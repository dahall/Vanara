using SmallestCSV;

namespace Vanara.Generators;

/// <summary>Represents handles.</summary>
internal record HandleModel(string Namespace, string ParentClassName, string HandleName, string interfaceName, string? SummaryText = null, string? ClassName = null, string? baseClassName = null, string? closeCode = null, string? InheritedHandleName = null, IEnumerable<string>? AdjNameRegex = null)
{
	private const string handleTemplateResourceName = "Vanara.Generators.HandleTemplate.cs";
	private const string safeHandleTemplateResourceName = "Vanara.Generators.SafeHandleTemplate.cs";
	private static string? handleTemplateText, safeHandleTemplateText = null;

	public string BaseClassName { get; } = string.IsNullOrWhiteSpace(baseClassName) ? "Vanara.PInvoke.SafeHANDLE" : baseClassName!;
	public string CloseCode { get; } = string.IsNullOrWhiteSpace(closeCode) ? "" : (closeCode!.Trim().StartsWith("{") ? closeCode : $"=> {closeCode};");
	public string InterfaceName { get; } = string.IsNullOrWhiteSpace(interfaceName) ? "Vanara.PInvoke.IHandle" : interfaceName!;

	internal bool HasHandle => HandleName != string.Empty && InterfaceName != string.Empty && SummaryText != string.Empty;
	internal bool HasSafeHandle => !string.IsNullOrEmpty(ClassName) && !string.IsNullOrEmpty(BaseClassName);

	public string GetHandleCode()
	{
		handleTemplateText ??= Util.ReadAllTextFromAsmResource(handleTemplateResourceName);
		var templateText = ReplaceMarker(handleTemplateText, "#1#", ParentClassName);
		templateText = ReplaceMarker(templateText, "#2#", InheritedHandleName);
		templateText = ReplaceMarker(templateText, "#3#", ClassName);
		templateText = ReplaceMarker(templateText, "#4#", AdjNameRegex is null ? null : "X");
		return Util.ReplaceWholeWords(templateText, new Dictionary<string, string>()
		{
			{ "HandleName", HandleName },
			{ "Namespace", Namespace },
			{ "ClassName", ClassName ?? "" },
			{ "ParentClassName", ParentClassName },
			{ "InterfaceName", InterfaceName.Qualify(Namespace, ParentClassName)! },
			{ "SummaryText", SummaryText is null ? "" : $"/// <summary>{SummaryText}</summary>\r\n" },
			{ "InheritedHandleName", InheritedHandleName ?? "" },
			{ "AdjNameRegex", AdjNameRegex is null ? "" : string.Join(", ", AdjNameRegex.Select(s => $"@\"{s}\"")) },
		});
	}

	public string GetSafeHandleCode(string summaryText = "", bool addHandleRefStub = false)
	{
		safeHandleTemplateText ??= Util.ReadAllTextFromAsmResource(safeHandleTemplateResourceName);
		var templateText = ReplaceMarker(safeHandleTemplateText, "#1#", ParentClassName);
		templateText = HandleModel.ReplaceMarker(templateText, "#2#", HandleName.Qualify(Namespace, ParentClassName));
		templateText = ReplaceMarker(templateText, "#3#", InheritedHandleName);
		templateText = ReplaceMarker(templateText, "#4#", CloseCode);
		templateText = ReplaceMarker(templateText, "#5#", string.IsNullOrEmpty(HandleName) ? "IntPtr" : "");
		templateText = ReplaceMarker(templateText, "#6#", addHandleRefStub ? HandleName : null);
		templateText = ReplaceMarker(templateText, "#7#", AdjNameRegex is null ? null : "X");
		return Util.ReplaceWholeWords(templateText, new Dictionary<string, string>()
		{
			{ "HandleName", HandleName.Qualify(Namespace, ParentClassName)! },
			{ "Namespace", Namespace },
			{ "ParentClassName", ParentClassName },
			{ "ClassName", ClassName ?? "" },
			{ "SummaryText", summaryText },
			{ "BaseClassName", BaseClassName.Qualify(Namespace, ParentClassName) + (Regex.IsMatch(InterfaceName, @"\bIHandle\b") ? "" : $", {InterfaceName}") },
			{ "CloseCode", CloseCode },
			{ "InheritedHandleName", InheritedHandleName ?? "" },
			{ "AdjNameRegex", AdjNameRegex is null ? "" : string.Join(", ", AdjNameRegex.Select(s => $"@\"{s}\"")) },
		});
	}

	private static List<(string, string)> MakePairs(IEnumerable<string>? adjNameRegex)
	{
		List<(string, string)> list = [];
		if (adjNameRegex is not null)
		{
			for (int i = 0; i < adjNameRegex.Count(); i += 2)
			{
				var pattern = adjNameRegex.ElementAt(i);
				var repl = (i + 1) < adjNameRegex.Count() ? adjNameRegex.ElementAt(i + 1) : "";
				list.Add((pattern, repl));
			}
		}
		return list;
	}

	private static string ReplaceMarker(string templateText, string marker, string? repl) =>
		Regex.Replace(templateText, string.IsNullOrWhiteSpace(repl) ? $"{marker}(?s).*?{marker}" : marker, "");

	public static IEnumerable<HandleModel> FromStream(TextReader reader)
	{
		var csv = new SmallestCSVParser(reader, true);
		while (true)
		{
			var r = csv.ReadNextRow();
			if (r is null)
				yield break;
			yield return new HandleModel(r[0], r[1], r[2], r[3], r[4], r[5], r[6], r[7], r.Count > 8 ? r[8] : null, r.Count > 9 ? r.Skip(9) : null);
		}
	}
}