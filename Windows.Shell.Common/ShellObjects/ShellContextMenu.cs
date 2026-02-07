// Credit due to Gong-Shell from which this was largely taken.
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using Vanara.PInvoke;
using static Vanara.PInvoke.Shell32;
using static Vanara.PInvoke.User32;

namespace Vanara.Windows.Shell;

/// <summary>Provides support for displaying the context menu of a shell item.</summary>
/// <remarks>
/// <para>Use this class to display a context menu for a shell item, either as a popup menu, or as a main menu.</para>
/// <para>
/// To display a popup menu, simply call <see cref="ShowContextMenu"/> with the parent control and the position at which the menu should
/// be shown.
/// </para>
/// <para>
/// To display a shell context menu in a Form's main menu, call the <see cref="GetItems"/> methods to populate the menu. In addition,
/// you must intercept a number of special messages that will be sent to the menu's parent form by hooking its message loop as in the
/// following WinForms example:
/// </para>
/// <code>protected override void WndProc(ref Message m) {
///   if ((m_ContextMenu == null) || (!m_ContextMenu.HandleMenuMessage(ref m))) {
///      base.WndProc(ref m);
///   }
/// }</code>
/// <para>Where m_ContextMenu is the <see cref="ShellContextMenu"/> being shown.</para>
/// Standard menu commands can also be invoked from this class, for example <see cref="InvokeDelete"/> and <see cref="InvokeRename"/>.
/// </remarks>
public class ShellContextMenu : IDisposable
{
	internal const CMF defaultPopulateFlag = CMF.CMF_NORMAL | CMF.CMF_EXTENDEDVERBS;
	internal const int m_CmdFirst = 1;
	private IContextMenu2? m_ComInterface2;
	private IContextMenu3? m_ComInterface3;
	private BasicMessageWindow m_MessageWindow;
	private readonly IDisposable? disposables;
	private bool disposed = false;
	private CMF initVal = CMF.CMF_RESERVED;
	private SafeHMENU? m_hMenu;

	/// <summary>Initializes a new instance of the <see cref="ShellContextMenu"/> class.</summary>
	/// <param name="contextMenu">The interface for the context menu.</param>
	/// <exception cref="System.ArgumentNullException">contextMenu</exception>
	public ShellContextMenu(IContextMenu contextMenu) => Init(contextMenu);

	/// <summary>Initialises a new instance of the <see cref="ShellContextMenu"/> class.</summary>
	/// <param name="items">The items to which the context menu should refer.</param>
	[Obsolete("Use ShellContextMenu.CreateFromItems instead to get better disposal handling. This constructor will be removed in the next release as it fails due to disposal issues.")]
	public ShellContextMenu(params ShellItem[] items)
	{
		Init(SHCreateDefaultContextMenuEx(null, out disposables, Array.ConvertAll(items, i => i.PIDL)));
		if (ComInterface is IShellExtInit ext)
			ext.Initialize(items[0].IsFolder ? items[0].PIDL : items[0].Parent!.PIDL).ThrowIfFailed("Failed to initialize IShellExtInit.");
	}

	/// <summary>Finalizes an instance of the <see cref="ShellContextMenu"/> class.</summary>
	~ShellContextMenu() => Dispose(disposing: false);

	/// <summary>Occurs when a new menu handle has been created and populated by Windows.</summary>
	public event EventHandler<MenuCreatedEventArgs>? MenuCreated;

	/// <summary>Gets the underlying COM <see cref="IContextMenu"/> interface.</summary>
	public IContextMenu ComInterface { get; private set; }

	/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
	public void Dispose()
	{
		// Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	/// <summary>Gets the help text for a specified command.</summary>
	/// <param name="command">The menu command identifier offset.</param>
	/// <returns>The help text value if available; otherwise <see langword="null"/>.</returns>
	public string? GetHelpTextForCommand(int command) => GetCommandString(command, GCS.GCS_HELPTEXTA);

	/// <summary>Gets the icon location for a specified command.</summary>
	/// <param name="command">The menu command identifier offset.</param>
	/// <returns>The icon location if available; otherwise <see langword="null"/>.</returns>
	public string? GetVerbIconLocationForCommand(int command) => GetCommandString(command, GCS.GCS_VERBICONW);

	/// <summary>Gets the verb for a specified command.</summary>
	/// <param name="command">The menu command identifier offset.</param>
	/// <returns>The verb if available; otherwise <see langword="null"/>.</returns>
	public string? GetVerbForCommand(int command) => GetCommandString(command, GCS.GCS_VERBA);

	/// <summary>Gets the information of all the menu items supported by the underlying interface.</summary>
	/// <value>The menu item information.</value>
	public MenuItemInfo[] GetItems(CMF menuOptions = defaultPopulateFlag)
	{
		PopulateMenu(menuOptions);
		return MenuItemInfo.GetMenuItems(m_hMenu, ComInterface);
	}

	/// <summary>Gets the information of all the menu items supported by the underlying interface.</summary>
	/// <value>The menu item information.</value>
	public async Task<MenuItemInfo[]> GetItemsAsync(CMF menuOptions = defaultPopulateFlag)
	{
		await PopulateMenuAsync(menuOptions);
		return await MenuItemInfo.GetMenuItemsAsync(m_hMenu, ComInterface);
	}

	/// <summary>Invokes the command.</summary>
	/// <param name="cmdInfo">
	/// The <see cref="CMINVOKECOMMANDINFO"/>, <see cref="CMINVOKECOMMANDINFOP"/>, or <see cref="CMINVOKECOMMANDINFOEX"/> with details about
	/// the invocation.
	/// </param>
	public void Invoke<T>(in T cmdInfo) where T : struct
	{
		// This is a little hack to get the menu to show up. If we don't call QueryContextMenu first, the menu won't show up. attr: @zhuxb711
		PopulateMenu(defaultPopulateFlag);
		ComInterface.InvokeCommand(cmdInfo).ThrowIfFailed();
	}

	/// <summary>Invokes the command.</summary>
	/// <param name="cmd">
	/// The menu-identifier offset of the command to carry out. The Shell uses this alternative when the user chooses a menu command.
	/// </param>
	/// <param name="parent">
	/// A handle to the window that is the owner of the shortcut menu. An extension can also use this handle as the owner of any message
	/// boxes or dialog boxes it displays. Callers must specify a legitimate HWND that can be used as the owner window for any UI that may be
	/// displayed. Failing to specify an HWND when calling from a UI thread (one with windows already created) will result in reentrancy and
	/// possible bugs in the implementation of this call.
	/// </param>
	public void InvokeCommand(int cmd, HWND parent) =>
		Invoke(new CMINVOKECOMMANDINFOP(cmd) { hwnd = parent, nShow = ShowWindowCommand.SW_NORMAL });

	/// <summary>Invokes the command.</summary>
	/// <param name="verb">
	/// The address of a null-terminated string that specifies the language-independent name of the command to carry out. This member is
	/// typically a string when a command is being activated by an application. The system provides predefined constant values for the
	/// following command strings.
	/// <para>
	/// If a canonical verb exists and a menu handler does not implement the canonical verb, it must return a failure code to enable the
	/// next handler to be able to handle this verb.Failing to do this will break functionality in the system including ShellExecute.
	/// </para>
	/// <para>
	/// Alternatively, rather than a pointer, this parameter can be MAKEINTRESOURCE(offset) where offset is the menu-identifier offset
	/// of the command to carry out. Implementations can use the IS_INTRESOURCE macro to detect that this alternative is being employed.
	/// The Shell uses this alternative when the user chooses a menu command.
	/// </para>
	/// </param>
	/// <param name="show">A set of values to pass to the ShowWindow function if the command displays a window or starts an application.</param>
	/// <param name="parent">
	/// A handle to the window that is the owner of the shortcut menu. An extension can also use this handle as the owner of any message
	/// boxes or dialog boxes it displays. Callers must specify a legitimate HWND that can be used as the owner window for any UI that
	/// may be displayed. Failing to specify an HWND when calling from a UI thread (one with windows already created) will result in
	/// reentrancy and possible bugs in the implementation of this call.
	/// </param>
	/// <param name="location">If supplied, the point where the command is invoked.</param>
	/// <param name="allowAsync">
	/// The implementation can spin off a new thread or process to handle the call and does not need to block on completion of the
	/// function being invoked. For example, if the verb is "delete" the call may return before all of the items have been deleted.
	/// Since this is advisory, calling applications that specify this flag cannot guarantee that this request will be honored if they
	/// are not familiar with the implementation of the verb that they are invoking.
	/// </param>
	/// <param name="shiftDown">
	/// If <see langword="true"/>, the SHIFT key is pressed. Use this instead of polling the current state of the keyboard that may have
	/// changed since the verb was invoked.
	/// </param>
	/// <param name="ctrlDown">
	/// If <see langword="true"/>, the CTRL key is pressed. Use this instead of polling the current state of the keyboard that may have
	/// changed since the verb was invoked..
	/// </param>
	/// <param name="hotkey">An optional keyboard shortcut to assign to any application activated by the command.</param>
	/// <param name="logUsage">
	/// If <see langword="true"/>, indicates that the method might want to keep track of the item being invoked for features like the
	/// "Recent documents" menu.
	/// </param>
	/// <param name="noZoneChecks">
	/// Do not perform a zone check. This flag allows ShellExecuteEx to bypass zone checking put into place by IAttachmentExecute.
	/// </param>
	/// <param name="parameters">Optional parameters.</param>
	public void InvokeCommand(ResourceId verb, ShowWindowCommand show = ShowWindowCommand.SW_SHOWNORMAL, HWND parent = default,
		POINT? location = default, bool allowAsync = false, bool shiftDown = false, bool ctrlDown = false, uint hotkey = 0,
		bool logUsage = false, bool noZoneChecks = false, string? parameters = null) =>
		Invoke(new CMINVOKECOMMANDINFOEX(verb, show, parent, location, allowAsync, shiftDown, ctrlDown, hotkey, logUsage, noZoneChecks, parameters));

	/// <summary>Invokes the Copy command on the shell item(s).</summary>
	public void InvokeCopy() => InvokeVerb("copy");

	/// <summary>Invokes the Copy command on the shell item(s).</summary>
	public void InvokeCut() => InvokeVerb("cut");

	/// <summary>Invokes the Delete command on the shell item(s).</summary>
	public void InvokeDelete()
	{
		try
		{
			InvokeVerb("delete");
		}
		catch (COMException e)
		{
			// Ignore the exception raised when the user cancels a delete operation.
			if (e.ErrorCode != (HRESULT)(Win32Error)Win32Error.ERROR_CANCELLED &&
				e.ErrorCode != HRESULT.COPYENGINE_E_USER_CANCELLED)
			{
				throw;
			}
		}
	}

	/// <summary>Invokes the Paste command on the shell item(s).</summary>
	public void InvokePaste() => InvokeVerb("paste");

	/// <summary>Invokes the Rename command on the shell item.</summary>
	public void InvokeRename() => InvokeVerb("rename");

	/// <summary>Invokes the specified verb on the shell item(s).</summary>
	/// <param name="verb">The verb to invoke.</param>
	/// <param name="show">Flags that specify how to display any opened window.</param>
	/// <param name="parent">
	/// A handle to the window that is the owner of the shortcut menu. An extension can also use this handle as the owner of any message
	/// boxes or dialog boxes it displays. Callers must specify a legitimate HWND that can be used as the owner window for any UI that
	/// may be displayed. Failing to specify an HWND when calling from a UI thread (one with windows already created) will result in
	/// reentrancy and possible bugs in the implementation of this call.
	/// </param>
	public void InvokeVerb(string verb, ShowWindowCommand show = ShowWindowCommand.SW_SHOWNORMAL, HWND parent = default) =>
		Invoke(new CMINVOKECOMMANDINFO(verb) { nShow = show, hwnd = parent });

	/// <summary>Populates the menu with the specified options, creating or updating the menu as needed.</summary>
	/// <remarks>
	/// If the menu has already been created with the same options, this method does not recreate it. After the menu is populated, the
	/// MenuCreated event is raised. This method should be called before displaying the menu to ensure it reflects the desired options.
	/// </remarks>
	/// <param name="menuOptions">The set of menu options to use when building the menu. Determines which commands and items are included.</param>
	public void PopulateMenu(CMF menuOptions = defaultPopulateFlag)
	{
		// Don't process again if already done with same flags
		if (m_hMenu is not null && !m_hMenu.IsInvalid && initVal == menuOptions)
			return;

		m_hMenu = CreatePopupMenu();
		ComInterface.QueryContextMenu(m_hMenu, 0, m_CmdFirst, 0x7FFF, initVal = menuOptions).ThrowIfFailed();
		MenuCreated?.Invoke(this, new(m_hMenu));
	}

	/// <summary>Asynchronously populates the menu using the specified menu options.</summary>
	/// <remarks>
	/// This method executes the menu population logic on a background thread. Use this method to avoid blocking the calling thread,
	/// especially in UI applications.
	/// </remarks>
	/// <param name="menuOptions">An object that specifies the options to use when populating the menu. Cannot be null.</param>
	/// <returns>A task that represents the asynchronous operation.</returns>
	public async Task PopulateMenuAsync(CMF menuOptions = defaultPopulateFlag) => await Task.Run(() => PopulateMenu(menuOptions));

	/// <summary>Shows a context menu for a shell item.</summary>
	/// <param name="pos">The position on the screen that the menu should be displayed at.</param>
	/// <param name="menuOptions">The options that determine which items are requested from <see cref="IContextMenu" />.</param>
	/// <param name="onMenuItemClicked">The delegate to call when a menu item is clicked; If <see langword="null" />, <see cref="InvokeCommand(int, HWND)" /> is called.</param>
	/// <param name="hWnd">The optional parent window handle.</param>
	public void ShowContextMenu(POINT pos, CMF menuOptions = defaultPopulateFlag, Action<HMENU, int, HWND>? onMenuItemClicked = null, HWND hWnd = default)
	{
		PopulateMenu(menuOptions);
		var command = TrackPopupMenuEx(m_hMenu, TrackPopupMenuFlags.TPM_RETURNCMD, pos.X, pos.Y, m_MessageWindow.Handle);
		if (command >= m_CmdFirst)
		{
			var cmd = (int)command - m_CmdFirst;
			Debug.WriteLine($"Popup command {GetCommandString(cmd, GCS.GCS_UNICODE)}, verb=\"{GetVerbForCommand(cmd)}\"");
			if (onMenuItemClicked is null)
				InvokeCommand(cmd, parent: hWnd);
			else
				onMenuItemClicked(m_hMenu, cmd, hWnd);
		}
	}

	/// <summary>Creates a new instance of the ShellContextMenu class for the specified collection of shell items.</summary>
	/// <remarks>
	/// The returned IDisposable in the keepAlive parameter manages native resources required by the context menu. Failing to keep this
	/// object alive may result in unexpected behavior or resource leaks.
	/// </remarks>
	/// <param name="items">The collection of ShellItem objects for which to create the context menu. Cannot be null or contain null elements.</param>
	/// <param name="keepAlive">
	/// When this method returns, contains an IDisposable that must be kept alive for the lifetime of the returned ShellContextMenu instance.
	/// Dispose this object when the context menu is no longer needed.
	/// </param>
	/// <returns>A ShellContextMenu instance representing the context menu for the specified shell items.</returns>
	public static ShellContextMenu CreateFromItems(IEnumerable<ShellItem> items, out IDisposable keepAlive) =>
		new(SHCreateDefaultContextMenuEx(null, out keepAlive, Array.ConvertAll(items.ToArray(), i => i.PIDL)));

	/// <summary>Releases unmanaged and - optionally - managed resources.</summary>
	/// <param name="disposing">
	/// <see langword="true"/> to release both managed and unmanaged resources; <see langword="false"/> to release only unmanaged resources.
	/// </param>
	protected virtual void Dispose(bool disposing)
	{
		if (disposed) return;

		if (disposing)
		{
			// TODO: dispose managed state (managed objects)
		}

		m_MessageWindow?.Dispose();
		Marshal.FinalReleaseComObject(ComInterface);
		ComInterface = null!;
		disposables?.Dispose();
		m_hMenu?.Dispose();
		disposed = true;
	}

	private string? GetCommandString(int command, GCS stringType) =>
		ComInterface.GetCommandString(unchecked((uint)command), stringType, out var mStr).Succeeded ? mStr : null;

	[MemberNotNull(nameof(ComInterface), nameof(m_MessageWindow))]
	private void Init(IContextMenu contextMenu)
	{
		ComInterface = contextMenu ?? throw new ArgumentNullException(nameof(contextMenu));
		m_ComInterface2 = contextMenu as IContextMenu2;
		m_ComInterface3 = contextMenu as IContextMenu3;
		m_MessageWindow = new BasicMessageWindow(WindowMessageFilter);
	}

	private bool WindowMessageFilter(HWND hwnd, uint msg, IntPtr wParam, IntPtr lParam, out IntPtr lReturn)
	{
		lReturn = default;
		try
		{
			if (msg == (uint)WindowMessage.WM_COMMAND && (int)wParam >= m_CmdFirst)
			{
				InvokeCommand((int)wParam - m_CmdFirst);
				return true;
			}
			else
			{
				if (m_ComInterface3 is not null && m_ComInterface3.HandleMenuMsg2(msg, wParam, lParam, out var lRet).Succeeded)
				{
					lReturn = lRet;
					return true;
				}
				else if (m_ComInterface2 is not null && m_ComInterface2.HandleMenuMsg(msg, wParam, lParam).Succeeded)
					return true;
			}
		}
		catch { }
		return false;
	}

	/*internal static IContextMenu MenuFromItems(out List<IDisposable> disposables, params ShellItem[] items)
	{
		if (items is null || items.Length == 0)
			throw new ArgumentNullException(nameof(items));

		ShellFolder pshf;
		PIDL[] pidls;
		disposables = [];
		if (items.Length == 1)
		{
			if (!items[0].IsFolder)
			{
				pshf = items[0].Parent ?? ShellFolder.Desktop;
				SHGetIDListFromObject(items[0], out var pidl).ThrowIfFailed();
				disposables.AddRange(pidls = [new PIDL(pidl)]);
			}
			else
			{
				if (items[0] is ShellFolder sf)
					pshf = sf;
				else
					disposables.Add(pshf = new ShellFolder(items[0]));
				pidls = [];
			}
		}
		else
		{
			disposables.AddRange(pidls = Array.ConvertAll(items, si => new PIDL(si.PIDL)));
			using var pfpidl = PIDL.FindCommonParent(pidls);
			disposables.Add(pshf = new ShellFolder(pfpidl));
		}

		SHCreateDefaultContextMenu(new DEFCONTEXTMENU(pshf.iShellFolder!, pidls, null, out var mem), out IContextMenu? pcm).ThrowIfFailed();
		disposables.Add(mem); // maybe remove?
		return pcm!;
	}*/

#if WINFORMS && HASMENU
	/// <summary>Populates a <see cref="Menu"/> with the context menu items for a shell item.</summary>
	/// <param name="menu">The menu to populate.</param>
	/// <param name="menuOptions">The flags to pass to <see cref="IContextMenu.QueryContextMenu"/>.</param>
	public void Populate(Menu menu, CMF menuOptions = CMF.CMF_NORMAL)
	{
		RemoveShellMenuItems(menu);
		ComInterface.QueryContextMenu(menu.Handle, 0, m_CmdFirst, int.MaxValue, menuOptions);
	}

	private void RemoveShellMenuItems(Menu menu)
	{
		const int tag = 0xAB;

		var menuInfo = new MENUINFO();
		menuInfo.cbSize = (uint)Marshal.SizeOf(menuInfo);
		menuInfo.fMask = MenuInfoMember.MIM_MENUDATA;

		var itemInfo = new MENUITEMINFO();
		itemInfo.cbSize = (uint)Marshal.SizeOf(itemInfo);
		itemInfo.fMask = MenuItemInfoMask.MIIM_ID | MenuItemInfoMask.MIIM_SUBMENU;

		// First, tag the managed menu items with an arbitary value (0xAB).
		TagManagedMenuItems(menu, tag);

		var remove = new Stack<uint>();
		var count = GetMenuItemCount(menu.Handle);
		for (uint n = 0; n < count; ++n)
		{
			GetMenuItemInfo(menu.Handle, n, true, ref itemInfo);

			if (itemInfo.hSubMenu.IsNull)
			{
				// If the item has no submenu we can't get the tag, so check its ID to determine if it was added by the shell.
				if (itemInfo.wID >= m_CmdFirst) remove.Push(n);
			}
			else
			{
				GetMenuInfo(itemInfo.hSubMenu, ref menuInfo);
				if ((int)menuInfo.dwMenuData != tag) remove.Push(n);
			}
		}

		// Remove the unmanaged menu items.
		while (remove.Count > 0)
			DeleteMenu(menu.Handle, remove.Pop(), MenuFlags.MF_BYPOSITION);
	}

	private void TagManagedMenuItems(Menu menu, int tag)
	{
		var info = new MENUINFO
		{
			cbSize = (uint)Marshal.SizeOf(typeof(MENUINFO)),
			fMask = MenuInfoMember.MIM_MENUDATA,
			dwMenuData = (IntPtr)tag
		};

		foreach (Menu item in menu.MenuItems)
		{
			SetMenuInfo(item.Handle, info);
		}
	}

#endif

	/// <summary>Provides information about a single menu entry discovered in a native menu.</summary>
	public class MenuItemInfo
	{
		/// <summary>Initializes a new instance of the <see cref="MenuItemInfo"/> class.</summary>
		/// <param name="hMenu">The menu handle.</param>
		/// <param name="idx">The identifier or position of the menu item to get information about. If zero or positive, it is </param>
		/// <param name="icm">The IContextMenu parent instance.</param>
		public MenuItemInfo(HMENU hMenu, int idx, IContextMenu? icm)
		{
			// Get the string length
			MENUITEMINFO miis = new(MenuItemInfoMask.MIIM_STRING);
			GetMenuItemInfo(hMenu, (uint)Math.Abs(idx), idx >= 0, ref miis);
			using SafeCoTaskMemString strmem = miis.cch == 0 ? SafeCoTaskMemString.Null : new((int)miis.cch + 1, CharSet.Auto);

			// Get all the details
			MENUITEMINFO mii = new(MenuItemInfoMask.MIIM_ID | MenuItemInfoMask.MIIM_SUBMENU | MenuItemInfoMask.MIIM_FTYPE | (miis.cch == 0 ? 0 : MenuItemInfoMask.MIIM_STRING) | MenuItemInfoMask.MIIM_STATE | MenuItemInfoMask.MIIM_BITMAP)
			{
				dwTypeData = (IntPtr)strmem,
				cch = (uint)strmem.Capacity
			};
			Win32Error.ThrowLastErrorIfFalse(GetMenuItemInfo(hMenu, (uint)Math.Abs(idx), idx >= 0, ref mii));
			Id = unchecked((int)mii.wID);
			Text = mii.fType.IsFlagSet(MenuItemType.MFT_SEPARATOR) ? "-" : mii.fType.IsFlagSet(MenuItemType.MFT_STRING) ? mii.dwTypeData.ToString() ?? "" : "";
			Type = mii.fType;
			State = mii.fState;
			BitmapHandle = mii.hbmpItem;
			if (icm is not null && !mii.fType.IsFlagSet(MenuItemType.MFT_SEPARATOR))
			{
				uint id = mii.wID - m_CmdFirst;
				Verb = icm.GetCommandString(id, GCS.GCS_VERBW, out string? str).Succeeded ? str : null;
				HelpText = icm.GetCommandString(id, GCS.GCS_HELPTEXTW, out str).Succeeded ? str : null;
				VerbIconLocation = icm.GetCommandString(id, GCS.GCS_VERBICONW, out str).Succeeded ? str : null;
			}
			SubMenus = GetMenuItems(mii.hSubMenu, icm);
		}

		/// <summary>
		/// <para>A handle to the bitmap to be displayed, or it can be one of the values in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>HBMMENU_CALLBACK ((HBITMAP) -1)</term>
		/// <term>
		/// A bitmap that is drawn by the window that owns the menu. The application must process the WM_MEASUREITEM and WM_DRAWITEM messages.
		/// </term>
		/// </item>
		/// <item>
		/// <term>HBMMENU_MBAR_CLOSE ((HBITMAP) 5)</term>
		/// <term>Close button for the menu bar.</term>
		/// </item>
		/// <item>
		/// <term>HBMMENU_MBAR_CLOSE_D ((HBITMAP) 6)</term>
		/// <term>Disabled close button for the menu bar.</term>
		/// </item>
		/// <item>
		/// <term>HBMMENU_MBAR_MINIMIZE ((HBITMAP) 3)</term>
		/// <term>Minimize button for the menu bar.</term>
		/// </item>
		/// <item>
		/// <term>HBMMENU_MBAR_MINIMIZE_D ((HBITMAP) 7)</term>
		/// <term>Disabled minimize button for the menu bar.</term>
		/// </item>
		/// <item>
		/// <term>HBMMENU_MBAR_RESTORE ((HBITMAP) 2)</term>
		/// <term>Restore button for the menu bar.</term>
		/// </item>
		/// <item>
		/// <term>HBMMENU_POPUP_CLOSE ((HBITMAP) 8)</term>
		/// <term>Close button for the submenu.</term>
		/// </item>
		/// <item>
		/// <term>HBMMENU_POPUP_MAXIMIZE ((HBITMAP) 10)</term>
		/// <term>Maximize button for the submenu.</term>
		/// </item>
		/// <item>
		/// <term>HBMMENU_POPUP_MINIMIZE ((HBITMAP) 11)</term>
		/// <term>Minimize button for the submenu.</term>
		/// </item>
		/// <item>
		/// <term>HBMMENU_POPUP_RESTORE ((HBITMAP) 9)</term>
		/// <term>Restore button for the submenu.</term>
		/// </item>
		/// <item>
		/// <term>HBMMENU_SYSTEM ((HBITMAP) 1)</term>
		/// <term>Windows icon or the icon of the window specified in dwItemData.</term>
		/// </item>
		/// </list>
		/// </summary>
		public HBITMAP BitmapHandle { get; }

		private Lazy<System.Drawing.Bitmap?> _bitmapLazy => new(() => BitmapHandle.DangerousGetHandle().ToInt32() <= 11 ? null : System.Drawing.Image.FromHbitmap(BitmapHandle.DangerousGetHandle()));

		/// <summary>Gets the bitmap associated with the menu item, if any.</summary>
		public System.Drawing.Bitmap? Bitmap => _bitmapLazy.Value;

		/// <summary>Gets the help text (tool tip) associated with the menu.</summary>
		public string? HelpText { get; internal set; }

		/// <summary>An application-defined value that identifies the menu item.</summary>
		public int Id { get; }

		/// <summary>The menu item state. This member can be one or more of the <see cref="MenuItemState"/> values.</summary>
		public MenuItemState State { get; }

		/// <summary>
		/// The submenu items associated with the menu item. If the menu item is not an item that opens a drop-down menu or submenu,
		/// this member has no values.
		/// </summary>
		public MenuItemInfo[] SubMenus { get; }

		/// <summary>The contents of the menu item. The meaning of this member depends on the value of <see cref="Type"/>.</summary>
		public string Text { get; }

		/// <summary>
		/// <para>The menu item type. This member can be one or more of the <see cref="MenuItemType"/> values.</para>
		/// <para>The <c>MFT_BITMAP</c>, <c>MFT_SEPARATOR</c>, and <c>MFT_STRING</c> values cannot be combined with one another.</para>
		/// </summary>
		public MenuItemType Type { get; }

		/// <summary>Gets the verb associated with the menu.</summary>
		public string? Verb { get; internal set; }

		/// <summary>Gets the icon location associated with the menu's image.</summary>
		public string? VerbIconLocation { get; internal set; }

		/// <summary>Recursively gets the information for all menu item entries supplied by the provided native menu.</summary>
		/// <param name="hMenu">The handle to the created native menu.</param>
		/// <returns>An array of <see cref="MenuItemInfo"/> instances with information about the entries in <paramref name="hMenu"/>.</returns>
		public static MenuItemInfo[] GetMenuItems(HMENU hMenu) => GetMenuItems(hMenu, null);

		/// <summary>Recursively gets the information for all menu item entries supplied by the provided native menu.</summary>
		/// <param name="hMenu">The handle to the Windows menu from which to retrieve menu items.</param>
		/// <param name="scm">An optional context menu interface used to provide additional information about the menu items. Can be null.</param>
		/// <returns>An array of <see cref="MenuItemInfo"/> instances with information about the entries in <paramref name="hMenu"/>.</returns>
		public static MenuItemInfo[] GetMenuItems(HMENU hMenu, IContextMenu? scm)
		{
			var SubMenus = new MenuItemInfo[hMenu.IsNull ? 0 : GetMenuItemCount(hMenu)];
			for (int i = 0; i < SubMenus.Length; i++)
				SubMenus[i] = new MenuItemInfo(hMenu, i, scm);
			return SubMenus;
		}

		/// <summary>Asynchronously retrieves an array of menu items from the specified Windows menu handle.</summary>
		/// <remarks>
		/// This method executes the retrieval operation on a background thread to avoid blocking the calling thread. Use this method when
		/// working with UI menus in asynchronous scenarios.
		/// </remarks>
		/// <param name="hMenu">The handle to the Windows menu from which to retrieve menu items.</param>
		/// <param name="scm">An optional context menu interface used to provide additional information about the menu items. Can be null.</param>
		/// <returns>
		/// A task that represents the asynchronous operation. The task result contains an array of <see cref="MenuItemInfo"/> objects
		/// representing the menu items. The array is empty if the menu contains no items.
		/// </returns>
		public static async Task<MenuItemInfo[]> GetMenuItemsAsync(HMENU hMenu, IContextMenu? scm) => await Task.Run(() => GetMenuItems(hMenu, scm));
	}
}

/// <summary>
/// Event arguments for <see cref="ShellContextMenu.MenuCreated"/> events giving access to the menu handle that was created and filled by the system.
/// </summary>
/// <seealso cref="System.EventArgs"/>
public class MenuCreatedEventArgs : EventArgs
{
	internal MenuCreatedEventArgs(HMENU hMenu) => MenuHandle = hMenu;

	/// <summary>Gets the menu handle.</summary>
	/// <value>The menu handle.</value>
	public HMENU MenuHandle { get; }
}