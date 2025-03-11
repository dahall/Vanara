namespace Vanara.Generators;

internal static class Util
{
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