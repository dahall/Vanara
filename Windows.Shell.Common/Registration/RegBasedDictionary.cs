using Microsoft.Win32;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Vanara.Collections;
using Vanara.Windows.Shell.Registration;

namespace Vanara.Windows.Shell;

/// <summary>A virtual dictionary that is based on values in the Windows Registry.</summary>
/// <typeparam name="T">Type used to capture multiple values within the registry.</typeparam>
/// <seealso cref="VirtualReadOnlyDictionary{TKey, TValue}"/>
/// <remarks>Initializes a new instance of the <see cref="RegBasedDictionary{T}"/> class.</remarks>
/// <param name="baseKey">The base registry key.</param>
/// <param name="readOnly">if set to <see langword="true"/> render this dictionary read-only.</param>
public abstract class RegBasedDictionary<T>(RegistryKey? baseKey, bool readOnly) : VirtualReadOnlyDictionary<string, T>
{
	/// <summary>Read-only flag.</summary>
	protected readonly bool readOnly = readOnly;

	/// <summary>The base registry key for this dictionary.</summary>
	protected RegistryKey? key = baseKey;

	/// <summary>Get the filtered list of keys under the base.</summary>
	public override IEnumerable<string> Keys => key?.GetSubKeyNames().Where(SubKeyFilter) ?? [];

	/// <summary>Determines if a specified key is in the filtered list of keys under the base.</summary>
	/// <param name="key">The name of the key to check.</param>
	/// <returns><see langword="true"/> if the key is found; otherwise <see langword="false"/>.</returns>
	public override bool ContainsKey(string? key) => this.key is not null && key is not null && this.key.HasSubKey(key) && SubKeyFilter(key);

	/// <summary>
	/// Returns a value that indicates if the provided <paramref name="keyName"/> value should be included in the list of available keys.
	/// </summary>
	/// <param name="keyName">Name of the key.</param>
	/// <returns><see langword="true"/> if <paramref name="keyName"/> is an included key; otherwise <see langword="false"/>.</returns>
	protected virtual bool SubKeyFilter(string keyName) => true;
}

internal class AppDictionary(bool readOnly) : RegBasedDictionary<AppRegistration>(Registry.ClassesRoot.OpenSubKey(AppRegistration.appsSubKey, !readOnly), readOnly)
{
	public override bool TryGetValue(string key, [MaybeNullWhen(false)] out AppRegistration value)
	{
		value = null;
		if (!ContainsKey(key)) return false;
		value = AppRegistration.Open(key, readOnly);
		return value is not null;
	}
}

internal class FileTypeDictionary(bool readOnly) : RegBasedDictionary<FileTypeAssociation>(Registry.ClassesRoot, readOnly)
{
	public override bool TryGetValue(string key, [MaybeNullWhen(false)] out FileTypeAssociation value)
	{
		value = null;
		if (!ContainsKey(key)) return false;
		value = FileTypeAssociation.Open(key, false, readOnly);
		return value is not null;
	}

	protected override bool SubKeyFilter(string keyName) => keyName.StartsWith(".");
}

internal class ProgIdDictionary(bool readOnly) : RegBasedDictionary<ProgId>(Registry.ClassesRoot, readOnly)
{
	private static readonly string[] badKeys =
	[
		"*", "AllFileSystemObjects", "AppID", "Applications", "AudioCD", "Briefcase", "CID", "CID.Local",
		"CLSID", "CompressedFolder", "ConflictFolder", "DVD", "DVDFile", "DesktopBackground", "DirectShow",
		"Directory", "Drive", "ExplorerCLSIDFlags", "Folder", "Interface", "LibraryFolder", "Local Settings",
		"MIME", "Media Servers", "Media Type", "MediaFoundation", "NetServer", "NetShare", "Network",
		"Printers", "Stack", "SystemFileAssociations", "TypeLib", "Unknown", "UserLibraryFolder",
		"VideoClipContainers", "VirtualStore"
	];

	public override bool TryGetValue(string key, [MaybeNullWhen(false)] out ProgId value)
	{
		value = null;
		if (!ContainsKey(key)) return false;
		value = ProgId.Open(key, readOnly, true, true);
		return true;
	}

	protected override bool SubKeyFilter(string keyName) => !keyName.StartsWith(".") &&
		!keyName.StartsWith("Kind.") && Array.BinarySearch(badKeys, keyName, StringComparer.OrdinalIgnoreCase) < 0;
}

internal class ShellAssociationDictionary(bool readOnly) : RegBasedDictionary<ShellAssociation>(Registry.ClassesRoot, readOnly)
{
	public override bool TryGetValue(string key, [MaybeNullWhen(false)] out ShellAssociation value)
	{
		value = null;
		if (!ContainsKey(key)) return false;
		value = ShellAssociation.FromFileExtension(key);
		return value is not null;
	}

	protected override bool SubKeyFilter(string keyName) => keyName.StartsWith(".");
}