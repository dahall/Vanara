using Microsoft.CodeAnalysis.CSharp;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Xml;
using System.Xml.Linq;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Vanara.Generators;

internal class SyntaxComparer : IEqualityComparer<SyntaxNode>
{
	public static readonly SyntaxComparer Default = new();
	public bool Equals(SyntaxNode? x, SyntaxNode? y) => x?.IsEquivalentTo(y) ?? y is null;
	public int GetHashCode(SyntaxNode obj) => obj.GetHashCode();
}

internal class TypeComparer : IEqualityComparer<TypeDeclarationSyntax>
{
	public static readonly TypeComparer Default = new();
	public bool Equals(TypeDeclarationSyntax? x, TypeDeclarationSyntax? y) => x is not null && string.Equals(GetTypeName(x), GetTypeName(y));
	public int GetHashCode(TypeDeclarationSyntax obj) => GetTypeName(obj)!.GetHashCode();
	private static string? GetTypeName(TypeDeclarationSyntax? tds) => tds?.Identifier.Text;
}

internal static class Util
{
	public static XmlDocument? GetDocs(this SyntaxNode node)
	{
		string docComment = node.GetLeadingTrivia().Where(t => t.IsKind(SyntaxKind.SingleLineDocumentationCommentTrivia)).FirstOrDefault().ToString();
		if (string.IsNullOrEmpty(docComment))
			return null;

		// Remove the leading /// from the doc comment
		docComment = $"<xmlDoc>\r\n{Regex.Replace(docComment, @"^\s*(///\s*)?", @"", RegexOptions.Multiline)}\r\n</xmlDoc>";

		// Unwrap any lines that are not the start of a new XML element
		docComment = Regex.Replace(docComment, @"\r\n(?!\s*<)", " ", RegexOptions.Multiline);

		// Load the xml docs into an XmlDocument
		XmlDocument xmlDoc = new() { PreserveWhitespace = true };
		xmlDoc.LoadXml(docComment);

		return xmlDoc;
	}

	// Determine the CharSet of the decl by looking for a MarshalAs attribute with constructor first argument of UnmanagedType.LPStr, LPWStr, or LPTStr OR
	// by looking for a DllImport attribute on the method with a CharSet named argument
	public static CharSet GetCharSet(this ParameterSyntax decl)
	{
		CharSet charSet = CharSet.Auto;

		// First, check the parameter's MarshalAs attribute
		if (decl.AttributeLists.SelectMany(al => al.Attributes).FirstOrDefault(a => a.Name.ToString() == "MarshalAs")?.ArgumentList?.Arguments
			.FirstOrDefault()?.Expression is MemberAccessExpressionSyntax maes && maes.Expression.ToString() == "UnmanagedType")
		{
			charSet = maes.Name.ToString() switch
			{
				"LPStr" => CharSet.Ansi,
				"LPWStr" => CharSet.Unicode,
				"LPTStr" => CharSet.Auto,
				_ => charSet
			};
		}
		else
		{
			// Check the method's DllImport attribute for CharSet named argument
			var dllImportAttr = (decl.Parent?.Parent as MethodDeclarationSyntax)?.AttributeLists.SelectMany(al => al.Attributes).FirstOrDefault(a => a.Name.ToString() == "DllImport");
			if (dllImportAttr?.ArgumentList?.Arguments != null)
			{
				if (dllImportAttr.ArgumentList.Arguments.FirstOrDefault(arg => arg.NameEquals?.Name.ToString() == "CharSet")?
					.Expression is MemberAccessExpressionSyntax charSetMaes && charSetMaes.Expression.ToString() == "CharSet")
				{
					charSet = charSetMaes.Name.ToString() switch
					{
						"Ansi" => CharSet.Ansi,
						"Unicode" => CharSet.Unicode,
						"Auto" => CharSet.Auto,
						_ => charSet
					};
				}
			}
		}

		return charSet;
	}

	public static string[] GetValues(this TypedConstant tc) => tc.Type?.ToDisplayString() == "string[]" ?
		[.. tc.Values.Select(v => v.Value?.ToString() ?? "")] :
		[tc.Value?.ToString() ?? ""];

	public static T GetParentKind<T>(this SyntaxNode node) where T : SyntaxNode
	{
		for (var n = node.Parent; n is not null; n = n.Parent)
			if (n is T mds)
				return mds;
		throw new ArgumentException("Unable to identify parent node of specified type.", nameof(node));
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

	public static TypeDeclarationSyntax MakeTypeDeclaration(this INamedTypeSymbol sym) =>
		sym.TypeKind switch
		{
			TypeKind.Class => ClassDeclaration(sym.Name),
			_ => StructDeclaration(sym.Name),
		};

	public static TypeDeclarationSyntax? GetTypeDeclaration(this TypeSyntax tsyn, Compilation compilation) =>
		tsyn.GetSymbol(compilation) is ITypeSymbol ts
			? ts.DeclaringSyntaxReferences.Select(r => r.GetSyntax())
				.FirstOrDefault(s => s is TypeDeclarationSyntax) as TypeDeclarationSyntax
			: null;

	public static Microsoft.CodeAnalysis.TypeInfo GetTypeInfo(this BaseParameterSyntax node, Compilation compilation) => compilation.GetSemanticModel(node.SyntaxTree).GetTypeInfo(node.Type!);

	public static TypeDeclarationSyntax? GetTypeSyntax(this INamedTypeSymbol symbol) => (TypeDeclarationSyntax?)GetSyntax(symbol, n => n is ClassDeclarationSyntax or StructDeclarationSyntax);

	public static bool IsPartial(this INamedTypeSymbol symbol) => symbol.DeclaringSyntaxReferences.Any(sr =>
		sr.GetSyntax() is BaseTypeDeclarationSyntax syn && syn.Modifiers.Any(m => m.IsKind(SyntaxKind.PartialKeyword)));

	public static bool IsDefinedInternally(this ITypeSymbol typeSymbol, Compilation compilation) =>
		//SymbolEqualityComparer.Default.NameEquals(typeSymbol?.ContainingAssembly, compilation?.Assembly);
		typeSymbol.Locations.Any(loc => loc.Kind == LocationKind.SourceFile);

	public static bool NameEquals(this AttributeSyntax attr, string name) => Regex.IsMatch(attr.Name.ToString(), $"(?:(?:\\w+\\.)*|\\b){name}(Attribute)?");

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

	public static ParameterSyntax WithoutAttribute(this ParameterSyntax p, string attrName)
	{
		var al = p.AttributeLists.SelectMany(al => al.Attributes).Where(a => (a.Name as IdentifierNameSyntax)?.Identifier.Text != attrName).ToList();
		return p.WithAttributeLists(al.Count > 0 ? SingletonList(AttributeList(SeparatedList(al))) : []);
	}

	public static HashSet<TSource> ToHashSet<TSource>(this IEnumerable<TSource> source, IEqualityComparer<TSource>? comparer = null)
	{
		if (source is null) throw new ArgumentException("Source cannot be null", nameof(source));
		return new HashSet<TSource>(source, comparer);
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
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static IEnumerable<T> WhereNotNull<T>(this IEnumerable<T?> o) where T : class
		=> o.Where(x => x is not null)!;

	/// <summary>Returns a sequence of distinct elements from the input sequence, comparing elements based on a specified key.</summary>
	/// <remarks>
	/// This method uses deferred execution and only enumerates the source sequence as needed. The order of the elements in the returned
	/// sequence corresponds to the first occurrence of each distinct key in the source sequence.
	/// </remarks>
	/// <typeparam name="TSource">The type of the elements in the source sequence.</typeparam>
	/// <typeparam name="TKey">The type of the key used to determine distinctness.</typeparam>
	/// <param name="source">The sequence to remove duplicate elements from.</param>
	/// <param name="keySelector">A function to extract the key for each element.</param>
	/// <returns>
	/// An <see cref="IEnumerable{T}"/> that contains distinct elements from the input sequence, determined by the specified key.
	/// </returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
		=> source.GroupBy(v => keySelector(v)).Select(v => v.First());

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

	public static void AddDistinctBy<TSource, TKey>(this ICollection<TSource> source, IEnumerable<TSource> items, Func<TSource, TKey> keySelector)
	{
		foreach (var item in items)
			if (!source.Any(k => EqualityComparer<TKey>.Default.Equals(keySelector(k), keySelector(item))))
				source.Add(item);
	}

	public static void RemoveParamDoc(this XmlDocument docs, string paramName)
	{
		var paramNode = docs.SelectSingleNode($"//param[@name='{paramName}']");
		paramNode?.ParentNode?.RemoveChild(paramNode);
		foreach (var n in docs.SelectNodes($"//paramref[@name='{paramName}']").Cast<XmlNode>())
			n.ParentNode?.RemoveChild(n);
	}

	public static XmlNode InsertTypeParamDocAfter(this XmlDocument docs, string typeParamName, string text, string? existingTypeParamName = null)
	{
		var prevNode = existingTypeParamName is null ? GetSummaryDoc(docs) : docs.SelectSingleNode($"//typeParam[@name='{existingTypeParamName}']") ?? GetSummaryDoc(docs);

		var cr = docs.CreateTextNode("\r\n");
		var typeParamElem = docs.CreateElement("typeParam");
		typeParamElem.SetAttribute("name", typeParamName);
		typeParamElem.InnerXml = text;

		return prevNode.ParentNode.InsertAfter(typeParamElem, prevNode.ParentNode.InsertAfter(cr, prevNode));
	}

	public static XmlNode InsertParamDocAfter(this XmlDocument docs, string paramName, string text, string? existingParamName = null)
	{
		// If and existing param name was given, try to get that node. If no name or not found, get the last typeParam node or the summary node if no typeParam nodes exist
		XmlNode? prevNode = null;
		if (existingParamName is not null)
			prevNode = docs.SelectSingleNode($"//param[@name='{existingParamName}']");
		prevNode ??= docs.SelectSingleNode("(//typeParam)[last()]") ?? GetSummaryDoc(docs);

		var cr = docs.CreateTextNode("\r\n");
		var paramElem = docs.CreateElement("param");
		paramElem.SetAttribute("name", paramName);
		paramElem.InnerXml = text;

		return prevNode.ParentNode.InsertAfter(paramElem, prevNode.ParentNode.InsertAfter(cr, prevNode));
	}

	/// <summary>
	/// Retrieves the <c>summary</c> XML node from the specified XML document.  If the <c>summary</c> node does not exist,
	/// a new one is created and inserted  as the first child of the document's root element.
	/// </summary>
	internal static XmlNode GetSummaryDoc(XmlDocument docs)
	{
		var summaryNode = docs.SelectSingleNode("//summary");
		if (summaryNode is null)
		{
			summaryNode = docs.CreateElement("summary");
			summaryNode = docs.DocumentElement.InsertBefore(summaryNode, docs.DocumentElement.FirstChild);
			docs.DocumentElement.InsertBefore(docs.CreateTextNode("\r\n"), summaryNode);
		}
		return summaryNode;
	}
}