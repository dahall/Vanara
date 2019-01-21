using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class Shell32
	{
		/// <summary>Flags that control the walk operation.</summary>
		[PInvokeData("shobjidl_core.h", MSDNShortId = "164732ae-1c72-465c-a16b-a8eeaa9cc185")]
		[Flags]
		public enum NAMESPACEWALKFLAG
		{
			/// <summary>Use this value when you do not want to set any of the other flags.</summary>
			NSWF_DEFAULT = 0x00000000,

			/// <summary>
			/// Collect all of the items in the folder if both of these criteria are met:
			/// <list type="bullet">
			/// <item>
			/// <term>punkToWalk is a folder (IShellFolder or IShellView).</term>
			/// </item>
			/// <item>
			/// <term>None of the items in the folder are currently selected.</term>
			/// </item>
			/// </list>
			/// </summary>
			NSWF_NONE_IMPLIES_ALL = 0x00000001,

			/// <summary>
			/// Collect all of the items in the folder if both of these criteria are met:
			/// <list type="bullet">
			/// <item>
			/// <term>punkToWalk is a folder (IShellFolder or IShellView).</term>
			/// </item>
			/// <item>
			/// <term>One of the items in the folder is currently selected.</term>
			/// </item>
			/// </list>
			/// </summary>
			NSWF_ONE_IMPLIES_ALL = 0x00000002,

			/// <summary>Do not follow links (.lnk, .url, and folder shortcuts) in the recursion; instead, return them as regular items.</summary>
			NSWF_DONT_TRAVERSE_LINKS = 0x00000004,

			/// <summary>Do not collect the PIDLs of the nodes during the namespace walk.</summary>
			NSWF_DONT_ACCUMULATE_RESULT = 0x00000008,

			/// <summary>Include the contents of stream junction points in the walk. For instance, walk into the contents of a .cab file.</summary>
			NSWF_TRAVERSE_STREAM_JUNCTIONS = 0x00000010,

			/// <summary>Walk only file system nodes.</summary>
			NSWF_FILESYSTEM_ONLY = 0x00000020,

			/// <summary>Display a dialog box with a progress bar while walking the namespace.</summary>
			NSWF_SHOW_PROGRESS = 0x00000040,

			/// <summary>Return items in view order. This applies only when punkToWalk is an IShellView object.</summary>
			NSWF_FLAG_VIEWORDER = 0x00000080,

			/// <summary>Do not use the AutoPlay HIDA in the data object. This applies only when punkToWalk is an IDataObject object.</summary>
			NSWF_IGNORE_AUTOPLAY_HIDA = 0x00000100,

			/// <summary>Perform the walk asynchronously by running it on a background thread.</summary>
			NSWF_ASYNC = 0x00000200,

			/// <summary>
			/// Traverse links to return their targets (for .lnk, .url and folder shortcuts) but do not verify that those targets exist
			/// (Resolve). This is an optimization and does not affect the results except in the case where a missing or moved target could
			/// be found and returned.
			/// </summary>
			NSWF_DONT_RESOLVE_LINKS = 0x00000400,

			/// <summary>Undocumented.</summary>
			NSWF_ACCUMULATE_FOLDERS = 0x00000800,

			/// <summary>Do not maintain the sort order of the items being walked.</summary>
			NSWF_DONT_SORT = 0x00001000,

			/// <summary>Use SHCONTF_STORAGE in enumerations</summary>
			NSWF_USE_TRANSFER_MEDIUM = 0x00002000,

			/// <summary>
			/// For items with both SFGAO_FOLDER and SFGAO_STREAM passed to the walk (as opposed to those discovered by walking), for example
			/// .zip, .search-ms and .library-ms files do not traverse them, instead treat them as items. this will result in FoundItem()
			/// callbacks instead of EnterFolder()/LeaveFolder()
			/// </summary>
			NSWF_DONT_TRAVERSE_STREAM_JUNCTIONS = 0x00004000,

			/// <summary><c>Introduced in Windows 8</c>.</summary>
			NSWF_ANY_IMPLIES_ALL = 0x00008000,   // For selections > 0
		}

		/// <summary>
		/// Exposes methods that walk a namespace from a given root node. The depth of the walk is specified and an optional array is
		/// returned containing the IDs of all nodes walked.
		/// </summary>
		/// <remarks>
		/// <para>
		/// Use this interface to display or perform an operation on the contents of the namespace. <c>INamespaceWalk</c> allows retrieval of
		/// all reachable nodes of your namespace as pointers to item identifier lists (PIDLs), which can in turn be used to retrieve the
		/// IShellFolder object for each.
		/// </para>
		/// <para>
		/// The class identifier (CLSID) for the default implementation of <c>INamespaceWalk</c> is CLSID_NamespaceWalker. You can obtain an
		/// <c>INamespaceWalk</c> object by creating a single uninitialized object of the class associated with CLSID_NamespaceWalker using
		/// CoCreateInstance. This interface's IID is IID_INamespaceWalk.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nn-shobjidl_core-inamespacewalk
		[PInvokeData("shobjidl_core.h", MSDNShortId = "164732ae-1c72-465c-a16b-a8eeaa9cc185")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("57ced8a7-3f4a-432c-9350-30f24483f74f"), CoClass(typeof(NamespaceWalker))]
		public interface INamespaceWalk
		{
			/// <summary>Initiates a recursive walk of the namespace from the specified root to the given depth.</summary>
			/// <param name="punkToWalk">
			/// <para>Type: <c>IUnknown*</c></para>
			/// <para>The root node from which to begin the walk. This can be represented by one of the following objects.</para>
			/// <list type="bullet">
			/// <item>
			/// <term>IShellFolder</term>
			/// </item>
			/// <item>
			/// <term>IDataObject</term>
			/// </item>
			/// <item>
			/// <term>IParentAndItem</term>
			/// </item>
			/// <item>
			/// <term>IEnumFullIDList</term>
			/// </item>
			/// <item>
			/// <term>IShellItem</term>
			/// </item>
			/// <item>
			/// <term>IShellItemArray</term>
			/// </item>
			/// <item>
			/// <term>IShellView</term>
			/// </item>
			/// </list>
			/// <para>Specifying the desktop's</para>
			/// <para>IShellFolder</para>
			/// <para>as the root allows the possibility of walking the entire Windows namespace if</para>
			/// <para>cDepth</para>
			/// <para>is sufficiently large.</para>
			/// </param>
			/// <param name="dwFlags">
			/// <para>Type: <c>DWORD</c></para>
			/// <para>One or more of the following flags that control the walk operation.</para>
			/// <para>NSWF_DEFAULT (0x00000000)</para>
			/// <para>Use this value when you do not want to set any of the other flags.</para>
			/// <para>NSWF_NONE_IMPLIES_ALL (0x00000001)</para>
			/// <para>Collect all of the items in the folder if both of these criteria are met:</para>
			/// <list type="bullet">
			/// <item>
			/// <term>punkToWalk is a folder (IShellFolder or IShellView).</term>
			/// </item>
			/// <item>
			/// <term>None of the items in the folder are currently selected.</term>
			/// </item>
			/// </list>
			/// <para>NSWF_ONE_IMPLIES_ALL (0x00000002)</para>
			/// <para>Collect all of the items in the folder if both of these criteria are met:</para>
			/// <list type="bullet">
			/// <item>
			/// <term>punkToWalk is a folder (IShellFolder or IShellView).</term>
			/// </item>
			/// <item>
			/// <term>One of the items in the folder is currently selected.</term>
			/// </item>
			/// </list>
			/// <para>NSWF_DONT_TRAVERSE_LINKS (0x00000004)</para>
			/// <para>Do not follow links (.lnk, .url, and folder shortcuts) in the recursion; instead, return them as regular items.</para>
			/// <para>NSWF_DONT_ACCUMULATE_RESULT (0x00000008)</para>
			/// <para>Do not collect the PIDLs of the nodes during the namespace walk.</para>
			/// <para>NSWF_TRAVERSE_STREAM_JUNCTIONS (0x00000010)</para>
			/// <para>Include the contents of stream junction points in the walk. For instance, walk into the contents of a .cab file.</para>
			/// <para>NSWF_FILESYSTEM_ONLY (0x00000020)</para>
			/// <para>Walk only file system nodes.</para>
			/// <para>NSWF_SHOW_PROGRESS (0x00000040)</para>
			/// <para>Display a dialog box with a progress bar while walking the namespace.</para>
			/// <para>NSWF_FLAG_VIEWORDER (0x00000080)</para>
			/// <para>Return items in view order. This applies only when punkToWalk is an IShellView object.</para>
			/// <para>NSWF_IGNORE_AUTOPLAY_HIDA (0x00000100)</para>
			/// <para>Do not use the AutoPlay HIDA in the data object. This applies only when punkToWalk is an IDataObject object.</para>
			/// <para>NSWF_ASYNC (0x00000200)</para>
			/// <para>Perform the walk asynchronously by running it on a background thread.</para>
			/// <para>NSWF_DONT_RESOLVE_LINKS (0x00000400)</para>
			/// <para>
			/// Traverse links to return their targets (for .lnk, .url and folder shortcuts) but do not verify that those targets exist
			/// (Resolve). This is an optimization and does not affect the results except in the case where a missing or moved target could
			/// be found and returned.
			/// </para>
			/// <para>NSWF_ACCUMULATE_FOLDERS (0x00000800)</para>
			/// <para>NSWF_DONT_SORT (0x00001000)</para>
			/// <para>Do not maintain the sort order of the items being walked.</para>
			/// <para>NSWF_USE_TRANSFER_MEDIUM (0x00002000)</para>
			/// <para>NSWF_DONT_TRAVERSE_STREAM_JUNCTIONS (0x00004000)</para>
			/// <para>NSWF_ANY_IMPLIES_ALL (0x00008000)</para>
			/// <para><c>Introduced in Windows 8</c>.</para>
			/// </param>
			/// <param name="cDepth">
			/// <para>Type: <c>int</c></para>
			/// <para>
			/// The maximum depth to descend through the namespace hierarchy. This depth is zero-based. Set to 0 to walk only the folder
			/// identified by punkToWalk but none of its subfolders.
			/// </para>
			/// </param>
			/// <param name="pnswcb">
			/// <para>Type: <c>INamespaceWalkCB*</c></para>
			/// <para>INamespaceWalkCB callback function used by INamespaceWalk. This parameter can be <c>NULL</c>.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-inamespacewalk-walk HRESULT Walk( IUnknown
			// *punkToWalk, DWORD dwFlags, int cDepth, INamespaceWalkCB *pnswcb );
			[PreserveSig]
			HRESULT Walk([In, MarshalAs(UnmanagedType.IUnknown)] object punkToWalk, NAMESPACEWALKFLAG dwFlags, int cDepth, [In] INamespaceWalkCB pnswcb);

			/// <summary>Gets a list of objects found during a namespace walk initiated by INamespaceWalk::Walk.</summary>
			/// <param name="pcItems">
			/// <para>Type: <c>UINT*</c></para>
			/// <para>The number of items stored in pppidl</para>
			/// </param>
			/// <param name="prgpidl">
			/// <para>Type: <c>LPITEMIDLIST**</c></para>
			/// <para>The address of a pointer to an array of PIDLs representing the items found during the namespace walk.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			/// <remarks>
			/// <para>
			/// To use <c>INamespaceWalk::GetIDArrayResult</c>, <c>NSWF_DONT_ACCUMULATE_RESULT</c> cannot be specified in the call to INamespaceWalk::Walk.
			/// </para>
			/// <para>
			/// It is the responsibility of the calling application to free this array. Call CoTaskMemFree for each PIDL as well as once for
			/// the array itself.
			/// </para>
			/// <para>Examples</para>
			/// <para>
			/// The following example creates the INamespaceWalk instance, begins the walk at the desktop, walks only the desktop folder and
			/// its immediate children, retrieves the PIDLs retrived in the walk, and frees their array.
			/// </para>
			/// </remarks>
			// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-inamespacewalk-getidarrayresult HRESULT
			// GetIDArrayResult( UINT *pcItems, PIDLIST_ABSOLUTE **prgpidl );
			[PreserveSig]
			HRESULT GetIDArrayResult(out uint pcItems, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeConst = 0)] IntPtr[] prgpidl);
		}

		/// <summary>
		/// A callback interface exposing methods used with INamespaceWalk. After performing a walk with <c>INamespaceWalk</c>, an
		/// IShellFolder object representing the walked nodes is passed to the <c>INamespaceWalkCB</c> methods. What those methods do with
		/// the information depends on the object that is implementing them.
		/// </summary>
		/// <remarks>The IID for this interface is IID_INamespaceWalkCB.</remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nn-shobjidl_core-inamespacewalkcb
		[PInvokeData("shobjidl_core.h", MSDNShortId = "15244d6e-6cd7-4dee-8e4e-2533d5a60ae7")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("d92995f8-cf5e-4a76-bf59-ead39ea2b97e")]
		public interface INamespaceWalkCB
		{
			/// <summary>
			/// Called when an object is found in the namespace during a namespace walk. Use this method as the main action function for the
			/// class implementing it. Perform your actions as needed inside this method.
			/// </summary>
			/// <param name="psf">
			/// <para>Type: <c>IShellFolder*</c></para>
			/// <para>A pointer to an IShellFolder object representing the folder containing the item.</para>
			/// </param>
			/// <param name="pidl">
			/// <para>Type: <c>PCUITEMID_CHILD</c></para>
			/// <para>The item's PIDL, relative to psf.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-inamespacewalkcb-founditem HRESULT
			// FoundItem( IShellFolder *psf, PCUITEMID_CHILD pidl );
			[PreserveSig]
			HRESULT FoundItem([In] IShellFolder psf, [In] IntPtr pidl);

			/// <summary>
			/// Called when a folder is about to be entered during a namespace walk. Use this method for any initialization of the retrieved item.
			/// </summary>
			/// <param name="psf">
			/// <para>Type: <c>IShellFolder*</c></para>
			/// <para>A pointer to an IShellFolder object representing the parent of the folder designated by pidl.</para>
			/// </param>
			/// <param name="pidl">
			/// <para>Type: <c>PCUITEMID_CHILD</c></para>
			/// <para>The PIDL, relative to psf, of the folder being entered.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-inamespacewalkcb-enterfolder HRESULT
			// EnterFolder( IShellFolder *psf, PCUITEMID_CHILD pidl );
			[PreserveSig]
			HRESULT EnterFolder([In] IShellFolder psf, [In] IntPtr pidl);

			/// <summary>
			/// Called after a namespace walk through a folder. Use this method to perform any necessary cleanup following the actions
			/// performed by INamespaceWalkCB::EnterFolder or INamespaceWalkCB::FoundItem.
			/// </summary>
			/// <param name="psf">
			/// <para>Type: <c>IShellFolder*</c></para>
			/// <para>A pointer to an IShellFolder object representing the parent of the folder designated by pidl.</para>
			/// </param>
			/// <param name="pidl">
			/// <para>Type: <c>PCUITEMID_CHILD</c></para>
			/// <para>A PIDL, relative to psf, of the folder being exited.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-inamespacewalkcb-leavefolder HRESULT
			// LeaveFolder( IShellFolder *psf, PCUITEMID_CHILD pidl );
			[PreserveSig]
			HRESULT LeaveFolder([In] IShellFolder psf, [In] IntPtr pidl);

			/// <summary>
			/// Initializes the window title and cancel button text of the progress dialog box displayed during the namespace walk.
			/// </summary>
			/// <param name="ppszTitle">
			/// <para>Type: <c>LPWSTR*</c></para>
			/// <para>
			/// When this method returns, contains a pointer to a null-terminated string that contains the title to be used for the dialog box.
			/// </para>
			/// </param>
			/// <param name="ppszCancel">
			/// <para>Type: <c>LPWSTR*</c></para>
			/// <para>
			/// When this method returns, contains a pointer to a null-terminated string that contains the text displayed on the button that
			/// cancels the namespace walk.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-inamespacewalkcb-initializeprogressdialog
			// HRESULT InitializeProgressDialog( LPWSTR *ppszTitle, LPWSTR *ppszCancel );
			[PreserveSig]
			HRESULT InitializeProgressDialog([Out, MarshalAs(UnmanagedType.LPWStr)] out string ppszTitle, [Out, MarshalAs(UnmanagedType.LPWStr)] out string ppszCancel);
		}

		/// <summary>
		/// Extends INamespaceWalkCB with a method that is required in order to complete a namespace walk. This method removes data collected
		/// during the walk.
		/// </summary>
		/// <seealso cref="Vanara.PInvoke.Shell32.INamespaceWalkCB"/>
		/// <remarks>This interface also provides the methods of the INamespaceWalkCB interface, from which it inherits.</remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nn-shobjidl_core-inamespacewalkcb2
		[PInvokeData("shobjidl_core.h", MSDNShortId = "a748083b-a99e-4015-93da-112d2950f623")]
		[ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("7ac7492b-c38e-438a-87db-68737844ff70")]
		public interface INamespaceWalkCB2 : INamespaceWalkCB
		{
			/// <summary>
			/// Called when an object is found in the namespace during a namespace walk. Use this method as the main action function for the
			/// class implementing it. Perform your actions as needed inside this method.
			/// </summary>
			/// <param name="psf">
			/// <para>Type: <c>IShellFolder*</c></para>
			/// <para>A pointer to an IShellFolder object representing the folder containing the item.</para>
			/// </param>
			/// <param name="pidl">
			/// <para>Type: <c>PCUITEMID_CHILD</c></para>
			/// <para>The item's PIDL, relative to psf.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-inamespacewalkcb-founditem HRESULT
			// FoundItem( IShellFolder *psf, PCUITEMID_CHILD pidl );
			[PreserveSig]
			new HRESULT FoundItem([In] IShellFolder psf, [In] IntPtr pidl);

			/// <summary>
			/// Called when a folder is about to be entered during a namespace walk. Use this method for any initialization of the retrieved item.
			/// </summary>
			/// <param name="psf">
			/// <para>Type: <c>IShellFolder*</c></para>
			/// <para>A pointer to an IShellFolder object representing the parent of the folder designated by pidl.</para>
			/// </param>
			/// <param name="pidl">
			/// <para>Type: <c>PCUITEMID_CHILD</c></para>
			/// <para>The PIDL, relative to psf, of the folder being entered.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-inamespacewalkcb-enterfolder HRESULT
			// EnterFolder( IShellFolder *psf, PCUITEMID_CHILD pidl );
			[PreserveSig]
			new HRESULT EnterFolder([In] IShellFolder psf, [In] IntPtr pidl);

			/// <summary>
			/// Called after a namespace walk through a folder. Use this method to perform any necessary cleanup following the actions
			/// performed by INamespaceWalkCB::EnterFolder or INamespaceWalkCB::FoundItem.
			/// </summary>
			/// <param name="psf">
			/// <para>Type: <c>IShellFolder*</c></para>
			/// <para>A pointer to an IShellFolder object representing the parent of the folder designated by pidl.</para>
			/// </param>
			/// <param name="pidl">
			/// <para>Type: <c>PCUITEMID_CHILD</c></para>
			/// <para>A PIDL, relative to psf, of the folder being exited.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-inamespacewalkcb-leavefolder HRESULT
			// LeaveFolder( IShellFolder *psf, PCUITEMID_CHILD pidl );
			[PreserveSig]
			new HRESULT LeaveFolder([In] IShellFolder psf, [In] IntPtr pidl);

			/// <summary>
			/// Initializes the window title and cancel button text of the progress dialog box displayed during the namespace walk.
			/// </summary>
			/// <param name="ppszTitle">
			/// <para>Type: <c>LPWSTR*</c></para>
			/// <para>
			/// When this method returns, contains a pointer to a null-terminated string that contains the title to be used for the dialog box.
			/// </para>
			/// </param>
			/// <param name="ppszCancel">
			/// <para>Type: <c>LPWSTR*</c></para>
			/// <para>
			/// When this method returns, contains a pointer to a null-terminated string that contains the text displayed on the button that
			/// cancels the namespace walk.
			/// </para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>If this method succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-inamespacewalkcb-initializeprogressdialog
			// HRESULT InitializeProgressDialog( LPWSTR *ppszTitle, LPWSTR *ppszCancel );
			[PreserveSig]
			new HRESULT InitializeProgressDialog([Out, MarshalAs(UnmanagedType.LPWStr)] out string ppszTitle, [Out, MarshalAs(UnmanagedType.LPWStr)] out string ppszCancel);

			/// <summary>Removes data collected during a namespace walk.</summary>
			/// <param name="hr">
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>The results of Walk.</para>
			/// </param>
			/// <returns>
			/// <para>Type: <c>HRESULT</c></para>
			/// <para>Always returns S_OK.</para>
			/// </returns>
			// https://docs.microsoft.com/en-us/windows/desktop/api/shobjidl_core/nf-shobjidl_core-inamespacewalkcb2-walkcomplete HRESULT
			// WalkComplete( HRESULT hr );
			[PreserveSig]
			HRESULT WalkComplete(HRESULT hr);
		}

		/// <summary>CLSID_NamespaceWalker</summary>
		[ComImport, Guid("72eb61e0-8672-4303-9175-f2e4c68b2e7c"), ClassInterface(ClassInterfaceType.None)]
		public class NamespaceWalker { }
	}
}