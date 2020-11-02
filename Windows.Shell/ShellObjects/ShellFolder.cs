using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using Vanara.PInvoke;
using static Vanara.PInvoke.Shell32;

// ReSharper disable UnusedMember.Global
// ReSharper disable MemberCanBePrivate.Global

namespace Vanara.Windows.Shell
{
	/// <summary>A filter for the types of children to enumerate.</summary>
	[Flags]
	public enum FolderItemFilter
	{
		/// <summary>Include items that are folders in the enumeration.</summary>
		Folders = 0x00020,

		/// <summary>Include items that are not folders in the enumeration.</summary>
		NonFolders = 0x00040,

		/// <summary>Include hidden items in the enumeration. This does not include hidden system items. (To include hidden system items, use IncludeSuperHidden.)</summary>
		IncludeHidden = 0x00080,

		/// <summary>The calling application is looking for printer objects.</summary>
		Printers = 0x00200,

		/// <summary>The calling application is looking for resources that can be shared.</summary>
		Shareable = 0x00400,

		/// <summary>Include items with accessible storage and their ancestors, including hidden items.</summary>
		Storage = 0x00800,

		// /// <summary>Windows 7 and later. Child folders should provide a navigation enumeration.</summary>
		// NAVIGATION_ENUM = 0x01000,

		/// <summary>Windows Vista and later. The calling application is looking for resources that can be enumerated quickly.</summary>
		FastItems = 0x02000,

		/// <summary>Windows Vista and later. Enumerate items as a simple list even if the folder itself is not structured in that way.</summary>
		FlatList = 0x04000,

		/// <summary>
		/// Windows 7 and later. Include hidden system items in the enumeration. This value does not include hidden non-system items. (To include hidden
		/// non-system items, use IncludeHidden.)
		/// </summary>
		IncludeSuperHidden = 0x10000
	}

	/// <summary>A folder or container of <see cref="T:Vanara.Windows.Shell.ShellItem" /> instances.</summary>
	public class ShellFolder : ShellItem, IEnumerable<ShellItem>
	{
		internal IShellFolder iShellFolder;
		private static ShellFolder desktop;

		/// <summary>Initializes a new instance of the <see cref="ShellItem"/> class.</summary>
		/// <param name="path">The file system path of the item.</param>
		public ShellFolder(string path) : base(path) => iShellFolder = GetInstance();

		/// <summary>Initializes a new instance of the <see cref="ShellItem"/> class.</summary>
		/// <param name="knownFolder">A known folder value.</param>
		public ShellFolder(KNOWNFOLDERID knownFolder) : base(knownFolder) => iShellFolder = GetInstance();

		/// <summary>Initializes a new instance of the <see cref="ShellItem"/> class.</summary>
		/// <param name="idList">The ID list.</param>
		public ShellFolder(PIDL idList) : base(idList) => iShellFolder = GetInstance();

		/// <summary>Initializes a new instance of the <see cref="ShellFolder"/> class.</summary>
		/// <param name="shellItem">A ShellItem instance whose IsFolder property is <c>true</c>.</param>
		public ShellFolder(ShellItem shellItem) : this(shellItem.iShellItem)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="ShellFolder"/> class.</summary>
		internal ShellFolder(IShellItem iShellItem) : base(iShellItem) => iShellFolder = GetInstance();

		/// <summary>Initializes a new instance of the <see cref="ShellFolder"/> class.</summary>
		protected ShellFolder()
		{
		}

		/// <summary>Gets a reference to the primary Desktop.</summary>
		/// <value>The desktop instance.</value>
		public static ShellFolder Desktop => desktop ??= new ShellFolder(KNOWNFOLDERID.FOLDERID_Desktop);

		/// <summary>Gets the <see cref="ShellItem"/> with the specified child name.</summary>
		/// <value>The <see cref="ShellItem"/> instance matching <paramref name="childName"/>.</value>
		/// <param name="childName">Name of the child item.</param>
		/// <returns>The <see cref="ShellItem"/> instance matching <paramref name="childName"/>, if it exists.</returns>
		public ShellItem this[string childName]
		{
			get
			{
				if (string.IsNullOrEmpty(childName)) throw new ArgumentNullException(nameof(childName));

				object ppv;
				if (IsMinVista)
					SHCreateItemFromRelativeName(iShellItem, childName, BindContext, typeof(IShellItem).GUID, out ppv).ThrowIfFailed();
				else
				{
					SFGAO attr = 0;
					iShellFolder.ParseDisplayName(IntPtr.Zero, null, childName, out uint _, out var tempPidl, ref attr).ThrowIfFailed();
					ppv = new ShellItemImpl(PIDL.Combine(PIDL, tempPidl), false);
				}
				return Open((IShellItem)ppv);
			}
		}

		/// <summary>Gets a child <see cref="ShellItem"/> reference from a parent and child PIDL.</summary>
		/// <param name="relativePidl">A valid relative PIDL.</param>
		/// <returns>A child <see cref="ShellItem"/> reference.</returns>
		public ShellItem this[PIDL relativePidl]
		{
			get
			{
				if (relativePidl == null || relativePidl.IsInvalid) throw new ArgumentNullException(nameof(relativePidl));

				object ppv;
				if (IsMinVista)
					SHCreateItemWithParent(PIDL.Null, iShellFolder, relativePidl, typeof(IShellItem).GUID, out ppv);
				else
					ppv = new ShellItemImpl(PIDL.Combine(PIDL, relativePidl), false);
				return Open((IShellItem)ppv);
			}
		}

		/// <summary>Gets the underlying <see cref="IShellFolder"/> instance.</summary>
		/// <value>The underlying <see cref="IShellFolder"/> instance.</value>
		public IShellFolder IShellFolder => iShellFolder;

		/// <summary>
		/// Retrieves a handler, typically the Shell folder object that implements IShellFolder for a particular item. Optional parameters
		/// that control the construction of the handler are passed in the bind context.
		/// </summary>
		/// <typeparam name="T">Type of the interface to get, usually IShellFolder or IStream.</typeparam>
		/// <param name="relativePidl">
		/// A relative PIDL that identifies the subfolder. This value can refer to an item at any level below the parent folder in the
		/// namespace hierarchy.
		/// </param>
		/// <param name="bindCtx">
		/// A pointer to an IBindCtx interface on a bind context object that can be used to pass parameters to the construction of the
		/// handler. If this parameter is not used, set it to <see langword="null"/>. Because support for this parameter is optional for
		/// folder object implementations, some folders may not support the use of bind contexts.
		/// <para>
		/// Information that can be provided in the bind context includes a BIND_OPTS structure that includes a grfMode member that
		/// indicates the access mode when binding to a stream handler. Other parameters can be set and discovered using
		/// IBindCtx::RegisterObjectParam and IBindCtx::GetObjectParam.
		/// </para>
		/// </param>
		/// <returns>Receives the interface pointer requested in <typeparamref name="T"/>.</returns>
		public T BindToObject<T>(PIDL relativePidl, IBindCtx bindCtx = null) where T : class => iShellFolder.BindToObject<T>(relativePidl, bindCtx);

		/// <summary>Requests a pointer to an object's storage interface.</summary>
		/// <typeparam name="T">Type of the interface to get, usuall IStream, IStorage, or IPropertySetStorage.</typeparam>
		/// <param name="relativePidl">The PIDL that identifies the subfolder relative to its parent folder.</param>
		/// <param name="bindCtx">
		/// The optional address of an IBindCtx interface on a bind context object to be used during this operation. If this parameter is
		/// not used, set it to <see langword="null"/>. Because support for pbc is optional for folder object implementations, some folders
		/// may not support the use of bind contexts.
		/// </param>
		/// <returns>Receives the interface pointer requested in <typeparamref name="T"/>.</returns>
		public T BindToStorage<T>(PIDL relativePidl, IBindCtx bindCtx = null) where T : class => iShellFolder.BindToStorage<T>(relativePidl, bindCtx);

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public override void Dispose()
		{
			if (iShellFolder != null) { Marshal.ReleaseComObject(iShellFolder); iShellFolder = null; }
			base.Dispose();
		}

		/// <summary>
		/// Enumerates all children of this item. If this item is not a folder/container, this method will return an empty enumeration.
		/// </summary>
		/// <param name="filter">A filter for the types of children to enumerate.</param>
		/// <param name="parentWindow">The parent window.</param>
		/// <returns>An enumerated list of children matching the filter.</returns>
		public IEnumerable<ShellItem> EnumerateChildren(FolderItemFilter filter /*= FolderItemFilter.Folders | FolderItemFilter.IncludeHidden | FolderItemFilter.NonFolders | FolderItemFilter.IncludeSuperHidden */, System.Windows.Forms.IWin32Window parentWindow = null)
		{
			if (iShellFolder.EnumObjects(IWin2Ptr(parentWindow, false), (SHCONTF)filter, out var eo).Failed)
				Debug.WriteLine($"Unable to enum children in folder.");
			foreach (var p in eo.Enumerate(20))
			{
				ShellItem i = null;
				try { i = this[p]; } catch (Exception e) { Debug.WriteLine($"Unable to open folder child: {e.Message}"); }
				if (i != null) yield return i;
			}
			Marshal.ReleaseComObject(eo);
		}

		/// <summary>Gets an object that can be used to carry out actions on the specified file objects or folders.</summary>
		/// <typeparam name="TInterface">The interface to retrieve, typically IShellView.</typeparam>
		/// <param name="parentWindow">The owner window that the client should specify if it displays a dialog box or message box..</param>
		/// <param name="children">The file objects or subfolders relative to the parent folder for which to get the interface.</param>
		/// <returns>The interface pointer requested.</returns>
		public TInterface GetChildrenUIObjects<TInterface>(System.Windows.Forms.IWin32Window parentWindow, params ShellItem[] children) where TInterface : class
		{
			if (children is null || children.Length == 0 || children.Any(i => i is null || !IsChild(i))) throw new ArgumentException("At least one child ShellItem instances is null or is not a child of this folder.");
			return iShellFolder.GetUIObjectOf<TInterface>(IWin2Ptr(parentWindow), Array.ConvertAll(children, i => (IntPtr)i.PIDL.LastId));
		}

		/// <summary>Returns an enumerator that iterates through the collection.</summary>
		/// <returns>A <see cref="IEnumerator{ShellItem}"/> that can be used to iterate through the collection.</returns>
		public IEnumerator<ShellItem> GetEnumerator() => EnumerateChildren().GetEnumerator();

		/// <summary>Requests an object that can be used to obtain information from or interact with a folder object.</summary>
		/// <typeparam name="TInterface">The interface to retrieve, typically IShellView.</typeparam>
		/// <param name="parentWindow">The owner window.</param>
		/// <returns>The interface pointer requested.</returns>
		public TInterface GetViewObject<TInterface>(System.Windows.Forms.IWin32Window parentWindow) where TInterface : class =>
			iShellFolder.CreateViewObject<TInterface>(IWin2Ptr(parentWindow));

		/// <summary>Determines if the supplied <see cref="ShellItem"/> is an immediate descendant of this folder.</summary>
		/// <param name="item">The child item to test.</param>
		/// <returns><c>true</c> if <paramref name="item"/> is an immediate descendant of this folder.</returns>
		public bool IsChild(ShellItem item) => Equals(item.Parent);

		/// <summary>Renames a child of this folder.</summary>
		/// <param name="relativeChildPidl">The relative child IDL.</param>
		/// <param name="newName">The new name.</param>
		/// <param name="displayType">The display type.</param>
		/// <param name="parentWindow">The parent window to use if any messages need to be shown the user.</param>
		/// <returns>A reference to the newly named item.</returns>
		public ShellItem RenameChild(PIDL relativeChildPidl, string newName, ShellItemDisplayString displayType, System.Windows.Forms.IWin32Window parentWindow)
		{
			iShellFolder.SetNameOf(IWin2Ptr(parentWindow), relativeChildPidl, newName, (SHGDNF)displayType, out PIDL newPidl);
			return this[newPidl];
		}

		/// <summary>Returns an enumerator that iterates through a collection.</summary>
		/// <returns>An <see cref="System.Collections.IEnumerator"/> object that can be used to iterate through the collection.</returns>
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		internal static HWND IWin2Ptr(System.Windows.Forms.IWin32Window wnd, bool desktopIfNull = true) => wnd?.Handle ?? (desktopIfNull ? User32.FindWindow("Progman", null) : default);

		private IShellFolder GetInstance() => iShellItem.BindToHandler<IShellFolder>(null, BHID.BHID_SFObject.Guid());
	}
}