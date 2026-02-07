using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System.Collections.Immutable;
using System.Linq;
using System.Runtime.InteropServices;

/// <summary>A diagnostic analyzer that checks for parameters of type [Marshaled] structures.</summary>
[DiagnosticAnalyzer(LanguageNames.CSharp)]
public class MarshalerStructNoAttrAnalyzer : DiagnosticAnalyzer
{
	/// <summary>The ID for diagnostics produced by the MarshalerStructNoAttrAnalyzer.</summary>
	public const string DiagnosticId = "VA0001";
	private static readonly LocalizableString Title = "Missing attribute for marshaled structure parameter";
	private static readonly LocalizableString MessageFormat = "Parameters of type '{0}' must have a custom marshaler attribute";
	private const string Category = "Usage";
	private static readonly LocalizableString Description = "When using the parameter type {0} which is [Marshaled], a custom marshaler attribute must be supplied. Use '[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(VanaraCustomMarshaler<{0}>)]' as the attribute.";

	private static readonly DiagnosticDescriptor Rule = new(DiagnosticId, Title, MessageFormat, Category, DiagnosticSeverity.Warning, isEnabledByDefault: true, description: Description);

	/// <inheritdoc/>
	public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => [Rule];

	/// <inheritdoc/>
	public override void Initialize(AnalysisContext context)
	{
		context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
		context.EnableConcurrentExecution();
		context.RegisterSyntaxNodeAction(AnalyzeNode, SyntaxKind.Parameter);
	}

	private static void AnalyzeNode(SyntaxNodeAnalysisContext context)
	{
		// Check if the node is a parameter with a parameter type that has the MarshaledAttribute applied
		if (context.Node is ParameterSyntax parameterSyntax &&
			context.SemanticModel.GetDeclaredSymbol(parameterSyntax) is IParameterSymbol parameterSymbol &&
			parameterSymbol.Type.GetAttributes().Any(attr => attr.AttributeClass?.Name == "MarshaledAttribute"))
		{
			// Check if the parameter has a MarshalAsAttribute applied
			var marshaledAttr = parameterSymbol.GetAttributes().FirstOrDefault(attr => attr.AttributeClass?.Name == nameof(MarshalAsAttribute));
			if (marshaledAttr is not null && marshaledAttr.ConstructorArguments.Length == 1)
			{
				var firstArg = marshaledAttr.ConstructorArguments[0];
				// Check if the first argument is of type UnmanagedType.CustomMarshaler
				if (Equals(firstArg.Value, (int)UnmanagedType.CustomMarshaler))
				{
					// Check if any of the following arguments are a named parameter of "MarshalTypeRef" with a value of VanaraCustomMarshaler<T>
					var marshalTypeRefArg = marshaledAttr.NamedArguments.FirstOrDefault(arg => arg.Key == "MarshalTypeRef");
					if (marshalTypeRefArg.Value.Value is INamedTypeSymbol namedTypeSymbol &&
						namedTypeSymbol.Name == "VanaraCustomMarshaler" &&
						namedTypeSymbol.TypeArguments.Length == 1 &&
						namedTypeSymbol.TypeArguments[0].Name == parameterSymbol.Type.Name)
					{
						// The parameter is correctly annotated with a custom marshaler attribute
						return; // No diagnostic needed
					}
				}
			}

			// If we reach here, the parameter is missing the required custom marshaler attribute
			var diagnostic = Diagnostic.Create(Rule, parameterSyntax.GetLocation(), parameterSymbol.Type.Name);
			context.ReportDiagnostic(diagnostic);
		}
	}

	//[Marshaled] private struct X { public int v; }
	//private static bool IsMarshaled(in X x, ref X x2, out X x3, [In][System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(Vanara.InteropServices.VanaraCustomMarshaler<X>))] X x4) { x3 = default; return true; }
}