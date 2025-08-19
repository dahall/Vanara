namespace Vanara.Generators;

/// <summary>Base class for code generators that process attributes on partial structures.</summary>
public abstract class GeneratorBase<T> : IIncrementalGenerator where T : SyntaxNode
{
	/// <summary>Gets the attribute type that this generator processes.</summary>
	protected abstract string AttributeFullName { get; }

	/// <summary>Called to initialize the generator and register generation steps via callbacks on the <paramref name="context"/></summary>
	/// <param name="context">The context to register callbacks on</param>
	void IIncrementalGenerator.Initialize(IncrementalGeneratorInitializationContext context)
	{
		var decl = context.SyntaxProvider.ForAttributeWithMetadataName(AttributeFullName, (sn, ct) => sn is T t && IsValidSyntax(t, ct),
			(ctx, _) =>
				((T)ctx.TargetNode, ctx.Attributes.FirstOrDefault(a => a.AttributeClass?.ToDisplayString() == AttributeFullName) ?? throw new InvalidOperationException("Attribute not found.")));
		var source = context.CompilationProvider.Combine(decl.Collect()).WithTrackingName("Syntax");
		context.RegisterSourceOutput(source, (c, r) => { foreach (var (t, a) in r.Right) Generate(c, r.Left, t, a); });
	}

	/// <summary>Generates source code based on the provided context, compilation, declaration, and attribute data.</summary>
	/// <remarks>
	/// This method is abstract and must be implemented by derived classes to define the specific logic for generating source code.
	/// </remarks>
	/// <param name="context">The context for source production, providing mechanisms for reporting diagnostics and adding generated sources.</param>
	/// <param name="compilation">The current state of the compilation, which can be used to analyze the code being compiled.</param>
	/// <param name="decl">The declaration of type <typeparamref name="T"/> that is being processed.</param>
	/// <param name="attr">The attribute data associated with the declaration, used to guide the generation process.</param>
	protected abstract void Generate(SourceProductionContext context, Compilation compilation, T decl, AttributeData attr);

	/// <summary>Determines whether the specified syntax node is valid according to the implemented rules.</summary>
	/// <remarks>This method is abstract and must be implemented in a derived class to define the specific validation logic.</remarks>
	/// <param name="syntaxNode">The syntax node to validate.</param>
	/// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
	/// <returns><see langword="true"/> if the syntax node is valid; otherwise, <see langword="false"/>.</returns>
	protected abstract bool IsValidSyntax(T syntaxNode, CancellationToken cancellationToken);
}