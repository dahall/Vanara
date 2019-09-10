using System;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace Vanara.PInvoke
{
	public static partial class Ole32
	{
		/// <summary>
		/// <para>
		/// Represents information about the effects of a drag-and-drop operation. The <c>DoDragDrop</c> function and many of the methods in
		/// the <c>IDropSource</c> and <c>IDropTarget</c> use the values of this enumeration.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Your application should always mask values from the <c>DROPEFFECT</c> enumeration to ensure compatibility with future
		/// implementations. Presently, only some of the positions in a <c>DROPEFFECT</c> value have meaning. In the future, more
		/// interpretations for the bits will be added. Drag sources and drop targets should carefully mask these values appropriately before
		/// comparing. They should never compare a <c>DROPEFFECT</c> against, say, DROPEFFECT_COPY by doing the following:
		/// </para>
		/// <para>Instead, the application should always mask for the value or values being sought as using one of the following techniques:</para>
		/// <para>This allows for the definition of new drop effects, while preserving backward compatibility with existing code.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/com/dropeffect-constants
		[PInvokeData("OleIdl.h", MSDNShortId = "d8e46899-3fbf-4012-8dd3-67fa627526d5")]
		// public static extern
		public enum DROPEFFECT : uint
		{
			/// <summary>Drop target cannot accept the data.</summary>
			DROPEFFECT_NONE = 0,

			/// <summary>Drop results in a copy. The original data is untouched by the drag source.</summary>
			DROPEFFECT_COPY = 1,

			/// <summary>Drag source should remove the data.</summary>
			DROPEFFECT_MOVE = 2,

			/// <summary>Drag source should create a link to the original data.</summary>
			DROPEFFECT_LINK = 4,

			/// <summary>
			/// Scrolling is about to start or is currently occurring in the target. This value is used in addition to the other values.
			/// </summary>
			DROPEFFECT_SCROLL = 0x80000000,
		}

		/// <summary>Indicates whether an object should be saved before closing.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/ne-oleidl-oleclose typedef enum tagOLECLOSE { OLECLOSE_SAVEIFDIRTY,
		// OLECLOSE_NOSAVE, OLECLOSE_PROMPTSAVE } OLECLOSE;
		[PInvokeData("oleidl.h", MSDNShortId = "386f24a4-11d7-4471-960e-1a3ff67ba3c5")]
		public enum OLECLOSE
		{
			/// <summary>The object should be saved if it is dirty.</summary>
			OLECLOSE_SAVEIFDIRTY,

			/// <summary>The object should not be saved, even if it is dirty. This flag is typically used when an object is being deleted.</summary>
			OLECLOSE_NOSAVE,

			/// <summary>
			/// If the object is dirty, the IOleObject::Close implementation should display a dialog box to let the end user determine
			/// whether to save the object. However, if the object is in the running state but its user interface is invisible, the end user
			/// should not be prompted, and the close should be handled as if OLECLOSE_SAVEIFDIRTY had been specified.
			/// </summary>
			OLECLOSE_PROMPTSAVE,
		}

		/// <summary>Indicates the type of objects to be enumerated.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/ne-oleidl-olecontf typedef enum tagOLECONTF { OLECONTF_EMBEDDINGS,
		// OLECONTF_LINKS, OLECONTF_OTHERS, OLECONTF_ONLYUSER, OLECONTF_ONLYIFRUNNING } OLECONTF;
		[PInvokeData("oleidl.h", MSDNShortId = "9c70fc86-7166-47dd-a424-741f18e381e3")]
		public enum OLECONTF
		{
			/// <summary>Enumerates the embedded objects in the container.</summary>
			OLECONTF_EMBEDDINGS = 1,

			/// <summary>Enumerates the linked objects in the container.</summary>
			OLECONTF_LINKS,

			/// <summary>
			/// Enumerates all objects in the container that are not OLE compound document objects (i.e., objects other than linked or
			/// embedded objects). Use this flag to enumerate the container's pseudo-objects.
			/// </summary>
			OLECONTF_OTHERS,

			/// <summary>
			/// Enumerates only those objects the user is aware of. For example, hidden named-ranges in Microsoft Excel would not be
			/// enumerated using this value.
			/// </summary>
			OLECONTF_ONLYUSER,

			/// <summary>Enumerates only those linked or embedded objects that are currently in the running state for this container.</summary>
			OLECONTF_ONLYIFRUNNING,
		}

		/// <summary>Controls aspects of the behavior of the IOleObject::GetMoniker and IOleClientSite::GetMoniker methods.</summary>
		/// <remarks>
		/// If the OLEGETMONIKER_FORCEASSIGN flag causes a container to create a moniker for the object, the container should notify the
		/// object by calling the IOleObject::GetMoniker method.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/ne-oleidl-olegetmoniker typedef enum tagOLEGETMONIKER {
		// OLEGETMONIKER_ONLYIFTHERE, OLEGETMONIKER_FORCEASSIGN, OLEGETMONIKER_UNASSIGN, OLEGETMONIKER_TEMPFORUSER } OLEGETMONIKER;
		[PInvokeData("oleidl.h", MSDNShortId = "b69e3213-08c4-45f8-b1b3-4ca78e966251")]
		public enum OLEGETMONIKER
		{
			/// <summary>
			/// If a moniker for the object or container does not exist, IOleClientSite::GetMoniker should return E_FAIL and not assign a moniker.
			/// </summary>
			OLEGETMONIKER_ONLYIFTHERE = 1,

			/// <summary>If a moniker for the object or container does not exist, IOleClientSite::GetMoniker should create one.</summary>
			OLEGETMONIKER_FORCEASSIGN,

			/// <summary>
			/// IOleClientSite::GetMoniker can release the object's moniker (although it is not required to do so). This constant is not
			/// valid in IOleObject::GetMoniker.
			/// </summary>
			OLEGETMONIKER_UNASSIGN,

			/// <summary>
			/// If a moniker for the object does not exist, IOleObject::GetMoniker can create a temporary moniker that can be used for
			/// display purposes (IMoniker::GetDisplayName) but not for binding. This enables the object server to return a descriptive name
			/// for the object without incurring the overhead of creating and maintaining a moniker until a link is actually created.
			/// </summary>
			OLEGETMONIKER_TEMPFORUSER,
		}

		/// <summary>Indicates the type of caching requested for newly created objects.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/ne-oleidl-olerender typedef enum tagOLERENDER { OLERENDER_NONE,
		// OLERENDER_DRAW, OLERENDER_FORMAT, OLERENDER_ASIS } OLERENDER;
		[PInvokeData("oleidl.h", MSDNShortId = "bab871ba-4ec4-49fd-854a-585732b91290")]
		public enum OLERENDER
		{
			/// <summary>
			/// The client is not requesting any locally cached drawing or data retrieval capabilities in the object. The pFormatEtc
			/// parameter of the calls is ignored when this value is specified for the renderopts parameter.
			/// </summary>
			OLERENDER_NONE,

			/// <summary>
			/// The client will draw the content of the object on the screen (a NULL target device) using IViewObject::Draw. The object
			/// itself determines the data formats that need to be cached. With this render option, only the ptd and dwAspect members of
			/// pFormatEtc are significant, since the object may cache things differently depending on the parameter values. However,
			/// pFormatEtc can legally be NULL here, in which case the object is to assume the display target device and the DVASPECT_CONTENT aspect.
			/// </summary>
			OLERENDER_DRAW,

			/// <summary>
			/// The client will pull one format from the object using IDataObject::GetData. The format of the data to be cached is passed in
			/// pFormatEtc, which may not in this case be NULL.
			/// </summary>
			OLERENDER_FORMAT,

			/// <summary>
			/// The client is not requesting any locally cached drawing or data retrieval capabilities in the object. pFormatEtc is ignored
			/// for this option. The difference between this and the OLERENDER_FORMAT value is important in such functions as
			/// OleCreateFromData and OleCreateLinkFromData.
			/// </summary>
			OLERENDER_ASIS,
		}

		/// <summary>Describes the attributes of a specified verb for an object.</summary>
		/// <remarks>Values are used in the enumerator (which supports the IEnumOLEVERB interface) that is created by a call to IOleObject::EnumVerbs.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/ne-oleidl-oleverbattrib typedef enum tagOLEVERBATTRIB {
		// OLEVERBATTRIB_NEVERDIRTIES, OLEVERBATTRIB_ONCONTAINERMENU } OLEVERBATTRIB;
		[PInvokeData("oleidl.h", MSDNShortId = "797498ba-5ad6-4476-87d8-de85b30396f4")]
		[Flags]
		public enum OLEVERBATTRIB
		{
			/// <summary>
			/// Executing this verb will not cause the object to become dirty and is therefore in need of saving to persistent storage.
			/// </summary>
			OLEVERBATTRIB_NEVERDIRTIES = 1,

			/// <summary>
			/// Indicates a verb that should appear in the container's menu of verbs for this object. OLEIVERB_HIDE, OLEIVERB_SHOW, and
			/// OLEIVERB_OPEN never have this value set.
			/// </summary>
			OLEVERBATTRIB_ONCONTAINERMENU = 2,
		}

		/// <summary>Indicates which part of an object's moniker is being set or retrieved.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/ne-oleidl-olewhichmk typedef enum tagOLEWHICHMK { OLEWHICHMK_CONTAINER,
		// OLEWHICHMK_OBJREL, OLEWHICHMK_OBJFULL } OLEWHICHMK;
		[PInvokeData("oleidl.h", MSDNShortId = "3774c868-c312-4e7c-aa57-cdb13000a87c")]
		public enum OLEWHICHMK
		{
			/// <summary>
			/// The moniker of the object's container. Typically, this is a file moniker. This moniker is not persistently stored inside the
			/// object, since the container can be renamed even while the object is not loaded.
			/// </summary>
			OLEWHICHMK_CONTAINER = 1,

			/// <summary>
			/// The moniker of the object relative to its container. Typically, this is an item moniker, and it is part of the persistent
			/// state of the object. If this moniker is composed on to the end of the container's moniker, the resulting moniker is the full
			/// moniker of the object.
			/// </summary>
			OLEWHICHMK_OBJREL,

			/// <summary>
			/// The full moniker of the object. Binding to this moniker results in a connection to the object. This moniker is not
			/// persistently stored inside the object, since the container can be renamed even while the object is not loaded.
			/// </summary>
			OLEWHICHMK_OBJFULL,
		}

		/// <summary>Indicates the different variants of the display name associated with a class of objects.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/ne-oleidl-userclasstype typedef enum tagUSERCLASSTYPE {
		// USERCLASSTYPE_FULL, USERCLASSTYPE_SHORT, USERCLASSTYPE_APPNAME } USERCLASSTYPE;
		[PInvokeData("oleidl.h", MSDNShortId = "f35dd18a-7fde-4954-8315-bc9bfd933827")]
		public enum USERCLASSTYPE
		{
			/// <summary>The full type name of the class.</summary>
			USERCLASSTYPE_FULL = 1,

			/// <summary>A short name (maximum of 15 characters) that is used for popup menus and the Links dialog box.</summary>
			USERCLASSTYPE_SHORT,

			/// <summary>The name of the application servicing the class and is used in the result text in dialog boxes.</summary>
			USERCLASSTYPE_APPNAME,
		}

		/// <summary>
		/// <para>
		/// The <c>IDropSource</c> interface is one of the interfaces you implement to provide drag-and-drop operations in your application.
		/// It contains methods used in any application used as a data source in a drag-and-drop operation. The data source application in a
		/// drag-and-drop operation is responsible for:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>Determining the data being dragged based on the user's selection.</term>
		/// </item>
		/// <item>
		/// <term>Initiating the drag-and-drop operation based on the user's mouse actions.</term>
		/// </item>
		/// <item>
		/// <term>
		/// Generating some of the visual feedback during the drag-and-drop operation, such as setting the cursor and highlighting the data
		/// selected for the drag-and-drop operation.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Canceling or completing the drag-and-drop operation based on the user's mouse actions.</term>
		/// </item>
		/// <item>
		/// <term>Performing any action on the original data caused by the drop operation, such as deleting the data on a drag move.</term>
		/// </item>
		/// </list>
		/// <para>
		/// <c>IDropSource</c> contains the methods for generating visual feedback to the end user and for canceling or completing the
		/// drag-and-drop operation. You also need to call the DoDragDrop, RegisterDragDrop, and RevokeDragDrop functions in drag-and-drop operations.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/oleidl/nn-oleidl-idropsource
		[PInvokeData("oleidl.h", MSDNShortId = "963a36bc-4ad7-4591-bffc-a96b4310177d")]
		[ComImport, Guid("00000121-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IDropSource
		{
			/// <summary>
			/// <para>
			/// Determines whether a drag-and-drop operation should be continued, canceled, or completed. You do not call this method
			/// directly. The OLE DoDragDrop function calls this method during a drag-and-drop operation.
			/// </para>
			/// </summary>
			/// <param name="fEscapePressed">
			/// <para>
			/// Indicates whether the Esc key has been pressed since the previous call to <c>QueryContinueDrag</c> or to DoDragDrop if this
			/// is the first call to <c>QueryContinueDrag</c>. A <c>TRUE</c> value indicates the end user has pressed the escape key; a
			/// <c>FALSE</c> value indicates it has not been pressed.
			/// </para>
			/// </param>
			/// <param name="grfKeyState">
			/// <para>
			/// The current state of the keyboard modifier keys on the keyboard. Possible values can be a combination of any of the flags
			/// MK_CONTROL, MK_SHIFT, MK_ALT, MK_BUTTON, MK_LBUTTON, MK_MBUTTON, and MK_RBUTTON.
			/// </para>
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
			/// <term>
			/// The drag operation should continue. This result occurs if no errors are detected, the mouse button starting the drag-and-drop
			/// operation has not been released, and the Esc key has not been detected.
			/// </term>
			/// </item>
			/// <item>
			/// <term>DRAGDROP_S_DROP</term>
			/// <term>
			/// The drop operation should occur completing the drag operation. This result occurs if grfKeyState indicates that the key that
			/// started the drag-and-drop operation has been released.
			/// </term>
			/// </item>
			/// <item>
			/// <term>DRAGDROP_S_CANCEL</term>
			/// <term>
			/// The drag operation should be canceled with no drop operation occurring. This result occurs if fEscapePressed is TRUE,
			/// indicating the Esc key has been pressed.
			/// </term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>
			/// The DoDragDrop function calls <c>QueryContinueDrag</c> whenever it detects a change in the keyboard or mouse button state
			/// during a drag-and-drop operation. <c>QueryContinueDrag</c> must determine whether the drag-and-drop operation should be
			/// continued, canceled, or completed based on the contents of the parameters grfKeyState and fEscapePressed.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/oleidl/nf-oleidl-idropsource-querycontinuedrag HRESULT QueryContinueDrag(
			// BOOL fEscapePressed, DWORD grfKeyState );
			[PInvokeData("oleidl.h", MSDNShortId = "96ea44fc-5046-4e31-abfc-659d8ef3ca8f")]
			[PreserveSig]
			HRESULT QueryContinueDrag([MarshalAs(UnmanagedType.Bool)] bool fEscapePressed, uint grfKeyState);

			/// <summary>
			/// <para>
			/// Enables a source application to give visual feedback to the end user during a drag-and-drop operation by providing the
			/// DoDragDrop function with an enumeration value specifying the visual effect.
			/// </para>
			/// </summary>
			/// <param name="dwEffect">
			/// <para>The DROPEFFECT value returned by the most recent call to IDropTarget::DragEnter, IDropTarget::DragOver, or IDropTarget::DragLeave.</para>
			/// </param>
			/// <returns>
			/// <para>This method returns S_OK on success. Other possible values include the following.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>DRAGDROP_S_USEDEFAULTCURSORS</term>
			/// <term>
			/// Indicates successful completion of the method, and requests OLE to update the cursor using the OLE-provided default cursors.
			/// </term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>
			/// When your application detects that the user has started a drag-and-drop operation, it should call the DoDragDrop function.
			/// <c>DoDragDrop</c> enters a loop, calling IDropTarget::DragEnter when the mouse first enters a drop target window,
			/// IDropTarget::DragOver when the mouse changes its position within the target window, and IDropTarget::DragLeave when the mouse
			/// leaves the target window.
			/// </para>
			/// <para>
			/// For every call to either IDropTarget::DragEnter or IDropTarget::DragOver, DoDragDrop calls <c>IDropSource::GiveFeedback</c>,
			/// passing it the DROPEFFECT value returned from the drop target call.
			/// </para>
			/// <para>
			/// DoDragDrop calls IDropTarget::DragLeave when the mouse has left the target window. Then, <c>DoDragDrop</c> calls
			/// <c>IDropSource::GiveFeedback</c> and passes the DROPEFFECT_NONE value in the dwEffect parameter.
			/// </para>
			/// <para>
			/// The dwEffect parameter can include DROPEFFECT_SCROLL, indicating that the source should put up the drag-scrolling variation
			/// of the appropriate pointer.
			/// </para>
			/// <para>Notes to Implementers</para>
			/// <para>
			/// This function is called frequently during the DoDragDrop loop, so you can gain performance advantages if you optimize your
			/// implementation as much as possible.
			/// </para>
			/// <para>
			/// <c>IDropSource::GiveFeedback</c> is responsible for changing the cursor shape or for changing the highlighted source based on
			/// the value of the dwEffect parameter. If you are using default cursors, you can return DRAGDROP_S_USEDEFAULTCURSORS, which
			/// causes OLE to update the cursor for you, using its defaults.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/oleidl/nf-oleidl-idropsource-givefeedback HRESULT GiveFeedback( DWORD
			// dwEffect );
			[PInvokeData("oleidl.h", MSDNShortId = "dde37299-ad7c-4f59-af99-e75b72ad9188")]
			[PreserveSig]
			HRESULT GiveFeedback(DROPEFFECT dwEffect);
		}

		/// <summary>
		/// <para>
		/// The <c>IDropTarget</c> interface is one of the interfaces you implement to provide drag-and-drop operations in your application.
		/// It contains methods used in any application that can be a target for data during a drag-and-drop operation. A drop-target
		/// application is responsible for:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>Determining the effect of the drop on the target application.</term>
		/// </item>
		/// <item>
		/// <term>Incorporating any valid dropped data when the drop occurs.</term>
		/// </item>
		/// <item>
		/// <term>
		/// Communicating target feedback to the source so the source application can provide appropriate visual feedback such as setting the cursor.
		/// </term>
		/// </item>
		/// <item>
		/// <term>Implementing drag scrolling.</term>
		/// </item>
		/// <item>
		/// <term>Registering and revoking its application windows as drop targets.</term>
		/// </item>
		/// </list>
		/// <para>
		/// The <c>IDropTarget</c> interface contains methods that handle all these responsibilities except registering and revoking the
		/// application window as a drop target, for which you must call the RegisterDragDrop and the RevokeDragDrop functions.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/oleidl/nn-oleidl-idroptarget
		[PInvokeData("oleidl.h", MSDNShortId = "13fbe834-1ef8-4944-b2e4-9f5c413c65c8")]
		[ComImport, Guid("00000122-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IDropTarget
		{
			/// <summary>Indicates whether a drop can be accepted, and, if so, the effect of the drop.</summary>
			/// <param name="pDataObj">
			/// A pointer to the IDataObject interface on the data object. This data object contains the data being transferred in the
			/// drag-and-drop operation. If the drop occurs, this data object will be incorporated into the target.
			/// </param>
			/// <param name="grfKeyState">
			/// The current state of the keyboard modifier keys on the keyboard. Possible values can be a combination of any of the flags
			/// MK_CONTROL, MK_SHIFT, MK_ALT, MK_BUTTON, MK_LBUTTON, MK_MBUTTON, and MK_RBUTTON.
			/// </param>
			/// <param name="pt">A POINTL structure containing the current cursor coordinates in screen coordinates.</param>
			/// <param name="pdwEffect">
			/// On input, pointer to the value of the pdwEffect parameter of the DoDragDrop function. On return, must contain one of the
			/// DROPEFFECT flags, which indicates what the result of the drop operation would be.
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
			/// <term>The pdwEffect parameter is NULL on input.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>There was insufficient memory available for this operation.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>
			/// You do not call <c>DragEnter</c> directly; instead the DoDragDrop function calls it to determine the effect of a drop the
			/// first time the user drags the mouse into the registered window of a drop target.
			/// </para>
			/// <para>
			/// To implement <c>DragEnter</c>, you must determine whether the target can use the data in the source data object by checking
			/// three things:
			/// </para>
			/// <list type="bullet">
			/// <item>
			/// <term>The format and medium specified by the data object</term>
			/// </item>
			/// <item>
			/// <term>The input value of pdwEffect</term>
			/// </item>
			/// <item>
			/// <term>The state of the modifier keys</term>
			/// </item>
			/// </list>
			/// <para>
			/// To check the format and medium, use the IDataObject pointer passed in the pDataObject parameter to call
			/// IDataObject::EnumFormatEtc so you can enumerate the FORMATETC structures the source data object supports. Then call
			/// IDataObject::QueryGetData to determine whether the data object can render the data on the target by examining the formats and
			/// medium specified for the data object.
			/// </para>
			/// <para>
			/// On entry to <c>IDropTarget::DragEnter</c>, the pdwEffect parameter is set to the effects given to the pdwOkEffect parameter
			/// of the DoDragDrop function. The <c>IDropTarget::DragEnter</c> method must choose one of these effects or disable the drop.
			/// </para>
			/// <para>The following modifier keys affect the result of the drop.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Key Combination</term>
			/// <term>User-Visible Feedback</term>
			/// <term>Drop Effect</term>
			/// </listheader>
			/// <item>
			/// <term>CTRL + SHIFT</term>
			/// <term>=</term>
			/// <term>DROPEFFECT_LINK</term>
			/// </item>
			/// <item>
			/// <term>CTRL</term>
			/// <term>+</term>
			/// <term>DROPEFFECT_COPY</term>
			/// </item>
			/// <item>
			/// <term>No keys or SHIFT</term>
			/// <term>None</term>
			/// <term>DROPEFFECT_MOVE</term>
			/// </item>
			/// </list>
			/// <para>
			/// On return, the method must write the effect, one of the DROPEFFECT flags, to the pdwEffect parameter. DoDragDrop then takes
			/// this parameter and writes it to its pdwEffect parameter. You communicate the effect of the drop back to the source through
			/// <c>DoDragDrop</c> in the pdwEffect parameter. The <c>DoDragDrop</c> function then calls IDropSource::GiveFeedback so that the
			/// source application can display the appropriate visual feedback to the user through the target window.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/oleidl/nf-oleidl-idroptarget-dragenter HRESULT DragEnter( IDataObject
			// *pDataObj, DWORD grfKeyState, POINTL pt, DWORD *pdwEffect );
			[PreserveSig]
			HRESULT DragEnter([In] IDataObject pDataObj, [In] uint grfKeyState, [In] Point pt, [In, Out] ref DROPEFFECT pdwEffect);

			/// <summary>
			/// Provides target feedback to the user and communicates the drop's effect to the DoDragDrop function so it can communicate the
			/// effect of the drop back to the source.
			/// </summary>
			/// <param name="grfKeyState">
			/// The current state of the keyboard modifier keys on the keyboard. Valid values can be a combination of any of the flags
			/// MK_CONTROL, MK_SHIFT, MK_ALT, MK_BUTTON, MK_LBUTTON, MK_MBUTTON, and MK_RBUTTON.
			/// </param>
			/// <param name="pt">A POINTL structure containing the current cursor coordinates in screen coordinates.</param>
			/// <param name="pdwEffect">
			/// On input, pointer to the value of the pdwEffect parameter of the DoDragDrop function. On return, must contain one of the
			/// DROPEFFECT flags, which indicates what the result of the drop operation would be.
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
			/// <term>The pdwEffect value is not valid.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>There was insufficient memory available for this operation.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>
			/// You do not call <c>DragOver</c> directly. The DoDragDrop function calls this method each time the user moves the mouse across
			/// a given target window. <c>DoDragDrop</c> exits the loop if the drag-and-drop operation is canceled, if the user drags the
			/// mouse out of the target window, or if the drop is completed.
			/// </para>
			/// <para>
			/// In implementing <c>IDropTarget::DragOver</c>, you must provide features similar to those in IDropTarget::DragEnter. You must
			/// determine the effect of dropping the data on the target by examining the FORMATETC defining the data object's formats and
			/// medium, along with the state of the modifier keys. The mouse position may also play a role in determining the effect of a
			/// drop. The following modifier keys affect the result of the drop.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Key Combination</term>
			/// <term>User-Visible Feedback</term>
			/// <term>Drop Effect</term>
			/// </listheader>
			/// <item>
			/// <term>CTRL + SHIFT</term>
			/// <term>=</term>
			/// <term>DROPEFFECT_LINK</term>
			/// </item>
			/// <item>
			/// <term>CTRL</term>
			/// <term>+</term>
			/// <term>DROPEFFECT_COPY</term>
			/// </item>
			/// <item>
			/// <term>No keys or SHIFT</term>
			/// <term>None</term>
			/// <term>DROPEFFECT_MOVE</term>
			/// </item>
			/// </list>
			/// <para>
			/// You communicate the effect of the drop back to the source through DoDragDrop in pdwEffect. The <c>DoDragDrop</c> function
			/// then calls IDropSource::GiveFeedback so the source application can display the appropriate visual feedback to the user.
			/// </para>
			/// <para>
			/// On entry to <c>IDropTarget::DragOver</c>, the pdwEffect parameter must be set to the allowed effects passed to the
			/// pdwOkEffect parameter of the DoDragDrop function. The <c>IDropTarget::DragOver</c> method must be able to choose one of these
			/// effects or disable the drop.
			/// </para>
			/// <para>
			/// Upon return, pdwEffect is set to one of the DROPEFFECT flags. This value is then passed to the pdwEffect parameter of
			/// DoDragDrop. Reasonable values are DROPEFFECT_COPY to copy the dragged data to the target, DROPEFFECT_LINK to create a link to
			/// the source data, or DROPEFFECT_MOVE to allow the dragged data to be permanently moved from the source application to the target.
			/// </para>
			/// <para>
			/// You may also wish to provide appropriate visual feedback in the target window. There may be some target feedback already
			/// displayed from a previous call to <c>IDropTarget::DragOver</c> or from the initial IDropTarget::DragEnter. If this feedback
			/// is no longer appropriate, you should remove it.
			/// </para>
			/// <para>
			/// For efficiency reasons, a data object is not passed in <c>IDropTarget::DragOver</c>. The data object passed in the most
			/// recent call to IDropTarget::DragEnter is available and can be used.
			/// </para>
			/// <para>
			/// When <c>IDropTarget::DragOver</c> has completed its operation, the DoDragDrop function calls IDropSource::GiveFeedback so the
			/// source application can display the appropriate visual feedback to the user.
			/// </para>
			/// <para>Notes to Implementers</para>
			/// <para>
			/// This function is called frequently during the DoDragDrop loop so it makes sense to optimize your implementation of the
			/// <c>DragOver</c> method as much as possible.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/oleidl/nf-oleidl-idroptarget-dragover HRESULT DragOver( DWORD
			// grfKeyState, POINTL pt, DWORD *pdwEffect );
			[PreserveSig]
			HRESULT DragOver([In] uint grfKeyState, [In] Point pt, [In, Out] ref DROPEFFECT pdwEffect);

			/// <summary>Removes target feedback and releases the data object.</summary>
			/// <returns>
			/// <para>This method returns S_OK on success. Other possible values include the following.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>There is insufficient memory available for this operation.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>You do not call this method directly. The DoDragDrop function calls this method in either of the following cases:</para>
			/// <list type="bullet">
			/// <item>
			/// <term>When the user drags the cursor out of a given target window.</term>
			/// </item>
			/// <item>
			/// <term>When the user cancels the current drag-and-drop operation.</term>
			/// </item>
			/// </list>
			/// <para>
			/// To implement <c>IDropTarget::DragLeave</c>, you must remove any target feedback that is currently displayed. You must also
			/// release any references you hold to the data transfer object.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/oleidl/nf-oleidl-idroptarget-dragleave HRESULT DragLeave( );
			[PreserveSig]
			HRESULT DragLeave();

			/// <summary>Incorporates the source data into the target window, removes target feedback, and releases the data object.</summary>
			/// <param name="pDataObj">
			/// A pointer to the IDataObject interface on the data object being transferred in the drag-and-drop operation.
			/// </param>
			/// <param name="grfKeyState">
			/// The current state of the keyboard modifier keys on the keyboard. Possible values can be a combination of any of the flags
			/// MK_CONTROL, MK_SHIFT, MK_ALT, MK_BUTTON, MK_LBUTTON, MK_MBUTTON, and MK_RBUTTON.
			/// </param>
			/// <param name="pt">A POINTL structure containing the current cursor coordinates in screen coordinates.</param>
			/// <param name="pdwEffect">
			/// On input, pointer to the value of the pdwEffect parameter of the DoDragDrop function. On return, must contain one of the
			/// DROPEFFECT flags, which indicates what the result of the drop operation would be.
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
			/// <term>The pdwEffect parameter is not valid.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>There is insufficient memory available for this operation.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>
			/// You do not call this method directly. The DoDragDrop function calls this method when the user completes the drag-and-drop operation.
			/// </para>
			/// <para>
			/// In implementing <c>Drop</c>, you must incorporate the data object into the target. Use the formats available in IDataObject,
			/// available through pDataObj, along with the current state of the modifier keys to determine how the data is to be
			/// incorporated, such as linking or embedding.
			/// </para>
			/// <para>In addition to incorporating the data, you must also clean up as you do in the IDropTarget::DragLeave method:</para>
			/// <list type="bullet">
			/// <item>
			/// <term>Remove any target feedback that is currently displayed.</term>
			/// </item>
			/// <item>
			/// <term>Release any references to the data object.</term>
			/// </item>
			/// </list>
			/// <para>
			/// You also pass the effect of this operation back to the source application through DoDragDrop, so the source application can
			/// clean up after the drag-and-drop operation is complete:
			/// </para>
			/// <list type="bullet">
			/// <item>
			/// <term>Remove any source feedback that is being displayed.</term>
			/// </item>
			/// <item>
			/// <term>Make any necessary changes to the data, such as removing the data if the operation was a move.</term>
			/// </item>
			/// </list>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/oleidl/nf-oleidl-idroptarget-drop HRESULT Drop( IDataObject *pDataObj,
			// DWORD grfKeyState, POINTL pt, DWORD *pdwEffect );
			[PreserveSig]
			HRESULT Drop([In] IDataObject pDataObj, [In] uint grfKeyState, [In] Point pt, [In, Out] ref DROPEFFECT pdwEffect);
		}

		/// <summary>
		/// Enumerates the different verbs available for an object in order of ascending verb number. An enumerator that implements the
		/// <c>IEnumOLEVERB</c> interface is returned by IOleObject::EnumVerbs.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nn-oleidl-ienumoleverb
		[PInvokeData("oleidl.h", MSDNShortId = "fc9b3474-6f56-4274-af7d-72e0920c0457")]
		[ComImport, Guid("00000104-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IEnumOLEVERB
		{
			/// <summary>Retrieves the specified number of items in the enumeration sequence.</summary>
			/// <param name="celt">
			/// The number of items to be retrieved. If there are fewer than the requested number of items left in the sequence, this method
			/// retrieves the remaining elements.
			/// </param>
			/// <param name="rgelt">
			/// An array of enumerated items.
			/// <para>
			/// The enumerator is responsible for allocating any memory, and the caller is responsible for freeing it.If celt is greater than
			/// 1, the caller must also pass a non-NULL pointer passed to pceltFetched to know how many pointers to release.
			/// </para>
			/// </param>
			/// <param name="pceltFetched">
			/// The number of items that were retrieved. This parameter is always less than or equal to the number of items requested. This
			/// parameter can be NULL if celt is 1.
			/// </param>
			/// <returns>If the method retrieves the number of items requested, the return value is S_OK. Otherwise, it is S_FALSE.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-ienumoleverb-next HRESULT Next( ULONG celt, LPOLEVERB
			// rgelt, ULONG *pceltFetched );
			[PInvokeData("oleidl.h", MSDNShortId = "bb934017-9054-42b5-89d4-a24f12829503")]
			[PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
			HRESULT Next([In] uint celt,
				[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] OLEVERB[] rgelt,
				out uint pceltFetched);

			/// <summary>Skips over the specified number of items in the enumeration sequence.</summary>
			/// <param name="celt">The number of items to be skipped.</param>
			/// <returns>If the method skips the number of items requested, the return value is S_OK. Otherwise, it is S_FALSE.</returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-ienumoleverb-skip HRESULT Skip( ULONG celt );
			[PInvokeData("oleidl.h", MSDNShortId = "f949f993-1c4c-4d42-ba23-93330f0e9967")]
			[PreserveSig, MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
			HRESULT Skip([In] uint celt);

			/// <summary>Resets the enumeration sequence to the beginning.</summary>
			/// <remarks>
			/// There is no guarantee that the same set of objects will be enumerated after the reset operation has completed. A static
			/// collection is reset to the beginning, but it can be too expensive for some collections, such as files in a directory, to
			/// guarantee this condition.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-ienumoleverb-reset HRESULT Reset( );
			[PInvokeData("oleidl.h", MSDNShortId = "612a364a-e7c2-4efd-b55c-1050891f5e22")]
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
			void Reset();

			/// <summary>
			/// Enumerates the different verbs available for an object in order of ascending verb number. An enumerator that implements the
			/// <c>IEnumOLEVERB</c> interface is returned by IOleObject::EnumVerbs.
			/// </summary>
			/// <returns>
			/// A pointer to an IEnumOLEVERB pointer variable that receives the interface pointer to the enumeration object. If the method is
			/// unsuccessful, the value of this output variable is undefined.
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nn-oleidl-ienumoleverb
			[PInvokeData("oleidl.h", MSDNShortId = "fc9b3474-6f56-4274-af7d-72e0920c0457")]
			[MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
			[return: MarshalAs(UnmanagedType.Interface)]
			IEnumOLEVERB Clone();
		}

		/// <summary>
		/// Manages advisory connections and compound document notifications in an object server. Its methods are intended to be used to
		/// implement the advisory methods of IOleObject. <c>IOleAdviseHolder</c> is implemented on an advise holder object. Its methods
		/// establish and delete advisory connections from the object managed by the server to the object's container, which must contain an
		/// advise sink (support the IAdviseSink interface). The advise holder object must also keep track of which advise sinks are
		/// interested in which notifications and pass along the notifications as appropriate.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nn-oleidl-ioleadviseholder
		[PInvokeData("oleidl.h", MSDNShortId = "680afee7-2bee-4d54-ae0b-3e4e0deb622f")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("00000111-0000-0000-C000-000000000046")]
		public interface IOleAdviseHolder
		{
			/// <summary>
			/// Establishes an advisory connection between an OLE object and the calling object's advise sink. Through that sink, the calling
			/// object can receive notification when the OLE object is renamed, saved, or closed.
			/// </summary>
			/// <param name="pAdvise">A pointer to the IAdviseSink interface on the advisory sink that should be informed of changes.</param>
			/// <param name="pdwConnection">
			/// A pointer to a token that can be passed to the IOleAdviseHolder::Unadvise method to delete the advisory connection. The
			/// calling object is responsible for calling both IUnknown::AddRef and IUnknown::Release on this pointer.
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
			/// <term>The supplied IAdviseSink interface pointer is invalid.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>
			/// Containers, object handlers, and link objects all create advise sinks to receive notification of changes in compound-document
			/// objects of interest, such as embedded or linked objects. OLE objects of interest to these objects must implement the
			/// IOleObject interface, which includes several advisory methods, including IOleObject::Advise. A call to this method must set
			/// up an advisory connection with any advise sink that calls it, and maintain each connection until it is closed. It must be
			/// able to handle more than one advisory connection at a time.
			/// </para>
			/// <para>
			/// <c>IOleAdviseHolder::Advise</c> is intended to be used to simplify the implementation of IOleObject::Advise. You can get a
			/// pointer to the OLE implementation of IOleAdviseHolder by calling CreateOleAdviseHolder, and then, to implement
			/// <c>IOleObject::Advise</c>, just delegate the call to <c>IOleAdviseHolder::Advise</c>. Other IOleAdviseHolder methods are
			/// intended to implement other IOleObject advisory methods.
			/// </para>
			/// <para>
			/// If the attempt to establish an advisory connection is successful, the object receiving the call returns a nonzero value
			/// through pdwConnection. If the attempt fails, the object returns a zero. To delete an advisory connection, the object with the
			/// advise sink passes this nonzero token back to the object by calling <c>IOleAdviseHolder::Advise</c>.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-ioleadviseholder-advise HRESULT Advise( IAdviseSink
			// *pAdvise, DWORD *pdwConnection );
			[PreserveSig]
			HRESULT Advise([In] IAdviseSink pAdvise, out uint pdwConnection);

			/// <summary>Deletes a previously established advisory connection.</summary>
			/// <param name="dwConnection">The value previously returned by IOleAdviseHolder::Advise in pdwConnection.</param>
			/// <returns>
			/// <para>This method returns S_OK on success. Other possible return values include the following.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>OLE_E_NOCONNECTION</term>
			/// <term>The dwConnection parameter does not represent a valid advisory connection.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>
			/// <c>IOleAdviseHolder::Unadvise</c> is intended to be used to implement IOleObject::Unadvise to delete an advisory connection.
			/// In general, you would use the OLE advise holder having obtained a pointer through a call to CreateOleAdviseHolder.
			/// </para>
			/// <para>
			/// Typically, containers call this method at shutdown or when an object is deleted. In certain cases, containers could call this
			/// method on objects that are running but not currently visible, as a way of reducing the overhead of maintaining multiple
			/// advisory connections.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-ioleadviseholder-unadvise HRESULT Unadvise( DWORD
			// dwConnection );
			[PreserveSig]
			HRESULT Unadvise(uint dwConnection);

			/// <summary>Creates an enumerator that can be used to enumerate the advisory connections currently established for an object.</summary>
			/// <param name="ppenumAdvise">
			/// A pointer to an IEnumSTATDATA pointer variable that receives the interface pointer to the new enumerator. If this parameter
			/// is NULL, there are presently no advisory connections on the object, or an error occurred. The advise holder is responsible
			/// for incrementing the reference count on the IEnumSTATDATA pointer this method supplies. It is the caller's responsibility to
			/// call IUnknown::Release when it is finished with the pointer.
			/// </param>
			/// <returns>This method returns S_OK on success.</returns>
			/// <remarks>
			/// <para>
			/// <c>IOleAdviseHolder::EnumAdvise</c> creates an enumerator that can be used to enumerate an object's established advisory
			/// connections. The method supplies a pointer to the IEnumSTATDATA interface on this enumerator. Advisory connection information
			/// for each connection is stored in the STATDATA structure, and the enumerator must be able to enumerate these structures.
			/// </para>
			/// <para>
			/// For this method, the only relevant structure members are <c>pAdvise</c> and <c>dwConnection</c>. Other members contain data
			/// advisory information. When you call the enumeration methods, and while an enumeration is in progress, the effect of
			/// registering or revoking advisory connections on what is to be enumerated is undefined.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-ioleadviseholder-enumadvise HRESULT EnumAdvise(
			// IEnumSTATDATA **ppenumAdvise );
			[PreserveSig]
			HRESULT EnumAdvised(out IEnumSTATDATA ppenumAdvise);

			/// <summary>
			/// Sends notification to all advisory sinks currently registered with the advise holder that the name of object has changed.
			/// </summary>
			/// <param name="pmk">A pointer to the new full moniker of the object.</param>
			/// <returns>This method returns S_OK if advise sinks were sent IAdviseSink::OnRename notifications.</returns>
			/// <remarks>
			/// <c>SendOnRename</c> calls IAdviseSink::OnRename to advise the calling object, which must have already established an advisory
			/// connection, that the object has a new moniker. If you are using the OLE advise holder (having obtained a pointer through a
			/// call to CreateOleAdviseHolder), you can call <c>SendOnRename</c> in the implementation of IOleObject::SetMoniker, when you
			/// have determined that the operation is successful.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-ioleadviseholder-sendonrename HRESULT SendOnRename(
			// IMoniker *pmk );
			[PreserveSig]
			HRESULT SendOnRename(IMoniker pmk);

			/// <summary>
			/// Sends notification to all advisory sinks currently registered with the advise holder that the object has been saved.
			/// </summary>
			/// <returns>This method returns S_OK if advise sinks were sent IAdviseSink::OnSave notifications.</returns>
			/// <remarks>
			/// <para>
			/// <c>SendOnSave</c> calls IAdviseSink::OnSave to advise the calling object (client), which must have already established an
			/// advisory connection, that the object has been saved. If you are using the OLE advise holder (having obtained a pointer
			/// through a call to CreateOleAdviseHolder), you can call <c>SendOnSave</c> whenever you save the object the advise holder is
			/// associated with.
			/// </para>
			/// <para>
			/// To take the object from the running state to the loaded state, the client calls IOleObject::Close. Within that
			/// implementation, if the user wants to save the object to persistent storage, the object calls IOleClientSite::SaveObject,
			/// followed by the call to <c>SendOnSave</c>.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-ioleadviseholder-sendonsave HRESULT SendOnSave( );
			[PreserveSig]
			HRESULT SendOnSave();

			/// <summary>Sends notification to all advisory sinks currently registered with the advise holder that the object has closed.</summary>
			/// <returns>
			/// This method returns S_OK if advise sinks were notified of the close operation through a call to the IAdviseSink::OnClose method.
			/// </returns>
			/// <remarks>
			/// <c>SendOnClose</c> must call IAdviseSink::OnClose on all advise sinks that have a valid advisory connection with the object,
			/// whenever the object goes from the running state to the loaded state. This occurs through a call to IOleObject::Close, so you
			/// can call <c>SendOnClose</c> when you determine that a Close operation has been successful.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-ioleadviseholder-sendonclose HRESULT SendOnClose( );
			[PreserveSig]
			HRESULT SendOnClose();
		}

		/// <summary>
		/// Provides control of the presentation data that gets cached inside of an object. Cached presentation data is available to the
		/// container of the object even when the server application is not running or is unavailable.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nn-oleidl-iolecache
		[PInvokeData("oleidl.h", MSDNShortId = "b5ef85d0-b54e-4831-87f1-ac6763179181")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("0000011e-0000-0000-C000-000000000046")]
		public interface IOleCache
		{
			/// <summary>Specifies the format and other data to be cached inside an embedded object.</summary>
			/// <param name="pformatetc">
			/// A pointer to a FORMATETC structure that specifies the format and other data to be cached. View caching is specified by
			/// passing a zero clipboard format in pformatetc.
			/// </param>
			/// <param name="advf">
			/// A group of flags that control the caching. Possible values come from the ADVF enumeration. When used in this context, for a
			/// cache, these values have specific meanings, which are outlined in Remarks. Refer to the <c>ADVF</c> enumeration for a more
			/// detailed description.
			/// </param>
			/// <returns>
			/// A variable that receives the identifier of this connection, which can later be used to turn caching off (by passing it to
			/// IOleCache::Uncache). If this value is 0, the connection was not established. The OLE-provided implementation uses nonzero
			/// numbers for connection identifiers.
			/// </returns>
			/// <remarks>
			/// <para>
			/// <c>IOleCache::Cache</c> can specify either data caching or view (presentation) caching. To specify data caching, a valid data
			/// format must be passed in pformatetc. For view caching, the cache object itself decides on the format to cache, so a caller
			/// would pass a zero data format in pformatetc as follows:
			/// </para>
			/// <para>
			/// A custom object handler can choose not to store data in a given format. Instead, it can synthesize it on demand when requested.
			/// </para>
			/// <para>
			/// The advf value specifies a member of the ADVF enumeration. When one of these values (or an OR'd combination of more than one
			/// value) is used in this context, these values mean the following.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>ADVF Value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>ADVF_NODATA</term>
			/// <term>
			/// The cache is not to be updated by changes made to the running object. Instead, the container will update the cache by
			/// explicitly calling IOleCache::SetData, IDataObject::SetData, or IOleCache2::UpdateCache. This flag is usually used when the
			/// iconic aspect of an object is being cached.
			/// </term>
			/// </item>
			/// <item>
			/// <term>ADVF_ONLYONCE</term>
			/// <term>
			/// Update the cache one time only. After the update is complete, the advisory connection between the object and the cache is
			/// disconnected. The source object for the advisory connection calls the Release method.
			/// </term>
			/// </item>
			/// <item>
			/// <term>ADVF_PRIMEFIRST</term>
			/// <term>
			/// The object is not to wait for the data or view to change before updating the cache. OR'd with ADVF_ONLYONCE, this parameter
			/// provides an asynchronous IDataObject::GetData call.
			/// </term>
			/// </item>
			/// <item>
			/// <term>ADVFCACHE_NOHANDLER</term>
			/// <term>Synonym for ADVFCACHE_FORCEBUILTIN.</term>
			/// </item>
			/// <item>
			/// <term>ADVFCACHE_FORCEBUILTIN</term>
			/// <term>
			/// Used by DLL object applications and object handlers that draw their objects to cache presentation data to ensure that there
			/// is a presentation in the cache. This ensures that the data can be retrieved even when the object or handler code is not available.
			/// </term>
			/// </item>
			/// <item>
			/// <term>ADVFCACHE_ONSAVE</term>
			/// <term>
			/// Updates the cached representation only when the object containing the cache is saved. The cache is also updated when the OLE
			/// object changes from the running state back to the loaded state (because a subsequent save operation would require running the
			/// object again).
			/// </term>
			/// </item>
			/// </list>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-iolecache-cache HRESULT Cache( FORMATETC *pformatetc,
			// DWORD advf, DWORD *pdwConnection );
			uint Cache(in FORMATETC pformatetc, ADVF advf);

			/// <summary>Removes a cache connection created previously using IOleCache::Cache.</summary>
			/// <param name="dwConnection">
			/// The cache connection to be removed. This nonzero value was returned by IOleCache::Cache when the cache was originally established.
			/// </param>
			/// <remarks>
			/// The <c>IOleCache::Uncache</c> method removes a cache connection that was created in a prior call to IOleCache::Cache. It uses
			/// the dwConnection parameter that was returned by the prior call to <c>IOleCache::Cache</c>.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-iolecache-uncache HRESULT Uncache( DWORD dwConnection );
			void Uncache(uint dwConnection);

			/// <summary>Creates an enumerator that can be used to enumerate the current cache connections.</summary>
			/// <returns>
			/// A pointer to an IEnumSTATDATA pointer variable that receives the interface pointer to the new enumerator object. If this
			/// parameter is NULL, there are no cache connections at this time.
			/// </returns>
			/// <remarks>
			/// The enumerator object returned by this method implements the IEnumSTATDATA interface. <c>IEnumSTATDATA</c> enumerates the
			/// data stored in an array of STATDATA structures containing information about current cache connections.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-iolecache-enumcache
			IEnumSTATDATA EnumCache();

			/// <summary>Fills the cache as needed using the data provided by the specified data object.</summary>
			/// <param name="pDataObject">A pointer to the IDataObject interface on the data object from which the cache is to be initialized.</param>
			/// <remarks>
			/// <c>InitCache</c> is usually used when creating an object from a drag-and-drop operation or from a clipboard paste operation.
			/// It fills the cache as needed with presentation data from all the data formats provided by the data object provided on the
			/// clipboard or in the drag-and-drop operation. Helper functions like OleCreateFromData or OleCreateLinkFromData call this
			/// method when needed. If a container does not use these helper functions to create compound document objects, it can use
			/// IOleCache::Cache to set up the cache entries which are then filled by <c>InitCache</c>.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-iolecache-initcache HRESULT InitCache( IDataObject
			// *pDataObject );
			void InitCache(IDataObject pDataObject);

			/// <summary>Initializes the cache with data in a specified format and on a specified medium.</summary>
			/// <param name="pformatetc">
			/// A pointer to a FORMATETC structure that specifies the format of the presentation data being placed in the cache.
			/// </param>
			/// <param name="pmedium">
			/// A pointer to a STGMEDIUM structure that specifies the storage medium that contains the presentation data.
			/// </param>
			/// <param name="fRelease">
			/// Indicates the ownership of the storage medium after completion of the method. If fRelease is <c>TRUE</c>, the cache takes
			/// ownership, freeing the medium when it is finished using it. When fRelease is <c>FALSE</c>, the caller retains ownership and
			/// is responsible for freeing the medium. The cache can only use the storage medium for the duration of the call.
			/// </param>
			/// <remarks>
			/// <para>
			/// <c>IOleCache::SetData</c> is usually called when an object is created from the clipboard or through a drag-and-drop
			/// operation, and Embed Source data is used to create the object.
			/// </para>
			/// <para>
			/// <c>IOleCache::SetData</c> and IOleCache::InitCache are very similar. There are two main differences. The first difference is
			/// that while <c>IOleCache::InitCache</c> initializes the cache with the presentation format provided by the data object,
			/// <c>IOleCache::SetData</c> initializes it with a single format. Second, the <c>IOleCache::SetData</c> method ignores the
			/// ADVF_NODATA flag while <c>IOleCache::InitCache</c> obeys this flag.
			/// </para>
			/// <para>A container can use this method to maintain a single aspect of an object, such as the icon aspect of the object.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-iolecache-setdata HRESULT SetData( FORMATETC *pformatetc,
			// STGMEDIUM *pmedium, BOOL fRelease );
			void SetData(in FORMATETC pformatetc, in STGMEDIUM pmedium, [MarshalAs(UnmanagedType.Bool)] bool fRelease);
		}

		/// <summary>
		/// <para>
		/// Provides the primary means by which an embedded object obtains information about the location and extent of its display site, its
		/// moniker, its user interface, and other resources provided by its container. An object server calls <c>IOleClientSite</c> to
		/// request services from the container. A container must provide one instance of <c>IOleClientSite</c> for every compound-document
		/// object it contains.
		/// </para>
		/// <para><c>Note</c> This interface is not supported for use across machine boundaries.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nn-oleidl-ioleclientsite
		[PInvokeData("oleidl.h", MSDNShortId = "dafee149-926a-4d08-a43d-5847682db645")]
		[ComImport, Guid("00000118-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IOleClientSite
		{
			/// <summary>
			/// Saves the embedded object associated with the client site. This function is synchronous; by the time it returns, the save
			/// will be completed.
			/// </summary>
			/// <returns>
			/// <para>This method returns S_OK on success. Other possible return values include the following.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>E_FAIL</term>
			/// <term>The operation has failed.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>
			/// An embedded object calls <c>SaveObject</c> to ask its container to save it to persistent storage when an end user chooses the
			/// File Update or Exit commands. The call is synchronous, meaning that by the time it returns, the save operation will be completed.
			/// </para>
			/// <para>
			/// Calls to <c>SaveObject</c> occur in most implementations of IOleObject::Close. Normally, when a container tells an object to
			/// close, the container passes a flag specifying whether the object should save itself before closing, prompt the user for
			/// instructions, or close without saving itself. If an object is instructed to save itself, either by its container or an end
			/// user, it calls <c>SaveObject</c> to ask the container application to save the object's contents before the object closes
			/// itself. If a container instructs an object not to save itself, the object should not call <c>SaveObject</c>.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-ioleclientsite-saveobject HRESULT SaveObject( );
			[PreserveSig]
			HRESULT SaveObject();

			/// <summary>
			/// Retrieves a moniker for the object's client site. An object can force the assignment of its own or its container's moniker by
			/// specifying a value for dwAssign.
			/// </summary>
			/// <param name="dwAssign">
			/// Specifies whether to get a moniker only if one already exists, force assignment of a moniker, create a temporary moniker, or
			/// remove a moniker that has been assigned. In practice, you will usually request that the container force assignment of the
			/// moniker. Possible values are taken from the OLEGETMONIKER enumeration.
			/// </param>
			/// <param name="dwWhichMoniker">
			/// Specifies whether to return the container's moniker, the object's moniker relative to the container, or the object's full
			/// moniker. In practice, you will usually request the object's full moniker. Possible values are taken from the OLEWHICHMK enumeration.
			/// </param>
			/// <param name="ppmk">
			/// A pointer to an IMoniker pointer variable that receives the interface pointer to the moniker for the object's client site. If
			/// an error occurs, the implementation must set ppmk to <c>NULL</c>. Each time a container receives a call to
			/// <c>IOleClientSite::GetMoniker</c>, it must increase the reference count on the ppmk pointer it returns. It is the caller's
			/// responsibility to call Release when it is finished with the pointer.
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
			/// <term>This container cannot assign monikers to objects. This is the case with OLE 1 containers.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>
			/// Containers implement <c>GetMoniker</c> as a way of passing out monikers for their embedded objects to clients that need to
			/// link to those objects.
			/// </para>
			/// <para>
			/// When a link is made to an embedded object or to a pseudo-object within it (a range of cells in a spreadsheet, for example),
			/// the object needs a moniker to construct the composite moniker indicating the source of the link. If the embedded object does
			/// not already have a moniker, it can call <c>GetMoniker</c> to request one.
			/// </para>
			/// <para>
			/// Every container that expects to contain links to embeddings should support <c>GetMoniker</c> to give out
			/// OLEWHICHMK_CONTAINER, thus enabling link tracking when the link client and link source files move, but maintain the same
			/// relative position.
			/// </para>
			/// <para>
			/// An object must not persistently store its full moniker or its container's moniker, because these can change while the object
			/// is not loaded. For example, either the container or the object could be renamed, in which event, storing the container's
			/// moniker or the object's full moniker would make it impossible for a client to track a link to the object.
			/// </para>
			/// <para>
			/// In some very specialized cases, an object may no longer need a moniker previously assigned to it and may wish to have it
			/// removed as an optimization. In such cases, the object can call <c>GetMoniker</c> with OLEGETMONIKER_UNASSIGN to have the
			/// moniker removed.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-ioleclientsite-getmoniker HRESULT GetMoniker( DWORD
			// dwAssign, DWORD dwWhichMoniker, IMoniker **ppmk );
			[PreserveSig]
			HRESULT GetMoniker(OLEGETMONIKER dwAssign, OLEWHICHMK dwWhichMoniker, out IMoniker ppmk);

			/// <summary>Retrieves a pointer to the object's container.</summary>
			/// <param name="ppContainer">
			/// Address of IOleContainer pointer variable that receives the interface pointer to the container object. If an error occurs,
			/// the implementation must set ppContainer to <c>NULL</c>.
			/// </param>
			/// <returns>
			/// <para>This method returns S_OK on success. Other possible return values include the following.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>OLE_E_NOT_SUPPORTED</term>
			/// <term>The client site is in an OLE 1 container.</term>
			/// </item>
			/// <item>
			/// <term>E_NOINTERFACE</term>
			/// <term>The container does not implement the IOleContainer interface.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>
			/// If a container supports links to its embedded objects, implementing <c>GetContainer</c> enables link clients to enumerate the
			/// container's objects and recursively traverse a containment hierarchy. This method is optional but recommended for all
			/// containers that expect to support links to their embedded objects.
			/// </para>
			/// <para>
			/// Link clients can traverse a hierarchy of compound-document objects by recursively calling <c>GetContainer</c> to get a
			/// pointer to the link source's container; followed by QueryInterface to get a pointer to the container's IOleObject interface
			/// and, finally, IOleObject::GetClientSite to get the container's client site in its container.
			/// </para>
			/// <para>
			/// Simple containers that do not support links to their embedded objects probably do not need to implement this method. Instead,
			/// they can return E_NOINTERFACE and set ppContainer to <c>NULL</c>.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-ioleclientsite-getcontainer HRESULT GetContainer(
			// IOleContainer **ppContainer );
			[PreserveSig]
			HRESULT GetContainer(out IOleContainer ppContainer);

			/// <summary>
			/// Asks a container to display its object to the user. This method ensures that the container itself is visible and not minimized.
			/// </summary>
			/// <returns>
			/// <para>This method returns S_OK on success. Other possible return values include the following.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>OLE_E_NOT_SUPPORTED</term>
			/// <term>Client site is in an OLE 1 container.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>
			/// After a link client binds to a link source, it commonly calls IOleObject::DoVerb on the link source, usually requesting the
			/// source to perform some action requiring that it display itself to the user. As part of its implementation of
			/// <c>IOleObject::DoVerb</c>, the link source can call <c>ShowObject</c>, which forces the client to show the link source as
			/// best it can. If the link source's container is itself an embedded object, it will recursively invoke <c>ShowObject</c> on its
			/// own container.
			/// </para>
			/// <para>
			/// Having called the <c>ShowObject</c> method, a link source has no guarantee of being appropriately displayed because its
			/// container may not be able to do so at the time of the call. The <c>ShowObject</c> method does not guarantee visibility, only
			/// that the container will do the best it can.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-ioleclientsite-showobject HRESULT ShowObject( );
			[PreserveSig]
			HRESULT ShowObject();

			/// <summary>
			/// Notifies a container when an embedded object's window is about to become visible or invisible. This method does not apply to
			/// an object that is activated in place and therefore has no window separate from that of its container.
			/// </summary>
			/// <param name="fShow">Indicates whether an object's window is open (TRUE) or closed (FALSE).</param>
			/// <returns>This method returns S_OK on success.</returns>
			/// <remarks>
			/// An embedded object calls <c>OnShowWindow</c> to keep its container informed when the object is open in a window. This window
			/// may or may not be currently visible to the end user. The container uses this information to shade the object's client site
			/// when the object is displayed in a window, and to remove the shading when the object is not. A shaded object, having received
			/// this notification, knows that it already has an open window and therefore can respond to being double-clicked by bringing
			/// this window quickly to the top, instead of launching its application in order to obtain a new one.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-ioleclientsite-onshowwindow HRESULT OnShowWindow( BOOL
			// fShow );
			[PreserveSig]
			HRESULT OnShowWindow([MarshalAs(UnmanagedType.Bool)] bool fShow);

			/// <summary>Asks a container to resize the display site for embedded objects.</summary>
			/// <returns>
			/// <para>This method returns S_OK on success. Other possible return values include the following.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>E_NOTIMPL</term>
			/// <term>Client site does not support requests for new layout.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// This method can either increase or decrease the space. Currently, there is no standard mechanism by which a container can
			/// negotiate how much room an object would like. When such a negotiation is defined, responding to this method will be optional
			/// for containers.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-ioleclientsite-requestnewobjectlayout HRESULT
			// RequestNewObjectLayout( );
			[PreserveSig]
			HRESULT RequestNewObjectLayout();
		}

		/// <summary>
		/// Enumerates objects in a compound document or lock a container in the running state. Container and object applications both
		/// implement this interface.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nn-oleidl-iolecontainer
		[PInvokeData("oleidl.h", MSDNShortId = "98549309-8ac8-4391-92ab-8a62269ff579")]
		[ComImport, Guid("0000011b-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IOleContainer : IParseDisplayName
		{
			/// <summary>Parses the specified display name and creates a corresponding moniker.</summary>
			/// <param name="pbc">A pointer to the bind context to be used in this binding operation. See IBindCtx.</param>
			/// <param name="pszDisplayName">The display name to be parsed.</param>
			/// <param name="pchEaten">
			/// A pointer to a variable that receives the number of characters in the display name that correspond to the ppmkOut moniker.
			/// </param>
			/// <param name="ppmkOut">
			/// A pointer to an IMoniker pointer variable that receives the interface pointer to the resulting moniker. If an error occurs,
			/// the implementation sets *ppmkOut to <c>NULL</c>. If *ppmkOut is non- <c>NULL</c>, the implementation must call AddRef; it is
			/// the caller's responsibility to call Release.
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
			/// <term>MK_E_SYNTAX</term>
			/// <term>
			/// There is a syntax error in the display name. Parsing failed because pszDisplayName could only be partially resolved into a
			/// moniker. In this case, *pchEaten has the number of characters that were successfully parsed into a moniker prefix. The
			/// parameter ppmkOut should be NULL.
			/// </term>
			/// </item>
			/// <item>
			/// <term>MK_E_NOOBJECT</term>
			/// <term>The display name does not identify a component in this namespace.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>One or more parameters are not valid.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>
			/// In general, the maximum prefix of pszDisplayName that is syntactically valid and that represents an object should be consumed
			/// by this method and converted to a moniker.
			/// </para>
			/// <para>
			/// Typically, this method is called by MkParseDisplayName or MkParseDisplayNameEx. In the initial step of the parsing operation,
			/// these functions can retrieve the IParseDisplayName interface directly from an instance of a class identified with either the
			/// "@ProgID" or "ProgID" notation. Subsequent parsing steps can query for the interface on an intermediate object.
			/// </para>
			/// <para>
			/// The main loops of MkParseDisplayName and MkParseDisplayNameEx find the next moniker piece by calling the equivalent method in
			/// the IMoniker interface, that is, IMoniker::ParseDisplayName, on the moniker that it currently holds. In this call to
			/// <c>IMoniker::ParseDisplayName</c>, the <c>MkParseDisplayName</c> or <c>MkParseDisplayNameEx</c> function passes <c>NULL</c>
			/// in the pmkToLeft parameter. If the moniker currently held is a generic composite, the call to
			/// <c>IMoniker::ParseDisplayName</c> is forwarded by that composite onto its last piece, passing the prefix of the composite to
			/// the left of the piece in pmkToLeft.
			/// </para>
			/// <para>
			/// Some moniker classes will be able to handle this parsing internally to themselves because they are designed to designate only
			/// certain kinds of objects. Others will need to bind to the object that they designate to accomplish the parsing process. As is
			/// usual, these objects should not be released by IMoniker::ParseDisplayName but instead should be transferred to the bind
			/// context via IBindCtx::RegisterObjectBound or IBindCtx::GetRunningObjectTable followed by IRunningObjectTable::Register for
			/// release at a later time.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-iparsedisplayname-parsedisplayname HRESULT
			// ParseDisplayName( IBindCtx *pbc, LPOLESTR pszDisplayName, ULONG *pchEaten, IMoniker **ppmkOut );
			[PreserveSig]
			new HRESULT ParseDisplayName(IBindCtx pbc, [MarshalAs(UnmanagedType.LPWStr)] string pszDisplayName, out uint pchEaten, out IMoniker ppmkOut);

			/// <summary>Enumerates the objects in the current container.</summary>
			/// <param name="grfFlags">Specifies which objects in a container are to be enumerated, as defined in the enumeration OLECONTF.</param>
			/// <param name="ppenum">
			/// A pointer to an IEnumUnknown pointer variable that receives the interface pointer to the enumerator object. Each time a
			/// container receives a successful call to EnumObjects, it must increase the reference count on the ppenum pointer the method
			/// returns. It is the caller's responsibility to call IUnknown::Release when it is done with the pointer. If an error is
			/// returned, the implementation must set ppenum to NULL.
			/// </param>
			/// <returns>This method returns S_OK on success.</returns>
			/// <remarks>
			/// A container should implement <c>EnumObjects</c> to enable programmatic clients to find out what objects it holds. This
			/// method, however, is not called in standard linking scenarios.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-iolecontainer-enumobjects HRESULT EnumObjects( DWORD
			// grfFlags, IEnumUnknown **ppenum );
			[PreserveSig]
			HRESULT EnumObjects(OLECONTF grfFlags, out IEnumUnknown ppenum);

			/// <summary>Keeps the container for embedded objects running until explicitly released.</summary>
			/// <param name="fLock">Indicates whether to lock ( <c>TRUE</c>) or unlock ( <c>FALSE</c>) a container.</param>
			/// <returns>
			/// <para>This method returns S_OK on success. Other possible return values include the following.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>E_FAIL</term>
			/// <term>The operation failed.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory available for the operation.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// An embedded object calls <c>LockContainer</c> to keep its container running when the object has link clients that require an
			/// update. If an end user selects <c>File Close</c> from the container's menu, however, the container ignores all outstanding
			/// <c>LockContainer</c> locks and closes the document anyway.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-iolecontainer-lockcontainer HRESULT LockContainer( BOOL
			// fLock );
			[PreserveSig]
			HRESULT LockContainer([MarshalAs(UnmanagedType.Bool)] bool fLock);
		}

		/// <summary>
		/// Provides a direct channel of communication between an in-place object and the associated application's outer-most frame window
		/// and the document window within the application that contains the embedded object. The communication involves the translation of
		/// messages, the state of the frame window (activated or deactivated), and the state of the document window (activated or
		/// deactivated). Also, it informs the object when it needs to resize its borders, and manages modeless dialog boxes.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nn-oleidl-ioleinplaceactiveobject
		[PInvokeData("oleidl.h", MSDNShortId = "b077c256-1109-494c-95c2-2d33bccbe47b")]
		[ComImport, Guid("00000117-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IOleInPlaceActiveObject : IOleWindow
		{
			/// <summary>
			/// Retrieves a handle to one of the windows participating in in-place activation (frame, document, parent, or in-place object window).
			/// </summary>
			/// <returns>A pointer to a variable that receives the window handle.</returns>
			new HWND GetWindow();

			/// <summary>Determines whether context-sensitive help mode should be entered during an in-place activation session.</summary>
			/// <param name="fEnterMode"><c>true</c> if help mode should be entered; <c>false</c> if it should be exited.</param>
			new void ContextSensitiveHelp([MarshalAs(UnmanagedType.Bool)] bool fEnterMode);

			/// <summary>Processes menu accelerator-key messages from the container's message queue. This method should only be used for objects created by a DLL object application.</summary>
			/// <param name="lpmsg">A pointer to an MSG structure for the message that might need to be translated.</param>
			/// <returns>
			/// <para>This method returns S_OK on success. Other possible return values include the following.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_FALSE</term>
			/// <term>The message was not translated.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>The specified parameter values are not valid.</term>
			/// </item>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>IThere is insufficient memory available for the operation.</term>
			/// </item>
			/// <item>
			/// <term>E_UNEXPECTED</term>
			/// <term>An unexpected error has occurred.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>Notes to Callers</para>
			/// <para>Active in-place objects must always be given the first chance at translating accelerator keystrokes. You can provide this opportunity by calling <c>IOleInPlaceActiveObject::TranslateAccelerator</c> from your container's message loop before doing any other translation. You should apply your own translation only when this method returns S_FALSE.</para>
			/// <para>If you call <c>IOleInPlaceActiveObject::TranslateAccelerator</c> for an object that is not created by a DLL object application, the default object handler returns S_FALSE.</para>
			/// <para>Notes to Implementers</para>
			/// <para>An object created by an EXE object application gets keystrokes from its own message pump, so the container does not get those messages.</para>
			/// <para>If you need to implement this method, you can do so by simply wrapping the call to the TranslateAccelerator function.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-ioleinplaceactiveobject-translateaccelerator
			// HRESULT TranslateAccelerator( LPMSG lpmsg );
			[PreserveSig]
			HRESULT TranslateAccelerator(in MSG lpmsg);

			/// <summary>
			/// Notifies the object when the container's top-level frame window is activated or deactivated.
			/// </summary>
			/// <param name="fActivate">The state of the container's top-level frame window. This parameter is <c>TRUE</c> if the window is activating and <c>FALSE</c> if it is deactivating.</param>
			// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-ioleinplaceactiveobject-onframewindowactivate
			// HRESULT OnFrameWindowActivate( BOOL fActivate );
			void OnFrameWindowActivate([MarshalAs(UnmanagedType.Bool)] bool fActivate);

			/// <summary>
			/// Notifies the active in-place object when the container's document window is activated or deactivated.
			/// </summary>
			/// <param name="fActivate">The state of the MDI child document window. If this parameter is <c>TRUE</c>, the window is in the act of activating; if it is <c>FALSE</c>, it is in the act of deactivating.</param>
			/// <remarks>
			/// <para>Notes to Callers</para>
			/// <para>Call <c>IOleInPlaceActiveObject::OnDocWindowActivate</c> when the MDI child document window is activated or deactivated and the object is currently the active object for the document.</para>
			/// <para>Notes to Implementers</para>
			/// <para>You should include code in this method that installs frame-level tools during object activation. These tools include the shared composite menu and/or optional toolbars and frame adornments. You should then take focus. When deactivating, the object should remove the frame-level tools. Note that if you do not call IOleInPlaceUIWindow::SetBorderSpace with pborderwidths set to <c>NULL</c>, you can avoid having to renegotiate border space.</para>
			/// <para>While executing <c>IOleInPlaceActiveObject::OnDocWindowActivate</c>, do not make calls to the PeekMessage or GetMessage functions, or a dialog box. Doing so may cause the system to deadlock. There are further restrictions on which OLE interface methods and functions can be called from within <c>IOleInPlaceActiveObject::OnDocWindowActivate</c>.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-ioleinplaceactiveobject-ondocwindowactivate
			// HRESULT OnDocWindowActivate( BOOL fActivate );
			void OnDocWindowActivate([MarshalAs(UnmanagedType.Bool)] bool fActivate);

			/// <summary>Alerts the object that it needs to resize its border space.</summary>
			/// <param name="prcBorder">A pointer to a RECT structure containing the new outer rectangle within which the object can request border space for its tools.</param>
			/// <param name="pUIWindow">A pointer to an IOleInPlaceUIWindow interface pointer for the frame or document window object whose border has changed.</param>
			/// <param name="fFrameWindow">This parameter is <c>TRUE</c> if the frame window object is calling <c>IOleInPlaceActiveObject::ResizeBorder</c>; otherwise, it is <c>FALSE</c>.</param>
			/// <remarks>
			/// <para>Notes to Callers</para>
			/// <para><c>IOleInPlaceActiveObject::ResizeBorder</c> is called by the top-level container's document or frame window object when the border space allocated to the object should change. Because the active in-place object is not informed about which window has changed (the frame- or document-level window), <c>IOleInPlaceActiveObject::ResizeBorder</c> must be passed the pointer to the window's IOleInPlaceUIWindow interface.</para>
			/// <para>Notes to Implemeters</para>
			/// <para>In most cases, resizing only requires that you grow, shrink, or scale your object's frame adornments. However, for more complicated adornments, you may be required to renegotiate for border space with calls to IOleInPlaceUIWindow::SetBorderSpace and <c>IOleInPlaceUIWindow::SetBorderSpace</c>.</para>
			/// <para><c>Note</c> While executing <c>IOleInPlaceActiveObject::ResizeBorder</c>, do not make calls to the PeekMessage or GetMessage functions, or a dialog box. Doing so may cause the system to deadlock. There are further restrictions on which OLE interface methods and functions can be called from within <c>IOleInPlaceActiveObject::ResizeBorder</c>.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-ioleinplaceactiveobject-resizeborder
			// HRESULT ResizeBorder( LPCRECT prcBorder, IOleInPlaceUIWindow *pUIWindow, BOOL fFrameWindow );
			void ResizeBorder(in RECT prcBorder, [In] IOleInPlaceUIWindow pUIWindow, [MarshalAs(UnmanagedType.Bool)] bool fFrameWindow);

			/// <summary>Enables or disables modeless dialog boxes when the container creates or destroys a modal dialog box.</summary>
			/// <param name="fEnable">Indicates whether to enable modeless dialog box windows (<c>TRUE</c>) or disable them <c>FALSE</c>.</param>
			// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-ioleinplaceactiveobject-enablemodeless
			// HRESULT EnableModeless( BOOL fEnable );
			void EnableModeless([MarshalAs(UnmanagedType.Bool)] bool fEnable);
		}

		/// <summary>
		/// Controls the container's top-level frame window. This control involves allowing the container to insert its menu group into the
		/// composite menu, install the composite menu into the appropriate window frame, and remove the container's menu elements from the
		/// composite menu. It sets and displays status text relevant to the in-place object. It also enables or disables the frame's
		/// modeless dialog boxes, and translates accelerator keystrokes intended for the container's frame.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nn-oleidl-ioleinplaceframe
		[PInvokeData("oleidl.h", MSDNShortId = "c530aff7-fd83-413d-8945-0c9d1bfb51ba")]
		[ComImport, Guid("00000116-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IOleInPlaceFrame : IOleInPlaceUIWindow
		{
			/// <summary>
			/// Retrieves a handle to one of the windows participating in in-place activation (frame, document, parent, or in-place object window).
			/// </summary>
			/// <returns>A pointer to a variable that receives the window handle.</returns>
			new HWND GetWindow();

			/// <summary>Determines whether context-sensitive help mode should be entered during an in-place activation session.</summary>
			/// <param name="fEnterMode"><c>true</c> if help mode should be entered; <c>false</c> if it should be exited.</param>
			new void ContextSensitiveHelp([MarshalAs(UnmanagedType.Bool)] bool fEnterMode);

			/// <summary>Retrieves the outer rectange for toolbars and controls while the object is active in place.</summary>
			/// <param name="lprectBorder">
			/// A pointer to a RECT structure where the outer rectangle is to be returned. The structure's coordinates are relative to the
			/// window being represented by the interface.
			/// </param>
			/// <remarks>
			/// <para>Notes to Callers</para>
			/// <para>
			/// The <c>IOleInPlaceUIWindow::GetBorder</c> function, when called on a document or frame window object, returns the outer
			/// rectangle (relative to the window) where the object can put toolbars or similar controls.
			/// </para>
			/// <para>
			/// If the object is to install these tools, it should negotiate space for the tools within this rectangle using
			/// IOleInPlaceUIWindow::RequestBorderSpace and then call IOleInPlaceUIWindow::SetBorderSpace to get this space allocated.
			/// </para>
			/// <para>
			/// <c>Note</c> While executing <c>IOleInPlaceUIWindow::GetBorder</c>, do not make calls to the PeekMessage or GetMessage
			/// functions, or a dialog box. Doing so may cause the system to deadlock. There are further restrictions on which OLE interface
			/// methods and functions can be called from within <c>GetBorder</c>.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-ioleinplaceuiwindow-getborder HRESULT GetBorder( LPRECT
			// lprectBorder );
			new void GetBorder(out RECT lprectBorder);

			/// <summary>
			/// Determines whether there is space available for tools to be installed around the object's window frame while the object is
			/// active in place.
			/// </summary>
			/// <param name="pborderwidths">
			/// A pointer to a BORDERWIDTHS structure containing the requested widths (in pixels) needed on each side of the window for the tools.
			/// </param>
			/// <remarks>
			/// <para>Notes to Callers</para>
			/// <para>
			/// The active in-place object calls <c>IOleInPlaceUIWindow::RequestBorderSpace</c> to ask if tools can be installed inside the
			/// window frame. These tools would be allocated between the rectangle returned by IOleInPlaceUIWindow::GetBorder and the
			/// BORDERWIDTHS structure specified in the argument to this call.
			/// </para>
			/// <para>
			/// The space for the tools is not actually allocated to the object until it calls IOleInPlaceUIWindow::SetBorderSpace, allowing
			/// the object to negotiate for space (such as while dragging toolbars around), but deferring the moving of tools until the
			/// action is completed.
			/// </para>
			/// <para>
			/// The object can install these tools by passing the width in pixels that is to be used on each side. For example, if the object
			/// required 10 pixels on the top, 0 pixels on the bottom, and 5 pixels on the left and right sides, it would pass the following
			/// BORDERWIDTHS structure to <c>IOleInPlaceUIWindow::RequestBorderSpace</c>:
			/// </para>
			/// <para>
			/// <c>Note</c> While executing <c>IOleInPlaceUIWindow::RequestBorderSpace</c>, do not make calls to the PeekMessage or
			/// GetMessage functions, or a dialog box. Doing so may cause the system to deadlock. There are further restrictions on which OLE
			/// interface methods and functions can be called from within <c>IOleInPlaceUIWindow::RequestBorderSpace</c>.
			/// </para>
			/// <para>Notes to Implementers</para>
			/// <para>
			/// If the amount of space an active object uses for its toolbars is irrelevant to the container, it can simply return NOERROR as
			/// shown in the following <c>IOleInPlaceUIWindow::RequestBorderSpace</c> example. Containers should not unduly restrict the
			/// display of tools by an active in-place object.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-ioleinplaceuiwindow-requestborderspace HRESULT
			// RequestBorderSpace( LPCBORDERWIDTHS pborderwidths );
			new void RequestBorderSpace(in RECT pborderwidths);

			/// <summary>Allocates space for the border requested in the call to IOleInPlaceUIWindow::RequestBorderSpace.</summary>
			/// <param name="pborderwidths">
			/// Pointer to a BORDERWIDTHS structure containing the requested width of the tools, in pixels. It can be <c>NULL</c>, indicating
			/// the object does not need any space.
			/// </param>
			/// <remarks>
			/// <para>The object must call <c>IOleInPlaceUIWindow::SetBorderSpace</c>. It can do any one of the following:</para>
			/// <list type="bullet">
			/// <item>
			/// <term>Use its own toolbars, requesting border space of a specific size.</term>
			/// </item>
			/// <item>
			/// <term>
			/// Use no toolbars, but force the container to remove its toolbars by passing a valid BORDERWIDTHS structure containing nothing
			/// but zeros in the pborderwidths parameter.
			/// </term>
			/// </item>
			/// <item>
			/// <term>
			/// Use no toolbars but allow the in-place container to leave its toolbars up by passing <c>NULL</c> as the pborderwidths parameter.
			/// </term>
			/// </item>
			/// </list>
			/// <para>
			/// The BORDERWIDTHS structure used in this call would generally have been passed in a previous call to
			/// IOleInPlaceUIWindow::RequestBorderSpace, which must have returned S_OK.
			/// </para>
			/// <para>
			/// If an object must renegotiate space on the border, it can call <c>IOleInPlaceUIWindow::SetBorderSpace</c> again with the new
			/// widths. If the call to <c>IOleInPlaceUIWindow::SetBorderSpace</c> fails, the object can do a full negotiation for border
			/// space with calls to IOleInPlaceUIWindow::GetBorder, IOleInPlaceUIWindow::RequestBorderSpace, and <c>IOleInPlaceUIWindow::SetBorderSpace</c>.
			/// </para>
			/// <para>
			/// <c>Note</c> While executing <c>IOleInPlaceUIWindow::SetBorderSpace</c>, do not make calls to the PeekMessage or GetMessage
			/// functions, or a dialog box. Doing so may cause the system to deadlock. There are further restrictions on which OLE interface
			/// methods and functions can be called from within <c>IOleInPlaceUIWindow::SetBorderSpace</c>.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-ioleinplaceuiwindow-setborderspace HRESULT SetBorderSpace(
			// LPCBORDERWIDTHS pborderwidths );
			new void SetBorderSpace(in RECT pborderwidths);

			/// <summary>Provides a direct channel of communication between the object and each of the frame and document windows.</summary>
			/// <param name="pActiveObject">A pointer to the IOleInPlaceActiveObject interface on the active in-place object.</param>
			/// <param name="pszObjName">
			/// A pointer to a string containing a name that describes the object an embedding container can use in composing its window
			/// title. It can be <c>NULL</c> if the object does not require the container to change its window titles. Containers should
			/// ignore this parameter and always use their own name in the title bar.
			/// </param>
			/// <remarks>
			/// <para>
			/// Generally, an embedded object should pass <c>NULL</c> for the pszObjName parameter (see Notes to Implementers below).
			/// However, if you are working in conjunction with a container that does display the name of the in-place active object in its
			/// title bar, then you should compose a string in the following form: &lt;application name&gt; â€“ &lt;object short-type name&gt;.
			/// </para>
			/// <para>Notes to Callers</para>
			/// <para>
			/// <c>IOleInPlaceUIWindow::SetActiveObject</c> is called by the object to establish a direct communication link between itself
			/// and the document and frame windows.
			/// </para>
			/// <para>
			/// When deactivating, the object calls <c>IOleInPlaceUIWindow::SetActiveObject</c>, passing <c>NULL</c> for the pActiveObject
			/// and pszObjName parameters.
			/// </para>
			/// <para>
			/// An object must call <c>IOleInPlaceUIWindow::SetActiveObject</c> before calling IOleInPlaceFrame::SetMenu to give the
			/// container the pointer to the active object. The container then uses this pointer in processing
			/// <c>IOleInPlaceFrame::SetMenu</c> and to pass to OleSetMenuDescriptor.
			/// </para>
			/// <para>Notes to Implementers</para>
			/// <para>
			/// The Microsoft Windows User Interface Design Guide recommends that an in-place container ignore the pszObjName parameter
			/// passed in this method. The guide says "The title bar is not affected by in-place activation. It always displays the top-level
			/// container's name."
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-ioleinplaceuiwindow-setactiveobject HRESULT
			// SetActiveObject( IOleInPlaceActiveObject *pActiveObject, LPCOLESTR pszObjName );
			new void SetActiveObject([In] IOleInPlaceActiveObject pActiveObject, [MarshalAs(UnmanagedType.LPWStr)] string pszObjName);

			/// <summary>Enables the container to insert menu groups into the composite menu to be used during the in-place session.</summary>
			/// <param name="hmenuShared">A handle to an empty menu.</param>
			/// <param name="lpMenuWidths">
			/// A pointer to an OLEMENUGROUPWIDTHS array with six elements. The container fills in elements 0, 2, and 4 to reflect the number
			/// of menu elements it provided in the <c>File</c>, <c>View</c>, and <c>Window</c> menu groups.
			/// </param>
			/// <remarks>
			/// <para>Notes to Callers</para>
			/// <para>
			/// This method is called by object applications when they are first being activated. They call it to insert their menus into the
			/// frame-level user interface.
			/// </para>
			/// <para>
			/// The object application asks the container to add its menus to the menu specified in hmenuShared and to set the group counts
			/// in the OLEMENUGROUPWIDTHS array pointed to by lpMenuWidths. The object application then adds its own menus and counts.
			/// Objects can call <c>IOleInPlaceFrame::InsertMenus</c> as many times as necessary to build up the composite menus. The
			/// container should use the initial menu handle associated with the composite menu for all menu items in the drop-down menus.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-ioleinplaceframe-insertmenus HRESULT InsertMenus( HMENU
			// hmenuShared, LPOLEMENUGROUPWIDTHS lpMenuWidths );
			void InsertMenus(HMENU hmenuShared, ref OLEMENUGROUPWIDTHS lpMenuWidths);

			/// <summary>Adds a composite menu to the window frame containing the object being activated in place.</summary>
			/// <param name="hmenuShared">
			/// A handle to the composite menu constructed by calls to IOleInPlaceFrame::InsertMenus and the InsertMenu function.
			/// </param>
			/// <param name="holemenu">A handle to the menu descriptor returned by the OleCreateMenuDescriptor function.</param>
			/// <param name="hwndActiveObject">
			/// A handle to a window owned by the object and to which menu messages, commands, and accelerators are to be sent.
			/// </param>
			/// <remarks>
			/// <para>Notes to Callers</para>
			/// <para>
			/// The object calls <c>IOleInPlaceFrame::SetMenu</c> to ask the container to install the composite menu structure set up by
			/// calls to IOleInPlaceFrame::InsertMenus.
			/// </para>
			/// <para>Notes to Implementers</para>
			/// <para>
			/// An SDI container's implementation of this method should call the SetMenu function. An MDI container should send a
			/// WM_MDISETMENU message, using hmenuShared as the menu to install. The container should call OleSetMenuDescriptor to install
			/// the OLE dispatching code.
			/// </para>
			/// <para>
			/// When deactivating, the container must call <c>IOleInPlaceFrame::SetMenu</c>, specifying <c>NULL</c> to remove the shared
			/// menu. This is done to help minimize window repaints. The container should also call OleSetMenuDescriptor, specifying
			/// <c>NULL</c> to unhook the dispatching code. Finally, the object application calls OleDestroyMenuDescriptor to free the data structure.
			/// </para>
			/// <para>
			/// <c>Note</c> While executing <c>IOleInPlaceFrame::SetMenu</c>, do not make calls to the PeekMessage or GetMessage functions,
			/// or a dialog box. Doing so may cause the system to deadlock. There are further restrictions on which OLE interface methods and
			/// functions can be called from within <c>IOleInPlaceFrame::SetMenu</c>.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-ioleinplaceframe-setmenu HRESULT SetMenu( HMENU
			// hmenuShared, HOLEMENU holemenu, HWND hwndActiveObject );
			void SetMenu(HMENU hmenuShared, HOLEMENU holemenu, HWND hwndActiveObject);

			/// <summary>Removes a container's menu elements from the composite menu.</summary>
			/// <param name="hmenuShared">
			/// A handle to the in-place composite menu that was constructed by calls to IOleInPlaceFrame::InsertMenus and the InsertMenu function.
			/// </param>
			/// <remarks>
			/// <para>
			/// The object should always give the container a chance to remove its menu elements from the composite menu before deactivating
			/// the shared user interface.
			/// </para>
			/// <para>Notes to Callers</para>
			/// <para>This method is called by the object application while it is being UI-deactivated to remove its menus.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-ioleinplaceframe-removemenus HRESULT RemoveMenus( HMENU
			// hmenuShared );
			void RemoveMenus(HMENU hmenuShared);

			/// <summary>Sets and displays status text about the in-place object in the container's frame window status line.</summary>
			/// <param name="pszStatusText">The message to be displayed.</param>
			/// <remarks>
			/// <para>Notes to Callers</para>
			/// <para>
			/// You should call <c>IOleInPlaceFrame::SetStatusText</c> when you need to ask the container to display object text in its
			/// frame's status line, if it has one. Because the container's frame window owns the status line, calling
			/// <c>IOleInPlaceFrame::SetStatusText</c> is the only way an object can display status information in the container's frame
			/// window. If the container refuses the object's request, the object application can, however, negotiate for border space to
			/// display its own status window.
			/// </para>
			/// <para>
			/// When switching between menus owned by the container and the in-place active object, the status bar text is not reflected
			/// properly if the object does not call the container's <c>IOleInPlaceFrame::SetStatusText</c> method. For example, if, during
			/// an in-place session, the user were to select the <c>File</c> menu, the status bar would reflect the action that would occur
			/// if the user selected this menu. If the user then selects the <c>Edit</c> menu (which is owned by the in-place object), the
			/// status bar text would not change unless the <c>IOleInPlaceFrame::SetStatusText</c> happened to be called. This is because
			/// there is no way for the container to recognize that one of the object's menus has been made active because all the messages
			/// that the container would trap are now going to the object.
			/// </para>
			/// <para>Notes to Implementers</para>
			/// <para>
			/// To avoid potential problems, all objects being activated in place should process the WM_MENUSELECT message and call
			/// <c>IOleInPlaceFrame::SetStatusText</c> â€”even if the object does not usually provide status information (in which case the
			/// object can just pass a <c>NULL</c> string for the requested status text).
			/// </para>
			/// <para>
			/// <c>Note</c> While executing <c>IOleInPlaceFrame::SetStatusText</c>, do not make calls to the PeekMessage or GetMessage
			/// functions, or a dialog box. Doing so may cause the system to deadlock. There are further restrictions on which OLE interface
			/// methods and functions can be called from within IOleInPlaceUIWindow::GetBorder.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-ioleinplaceframe-setstatustext HRESULT SetStatusText(
			// LPCOLESTR pszStatusText );
			void SetStatusText([MarshalAs(UnmanagedType.LPWStr)] string pszStatusText);

			/// <summary>Enables or disables a frame's modeless dialog boxes.</summary>
			/// <param name="fEnable">
			/// Specifies whether the modeless dialog box windows are to be enabled ( <c>TRUE</c>) or disabled ( <c>FALSE</c>).
			/// </param>
			// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-ioleinplaceframe-enablemodeless HRESULT EnableModeless(
			// BOOL fEnable );
			void EnableModeless([MarshalAs(UnmanagedType.Bool)] bool fEnable);

			/// <summary>Translates accelerator keystrokes intended for the container's frame while an object is active in place.</summary>
			/// <param name="lpmsg">A pointer to the MSG structure that contains the keystroke message.</param>
			/// <param name="wID">
			/// The command identifier value corresponding to the keystroke in the container-provided accelerator table. Containers should
			/// use this value instead of translating again.
			/// </param>
			/// <remarks>
			/// <para>Notes to Callers</para>
			/// <para>
			/// The <c>IOleInPlaceFrame::TranslateAccelerator</c> method is called indirectly by OleTranslateAccelerator when a keystroke
			/// accelerator intended for the container (frame) is received.
			/// </para>
			/// <para>Notes to Implementers</para>
			/// <para>
			/// The container application should perform its usual accelerator processing, or use wID directly, and then return, indicating
			/// whether the keystroke accelerator was processed. If the container is an MDI application and the TranslateAccelerator function
			/// fails, the container can call the TranslateMDISysAccel function, just as it does for its usual message processing.
			/// </para>
			/// <para>
			/// In-place objects should be given first chance at translating accelerator messages. However, because objects implemented by
			/// DLL object applications do not have their own message pump, they receive their messages from the container's message queue.
			/// To ensure that the object has first chance at translating messages, a container should always call
			/// <c>IOleInPlaceFrame::TranslateAccelerator</c> before doing its own accelerator translation. Conversely, an executable object
			/// application should call OleTranslateAccelerator after calling TranslateAccelerator, calling TranslateMessage and
			/// DispatchMessage only if both translation functions fail.
			/// </para>
			/// <para>
			/// You should define accelerator tables for containers so they will work properly with object applications that do their own
			/// accelerator keystroke translations. Tables should be defined as follows.
			/// </para>
			/// <para>
			/// This is the most common way to describe keyboard accelerators. Failure to do so can result in keystrokes being lost or sent
			/// to the wrong object during an in-place session.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-ioleinplaceframe-translateaccelerator HRESULT
			// TranslateAccelerator( LPMSG lpmsg, WORD wID );
			void TranslateAccelerator(in MSG lpmsg, in ushort wID);
		}

		/// <summary>
		/// Implemented by container applications and used by object applications to negotiate border space on the document or frame window.
		/// The container provides a RECT structure in which the object can place toolbars and other similar controls, determines if tools
		/// can in fact be installed around the object's window frame, allocates space for the border, and establishes a communication
		/// channel between the object and each frame and document window.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nn-oleidl-ioleinplaceuiwindow
		[PInvokeData("oleidl.h", MSDNShortId = "3cfb31aa-9746-438c-af64-8236c170fe88")]
		[ComImport, Guid("00000115-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IOleInPlaceUIWindow : IOleWindow
		{
			/// <summary>
			/// Retrieves a handle to one of the windows participating in in-place activation (frame, document, parent, or in-place object window).
			/// </summary>
			/// <returns>A pointer to a variable that receives the window handle.</returns>
			new HWND GetWindow();

			/// <summary>Determines whether context-sensitive help mode should be entered during an in-place activation session.</summary>
			/// <param name="fEnterMode"><c>true</c> if help mode should be entered; <c>false</c> if it should be exited.</param>
			new void ContextSensitiveHelp([MarshalAs(UnmanagedType.Bool)] bool fEnterMode);

			/// <summary>Retrieves the outer rectange for toolbars and controls while the object is active in place.</summary>
			/// <param name="lprectBorder">
			/// A pointer to a RECT structure where the outer rectangle is to be returned. The structure's coordinates are relative to the
			/// window being represented by the interface.
			/// </param>
			/// <remarks>
			/// <para>Notes to Callers</para>
			/// <para>
			/// The <c>IOleInPlaceUIWindow::GetBorder</c> function, when called on a document or frame window object, returns the outer
			/// rectangle (relative to the window) where the object can put toolbars or similar controls.
			/// </para>
			/// <para>
			/// If the object is to install these tools, it should negotiate space for the tools within this rectangle using
			/// IOleInPlaceUIWindow::RequestBorderSpace and then call IOleInPlaceUIWindow::SetBorderSpace to get this space allocated.
			/// </para>
			/// <para>
			/// <c>Note</c> While executing <c>IOleInPlaceUIWindow::GetBorder</c>, do not make calls to the PeekMessage or GetMessage
			/// functions, or a dialog box. Doing so may cause the system to deadlock. There are further restrictions on which OLE interface
			/// methods and functions can be called from within <c>GetBorder</c>.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-ioleinplaceuiwindow-getborder HRESULT GetBorder( LPRECT
			// lprectBorder );
			void GetBorder(out RECT lprectBorder);

			/// <summary>
			/// Determines whether there is space available for tools to be installed around the object's window frame while the object is
			/// active in place.
			/// </summary>
			/// <param name="pborderwidths">
			/// A pointer to a BORDERWIDTHS structure containing the requested widths (in pixels) needed on each side of the window for the tools.
			/// </param>
			/// <remarks>
			/// <para>Notes to Callers</para>
			/// <para>
			/// The active in-place object calls <c>IOleInPlaceUIWindow::RequestBorderSpace</c> to ask if tools can be installed inside the
			/// window frame. These tools would be allocated between the rectangle returned by IOleInPlaceUIWindow::GetBorder and the
			/// BORDERWIDTHS structure specified in the argument to this call.
			/// </para>
			/// <para>
			/// The space for the tools is not actually allocated to the object until it calls IOleInPlaceUIWindow::SetBorderSpace, allowing
			/// the object to negotiate for space (such as while dragging toolbars around), but deferring the moving of tools until the
			/// action is completed.
			/// </para>
			/// <para>
			/// The object can install these tools by passing the width in pixels that is to be used on each side. For example, if the object
			/// required 10 pixels on the top, 0 pixels on the bottom, and 5 pixels on the left and right sides, it would pass the following
			/// BORDERWIDTHS structure to <c>IOleInPlaceUIWindow::RequestBorderSpace</c>:
			/// </para>
			/// <para>
			/// <c>Note</c> While executing <c>IOleInPlaceUIWindow::RequestBorderSpace</c>, do not make calls to the PeekMessage or
			/// GetMessage functions, or a dialog box. Doing so may cause the system to deadlock. There are further restrictions on which OLE
			/// interface methods and functions can be called from within <c>IOleInPlaceUIWindow::RequestBorderSpace</c>.
			/// </para>
			/// <para>Notes to Implementers</para>
			/// <para>
			/// If the amount of space an active object uses for its toolbars is irrelevant to the container, it can simply return NOERROR as
			/// shown in the following <c>IOleInPlaceUIWindow::RequestBorderSpace</c> example. Containers should not unduly restrict the
			/// display of tools by an active in-place object.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-ioleinplaceuiwindow-requestborderspace HRESULT
			// RequestBorderSpace( LPCBORDERWIDTHS pborderwidths );
			void RequestBorderSpace(in RECT pborderwidths);

			/// <summary>Allocates space for the border requested in the call to IOleInPlaceUIWindow::RequestBorderSpace.</summary>
			/// <param name="pborderwidths">
			/// Pointer to a BORDERWIDTHS structure containing the requested width of the tools, in pixels. It can be <c>NULL</c>, indicating
			/// the object does not need any space.
			/// </param>
			/// <remarks>
			/// <para>The object must call <c>IOleInPlaceUIWindow::SetBorderSpace</c>. It can do any one of the following:</para>
			/// <list type="bullet">
			/// <item>
			/// <term>Use its own toolbars, requesting border space of a specific size.</term>
			/// </item>
			/// <item>
			/// <term>
			/// Use no toolbars, but force the container to remove its toolbars by passing a valid BORDERWIDTHS structure containing nothing
			/// but zeros in the pborderwidths parameter.
			/// </term>
			/// </item>
			/// <item>
			/// <term>
			/// Use no toolbars but allow the in-place container to leave its toolbars up by passing <c>NULL</c> as the pborderwidths parameter.
			/// </term>
			/// </item>
			/// </list>
			/// <para>
			/// The BORDERWIDTHS structure used in this call would generally have been passed in a previous call to
			/// IOleInPlaceUIWindow::RequestBorderSpace, which must have returned S_OK.
			/// </para>
			/// <para>
			/// If an object must renegotiate space on the border, it can call <c>IOleInPlaceUIWindow::SetBorderSpace</c> again with the new
			/// widths. If the call to <c>IOleInPlaceUIWindow::SetBorderSpace</c> fails, the object can do a full negotiation for border
			/// space with calls to IOleInPlaceUIWindow::GetBorder, IOleInPlaceUIWindow::RequestBorderSpace, and <c>IOleInPlaceUIWindow::SetBorderSpace</c>.
			/// </para>
			/// <para>
			/// <c>Note</c> While executing <c>IOleInPlaceUIWindow::SetBorderSpace</c>, do not make calls to the PeekMessage or GetMessage
			/// functions, or a dialog box. Doing so may cause the system to deadlock. There are further restrictions on which OLE interface
			/// methods and functions can be called from within <c>IOleInPlaceUIWindow::SetBorderSpace</c>.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-ioleinplaceuiwindow-setborderspace HRESULT SetBorderSpace(
			// LPCBORDERWIDTHS pborderwidths );
			void SetBorderSpace(in RECT pborderwidths);

			/// <summary>Provides a direct channel of communication between the object and each of the frame and document windows.</summary>
			/// <param name="pActiveObject">A pointer to the IOleInPlaceActiveObject interface on the active in-place object.</param>
			/// <param name="pszObjName">
			/// A pointer to a string containing a name that describes the object an embedding container can use in composing its window
			/// title. It can be <c>NULL</c> if the object does not require the container to change its window titles. Containers should
			/// ignore this parameter and always use their own name in the title bar.
			/// </param>
			/// <remarks>
			/// <para>
			/// Generally, an embedded object should pass <c>NULL</c> for the pszObjName parameter (see Notes to Implementers below).
			/// However, if you are working in conjunction with a container that does display the name of the in-place active object in its
			/// title bar, then you should compose a string in the following form: &lt;application name&gt; â€“ &lt;object short-type name&gt;.
			/// </para>
			/// <para>Notes to Callers</para>
			/// <para>
			/// <c>IOleInPlaceUIWindow::SetActiveObject</c> is called by the object to establish a direct communication link between itself
			/// and the document and frame windows.
			/// </para>
			/// <para>
			/// When deactivating, the object calls <c>IOleInPlaceUIWindow::SetActiveObject</c>, passing <c>NULL</c> for the pActiveObject
			/// and pszObjName parameters.
			/// </para>
			/// <para>
			/// An object must call <c>IOleInPlaceUIWindow::SetActiveObject</c> before calling IOleInPlaceFrame::SetMenu to give the
			/// container the pointer to the active object. The container then uses this pointer in processing
			/// <c>IOleInPlaceFrame::SetMenu</c> and to pass to OleSetMenuDescriptor.
			/// </para>
			/// <para>Notes to Implementers</para>
			/// <para>
			/// The Microsoft Windows User Interface Design Guide recommends that an in-place container ignore the pszObjName parameter
			/// passed in this method. The guide says "The title bar is not affected by in-place activation. It always displays the top-level
			/// container's name."
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-ioleinplaceuiwindow-setactiveobject HRESULT
			// SetActiveObject( IOleInPlaceActiveObject *pActiveObject, LPCOLESTR pszObjName );
			void SetActiveObject([In] IOleInPlaceActiveObject pActiveObject, [MarshalAs(UnmanagedType.LPWStr)] string pszObjName);
		}

		/// <summary>
		/// Serves as the principal means by which an embedded object provides basic functionality to, and communicates with, its container.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nn-oleidl-ioleobject
		[PInvokeData("oleidl.h", MSDNShortId = "58b32c87-39b6-4d64-9174-cf798ed302c2")]
		[ComImport, Guid("00000112-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IOleObject
		{
			/// <summary>Informs an embedded object of its display location, called a "client site," within its container.</summary>
			/// <param name="pClientSite">Pointer to the IOleClientSite interface on the container application's client-site.</param>
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
			/// <para>
			/// Within a compound document, each embedded object has its own client site â€” the place where it is displayed and through
			/// which it receives information about its storage, user interface, and other resources. <c>IOleObject::SetClientSite</c> is the
			/// only method enabling an embedded object to obtain a pointer to its client site.
			/// </para>
			/// <para>Notes to Callers</para>
			/// <para>
			/// A container can notify an object of its client site either at the time the object is created or, subsequently, when the
			/// object is initialized.
			/// </para>
			/// <para>
			/// When creating or loading an object, a container may pass a client-site pointer (along with other arguments) to one of the
			/// following helper functions: OleCreate, OleCreateFromFile, OleCreateFromData or OleLoad. These helper functions load an object
			/// handler for the new object and call <c>IOleObject::SetClientSite</c> on the container's behalf before returning a pointer to
			/// the new object.
			/// </para>
			/// <para>
			/// Passing a client-site pointer informs the object handler that the client site is ready to process requests. If the client
			/// site is unlikely to be ready immediately after the handler is loaded, you may want your container to pass a <c>NULL</c>
			/// client-site pointer to the helper function. The <c>NULL</c> pointer says that no client site is available and thereby defers
			/// notifying the object handler of the client site until the object is initialized. In response, the helper function returns a
			/// pointer to the object, but upon receiving that pointer the container must call <c>IOleObject::SetClientSite</c> as part of
			/// initializing the new object.
			/// </para>
			/// <para>Notes to Implementers</para>
			/// <para>Implementation consists simply of incrementing the reference count on, and storing, the pointer to the client site.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-ioleobject-setclientsite HRESULT SetClientSite(
			// IOleClientSite *pClientSite );
			[PreserveSig]
			HRESULT SetClientSite(IOleClientSite pClientSite);

			/// <summary>Retrieves a pointer to an embedded object's client site.</summary>
			/// <param name="ppClientSite">
			/// Address of IOleClientSite pointer variable that receives the interface pointer to the object's client site. If an object does
			/// not yet know its client site, or if an error has occurred, ppClientSite must be set to <c>NULL</c>. Each time an object
			/// receives a call to <c>IOleObject::GetClientSite</c>, it must increase the reference count on ppClientSite. It is the caller's
			/// responsibility to call Release when it is done with ppClientSite.
			/// </param>
			/// <returns>This method returns S_OK on success.</returns>
			/// <remarks>
			/// <para>
			/// Link clients most commonly call the <c>IOleObject::GetClientSite</c> method in conjunction with the
			/// IOleClientSite::GetContainer method to traverse a hierarchy of nested objects. A link client calls
			/// <c>IOleObject::GetClientSite</c> to get a pointer to the link source's client site. The client then calls
			/// <c>IOleClientSite::GetContainer</c> to get a pointer to the link source's container. Finally, the client calls QueryInterface
			/// to get IOleObject and <c>IOleObject::GetClientSite</c> to get the container's client site within its container. By repeating
			/// this sequence of calls, the caller can eventually retrieve a pointer to the master container in which all the other objects
			/// are nested.
			/// </para>
			/// <para>Notes to Callers</para>
			/// <para>
			/// The returned client-site pointer will be <c>NULL</c> if an embedded object has not yet been informed of its client site. This
			/// will be the case with a newly loaded or created object when a container has passed a <c>NULL</c> client-site pointer to one
			/// of the object-creation helper functions but has not yet called IOleObject::SetClientSite as part of initializing the object.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-ioleobject-getclientsite HRESULT GetClientSite(
			// IOleClientSite **ppClientSite );
			[PreserveSig]
			HRESULT GetClientSite(out IOleClientSite ppClientSite);

			/// <summary>Provides an object with the names of its container application and the compound document in which it is embedded.</summary>
			/// <param name="szContainerApp">Pointer to the name of the container application in which the object is running.</param>
			/// <param name="szContainerObj">
			/// Pointer to the name of the compound document that contains the object. If you do not wish to display the name of the compound
			/// document, you can set this parameter to <c>NULL</c>.
			/// </param>
			/// <returns>This method returns S_OK on success.</returns>
			/// <remarks>
			/// <para>Notes for Callers</para>
			/// <para>
			/// Call <c>IOleObject::SetHostNames</c> only for embedded objects, because for linked objects, the link source provides its own
			/// separate editing window and title bar information.
			/// </para>
			/// <para>Notes to Implementers</para>
			/// <para>
			/// An object's application of <c>IOleObject::SetHostNames</c> should include whatever modifications to its user interface may be
			/// appropriate to an object's embedded state. Such modifications typically will include adding and removing menu commands and
			/// altering the text displayed in the title bar of the editing window.
			/// </para>
			/// <para>
			/// The complete window title for an embedded object in an SDI container application or an MDI application with a maximized child
			/// window should appear as follows:
			/// </para>
			/// <para>Otherwise, the title should be:</para>
			/// <para>
			/// The "object short type" refers to a form of an object's name short enough to be displayed in full in a list box. Because
			/// these identifying strings are not stored as part of the persistent state of the object, <c>IOleObject::SetHostNames</c> must
			/// be called each time the object loads or runs.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-ioleobject-sethostnames HRESULT SetHostNames( LPCOLESTR
			// szContainerApp, LPCOLESTR szContainerObj );
			[PreserveSig]
			HRESULT SetHostNames([MarshalAs(UnmanagedType.LPWStr)] string szContainerApp, [MarshalAs(UnmanagedType.LPWStr)] string szContainerObj);

			/// <summary>Changes an embedded object from the running to the loaded state. Disconnects a linked object from its link source.</summary>
			/// <param name="dwSaveOption">
			/// <para>
			/// Indicates whether the object is to be saved as part of the transition to the loaded state. Valid values are taken from the
			/// enumeration OLECLOSE.
			/// </para>
			/// <para>
			/// <c>Note</c> The OLE 2 user model recommends that object applications do not prompt users before saving linked or embedded
			/// objects, including those activated in place. This policy represents a change from the OLE 1 user model, in which object
			/// applications always prompt the user to decide whether to save changes.
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
			/// <term>OLE_E_PROMPTSAVECANCELLED</term>
			/// <term>The user was prompted to save but chose the Cancel button from the prompt message box.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>Notes to Callers</para>
			/// <para>
			/// A container application calls <c>IOleObject::Close</c> when it wants to move the object from a running to a loaded state.
			/// Following such a call, the object still appears in its container but is not open for editing. Calling
			/// <c>IOleObject::Close</c> on an object that is loaded but not running has no effect. Closing a linked object simply means
			/// disconnecting it.
			/// </para>
			/// <para>Notes to Implementers</para>
			/// <para>Upon receiving a call to <c>IOleObject::Close</c>, a running object should do the following:</para>
			/// <list type="bullet">
			/// <item>
			/// <term>
			/// If the object has been changed since it was last opened for editing, it should request to be saved, or not, according to
			/// instructions specified in dwSaveOption. If the option is to save the object, then it should call its container's
			/// IOleClientSite::SaveObject interface.
			/// </term>
			/// </item>
			/// <item>
			/// <term>
			/// If the object has IDataObject::DAdvise connections with ADVF_DATAONSTOP flags, then it should send an
			/// IAdviseSink::OnDataChange notification. See <c>IDataObject::DAdvise</c> for details.
			/// </term>
			/// </item>
			/// <item>
			/// <term>If the object currently owns the Clipboard, it should empty it by calling OleFlushClipboard.</term>
			/// </item>
			/// <item>
			/// <term>
			/// If the object is currently visible, notify its container by calling IOleClientSite::OnShowWindow with the fshow argument set
			/// to <c>FALSE</c>.
			/// </term>
			/// </item>
			/// <item>
			/// <term>Send IAdviseSink::OnClose notifications to appropriate advise sinks.</term>
			/// </item>
			/// <item>
			/// <term>Finally, forcibly cut off all remoting clients by calling CoDisconnectObject.</term>
			/// </item>
			/// </list>
			/// <para>
			/// If the object application is a local server (an EXE rather than a DLL), closing the object should also shut down the object
			/// application unless the latter is supporting other running objects or has another reason to remain in the running state. Such
			/// reasons might include the presence of IClassFactory::LockServer locks, end-user control of the application, or the existence
			/// of other open documents requiring access to the application.
			/// </para>
			/// <para>
			/// Calling <c>IOleObject::Close</c> on a linked object disconnects it from, but does not shut down, its source application. A
			/// source application that is visible to the user when the object is closed remains visible and running after the disconnection
			/// and does not send an IAdviseSink::OnClose notification to the link container.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-ioleobject-close HRESULT Close( DWORD dwSaveOption );
			[PreserveSig]
			HRESULT Close(OLECLOSE dwSaveOption);

			/// <summary>
			/// Notifies an object of its container's moniker, the object's own moniker relative to the container, or the object's full moniker.
			/// </summary>
			/// <param name="dwWhichMoniker">The moniker is passed in pmk. Possible values are from the enumeration OLEWHICHMK.</param>
			/// <param name="pmk">Pointer to where to return the moniker.</param>
			/// <returns>
			/// <para>This method returns S_OK on success. Other possible return values include the following.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>E_FAIL</term>
			/// <term>The operation failed.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>
			/// A container that supports links to embedded objects must be able to inform an embedded object when its moniker has changed.
			/// Otherwise, subsequent attempts by link clients to bind to the object will fail. The <c>IOleObject::SetMoniker</c> method
			/// provides one way for a container to communicate this information.
			/// </para>
			/// <para>
			/// The container can pass either its own moniker, an object's moniker relative to the container, or an object's full moniker. In
			/// practice, if a container passes anything other than an object's full moniker, each object calls the container back to request
			/// assignment of the full moniker, which the object requires to register itself in the running object table.
			/// </para>
			/// <para>
			/// The moniker of an object relative to its container is stored by the object handler as part of the object's persistent state.
			/// The moniker of the object's container, however, must not be persistently stored inside the object because the container can
			/// be renamed at any time.
			/// </para>
			/// <para>Notes to Callers</para>
			/// <para>
			/// A container calls <c>IOleObject::SetMoniker</c> when the container has been renamed, and the container's embedded objects
			/// currently or can potentially serve as link sources. Containers call SetMoniker mainly in the context of linking because an
			/// embedded object is already aware of its moniker. Even in the context of linking, calling this method is optional because
			/// objects can call IOleClientSite::GetMoniker to force assignment of a new moniker.
			/// </para>
			/// <para>Notes to Implementers</para>
			/// <para>
			/// Upon receiving a call to <c>IOleObject::SetMoniker</c>, an object should register its full moniker in the running object
			/// table and send IAdviseSink::OnRename notification to all advise sinks that exist for the object.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-ioleobject-setmoniker HRESULT SetMoniker( DWORD
			// dwWhichMoniker, IMoniker *pmk );
			[PreserveSig]
			HRESULT SetMoniker(OLEWHICHMK dwWhichMoniker, IMoniker pmk);

			/// <summary>Retrieves an embedded object's moniker, which the caller can use to link to the object.</summary>
			/// <param name="dwAssign">
			/// <para>
			/// Determines how the moniker is assigned to the object. Depending on the value of dwAssign, <c>IOleObject::GetMoniker</c> does
			/// one of the following:
			/// </para>
			/// <list type="bullet">
			/// <item>
			/// <term>Obtains a moniker only if one has already been assigned.</term>
			/// </item>
			/// <item>
			/// <term>Forces assignment of a moniker, if necessary, in order to satisfy the call.</term>
			/// </item>
			/// <item>
			/// <term>Obtains a temporary moniker.</term>
			/// </item>
			/// </list>
			/// <para>Values for</para>
			/// <para>dwAssign</para>
			/// <para>are specified in the enumeration</para>
			/// <para>OLEGETMONIKER</para>
			/// <para>.</para>
			/// <para>
			/// <c>Note</c> You cannot pass OLEGETMONIKER_UNASSIGN when calling <c>IOleObject::GetMoniker</c>. This value is valid only when
			/// calling <c>IOleObject::GetMoniker</c>.
			/// </para>
			/// </param>
			/// <param name="dwWhichMoniker">
			/// Specifies the form of the moniker being requested. Possible values are taken from the enumeration OLEWHICHMK.
			/// </param>
			/// <param name="ppmk">
			/// Address of IMoniker pointer variable that receives the interface pointer to the object's moniker. If an error occurs, ppmk
			/// must be set to <c>NULL</c>. Each time an object receives a call to <c>IOleObject::GetMoniker</c>, it must increase the
			/// reference count on ppmk. It is the caller's responsibility to call Release when it is done with ppmk.
			/// </param>
			/// <returns>This method returns S_OK on success.</returns>
			/// <remarks>
			/// The <c>IOleObject::GetMoniker</c> method returns an object's moniker. Like IOleObject::SetMoniker, this method is important
			/// only in the context of managing links to embedded objects and even in that case is optional. A potential link client that
			/// requires an object's moniker to bind to the object can call this method to obtain that moniker. The default implementation of
			/// <c>IOleObject::GetMoniker</c> calls the IOleClientSite::GetMoniker, returning E_UNEXPECTED if the object is not running or
			/// does not have a valid pointer to a client site.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-ioleobject-getmoniker HRESULT GetMoniker( DWORD dwAssign,
			// DWORD dwWhichMoniker, IMoniker **ppmk );
			[PreserveSig]
			HRESULT GetMoniker(OLEGETMONIKER dwAssign, OLEWHICHMK dwWhichMoniker, out IMoniker ppmk);

			/// <summary>
			/// Initializes a newly created object with data from a specified data object, which can reside either in the same container or
			/// on the Clipboard.
			/// </summary>
			/// <param name="pDataObject">
			/// Pointer to the IDataObject interface on the data object from which the initialization data is to be obtained. This parameter
			/// can be <c>NULL</c>, which indicates that the caller wants to know if it is worthwhile trying to send data; that is, whether
			/// the container is capable of initializing an object from data passed to it. The data object to be passed can be based on
			/// either the current selection within the container document or on data transferred to the container from an external source.
			/// </param>
			/// <param name="fCreation">
			/// <c>TRUE</c> indicates the container is inserting a new object inside itself and initializing that object with data from the
			/// current selection; <c>FALSE</c> indicates a more general programmatic data transfer, most likely from a source other than the
			/// current selection.
			/// </param>
			/// <param name="dwReserved">This parameter is reserved and must be zero.</param>
			/// <returns>
			/// <para>
			/// This method returns S_OK if pDataObject is not <c>NULL</c>, the object successfully attempted to initialize itself from the
			/// provided data; if pDataObject is <c>NULL</c>, the object is able to attempt a successful initialization.. Other possible
			/// return values include the following.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_FALSE</term>
			/// <term>
			/// If pDataObject is not NULL, the object made no attempt to initialize itself; if pDataObject is NULL, the object cannot
			/// attempt to initialize itself from the data provided.
			/// </term>
			/// </item>
			/// <item>
			/// <term>E_NOTIMPL</term>
			/// <term>The object does not support InitFromData.</term>
			/// </item>
			/// <item>
			/// <term>OLE_E_NOTRUNNING</term>
			/// <term>The object is not running and therefore cannot perform the operation.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>
			/// This method enables a container document to insert within itself a new object whose content is based on a current data
			/// selection within the container. For example, a spreadsheet document may want to create a graph object based on data in a
			/// selected range of cells.
			/// </para>
			/// <para>
			/// Using this method, a container can also replace the contents of an embedded object with data transferred from another source.
			/// This provides a convenient way of updating an embedded object.
			/// </para>
			/// <para>Notes to Callers</para>
			/// <para>
			/// Following initialization, the container should call IOleObject::GetMiscStatus to check the value of the
			/// OLEMISC_INSERTNOTREPLACE bit. If the bit is on, the new object inserts itself following the selected data. If the bit is off,
			/// the new object replaces the selected data.
			/// </para>
			/// <para>Notes to Implementers</para>
			/// <para>
			/// A container specifies whether to base a new object on the current selection by passing either <c>TRUE</c> or <c>FALSE</c> to
			/// the fCreation parameter.
			/// </para>
			/// <para>
			/// If fCreation is <c>TRUE</c>, the container is attempting to create a new instance of an object, initializing it with the
			/// selected data specified by the data object.
			/// </para>
			/// <para>
			/// If fCreation is <c>FALSE</c>, the caller is attempting to replace the object's current contents with that pointed to by
			/// pDataObject. The usual constraints that apply to an object during a paste operation should be applied here. For example, if
			/// the type of the data provided is unacceptable, the object should fail to initialize and return S_FALSE.
			/// </para>
			/// <para>If the object returns S_FALSE, it cannot initialize itself from the provided data.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-ioleobject-initfromdata HRESULT InitFromData( IDataObject
			// *pDataObject, BOOL fCreation, DWORD dwReserved );
			[PreserveSig]
			HRESULT InitFromData(IDataObject pDataObject, [MarshalAs(UnmanagedType.Bool)] bool fCreation, uint dwReserved = 0);

			/// <summary>
			/// Retrieves a data object containing the current contents of the embedded object on which this method is called. Using the
			/// pointer to this data object, it is possible to create a new embedded object with the same data as the original.
			/// </summary>
			/// <param name="dwReserved">This parameter is reserved and must be zero.</param>
			/// <param name="ppDataObject">
			/// Address of IDataObject pointer variable that receives the interface pointer to the data object. If an error occurs,
			/// ppDataObject must be set to <c>NULL</c>. Each time an object receives a call to <c>IOleObject::GetClipboardData</c>, it must
			/// increase the reference count on ppDataObject. It is the caller's responsibility to call Release when it is done with ppDataObject.
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
			/// <term>GetClipboardData is not supported.</term>
			/// </item>
			/// <item>
			/// <term>OLE_E_NOTRUNNING</term>
			/// <term>The object is not running.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>
			/// You can use the <c>IOleObject::GetClipboardData</c> method to convert a linked object to an embedded object, in which case
			/// the container application would call <c>IOleObject::GetClipboardData</c> and then pass the data received to
			/// OleCreateFromData. This method returns a pointer to a data object that is identical to what would have been passed to the
			/// clipboard by a standard copy operation.
			/// </para>
			/// <para>Notes to Callers</para>
			/// <para>
			/// If you want a stable snapshot of the current contents of an embedded object, call <c>IOleObject::GetClipboardData</c>. Should
			/// the data change, you will need to call the function again for an updated snapshot. If you want the caller to be informed of
			/// changes that occur to the data, call QueryInterface, then call IDataObject::DAdvise.
			/// </para>
			/// <para>Notes to Implementers</para>
			/// <para>If you implement this function, you must return an IDataObject pointer for an object whose data will not change.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-ioleobject-getclipboarddata HRESULT GetClipboardData(
			// DWORD dwReserved, IDataObject **ppDataObject );
			[PreserveSig]
			HRESULT GetClipboardData([Optional] uint dwReserved, out IDataObject ppDataObject);

			/// <summary>
			/// Requests that an object perform an action in response to an end-user's action. The possible actions are enumerated for the
			/// object in IOleObject::EnumVerbs.
			/// </summary>
			/// <param name="iVerb">Number assigned to the verb in the OLEVERB structure returned by IOleObject::EnumVerbs.</param>
			/// <param name="lpmsg">
			/// Pointer to the MSG structure describing the event (such as a double-click) that invoked the verb. The caller should pass the
			/// <c>MSG</c> structure unmodified, without attempting to interpret or alter the values of any of the structure members.
			/// </param>
			/// <param name="pActiveSite">
			/// Pointer to the IOleClientSite interface on the object's active client site, where the event occurred that invoked the verb.
			/// </param>
			/// <param name="lindex">This parameter is reserved and must be zero.</param>
			/// <param name="hwndParent">
			/// Handle of the document window containing the object. This and lprcPosRect together make it possible to open a temporary
			/// window for an object, where hwndParent is the parent window in which the object's window is to be displayed, and lprcPosRect
			/// defines the area available for displaying the object window within that parent. A temporary window is useful, for example, to
			/// a multimedia object that opens itself for playback but not for editing.
			/// </param>
			/// <param name="lprcPosRect">
			/// Pointer to the RECT structure containing the coordinates, in pixels, that define an object's bounding rectangle in
			/// hwndParent. This and hwndParent together enable opening multimedia objects for playback but not for editing.
			/// </param>
			/// <returns>
			/// <para>This method returns S_OK on success. Other possible return values include the following.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>OLE_E_NOT_INPLACEACTIVE</term>
			/// <term>iVerb set to OLEIVERB_UIACTIVATE or OLEIVERB_INPLACEACTIVATE and object is not already visible.</term>
			/// </item>
			/// <item>
			/// <term>OLE_E_CANT_BINDTOSOURCE</term>
			/// <term>The object handler or link object cannot connect to the link source.</term>
			/// </item>
			/// <item>
			/// <term>DV_E_LINDEX</term>
			/// <term>Invalid lindex.</term>
			/// </item>
			/// <item>
			/// <term>OLEOBJ_S_CANNOT_DOVERB_NOW</term>
			/// <term>The verb is valid, but in the object's current state it cannot carry out the corresponding action.</term>
			/// </item>
			/// <item>
			/// <term>OLEOBJ_S_INVALIDHWND</term>
			/// <term>DoVerb was successful but hwndParent is invalid.</term>
			/// </item>
			/// <item>
			/// <term>OLEOBJ_E_NOVERBS</term>
			/// <term>The object does not support any verbs.</term>
			/// </item>
			/// <item>
			/// <term>OLEOBJ_S_INVALIDVERB</term>
			/// <term>Link source is across a network that is not connected to a drive on this computer.</term>
			/// </item>
			/// <item>
			/// <term>MK_E_CONNECT</term>
			/// <term>Link source is across a network that is not connected to a drive on this computer.</term>
			/// </item>
			/// <item>
			/// <term>OLE_E_CLASSDIFF</term>
			/// <term>Class for source of link has undergone a conversion.</term>
			/// </item>
			/// <item>
			/// <term>E_NOTIMPL</term>
			/// <term>Object does not support in-place activation or does not recognize a negative verb number.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>
			/// A "verb" is an action that an OLE object takes in response to a message from its container. An object's container, or a
			/// client linked to the object, normally calls <c>IOleObject::DoVerb</c> in response to some end-user action, such as
			/// double-clicking on the object. The various actions that are available for a given object are enumerated in an OLEVERB
			/// structure, which the container obtains by calling IOleObject::EnumVerbs. <c>IOleObject::DoVerb</c> matches the value of iVerb
			/// against the iVerb member of the structure to determine which verb to invoke.
			/// </para>
			/// <para>
			/// Through IOleObject::EnumVerbs, an object, rather than its container, determines which verbs (i.e., actions) it supports. OLE
			/// 2 defines seven verbs that are available, but not necessarily useful, to all objects. In addition, each object can define
			/// additional verbs that are unique to it. The following table describes the verbs defined by OLE.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Verb</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>OLEIVERB_PRIMARY (0L)</term>
			/// <term>
			/// Specifies the action that occurs when an end user double-clicks the object in its container. The object, not the container,
			/// determines this action. If the object supports in-place activation, the primary verb usually activates the object in place.
			/// </term>
			/// </item>
			/// <item>
			/// <term>OLEIVERB_SHOW (-1)</term>
			/// <term>
			/// Instructs an object to show itself for editing or viewing. Called to display newly inserted objects for initial editing and
			/// to show link sources. Usually an alias for some other object-defined verb.
			/// </term>
			/// </item>
			/// <item>
			/// <term>OLEIVERB_OPEN (-2)</term>
			/// <term>
			/// Instructs an object, including one that otherwise supports in-place activation, to open itself for editing in a window
			/// separate from that of its container. If the object does not support in-place activation, this verb has the same semantics as OLEIVERB_SHOW.
			/// </term>
			/// </item>
			/// <item>
			/// <term>OLEIVERB_HIDE (-3)</term>
			/// <term>Causes an object to remove its user interface from the view. Applies only to objects that are activated in-place.</term>
			/// </item>
			/// <item>
			/// <term>OLEIVERB_UIACTIVATE (-4)</term>
			/// <term>
			/// Activates an object in place, along with its full set of user-interface tools, including menus, toolbars, and its name in the
			/// title bar of the container window. If the object does not support in-place activation, it should return E_NOTIMPL.
			/// </term>
			/// </item>
			/// <item>
			/// <term>OLEIVERB_INPLACEACTIVATE (-5)</term>
			/// <term>
			/// Activates an object in place without displaying tools, such as menus and toolbars, that end users need to change the behavior
			/// or appearance of the object. Single-clicking such an object causes it to negotiate the display of its user-interface tools
			/// with its container. If the container refuses, the object remains active but without its tools displayed.
			/// </term>
			/// </item>
			/// <item>
			/// <term>OLEIVERB_DISCARDUNDOSTATE (-6)</term>
			/// <term>Used to tell objects to discard any undo state that they may be maintaining without deactivating the object.</term>
			/// </item>
			/// </list>
			/// <para>Notes to Callers</para>
			/// <para>
			/// Containers call <c>IOleObject::DoVerb</c> as part of initializing a newly created object. Before making the call, containers
			/// should first call IOleObject::SetClientSite to inform the object of its display location and IOleObject::SetHostNames to
			/// alert the object that it is an embedded object and to trigger appropriate changes to the user interface of the object
			/// application in preparation for opening an editing window.
			/// </para>
			/// <para>
			/// <c>IOleObject::DoVerb</c> automatically runs the OLE server application. If an error occurs during verb execution, the object
			/// application is shut down.
			/// </para>
			/// <para>
			/// If an end user invokes a verb by some means other than selecting a command from a menu (say, by double-clicking or, more
			/// rarely, single-clicking an object), the object's container should pass a pointer to a Windows MSG structure containing the
			/// appropriate message. For example, if the end user invokes a verb by double-clicking the object, the container should pass a
			/// <c>MSG</c> structure containing WM_LBUTTONDBLCLK, WM_MBUTTONDBLCLK, or WM_RBUTTONDBLCLK. If the container passes no message,
			/// lpmsg should be set to <c>NULL</c>. The object should ignore the <c>hwnd</c> member of the passed <c>MSG</c> structure, but
			/// can use all the other MSG members.
			/// </para>
			/// <para>
			/// If the object's embedding container calls <c>IOleObject::DoVerb</c>, the client-site pointer (pClientSite) passed to
			/// <c>IOleObject::DoVerb</c> is the same as that of the embedding site. If the embedded object is a link source, the pointer
			/// passed to <c>IOleObject::DoVerb</c> is that of the linking client's client site.
			/// </para>
			/// <para>
			/// When <c>IOleObject::DoVerb</c> is invoked on an OLE link, it may return OLE_E_CLASSDIFF or MK_CONNECTMANUALLY. The link
			/// object returns the former error when the link source has been subjected to some sort of conversion while the link was
			/// passive. The link object returns the latter error when the link source is located on a network drive that is not currently
			/// connected to the caller's computer. The only way to connect a link under these conditions is to first call
			/// IUnknown::QueryInterface, ask for IOleLink, allocate a bind context, and run the link source by calling IOleLink::BindToSource.
			/// </para>
			/// <para>
			/// Container applications that do not support general in-place activation can still use the hwndParent and lprcPosRect
			/// parameters to support in-place playback of multimedia files. Containers must pass valid hwndParent and lprcPosRect parameters
			/// to <c>IOleObject::DoVerb</c>.
			/// </para>
			/// <para>
			/// Some code samples pass a lindex value of -1 instead of zero. The value -1 works but should be avoided in favor of zero. The
			/// lindex parameter is a reserved parameter, and for reasons of consistency Microsoft recommends assigning a zero value to all
			/// reserved parameters.
			/// </para>
			/// <para>Notes to Implementers</para>
			/// <para>
			/// In addition to the above verbs, an object can define in its OLEVERB structure additional verbs that are specific to itself.
			/// Positive numbers designate these object-specific verbs. An object should treat any unknown positive verb number as if it were
			/// the primary verb and return OLEOBJ_S_INVALIDVERB to the calling function. The object should ignore verbs with negative
			/// numbers that it does not recognize and return E_NOTIMPL.
			/// </para>
			/// <para>
			/// If the verb being executed places the object in the running state, you should register the object in the running object table
			/// (ROT) even if its server application doesn't support linking. Registration is important because the object at some point may
			/// serve as the source of a link in a container that supports links to embeddings. Registering the object with the ROT enables
			/// the link client to get a pointer to the object directly, instead of having to go through the object's container. To perform
			/// the registration, call IOleClientSite::GetMoniker to get the full moniker of the object, call the GetRunningObjectTable
			/// function to get a pointer to the ROT, and then call IRunningObjectTable::Register.
			/// </para>
			/// <para>
			/// <c>Note</c> When the object leaves the running state, remember to revoke the object's registration with the ROT by calling
			/// IOleObject::Close. If the object's container document is renamed while the object is running, you should revoke the object's
			/// registration and re-register it with the ROT, using its new name. The container should inform the object of its new moniker
			/// either by calling IOleObject::SetMoniker or by responding to the object's calling IOleClientSite::GetMoniker.
			/// </para>
			/// <para>
			/// When showing a window as a result of <c>IOleObject::DoVerb</c>, it is very important for the object to explicitly call
			/// SetForegroundWindow on its editing window. This ensures that the object's window will be visible to the user even if another
			/// process originally obscured it. For more information see <c>SetForegroundWindow</c> and SetActiveWindow.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-ioleobject-doverb HRESULT DoVerb( LONG iVerb, LPMSG lpmsg,
			// IOleClientSite *pActiveSite, LONG lindex, HWND hwndParent, LPCRECT lprcPosRect );
			[PreserveSig]
			HRESULT DoVerb(int iVerb, in MSG lpmsg, IOleClientSite pActiveSite, [Optional] int lindex, HWND hwndParent, in RECT lprcPosRect);

			/// <summary>Exposes a pull-down menu listing the verbs available for an object in ascending order by verb number.</summary>
			/// <param name="ppEnumOleVerb">
			/// Address of IEnumOLEVERB pointer variable that receives the interface pointer to the new enumerator object. Each time an
			/// object receives a call to IOleObject::EnumVerbs, it must increase the reference count on ppEnumOleVerb. It is the caller's
			/// responsibility to call IUnknown::Release when it is done with ppEnumOleVerb. If an error occurs, ppEnumOleVerb must be set to NULL.
			/// </param>
			/// <returns>
			/// <para>This method returns S_OK on success. Other possible return values include the following.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>OLE_S_USEREG</term>
			/// <term>Delegate to the default handler to use the entries in the registry to provide the enumeration.</term>
			/// </item>
			/// <item>
			/// <term>OLEOBJ_E_NOVERBS</term>
			/// <term>The object does not support any verbs.</term>
			/// </item>
			/// </list>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-ioleobject-enumverbs HRESULT EnumVerbs( IEnumOLEVERB
			// **ppEnumOleVerb );
			[PreserveSig]
			HRESULT EnumVerbs(out IEnumOLEVERB ppEnumOleVerb);

			/// <summary>Updates an object handler's or link object's data or view caches.</summary>
			/// <returns>
			/// <para>This method returns S_OK on success. Other possible return values include the following.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>E_FAIL</term>
			/// <term>The operation failed.</term>
			/// </item>
			/// <item>
			/// <term>OLE_E_CANT_BINDTOSOURCE</term>
			/// <term>Cannot run object to get updated data. The object is for some reason unavailable to the caller.</term>
			/// </item>
			/// <item>
			/// <term>CACHE_E_NOCACHE_UPDATED</term>
			/// <term>No caches were updated.</term>
			/// </item>
			/// <item>
			/// <term>CACHE_S_SOMECACHES_NOTUPDATED</term>
			/// <term>Some caches were not updated.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>
			/// The <c>Update</c> method provides a way for containers to keep data updated in their linked and embedded objects. A link
			/// object can become out-of-date if the link source has been updated. An embedded object that contains links to other objects
			/// can also become out of date. An embedded object that does not contain links cannot become out of date because its data is not
			/// linked to another source.
			/// </para>
			/// <para>Notes to Implementers</para>
			/// <para>
			/// When a container calls a link object's <c>IOleObject::Update</c> method, the link object finds the link source and gets a new
			/// presentation from it. This process may also involve running one or more object applications, which could be time-consuming.
			/// </para>
			/// <para>
			/// When a container calls an embedded object's <c>IOleObject::Update</c> method, it is requesting the object to update all link
			/// objects it may contain. In response, the object handler recursively calls <c>IOleObject::Update</c> for each of its own
			/// linked objects, running each one as needed.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-ioleobject-update HRESULT Update( );
			[PreserveSig]
			HRESULT Update();

			/// <summary>Checks whether an object is up to date.</summary>
			/// <returns>
			/// <para>
			/// This method returns S_OK if the object is up to date; otherwise, S_FALSE. Other possible return values include the following.
			/// </para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>OLE_E_UNAVAILABLE</term>
			/// <term>The status of object cannot be determined in a timely manner.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>
			/// The <c>IOleObject::IsUpToDate</c> method provides a way for containers to check recursively whether all objects are up to
			/// date. That is, when the container calls this method on the first object, the object in turn calls it for all its own objects,
			/// and they in turn for all of theirs, until all objects have been checked.
			/// </para>
			/// <para>Notes to Implementers</para>
			/// <para>
			/// Because of the recursive nature of <c>IOleObject::IsUpToDate</c>, determining whether an object is out-of-date, particularly
			/// one containing one or more other objects, can be as time-consuming as simply updating the object in the first place. If you
			/// would rather avoid lengthy queries of this type, make sure that <c>IOleObject::IsUpToDate</c> returns OLE_E_UNAVAILABLE. In
			/// cases where the object to be queried is small and contains no objects itself, thereby making an efficient query possible,
			/// this method can return either S_OK or S_FALSE.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-ioleobject-isuptodate HRESULT IsUpToDate( );
			[PreserveSig]
			HRESULT IsUpToDate();

			/// <summary>
			/// Retrieves an object's class identifier, the CLSID corresponding to the string identifying the object to an end user.
			/// </summary>
			/// <param name="pClsid">
			/// Pointer to the class identifier (CLSID) to be returned. An object's CLSID is the binary equivalent of the user-type name
			/// returned by IOleObject::GetUserType.
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
			/// <term>The operation failed.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <c>IOleObject::GetUserClassID</c> returns the CLSID associated with the object in the registration database. Normally, this
			/// value is identical to the CLSID stored with the object, which is returned by IPersist::GetClassID. For linked objects, this
			/// is the CLSID of the last bound link source. If the object is running in an application different from the one in which it was
			/// created and for the purpose of being edited is emulating a class that the container application recognizes, the CLSID
			/// returned will be that of the class being emulated rather than that of the object's own class.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-ioleobject-getuserclassid HRESULT GetUserClassID( CLSID
			// *pClsid );
			[PreserveSig]
			HRESULT GetUserClassID(out Guid pClsid);

			/// <summary>
			/// Retrieves the user-type name of an object for display in user-interface elements such as menus, list boxes, and dialog boxes.
			/// </summary>
			/// <param name="dwFormOfType">
			/// The form of the user-type name to be presented to users. Possible values are obtained from the USERCLASSTYPE enumeration.
			/// </param>
			/// <param name="pszUserType">
			/// Address of LPOLESTR pointer variable that receives a pointer to the user type string. The caller must free pszUserType using
			/// the current IMalloc instance. If an error occurs, the implementation must set pszUserType to <c>NULL</c>.
			/// </param>
			/// <returns>
			/// <para>This method returns S_OK on success. Other possible return values include the following.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>OLE_S_USEREG</term>
			/// <term>Delegate to the default handler's implementation using the registry to provide the requested information.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>
			/// Containers call <c>IOleObject::GetUserType</c> in order to represent embedded objects in list boxes, menus, and dialog boxes
			/// by their normal, user-recognizable names. Examples include "Word Document," "Excel Chart," and "Paintbrush Object." The
			/// information returned by <c>IOleObject::GetUserType</c> is the user-readable equivalent of the binary class identifier
			/// returned by IOleObject::GetUserClassID.
			/// </para>
			/// <para>Notes to Callers</para>
			/// <para>
			/// The default handler's implementation of <c>IOleObject::GetUserType</c> uses the object's class identifier (the pClsid
			/// parameter returned by IOleObject::GetUserClassID) and the dwFormOfType parameter together as a key into the registry. If an
			/// entry is found that matches the key exactly, then the user type specified by that entry is returned. If only the CLSID part
			/// of the key matches, then the lowest-numbered entry available (usually the full name) is used. If the CLSID is not found, or
			/// there are no user types registered for the class, the user type currently found in the object's storage is used.
			/// </para>
			/// <para>
			/// You should not cache the string returned from <c>IOleObject::GetUserType</c>. Instead, call this method each and every time
			/// the string is needed. This guarantees correct results when the embedded object is being converted from one type into another
			/// without the caller's knowledge. Calling this method is inexpensive because the default handler implements it using the registry.
			/// </para>
			/// <para>Notes to Implementers</para>
			/// <para>
			/// You can use the implementation provided by the default handler by returning OLE_S_USEREG as your application's implementation
			/// of this method. If the user type name is an empty string, the message "Unknown Object" is returned.
			/// </para>
			/// <para>You can call the OLE helper function OleRegGetUserType to return the appropriate user type.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-ioleobject-getusertype HRESULT GetUserType( DWORD
			// dwFormOfType, LPOLESTR *pszUserType );
			[return: MarshalAs(UnmanagedType.LPWStr)]
			[PreserveSig]
			HRESULT GetUserType(USERCLASSTYPE dwFormOfType, [MarshalAs(UnmanagedType.LPWStr)] out string pszUserType);

			/// <summary>Informs an object of how much display space its container has assigned it.</summary>
			/// <param name="dwDrawAspect">
			/// DWORD that describes which form, or "aspect," of an object is to be displayed. The object's container obtains this value from
			/// the enumeration DVASPECT (refer to the FORMATETC enumeration). The most common aspect is DVASPECT_CONTENT, which specifies a
			/// full rendering of the object within its container. An object can also be rendered as an icon, a thumbnail version for display
			/// in a browsing tool, or a print version, which displays the object as it would be rendered using the <c>File Print</c> command.
			/// </param>
			/// <param name="psizel">Pointer to the size limit for the object.</param>
			/// <returns>
			/// <para>This method returns S_OK on success. Other possible return values include the following.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>E_FAIL</term>
			/// <term>The operation failed.</term>
			/// </item>
			/// <item>
			/// <term>OLE_E_NOTRUNNING</term>
			/// <term>The object is not running.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>
			/// A container calls <c>IOleObject::SetExtent</c> when it needs to dictate to an embedded object the size at which it will be
			/// displayed. Often, this call occurs in response to an end user resizing the object window. Upon receiving the call, the
			/// object, if possible, should recompose itself gracefully to fit the new window.
			/// </para>
			/// <para>
			/// Whenever possible, a container seeks to display an object at its finest resolution, sometimes called the object's native
			/// size. All objects, however, have a default display size specified by their applications, and in the absence of other
			/// constraints, this is the size they will use to display themselves. Since an object knows its optimum display size better than
			/// does its container, the latter normally requests that size from a running object by calling <c>IOleObject::SetExtent</c>.
			/// Only in cases where the container cannot accommodate the value returned by the object does it override the object's
			/// preference by calling <c>IOleObject::SetExtent</c>.
			/// </para>
			/// <para>Notes to Callers</para>
			/// <para>
			/// You can call <c>IOleObject::SetExtent</c> on an object only when the object is running. If a container resizes an object
			/// while an object is not running, the container should keep track of the object's new size but defer calling
			/// <c>IOleObject::SetExtent</c> until a user activates the object. If the OLEMISC_RECOMPOSEONRESIZE bit is set on an object, its
			/// container should force the object to run before calling <c>IOleObject::SetExtent</c>.
			/// </para>
			/// <para>
			/// As noted above, a container may want to delegate responsibility for setting the size of an object's display site to the
			/// object itself, by calling <c>IOleObject::SetExtent</c>.
			/// </para>
			/// <para>Notes to Implementers</para>
			/// <para>
			/// You may want to implement this method so that your object rescales itself to match as closely as possible the maximum space
			/// available to it in its container.
			/// </para>
			/// <para>
			/// If an object's size is fixed, that is, if it cannot be set by its container, <c>IOleObject::SetExtent</c> should return
			/// E_FAIL. This is always the case with linked objects, whose sizes are set by their link sources, not by their containers.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-ioleobject-setextent HRESULT SetExtent( DWORD
			// dwDrawAspect, SIZEL *psizel );
			[PreserveSig]
			HRESULT SetExtent(DVASPECT dwDrawAspect, in SIZE psizel);

			/// <summary>Retrieves a running object's current display size.</summary>
			/// <param name="dwDrawAspect">
			/// The aspect of the object whose limit is to be retrieved; the value is obtained from the enumerations DVASPECT and from
			/// DVASPECT2. Note that newer objects and containers that support optimized drawing interfaces support the <c>DVASPECT2</c>
			/// enumeration values. Older objects and containers that do not support optimized drawing interfaces may not support
			/// <c>DVASPECT2</c>. The most common value for this method is DVASPECT_CONTENT, which specifies a full rendering of the object
			/// within its container.
			/// </param>
			/// <param name="psizel">Pointer to where the object's size is to be returned.</param>
			/// <returns>
			/// <para>This method returns S_OK on success. Other possible return values include the following.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>The supplied dwDrawAspect value is invalid.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>
			/// A container calls <c>IOleObject::GetExtent</c> on a running object to retrieve its current display size. If the container can
			/// accommodate that size, it will normally do so because the object, after all, knows what size it should be better than the
			/// container does. A container normally makes this call as part of initializing an object.
			/// </para>
			/// <para>
			/// The display size returned by <c>IOleObject::GetExtent</c> may differ from the size last set by IOleObject::SetExtent because
			/// the latter method dictates the object's display space at the time the method is called but does not necessarily change the
			/// object's native size, as determined by its application.
			/// </para>
			/// <para>
			/// If one of the new aspects is requested in dwAspect, this method can either fail or return the same rectangle as for the
			/// DVASPECT_CONTENT aspect.
			/// </para>
			/// <para>
			/// <c>Note</c> This method must return the same size as DVASPECT_CONTENT for all the new aspects in DVASPECT2.
			/// IViewObject2::GetExtent must do the same thing.
			/// </para>
			/// <para>Notes to Callers</para>
			/// <para>
			/// Because a container can make this call only to a running object, the container must instead call IViewObject2::GetExtent if
			/// it wants to get the display size of a loaded object from its cache.
			/// </para>
			/// <para>Notes to Implementers</para>
			/// <para>Implementation consists of filling the sizel structure with an object's height and width.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-ioleobject-getextent HRESULT GetExtent( DWORD
			// dwDrawAspect, SIZEL *psizel );
			[PreserveSig]
			HRESULT GetExtent(DVASPECT dwDrawAspect, out SIZE psizel);

			/// <summary>
			/// Establishes an advisory connection between a compound document object and the calling object's advise sink, through which the
			/// calling object receives notification when the compound document object is renamed, saved, or closed.
			/// </summary>
			/// <param name="pAdvSink">Pointer to the IAdviseSink interface on the advise sink of the calling object.</param>
			/// <param name="pdwConnection">Pointer to a token that can be passed to IOleObject::Unadvise to delete the advisory connection.</param>
			/// <returns>
			/// <para>This method returns S_OK on success. Other possible return values include the following.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>E_OUTOFMEMORY</term>
			/// <term>Insufficient memory available for this operation.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>
			/// The <c>IOleObject::Advise</c> method sets up an advisory connection between an object and its container, through which the
			/// object informs the container's advise sink of close, save, rename, and link-source change events in the object. A container
			/// calls this method, normally as part of initializing an object, to register its advisory sink with the object. In return, the
			/// object sends the container compound-document notifications by calling IAdviseSink or IAdviseSink2.
			/// </para>
			/// <para>
			/// If container and object successfully establish an advisory connection, the object receiving the call returns a nonzero value
			/// through pdwConnection to the container. If the attempt to establish an advisory connection fails, the object returns zero. To
			/// delete an advisory connection, the container calls IOleObject::Unadvise and passes this nonzero token back to the object.
			/// </para>
			/// <para>
			/// An object can delegate the job of managing and tracking advisory events to an OLE advise holder, to which you obtain a
			/// pointer by calling CreateOleAdviseHolder. The returned IOleAdviseHolder interface has three methods for sending advisory
			/// notifications, as well as IOleAdviseHolder::Advise, IOleAdviseHolder::Unadvise, and IOleAdviseHolder::EnumAdvise methods that
			/// are identical to those for IOleObject. Calls to <c>IOleObject::Advise</c>, IOleObject::Unadvise, or IOleObject::EnumAdvise
			/// are delegated to corresponding methods in the advise holder.
			/// </para>
			/// <para>To destroy the advise holder, simply call IUnknown::Release on the IOleAdviseHolder interface.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-ioleobject-advise HRESULT Advise( IAdviseSink *pAdvSink,
			// DWORD *pdwConnection );
			[PreserveSig]
			HRESULT Advise(IAdviseSink pAdvSink, out uint pdwConnection);

			/// <summary>Deletes a previously established advisory connection.</summary>
			/// <param name="dwConnection">
			/// Contains a token of nonzero value, which was previously returned from IOleObject::Advise through its pdwConnection parameter.
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
			/// <term>The operation failed.</term>
			/// </item>
			/// <item>
			/// <term>OLE_E_NOCONNECTION</term>
			/// <term>dwConnection does not represent a valid advisory connection.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// Normally, containers call <c>IOleObject::Unadvise</c> at shutdown or when an object is deleted. In certain cases, containers
			/// can call this method on objects that are running but not currently visible as a way of reducing the overhead of maintaining
			/// multiple advisory connections. The easiest way to implement this method is to delegate the call to <c>IOleObject::Unadvise</c>.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-ioleobject-unadvise HRESULT Unadvise( DWORD dwConnection );
			[PreserveSig]
			HRESULT Unadvise(uint dwConnection);

			/// <summary>
			/// Retrieves a pointer to an enumerator that can be used to enumerate the advisory connections registered for an object, so a
			/// container can know what to release prior to closing down.
			/// </summary>
			/// <param name="ppenumAdvise">
			/// Address of IEnumSTATDATA pointer variable that receives the interface pointer to the enumerator object. If the object does
			/// not have any advisory connections or if an error occurs, the implementation must set ppenumAdvise to NULL. Each time an
			/// object receives a successful call to IOleObject::EnumAdvise, it must increase the reference count on ppenumAdvise. It is the
			/// caller's responsibility to call Release when it is done with the ppenumAdvise.
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
			/// <term>EnumAdvise is not supported.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>
			/// The <c>IOleObject::EnumAdvise</c> method supplies an enumerator that provides a way for containers to keep track of advisory
			/// connections registered for their objects. A container normally would call this function so that it can instruct an object to
			/// release each of its advisory connections prior to closing down.
			/// </para>
			/// <para>
			/// The enumerator to which you get access through <c>IOleObject::EnumAdvise</c> enumerates items of type STATDATA. Upon
			/// receiving the pointer, the container can then loop through <c>STATDATA</c> and call IOleObject::Unadvise for each enumerated connection.
			/// </para>
			/// <para>
			/// The usual way to implement this function is to delegate the call to the IOleAdviseHolder interface. Only the <c>pAdvise</c>
			/// and <c>dwConnection</c> members of STATDATA are relevant for <c>IOleObject::EnumAdvise</c>.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-ioleobject-enumadvise HRESULT EnumAdvise( IEnumSTATDATA
			// **ppenumAdvise );
			[PreserveSig]
			HRESULT EnumAdvise(out IEnumSTATDATA ppenumAdvise);

			/// <summary>Retrieves the status of an object at creation and loading.</summary>
			/// <param name="dwAspect">
			/// The aspect of an object about which status information is being requested. The value is obtained from the enumeration DVASPECT.
			/// </param>
			/// <param name="pdwStatus">Pointer to where the status information is returned. This parameter cannot be <c>NULL</c>.</param>
			/// <returns>
			/// <para>This method returns S_OK on success. Other possible return values include the following.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>OLE_S_USEREG</term>
			/// <term>Delegate the retrieval of miscellaneous status information to the default handler's implementation of this method.</term>
			/// </item>
			/// <item>
			/// <term>CO_E_CLASSNOTREG</term>
			/// <term>There is no CLSID registered for the object.</term>
			/// </item>
			/// <item>
			/// <term>CO_E_READREGDB</term>
			/// <term>Error accessing the registry.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>
			/// A container normally calls <c>IOleObject::GetMiscStatus</c> when it creates or loads an object in order to determine how to
			/// display the object and what types of behaviors it supports.
			/// </para>
			/// <para>
			/// Objects store status information in the registry. If the object is not running, the default handler's implementation of
			/// <c>IOleObject::GetMiscStatus</c> retrieves this information from the registry. If the object is running, the default handler
			/// invokes <c>IOleObject::GetMiscStatus</c> on the object itself.
			/// </para>
			/// <para>
			/// The information that is actually stored in the registry varies with individual objects. The status values to be returned are
			/// defined in the enumeration OLEMISC.
			/// </para>
			/// <para>
			/// The default value of <c>IOleObject::GetMiscStatus</c> is used if a subkey corresponding to the specified DVASPECT is not
			/// found. To set an OLE control, specify DVASPECT==1. This will cause the following to occur in the registry:
			/// </para>
			/// <para><c>HKEY_CLASSES_ROOT\CLSID\ . . .</c><c>MiscStatus</c> = 1</para>
			/// <para>Notes to Implementers</para>
			/// <para>Implementation normally consists of delegating the call to the default handler.</para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-ioleobject-getmiscstatus HRESULT GetMiscStatus( DWORD
			// dwAspect, DWORD *pdwStatus );
			[PreserveSig]
			HRESULT GetMiscStatus(DVASPECT dwAspect, out uint pdwStatus);

			/// <summary>Specifies the color palette that the object application should use when it edits the specified object.</summary>
			/// <param name="pLogpal">Pointer to a LOGPALETTE structure that specifies the recommended palette.</param>
			/// <returns>
			/// <para>This method returns S_OK on success. Other possible return values include the following.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>E_NOTIMPL</term>
			/// <term>Object does not support setting palettes.</term>
			/// </item>
			/// <item>
			/// <term>OLE_E_PALETTE</term>
			/// <term>Invalid LOGPALETTE structure pointed to by pLogPal.</term>
			/// </item>
			/// <item>
			/// <term>OLE_E_NOTRUNNING</term>
			/// <term>Object must be running to perform this operation.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// The <c>IOleObject::SetColorScheme</c> method sends the container application's recommended color palette to the object
			/// application, which is not obliged to use it.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-ioleobject-setcolorscheme HRESULT SetColorScheme(
			// LOGPALETTE *pLogpal );
			[PreserveSig]
			HRESULT SetColorScheme(IntPtr pLogpal);
		}

		/// <summary>
		/// The IOleWindow interface provides methods that allow an application to obtain the handle to the various windows that participate
		/// in in-place activation, and also to enter and exit context-sensitive help mode.
		/// </summary>
		[PInvokeData("Oleidl.h")]
		[ComImport, Guid("00000114-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IOleWindow
		{
			/// <summary>
			/// Retrieves a handle to one of the windows participating in in-place activation (frame, document, parent, or in-place object window).
			/// </summary>
			/// <returns>A pointer to a variable that receives the window handle.</returns>
			HWND GetWindow();

			/// <summary>Determines whether context-sensitive help mode should be entered during an in-place activation session.</summary>
			/// <param name="fEnterMode"><c>true</c> if help mode should be entered; <c>false</c> if it should be exited.</param>
			void ContextSensitiveHelp([MarshalAs(UnmanagedType.Bool)] bool fEnterMode);
		}

		/// <summary>
		/// <para>Parses a displayable name string to convert it into a moniker for custom moniker implementations.</para>
		/// <para>Display name parsing is necessary when the end user inputs a string to identify a component, as in the following situations:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// A compound document application that supports linked components typically supports the <c>Edit:Links...</c> dialog box. Through
		/// this dialog box, the end user can enter a display name to specify a new link source for a specified linked component. The
		/// compound document needs to have this input string converted into a moniker.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// A script language such as the macro language of a spreadsheet can allow textual references to a component. The language's
		/// interpreter needs to have such a reference converted into a moniker in order to execute the macro.
		/// </term>
		/// </item>
		/// </list>
		/// <para>This interface is not supported for use across machine boundaries.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nn-oleidl-iparsedisplayname
		[PInvokeData("oleidl.h", MSDNShortId = "37844d9b-35ce-4d30-8a58-dac4c671896f")]
		[ComImport, Guid("0000011a-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IParseDisplayName
		{
			/// <summary>Parses the specified display name and creates a corresponding moniker.</summary>
			/// <param name="pbc">A pointer to the bind context to be used in this binding operation. See IBindCtx.</param>
			/// <param name="pszDisplayName">The display name to be parsed.</param>
			/// <param name="pchEaten">
			/// A pointer to a variable that receives the number of characters in the display name that correspond to the ppmkOut moniker.
			/// </param>
			/// <param name="ppmkOut">
			/// A pointer to an IMoniker pointer variable that receives the interface pointer to the resulting moniker. If an error occurs,
			/// the implementation sets *ppmkOut to <c>NULL</c>. If *ppmkOut is non- <c>NULL</c>, the implementation must call AddRef; it is
			/// the caller's responsibility to call Release.
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
			/// <term>MK_E_SYNTAX</term>
			/// <term>
			/// There is a syntax error in the display name. Parsing failed because pszDisplayName could only be partially resolved into a
			/// moniker. In this case, *pchEaten has the number of characters that were successfully parsed into a moniker prefix. The
			/// parameter ppmkOut should be NULL.
			/// </term>
			/// </item>
			/// <item>
			/// <term>MK_E_NOOBJECT</term>
			/// <term>The display name does not identify a component in this namespace.</term>
			/// </item>
			/// <item>
			/// <term>E_INVALIDARG</term>
			/// <term>One or more parameters are not valid.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// <para>
			/// In general, the maximum prefix of pszDisplayName that is syntactically valid and that represents an object should be consumed
			/// by this method and converted to a moniker.
			/// </para>
			/// <para>
			/// Typically, this method is called by MkParseDisplayName or MkParseDisplayNameEx. In the initial step of the parsing operation,
			/// these functions can retrieve the IParseDisplayName interface directly from an instance of a class identified with either the
			/// "@ProgID" or "ProgID" notation. Subsequent parsing steps can query for the interface on an intermediate object.
			/// </para>
			/// <para>
			/// The main loops of MkParseDisplayName and MkParseDisplayNameEx find the next moniker piece by calling the equivalent method in
			/// the IMoniker interface, that is, IMoniker::ParseDisplayName, on the moniker that it currently holds. In this call to
			/// <c>IMoniker::ParseDisplayName</c>, the <c>MkParseDisplayName</c> or <c>MkParseDisplayNameEx</c> function passes <c>NULL</c>
			/// in the pmkToLeft parameter. If the moniker currently held is a generic composite, the call to
			/// <c>IMoniker::ParseDisplayName</c> is forwarded by that composite onto its last piece, passing the prefix of the composite to
			/// the left of the piece in pmkToLeft.
			/// </para>
			/// <para>
			/// Some moniker classes will be able to handle this parsing internally to themselves because they are designed to designate only
			/// certain kinds of objects. Others will need to bind to the object that they designate to accomplish the parsing process. As is
			/// usual, these objects should not be released by IMoniker::ParseDisplayName but instead should be transferred to the bind
			/// context via IBindCtx::RegisterObjectBound or IBindCtx::GetRunningObjectTable followed by IRunningObjectTable::Register for
			/// release at a later time.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/nf-oleidl-iparsedisplayname-parsedisplayname HRESULT
			// ParseDisplayName( IBindCtx *pbc, LPOLESTR pszDisplayName, ULONG *pchEaten, IMoniker **ppmkOut );
			[PreserveSig]
			HRESULT ParseDisplayName(IBindCtx pbc, [MarshalAs(UnmanagedType.LPWStr)] string pszDisplayName, out uint pchEaten, out IMoniker ppmkOut);
		}

		/// <summary>
		/// <para>
		/// Provides the CLSID of an object that can be stored persistently in the system. Allows the object to specify which object handler
		/// to use in the client process, as it is used in the default implementation of marshaling.
		/// </para>
		/// <para>
		/// <c>IPersist</c> is the base interface for three other interfaces: IPersistStorage, IPersistStream, and IPersistFile. Each of
		/// these interfaces, therefore, includes the GetClassID method, and the appropriate one of these three interfaces is implemented on
		/// objects that can be serialized to a storage, a stream, or a file. The methods of these interfaces allow the state of these
		/// objects to be saved for later instantiations, and load the object using the saved state. Typically, the persistence interfaces
		/// are implemented by an embedded or linked object, and are called by the container application or the default object handler.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nn-objidl-ipersist
		[PInvokeData("objidl.h", MSDNShortId = "932eb0e2-35a6-482e-9138-00cff30508a9")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("0000010c-0000-0000-C000-000000000046")]
		public interface IPersist
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
			/// A container application might call this method to retrieve the original CLSID of an object that it is treating as a different
			/// class. Such a call would be necessary if a user performed an editing operation that required the object to be saved. If the
			/// container were to save it using the treat-as CLSID, the original application would no longer be able to edit the object.
			/// Typically, in this case, the container calls the OleSave helper function, which performs all the necessary steps. For this
			/// reason, most container applications have no need to call this method directly.
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
			/// <c>TreatAs</c> registry key has been set by an application that supports emulation (and so is treating the object as one of a
			/// different class), a call to <c>GetClassID</c> must supply the CLSID specified in the <c>TreatAs</c> key. For more information
			/// on emulation, see CoTreatAsClass.
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
			Guid GetClassID();
		}

		/// <summary>Enables the saving and loading of objects that use a simple serial stream for their storage needs.</summary>
		/// <remarks>
		/// <para>
		/// One way in which this interface is used is to support OLE moniker implementations. Each of the OLE-provided moniker interfaces
		/// provides an <c>IPersistStream</c> implementation through which the moniker saves or loads itself. An instance of the OLE generic
		/// composite moniker class calls the <c>IPersistStream</c> methods of its component monikers to load or save the components in the
		/// proper sequence in a single stream.
		/// </para>
		/// <para>IPersistStream URL Moniker Implementation</para>
		/// <para>
		/// The URL moniker implementation of <c>IPersistStream</c> is found on an URL moniker object, which supports IUnknown,
		/// <c>IAsyncMoniker</c>, and IMoniker. The <c>IMoniker</c> interface inherits its definition from <c>IPersistStream</c> and thus,
		/// the URL moniker also provides an implementation of <c>IPersistStream</c> as part of its implementation of <c>IMoniker</c>.
		/// </para>
		/// <para>
		/// The IAsyncMoniker interface on an URL moniker is simply IUnknown (there are no additional methods); it is used to allow clients
		/// to determine if a moniker supports asynchronous binding. To get a pointer to the IMoniker interface on this object, call the
		/// <c>CreateURLMonikerEx</c> function. Then, to get a pointer to <c>IPersistStream</c>, call the QueryInterface method.
		/// </para>
		/// <para>
		/// <c>IPersistStream</c>, in addition to inheriting its definition from IUnknown, also inherits the single method of IPersist, GetClassID.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nn-objidl-ipersiststream
		[PInvokeData("objidl.h", MSDNShortId = "97ea64ee-d950-4872-add6-1f532a6eb33f")]
		[ComImport, Guid("00000109-0000-0000-C000-000000000046"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IPersistStream : IPersist
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
			/// A container application might call this method to retrieve the original CLSID of an object that it is treating as a different
			/// class. Such a call would be necessary if a user performed an editing operation that required the object to be saved. If the
			/// container were to save it using the treat-as CLSID, the original application would no longer be able to edit the object.
			/// Typically, in this case, the container calls the OleSave helper function, which performs all the necessary steps. For this
			/// reason, most container applications have no need to call this method directly.
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
			/// <c>TreatAs</c> registry key has been set by an application that supports emulation (and so is treating the object as one of a
			/// different class), a call to <c>GetClassID</c> must supply the CLSID specified in the <c>TreatAs</c> key. For more information
			/// on emulation, see CoTreatAsClass.
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

			/// <summary>Determines whether an object has changed since it was last saved to its stream.</summary>
			/// <returns>This method returns S_OK to indicate that the object has changed. Otherwise, it returns S_FALSE.</returns>
			/// <remarks>
			/// <para>
			/// Use this method to determine whether an object should be saved before closing it. The dirty flag for an object is
			/// conditionally cleared in the IPersistStream::Save method.
			/// </para>
			/// <para>Notes to Callers</para>
			/// <para>
			/// You should treat any error return codes as an indication that the object has changed. Unless this method explicitly returns
			/// S_FALSE, assume that the object must be saved.
			/// </para>
			/// <para>
			/// Note that the OLE-provided implementations of the <c>IPersistStream::IsDirty</c> method in the OLE-provided moniker
			/// interfaces always return S_FALSE because their internal state never changes.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-ipersiststream-isdirty HRESULT IsDirty( );
			[PreserveSig]
			HRESULT IsDirty();

			/// <summary>Initializes an object from the stream where it was saved previously.</summary>
			/// <param name="pstm">The PSTM.</param>
			/// <remarks>
			/// <para>
			/// This method loads an object from its associated stream. The seek pointer is set as it was in the most recent
			/// IPersistStream::Save method. This method can seek and read from the stream, but cannot write to it.
			/// </para>
			/// <para>Notes to Callers</para>
			/// <para>
			/// Rather than calling <c>IPersistStream::Load</c> directly, you typically call the OleLoadFromStream function does the following:
			/// </para>
			/// <list type="number">
			/// <item>
			/// <term>Calls the ReadClassStm function to get the class identifier from the stream.</term>
			/// </item>
			/// <item>
			/// <term>Calls the CoCreateInstance function to create an instance of the object.</term>
			/// </item>
			/// <item>
			/// <term>Queries the instance for IPersistStream.</term>
			/// </item>
			/// <item>
			/// <term>Calls <c>IPersistStream::Load</c>.</term>
			/// </item>
			/// </list>
			/// <para>
			/// The OleLoadFromStream function assumes that objects are stored in the stream with a class identifier followed by the object
			/// data. This storage pattern is used by the generic, composite-moniker implementation provided by OLE.
			/// </para>
			/// <para>If the objects are not stored using this pattern, you must call the methods separately yourself.</para>
			/// <para>URL Moniker Notes</para>
			/// <para>
			/// Initializes an URL moniker from data within a stream, usually stored there previously using its IPersistStream::Save (using
			/// OleSaveToStream). The binary format of the URL moniker is its URL string in Unicode (may be a full or partial URL string, see
			/// CreateURLMonikerEx for details). This is represented as a <c>ULONG</c> count of characters followed by that many Unicode characters.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-ipersiststream-load HRESULT Load( IStream *pStm );
			void Load([In, MarshalAs(UnmanagedType.Interface)] IStream pstm);

			/// <summary>Saves an object to the specified stream.</summary>
			/// <param name="pstm">The PSTM.</param>
			/// <param name="fClearDirty">
			/// Indicates whether to clear the dirty flag after the save is complete. If <c>TRUE</c>, the flag should be cleared. If
			/// <c>FALSE</c>, the flag should be left unchanged.
			/// </param>
			/// <remarks>
			/// <para>
			/// <c>IPersistStream::Save</c> saves an object into the specified stream and indicates whether the object should reset its dirty flag.
			/// </para>
			/// <para>
			/// The seek pointer is positioned at the location in the stream at which the object should begin writing its data. The object
			/// calls the ISequentialStream::Write method to write its data.
			/// </para>
			/// <para>
			/// On exit, the seek pointer must be positioned immediately past the object data. The position of the seek pointer is undefined
			/// if an error returns.
			/// </para>
			/// <para>Notes to Callers</para>
			/// <para>
			/// Rather than calling <c>IPersistStream::Save</c> directly, you typically call the OleSaveToStream helper function which does
			/// the following:
			/// </para>
			/// <list type="number">
			/// <item>
			/// <term>Calls GetClassID to get the object's CLSID.</term>
			/// </item>
			/// <item>
			/// <term>Calls the WriteClassStm function to write the object's CLSID to the stream.</term>
			/// </item>
			/// <item>
			/// <term>Calls <c>IPersistStream::Save</c>.</term>
			/// </item>
			/// </list>
			/// <para>If you call these methods directly, you can write other data into the stream after the CLSID before calling <c>IPersistStream::Save</c>.</para>
			/// <para>The OLE-provided implementation of IPersistStream follows this same pattern.</para>
			/// <para>Notes to Implementers</para>
			/// <para>
			/// The <c>IPersistStream::Save</c> method does not write the CLSID to the stream. The caller is responsible for writing the CLSID.
			/// </para>
			/// <para>
			/// The <c>IPersistStream::Save</c> method can read from, write to, and seek in the stream; but it must not seek to a location in
			/// the stream before that of the seek pointer on entry.
			/// </para>
			/// <para>URL Moniker Notes</para>
			/// <para>
			/// Saves an URL moniker to a stream. The binary format of URL moniker is its URL string in Unicode (may be a full or partial URL
			/// string, see CreateURLMonikerEx for details). This is represented as a <c>ULONG</c> count of characters followed by that many
			/// Unicode characters.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-ipersiststream-save HRESULT Save( IStream *pStm, BOOL
			// fClearDirty );
			void Save([In, MarshalAs(UnmanagedType.Interface)] IStream pstm, [In, MarshalAs(UnmanagedType.Bool)] bool fClearDirty);

			/// <summary>Retrieves the size of the stream needed to save the object.</summary>
			/// <returns>The size in bytes of the stream needed to save this object, in bytes.</returns>
			/// <remarks>
			/// <para>
			/// This method returns the size needed to save an object. You can call this method to determine the size and set the necessary
			/// buffers before calling the IPersistStream::Save method.
			/// </para>
			/// <para>Notes to Implementers</para>
			/// <para>
			/// The <c>GetSizeMax</c> implementation should return a conservative estimate of the necessary size because the caller might
			/// call the IPersistStream::Save method with a non-growable stream.
			/// </para>
			/// <para>URL Moniker Notes</para>
			/// <para>
			/// This method retrieves the maximum number of bytes in the stream that will be required by a subsequent call to
			/// IPersistStream::Save. This value is sizeof(ULONG)==4 plus sizeof(WCHAR)*n where n is the length of the full or partial URL
			/// string, including the NULL terminator.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/objidl/nf-objidl-ipersiststream-getsizemax HRESULT GetSizeMax(
			// ULARGE_INTEGER *pcbSize );
			ulong GetSizeMax();
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
			/// A container application might call this method to retrieve the original CLSID of an object that it is treating as a different
			/// class. Such a call would be necessary if a user performed an editing operation that required the object to be saved. If the
			/// container were to save it using the treat-as CLSID, the original application would no longer be able to edit the object.
			/// Typically, in this case, the container calls the OleSave helper function, which performs all the necessary steps. For this
			/// reason, most container applications have no need to call this method directly.
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
			/// <c>TreatAs</c> registry key has been set by an application that supports emulation (and so is treating the object as one of a
			/// different class), a call to <c>GetClassID</c> must supply the CLSID specified in the <c>TreatAs</c> key. For more information
			/// on emulation, see CoTreatAsClass.
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
			void Load([In, MarshalAs(UnmanagedType.Interface)] IStream pstm);

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
			void Save([In, MarshalAs(UnmanagedType.Interface)] IStream pstm, [In, MarshalAs(UnmanagedType.Bool)] bool fClearDirty);

			/// <summary>Retrieves the size of the stream needed to save the object.</summary>
			/// <returns>The size in bytes of the stream needed to save this object, in bytes.</returns>
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
			// https://docs.microsoft.com/en-us/windows/desktop/api/ocidl/nf-ocidl-ipersiststreaminit-getsizemax HRESULT GetSizeMax(
			// ULARGE_INTEGER *pCbSize );
			ulong GetSizeMax();

			/// <summary>Initializes an object to a default state. This method is to be called instead of IPersistStreamInit::Load.</summary>
			/// <remarks>If the object has already been initialized with IPersistStreamInit::Load, then this method must return E_UNEXPECTED.</remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/ocidl/nf-ocidl-ipersiststreaminit-initnew HRESULT InitNew( );
			void InitNew();
		}

		/// <summary>
		/// Contains information about the accelerators supported by a container during an in-place session. The structure is used in the
		/// IOleInPlaceSite::GetWindowContext method and the OleTranslateAccelerator function.
		/// </summary>
		/// <remarks>
		/// When an object is being in-place activated, its server calls the container's IOleInPlaceSite::GetWindowContext method, which
		/// fills in an <c>OLEINPLACEFRAMEINFO</c> structure. During an in-place session, the message loop of an EXE server passes a pointer
		/// to the <c>OLEINPLACEFRAMEINFO</c> structure to OleTranslateAccelerator. OLE uses the information in this structure to determine
		/// whether a message maps to one of the container's accelerators.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/ns-oleidl-oleinplaceframeinfo typedef struct tagOIFI { UINT cb; BOOL
		// fMDIApp; HWND hwndFrame; HACCEL haccel; UINT cAccelEntries; } OLEINPLACEFRAMEINFO, *LPOLEINPLACEFRAMEINFO;
		[PInvokeData("oleidl.h", MSDNShortId = "e09445d2-61e5-4691-b51e-746e0cc91c00")]
		[StructLayout(LayoutKind.Sequential)]
		public struct OIFI
		{
			/// <summary>
			/// The size of this structure, in bytes. The object server must specify sizeof( <c>OLEINPLACEFRAMEINFO</c>) in the structure it
			/// passes to IOleInPlaceSite::GetWindowContext. The container can then use this size to determine the structure's version.
			/// </summary>
			public uint cb;

			/// <summary>Indicates whether the container is an MDI application.</summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool fMDIApp;

			/// <summary>A handle to the container's top-level frame window.</summary>
			public HWND hwndFrame;

			/// <summary>A handle to the accelerator table that the container wants to use during an in-place editing session.</summary>
			public HACCEL haccel;

			/// <summary>The number of accelerators in <c>haccel</c>.</summary>
			public uint cAccelEntries;
		}

		/// <summary>
		/// Indicates the number of menu items in each of the six menu groups of a menu shared between a container and an object server
		/// during an in-place editing session. This is the mechanism for building a shared menu.
		/// </summary>
		[PInvokeData("Oleidl.h", MSDNShortId = "ms693766")]
		[StructLayout(LayoutKind.Sequential)]
		public struct OLEMENUGROUPWIDTHS
		{
			/// <summary>
			/// An array whose elements contain the number of menu items in each of the six menu groups of a shared in-place editing menu.
			/// Each menu group can have any number of menu items. The container uses elements 0, 2, and 4 to indicate the number of menu
			/// items in its File, View, and Window menu groups. The object server uses elements 1, 3, and 5 to indicate the number of menu
			/// items in its Edit, Object, and Help menu groups.
			/// </summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
			public uint[] width;
		}

		/// <summary>
		/// Defines a verb that an object supports. The IOleObject::EnumVerbs method creates an enumerator that can enumerate these
		/// structures for an object, and supplies a pointer to the enumerator's IEnumOLEVERB.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/oleidl/ns-oleidl-oleverb typedef struct tagOLEVERB { LONG lVerb; LPOLESTR
		// lpszVerbName; DWORD fuFlags; DWORD grfAttribs; } OLEVERB, *LPOLEVERB;
		[PInvokeData("oleidl.h", MSDNShortId = "657e3cc3-67fb-4458-8dad-f2a31df1b631")]
		[StructLayout(LayoutKind.Sequential)]
		public struct OLEVERB
		{
			/// <summary>Integer identifier associated with this verb.</summary>
			public int lVerb;

			/// <summary>Pointer to a string that contains the verb's name.</summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string lpszVerbName;

			/// <summary>
			/// In Windows, a group of flags taken from the flag constants beginning with MF_ defined in AppendMenu. Containers should use
			/// these flags in building an object's verb menu. All Flags defined in <c>AppendMenu</c> are supported except for MF_BITMAP,
			/// MF_OWNERDRAW, and MF_POPUP.
			/// </summary>
			public uint fuFlags;

			/// <summary>Combination of the verb attributes in the OLEVERBATTRIB enumeration.</summary>
			public OLEVERBATTRIB grfAttribs;
		}
	}
}