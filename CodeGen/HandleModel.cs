namespace Vanara.Generators;

/// <summary>Represents handles.</summary>
internal record HandleModel(string Namespace, string HandleName, string InterfaceName, string? SummaryText = null, string? ClassName = null, string? BaseClassName = null, string? CloseCode = null)
{
	private const string handleTemplateResourceName = "Vanara.Generators.HandleTemplate.cs";
	private const string safeHandleTemplateResourceName = "Vanara.Generators.SafeHandleTemplate.cs";
	private static string? handleTemplateText, safeHandleTemplateText = null;

	public string GetHandleCode()
	{
		handleTemplateText ??= Util.ReadAllTextFromAsmResource(handleTemplateResourceName);
		return Util.ReplaceWholeWords(handleTemplateText, new Dictionary<string, string>()
		{
			{ "HandleName", HandleName },
			{ "Namespace", Namespace },
			{ "InterfaceName", InterfaceName },
			{ "SummaryText", SummaryText is null ? "" : $"/// <summary>{SummaryText}</summary>" }
		});
	}

	public string GetSafeHandleCode()
	{
		safeHandleTemplateText ??= Util.ReadAllTextFromAsmResource(safeHandleTemplateResourceName);
		return Util.ReplaceWholeWords(safeHandleTemplateText, new Dictionary<string, string>()
		{
			{ "HandleName", HandleName },
			{ "Namespace", Namespace },
			{ "ClassName", ClassName ?? "" },
			{ "BaseClassName", BaseClassName ?? ""},
			{ "CloseCode", CloseCode ?? "" }
		});
	}
}