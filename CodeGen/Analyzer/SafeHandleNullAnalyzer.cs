using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

/// <summary>Analyzer for supplying <see langword="null"/> as a value for a <c>Vanara.PInvoke.SafeHANDLE</c> typed argument.</summary>
[DiagnosticAnalyzer(LanguageNames.CSharp)]
public class SafeHANDLENullAnalyzer : DiagnosticAnalyzer
{
	/// <summary>The ID for diagnostics produced by the SafeHANDLENullAnalyzer.</summary>
	public const string DiagnosticId = "VA0002";
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

		// Check if the argument is a null literal assigned to a SafeHandle
		if (nodeSyntax.Parent is EqualsValueClauseSyntax eqSyntax && eqSyntax.Parent is VariableDeclaratorSyntax varSyntax
			&& varSyntax.Parent is VariableDeclarationSyntax varDeclSyntax && varDeclSyntax.Type is not NullableTypeSyntax
			&& context.SemanticModel.GetTypeInfo(varDeclSyntax.Type).Type is ITypeSymbol typeSym)
		{
			ReportIfDerivedType(typeSym, context);
		}
		// If this is an argument, determine if the parameter type it is going to IsSafeHANDLEDerivedType and create diagnotic
		else if (nodeSyntax.AncestorsAndSelf().FirstOrDefault(n => n is ArgumentSyntax) is ArgumentSyntax argumentSyntax
			&& argumentSyntax.Parent is ArgumentListSyntax argumentListSyntax)
		{
			var symbolInfo = context.SemanticModel.GetSymbolInfo(argumentListSyntax.Parent!);
			if ((symbolInfo.Symbol ?? symbolInfo.CandidateSymbols.FirstOrDefault()) is IMethodSymbol method)
			{
				IParameterSymbol? parameter;
				if (argumentSyntax.NameColon is not null)
					parameter = method.Parameters.FirstOrDefault(p => p.Name == argumentSyntax.NameColon.Name.Identifier.Text);
				else
				{
					var index = argumentListSyntax.Arguments.IndexOf(argumentSyntax);
					parameter = index >= 0 && index < method.Parameters.Length ? method.Parameters[index] : null;
				}

				if (parameter is not null && parameter.NullableAnnotation != NullableAnnotation.Annotated)
					ReportIfDerivedType(parameter.Type, context);
			}
		}
	}

	private static void ReportIfDerivedType(ITypeSymbol typeSymbol, SyntaxNodeAnalysisContext context)
	{
		var safeHandleType = context.Compilation.GetTypeByMetadataName("Vanara.PInvoke.SafeHANDLE");
		if (typeSymbol is not null && typeSymbol.BaseType is not null && SymbolEqualityComparer.Default.Equals(typeSymbol.BaseType, safeHandleType))
		{
			Dictionary<string, string?> properties = new() { ["SafeHandleType"] = typeSymbol.Name };
			var diagnostic = Diagnostic.Create(Rule, context.Node.GetLocation(), ImmutableDictionary.CreateRange(properties), typeSymbol.Name);
			context.ReportDiagnostic(diagnostic);
		}
	}
}