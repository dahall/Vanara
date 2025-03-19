using Microsoft.CodeAnalysis.CSharp;
using System.Collections.Immutable;
using System.Runtime.InteropServices;
using Vanara.PInvoke;
using static Microsoft.CodeAnalysis.CSharp.SyntaxTokenParser;

namespace Vanara.Generators;

/// <summary></summary>
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
		syntaxNode is ParameterSyntax ms && 
		ms.Identifier.Text == "p3" &&
		((ms.Parent?.Parent?.Parent is ClassDeclarationSyntax cs && cs.IsPartial()) || ((ms.Parent?.Parent?.Parent is InterfaceDeclarationSyntax && ms.Parent?.Parent?.Parent?.Parent is ClassDeclarationSyntax ccs && ccs.IsPartial())));

	private static void Execute(SourceProductionContext context, (Compilation compilation, ImmutableArray<(ParameterSyntax, AttributeData)> classes) unit)
	{
		foreach ((ParameterSyntax decl, AttributeData attr) in unit.classes)
		{
			// Confirm that attribute has UnmanagedType.IUnknown or Interface and IidParameterIndex argument
			if (!ValidateAttr(attr, out var iidindex)) continue;

			// Split method info into modifiers, return type, method name, and arg list
			if (decl.Parent?.Parent is not MethodDeclarationSyntax methodDecl)
				continue;
			var modifiers = methodDecl.Modifiers;
			var returnType = methodDecl.ReturnType;
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
			var hasStructAttribute = hasInModifier ? false : iidParam.AttributeLists
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

			MethodDeclarationSyntax? methodSig1 = null, methodSig2 = null;

			// Handle interface methods
			if (decl.Parent?.Parent?.Parent is InterfaceDeclarationSyntax interfaceDecl)
			{
				// Create the extension method signature
				var interfaceName = interfaceDecl.Identifier.Text;
				const string thisParamName = "__baseInterface";
				const string genericType = "T";
				var newArgList = argList.
					Replace(decl, SyntaxFactory.Parameter(decl.Identifier).WithType(SyntaxFactory.ParseTypeName($"out {genericType}?"))).
					RemoveAt(iidindex).
					Insert(0, SyntaxFactory.Parameter(SyntaxFactory.Identifier(thisParamName)).WithType(SyntaxFactory.ParseTypeName($"this {interfaceName}")));

				// Create the invocation expression capturing the return value if the return type is not `void`
				var iArgs = argList.
					Replace(decl, SyntaxFactory.Parameter(SyntaxFactory.Identifier("__ppv"))).
					Select(arg => SyntaxFactory.Argument(SyntaxFactory.IdentifierName(arg.Identifier)).WithRefKindKeyword(SyntaxFactory.Token(SyntaxKind.OutKeyword))).ToArray();
				iArgs[iidindex] = SyntaxFactory.Argument(SyntaxFactory.ParseExpression($"typeof({genericType}).GUID"));
				var invocationExpression = SyntaxFactory.InvocationExpression(
					SyntaxFactory.MemberAccessExpression(SyntaxKind.SimpleMemberAccessExpression,
						SyntaxFactory.IdentifierName(thisParamName), SyntaxFactory.IdentifierName(methodName)),
						SyntaxFactory.ArgumentList(SyntaxFactory.SeparatedList(iArgs)));

				// Craete the assignment expression
				var assignmentExpression = SyntaxFactory.AssignmentExpression(
					SyntaxKind.SimpleAssignmentExpression,
					SyntaxFactory.IdentifierName(decl.Identifier),
					SyntaxFactory.CastExpression(SyntaxFactory.ParseTypeName($"({genericType}?)"), SyntaxFactory.IdentifierName("ppv"))
				);

				// If return type is not `void`, return the result of the invocation
				StatementSyntax? returnStatement = returnType.ToString() != "void" ? SyntaxFactory.ReturnStatement(SyntaxFactory.IdentifierName(decl.Identifier)) : null;

				// Create the statement syntax
				List<StatementSyntax> stmts1 = [SyntaxFactory.ExpressionStatement(invocationExpression),
					SyntaxFactory.ExpressionStatement(assignmentExpression)];
				if (returnStatement != null)
					stmts1.Add(returnStatement);

				methodSig1 = SyntaxFactory.MethodDeclaration(returnType, methodName)
					.AddModifiers(SyntaxFactory.Token(SyntaxKind.PublicKeyword), SyntaxFactory.Token(SyntaxKind.StaticKeyword))
					.AddTypeParameterListParameters(SyntaxFactory.TypeParameter(genericType))
					.WithParameterList(SyntaxFactory.ParameterList(newArgList))
					.WithConstraintClauses(new(SyntaxFactory.TypeParameterConstraintClause($"{genericType} : class")))
					.AddBodyStatements(stmts1.ToArray());

				methodSig2 = methodSig1;
			}
			// Handle class methods
			else if (decl.Parent?.Parent?.Parent is ClassDeclarationSyntax classDecl)
			{

			}

			if (methodSig1 == null || methodSig2 == null)
			{
				context.ReportError("VANGEN015", "Unable to create methods.");
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
			while (currentClass != null)
			{
				nestedClasses.Push(currentClass);
				currentClass = currentClass.Parent?.Parent as ClassDeclarationSyntax;
			}
			while (nestedClasses.Count > 0)
			{
				var nc = nestedClasses.Pop();
				output.AppendLine($"{nc.Modifiers} class {nc.Identifier} {{");
			}

			// Output the extension methods
			output.AppendLine(methodSig1.NormalizeWhitespace().ToFullString());
			output.AppendLine(methodSig2.NormalizeWhitespace().ToFullString());

			// Close the classes and namespace
			for (int i = 0; i <= nestedClasses.Count; i++)
				output.AppendLine("}");

			// Add the generated source to the context
			context.AddSource($"{parentClass.Identifier.Text}_Generated.cs", output.ToString());
		}

		static bool ValidateAttr(AttributeData attr, out int iidindex)
		{
			iidindex = -1;
			if (attr.AttributeClass?.ToDisplayString() == attributeFullName)
			{
				iidindex = 1;
				return true;
				//var firstArg = attr.ConstructorArguments.FirstOrDefault();
				//if (firstArg.Value is int unmanagedTypeValue &&
				//	(unmanagedTypeValue == (int)UnmanagedType.IUnknown || unmanagedTypeValue == (int)UnmanagedType.Interface))
				//{
				//	var iidParameterIndex = attr.NamedArguments.FirstOrDefault(na => na.Key == "IidParameterIndex");
				//	if (iidParameterIndex.Key != null)
				//	{
				//		iidindex = (int)iidParameterIndex.Value.Value!;
				//		return true;
				//	}
				//}
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
//		void GetObj(object? p1, in System.Guid p2, [System.Runtime.InteropServices.MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object? p3);
//	}

//	[System.Runtime.InteropServices.DllImport("test32.dll")]
//	public static extern int GetObjC(object? p1, in System.Guid p2, [System.Runtime.InteropServices.MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 1)] out object? p3);
//}

//public static partial class TestClass
//{
//	public static void GetObj<T>(this IUnkHolder __baseInterface, object? p1, out T? p3) where T : class
//	{
//		__baseInterface.GetObj(p1, typeof(T).GUID, out var ppv);
//		p3 = ppv as T;
//	}

//	public static T GetObj<T>(this IUnkHolder __baseInterface, object? p1) where T : class
//	{
//		__baseInterface.GetObj(p1, typeof(T).GUID, out var ppv);
//		return (T)ppv!;
//	}

//	public static HRESULT GetObjC<T>(object? p1, out T? p3) where T : class
//	{
//		HRESULT ret = GetObjC(p1, typeof(T).GUID, out var ppv);
//		p3 = ppv as T;
//		return ret;
//	}

//	public static T GetObjC<T>(object? p1) where T : class
//	{
//		GetObjC(p1, typeof(T).GUID, out var ppv).ThrowIfFailed();
//		return (T)ppv!;
//	}
//}
