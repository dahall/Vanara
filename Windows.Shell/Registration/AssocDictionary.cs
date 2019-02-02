using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using Vanara.Collections;

namespace Vanara.Windows.Shell
{
	/// <summary>A dictionary of Command Verbs defined in the Windows Registry.</summary>
	/// <seealso cref="Vanara.Windows.Shell.RegistryBasedVirtualDictionary{Vanara.Windows.Shell.CommandVerb}"/>
	public class CommandVerbDictionary : RegistryBasedVirtualDictionary<CommandVerb>
	{
		private const string rootKeyName = "shell";
		private readonly RegBasedSettings parent;

		internal CommandVerbDictionary(RegBasedSettings parent, bool readOnly) : base(parent.key.OpenSubKey(rootKeyName, !readOnly), readOnly) => this.parent = parent;

		/// <summary>Get the filtered list of keys under the base.</summary>
		public override IEnumerable<string> Keys => baseKey?.GetSubKeyNames() ?? new string[0];

		/// <summary>Gets or sets the order of the command verbs.</summary>
		/// <value>The ordered list of command verbs.</value>
		public IList<CommandVerb> Order
		{
			get
			{
				var order = baseKey.GetValue("", null)?.ToString();
				var vals = Values.ToList();
				if (order != null)
				{
					var orderedItems = order.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
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

		/// <summary>Adds the specified command verb.</summary>
		/// <param name="verb">The command verb name.</param>
		/// <param name="displayName">
		/// The command verb display name. This is the string shown to the user when requesting a context menu for a shell item.
		/// </param>
		/// <param name="command">The command to execute.</param>
		/// <returns>A <see cref="CommandVerb"/> instance which has been added to the registry.</returns>
		public CommandVerb Add(string verb, string displayName = null, string command = null)
		{
			if (baseKey == null && !readOnly)
				baseKey = parent.key.CreateSubKey(rootKeyName);
			return ShellRegistrar.RegisterCommandVerb(parent.key, verb, displayName, command);
		}

		/// <summary>Determines if a specified key is in the filtered list of keys under the base.</summary>
		/// <param name="verb">The name of the key to check.</param>
		/// <returns><see langword="true" /> if the key is found; otherwise <see langword="false" />.</returns>
		public override bool ContainsKey(string verb) => baseKey?.HasSubKey(verb) ?? false;

		/// <summary>Removes the specified key from this dictionary and the registry.</summary>
		/// <param name="verb">The name of the command verb to remove.</param>
		/// <returns>A value indicating success (<see langword="true"/>) or failure (<see langword="false"/>).</returns>
		public bool Remove(string verb)
		{
			try
			{
				baseKey.DeleteSubKeyTree(verb);
				return true;
			}
			catch
			{
				return false;
			}
		}

		/// <summary>Tries to get the <see cref="CommandVerb"/> with the name <paramref name="verb"/>.</summary>
		/// <param name="verb">The verb name.</param>
		/// <param name="value">On success, the corresponding <see cref="CommandVerb"/> instance; <see langword="null"/> on failure.</param>
		/// <returns>A value indicating if <paramref name="verb"/> was found.</returns>
		public override bool TryGetValue(string verb, out CommandVerb value)
		{
			value = null;
			if (!ContainsKey(verb)) return false;
			value = new CommandVerb(baseKey.OpenSubKey(verb, !readOnly), verb, readOnly);
			return true;
		}
	}

	/// <summary>A virtual dictionary that is based on values in the Windows Registry.</summary>
	/// <typeparam name="T">Type used to capture multiple values within the registry.</typeparam>
	/// <seealso cref="Vanara.Collections.VirtualReadOnlyDictionary{string, T}"/>
	public abstract class RegistryBasedVirtualDictionary<T> : VirtualReadOnlyDictionary<string, T>
	{
		/// <summary>Read-only flag.</summary>
		protected readonly bool readOnly;

		/// <summary>The base registry key for this dictionary.</summary>
		protected RegistryKey baseKey;

		/// <summary>Initializes a new instance of the <see cref="RegistryBasedVirtualDictionary{T}"/> class.</summary>
		/// <param name="baseKey">The base registry key.</param>
		/// <param name="readOnly">if set to <see langword="true"/> render this dictionary read-only.</param>
		protected RegistryBasedVirtualDictionary(RegistryKey baseKey, bool readOnly)
		{
			this.baseKey = baseKey;
			this.readOnly = readOnly;
		}

		/// <summary>Get the filtered list of keys under the base.</summary>
		public override IEnumerable<string> Keys => baseKey?.GetSubKeyNames().Where(SubKeyFilter) ?? new string[0];

		/// <summary>Determines if a specified key is in the filtered list of keys under the base.</summary>
		/// <param name="key">The name of the key to check.</param>
		/// <returns><see langword="true"/> if the key is found; otherwise <see langword="false"/>.</returns>
		public override bool ContainsKey(string key) => (baseKey?.HasSubKey(key) ?? false) && SubKeyFilter(key);

		/// <summary>
		/// Returns a value that indicates if the provided <paramref name="keyName"/> value should be included in the list of available keys.
		/// </summary>
		/// <param name="keyName">Name of the key.</param>
		/// <returns><see langword="true"/> if <paramref name="keyName"/> is an included key; otherwise <see langword="false"/>.</returns>
		protected virtual bool SubKeyFilter(string keyName) => true;
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

		public ProgIdDictionary(bool readOnly) : base(Registry.ClassesRoot, readOnly)
		{
		}

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
		public ShellAssociationDictionary(bool readOnly) : base(Registry.ClassesRoot, readOnly)
		{
		}

		public override bool TryGetValue(string key, out ShellAssociation value)
		{
			value = null;
			if (!ContainsKey(key)) return false;
			value = ShellAssociation.FromFileExtension(key);
			return !(value is null);
		}

		protected override bool SubKeyFilter(string keyName) => keyName.StartsWith(".");
	}
}