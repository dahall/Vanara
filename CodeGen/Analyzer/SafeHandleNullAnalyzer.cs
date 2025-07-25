using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Generic;
using System.Collections.Immutable;

/// <summary>Analyzer for supplying <see langword="null"/> as a value for a <see cref="Vanara.PInvoke.SafeHANDLE"/> typed argument.</summary>
[DiagnosticAnalyzer(LanguageNames.CSharp)]
public class SafeHANDLENullAnalyzer : DiagnosticAnalyzer
{
	/// <summary>The ID for diagnostics produced by the SafeHANDLENullAnalyzer.</summary>
	public const string DiagnosticId = "SafeHANDLENullAnalyzer";
	private static readonly LocalizableString Title = "Use SafeHANDLE NULL for default value";
	private static readonly LocalizableString MessageFormat = "Use '{0}.NULL' instead of 'null' or 'default' for argument values of type '{0}'";
	private const string Category = "Usage";
	private static readonly LocalizableString Description = "Use the NULL property of SafeHANDLE-derived types instead of 'null' or 'default'.";

	private static readonly DiagnosticDescriptor Rule = new(DiagnosticId, Title, MessageFormat, Category, DiagnosticSeverity.Warning, isEnabledByDefault: true, description: Description);

	/// <inheritdoc/>
	public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => [Rule];

	/// <inheritdoc/>
	public override void Initialize(AnalysisContext context)
	{
		context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
		context.EnableConcurrentExecution();
		context.RegisterSyntaxNodeAction(AnalyzeNode, SyntaxKind.NullLiteralExpression, SyntaxKind.DefaultLiteralExpression);
	}

	private static void AnalyzeNode(SyntaxNodeAnalysisContext context)
	{
		var nodeSyntax = (LiteralExpressionSyntax)context.Node;

		// Check if the argument is a null literal
		if (nodeSyntax.Parent is EqualsValueClauseSyntax eqSyntax && eqSyntax.Parent is VariableDeclaratorSyntax varSyntax &&
			varSyntax.Parent is VariableDeclarationSyntax varDeclSyntax && context.SemanticModel.GetTypeInfo(varDeclSyntax.Type).Type is ITypeSymbol typeSym &&
			IsSafeHANDLEDerivedType(typeSym, context.Compilation))
		{
			Dictionary<string, string?> properties = new() { { "SafeHandleType", typeSym.Name } };
			var diagnostic = Diagnostic.Create(Rule, nodeSyntax.GetLocation(), ImmutableDictionary.CreateRange(properties), typeSym.Name);
			context.ReportDiagnostic(diagnostic);
		}
	}

	private static bool IsSafeHANDLEDerivedType(ITypeSymbol typeSymbol, Compilation compilation)
	{
		var safeHandleType = compilation.GetTypeByMetadataName("Vanara.PInvoke.SafeHANDLE");
		return typeSymbol is not null && typeSymbol.BaseType is not null && SymbolEqualityComparer.Default.Equals(typeSymbol.BaseType, safeHandleType);
	}
}