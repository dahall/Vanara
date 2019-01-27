using Microsoft.Win32;
using System;
using System.Collections.Generic;
using static Vanara.PInvoke.ShlwApi;

namespace Vanara.Windows.Shell
{
	/// <summary>Represents a programmatic identifier in the registry for an application.</summary>
	/// <seealso cref="System.IDisposable"/>
	public class ProgId : RegBasedSettings
	{
		/// <summary>Initializes a new instance of the <see cref="ProgId"/> class.</summary>
		/// <param name="progId">The programmatic identifier string.</param>
		/// <param name="readOnly">if set to <c>true</c> disallow changes.</param>
		/// <param name="autoLoadVersioned">
		/// if set to <c>true</c> automatically load a referenced versioned ProgId instead of the specified ProgId.
		/// </param>
		public ProgId(string progId, bool readOnly = true, bool autoLoadVersioned = true) : base(Registry.ClassesRoot.OpenSubKey(progId ?? throw new ArgumentNullException(nameof(progId)), !readOnly), readOnly)
		{
			if (autoLoadVersioned)
			{
				var cv = key.GetSubKeyDefaultValue("CurVer")?.ToString();
				if (cv != null)
					key = Registry.ClassesRoot.OpenSubKey(cv, !readOnly);
			}
			if (key == null) throw new ArgumentException("Unable to load specified ProgId", nameof(progId));
			ID = progId;
			Verbs = new CommandVerbDictionary(this, readOnly);
		}

		internal ProgId(string progId, RegistryKey pkey, bool readOnly) : base(pkey, readOnly)
		{
			ID = progId;
			Verbs = new CommandVerbDictionary(this, readOnly);
		}

		/// <summary>
		/// Gets a value indicating whether to signal that Windows should ignore this ProgID when determining a default handler for a public
		/// file type. Regardless of whether this value is set, the ProgID continues to appear in the OpenWith shortcut menu and dialog.
		/// </summary>
		public bool AllowSilentDefaultTakeOver
		{
			get => key.HasSubKey("AllowSilentDefaultTakeOver");
			set => ToggleKeyValue("AllowSilentDefaultTakeOver", value);
		}

		/// <summary>Overrides one of the folder options that hides the extension of known file types.</summary>
		public bool AlwaysShowExt
		{
			get => key.HasValue("AlwaysShowExt");
			set => ToggleValue("AlwaysShowExt", value);
		}

		/// <summary>
		/// Gets the application's explicit Application User Model ID (AppUserModelID) if the application uses an explicit AppUserModelID and
		/// uses either the system's automatically generated Recent or Frequent Jump Lists or provides a custom Jump List. If an application
		/// uses an explicit AppUserModelID and does not set this value, items will not appear in that application's Jump Lists.
		/// </summary>
		public string AppUserModelID
		{
			get => key.GetValue("AppUserModelID")?.ToString();
			set => UpdateValue("AppUserModelID", value);
		}

		/// <summary>Gets or sets the CLSID of the COM server associated with this ProgId.</summary>
		public Guid? CLSID
		{
			get { var s = key.GetSubKeyDefaultValue("CLSID")?.ToString(); return s == null ? (Guid?)null : new Guid(s); }
			set => UpdateKeyValue("CLSID", value?.ToRegString());
		}

		/// <summary>Gets or sets the versioned ProgId for this instance.</summary>
		public ProgId CurVer
		{
			get => key.HasSubKey("CurVer") ? new ProgId(ID, ReadOnly, true) : null;
			set => UpdateKeyValue("CurVer", value?.ID);
		}

		/// <summary>Gets the default icon to display for file types associated with this ProgID.</summary>
		public IconLocation DefaultIcon
		{
			get => IconLocation.TryParse(key.GetSubKeyDefaultValue("DefaultIcon")?.ToString(), out var loc) ? loc : null;
			set => UpdateKeyValue("DefaultIcon", value?.ToString());
		}

		/// <summary>
		/// Gets flags that control some aspects of the Shell's handling of the file types linked to this ProgID. EditFlags may also limit
		/// how much the user can modify certain aspects of these file types using a file's property sheet.
		/// </summary>
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
		public PropertyDescriptionList ExtendedTileInfo
		{
			get => GetPDL(key, "ExtendedTileInfo");
			set => UpdateValue("ExtendedTileInfo", value?.ToString());
		}

		/// <summary>
		/// Gets a friendly name for that ProgID, suitable to display to the user. The use of this entry to hold the friendly name is
		/// deprecated by the FriendlyTypeName entry on systems running Windows 2000 or later. However, it may be set for backward compatibility.
		/// </summary>
		public string FriendlyName
		{
			get => key.GetValue(null)?.ToString();
			set => UpdateValue(null, value ?? "");
		}

		/// <summary>Gets the friendly name for the ProgID, suitable to display to the user.</summary>
		public IndirectString FriendlyTypeName
		{
			get => IndirectString.TryParse(key.GetValue("FriendlyTypeName")?.ToString(), out var loc) ? loc : null;
			set => UpdateValue("FriendlyTypeName", value?.ToString());
		}

		/// <summary>Gets or sets the list of all the properties to show in the details page.</summary>
		public PropertyDescriptionList FullDetails
		{
			get => GetPDL(key, "FullDetails");
			set => UpdateValue("FullDetails", value?.ToString());
		}

		/// <summary>Gets the programmatic identifier.</summary>
		public string ID { get; }

		/// <summary>
		/// Gets the brief help message that the Shell displays for this ProgID. This may be a string, a IndirectString, or a PropertyDescriptionList.
		/// </summary>
		public object InfoTip
		{
			get
			{
				var val = key.GetValue("InfoTip")?.ToString();
				if (val == null) return null;
				if (val.StartsWith("@")) return IndirectString.TryParse(val, out var loc) ? loc : null;
				if (val.StartsWith("prop:")) return new PropertyDescriptionList(val);
				return val;
			}
			set => UpdateValue("InfoTip", value?.ToString());
		}

		/// <summary>
		/// Allows an application to register a file name extension as a shortcut file type. If a file has a file name extension that has
		/// been registered as a shortcut file type, the system automatically adds the system-defined link overlay icon (a small arrow) to
		/// the file's icon.
		/// </summary>
		public bool IsShortcut
		{
			get => key.HasValue("IsShortcut");
			set => ToggleValue("IsShortcut", value);
		}

		/// <summary>Gets or sets a value indicating that the extension is never to be shown regardless of folder options.</summary>
		public bool NeverShowExt
		{
			get => key.HasValue("NeverShowExt");
			set => ToggleValue("NeverShowExt", value);
		}

		/// <summary>
		/// Specifies that the associated ProgId should not be opened by users. The value is presented as a warning to users.
		/// Use <see cref="string.Empty"/> to use the system prompt.
		/// </summary>
		public string NoOpen
		{
			get => key.GetValue("NoOpen")?.ToString();
			set => UpdateValue("NoOpen", value);
		}

		/// <summary>Gets or sets the list of properties to display in the preview pane.</summary>
		public PropertyDescriptionList PreviewDetails
		{
			get => GetPDL(key, "PreviewDetails");
			set => UpdateValue("PreviewDetails", value?.ToString());
		}

		/// <summary>Gets or sets the one or two properties to display in the preview pane title section.</summary>
		public PropertyDescriptionList PreviewTitle
		{
			get => GetPDL(key, "PreviewTitle");
			set => UpdateValue("PreviewTitle", value?.ToString());
		}

		/// <summary>Gets or sets the list of properties to show in the listview on tiles.</summary>
		public PropertyDescriptionList TileInfo
		{
			get => GetPDL(key, "TileInfo");
			set => UpdateValue("TileInfo", value?.ToString());
		}

		/// <summary>Gets the command verbs associated with this ProgID.</summary>
		public CommandVerbDictionary Verbs { get; }

		private static PropertyDescriptionList GetPDL(RegistryKey key, string valueName)
		{
			var pdl = key.GetValue(valueName)?.ToString();
			return pdl == null ? null : new PropertyDescriptionList(pdl);
		}

		// TODO + public
		private IEnumerable<ShellAssociation> QueryAssociations() => null; //ShellRegistrar.GetAssociatedFileExtensions(ID).Select(s => new ShellAssociation(s));
	}
}