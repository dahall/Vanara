using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using Vanara.Collections;
using Vanara.Windows.Shell.Registration;

namespace Vanara.Windows.Shell
{
	/// <summary>A virtual dictionary that is based on values in the Windows Registry.</summary>
	/// <typeparam name="T">Type used to capture multiple values within the registry.</typeparam>
	/// <seealso cref="Vanara.Collections.VirtualReadOnlyDictionary{TKey, TValue}"/>
	public abstract class RegBasedDictionary<T> : VirtualReadOnlyDictionary<string, T>
	{
		/// <summary>Read-only flag.</summary>
		protected readonly bool readOnly;

		/// <summary>The base registry key for this dictionary.</summary>
		protected RegistryKey key;

		/// <summary>Initializes a new instance of the <see cref="RegBasedDictionary{T}"/> class.</summary>
		/// <param name="baseKey">The base registry key.</param>
		/// <param name="readOnly">if set to <see langword="true"/> render this dictionary read-only.</param>
		protected RegBasedDictionary(RegistryKey baseKey, bool readOnly)
		{
			key = baseKey;
			this.readOnly = readOnly;
		}

		/// <summary>Get the filtered list of keys under the base.</summary>
		public override IEnumerable<string> Keys => key?.GetSubKeyNames().Where(SubKeyFilter) ?? new string[0];

		/// <summary>Determines if a specified key is in the filtered list of keys under the base.</summary>
		/// <param name="key">The name of the key to check.</param>
		/// <returns><see langword="true"/> if the key is found; otherwise <see langword="false"/>.</returns>
		public override bool ContainsKey(string key) => (this.key?.HasSubKey(key) ?? false) && SubKeyFilter(key);

		/// <summary>
		/// Returns a value that indicates if the provided <paramref name="keyName"/> value should be included in the list of available keys.
		/// </summary>
		/// <param name="keyName">Name of the key.</param>
		/// <returns><see langword="true"/> if <paramref name="keyName"/> is an included key; otherwise <see langword="false"/>.</returns>
		protected virtual bool SubKeyFilter(string keyName) => true;
	}

	internal class AppDictionary : RegBasedDictionary<AppRegistration>
	{
		public AppDictionary(bool readOnly) : base(Registry.ClassesRoot.OpenSubKey(AppRegistration.appsSubKey, !readOnly), readOnly)
		{
		}

		public override bool TryGetValue(string key, out AppRegistration value)
		{
			value = null;
			if (!ContainsKey(key)) return false;
			var sk = base.key.OpenSubKey(key, !readOnly);
			value = sk is null ? null : new AppRegistration(sk, null, readOnly);
			return !(value is null);
		}
	}

	internal class FileTypeDictionary : RegBasedDictionary<FileTypeAssociation>
	{
		public FileTypeDictionary(bool readOnly) : base(Registry.ClassesRoot, readOnly)
		{
		}

		public override bool TryGetValue(string key, out FileTypeAssociation value)
		{
			value = null;
			if (!ContainsKey(key)) return false;
			value = FileTypeAssociation.Open(key, false, readOnly);
			return !(value is null);
		}

		protected override bool SubKeyFilter(string keyName) => keyName.StartsWith(".");
	}

	internal class ProgIdDictionary : RegBasedDictionary<ProgId>
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
			value = ProgId.Open(key, readOnly);
			return true;
		}

		protected override bool SubKeyFilter(string keyName) => !keyName.StartsWith(".") &&
			!keyName.StartsWith("Kind.") && Array.BinarySearch(badKeys, keyName, StringComparer.OrdinalIgnoreCase) < 0;
	}

	internal class ShellAssociationDictionary : RegBasedDictionary<ShellAssociation>
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