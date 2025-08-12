namespace Vanara.Generators;

/// <summary>Represents handles.</summary>
internal record HandleModel(string Namespace, string ParentClassName, string HandleName, string interfaceName, string? SummaryText = null, string? ClassName = null, string? baseClassName = null, string? closeCode = null, string? InheritedHandleName = null)
{
	private const string handleTemplateResourceName = "Vanara.Generators.HandleTemplate.cs";
	private const string safeHandleTemplateResourceName = "Vanara.Generators.SafeHandleTemplate.cs";
	private static string? handleTemplateText, safeHandleTemplateText = null;

	public string BaseClassName { get; } = string.IsNullOrWhiteSpace(baseClassName) ? "Vanara.PInvoke.SafeHANDLE" : baseClassName!;
	public string CloseCode { get; } = string.IsNullOrWhiteSpace(closeCode) ? "" : (closeCode!.Trim().StartsWith("{") ? closeCode : $"=> {closeCode};");
	public string InterfaceName { get; } = string.IsNullOrWhiteSpace(interfaceName) ? "Vanara.PInvoke.IHandle" : interfaceName!;

	public string GetHandleCode()
	{
		handleTemplateText ??= Util.ReadAllTextFromAsmResource(handleTemplateResourceName);
		var templateText = ReplaceMarker(handleTemplateText, "#1#", ParentClassName);
		templateText = ReplaceMarker(templateText, "#2#", InheritedHandleName);
		templateText = ReplaceMarker(templateText, "#3#", ClassName);
		return Util.ReplaceWholeWords(templateText, new Dictionary<string, string>()
		{
			{ "HandleName", HandleName },
			{ "Namespace", Namespace },
			{ "ClassName", ClassName ?? "" },
			{ "ParentClassName", ParentClassName },
			{ "InterfaceName", InterfaceName.Qualify(Namespace, ParentClassName)! },
			{ "SummaryText", SummaryText is null ? "" : $"/// <summary>{SummaryText}</summary>\r\n" },
			{ "InheritedHandleName", InheritedHandleName ?? "" },
		});
	}

	public string GetSafeHandleCode(string summaryText = "", bool addHandleRefStub = false)
	{
		safeHandleTemplateText ??= Util.ReadAllTextFromAsmResource(safeHandleTemplateResourceName);
		var templateText = ReplaceMarker(safeHandleTemplateText, "#1#", ParentClassName);
		templateText = ReplaceMarker(templateText, "#2#", HandleName.Qualify(Namespace, ParentClassName));
		templateText = ReplaceMarker(templateText, "#3#", InheritedHandleName);
		templateText = ReplaceMarker(templateText, "#4#", CloseCode);
		templateText = ReplaceMarker(templateText, "#5#", string.IsNullOrEmpty(HandleName) ? "IntPtr" : "");
		templateText = ReplaceMarker(templateText, "#6#", addHandleRefStub ? HandleName : null);
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
		});
	}

	private string ReplaceMarker(string templateText, string marker, string? repl) =>
		Regex.Replace(templateText, string.IsNullOrWhiteSpace(repl) ? $"{marker}(?s).*?{marker}" : marker, "");
}