namespace Vanara.PInvoke;

public static partial class Kernel32
{
	private const string Lib_bindlink = "bindlink.dll";

	/// <summary>
	/// These flags can be passed in to <c>CreateBindLink</c> to change the default bind link behavior to suit the needs of the user.
	/// </summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/bindlink/ne-bindlink-create_bind_link_flags typedef enum CREATE_BIND_LINK_FLAGS {
	// CREATE_BIND_LINK_FLAG_NONE, CREATE_BIND_LINK_FLAG_READ_ONLY, CREATE_BIND_LINK_FLAG_MERGED } ;
	[PInvokeData("bindlink.h", MSDNShortId = "NE:bindlink.CREATE_BIND_LINK_FLAGS")]
	[Flags]
	public enum CREATE_BIND_LINK_FLAGS : uint
	{
		/// <summary>
		/// <para>0x00000000</para>
		/// <para>No bind link flags are specified.</para>
		/// </summary>
		CREATE_BIND_LINK_FLAG_NONE = 0x0,

		/// <summary>
		/// <para>0x00000001</para>
		/// <para>
		/// Read Only links are bind links where the users on the system are prevented from making changes to files that reside in the
		/// backing path if they are accessed through the virtual path. This means that a user with permission to modify a file on the
		/// backing path can still modify that file if they access it through the backing path, but not if they access it through the virtual
		/// path. Normally, the permissions of the backing path apply as such when the corresponding virtual path is accessed, however when
		/// </para>
		/// <para>READ_ONLY</para>
		/// <para>flag is used the "write" permissions are masked off. This ensures that applications see that the file is</para>
		/// <para>READ_ONLY</para>
		/// <para>.</para>
		/// <para>
		/// Note that the read only restriction only applies to files that reside at the backing path on disk. If the link is merged and
		/// files that are originally from the virtual directory path are visible, they will remain modifiable. For example:
		/// </para>
		/// <para>C:\Foo exists on disk with a file Cat.txt</para>
		/// <para>C:\Bar exists on disk with a file Cow.txt</para>
		/// <para>
		/// When a link is created with C:\Foo as the virtual path and C:\Bar as the backing path and the link is marked read-only and
		/// merged, both Cat.txt and Cow.txt will be visible at C:\Foo, however, Cat.txt will be modifiable while Cow.txt will not be modifiable.
		/// </para>
		/// </summary>
		CREATE_BIND_LINK_FLAG_READ_ONLY = 0x1,

		/// <summary>
		/// <para>0x00000002</para>
		/// <para>A merged link is like a shadow link, except the existing content in the virtual path is merged with backing path.</para>
		/// <para>Let’s consider the prior example for shadow link once again, with the addition of this flag. For example:</para>
		/// <para>- C:\Foo exists on disk with two files Cat.txt and Dog.txt</para>
		/// <para>- C:\Bar exists on disk with two files Cow.txt and Mouse.txt</para>
		/// <para>When a link is created with C:\Foo as the virtual path and C:\Bar as the backing path with the flag</para>
		/// <para>CREATE_BIND_LINK_FLAG_MERGED</para>
		/// <para>, C:\Foo path will show Cat.txt, Dog.txt, Cow.txt and Mouse.txt.</para>
		/// <para>
		/// Note that merged links only apply when the virtual path is a directory. In the case where a file appears in both the backing path
		/// and the virtual path, the file in the backing path takes precedence (i.e., the file in the virtual path is masked). This applies
		/// recursively for all directories within the virtual path. Since the merge applies to directories, if the
		/// </para>
		/// <para>virtualPath</para>
		/// <para>and the</para>
		/// <para>backingPath</para>
		/// <para>
		/// both have a directory with the same name at the same level, the directory will be merged as an outcome of the link. If the link
		/// wasn’t a merged link the directory in the backing path will take precedence and override the directory in the
		/// </para>
		/// <para>virtualPath</para>
		/// <para>
		/// . If a file were created at the merged path when the merged link exists, it will be physically created at the backing path (as is
		/// the case with any bind link) and will override a file with the same name at the
		/// </para>
		/// <para>virtualPath</para>
		/// <para>.</para>
		/// <para>Let’s consider the following directory structures:</para>
		/// <para>- c:\Foo\Sub\Foo_sub.txt</para>
		/// <para>- c:\Bar\Sub\Bar_sub.txt</para>
		/// <para>And two different links:</para>
		/// <para>- {c:\Foo is linked to c:\Bar WITHOUT merge}. In this case c:\Foo\Sub will only show Bar_sub.txt.</para>
		/// <para>- {c:\Foo is linked to c:\Bar WITH merge}. In this case c:\Foo\Sub will show both Foo_sub.txt and Bar_sub.txt.</para>
		/// <para>
		/// Since bind links are path-based links, if a file is replaced, modified, or deleted/recreated in the backing path after the link
		/// is created, the virtual path will point to the file that exists at the time the link is being followed. It happens because the
		/// link is resolved at the time a file is opened. Accordingly, if a file from the backing path was masking a file in the virtual
		/// path due to the link and if the file in the backing path was deleted, a subsequent open will open the file in the virtual path.
		/// </para>
		/// </summary>
		CREATE_BIND_LINK_FLAG_MERGED = 0x2,
	}

	/// <summary>
	/// This API allows admins to create a bind link between a virtual path and a backing path. The virtual path is always local while the
	/// backing path could be local or remote (a network share, for example). The parent of the virtualPath should be visible for the link
	/// creation to succeed. Both the virtual path and the backing path can represent files or directories. The backingPath for a prior link
	/// can be a virtualPath for a subsequent link as well. <b>CreateBindLink</b> can only be called by a user with Administrator privileges.
	/// Once created, a bind link exists system-wide, and it lasts until it is deleted by calling <c>RemoveBindLink</c>, or until the system
	/// is shut down.
	/// </summary>
	/// <param name="virtualPath">The virtual path to be used to create the bind link.</param>
	/// <param name="backingPath">The backing path to be used to create the bind link.</param>
	/// <param name="createBindLinkFlags">
	/// These flags can change the default bind link behavior to suit the needs of the user. See <c>CREATE_BIND_LINK_FLAGS</c> for more details.
	/// </param>
	/// <param name="exceptionCount">The number of exceptions provided in the exceptionPaths parameter.</param>
	/// <param name="exceptionPaths">
	/// The exception paths to be excluded from the bind link. Note that exceptions do not apply to anchorless links since anchorless virtual
	/// paths have no descendants by definition and, therefore, have no paths that qualify. The API will return an error if there is an
	/// attempt to pass exceptions to anchorless link.
	/// </param>
	/// <remarks>
	/// <para>For more information about creating bind links, see <c>Bindlink Overview - Creating bind links</c>.</para>
	/// <para>Examples</para>
	/// <para>
	/// For a full example of how to use the <b>CreateBindLink</b> and <b>RemoveBindLink</b> APIs, see the <c>bind link example</c> page.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/bindlink/nf-bindlink-createbindlink HRESULT CreateBindLink( PCWSTR virtualPath,
	// PCWSTR backingPath, CREATE_BIND_LINK_FLAGS createBindLinkFlags, UINT32 exceptionCount, PCWSTR * const exceptionPaths );
	[PInvokeData("bindlink.h", MSDNShortId = "NF:bindlink.CreateBindLink")]
	[DllImport(Lib_bindlink, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	public static extern HRESULT CreateBindLink(string virtualPath, string backingPath,
		[Optional] CREATE_BIND_LINK_FLAGS createBindLinkFlags, [Optional] uint exceptionCount,
		[In, Optional, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr, SizeParamIndex = 3)] string[]? exceptionPaths);

	/// <summary>This API allows a user to remove a link that was previously created by calling <c>CreateBindLink</c>.</summary>
	/// <param name="virtualPath">The virtual path for which the bind link is to be removed.</param>
	/// <remarks>
	/// <para>
	/// This API will fail if the user does not have Administrator privileges, or if the user does not have permission to access the virtual
	/// path, or if the link being deleted is the ancestor of an existing link. The API will also fail if the link doesn’t exist or due to
	/// another internal error. If an app is in the middle of traversing the virtual path while <b>RemoveBindLink</b> is called, the
	/// resulting behavior will depend on where each of the threads are in the process (i.e., this is a race between the link being deleted
	/// and the file/directory being accessed).
	/// </para>
	/// <para>
	/// Note that nested links must be removed in deepest-first order. This means the deepest virtual path must be removed before ancestor
	/// virtual paths can be removed. Unrelated services that create the links and remove the links are expected to be respectful of each
	/// other's personal space and limit their mappings to paths under their control.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/bindlink/nf-bindlink-removebindlink HRESULT RemoveBindLink( PCWSTR virtualPath );
	[PInvokeData("bindlink.h", MSDNShortId = "NF:bindlink.RemoveBindLink")]
	[DllImport(Lib_bindlink, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT RemoveBindLink([MarshalAs(UnmanagedType.LPWStr)] string virtualPath);
}