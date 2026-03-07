using Microsoft.CodeAnalysis.CSharp;
using System.Collections.Immutable;
using System.Xml;
using System.Xml.Schema;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static Vanara.Generators.TypeDeclarationSyntaxExtensions;

namespace Vanara.Generators;

internal delegate void BuildMethodFunc(SourceProductionContext context, Compilation compilation, IEnumerable<FungibleTypeDecl> types, SyntaxNode decl, MethodDeclarationSyntax methodDecl, ImmutableArray<AttributeData> attrDatas, ref MethodBodyBuilder? existing);

internal delegate TypeDeclarationSyntax GetContainerTypeFunc(SourceProductionContext context, SyntaxNode decl, Compilation compilation);

internal abstract class AttrHandler(string attr, Func<SyntaxNode, CancellationToken, bool> validator, int order = 0)
{
	public string AttrName => attr;
	public int Order => order;
	public Func<SyntaxNode, CancellationToken, bool> Validator => validator;
}

internal class MethAttrHandler(string attr, Func<SyntaxNode, CancellationToken, bool> validator, GetContainerTypeFunc container, Func<SyntaxNode, MethodDeclarationSyntax?> getmeth, BuildMethodFunc builder, int order) :
	AttrHandler(attr, validator, order)
{
	public BuildMethodFunc bodyBuilder => builder;
	public GetContainerTypeFunc parent => container;
	public Func<SyntaxNode, MethodDeclarationSyntax?> meth => getmeth;
}

internal class TypeAttrHandler(string attr, Func<SyntaxNode, CancellationToken, bool> validator, Func<GeneratorAttributeSyntaxContext, TypeDeclarationSyntax>? getType, Func<(TypeDeclarationSyntax type, ImmutableArray<AttributeData> attrDatas), INamedTypeSymbol?> getRefType) :
	AttrHandler(attr, validator)
{
	public Func<GeneratorAttributeSyntaxContext, TypeDeclarationSyntax> type => getType ?? new(c => (TypeDeclarationSyntax)c.TargetNode);
	public Func<(TypeDeclarationSyntax type, ImmutableArray<AttributeData> attrDatas), INamedTypeSymbol?> reftype => getRefType;
}

internal static class MBBExt
{
	public static List<(string, ModType)> Has(this Dictionary<string, List<(string, ModType)>> d, string key) => d.TryGetValue(key, out var v) ? v : [];
}

internal class MethodBodyBuilder
{
	public const string retVarName = "__ret";
	public const string qretVarName = "__qret";
	public const string thisParamName = "__baseInterface";
	public static readonly SyntaxToken outToken = Token(SyntaxKind.OutKeyword);
	public static readonly SyntaxToken publicToken = Token(SyntaxKind.PublicKeyword);
	public static readonly SyntaxToken refToken = Token(SyntaxKind.RefKeyword);
	public static readonly SyntaxToken staticToken = Token(SyntaxKind.StaticKeyword);
	public static readonly ExpressionSyntax defaultExpr = ParseExpression("default");
	private readonly MethodDeclarationSyntax methodDecl;
	public string? asMemberOf;
	public TypeDeclarationSyntax? parentClass;
	public XmlDocument? docs;
	public string? interfaceName;
	public string methodName;
	public string topMethodName;
	public HashSet<SyntaxToken> modifiers = [publicToken, staticToken];
	public List<ParameterSyntax> parameters;
	public TypeSyntax returnType;
	public StatementBuilder statements;
	public List<TypeParameterConstraintClauseSyntax> typeConstraints;
	public List<TypeParameterSyntax> typeParameters;
	public bool ignoreErrHandler = false;
	public bool isCtor = false;
	public string? ctorResultParamName = null;
	public List<AttributeListSyntax> attributes = [];
	public Dictionary<string, List<(string, ModType)>> paramReferences = [];
#pragma warning disable CS0414 // Field is assigned but its value is never used
	private bool xmlInserted = false;
#pragma warning restore CS0414

	public MethodBodyBuilder(MethodDeclarationSyntax methodDecl)
	{
		this.methodDecl = methodDecl;
		asMemberOf = methodDecl.Parent is InterfaceDeclarationSyntax ? thisParamName : null;
		parentClass = methodDecl.Parent is InterfaceDeclarationSyntax ids ? ids.Parent as ClassDeclarationSyntax : methodDecl.Parent as ClassDeclarationSyntax;
		docs = methodDecl.GetDocs((s,e) => xmlInserted = true);
		interfaceName = (methodDecl.Parent as InterfaceDeclarationSyntax)?.Identifier.Text;
		methodName = methodDecl.Identifier.Text;
		topMethodName = methodDecl.Identifier.Text;
		parameters = [.. methodDecl.ParameterList.Parameters];
		returnType = ParseTypeName(methodDecl.ReturnType.ToString());
		statements = new(methodDecl);
		typeConstraints = [.. methodDecl.ConstraintClauses];
		typeParameters = [.. methodDecl.TypeParameterList?.Parameters ?? []];

		// For each parameter, get any references to it from other parameter attributes (SizeDef, ArrayPointer, and MarshalAs) and store them for reference in paramReferences
		foreach (var param in parameters)
		{
			foreach (var attr in param.AttributeLists.SelectMany(al => al.Attributes))
			{
				switch (attr.Name.ToString())
				{
					case "SizeDef":
						if (attr.ArgumentList?.Arguments.FirstOrDefault()?.Expression is InvocationExpressionSyntax le && le.ArgumentList.Arguments.FirstOrDefault()?.Expression is IdentifierNameSyntax n)
							AddAttrRef(n.Identifier.Text, param);
						break;
					case "ArrayPointer":
						if (attr.ArgumentList?.Arguments.ElementAtOrDefault(1)?.Expression is LiteralExpressionSyntax aple)
							AddAttrRef(aple.Token.ValueText, param);
						break;
					case "MarshalAs":
						if (attr.ArgumentList?.Arguments.FirstOrDefault()?.Expression is MemberAccessExpressionSyntax ma &&
							ma.Name.Identifier.Text is "LPArray" or "Interface" or "IUnknown" &&
							attr.ArgumentList.Arguments.Skip(1).FirstOrDefault(a => a.NameEquals?.Name.Identifier.Text is "SizeParamIndex" or "IidParameterIndex")?.Expression is LiteralExpressionSyntax male)
							AddAttrRef(parameters[Convert.ToInt32(male.Token.Value)].Identifier.Text, param);
						break;
					default:
						break;
				}
			}
		}

		void AddAttrRef(string refParamName, ParameterSyntax ps)
		{
			var input = (ps.Identifier.Text, GetModType(ps));
			if (paramReferences.TryGetValue(refParamName, out var refs))
				refs.Add(input);
			else
				paramReferences[refParamName] = [input];
		}
	}

	public MemberDeclarationSyntax ToMethod()
	{
		// Create method declaration
		var ret = MethodDeclaration(returnType, topMethodName)
			.WithAttributeLists(List(attributes))
			.WithModifiers(TokenList([.. modifiers]));
		if (typeParameters.Count > 0)
			ret = ret.WithTypeParameterList(TypeParameterList([.. typeParameters]));
		if (typeConstraints.Count > 0)
			ret = ret.WithConstraintClauses(List(typeConstraints));

		// Add parameters, removing MarshalAs attributes, including 'this' if extension method
		var modParameters = parameters.Select(p => p.WithoutAttribute("MarshalAs"));
		if (interfaceName is not null)
		{
			ParameterSyntax[] thisParam = [Parameter(default, TokenList([Token(SyntaxKind.ThisKeyword)]), ParseTypeName(interfaceName), Identifier(thisParamName), default)];
			ret = ret.WithParameterList(ParameterList([.. thisParam.Concat(modParameters)]));
		}
		else
			ret = ret.WithParameterList(ParameterList([.. modParameters]));

		string mbrName = string.IsNullOrEmpty(asMemberOf) ? parentClass!.Identifier.Text : asMemberOf!;
		TypeArgumentListSyntax typeArgs = TypeArgumentList(SeparatedList((methodDecl.TypeParameterList?.Parameters ?? []).Select(tp => ParseTypeName(tp.Identifier.Text))));
		SimpleNameSyntax nameSyntax = typeArgs.Arguments.Count > 0 ? GenericName(Identifier(methodName), typeArgs) : IdentifierName(methodName);
		InvocationExpressionSyntax invokeExpr = InvocationExpression(MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, IdentifierName(mbrName), nameSyntax),
			ArgumentList(SeparatedList(statements.invokeArgs)));
		InvocationExpressionSyntax? queryExpr = statements.invokeForQueryArgs is null || (!string.IsNullOrEmpty(asMemberOf) && !statements.invokeForQueryArgs.Any()) ? null
			: InvocationExpression(MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, IdentifierName(mbrName), nameSyntax),
				ArgumentList(SeparatedList(statements.invokeForQueryArgs)));

		if (queryExpr is null && ignoreErrHandler && statements.IsSimpleInvoke)
		{
			ret = ret.WithExpressionBody(ArrowExpressionClause(invokeExpr))
				.WithSemicolonToken(Token(SyntaxKind.SemicolonToken));
		}
		else
		{
			var returnIsVoid = methodDecl.ReturnType is PredefinedTypeSyntax pts && pts.Keyword.IsKind(SyntaxKind.VoidKeyword);
			StatementSyntax invokeStmt = returnIsVoid ? ExpressionStatement(invokeExpr) : LocalDeclarationStatement(VariableDeclaration(methodDecl.ReturnType.WithoutTrivia(),
				SeparatedList([VariableDeclarator(Identifier(retVarName), null, EqualsValueClause(invokeExpr))])));
			StatementSyntax? queryStmt = queryExpr is null ? null : (returnIsVoid ? ExpressionStatement(queryExpr) : LocalDeclarationStatement(VariableDeclaration(methodDecl.ReturnType.WithoutTrivia(),
				SeparatedList([VariableDeclarator(Identifier(qretVarName), null, EqualsValueClause(queryExpr))]))));

			string errHandler = isCtor
				? $"global::Vanara.PInvoke.FailedHelper.THROW_IF_FAILED({retVarName}, false);"
				: $"if (global::Vanara.PInvoke.FailedHelper.FAILED({retVarName}, false)) return {retVarName};";
			ret = ret.WithBody(Block(statements.setupVariables.Values
				.Concat(statements.initOutParams)
				.Concat(statements.setupArgs.DistinctBy(StmtToKey))
				.Concat([queryStmt]).WhereNotNull()
				.Concat(statements.queryFailureHandler.DistinctBy(StmtToKey))
				.Concat(statements.assignAfterQuery.DistinctBy(StmtToKey))
				.Concat([invokeStmt])
				.Concat(returnIsVoid || ignoreErrHandler || statements.assignOutParams.Count == 0 ? [] : [ParseStatement(errHandler)])
				.Concat(statements.assignOutParams)
				.Concat([statements.ret]).WhereNotNull()
				.ToArray()));
		}

		XmlDocument? tmpDocs = docs;
		if (interfaceName is not null)
		{
			tmpDocs = docs?.Clone() as XmlDocument;
			tmpDocs?.InsertParamDocAfter(thisParamName, $"The <see cref=\"{interfaceName}\"/> interface instance value used for the extension method.");
		}
		//return tmpDocs is null ? ret : (xmlInserted ? ret.WithDocs(tmpDocs) : ret.WithInheritDocs(methodDecl));
		return tmpDocs is null ? ret : ret.WithDocs(tmpDocs);

		static string StmtToKey(StatementSyntax s) => s.ToString();
	}

	internal MethodBodyBuilder MakeInvokableClone()
	{
		// Create method declaration for currently modified method
		var md = MethodDeclaration(returnType, methodName)
			.WithParameterList(ParameterList([.. parameters]));
		if (typeParameters.Count > 0)
			md = md.WithTypeParameterList(TypeParameterList([.. typeParameters]));
		if (typeConstraints.Count > 0)
			md = md.WithConstraintClauses(List(typeConstraints));
		if (docs is not null)
			md = md.WithDocs((XmlDocument)docs.Clone());
		return new MethodBodyBuilder(md) { parentClass = parentClass, };
	}

	public class StatementBuilder()
	{
		public StatementBuilder(MethodDeclarationSyntax methodDecl) : this()
		{
			returnIsVoid = methodDecl.ReturnType is PredefinedTypeSyntax pts && pts.Keyword.IsKind(SyntaxKind.VoidKeyword);
			var returnType = ParseTypeName(methodDecl.ReturnType.ToString());
			invokeArgs = [.. methodDecl.ParameterList.Parameters.Select(p => p.ParamToArg())];
			ret = returnIsVoid ? null : ReturnStatement(IdentifierName(retVarName));
		}

		// Get param types and attribute values for parameter and return values
		public Dictionary<string, StatementSyntax> setupVariables = [];

		// Initialize out params
		public List<StatementSyntax> initOutParams = [];

		// Declare default argument values
		public List<StatementSyntax> setupArgs = [];

		// Call method for query
		public List<ArgumentSyntax>? invokeForQueryArgs = null;

		// Return on query failure
		public List<StatementSyntax> queryFailureHandler = [];

		// Assign variables after query
		public List<StatementSyntax> assignAfterQuery = [];

		// Call method for real
		public List<ArgumentSyntax> invokeArgs = [];

		// Get out params
		public List<StatementSyntax> assignOutParams = [];

		// Return
		public StatementSyntax? ret = null;

		public bool returnIsVoid;

		internal bool IsSimpleInvoke => setupVariables.Count == 0 && initOutParams.Count == 0 && setupArgs.Count == 0 &&
			(invokeForQueryArgs is null || invokeForQueryArgs.Count == 0) && queryFailureHandler.Count == 0 &&
			assignAfterQuery.Count == 0 && assignOutParams.Count == 0;
	}
}