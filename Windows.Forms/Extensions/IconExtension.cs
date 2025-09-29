/*
 *  IconExtractor/IconUtil for .NET
 *  Copyright (C) 2014 Tsuda Kageyu. All rights reserved.
 *
 *  Redistribution and use in source and binary forms, with or without
 *  modification, are permitted provided that the following conditions
 *  are met:
 *
 *   1. Redistributions of source code must retain the above copyright
 *      notice, this list of conditions and the following disclaimer.
 *   2. Redistributions in binary form must reproduce the above copyright
 *      notice, this list of conditions and the following disclaimer in the
 *      documentation and/or other materials provided with the distribution.
 *
 *  THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS
 *  "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED
 *  TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A
 *  PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER
 *  OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL,
 *  EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO,
 *  PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR
 *  PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF
 *  LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING
 *  NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS
 *  SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
 */

using System.Drawing;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using System.Windows.Forms;
using Vanara.PInvoke;
using static Vanara.PInvoke.ComCtl32;
using static Vanara.PInvoke.Shell32;
using static Vanara.PInvoke.User32;

namespace Vanara.Extensions;

/// <summary>Used to determine the size of the icon returned by various shell methods.</summary>
public enum IconSize
{
	/// <summary>
	/// The image size is normally 32x32 pixels. However, if the Use large icons option is selected from the Effects section of the Appearance tab in
	/// Display Properties, the image is 48x48 pixels.
	/// </summary>
	Large = SHIL.SHIL_LARGE,
	/// <summary>The image is the Shell standard small icon size of 16x16, but the size can be customized by the user.</summary>
	Small = SHIL.SHIL_SMALL,
	/// <summary>The image is the Shell standard extra-large icon size. This is typically 48x48, but the size can be customized by the user.</summary>
	ExtraLarge = SHIL.SHIL_EXTRALARGE,
	/// <summary>Windows Vista and later. The image is normally 256x256 pixels.</summary>
	Jumbo = SHIL.SHIL_JUMBO
}

/// <summary>Extension methods for <see cref="Icon"/>.</summary>
public static class IconExtension
{
	private delegate byte[] GetIconDataDelegate(Icon icon);
	private static readonly GetIconDataDelegate getIconData;
	private static HIMAGELIST hSystemImageList;

	static IconExtension()
	{
		// Create a dynamic method to access Icon.iconData private field.
		var dm = new DynamicMethod("GetIconData", typeof(byte[]), new[] { typeof(Icon) }, typeof(Icon));
		var fi = typeof(Icon).GetField("iconData", BindingFlags.Instance | BindingFlags.NonPublic);
		var gen = dm.GetILGenerator();
		gen.Emit(OpCodes.Ldarg_0);
		if (fi != null)
			gen.Emit(OpCodes.Ldfld, fi);
		gen.Emit(OpCodes.Ret);
		getIconData = (GetIconDataDelegate)dm.CreateDelegate(typeof(GetIconDataDelegate));
	}

	/// <summary>Gets the bit depth of an Icon.</summary>
	/// <param name="icon">An System.Drawing.Icon object.</param>
	/// <returns>Bit depth of the icon.</returns>
	/// <remarks>This method takes into account the PNG header. If the icon has multiple variations, this method returns the bit depth of the first variation.</remarks>
	public static int GetBitCount(this Icon icon)
	{
		if (icon == null)
			throw new ArgumentNullException(nameof(icon));

		// Get an .ico file in memory, then read the header.
		var data = ToByteArray(icon);
		int idCount = BitConverter.ToInt16(data, 4); // ICONDIR.idCount
		if (idCount < 1 || data.Length < 14)
			throw new ArgumentException(@"The icon is corrupt. Couldn't read the header.", nameof(icon));
		var bColorCount = data[8]; // ICONDIRENTRY.bColorCount
		var wPlanes = BitConverter.ToInt16(data, 10); // ICONDIRENTRY.wPlanes
		var wBitCount = BitConverter.ToInt16(data, 12); // ICONDIRENTRY.wBitCount
		var bits = wPlanes * wBitCount;
		if (bits >= 8 || bColorCount == 0) return bits;
		for (bits = 4; bits > 0 && 1 << bits != bColorCount; bits >>= 1) { }
		return bits;
	}

	/// <summary>Load a full icon from a file. The file must be in the Windows ICO format. It may contain multiple instances of an icon.</summary>
	/// <param name="filename">The filename of the icon file.</param>
	/// <returns>An <see cref="Icon"/> instance.</returns>
	public static Icon IconFromFile(string filename)
	{
		using var fs = File.OpenRead(filename);
		return new Icon(fs);
	}

	/// <summary>Gets the icon associated with this ITEMIDLIST, if one does.</summary>
	/// <param name="pidl">The ITEMIDLIST pointer from which to retrieve the icon.</param>
	/// <param name="iconSize">Size of the icon.</param>
	/// <returns>Icon of the specified size, or <c>null</c> if no icon is associated with this ITEMIDLIST.</returns>
	public static Icon? GetIcon(this PIDL pidl, IconSize iconSize = IconSize.Large)
	{
		if (pidl.IsInvalid) return null;
		var shfi = new SHFILEINFO();
		var ret = SHGetFileInfo(pidl, 0, ref shfi, SHFILEINFO.Size, SHGFI.SHGFI_ICON | SHGFI.SHGFI_PIDL | (SHGFI)iconSize);
		return ret == IntPtr.Zero ? null : new SafeHICON((IntPtr)shfi.hIcon).ToIcon();
	}

	/// <summary>Gets the system icon for the given file name or extension.</summary>
	/// <param name="fileNameOrExtension">The file name or extension.</param>
	/// <param name="iconSize">Size of the icon.</param>
	/// <returns>An <see cref="Icon"/> instance if found; otherwise <see langword="null"/>.</returns>
	public static Icon? GetSystemIcon(string fileNameOrExtension, IconSize iconSize = IconSize.Large)
	{
		var shfi = new SHFILEINFO();
		if (hSystemImageList.IsNull)
			hSystemImageList = SHGetFileInfo(fileNameOrExtension, 0, ref shfi, SHFILEINFO.Size, SHGFI.SHGFI_SYSICONINDEX | (iconSize == IconSize.Small ? SHGFI.SHGFI_SMALLICON : 0));
		if (hSystemImageList.IsNull) return null;
		if (iconSize <= IconSize.Small)
			return ImageList_GetIcon(hSystemImageList, shfi.iIcon, IMAGELISTDRAWFLAGS.ILD_TRANSPARENT).ToIcon();
		SHGetImageList((SHIL)iconSize, out IImageList? il).ThrowIfFailed();
		return il!.GetIcon(shfi.iIcon, IMAGELISTDRAWFLAGS.ILD_TRANSPARENT).ToIcon();
	}

	/// <summary>Gets the Shell icon for the given file name or extension.</summary>
	/// <param name="fileNameOrExtension">The file name or extension .</param>
	/// <param name="iconType">Flags to specify the type of the icon to retrieve. This uses the <see cref="SHGetFileInfo(string, FileAttributes, ref SHFILEINFO, int, SHGFI)"/> method and can only retrieve small or large icons.</param>
	/// <returns>An <see cref="Icon"/> instance if found; otherwise <see langword="null"/>.</returns>
	public static Icon? GetFileIcon(string fileNameOrExtension, IconSize iconType = IconSize.Large)
	{
		var shfi = new SHFILEINFO();
		var ret = SHGetFileInfo(fileNameOrExtension, 0, ref shfi, SHFILEINFO.Size, SHGFI.SHGFI_USEFILEATTRIBUTES | SHGFI.SHGFI_ICON | (SHGFI)iconType);
		if (ret == IntPtr.Zero)
			ret = SHGetFileInfo(fileNameOrExtension, 0, ref shfi, SHFILEINFO.Size, SHGFI.SHGFI_ICON | (SHGFI)iconType);
		return ret == IntPtr.Zero ? null : new SafeHICON((IntPtr)shfi.hIcon).ToIcon();
	}

	/// <summary>Split an Icon consists of multiple icons into an array of Icon each consists of single icons.</summary>
	/// <param name="icon">A System.Drawing.Icon to be split.</param>
	/// <returns>An array of System.Drawing.Icon.</returns>
	public static Icon[] Split(this Icon icon)
	{
		const int sIconDir = 6; // sizeof(ICONDIR) 
		const int sIconDirEntry = 16; // sizeof(ICONDIRENTRY)

		if (icon == null)
			throw new ArgumentNullException(nameof(icon));

		// Get multiple .ico file image.
		var srcBuf = ToByteArray(icon);

		int count = BitConverter.ToInt16(srcBuf, 4); // ICONDIR.idCount
		var splitIcons = new Icon[count];
		for (var i = 0; i < count; i++)
		{
			using var destStream = new MemoryStream();
			using var writer = new BinaryWriter(destStream);
			// Copy ICONDIR and ICONDIRENTRY.
			writer.Write(srcBuf, 0, sIconDir - 2);
			writer.Write((short)1); // ICONDIR.idCount == 1;
			writer.Write(srcBuf, sIconDir + sIconDirEntry * i, sIconDirEntry - 4);
			writer.Write(sIconDir + sIconDirEntry); // ICONDIRENTRY.dwImageOffset = sizeof(ICONDIR) + sizeof(ICONDIRENTRY)

			// Copy picture and mask data.
			var imgSize = BitConverter.ToInt32(srcBuf, sIconDir + sIconDirEntry * i + 8); // ICONDIRENTRY.dwBytesInRes
			var imgOffset = BitConverter.ToInt32(srcBuf, sIconDir + sIconDirEntry * i + 12); // ICONDIRENTRY.dwImageOffset
			writer.Write(srcBuf, imgOffset, imgSize);

			// Create new icon.
			destStream.Seek(0, SeekOrigin.Begin);
			splitIcons[i] = new Icon(destStream);
		}

		return splitIcons;
	}

	/// <summary>Converts this icon to a GDI+ <see cref="Bitmap"/> and preserves any transparency from the source icon.</summary>
	/// <param name="icon">The icon to convert.</param>
	/// <returns>A <see cref="Bitmap"/> that represents the converted <paramref name="icon"/>.</returns>
	public static Bitmap ToAlphaBitmap(this Icon icon)
	{
		if (icon.GetBitCount() < 32) return icon.ToBitmap();
		var il = new ImageList {ColorDepth = ColorDepth.Depth32Bit, ImageSize = icon.Size};
		il.Images.Add(icon);
		return (Bitmap)il.Images[0];
		/*var ii = new ICONINFO();
		if (!GetIconInfo(icon.Handle, ref ii)) throw new Win32Exception();
		var bmp = ii.Bitmap;
		if (Image.GetPixelFormatSize(bmp.PixelFormat) == 32)
		{
			using (var lb = new ExtensionMethods.SmartBitmapLock(bmp))
			{
				if (lb.Any(c => c.A > 0 && c.A < 255))
					return lb.ToBitmap();
			}
		}
		return icon.ToBitmap();*/
	}

	/// <summary>Converts an <see cref="Icon"/> to a byte array.</summary>
	/// <param name="icon">The <see cref="Icon"/> instance.</param>
	/// <returns>The icon expressed as an array of bytes.</returns>
	public static byte[] ToByteArray(this Icon icon)
	{
		var data = getIconData(icon);
		if (data != null)
			return data;
		using var ms = new MemoryStream();
		icon.Save(ms);
		return ms.ToArray();
	}

	/*[StructLayout(LayoutKind.Sequential)]
	public struct GrpIconDir
	{
		private ushort idReserved;
		public ushort idType;
		public ushort idCount;
		[MarshalAs(UnmanagedType.ByValArray)]
		public GrpIconDirEntry[] idEntries;
	}

	[StructLayout(LayoutKind.Sequential)]
	public struct GrpIconDirEntry
	{
		public byte bWidth;          // Width, in pixels, of the image
		public byte bHeight;         // Height, in pixels, of the image
		public byte bColorCount;     // Number of colors in image (0 if >=8bpp)
		public byte bReserved;       // Reserved ( must be 0)
		public ushort wPlanes;       // Color Planes
		public ushort wBitCount;     // Bits per pixel
		public uint dwBytesInRes;    // How many bytes in this resource?
		public ushort nID;           // the ID
	}*/
}