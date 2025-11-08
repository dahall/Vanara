using Microsoft.CodeAnalysis.CSharp;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Vanara.Generators;

internal class FungibleTypeDecl(TypeDeclarationSyntax? td) : IEquatable<FungibleTypeDecl>, IComparable<FungibleTypeDecl>
{
	private readonly List<SyntaxNode>? Hierarchy = null;

	public FungibleTypeDecl(TypeSyntax type, Compilation compilation) : this(type.GetTypeDeclaration(compilation)!) { }

	public FungibleTypeDecl(INamedTypeSymbol tsym) : this(tsym.GetTypeSyntax())
	{
		if (decl is null && tsym.DeclaringSyntaxReferences.Length == 0)
		{
			Hierarchy = MakeTypeDecl(tsym.IsValueType, tsym.Name, [SyntaxKind.PublicKeyword], tsym.ContainingType?.Name, tsym.ContainingNamespace.Name);
			decl = (TypeDeclarationSyntax)Hierarchy[0];
		}
	}

	public FungibleTypeDecl(string fullyQualifiedName, Compilation compilation) :
		this(compilation.GetTypeByMetadataName(fullyQualifiedName)?.GetTypeSyntax()) { }

	public FungibleTypeDecl(HandleModel model, Compilation compilation, bool safe) : this((TypeDeclarationSyntax?)null)
	{
		INamedTypeSymbol? symbol = GetSymbolForHandle(model, safe, compilation);
		if (symbol is not null)
			decl = symbol?.GetTypeSyntax();
		if (decl is null)
		{
			Hierarchy = MakeTypeFromModel(model, safe);
			decl = Hierarchy is not null ? (TypeDeclarationSyntax)Hierarchy[0] : null;
		}
	}

	public IEnumerable<SyntaxNode> Ancestors => decl?.Parent?.AncestorsAndSelf() ?? Hierarchy?.Skip(1) ?? [];
	public TypeDeclarationSyntax? decl { get; } = td;
	public bool IsInvalid => decl is null;
	public string? Name => decl?.Identifier.Text;

	public static implicit operator FungibleTypeDecl(TypeDeclarationSyntax? tds) => new(tds);

	public static implicit operator TypeDeclarationSyntax?(FungibleTypeDecl ftd) => ftd.decl;

	public static bool operator !=(FungibleTypeDecl? left, FungibleTypeDecl? right) => !(left == right);

	public static bool operator ==(FungibleTypeDecl? left, FungibleTypeDecl? right) => left is null ? right is null : left.Equals((object?)right);

	public override bool Equals(object? obj) => obj switch
	{
		FungibleTypeDecl ftd => Equals(ftd),
		TypeDeclarationSyntax tds => TypeComparer.Default.Equals(decl, tds),
		_ => false,
	};

	public bool Equals(FungibleTypeDecl other) => ReferenceEquals(this, other) || TypeComparer.Default.Equals(decl, other.decl);

	public override int GetHashCode() => decl is null ? 0 : TypeComparer.Default.GetHashCode(decl);

	public override string ToString() => decl is null ? "[null]" : decl.Identifier.Text;

	int IComparable<FungibleTypeDecl>.CompareTo(FungibleTypeDecl other) => string.Compare(decl?.Identifier.Text, other.decl?.Identifier.Text);

	private static INamedTypeSymbol? GetSymbolForHandle(HandleModel? mod, bool safe, Compilation compilation) => mod is null
		? null!
		: compilation.GetTypeByMetadataName($"{mod.Namespace}.{mod.ParentClassName}.{(safe ? mod.ClassName : mod.HandleName)}");

	private static List<SyntaxNode> MakeTypeDecl(bool isStruct, string name, IEnumerable<SyntaxKind> modifiers,
		string? parentClassName, string namespaceName)
	{
		TypeDeclarationSyntax td = isStruct ? StructDeclaration(name) : ClassDeclaration(name);
		td = td.WithModifiers(TokenList(modifiers.Select(Token)));
		ClassDeclarationSyntax? parent = parentClassName is null ? null : ClassDeclaration(parentClassName)
			.WithModifiers(TokenList([MethodBodyBuilder.publicToken, MethodBodyBuilder.staticToken, Token(SyntaxKind.PartialKeyword)]));
		NamespaceDeclarationSyntax ns = NamespaceDeclaration(IdentifierName(namespaceName));
		return parent is null ? [td, ns] : [td, parent, ns];
	}

	private static List<SyntaxNode>? MakeTypeFromModel(HandleModel? mod, bool safe) => mod is null
		? null
		: MakeTypeDecl(!safe, safe ? mod.ClassName! : mod.HandleName,
		safe ? [SyntaxKind.PublicKeyword, SyntaxKind.PartialKeyword] : [SyntaxKind.PublicKeyword, SyntaxKind.ReadOnlyKeyword, SyntaxKind.PartialKeyword],
		mod.ParentClassName, mod.Namespace);
}