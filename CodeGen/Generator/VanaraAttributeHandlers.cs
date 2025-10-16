using Microsoft.CodeAnalysis.CSharp;
using System.Collections.Immutable;
using System.Linq.Expressions;
using System.Xml;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Vanara.Generators;

internal delegate void BuildMethodFunc(SourceProductionContext context, Compilation compilation, ParameterSyntax decl, MethodDeclarationSyntax methodDecl, ImmutableArray<AttributeData> attrDatas, ref MethodBodyBuilder? existing);

internal delegate TypeDeclarationSyntax GetContainerTypeFunc(SourceProductionContext context, ParameterSyntax decl);

internal abstract class AttrHandler(string attr, Func<SyntaxNode, CancellationToken, bool> validator)
{
	public string AttrName => attr;
	public Func<SyntaxNode, CancellationToken, bool> Validator => validator;
}

internal class MethAttrHandler(string attr, Func<SyntaxNode, CancellationToken, bool> validator, BuildMethodFunc builder, GetContainerTypeFunc container, Func<ParameterSyntax, MethodDeclarationSyntax> getmeth) :
	AttrHandler(attr, validator)
{
	public BuildMethodFunc bodyBuilder => builder;
	public GetContainerTypeFunc parent => container;
	public Func<ParameterSyntax, MethodDeclarationSyntax> meth => getmeth;
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
	public XmlDocument? docs = methodDecl.GetDocs();
	public string? interfaceName = (methodDecl.Parent as InterfaceDeclarationSyntax)?.Identifier.Text;
	public string methodName = methodDecl.Identifier.Text;
	public HashSet<SyntaxToken> modifiers = [publicToken, staticToken];
	public List<ParameterSyntax> parameters = [.. methodDecl.ParameterList.Parameters];
	public TypeSyntax returnType = ParseTypeName(methodDecl.ReturnType.ToString());
	public StatementBuilder statements = new(methodDecl);
	public List<TypeParameterConstraintClauseSyntax> typeConstraints = [.. methodDecl.ConstraintClauses];
	public List<TypeParameterSyntax> typeParameters = [.. methodDecl.TypeParameterList?.Parameters ?? []];

	public MethodDeclarationSyntax ToMethod()
	{
		MethodDeclarationSyntax ret = MethodDeclaration(returnType, methodName)
			.WithModifiers(TokenList([.. modifiers]));
		if (typeParameters.Count > 0)
			ret = ret.WithTypeParameterList(TypeParameterList([.. typeParameters]));
		if (interfaceName is not null)
		{
			ParameterSyntax[] thisParam = [Parameter(default, TokenList([Token(SyntaxKind.ThisKeyword)]), ParseTypeName(interfaceName), Identifier(thisParamName), default)];
			ret = ret.WithParameterList(ParameterList([.. thisParam.Concat(parameters)]));
		}
		else
			ret = ret.WithParameterList(ParameterList([.. parameters]));
		if (typeConstraints.Count > 0)
			ret = ret.WithConstraintClauses(List(typeConstraints));

		InvocationExpressionSyntax invokeExpr;
		InvocationExpressionSyntax? queryExpr;
		if (string.IsNullOrEmpty(asMemberOf))
		{
			invokeExpr = InvocationExpression(IdentifierName(methodName), ArgumentList(SeparatedList(statements.invokeArgs)));
			queryExpr = statements.invokeForQueryArgs is null ? null : InvocationExpression(IdentifierName(methodName), ArgumentList(SeparatedList(statements.invokeForQueryArgs)));
		}
		else
		{
			invokeExpr = InvocationExpression(MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, IdentifierName(asMemberOf!), IdentifierName(methodName)), ArgumentList(SeparatedList(statements.invokeArgs)));
			queryExpr = statements.invokeForQueryArgs is null || !statements.invokeForQueryArgs.Any() ? null : InvocationExpression(MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression, IdentifierName(asMemberOf!), IdentifierName(methodName)), ArgumentList(SeparatedList(statements.invokeForQueryArgs)));
		}
		var returnIsVoid = methodDecl.ReturnType is PredefinedTypeSyntax pts && pts.Keyword.IsKind(SyntaxKind.VoidKeyword);
		StatementSyntax invokeStmt = returnIsVoid ? ExpressionStatement(invokeExpr) : LocalDeclarationStatement(VariableDeclaration(returnType, SeparatedList([VariableDeclarator(Identifier(retVarName), null, EqualsValueClause(invokeExpr))])));
		StatementSyntax? queryStmt = queryExpr is null ? null : (returnIsVoid ? ExpressionStatement(queryExpr) : LocalDeclarationStatement(VariableDeclaration(returnType, SeparatedList([VariableDeclarator(Identifier(qretVarName), null, EqualsValueClause(queryExpr))]))));


		ret = ret.WithBody(Block(statements.setupVariables
			.Concat(statements.initOutParams)
			.Concat(statements.setupParams)
			.Concat([queryStmt]).WhereNotNull()
			.Concat(statements.queryFailureHandler)
			.Concat(statements.assignAfterQuery)
			.Concat([invokeStmt])
			.Concat(returnIsVoid ? [] : [ParseStatement($"if (global::Vanara.PInvoke.FailedHelper.FAILED({retVarName}, false)) return {retVarName};")])
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