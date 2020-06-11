using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Vanara.PInvoke
{
	public static partial class Shell32
	{
		/// <summary>Specifies the information that is being returned by <see cref="IShellIconOverlayIdentifier.GetOverlayInfo"/>.</summary>
		[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.IShellIconOverlayIdentifier")]
		[Flags]
		public enum ISIOI
		{
			/// <summary>The path of the icon file is returned through pwszIconFile.</summary>
			ISIOI_ICONFILE = 0x00000001,

			/// <summary>There is more than one icon in pwszIconFile. The icon's index is returned through pIndex.</summary>
			ISIOI_ICONINDEX = 0x00000002
		}

		/// <summary>Exposes methods that handle all communication between icon overlay handlers and the Shell.</summary>
		/// <remarks>
		/// <para>
		/// Icon overlays are small images placed at the lower-left corner of the icon that represents a Shell object in Windows Explorer or
		/// on the desktop. They are used to add some extra information to the object's normal icon. A commonly used icon overlay is the
		/// small arrow that indicates that a file or folder is actually a link. You can specify custom icon overlays for Shell objects by
		/// implementing and registering an icon overlay handler.
		/// </para>
		/// <para>
		/// Icon overlay handlers are Component Object Model (COM) objects that are associated with a particular icon overlay. For a general
		/// discussion of icon overlay handlers, see How to Implement Icon Overlay Handlers.
		/// </para>
		/// <para>This interface must be implemented by all icon overlay handlers.</para>
		/// <para>This interface is not typically called by applications.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-ishelliconoverlayidentifier
		[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.IShellIconOverlayIdentifier")]
		[ComImport, Guid("0c6c4200-c589-11d0-999a-00c04fd655e1"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		public interface IShellIconOverlayIdentifier
		{
			/// <summary>Specifies whether an icon overlay should be added to a Shell object's icon.</summary>
			/// <param name="pwszPath">
			/// <para>Type: <c>PCWSTR</c></para>
			/// <para>A Unicode string that contains the fully qualified path of the Shell object.</para>
			/// </param>
			/// <param name="dwAttrib">
			/// <para>Type: <c>DWORD</c></para>
			/// <para>The object's attributes. For a complete list of file attributes and their associated flags, see <see cref="IShellFolder.GetAttributesOf"/>.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>This method returns one of the following:</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Return code</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>S_OK</term>
			/// <term>The icon overlay should be displayed.</term>
			/// </item>
			/// <item>
			/// <term>S_FALSE</term>
			/// <term>The icon overlay should not be displayed.</term>
			/// </item>
			/// <item>
			/// <term>E_FAIL</term>
			/// <term>The operation failed.</term>
			/// </item>
			/// </list>
			/// </returns>
			/// <remarks>
			/// The Shell calls this method to determine whether it should display a handler's icon overlay for a particular object. Icon
			/// overlay handlers are usually intended to work with a particular group of files. A typical example is a file type, identified
			/// by a specific file name extension. An icon overlay handler might request an icon overlay for all members of the file type.
			/// Some handlers request an icon overlay only if a member of the file type is in a particular state. However, icon overlay
			/// handlers are free to request their icon overlay for any object that they want.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishelliconoverlayidentifier-ismemberof
			// HRESULT IsMemberOf( LPCWSTR pwszPath, DWORD dwAttrib );
			[PreserveSig]
			HRESULT IsMemberOf([MarshalAs(UnmanagedType.LPWStr)] string pwszPath, SFGAO dwAttrib);

			/// <summary>Provides the location of the icon overlay's bitmap.</summary>
			/// <param name="pwszIconFile">
			/// <para>Type: <c>PWSTR</c></para>
			/// <para>
			/// A null-terminated Unicode string that contains the fully qualified path of the file containing the icon. The .dll, .exe, and
			/// .ico file types are all acceptable. You must set the <c>ISIOI_ICONFILE</c> flag in pdwFlags if you return a file name.
			/// </para>
			/// </param>
			/// <param name="cchMax">
			/// <para>Type: <c>int</c></para>
			/// <para>The size of the pwszIconFile buffer, in Unicode characters.</para>
			/// </param>
			/// <param name="pIndex">
			/// <para>Type: <c>int*</c></para>
			/// <para>
			/// Pointer to an index value used to identify the icon in a file that contains multiple icons. You must set the
			/// <c>ISIOI_ICONINDEX</c> flag in pdwFlags if you return an index.
			/// </para>
			/// </param>
			/// <param name="pdwFlags">
			/// <para>Type: <c>DWORD*</c></para>
			/// <para>
			/// Pointer to a bitmap that specifies the information that is being returned by the method. This parameter can be one or both
			/// of the following values.
			/// </para>
			/// <para>ISIOI_ICONFILE (0x00000001)</para>
			/// <para>The path of the icon file is returned through pwszIconFile.</para>
			/// <para>ISIOI_ICONINDEX (0x00000002)</para>
			/// <para>There is more than one icon in pwszIconFile. The icon's index is returned through pIndex.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// This method is called by the Shell at startup so that the handler's icon overlay can be added to the system image list.
			/// After initialization is complete, the Shell calls <c>GetOverlayInfo</c> when it needs to display the handler's icon overlay.
			/// </para>
			/// <para>
			/// <c>Note</c> Once the image has been loaded into the system image list during initialization, it cannot be changed. After
			/// initialization, the file name and index are used only to identify the icon overlay. The system will not load a new icon
			/// overlay. When <c>GetOverlayInfo</c> is called, your handler must return the same file name and index that were specified
			/// when the function was first called.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishelliconoverlayidentifier-getoverlayinfo
			// HRESULT GetOverlayInfo( LPWSTR pwszIconFile, int cchMax, int *pIndex, DWORD *pdwFlags );
			[PreserveSig]
			HRESULT GetOverlayInfo([MarshalAs(UnmanagedType.LPWStr)] StringBuilder pwszIconFile, int cchMax, out int pIndex, out ISIOI pdwFlags);

			/// <summary>Specifies the priority of an icon overlay.</summary>
			/// <param name="pPriority">
			/// <para>Type: <c>int*</c></para>
			/// <para>
			/// The address of a value that indicates the priority of the overlay identifier. Possible values range from zero to 100, with
			/// zero the highest priority.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>Returns S_OK if successful, or a COM error code otherwise.</para>
			/// </returns>
			/// <remarks>
			/// If more than one icon overlay is available for an object, the one with highest priority is chosen. The Shell has a set of
			/// internal rules that determine priority for many cases. The value returned by <c>GetPriority</c> is used for those cases in
			/// which the Shell's internal rules do not apply. Typically, you should set the value to zero. However, the priority value is
			/// useful when you have implemented two or more icon overlay handlers that can request icon overlay icons for the same object.
			/// By setting the priority values appropriately, you can specify which of the requested icon overlays will be displayed.
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishelliconoverlayidentifier-getpriority
			// HRESULT GetPriority( int *pPriority );
			[PreserveSig]
			HRESULT GetPriority(out int pPriority);
		}
	}
}