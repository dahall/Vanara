using System.Runtime.InteropServices.ComTypes;

namespace Vanara.PInvoke;

public static partial class Ole32
{
	/// <summary>Indicates whether an object is activated as a windowless object. It is used in IOleInPlaceSiteEx::OnInPlaceActivateEx.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/ne-ocidl-activateflags typedef enum tagACTIVATEFLAGS {
	// ACTIVATE_WINDOWLESS } ACTIVATEFLAGS;
	[PInvokeData("ocidl.h", MSDNShortId = "NE:ocidl.tagACTIVATEFLAGS")]
	public enum ACTIVATEFLAGS
	{
		/// <summary>
		/// Indicates that the object is activated in place as a windowless object. In the IOleInPlaceSiteEx::OnInPlaceActivateEx
		/// method, the container uses this value returned in the dwFlags parameter instead of calling the
		/// IOleInPlaceObjectWindowless::GetWindow method to determine if the object is windowless or not.
		/// </summary>
		ACTIVATE_WINDOWLESS = 1,
	}

	/// <summary>Flags that indicate the keyboard behavior of the control.</summary>
	[PInvokeData("ocidl.h", MSDNShortId = "NS:ocidl.tagCONTROLINFO")]
	[Flags]
	public enum CTRLINFO
	{
		/// <summary>When the control has the focus, it will process the Return key.</summary>
		CTRLINFO_EATS_RETURN = 1,

		/// <summary>When the control has the focus, it will process the Escape key.</summary>
		CTRLINFO_EATS_ESCAPE = 2
	}

	/// <summary>Specifies new drawing aspects used to optimize the drawing process.</summary>
	/// <remarks>
	/// <para>
	/// To support drawing optimizations to reduce flicker, an object needs to be able to draw and return information about three
	/// separate aspects of itself.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Aspect</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>DVASPECT_CONTENT</term>
	/// <term>Specifies the entire content of an object. All objects should support this aspect.</term>
	/// </item>
	/// <item>
	/// <term>DVASPECT_OPAQUE</term>
	/// <term>Represents the opaque, easy to clip parts of an object. Objects may or may not support this aspect.</term>
	/// </item>
	/// <item>
	/// <term>DVASPECT_TRANSPARENT</term>
	/// <term>
	/// Represents the transparent or irregular parts of on object, typically parts that are expensive or impossible to clip out.
	/// Objects may or may not support this aspect.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// The container can determine which of these drawing aspects an object supports by calling the new method
	/// IViewObjectEx::GetViewStatus. Individual bits return information about which aspects are supported. If an object does not
	/// support the IViewObjectExinterface, it is assumed to support only DVASPECT_CONTENT.
	/// </para>
	/// <para>
	/// Depending on which aspects are supported, the container can ask the object to draw itself during the front to back pass only,
	/// the back to front pass only, or both. The various possible cases are:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// Objects supporting only DVASPECT_CONTENT should be drawn during the back to front pass, with all opaque parts of any overlapping
	/// object clipped out. Since all objects should support this aspect, a container not concerned about flickering - maybe because it
	/// is drawing in an offscreen bitmap - can opt to draw all objects that way and skip the front to back pass.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// Objects supporting DVASPECT_OPAQUE may be asked to draw this aspect during the front to back pass. The container is responsible
	/// for clipping out the object's opaque regions before painting any further object behind it.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// Objects supporting DVASPECT_TRANSPARENT may be asked to draw this aspect during the back to front pass. The container is
	/// responsible for clipping out opaque parts of overlapping objects before letting an object draw this aspect.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// Even when DVASPECT_OPAQUE and DVASPECT_TRANSPARENT are supported, the container is free to use these aspects or not. In
	/// particular, if it is painting in an offscreen bitmap and consequently is unconcerned about flicker, the container may use
	/// DVASPECT_CONTENT and a one-pass drawing only. However, in a two-pass drawing, if the container uses DVASPECT_OPAQUE during the
	/// front to back pass, then it must use DVASPECT_TRANSPARENT during the back to front pass to complete the rendering of the object.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/ne-ocidl-dvaspect2 typedef enum tagDVASPECT2 { DVASPECT_OPAQUE,
	// DVASPECT_TRANSPARENT } DVASPECT2;
	[PInvokeData("ocidl.h", MSDNShortId = "NE:ocidl.tagDVASPECT2")]
	[Flags]
	public enum DVASPECT2
	{
		/// <summary>
		/// A representation of an object that lets that object be displayed as an embedded object inside a container. This value is
		/// typically specified for compound document objects. The presentation can be provided for the screen or printer.
		/// </summary>
		DVASPECT_CONTENT = 1,

		/// <summary>
		/// A representation of an object on the screen as though it were printed to a printer using the Print command from the File
		/// menu. The described data may represent a sequence of pages.
		/// </summary>
		DVASPECT_DOCPRINT = 8,

		/// <summary>An iconic representation of an object.</summary>
		DVASPECT_ICON = 4,

		/// <summary>
		/// A thumbnail representation of an object that lets that object be displayed in a browsing tool. The thumbnail is
		/// approximately a 120 by 120 pixel, 16-color (recommended), device-independent bitmap potentially wrapped in a metafile.
		/// </summary>
		DVASPECT_THUMBNAIL = 2,

		/// <summary>Represents the opaque, easy to clip parts of an object. Objects may or may not support this aspect.</summary>
		DVASPECT_OPAQUE = 16,

		/// <summary>
		/// Represents the transparent or irregular parts of on object, typically parts that are expensive or impossible to clip out.
		/// Objects may or may not support this aspect.
		/// </summary>
		DVASPECT_TRANSPARENT = 32,
	}

	/// <summary>Indicates whether an object can support optimized drawing of itself.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/ne-ocidl-dvaspectinfoflag typedef enum tagAspectInfoFlag {
	// DVASPECTINFOFLAG_CANOPTIMIZE } DVASPECTINFOFLAG;
	[PInvokeData("ocidl.h", MSDNShortId = "NE:ocidl.tagAspectInfoFlag")]
	public enum DVASPECTINFOFLAG
	{
		/// <summary>
		/// Indicates that the object can support optimized rendering of itself. Because most objects on a form share the same font,
		/// background color, and border types, leaving these values in the device context allows the next object to use them without
		/// having to re-select them. Specifically, the object can leave the font, brush, and pen selected on return from the
		/// IViewObject::Draw method instead of deselecting these from the device context. The container then must deselect these values
		/// at the end of the overall drawing process. The object can also leave other drawing state changes in the device context, such
		/// as the background color, the text color, raster operation code, the current point, the line drawing, and the poly fill mode.
		/// The object cannot change state values unless other objects are capable of restoring them. For example, the object cannot
		/// leave a changed mode, transformation value, selected bitmap, clip region, or metafile.
		/// </summary>
		DVASPECTINFOFLAG_CANOPTIMIZE = 1,
	}

	/// <summary>Indicates whether the sizing mode is content or integral sizing.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/ne-ocidl-dvextentmode typedef enum tagExtentMode { DVEXTENT_CONTENT,
	// DVEXTENT_INTEGRAL } DVEXTENTMODE;
	[PInvokeData("ocidl.h", MSDNShortId = "NE:ocidl.tagExtentMode")]
	public enum DVEXTENTMODE
	{
		/// <summary>
		/// Indicates that the container will ask the object how big it wants to be to exactly fit its content, for example, in
		/// snap-to-size operations.
		/// </summary>
		DVEXTENT_CONTENT,

		/// <summary>Indicates that the container will provide a proposed size to the object for its use in resizing.</summary>
		DVEXTENT_INTEGRAL,
	}

	/// <summary>Flags used to specify the kind of information requested from an object in the IProvideClassInfo2.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/ne-ocidl-guidkind typedef enum tagGUIDKIND {
	// GUIDKIND_DEFAULT_SOURCE_DISP_IID } GUIDKIND;
	[PInvokeData("ocidl.h", MSDNShortId = "NE:ocidl.tagGUIDKIND")]
	public enum GUIDKIND
	{
		/// <summary>
		/// The interface identifier (IID) of the object's outgoing dispinterface, labeled [source, default]. The outgoing interface in
		/// question must be derived from IDispatch.
		/// </summary>
		GUIDKIND_DEFAULT_SOURCE_DISP_IID = 1,
	}

	/// <summary>Indicates whether a location is within the image of an object.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/ne-ocidl-hitresult typedef enum tagHITRESULT { HITRESULT_OUTSIDE,
	// HITRESULT_TRANSPARENT, HITRESULT_CLOSE, HITRESULT_HIT } HITRESULT;
	[PInvokeData("ocidl.h", MSDNShortId = "NE:ocidl.tagHITRESULT")]
	public enum HITRESULT
	{
		/// <summary>The specified location is outside the object and not close to the object.</summary>
		HITRESULT_OUTSIDE = 0,

		/// <summary>
		/// The specified location is within the bounds of the object, but not close to the image. For example, a point in the middle of
		/// a transparent circle could be HITRESULT_TRANSPARENT.
		/// </summary>
		HITRESULT_TRANSPARENT,

		/// <summary>
		/// The specified location is inside the object or is outside the object but is close enough to the object to be considered
		/// inside. Small, thin or detailed objects may use this value. Even if a point is outside the bounding rectangle of an object
		/// it may still be close. This value is needed for hitting small objects.
		/// </summary>
		HITRESULT_CLOSE,

		/// <summary>The specified location is within the image of the object.</summary>
		HITRESULT_HIT,
	}

	/// <summary>
	/// Describes additional keyboard states that can modify the meaning of the keyboard messages that are specified in <c>IOleControlSite::TranslateAccelerator</c>.
	/// </summary>
	// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/legacy/ms683763(v=vs.85) typedef enum tagKEYMODIFIERS { KEYMOD_SHIFT =
	// 0x0001, KEYMOD_CONTROL = 0x0002, KEYMOD_ALT = 0x0004 } KEYMODIFIERS;
	[PInvokeData("")]
	[Flags]
	public enum KEYMODIFIERS
	{
		/// <summary>The Shift key is currently depressed.</summary>
		KEYMOD_SHIFT = 0x01,

		/// <summary>The Control key is currently depressed.</summary>
		KEYMOD_CONTROL = 0x02,

		/// <summary>The Alt key is currently depressed.</summary>
		KEYMOD_ALT = 0x04,
	}

	/// <summary>
	/// A bitfield indicating which out parameters are being requested. Indicating a particular flag results in the appropriate
	/// information being assigned to the associated out parameter.
	/// </summary>
	[PInvokeData("ocidl.h", MSDNShortId = "NN:ocidl.IProvideMultipleClassInfo")]
	[Flags]
	public enum MULTICLASSINFO
	{
		/// <summary>Indicates a request for pptiCoClass information.</summary>
		MULTICLASSINFO_GETTYPEINFO = 0x00000001,

		/// <summary>Indicates a request for pcdispidReserved and pdwTIFlags information.</summary>
		MULTICLASSINFO_GETNUMRESERVEDDISPIDS = 0x00000002,

		/// <summary>Indicates a request for piidPrimary information.</summary>
		MULTICLASSINFO_GETIIDPRIMARY = 0x00000004,

		/// <summary>Indicates a request for piidPrimary information.</summary>
		MULTICLASSINFO_GETIIDSOURCE = 0x00000008,
	}

	/// <summary>Specifies additional information to the container about the device context that the object has requested.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/ne-ocidl-oledcflags typedef enum tagOLEDCFLAGS { OLEDC_NODRAW,
	// OLEDC_PAINTBKGND, OLEDC_OFFSCREEN } OLEDCFLAGS;
	[PInvokeData("ocidl.h", MSDNShortId = "NE:ocidl.tagOLEDCFLAGS")]
	[Flags]
	public enum OLEDCFLAGS
	{
		/// <summary>
		/// Indicates that the object will not use the returned HDC for drawing but merely to get information about the display device.
		/// In this case, the container can simply pass the window's device context without further processing.
		/// </summary>
		OLEDC_NODRAW = 0x01,

		/// <summary>
		/// Requests that the container paint the background behind the object before returning the device context. Objects should use
		/// this flag when requesting a device context to paint a transparent area.
		/// </summary>
		OLEDC_PAINTBKGND = 0x02,

		/// <summary>
		/// Indicates that the object prefers to draw into an offscreen device context that should then be copied to the screen. The
		/// container can honor this request or not. If this bit is cleared, the container must return an on-screen device context
		/// allowing the object to perform direct screen operations such as showing a selection through an XOR operation. An object can
		/// specify this value when the drawing operation generates a lot of screen flicker.
		/// </summary>
		OLEDC_OFFSCREEN = 0x04,
	}

	/// <summary>Specifies attributes of a picture object as returned through the IPicture::get_Attributes method.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/ne-ocidl-pictureattributes typedef enum tagPictureAttributes {
	// PICTURE_SCALABLE, PICTURE_TRANSPARENT } PICTUREATTRIBUTES;
	[PInvokeData("ocidl.h", MSDNShortId = "NE:ocidl.tagPictureAttributes")]
	[Flags]
	public enum PICTUREATTRIBUTES
	{
		/// <summary>
		/// The picture object is scalable, such that it can be redrawn with a different size than was used to create the picture
		/// originally. Metafile-based pictures are considered scalable; icon and bitmap pictures, while they can be scaled, do not
		/// express this attribute because both involve bitmap stretching instead of true scaling.
		/// </summary>
		PICTURE_SCALABLE = 0x01,

		/// <summary>
		/// The picture object contains an image that has transparent areas, such that drawing the picture will not necessarily fill in
		/// all the spaces in the rectangle it occupies. Metafile and icon pictures have this attribute; bitmap pictures do not.
		/// </summary>
		PICTURE_TRANSPARENT = 0x02,
	}

	/// <summary>
	/// <para>
	/// Describe the type of a picture object as returned by <c>IPicture::get_Type</c>, as well as to describe the type of picture in
	/// the <c>picType</c> member of the <c>PICTDESC</c> structure that is passed to <c>OleCreatePictureIndirect</c>.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/com/pictype-constants
	[PInvokeData("ocidl.h", MSDNShortId = "NN:ocidl.IPicture")]
	public enum PICTYPE : short
	{
		/// <summary>
		/// The picture object is currently uninitialized. This value is only valid as a return value from IPicture::get_Type and is not
		/// valid with the PICTDESC structure.
		/// </summary>
		PICTYPE_UNINITIALIZED = (-1),

		/// <summary>
		/// A new picture object is to be created without an initialized state. This value is valid only in the PICTDESC structure.
		/// </summary>
		PICTYPE_NONE = 0,

		/// <summary>
		/// The picture type is a bitmap. When this value occurs in the PICTDESC structure, it means that the bmp field of that
		/// structure contains the relevant initialization parameters.
		/// </summary>
		PICTYPE_BITMAP = 1,

		/// <summary>
		/// The picture type is a metafile. When this value occurs in the PICTDESC structure, it means that the wmf field of that
		/// structure contains the relevant initialization parameters.
		/// </summary>
		PICTYPE_METAFILE = 2,

		/// <summary>
		/// The picture type is an icon. When this value occurs in the PICTDESC structure, it means that the icon field of that
		/// structure contains the relevant initialization parameters.
		/// </summary>
		PICTYPE_ICON = 3,

		/// <summary>
		/// The picture type is an enhanced metafile. When this value occurs in the PICTDESC structure, it means that the emf field of
		/// that structure contains the relevant initialization parameters.
		/// </summary>
		PICTYPE_ENHMETAFILE = 4,
	}

	/// <summary>Indicate the activation policy of the object and are used in the IPointerInactive::GetActivationPolicy method.</summary>
	/// <remarks>
	/// <para>
	/// For more information on using the <c>POINTERINACTIVE_ACTIVATEONENTRY</c> and <c>POINTERINACTIVE_DEACTIVATEONLEAVE</c> values,
	/// see the IPointerInactive::GetActivationPolicy method.
	/// </para>
	/// <para>
	/// <c>The POINTERINACTIVE_ACTIVATEONDRAG</c> value can be used to support drag and drop operations on an inactive object. An
	/// inactive object has no window to register itself as a potential drop target. Most containers ignore embedded, inactive objects
	/// as drop targets because of the overhead associated with activating them.
	/// </para>
	/// <para>
	/// As an alternative to activating an object when the mouse pointer is over it during a drag and drop operation, the container can
	/// first QueryInterface to determine if the inactive object supports IPointerInactive. Then, if the object does not support
	/// IPointerInactive, the container can assume that it is not a drop target. If the object does support <c>IPointerInactive</c>, the
	/// container calls the IPointerInactive::GetActivationPolicy method. If the <c>POINTERINACTIVE_ACTIVATEONDRAG</c> value is set, the
	/// container activates the object in-place so the object can register its own IDropTarget interface.
	/// </para>
	/// <para>
	/// The container is processing its own IDropTarget::DragOver method when all these actions occur. To complete that method, the
	/// container returns <c>DROPEFFECT_NONE</c> for the pdwEffect parameter. Then, the drag and drop operation continues by calling the
	/// container's IDropTarget::DragLeave and then calling the object's IDropTarget::DragEnter.
	/// </para>
	/// <para>
	/// <c>Important</c> For windowless OLE objects this mechanism is slightly different. See IOleInPlaceSiteWindowless for more
	/// information on drag and drop operations for windowless objects.
	/// </para>
	/// <para>
	/// If the drop occurs on the embedded object, the object is UI-activated and will get UI-deactivated when the focus changes again.
	/// If the drop does not occur on the object, the container should deactivate the object the next time it gets a call to its own
	/// IDropTarget::DragEnter. It is possible for the drop to occur on a third active object without an intervening call to the
	/// container's IDropTarget::DragEnter. In this case, the container should try to deactivate the object as soon as it can, for
	/// example, when it UI-activates another object.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/ne-ocidl-pointerinactive typedef enum tagPOINTERINACTIVE {
	// POINTERINACTIVE_ACTIVATEONENTRY, POINTERINACTIVE_DEACTIVATEONLEAVE, POINTERINACTIVE_ACTIVATEONDRAG } POINTERINACTIVE;
	[PInvokeData("ocidl.h", MSDNShortId = "NE:ocidl.tagPOINTERINACTIVE")]
	[Flags]
	public enum POINTERINACTIVE
	{
		/// <summary>The object should be in-place activated when the mouse enters it during a mouse move operation.</summary>
		POINTERINACTIVE_ACTIVATEONENTRY = 0x01,

		/// <summary>The object should be deactivated when the mouse leaves the object during a mouse move operation.</summary>
		POINTERINACTIVE_DEACTIVATEONLEAVE = 0x02,

		/// <summary>The object should be in-place activated when the mouse is dragged over it during a drag and drop operation.</summary>
		POINTERINACTIVE_ACTIVATEONDRAG = 0x04,
	}

	/// <summary>Indicates the changes that have occurred.</summary>
	[PInvokeData("ocidl.h", MSDNShortId = "NN:ocidl.IPropertyPageSite")]
	public enum PROPPAGESTATUS
	{
		/// <summary>The values in the pages have changed, so the state of the Apply button should be updated.</summary>
		PROPPAGESTATUS_DIRTY = 0x01,

		/// <summary>Now is an appropriate time to apply changes.</summary>
		PROPPAGESTATUS_VALIDATE = 0x02,

		/// <summary/>
		PROPPAGESTATUS_CLEAN = 0x04
	}

	/// <summary>
	/// Indicates ambient properties supplied by the container. It is used in the <c>dwAmbientFlags</c> member of the QACONTAINER structure.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/ne-ocidl-qacontainerflags typedef enum tagQACONTAINERFLAGS {
	// QACONTAINER_SHOWHATCHING, QACONTAINER_SHOWGRABHANDLES, QACONTAINER_USERMODE, QACONTAINER_DISPLAYASDEFAULT, QACONTAINER_UIDEAD,
	// QACONTAINER_AUTOCLIP, QACONTAINER_MESSAGEREFLECT, QACONTAINER_SUPPORTSMNEMONICS } QACONTAINERFLAGS;
	[PInvokeData("ocidl.h", MSDNShortId = "NE:ocidl.tagQACONTAINERFLAGS")]
	[Flags]
	public enum QACONTAINERFLAGS
	{
		/// <summary>Specifies the ShowHatching ambient property, which has a standard ambient DISPID of -712.</summary>
		QACONTAINER_SHOWHATCHING = 0x01,

		/// <summary>Specifies the ShowGrabHandles ambient property, which has a standard ambient DISPID of -711.</summary>
		QACONTAINER_SHOWGRABHANDLES = 0x02,

		/// <summary>Specifies the UserMode ambient property, which has a standard ambient DISPID of -709.</summary>
		QACONTAINER_USERMODE = 0x04,

		/// <summary>Specifies the DisplayAsDefault ambient property, which has a standard ambient DISPID of -713.</summary>
		QACONTAINER_DISPLAYASDEFAULT = 0x08,

		/// <summary>Specifies the UIDead ambient property, which has a standard ambient DISPID of -710.</summary>
		QACONTAINER_UIDEAD = 0x10,

		/// <summary>Specifies the AutoClip ambient property, which has a standard ambient DISPID of -715.</summary>
		QACONTAINER_AUTOCLIP = 0x20,

		/// <summary>Specifies the MessageReflect ambient property, which has a standard ambient DISPID of -706.</summary>
		QACONTAINER_MESSAGEREFLECT = 0x40,

		/// <summary>Specifies the SupportsMnemonics ambient property, which has a standard ambient DISPID of -714.</summary>
		QACONTAINER_SUPPORTSMNEMONICS = 0x80,
	}

	/// <summary>
	/// <para>This property is read-only with no default value.</para>
	/// <para>Returns an integer value representing the control's ReadyState.</para>
	/// <para>Any object embedded in a Web page exposes the
	/// <code>ReadyState</code>
	/// property.
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>This property is read-only with no default value.</para>
	/// <para>Returns an integer value representing the control's ReadyState.</para>
	/// <para>Any object embedded in a Web page exposes the
	/// <code>ReadyState</code>
	/// property.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/ne-ocidl-readystate typedef enum tagREADYSTATE {
	// READYSTATE_UNINITIALIZED, READYSTATE_LOADING, READYSTATE_LOADED, READYSTATE_INTERACTIVE, READYSTATE_COMPLETE } READYSTATE;
	[PInvokeData("ocidl.h", MSDNShortId = "NE:ocidl.tagREADYSTATE")]
	public enum READYSTATE
	{
		/// <summary>Default initialization state.</summary>
		READYSTATE_UNINITIALIZED = 0,

		/// <summary>Object is loading its properties.</summary>
		READYSTATE_LOADING,

		/// <summary>Object has been initialized.</summary>
		READYSTATE_LOADED,

		/// <summary>Object is interactive, but not all its data is available.</summary>
		READYSTATE_INTERACTIVE,

		/// <summary>Object has received all its data.</summary>
		READYSTATE_COMPLETE,
	}

	/// <summary>Provides information about the parent undo unit.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/ne-ocidl-uasflags typedef enum tagUASFLAGS { UAS_NORMAL, UAS_BLOCKED,
	// UAS_NOPARENTENABLE, UAS_MASK } UASFLAGS;
	[PInvokeData("ocidl.h", MSDNShortId = "NE:ocidl.tagUASFLAGS")]
	[Flags]
	public enum UASFLAGS
	{
		/// <summary>
		/// The currently open parent undo unit is in a normal, unblocked state and can accept any new units added through calls to its
		/// Open or Add methods.
		/// </summary>
		UAS_NORMAL = 0x00,

		/// <summary>
		/// The currently open undo unit is blocked and will reject any undo units added through calls to its IOleParentUndoUnit::Open
		/// or IOleParentUndoUnit::Add methods. The caller need not create any new units since they will just be rejected.
		/// </summary>
		UAS_BLOCKED = 0x01,

		/// <summary>
		/// The currently open undo unit will accept new units, but the caller should act like there is no currently open unit. This
		/// means that if the new unit being created requires a parent, then this parent does not satisfy that requirement and the undo
		/// stack should be cleared.
		/// </summary>
		UAS_NOPARENTENABLE = 0x02,

		/// <summary>
		/// When checking for a normal state, use this value to mask unused bits in the pdwState parameter to the
		/// IOleParentUndoUnit::GetParentState method for future compatibility. For example:
		/// </summary>
		UAS_MASK = 0x03,
	}

	/// <summary>Specifies the opacity of the object and the drawing aspects supported by the object.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/ne-ocidl-viewstatus typedef enum tagVIEWSTATUS { VIEWSTATUS_OPAQUE,
	// VIEWSTATUS_SOLIDBKGND, VIEWSTATUS_DVASPECTOPAQUE, VIEWSTATUS_DVASPECTTRANSPARENT, VIEWSTATUS_SURFACE, VIEWSTATUS_3DSURFACE } VIEWSTATUS;
	[PInvokeData("ocidl.h", MSDNShortId = "NE:ocidl.tagVIEWSTATUS")]
	[Flags]
	public enum VIEWSTATUS
	{
		/// <summary>
		/// The object is completely opaque. So, for any aspect, it promises to draw the entire rectangle passed to the
		/// IViewObject::Draw method. If this value is not set, the object contains transparent parts. If it also support
		/// DVASPECT_TRANSPARENT, then this aspect may be used to draw the transparent parts only.This bit applies only to CONTENT
		/// related aspects and not to DVASPECT_ICON or DVASPECT_DOCPRINT.
		/// </summary>
		VIEWSTATUS_OPAQUE = 0x01,

		/// <summary>
		/// The object has a solid background (consisting in a solid color, not a brush pattern). This bit is meaningful only if
		/// VIEWSTATUS_OPAQUE is set.This bit applies only to CONTENT related aspects and not to DVASPECT_ICON or DVASPECT_DOCPRINT.
		/// </summary>
		VIEWSTATUS_SOLIDBKGND = 0x02,

		/// <summary>
		/// The object supports DVASPECT_OPAQUE. All IViewObjectEx methods taking a drawing aspect as a parameter can be called with
		/// this aspect.
		/// </summary>
		VIEWSTATUS_DVASPECTOPAQUE = 0x04,

		/// <summary>
		/// The object supports DVASPECT_TRANSPARENT. All IViewObjectEx methods taking a drawing aspect as a parameter can be called
		/// with this aspect.
		/// </summary>
		VIEWSTATUS_DVASPECTTRANSPARENT = 0x08,

		/// <summary>The object supports a 2-dimensional surface.</summary>
		VIEWSTATUS_SURFACE = 0x10,

		/// <summary>The object supports a 3-dimensional surface.</summary>
		VIEWSTATUS_3DSURFACE = 0x20,
	}

	/// <summary>
	/// Flags indicating the exact conversion to perform. This parameter can be any combination of the following values, except as indicated.
	/// </summary>
	[PInvokeData("ocidl.h", MSDNShortId = "NN:ocidl.IOleControlSite")]
	public enum XFORMCOORDS
	{
		/// <summary>The coordinates to convert represent a position point. Cannot be used with XFORMCOORDS_SIZE.</summary>
		XFORMCOORDS_POSITION = 0x1,

		/// <summary>The coordinates to convert represent a set of dimensions. Cannot be used with XFORMCOORDS_POSITION.</summary>
		XFORMCOORDS_SIZE = 0x2,

		/// <summary>The operation converts pptlHimetric into pptfContainer. Cannot be used with XFORMCOORDS_CONTAINERTOHIMETRIC.</summary>
		XFORMCOORDS_HIMETRICTOCONTAINER = 0x4,

		/// <summary>The operation converts pptfContainer into pptlHimetric. Cannot be used with XFORMCOORDS_HIMETRICTOCONTAINER.</summary>
		XFORMCOORDS_CONTAINERTOHIMETRIC = 0x8,

		/// <summary>The operation maintains compatibility with an event.</summary>
		XFORMCOORDS_EVENTCOMPAT = 0x10
	}

	/// <summary>
	/// This interface is derived from IAdviseSink to provide extensions for notifying the sink of changes in an object's view status.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nn-ocidl-iadvisesinkex
	[PInvokeData("ocidl.h", MSDNShortId = "NN:ocidl.IAdviseSinkEx")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("3AF24290-0C96-11CE-A0CF-00AA00600AB8")]
	public interface IAdviseSinkEx : IAdviseSink
	{
		/// <summary>
		/// Called by the server to notify a data object's currently registered advise sinks that data in the object has changed.
		/// </summary>
		/// <param name="pFormatetc">
		/// A pointer to a FORMATETC structure, which describes the format, target device, rendering, and storage information of the
		/// calling data object.
		/// </param>
		/// <param name="pStgmed">
		/// A pointer to a STGMEDIUM structure, which defines the storage medium (global memory, disk file, storage object, stream
		/// object, GDI object, or undefined) and ownership of that medium for the calling data object.
		/// </param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// Object handlers and containers of link objects implement <c>IAdviseSink::OnDataChange</c> to take appropriate steps when
		/// notified that data in the object has changed. They also must call IDataObject::DAdvise to set up advisory connections with
		/// the objects in whose data they are interested.
		/// </para>
		/// <para>
		/// Containers that take advantage of OLE's caching support do not need to register for data-change notifications, because the
		/// information necessary to update the container's presentation of the object, including any changes in its data, are
		/// maintained in the object's cache.
		/// </para>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// If you implement <c>IAdviseSink::OnDataChange</c> for a container, remember that this method is asynchronous and that making
		/// synchronous calls within asynchronous methods is not valid. Therefore, you cannot call IDataObject::GetData to obtain the
		/// data you need to update your object. Instead, you either post an internal message, or invalidate the rectangle for the
		/// changed data by calling InvalidateRect and waiting for a WM_PAINT message, at which point you are free to get the data and
		/// update the object.
		/// </para>
		/// <para>
		/// The data itself, which is valid only for the duration of the call, is passed using the storage medium pointed to by pStgmed.
		/// Since the caller owns the medium, the advise sink should not free it. Also, if pStgmed points to an IStorage or IStream
		/// interface, the sink must not increment the reference count.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-iadvisesink-ondatachange void OnDataChange( FORMATETC
		// *pFormatetc, STGMEDIUM *pStgmed );
		[PreserveSig]
		void OnDataChange(in FORMATETC pFormatetc, in STGMEDIUM pStgmed);

		/// <summary>Notifies an object's registered advise sinks that its view has changed.</summary>
		/// <param name="dwAspect">The aspect, or view, of the object. Contains a value taken from the DVASPECT enumeration.</param>
		/// <param name="lindex">The portion of the view that has changed. Currently only -1 is valid.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// Containers register to be notified when an object's view changes by calling IViewObject::SetAdvise. After it is registered,
		/// the object will call the sink's <c>IAdviseSink::OnViewChange</c> method when appropriate. <c>OnViewChange</c> can be called
		/// when the object is in either the loaded or running state.
		/// </para>
		/// <para>
		/// Even though DVASPECT values are individual flag bits, dwAspect may represent only one value. That is, dwAspect cannot
		/// contain the result of an OR operation combining two or more <c>DVASPECT</c> values.
		/// </para>
		/// <para>
		/// The lindex parameter represents the part of the aspect that is of interest. The value of lindex depends on the value of
		/// dwAspect. If dwAspect is either DVASPECT_THUMBNAIL or DVASPECT_ICON, lindex is ignored. If dwAspect is DVASPECT_CONTENT,
		/// lindex must be -1, which indicates that the entire view is of interest and is the only value that is currently valid.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-iadvisesink-onviewchange void OnViewChange( DWORD
		// dwAspect, LONG lindex );
		[PreserveSig]
		void OnViewChange(DVASPECT dwAspect, int lindex);

		/// <summary>Called by the server to notify all registered advisory sinks that the object has been renamed.</summary>
		/// <param name="pmk">A pointer to the IMoniker interface on the new full moniker of the object.</param>
		/// <returns>None</returns>
		/// <remarks>
		/// OLE link objects normally implement <c>IAdviseSink::OnRename</c> to receive notification of a change in the name of a link
		/// source or its container. The object serving as the link source calls <c>OnRename</c> and passes its new full moniker to the
		/// object handler, which forwards the notification to the link object. In response, the link object must update its moniker.
		/// The link object, in turn, forwards the notification to its own container.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-iadvisesink-onrename void OnRename( IMoniker *pmk );
		[PreserveSig]
		new void OnRename(IMoniker pmk);

		/// <summary>Called by the server to notify all registered advisory sinks that the object has been saved.</summary>
		/// <returns>None</returns>
		/// <remarks>
		/// Object handlers and link objects normally implement <c>IAdviseSink::OnSave</c> to receive notifications of when an object is
		/// saved to disk, either to its original storage (through a <c>Save</c> operation) or to new storage (through a <c>Save As</c>
		/// operation). Object Handlers and link objects register to be notified when an object is saved for the purpose of updating
		/// their caches, but then only if the advise flag passed during registration specifies ADVFCACHE_ONSAVE. Object handlers and
		/// link objects forward these notifications to their containers.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-iadvisesink-onsave void OnSave();
		[PreserveSig]
		new void OnSave();

		/// <summary>
		/// Called by the server to notify all registered advisory sinks that the object has changed from the running to the loaded state.
		/// </summary>
		/// <returns>None</returns>
		/// <remarks>
		/// <para>
		/// The <c>OnClose</c> notification indicates that an object is making the transition from the running to the loaded state, so
		/// its container can take appropriate measures to ensure an orderly shutdown. For example, an object handler must release its
		/// pointer to the object.
		/// </para>
		/// <para>
		/// If the object that is closing is the last open object supported by its OLE server application, the application can also shut down.
		/// </para>
		/// <para>
		/// In the case of a link object, the notification that the object is closing should always be interpreted to mean that the
		/// connection to the link source has broken.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/objidl/nf-objidl-iadvisesink-onclose void OnClose();
		[PreserveSig]
		new void OnClose();

		/// <summary>Notifies the sink that a view status of an object has changed.</summary>
		/// <param name="dwViewStatus">The new view status. Possible values are from the VIEWSTATUS enumeration.</param>
		/// <returns>This method returns S_OK on success.</returns>
		/// <remarks>
		/// It is important that objects call the IAdviseSink:OnViewChange method whenever the object's view changes even when the
		/// object is in place active. Containers rely on this notification to keep an object's view up-to-date.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-iadvisesinkex-onviewstatuschange void OnViewStatusChange(
		// DWORD dwViewStatus );
		[PreserveSig]
		void OnViewStatusChange(VIEWSTATUS dwViewStatus);
	}

	/// <summary>
	/// <para>Enables a class factory object, in any sort of object server, to control object creation through licensing.</para>
	/// <para>
	/// This interface is an extension to IClassFactory. This extension enables a class factory executing on a licensed machine to
	/// provide a license key that can be used later to create an object instance on an unlicensed machine. Such considerations are
	/// important for objects like controls that are used to build applications on a licensed machine. Subsequently, the application
	/// built must be able to run on an unlicensed machine. The license key gives only that one client application the right to
	/// instantiate objects through <c>IClassFactory2</c> when a full machine license does not exist.
	/// </para>
	/// </summary>
	/// <seealso cref="IClassFactory"/>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ocidl/nn-ocidl-iclassfactory2
	[PInvokeData("ocidl.h", MSDNShortId = "c49c7612-3b1f-4535-baf3-8458b3f34f95")]
	[ComImport, Guid("B196B28F-BAB4-101A-B69C-00AA00341D07"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IClassFactory2 : IClassFactory
	{
		/// <summary>Creates an uninitialized object.</summary>
		/// <param name="pUnkOuter">
		/// If the object is being created as part of an aggregate, specify a pointer to the controlling IUnknown interface of the
		/// aggregate. Otherwise, this parameter must be <c>NULL</c>.
		/// </param>
		/// <param name="riid">
		/// A reference to the identifier of the interface to be used to communicate with the newly created object. If pUnkOuter is
		/// <c>NULL</c>, this parameter is generally the IID of the initializing interface; if pUnkOuter is non- <c>NULL</c>, riid must
		/// be IID_IUnknown.
		/// </param>
		/// <param name="ppvObject">
		/// The address of pointer variable that receives the interface pointer requested in riid. Upon successful return, *ppvObject
		/// contains the requested interface pointer. If the object does not support the interface specified in riid, the implementation
		/// must set *ppvObject to <c>NULL</c>.
		/// </param>
		/// <returns>
		/// <para>
		/// This method can return the standard return values E_INVALIDARG, E_OUTOFMEMORY, and E_UNEXPECTED, as well as the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The specified object was created.</term>
		/// </item>
		/// <item>
		/// <term>CLASS_E_NOAGGREGATION</term>
		/// <term>The pUnkOuter parameter was non-NULL and the object does not support aggregation.</term>
		/// </item>
		/// <item>
		/// <term>E_NOINTERFACE</term>
		/// <term>The object that ppvObject points to does not support the interface identified by riid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A COM server's implementation of <c>CreateInstance</c> must return a reference to an object contained in an apartment that
		/// belongs to the server's DCOM resolver. It must not return a reference to an object that is contained in a remote apartment.
		/// </para>
		/// <para>
		/// The IClassFactory interface is always on a class object. The <c>CreateInstance</c> method creates an uninitialized object of
		/// the class identified with the specified CLSID. When an object is created in this way, the CLSID must be registered in the
		/// system registry with the CoRegisterClassObject function.
		/// </para>
		/// <para>
		/// The pUnkOuter parameter indicates whether the object is being created as part of an aggregate. Object definitions are not
		/// required to support aggregation â€” they must be specifically designed and implemented to support it.
		/// </para>
		/// <para>
		/// The riid parameter specifies the IID (interface identifier) of the interface through which you will communicate with the new
		/// object. If pUnkOuter is non- <c>NULL</c> (indicating aggregation), the value of the riid parameter must be IID_IUnknown. If
		/// the object is not part of an aggregate, riid often specifies the interface though which the object will be initialized.
		/// </para>
		/// <para>
		/// For OLE embeddings, the initialization interface is IPersistStorage, but in other situations, other interfaces are used. To
		/// initialize the object, there must be a subsequent call to an appropriate method in the initializing interface. Common
		/// initialization functions include IPersistStorage::InitNew (for new, blank embeddable components), IPersistStorage::Load (for
		/// reloaded embeddable components), IPersistStream::Load, (for objects stored in a stream object) or IPersistFile::Load (for
		/// objects stored in a file).
		/// </para>
		/// <para>
		/// In general, if an application supports only one class of objects, and the class object is registered for single use, only
		/// one object can be created. The application must not create other objects, and a request to do so should return an error from
		/// <c>IClassFactory::CreateInstance</c>. The same is true for applications that support multiple classes, each with a class
		/// object registered for single use; a call to <c>CreateInstance</c> for one class followed by a call to <c>CreateInstance</c>
		/// for any of the classes that should return an error.
		/// </para>
		/// <para>
		/// To avoid returning an error, applications that support multiple classes with single-use class objects can revoke the
		/// registered class object of the first class by calling CoRevokeClassObject when a request for instantiating a second is
		/// received. For example, suppose there are two classes, A and B. When <c>CreateInstance</c> is called for class A, revoke the
		/// class object for B. When B is created, revoke the class object for A. This solution complicates shutdown because one of the
		/// class objects might have already been revoked (and cannot be revoked twice).
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/unknwn/nf-unknwn-iclassfactory-createinstance HRESULT CreateInstance(
		// IUnknown *pUnkOuter, REFIID riid, void **ppvObject );
		[PreserveSig]
		new HRESULT CreateInstance([In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? pUnkOuter, in Guid riid,
			[MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object? ppvObject);

		/// <summary>Locks an object application open in memory. This enables instances to be created more quickly.</summary>
		/// <param name="fLock">If <c>TRUE</c>, increments the lock count; if <c>FALSE</c>, decrements the lock count.</param>
		/// <returns>This method can return the standard return values E_OUTOFMEMORY, E_UNEXPECTED, E_FAIL, and S_OK.</returns>
		/// <remarks>
		/// <para>
		/// <c>IClassFactory::LockServer</c> controls whether an object's server is kept in memory. Keeping the application alive in
		/// memory allows instances to be created more quickly.
		/// </para>
		/// <para>Notes to Callers</para>
		/// <para>
		/// Most clients do not need to call this method. It is provided only for those clients that require special performance in
		/// creating multiple instances of their objects.
		/// </para>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// If the lock count is zero, there are no more objects in use, and the application is not under user control, the server can
		/// be closed. One way to implement <c>LockServer</c> is to call the CoLockObjectExternal function.
		/// </para>
		/// <para>
		/// The process that locks the object application is responsible for unlocking it. After the class object is released, there is
		/// no mechanism that guarantees the caller connection to the same class later (as in the case where a class object is
		/// registered as single-use). It is important to count all calls, not just the last one, to <c>LockServer</c>, because calls
		/// must be balanced before attempting to release the pointer to the IClassFactory interface on the class object or an error
		/// results. For every call to <c>LockServer</c> with fLock set to <c>TRUE</c>, there must be a call to <c>LockServer</c> with
		/// fLock set to <c>FALSE</c>. When the lock count and the class object reference count are both zero, the class object can be freed.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/unknwnbase/nf-unknwnbase-iclassfactory-lockserver HRESULT LockServer(
		// BOOL fLock );
		[PreserveSig]
		new HRESULT LockServer([MarshalAs(UnmanagedType.Bool)] bool fLock);

		/// <summary>Retrieves information about the licensing capabilities of this class factory.</summary>
		/// <param name="pLicInfo">A pointer to the caller-allocated LICINFO structure to be filled on output.</param>
		/// <returns>
		/// <para>This method can return the standard return values E_UNEXPECTED, as well as the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The LICINFO structure was successfully filled in.</term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>The address in pLicInfo is not valid. For example, it may be NULL.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// E_NOTIMPL is not allowed as a return value because this method provides critical information for the client of a licensed
		/// class factory.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ocidl/nf-ocidl-iclassfactory2-getlicinfo HRESULT GetLicInfo( LICINFO
		// *pLicInfo );
		[PreserveSig]
		HRESULT GetLicInfo(ref LICINFO pLicInfo);

		/// <summary>Creates a license key that the caller can save and use later to create an instance of the licensed object.</summary>
		/// <param name="dwReserved">This parameter is reserved and must be zero.</param>
		/// <param name="pBstrKey">
		/// A pointer to the caller-allocated variable that receives the callee-allocated license key on successful return from this
		/// method. This parameter is set to <c>NULL</c> on any failure.
		/// </param>
		/// <returns>
		/// <para>
		/// This method can return the standard return values E_INVALIDARG, E_OUTOFMEMORY, and E_UNEXPECTED, as well as the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The license key was successfully created.</term>
		/// </item>
		/// <item>
		/// <term>E_NOTIMPL</term>
		/// <term>This class factory does not support run-time license keys.</term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>The address passed in pbstrKey is not valid. For example, it may be NULL.</term>
		/// </item>
		/// <item>
		/// <term>CLASS_E_NOTLICENSED</term>
		/// <term>
		/// This class factory supports run-time licensing, but the current machine itself is not licensed. Thus, a run-time key is not
		/// available on this machine.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The caller can save the license key for subsequent calls to IClassFactory2::CreateInstanceLic to create objects on an
		/// otherwise unlicensed machine.
		/// </para>
		/// <para>Notes to Callers</para>
		/// <para>
		/// The caller must free the <c>BSTR</c> with the SysFreeString function when the key is no longer needed. The value of
		/// fRuntimeKeyAvail is returned through a previous call to IClassFactory2::GetLicInfo.
		/// </para>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// This method allocates the <c>BSTR</c> key with SysAllocString or SysAllocStringLen, and the caller becomes responsible for
		/// this <c>BSTR</c> after this method returns successfully.
		/// </para>
		/// <para>This method need not be implemented when a class factory does not support run-time license keys.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ocidl/nf-ocidl-iclassfactory2-requestlickey HRESULT RequestLicKey( DWORD
		// dwReserved, BSTR *pBstrKey );
		[PreserveSig]
		HRESULT RequestLicKey([Optional] uint dwReserved, [MarshalAs(UnmanagedType.BStr)] out string? pBstrKey);

		/// <summary>
		/// Creates an instance of the licensed object for the specified license key. This method is the only possible means to create
		/// an object on an otherwise unlicensed machine.
		/// </summary>
		/// <param name="pUnkOuter">
		/// A pointer to the controlling IUnknown interface on the outer unknown if this object is being created as part of an
		/// aggregate. If the object is not part of an aggregate, this parameter must be <c>NULL</c>.
		/// </param>
		/// <param name="pUnkReserved">This parameter is unused and must be <c>NULL</c>.</param>
		/// <param name="riid">A reference to the identifier of the interface to be used to communicate with the newly created object.</param>
		/// <param name="bstrKey">
		/// Run-time license key previously obtained from IClassFactory2::RequestLicKey that is required to create an object.
		/// </param>
		/// <param name="ppvObj">
		/// Address of pointer variable that receives the interface pointer requested in riid. Upon successful return, *ppvObj contains
		/// the requested interface pointer. If an error occurs, the implementation must set *ppvObj to <c>NULL</c>.
		/// </param>
		/// <returns>
		/// <para>
		/// This method can return the standard return values E_INVALIDARG, E_OUTOFMEMORY, and E_UNEXPECTED, as well as the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The license was successfully created.</term>
		/// </item>
		/// <item>
		/// <term>E_NOTIMPL</term>
		/// <term>This method is not implemented because objects can only be created on fully licensed machines through IClassFactory::CreateInstance.</term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>A pointer passed in bstrKey or ppvObj is not valid. For example, it may be NULL.</term>
		/// </item>
		/// <item>
		/// <term>E_NOINTERFACE</term>
		/// <term>
		/// The object can be created (and the license key is valid) except the object does not support the interface specified by riid.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CLASS_E_NOAGGREGATION</term>
		/// <term>The pUnkOuter parameter is non-NULL, but this object class does not support aggregation.</term>
		/// </item>
		/// <item>
		/// <term>CLASS_E_NOTLICENSED</term>
		/// <term>The key provided in bstrKey is not a valid license key.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// If the class factory does not provide a license key (that is, IClassFactory2::RequestLicKey returns E_NOTIMPL and the
		/// <c>fRuntimeKeyAvail</c> member in LICINFO is set to <c>FALSE</c> in IClassFactory2::GetLicInfo), then this method can also
		/// return E_NOTIMPL. In such cases, the class factory is implementing IClassFactory2 simply to specify whether the machine is
		/// licensed at all through the <c>fLicVerified</c> member of <c>LICINFO</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ocidl/nf-ocidl-iclassfactory2-createinstancelic HRESULT
		// CreateInstanceLic( IUnknown *pUnkOuter, IUnknown *pUnkReserved, REFIID riid, BSTR bstrKey, PVOID *ppvObj );
		[PreserveSig]
		HRESULT CreateInstanceLic([In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? pUnkOuter, [In, Optional, MarshalAs(UnmanagedType.IUnknown)] object? pUnkReserved,
			in Guid riid, [In, MarshalAs(UnmanagedType.BStr)] string bstrKey, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 2)] out object? ppvObj);
	}

	/// <summary>Enumerates the undo units on the undo or redo stack.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nn-ocidl-ienumoleundounits
	[PInvokeData("ocidl.h", MSDNShortId = "NN:ocidl.IEnumOleUndoUnits")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("B3E7C340-EF97-11CE-9BC9-00AA00608E01")]
	public interface IEnumOleUndoUnits : Vanara.Collections.ICOMEnum<IOleUndoUnit>
	{
		/// <summary>Retrieves the specified number of items in the enumeration sequence.</summary>
		/// <param name="cElt">
		/// The number of items to be retrieved. If there are fewer than the requested number of items left in the sequence, this method
		/// retrieves the remaining elements.
		/// </param>
		/// <param name="rgElt">
		/// <para>An array of enumerated items.</para>
		/// <para>
		/// The enumerator is responsible for calling AddRef, and the caller is responsible for calling Release through each pointer
		/// enumerated. If cElt is greater than 1, the caller must also pass a non-NULL pointer passed to pcEltFetched to know how many
		/// pointers to release.
		/// </para>
		/// </param>
		/// <param name="pcEltFetched">
		/// The number of items that were retrieved. This parameter is always less than or equal to the number of items requested.
		/// </param>
		/// <returns>If the method retrieves the number of items requested, the return value is S_OK. Otherwise, it is S_FALSE.</returns>
		/// <remarks>
		/// <para>
		/// The caller is responsible for calling the Release method for each element in the array once this method returns
		/// successfully. If cUndoUnits is greater than one, the caller must also pass a non-NULL pointer to pcFetched to get the number
		/// of pointers it has to release.
		/// </para>
		/// <para>
		/// E_NOTIMPL is not allowed as a return value. If an error value is returned, no entries in the rgpcd array are valid on exit
		/// and require no release.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ienumoleundounits-next HRESULT Next( ULONG cElt,
		// IOleUndoUnit **rgElt, ULONG *pcEltFetched );
		[PreserveSig]
		HRESULT Next(uint cElt, [Out, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.Interface, SizeParamIndex = 0)] IOleUndoUnit[] rgElt, out uint pcEltFetched);

		/// <summary>Skips over the specified number of items in the enumeration sequence.</summary>
		/// <param name="cElt">The number of items to be skipped.</param>
		/// <returns>If the method skips the number of items requested, the return value is S_OK. Otherwise, it is S_FALSE.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ienumoleundounits-skip HRESULT Skip( ULONG cElt );
		[PreserveSig]
		HRESULT Skip(uint cElt);

		/// <summary>Resets the enumeration sequence to the beginning.</summary>
		/// <returns>This method returns S_OK on success.</returns>
		/// <remarks>
		/// There is no guarantee that the same set of objects will be enumerated after the reset operation has completed. A static
		/// collection is reset to the beginning, but it can be too expensive for some collections, such as files in a directory, to
		/// guarantee this condition.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ienumoleundounits-reset HRESULT Reset();
		[PreserveSig]
		HRESULT Reset();

		/// <summary>
		/// <para>Creates a new enumerator that contains the same enumeration state as the current one.</para>
		/// <para>
		/// This method makes it possible to record a particular point in the enumeration sequence and then return to that point at a
		/// later time. The caller must release this new enumerator separately from the first enumerator.
		/// </para>
		/// </summary>
		/// <param name="ppEnum">
		/// A pointer to the IEnumOleUndoUnits interface pointer on the newly created enumerator. The caller must release this
		/// enumerator separately from the one from which it was cloned.
		/// </param>
		/// <returns>
		/// <para>This method returns S_OK on success. Other possible values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_UNEXPECTED</term>
		/// <term>An unexpected error has occurred.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The specified enumerator is invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>Insufficient memory available for this operation.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ienumoleundounits-clone HRESULT Clone( IEnumOleUndoUnits
		// **ppEnum );
		[PreserveSig]
		HRESULT Clone(out IEnumOleUndoUnits ppEnum);
	}

	/// <summary>
	/// <para>
	/// Provides a wrapper around a Windows font object. The COM font object supports a number of read/write properties as well as a set
	/// of methods through its <c>IFont</c> interface. It supports the same set of properties (but not the methods) through the dispatch
	/// interface IFontDisp, which is derived from <c>IDispatch</c> to provide access to the font's properties through Automation. The
	/// system provides a standard implementation of the font object with both interfaces.
	/// </para>
	/// <para>
	/// The font object also supports the outgoing interface IPropertyNotifySink so a client can determine when font properties change.
	/// Because the font object supports at least one outgoing interface, it also implements IConnectionPointContainer and related
	/// interfaces for this purpose.
	/// </para>
	/// <para>
	/// The font object provides an hFont property, which is a Windows font handle that conforms to the other attributes specified for
	/// the font. The font object delays realizing this hFont object when possible, so consecutively setting two properties on a font
	/// will not cause an intermediate font to be realized. In addition, as an optimization, the system-implemented font object
	/// maintains a cache of font handles. Two font objects in the same process that have identical properties will return the same font
	/// handle. The font object can remove font handles from this cache at will, which introduces special considerations for clients
	/// using the hFont property.
	/// </para>
	/// <para>
	/// The font object also supports IPersistStream so that it can save and load itself from an instance of IStream. An object that
	/// uses a font object internally would normally save and load the font as part of the object's own persistence handling.
	/// </para>
	/// <para>
	/// In addition, the font object supports IDataObject, which can render a property set containing the font's attributes, allowing a
	/// client to save these properties as text.
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// Each property in the <c>IFont</c> interface includes a <c>get_PropertyName</c> method if the property supports read access and a
	/// <c>put_PropertyName</c> method if the property supports write access. Most of these properties support both read and write access.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Property</term>
	/// <term>Type</term>
	/// <term>Read Access Method</term>
	/// <term>Write Access Method</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>Name</term>
	/// <term>BSTR</term>
	/// <term>get_Name</term>
	/// <term>put_Name</term>
	/// <term>The facename of the font, e.g. Arial.</term>
	/// </item>
	/// <item>
	/// <term>Size</term>
	/// <term>CY</term>
	/// <term>get_Size</term>
	/// <term>put_Size</term>
	/// <term>The point size of the font, expressed in a CY type to allow for fractional point sizes.</term>
	/// </item>
	/// <item>
	/// <term>Bold</term>
	/// <term>BOOL</term>
	/// <term>get_Bold</term>
	/// <term>put_Bold</term>
	/// <term>Indicates whether the font is boldfaced.</term>
	/// </item>
	/// <item>
	/// <term>Italic</term>
	/// <term>BOOL</term>
	/// <term>get_Italic</term>
	/// <term>put_Italic</term>
	/// <term>Indicates whether the font is italicized.</term>
	/// </item>
	/// <item>
	/// <term>Underline</term>
	/// <term>BOOL</term>
	/// <term>get_Underline</term>
	/// <term>put_Underline</term>
	/// <term>Indicates whether the font is underlined.</term>
	/// </item>
	/// <item>
	/// <term>Strikethrough</term>
	/// <term>BOOL</term>
	/// <term>get_Strikethrough</term>
	/// <term>put_Strikethrough</term>
	/// <term>Indicates whether the font is strikethrough.</term>
	/// </item>
	/// <item>
	/// <term>Weight</term>
	/// <term>short</term>
	/// <term>get_Weight</term>
	/// <term>put_Weight</term>
	/// <term>The boldness of the font.</term>
	/// </item>
	/// <item>
	/// <term>Charset</term>
	/// <term>short</term>
	/// <term>get_Charset</term>
	/// <term>put_Charset</term>
	/// <term>The character set used in the font, such as ANSI_CHARSET, DEFAULT_CHARSET, or SYMBOL_CHARSET.</term>
	/// </item>
	/// <item>
	/// <term>hFont</term>
	/// <term>HFONT</term>
	/// <term>get_hFont</term>
	/// <term/>
	/// <term>The Windows font handle that can be selected into a device context for rendering.</term>
	/// </item>
	/// </list>
	/// <para>OLE Implementation</para>
	/// <para>
	/// The system provides a standard implementation of a font object with the <c>IFont</c> interface on top of the underlying system
	/// font support. A font object is created through the function OleCreateFontIndirect. A font object supports a number of read/write
	/// properties as well as a set of methods through its <c>IFont</c> interface and supports the same set of properties (but not the
	/// methods) through a dispatch interface IFontDisp which is derived from <c>IDispatch</c> to provide access to the font's
	/// properties through Automation. The system implementation of the font object supplies both interfaces.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nn-ocidl-ifont
	[PInvokeData("ocidl.h", MSDNShortId = "NN:ocidl.IFont")]
	[ComImport, Guid("BEF6E002-A874-101A-8BBA-00AA00300CAB"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IFont
	{
		/// <summary>Retrieves the name of the font family.</summary>
		/// <param name="pName">
		/// A pointer to the caller-allocated variable that receives the name. This string must be freed with <c>SysFreeString</c> when
		/// it is no longer needed.
		/// </param>
		/// <returns>
		/// <para>The method supports the standard return value <c>E_UNEXPECTED</c>, as well as the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The name was returned successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>The address in the pname parameter is not valid. For example, it may be NULL.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ifont-get_name HRESULT get_Name( BSTR *pName );
		[PreserveSig]
		HRESULT get_Name([MarshalAs(UnmanagedType.BStr)] out string pName);

		/// <summary>Specifies a new name for the font family.</summary>
		/// <param name="name">The new name of the font family. This value is both allocated and freed by the caller.</param>
		/// <returns>
		/// <para>The method supports the standard return value <c>E_UNEXPECTED</c>, as well as the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The name was changed successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>The address in the name parameter is not valid. For example, it may be NULL.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Notes to Callers</para>
		/// <para>The string value is caller allocated and the caller is responsible for freeing it after this call returns.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ifont-put_name HRESULT put_Name( BSTR name );
		[PreserveSig]
		HRESULT put_Name([MarshalAs(UnmanagedType.BStr)] string name);

		/// <summary>Retrieves the point size of the font.</summary>
		/// <param name="pSize">A pointer to the caller-allocated variable that receives the size, in <c>HIMETRIC</c> units.</param>
		/// <returns>
		/// <para>The method supports the standard return value <c>E_UNEXPECTED</c>, as well as the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The size was retrieved successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>The address in the pSize parameter is not valid. For example, it may be NULL.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ifont-get_size HRESULT get_Size( CY *pSize );
		[PreserveSig]
		HRESULT get_Size(out CY pSize);

		/// <summary>Sets the point size of the font.</summary>
		/// <param name="size">The new size of the font, in <c>HIMETRIC</c> units.</param>
		/// <returns>
		/// <para>The method supports the standard return value <c>E_UNEXPECTED</c>, as well as the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The font was resized successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>The value of the size parameter is not valid. For example, it does not contain a usable font size.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ifont-put_size HRESULT put_Size( CY size );
		[PreserveSig]
		HRESULT put_Size(CY size);

		/// <summary>Gets the font's current Bold property.</summary>
		/// <param name="pBold">A pointer to a caller-allocated variable that receives the current Bold property for the font.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>
		/// The state was retrieved successfully. If the state is indeterminate, a font object should set *pBold to FALSE and return S_OK.
		/// </term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>The address in pBold is not valid. For example, it may be NULL.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ifont-get_bold HRESULT get_Bold( BOOL *pBold );
		[PreserveSig]
		HRESULT get_Bold([MarshalAs(UnmanagedType.Bool)] out bool pBold);

		/// <summary>Sets the font's Bold property.</summary>
		/// <param name="bold">The new Bold property for the font.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The bold state was changed successfully.</term>
		/// </item>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>The font does not support a bold state. Note that this is not an error condition.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// Changing the Bold property may also change the Weight property. Setting the Bold property to <c>TRUE</c> sets the Weight
		/// property to <c>FW_BOLD</c> (700); setting the Bold property to <c>FALSE</c> sets the Weight property to <c>FW_NORMAL</c> (400).
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ifont-put_bold HRESULT put_Bold( BOOL bold );
		[PreserveSig]
		HRESULT put_Bold([MarshalAs(UnmanagedType.Bool)] bool bold);

		/// <summary>Gets the font's current Italic property.</summary>
		/// <param name="pItalic">A pointer to the caller-allocated variable that receives the current Italic property for the font.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>
		/// The state was retrieved successfully. If the state is indeterminate, a font object should set *pItalic to FALSE and return S_OK.
		/// </term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>The address in pitalic is not valid. For example, it may be NULL.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ifont-get_italic HRESULT get_Italic( BOOL *pItalic );
		[PreserveSig]
		HRESULT get_Italic([MarshalAs(UnmanagedType.Bool)] out bool pItalic);

		/// <summary>Sets the font's Italic property.</summary>
		/// <param name="italic">The new Italic property for the font.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The italic state was changed successfully.</term>
		/// </item>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>The font does not support an italic state. This value is not an error condition.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ifont-put_italic HRESULT put_Italic( BOOL italic );
		[PreserveSig]
		HRESULT put_Italic([MarshalAs(UnmanagedType.Bool)] bool italic);

		/// <summary>Gets the font's current Underline property..</summary>
		/// <param name="pUnderline">
		/// A pointer to the caller-allocated variable that receives the current Underline property for the font.
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>
		/// The state was retrieved successfully. If the state is indeterminate, a font object should set *pUnderline to FALSE and
		/// return S_OK.
		/// </term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>The address in the pUnderline parameter is not valid. For example, it may be NULL.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ifont-get_underline HRESULT get_Underline( BOOL *pUnderline );
		[PreserveSig]
		HRESULT get_Underline([MarshalAs(UnmanagedType.Bool)] out bool pUnderline);

		/// <summary>Sets the font's Underline property.</summary>
		/// <param name="underline">The new Underline property for the font.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The underline state was changed successfully.</term>
		/// </item>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>The font does not support an underline state. This value is not an error condition.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ifont-put_underline HRESULT put_Underline( BOOL underline );
		[PreserveSig]
		HRESULT put_Underline([MarshalAs(UnmanagedType.Bool)] bool underline);

		/// <summary>Gets the font's current Strikethrough property.</summary>
		/// <param name="pStrikethrough">
		/// A pointer to the caller-allocated variable that receives the current Strikethrough property for the font.
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>
		/// The state was retrieved successfully. If the state is indeterminate, a font object should set *pStrikethrough to FALSE and
		/// return S_OK.
		/// </term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>The address in the pStrikethrough parameter is not valid. For example, it may be NULL.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ifont-get_strikethrough HRESULT get_Strikethrough( BOOL
		// *pStrikethrough );
		[PreserveSig]
		HRESULT get_Strikethrough([MarshalAs(UnmanagedType.Bool)] out bool pStrikethrough);

		/// <summary>Sets the font's Strikethrough property.</summary>
		/// <param name="strikethrough">The new Strikethrough property for the font.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The Strikethrough property was changed successfully.</term>
		/// </item>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>The font does not support a strikethrough state. This value is not an error condition.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ifont-put_strikethrough HRESULT put_Strikethrough( BOOL
		// strikethrough );
		[PreserveSig]
		HRESULT put_Strikethrough([MarshalAs(UnmanagedType.Bool)] bool strikethrough);

		/// <summary>Gets the font's current Weight property.</summary>
		/// <param name="pWeight">
		/// A pointer to the caller-allocated variable that receives the current Weight property for the font. For a list of possible
		/// values, see the <c>lfWeight</c> member of the LOGFONT structure.
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term/>
		/// <term>
		/// The weight was retrieved successfully. If the weight is indeterminate, a font object should store FW_NORMAL in *pWeight and
		/// return S_OK.
		/// </term>
		/// </item>
		/// <item>
		/// <term/>
		/// <term>The address in the pWeight parameter is not valid. For example, it may be NULL.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ifont-get_weight HRESULT get_Weight( SHORT *pWeight );
		[PreserveSig]
		HRESULT get_Weight(out short pWeight);

		/// <summary>Sets the font's Weight property.</summary>
		/// <param name="weight">
		/// The new Weight for the font. For a list of available font weights, see the description of the <c>lfWeight</c> member of the
		/// LOGFONT structure.
		/// </param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The Weight property was changed successfully.</term>
		/// </item>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>This font does not support different weights. This value is not an error condition.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// This property may affect the Bold property as well. The Bold property is set to <c>TRUE</c> if the Weight property is
		/// greater than the average of <c>FW_NORMAL</c> (400) and <c>FW_BOLD</c> (700), that is 550.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ifont-put_weight HRESULT put_Weight( SHORT weight );
		[PreserveSig]
		HRESULT put_Weight(short weight);

		/// <summary>Retrieves the character set used in the font. The character set can be any of those defined for Windows fonts.</summary>
		/// <param name="pCharset">A pointer to the caller-allocated variable that receives the character set value.</param>
		/// <returns>
		/// <para>This method can return one of these values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The character set was retrieved successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>The address in the pCharset parameter is not valid. For example, it may be NULL.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ifont-get_charset HRESULT get_Charset( SHORT *pCharset );
		[PreserveSig]
		HRESULT get_Charset(out short pCharset);

		/// <summary>Sets the font's character set.</summary>
		/// <param name="charset">The new character set for the font.</param>
		/// <returns>The method supports the standard return value <c>E_INVALIDARG</c> and S_OK.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ifont-put_charset HRESULT put_Charset( SHORT charset );
		[PreserveSig]
		HRESULT put_Charset(short charset);

		/// <summary>Retrieves a handle to the font described by this font object.</summary>
		/// <param name="phFont">
		/// A pointer to the caller-allocated variable that receives the font handle. The caller does not own this resource and must not
		/// attempt to destroy the font.
		/// </param>
		/// <returns>
		/// <para>
		/// The method supports the standard return values <c>E_UNEXPECTED</c> and <c>E_OUTOFMEMORY</c>, as well as the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The font handle was retrieved successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>The address in the phFont parameter is not valid. For example, it may be NULL.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Notes to Callers</para>
		/// <para>
		/// The font object maintains ownership of the <c>HFONT</c> and can destroy it at any time without prior notification. If the
		/// caller needs to secure this font for a limited period of time, it can call IFont::AddRefHfont and IFont::ReleaseHfont.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ifont-get_hfont HRESULT get_hFont( HFONT *phFont );
		[PreserveSig]
		HRESULT get_hFont(out HFONT phFont);

		/// <summary>Creates a duplicate font object with a state identical to the current font.</summary>
		/// <param name="ppFont">
		/// Address of IFont pointer variable that receives the interface pointer to the new font object. The caller must call
		/// IFont::Release when this new font object is no longer needed.
		/// </param>
		/// <returns>
		/// <para>
		/// The method supports the standard return values <c>E_UNEXPECTED</c> and <c>E_OUTOFMEMORY</c>, as well as the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The new font object was successfully created.</term>
		/// </item>
		/// <item>
		/// <term>E_NOTIMPL</term>
		/// <term>This font object does not support cloning.</term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>The address in ppfont is not valid. For example, it may be NULL.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Notes to Callers</para>
		/// <para>
		/// The new font object is entirely independent of the first. The caller is responsible for releasing this new object when it is
		/// no longer needed. This method does not affect the reference count of the font being cloned.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ifont-clone HRESULT Clone( IFont **ppFont );
		[PreserveSig]
		HRESULT Clone(out IFont ppFont);

		/// <summary>Compares this font object to another for equivalence.</summary>
		/// <param name="pFontOther">
		/// A pointer to the IFont interface on the font object to be compared to this font. The reference count of the object referred
		/// to by this pointer is not affected by the comparison operation.
		/// </param>
		/// <returns>
		/// <para>The method supports the standard return value <c>E_UNEXPECTED</c>, as well as the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The two fonts are equivalent.</term>
		/// </item>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>The two fonts are not equivalent.</term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>The address in the pFontOther parameter is not valid. For example, it may be NULL.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ifont-isequal HRESULT IsEqual( IFont *pFontOther );
		[PreserveSig]
		HRESULT IsEqual(IFont pFontOther);

		/// <summary>
		/// <para>
		/// Converts the scaling factor for this font between logical units and <c>HIMETRIC</c> units. <c>HIMETRIC</c> units are used to
		/// express the point size in the IFont::get_Size and IFont::put_Size methods. The values passed to <c>IFont::SetRatio</c> are
		/// used to compute the display size of the font in logical units from the value in the <c>Size</c> property:
		/// </para>
		/// <para>
		/// <code>Display Size = ( cyLogical / cyHimetric ) * Size</code>
		/// </para>
		/// </summary>
		/// <param name="cyLogical">The font size, in logical units.</param>
		/// <param name="cyHimetric">The font size, in <c>HIMETRIC</c> units.</param>
		/// <returns>The method supports the standard return values E_UNEXPECTED, E_INVALIDARG, and S_OK.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ifont-setratio HRESULT SetRatio( LONG cyLogical, LONG
		// cyHimetric );
		[PreserveSig]
		HRESULT SetRatio(int cyLogical, int cyHimetric);

		/// <summary>Fills a caller-allocated structure with information about the font.</summary>
		/// <param name="pTM">
		/// Pointer to the caller-allocated structure that receives the font information. The <c>TEXTMETRICOLE</c> structure is defined
		/// as a TEXTMETRICW structure.
		/// </param>
		/// <returns>
		/// <para>The method supports the standard return value <c>E_UNEXPECTED</c>, as well as the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The text metrics were returned successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>The address in the ptm parameter is not valid. For example, it may be NULL.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// <c>E_NOTIMPL</c> is not a valid return value. Font objects must always provide their font information through this call
		/// unless other errors occur.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ifont-querytextmetrics HRESULT QueryTextMetrics(
		// TEXTMETRICOLE *pTM );
		[PreserveSig]
		HRESULT QueryTextMetrics(out TEXTMETRIC pTM);

		/// <summary>
		/// Notifies the font object that the previously realized font identified with hFont should remain valid until ReleaseHfont is
		/// called or the font object itself is released completely.
		/// </summary>
		/// <param name="hFont">Font handle previously realized through get_hFont to be locked in the font object's cache.</param>
		/// <returns>
		/// <para>
		/// The method supports the standard return values <c>E_UNEXPECTED</c> and <c>E_INVALIDARG</c>, as well as the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The font was successfully locked in the cache.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ifont-addrefhfont HRESULT AddRefHfont( HFONT hFont );
		[PreserveSig]
		HRESULT AddRefHfont(HFONT hFont);

		/// <summary>
		/// Notifies the font object that the caller that previously locked this font in the cache with IFont::AddRefHfont no longer
		/// requires the lock.
		/// </summary>
		/// <param name="hFont">
		/// A font handle previously realized through IFont::get_hFont. This value was passed to a previous call to IFont::AddRefHfont
		/// to lock the font, and the caller would now like to unlock the font in the cache.
		/// </param>
		/// <returns>
		/// <para>
		/// The method supports the standard return values <c>E_UNEXPECTED</c> and <c>E_INVALIDARG</c>, as well as the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The font was unlocked successfully.</term>
		/// </item>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>
		/// The font was not locked in the cache. This return value is a benign notification to the caller that it may have a font
		/// reference counting problem.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ifont-releasehfont HRESULT ReleaseHfont( HFONT hFont );
		[PreserveSig]
		HRESULT ReleaseHfont(HFONT hFont);

		/// <summary>Provides a device context to the font that describes the logical mapping mode.</summary>
		/// <param name="hDC">A handle to the device context in which to select the font.</param>
		/// <returns>
		/// <para>The method supports the standard return value <c>E_INVALIDARG</c>, as well as the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The font was selected successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_NOTIMPL</term>
		/// <term>The font selection is not supported through this font object.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The logical mapping mode affects the font's internal computation of its point size so that when the caller asks for a font
		/// handle by calling IFont::get_hFont, the font is already properly scaled to the device context.
		/// </para>
		/// <para>Notes to Callers</para>
		/// <para>
		/// The caller retains ownership of this device context which must remain valid for the lifetime of the font object. Thus, the
		/// device context passed should be a memory device context (from the function CreateCompatibleDC) and not a screen device
		/// context (from CreateDC, GetDC, or BeginPaint) because screen device contexts are a limited system resource.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ifont-sethdc HRESULT SetHdc( HDC hDC );
		[PreserveSig]
		HRESULT SetHdc(HDC hDC);
	}

	/// <summary>
	/// <para>Provides a simple way to support communication between an object and its site in the container.</para>
	/// <para>
	/// Often an object needs to communicate directly with a container site object and, in effect, manage the site object itself.
	/// Outside of IOleObject::SetClientSite, there is no generic means through which an object becomes aware of its site.
	/// <c>IObjectWithSite</c> provides simple objects with a simple siting mechanism (lighter than IOleObject) This interface should
	/// only be used when <c>IOleObject</c> is not already in use.
	/// </para>
	/// <para>
	/// Through <c>IObjectWithSite</c>, a container can pass the IUnknown pointer of its site to the object through
	/// IObjectWithSite::SetSite. Callers can also retrieve the latest site passed to <c>SetSite</c> through IObjectWithSite::GetSite.
	/// This latter method is included as a hooking mechanism, allowing a third party to intercept calls from the object to the site.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ocidl/nn-ocidl-iobjectwithsite
	[PInvokeData("ocidl.h", MSDNShortId = "e688136e-e06b-46ba-bec9-b8db2f9c468d")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("fc4801a3-2ba9-11cf-a229-00aa003d7352")]
	public interface IObjectWithSite
	{
		/// <summary>
		/// <para>Enables a container to pass an object a pointer to the interface for its site.</para>
		/// </summary>
		/// <param name="pUnkSite">
		/// <para>
		/// A pointer to the IUnknown interface pointer of the site managing this object. If <c>NULL</c>, the object should call Release
		/// on any existing site at which point the object no longer knows its site.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>This method returns S_OK on success.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The object should hold onto this pointer, calling IUnknown::AddRef in doing so. If the object already has a site, it should
		/// call that existing site's IUnknown::Release, save the new site pointer, and call the new site's <c>IUnknown::AddRef</c>.
		/// </para>
		/// <para>E_NOTIMPL is not allowed without implementation of the <c>SetSite</c> method, the IObjectWithSite interface is unnecessary.</para>
		/// </remarks>
		[PreserveSig]
		HRESULT SetSite([In, MarshalAs(UnmanagedType.IUnknown)] object? pUnkSite);

		/// <summary>
		/// <para>Retrieves the latest site passed using SetSite.</para>
		/// </summary>
		/// <param name="riid">
		/// <para>The IID of the interface pointer that should be returned in .</para>
		/// </param>
		/// <param name="ppvSite">
		/// <para>
		/// Address of pointer variable that receives the interface pointer requested in . Upon successful return, * contains the
		/// requested interface pointer to the site last seen in SetSite. The specific interface returned depends on the argument in
		/// essence, the two arguments act identically to those in QueryInterface. If the appropriate interface pointer is available,
		/// the object must call AddRef on that pointer before returning successfully. If no site is available, or the requested
		/// interface is not supported, this method must * to <c>NULL</c> and return a failure code.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>This method returns S_OK on success. Other possible return values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>There is no site, in which case * contains NULL on return.</term>
		/// </item>
		/// <item>
		/// <term>E_NOINTERFACE</term>
		/// <term>There is a site, but it does not support the interface requested by .</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>E_NOTIMPL is not allowed any object implementing this interface must be able to return the last site seen in IObjectWithSite::SetSite.</para>
		/// </remarks>
		[PreserveSig]
		HRESULT GetSite(in Guid riid, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 0)] out object? ppvSite);
	}

	/// <summary>Provides the features for supporting keyboard mnemonics, ambient properties, and events in control objects.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nn-ocidl-iolecontrol
	[PInvokeData("ocidl.h", MSDNShortId = "NN:ocidl.IOleControl")]
	[ComImport, Guid("B196B288-BAB4-101A-B69C-00AA00341D07"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IOleControl
	{
		/// <summary>Retrieves information about the control's keyboard mnemonics and behavior.</summary>
		/// <param name="pCI">A pointer to a CONTROLINFO structure that receives the information.</param>
		/// <returns>
		/// <para>This method can return the standard return value E_OUTOFMEMORY, as well as the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method completed succesfully.</term>
		/// </item>
		/// <item>
		/// <term>E_NOTIMPL</term>
		/// <term>The control has no mnemonics.</term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>The address in pCI is not valid. For example, it may be NULL.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-iolecontrol-getcontrolinfo HRESULT GetControlInfo(
		// CONTROLINFO *pCI );
		[PreserveSig]
		HRESULT GetControlInfo(ref CONTROLINFO pCI);

		/// <summary>Informs a control that the user has pressed a keystroke that represents a keyboard mneumonic.</summary>
		/// <param name="pMsg">A pointer to the MSG structure describing the keystroke to be processed.</param>
		/// <returns>
		/// <para>This method can return the standard return values E_INVALIDARG and E_UNEXPECTED, as well as the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method completed successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_NOTIMPL</term>
		/// <term>
		/// The control does not handle mnemonics. This indicates an unexpected condition and a caller error. For example, the caller
		/// has mismatched which control has which mnemonic.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The keystroke must match one of the <c>ACCEL</c> entries in the mnemonic table returned through IOleControl::GetControlInfo.
		/// The control takes whatever action is appropriate for the keystroke.
		/// </para>
		/// <para>Notes to Callers</para>
		/// <para>
		/// A container of a control is allowed to cache the control's CONTROLINFO structure, provided that the container implements
		/// IOleControlSite::OnControlInfoChanged to know when it must update its cached information.
		/// </para>
		/// <para>Notes to Implementers</para>
		/// <para>If a control changes the contents of its CONTROLINFO structure, it must notify its container by calling IOleControlSite::OnControlInfoChanged.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-iolecontrol-onmnemonic HRESULT OnMnemonic( MSG *pMsg );
		[PreserveSig]
		HRESULT OnMnemonic(in MSG pMsg);

		/// <summary>Informs a control that one or more of the container's ambient properties has changed.</summary>
		/// <param name="dispID">
		/// The dispatch identifier of the ambient property that changed. If this parameter is DISPID_UNKNOWN, it indicates that
		/// multiple properties changed. In this case, the control should check all the ambient properties of interest to obtain their
		/// current values.
		/// </param>
		/// <returns>This method returns S_OK in all cases.</returns>
		/// <remarks>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// S_OK is returned in all cases even when the control does not support ambient properties or some other failure has occurred.
		/// The caller sending the notification cannot attempt to use an error code (such as E_NOTIMPL) to determine whether to send the
		/// notification in the future. Such semantics are not part of this interface.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-iolecontrol-onambientpropertychange HRESULT
		// OnAmbientPropertyChange( DISPID dispID );
		[PreserveSig]
		HRESULT OnAmbientPropertyChange(int dispID);

		/// <summary>Indicates whether the container is ignoring or accepting events from the control.</summary>
		/// <param name="bFreeze">
		/// Indicates whether the container will ignore ( <c>TRUE</c>) or now process ( <c>FALSE</c>) events from the control.
		/// </param>
		/// <returns>This method returns S_OK in all cases.</returns>
		/// <remarks>
		/// <para>
		/// The control is not required to stop sending events when bFreeze is <c>TRUE</c>. However, the container is not going to
		/// process them in this case. If a control depends on the container's processing -- as with request events that return
		/// information from the container -- the control must either discard the event or queue the event to send later when bFreeze is <c>FALSE</c>.
		/// </para>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// As with IOleControl::OnAmbientPropertyChange, S_OK is returned in all cases in order to prevent a container from making
		/// assumptions about a control's behavior based on return values.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-iolecontrol-freezeevents HRESULT FreezeEvents( BOOL bFreeze );
		[PreserveSig]
		HRESULT FreezeEvents([MarshalAs(UnmanagedType.Bool)] bool bFreeze);
	}

	/// <summary>
	/// Provides the methods that enable a site object to manage each embedded control within a container. A site object provides
	/// <c>IOleControlSite</c> as well as other site interfaces such as IOleClientSite and IOleInPlaceSite. When a control requires the
	/// services expressed through this interface, it will query one of the other client site interfaces for <c>IOleControlSite</c>.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nn-ocidl-iolecontrolsite
	[PInvokeData("ocidl.h", MSDNShortId = "NN:ocidl.IOleControlSite")]
	[ComImport, Guid("B196B289-BAB4-101A-B69C-00AA00341D07"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IOleControlSite
	{
		/// <summary>
		/// Informs the container that the control's CONTROLINFO structure has changed and that the container should call the control's
		/// IOleControl::GetControlInfo for an update.
		/// </summary>
		/// <returns>This method returns S_OK in all cases.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-iolecontrolsite-oncontrolinfochanged HRESULT OnControlInfoChanged();
		[PreserveSig]
		HRESULT OnControlInfoChanged();

		/// <summary>
		/// Indicates whether a control should remain in-place active. Calls to this method typically nest an event to ensure that the
		/// object's activation state remains stable throughout the processing of the event.
		/// </summary>
		/// <param name="fLock">
		/// Indicates whether to ensure the in-place active state ( <c>TRUE</c>) or to allow activation to change ( <c>FALSE</c>). When
		/// <c>TRUE</c>, a supporting container must not deactivate the in-place object until this method is called again with <c>FALSE</c>.
		/// </param>
		/// <returns>
		/// <para>This method can return the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The lock or unlock was made successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_NOTIMPL</term>
		/// <term>The container does not support in-place locking.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>This method affects the control's in-place active state but not its UI-active state.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-iolecontrolsite-lockinplaceactive HRESULT
		// LockInPlaceActive( BOOL fLock );
		[PreserveSig]
		HRESULT LockInPlaceActive([MarshalAs(UnmanagedType.Bool)] bool fLock);

		/// <summary>Retrieves an <c>IDispatch</c> pointer to the extended control that the container uses to wrap the real control.</summary>
		/// <param name="ppDisp">
		/// A pointer to an <c>IDispatch</c> pointer variable that receives the interface pointer to the extended control. If an error
		/// occurs, the implementation must set *ppDisp to <c>NULL</c>. On success, the caller is responsible for calling Release when
		/// *ppDisp is no longer needed.
		/// </param>
		/// <returns>
		/// <para>This method can return the standard return values E_OUTOFMEMORY and E_UNEXPECTED, as well as the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method completed successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_NOTIMPL</term>
		/// <term>The container does not implement extended controls.</term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>The address in ppDisp or *ppDisp is not valid. For example, it may be NULL.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method gives the real control access to whatever properties and methods the container maintains in the extended
		/// control. These properties and methods would otherwise be inaccessible to the control.
		/// </para>
		/// <para>Notes to Callers</para>
		/// <para>The returned pointer is the responsibility of the caller, which must release it when it is no longer needed.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-iolecontrolsite-getextendedcontrol HRESULT
		// GetExtendedControl( IDispatch **ppDisp );
		[PreserveSig]
		HRESULT GetExtendedControl([MarshalAs(UnmanagedType.IDispatch)] out object? ppDisp);

		/// <summary>
		/// Converts coordinates expressed in <c>HIMETRIC</c> units (as is standard in OLE) to the units specified by the container.
		/// </summary>
		/// <param name="pPtlHimetric">
		/// Address of a POINTL structure containing coordinates expressed in <c>HIMETRIC</c> units. This is an [in] parameter when
		/// dwFlags contains XFORMCOORDS_HIMETRICTOCONTAINER; it is an [out] parameter with XFORMCOORDS_CONTAINERTOHIMETRIC. In the
		/// latter case, the contents are undefined on error.
		/// </param>
		/// <param name="pPtfContainer">
		/// Address of a caller-allocated POINTF structure that receives the converted coordinates. This is an [in] parameter when
		/// dwFlags contains XFORMCOORDS_CONTAINERTOHIMETRIC; it is an [out] parameter with XFORMCOORDS_HIMETRICTOCONTAINER. In the
		/// latter case, the contents are undefined on error.
		/// </param>
		/// <param name="dwFlags">
		/// <para>
		/// Flags indicating the exact conversion to perform. This parameter can be any combination of the following values, except as indicated.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>XFORMCOORDS_POSITION 0x1</term>
		/// <term>The coordinates to convert represent a position point. Cannot be used with XFORMCOORDS_SIZE.</term>
		/// </item>
		/// <item>
		/// <term>XFORMCOORDS_SIZE 0x2</term>
		/// <term>The coordinates to convert represent a set of dimensions. Cannot be used with XFORMCOORDS_POSITION.</term>
		/// </item>
		/// <item>
		/// <term>XFORMCOORDS_HIMETRICTOCONTAINER 0x4</term>
		/// <term>The operation converts pptlHimetric into pptfContainer. Cannot be used with XFORMCOORDS_CONTAINERTOHIMETRIC.</term>
		/// </item>
		/// <item>
		/// <term>XFORMCOORDS_CONTAINERTOHIMETRIC 0x8</term>
		/// <term>The operation converts pptfContainer into pptlHimetric. Cannot be used with XFORMCOORDS_HIMETRICTOCONTAINER.</term>
		/// </item>
		/// <item>
		/// <term>XFORMCOORDS_EVENTCOMPAT 0x10</term>
		/// <term>The operation maintains compatibility with an event.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <para>This method can return the standard return values E_INVALIDARG and E_UNEXPECTED, as well as the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method completed successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_NOTIMPL</term>
		/// <term>The container does not require any special coordinate conversions. The container deals completely in HIMETRIC.</term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>The address in pPtlHimetric or pPtfContainer is not valid. For example, it may be NULL.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// A control uses this method when it has to send coordinates to a container within an event or some other custom call or when
		/// the control has container coordinates that it needs to convert into <c>HIMETRIC</c> units.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-iolecontrolsite-transformcoords HRESULT TransformCoords(
		// POINTL *pPtlHimetric, POINTF *pPtfContainer, DWORD dwFlags );
		[PreserveSig]
		HRESULT TransformCoords(ref POINT pPtlHimetric, ref POINTF pPtfContainer, XFORMCOORDS dwFlags);

		/// <summary>Passes a keystroke to the control site for processing.</summary>
		/// <param name="pMsg">A pointer to the MSG structure describing the keystroke to be processed.</param>
		/// <param name="grfModifiers">
		/// Flags describing the state of the Control, Alt, and Shift keys. The value of the flag can be any valid KEYMODIFIERS
		/// enumeration values.
		/// </param>
		/// <returns>
		/// <para>This method can return the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The container processed the message.</term>
		/// </item>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>The container did not process the message. This value must also be returned in all other error cases besides E_NOTIMPL.</term>
		/// </item>
		/// <item>
		/// <term>E_NOTIMPL</term>
		/// <term>The container does not implement accelerator support.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// This method is called by a control that can be UI-active. In such cases, a control can process all keystrokes first through
		/// IOleInPlaceActiveObject::TranslateAccelerator, according to normal OLE Compound Document rules. Inside that method, the
		/// control can give the container certain messages to process first by calling <c>IOleControlSite::TranslateAccelerator</c> and
		/// using the return value to determine if any processing took place. Otherwise, the control always processes the message first.
		/// If the control does not use the keystroke as an accelerator, it passes the keystroke to the container through this method.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-iolecontrolsite-translateaccelerator HRESULT
		// TranslateAccelerator( MSG *pMsg, DWORD grfModifiers );
		[PreserveSig]
		HRESULT TranslateAccelerator(in MSG pMsg, KEYMODIFIERS grfModifiers);

		/// <summary>Indicates whether the control managed by this control site has gained or lost the focus.</summary>
		/// <param name="fGotFocus">Indicates whether the control gained (TRUE) or lost the focus (FALSE).</param>
		/// <returns>This method returns S_OK in all cases.</returns>
		/// <remarks>
		/// The container uses this information to update the state of <c>Default</c> and <c>Cancel</c> buttons according to how the
		/// control with the focus processes Return or Esc keys. A control's behavior regarding the Return and Esc keys is specified in
		/// the control's CONTROLINFO structure. See IOleControl::GetControlInfo for more information.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-iolecontrolsite-onfocus HRESULT OnFocus( BOOL fGotFocus );
		[PreserveSig]
		HRESULT OnFocus([MarshalAs(UnmanagedType.Bool)] bool fGotFocus);

		/// <summary>Instructs a container to display a property sheet for the control embedded in this site.</summary>
		/// <returns>
		/// <para>This method can return the standard return value E_OUTOFMEMORY, as well as the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method completed successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_NOTIMPL</term>
		/// <term>The container does not need to show property pages itself.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// A control must always call this method in the container first when it intends to show its own property pages. Calling this
		/// method gives the container a chance to have those property pages work with the container's extended controls. The container
		/// may include its own property pages as well in such cases, which doesn't affect the control at all. If the container does not
		/// implement this method or if it returns a failure of any kind, the control can show its property pages directly. Otherwise,
		/// the container has shown the pages.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-iolecontrolsite-showpropertyframe HRESULT ShowPropertyFrame();
		[PreserveSig]
		HRESULT ShowPropertyFrame();
	}

	/// <summary>
	/// <para>
	/// Enables a windowless object to process window messages and participate in drag and drop operations. It is derived from and
	/// extends the IOleInPlaceObject interface.
	/// </para>
	/// <para>
	/// A small object, such as a control, does not need a window of its own. Instead, it can rely on its container to dispatch window
	/// messages and help the object to participate in drag and drop operations. The container must implement the
	/// IOleInPlaceSiteWindowless interface. Otherwise, the object must act as a normal compound document object and create a window
	/// when it is activated.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nn-ocidl-ioleinplaceobjectwindowless
	[PInvokeData("ocidl.h", MSDNShortId = "NN:ocidl.IOleInPlaceObjectWindowless")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("1C2056CC-5EF4-101B-8BC8-00AA003E3B29")]
	public interface IOleInPlaceObjectWindowless : IOleInPlaceObject
	{
		/// <summary>
		/// Retrieves a handle to one of the windows participating in in-place activation (frame, document, parent, or in-place object window).
		/// </summary>
		/// <param name="phwnd">A pointer to a variable that receives the window handle.</param>
		/// <returns>
		/// This method returns S_OK on success. Other possible return values include the following.
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <description>E_FAIL</description>
		/// <description>The object is windowless.</description>
		/// </item>
		/// <item>
		/// <description>E_OUTOFMEMORY</description>
		/// <description>There is insufficient memory available for this operation.</description>
		/// </item>
		/// <item>
		/// <description>E_UNEXPECTED</description>
		/// <description>An unexpected error has occurred.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Five types of windows comprise the windows hierarchy. When a object is active in place, it has access to some or all of
		/// these windows.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Window</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <description>Frame</description>
		/// <description>The outermost main window where the container application's main menu resides.</description>
		/// </item>
		/// <item>
		/// <description>Document</description>
		/// <description>The window that displays the compound document containing the embedded object to the user.</description>
		/// </item>
		/// <item>
		/// <description>Pane</description>
		/// <description>
		/// The subwindow of the document window that contains the object's view. Applicable only for applications with split-pane windows.
		/// </description>
		/// </item>
		/// <item>
		/// <description>Parent</description>
		/// <description>
		/// The container window that contains that object's view. The object application installs its window as a child of this window.
		/// </description>
		/// </item>
		/// <item>
		/// <description>In-place</description>
		/// <description>
		/// The window containing the active in-place object. The object application creates this window and installs it as a child of
		/// its hatch window, which is a child of the container's parent window.
		/// </description>
		/// </item>
		/// </list>
		/// <para>
		/// Each type of window has a different role in the in-place activation architecture. However, it is not necessary to employ a
		/// separate physical window for each type. Many container applications use the same window for their frame, document, pane, and
		/// parent windows.
		/// </para>
		/// </remarks>
		[PreserveSig]
		new HRESULT GetWindow(out HWND phwnd);

		/// <summary>Determines whether context-sensitive help mode should be entered during an in-place activation session.</summary>
		/// <param name="fEnterMode">
		/// <see langword="true"/> if help mode should be entered; <see langword="false"/> if it should be exited.
		/// </param>
		/// <returns>
		/// <para>
		/// This method returns S_OK if the help mode was entered or exited successfully, depending on the value passed in <paramref
		/// name="fEnterMode"/>. Other possible return values include the following. <br/>
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <description>E_INVALIDARG</description>
		/// <description>The specified <paramref name="fEnterMode"/> value is not valid.</description>
		/// </item>
		/// <item>
		/// <description>E_OUTOFMEMORY</description>
		/// <description>There is insufficient memory available for this operation.</description>
		/// </item>
		/// <item>
		/// <description>E_UNEXPECTED</description>
		/// <description>An unexpected error has occurred.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Applications can invoke context-sensitive help when the user:</para>
		/// <list type="bullet">
		/// <item>presses SHIFT+F1, then clicks a topic</item>
		/// <item>presses F1 when a menu item is selected</item>
		/// </list>
		/// <para>
		/// When SHIFT+F1 is pressed, either the frame or active object can receive the keystrokes. If the container's frame receives
		/// the keystrokes, it calls its containing document's IOleWindow::ContextSensitiveHelp method with <paramref
		/// name="fEnterMode"/> set to <see langword="true"/>. This propagates the help state to all of its in-place objects so they can
		/// correctly handle the mouse click or WM_COMMAND.
		/// </para>
		/// <para>
		/// If an active object receives the SHIFT+F1 keystrokes, it calls the container's IOleWindow::ContextSensitiveHelp method with
		/// <paramref name="fEnterMode"/> set to <see langword="true"/>, which then recursively calls each of its in-place sites until
		/// there are no more to be notified. The container then calls its document's or frame's IOleWindow::ContextSensitiveHelp method
		/// with <paramref name="fEnterMode"/> set to <see langword="true"/>.
		/// </para>
		/// <para>When in context-sensitive help mode, an object that receives the mouse click can either:</para>
		/// <list type="bullet">
		/// <item>Ignore the click if it does not support context-sensitive help.</item>
		/// <item>
		/// Tell all the other objects to exit context-sensitive help mode with ContextSensitiveHelp set to FALSE and then provide help
		/// for that context.
		/// </item>
		/// </list>
		/// <para>
		/// An object in context-sensitive help mode that receives a WM_COMMAND should tell all the other in-place objects to exit
		/// context-sensitive help mode and then provide help for the command.
		/// </para>
		/// <para>
		/// If a container application is to support context-sensitive help on menu items, it must either provide its own message filter
		/// so that it can intercept the F1 key or ask the OLE library to add a message filter by calling OleSetMenuDescriptor, passing
		/// valid, non-NULL values for the lpFrame and lpActiveObj parameters.
		/// </para>
		/// </remarks>
		[PreserveSig]
		new HRESULT ContextSensitiveHelp([MarshalAs(UnmanagedType.Bool)] bool fEnterMode);

		/// <summary>Deactivates an active in-place object and discards the object's undo state.</summary>
		/// <returns>
		/// <para>This method returns S_OK on success. Other possible return values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_UNEXPECTED</term>
		/// <term>An unexpected error occurred.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Notes to Callers</para>
		/// <para>
		/// This method is called by an active object's immediate container to deactivate the active object and discard its undo state.
		/// </para>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// On return from <c>IOleInPlaceObject::InPlaceDeactivate</c>, the object discards its undo state. The object application
		/// should not shut down immediately after this call. Instead, it should wait for an explicit call to IOleObject::Close or for
		/// the object's reference count to reach zero.
		/// </para>
		/// <para>
		/// Before deactivating, the object application should give the container a chance to put its user interface back on the frame
		/// window by calling IOleInPlaceSite::OnUIDeactivate.
		/// </para>
		/// <para>
		/// If the in-place user interface is still visible during the call to <c>IOleInPlaceObject::InPlaceDeactivate</c>, the object
		/// application should call its own <c>IOleInPlaceObject::InPlaceDeactivate</c> method to hide the user interface. The in-place
		/// user interface can be optionally destroyed during calls to <c>IOleInPlaceObject::InPlaceDeactivate</c> and
		/// <c>IOleInPlaceObject::InPlaceDeactivate</c>. But if the user interface has not already been destroyed when the container
		/// calls IOleObject::Close, then it must be destroyed during the call to <c>IOleObject::Close</c>.
		/// </para>
		/// <para>
		/// During the call to IOleObject::Close, the object should check to see whether it is still active in place. If so, it should
		/// call <c>IOleInPlaceObject::InPlaceDeactivate</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-ioleinplaceobject-inplacedeactivate HRESULT InPlaceDeactivate();
		[PreserveSig]
		new HRESULT InPlaceDeactivate();

		/// <summary>Deactivates and removes the user interface of an active in-place object.</summary>
		/// <returns>
		/// <para>This method returns S_OK on success. Other possible return values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_UNEXPECTED</term>
		/// <term>An unexpected error has occurred.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Notes to Callers</para>
		/// <para>
		/// This method is called by the object's immediate container when, for example, the user has clicked in the client area outside
		/// the object.
		/// </para>
		/// <para>
		/// If the container has called <c>IOleInPlaceObject::UIDeactivate</c>, it should later call
		/// IOleInPlaceObject::InPlaceDeactivate to properly clean up resources. The container can assume that stopping or releasing the
		/// object cleans up resources if necessary. The object must be prepared to do so if <c>IOleInPlaceObject::InPlaceDeactivate</c>
		/// has not been called. but either <c>IOleInPlaceObject::UIDeactivate</c> or IOleObject::Close has been called.
		/// </para>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// Resources such as menus and windows can be either cleaned up or kept in a hidden state until your object is completely
		/// deactivated by calls to either IOleInPlaceObject::InPlaceDeactivate or IOleObject::Close. The object application must call
		/// IOleInPlaceSite::OnUIDeactivate before doing anything with the composite menus so that the container can first be detached
		/// from the frame window. On deactivating the in-place object's user interface, the object is left in a ready state so it can
		/// be quickly reactivated. The object stays in this state until the undo state of the document changes. The container should
		/// then call <c>IOleInPlaceObject::InPlaceDeactivate</c> to tell the object to discard its undo state.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-ioleinplaceobject-uideactivate HRESULT UIDeactivate();
		[PreserveSig]
		new HRESULT UIDeactivate();

		/// <summary>Specifies how much of the in-place object is to be visible.</summary>
		/// <param name="lprcPosRect">
		/// A pointer to the RECT structure containing the position of the in-place object using the client coordinates of its parent window.
		/// </param>
		/// <param name="lprcClipRect">
		/// A pointer to the outer rectangle containing the in-place object's position rectangle (lprcPosRect). This rectangle is
		/// relative to the client area of the object's parent window.
		/// </param>
		/// <returns>
		/// <para>This method returns S_OK on success. Other possible return values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The specified pointer is invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>There is insufficient memory available for the operation.</term>
		/// </item>
		/// <item>
		/// <term>E_UNEXPECTED</term>
		/// <term>An unexpected error has occurred.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>It is possible for lprcClipRect to change without lprcPosRect changing.</para>
		/// <para>
		/// The size of an in-place object's rectangle is always calculated in pixels. This is different from other OLE object's
		/// visualizations, which are in <c>HIMETRIC</c>.
		/// </para>
		/// <para>
		/// <c>Note</c> While executing <c>IOleInPlaceObject::SetObjectRects</c>, do not make calls to the PeekMessage or GetMessage
		/// functions, or a dialog box. Doing so may cause the system to deadlock. There are further restrictions on which OLE interface
		/// methods and functions can be called from within <c>IOleInPlaceObject::SetObjectRects</c>.
		/// </para>
		/// <para>Notes to Callers</para>
		/// <para>
		/// The container should call <c>IOleInPlaceObject::SetObjectRects</c> whenever the window position of the in-place object
		/// and/or the visible part of the in-place object changes.
		/// </para>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// The object must size its in-place window to match the intersection of lprcPosRect and lprcClipRect. The object must also
		/// draw its contents into the object's in-place window so that proper clipping takes place.
		/// </para>
		/// <para>
		/// The object should compare its width and height with those provided by its container (conveyed through lprcPosRect). If the
		/// comparison does not result in a match, the container is applying scaling to the object. The object must then decide whether
		/// it should continue the in-place editing in the scale/zoom mode or deactivate.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-ioleinplaceobject-setobjectrects HRESULT SetObjectRects(
		// LPCRECT lprcPosRect, LPCRECT lprcClipRect );
		[PreserveSig]
		new HRESULT SetObjectRects(in RECT lprcPosRect, in RECT lprcClipRect);

		/// <summary>Reactivates a previously deactivated object, undoing the last state of the object.</summary>
		/// <returns>
		/// <para>This method returns S_OK on success. Other possible return values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_NOTUNDOABLE</term>
		/// <term>The undo state is not available.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>There is insufficient memory available for the operation.</term>
		/// </item>
		/// <item>
		/// <term>E_UNEXPECTED</term>
		/// <term>An unexpected error has occurred.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// If the user chooses the <c>Undo</c> command before the undo state of the object is lost, the object's immediate container
		/// calls <c>IOleInPlaceObject::ReactivateAndUndo</c> to activate the user interface, carry out the undo operation, and return
		/// the object to the active state.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-ioleinplaceobject-reactivateandundo HRESULT ReactivateAndUndo();
		[PreserveSig]
		new HRESULT ReactivateAndUndo();

		/// <summary>Dispatches a message from a container to a windowless object that is in-place active.</summary>
		/// <param name="msg">The identifier for the window message provided to the container by Windows.</param>
		/// <param name="wParam">A parameter for the window message provided to the container by Windows.</param>
		/// <param name="lParam">A parameter for the window message provided to the container by Windows.</param>
		/// <param name="plResult">A pointer to result code for the window message.</param>
		/// <returns>
		/// <para>This method returns S_OK on success. Other possible return values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>
		/// The windowless object did not process the window message. The container should call the DefWindowProc for the message or
		/// process the message itself as described below.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A container calls this method to send window messages to a windowless object that is in-place active. The container should
		/// dispatch messages according to the following guidelines:
		/// </para>
		/// <para>
		/// For the following messages, the container should first dispatch the message to the windowless object that has captured the
		/// mouse, if any. Otherwise, the container should dispatch the message to the windowless object under the mouse cursor. If
		/// there is no such object, the container is free to process the following messages for itself:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>WM_MOUSEMOVE</term>
		/// </item>
		/// <item>
		/// <term>WM_SETCURSOR</term>
		/// </item>
		/// <item>
		/// <term>WM_XBUTTONDOWN</term>
		/// </item>
		/// <item>
		/// <term>WM_XBUTTONUP</term>
		/// </item>
		/// <item>
		/// <term>WM_XBUTTONDBLCLK</term>
		/// </item>
		/// </list>
		/// <para>The container should dispatch the message to the windowless object with the keyboard focus for the following messages:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>WM_CANCELMODE</term>
		/// </item>
		/// <item>
		/// <term>WM_CHAR</term>
		/// </item>
		/// <item>
		/// <term>WM_DEADCHAR</term>
		/// </item>
		/// <item>
		/// <term>WM_HELP</term>
		/// </item>
		/// <item>
		/// <term>WM_IMExxx</term>
		/// </item>
		/// <item>
		/// <term>WM_KEYDOWN</term>
		/// </item>
		/// <item>
		/// <term>WM_KEYUP</term>
		/// </item>
		/// <item>
		/// <term>WM_SYSDEADCHAR</term>
		/// </item>
		/// <item>
		/// <term>WM_SYSKEYDOWN</term>
		/// </item>
		/// <item>
		/// <term>WM_SYSKEYUP</term>
		/// </item>
		/// </list>
		/// <para>For all other messages, the container should process the message on its own.</para>
		/// <para>
		/// The windowless object can return S_FALSE to this method to indicate that it did not process the message. Then, the container
		/// either performs the default behavior for the message by calling the DefWindowProc function, or processes the message itself.
		/// </para>
		/// <para>The container must pass the following window messages to the default window procedure:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>WM_CHAR</term>
		/// </item>
		/// <item>
		/// <term>WM_DEADCHAR</term>
		/// </item>
		/// <item>
		/// <term>WM_IMExxx</term>
		/// </item>
		/// <item>
		/// <term>WM_KEYDOWN</term>
		/// </item>
		/// <item>
		/// <term>WM_KEYUP</term>
		/// </item>
		/// <item>
		/// <term>WM_MOUSEMOVE</term>
		/// </item>
		/// <item>
		/// <term>WM_SYSCHAR</term>
		/// </item>
		/// <item>
		/// <term>WM_SYSDEADCHAR</term>
		/// </item>
		/// <item>
		/// <term>WM_SYSKEYUP</term>
		/// </item>
		/// <item>
		/// <term>WM_XBUTTONDOWN</term>
		/// </item>
		/// <item>
		/// <term>WM_XBUTTONUP</term>
		/// </item>
		/// <item>
		/// <term>WM_XBUTTONDBLCLK</term>
		/// </item>
		/// </list>
		/// <para>The container must process the following window messages as its own:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>WM_CONTEXTMENU</term>
		/// </item>
		/// <item>
		/// <term>WM_HELP</term>
		/// </item>
		/// <item>
		/// <term>WM_SETCURSOR</term>
		/// </item>
		/// </list>
		/// <para><c>Note</c> For WM_SETCURSOR, the container can either set the cursor itself or do nothing.</para>
		/// <para>
		/// Objects can also use IOleInPlaceSiteWindowless::OnDefWindowMessage to explicitly invoke the default message processing from
		/// the container. In the case of the WM_SETCURSOR message, this allows an object to take action if the container does not set
		/// the cursor.
		/// </para>
		/// <para>All coordinates passed to the object in wParam and lParam are specified as client coordinates of the containing window.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ioleinplaceobjectwindowless-onwindowmessage HRESULT
		// OnWindowMessage( UINT msg, WPARAM wParam, LPARAM lParam, LRESULT *plResult );
		[PreserveSig]
		HRESULT OnWindowMessage(uint msg, IntPtr wParam, IntPtr lParam, out IntPtr plResult);

		/// <summary>Retrieves the IDropTarget interface for an in-place active, windowless object that supports drag and drop.</summary>
		/// <param name="ppDropTarget">
		/// A pointer to an IDropTarget pointer variable that receives the interface pointer to the windowless object.
		/// </param>
		/// <returns>
		/// <para>This method returns S_OK on success. Other possible return values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_NOTIMPL</term>
		/// <term>The windowless object does not support drag and drop.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A windowed object registers its IDropTarget interface by calling the RegisterDragDrop function and supplying its window
		/// handle as a parameter. Registering its <c>IDropTarget</c> interface enables the object to participate in drag and drop
		/// operations. Because it does not have a window when active, a windowless object cannot register its <c>IDropTarget</c>
		/// interface. Therefore, it cannot directly participate in drag and drop operations without support from its container.
		/// </para>
		/// <para>The following events occur during a drag and drop operation involving windowless objects:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>The container registers its own IDropTarget interface through the RegisterDragDrop function.</term>
		/// </item>
		/// <item>
		/// <term>
		/// In the container's implementation of its own IDropTarget::DragEnter or IDropTarget::DragOver methods, the container detects
		/// whether the mouse pointer just entered an embedded object.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// If the object is inactive, the container calls the object's IPointerInactive::GetActivationPolicy method. The object returns
		/// the POINTERINACTIVE_ACTIVATEONDRAG flag. The container then activates the object in place. If the object was already active,
		/// the container does not have to do this step.
		/// </term>
		/// </item>
		/// <item>
		/// <term>After the object is active, the container must then obtain the object's IDropTarget interface.</term>
		/// </item>
		/// <item>
		/// <term>
		/// A windowless object that wishes to be a drop target still implements the IDropTarget interface, but does not register it and
		/// does not return it through calls to IUnknown::QueryInterface. Instead, the container can obtain this interface by calling
		/// the object's <c>IOleInPlaceObjectWindowless::GetDropTarget</c> method. The object returns a pointer to its own
		/// <c>IDropTarget</c> interface if it wants to participate in drag and drop operations. The container can cache this interface
		/// pointer for later use. For example, on subsequent calls to the container's IDropTarget::DragEnter or IDropTarget::DragLeave
		/// methods, the container can use the cached pointer instead of calling the object's GetDropTarget method again.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// The container then calls the object's IDropTarget::DragEnter and passes the returned value for pdwEffect from its own
		/// IDropTarget::DragOver or <c>IDropTarget::DragEnter</c> methods. From this point on, the container forwards all subsequent
		/// <c>IDropTarget::DragOver</c> calls to the windowless object until the mouse leaves the object or a drop occurs on the
		/// object. If the mouse leaves the object, the container calls the object's IDropTarget::DragLeave and then releases the
		/// object's IDropTarget interface. If the drop occurs, the container forwards the IDropTarget::Drop call to the object.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Finally, the container in-place deactivates the object.</term>
		/// </item>
		/// </list>
		/// <para>
		/// An object can return S_FALSE from its own IDropTarget::DragEnter to indicate that it does not accept any of the data formats
		/// in the data object. In that case, the container can decide to accept the data for itself and return an appropriate dwEffect
		/// from its own <c>IDropTarget::DragEnter</c> or IDropTarget::DragOver methods.
		/// </para>
		/// <para>
		/// An object that returns S_FALSE from IDropTarget::DragEnter should be prepared to receive subsequent calls to
		/// <c>IDropTarget::DragEnter</c> without any IDropTarget::DragLeave in between. Indeed, if the mouse is still over the same
		/// object during the next call to the container's IDropTarget::DragOver, the container may decide to try and call
		/// <c>IDropTarget::DragEnter</c> again on the object.
		/// </para>
		/// <para>Notes to Callers</para>
		/// <para>A container can cache the pointer to the object's IDropTarget interface for later use.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ioleinplaceobjectwindowless-getdroptarget HRESULT
		// GetDropTarget( IDropTarget **ppDropTarget );
		[PreserveSig]
		HRESULT GetDropTarget(out IDropTarget ppDropTarget);
	}

	/// <summary>
	/// <para>
	/// Provides an additional set of activation and deactivation notification methods that enable an object to avoid unnecessary
	/// flashing on the screen when the object is activated and deactivated.
	/// </para>
	/// <para>
	/// When an object is activated, it does not know if its visual display is already correct. When the object is deactivated, the
	/// container does not know if the visual display is correct. To avoid a redraw and the associated screen flicker in both cases, the
	/// container can provide this extension to IOleInPlaceSite.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nn-ocidl-ioleinplacesiteex
	[PInvokeData("ocidl.h", MSDNShortId = "NN:ocidl.IOleInPlaceSiteEx")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("9C2CAD80-3424-11CF-B670-00AA004CD6D8")]
	public interface IOleInPlaceSiteEx : IOleInPlaceSite
	{
		/// <summary>
		/// Retrieves a handle to one of the windows participating in in-place activation (frame, document, parent, or in-place object window).
		/// </summary>
		/// <param name="phwnd">A pointer to a variable that receives the window handle.</param>
		/// <returns>
		/// This method returns S_OK on success. Other possible return values include the following.
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <description>E_FAIL</description>
		/// <description>The object is windowless.</description>
		/// </item>
		/// <item>
		/// <description>E_OUTOFMEMORY</description>
		/// <description>There is insufficient memory available for this operation.</description>
		/// </item>
		/// <item>
		/// <description>E_UNEXPECTED</description>
		/// <description>An unexpected error has occurred.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Five types of windows comprise the windows hierarchy. When a object is active in place, it has access to some or all of
		/// these windows.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Window</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <description>Frame</description>
		/// <description>The outermost main window where the container application's main menu resides.</description>
		/// </item>
		/// <item>
		/// <description>Document</description>
		/// <description>The window that displays the compound document containing the embedded object to the user.</description>
		/// </item>
		/// <item>
		/// <description>Pane</description>
		/// <description>
		/// The subwindow of the document window that contains the object's view. Applicable only for applications with split-pane windows.
		/// </description>
		/// </item>
		/// <item>
		/// <description>Parent</description>
		/// <description>
		/// The container window that contains that object's view. The object application installs its window as a child of this window.
		/// </description>
		/// </item>
		/// <item>
		/// <description>In-place</description>
		/// <description>
		/// The window containing the active in-place object. The object application creates this window and installs it as a child of
		/// its hatch window, which is a child of the container's parent window.
		/// </description>
		/// </item>
		/// </list>
		/// <para>
		/// Each type of window has a different role in the in-place activation architecture. However, it is not necessary to employ a
		/// separate physical window for each type. Many container applications use the same window for their frame, document, pane, and
		/// parent windows.
		/// </para>
		/// </remarks>
		[PreserveSig]
		new HRESULT GetWindow(out HWND phwnd);

		/// <summary>Determines whether context-sensitive help mode should be entered during an in-place activation session.</summary>
		/// <param name="fEnterMode">
		/// <see langword="true"/> if help mode should be entered; <see langword="false"/> if it should be exited.
		/// </param>
		/// <returns>
		/// <para>
		/// This method returns S_OK if the help mode was entered or exited successfully, depending on the value passed in <paramref
		/// name="fEnterMode"/>. Other possible return values include the following. <br/>
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <description>E_INVALIDARG</description>
		/// <description>The specified <paramref name="fEnterMode"/> value is not valid.</description>
		/// </item>
		/// <item>
		/// <description>E_OUTOFMEMORY</description>
		/// <description>There is insufficient memory available for this operation.</description>
		/// </item>
		/// <item>
		/// <description>E_UNEXPECTED</description>
		/// <description>An unexpected error has occurred.</description>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Applications can invoke context-sensitive help when the user:</para>
		/// <list type="bullet">
		/// <item>presses SHIFT+F1, then clicks a topic</item>
		/// <item>presses F1 when a menu item is selected</item>
		/// </list>
		/// <para>
		/// When SHIFT+F1 is pressed, either the frame or active object can receive the keystrokes. If the container's frame receives
		/// the keystrokes, it calls its containing document's IOleWindow::ContextSensitiveHelp method with <paramref
		/// name="fEnterMode"/> set to <see langword="true"/>. This propagates the help state to all of its in-place objects so they can
		/// correctly handle the mouse click or WM_COMMAND.
		/// </para>
		/// <para>
		/// If an active object receives the SHIFT+F1 keystrokes, it calls the container's IOleWindow::ContextSensitiveHelp method with
		/// <paramref name="fEnterMode"/> set to <see langword="true"/>, which then recursively calls each of its in-place sites until
		/// there are no more to be notified. The container then calls its document's or frame's IOleWindow::ContextSensitiveHelp method
		/// with <paramref name="fEnterMode"/> set to <see langword="true"/>.
		/// </para>
		/// <para>When in context-sensitive help mode, an object that receives the mouse click can either:</para>
		/// <list type="bullet">
		/// <item>Ignore the click if it does not support context-sensitive help.</item>
		/// <item>
		/// Tell all the other objects to exit context-sensitive help mode with ContextSensitiveHelp set to FALSE and then provide help
		/// for that context.
		/// </item>
		/// </list>
		/// <para>
		/// An object in context-sensitive help mode that receives a WM_COMMAND should tell all the other in-place objects to exit
		/// context-sensitive help mode and then provide help for the command.
		/// </para>
		/// <para>
		/// If a container application is to support context-sensitive help on menu items, it must either provide its own message filter
		/// so that it can intercept the F1 key or ask the OLE library to add a message filter by calling OleSetMenuDescriptor, passing
		/// valid, non-NULL values for the lpFrame and lpActiveObj parameters.
		/// </para>
		/// </remarks>
		[PreserveSig]
		new HRESULT ContextSensitiveHelp([MarshalAs(UnmanagedType.Bool)] bool fEnterMode);

		/// <summary>Determines whether the container can activate the object in place.</summary>
		/// <returns>
		/// <para>This method returns S_OK on success. Other possible return values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>The container does not allow in-place activation for this object.</term>
		/// </item>
		/// <item>
		/// <term>E_UNEXPECTED</term>
		/// <term>An unexpected error has occurred.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Only objects being displayed as DVASPECT_CONTENT can be activated in place.</para>
		/// <para>Notes to Callers</para>
		/// <para>
		/// <c>CanInPlaceActivate</c> is called by the client site's immediate child object when this object must activate in place.
		/// This function allows the container application to accept or refuse the activation request.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-ioleinplacesite-caninplaceactivate HRESULT CanInPlaceActivate();
		[PreserveSig]
		new HRESULT CanInPlaceActivate();

		/// <summary>Notifies the container that one of its objects is being activated in place.</summary>
		/// <returns>
		/// <para>
		/// This method returns S_OK if the container allows the in-place activation. Other possible return values include the following.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_UNEXPECTED</term>
		/// <term>An unexpected error has occurred.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Notes to Callers</para>
		/// <para>
		/// <c>OnInPlaceActivate</c> is called by the active embedded object when it is activated in-place for the first time. The
		/// container should note that the object is becoming active.
		/// </para>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// A container that supports linking to embedded objects must properly manage the running of its in-place objects when they are
		/// UI-inactive and running in the hidden state. To reactivate the in-place object quickly, a container should not call
		/// IOleObject::Close until the container's IOleInPlaceSite::DeactivateAndUndo method is called. To help protect against the
		/// object being left in an unstable state if a linking client updates silently, the container should call OleLockRunning to
		/// lock the object in the running state. This prevents the hidden in-place object from shutting down before it can be saved in
		/// its container.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-ioleinplacesite-oninplaceactivate HRESULT OnInPlaceActivate();
		[PreserveSig]
		new HRESULT OnInPlaceActivate();

		/// <summary>
		/// Notifies the container that the object is about to be activated in place and that the object is going to replace the
		/// container's main menu with an in-place composite menu.
		/// </summary>
		/// <returns>
		/// <para>
		/// This method returns S_OK if the container allows the in-place activation. Other possible return values include the following.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_UNEXPECTED</term>
		/// <term>An unexpected error has occurred.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Notes to Callers</para>
		/// <para>The in-place object calls <c>IOleInPlaceSite::OnUIActivate</c> just before activating its user interface.</para>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// The container should remove any user interface associated with its own activation. If the container is itself an embedded
		/// object, it should remove its document-level user interface.
		/// </para>
		/// <para>
		/// If there is already an object active in place in the same document, the container should call
		/// IOleInPlaceObject::UIDeactivate before calling OnUIDeactivate.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-ioleinplacesite-onuiactivate HRESULT OnUIActivate();
		[PreserveSig]
		new HRESULT OnUIActivate();

		/// <summary>
		/// Enables an in-place object to retrieve the window interfaces that form the window object hierarchy, and the position in the
		/// parent window where the object's in-place activation window should be located.
		/// </summary>
		/// <param name="ppFrame">
		/// A pointer to an IOleInPlaceFrame pointer variable that receives the interface pointer to the frame. If an error occurs, the
		/// implementation must set ppFrame to <c>NULL</c>.
		/// </param>
		/// <param name="ppDoc">
		/// A pointer to an IOleInPlaceUIWindow pointer variable that receives the interface pointer to the document window. If the
		/// document window is the same as the frame window, ppDoc is set to <c>NULL</c>. In this case, the object can only use ppFrame
		/// or border negotiation. If an error is returned, the implementation must set ppDoc to <c>NULL</c>.
		/// </param>
		/// <param name="lprcPosRect">
		/// A pointer to a RECT structure for the rectangle containing the position of the in-place object in the client coordinates of
		/// its parent window. If an error is returned, this parameter must be set to <c>NULL</c>.
		/// </param>
		/// <param name="lprcClipRect">
		/// A pointer to a RECT structure for the outer rectangle containing the in-place object's position rectangle (lprcPosRect).
		/// This rectangle is relative to the client area of the object's parent window. If an error is returned, this parameter must be
		/// set to <c>NULL</c>.
		/// </param>
		/// <param name="lpFrameInfo">
		/// A pointer to an OLEINPLACEFRAMEINFO structure the container is to fill in with appropriate data. If an error is returned,
		/// this parameter must be set to <c>NULL</c>.
		/// </param>
		/// <returns>
		/// <para>This method returns S_OK on success. Other possible return values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One or more of the supplied pointers is invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_UNEXPECTED</term>
		/// <term>An unexpected error has occurred.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The OLEINPLACEFRAMEINFO structure provides data needed by OLE to dispatch keystroke accelerators to a container frame while
		/// an object is active in place.
		/// </para>
		/// <para>
		/// When an object is activated, it calls <c>GetWindowContext</c> from its container. The container returns the handle to its
		/// in-place accelerator table through the OLEINPLACEFRAMEINFO structure. Before calling <c>GetWindowContext</c>, the object
		/// must provide the size of the <c>OLEINPLACEFRAMEINFO</c> structure by filling in the cb member, pointed to by lpFrameInfo.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-ioleinplacesite-getwindowcontext HRESULT
		// GetWindowContext( IOleInPlaceFrame **ppFrame, IOleInPlaceUIWindow **ppDoc, LPRECT lprcPosRect, LPRECT lprcClipRect,
		// LPOLEINPLACEFRAMEINFO lpFrameInfo );
		[PreserveSig]
		new unsafe HRESULT GetWindowContext(out IOleInPlaceFrame ppFrame, out IOleInPlaceUIWindow ppDoc, [Out] RECT* lprcPosRect, [Out] RECT* lprcClipRect, [Out] OLEINPLACEFRAMEINFO* lpFrameInfo);

		/// <summary>Instructs the container to scroll the view of the object by the specified number of pixels.</summary>
		/// <param name="scrollExtant">The number of pixels by which to scroll in the X and Y directions.</param>
		/// <returns>
		/// <para>This method returns S_OK on success. Other possible return values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The specified pointer is not valid.</term>
		/// </item>
		/// <item>
		/// <term>E_UNEXPECTED</term>
		/// <term>An unexpected error has occurred.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// As a result of scrolling, the object's visible rectangle can change. If that happens, the container should give the new
		/// clipping rectangle to the object by calling IOleInPlaceObject::SetObjectRects. The intersection of the lprcClipRect and
		/// lprcPosRect rectangles gives the new visible rectangle. See IOleInPlaceSite::GetWindowContext for more information.
		/// </para>
		/// <para>Notes to Callers</para>
		/// <para>Called by an active, in-place object when it is asking the container to scroll.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-ioleinplacesite-scroll HRESULT Scroll( SIZE scrollExtant );
		[PreserveSig]
		new HRESULT Scroll(SIZE scrollExtant);

		/// <summary>
		/// Notifies the container that it should reinstall its user interface and take focus, and whether the object has an undoable state.
		/// </summary>
		/// <param name="fUndoable">Specifies whether the object can undo changes (TRUE) or not (FALSE).</param>
		/// <returns>
		/// <para>This method returns S_OK on success. Other possible return values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_UNEXPECTED</term>
		/// <term>An unexpected error has occurred.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The object indicates whether it can undo changes through the fUndoable flag. If the object can undo changes, the container
		/// can (by the user invoking the <c>Edit Undo</c> command) call the IOleInPlaceObject::ReactivateAndUndo method to undo the changes.
		/// </para>
		/// <para>Notes to Callers</para>
		/// <para>
		/// <c>IOleInPlaceSite::OnUIDeactivate</c> is called by the site's immediate child object when it is deactivating to notify the
		/// container that it should reinstall its own user interface components and take focus. The container should wait for the call
		/// to <c>IOleInPlaceSite::OnUIDeactivate</c> to complete before fully cleaning up and destroying any composite submenus.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-ioleinplacesite-onuideactivate HRESULT OnUIDeactivate(
		// BOOL fUndoable );
		[PreserveSig]
		new HRESULT OnUIDeactivate([MarshalAs(UnmanagedType.Bool)] bool fUndoable);

		/// <summary>Notifies the container that the object is no longer active in place.</summary>
		/// <returns>
		/// <para>This method returns S_OK on success. Other possible return values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_UNEXPECTED</term>
		/// <term>An unexpected error has occurred.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Notes to Callers</para>
		/// <para>
		/// <c>OnInPlaceDeactivate</c> is called by an in-place object when it is fully deactivated. This function notifies the
		/// container that the object has been deactivated, and it gives the container a chance to run code pertinent to the object's
		/// deactivation. In particular, <c>OnInPlaceDeactivate</c> is called as a result of IOleInPlaceObject::InPlaceDeactivate being
		/// called. Calling <c>OnInPlaceDeactivate</c> indicates that the object can no longer support Undo.
		/// </para>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// If the container is holding pointers to the IOleInPlaceObject and IOleInPlaceActiveObject interface implementations, it
		/// should release them after the <c>OnInPlaceDeactivate</c> call.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-ioleinplacesite-oninplacedeactivate HRESULT OnInPlaceDeactivate();
		[PreserveSig]
		new HRESULT OnInPlaceDeactivate();

		/// <summary>Instructs the container to discard its undo state. The container should not call IOleInPlaceObject::ReActivateAndUndo.</summary>
		/// <returns>
		/// <para>This method returns S_OK on success. Other possible return values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_UNEXPECTED</term>
		/// <term>An unexpected error has occurred.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// If an object is activated in place and the object's associated object application maintains only one level of undo, there is
		/// no need to have more than one entry on the undo stack. That is, after a change has been made to the active object that
		/// invalidates its undo state saved by the container, there is no need to maintain this undo state in the container.
		/// </para>
		/// <para>Notes to Callers</para>
		/// <para>
		/// <c>DiscardUndoState</c> is called by the active object while performing some action that would discard the undo state of the
		/// object. The in-place object calls this method to notify the container to discard the object's last saved undo state.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-ioleinplacesite-discardundostate HRESULT DiscardUndoState();
		[PreserveSig]
		new HRESULT DiscardUndoState();

		/// <summary>Deactivates the object, ends the in-place session, and reverts to the container's saved undo state.</summary>
		/// <returns>
		/// <para>This method returns S_OK on success. Other possible return values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_UNEXPECTED</term>
		/// <term>An unexpected error has occurred.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Notes to Callers</para>
		/// <para>Called by the active object when the user invokes undo just after activating the object.</para>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// Upon completion of this call, the container should call IOleInPlaceObject::UIDeactivate to remove the user interface for the
		/// object, activate itself, and undo.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-ioleinplacesite-deactivateandundo HRESULT DeactivateAndUndo();
		[PreserveSig]
		new HRESULT DeactivateAndUndo();

		/// <summary>Notifies the container that the object extents have changed.</summary>
		/// <param name="lprcPosRect">
		/// A pointer a RECT structure that contains the position of the in-place object in the client coordinates of its parent window.
		/// </param>
		/// <returns>
		/// <para>This method returns S_OK on success. Other possible return values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The supplied pointer is invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_UNEXPECTED</term>
		/// <term>An unexpected error occurred.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Notes to Callers</para>
		/// <para>The <c>OnPosRectChange</c> method is called by the in-place object.</para>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// When the in-place object calls <c>OnPosRectChange</c>, the container must call IOleInPlaceObject::SetObjectRects to specify
		/// the new position of the in-place window and the clipping rectangle. Only then does the object resize its window.
		/// </para>
		/// <para>
		/// In most cases, the object grows to the right and/or down. There could be cases where the object grows to the left and/or up,
		/// as conveyed through lprcPosRect. It is also possible to change the object's position without changing its size.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-ioleinplacesite-onposrectchange HRESULT OnPosRectChange(
		// LPCRECT lprcPosRect );
		[PreserveSig]
		new HRESULT OnPosRectChange(in RECT lprcPosRect);

		/// <summary>Called by the embedded object to determine whether it needs to redraw itself upon activation.</summary>
		/// <param name="pfNoRedraw">
		/// A pointer to a variable that receives the current redraw status. The status is <c>TRUE</c> if the object need not redraw
		/// itself upon activation and <c>FALSE</c> otherwise. Windowless objects usually do not need the value returned by this
		/// parameter and may pass a <c>NULL</c> pointer to save the container the burden of computing this value.
		/// </param>
		/// <param name="dwFlags">
		/// Indicates whether the object is activated as a windowless object. This parameter takes values from the ACTIVATEFLAGS
		/// enumeration. See IOleInPlaceSiteWindowless for more information on windowless objects.
		/// </param>
		/// <returns>
		/// <para>
		/// This method returns S_OK if the container allows the in-place activation. Other possible return values include the following.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_UNEXPECTED</term>
		/// <term>An unexpected error has occurred.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method replaces IOleInPlaceSite::OnInPlaceActivate. If the older method is used, the object must always redraw itself
		/// on activation.
		/// </para>
		/// <para>
		/// Windowless objects are required to use this method instead of IOleInPlaceSite::OnInPlaceActivate to notify the container of
		/// whether they are activating windowless or not.
		/// </para>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// The container should carefully check the invalidation status of the object, its z-order, clipping and any other relevant
		/// parameters to determine the appropriate value to return in pfNoRedraw.
		/// </para>
		/// <para>
		/// A container can cache the value of the ACTIVATEFLAGS enumeration instead of calling the GetWindow method in the
		/// IOleInPlaceObjectWindowless interface repeatedly.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ioleinplacesiteex-oninplaceactivateex HRESULT
		// OnInPlaceActivateEx( BOOL *pfNoRedraw, DWORD dwFlags );
		[PreserveSig]
		HRESULT OnInPlaceActivateEx([MarshalAs(UnmanagedType.Bool)] out bool pfNoRedraw, ACTIVATEFLAGS dwFlags);

		/// <summary>Notifies the container if the object needs to be redrawn upon deactivation.</summary>
		/// <param name="fNoRedraw">
		/// If <c>TRUE</c>, the container need not redraw the object after completing the deactivation; if <c>FALSE</c> the object must
		/// be redrawn after deactivation.
		/// </param>
		/// <returns>
		/// <para>This method returns S_OK on success. Other possible return values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_UNEXPECTED</term>
		/// <term>An unexpected error has occurred.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// This method replaces IOleInPlaceSite::OnInPlaceDeactivate. If the older method is used, the object must always be redrawn on deactivation.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ioleinplacesiteex-oninplacedeactivateex HRESULT
		// OnInPlaceDeactivateEx( BOOL fNoRedraw );
		[PreserveSig]
		HRESULT OnInPlaceDeactivateEx([MarshalAs(UnmanagedType.Bool)] bool fNoRedraw);

		/// <summary>Notifies the container that the object is about to enter the UI-active state.</summary>
		/// <returns>
		/// <para>
		/// This method returns S_OK if the object can continue the activation process and call IOleInPlaceSite::OnUIActivate. Other
		/// possible return values include the following.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>
		/// The object cannot enter the UI-active state. The object must call IOleInPlaceSite::OnUIDeactivate so the container can
		/// perform its the necessary processing to restore the focus.
		/// </term>
		/// </item>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>The operation failed.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// An object calls this method to determine if it can enter the UI-active state and to notify the container that it is about to
		/// make this transition. The container can return S_FALSE to deny this request, for example, if the end user has canceled the
		/// operation or if the currently active object will not relinquish its active state.
		/// </para>
		/// <para>
		/// If the object does not call <c>IOleInPlaceSiteEx::RequestUIActivate</c>, the container handles data validation and fires
		/// Enter and Exit events from IOleInPlaceSite::OnUIActivate.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ioleinplacesiteex-requestuiactivate HRESULT RequestUIActivate();
		[PreserveSig]
		HRESULT RequestUIActivate();
	}

	/// <summary>
	/// <para>
	/// Extends the IOleInPlaceSiteEx interface. <c>IOleInPlaceSiteWindowless</c> works with IOleInPlaceObjectWindowless which is
	/// implemented on the windowless object. Together, these two interfaces provide services to a windowless object from its container
	/// allowing the windowless object to:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>Process window messages</term>
	/// </item>
	/// <item>
	/// <term>Participate in drag and drop operations</term>
	/// </item>
	/// <item>
	/// <term>Perform drawing operations</term>
	/// </item>
	/// </list>
	/// <para>
	/// Having a window can place unnecessary burdens on small objects, such as controls. It prevents an object from being
	/// non-rectangular. It prevents windows from being transparent. It prevents the small instance size needed by many small controls.
	/// </para>
	/// <para>
	/// A windowless object can enter the in-place active state without requiring a window or the resources associated with a window.
	/// Instead, the object's container provides the object with many of the services associated with having a window.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nn-ocidl-ioleinplacesitewindowless
	[PInvokeData("ocidl.h", MSDNShortId = "NN:ocidl.IOleInPlaceSiteWindowless")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("922EADA0-3424-11CF-B670-00AA004CD6D8")]
	public interface IOleInPlaceSiteWindowless : IOleInPlaceSiteEx
	{
		/// <summary>Informs an object if its container can support it as a windowless object that can be in-place activated.</summary>
		/// <returns>This method returns S_OK if the object can activate in-place without a window.</returns>
		/// <remarks>
		/// <para>If this method returns S_OK, the container can dispatch events to it using IOleInPlaceObjectWindowless.</para>
		/// <para>If this method returns S_FALSE, the object should create a window and behave as a normal compound document object.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ioleinplacesitewindowless-canwindowlessactivate HRESULT CanWindowlessActivate();
		[PreserveSig]
		HRESULT CanWindowlessActivate();

		/// <summary>Called by an in-place active, windowless object to determine whether it still has the mouse capture.</summary>
		/// <returns>
		/// <para>This method returns S_OK on success. Other possible return values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>The object does not currently have the mouse capture.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>As an alternative to calling this method, the object can cache information about whether it has the mouse capture.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ioleinplacesitewindowless-getcapture HRESULT GetCapture();
		[PreserveSig]
		HRESULT GetCapture();

		/// <summary>Enables an in-place active, windowless object to capture all mouse messages.</summary>
		/// <param name="fCapture">
		/// If <c>TRUE</c>, the container should capture the mouse for the object. If <c>FALSE</c>, the container should release mouse
		/// capture for the object.
		/// </param>
		/// <returns>
		/// <para>
		/// This method returns S_OK if the mouse capture was successfully granted to the object. If called to release the mouse
		/// capture, this method must not fail. Other possible return values include the following.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>Mouse capture was denied to the object.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A windowless object captures the mouse input, by calling <c>IOleInPlaceSiteWindowless::SetCapture</c> with <c>TRUE</c> on
		/// its site object. The container can deny mouse capture, in which case this method returns S_FALSE. If the capture is granted,
		/// the container must set the Windows mouse capture to its own window and dispatch any subsequent mouse message to the object,
		/// regardless of whether the mouse cursor position is over this object or not.
		/// </para>
		/// <para>
		/// The object can later release mouse capture by calling <c>IOleInPlaceSiteWindowless::SetCapture</c> with <c>FALSE</c> on its
		/// site object. The capture can also be released because of an external event, such as the ESC key being pressed. In this case,
		/// the object is notified by a WM_CANCELMODE message that the container dispatches along with the keyboard focus.
		/// </para>
		/// <para>
		/// Containers should dispatch all mouse messages, including WM_SETCURSOR, to the windowless OLE object that has captured the
		/// mouse. If no object has captured the mouse, the container should dispatch the mouse message to the object under the mouse cursor.
		/// </para>
		/// <para>
		/// The container dispatches these window messages by calling IOleInPlaceObjectWindowless::OnWindowMessage on the windowless
		/// object. The windowless object can return S_FALSE to this method to indicate that it did not process the mouse message. Then,
		/// the container should perform the default behavior for the message by calling the DefWindowProc function. For WM_SETCURSOR,
		/// the container can either set the cursor itself or do nothing.
		/// </para>
		/// <para>
		/// Objects can also use IOleInPlaceSiteWindowless::OnDefWindowMessage to invoke the default message processing from the
		/// container. In the case of the WM_SETCURSOR message, this allows an object to take action if the container does not set the cursor.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ioleinplacesitewindowless-setcapture HRESULT SetCapture(
		// BOOL fCapture );
		[PreserveSig]
		HRESULT SetCapture([MarshalAs(UnmanagedType.Bool)] bool fCapture);

		/// <summary>Called by an in-place active, windowless object to determine whether it still has the keyboard focus.</summary>
		/// <returns>
		/// <para>This method returns S_OK on success. Other possible return values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>The object does not currently have the keyboard focus.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// A windowless object calls this method to find out if it currently has the focus or not. As an alternative to calling this
		/// method, the object can cache information about whether it has the keyboard focus or not.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ioleinplacesitewindowless-getfocus HRESULT GetFocus();
		[PreserveSig]
		HRESULT GetFocus();

		/// <summary>Sets the keyboard focus for a UI-active, windowless object.</summary>
		/// <param name="fFocus">
		/// If <c>TRUE</c>, sets the keyboard focus to the calling object. If <c>FALSE</c>, removes the keyboard focus from the calling
		/// object, provided that the object has the focus.
		/// </param>
		/// <returns>
		/// <para>
		/// This method returns S_OK if the keyboard focus was successfully given to the object. If this method is called to release the
		/// focus, it should never fail. Other possible return values include the following.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>Keyboard focus was denied to the object.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A windowless object calls this method whenever a windowed object would call the SetFocus function. Through this call, the
		/// windowless object obtains the keyboard focus and can respond to window messages. Normally, this call is made during the UI
		/// activation process and within the notification methods IOleInPlaceActiveObject::OnDocWindowActivate with <c>TRUE</c> and
		/// IOleInPlaceActiveObject::OnFrameWindowActivate with <c>TRUE</c>.
		/// </para>
		/// <para>
		/// In response to this call, the container sets the Windows focus to the window being used to get keyboard messages (usually
		/// the container window) and redirects any subsequent keyboard messages to the windowless object that requested the focus.
		/// </para>
		/// <para>
		/// A windowless object also calls the <c>IOleInPlaceSiteWindowless::SetFocus</c> method with the fFocus parameter set to
		/// <c>FALSE</c> to release the keyboard focus without assigning it to any other object. In this case, the container must call
		/// the SetFocus function with a <c>NULL</c> parameter so that no window has the focus.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ioleinplacesitewindowless-setfocus HRESULT SetFocus( BOOL
		// fFocus );
		[PreserveSig]
		HRESULT SetFocus([MarshalAs(UnmanagedType.Bool)] bool fFocus);

		/// <summary>Provides an object with a handle to a device context for a screen or compatible device from its container.</summary>
		/// <param name="pRect">
		/// A pointer to the rectangle that the object wants to redraw, in client coordinates of the containing window. If this
		/// parameter is <c>NULL</c>, the object's full extent is redrawn.
		/// </param>
		/// <param name="grfFlags">A combination of values from the OLEDCFLAGS enumeration.</param>
		/// <param name="phDC">A pointer to a returned device context.</param>
		/// <returns>
		/// <para>This method returns S_OK on success. Other possible return values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>OLE_E_NESTEDPAINT</term>
		/// <term>
		/// The container is already in the middle of a paint session. That is, this method has already been called, and the
		/// IOleInPlaceSiteWindowless::ReleaseDC method has not yet been called.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>A device context obtained by this method should be released by calling IOleInPlaceSiteWindowless::ReleaseDC.</para>
		/// <para>
		/// Like other methods in this interface, rectangles are specified in client coordinates of the containing window. The container
		/// is expected to intersect this rectangle with the object's site rectangle and clip out everything outside the resulting
		/// rectangle. This prevents objects from inadvertently drawing where they are not supposed to.
		/// </para>
		/// <para>
		/// Containers are also expected to map the device context origin so the object can draw in client coordinates of the containing
		/// window, usually the container's window. If the container is merely passing its window device context, this occurs
		/// automatically. If it is returning another device context, for example, an offscreen memory device context, then the viewport
		/// origin should be set appropriately.
		/// </para>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// Depending whether it is returning an on-screen or off-screen device context and depending on how sophisticated it is,
		/// container can use one of the following algorithms:
		/// </para>
		/// <list type="number">
		/// <item>
		/// <term>On-screen, One Pass Drawing</term>
		/// </item>
		/// <item>
		/// <term>On-screen, Two Pass Drawing</term>
		/// </item>
		/// <item>
		/// <term>Off-screen Drawing</term>
		/// </item>
		/// </list>
		/// <para>
		/// When this method returns, the clipping region in the device context should be set so that the object can't paint in any area
		/// it is not supposed to. If the object is not opaque, the background should have been painted. If the device context is a
		/// screen, any overlapping opaque areas should be clipped out.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ioleinplacesitewindowless-getdc HRESULT GetDC( LPCRECT
		// pRect, DWORD grfFlags, HDC *phDC );
		[PreserveSig]
		HRESULT GetDC([In, Optional] PRECT? pRect, OLEDCFLAGS grfFlags, out HDC phDC);

		/// <summary>Releases the device context previously obtained by a call to IOleInPlaceSiteWindowless::GetDC.</summary>
		/// <param name="hDC">The device context to be released.</param>
		/// <returns>This method returns S_OK on success.</returns>
		/// <remarks>
		/// An object calls this method to notify its container that the object is done with the device context. If the device context
		/// was used for drawing, the container should ensure that all overlapping objects are repainted correctly. If the device
		/// context was an offscreen device context, its content should also be copied to the screen in the rectangle originally passed
		/// to IOleInPlaceSiteWindowless::GetDC. See <c>IOleInPlaceSiteWindowless::GetDC</c> for implementation notes relevant to <c>IOleInPlaceSiteWindowless::ReleaseDC</c>.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ioleinplacesitewindowless-releasedc HRESULT ReleaseDC( HDC
		// hDC );
		[PreserveSig]
		HRESULT ReleaseDC(HDC hDC);

		/// <summary>Enables an object to invalidate a specified rectangle of its in-place image on the screen.</summary>
		/// <param name="pRect">
		/// The rectangle to be invalidated, in client coordinates of the containing window. If this parameter is <c>NULL</c>, the
		/// object's full extent is invalidated.
		/// </param>
		/// <param name="fErase">
		/// Specifies whether the background within the update region is to be erased when the region is updated. If this parameter is
		/// <c>TRUE</c>, the background is erased. If this parameter is <c>FALSE</c>, the background remains unchanged.
		/// </param>
		/// <returns>This method returns S_OK on success.</returns>
		/// <remarks>
		/// An object is only allowed to invalidate pixels contained in its own site rectangle. Any attempt to invalidate an area
		/// outside of that rectangle should result in a no-op.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ioleinplacesitewindowless-invalidaterect HRESULT
		// InvalidateRect( LPCRECT pRect, BOOL fErase );
		[PreserveSig]
		HRESULT InvalidateRect([In, Optional] PRECT? pRect, [MarshalAs(UnmanagedType.Bool)] bool fErase);

		/// <summary>Enables an object to invalidate a specified region of its in-place image on the screen.</summary>
		/// <param name="hRGN">
		/// The region to invalidate, in client coordinates of the containing window. If this parameter is <c>NULL</c>, the object's
		/// full extent is invalidated.
		/// </param>
		/// <param name="fErase">
		/// Specifies whether the background within the update region is to be erased when the region is updated. If this parameter is
		/// <c>TRUE</c>, the background is erased. If this parameter is <c>FALSE</c>, the background remains unchanged.
		/// </param>
		/// <returns>This method returns S_OK on success.</returns>
		/// <remarks>
		/// An object is only allowed to invalidate pixels contained in its own site region. Any attempt to invalidate an area outside
		/// of that region should result in a no-op.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ioleinplacesitewindowless-invalidatergn HRESULT
		// InvalidateRgn( HRGN hRGN, BOOL fErase );
		[PreserveSig]
		HRESULT InvalidateRgn([Optional] HRGN hRGN, [MarshalAs(UnmanagedType.Bool)] bool fErase);

		/// <summary>Enables an object to scroll an area within its in-place active image on the screen.</summary>
		/// <param name="dx">The amount to scroll the x-axis.</param>
		/// <param name="dy">The amount to scroll the y-axis.</param>
		/// <param name="pRectScroll">
		/// The rectangle to scroll, in client coordinates of the containing window. A value of <c>NULL</c> indicates the full object.
		/// </param>
		/// <param name="pRectClip">
		/// The rectangle to clip. Only pixels scrolling into this rectangle are drawn. Pixels scrolling out are not. If this parameter
		/// is <c>NULL</c>, the rectangle is not clipped.
		/// </param>
		/// <returns>This method returns S_OK on success.</returns>
		/// <remarks>
		/// <para>
		/// This method should take in account the fact that the caller may be transparent and that there may be opaque or transparent
		/// overlapping objects. See Notes to Implementers below for suggestions on algorithms this method can use.
		/// </para>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// Containers can implement this method in a variety of ways. However, all of them should account for the possibility that the
		/// object requesting scrolling may be transparent or may not have a solid background. Containers should also take into account
		/// that there may be overlapping objects.
		/// </para>
		/// <para>The simplest way to implement this method consists in simply redrawing the rectangle to scroll.</para>
		/// <para>
		/// An added refinement to this simple implementation is to use the ScrollDC function when the object requesting the scroll is
		/// opaque, the object has a solid background, and there are no overlapping objects.
		/// </para>
		/// <para>More sophisticated implementations can use the following procedure:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// Check whether the object is opaque and has a solid background, using IViewObjectEx::GetViewStatus. If not, simply invalidate
		/// the rectangle to scroll. An added refinement is to check whether the scrolling rectangle is entirely in the opaque region of
		/// a partially transparent object.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Get the window device context.</term>
		/// </item>
		/// <item>
		/// <term>Clip out the opaque parts of any overlapping object returned by IViewObjectEx::GetRect.</term>
		/// </item>
		/// <item>
		/// <term>Finally, call the ScrollDC function.</term>
		/// </item>
		/// <item>
		/// <term>Redraw the previously invalidated transparent parts of any overlapping object.</term>
		/// </item>
		/// </list>
		/// <para>
		/// Regardless of the scrolling and clipping rectangle, only pixels contained in the object's site rectangle will be painted.
		/// The area uncovered by the scrolling operation is invalidated and redrawn immediately, before this method returns.
		/// </para>
		/// <para>All redraw generated by this method should happen synchronously before this method returns.</para>
		/// <para>
		/// This method should automatically hide the caret during the scrolling operation and should move the caret by the scrolling
		/// amounts if it is inside the clip rectangle.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ioleinplacesitewindowless-scrollrect HRESULT ScrollRect(
		// INT dx, INT dy, LPCRECT pRectScroll, LPCRECT pRectClip );
		[PreserveSig]
		HRESULT ScrollRect(int dx, int dy, [In, Optional] PRECT? pRectScroll, [In, Optional] PRECT? pRectClip);

		/// <summary>Adjusts a specified rectangle if it is entirely or partially covered by overlapping, opaque objects.</summary>
		/// <param name="prc">The rectangle to be adjusted.</param>
		/// <returns>
		/// <para>
		/// This method returns S_OK if rectangle was adjusted successfully; meaning that the rectangle was not completely covered.
		/// Other possible return values include the following.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>
		/// The rectangle was adjusted successfully. Note S_FALSE means that the rectangle was completely covered. Its width and height
		/// are now NULL.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The main use of this method is to adjust the size of the caret. An object willing to create a caret should submit the caret
		/// rectangle to its site object by calling this method and using the adjusted rectangle returned from it for the caret. If the
		/// caret is entirely hidden, this method will return S_FALSE and the caret should not be shown at all in this case.
		/// </para>
		/// <para>In a situation where objects are overlapping this method should return the largest rectangle that is fully visible.</para>
		/// <para>This method can also be used to figure whether a point or a rectangular area is visible or hidden by overlapping objects.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ioleinplacesitewindowless-adjustrect HRESULT AdjustRect(
		// LPRECT prc );
		[PreserveSig]
		HRESULT AdjustRect(ref RECT prc);

		/// <summary>Invokes the default processing for all messages passed to an object.</summary>
		/// <param name="msg">The identifier for the window message provided to the container by Windows.</param>
		/// <param name="wParam">A parameter for the window message provided to the container by Windows.</param>
		/// <param name="lParam">A parameter for the window message provided to the container by Windows.</param>
		/// <param name="plResult">A pointer to result code for the window message.</param>
		/// <returns>
		/// <para>This method returns S_OK on success. Other possible return values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>The container's default processing for the window message was not invoked. See Note to Implementers below.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A windowless object can explicitly invoke the default processing for a window message by calling this method. A container
		/// dispatches window messages to its windowless objects by calling IOleInPlaceObjectWindowless::OnWindowMessage. The object
		/// usually returns S_FALSE to indicate that it did not process the message. Then, the container can perform the default
		/// behavior for the message by calling the DefWindowProc function.
		/// </para>
		/// <para>
		/// Instead, the object can call this method on the container's site object to explicitly invoke the default processing. Then,
		/// the object can take action on its own if the container does not handle the message.
		/// </para>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// The container must pass the following window messages to its default window procedure (the DefWindowProc function) and
		/// return S_OK. Note that *plResult should contain the value returned by <c>DefWindowProc</c>.
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>WM_CHAR</term>
		/// </item>
		/// <item>
		/// <term>WM_DEADCHAR</term>
		/// </item>
		/// <item>
		/// <term>WM_IMExxx</term>
		/// </item>
		/// <item>
		/// <term>WM_KEYDOWN</term>
		/// </item>
		/// <item>
		/// <term>WM_KEYUP</term>
		/// </item>
		/// <item>
		/// <term>WM_MOUSEMOVE</term>
		/// </item>
		/// <item>
		/// <term>WM_SYSCHAR</term>
		/// </item>
		/// <item>
		/// <term>WM_SYSDEADCHAR</term>
		/// </item>
		/// <item>
		/// <term>WM_SYSKEYUP</term>
		/// </item>
		/// <item>
		/// <term>WM_XBUTTONDOWN</term>
		/// </item>
		/// <item>
		/// <term>WM_XBUTTONUP</term>
		/// </item>
		/// <item>
		/// <term>WM_XBUTTONDBLCLK</term>
		/// </item>
		/// </list>
		/// <para>The container can either process the window messages as its own and return S_OK or not do anything and return S_FALSE.</para>
		/// <list type="bullet">
		/// <item>
		/// <term>WM_CONTEXTMENU</term>
		/// </item>
		/// <item>
		/// <term>WM_HELP</term>
		/// </item>
		/// <item>
		/// <term>WM_SETCURSOR</term>
		/// </item>
		/// </list>
		/// <para>If the container returns S_FALSE, the object can take action to process the window message on its own.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ioleinplacesitewindowless-ondefwindowmessage HRESULT
		// OnDefWindowMessage( UINT msg, WPARAM wParam, LPARAM lParam, LRESULT *plResult );
		[PreserveSig]
		HRESULT OnDefWindowMessage(uint msg, [In] IntPtr wParam, [In] IntPtr lParam, out IntPtr plResult);
	}

	/// <summary>
	/// <para>
	/// Enables undo units to contain child undo units. For example, a complex action can be presented to the end user as a single undo
	/// action even though a number of separate actions are involved. All the subordinate undo actions are contained within the
	/// top-level, parent undo unit.
	/// </para>
	/// <para>
	/// A parent undo unit is initially created using the IOleUndoManager::Open method. The addition of undo units should always be done
	/// through the undo manager. The IOleParentUndoUnit::Open and IOleParentUndoUnit::Close methods on parent units will end up being
	/// called by the undo manager. Having parent units call back into the undo manager will cause infinite recursion.
	/// </para>
	/// <para>
	/// While a parent unit is open, the undo manager adds undo units to it by calling IOleParentUndoUnit::Add. When the undo manager
	/// closes a top-level parent, the entire undo unit with its nested subordinates is placed on top of the undo stack.
	/// </para>
	/// <para>
	/// An enabling parent is required to be open on the stack before any other undo units can be added. If one isn't open, the stack
	/// should be cleared instead. This is to ensure that undo units only get added as a result of user actions and not programmatic
	/// actions. For example, if your application wants to make clicking a certain button undoable, but that same action is also exposed
	/// through the object model. That action should be undoable through the user interface but not the object model because you cannot
	/// restore the state of the user's script code. Because the same code implements the change in both cases, the UI code that handles
	/// the button click should open an enabling parent on the stack, call the appropriate code, and then close the parent unit. The
	/// object model code would not open a parent unit, causing the undo stack to be cleared.
	/// </para>
	/// <para>
	/// A blocking parent is used when you do not want your code to call other code that you know may try to add undo units to the
	/// stack. For example, you should use a blocking parent if you call code that creates undo units, that your outer code has already
	/// created that will fully undo all the desired behavior.
	/// </para>
	/// <para>
	/// A non-enabling parent is used when you fire an event in response to a user action. The stack would be cleared only if the event
	/// handler did something that tried to create an undo unit, but if no handler exists then the undo stack would be preserved.
	/// </para>
	/// <para>If an object needs to create a parent unit, there are several cases to consider:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// To create an enabling parent unit, the object calls IOleUndoManager::GetOpenParentState on the undo manager and checks the
	/// return value. If the value is S_FALSE, then the object creates the enabling parent and opens it. If the return value is S_OK,
	/// then there is a parent already open. If the open parent is blocked (UAS_BLOCKED bit set), or an enabling parent (UAS_BLOCKED and
	/// UAS_NOPARENTENABLE bits not set), then there is no need to create the enabling parent. If the currently open parent is a
	/// disabling parent (UAS_NOPARENTENABLE bit set), then the enabling parent should be created and opened to re-enable adding undo
	/// units. Note that UAS_NORMAL has a value of zero, which means it is the absence of all other bits and is not a bit flag that can
	/// be set. If comparing *pdwState against UAS_NORMAL, mask out unused bits from pdwState with UAS_MASK to allow for future expansion.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// To create a blocked parent, the object calls IOleUndoManager::GetOpenParentState and checks for an open parent that is already
	/// blocked. If one exists, then there is no need to create the new blocking parent. Otherwise, the object creates it and opens it
	/// on the stack.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// To create a disabling parent, the object calls IOleUndoManager::GetOpenParentState and checks for an open parent that is blocked
	/// or disabling. If either one exists it is unnecessary to create the new parent. Otherwise, the object creates the parent and
	/// opens it on the stack.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// In the event that both the UAS_NOPARENTENABLE and UAS_BLOCKED flags are set, the flag that is most relevant to the caller should
	/// be used with UAS_NOPARENTENABLE taking precedence. For example, if an object is creating a simple undo unit, it should pay
	/// attention to the UAS_NOPARENTENABLE flag and clear the undo stack. If it is creating an enabling parent unit, then it should pay
	/// attention to the UAS_BLOCKED flag and skip the creation.
	/// </para>
	/// <para>When the parent undo unit is marked blocked, it discards any undo units it receives.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nn-ocidl-ioleparentundounit
	[PInvokeData("ocidl.h", MSDNShortId = "NN:ocidl.IOleParentUndoUnit")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("A1FAF330-EF97-11CE-9BC9-00AA00608E01")]
	public interface IOleParentUndoUnit : IOleUndoUnit
	{
		/// <summary>
		/// Instructs the undo unit to carry out its action. Note that if it contains child undo units, it must call their Do methods as well.
		/// </summary>
		/// <param name="pUndoManager">A pointer to the undo manager. See IOleUndoManager.</param>
		/// <returns>This method returns S_OK on success.</returns>
		/// <remarks>
		/// <para>
		/// The undo unit is responsible for carrying out its action. Performing its own undo action results in another action that can
		/// potentially be reversed. However, if pUndoManager is <c>NULL</c>, the undo unit should perform its undo action but should
		/// not attempt to put anything on the redo or undo stack.
		/// </para>
		/// <para>
		/// If pUndoManager is not <c>NULL</c>, then the unit is required to put a corresponding unit on the redo or undo stack. As a
		/// result, this method either moves itself to the redo or undo stack, or it creates a new undo unit and adds it to the
		/// appropriate stack. After creating a new undo unit, this undo unit calls IOleUndoManager::Open or IOleUndoManager::Add. The
		/// undo manager will put the new undo unit on the undo or redo stack depending on its current state.
		/// </para>
		/// <para>
		/// A parent unit must pass to its children the same undo manager, possibly <c>NULL</c>, that was given to the parent. It is
		/// permissible, but not necessary, when pUndoManager is <c>NULL</c> to open a parent unit on the redo or undo stack as long as
		/// it is not committed. A blocked parent unit ensures that nothing is added to the stack by child units.
		/// </para>
		/// <para>
		/// If this undo unit is a parent unit, it should put itself on the redo or undo stack before calling the <c>Do</c> method on
		/// its children.
		/// </para>
		/// <para>After calling this method, the undo manager must release the undo unit.</para>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// See the IOleUndoManager interface for error handling strategies for undo units. The error handling strategy affects the
		/// implementation of this method, particularly for parent units.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ioleundounit-do HRESULT Do( IOleUndoManager *pUndoManager );
		[PreserveSig]
		new HRESULT Do(IOleUndoManager? pUndoManager);

		/// <summary>Retrieves a description of the undo unit that can be used in the undo or redo user interface.</summary>
		/// <param name="pBstr">A pointer to string that describes this undo unit.</param>
		/// <returns>This method returns S_OK on success.</returns>
		/// <remarks>
		/// <para>All units are required to provide a user-readable description of themselves.</para>
		/// <para>Notes to Callers</para>
		/// <para>The pbstr parameter is allocated with the standard string allocator. The caller is responsible for freeing this string.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ioleundounit-getdescription HRESULT GetDescription( BSTR
		// *pBstr );
		[PreserveSig]
		new HRESULT GetDescription([MarshalAs(UnmanagedType.BStr)] out string pBstr);

		/// <summary>Retrieves the CLSID and a type identifier for the undo unit.</summary>
		/// <param name="pClsid">A pointer to CLSID for the undo unit.</param>
		/// <param name="plID">A pointer to the type identifier for the undo unit.</param>
		/// <returns>This method returns S_OK on success.</returns>
		/// <remarks>
		/// <para>
		/// A parent undo unit can call this method on its child units to determine whether it can apply special handling to them. The
		/// CLSID returned can be the CLSID of the undo unit itself, of its creating object, or an arbitrary GUID. The undo unit has the
		/// option of returning CLSID_NULL, in which case the caller can make no assumptions about the type of this unit. The only
		/// requirement is that the CLSID and type identifier together uniquely identify this type of undo unit.
		/// </para>
		/// <para>
		/// Note that the undo manager and parent undo units do not have the option of accepting or rejecting child units based on their type.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ioleundounit-getunittype HRESULT GetUnitType( CLSID
		// *pClsid, LONG *plID );
		[PreserveSig]
		new HRESULT GetUnitType(out Guid pClsid, out int plID);

		/// <summary>Notifies the last undo unit in the collection that a new unit has been added.</summary>
		/// <returns>Implementations of this method always return S_OK. The <c>HRESULT</c> return type is used only for remotability.</returns>
		/// <remarks>
		/// <para>
		/// An object can create an undo unit for an action and add it to the undo manager but can continue inserting data into it
		/// through private interfaces. When the undo unit receives a call to this method, it communicates back to the creating object
		/// that the context has changed. Then, the creating object stops inserting data into the undo unit.
		/// </para>
		/// <para>
		/// The parent undo unit calls this method on its most recently added child undo unit to notify the child unit that the context
		/// has changed and a new undo unit has been added.
		/// </para>
		/// <para>
		/// For example, this method is used for supporting fuzzy actions, like typing, which do not have a clear point of termination
		/// but instead are terminated only when something else happens.
		/// </para>
		/// <para>
		/// This method may not always be called if the undo manager or an open parent unit chooses to discard the unit by calling
		/// IUnknown::Release instead. Any connection which feeds data to the undo unit behind the scenes through private interfaces
		/// should not IUnknown::AddRef the undo unit.
		/// </para>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// Note that parent units merely delegate this method to their most recently added child unit. A parent unit should terminate
		/// communication through any private interfaces when it is closed. A parent unit knows it is being closed when it receives
		/// S_FALSE from calling IOleParentUndoUnit::Close.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ioleundounit-onnextadd HRESULT OnNextAdd();
		[PreserveSig]
		new HRESULT OnNextAdd();

		/// <summary>Opens a new parent undo unit, which becomes part of the containing unit's undo stack.</summary>
		/// <param name="pPUU">An IOleParentUndoUnit pointer to the parent undo unit to be opened.</param>
		/// <returns>This method returns S_OK if the parent undo unit was successfully opened or it is currently blocked.</returns>
		/// <remarks>
		/// <para>
		/// The specified parent unit is created and remains open. The undo manager then calls the IOleParentUndoUnit::Add or
		/// <c>IOleParentUndoUnit::Open</c> methods on this parent unit to add new units to it. This parent unit receives any additional
		/// undo units until its IOleParentUndoUnit::Close method is called.
		/// </para>
		/// <para>
		/// The parent unit specified by pPUU is not added to the undo stack until its IOleParentUndoUnit::Close method is called with
		/// the fCommit parameter set to <c>TRUE</c>.
		/// </para>
		/// <para>
		/// The parent undo unit or undo manager must contain any undo unit given to it unless it is blocked. If it is blocked, it must
		/// return S_OK but should do nothing else.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ioleparentundounit-open HRESULT Open( IOleParentUndoUnit
		// *pPUU );
		[PreserveSig]
		HRESULT Open(IOleParentUndoUnit pPUU);

		/// <summary>Closes the specified parent undo unit.</summary>
		/// <param name="pPUU">An IOleParentUndoUnit pointer to the currently open parent unit to be closed.</param>
		/// <param name="fCommit">
		/// Indicates whether to keep or discard the unit. If <c>TRUE</c>, the unit is kept in the collection. If <c>FALSE</c>, the unit
		/// is discarded. This parameter is used to allow the client to discard an undo unit under construction if an error or a
		/// cancellation occurs.
		/// </param>
		/// <returns>
		/// <para>This method returns S_OK on success. Other possible return values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>The parent undo unit did not have an open child and it was successfully closed.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>
		/// If pPUU does not match the currently open parent undo unit, then implementations of this method should return E_INVALIDARG
		/// without changing any internal state unless the parent unit is blocked.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A parent undo unit knows it is being closed when it returns S_FALSE from this method. At that time, it should terminate any
		/// communication with other objects which may be giving data to it through private interfaces.
		/// </para>
		/// <para>Notes to Callers</para>
		/// <para>An error return indicates a fatal error condition.</para>
		/// <para>The parent unit or undo manager must accept the undo unit if fCommit is <c>TRUE</c>.</para>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// To process a close request, a parent undo unit first checks to see if it has an open child unit. If it does not, it returns S_FALSE.
		/// </para>
		/// <para>
		/// If it does have a child unit open, it calls the <c>IOleParentUndoUnit::Close</c> method on the child. If the child returns
		/// S_FALSE, then the parent undo unit verifies that pPUU points to the child unit, and closes that child undo unit. If the
		/// child returns S_OK then it handled the close internally and its parent should do nothing.
		/// </para>
		/// <para>
		/// If the parent unit is blocked, it should check the pPUU parameter to determine the appropriate return code. If pPUU is
		/// pointing to itself, then it should return S_FALSE.
		/// </para>
		/// <para>Otherwise, it should return S_OK; the fCommit parameter is ignored; and no action is taken.</para>
		/// <para>
		/// If pPUU does not match the currently open parent undo unit, then implementations of this method should return E_INVALIDARG
		/// without changing any internal state. The only exception to this is if the unit is blocked.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ioleparentundounit-close HRESULT Close( IOleParentUndoUnit
		// *pPUU, BOOL fCommit );
		[PreserveSig]
		HRESULT Close(IOleParentUndoUnit pPUU, [MarshalAs(UnmanagedType.Bool)] bool fCommit);

		/// <summary>Adds a simple undo unit to the collection.</summary>
		/// <param name="pUU">An IOleUndoUnit pointer to the undo unit to be added.</param>
		/// <returns>This method returns S_OK if the specified unit was successfully added or the parent unit was blocked.</returns>
		/// <remarks>
		/// The parent undo unit or undo manager must accept any undo unit given to it, unless it is blocked. If it is blocked, it
		/// should do nothing but return S_OK.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ioleparentundounit-add HRESULT Add( IOleUndoUnit *pUU );
		[PreserveSig]
		HRESULT Add(IOleUndoUnit pUU);

		/// <summary>
		/// Indicates whether the specified unit is a child of this undo unit or one of its children, that is if the specified unit is
		/// part of the hierarchy in this parent unit.
		/// </summary>
		/// <param name="pUU">An IOleUndoUnit pointer to the undo unit to be found.</param>
		/// <returns>
		/// This method returns S_OK if the specified undo unit is in the hierarchy subordinate to this parent; otherwise, S_FALSE.
		/// </returns>
		/// <remarks>
		/// This is typically called by the undo manager in its implementation of its IOleUndoManager::DiscardFrom method in the rare
		/// event that the unit being discarded is not a top-level unit. The parent unit should look in its own list first, then
		/// delegate to each child that is also a parent unit, as determined by doing a IUnknown::QueryInterface for IOleParentUndoUnit.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ioleparentundounit-findunit HRESULT FindUnit( IOleUndoUnit
		// *pUU );
		[PreserveSig]
		HRESULT FindUnit(IOleUndoUnit pUU);

		/// <summary>Retrieves state information about the innermost open parent undo unit.</summary>
		/// <param name="pdwState">A pointer to the state information. This information is a value taken from the UASFLAGS enumeration.</param>
		/// <returns>This method returns S_OK on success.</returns>
		/// <remarks>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// If the unit has an open child, it should delegate this method to that child. If not, it should fill in pdwState values
		/// appropriately and return. Note that a parent unit must never be blocked while it has an open child. If this happened it
		/// could prevent the child unit from being closed, which would cause serious problems.
		/// </para>
		/// <para>Notes to Callers</para>
		/// <para>
		/// When checking for a normal state, use the UAS_MASK value to mask unused bits in the pdwState parameter to this method for
		/// future compatibility.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ioleparentundounit-getparentstate HRESULT GetParentState(
		// DWORD *pdwState );
		[PreserveSig]
		HRESULT GetParentState(out UASFLAGS pdwState);
	}

	/// <summary>
	/// The <c>IOleUndoManager</c> interface enables containers to implement multi-level undo and redo operations for actions that occur
	/// within contained controls.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The control must create an undo unit with the IOleUndoUnit interface or a parent undo unit with the IOleParentUndoUnit interface
	/// derived from <c>IOleUndoUnit</c>. Both of these interfaces perform the undo action and the parent undo unit additionally can
	/// contain nested undo units.
	/// </para>
	/// <para>
	/// The undo manager provides a centralized undo and redo service. It manages parent undo units and simple undo units on the undo
	/// and redo stacks. Whether an object is UI-active or not, it can deposit undo units on these stacks by calling methods in the undo manager.
	/// </para>
	/// <para>
	/// The centralized undo manager then has the data necessary to support the undo and redo user interface for the host application
	/// and can discard undo information gradually as the stack becomes full.
	/// </para>
	/// <para>
	/// The undo manager is implemented as a service and objects obtain a pointer to <c>IOleUndoManger</c> from the IServiceProvider
	/// interface. It is usually implemented by the container. The service manages two stacks, the undo stack and the redo stack, each
	/// of which contains undo units generated by embedded objects or by the container application itself.
	/// </para>
	/// <para>
	/// Undo units are typically generated in response to actions taken by the end user. An object does not generate undo actions for
	/// programmatic events. In fact, programmatic events should clear the undo stack since the programmatic event can possibly
	/// invalidate assumptions made by the undo units on the stack.
	/// </para>
	/// <para>
	/// When the object's state changes, it creates an undo unit encapsulating all the information needed to undo that change. The
	/// object calls methods in the undo manager to place its undo units on the stack. Then, when the end user selects an Undo
	/// operation, the undo manager takes the top undo unit off the stack, invokes its action by calling its IOleUndoUnit::Do method,
	/// and then releases it. When an end user selects a Redo operation, the undo manager takes the top redo unit off the stack, invokes
	/// its action by calling its <c>IOleUndoUnit::Do</c> method, and then releases it.
	/// </para>
	/// <para>
	/// The undo manager has three states: the base state, the undo state, and the redo state. It begins in the base state. To perform
	/// an action from the undo stack, it puts itself into the undo state, calls IOleUndoUnit::Do on the undo unit, and goes back to the
	/// base state. To perform an action from the redo stack, it puts itself into the redo state, calls <c>IOleUndoUnit::Do</c> on the
	/// undo unit, and goes back to the base state.
	/// </para>
	/// <para>
	/// If the undo manager receives a new undo unit while in the base state, it places the unit on the undo stack and discards the
	/// entire redo stack. While it is in the undo state, it puts incoming units on the redo stack. While it is in the redo state, it
	/// places them on the undo stack without flushing the redo stack.
	/// </para>
	/// <para>The undo manager also allows objects to discard the undo or redo stack starting from any object in either stack.</para>
	/// <para>
	/// The host application determines the scope of an undo manager. For example, in one application, the scope might be at the
	/// document level; a separate undo manager is maintained for each document; and undo is managed independently for each document.
	/// However, another application maintain one undo manager, and therefore one undo scope, for the entire application.
	/// </para>
	/// <para>Error Handling</para>
	/// <para>
	/// Having an undo operation fail and leaving the document in an unstable state is something the undo manager, undo units, and the
	/// application itself all have to work together to avoid. As a result, there are certain requirements that undo units, the undo
	/// manager, and the application or component using undo must conform to.
	/// </para>
	/// <para>
	/// To perform an undo, the undo manager calls IOleUndoUnit::Do on one or more undo units which can, in turn, contain more units. If
	/// a unit somewhere in the hierarchy fails, the error will eventually reach the undo manager, which is responsible for making an
	/// attempt to roll back the state of the document to what it was before the call to the last top-level unit. The undo manager
	/// performs the rollback by calling <c>IOleUndoUnit::Do</c> on the unit that was added to the redo stack during the undo attempt.
	/// If the rollback also fails, then the undo manager is forced to abandon everything and return to the application. The undo
	/// manager indicates whether the rollback succeeded, and the application can take different actions based on this, such as
	/// reinitializing components so they're in a known state.
	/// </para>
	/// <para>
	/// All the steps in adding an undo unit to the stack should be performed atomically. That is, all steps must succeed or none of
	/// them should succeed.
	/// </para>
	/// <para>
	/// The host application that provides the undo manager decides what action to take when undo fails. At the very least, it should
	/// inform the user of the failure. The host application will be told by the undo manager whether the undo succeeded and whether the
	/// attempted rollback succeeded. In case both the undo and rollback failed, the host application can present the user with several
	/// options, including immediately shutting down the application.
	/// </para>
	/// <para>
	/// Simple undo units must not change the state of any object if they return failure. This includes the state of the redo stack or
	/// undo stack if performing a redo. They are also required to put a corresponding unit on the redo or undo stack if they succeed.
	/// The application should be stable before and after the unit is called.
	/// </para>
	/// <para>
	/// Parent undo units have the same requirements as simple units, with one exception. If one or more children succeeded prior to
	/// another child's failure, the parent unit must commit its corresponding unit on the redo stack and return the failure to its
	/// parent. If no children succeeded, the parent unit should commit its redo unit only if it has made a state change that needs to
	/// be rolled back. For example, suppose a parent unit contains three simple units. The first two succeed and added units to the
	/// redo stack, but the third one failed. At this point, the parent unit commits its redo unit and returns the failure.
	/// </para>
	/// <para>
	/// As a side effect, the parent unit should never make state changes that depend on the success of their children. Doing this will
	/// cause the rollback behavior to break. If a parent unit makes state changes, it should do them before calling any children. Then,
	/// if the state change fails, it should not commit its redo unit, it should not call any children, and it should return the failure
	/// to its parent.
	/// </para>
	/// <para>The undo manager has one primary requirement for error handling: to attempt rollback when an undo or redo fails.</para>
	/// <para>Non-compliant Objects</para>
	/// <para>
	/// Objects that do not support multi-level undo can cause serious problems for a global undo service. Since the object cannot be
	/// relied on to properly update the undo manager, any units submitted by other objects are also suspect, because their units may
	/// rely on the state of the non-compliant object. Attempting to undo a compliant object's units may not be successful, because the
	/// state in the non-compliant object will not match.
	/// </para>
	/// <para>
	/// To detect objects that do not support multi-level undo, check for the OLEMISC_SUPPORTSMULTILEVELUNDO value. An object that can
	/// participate in the global undo service sets this value.
	/// </para>
	/// <para>
	/// When an object without this value is added to a user-visible undo context, the best practice is to disable the undo user
	/// interface for this context. Alternatively, a dialog could be presented to the user, asking them whether to attempt to provide
	/// partial undo support, working around the non-compliance of the new object.
	/// </para>
	/// <para>
	/// In addition, non-compliant objects may be added to nested containers. In this case, the nested container needs to notify the
	/// undo manager that undo can no longer be safely supported by calling IOleUndoManager::Enable with <c>FALSE</c>.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nn-ocidl-ioleundomanager
	[PInvokeData("ocidl.h", MSDNShortId = "NN:ocidl.IOleUndoManager")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("D001F200-EF97-11CE-9BC9-00AA00608E01")]
	public interface IOleUndoManager
	{
		/// <summary>Opens a new parent undo unit, which becomes part of its containing unit's undo stack.</summary>
		/// <param name="pPUU">An IOleParentUndoUnit pointer to the parent undo unit to be opened.</param>
		/// <returns>
		/// This method returns S_OK if the parent undo unit was successfully opened or if a currently open unit is blocked. If the undo
		/// manager is currently disabled, it will return S_OK and do nothing else.
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method is implemented the same as IOleParentUndoUnit::Open. The specified parent unit is created and remains open. The
		/// undo manager then calls the IOleUndoManager::Add or <c>IOleUndoManager::Open</c> methods on this parent unit to add new
		/// units to it. This parent unit receives any additional undo units until its IOleUndoManager::Close method is called.
		/// </para>
		/// <para>
		/// The parent unit specified by pPUU is not added to the undo stack until its IOleUndoManager::Close method is called with the
		/// fCommit parameter set to <c>TRUE</c>.
		/// </para>
		/// <para>
		/// The parent undo unit or undo manager must contain any undo unit given to it unless it is blocked. If it is blocked, it must
		/// return S_OK but should do nothing else.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ioleundomanager-open HRESULT Open( IOleParentUndoUnit *pPUU );
		[PreserveSig]
		HRESULT Open(IOleParentUndoUnit pPUU);

		/// <summary>Closes the specified parent undo unit.</summary>
		/// <param name="pPUU">A pointer to an IOleParentUndoUnit interface for the currently open parent unit to be closed.</param>
		/// <param name="fCommit">
		/// Indicates whether to keep or discard the unit. If <c>TRUE</c>, the unit is kept in the collection. If <c>FALSE</c>, the unit
		/// is discarded. This parameter is used to allow the client to discard an undo unit under construction if an error or a
		/// cancellation occurs.
		/// </param>
		/// <returns>
		/// <para>
		/// This method returns S_OK if the undo manager had an open parent undo unit and it was successfully closed. If the undo
		/// manager is disabled, it should immediately return S_OK and do nothing else. Other possible return values include the following.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>The parent undo unit did not have an open child and it was successfully closed.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>
		/// If pPUU does not match the currently open parent undo unit, then implementations of this method should return E_INVALIDARG
		/// without changing any internal state unless the parent unit is blocked.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method is implemented the same as IOleParentUndoUnit::Close. A parent undo unit knows it is being closed when it
		/// returns S_FALSE from this method. At that time, it should terminate any communication with other objects which may be giving
		/// data to it through private interfaces.
		/// </para>
		/// <para>Notes to Callers</para>
		/// <para>An error return indicates a fatal error condition.</para>
		/// <para>The parent unit or undo manager must accept the undo unit if fCommit is <c>TRUE</c>.</para>
		/// <para>Note to Implementers</para>
		/// <para>
		/// To process a close request, a parent undo unit first checks to see if it has an open child unit. If it does not, it returns S_FALSE.
		/// </para>
		/// <para>
		/// If it does have a child unit open, it calls the <c>IOleUndoManager::Close</c> method on the child. If the child returns
		/// S_FALSE, then the parent undo unit verifies that pPUU points to the child unit, and closes that child undo unit. If the
		/// child returns S_OK then it handled the close internally and its parent should do nothing.
		/// </para>
		/// <para>
		/// If the parent unit is blocked, it should check the pPUU parameter to determine the appropriate return code. If pPUU is
		/// pointing to itself, then it should return S_FALSE.
		/// </para>
		/// <para>Otherwise, it should return S_OK; the fCommit parameter is ignored; and no action is taken.</para>
		/// <para>
		/// If pPUU does not match the currently open parent undo unit, then implementations of this method should return E_INVALIDARG
		/// without changing any internal state. The only exception to this is if the unit is blocked.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ioleundomanager-close HRESULT Close( IOleParentUndoUnit
		// *pPUU, BOOL fCommit );
		[PreserveSig]
		HRESULT Close(IOleParentUndoUnit pPUU, [MarshalAs(UnmanagedType.Bool)] bool fCommit);

		/// <summary>
		/// Adds a simple undo unit to the collection. While a parent undo unit is open, the undo manager adds undo units to it by
		/// calling IOleParentUndoUnit::Add.
		/// </summary>
		/// <param name="pUU">An IOleUndoUnit pointer to the undo unit to be added.</param>
		/// <returns>
		/// This method returns S_OK if the specified unit was successfully added, the parent unit was blocked, or the undo manager is disabled.
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method is implemented the same as IOleParentUndoUnit::Add. The parent undo unit or undo manager must accept any undo
		/// unit given to it, unless it is blocked. If it is blocked, it should do nothing but return S_OK.
		/// </para>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// If the undo manager is in the base state, it should put the new unit on the undo stack and discard the entire redo stack. If
		/// the undo manager is in the undo state, it should put new units on the redo stack. If the undo manager is in the redo state,
		/// it should put units on the undo stack without affecting the redo stack.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ioleundomanager-add HRESULT Add( IOleUndoUnit *pUU );
		[PreserveSig]
		HRESULT Add(IOleUndoUnit pUU);

		/// <summary>Retrieves state information about the innermost open parent undo unit.</summary>
		/// <param name="pdwState">
		/// A pointer to a variable that receives the state information. This information is a value taken from the UASFLAGS enumeration.
		/// </param>
		/// <returns>
		/// This method returns S_OK if there is an open parent unit and its state was successfully returned or the undo manager is
		/// disabled; otherwise, S_FALSE.
		/// </returns>
		/// <remarks>
		/// <para>Notes to Callers</para>
		/// <para>
		/// When checking for a normal state, use the UAS_MASK value to mask unused bits in the pdwState parameter to this method for
		/// future compatibility.
		/// </para>
		/// <para>Notes to Implementers</para>
		/// <para>If there is an open parent unit, this method calls IOleParentUndoUnit::GetParentState.</para>
		/// <para>If the undo manager is disabled, it should fill the pdwState parameter with UAS_BLOCKED and return S_OK.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ioleundomanager-getopenparentstate HRESULT
		// GetOpenParentState( DWORD *pdwState );
		[PreserveSig]
		HRESULT GetOpenParentState(out UASFLAGS pdwState);

		/// <summary>
		/// Instructs the undo manager to discard the specified undo unit and all undo units below it on the undo or redo stack.
		/// </summary>
		/// <param name="pUU">
		/// An IOleUndoUnit pointer to the undo unit to be discarded. This parameter can be <c>NULL</c> to discard the entire undo or
		/// redo stack. If the parameter is not <c>NULL</c> then the stack will not be discarded.
		/// </param>
		/// <returns>
		/// <para>This method returns S_OK on success. Other possible return values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The specified undo unit was not found in the stacks.</term>
		/// </item>
		/// <item>
		/// <term>E_UNEXPECTED</term>
		/// <term>The undo manager is disabled.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The undo manager first searches the undo stack for the given unit, and if not found there searches the redo stack. After it
		/// has been found, the given unit and all below it on the same stack are discarded. The undo unit may be a child of a parent
		/// unit contained by the undo manager, as determined by calling IOleParentUndoUnit::FindUnit. If it is a child unit, then the
		/// root unit containing the given unit and all units below it on the appropriate stack are discarded.
		/// </para>
		/// <para>
		/// If there is an open parent unit and the <c>DiscardFrom</c> method is called and the pUU parameter is <c>NULL</c>, the undo
		/// manager should immediately release and discard the open parent unit without calling the IOleUndoManager::Close first. When
		/// the object that opened the parent unit attempts to close it, <c>IOleUndoManager::Close</c> will return S_FALSE. If a parent
		/// unit is open, throw it away and discard the stack. If the parent unit is not open, just throw the stack away. If the pUU
		/// parameter is not <c>NULL</c>, then any open parent units should be left open.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ioleundomanager-discardfrom HRESULT DiscardFrom(
		// IOleUndoUnit *pUU );
		[PreserveSig]
		HRESULT DiscardFrom(IOleUndoUnit? pUU);

		/// <summary>
		/// Instructs the undo manager to invoke undo actions back through the undo stack, down to and including the specified undo unit.
		/// </summary>
		/// <param name="pUU">
		/// Pointer to the top level unit to undo. If this parameter is <c>NULL</c>, the most recently added top level unit is used.
		/// </param>
		/// <returns>
		/// <para>This method returns S_OK on success. Other possible return values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The specified undo unit is not on the undo stack.</term>
		/// </item>
		/// <item>
		/// <term>E_ABORT</term>
		/// <term>
		/// Both the undo attempt and the rollback attempt failed. The undo manager should never propagate the E_ABORT obtained from a
		/// contained undo unit. Instead, it should map any E_ABORT values returned from other undo units to E_FAIL. The undo manager
		/// should map any E_ABORT value returned from other undo units to E_FAIL because the caller of IOleUndoManager::UndoTo knows
		/// that the undo attempt and the rollback attempt failed and this is the only reason for the return value of E_ABORT.
		/// </term>
		/// </item>
		/// <item>
		/// <term>E_UNEXPECTED</term>
		/// <term>The undo manager is disabled.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>This method calls the IOleUndoUnit::Do method on each top-level undo unit. Then, it releases that undo unit.</para>
		/// <para>Note that the specified undo unit must be a top-level unit, typically retrieved through IOleUndoManager::EnumUndoable.</para>
		/// <para>
		/// In case an error is returned from the undo unit, the undo manager needs to attempt to rollback the state of the document to
		/// recover from the error by performing actions on the redo stack.
		/// </para>
		/// <para>
		/// No matter what the success of the rollback, the undo manager should always clear both stacks before returning the error.
		/// </para>
		/// <para>
		/// If the undo manager has called the Do method on more than one top-level unit, it should only rollback the unit that returned
		/// the error. The top-level units that succeeded should not be rolled back.
		/// </para>
		/// <para>
		/// The undo manager must also keep track of whether units were added to the opposite stack so it won't attempt rollback if
		/// nothing was added. See the IOleUndoManager interface for detailed description of error handling.
		/// </para>
		/// <para>Notes to Callers</para>
		/// <para>
		/// It is possible for an undo unit to return E_ABORT as a failure, but that has no specific meaning on IOleUndoUnit. Because
		/// the undo manager will typically return the error code given by the failed undo unit, and E_ABORT does have a specific
		/// meaning on <c>IOleUndoManager::UndoTo</c>, the undo manager should never pass on E_ABORT because the caller will interpret
		/// that as the rollback failing when in fact it may have succeeded.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ioleundomanager-undoto HRESULT UndoTo( IOleUndoUnit *pUU );
		[PreserveSig]
		HRESULT UndoTo(IOleUndoUnit? pUU);

		/// <summary>
		/// Instructs the undo manager to invoke undo actions back through the redo stack, down to and including the specified undo unit.
		/// </summary>
		/// <param name="pUU">
		/// An IOleUndoUnit pointer to the top level unit to redo. If this parameter is <c>NULL</c>, the most recently added top level
		/// unit is used.
		/// </param>
		/// <returns>
		/// <para>This method returns S_OK on success. Other possible return values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>The specified undo unit is not on the redo stack.</term>
		/// </item>
		/// <item>
		/// <term>E_ABORT</term>
		/// <term>
		/// Both the undo attempt and the rollback attempt failed. The undo manager should never propagate the E_ABORT obtained from a
		/// contained undo unit. Instead, it should map any E_ABORT values returned from other undo units to E_FAIL.
		/// </term>
		/// </item>
		/// <item>
		/// <term>E_UNEXPECTED</term>
		/// <term>The undo manager is disabled.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>This method calls the IOleUndoUnit::Do method on each top-level undo unit. Then, it releases that undo unit.</para>
		/// <para>Note that the specified undo unit must be a top-level unit, typically retrieved through IOleUndoManager::EnumRedoable.</para>
		/// <para>
		/// In case an error is returned from the undo unit, the undo manager needs to attempt to rollback the state of the document to
		/// recover from the error by performing actions on the undo stack.
		/// </para>
		/// <para>
		/// No matter what the success of the rollback, the undo manager should always clear both stacks before returning the error.
		/// </para>
		/// <para>
		/// If the undo manager has called the IOleUndoUnit::Do method on more than one top-level unit, it should only rollback the unit
		/// that returned the error. The top-level units that succeeded should not be rolled back.
		/// </para>
		/// <para>
		/// The undo manager must also keep track of whether units were added to the opposite stack so it won't attempt rollback if
		/// nothing was added. See the IOleUndoManager interface for detailed description of error handling.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ioleundomanager-redoto HRESULT RedoTo( IOleUndoUnit *pUU );
		[PreserveSig]
		HRESULT RedoTo(IOleUndoUnit? pUU);

		/// <summary>
		/// Creates an enumerator object that the caller can use to iterate through a series of top-level undo units from the undo stack.
		/// </summary>
		/// <param name="ppEnum">
		/// Address of IEnumOleUndoUnits pointer variable that receives the interface pointer to the enumerator object.
		/// </param>
		/// <returns>
		/// <para>This method returns S_OK on success. Other possible return values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_UNEXPECTED</term>
		/// <term>The undo manager is disabled.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A new enumerator object is created each time this method is called. If the series of enumerated items changes over time, the
		/// results of enumeration operations can vary from one call to the next.
		/// </para>
		/// <para>
		/// This method calls IUnknown::AddRef on the new enumerator object to increment its reference count. The caller is responsible
		/// for calling IUnknown::Release on the enumerator object when it is no longer needed.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ioleundomanager-enumundoable HRESULT EnumUndoable(
		// IEnumOleUndoUnits **ppEnum );
		[PreserveSig]
		HRESULT EnumUndoable(out IEnumOleUndoUnits ppEnum);

		/// <summary>
		/// Creates an enumerator object that the caller can use to iterate through a series of top-level undo units from the redo stack.
		/// </summary>
		/// <param name="ppEnum">
		/// Address of IEnumOleUndoUnits pointer variable that receives the interface pointer to the enumerator object.
		/// </param>
		/// <returns>
		/// <para>This method returns S_OK on success. Other possible return values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_UNEXPECTED</term>
		/// <term>The undo manager is disabled.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A new enumerator object is created each time this method is called. If the series of enumerated items changes over time, the
		/// results of enumeration operations can vary from one call to the next.
		/// </para>
		/// <para>
		/// This method calls IUnknown::AddRef on the new enumerator object to increment its reference count. The caller is responsible
		/// for calling IUnknown::Release on the enumerator object when it is no longer needed.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ioleundomanager-enumredoable HRESULT EnumRedoable(
		// IEnumOleUndoUnits **ppEnum );
		[PreserveSig]
		HRESULT EnumRedoable(out IEnumOleUndoUnits ppEnum);

		/// <summary>Retrieves the description for the top-level undo unit that is on top of the undo stack.</summary>
		/// <param name="pBstr">A pointer to a string that contains a description of the top-level undo unit on the undo stack.</param>
		/// <returns>
		/// <para>This method returns S_OK on success. Other possible return values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>The undo stack is empty.</term>
		/// </item>
		/// <item>
		/// <term>E_UNEXPECTED</term>
		/// <term>The undo manager is disabled.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// This method provides a convenient shortcut for the host application to add a description to its <c>Edit Undo</c> menu item.
		/// The pBstr parameter is a string allocated with the standard string allocator. The caller is responsible for freeing this string.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ioleundomanager-getlastundodescription HRESULT
		// GetLastUndoDescription( BSTR *pBstr );
		[PreserveSig]
		HRESULT GetLastUndoDescription([MarshalAs(UnmanagedType.BStr)] out string pBstr);

		/// <summary>Retrieves the description for the top-level undo unit that is on top of the redo stack.</summary>
		/// <param name="pBstr">A pointer to a string that contains a description of the top-level undo unit on the redo stack.</param>
		/// <returns>
		/// <para>This method returns S_OK on success. Other possible return values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>The undo stack is empty.</term>
		/// </item>
		/// <item>
		/// <term>E_UNEXPECTED</term>
		/// <term>The undo manager is disabled.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// This method provides a convenient shortcut for the host application to add a description to its <c>Edit Redo</c> menu item.
		/// The pBstr parameter is a string allocated with the standard string allocator. The caller is responsible for freeing this string.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ioleundomanager-getlastredodescription HRESULT
		// GetLastRedoDescription( BSTR *pBstr );
		[PreserveSig]
		HRESULT GetLastRedoDescription([MarshalAs(UnmanagedType.BStr)] out string pBstr);

		/// <summary>Enables or disables the undo manager.</summary>
		/// <param name="fEnable">
		/// Indicates whether to enable or disable the undo manager. If <c>TRUE</c>, the undo manager should be enabled. If
		/// <c>FALSE</c>, the undo manager should be disabled.
		/// </param>
		/// <returns>
		/// <para>
		/// This method returns S_OK if the undo manager was successfully enabled or disabled. Other possible return values include the following.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_UNEXPECTED</term>
		/// <term>There is an open undo unit on the stack or the undo manager is currently performing an undo or a redo.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The undo manager should clear both stacks when making the transition from enabled to disabled.</para>
		/// <para>If the undo manager is disabled, each method in IOleUndoManager must behave as specified. See each method for details.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ioleundomanager-enable HRESULT Enable( BOOL fEnable );
		[PreserveSig]
		HRESULT Enable([MarshalAs(UnmanagedType.Bool)] bool fEnable);
	}

	/// <summary>
	/// <para>
	/// Serves as the main interface on an undo unit. An undo unit encapsulates the information necessary to undo or redo a single action.
	/// </para>
	/// <para>
	/// When an object's state changes and it needs to create an undo unit, it first needs to know what parent units are open. It calls
	/// the IOleUndoManager::GetOpenParentState method to determine this. If the call returns S_FALSE, then there is no enabling parent.
	/// If the call returns S_OK but the UAS_NOPARENTENABLE flag is set, then the open parent is a disabling parent. In either of these
	/// cases, the object calls IOleUndoManager::DiscardFrom(NULL) on the undo manager and skips creating the undo unit.
	/// </para>
	/// <para>
	/// If the method returns S_OK, but the UAS_BLOCKED flag is set, then the open parent is a blocking parent. The object does not need
	/// to create an undo unit, since it would be immediately discarded. If the return value is S_OK and neither of the bit flags are
	/// set, then the object creates the undo unit and calls IOleUndoManager::Add on the undo manager.
	/// </para>
	/// <para>The object should retain a pointer to the undo manager.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nn-ocidl-ioleundounit
	[PInvokeData("ocidl.h", MSDNShortId = "NN:ocidl.IOleUndoUnit")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("894AD3B0-EF97-11CE-9BC9-00AA00608E01")]
	public interface IOleUndoUnit
	{
		/// <summary>
		/// Instructs the undo unit to carry out its action. Note that if it contains child undo units, it must call their Do methods as well.
		/// </summary>
		/// <param name="pUndoManager">A pointer to the undo manager. See IOleUndoManager.</param>
		/// <returns>This method returns S_OK on success.</returns>
		/// <remarks>
		/// <para>
		/// The undo unit is responsible for carrying out its action. Performing its own undo action results in another action that can
		/// potentially be reversed. However, if pUndoManager is <c>NULL</c>, the undo unit should perform its undo action but should
		/// not attempt to put anything on the redo or undo stack.
		/// </para>
		/// <para>
		/// If pUndoManager is not <c>NULL</c>, then the unit is required to put a corresponding unit on the redo or undo stack. As a
		/// result, this method either moves itself to the redo or undo stack, or it creates a new undo unit and adds it to the
		/// appropriate stack. After creating a new undo unit, this undo unit calls IOleUndoManager::Open or IOleUndoManager::Add. The
		/// undo manager will put the new undo unit on the undo or redo stack depending on its current state.
		/// </para>
		/// <para>
		/// A parent unit must pass to its children the same undo manager, possibly <c>NULL</c>, that was given to the parent. It is
		/// permissible, but not necessary, when pUndoManager is <c>NULL</c> to open a parent unit on the redo or undo stack as long as
		/// it is not committed. A blocked parent unit ensures that nothing is added to the stack by child units.
		/// </para>
		/// <para>
		/// If this undo unit is a parent unit, it should put itself on the redo or undo stack before calling the <c>Do</c> method on
		/// its children.
		/// </para>
		/// <para>After calling this method, the undo manager must release the undo unit.</para>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// See the IOleUndoManager interface for error handling strategies for undo units. The error handling strategy affects the
		/// implementation of this method, particularly for parent units.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ioleundounit-do HRESULT Do( IOleUndoManager *pUndoManager );
		[PreserveSig]
		HRESULT Do(IOleUndoManager? pUndoManager);

		/// <summary>Retrieves a description of the undo unit that can be used in the undo or redo user interface.</summary>
		/// <param name="pBstr">A pointer to string that describes this undo unit.</param>
		/// <returns>This method returns S_OK on success.</returns>
		/// <remarks>
		/// <para>All units are required to provide a user-readable description of themselves.</para>
		/// <para>Notes to Callers</para>
		/// <para>The pbstr parameter is allocated with the standard string allocator. The caller is responsible for freeing this string.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ioleundounit-getdescription HRESULT GetDescription( BSTR
		// *pBstr );
		[PreserveSig]
		HRESULT GetDescription([MarshalAs(UnmanagedType.BStr)] out string pBstr);

		/// <summary>Retrieves the CLSID and a type identifier for the undo unit.</summary>
		/// <param name="pClsid">A pointer to CLSID for the undo unit.</param>
		/// <param name="plID">A pointer to the type identifier for the undo unit.</param>
		/// <returns>This method returns S_OK on success.</returns>
		/// <remarks>
		/// <para>
		/// A parent undo unit can call this method on its child units to determine whether it can apply special handling to them. The
		/// CLSID returned can be the CLSID of the undo unit itself, of its creating object, or an arbitrary GUID. The undo unit has the
		/// option of returning CLSID_NULL, in which case the caller can make no assumptions about the type of this unit. The only
		/// requirement is that the CLSID and type identifier together uniquely identify this type of undo unit.
		/// </para>
		/// <para>
		/// Note that the undo manager and parent undo units do not have the option of accepting or rejecting child units based on their type.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ioleundounit-getunittype HRESULT GetUnitType( CLSID
		// *pClsid, LONG *plID );
		[PreserveSig]
		HRESULT GetUnitType(out Guid pClsid, out int plID);

		/// <summary>Notifies the last undo unit in the collection that a new unit has been added.</summary>
		/// <returns>Implementations of this method always return S_OK. The <c>HRESULT</c> return type is used only for remotability.</returns>
		/// <remarks>
		/// <para>
		/// An object can create an undo unit for an action and add it to the undo manager but can continue inserting data into it
		/// through private interfaces. When the undo unit receives a call to this method, it communicates back to the creating object
		/// that the context has changed. Then, the creating object stops inserting data into the undo unit.
		/// </para>
		/// <para>
		/// The parent undo unit calls this method on its most recently added child undo unit to notify the child unit that the context
		/// has changed and a new undo unit has been added.
		/// </para>
		/// <para>
		/// For example, this method is used for supporting fuzzy actions, like typing, which do not have a clear point of termination
		/// but instead are terminated only when something else happens.
		/// </para>
		/// <para>
		/// This method may not always be called if the undo manager or an open parent unit chooses to discard the unit by calling
		/// IUnknown::Release instead. Any connection which feeds data to the undo unit behind the scenes through private interfaces
		/// should not IUnknown::AddRef the undo unit.
		/// </para>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// Note that parent units merely delegate this method to their most recently added child unit. A parent unit should terminate
		/// communication through any private interfaces when it is closed. A parent unit knows it is being closed when it receives
		/// S_FALSE from calling IOleParentUndoUnit::Close.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ioleundounit-onnextadd HRESULT OnNextAdd();
		[PreserveSig]
		HRESULT OnNextAdd();
	}

	/// <summary>Retrieves the information in the property pages offered by an object.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nn-ocidl-iperpropertybrowsing
	[PInvokeData("ocidl.h", MSDNShortId = "NN:ocidl.IPerPropertyBrowsing")]
	[ComImport, Guid("376BD3AA-3845-101B-84ED-08002B2EC713"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IPerPropertyBrowsing
	{
		/// <summary>Retrieves a text string describing the specified property.</summary>
		/// <param name="dispID">The dispatch identifier of the property whose display name is requested.</param>
		/// <param name="pBstr">
		/// A pointer to a variable that receives the display name for the property identified in dispID. The string is allocated by
		/// this method using <c>SysAllocString</c>. Upon return, the string is the responsibility of the caller, which must free it
		/// with <c>SysFreeString</c> when it is no longer needed.
		/// </param>
		/// <returns>
		/// <para>
		/// This method can return the standard return values E_INVALIDARG, E_OUTOFMEMORY, and E_UNEXPECTED, as well as the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The display name was successfully returned.</term>
		/// </item>
		/// <item>
		/// <term>E_NOTIMPL</term>
		/// <term>
		/// The object does not provide display names for individual properties. The caller has the recourse to check the object's type
		/// information for the text name of the object in this case.
		/// </term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>The address in pbstr is not valid. For example, it may be NULL.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-iperpropertybrowsing-getdisplaystring HRESULT
		// GetDisplayString( DISPID dispID, BSTR *pBstr );
		[PreserveSig]
		HRESULT GetDisplayString(int dispID, [MarshalAs(UnmanagedType.BStr)] out string pBstr);

		/// <summary>Retrieves the CLSID of the property page associated with the specified property.</summary>
		/// <param name="dispID">The dispatch identifier of the property.</param>
		/// <param name="pClsid">
		/// A pointer to the CLSID identifying the property page associated with the property specified by dispID. If this method fails,
		/// *pClsid is set to CLSID_NULL.
		/// </param>
		/// <returns>
		/// <para>This method can return the standard return values E_INVALIDARG and E_UNEXPECTED, as well as the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method completed succesfully.</term>
		/// </item>
		/// <item>
		/// <term>E_NOTIMPL</term>
		/// <term>
		/// The object does not support property pages at all or does not support mapping properties to the page CLSID. In other words,
		/// this feature of specific property browsing is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>The address in pClsid is not valid. For example, it may be NULL.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// The CLSID returned from this method can be passed to OleCreatePropertyFrameIndirect to specify the initial page to display
		/// in the property sheet.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-iperpropertybrowsing-mappropertytopage HRESULT
		// MapPropertyToPage( DISPID dispID, CLSID *pClsid );
		[PreserveSig]
		HRESULT MapPropertyToPage(int dispID, out Guid pClsid);

		/// <summary>Retrieves an array description strings for the allowable values that the specified property can accept.</summary>
		/// <param name="dispID">The dispatch identifier of the property.</param>
		/// <param name="pCaStringsOut">
		/// A pointer to a caller-allocated, counted array structure that contains the element count and address of a method-allocated
		/// array of string pointers. This method also allocates memory for the string values containing the predefined names, and it
		/// stores the string pointers in the array. If the method fails, no memory is allocated, and the contents of the structure are undefined.
		/// </param>
		/// <param name="pCaCookiesOut">
		/// A pointer to the caller-allocated, counted array structure that contains the element count and address of a method-allocated
		/// array of <c>DWORD</c> values. The values in the array can be passed to IPerPropertyBrowsing::GetPredefinedValue to retrieve
		/// the value associated with the name in the same array position inside pCaStringsOut. If the method fails, no memory is
		/// allocated, and the contents of the structure are undefined.
		/// </param>
		/// <returns>
		/// <para>
		/// This method can return the standard return values E_INVALIDARG, E_OUTOFMEMORY, and E_UNEXPECTED, as well as the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method completed succesfully.</term>
		/// </item>
		/// <item>
		/// <term>E_NOTIMPL</term>
		/// <term>This method is not implemented and predefined names are not supported.</term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>The address in pCaStringsOut or pCaCookiesOut is not valid. For example, either parameter may be NULL.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Each string returned in the array pointed to by pCaStringsOut has a matching token in the counted array pointed to by
		/// pCaCookiesOut, where the token can be passed to IPerPropertyBrowsing::GetPredefinedValue to get the actual value (a
		/// <c>VARIANT</c>) corresponding to the string.
		/// </para>
		/// <para>
		/// Using the predefined strings, a caller can obtain a list of strings for populating user interface elements, such as a
		/// drop-down listbox. When the end user selects one of these strings as a value to assign to a property, the caller can then
		/// obtain the corresponding value through IPerPropertyBrowsing::GetPredefinedValue.
		/// </para>
		/// <para>Notes to Callers</para>
		/// <para>
		/// Both the CALPOLESTR and CADWORD structures passed to this method are caller-allocated. The caller is responsible for freeing
		/// each string pointed to from the <c>CALPOLESTR</c> array as well as the <c>CALPOLESTR</c> structure.
		/// </para>
		/// <para>
		/// All memory is allocated with CoTaskMemAlloc. The caller is responsible for freeing the strings and the array with CoTaskMemFree.
		/// </para>
		/// <para>
		/// Upon return from this method, the caller is responsible for all this memory and must free it when it is no longer needed.
		/// Code to achieve this appears as follows.
		/// </para>
		/// <para>
		/// <code>CALPOLESTR castr; CWDWORD cadw; ULONG i; pIPerPropertyBrowsing-&gt;GetPredefinedStrings(dispID, &amp;castr, &amp;cadw); //...Use the strings and the cookies CoTaskMemFree((void *)cadw.pElems); for (i=0; i &lt; castr.cElems; i++) CoTaskMemFree((void *)castr.pElems[i]); CoTaskMemFree((void *)castr.pElems);</code>
		/// </para>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// Support for predefined names and values is not required. If your object does not support these names, return E_NOTIMPL from
		/// this method. If this method is not implemented, IPerPropertyBrowsing::GetPredefinedValue must not be implemented either.
		/// </para>
		/// <para>
		/// This method fills the <c>cElems</c> and <c>pElems</c> members of the CADWORD and CALPOLESTR structures. It allocates the
		/// arrays pointed to by these structures with CoTaskMemAlloc and fills those arrays. In the <c>CALPOLESTR</c> case, this method
		/// also allocates each string with <c>CoTaskMemAlloc</c>, storing each string pointer in the array.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-iperpropertybrowsing-getpredefinedstrings HRESULT
		// GetPredefinedStrings( DISPID dispID, CALPOLESTR *pCaStringsOut, CADWORD *pCaCookiesOut );
		[PreserveSig]
		HRESULT GetPredefinedStrings(int dispID, out CALPOLESTR pCaStringsOut, out CADWORD pCaCookiesOut);

		/// <summary>
		/// Retrieves the value of the specified property that is associated with a predefined string name. This property is associated
		/// with a predefined string name as returned from IPerPropertyBrowsing::GetPredefinedStrings. The predefined string is
		/// identified by a token returned from <c>GetPredefinedStrings</c>.
		/// </summary>
		/// <param name="dispID">The dispatch identifier of the property for which a predefined value is requested.</param>
		/// <param name="dwCookie">
		/// A token identifying which value to return. The token was previously returned in the pCaCookiesOut array filled by GetPredefinedStrings.
		/// </param>
		/// <param name="pVarOut">A pointer to the <c>VARIANT</c> value for the property.</param>
		/// <returns>
		/// <para>
		/// This method can return the standard return values E_INVALIDARG, E_OUTOFMEMORY, and E_UNEXPECTED, as well as the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method completed succesfully.</term>
		/// </item>
		/// <item>
		/// <term>E_NOTIMPL</term>
		/// <term>This object does not support predefined strings or predefined values.</term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>The address in pVarOut is not valid. For example, it may be NULL.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Notes to Callers</para>
		/// <para>
		/// The caller is responsible for freeing any allocations contained in the <c>VARIANT</c>. Unless the <c>vt</c> member of
		/// <c>VARIANT</c> is VT_VARIANT, the caller can free memory using a single call to <c>VariantClear</c>. Otherwise, the caller
		/// must recursively free the contained <c>VARIANT</c> values before freeing the outer <c>VARIANT</c>.
		/// </para>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// Support for predefined names and values is not required. If your object does not support these names, return E_NOTIMPL from
		/// this method. If this method is not implemented, IPerPropertyBrowsing::GetPredefinedStrings must not be implemented either.
		/// </para>
		/// <para>This method allocates any memory needed inside the <c>VARIANT</c>.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-iperpropertybrowsing-getpredefinedvalue HRESULT
		// GetPredefinedValue( DISPID dispID, DWORD dwCookie, VARIANT *pVarOut );
		[PreserveSig]
		HRESULT GetPredefinedValue(int dispID, uint dwCookie, out object pVarOut);
	}

	/// <summary>Works with IPropertyBag and IErrorlog to define an individual property-based persistence mechanism.</summary>
	/// <remarks>
	/// <c>IPersistPropertyBag</c> provides an object with an IPropertyBag interface through which it can save and load individual
	/// properties. The object that implements <c>IPropertyBag</c> can then save those properties in various ways, such as name/value
	/// pairs in a text file. Errors encountered in the process (on either side) are recorded in an error log through IErrorlog. This
	/// error reporting mechanism works on a per-property basis instead of on all properties at once.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nn-ocidl-ipersistpropertybag
	[PInvokeData("ocidl.h", MSDNShortId = "NN:ocidl.IPersistPropertyBag")]
	[ComImport, Guid("37D84F60-42CB-11CE-8135-00AA004BB851"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IPersistPropertyBag : IPersist
	{
		/// <summary>Retrieves the class identifier (CLSID) of the object.</summary>
		/// <returns>
		/// <para>
		/// A pointer to the location that receives the CLSID on return. The CLSID is a globally unique identifier (GUID) that uniquely
		/// represents an object class that defines the code that can manipulate the object's data.
		/// </para>
		/// <para>If the method succeeds, the return value is S_OK. Otherwise, it is E_FAIL.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>GetClassID</c> method retrieves the class identifier (CLSID) for an object, used in later operations to load
		/// object-specific code into the caller's context.
		/// </para>
		/// <para>Notes to Callers</para>
		/// <para>
		/// A container application might call this method to retrieve the original CLSID of an object that it is treating as a
		/// different class. Such a call would be necessary if a user performed an editing operation that required the object to be
		/// saved. If the container were to save it using the treat-as CLSID, the original application would no longer be able to edit
		/// the object. Typically, in this case, the container calls the OleSave helper function, which performs all the necessary
		/// steps. For this reason, most container applications have no need to call this method directly.
		/// </para>
		/// <para>
		/// The exception would be a container that provides an object handler for certain objects. In particular, a container
		/// application should not get an object's CLSID and then use it to retrieve class specific information from the registry.
		/// Instead, the container should use IOleObject and IDataObject interfaces to retrieve such class-specific information directly
		/// from the object.
		/// </para>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// Typically, implementations of this method simply supply a constant CLSID for an object. If, however, the object's
		/// <c>TreatAs</c> registry key has been set by an application that supports emulation (and so is treating the object as one of
		/// a different class), a call to <c>GetClassID</c> must supply the CLSID specified in the <c>TreatAs</c> key. For more
		/// information on emulation, see CoTreatAsClass.
		/// </para>
		/// <para>
		/// When an object is in the running state, the default handler calls an implementation of <c>GetClassID</c> that delegates the
		/// call to the implementation in the object. When the object is not running, the default handler instead calls the ReadClassStg
		/// function to read the CLSID that is saved in the object's storage.
		/// </para>
		/// <para>
		/// If you are writing a custom object handler for your object, you might want to simply delegate this method to the default
		/// handler implementation (see OleCreateDefaultHandler).
		/// </para>
		/// <para>URL Moniker Notes</para>
		/// <para>This method returns CLSID_StdURLMoniker.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-ipersist-getclassid HRESULT GetClassID( CLSID *pClassID );
		new Guid GetClassID();

		/// <summary>Informs the object that it is being initialized as a newly created object.</summary>
		/// <remarks>E_NOTIMPL should not be returned. Return S_OK, even if the object does not perform any function in this method.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ipersistpropertybag-initnew HRESULT InitNew();
		void InitNew();

		/// <summary>
		/// Instructs the object to initialize itself using the properties available in the property bag, and to notify the provided
		/// error log object when errors occur.
		/// </summary>
		/// <param name="pPropBag">
		/// The address of the caller's property bag, through which the object can read properties. This cannot be NULL.
		/// </param>
		/// <param name="pErrorLog">
		/// The address of the caller's error log, in which the object stores any errors that occur during initialization. This can be
		/// NULL; in which case, the caller does not receive errors.
		/// </param>
		/// <remarks>
		/// <para>
		/// All property loading must take place in the <c>IPersistPropertyBag::Load</c> function call, because the object cannot hold
		/// the IPropertyBag pointer.
		/// </para>
		/// <para>
		/// E_NOTIMPL is not a valid return code, because any object that implements this interface must support the entire
		/// functionality of the interface.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ipersistpropertybag-load HRESULT Load( IPropertyBag
		// *pPropBag, IErrorLog *pErrorLog );
		void Load(OleAut32.IPropertyBag pPropBag, [Optional] OleAut32.IErrorLog? pErrorLog);

		/// <summary>
		/// Instructs the object to save its properties to the given property bag, and optionally, to clear the object's dirty flag.
		/// </summary>
		/// <param name="pPropBag">
		/// The address of the caller's property bag, through which the object can write properties. This cannot be NULL.
		/// </param>
		/// <param name="fClearDirty">
		/// A flag indicating whether the object should clear its dirty flag when the "Save" operation is complete. TRUE means clear the
		/// flag, and FALSE means leave the flag unaffected. FALSE is used when the caller performs a "Save Copy As" operation.
		/// </param>
		/// <param name="fSaveAllProperties">
		/// A flag indicating whether the object should save all its properties (TRUE), or save only those properties that have changed
		/// from the default value (FALSE).
		/// </param>
		/// <remarks>
		/// <para>The caller can request that the object save all properties, or save only those properties that have changed.</para>
		/// <para>
		/// E_NOTIMPL is not a valid return code, because any object that implements this interface must support the entire
		/// functionality of the interface.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ipersistpropertybag-save HRESULT Save( IPropertyBag
		// *pPropBag, BOOL fClearDirty, BOOL fSaveAllProperties );
		void Save(OleAut32.IPropertyBag pPropBag, [MarshalAs(UnmanagedType.Bool)] bool fClearDirty, [MarshalAs(UnmanagedType.Bool)] bool fSaveAllProperties);
	}

	/// <summary>
	/// <para>A replacement for IPersistStream that adds an initialization method.</para>
	/// <para>
	/// This interface is not derived from IPersistStream; it is mutually exclusive with <c>IPersistStream</c>. An object chooses to
	/// support only one of the two interfaces, based on whether it requires the InitNew method.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ocidl/nn-ocidl-ipersiststreaminit
	[PInvokeData("ocidl.h", MSDNShortId = "49c413b3-3523-4602-9ec1-19f4e0fe5651")]
	[ComImport, Guid("7FD52380-4E07-101B-AE2D-08002B2EC713"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IPersistStreamInit : IPersist
	{
		/// <summary>Retrieves the class identifier (CLSID) of the object.</summary>
		/// <returns>
		/// <para>
		/// A pointer to the location that receives the CLSID on return. The CLSID is a globally unique identifier (GUID) that uniquely
		/// represents an object class that defines the code that can manipulate the object's data.
		/// </para>
		/// <para>If the method succeeds, the return value is S_OK. Otherwise, it is E_FAIL.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>GetClassID</c> method retrieves the class identifier (CLSID) for an object, used in later operations to load
		/// object-specific code into the caller's context.
		/// </para>
		/// <para>Notes to Callers</para>
		/// <para>
		/// A container application might call this method to retrieve the original CLSID of an object that it is treating as a
		/// different class. Such a call would be necessary if a user performed an editing operation that required the object to be
		/// saved. If the container were to save it using the treat-as CLSID, the original application would no longer be able to edit
		/// the object. Typically, in this case, the container calls the OleSave helper function, which performs all the necessary
		/// steps. For this reason, most container applications have no need to call this method directly.
		/// </para>
		/// <para>
		/// The exception would be a container that provides an object handler for certain objects. In particular, a container
		/// application should not get an object's CLSID and then use it to retrieve class specific information from the registry.
		/// Instead, the container should use IOleObject and IDataObject interfaces to retrieve such class-specific information directly
		/// from the object.
		/// </para>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// Typically, implementations of this method simply supply a constant CLSID for an object. If, however, the object's
		/// <c>TreatAs</c> registry key has been set by an application that supports emulation (and so is treating the object as one of
		/// a different class), a call to <c>GetClassID</c> must supply the CLSID specified in the <c>TreatAs</c> key. For more
		/// information on emulation, see CoTreatAsClass.
		/// </para>
		/// <para>
		/// When an object is in the running state, the default handler calls an implementation of <c>GetClassID</c> that delegates the
		/// call to the implementation in the object. When the object is not running, the default handler instead calls the ReadClassStg
		/// function to read the CLSID that is saved in the object's storage.
		/// </para>
		/// <para>
		/// If you are writing a custom object handler for your object, you might want to simply delegate this method to the default
		/// handler implementation (see OleCreateDefaultHandler).
		/// </para>
		/// <para>URL Moniker Notes</para>
		/// <para>This method returns CLSID_StdURLMoniker.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-ipersist-getclassid HRESULT GetClassID( CLSID *pClassID );
		new Guid GetClassID();

		/// <summary>
		/// <para>Determines whether an object has changed since it was last saved to its stream.</para>
		/// </summary>
		/// <returns>
		/// <para>This method returns S_OK to indicate that the object has changed. Otherwise, it returns S_FALSE.</para>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Use this method to determine whether an object should be saved before closing it. The dirty flag for an object is
		/// conditionally cleared in the IPersistStreamInit::Save method.
		/// </para>
		/// <para>Notes to Callers</para>
		/// <para>
		/// You should treat any error return codes as an indication that the object has changed. Unless this method explicitly returns
		/// S_FALSE, assume that the object must be saved.
		/// </para>
		/// <para>
		/// Note that the OLE-provided implementations of the <c>IPersistStreamInit::IsDirty</c> method in the OLE-provided moniker
		/// interfaces always return S_FALSE because their internal state never changes.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ocidl/nf-ocidl-ipersiststreaminit-isdirty HRESULT IsDirty( );
		[PreserveSig]
		HRESULT IsDirty();

		/// <summary>Initializes an object from the stream where it was saved previously.</summary>
		/// <param name="pstm">The PSTM.</param>
		/// <remarks>
		/// <para>
		/// This method loads an object from its associated stream. The seek pointer is set as it was in the most recent
		/// IPersistStreamInit::Save method. This method can seek and read from the stream, but cannot write to it.
		/// </para>
		/// <para>Notes to Callers</para>
		/// <para>
		/// Rather than calling <c>IPersistStreamInit::Load</c> directly, you typically call the OleLoadFromStream function does the following:
		/// </para>
		/// <list type="number">
		/// <item>
		/// <term>Calls the ReadClassStm function to get the class identifier from the stream.</term>
		/// </item>
		/// <item>
		/// <term>Calls the CoCreateInstance function to create an instance of the object.</term>
		/// </item>
		/// <item>
		/// <term>Queries the instance for IPersistStreamInit.</term>
		/// </item>
		/// <item>
		/// <term>Calls <c>IPersistStreamInit::Load</c>.</term>
		/// </item>
		/// </list>
		/// <para>
		/// The OleLoadFromStream function assumes that objects are stored in the stream with a class identifier followed by the object
		/// data. This storage pattern is used by the generic, composite-moniker implementation provided by OLE.
		/// </para>
		/// <para>If the objects are not stored using this pattern, you must call the methods separately yourself.</para>
		/// <para>URL Moniker Notes</para>
		/// <para>
		/// Initializes an URL moniker from data within a stream, usually stored there previously using its IPersistStreamInit::Save
		/// (using OleSaveToStream). The binary format of the URL moniker is its URL string in Unicode (may be a full or partial URL
		/// string, see CreateURLMonikerEx for details). This is represented as a <c>ULONG</c> count of characters followed by that many
		/// Unicode characters.
		/// </para>
		/// </remarks>
		// HRESULT Load( LPSTREAM pStm ); https://msdn.microsoft.com/en-us/library/ms864774.aspx
		[PreserveSig]
		HRESULT Load([In, MarshalAs(UnmanagedType.Interface)] IStream pstm);

		/// <summary>Saves an object to the specified stream.</summary>
		/// <param name="pstm">The PSTM.</param>
		/// <param name="fClearDirty">
		/// Indicates whether to clear the dirty flag after the save is complete. If <c>TRUE</c>, the flag should be cleared. If
		/// <c>FALSE</c>, the flag should be left unchanged.
		/// </param>
		/// <remarks>
		/// <para>
		/// <c>IPersistStreamInit::Save</c> saves an object into the specified stream and indicates whether the object should reset its
		/// dirty flag.
		/// </para>
		/// <para>
		/// The seek pointer is positioned at the location in the stream at which the object should begin writing its data. The object
		/// calls the ISequentialStream::Write method to write its data.
		/// </para>
		/// <para>
		/// On exit, the seek pointer must be positioned immediately past the object data. The position of the seek pointer is undefined
		/// if an error returns.
		/// </para>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// The <c>IPersistStreamInit::Save</c> method does not write the CLSID to the stream. The caller is responsible for writing the CLSID.
		/// </para>
		/// <para>
		/// The <c>IPersistStreamInit::Save</c> method can read from, write to, and seek in the stream; but it must not seek to a
		/// location in the stream before that of the seek pointer on entry.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ocidl/nf-ocidl-ipersiststreaminit-save HRESULT Save( LPSTREAM pStm, BOOL
		// fClearDirty );
		[PreserveSig]
		HRESULT Save([In, MarshalAs(UnmanagedType.Interface)] IStream pstm, [In, MarshalAs(UnmanagedType.Bool)] bool fClearDirty);

		/// <summary>Retrieves the size of the stream needed to save the object.</summary>
		/// <param name="pCbSize">The size in bytes of the stream needed to save this object, in bytes.</param>
		/// <returns>This method returns S_OK to indicate that the size was retrieved successfully.</returns>
		/// <remarks>
		/// <para>
		/// This method returns the size needed to save an object. You can call this method to determine the size and set the necessary
		/// buffers before calling the IPersistStreamInit::Save method.
		/// </para>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// The <c>GetSizeMax</c> implementation should return a conservative estimate of the necessary size because the caller might
		/// call the IPersistStreamInit::Save method with a non-growable stream.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ipersiststreaminit-getsizemax HRESULT GetSizeMax(
		// ULARGE_INTEGER *pCbSize );
		[PreserveSig]
		HRESULT GetSizeMax(out ulong pCbSize);

		/// <summary>Initializes an object to a default state. This method is to be called instead of IPersistStreamInit::Load.</summary>
		/// <remarks>If the object has already been initialized with IPersistStreamInit::Load, then this method must return E_UNEXPECTED.</remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/ocidl/nf-ocidl-ipersiststreaminit-initnew HRESULT InitNew( );
		[PreserveSig]
		HRESULT InitNew();
	}

	/// <summary>
	/// <para>
	/// Manages a picture object and its properties. Picture objects provide a language-neutral abstraction for bitmaps, icons, and
	/// metafiles. As with the standard font object, the system provides a standard implementation of the picture object. Its primary
	/// interfaces are <c>IPicture</c> and IPictureDisp, the latter being derived from <c>IDispatch</c> to provide access to the
	/// picture's properties through Automation. A picture object is created with OleCreatePictureIndirect.
	/// </para>
	/// <para>
	/// The picture object also supports the outgoing interface IPropertyNotifySink, so a client can determine when picture properties
	/// change. Because the picture object supports at least one outgoing interface, it also implements IConnectionPointContainer and
	/// its associated interfaces for this purpose.
	/// </para>
	/// <para>
	/// The picture object also supports IPersistStream so that it can save and load itself from an instance of IStream. An object that
	/// uses a picture object internally would normally save and load the picture as part of the object's own persistence handling. The
	/// function OleLoadPicture simplifies the creation of a picture object based on stream contents.
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// Each property in the <c>IPicture</c> interface includes a <c>get_PropertyName</c> method if the property supports read access
	/// and a <c>put_PropertyName</c> method if the property supports write access.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Property</term>
	/// <term>Type</term>
	/// <term>Access</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>Handle</term>
	/// <term>OLE_HANDLE (int)</term>
	/// <term>R</term>
	/// <term>The Windows GDI handle of the picture</term>
	/// </item>
	/// <item>
	/// <term>hPal</term>
	/// <term>OLE_HANDLE (int)</term>
	/// <term>RW</term>
	/// <term>The Windows handle of the palette used by the picture.</term>
	/// </item>
	/// <item>
	/// <term>Type</term>
	/// <term>short</term>
	/// <term>R</term>
	/// <term>The type of picture (see PICTYPE).</term>
	/// </item>
	/// <item>
	/// <term>Width</term>
	/// <term>OLE_XSIZE_HIMETRIC (long)</term>
	/// <term>R</term>
	/// <term>The width of the picture.</term>
	/// </item>
	/// <item>
	/// <term>Height</term>
	/// <term>OLE_YSIZE_HIMETRIC (long)</term>
	/// <term>R</term>
	/// <term>The height of the picture.</term>
	/// </item>
	/// <item>
	/// <term>CurDC</term>
	/// <term>HDC</term>
	/// <term>R</term>
	/// <term>The current device context.</term>
	/// </item>
	/// <item>
	/// <term>KeepOriginalFormat</term>
	/// <term>BOOL</term>
	/// <term>RW</term>
	/// <term>
	/// If TRUE, the picture object maintains the entire original state of the picture in memory. If FALSE, any state not applicable to
	/// the user's computer is discarded.
	/// </term>
	/// </item>
	/// <item>
	/// <term>Attributes</term>
	/// <term>DWORD</term>
	/// <term>R</term>
	/// <term>Miscellaneous bit attributes of the picture.</term>
	/// </item>
	/// </list>
	/// <para>OLE Implementation</para>
	/// <para>
	/// Picture objects provide a language-neutral abstraction for bitmaps, icons, and metafiles. As with the standard font object, the
	/// system provides a standard implementation of the picture object. Its primary interfaces are <c>IPicture</c> and IPictureDisp. A
	/// picture object is created with OleCreatePictureIndirect and supports both the <c>IPicture</c> and the <c>IPictureDisp</c> interfaces.
	/// </para>
	/// <para>The OLE-provided picture object implements the complete semantics of the <c>IPicture</c> and IPictureDisp interfaces.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nn-ocidl-ipicture
	[PInvokeData("ocidl.h", MSDNShortId = "NN:ocidl.IPicture")]
	[ComImport, Guid("7BF80980-BF32-101A-8BBB-00AA00300CAB"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IPicture
	{
		/// <summary>Retrieves the handle to the picture managed within this picture object to a specified location.</summary>
		/// <param name="pHandle">
		/// A pointer to a variable that receives the handle. The caller is responsible for this handle upon successful return. The
		/// variable is set to <c>NULL</c> on failure.
		/// </param>
		/// <returns>
		/// <para>This method supports the standard return values E_FAIL and E_OUTOFMEMORY, as well as the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The handle was returned successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>The value of phandle is not valid. For example, it may be NULL.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Notes to Callers</para>
		/// <para>
		/// The picture object may retain ownership of the picture. However, the caller can be assured that the picture will remain
		/// valid until either the caller specifically destroys the picture or the picture object is itself destroyed. The fOwn
		/// parameter to OleCreatePictureIndirect determines ownership when the picture object is created. OleLoadPicture forces fOwn to <c>TRUE</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ipicture-get_handle HRESULT get_Handle( OLE_HANDLE *pHandle );
		[PreserveSig]
		HRESULT get_Handle(out uint pHandle);

		/// <summary>Retrieves a copy of the palette currently used by the picture object.</summary>
		/// <param name="phPal">A pointer to a variable that receives the palette handle. The variable is set to <c>NULL</c> on failure.</param>
		/// <returns>
		/// <para>This method supports the standard return values E_FAIL and E_OUTOFMEMORY, as well as the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The height was returned successfully.</term>
		/// </item>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>This picture has no palette. The variable that phpal points to was set to NULL.</term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>The value of phPal is not valid. For example, it may be NULL.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Notes to Callers</para>
		/// <para>
		/// If the picture object has ownership of the picture, it also has ownership of the palette and will destroy it when the object
		/// is itself destroyed. Otherwise the caller owns the palette. The fOwn parameter to OleCreatePictureIndirect determines
		/// ownership. OleLoadPicture sets fOwn to <c>TRUE</c> to indicate that the picture object owns the palette.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ipicture-get_hpal HRESULT get_hPal( OLE_HANDLE *phPal );
		[PreserveSig]
		HRESULT get_hPal(out uint phPal);

		/// <summary>Retrieves the current type of the picture contained in the picture object.</summary>
		/// <param name="pType">
		/// Pointer to a variable that receives the picture type. The Type property can have any one of the values contained in the
		/// PICTYPE enumeration.
		/// </param>
		/// <returns>
		/// <para>This method supports the standard return value E_FAIL, as well as the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The type was returned successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>The value of pType is not valid. For example, it may be NULL.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ipicture-get_type HRESULT get_Type( SHORT *pType );
		[PreserveSig]
		HRESULT get_Type(out PICTYPE pType);

		/// <summary>Retrieves the current width of the picture in the picture object.</summary>
		/// <param name="pWidth">A pointer to a variable that receives the width.</param>
		/// <returns>
		/// <para>This method supports the standard return value E_FAIL, as well as the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The width was returned successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>The value of pWidth is not valid. For example, it may be NULL.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ipicture-get_width HRESULT get_Width( OLE_XSIZE_HIMETRIC
		// *pWidth );
		[PreserveSig]
		HRESULT get_Width(out int pWidth);

		/// <summary>Retrieves the current height of the picture in the picture object.</summary>
		/// <param name="pHeight">A pointer to a variable that receives the height.</param>
		/// <returns>
		/// <para>This method supports the standard return value E_FAIL, as well as the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The height was returned successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>The value of pHeight is not valid. For example, it may be NULL.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ipicture-get_height HRESULT get_Height( OLE_YSIZE_HIMETRIC
		// *pHeight );
		[PreserveSig]
		HRESULT get_Height(out int pHeight);

		/// <summary>
		/// Renders (draws) a specified portion of the picture defined by the offset (xSrc,ySrc) of the source picture and the
		/// dimensions to copy (cxSrc,xySrc). This picture is rendered onto the specified device context, positioned at the point (x,y),
		/// and scaled to the dimensions (cx,cy). The prcWBounds parameter specifies the position of this rendering if the destination
		/// device context is itself a metafile. Such information is necessary to place one metafile in another. For more information,
		/// see the prcWBounds parameter of IViewObject2::Draw.
		/// </summary>
		/// <param name="hDC">A handle of the device context on which to render the image.</param>
		/// <param name="x">The horizontal coordinate in hdc at which to place the rendered image.</param>
		/// <param name="y">The vertical coordinate in hdc at which to place the rendered image.</param>
		/// <param name="cx">The horizontal dimension (width) of the destination rectangle.</param>
		/// <param name="cy">The vertical dimension (height) of the destination rectangle</param>
		/// <param name="xSrc">The horizontal offset in the source picture from which to start copying.</param>
		/// <param name="ySrc">The vertical offset in the source picture from which to start copying.</param>
		/// <param name="cxSrc">The horizontal extent to copy from the source picture.</param>
		/// <param name="cySrc">The vertical extent to copy from the source picture.</param>
		/// <param name="pRcWBounds">
		/// A pointer to a rectangle containing the position of the destination within a metafile device context if hdc is a metafile
		/// DC. Cannot be <c>NULL</c> in such cases.
		/// </param>
		/// <returns>
		/// <para>This method supports the standard return values E_FAIL, E_INVALIDARG, and E_OUTOFMEMORY, as well as the following:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The picture was rendered successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>The address in prcWBounds is not valid when hdc contains a metafile device context.</term>
		/// </item>
		/// <item>
		/// <term>CTL_E_INVALIDPROPERTYVALUE</term>
		/// <term>The parameter cx, cy, cxSrc, or cySrc has a value of zero.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ipicture-render HRESULT Render( HDC hDC, LONG x, LONG y,
		// LONG cx, LONG cy, OLE_XPOS_HIMETRIC xSrc, OLE_YPOS_HIMETRIC ySrc, OLE_XSIZE_HIMETRIC cxSrc, OLE_YSIZE_HIMETRIC cySrc, LPCRECT
		// pRcWBounds );
		[PreserveSig]
		HRESULT Render(HDC hDC, int x, int y, int cx, int cy, int xSrc, int ySrc, int cxSrc, int cySrc, [In, Optional] PRECT? pRcWBounds);

		/// <summary>Assigns a GDI palette to the picture contained in the picture object.</summary>
		/// <param name="hPal">A handle to the GDI palette assigned to the picture.</param>
		/// <returns>This method supports the standard return values E_FAIL, E_INVALIDARG, E_OUTOFMEMORY, and S_OK.</returns>
		/// <remarks>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// Ownership of the palette passed to this method depends on how the picture object was created, as specified by the fOwn
		/// parameter to OleCreatePictureIndirect. OleLoadPicture forces fOwn to <c>TRUE</c>; if the object owns the picture, then it
		/// takes over ownership of this palette.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ipicture-set_hpal HRESULT set_hPal( OLE_HANDLE hPal );
		[PreserveSig]
		HRESULT set_hPal(uint hPal);

		/// <summary>Retrieves the handle of the current device context. This property is valid only for bitmap pictures.</summary>
		/// <param name="phDC">A pointer a variable that receives the device context.</param>
		/// <returns>
		/// <para>This method supports the standard return value E_FAIL, as well as the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The attribute bits were returned successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>The value of phDC is not valid. For example, it may be NULL.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The CurDC property and the IPicture::SelectPicture method exist to circumvent restrictions in Windows; specifically, that an
		/// object can only be selected into exactly one device context at a time. In some cases, a picture object may be permanently
		/// selected into a particular device context (for example, a control may use a certain picture for a background). To use this
		/// picture property elsewhere, it must be temporarily deselected from its old device context, selected into the new device
		/// context for the operation, then reselected back into the old device context. The <c>IPicture::get_CurDC</c> method returns
		/// the device context handle into which the picture is currently selected. The <c>IPicture::SelectPicture</c> method selects
		/// the picture into a new device context, returning the old device context and the picture's GDI handle. The caller should
		/// select the picture back into the old device context when the caller is done with it, as is normal for Windows code.
		/// </para>
		/// <para>Notes to Callers</para>
		/// <para>
		/// The caller always owns any device contexts passed between it and the picture object. Because the picture object maintains a
		/// copy of the HDC, the caller should use a memory device context (created with the CreateCompatibleDC function) and not a
		/// screen device context (from GetDC, CreateDC, or BeginPaint), because the screen device contexts are a limited system resource.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ipicture-get_curdc HRESULT get_CurDC( HDC *phDC );
		[PreserveSig]
		HRESULT get_CurDC(out HDC phDC);

		/// <summary>
		/// Selects a bitmap picture into a given device context, and returns the device context in which the picture was previously
		/// selected as well as the picture's GDI handle. This method works in conjunction with IPicture::get_CurDC.
		/// </summary>
		/// <param name="hDCIn">A handle for the device context in which to select the picture.</param>
		/// <param name="phDCOut">
		/// A pointer to a variable that receives the previous device context. This parameter can be <c>NULL</c> if the caller does not
		/// need this information. Ownership of the device context is always the responsibility of the caller.
		/// </param>
		/// <param name="phBmpOut">
		/// A pointer to a variable that receives the GDI handle of the picture. This parameter can be <c>NULL</c> if the caller does
		/// not need the handle. Ownership of this handle is determined by the fOwn parameter passed to OleCreatePictureIndirect.
		/// Pictures loaded from a stream always own their resources.
		/// </param>
		/// <returns>This method supports the standard return values E_FAIL, E_INVALIDARG, E_OUTOFMEMORY, and S_OK.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ipicture-selectpicture HRESULT SelectPicture( HDC hDCIn,
		// HDC *phDCOut, OLE_HANDLE *phBmpOut );
		[PreserveSig]
		HRESULT SelectPicture(HDC hDCIn, out HDC phDCOut, out uint phBmpOut);

		/// <summary>Retrieves the current value of the picture's KeepOriginalFormat property.</summary>
		/// <param name="pKeep">A pointer to a variable that receives the value of the property.</param>
		/// <returns>
		/// <para>This method supports the standard return value E_FAIL, as well as the following value.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The value of the KeepOriginalFormat property was returned successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>The value of pKeep is not valid. For example, it may be NULL.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ipicture-get_keeporiginalformat HRESULT
		// get_KeepOriginalFormat( BOOL *pKeep );
		[PreserveSig]
		HRESULT get_KeepOriginalFormat([MarshalAs(UnmanagedType.Bool)] out bool pKeep);

		/// <summary>Sets the value of the picture's KeepOriginalFormat property.</summary>
		/// <param name="keep">Specifies the new value to assign to the property.</param>
		/// <returns>This method returns S_OK on success and E_FAIL otherwise.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ipicture-put_keeporiginalformat HRESULT
		// put_KeepOriginalFormat( BOOL keep );
		[PreserveSig]
		HRESULT put_KeepOriginalFormat([MarshalAs(UnmanagedType.Bool)] bool keep);

		/// <summary>
		/// Notifies the picture object that its picture resource has changed. This method only calls IPropertyNotifySink::OnChanged
		/// with DISPID_PICT_HANDLE for any connected sinks.
		/// </summary>
		/// <returns>This method S_OK if it succeeds and E_FAIL if the picture object is uninitialized.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ipicture-picturechanged HRESULT PictureChanged();
		[PreserveSig]
		HRESULT PictureChanged();

		/// <summary>
		/// Saves the picture's data into a stream in the same format that it would save itself into a file. Bitmaps use the BMP file
		/// format, metafiles the WMF format, and icons the ICO format.
		/// </summary>
		/// <param name="pStream">A pointer to the stream into which the picture writes its data.</param>
		/// <param name="fSaveMemCopy">A flag indicating whether to save a copy of the picture in memory.</param>
		/// <param name="pCbSize">
		/// Pointer to a variable that receives the number of bytes written into the stream. This value can be <c>NULL</c>, indicating
		/// that the caller does not require this information.
		/// </param>
		/// <returns>This method supports the standard return values E_FAIL, E_INVALIDARG, and S_OK.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ipicture-saveasfile HRESULT SaveAsFile( LPSTREAM pStream,
		// BOOL fSaveMemCopy, LONG *pCbSize );
		[PreserveSig]
		HRESULT SaveAsFile(IStream pStream, [MarshalAs(UnmanagedType.Bool)] bool fSaveMemCopy, out int pCbSize);

		/// <summary>Retrieves the current set of the picture's bit attributes.</summary>
		/// <param name="pDwAttr">
		/// <para>A pointer to a variable that receives the value of the Attributes property.</para>
		/// <para>The Attributes property can contain any combination of the values from the PICTUREATTRIBUTES enumeration.</para>
		/// </param>
		/// <returns>
		/// <para>This method supports the standard return value E_FAIL, as well as the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The attribute bits were returned successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>The value of pdwAttr is not valid. For example, it may be NULL.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ipicture-get_attributes HRESULT get_Attributes( DWORD
		// *pDwAttr );
		[PreserveSig]
		HRESULT get_Attributes(out PICTUREATTRIBUTES pDwAttr);
	}

	/// <summary>
	/// <para>
	/// Manages a picture object and its properties. Picture objects provide a language-neutral abstraction for bitmaps, icons, and
	/// metafiles. As with the standard font object, the system provides a standard implementation of the picture object. Its primary
	/// interfaces are <c>IPicture</c> and IPictureDisp, the latter being derived from <c>IDispatch</c> to provide access to the
	/// picture's properties through Automation. A picture object is created with OleCreatePictureIndirect.
	/// </para>
	/// <para>
	/// The picture object also supports the outgoing interface IPropertyNotifySink, so a client can determine when picture properties
	/// change. Because the picture object supports at least one outgoing interface, it also implements IConnectionPointContainer and
	/// its associated interfaces for this purpose.
	/// </para>
	/// <para>
	/// The picture object also supports IPersistStream so that it can save and load itself from an instance of IStream. An object that
	/// uses a picture object internally would normally save and load the picture as part of the object's own persistence handling. The
	/// function OleLoadPicture simplifies the creation of a picture object based on stream contents.
	/// </para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// Each property in the <c>IPicture</c> interface includes a <c>get_PropertyName</c> method if the property supports read access
	/// and a <c>put_PropertyName</c> method if the property supports write access.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Property</term>
	/// <term>Type</term>
	/// <term>Access</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>Handle</term>
	/// <term>OLE_HANDLE (int)</term>
	/// <term>R</term>
	/// <term>The Windows GDI handle of the picture</term>
	/// </item>
	/// <item>
	/// <term>hPal</term>
	/// <term>OLE_HANDLE (int)</term>
	/// <term>RW</term>
	/// <term>The Windows handle of the palette used by the picture.</term>
	/// </item>
	/// <item>
	/// <term>Type</term>
	/// <term>short</term>
	/// <term>R</term>
	/// <term>The type of picture (see PICTYPE).</term>
	/// </item>
	/// <item>
	/// <term>Width</term>
	/// <term>OLE_XSIZE_HIMETRIC (long)</term>
	/// <term>R</term>
	/// <term>The width of the picture.</term>
	/// </item>
	/// <item>
	/// <term>Height</term>
	/// <term>OLE_YSIZE_HIMETRIC (long)</term>
	/// <term>R</term>
	/// <term>The height of the picture.</term>
	/// </item>
	/// <item>
	/// <term>CurDC</term>
	/// <term>HDC</term>
	/// <term>R</term>
	/// <term>The current device context.</term>
	/// </item>
	/// <item>
	/// <term>KeepOriginalFormat</term>
	/// <term>BOOL</term>
	/// <term>RW</term>
	/// <term>
	/// If TRUE, the picture object maintains the entire original state of the picture in memory. If FALSE, any state not applicable to
	/// the user's computer is discarded.
	/// </term>
	/// </item>
	/// <item>
	/// <term>Attributes</term>
	/// <term>DWORD</term>
	/// <term>R</term>
	/// <term>Miscellaneous bit attributes of the picture.</term>
	/// </item>
	/// </list>
	/// <para>OLE Implementation</para>
	/// <para>
	/// Picture objects provide a language-neutral abstraction for bitmaps, icons, and metafiles. As with the standard font object, the
	/// system provides a standard implementation of the picture object. Its primary interfaces are <c>IPicture</c> and IPictureDisp. A
	/// picture object is created with OleCreatePictureIndirect and supports both the <c>IPicture</c> and the <c>IPictureDisp</c> interfaces.
	/// </para>
	/// <para>The OLE-provided picture object implements the complete semantics of the <c>IPicture</c> and IPictureDisp interfaces.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nn-ocidl-ipicture
	[PInvokeData("ocidl.h", MSDNShortId = "NN:ocidl.IPicture2")]
	[ComImport, Guid("F5185DD8-2012-4b0b-AAD9-F052C6BD482B"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IPicture2
	{
		/// <summary>Retrieves the handle to the picture managed within this picture object to a specified location.</summary>
		/// <param name="pHandle">
		/// A pointer to a variable that receives the handle. The caller is responsible for this handle upon successful return. The
		/// variable is set to <c>NULL</c> on failure.
		/// </param>
		/// <returns>
		/// <para>This method supports the standard return values E_FAIL and E_OUTOFMEMORY, as well as the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The handle was returned successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>The value of phandle is not valid. For example, it may be NULL.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Notes to Callers</para>
		/// <para>
		/// The picture object may retain ownership of the picture. However, the caller can be assured that the picture will remain
		/// valid until either the caller specifically destroys the picture or the picture object is itself destroyed. The fOwn
		/// parameter to OleCreatePictureIndirect determines ownership when the picture object is created. OleLoadPicture forces fOwn to <c>TRUE</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ipicture-get_handle HRESULT get_Handle( OLE_HANDLE *pHandle );
		[PreserveSig]
		HRESULT get_Handle(out HANDLE pHandle);

		/// <summary>Retrieves a copy of the palette currently used by the picture object.</summary>
		/// <param name="phPal">A pointer to a variable that receives the palette handle. The variable is set to <c>NULL</c> on failure.</param>
		/// <returns>
		/// <para>This method supports the standard return values E_FAIL and E_OUTOFMEMORY, as well as the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The height was returned successfully.</term>
		/// </item>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>This picture has no palette. The variable that phpal points to was set to NULL.</term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>The value of phPal is not valid. For example, it may be NULL.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Notes to Callers</para>
		/// <para>
		/// If the picture object has ownership of the picture, it also has ownership of the palette and will destroy it when the object
		/// is itself destroyed. Otherwise the caller owns the palette. The fOwn parameter to OleCreatePictureIndirect determines
		/// ownership. OleLoadPicture sets fOwn to <c>TRUE</c> to indicate that the picture object owns the palette.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ipicture-get_hpal HRESULT get_hPal( OLE_HANDLE *phPal );
		[PreserveSig]
		HRESULT get_hPal(out HANDLE phPal);

		/// <summary>Retrieves the current type of the picture contained in the picture object.</summary>
		/// <param name="pType">
		/// Pointer to a variable that receives the picture type. The Type property can have any one of the values contained in the
		/// PICTYPE enumeration.
		/// </param>
		/// <returns>
		/// <para>This method supports the standard return value E_FAIL, as well as the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The type was returned successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>The value of pType is not valid. For example, it may be NULL.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ipicture-get_type HRESULT get_Type( SHORT *pType );
		[PreserveSig]
		HRESULT get_Type(out PICTYPE pType);

		/// <summary>Retrieves the current width of the picture in the picture object.</summary>
		/// <param name="pWidth">A pointer to a variable that receives the width.</param>
		/// <returns>
		/// <para>This method supports the standard return value E_FAIL, as well as the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The width was returned successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>The value of pWidth is not valid. For example, it may be NULL.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ipicture-get_width HRESULT get_Width( OLE_XSIZE_HIMETRIC
		// *pWidth );
		[PreserveSig]
		HRESULT get_Width(out int pWidth);

		/// <summary>Retrieves the current height of the picture in the picture object.</summary>
		/// <param name="pHeight">A pointer to a variable that receives the height.</param>
		/// <returns>
		/// <para>This method supports the standard return value E_FAIL, as well as the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The height was returned successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>The value of pHeight is not valid. For example, it may be NULL.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ipicture-get_height HRESULT get_Height( OLE_YSIZE_HIMETRIC
		// *pHeight );
		[PreserveSig]
		HRESULT get_Height(out int pHeight);

		/// <summary>
		/// Renders (draws) a specified portion of the picture defined by the offset (xSrc,ySrc) of the source picture and the
		/// dimensions to copy (cxSrc,xySrc). This picture is rendered onto the specified device context, positioned at the point (x,y),
		/// and scaled to the dimensions (cx,cy). The prcWBounds parameter specifies the position of this rendering if the destination
		/// device context is itself a metafile. Such information is necessary to place one metafile in another. For more information,
		/// see the prcWBounds parameter of IViewObject2::Draw.
		/// </summary>
		/// <param name="hDC">A handle of the device context on which to render the image.</param>
		/// <param name="x">The horizontal coordinate in hdc at which to place the rendered image.</param>
		/// <param name="y">The vertical coordinate in hdc at which to place the rendered image.</param>
		/// <param name="cx">The horizontal dimension (width) of the destination rectangle.</param>
		/// <param name="cy">The vertical dimension (height) of the destination rectangle</param>
		/// <param name="xSrc">The horizontal offset in the source picture from which to start copying.</param>
		/// <param name="ySrc">The vertical offset in the source picture from which to start copying.</param>
		/// <param name="cxSrc">The horizontal extent to copy from the source picture.</param>
		/// <param name="cySrc">The vertical extent to copy from the source picture.</param>
		/// <param name="pRcWBounds">
		/// A pointer to a rectangle containing the position of the destination within a metafile device context if hdc is a metafile
		/// DC. Cannot be <c>NULL</c> in such cases.
		/// </param>
		/// <returns>
		/// <para>This method supports the standard return values E_FAIL, E_INVALIDARG, and E_OUTOFMEMORY, as well as the following:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The picture was rendered successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>The address in prcWBounds is not valid when hdc contains a metafile device context.</term>
		/// </item>
		/// <item>
		/// <term>CTL_E_INVALIDPROPERTYVALUE</term>
		/// <term>The parameter cx, cy, cxSrc, or cySrc has a value of zero.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ipicture-render HRESULT Render( HDC hDC, LONG x, LONG y,
		// LONG cx, LONG cy, OLE_XPOS_HIMETRIC xSrc, OLE_YPOS_HIMETRIC ySrc, OLE_XSIZE_HIMETRIC cxSrc, OLE_YSIZE_HIMETRIC cySrc, LPCRECT
		// pRcWBounds );
		[PreserveSig]
		HRESULT Render(HDC hDC, int x, int y, int cx, int cy, int xSrc, int ySrc, int cxSrc, int cySrc, [In, Optional] PRECT? pRcWBounds);

		/// <summary>Assigns a GDI palette to the picture contained in the picture object.</summary>
		/// <param name="hPal">A handle to the GDI palette assigned to the picture.</param>
		/// <returns>This method supports the standard return values E_FAIL, E_INVALIDARG, E_OUTOFMEMORY, and S_OK.</returns>
		/// <remarks>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// Ownership of the palette passed to this method depends on how the picture object was created, as specified by the fOwn
		/// parameter to OleCreatePictureIndirect. OleLoadPicture forces fOwn to <c>TRUE</c>; if the object owns the picture, then it
		/// takes over ownership of this palette.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ipicture-set_hpal HRESULT set_hPal( OLE_HANDLE hPal );
		[PreserveSig]
		HRESULT set_hPal(HANDLE hPal);

		/// <summary>Retrieves the handle of the current device context. This property is valid only for bitmap pictures.</summary>
		/// <param name="phDC">A pointer a variable that receives the device context.</param>
		/// <returns>
		/// <para>This method supports the standard return value E_FAIL, as well as the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The attribute bits were returned successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>The value of phDC is not valid. For example, it may be NULL.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The CurDC property and the IPicture::SelectPicture method exist to circumvent restrictions in Windows; specifically, that an
		/// object can only be selected into exactly one device context at a time. In some cases, a picture object may be permanently
		/// selected into a particular device context (for example, a control may use a certain picture for a background). To use this
		/// picture property elsewhere, it must be temporarily deselected from its old device context, selected into the new device
		/// context for the operation, then reselected back into the old device context. The <c>IPicture::get_CurDC</c> method returns
		/// the device context handle into which the picture is currently selected. The <c>IPicture::SelectPicture</c> method selects
		/// the picture into a new device context, returning the old device context and the picture's GDI handle. The caller should
		/// select the picture back into the old device context when the caller is done with it, as is normal for Windows code.
		/// </para>
		/// <para>Notes to Callers</para>
		/// <para>
		/// The caller always owns any device contexts passed between it and the picture object. Because the picture object maintains a
		/// copy of the HDC, the caller should use a memory device context (created with the CreateCompatibleDC function) and not a
		/// screen device context (from GetDC, CreateDC, or BeginPaint), because the screen device contexts are a limited system resource.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ipicture-get_curdc HRESULT get_CurDC( HDC *phDC );
		[PreserveSig]
		HRESULT get_CurDC(out HDC phDC);

		/// <summary>
		/// Selects a bitmap picture into a given device context, and returns the device context in which the picture was previously
		/// selected as well as the picture's GDI handle. This method works in conjunction with IPicture::get_CurDC.
		/// </summary>
		/// <param name="hDCIn">A handle for the device context in which to select the picture.</param>
		/// <param name="phDCOut">
		/// A pointer to a variable that receives the previous device context. This parameter can be <c>NULL</c> if the caller does not
		/// need this information. Ownership of the device context is always the responsibility of the caller.
		/// </param>
		/// <param name="phBmpOut">
		/// A pointer to a variable that receives the GDI handle of the picture. This parameter can be <c>NULL</c> if the caller does
		/// not need the handle. Ownership of this handle is determined by the fOwn parameter passed to OleCreatePictureIndirect.
		/// Pictures loaded from a stream always own their resources.
		/// </param>
		/// <returns>This method supports the standard return values E_FAIL, E_INVALIDARG, E_OUTOFMEMORY, and S_OK.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ipicture-selectpicture HRESULT SelectPicture( HDC hDCIn,
		// HDC *phDCOut, OLE_HANDLE *phBmpOut );
		[PreserveSig]
		HRESULT SelectPicture(HDC hDCIn, out HDC phDCOut, out HANDLE phBmpOut);

		/// <summary>Retrieves the current value of the picture's KeepOriginalFormat property.</summary>
		/// <param name="pKeep">A pointer to a variable that receives the value of the property.</param>
		/// <returns>
		/// <para>This method supports the standard return value E_FAIL, as well as the following value.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The value of the KeepOriginalFormat property was returned successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>The value of pKeep is not valid. For example, it may be NULL.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ipicture-get_keeporiginalformat HRESULT
		// get_KeepOriginalFormat( BOOL *pKeep );
		[PreserveSig]
		HRESULT get_KeepOriginalFormat([MarshalAs(UnmanagedType.Bool)] out bool pKeep);

		/// <summary>Sets the value of the picture's KeepOriginalFormat property.</summary>
		/// <param name="keep">Specifies the new value to assign to the property.</param>
		/// <returns>This method returns S_OK on success and E_FAIL otherwise.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ipicture-put_keeporiginalformat HRESULT
		// put_KeepOriginalFormat( BOOL keep );
		[PreserveSig]
		HRESULT put_KeepOriginalFormat([MarshalAs(UnmanagedType.Bool)] bool keep);

		/// <summary>
		/// Notifies the picture object that its picture resource has changed. This method only calls IPropertyNotifySink::OnChanged
		/// with DISPID_PICT_HANDLE for any connected sinks.
		/// </summary>
		/// <returns>This method S_OK if it succeeds and E_FAIL if the picture object is uninitialized.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ipicture-picturechanged HRESULT PictureChanged();
		[PreserveSig]
		HRESULT PictureChanged();

		/// <summary>
		/// Saves the picture's data into a stream in the same format that it would save itself into a file. Bitmaps use the BMP file
		/// format, metafiles the WMF format, and icons the ICO format.
		/// </summary>
		/// <param name="pStream">A pointer to the stream into which the picture writes its data.</param>
		/// <param name="fSaveMemCopy">A flag indicating whether to save a copy of the picture in memory.</param>
		/// <param name="pCbSize">
		/// Pointer to a variable that receives the number of bytes written into the stream. This value can be <c>NULL</c>, indicating
		/// that the caller does not require this information.
		/// </param>
		/// <returns>This method supports the standard return values E_FAIL, E_INVALIDARG, and S_OK.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ipicture-saveasfile HRESULT SaveAsFile( LPSTREAM pStream,
		// BOOL fSaveMemCopy, LONG *pCbSize );
		[PreserveSig]
		HRESULT SaveAsFile(IStream pStream, [MarshalAs(UnmanagedType.Bool)] bool fSaveMemCopy, out int pCbSize);

		/// <summary>Retrieves the current set of the picture's bit attributes.</summary>
		/// <param name="pDwAttr">
		/// <para>A pointer to a variable that receives the value of the Attributes property.</para>
		/// <para>The Attributes property can contain any combination of the values from the PICTUREATTRIBUTES enumeration.</para>
		/// </param>
		/// <returns>
		/// <para>This method supports the standard return value E_FAIL, as well as the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The attribute bits were returned successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>The value of pdwAttr is not valid. For example, it may be NULL.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ipicture-get_attributes HRESULT get_Attributes( DWORD
		// *pDwAttr );
		[PreserveSig]
		HRESULT get_Attributes(out PICTUREATTRIBUTES pDwAttr);
	}

	/// <summary>
	/// <para>
	/// Enables an object to remain inactive most of the time, yet still participate in interaction with the mouse, including drag and drop.
	/// </para>
	/// <para>
	/// Objects can be active (in-place or UI active) or they can be inactive (loaded or running). An active object creates a window and
	/// can receive Windows mouse and keyboard messages. An inactive object can render itself and provide a representation of its data
	/// in a given format. While they provide more functionality, active objects also consume more resources than inactive objects.
	/// Typically, they are larger and slower than inactive objects. Thus, keeping an object inactive can provide performance improvements.
	/// </para>
	/// <para>
	/// However, an object, such as a control, needs to be able to control the mouse pointer, fire mouse events, and act as a drop
	/// target so it can participate in the user interface of its container application.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nn-ocidl-ipointerinactive
	[PInvokeData("ocidl.h", MSDNShortId = "NN:ocidl.IPointerInactive")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("55980BA0-35AA-11CF-B671-00AA004CD6D8")]
	public interface IPointerInactive
	{
		/// <summary>
		/// Retrieves the current activation policy for the object. This method is called by the container on receipt of a WM_SETCURSOR
		/// or WM_MOUSEMOVE message when an inactive object is under the mouse pointer.
		/// </summary>
		/// <param name="pdwPolicy">
		/// A pointer to a variable that receives the activation policy. Possible values come from the POINTERINACTIVE enumeration.
		/// </param>
		/// <returns>If the method succeeds, the return value is S_OK. Otherwise, it is E_FAIL.</returns>
		/// <remarks>
		/// <para>
		/// The object can request to be in-place activated as soon as the mouse enters it through the POINTERINACTIVE_ACTIVATEONENTRY
		/// value. An object that provides more visual feedback than simply setting the mouse pointer would use this value. For example,
		/// if the object supports special visual feedback, it must enter the active state so it can draw the visual feedback that it supports.
		/// </para>
		/// <para>
		/// An object can also use this method to request activation when the mouse is dragged over them during a drag and drop
		/// operation through the POINTERINACTIVE_ACTIVATEONDRAG.
		/// </para>
		/// <para>
		/// If the object returns one of these values, the container should activate the object immediately and forward the Window
		/// message that triggered the call. The object then stays active and processes subsequent messages through its own window until
		/// the container gets another WM_SETCURSOR or WM_MOUSEMOVE. At this point, the container should deactivate the object.
		/// </para>
		/// <para>
		/// For windowless OLE objects this mechanism is slightly different. See IOleInPlaceSiteWindowless for more information on drag
		/// and drop operations for windowless objects.
		/// </para>
		/// <para>
		/// If the object returns both the POINTERINACTIVE_ACTIVATEONENTRY and the POINTERINACTIVE_DEACTIVATEONLEAVE values, the object
		/// is activated only when the mouse is over the object. If the POINTERINACTIVE_ACTIVATEONENTRY value alone is set, the object
		/// is activated once when the mouse first enters it, and it remains active.
		/// </para>
		/// <para>Notes to Callers</para>
		/// <para>
		/// The activation policy should not be cached. The container should call this method each time the mouse enters an inactive object.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ipointerinactive-getactivationpolicy HRESULT
		// GetActivationPolicy( DWORD *pdwPolicy );
		[PreserveSig]
		HRESULT GetActivationPolicy(out POINTERINACTIVE pdwPolicy);

		/// <summary>
		/// Notifies the object that the mouse pointer has moved over it so the object can fire mouse events. This method is called by
		/// the container on receipt of a WM_MOUSEMOVE method when an inactive object is under the mouse pointer.
		/// </summary>
		/// <param name="pRectBounds">
		/// The object bounding rectangle, in client coordinates of the containing window. This parameter tells the object its exact
		/// position and size on the screen when the WM_MOUSEMOVE message was received. This value is specified in units of the client's
		/// coordinate system.
		/// </param>
		/// <param name="x">The horizontal coordinate of mouse location in units of the client's containing window.</param>
		/// <param name="y">The vertical coordinate of mouse location in units of the client's containing window.</param>
		/// <param name="grfKeyState">
		/// The current state of the keyboard modifier keys on the keyboard. Possible values can be a combination of any of the values
		/// MK_CONTROL, MK_SHIFT, MK_ALT, MK_BUTTON, MK_LBUTTON, MK_MBUTTON, and MK_RBUTTON.
		/// </param>
		/// <returns>If the method succeeds, the return value is S_OK. Otherwise, it is E_FAIL.</returns>
		/// <remarks>
		/// <para>
		/// The container calls this method to notify the object that the mouse pointer is over the object after checking the object's
		/// activation policy by calling the IPointerInactive::GetActivationPolicy method. If the object has not requested to be
		/// activated in-place through that call, the container dispatches subsequent WM_MOUSEMOVE messages to the inactive object by
		/// calling <c>OnInactiveMouseMove</c> as long as the mouse pointer stays over the object. The object can then fire mouse move events.
		/// </para>
		/// <para>
		/// To avoid rounding errors and to make the job easier on the object implementer, this method takes window coordinates in the
		/// units of its containing client window, that is, the window in which the object is displayed, instead of the usual
		/// <c>HIMETRIC</c> units. Thus, the same coordinates and code path can be used when the object is active and inactive. The
		/// window coordinates specify the mouse position. The bounding rectangle is also specified in the same coordinate system.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ipointerinactive-oninactivemousemove HRESULT
		// OnInactiveMouseMove( LPCRECT pRectBounds, LONG x, LONG y, DWORD grfKeyState );
		[PreserveSig]
		HRESULT OnInactiveMouseMove(in RECT pRectBounds, int x, int y, uint grfKeyState);

		/// <summary>
		/// Sets the mouse pointer for an inactive object. This method is called by the container on receipt of a WM_SETCURSOR method
		/// when an inactive object is under the mouse pointer.
		/// </summary>
		/// <param name="pRectBounds">
		/// The object bounding rectangle specified in client coordinate units of the containing window. This parameter tells the object
		/// its exact position and size on the screen when the WM_SETCURSOR message was received. This value is specified in units of
		/// the client's coordinate system.
		/// </param>
		/// <param name="x">The horizontal coordinate of mouse location in units of the client's containing window.</param>
		/// <param name="y">The vertical coordinate of mouse location in units of the client's containing window.</param>
		/// <param name="dwMouseMsg">The identifier of the mouse message for which a WM_SETCURSOR occurred.</param>
		/// <param name="fSetAlways">
		/// If this value is <c>TRUE</c>, the object must set the cursor; if this value is <c>FALSE</c>, the object is not obligated to
		/// set the cursor, and should return S_FALSE in that case.
		/// </param>
		/// <returns>
		/// <para>This method can return the standard return value E_FAIL, as well as the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The mouse pointer was successfully set.</term>
		/// </item>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>
		/// The object did not set the cursor; the container should either set the cursor or call the object again with the parameter
		/// fSetAlways set to TRUE.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The container calls this method to set the mouse pointer over an inactive object after checking the object's activation
		/// policy by calling the IPointerInactive::GetActivationPolicy method. If the object has not requested to be activated in-place
		/// through that call, the container dispatches subsequent WM_SETCURSOR messages to the inactive object by calling
		/// <c>OnInactiveSetCursor</c> as long as the mouse pointer stays over the object.
		/// </para>
		/// <para>
		/// To avoid rounding errors and to make the job easier on the object implementer, this method takes window coordinates in the
		/// units of its containing client window, that is, the window in which the object is displayed, instead of the usual
		/// <c>HIMETRIC</c> units. Thus, the same coordinates and code path can be used when the object is active and inactive. The
		/// window coordinates specify the mouse position. The bounding rectangle is also specified in the same coordinate system.
		/// </para>
		/// <para>
		/// <c>OnInactiveSetCursor</c> takes an additional parameter, fSetAlways, that indicates whether the object is obligated to set
		/// the cursor or not. Containers should first call this method with this parameter <c>FALSE</c>. The object may return S_FALSE
		/// to indicate that it did not set the cursor. In that case, the container should either set the cursor itself, or, if it does
		/// not wish to do this, call the <c>OnInactiveSetCursor</c> method again with fSetAlways being <c>TRUE</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ipointerinactive-oninactivesetcursor HRESULT
		// OnInactiveSetCursor( LPCRECT pRectBounds, LONG x, LONG y, DWORD dwMouseMsg, BOOL fSetAlways );
		[PreserveSig]
		HRESULT OnInactiveSetCursor(in RECT pRectBounds, int x, int y, uint dwMouseMsg, [MarshalAs(UnmanagedType.Bool)] bool fSetAlways);
	}

	/// <summary>
	/// Implemented by a sink object to receive notifications about property changes from an object that supports
	/// <c>IPropertyNotifySink</c> as an outgoing interface. The client that needs to receive the notifications in this interface (from
	/// a supporting connectable object) creates a sink with this interface and connects it to the connectable object through the
	/// connection point mechanism. For more information on connection points, see IConnectionPointContainer.
	/// </summary>
	/// <remarks>
	/// <para>
	/// The object is itself required to call the methods of <c>IPropertyNotifySink</c> only for those properties marked with the
	/// [bindable] and [requestedit] attributes in the object's type information. When the object changes a [ <c>bindable</c>] property,
	/// it is required to call IPropertyNotifySink::OnChanged. When the object is about to change a [ <c>requestedit</c>] property, it
	/// must call IPropertyNotifySink::OnRequestEdit before changing the property and must also honor the action specified by the sink
	/// on return from this call.
	/// </para>
	/// <para>
	/// The one exception to this rule is that no notifications are sent as a result of an object's initialization or loading
	/// procedures. At initialization time, it is assumed that all properties change and that all must be allowed to change.
	/// Notifications to this interface are therefore meaningful only in the context of a fully initialized/loaded object.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nn-ocidl-ipropertynotifysink
	[PInvokeData("ocidl.h", MSDNShortId = "NN:ocidl.IPropertyNotifySink")]
	[ComImport, Guid("9BFBBC02-EFF1-101A-84ED-00AA00341D07"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IPropertyNotifySink
	{
		/// <summary>Notifies a sink that a bindable property has changed.</summary>
		/// <param name="dispID">
		/// The dispatch identifier of the property that changed, or DISPID_UNKNOWN if multiple properties have changed. The client
		/// (owner of the sink) should retrieve the current value of each property of interest from the object that generated the notification.
		/// </param>
		/// <returns>This method returns S_OK in all cases.</returns>
		/// <remarks>
		/// S_OK is returned in all cases even when the sink does not need [bindable] properties or when some other failure has
		/// occurred. In short, the calling object simply sends the notification and cannot attempt to use an error code (such as
		/// E_NOTIMPL) to determine whether to not send the notification in the future. Such semantics are not part of this interface.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ipropertynotifysink-onchanged HRESULT OnChanged( DISPID
		// dispID );
		[PreserveSig]
		HRESULT OnChanged(int dispID);

		/// <summary>Notifies a sink that a requestedit property is about to change.</summary>
		/// <param name="dispID">
		/// The dispatch identifier of the property that is about to change or DISPID_UNKNOWN if multiple properties are about to change.
		/// </param>
		/// <returns>
		/// <para>This method can return the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The specified property or properties are allowed to change.</term>
		/// </item>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>
		/// The specified property or properties are not allowed to change. The caller must obey this return value by discarding the new
		/// property value(s). This is part of the contract of the [requestedit] attribute and this method.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The sink may choose to allow or disallow the change to take place. For example, the sink may enforce a read-only state on
		/// the property. DISPID_UNKNOWN is a valid parameter to this method to indicate that multiple properties are about to change.
		/// In this case, the sink can enforce a global read-only state for all [requestedit] properties in the object, including any
		/// specific ones that the sink otherwise recognizes.
		/// </para>
		/// <para>
		/// If the sink allows changes, the object must also make IPropertyNotifySink::OnChanged notifications for any properties that
		/// are marked [bindable] in addition to [requestedit].
		/// </para>
		/// <para>
		/// This method cannot be used to implement any sort of data validation. At the time of the call, the desired new value of the
		/// property is unavailable and thus cannot be validated. This method's only purpose is to allow the sink to enforce a read-only
		/// state on a property.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ipropertynotifysink-onrequestedit HRESULT OnRequestEdit(
		// DISPID dispID );
		[PreserveSig]
		HRESULT OnRequestEdit(int dispID);
	}

	/// <summary>
	/// <para>
	/// Provides the main features of a property page object that manages a particular page within a property sheet. A property page
	/// implements at least <c>IPropertyPage</c> and can optionally implement IPropertyPage2 if selection of a specific property is
	/// supported. See IPerPropertyBrowsing::MapPropertyToPage for more information on specific property browsing. The methods of
	/// <c>IPropertyPage2</c> enable the property sheet or property frame to instruct the page when to perform specific actions, mostly
	/// based on user input such as switching between pages or pressing various buttons that the frame itself manages in the dialog box.
	/// </para>
	/// <para>
	/// A property page manages a dialog box that contains only those controls that should be displayed for that one page within the
	/// property sheet itself. This means that the dialog box template used to define the page should only carry the WS_CHILD style and
	/// no others. It should not include any style related to a frame, caption, or system menus or controls.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nn-ocidl-ipropertypage
	[PInvokeData("ocidl.h", MSDNShortId = "NN:ocidl.IPropertyPage")]
	[ComImport, Guid("B196B28D-BAB4-101A-B69C-00AA00341D07"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IPropertyPage
	{
		/// <summary>
		/// Initializes a property page and provides the page with a pointer to the IPropertyPageSite interface through which the
		/// property page communicates with the property frame.
		/// </summary>
		/// <param name="pPageSite">
		/// A pointer to the IPropertyPageSite interface of the page site that manages and provides services to this property page
		/// within the entire property sheet.
		/// </param>
		/// <returns>This method can return the standard return values E_INVALIDARG, E_OUTOFMEMORY, and S_OK.</returns>
		/// <remarks>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// If the pPageSite parameter is <c>NULL</c>, this method must call Release on any IPropertyPageSite pointer passed during a
		/// previous call to this method. If non- <c>NULL</c>, this method must save the <c>IPropertyPageSite</c> pointer value and call
		/// AddRef. Two consecutive calls to this method with a non- <c>NULL</c> site pointer are not allowed and should cause the
		/// property page to return E_UNEXPECTED.
		/// </para>
		/// <para>E_NOTIMPL is not a valid return value. All property pages must implement this method.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ipropertypage-setpagesite HRESULT SetPageSite(
		// IPropertyPageSite *pPageSite );
		[PreserveSig]
		HRESULT SetPageSite(IPropertyPageSite? pPageSite);

		/// <summary>
		/// <para>Creates the dialog box window for the property page.</para>
		/// <para>
		/// The dialog box is created without a frame, caption, or system menu/controls. The text in the dialog should match the locale
		/// obtained through IPropertyPageSite::GetLocaleID.
		/// </para>
		/// </summary>
		/// <param name="hWndParent">The window handle of the parent of the dialog box that is being created.</param>
		/// <param name="pRect">
		/// A pointer to the RECT structure containing the positioning information for the dialog box. This method must create its
		/// dialog box with the placement and dimensions described by this structure.
		/// </param>
		/// <param name="bModal">Indicates whether the dialog box frame is modal ( <c>TRUE</c>) or modeless ( <c>FALSE</c>).</param>
		/// <returns>
		/// <para>This method can return the standard return values E_OUTOFMEMORY and E_UNEXPECTED, as well as the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method completed successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>The address in prc is not valid. For example, it may be NULL.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The property page maintains the window handle created in this process, which it uses to destroy the dialog box within IPropertyPage::Deactivate.
		/// </para>
		/// <para>Notes to Implementers</para>
		/// <para>E_NOTIMPL is not a valid return value.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ipropertypage-activate HRESULT Activate( HWND hWndParent,
		// LPCRECT pRect, BOOL bModal );
		[PreserveSig]
		HRESULT Activate(HWND hWndParent, in RECT pRect, [MarshalAs(UnmanagedType.Bool)] bool bModal);

		/// <summary>Destroys the window created in IPropertyPage::Activate.</summary>
		/// <returns>This method can return the standard return values E_UNEXPECTED and S_OK.</returns>
		/// <remarks>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// It is important that property pages not keep the dialog box around as an optimization. In a property sheet with many
		/// property pages, memory consumption would become excessive if all property pages kept their dialog boxes created at all
		/// times. Destroying the dialog box prevents excessive memory consumption due to a very large number of created controls in the
		/// dialog boxes. If the frame wishes to keep pages alive while they are not visible, it can use IPropertyPage::Show for that
		/// purpose. The decision is ultimately left to the frame.
		/// </para>
		/// <para>E_NOTIMPL is not a valid return value.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ipropertypage-deactivate HRESULT Deactivate();
		[PreserveSig]
		HRESULT Deactivate();

		/// <summary>Retrieves information about the property page.</summary>
		/// <param name="pPageInfo">
		/// A pointer to the caller-allocated PROPPAGEINFO structure in which the property page stores its page information. All
		/// allocations stored in this structure become the responsibility of the caller.
		/// </param>
		/// <returns>
		/// <para>This method can return the standard return values E_OUTOFMEMORY and E_UNEXPECTED, as well as the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The structure was successfully filled.</term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>The address in pPageInfo is not valid. For example, it may be NULL.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Notes to Implementers</para>
		/// <para>E_NOTIMPL is not a valid return value.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ipropertypage-getpageinfo HRESULT GetPageInfo( PROPPAGEINFO
		// *pPageInfo );
		[PreserveSig]
		HRESULT GetPageInfo(out PROPPAGEINFO pPageInfo);

		/// <summary>
		/// <para>Provides the property page with an array of pointers to objects associated with this property page.</para>
		/// <para>
		/// When the property page receives a call to IPropertyPage::Apply, it must send value changes to these objects through whatever
		/// interfaces are appropriate. The property page must query for those interfaces. This method can fail if the objects do not
		/// support the interfaces expected by the property page.
		/// </para>
		/// </summary>
		/// <param name="cObjects">
		/// The number of pointers in the array pointed to by ppUnk. If this parameter is 0, the property page must release any pointers
		/// previously passed to this method.
		/// </param>
		/// <param name="ppUnk">
		/// A pointer to an array of IUnknown interface pointers where each pointer identifies a unique object affected by the property
		/// sheet in which this (and possibly other) property pages are displayed. The property page must cache these pointers calling
		/// AddRef for each pointer at that time. This array of pointers is the same one that was passed to OleCreatePropertyFrame or
		/// OleCreatePropertyFrameIndirect to invoke the property sheet.
		/// </param>
		/// <returns>
		/// <para>
		/// This method can return the standard return values E_FAIL, E_INVALIDARG, E_OUTOFMEMORY, and E_UNEXPECTED, as well as the
		/// following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The property page successfully saved the pointers it needed.</term>
		/// </item>
		/// <item>
		/// <term>E_NOINTERFACE</term>
		/// <term>
		/// One of the objects in ppUnk did not support the interface expected by this property page, and so this property page cannot
		/// communicate with it.
		/// </term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>The address in ppUnk is not valid. For example, it may be NULL.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The property page is required to keep the pointers returned by this method or others queried through them. If these specific
		/// IUnknown pointers are held, the property page must call AddRef through each when caching them, until the time when
		/// <c>SetObjects</c> is called with cObjects equal to 0. At that time, the property page must call Release through each
		/// pointer, releasing any objects that it held.
		/// </para>
		/// <para>
		/// The caller must provide the property page with these objects before calling IPropertyPage::Activate, and should call
		/// <c>SetObjects</c> with zero as the parameter when deactivating the page or when releasing the object entirely. Each call to
		/// <c>SetObjects</c> with a non- <c>NULL</c> ppUnk parameter must be matched with a later call to <c>SetObjects</c> with 0 in
		/// the cObjects parameter.
		/// </para>
		/// <para>Notes to Implementers</para>
		/// <para>E_NOTIMPL is not a valid return value.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ipropertypage-setobjects HRESULT SetObjects( ULONG
		// cObjects, IUnknown **ppUnk );
		[PreserveSig]
		HRESULT SetObjects(uint cObjects, [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 0)] object[] ppUnk);

		/// <summary>
		/// Makes the property page dialog box visible or invisible. If the page is made visible, the page should set the focus to
		/// itself, specifically to the first property on the page.
		/// </summary>
		/// <param name="nCmdShow">
		/// A command describing whether to become visible (SW_SHOW or SW_SHOWNORMAL) or hidden (SW_HIDE). No other values are valid for
		/// this parameter.
		/// </param>
		/// <returns>This method can return the standard return values E_INVALIDARG, E_UNEXPECTED, and S_OK.</returns>
		/// <remarks>
		/// <para>Notes to Callers</para>
		/// <para>Calls to this method must occur after a call to IPropertyPage::Activate and before a corresponding call to IPropertyPage::Deactivate.</para>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// E_NOTIMPL is not a valid return value. E_OUTOFMEMORY is not a valid return value, since no memory should be used in
		/// implementing this method.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ipropertypage-show HRESULT Show( UINT nCmdShow );
		[PreserveSig]
		HRESULT Show(ShowWindowCommand nCmdShow);

		/// <summary>Positions and resizes the property page dialog box within the frame.</summary>
		/// <param name="pRect">
		/// A pointer to the RECT structure containing the positioning information for the property page dialog box.
		/// </param>
		/// <returns>
		/// <para>This method can return the standard return value E_UNEXPECTED, as well as the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method completed successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>The address in prc is not valid. For example, it may be NULL.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The rectangle specified by prc is treated identically to that passed to IPropertyPage::Activate.</para>
		/// <para>Notes to Callers</para>
		/// <para>Calls to this method must occur after a call to IPropertyPage::Activate and before a corresponding call to IPropertyPage::Deactivate.</para>
		/// <para>Notes to Implementers</para>
		/// <para>The page must create its dialog box with the placement and dimensions described by this structure.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ipropertypage-move HRESULT Move( LPCRECT pRect );
		[PreserveSig]
		HRESULT Move(in RECT pRect);

		/// <summary>Indicates whether the property page has changed since it was activated or since the most recent call to Apply.</summary>
		/// <returns>This method returns S_OK to indicate that the property page has changed. Otherwise, it returns S_FALSE.</returns>
		/// <remarks>
		/// <para>
		/// The property sheet uses this information to enable or disable the <c>Apply</c> button in the dialog box. There is no need to
		/// apply the values on a property page if those values are already current with the underlying objects.
		/// </para>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// This method has no reason to return an error code, since the inability to determine if the page is dirty should return S_OK
		/// as a default. In this way, the user has a chance to update the values. The page should not return an error code, since an
		/// error code is not the same as S_OK and would indicate that the page is not dirty. Then, the property frame could potentially
		/// disable the <c>Apply</c> button, not allowing the user to make sure that the property values are current.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ipropertypage-ispagedirty HRESULT IsPageDirty();
		[PreserveSig]
		HRESULT IsPageDirty();

		/// <summary>
		/// Applies the current values to the underlying objects associated with the property page as previously passed to IPropertyPage::SetObjects.
		/// </summary>
		/// <returns>
		/// <para>
		/// This method can return the standard return values <c>E_OUTOFMEMORY</c> and <c>E_UNEXPECTED</c>, as well as the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Changes were successfully applied and the property page is current with the underlying objects.</term>
		/// </item>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>Changes were applied, but the property page cannot determine if its state is current with the objects.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The objects to be changed are provided through a previous call to IPropertyPage::SetObjects. By calling
		/// <c>IPropertyPage::SetObjects</c> prior to calling this method, the caller ensures that all underlying objects have the
		/// correct interfaces through which to communicate changes. Therefore, this method should not fail because of non-existent interfaces.
		/// </para>
		/// <para>
		/// After applying its values, the property page should determine if its state is now current with the objects in order to
		/// properly implement IPropertyPage::IsPageDirty and to provide both <c>S_OK</c> and <c>S_FALSE</c> return values.
		/// </para>
		/// <para>Notes to Implementers</para>
		/// <para>E_NOTIMPL is not a valid return value.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ipropertypage-apply HRESULT Apply();
		[PreserveSig]
		HRESULT Apply();

		/// <summary>Invokes the property page help in response to an end-user request.</summary>
		/// <param name="pszHelpDir">
		/// A pointer to the string under the <c>HelpDir</c> key in the property page's CLSID information in the registry. If
		/// <c>HelpDir</c> does not exist, this will be the path found in the <c>InprocServer32</c> entry minus the server file name.
		/// (Note that <c>LocalServer32</c> is not checked, because local property pages are not supported).
		/// </param>
		/// <returns>
		/// <para>This method can return the standard return values E_OUTOFMEMORY and E_UNEXPECTED, as well as the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The page displayed its own help.</term>
		/// </item>
		/// <item>
		/// <term>E_NOTIMPL</term>
		/// <term>Help is either not provided or is provided only through the information is PROPPAGEINFO.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Notes to Callers</para>
		/// <para>Calls to this method must occur between calls to IPropertyPage::Activate and IPropertyPage::Deactivate.</para>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// If the page fails this method (such as E_NOTIMPL), then the frame will attempt to use the <c>pszHelpFile</c> and
		/// <c>dwHelpContext</c> members of the PROPPAGEINFO structure obtained through IPropertyPage::GetPageInfo. Therefore, the page
		/// should either implement <c>IPropertyPage::Help</c> or return help information through <c>IPropertyPage::GetPageInfo</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ipropertypage-help HRESULT Help( LPCOLESTR pszHelpDir );
		[PreserveSig]
		HRESULT Help([MarshalAs(UnmanagedType.LPWStr)] string pszHelpDir);

		/// <summary>Passes a keystroke to the property page for processing.</summary>
		/// <param name="pMsg">A pointer to the MSG structure describing the keystroke to be processed.</param>
		/// <returns>
		/// <para>This method can return the standard return value E_UNEXPECTED, as well as the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The property page handles the accelerator.</term>
		/// </item>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>The property page handles accelerators, but this one was not useful to it.</term>
		/// </item>
		/// <item>
		/// <term>E_NOTIMPL</term>
		/// <term>The property page does not handle accelerators.</term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>The address in pMsg is not valid. For example, it may be NULL.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Notes to Callers</para>
		/// <para>Calls to this method must occur after a call to IPropertyPage::Activate and before the corresponding call to IPropertyPage::Deactivate.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ipropertypage-translateaccelerator HRESULT
		// TranslateAccelerator( MSG *pMsg );
		[PreserveSig]
		HRESULT TranslateAccelerator(in MSG pMsg);
	}

	/// <summary>
	/// <para>An extension to IPropertyPage to support initial selection of a property on a page.</para>
	/// <para>
	/// This method works in conjunction with the implementation of IPerPropertyBrowsing::MapPropertyToPage on an object that supplies
	/// properties and specifies property pages through ISpecifyPropertyPages. This interface has only one extra method in addition to
	/// those in IPropertyPage. That method, IPropertyPage2::EditProperty tells the page which property to highlight.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nn-ocidl-ipropertypage2
	[PInvokeData("ocidl.h", MSDNShortId = "NN:ocidl.IPropertyPage2")]
	[ComImport, Guid("01E44665-24AC-101B-84ED-08002B2EC713"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IPropertyPage2 : IPropertyPage
	{
		/// <summary>
		/// Initializes a property page and provides the page with a pointer to the IPropertyPageSite interface through which the
		/// property page communicates with the property frame.
		/// </summary>
		/// <param name="pPageSite">
		/// A pointer to the IPropertyPageSite interface of the page site that manages and provides services to this property page
		/// within the entire property sheet.
		/// </param>
		/// <returns>This method can return the standard return values E_INVALIDARG, E_OUTOFMEMORY, and S_OK.</returns>
		/// <remarks>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// If the pPageSite parameter is <c>NULL</c>, this method must call Release on any IPropertyPageSite pointer passed during a
		/// previous call to this method. If non- <c>NULL</c>, this method must save the <c>IPropertyPageSite</c> pointer value and call
		/// AddRef. Two consecutive calls to this method with a non- <c>NULL</c> site pointer are not allowed and should cause the
		/// property page to return E_UNEXPECTED.
		/// </para>
		/// <para>E_NOTIMPL is not a valid return value. All property pages must implement this method.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ipropertypage-setpagesite HRESULT SetPageSite(
		// IPropertyPageSite *pPageSite );
		[PreserveSig]
		new HRESULT SetPageSite(IPropertyPageSite? pPageSite);

		/// <summary>
		/// <para>Creates the dialog box window for the property page.</para>
		/// <para>
		/// The dialog box is created without a frame, caption, or system menu/controls. The text in the dialog should match the locale
		/// obtained through IPropertyPageSite::GetLocaleID.
		/// </para>
		/// </summary>
		/// <param name="hWndParent">The window handle of the parent of the dialog box that is being created.</param>
		/// <param name="pRect">
		/// A pointer to the RECT structure containing the positioning information for the dialog box. This method must create its
		/// dialog box with the placement and dimensions described by this structure.
		/// </param>
		/// <param name="bModal">Indicates whether the dialog box frame is modal ( <c>TRUE</c>) or modeless ( <c>FALSE</c>).</param>
		/// <returns>
		/// <para>This method can return the standard return values E_OUTOFMEMORY and E_UNEXPECTED, as well as the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method completed successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>The address in prc is not valid. For example, it may be NULL.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The property page maintains the window handle created in this process, which it uses to destroy the dialog box within IPropertyPage::Deactivate.
		/// </para>
		/// <para>Notes to Implementers</para>
		/// <para>E_NOTIMPL is not a valid return value.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ipropertypage-activate HRESULT Activate( HWND hWndParent,
		// LPCRECT pRect, BOOL bModal );
		[PreserveSig]
		new HRESULT Activate(HWND hWndParent, in RECT pRect, [MarshalAs(UnmanagedType.Bool)] bool bModal);

		/// <summary>Destroys the window created in IPropertyPage::Activate.</summary>
		/// <returns>This method can return the standard return values E_UNEXPECTED and S_OK.</returns>
		/// <remarks>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// It is important that property pages not keep the dialog box around as an optimization. In a property sheet with many
		/// property pages, memory consumption would become excessive if all property pages kept their dialog boxes created at all
		/// times. Destroying the dialog box prevents excessive memory consumption due to a very large number of created controls in the
		/// dialog boxes. If the frame wishes to keep pages alive while they are not visible, it can use IPropertyPage::Show for that
		/// purpose. The decision is ultimately left to the frame.
		/// </para>
		/// <para>E_NOTIMPL is not a valid return value.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ipropertypage-deactivate HRESULT Deactivate();
		[PreserveSig]
		new HRESULT Deactivate();

		/// <summary>Retrieves information about the property page.</summary>
		/// <param name="pPageInfo">
		/// A pointer to the caller-allocated PROPPAGEINFO structure in which the property page stores its page information. All
		/// allocations stored in this structure become the responsibility of the caller.
		/// </param>
		/// <returns>
		/// <para>This method can return the standard return values E_OUTOFMEMORY and E_UNEXPECTED, as well as the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The structure was successfully filled.</term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>The address in pPageInfo is not valid. For example, it may be NULL.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Notes to Implementers</para>
		/// <para>E_NOTIMPL is not a valid return value.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ipropertypage-getpageinfo HRESULT GetPageInfo( PROPPAGEINFO
		// *pPageInfo );
		[PreserveSig]
		new HRESULT GetPageInfo(out PROPPAGEINFO pPageInfo);

		/// <summary>
		/// <para>Provides the property page with an array of pointers to objects associated with this property page.</para>
		/// <para>
		/// When the property page receives a call to IPropertyPage::Apply, it must send value changes to these objects through whatever
		/// interfaces are appropriate. The property page must query for those interfaces. This method can fail if the objects do not
		/// support the interfaces expected by the property page.
		/// </para>
		/// </summary>
		/// <param name="cObjects">
		/// The number of pointers in the array pointed to by ppUnk. If this parameter is 0, the property page must release any pointers
		/// previously passed to this method.
		/// </param>
		/// <param name="ppUnk">
		/// A pointer to an array of IUnknown interface pointers where each pointer identifies a unique object affected by the property
		/// sheet in which this (and possibly other) property pages are displayed. The property page must cache these pointers calling
		/// AddRef for each pointer at that time. This array of pointers is the same one that was passed to OleCreatePropertyFrame or
		/// OleCreatePropertyFrameIndirect to invoke the property sheet.
		/// </param>
		/// <returns>
		/// <para>
		/// This method can return the standard return values E_FAIL, E_INVALIDARG, E_OUTOFMEMORY, and E_UNEXPECTED, as well as the
		/// following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The property page successfully saved the pointers it needed.</term>
		/// </item>
		/// <item>
		/// <term>E_NOINTERFACE</term>
		/// <term>
		/// One of the objects in ppUnk did not support the interface expected by this property page, and so this property page cannot
		/// communicate with it.
		/// </term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>The address in ppUnk is not valid. For example, it may be NULL.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The property page is required to keep the pointers returned by this method or others queried through them. If these specific
		/// IUnknown pointers are held, the property page must call AddRef through each when caching them, until the time when
		/// <c>SetObjects</c> is called with cObjects equal to 0. At that time, the property page must call Release through each
		/// pointer, releasing any objects that it held.
		/// </para>
		/// <para>
		/// The caller must provide the property page with these objects before calling IPropertyPage::Activate, and should call
		/// <c>SetObjects</c> with zero as the parameter when deactivating the page or when releasing the object entirely. Each call to
		/// <c>SetObjects</c> with a non- <c>NULL</c> ppUnk parameter must be matched with a later call to <c>SetObjects</c> with 0 in
		/// the cObjects parameter.
		/// </para>
		/// <para>Notes to Implementers</para>
		/// <para>E_NOTIMPL is not a valid return value.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ipropertypage-setobjects HRESULT SetObjects( ULONG
		// cObjects, IUnknown **ppUnk );
		[PreserveSig]
		new HRESULT SetObjects(uint cObjects, [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.IUnknown, SizeParamIndex = 0)] object[] ppUnk);

		/// <summary>
		/// Makes the property page dialog box visible or invisible. If the page is made visible, the page should set the focus to
		/// itself, specifically to the first property on the page.
		/// </summary>
		/// <param name="nCmdShow">
		/// A command describing whether to become visible (SW_SHOW or SW_SHOWNORMAL) or hidden (SW_HIDE). No other values are valid for
		/// this parameter.
		/// </param>
		/// <returns>This method can return the standard return values E_INVALIDARG, E_UNEXPECTED, and S_OK.</returns>
		/// <remarks>
		/// <para>Notes to Callers</para>
		/// <para>Calls to this method must occur after a call to IPropertyPage::Activate and before a corresponding call to IPropertyPage::Deactivate.</para>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// E_NOTIMPL is not a valid return value. E_OUTOFMEMORY is not a valid return value, since no memory should be used in
		/// implementing this method.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ipropertypage-show HRESULT Show( UINT nCmdShow );
		[PreserveSig]
		new HRESULT Show(ShowWindowCommand nCmdShow);

		/// <summary>Positions and resizes the property page dialog box within the frame.</summary>
		/// <param name="pRect">
		/// A pointer to the RECT structure containing the positioning information for the property page dialog box.
		/// </param>
		/// <returns>
		/// <para>This method can return the standard return value E_UNEXPECTED, as well as the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method completed successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>The address in prc is not valid. For example, it may be NULL.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The rectangle specified by prc is treated identically to that passed to IPropertyPage::Activate.</para>
		/// <para>Notes to Callers</para>
		/// <para>Calls to this method must occur after a call to IPropertyPage::Activate and before a corresponding call to IPropertyPage::Deactivate.</para>
		/// <para>Notes to Implementers</para>
		/// <para>The page must create its dialog box with the placement and dimensions described by this structure.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ipropertypage-move HRESULT Move( LPCRECT pRect );
		[PreserveSig]
		new HRESULT Move(in RECT pRect);

		/// <summary>Indicates whether the property page has changed since it was activated or since the most recent call to Apply.</summary>
		/// <returns>This method returns S_OK to indicate that the property page has changed. Otherwise, it returns S_FALSE.</returns>
		/// <remarks>
		/// <para>
		/// The property sheet uses this information to enable or disable the <c>Apply</c> button in the dialog box. There is no need to
		/// apply the values on a property page if those values are already current with the underlying objects.
		/// </para>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// This method has no reason to return an error code, since the inability to determine if the page is dirty should return S_OK
		/// as a default. In this way, the user has a chance to update the values. The page should not return an error code, since an
		/// error code is not the same as S_OK and would indicate that the page is not dirty. Then, the property frame could potentially
		/// disable the <c>Apply</c> button, not allowing the user to make sure that the property values are current.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ipropertypage-ispagedirty HRESULT IsPageDirty();
		[PreserveSig]
		new HRESULT IsPageDirty();

		/// <summary>
		/// Applies the current values to the underlying objects associated with the property page as previously passed to IPropertyPage::SetObjects.
		/// </summary>
		/// <returns>
		/// <para>
		/// This method can return the standard return values <c>E_OUTOFMEMORY</c> and <c>E_UNEXPECTED</c>, as well as the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Changes were successfully applied and the property page is current with the underlying objects.</term>
		/// </item>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>Changes were applied, but the property page cannot determine if its state is current with the objects.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The objects to be changed are provided through a previous call to IPropertyPage::SetObjects. By calling
		/// <c>IPropertyPage::SetObjects</c> prior to calling this method, the caller ensures that all underlying objects have the
		/// correct interfaces through which to communicate changes. Therefore, this method should not fail because of non-existent interfaces.
		/// </para>
		/// <para>
		/// After applying its values, the property page should determine if its state is now current with the objects in order to
		/// properly implement IPropertyPage::IsPageDirty and to provide both <c>S_OK</c> and <c>S_FALSE</c> return values.
		/// </para>
		/// <para>Notes to Implementers</para>
		/// <para>E_NOTIMPL is not a valid return value.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ipropertypage-apply HRESULT Apply();
		[PreserveSig]
		new HRESULT Apply();

		/// <summary>Invokes the property page help in response to an end-user request.</summary>
		/// <param name="pszHelpDir">
		/// A pointer to the string under the <c>HelpDir</c> key in the property page's CLSID information in the registry. If
		/// <c>HelpDir</c> does not exist, this will be the path found in the <c>InprocServer32</c> entry minus the server file name.
		/// (Note that <c>LocalServer32</c> is not checked, because local property pages are not supported).
		/// </param>
		/// <returns>
		/// <para>This method can return the standard return values E_OUTOFMEMORY and E_UNEXPECTED, as well as the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The page displayed its own help.</term>
		/// </item>
		/// <item>
		/// <term>E_NOTIMPL</term>
		/// <term>Help is either not provided or is provided only through the information is PROPPAGEINFO.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Notes to Callers</para>
		/// <para>Calls to this method must occur between calls to IPropertyPage::Activate and IPropertyPage::Deactivate.</para>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// If the page fails this method (such as E_NOTIMPL), then the frame will attempt to use the <c>pszHelpFile</c> and
		/// <c>dwHelpContext</c> members of the PROPPAGEINFO structure obtained through IPropertyPage::GetPageInfo. Therefore, the page
		/// should either implement <c>IPropertyPage::Help</c> or return help information through <c>IPropertyPage::GetPageInfo</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ipropertypage-help HRESULT Help( LPCOLESTR pszHelpDir );
		[PreserveSig]
		new HRESULT Help([MarshalAs(UnmanagedType.LPWStr)] string pszHelpDir);

		/// <summary>Passes a keystroke to the property page for processing.</summary>
		/// <param name="pMsg">A pointer to the MSG structure describing the keystroke to be processed.</param>
		/// <returns>
		/// <para>This method can return the standard return value E_UNEXPECTED, as well as the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The property page handles the accelerator.</term>
		/// </item>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>The property page handles accelerators, but this one was not useful to it.</term>
		/// </item>
		/// <item>
		/// <term>E_NOTIMPL</term>
		/// <term>The property page does not handle accelerators.</term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>The address in pMsg is not valid. For example, it may be NULL.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Notes to Callers</para>
		/// <para>Calls to this method must occur after a call to IPropertyPage::Activate and before the corresponding call to IPropertyPage::Deactivate.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ipropertypage-translateaccelerator HRESULT
		// TranslateAccelerator( MSG *pMsg );
		[PreserveSig]
		new HRESULT TranslateAccelerator(in MSG pMsg);

		/// <summary>Specifies which field is to receive the focus when the property page is activated.</summary>
		/// <param name="dispID">The property that is to receive the focus.</param>
		/// <returns>
		/// <para>This method can return the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method completed successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_NOTIMPL</term>
		/// <term>
		/// This method is not currently implemented; the interface is probably provided in anticipation of future work on this page.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// If this method is called before a page is activated, the page should store the property and set the focus to it in the next
		/// call to IPropertyPage::Activate. If the page is already active, <c>EditProperty</c> should set the focus to the specific
		/// property field.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ipropertypage2-editproperty HRESULT EditProperty( DISPID
		// dispID );
		[PreserveSig]
		HRESULT EditProperty(int dispID);
	}

	/// <summary>Provides the main features for a property page site object.</summary>
	/// <remarks>
	/// <para>
	/// For each property page created within a property frame, the frame creates a property page site to provide information to the
	/// property page and to receive notifications from the page when changes occur. This latter notification is used to initiate a call
	/// to IPropertyPage::IsPageDirty, the return value of which is then used to enable or disable the frame's <c>Apply</c> button.
	/// </para>
	/// <para>OLE Implementation</para>
	/// <para>
	/// The system provides an implementation of the <c>IPropertyPageSite</c> interface through the OleCreatePropertyFrame or
	/// OleCreatePropertyFrameIndirect functions. The frame implementation provided through these functions only implements the
	/// OnStatusChange and GetLocaleID methods. The GetPageContainer and TranslateAccelerator methods return E_NOTIMPL.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nn-ocidl-ipropertypagesite
	[PInvokeData("ocidl.h", MSDNShortId = "NN:ocidl.IPropertyPageSite")]
	[ComImport, Guid("B196B28C-BAB4-101A-B69C-00AA00341D07"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IPropertyPageSite
	{
		/// <summary>
		/// Informs the frame that the property page managed by this site has changed its state, that is, one or more property values
		/// have been changed in the page. Property pages should call this method whenever changes occur in their dialog boxes.
		/// </summary>
		/// <param name="dwFlags">
		/// <para>Indicates the changes that have occurred. This parameter can contain one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PROPPAGESTATUS_DIRTY 0x1</term>
		/// <term>The values in the pages have changed, so the state of the Apply button should be updated.</term>
		/// </item>
		/// <item>
		/// <term>PROPPAGESTATUS_VALIDATE 0x2</term>
		/// <term>Now is an appropriate time to apply changes.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>This method can return the standard return values E_INVALIDARG and S_OK.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ipropertypagesite-onstatuschange HRESULT OnStatusChange(
		// DWORD dwFlags );
		[PreserveSig]
		HRESULT OnStatusChange(PROPPAGESTATUS dwFlags);

		/// <summary>Retrieves the locale identifier (an LCID) that a property page can use to adjust its locale-specific settings.</summary>
		/// <param name="pLocaleID">
		/// A pointer to a variable that receives the locale identifier. See Language Identifier Constants and Strings.
		/// </param>
		/// <returns>
		/// <para>This method can return the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method completed successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>The address in pLocaleID is not valid. For example, it may be NULL.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ipropertypagesite-getlocaleid HRESULT GetLocaleID( LCID
		// *pLocaleID );
		[PreserveSig]
		HRESULT GetLocaleID(out LCID pLocaleID);

		/// <summary>
		/// <para>
		/// Retrieves a pointer to the object representing the entire property frame dialog box that contains all the pages. Calling
		/// this method could potentially allow one page to navigate to another.
		/// </para>
		/// <para>
		/// However, there are no container interfaces defined for this role, so this method always fails in the property frame implementation.
		/// </para>
		/// </summary>
		/// <param name="ppUnk">
		/// A pointer to an IUnknown pointer variable that receives the interface pointer to the container object. If an error occurs,
		/// the implementation must set *ppUnk to <c>NULL</c>.
		/// </param>
		/// <returns>This method returns E_NOTIMPL.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ipropertypagesite-getpagecontainer HRESULT
		// GetPageContainer( IUnknown **ppUnk );
		[PreserveSig]
		HRESULT GetPageContainer([MarshalAs(UnmanagedType.IUnknown)] out object? ppUnk);

		/// <summary>Passes a keystroke to the property frame for processing.</summary>
		/// <param name="pMsg">A pointer to the MSG structure to be processed.</param>
		/// <returns>
		/// <para>This method can return the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method completed successfully.</term>
		/// </item>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>The page site did not process the message.</term>
		/// </item>
		/// <item>
		/// <term>E_NOTIMPL</term>
		/// <term>The page site does not support keyboard processing.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ipropertypagesite-translateaccelerator HRESULT
		// TranslateAccelerator( MSG *pMsg );
		[PreserveSig]
		HRESULT TranslateAccelerator(in MSG pMsg);
	}

	/// <summary>Provides access to the type information for an object's coclass entry in its type library.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nn-ocidl-iprovideclassinfo
	[PInvokeData("ocidl.h", MSDNShortId = "NN:ocidl.IProvideClassInfo")]
	[ComImport, Guid("B196B283-BAB4-101A-B69C-00AA00341D07"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IProvideClassInfo
	{
		/// <summary>
		/// Retrieves a pointer to the ITypeInfo interface for the object's type information. The type information for an object
		/// corresponds to the object's coclass entry in a type library.
		/// </summary>
		/// <param name="ppTI">
		/// A pointer to an ITypeInfo pointer variable that receives the interface pointer to the object's type information. The caller
		/// is responsible for calling Release on the returned interface pointer if this method returns successfully.
		/// </param>
		/// <returns>
		/// <para>This method can return the standard return values E_OUTOFMEMORY and E_UNEXPECTED, as well as the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method completed successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>The address in ppTI is not valid. For example, it may be NULL.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// This method must call AddRef before returning. If the object loads the type information from a type library, the type
		/// library itself will call <c>AddRef</c> in creating the pointer.
		/// </para>
		/// <para>
		/// Because the caller cannot specify a locale identifier (LCID) when calling this method, this method must assume the neutral
		/// language, that is, LANGID_NEUTRAL, and use this value to determine what locale-specific type information to return.
		/// </para>
		/// <para>This method must be implemented; E_NOTIMPL is not an acceptable return value.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-iprovideclassinfo-getclassinfo HRESULT GetClassInfo(
		// ITypeInfo **ppTI );
		[PreserveSig]
		HRESULT GetClassInfo(out ITypeInfo ppTI);
	}

	/// <summary>
	/// An extension to IProvideClassInfo that makes is faster and easier to retrieve an object's outgoing interface IID for its default
	/// event set.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nn-ocidl-iprovideclassinfo2
	[PInvokeData("ocidl.h", MSDNShortId = "NN:ocidl.IProvideClassInfo2")]
	[ComImport, Guid("A6BC3AC0-DBAA-11CE-9DE3-00AA004BB851"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IProvideClassInfo2 : IProvideClassInfo
	{
		/// <summary>
		/// Retrieves a pointer to the ITypeInfo interface for the object's type information. The type information for an object
		/// corresponds to the object's coclass entry in a type library.
		/// </summary>
		/// <param name="ppTI">
		/// A pointer to an ITypeInfo pointer variable that receives the interface pointer to the object's type information. The caller
		/// is responsible for calling Release on the returned interface pointer if this method returns successfully.
		/// </param>
		/// <returns>
		/// <para>This method can return the standard return values E_OUTOFMEMORY and E_UNEXPECTED, as well as the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method completed successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>The address in ppTI is not valid. For example, it may be NULL.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// This method must call AddRef before returning. If the object loads the type information from a type library, the type
		/// library itself will call <c>AddRef</c> in creating the pointer.
		/// </para>
		/// <para>
		/// Because the caller cannot specify a locale identifier (LCID) when calling this method, this method must assume the neutral
		/// language, that is, LANGID_NEUTRAL, and use this value to determine what locale-specific type information to return.
		/// </para>
		/// <para>This method must be implemented; E_NOTIMPL is not an acceptable return value.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-iprovideclassinfo-getclassinfo HRESULT GetClassInfo(
		// ITypeInfo **ppTI );
		[PreserveSig]
		new HRESULT GetClassInfo(out ITypeInfo ppTI);

		/// <summary>Retrieves the specified GUID for the object.</summary>
		/// <param name="dwGuidKind">The GUID type. Possible values are from the GUIDKIND enumeration.</param>
		/// <param name="pGUID">A pointer to a variable that receives the GUID.</param>
		/// <returns>This method can return the standard return values E_INVALIDARG, E_UNEXPECTED, E_POINTER, and S_OK.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-iprovideclassinfo2-getguid HRESULT GetGUID( DWORD
		// dwGuidKind, GUID *pGUID );
		[PreserveSig]
		HRESULT GetGUID(GUIDKIND dwGuidKind, out Guid pGUID);
	}

	/// <summary>
	/// An extension to IProvideClassInfo2 that makes it faster and easier to retrieve type information from a component that may have
	/// multiple coclasses that determine its behavior.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nn-ocidl-iprovidemultipleclassinfo
	[PInvokeData("ocidl.h", MSDNShortId = "NN:ocidl.IProvideMultipleClassInfo")]
	[ComImport, Guid("A7ABA9C1-8983-11cf-8F20-00805F2CD064"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IProvideMultipleClassInfo : IProvideClassInfo2
	{
		/// <summary>
		/// Retrieves a pointer to the ITypeInfo interface for the object's type information. The type information for an object
		/// corresponds to the object's coclass entry in a type library.
		/// </summary>
		/// <param name="ppTI">
		/// A pointer to an ITypeInfo pointer variable that receives the interface pointer to the object's type information. The caller
		/// is responsible for calling Release on the returned interface pointer if this method returns successfully.
		/// </param>
		/// <returns>
		/// <para>This method can return the standard return values E_OUTOFMEMORY and E_UNEXPECTED, as well as the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method completed successfully.</term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>The address in ppTI is not valid. For example, it may be NULL.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// This method must call AddRef before returning. If the object loads the type information from a type library, the type
		/// library itself will call <c>AddRef</c> in creating the pointer.
		/// </para>
		/// <para>
		/// Because the caller cannot specify a locale identifier (LCID) when calling this method, this method must assume the neutral
		/// language, that is, LANGID_NEUTRAL, and use this value to determine what locale-specific type information to return.
		/// </para>
		/// <para>This method must be implemented; E_NOTIMPL is not an acceptable return value.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-iprovideclassinfo-getclassinfo HRESULT GetClassInfo(
		// ITypeInfo **ppTI );
		[PreserveSig]
		new HRESULT GetClassInfo(out ITypeInfo ppTI);

		/// <summary>Retrieves the specified GUID for the object.</summary>
		/// <param name="dwGuidKind">The GUID type. Possible values are from the GUIDKIND enumeration.</param>
		/// <param name="pGUID">A pointer to a variable that receives the GUID.</param>
		/// <returns>This method can return the standard return values E_INVALIDARG, E_UNEXPECTED, E_POINTER, and S_OK.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-iprovideclassinfo2-getguid HRESULT GetGUID( DWORD
		// dwGuidKind, GUID *pGUID );
		[PreserveSig]
		new HRESULT GetGUID(GUIDKIND dwGuidKind, out Guid pGUID);

		/// <summary>Retrieves the number of type information blocks that this object must provide.</summary>
		/// <param name="pcti">The number of type information blocks that this object must provide.</param>
		/// <returns>This method can return the standard return values E_INVALIDARG, E_POINTER, E_FAIL, and S_OK.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-iprovidemultipleclassinfo-getmultitypeinfocount HRESULT
		// GetMultiTypeInfoCount( ULONG *pcti );
		[PreserveSig]
		HRESULT GetMultiTypeInfoCount(out uint pcti);

		/// <summary>Retrieves the type information from the specified index.</summary>
		/// <param name="iti">
		/// The index of the type information for which you want to obtain information. Index 0 is the default interface of the extender
		/// object; index *pcti-1 is the index of the base object.
		/// </param>
		/// <param name="dwFlags">
		/// <para>
		/// A bitfield indicating which out parameters are being requested. Indicating a particular flag results in the appropriate
		/// information being assigned to the associated out parameter. This parameter can be one of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>MULTICLASSINFO_GETTYPEINFO 0x00000001</term>
		/// <term>Indicates a request for pptiCoClass information.</term>
		/// </item>
		/// <item>
		/// <term>MULTICLASSINFO_GETNUMRESERVEDDISPIDS 0x00000002</term>
		/// <term>Indicates a request for pcdispidReserved and pdwTIFlags information.</term>
		/// </item>
		/// <item>
		/// <term>MULTICLASSINFO_GETIIDPRIMARY 0x00000004</term>
		/// <term>Indicates a request for piidPrimary information.</term>
		/// </item>
		/// <item>
		/// <term>MULTICLASSINFO_GETIIDSOURCE 0x00000008</term>
		/// <term>Indicates a request for piidSource information.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pptiCoClass">The coclass type information for the requested contributor. See ITypeInfo.</param>
		/// <param name="pdwTIFlags">The bitfield flag.</param>
		/// <param name="pcdispidReserved">
		/// The mumber of DISPIDs the default interface of pptiCoClass reserves for its own use. This number can be used to calculate
		/// the amount to offset DISPIDs in the reserved range implemented by the object this class is extending.
		/// </param>
		/// <param name="piidPrimary">The IID of the primary interface for the requested contributor.</param>
		/// <param name="piidSource">The IID of the default source interface for the requested contributor.</param>
		/// <returns>This method can return the standard return values E_INVALIDARG, E_POINTER, E_FAIL, and S_OK.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-iprovidemultipleclassinfo-getinfoofindex HRESULT
		// GetInfoOfIndex( ULONG iti, DWORD dwFlags, ITypeInfo **pptiCoClass, DWORD *pdwTIFlags, ULONG *pcdispidReserved, IID
		// *piidPrimary, IID *piidSource );
		[PreserveSig]
		HRESULT GetInfoOfIndex(uint iti, MULTICLASSINFO dwFlags, out ITypeInfo pptiCoClass, out uint pdwTIFlags, out uint pcdispidReserved, out Guid piidPrimary, out Guid piidSource);
	}

	/// <summary>
	/// Enables controls and containers to avoid performance bottlenecks on loading controls. It combines the load-time or
	/// initialization-time handshaking between the control and its container into a single call.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nn-ocidl-iquickactivate
	[PInvokeData("ocidl.h", MSDNShortId = "NN:ocidl.IQuickActivate")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("CF51ED10-62FE-11CF-BF86-00A0C9034836")]
	public interface IQuickActivate
	{
		/// <summary>Quick activates a control.</summary>
		/// <param name="pQaContainer">A pointer to the QACONTAINER structure containing information about the container.</param>
		/// <param name="pQaControl">
		/// A pointer to the QACONTROL structure filled in by the control to return information about the control to the container. The
		/// container calling this method must reserve memory for this structure.
		/// </param>
		/// <returns>If the method succeeds, the return value is S_OK. Otherwise, it is E_FAIL.</returns>
		/// <remarks>
		/// <para>
		/// If the control does not support IQuickActivate, the container performs certain handshaking operations when it loads the
		/// control. The container calls certain interfaces on the control and the control, in turn, calls back to certain interfaces on
		/// the container's client site. First, the container creates the control object and calls QueryInterface to query for
		/// interfaces that it needs. Then, the container calls IOleObject::SetClientSite on the control, passing a pointer to its
		/// client site. Next, the control calls <c>QueryInterface</c> on this site, retrieving a pointer to additional necessary interfaces.
		/// </para>
		/// <para>
		/// Using the <c>QuickActivate</c> method, the container passes a pointer to a QACONTAINER structure. The structure contains
		/// pointers to interfaces which are needed by the control and the values of some ambient properties that the control may need.
		/// Upon return, the control passes a pointer to a QACONTROL structure that contains pointers to its own interfaces that the
		/// container requires, and additional status information.
		/// </para>
		/// <para>
		/// The <c>IPersist*::Load</c> and <c>IPersist*::InitNew</c> methods should be called after quick activation occurs. The control
		/// should establish its connections to the container's sinks during quick activation. However, these connections are not live
		/// until <c>IPersist*::Load</c> or <c>IPersist*::InitNew</c> has been called.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-iquickactivate-quickactivate HRESULT QuickActivate(
		// QACONTAINER *pQaContainer, QACONTROL *pQaControl );
		[PreserveSig]
		HRESULT QuickActivate(in QACONTAINER pQaContainer, ref QACONTROL pQaControl);

		/// <summary>Sets the content extent of a control.</summary>
		/// <param name="pSizel">The size of the content extent.</param>
		/// <returns>If the method succeeds, the return value is S_OK. Otherwise, it is E_FAIL.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-iquickactivate-setcontentextent HRESULT SetContentExtent(
		// LPSIZEL pSizel );
		[PreserveSig]
		HRESULT SetContentExtent(in SIZE pSizel);

		/// <summary>Gets the content extent of a control.</summary>
		/// <param name="pSizel">A pointer to a structure that contains size of the content extent.</param>
		/// <returns>If the method succeeds, the return value is S_OK. Otherwise, it is E_FAIL.</returns>
		/// <remarks>
		/// <para>The <c>SIZEL</c> structure is defined in Wtypes.h as follows.</para>
		/// <para>
		/// <code>typedef struct tagSIZEL { LONG cx; LONG cy; } SIZEL; typedef struct tagSIZEL *PSIZEL; typedef struct tagSIZEL *LPSIZEL;</code>
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-iquickactivate-getcontentextent HRESULT GetContentExtent(
		// LPSIZEL pSizel );
		[PreserveSig]
		HRESULT GetContentExtent(out SIZE pSizel);
	}

	/// <summary>
	/// <para>
	/// Provides simple frame controls that act as simple containers for other nested controls. Some controls merely contain other
	/// controls. In such cases, the simple control container, called a simple frame, need not implement all container requirements. It
	/// can delegate most of the interface calls from its contained controls to the outer container that manages the simple frame. To
	/// support what are called simple frame controls, a container implements this interface as well as other site interfaces such as IOleControlSite.
	/// </para>
	/// <para>
	/// An example of a simple frame control is a group box that only needs to capture a few keystrokes for its contained controls to
	/// implement the correct tab or arrow key behavior, but does not want to handle every other message. Through the two methods of
	/// this interface, the simple frame control passes messages to its control site both before and after its own processing. If that
	/// site is itself a simple frame, it can continue to pass messages up the chain.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nn-ocidl-isimpleframesite
	[PInvokeData("ocidl.h", MSDNShortId = "NN:ocidl.ISimpleFrameSite")]
	[ComImport, Guid("742B0E01-14E6-101B-914E-00AA00300CAB"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ISimpleFrameSite
	{
		/// <summary>
		/// Provides a site with the opportunity to process a message that is received by a control's own window before the control
		/// itself does any processing.
		/// </summary>
		/// <param name="hWnd">A handle of the control window receiving the message.</param>
		/// <param name="msg">The message received by the simple frame site.</param>
		/// <param name="wp">The <c>WPARAM</c> of the message.</param>
		/// <param name="lp">The <c>LPARAM</c> of the message.</param>
		/// <param name="plResult">A pointer to the variable that receives the result of the message processing.</param>
		/// <param name="pdwCookie">
		/// A pointer to the variable that will be passed to ISimpleFrameSite::PostMessageFilter if it is called later. This parameter
		/// should only contain allocated data if this method returns S_OK so it will also receive a call to <c>PostMessageFilter</c>
		/// which can free the allocation. The caller is not in any way responsible for anything returned in this parameter.
		/// </param>
		/// <returns>
		/// <para>This method can return the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The simple frame site will not use the message in this filter so more processing can take place.</term>
		/// </item>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>The site has processed the message and no further processing should occur.</term>
		/// </item>
		/// <item>
		/// <term>E_NOTIMPL</term>
		/// <term>The site does not do any message filtering, indicating that PostMessageFilter need not be called later.</term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>The address in plResult or pdwCookie is not valid.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// Successful return values indicate whether the site wishes to allow further processing. S_OK indicates further processing,
		/// whereas S_FALSE means do not process further. S_OK also indicates that the control must later call PostMessageFilter.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-isimpleframesite-premessagefilter HRESULT PreMessageFilter(
		// HWND hWnd, UINT msg, WPARAM wp, LPARAM lp, LRESULT *plResult, DWORD *pdwCookie );
		[PreserveSig]
		HRESULT PreMessageFilter(HWND hWnd, uint msg, IntPtr wp, IntPtr lp, out IntPtr plResult, out uint pdwCookie);

		/// <summary>
		/// Sends the simple frame site a message that is received by a control's own window after the control has processed the message.
		/// </summary>
		/// <param name="hWnd">A handle of the control window receiving the message.</param>
		/// <param name="msg">The message received by the simple frame site.</param>
		/// <param name="wp">The <c>WPARAM</c> of the message.</param>
		/// <param name="lp">The <c>LPARAM</c> of the message.</param>
		/// <param name="plResult">A pointer to the variable that receives the result of the message processing.</param>
		/// <param name="dwCookie">The value that was returned by ISimpleFrameSite::PreMessageFilter through its pdwCookie parameter.</param>
		/// <returns>
		/// <para>This method can return the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The site processed the message.</term>
		/// </item>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>The site did not process the message.</term>
		/// </item>
		/// <item>
		/// <term>E_NOTIMPL</term>
		/// <term>The site does not filter any messages.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-isimpleframesite-postmessagefilter HRESULT
		// PostMessageFilter( HWND hWnd, UINT msg, WPARAM wp, LPARAM lp, LRESULT *plResult, DWORD dwCookie );
		[PreserveSig]
		HRESULT PostMessageFilter(HWND hWnd, uint msg, IntPtr wp, IntPtr lp, out IntPtr plResult, uint dwCookie);
	}

	/// <summary>
	/// Indicates that an object supports property pages. OLE property pages enable an object to display its properties in a tabbed
	/// dialog box known as a property sheet. An end user can then view and change the object's properties. An object can display its
	/// property pages independent of its client, or the client can manage the display of property pages from a number of contained
	/// objects in a single property sheet. Property pages also provide a means for notifying a client of changes in an object's properties.
	/// </summary>
	/// <remarks>
	/// <para>
	/// A property page object manages a particular page within a property sheet. A property page implements at least IPropertyPage and
	/// can optionally implement IPropertyPage2 if selection of a specific property is supported.
	/// </para>
	/// <para>
	/// An object specifies its support for property pages by implementing <c>ISpecifyPropertyPages</c>. Through this interface the
	/// caller can obtain a list of CLSIDs identifying the specific property pages that the object supports. If the object specifies a
	/// property page CLSID, the object must be able to receive property changes from the property page.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nn-ocidl-ispecifypropertypages
	[PInvokeData("ocidl.h", MSDNShortId = "NN:ocidl.ISpecifyPropertyPages")]
	[ComImport, Guid("B196B28B-BAB4-101A-B69C-00AA00341D07"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ISpecifyPropertyPages
	{
		/// <summary>Retrieves a list of property pages that can be displayed in this object's property sheet.</summary>
		/// <param name="pPages">
		/// A pointer to a caller-allocated CAUUID structure that must be initialized and filled before returning. The <c>pElems</c>
		/// member in the structure is allocated by the callee with CoTaskMemAlloc and freed by the caller with CoTaskMemFree.
		/// </param>
		/// <returns>
		/// <para>This method can return the standard return values E_OUTOFMEMORY and E_UNEXPECTED, as well as the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>The method completed succesfully.</term>
		/// </item>
		/// <item>
		/// <term>E_POINTER</term>
		/// <term>The address in pPages is not valid. For example, it may be NULL.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The CAUUID structure is caller-allocated, but is not initialized by the caller. The <c>GetPages</c> method fills the
		/// <c>cElements</c> member in the structure. This method also allocates memory for the array pointed to by the <c>pElems</c>
		/// member using CoTaskMemAlloc. Then, it fills the newly allocated array. After this method returns successfully, the structure
		/// contains a counted array of UUIDs, each UUID specifying a property page CLSID.
		/// </para>
		/// <para>Notes to Callers</para>
		/// <para>
		/// The caller must release the memory pointed to by the <c>pElems</c> member of CAUUID, using CoTaskMemFree when it is no
		/// longer needed.
		/// </para>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// E_NOTIMPL is not allowed as a return value, because an object with no property pages should not expose the
		/// ISpecifyPropertyPages interface.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-ispecifypropertypages-getpages HRESULT GetPages( CAUUID
		// *pPages );
		[PreserveSig]
		HRESULT GetPages(out CAUUID pPages);
	}

	/// <summary>
	/// <para>An extension derived from IViewObject2 to provide support for:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>Enhanced, flicker-free drawing for non-rectangular objects and transparent objects</term>
	/// </item>
	/// <item>
	/// <term>Hit testing for non-rectangular objects</term>
	/// </item>
	/// <item>
	/// <term>Control sizing</term>
	/// </item>
	/// </list>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nn-ocidl-iviewobjectex
	[PInvokeData("ocidl.h", MSDNShortId = "NN:ocidl.IViewObjectEx")]
	[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("3AF24292-0C96-11CE-A0CF-00AA00600AB8")]
	public interface IViewObjectEx : IViewObject2
	{
		/// <summary>Draws a representation of an object onto the specified device context.</summary>
		/// <param name="dwDrawAspect">
		/// Specifies the aspect to be drawn, that is, how the object is to be represented. Representations include content, an icon, a
		/// thumbnail, or a printed document. Valid values are taken from the enumerations DVASPECT and DVASPECT2. Note that newer
		/// objects and containers that support optimized drawing interfaces support the <c>DVASPECT2</c> enumeration values. Older
		/// objects and containers that do not support optimized drawing interfaces may not support <c>DVASPECT2</c>. Windowless objects
		/// allow only <c>DVASPECT</c> _CONTENT, <c>DVASPECT</c> _OPAQUE, and <c>DVASPECT</c> _TRANSPARENT.
		/// </param>
		/// <param name="lindex">
		/// Portion of the object that is of interest for the draw operation. Its interpretation varies depending on the value in the
		/// dwAspect parameter. See the DVASPECT enumeration for more information.
		/// </param>
		/// <param name="pvAspect">
		/// Pointer to additional information in a DVASPECTINFO structure that enables drawing optimizations depending on the aspect
		/// specified. Note that newer objects and containers that support optimized drawing interfaces support this parameter as well.
		/// Older objects and containers that do not support optimized drawing interfaces always specify <c>NULL</c> for this parameter.
		/// </param>
		/// <param name="ptd">
		/// Pointer to the DVTARGETDEVICE structure that describes the device for which the object is to be rendered. If <c>NULL</c>,
		/// the view should be rendered for the default target device (typically the display). A value other than <c>NULL</c> is
		/// interpreted in conjunction with hdcTargetDev and hdcDraw. For example, if hdcDraw specifies a printer as the device context,
		/// the ptd parameter points to a structure describing that printer device. The data may actually be printed if hdcTargetDev is
		/// a valid value or it may be displayed in print preview mode if hdcTargetDev is <c>NULL</c>.
		/// </param>
		/// <param name="hdcTargetDev">
		/// Information context for the target device indicated by the ptd parameter from which the object can extract device metrics
		/// and test the device's capabilities. If ptd is <c>NULL</c>; the object should ignore the value in the hdcTargetDev parameter.
		/// </param>
		/// <param name="hdcDraw">
		/// Device context on which to draw. For a windowless object, the hdcDraw parameter should be in MM_TEXT mapping mode with its
		/// logical coordinates matching the client coordinates of the containing window. For a windowless object, the device context
		/// should be in the same state as the one normally passed by a WM_PAINT message.
		/// </param>
		/// <param name="lprcBounds">
		/// Pointer to a RECTL structure specifying the rectangle on hdcDraw and in which the object should be drawn. This parameter
		/// controls the positioning and stretching of the object. This parameter should be <c>NULL</c> to draw a windowless in-place
		/// active object. In every other situation, <c>NULL</c> is not a legal value and should result in an E_INVALIDARG error code.
		/// If the container passes a non- <c>NULL</c> value to a windowless object, the object should render the requested aspect into
		/// the specified device context and rectangle. A container can request this from a windowless object to render a second,
		/// non-active view of the object or to print the object.
		/// </param>
		/// <param name="lprcWBounds">
		/// <para>
		/// If hdcDraw is a metafile device context, pointer to a RECTL structure specifying the bounding rectangle in the underlying
		/// metafile. The rectangle structure contains the window extent and window origin. These values are useful for drawing
		/// metafiles. The rectangle indicated by lprcBounds is nested inside this lprcWBounds rectangle; they are in the same
		/// coordinate space.
		/// </para>
		/// <para>If hdcDraw is not a metafile device context; lprcWBounds will be <c>NULL</c>.</para>
		/// </param>
		/// <param name="pfnContinue">
		/// <para>
		/// Pointer to a callback function that the view object should call periodically during a lengthy drawing operation to determine
		/// whether the operation should continue or be canceled. This function returns <c>TRUE</c> to continue drawing. It returns
		/// <c>FALSE</c> to stop the drawing in which case <c>IViewObject::Draw</c> returns DRAW_E_ABORT.
		/// </para>
		/// <para>dwContinue</para>
		/// </param>
		/// <param name="dwContinue">
		/// Value to pass as a parameter to the function pointed to by the pfnContinue parameter. Typically, dwContinue is a pointer to
		/// an application-defined structure needed inside the callback function.
		/// </param>
		/// <returns>
		/// <para>This method returns S_OK on success. Other possible return values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>OLE_E_BLANK</term>
		/// <term>No data to draw from.</term>
		/// </item>
		/// <item>
		/// <term>DRAW_E_ABORT</term>
		/// <term>Draw operation aborted.</term>
		/// </item>
		/// <item>
		/// <term>VIEW_E_DRAW</term>
		/// <term>Error in drawing.</term>
		/// </item>
		/// <item>
		/// <term>DV_E_LINDEX</term>
		/// <term>Invalid value for lindex; currently only -1 is supported.</term>
		/// </item>
		/// <item>
		/// <term>DV_E_DVASPECT</term>
		/// <term>Invalid value for dwAspect.</term>
		/// </item>
		/// <item>
		/// <term>OLE_E_INVALIDRECT</term>
		/// <term>Invalid rectangle.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A container application issues a call to <c>IViewObject::Draw</c> to create a representation of a contained object. This
		/// method draws the specified piece (lindex) of the specified view (dwAspect and pvAspect) on the specified device context
		/// (hdcDraw). Formatting, fonts, and other rendering decisions are made on the basis of the target device specified by the ptd parameter.
		/// </para>
		/// <para>
		/// There is a relationship between the dwDrawAspect value and the lprcbounds value. The lprcbounds value specifies the
		/// rectangle on hdcDraw into which the drawing is to be mapped. For DVASPECT_THUMBNAIL, <c>DVASPECT</c> _ICON, and
		/// <c>DVASPECT</c> _SMALLICON, the object draws whatever it wants to draw, and it maps it into the space given in the best way.
		/// Some objects might scale to fit while some might scale to fit but preserve the aspect ratio. In addition, some might scale
		/// so the drawing appears at full width, but the bottom is cropped. The container can suggest a size via IOleObject::SetExtent,
		/// but it has no control over the rendering size. In the case of <c>DVASPECT</c> _CONTENT, the <c>IViewObject::Draw</c>
		/// implementation should either use the extents given by <c>IOleObject::SetExtent</c> or use the bounding rectangle given in
		/// the lprcBounds parameter.
		/// </para>
		/// <para>
		/// For newer objects that support optimized drawing techniques and for windowless objects, this method should be used as follows:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>New drawing aspects are supported in dwAspect as defined in DVASPECT2.</term>
		/// </item>
		/// <item>
		/// <term>
		/// The pvAspect parameter can be used to pass additional information allowing drawing optimizations through the DVASPECTINFO structure.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// The <c>IViewObject::Draw</c> method can be called to redraw a windowless in-place active object by setting the lrpcBounds
		/// parameter to <c>NULL</c>. In every other situation, <c>NULL</c> is an illegal value and should result in an E_INVALIDARG
		/// error code. A windowless object uses the rectangle passed by the activation verb or calls IOleInPlaceObject::SetObjectRects
		/// instead of using this parameter. If the container passes a non- <c>NULL</c> value to a windowless object, the object should
		/// render the requested aspect into the specified device context and rectangle. A container can request this from a windowless
		/// object to render a second, non-active view of the object or to print the object. See the IOleInPlaceSiteWindowless interface
		/// for more information on drawing windowless objects.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// For windowless objects, the dwAspect parameter only allows the DVASPECT_CONTENT, <c>DVASPECT</c> _OPAQUE, and
		/// <c>DVASPECT</c> _TRANSPARENT aspects.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// For a windowless object, the hdcDraw parameter should be in MM_TEXT mapping mode with its logical coordinates matching the
		/// client coordinates of the containing window. For a windowless object, the device context should be in the same state as the
		/// one normally passed by a WM_PAINT message.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// To maintain compatibility with older objects and containers that do not support drawing optimizations, all objects,
		/// rectangular or not, are required to maintain an origin and a rectangular extent. This allows the container to still consider
		/// all its embedded objects as rectangles and to pass them appropriate rendering rectangles in <c>Draw</c>.
		/// </para>
		/// <para>
		/// An object's extent depends on the drawing aspect. For non-rectangular objects, the extent should be the size of a rectangle
		/// covering the entire aspect. By convention, the origin of an object is the top-left corner of the rectangle of the
		/// DVASPECT_CONTENT aspect. In other words, the origin always coincides with the top-left corner of the rectangle maintained by
		/// the object's site, even for a non-rectangular object.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-iviewobject-draw HRESULT Draw( DWORD dwDrawAspect, LONG
		// lindex, void *pvAspect, DVTARGETDEVICE *ptd, HDC hdcTargetDev, HDC hdcDraw, LPCRECTL lprcBounds, LPCRECTL lprcWBounds, BOOL(*
		// )(ULONG_PTR dwContinue) pfnContinue, ULONG_PTR dwContinue );
		new HRESULT Draw(DVASPECT dwDrawAspect, int lindex, [In, Optional] DVASPECTINFO? pvAspect, [In, Optional] DVTARGETDEVICE? ptd,
			[In, Optional] HDC hdcTargetDev, [In] HDC hdcDraw, [In, Optional] PRECT? lprcBounds, [In, Optional] PRECT? lprcWBounds,
			[In, Optional, MarshalAs(UnmanagedType.FunctionPtr)] Func<IntPtr, BOOL>? pfnContinue, [In, Optional] IntPtr dwContinue);

		/// <summary>
		/// Returns the logical palette that the object will use for drawing in its IViewObject::Draw method with the corresponding parameters.
		/// </summary>
		/// <param name="dwDrawAspect">
		/// Specifies how the object is to be represented. Representations include content, an icon, a thumbnail, or a printed document.
		/// Valid values are taken from the enumeration DVASPECT. See the <c>DVASPECT</c> enumeration for more information.
		/// </param>
		/// <param name="lindex">
		/// Portion of the object that is of interest for the draw operation. Its interpretation varies with dwDrawAspect. See the
		/// DVASPECT enumeration for more information.
		/// </param>
		/// <param name="pvAspect">
		/// Pointer to additional information about the view of the object specified in dwDrawAspect. Since none of the current aspects
		/// support additional information, pvAspect must always be <c>NULL</c>.
		/// </param>
		/// <param name="ptd">
		/// Pointer to the DVTARGETDEVICE structure that describes the device for which the object is to be rendered. If <c>NULL</c>,
		/// the view should be rendered for the default target device (typically the display). A value other than <c>NULL</c> is
		/// interpreted in conjunction with hicTargetDev and hdcDraw. For example, if hdcDraw specifies a printer as the device context,
		/// ptd points to a structure describing that printer device. The data may actually be printed if hicTargetDev is a valid value
		/// or it may be displayed in print preview mode if hicTargetDev is <c>NULL</c>.
		/// </param>
		/// <param name="hicTargetDev">
		/// Information context for the target device indicated by the ptd parameter from which the object can extract device metrics
		/// and test the device's capabilities. If ptd is <c>NULL</c>, the object should ignore the hicTargetDev parameter.
		/// </param>
		/// <param name="ppColorSet">
		/// Address of LOGPALETTE pointer variable that receives a pointer to the LOGPALETTE structure. The LOGPALETTE structure
		/// contains the set of colors that would be used if IViewObject::Draw were called with the same parameters for dwAspect,
		/// lindex, pvAspect, ptd, and hicTargetDev. If ppColorSet is <c>NULL</c>, the object does not use a palette.
		/// </param>
		/// <returns>
		/// <para>This method returns S_OK on success. Other possible return values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>Set of colors is empty or the object will not give out the information.</term>
		/// </item>
		/// <item>
		/// <term>OLE_E_BLANK</term>
		/// <term>No presentation data for object.</term>
		/// </item>
		/// <item>
		/// <term>DV_E_LINDEX</term>
		/// <term>Invalid value for lindex; currently only -1 is supported.</term>
		/// </item>
		/// <item>
		/// <term>DV_E_DVASPECT</term>
		/// <term>Invalid value for dwAspect.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One or more of the supplied parameter values is invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>Insufficient memory available for this operation.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>IViewObject::GetColorSet</c> method recursively queries any nested objects and returns a color set that represents
		/// the union of all colors requested. The color set eventually percolates to the top-level container that owns the window
		/// frame. This container can call <c>IViewObject::GetColorSet</c> on each of its embedded objects to obtain all the colors
		/// needed to draw the embedded objects. The container can use the color sets obtained in conjunction with other colors it needs
		/// for itself to set the overall color palette.
		/// </para>
		/// <para>
		/// The OLE-provided implementation of <c>IViewObject::GetColorSet</c> looks at the data it has on hand to draw the picture. If
		/// CF_DIB is the drawing format, the palette found in the bitmap is used. For a regular bitmap, no color information is
		/// returned. If the drawing format is a metafile, the object handler enumerates the metafile looking for a CreatePalette
		/// metafile record. If one is found, the handler uses it as the color set.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-iviewobject-getcolorset HRESULT GetColorSet( DWORD
		// dwDrawAspect, LONG lindex, void *pvAspect, DVTARGETDEVICE *ptd, HDC hicTargetDev, LOGPALETTE **ppColorSet );
		new HRESULT GetColorSet(DVASPECT dwDrawAspect, int lindex, [In, Optional] DVASPECTINFO? pvAspect, [In, Optional] DVTARGETDEVICE? ptd,
			[In, Optional] HDC hicTargetDev, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(VanaraCustomMarshaler<LOGPALETTE>))] out LOGPALETTE ppColorSet);

		/// <summary>
		/// Freezes the drawn representation of an object so that it will not change until the IViewObject::Unfreeze method is called.
		/// The most common use of this method is for banded printing.
		/// </summary>
		/// <param name="dwDrawAspect">
		/// Specifies how the object is to be represented. Representations include content, an icon, a thumbnail, or a printed document.
		/// Valid values are taken from the enumeration DVASPECT. See the <c>DVASPECT</c> enumeration for more information.
		/// </param>
		/// <param name="lindex">
		/// Portion of the object that is of interest for the draw operation. Its interpretation varies with dwAspect. See the DVASPECT
		/// enumeration for more information.
		/// </param>
		/// <param name="pvAspect">
		/// Pointer to additional information about the view of the object specified in dwAspect. Since none of the current aspects
		/// support additional information, pvAspect must always be <c>NULL</c>.
		/// </param>
		/// <param name="pdwFreeze">
		/// Pointer to where an identifying DWORD key is returned. This unique key is later used to cancel the freeze by calling
		/// IViewObject::Unfreeze. This key is an index that the default cache uses to keep track of which object is frozen.
		/// </param>
		/// <returns>
		/// <para>This method returns S_OK on success. Other possible return values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>VIEW_S_ALREADY_FROZEN</term>
		/// <term>Presentation has already been frozen. The value of pdwFreeze is the identifying key of the already frozen object.</term>
		/// </item>
		/// <item>
		/// <term>OLE_E_BLANK</term>
		/// <term>Presentation not in cache.</term>
		/// </item>
		/// <item>
		/// <term>DV_E_LINDEX</term>
		/// <term>Invalid value for lindex; currently; only -1 is supported.</term>
		/// </item>
		/// <item>
		/// <term>DV_E_DVASPECT</term>
		/// <term>Invalid value for dwAspect.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>IViewObject::Freeze</c> method causes the view object to freeze its drawn representation until a subsequent call to
		/// IViewObject::Unfreeze releases it. After calling <c>IViewObject::Freeze</c>, successive calls to IViewObject::Draw with the
		/// same parameters produce the same picture until <c>IViewObject::Unfreeze</c> is called.
		/// </para>
		/// <para>
		/// <c>IViewObject::Freeze</c> is not part of the persistent state of the object and does not continue across unloads and
		/// reloads of the object.
		/// </para>
		/// <para>The most common use of this method is for banded printing.</para>
		/// <para>
		/// While in a frozen state, view notifications are not sent. Pending view notifications are deferred to the subsequent call to IViewObject::Unfreeze.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-iviewobject-freeze HRESULT Freeze( DWORD dwDrawAspect,
		// LONG lindex, void *pvAspect, DWORD *pdwFreeze );
		new HRESULT Freeze(DVASPECT dwDrawAspect, int lindex, [In, Optional] DVASPECTINFO? pvAspect, out uint pdwFreeze);

		/// <summary>
		/// Releases a drawing that was previously frozen using IViewObject::Freeze. The most common use of this method is for banded printing.
		/// </summary>
		/// <param name="dwFreeze">
		/// Contains a key previously returned from IViewObject::Freeze that determines which view object to unfreeze.
		/// </param>
		/// <returns>
		/// <para>This method returns S_OK on success. Other possible return values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>OLE_E_NOCONNECTION</term>
		/// <term>Error in the unfreezing process or the object is currently not frozen.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-iviewobject-unfreeze HRESULT Unfreeze( DWORD dwFreeze );
		new HRESULT Unfreeze(uint dwFreeze);

		/// <summary>
		/// Establishes a connection between the view object and an advise sink so that the advise sink can be notified about changes in
		/// the object's view.
		/// </summary>
		/// <param name="aspects">
		/// View for which the advisory connection is being set up. Valid values are taken from the enumeration DVASPECT. See the
		/// <c>DVASPECT</c> enumeration for more information.
		/// </param>
		/// <param name="advf">
		/// <para>
		/// Contains a group of flags for controlling the advisory connection. Valid values are from the enumeration ADVF. However, only
		/// some of the possible <c>ADVF</c> values are relevant for this method. The following table briefly describes the relevant
		/// values. See the <c>ADVF</c> enumeration for a more detailed description.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>ADVF_ONLYONCE</term>
		/// <term>Causes the advisory connection to be destroyed after the first notification is sent.</term>
		/// </item>
		/// <item>
		/// <term>ADVF_PRIMEFIRST</term>
		/// <term>Causes an initial notification to be sent regardless of whether data has changed from its current state.</term>
		/// </item>
		/// </list>
		/// <para><c>Note</c> The ADVF_ONLYONCE and ADVF_PRIMEFIRST can be combined to provide an asynchronous call to IDataObject::GetData.</para>
		/// </param>
		/// <param name="pAdvSink">
		/// Pointer to the IAdviseSink interface on the advisory sink that is to be informed of changes. A <c>NULL</c> value deletes any
		/// existing advisory connection.
		/// </param>
		/// <returns>
		/// <para>This method returns S_OK on success. Other possible return values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>OLE_E_ADVISENOTSUPPORTED</term>
		/// <term>Advisory notifications are not supported.</term>
		/// </item>
		/// <item>
		/// <term>DV_E_DVASPECT</term>
		/// <term>Invalid value for dwAspect.</term>
		/// </item>
		/// <item>
		/// <term>E_INVALIDARG</term>
		/// <term>One or more of the supplied values is invalid.</term>
		/// </item>
		/// <item>
		/// <term>E_OUTOFMEMORY</term>
		/// <term>Insufficient memory available for this operation.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// A container application that is requesting a draw operation on a view object can also register with the
		/// <c>IViewObject::SetAdvise</c> method to be notified when the presentation of the view object changes. To find out about when
		/// an object's underlying data changes, you must call IDataObject::DAdvise separately.
		/// </para>
		/// <para>To remove an existing advisory connection, call the <c>IViewObject::SetAdvise</c> method with pAdvSink set to <c>NULL</c>.</para>
		/// <para>If the view object changes, a call is made to the appropriate advise sink through its IAdviseSink::OnViewChange method.</para>
		/// <para>
		/// At any time, a given view object can support only one advisory connection. Therefore, when <c>IViewObject::SetAdvise</c> is
		/// called and the view object is already holding on to an advise sink pointer, OLE releases the existing pointer before the new
		/// one is registered.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-iviewobject-setadvise HRESULT SetAdvise( DWORD aspects,
		// DWORD advf, IAdviseSink *pAdvSink );
		new HRESULT SetAdvise(DVASPECT aspects, ADVF advf, [In, Optional] IAdviseSink? pAdvSink);

		/// <summary>Retrieves the advisory connection on the object that was used in the most recent call to IViewObject::SetAdvise.</summary>
		/// <param name="pAspects">
		/// Pointer to where the dwAspect parameter from the previous IViewObject::SetAdvise call is returned. If this pointer is
		/// <c>NULL</c>, the caller does not permit this value to be returned.
		/// </param>
		/// <param name="pAdvf">
		/// Pointer to where the advf parameter from the previous IViewObject::SetAdvise call is returned. If this pointer is
		/// <c>NULL</c>, the caller does not permit this value to be returned.
		/// </param>
		/// <param name="ppAdvSink">
		/// Address of IAdviseSink pointer variable that receives the interface pointer to the advise sink. The connection to this
		/// advise sink must have been established with a previous IViewObject::SetAdvise call, which provides the pAdvSink parameter.
		/// If ppvAdvSink is <c>NULL</c>, there is no established advisory connection.
		/// </param>
		/// <returns>This method returns S_OK on success.</returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-iviewobject-getadvise HRESULT GetAdvise( DWORD *pAspects,
		// DWORD *pAdvf, IAdviseSink **ppAdvSink );
		new unsafe HRESULT GetAdvise([Out, Optional] DVASPECT* pAspects, [Out, Optional] ADVF* pAdvf, [Out, Optional] IntPtr ppAdvSink);

		/// <summary>Retrieves the size that the specified view object will be drawn on the specified target device.</summary>
		/// <param name="dwDrawAspect">
		/// Requested view of the object whose size is of interest. Possible values are taken from the DVASPECT and DVASPECT2
		/// enumerations. Note that newer objects and containers that support optimized drawing interfaces support the <c>DVASPECT2</c>
		/// enumeration values. Older objects and containers that do not support optimized drawing interfaces may not support <c>DVASPECT2</c>.
		/// </param>
		/// <param name="lindex">The portion of the object that is of interest. Currently, the only possible value is -1.</param>
		/// <param name="ptd">
		/// A pointer to the DVTARGETDEVICE structure defining the target device for which the object's size should be returned.
		/// </param>
		/// <param name="lpsizel">A pointer to where the object's size is returned.</param>
		/// <returns>
		/// <para>This method returns S_OK on success. Other possible return values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>OLE_E_BLANK</term>
		/// <term>An appropriate cache is not available.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>The OLE-provided implementation of <c>IViewObject2::GetExtent</c> searches the cache for the size of the view object.</para>
		/// <para>The IOleObject::GetExtent method in the IOleObject interface provides some of the same information as <c>IViewObject2::GetExtent</c>.</para>
		/// <para>
		/// This method must return the same size as DVASPECT_CONTENT for all the new aspects in DVASPECT2. IOleObject::GetExtent must
		/// do the same thing.
		/// </para>
		/// <para>
		/// If one of the new aspects is requested in dwAspect, this method can either fail or return the same rectangle as for the
		/// DVASPECT_CONTENT aspect.
		/// </para>
		/// <para>Notes to Callers</para>
		/// <para>
		/// To prevent the object from being run if it isn't already running, you can call <c>IViewObject2::GetExtent</c> rather than
		/// IOleObject::GetExtent to determine the size of the presentation to be drawn.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-iviewobject2-getextent
		// HRESULT GetExtent( DWORD dwDrawAspect, LONG lindex, DVTARGETDEVICE *ptd, LPSIZEL lpsizel );
		new HRESULT GetExtent(uint dwDrawAspect, int lindex, [In] DVTARGETDEVICE ptd, out SIZE lpsizel);

		/// <summary>Retrieves a rectangle describing a requested drawing aspect.</summary>
		/// <param name="dwAspect">The drawing aspect requested.</param>
		/// <param name="pRect">A pointer to the rectangle describing the requested drawing aspect.</param>
		/// <returns>
		/// <para>This method returns S_OK on success. Other possible return values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>DV_E_DVASPECT</term>
		/// <term>
		/// The method does not support the specified aspect. Either the object does not support the aspect requested or the aspect is
		/// not rectangular.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// This method returns a rectangle describing the specified drawing aspect. The returned rectangle is in <c>HIMETRIC</c> units,
		/// relative to the object's origin. The rectangle returned depends on the drawing aspect as follows.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Drawing Aspect</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>DVASPECT_CONTENT</term>
		/// <term>
		/// Objects should return the bounding rectangle of the whole object. The top-left corner is at the object's origin and the size
		/// is equal to the extent returned by IViewObject2::GetExtent.
		/// </term>
		/// </item>
		/// <item>
		/// <term>DVASPECT_OPAQUE</term>
		/// <term>
		/// Objects with a rectangular opaque region should return that rectangle. Others should fail and return error code
		/// DV_E_DVASPECT. If a rectangle is returned, it is guaranteed to be completely obscured by calling IViewObject::Draw for that
		/// aspect. The container should use that rectangle to clip out the object's opaque parts before drawing any object behind it
		/// during the back to front pass. If this method fails on an object with a non-rectangular opaque region, the container should
		/// draw the entire object in the back to front part using the DVASPECT_CONTENT aspect.
		/// </term>
		/// </item>
		/// <item>
		/// <term>DVASPECT_TRANSPARENT</term>
		/// <term>
		/// Objects should return the rectangle covering all transparent or irregular parts. If the object does not have any transparent
		/// or irregular parts, it may return DV_E_ASPECT. A container may use this rectangle to determine whether there are other
		/// objects overlapping the transparent parts of a given object.
		/// </term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-iviewobjectex-getrect HRESULT GetRect( DWORD dwAspect,
		// LPRECTL pRect );
		[PreserveSig]
		HRESULT GetRect(DVASPECT2 dwAspect, out RECT pRect);

		/// <summary>Retrieves information about the opacity of the object, and what drawing aspects are supported.</summary>
		/// <param name="pdwStatus">
		/// A pointer to the view status. This information is returned as a combination of the VIEWSTATUS enumeration values.
		/// </param>
		/// <returns>This method returns S_OK on success.</returns>
		/// <remarks>
		/// <para>
		/// In order to optimize the drawing process, the container needs to be able to determine whether an object is opaque and
		/// whether it has a solid background. It is not necessary to redraw objects that are entirely covered by a completely opaque
		/// object. Other operations, such as scrolling for example, can also be highly optimized if an object is opaque and has a solid background.
		/// </para>
		/// <para>
		/// The <c>IViewObjectEx::GetViewStatus</c> method returns whether the object is entirely opaque or not (VIEWSTATUS_OPAQUE bit)
		/// and whether its background is solid (VIEWSTATUS_SOLIDBKGND bit). This information may change in time. An object may be
		/// opaque at a given time and become totally or partially transparent later on, for example, because of a change of the
		/// BackStyle property. An object should notify its sites when it changes using IAdviseSinkEx::OnViewStatusChange so the sites
		/// can cache this information for high speed access.
		/// </para>
		/// <para>Objects not supporting IViewObjectEx are considered to be always transparent.</para>
		/// <para>The <c>IViewObjectEx::GetViewStatus</c> method also returns a combination of bits indicating which aspects are supported.</para>
		/// <para>
		/// If a given drawing aspect is not supported, all IViewObjectEx methods taking a drawing aspect as an input parameter should
		/// fail and return E_INVALIDARG. The <c>IViewObjectEx::GetViewStatus</c> method allows the container to get back information
		/// about all drawing aspects in one quick call. Normally the set of supported drawing aspects should not change with time.
		/// However, if this was not the case, an object should notify its container using IAdviseSinkEx::OnViewStatusChange.
		/// </para>
		/// <para>
		/// Which drawing aspects are supported is independent of whether the object is opaque, partially transparent, or totally
		/// transparent. In particular, a transparent object that does not support DVASPECT_TRANSPARENT should be drawn correctly during
		/// the back to front pass using DVASPECT_CONTENT. However, this is likely to result in more flicker.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-iviewobjectex-getviewstatus HRESULT GetViewStatus( DWORD
		// *pdwStatus );
		[PreserveSig]
		HRESULT GetViewStatus(out VIEWSTATUS pdwStatus);

		/// <summary>Indicates whether a point is within a given aspect of an object.</summary>
		/// <param name="dwAspect">The requested drawing aspect.</param>
		/// <param name="pRectBounds">
		/// An object bounding rectangle in client coordinates of the containing window. This rectangle is computed and passed by the
		/// container so that the object can meaningfully interpret the hit location.
		/// </param>
		/// <param name="ptlLoc">The hit location in client coordinates of the containing window.</param>
		/// <param name="lCloseHint">
		/// Suggested distance in <c>HIMETRIC</c> units that the container considers close. This value is a hint, and objects can
		/// interpret it in their own way. Objects can also use this hint to roughly infer output resolution to choose expansiveness of
		/// hit test implementation.
		/// </param>
		/// <param name="pHitResult">A pointer to returned information about the hit expressed as the HITRESULT enumeration values.</param>
		/// <returns>
		/// <para>This method returns <c>S_OK</c> on success. Other possible return values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>This method is not implemented for the requested aspect. Use DVASPECT_CONTENT instead.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// To support hit detection on non-rectangular objects, the container needs a reliable way to ask an object whether a given
		/// location is inside one of its drawing aspects. This function is provided by <c>IViewObjectEx::QueryHitPoint</c>.
		/// </para>
		/// <para>
		/// <c>Note</c> Because this method is part of the IViewObjectEx interface, the container can figure whether an mouse hit is
		/// over an object without having to necessarily launch the server. If the hit happens to be inside the object, then it is
		/// likely that the object will be in-place activated and the server started.
		/// </para>
		/// <para>
		/// Typically, the container first quickly determines whether a given location is within the rectangular extent of an object. If
		/// the location is within the rectangular extent of an object, the container calls <c>IViewObjectEx::QueryHitPoint</c> to get
		/// confirmation that the location is actually inside the object. The hit location is passed in client coordinates of the
		/// container window. Since the object may be inactive when this method is called, the bounding rectangle of the object in the
		/// same coordinate system is also passed to this method, similarly to what happens in IPointerInactive::OnInactiveSetCursor.
		/// </para>
		/// <para>Possible returned values include:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>Outside, on a transparent region</term>
		/// </item>
		/// <item>
		/// <term>Close enough to be considered a hit (may be used by small or thin objects)</term>
		/// </item>
		/// <item>
		/// <term>Hit</term>
		/// </item>
		/// </list>
		/// <para>
		/// <c>IViewObjectEx::QueryHitPoint</c> is not concerned by the sub-objects of the object it is called for. It merely indicates
		/// whether the mouse hit was within the object or not.
		/// </para>
		/// <para>
		/// <c>IViewObjectEx::QueryHitPoint</c> can be called for any of the drawing aspects an object supports. It should fail if the
		/// it is not supported for the requested drawing aspect.
		/// </para>
		/// <para>
		/// Transparent objects may wish to implement a complex hit-detection mechanism where the user can select either the transparent
		/// object or an object behind it, depending on where exactly the click happens inside the object. For example, a transparent
		/// text box showing big enough text may let the user select the object behind, for example, a bitmap, when the user clicks
		/// between the characters. For this reason, the information returned by <c>IViewObjectEx::QueryHitPoint</c> includes indication
		/// about whether the hit happens on an opaque or transparent region.
		/// </para>
		/// <para>
		/// An example of non-rectangular and transparent hit detection is a transparent circle control with an object behind it (a line
		/// in the example below):
		/// </para>
		/// <para>
		/// The values shown are for hit tests against the circle; gray regions are not part of the control, but are shown here to
		/// indicate an area around the image considered close. Each object implements its own definition of close but is assisted by a
		/// hint provided by the container so that closeness can be adjusted as images zoom larger or smaller.
		/// </para>
		/// <para>
		/// In the picture above, the points marked Hit, Close, and Transparent would all be hits of varying strength on the circle,
		/// with the exception of the one marked Transparent, (but for the line, close). This illustrates the effect of the different
		/// strength of hits. Because the circle responds transparent while the line claims close, and transparent is weaker than close,
		/// the line takes the hit.
		/// </para>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// An object supporting IViewObjectEx is required to implement this method at least for the <c>DVASPECT_CONTENT</c> aspect. The
		/// object should not take any other action in response to this method other than to return the information; there should be no side-effects.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-iviewobjectex-queryhitpoint HRESULT QueryHitPoint( DWORD
		// dwAspect, LPCRECT pRectBounds, POINT ptlLoc, LONG lCloseHint, DWORD *pHitResult );
		[PreserveSig]
		HRESULT QueryHitPoint(DVASPECT2 dwAspect, in RECT pRectBounds, POINT ptlLoc, int lCloseHint, out HITRESULT pHitResult);

		/// <summary>Indicates whether any point in a rectangle is within a given drawing aspect of an object.</summary>
		/// <param name="dwAspect">The requested drawing aspect.</param>
		/// <param name="pRectBounds">
		/// An object bounding rectangle in client coordinates of the containing window. This rectangle is computed and passed by the
		/// container so that the object can meaningfully interpret the hit location.
		/// </param>
		/// <param name="pRectLoc">
		/// The hit test rectangle, specified in <c>HIMETRIC</c> units, relative to the top-left corner of the object.
		/// </param>
		/// <param name="lCloseHint">
		/// The suggested distance, in <c>HIMETRIC</c> units, that the container considers close. This value is a hint, and objects can
		/// interpret it in their own way. Objects can also use this hint to roughly infer output resolution to choose expansiveness of
		/// hit test implementation.
		/// </param>
		/// <param name="pHitResult">A pointer to returned information about the hit expressed as the HITRESULT enumeration values.</param>
		/// <returns>
		/// <para>This method returns S_OK on success. Other possible return values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>This method is not implemented for the requested aspect. Use DVASPECT_CONTENT instead.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// Containers may need to test whether an object overlaps a given drawing aspect of another object. They can determine whether
		/// the objects overlap by requesting a region or at least a bounding rectangle of the aspect in question. However, a quicker
		/// way to do this is to call <c>IViewObjectEx::QueryHitRect</c> to ask the object whether a given rectangle intersects one of
		/// its drawing aspects.
		/// </para>
		/// <para>
		/// <c>Note</c> Unlike IViewObjectEx::QueryHitPoint, this method does not return HITRESULT_TRANSPARENT or HITRESULT_CLOSE. It is
		/// strictly hit or miss, returning HITRESULT_OUTSIDE if no point in the rectangle is hit and HITRESULT_HIT if at least one
		/// point in the rectangle is a hit.
		/// </para>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// An object supporting IViewObjectEx is required to implement this method at least for the DVASPECT_CONTENT aspect. The object
		/// should not take any other action in response to this method other than to return the information; there should be no
		/// side-effects. If there is any ambiguity about whether a point is a hit, for instance due to coordinates not converting
		/// exactly, the object should return HITRESULT_HIT whenever any point in the rectangle might be a hit on the object. That is,
		/// it is permissible to claim a hit for a point that is not actually rendered, but never correct to claim a miss for any point
		/// that is in the rendered image of the object.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-iviewobjectex-queryhitrect HRESULT QueryHitRect( DWORD
		// dwAspect, LPCRECT pRectBounds, LPCRECT pRectLoc, LONG lCloseHint, DWORD *pHitResult );
		[PreserveSig]
		HRESULT QueryHitRect(DVASPECT2 dwAspect, in RECT pRectBounds, in RECT pRectLoc, int lCloseHint, out HITRESULT pHitResult);

		/// <summary>Provides sizing hints from the container for the object to use as the user resizes it.</summary>
		/// <param name="dwAspect">
		/// <para>The requested drawing aspect. It can be any of the following values, which are defined by the DVASPECT enumeration.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>DVASPECT_CONTENT</term>
		/// <term>
		/// Provide a representation of the control so it can be displayed as an embedded object inside of a container. This value is
		/// typically specified for compound document objects. The presentation can be provided for the screen or printer.
		/// </term>
		/// </item>
		/// <item>
		/// <term>DVASPECT_DOCPRINT</term>
		/// <term>
		/// Provide a representation of the control on the screen as though it were printed to a printer using the Print command from
		/// the File menu. The described data may represent a sequence of pages.
		/// </term>
		/// </item>
		/// <item>
		/// <term>DVASPECT_ICON</term>
		/// <term>Provide an iconic representation of the control.</term>
		/// </item>
		/// <item>
		/// <term>DVASPECT_THUMBNAIL</term>
		/// <term>
		/// Provide a thumbnail representation of an object so it can be displayed in a browsing tool. The thumbnail is approximately a
		/// 120 by 120 pixel, 16-color (recommended) device-independent bitmap potentially wrapped in a metafile.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="lindex">
		/// Indicates the portion of the object that is of interest for the draw operation. Its interpretation varies depending on the
		/// value in the dwAspect parameter. See the DVASPECT enumeration for more information.
		/// </param>
		/// <param name="ptd">
		/// Pointer to the target device structure that describes the device for which the object is to be rendered. If <c>NULL</c>, the
		/// view should be rendered for the default target device (typically the display). A value other than <c>NULL</c> is interpreted
		/// in conjunction with hicTargetDev and <c>hdcDraw</c>. For example, if <c>hdcDraw</c> specifies a printer as the device
		/// context, the ptd parameter points to a structure describing that printer device. The data may actually be printed if
		/// hicTargetDev is a valid value or it may be displayed in print preview mode if hicTargetDev is <c>NULL</c>.
		/// </param>
		/// <param name="hicTargetDev">
		/// Specifies the information context for the target device indicated by the ptd parameter from which the object can extract
		/// device metrics and test the device's capabilities. If ptd is <c>NULL</c>; the object should ignore the value in the
		/// hicTargetDev parameter.
		/// </param>
		/// <param name="pExtentInfo">Pointer to DVEXTENTINFO structure that specifies the sizing data.</param>
		/// <param name="pSizel">
		/// Pointer to sizing data returned by the object. The returned sizing data is set to -1 for any dimension that was not
		/// adjusted. That is if <c>cx</c> is -1 then the width was not adjusted, if <c>cy</c> is -1 then the height was not adjusted.
		/// If E_FAIL is returned indicating no size was adjusted then pSizel may be <c>NULL</c>.
		/// </param>
		/// <returns>
		/// <para>This method returns S_OK on success. Other possible return values include the following.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>E_FAIL</term>
		/// <term>This method is not implemented for the specified dwAspect, or the size was not adjusted.</term>
		/// </item>
		/// <item>
		/// <term>E_NOTIMPL</term>
		/// <term>This method was not implemented.</term>
		/// </item>
		/// </list>
		/// </returns>
		/// <remarks>
		/// <para>
		/// There are two general approaches to sizing a control. The first approach gives the control responsibility for sizing itself;
		/// the second approach gives the container responsibility for sizing the control. The first approach is called autosizing.
		/// There are two alternatives involved in the second approach: content sizing and integral sizing.
		/// </para>
		/// <para>
		/// The <c>IViewObjectEx::GetNaturalExtent</c> method supports both content and integral sizing. In content sizing, the
		/// container passes the DVEXTENTINFO structure to the object into which the object returns a suggested size. In integral
		/// sizing, the container passes a preferred size to the object in <c>DVEXTENTINFO</c>, and the object actually adjusts its
		/// height. Integral sizing is used when the user rubberbands a new size in design mode.
		/// </para>
		/// <para>
		/// Autosizing typically occurs with objects such as the Label control which resizes if the autosize property was enabled and
		/// the associated text changed. Autosizing is handled differently depending on the state of the object.
		/// </para>
		/// <para>If the object is inactive, the following occurs:</para>
		/// <list type="number">
		/// <item>
		/// <term>The object calls IOleClientSite::RequestNewObjectLayout.</term>
		/// </item>
		/// <item>
		/// <term>The container calls IOleObject::GetExtent and retrieves the new extents.</term>
		/// </item>
		/// <item>
		/// <term>The container calls IOleObject::SetExtent and adjusts the new extents.</term>
		/// </item>
		/// </list>
		/// <para>If the object is active, the following occurs:</para>
		/// <list type="number">
		/// <item>
		/// <term>The object calls IOleInPlaceSite::OnPosRectChange to specify that it requires resizing.</term>
		/// </item>
		/// <item>
		/// <term>The container calls IOleInPlaceObject::SetObjectRects and specifies the new size.</term>
		/// </item>
		/// </list>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/nf-ocidl-iviewobjectex-getnaturalextent HRESULT GetNaturalExtent(
		// DWORD dwAspect, LONG lindex, DVTARGETDEVICE *ptd, HDC hicTargetDev, DVEXTENTINFO *pExtentInfo, LPSIZEL pSizel );
		[PreserveSig]
		HRESULT GetNaturalExtent(DVASPECT2 dwAspect, int lindex, [In] DVTARGETDEVICE? ptd, HDC hicTargetDev, in DVEXTENTINFO pExtentInfo, out SIZE pSizel);
	}

	/// <summary>Extension method to simplify using the <see cref="IObjectWithSite.GetSite"/> method.</summary>
	/// <typeparam name="T">Type of the interface to get.</typeparam>
	/// <param name="ows">An <see cref="IObjectWithSite"/> instance.</param>
	/// <returns>Receives the interface pointer requested in <typeparamref name="T"/>.</returns>
	public static T? GetSite<T>(this IObjectWithSite ows) where T : class { ows.GetSite(typeof(T).GUID, out object? pSite).ThrowIfFailed(); return (T?)pSite; }

	/// <summary>
	/// Specifies a counted array of values that can be used to obtain the value corresponding to one of the predefined strings for a property.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/ns-ocidl-cadword typedef struct tagCADWORD { ULONG cElems; DWORD
	// *pElems; } CADWORD, *LPCADWORD;
	[PInvokeData("ocidl.h", MSDNShortId = "NS:ocidl.tagCADWORD")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CADWORD : IArrayStruct<uint>
	{
		/// <summary>The size of the array pointed to by <c>pElems</c>.</summary>
		public uint cElems;

		/// <summary>
		/// A pointer to an array of values, each of which can be passed to the IPerPropertyBrowsing::GetPredefinedValue method to
		/// obtain the corresponding value for one of the property's predefined strings. This array is allocated by the callee using
		/// CoTaskMemAlloc and is freed by the caller using CoTaskMemFree.
		/// </summary>
		public IntPtr pElems;
	}

	/// <summary>Specifies a counted array of strings used to specify the predefined strings that a property can accept.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/ns-ocidl-calpolestr typedef struct tagCALPOLESTR { ULONG cElems;
	// LPOLESTR *pElems; } CALPOLESTR, *LPCALPOLESTR;
	[PInvokeData("ocidl.h", MSDNShortId = "NS:ocidl.tagCALPOLESTR")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CALPOLESTR : IArrayStruct<LPWSTR>
	{
		/// <summary>The size of the array pointed to by <c>pElems</c>.</summary>
		public uint cElems;

		/// <summary>
		/// A pointer to an array of LPOLESTR values, each of which corresponds to an allowable value that a particular property can
		/// accept. The caller can use these string values in user interface elements, such as drop-down list boxes. This array, as well
		/// as the strings in the array, are allocated by the callee using CoTaskMemAlloc and is freed by the caller using CoTaskMemFree.
		/// </summary>
		public IntPtr pElems;
	}

	/// <summary>
	/// Specifies a counted array of UUID or GUID types used to receive an array of CLSIDs for the property pages that the object wants
	/// to display.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/ns-ocidl-cauuid typedef struct tagCAUUID { ULONG cElems; GUID *pElems; }
	// CAUUID, *LPCAUUID;
	[PInvokeData("ocidl.h", MSDNShortId = "NS:ocidl.tagCAUUID")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CAUUID : IArrayStruct<Guid>
	{
		/// <summary>The size of the array pointed to by <c>pElems</c>.</summary>
		public uint cElems;

		/// <summary>
		/// A pointer to an array of values, each of which specifies a CLSID of a particular property page. This array is allocated by
		/// the callee using CoTaskMemAlloc and is freed by the caller using CoTaskMemFree.
		/// </summary>
		public IntPtr pElems;
	}

	/// <summary>Describes a connection that exists to a given connection point.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/ns-ocidl-connectdata typedef struct tagCONNECTDATA { IUnknown *pUnk;
	// DWORD dwCookie; } CONNECTDATA, *PCONNECTDATA, *LPCONNECTDATA;
	[PInvokeData("ocidl.h", MSDNShortId = "NS:ocidl.tagCONNECTDATA")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct CONNECTDATA
	{
		/// <summary>
		/// A pointer to the IUnknown interface on a connected advisory sink. The caller must call Release using this pointer when the
		/// <c>CONNECTDATA</c> structure is no longer needed. The caller is responsible for calling <c>Release</c> for each
		/// <c>CONNECTDATA</c> structure enumerated through IEnumConnections::Next.
		/// </summary>
		public IntPtr pUnk;

		/// <summary>
		/// Connection where this value is the same token that is returned originally from calls to IConnectionPoint::Advise. This token
		/// can be used to disconnect the sink pointed to by a <c>pUnk</c> by passing <c>dwCookie</c> to IConnectionPoint::Unadvise.
		/// </summary>
		public uint dwCookie;
	}

	/// <summary>
	/// Contains parameters that describe a control's keyboard mnemonics and keyboard behavior. The structure is populated during the
	/// IOleControl::GetControlInfo method.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/ns-ocidl-controlinfo typedef struct tagCONTROLINFO { ULONG cb; HACCEL
	// hAccel; USHORT cAccel; DWORD dwFlags; } CONTROLINFO, *LPCONTROLINFO;
	[PInvokeData("ocidl.h", MSDNShortId = "NS:ocidl.tagCONTROLINFO")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CONTROLINFO
	{
		/// <summary>The size of the structure, in bytes.</summary>
		public uint cb;

		/// <summary>
		/// A handle to an array of ACCEL structures, each structure describing a keyboard mnemonic. The array is created with the
		/// CreateAcceleratorTable function. The control always maintains the memory for this array; the caller of
		/// IOleControl::GetControlInfo should not attempt to free the memory.
		/// </summary>
		public HACCEL hAccel;

		/// <summary>The number of mnemonics described in the <c>hAccel</c> field. This value can be zero to indicate no mnemonics.</summary>
		public ushort cAccel;

		/// <summary>
		/// <para>Flags that indicate the keyboard behavior of the control. The possible values are:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>CTRLINFO_EATS_RETURN: When the control has the focus, it will process the Return key.</term>
		/// </item>
		/// <item>
		/// <term>CTRLINFO_EATS_ESCAPE: When the control has the focus, it will process the Escape key.</term>
		/// </item>
		/// </list>
		/// <para>
		/// When the control has the focus, the dialog box containing the control cannot use the Return or Escape keys as mnemonics for
		/// the default and cancel buttons.
		/// </para>
		/// </summary>
		public CTRLINFO dwFlags;
	}

	/// <summary>
	/// Contains information that is used by the IViewObject::Draw method to optimize rendering of an inactive object by making more
	/// efficient use of the GDI.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/ns-ocidl-dvaspectinfo typedef struct tagAspectInfo { ULONG cb; DWORD
	// dwFlags; } DVASPECTINFO;
	[PInvokeData("ocidl.h", MSDNShortId = "NS:ocidl.tagAspectInfo")]
	[StructLayout(LayoutKind.Sequential)]
	public class DVASPECTINFO
	{
		/// <summary>The size of the structure, in bytes.</summary>
		public uint cb;

		/// <summary>A value taken from the DVASPECTINFOFLAG enumeration.</summary>
		public DVASPECTINFOFLAG dwFlags;
	}

	/// <summary>Represents the sizing data used in IViewObjectEx::GetNaturalExtent.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/ns-ocidl-dvextentinfo typedef struct tagExtentInfo { ULONG cb; DWORD
	// dwExtentMode; SIZEL sizelProposed; } DVEXTENTINFO;
	[PInvokeData("ocidl.h", MSDNShortId = "NS:ocidl.tagExtentInfo")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DVEXTENTINFO
	{
		/// <summary>The size of the structure, in bytes.</summary>
		public uint cb;

		/// <summary>
		/// Indicates whether the sizing mode is content or integral sizing. See the DVEXTENTMODE enumeration for possible values.
		/// </summary>
		public DVEXTENTMODE dwExtentMode;

		/// <summary>The proposed size in content sizing or the preferred size in integral sizing.</summary>
		public SIZE sizelProposed;
	}

	/// <summary>
	/// <para>
	/// Contains parameters that describe the licensing behavior of a class factory that supports licensing. The structure is filled by
	/// calling the IClassFactory2::GetLicInfo method.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ocidl/ns-ocidl-taglicinfo typedef struct tagLICINFO { LONG cbLicInfo; BOOL
	// fRuntimeKeyAvail; BOOL fLicVerified; } LICINFO, *LPLICINFO;
	[PInvokeData("ocidl.h", MSDNShortId = "a90d82f3-8dc4-4b1d-81f7-9d3a19e74314")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct LICINFO
	{
		/// <summary>
		/// <para>The size of the structure, in bytes.</para>
		/// </summary>
		public int cbLicInfo;

		/// <summary>
		/// <para>
		/// Indicates whether this class factory allows the creation of its objects on an unlicensed machine through the use of a
		/// license key. If <c>TRUE</c>, IClassFactory2::RequestLicKey can be called to obtain the key. If <c>FALSE</c>, objects can be
		/// created only on a fully licensed machine.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool fRuntimeKeyAvail;

		/// <summary>
		/// <para>
		/// Indicates whether a full machine license exists such that calls to IClassFactory::CreateInstance and
		/// IClassFactory2::RequestLicKey will succeed. If <c>TRUE</c>, the full machine license exists. Thus, objects can be created
		/// freely. and a license key is available if <c>fRuntimeKeyAvail</c> is also <c>TRUE</c>. If <c>FALSE</c>, this class factory
		/// cannot create any instances of objects on this machine unless the proper license key is passed to IClassFactory2::CreateInstanceLic.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool fLicVerified;
	}

	/// <summary>
	/// Contains information that is used to convert between container units, expressed in floating point, and control units, expressed
	/// in <c>HIMETRIC</c>. The <c>POINTF</c> structure specifically holds the floating point container units. Controls do not attempt to
	/// interpret either value in the structure.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/ns-ocidl-pointf typedef struct tagPOINTF { FLOAT x; FLOAT y; } POINTF, *LPPOINTF;
	[PInvokeData("ocidl.h", MSDNShortId = "NS:ocidl.tagPOINTF")]
	[StructLayout(LayoutKind.Sequential)]
	public struct POINTF
	{
		/// <summary>The x coordinates of the point in units that the container finds convenient.</summary>
		public float x;

		/// <summary>The y coordinates of the point in units that the container finds convenient.</summary>
		public float y;
	}

	/// <summary>
	/// Contains parameters used to describe a property page to a property frame. A property page fills a caller-provided structure in
	/// the IPropertyPage::GetPageInfo method.
	/// </summary>
	/// <remarks>
	/// The <c>pszTitle</c>, <c>pszDocString</c>, and the <c>pszHelpFile</c> members specified in this structure should contain text
	/// sensitive to the locale obtained through IPropertyPageSite::GetLocaleID.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/ns-ocidl-proppageinfo typedef struct tagPROPPAGEINFO { ULONG cb;
	// LPOLESTR pszTitle; SIZE size; LPOLESTR pszDocString; LPOLESTR pszHelpFile; DWORD dwHelpContext; } PROPPAGEINFO, *LPPROPPAGEINFO;
	[PInvokeData("ocidl.h", MSDNShortId = "NS:ocidl.tagPROPPAGEINFO")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PROPPAGEINFO
	{
		/// <summary>The size of the structure, in bytes.</summary>
		public uint cb;

		/// <summary>
		/// Pointer to an OLESTR that contains the string that appears in the tab for this page. The string must be allocated with
		/// CoTaskMemAlloc. The caller of IPropertyPage::GetPageInfo is responsible for freeing the memory with CoTaskMemFree.
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pszTitle;

		/// <summary>Required dimensions of the page's dialog box, in pixels.</summary>
		public SIZE size;

		/// <summary>
		/// Pointer to a text string describing the page, which can be displayed in the property sheet dialog box (current frame
		/// implementation doesn't use this field). The text must be allocated with CoTaskMemAlloc. The caller of
		/// IPropertyPage::GetPageInfo is responsible for freeing the memory with CoTaskMemFree.
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pszDocString;

		/// <summary>
		/// Pointer to an OLESTR that contains the simple name of the help file that describes this property page used instead of
		/// implementing IPropertyPage::Help. When the user presses Help, the Help method is normally called. If that method fails, the
		/// frame will open the help system with this help file (prefixed with the value of the HelpDir key in the property page's
		/// registry entries under its CLSID) and will instruct the help system to display the context described by the
		/// <c>dwHelpContext</c> field. The path must be allocated with CoTaskMemAlloc. The caller of IPropertyPage::GetPageInfo is
		/// responsible for freeing the memory with CoTaskMemFree.
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pszHelpFile;

		/// <summary>Context identifier for the help topic within <c>pszHelpFile</c> that describes this page.</summary>
		public uint dwHelpContext;
	}

	/// <summary>Specifies container information for IQuickActivate::QuickActivate.</summary>
	/// <remarks>
	/// If an interface pointer in the <c>QACONTAINER</c> structure is <c>NULL</c> it does not indicate that the interface is not
	/// supported. In this situation, the control should use QueryInterface to obtain the interface pointer in the standard manner.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/ns-ocidl-qacontainer typedef struct tagQACONTAINER { ULONG cbSize;
	// IOleClientSite *pClientSite; IAdviseSinkEx *pAdviseSink; IPropertyNotifySink *pPropertyNotifySink; IUnknown *pUnkEventSink; DWORD
	// dwAmbientFlags; OLE_COLOR colorFore; OLE_COLOR colorBack; IFont *pFont; IOleUndoManager *pUndoMgr; DWORD dwAppearance; LONG lcid;
	// HPALETTE hpal; IBindHost *pBindHost; IOleControlSite *pOleControlSite; IServiceProvider *pServiceProvider; } QACONTAINER;
	[PInvokeData("ocidl.h", MSDNShortId = "NS:ocidl.tagQACONTAINER")]
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct QACONTAINER
	{
		/// <summary>The size of the structure, in bytes.</summary>
		public uint cbSize;

		/// <summary>A pointer to an IOleClientSite interface in the container.</summary>
		[MarshalAs(UnmanagedType.Interface)]
		public IOleClientSite pClientSite;

		/// <summary>A pointer to an IAdviseSinkEx interface in the container.</summary>
		[MarshalAs(UnmanagedType.Interface)]
		public IAdviseSinkEx pAdviseSink;

		/// <summary>A pointer to an IPropertyNotifySink interface in the container.</summary>
		[MarshalAs(UnmanagedType.Interface)]
		public IPropertyNotifySink pPropertyNotifySink;

		/// <summary>A pointer to an IUnknown interface on the container's sink object.</summary>
		[MarshalAs(UnmanagedType.IUnknown)]
		public object pUnkEventSink;

		/// <summary>The number of ambient properties supplied by the container using values from the QACONTAINERFLAGS enumeration.</summary>
		public QACONTAINERFLAGS dwAmbientFlags;

		/// <summary>Specifies ForeColor, an ambient property supplied by the container with a DISPID = -704.</summary>
		public uint colorFore;

		/// <summary>Specifies BackColor, an ambient property supplied by the container with a DISPID = -701.</summary>
		public uint colorBack;

		/// <summary>Specifies Font, an ambient property supplied by the container with a DISPID = -703.</summary>
		[MarshalAs(UnmanagedType.Interface)]
		public IFont pFont;

		/// <summary>A pointer to an IOleUndoManager interface in the container.</summary>
		[MarshalAs(UnmanagedType.Interface)]
		public IOleUndoManager pUndoMgr;

		/// <summary>Specifies Appearance, an ambient property supplied by the container with a DISPID = -716.</summary>
		public uint dwAppearance;

		/// <summary>Specifies LocaleIdentifier, an ambient property supplied by the container with a DISPID = -705.</summary>
		public LCID lcid;

		/// <summary>Specifies Palette, an ambient property supplied by the container with a DISPID = -726.</summary>
		public HPALETTE hpal;

		/// <summary>A pointer to an IBindHost interface in the container.</summary>
		[MarshalAs(UnmanagedType.Interface)]
		public object pBindHost;

		/// <summary>A pointer to the IOleControlSite interface in the container's site object.</summary>
		[MarshalAs(UnmanagedType.Interface)]
		public IOleControlSite pOleControlSite;

		/// <summary>A pointer to the IServiceProvider interface in the container.</summary>
		[MarshalAs(UnmanagedType.Interface)]
		public IServiceProvider pServiceProvider;
	}

	/// <summary>Specifies control information for IQuickActivate::QuickActivate.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ocidl/ns-ocidl-qacontrol typedef struct tagQACONTROL { ULONG cbSize; DWORD
	// dwMiscStatus; DWORD dwViewStatus; DWORD dwEventCookie; DWORD dwPropNotifyCookie; DWORD dwPointerActivationPolicy; } QACONTROL;
	[PInvokeData("ocidl.h", MSDNShortId = "NS:ocidl.tagQACONTROL")]
	[StructLayout(LayoutKind.Sequential)]
	public struct QACONTROL
	{
		/// <summary>The size of the structure, in bytes.</summary>
		public uint cbSize;

		/// <summary>
		/// The control's miscellaneous status bits that can also be returned by IOleObject::GetMiscStatus. See OLEMISC for more information.
		/// </summary>
		public OLEMISC dwMiscStatus;

		/// <summary>
		/// The control's view status that can also be returned by IViewObjectEx::GetViewStatus. See VIEWSTATUS for more information.
		/// </summary>
		public VIEWSTATUS dwViewStatus;

		/// <summary>A unique identifier for control-defined events.</summary>
		public uint dwEventCookie;

		/// <summary>A unique identifier for control-defined properties.</summary>
		public uint dwPropNotifyCookie;

		/// <summary>
		/// The control's activation policy that can also be returned by IPointerInactive::GetActivationPolicy. If all the bits of
		/// <c>dwPointerActivationPolicy</c> are set, then the IPointerInactive interface may not be supported. The container should
		/// QueryInterface to obtain the interface pointer in the standard manner.
		/// </summary>
		public POINTERINACTIVE dwPointerActivationPolicy;
	}

	/* cpp_quote("#define MULTICLASSINFO_GETTYPEINFO 0x00000001")
	cpp_quote("#define MULTICLASSINFO_GETNUMRESERVEDDISPIDS 0x00000002")
	cpp_quote("#define MULTICLASSINFO_GETIIDPRIMARY 0x00000004")
	cpp_quote("#define MULTICLASSINFO_GETIIDSOURCE 0x00000008")
	cpp_quote("#define TIFLAGS_EXTENDDISPATCHONLY 0x00000001") */
}