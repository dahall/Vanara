using Microsoft.CodeAnalysis.CSharp;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Vanara.Generators;

internal static class TypeDeclarationSyntaxExtensions
{
	public static AttributeSyntax? GetAttr(this ParameterSyntax param, string name) =>
		param.AttributeLists.SelectMany(al => al.Attributes).FirstOrDefault(a => a.NameEquals(name));

	public static VariableDeclarationSyntax CreateArrayVariableDeclaration(this ArrayTypeSyntax arrayType, string varName, string countVarName) =>
		VariableDeclaration(arrayType.WithRankSpecifiers(SingletonList(ArrayRankSpecifier())),
			SingletonSeparatedList(VariableDeclarator(Identifier(varName)).WithInitializer(EqualsValueClause(ParseExpression($"new {arrayType.ElementType}[{countVarName}]"))))
		);

	public static bool NameEquals(this ArgumentSyntax arg, string name) =>
		(arg.NameColon?.Name.Identifier.Text == name) || (arg.Expression is IdentifierNameSyntax ins && ins.Identifier.Text == name);

	public static void Remove(this List<ParameterSyntax> values, string name)
	{
		var idx = values.FindIndex(t => t.Identifier.Text == name);
		if (idx >= 0)
			values.RemoveAt(idx);
	}

	public static void Replace<T>(this List<T> values, T match, T replacement) where T : SyntaxNode
	{
		var idx = values.FindIndex(t => t.IsEquivalentTo(match));
		if (idx >= 0)
			values[idx] = replacement;
	}

	public static bool IsPartial(this TypeDeclarationSyntax tds) =>
		tds.Modifiers.Any(m => m.IsKind(SyntaxKind.PartialKeyword));

	public static bool IsGeneric(this TypeDeclarationSyntax tds) =>
		tds.TypeParameterList is { Parameters.Count: > 0 };

	public static void ReportError(this SourceProductionContext context, string id, string message, params string[] fields) =>
		context.ReportDiagnostic(Diagnostic.Create(new DiagnosticDescriptor(id, "Error", message, "Vanara.Generator", DiagnosticSeverity.Error, true, string.Join("\r\n", fields)), Location.None));

	public static void ReportError(this SourceProductionContext context, SyntaxNode node, string id, string message, params string[] fields) =>
		context.ReportDiagnostic(Diagnostic.Create(new DiagnosticDescriptor(id, "Error", message, "Vanara.Generator", DiagnosticSeverity.Error, true, string.Join("\r\n", fields)), Location.Create(node.SyntaxTree, node.Span)));

	public static void ReportStatus(this SourceProductionContext context, SyntaxNode node, string id, string message, params string[] fields) =>
		context.ReportDiagnostic(Diagnostic.Create(new DiagnosticDescriptor(id, "Status", message, "Vanara.Generator", DiagnosticSeverity.Info, true, string.Join("\r\n", fields)), Location.Create(node.SyntaxTree, node.Span)));
}