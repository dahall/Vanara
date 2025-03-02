using Microsoft.CodeAnalysis.CSharp;

namespace Vanara.Generators;

internal static class TypeDeclarationSyntaxExtensions
{
	public static bool IsPartial(this TypeDeclarationSyntax tds) =>
		tds.Modifiers.Any(m => m.IsKind(SyntaxKind.PartialKeyword));

	public static bool IsGeneric(this TypeDeclarationSyntax tds) =>
		tds.TypeParameterList is { Parameters.Count: > 0 };

	public static void ReportError(this SourceProductionContext context, string id, string message, params string[] fields) =>
		context.ReportDiagnostic(Diagnostic.Create(new DiagnosticDescriptor(id, "Error", message, "Vanara.Generator", DiagnosticSeverity.Error, true, customTags: fields), Location.None));
}