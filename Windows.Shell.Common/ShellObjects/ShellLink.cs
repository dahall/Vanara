using System;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Security.AccessControl;
using System.Security.Permissions;
using Vanara.Extensions;
using Vanara.InteropServices;
using Vanara.PInvoke;
using static Vanara.PInvoke.Kernel32;
using static Vanara.PInvoke.Macros;
using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.Shell32;
using static Vanara.PInvoke.User32;

namespace Vanara.Windows.Shell;

/// <summary>Flags determining how the links with missing targets are resolved.</summary>
[Flags]
public enum LinkResolution : uint
{
	/// <summary>No flags set.</summary>
	None = 0,

	/// <summary>
	/// Do not display a dialog box if the link cannot be resolved. When NoUI is set, a time-out value that specifies the maximum amount
	/// of time to be spent resolving the link can be specified in milliseconds. The function returns if the link cannot be resolved
	/// within the time-out duration. If the timeout is not set, the time-out duration will be set to the default value of 3,000
	/// milliseconds (3 seconds).
	/// </summary>
	NoUI = 0x1,

	/// <summary>Allow any match during resolution. Has no effect on ME/2000 or above, use the other flags instead.</summary>
	AnyMatch = 0x2,

	/// <summary>
	/// If the link object has changed, update its path and list of identifiers. If UPDATE is set, you do not need to call
	/// IPersistFile::IsDirty to determine whether or not the link object has changed.
	/// </summary>
	Update = 0x4,

	/// <summary>Do not update the link information.</summary>
	NoUpdate = 0x8,

	/// <summary>Do not execute the search heuristics.</summary>
	NoSearch = 0x10,

	/// <summary>Do not use distributed link tracking.</summary>
	NoTrack = 0x20,

	/// <summary>
	/// Disable distributed link tracking. By default, distributed link tracking tracks removable media across multiple devices based on
	/// the volume name. It also uses the UNC path to track remote file systems whose drive letter has changed. Setting NoLinkInfo
	/// disables both types of tracking.
	/// </summary>
	NoLinkInfo = 0x40,

	/// <summary>Call the Microsoft Windows Installer.</summary>
	InvokeMSI = 0x80,

	/// <summary>Windows XP and later. Assume same as NoUI but intended for applications without a hWnd.</summary>
	NoUIWithMsgPump = 0x101,

	/// <summary>
	/// Windows 7 and later. Offer the option to delete the shortcut when this method is unable to resolve it, even if the shortcut is
	/// not a shortcut to a file.
	/// </summary>
	OfferDeleteWithoutFile = 0x200,

	/// <summary>
	/// Windows 7 and later. Report as dirty if the target is a known folder and the known folder was redirected. This only works if the
	/// original target path was a file system path or ID list and not an aliased known folder ID list.
	/// </summary>
	KnownFolder = 0x400,

	/// <summary>
	/// Windows 7 and later. Resolve the computer name in UNC targets that point to a local computer. This value is used with SLDFKEEPLOCALIDLISTFORUNCTARGET.
	/// </summary>
	MachineInLocalTarget = 0x800,

	/// <summary>Windows 7 and later. Update the computer GUID and user SID if necessary.</summary>
	UpdateMachineAndSid = 0x1000,

	/// <summary>?? Assuming this does not update the Object ID</summary>
	NoObjectID = 0x2000
}

/// <summary>Represents a Shell Shortcut (.lnk) file.</summary>
public sealed class ShellLink : ShellItem, IEquatable<IShellLinkW>, IEquatable<ShellLink>
{
	internal IShellLinkW link;

	/// <summary>Initializes a new instance of the <see cref="ShellLink"/> class, which acts as a wrapper for a .lnk file.</summary>
	/// <param name="linkFile">The shortcut file (.lnk) to load.</param>
	/// <param name="window">
	/// The window that the Shell will use as the parent for a dialog box. The Shell displays the dialog box if it needs to prompt the
	/// user for more information while resolving a Shell link.
	/// </param>
	/// <param name="resolveFlags">The resolve flags.</param>
	/// <param name="timeOut">The time out.</param>
	/// <exception cref="System.ArgumentNullException">linkFile</exception>
	public ShellLink(string linkFile, LinkResolution resolveFlags = LinkResolution.NoUI, HWND window = default, TimeSpan timeOut = default) : base(linkFile) =>
		LoadAndResolve(linkFile, (SLR_FLAGS)resolveFlags, window, (ushort)timeOut.TotalMilliseconds);

	/// <summary>
	/// Initializes a new instance of the <see cref="ShellLink"/> class and sets many properties. This link is not saved as a file.
	/// </summary>
	/// <param name="targetFilename">The full path to the target file.</param>
	/// <param name="arguments">The arguments for the target's execution.</param>
	/// <param name="workingDirectory">The working directory for the execution of the target.</param>
	/// <param name="description">The description of the link.</param>
	public ShellLink(string targetFilename, string arguments, string workingDirectory = null, string description = null) : this()
	{
		TargetPath = targetFilename;
		Description = description;
		WorkingDirectory = workingDirectory;
		Arguments = arguments;
		// TODO: Determine if IShellItem is required. => Init(null);
	}

	internal ShellLink(IShellItem iItem) => LoadAndResolve(iItem.GetDisplayName(SIGDN.SIGDN_FILESYSPATH), SLR_FLAGS.SLR_NO_UI);

	private ShellLink() => link = new IShellLinkW();

	/// <summary>Gets/sets any command line arguments associated with the link</summary>
	public string Arguments
	{
		get => GetStringValue(link.GetArguments, MAX_PATH);
		set { link.SetArguments(value); Save(); }
	}

	/// <summary>Gets the current option settings.</summary>
	/// <value>One or more of the SHELL_LINK_DATA_FLAGS that indicate the current option settings.</value>
	public SHELL_LINK_DATA_FLAGS DataFlags
	{
		get => ((IShellLinkDataList)link).GetFlags();
		set { ((IShellLinkDataList)link).SetFlags(value); Save(); }
	}

	/// <summary>Gets/sets the description of the link</summary>
	public string Description
	{
		get => GetStringValue(link.GetDescription, ComCtl32.INFOTIPSIZE);
		set { link.SetDescription(value); Save(); }
	}

	/// <summary>Gets/sets the HotKey to start the shortcut (if any).</summary>
	/// <value>
	/// <para>
	/// The keyboard shortcut. The virtual key code is in the low-order byte, and the modifier flags are in the high-order byte. The
	/// modifier flags can be a combination of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>HOTKEYF_ALT</c> 0x04</term>
	/// <term>ALT key</term>
	/// </item>
	/// <item>
	/// <term><c>HOTKEYF_CONTROL</c> 0x02</term>
	/// <term>CTRL key</term>
	/// </item>
	/// <item>
	/// <term><c>HOTKEYF_EXT</c> 0x08</term>
	/// <term>Extended key</term>
	/// </item>
	/// <item>
	/// <term><c>HOTKEYF_SHIFT</c> 0x01</term>
	/// <term>SHIFT key</term>
	/// </item>
	/// </list>
	/// </value>
	public ushort HotKey
	{
		get => link.GetHotKey();
		set { link.SetHotKey(value); Save(); }
	}

	/// <summary>Gets the index of this icon within the icon path's resources.</summary>
	public IconLocation IconLocation
	{
		get
		{
			var iconIndex = 0;
			try { return new IconLocation(GetStringValue((sb, l) => link.GetIconLocation(sb, l, out iconIndex)), iconIndex); }
			catch { return null; }
		}

		set { link.SetIconLocation(value.ModuleFileName, value.ResourceId); Save(); }
	}

	/// <summary>Get or sets the list of item identifiers for a Shell link.</summary>
	public PIDL IDList
	{
		get => link.GetIDList();
		set { link.SetIDList(value); Save(); }
	}

	/// <summary>Gets a value indicating whether this instance is link.</summary>
	/// <value><c>true</c> if this instance is link; otherwise, <c>false</c>.</value>
	public override bool IsLink => true;

	/// <summary>Gets/sets the relative path to the link's target</summary>
	public string RelativeTargetPath
	{
		get => GetPath(SLGP.SLGP_RELATIVEPRIORITY);
		set { link.SetRelativePath(value); Save(); }
	}

	/// <summary>Gets or sets a value indicating whether the target is run with Administrator rights.</summary>
	/// <value><c>true</c> if run as Administrator; otherwise, <c>false</c>.</value>
	public bool RunAsAdministrator
	{
		get => DataFlags.IsFlagSet(SHELL_LINK_DATA_FLAGS.SLDF_RUNAS_USER);
		set
		{
			var pdl = (IShellLinkDataList)link;
			pdl.SetFlags(pdl.GetFlags().SetFlags(SHELL_LINK_DATA_FLAGS.SLDF_RUNAS_USER, value));
			Save();
		}
	}

	/// <summary>Gets/sets the short (8.3 format) path to the link's target</summary>
	public string ShortTargetPath => GetPath(SLGP.SLGP_SHORTPATH);

	/// <summary>Gets or sets the show command for a Shell link object.</summary>
	/// <value>The show command for a Shell link object.</value>
	public ShowWindowCommand ShowState
	{
		get => link.GetShowCmd();
		set { link.SetShowCmd(value); Save(); }
	}

	/// <summary>Gets or sets the target with a <see cref="ShellItem"/> instance.</summary>
	public ShellItem Target
	{
		get => TargetPath is null ? null : new ShellItem(TargetPath);
		set { link.SetIDList(value.PIDL); Save(); }
	}

	/// <summary>Gets/sets the fully qualified path to the link's target</summary>
	public string TargetPath
	{
		get => GetPath(SLGP.SLGP_RAWPATH);
		set { link.SetPath(value); Save(); }
	}

	/// <summary>Gets/sets the display name of the link through the PKEY_Title property.</summary>
	public string Title
	{
		get => (string)Properties[PROPERTYKEY.System.Title];
		set { Properties[PROPERTYKEY.System.Title] = value; Properties.Commit(); Save(); }
	}

	/// <summary>Gets/sets the Working Directory for the Link</summary>
	public string WorkingDirectory
	{
		get => GetStringValue(link.GetWorkingDirectory, MAX_PATH);
		set { link.SetWorkingDirectory(value); Save(); }
	}

	/// <summary>Creates or overwrites a new link file.</summary>
	/// <param name="linkFilename">The link filename.</param>
	/// <param name="targetFilename">The full path to the target file.</param>
	/// <param name="description">The description of the link.</param>
	/// <param name="workingDirectory">The working directory for the execution of the target.</param>
	/// <param name="arguments">The arguments for the target's execution.</param>
	/// <returns>An instance of a <see cref="ShellLink"/> representing the values supplied.</returns>
	public static ShellLink Create(string linkFilename, string targetFilename, string description = null, string workingDirectory = null, string arguments = null)
	{
		if (File.Exists(linkFilename)) throw new InvalidOperationException("File already exists.");
		var lnk = new ShellLink(targetFilename, arguments, workingDirectory, description);
		lnk.SaveAs(linkFilename);
		return lnk;
	}

	/// <summary>Creates or overwrites a new link file.</summary>
	/// <param name="linkFilename">The link filename.</param>
	/// <param name="target">The ShellItem for the target.</param>
	/// <param name="description">The description of the link.</param>
	/// <param name="workingDirectory">The working directory for the execution of the target.</param>
	/// <param name="arguments">The arguments for the target's execution.</param>
	/// <returns>An instance of a <see cref="ShellLink"/> representing the values supplied.</returns>
	public static ShellLink Create(string linkFilename, ShellItem target, string description = null, string workingDirectory = null, string arguments = null)
	{
		if (File.Exists(linkFilename)) throw new InvalidOperationException("File already exists.");
		var lnk = new ShellLink
		{
			link = new IShellLinkW(),
			Target = target,
			Description = description,
			WorkingDirectory = workingDirectory,
			Arguments = arguments
		};
		lnk.SaveAs(linkFilename);
		lnk.Init(SHCreateItemFromParsingName<IShellItem>(Path.GetFullPath(linkFilename)));
		return lnk;
	}

	/// <summary>Copies an existing file to a new file, allowing the overwriting of an existing file.</summary>
	/// <param name="destShellLink">The name of the new file to copy to.</param>
	/// <param name="overwrite"><c>true</c> to allow an existing file to be overwritten; otherwise <c>false</c>.</param>
	/// <returns>
	/// A new file, or an overwrite of an existing file if overwrite is true. If the file exists and overwrite is false, an IOException
	/// is thrown.
	/// </returns>
	public ShellLink CopyTo(string destShellLink, bool overwrite = false)
	{
		File.Copy(FileSystemPath, destShellLink, overwrite);
		return new ShellLink(destShellLink);
	}

	/// <summary>Dispose the object, releasing the COM ShellLink object</summary>
	public override void Dispose()
	{
		link = null;
		//Release(link);
		base.Dispose();
	}

	/// <summary>Determines whether the specified <see cref="object"/>, is equal to this instance.</summary>
	/// <param name="obj">The <see cref="object"/> to compare with this instance.</param>
	/// <returns><see langword="true"/> if the specified <see cref="object"/> is equal to this instance; otherwise, <see langword="false"/>.</returns>
	public override bool Equals(object obj) => obj switch
	{
		ShellLink sl => Equals(sl),
		IShellLinkW isl => Equals(isl),
		_ => base.Equals(obj),
	};

	/// <summary>
	/// Gets a FileSecurity object that encapsulates the specified type of access control list (ACL) entries for the file described by
	/// the current FileInfo object.
	/// </summary>
	/// <param name="includeSections">
	/// One of the AccessControlSections values that specifies which group of access control entries to retrieve.
	/// </param>
	/// <returns>A FileSecurity object that encapsulates the access control rules for the current file.</returns>
	public FileSecurity GetAccessControl(AccessControlSections includeSections = AccessControlSections.Access | AccessControlSections.Group | AccessControlSections.Owner) =>
		new(FileSystemPath, includeSections);

	/// <summary>Returns a hash code for this instance.</summary>
	/// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
	public override int GetHashCode() => ToString().GetHashCode();

	/// <summary>Gets the icon for this link file.</summary>
	/// <param name="large">if set to <c>true</c> retrieve the large icon; other retrieve the small icon.</param>
	/// <returns>The icon.</returns>
	public SafeHICON GetIcon(bool large)
	{
		var loc = IconLocation;
		if (loc.IsValid) return loc.Icon;

		// If there are no details set for the icon, then we must use the shell to get the icon for the target
		var sfi = new ShellFileInfo(TargetPath);
		return large ? sfi.LargeIcon : sfi.SmallIcon;
	}

	/// <summary>
	/// Applies access control list (ACL) entries described by a FileSecurity object to the file described by the current FileInfo object.
	/// </summary>
	/// <param name="fileSecurity">
	/// A FileSecurity object that describes an access control list (ACL) entry to apply to the current file.
	/// </param>
	public void SetAccessControl(FileSecurity fileSecurity) => new FileInfo(FileSystemPath).SetAccessControl(fileSecurity);

	/// <summary>Returns a <see cref="System.String"/> that represents this instance.</summary>
	/// <returns>A <see cref="System.String"/> that represents this instance.</returns>
	// Path and title should be case insensitive. Shell treats arguments as case sensitive because apps can handle those differently.
	public override string ToString() =>
		$"{Title?.ToUpperInvariant() ?? ""} {TargetPath.ToUpperInvariant()} {Arguments}";

	private string GetPath(SLGP value) => GetStringValue((sb, l) => link.GetPath(sb, l, out _, value));

	private void InitBaseFromPath(string linkFilename) => Init(SHCreateItemFromParsingName<IShellItem>(Path.GetFullPath(linkFilename)));

	private void LoadAndResolve(string linkFile, SLR_FLAGS resolveFlags, HWND hWin = default, ushort timeOut = 0)
	{
		var fullPath = Path.GetFullPath(linkFile ?? throw new ArgumentNullException(nameof(linkFile)));
		if (!File.Exists(fullPath)) throw new FileNotFoundException("Link file not found.", linkFile);

		link = new IShellLinkW();

		if (resolveFlags.IsFlagSet(SLR_FLAGS.SLR_NO_UI) && timeOut != 0)
			resolveFlags = (SLR_FLAGS)MAKELONG((ushort)resolveFlags, timeOut);
#if !NETSTANDARD
		new FileIOPermission(FileIOPermissionAccess.Read, fullPath).Demand();
#endif
		((IPersistFile)link).Load(fullPath, (int)STGM.STGM_DIRECT);
		link.Resolve(hWin, resolveFlags);

		InitBaseFromPath(linkFile);
	}

	/// <summary>Saves the shortcut to ShortCutFile.</summary>
	private void Save()
	{
		if (string.IsNullOrEmpty(FileSystemPath)) return;
		SaveAs(File.Exists(FileSystemPath) ? null : FileSystemPath);
	}

	/// <summary>Saves the shortcut to the specified file.</summary>
	/// <param name="linkFile">The shortcut file (.lnk).</param>
	public void SaveAs(string linkFile)
	{
		using (var pIPF = ComReleaserFactory.Create((IPersistFile)link))
			pIPF.Item.Save(linkFile, true);
		if (linkFile != null)
			InitBaseFromPath(linkFile);
	}

	/// <summary>Determines if two shell links are equal by looking at the title, path and arguments.</summary>
	/// <param name="left">The left shell link to evaluate.</param>
	/// <param name="right">The right shell link to evaluate.</param>
	/// <returns><see langword="true"/> if the two links are equal; otherwise <see langword="false"/>.</returns>
	internal static bool Equals(IShellLinkW left, IShellLinkW right)
	{
		if (ReferenceEquals(left, right)) return true;
		if (left is null || right is null) return false;
		return string.Equals(GetCompareString(left), GetCompareString(right), StringComparison.Ordinal);
	}

	/// <summary>Gets a string representation of an <see cref="IShellLinkW"/> instance that includes the title, path and arguments for comparison.</summary>
	/// <param name="l">The <see cref="IShellLinkW"/> instance.</param>
	/// <returns>The string representation for comparison.</returns>
	internal static string GetCompareString(IShellLinkW l)
	{
		var ps = (PropSys.IPropertyStore)l;
		var title = ps.GetValue(PROPERTYKEY.System.Title)?.ToString();
		var exe = GetStringValue((sb, z) => l.GetPath(sb, z, out _, SLGP.SLGP_RAWPATH));
		var args = GetStringValue(l.GetArguments, MAX_PATH);
		return exe?.ToUpperInvariant() + title?.ToUpperInvariant() + args;
	}

	/// <summary>Determines whether the specified <see cref="IShellLinkW"/>, is equal to this instance.</summary>
	/// <param name="other">The <see cref="IShellLinkW"/> to compare with this instance.</param>
	/// <returns><see langword="true"/> if the specified <see cref="IShellLinkW"/> is equal to this instance; otherwise, <see langword="false"/>.</returns>
	public bool Equals(IShellLinkW other) => Equals(link, other);

	/// <summary>Determines whether the specified <see cref="ShellLink"/>, is equal to this instance.</summary>
	/// <param name="other">The <see cref="ShellLink"/> to compare with this instance.</param>
	/// <returns><see langword="true"/> if the specified <see cref="ShellLink"/> is equal to this instance; otherwise, <see langword="false"/>.</returns>
	public bool Equals(ShellLink other) => Equals(link, other?.link);
}