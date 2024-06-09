using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Vanara.PInvoke;
using static Vanara.PInvoke.Shell32;
using static Vanara.PInvoke.Shell32.ShellUtil;

namespace Vanara.Windows.Shell
{
	/// <summary>Event arguments that expose an ID list and associated image.</summary>
	/// <seealso cref="System.EventArgs"/>
	public class ShellIconExtractedEventArgs(PIDL pidl, int idx) : EventArgs
	{
		/// <summary>Gets the retrieved icon.</summary>
		/// <value>The icon.</value>
		public int ImageListIndex { get; } = idx;

		/// <summary>Gets the item ID list.</summary>
		/// <value>The item ID list.</value>
		public PIDL ItemID { get; } = pidl;
	}

	/// <summary>Class that simplifies extracting icons from items in a Shell Folder.</summary>
	public class ShellIconExtractor
	{
		private const int defSize = 32;
		private readonly List<Bitmap> images = [];
		private readonly object imgLock = new(), lookLock = new();
		private readonly FolderItemFilter itemFilter;
		private readonly Dictionary<PIDL, int> lookup = [];
		private readonly ShellFolder? parent = null;
		private int imageSize = defSize;
		private IEnumerable<PIDL>? items = null;
		private CancellationTokenSource? lastCanceler;
		private List<Task> lastRunThreads = [];

		static ShellIconExtractor()
		{
			if (!FileIconInit(false)) FileIconInit(true);
		}

		/// <summary>Initializes a new instance of the <see cref="ShellIconExtractor"/> class to fetch icons for all items in a folder.</summary>
		/// <param name="folder">The folder.</param>
		/// <param name="filter">The filter to determine which child items of the folder are enumerated.</param>
		/// <param name="bmpSize">The width and height of the bitmaps to fetch.</param>
		public ShellIconExtractor(ShellFolder folder,
			FolderItemFilter filter = FolderItemFilter.Folders | FolderItemFilter.NonFolders,
			int bmpSize = defSize)
		{
			parent = folder;
			itemFilter = filter;
			imageSize = bmpSize;
		}

		/// <summary>Initializes a new instance of the <see cref="ShellIconExtractor"/> class.</summary>
		/// <param name="items">The items.</param>
		/// <param name="bmpSize">The width and height of the bitmaps to fetch.</param>
		public ShellIconExtractor(IEnumerable<ShellItem> items, int bmpSize = defSize) :
			this(items.Select(i => i.PIDL), bmpSize)
		{ }

		/// <summary>Initializes a new instance of the <see cref="ShellIconExtractor"/> class.</summary>
		/// <param name="items">The items.</param>
		/// <param name="bmpSize">The width and height of the bitmaps to fetch.</param>
		public ShellIconExtractor(IEnumerable<PIDL> items, int bmpSize = defSize)
		{
			this.items = items.ToArray();
			imageSize = bmpSize;
		}

		/// <summary>Occurs when all icons has been added to <see cref="ImageList"/>.</summary>
		public event EventHandler? Complete;

		/// <summary>Occurs when an updated icon has been added to <see cref="ImageList"/>.</summary>
		public event EventHandler<ShellIconExtractedEventArgs>? IconExtracted;

		/// <summary>Gets the list of all images.</summary>
		/// <value>The list of all images.</value>
		public IReadOnlyList<Bitmap> ImageList => images;

		/// <summary>Gets or sets the width and height of the image.</summary>
		/// <value>The size of the image.</value>
		[DefaultValue(defSize)]
		public int ImageSize
		{
			get => imageSize;
			set
			{
				if (imageSize == value)
					return;
				imageSize = value;
				Refresh();
			}
		}

		/// <summary>Signals the process to end image retrieval.</summary>
		public void Cancel() => lastCanceler?.Cancel();

		/// <summary>Refreshes the list of images.</summary>
		public void Refresh()
		{
			lastCanceler?.Cancel();
			items ??= parent?.IShellFolder.EnumObjects((SHCONTF)itemFilter);

			if (items is not null)
			{
				lock (lookLock) lookup.Clear();
				lock (imgLock) images.Clear();
				lastCanceler = new();
				lastRunThreads = [];

				HRESULT hr;
				foreach (var i in items)
				{
					// Get IShellFolder for item
					var info = new Info(parent?.IShellFolder, i, imageSize, lastCanceler.Token);

					// Try to get the fast icon from IExtractIcon and then IExtractImage
					if ((hr = LoadImageFromImageFactory(info.pidl, ref info.sz, SIIGBF.SIIGBF_INCACHEONLY, out var hbmp)).Succeeded && hbmp != null)
					{
						using (hbmp) AddBmp(hbmp.ToBitmap(), c => { lock (lookLock) lookup.Add(i, c); IconExtracted?.Invoke(this, new(i, c)); }); ;
					}
					else
					{
						// Spin up thread to get the real one
						lastRunThreads.Add(Task.Factory.StartNew(GetImageThread, info, lastCanceler.Token));
					}
				}

				Task.WhenAll(lastRunThreads).ContinueWith(t =>
				{
					if (!t.IsCanceled)
						Complete?.Invoke(this, EventArgs.Empty);
				}, lastCanceler.Token);

				void AddBmp(Bitmap bmp, Action<int>? action = null) { lock (imgLock) images.Add(bmp); action?.Invoke(images.Count - 1); }

				void GetImageThread(object? o)
				{
					var c = (Info)o!;
					if (c.ct.IsCancellationRequested) return;

					try
					{
						var hr = LoadImageFromImageFactory(c.pidl, ref c.sz, 0, out var hbmp);
						if (hr.Failed || c.ct.IsCancellationRequested)
							return;
						AddBmp(hbmp!.ToBitmap(), cnt => { lock (lookLock) lookup[c.pidl] = cnt; IconExtracted?.Invoke(this, new(c.pidl, cnt)); });
					}
					finally
					{
						c.Dispose();
					}
				}
			}
		}

		/// <summary>Starts this instance.</summary>
		public void Start() => Refresh();

		private class Info(IShellFolder? parent, PIDL pidl, int sz, CancellationToken ct) : IDisposable
		{
#if DEBUG
			public readonly string name = pidl.ToString(SIGDN.SIGDN_PARENTRELATIVE);
#endif
			public readonly CancellationToken ct = ct;
			public readonly PIDL pidl = pidl;
			public SIZE sz = new(sz, sz);
			private bool? isDir = null;
			private IShellFolder? isf = parent;

			public bool IsDir => isDir ?? (isDir = IsFolder()).Value;
			public IShellFolder parent => isf ??= SHBindToParent<IShellFolder>(pidl)!;

			public void Dispose() => isf = null;

			private bool IsFolder()
			{
				if (isf is null)
				{
					SHFILEINFO sfi = new() { dwAttributes = (int)SFGAO.SFGAO_FOLDER };
					return SHGetFileInfo(pidl, System.IO.FileAttributes.Directory, ref sfi, SHFILEINFO.Size, SHGFI.SHGFI_ATTRIBUTES | SHGFI.SHGFI_ATTR_SPECIFIED) != IntPtr.Zero && sfi.dwAttributes != 0;
				}
				return (SHGetDataFromIDList<WIN32_FIND_DATA>(isf, pidl, SHGetDataFormat.SHGDFIL_FINDDATA).dwFileAttributes & System.IO.FileAttributes.Directory) != 0;
			}
		}
	}
}