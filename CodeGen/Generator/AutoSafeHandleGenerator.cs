using System.Collections.Immutable;

namespace Vanara.Generators;

/// <summary></summary>
[Generator(LanguageNames.CSharp)]
public class AutoSafeHandleGenerator : IIncrementalGenerator
{
	private const string attributeFullName = "Vanara.PInvoke.AutoSafeHandleAttribute";

	/// <summary>Called to initialize the generator and register generation steps via callbacks on the <paramref name="context"/></summary>
	/// <param name="context">
	/// The <see cref="T:Microsoft.CodeAnalysis.IncrementalGeneratorInitializationContext"/> to register callbacks on
	/// </param>
	public void Initialize(IncrementalGeneratorInitializationContext context)
	{
		var decl = context.SyntaxProvider.ForAttributeWithMetadataName(attributeFullName, IsValidSyntax,
			(ctx, _) =>
				((ClassDeclarationSyntax)ctx.TargetNode, ctx.Attributes.FirstOrDefault(a => a.AttributeClass?.ToDisplayString() == attributeFullName) ?? throw new InvalidOperationException("Attribute not found.")));
		var source = context.CompilationProvider.Combine(decl.Collect()).WithTrackingName("Syntax");
		context.RegisterSourceOutput(source, Execute);
	}

	private static bool IsValidSyntax(SyntaxNode syntaxNode, CancellationToken cancellationToken) =>
		syntaxNode is ClassDeclarationSyntax ds && ds.IsPartial();

	private static void Execute(SourceProductionContext context, (Compilation compilation, ImmutableArray<(ClassDeclarationSyntax, AttributeData)> classes) unit)
	{
		foreach ((ClassDeclarationSyntax decl, AttributeData attr) in unit.classes)
		{
			var semanticModel = unit.compilation.GetSemanticModel(decl.SyntaxTree);
			if (semanticModel.GetDeclaredSymbol(decl) is not { } symbol) continue;
			var ns = symbol.ContainingNamespace.ToString();
			string? closeCode = attr.ConstructorArguments.ElementAtOrDefault(0).Value?.ToString();
			string handleType = attr.ConstructorArguments.ElementAtOrDefault(1).Value?.ToString() ?? "";
			string baseType = (attr.ConstructorArguments.ElementAtOrDefault(2).Value?.ToString() ?? "Vanara.PInvoke.SafeHANDLE").Qualify(ns)!;
			string? inhType = attr.ConstructorArguments.ElementAtOrDefault(3).Value?.ToString();

			if (decl.Parent is not ClassDeclarationSyntax parent) { context.ReportError("VANGEN004", "Unable to find parent class."); return; }

			HandleModel model = new(ns, parent!.Identifier.Text, handleType, "", "", symbol.Name, baseType, closeCode, inhType);
			context.AddSource($"{symbol.Name}.g.cs", SourceText.From(model.GetSafeHandleCode("", true), Encoding.UTF8));
		}
	}
}