namespace Vanara.Generators;

internal static class Util
{
	public static string? Qualify(this string? name, string ns, string? parent = null)
	{
		System.Diagnostics.Debug.Write($"{name} (NS:{ns}, P:{parent}) => ");
		if (string.IsNullOrWhiteSpace(name)) return name;
		if (string.IsNullOrWhiteSpace(ns)) return name;
		name = parent is not null && name!.StartsWith(parent + '.') ? name.Substring(parent.Length + 1) : name;
		var prefix = ns + '.' + (string.IsNullOrWhiteSpace(parent) ? "" : $"{parent}.");
		string? retVal;
		if (name!.StartsWith(prefix))
			retVal = name.Substring(prefix.Length);
		else if (name.StartsWith(ns + '.'))
			retVal = name.Substring(ns.Length + 1);
		else
			retVal = (name.Contains('.') ? $"{name}" : name);
		System.Diagnostics.Debug.WriteLine(retVal);
		return retVal;
	}

	public static string ReadAllTextFromAsmResource(string resourceName)
	{
		using var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName);
		using var reader = new StreamReader(stream);
		return reader.ReadToEnd();
	}

	public static string ReplaceWholeWords(string text, IReadOnlyDictionary<string, string> wordMap)
	{
		var regex = new Regex(string.Join("|", wordMap.Keys.Select(k => @$"\b{Regex.Escape(k)}\b")));
		return regex.Replace(text, m => wordMap[m.Value]);
	}
}