using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke;

public static partial class User32
{
#pragma warning disable IDE1006 // Naming Styles

	/// <summary>
	/// <para>The type of device that sent the input message.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ne-winuser-input_message_device_type typedef enum
	// tagINPUT_MESSAGE_DEVICE_TYPE { IMDT_UNAVAILABLE, IMDT_KEYBOARD, IMDT_MOUSE, IMDT_TOUCH, IMDT_PEN, IMDT_TOUCHPAD } INPUT_MESSAGE_DEVICE_TYPE;
	[PInvokeData("winuser.h", MSDNShortId = "aaaa8d9b-1056-4fa3-afcf-43d2c4b41c0e")]
	[Flags]
	public enum INPUT_MESSAGE_DEVICE_TYPE
	{
		/// <summary>The device type isn't identified.</summary>
		IMDT_UNAVAILABLE = 0x00,

		/// <summary>Keyboard input.</summary>
		IMDT_KEYBOARD = 0x01,

		/// <summary>Mouse input.</summary>
		IMDT_MOUSE = 0x02,

		/// <summary>Touch input.</summary>
		IMDT_TOUCH = 0x04,

		/// <summary>Pen or stylus input.</summary>
		IMDT_PEN = 0x08,

		/// <summary>Touchpad input (Windows 8.1 and later).</summary>
		IMDT_TOUCHPAD = 0x10,
	}

	/// <summary>The ID of the input message source.</summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ne-winuser-input_message_origin_id typedef enum
	// tagINPUT_MESSAGE_ORIGIN_ID { IMO_UNAVAILABLE, IMO_HARDWARE, IMO_INJECTED, IMO_SYSTEM } INPUT_MESSAGE_ORIGIN_ID;
	[PInvokeData("winuser.h", MSDNShortId = "5637bf3a-9fd8-4c89-acd0-4e0e47c0a3bf")]
	[Flags]
	public enum INPUT_MESSAGE_ORIGIN_ID
	{
		/// <summary>The source isn't identified.</summary>
		IMO_UNAVAILABLE = 0x00,

		/// <summary>
		/// The input message is from a hardware device or has been injected into the message queue by an application that has the
		/// UIAccess attribute set to TRUE in its manifest file. For more information about the UIAccess attribute and application
		/// manifests, see UAC References.
		/// </summary>
		IMO_HARDWARE = 0x01,

		/// <summary>
		/// The input message has been injected (through the SendInput function) by an application that doesn't have the UIAccess
		/// attribute set to TRUE in its manifest file.
		/// </summary>
		IMO_INJECTED = 0x02,

		/// <summary>The system has injected the input message.</summary>
		IMO_SYSTEM = 0x04,
	}

	/// <summary>Type for <see cref="INPUT"/> structure.</summary>
	[PInvokeData("winuser.h", MSDNShortId = "")]
	public enum INPUTTYPE
	{
		/// <summary>The event is a mouse event. Use the mi structure of the union.</summary>
		INPUT_MOUSE = 0,

		/// <summary>The event is a keyboard event. Use the ki structure of the union.</summary>
		INPUT_KEYBOARD = 1,

		/// <summary>The event is a hardware event. Use the hi structure of the union.</summary>
		INPUT_HARDWARE = 2,
	}

	/// <summary>The mouse state flags.</summary>
	[PInvokeData("winuser.h")]
	[Flags]
	public enum MouseState : ushort
	{
		/// <summary>Mouse attributes changed; application needs to query the mouse attributes.</summary>
		MOUSE_ATTRIBUTES_CHANGED = 0x04,

		/// <summary>Mouse movement data is relative to the last mouse position.</summary>
		MOUSE_MOVE_RELATIVE = 0,

		/// <summary>Mouse movement data is based on absolute position.</summary>
		MOUSE_MOVE_ABSOLUTE = 1,

		/// <summary>Mouse coordinates are mapped to the virtual desktop (for a multiple monitor system).</summary>
		MOUSE_VIRTUAL_DESKTOP = 0x02,

		/// <summary>Do not coalesce mouse moves.</summary>
		MOUSE_MOVE_NOCOALESCE = 0x08,
	}

	/// <summary>Flags for scan code information.</summary>
	[PInvokeData("winuser.h")]
	[Flags]
	public enum RI_KEY : ushort
	{
		/// <summary>The key is down.</summary>
		RI_KEY_MAKE = 0,

		/// <summary>The key is up.</summary>
		RI_KEY_BREAK = 1,

		/// <summary>The scan code has the E0 prefix.</summary>
		RI_KEY_E0 = 2,

		/// <summary>The scan code has the E1 prefix.</summary>
		RI_KEY_E1 = 4,

		/// <summary>Undocumented</summary>
		RI_KEY_TERMSRV_SET_LED = 8,

		/// <summary>Undocumented</summary>
		RI_KEY_TERMSRV_SHADOW = 0x10
	}

	/// <summary>Mouse button transition state indicators.</summary>
	[PInvokeData("winuser.h")]
	[Flags]
	public enum RI_MOUSE : ushort
	{
		/// <summary>Left button changed to down.</summary>
		RI_MOUSE_LEFT_BUTTON_DOWN = 0x0001,

		/// <summary>Left button changed to up.</summary>
		RI_MOUSE_LEFT_BUTTON_UP = 0x0002,

		/// <summary>Right button changed to down.</summary>
		RI_MOUSE_RIGHT_BUTTON_DOWN = 0x0004,

		/// <summary>Right button changed to up.</summary>
		RI_MOUSE_RIGHT_BUTTON_UP = 0x0008,

		/// <summary>Middle button changed to down.</summary>
		RI_MOUSE_MIDDLE_BUTTON_DOWN = 0x0010,

		/// <summary>Middle button changed to up.</summary>
		RI_MOUSE_MIDDLE_BUTTON_UP = 0x0020,

		/// <summary>RI_MOUSE_LEFT_BUTTON_DOWN</summary>
		RI_MOUSE_BUTTON_1_DOWN = RI_MOUSE_LEFT_BUTTON_DOWN,

		/// <summary>RI_MOUSE_LEFT_BUTTON_UP</summary>
		RI_MOUSE_BUTTON_1_UP = RI_MOUSE_LEFT_BUTTON_UP,

		/// <summary>RI_MOUSE_RIGHT_BUTTON_DOWN</summary>
		RI_MOUSE_BUTTON_2_DOWN = RI_MOUSE_RIGHT_BUTTON_DOWN,

		/// <summary>RI_MOUSE_RIGHT_BUTTON_UP</summary>
		RI_MOUSE_BUTTON_2_UP = RI_MOUSE_RIGHT_BUTTON_UP,

		/// <summary>RI_MOUSE_MIDDLE_BUTTON_DOWN</summary>
		RI_MOUSE_BUTTON_3_DOWN = RI_MOUSE_MIDDLE_BUTTON_DOWN,

		/// <summary>RI_MOUSE_MIDDLE_BUTTON_UP</summary>
		RI_MOUSE_BUTTON_3_UP = RI_MOUSE_MIDDLE_BUTTON_UP,

		/// <summary>XBUTTON1 changed to down.</summary>
		RI_MOUSE_BUTTON_4_DOWN = 0x0040,

		/// <summary>XBUTTON1 changed to up.</summary>
		RI_MOUSE_BUTTON_4_UP = 0x0080,

		/// <summary>XBUTTON2 changed to down.</summary>
		RI_MOUSE_BUTTON_5_DOWN = 0x0100,

		/// <summary>XBUTTON2 changed to up.</summary>
		RI_MOUSE_BUTTON_5_UP = 0x0200,

		/// <summary>Raw input comes from a mouse wheel. The wheel delta is stored in usButtonData.</summary>
		RI_MOUSE_WHEEL = 0x0400,

		/// <summary>Raw input comes from a mouse horizontal wheel. The wheel delta is stored in usButtonData.</summary>
		RI_MOUSE_HWHEEL = 0x0800,
	}

	/// <summary>The command flag for <see cref="GetRawInputData"/>.</summary>
	[PInvokeData("winuser.h", MSDNShortId = "")]
	public enum RID
	{
		/// <summary>Get the raw data from the RAWINPUT structure.</summary>
		RID_INPUT = 0x10000003,

		/// <summary>Get the header information from the RAWINPUT structure.</summary>
		RID_HEADER = 0x10000005
	}

	/// <summary>Mode flag that specifies how to interpret the information provided by usUsagePage and usUsage in <see cref="RAWINPUTDEVICE"/>.</summary>
	[PInvokeData("winuser.h", MSDNShortId = "")]
	[Flags]
	public enum RIDEV : uint
	{
		/// <summary>
		/// If set, the application command keys are handled. RIDEV_APPKEYS can be specified only if RIDEV_NOLEGACY is specified for a
		/// keyboard device.
		/// </summary>
		RIDEV_APPKEYS = 0x00000400,

		/// <summary>If set, the mouse button click does not activate the other window.</summary>
		RIDEV_CAPTUREMOUSE = 0x00000200,

		/// <summary>
		/// If set, this enables the caller to receive WM_INPUT_DEVICE_CHANGE notifications for device arrival and device removal.
		/// <page>Windows XP: This flag is not supported until Windows Vista</page>
		/// </summary>
		RIDEV_DEVNOTIFY = 0x00002000,

		/// <summary>
		/// If set, this specifies the top level collections to exclude when reading a complete usage page. This flag only affects a TLC
		/// whose usage page is already specified with RIDEV_PAGEONLY.
		/// </summary>
		RIDEV_EXCLUDE = 0x00000010,

		/// <summary>
		/// If set, this enables the caller to receive input in the background only if the foreground application does not process it.
		/// In other words, if the foreground application is not registered for raw input, then the background application that is
		/// registered will receive the input. <page>Windows XP: This flag is not supported until Windows Vista</page>
		/// </summary>
		RIDEV_EXINPUTSINK = 0x00001000,

		/// <summary>
		/// If set, this enables the caller to receive the input even when the caller is not in the foreground. Note that hwndTarget
		/// must be specified.
		/// </summary>
		RIDEV_INPUTSINK = 0x00000100,

		/// <summary>
		/// If set, the application-defined keyboard device hotkeys are not handled. However, the system hotkeys; for example, ALT+TAB
		/// and CTRL+ALT+DEL, are still handled. By default, all keyboard hotkeys are handled. RIDEV_NOHOTKEYS can be specified even if
		/// RIDEV_NOLEGACY is not specified and hwndTarget is NULL.
		/// </summary>
		RIDEV_NOHOTKEYS = 0x00000200,

		/// <summary>
		/// If set, this prevents any devices specified by usUsagePage or usUsage from generating legacy messages. This is only for the
		/// mouse and keyboard. See Remarks.
		/// </summary>
		RIDEV_NOLEGACY = 0x00000030,

		/// <summary>
		/// If set, this specifies all devices whose top level collection is from the specified usUsagePage. Note that usUsage must be
		/// zero. To exclude a particular top level collection, use RIDEV_EXCLUDE.
		/// </summary>
		RIDEV_PAGEONLY = 0x00000020,

		/// <summary>
		/// If set, this removes the top level collection from the inclusion list. This tells the operating system to stop reading from
		/// a device which matches the top level collection.
		/// </summary>
		RIDEV_REMOVE = 0x00000001,
	}

	/// <summary>The type of raw input.</summary>
	[PInvokeData("winuser.h")]
	public enum RIM_TYPE
	{
		/// <summary>Raw input comes from some device that is not a keyboard or a mouse.</summary>
		RIM_TYPEHID = 2,

		/// <summary>Raw input comes from the keyboard.</summary>
		RIM_TYPEKEYBOARD = 1,

		/// <summary>Raw input comes from the mouse.</summary>
		RIM_TYPEMOUSE = 0,
	}

	/// <summary>
	/// Calls the default raw input procedure to provide default processing for any raw input messages that an application does not
	/// process. This function ensures that every message is processed. <c>DefRawInputProc</c> is called with the same parameters
	/// received by the window procedure.
	/// </summary>
	/// <param name="paRawInput">
	/// <para>Type: <c>PRAWINPUT*</c></para>
	/// <para>An array of RAWINPUT structures.</para>
	/// </param>
	/// <param name="nInput">
	/// <para>Type: <c>INT</c></para>
	/// <para>The number of RAWINPUT structures pointed to by paRawInput.</para>
	/// </param>
	/// <param name="cbSizeHeader">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The size, in bytes, of the RAWINPUTHEADER structure.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>LRESULT</c></para>
	/// <para>If successful, the function returns <c>S_OK</c>. Otherwise it returns an error value.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-defrawinputproc LRESULT DefRawInputProc( PRAWINPUT
	// *paRawInput, INT nInput, UINT cbSizeHeader );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h")]
	public static extern IntPtr DefRawInputProc(RAWINPUT[] paRawInput, int nInput, uint cbSizeHeader);

	/// <summary>Retrieves the source of the input message.</summary>
	/// <param name="inputMessageSource">
	/// <para>The INPUT_MESSAGE_SOURCE structure that holds the device type and the ID of the input message source.</para>
	/// <para>
	/// <c>Note</c><c>deviceType</c> in INPUT_MESSAGE_SOURCE is set to IMDT_UNAVAILABLE when SendMessage is used to inject input (system
	/// generated or through messages such as WM_PAINT). This remains true until <c>SendMessage</c> returns.
	/// </para>
	/// </param>
	/// <returns>
	/// If this function succeeds, it returns TRUE. Otherwise, it returns FALSE. To retrieve extended error information, call the
	/// GetLastError function.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getcurrentinputmessagesource BOOL
	// GetCurrentInputMessageSource( INPUT_MESSAGE_SOURCE *inputMessageSource );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "35e4ebf5-df9d-4168-9996-355204c2ab93")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetCurrentInputMessageSource(ref INPUT_MESSAGE_SOURCE inputMessageSource);

	/// <summary>Retrieves the time of the last input event.</summary>
	/// <param name="plii">
	/// <para>Type: <c>PLASTINPUTINFO</c></para>
	/// <para>A pointer to a LASTINPUTINFO structure that receives the time of the last input event.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function is useful for input idle detection. However, <c>GetLastInputInfo</c> does not provide system-wide user input
	/// information across all running sessions. Rather, <c>GetLastInputInfo</c> provides session-specific user input information for
	/// only the session that invoked the function.
	/// </para>
	/// <para>
	/// The tick count when the last input event was received (see LASTINPUTINFO) is not guaranteed to be incremental. In some cases,
	/// the value might be less than the tick count of a prior event. For example, this can be caused by a timing gap between the raw
	/// input thread and the desktop thread or an event raised by SendInput, which supplies its own tick count.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getlastinputinfo BOOL GetLastInputInfo( PLASTINPUTINFO
	// plii );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

	/// <summary>Performs a buffered read of the raw input data.</summary>
	/// <param name="pData">
	/// <para>Type: <c>PRAWINPUT</c></para>
	/// <para>
	/// A pointer to a buffer of RAWINPUT structures that contain the raw input data. If <c>NULL</c>, the minimum required buffer, in
	/// bytes, is returned in *pcbSize.
	/// </para>
	/// </param>
	/// <param name="pcbSize">
	/// <para>Type: <c>PUINT</c></para>
	/// <para>The size, in bytes, of a RAWINPUT structure.</para>
	/// </param>
	/// <param name="cbSizeHeader">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The size, in bytes, of the RAWINPUTHEADER structure.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>UINT</c></para>
	/// <para>
	/// If pData is NULL and the function is successful, the return value is zero. If pData is not NULL and the function is successful,
	/// the return value is the number of RAWINPUT structures written to pData.
	/// </para>
	/// <para>If an error occurs, the return value is ( <c>UINT</c>)-1. Call GetLastError for the error code.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Using <c>GetRawInputBuffer</c>, the raw input data is buffered in the array of RAWINPUT structures. For an unbuffered read, use
	/// the GetMessage function to read in the raw input data.
	/// </para>
	/// <para>The NEXTRAWINPUTBLOCK macro allows an application to traverse an array of RAWINPUT structures.</para>
	/// <para>
	/// <c>Note</c> To get the correct size of the raw input buffer, do not use *pcbSize, use *pcbSize * 8 instead. To ensure
	/// <c>GetRawInputBuffer</c> behaves properly on WOW64, you must align the RAWINPUT structure by 8 bytes. The following code shows
	/// how to align <c>RAWINPUT</c> for WOW64.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getrawinputbuffer UINT GetRawInputBuffer( PRAWINPUT
	// pData, PUINT pcbSize, UINT cbSizeHeader );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "")]
	public static extern uint GetRawInputBuffer([Optional] IntPtr pData, ref uint pcbSize, uint cbSizeHeader);

	/// <summary>Retrieves the raw input from the specified device.</summary>
	/// <param name="hRawInput">
	/// <para>Type: <c>HRAWINPUT</c></para>
	/// <para>A handle to the RAWINPUT structure. This comes from the lParam in WM_INPUT.</para>
	/// </param>
	/// <param name="uiCommand">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The command flag. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>RID_HEADER 0x10000005</term>
	/// <term>Get the header information from the RAWINPUT structure.</term>
	/// </item>
	/// <item>
	/// <term>RID_INPUT 0x10000003</term>
	/// <term>Get the raw data from the RAWINPUT structure.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pData">
	/// <para>Type: <c>LPVOID</c></para>
	/// <para>
	/// A pointer to the data that comes from the RAWINPUT structure. This depends on the value of uiCommand. If pData is <c>NULL</c>,
	/// the required size of the buffer is returned in *pcbSize.
	/// </para>
	/// </param>
	/// <param name="pcbSize">
	/// <para>Type: <c>PUINT</c></para>
	/// <para>The size, in bytes, of the data in pData.</para>
	/// </param>
	/// <param name="cbSizeHeader">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The size, in bytes, of the RAWINPUTHEADER structure.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>UINT</c></para>
	/// <para>
	/// If pData is <c>NULL</c> and the function is successful, the return value is 0. If pData is not <c>NULL</c> and the function is
	/// successful, the return value is the number of bytes copied into pData.
	/// </para>
	/// <para>If there is an error, the return value is ( <c>UINT</c>)-1.</para>
	/// </returns>
	/// <remarks>
	/// <c>GetRawInputData</c> gets the raw input one RAWINPUT structure at a time. In contrast, GetRawInputBuffer gets an array of
	/// <c>RAWINPUT</c> structures.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getrawinputdata UINT GetRawInputData( HRAWINPUT
	// hRawInput, UINT uiCommand, LPVOID pData, PUINT pcbSize, UINT cbSizeHeader );
	[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winuser.h")]
	public static extern uint GetRawInputData(HRAWINPUT hRawInput, RID uiCommand, [Optional] IntPtr pData, ref uint pcbSize, uint cbSizeHeader);

	/// <summary>Retrieves information about the raw input device.</summary>
	/// <param name="hDevice">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>A handle to the raw input device. This comes from the <c>hDevice</c> member of RAWINPUTHEADER or from GetRawInputDeviceList.</para>
	/// </param>
	/// <param name="uiCommand">
	/// <para>Type: <c>UINT</c></para>
	/// <para>Specifies what data will be returned in pData. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>RIDI_DEVICENAME 0x20000007</term>
	/// <term>
	/// pData points to a string that contains the device name. For this uiCommand only, the value in pcbSize is the character count
	/// (not the byte count).
	/// </term>
	/// </item>
	/// <item>
	/// <term>RIDI_DEVICEINFO 0x2000000b</term>
	/// <term>pData points to an RID_DEVICE_INFO structure.</term>
	/// </item>
	/// <item>
	/// <term>RIDI_PREPARSEDDATA 0x20000005</term>
	/// <term>pData points to the previously parsed data.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pData">
	/// <para>Type: <c>LPVOID</c></para>
	/// <para>
	/// A pointer to a buffer that contains the information specified by uiCommand. If uiCommand is <c>RIDI_DEVICEINFO</c>, set the
	/// <c>cbSize</c> member of RID_DEVICE_INFO to before calling <c>GetRawInputDeviceInfo</c>.
	/// </para>
	/// </param>
	/// <param name="pcbSize">
	/// <para>Type: <c>PUINT</c></para>
	/// <para>The size, in bytes, of the data in pData.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>UINT</c></para>
	/// <para>If successful, this function returns a non-negative number indicating the number of bytes copied to pData.</para>
	/// <para>
	/// If pData is not large enough for the data, the function returns -1. If pData is <c>NULL</c>, the function returns a value of
	/// zero. In both of these cases, pcbSize is set to the minimum size required for the pData buffer.
	/// </para>
	/// <para>Call GetLastError to identify any other errors.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getrawinputdeviceinfoa UINT GetRawInputDeviceInfoA(
	// HANDLE hDevice, UINT uiCommand, LPVOID pData, PUINT pcbSize );
	[DllImport(Lib.User32, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("winuser.h", MSDNShortId = "")]
	public static extern uint GetRawInputDeviceInfo(HANDLE hDevice, uint uiCommand, [Optional] IntPtr pData, ref uint pcbSize);

	/// <summary>Enumerates the raw input devices attached to the system.</summary>
	/// <param name="pRawInputDeviceList">
	/// <para>Type: <c>PRAWINPUTDEVICELIST</c></para>
	/// <para>
	/// An array of RAWINPUTDEVICELIST structures for the devices attached to the system. If <c>NULL</c>, the number of devices are
	/// returned in *puiNumDevices.
	/// </para>
	/// </param>
	/// <param name="puiNumDevices">
	/// <para>Type: <c>PUINT</c></para>
	/// <para>
	/// If pRawInputDeviceList is <c>NULL</c>, the function populates this variable with the number of devices attached to the system;
	/// otherwise, this variable specifies the number of RAWINPUTDEVICELIST structures that can be contained in the buffer to which
	/// pRawInputDeviceList points. If this value is less than the number of devices attached to the system, the function returns the
	/// actual number of devices in this variable and fails with <c>ERROR_INSUFFICIENT_BUFFER</c>.
	/// </para>
	/// </param>
	/// <param name="cbSize">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The size of a RAWINPUTDEVICELIST structure, in bytes.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>UINT</c></para>
	/// <para>If the function is successful, the return value is the number of devices stored in the buffer pointed to by pRawInputDeviceList.</para>
	/// <para>On any other error, the function returns ( <c>UINT</c>) -1 and GetLastError returns the error indication.</para>
	/// </returns>
	/// <remarks>
	/// <para>The devices returned from this function are the mouse, the keyboard, and other Human Interface Device (HID) devices.</para>
	/// <para>To get more detailed information about the attached devices, call GetRawInputDeviceInfo using the hDevice from RAWINPUTDEVICELIST.</para>
	/// <para>Examples</para>
	/// <para>The following sample code shows a typical call to <c>GetRawInputDeviceList</c>:</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getrawinputdevicelist UINT GetRawInputDeviceList(
	// PRAWINPUTDEVICELIST pRawInputDeviceList, PUINT puiNumDevices, UINT cbSize );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "")]
	public static extern uint GetRawInputDeviceList([In, Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] RAWINPUTDEVICELIST[]? pRawInputDeviceList, ref uint puiNumDevices, uint cbSize);

	/// <summary>Retrieves the information about the raw input devices for the current application.</summary>
	/// <param name="pRawInputDevices">
	/// <para>Type: <c>PRAWINPUTDEVICE</c></para>
	/// <para>An array of RAWINPUTDEVICE structures for the application.</para>
	/// </param>
	/// <param name="puiNumDevices">
	/// <para>Type: <c>PUINT</c></para>
	/// <para>The number of RAWINPUTDEVICE structures in *pRawInputDevices.</para>
	/// </param>
	/// <param name="cbSize">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The size, in bytes, of a RAWINPUTDEVICE structure.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>UINT</c></para>
	/// <para>
	/// If successful, the function returns a non-negative number that is the number of RAWINPUTDEVICE structures written to the buffer.
	/// </para>
	/// <para>
	/// If the pRawInputDevices buffer is too small or <c>NULL</c>, the function sets the last error as
	/// <c>ERROR_INSUFFICIENT_BUFFER</c>, returns -1, and sets puiNumDevices to the required number of devices. If the function fails
	/// for any other reason, it returns -1. For more details, call GetLastError.
	/// </para>
	/// </returns>
	/// <remarks>To receive raw input from a device, an application must register it by using RegisterRawInputDevices.</remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getregisteredrawinputdevices UINT
	// GetRegisteredRawInputDevices( PRAWINPUTDEVICE pRawInputDevices, PUINT puiNumDevices, UINT cbSize );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "")]
	public static extern uint GetRegisteredRawInputDevices([In, Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] RAWINPUTDEVICE[]? pRawInputDevices, ref uint puiNumDevices, uint cbSize);

	/// <summary>Registers the devices that supply the raw input data.</summary>
	/// <param name="pRawInputDevices">
	/// <para>Type: <c>PCRAWINPUTDEVICE</c></para>
	/// <para>An array of RAWINPUTDEVICE structures that represent the devices that supply the raw input.</para>
	/// </param>
	/// <param name="uiNumDevices">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The number of RAWINPUTDEVICE structures pointed to by pRawInputDevices.</para>
	/// </param>
	/// <param name="cbSize">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The size, in bytes, of a RAWINPUTDEVICE structure.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para><c>TRUE</c> if the function succeeds; otherwise, <c>FALSE</c>. If the function fails, call GetLastError for more information.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// To receive WM_INPUT messages, an application must first register the raw input devices using <c>RegisterRawInputDevices</c>. By
	/// default, an application does not receive raw input.
	/// </para>
	/// <para>
	/// To receive WM_INPUT_DEVICE_CHANGE messages, an application must specify the RIDEV_DEVNOTIFY flag for each device class that is
	/// specified by the usUsagePage and usUsage fields of the RAWINPUTDEVICE structure . By default, an application does not receive
	/// <c>WM_INPUT_DEVICE_CHANGE</c> notifications for raw input device arrival and removal.
	/// </para>
	/// <para>
	/// If a RAWINPUTDEVICE structure has the RIDEV_REMOVE flag set and the hwndTarget parameter is not set to NULL, then parameter
	/// validation will fail.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-registerrawinputdevices BOOL RegisterRawInputDevices(
	// PCRAWINPUTDEVICE pRawInputDevices, UINT uiNumDevices, UINT cbSize );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool RegisterRawInputDevices([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] RAWINPUTDEVICE[] pRawInputDevices, uint uiNumDevices, uint cbSize);

	/// <summary>Synthesizes keystrokes, mouse motions, and button clicks.</summary>
	/// <param name="cInputs">
	/// <para>Type: <c>UINT</c></para>
	/// <para>The number of structures in the pInputs array.</para>
	/// </param>
	/// <param name="pInputs">
	/// <para>Type: <c>LPINPUT</c></para>
	/// <para>An array of INPUT structures. Each structure represents an event to be inserted into the keyboard or mouse input stream.</para>
	/// </param>
	/// <param name="cbSize">
	/// <para>Type: <c>int</c></para>
	/// <para>The size, in bytes, of an INPUT structure. If cbSize is not the size of an <c>INPUT</c> structure, the function fails.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>UINT</c></para>
	/// <para>
	/// The function returns the number of events that it successfully inserted into the keyboard or mouse input stream. If the function
	/// returns zero, the input was already blocked by another thread. To get extended error information, call GetLastError.
	/// </para>
	/// <para>
	/// This function fails when it is blocked by UIPI. Note that neither GetLastError nor the return value will indicate the failure
	/// was caused by UIPI blocking.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function is subject to UIPI. Applications are permitted to inject input only into applications that are at an equal or
	/// lesser integrity level.
	/// </para>
	/// <para>
	/// The <c>SendInput</c> function inserts the events in the INPUT structures serially into the keyboard or mouse input stream. These
	/// events are not interspersed with other keyboard or mouse input events inserted either by the user (with the keyboard or mouse)
	/// or by calls to keybd_event, mouse_event, or other calls to <c>SendInput</c>.
	/// </para>
	/// <para>
	/// This function does not reset the keyboard's current state. Any keys that are already pressed when the function is called might
	/// interfere with the events that this function generates. To avoid this problem, check the keyboard's state with the
	/// GetAsyncKeyState function and correct as necessary.
	/// </para>
	/// <para>
	/// Because the touch keyboard uses the surrogate macros defined in winnls.h to send input to the system, a listener on the keyboard
	/// event hook must decode input originating from the touch keyboard. For more information, see Surrogates and Supplementary Characters.
	/// </para>
	/// <para>
	/// An accessibility application can use <c>SendInput</c> to inject keystrokes corresponding to application launch shortcut keys
	/// that are handled by the shell. This functionality is not guaranteed to work for other types of applications.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-sendinput UINT SendInput( UINT cInputs, LPINPUT pInputs,
	// int cbSize );
	[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("winuser.h", MSDNShortId = "")]
	public static extern uint SendInput(uint cInputs, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] INPUT[] pInputs, int cbSize);

	/// <summary>Contains information about a simulated message generated by an input device other than a keyboard or mouse.</summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ns-winuser-taghardwareinput typedef struct tagHARDWAREINPUT { DWORD
	// uMsg; WORD wParamL; WORD wParamH; } HARDWAREINPUT, *PHARDWAREINPUT, *LPHARDWAREINPUT;
	[PInvokeData("winuser.h", MSDNShortId = "")]
	[StructLayout(LayoutKind.Sequential)]
	public struct HARDWAREINPUT
	{
		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The message generated by the input hardware.</para>
		/// </summary>
		public uint uMsg;

		/// <summary>
		/// <para>Type: <c>WORD</c></para>
		/// <para>The low-order word of the lParam parameter for <c>uMsg</c>.</para>
		/// </summary>
		public ushort wParamL;

		/// <summary>
		/// <para>Type: <c>WORD</c></para>
		/// <para>The high-order word of the lParam parameter for <c>uMsg</c>.</para>
		/// </summary>
		public ushort wParamH;
	}

	/// <summary>Provides a handle to a RAWINPUT structure.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public readonly struct HRAWINPUT : IHandle
	{
		private readonly IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="HRAWINPUT"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HRAWINPUT(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HRAWINPUT"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HRAWINPUT NULL => new(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="HRAWINPUT"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(HRAWINPUT h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HRAWINPUT"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HRAWINPUT(IntPtr h) => new(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HRAWINPUT h1, HRAWINPUT h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HRAWINPUT h1, HRAWINPUT h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj is HRAWINPUT h && handle == h.handle;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>
	/// Used by SendInput to store information for synthesizing input events such as keystrokes, mouse movement, and mouse clicks.
	/// </summary>
	/// <remarks>
	/// <c>INPUT_KEYBOARD</c> supports nonkeyboard input methods, such as handwriting recognition or voice recognition, as if it were
	/// text input by using the <c>KEYEVENTF_UNICODE</c> flag. For more information, see the remarks section of KEYBDINPUT.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ns-winuser-taginput typedef struct tagINPUT { DWORD type; union {
	// MOUSEINPUT mi; KEYBDINPUT ki; HARDWAREINPUT hi; } DUMMYUNIONNAME; } INPUT, *PINPUT, *LPINPUT;
	[PInvokeData("winuser.h", MSDNShortId = "")]
	[StructLayout(LayoutKind.Sequential)]
	public struct INPUT
	{
		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The type of the input event. This member can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>INPUT_MOUSE 0</term>
		/// <term>The event is a mouse event. Use the mi structure of the union.</term>
		/// </item>
		/// <item>
		/// <term>INPUT_KEYBOARD 1</term>
		/// <term>The event is a keyboard event. Use the ki structure of the union.</term>
		/// </item>
		/// <item>
		/// <term>INPUT_HARDWARE 2</term>
		/// <term>The event is a hardware event. Use the hi structure of the union.</term>
		/// </item>
		/// </list>
		/// </summary>
		public INPUTTYPE type;

		private UNION union;

		/// <summary>
		/// <para>Type: <c>MOUSEINPUT</c></para>
		/// <para>The information about a simulated mouse event.</para>
		/// </summary>
		public MOUSEINPUT mi { get => union.mi; set => union.mi = value; }

		/// <summary>
		/// <para>Type: <c>KEYBDINPUT</c></para>
		/// <para>The information about a simulated keyboard event.</para>
		/// </summary>
		public KEYBDINPUT ki { get => union.ki; set => union.ki = value; }

		/// <summary>
		/// <para>Type: <c>HARDWAREINPUT</c></para>
		/// <para>The information about a simulated hardware event.</para>
		/// </summary>
		public HARDWAREINPUT hi { get => union.hi; set => union.hi = value; }

		[StructLayout(LayoutKind.Explicit)]
		private struct UNION
		{
			[FieldOffset(0)]
			public MOUSEINPUT mi;

			[FieldOffset(0)]
			public KEYBDINPUT ki;

			[FieldOffset(0)]
			public HARDWAREINPUT hi;
		}

		/// <summary>Initializes a new instance of the <see cref="INPUT"/> struct for keyboard input.</summary>
		/// <param name="keyFlags">Specifies various aspects of a keystroke.</param>
		/// <param name="vkOrScan">
		/// If KEYEVENTF_SCANCODE, the value represents a hardware scan code for the key, otherwise, this value represents a virtual key-code.
		/// </param>
		public INPUT(KEYEVENTF keyFlags, ushort vkOrScan)
		{
			type = INPUTTYPE.INPUT_KEYBOARD;
			union = new UNION { ki = new KEYBDINPUT { dwFlags = keyFlags, wVk = (keyFlags & KEYEVENTF.KEYEVENTF_SCANCODE) == 0 ? vkOrScan : (ushort)0, wScan = (keyFlags & KEYEVENTF.KEYEVENTF_SCANCODE) != 0 ? vkOrScan : (ushort)0 } };
		}

		/// <summary>Initializes a new instance of the <see cref="INPUT"/> struct for mouse input.</summary>
		/// <param name="keyFlags">A set of bit flags that specify various aspects of mouse motion and button clicks.</param>
		/// <param name="mouseData">
		/// <para>
		/// If <c>dwFlags</c> contains <c>MOUSEEVENTF_WHEEL</c>, then <c>mouseData</c> specifies the amount of wheel movement. A
		/// positive value indicates that the wheel was rotated forward, away from the user; a negative value indicates that the wheel
		/// was rotated backward, toward the user. One wheel click is defined as <c>WHEEL_DELTA</c>, which is 120.
		/// </para>
		/// <para>
		/// Windows Vista: If dwFlags contains <c>MOUSEEVENTF_HWHEEL</c>, then dwData specifies the amount of wheel movement. A positive
		/// value indicates that the wheel was rotated to the right; a negative value indicates that the wheel was rotated to the left.
		/// One wheel click is defined as <c>WHEEL_DELTA</c>, which is 120.
		/// </para>
		/// <para>
		/// If <c>dwFlags</c> does not contain <c>MOUSEEVENTF_WHEEL</c>, <c>MOUSEEVENTF_XDOWN</c>, or <c>MOUSEEVENTF_XUP</c>, then
		/// <c>mouseData</c> should be zero.
		/// </para>
		/// <para>
		/// If <c>dwFlags</c> contains <c>MOUSEEVENTF_XDOWN</c> or <c>MOUSEEVENTF_XUP</c>, then <c>mouseData</c> specifies which X
		/// buttons were pressed or released. This value may be any combination of the following flags.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>XBUTTON1 0x0001</term>
		/// <term>Set if the first X button is pressed or released.</term>
		/// </item>
		/// <item>
		/// <term>XBUTTON2 0x0002</term>
		/// <term>Set if the second X button is pressed or released.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="dx">
		/// The absolute position of the mouse, or the amount of motion since the last mouse event was generated, depending on the value
		/// of the <c>dwFlags</c> member. Absolute data is specified as the x coordinate of the mouse; relative data is specified as the
		/// number of pixels moved.
		/// </param>
		/// <param name="dy">
		/// The absolute position of the mouse, or the amount of motion since the last mouse event was generated, depending on the value
		/// of the <c>dwFlags</c> member. Absolute data is specified as the y coordinate of the mouse; relative data is specified as the
		/// number of pixels moved.
		/// </param>
		public INPUT(MOUSEEVENTF keyFlags, int mouseData = 0, int dx = 0, int dy = 0)
		{
			type = INPUTTYPE.INPUT_MOUSE;
			union = new UNION { mi = new MOUSEINPUT { dwFlags = keyFlags, dx = dx, dy = dy, mouseData = mouseData } };
		}
	}

	/// <summary>Contains information about the source of the input message.</summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ns-winuser-taginput_message_source typedef struct
	// tagINPUT_MESSAGE_SOURCE { INPUT_MESSAGE_DEVICE_TYPE deviceType; INPUT_MESSAGE_ORIGIN_ID originId; } INPUT_MESSAGE_SOURCE;
	[PInvokeData("winuser.h", MSDNShortId = "75437c0a-925a-44d9-9254-43095b281c21")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct INPUT_MESSAGE_SOURCE
	{
		/// <summary>The device type (INPUT_MESSAGE_DEVICE_TYPE) of the source of the input message.</summary>
		public INPUT_MESSAGE_DEVICE_TYPE deviceType;

		/// <summary>The ID (INPUT_MESSAGE_ORIGIN_ID) of the source of the input message.</summary>
		public INPUT_MESSAGE_ORIGIN_ID originId;
	}

	/// <summary>Contains the time of the last input.</summary>
	/// <remarks>This function is useful for input idle detection. For more information on tick counts, see GetTickCount.</remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ns-winuser-taglastinputinfo typedef struct tagLASTINPUTINFO { UINT
	// cbSize; DWORD dwTime; } LASTINPUTINFO, *PLASTINPUTINFO;
	[PInvokeData("winuser.h", MSDNShortId = "")]
	[StructLayout(LayoutKind.Sequential)]
	public struct LASTINPUTINFO
	{
		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The size of the structure, in bytes. This member must be set to sizeof(LASTINPUTINFO).</para>
		/// </summary>
		public uint cbSize;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The tick count when the last input event was received.</para>
		/// </summary>
		public uint dwTime;

		/// <summary>Gets a default instance with the size field set appropriately.</summary>
		public static readonly LASTINPUTINFO Default = new() { cbSize = (uint)Marshal.SizeOf(typeof(LASTINPUTINFO)) };
	}

	/// <summary>Contains information about a simulated mouse event.</summary>
	/// <remarks>
	/// <para>
	/// If the mouse has moved, indicated by <c>MOUSEEVENTF_MOVE</c>, <c>dx</c> and <c>dy</c> specify information about that movement.
	/// The information is specified as absolute or relative integer values.
	/// </para>
	/// <para>
	/// If <c>MOUSEEVENTF_ABSOLUTE</c> value is specified, <c>dx</c> and <c>dy</c> contain normalized absolute coordinates between 0 and
	/// 65,535. The event procedure maps these coordinates onto the display surface. Coordinate (0,0) maps onto the upper-left corner of
	/// the display surface; coordinate (65535,65535) maps onto the lower-right corner. In a multimonitor system, the coordinates map to
	/// the primary monitor.
	/// </para>
	/// <para>If <c>MOUSEEVENTF_VIRTUALDESK</c> is specified, the coordinates map to the entire virtual desktop.</para>
	/// <para>
	/// If the <c>MOUSEEVENTF_ABSOLUTE</c> value is not specified, <c>dx</c> and <c>dy</c> specify movement relative to the previous
	/// mouse event (the last reported position). Positive values mean the mouse moved right (or down); negative values mean the mouse
	/// moved left (or up).
	/// </para>
	/// <para>
	/// Relative mouse motion is subject to the effects of the mouse speed and the two-mouse threshold values. A user sets these three
	/// values with the <c>Pointer Speed</c> slider of the Control Panel's <c>Mouse Properties</c> sheet. You can obtain and set these
	/// values using the SystemParametersInfo function.
	/// </para>
	/// <para>
	/// The system applies two tests to the specified relative mouse movement. If the specified distance along either the x or y axis is
	/// greater than the first mouse threshold value, and the mouse speed is not zero, the system doubles the distance. If the specified
	/// distance along either the x or y axis is greater than the second mouse threshold value, and the mouse speed is equal to two, the
	/// system doubles the distance that resulted from applying the first threshold test. It is thus possible for the system to multiply
	/// specified relative mouse movement along the x or y axis by up to four times.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ns-winuser-tagmouseinput typedef struct tagMOUSEINPUT { LONG dx;
	// LONG dy; DWORD mouseData; DWORD dwFlags; DWORD time; ULONG_PTR dwExtraInfo; } MOUSEINPUT, *PMOUSEINPUT, *LPMOUSEINPUT;
	[PInvokeData("winuser.h", MSDNShortId = "")]
	[StructLayout(LayoutKind.Sequential)]
	public struct MOUSEINPUT
	{
		/// <summary>
		/// <para>Type: <c>LONG</c></para>
		/// <para>
		/// The absolute position of the mouse, or the amount of motion since the last mouse event was generated, depending on the value
		/// of the <c>dwFlags</c> member. Absolute data is specified as the x coordinate of the mouse; relative data is specified as the
		/// number of pixels moved.
		/// </para>
		/// </summary>
		public int dx;

		/// <summary>
		/// <para>Type: <c>LONG</c></para>
		/// <para>
		/// The absolute position of the mouse, or the amount of motion since the last mouse event was generated, depending on the value
		/// of the <c>dwFlags</c> member. Absolute data is specified as the y coordinate of the mouse; relative data is specified as the
		/// number of pixels moved.
		/// </para>
		/// </summary>
		public int dy;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// If <c>dwFlags</c> contains <c>MOUSEEVENTF_WHEEL</c>, then <c>mouseData</c> specifies the amount of wheel movement. A
		/// positive value indicates that the wheel was rotated forward, away from the user; a negative value indicates that the wheel
		/// was rotated backward, toward the user. One wheel click is defined as <c>WHEEL_DELTA</c>, which is 120.
		/// </para>
		/// <para>
		/// Windows Vista: If dwFlags contains <c>MOUSEEVENTF_HWHEEL</c>, then dwData specifies the amount of wheel movement. A positive
		/// value indicates that the wheel was rotated to the right; a negative value indicates that the wheel was rotated to the left.
		/// One wheel click is defined as <c>WHEEL_DELTA</c>, which is 120.
		/// </para>
		/// <para>
		/// If <c>dwFlags</c> does not contain <c>MOUSEEVENTF_WHEEL</c>, <c>MOUSEEVENTF_XDOWN</c>, or <c>MOUSEEVENTF_XUP</c>, then
		/// <c>mouseData</c> should be zero.
		/// </para>
		/// <para>
		/// If <c>dwFlags</c> contains <c>MOUSEEVENTF_XDOWN</c> or <c>MOUSEEVENTF_XUP</c>, then <c>mouseData</c> specifies which X
		/// buttons were pressed or released. This value may be any combination of the following flags.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>XBUTTON1 0x0001</term>
		/// <term>Set if the first X button is pressed or released.</term>
		/// </item>
		/// <item>
		/// <term>XBUTTON2 0x0002</term>
		/// <term>Set if the second X button is pressed or released.</term>
		/// </item>
		/// </list>
		/// </summary>
		public int mouseData;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// A set of bit flags that specify various aspects of mouse motion and button clicks. The bits in this member can be any
		/// reasonable combination of the following values.
		/// </para>
		/// <para>
		/// The bit flags that specify mouse button status are set to indicate changes in status, not ongoing conditions. For example,
		/// if the left mouse button is pressed and held down, <c>MOUSEEVENTF_LEFTDOWN</c> is set when the left button is first pressed,
		/// but not for subsequent motions. Similarly, <c>MOUSEEVENTF_LEFTUP</c> is set only when the button is first released.
		/// </para>
		/// <para>
		/// You cannot specify both the <c>MOUSEEVENTF_WHEEL</c> flag and either <c>MOUSEEVENTF_XDOWN</c> or <c>MOUSEEVENTF_XUP</c>
		/// flags simultaneously in the <c>dwFlags</c> parameter, because they both require use of the <c>mouseData</c> field.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MOUSEEVENTF_ABSOLUTE 0x8000</term>
		/// <term>
		/// The dx and dy members contain normalized absolute coordinates. If the flag is not set, dxand dy contain relative data (the
		/// change in position since the last reported position). This flag can be set, or not set, regardless of what kind of mouse or
		/// other pointing device, if any, is connected to the system. For further information about relative mouse motion, see the
		/// following Remarks section.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MOUSEEVENTF_HWHEEL 0x01000</term>
		/// <term>
		/// The wheel was moved horizontally, if the mouse has a wheel. The amount of movement is specified in mouseData. Windows
		/// XP/2000: This value is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MOUSEEVENTF_MOVE 0x0001</term>
		/// <term>Movement occurred.</term>
		/// </item>
		/// <item>
		/// <term>MOUSEEVENTF_MOVE_NOCOALESCE 0x2000</term>
		/// <term>
		/// The WM_MOUSEMOVE messages will not be coalesced. The default behavior is to coalesce WM_MOUSEMOVE messages. Windows XP/2000:
		/// This value is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>MOUSEEVENTF_LEFTDOWN 0x0002</term>
		/// <term>The left button was pressed.</term>
		/// </item>
		/// <item>
		/// <term>MOUSEEVENTF_LEFTUP 0x0004</term>
		/// <term>The left button was released.</term>
		/// </item>
		/// <item>
		/// <term>MOUSEEVENTF_RIGHTDOWN 0x0008</term>
		/// <term>The right button was pressed.</term>
		/// </item>
		/// <item>
		/// <term>MOUSEEVENTF_RIGHTUP 0x0010</term>
		/// <term>The right button was released.</term>
		/// </item>
		/// <item>
		/// <term>MOUSEEVENTF_MIDDLEDOWN 0x0020</term>
		/// <term>The middle button was pressed.</term>
		/// </item>
		/// <item>
		/// <term>MOUSEEVENTF_MIDDLEUP 0x0040</term>
		/// <term>The middle button was released.</term>
		/// </item>
		/// <item>
		/// <term>MOUSEEVENTF_VIRTUALDESK 0x4000</term>
		/// <term>Maps coordinates to the entire desktop. Must be used with MOUSEEVENTF_ABSOLUTE.</term>
		/// </item>
		/// <item>
		/// <term>MOUSEEVENTF_WHEEL 0x0800</term>
		/// <term>The wheel was moved, if the mouse has a wheel. The amount of movement is specified in mouseData.</term>
		/// </item>
		/// <item>
		/// <term>MOUSEEVENTF_XDOWN 0x0080</term>
		/// <term>An X button was pressed.</term>
		/// </item>
		/// <item>
		/// <term>MOUSEEVENTF_XUP 0x0100</term>
		/// <term>An X button was released.</term>
		/// </item>
		/// </list>
		/// </summary>
		public MOUSEEVENTF dwFlags;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The time stamp for the event, in milliseconds. If this parameter is 0, the system will provide its own time stamp.</para>
		/// </summary>
		public uint time;

		/// <summary>
		/// <para>Type: <c>ULONG_PTR</c></para>
		/// <para>
		/// An additional value associated with the mouse event. An application calls GetMessageExtraInfo to obtain this extra information.
		/// </para>
		/// </summary>
		public IntPtr dwExtraInfo;
	}

	/// <summary>Describes the format of the raw input from a Human Interface Device (HID).</summary>
	/// <remarks>
	/// Each WM_INPUT can indicate several inputs, but all of the inputs come from the same HID. The size of the <c>bRawData</c> array
	/// is <c>dwSizeHid</c> * <c>dwCount</c>.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ns-winuser-tagrawhid typedef struct tagRAWHID { DWORD dwSizeHid;
	// DWORD dwCount; BYTE bRawData[1]; } RAWHID, *PRAWHID, *LPRAWHID;
	[PInvokeData("winuser.h")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct RAWHID
	{
		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The size, in bytes, of each HID input in <c>bRawData</c>.</para>
		/// </summary>
		public uint dwSizeHid;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The number of HID inputs in <c>bRawData</c>.</para>
		/// </summary>
		public uint dwCount;

		/// <summary>
		/// <para>Type: <c>BYTE[1]</c></para>
		/// <para>The raw input data, as an array of bytes.</para>
		/// </summary>
		public IntPtr bRawData;
	}

	/// <summary>Contains the raw input from a device.</summary>
	/// <remarks>
	/// <para>The handle to this structure is passed in the lParam parameter of WM_INPUT.</para>
	/// <para>To get detailed information -- such as the header and the content of the raw input -- call GetRawInputData.</para>
	/// <para>To read the <c>RAWINPUT</c> in the message loop as a buffered read, call GetRawInputBuffer.</para>
	/// <para>To get device specific information, call GetRawInputDeviceInfo with the hDevice from RAWINPUTHEADER.</para>
	/// <para>Raw input is available only when the application calls RegisterRawInputDevices with valid device specifications.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ns-winuser-tagrawinput typedef struct tagRAWINPUT { RAWINPUTHEADER
	// header; union { RAWMOUSE mouse; RAWKEYBOARD keyboard; RAWHID hid; } data; } RAWINPUT, *PRAWINPUT, *LPRAWINPUT;
	[PInvokeData("winuser.h")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct RAWINPUT
	{
		/// <summary>
		/// <para>Type: <c>RAWINPUTHEADER</c></para>
		/// <para>The raw input data.</para>
		/// </summary>
		public RAWINPUTHEADER header;

		/// <summary>The data</summary>
		public DATA data;

		/// <summary></summary>
		[StructLayout(LayoutKind.Explicit)]
		public struct DATA
		{
			/// <summary><c>Type: <c>RAWMOUSE</c></c> If the data comes from a mouse, this is the raw input data.</summary>
			[FieldOffset(0)]
			public RAWMOUSE mouse;

			/// <summary><c>Type: <c>RAWKEYBOARD</c></c> If the data comes from a keyboard, this is the raw input data.</summary>
			[FieldOffset(0)]
			public RAWKEYBOARD keyboard;

			/// <summary><c>Type: <c>RAWHID</c></c> If the data comes from an HID, this is the raw input data.</summary>
			[FieldOffset(0)]
			public RAWHID hid;
		}
	}

	/// <summary>Defines information for the raw input devices.</summary>
	/// <remarks>
	/// <para>
	/// If <c>RIDEV_NOLEGACY</c> is set for a mouse or a keyboard, the system does not generate any legacy message for that device for
	/// the application. For example, if the mouse TLC is set with <c>RIDEV_NOLEGACY</c>, WM_LBUTTONDOWN and related legacy mouse
	/// messages are not generated. Likewise, if the keyboard TLC is set with <c>RIDEV_NOLEGACY</c>, WM_KEYDOWN and related legacy
	/// keyboard messages are not generated.
	/// </para>
	/// <para>
	/// If <c>RIDEV_REMOVE</c> is set and the <c>hwndTarget</c> member is not set to <c>NULL</c>, then parameter validation will fail.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ns-winuser-tagrawinputdevice typedef struct tagRAWINPUTDEVICE {
	// USHORT usUsagePage; USHORT usUsage; DWORD dwFlags; HWND hwndTarget; } RAWINPUTDEVICE, *PRAWINPUTDEVICE, *LPRAWINPUTDEVICE;
	[PInvokeData("winuser.h", MSDNShortId = "")]
	[StructLayout(LayoutKind.Sequential)]
	public struct RAWINPUTDEVICE
	{
		/// <summary>
		/// <para>Type: <c>USHORT</c></para>
		/// <para>Top level collection Usage page for the raw input device.</para>
		/// </summary>
		public ushort usUsagePage;

		/// <summary>
		/// <para>Type: <c>USHORT</c></para>
		/// <para>Top level collection Usage for the raw input device.</para>
		/// </summary>
		public ushort usUsage;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// Mode flag that specifies how to interpret the information provided by <c>usUsagePage</c> and <c>usUsage</c>. It can be zero
		/// (the default) or one of the following values. By default, the operating system sends raw input from devices with the
		/// specified top level collection (TLC) to the registered application as long as it has the window focus.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>RIDEV_APPKEYS 0x00000400</term>
		/// <term>
		/// If set, the application command keys are handled. RIDEV_APPKEYS can be specified only if RIDEV_NOLEGACY is specified for a
		/// keyboard device.
		/// </term>
		/// </item>
		/// <item>
		/// <term>RIDEV_CAPTUREMOUSE 0x00000200</term>
		/// <term>If set, the mouse button click does not activate the other window.</term>
		/// </item>
		/// <item>
		/// <term>RIDEV_DEVNOTIFY 0x00002000</term>
		/// <term>
		/// If set, this enables the caller to receive WM_INPUT_DEVICE_CHANGE notifications for device arrival and device removal.
		/// Windows XP: This flag is not supported until Windows Vista
		/// </term>
		/// </item>
		/// <item>
		/// <term>RIDEV_EXCLUDE 0x00000010</term>
		/// <term>
		/// If set, this specifies the top level collections to exclude when reading a complete usage page. This flag only affects a TLC
		/// whose usage page is already specified with RIDEV_PAGEONLY.
		/// </term>
		/// </item>
		/// <item>
		/// <term>RIDEV_EXINPUTSINK 0x00001000</term>
		/// <term>
		/// If set, this enables the caller to receive input in the background only if the foreground application does not process it.
		/// In other words, if the foreground application is not registered for raw input, then the background application that is
		/// registered will receive the input. Windows XP: This flag is not supported until Windows Vista
		/// </term>
		/// </item>
		/// <item>
		/// <term>RIDEV_INPUTSINK 0x00000100</term>
		/// <term>
		/// If set, this enables the caller to receive the input even when the caller is not in the foreground. Note that hwndTarget
		/// must be specified.
		/// </term>
		/// </item>
		/// <item>
		/// <term>RIDEV_NOHOTKEYS 0x00000200</term>
		/// <term>
		/// If set, the application-defined keyboard device hotkeys are not handled. However, the system hotkeys; for example, ALT+TAB
		/// and CTRL+ALT+DEL, are still handled. By default, all keyboard hotkeys are handled. RIDEV_NOHOTKEYS can be specified even if
		/// RIDEV_NOLEGACY is not specified and hwndTarget is NULL.
		/// </term>
		/// </item>
		/// <item>
		/// <term>RIDEV_NOLEGACY 0x00000030</term>
		/// <term>
		/// If set, this prevents any devices specified by usUsagePage or usUsage from generating legacy messages. This is only for the
		/// mouse and keyboard. See Remarks.
		/// </term>
		/// </item>
		/// <item>
		/// <term>RIDEV_PAGEONLY 0x00000020</term>
		/// <term>
		/// If set, this specifies all devices whose top level collection is from the specified usUsagePage. Note that usUsage must be
		/// zero. To exclude a particular top level collection, use RIDEV_EXCLUDE.
		/// </term>
		/// </item>
		/// <item>
		/// <term>RIDEV_REMOVE 0x00000001</term>
		/// <term>
		/// If set, this removes the top level collection from the inclusion list. This tells the operating system to stop reading from
		/// a device which matches the top level collection.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public RIDEV dwFlags;

		/// <summary>
		/// <para>Type: <c>HWND</c></para>
		/// <para>A handle to the target window. If <c>NULL</c> it follows the keyboard focus.</para>
		/// </summary>
		public HWND hwndTarget;
	}

	/// <summary>Contains information about a raw input device.</summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ns-winuser-tagrawinputdevicelist typedef struct
	// tagRAWINPUTDEVICELIST { HANDLE hDevice; DWORD dwType; } RAWINPUTDEVICELIST, *PRAWINPUTDEVICELIST;
	[PInvokeData("winuser.h", MSDNShortId = "")]
	[StructLayout(LayoutKind.Sequential)]
	public struct RAWINPUTDEVICELIST
	{
		/// <summary>
		/// <para>Type: <c>HANDLE</c></para>
		/// <para>A handle to the raw input device.</para>
		/// </summary>
		public HANDLE hDevice;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The type of device. This can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>RIM_TYPEHID 2</term>
		/// <term>The device is an HID that is not a keyboard and not a mouse.</term>
		/// </item>
		/// <item>
		/// <term>RIM_TYPEKEYBOARD 1</term>
		/// <term>The device is a keyboard.</term>
		/// </item>
		/// <item>
		/// <term>RIM_TYPEMOUSE 0</term>
		/// <term>The device is a mouse.</term>
		/// </item>
		/// </list>
		/// </summary>
		public RIM_TYPE dwType;
	}

	/// <summary>
	/// <para>Contains the header information that is part of the raw input data.</para>
	/// </summary>
	/// <remarks>
	/// <para>To get more information on the device, use <c>hDevice</c> in a call to GetRawInputDeviceInfo.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ns-winuser-tagrawinputheader typedef struct tagRAWINPUTHEADER {
	// DWORD dwType; DWORD dwSize; HANDLE hDevice; WPARAM wParam; } RAWINPUTHEADER, *PRAWINPUTHEADER, *LPRAWINPUTHEADER;
	[PInvokeData("winuser.h")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct RAWINPUTHEADER
	{
		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The type of raw input. It can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>RIM_TYPEHID 2</term>
		/// <term>Raw input comes from some device that is not a keyboard or a mouse.</term>
		/// </item>
		/// <item>
		/// <term>RIM_TYPEKEYBOARD 1</term>
		/// <term>Raw input comes from the keyboard.</term>
		/// </item>
		/// <item>
		/// <term>RIM_TYPEMOUSE 0</term>
		/// <term>Raw input comes from the mouse.</term>
		/// </item>
		/// </list>
		/// </summary>
		public RIM_TYPE dwType;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// The size, in bytes, of the entire input packet of data. This includes RAWINPUT plus possible extra input reports in the
		/// RAWHID variable length array.
		/// </para>
		/// </summary>
		public uint dwSize;

		/// <summary>
		/// <para>Type: <c>HANDLE</c></para>
		/// <para>A handle to the device generating the raw input data.</para>
		/// </summary>
		public HANDLE hDevice;

		/// <summary>
		/// <para>Type: <c>WPARAM</c></para>
		/// <para>The value passed in the wParam parameter of the WM_INPUT message.</para>
		/// </summary>
		public IntPtr wParam;
	}

	/// <summary>Contains information about the state of the keyboard.</summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ns-winuser-tagrawkeyboard typedef struct tagRAWKEYBOARD { USHORT
	// MakeCode; USHORT Flags; USHORT Reserved; USHORT VKey; UINT Message; ULONG ExtraInformation; } RAWKEYBOARD, *PRAWKEYBOARD, *LPRAWKEYBOARD;
	[PInvokeData("winuser.h")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct RAWKEYBOARD
	{
		/// <summary>
		/// <para>Type: <c>USHORT</c></para>
		/// <para>The scan code from the key depression. The scan code for keyboard overrun is <c>KEYBOARD_OVERRUN_MAKE_CODE</c>.</para>
		/// </summary>
		public ushort MakeCode;

		/// <summary>
		/// <para>Type: <c>USHORT</c></para>
		/// <para>Flags for scan code information. It can be one or more of the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>RI_KEY_BREAK 1</term>
		/// <term>The key is up.</term>
		/// </item>
		/// <item>
		/// <term>RI_KEY_E0 2</term>
		/// <term>The scan code has the E0 prefix.</term>
		/// </item>
		/// <item>
		/// <term>RI_KEY_E1 4</term>
		/// <term>The scan code has the E1 prefix.</term>
		/// </item>
		/// <item>
		/// <term>RI_KEY_MAKE 0</term>
		/// <term>The key is down.</term>
		/// </item>
		/// </list>
		/// </summary>
		public RI_KEY Flags;

		/// <summary>
		/// <para>Type: <c>USHORT</c></para>
		/// <para>Reserved; must be zero.</para>
		/// </summary>
		public ushort Reserved;

		/// <summary>
		/// <para>Type: <c>USHORT</c></para>
		/// <para>Windows message compatible virtual-key code. For more information, see Virtual Key Codes.</para>
		/// </summary>
		public ushort VKey;

		/// <summary>
		/// <para>Type: <c>UINT</c></para>
		/// <para>The corresponding window message, for example WM_KEYDOWN, WM_SYSKEYDOWN, and so forth.</para>
		/// </summary>
		public uint Message;

		/// <summary>
		/// <para>Type: <c>ULONG</c></para>
		/// <para>The device-specific additional information for the event.</para>
		/// </summary>
		public uint ExtraInformation;
	}

	/// <summary>Contains information about the state of the mouse.</summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ns-winuser-tagrawmouse typedef struct tagRAWMOUSE { USHORT usFlags;
	// union { ULONG ulButtons; struct { USHORT usButtonFlags; USHORT usButtonData; } DUMMYSTRUCTNAME; } DUMMYUNIONNAME; ULONG
	// ulRawButtons; LONG lLastX; LONG lLastY; ULONG ulExtraInformation; } RAWMOUSE, *PRAWMOUSE, *LPRAWMOUSE;
	[PInvokeData("winuser.h")]
	[StructLayout(LayoutKind.Explicit)]
	public struct RAWMOUSE
	{
		/// <summary>
		/// <para>Type: <c>USHORT</c></para>
		/// <para>The mouse state. This member can be any reasonable combination of the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MOUSE_ATTRIBUTES_CHANGED 0x04</term>
		/// <term>Mouse attributes changed; application needs to query the mouse attributes.</term>
		/// </item>
		/// <item>
		/// <term>MOUSE_MOVE_RELATIVE 0</term>
		/// <term>Mouse movement data is relative to the last mouse position.</term>
		/// </item>
		/// <item>
		/// <term>MOUSE_MOVE_ABSOLUTE 1</term>
		/// <term>Mouse movement data is based on absolute position.</term>
		/// </item>
		/// <item>
		/// <term>MOUSE_VIRTUAL_DESKTOP 0x02</term>
		/// <term>Mouse coordinates are mapped to the virtual desktop (for a multiple monitor system).</term>
		/// </item>
		/// </list>
		/// </summary>
		[FieldOffset(0)]
		public MouseState usFlags;

		/// <summary>
		/// <para>Type: <c>ULONG</c></para>
		/// <para>Reserved.</para>
		/// </summary>
		[FieldOffset(2)]
		public uint ulButtons;

		/// <summary>
		/// <para>Type: <c>USHORT</c></para>
		/// <para>The transition state of the mouse buttons. This member can be one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>RI_MOUSE_LEFT_BUTTON_DOWN 0x0001</term>
		/// <term>Left button changed to down.</term>
		/// </item>
		/// <item>
		/// <term>RI_MOUSE_LEFT_BUTTON_UP 0x0002</term>
		/// <term>Left button changed to up.</term>
		/// </item>
		/// <item>
		/// <term>RI_MOUSE_MIDDLE_BUTTON_DOWN 0x0010</term>
		/// <term>Middle button changed to down.</term>
		/// </item>
		/// <item>
		/// <term>RI_MOUSE_MIDDLE_BUTTON_UP 0x0020</term>
		/// <term>Middle button changed to up.</term>
		/// </item>
		/// <item>
		/// <term>RI_MOUSE_RIGHT_BUTTON_DOWN 0x0004</term>
		/// <term>Right button changed to down.</term>
		/// </item>
		/// <item>
		/// <term>RI_MOUSE_RIGHT_BUTTON_UP 0x0008</term>
		/// <term>Right button changed to up.</term>
		/// </item>
		/// <item>
		/// <term>RI_MOUSE_BUTTON_1_DOWN 0x0001</term>
		/// <term>RI_MOUSE_LEFT_BUTTON_DOWN</term>
		/// </item>
		/// <item>
		/// <term>RI_MOUSE_BUTTON_1_UP 0x0002</term>
		/// <term>RI_MOUSE_LEFT_BUTTON_UP</term>
		/// </item>
		/// <item>
		/// <term>RI_MOUSE_BUTTON_2_DOWN 0x0004</term>
		/// <term>RI_MOUSE_RIGHT_BUTTON_DOWN</term>
		/// </item>
		/// <item>
		/// <term>RI_MOUSE_BUTTON_2_UP 0x0008</term>
		/// <term>RI_MOUSE_RIGHT_BUTTON_UP</term>
		/// </item>
		/// <item>
		/// <term>RI_MOUSE_BUTTON_3_DOWN 0x0010</term>
		/// <term>RI_MOUSE_MIDDLE_BUTTON_DOWN</term>
		/// </item>
		/// <item>
		/// <term>RI_MOUSE_BUTTON_3_UP 0x0020</term>
		/// <term>RI_MOUSE_MIDDLE_BUTTON_UP</term>
		/// </item>
		/// <item>
		/// <term>RI_MOUSE_BUTTON_4_DOWN 0x0040</term>
		/// <term>XBUTTON1 changed to down.</term>
		/// </item>
		/// <item>
		/// <term>RI_MOUSE_BUTTON_4_UP 0x0080</term>
		/// <term>XBUTTON1 changed to up.</term>
		/// </item>
		/// <item>
		/// <term>RI_MOUSE_BUTTON_5_DOWN 0x100</term>
		/// <term>XBUTTON2 changed to down.</term>
		/// </item>
		/// <item>
		/// <term>RI_MOUSE_BUTTON_5_UP 0x0200</term>
		/// <term>XBUTTON2 changed to up.</term>
		/// </item>
		/// <item>
		/// <term>RI_MOUSE_WHEEL 0x0400</term>
		/// <term>Raw input comes from a mouse wheel. The wheel delta is stored in usButtonData.</term>
		/// </item>
		/// </list>
		/// </summary>
		[FieldOffset(2)]
		public RI_MOUSE usButtonFlags;

		/// <summary>
		/// <para>Type: <c>USHORT</c></para>
		/// <para>If <c>usButtonFlags</c> is <c>RI_MOUSE_WHEEL</c>, this member is a signed value that specifies the wheel delta.</para>
		/// </summary>
		[FieldOffset(4)]
		public ushort usButtonData;

		/// <summary>
		/// <para>Type: <c>ULONG</c></para>
		/// <para>The raw state of the mouse buttons.</para>
		/// </summary>
		[FieldOffset(6)]
		public uint ulRawButtons;

		/// <summary>
		/// <para>Type: <c>LONG</c></para>
		/// <para>The motion in the X direction. This is signed relative motion or absolute motion, depending on the value of <c>usFlags</c>.</para>
		/// </summary>
		[FieldOffset(10)]
		public int lLastX;

		/// <summary>
		/// <para>Type: <c>LONG</c></para>
		/// <para>The motion in the Y direction. This is signed relative motion or absolute motion, depending on the value of <c>usFlags</c>.</para>
		/// </summary>
		[FieldOffset(14)]
		public int lLastY;

		/// <summary>
		/// <para>Type: <c>ULONG</c></para>
		/// <para>The device-specific additional information for the event.</para>
		/// </summary>
		[FieldOffset(18)]
		public uint ulExtraInformation;
	}

	/// <summary>Defines the raw input data coming from any device.</summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ns-winuser-tagrid_device_info typedef struct tagRID_DEVICE_INFO {
	// DWORD cbSize; DWORD dwType; union { RID_DEVICE_INFO_MOUSE mouse; RID_DEVICE_INFO_KEYBOARD keyboard; RID_DEVICE_INFO_HID hid; }
	// DUMMYUNIONNAME; } RID_DEVICE_INFO, *PRID_DEVICE_INFO, *LPRID_DEVICE_INFO;
	[PInvokeData("winuser.h", MSDNShortId = "")]
	[StructLayout(LayoutKind.Explicit)]
	public struct RID_DEVICE_INFO
	{
		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The size, in bytes, of the <c>RID_DEVICE_INFO</c> structure.</para>
		/// </summary>
		[FieldOffset(0)]
		public uint cbSize;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The type of raw input data. This member can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>RIM_TYPEHID 2</term>
		/// <term>Data comes from an HID that is not a keyboard or a mouse.</term>
		/// </item>
		/// <item>
		/// <term>RIM_TYPEKEYBOARD 1</term>
		/// <term>Data comes from a keyboard.</term>
		/// </item>
		/// <item>
		/// <term>RIM_TYPEMOUSE 0</term>
		/// <term>Data comes from a mouse.</term>
		/// </item>
		/// </list>
		/// </summary>
		[FieldOffset(4)]
		public RIM_TYPE dwType;

		/// <summary>
		/// <para>Type: <c>RID_DEVICE_INFO_MOUSE</c></para>
		/// <para>If <c>dwType</c> is <c>RIM_TYPEMOUSE</c>, this is the RID_DEVICE_INFO_MOUSE structure that defines the mouse.</para>
		/// </summary>
		[FieldOffset(8)]
		public RID_DEVICE_INFO_MOUSE mouse;

		/// <summary>
		/// <para>Type: <c>RID_DEVICE_INFO_KEYBOARD</c></para>
		/// <para>If <c>dwType</c> is <c>RIM_TYPEKEYBOARD</c>, this is the RID_DEVICE_INFO_KEYBOARD structure that defines the keyboard.</para>
		/// </summary>
		[FieldOffset(8)]
		public RID_DEVICE_INFO_KEYBOARD keyboard;

		/// <summary>
		/// <para>Type: <c>RID_DEVICE_INFO_HID</c></para>
		/// <para>If <c>dwType</c> is <c>RIM_TYPEHID</c>, this is the RID_DEVICE_INFO_HID structure that defines the HID device.</para>
		/// </summary>
		[FieldOffset(8)]
		public RID_DEVICE_INFO_HID hid;
	}

	/// <summary>Defines the raw input data coming from the specified Human Interface Device (HID).</summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ns-winuser-tagrid_device_info_hid typedef struct
	// tagRID_DEVICE_INFO_HID { DWORD dwVendorId; DWORD dwProductId; DWORD dwVersionNumber; USHORT usUsagePage; USHORT usUsage; }
	// RID_DEVICE_INFO_HID, *PRID_DEVICE_INFO_HID;
	[PInvokeData("winuser.h", MSDNShortId = "")]
	[StructLayout(LayoutKind.Sequential)]
	public struct RID_DEVICE_INFO_HID
	{
		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The vendor identifier for the HID.</para>
		/// </summary>
		public uint dwVendorId;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The product identifier for the HID.</para>
		/// </summary>
		public uint dwProductId;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The version number for the HID.</para>
		/// </summary>
		public uint dwVersionNumber;

		/// <summary>
		/// <para>Type: <c>USHORT</c></para>
		/// <para>The top-level collection Usage Page for the device.</para>
		/// </summary>
		public ushort usUsagePage;

		/// <summary>
		/// <para>Type: <c>USHORT</c></para>
		/// <para>The top-level collection Usage for the device.</para>
		/// </summary>
		public ushort usUsage;
	}

	/// <summary>Defines the raw input data coming from the specified keyboard.</summary>
	/// <remarks>For the keyboard, the Usage Page is 1 and the Usage is 6.</remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ns-winuser-tagrid_device_info_keyboard typedef struct
	// tagRID_DEVICE_INFO_KEYBOARD { DWORD dwType; DWORD dwSubType; DWORD dwKeyboardMode; DWORD dwNumberOfFunctionKeys; DWORD
	// dwNumberOfIndicators; DWORD dwNumberOfKeysTotal; } RID_DEVICE_INFO_KEYBOARD, *PRID_DEVICE_INFO_KEYBOARD;
	[PInvokeData("winuser.h", MSDNShortId = "")]
	[StructLayout(LayoutKind.Sequential)]
	public struct RID_DEVICE_INFO_KEYBOARD
	{
		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The type of the keyboard.</para>
		/// </summary>
		public uint dwType;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The subtype of the keyboard.</para>
		/// </summary>
		public uint dwSubType;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The scan code mode.</para>
		/// </summary>
		public uint dwKeyboardMode;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The number of function keys on the keyboard.</para>
		/// </summary>
		public uint dwNumberOfFunctionKeys;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The number of LED indicators on the keyboard.</para>
		/// </summary>
		public uint dwNumberOfIndicators;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The total number of keys on the keyboard.</para>
		/// </summary>
		public uint dwNumberOfKeysTotal;
	}

	/// <summary>Defines the raw input data coming from the specified mouse.</summary>
	/// <remarks>For the mouse, the Usage Page is 1 and the Usage is 2.</remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ns-winuser-tagrid_device_info_mouse typedef struct
	// tagRID_DEVICE_INFO_MOUSE { DWORD dwId; DWORD dwNumberOfButtons; DWORD dwSampleRate; BOOL fHasHorizontalWheel; }
	// RID_DEVICE_INFO_MOUSE, *PRID_DEVICE_INFO_MOUSE;
	[PInvokeData("winuser.h", MSDNShortId = "")]
	[StructLayout(LayoutKind.Sequential)]
	public struct RID_DEVICE_INFO_MOUSE
	{
		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The identifier of the mouse device.</para>
		/// </summary>
		public uint dwId;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The number of buttons for the mouse.</para>
		/// </summary>
		public uint dwNumberOfButtons;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The number of data points per second. This information may not be applicable for every mouse device.</para>
		/// </summary>
		public uint dwSampleRate;

		/// <summary>
		/// <para>Type: <c>BOOL</c></para>
		/// <para><c>TRUE</c> if the mouse has a wheel for horizontal scrolling; otherwise, <c>FALSE</c>.</para>
		/// <para><c>Windows XP:</c> This member is only supported starting with Windows Vista.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool fHasHorizontalWheel;
	}
}