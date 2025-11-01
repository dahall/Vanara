using Microsoft.CodeAnalysis.CSharp;
using System.Collections.Immutable;
using System.Xml;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Vanara.Generators;

internal delegate void BuildMethodFunc(SourceProductionContext context, Compilation compilation, IEnumerable<FungibleTypeDecl> types, SyntaxNode decl, MethodDeclarationSyntax methodDecl, ImmutableArray<AttributeData> attrDatas, ref MethodBodyBuilder? existing);

internal delegate TypeDeclarationSyntax GetContainerTypeFunc(SourceProductionContext context, SyntaxNode decl, Compilation compilation);

internal abstract class AttrHandler(string attr, Func<SyntaxNode, CancellationToken, bool> validator)
{
	public string AttrName => attr;
	public Func<SyntaxNode, CancellationToken, bool> Validator => validator;
}

internal class MethAttrHandler(string attr, Func<SyntaxNode, CancellationToken, bool> validator, GetContainerTypeFunc container, Func<SyntaxNode, MethodDeclarationSyntax?> getmeth, BuildMethodFunc builder) :
	AttrHandler(attr, validator)
{
	public BuildMethodFunc bodyBuilder => builder;
	public GetContainerTypeFunc parent => container;
	public Func<SyntaxNode, MethodDeclarationSyntax?> meth => getmeth;
}

internal class TypeAttrHandler(string attr, Func<SyntaxNode, CancellationToken, bool> validator, Func<GeneratorAttributeSyntaxContext, TypeDeclarationSyntax>? getTypeDecl) :
	AttrHandler(attr, validator)
{
	public Func<GeneratorAttributeSyntaxContext, TypeDeclarationSyntax> type => getTypeDecl ?? TypeFromCtx;
	internal static TypeDeclarationSyntax TypeFromCtx(GeneratorAttributeSyntaxContext c) => (TypeDeclarationSyntax)c.TargetNode;
}

internal class MethodBodyBuilder(MethodDeclarationSyntax methodDecl)
{
	public const string retVarName = "__ret";
	public const string qretVarName = "__qret";
	public const string thisParamName = "__baseInterface";
	public static readonly SyntaxToken outToken = Token(SyntaxKind.OutKeyword);
	public static readonly SyntaxToken publicToken = Token(SyntaxKind.PublicKeyword);
	public static readonly SyntaxToken refToken = Token(SyntaxKind.RefKeyword);
	public static readonly SyntaxToken staticToken = Token(SyntaxKind.StaticKeyword);
	public static readonly ExpressionSyntax defaultExpr = ParseExpression("default");

	public string? asMemberOf = methodDecl.Parent is InterfaceDeclarationSyntax ? thisParamName : null;
	public TypeDeclarationSyntax? parentClass = methodDecl.Parent is InterfaceDeclarationSyntax ids ? ids.Parent as ClassDeclarationSyntax : methodDecl.Parent as ClassDeclarationSyntax;
	public XmlDocument? docs = methodDecl.GetDocs();
	public string? interfaceName = (methodDecl.Parent as InterfaceDeclarationSyntax)?.Identifier.Text;
	public string methodName = methodDecl.Identifier.Text;
	public HashSet<SyntaxToken> modifiers = [publicToken, staticToken];
	public List<ParameterSyntax> parameters = [.. methodDecl.ParameterList.Parameters];
	public TypeSyntax returnType = ParseTypeName(methodDecl.ReturnType.ToString());
	public StatementBuilder statements = new(methodDecl);
	public List<TypeParameterConstraintClauseSyntax> typeConstraints = [.. methodDecl.ConstraintClauses];
	public List<TypeParameterSyntax> typeParameters = [.. methodDecl.TypeParameterList?.Parameters ?? []];
	public bool isCtor = false;
	public string? ctorResultParamName = null;

	public MemberDeclarationSyntax ToMethod(string? altName = null)
	{
		// Create method declaration
		var ret = MethodDeclaration(returnType, altName ?? methodName)
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
		var returnIsVoid = methodDecl.ReturnType is PredefinedTypeSyntax pts && pts.Keyword.IsKind(SyntaxKind.VoidKeyword);
		StatementSyntax invokeStmt = returnIsVoid ? ExpressionStatement(invokeExpr) : LocalDeclarationStatement(VariableDeclaration(methodDecl.ReturnType.WithoutTrivia(),
			SeparatedList([VariableDeclarator(Identifier(retVarName), null, EqualsValueClause(invokeExpr))])));
		StatementSyntax? queryStmt = queryExpr is null ? null : (returnIsVoid ? ExpressionStatement(queryExpr) : LocalDeclarationStatement(VariableDeclaration(methodDecl.ReturnType.WithoutTrivia(),
			SeparatedList([VariableDeclarator(Identifier(qretVarName), null, EqualsValueClause(queryExpr))]))));

		string errHandler = isCtor
			? $"global::Vanara.PInvoke.FailedHelper.THROW_IF_FAILED({retVarName}, false);"
			: $"if (global::Vanara.PInvoke.FailedHelper.FAILED({retVarName}, false)) return {retVarName};";
		ret = ret.WithBody(Block(statements.setupVariables
			.Concat(statements.initOutParams)
			.Concat(statements.setupParams)
			.Concat([queryStmt]).WhereNotNull()
			.Concat(statements.queryFailureHandler)
			.Concat(statements.assignAfterQuery)
			.Concat([invokeStmt])
			.Concat(returnIsVoid ? [] : [ParseStatement(errHandler)])
			.Concat(statements.assignOutParams)
			.Concat([statements.ret]).WhereNotNull()
			.ToArray()));

		XmlDocument? tmpDocs = docs;
		if (interfaceName is not null)
		{
			tmpDocs = docs?.Clone() as XmlDocument;
			tmpDocs?.InsertParamDocAfter(thisParamName, $"The <see cref=\"{interfaceName}\"/> interface instance value used for the extension method.");
		}
		return tmpDocs is not null ? ret.WithDocs(tmpDocs) : ret;
	}

	public class StatementBuilder
	{
		public StatementBuilder(MethodDeclarationSyntax methodDecl)
		{
			returnIsVoid = methodDecl.ReturnType is PredefinedTypeSyntax pts && pts.Keyword.IsKind(SyntaxKind.VoidKeyword);
			var returnType = ParseTypeName(methodDecl.ReturnType.ToString());
			invokeArgs = [.. methodDecl.ParameterList.Parameters.Select(p => p.ParamToArg())];
			ret = returnIsVoid ? null : ReturnStatement(IdentifierName(retVarName));
		}

		// Get param types and attribute values for parameter and return values
		public List<StatementSyntax> setupVariables = [];

		// Initialize out params
		public List<StatementSyntax> initOutParams = [];

		// Setup parameter values
		public List<StatementSyntax> setupParams = [];

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

		public readonly bool returnIsVoid;
	}
}