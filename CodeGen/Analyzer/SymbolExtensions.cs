using Microsoft.CodeAnalysis;
using System.Collections.Generic;
using System.Linq;

namespace Vanara.CodeGen;

internal static partial class SymbolExtensions
{

	public static readonly HashSet<string> AttrsToCheck = new(System.StringComparer.Ordinal)
	{
		"IgnoreAttribute", "MarshalAsAttribute", "SizeDefAttribute",
		"AddAsMemberAttribute", "StructPointerAttribute", "ArrayPointerAttribute"
	};

	public static int CountInteropAttributes(this IMethodSymbol method) =>
		method.Parameters.Sum(p => p.GetAttributes().Count(a => a.AttributeClass is not null && AttrsToCheck.Contains(a.AttributeClass.Name)));

	public static bool IsInNamespace(this INamedTypeSymbol type, string nameSpace)
	{
		for (var ns = type.ContainingNamespace; ns is not null && !ns.IsGlobalNamespace; ns = ns.ContainingNamespace)
			if (ns.Name == nameSpace)
				return true;
		return false;
	}
}
