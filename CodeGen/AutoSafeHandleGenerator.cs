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
		var pipeline = context.SyntaxProvider.ForAttributeWithMetadataName(attributeFullName,
			IsValidSyntax, TransformFromSyntax).
			Collect().
			SelectMany((i, _) => i.Distinct()).
			WithTrackingName("Syntax");

		context.RegisterSourceOutput(pipeline, static (context, model) =>
			context.AddSource($"{model.ClassName}.g.cs", SourceText.From(model.GetSafeHandleCode(), Encoding.UTF8)));
	}

	private static bool IsValidSyntax(SyntaxNode syntaxNode, CancellationToken cancellationToken) =>
		syntaxNode is ClassDeclarationSyntax ds && ds.IsPartial();

	private static HandleModel TransformFromSyntax(GeneratorAttributeSyntaxContext context, CancellationToken cancellationToken)
	{
		ISymbol? classSymbol = context.TargetSymbol;
		string handleType = context.Attributes.First().ConstructorArguments.ElementAtOrDefault(0).Value?.ToString() ?? "";
		string baseType = context.Attributes.First().ConstructorArguments.ElementAtOrDefault(1).Value?.ToString() ?? "";
		string closeCode = context.Attributes.First().ConstructorArguments.ElementAtOrDefault(2).Value?.ToString() ?? "";
		var ns = classSymbol.ContainingNamespace.ToString();
		return new(ns, handleType, "", "", classSymbol.Name, baseType, closeCode);
	}
}