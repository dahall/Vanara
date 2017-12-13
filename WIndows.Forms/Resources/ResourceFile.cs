using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using Vanara.PInvoke;
using static Vanara.PInvoke.Kernel32;
using static Vanara.PInvoke.Shell32;
using static Vanara.PInvoke.User32_Gdi;

namespace Vanara.Resources
{
	public class ResourceFile : IDisposable
	{
		private SafeLibraryHandle hLib;

		public ResourceFile(string filename) : this()
		{
			if (filename == null)
				throw new ArgumentNullException(nameof(filename));

			using (var hm = new SafeLibraryHandle(filename))
				FileName = GetModuleFileName(hm);
			hLib = new SafeLibraryHandle(filename,
				LoadLibraryExFlags.LOAD_LIBRARY_AS_DATAFILE | LoadLibraryExFlags.LOAD_LIBRARY_AS_IMAGE_RESOURCE);
		}

		private ResourceFile()
		{
			Bitmaps = new ImageResIndexer<Bitmap>(GetBitmap);
			GroupIcons = new GroupIconResIndexer(GetGroupIcon);
			Icons = new ImageResIndexer<Icon>(GetIcon);
			Strings = new StringResIndexer(GetString);
		}

		public ImageResIndexer<Bitmap> Bitmaps { get; }

		/// <summary>Gets the name of the file.</summary>
		/// <value>The name of the file.</value>
		public string FileName { get; }

		public GroupIconResIndexer GroupIcons { get; }

		public ImageResIndexer<Icon> Icons { get; }

		public StringResIndexer Strings { get; }

		public static Icon GetResourceGrouoIcon(string resourceReference)
		{
			var parts = GetResourceRefParts(resourceReference);
			using (var nr = new ResourceFile(parts.Item1))
				return nr.GetGroupIcon(parts.Item2);
		}

		public static Icon GetResourceIcon(string resourceReference)
		{
			var parts = GetResourceRefParts(resourceReference);
			IntPtr hIcon = IntPtr.Zero, hSmIcon = IntPtr.Zero;
			SHDefExtractIcon(parts.Item1, parts.Item2, 0, ref hIcon, ref hSmIcon, 0);
			DestroyIcon(hSmIcon);
			var ico = (Icon)Icon.FromHandle(hIcon).Clone();
			DestroyIcon(hIcon);
			return ico;
		}

		public static string GetResourceString(string resourceReference)
		{
			var parts = GetResourceRefParts(resourceReference);
			using (var nr = new ResourceFile(parts.Item1))
				return nr.GetString(parts.Item2);
		}

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
			if (hResInfo == IntPtr.Zero)
				throw new Win32Exception();

			var hResData = LoadResource(hLib, hResInfo);
			if (hResData == IntPtr.Zero)
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

		public IList<SafeResourceId> GetResourceNames(SafeResourceId type) => EnumResourceNames(hLib, type);

		protected virtual Bitmap GetBitmap(SafeResourceId name, Size size)
		{
			var hBmp = LoadImage(hLib, name, LoadImageType.IMAGE_BITMAP, size.Width, size.Height,
				LoadImageOptions.LR_DEFAULTCOLOR);
			if (hBmp == IntPtr.Zero)
				throw new Win32Exception();
			var bmp = (Bitmap)Image.FromHbitmap(hBmp).Clone();
			DestroyIcon(hBmp);
			return bmp;
		}

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

		protected virtual Icon GetIcon(SafeResourceId name, Size size)
		{
			var hIcon = LoadImage(hLib, name, LoadImageType.IMAGE_ICON, size.Width, size.Height,
				LoadImageOptions.LR_LOADTRANSPARENT);
			if (hIcon == IntPtr.Zero)
				throw new Win32Exception();
			var ico = (Icon)Icon.FromHandle(hIcon).Clone();
			DestroyIcon(hIcon);
			return ico;
		}

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

		public class GroupIconResIndexer
		{
			private readonly IndexerGetter getter;
			internal GroupIconResIndexer(IndexerGetter getFn) { getter = getFn; }
			internal delegate Icon IndexerGetter(SafeResourceId name);
			public Icon this[int index] => getter(index);
			public Icon this[string index] => getter(index);
		}

		public class ImageResIndexer<T>
		{
			private readonly IndexerGetter getter;

			internal ImageResIndexer(IndexerGetter getFn) { getter = getFn; }

			internal delegate T IndexerGetter(SafeResourceId name, Size size);
			public T this[int index] => getter(index, default(Size));
			public T this[int index, Size size] => getter(index, size);
			public T this[string index] => getter(index, default(Size));
			public T this[string index, Size size] => getter(index, size);
		}

		public class StringResIndexer
		{
			private readonly IndexerGetter getter;
			internal StringResIndexer(IndexerGetter getFn) { getter = getFn; }
			internal delegate string IndexerGetter(int name);
			public string this[int index] => getter(index);
		}
	}
}