using Microsoft.CodeAnalysis.CSharp;
using System.Collections.Immutable;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Vanara.Generators;

[Flags]
internal enum ModType
{
	In = 1,
	Out = 2,
	Ref = 3
}

internal static class TypeDeclarationSyntaxExtensions
{
	public static INamedTypeSymbol? AutoSafeHandleType((TypeDeclarationSyntax type, ImmutableArray<AttributeData> attrDatas) ta) =>
		ta.attrDatas.First().ConstructorArguments.Skip(1).FirstOrDefault(a => a.Value is INamedTypeSymbol).Value as INamedTypeSymbol;

	public static VariableDeclarationSyntax CreateArrayVariableDeclaration(this ArrayTypeSyntax arrayType, string varName, string countVarName) =>
		VariableDeclaration(arrayType.WithRankSpecifiers(SingletonList(ArrayRankSpecifier())),
			SingletonSeparatedList(VariableDeclarator(Identifier(varName)).WithInitializer(EqualsValueClause(ParseExpression($"new {arrayType.ElementType}[{countVarName}]"))))
		);

	public static INamedTypeSymbol? DeferMethType((TypeDeclarationSyntax type, ImmutableArray<AttributeData> attrDatas) ta) =>
		ta.attrDatas.First().ConstructorArguments.FirstOrDefault(a => a.Value is INamedTypeSymbol).Value as INamedTypeSymbol;

	public static AttributeSyntax? GetAttr(this ParameterSyntax param, string name) =>
		param.AttributeLists.SelectMany(al => al.Attributes).FirstOrDefault(a => a.NameEquals(name));

	public static MethodDeclarationSyntax? GetMethodFromNode(SyntaxNode n) => n switch
	{
		ParameterSyntax ps when ps.Parent?.Parent is MethodDeclarationSyntax mds => mds,
		MethodDeclarationSyntax mds2 => mds2,
		_ => n.AncestorsAndSelf().OfType<MethodDeclarationSyntax>().FirstOrDefault()
	};

	public static ModType GetModType(ParameterSyntax p)
	{
		if (p.Modifiers.Any(SyntaxKind.OutKeyword)) return ModType.Out;
		if (p.Modifiers.Any(SyntaxKind.RefKeyword)) return ModType.Ref;
		if (p.Type!.ToString().StartsWith("string")) return ModType.In;
		var ret = (p.AttributeLists.SelectMany(al => al.Attributes).Any(a => a.Name.ToString() == "In") ? ModType.In : 0)
			| (p.AttributeLists.SelectMany(al => al.Attributes).Any(a => a.Name.ToString() == "Out") ? ModType.Out : 0);
		return ret == 0 ? ModType.Ref : ret;
	}

	public static TypeSyntax? GetTypeFromNode(SyntaxNode n) => n switch
	{
		ParameterSyntax ps => ps.Type!,
		MethodDeclarationSyntax mds => mds.ReturnType,
		TypeSyntax ts => ts,
		_ => null
	};

	public static bool IsGeneric(this TypeDeclarationSyntax tds) =>
		tds.TypeParameterList is { Parameters.Count: > 0 };

	public static bool IsNestedMethWithParamOrReturnAttr(SyntaxNode syntaxNode, CancellationToken cancellationToken) =>
		GetMethodFromNode(syntaxNode) is MethodDeclarationSyntax ms
			&& !ms.Modifiers.Any(SyntaxKind.UnsafeKeyword) && !ms.Modifiers.Any(SyntaxKind.NewKeyword)
			&& !ms.AttributeLists.SelectMany(al => al.Attributes).Any(a => a.Name.ToString().Contains("SuppressAutoGen"))
			&& (ms?.Parent is ClassDeclarationSyntax cs && cs.IsPartial() && ms.Modifiers.Any(SyntaxKind.StaticKeyword) ||
				ms?.Parent is InterfaceDeclarationSyntax && ms?.Parent?.Parent is ClassDeclarationSyntax ccs && ccs.IsPartial());

	public static bool IsOptional(ParameterSyntax p) => p.AttributeLists.SelectMany(al => al.Attributes).Any(a => a.Name.ToString() == "Optional") ||
		p.Default is not null;

	public static bool IsParamInNestedType(SyntaxNode syntaxNode, CancellationToken cancellationToken) =>
		IsParamInMethod(syntaxNode, cancellationToken, out var ms) &&
		(ms?.Parent is ClassDeclarationSyntax cs && cs.IsPartial() && ms.Modifiers.Any(SyntaxKind.StaticKeyword) && ms.Modifiers.Any(SyntaxKind.PublicKeyword) ||
		ms?.Parent is InterfaceDeclarationSyntax && ms?.Parent?.Parent is ClassDeclarationSyntax ccs && ccs.IsPartial());

	public static bool IsPartial(this TypeDeclarationSyntax tds) =>
		tds.Modifiers.Any(m => m.IsKind(SyntaxKind.PartialKeyword));

	public static bool IsPartialType(SyntaxNode syntaxNode, CancellationToken _) => syntaxNode is TypeDeclarationSyntax tds && tds.IsPartial();

	public static bool NameEquals(this ArgumentSyntax arg, string name) =>
		(arg.NameColon?.Name.Identifier.Text == name) || (arg.Expression is IdentifierNameSyntax ins && ins.Identifier.Text == name);

	public static TypeDeclarationSyntax ParentForExtMethod(SourceProductionContext context, SyntaxNode decl, Compilation compilation)
	{
		var meth = GetMethodFromNode(decl);
		var parentClass = meth?.Parent is ClassDeclarationSyntax cs ? cs : (meth?.Parent is InterfaceDeclarationSyntax && meth?.Parent?.Parent is ClassDeclarationSyntax ccs ? ccs : null);
		if (parentClass == null)
			context.ReportError(decl, "VANGEN020", "Unable to find the parent class into which to insert the methods.");
		return parentClass!;
	}

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

	public static void ReportError(this SourceProductionContext context, string id, string message, params string[] fields) =>
		context.ReportDiagnostic(Diagnostic.Create(new DiagnosticDescriptor(id, "Error", message, "Vanara.Generator", DiagnosticSeverity.Error, true, string.Join("\r\n", fields)), Location.None));

	public static void ReportError(this SourceProductionContext context, SyntaxNode node, string id, string message, params string[] fields) =>
		context.ReportDiagnostic(Diagnostic.Create(new DiagnosticDescriptor(id, "Error", message, "Vanara.Generator", DiagnosticSeverity.Error, true, string.Join("\r\n", fields)), Location.Create(node.SyntaxTree, node.Span)));

	public static void ReportStatus(this SourceProductionContext context, SyntaxNode node, string id, string message, params string[] fields) =>
		context.ReportDiagnostic(Diagnostic.Create(new DiagnosticDescriptor(id, "Status", message, "Vanara.Generator", DiagnosticSeverity.Info, true, string.Join("\r\n", fields)), Location.Create(node.SyntaxTree, node.Span)));

	public static TypeSyntax WithoutNullable(this TypeSyntax typeSyntax) => typeSyntax is NullableTypeSyntax nullableTypeSyntax ? nullableTypeSyntax.ElementType : typeSyntax;

	// Confirm param is in a method is not new or unsafe and does not have SuppressAutoGen attribute
	private static bool IsParamInMethod(SyntaxNode syntaxNode, CancellationToken _, out MethodDeclarationSyntax? ms)
	{
		ms = syntaxNode is ParameterSyntax ps && ps.Parent?.Parent is MethodDeclarationSyntax mds
			&& !mds.Modifiers.Any(SyntaxKind.UnsafeKeyword) && !mds.Modifiers.Any(SyntaxKind.NewKeyword)
			&& !mds.AttributeLists.SelectMany(al => al.Attributes).Any(a => a.Name.ToString().Contains("SuppressAutoGen")) ? mds : null;
		return ms is not null;
	}
}