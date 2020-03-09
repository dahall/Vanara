using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class User32
	{
		/// <summary>Lists the flags that may appear in the <c>penFlags</c> field of the <c>POINTER_PEN_INFO</c> structure.</summary>
		// https://docs.microsoft.com/en-us/previous-versions/hh454905(v%3dvs.85) typedef enum tagPEN_FLAGS { PEN_FLAGS_NONE = 0x00000000,
		// PEN_FLAGS_BARREL = 0x00000001, PEN_FLAGS_INVERTED = 0x00000002, PEN_FLAGS_ERASER = 0x00000004 } PEN_FLAGS;
		[PInvokeData("Winuser.h", MSDNShortId = "")]
		[Flags]
		public enum PEN_FLAGS
		{
			/// <summary>There is no pen flag. This is the default.</summary>
			PEN_FLAG_NONE = 0x00000000,

			/// <summary>The barrel button is pressed.</summary>
			PEN_FLAG_BARREL = 0x00000001,

			/// <summary>The pen is inverted.</summary>
			PEN_FLAG_INVERTED = 0x00000002,

			/// <summary>The eraser button is pressed.</summary>
			PEN_FLAG_ERASER = 0x00000004,
		}

		/// <summary>Values that can appear in the penMask field of the POINTER_PEN_INFO structure.</summary>
		[PInvokeData("Winuser.h", MSDNShortId = "")]
		[Flags]
		public enum PEN_MASK
		{
			/// <summary>Default. None of the optional fields are valid.</summary>
			PEN_MASK_NONE = 0x00000000,

			/// <summary>pressure of the POINTER_PEN_INFO structure is valid.</summary>
			PEN_MASK_PRESSURE = 0x00000001,

			/// <summary>rotation of the POINTER_PEN_INFO structure is valid.</summary>
			PEN_MASK_ROTATION = 0x00000002,

			/// <summary>tiltX of the POINTER_PEN_INFO structure is valid.</summary>
			PEN_MASK_TILT_X = 0x00000004,

			/// <summary>tiltY of the POINTER_PEN_INFO structure is valid.</summary>
			PEN_MASK_TILT_Y = 0x00000008,
		}

		/// <summary>Identifies a change in the state of a button associated with a pointer.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ne-winuser-tagpointer_button_change_type typedef enum
		// tagPOINTER_BUTTON_CHANGE_TYPE { POINTER_CHANGE_NONE, POINTER_CHANGE_FIRSTBUTTON_DOWN, POINTER_CHANGE_FIRSTBUTTON_UP,
		// POINTER_CHANGE_SECONDBUTTON_DOWN, POINTER_CHANGE_SECONDBUTTON_UP, POINTER_CHANGE_THIRDBUTTON_DOWN, POINTER_CHANGE_THIRDBUTTON_UP,
		// POINTER_CHANGE_FOURTHBUTTON_DOWN, POINTER_CHANGE_FOURTHBUTTON_UP, POINTER_CHANGE_FIFTHBUTTON_DOWN, POINTER_CHANGE_FIFTHBUTTON_UP
		// } POINTER_BUTTON_CHANGE_TYPE;
		[PInvokeData("winuser.h", MSDNShortId = "DF5F60F6-8FD9-41EB-AF2A-09A17513659C")]
		public enum POINTER_BUTTON_CHANGE_TYPE
		{
			/// <summary>No change in button state.</summary>
			POINTER_CHANGE_NONE,

			/// <summary>The first button (see POINTER_FLAG_FIRSTBUTTON) transitioned to a pressed state.</summary>
			POINTER_CHANGE_FIRSTBUTTON_DOWN,

			/// <summary>The first button (see POINTER_FLAG_FIRSTBUTTON) transitioned to a released state.</summary>
			POINTER_CHANGE_FIRSTBUTTON_UP,

			/// <summary>The second button (see POINTER_FLAG_SECONDBUTTON) transitioned to a pressed state.</summary>
			POINTER_CHANGE_SECONDBUTTON_DOWN,

			/// <summary>The second button (see POINTER_FLAG_SECONDBUTTON) transitioned to a released state.</summary>
			POINTER_CHANGE_SECONDBUTTON_UP,

			/// <summary>The third button (see POINTER_FLAG_THIRDBUTTON) transitioned to a pressed state.</summary>
			POINTER_CHANGE_THIRDBUTTON_DOWN,

			/// <summary>The third button (see POINTER_FLAG_THIRDBUTTON) transitioned to a released state.</summary>
			POINTER_CHANGE_THIRDBUTTON_UP,

			/// <summary>The fourth button (see POINTER_FLAG_FOURTHBUTTON) transitioned to a pressed state.</summary>
			POINTER_CHANGE_FOURTHBUTTON_DOWN,

			/// <summary>The fourth button (see POINTER_FLAG_FOURTHBUTTON) transitioned to a released state.</summary>
			POINTER_CHANGE_FOURTHBUTTON_UP,

			/// <summary>The fifth button (see POINTER_FLAG_FIFTHBUTTON) transitioned to a pressed state.</summary>
			POINTER_CHANGE_FIFTHBUTTON_DOWN,

			/// <summary>The fifth button (see POINTER_FLAG_FIFTHBUTTON) transitioned to a released state.</summary>
			POINTER_CHANGE_FIFTHBUTTON_UP,
		}

		/// <summary>Identifies the pointer device cursor types.</summary>
		/// <remarks>
		/// Cursor objects represent pointing and selecting devices used with digitizer devices, most commonly tactile contacts on touch
		/// digitizers and tablet pens on pen digitizers. Physical pens may have multiple tips (such as normal and eraser ends), with each
		/// pen tip representing a different cursor object. Each cursor object has an associated cursor identifier.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ne-winuser-pointer_device_cursor_type typedef enum
		// tagPOINTER_DEVICE_CURSOR_TYPE { POINTER_DEVICE_CURSOR_TYPE_UNKNOWN, POINTER_DEVICE_CURSOR_TYPE_TIP,
		// POINTER_DEVICE_CURSOR_TYPE_ERASER, POINTER_DEVICE_CURSOR_TYPE_MAX } POINTER_DEVICE_CURSOR_TYPE;
		[PInvokeData("winuser.h", MSDNShortId = "ebd5c0c6-a949-42f1-976e-96d143b1a0d7")]
		public enum POINTER_DEVICE_CURSOR_TYPE
		{
			/// <summary>Unidentified cursor.</summary>
			POINTER_DEVICE_CURSOR_TYPE_UNKNOWN,

			/// <summary>Pen tip.</summary>
			POINTER_DEVICE_CURSOR_TYPE_TIP,

			/// <summary>Pen eraser.</summary>
			POINTER_DEVICE_CURSOR_TYPE_ERASER,
		}

		/// <summary>Identifies the pointer device types.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ne-winuser-pointer_device_type typedef enum tagPOINTER_DEVICE_TYPE {
		// POINTER_DEVICE_TYPE_INTEGRATED_PEN, POINTER_DEVICE_TYPE_EXTERNAL_PEN, POINTER_DEVICE_TYPE_TOUCH, POINTER_DEVICE_TYPE_TOUCH_PAD,
		// POINTER_DEVICE_TYPE_MAX } POINTER_DEVICE_TYPE;
		[PInvokeData("winuser.h", MSDNShortId = "7702adec-e24f-4dc8-b5d4-f1f9dbcb5ed0")]
		public enum POINTER_DEVICE_TYPE : uint
		{
			/// <summary>Direct pen digitizer (integrated into display).</summary>
			POINTER_DEVICE_TYPE_INTEGRATED_PEN = 1,

			/// <summary>Indirect pen digitizer (not integrated into display).</summary>
			POINTER_DEVICE_TYPE_EXTERNAL_PEN,

			/// <summary>Touch digitizer.</summary>
			POINTER_DEVICE_TYPE_TOUCH,

			/// <summary>Touchpad digitizer (Windows 8.1 and later).</summary>
			POINTER_DEVICE_TYPE_TOUCH_PAD,
		}

		/// <summary>Identifies the visual feedback behaviors available to CreateSyntheticPointerDevice.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/winuser/ne-winuser-pointer_feedback_mode typedef enum {
		// POINTER_FEEDBACK_DEFAULT, POINTER_FEEDBACK_INDIRECT, POINTER_FEEDBACK_NONE } ;
		[PInvokeData("winuser.h", MSDNShortId = "73D024E9-F83B-408F-BC96-6851AB4603AE")]
		public enum POINTER_FEEDBACK_MODE
		{
			/// <summary>Visual feedback might be suppressed by the user's pen (Settings -> Devices -> Pen &amp; Windows Ink) and touch
			/// (Settings -> Ease of Access -> Cursor &amp; pointer size) settings.</summary>
			POINTER_FEEDBACK_DEFAULT = 1,

			/// <summary>Visual feedback overrides the user's pen and touch settings.</summary>
			POINTER_FEEDBACK_INDIRECT,

			/// <summary>Visual feedback is disabled.</summary>
			POINTER_FEEDBACK_NONE
		}

		/// <summary>Values that can appear in the <c>pointerFlags</c> field of the <c>POINTER_INFO</c> structure.</summary>
		/// <remarks>
		/// XBUTTON1 and XBUTTON2 are additional buttons used on many mouse devices. They return the same data as standard mouse buttons.
		/// </remarks>
		// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/inputmsg/pointer-flags-contants
		[PInvokeData("winuser.h", MSDNShortId = "CC3F8E21-F4FF-495C-922E-A3708D3F2093")]
		public enum POINTER_FLAGS
		{
			/// <summary>Default</summary>
			POINTER_FLAG_NONE = 0x00000000,

			/// <summary>Indicates the arrival of a new pointer.</summary>
			POINTER_FLAG_NEW = 0x00000001,

			/// <summary>
			/// Indicates that this pointer continues to exist. When this flag is not set, it indicates the pointer has left detection range.
			/// <para>
			/// This flag is typically not set only when a hovering pointer leaves detection range (POINTER_FLAG_UPDATE is set) or when a
			/// pointer in contact with a window surface leaves detection range(POINTER_FLAG_UP is set).
			/// </para>
			/// </summary>
			POINTER_FLAG_INRANGE = 0x00000002,

			/// <summary>
			/// Indicates that this pointer is in contact with the digitizer surface. When this flag is not set, it indicates a hovering pointer.
			/// </summary>
			POINTER_FLAG_INCONTACT = 0x00000004,

			/// <summary>
			/// Indicates a primary action, analogous to a left mouse button down.
			/// <para>A touch pointer has this flag set when it is in contact with the digitizer surface.</para>
			/// <para>A pen pointer has this flag set when it is in contact with the digitizer surface with no buttons pressed.</para>
			/// <para>A mouse pointer has this flag set when the left mouse button is down.</para>
			/// </summary>
			POINTER_FLAG_FIRSTBUTTON = 0x00000010,

			/// <summary>
			/// Indicates a secondary action, analogous to a right mouse button down.
			/// <para>A touch pointer does not use this flag.</para>
			/// <para>A pen pointer has this flag set when it is in contact with the digitizer surface with the pen barrel button pressed.</para>
			/// <para>A mouse pointer has this flag set when the right mouse button is down.</para>
			/// </summary>
			POINTER_FLAG_SECONDBUTTON = 0x00000020,

			/// <summary>
			/// Analogous to a mouse wheel button down.
			/// <para>A touch pointer does not use this flag.</para>
			/// <para>A pen pointer does not use this flag.</para>
			/// <para>A mouse pointer has this flag set when the mouse wheel button is down.</para>
			/// </summary>
			POINTER_FLAG_THIRDBUTTON = 0x00000040,

			/// <summary>
			/// Analogous to a first extended mouse (XButton1) button down.
			/// <para>A touch pointer does not use this flag.</para>
			/// <para>A pen pointer does not use this flag.</para>
			/// <para>A mouse pointer has this flag set when the first extended mouse(XBUTTON1) button is down.</para>
			/// </summary>
			POINTER_FLAG_FOURTHBUTTON = 0x00000080,

			/// <summary>
			/// Analogous to a second extended mouse (XButton2) button down.
			/// <para>A touch pointer does not use this flag.</para>
			/// <para>A pen pointer does not use this flag.</para>
			/// <para>A mouse pointer has this flag set when the second extended mouse(XBUTTON2) button is down.</para>
			/// </summary>
			POINTER_FLAG_FIFTHBUTTON = 0x00000100,

			/// <summary>
			/// Indicates that this pointer has been designated as the primary pointer. A primary pointer is a single pointer that can
			/// perform actions beyond those available to non-primary pointers. For example, when a primary pointer makes contact with a
			/// window s surface, it may provide the window an opportunity to activate by sending it a WM_POINTERACTIVATE message.
			/// <para>
			/// The primary pointer is identified from all current user interactions on the system(mouse, touch, pen, and so on). As such,
			/// the primary pointer might not be associated with your app.The first contact in a multi-touch interaction is set as the
			/// primary pointer.Once a primary pointer is identified, all contacts must be lifted before a new contact can be identified as
			/// a primary pointer.For apps that don't process pointer input, only the primary pointer's events are promoted to mouse events.
			/// </para>
			/// </summary>
			POINTER_FLAG_PRIMARY = 0x00002000,

			/// <summary>
			/// Confidence is a suggestion from the source device about whether the pointer represents an intended or accidental
			/// interaction, which is especially relevant for PT_TOUCH pointers where an accidental interaction (such as with the palm of
			/// the hand) can trigger input. The presence of this flag indicates that the source device has high confidence that this input
			/// is part of an intended interaction.
			/// </summary>
			POINTER_FLAG_CONFIDENCE = 0x000004000,

			/// <summary>
			/// Indicates that the pointer is departing in an abnormal manner, such as when the system receives invalid input for the
			/// pointer or when a device with active pointers departs abruptly. If the application receiving the input is in a position to
			/// do so, it should treat the interaction as not completed and reverse any effects of the concerned pointer.
			/// </summary>
			POINTER_FLAG_CANCELED = 0x000008000,

			/// <summary>Indicates that this pointer transitioned to a down state; that is, it made contact with the digitizer surface.</summary>
			POINTER_FLAG_DOWN = 0x00010000,

			/// <summary>Indicates that this is a simple update that does not include pointer state changes.</summary>
			POINTER_FLAG_UPDATE = 0x00020000,

			/// <summary>Indicates that this pointer transitioned to an up state; that is, contact with the digitizer surface ended.</summary>
			POINTER_FLAG_UP = 0x00040000,

			/// <summary>
			/// Indicates input associated with a pointer wheel. For mouse pointers, this is equivalent to the action of the mouse scroll
			/// wheel (WM_MOUSEHWHEEL).
			/// </summary>
			POINTER_FLAG_WHEEL = 0x00080000,

			/// <summary>
			/// Indicates input associated with a pointer h-wheel. For mouse pointers, this is equivalent to the action of the mouse
			/// horizontal scroll wheel (WM_MOUSEHWHEEL).
			/// </summary>
			POINTER_FLAG_HWHEEL = 0x00100000,

			/// <summary>
			/// Indicates that this pointer was captured by (associated with) another element and the original element has lost capture (see WM_POINTERCAPTURECHANGED).
			/// </summary>
			POINTER_FLAG_CAPTURECHANGED = 0x00200000,

			/// <summary>Indicates that this pointer has an associated transform.</summary>
			POINTER_FLAG_HASTRANSFORM = 0x00400000,
		}

		/// <summary>Identifies the pointer input types.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ne-winuser-tagpointer_input_type typedef enum tagPOINTER_INPUT_TYPE
		// { PT_POINTER, PT_TOUCH, PT_PEN, PT_MOUSE, PT_TOUCHPAD } ;
		[PInvokeData("winuser.h", MSDNShortId = "3334DCD0-DAE1-4AC2-AB36-23D114803100")]
		public enum POINTER_INPUT_TYPE
		{
			/// <summary>
			/// Generic pointer type. This type never appears in pointer messages or pointer data. Some data query functions allow the
			/// caller to restrict the query to specific pointer type. The PT_POINTER type can be used in these functions to specify that
			/// the query is to include pointers of all types
			/// </summary>
			PT_POINTER,

			/// <summary>Touch pointer type.</summary>
			PT_TOUCH,

			/// <summary>Pen pointer type.</summary>
			PT_PEN,

			/// <summary>Mouse pointer type.</summary>
			PT_MOUSE,

			/// <summary>Touchpad pointer type (Windows 8.1 and later).</summary>
			PT_TOUCHPAD,
		}

		/// <summary>Values that can appear in the touchFlags field of the POINTER_TOUCH_INFO structure.</summary>
		// https://docs.microsoft.com/en-us/previous-versions/hh454914(v%3dvs.85) typedef enum tagTOUCH_FLAGS { TOUCH_FLAGS_NONE =
		// 0x00000000 } TOUCH_FLAGS;
		[PInvokeData("Winuser.h", MSDNShortId = "")]
		public enum TOUCH_FLAGS
		{
			/// <summary>Indicates that no flags are set.</summary>
			TOUCH_FLAGS_NONE = 0x00000000
		}

		/// <summary>Values that can appear in the touchMask field of the POINTER_TOUCH_INFO structure.</summary>
		[PInvokeData("Winuser.h", MSDNShortId = "")]
		[Flags]
		public enum TOUCH_MASK
		{
			/// <summary>Default. None of the optional fields are valid.</summary>
			TOUCH_MASK_NONE = 0x00000000,

			/// <summary>rcContact of the POINTER_TOUCH_INFO structure is valid.</summary>
			TOUCH_MASK_CONTACTAREA = 0x00000001,

			/// <summary>orientation of the POINTER_TOUCH_INFO structure is valid.</summary>
			TOUCH_MASK_ORIENTATION = 0x00000002,

			/// <summary>pressure of the POINTER_TOUCH_INFO structure is valid.</summary>
			TOUCH_MASK_PRESSURE = 0x00000004,
		}

		/// <summary>
		/// Configures the pointer injection device for the calling application, and initializes the maximum number of simultaneous pointers
		/// that the app can inject.
		/// </summary>
		/// <param name="pointerType">The pointer injection device type. Must be either PT_TOUCH or <c>PT_PEN</c>.</param>
		/// <param name="maxCount">
		/// <para>The maximum number of contacts.</para>
		/// <para>For PT_TOUCH this value must be greater than 0 and less than or equal to MAX_TOUCH_COUNT.</para>
		/// <para>For PT_PEN this value must be 1.</para>
		/// </param>
		/// <param name="mode">The contact visualization mode.</param>
		/// <returns>
		/// If the function succeeds, the return value is a handle to the pointer injection device. Otherwise, it returns null. To retrieve
		/// extended error information, call the GetLastError function.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-createsyntheticpointerdevice HSYNTHETICPOINTERDEVICE
		// CreateSyntheticPointerDevice( POINTER_INPUT_TYPE pointerType, ULONG maxCount, POINTER_FEEDBACK_MODE mode );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "251F837F-DF9A-4A94-B790-73AA7196E4A9")]
		public static extern SafeHSYNTHETICPOINTERDEVICE CreateSyntheticPointerDevice(POINTER_INPUT_TYPE pointerType, uint maxCount, POINTER_FEEDBACK_MODE mode);

		/// <summary>Destroys the specified pointer injection device.</summary>
		/// <param name="device">A handle to the pointer injection device.</param>
		/// <returns>This function does not return a value.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-destroysyntheticpointerdevice void
		// DestroySyntheticPointerDevice( HSYNTHETICPOINTERDEVICE device );
		[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "236484FC-D552-45CE-A968-B928D020A4C8")]
		public static extern void DestroySyntheticPointerDevice(HSYNTHETICPOINTERDEVICE device);

		/// <summary>Enables the mouse to act as a pointer input device and send WM_POINTER messages.</summary>
		/// <param name="fEnable"><c>TRUE</c> to turn on mouse input support in WM_POINTER.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is non-zero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This function can be called only once in the context of a process lifetime. Prior to the first call, Windows Store apps run with
		/// mouse-in-pointer enabled, as do any desktop applications that consume mshtml.dll. All other desktop applications run with
		/// mouse-in-pointer disabled.
		/// </para>
		/// <para>On the first call in the process lifetime, the state is changed as specified and the call succeeds.</para>
		/// <para>On subsequent calls, the state will not change. If the current state is not equal to the specified state, the call fails.</para>
		/// <para>Call IsMouseInPointerEnabled to verify the mouse-in-pointer state.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-enablemouseinpointer BOOL EnableMouseInPointer( BOOL
		// fEnable );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "66D9BF17-164F-455F-803F-36CDF88C34FF")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool EnableMouseInPointer([MarshalAs(UnmanagedType.Bool)] bool fEnable);

		/// <summary>Retrieves the cursor identifier associated with the specified pointer.</summary>
		/// <param name="pointerId">An identifier of the pointer for which to retrieve the cursor identifier.</param>
		/// <param name="cursorId">
		/// An address of a <c>UINT32</c> to receive the tablet cursor identifier, if any, associated with the specified pointer.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is non-zero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Cursor objects represent pointing and selecting devices used with digitizer devices, most commonly tactile contacts on touch
		/// digitizers and tablet pens on pen digitizers. Physical pens may have multiple tips (such as normal and eraser ends), with each
		/// pen tip representing a different cursor object. Each cursor object has an associated cursor identifier.
		/// </para>
		/// <para>
		/// For pointer types that derive from these cursor objects, an application can use the <c>GetPointerCursorId</c> function to
		/// retrieve the cursor identifier associated with a pointer.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getpointercursorid BOOL GetPointerCursorId( UINT32
		// pointerId, UINT32 *cursorId );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "43211600-ee82-416f-860f-423c581eda75")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetPointerCursorId(uint pointerId, out uint cursorId);

		/// <summary>Gets information about the pointer device.</summary>
		/// <param name="device">The handle to the device.</param>
		/// <param name="pointerDevice">A POINTER_DEVICE_INFO structure that contains information about the pointer device.</param>
		/// <returns>
		/// <para>If this function succeeds, it returns TRUE.</para>
		/// <para>Otherwise, it returns FALSE. To retrieve extended error information, call the GetLastError function.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getpointerdevice BOOL GetPointerDevice( HANDLE device,
		// POINTER_DEVICE_INFO *pointerDevice );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("winuser.h", MSDNShortId = "800E0BFE-6E57-4EAA-B47C-FEEC0B5BFA2F")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetPointerDevice(HANDLE device, out POINTER_DEVICE_INFO pointerDevice);

		/// <summary>Gets the cursor IDs that are mapped to the cursors associated with a pointer device.</summary>
		/// <param name="device">The device handle.</param>
		/// <param name="cursorCount">The number of cursors associated with the pointer device.</param>
		/// <param name="deviceCursors">
		/// An array of POINTER_DEVICE_CURSOR_INFO structures that contain info about the cursors. If NULL, cursorCount returns the number
		/// of cursors associated with the pointer device.
		/// </param>
		/// <returns>
		/// TRUE if the function succeeds; otherwise, FALSE. If the function fails, call the GetLastError function for more information.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getpointerdevicecursors BOOL GetPointerDeviceCursors(
		// HANDLE device, UINT32 *cursorCount, POINTER_DEVICE_CURSOR_INFO *deviceCursors );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "4dd25033-e63a-4fa9-89b9-bfcae4061a76")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetPointerDeviceCursors(HANDLE device, ref uint cursorCount, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)]POINTER_DEVICE_CURSOR_INFO[] deviceCursors);

		/// <summary>Gets device properties that aren't included in the POINTER_DEVICE_INFO structure.</summary>
		/// <param name="device">
		/// <para>The pointer device to query properties from.</para>
		/// <para>A call to the GetPointerDevices function returns this handle in the POINTER_DEVICE_INFO structure.</para>
		/// </param>
		/// <param name="propertyCount">
		/// <para>The number of properties.</para>
		/// <para>Returns the count that's written or needed if pointerProperties is NULL.</para>
		/// <para>
		/// If this value is less than the number of properties that the pointer device supports and pointerProperties is not NULL, the
		/// function returns the actual number of properties in this variable and fails.
		/// </para>
		/// </param>
		/// <param name="pointerProperties">The array of properties.</param>
		/// <returns>
		/// TRUE if the function succeeds; otherwise, FALSE. If the function fails, call the GetLastError function for more information.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getpointerdeviceproperties BOOL
		// GetPointerDeviceProperties( HANDLE device, UINT32 *propertyCount, POINTER_DEVICE_PROPERTY *pointerProperties );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "dbb81637-217a-49b1-9e81-2068cf4c0951")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetPointerDeviceProperties(HANDLE device, ref uint propertyCount, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] POINTER_DEVICE_PROPERTY[] pointerProperties);

		/// <summary>
		/// Gets the x and y range for the pointer device (in himetric) and the x and y range (current resolution) for the display that the
		/// pointer device is mapped to.
		/// </summary>
		/// <param name="device">The handle to the pointer device.</param>
		/// <param name="pointerDeviceRect">The structure for retrieving the device's physical range data.</param>
		/// <param name="displayRect">The structure for retrieving the display resolution.</param>
		/// <returns>
		/// TRUE if the function succeeds; otherwise, FALSE. If the function fails, call the GetLastError function for more information.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getpointerdevicerects BOOL GetPointerDeviceRects( HANDLE
		// device, RECT *pointerDeviceRect, RECT *displayRect );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "a6586dec-6d57-4345-be56-89c7308c1097")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetPointerDeviceRects(HANDLE device, out RECT pointerDeviceRect, out RECT displayRect);

		/// <summary>Gets information about the pointer devices attached to the system.</summary>
		/// <param name="deviceCount">
		/// If pointerDevices is NULL, deviceCount returns the total number of attached pointer devices. Otherwise, deviceCount specifies
		/// the number of POINTER_DEVICE_INFO structures pointed to by pointerDevices.
		/// </param>
		/// <param name="pointerDevices">
		/// Array of POINTER_DEVICE_INFO structures for the pointer devices attached to the system. If NULL, the total number of attached
		/// pointer devices is returned in deviceCount.
		/// </param>
		/// <returns>
		/// <para>If this function succeeds, it returns TRUE.</para>
		/// <para>Otherwise, it returns FALSE. To retrieve extended error information, call the GetLastError function.</para>
		/// </returns>
		/// <remarks>
		/// <para>Windows 8 supports the following:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>256 contacts per pointer device.</term>
		/// </item>
		/// <item>
		/// <term>
		/// 2560 total contacts per system session, regardless of the number of attached devices. For example, 10 pointer devices with 256
		/// contacts each, 20 pointer devices with 128 contacts each, and so on.
		/// </term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getpointerdevices BOOL GetPointerDevices( UINT32
		// *deviceCount, POINTER_DEVICE_INFO *pointerDevices );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "91FD5EBA-EDD7-4D7D-ABF3-3CE2461417B0")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetPointerDevices(ref uint deviceCount, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] POINTER_DEVICE_INFO[] pointerDevices);

		/// <summary>Gets the entire frame of information for the specified pointers associated with the current message.</summary>
		/// <param name="pointerId">An identifier of the pointer for which to retrieve frame information.</param>
		/// <param name="pointerCount">
		/// A pointer to a variable that specifies the count of structures in the buffer to which pointerInfo points. If
		/// <c>GetPointerFrameInfo</c> succeeds, pointerCount is updated with the total count of pointers in the frame.
		/// </param>
		/// <param name="pointerInfo">
		/// Address of an array of POINTER_INFO structures to receive the pointer information. This parameter can be <c>NULL</c> if
		/// *pointerCount is zero.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is non-zero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Parallel-mode devices may report pointer input in frames, that is, they may report the state and position of all pointers from
		/// that device in a single input report to the system. Ideally, applications should view the entire frame as a single input unless
		/// the application-specific requirements dictate otherwise.
		/// </para>
		/// <para>
		/// <c>GetPointerFrameInfo</c> retrieves the entire pointer input frame associated with a pointer message. Use GetPointerInfo to
		/// retrieve information for a single pointer associated with a pointer message.
		/// </para>
		/// <para>The frame contains only pointers that are currently owned by the same window as the specified pointer.</para>
		/// <para>
		/// The information returned by <c>GetPointerFrameInfo</c> is associated with the most recent pointer message retrieved by the
		/// calling thread. When the next message is retrieved by the calling thread, the information associated with the previous message
		/// may no longer be available.
		/// </para>
		/// <para>
		/// If the application does not process pointer input messages as fast as they are generated, some messages may be coalesced into a
		/// WM_POINTERUPDATE message. Use GetPointerFrameInfoHistory to retrieve the message history from the most recent
		/// <c>WM_POINTERUPDATE</c> message.
		/// </para>
		/// <para>
		/// Having retrieved the entire frame of information, the application can then call the SkipPointerFrameMessages function to skip
		/// remaining pointer messages associated with this frame that are pending retrieval. This saves the application the overhead of
		/// retrieving and processing the remaining messages one by one. However, the <c>SkipPointerFrameMessages</c> function should be
		/// used with care and only when the caller can be sure that no other entity on the caller’s thread is expecting to see the
		/// remaining pointer messages one by one as they are retrieved.
		/// </para>
		/// <para>
		/// Note that the information retrieved is associated with the pointer frame most recently retrieved by the calling thread. Once the
		/// calling thread retrieves its next message, the information associated with the previous pointer frame may no longer be available.
		/// </para>
		/// <para>
		/// If the pointer frame contains no additional pointers besides the specified pointer, this function succeeds and returns only the
		/// information for the specified pointer.
		/// </para>
		/// <para>
		/// If the information associated with the pointer frame is no longer available, this function fails with the last error set to <c>ERROR_NO_DATA</c>.
		/// </para>
		/// <para>
		/// If the calling thread does not own the window (where the input was originally delivered or where the message was forwarded) to
		/// which the pointer message has been delivered, this function fails with the last error set to <c>ERROR_ACCESS_DENIED</c>.
		/// </para>
		/// <para>
		/// For apps that have both client and non-client areas, the input frame can include both client and non-client data. To
		/// differentiate between client and non-client data, you must perform hit testing on the target window.
		/// </para>
		/// <para>We recommend the following if you want to filter data from the input frame:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// For each update that does not include a pointer contact (a POINTER_FLAG_UPDATE without <c>POINTER_FLAG_INCONTACT</c>), hit test
		/// to determine if the input is client or non-client.
		/// </term>
		/// </item>
		/// <item>
		/// <term>For each new contact (POINTER_FLAG_DOWN), hit test to determine if the input is client or non-client and track this info.</term>
		/// </item>
		/// <item>
		/// <term>
		/// For each update that includes a pointer contact (a POINTER_FLAG_UPDATE with <c>POINTER_FLAG_INCONTACT</c>), use the tracking
		/// info to determine whether the input is client or non-client.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// For each POINTER_FLAG_UP, use the tracking info to determine whether the input is client or non-client and then clear this
		/// pointer from the tracking data.
		/// </term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getpointerframeinfo BOOL GetPointerFrameInfo( UINT32
		// pointerId, UINT32 *pointerCount, POINTER_INFO *pointerInfo );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "6b7f450d-6ab1-4991-b2f9-a1db3f065711")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetPointerFrameInfo(uint pointerId, ref uint pointerCount, [In, Out, MarshalAs(UnmanagedType.LPArray)] POINTER_INFO[] pointerInfo);

		/// <summary>
		/// Gets the entire frame of information (including coalesced input frames) for the specified pointers associated with the current message.
		/// </summary>
		/// <param name="pointerId">An identifier of the pointer for which to retrieve frame information.</param>
		/// <param name="entriesCount">
		/// A pointer to a variable that specifies the count of rows in the two-dimensional array to which pointerInfo points. If
		/// <c>GetPointerFrameInfoHistory</c> succeeds, entriesCount is updated with the total count of frames available in the history.
		/// </param>
		/// <param name="pointerCount">
		/// A pointer to a variable that specifies the count of columns in the two-dimensional array to which pointerInfo points. If
		/// <c>GetPointerFrameInfoHistory</c> succeeds, pointerCount is updated with the total count of pointers in each frame.
		/// </param>
		/// <param name="pointerInfo">
		/// <para>
		/// Address of a two-dimensional array of POINTER_INFO structures to receive the pointer information. This parameter can be NULL if
		/// *entriesCount and *pointerCount are both zero.
		/// </para>
		/// <para>This array is interpreted as .</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is non-zero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Parallel-mode devices may report pointer input in frames, that is, they may report the state and position of all pointers from
		/// that device in a single input report to the system. Ideally, applications should view the entire frame as a single input unless
		/// the application-specific requirements dictate otherwise.
		/// </para>
		/// <para>
		/// The information returned by GetPointerFrameInfo is associated with the most recent pointer message retrieved by the calling
		/// thread. When the next message is retrieved by the calling thread, the information associated with the previous message may no
		/// longer be available.
		/// </para>
		/// <para>
		/// If the application does not process pointer input messages as fast as they are generated, some messages may be coalesced into a
		/// WM_POINTERUPDATE message. Use <c>GetPointerFrameInfoHistory</c> to retrieve the message history (including coalesced input
		/// frames) from the most recent <c>WM_POINTERUPDATE</c> message.
		/// </para>
		/// <para>
		/// Having retrieved the entire frame of information, the application can then call the SkipPointerFrameMessages function to skip
		/// remaining pointer messages associated with this frame that are pending retrieval. This saves the application the overhead of
		/// retrieving and processing the remaining messages one by one. However, the <c>SkipPointerFrameMessages</c> function should be
		/// used with care and only when the caller can be sure that no other entity on the caller’s thread is expecting to see the
		/// remaining pointer messages one by one as they are retrieved.
		/// </para>
		/// <para>The frame contains only pointers that are currently owned by the same window as the specified pointer.</para>
		/// <para>
		/// The information retrieved represents a two-dimensional array with one row for each history entry and one column for each pointer
		/// in the frame.
		/// </para>
		/// <para>
		/// The information retrieved appears in reverse chronological order, with the most recent entry in the first row of the returned
		/// array. The most recent entry is the same as that returned by the GetPointerFrameInfo function.
		/// </para>
		/// <para>
		/// If the count of rows in the buffer provided is insufficient to hold all available history entries, this function succeeds with
		/// the buffer containing the most recent entries and *entriesCount containing the total count of entries available.
		/// </para>
		/// <para>
		/// If the pointer frame contains no additional pointers besides the specified pointer, this function succeeds and returns only the
		/// information for the specified pointer.
		/// </para>
		/// <para>
		/// If the information associated with the pointer frame is no longer available, this function fails with the last error set to <c>ERROR_NO_DATA</c>.
		/// </para>
		/// <para>
		/// If the calling thread does not own the window (where the input was originally delivered or where the message was forwarded) to
		/// which the pointer message has been delivered, this function fails with the last error set to <c>ERROR_ACCESS_DENIED</c>.
		/// </para>
		/// <para>
		/// For apps that have both client and non-client areas, the input frame can include both client and non-client data. To
		/// differentiate between client and non-client data, you must perform hit testing on the target window.
		/// </para>
		/// <para>We recommend the following if you want to filter data from the input frame:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// For each update that does not include a pointer contact (a POINTER_FLAG_UPDATE without <c>POINTER_FLAG_INCONTACT</c>), hit test
		/// to determine if the input is client or non-client.
		/// </term>
		/// </item>
		/// <item>
		/// <term>For each new contact (POINTER_FLAG_DOWN), hit test to determine if the input is client or non-client and track this info.</term>
		/// </item>
		/// <item>
		/// <term>
		/// For each update that includes a pointer contact (a POINTER_FLAG_UPDATE with <c>POINTER_FLAG_INCONTACT</c>), use the tracking
		/// info to determine whether the input is client or non-client.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// For each POINTER_FLAG_UP, use the tracking info to determine whether the input is client or non-client and then clear this
		/// pointer from the tracking data.
		/// </term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getpointerframeinfohistory BOOL
		// GetPointerFrameInfoHistory( UINT32 pointerId, UINT32 *entriesCount, UINT32 *pointerCount, POINTER_INFO *pointerInfo );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "1ae035d6-a375-4421-82a6-50be4a2341f6")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetPointerFrameInfoHistory(uint pointerId, ref uint entriesCount, ref uint pointerCount, [In, Out] POINTER_INFO[,] pointerInfo);

		/// <summary>
		/// Gets the entire frame of pen-based information for the specified pointers (of type PT_PEN) associated with the current message.
		/// </summary>
		/// <param name="pointerId">An identifier of the pointer for which to retrieve frame information.</param>
		/// <param name="pointerCount">
		/// A pointer to a variable that specifies the count of structures in the buffer to which penInfo points. If
		/// <c>GetPointerFramePenInfo</c> succeeds, pointerCount is updated with the total count of pointers in the frame.
		/// </param>
		/// <param name="penInfo">
		/// Address of an array of POINTER_PEN_INFO structures to receive the pointer information. This parameter can be NULL if
		/// *pointerCount is zero.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is non-zero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Parallel-mode devices may report pointer input in frames, that is, they may report the state and position of all pointers from
		/// that device in a single input report to the system. Ideally, applications should view the entire frame as a single input unless
		/// the application-specific requirements dictate otherwise.
		/// </para>
		/// <para>
		/// <c>GetPointerFramePenInfo</c> retrieves the entire pointer input frame associated with a pointer (of type PT_PEN) message. Use
		/// GetPointerPenInfo to retrieve information for a single pointer associated with a pointer message.
		/// </para>
		/// <para>The frame contains only pointers that are currently owned by the same window as the specified pointer.</para>
		/// <para>
		/// The information returned by GetPointerFrameInfo is associated with the most recent pointer message retrieved by the calling
		/// thread. When the next message is retrieved by the calling thread, the information associated with the previous message may no
		/// longer be available.
		/// </para>
		/// <para>
		/// If the application does not process pointer input messages as fast as they are generated, some messages may be coalesced into a
		/// WM_POINTERUPDATE message. Use GetPointerFramePenInfoHistory to retrieve the message history from the most recent
		/// <c>WM_POINTERUPDATE</c> message.
		/// </para>
		/// <para>
		/// Having retrieved the entire frame of information, the application can then call the SkipPointerFrameMessages function to skip
		/// remaining pointer messages associated with this frame that are pending retrieval. This saves the application the overhead of
		/// retrieving and processing the remaining messages one by one. However, the <c>SkipPointerFrameMessages</c> function should be
		/// used with care and only when the caller can be sure that no other entity on the caller’s thread is expecting to see the
		/// remaining pointer messages one by one as they are retrieved.
		/// </para>
		/// <para>
		/// Note that the information retrieved is associated with the pointer frame most recently retrieved by the calling thread. Once the
		/// calling thread retrieves its next message, the information associated with the previous pointer frame may no longer be available.
		/// </para>
		/// <para>
		/// If the pointer frame contains no additional pointers besides the specified pointer, this function succeeds and returns only the
		/// information for the specified pointer.
		/// </para>
		/// <para>
		/// If the information associated with the pointer frame is no longer available, this function fails with the last error set to <c>ERROR_NO_DATA</c>.
		/// </para>
		/// <para>
		/// If the calling thread does not own the window to which the pointer message has been delivered, this function fails with the last
		/// error set to <c>ERROR_ACCESS_DENIED</c>.
		/// </para>
		/// <para>If the specified pointer is not of type PT_PEN, this function fails with the last error set to <c>ERROR_DATATYPE_MISMATCH</c>.</para>
		/// <para>
		/// For apps that have both client and non-client areas, the input frame can include both client and non-client data. To
		/// differentiate between client and non-client data, you must perform hit testing on the target window.
		/// </para>
		/// <para>We recommend the following if you want to filter data from the input frame:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// For each update that does not include a pointer contact (a POINTER_FLAG_UPDATE without <c>POINTER_FLAG_INCONTACT</c>), hit test
		/// to determine if the input is client or non-client.
		/// </term>
		/// </item>
		/// <item>
		/// <term>For each new contact (POINTER_FLAG_DOWN), hit test to determine if the input is client or non-client and track this info.</term>
		/// </item>
		/// <item>
		/// <term>
		/// For each update that includes a pointer contact (a POINTER_FLAG_UPDATE with <c>POINTER_FLAG_INCONTACT</c>), use the tracking
		/// info to determine whether the input is client or non-client.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// For each POINTER_FLAG_UP, use the tracking info to determine whether the input is client or non-client and then clear this
		/// pointer from the tracking data.
		/// </term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getpointerframepeninfo BOOL GetPointerFramePenInfo(
		// UINT32 pointerId, UINT32 *pointerCount, POINTER_PEN_INFO *penInfo );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "52db9b96-7f9e-41d7-88f7-b9c7691a6511")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetPointerFramePenInfo(uint pointerId, ref uint pointerCount, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] POINTER_PEN_INFO[] penInfo);

		/// <summary>
		/// Gets the entire frame of pen-based information (including coalesced input frames) for the specified pointers (of type PT_PEN)
		/// associated with the current message.
		/// </summary>
		/// <param name="pointerId">The identifier of the pointer for which to retrieve frame information.</param>
		/// <param name="entriesCount">
		/// A pointer to a variable that specifies the count of rows in the two-dimensional array to which penInfo points. If
		/// <c>GetPointerFramePenInfoHistory</c> succeeds, entriesCount is updated with the total count of frames available in the history.
		/// </param>
		/// <param name="pointerCount">
		/// A pointer to a variaable that specifies the count of columns in the two-dimensional array to which penInfo points. If
		/// <c>GetPointerFramePenInfoHistory</c> succeeds, pointerCount is updated with the total count of pointers in each frame.
		/// </param>
		/// <param name="penInfo">
		/// <para>
		/// Address of a two-dimensional array of POINTER_PEN_INFO structures to receive the pointer information. This parameter can be NULL
		/// if *entriesCount and *pointerCount are both zero.
		/// </para>
		/// <para>This array is interpreted as POINTER_PEN_INFO[*entriesCount][*pointerCount].</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is non-zero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Parallel-mode devices may report pointer input in frames, that is, they may report the state and position of all pointers from
		/// that device in a single input report to the system. Ideally, applications should view the entire frame as a single input unless
		/// the application-specific requirements dictate otherwise.
		/// </para>
		/// <para>
		/// The information returned by GetPointerFramePenInfo is associated with the most recent pointer (PT_PEN) message retrieved by the
		/// calling thread. When the next message is retrieved by the calling thread, the information associated with the previous message
		/// may no longer be available.
		/// </para>
		/// <para>
		/// If the application does not process pointer input messages as fast as they are generated, some messages may be coalesced into a
		/// WM_POINTERUPDATE message. Use <c>GetPointerFramePenInfoHistory</c> to retrieve the message history (including coalesced input
		/// frames) from the most recent <c>WM_POINTERUPDATE</c> message.
		/// </para>
		/// <para>
		/// Having retrieved the entire frame of information, the application can then call the SkipPointerFrameMessages function to skip
		/// remaining pointer messages associated with this frame that are pending retrieval. This saves the application the overhead of
		/// retrieving and processing the remaining messages one by one. However, the <c>SkipPointerFrameMessages</c> function should be
		/// used with care and only when the caller can be sure that no other entity on the caller’s thread is expecting to see the
		/// remaining pointer messages one by one as they are retrieved.
		/// </para>
		/// <para>The frame contains only pointers that are currently owned by the same window as the specified pointer.</para>
		/// <para>
		/// The information retrieved represents a two-dimensional array with one row for each history entry and one column for each pointer
		/// in the frame.
		/// </para>
		/// <para>
		/// The information retrieved appears in reverse chronological order, with the most recent entry in the first row of the returned
		/// array. The most recent entry is the same as that returned by the GetPointerFramePenInfo function.
		/// </para>
		/// <para>
		/// If the count of rows in the buffer provided is insufficient to hold all available history entries, this function succeeds with
		/// the buffer containing the most recent entries and *entriesCount containing the total count of entries available.
		/// </para>
		/// <para>
		/// If the pointer frame contains no additional pointers besides the specified pointer, this function succeeds and returns only the
		/// information for the specified pointer.
		/// </para>
		/// <para>
		/// If the information associated with the pointer frame is no longer available, this function fails with the last error set to <c>ERROR_NO_DATA</c>.
		/// </para>
		/// <para>
		/// If the calling thread does not own the window (where the input was originally delivered or where the message was forwarded) to
		/// which the pointer message has been delivered, this function fails with the last error set to <c>ERROR_ACCESS_DENIED</c>.
		/// </para>
		/// <para>If the specified pointer is not of type PT_PEN, this function fails with the last error set to <c>ERROR_DATATYPE_MISMATCH</c>.</para>
		/// <para>
		/// For apps that have both client and non-client areas, the input frame can include both client and non-client data. To
		/// differentiate between client and non-client data, you must perform hit testing on the target window.
		/// </para>
		/// <para>We recommend the following if you want to filter data from the input frame:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// For each update that does not include a pointer contact (a POINTER_FLAG_UPDATE without <c>POINTER_FLAG_INCONTACT</c>), hit test
		/// to determine if the input is client or non-client.
		/// </term>
		/// </item>
		/// <item>
		/// <term>For each new contact (POINTER_FLAG_DOWN), hit test to determine if the input is client or non-client and track this info.</term>
		/// </item>
		/// <item>
		/// <term>
		/// For each update that includes a pointer contact (a POINTER_FLAG_UPDATE with <c>POINTER_FLAG_INCONTACT</c>), use the tracking
		/// info to determine whether the input is client or non-client.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// For each POINTER_FLAG_UP, use the tracking info to determine whether the input is client or non-client and then clear this
		/// pointer from the tracking data.
		/// </term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getpointerframepeninfohistory BOOL
		// GetPointerFramePenInfoHistory( UINT32 pointerId, UINT32 *entriesCount, UINT32 *pointerCount, POINTER_PEN_INFO *penInfo );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "a4f6a9f3-dfbd-4413-aae7-f58e1521ef1d")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetPointerFramePenInfoHistory(uint pointerId, ref uint entriesCount, ref uint pointerCount, [In, Out] POINTER_PEN_INFO[,] penInfo);

		/// <summary>
		/// Gets the entire frame of touch-based information for the specified pointers (of type PT_TOUCH) associated with the current message.
		/// </summary>
		/// <param name="pointerId">An identifier of the pointer for which to retrieve frame information.</param>
		/// <param name="pointerCount">
		/// A pointer to a variable that specifies the count of structures in the buffer to which touchInfo points. If
		/// <c>GetPointerFrameTouchInfo</c> succeeds, pointerCount is updated with the total count of pointers in the frame.
		/// </param>
		/// <param name="touchInfo">
		/// Address of an array of POINTER_TOUCH_INFO structures to receive the pointer information. This parameter can be NULL if
		/// *pointerCount is zero.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is non-zero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Parallel-mode devices may report pointer input in frames, that is, they may report the state and position of all pointers from
		/// that device in a single input report to the system. Ideally, applications should view the entire frame as a single input unless
		/// the application-specific requirements dictate otherwise.
		/// </para>
		/// <para>
		/// <c>GetPointerFrameTouchInfo</c> retrieves the entire pointer input frame associated with a pointer (of type PT_TOUCH) message.
		/// Use GetPointerTouchInfo to retrieve information for a single pointer associated with a pointer message.
		/// </para>
		/// <para>The frame contains only pointers that are currently owned by the same window as the specified pointer.</para>
		/// <para>
		/// The information returned by <c>GetPointerFrameTouchInfo</c> is associated with the most recent pointer message retrieved by the
		/// calling thread. When the next message is retrieved by the calling thread, the information associated with the previous message
		/// may no longer be available.
		/// </para>
		/// <para>
		/// If the application does not process pointer input messages as fast as they are generated, some messages may be coalesced into a
		/// WM_POINTERUPDATE message. Use GetPointerFrameTouchInfoHistory to retrieve the message history from the most recent
		/// <c>WM_POINTERUPDATE</c> message.
		/// </para>
		/// <para>
		/// Having retrieved the entire frame of information, the application can then call the SkipPointerFrameMessages function to skip
		/// remaining pointer messages associated with this frame that are pending retrieval. This saves the application the overhead of
		/// retrieving and processing the remaining messages one by one. However, the <c>SkipPointerFrameMessages</c> function should be
		/// used with care and only when the caller can be sure that no other entity on the caller’s thread is expecting to see the
		/// remaining pointer messages one by one as they are retrieved.
		/// </para>
		/// <para>
		/// Note that the information retrieved is associated with the pointer frame most recently retrieved by the calling thread. Once the
		/// calling thread retrieves its next message, the information associated with the previous pointer frame may no longer be available.
		/// </para>
		/// <para>
		/// If the pointer frame contains no additional pointers besides the specified pointer, this function succeeds and returns only the
		/// information for the specified pointer.
		/// </para>
		/// <para>
		/// If the information associated with the pointer frame is no longer available, this function fails with the last error set to <c>ERROR_NO_DATA</c>.
		/// </para>
		/// <para>
		/// If the calling thread does not own the window to which the pointer message has been delivered, this function fails with the last
		/// error set to <c>ERROR_ACCESS_DENIED</c>.
		/// </para>
		/// <para>If the specified pointer is not of type PT_TOUCH, this function fails with the last error set to <c>ERROR_DATATYPE_MISMATCH</c>.</para>
		/// <para>
		/// For apps that have both client and non-client areas, the input frame can include both client and non-client data. To
		/// differentiate between client and non-client data, you must perform hit testing on the target window.
		/// </para>
		/// <para>We recommend the following if you want to filter data from the input frame:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// For each update that does not include a pointer contact (a POINTER_FLAG_UPDATE without <c>POINTER_FLAG_INCONTACT</c>), hit test
		/// to determine if the input is client or non-client.
		/// </term>
		/// </item>
		/// <item>
		/// <term>For each new contact (POINTER_FLAG_DOWN), hit test to determine if the input is client or non-client and track this info.</term>
		/// </item>
		/// <item>
		/// <term>
		/// For each update that includes a pointer contact (a POINTER_FLAG_UPDATE with <c>POINTER_FLAG_INCONTACT</c>), use the tracking
		/// info to determine whether the input is client or non-client.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// For each POINTER_FLAG_UP, use the tracking info to determine whether the input is client or non-client and then clear this
		/// pointer from the tracking data.
		/// </term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getpointerframetouchinfo BOOL GetPointerFrameTouchInfo(
		// UINT32 pointerId, UINT32 *pointerCount, POINTER_TOUCH_INFO *touchInfo );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "a100cc7a-62fc-4ace-8d35-e77aff98d944")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetPointerFrameTouchInfo(uint pointerId, ref uint pointerCount, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] POINTER_TOUCH_INFO[] touchInfo);

		/// <summary>
		/// Gets the entire frame of touch-based information (including coalesced input frames) for the specified pointers (of type
		/// PT_TOUCH) associated with the current message.
		/// </summary>
		/// <param name="pointerId">An identifier of the pointer for which to retrieve frame information.</param>
		/// <param name="entriesCount">
		/// A pointer to variable that specifies the count of rows in the two-dimensional array to which touchInfo points. If
		/// <c>GetPointerFrameTouchInfoHistory</c> succeeds, entriesCount is updated with the total count of frames available in the history.
		/// </param>
		/// <param name="pointerCount">
		/// A pointer to a variable that specifies the count of columns in the two-dimensional array to which touchInfo points. If
		/// <c>GetPointerFrameTouchInfoHistory</c> succeeds, pointerCount is updated with the total count of pointers in each frame.
		/// </param>
		/// <param name="touchInfo">
		/// <para>
		/// Address of a two-dimensional array of POINTER_TOUCH_INFO structures to receive the pointer information. This parameter can be
		/// NULL if *entriesCount and *pointerCount are both zero.
		/// </para>
		/// <para>This array is interpreted as .</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is non-zero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Parallel-mode devices may report pointer input in frames, that is, they may report the state and position of all pointers from
		/// that device in a single input report to the system. Ideally, applications should view the entire frame as a single input unless
		/// the application-specific requirements dictate otherwise.
		/// </para>
		/// <para>
		/// The information returned by GetPointerFrameTouchInfo is associated with the most recent pointer (PT_TOUCH) message retrieved by
		/// the calling thread. When the next message is retrieved by the calling thread, the information associated with the previous
		/// message may no longer be available.
		/// </para>
		/// <para>
		/// If the application does not process pointer input messages as fast as they are generated, some messages may be coalesced into a
		/// WM_POINTERUPDATE message. Use <c>GetPointerFrameTouchInfoHistory</c> to retrieve the message history (including coalesced input
		/// frames) from the most recent <c>WM_POINTERUPDATE</c> message.
		/// </para>
		/// <para>
		/// Having retrieved the entire frame of information, the application can then call the SkipPointerFrameMessages function to skip
		/// remaining pointer messages associated with this frame that are pending retrieval. This saves the application the overhead of
		/// retrieving and processing the remaining messages one by one. However, the <c>SkipPointerFrameMessages</c> function should be
		/// used with care and only when the caller can be sure that no other entity on the caller’s thread is expecting to see the
		/// remaining pointer messages one by one as they are retrieved.
		/// </para>
		/// <para>The frame contains only pointers that are currently owned by the same window as the specified pointer.</para>
		/// <para>
		/// The information retrieved represents a two-dimensional array with one row for each history entry and one column for each pointer
		/// in the frame.
		/// </para>
		/// <para>
		/// The information retrieved appears in reverse chronological order, with the most recent entry in the first row of the returned
		/// array. The most recent entry is the same as that returned by the GetPointerFrameTouchInfo function.
		/// </para>
		/// <para>
		/// If the count of rows in the buffer provided is insufficient to hold all available history entries, this function succeeds with
		/// the buffer containing the most recent entries and *entriesCount containing the total count of entries available.
		/// </para>
		/// <para>
		/// If the pointer frame contains no additional pointers besides the specified pointer, this function succeeds and returns only the
		/// information for the specified pointer.
		/// </para>
		/// <para>
		/// If the information associated with the pointer frame is no longer available, this function fails with the last error set to <c>ERROR_NO_DATA</c>.
		/// </para>
		/// <para>
		/// If the calling thread does not own the window (where the input was originally delivered or where the message was forwarded) to
		/// which the pointer message has been delivered, this function fails with the last error set to <c>ERROR_ACCESS_DENIED</c>.
		/// </para>
		/// <para>If the specified pointer is not of type PT_TOUCH, this function fails with the last error set to <c>ERROR_DATATYPE_MISMATCH</c>.</para>
		/// <para>
		/// For apps that have both client and non-client areas, the input frame can include both client and non-client data. To
		/// differentiate between client and non-client data, you must perform hit testing on the target window.
		/// </para>
		/// <para>We recommend the following if you want to filter data from the input frame:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// For each update that does not include a pointer contact (a POINTER_FLAG_UPDATE without <c>POINTER_FLAG_INCONTACT</c>), hit test
		/// to determine if the input is client or non-client.
		/// </term>
		/// </item>
		/// <item>
		/// <term>For each new contact (POINTER_FLAG_DOWN), hit test to determine if the input is client or non-client and track this info.</term>
		/// </item>
		/// <item>
		/// <term>
		/// For each update that includes a pointer contact (a POINTER_FLAG_UPDATE with <c>POINTER_FLAG_INCONTACT</c>), use the tracking
		/// info to determine whether the input is client or non-client.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// For each POINTER_FLAG_UP, use the tracking info to determine whether the input is client or non-client and then clear this
		/// pointer from the tracking data.
		/// </term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getpointerframetouchinfohistory BOOL
		// GetPointerFrameTouchInfoHistory( UINT32 pointerId, UINT32 *entriesCount, UINT32 *pointerCount, POINTER_TOUCH_INFO *touchInfo );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "f2521a67-9850-46e9-bc8b-75bf5b6cc263")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetPointerFrameTouchInfoHistory(uint pointerId, ref uint entriesCount, ref uint pointerCount, [In, Out] POINTER_TOUCH_INFO[,] touchInfo);

		/// <summary>
		/// <para>Gets the information for the specified pointer associated with the current message.</para>
		/// <para><c>Note</c> Use GetPointerType if you don't need the additional information exposed by <c>GetPointerInfo</c>.</para>
		/// </summary>
		/// <param name="pointerId">The pointer identifier.</param>
		/// <param name="pointerInfo">Address of a POINTER_INFO structure that receives the pointer information.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is non-zero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para><c>GetPointerInfo</c> retrieves information for a single pointer associated with a pointer message.</para>
		/// <para>Use GetPointerFrameInfo to retrieve frame information associated with a message for a set of pointers.</para>
		/// <para>
		/// The information returned by <c>GetPointerInfo</c> is associated with the most recent pointer message retrieved by the calling
		/// thread. When the next message is retrieved by the calling thread, the information associated with the previous message may no
		/// longer be available.
		/// </para>
		/// <para>
		/// If the application does not process pointer input messages as fast as they are generated, some messages may be coalesced into a
		/// WM_POINTERUPDATE message. Use GetPointerInfoHistory to retrieve the message history from the most recent <c>WM_POINTERUPDATE</c> message.
		/// </para>
		/// <para>
		/// If the information associated with the message is no longer available, this function fails with the last error set to <c>ERROR_NO_DATA</c>.
		/// </para>
		/// <para>
		/// If the calling thread does not own the window to which the pointer message has been delivered, this function fails with the last
		/// error set to <c>ERROR_ACCESS_DENIED</c>. Note that this may be the window to which the input was originally delivered or it may
		/// be a window to which the message was forwarded.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getpointerinfo BOOL GetPointerInfo( UINT32 pointerId,
		// POINTER_INFO *pointerInfo );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "75faea24-91cd-448b-b67a-19fe530f1800")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetPointerInfo(uint pointerId, ref POINTER_INFO pointerInfo);

		/// <summary>
		/// Gets the information associated with the individual inputs, if any, that were coalesced into the current message for the
		/// specified pointer. The most recent input is included in the returned history and is the same as the most recent input returned
		/// by the GetPointerInfo function.
		/// </summary>
		/// <param name="pointerId">An identifier of the pointer for which to retrieve information.</param>
		/// <param name="entriesCount">
		/// A pointer to a variable that specifies the count of structures in the buffer to which pointerInfo points. If
		/// <c>GetPointerInfoHistory</c> succceeds, entriesCount is updated with the total count of structures available. The total count of
		/// structures available is the same as the <c>historyCount</c> field of the POINTER_INFO structure returned by a call to GetPointerInfo.
		/// </param>
		/// <param name="pointerInfo">
		/// Address of an array of POINTER_INFO structures to receive the pointer information. This parameter can be NULL if *entriesCount
		/// is zero.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is non-zero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If the application does not process pointer input messages as fast as they are generated, some moves may be coalesced. When an
		/// application receives a coalescable pointer message, it can use the <c>GetPointerInfoHistory</c> function to retrieve information
		/// for all the individual inputs, if any, that were coalesced into the message. Note that the information retrieved is associated
		/// with the pointer message most recently retrieved by the calling thread. Once the calling thread retrieves its next message, the
		/// information associated with the previous message may no longer be available.
		/// </para>
		/// <para>
		/// The information retrieved appears in reverse chronological order, with the most recent entry in the first row of the returned
		/// array. The most recent entry is the same as that returned by the GetPointerInfo function.
		/// </para>
		/// <para>
		/// If the count of rows in the buffer provided is insufficient to hold all available history entries, this function succeeds with
		/// the buffer containing the most recent entries and *entriesCount containing the total count of entries available.
		/// </para>
		/// <para>
		/// If the pointer frame contains no additional pointers besides the specified pointer, this function succeeds and returns only the
		/// information for the specified pointer.
		/// </para>
		/// <para>
		/// If the information associated with the pointer frame is no longer available, this function fails with the last error set to <c>ERROR_NO_DATA</c>.
		/// </para>
		/// <para>
		/// If the calling thread does not own the window (where the input was originally delivered or where the message was forwarded) to
		/// which the pointer message has been delivered, this function fails with the last error set to <c>ERROR_ACCESS_DENIED</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getpointerinfohistory BOOL GetPointerInfoHistory( UINT32
		// pointerId, UINT32 *entriesCount, POINTER_INFO *pointerInfo );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "92173197-45e8-4ee7-8959-2f14f90c2d21")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetPointerInfoHistory(uint pointerId, ref uint entriesCount, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] POINTER_INFO[] pointerInfo);

		/// <summary>Gets one or more transforms for the pointer information coordinates associated with the current message.</summary>
		/// <param name="pointerId">An identifier of the pointer for which to retrieve information.</param>
		/// <param name="historyCount">
		/// <para>The number of INPUT_TRANSFORM structures that inputTransform can point to.</para>
		/// <para>
		/// This value must be no less than 1 and no greater than the value specified in <c>historyCount</c> of the POINTER_INFO structure
		/// returned by GetPointerInfo, GetPointerTouchInfo, or GetPointerPenInfo (for a single input transform) or GetPointerInfoHistory,
		/// GetPointerTouchInfoHistory, or GetPointerPenInfoHistory (for an array of input transforms).
		/// </para>
		/// <para>
		/// If <c>GetPointerInputTransform</c> succeeds, inputTransform is updated with the total count of structures available. The total
		/// count of structures available is the same as the <c>historyCount</c> field of the POINTER_INFO structure.
		/// </para>
		/// </param>
		/// <param name="inputTransform">
		/// Address of an array of INPUT_TRANSFORM structures to receive the transform information. This parameter cannot be NULL.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is non-zero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A consumer of pointer input messages typically uses ScreenToClient or MapWindowPoints to convert screen coordinates to client coordinates.
		/// </para>
		/// <para>
		/// If a transform is applied on the message consumer, use <c>GetPointerInputTransform</c> to retrieve the transform on the message
		/// consumer at the time the input occurred. The inverse of this transform can then be used to convert pointer input coordinates
		/// from screen coordinates to the client coordinates of the message consumer.
		/// </para>
		/// <para>
		/// If an input transform is not associated with the input, the <c>GetPointerInputTransform</c> function fails with the last error
		/// set to <c>ERROR_NO_DATA</c>. Use ScreenToClient or MapWindowPoints instead.
		/// </para>
		/// <para>
		/// The input transform does not respect any right-to-left layout setting on the input target. An application that requires adjusted
		/// coordinates for right-to-left layout must perform the right-to-left mirroring or combine an appropriate mirroring transform with
		/// the input transform.
		/// </para>
		/// <para>
		/// The information returned by <c>GetPointerInputTransform</c> is associated with the most recent pointer message retrieved by the
		/// calling thread. When the next message is retrieved by the calling thread, the information associated with the previous message
		/// might no longer be available.
		/// </para>
		/// <para>
		/// If an application calls GetPointerInfo, it can call <c>GetPointerInputTransform</c> with the same pointer Id and a single
		/// INPUT_TRANSFORM output buffer to get the input transform associated with the data.
		/// </para>
		/// <para>
		/// If an application calls GetPointerFrameInfo, it can call <c>GetPointerInputTransform</c> with the same pointer Id and a single
		/// INPUT_TRANSFORM output buffer to get the input transform associated with the data. The same input transform applies to the
		/// entire frame.
		/// </para>
		/// <para>
		/// If an application calls GetPointerInfoHistory, it can call <c>GetPointerInputTransform</c> with the same pointer Id and an
		/// output buffer to hold the entries retrieved using <c>GetPointerInfoHistory</c>. Each input transform in the returned array can
		/// be used with the corresponding entry in the array returned by <c>GetPointerInfoHistory</c>.
		/// </para>
		/// <para>
		/// If an application calls GetPointerFrameInfoHistory, it can call <c>GetPointerInputTransform</c> with the same pointer Id and an
		/// output buffer to hold the entries retrieved using GetPointerInfoHistory. Each input transform in the returned array can be used
		/// with the corresponding frame in the array returned by <c>GetPointerFrameInfoHistory</c>, with the same input transform being
		/// applied to the entire frame.
		/// </para>
		/// <para>
		/// If the information associated with the message is no longer available, this function fails with the last error set to <c>ERROR_INVALID_PARAMETER</c>.
		/// </para>
		/// <para>
		/// If historyCount contains a value larger than the <c>historyCount</c> field of the POINTER_INFO structure returned by
		/// GetPointerInfo (or the first <c>POINTER_INFO</c> structure in the array returned by GetPointerInfoHistory), the function fails
		/// with the last error set to <c>ERROR_INVALID_PARAMETER</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getpointerinputtransform BOOL GetPointerInputTransform(
		// UINT32 pointerId, UINT32 historyCount, INPUT_TRANSFORM *inputTransform );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "9F10ED61-90E3-441B-8F4D-E33DA54D473C")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetPointerInputTransform(uint pointerId, uint historyCount, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] INPUT_TRANSFORM[] inputTransform);

		/// <summary>Gets the pen-based information for the specified pointer (of type PT_PEN) associated with the current message.</summary>
		/// <param name="pointerId">An identifier of the pointer for which to retrieve information.</param>
		/// <param name="penInfo">Address of a POINTER_PEN_INFO structure to receive the pen-specific pointer information.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is non-zero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para><c>GetPointerPenInfo</c> retrieves information for a single pointer (of type PT_PEN) associated with a pointer message.</para>
		/// <para>Use GetPointerFramePenInfo to retrieve frame information associated with a message for a set of pointers.</para>
		/// <para>
		/// The information returned by GetPointerInfo is associated with the most recent pointer message retrieved by the calling thread.
		/// When the next message is retrieved by the calling thread, the information associated with the previous message may no longer be available.
		/// </para>
		/// <para>
		/// If the application does not process pointer input messages as fast as they are generated, some messages may be coalesced into a
		/// WM_POINTERUPDATE message. Use GetPointerPenInfoHistory to retrieve the message history from the most recent
		/// <c>WM_POINTERUPDATE</c> message.
		/// </para>
		/// <para>
		/// If the information associated with the message is no longer available, this function fails with the last error set to <c>ERROR_NO_DATA</c>.
		/// </para>
		/// <para>
		/// If the calling thread does not own the window to which the pointer message has been delivered, this function fails with the last
		/// error set to <c>ERROR_ACCESS_DENIED</c>. Note that this may be the window to which the input was originally delivered or it may
		/// be a window to which the message was forwarded.
		/// </para>
		/// <para>If the specified pointer is not of type PT_PEN, this function fails with the last error set to <c>ERROR_DATATYPE_MISMATCH</c>.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getpointerpeninfo BOOL GetPointerPenInfo( UINT32
		// pointerId, POINTER_PEN_INFO *penInfo );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "5f1f7252-a4aa-4b06-94c9-2aa365cf0100")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetPointerPenInfo(uint pointerId, out POINTER_PEN_INFO penInfo);

		/// <summary>
		/// Gets the pen-based information associated with the individual inputs, if any, that were coalesced into the current message for
		/// the specified pointer (of type PT_PEN). The most recent input is included in the returned history and is the same as the most
		/// recent input returned by the GetPointerPenInfo function.
		/// </summary>
		/// <param name="pointerId">An identifier of the pointer for which to retrieve information.</param>
		/// <param name="entriesCount">
		/// A pointer to a variable that specifies the count of structures in the buffer to which penInfo points. If
		/// <c>GetPointerPenInfoHistory</c> succeeds, entriesCount is updated with the total count of structures available. The total count
		/// of structures available is the same as the historyCount field in the POINTER_PEN_INFO structure returned by a call to GetPointerPenInfo.
		/// </param>
		/// <param name="penInfo">
		/// Address of an array of POINTER_PEN_INFO structures to receive the pointer information. This parameter can be NULL if
		/// *entriesCount is zero.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is non-zero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If the application does not process pointer input messages as fast as they are generated, some moves may be coalesced. When an
		/// application receives a coalescable pointer (of type PT_PEN) message, it can use the <c>GetPointerPenInfoHistory</c> function to
		/// retrieve information for all the individual inputs, if any, that were coalesced into the message. Note that the information
		/// retrieved is associated with the pointer message most recently retrieved by the calling thread. Once the calling thread
		/// retrieves its next message, the information associated with the previous message may no longer be available.
		/// </para>
		/// <para>
		/// The information retrieved appears in reverse chronological order, with the most recent entry in the first row of the returned
		/// array. The most recent entry is the same as that returned by the GetPointerPenInfo function.
		/// </para>
		/// <para>
		/// If the count of rows in the buffer provided is insufficient to hold all available history entries, this function succeeds with
		/// the buffer containing the most recent entries and *entriesCount containing the total count of entries available.
		/// </para>
		/// <para>
		/// If the pointer frame contains no additional pointers besides the specified pointer, this function succeeds and returns only the
		/// information for the specified pointer.
		/// </para>
		/// <para>
		/// If the information associated with the pointer frame is no longer available, this function fails with the last error set to <c>ERROR_NO_DATA</c>.
		/// </para>
		/// <para>
		/// If the calling thread does not own the window (where the input was originally delivered or where the message was forwarded) to
		/// which the pointer message has been delivered, this function fails with the last error set to <c>ERROR_ACCESS_DENIED</c>.
		/// </para>
		/// <para>If the specified pointer is not of type PT_PEN, this function fails with the last error set to <c>ERROR_DATATYPE_MISMATCH</c>.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getpointerpeninfohistory BOOL GetPointerPenInfoHistory(
		// UINT32 pointerId, UINT32 *entriesCount, POINTER_PEN_INFO *penInfo );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "90082327-b242-4f5d-8cd7-fd8ef9340395")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetPointerPenInfoHistory(uint pointerId, ref uint entriesCount, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] POINTER_PEN_INFO[] penInfo);

		/// <summary>Gets the touch-based information for the specified pointer (of type PT_TOUCH) associated with the current message.</summary>
		/// <param name="pointerId">An identifier of the pointer for which to retrieve information.</param>
		/// <param name="touchInfo">Address of a POINTER_TOUCH_INFO structure to receive the touch-specific pointer information.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is non-zero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para><c>GetPointerTouchInfo</c> retrieves information for a single pointer (of type PT_TOUCH) associated with a pointer message.</para>
		/// <para>Use GetPointerFrameTouchInfo to retrieve frame information associated with a message for a set of pointers.</para>
		/// <para>
		/// The information returned by <c>GetPointerTouchInfo</c> is associated with the most recent pointer message retrieved by the
		/// calling thread. When the next message is retrieved by the calling thread, the information associated with the previous message
		/// may no longer be available.
		/// </para>
		/// <para>
		/// If the application does not process pointer input messages as fast as they are generated, some messages may be coalesced into a
		/// WM_POINTERUPDATE message. Use GetPointerTouchInfoHistory to retrieve the message history from the most recent
		/// <c>WM_POINTERUPDATE</c> message.
		/// </para>
		/// <para>
		/// If the information associated with the message is no longer available, this function fails with the last error set to <c>ERROR_NO_DATA</c>.
		/// </para>
		/// <para>
		/// If the calling thread does not own the window to which the pointer message has been delivered, this function fails with the last
		/// error set to <c>ERROR_ACCESS_DENIED</c>. Note that this may be the window to which the input was originally delivered or it may
		/// be a window to which the message was forwarded.
		/// </para>
		/// <para>If the specified pointer is not of type PT_TOUCH, this function fails with the last error set to <c>ERROR_DATATYPE_MISMATCH</c>.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getpointertouchinfo BOOL GetPointerTouchInfo( UINT32
		// pointerId, POINTER_TOUCH_INFO *touchInfo );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "97d93754-fc7e-4400-a6ee-6bab53e421cf")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetPointerTouchInfo(uint pointerId, out POINTER_TOUCH_INFO touchInfo);

		/// <summary>
		/// Gets the touch-based information associated with the individual inputs, if any, that were coalesced into the current message for
		/// the specified pointer (of type PT_TOUCH). The most recent input is included in the returned history and is the same as the most
		/// recent input returned by the GetPointerTouchInfo function.
		/// </summary>
		/// <param name="pointerId">An identifier of the pointer for which to retrieve information.</param>
		/// <param name="entriesCount">
		/// A pointer to a variable that specifies the count of structures in the buffer to which touchInfo points. If
		/// <c>GetPointerTouchInfoHistory</c> succeeds, entriesCount is updated with the total count of structures available. The total
		/// count of structures available is the same as the historyCount field in the POINTER_INFO structure returned by a call to
		/// GetPointerInfo or GetPointerTouchInfo.
		/// </param>
		/// <param name="touchInfo">
		/// Address of an array of POINTER_TOUCH_INFO structures to receive the pointer information. This parameter can be NULL if
		/// *entriesCount is zero.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is non-zero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If the application does not process pointer input messages as fast as they are generated, some moves may be coalesced. When an
		/// application receives a coalescable pointer (of type PT_TOUCH) message, it can use the <c>GetPointerTouchInfoHistory</c> function
		/// to retrieve information for all the individual inputs, if any, that were coalesced into the message. Note that the information
		/// retrieved is associated with the pointer message most recently retrieved by the calling thread. Once the calling thread
		/// retrieves its next message, the information associated with the previous message may no longer be available.
		/// </para>
		/// <para>
		/// The information retrieved appears in reverse chronological order, with the most recent entry in the first row of the returned
		/// array. The most recent entry is the same as that returned by the GetPointerTouchInfo function.
		/// </para>
		/// <para>
		/// If the count of rows in the buffer provided is insufficient to hold all available history entries, this function succeeds with
		/// the buffer containing the most recent entries and *entriesCount containing the total count of entries available.
		/// </para>
		/// <para>
		/// If the pointer frame contains no additional pointers besides the specified pointer, this function succeeds and returns only the
		/// information for the specified pointer.
		/// </para>
		/// <para>
		/// If the information associated with the pointer frame is no longer available, this function fails with the last error set to <c>ERROR_NO_DATA</c>.
		/// </para>
		/// <para>
		/// If the calling thread does not own the window (where the input was originally delivered or where the message was forwarded) to
		/// which the pointer message has been delivered, this function fails with the last error set to <c>ERROR_ACCESS_DENIED</c>.
		/// </para>
		/// <para>If the specified pointer is not of type PT_TOUCH, this function fails with the last error set to <c>ERROR_DATATYPE_MISMATCH</c>.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getpointertouchinfohistory BOOL
		// GetPointerTouchInfoHistory( UINT32 pointerId, UINT32 *entriesCount, POINTER_TOUCH_INFO *touchInfo );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "9fdfbde7-4126-4c1b-b870-479f846e1aa9")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetPointerTouchInfoHistory(uint pointerId, ref uint entriesCount, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] POINTER_TOUCH_INFO[] touchInfo);

		/// <summary>Retrieves the pointer type for a specified pointer.</summary>
		/// <param name="pointerId">An identifier of the pointer for which to retrieve pointer type.</param>
		/// <param name="pointerType">An address of a POINTER_INPUT_TYPE type to receive a pointer input type.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is non-zero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// An application can use the <c>GetPointerType</c> function to determine the pointer type if it wishes to react differently to
		/// pointers of different types.
		/// </para>
		/// <para><c>Note</c> This function will never return with the generic PT_POINTER type.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getpointertype BOOL GetPointerType( UINT32 pointerId,
		// POINTER_INPUT_TYPE *pointerType );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "63bfc340-9691-463c-96ca-0a5b80b8fe40")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetPointerType(uint pointerId, out POINTER_INPUT_TYPE pointerType);

		/// <summary>Gets the raw input data from the pointer device.</summary>
		/// <param name="pointerId">An identifier of the pointer for which to retrieve information.</param>
		/// <param name="historyCount">The pointer history.</param>
		/// <param name="propertiesCount">Number of properties to retrieve.</param>
		/// <param name="pProperties">Array of POINTER_DEVICE_PROPERTY structures that contain raw data reported by the device.</param>
		/// <param name="pValues">The values for pProperties.</param>
		/// <returns>
		/// TRUE if the function succeeds; otherwise, FALSE. If the function fails, call the GetLastError function for more information.
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getrawpointerdevicedata BOOL GetRawPointerDeviceData(
		// UINT32 pointerId, UINT32 historyCount, UINT32 propertiesCount, POINTER_DEVICE_PROPERTY *pProperties, LONG *pValues );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "56b65cc9-9582-4c7f-81e8-0b0d45b4dc8b")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetRawPointerDeviceData(uint pointerId, uint historyCount, uint propertiesCount, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] POINTER_DEVICE_PROPERTY[] pProperties, IntPtr pValues);

		/// <summary>Gets pointer data before it has gone through touch prediction processing.</summary>
		/// <returns>The screen location of the pointer input.</returns>
		/// <remarks>By default, touch prediction is activated.</remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getunpredictedmessagepos DWORD GetUnpredictedMessagePos( );
		[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "5BE2748B-0124-4647-A77E-EA2937C7B1AD")]
		public static extern uint GetUnpredictedMessagePos();

		/// <summary>Simulates pointer input (pen or touch).</summary>
		/// <param name="device">A handle to the pointer injection device created by CreateSyntheticPointerDevice.</param>
		/// <param name="pointerInfo">
		/// <para>Array of injected pointers.</para>
		/// <para>The type must match the pointerType parameter of the CreateSyntheticPointerDevice call that created the injection device.</para>
		/// <para>The ptPixelLocation for each POINTER_TYPE_INFO is specified relative to top left of the virtual screen:</para>
		/// </param>
		/// <param name="count">
		/// <para>The number of contacts.</para>
		/// <para>For PT_TOUCH this value must be greater than 0 and less than or equal to MAX_TOUCH_COUNT.</para>
		/// <para>For PT_PEN this value must be 1.</para>
		/// </param>
		/// <returns>
		/// <para>If this function succeeds, it returns TRUE.</para>
		/// <para>Otherwise, it returns FALSE. To retrieve extended error information, call the GetLastError function.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/winuser/nf-winuser-injectsyntheticpointerinput BOOL
		// InjectSyntheticPointerInput( HSYNTHETICPOINTERDEVICE device, const POINTER_TYPE_INFO *pointerInfo, UINT32 count );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "9F7FC5E2-F4B8-42C2-A4BE-240E36AFC13B")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool InjectSyntheticPointerInput(HSYNTHETICPOINTERDEVICE device, [In, MarshalAs(UnmanagedType.LPArray)] POINTER_TYPE_INFO[] pointerInfo, uint count);

		/// <summary>
		/// Indicates whether EnableMouseInPointer is set for the mouse to act as a pointer input device and send WM_POINTER messages.
		/// </summary>
		/// <returns>
		/// <para>If EnableMouseInPointer is set, the return value is nonzero.</para>
		/// <para>If EnableMouseInPointer is not set, the return value is zero.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// EnableMouseInPointer can be called only once in the context of a process lifetime. Prior to the first call, Windows Store apps
		/// run with mouse-in-pointer enabled, as do any desktop applications that consume mshtml.dll. All other desktop applications run
		/// with mouse-in-pointer disabled.
		/// </para>
		/// <para>On the first call to EnableMouseInPointer in the process lifetime, the state is changed as specified and the call succeeds.</para>
		/// <para>
		/// On subsequent calls to EnableMouseInPointer, the state will not change. If the current state is not equal to the specified
		/// state, the call fails.
		/// </para>
		/// <para>Call <c>IsMouseInPointerEnabled</c> to verify the mouse-in-pointer state.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-ismouseinpointerenabled BOOL IsMouseInPointerEnabled( );
		[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "5D493066-2425-4610-8489-575BF25C8C16")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool IsMouseInPointerEnabled();

		/// <summary>
		/// Registers a window to process the WM_POINTERDEVICECHANGE, WM_POINTERDEVICEINRANGE, and WM_POINTERDEVICEOUTOFRANGE pointer device notifications.
		/// </summary>
		/// <param name="window">
		/// The window that receives WM_POINTERDEVICECHANGE, WM_POINTERDEVICEINRANGE, and WM_POINTERDEVICEOUTOFRANGE notifications.
		/// </param>
		/// <param name="notifyRange">
		/// If set to TRUE, process the WM_POINTERDEVICEINRANGE and WM_POINTERDEVICEOUTOFRANGE messages. If set to FALSE, these messages
		/// aren't processed.
		/// </param>
		/// <returns>
		/// <para>If this function succeeds, it returns TRUE.</para>
		/// <para>Otherwise, it returns FALSE. To retrieve extended error information, call the GetLastError function.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-registerpointerdevicenotifications BOOL
		// RegisterPointerDeviceNotifications( HWND window, BOOL notifyRange );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "a7322d97-f96c-449d-94a6-2081962ec7ed")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool RegisterPointerDeviceNotifications(HWND window, [MarshalAs(UnmanagedType.Bool)] bool notifyRange);

		/// <summary>Allows the caller to register a target window to which all pointer input of the specified type is redirected.</summary>
		/// <param name="hwnd">
		/// <para>The window to register as a global redirection target.</para>
		/// <para>
		/// Redirection can cause the foreground window to lose activation (focus). To avoid this, ensure the window is a message-only
		/// window or has the WS_EX_NOACTIVATE style set.
		/// </para>
		/// </param>
		/// <param name="pointerType">
		/// Type of pointer input to be redirected to the specified window. This is any valid and supported value from the
		/// POINTER_INPUT_TYPE enumeration. Note that the generic <c>PT_POINTER</c> type and the <c>PT_MOUSE</c> type are not valid in this parameter.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is non-zero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// An application with the UI Access privilege can use this function to register its own window to receive all input of the
		/// specified pointer input type. Each desktop allows only one such global redirection target window for each pointer input type at
		/// any given time. The first window to successfully register remains in effect until the window is unregistered or destroyed, at
		/// which point the role is available to the next qualified caller.
		/// </para>
		/// <para>
		/// While the registration is in effect, all input of the specified pointer type, whether from an input device or injected by an
		/// application, is redirected to the registered window. However, when the process that owns the registered window injects input of
		/// the specified pointer type, such injected is not redirected but is instead processed normally.
		/// </para>
		/// <para>
		/// An application that wishes to register the same window as a global redirection target for multiple pointer input types must call
		/// the <c>RegisterPointerInputTarget</c> function multiple times, once for each pointer input type of interest.
		/// </para>
		/// <para>If the calling thread does not have the UI Access privilege, this function fails with the last error set to <c>ERROR_ACCESS_DENIED</c>.</para>
		/// <para>If the specified pointer input type is not valid, this function fails with the last error set to <c>ERROR_INVALID_PARAMETER</c>.</para>
		/// <para>If the calling thread does not own the specified window, this function fails with the last error set to <c>ERROR_ACCESS_DENIED</c>.</para>
		/// <para>
		/// If the specified window’s desktop already has a registered global redirection target for the specified pointer input type, this
		/// function fails with the last error set to <c>ERROR_ACCESS_DENIED</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-registerpointerinputtarget BOOL
		// RegisterPointerInputTarget( HWND hwnd, POINTER_INPUT_TYPE pointerType );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "75faea24-91cd-448b-b67a-09fe530f1830")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool RegisterPointerInputTarget(HWND hwnd, POINTER_INPUT_TYPE pointerType);

		/// <summary>
		/// <para>[ <c>RegisterPointerInputTargetEx</c> is not supported and may be altered or unavailable in the future. Instead, use RegisterPointerInputTarget.]</para>
		/// <para><c>RegisterPointerInputTargetEx</c> may be altered or unavailable. Instead, use RegisterPointerInputTarget.</para>
		/// </summary>
		/// <param name="hwnd">Not supported.</param>
		/// <param name="pointerType">Not supported.</param>
		/// <param name="fObserve">Not supported.</param>
		/// <returns>Not supported.</returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-registerpointerinputtargetex BOOL
		// RegisterPointerInputTargetEx( HWND hwnd, POINTER_INPUT_TYPE pointerType, BOOL fObserve );
		[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "E2B3D097-36E5-4444-B9DF-B3D38F1FEF48")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool RegisterPointerInputTargetEx(HWND hwnd, POINTER_INPUT_TYPE pointerType, [MarshalAs(UnmanagedType.Bool)] bool fObserve);

		/// <summary>
		/// Determines which pointer input frame generated the most recently retrieved message for the specified pointer and discards any
		/// queued (unretrieved) pointer input messages generated from the same pointer input frame. If an application has retrieved
		/// information for an entire frame using the GetPointerFrameInfo function, the GetPointerFrameInfoHistory function or one of their
		/// type-specific variants, it can use this function to avoid retrieving and discarding remaining messages from that frame one by one.
		/// </summary>
		/// <param name="pointerId">
		/// Identifier of the pointer. Pending messages will be skipped for the frame that includes the most recently retrieved input for
		/// this pointer.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is non-zero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Parallel-mode devices may report pointer input in frames, that is, they may report the state and position of all pointers from
		/// that device in a single input report to the system. Ideally, applications should view the entire frame as a single input unless
		/// the application-specific requirements dictate otherwise.
		/// </para>
		/// <para>
		/// The <c>SkipPointerFrameMessages</c> function can be used in conjunction with the GetPointerFrameInfo function (or one of its
		/// type-specific variants) to consume entire frames as a single input.
		/// </para>
		/// <para>
		/// When an application sees a pointer message, it can use the GetPointerFrameInfo function to retrieve the entire pointer input
		/// frame to which the pointer message belongs, hence obtaining an updated view of all of the pointers currently owned by the
		/// window. Note that the returned frame contains only pointers that are currently owned by the same window as the specified pointer.
		/// </para>
		/// <para>
		/// Having retrieved the entire frame of information, the application can then call the <c>SkipPointerFrameMessages</c> function to
		/// skip remaining pointer messages associated with this frame that are pending retrieval. This saves the application the overhead
		/// of retrieving and processing the remaining messages one by one.
		/// </para>
		/// <para>
		/// <c>Warning</c> The <c>SkipPointerFrameMessages</c> function should be used only when the caller can be sure that no other entity
		/// on the caller’s thread (such as Direct Manipulation) is expecting to retrieve pending pointer messages. For this reason,
		/// <c>SkipPointerFrameMessages</c> should not be used in conjunction with Direct Manipulation when processing multiple,
		/// simultaneous interactions.
		/// </para>
		/// <para>
		/// Note that the information retrieved is associated with the pointer frame most recently retrieved by the calling thread. Once the
		/// calling thread retrieves its next message, the information associated with the previous pointer frame may no longer be available.
		/// </para>
		/// <para>If the pointer frame contains no additional pointers besides the specified pointer, this function succeeds with no action.</para>
		/// <para>
		/// If the calling thread does not own the window to which the pointer message has been delivered, this function fails with the last
		/// error set to <c>ERROR_ACCESS_DENIED</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-skippointerframemessages BOOL SkipPointerFrameMessages(
		// UINT32 pointerId );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "d67f8d44-3e19-4523-a0f3-38f09f5df91f")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SkipPointerFrameMessages(uint pointerId);

		/// <summary>Allows the caller to unregister a target window to which all pointer input of the specified type is redirected.</summary>
		/// <param name="hwnd">Window to be un-registered as a global redirection target on its desktop.</param>
		/// <param name="pointerType">
		/// Type of pointer input to no longer be redirected to the specified window. This is any valid and supported value from the
		/// POINTER_INPUT_TYPE enumeration. Note that the generic <c>PT_POINTER</c> type and the <c>PT_MOUSE</c> type are not valid in this parameter.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is non-zero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// An application that has successfully called the RegisterPointerInputTarget function can call this function to un-register the
		/// window from the role of global redirected target for the specified pointer type.
		/// </para>
		/// <para>
		/// An application that has registered the same window as a global redirection target for multiple pointer input types can call the
		/// <c>UnregisterPointerInputTarget</c> to un-register the window for one of those types while leaving the window registered for the
		/// remaining types.
		/// </para>
		/// <para>If the calling thread does not have the UI Access privilege, this function fails with the last error set to <c>ERROR_ACCESS_DENIED</c>.</para>
		/// <para>If the specified pointer input type is not valid, this function fails with the last error set to <c>ERROR_INVALID_PARAMETER</c>.</para>
		/// <para>If the calling thread does not own the specified window, this function fails with the last error set to <c>ERROR_ACCESS_DENIED</c>.</para>
		/// <para>
		/// If the specified window is not the registered global redirection target for the specified pointer input type on its desktop,
		/// this function takes no action and returns success.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-unregisterpointerinputtarget BOOL
		// UnregisterPointerInputTarget( HWND hwnd, POINTER_INPUT_TYPE pointerType );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "75faea24-91cd-448b-b67a-09fe530f1800")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool UnregisterPointerInputTarget(HWND hwnd, POINTER_INPUT_TYPE pointerType);

		/// <summary>Provides a handle to a synthetic pointer device.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct HSYNTHETICPOINTERDEVICE : IHandle
		{
			private IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="HSYNTHETICPOINTERDEVICE"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public HSYNTHETICPOINTERDEVICE(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="HSYNTHETICPOINTERDEVICE"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static HSYNTHETICPOINTERDEVICE NULL => new HSYNTHETICPOINTERDEVICE(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="HSYNTHETICPOINTERDEVICE"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(HSYNTHETICPOINTERDEVICE h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HSYNTHETICPOINTERDEVICE"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator HSYNTHETICPOINTERDEVICE(IntPtr h) => new HSYNTHETICPOINTERDEVICE(h);

			/// <summary>Implements the operator !=.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(HSYNTHETICPOINTERDEVICE h1, HSYNTHETICPOINTERDEVICE h2) => !(h1 == h2);

			/// <summary>Implements the operator ==.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(HSYNTHETICPOINTERDEVICE h1, HSYNTHETICPOINTERDEVICE h2) => h1.Equals(h2);

			/// <inheritdoc/>
			public override bool Equals(object obj) => obj is HSYNTHETICPOINTERDEVICE h ? handle == h.handle : false;

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
		}

		/// <summary>
		/// Defines the matrix that represents a transform on a message consumer. This matrix can be used to transform pointer input data
		/// from client coordinates to screen coordinates, while the inverse can be used to transform pointer input data from screen
		/// coordinates to client coordinates.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ns-winuser-taginput_transform typedef struct tagINPUT_TRANSFORM {
		// union { struct { float _11; float _12; float _13; float _14; float _21; float _22; float _23; float _24; float _31; float _32;
		// float _33; float _34; float _41; float _42; float _43; float _44; } DUMMYSTRUCTNAME; float m[4]; } DUMMYUNIONNAME; } INPUT_TRANSFORM;
		[PInvokeData("winuser.h", MSDNShortId = "DE6854F0-17D8-4E4B-97CB-A135910A300C")]
		[StructLayout(LayoutKind.Sequential)]
		public struct INPUT_TRANSFORM
		{
			/// <summary>Undocumented.</summary>
			public float _11, _12, _13, _14;

			/// <summary>Undocumented.</summary>
			public float _21, _22, _23, _24;

			/// <summary>Undocumented.</summary>
			public float _31, _32, _33, _34;

			/// <summary>Undocumented.</summary>
			public float _41, _42, _43, _44;

			/// <summary>Undocumented.</summary>
			public float[,] m
			{
				get => new float[4, 4] { { _11, _12, _13, _14 }, { 21, _22, _23, _24 }, { _31, _32, _33, _34 }, { _41, _42, _43, _44 } };
				set
				{
					if (value is null) throw new ArgumentNullException(nameof(m));
					if (value.Rank != 2 || value.GetLength(0) != 4 || value.GetLength(1) != 4) throw new ArgumentOutOfRangeException(nameof(m), "Must be a 4x4 two-dimensional array.");
					unsafe
					{
						fixed (float* ptr = &_11)
						{
							for (var i = 0; i < 4; i++)
							{
								for (var j = 0; j < 4; j++)
								{
									*(ptr + (i * 4) + j) = value[i, j];
								}
							}
						}
					}
				}
			}
		}

		/// <summary>Contains cursor ID mappings for pointer devices.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ns-winuser-pointer_device_cursor_info typedef struct
		// tagPOINTER_DEVICE_CURSOR_INFO { UINT32 cursorId; POINTER_DEVICE_CURSOR_TYPE cursor; } POINTER_DEVICE_CURSOR_INFO;
		[PInvokeData("winuser.h", MSDNShortId = "5d71e5b4-95eb-453e-9164-e7659ef4059e")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct POINTER_DEVICE_CURSOR_INFO
		{
			/// <summary>The assigned cursor ID.</summary>
			public uint cursorId;

			/// <summary>The POINTER_DEVICE_CURSOR_TYPE that the ID is mapped to.</summary>
			public POINTER_DEVICE_CURSOR_TYPE cursor;
		}

		/// <summary>
		/// Contains information about a pointer device. An array of these structures is returned from the GetPointerDevices function. A
		/// single structure is returned from a call to the GetPointerDevice function.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ns-winuser-tagpointer_device_info typedef struct
		// tagPOINTER_DEVICE_INFO { DWORD displayOrientation; HANDLE device; POINTER_DEVICE_TYPE pointerDeviceType; HMONITOR monitor; ULONG
		// startingCursorId; USHORT maxActiveContacts; WCHAR productString[POINTER_DEVICE_PRODUCT_STRING_MAX]; } POINTER_DEVICE_INFO;
		[PInvokeData("winuser.h", MSDNShortId = "1b909caf-2d69-42b9-8d60-5d89a0286f59")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct POINTER_DEVICE_INFO
		{
			/// <summary>
			/// <para>One of the values from DISPLAYCONFIG_ROTATION, which identifies the orientation of the input digitizer.</para>
			/// <para><c>Note</c> This value is 0 when the source of input is Touch Injection.</para>
			/// </summary>
			public uint displayOrientation;

			/// <summary>The handle to the pointer device.</summary>
			public HANDLE device;

			/// <summary>The device type.</summary>
			public POINTER_DEVICE_TYPE pointerDeviceType;

			/// <summary>
			/// The HMONITOR for the display that the device is mapped to. This is not necessarily the monitor that the pointer device is
			/// physically connected to.
			/// </summary>
			public HMONITOR monitor;

			/// <summary>The lowest ID that's assigned to the device.</summary>
			public uint startingCursorId;

			/// <summary>The number of supported simultaneous contacts.</summary>
			public ushort maxActiveContacts;

			/// <summary>The string that identifies the product.</summary>
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 520)]
			public string productString;
		}

		/// <summary>Contains pointer-based device properties (Human Interface Device (HID) global items that correspond to HID usages).</summary>
		/// <remarks>
		/// Developers can use this function to determine the properties that a device supports beyond the standard ones that are delivered
		/// through Pointer Input Messages and Notifications. The properties map directly to HID usages.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ns-winuser-tagpointer_device_property typedef struct
		// tagPOINTER_DEVICE_PROPERTY { INT32 logicalMin; INT32 logicalMax; INT32 physicalMin; INT32 physicalMax; UINT32 unit; UINT32
		// unitExponent; USHORT usagePageId; USHORT usageId; } POINTER_DEVICE_PROPERTY;
		[PInvokeData("winuser.h", MSDNShortId = "2c96379e-7c9f-440c-a98b-bda38bacd33f")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct POINTER_DEVICE_PROPERTY
		{
			/// <summary>The minimum value that the device can report for this property.</summary>
			public int logicalMin;

			/// <summary>The maximum value that the device can report for this property.</summary>
			public int logicalMax;

			/// <summary>The physical minimum in Himetric.</summary>
			public int physicalMin;

			/// <summary>The physical maximum in Himetric.</summary>
			public int physicalMax;

			/// <summary>The unit.</summary>
			public uint unit;

			/// <summary>The exponent.</summary>
			public uint unitExponent;

			/// <summary>The usage page for the property, as documented in the HID specification.</summary>
			public ushort usagePageId;

			/// <summary>The usage of the property, as documented in the HID specification.</summary>
			public ushort usageId;
		}

		/// <summary>
		/// Contains basic pointer information common to all pointer types. Applications can retrieve this information using the
		/// GetPointerInfo, GetPointerFrameInfo, GetPointerInfoHistory and GetPointerFrameInfoHistory functions.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ns-winuser-tagpointer_info typedef struct tagPOINTER_INFO {
		// POINTER_INPUT_TYPE pointerType; UINT32 pointerId; UINT32 frameId; POINTER_FLAGS pointerFlags; HANDLE sourceDevice; HWND
		// hwndTarget; POINT ptPixelLocation; POINT ptHimetricLocation; POINT ptPixelLocationRaw; POINT ptHimetricLocationRaw; DWORD dwTime;
		// UINT32 historyCount; INT32 InputData; DWORD dwKeyStates; UINT64 PerformanceCount; POINTER_BUTTON_CHANGE_TYPE ButtonChangeType; } POINTER_INFO;
		[PInvokeData("winuser.h", MSDNShortId = "fee176ba-ad07-4145-0b4d-1b8c335fd102")]
		[StructLayout(LayoutKind.Sequential)]
		public struct POINTER_INFO
		{
			/// <summary>
			/// <para>Type: <c>POINTER_INPUT_TYPE</c></para>
			/// <para>A value from the POINTER_INPUT_TYPE enumeration that specifies the pointer type.</para>
			/// </summary>
			public POINTER_INPUT_TYPE pointerType;

			/// <summary>
			/// <para>Type: <c>UINT32</c></para>
			/// <para>
			/// An identifier that uniquely identifies a pointer during its lifetime. A pointer comes into existence when it is first
			/// detected and ends its existence when it goes out of detection range. Note that if a physical entity (finger or pen) goes out
			/// of detection range and then returns to be detected again, it is treated as a new pointer and may be assigned a new pointer identifier.
			/// </para>
			/// </summary>
			public uint pointerId;

			/// <summary>
			/// <para>Type: <c>UINT32</c></para>
			/// <para>
			/// An identifier common to multiple pointers for which the source device reported an update in a single input frame. For
			/// example, a parallel-mode multi-touch digitizer may report the positions of multiple touch contacts in a single update to the system.
			/// </para>
			/// <para>
			/// Note that frame identifier is assigned as input is reported to the system for all pointers across all devices. Therefore,
			/// this field may not contain strictly sequential values in a single series of messages that a window receives. However, this
			/// field will contain the same numerical value for all input updates that were reported in the same input frame by a single device.
			/// </para>
			/// </summary>
			public uint frameId;

			/// <summary>
			/// <para>Type: <c>POINTER_FLAGS</c></para>
			/// <para>May be any reasonable combination of flags from the Pointer Flags constants.</para>
			/// </summary>
			public POINTER_FLAGS pointerFlags;

			/// <summary>
			/// <para>Type: <c>HANDLE</c></para>
			/// <para>Handle to the source device that can be used in calls to the raw input device API and the digitizer device API.</para>
			/// </summary>
			public HANDLE sourceDevice;

			/// <summary>
			/// <para>Type: <c>HWND</c></para>
			/// <para>
			/// Window to which this message was targeted. If the pointer is captured, either implicitly by virtue of having made contact
			/// over this window or explicitly using the pointer capture API, this is the capture window. If the pointer is uncaptured, this
			/// is the window over which the pointer was when this message was generated.
			/// </para>
			/// </summary>
			public HWND hwndTarget;

			/// <summary>
			/// <para>Type: <c>POINT</c></para>
			/// <para>The predicted screen coordinates of the pointer, in pixels.</para>
			/// <para>
			/// The predicted value is based on the pointer position reported by the digitizer and the motion of the pointer. This
			/// correction can compensate for visual lag due to inherent delays in sensing and processing the pointer location on the
			/// digitizer. This is applicable to pointers of type PT_TOUCH. For other pointer types, the predicted value will be the same as
			/// the non-predicted value (see <c>ptPixelLocationRaw</c>).
			/// </para>
			/// </summary>
			public System.Drawing.Point ptPixelLocation;

			/// <summary>
			/// <para>Type: <c>POINT</c></para>
			/// <para>The predicted screen coordinates of the pointer, in HIMETRIC units.</para>
			/// <para>
			/// The predicted value is based on the pointer position reported by the digitizer and the motion of the pointer. This
			/// correction can compensate for visual lag due to inherent delays in sensing and processing the pointer location on the
			/// digitizer. This is applicable to pointers of type PT_TOUCH. For other pointer types, the predicted value will be the same as
			/// the non-predicted value (see <c>ptHimetricLocationRaw</c>).
			/// </para>
			/// </summary>
			public System.Drawing.Point ptHimetricLocation;

			/// <summary>
			/// <para>Type: <c>POINT</c></para>
			/// <para>The screen coordinates of the pointer, in pixels. For adjusted screen coordinates, see <c>ptPixelLocation</c>.</para>
			/// </summary>
			public System.Drawing.Point ptPixelLocationRaw;

			/// <summary>
			/// <para>Type: <c>POINT</c></para>
			/// <para>The screen coordinates of the pointer, in HIMETRIC units. For adjusted screen coordinates, see <c>ptHimetricLocation</c>.</para>
			/// </summary>
			public System.Drawing.Point ptHimetricLocationRaw;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>0 or the time stamp of the message, based on the system tick count when the message was received.</para>
			/// <para>
			/// The application can specify the input time stamp in either <c>dwTime</c> or <c>PerformanceCount</c>. The value cannot be
			/// more recent than the current tick count or <c>QueryPerformanceCount (QPC)</c> value of the injection thread. Once a frame is
			/// injected with a time stamp, all subsequent frames must include a timestamp until all contacts in the frame go to an UP
			/// state. The custom timestamp value must also be provided for the first element in the contacts array. The time stamp values
			/// after the first element are ignored. The custom timestamp value must increment in every injection frame.
			/// </para>
			/// <para>
			/// When <c>PerformanceCount</c> is specified, the time stamp will be converted to the current time in .1 millisecond resolution
			/// upon actual injection. If a custom <c>PerformanceCount</c> resulted in the same .1 millisecond window from the previous
			/// injection, <c>ERROR_NOT_READY</c> is returned and injection will not occur. While injection will not be invalidated
			/// immediately by the error, the next successful injection must have a <c>PerformanceCount</c> value that is at least 0.1
			/// millisecond from the previously successful injection. This is also true if <c>dwTime</c> is used.
			/// </para>
			/// <para>If both <c>dwTime</c> and <c>PerformanceCount</c> are specified in InjectTouchInput, ERROR_INVALID_PARAMETER is returned.</para>
			/// <para>InjectTouchInput cannot switch between <c>dwTime</c> and <c>PerformanceCount</c> once injection has started.</para>
			/// <para>
			/// If neither <c>dwTime</c> and <c>PerformanceCount</c> are specified, InjectTouchInput allocates the timestamp based on the
			/// timing of the call. If <c>InjectTouchInput</c> calls are repeatedly less than 0.1 millisecond apart, ERROR_NOT_READY might
			/// be returned. The error will not invalidate the input immediately, but the injection application needs to retry the same
			/// frame again for injection to succeed.
			/// </para>
			/// </summary>
			public uint dwTime;

			/// <summary>
			/// <para>Type: <c>UINT32</c></para>
			/// <para>
			/// Count of inputs that were coalesced into this message. This count matches the total count of entries that can be returned by
			/// a call to GetPointerInfoHistory. If no coalescing occurred, this count is 1 for the single input represented by the message.
			/// </para>
			/// </summary>
			public uint historyCount;

			/// <summary>The input data</summary>
			public int InputData;

			/// <summary>
			/// <para>Type: <c>DWORD</c></para>
			/// <para>
			/// Indicates which keyboard modifier keys were pressed at the time the input was generated. May be zero or a combination of the
			/// following values.
			/// </para>
			/// <para>POINTER_MOD_SHIFT – A SHIFT key was pressed.</para>
			/// <para>POINTER_MOD_CTRL – A CTRL key was pressed.</para>
			/// </summary>
			public uint dwKeyStates;

			/// <summary>
			/// <para>Type: <c>UINT64</c></para>
			/// <para>
			/// The value of the high-resolution performance counter when the pointer message was received (high-precision, 64 bit
			/// alternative to <c>dwTime</c>). The value can be calibrated when the touch digitizer hardware supports the scan timestamp
			/// information in its input report.
			/// </para>
			/// </summary>
			public ulong PerformanceCount;

			/// <summary>
			/// <para>Type: <c>POINTER_BUTTON_CHANGE_TYPE</c></para>
			/// <para>
			/// A value from the POINTER_BUTTON_CHANGE_TYPE enumeration that specifies the change in button state between this input and the
			/// previous input.
			/// </para>
			/// </summary>
			public POINTER_BUTTON_CHANGE_TYPE ButtonChangeType;
		}

		/// <summary>Defines basic pen information common to all pointer types.</summary>
		/// <remarks>
		/// Applications can retrieve this information using the GetPointerPenInfo, GetPointerFramePenInfo, GetPointerPenInfoHistory and
		/// GetPointerFramePenInfoHistory API functions.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ns-winuser-tagpointer_pen_info typedef struct tagPOINTER_PEN_INFO {
		// POINTER_INFO pointerInfo; PEN_FLAGS penFlags; PEN_MASK penMask; UINT32 pressure; UINT32 rotation; INT32 tiltX; INT32 tiltY; } POINTER_PEN_INFO;
		[PInvokeData("winuser.h", MSDNShortId = "fee176ba-ad07-4141-ab4d-1b8c335fd111")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct POINTER_PEN_INFO
		{
			/// <summary>
			/// <para>Type: <c>POINTER_INFO</c></para>
			/// <para>An embedded POINTER_INFO structure.</para>
			/// </summary>
			public POINTER_INFO pointerInfo;

			/// <summary>
			/// <para>Type: <c>PEN_FLAGS</c></para>
			/// <para>The pen flag. This member can be zero or any reasonable combination of the values from the Pen Flags constants.</para>
			/// </summary>
			public PEN_FLAGS penFlags;

			/// <summary>
			/// <para>Type: <c>PEN_MASK</c></para>
			/// <para>The pen mask. This member can be zero or any reasonable combination of the values from the Pen Mask constants.</para>
			/// </summary>
			public PEN_MASK penMask;

			/// <summary>
			/// <para>Type: <c>UINT32</c></para>
			/// <para>A pen pressure normalized to a range between 0 and 1024. The default is 0 if the device does not report pressure.</para>
			/// </summary>
			public uint pressure;

			/// <summary>
			/// <para>Type: <c>UINT32</c></para>
			/// <para>The clockwise rotation, or twist, of the pointer normalized in a range of 0 to 359. The default is 0.</para>
			/// </summary>
			public uint rotation;

			/// <summary>
			/// <para>Type: <c>INT32</c></para>
			/// <para>
			/// The angle of tilt of the pointer along the x-axis in a range of -90 to +90, with a positive value indicating a tilt to the
			/// right. The default is 0.
			/// </para>
			/// </summary>
			public int tiltX;

			/// <summary>
			/// <para>Type: <c>INT32</c></para>
			/// <para>
			/// The angle of tilt of the pointer along the y-axis in a range of -90 to +90, with a positive value indicating a tilt toward
			/// the user. The default is 0.
			/// </para>
			/// </summary>
			public int tiltY;
		}

		/// <summary>Defines basic touch information common to all pointer types.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ns-winuser-tagpointer_touch_info typedef struct
		// tagPOINTER_TOUCH_INFO { POINTER_INFO pointerInfo; TOUCH_FLAGS touchFlags; TOUCH_MASK touchMask; RECT rcContact; RECT
		// rcContactRaw; UINT32 orientation; UINT32 pressure; } POINTER_TOUCH_INFO;
		[PInvokeData("winuser.h", MSDNShortId = "fee176ba-ad07-3141-ab4d-1b8c335fd102")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct POINTER_TOUCH_INFO
		{
			/// <summary>
			/// <para>Type: <c>POINTER_INFO</c></para>
			/// <para>An embedded POINTER_INFO header structure.</para>
			/// </summary>
			public POINTER_INFO pointerInfo;

			/// <summary>
			/// <para>Type: <c>Touch Flags</c></para>
			/// <para>Currently none.</para>
			/// </summary>
			public TOUCH_FLAGS touchFlags;

			/// <summary>
			/// <para>Type: <c>Touch Mask</c></para>
			/// <para>
			/// Indicates which of the optional fields contain valid values. The member can be zero or any combination of the values from
			/// the Touch Mask constants.
			/// </para>
			/// </summary>
			public TOUCH_MASK touchMask;

			/// <summary>
			/// <para>Type: <c>RECT</c></para>
			/// <para>
			/// The predicted screen coordinates of the contact area, in pixels. By default, if the device does not report a contact area,
			/// this field defaults to a 0-by-0 rectangle centered around the pointer location.
			/// </para>
			/// <para>
			/// The predicted value is based on the pointer position reported by the digitizer and the motion of the pointer. This
			/// correction can compensate for visual lag due to inherent delays in sensing and processing the pointer location on the
			/// digitizer. This is applicable to pointers of type PT_TOUCH.
			/// </para>
			/// </summary>
			public RECT rcContact;

			/// <summary>
			/// <para>Type: <c>RECT</c></para>
			/// <para>The raw screen coordinates of the contact area, in pixels. For adjusted screen coordinates, see <c>rcContact</c>.</para>
			/// </summary>
			public RECT rcContactRaw;

			/// <summary>
			/// <para>Type: <c>UINT32</c></para>
			/// <para>
			/// A pointer orientation, with a value between 0 and 359, where 0 indicates a touch pointer aligned with the x-axis and
			/// pointing from left to right; increasing values indicate degrees of rotation in the clockwise direction.
			/// </para>
			/// <para>This field defaults to 0 if the device does not report orientation.</para>
			/// </summary>
			public uint orientation;

			/// <summary>
			/// <para>Type: <c>UINT32</c></para>
			/// <para>A pen pressure normalized to a range between 0 and 1024. The default is 0 if the device does not report pressure.</para>
			/// </summary>
			public uint pressure;
		}

		/// <summary>Contains information about the pointer input type.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/winuser/ns-winuser-pointer_type_info typedef struct tagPOINTER_TYPE_INFO {
		// POINTER_INPUT_TYPE type; union { POINTER_TOUCH_INFO touchInfo; POINTER_PEN_INFO penInfo; } DUMMYUNIONNAME; } POINTER_TYPE_INFO, *PPOINTER_TYPE_INFO;
		[PInvokeData("winuser.h", MSDNShortId = "5EA8012C-CF0C-4771-9A9C-A9DC218DC9AB")]
		[StructLayout(LayoutKind.Explicit)]
		public struct POINTER_TYPE_INFO
		{
			/// <summary>The pointer input device.</summary>
			[FieldOffset(0)]
			public POINTER_INPUT_TYPE type;

			/// <summary>Basic touch information common to all pointer types.</summary>
			[FieldOffset(4)]
			public POINTER_TOUCH_INFO touchInfo;

			/// <summary>Basic pen information common to all pointer types.</summary>
			[FieldOffset(4)]
			public POINTER_PEN_INFO penInfo;
		}

		/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="HSYNTHETICPOINTERDEVICE"/> that is disposed using <see cref="DestroySyntheticPointerDevice"/>.</summary>
		public class SafeHSYNTHETICPOINTERDEVICE : SafeHANDLE
		{
			/// <summary>Initializes a new instance of the <see cref="SafeHSYNTHETICPOINTERDEVICE"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafeHSYNTHETICPOINTERDEVICE(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="SafeHSYNTHETICPOINTERDEVICE"/> class.</summary>
			private SafeHSYNTHETICPOINTERDEVICE() : base() { }

			/// <summary>Performs an implicit conversion from <see cref="SafeHSYNTHETICPOINTERDEVICE"/> to <see cref="HSYNTHETICPOINTERDEVICE"/>.</summary>
			/// <param name="h">The safe handle instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator HSYNTHETICPOINTERDEVICE(SafeHSYNTHETICPOINTERDEVICE h) => h.handle;

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() { DestroySyntheticPointerDevice(handle); return true; }
		}

		/*
		GET_POINTERID_WPARAM macro
		HAS_POINTER_CONFIDENCE_WPARAM macro
		IS_POINTER_CANCELED_WPARAM macro
		IS_POINTER_FIFTHBUTTON_WPARAM macro
		IS_POINTER_FIRSTBUTTON_WPARAM macro
		IS_POINTER_FLAG_SET_WPARAM macro
		IS_POINTER_FOURTHBUTTON_WPARAM macro
		IS_POINTER_INCONTACT_WPARAM macro
		IS_POINTER_INRANGE_WPARAM macro
		IS_POINTER_NEW_WPARAM macro
		IS_POINTER_SECONDBUTTON_WPARAM macro
		IS_POINTER_THIRDBUTTON_WPARAM macro
		*/
	}
}