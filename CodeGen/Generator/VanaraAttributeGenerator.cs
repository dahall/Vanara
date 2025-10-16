//#define DEBUGGING_SLN
/* NOTES
 * 
 * AddAsMember cannot be applied to methods in interfaces
 * AddAsMember should not be applied to parameters of types not defined in its assembly unless that type is the reference of a
 *    DeferAutoMethodFromAttribute attribute on a partial class defined in this assembly
 * When munging methods, change any optional SafeHandle parameter to nullable and handle null value in body replacing with SafeHandle.Null
 * When munging methods, convert [In] arrays to Span<> or IEnumerable<>
 * For UnmangedType.Interface with IidParamIndex specfied and a type specified, create munged method with that param passed automatically
 * 
 * Method steps:
 *   Get param types and attribute values for parameter and return values
 *   Initialize out params
 *   Setup parameter values
 *   Call method for query
 *   Return on query failure
 *   Assign variables after query
 *   Call method for real
 *   Return on failure
 *   Get out params
 *   Return
 *   
 *   
 *   
 * Attr							NewOjb	ChgMeth	AddMeth
 * ----							----	----	----
 * HandleFile					X		
 * MarshalAs(IUnknown)					X
 * SuppressAutoGen						X
 * Ignore								X
 * AdjustAutoMethodNamePattern			X
 * SizeDef								X
 * MarshaledAlternative							X	
 * AddAsCtor									X	
 * AddAsMember									X	
 * DeferAutoMethodFrom							X	
 * AutoHandle									X	
 * AutoSafeHandle								X	

*/

using Microsoft.CodeAnalysis.CSharp;
using System.Collections.Immutable;
using System.Runtime.InteropServices;
using System.Xml;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace Vanara.Generators;

/// <summary>
/// A source generator that creates extension methods for types based on the presence of the <c>AddAsMemberAttribute</c> on method parameters.
/// </summary>
[Generator(LanguageNames.CSharp)]
public partial class VanaraAttributeGenerator : IIncrementalGenerator
{
	[Flags]
	internal enum SizingMethod
	{
		Count = 0x0,
		Bytes = 0x1,
		InclNullTerm = 0x2,
		Query = 0x4,
		QueryResultInReturn = 0xC,
		CheckLastError = 0x14,
		Guess = 0x20,
	}

	[Flags]
	internal enum SizeParamType
	{
		Nullable = 0x1,
		String = 0x2,
		Array = 0x4,
		Ptr = 0x8,
	}

	static int uid = 1;
	static string UniqueName(string n) => $"{n}{uid++}";

	static readonly MethAttrHandler[] methodAttributes = [
		new("System.Runtime.InteropServices.MarshalAsAttribute", IsParamWithArgs, BuildMarshalAsMethod, ParentForExtMethod, GetParamMeth), // IUnknown, Interface, LPArray
		new("Vanara.PInvoke.IgnoreAttribute", IsParamInNotNewMethod, BuildIgnoreMethod, ParentForExtMethod, GetParamMeth),
		new("Vanara.PInvoke.SizeDefAttribute", IsParamInNotNewMethod, BuildSizeDefMethod, ParentForExtMethod, GetParamMeth),
		new("Vanara.PInvoke.AddAsCtorAttribute", IsParamInNotNewStaticMethod, DummyBuilder, GetParamType, GetParamMeth),
		new("Vanara.PInvoke.AddAsMemberAttribute", IsParamInNotNewStaticMethod, DummyBuilder, GetParamType, GetParamMeth),
		//("Vanara.PInvoke.SuppressAutoGenAttribute", static (n, t) => n is MethodDeclarationSyntax),
	];

	static readonly TypeAttrHandler[] typeAttributes = [
		new("Vanara.PInvoke.AdjustAutoMethodNamePatternAttribute", IsPartialType, null),
		new("Vanara.PInvoke.DeferAutoMethodFromAttribute", IsPartialType, static (ctx) => (TypeDeclarationSyntax)ctx.TargetNode),
	];

	static MethodDeclarationSyntax GetParamMeth(ParameterSyntax decl) => (MethodDeclarationSyntax)decl.Parent!.Parent!;

	/// <inheritdoc/>
	public void Initialize(IncrementalGeneratorInitializationContext context)
	{
		// Process each attribute in the methodAttributes array
		var attributeProviders = methodAttributes
			.Select(attr => context.SyntaxProvider.ForAttributeWithMetadataName(attr.AttrName, (n, t) => attr.Validator(n, t) && NoSuppress(attr.meth((ParameterSyntax)n)), (ctx, _) => ((ParameterSyntax)ctx.TargetNode, ctx.Attributes)).Collect())
			.ToArray();

		// Process type-level methodAttributes (those without method transforms)
		var typeProviders = typeAttributes
			.Select(attr => context.SyntaxProvider.ForAttributeWithMetadataName(attr.AttrName, attr.Validator, (ctx, _) => (attr.type(ctx), ctx.Attributes)).Collect())
			.ToArray();

		//var defferals = context.SyntaxProvider.ForAttributeWithMetadataName("Vanara.PInvoke.DeferAutoMethodFromAttribute",
		//	(syntaxNode, cancellationToken) => syntaxNode is StructDeclarationSyntax or ClassDeclarationSyntax && ((TypeDeclarationSyntax)syntaxNode).IsPartial(),
		//	(ctx, _) => (TypeDeclarationSyntax)ctx.TargetNode);

		var handlesFiles = HandlesFromFileGenerator.GetHandleFileContentProvider(context);

		// Combine everything together
		var source = context.CompilationProvider
			.Combine(handlesFiles)
			.Combine(typeProviders[0])
			.Combine(typeProviders[1])
			.Combine(attributeProviders[0])
			.Combine(attributeProviders[1])
			.Combine(attributeProviders[2])
			.Combine(attributeProviders[3])
			.Combine(attributeProviders[4])
			.WithTrackingName("Syntax");

		context.RegisterSourceOutput(source, (spc, value) =>
			GenerateCode(spc, value.Left.Left.Left.Left.Left.Left.Left.Left, value.Left.Left.Left.Left.Left.Left.Left.Right,
			value.Right.AddRange(value.Left.Right).AddRange(value.Left.Left.Right).AddRange(value.Left.Left.Left.Right).AddRange(value.Left.Left.Left.Left.Right),
			value.Left.Left.Left.Left.Left.Right.AddRange(value.Left.Left.Left.Left.Left.Left.Right)));

		static bool NoSuppress(MethodDeclarationSyntax ms) => !ms.Modifiers.Any(SyntaxKind.NewKeyword) && !ms.AttributeLists.SelectMany(al => al.Attributes).Any(a => a.Name.ToString().Contains("SuppressAutoGen"));
	}

	private static void GenerateCode(SourceProductionContext context, Compilation compilation, ImmutableArray<AdditionalText> addtlFiles, ImmutableArray<(ParameterSyntax paramNode, ImmutableArray<AttributeData> attrDatas)> paramNodes,
		ImmutableArray<(TypeDeclarationSyntax type, ImmutableArray<AttributeData> attrDatas)> typeNodes)
	{
		uid = 1;

		// Process handlesCsv to get list of new types
		var handles = HandlesFromFileGenerator.EnumHandleModels(context, addtlFiles).Select(h => (ns: h.Namespace, parent: h.ParentClassName, handle: h.HandleName, safehandle: h.ClassName)).ToList();

		// Get list of all types that will hold methods
		//var types = paramNodes.Select(TypeFromParam).GroupBy(t => t.Identifier.altArgBase).Select(t => t.First()).ToDictionary(t => t, t => new Dictionary<MethodDeclarationSyntax, MethodBodyBuilder>(SyntaxComparer.Default), SyntaxComparer.Default);
		var types = paramNodes.Select(TypeFromParam).DistinctBy(t => t.Identifier.Text).ToDictionary(t => t, t => new Dictionary<MethodDeclarationSyntax, MethodBodyBuilder>(SyntaxComparer.Default), SyntaxComparer.Default);

		// Process all DeferAutoMethodFromAttribute and replace the typeSyms entry if found with the type from the attribute
		foreach (var (type, attrs) in typeNodes.Where(p => p.attrDatas.First().AttributeClass?.ToDisplayString() == "Vanara.PInvoke.DeferAutoMethodFromAttribute"))
		{
			var attr = attrs.FirstOrDefault();
			if (attr is not null && attr.ConstructorArguments.Length > 0 && attr.ConstructorArguments[0].Value is INamedTypeSymbol tsym)
			{
				// TODO: Find tsym in types and find a way to identify it as having been deferred
			}
		}

		// Get a dictionary of all string munges
		var munges = typeNodes.Where(n => n.attrDatas.First().AttributeClass?.ToDisplayString() == "Vanara.PInvoke.AdjustAutoMethodNamePatternAttribute")!
			.SelectMany(tas => tas.attrDatas.Select(a => (tas.type, a)))
			.SelectMany(ta => ta.a.ConstructorArguments.First().Values.Select(tc => (ta.type, ((string p, string r))tc.Value!)))
			.ToDictionary(s => s.type, s => s.Item2);

		foreach (var typeGroup in types)
		{
			var typeDecl = (TypeDeclarationSyntax)typeGroup.Key;
			var methLookup = typeGroup.Value;
			List<UsingDirectiveSyntax> usings = [];
			foreach (var pa in paramNodes.Where(pa => TypeFromParam(pa).Identifier.Text == typeDecl.Identifier.Text))
			{
				var handler = GetHandler(pa);
				var methDecl = handler.meth(pa.paramNode);
				methLookup.TryGetValue(methDecl, out MethodBodyBuilder? methBuilder);
				try { handler.bodyBuilder(context, compilation, pa.paramNode, methDecl, pa.attrDatas, ref methBuilder); }
				catch (Exception ex)
				{
					context.ReportError(methDecl, "VANGEN999", "Unknown error: " + Regex.Replace(ex.ToString(), "[\r\n]+", " "));
					continue;
				}
				if (methBuilder is not null)
				{
					methLookup[methDecl] = methBuilder;
					usings.AddRange(pa.paramNode.SyntaxTree.GetRoot().DescendantNodes().OfType<UsingDirectiveSyntax>().Where(u => u.GlobalKeyword.IsKind(SyntaxKind.None)).Select(u => u.WithoutTrivia()));
				}
			}

			if (methLookup.Count == 0)
				continue;

			// Add distinct using directives from 'usings' to the compilation unit
			usings = [.. usings.DistinctBy(u => u.Name?.ToString())];

			// Build new syntax tree, starting with nsDecl, adding any containing types with their modifiers, and finally the typeDecl with the new values from methLookup.Values
			SyntaxNode topDecl = typeDecl.WithMembers(List<MemberDeclarationSyntax>(methLookup.Values.Select(bb => bb.ToMethod())));
			foreach (var parent in typeDecl.Ancestors())
			{
				topDecl = parent switch
				{
					ClassDeclarationSyntax cds => ClassDeclaration(cds.Identifier.Text)
						.WithModifiers(cds.Modifiers)
						.WithTypeParameterList(cds.TypeParameterList)
						.WithConstraintClauses(cds.ConstraintClauses)
						.WithLeadingTrivia(cds.GetLeadingTrivia())
						.WithTrailingTrivia(cds.GetTrailingTrivia())
						.WithMembers(SingletonList((MemberDeclarationSyntax)topDecl)),
					StructDeclarationSyntax sds => StructDeclaration(sds.Identifier.Text)
						.WithModifiers(sds.Modifiers)
						.WithTypeParameterList(sds.TypeParameterList)
						.WithConstraintClauses(sds.ConstraintClauses)
						.WithLeadingTrivia(sds.GetLeadingTrivia())
						.WithTrailingTrivia(sds.GetTrailingTrivia())
						.WithMembers(SingletonList((MemberDeclarationSyntax)topDecl)),
					BaseNamespaceDeclarationSyntax nds => NamespaceDeclaration(nds.Name)
						.WithMembers(SingletonList((MemberDeclarationSyntax)topDecl))
						.WithLeadingTrivia(nds.GetLeadingTrivia())
						.WithTrailingTrivia(nds.GetTrailingTrivia()),
					_ => topDecl
				};
			}

			// Create compilation unit with using directives outside the namespace
			var compilationUnit = CompilationUnit()
				.WithUsings(List(usings))
				.WithMembers(SingletonList((MemberDeclarationSyntax)topDecl))
				.WithLeadingTrivia(
					TriviaList(
						Trivia(NullableDirectiveTrivia(Token(SyntaxKind.EnableKeyword), true)),
						Trivia(PragmaWarningDirectiveTrivia(Token(SyntaxKind.DisableKeyword), true)
							.WithErrorCodes(SingletonSeparatedList<ExpressionSyntax>(LiteralExpression(SyntaxKind.NumericLiteralExpression, Literal(1591)))))
					)
				);

			// Output
			context.AddSource($"{typeDecl!.Identifier.Text}_AttrGen.g.cs", compilationUnit.NormalizeWhitespace().ToFullString());
		}

		TypeDeclarationSyntax TypeFromParam((ParameterSyntax paramNode, ImmutableArray<AttributeData> attrDatas) p) => GetHandler(p).parent(context, p.paramNode);
		static MethAttrHandler GetHandler((ParameterSyntax paramNode, ImmutableArray<AttributeData> attrDatas) p) => methodAttributes.First(a => a.AttrName == p.attrDatas.First().AttributeClass?.ToDisplayString());
	}

	private static void DummyBuilder(SourceProductionContext context, Compilation compilation, ParameterSyntax decl, MethodDeclarationSyntax methodDecl, ImmutableArray<AttributeData> attrDatas, ref MethodBodyBuilder? builder)
	{
	}

	private static void BuildSizeDefMethod(SourceProductionContext context, Compilation compilation, ParameterSyntax decl, MethodDeclarationSyntax methodDecl, ImmutableArray<AttributeData> attrDatas, ref MethodBodyBuilder? builder)
	{
		MethodBodyBuilder tmpbuilder = builder ?? new(methodDecl);

		if (!ValidateAttr(out var szParam, out var sz, out var szMeth, out var charSet, out var outSzParam, out var bufSzParam))
			return;

		// Determine the output type from the parameter type: if it's a StringBuilder, then string, else the element type of the array or IntPtr
		(TypeSyntax? outType, SizeParamType szType) = decl.Type?.ToString() switch
		{
			"string" or "StringBuilder" => (PredefinedType(Token(SyntaxKind.StringKeyword)), SizeParamType.String),
			"string?" or "StringBuilder?" => (NullableType(PredefinedType(Token(SyntaxKind.StringKeyword))), SizeParamType.String | SizeParamType.Nullable),
			var s when (s ?? "").EndsWith("[]") == true => (decl.Type!.WithoutTrivia(), SizeParamType.Array),
			var s when (s ?? "").EndsWith("[]?") == true => (decl.Type!.WithoutTrivia(), SizeParamType.Array | SizeParamType.Nullable),
			//"IntPtr" or "System.IntPtr" => ParseTypeName("System.IntPtr"),
			_ => (null, 0),
		};

		// TODO: Remove once arrays and pointers implemented
		if (outType is null)
			return;

		bool isNullable = decl.Type is NullableTypeSyntax || decl.Type?.ToString().EndsWith("?") == true;

		// Replace the decl and remove the szParam parameters from the method signature
		tmpbuilder.parameters.Replace(decl, decl.WithoutAttribute("SizeDef").WithoutAttribute("In").WithModifiers(TokenList(Token(SyntaxKind.OutKeyword))).WithType(outType));
		if (szParam is not null) tmpbuilder.parameters.Remove(szParam);

		// Initialize out param
		(ExpressionSyntax? outNullVal, ExpressionSyntax? outDefVal) = szType switch
		{
			var t when t.HasFlag(SizeParamType.String) => (MethodBodyBuilder.defaultExpr, ParseExpression("string.Empty")),
			var t when t.HasFlag(SizeParamType.Array) => (MethodBodyBuilder.defaultExpr, ParseExpression("[]")),
			//"IntPtr" => ,
			_ => (null, null),
		};
		if (outNullVal is null || outDefVal is null)
		{
			context.ReportError(decl, "VANGEN029", "SizeDef attribute currently only supports parameters of type string, StringBuilder, or arrays.");
			return;
		}
		tmpbuilder.statements.initOutParams.Add(ExpressionStatement(AssignmentExpression(SyntaxKind.SimpleAssignmentExpression, IdentifierName(decl.Identifier),
			isNullable ? outNullVal : outDefVal)));

		// Setup parameter values
		// 1. Create statement that creates a variable for the size of the type of szParam and assigns it the value of default (query) or sz
		var szVarName = szParam is null ? UniqueName("__sz") : szParam.Identifier.Text;
		TypeSyntax szVarTypeDecl = szParam is null ? PredefinedType(Token(SyntaxKind.IntKeyword)) : szParam.Type!;
		tmpbuilder.statements.setupParams.Add(LocalDeclarationStatement(VariableDeclaration(szVarTypeDecl)
			.WithVariables(SingletonSeparatedList(VariableDeclarator(Identifier(szVarName))
				.WithInitializer(EqualsValueClause(szMeth.HasFlag(SizingMethod.Query) ? MethodBodyBuilder.defaultExpr : ParseExpression(sz)))))));

		// When query
		if (szMeth.HasFlag(SizingMethod.Query))
		{
			// Call method for query, if sizing method is Query
			// Assign variables after query
			tmpbuilder.statements.invokeForQueryArgs ??= [.. tmpbuilder.statements.invokeArgs.Select(a => a.WithoutTrivia())];
			if (szMeth.HasFlag(SizingMethod.QueryResultInReturn))
			{
				tmpbuilder.statements.invokeForQueryArgs = [.. tmpbuilder.statements.invokeForQueryArgs.Select(a => a switch
				{
					ArgumentSyntax arg when arg.NameEquals(decl.Identifier.Text) => Argument(DefaultExpression(decl.Type!)),
					ArgumentSyntax arg when szParam is not null && arg.NameEquals(szParam.Identifier.Text) => Argument(IdentifierName(szVarName)),
					_ => a
				})];
				tmpbuilder.statements.assignAfterQuery.Insert(0,
					ExpressionStatement(AssignmentExpression(SyntaxKind.SimpleAssignmentExpression, IdentifierName(szVarName), IdentifierName(MethodBodyBuilder.qretVarName))));
			}
			else if (szMeth.HasFlag(SizingMethod.CheckLastError))
			{
				tmpbuilder.statements.invokeForQueryArgs = [.. tmpbuilder.statements.invokeForQueryArgs.Select(a => a switch
				{
					ArgumentSyntax arg when arg.NameEquals(decl.Identifier.Text) => Argument(DefaultExpression(decl.Type!)),
					ArgumentSyntax arg when szParam is not null && arg.NameEquals(szParam.Identifier.Text) && outSzParam is null => Argument(null, MethodBodyBuilder.refToken, IdentifierName(szVarName)),
					ArgumentSyntax arg when szParam is not null && arg.NameEquals(szParam.Identifier.Text) && outSzParam is not null => Argument(IdentifierName(szVarName)),
					_ => a
				})];
			}
			else
			{
				tmpbuilder.statements.invokeForQueryArgs = [.. tmpbuilder.statements.invokeForQueryArgs.Select(a => a switch
				{
					ArgumentSyntax arg when arg.NameEquals(decl.Identifier.Text) && isNullable => Argument(DefaultExpression(decl.Type!)),
					ArgumentSyntax arg when arg.NameEquals(decl.Identifier.Text) && szType.HasFlag(SizeParamType.String) => Argument(ParseExpression("new StringBuilder(0)")),
					ArgumentSyntax arg when arg.NameEquals(decl.Identifier.Text) && szType.HasFlag(SizeParamType.Array) => Argument(ParseExpression("[]")),
					ArgumentSyntax arg when szParam is not null && arg.NameEquals(szParam.Identifier.Text) && outSzParam is null => Argument(null, MethodBodyBuilder.refToken, IdentifierName(szVarName)),
					ArgumentSyntax arg when szParam is not null && arg.NameEquals(szParam.Identifier.Text) && outSzParam is not null => Argument(IdentifierName(szVarName)),
					_ => a
				})];
			}

			// Return on query failure
			tmpbuilder.statements.queryFailureHandler.Add(
				ParseStatement($"if (global::Vanara.PInvoke.FailedHelper.FAILED({MethodBodyBuilder.qretVarName}, {(szMeth.HasFlag(SizingMethod.CheckLastError) ? "true" : "false")})) return {MethodBodyBuilder.qretVarName};"));
		}

		// Assign variables before final method call
		// 1. Create a statement that creates a variable for the output of decl and initializes it to the value of 'sz'
		var outVarName = UniqueName("__out");
		// 2. Create a variable that holds the number of elements initialized to the value of szVarName
		var cElemName = UniqueName("__cElem");
		tmpbuilder.statements.assignAfterQuery.Add(LocalDeclarationStatement(VariableDeclaration(PredefinedType(Token(SyntaxKind.IntKeyword)))
			.WithVariables(SingletonSeparatedList(VariableDeclarator(Identifier(cElemName))
				.WithInitializer(EqualsValueClause(ParseExpression($"Convert.ToInt32({szVarName})")))))));
		// 3. Create statement that adjusts to bytes if indicated
		if (szMeth.HasFlag(SizingMethod.Bytes))
		{
			var getElemSize = szType switch
			{
				var t when t.HasFlag(SizeParamType.String) => $"global::Vanara.Extensions.StringHelper.GetCharSize(CharSet.{charSet})",
				var t when t.HasFlag(SizeParamType.Array) && isNullable => $"global::Vanara.Extensions.InteropExtensions.SizeOf(typeof({((ArrayTypeSyntax)((NullableTypeSyntax)outType!).ElementType).ElementType}), CharSet.{charSet})",
				var t when t.HasFlag(SizeParamType.Array) && !isNullable => $"global::Vanara.Extensions.InteropExtensions.SizeOf(typeof({((ArrayTypeSyntax)outType!).ElementType}), CharSet.{charSet})",
				_ => "1",
			};
			var expr = ExpressionStatement(AssignmentExpression(SyntaxKind.DivideAssignmentExpression, IdentifierName(cElemName), ParseExpression(getElemSize)));
			tmpbuilder.statements.assignAfterQuery.Add(expr);
		}
		// 4. Create statement that adjusts for null term if indicated
		if (szMeth.HasFlag(SizingMethod.InclNullTerm))
		{
			var expr = ExpressionStatement(AssignmentExpression(SyntaxKind.SubtractAssignmentExpression, IdentifierName(cElemName), ParseExpression("1")));
			tmpbuilder.statements.assignAfterQuery.Add(expr);
		}
		// 5. If the outType is string, initialize to new StringBuilder(sz)
		var outVarDecl = VariableDeclaration(decl.Type!);
		outVarDecl = szType switch
		{
			var t when t.HasFlag(SizeParamType.String) => outVarDecl
				.WithVariables(SingletonSeparatedList(VariableDeclarator(Identifier(outVarName))
					.WithInitializer(EqualsValueClause(ImplicitObjectCreationExpression()
						.WithArgumentList(ArgumentList(SingletonSeparatedList(Argument(ParseExpression(cElemName))))))))),
			var t when t.HasFlag(SizeParamType.Array) => (decl.Type is ArrayTypeSyntax ats ? ats : (decl.Type is NullableTypeSyntax nts && nts.ElementType is ArrayTypeSyntax nats ? nats : null))?
				.CreateArrayVariableDeclaration(outVarName, cElemName) ?? outVarDecl,
			//"IntPtr" => ,
			_ => outVarDecl,
		};
		tmpbuilder.statements.assignAfterQuery.Add(LocalDeclarationStatement(outVarDecl));

		// Call method for real
		// 1. Replace the reference to the parameter in the method body invokeArgs statement with outVarName
		var sdArg = tmpbuilder.statements.invokeArgs.FirstOrDefault(a => a.NameEquals(decl.Identifier.Text));
		if (sdArg != null)
			tmpbuilder.statements.invokeArgs.Replace(sdArg, Argument(IdentifierName(outVarName)));

		// Get out params
		// 1. Set the output parameter to the value of outVarName, converting as needed
		ExpressionSyntax? assignExpr = szType switch
		{
			var t when t.HasFlag(SizeParamType.String) => ParseExpression($"{outVarName}.ToString()"),
			_ => ParseExpression(outVarName),
		};
		if (assignExpr is not null)
			tmpbuilder.statements.assignOutParams.Add(ExpressionStatement(AssignmentExpression(SyntaxKind.SimpleAssignmentExpression, IdentifierName(decl.Identifier), assignExpr)));

		// Process the xml docs for the method, removing the ignored param
		if (szParam is not null)
			tmpbuilder.docs?.RemoveParamDoc(szParam.Identifier.Text);

		builder = tmpbuilder;

		bool ValidateAttr(out ParameterSyntax? szParam, out string sz, out SizingMethod szMeth, out CharSet charSet, out ParameterSyntax? outSzParam, out ParameterSyntax? bufSzParam)
		{
			szParam = outSzParam = bufSzParam = null;
			sz = "0";
			szMeth = attrDatas.FirstOrDefault()?.ConstructorArguments.ElementAtOrDefault(1).Value is int ism ? (SizingMethod)ism : SizingMethod.Count;
			charSet = decl.GetCharSet();

			// TODO: Implement Guess
			if ((szMeth & (SizingMethod.Bytes | SizingMethod.InclNullTerm | SizingMethod.QueryResultInReturn | SizingMethod.CheckLastError)) != szMeth)
				return false;

			// From 'decl', get the ParameterSyntax for the parameter referenced by the first string argument in the SizeDef attribute
			var arg = attrDatas.FirstOrDefault()?.ConstructorArguments.FirstOrDefault().Value;
			if (arg is string s)
			{
				if (string.IsNullOrEmpty(s) || (szParam = methodDecl.ParameterList.Parameters.FirstOrDefault(p => p.Identifier.Text == s)) is null)
				{
					context.ReportError(decl, "VANGEN023", "SizeDef attribute must have a valid parameter name as its first argument.");
					return false;
				}
				var outarg = attrDatas.FirstOrDefault()?.NamedArguments.FirstOrDefault(na => na.Key == "OutVarName").Value.Value;
				if (outarg is string os && !string.IsNullOrEmpty(os))
				{
					if ((outSzParam = methodDecl.ParameterList.Parameters.FirstOrDefault(p => p.Identifier.Text == os)) is null)
					{
						context.ReportError(decl, "VANGEN024", "SizeDef attribute must have a valid parameter name as its OutVarName named argument.");
						return false;
					}
					if (!outSzParam.Modifiers.Any(SyntaxKind.OutKeyword) && !outSzParam.Modifiers.Any(SyntaxKind.RefKeyword))
					{
						context.ReportError(decl, "VANGEN025", "SizeDef attribute OutVarName parameter must be passed by ref or out.");
						return false;
					}
				}
				var bufarg = attrDatas.FirstOrDefault()?.NamedArguments.FirstOrDefault(na => na.Key == "BufferVarName").Value.Value;
				if (bufarg is string bs && !string.IsNullOrEmpty(bs))
				{
					if ((bufSzParam = methodDecl.ParameterList.Parameters.FirstOrDefault(p => p.Identifier.Text == bs)) is null)
					{
						context.ReportError(decl, "VANGEN030", "SizeDef attribute must have a valid parameter name as its BufferVarName named argument.");
						return false;
					}
					if (!bufSzParam.Modifiers.Any(SyntaxKind.OutKeyword) && !bufSzParam.Modifiers.Any(SyntaxKind.RefKeyword))
					{
						context.ReportError(decl, "VANGEN031", "SizeDef attribute BufferVarName parameter must be passed by ref or out.");
						return false;
					}
				}

				AttributeSyntax rngAttr = szParam.AttributeLists.SelectMany(al => al.Attributes).FirstOrDefault(a => a.NameEquals("Range"));
				// If rngAttr is found, get its second constructor argument value as an int and use that as sz
				if (rngAttr is not null && rngAttr.ArgumentList is not null && rngAttr.ArgumentList.Arguments.Count > 1)
				{
					sz = rngAttr.ArgumentList.Arguments[1].Expression.ToString() ?? "0";
				}
				// If rngAttr is not found, use the max value of the parameter type if it's an integral type
				else
				{
					long? tsz = szParam.Type?.ToString() switch
					{
						"byte" => byte.MaxValue,
						"sbyte" => sbyte.MaxValue,
						"short" => short.MaxValue,
						_ => ushort.MaxValue - 1,
					};
					if (tsz is null)
					{
						context.ReportError(decl, "VANGEN026", "SizeDef attribute must have a Range attribute on its size parameter or the size parameter must be an integral type.");
						return false;
					}
					sz = tsz.ToString()!;
				}
			}
			else if (arg is int isz)
			{
				sz = isz.ToString();
			}

			// If a normal query, ensure szParam is by ref
			if (szMeth.HasFlag(SizingMethod.Query))
			{
				bool qret = szMeth.HasFlag(SizingMethod.QueryResultInReturn), qle = szMeth.HasFlag(SizingMethod.CheckLastError);
				if (!qret && !qle && (szParam is null || (!szParam.Modifiers.Any(SyntaxKind.RefKeyword) && outSzParam is null && bufSzParam is null)))
				{
					context.ReportError(decl, "VANGEN027", "SizeDef attribute with Query sizing method requires the referenced parameter to be passed by ref.");
					return false;
				}
				if (qret && ((szParam is null || szParam.Modifiers.Any(SyntaxKind.RefKeyword)) || outSzParam is not null))
				{
					context.ReportError(decl, "VANGEN028", "SizeDef attribute with QueryResultInReturn sizing method requires the referenced parameter to be passed by value and no OutVarName specified.");
					return false;
				}
			}

			return true;
		}
	}

	private static void BuildIgnoreMethod(SourceProductionContext context, Compilation compilation, ParameterSyntax decl, MethodDeclarationSyntax methodDecl, ImmutableArray<AttributeData> attrDatas, ref MethodBodyBuilder? builder)
	{
		MethodBodyBuilder tmpbuilder = builder ?? new(methodDecl);

		// Remove the parameter from the method signature
		var idx = tmpbuilder.parameters.FindIndex(t => t.IsEquivalentTo(decl));
		if (idx >= 0)
		{
			// If the parameter is not optional, report an error
			if (!decl.AttributeLists.SelectMany(al => al.Attributes).Any(a => a.Name.ToString() == "Optional"))
			{
				context.ReportError(decl, "VANGEN022", "Ignore parameters must be optional.");
				return;
			}
			tmpbuilder.parameters.RemoveAt(idx);
		}

		// Replace any references to the parameter in the method body invokeArgs statement with default values or uncaptured out params
		List<ArgumentSyntax>?[] argLists = [tmpbuilder.statements.invokeArgs, tmpbuilder.statements.invokeForQueryArgs];
		foreach (var args in argLists)
		{
			if (args is null) continue;
			var igArg = args.FirstOrDefault(a => a.NameEquals(decl.Identifier.Text));
			if (igArg is null)
			{
				context.ReportError(decl, "VANGEN023", $"Unable to locate Ignore param with same name as declaration.");
				return;
			}
			// If the parameter is an out param, replace with 'out var __ignore' else replace with 'default'
			var igidx = args.FindIndex(a => a.IsEquivalentTo(igArg));
			if (igidx < 0) continue;
			args[igidx] = args[igidx].RefKindKeyword.ValueText == "out" ? Argument(ParseExpression("out _")) : Argument(MethodBodyBuilder.defaultExpr);
		}

		// Process the xml docs for the method, removing the ignored param
		tmpbuilder.docs?.RemoveParamDoc(decl.Identifier.Text);

		builder = tmpbuilder;
	}

	[Flags]
	private enum ModType
	{
		In = 1,
		Out = 2,
		Ref = 3
	}

	private static void BuildMarshalAsMethod(SourceProductionContext context, Compilation compilation, ParameterSyntax decl, MethodDeclarationSyntax methodDecl, ImmutableArray<AttributeData> attrDatas, ref MethodBodyBuilder? builder)
	{
		// Determine if the decl is an in or out or ref param
		bool isOutParam = decl.Modifiers.Any(SyntaxKind.OutKeyword);
		ModType modAttr = (decl.AttributeLists.SelectMany(al => al.Attributes).Any(a => a.Name.ToString() == "Out") ? ModType.Out : 0)
			| (decl.AttributeLists.SelectMany(al => al.Attributes).Any(a => a.Name.ToString() == "In") ? ModType.In : 0);
		if (modAttr == 0) modAttr = isOutParam ? ModType.Out : ModType.In;

		// Determine if the decl has the MarshalAs attribute with contructor first argument of UnmanagedType.IUnknown or UnmanagedType.IInterface and a named argument of IidParameterIndex
		if (!ValidateAttr(out string refParamName, out var unmanagedType))
			return;

		MethodBodyBuilder tmpbuilder = builder ?? new(methodDecl);
		var argList = tmpbuilder.parameters;
		bool paramTypeIsNullable = decl.Type is NullableTypeSyntax || decl.Type?.ToString().EndsWith("?") == true;
		bool returnIsVoid = tmpbuilder.returnType.ToString() == "void";

		const string genericTypeBase = "__TIUnk";
		const string altArgBase = "__ppv";
		string genericType = UniqueName(genericTypeBase);
		string altArg = isOutParam ? UniqueName(altArgBase) : string.Empty;

		// Create the extension method signature, removing this attribute
		if (unmanagedType == UnmanagedType.IUnknown)
		{
			tmpbuilder.typeParameters.Add(TypeParameter(genericType));
			tmpbuilder.typeConstraints.Add(TypeParameterConstraintClause(IdentifierName(genericType), SingletonSeparatedList<TypeParameterConstraintSyntax>(ClassOrStructConstraint(SyntaxKind.ClassConstraint))));
		}
		ParameterSyntax newParam = unmanagedType switch
		{
			UnmanagedType.IUnknown => decl.WithType(ParseTypeName(genericType + (decl.Type is not null && decl.Type.ToString().EndsWith("?") ? "?" : "")))
				.WithoutAttribute("MarshalAs"),
			UnmanagedType.Interface => decl.WithoutAttribute("MarshalAs"),
			_ => decl.WithoutTrivia()
		};
		tmpbuilder.parameters.Replace(decl, newParam);
		tmpbuilder.parameters.Remove(refParamName);

		// Initialize out param
		if (isOutParam)
		{
			var expr = ExpressionStatement(AssignmentExpression(SyntaxKind.SimpleAssignmentExpression, IdentifierName(decl.Identifier), MethodBodyBuilder.defaultExpr));
			if (!paramTypeIsNullable)
				expr = expr.WithLeadingTrivia(Trivia(NullableDirectiveTrivia(Token(SyntaxKind.DisableKeyword), true))).WithTrailingTrivia(Trivia(NullableDirectiveTrivia(Token(SyntaxKind.RestoreKeyword), true)));
			tmpbuilder.statements.initOutParams.Add(expr);
		}

		// Create the invocation expression capturing the return value if the return type is not `void`
		tmpbuilder.statements.invokeArgs = [.. tmpbuilder.statements.invokeArgs.Select(a => a switch
			{
				var a1 when a1.NameEquals(refParamName) => Argument(ParseExpression($"typeof({(unmanagedType == UnmanagedType.IUnknown ? genericType : decl.Type!.ToString().TrimEnd('?'))}).GUID")),
				var a1 when a1.Expression is IdentifierNameSyntax ins && ins.Identifier.Text == decl.Identifier.Text => isOutParam
					? Argument(null, MethodBodyBuilder.outToken, DeclarationExpression(IdentifierName("var"), SingleVariableDesignation(Identifier(altArg))))
					: Argument(IdentifierName(ins.Identifier.Text)),
				_ => a
			})];

		// Create the assignment expression
		if (isOutParam)
		{
			if (unmanagedType == UnmanagedType.IUnknown)
			{
				tmpbuilder.statements.assignOutParams.Add(ExpressionStatement(AssignmentExpression(
					SyntaxKind.SimpleAssignmentExpression, IdentifierName(decl.Identifier),
					BinaryExpression(SyntaxKind.AsExpression, IdentifierName(altArg), ParseTypeName(genericType)))));
			}
			else
			{
				tmpbuilder.statements.assignOutParams.Add(ExpressionStatement(AssignmentExpression(
					SyntaxKind.SimpleAssignmentExpression, IdentifierName(decl.Identifier), IdentifierName(altArg))));
			}
		}

		// Process the xml docs for the method
		if (tmpbuilder.docs is not null)
		{
			// Get the xml node for the IID parameter docs
			XmlNode? iidNode = tmpbuilder.docs.SelectSingleNode($"//param[@name='{refParamName}']");
			if (iidNode is not null)
			{
				// Add the IID parameter docs to the method docs as the value of the typeParam tag
				if (unmanagedType == UnmanagedType.IUnknown)
					tmpbuilder.docs.InsertTypeParamDocAfter(genericType, iidNode.InnerXml);

				// Remove the IID parameter docs
				iidNode.ParentNode?.RemoveChild(iidNode);
			}
		}

		builder = tmpbuilder;

		bool ValidateAttr(out string refParamName, out UnmanagedType unmanagedType)
		{
			refParamName = "";
			unmanagedType = 0;

			// Get the refindex from the attribute
			var refindex = -1;
			var attr = decl.GetAttr("MarshalAs");
			if (attr?.ArgumentList?.Arguments.FirstOrDefault()?.Expression is MemberAccessExpressionSyntax maes &&
				maes.Expression.ToFullString() == "UnmanagedType" && Enum.TryParse(maes.Name.ToFullString(), out unmanagedType))
			{
				switch (unmanagedType)
				{
					case UnmanagedType.Interface:
						if (decl.Type?.ToString() is "object" or "object?")
						{
							unmanagedType = UnmanagedType.IUnknown;
							refindex = GetIndex("IidParameterIndex");
							break;
						}
						else if (decl.Type?.ToString()?.StartsWith("I") ?? false)
						{
							refindex = GetIndex("IidParameterIndex");
							break;
						}
						context.ReportError(decl, "VANGEN021", "The parameter type is not System.Object or a named interface.");
						return false;

					case UnmanagedType.IUnknown:
						// Confirm param type is Nullable<object>
						if (decl.Type?.ToString() is not "object" and not "object?")
							return false;

						refindex = GetIndex("IidParameterIndex");
						break;

					case UnmanagedType.LPArray:
					//refindex = GetIndex("SizeParamIndex");
					//if (refindex == -1 || modAttr != ModType.In)
					//	return false;
					//break;
					default:
						return false;
				}
			}

			// If there's an refindex, then make sure it points to a valid Guid parameter
			if (refindex >= 0)
			{
				var iidParam = methodDecl.ParameterList.Parameters[refindex];
				var paramType = iidParam.Type?.ToString();
				var hasInModifier = iidParam.Modifiers.Any(SyntaxKind.InKeyword);
				var hasStructAttribute = !hasInModifier && iidParam.AttributeLists
					.SelectMany(al => al.Attributes)
					.Any(attr => attr.Name.ToFullString() == "MarshalAs" && attr.ArgumentList?.Arguments.FirstOrDefault()?.ToString() == "UnmanagedType.Struct");
				if ((paramType == "System.Guid" || paramType == "Guid") && (hasInModifier || hasStructAttribute))
				{
					refParamName = iidParam.Identifier.Text;
					return true;
				}
			}
			return false;

			int GetIndex(string attrNamedArg)
			{
				var namedArg = attr.ArgumentList?.Arguments.FirstOrDefault(a => a.NameEquals?.Name.ToString() == attrNamedArg);
				return namedArg?.Expression is LiteralExpressionSyntax les && les.IsKind(SyntaxKind.NumericLiteralExpression)
					&& les.Token.Value is int i ? i : -1;
			}
		}
	}

	private static TypeDeclarationSyntax GetFirstTypeParent(SourceProductionContext context, ParameterSyntax decl) => decl.GetParentKind<TypeDeclarationSyntax>();

	private static TypeDeclarationSyntax GetParamType(SourceProductionContext context, ParameterSyntax decl) => GetFirstTypeParent(context, decl);

	private static bool IsParamInNotNewStaticMethod(SyntaxNode syntaxNode, CancellationToken cancellationToken) =>
		syntaxNode is ParameterSyntax ps && ps.Parent?.Parent is MethodDeclarationSyntax ms && !ms.Modifiers.Any(SyntaxKind.NewKeyword) && ms.Modifiers.Any(SyntaxKind.StaticKeyword);

	private static bool IsParamInNotNewMethod(SyntaxNode syntaxNode, CancellationToken cancellationToken) =>
		syntaxNode is ParameterSyntax ps && ps.Parent?.Parent is MethodDeclarationSyntax ms && !ms.Modifiers.Any(SyntaxKind.NewKeyword);

	private static bool IsParamWithArgs(SyntaxNode syntaxNode, CancellationToken cancellationToken) => syntaxNode is ParameterSyntax ps &&
		ps.Parent?.Parent is MethodDeclarationSyntax ms && !ms.Modifiers.Any(SyntaxKind.NewKeyword) &&
		(ms?.Parent is ClassDeclarationSyntax cs && cs.IsPartial() || ms?.Parent is InterfaceDeclarationSyntax && ms?.Parent?.Parent is ClassDeclarationSyntax ccs && ccs.IsPartial());

	private static bool IsPartialType(SyntaxNode syntaxNode, CancellationToken cancellationToken) => syntaxNode is TypeDeclarationSyntax tds && tds.IsPartial();
	
	private static TypeDeclarationSyntax ParentForExtMethod(SourceProductionContext context, ParameterSyntax decl)
	{
		var parentClass = decl.Parent?.Parent?.Parent is ClassDeclarationSyntax cs ? cs : (decl.Parent?.Parent?.Parent is InterfaceDeclarationSyntax && decl.Parent?.Parent?.Parent?.Parent is ClassDeclarationSyntax ccs ? ccs : null);
		if (parentClass == null)
			context.ReportError(decl, "VANGEN020", "Unable to find the parent class into which to insert the methods.");
		return parentClass!;
	}
}