using Accessibility;
using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Vanara.PInvoke
{
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
	public static partial class Oleacc
	{
		// Input to DISPID_ACC_NAVIGATE
		private const int NAVDIR_DOWN = 0x00000002;
		private const int NAVDIR_FIRSTCHILD = 0x00000007;
		private const int NAVDIR_LASTCHILD = 0x00000008;
		private const int NAVDIR_LEFT = 0x00000003;
		private const int NAVDIR_MAX = 0x00000009;
		private const int NAVDIR_MIN = 0x00000000;
		private const int NAVDIR_NEXT = 0x00000005;
		private const int NAVDIR_PREVIOUS = 0x00000006;
		private const int NAVDIR_RIGHT = 0x00000004;
		private const int NAVDIR_UP = 0x00000001;

		// Input to DISPID_ACC_SELECT
		private const int SELFLAG_ADDSELECTION = 0x00000008;
		private const int SELFLAG_EXTENDSELECTION = 0x00000004;
		private const int SELFLAG_NONE = 0x00000000;
		private const int SELFLAG_REMOVESELECTION = 0x00000010;
		private const int SELFLAG_TAKEFOCUS = 0x00000001;
		private const int SELFLAG_TAKESELECTION = 0x00000002;
		private const int SELFLAG_VALID = 0x0000001F;

		public enum AccessibilityRole : uint
		{
			ROLE_SYSTEM_TITLEBAR = 0x00000001,
			ROLE_SYSTEM_MENUBAR = 0x00000002,
			ROLE_SYSTEM_SCROLLBAR = 0x00000003,
			ROLE_SYSTEM_GRIP = 0x00000004,
			ROLE_SYSTEM_SOUND = 0x00000005,
			ROLE_SYSTEM_CURSOR = 0x00000006,
			ROLE_SYSTEM_CARET = 0x00000007,
			ROLE_SYSTEM_ALERT = 0x00000008,
			ROLE_SYSTEM_WINDOW = 0x00000009,
			ROLE_SYSTEM_CLIENT = 0x0000000A,
			ROLE_SYSTEM_MENUPOPUP = 0x0000000B,
			ROLE_SYSTEM_MENUITEM = 0x0000000C,
			ROLE_SYSTEM_TOOLTIP = 0x0000000D,
			ROLE_SYSTEM_APPLICATION = 0x0000000E,
			ROLE_SYSTEM_DOCUMENT = 0x0000000F,
			ROLE_SYSTEM_PANE = 0x00000010,
			ROLE_SYSTEM_CHART = 0x00000011,
			ROLE_SYSTEM_DIALOG = 0x00000012,
			ROLE_SYSTEM_BORDER = 0x00000013,
			ROLE_SYSTEM_GROUPING = 0x00000014,
			ROLE_SYSTEM_SEPARATOR = 0x00000015,
			ROLE_SYSTEM_TOOLBAR = 0x00000016,
			ROLE_SYSTEM_STATUSBAR = 0x00000017,
			ROLE_SYSTEM_TABLE = 0x00000018,
			ROLE_SYSTEM_COLUMNHEADER = 0x00000019,
			ROLE_SYSTEM_ROWHEADER = 0x0000001A,
			ROLE_SYSTEM_COLUMN = 0x0000001B,
			ROLE_SYSTEM_ROW = 0x0000001C,
			ROLE_SYSTEM_CELL = 0x0000001D,
			ROLE_SYSTEM_LINK = 0x0000001E,
			ROLE_SYSTEM_HELPBALLOON = 0x0000001F,
			ROLE_SYSTEM_CHARACTER = 0x00000020,
			ROLE_SYSTEM_LIST = 0x00000021,
			ROLE_SYSTEM_LISTITEM = 0x00000022,
			ROLE_SYSTEM_OUTLINE = 0x00000023,
			ROLE_SYSTEM_OUTLINEITEM = 0x00000024,
			ROLE_SYSTEM_PAGETAB = 0x00000025,
			ROLE_SYSTEM_PROPERTYPAGE = 0x00000026,
			ROLE_SYSTEM_INDICATOR = 0x00000027,
			ROLE_SYSTEM_GRAPHIC = 0x00000028,
			ROLE_SYSTEM_STATICTEXT = 0x00000029,
			ROLE_SYSTEM_TEXT = 0x0000002A,  // Editable, selectable, etc.
			ROLE_SYSTEM_PUSHBUTTON = 0x0000002B,
			ROLE_SYSTEM_CHECKBUTTON = 0x0000002C,
			ROLE_SYSTEM_RADIOBUTTON = 0x0000002D,
			ROLE_SYSTEM_COMBOBOX = 0x0000002E,
			ROLE_SYSTEM_DROPLIST = 0x0000002F,
			ROLE_SYSTEM_PROGRESSBAR = 0x00000030,
			ROLE_SYSTEM_DIAL = 0x00000031,
			ROLE_SYSTEM_HOTKEYFIELD = 0x00000032,
			ROLE_SYSTEM_SLIDER = 0x00000033,
			ROLE_SYSTEM_SPINBUTTON = 0x00000034,
			ROLE_SYSTEM_DIAGRAM = 0x00000035,
			ROLE_SYSTEM_ANIMATION = 0x00000036,
			ROLE_SYSTEM_EQUATION = 0x00000037,
			ROLE_SYSTEM_BUTTONDROPDOWN = 0x00000038,
			ROLE_SYSTEM_BUTTONMENU = 0x00000039,
			ROLE_SYSTEM_BUTTONDROPDOWNGRID = 0x0000003A,
			ROLE_SYSTEM_WHITESPACE = 0x0000003B,
			ROLE_SYSTEM_PAGETABLIST = 0x0000003C,
			ROLE_SYSTEM_CLOCK = 0x0000003D,
			ROLE_SYSTEM_SPLITBUTTON = 0x0000003E,
			ROLE_SYSTEM_IPADDRESS = 0x0000003F,
			ROLE_SYSTEM_OUTLINEBUTTON = 0x00000040,
		}

		[Flags]
		public enum AccessibilityState : uint
		{
			STATE_SYSTEM_NORMAL = 0x00000000,
			STATE_SYSTEM_UNAVAILABLE = 0x00000001,  // Disabled
			STATE_SYSTEM_SELECTED = 0x00000002,
			STATE_SYSTEM_FOCUSED = 0x00000004,
			STATE_SYSTEM_PRESSED = 0x00000008,
			STATE_SYSTEM_CHECKED = 0x00000010,
			STATE_SYSTEM_MIXED = 0x00000020,  // 3-state checkbox or toolbar button
			STATE_SYSTEM_INDETERMINATE = STATE_SYSTEM_MIXED,
			STATE_SYSTEM_READONLY = 0x00000040,
			STATE_SYSTEM_HOTTRACKED = 0x00000080,
			STATE_SYSTEM_DEFAULT = 0x00000100,
			STATE_SYSTEM_EXPANDED = 0x00000200,
			STATE_SYSTEM_COLLAPSED = 0x00000400,
			STATE_SYSTEM_BUSY = 0x00000800,
			STATE_SYSTEM_FLOATING = 0x00001000,  // Children "owned" not "contained" by parent
			STATE_SYSTEM_MARQUEED = 0x00002000,
			STATE_SYSTEM_ANIMATED = 0x00004000,
			STATE_SYSTEM_INVISIBLE = 0x00008000,
			STATE_SYSTEM_OFFSCREEN = 0x00010000,
			STATE_SYSTEM_SIZEABLE = 0x00020000,
			STATE_SYSTEM_MOVEABLE = 0x00040000,
			STATE_SYSTEM_SELFVOICING = 0x00080000,
			STATE_SYSTEM_FOCUSABLE = 0x00100000,
			STATE_SYSTEM_SELECTABLE = 0x00200000,
			STATE_SYSTEM_LINKED = 0x00400000,
			STATE_SYSTEM_TRAVERSED = 0x00800000,
			STATE_SYSTEM_MULTISELECTABLE = 0x01000000,  // Supports multiple selection
			STATE_SYSTEM_EXTSELECTABLE = 0x02000000,  // Supports extended selection
			STATE_SYSTEM_ALERT_LOW = 0x04000000,  // This information is of low priority
			STATE_SYSTEM_ALERT_MEDIUM = 0x08000000,  // This information is of medium priority
			STATE_SYSTEM_ALERT_HIGH = 0x10000000,  // This information is of high priority
			STATE_SYSTEM_PROTECTED = 0x20000000,
			STATE_SYSTEM_VALID = 0x7FFFFFFF,
			STATE_SYSTEM_HASPOPUP = 0x40000000,
		}

		/// <summary>Accessibility running utility states.</summary>
		[PInvokeData("oleacc.h", MSDNShortId = "0AEDDE0D-D8E2-4C9E-AB2B-2FF0ACC3695D")]
		[Flags]
		public enum ANRUS
		{
			/// <summary>The AT application is providing an on-screen keyboard.</summary>
			ANRUS_ON_SCREEN_KEYBOARD_ACTIVE = 0x0000001,

			/// <summary>The AT application is consuming redirected touch input.</summary>
			ANRUS_TOUCH_MODIFICATION_ACTIVE = 0x0000002,

			/// <summary>
			/// The AT application is relying on audio (such as text-to-speech) to convey essential information to the user and should remain
			/// audible over other system sounds.
			/// </summary>
			ANRUS_PRIORITY_AUDIO_ACTIVE = 0x0000004,

			/// <summary>
			/// The AT application is relying on audio (such as text-to-speech) to convey essential information to the user but should not
			/// change relative to other system sounds.
			/// </summary>
			ANRUS_PRIORITY_AUDIO_ACTIVE_NODUCK = 0x0000008,

			/// <summary>Undocumented.</summary>
			ANRUS_PRIORITY_AUDIO_DYNAMIC_DUCK = 0x0000010,
		}

		/// <summary>Retrieves the child ID or IDispatch of each child within an accessible container object.</summary>
		/// <param name="paccContainer">
		/// <para>Type: <c>IAccessible*</c></para>
		/// <para>Pointer to the container object's IAccessible interface.</para>
		/// </param>
		/// <param name="iChildStart">
		/// <para>Type: <c>LONG</c></para>
		/// <para>
		/// Specifies the zero-based index of the first child that is retrieved. This parameter is an index, not a child ID, and it is
		/// usually is set to zero (0).
		/// </para>
		/// </param>
		/// <param name="cChildren">
		/// <para>Type: <c>LONG</c></para>
		/// <para>Specifies the number of children to retrieve. To retrieve the current number of children, an application calls IAccessible::get_accChildCount.</para>
		/// </param>
		/// <param name="rgvarChildren">
		/// <para>Type: <c>VARIANT*</c></para>
		/// <para>
		/// Pointer to an array of VARIANT structures that receives information about the container's children. If the <c>vt</c> member of an
		/// array element is VT_I4, then the <c>lVal</c> member for that element is the child ID. If the <c>vt</c> member of an array element
		/// is VT_DISPATCH, then the <c>pdispVal</c> member for that element is the address of the child object's IDispatch interface.
		/// </para>
		/// </param>
		/// <param name="pcObtained">
		/// <para>Type: <c>LONG*</c></para>
		/// <para>
		/// Address of a variable that receives the number of elements in the rgvarChildren array that is populated by the
		/// <c>AccessibleChildren</c> function. This value is the same as that of the cChildren parameter; however, if you request more
		/// children than exist, this value will be less than that of cChildren.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>STDAPI</c></para>
		/// <para>If successful, returns S_OK.</para>
		/// <para>If not successful, returns one of the following or another standard COM error code.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>An argument is not valid.</term>
		/// </item>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>The function succeeded, but there are fewer elements in the rgvarChildren array than there are children requested in cChildren.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// To retrieve information about all of the children in a container, the iChildStart parameter must be zero (0), and cChildren must
		/// be the value returned by IAccessible::get_accChildCount.
		/// </para>
		/// <para>
		/// When calling this function to obtain information about the children of a user interface element, it is recommended that clients
		/// obtain information about all of the children. For example, iChildStart must be zero (0), and cChildren must be the value returned
		/// by IAccessible::get_accChildCount.
		/// </para>
		/// <para>
		/// If a child ID is returned for an element, then the container must provide information about the child element. To obtain
		/// information about the element, clients use the container's IAccessible interface pointer and specify the obtained child ID in
		/// calls to the <c>IAccessible</c> properties.
		/// </para>
		/// <para>
		/// Clients must call the IUnknown::Release method for any IDispatch interfaces retrieved by this function, and free the array when
		/// it is no longer required.
		/// </para>
		/// <para>Examples</para>
		/// <para>
		/// The following example function displays a view of the element tree below the element that is passed in. The name and role of each
		/// element are printed by user-defined functions that are not shown here.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/oleacc/nf-oleacc-accessiblechildren HRESULT AccessibleChildren( IAccessible
		// *paccContainer, LONG iChildStart, LONG cChildren, VARIANT *rgvarChildren, LONG *pcObtained );
		[DllImport(Lib.Oleacc, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleacc.h", MSDNShortId = "dc9262d8-f57f-41f8-8945-d95f38d197e9")]
		public static extern HRESULT AccessibleChildren(IAccessible paccContainer, int iChildStart, int cChildren, [MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Struct, SizeParamIndex = 2)] object[] rgvarChildren, out int pcObtained);

		/// <summary>
		/// Retrieves the address of the IAccessible interface for the object that generated the event that is currently being processed by
		/// the client's event hook function.
		/// </summary>
		/// <param name="hwnd">
		/// <para>Type: <c>HWND</c></para>
		/// <para>
		/// Specifies the window handle of the window that generated the event. This value must be the window handle that is sent to the
		/// event hook function.
		/// </para>
		/// </param>
		/// <param name="dwId">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// Specifies the object ID of the object that generated the event. This value must be the object ID that is sent to the event hook function.
		/// </para>
		/// </param>
		/// <param name="dwChildId">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// Specifies whether the event was triggered by an object or one of its child elements. If the object triggered the event, dwChildID
		/// is CHILDID_SELF. If a child element triggered the event, dwChildID is the element's child ID. This value must be the child ID
		/// that is sent to the event hook function.
		/// </para>
		/// </param>
		/// <param name="ppacc">
		/// <para>Type: <c>IAccessible**</c></para>
		/// <para>
		/// Address of a pointer variable that receives the address of an IAccessible interface. The interface is either for the object that
		/// generated the event, or for the parent of the element that generated the event.
		/// </para>
		/// </param>
		/// <param name="pvarChild">
		/// <para>Type: <c>VARIANT*</c></para>
		/// <para>Address of a VARIANT structure that specifies the child ID that can be used to access information about the UI element.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>STDAPI</c></para>
		/// <para>If successful, returns S_OK.</para>
		/// <para>If not successful, returns one of the following or another standard COM error code.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>An argument is not valid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Clients call this function within an event hook function to obtain an IAccessible interface pointer to either the object that
		/// generated the event or to the parent of the element that generated the event. The parameters sent to the WinEventProc callback
		/// function must be used for this function's hwnd, dwObjectID, and dwChildID parameters.
		/// </para>
		/// <para>
		/// This function retrieves the lowest-level accessible object in the object hierarchy that is associated with an event. If the
		/// element that generated the event is not an accessible object (that is, does not support IAccessible), then the function retrieves
		/// the <c>IAccessible</c> interface of the parent object. The parent object must provide information about the child element through
		/// the <c>IAccessible</c> interface.
		/// </para>
		/// <para>
		/// As with other IAccessible methods and functions, clients might receive errors for <c>IAccessible</c> interface pointers because
		/// of a user action. For more information, see Receiving Errors for IAccessible Interface Pointers.
		/// </para>
		/// <para>
		/// This function fails if called in response to EVENT_OBJECT_CREATE because the object is not fully initialized. Similarly, clients
		/// should not call this in response to EVENT_OBJECT_DESTROY because the object is no longer available and cannot respond. Clients
		/// watch for EVENT_OBJECT_SHOW and EVENT_OBJECT_HIDE events rather than for <c>EVENT_OBJECT_CREATE</c> and <c>EVENT_OBJECT_DESTROY</c>.
		/// </para>
		/// <para>Examples</para>
		/// <para>The following example code shows this method being called in a WinEventProc event handler.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/oleacc/nf-oleacc-accessibleobjectfromevent HRESULT AccessibleObjectFromEvent(
		// HWND hwnd, DWORD dwId, DWORD dwChildId, IAccessible **ppacc, VARIANT *pvarChild );
		[DllImport(Lib.Oleacc, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleacc.h", MSDNShortId = "d453c163-3918-4a1c-9636-16816227a295")]
		public static extern HRESULT AccessibleObjectFromEvent(HWND hwnd, uint dwId, uint dwChildId, out IAccessible ppacc, [MarshalAs(UnmanagedType.Struct)] out object pvarChild);

		/// <summary>
		/// Retrieves the address of the IAccessible interface pointer for the object displayed at a specified point on the screen.
		/// </summary>
		/// <param name="ptScreen">Specifies, in physical screen coordinates, the point that is examined.</param>
		/// <param name="ppacc">Address of a pointer variable that receives the address of the object's IAccessible interface.</param>
		/// <param name="pvarChild">
		/// Address of a VARIANT structure that specifies whether the IAccessible interface pointer that is returned in ppacc belongs to the
		/// object displayed at the specified point, or to the parent of the element at the specified point. The <c>vt</c> member of the
		/// <c>VARIANT</c> is always VT_I4. If the <c>lVal</c> member is CHILDID_SELF, then the <c>IAccessible</c> interface pointer at ppacc
		/// belongs to the object at the point. If the <c>lVal</c> member is not CHILDID_SELF, ppacc is the address of the <c>IAccessible</c>
		/// interface of the child element's parent object. Clients must call VariantClear on the retrieved <c>VARIANT</c> parameter when
		/// finished using it.
		/// </param>
		/// <returns>
		/// <para>If successful, returns S_OK.</para>
		/// <para>If not successful, returns one of the following or another standard COM error code.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>An argument is not valid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This function retrieves the lowest-level accessible object in the object hierarchy at a given point. If the element at the point
		/// is not an accessible object (that is, does not support IAccessible), then the function retrieves the <c>IAccessible</c> interface
		/// of the parent object. The parent object must provide information about the child element through the <c>IAccessible</c>
		/// interface. Call IAccessible::accHitTest to identify the child element at the specified screen coordinates.
		/// </para>
		/// <para>
		/// As with other IAccessible methods and functions, clients might receive errors for <c>IAccessible</c> interface pointers because
		/// of a user action. For more information, see Receiving Errors for IAccessible Interface Pointers.
		/// </para>
		/// <para>Client Example</para>
		/// <para>
		/// The following example function selects the item at a specified point on the screen. It is assumed that a single selection is wanted.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/oleacc/nf-oleacc-accessibleobjectfrompoint HRESULT AccessibleObjectFromPoint(
		// POINT ptScreen, IAccessible **ppacc, VARIANT *pvarChild );
		[DllImport(Lib.Oleacc, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleacc.h", MSDNShortId = "b781b74f-5c36-4a65-a9b1-ecf7f8e5b531")]
		public static extern HRESULT AccessibleObjectFromPoint(System.Drawing.Point ptScreen, out IAccessible ppacc, [MarshalAs(UnmanagedType.Struct)] out object pvarChild);

		/// <summary>Retrieves the address of the specified interface for the object associated with the specified window.</summary>
		/// <param name="hwnd">
		/// <para>Type: <c>HWND</c></para>
		/// <para>
		/// Specifies the handle of a window for which an object is to be retrieved. To retrieve an interface pointer to the cursor or caret
		/// object, specify <c>NULL</c> and use the appropriate object ID in dwObjectID.
		/// </para>
		/// </param>
		/// <param name="dwId">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// Specifies the object ID. This value is one of the standard object identifier constants or a custom object ID such as
		/// OBJID_NATIVEOM, which is the object ID for the Office native object model. For more information about <c>OBJID_NATIVEOM</c>, see
		/// the Remarks section in this topic.
		/// </para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <c>REFIID</c></para>
		/// <para>
		/// Specifies the reference identifier of the requested interface. This value is either IID_IAccessible or IID_IDispatch, but it can
		/// also be IID_IUnknown, or the IID of any interface that the object is expected to support.
		/// </para>
		/// </param>
		/// <param name="ppvObject">
		/// <para>Type: <c>void**</c></para>
		/// <para>Address of a pointer variable that receives the address of the specified interface.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>STDAPI</c></para>
		/// <para>If successful, returns S_OK.</para>
		/// <para>If not successful, returns one of the following or another standard COM error code.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>An argument is not valid.</term>
		/// </item>
		/// <item>
		/// <term>E_NOINTERFACE</term>
		/// <term>The requested interface is not supported.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Clients call this function to retrieve the address of an object's IAccessible, IDispatch, IEnumVARIANT, IUnknown, or other
		/// supported interface pointer.
		/// </para>
		/// <para>
		/// As with other IAccessible methods and functions, clients might receive errors for <c>IAccessible</c> interface pointers because
		/// of a user action. For more information, see Receiving Errors for IAccessible Interface Pointers.
		/// </para>
		/// <para>
		/// Clients use this function to obtain access to the Microsoft Office 2000 native object model. The native object model provides
		/// clients with accessibility information about an Office application's document or client area that is not exposed by Microsoft
		/// Active Accessibility.
		/// </para>
		/// <para>
		/// To obtain an IDispatch interface pointer to a class supported by the native object model, specify OBJID_NATIVEOM in dwObjectID.
		/// When using this object identifier, the hwnd parameter must match the following window class types.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Office application</term>
		/// <term>Window class</term>
		/// <term>IDispatch pointer to</term>
		/// </listheader>
		/// <item>
		/// <term>Word</term>
		/// <term>_WwG</term>
		/// <term>Window</term>
		/// </item>
		/// <item>
		/// <term>Excel</term>
		/// <term>EXCEL7</term>
		/// <term>Window</term>
		/// </item>
		/// <item>
		/// <term>PowerPoint</term>
		/// <term>paneClassDC</term>
		/// <term>DocumentWindow</term>
		/// </item>
		/// <item>
		/// <term>Command Bars</term>
		/// <term>MsoCommandBar</term>
		/// <term>CommandBar</term>
		/// </item>
		/// </list>
		/// <para>
		/// Note that the above window classes correspond to the innermost document window or pane window. For more information about the
		/// Office object model, see the Microsoft Office 2000/Visual Basic Programmer's Guide.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/oleacc/nf-oleacc-accessibleobjectfromwindow HRESULT
		// AccessibleObjectFromWindow( HWND hwnd, DWORD dwId, REFIID riid, void **ppvObject );
		[DllImport(Lib.Oleacc, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleacc.h", MSDNShortId = "297ac50f-2a58-477b-ba57-5d1416c191b3")]
		public static extern HRESULT AccessibleObjectFromWindow(HWND hwnd, uint dwId, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 2)] out object ppvObject);

		/// <summary>
		/// Allows an assistive technology (AT) application to notify the system that it is interacting with UI through a Windows Automation
		/// API (such as Microsoft UI Automation) as a result of a touch gesture from the user. This allows the assistive technology to
		/// notify the target application and the system that the user is interacting with touch.
		/// </summary>
		/// <param name="hwndApp">A window that belongs to the AT process that is calling <c>AccNotifyTouchInteraction</c>.</param>
		/// <param name="hwndTarget">The nearest window of the automation element that the AT is targeting.</param>
		/// <param name="ptTarget">The center point of the automation element (or a point in the bounding rectangle of the element).</param>
		/// <returns>
		/// <para>If successful, returns S_OK.</para>
		/// <para>If not successful, returns a standard COM error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This function requires the calling process to have UIAccess or higher privileges. If the caller does not have the required
		/// privileges, the call to <c>AccNotifyTouchInteraction</c> fails and returns <c>E_ACCESSDENIED</c>. For more information, see
		/// Security Considerations for Assistive Technologies and /MANIFESTUAC (Embeds UAC information in manifest).
		/// </para>
		/// <para>
		/// When an AT is consuming touch data (such as when using the RegisterPointerInputTarget function), the shell and applications that
		/// the AT interacts with through the Windows Automation API are not aware that the user is interacting through touch. For the system
		/// to expose touch-related functionality to the user, the AT must use <c>AccNotifyTouchInteraction</c> to notify the system that it
		/// is performing the interaction in response to user touch input.
		/// </para>
		/// <para>Examples</para>
		/// <para>This code example shows how to call the <c>AccNotifyTouchInteraction</c> function.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/oleacc/nf-oleacc-accnotifytouchinteraction HRESULT AccNotifyTouchInteraction(
		// HWND hwndApp, HWND hwndTarget, POINT ptTarget );
		[DllImport(Lib.Oleacc, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleacc.h", MSDNShortId = "CB533913-95A7-45D5-B0D3-E931E4F73B2E")]
		public static extern HRESULT AccNotifyTouchInteraction(HWND hwndApp, HWND hwndTarget, System.Drawing.Point ptTarget);

		/// <summary>
		/// Sets system values that indicate whether an assistive technology (AT) application's current state affects functionality that is
		/// typically provided by the system.
		/// </summary>
		/// <param name="hwndApp">
		/// <para>Type: <c>HWND</c></para>
		/// <para>The handle of the AT application window. This parameter must not be <c>NULL</c>.</para>
		/// </param>
		/// <param name="dwUtilityStateMask">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>A mask that indicates the system values being set. It can be a combination of the following values:</para>
		/// <para>ANRUS_ON_SCREEN_KEYBOARD_ACTIVE</para>
		/// <para>ANRUS_TOUCH_MODIFICATION_ACTIVE</para>
		/// <para>ANRUS_PRIORITY_AUDIO_ACTIVE</para>
		/// <para>ANRUS_PRIORITY_AUDIO_ACTIVE_NODUCK</para>
		/// </param>
		/// <param name="dwUtilityState">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>
		/// The new settings for the system values indicated by dwUtilityStateMask. This parameter can be zero to reset the system values, or
		/// a combination of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ANRUS_ON_SCREEN_KEYBOARD_ACTIVE 0x0000001</term>
		/// <term>The AT application is providing an on-screen keyboard.</term>
		/// </item>
		/// <item>
		/// <term>ANRUS_TOUCH_MODIFICATION_ACTIVE 0x0000002</term>
		/// <term>The AT application is consuming redirected touch input.</term>
		/// </item>
		/// <item>
		/// <term>ANRUS_PRIORITY_AUDIO_ACTIVE 0x0000004</term>
		/// <term>
		/// The AT application is relying on audio (such as text-to-speech) to convey essential information to the user and should remain
		/// audible over other system sounds.
		/// </term>
		/// </item>
		/// <item>
		/// <term>ANRUS_PRIORITY_AUDIO_ACTIVE_NODUCK 0x0000008</term>
		/// <term>
		/// The AT application is relying on audio (such as text-to-speech) to convey essential information to the user but should not change
		/// relative to other system sounds.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>Type: <c>STDAPI</c></para>
		/// <para>If successful, returns S_OK.</para>
		/// <para>If not successful, returns a standard COM error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>Before it exits, an AT application should reset any system values that it previously set.</para>
		/// <para>
		/// This function requires the calling process to have UIAccess or higher privileges. If the caller does not have the required
		/// privileges, the call to <c>AccSetRunningUtilityState</c> fails and returns <c>E_ACCESSDENIED</c>. For more information, see
		/// Security Considerations for Assistive Technologies and /MANIFESTUAC (Embeds UAC information in manifest).
		/// </para>
		/// <para>Examples</para>
		/// <para>This code example shows how to call the <c>AccSetRunningUtilityState</c> function.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/oleacc/nf-oleacc-accsetrunningutilitystate HRESULT AccSetRunningUtilityState(
		// HWND hwndApp, DWORD dwUtilityStateMask, DWORD dwUtilityState );
		[DllImport(Lib.Oleacc, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleacc.h", MSDNShortId = "0AEDDE0D-D8E2-4C9E-AB2B-2FF0ACC3695D")]
		public static extern HRESULT AccSetRunningUtilityState(HWND hwndApp, ANRUS dwUtilityStateMask, ANRUS dwUtilityState);

		/// <summary>
		/// Creates an accessible object with the methods and properties of the specified type of system-provided user interface element.
		/// </summary>
		/// <param name="hwnd">
		/// <para>Type: <c>HWND</c></para>
		/// <para>Window handle of the system-provided user interface element (a control) for which an accessible object is created.</para>
		/// </param>
		/// <param name="idObject">
		/// <para>Type: <c>LONG</c></para>
		/// <para>Object ID. This value is usually OBJID_CLIENT, but it may be another object identifier.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <c>REFIID</c></para>
		/// <para>
		/// Reference identifier of the requested interface. This value is one of the following: IID_IAccessible, IID_IDispatch,
		/// IID_IEnumVARIANT, or IID_IUnknown.
		/// </para>
		/// </param>
		/// <param name="ppvObject">
		/// <para>Type: <c>void**</c></para>
		/// <para>Address of a pointer variable that receives the address of the specified interface.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>STDAPI</c></para>
		/// <para>If successful, returns S_OK.</para>
		/// <para>If not successful, returns a standard COM error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Server applications call this function when they contain a custom UI object that is similar to a system-provided object. Server
		/// developers can call <c>CreateStdAccessibleObject</c> to override the IAccessible methods and properties as required to match
		/// their custom objects. Alternatively, server developers can use Dynamic Annotation to override specific properties without having
		/// to use difficult subclassing techniques that <c>CreateStdAccessibleObject</c> requires. Server developers should still use
		/// <c>CreateStdAccessibleObject</c> for structural changes, such as hiding a child element or creating a placeholder child element.
		/// This approach saves server developers the work of fully implementing all of the <c>IAccessible</c> properties and methods.
		/// </para>
		/// <para>
		/// This function is similar to CreateStdAccessibleProxy, except that <c>CreateStdAccessibleProxy</c> allows you to specify the class
		/// name as a parameter whereas <c>CreateStdAccessibleObject</c> uses the class name associated with the hwnd parameter.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/oleacc/nf-oleacc-createstdaccessibleobject HRESULT CreateStdAccessibleObject(
		// HWND hwnd, LONG idObject, REFIID riid, void **ppvObject );
		[DllImport(Lib.Oleacc, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleacc.h", MSDNShortId = "50b6f391-98a4-4276-840f-028cc18e99ef")]
		public static extern HRESULT CreateStdAccessibleObject(HWND hwnd, int idObject, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 2)] out object ppvObject);

		/// <summary>
		/// Creates an accessible object that has the properties and methods of the specified class of system-provided user interface element.
		/// </summary>
		/// <param name="hwnd">
		/// <para>Type: <c>HWND</c></para>
		/// <para>Window handle of the system-provided user interface element (a control) for which an accessible object is created.</para>
		/// </param>
		/// <param name="pClassName">
		/// <para>Type: <c>LPCTSTR</c></para>
		/// <para>
		/// Pointer to a null-terminated string of the class name of a system-provided user interface element for which an accessible object
		/// is created. The window class name is one of the common controls (defined in Comctl32.dll), predefined controls (defined in
		/// User32.dll), or window elements.
		/// </para>
		/// </param>
		/// <param name="idObject">
		/// <para>Type: <c>LONG</c></para>
		/// <para>
		/// Object ID. This value is usually OBJID_CLIENT, which is one of the object identifier constants, but it may be another object identifier.
		/// </para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <c>REFIID</c></para>
		/// <para>
		/// Reference identifier of the interface requested. This value is one of the following: IID_IAccessible, IID_IDispatch,
		/// IID_IEnumVARIANT, or IID_IUnknown.
		/// </para>
		/// </param>
		/// <param name="ppvObject">
		/// <para>Type: <c>void**</c></para>
		/// <para>Address of a pointer variable that receives the address of the specified interface.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>STDAPI</c></para>
		/// <para>If successful, returns S_OK.</para>
		/// <para>If not successful, returns a standard COM error code.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Server applications call this function when they contain a custom control that is similar to a system-provided control. Server
		/// applications can call <c>CreateStdAccessibleProxy</c> to override the IAccessible methods and properties as required to match
		/// their custom controls. Alternatively, server developers can use Dynamic Annotation to override specific properties without having
		/// to use difficult subclassing techniques that were required with <c>CreateStdAccessibleProxy</c>. Server developers should still
		/// use <c>CreateStdAccessibleProxy</c> for structural changes, such as hiding a child element or creating a placeholder child
		/// element. This approach saves server developers the work of fully implementing all of the <c>IAccessible</c> properties and methods.
		/// </para>
		/// <para>
		/// This function is similar to CreateStdAccessibleObject, except that <c>CreateStdAccessibleObject</c> always uses the class name
		/// associated with the hwnd whereas <c>CreateStdAccessibleProxy</c> allows you to specify the class name as a parameter.
		/// </para>
		/// <para>
		/// Use <c>CreateStdAccessibleProxy</c> to create an accessible object for a user interface element that is superclassed. When a user
		/// interface element is superclassed, an application creates a custom control with a window class name different from the predefined
		/// control on which it is based. Because the class name associated with the hwnd parameter is the superclass window class name,
		/// specify the base class name (the system class name on which the superclassed control is based) in pszClassName.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/oleacc/nf-oleacc-createstdaccessibleproxya HRESULT CreateStdAccessibleProxyA(
		// HWND hwnd, LPCSTR pClassName, LONG idObject, REFIID riid, void **ppvObject );
		[DllImport(Lib.Oleacc, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("oleacc.h", MSDNShortId = "724b2a38-f7ca-4423-acd4-0871623d1201")]
		public static extern HRESULT CreateStdAccessibleProxy(HWND hwnd, [MarshalAs(UnmanagedType.LPTStr)] string pClassName, int idObject, in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 3)] out object ppvObject);

		/// <summary>Retrieves the version number and build number of the Microsoft Active Accessibility file Oleacc.dll.</summary>
		/// <param name="pVer">
		/// <para>Type: <c>DWORD*</c></para>
		/// <para>
		/// Address of a <c>DWORD</c> that receives the version number. The major version number is placed in the high word, and the minor
		/// version number is placed in the low word.
		/// </para>
		/// </param>
		/// <param name="pBuild">
		/// <para>Type: <c>DWORD*</c></para>
		/// <para>
		/// Address of a <c>DWORD</c> that receives the build number. The major build number is placed in the high word, and the minor build
		/// number is placed in the low word.
		/// </para>
		/// </param>
		/// <returns>This function does not return a value.</returns>
		/// <remarks>
		/// This function provides an easy way to get the version and build numbers for Oleacc.dll. The GetFileVersionInfoSize,
		/// GetFileVersionInfo, and VerQueryValue functions can be used to retrieve the same information.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/oleacc/nf-oleacc-getoleaccversioninfo void GetOleaccVersionInfo( DWORD *pVer,
		// DWORD *pBuild );
		[DllImport(Lib.Oleacc, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleacc.h", MSDNShortId = "96dcdb85-4f35-4274-ba57-2f565c3ebb5f")]
		public static extern void GetOleaccVersionInfo(out uint pVer, out uint pBuild);

		/// <summary>Retrieves a process handle from a window handle.</summary>
		/// <returns>
		/// <para>Type: <c><c>HANDLE</c></c></para>
		/// <para>If successful, returns the handle of the process that owns the window.</para>
		/// <para>If not successful, returns <c>NULL</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// In previous versions of the operating system, a process could open another process (to access its memory, for example) using
		/// <c>OpenProcess</c>. This function succeeds if the caller has appropriate privileges; usually the caller and target process must
		/// be the same user.
		/// </para>
		/// <para>
		/// On Windows Vista, however, <c>OpenProcess</c> fails in the scenario where the caller has UIAccess, and the target process is
		/// elevated. In this case, the owner of the target process is in the Administrators group, but the calling process is running with
		/// the restricted token, so does not have membership in this group, and is denied access to the elevated process. If the caller has
		/// UIAccess, however, they can use a windows hook to inject code into the target process, and from within the target process, send a
		/// handle back to the caller.
		/// </para>
		/// <para>
		/// <c>GetProcessHandleFromHwnd</c> is a convenience function that uses this technique to obtain the handle of the process that owns
		/// the specified HWND. Note that it only succeeds in cases where the caller and target process are running as the same user. The
		/// returned handle has the following privileges: PROCESS_DUP_HANDLE | PROCESS_VM_OPERATION | PROCESS_VM_READ | PROCESS_VM_WRITE |
		/// SYNCHRONIZE. If other privileges are required, it may be necessary to implement the hooking technique explicitly instead of using
		/// this function.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/WinAuto/getprocesshandlefromhwnd HANDLE WINAPI GetProcessHandleFromHwnd( _In_
		// HWND hwnd );
		[DllImport(Lib.Oleacc, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("", MSDNShortId = "173579d2-c930-402c-81c7-761b063b5b51")]
		public static extern HPROCESS GetProcessHandleFromHwnd(HWND hwnd);

		/// <summary>Retrieves the localized string that describes the object's role for the specified role value.</summary>
		/// <param name="lRole">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>One of the object role constants.</para>
		/// </param>
		/// <param name="lpszRole">
		/// <para>Type: <c>LPTSTR</c></para>
		/// <para>
		/// Address of a buffer that receives the role text string. If this parameter is <c>NULL</c>, the function returns the role string's
		/// length, not including the null character.
		/// </para>
		/// </param>
		/// <param name="cchRoleMax">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// The size of the buffer that is pointed to by the lpszRole parameter. For ANSI strings, this value is measured in bytes; for
		/// Unicode strings, it is measured in characters.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// If successful, and if lpszRole is non- <c>NULL</c>, the return value is the number of bytes (ANSI strings) or characters (Unicode
		/// strings) copied into the buffer, not including the terminating null character. If lpszRole is <c>NULL</c>, the return value
		/// represents the string's length, not including the null character.
		/// </para>
		/// <para>
		/// If the string resource does not exist, or if the lpszRole parameter is not a valid pointer, the return value is zero (0). To get
		/// extended error information, call GetLastError.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/oleacc/nf-oleacc-getroletexta UINT GetRoleTextA( DWORD lRole, LPSTR lpszRole,
		// UINT cchRoleMax );
		[DllImport(Lib.Oleacc, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("oleacc.h", MSDNShortId = "58436001-92d7-4afa-af07-169c8bbda9ba")]
		public static extern uint GetRoleText(AccessibilityRole lRole, [MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpszRole, uint cchRoleMax);

		/// <summary>
		/// Retrieves a localized string that describes an object's state for a single predefined state bit flag. Because state values are a
		/// combination of one or more bit flags, clients call this function more than once to retrieve all state strings.
		/// </summary>
		/// <param name="lStateBit">
		/// <para>Type: <c>DWORD</c></para>
		/// <para>One of the object state constants.</para>
		/// </param>
		/// <param name="lpszState">
		/// <para>Type: <c>LPTSTR</c></para>
		/// <para>
		/// Address of a buffer that receives the state text string. If this parameter is <c>NULL</c>, the function returns the state
		/// string's length, not including the null character.
		/// </para>
		/// </param>
		/// <param name="cchState">
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// The size of the buffer that is pointed to by the lpszStateBit parameter. For ANSI strings, this value is measured in bytes; for
		/// Unicode strings, it is measured in characters.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>UINT</c></para>
		/// <para>
		/// If successful, and if lpszStateBit is non- <c>NULL</c>, the return value is the number of bytes (ANSI strings) or characters
		/// (Unicode strings) that are copied into the buffer, not including the null-terminated character. If lpszStateBit is <c>NULL</c>,
		/// the return value represents the string's length, not including the null character.
		/// </para>
		/// <para>
		/// If the string resource does not exist, or if the lpszStateBit parameter is not a valid pointer, the return value is zero (0). To
		/// get extended error information, call GetLastError.
		/// </para>
		/// </returns>
		/// <remarks>This function accepts only one state bit at a time, not a bitmask.</remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/oleacc/nf-oleacc-getstatetexta UINT GetStateTextA( DWORD lStateBit, LPSTR
		// lpszState, UINT cchState );
		[DllImport(Lib.Oleacc, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("oleacc.h", MSDNShortId = "2a136883-870e-48c3-b182-1cdc64768894")]
		public static extern uint GetStateText(AccessibilityState lStateBit, [MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpszState, uint cchState);

		/// <summary>Returns a reference, similar to a handle, to the specified object. Servers return this reference when handling WM_GETOBJECT.</summary>
		/// <param name="riid">
		/// <para>Type: <c>REFIID</c></para>
		/// <para>Reference identifier of the interface provided to the client. This parameter is IID_IAccessible.</para>
		/// </param>
		/// <param name="wParam">
		/// <para>Type: <c>WPARAM</c></para>
		/// <para>Value sent by the associated WM_GETOBJECT message in its wParam parameter.</para>
		/// </param>
		/// <param name="punk">
		/// <para>Type: <c>LPUNKNOWN</c></para>
		/// <para>Address of the IAccessible interface to the object that corresponds to the WM_GETOBJECT message.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>LRESULT</c></para>
		/// <para>If successful, returns a positive value that is a reference to the object.</para>
		/// <para>If not successful, returns one of the values in the table that follows, or another standard COM error code.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One or more arguments are not valid.</term>
		/// </item>
		/// <item>
		/// <term>E_NOINTERFACE</term>
		/// <term>The object specified in the pAcc parameter does not support the interface specified in the riid parameter.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>Insufficient memory to store the object reference.</term>
		/// </item>
		/// <item>
		/// <term>E_UNEXPECTED</term>
		/// <term>An unexpected error occurred.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Servers call this function only when handling the WM_GETOBJECT message. For an overview of how <c>LresultFromObject</c> is
		/// related to <c>WM_GETOBJECT</c>, see How WM_GETOBJECT Works.
		/// </para>
		/// <para>
		/// <c>LresultFromObject</c> increments the object's reference count. If you are not storing the interface pointer passed to the
		/// function (that is, you create a new interface pointer for the object each time WM_GETOBJECT is received), call the object's
		/// Release method to decrement the reference count back to one. Then the client calls <c>Release</c> and the object is destroyed.
		/// For more information, see How to Handle WM_GETOBJECT.
		/// </para>
		/// <para>
		/// Each time a server processes WM_GETOBJECT for a specific object, it calls <c>LresultFromObject</c> to obtain a new reference to
		/// the object. Servers do not save the reference returned from <c>LresultFromObject</c> from one instance of processing
		/// <c>WM_GETOBJECT</c> to use as the message's return value when processing subsequent <c>WM_GETOBJECT</c> messages for the same
		/// object. This causes the client to receive an error.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/oleacc/nf-oleacc-lresultfromobject LRESULT LresultFromObject( REFIID riid,
		// WPARAM wParam, LPUNKNOWN punk );
		[DllImport(Lib.Oleacc, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleacc.h", MSDNShortId = "c219a4cd-7a8f-4942-8975-b3d823b6497f")]
		public static extern IntPtr LresultFromObject(in Guid riid, IntPtr wParam, [In, MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)] object punk);

		/// <summary>
		/// <para>Retrieves a requested interface pointer for an accessible object based on a previously generated object reference.</para>
		/// <para>
		/// This function is designed for internal use by Microsoft Active Accessibility and is documented for informational purposes only.
		/// Neither clients nor servers should call this function.
		/// </para>
		/// </summary>
		/// <param name="lResult">
		/// <para>Type: <c>LRESULT</c></para>
		/// <para>A 32-bit value returned by a previous successful call to the LresultFromObject function.</para>
		/// </param>
		/// <param name="riid">
		/// <para>Type: <c>REFIID</c></para>
		/// <para>Reference identifier of the interface to be retrieved. This is IID_IAccessible.</para>
		/// </param>
		/// <param name="wParam">
		/// <para>Type: <c>WPARAM</c></para>
		/// <para>Value sent by the associated WM_GETOBJECT message in its wParam parameter.</para>
		/// </param>
		/// <param name="ppvObject">
		/// <para>Type: <c>void**</c></para>
		/// <para>Receives the address of the IAccessible interface on the object that corresponds to the WM_GETOBJECT message.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>STDAPI</c></para>
		/// <para>If successful, returns S_OK.</para>
		/// <para>If not successful, returns one of the following standard COM error codes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>
		/// One or more arguments are not valid. This occurs when the lResult parameter specified is not a value obtained by a call to
		/// LresultFromObject, or when lResult is a value used on a previous call to ObjectFromLresult.
		/// </term>
		/// </item>
		/// <item>
		/// <term>E_NOINTERFACE</term>
		/// <term>The object specified in the ppvObject parameter does not support the interface specified by the riid parameter.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>Insufficient memory to store the object reference.</term>
		/// </item>
		/// <item>
		/// <term>E_UNEXPECTED</term>
		/// <term>An unexpected error occurred.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/oleacc/nf-oleacc-objectfromlresult HRESULT ObjectFromLresult( LRESULT
		// lResult, REFIID riid, WPARAM wParam, void **ppvObject );
		[DllImport(Lib.Oleacc, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleacc.h", MSDNShortId = "97e766fd-e142-40d1-aba7-408b45d33426")]
		public static extern HRESULT ObjectFromLresult(IntPtr lResult, in Guid riid, IntPtr wParam, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object ppvObject);

		/// <summary>Retrieves the window handle that corresponds to a particular instance of an IAccessible interface.</summary>
		/// <param name="arg1">
		/// <para>Type: <c>IAccessible*</c></para>
		/// <para>Pointer to the IAccessible interface whose corresponding window handle will be retrieved. This parameter must not be <c>NULL</c>.</para>
		/// </param>
		/// <param name="phwnd">
		/// <para>Type: <c>HWND*</c></para>
		/// <para>
		/// Address of a variable that receives a handle to the window containing the object specified in pacc. If this value is <c>NULL</c>
		/// after the call, the object is not contained within a window; for example, the mouse pointer is not contained within a window.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>STDAPI</c></para>
		/// <para>If successful, returns S_OK.</para>
		/// <para>If not successful, returns the following or another standard COM error code.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>An argument is not valid.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/oleacc/nf-oleacc-windowfromaccessibleobject HRESULT
		// WindowFromAccessibleObject( IAccessible *, HWND *phwnd );
		[DllImport(Lib.Oleacc, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("oleacc.h", MSDNShortId = "b3a3d3dd-ef84-4323-ab6d-6331d8389f11")]
		public static extern HRESULT WindowFromAccessibleObject([In] IAccessible arg1, out HWND phwnd);
	}
}