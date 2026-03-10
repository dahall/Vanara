using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeActions;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Immutable;
using System.Collections.Generic;
using System.Composition;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Vanara.CodeGen;

/// <summary>
/// Code fix provider that offers to replace a method invocation with a call to an overload that has fewer interop-attributed parameters.
/// </summary>
[ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(PreferFewerAttributeOverloadCodeFixProvider)), Shared]
public class PreferFewerAttributeOverloadCodeFixProvider : CodeFixProvider
{
	private const string Title = "Use more optimal overload";

	/// <inheritdoc/>
	public sealed override ImmutableArray<string> FixableDiagnosticIds => [PreferFewerAttributeOverloadAnalyzer.DiagnosticId];

	/// <inheritdoc/>
	public sealed override FixAllProvider GetFixAllProvider() => WellKnownFixAllProviders.BatchFixer;

	/// <inheritdoc/>
	public sealed override async Task RegisterCodeFixesAsync(CodeFixContext context)
	{
		var root = await context.Document.GetSyntaxRootAsync(context.CancellationToken).ConfigureAwait(false);
		if (root is null) return;

		var diagnostic = context.Diagnostics[0];
		var diagnosticSpan = diagnostic.Location.SourceSpan;

		var invocation = root.FindNode(diagnosticSpan).FirstAncestorOrSelf<InvocationExpressionSyntax>();
		if (invocation is null) return;

		context.RegisterCodeFix(
			CodeAction.Create(
				title: Title,
				createChangedDocument: c => ReplaceWithFewerAttributeOverloadAsync(context.Document, invocation, c),
				equivalenceKey: Title),
			diagnostic);
	}

	private static async Task<Document> ReplaceWithFewerAttributeOverloadAsync(Document document, InvocationExpressionSyntax invocation, CancellationToken cancellationToken)
	{
		// Get the symbol for the currently called method
		var semanticModel = await document.GetSemanticModelAsync(cancellationToken).ConfigureAwait(false);
		if (semanticModel is null || semanticModel.GetSymbolInfo(invocation, cancellationToken).Symbol is not IMethodSymbol calledMethod) return document;

		// Only examine methods whose namespace starts with "Vanara"
		var containingType = calledMethod.ContainingType;
		if (containingType is null || !containingType.IsInNamespace("Vanara")) return document;

		// Find the best overload (fewest interop attributes that is still compatible)
		int calledAttrCount = calledMethod.CountInteropAttributes();
		var bestOverload = containingType.GetMembers(calledMethod.Name)
			.OfType<IMethodSymbol>()
			.Where(m => !SymbolEqualityComparer.Default.Equals(m, calledMethod) &&
						m.DeclaredAccessibility == calledMethod.DeclaredAccessibility &&
						m.IsStatic == calledMethod.IsStatic)
			.Select(m => (method: m, attrCount: m.CountInteropAttributes()))
			.Where(x => x.attrCount < calledAttrCount)
			.OrderBy(x => x.attrCount)
			.Select(x => x.method)
			.FirstOrDefault();
		if (bestOverload is null) return document;

		// Build the new argument list that matches the target overload's parameters
		var arguments = invocation.ArgumentList.Arguments;
		var newArgsList = new List<ArgumentSyntax>(bestOverload.Parameters.Length);

		for (int i = 0; i < bestOverload.Parameters.Length; i++)
		{
			var targetParam = bestOverload.Parameters[i];

			// Try to find a matching argument by name first
			var namedArg = arguments.FirstOrDefault(a =>
				a.NameColon is not null &&
				a.NameColon.Name.Identifier.ValueText == targetParam.Name);

			if (namedArg != null)
			{
				newArgsList.Add(namedArg);
			}
			else if (i < arguments.Count && arguments[i].NameColon is null)
			{
				// Use the positional argument if available
				newArgsList.Add(arguments[i]);
			}
			else if (targetParam.IsOptional)
			{
				// Skip optional parameters — they'll use their defaults
				break;
			}
		}

		var newArgumentList = SyntaxFactory.ArgumentList(SyntaxFactory.SeparatedList(newArgsList))
			.WithTriviaFrom(invocation.ArgumentList);
		var newInvocation = invocation.WithArgumentList(newArgumentList);

		var root = await document.GetSyntaxRootAsync(cancellationToken).ConfigureAwait(false);
		if (root is null) return document;

		var newRoot = root.ReplaceNode(invocation, newInvocation);
		return document.WithSyntaxRoot(newRoot);
	}
}