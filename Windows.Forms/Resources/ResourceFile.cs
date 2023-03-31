using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using Vanara.PInvoke;
using static Vanara.PInvoke.Gdi32;
using static Vanara.PInvoke.Kernel32;
using static Vanara.PInvoke.Shell32;
using static Vanara.PInvoke.User32;

namespace Vanara.Resources;

/// <summary>Represents a file that contains resources.</summary>
/// <seealso cref="System.IDisposable"/>
public class ResourceFile : IDisposable
{
	private SafeHINSTANCE hLib;

	/// <summary>Initializes a new instance of the <see cref="ResourceFile"/> class.</summary>
	/// <param name="filename">The filename.</param>
	/// <exception cref="System.ArgumentNullException">filename</exception>
	public ResourceFile(string filename) : this()
	{
		if (filename == null)
			throw new ArgumentNullException(nameof(filename));

		using (var hm = LoadLibraryEx(filename))
			FileName = GetModuleFileName(hm);
		hLib = LoadLibraryEx(filename, IntPtr.Zero, LoadLibraryExFlags.LOAD_LIBRARY_AS_DATAFILE | LoadLibraryExFlags.LOAD_LIBRARY_AS_IMAGE_RESOURCE);
	}

	private ResourceFile()
	{
		Bitmaps = new ImageResIndexer<Bitmap>(GetBitmap);
		GroupIcons = new GroupIconResIndexer(GetGroupIcon);
		Icons = new ImageResIndexer<Icon>(GetIcon);
		Strings = new StringResIndexer(GetString);
	}

	/// <summary>Gets the bitmaps.</summary>
	/// <value>The bitmaps.</value>
	public ImageResIndexer<Bitmap> Bitmaps { get; }

	/// <summary>Gets the name of the file.</summary>
	/// <value>The name of the file.</value>
	public string FileName { get; }

	/// <summary>Gets the group icons.</summary>
	/// <value>The group icons.</value>
	public GroupIconResIndexer GroupIcons { get; }

	/// <summary>Gets the icons.</summary>
	/// <value>The icons.</value>
	public ImageResIndexer<Icon> Icons { get; }

	/// <summary>Gets the strings.</summary>
	/// <value>The strings.</value>
	public StringResIndexer Strings { get; }

	/// <summary>Gets the resource grouo icon.</summary>
	/// <param name="resourceReference">The resource reference.</param>
	/// <returns></returns>
	public static Icon GetResourceGrouoIcon(string resourceReference)
	{
		var parts = GetResourceRefParts(resourceReference);
		using (var nr = new ResourceFile(parts.Item1))
			return nr.GetGroupIcon(parts.Item2);
	}

	/// <summary>Gets the resource icon.</summary>
	/// <param name="resourceReference">The resource reference.</param>
	/// <returns></returns>
	public static Icon GetResourceIcon(string resourceReference)
	{
		var parts = GetResourceRefParts(resourceReference);
		SHDefExtractIcon(parts.Item1, parts.Item2, 0, out var hIcon, out var _, 0).ThrowIfFailed();
		return hIcon.ToIcon();
	}

	/// <summary>Gets the resource string.</summary>
	/// <param name="resourceReference">The resource reference.</param>
	/// <returns></returns>
	public static string GetResourceString(string resourceReference)
	{
		var parts = GetResourceRefParts(resourceReference);
		using (var nr = new ResourceFile(parts.Item1))
			return nr.GetString(parts.Item2);
	}

	/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
	public void Dispose()
	{
		hLib = null;
	}

	/// <summary>Get binary image of the specified resource.</summary>
	/// <param name="name">The resource name.</param>
	/// <param name="resourceType">Type of the resource.</param>
	/// <returns>Binary image of the resource.</returns>
	public byte[] GetResourceData(SafeResourceId name, ResourceType resourceType)
	{
		// Get binary image of the specified resource.

		var hResInfo = FindResource(hLib, name, resourceType);
		if (hResInfo.IsNull)
			throw new Win32Exception();

		var hResData = LoadResource(hLib, hResInfo);
		if (hResData.IsNull)
			throw new Win32Exception();

		var hGlobal = LockResource(hResData);
		if (hGlobal == IntPtr.Zero)
			throw new Win32Exception();

		var resSize = SizeofResource(hLib, hResInfo);
		if (resSize == 0)
			throw new Win32Exception();

		var buf = new byte[resSize];
		Marshal.Copy(hGlobal, buf, 0, buf.Length);
		return buf;
	}

	/// <summary>Gets the resource names.</summary>
	/// <param name="type">The type.</param>
	/// <returns></returns>
	public IList<ResourceId> GetResourceNames(SafeResourceId type) => EnumResourceNamesEx(hLib, type);

	/// <summary>Gets the bitmap.</summary>
	/// <param name="name">The name.</param>
	/// <param name="size">The size.</param>
	/// <returns></returns>
	/// <exception cref="Win32Exception"></exception>
	protected virtual Bitmap GetBitmap(SafeResourceId name, Size size)
	{
		var hBmp = new SafeHBITMAP(LoadImage(hLib, name, LoadImageType.IMAGE_BITMAP, size.Width, size.Height, LoadImageOptions.LR_DEFAULTCOLOR));
		return !hBmp.IsNull ? hBmp.ToBitmap() : throw new Win32Exception();
	}

	/// <summary>Gets the group icon.</summary>
	/// <param name="name">The name.</param>
	/// <returns></returns>
	protected virtual Icon GetGroupIcon(SafeResourceId name)
	{
		const int szGrpIconDirEntry = 14; // sizeof(GRPICONDIRENTRY)
		const int sIconDir = 6; // sizeof(ICONDIR)
		const int sIconDirEntry = 16; // sizeof(ICONDIRENTRY)

		var srcBuf = GetResourceData(name, ResourceType.RT_GROUP_ICON);

		// Convert the resource into an .ico file image.
		using (var destStream = new MemoryStream())
		using (var writer = new BinaryWriter(destStream))
		{
			int count = BitConverter.ToUInt16(srcBuf, 4); // ICONDIR.idCount
			var imgOffset = sIconDir + sIconDirEntry * count;

			// Copy ICONDIR.
			writer.Write(srcBuf, 0, sIconDir);

			for (var i = 0; i < count; i++)
			{
				// Copy GRPICONDIRENTRY converting into ICONDIRENTRY.
				writer.BaseStream.Seek(sIconDir + sIconDirEntry * i, SeekOrigin.Begin);
				writer.Write(srcBuf, sIconDir + szGrpIconDirEntry * i, sIconDirEntry - 4); // Common fields of structures
				writer.Write(imgOffset); // ICONDIRENTRY.dwImageOffset

				// Get picture and mask data, then copy them.
				var nId = BitConverter.ToUInt16(srcBuf, sIconDir + szGrpIconDirEntry * i + 12); // GRPICONDIRENTRY.nID
				var imgBuf = GetResourceData(nId, ResourceType.RT_ICON);

				writer.BaseStream.Seek(imgOffset, SeekOrigin.Begin);
				writer.Write(imgBuf, 0, imgBuf.Length);

				imgOffset += imgBuf.Length;
			}

			destStream.Seek(0, SeekOrigin.Begin);
			return new Icon(destStream);
		}
	}

	/// <summary>Gets the icon.</summary>
	/// <param name="name">The name.</param>
	/// <param name="size">The size.</param>
	/// <returns></returns>
	/// <exception cref="Win32Exception"></exception>
	protected virtual Icon GetIcon(SafeResourceId name, Size size)
	{
		var hIcon = new SafeHICON(LoadImage(hLib, name, LoadImageType.IMAGE_ICON, size.Width, size.Height, LoadImageOptions.LR_LOADTRANSPARENT));
		return !hIcon.IsNull ? hIcon.ToIcon() : throw new Win32Exception();
	}

	/// <summary>Gets the string.</summary>
	/// <param name="id">The identifier.</param>
	/// <returns></returns>
	protected virtual string GetString(int id)
	{
		var sb = new System.Text.StringBuilder(260);
		var len = LoadString(hLib, id, sb, 260);
		return len == 0 ? null : sb.ToString();
	}

	private static Tuple<string, int> GetResourceRefParts(string resourceReference)
	{
		var parts = resourceReference.Split(',');
		if (parts.Length != 2)
			throw new ArgumentException(@"Invalid string format.", nameof(resourceReference));
		int id;
		if (!int.TryParse(parts[1], out id))
			throw new ArgumentException(@"Invalid resource identifier.", nameof(resourceReference));
		var fn = parts[0];
		try
		{
			fn = Environment.ExpandEnvironmentVariables(fn);
		}
		catch (Exception ex)
		{
			throw new ArgumentException(@"Invalid file name part.", nameof(resourceReference), ex);
		}
		return new Tuple<string, int>(fn, id);
	}

	/// <summary>An indexer for group icons.</summary>
	public class GroupIconResIndexer
	{
		private readonly IndexerGetter getter;

		internal GroupIconResIndexer(IndexerGetter getFn)
		{
			getter = getFn;
		}

		internal delegate Icon IndexerGetter(SafeResourceId name);

		/// <summary>Gets the <see cref="Icon"/> at the specified index.</summary>
		/// <value>The <see cref="Icon"/>.</value>
		/// <param name="index">The index.</param>
		/// <returns></returns>
		public Icon this[int index] => getter(index);

		/// <summary>Gets the <see cref="Icon"/> at the specified index.</summary>
		/// <value>The <see cref="Icon"/>.</value>
		/// <param name="index">The index.</param>
		/// <returns></returns>
		public Icon this[string index] => getter(index);
	}

	/// <summary>An indexer for images.</summary>
	/// <typeparam name="T"></typeparam>
	public class ImageResIndexer<T>
	{
		private readonly IndexerGetter getter;

		internal ImageResIndexer(IndexerGetter getFn)
		{
			getter = getFn;
		}

		internal delegate T IndexerGetter(SafeResourceId name, Size size);

		/// <summary>Gets the <typeparamref name="T"/> at the specified index.</summary>
		/// <value>The <typeparamref name="T"/>.</value>
		/// <param name="index">The index.</param>
		/// <returns></returns>
		public T this[int index] => getter(index, default);

		/// <summary>Gets the <typeparamref name="T"/> at the specified index.</summary>
		/// <value>The <typeparamref name="T"/>.</value>
		/// <param name="index">The index.</param>
		/// <param name="size">The size.</param>
		/// <returns></returns>
		public T this[int index, Size size] => getter(index, size);

		/// <summary>Gets the <typeparamref name="T"/> at the specified index.</summary>
		/// <value>The <typeparamref name="T"/>.</value>
		/// <param name="index">The index.</param>
		/// <returns></returns>
		public T this[string index] => getter(index, default);

		/// <summary>Gets the <typeparamref name="T"/> at the specified index.</summary>
		/// <value>The <typeparamref name="T"/>.</value>
		/// <param name="index">The index.</param>
		/// <param name="size">The size.</param>
		/// <returns></returns>
		public T this[string index, Size size] => getter(index, size);
	}

	/// <summary>An indexer for strings.</summary>
	public class StringResIndexer
	{
		private readonly IndexerGetter getter;

		internal StringResIndexer(IndexerGetter getFn)
		{
			getter = getFn;
		}

		internal delegate string IndexerGetter(int name);

		/// <summary>Gets the <see cref="System.String"/> at the specified index.</summary>
		/// <value>The <see cref="System.String"/>.</value>
		/// <param name="index">The index.</param>
		/// <returns></returns>
		public string this[int index] => getter(index);
	}
}