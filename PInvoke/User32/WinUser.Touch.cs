using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class User32
	{
		/// <summary>Gesture configurations used by <see cref="GESTURECONFIG"/>.</summary>
		[Flags]
		public enum GC
		{
			/// <summary>Indicates all of the gestures.</summary>
			GC_ALLGESTURES = 0x00000001,

			/// <summary>Indicates the zoom gesture.</summary>
			GC_ZOOM = 0x00000001,

			/// <summary>Indicates all pan gestures.</summary>
			GC_PAN = 0x00000001,

			/// <summary>Indicates vertical pans with one finger.</summary>
			GC_PAN_WITH_SINGLE_FINGER_VERTICALLY = 0x00000002,

			/// <summary>Indicates horizontal pans with one finger.</summary>
			GC_PAN_WITH_SINGLE_FINGER_HORIZONTALLY = 0x00000004,

			/// <summary>Limits perpendicular movement to primary direction until a threshold is reached to break out of the gutter.</summary>
			GC_PAN_WITH_GUTTER = 0x00000008,

			/// <summary>Indicates panning with inertia to smoothly slow when pan gestures stop.</summary>
			GC_PAN_WITH_INERTIA = 0x00000010,

			/// <summary>Indicates the rotation gesture.</summary>
			GC_ROTATE = 0x00000001,

			/// <summary>Indicates the two-finger tap gesture.</summary>
			GC_TWOFINGERTAP = 0x00000001,

			/// <summary>Indicates the press and tap gesture.</summary>
			GC_PRESSANDTAP = 0x00000001,

			/// <summary>Indicates the press and tap gesture.</summary>
			GC_ROLLOVER = GC_PRESSANDTAP,
		}

		/// <summary>Flags for <see cref="GetGestureConfig"/>.</summary>
		[PInvokeData("winuser.h", MSDNShortId = "8b7a594c-e9e4-4215-8946-da170c957a2b")]
		[Flags]
		public enum GCF
		{
			/// <summary>
			/// If specified, GetGestureConfig returns consolidated configuration for the specified window and its parent window chain.
			/// </summary>
			GCF_INCLUDE_ANCESTORS = 0x00000001
		}

		/// <summary>Flags used by <see cref="GESTUREINFO"/>.</summary>
		[PInvokeData("winuser.h", MSDNShortId = "f5b8b530-ff1e-4d78-a12f-86990fe9ac88")]
		[Flags]
		public enum GF
		{
			/// <summary>A gesture is starting.</summary>
			GF_BEGIN = 0x00000001,

			/// <summary>A gesture has triggered inertia.</summary>
			GF_INERTIA = 0x00000002,

			/// <summary>A gesture is ending.</summary>
			GF_END = 0x00000004,
		}

		/// <summary>Gesture IDs used by <see cref="GESTURECONFIG"/> and <see cref="GESTUREINFO"/>.</summary>
		public enum GID
		{
			/// <summary>Indicates a generic gesture is beginning.</summary>
			GID_BEGIN = 1,

			/// <summary>Indicates a generic gesture end.</summary>
			GID_END = 2,

			/// <summary>Indicates configuration settings for the zoom gesture.</summary>
			GID_ZOOM = 3,

			/// <summary>Indicates the pan gesture.</summary>
			GID_PAN = 4,

			/// <summary>Indicates the rotation gesture.</summary>
			GID_ROTATE = 5,

			/// <summary>Indicates the two-finger tap gesture.</summary>
			GID_TWOFINGERTAP = 6,

			/// <summary>Indicates the press and tap gesture.</summary>
			GID_PRESSANDTAP = 7,

			/// <summary>Indicates the press and tap gesture.</summary>
			GID_ROLLOVER = GID_PRESSANDTAP,
		}

		/// <summary> Flags for <see cref="InitializeTouchInjection"/>. </summary>
		[PInvokeData("winuser.h", MSDNShortId = "79cc2a05-d8ee-4d87-9c7b-fa7d5354b04f")]
		public enum TOUCH_FEEDBACK
		{
			/// <summary>Specifies default touch visualizations.</summary>
			TOUCH_FEEDBACK_DEFAULT = 0x1,

			/// <summary>Specifies indirect touch visualizations.</summary>
			TOUCH_FEEDBACK_INDIRECT = 0x2,

			/// <summary>Specifies no touch visualizations.</summary>
			TOUCH_FEEDBACK_NONE = 0x3,
		}

		/// <summary>Flags for <see cref="RegisterTouchHitTestingWindow"/></summary>
		[PInvokeData("winuser.h", MSDNShortId = "52e48cea-b5c7-405f-8df6-26052304b62c")]
		public enum TOUCH_HIT_TESTING
		{
			/// <summary>The touch hit testing default</summary>
			TOUCH_HIT_TESTING_DEFAULT = 0x0,

			/// <summary>The touch hit testing client</summary>
			TOUCH_HIT_TESTING_CLIENT = 0x1,

			/// <summary>The touch hit testing none</summary>
			TOUCH_HIT_TESTING_NONE = 0x2
		}

		/// <summary>Flags used by <see cref="TOUCHINPUT"/>.</summary>
		[PInvokeData("winuser.h", MSDNShortId = "fc382759-3a1e-401e-a6a7-1bf209a5434b")]
		[Flags]
		public enum TOUCHEVENTF
		{
			/// <summary>Movement has occurred. Cannot be combined with TOUCHEVENTF_DOWN.</summary>
			TOUCHEVENTF_MOVE = 0x0001,

			/// <summary>
			/// The corresponding touch point was established through a new contact. Cannot be combined with TOUCHEVENTF_MOVE or TOUCHEVENTF_UP.
			/// </summary>
			TOUCHEVENTF_DOWN = 0x0002,

			/// <summary>A touch point was removed.</summary>
			TOUCHEVENTF_UP = 0x0004,

			/// <summary>
			/// A touch point is in range. This flag is used to enable touch hover support on compatible hardware. Applications that do not
			/// want support for hover can ignore this flag.
			/// </summary>
			TOUCHEVENTF_INRANGE = 0x0008,

			/// <summary>
			/// Indicates that this TOUCHINPUT structure corresponds to a primary contact point. See the following text for more information
			/// on primary touch points.
			/// </summary>
			TOUCHEVENTF_PRIMARY = 0x0010,

			/// <summary>When received using GetTouchInputInfo, this input was not coalesced.</summary>
			TOUCHEVENTF_NOCOALESCE = 0x0020,

			/// <summary>The touch event came from a pen.</summary>
			TOUCHEVENTF_PEN = 0x0040,

			/// <summary>The touch event came from the user's palm.</summary>
			TOUCHEVENTF_PALM = 0x0080,
		}

		/// <summary>Masks used by <see cref="TOUCHINPUT"/>.</summary>
		[PInvokeData("winuser.h", MSDNShortId = "fc382759-3a1e-401e-a6a7-1bf209a5434b")]
		[Flags]
		public enum TOUCHINPUTMASKF
		{
			/// <summary>The system time was set in the TOUCHINPUT structure.</summary>
			TOUCHINPUTMASKF_TIMEFROMSYSTEM = 0x0001,

			/// <summary>dwExtraInfo is valid.</summary>
			TOUCHINPUTMASKF_EXTRAINFO = 0x0002,

			/// <summary>cxContact and cyContact are valid. See the following text for more information on primary touch points.</summary>
			TOUCHINPUTMASKF_CONTACTAREA = 0x0004,
		}

		/// <summary>Flags used by <see cref="IsTouchWindow"/>.</summary>
		[Flags]
		public enum TWF
		{
			/// <summary>Specifies that hWnd prefers non-coalesced touch input.</summary>
			TWF_FINETOUCH = 0x00000001,

			/// <summary>
			/// Clearing this flag disables palm rejection which reduces delays for getting WM_TOUCH messages. This is useful if you want as
			/// quick of a response as possible when a user touches your application. Setting this flag enables palm detection and will
			/// prevent some WM_TOUCH messages from being sent to your application. This is useful if you do not want to receive WM_TOUCH
			/// messages that are from palm contact.
			/// </summary>
			TWF_WANTPALM = 0x00000002
		}

		/// <summary>Closes resources associated with a gesture information handle.</summary>
		/// <param name="hGestureInfo">The gesture information handle.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, use the GetLastError function.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If an application processes a WM_GESTURE message, it is responsible for closing the handle using this function. Failure to do so
		/// may result in process memory leaks.
		/// </para>
		/// <para>
		/// If the message is passed to DefWindowProc, or is forwarded using one of the PostMessage or SendMessage classes of API functions,
		/// the handle is transferred with the message and need not be closed by the application.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following code shows a handler that closes the GESTUREINFO handle if the gesture has been handled.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-closegestureinfohandle BOOL CloseGestureInfoHandle(
		// HGESTUREINFO hGestureInfo );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "f2bf98b2-a4f7-4b63-b9ae-b2534415cb4b")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CloseGestureInfoHandle(HGESTUREINFO hGestureInfo);

		/// <summary>Closes a touch input handle, frees process memory associated with it, and invalidates the handle.</summary>
		/// <param name="hTouchInput">
		/// The touch input handle received in the <c>LPARAM</c> of a touch message. The function fails with <c>ERROR_INVALID_HANDLE</c> if
		/// this handle is not valid. Note that the handle is not valid after it has been used in a successful call to
		/// <c>CloseTouchInputHandle</c> or after it has been passed to DefWindowProc, PostMessage, SendMessage or one of their variants.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, use the GetLastError function.</para>
		/// </returns>
		/// <remarks>
		/// Calling <c>CloseTouchInputHandle</c> will not free memory associated with values retrieved in a call to GetTouchInputInfo. Values
		/// in structures passed to <c>GetTouchInputInfo</c> will be valid until you delete them.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-closetouchinputhandle BOOL CloseTouchInputHandle(
		// HTOUCHINPUT hTouchInput );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "bdc8bb94-3126-4183-9dfd-ba4844d98f29")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CloseTouchInputHandle(HTOUCHINPUT hTouchInput);

		/// <summary>
		/// Returns the score of a polygon as the probable touch target (compared to all other polygons that intersect the touch contact
		/// area) and an adjusted touch point within the polygon.
		/// </summary>
		/// <param name="numVertices">
		/// <para>The number of vertices in the polygon. This value must be greater than or equal to 3.</para>
		/// <para>This value indicates the size of the array, as specified by the controlPolygon parameter.</para>
		/// </param>
		/// <param name="controlPolygon">
		/// <para>The array of x-y screen coordinates that define the shape of the UI element.</para>
		/// <para>The numVertices parameter specifies the number of coordinates.</para>
		/// </param>
		/// <param name="pHitTestingInput">The TOUCH_HIT_TESTING_INPUT structure that holds the data for the touch contact area.</param>
		/// <param name="pProximityEval">
		/// The TOUCH_HIT_TESTING_PROXIMITY_EVALUATION structure that holds the score and adjusted touch-point data.
		/// </param>
		/// <returns>
		/// <para>If this function succeeds, it returns TRUE.</para>
		/// <para>Otherwise, it returns FALSE. To retrieve extended error information, call the GetLastError function.</para>
		/// </returns>
		/// <remarks>
		/// <para>For consistency with Windows, frameworks that handle WM_TOUCHHITTESTING should use the following principles for targeting:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Inclusion: If the touch point is within the boundaries of a control, the touch point is not changed.</term>
		/// </item>
		/// <item>
		/// <term>Intersection: Include only controls that intersect the contact geometry.</term>
		/// </item>
		/// <item>
		/// <term>
		/// Z-order: If more than one control intersects the contact geometry, and the controls overlap, the control that's highest in the
		/// z-order receives priority.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// Ambiguity: If more than one control intersects the contact geometry, and the controls don't overlap, the control that's closest
		/// to the original touch point receives priority.
		/// </term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-evaluateproximitytopolygon BOOL
		// EvaluateProximityToPolygon( UINT32 numVertices, const POINT *controlPolygon, const TOUCH_HIT_TESTING_INPUT *pHitTestingInput,
		// TOUCH_HIT_TESTING_PROXIMITY_EVALUATION *pProximityEval );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "443d12f2-9f26-4e1e-9bf3-cd97b4026399")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool EvaluateProximityToPolygon(uint numVertices, [In] POINT[] controlPolygon, in TOUCH_HIT_TESTING_INPUT pHitTestingInput, out TOUCH_HIT_TESTING_PROXIMITY_EVALUATION pProximityEval);

		/// <summary>
		/// Returns the score of a rectangle as the probable touch target, compared to all other rectangles that intersect the touch contact
		/// area, and an adjusted touch point within the rectangle.
		/// </summary>
		/// <param name="controlBoundingBox">The RECT structure that defines the bounding box of the UI element.</param>
		/// <param name="pHitTestingInput">The TOUCH_HIT_TESTING_INPUT structure that holds the data for the touch contact area.</param>
		/// <param name="pProximityEval">
		/// The TOUCH_HIT_TESTING_PROXIMITY_EVALUATION structure that holds the score and adjusted touch-point data.
		/// </param>
		/// <returns>
		/// <para>If this function succeeds, it returns TRUE.</para>
		/// <para>Otherwise, it returns FALSE. To retrieve extended error information, call the GetLastError function.</para>
		/// </returns>
		/// <remarks>
		/// <para>For consistency with Windows, frameworks that handle WM_TOUCHHITTESTING should use the following principles for targeting:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Inclusion: If the touch point is within the boundaries of a control, the touch point is not changed.</term>
		/// </item>
		/// <item>
		/// <term>Intersection: Include only controls that intersect the contact geometry.</term>
		/// </item>
		/// <item>
		/// <term>
		/// Z-order: If more than one control intersects the contact geometry, and the controls overlap, the control that's highest in the
		/// z-order receives priority.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// Ambiguity: If more than one control intersects the contact geometry, and the controls don't overlap, the control that's closest
		/// to the original touch point receives priority.
		/// </term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-evaluateproximitytorect BOOL EvaluateProximityToRect(
		// const RECT *controlBoundingBox, const TOUCH_HIT_TESTING_INPUT *pHitTestingInput, TOUCH_HIT_TESTING_PROXIMITY_EVALUATION
		// *pProximityEval );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "269ef4c1-9c9f-4bd7-9852-e82c4a707d3c")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool EvaluateProximityToRect(in RECT controlBoundingBox, in TOUCH_HIT_TESTING_INPUT pHitTestingInput, out TOUCH_HIT_TESTING_PROXIMITY_EVALUATION pProximityEval);

		/// <summary>Retrieves the configuration for which Windows Touch gesture messages are sent from a window.</summary>
		/// <param name="hwnd">A handle to the window to get the gesture configuration from.</param>
		/// <param name="dwReserved">This value is reserved and must be set to 0.</param>
		/// <param name="dwFlags">
		/// A gesture command flag value indicating options for retrieving the gesture configuration. See Remarks for additional information
		/// and supported values.
		/// </param>
		/// <param name="pcIDs">The size, in number of gesture configuration structures, that is in the pGestureConfig buffer.</param>
		/// <param name="pGestureConfig">An array of gesture configuration structures that specify the gesture configuration.</param>
		/// <param name="cbSize">The size of the gesture configuration (GESTURECONFIG) structure.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, use the GetLastError function.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Passing a value other than <c>sizeof(GESTURECONFIG)</c> for the cbSize parameter will cause calls to this function to fail and
		/// GetLastError will return <c>ERROR_INVALID_PARAMETER</c> (87 in decimal).
		/// </para>
		/// <para>The following table lists the gesture configuration values:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Name</term>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>GCF_INCLUDE_ANCESTORS</term>
		/// <term>0x00000001</term>
		/// <term>If specified, GetGestureConfig returns consolidated configuration for the specified window and its parent window chain.</term>
		/// </item>
		/// </list>
		/// <para>Examples</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getgestureconfig BOOL GetGestureConfig( HWND hwnd, DWORD
		// dwReserved, DWORD dwFlags, PUINT pcIDs, PGESTURECONFIG pGestureConfig, UINT cbSize );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "8b7a594c-e9e4-4215-8946-da170c957a2b")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetGestureConfig(HWND hwnd, [Optional] uint dwReserved, GCF dwFlags, ref uint pcIDs, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] GESTURECONFIG[] pGestureConfig, [In] uint cbSize);

		/// <summary>Retrieves additional information about a gesture from its GESTUREINFO handle.</summary>
		/// <param name="hGestureInfo">The handle to the gesture information that is passed in the lParam of a WM_GESTURE message.</param>
		/// <param name="cbExtraArgs">A count of the bytes of data stored in the extra arguments.</param>
		/// <param name="pExtraArgs">A pointer to the extra argument information.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, use the GetLastError function.</para>
		/// </returns>
		/// <remarks>
		/// This function is reserved for future use and should only be used for testing. Windows 7 gestures do not use extra arguments.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getgestureextraargs BOOL GetGestureExtraArgs( HGESTUREINFO
		// hGestureInfo, UINT cbExtraArgs, PBYTE pExtraArgs );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "f7775d88-6a5b-4283-ab40-65c2da218f81")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetGestureExtraArgs(HGESTUREINFO hGestureInfo, uint cbExtraArgs, IntPtr pExtraArgs);

		/// <summary>Retrieves a GESTUREINFO structure given a handle to the gesture information.</summary>
		/// <param name="hGestureInfo">The gesture information handle.</param>
		/// <param name="pGestureInfo">A pointer to the gesture information structure.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, use the GetLastError function.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>cbSize</c> member of the GESTUREINFO structure passed in to the function must be set before the function is called.
		/// Otherwise, calls to GetLastError will return <c>ERROR_INVALID_PARAMETER</c> (87 in decimal). If an application processes a
		/// WM_GESTURE message, it is responsible for closing the handle using CloseGestureInfoHandle. Failure to do so may result in process
		/// memory leaks.
		/// </para>
		/// <para>
		/// If the message is passed to DefWindowProc, or is forwarded using one of the PostMessage or SendMessage classes of API functions,
		/// the handle is transferred with the message and need not be closed by the application.
		/// </para>
		/// <para>Examples</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-getgestureinfo BOOL GetGestureInfo( HGESTUREINFO
		// hGestureInfo, PGESTUREINFO pGestureInfo );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "407ed585-09aa-4174-8907-8bb9590f1795")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetGestureInfo(HGESTUREINFO hGestureInfo, ref GESTUREINFO pGestureInfo);

		/// <summary>Retrieves detailed information about touch inputs associated with a particular touch input handle.</summary>
		/// <param name="hTouchInput">
		/// The touch input handle received in the <c>LPARAM</c> of a touch message. The function fails with <c>ERROR_INVALID_HANDLE</c> if
		/// this handle is not valid. Note that the handle is not valid after it has been used in a successful call to CloseTouchInputHandle
		/// or after it has been passed to DefWindowProc, PostMessage, SendMessage or one of their variants.
		/// </param>
		/// <param name="cInputs">
		/// The number of structures in the pInputs array. This should ideally be at least equal to the number of touch points associated
		/// with the message as indicated in the message <c>WPARAM</c>. If cInputs is less than the number of touch points, the function will
		/// still succeed and populate the pInputs buffer with information about cInputs touch points.
		/// </param>
		/// <param name="pInputs">
		/// A pointer to an array of TOUCHINPUT structures to receive information about the touch points associated with the specified touch
		/// input handle.
		/// </param>
		/// <param name="cbSize">
		/// The size, in bytes, of a single TOUCHINPUT structure. If cbSize is not the size of a single <c>TOUCHINPUT</c> structure, the
		/// function fails with <c>ERROR_INVALID_PARAMETER</c>.
		/// </param>
		/// <returns>
		/// If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error
		/// information, use the GetLastError function.
		/// </returns>
		/// <remarks>
		/// Calling CloseTouchInputHandle will not free memory associated with values retrieved in a call to <c>GetTouchInputInfo</c>. Values
		/// in structures passed to <c>GetTouchInputInfo</c> will be valid until you delete them.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-gettouchinputinfo BOOL GetTouchInputInfo( HTOUCHINPUT
		// hTouchInput, UINT cInputs, PTOUCHINPUT pInputs, int cbSize );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "18caab11-9c22-46ac-b89f-dd3e662bea1e")]
		[return: MarshalAs(UnmanagedType.Bool)] public static extern bool GetTouchInputInfo(HTOUCHINPUT hTouchInput, uint cInputs, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] TOUCHINPUT[] pInputs, int cbSize);

		/// <summary>
		/// The <c>GID_ROTATE_ANGLE_FROM_ARGUMENT</c> macro is used to interpret the <c>GID_ROTATE</c> ullArgument value when receiving the
		/// value in the WM_GESTURE structure.
		/// </summary>
		/// <param name="arg">A value from a WM_GESTURE message.</param>
		/// <returns>The angle of rotation as a double in radians.</returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-gid_rotate_angle_from_argument void
		// GID_ROTATE_ANGLE_FROM_ARGUMENT( _arg_ );
		[PInvokeData("winuser.h", MSDNShortId = "8967e870-b444-402e-a343-9ac427ce1f07")]
		public static double GID_ROTATE_ANGLE_FROM_ARGUMENT(ulong arg) => (double)arg / ushort.MaxValue * 4.0 * Math.PI - 2.0 * Math.PI;

		/// <summary>Converts a radian value to an argument for rotation gesture messages.</summary>
		/// <param name="arg">The angle of rotation as a double in radians.</param>
		/// <returns>Value to pass to WM_GESTURE.</returns>
		/// <remarks><c>Note</c> The macro assumes that the input value for the radian value is between -2*pi and 2*pi.</remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-gid_rotate_angle_to_argument void
		// GID_ROTATE_ANGLE_TO_ARGUMENT( _arg_ );
		[PInvokeData("winuser.h", MSDNShortId = "058c914e-82c7-40f9-8d0d-2a6a8e77cee0")]
		public static ushort GID_ROTATE_ANGLE_TO_ARGUMENT(double arg) => (ushort)((arg + 2.0 * Math.PI) / (4.0 * Math.PI) * ushort.MaxValue);

		/// <summary>
		/// Configures the touch injection context for the calling application and initializes the maximum number of simultaneous contacts
		/// that the app can inject.
		/// </summary>
		/// <param name="maxCount">
		/// <para>The maximum number of touch contacts.</para>
		/// <para>The maxCount parameter must be greater than 0 and less than or equal to MAX_TOUCH_COUNT (256) as defined in winuser.h.</para>
		/// </param>
		/// <param name="dwMode">
		/// <para>The contact visualization mode.</para>
		/// <para>The dwMode parameter must be TOUCH_FEEDBACK_DEFAULT, <c>TOUCH_FEEDBACK_INDIRECT</c>, or <c>TOUCH_FEEDBACK_NONE</c>.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is TRUE.</para>
		/// <para>If the function fails, the return value is FALSE. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If TOUCH_FEEDBACK_DEFAULT is set, the injected touch feedback may get suppressed by the end-user settings in the <c>Pen and
		/// Touch</c> control panel.
		/// </para>
		/// <para>
		/// If TOUCH_FEEDBACK_INDIRECT is set, the injected touch feedback overrides the end-user settings in the <c>Pen and Touch</c>
		/// control panel.
		/// </para>
		/// <para>
		/// If TOUCH_FEEDBACK_INDIRECT or <c>TOUCH_FEEDBACK_NONE</c> are set, touch feedback provided by applications and controls may not be affected.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-initializetouchinjection BOOL InitializeTouchInjection(
		// UINT32 maxCount, DWORD dwMode );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "79cc2a05-d8ee-4d87-9c7b-fa7d5354b04f")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool InitializeTouchInjection(uint maxCount, TOUCH_FEEDBACK dwMode);

		/// <summary>Simulates touch input.</summary>
		/// <param name="count">
		/// <para>The size of the array in contacts.</para>
		/// <para>The maximum value for count is specified by the maxCount parameter of the InitializeTouchInjection function.</para>
		/// </param>
		/// <param name="contacts">
		/// Array of POINTER_TOUCH_INFO structures that represents all contacts on the desktop. The screen coordinates of each contact must
		/// be within the bounds of the desktop.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is non-zero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
		/// </returns>
		/// <remarks>
		/// <para>The injected input is sent to the desktop of the session where the injection process is running.</para>
		/// <para>
		/// There are two input states for touch input injection (interactive and hover) that are indicated by the following combinations of
		/// <c>pointerFlags</c> in contacts:
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>pointerFlags (POINTER_FLAG_*)</term>
		/// <term>Status</term>
		/// </listheader>
		/// <item>
		/// <term>INRANGE | UPDATE</term>
		/// <term>Touch hover starts or moves</term>
		/// </item>
		/// <item>
		/// <term>INRANGE | INCONTACT | DOWN</term>
		/// <term>Touch contact down</term>
		/// </item>
		/// <item>
		/// <term>INRANGE | INCONTACT | UPDATE</term>
		/// <term>Touch contact moves</term>
		/// </item>
		/// <item>
		/// <term>INRANGE | UP</term>
		/// <term>Touch contact up and transition to hover</term>
		/// </item>
		/// <item>
		/// <term>UPDATE</term>
		/// <term>Touch hover ends</term>
		/// </item>
		/// <item>
		/// <term>UP</term>
		/// <term>Touch ends</term>
		/// </item>
		/// </list>
		/// <para>
		/// <c>Note</c> Interactive state represents a touch contact that is on-screen and able to interact with any touch-capable app. Hover
		/// state represents touch input that is not in contact with the screen and cannot interact with applications. Touch injection can
		/// start in hover or interactive state, but the state can only transition through INRANGE | INCONTACT | DOWN for hover to
		/// interactive state, or through INRANGE | UP for interactive to hover state.
		/// </para>
		/// <para>All touch injection sequences end with either UPDATE or UP.</para>
		/// <para>
		/// The following diagram demonstrates a touch injection sequence that starts with a hover state, transitions to interactive, and
		/// concludes with hover.
		/// </para>
		/// <para>
		/// For press and hold gestures, multiple frames must be sent to ensure input is not cancelled. For a press and hold at point (x,y),
		/// send WM_POINTERDOWN at point (x,y) followed by WM_POINTERUPDATE messages at point(x,y).
		/// </para>
		/// <para>
		/// Listen for WM_DISPLAYCHANGE to handle changes to display resolution and orientation and manage screen coordinate updates. All
		/// active contacts are cancelled when a <c>WM_DISPLAYCHANGE</c> is received.
		/// </para>
		/// <para>
		/// Cancel individual contacts by setting POINTER_FLAG_CANCELED with POINTER_FLAG_UP or POINTER_FLAG_UPDATE. Cancelling touch
		/// injection without POINTER_FLAG_UP or POINTER_FLAG_UPDATE invalidates the injection.
		/// </para>
		/// <para>
		/// When POINTER_FLAG_UP is set, ptPixelLocation of POINTER_INFO should be the same as the value of the previous touch injection
		/// frame with POINTER_FLAG_UPDATE. Otherwise, the injection fails with ERROR_INVALID_PARAMETER and all active injection contacts are
		/// cancelled. The system modifies the ptPixelLocation of the WM_POINTERUP event as it cancels the injection.
		/// </para>
		/// <para>
		/// The input timestamp can be specified in either the dwTime or PerformanceCount field of POINTER_INFO. The value cannot be more
		/// recent than the current tick count or QueryPerformanceCounter value of the injection thread. Once a frame is injected with a
		/// timestamp, all subsequent frames must include a timestamp until all contacts in the frame go to the UP state. The custom
		/// timestamp value must be provided for the first element in the contacts array. The timestamp values after the first element are
		/// ignored. The custom timestamp value must increment in every injection frame.
		/// </para>
		/// <para>
		/// When a PerformanceCount field is specified, the timestamp is converted into current time in .1 millisecond resolution upon actual
		/// injection. If a custom PerformanceCount resulted in the same .1 millisecond window from previous injection, the API will return
		/// an error (ERROR_NOT_READY) and will not inject the data. While injection is not immediately invalidated by the error, next
		/// successful injection must have PerformanceCount value that is at least 0.1 milliseconds apart from the previously successful
		/// injection. Similarly a custom dwTime value must be at least 1 millisecond apart if the field was used.
		/// </para>
		/// <para>
		/// If both dwTime and PerformanceCount are specified in the injection parameter, InjectTouchInput fails with an Error Code
		/// (ERROR_INVALID_PARAMETER). Once the injection application starts with either a dwTime or PerformanceCount parameter, the
		/// timestamp field must be filled correctly. Injection cannot switch the custom timestamp field from one to another once the
		/// injection sequence has started.
		/// </para>
		/// <para>
		/// When neither dwTime or PerformanceCount values are specified, the InjectTouchInput allocates the timestamp based on the timing of
		/// the API call. If the calls are less than 0.1 millisecond apart, the API may return an error (ERROR_NOT_READY). The error will not
		/// invalidate the input immediately, but the injection application needs to retry the same frame again to ensure injection is successful.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-injecttouchinput BOOL InjectTouchInput( UINT32 count,
		// const POINTER_TOUCH_INFO *contacts );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "c3c1425e-2af6-4ecb-a0b2-a456654f7a53")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool InjectTouchInput(uint count, [In] POINTER_TOUCH_INFO[] contacts);

		/// <summary>
		/// Checks whether a specified window is touch-capable and, optionally, retrieves the modifier flags set for the window's touch capability.
		/// </summary>
		/// <param name="hwnd">
		/// The handle of the window. The function fails with <c>ERROR_ACCESS_DENIED</c> if the calling thread is not on the same desktop as
		/// the specified window.
		/// </param>
		/// <param name="pulFlags">
		/// The address of the <c>ULONG</c> variable to receive the modifier flags for the specified window's touch capability.
		/// </param>
		/// <returns>
		/// Returns <c>TRUE</c> if the window supports Windows Touch; returns <c>FALSE</c> if the window does not support Windows Touch.
		/// </returns>
		/// <remarks>
		/// <para>The following table lists the values for the pulFlags output parameter.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Flag</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>TWF_FINETOUCH</term>
		/// <term>Specifies that hWnd prefers non-coalesced touch input.</term>
		/// </item>
		/// <item>
		/// <term>TWF_WANTPALM</term>
		/// <term>
		/// Clearing this flag disables palm rejection which reduces delays for getting WM_TOUCH messages. This is useful if you want as
		/// quick of a response as possible when a user touches your application. Setting this flag enables palm detection and will prevent
		/// some WM_TOUCH messages from being sent to your application. This is useful if you do not want to receive WM_TOUCH messages that
		/// are from palm contact.
		/// </term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-istouchwindow BOOL IsTouchWindow( HWND hwnd, PULONG
		// pulFlags );
		[DllImport(Lib.User32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "080b9d18-5975-4d38-ae3b-151f74120bb3")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool IsTouchWindow(HWND hwnd, out TWF pulFlags);

		/// <summary>
		/// Returns the proximity evaluation score and the adjusted touch-point coordinates as a packed value for the WM_TOUCHHITTESTING callback.
		/// </summary>
		/// <param name="pHitTestingInput">The TOUCH_HIT_TESTING_INPUT structure that holds the data for the touch contact area.</param>
		/// <param name="pProximityEval">
		/// The TOUCH_HIT_TESTING_PROXIMITY_EVALUATION structure that holds the score and adjusted touch-point data that the
		/// EvaluateProximityToPolygon or EvaluateProximityToRect function returns.
		/// </param>
		/// <returns>
		/// If this function succeeds, it returns the <c>score</c> and <c>adjustedPoint</c> values from
		/// TOUCH_HIT_TESTING_PROXIMITY_EVALUATION as an LRESULT. To retrieve extended error information, call the GetLastError function.
		/// </returns>
		/// <remarks>Usually, this is the last function that's called in a WM_TOUCHHITTESTING handler.</remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-packtouchhittestingproximityevaluation LRESULT
		// PackTouchHitTestingProximityEvaluation( const TOUCH_HIT_TESTING_INPUT *pHitTestingInput, const
		// TOUCH_HIT_TESTING_PROXIMITY_EVALUATION *pProximityEval );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "c4061285-2d0f-4404-9b63-bda2ec61b764")]
		public static extern IntPtr PackTouchHitTestingProximityEvaluation(in TOUCH_HIT_TESTING_INPUT pHitTestingInput, out TOUCH_HIT_TESTING_PROXIMITY_EVALUATION pProximityEval);

		/// <summary>
		/// <para>Registers a window to process the</para>
		/// <para>WM_TOUCHHITTESTING notification.</para>
		/// </summary>
		/// <param name="hwnd">The window that receives the WM_TOUCHHITTESTING notification.</param>
		/// <param name="value">
		/// <para>One of the following values:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>TOUCH_HIT_TESTING_CLIENT: Send WM_TOUCHHITTESTING messages to the target window.</term>
		/// </item>
		/// <item>
		/// <term>
		/// TOUCH_HIT_TESTING_DEFAULT: Don't send WM_TOUCHHITTESTING messages to the target window but continue to send the messages to child windows.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TOUCH_HIT_TESTING_NONE: Don't send WM_TOUCHHITTESTING messages to the target window or child windows.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>If this function succeeds, it returns TRUE.</para>
		/// <para>Otherwise, it returns FALSE. To retrieve extended error information, call the GetLastError function.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-registertouchhittestingwindow BOOL
		// RegisterTouchHitTestingWindow( HWND hwnd, ULONG value );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "52e48cea-b5c7-405f-8df6-26052304b62c")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool RegisterTouchHitTestingWindow(HWND hwnd, TOUCH_HIT_TESTING value);

		/// <summary>Registers a window as being touch-capable.</summary>
		/// <param name="hwnd">
		/// The handle of the window being registered. The function fails with <c>ERROR_ACCESS_DENIED</c> if the calling thread does not own
		/// the specified window.
		/// </param>
		/// <param name="ulFlags">
		/// <para>A set of bit flags that specify optional modifications. This field may contain 0 or one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>TWF_FINETOUCH</term>
		/// <term>Specifies that hWnd prefers noncoalesced touch input.</term>
		/// </item>
		/// <item>
		/// <term>TWF_WANTPALM</term>
		/// <term>
		/// Setting this flag disables palm rejection which reduces delays for getting WM_TOUCH messages. This is useful if you want as quick
		/// of a response as possible when a user touches your application. By default, palm detection is enabled and some WM_TOUCH messages
		/// are prevented from being sent to your application. This is useful if you do not want to receive WM_TOUCH messages that are from
		/// palm contact.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, use the GetLastError function.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// <c>Note</c><c>RegisterTouchWindow</c> must be called on every window that will be used for touch input. This means that if you
		/// have an application that has multiple windows within it, <c>RegisterTouchWindow</c> must be called on every window in that
		/// application that uses touch features. Also, an application can call <c>RegisterTouchWindow</c> any number of times for the same
		/// window if it desires to change the modifier flags. A window can be marked as no longer requiring touch input using the
		/// UnregisterTouchWindow function.
		/// </para>
		/// <para>
		/// If <c>TWF_WANTPALM</c> is enabled, packets from touch input are not buffered and palm detection is not performed before the
		/// packets are sent to your application. Enabling <c>TWF_WANTPALM</c> is most useful if you want minimal latencies when processing
		/// WM_TOUCH messages.
		/// </para>
		/// <para>Examples</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-registertouchwindow BOOL RegisterTouchWindow( HWND hwnd,
		// ULONG ulFlags );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "a70a7418-f79d-40c8-9219-3ce38a74da9f")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool RegisterTouchWindow(HWND hwnd, TWF ulFlags);

		/// <summary>Configures the messages that are sent from a window for Windows Touch gestures.</summary>
		/// <param name="hwnd">A handle to the window to set the gesture configuration on.</param>
		/// <param name="dwReserved">This value is reserved and must be set to 0.</param>
		/// <param name="cIDs">A count of the gesture configuration structures that are being passed.</param>
		/// <param name="pGestureConfig">An array of gesture configuration structures that specify the gesture configuration.</param>
		/// <param name="cbSize">The size of the gesture configuration (GESTURECONFIG) structure.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, use the GetLastError function.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If you don't expect to change the gesture configuration, call <c>SetGestureConfig</c> at window creation time. If you want to
		/// dynamically change the gesture configuration, call <c>SetGestureConfig</c> in response to WM_GESTURENOTIFY messages.
		/// </para>
		/// <para>
		/// The following table shows the identifiers for gestures that are supported by the dwID member of the GESTURECONFIG structure. Note
		/// that setting dwID to 0 indicates that global gesture configuration flags are set.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Name</term>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>GID_ZOOM</term>
		/// <term>3</term>
		/// <term>Configuration settings for the zoom gesture.</term>
		/// </item>
		/// <item>
		/// <term>GID_PAN</term>
		/// <term>4</term>
		/// <term>The pan gesture.</term>
		/// </item>
		/// <item>
		/// <term>GID_ROTATE</term>
		/// <term>5</term>
		/// <term>The rotation gesture.</term>
		/// </item>
		/// <item>
		/// <term>GID_TWOFINGERTAP</term>
		/// <term>6</term>
		/// <term>The two-finger tap gesture.</term>
		/// </item>
		/// <item>
		/// <term>GID_PRESSANDTAP</term>
		/// <term>7</term>
		/// <term>The press and tap gesture.</term>
		/// </item>
		/// </list>
		/// <para>The following flags are used when dwID is set to zero.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Name</term>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>GC_ALLGESTURES</term>
		/// <term>0x00000001</term>
		/// <term>All of the gestures.</term>
		/// </item>
		/// </list>
		/// <para>The following flags are used when dwID is set to GID_ZOOM.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Name</term>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>GC_ZOOM</term>
		/// <term>0x00000001</term>
		/// <term>The zoom gesture.</term>
		/// </item>
		/// </list>
		/// <para>The following flags are used when dwID is set to GID_PAN.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Name</term>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>GC_PAN</term>
		/// <term>0x00000001</term>
		/// <term>All pan gestures.</term>
		/// </item>
		/// <item>
		/// <term>GC_PAN_WITH_SINGLE_FINGER_VERTICALLY</term>
		/// <term>0x00000002</term>
		/// <term>Vertical pans with one finger.</term>
		/// </item>
		/// <item>
		/// <term>GC_PAN_WITH_SINGLE_FINGER_HORIZONTALLY</term>
		/// <term>0x00000004</term>
		/// <term>Horizontal pans with one finger.</term>
		/// </item>
		/// <item>
		/// <term>GC_PAN_WITH_GUTTER</term>
		/// <term>0x00000008</term>
		/// <term>
		/// Panning with a gutter boundary around the edges of pannable region. The gutter boundary limits perpendicular movement to a
		/// primary direction until a threshold is reached to break out of the gutter.
		/// </term>
		/// </item>
		/// <item>
		/// <term>GC_PAN_WITH_INTERTIA</term>
		/// <term>0x00000010</term>
		/// <term>Panning with inertia to smoothly slow when pan gestures stop.</term>
		/// </item>
		/// </list>
		/// <para>
		/// <c>Note</c> Pan gestures can be used in conjunction with each other to control behavior. For example, setting the <c>dwWant</c>
		/// bits to panning with single-finger horizontal and setting the <c>dwBlock</c> bits to single-finger vertical will restrict panning
		/// to horizontal pans. Changing the <c>dwWant</c> bit to have and removing single-finger vertical pan from the <c>dwBlock</c> bit
		/// will enable both vertical and horizontal panning.
		/// </para>
		/// <para><c>Note</c> By default, panning has inertia enabled.</para>
		/// <para><c>Note</c> A single call to <c>SetGestureConfig</c> cannot include other GIDs along with 0.</para>
		/// <para>The following flags are used when dwID is set to GID_ROTATE.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Name</term>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>GC_ROTATE</term>
		/// <term>0x00000001</term>
		/// <term>The rotation gesture.</term>
		/// </item>
		/// </list>
		/// <para>The following flags are used when dwID is set to <c>GID_TWOFINGERTAP</c>.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Name</term>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>GC_TWOFINGERTAP</term>
		/// <term>0x00000001</term>
		/// <term>The two-finger tap gesture.</term>
		/// </item>
		/// </list>
		/// <para>The following flags are used when dwID is set to <c>GID_PRESSANDTAP</c>.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Name</term>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>GC_PRESSANDTAP</term>
		/// <term>0x00000001</term>
		/// <term>The press and tap gesture.</term>
		/// </item>
		/// </list>
		/// <para>
		/// <c>Note</c> Calling <c>SetGestureConfig</c> will change the gesture configuration for the lifetime of the Window, not just for
		/// the next gesture.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following example shows how you could receive horizontal and vertical single-finger panning with no gutter and no inertia.
		/// This is a typical configuration for a 2-D navigation application such as the Microsoft PixelSense Globe application.
		/// </para>
		/// <para>
		/// The following example shows how to receive single-finger pan gestures and disable gutter panning. This is a typical configuration
		/// for applications that scroll text such as Notepad.
		/// </para>
		/// <para><c>Note</c> You should explicitly set all the flags that you want enabled or disabled when controlling single-finger panning.</para>
		/// <para>The following example shows how you can disable all gestures.</para>
		/// <para>The following example shows how you could enable all gestures.</para>
		/// <para>The following example shows how you could enable all Windows 7 gestures.</para>
		/// <para>
		/// The following example configuration would set the parent window to enable support for zoom, horizontal pan, and vertical pan
		/// while the child window would just support horizontal pan.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-setgestureconfig BOOL SetGestureConfig( HWND hwnd, DWORD
		// dwReserved, UINT cIDs, PGESTURECONFIG pGestureConfig, UINT cbSize );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "7df5a18e-5e65-4dd5-a59d-853a91ead710")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetGestureConfig(HWND hwnd, [Optional] uint dwReserved, uint cIDs, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] GESTURECONFIG[] pGestureConfig, uint cbSize);

		/// <summary>Converts touch coordinates to pixels.</summary>
		/// <param name="l">The value to be converted from touch coordinates to pixels.</param>
		/// <returns>The pixel value.</returns>
		/// <remarks>
		/// <para>
		/// The <c>TOUCH_COORD_TO_PIXEL</c> macro is used to convert from touch coordinates (currently centipixels) to pixels. Touch
		/// coordinates are finer grained than pixels so that application developers can use subpixel granularity for specialized
		/// applications such as graphic design.
		/// </para>
		/// <para>Examples</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-touch_coord_to_pixel void TOUCH_COORD_TO_PIXEL( l );
		[PInvokeData("winuser.h", MSDNShortId = "719b6800-aeda-424a-86ea-d8c307bd6ad2")]
		public static int TOUCH_COORD_TO_PIXEL(int l) => l / 100;

		/// <summary>Registers a window as no longer being touch-capable.</summary>
		/// <param name="hwnd">
		/// The handle of the window. The function fails with <c>ERROR_ACCESS_DENIED</c> if the calling thread does not own the specified window.
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, the return value is nonzero.</para>
		/// <para>If the function fails, the return value is zero. To get extended error information, use the GetLastError function.</para>
		/// </returns>
		/// <remarks>
		/// The <c>UnregisterTouchWindow</c> function succeeds even if the specified window was not previously registered as being touch-capable.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/nf-winuser-unregistertouchwindow BOOL UnregisterTouchWindow( HWND
		// hwnd );
		[DllImport(Lib.User32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winuser.h", MSDNShortId = "19b83312-b52b-45a5-9595-23d4621c4342")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool UnregisterTouchWindow(HWND hwnd);

		/// <summary>Gets and sets the configuration for enabling gesture messages and the type of this configuration.</summary>
		/// <remarks>
		/// <para>
		/// It is impossible to disable two-finger panning and keep single finger panning. You must set the want bits for GC_PAN before you
		/// can set them for GC_PAN_WITH_SINGLE_FINGER_HORIZONTALLY or GC_PAN_WITH_SINGLE_FINGER_VERTICALLY.
		/// </para>
		/// <para>An inertia vector is included in the GID_PAN message with the GF_END flag if inertia was disabled by a call to SetGestureConfig.</para>
		/// <para>
		/// When you pass this structure, the dwID member contains information for a set of gestures. This determines what the other flags
		/// will mean. If you set flags for pan messages, they will be different from those flags that are set for rotation messages.
		/// </para>
		/// <para>
		/// The following table indicates the various identifiers for gestures that are supported by the dwID member of the
		/// <c>GESTURECONFIG</c> structure. Note that setting dwID to 0 indicates that global gesture configuration flags are set.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Name</term>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>GID_ZOOM</term>
		/// <term>3</term>
		/// <term>Indicates configuration settings for the zoom gesture.</term>
		/// </item>
		/// <item>
		/// <term>GID_PAN</term>
		/// <term>4</term>
		/// <term>Indicates the pan gesture.</term>
		/// </item>
		/// <item>
		/// <term>GID_ROTATE</term>
		/// <term>5</term>
		/// <term>Indicates the rotation gesture.</term>
		/// </item>
		/// <item>
		/// <term>GID_TWOFINGERTAP</term>
		/// <term>6</term>
		/// <term>Indicates the two-finger tap gesture.</term>
		/// </item>
		/// <item>
		/// <term>GID_PRESSANDTAP</term>
		/// <term>7</term>
		/// <term>Indicates the press and tap gesture.</term>
		/// </item>
		/// </list>
		/// <para>The following flags are used when dwID is set to 0.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Name</term>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>GC_ALLGESTURES</term>
		/// <term>0x00000001</term>
		/// <term>Indicates all of the gestures.</term>
		/// </item>
		/// </list>
		/// <para>The following flags are used when dwID is set to GID_ZOOM.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Name</term>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>GC_ZOOM</term>
		/// <term>0x00000001</term>
		/// <term>Indicates the zoom gesture.</term>
		/// </item>
		/// </list>
		/// <para>The following flags are used when dwID is set to GID_PAN.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Name</term>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>GC_PAN</term>
		/// <term>0x00000001</term>
		/// <term>Indicates all pan gestures.</term>
		/// </item>
		/// <item>
		/// <term>GC_PAN_WITH_SINGLE_FINGER_VERTICALLY</term>
		/// <term>0x00000002</term>
		/// <term>Indicates vertical pans with one finger.</term>
		/// </item>
		/// <item>
		/// <term>GC_PAN_WITH_SINGLE_FINGER_HORIZONTALLY</term>
		/// <term>0x00000004</term>
		/// <term>Indicates horizontal pans with one finger.</term>
		/// </item>
		/// <item>
		/// <term>GC_PAN_WITH_GUTTER</term>
		/// <term>0x00000008</term>
		/// <term>Limits perpendicular movement to primary direction until a threshold is reached to break out of the gutter.</term>
		/// </item>
		/// <item>
		/// <term>GC_PAN_WITH_INERTIA</term>
		/// <term>0x00000010</term>
		/// <term>Indicates panning with inertia to smoothly slow when pan gestures stop.</term>
		/// </item>
		/// </list>
		/// <para>
		/// <c>Note</c> Setting the <c>GID_PAN</c> flags in SetGestureConfig will affect the default gesture handler for panning. You should
		/// not have both <c>dwWant</c> and <c>dwBlock</c> set for the same flags; this will result in unexpected behavior. See Windows Touch
		/// Gestures for more information on panning and legacy panning support; see <c>SetGestureConfig</c> for examples of enabling and
		/// blocking gestures.
		/// </para>
		/// <para>The following flags are used when dwID is set to GID_ROTATE.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Name</term>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>GC_ROTATE</term>
		/// <term>0x00000001</term>
		/// <term>Indicates the rotation gesture.</term>
		/// </item>
		/// </list>
		/// <para>The following flags are used when dwID is set to GID_TWOFINGERTAP.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Name</term>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>GC_TWOFINGERTAP</term>
		/// <term>0x00000001</term>
		/// <term>Indicates the two-finger tap gesture.</term>
		/// </item>
		/// </list>
		/// <para>The following flags are used when dwID is set to GID_PRESSANDTAP.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Name</term>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>GC_PRESSANDTAP</term>
		/// <term>0x00000001</term>
		/// <term>Indicates the press and tap gesture.</term>
		/// </item>
		/// </list>
		/// <para>Examples</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ns-winuser-taggestureconfig typedef struct tagGESTURECONFIG { DWORD
		// dwID; DWORD dwWant; DWORD dwBlock; } GESTURECONFIG, *PGESTURECONFIG;
		[PInvokeData("winuser.h", MSDNShortId = "4ec5050e-7fef-4f52-89af-5237e8cdbdb8")]
		[StructLayout(LayoutKind.Sequential)]
		public struct GESTURECONFIG
		{
			/// <summary>
			/// The identifier for the type of configuration that will have messages enabled or disabled. For more information, see Remarks.
			/// </summary>
			public GID dwID;

			/// <summary>The messages to enable.</summary>
			public GC dwWant;

			/// <summary>The messages to disable.</summary>
			public GC dwBlock;

			/// <summary>Initializes a new instance of the <see cref="GESTURECONFIG"/> struct.</summary>
			/// <param name="id">The identifier for the type of configuration that will have messages enabled or disabled.</param>
			public GESTURECONFIG(GID id) : this() => dwID = id;
		}

		/// <summary>Stores information about a gesture.</summary>
		/// <remarks>
		/// <para>The <c>HIDWORD</c> of the <c>ullArguments</c> member is always 0, with the following exceptions:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// For <c>GID_PAN</c>, it is 0 except when there is inertia. When <c>GF_INERTIA</c> is set, the <c>HIDWORD</c> is an inertia vector
		/// (two 16-bit values).
		/// </term>
		/// </item>
		/// <item>
		/// <term>For <c>GID_PRESSANDTAP</c>, it is the distance between the two points.</term>
		/// </item>
		/// </list>
		/// <para>
		/// The <c>GESTUREINFO</c> structure is retrieved by passing the handle to the gesture information structure to the GetGestureInfo function.
		/// </para>
		/// <para>The following flags indicate the various states of the gestures and are stored in <c>dwFlags</c>.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Name</term>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>GF_BEGIN</term>
		/// <term>0x00000001</term>
		/// <term>A gesture is starting.</term>
		/// </item>
		/// <item>
		/// <term>GF_INERTIA</term>
		/// <term>0x00000002</term>
		/// <term>A gesture has triggered inertia.</term>
		/// </item>
		/// <item>
		/// <term>GF_END</term>
		/// <term>0x00000004</term>
		/// <term>A gesture has finished.</term>
		/// </item>
		/// </list>
		/// <para>
		/// <c>Note</c> Most applications should ignore the <c>GID_BEGIN</c> and <c>GID_END</c> messages and pass them to
		/// <c>DefWindowProc</c>. These messages are used by the default gesture handler. Application behavior is undefined when the
		/// <c>GID_BEGIN</c> and <c>GID_END</c> messages are consumed by a third-party application.
		/// </para>
		/// <para>The following table indicates the various identifiers for gestures.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Name</term>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>GID_BEGIN</term>
		/// <term>1</term>
		/// <term>A gesture is starting.</term>
		/// </item>
		/// <item>
		/// <term>GID_END</term>
		/// <term>2</term>
		/// <term>A gesture is ending.</term>
		/// </item>
		/// <item>
		/// <term>GID_ZOOM</term>
		/// <term>3</term>
		/// <term>The zoom gesture.</term>
		/// </item>
		/// <item>
		/// <term>GID_PAN</term>
		/// <term>4</term>
		/// <term>The pan gesture.</term>
		/// </item>
		/// <item>
		/// <term>GID_ROTATE</term>
		/// <term>5</term>
		/// <term>The rotation gesture.</term>
		/// </item>
		/// <item>
		/// <term>GID_TWOFINGERTAP</term>
		/// <term>6</term>
		/// <term>The two-finger tap gesture.</term>
		/// </item>
		/// <item>
		/// <term>GID_PRESSANDTAP</term>
		/// <term>7</term>
		/// <term>The press and tap gesture.</term>
		/// </item>
		/// </list>
		/// <para>
		/// <c>Note</c> The <c>GID_PAN</c> gesture has built-in inertia. At the end of a pan gesture, additional pan gesture messages are
		/// created by the operating system.
		/// </para>
		/// <para>The following type is defined to represent a constant pointer to a <c>GESTUREINFO</c> structure.</para>
		/// <para>Examples</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ns-winuser-taggestureinfo typedef struct tagGESTUREINFO { UINT
		// cbSize; DWORD dwFlags; DWORD dwID; HWND hwndTarget; POINTS ptsLocation; DWORD dwInstanceID; DWORD dwSequenceID; ULONGLONG
		// ullArguments; UINT cbExtraArgs; } GESTUREINFO, *PGESTUREINFO;
		[PInvokeData("winuser.h", MSDNShortId = "f5b8b530-ff1e-4d78-a12f-86990fe9ac88")]
		[StructLayout(LayoutKind.Sequential)]
		public struct GESTUREINFO
		{
			/// <summary>The size of the structure, in bytes. The caller must set this to .</summary>
			public uint cbSize;

			/// <summary>The state of the gesture. For additional information, see Remarks.</summary>
			public GF dwFlags;

			/// <summary>The identifier of the gesture command.</summary>
			public GID dwID;

			/// <summary>A handle to the window that is targeted by this gesture.</summary>
			public HWND hwndTarget;

			/// <summary>
			/// A <c>POINTS</c> structure containing the coordinates associated with the gesture. These coordinates are always relative to
			/// the origin of the screen.
			/// </summary>
			public POINTS ptsLocation;

			/// <summary>An internally used identifier for the structure.</summary>
			public uint dwInstanceID;

			/// <summary>An internally used identifier for the sequence.</summary>
			public uint dwSequenceID;

			/// <summary>A 64-bit unsigned integer that contains the arguments for gestures that fit into 8 bytes.</summary>
			public ulong ullArguments;

			/// <summary>The size, in bytes, of extra arguments that accompany this gesture.</summary>
			public uint cbExtraArgs;

			/// <summary>A default value for <see cref="GESTUREINFO"/> with the <see cref="cbSize"/> field value set correctly.</summary>
			public static readonly GESTUREINFO Default = new GESTUREINFO { cbSize = (uint)Marshal.SizeOf(typeof(GESTUREINFO)) };
		}

		/// <summary>When transmitted with WM_GESTURENOTIFY messages, passes information about a gesture.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ns-winuser-taggesturenotifystruct typedef struct
		// tagGESTURENOTIFYSTRUCT { UINT cbSize; DWORD dwFlags; HWND hwndTarget; POINTS ptsLocation; DWORD dwInstanceID; }
		// GESTURENOTIFYSTRUCT, *PGESTURENOTIFYSTRUCT;
		[PInvokeData("winuser.h", MSDNShortId = "e887c026-9300-4d20-8925-9939a664cd53")]
		[StructLayout(LayoutKind.Sequential)]
		public struct GESTURENOTIFYSTRUCT
		{
			/// <summary>The size of the structure.</summary>
			public uint cbSize;

			/// <summary>Reserved for future use.</summary>
			public uint dwFlags;

			/// <summary>The target window for the gesture notification.</summary>
			public HWND hwndTarget;

			/// <summary>The location of the gesture in physical screen coordinates.</summary>
			public POINTS ptsLocation;

			/// <summary>A specific gesture instance with gesture messages starting with <c>GID_START</c> and ending with <c>GID_END</c>.</summary>
			public uint dwInstanceID;

			/// <summary>A default value for <see cref="GESTURENOTIFYSTRUCT"/> with the <see cref="cbSize"/> field value set correctly.</summary>
			public static readonly GESTURENOTIFYSTRUCT Default = new GESTURENOTIFYSTRUCT { cbSize = (uint)Marshal.SizeOf(typeof(GESTURENOTIFYSTRUCT)) };
		}

		/// <summary>Provides a handle to a gesture info.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct HGESTUREINFO : IHandle
		{
			private IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="HGESTUREINFO"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public HGESTUREINFO(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="HGESTUREINFO"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static HGESTUREINFO NULL => new HGESTUREINFO(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="HGESTUREINFO"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(HGESTUREINFO h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HGESTUREINFO"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator HGESTUREINFO(IntPtr h) => new HGESTUREINFO(h);

			/// <summary>Implements the operator !=.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(HGESTUREINFO h1, HGESTUREINFO h2) => !(h1 == h2);

			/// <summary>Implements the operator ==.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(HGESTUREINFO h1, HGESTUREINFO h2) => h1.Equals(h2);

			/// <inheritdoc/>
			public override bool Equals(object obj) => obj is HGESTUREINFO h ? handle == h.handle : false;

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
		}

		/// <summary>Provides a handle to a touch input.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct HTOUCHINPUT : IHandle
		{
			private IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="HTOUCHINPUT"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public HTOUCHINPUT(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="HTOUCHINPUT"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static HTOUCHINPUT NULL => new HTOUCHINPUT(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="HTOUCHINPUT"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(HTOUCHINPUT h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HTOUCHINPUT"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator HTOUCHINPUT(IntPtr h) => new HTOUCHINPUT(h);

			/// <summary>Implements the operator !=.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(HTOUCHINPUT h1, HTOUCHINPUT h2) => !(h1 == h2);

			/// <summary>Implements the operator ==.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(HTOUCHINPUT h1, HTOUCHINPUT h2) => h1.Equals(h2);

			/// <inheritdoc/>
			public override bool Equals(object obj) => obj is HTOUCHINPUT h ? handle == h.handle : false;

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
		}

		/// <summary>Contains information about the touch contact area reported by the touch digitizer.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ns-winuser-touch_hit_testing_input typedef struct
		// tagTOUCH_HIT_TESTING_INPUT { UINT32 pointerId; POINT point; RECT boundingBox; RECT nonOccludedBoundingBox; UINT32 orientation; }
		// TOUCH_HIT_TESTING_INPUT, *PTOUCH_HIT_TESTING_INPUT;
		[PInvokeData("winuser.h", MSDNShortId = "d2103f6e-6aa9-4260-bef9-cfcbec35e675")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct TOUCH_HIT_TESTING_INPUT
		{
			/// <summary>
			/// The ID of the pointer. You cannot pass this value to the input message process and retrieve additional pointer info through GetPointerInfo.
			/// </summary>
			public uint pointerId;

			/// <summary>The screen coordinates of the touch point that the touch digitizer reports.</summary>
			public POINT point;

			/// <summary>
			/// <para>
			/// The bounding rectangle of the touch contact area. Valid touch targets are identified and scored based on this bounding box.
			/// </para>
			/// <para><c>Note</c> This bounding box may differ from the contact area that the digitizer reports when:</para>
			/// </summary>
			public RECT boundingBox;

			/// <summary>
			/// The touch contact area within a specific targeted window that's not occluded by other objects that are higher in the z-order.
			/// Any area that's occluded by another object is an invalid target.
			/// </summary>
			public RECT nonOccludedBoundingBox;

			/// <summary>The orientation of the touch contact area.</summary>
			public uint orientation;
		}

		/// <summary>
		/// Contains the hit test score that indicates whether the object is the likely target of the touch contact area, relative to other
		/// objects that intersect the touch contact area.
		/// </summary>
		/// <remarks>The EvaluateProximityToRect or EvaluateProximityToPolygon function returns the values.</remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ns-winuser-touch_hit_testing_proximity_evaluation typedef struct
		// tagTOUCH_HIT_TESTING_PROXIMITY_EVALUATION { UINT16 score; POINT adjustedPoint; } TOUCH_HIT_TESTING_PROXIMITY_EVALUATION, *PTOUCH_HIT_TESTING_PROXIMITY_EVALUATION;
		[PInvokeData("winuser.h", MSDNShortId = "a26facc3-fe63-4657-9bd6-821dd89cb11d")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct TOUCH_HIT_TESTING_PROXIMITY_EVALUATION
		{
			/// <summary>The score, compared to the other objects that intersect the touch contact area.</summary>
			public ushort score;

			/// <summary>The adjusted touch point that hits the closest object that's identified by the value of Score.</summary>
			public POINT adjustedPoint;
		}

		/// <summary>Encapsulates data for touch input.</summary>
		/// <remarks>
		/// <para>The following table lists the flags for the <c>dwFlags</c> member.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Flag</term>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>TOUCHEVENTF_MOVE</term>
		/// <term>0x0001</term>
		/// <term>Movement has occurred. Cannot be combined with TOUCHEVENTF_DOWN.</term>
		/// </item>
		/// <item>
		/// <term>TOUCHEVENTF_DOWN</term>
		/// <term>0x0002</term>
		/// <term>The corresponding touch point was established through a new contact. Cannot be combined with TOUCHEVENTF_MOVE or TOUCHEVENTF_UP.</term>
		/// </item>
		/// <item>
		/// <term>TOUCHEVENTF_UP</term>
		/// <term>0x0004</term>
		/// <term>A touch point was removed.</term>
		/// </item>
		/// <item>
		/// <term>TOUCHEVENTF_INRANGE</term>
		/// <term>0x0008</term>
		/// <term>
		/// A touch point is in range. This flag is used to enable touch hover support on compatible hardware. Applications that do not want
		/// support for hover can ignore this flag.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TOUCHEVENTF_PRIMARY</term>
		/// <term>0x0010</term>
		/// <term>
		/// Indicates that this TOUCHINPUT structure corresponds to a primary contact point. See the following text for more information on
		/// primary touch points.
		/// </term>
		/// </item>
		/// <item>
		/// <term>TOUCHEVENTF_NOCOALESCE</term>
		/// <term>0x0020</term>
		/// <term>When received using GetTouchInputInfo, this input was not coalesced.</term>
		/// </item>
		/// <item>
		/// <term>TOUCHEVENTF_PALM</term>
		/// <term>0x0080</term>
		/// <term>The touch event came from the user's palm.</term>
		/// </item>
		/// </list>
		/// <para>
		/// <c>Note</c> If the target hardware on a machine does not support hover, when the <c>TOUCHEVENTF_UP</c> flag is set, the
		/// <c>TOUCHEVENTF_INRANGE</c> flag is cleared. If the target hardware on a machine supports hover, the <c>TOUCHEVENTF_UP</c> and
		/// <c>TOUCHEVENTF_INRANGE</c> flags will be set independently.
		/// </para>
		/// <para>The following table lists the flags for the <c>dwMask</c> member.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Flag</term>
		/// <term>Value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>TOUCHINPUTMASKF_CONTACTAREA</term>
		/// <term>0x0004</term>
		/// <term>cxContact and cyContact are valid. See the following text for more information on primary touch points.</term>
		/// </item>
		/// <item>
		/// <term>TOUCHINPUTMASKF_EXTRAINFO</term>
		/// <term>0x0002</term>
		/// <term>dwExtraInfo is valid.</term>
		/// </item>
		/// <item>
		/// <term>TOUCHINPUTMASKF_TIMEFROMSYSTEM</term>
		/// <term>0x0001</term>
		/// <term>The system time was set in the TOUCHINPUT structure.</term>
		/// </item>
		/// </list>
		/// <para>
		/// A touch point is designated as primary when it is the first touch point to be established from a previous state of no touch
		/// points. The <c>TOUCHEVENTF_PRIMARY</c> flag continues to be set for all subsequent events for the primary touch point until the
		/// primary touch point is released. Note that a <c>TOUCHEVENTF_UP</c> event on the primary touch point does not necessarily
		/// designate the end of a Windows Touch operation; the current Windows Touch operation proceeds from the establishment of the
		/// primary touch point until the last touch point is released.
		/// </para>
		/// <para>
		/// Note that a solitary touch point or, in a set of simultaneous touch points, the first to be detected, is designated the primary.
		/// The system mouse position follows the primary touch point and, in addition to touch messages, also generates
		/// <c>WM_LBUTTONDOWN</c>, <c>WM_MOUSEMOVE</c>, and <c>WM_LBUTTONUP</c> messages in response to actions on a primary touch point. The
		/// primary touch point can also generate <c>WM_RBUTTONDOWN</c> and <c>WM_RBUTTONUP</c> messages using the press and hold gesture.
		/// </para>
		/// <para>
		/// Note that the touch point identifier may be dynamic and is associated with a given touch point only as long as the touch point
		/// persists. If contact is broken and then resumed (for example, if a finger is removed from the surface and then pressed down
		/// again), the same touch point (the same finger, pen, or other such device) may receive a different touch point identifier.
		/// </para>
		/// <para>The following type is defined to represent a constant pointer to a <c>TOUCHINPUT</c> structure.</para>
		/// <para>Examples</para>
		/// <para>
		/// <c>Note</c> In the following example, the pInputs array is not sorted. Use the <c>dwID</c> value to track specific touch points.
		/// </para>
		/// <para>
		/// The following example shows how to get the device information from the <c>hSource</c> member. This example uses GetRawInputDevice
		/// to retrieve information about the device.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winuser/ns-winuser-tagtouchinput typedef struct tagTOUCHINPUT { LONG x; LONG
		// y; HANDLE hSource; DWORD dwID; DWORD dwFlags; DWORD dwMask; DWORD dwTime; ULONG_PTR dwExtraInfo; DWORD cxContact; DWORD cyContact;
		// } TOUCHINPUT, *PTOUCHINPUT;
		[PInvokeData("winuser.h", MSDNShortId = "fc382759-3a1e-401e-a6a7-1bf209a5434b")]
		[StructLayout(LayoutKind.Sequential)]
		public struct TOUCHINPUT
		{
			/// <summary>
			/// The x-coordinate (horizontal point) of the touch input. This member is indicated in hundredths of a pixel of physical screen coordinates.
			/// </summary>
			public int x;

			/// <summary>
			/// The y-coordinate (vertical point) of the touch input. This member is indicated in hundredths of a pixel of physical screen coordinates.
			/// </summary>
			public int y;

			/// <summary>
			/// A device handle for the source input device. Each device is given a unique provider at run time by the touch input provider.
			/// </summary>
			public HANDLE hSource;

			/// <summary>
			/// A touch point identifier that distinguishes a particular touch input. This value stays consistent in a touch contact sequence
			/// from the point a contact comes down until it comes back up. An ID may be reused later for subsequent contacts.
			/// </summary>
			public uint dwID;

			/// <summary>
			/// A set of bit flags that specify various aspects of touch point press, release, and motion. The bits in this member can be any
			/// reasonable combination of the values in the Remarks section.
			/// </summary>
			public TOUCHEVENTF dwFlags;

			/// <summary>
			/// A set of bit flags that specify which of the optional fields in the structure contain valid values. The availability of valid
			/// information in the optional fields is device-specific. Applications should use an optional field value only when the
			/// corresponding bit is set in dwMask. This field may contain a combination of the dwMask flags mentioned in the Remarks section.
			/// </summary>
			public TOUCHINPUTMASKF dwMask;

			/// <summary>
			/// The time stamp for the event, in milliseconds. The consuming application should note that the system performs no validation
			/// on this field; when the <c>TOUCHINPUTMASKF_TIMEFROMSYSTEM</c> flag is not set, the accuracy and sequencing of values in this
			/// field are completely dependent on the touch input provider.
			/// </summary>
			public uint dwTime;

			/// <summary>An additional value associated with the touch event.</summary>
			public UIntPtr dwExtraInfo;

			/// <summary>
			/// The width of the touch contact area in hundredths of a pixel in physical screen coordinates. This value is only valid if the
			/// <c>dwMask</c> member has the <c>TOUCHEVENTFMASK_CONTACTAREA</c> flag set.
			/// </summary>
			public uint cxContact;

			/// <summary>
			/// The height of the touch contact area in hundredths of a pixel in physical screen coordinates. This value is only valid if the
			/// <c>dwMask</c> member has the <c>TOUCHEVENTFMASK_CONTACTAREA</c> flag set.
			/// </summary>
			public uint cyContact;
		}
	}
}