namespace Vanara.PInvoke;

public static partial class Shell32
{
	/// <summary>
	/// Obtained by calling IShellFolder::BindToObject for an item. If the item represents a snapshot of an item at a previous time,
	/// this interface will obtain the current version of the item.
	/// </summary>
	/// <remarks>This interface provides only the methods of the IRelatedItem interface, from which it inherits.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-icurrentitem
	[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.ICurrentItem")]
	[ComImport, Guid("240a7174-d653-4a1d-a6d3-d4943cfbfe3d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ICurrentItem : IRelatedItem
	{
		/// <summary>Gets the pointer to an item identifier list (PIDL) for the item that is related.</summary>
		/// <returns>
		/// <para>Type: <c>PIDLIST_ABSOLUTE*</c></para>
		/// <para>When this method returns, contains the PIDL.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-irelateditem-getitemidlist HRESULT
		// GetItemIDList( PIDLIST_ABSOLUTE *ppidl );
		new PIDL GetItemIDList();

		/// <summary>Gets the IShellItem that is related to this item.</summary>
		/// <returns>
		/// <para>Type: <c>IShellItem**</c></para>
		/// <para>
		/// When this method returns, contains the address of a pointer to the IShellItem interface for the item that is related to this item.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-irelateditem-getitem HRESULT GetItem(
		// IShellItem **ppsi );
		new IShellItem GetItem();
	}

	/// <summary>Used to obtain the immediately underlying representation of an item's path.</summary>
	/// <remarks>
	/// <para>This interface provides only the methods of the IRelatedItem interface, from which it inherits.</para>
	/// <para>When to Implement</para>
	/// <para>
	/// An implementation of this interface for system-provided data objects is provided with Windows. Custom data sources that want to
	/// expose this information must implement the interface as part of their data object.
	/// </para>
	/// <para>When to Use</para>
	/// <para>
	/// Use this interface to uncovers a single level of aliasing. For instance, if you have the path of an item in the Documents
	/// library, this interface reveals the path of the item in the location that was added to the library. Whether this is the file
	/// system path depends on the nature of that original location. For a full recursion to the source item, use IIdentityName.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-idelegateitem
	[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.IDelegateItem")]
	[ComImport, Guid("3c5a1c94-c951-4cb7-bb6d-3b93f30cce93"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDelegateItem : IRelatedItem
	{
		/// <summary>Gets the pointer to an item identifier list (PIDL) for the item that is related.</summary>
		/// <returns>
		/// <para>Type: <c>PIDLIST_ABSOLUTE*</c></para>
		/// <para>When this method returns, contains the PIDL.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-irelateditem-getitemidlist HRESULT
		// GetItemIDList( PIDLIST_ABSOLUTE *ppidl );
		new PIDL GetItemIDList();

		/// <summary>Gets the IShellItem that is related to this item.</summary>
		/// <returns>
		/// <para>Type: <c>IShellItem**</c></para>
		/// <para>
		/// When this method returns, contains the address of a pointer to the IShellItem interface for the item that is related to this item.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-irelateditem-getitem HRESULT GetItem(
		// IShellItem **ppsi );
		new IShellItem GetItem();
	}

	/// <summary>
	/// Exposes methods that find a version of the current item to be used to get display properties, such as the item name, that will
	/// be displayed in the UI. Used by the copy engine dialogs to provide the UI with an appropriate item to display. If no other
	/// version can be found, the current item is used.
	/// </summary>
	/// <remarks>This interface provides only the methods of the IRelatedItem interface, from which it inherits.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-idisplayitem
	[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.IDisplayItem")]
	[ComImport, Guid("c6fd5997-9f6b-4888-8703-94e80e8cde3f"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDisplayItem : IRelatedItem
	{
		/// <summary>Gets the pointer to an item identifier list (PIDL) for the item that is related.</summary>
		/// <returns>
		/// <para>Type: <c>PIDLIST_ABSOLUTE*</c></para>
		/// <para>When this method returns, contains the PIDL.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-irelateditem-getitemidlist HRESULT
		// GetItemIDList( PIDLIST_ABSOLUTE *ppidl );
		new PIDL GetItemIDList();

		/// <summary>Gets the IShellItem that is related to this item.</summary>
		/// <returns>
		/// <para>Type: <c>IShellItem**</c></para>
		/// <para>
		/// When this method returns, contains the address of a pointer to the IShellItem interface for the item that is related to this item.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-irelateditem-getitem HRESULT GetItem(
		// IShellItem **ppsi );
		new IShellItem GetItem();
	}

	/// <summary>Exposes methods to compare two items to see if they are the same.</summary>
	/// <remarks>
	/// <para>This interface provides only the methods of the IRelatedItem interface, from which it inherits.</para>
	/// <para>
	/// Shell data sources that present items in virtual locations, such as search results, typically implement this interface as a
	/// handler to discover the actual location of an item—to find a folder that contains a file. For example, this interface is used to
	/// implement the <c>Open File Location</c> command in Windows Explorer. When the user right-clicks on a file in a set of search
	/// results, for example, and then selects <c>Open File Location</c>, the command uses <c>IIdentityName</c> to get the true item and
	/// opens a browser on its parent (the file folder) instead of opening the parent of the item (which is where the user already is).
	/// </para>
	/// <para>
	/// Several controls (the <c>Start</c> button on the taskbar, and the namespace control) use <c>IIdentityName</c> to get the
	/// original item and thus avoid duplicate items.
	/// </para>
	/// <para>This interface is helpful with aliased ID lists (type ITEMIDLIST), as can be demonstrated using the following two lists.</para>
	/// <list type="number">
	/// <item>
	/// <term>
	/// [computer][c:][users][pat][desktop][myfile.txt]. This is a file in the user's desktop and is handled by the IShellFolder
	/// implementation in Windows Vista that handles file systems.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// [desktop][myfile.txt]. The IShellFolder implementation behind the desktop shows files from the user's desktop, all of the user's
	/// desktop, and some special items like the <c>Recycle Bin</c>. When asked to bind through IShellFolder::BindToObject using IID
	/// IID_IIdentityName, this <c>IShellFolder</c> returns the underlying item, which is the file folder item just above.
	/// </term>
	/// </item>
	/// </list>
	/// <note>To get an instance of this handler use IShellFolder::BindToObject with IID_IIdentityItem or use IShellItem::BindToHandler
	/// with BHID_SFObject.</note>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-iidentityname
	[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.IIdentityName")]
	[ComImport, Guid("7d903fca-d6f9-4810-8332-946c0177e247"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IIdentityName : IRelatedItem
	{
		/// <summary>Gets the pointer to an item identifier list (PIDL) for the item that is related.</summary>
		/// <returns>
		/// <para>Type: <c>PIDLIST_ABSOLUTE*</c></para>
		/// <para>When this method returns, contains the PIDL.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-irelateditem-getitemidlist HRESULT
		// GetItemIDList( PIDLIST_ABSOLUTE *ppidl );
		new PIDL GetItemIDList();

		/// <summary>Gets the IShellItem that is related to this item.</summary>
		/// <returns>
		/// <para>Type: <c>IShellItem**</c></para>
		/// <para>
		/// When this method returns, contains the address of a pointer to the IShellItem interface for the item that is related to this item.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-irelateditem-getitem HRESULT GetItem(
		// IShellItem **ppsi );
		new IShellItem GetItem();
	}

	/// <summary>Identifies an item that will be shown in the preview pane.</summary>
	/// <remarks>
	/// <para>This interface provides only the methods of the IRelatedItem interface, from which it inherits.</para>
	/// <para>When to Implement</para>
	/// <para>
	/// An implementation of this interface for system-provided data objects is provided with Windows. Custom data sources that want to
	/// expose this information must implement the interface as part of their data object.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-ipreviewitem
	[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.IPreviewItem")]
	[ComImport, Guid("36149969-0A8F-49c8-8B00-4AECB20222FB"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IPreviewItem : IRelatedItem
	{
		/// <summary>Gets the pointer to an item identifier list (PIDL) for the item that is related.</summary>
		/// <returns>
		/// <para>Type: <c>PIDLIST_ABSOLUTE*</c></para>
		/// <para>When this method returns, contains the PIDL.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-irelateditem-getitemidlist HRESULT
		// GetItemIDList( PIDLIST_ABSOLUTE *ppidl );
		new PIDL GetItemIDList();

		/// <summary>Gets the IShellItem that is related to this item.</summary>
		/// <returns>
		/// <para>Type: <c>IShellItem**</c></para>
		/// <para>
		/// When this method returns, contains the address of a pointer to the IShellItem interface for the item that is related to this item.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-irelateditem-getitem HRESULT GetItem(
		// IShellItem **ppsi );
		new IShellItem GetItem();
	}

	/// <summary>Exposes methods that derive related items with specific relationships.</summary>
	/// <remarks>
	/// <para>
	/// Do not implement this interface directly. This is a base interface (other interfaces derive from it) for a set of interfaces
	/// that describes the relationship between two items, (For example IDisplayItem). Do not query for this interface directly, for
	/// example, using QueryInterface or IShellFolder::BindToObject. Instead, use the derived interfaces.
	/// </para>
	/// <para>
	/// An example derivation is the creation of an identity name handler. For more information, see IIdentityName. Other interfaces
	/// that may derive from this interface include ICurrentItem, and ITransferMediumItem.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-irelateditem
	[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.IRelatedItem")]
	[ComImport, Guid("a73ce67a-8ab1-44f1-8d43-d2fcbf6b1cd0"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IRelatedItem
	{
		/// <summary>Gets the pointer to an item identifier list (PIDL) for the item that is related.</summary>
		/// <returns>
		/// <para>Type: <c>PIDLIST_ABSOLUTE*</c></para>
		/// <para>When this method returns, contains the PIDL.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-irelateditem-getitemidlist HRESULT
		// GetItemIDList( PIDLIST_ABSOLUTE *ppidl );
		PIDL GetItemIDList();

		/// <summary>Gets the IShellItem that is related to this item.</summary>
		/// <returns>
		/// <para>Type: <c>IShellItem**</c></para>
		/// <para>
		/// When this method returns, contains the address of a pointer to the IShellItem interface for the item that is related to this item.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-irelateditem-getitem HRESULT GetItem(
		// IShellItem **ppsi );
		IShellItem GetItem();
	}

	/// <summary>
	/// Used by a copy engine to get the item on which to call QueryInterface to return a pointer to interface ITransferDestination or
	/// interface ITransferSource. These interfaces can be queried and enumerated for copy, move, or delete operations.
	/// </summary>
	/// <remarks>This interface provides only the methods of the IRelatedItem interface, from which it inherits.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-itransfermediumitem
	[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.ITransferMediumItem")]
	[ComImport, Guid("77f295d5-2d6f-4e19-b8ae-322f3e721ab5"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ITransferMediumItem : IRelatedItem
	{
		/// <summary>Gets the pointer to an item identifier list (PIDL) for the item that is related.</summary>
		/// <returns>
		/// <para>Type: <c>PIDLIST_ABSOLUTE*</c></para>
		/// <para>When this method returns, contains the PIDL.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-irelateditem-getitemidlist HRESULT
		// GetItemIDList( PIDLIST_ABSOLUTE *ppidl );
		new PIDL GetItemIDList();

		/// <summary>Gets the IShellItem that is related to this item.</summary>
		/// <returns>
		/// <para>Type: <c>IShellItem**</c></para>
		/// <para>
		/// When this method returns, contains the address of a pointer to the IShellItem interface for the item that is related to this item.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-irelateditem-getitem HRESULT GetItem(
		// IShellItem **ppsi );
		new IShellItem GetItem();
	}

	/// <summary>Provides a canonical persistence item, an item for which view customizations will be remembered.</summary>
	/// <remarks>This interface provides only the methods of the IRelatedItem interface, from which it inherits.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-iviewstateidentityitem
	[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.IViewStateIdentityItem")]
	[ComImport, Guid("9D264146-A94F-4195-9F9F-3BB12CE0C955"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IViewStateIdentityItem : IRelatedItem
	{
		/// <summary>Gets the pointer to an item identifier list (PIDL) for the item that is related.</summary>
		/// <returns>
		/// <para>Type: <c>PIDLIST_ABSOLUTE*</c></para>
		/// <para>When this method returns, contains the PIDL.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-irelateditem-getitemidlist HRESULT
		// GetItemIDList( PIDLIST_ABSOLUTE *ppidl );
		new PIDL GetItemIDList();

		/// <summary>Gets the IShellItem that is related to this item.</summary>
		/// <returns>
		/// <para>Type: <c>IShellItem**</c></para>
		/// <para>
		/// When this method returns, contains the address of a pointer to the IShellItem interface for the item that is related to this item.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-irelateditem-getitem HRESULT GetItem(
		// IShellItem **ppsi );
		new IShellItem GetItem();
	}
}