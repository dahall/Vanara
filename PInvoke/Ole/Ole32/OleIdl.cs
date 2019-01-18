using System;
using System.Drawing;
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
		[ComImport(), Guid("00000122-0000-0000-C000-000000000046"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
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
			HRESULT DragEnter([In, MarshalAs(UnmanagedType.Interface)] object pDataObj,
				[In] uint grfKeyState, [In] Point pt, [In, Out] ref uint pdwEffect);

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
			HRESULT DragOver([In] uint grfKeyState, [In] Point pt, [In, Out] ref uint pdwEffect);

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
			[DllImport(Lib.OleIdl, SetLastError = false, ExactSpelling = true)]
			[PInvokeData("oleidl.h", MSDNShortId = "7ea6d815-bf8f-47d5-99d3-f9a55bafee2e")]
			// public static extern HRESULT Drop(ref IDataObject pDataObj, uint grfKeyState, POINTL pt, ref uint pdwEffect);
			[PreserveSig]
			HRESULT Drop([In, MarshalAs(UnmanagedType.Interface)] object pDataObj, [In] uint grfKeyState, [In] Point pt,
				[In, Out] ref uint pdwEffect);
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
	}
}