using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;

namespace Vanara.PInvoke
{
	public static partial class Shell32
	{
		/// <summary>The flags that determine the characteristics of a drag-and-drop operation over an IDragSourceHelper object.</summary>
		[PInvokeData("shobjidl.h", MSDNShortId = "NF:shobjidl.IDragSourceHelper2.SetFlags")]
		[Flags]
		public enum DSH_FLAGS
		{
			/// <summary>
			/// Allow text specified in DROPDESCRIPTION to be displayed on the drag image. If you pass this flag into the dwFlags parameter
			/// of <c>IDragSourceHelper2::SetFlags</c>, then the text description is rendered on top of the supplied drag image. If you pass
			/// a drag image into an IDragSourceHelper object, then by default, the extra text description of the drag-and-drop operation is
			/// not displayed.
			/// </summary>
			DSH_ALLOWDROPDESCRIPTIONTEXT = 0x1
		}

		/// <summary>
		/// Exposed by the Shell to allow an application to specify the image that will be displayed during a Shell drag-and-drop operation.
		/// </summary>
		/// <remarks>
		/// <para>This interface is exposed by the Shell's drag-image manager. It is not implemented by applications.</para>
		/// <para>
		/// Use this interface to specify the image displayed during a Shell drag-and-drop operation. The <c>IDragSourceHelper</c>,
		/// IDropTargetHelper, and IInitializeWithWindow interfaces are exposed by the drag-image manager object to allow the IDropTarget
		/// interface to use custom drag images. To use either of these interfaces, you must create an in-process server drag-image manager
		/// object by calling CoCreateInstance with a class identifier (CLSID) of CLSID_DragDropHelper. Get interface pointers using
		/// standard Component Object Model (COM) procedures.
		/// </para>
		/// <para>The <c>IDragSourceHelper</c> interface provides the following two ways to specify the bitmap to be used as a drag image.</para>
		/// <list type="bullet">
		/// <item>
		/// <term>
		/// Controls that have a window can register a DI_GETDRAGIMAGE window message for it and initialize the drag-image manager with
		/// IDragSourceHelper::InitializeFromWindow. When the DI_GETDRAGIMAGE message is received, the handler puts the drag image bitmap
		/// information in the SHDRAGIMAGE structure that is passed as the message's lParam value.
		/// </term>
		/// </item>
		/// <item>
		/// <term>
		/// Windowless controls can initialize the drag-image manager with IDragSourceHelper::InitializeFromBitmap. This method allows an
		/// application to simply specify the bitmap.
		/// </term>
		/// </item>
		/// </list>
		/// <para>
		/// <c>Note</c> The drag-and-drop helper object calls IDataObject::SetData to load private formats—used for cross-process
		/// support—into the data object. It later retrieves these formats by calling IDataObject::GetData. To support the drag-and-drop
		/// helper object, the data object's <c>SetData</c> and <c>GetData</c> implementations must be able to accept and return arbitrary
		/// private formats.
		/// </para>
		/// <para>For further discussion of Shell drag-and-drop operations, see Transferring Shell Data Using Drag-and-Drop or the Clipboard.</para>
		/// <para><c>Note</c> Prior to Windows Vista this interface was declared in Shlobj.h.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-idragsourcehelper
		[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.IDragSourceHelper")]
		[ComImport, Guid("DE5BF786-477A-11D2-839D-00C04FD918D0"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IDragSourceHelper
		{
			/// <summary>Initializes the drag-image manager for a windowless control.</summary>
			/// <param name="pshdi">
			/// <para>Type: <c>LPSHDRAGIMAGE</c></para>
			/// <para>The SHDRAGIMAGE structure that contains information about the bitmap.</para>
			/// </param>
			/// <param name="pDataObject">
			/// <para>Type: <c>IDataObject*</c></para>
			/// <para>A pointer to the data object's IDataObject interface.</para>
			/// </param>
			/// <remarks>
			/// Because <c>InitializeFromBitmap</c> always performs the RGB multiplication step in calculating the alpha value, you should
			/// always pass a bitmap without premultiplied alpha blending. Note that no error will result from passing the method a bitmap
			/// with premultiplied alpha blending, but this method will multiply it again, doubling the resulting alpha value.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-idragsourcehelper-initializefrombitmap
			// HRESULT InitializeFromBitmap( LPSHDRAGIMAGE pshdi, IDataObject *pDataObject );
			void InitializeFromBitmap(in SHDRAGIMAGE pshdi, [In] IDataObject pDataObject);

			/// <summary>Initializes the drag-image manager for a control with a window.</summary>
			/// <param name="hwnd">
			/// <para>Type: <c>HWND</c></para>
			/// <para>A handle to the window that receives the <c>DI_GETDRAGIMAGE</c> message. This value can be <c>NULL</c>.</para>
			/// </param>
			/// <param name="ppt">
			/// <para>Type: <c>POINT*</c></para>
			/// <para>
			/// A pointer to a POINT structure that specifies the location of the cursor within the drag image. The structure should contain
			/// the offset from the upper-left corner of the drag image to the location of the cursor. This value can be <c>NULL</c>.
			/// </para>
			/// </param>
			/// <param name="pDataObject">
			/// <para>Type: <c>IDataObject*</c></para>
			/// <para>A pointer to the data object's IDataObject interface.</para>
			/// </param>
			/// <remarks>
			/// The <c>DI_GETDRAGIMAGE</c> message allows you to source a drag image from a custom control. It is defined in Shlobj.h and
			/// must be registered with RegisterWindowMessage. When the window specified by hwnd receives the <c>DI_GETDRAGIMAGE</c>
			/// message, the lParam value holds a pointer to an SHDRAGIMAGE structure. The handler should fill the structure with the drag
			/// image bitmap information.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-idragsourcehelper-initializefromwindow
			// HRESULT InitializeFromWindow( HWND hwnd, POINT *ppt, IDataObject *pDataObject );
			void InitializeFromWindow([In, Optional] HWND hwnd, [In, Optional] IntPtr ppt, [In] IDataObject pDataObject);
		}

		/// <summary>
		/// Exposes a method that adds functionality to IDragSourceHelper. This method sets the characteristics of a drag-and-drop operation
		/// over an <c>IDragSourceHelper</c> object.
		/// </summary>
		/// <remarks>
		/// <para>This interface also provides the methods of the IDragSourceHelper interface, from which it inherits.</para>
		/// <para>
		/// If you want to adjust the behavior of the drag image by calling IDragSourceHelper2::SetFlags, that call should be made before
		/// you call InitializeFromWindow or InitializeFromBitmap.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nn-shobjidl-idragsourcehelper2
		[PInvokeData("shobjidl.h", MSDNShortId = "NN:shobjidl.IDragSourceHelper2")]
		[ComImport, Guid("83E07D0D-0C5F-4163-BF1A-60B274051E40"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IDragSourceHelper2 : IDragSourceHelper
		{
			/// <summary>Initializes the drag-image manager for a windowless control.</summary>
			/// <param name="pshdi">
			/// <para>Type: <c>LPSHDRAGIMAGE</c></para>
			/// <para>The SHDRAGIMAGE structure that contains information about the bitmap.</para>
			/// </param>
			/// <param name="pDataObject">
			/// <para>Type: <c>IDataObject*</c></para>
			/// <para>A pointer to the data object's IDataObject interface.</para>
			/// </param>
			/// <remarks>
			/// Because <c>InitializeFromBitmap</c> always performs the RGB multiplication step in calculating the alpha value, you should
			/// always pass a bitmap without premultiplied alpha blending. Note that no error will result from passing the method a bitmap
			/// with premultiplied alpha blending, but this method will multiply it again, doubling the resulting alpha value.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-idragsourcehelper-initializefrombitmap
			// HRESULT InitializeFromBitmap( LPSHDRAGIMAGE pshdi, IDataObject *pDataObject );
			new void InitializeFromBitmap(in SHDRAGIMAGE pshdi, [In] IDataObject pDataObject);

			/// <summary>Initializes the drag-image manager for a control with a window.</summary>
			/// <param name="hwnd">
			/// <para>Type: <c>HWND</c></para>
			/// <para>A handle to the window that receives the <c>DI_GETDRAGIMAGE</c> message. This value can be <c>NULL</c>.</para>
			/// </param>
			/// <param name="ppt">
			/// <para>Type: <c>POINT*</c></para>
			/// <para>
			/// A pointer to a POINT structure that specifies the location of the cursor within the drag image. The structure should contain
			/// the offset from the upper-left corner of the drag image to the location of the cursor. This value can be <c>NULL</c>.
			/// </para>
			/// </param>
			/// <param name="pDataObject">
			/// <para>Type: <c>IDataObject*</c></para>
			/// <para>A pointer to the data object's IDataObject interface.</para>
			/// </param>
			/// <remarks>
			/// The <c>DI_GETDRAGIMAGE</c> message allows you to source a drag image from a custom control. It is defined in Shlobj.h and
			/// must be registered with RegisterWindowMessage. When the window specified by hwnd receives the <c>DI_GETDRAGIMAGE</c>
			/// message, the lParam value holds a pointer to an SHDRAGIMAGE structure. The handler should fill the structure with the drag
			/// image bitmap information.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-idragsourcehelper-initializefromwindow
			// HRESULT InitializeFromWindow( HWND hwnd, POINT *ppt, IDataObject *pDataObject );
			new void InitializeFromWindow([In, Optional] HWND hwnd, [In, Optional] IntPtr ppt, [In] IDataObject pDataObject);

			/// <summary>Sets the characteristics of a drag-and-drop operation over an IDragSourceHelper object.</summary>
			/// <param name="dwFlags">
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The flags that determine the characteristics of a drag-and-drop operation over an IDragSourceHelper object.</para>
			/// <para>DSH_ALLOWDROPDESCRIPTIONTEXT (0x0001)</para>
			/// <para>
			/// Allow text specified in DROPDESCRIPTION to be displayed on the drag image. If you pass this flag into the dwFlags parameter
			/// of <c>IDragSourceHelper2::SetFlags</c>, then the text description is rendered on top of the supplied drag image. If you pass
			/// a drag image into an IDragSourceHelper object, then by default, the extra text description of the drag-and-drop operation is
			/// not displayed.
			/// </para>
			/// </param>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl/nf-shobjidl-idragsourcehelper2-setflags HRESULT SetFlags( DWORD
			// dwFlags );
			void SetFlags([In] DSH_FLAGS dwFlags);
		}

		/// <summary>Exposes methods that allow drop targets to display a drag image while the image is over the target window.</summary>
		/// <remarks>
		/// <para>This interface is exposed by the Shell's drag-image manager. It is not implemented by applications.</para>
		/// <para>
		/// This interface is used by drop targets to enable the drag-image manager to display the drag image while the image is over the
		/// target window. The IDragSourceHelper and <c>IDropTargetHelper</c> interfaces are exposed by the drag-image manager object to
		/// allow the IDropTarget interface to use custom drag images. To use either of these interfaces, you must create an in-process
		/// server drag-image manager object by calling CoCreateInstance with a class identifier (CLSID) of CLSID_DragDropHelper. Get
		/// interface pointers using standard Component Object Model (COM) procedures.
		/// </para>
		/// <para>
		/// Four of the <c>IDropTargetHelper</c> methods correspond to the four IDropTarget methods. When you implement <c>IDropTarget</c>,
		/// each of its methods should call the corresponding <c>IDropTargetHelper</c> method to pass the information to the drag-image
		/// manager. The fifth <c>IDropTargetHelper</c> method notifies the drag-image manager to show or hide the drag image. This method
		/// is used when dragging over a target window in a low color-depth video mode. It allows the target to hide the drag image while it
		/// is painting the window.
		/// </para>
		/// <para>
		/// <c>Note</c> The drag-and-drop helper object calls IDataObject::SetData to load private formats—used for cross-process
		/// support—into the data object. It later retrieves these formats by calling IDataObject::GetData. To support the drag-and-drop
		/// helper object, the data object's <c>SetData</c> and <c>GetData</c> implementations must be able to accept and return arbitrary
		/// private formats.
		/// </para>
		/// <para>For further discussion of Shell drag-and-drop operations, see Transferring Shell Data Using Drag-and-Drop or the Clipboard.</para>
		/// <para><c>Note</c> Prior to Windows Vista this interface was declared in Shlobj.h.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-idroptargethelper
		[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.IDropTargetHelper")]
		[ComImport, Guid("4657278B-411B-11D2-839A-00C04FD918D0"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IDropTargetHelper
		{
			/// <summary>Notifies the drag-image manager that the drop target's IDropTarget::DragEnter method has been called.</summary>
			/// <param name="hwndTarget">
			/// <para>Type: <c>HWND</c></para>
			/// <para>The target's window handle.</para>
			/// </param>
			/// <param name="pDataObject">
			/// <para>Type: <c>IDataObject*</c></para>
			/// <para>A pointer to the data object's IDataObject interface.</para>
			/// </param>
			/// <param name="ppt">
			/// <para>Type: <c>POINT*</c></para>
			/// <para>The POINT structure pointer that was received in the IDropTarget::DragEnter method's pt parameter.</para>
			/// </param>
			/// <param name="dwEffect">
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The value pointed to by the IDropTarget::DragEnter method's pdwEffect parameter.</para>
			/// </param>
			/// <remarks>
			/// This method is called by a drop target when its IDropTarget::DragEnter method is called. It notifies the drag-image manager
			/// that the drop target has been entered, and provides it with the information needed to display the drag image.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-idroptargethelper-dragenter HRESULT
			// DragEnter( HWND hwndTarget, IDataObject *pDataObject, POINT *ppt, DWORD dwEffect );
			void DragEnter([In] HWND hwndTarget, [In] IDataObject pDataObject, in Point ppt, [In] Ole32.DROPEFFECT dwEffect);

			/// <summary>Notifies the drag-image manager that the drop target's IDropTarget::DragLeave method has been called.</summary>
			/// <remarks>
			/// This method is called by a drop target when its IDropTarget::DragLeave method is called. It notifies the drag-image manager
			/// that the cursor has left the drop target.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-idroptargethelper-dragleave HRESULT DragLeave();
			void DragLeave();

			/// <summary>Notifies the drag-image manager that the drop target's IDropTarget::DragOver method has been called.</summary>
			/// <param name="ppt">
			/// <para>Type: <c>POINT*</c></para>
			/// <para>The POINT structure pointer that was received in the IDropTarget::DragOver method's pt parameter.</para>
			/// </param>
			/// <param name="dwEffect">
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The value pointed to by the IDropTarget::DragOver method's pdwEffect parameter.</para>
			/// </param>
			/// <remarks>
			/// This method is called by a drop target when its IDropTarget::DragOver method is called. It notifies the drag-image manager
			/// that the cursor position has changed and provides it with the information needed to display the drag image.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-idroptargethelper-dragover HRESULT
			// DragOver( POINT *ppt, DWORD dwEffect );
			void DragOver(in Point ppt, [In] Ole32.DROPEFFECT dwEffect);

			/// <summary>Notifies the drag-image manager that the drop target's IDropTarget::Drop method has been called.</summary>
			/// <param name="pDataObject">
			/// <para>Type: <c>IDataObject*</c></para>
			/// <para>A pointer to the data object's IDataObject interface.</para>
			/// </param>
			/// <param name="ppt">
			/// <para>Type: <c>POINT*</c></para>
			/// <para>A POINT structure pointer that was received in the IDropTarget::Drop method's pt parameter.</para>
			/// </param>
			/// <param name="dwEffect">
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The value pointed to by the IDropTarget::Drop method's pdwEffect parameter.</para>
			/// </param>
			/// <remarks>
			/// This method is called by a drop target when its IDropTarget::Drop method is called. It notifies the drag-image manager that
			/// the object has been dropped, and provides it with the information needed to display the drag image.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-idroptargethelper-drop HRESULT Drop(
			// IDataObject *pDataObject, POINT *ppt, DWORD dwEffect );
			void Drop([In] IDataObject pDataObject, in Point ppt, Ole32.DROPEFFECT dwEffect);

			/// <summary>Notifies the drag-image manager to show or hide the drag image.</summary>
			/// <param name="fShow">
			/// <para>Type: <c>BOOL</c></para>
			/// <para>A boolean value that is set to <c>TRUE</c> to show the drag image, and <c>FALSE</c> to hide it.</para>
			/// </param>
			/// <remarks>
			/// This method is used when dragging over a target window in a low color-depth video mode. It allows the target to notify the
			/// drag-image manager to hide the drag image while it is painting the window. While you are painting a window that is currently
			/// being dragged over, hide the drag image by calling <c>Show</c> with fShow set to <c>FALSE</c>. Once the window has been
			/// painted, display the drag image again by calling <c>Show</c> with fShow set to <c>TRUE</c>.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-idroptargethelper-show HRESULT Show( BOOL
			// fShow );
			void Show([MarshalAs(UnmanagedType.Bool)] bool fShow);
		}
	}
}