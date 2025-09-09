using Microsoft.CodeAnalysis.CSharp;
using System.Xml;
using System.Xml.Linq;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Vanara.Generators;

internal static class Util
{
	public static XmlDocument? GetDocs(this SyntaxNode node)
	{
		string docComment = node.GetLeadingTrivia().Where(t => t.IsKind(SyntaxKind.SingleLineDocumentationCommentTrivia)).FirstOrDefault().ToString();
		if (string.IsNullOrEmpty(docComment))
			return null;

		// Remove the leading /// from the doc comment
		docComment = $"<xmlDoc>\r\n{Regex.Replace(docComment, @"^\s*(///\s*)?", @"", RegexOptions.Multiline)}\r\n</xmlDoc>";

		// Load the xml docs into an XmlDocument
		XmlDocument xmlDoc = new() { PreserveWhitespace = true };
		xmlDoc.LoadXml(docComment);

		return xmlDoc;
	}

	public static ISymbol? GetSymbol(this SyntaxNode node, Compilation compilation) => compilation.GetSemanticModel(node.SyntaxTree).GetSymbolInfo(node).Symbol;

	public static SyntaxNode? GetSyntax(this ISymbol symbol, Func<SyntaxNode, bool>? pred) => symbol.DeclaringSyntaxReferences.Select(r => r.GetSyntax()).FirstOrDefault(pred);

	public static TSyn? GetSyntax<TSyn>(this ISymbol symbol, Func<SyntaxNode, bool>? pred = null) where TSyn : SyntaxNode
	{
		pred ??= n => n is TSyn;
		return (TSyn?)GetSyntax(symbol, pred);
	}

	public static ClassDeclarationSyntax? GetSyntax(this INamedTypeSymbol symbol) => GetSyntax<ClassDeclarationSyntax>(symbol);

	public static NamespaceDeclarationSyntax? GetSyntax(this INamespaceSymbol symbol) => GetSyntax<NamespaceDeclarationSyntax>(symbol);

	public static TypeDeclarationSyntax GetTypeDeclaration(INamedTypeSymbol sym) =>
		sym.TypeKind switch
		{
			TypeKind.Class => ClassDeclaration(sym.Name),
			_ => StructDeclaration(sym.Name),
		};

	public static TypeDeclarationSyntax? GetTypeSyntax(this INamedTypeSymbol symbol) => (TypeDeclarationSyntax?)GetSyntax(symbol, n => n is ClassDeclarationSyntax or StructDeclarationSyntax);

	public static bool IsPartial(this INamedTypeSymbol symbol) => symbol.DeclaringSyntaxReferences.Any(sr =>
		sr.GetSyntax() is BaseTypeDeclarationSyntax syn && syn.Modifiers.Any(m => m.IsKind(SyntaxKind.PartialKeyword)));

	public static bool IsDefinedInternally(this ITypeSymbol typeSymbol, Compilation compilation) =>
		//SymbolEqualityComparer.Default.Equals(typeSymbol?.ContainingAssembly, compilation?.Assembly);
		typeSymbol.Locations.Any(loc => loc.Kind == LocationKind.SourceFile);

	public static ArgumentSyntax ParamToArg(this ParameterSyntax param)
	{
		ArgumentSyntax arg = Argument(IdentifierName(param.Identifier));
		if (param.Modifiers.Count > 0)
		{
			if (param.Modifiers.First().ValueText == "out")
				return arg.WithRefKindKeyword(Token(SyntaxKind.OutKeyword));
			else if (param.Modifiers.First().ValueText == "ref")
				return arg.WithRefKindKeyword(Token(SyntaxKind.RefKeyword));
		}
		return arg;
	}

	public static string? Qualify(this string? name, string ns, string? parent = null)
	{
		System.Diagnostics.Debug.Write($"{name} (NS:{ns}, P:{parent}) => ");
		if (string.IsNullOrWhiteSpace(name)) return name;
		if (string.IsNullOrWhiteSpace(ns)) return name;
		name = parent is not null && name!.StartsWith(parent + '.') ? name.Substring(parent.Length + 1) : name;
		string prefix = ns + '.' + (string.IsNullOrWhiteSpace(parent) ? "" : $"{parent}.");
		string? retVal;
		if (name!.StartsWith(prefix))
			retVal = name.Substring(prefix.Length);
		else retVal = name.StartsWith(ns + '.') ? name.Substring(ns.Length + 1) : name.Contains('.') ? $"{name}" : name;
		System.Diagnostics.Debug.WriteLine(retVal);
		return retVal;
	}

	public static string ReadAllTextFromAsmResource(string resourceName)
	{
		using Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName);
		using StreamReader reader = new(stream);
		return reader.ReadToEnd();
	}

	public static string ReplaceWholeWords(string text, IReadOnlyDictionary<string, string> wordMap)
	{
		Regex regex = new(string.Join("|", wordMap.Keys.Select(k => @$"\b{Regex.Escape(k)}\b")));
		return regex.Replace(text, m => wordMap[m.Value]);
	}

	public static IEnumerable<SyntaxToken> ToTokens(this Accessibility accessibility)
	{
		switch (accessibility)
		{
			case Accessibility.Public:
				yield return Token(SyntaxKind.PublicKeyword);
				break;

			case Accessibility.Private:
				yield return Token(SyntaxKind.PrivateKeyword);
				break;

			case Accessibility.Protected:
				yield return Token(SyntaxKind.ProtectedKeyword);
				break;

			case Accessibility.Internal:
				yield return Token(SyntaxKind.InternalKeyword);
				break;

			case Accessibility.ProtectedAndInternal:
				yield return Token(SyntaxKind.PrivateKeyword);
				yield return Token(SyntaxKind.ProtectedKeyword);
				break;

			case Accessibility.ProtectedOrInternal:
				yield return Token(SyntaxKind.ProtectedKeyword);
				yield return Token(SyntaxKind.InternalKeyword);
				break;
		}
	}

	/// <summary>Filters <see langword="null"/> values out of a sequence.</summary>
	/// <typeparam name="T">The nullable type.</typeparam>
	/// <param name="o">The sequence.</param>
	/// <returns>The sequence without any <see langword="null"/> values.</returns>
	public static IEnumerable<T> WhereNotNull<T>(this IEnumerable<T?> o) where T : class
		=> o.Where(x => x is not null)!;

	public static T WithDocs<T>(this T node, XmlDocument? xmlDoc) where T : SyntaxNode
	{
		if (xmlDoc is null) return node;

		// Preface each line of the non-document xml elements with '/// '
		XDocument xdoc = XDocument.Parse(xmlDoc.DocumentElement.OuterXml, LoadOptions.PreserveWhitespace);
		var docLines = xdoc.ToString().Split(["\r\n"], StringSplitOptions.RemoveEmptyEntries).ToList();
		docLines.RemoveAt(0); docLines.RemoveAt(docLines.Count - 1);
		StringBuilder outXml = new();
		for (int i = 0; i < docLines.Count; i++)
			outXml.AppendLine("/// " + docLines[i].TrimStart(' ', '\t'));
		return node.WithLeadingTrivia(ParseLeadingTrivia(outXml.ToString()));
	}
}