using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeActions;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Rename;
using Microsoft.CodeAnalysis.Simplification;
using System.Collections.Immutable;
using System.Composition;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Vanara.CodeGen
{
	/// <summary>Code fix provider for replacing <see langword="null"/> or <see langword="default"/> with the SafeHANDLE.NULL property.</summary>
	[ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(SafeHANDLENullCodeFixProvider)), Shared]
	public class SafeHANDLENullCodeFixProvider : CodeFixProvider
	{
		private const string Title = "Replace with SafeHANDLE NULL property";

		/// <inheritdoc/>
		public sealed override ImmutableArray<string> FixableDiagnosticIds => [SafeHANDLENullAnalyzer.DiagnosticId];

		/// <inheritdoc/>
		public sealed override FixAllProvider GetFixAllProvider() => WellKnownFixAllProviders.BatchFixer;

		/// <inheritdoc/>
		public sealed override async Task RegisterCodeFixesAsync(CodeFixContext context)
		{
			var root = await context.Document.GetSyntaxRootAsync(context.CancellationToken).ConfigureAwait(false);
			if (root is null) return;

			var diagnostic = context.Diagnostics[0];
			var diagnosticSpan = diagnostic.Location.SourceSpan;

			var nodeSyntax = root.FindNode(diagnosticSpan).FirstAncestorOrSelf<LiteralExpressionSyntax>();
			if (nodeSyntax is null) return;

			context.RegisterCodeFix(
				CodeAction.Create(
					title: Title,
					createChangedDocument: c => ReplaceWithSafeHandleNullAsync(context, nodeSyntax, c),
					equivalenceKey: Title),
				diagnostic);
		}

		private async Task<Document> ReplaceWithSafeHandleNullAsync(CodeFixContext context, LiteralExpressionSyntax nodeSyntax, CancellationToken cancellationToken)
		{
			var semanticModel = await context.Document.GetSemanticModelAsync(cancellationToken).ConfigureAwait(false);
			if (semanticModel is null) return context.Document;

			//var parameterSymbol = nodeSyntax.Parent is null ? null : semanticModel.GetSymbolInfo(nodeSyntax.Parent).Symbol as IParameterSymbol;
			//if (parameterSymbol is null) return context.Document;

			//var safeHandleTypeName = parameterSymbol.Type.Name;
			var safeHandleTypeName = context.Diagnostics[0].Properties["SafeHandleType"];
			var nullPropertyName = $"{safeHandleTypeName}.Null";

			var nullPropertyExpression = SyntaxFactory.ParseExpression(nullPropertyName)
				.WithAdditionalAnnotations(Microsoft.CodeAnalysis.Formatting.Formatter.Annotation, Simplifier.Annotation);

			var root = await context.Document.GetSyntaxRootAsync(cancellationToken).ConfigureAwait(false);
			if (root is null) return context.Document;

			var newRoot = root.ReplaceNode(nodeSyntax, nullPropertyExpression);
			return context.Document.WithSyntaxRoot(newRoot);
		}
	}
}