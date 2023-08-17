using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Security;
using static Vanara.PInvoke.Kernel32;
using static Vanara.PInvoke.Macros;
using static Vanara.PInvoke.Shell32;
using static Vanara.PInvoke.User32;

namespace Vanara.Windows.Shell;

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

/// <summary>The type of icon to be returned from <see cref="ShellFileInfo.GetIcon"/>.</summary>
[Flags]
public enum ShellIconType
{
	/// <summary>Retrieve the file's small icon.</summary>
	Small = SHGFI.SHGFI_SMALLICON,

	/// <summary>Retrieve the file's large icon.</summary>
	Large = SHGFI.SHGFI_LARGEICON,

	/// <summary>Retrieve a Shell-sized icon.</summary>
	ShellDefinedSize = SHGFI.SHGFI_SHELLICONSIZE,

	/// <summary>Add the link overlay to the file's icon</summary>
	LinkOverlay = SHGFI.SHGFI_LINKOVERLAY,

	/// <summary>Retrieve the file's open icon.</summary>
	Open = SHGFI.SHGFI_OPENICON,

	/// <summary>Blend the file's icon with the system highlight color.</summary>
	Selected = SHGFI.SHGFI_SELECTED
}

/// <summary>Information and icons for any shell file.</summary>
public class ShellFileInfo : FileSystemInfo
{
	private string _name;

	/// <summary>Initializes a new instance of the ShellFileInfo class, which acts as a wrapper for a file path within the Windows Shell.</summary>
	/// <param name="fileName">The fully qualified name of the new file, or the relative file name.</param>
	public ShellFileInfo(string fileName)
	{
		OriginalPath = fileName;
		FullPath = Path.GetFullPath(fileName);
		SetName(Path.GetFileName(fileName));
		GetInfo();
	}

	/// <summary>Initializes a new instance of the ShellFileInfo class, which acts as a wrapper for a file path within the Windows Shell.</summary>
	/// <param name="pidl">The ID list.</param>
	public ShellFileInfo(PIDL pidl)
	{
		StringBuilder sb = new(MAX_PATH, MAX_PATH);
		if (!SHGetPathFromIDList(pidl, sb)) throw new ArgumentException("Invalid identifier list.");
		OriginalPath = sb.ToString();
		FullPath = sb.ToString();
		SetName(Path.GetFileName(sb.ToString()));
		GetInfo();
	}

	/// <summary>Initializes a new instance of the <see cref="ShellFileInfo"/> class.</summary>
	protected ShellFileInfo() => _name = DisplayName = TypeName = string.Empty;

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

	/// <summary>Gets the icon location for this file.</summary>
	/// <value>The <see cref="IconLocation"/>.</value>
	public IconLocation IconLocation
	{
		get
		{
			SHFILEINFO shfi = new();
			nint ret = SHGetFileInfo(FullPath, 0, ref shfi, SHFILEINFO.Size, SHGFI.SHGFI_ICONLOCATION);
			if (ret == IntPtr.Zero)
			{
				ret = SHGetFileInfo(FullPath, 0, ref shfi, SHFILEINFO.Size, SHGFI.SHGFI_ICONLOCATION | SHGFI.SHGFI_ICON);
				if (ret != IntPtr.Zero) _ = DestroyIcon(shfi.hIcon);
			}
			return ret != IntPtr.Zero ? new IconLocation(shfi.szDisplayName, shfi.iIcon) : new IconLocation();
		}
	}

	/// <summary>Gets the index of the icon overlay.</summary>
	/// <value>The index of the icon overlay, or -1 if no overlay is set.</value>
	public int IconOverlayIndex
	{
		get
		{
			SHFILEINFO shfi = new();
			nint ret = SHGetFileInfo(FullPath, 0, ref shfi, SHFILEINFO.Size, SHGFI.SHGFI_ICON | SHGFI.SHGFI_USEFILEATTRIBUTES | SHGFI.SHGFI_OVERLAYINDEX | SHGFI.SHGFI_LINKOVERLAY);
			if (ret == IntPtr.Zero) return -1;
			_ = DestroyIcon(shfi.hIcon);
			return (shfi.iIcon >> 24) - 1;
		}
	}

	/// <summary>Gets the large icon for the file.</summary>
	public SafeHICON? LargeIcon => GetIcon();

	/// <summary>Gets the size, in bytes, of the current link file.</summary>
	/// <value>The length in bytes of the file.</value>
	public long Length => new FileInfo(FullPath).Length;

	/// <summary>
	/// For files, gets the name of the file. For directories, gets the name of the last directory in the hierarchy if a hierarchy exists.
	/// Otherwise, the Name property gets the name of the directory.
	/// </summary>
	public override string Name => _name;

	// <summary>Gets the size the file requires on disk taking into account NTFS compression.</summary>
	// REQUIRES DEPENDENCY ON Vanara.SystemServices public ulong PhysicalLength =&gt; new FileInfo(FullPath).GetPhysicalLength();

	/// <summary>Gets the shell item attributes.</summary>
	/// <value>The shell item attributes.</value>
	public SFGAO ShellAttributes { get; private set; }

	/// <summary>Gets the small icon for the file.</summary>
	public SafeHICON? SmallIcon => GetIcon(ShellIconType.Small);

	/// <summary>Gets the icon for this shell item from the system.</summary>
	/// <value>The system icon on success; <c>null</c> on failure.</value>
	public SafeHICON? SystemIcon => ShellImageList.GetSystemIcon(FullPath);

	/// <summary>Gets the type name for the file.</summary>
	public string TypeName { get; private set; }

	/// <summary>Permanently deletes the file.</summary>
	public override void Delete() => File.Delete(FullPath);

	/// <summary>Gets the icon defined by the set of flags provided.</summary>
	/// <param name="iconType">Flags to specify type of the icon.</param>
	/// <returns><see cref="SafeHICON"/> if successful; <c>null</c> otherwise.</returns>
	public SafeHICON? GetIcon(ShellIconType iconType = ShellIconType.Large) => ShellImageList.GetFileIcon(FullPath, iconType);

	/// <summary>Returns a <see cref="string"/> that represents this instance.</summary>
	/// <returns>A <see cref="string"/> that represents this instance.</returns>
	public override string ToString() => FullPath;

	/// <summary>Sets the name.</summary>
	/// <param name="name">The name.</param>
	[MemberNotNull(nameof(_name))]
	protected void SetName(string name) => _name = name;

	/// <summary>Gets the information.</summary>
	[MemberNotNull(nameof(DisplayName), nameof(TypeName))]
	private void GetInfo()
	{
		SHFILEINFO shfi = new();

		// Get display name, type, and attributes
		nint ret = SHGetFileInfo(FullPath, 0, ref shfi, SHFILEINFO.Size, SHGFI.SHGFI_DISPLAYNAME | SHGFI.SHGFI_TYPENAME | SHGFI.SHGFI_ATTRIBUTES);
		if (ret != IntPtr.Zero)
		{
			ShellAttributes = (SFGAO)shfi.dwAttributes;
			TypeName = shfi.szTypeName.Clone().ToString()!;
			DisplayName = shfi.szDisplayName.Clone().ToString()!;
		}
		else
		{
			throw new FileLoadException();
		}

		// Get executable type
		ret = SHGetFileInfo(FullPath, 0, ref shfi, SHFILEINFO.Size, SHGFI.SHGFI_EXETYPE);
		ExecutableType = ExecutableType.Nonexecutable;
		if (ret != IntPtr.Zero)
		{
			ushort loWord = LOWORD(ret);
			if (HIWORD(ret) == 0x0000)
			{
				if (loWord == 0x5A4D)
					ExecutableType = ExecutableType.DOS;
				else if (loWord == 0x4550)
					ExecutableType = ExecutableType.Win32Console;
			}
			else if (loWord is 0x454E or 0x4550 or 0x454C)
			{
				ExecutableType = ExecutableType.Windows;
			}
		}
	}
}