using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using Vanara.Collections;

namespace Vanara.Windows.Shell
{
	public abstract class RegistryBasedVirtualDictionary<T> : VirtualReadOnlyDictionary<string, T>
	{
		protected RegistryKey baseKey;
		protected readonly bool readOnly;

		protected RegistryBasedVirtualDictionary(RegistryKey baseKey, bool readOnly)
		{
			this.baseKey = baseKey;
			this.readOnly = readOnly;
		}

		public override IEnumerable<string> Keys => baseKey?.GetSubKeyNames().Where(SubKeyFilter) ?? new string[0];

		public override bool ContainsKey(string key) => (baseKey?.HasSubKey(key) ?? false) && SubKeyFilter(key);

		protected virtual bool SubKeyFilter(string keyName) => true;
	}

	public class CommandVerbDictionary : RegistryBasedVirtualDictionary<CommandVerb>
	{
		private const string rootKeyName = "shell";
		private readonly RegBasedSettings parent;

		internal CommandVerbDictionary(RegBasedSettings parent, bool readOnly) : base(parent.key.OpenSubKey(rootKeyName, !readOnly), readOnly)
		{
			this.parent = parent;
		}

		public override IEnumerable<string> Keys => baseKey?.GetSubKeyNames() ?? new string[0];

		public CommandVerb Add(string verb, string displayName = null, string command = null)
		{
			if (baseKey == null && !readOnly)
				baseKey = parent.key.CreateSubKey(rootKeyName);
			return ShellRegistrar.RegisterCommandVerb(parent.key, verb, displayName, command);
		}

		public override bool ContainsKey(string key) => baseKey?.HasSubKey(key) ?? false;

		public bool Remove(string key)
		{
			try
			{
				baseKey.DeleteSubKeyTree(key);
				return true;
			}
			catch
			{
				return false;
			}
		}

		public IList<CommandVerb> Order
		{
			get
			{
				var order = baseKey.GetValue("", null)?.ToString();
				var vals = Values.ToList();
				if (order != null)
				{
					var orderedItems = order.Split(new[] {','}, StringSplitOptions.RemoveEmptyEntries);
					for (var i = orderedItems.Length - 1; i >= 0; i--)
					{
						var match = vals.Find(c =>
							string.Equals(c.Name, orderedItems[i], StringComparison.InvariantCultureIgnoreCase));
						if (match == null) continue;
						vals.Remove(match);
						vals.Insert(0, match);
					}
				}
				return vals;
			}
			set
			{
				switch (value?.Count ?? 0)
				{
					case 0:
						baseKey.DeleteValue("", false);
						break;
					case 1:
						baseKey.SetValue("", value.First().Name);
						break;
					default:
						baseKey.SetValue("", string.Join(",", value.Select(c => c.Name).ToArray()));
						break;
				}
			}
		}

		public override bool TryGetValue(string key, out CommandVerb value)
		{
			value = null;
			if (!ContainsKey(key)) return false;
			value = new CommandVerb(baseKey.OpenSubKey(key, !readOnly), key, readOnly);
			return true;
		}
	}

	internal class ProgIdDictionary : RegistryBasedVirtualDictionary<ProgId>
	{
		private static readonly string[] badKeys =
		{
			"*", "AllFileSystemObjects", "AppID", "Applications", "AudioCD", "Briefcase", "CID", "CID.Local",
			"CLSID", "CompressedFolder", "ConflictFolder", "DVD", "DVDFile", "DesktopBackground", "DirectShow",
			"Directory", "Drive", "ExplorerCLSIDFlags", "Folder", "Interface", "LibraryFolder", "Local Settings",
			"MIME", "Media Servers", "Media Type", "MediaFoundation", "NetServer", "NetShare", "Network",
			"Printers", "Stack", "SystemFileAssociations", "TypeLib", "Unknown", "UserLibraryFolder",
			"VideoClipContainers", "VirtualStore"
		};

		public ProgIdDictionary(bool readOnly) : base(Registry.ClassesRoot, readOnly) { }

		public override bool TryGetValue(string key, out ProgId value)
		{
			value = null;
			if (!ContainsKey(key)) return false;
			value = new ProgId(key, readOnly);
			return true;
		}

		protected override bool SubKeyFilter(string keyName) => !keyName.StartsWith(".") &&
			!keyName.StartsWith("Kind.") && Array.BinarySearch(badKeys, keyName, StringComparer.OrdinalIgnoreCase) < 0;
	}

	internal class ShellAssociationDictionary : RegistryBasedVirtualDictionary<ShellAssociation>
	{
		public ShellAssociationDictionary(bool readOnly) : base(Registry.ClassesRoot, readOnly) { }

		public override bool TryGetValue(string key, out ShellAssociation value)
		{
			value = null;
			if (!ContainsKey(key)) return false;
			value = ShellAssociation.CreateFromFileExtension(key);
			return true;
		}

		protected override bool SubKeyFilter(string keyName) => keyName.StartsWith(".");
	}
}