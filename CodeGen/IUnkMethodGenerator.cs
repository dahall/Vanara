using Microsoft.CodeAnalysis.CSharp;
using System.Collections.Immutable;
using System.Runtime.InteropServices;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Vanara.Generators;

/// <summary>
/// A method generator that looks for methods with the <see cref="MarshalAsAttribute"/> on a <see cref="Nullable"/>&lt;<see
/// cref="object"/>&gt; parameter where <see cref="UnmanagedType.IUnknown"/> is set with an <c>IidParameterIndex</c> property set, and then
/// creates an extension method that calls that method infering the IID from the specified type.
/// </summary>
[Generator(LanguageNames.CSharp)]
public class IUnkMethodGenerator : IIncrementalGenerator
{
	private const string attributeFullName = "System.Runtime.InteropServices.MarshalAsAttribute";

	/// <summary>Called to initialize the generator and register generation steps via callbacks on the <paramref name="context"/></summary>
	/// <param name="context">
	/// The <see cref="T:Microsoft.CodeAnalysis.IncrementalGeneratorInitializationContext"/> to register callbacks on
	/// </param>
	public void Initialize(IncrementalGeneratorInitializationContext context)
	{
		var decl = context.SyntaxProvider.ForAttributeWithMetadataName(attributeFullName, IsValidSyntax,
			(ctx, _) =>
				((ParameterSyntax)ctx.TargetNode, ctx.Attributes.FirstOrDefault(a => attributeFullName.Equals(a.AttributeClass?.ToDisplayString())) ?? throw new InvalidOperationException("Attribute not found.")));
		var source = context.CompilationProvider.Combine(decl.Collect()).WithTrackingName("Syntax");
		context.RegisterSourceOutput(source, Execute);
	}

	private static bool IsValidSyntax(SyntaxNode syntaxNode, CancellationToken cancellationToken) =>
		syntaxNode is ParameterSyntax ps && ps.Parent?.Parent is MethodDeclarationSyntax ms &&
		((ms?.Parent is ClassDeclarationSyntax cs && cs.IsPartial()) || ((ms?.Parent is InterfaceDeclarationSyntax && ms?.Parent?.Parent is ClassDeclarationSyntax ccs && ccs.IsPartial())));

	private static void Execute(SourceProductionContext context, (Compilation compilation, ImmutableArray<(ParameterSyntax, AttributeData)> classes) unit)
	{
		var outToken = Token(SyntaxKind.OutKeyword);
		var refToken = Token(SyntaxKind.RefKeyword);

		foreach ((ParameterSyntax decl, AttributeData attr) in unit.classes)
		{
			// Confirm that attribute has UnmanagedType.IUnknown or Interface and IidParameterIndex argument
			if (!ValidateAttr(attr, out var iidindex)) continue;

			// Split method info into modifiers, return type, method name, and arg list
			MethodDeclarationSyntax methodDecl = (MethodDeclarationSyntax)decl.Parent!.Parent!;
			var modifiers = methodDecl.Modifiers;
			var returnType = methodDecl.ReturnType;
			bool returnIsVoid = returnType.ToString() == "void";
			var methodName = methodDecl.Identifier;
			var argList = methodDecl.ParameterList.Parameters;

			// Confirm IidParameterIndex points to a "in Guid" or "[UnmanagedType.Struct] Guid" value
			if (iidindex < 0 || iidindex >= argList.Count)
			{
				context.ReportError("VANGEN010", "IidParameterIndex does not reference a valid parameter index.");
				continue;
			}
			var iidParam = argList[iidindex];
			var paramType = iidParam.Type?.ToString();
			var hasInModifier = iidParam.Modifiers.Any(SyntaxKind.InKeyword);
			var hasStructAttribute = !hasInModifier && iidParam.AttributeLists
				.SelectMany(al => al.Attributes)
				.Any(attr => attr.Name.ToString() == "MarshalAs" && attr.ArgumentList?.Arguments.FirstOrDefault()?.ToString() == "UnmanagedType.Struct");
			if (paramType != "System.Guid" || !hasInModifier && !hasStructAttribute)
			{
				context.ReportError("VANGEN011", "IidParameterIndex does not reference a parameter of type Guid.");
				continue;
			}

			// Confirm interface type is Nullable<object>
			if (decl.Type?.ToString() != "object?")
			{
				context.ReportError("VANGEN012", "The parameter type is not nullable System.Object.");
				continue;
			}

			// Get the parent class or interface
			var parentClass = decl.Parent?.Parent?.Parent is ClassDeclarationSyntax cs ? cs : (decl.Parent?.Parent?.Parent is InterfaceDeclarationSyntax && decl.Parent?.Parent?.Parent?.Parent is ClassDeclarationSyntax ccs ? ccs : null);
			if (parentClass == null)
			{
				context.ReportError("VANGEN013", "Unable to find the parent class into which to insert the methods.");
				continue;
			}

			// Get the namespace of the parent class
			var ns = parentClass.Ancestors().OfType<NamespaceDeclarationSyntax>().FirstOrDefault()?.Name.ToString();
			if (ns == null)
			{
				context.ReportError("VANGEN014", "Unable to find the namespace into which to insert the methods.");
				continue;
			}

			MethodDeclarationSyntax? methodSig = null;

			// Handle interface methods
			if (decl.Parent?.Parent?.Parent is InterfaceDeclarationSyntax interfaceDecl)
			{
				// Create the extension method signature
				var interfaceName = interfaceDecl.Identifier.Text;
				const string thisParamName = "__baseInterface";
				const string genericType = "T";
				var newArgList = argList.
					Replace(decl, Parameter(default, TokenList([outToken]), ParseTypeName(genericType+'?'), decl.Identifier, default)).
					RemoveAt(iidindex).
					Insert(0, Parameter(default, TokenList([Token(SyntaxKind.ThisKeyword)]), ParseTypeName(interfaceName), Identifier(thisParamName), default));

				// Create the invocation expression capturing the return value if the return type is not `void`
				var iArgs = argList.Select(param => 
				{
					if (param == decl)
						return Argument(null, outToken, DeclarationExpression(IdentifierName("var"), SingleVariableDesignation(Identifier("__ppv"))));

					var arg = Argument(IdentifierName(param.Identifier));
					if (param.Modifiers.Count > 0)
					{
						if (param.Modifiers.First().ValueText == "out")
							return arg.WithRefKindKeyword(outToken);
						else if (param.Modifiers.First().ValueText == "ref")
							return arg.WithRefKindKeyword(refToken);
					}
					return arg;
				}).ToList();
				iArgs[iidindex] = Argument(ParseExpression($"typeof({genericType}).GUID"));
				var invocationExpression = InvocationExpression(
					MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression,
						IdentifierName(thisParamName), IdentifierName(methodName)),
						ArgumentList(SeparatedList(iArgs)));

				StatementSyntax invoker = returnIsVoid ? ExpressionStatement(invocationExpression) :
					LocalDeclarationStatement(VariableDeclaration(returnType, SeparatedList([
						VariableDeclarator(Identifier("__ret"), null, EqualsValueClause(invocationExpression))
					])));

				// Craete the assignment expression
				var assignmentExpression = AssignmentExpression(
					SyntaxKind.SimpleAssignmentExpression,
					IdentifierName(decl.Identifier),
					BinaryExpression(SyntaxKind.AsExpression, IdentifierName("__ppv"), ParseTypeName(genericType))
				);

				// If return type is not `void`, return the result of the invocation
				StatementSyntax? returnStatement = !returnIsVoid ? ReturnStatement(IdentifierName("__ret")) : null;

				// Create the statement syntax
				List<StatementSyntax> stmts1 = [invoker, ExpressionStatement(assignmentExpression)];
				if (returnStatement != null)
					stmts1.Add(returnStatement);

				methodSig = MethodDeclaration(returnType, methodName)
					.AddModifiers(Token(SyntaxKind.PublicKeyword), Token(SyntaxKind.StaticKeyword))
					.AddTypeParameterListParameters(TypeParameter(genericType))
					.WithParameterList(ParameterList(newArgList))
					.WithConstraintClauses(SyntaxList.Create([TypeParameterConstraintClause(IdentifierName(genericType), SingletonSeparatedList<TypeParameterConstraintSyntax>(ClassOrStructConstraint(SyntaxKind.ClassConstraint)))]))
					.AddBodyStatements([.. stmts1]);
			}
			// Handle class methods
			else if (decl.Parent?.Parent?.Parent is ClassDeclarationSyntax classDecl)
			{
				// Create the extension method signature
				const string genericType = "T";
				var newArgList = argList.
					Replace(decl, Parameter(default, TokenList([outToken]), ParseTypeName(genericType + '?'), decl.Identifier, default)).
					RemoveAt(iidindex);

				// Create the invocation expression capturing the return value if the return type is not `void`
				var iArgs = argList.Select(param =>
				{
					if (param == decl)
						return Argument(null, outToken, DeclarationExpression(IdentifierName("var"), SingleVariableDesignation(Identifier("__ppv"))));

					var arg = Argument(IdentifierName(param.Identifier));
					if (param.Modifiers.Count > 0)
					{
						if (param.Modifiers.First().ValueText == "out")
							return arg.WithRefKindKeyword(outToken);
						else if (param.Modifiers.First().ValueText == "ref")
							return arg.WithRefKindKeyword(refToken);
					}
					return arg;
				}).ToList();
				iArgs[iidindex] = Argument(ParseExpression($"typeof({genericType}).GUID"));
				var invocationExpression = InvocationExpression(IdentifierName(methodName),
					ArgumentList(SeparatedList(iArgs)));

				StatementSyntax invoker = returnIsVoid ? ExpressionStatement(invocationExpression) :
					LocalDeclarationStatement(VariableDeclaration(returnType, SeparatedList([
						VariableDeclarator(Identifier("__ret"), null, EqualsValueClause(invocationExpression))
					])));

				// Craete the assignment expression
				var assignmentExpression = AssignmentExpression(
					SyntaxKind.SimpleAssignmentExpression,
					IdentifierName(decl.Identifier),
					BinaryExpression(SyntaxKind.AsExpression, IdentifierName("__ppv"), ParseTypeName(genericType))
				);

				// If return type is not `void`, return the result of the invocation
				StatementSyntax? returnStatement = !returnIsVoid ? ReturnStatement(IdentifierName("__ret")) : null;

				// Create the statement syntax
				List<StatementSyntax> stmts1 = [invoker, ExpressionStatement(assignmentExpression)];
				if (returnStatement != null)
					stmts1.Add(returnStatement);

				methodSig = MethodDeclaration(returnType, methodName)
					.AddModifiers(Token(SyntaxKind.PublicKeyword), Token(SyntaxKind.StaticKeyword))
					.AddTypeParameterListParameters(TypeParameter(genericType))
					.WithParameterList(ParameterList(newArgList))
					.WithConstraintClauses(SyntaxList.Create([TypeParameterConstraintClause(IdentifierName(genericType), SingletonSeparatedList<TypeParameterConstraintSyntax>(ClassOrStructConstraint(SyntaxKind.ClassConstraint)))]))
					.AddBodyStatements([.. stmts1]);
			}

			if (methodSig == null)
			{
				context.ReportError("VANGEN015", "Unable to create method.");
				continue;
			}

			// Create the output string
			StringBuilder output = new(4096);
			output.AppendLine("using System;");
			output.AppendLine($"namespace {ns}");
			output.AppendLine("{");

			// Output nested classes
			var nestedClasses = new Stack<ClassDeclarationSyntax>();
			var currentClass = parentClass;
			StringBuilder stackName = new();
			while (currentClass != null)
			{
				nestedClasses.Push(currentClass);
				currentClass = currentClass.Parent?.Parent as ClassDeclarationSyntax;
			}
			while (nestedClasses.Count > 0)
			{
				var nc = nestedClasses.Pop();
				stackName.Append(nc.Identifier.Text).Append('_');
				output.AppendLine($"{nc.Modifiers} class {nc.Identifier} {{");
			}

			// Output the extension methods
			output.AppendLine(methodSig.NormalizeWhitespace().ToFullString());

			// Close the classes and namespace
			for (int i = 0; i <= nestedClasses.Count; i++)
				output.AppendLine("}");

			// Add the generated source to the context
			if (decl.Parent?.Parent?.Parent is InterfaceDeclarationSyntax id)
				stackName.Append(id.Identifier.Text).Append('_');
			context.AddSource($"{stackName}{methodName.Text}.g.cs", output.ToString());
		}

		static bool ValidateAttr(AttributeData attr, out int iidindex)
		{
			iidindex = -1;
			if (attr.ConstructorArguments.FirstOrDefault().Value is int unmanagedTypeValue &&
				(unmanagedTypeValue == (int)UnmanagedType.IUnknown || unmanagedTypeValue == (int)UnmanagedType.Interface))
			{
				var iidParameterIndex = attr.NamedArguments.FirstOrDefault(na => na.Key == "IidParameterIndex");
				if (iidParameterIndex.Key != null)
				{
					iidindex = (int)iidParameterIndex.Value.Value!;
					return true;
				}
			}
			return false;
		}
	}
}

//#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
//public static partial class TestClass
//{
//	public interface IUnkHolder
//	{
//		void GetObj(object? p1, in System.Guid p2, [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.IUnknown, IidParameterIndex = 1)] out object? p3);
//		int GetObjRet(in System.ConsoleKeyInfo p1, in System.Guid p2, [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.IUnknown, IidParameterIndex = 1)] out object? p3, out int p4);
//	}

//	[System.Runtime.InteropServices.DllImport("test32.dll")]
//	public static extern int GetObjC(object? p1, in System.Guid p2, [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.IUnknown, IidParameterIndex = 1)] out object? p3);
//}

//public static partial class TestClass
//{
//	public static void GetObj<T>(this IUnkHolder __baseInterface, object? p1, out T? p3) where T : class
//	{
//		__baseInterface.GetObj(p1, typeof(T).GUID, out var ppv);
//		p3 = ppv as T;
//	}

//	public static int GetObjRet<T>(this IUnkHolder __baseInterface, in System.ConsoleKeyInfo p1, out T? p3, out int p4) where T : class
//	{
//		int __ret = __baseInterface.GetObjRet(p1, typeof(T).GUID, out var ppv, out p4);
//		p3 = ppv as T;
//		return __ret;
//	}

//	public static int GetObjC<T>(object? p1, out T? p3) where T : class
//	{
//		int __ret = GetObjC(p1, typeof(T).GUID, out var ppv);
//		p3 = ppv as T;
//		return __ret;
//	}
//}
