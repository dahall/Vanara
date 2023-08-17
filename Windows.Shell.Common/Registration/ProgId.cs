using Microsoft.Win32;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using Vanara.Windows.Shell.Registration;
using static Vanara.PInvoke.ShlwApi;

namespace Vanara.Windows.Shell;

/// <summary>Represents a programmatic identifier in the registry for an application.</summary>
/// <example>
/// <code title="Register a ProgId with a verb and associated extension.">
///using (var progId = ProgId.Register("Company.Product.1", "My first product", systemWide))
///{
///   progId.Verbs.Add("open", "Open", Application.ExecutablePath);
///   progId.FileTypeAssociations.Add(".txt");
///}
/// </code>
/// </example>
/// <seealso cref="IDisposable"/>
public class ProgId : RegBasedSettings
{
	private const string ClickToRun = @"SOFTWARE\Microsoft\Office\ClickToRun\REGISTRY\MACHINE\Software\Classes";
	private const string OpenWithProgIds = "OpenWithProgIds";

	internal ProgId(string progId, RegistryKey pkey, bool readOnly) : base(pkey, readOnly)
	{
		ID = progId;
		FileTypeAssociations = new FileTypeCollection(progId, readOnly, IsSystemWide);
		Verbs = new CommandVerbDictionary(this, readOnly);
	}

	/// <summary>
	/// Gets a value indicating whether to signal that Windows should ignore this ProgID when determining a default handler for a public
	/// file type. Regardless of whether this value is set, the ProgID continues to appear in the OpenWith shortcut menu and dialog.
	/// </summary>
	[DefaultValue(false)]
	public bool AllowSilentDefaultTakeOver
	{
		get => key.HasSubKey("AllowSilentDefaultTakeOver");
		set => ToggleKeyValue("AllowSilentDefaultTakeOver", value);
	}

	/// <summary>Overrides one of the folder options that hides the extension of known file types.</summary>
	[DefaultValue(false)]
	public bool AlwaysShowExt
	{
		get => key.HasValue("AlwaysShowExt");
		set => ToggleValue("AlwaysShowExt", value);
	}

	/// <summary>
	/// Gets the application's explicit Application User Model ID (AppUserModelID) if the application uses an explicit AppUserModelID
	/// and uses either the system's automatically generated Recent or Frequent Jump Lists or provides a custom Jump List. If an
	/// application uses an explicit AppUserModelID and does not set this value, items will not appear in that application's Jump Lists.
	/// </summary>
	[DefaultValue(null)]
	public string? AppUserModelID
	{
		get => key.GetValue("AppUserModelID")?.ToString();
		set => UpdateValue("AppUserModelID", value);
	}

	/// <summary>Gets or sets the CLSID of the COM server associated with this ProgId.</summary>
	[DefaultValue(null)]
	public Guid? CLSID
	{
		get { var s = key.GetSubKeyDefaultValue("CLSID")?.ToString(); return s == null ? null : new Guid(s); }
		set => UpdateKeyValue("CLSID", value?.ToRegString());
	}

	/// <summary>Gets or sets the versioned ProgId for this instance.</summary>
	[DefaultValue(null)]
	public string? CurVer
	{
		get => key.GetSubKeyDefaultValue("CurVer")?.ToString();
		set => UpdateKeyValue("CurVer", value);
	}

	/// <summary>Gets the default icon to display for file types associated with this ProgID.</summary>
	[DefaultValue(null)]
	public IconLocation? DefaultIcon
	{
		get => IconLocation.TryParse(key.GetSubKeyDefaultValue("DefaultIcon")?.ToString(), out var loc) ? loc : null;
		set => UpdateKeyValue("DefaultIcon", value?.ToString());
	}

	/// <summary>
	/// Gets flags that control some aspects of the Shell's handling of the file types linked to this ProgID. EditFlags may also limit
	/// how much the user can modify certain aspects of these file types using a file's property sheet.
	/// </summary>
	[DefaultValue((FILETYPEATTRIBUTEFLAGS)0)]
	public FILETYPEATTRIBUTEFLAGS EditFlags
	{
		get
		{
			var val = key.GetValue("EditFlags", 0);
			if (val is byte[] b) val = BitConverter.ToInt32(b, 0);
			if (val is int i) return (FILETYPEATTRIBUTEFLAGS)i;
			throw new InvalidOperationException("Unable to retrieve EditFlags value.");
		}
		set => UpdateValue("EditFlags", (uint)value, RegistryValueKind.DWord, (uint)FILETYPEATTRIBUTEFLAGS.FTA_None);
	}

	/// <summary>Gets or sets the list of properties to show in the listview on extended tiles.</summary>
	[DefaultValue(null)]
	public PropertyDescriptionList? ExtendedTileInfo
	{
		get => GetPDL(key, "ExtendedTileInfo");
		set => UpdateValue("ExtendedTileInfo", value?.ToString());
	}

	/// <summary>A collection of extensions with which this ProgId is associated.</summary>
	public ICollection<string> FileTypeAssociations { get; }

	/// <summary>
	/// Gets a friendly name for that ProgID, suitable to display to the user. The use of this entry to hold the friendly name is
	/// deprecated by the FriendlyTypeName entry on systems running Windows 2000 or later. However, it may be set for backward compatibility.
	/// </summary>
	[DefaultValue(null)]
	public string? FriendlyName
	{
		get => key.GetValue(null)?.ToString();
		set => UpdateValue(null, value ?? "");
	}

	/// <summary>Gets the friendly name for the ProgID, suitable to display to the user.</summary>
	[DefaultValue(null)]
	public IndirectString? FriendlyTypeName
	{
		get => IndirectString.TryParse(key.GetValue("FriendlyTypeName")?.ToString(), out var loc) ? loc : null;
		set => UpdateValue("FriendlyTypeName", value?.ToString());
	}

	/// <summary>Gets or sets the list of all the properties to show in the details page.</summary>
	[DefaultValue(null)]
	public PropertyDescriptionList? FullDetails
	{
		get => GetPDL(key, "FullDetails");
		set => UpdateValue("FullDetails", value?.ToString());
	}

	/// <summary>Gets the programmatic identifier.</summary>
	public string ID { get; }

	/// <summary>
	/// Gets the brief help message that the Shell displays for this ProgID. This may be a string, a IndirectString, or a PropertyDescriptionList.
	/// </summary>
	[DefaultValue(null)]
	public object? InfoTip
	{
		get => key.GetValue("InfoTip")?.ToString() switch
			{
				null => null,
				string s when s.StartsWith("@") => IndirectString.TryParse(s, out var loc) ? loc : null,
				string s when s.StartsWith("prop:") => new PropertyDescriptionList(s),
				string s => s
			};
		set => UpdateValue("InfoTip", value?.ToString());
	}

	/// <summary>
	/// Allows an application to register a file name extension as a shortcut file type. If a file has a file name extension that has
	/// been registered as a shortcut file type, the system automatically adds the system-defined link overlay icon (a small arrow) to
	/// the file's icon.
	/// </summary>
	[DefaultValue(false)]
	public bool IsShortcut
	{
		get => key.HasValue("IsShortcut");
		set => ToggleValue("IsShortcut", value);
	}

	/// <summary>Gets or sets a value indicating that the extension is never to be shown regardless of folder options.</summary>
	[DefaultValue(false)]
	public bool NeverShowExt
	{
		get => key.HasValue("NeverShowExt");
		set => ToggleValue("NeverShowExt", value);
	}

	/// <summary>
	/// Specifies that the associated ProgId should not be opened by users. The value is presented as a warning to users. Use <see
	/// cref="string.Empty"/> to use the system prompt.
	/// </summary>
	[DefaultValue(null)]
	public string? NoOpen
	{
		get => key.GetValue("NoOpen")?.ToString();
		set => UpdateValue("NoOpen", value);
	}

	/// <summary>Gets or sets the list of properties to display in the preview pane.</summary>
	[DefaultValue(null)]
	public PropertyDescriptionList? PreviewDetails
	{
		get => GetPDL(key, "PreviewDetails");
		set => UpdateValue("PreviewDetails", value?.ToString());
	}

	/// <summary>Gets or sets the one or two properties to display in the preview pane title section.</summary>
	[DefaultValue(null)]
	public PropertyDescriptionList? PreviewTitle
	{
		get => GetPDL(key, "PreviewTitle");
		set => UpdateValue("PreviewTitle", value?.ToString());
	}

	/// <summary>Gets or sets the list of properties to show in the listview on tiles.</summary>
	[DefaultValue(null)]
	public PropertyDescriptionList? TileInfo
	{
		get => GetPDL(key, "TileInfo");
		set => UpdateValue("TileInfo", value?.ToString());
	}

	/// <summary>Gets the command verbs associated with this ProgID.</summary>
	public CommandVerbDictionary Verbs { get; }

	/// <summary>Initializes a new instance of the <see cref="ProgId"/> class.</summary>
	/// <param name="progId">The programmatic identifier string.</param>
	/// <param name="readOnly">
	/// If <see langword="true"/>, provides read-only access to the registration; If <see langword="false"/>, the properties can be set
	/// to update the registration values.
	/// </param>
	/// <param name="autoLoadVersioned">
	/// if set to <c>true</c> automatically load a referenced versioned ProgId instead of the specified ProgId.
	/// </param>
	/// <param name="systemWide">
	/// If <see langword="true"/>, open the ProgId for system-wide use. If <see langword="false"/>, open the ProgId for the current user only.
	/// </param>
	/// <returns>The requested <see cref="ProgId"/> instance.</returns>
	public static ProgId Open(string progId, bool readOnly = true, bool autoLoadVersioned = true, bool systemWide = false)
	{
		var key = (systemWide ? null : ShellRegistrar.GetRoot(systemWide, !readOnly, progId ?? throw new ArgumentNullException(nameof(progId)))) ??
			Registry.ClassesRoot.OpenSubKey(progId, !readOnly);
		if (autoLoadVersioned)
		{
			var cv = key?.GetSubKeyDefaultValue("CurVer")?.ToString();
			if (cv != null && cv != progId)
			{
				var cvkey = ((systemWide ? null : ShellRegistrar.GetRoot(systemWide, !readOnly, cv)) ?? Registry.ClassesRoot.OpenSubKey(cv, !readOnly) ??
					Registry.LocalMachine.OpenSubKey(Path.Combine(ClickToRun, cv), !readOnly)); // ?? throw new ArgumentException($"Unable to load ProgId version = '{cv}'", nameof(progId));
				if (cvkey is null)
					System.Diagnostics.Debug.WriteLine($"Unable to load ProgId version = '{cv}'");
				else
				{
					key?.Close();
					key = cvkey;
				}
			}
		}
		if (key is null) throw new ArgumentException($"Unable to load ProgId = '{progId}'", nameof(progId));
		return new ProgId(progId, key, readOnly);
	}

	/// <summary>Registers the programmatic identifier (ProgId).</summary>
	/// <param name="progId">
	/// The key name for the ProgId. The proper format of a ProgID key name is [Vendor or Application].[Component].[Version], separated
	/// by periods and with no spaces, as in Word.Document.6. The Version portion is optional but strongly recommended.
	/// </param>
	/// <param name="friendlyName">
	/// The friendly name for this ProgID, suitable to display to the user. The use of this entry to hold the friendly name is
	/// overridden by the FriendlyTypeName entry on systems running Windows 2000 or later.
	/// </param>
	/// <param name="systemWide">
	/// If <see langword="true"/>, register the ProgId system-wide. If <see langword="false"/>, register the ProgId for the current user only.
	/// </param>
	/// <returns>A <see cref="ProgId"/> instance to continue definition of ProgId settings.</returns>
	public static ProgId Register(string progId, string friendlyName, bool systemWide = false)
	{
		if (progId == null) throw new ArgumentNullException(nameof(progId));
		if (progId.Length > 39 || !System.Text.RegularExpressions.Regex.IsMatch(progId, @"^[a-zA-Z][\w\.]+$", System.Text.RegularExpressions.RegexOptions.Singleline))
			throw new ArgumentException("A ProgID may not have more then 39 characters, must start with a letter, and may only contain letters, numbers and periods.");
		using var root = ShellRegistrar.GetRoot(systemWide, true) ?? Registry.ClassesRoot;
		return new ProgId(progId, root.CreateSubKey(progId, friendlyName), false);
	}

	/// <summary>Unregisters the ProgID.</summary>
	/// <param name="progId">The key for the ProgID. The function will succeed even if this value does not exists.</param>
	/// <param name="withFileExt">If set to <see langword="true"/>, also remove all associated registered file extensions.</param>
	/// <param name="systemWide">
	/// If <see langword="true"/>, register the ProgId system-wide. If <see langword="false"/>, register the ProgId for the current user only.
	/// </param>
	public static void Unregister(string progId, bool withFileExt = true, bool systemWide = false)
	{
		if (progId is null) return;
		using var reg = ShellRegistrar.GetRoot(systemWide, true) ?? Registry.ClassesRoot;

		if (withFileExt)
		{
			foreach (var ext in GetAssociatedFileExtensions(progId, systemWide))
			{
				using var ftype = FileTypeAssociation.Open(ext, systemWide, false);
				if (ftype.DefaultProgId == progId)
					ftype.DefaultProgId = null;
				ftype.OpenWithProgIds.Remove(progId);
			}
		}

		try { reg.DeleteSubKeyTree(progId); }
		catch { reg.DeleteSubKey(progId, false); }

		ShellRegistrar.NotifyShell();
	}

	/// <inheritdoc/>
	public override void Dispose()
	{
		base.Dispose();
		ShellRegistrar.NotifyShell();
	}

	internal static IEnumerable<string> GetAssociatedFileExtensions(string progId, bool systemWide = false)
	{
		using var root = ShellRegistrar.GetRoot(systemWide, false) ?? Registry.ClassesRoot;
		foreach (var ext in root.GetSubKeyNames().Where(ext => ext.StartsWith(".")))
		{
			var hasValue = false;
			using (var openWithKey = root.OpenSubKey(Path.Combine(ext, OpenWithProgIds)))
				hasValue = openWithKey?.HasValue(progId) ?? false;
			if (hasValue)
				yield return ext;
		}
	}

	private static PropertyDescriptionList? GetPDL(RegistryKey key, string valueName)
	{
		var pdl = key.GetValue(valueName)?.ToString();
		return pdl is null ? null : new PropertyDescriptionList(pdl);
	}
}

/// <summary>A virtual collection of file types associated with a ProgId in the Windows Registry.</summary>
class FileTypeCollection : ICollection<string>
{
	protected internal string progId;

	protected internal FileTypeCollection(string progId, bool readOnly, bool systemWide)
	{
		this.progId = progId ?? throw new ArgumentNullException(nameof(progId));
		IsReadOnly = readOnly;
		IsSystemWide = systemWide;
	}

	/// <summary>Gets the count.</summary>
	/// <value>The count.</value>
	public int Count => Enum().Count();

	/// <summary>Gets or sets a value indicating whether these settings are read-only.</summary>
	public bool IsReadOnly { get; }

	/// <summary>Gets or sets a value indicating whether these settings are read-only.</summary>
	public bool IsSystemWide { get; }

	/// <summary>Adds the specified item.</summary>
	/// <param name="ext">The extension to associate.</param>
	public void Add(string ext)
	{
		EnsureWritable();
		using var assoc = FileTypeAssociation.Register(ext, IsSystemWide);
		assoc.OpenWithProgIds.Add(progId);
	}

	/// <summary>Clears this instance.</summary>
	public void Clear() => throw new NotSupportedException();

	/// <summary>Determines whether this instance contains the object.</summary>
	/// <param name="item">The item.</param>
	/// <returns><see langword="true"/> if [contains] [the specified item]; otherwise, <see langword="false"/>.</returns>
	public bool Contains(string item) => (ShellRegistrar.GetRoot(IsSystemWide, false, Path.Combine(item, "OpenWithProgIds")) ?? Registry.ClassesRoot.OpenSubKey(Path.Combine(item, "OpenWithProgIds"), false))?.HasValue(progId) ?? false;

	/// <summary>Copies to.</summary>
	/// <param name="array">The array.</param>
	/// <param name="arrayIndex">Index of the array.</param>
	public void CopyTo(string[] array, int arrayIndex) => Array.Copy(Enum().ToArray(), 0, array, arrayIndex, Count);

	/// <summary>Gets the enumerator.</summary>
	/// <returns></returns>
	public IEnumerator<string> GetEnumerator() => Enum().GetEnumerator();

	/// <summary>Removes the specified item.</summary>
	/// <param name="item">The item.</param>
	/// <returns></returns>
	public bool Remove(string item)
	{
		EnsureWritable();
		using var openWithKey = ShellRegistrar.GetRoot(IsSystemWide, true, Path.Combine(item, "OpenWithProgIds")) ?? Registry.ClassesRoot.OpenSubKey(Path.Combine(item, "OpenWithProgIds"), false);
		try
		{
			openWithKey?.DeleteValue(progId, true);
			return true;
		}
		catch { return false; }
	}

	/// <summary>Gets the enumerator.</summary>
	/// <returns></returns>
	System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => GetEnumerator();

	/// <summary>Checks the ReadOnly flag and throws an exception if it is true.</summary>
	protected void EnsureWritable() { if (IsReadOnly) throw new NotSupportedException("The collection is read only."); }

	private IEnumerable<string> Enum() => ProgId.GetAssociatedFileExtensions(progId, IsSystemWide);
}