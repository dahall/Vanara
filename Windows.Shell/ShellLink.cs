using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security.AccessControl;
using System.Security.Permissions;
using System.Text;
using System.Windows.Forms;
using Vanara.Extensions;
using Vanara.PInvoke;
using static Vanara.PInvoke.Macros;
using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.Kernel32;
using static Vanara.PInvoke.Shell32;

// ReSharper disable SuspiciousTypeConversion.Global
// ReSharper disable InconsistentNaming

namespace Vanara.Windows.Shell
{
	/// <summary>Flags determining how the links with missing targets are resolved.</summary>
	[Flags]
	public enum LinkResolution : uint
	{
		/// <summary>No flags set.</summary>
		None = 0,

		/// <summary>
		/// Do not display a dialog box if the link cannot be resolved. When NoUI is set, a time-out value that specifies
		/// the maximum amount of time to be spent resolving the link can be specified in milliseconds. The function
		/// returns if the link cannot be resolved within the time-out duration. If the timeout is not set, the time-out
		/// duration will be set to the default value of 3,000 milliseconds (3 seconds).
		/// </summary>
		NoUI = 0x1,

		/// <summary>Allow any match during resolution. Has no effect on ME/2000 or above, use the other flags instead.</summary>
		AnyMatch = 0x2,

		/// <summary>
		/// If the link object has changed, update its path and list of identifiers. If UPDATE is set, you do not need to
		/// call IPersistFile::IsDirty to determine whether or not the link object has changed.
		/// </summary>
		Update = 0x4,

		/// <summary>Do not update the link information.</summary>
		NoUpdate = 0x8,

		/// <summary>Do not execute the search heuristics.</summary>
		NoSearch = 0x10,

		/// <summary>Do not use distributed link tracking.</summary>
		NoTrack = 0x20,

		/// <summary>
		/// Disable distributed link tracking. By default, distributed link tracking tracks removable media across
		/// multiple devices based on the volume name. It also uses the UNC path to track remote file systems whose drive
		/// letter has changed. Setting NoLinkInfo disables both types of tracking.
		/// </summary>
		NoLinkInfo = 0x40,

		/// <summary>Call the Microsoft Windows Installer.</summary>
		InvokeMSI = 0x80,

		/// <summary>Windows XP and later. Assume same as NoUI but intended for applications without a hWnd.</summary>
		NoUIWithMsgPump = 0x101,

		/// <summary>
		/// Windows 7 and later. Offer the option to delete the shortcut when this method is unable to resolve it, even
		/// if the shortcut is not a shortcut to a file.
		/// </summary>
		OfferDeleteWithoutFile = 0x200,

		/// <summary>
		/// Windows 7 and later. Report as dirty if the target is a known folder and the known folder was redirected.
		/// This only works if the original target path was a file system path or ID list and not an aliased known folder
		/// ID list.
		/// </summary>
		KnonnFolder = 0x400,

		/// <summary>
		/// Windows 7 and later. Resolve the computer name in UNC targets that point to a local computer. This value is
		/// used with SLDFKEEPLOCALIDLISTFORUNCTARGET.
		/// </summary>
		MachineInLocalTarget = 0x800,

		/// <summary>Windows 7 and later. Update the computer GUID and user SID if necessary.</summary>
		UpdateMachineAndSid = 0x1000,

		/// <summary>?? Assuming this does not update the Object ID</summary>
		NoObjectID = 0x2000
	}

	/// <summary>Represents a Shell Shortcut (.lnk) file.</summary>
	public sealed class ShellLink : ShellFileInfo, IDisposable
	{
		internal IShellLinkW link;
		private PropertyStore values;

		/// <summary>Initializes a new instance of the <see cref="ShellLink"/> class, which acts as a wrapper for a .lnk file.</summary>
		/// <param name="linkFile">The shortcut file (.lnk) to load.</param>
		/// <param name="window">
		/// The window that the Shell will use as the parent for a dialog box. The Shell displays the dialog box if it needs to prompt the user for more
		/// information while resolving a Shell link.
		/// </param>
		/// <param name="resolveFlags">The resolve flags.</param>
		/// <param name="timeOut">The time out.</param>
		/// <exception cref="System.ArgumentNullException">linkFile</exception>
		public ShellLink(string linkFile, IWin32Window window = null, LinkResolution resolveFlags = LinkResolution.AnyMatch | LinkResolution.NoUI, ushort timeOut = 1) : this()
		{
			if (string.IsNullOrEmpty(linkFile)) throw new ArgumentNullException(nameof(linkFile));

			if ((resolveFlags & LinkResolution.NoUI) == LinkResolution.NoUI)
				resolveFlags |= (LinkResolution)(timeOut << 16);

			Init(linkFile);
			new FileIOPermission(FileIOPermissionAccess.Read, FullPath).Demand();
			((IPersistFile)link).Load(linkFile, 0); //STGM_DIRECT)
			link.Resolve(window?.Handle ?? IntPtr.Zero, (SLR_FLAGS)resolveFlags);
		}

		/// <summary>Creates an instance of the Shell Link object.</summary>
		private ShellLink()
		{
			link = (IShellLinkW)new CShellLinkW();
		}

		/// <summary>Call dispose just in case it hasn't happened yet</summary>
		~ShellLink()
		{
			Dispose();
		}

		/*public string AppUserModelID
		{
			get
			{
				using (PropVariant pv = new PropVariant())
				{
					VerifySucceeded(PropertyStore.GetValue(AppUserModelIDKey, pv));

					if (pv.Value == null)
						return "Null";
					else
						return pv.Value;
				}
			}
			set
			{
				using (PropVariant pv = new PropVariant(value))
				{
					VerifySucceeded(PropertyStore.SetValue(AppUserModelIDKey, pv));
					VerifySucceeded(PropertyStore.Commit());
				}
			}
		}*/

		/// <summary>Gets/sets any command line arguments associated with the link</summary>
		public string Arguments
		{
			get => GetStringValue(link.GetArguments, 260); set { link.SetArguments(value); Save(); }
		}

		/// <summary>Gets/sets the description of the link</summary>
		public string Description
		{
			get => GetStringValue(link.GetDescription, 1024); set { link.SetDescription(value); Save(); }
		}

		/// <summary>Gets/sets the HotKey to start the shortcut (if any).</summary>
		public Keys HotKey
		{
			get { var hk = link.GetHotKey(); return (Keys)MAKELONG(LOBYTE(hk), HIBYTE(hk)); }
			set { link.SetHotKey(MAKEWORD((byte)LOWORD((uint)value), (byte)HIWORD((uint)value))); Save(); }
		}

		/// <summary>Gets the index of this icon within the icon path's resources.</summary>
		public int IconIndex
		{
			get
			{
				int iconIndex;
				GetIconLocation(out iconIndex);
				return iconIndex;
			}
			set
			{
				int iconIndex;
				link.SetIconLocation(GetIconLocation(out iconIndex), value);
				Save();
			}
		}

		/// <summary>Gets the path to the file containing the icon for this shortcut.</summary>
		public string IconPath
		{
			get
			{
				int iconIndex;
				return GetIconLocation(out iconIndex);
			}
			set
			{
				int iconIndex;
				GetIconLocation(out iconIndex);
				link.SetIconLocation(value, iconIndex);
				Save();
			}
		}

		/// <summary>Get or sets the list of item identifiers for a Shell link.</summary>
		public PIDL IDList
		{
			get => link.GetIDList(); set { link.SetIDList(value); Save(); }
		}

		/// <summary>Gets or sets a value that determines if the current link file is read only.</summary>
		/// <value><c>true</c> if this instance is read only; otherwise, <c>false</c>.</value>
		public bool IsReadOnly
		{
			get => (Attributes & FileAttributes.ReadOnly) != 0; set
			{
				if (value)
					Attributes |= FileAttributes.ReadOnly;
				else
					Attributes &= ~FileAttributes.ReadOnly;
			}
		}

		/// <summary>Gets a <see cref="PropertyStore"/> object that provides access to shell properties of the file.</summary>
		/// <value>A <see cref="PropertyStore"/> object.</value>
		public PropertyStore Properties => values ?? (values = new PropertyStore(this, (o, e) => Save()));

		/// <summary>Gets/sets the relative path to the link's target</summary>
		public string RelativeTargetPath
		{
			get => GetPath(SLGP.SLGP_RELATIVEPRIORITY); set { link.SetRelativePath(value, 0); Save(); }
		}

		/// <summary>Gets or sets a value indicating whether the target is run with Administrator rights.</summary>
		/// <value><c>true</c> if run as Administrator; otherwise, <c>false</c>.</value>
		public bool RunAsAdministrator
		{
			get
			{
				var dl = (IShellLinkDataList)link;
				var flags = dl.GetFlags();
				return flags.IsFlagSet(SHELL_LINK_DATA_FLAGS.SLDF_RUNAS_USER);
			}
			set
			{
				var dl = (IShellLinkDataList)link;
				var flags = dl.GetFlags();
				if (flags.IsFlagSet(SHELL_LINK_DATA_FLAGS.SLDF_RUNAS_USER) && !value)
					dl.SetFlags(flags.SetFlags(SHELL_LINK_DATA_FLAGS.SLDF_RUNAS_USER, false));
				else if (!flags.IsFlagSet(SHELL_LINK_DATA_FLAGS.SLDF_RUNAS_USER) && value)
					dl.SetFlags(flags.SetFlags(SHELL_LINK_DATA_FLAGS.SLDF_RUNAS_USER, true));
				Save();
			}
		}

		/// <summary>Gets/sets the short (8.3 format) path to the link's target</summary>
		public string ShortTargetPath => GetPath(SLGP.SLGP_SHORTPATH);

		/// <summary>Gets or sets the show command for a Shell link object.</summary>
		/// <value>The show command for a Shell link object.</value>
		public FormWindowState ShowState
		{
			get => (FormWindowState)link.GetShowCmd() - 1; set { link.SetShowCmd((ShowWindowCommand)value + 1); Save(); }
		}

		/// <summary>Gets/sets the fully qualified path to the link's target</summary>
		public string TargetPath
		{
			get => GetPath(SLGP.SLGP_UNCPRIORITY); set { link.SetPath(value); Save(); }
		}

		/// <summary>Gets/sets the Working Directory for the Link</summary>
		public string WorkingDirectory
		{
			get => GetStringValue(link.GetWorkingDirectory, 260); set { link.SetWorkingDirectory(value); Save(); }
		}

		/// <summary>
		/// Creates or overwrites a new link file.
		/// </summary>
		/// <param name="linkFilename">The link filename.</param>
		/// <param name="targetFilename">The full path to the target file.</param>
		/// <param name="description">The description of the link.</param>
		/// <param name="workingDirectory">The working directory for the execution of the target.</param>
		/// <param name="arguments">The arguments for the target's execution.</param>
		/// <returns>An instance of a <see cref="ShellLink"/> representing the values supplied.</returns>
		public static ShellLink Create(string linkFilename, string targetFilename, string description = null,
			string workingDirectory = null, string arguments = null)
		{
			var lnk = new ShellLink
			{
				TargetPath = targetFilename,
				Description = description,
				WorkingDirectory = workingDirectory,
				Arguments = arguments
			};
			lnk.SaveAs(linkFilename);
			return lnk;
		}

		/// <summary>
		/// Copies an existing file to a new file, allowing the overwriting of an existing file.
		/// </summary>
		/// <param name="destShellLink">The name of the new file to copy to.</param>
		/// <param name="overwrite"><c>true</c> to allow an existing file to be overwritten; otherwise <c>false</c>.</param>
		/// <returns>A new file, or an overwrite of an existing file if overwrite is true. If the file exists and overwrite is false, an IOException is thrown.</returns>
		public ShellLink CopyTo(string destShellLink, bool overwrite = false)
		{
			File.Copy(FullPath, destShellLink);
			return new ShellLink(destShellLink);
		}

		/// <summary>Permanently deletes the link file.</summary>
		public override void Delete()
		{
			File.Delete(FullPath);
		}

		/// <summary>Dispose the object, releasing the COM ShellLink object</summary>
		public void Dispose()
		{
			if (link != null)
			{
				Marshal.ReleaseComObject(link);
				link = null;
			}
		}

		/// <summary>Determines whether the specified <see cref="System.Object"/>, is equal to this instance.</summary>
		/// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
		/// <returns>
		/// <c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.
		/// </returns>
		public override bool Equals(object obj)
		{
			var link2 = obj as ShellLink;
			if (link2 != null)
				return link2.ToString() == ToString();
			return base.Equals(obj);
		}

		/// <summary>
		/// Gets a FileSecurity object that encapsulates the specified type of access control list (ACL) entries for the file described by the current FileInfo object.
		/// </summary>
		/// <param name="includeSections">One of the AccessControlSections values that specifies which group of access control entries to retrieve.</param>
		/// <returns>A FileSecurity object that encapsulates the access control rules for the current file.</returns>
		public FileSecurity GetAccessControl(AccessControlSections includeSections = AccessControlSections.Access | AccessControlSections.Group | AccessControlSections.Owner)
		{
			return File.GetAccessControl(FullPath, includeSections);
		}

		/// <summary>Returns a hash code for this instance.</summary>
		/// <returns>
		/// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
		/// </returns>
		public override int GetHashCode() => ToString().GetHashCode();

		/// <summary>Gets the property specified by <paramref name="key"/>.</summary>
		/// <typeparam name="T">Property type</typeparam>
		/// <param name="key">The property key.</param>
		/// <param name="defValue">The default value.</param>
		/// <returns>The value of the property or <paramref name="defValue"/> if not found.</returns>
		public T GetProperty<T>(PROPERTYKEY key, T defValue = default(T))
		{
			try
			{
				return (T)Properties[key.Key];
			}
			catch { }
			return defValue;
		}

		/// <summary>
		/// Moves a specified file to a new location, providing the option to specify a new file name.
		/// </summary>
		/// <param name="destFileName">The path to move the file to, which can specify a different file name.</param>
		public void MoveTo(string destFileName)
		{
			File.Move(FullPath, destFileName);
			Init(destFileName);
		}

		/// <summary>
		/// Applies access control list (ACL) entries described by a FileSecurity object to the file described by the current FileInfo object.
		/// </summary>
		/// <param name="fileSecurity">A FileSecurity object that describes an access control list (ACL) entry to apply to the current file.</param>
		public void SetAccessControl(FileSecurity fileSecurity)
		{
			File.SetAccessControl(FullPath, fileSecurity);
		}

		/// <summary>Returns a <see cref="System.String"/> that represents this instance.</summary>
		/// <returns>A <see cref="System.String"/> that represents this instance.</returns>
		// Path and title should be case insensitive. Shell treats arguments as case sensitive because apps can handle
		// those differently.
		public override string ToString() =>
			$"{(GetProperty<string>(KnownShellItemPropertyKeys.Title) ?? "").ToUpperInvariant()} {GetPath(SLGP.SLGP_RAWPATH).ToUpperInvariant()} {Arguments}";

		private Icon GetIcon(bool large)
		{
			// Get icon index and path:
			var iconIndex = 0;
			var iconPath = new StringBuilder(MAX_PATH, MAX_PATH);
			link.GetIconLocation(iconPath, iconPath.Capacity, out iconIndex);
			var iconFile = iconPath.ToString();

			// If there are no details set for the icon, then we must use the shell to get the icon for the target
			if (iconFile.Length == 0)
			{
				var sfi = new ShellFileInfo(TargetPath);
				return large ? sfi.LargeIcon : sfi.SmallIcon;
			}
			else
			{
				// Use ExtractIconEx to get the icon:
				var hIconEx = new IntPtr[1] { IntPtr.Zero };
				if (large)
					ExtractIconEx(iconFile, iconIndex, hIconEx, null, 1);
				else
					ExtractIconEx(iconFile, iconIndex, null, hIconEx, 1);
				// If success then return as a GDI+ object
				Icon icon = null;
				if (hIconEx[0] != IntPtr.Zero)
					icon = ShellFileInfo.GetClonedIcon(hIconEx[0]);
				return icon;
			}
		}

		private string GetIconLocation(out int iconIndex)
		{
			var iconPath = new StringBuilder(MAX_PATH, MAX_PATH);
			iconIndex = 0;
			link.GetIconLocation(iconPath, iconPath.Capacity, out iconIndex);
			return iconPath.ToString();
		}

		private string GetPath(SLGP value)
		{
			var target = new StringBuilder(MAX_PATH, MAX_PATH);
			var fd = new WIN32_FIND_DATA();
			link.GetPath(target, target.Capacity, fd, value);
			return target.ToString();
		}

		private string GetStringValue(Action<StringBuilder, int> method, int buffSize)
		{
			var ret = new StringBuilder(buffSize, buffSize);
			method(ret, ret.Capacity);
			return ret.ToString();
		}

		private void Init(string linkFile)
		{
			OriginalPath = linkFile;
			FullPath = Path.GetFullPath(linkFile);
			SetName(Path.GetFileName(linkFile));
		}

		/// <summary>Saves the shortcut to ShortCutFile.</summary>
		private void Save()
		{
			if (Exists)
				((IPersistFile)link).Save(null, true);
			else if (FullPath != null)
				SaveAs(FullPath);
		}

		/// <summary>Saves the shortcut to the specified file</summary>
		/// <param name="linkFile">The shortcut file (.lnk)</param>
		private void SaveAs(string linkFile)
		{
			((IPersistFile)link).Save(linkFile, true);
			Init(linkFile);
		}
	}
}