using System;
using System.Runtime.InteropServices;

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