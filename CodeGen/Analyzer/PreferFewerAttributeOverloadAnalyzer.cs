using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using System;
using System.Collections.Concurrent;
using System.Collections.Immutable;
using System.Linq;
using Vanara.CodeGen;

/// <summary>
/// Analyzer that examines method invocations and determines if an overload with fewer generated parameter attributes exists and would be a
/// better alternative. This helps developers prefer simpler overloads.
/// </summary>
[DiagnosticAnalyzer(LanguageNames.CSharp)]
public class PreferFewerAttributeOverloadAnalyzer : DiagnosticAnalyzer
{
	/// <summary>The ID for diagnostics produced by this analyzer.</summary>
	public const string DiagnosticId = "VA0003";

	private static readonly LocalizableString Title = "Prefer more optimal overload";
	private static readonly LocalizableString MessageFormat = "Consider using the simpler overload '{0}'";
	private const string Category = "Usage";
	private static readonly LocalizableString Description =
		"When an overload exists with fewer parameters decorated with generation attributes (e.g., [Ignore], [MarshalAs], [SizeDef], etc.), " +
		"prefer the simpler overload unless the extra attributed parameters are explicitly needed.";

	private static readonly DiagnosticDescriptor Rule = new(DiagnosticId, Title, MessageFormat, Category,
		DiagnosticSeverity.Info, isEnabledByDefault: true, description: Description);

	/// <inheritdoc/>
	public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => [Rule];

	/// <inheritdoc/>
	public override void Initialize(AnalysisContext context)
	{
		context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
		context.EnableConcurrentExecution();
		context.RegisterCompilationStartAction(compilationContext =>
		{
			// Cache interop attribute counts per method symbol for the lifetime of this compilation.
			// Without caching, GetMembers + CountInteropAttributes runs on every invocation node.
			var attrCountCache = new ConcurrentDictionary<IMethodSymbol, int>(SymbolEqualityComparer.Default);
			int GetCachedAttrCount(IMethodSymbol m) => attrCountCache.GetOrAdd(m, static sym => sym.CountInteropAttributes());

			compilationContext.RegisterSyntaxNodeAction(
				ctx => AnalyzeInvocation(ctx, GetCachedAttrCount),
				SyntaxKind.InvocationExpression);
		});
	}

	private static void AnalyzeInvocation(SyntaxNodeAnalysisContext context, Func<IMethodSymbol, int> getAttrCount)
	{
		var invocation = (InvocationExpressionSyntax)context.Node;

		// Get the symbol for the invoked method
		if (context.SemanticModel.GetSymbolInfo(invocation).Symbol is not IMethodSymbol calledMethod)
			return;

		// Get the containing type to look for overloads that must be in the same type. Only analyze methods in the "Vanara" namespace.
		var containingType = calledMethod.ContainingType;
		if (containingType is null || !containingType.IsInNamespace("Vanara"))
			return;

		// Count interop attributes on the called method (cached).
		int calledAttrCount = getAttrCount(calledMethod);
		if (calledAttrCount == 0)
			return; // Already using a clean overload

		// Find all overloads of the same method name in the same type with fewer attributes (cached counts).
		IMethodSymbol? betterOverload = null;
		foreach (var member in containingType.GetMembers(calledMethod.Name))
		{
			if (member is not IMethodSymbol overload) continue;
			if (SymbolEqualityComparer.Default.Equals(overload, calledMethod)) continue;
			if (overload.DeclaredAccessibility != calledMethod.DeclaredAccessibility) continue;
			if (overload.IsStatic != calledMethod.IsStatic || overload.IsExtern) continue;

			int overloadAttrCount = getAttrCount(overload);
			if (overloadAttrCount < calledAttrCount)
			{
				betterOverload = overload;
				break;
			}
		}

		if (betterOverload is null)
			return;

		// Found a better overload — report diagnostic
		var overloadSignature = FormatMethodSignature(calledMethod, invocation.ArgumentList.Arguments, betterOverload);
		var diagnostic = Diagnostic.Create(Rule, invocation.GetLocation(), overloadSignature);
		context.ReportDiagnostic(diagnostic);
	}

	/// <summary>
	/// Checks whether the candidate overload is compatible with the current invocation. An overload is compatible if the arguments currently
	/// being passed can be accepted by the candidate.
	/// </summary>
	private static bool IsOverloadCompatible(SemanticModel semanticModel, InvocationExpressionSyntax invocation, IMethodSymbol calledMethod, IMethodSymbol candidate)
	{
		var arguments = invocation.ArgumentList.Arguments;

		// If the candidate has more required parameters than arguments being passed, it's not compatible
		int requiredParams = candidate.Parameters.Count(p => !p.IsOptional && !p.IsParams);
		if (requiredParams > arguments.Count)
			return false;

		// If the candidate has fewer total parameters (excluding params) than arguments, it might not work
		// unless there's a params parameter
		bool candidateHasParams = candidate.Parameters.Any(p => p.IsParams);
		int maxAcceptable = candidateHasParams ? int.MaxValue : candidate.Parameters.Length;
		if (arguments.Count > maxAcceptable)
			return false;

		// Check each argument matches the candidate parameter type
		for (int i = 0; i < arguments.Count && i < candidate.Parameters.Length; i++)
		{
			var argument = arguments[i];
			IParameterSymbol? candidateParam;

			// Handle named arguments
			if (argument.NameColon is not null)
			{
				var paramName = argument.NameColon.Name.Identifier.ValueText;
				candidateParam = candidate.Parameters.FirstOrDefault(p => p.Name == paramName);
				if (candidateParam == null)
					return false;
			}
			else
			{
				candidateParam = candidate.Parameters[i];
			}

			// Check type compatibility
			var argType = semanticModel.GetTypeInfo(argument.Expression).Type;
			if (argType is null)
				continue;

			var paramType = candidateParam.Type;

			// Check if types are compatible (same type, or implicit conversion exists)
			if (!IsTypeCompatible(argType, paramType, semanticModel.Compilation))
				return false;
		}

		return true;
	}

	/// <summary>Checks if a source type is compatible with a destination parameter type.</summary>
	private static bool IsTypeCompatible(ITypeSymbol source, ITypeSymbol destination, Compilation compilation)
	{
		if (SymbolEqualityComparer.Default.Equals(source, destination))
			return true;

		if (compilation is CSharpCompilation csharpCompilation)
		{
			var conversion = csharpCompilation.ClassifyConversion(source, destination);
			return conversion.Exists && (conversion.IsImplicit || conversion.IsIdentity);
		}

		// Fallback: check if the source type inherits from or implements the destination type
		for (var baseType = source.BaseType; baseType is not null; baseType = baseType.BaseType)
		{
			if (SymbolEqualityComparer.Default.Equals(baseType, destination))
				return true;
		}

		return source.AllInterfaces.Any(i => SymbolEqualityComparer.Default.Equals(i, destination));
	}

	/// <summary>Formats a method signature for display in the diagnostic message.</summary>
	private static string FormatMethodSignature(IMethodSymbol method, SeparatedSyntaxList<ArgumentSyntax> args, IMethodSymbol overload)
	{
		//// For each matching paramenter in overload from method, use the argument syntax identifier to create a signature like "Method(arg1, arg2, ...)"
		//string[] outArgs = new string[overload.Parameters.Length];
		//for (int i = 0; i < overload.Parameters.Length; i++)
		//{
		//	IParameterSymbol? p = overload.Parameters[i];
		//	var matchingParam = method.Parameters.FirstOrDefault(mp => mp.Name == p.Name);
		//	var matchingParamIndex = matchingParam != null ? method.Parameters.IndexOf(matchingParam) : -1;
		//	outArgs[i] = matchingParamIndex >= 0 && matchingParamIndex < args.Count
		//		? args[matchingParamIndex].ToString()
		//		: p.Name;
		//}
		return overload.ToDisplayString(SymbolDisplayFormat.CSharpShortErrorMessageFormat);
	}
}