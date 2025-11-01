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
 * MarshalAs(Interface)					X
 * MarshalAs(LPArray)					X
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
		new("System.Runtime.InteropServices.MarshalAsAttribute", IsParamInNestedType, ParentForExtMethod, GetMethodFromNode, BuildMarshalAsMethod), // IUnknown, Interface, LPArray
		new("Vanara.PInvoke.IgnoreAttribute", IsParamInNestedType, ParentForExtMethod, GetMethodFromNode, BuildIgnoreMethod),
		new("Vanara.PInvoke.SizeDefAttribute", IsParamInNestedType, ParentForExtMethod, GetMethodFromNode, BuildSizeDefMethod),
		new("Vanara.PInvoke.AddAsMemberAttribute", IsParamInNestedType, ParentForExtMethod, GetMethodFromNode, BuildAddAsMethod),
		new("Vanara.PInvoke.AddAsCtorAttribute", IsNestedMethWithParamOrReturnAttr, ParentForExtMethod, GetMethodFromNode, BuildAddAsMethod),
	];

	static readonly TypeAttrHandler[] typeAttributes = [
		new("Vanara.PInvoke.AdjustAutoMethodNamePatternAttribute", IsPartialType, null),
		new("Vanara.PInvoke.AutoSafeHandleAttribute", IsPartialType, null),
		new("Vanara.PInvoke.DeferAutoMethodFromAttribute", IsPartialType, static (ctx) => (TypeDeclarationSyntax)ctx.TargetNode),
	];

	/// <inheritdoc/>
	public void Initialize(IncrementalGeneratorInitializationContext context)
	{
		// Process each attribute in the methodAttributes array
		var attributeProviders = methodAttributes
			.Select(attr => context.SyntaxProvider.ForAttributeWithMetadataName(attr.AttrName, (n, t) => attr.Validator(n, t), (ctx, _) => (ctx.TargetNode, ctx.Attributes)).Collect())
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
			.Combine(attributeProviders[0])
			.Combine(attributeProviders[1])
			.Combine(attributeProviders[2])
			.Combine(attributeProviders[3])
			.Combine(attributeProviders[4])
			.Combine(typeProviders[0])
			.Combine(typeProviders[1])
			.Combine(typeProviders[2])
			.WithTrackingName("Syntax");

		context.RegisterSourceOutput(source, (spc, value) =>
			GenerateCode(spc, value.Left.Left.Left.Left.Left.Left.Left.Left.Left, value.Left.Left.Left.Left.Left.Left.Left.Left.Right,
			value.Left.Left.Left.Right.AddRange(value.Left.Left.Left.Left.Right).AddRange(value.Left.Left.Left.Left.Left.Right).AddRange(value.Left.Left.Left.Left.Left.Left.Right).AddRange(value.Left.Left.Left.Left.Left.Left.Left.Right),
			value.Right.AddRange(value.Left.Right).AddRange(value.Left.Left.Right)));
	}

	private static void GenerateCode(SourceProductionContext context, Compilation compilation, ImmutableArray<AdditionalText> addtlFiles, ImmutableArray<(SyntaxNode syntaxNode, ImmutableArray<AttributeData> attrDatas)> paramNodes,
		ImmutableArray<(TypeDeclarationSyntax type, ImmutableArray<AttributeData> attrDatas)> typeNodes)
	{
		uid = 1;
		try
		{
			// Get list of all types of entries from handles that have a safe handle and have a handle
			var handles = HandlesFromFileGenerator.EnumHandleModels(context, addtlFiles).ToList();

			FungibleTypeDecl MakeOrBuild(INamedTypeSymbol tsym)
			{
				var ftd = new FungibleTypeDecl(tsym);
				if (!ftd.IsInvalid)
					return ftd;
				// See if it's a handle type
				var handle = handles.FirstOrDefault(h => h.HasHandle && h.HandleName == tsym.Name);
				return handle is not null ? new FungibleTypeDecl(handle, compilation, false) : ftd;
			}

			// Process all DeferAutoMethodFromAttribute
			var deferralMappings = typeNodes
				.Where(p => p.attrDatas.First().AttributeClass?.ToDisplayString() == "Vanara.PInvoke.DeferAutoMethodFromAttribute")
				.SelectMany(tn => tn.attrDatas.Select(a => a.ConstructorArguments.FirstOrDefault().Value).OfType<INamedTypeSymbol>()
					.Select(tsym => (src: MakeOrBuild(tsym), dest: new FungibleTypeDecl(tn.type))))
				.Concat(typeNodes.Where(p => p.attrDatas.First().AttributeClass?.ToDisplayString() == "Vanara.PInvoke.AutoSafeHandleAttribute")
					.SelectMany(tn => tn.attrDatas.Select(a => a.ConstructorArguments.Skip(1).FirstOrDefault().Value).OfType<INamedTypeSymbol>()
					.Select(tsym => (src: MakeOrBuild(tsym), dest: new FungibleTypeDecl(tn.type)))))
				.Concat(handles.Where(h => !string.IsNullOrEmpty(h.HandleName) && h.HasSafeHandle)
					.Select(h => (src: new FungibleTypeDecl(h, compilation, false), dest: new FungibleTypeDecl(h, compilation, true))))
				.Distinct().ToList();

			// Get list of all types that will hold methods
			var types = paramNodes.Select(n => new FungibleTypeDecl(TypeFromNode(n)))
				.Concat(deferralMappings.Select(dm => dm.src))
				.Concat(deferralMappings.Select(dm => dm.dest))
				.Concat(typeNodes.Where(p => p.attrDatas.First().AttributeClass?.ToDisplayString() == "Vanara.PInvoke.AutoSafeHandleAttribute")
					.Select(tsym => (FungibleTypeDecl)tsym.type))
				.Distinct()
				.ToDictionary(t => t, t => (methods: new Dictionary<MemberDeclarationSyntax, MethodBodyBuilder>(SyntaxComparer.Default), usings: new List<UsingDirectiveSyntax>()));

			// Process each type group's methods
			List<(FungibleTypeDecl td, MethodDeclarationSyntax md, MethodBodyBuilder mb, SyntaxNode n, AttributeData ad)> postProcessMethods = [];
			foreach (var typeGroup in types)
			{
				FungibleTypeDecl typeDecl = typeGroup.Key;
				var methLookup = typeGroup.Value.methods;
				var usings = typeGroup.Value.usings;

				// Process each paramNode that maps to this type
				foreach (var pa in paramNodes.Where(pa => TypeComparer.Default.Equals(TypeFromNode(pa), typeDecl.decl)))
				{
					var handler = GetHandler(pa);
					var methDecl = handler.meth(pa.syntaxNode);
					if (methDecl is null)
					{
						context.ReportError(pa.syntaxNode, "VANGEN999", "Internal error: Cannot find method declaration for attribute application.");
						continue;
					}
					try
					{
						methLookup.TryGetValue(methDecl, out MethodBodyBuilder? methBuilder);
						handler.bodyBuilder(context, compilation, types.Keys, pa.syntaxNode, methDecl, pa.attrDatas, ref methBuilder);

						if (methBuilder is not null)
						{
							methLookup[methDecl] = methBuilder;
							// Add distinct using directives
							usings.AddDistinctBy(pa.syntaxNode.SyntaxTree.GetRoot().DescendantNodes().OfType<UsingDirectiveSyntax>()
								.Where(u => u.GlobalKeyword.IsKind(SyntaxKind.None)).Select(u => u.WithoutTrivia()), UsingComp);
						}

						if (handler.AttrName is "Vanara.PInvoke.AddAsMemberAttribute" or "Vanara.PInvoke.AddAsCtorAttribute")
						{
							postProcessMethods.Add((typeDecl, methDecl, methBuilder!, pa.syntaxNode, pa.attrDatas.First()));
						}
					}
					catch (Exception ex)
					{
						context.ReportError(methDecl, "VANGEN999", "Unknown error: " + Regex.Replace(ex.ToString(), "[\r\n]+", " "));
						continue;
					}
				}
			}

			// Enumerate each AddAsMember and AddAsCtor attribute reference and move methods from parent type to target type
			// where target type is replaced by value in deferralMappings if found there or in handles, in any references there.
			foreach (var ppg in postProcessMethods.GroupBy(pp => pp.td))
			{
				var srcType = ppg.Key;
				var (methods, usings) = types[srcType];
				foreach (var (td, md, mb, n, ad) in ppg)
				{
					// Get the destination type from the parameter or return type and ensure it exists in types, creating it if necessary from handles
					var destNodeType = GetTypeFromNode(n);
					var destType = types.Keys.FirstOrDefault(td => td.Name == destNodeType?.ToString());

					// Try to get the altnernate type from deferralMappings
					var altDestType = deferralMappings.FirstOrDefault(at => at.src.Name == destNodeType!.ToString()).dest;

					// Process the methods, copying them to the destType or altDestType as needed
					switch (ad.AttributeClass?.ToDisplayString())
					{
						case "Vanara.PInvoke.AddAsMemberAttribute":
						case "Vanara.PInvoke.AddAsCtorAttribute":
							// Copy methods to destType if available in compilation
							if (destType is not null && altDestType is null)
							{
								var destMethods = types[destType];
								if (!destMethods.methods.ContainsKey(md))
									destMethods.methods[md] = mb;
								// Merge usings
								destMethods.usings.AddDistinctBy(usings, UsingComp);
							}
							// Copy methods to altDestType if available in compilation
							if (altDestType is not null)
							{
								var destMethods = types[altDestType];
								if (!destMethods.methods.ContainsKey(md))
									destMethods.methods[md] = mb;
								// Merge usings
								destMethods.usings.AddDistinctBy(usings, UsingComp);
							}
							// Remove method from source type
							types[srcType].methods.Remove(md);
							break;
						default:
							context.ReportError(n, "VANGEN031", "Error: Unrecognized post-process handler.");
							break;
					}
				}
			}

			// Get a dictionary of all string munges
			var munges = typeNodes.Where(n => n.attrDatas.First().AttributeClass?.ToDisplayString() == "Vanara.PInvoke.AdjustAutoMethodNamePatternAttribute")!
				.SelectMany(tas => tas.attrDatas.Select(a => ((FungibleTypeDecl)tas.type, a.ConstructorArguments.First().GetValues())))
				.Concat(handles.Where(h => h.HasHandle).Select(h => (new FungibleTypeDecl(h, compilation, false), h.AdjNameRegex is not null ? h.AdjNameRegex.ToArray() : [])))
				.Concat(handles.Where(h => h.HasSafeHandle).Select(h => (new FungibleTypeDecl(h, compilation, true), h.AdjNameRegex is not null ? h.AdjNameRegex.ToArray() : [])))
				.ToDictionary(s => s.Item1, s => s.Item2);

			// Generate source for each type, replacing type with handle type if applicable
			foreach (var kv in types)
			{
				GenerateTypeSource(kv.Key, kv.Value.usings, kv.Value.methods.Values);
			}

			void GenerateTypeSource(FungibleTypeDecl localTypeDecl, IEnumerable<UsingDirectiveSyntax> usings, IReadOnlyCollection<MethodBodyBuilder> methLookup)
			{
				if (methLookup.Count == 0 || localTypeDecl.decl is null)
					return;

				// If localTypeDecl is in munges, apply the string replacements to each method name in methLookup
				var ptrnRepl = munges.TryGetValue(localTypeDecl, out var mr) ? mr : null;
				// Build new syntax tree, starting with nsDecl, adding any containing types with their modifiers, and finally the localTypeDecl with the new values from methLookup.Values
				SyntaxNode topDecl = localTypeDecl.decl
					.WithoutTrivia()
					.WithAttributeLists([])
					.WithMembers(List(methLookup
						.Select(bb => (bb, ptrnRepl is null ? null : RegexRepl(bb.methodName, ptrnRepl)))
						.Select(bban => bban.bb.ToMethod(bban.Item2))));
				foreach (var parent in localTypeDecl.Ancestors)
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
				context.AddSource($"{localTypeDecl!.Name}_AttrGen.g.cs", compilationUnit.NormalizeWhitespace().ToFullString());
			}
			TypeDeclarationSyntax TypeFromNode((SyntaxNode paramNode, ImmutableArray<AttributeData> attrDatas) p) => GetHandler(p).parent(context, p.paramNode, compilation);
		}
		catch (Exception ex)
		{
			context.ReportError("VANGEN999", "Unknown error: " + Regex.Replace(ex.ToString(), "[\r\n]+", " "));
		}

		static MethAttrHandler GetHandler((SyntaxNode paramNode, ImmutableArray<AttributeData> attrDatas) p) => methodAttributes.First(a => a.AttrName == p.attrDatas.First().AttributeClass?.ToDisplayString());
		static string RegexRepl(string input, string[] replPatterns)
		{
			string output = input;
			for (int i = 0; i < replPatterns.Length - 1; i += 2)
				output = Regex.Replace(output, replPatterns[i], replPatterns[i + 1]);
			return output;
		}
		static string? UsingComp(UsingDirectiveSyntax u) => u.Alias?.ToString() ?? u.Name?.ToString();
	}

	private static void BuildAddAsMethod(SourceProductionContext context, Compilation compilation, IEnumerable<FungibleTypeDecl> types, SyntaxNode decl, MethodDeclarationSyntax methodDecl, ImmutableArray<AttributeData> attrDatas, ref MethodBodyBuilder? builder)
	{
		var ts = GetTypeFromNode(decl);
		if (!types.Any(td => td.Name == ts?.ToString()))
			return;

		MethodBodyBuilder tmpbuilder = builder ?? new(methodDecl);

		if (attrDatas.First().AttributeClass?.Name == "AddAsCtorAttribute")
		{
			tmpbuilder.isCtor = true;

			// See if the attribute is marked with the return attribute target specifier
			if (decl is ParameterSyntax ps)
			{
				// Remove the n from the method signature
				tmpbuilder.parameters.Remove(ps.Identifier.Text);

				// Set the return statement to the parameter type
				tmpbuilder.returnType = ps.Type!;
				tmpbuilder.statements.ret = ReturnStatement(IdentifierName(ps.Identifier.Text));

				// Set the invoke argument an out argument of the parameter type
				var sdArg = tmpbuilder.statements.invokeArgs.FirstOrDefault(a => a.NameEquals(ps.Identifier.Text));
				if (sdArg != null)
					tmpbuilder.statements.invokeArgs.Replace(sdArg, Argument(null, MethodBodyBuilder.outToken, ParseExpression($"{ps.Type!.GetText()} {ps.Identifier.Text}")));

				// Process the xml docs for the method, replacing the returns node with the param node innerxml
				var paramNode = tmpbuilder.docs?.SelectSingleNode($"//param[@name='{ps.Identifier.Text}']");
				var returnsNode = tmpbuilder.docs?.SelectSingleNode("//returns") ??
					tmpbuilder.docs?.DocumentElement?.AppendChild(tmpbuilder.docs?.CreateElement("returns")!);
				if (returnsNode is not null)
					returnsNode.InnerXml = paramNode?.InnerXml;
				paramNode?.ParentNode?.RemoveChild(paramNode);
			}
		}
		else if (decl is ParameterSyntax ps)
		{
			// Remove static modifier from the method
			tmpbuilder.modifiers.RemoveWhere(t => t.IsKind(SyntaxKind.StaticKeyword));

			// Remove the n from the method signature
			tmpbuilder.parameters.Remove(ps.Identifier.Text);

			// Call method for real replacing the reference to the parameter in the method body invokeArgs statement with DangerousGetHandle()
			var sdArg = tmpbuilder.statements.invokeArgs.FirstOrDefault(a => a.NameEquals(ps.Identifier.Text));
			if (sdArg != null)
				tmpbuilder.statements.invokeArgs.Replace(sdArg, Argument(ParseExpression(@"DangerousGetHandle()")));

			// Process the xml docs for the method, removing the ignored param
			tmpbuilder.docs?.RemoveParamDoc(ps.Identifier.Text);
		}
		builder = tmpbuilder;
	}

	private static void BuildSizeDefMethod(SourceProductionContext context, Compilation compilation, IEnumerable<FungibleTypeDecl> types, SyntaxNode node, MethodDeclarationSyntax methodDecl, ImmutableArray<AttributeData> attrDatas, ref MethodBodyBuilder? builder)
	{
		MethodBodyBuilder tmpbuilder = builder ?? new(methodDecl);
		var decl = (ParameterSyntax)node;

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

		// Replace the n and remove the szParam parameters from the method signature
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
		// 1. Create a statement that creates a variable for the output of n and initializes it to the value of 'sz'
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

			// From 'n', get the ParameterSyntax for the parameter referenced by the first string argument in the SizeDef attribute
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
				if (!qret && !qle && (szParam is null || !szParam.Modifiers.Any(SyntaxKind.RefKeyword) && outSzParam is null && bufSzParam is null))
				{
					context.ReportError(decl, "VANGEN027", "SizeDef attribute with Query sizing method requires the referenced parameter to be passed by ref.");
					return false;
				}
				if (qret && (szParam is null || szParam.Modifiers.Any(SyntaxKind.RefKeyword) || outSzParam is not null))
				{
					context.ReportError(decl, "VANGEN028", "SizeDef attribute with QueryResultInReturn sizing method requires the referenced parameter to be passed by value and no OutVarName specified.");
					return false;
				}
			}

			return true;
		}
	}

	private static void BuildIgnoreMethod(SourceProductionContext context, Compilation compilation, IEnumerable<FungibleTypeDecl> types, SyntaxNode node, MethodDeclarationSyntax methodDecl, ImmutableArray<AttributeData> attrDatas, ref MethodBodyBuilder? builder)
	{
		MethodBodyBuilder tmpbuilder = builder ?? new(methodDecl);
		var decl = (ParameterSyntax)node;

		// Remove the parameter from the method signature
		var idx = tmpbuilder.parameters.FindIndex(t => t.IsEquivalentTo(decl));
		if (idx >= 0)
		{
			// If the parameter is not optional, report an error
			if (!decl.AttributeLists.SelectMany(al => al.Attributes).Any(a => a.Name.ToString() == "Optional") && decl.Default is null)
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

	private static void BuildMarshalAsMethod(SourceProductionContext context, Compilation compilation, IEnumerable<FungibleTypeDecl> types, SyntaxNode node, MethodDeclarationSyntax methodDecl, ImmutableArray<AttributeData> attrDatas, ref MethodBodyBuilder? builder)
	{
		var decl = (ParameterSyntax)node;
		// Determine if the n is an in or out or ref param
		bool isOutParam = decl.Modifiers.Any(SyntaxKind.OutKeyword);
		ModType modAttr = (decl.AttributeLists.SelectMany(al => al.Attributes).Any(a => a.Name.ToString() == "Out") ? ModType.Out : 0)
			| (decl.AttributeLists.SelectMany(al => al.Attributes).Any(a => a.Name.ToString() == "In") ? ModType.In : 0);
		if (modAttr == 0) modAttr = isOutParam ? ModType.Out : ModType.In;

		// Determine if the n has the MarshalAs attribute with contructor first argument of UnmanagedType.IUnknown or UnmanagedType.IInterface and a named argument of IidParameterIndex
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
			UnmanagedType.LPArray when modAttr is ModType.In => decl.WithoutAttribute("MarshalAs"),
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
				var a1 when a1.NameEquals(refParamName) => unmanagedType switch
				{
					UnmanagedType.IUnknown => Argument(ParseExpression($"typeof({genericType}).GUID")),
					UnmanagedType.Interface => Argument(ParseExpression($"typeof({decl.Type!.ToString().TrimEnd('?')}).GUID")),
					UnmanagedType.LPArray when modAttr is ModType.In && methodDecl.ParameterList.Parameters.FirstOrDefault(p => p.Identifier.Text == refParamName) is ParameterSyntax refParam =>
						paramTypeIsNullable
						? Argument(ParseExpression($"({refParam.Type})Convert.ChangeType({decl.Identifier.Text}?.Length ?? 0, typeof({refParam.Type}))"))
						: Argument(ParseExpression($"({refParam.Type})Convert.ChangeType({decl.Identifier.Text}.Length, typeof({refParam.Type}))")),
					_ => a1,
				},
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
			// Get the xml node for the ref parameter docs
			XmlNode? refNode = tmpbuilder.docs.SelectSingleNode($"//param[@name='{refParamName}']");
			if (refNode is not null)
			{
				// Add the ref parameter docs to the method docs as the value of the typeParam tag
				if (unmanagedType == UnmanagedType.IUnknown)
					tmpbuilder.docs.InsertTypeParamDocAfter(genericType, refNode.InnerXml);

				// Remove the ref parameter docs
				refNode.ParentNode?.RemoveChild(refNode);

				// Remove the "<paramref name="refParamName"/>" tags from the entire document
				XmlElement replElem = tmpbuilder.docs.CreateElement("c");
				replElem.InnerText = refParamName;
				foreach (var n in tmpbuilder.docs.SelectNodes($"//paramref[@name='{refParamName}']").Cast<XmlElement>().Where(n => n.ParentNode is not null))
					n.ParentNode?.ReplaceChild(replElem, n);
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
						refindex = GetIndex("SizeParamIndex");
						if (refindex == -1 || modAttr != ModType.In)
							return false;
						break;

					default:
						return false;
				}
			}

			// If there's an refindex, then make sure it points to a valid parameter
			if (refindex >= 0)
			{
				var iidParam = methodDecl.ParameterList.Parameters[refindex];
				var paramType = iidParam.Type?.ToString();
				// For interfaces, confirm param type is Guid
				if (unmanagedType is UnmanagedType.IUnknown or UnmanagedType.Interface)
				{
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
				// For LPArray, type is integral so pass along
				else if (unmanagedType == UnmanagedType.LPArray)
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

	// Confirm param is in a method is not new or unsafe and does not have SuppressAutoGen attribute
	private static bool IsParamInMethod(SyntaxNode syntaxNode, CancellationToken cancellationToken, out MethodDeclarationSyntax? ms)
	{
		ms = syntaxNode is ParameterSyntax ps && ps.Parent?.Parent is MethodDeclarationSyntax mds
			&& !mds.Modifiers.Any(SyntaxKind.UnsafeKeyword) && !mds.Modifiers.Any(SyntaxKind.NewKeyword)
			&& !mds.AttributeLists.SelectMany(al => al.Attributes).Any(a => a.Name.ToString().Contains("SuppressAutoGen")) ? mds : null;
		return ms is not null;
	}

	private static bool IsParamInMethod(SyntaxNode syntaxNode, CancellationToken cancellationToken) => IsParamInMethod(syntaxNode, cancellationToken, out _);

	private static bool IsParamInStaticMethod(SyntaxNode syntaxNode, CancellationToken cancellationToken) =>
		IsParamInMethod(syntaxNode, cancellationToken, out var ms) && ms!.Modifiers.Any(SyntaxKind.StaticKeyword);

	private static bool IsParamInNestedType(SyntaxNode syntaxNode, CancellationToken cancellationToken) =>
		IsParamInMethod(syntaxNode, cancellationToken, out var ms) &&
		(ms?.Parent is ClassDeclarationSyntax cs && cs.IsPartial() && ms.Modifiers.Any(SyntaxKind.StaticKeyword) ||
		ms?.Parent is InterfaceDeclarationSyntax && ms?.Parent?.Parent is ClassDeclarationSyntax ccs && ccs.IsPartial());

	private static bool IsNestedMethWithParamOrReturnAttr(SyntaxNode syntaxNode, CancellationToken cancellationToken) =>
		GetMethodFromNode(syntaxNode) is MethodDeclarationSyntax ms
			&& !ms.Modifiers.Any(SyntaxKind.UnsafeKeyword) && !ms.Modifiers.Any(SyntaxKind.NewKeyword)
			&& !ms.AttributeLists.SelectMany(al => al.Attributes).Any(a => a.Name.ToString().Contains("SuppressAutoGen"))
			&& (ms?.Parent is ClassDeclarationSyntax cs && cs.IsPartial() && ms.Modifiers.Any(SyntaxKind.StaticKeyword) ||
				ms?.Parent is InterfaceDeclarationSyntax && ms?.Parent?.Parent is ClassDeclarationSyntax ccs && ccs.IsPartial());

	private static MethodDeclarationSyntax? GetMethodFromNode(SyntaxNode n) => n switch
	{
		ParameterSyntax ps when ps.Parent?.Parent is MethodDeclarationSyntax mds => mds,
		MethodDeclarationSyntax mds2 => mds2,
		_ => n.AncestorsAndSelf().OfType<MethodDeclarationSyntax>().FirstOrDefault()
	};

	private static bool IsPartialType(SyntaxNode syntaxNode, CancellationToken cancellationToken) => syntaxNode is TypeDeclarationSyntax tds && tds.IsPartial();

	private static TypeSyntax? GetTypeFromNode(SyntaxNode n) => n switch
	{
		ParameterSyntax ps => ps.Type!,
		MethodDeclarationSyntax mds => mds.ReturnType,
		TypeSyntax ts => ts,
		_ => null
	};

	private static TypeDeclarationSyntax GetParamType(SourceProductionContext context, SyntaxNode decl, Compilation compilation) =>
		((ParameterSyntax)decl).Type?.GetTypeDeclaration(compilation) ??
			StructDeclaration(((ParameterSyntax)decl).Type is IdentifierNameSyntax ins ? ins.Identifier.Text : ((ParameterSyntax)decl).Type!.ToString());

	private static TypeDeclarationSyntax ParentForExtMethod(SourceProductionContext context, SyntaxNode decl, Compilation compilation)
	{
		var meth = GetMethodFromNode(decl);
		var parentClass = meth?.Parent is ClassDeclarationSyntax cs ? cs : (meth?.Parent is InterfaceDeclarationSyntax && meth?.Parent?.Parent is ClassDeclarationSyntax ccs ? ccs : null);
		if (parentClass == null)
			context.ReportError(decl, "VANGEN020", "Unable to find the parent class into which to insert the methods.");
		return parentClass!;
	}
}