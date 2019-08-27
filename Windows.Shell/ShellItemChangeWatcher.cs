using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using Vanara.PInvoke;
using static Vanara.PInvoke.Shell32;

namespace Vanara.Windows.Shell
{
	/// <summary>Changes that might occur to a shell item or folder.</summary>
	[Flags]
	public enum ChangeFilters : uint
	{
		/// <summary>
		/// The name of a nonfolder item has changed. SHCNF_IDLIST or SHCNF_PATH must be specified in uFlags. dwItem1 contains the previous
		/// PIDL or name of the item. dwItem2 contains the new PIDL or name of the item.
		/// </summary>
		ItemRenamed = SHCNE.SHCNE_RENAMEITEM,

		/// <summary>
		/// A nonfolder item has been created. SHCNF_IDLIST or SHCNF_PATH must be specified in uFlags. dwItem1 contains the item that was
		/// created. dwItem2 is not used and should be NULL.
		/// </summary>
		ItemCreated = SHCNE.SHCNE_CREATE,

		/// <summary>
		/// A nonfolder item has been deleted. SHCNF_IDLIST or SHCNF_PATH must be specified in uFlags. dwItem1 contains the item that was
		/// deleted. dwItem2 is not used and should be NULL.
		/// </summary>
		ItemDeleted = SHCNE.SHCNE_DELETE,

		/// <summary>
		/// A folder has been created. SHCNF_IDLIST or SHCNF_PATH must be specified in uFlags. dwItem1 contains the folder that was created.
		/// dwItem2 is not used and should be NULL.
		/// </summary>
		FolderCreated = SHCNE.SHCNE_MKDIR,

		/// <summary>
		/// A folder has been removed. SHCNF_IDLIST or SHCNF_PATH must be specified in uFlags. dwItem1 contains the folder that was removed.
		/// dwItem2 is not used and should be NULL.
		/// </summary>
		FolderDeleted = SHCNE.SHCNE_RMDIR,

		/// <summary>
		/// Storage media has been inserted into a drive. SHCNF_IDLIST or SHCNF_PATH must be specified in uFlags. dwItem1 contains the root
		/// of the drive that contains the new media. dwItem2 is not used and should be NULL.
		/// </summary>
		MediaInserted = SHCNE.SHCNE_MEDIAINSERTED,

		/// <summary>
		/// Storage media has been removed from a drive. SHCNF_IDLIST or SHCNF_PATH must be specified in uFlags. dwItem1 contains the root of
		/// the drive from which the media was removed. dwItem2 is not used and should be NULL.
		/// </summary>
		MediaRemoved = SHCNE.SHCNE_MEDIAREMOVED,

		/// <summary>
		/// A drive has been removed. SHCNF_IDLIST or SHCNF_PATH must be specified in uFlags. dwItem1 contains the root of the drive that was
		/// removed. dwItem2 is not used and should be NULL.
		/// </summary>
		DriveRemoved = SHCNE.SHCNE_DRIVEREMOVED,

		/// <summary>
		/// A drive has been added. SHCNF_IDLIST or SHCNF_PATH must be specified in uFlags. dwItem1 contains the root of the drive that was
		/// added. dwItem2 is not used and should be NULL.
		/// </summary>
		DriveAdded = SHCNE.SHCNE_DRIVEADD,

		/// <summary>
		/// A folder on the local computer is being shared via the network. SHCNF_IDLIST or SHCNF_PATH must be specified in uFlags. dwItem1
		/// contains the folder that is being shared. dwItem2 is not used and should be NULL.
		/// </summary>
		FolderShared = SHCNE.SHCNE_NETSHARE,

		/// <summary>
		/// A folder on the local computer is no longer being shared via the network. SHCNF_IDLIST or SHCNF_PATH must be specified in uFlags.
		/// dwItem1 contains the folder that is no longer being shared. dwItem2 is not used and should be NULL.
		/// </summary>
		FolderUnshared = SHCNE.SHCNE_NETUNSHARE,

		/// <summary>
		/// The attributes of an item or folder have changed. SHCNF_IDLIST or SHCNF_PATH must be specified in uFlags. dwItem1 contains the
		/// item or folder that has changed. dwItem2 is not used and should be NULL.
		/// </summary>
		Attributes = SHCNE.SHCNE_ATTRIBUTES,

		/// <summary>
		/// The contents of an existing folder have changed, but the folder still exists and has not been renamed. SHCNF_IDLIST or SHCNF_PATH
		/// must be specified in uFlags. dwItem1 contains the folder that has changed. dwItem2 is not used and should be NULL. If a folder
		/// has been created, deleted, or renamed, use SHCNE_MKDIR, SHCNE_RMDIR, or SHCNE_RENAMEFOLDER, respectively.
		/// </summary>
		FolderUpdated = SHCNE.SHCNE_UPDATEDIR,

		/// <summary>
		/// An existing item (a folder or a nonfolder) has changed, but the item still exists and has not been renamed. SHCNF_IDLIST or
		/// SHCNF_PATH must be specified in uFlags. dwItem1 contains the item that has changed. dwItem2 is not used and should be NULL. If a
		/// nonfolder item has been created, deleted, or renamed, use SHCNE_CREATE, SHCNE_DELETE, or SHCNE_RENAMEITEM, respectively, instead.
		/// </summary>
		ItemUpdated = SHCNE.SHCNE_UPDATEITEM,

		/// <summary>
		/// The computer has disconnected from a server. SHCNF_IDLIST or SHCNF_PATH must be specified in uFlags. dwItem1 contains the server
		/// from which the computer was disconnected. dwItem2 is not used and should be NULL.
		/// </summary>
		ServerDisconnected = SHCNE.SHCNE_SERVERDISCONNECT,

		/// <summary>
		/// An image in the system image list has changed. SHCNF_DWORD must be specified in uFlags. dwItem2 contains the index in the system
		/// image list that has changed. dwItem1 is not used and should be NULL.
		/// </summary>
		SystemImageUpdated = SHCNE.SHCNE_UPDATEIMAGE,

		/// <summary>
		/// A drive has been added. SHCNF_IDLIST or SHCNF_PATH must be specified in uFlags. dwItem1 contains the root of the drive that was
		/// added. dwItem2 is not used and should be NULL.
		/// </summary>
		DriveAddedInteractive = SHCNE.SHCNE_DRIVEADDGUI,

		/// <summary>
		/// The name of a folder has changed. SHCNF_IDLIST or SHCNF_PATH must be specified in uFlags. dwItem1 contains the previous PIDL or
		/// name of the folder. dwItem2 contains the new PIDL or name of the folder.
		/// </summary>
		FolderRenamed = SHCNE.SHCNE_RENAMEFOLDER,

		/// <summary>
		/// The amount of free space on a drive has changed. SHCNF_IDLIST or SHCNF_PATH must be specified in uFlags. dwItem1 contains the
		/// root of the drive on which the free space changed. dwItem2 is not used and should be NULL.
		/// </summary>
		DriveFreeSpaceChanged = SHCNE.SHCNE_FREESPACE,

		/// <summary>
		/// A file type association has changed. SHCNF_IDLIST must be specified in the uFlags parameter. dwItem1 and dwItem2 are not used and
		/// must be NULL. This event should also be sent for registered protocols.
		/// </summary>
		FileAssociationChanged = SHCNE.SHCNE_ASSOCCHANGED,

		/// <summary>All disk related events.</summary>
		AllDiskEvents = SHCNE.SHCNE_DISKEVENTS,

		/// <summary>All global events.</summary>
		AllGlobalEvents = SHCNE.SHCNE_GLOBALEVENTS,

		/// <summary>All events.</summary>
		AllEvents = SHCNE.SHCNE_ALLEVENTS,
	}

	/// <summary>Listens to the shell item change notifications and raises events when a folder, or item in a folder, changes.</summary>
	[DefaultProperty(nameof(Item)), DefaultEvent(nameof(Changed))]
	public class ShellItemChangeWatcher : Component, ISupportInitialize
	{
		private readonly WatcherNativeWindow hPump;
		private bool enabled;
		private bool initializing;
		private ShellItem item;
		private ChangeFilters notifyFilter = ChangeFilters.AllEvents;
		private bool recursive;
		private uint ulRegister;

		/// <summary>Initializes a new instance of the <see cref="ShellItemChangeWatcher"/> class.</summary>
		public ShellItemChangeWatcher() => hPump = new WatcherNativeWindow(this);

		/// <summary>Initializes a new instance of the <see cref="ShellItemChangeWatcher"/> class, given the shell item.</summary>
		/// <param name="shItem">The shell item.</param>
		/// <param name="inclChildren">if set to <c>true</c> include children.</param>
		public ShellItemChangeWatcher(ShellItem shItem, bool inclChildren = false) : this()
		{
			Item = shItem;
			IncludeChildren = inclChildren;
		}

		/// <summary>Occurs when a shell folder or item is changed.</summary>
		public event EventHandler<ShellItemChangeEventArgs> Changed;

		/// <summary>Gets or sets a value indicating whether the component is enabled.</summary>
		/// <value><see langword="true"/> if the component is enabled; otherwise, <see langword="false"/>. The default is <see langword="false"/>.</value>
		[DefaultValue(false), Category("Behavior"), Description("Indicates whether the component is enabled.")]
		public bool EnableRaisingEvents
		{
			get => enabled;
			set
			{
				if (value == enabled) return;
				enabled = value;
				if (IsSuspended) return;
				if (enabled)
					StartWatching();
				else
					StopWatching();
			}
		}

		/// <summary>Gets or sets a value indicating whether the children of the specified shell item should be monitored.</summary>
		/// <value><see langword="true"/> if you want to monitor children; otherwise, <see langword="false"/>. The default is <see langword="false"/>.</value>
		[DefaultValue(false), Category("Behavior"), Description("Indicates whether the children of the specified shell item should be monitored.")]
		public bool IncludeChildren
		{
			get => recursive;
			set
			{
				if (recursive == value) return;
				recursive = value;
				Restart();
			}
		}

		/// <summary>Gets or sets the shell item to watch.</summary>
		/// <value>The shell item to monitor. The default is <see langword="null"/>.</value>
		/// <exception cref="ArgumentNullException">Item</exception>
		[DefaultValue(null), Category("Data"), Description("The shell item to watch.")]
		public ShellItem Item
		{
			get => item;
			set
			{
				if (value is null) throw new ArgumentNullException(nameof(Item));
				if (item == value) return;
				item = value;
				Restart();
			}
		}

		/// <summary>Gets or sets the type of changes to watch for.</summary>
		/// <value>One of the <see cref="ChangeFilters"/> values. The default is <see cref="ChangeFilters.AllEvents"/>.</value>
		[DefaultValue(ChangeFilters.AllEvents), Category("Behavior"), Description("The type of changes to watch for.")]
		public ChangeFilters NotifyFilter
		{
			get => notifyFilter;
			set
			{
				if (notifyFilter == value) return;
				notifyFilter = value;
				Restart();
			}
		}

		private bool IsSuspended => initializing || DesignMode;

		/// <summary>
		/// Begins the initialization of a <see cref="ShellItemChangeWatcher"/> used on a form or used by another component. The
		/// initialization occurs at run time.
		/// </summary>
		/// <remarks>
		/// The Visual Studio design environment uses this method to start the initialization of a component used on a form or used by
		/// another component. The <see cref="EndInit"/> method ends the initialization. Using the <see cref="BeginInit"/> and
		/// <see cref="EndInit"/> methods prevents the control from being used before it is fully initialized.
		/// </remarks>
		public void BeginInit()
		{
			var oldEnabled = enabled;
			StopWatching();
			enabled = oldEnabled;
			initializing = true;
		}

		/// <summary>
		/// Ends the initialization of a <see cref="ShellItemChangeWatcher"/> used on a form or used by another component. The initialization
		/// occurs at run time.
		/// </summary>
		/// <remarks>
		/// The Visual Studio design environment uses this method to start the initialization of a component used on a form or used by
		/// another component. The <see cref="EndInit"/> method ends the initialization. Using the <see cref="BeginInit"/> and
		/// <see cref="EndInit"/> methods prevents the control from being used before it is fully initialized.
		/// </remarks>
		public void EndInit()
		{
			initializing = false;
			if (!(item is null) && enabled)
				StartWatching();
		}

		/// <summary>Releases unmanaged and - optionally - managed resources.</summary>
		/// <param name="disposing">
		/// <c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.
		/// </param>
		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
			if (disposing) StopWatching();
		}

		/// <summary>Raises the <see cref="Changed"/> event.</summary>
		/// <param name="e">The <see cref="ShellItemChangeEventArgs"/> instance containing the event data.</param>
		protected virtual void OnChanged(ShellItemChangeEventArgs e) => Changed?.Invoke(this, e);

		private void Restart()
		{
			if (IsSuspended || !enabled) return;
			StopWatching();
			StartWatching();
		}

		private void StartWatching()
		{
			const SHCNRF sources = SHCNRF.SHCNRF_ShellLevel | SHCNRF.SHCNRF_InterruptLevel | SHCNRF.SHCNRF_NewDelivery;

			enabled = true;
			if (IsSuspended) return;

			SHGetIDListFromObject(Item.IShellItem, out var pidlWatch).ThrowIfFailed();
			SHChangeNotifyEntry[] entries = { new SHChangeNotifyEntry { pidl = pidlWatch.DangerousGetHandle(), fRecursive = IncludeChildren } };
			ulRegister = SHChangeNotifyRegister(hPump.Handle, sources, (SHCNE)NotifyFilter, hPump.MessageId, entries.Length, entries);
		}

		private void StopWatching()
		{
			enabled = false;
			if (IsSuspended) return;

			if (ulRegister == 0) return;
			SHChangeNotifyDeregister(ulRegister);
			ulRegister = 0;
		}

		/// <summary>Provides data for <see cref="ShellItemChangeWatcher"/> events.</summary>
		/// <seealso cref="System.EventArgs"/>
		public class ShellItemChangeEventArgs : EventArgs
		{
			internal ShellItemChangeEventArgs(SHCNE levent, IntPtr rgpidl)
			{
				ChangeType = (ChangeFilters)levent;
				ChangedItems = new PIDL(rgpidl, true).Select(p => new ShellItem(p)).ToArray();
			}

			/// <summary>Gets the items affected by the change.</summary>
			/// <value>The changed items.</value>
			public ShellItem[] ChangedItems { get; }

			/// <summary>Gets the type of change event that occurred.</summary>
			/// <value>One of the <see cref="ChangeFilters"/> values that represents the kind of change detected for the shell item.</value>
			public ChangeFilters ChangeType { get; }
		}

		private class WatcherNativeWindow : NativeWindow
		{
			private ShellItemChangeWatcher p;

			public WatcherNativeWindow(ShellItemChangeWatcher parent)
			{
				MessageId = User32.RegisterWindowMessage($"{parent.GetType()}{DateTime.Now.Ticks}");
				p = parent;
				var cp = new CreateParams { Style = 0, ExStyle = 0, ClassStyle = 0, Parent = IntPtr.Zero, Caption = GetType().Name };
				CreateHandle(cp);
			}

			public uint MessageId { get; set; }

			protected override void WndProc(ref Message m)
			{
				if (m.Msg == MessageId)
				{
					HLOCK hNotifyLock = default;
					try
					{
						hNotifyLock = SHChangeNotification_Lock(m.WParam, (uint)m.LParam.ToInt32(), out var rgpidl, out var lEvent);
						if (hNotifyLock != IntPtr.Zero) //  && (lEvent & (int)(SHCNE.SHCNE_UPDATEIMAGE | SHCNE.SHCNE_ASSOCCHANGED | SHCNE.SHCNE_EXTENDED_EVENT | SHCNE.SHCNE_FREESPACE | SHCNE.SHCNE_DRIVEADDGUI | SHCNE.SHCNE_SERVERDISCONNECT)) != 0
							p.OnChanged(new ShellItemChangeEventArgs(lEvent, rgpidl));
					}
					finally
					{
						if (hNotifyLock != default)
							SHChangeNotification_Unlock(hNotifyLock);
					}
					return;
				}
				base.WndProc(ref m);
			}
		}
	}
}