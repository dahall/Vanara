using Microsoft.CodeAnalysis.CSharp;
using System.Collections.Immutable;
using System.ComponentModel.Design;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Vanara.Generators;

/// <summary>
/// A source generator that creates extension methods for types based on the presence of the <c>AddAsMemberAttribute</c> on method parameters.
/// </summary>
//[Generator]
internal sealed class AddAsMemberGenerator : IIncrementalGenerator
{
	/// <inheritdoc/>
	public void Initialize(IncrementalGeneratorInitializationContext context)
	{
		var decl = context.SyntaxProvider.ForAttributeWithMetadataName("Vanara.PInvoke.AddAsMemberAttribute", IsValidSyntax,
			(ctx, _) => (ParameterSyntax)ctx.TargetNode);

		var defferals = context.SyntaxProvider.ForAttributeWithMetadataName("Vanara.PInvoke.DeferAutoMethodFromAttribute",
			(syntaxNode, cancellationToken) => syntaxNode is StructDeclarationSyntax or ClassDeclarationSyntax && ((TypeDeclarationSyntax)syntaxNode).IsPartial(),
			(ctx, _) => (TypeDeclarationSyntax)ctx.TargetNode);

		var handlesFiles = HandlesFromFileGenerator.GetHandleFileContentProvider(context);

		// Combine compilation, parameters, and handles.csv files
		var source = context.CompilationProvider
			.Combine(decl.Collect())
			.Combine(defferals.Collect())
			.Combine(handlesFiles)
			.WithTrackingName("Syntax");

		context.RegisterSourceOutput(source, (spc, value) =>
			GenerateCode(spc, value.Left.Left.Left, value.Left.Left.Right, value.Left.Right, value.Right));
	}

	private static bool IsValidSyntax(SyntaxNode syntaxNode, CancellationToken cancellationToken) =>
		syntaxNode is ParameterSyntax ps && ps.Parent?.Parent is MethodDeclarationSyntax ms && !ms.Modifiers.Any(SyntaxKind.NewKeyword) && ms.Modifiers.Any(SyntaxKind.StaticKeyword);

	private static void GenerateCode(SourceProductionContext context, Compilation compilation, ImmutableArray<ParameterSyntax> paramNodes, ImmutableArray<TypeDeclarationSyntax> defferalNodes, ImmutableArray<AdditionalText> addtlFiles)
	{
		INamedTypeSymbol? addAsMemberAttr = compilation.GetTypeByMetadataName("Vanara.PInvoke.AddAsMemberAttribute");
		if (addAsMemberAttr is null) return;

		// Process handlesCsv to get list of new types
		var handles = HandlesFromFileGenerator.EnumHandleModels(context, addtlFiles).Select(h => (ns: h.Namespace, parent: h.ParentClassName, handle: h.HandleName, safehandle: h.ClassName)).ToList();

		// Find all methods with parameters decorated with [AddAsMember] and their associated parameter types
		var typeMethods = paramNodes.Select(p => (ts: (INamedTypeSymbol)compilation.GetSemanticModel(p.SyntaxTree).GetDeclaredSymbol(p)!.Type, p)).ToList();

		// Get the types referenced by the first parameter of the DeferAutoMethodFromAttribute attribute on each defferalNode
		var defferalTypeSymbols = defferalNodes
			.Select(dn => (dn, t: compilation.GetSemanticModel(dn.SyntaxTree).GetDeclaredSymbol(dn)))
			.Select(dnt => (deferToNamespace: dnt.t?.ContainingNamespace.ToDisplayString(),
				deferToParent: dnt.t?.ContainingType.GetSyntax<ClassDeclarationSyntax>(),
				deferFrom: dnt.dn.AttributeLists.SelectMany(al => al.Attributes)
					.Where(a => a.Name.ToFullString() is "Vanara.PInvoke.DeferAutoMethodFromAttribute")
					.Select(a => (a.ArgumentList?.Arguments.FirstOrDefault()?.Expression as TypeOfExpressionSyntax)?.Type?.GetSymbol(compilation) as INamedTypeSymbol)
					.FirstOrDefault(ts => ts is not null),
				deferTo: dnt.t?.GetSyntax<ClassDeclarationSyntax>())).ToList();

		// Group by parameter type and generate partial classes with all relevant methods
		foreach (var group in typeMethods.GroupBy(i => i.ts, i => i.p, SymbolEqualityComparer.Default))
		{
			var paramType = group?.Key as INamedTypeSymbol;

			// See if the paramType is the same as the constructor type value for the DeferAutoMethodFromAttribute attribute on any of the deferralNodes values and get that type value
			var defType = defferalNodes.Select(dn => compilation.GetSemanticModel(dn.SyntaxTree).GetDeclaredSymbol(dn)).FirstOrDefault(dn => SymbolEqualityComparer.Default.Equals(dn, paramType));
			if (defType is not null)
				continue;

			int typeIdx = handles.FindIndex(t => t.handle == paramType?.Name || t.safehandle == paramType?.Name);

			// Validate that the parameter type is a class or struct and is declared as partial
			if (typeIdx == -1 && (paramType is null || (paramType.TypeKind != TypeKind.Class && paramType.TypeKind != TypeKind.Struct))) // || !paramType.IsPartial())
			{
				context.ReportError(group.First(), "VANGEN041", $"The AddAsMember parameter refers to '{paramType?.Name ?? "null"}' which is not defined as a class or struct. (Type={paramType?.TypeKind})");
				continue;
			}

			// We can't extend types not defined in this compilation
			if (typeIdx == -1 && !paramType!.IsDefinedInternally(compilation))
			{
				context.ReportError(group.First(), "VANGEN043", $"The AddAsMember parameter refers to '{paramType?.Name ?? "null"}' which is not defined in this assembly.");
				continue;
			}

			List<UsingDirectiveSyntax> usings = [];
			// Generate method declarations for all methods tied to a specific type
			var methodDecls = group.Select(param =>
			{
				var method = (MethodDeclarationSyntax)param.Parent!.Parent!;

				// Build argument list for invocation
				List<ParameterSyntax> toIgnore = [];
				var argList = ArgumentList(SeparatedList(method.ParameterList.Parameters.Select(p => {
					if (p.AttributeLists.SelectMany(al => al.Attributes).Count(a => a.Name.ToString() is "Optional" or "Ignore") == 2)
					{
						toIgnore.Add(p);
						return Argument(DefaultExpression(p.Type!));
					}
					if (p.IsEquivalentTo(param))
					{
						toIgnore.Add(p);
						return Argument(ThisExpression());
					}
					return p.ParamToArg();
				})));

				// Build invocation expression
				var methParName = compilation.GetSemanticModel(method.SyntaxTree).GetDeclaredSymbol(method)?.ContainingType.ToDisplayString(SymbolDisplayFormat.FullyQualifiedFormat);
				var invocation = InvocationExpression(
					MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression,
						IdentifierName(methParName!),
						IdentifierName(method.Identifier.Text)),
					argList
				);
				var typeArgList = method.TypeParameterList is not null ?
					TypeArgumentList(SeparatedList(method.TypeParameterList.Parameters.Select(tp => ParseTypeName(tp.Identifier.Text)))) :
					null;
				if (typeArgList is not null)
					invocation = invocation.WithExpression(GenericName(Identifier($"{methParName}.{method.Identifier.Text}"), typeArgList));

				// Get the parameters excluding the one with [AddAsMember] for the new method and all ignored values
				var newParams = method.ParameterList.Parameters.ToList();
				newParams.RemoveAll(p => toIgnore.Contains(p));

				// Reformat XML docs by removing param nodes for ignored parameters and the one with [AddAsMember]
				var xmlDoc = method.GetDocs();
				if (xmlDoc is not null)
				{
					foreach (var p in toIgnore.Concat([param]))
					{
						var paramNode = xmlDoc.SelectSingleNode($"/xmlDoc/param[@name='{p.Identifier.Text}']");
						paramNode?.ParentNode?.RemoveChild(paramNode);
					}
				}

				// Collect all using directives from the 'param''s syntax tree
				usings.AddRange(param.SyntaxTree.GetRoot().DescendantNodes().OfType<UsingDirectiveSyntax>());

				// Build method declaration
				var mdecl = MethodDeclaration(ParseTypeName(method.ReturnType.ToFullString()), method.Identifier.Text)
					.WithModifiers(TokenList(Token(SyntaxKind.PublicKeyword)))
					.WithConstraintClauses(method.ConstraintClauses)
					.WithParameterList(ParameterList(SeparatedList(newParams)))
					.WithExpressionBody(ArrowExpressionClause(Token(SyntaxKind.EqualsGreaterThanToken), invocation))
					.WithSemicolonToken(Token(SyntaxKind.SemicolonToken))
					.WithDocs(xmlDoc);

				if (method.TypeParameterList is not null)
					mdecl = mdecl.WithTypeParameterList(method.TypeParameterList);

				return mdecl;
			}).ToList();

			TypeDeclarationSyntax? classDecl = null;
			string ns = "";

			if (typeIdx >= 0)
			{
				if (!string.IsNullOrEmpty(handles[typeIdx].safehandle))
				{
					classDecl = ClassDeclaration(handles[typeIdx].safehandle!)
						.WithModifiers(TokenList(Token(SyntaxKind.PublicKeyword), Token(SyntaxKind.PartialKeyword)))
						.WithMembers(List<MemberDeclarationSyntax>(methodDecls));

				}
				else if (!string.IsNullOrEmpty(handles[typeIdx].handle))
				{
					classDecl = StructDeclaration(handles[typeIdx].handle)
						.WithModifiers(TokenList(Token(SyntaxKind.PublicKeyword), Token(SyntaxKind.PartialKeyword)))
						.WithMembers(List<MemberDeclarationSyntax>(methodDecls));
				}
				else
				{
					context.ReportError(group.First(), "VANGEN044", $"Could not generate class for type '{paramType!.Name}'. Bad handle file definition.");
					continue;
				}
				if (!string.IsNullOrEmpty(handles[typeIdx].parent))
				{
					classDecl = ClassDeclaration(handles[typeIdx].parent)
						.WithModifiers(TokenList(Token(SyntaxKind.PublicKeyword), Token(SyntaxKind.PartialKeyword)))
						.AddMembers(classDecl);
				}

				ns = handles[typeIdx].ns;
			}
			else if (defferalTypeSymbols.Select(i => i.deferFrom)
				.FirstOrDefault(t => SymbolEqualityComparer.Default.Equals(t, paramType)) is INamedTypeSymbol ts)
			{

			}
			else
			{
				// Build partial class with members
				INamedTypeSymbol? parent = paramType;
				classDecl = Util.GetTypeDeclaration(parent!)
					.WithModifiers(TokenList(parent!.DeclaredAccessibility.ToTokens()).Add(Token(SyntaxKind.PartialKeyword)))
					.WithMembers(List<MemberDeclarationSyntax>(methodDecls));

				// Nest class within any containing types
				while (classDecl is not null && (parent = parent!.ContainingType) is not null)
					classDecl = Util.GetTypeDeclaration(parent)
						.WithModifiers(TokenList(parent.DeclaredAccessibility.ToTokens()).Add(Token(SyntaxKind.PartialKeyword)))
						.AddMembers(classDecl);

				ns = paramType!.ContainingNamespace.ToDisplayString();
			}

			if (classDecl is null)
			{
				context.ReportError(group.First(), "VANGEN042", $"Could not generate class for type '{paramType!.Name}'.");
				continue;
			}

			// Build namespace
			CSharpSyntaxNode nsDecl = (CSharpSyntaxNode?)NamespaceDeclaration(ParseName(ns)).WithMembers(SingletonList<MemberDeclarationSyntax>(classDecl)) ??
				CompilationUnit().WithMembers(SingletonList<MemberDeclarationSyntax>(classDecl));

			// Add distinct using directives from 'usings' to the compilation unit
			usings = usings.Select(u => u.Name?.ToString()).Distinct().Where(u => u is not null).Select(u => UsingDirective(ParseName(u!))).ToList();
			if (usings.Count > 0)
			{
				if (nsDecl is CompilationUnitSyntax cu)
					nsDecl = cu.AddUsings(usings.ToArray());
				else
					nsDecl = ((NamespaceDeclarationSyntax)nsDecl).AddUsings(usings.ToArray());
			}

			// Output
			context.AddSource($"{paramType!.Name}_AddAsMember.g.cs", "#nullable enable\r\n" + nsDecl.NormalizeWhitespace().ToFullString());
		}
	}
}