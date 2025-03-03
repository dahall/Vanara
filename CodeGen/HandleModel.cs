namespace Vanara.Generators;

/// <summary>Represents handles.</summary>
internal record HandleModel(string Namespace, string ParentClassName, string HandleName, string InterfaceName, string? SummaryText = null, string? ClassName = null, string? BaseClassName = null, string? CloseCode = null, string? InheritedHandleName = null)
{
	private const string handleTemplateResourceName = "Vanara.Generators.HandleTemplate.cs";
	private const string safeHandleTemplateResourceName = "Vanara.Generators.SafeHandleTemplate.cs";
	private static string? handleTemplateText, safeHandleTemplateText = null;

	public string GetHandleCode()
	{
		handleTemplateText ??= Util.ReadAllTextFromAsmResource(handleTemplateResourceName);
		var templateText = ReplaceMarker(handleTemplateText, "#1#", ParentClassName);
		templateText = ReplaceMarker(templateText, "#2#", InheritedHandleName);
		return Util.ReplaceWholeWords(templateText, new Dictionary<string, string>()
		{
			{ "HandleName", HandleName },
			{ "Namespace", Namespace },
			{ "ParentClassName", ParentClassName },
			{ "InterfaceName", InterfaceName },
			{ "SummaryText", SummaryText is null ? "" : $"/// <summary>{SummaryText}</summary>\r\n" },
			{ "InheritedHandleName", InheritedHandleName ?? "" },
		});
	}

	public string GetSafeHandleCode(string summaryText = "")
	{
		safeHandleTemplateText ??= Util.ReadAllTextFromAsmResource(safeHandleTemplateResourceName);
		var templateText = ReplaceMarker(safeHandleTemplateText, "#1#", ParentClassName);
		templateText = ReplaceMarker(templateText, "#2#", HandleName);
		templateText = ReplaceMarker(templateText, "#3#", InheritedHandleName);
		templateText = ReplaceMarker(templateText, "#4#", CloseCode);
		var closeCode = string.IsNullOrEmpty(CloseCode) ? "" : (CloseCode!.Trim().StartsWith("{") ? CloseCode : $"=> {CloseCode};");
		return Util.ReplaceWholeWords(templateText, new Dictionary<string, string>()
		{
			{ "HandleName", HandleName },
			{ "Namespace", Namespace },
			{ "ParentClassName", ParentClassName },
			{ "ClassName", ClassName ?? "" },
			{ "SummaryText", summaryText },
			{ "BaseClassName", BaseClassName ?? ""},
			{ "CloseCode", closeCode },
			{ "InheritedHandleName", InheritedHandleName ?? "" },
		});
	}

	private static string ReplaceMarker(string templateText, string marker, string? repl) =>
		Regex.Replace(templateText, string.IsNullOrEmpty(repl) ? $"{marker}(?s).*?{marker}" : marker, "");
}