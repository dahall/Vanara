using System;
using Microsoft.Win32;

namespace Vanara.Windows.Shell;

internal static class RegistryExtensions
{
	private const string improbableValue = "_aVery1mprobable*Value";

	public static RegistryKey CreateSubKey(this RegistryKey key, string subkey, string defaultValue)
	{
		var sk = key.CreateSubKey(subkey);
		if (defaultValue != null)
			sk?.SetValue(null, defaultValue);
		return sk;
	}

	public static bool DeleteAllSubItems(this RegistryKey key)
	{
		var succeeded = true;
		foreach (var n in key.GetSubKeyNames())
			try { key.DeleteSubKeyTree(n); } catch { succeeded = false; }
		foreach (var n in key.GetValueNames())
			key.DeleteValue(n);
		return succeeded;
	}

	public static Guid? GetGuidValue(this RegistryKey key, string name)
	{
		var g = key?.GetValue(name)?.ToString();
		return g != null ? new Guid(g) : (Guid?)null;
	}

	public static object GetSubKeyDefaultValue(this RegistryKey key, string subkey)
	{
		using (var sk = key.OpenSubKey(subkey))
			return sk?.GetValue(null);
	}

	public static bool HasSubKey(this RegistryKey key, string subkeyName)
	{
		using (var sk = key.OpenSubKey(subkeyName))
			return sk != null;
	}

	public static bool HasValue(this RegistryKey key, string name) => !Equals(key.GetValue(name, improbableValue), improbableValue);

	public static string ToRegString(this Guid guid) => guid.ToString("B").ToUpperInvariant();

	public static string ToRegString(this Guid? guid) => guid.HasValue ? guid.Value.ToRegString() : null;
}