using System;
using System.Drawing;
using System.IO;
using System.Security;
using static Vanara.PInvoke.ComCtl32;
using static Vanara.PInvoke.Macros;
using static Vanara.PInvoke.Shell32;
using static Vanara.PInvoke.User32_Gdi;

namespace Vanara.Windows.Shell
{
	/// <summary>Specifies the executable file type.</summary>
	public enum ExecutableType
	{
		/// <summary>The file executable type is not able to be determined.</summary>
		Nonexecutable = 0,

		/// <summary>The file is an MS-DOS .exe, .com, or .bat file.</summary>
		// ReSharper disable once InconsistentNaming
		DOS,

		/// <summary>The file is a Microsoft Win32®-based console application.</summary>
		Win32Console,

		/// <summary>The file is a Windows application.</summary>
		Windows,
	}

	[Flags]
	public enum ShellIconType
	{
		Small = 1,
		Large = 0,
		ShellDefinedSize = 4,
		LinkOverlay = 0x8000,
		Open = 2,
		Selected = 0x10000,
	}

	/// <summary>Information and icons for any shell file.</summary>
	public class ShellFileInfo : FileSystemInfo
	{
		private string name;

		/// <summary>
		/// Initializes a new instance of the ShellFileInfo class, which acts as a wrapper for a file path within the
		/// Windows Shell.
		/// </summary>
		/// <param name="fileName">The fully qualified name of the new file, or the relative file name.</param>
		public ShellFileInfo(string fileName)
		{
			OriginalPath = fileName;
			FullPath = Path.GetFullPath(fileName);
			SetName(Path.GetFileName(fileName));
			GetInfo();
		}

		protected ShellFileInfo() { }

		/// <summary>Gets the display name for the file.</summary>
		public string DisplayName { get; private set; }

		/// <summary>Gets the executable type of the file.</summary>
		public ExecutableType ExecutableType { get; private set; }

		/// <summary>Gets a value indicating whether the file or directory exists.</summary>
		public override bool Exists
		{
			[SecuritySafeCritical]
			get { try { return ((int)Attributes & 0x10) == 0; } catch { return false; } }
		}

		/// <summary>Gets the name of the file that contains the icon representing this shell item.</summary>
		/// <value>The icon file path, or <c>null</c> if no icon is defined.</value>
		public string IconFilePath
		{
			get
			{
				var shfi = new SHFILEINFO();
				var ret = SHGetFileInfo(FullPath, 0, ref shfi, SHFILEINFO.Size, SHGFI.SHGFI_ICONLOCATION);
				if (ret == IntPtr.Zero)
				{
					ret = SHGetFileInfo(FullPath, 0, ref shfi, SHFILEINFO.Size, SHGFI.SHGFI_ICONLOCATION | SHGFI.SHGFI_ICON);
					if (ret != IntPtr.Zero) DestroyIcon(shfi.hIcon);
				}
				return ret != IntPtr.Zero ? shfi.szDisplayName : null;
			}
		}

		/// <summary>Gets the large icon for the file.</summary>
		public Icon LargeIcon => GetIcon();

		/// <summary>Gets the size, in bytes, of the current link file.</summary>
		/// <value>The length in bytes of the file.</value>
		public long Length => new FileInfo(FullPath).Length;

		/// <summary>
		/// For files, gets the name of the file. For directories, gets the name of the last directory in the hierarchy if a hierarchy exists. Otherwise, the Name property gets the name of the directory.
		/// </summary>
		public override string Name => name;

		/// <summary>Gets the index of the icon overlay.</summary>
		/// <value>The index of the icon overlay, or -1 if no overlay is set.</value>
		public int IconOverlayIndex
		{
			get
			{
				var shfi = new SHFILEINFO();
				var ret = SHGetFileInfo(FullPath, 0, ref shfi, SHFILEINFO.Size, SHGFI.SHGFI_ICON | SHGFI.SHGFI_USEFILEATTRIBUTES | SHGFI.SHGFI_OVERLAYINDEX | SHGFI.SHGFI_LINKOVERLAY);
				if (ret == IntPtr.Zero) return -1;
				DestroyIcon(shfi.hIcon);
				return (shfi.iIcon >> 24) - 1;
			}
		}

		/// <summary>Gets the size the file requires on disk taking into account NTFS compression.</summary>
		// REQUIRES DEPENDENCY ON Vanara.SystemServices
		//public ulong PhysicalLength => new FileInfo(FullPath).GetPhysicalLength();

		public ShellItemAttribute ShellAttributes { get; private set; }

		/// <summary>Gets the small icon for the file.</summary>
		public Icon SmallIcon => GetIcon(ShellIconType.Small);

		/// <summary>Gets the icon for this shell item from the system.</summary>
		/// <value>The system icon on success; <c>null</c> on failure.</value>
		public Icon SystemIcon
		{
			get
			{
				var shfi = new SHFILEINFO();
				var hImageList = SHGetFileInfo(FullPath, 0, ref shfi, SHFILEINFO.Size, SHGFI.SHGFI_SYSICONINDEX);
				if (hImageList == IntPtr.Zero) return null;
				var hIcon = ImageList_GetIcon(hImageList, shfi.iIcon, IMAGELISTDRAWFLAGS.ILD_NORMAL);
				return GetClonedIcon(hIcon);
			}
		}

		/// <summary>Gets the type name for the file.</summary>
		public string TypeName { get; private set; }

		/// <summary>Permanently deletes the file.</summary>
		public override void Delete() { File.Delete(FullPath); }

		/// <summary>
		/// Gets the icon defined by the set of flags provided.
		/// </summary>
		/// <param name="iconType">Flags to specify type of the icon.</param>
		/// <returns><see cref="Icon"/> if successful; <c>null</c> otherwise.</returns>
		public Icon GetIcon(ShellIconType iconType = ShellIconType.Large)
		{
			const SHGFI baseFlags = SHGFI.SHGFI_USEFILEATTRIBUTES | SHGFI.SHGFI_ICON;
			var shfi = new SHFILEINFO();
			var ret = SHGetFileInfo(FullPath, 0, ref shfi, SHFILEINFO.Size, baseFlags | (SHGFI)iconType);
			if (ret == IntPtr.Zero)
				ret = SHGetFileInfo(FullPath, 0, ref shfi, SHFILEINFO.Size, SHGFI.SHGFI_ICON | (SHGFI)iconType);
			return ret == IntPtr.Zero ? null : GetClonedIcon(shfi.hIcon);
		}

		/// <summary>Returns a <see cref="System.String"/> that represents this instance.</summary>
		/// <returns>A <see cref="System.String"/> that represents this instance.</returns>
		public override string ToString() => FullPath;

		/// <summary>Gets the information.</summary>
		private void GetInfo()
		{
			var shfi = new SHFILEINFO();

			// Get display name, type, and attributes
			var ret = SHGetFileInfo(FullPath, 0, ref shfi, SHFILEINFO.Size, SHGFI.SHGFI_DISPLAYNAME | SHGFI.SHGFI_TYPENAME | SHGFI.SHGFI_ATTRIBUTES);
			if (ret != IntPtr.Zero)
			{
				ShellAttributes = (ShellItemAttribute)shfi.dwAttributes;
				TypeName = shfi.szTypeName.Clone().ToString();
				DisplayName = shfi.szDisplayName.Clone().ToString();
			}
			else
				throw new FileLoadException();

			// Get executable type
			ret = SHGetFileInfo(FullPath, 0, ref shfi, SHFILEINFO.Size, SHGFI.SHGFI_EXETYPE);
			ExecutableType = ExecutableType.Nonexecutable;
			if (ret != IntPtr.Zero)
			{
				var loWord = LOWORD(ret);
				if (HIWORD(ret) == 0x0000)
				{
					if (loWord == 0x5A4D)
						ExecutableType = ExecutableType.DOS;
					else if (loWord == 0x4550)
						ExecutableType = ExecutableType.Win32Console;
				}
				else if (loWord == 0x454E || loWord == 0x4550 || loWord == 0x454C)
					ExecutableType = ExecutableType.Windows;
			}
		}

		/// <summary>Gets an <see cref="Icon"/> from an icon handle.</summary>
		/// <param name="hIcon">The icon handle.</param>
		/// <returns>An <see cref="Icon"/> instance.</returns>
		protected static Icon GetClonedIcon(IntPtr hIcon)
		{
			if (hIcon == IntPtr.Zero) return null;
			var icon = (Icon)Icon.FromHandle(hIcon).Clone();
			DestroyIcon(hIcon);
			return icon;
		}

		/// <summary>Sets the name.</summary>
		/// <param name="name">The name.</param>
		protected void SetName(string name) { this.name = name; }
	}
}