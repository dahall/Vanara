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
	/// <summary>Code fix provider for adding a custom marshaler attribute to marshaled structs.</summary>
	[ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(MarshalerStructAttrFixProvider)), Shared]
	public class MarshalerStructAttrFixProvider : CodeFixProvider
	{
		private const string Title = "Add custom marshaler attribute to marshaled structs";

		/// <inheritdoc/>
		public sealed override ImmutableArray<string> FixableDiagnosticIds => [MarshalerStructNoAttrAnalyzer.DiagnosticId];

		/// <inheritdoc/>
		public sealed override FixAllProvider GetFixAllProvider() => WellKnownFixAllProviders.BatchFixer;

		/// <inheritdoc/>
		public sealed override async Task RegisterCodeFixesAsync(CodeFixContext context)
		{
			var root = await context.Document.GetSyntaxRootAsync(context.CancellationToken).ConfigureAwait(false);
			if (root is null) return;

			var diagnostic = context.Diagnostics[0];
			var diagnosticSpan = diagnostic.Location.SourceSpan;

			var paramSyntax = root.FindNode(diagnosticSpan).FirstAncestorOrSelf<ParameterSyntax>();
			if (paramSyntax is null) return;

			context.RegisterCodeFix(
				CodeAction.Create(Title, c => AddCustomMarshalerAttrAsync(context.Document, paramSyntax, c), Title),
				diagnostic);
		}

		private async Task<Document> AddCustomMarshalerAttrAsync(Document document, ParameterSyntax paramSyntax, CancellationToken cancellationToken)
		{
			var semanticModel = await document.GetSemanticModelAsync(cancellationToken).ConfigureAwait(false);
			if (semanticModel is null) return document;

			if (semanticModel.GetDeclaredSymbol(paramSyntax) is not IParameterSymbol parameterSymbol)
				return document;

			var paramTypeName = parameterSymbol.Type.Name;
			var attrParam = $"(System.Runtime.InteropServices.UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Vanara.InteropServices.VanaraCustomMarshaler<{paramTypeName}>))";

			// If the parameter already has a MarshalAsAttribute, we need to replace it with the custom marshaler attribute.
			var marshaledAttr = parameterSymbol.GetAttributes().FirstOrDefault(attr => attr.AttributeClass?.Name == nameof(System.Runtime.InteropServices.MarshalAsAttribute));
			var newParamSyntax = marshaledAttr is not null ? paramSyntax.RemoveNode(marshaledAttr!.ApplicationSyntaxReference!.GetSyntax(), SyntaxRemoveOptions.KeepNoTrivia)! : paramSyntax;

			// Add the custom marshaler attribute to the parameter's list of attributes
			var newAttr = SyntaxFactory.Attribute(SyntaxFactory.ParseName("System.Runtime.InteropServices.MarshalAsAttribute"), SyntaxFactory.ParseAttributeArgumentList(attrParam));
			var newAttrList = SyntaxFactory.AttributeList([newAttr]);
			newParamSyntax = newParamSyntax.AddAttributeLists(newAttrList).WithAdditionalAnnotations(Microsoft.CodeAnalysis.Formatting.Formatter.Annotation, Simplifier.Annotation);

			// If the new parameter syntax has empty attbute lists, remove them to keep the code clean
			newParamSyntax = newParamSyntax.WithAttributeLists(SyntaxFactory.List(newParamSyntax.AttributeLists.Where(a => a.Attributes.Count > 0)));

			var root = await document.GetSyntaxRootAsync(cancellationToken).ConfigureAwait(false);
			if (root is null) return document;

			var newRoot = root.ReplaceNode(paramSyntax, newParamSyntax);
			return document.WithSyntaxRoot(newRoot);
		}
	}
}