using System.Collections.Immutable;

namespace Vanara.Generators;

/// <summary></summary>
[Generator(LanguageNames.CSharp)]
public class AutoHandleGenerator : IIncrementalGenerator
{
	private const string attributeFullName = "Vanara.PInvoke.AutoHandleAttribute";

	/// <summary>Called to initialize the generator and register generation steps via callbacks on the <paramref name="context"/></summary>
	/// <param name="context">
	/// The <see cref="T:Microsoft.CodeAnalysis.IncrementalGeneratorInitializationContext"/> to register callbacks on
	/// </param>
	public void Initialize(IncrementalGeneratorInitializationContext context)
	{
		var decl = context.SyntaxProvider.ForAttributeWithMetadataName(attributeFullName, IsValidSyntax,
			(ctx, _) =>
				((StructDeclarationSyntax)ctx.TargetNode, ctx.Attributes.FirstOrDefault(a => a.AttributeClass?.ToDisplayString() == attributeFullName) ?? throw new InvalidOperationException("Attribute not found.")));
		var source = context.CompilationProvider.Combine(decl.Collect()).WithTrackingName("Syntax");
		context.RegisterSourceOutput(source, Execute);
	}

	private static bool IsValidSyntax(SyntaxNode syntaxNode, CancellationToken cancellationToken) =>
		syntaxNode is StructDeclarationSyntax ds && ds.IsPartial();

	private static void Execute(SourceProductionContext context, (Compilation compilation, ImmutableArray<(StructDeclarationSyntax, AttributeData)> classes) unit)
	{
		foreach ((StructDeclarationSyntax decl, AttributeData attr) in unit.classes)
		{
			if (unit.compilation?.GetSemanticModel(decl.SyntaxTree)?.GetDeclaredSymbol(decl) is not { } symbol) continue;
			string ns = symbol?.ContainingNamespace?.ToDisplayString() ?? "BADNS";

			if (decl.Parent is not ClassDeclarationSyntax parent) { context.ReportError("VANGEN004", "Unable to find parent class."); return; }

			var ctorp1 = attr.ConstructorArguments.ElementAtOrDefault(0);
			var ctorp2 = attr.ConstructorArguments.ElementAtOrDefault(1);

			HandleModel model = new(ns, parent!.Identifier.Text, decl.Identifier.Text, ctorp1.Value?.ToString() ?? "Vanara.PInvoke.IHandle", InheritedHandleName: ctorp2.Value?.ToString());
			context.AddSource($"{model.HandleName}.g.cs", SourceText.From(model.GetHandleCode(), Encoding.UTF8));
		}
	}
}