//#define TEST
//#define DEBUGGING_SLN
using Microsoft.CodeAnalysis.CSharp;
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using System.Runtime.InteropServices;
using System.Xml;
using System.Xml.Linq;
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
		syntaxNode is ParameterSyntax ps && ps.Type?.ToString() == "object?" && ps.Modifiers.Any(SyntaxKind.OutKeyword) && ps.Parent?.Parent is MethodDeclarationSyntax ms &&
		!ms.Modifiers.Any(SyntaxKind.NewKeyword) && !ms.AttributeLists.SelectMany(al => al.Attributes).Any(a => a.Name.ToString().Contains("SuppressAutoGen")) &&
#if TEST
		ps.Identifier.ValueText == "p3" &&
#endif
		((ms?.Parent is ClassDeclarationSyntax cs && cs.IsPartial()) || ((ms?.Parent is InterfaceDeclarationSyntax && ms?.Parent?.Parent is ClassDeclarationSyntax ccs && ccs.IsPartial())));

	private static void Execute(SourceProductionContext context, (Compilation compilation, ImmutableArray<(ParameterSyntax, AttributeData)> classes) unit)
	{
		var outToken = Token(SyntaxKind.OutKeyword);
		var refToken = Token(SyntaxKind.RefKeyword);

		foreach ((ParameterSyntax decl, AttributeData attr) in unit.classes)
		{
			// Confirm that attribute has UnmanagedType.IUnknown or Interface and IidParameterIndex argument
			if (!ValidateAttr(decl, attr, out var iidindex))
			{
#if DEBUGGING_SLN
				context.ReportError(decl, "VANGEN019", $"Invalid attribute");
#endif
				continue;
			}

			try
			{
				// Split method info into modifiers, return type, method name, and arg list
				MethodDeclarationSyntax methodDecl = (MethodDeclarationSyntax)decl.Parent!.Parent!;
				var modifiers = methodDecl.Modifiers;
				var returnType = methodDecl.ReturnType.WithoutLeadingTrivia();
				bool returnIsVoid = returnType.ToString() == "void";
				var methodName = methodDecl.Identifier;
				var argList = methodDecl.ParameterList.Parameters;

				// Confirm IidParameterIndex points to a "in Guid" or "[UnmanagedType.Struct] Guid" value
				if (iidindex < 0 || iidindex >= argList.Count)
				{
#if DEBUGGING_SLN
				context.ReportError(methodDecl, "VANGEN010", $"IidParameterIndex does not reference a valid parameter index. method: iid={iidindex} argc={argList.Count} method={methodDecl}");
#endif
					continue;
				}
				var iidParam = argList[iidindex];
				var paramType = iidParam.Type?.ToString();
				var hasInModifier = iidParam.Modifiers.Any(SyntaxKind.InKeyword);
				var hasStructAttribute = !hasInModifier && iidParam.AttributeLists
					.SelectMany(al => al.Attributes)
					.Any(attr => attr.Name.ToString() == "MarshalAs" && attr.ArgumentList?.Arguments.FirstOrDefault()?.ToString() == "UnmanagedType.Struct");
				if (paramType != "System.Guid" && paramType != "Guid" || !hasInModifier && !hasStructAttribute)
				{
#if DEBUGGING_SLN
				context.ReportError(methodDecl, "VANGEN011", $"IidParameterIndex does not reference a parameter of type Guid. iid={iidindex} param={iidParam.ToFullString()} paramType={paramType} modif={iidParam.Modifiers}");
#endif
					continue;
				}

				// Confirm param type is Nullable<object>
				if (decl.Type?.ToString() != "object?")
				{
					context.ReportError(decl, "VANGEN012", "The parameter type is not nullable System.Object.");
					continue;
				}

				// Get the parent class or interface
				var parentClass = decl.Parent?.Parent?.Parent is ClassDeclarationSyntax cs ? cs : (decl.Parent?.Parent?.Parent is InterfaceDeclarationSyntax && decl.Parent?.Parent?.Parent?.Parent is ClassDeclarationSyntax ccs ? ccs : null);
				if (parentClass == null)
				{
					context.ReportError(decl, "VANGEN013", "Unable to find the parent class into which to insert the methods.");
					continue;
				}

				// Get the namespace of the parent class
				var ns = parentClass.Ancestors().OfType<BaseNamespaceDeclarationSyntax>().FirstOrDefault()?.Name.ToString();
				if (ns == null)
				{
					context.ReportError(parentClass, "VANGEN014", "Unable to find the namespace into which to insert the methods.");
					continue;
				}

				MethodDeclarationSyntax? methodSig = null;

				// Handle interface methods
				string? interfaceName = null;
				const string genericType = "T";
				const string thisParamName = "__baseInterface";
				if (decl.Parent?.Parent?.Parent is InterfaceDeclarationSyntax interfaceDecl)
				{
					// Create the extension method signature
					interfaceName = interfaceDecl.Identifier.Text;
					var newArgList = argList.
						Replace(decl, Parameter(default, TokenList([outToken]), ParseTypeName(genericType + '?'), decl.Identifier, default)).
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
						.WithModifiers(TokenList(Token(SyntaxKind.PublicKeyword), Token(SyntaxKind.StaticKeyword)))
						.AddTypeParameterListParameters(TypeParameter(genericType))
						.WithParameterList(ParameterList(newArgList))
						.WithConstraintClauses(SyntaxList.Create([TypeParameterConstraintClause(IdentifierName(genericType), SingletonSeparatedList<TypeParameterConstraintSyntax>(ClassOrStructConstraint(SyntaxKind.ClassConstraint)))]))
						.AddBodyStatements([.. stmts1]);
				}
				// Handle class methods
				else if (decl.Parent?.Parent?.Parent is ClassDeclarationSyntax classDecl)
				{
					// Create the extension method signature
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
						.WithModifiers(TokenList(Token(SyntaxKind.PublicKeyword), Token(SyntaxKind.StaticKeyword)))
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

				// Process the xml docs for the method
				var docComment = methodDecl.GetLeadingTrivia().Where(t => t.IsKind(SyntaxKind.SingleLineDocumentationCommentTrivia)).FirstOrDefault().ToString();
				if (!string.IsNullOrEmpty(docComment))
				{
					// Remove the leading /// from the doc comment
					docComment = $"<xmlDoc>\r\n{Regex.Replace(docComment, @"^\s*(///\s*)?", @"", RegexOptions.Multiline)}\r\n</xmlDoc>";

					// Load the xml docs into an XmlDocument
					XmlDocument xmlDoc = new();
					xmlDoc.LoadXml(docComment);

					// Get the xml node for the IID parameter docs
					XmlNode? iidNode = xmlDoc.SelectSingleNode($"//param[@name='{iidParam.Identifier}']");
					if (iidNode is not null)
					{
						var iidText = iidNode.InnerXml;

						// Add the IID parameter docs to the method docs as the value of the typeParam tag
						var typeParamNode = xmlDoc.CreateElement("typeParam");
						typeParamNode.SetAttribute("name", genericType);
						typeParamNode.InnerXml = iidText;
						var summaryNode = xmlDoc.SelectSingleNode("//summary");
						if (summaryNode is not null)
							summaryNode.ParentNode.InsertAfter(typeParamNode, summaryNode);
						else
							xmlDoc.DocumentElement.InsertBefore(typeParamNode, xmlDoc.DocumentElement.FirstChild);

						// Remove the IID parameter docs
						iidNode.ParentNode?.RemoveChild(iidNode);

						// If this is an interface method, add the 'this' interface parameter docs to the method docs
						if (interfaceName is not null)
						{
							var iParamNode = xmlDoc.CreateElement("param");
							iParamNode.SetAttribute("name", thisParamName);
							iParamNode.InnerXml = $"The <see cref=\"{interfaceName}\"/> interface instance value used for the extension method.";
							typeParamNode.ParentNode.InsertAfter(iParamNode, typeParamNode);
						}

						// Preface each line of the non-document xml elements with '/// '
						XDocument xdoc = XDocument.Parse(xmlDoc.DocumentElement.OuterXml);
						List<string> docLines = [.. xdoc.ToString().Split(["\r\n"], StringSplitOptions.RemoveEmptyEntries)];
						docLines.RemoveAt(0); docLines.RemoveAt(docLines.Count - 1);
						StringBuilder outXml = new();
						for (int i = 0; i < docLines.Count; i++)
							outXml.AppendLine("/// " + docLines[i].TrimStart(' ', '\t'));
						methodSig = methodSig.WithLeadingTrivia(ParseLeadingTrivia(outXml.ToString()));
					}
				}

				// Create the output string
				using var outputString = new StringWriter();
				using var output = new IndentedTextWriter(outputString);

				// Output the nullable directive and the warning disable directive
				output.WriteLine("#nullable enable");
				if (methodDecl.GetLeadingTrivia().Where(t => t.IsKind(SyntaxKind.SingleLineDocumentationCommentTrivia)).Count() == 0)
					output.WriteLine("#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member");

				// Output the usings statements for the parentClass
				foreach (var u in parentClass.Ancestors().OfType<CompilationUnitSyntax>().First().Usings.Where(i => i.GlobalKeyword.Value is null))
					output.WriteLine($"{u.ToFullString()}");

				// Output the namespace
				output.WriteLine($"namespace {ns} {{");
				output.Indent++;

				// Output nested classes
				Stack<ClassDeclarationSyntax> nestedClasses = new();
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
					stackName.Append(nc.Identifier.Text).Append('.');
					output.WriteLine($"{nc.Modifiers} class {nc.Identifier} {{");
					output.Indent++;
				}

				// Output the extension methods
				output.WriteLine(methodSig.NormalizeWhitespace().ToFullString());

				// Close the classes and namespace
				for (int i = 0; i <= nestedClasses.Count; i++)
				{
					output.Indent--;
					output.WriteLine("}");
				}
				output.Indent--;
				output.Write('}');

				// Add the generated source to the context
				if (interfaceName is not null)
					stackName.Append(interfaceName).Append('.');
				context.AddSource($"{stackName}{methodName.Text}.g.cs", outputString.ToString());
			}
			catch (Exception ex)
			{
				context.ReportError(decl, "VANGEN016", $"Error generating method: {ex.Message} {ex.StackTrace}");
			}
		}

		static bool ValidateAttr(ParameterSyntax decl, AttributeData attr, out int iidindex)
		{
			iidindex = -1;
#if TEST
			// This is for testing only
			if (decl.Identifier.ValueText == "p3")
			{
				string attrText = decl.AttributeLists.SelectMany(l => l.Attributes).FirstOrDefault(a => attributeFullName.StartsWith(a.Name.ToString()))?.ToString() ?? "";
				var m = Regex.Match(attrText, @"IidParameterIndex\s*=\s*(\d+)");
				return m.Success && int.TryParse(m.Groups[1].Value, out iidindex);
			}
#endif
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
//	/// <summary>
//	/// 
//	/// </summary>
//	/// <typeparam name="T"></typeparam>
//	/// <param name="__baseInterface">The <see cref="IUnkHolder"/> interface</param>
//	/// <param name="p1"></param>
//	/// <param name="p3"></param>
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
