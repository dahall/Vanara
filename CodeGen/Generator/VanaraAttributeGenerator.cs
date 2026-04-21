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
using System.CodeDom.Compiler;
using System.Collections.Immutable;
using System.Runtime.InteropServices;
using System.Xml;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using static Vanara.Generators.TypeDeclarationSyntaxExtensions;
using static Vanara.Generators.Util;

namespace Vanara.Generators;

/// <summary>
/// A source generator that creates extension methods for types based on the presence of the <c>AddAsMemberAttribute</c> on method parameters.
/// </summary>
[Generator(LanguageNames.CSharp)]
public partial class VanaraAttributeGenerator : IIncrementalGenerator
{
	const string hMemTypeStr = "global::Vanara.InteropServices.SafeHGlobalHandle";
	static readonly TypeSyntax hMemType = ParseTypeName(hMemTypeStr);

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
		StructPtr = 0x10,
		ArrayPtr = 0x20,
	}

	static readonly MethAttrHandler[] methodAttributes = [
		new("Vanara.PInvoke.IgnoreAttribute", IsParamInNestedType, ParentForExtMethod, GetMethodFromNode, BuildIgnoreMethod, 0),
		new("Vanara.PInvoke.SizeDefAttribute", IsParamInNestedType, ParentForExtMethod, GetMethodFromNode, BuildSizeDefMethod, 1),
		new("Vanara.PInvoke.StructPointerAttribute", IsParamInNestedType, ParentForExtMethod, GetMethodFromNode, BuildStructPtrMethod, 2),
		new("Vanara.PInvoke.ArrayPointerAttribute", IsParamInNestedType, ParentForExtMethod, GetMethodFromNode, BuildArrayPtrMethod, 2),
		new("System.Runtime.InteropServices.MarshalAsAttribute", IsParamInNestedType, ParentForExtMethod, GetMethodFromNode, BuildMarshalAsMethod, 3), // IUnknown, Interface, LPArray
	];

	static readonly MethAttrHandler[] methodMoveAttributes = [
		new("Vanara.PInvoke.AddAsCtorAttribute", IsNestedMethWithParamOrReturnAttr, ParentForExtMethod, GetMethodFromNode, BuildAddAsMethod, 0),
		new("Vanara.PInvoke.AddAsMemberAttribute", IsParamInNestedType, ParentForExtMethod, GetMethodFromNode, BuildAddAsMethod, 1),
	];

	static readonly Dictionary<string, MethAttrHandler> methodAttrDict = methodAttributes.Concat(methodMoveAttributes).ToDictionary(a => a.AttrName, a => a);

	static readonly TypeAttrHandler[] typeAttributes = [
		new("Vanara.PInvoke.AdjustAutoMethodNamePatternAttribute", IsPartialType, null, ta => null),
		new("Vanara.PInvoke.AutoSafeHandleAttribute", IsPartialType, null, AutoSafeHandleType),
		new("Vanara.PInvoke.DeferAutoMethodFromAttribute", IsPartialType, static (ctx) => (TypeDeclarationSyntax)ctx.TargetNode, DeferMethType),
	];

	/// <inheritdoc/>
	public void Initialize(IncrementalGeneratorInitializationContext context)
	{
		//uid = 0;
		// Process each attribute in the methodAttributes array
		var attributeProviders = methodAttributes
			.Select(attr => context.SyntaxProvider.ForAttributeWithMetadataName(attr.AttrName, attr.Validator, (ctx, _) => (ctx.TargetNode, ctx.Attributes, attr.Order)).Collect())
			.ToArray();

		// Process type-level methodMoveAttributes (those with method transforms)
		var methodMoveProviders = methodMoveAttributes
			.Select(attr => context.SyntaxProvider.ForAttributeWithMetadataName(attr.AttrName, attr.Validator, (ctx, _) => (ctx.TargetNode, ctx.Attributes)).Collect())
			.ToArray();

		// Process type-level methodAttributes (those without method transforms)
		var typeProviders = typeAttributes
			.Select(attr => context.SyntaxProvider.ForAttributeWithMetadataName(attr.AttrName, attr.Validator, (ctx, _) => (attr.type(ctx), ctx.Attributes)).Collect())
			.ToArray();

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
			.Combine(methodMoveProviders[0])
			.Combine(methodMoveProviders[1])
			.WithTrackingName("Syntax");

		context.RegisterSourceOutput(source, (spc, value) =>
			GenerateCode(spc, value.Left.Left.Left.Left.Left.Left.Left.Left.Left.Left.Left,
			value.Left.Left.Left.Left.Left.Left.Left.Left.Left.Left.Right,
			value.Left.Left.Left.Left.Left.Right.AddRange(value.Left.Left.Left.Left.Left.Left.Right).AddRange(value.Left.Left.Left.Left.Left.Left.Left.Right).AddRange(value.Left.Left.Left.Left.Left.Left.Left.Left.Right).AddRange(value.Left.Left.Left.Left.Left.Left.Left.Left.Left.Right),
			value.Left.Left.Right.AddRange(value.Left.Left.Left.Right).AddRange(value.Left.Left.Left.Left.Right),
			value.Right.AddRange(value.Left.Right)));
	}

	private static void GenerateCode(SourceProductionContext context, Compilation compilation, ImmutableArray<AdditionalText> addtlFiles, ImmutableArray<(SyntaxNode syntaxNode, ImmutableArray<AttributeData> attrDatas, int order)> pNodes,
		ImmutableArray<(TypeDeclarationSyntax type, ImmutableArray<AttributeData> attrDatas)> typeNodes, ImmutableArray<(SyntaxNode syntaxNode, ImmutableArray<AttributeData> attrDatas)> moveNodes)
	{
		try
		{
			// Combine paramNodes with matching syntaxNode into a single entry with combined attrDatas ordered by Order
			var paramNodes = pNodes.GroupBy(p => p.syntaxNode, SyntaxComparer.Default).Select(g => (g.Key, g.OrderBy(p => p.order).SelectMany(p => p.attrDatas).ToImmutableArray())).ToArray();

			// Get list of all types of entries from handles that have a safe handle and have a handle
			var handles = HandlesFromFileGenerator.EnumHandleModels(context, addtlFiles).ToList();

			// Process all DeferAutoMethodFromAttribute
			var deferralMappings = typeNodes.Select(ta => (typeAttributes.First(a => a.AttrName == ta.attrDatas.First().AttributeClass?.ToDisplayString()).reftype(ta), ta.type))
				.Where(t => t.Item1 is not null).Select(sd => (src: MakeOrBuild(sd.Item1!), dest: (FungibleTypeDecl)sd.type))
				.Concat(handles.Where(h => !string.IsNullOrEmpty(h.HandleName) && h.HasSafeHandle)
					.Select(h => (src: new FungibleTypeDecl(h, compilation, false), dest: new FungibleTypeDecl(h, compilation, true))))
				.Distinct().ToList();

			// Get list of all types that will hold methods
			var types = deferralMappings.SelectMany(dm => new FungibleTypeDecl[] { dm.src, dm.dest }).Distinct()
				.ToDictionary(t => t, t => (methods: new Dictionary<MemberDeclarationSyntax, MethodBodyBuilder>(SyntaxComparer.Default), usings: new List<UsingDirectiveSyntax>()));

			// Process each type group's methods
			foreach (var typeGroup in paramNodes.GroupBy(TypeFromNode))
			{
				FungibleTypeDecl typeDecl = typeGroup.Key;
				var (methLookup, usings) = GetOrCreateTypeEntry(typeDecl);

				// Process each paramNode that maps to this type
				foreach (var (syntaxNode, attrDatas) in typeGroup)
				{
					var handler = GetHandler(attrDatas);
					var methDecl = handler.meth(syntaxNode);
					if (methDecl is null)
					{
						context.ReportError(syntaxNode, "VANGEN999", "Internal error: Cannot find method declaration for attribute application.");
						continue;
					}
					try
					{
						methLookup.TryGetValue(methDecl, out MethodBodyBuilder? methBuilder);
						handler.bodyBuilder(context, compilation, types.Keys, syntaxNode, methDecl, attrDatas, ref methBuilder);

						if (methBuilder is not null)
						{
							methLookup[methDecl] = methBuilder;
							// Add distinct using directives
							usings.AddRange(syntaxNode.SyntaxTree.GetRoot().DescendantNodes().OfType<UsingDirectiveSyntax>()
								.Where(u => u.GlobalKeyword.IsKind(SyntaxKind.None)).Select(u => u.WithoutTrivia()));
						}
					}
					catch (Exception ex)
					{
						context.ReportError(methDecl, "VANGEN999", "Unknown error: " + Regex.Replace(ex.ToString(), @"[\r\s]+", " "));
						continue;
					}
				}
			}

			// Get a dictionary of all string munges
			var munges = typeNodes.Where(n => n.attrDatas.First().AttributeClass?.Name == "AdjustAutoMethodNamePatternAttribute")!
				.SelectMany(tas => tas.attrDatas.Select(a => ((FungibleTypeDecl)tas.type, a.ConstructorArguments.First().GetValues())))
				.Concat(handles.Where(h => h.HasHandle).Select(h => (new FungibleTypeDecl(h, compilation, false), h.AdjNameRegex is not null ? h.AdjNameRegex.ToArray() : [])))
				.Concat(handles.Where(h => h.HasSafeHandle).Select(h => (new FungibleTypeDecl(h, compilation, true), h.AdjNameRegex is not null ? h.AdjNameRegex.ToArray() : [])))
				.ToDictionary(s => s.Item1, s => s.Item2);

			// Enumerate each AddAsMember and AddAsCtor attribute reference and move methods from parent type to target type
			// where target type is replaced by value in deferralMappings if found there or in handles, in any references there.
			foreach (var ppg in moveNodes.GroupBy(TypeFromNode))
			{
				FungibleTypeDecl srcType = ppg.Key;
				var (methLookup, usings) = GetOrCreateTypeEntry(srcType);

				foreach (var (syntaxNode, attrDatas) in ppg)
				{
					try
					{
						var handler = GetHandler(attrDatas);
						var methDecl = handler.meth(syntaxNode)!;
						if (methDecl is null)
						{
							context.ReportError(syntaxNode, "VANGEN999", "Internal error: Cannot find method declaration for attribute application.");
							continue;
						}
						methLookup.TryGetValue(methDecl, out MethodBodyBuilder? mb);
						MethodBodyBuilder methBuilder = mb?.MakeInvokableClone() ?? new(methDecl);
						handler.bodyBuilder(context, compilation, types.Keys, syntaxNode, methDecl, attrDatas, ref methBuilder!);
						if (methBuilder is not null)
						{
							// Add distinct using directives
							usings.AddRange(syntaxNode.SyntaxTree.GetRoot().DescendantNodes().OfType<UsingDirectiveSyntax>()
								.Where(u => u.GlobalKeyword.IsKind(SyntaxKind.None)).Select(u => u.WithoutTrivia()));
						}

						// Get the destination type from the parameter or return type and ensure it exists in types, creating it if necessary from handles
						var destNodeType = GetTypeFromNode(syntaxNode);
						var destType = types.Keys.FirstOrDefault(td => td.Name == destNodeType?.ToString());

						// Try to get the altnernate type from deferralMappings
						var altDestType = deferralMappings.FirstOrDefault(at => at.src.Name == destNodeType!.ToString()).dest;

						// Process the methods, copying them to the typeDecl or altDestType as needed
						// Copy methods to typeDecl if available in compilation
						if (destType is not null && altDestType is null)
						{
							AddMethodToType(destType);
						}
						// Copy methods to altDestType if available in compilation
						if (altDestType is not null)
						{
							AddMethodToType(altDestType);
						}

						void AddMethodToType(FungibleTypeDecl typeDecl)
						{
							// If desType is in munges, apply the string replacements to each method name in methLookup
							var ptrnRepl = munges.TryGetValue(typeDecl, out var mr) ? mr : null;
							if (ptrnRepl is not null)
								methBuilder!.topMethodName = RegexRepl(methBuilder!.methodName, ptrnRepl);
							// Add method to typeDecl
							var destMethods = GetOrCreateTypeEntry(typeDecl);
							destMethods.methods[methDecl] = methBuilder!;
							// Merge usings
							destMethods.usings.AddRange(usings);
						}
					}
					catch (Exception ex)
					{
						context.ReportError(syntaxNode, "VANGEN999", "Unknown error: " + Regex.Replace(ex.ToString(), @"[\r\s]+", " "));
						continue;
					}
				}
			}

			// Generate source for each type, replacing type with handle type if applicable
			foreach (var (localTypeDecl, usings, methLookup) in types.Where(kv => kv.Key is not null && kv.Key.decl is not null && kv.Value.usings.Count > 0)
				.Select(kv => (kv.Key!, kv.Value.usings, kv.Value.methods.Values))
				)
			{
				// Build new syntax tree, starting with nsDecl, adding any containing types with their modifiers, and finally the localTypeDecl with the new values from methLookup.Values
				SyntaxNode topDecl = localTypeDecl.decl!
					.WithoutTrivia()
					.WithAttributeLists([AttributeList([Attribute(IdentifierName("global::System.CodeDom.Compiler.GeneratedCode"))
						.WithArgumentList(AttributeArgumentList([AttributeArgument(LiteralExpression(SyntaxKind.StringLiteralExpression, Literal("Vanara"))),
							AttributeArgument(LiteralExpression(SyntaxKind.NullLiteralExpression))]))])])
					.WithMembers(List(methLookup.OrderBy(bb => bb.topMethodName).Select(bb => bb.ToMethod())));
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
						BaseNamespaceDeclarationSyntax nds => FileScopedNamespaceDeclaration(nds.Name)
							.WithMembers(SingletonList((MemberDeclarationSyntax)topDecl))
							.WithLeadingTrivia(nds.GetLeadingTrivia())
							.WithTrailingTrivia(nds.GetTrailingTrivia()),
						_ => topDecl
					};
				}

				// Remove unused usings
				var filteredUsings = RemoveUnusedUsings(topDecl, usings);

				// Create compilation unit with using directives outside the namespace
				var compilationUnit = CompilationUnit()
					.WithUsings(List(filteredUsings))
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

			(Dictionary<MemberDeclarationSyntax, MethodBodyBuilder> methods, List<UsingDirectiveSyntax> usings) GetOrCreateTypeEntry(FungibleTypeDecl t) =>
				types.TryGetValue(t, out var entry) ? entry : types[t] = (new Dictionary<MemberDeclarationSyntax, MethodBodyBuilder>(SyntaxComparer.Default), []);
			FungibleTypeDecl MakeOrBuild(INamedTypeSymbol tsym)
			{
				var ftd = new FungibleTypeDecl(tsym);
				return ftd.IsInvalid && handles.FirstOrDefault(h => h.HasHandle && h.HandleName == tsym.Name) is HandleModel handle ? new FungibleTypeDecl(handle, compilation, false) : ftd;
			}
			TypeDeclarationSyntax TypeFromNode((SyntaxNode paramNode, ImmutableArray<AttributeData> attrDatas) p) => GetHandler(p.attrDatas).parent(context, p.paramNode, compilation);
		}
		catch (Exception ex)
		{
			context.ReportError("VANGEN999", "Unknown error: " + Regex.Replace(ex.ToString(), @"[\r\s]+", " "));
		}

		static MethAttrHandler GetHandler(ImmutableArray<AttributeData> attrDatas) => methodAttrDict[attrDatas.First().AttributeClass?.ToDisplayString()!];
		static string RegexRepl(string input, string[] replPatterns)
		{
			string output = input;
			for (int i = 0; i < replPatterns.Length - 1; i += 2)
				output = Regex.Replace(output, replPatterns[i], replPatterns[i + 1]);
			return output;
		}
		// TODO: Fix this to actually remove unused usings
		static List<UsingDirectiveSyntax> RemoveUnusedUsings(SyntaxNode topDecl, List<UsingDirectiveSyntax> usings)
		{
			return [.. usings.DistinctBy(UsingComp).OrderBy(CompVal)];

			/*// Filter usings to only include those that are actually referenced in the new syntax tree
			var usedIdentifiers = topDecl.DescendantNodes().OfType<IdentifierNameSyntax>().Select(ins => ins.Identifier.ValueText).ToHashSet();				
			// Also collect member access expressions (e.g., System.Runtime.InteropServices.MarshalAs)
			var memberAccessNames = topDecl.DescendantNodes().OfType<MemberAccessExpressionSyntax>()
				.SelectMany(maes => 
				{
					var parts = new List<string>();
					var current = maes;
					while (current != null)
					{
						if (current.Name is IdentifierNameSyntax name)
							parts.Add(name.Identifier.ValueText);
						if (current.Expression is IdentifierNameSyntax expr)
						{
							parts.Add(expr.Identifier.ValueText);
							break;
						}
						current = current.Expression as MemberAccessExpressionSyntax;
					}
					return parts;
				}).ToHashSet();

			// Collect qualified names
			var qualifiedNames = topDecl.DescendantNodes().OfType<QualifiedNameSyntax>()
				.SelectMany(qns => qns.ToString().Split('.'))
				.ToHashSet();

			// Collect attribute names (may be shortened)
			var attributeNames = topDecl.DescendantNodes().OfType<AttributeSyntax>()
				.Select(attr => attr.Name.ToString())
				.SelectMany(name => name.Split('.'))
				.ToHashSet();

			// Combine all identifiers that might be used
			var allUsedIdentifiers = usedIdentifiers
				.Union(memberAccessNames)
				.Union(qualifiedNames)
				.Union(attributeNames)
				.ToHashSet();

			return usings.DistinctBy(UsingComp).Where(u =>
				{
					// Keep using directive if any part of its name is referenced in the syntax tree
					if (u.Name?.ToString() is not string nameText)
						return false;

					// Always keep System namespaces as they're fundamental
					//if (nameText.StartsWith("System"))
					//	return true;

					// Check if the namespace or any of its parts are used
					var nameParts = nameText.Split('.');
					return nameParts.Any(part => allUsedIdentifiers.Contains(part)) || 
						topDecl.DescendantNodes().OfType<QualifiedNameSyntax>().Any(qns => qns.ToString().StartsWith(nameText));
				}).ToList();*/

			static string? CompVal(UsingDirectiveSyntax u) => u switch
			{
				UsingDirectiveSyntax u1 when u1.Alias is not null => $"zzz{u1.Alias?.ToString()}",
				UsingDirectiveSyntax u2 when u2.GlobalKeyword.IsKind(SyntaxKind.GlobalKeyword) => $"000{u2.Name?.ToString()}",
				UsingDirectiveSyntax u2 when u2.StaticKeyword.IsKind(SyntaxKind.StaticKeyword) => $"zz{u2.Name?.ToString()}",
				_ => u.Name?.ToString(),
			};
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
				// Remove the syntaxNode from the method signature
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
				returnsNode?.InnerXml = paramNode?.InnerXml;
				paramNode?.ParentNode?.RemoveChild(paramNode);
			}
		}
		else if (decl is ParameterSyntax ps)
		{
			tmpbuilder.modifiers.Remove(MethodBodyBuilder.staticToken);
			tmpbuilder.attributes.Add(AttributeList([Attribute(ParseName("System.Runtime.CompilerServices.MethodImplAttribute"), ParseAttributeArgumentList("(System.Runtime.CompilerServices.MethodImplOptions.NoInlining | System.Runtime.CompilerServices.MethodImplOptions.NoOptimization)"))]));

			// Mark method to ignore error handling
			tmpbuilder.ignoreErrHandler = true;

			// Remove the syntaxNode from the method signature
			tmpbuilder.parameters.Remove(ps.Identifier.Text);

			// Call method for real replacing the reference to the parameter in the method body invokeArgs statement with DangerousGetHandle()
			var sdArg = tmpbuilder.statements.invokeArgs.FirstOrDefault(a => a.NameEquals(ps.Identifier.Text));
			if (sdArg != null)
				tmpbuilder.statements.invokeArgs.Replace(sdArg, Argument(ParseExpression(@"this")));

			// Process the xml docs for the method, removing the ignored param
			tmpbuilder.docs?.RemoveParamDoc(ps.Identifier.Text);
		}
		builder = tmpbuilder;
	}

	private static void BuildArrayPtrMethod(SourceProductionContext context, Compilation compilation, IEnumerable<FungibleTypeDecl> types, SyntaxNode node, MethodDeclarationSyntax methodDecl, ImmutableArray<AttributeData> attrDatas, ref MethodBodyBuilder? builder)
	{
		var decl = (ParameterSyntax)node;
		
		ArrayPtrInfo attrInfo;
		try { attrInfo = new(decl, attrDatas); }
		catch (ArgumentException ex)
		{
			context.ReportError(decl, "VANGEN060", $"Invalid ArrayPointer attribute usage: {ex.Message}");
			return;
		}

		var typeIsPtr = decl.Type?.ToString() is "IntPtr" or "System.IntPtr";
		if (attrInfo.ModType != ModType.Out && (attrInfo.ModType != ModType.In || !typeIsPtr))
		{
			context.ReportError(decl, "VANGEN061", "ArrayPointer attribute can only be applied to out parameters when not paired with a SizeDef attribute and in parameters that are IntPtr.");
			return;
		}

		MethodBodyBuilder tmpbuilder = builder ?? new(methodDecl);
		var id = decl.Identifier.Text;
		var cntid = attrInfo.CountParam.Identifier.Text;
		var newTypeName = attrInfo.ElementType.Name + (attrInfo.IsOptional ? "[]?" : "[]");
		var defaultVal = attrInfo.IsOptional ? MethodBodyBuilder.defaultExpr : ParseExpression($"[]");
		ArgumentSyntax GetArg(string name) => tmpbuilder.statements.invokeArgs.First(a => a.NameEquals(name));
		static ArgumentSyntax MakeVarArg(string name) => Argument(null, MethodBodyBuilder.outToken, DeclarationExpression(IdentifierName("var"), SingleVariableDesignation(Identifier(name))));

		// Handle in IntPtr values
		if (attrInfo.ModType == ModType.In && typeIsPtr)
		{
			// Replace method param with designated type, remove all attributes, and add ref modifier
			tmpbuilder.parameters.Replace(decl, decl.WithoutAttributes("ArrayPointer", "In").WithoutTrivia().WithType(ParseTypeName(newTypeName)));
			tmpbuilder.parameters.Remove(attrInfo.CountParam);

			// Setup variable(s) to convert the array to a native pointer
			tmpbuilder.statements.setupVariables[$"__{id}"] = ParseStatement($"using global::Vanara.InteropServices.SafeNativeArray<{attrInfo.ElementType.Name}> __{id} = new({id} ?? []);");
			if (attrInfo.ElementsAreByRef)
				tmpbuilder.statements.setupVariables[$"__p_{id}"] = ParseStatement($"using global::Vanara.InteropServices.SafeNativeArray<IntPtr> __p_{id} = new(__{id}.GetPointers());");

			// Call the invoke method with a reference to the first element of the array
			tmpbuilder.statements.invokeArgs.Replace(GetArg(id), Argument(ParseExpression(attrInfo.ElementsAreByRef ? $"__p_{id}" : $"__{id}")));
			tmpbuilder.statements.invokeArgs.Replace(GetArg(cntid), Argument(ParseExpression($"({attrInfo.CountParam.Type})Convert.ChangeType({id}?.Length ?? 0, typeof({attrInfo.CountParam.Type}))")));

			tmpbuilder.docs?.RemoveParamDoc(cntid);
		}

		// Handle out values with out modifier
		else if (decl.Modifiers.Any(SyntaxKind.OutKeyword))
		{
			// Replace method param with designated type, remove all attributes, and add out modifier; remove the count param as well
			tmpbuilder.parameters.Replace(decl, decl.WithoutAttributes("ArrayPointer", "Out", "Optional").WithoutTrivia().WithType(ParseTypeName(newTypeName)).WithModifiers([Token(SyntaxKind.OutKeyword)]));
			tmpbuilder.parameters.Remove(attrInfo.CountParam);

			// Init out param to default
			tmpbuilder.statements.initOutParams.Add(ExpressionStatement(AssignmentExpression(SyntaxKind.SimpleAssignmentExpression, IdentifierName(decl.Identifier), defaultVal)));

			// Call the invoke method with pinned variable and named count argument
			tmpbuilder.statements.invokeArgs.Replace(GetArg(id), MakeVarArg($"__{id}"));
			tmpbuilder.statements.invokeArgs.Replace(GetArg(cntid), MakeVarArg(cntid));

			// Handle out value that is an out IntPtr and ArrayPointer provides a memory manager
			// TODO: Handle FreeStatement as well
			if (typeIsPtr && attrInfo.MemMgr is not null)
			{
				// Add "using (__id) id = __id.DangerousGetHandle().ToArray<attrInfo.ArrayType.Name>(__id.Size);"
				const string assignOutTemplate = """
				if (__{0} != default && {3} != 0) {{
					try {{
						global::Vanara.PInvoke.SizeT __memSz = {1}.Instance is global::Vanara.InteropServices.IGetMemorySize __igetmemsz ? __igetmemsz.GetSize(__{0}) : int.MaxValue;
						{0} = __{0}.ToArray<{2}>((int)Convert.ChangeType({3}, typeof(int)), 0, __memSz);
					}}
					finally {{ {1}.Instance.FreeMem(__{0}); }}
				}}
				""";
				tmpbuilder.statements.assignOutParams.Add(ParseStatement(string.Format(assignOutTemplate, id, attrInfo.MemMgr.Name, attrInfo.ElementType.Name, cntid)));
			}

			// Handle out value that is a memory handle
			else if (decl.Type!.GetSymbol(compilation) is ITypeSymbol ts && ts.ImplementsInterface("Vanara.InteropServices.IMemoryHandle"))
			{
				// Add "using (__id) id = __id.DangerousGetHandle().ToArray<attrInfo.ArrayType.Name>(__id.Size);"
				tmpbuilder.statements.assignOutParams.Add(ParseStatement($"using (__{id}) {id} = __{id}?.DangerousGetHandle().ToArray<{attrInfo.ElementType.Name}>((int)Convert.ChangeType({cntid}, typeof(int)), 0, __{id}.Size) ?? [];"));
			}

			// Unhandled type, report error
			else
			{
				context.ReportError(decl, "VANGEN062", "ArrayPointer attribute applied to an 'out' value of an unsupported type. Must be IntPtr or IMemoryHandle derived class.");
				return;
			}

			tmpbuilder.docs?.RemoveParamDoc(cntid);
		}

		// Unhandled case, report error
		else
		{
			context.ReportError(decl, "VANGEN060", "Invalid ArrayPointer attribute usage.");
			return;
		}

		builder = tmpbuilder;
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
			if (!IsOptional(decl))
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

	private static void BuildMarshalAsMethod(SourceProductionContext context, Compilation compilation, IEnumerable<FungibleTypeDecl> types, SyntaxNode node, MethodDeclarationSyntax methodDecl, ImmutableArray<AttributeData> attrDatas, ref MethodBodyBuilder? builder)
	{
		var decl = (ParameterSyntax)node;

		// Determine if the syntaxNode has the MarshalAs attribute with contructor first argument of UnmanagedType.IUnknown or UnmanagedType.IInterface and a named argument of IidParameterIndex
		var attrInfo = MarshalAsInfo.Validate(node, attrDatas, methodDecl, out var err);
		if (attrInfo is null)
		{
			if (err is not null)
				context.ReportError(decl, err.Value.Item1, err.Value.Item2);
			return;
		}

		MethodBodyBuilder tmpbuilder = builder ?? new(methodDecl);

		// If this an out parameter, there must be another parameter with the same SizeParamIndex value that is has an In attribute and the same SizeParamIndex and is integral, so look for that and if found, pass it along as well
		if (attrInfo.ModType == ModType.Out && attrInfo.IidParameterIndex is null && (!tmpbuilder.paramReferences.Has(attrInfo!.RefParam!.Identifier.Text).Any(rd => rd.Item2.HasFlag(ModType.In))))
		{
			context.ReportStatus(decl, "VANGEN059", "An array with MarshalAs.LPArray and an Out attribute, can specify a SizeParamIndex value when shared with another parameter marked with an In attribute.");
			return;
		}

		// Setup some common values for use in the transformations
		var argList = tmpbuilder.parameters;
		bool isOutParam = decl.Modifiers.Any(SyntaxKind.OutKeyword);
		bool paramTypeIsNullable = decl.Type is NullableTypeSyntax || decl.Type?.ToString().EndsWith("?") == true;
		bool returnIsVoid = tmpbuilder.returnType.ToString() == "void";

		const string genericTypeBase = "TIUnk";
		const string altArgBase = "__ppv";
		string genericType = UniqueName(genericTypeBase);
		string altArg = isOutParam ? UniqueName(altArgBase) : string.Empty;
		var szVarType = attrInfo.RefParam?.Type;
		string? szVarName = attrInfo.RefParam?.Identifier.Text;

		// Create the extension method signature, removing this attribute
		if (attrInfo.UnmanagedType == UnmanagedType.IUnknown)
		{
			tmpbuilder.typeParameters.Add(TypeParameter(genericType));
			tmpbuilder.typeConstraints.Add(TypeParameterConstraintClause(IdentifierName(genericType), SingletonSeparatedList<TypeParameterConstraintSyntax>(ClassOrStructConstraint(SyntaxKind.ClassConstraint))));
		}
		ParameterSyntax newParam = attrInfo.UnmanagedType switch
		{
			UnmanagedType.IUnknown => decl.WithType(ParseTypeName(genericType + (decl.Type is not null && decl.Type.ToString().EndsWith("?") ? "?" : "")))
				.WithoutAttribute("MarshalAs"),
			UnmanagedType.Interface => decl.WithoutAttribute("MarshalAs"),
			UnmanagedType.LPArray when attrInfo.ModType == ModType.Out => decl.WithoutAttributes("MarshalAs", "Out").WithModifiers([Token(SyntaxKind.OutKeyword)]),
			UnmanagedType.LPArray => decl.WithoutAttribute("MarshalAs"),
			_ => decl.WithoutTrivia()
		};
		tmpbuilder.parameters.Replace(decl, newParam);
		tmpbuilder.parameters.Remove(attrInfo.RefParam!);

		// Initialize an 'int' length param from array length if array and in and not already declared
		if (attrInfo.UnmanagedType == UnmanagedType.LPArray && attrInfo.ModType.HasFlag(ModType.In)
			&& !tmpbuilder.statements.setupVariables.OfType<LocalDeclarationStatementSyntax>().Any(lds => lds.Declaration.Variables.First().Identifier.Text.Equals(szVarName)))
		{
			var getLenExpr = paramTypeIsNullable ? $"{decl.Identifier.Text}?.Length ?? 0" : $"{decl.Identifier.Text}.Length";
			if (attrInfo.RefParam!.Type!.ToString() != "int")
				getLenExpr = $"({szVarType})Convert.ChangeType({getLenExpr}, typeof({szVarType}))";
			tmpbuilder.statements.setupVariables[szVarName!] = LocalDeclarationStatement(VariableDeclaration(szVarType!)
				.WithVariables(SingletonSeparatedList(VariableDeclarator(attrInfo.RefParam!.Identifier)
					.WithInitializer(EqualsValueClause(ParseExpression(getLenExpr))))));
		}

		// Initialize out param
		if (isOutParam || attrInfo.ModType == ModType.Out)
		{
			if (attrInfo.UnmanagedType == UnmanagedType.LPArray)
			{
				// Declare out array param to new array of the correct type and length equal to the RefParam value
				var elementType = decl.Type is NullableTypeSyntax nt ? ((ArrayTypeSyntax)nt.ElementType).ElementType : ((ArrayTypeSyntax?)decl.Type)?.ElementType;
				tmpbuilder.statements.initOutParams.Add(ParseStatement($"{decl.Identifier.Text} = new {elementType?.ToString()}[{(szVarType!.ToString() == "int" ? szVarName! : $"Convert.ToInt32({szVarName})")}];"));
			}
			else
			{
				var expr = ExpressionStatement(AssignmentExpression(SyntaxKind.SimpleAssignmentExpression, IdentifierName(decl.Identifier), MethodBodyBuilder.defaultExpr));
				if (!paramTypeIsNullable)
					expr = expr.WithLeadingTrivia(Trivia(NullableDirectiveTrivia(Token(SyntaxKind.DisableKeyword), true))).WithTrailingTrivia(Trivia(NullableDirectiveTrivia(Token(SyntaxKind.RestoreKeyword), true)));
				tmpbuilder.statements.initOutParams.Add(expr);
			}
		}

		// Create the invocation expression capturing the return value if the return type is not `void`
		ArgumentSyntax ModArgs(ArgumentSyntax a) => a switch
		{
			var a1 when a1.NameEquals(szVarName!) => attrInfo.UnmanagedType switch
			{
				UnmanagedType.IUnknown => Argument(ParseExpression($"typeof({genericType}).GUID")),
				UnmanagedType.Interface => Argument(ParseExpression($"typeof({decl.Type!.ToString().TrimEnd('?')}).GUID")),
				UnmanagedType.LPArray when attrInfo.ModType.HasFlag(ModType.In) && methodDecl.ParameterList.Parameters.FirstOrDefault(p => p.Identifier.Text == szVarName) is ParameterSyntax refParam => Argument(ParseExpression(szVarName!)),
				_ => a1,
			},
			var a1 when a1.Expression is IdentifierNameSyntax ins && ins.Identifier.Text == decl.Identifier.Text => isOutParam
				? Argument(null, MethodBodyBuilder.outToken, DeclarationExpression(IdentifierName("var"), SingleVariableDesignation(Identifier(altArg))))
				: Argument(IdentifierName(ins.Identifier.Text)),
			_ => a
		};
		tmpbuilder.statements.invokeArgs = [.. tmpbuilder.statements.invokeArgs.Select(ModArgs)];
		if (tmpbuilder.statements.invokeForQueryArgs is not null)
			tmpbuilder.statements.invokeForQueryArgs = [.. tmpbuilder.statements.invokeForQueryArgs.Select(ModArgs)];

		// Create the assignment expression
		if (isOutParam)
		{
			if (attrInfo.UnmanagedType == UnmanagedType.IUnknown)
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
			XmlNode? refNode = tmpbuilder.docs.SelectSingleNode($"//param[@name='{szVarName}']");
			if (refNode is not null)
			{
				// Add the ref parameter docs to the method docs as the value of the typeParam tag
				if (attrInfo.UnmanagedType == UnmanagedType.IUnknown)
					tmpbuilder.docs.InsertTypeParamDocAfter(genericType, refNode.InnerXml);

				// Remove the ref parameter docs
				refNode.ParentNode?.RemoveChild(refNode);

				// Remove the "<paramref name="refParamName"/>" tags from the entire document
				XmlElement replElem = tmpbuilder.docs.CreateElement("c");
				replElem.InnerText = szVarName;
				foreach (var n in tmpbuilder.docs.SelectNodes($"//paramref[@name='{szVarName}']").Cast<XmlElement>().Where(n => n.ParentNode is not null))
					n.ParentNode?.ReplaceChild(replElem, n);
			}
		}

		builder = tmpbuilder;
	}

	private static void BuildSizeDefMethod(SourceProductionContext context, Compilation compilation, IEnumerable<FungibleTypeDecl> types, SyntaxNode node, MethodDeclarationSyntax methodDecl, ImmutableArray<AttributeData> attrDatas, ref MethodBodyBuilder? builder)
	{
		MethodBodyBuilder tmpbuilder = builder ?? new(methodDecl);
		var decl = (ParameterSyntax)node;

		var attrInfo = SizeDefInfo.Validate(node, attrDatas, methodDecl, out var err);
		if (attrInfo is null)
		{
			if (err is not null)
				context.ReportError(decl, err.Value.Item1, err.Value.Item2);
			return;
		}

		// Determine the output type from the parameter type: if it's a StringBuilder, then string, else the element type of the array or IntPtr
		(TypeSyntax? outType, SizeParamType szType, string getLenExpr) = decl.Type?.ToString() switch
		{
			"string" => (PredefinedType(Token(SyntaxKind.StringKeyword)), SizeParamType.String, "{0}.Length"),
			"StringBuilder" => (PredefinedType(Token(SyntaxKind.StringKeyword)), SizeParamType.String, "{0}.Capacity"),
			"string?" => (NullableType(PredefinedType(Token(SyntaxKind.StringKeyword))), SizeParamType.String | SizeParamType.Nullable, "{0}?.Length ?? 0"),
			"StringBuilder?" => (NullableType(PredefinedType(Token(SyntaxKind.StringKeyword))), SizeParamType.String | SizeParamType.Nullable, "{0}?.Capacity ?? 0"),
			var s when (s ?? "").EndsWith("[]") == true => (decl.Type!.WithoutTrivia(), SizeParamType.Array, "{0}.Length"),
			var s when (s ?? "").EndsWith("[]?") == true => (decl.Type!.WithoutTrivia(), SizeParamType.Array | SizeParamType.Nullable, "{0}?.Length ?? 0"),
			"IntPtr" or "System.IntPtr" => attrInfo switch
			{
				var ai when ai.StructPtr is not null => ai switch
				{
					//var sai when !ai.StructPtr.Marshal && ai.ModType == ModType.Out => (ParseTypeName($"global::Vanara.InteropServices.SafeHGlobalStruct<{ai.StructPtr.StructType.Name}>"), SizeParamType.StructPtr, "***THIS SHOULD NEVER HAPPEN***"),
					var sai when !ai.StructPtr.Marshal && ai.ModType == ModType.Out => (hMemType, SizeParamType.StructPtr, "***THIS SHOULD NEVER HAPPEN***"),
					var sai when ai.StructPtr.IsOptional => (ParseTypeName(ai.StructPtr.StructType.Name + '?'), SizeParamType.StructPtr | SizeParamType.Nullable, $"global::Vanara.Extensions.InteropExtensions.SizeOf<{ai.StructPtr.StructType.Name}>()"),
					_ => (ParseTypeName(ai.StructPtr.StructType.Name), SizeParamType.StructPtr, $"global::Vanara.Extensions.InteropExtensions.SizeOf<{ai.StructPtr.StructType.Name}>()"),
				},
				var ai when ai.ArrayPtr is not null && ai.ArrayPtr.IsOptional => (ParseTypeName(ai.ArrayPtr.ElementType.Name + "[]?"), SizeParamType.ArrayPtr | SizeParamType.Nullable, "***THIS SHOULD NEVER HAPPEN***"),
				var ai when ai.ArrayPtr is not null => (ParseTypeName(ai.ArrayPtr.ElementType.Name + "[]"), SizeParamType.ArrayPtr, "***THIS SHOULD NEVER HAPPEN***"),
				var ai when ai.IsOptional => (ParseTypeName("byte[]?"), SizeParamType.Ptr | SizeParamType.Nullable, "{0}?.Length ?? 0"),
				_ => (ParseTypeName("byte[]"), SizeParamType.Ptr, "{0}.Length"),
			},
			_ => default,
		};

		// TODO: Remove once arrays and pointers implemented
		if (outType is null)
			return;

		bool isNullable = szType.HasFlag(SizeParamType.Nullable);
		ModType paramModType = attrInfo.ModType;
		bool isInParam = paramModType == ModType.In && !attrInfo.SizingMethod.HasFlag(SizingMethod.Query);
		bool returnIsVoid = tmpbuilder.returnType.ToString() == "void";
		bool useStructHandle = szType.HasFlag(SizeParamType.StructPtr) && attrInfo.StructPtr is not null && (!attrInfo.StructPtr.Marshal || !attrInfo.StructPtr.StructType.IsUnmanagedType);

		// If szMeth is Count, outSizeParam must be null and paramModType must be In
		if (!attrInfo.SizingMethod.HasFlag(SizingMethod.Query))
		{
			if (attrInfo.OutSzParam is not null)
			{
				context.ReportError(decl, "VANGEN028", "When SizingMethod is Count, out size parameter cannot be specified.");
				return;
			}
			//if (paramModType != ModType.In)
			//{
			//	context.ReportError(decl, "VANGEN027", "When SizingMethod is Count, size parameter must be an [In] parameter.");
			//	return;
			//}
		}

		// **********************************
		// Parameters
		// **********************************
		// Replace the syntaxNode and remove the attrInfo.SzParam parameters from the method signature
		SyntaxToken[] paramMods = isInParam ? [] : [Token(SyntaxKind.OutKeyword)];
		var newDecl = decl.WithoutAttributes("SizeDef", "StructPointer", "ArrayPointer", "Out").WithModifiers(TokenList(paramMods)).WithType(outType);
		if (!isNullable) newDecl = newDecl.WithoutAttribute("Optional");
		if (!isInParam) newDecl = newDecl.WithoutAttribute("In");
		tmpbuilder.parameters.Replace(decl, newDecl);
		if (attrInfo.SzParam is not null) tmpbuilder.parameters.Remove(attrInfo.SzParam);
		if (attrInfo.OutSzParam is not null) tmpbuilder.parameters.Remove(attrInfo.OutSzParam);
		if (attrInfo.ByteSzParam is not null) tmpbuilder.parameters.Remove(attrInfo.ByteSzParam);

		// **********************************
		// Declare default argument values
		// **********************************
		// 1. Create statement that creates a variable for the size of the type of attrInfo.SzParam and assigns it the value of default (query) or sz
		var szVarName = attrInfo.SzParam is null ? UniqueName("__sz") : attrInfo.SzParam.Identifier.Text;
		TypeSyntax szVarTypeDecl = attrInfo.SzParam is null ? PredefinedType(Token(SyntaxKind.IntKeyword)) : attrInfo.SzParam.Type!;
		// Get size based on count
		if (isInParam || attrInfo.InitSize == -1)
			attrInfo.SzValueExpr = szVarTypeDecl.ToString() == "int" ? string.Format(getLenExpr, decl.Identifier.Text) : $"({szVarTypeDecl})Convert.ChangeType({string.Format(getLenExpr, decl.Identifier.Text)}, typeof({szVarTypeDecl}))";
		else if (attrInfo.InitSize > 0)
			attrInfo.SzValueExpr = szVarTypeDecl.ToString() == "int" ? attrInfo.InitSize.ToString() : $"({szVarTypeDecl})Convert.ChangeType({attrInfo.InitSize}, typeof({szVarTypeDecl}))";
		// Initialize size variable
		tmpbuilder.statements.setupVariables[szVarName] = LocalDeclarationStatement(VariableDeclaration(szVarTypeDecl)
			.WithVariables(SingletonSeparatedList(VariableDeclarator(Identifier(szVarName))
				.WithInitializer(EqualsValueClause(attrInfo.SizingMethod.HasFlag(SizingMethod.Query) && attrInfo.InitSize == 0 ? MethodBodyBuilder.defaultExpr : ParseExpression(attrInfo.SzValueExpr ?? "0"))))));
		// If attrInfo.OutSzParam is specified, create statement that assigns attrInfo.OutSzParam to default value
		if (attrInfo.OutSzParam is not null)
			tmpbuilder.statements.setupVariables[attrInfo.OutSzParam.Identifier.Text] = LocalDeclarationStatement(VariableDeclaration(attrInfo.OutSzParam.Type!)
			.WithVariables(SingletonSeparatedList(VariableDeclarator(Identifier(attrInfo.OutSzParam.Identifier.Text))
				.WithInitializer(EqualsValueClause(MethodBodyBuilder.defaultExpr)))));
		// If attrInfo.ByteSzParam is specified, create statement that assigns attrInfo.ByteSzParam to default value
		if (attrInfo.ByteSzParam is not null)
			tmpbuilder.statements.setupVariables[attrInfo.ByteSzParam.Identifier.Text] = LocalDeclarationStatement(VariableDeclaration(attrInfo.ByteSzParam.Type!)
			.WithVariables(SingletonSeparatedList(VariableDeclarator(Identifier(attrInfo.ByteSzParam.Identifier.Text))
				.WithInitializer(EqualsValueClause(MethodBodyBuilder.defaultExpr)))));

		// **********************************
		// Initialize out parameter values
		// **********************************
		(ExpressionSyntax? outNullVal, ExpressionSyntax? outDefVal) = (szType & ~SizeParamType.Nullable) switch
		{
			SizeParamType.String => (MethodBodyBuilder.defaultExpr, ParseExpression("string.Empty")),
			SizeParamType.Array or SizeParamType.Ptr or SizeParamType.ArrayPtr => (MethodBodyBuilder.defaultExpr, ParseExpression("[]")),
			SizeParamType.StructPtr when !attrInfo.StructPtr!.Marshal => (ParseExpression($"{hMemTypeStr}.Null"), MethodBodyBuilder.defaultExpr),
			SizeParamType.StructPtr => (MethodBodyBuilder.defaultExpr, ParseExpression("new()")),
			_ => default,
		};
		if (outNullVal is null || outDefVal is null)
		{
			context.ReportError(decl, "VANGEN029", "SizeDef attribute currently only supports parameters of type string, StringBuilder, IntPtr or arrays.");
			return;
		}
		if (!isInParam)
			tmpbuilder.statements.initOutParams.Add(ExpressionStatement(AssignmentExpression(SyntaxKind.SimpleAssignmentExpression, IdentifierName(decl.Identifier),
				isNullable || (attrInfo.StructPtr is not null && !attrInfo.StructPtr.Marshal) ? outNullVal : outDefVal)));

		// **********************************
		// Setup argument values
		// **********************************
		// If isInParam is true, create an assignment statement that assigns decl parameter to the appropriate value 
		string? setupArgName = $"__{decl.Identifier.Text}";
		if (isInParam || attrInfo.InitSize != 0)
		{
			var setupArgType = (szType & ~SizeParamType.Nullable) switch
			{
				SizeParamType.StructPtr when isInParam || attrInfo.InitSize != 0 => hMemType,
				SizeParamType.ArrayPtr when !attrInfo.ArrayPtr!.ElementType.IsUnmanagedType => hMemType,
				_ => decl.Type!,
			};
			tmpbuilder.statements.setupArgs.Add(LocalDeclarationStatement(VariableDeclaration(setupArgType)
				.WithVariables(SingletonSeparatedList(VariableDeclarator(Identifier(setupArgName!))
					.WithInitializer(EqualsValueClause((szType & ~SizeParamType.Nullable) switch
					{
						SizeParamType.Ptr when isNullable => ParseExpression($"{decl.Identifier.Text} is null ? default : global::System.Runtime.InteropServices.Marshal.UnsafeAddrOfPinnedArrayElement({decl.Identifier.Text}, 0)"),
						SizeParamType.Ptr => ParseExpression($"global::System.Runtime.InteropServices.Marshal.UnsafeAddrOfPinnedArrayElement({decl.Identifier.Text}, 0)"),
						SizeParamType.String when attrInfo.InitSize != 0 => ParseExpression($"new({(attrInfo.InitSize == -1 ? "1" : attrInfo.InitSize.ToString())})"),
						SizeParamType.String when isNullable => IdentifierName($"{decl.Identifier.Text}?.ToString()"),
						SizeParamType.String => IdentifierName($"{decl.Identifier.Text}.ToString()"),
						SizeParamType.StructPtr when !useStructHandle && isInParam => ParseExpression($"new global::Vanara.InteropServices.PinnedObject({decl.Identifier.Text})"),
						SizeParamType.StructPtr when !useStructHandle && !isInParam => ParseExpression($"new({(attrInfo.InitSize == -1 ? string.Format(getLenExpr, decl.Identifier.Text) : attrInfo.InitSize.ToString())})"),
						SizeParamType.StructPtr => ParseExpression($"{hMemTypeStr}.CreateFromStructure({decl.Identifier.Text})"),
						SizeParamType.ArrayPtr when attrInfo.ArrayPtr!.ElementType.IsUnmanagedType => ParseExpression($"global::System.Runtime.InteropServices.Marshal.UnsafeAddrOfPinnedArrayElement({decl.Identifier.Text}, 0)"),
						SizeParamType.ArrayPtr => ParseExpression($"{hMemTypeStr}.CreateFromList({decl.Identifier.Text})"),
						_ => IdentifierName(decl.Identifier.Text),
					}))))));
		}

		// **********************************
		// Setup arguments for query
		// **********************************
		if (attrInfo.SizingMethod.HasFlag(SizingMethod.Query))
		{
			// Call method for query, if sizing method is Query
			// Assign variables after query
			tmpbuilder.statements.invokeForQueryArgs ??= [.. tmpbuilder.statements.invokeArgs.Select(a => a.WithoutTrivia())];
			if (attrInfo.SizingMethod.HasFlag(SizingMethod.QueryResultInReturn))
			{
				tmpbuilder.statements.invokeForQueryArgs = [.. tmpbuilder.statements.invokeForQueryArgs.Select(a => a switch
				{
					ArgumentSyntax arg when arg.NameEquals(decl.Identifier.Text) => Argument(attrInfo.InitSize == 0 ? DefaultExpression(decl.Type!) : IdentifierName(setupArgName)),
					ArgumentSyntax arg when attrInfo.SzParam is not null && arg.NameEquals(attrInfo.SzParam.Identifier.Text) => Argument(IdentifierName(szVarName)),
					_ => a
				})];
			}
			else if (attrInfo.SizingMethod.HasFlag(SizingMethod.CheckLastError))
			{
				tmpbuilder.statements.invokeForQueryArgs = [.. tmpbuilder.statements.invokeForQueryArgs.Select(a => a switch
				{
					ArgumentSyntax arg when arg.NameEquals(decl.Identifier.Text) => Argument(attrInfo.InitSize == 0 ? DefaultExpression(decl.Type!) : IdentifierName(setupArgName)),
					ArgumentSyntax arg when attrInfo.SzParam is not null && arg.NameEquals(attrInfo.SzParam.Identifier.Text) => attrInfo switch {
						var ai when ai.OutSzParam is not null && ai.SzParam.Modifiers.Any(SyntaxKind.RefKeyword) => Argument(null, MethodBodyBuilder.refToken, IdentifierName(szVarName)),
						var ai when ai.OutSzParam is not null => Argument(IdentifierName(szVarName)),
						var ai when ai.OutSzParam is not null => Argument(IdentifierName(szVarName)),
						_ => a,
					},
					_ => a
				})];
			}
			else
			{
				tmpbuilder.statements.invokeForQueryArgs = [.. tmpbuilder.statements.invokeForQueryArgs.Select(a => a switch
				{
					ArgumentSyntax arg when arg.NameEquals(decl.Identifier.Text) && isNullable => Argument(DefaultExpression(decl.Type!)),
					ArgumentSyntax arg when arg.NameEquals(decl.Identifier.Text) => (szType & ~SizeParamType.Nullable) switch {
						SizeParamType.String => Argument(ParseExpression("new StringBuilder(0)")),
						SizeParamType.Array => Argument(ParseExpression("[]")),
						SizeParamType.Ptr => Argument(ParseExpression("IntPtr.Zero")),
						SizeParamType.StructPtr or SizeParamType.ArrayPtr => Argument(attrInfo.InitSize == 0 ? MethodBodyBuilder.defaultExpr : IdentifierName(setupArgName)),
						_ => a,
					},
					ArgumentSyntax arg when attrInfo.SzParam is not null && arg.NameEquals(attrInfo.SzParam.Identifier.Text) => attrInfo switch {
						var ai when ai.OutSzParam is null => Argument(null, MethodBodyBuilder.refToken, IdentifierName(szVarName)),
						var ai when ai.OutSzParam is not null => Argument(IdentifierName(szVarName)),
						_ => a,
					},
					_ => a
				})];
			}

			// **********************************
			// Setup query result handler
			// **********************************
			if (!returnIsVoid)
				tmpbuilder.statements.queryFailureHandler.Add(
					ParseStatement($"if (global::Vanara.PInvoke.FailedHelper.FAILED({MethodBodyBuilder.qretVarName}, {(attrInfo.SizingMethod.HasFlag(SizingMethod.CheckLastError) ? "true" : "false")})) return {MethodBodyBuilder.qretVarName};"));
		}

		// **********************************
		// Assign/declare post query variables
		// **********************************
		// 1. Assign correct size to szVarName
		if (attrInfo.SizingMethod.HasFlag(SizingMethod.QueryResultInReturn))
			tmpbuilder.statements.assignAfterQuery.Insert(0,
				ExpressionStatement(AssignmentExpression(SyntaxKind.SimpleAssignmentExpression, IdentifierName(szVarName), IdentifierName(MethodBodyBuilder.qretVarName))));
		else if (attrInfo.OutSzParam is not null)
			tmpbuilder.statements.assignAfterQuery.Insert(0,
				ExpressionStatement(AssignmentExpression(SyntaxKind.SimpleAssignmentExpression, IdentifierName(szVarName), IdentifierName(attrInfo.OutSzParam.Identifier.Text))));
		// 2. Create a statement that creates a variable for the output of syntaxNode and initializes it to the value of 'sz'
		var cElemName = UniqueName($"__i{szVarName}");
		if (isInParam)
			cElemName = szVarName;
		else
		{
			// 3. Create a variable that holds the number of elements initialized to the value of szVarName
			tmpbuilder.statements.assignAfterQuery.Add(LocalDeclarationStatement(VariableDeclaration(PredefinedType(Token(SyntaxKind.IntKeyword)))
				.WithVariables(SingletonSeparatedList(VariableDeclarator(Identifier(cElemName))
					.WithInitializer(EqualsValueClause(ParseExpression(szVarTypeDecl.ToString() == "int" ? szVarName : $"Convert.ToInt32({szVarName})")))))));
		}
		// 4. Create statement that adjusts to bytes if indicated
		if (attrInfo.SizingMethod.HasFlag(SizingMethod.Bytes))
		{
			var getElemSize = szType switch
			{
				var t when t.HasFlag(SizeParamType.String) => $"global::Vanara.Extensions.StringHelper.GetCharSize(CharSet.{attrInfo.CharSet})",
				SizeParamType.Array | SizeParamType.Nullable => $"global::Vanara.Extensions.InteropExtensions.SizeOf(typeof({((ArrayTypeSyntax)((NullableTypeSyntax)outType!).ElementType).ElementType}), CharSet.{attrInfo.CharSet})",
				SizeParamType.Array => $"global::Vanara.Extensions.InteropExtensions.SizeOf(typeof({((ArrayTypeSyntax)outType!).ElementType}), CharSet.{attrInfo.CharSet})",
				_ => null,
			};
			if (getElemSize is not null)
			{
				var expr = ExpressionStatement(AssignmentExpression(SyntaxKind.DivideAssignmentExpression, IdentifierName(cElemName), ParseExpression(getElemSize)));
				tmpbuilder.statements.assignAfterQuery.Add(expr);
			}
		}
		// 5. Create statement that adjusts for null term if indicated
		if (attrInfo.SizingMethod.HasFlag(SizingMethod.InclNullTerm))
		{
			var expr = ExpressionStatement(AssignmentExpression(SyntaxKind.SubtractAssignmentExpression, IdentifierName(cElemName), ParseExpression("1")));
			tmpbuilder.statements.assignAfterQuery.Add(expr);
		}
		// 6. If the outType is string, initialize to new StringBuilder(sz)
		var outVarName = $"__{decl.Identifier.Text}";
		if (!isInParam)
		{
			var outVarDecl = VariableDeclaration(decl.Type!);
			if (attrInfo.InitSize == 0)
			{
				outVarDecl = (szType & ~SizeParamType.Nullable) switch
				{
					SizeParamType.String => outVarDecl
						.WithVariables(SingletonSeparatedList(VariableDeclarator(Identifier(outVarName))
							.WithInitializer(EqualsValueClause(ImplicitObjectCreationExpression()
								.WithArgumentList(ArgumentList(SingletonSeparatedList(Argument(ParseExpression(cElemName))))))))),
					SizeParamType.Array => (decl.Type is ArrayTypeSyntax ats ? ats : (decl.Type is NullableTypeSyntax nts && nts.ElementType is ArrayTypeSyntax nats ? nats : null))?
						.CreateArrayVariableDeclaration(outVarName, cElemName) ?? outVarDecl,
					SizeParamType.StructPtr when useStructHandle => VariableDeclaration(hMemType)
						.WithVariables(SingletonSeparatedList(VariableDeclarator(Identifier(outVarName))
							.WithInitializer(EqualsValueClause(ImplicitObjectCreationExpression()
								.WithArgumentList(ArgumentList(SingletonSeparatedList(Argument(ParseExpression(cElemName))))))))),
					SizeParamType.Ptr or SizeParamType.StructPtr => ArrayType(ParseTypeName("byte")).CreateArrayVariableDeclaration(outVarName, cElemName),
					SizeParamType.ArrayPtr => ArrayType(ParseTypeName(attrInfo.ArrayPtr!.ElementType.Name)).CreateArrayVariableDeclaration(outVarName, cElemName),
					_ => outVarDecl,
				};
				tmpbuilder.statements.assignAfterQuery.Add(LocalDeclarationStatement(outVarDecl));
			}
			else
			{
				tmpbuilder.statements.assignAfterQuery.Add(ExpressionStatement(AssignmentExpression(SyntaxKind.SimpleAssignmentExpression, IdentifierName($"{outVarName}.{(szType.IsFlagSet(SizeParamType.String) ? "Capacity" : "Size")}"), IdentifierName(cElemName))));
			}
		}

		// **********************************
		// Setup arguments for invoke
		// **********************************
		// 1. Replace the reference to the parameter in the method body invokeArgs statement with outVarName
		var sdArg = tmpbuilder.statements.invokeArgs.FirstOrDefault(a => a.NameEquals(decl.Identifier.Text));
		if (sdArg != null)
		{
			tmpbuilder.statements.invokeArgs.Replace(sdArg, (szType & ~SizeParamType.Nullable) switch
			{
				SizeParamType t when isInParam => Argument(IdentifierName(setupArgName!)),
				SizeParamType.StructPtr when attrInfo.StructPtr?.Marshaler is not null => Argument(ParseExpression($"global::Vanara.InteropServices.MarshalHelper.MarshalFromNative<{attrInfo.StructPtr.Marshaler.Name}, {attrInfo.StructPtr.StructType.Name}>({outVarName})")),
				SizeParamType.StructPtr when useStructHandle => Argument(IdentifierName(outVarName)),
				SizeParamType.ArrayPtr when attrInfo.ArrayPtr?.Marshaler is not null => Argument(ParseExpression($"global::Vanara.InteropServices.MarshalHelper.MarshalFromNative<{attrInfo.ArrayPtr.Marshaler.Name}, {attrInfo.ArrayPtr.ElementType.Name}[]>({outVarName})")),
				SizeParamType.Ptr or SizeParamType.StructPtr when isNullable && attrInfo.InitSize == 0 => Argument(ParseExpression($"{outVarName} is null ? default : global::System.Runtime.InteropServices.Marshal.UnsafeAddrOfPinnedArrayElement({outVarName}, 0)")),
				SizeParamType.Ptr or SizeParamType.StructPtr or SizeParamType.ArrayPtr when attrInfo.InitSize == 0 => Argument(ParseExpression($"global::System.Runtime.InteropServices.Marshal.UnsafeAddrOfPinnedArrayElement({outVarName}, 0)")),
				SizeParamType.Array => Argument(IdentifierName(outVarName)),
				_ => Argument(IdentifierName(outVarName)),
			});
			if (isInParam)
				tmpbuilder.statements.invokeForQueryArgs?.Replace(sdArg, Argument(IdentifierName(setupArgName!)));
		}

		// **********************************
		// Assign output parameter values
		// **********************************
		// 1. Set the output parameter to the value of outVarName, converting as needed, if query
		if (!isInParam)
		{
			if (attrInfo.OutSzParam is not null && (szType.HasFlag(SizeParamType.Array) || szType.HasFlag(SizeParamType.Ptr)))
				tmpbuilder.statements.assignOutParams.Add(ExpressionStatement(ParseExpression($"Array.Resize(ref {outVarName}, (int){attrInfo.OutSzParam.Identifier.Text})")));

			ExpressionSyntax? assignExpr = (szType & ~SizeParamType.Nullable) switch
			{
				SizeParamType.String => ParseExpression($"{outVarName}.ToString()"),
				SizeParamType.StructPtr when (useStructHandle && attrInfo.StructPtr!.Marshal) || attrInfo.InitSize != 0 => ParseExpression($"{outVarName}.ToStructure<{attrInfo.StructPtr!.StructType.Name}>()!"),
				SizeParamType.StructPtr when attrInfo.StructPtr!.Marshal => ParseExpression($"global::System.Runtime.InteropServices.Marshal.UnsafeAddrOfPinnedArrayElement({outVarName}, 0).ToStructure<{attrInfo.StructPtr!.StructType.Name}>({cElemName})"),
				_ => ParseExpression(outVarName),
			};
			tmpbuilder.statements.assignOutParams.Add(ExpressionStatement(AssignmentExpression(SyntaxKind.SimpleAssignmentExpression, IdentifierName(decl.Identifier), assignExpr)));
		}

		// **********************************
		// Process the xml docs for the method, removing the ignored param
		// **********************************
		if (attrInfo.SzParam is not null)
			tmpbuilder.docs?.RemoveParamDoc(attrInfo.SzParam.Identifier.Text);
		if (attrInfo.OutSzParam is not null)
			tmpbuilder.docs?.RemoveParamDoc(attrInfo.OutSzParam.Identifier.Text);

		builder = tmpbuilder;
	}

	private static void BuildStructPtrMethod(SourceProductionContext context, Compilation compilation, IEnumerable<FungibleTypeDecl> types, SyntaxNode node, MethodDeclarationSyntax methodDecl, ImmutableArray<AttributeData> attrDatas, ref MethodBodyBuilder? builder)
	{
		var decl = (ParameterSyntax)node;

		StructPtrInfo attrInfo;
		try { attrInfo = new(decl, attrDatas); }
		catch (ArgumentException ex)
		{
			context.ReportError(decl, "VANGEN050", $"Invalid StructPointer attribute usage: {ex.Message}");
			return;
		}

		var typeIsPtr = decl.Type?.ToString() is "IntPtr" or "System.IntPtr";
		if (attrInfo.ModType != ModType.Out && (attrInfo.ModType == ModType.Out || !typeIsPtr))
		{
			context.ReportError(decl, "VANGEN051", "StructPointer attribute can only be applied to out parameters when not paired with a SizeDef attribute and in parameters that are IntPtr.");
			return;
		}

		MethodBodyBuilder tmpbuilder = builder ?? new(methodDecl);
		var id = decl.Identifier.Text;
		var iArrayStructType = attrInfo.StructType.AllInterfaces.FirstOrDefault(i => i.OriginalDefinition.MetadataName == "IArrayStruct`1" && i.OriginalDefinition.ContainingNamespace.ToDisplayString() == "Vanara.PInvoke")?.TypeArguments.FirstOrDefault();
		TypeSyntax newType = ParseTypeName(iArrayStructType is null || !decl.Modifiers.Any(SyntaxKind.OutKeyword) ? attrInfo.StructType.Name + (attrInfo.IsOptional ? "?" : "") : iArrayStructType.Name + (attrInfo.IsOptional ? "[]?" : "[]"));
		ArgumentSyntax GetArg(string name) => tmpbuilder.statements.invokeArgs.First(a => a.NameEquals(name));

		// Handle in IntPtr values
		if (typeIsPtr && /*attrInfo.IsOptional &&*/ attrInfo.ModType.HasFlag(ModType.In))
		{
			// Replace method param with designated type, remove all attributes, and add in modifier
			tmpbuilder.parameters.Replace(decl, decl.WithoutAttributes("StructPointer", "In", "Out", "Optional").WithoutTrivia().WithType(newType).WithModifiers([Token(attrInfo.ModType == ModType.In ? SyntaxKind.InKeyword : SyntaxKind.RefKeyword)]));

			// Setup variable(s) to convert the array to a native pointer
			if (attrInfo.StructType.IsUnmanagedType)
				tmpbuilder.statements.setupArgs.Add(ParseStatement($"using global::Vanara.InteropServices.PinnedObject __{id} = new({id});"));
			else
				tmpbuilder.statements.setupArgs.Add(ParseStatement($"using var __{id} = {hMemTypeStr}.CreateFromStructure({id});"));

			// Call the invoke method with a reference to the first element of the array
			tmpbuilder.statements.invokeArgs.Replace(GetArg(id), Argument(ParseExpression($"__{id}")));
		}

		// Handle optional out values with no modifier
		else if (typeIsPtr && attrInfo.IsOptional && !decl.Modifiers.Any())
		{
			// Replace method param with designated type, remove all attributes, and add out modifier
			tmpbuilder.parameters.Replace(decl, decl.WithoutAttributes("StructPointer", "Out", "Optional").WithoutTrivia().WithType(newType).WithModifiers([Token(SyntaxKind.OutKeyword)]));

			// Init out param to default
			tmpbuilder.statements.initOutParams.Add(ExpressionStatement(AssignmentExpression(SyntaxKind.SimpleAssignmentExpression, IdentifierName(decl.Identifier), MethodBodyBuilder.defaultExpr)));

			// Create expression to pin the out value
			if (attrInfo.StructType.IsUnmanagedType)
				tmpbuilder.statements.setupArgs.Add(ParseStatement($"using global::Vanara.InteropServices.PinnedObject __{id} = new({id});"));
			else
				tmpbuilder.statements.setupArgs.Add(ParseStatement($"using var __{id} = {hMemTypeStr}.CreateFromStructure({id});"));

			// Call the invoke method with pinned variable
			tmpbuilder.statements.invokeArgs.Replace(GetArg(id), Argument(IdentifierName($"__{id}")));
		}

		// Handle out values with out modifier
		else if (decl.Modifiers.Any(SyntaxKind.OutKeyword))
		{
			// Replace method param with designated type, remove all attributes, and add out modifier
			tmpbuilder.parameters.Replace(decl, decl.WithoutAttributes("StructPointer", "Out", "Optional").WithoutTrivia().WithType(newType).WithModifiers([Token(SyntaxKind.OutKeyword)]));

			// Init out param to default
			tmpbuilder.statements.initOutParams.Add(ExpressionStatement(AssignmentExpression(SyntaxKind.SimpleAssignmentExpression, IdentifierName(decl.Identifier), iArrayStructType is not null && !attrInfo.IsOptional ? ParseExpression("[]") : MethodBodyBuilder.defaultExpr)));

			// Call the invoke method with "out var" variable
			//tmpbuilder.statements.invokeArgs.Replace(GetArg(id), Argument(IdentifierName($"__{id}")));
			tmpbuilder.statements.invokeArgs.Replace(GetArg(id), Argument(null, MethodBodyBuilder.outToken, DeclarationExpression(decl.Type!, SingleVariableDesignation(Identifier($"__{id}")))));

			// Handle out value that is an out IntPtr and StructPointer provides a memory manager
			// TODO: Handle FreeStatement as well
			if (typeIsPtr && attrInfo.MemMgr is not null)
			{
				// Add structure extraction statement in assignOutParams
				const string assignOutTemplate = """
				if (__{0} != default) {{
					try {{
						global::Vanara.PInvoke.SizeT __memSz = {1}.Instance is global::Vanara.InteropServices.IGetMemorySize __igetmemsz ? __igetmemsz.GetSize(__{0}) : int.MaxValue;
						{0} = __{0}.ToStructure<{2}>(__memSz);
					}}
					finally {{ {1}.Instance.FreeMem(__{0}); }}
				}}
				""";
				const string assignOutArrayTemplate = """
				if (__{0} != default) {{
					try {{
						global::Vanara.PInvoke.SizeT __memSz = {1}.Instance is global::Vanara.InteropServices.IGetMemorySize __igetmemsz ? __igetmemsz.GetSize(__{0}) : int.MaxValue;
						{0} = ((global::Vanara.PInvoke.IArrayStruct<{3}>?)__{0}.ToStructure<{2}>(__memSz))?.GetArray() ?? [];
					}}
					finally {{ {1}.Instance.FreeMem(__{0}); }}
				}}
				""";
				tmpbuilder.statements.assignOutParams.Add(ParseStatement(string.Format(iArrayStructType is null ? assignOutTemplate : assignOutArrayTemplate, id, attrInfo.MemMgr.Name, attrInfo.StructType.Name, iArrayStructType?.Name)));
			}

			// Handle out value that is a memory handle
			else if (decl.Type!.GetSymbol(compilation) is ITypeSymbol ts && ts.ImplementsInterface("Vanara.InteropServices.IMemoryHandle"))
			{
				// Add out param wrapped in using
				if (iArrayStructType is not null)
					tmpbuilder.statements.assignOutParams.Add(ParseStatement($"using (__{id}) {id} = ((global::Vanara.PInvoke.IArrayStruct<{iArrayStructType.Name}>?)__{id}.DangerousGetHandle().ToStructure<{attrInfo.StructType.Name}>(__{id}.Size))?.GetArray() ?? [];"));
				else
					tmpbuilder.statements.assignOutParams.Add(ParseStatement($"using (__{id}) {id} = __{id}.DangerousGetHandle().ToStructure<{attrInfo.StructType.Name}>(__{id}.Size);"));
			}

			// Unhandled type, report error
			else
			{
				context.ReportError(decl, "VANGEN052", "StructPtr attribute applied to an 'out' value of an unsupported type. Must be IntPtr or IMemoryHandle derived class.");
				return;
			}
		}

		// Unhandled case, report error
		else
		{
			context.ReportError(decl, "VANGEN050", "StructPtr attribute applied to unhandled syntax.");
			return;
		}

		builder = tmpbuilder;
	}

	private abstract class ParamInfo(ParameterSyntax ps)
	{
		public virtual CharSet CharSet { get; init; } = ps.GetCharSet();
		public bool IsOptional { get; init; } = IsOptional(ps);
		public ModType ModType { get; init; } = GetModType(ps);
		public ParameterSyntax Param { get; init; } = ps;
		protected static AttributeData? GetAttr(string id, ImmutableArray<AttributeData> attrDatas) => attrDatas.FirstOrDefault(a => a.AttributeClass?.ToDisplayString() == id);
		protected static object? GetNamedArg(string id, ImmutableArray<AttributeData> attrDatas, string arg) => GetAttr(id, attrDatas)?.NamedArguments.FirstOrDefault(a => a.Key == arg).Value.Value;
	}

	private class ArrayPtrInfo(ParameterSyntax ps, ImmutableArray<AttributeData> attrDatas) : ParamInfo(ps)
	{
		const string attr = "Vanara.PInvoke.ArrayPointerAttribute";
		public INamedTypeSymbol ElementType { get; init; } = GetAttr(attr, attrDatas)?.ConstructorArguments.First().Value as INamedTypeSymbol
			?? throw new ArgumentException("ArrayPointerAttribute does not have a type as first parameter.");
		public string ElementCountVarName { get; init; } = GetAttr(attr, attrDatas)?.ConstructorArguments.Skip(1).First().Value as string
			?? throw new ArgumentException("ArrayPointerAttribute does not have a valid string as a second parameter.");
		public bool ElementsAreByRef { get; init; } = GetNamedArg(attr, attrDatas, "ElementsAreByRef") as bool? ?? false;
		public INamedTypeSymbol? Marshaler { get; init; } = GetNamedArg(attr, attrDatas, "Marshaler") as INamedTypeSymbol;
		public INamedTypeSymbol? MemMgr { get; init; } = GetNamedArg(attr, attrDatas, "MemoryManager") as INamedTypeSymbol;
		public string? FreeExpr { get; init; } = GetNamedArg(attr, attrDatas, "FreeStatement") as string;
		public ParameterSyntax CountParam { get; } = ps.FirstAncestorOrSelf<MethodDeclarationSyntax>()?.ParameterList.Parameters.FirstOrDefault(p => p.Identifier.Text == GetAttr(attr, attrDatas)?.ConstructorArguments.Skip(1).First().Value as string)
			?? throw new ArgumentException("ArrayPointerAttribute does not have a valid parameter name as a second parameter.");
	}

	private class MarshalAsInfo(ParameterSyntax ps, ImmutableArray<AttributeData> attrDatas) : ParamInfo(ps)
	{
		const string attr = "System.Runtime.InteropServices.MarshalAsAttribute";
		public UnmanagedType UnmanagedType { get; private set; } = GetAttr(attr, attrDatas)?.ConstructorArguments.First().Value is int ut ? (UnmanagedType)ut : 0;
		public int? IidParameterIndex { get; init; } = GetNamedArg(attr, attrDatas, "IidParameterIndex") as int?;
		public int? SizeConst { get; init; } = GetNamedArg(attr, attrDatas, "SizeConst") as int?;
		public short? SizeParamIndex { get; init; } = GetNamedArg(attr, attrDatas, "SizeParamIndex") as short?;
		public ParameterSyntax? RefParam { get; private set; }

		public static MarshalAsInfo? Validate(SyntaxNode node, ImmutableArray<AttributeData> attrDatas, MethodDeclarationSyntax methodDecl, out (string, string)? err)
		{
			if (node is not ParameterSyntax decl)
			{
				err = ("VANGEN001", "Somehow you didn't get a parameter for this syntax node.");
				return null;
			}

			MarshalAsInfo ret = new(decl, attrDatas);
			err = null;

			// Get the refindex from the attribute
			var refindex = -1;
			switch (ret.UnmanagedType)
			{
				case UnmanagedType.Interface:
					if (decl.Type?.ToString() is "object" or "object?")
					{
						ret.UnmanagedType = UnmanagedType.IUnknown;
						refindex = ret.IidParameterIndex ?? -1;
						break;
					}
					else if (decl.Type?.ToString()?.StartsWith("I") ?? false)
					{
						refindex = ret.IidParameterIndex ?? -1;
						break;
					}
					err = ("VANGEN021", "The parameter type is not System.Object or a named interface.");
					return null;

				case UnmanagedType.IUnknown:
					// Confirm param type is Nullable<object>
					if (decl.Type?.ToString() is not "object" and not "object?")
						return null;

					refindex = ret.IidParameterIndex ?? -1;
					break;

				case UnmanagedType.LPArray:
					refindex = ret.SizeParamIndex ?? -1;
					if (refindex == -1 || !decl.Type!.ToString().Contains("[]"))
						return null;
					break;

				default:
					return null;
			}

			// If there's an refindex, then make sure it points to a valid parameter
			if (refindex >= 0)
			{
				var refParam = methodDecl.ParameterList.Parameters[refindex];
				var paramType = refParam.Type?.ToString();
				// For interfaces, confirm param type is Guid
				if (ret.UnmanagedType is UnmanagedType.IUnknown or UnmanagedType.Interface)
				{
					var hasInModifier = refParam.Modifiers.Any(SyntaxKind.InKeyword);
					var hasStructAttribute = !hasInModifier && refParam.AttributeLists
						.SelectMany(al => al.Attributes)
						.Any(attr => attr.Name.ToFullString() == "MarshalAs" && attr.ArgumentList?.Arguments.FirstOrDefault()?.ToString() == "UnmanagedType.Struct");
					if ((paramType == "System.Guid" || paramType == "Guid") && (hasInModifier || hasStructAttribute))
					{
						ret.RefParam = refParam;
						return ret;
					}
				}
				// For LPArray, type is integral so pass along
				else if (ret.UnmanagedType == UnmanagedType.LPArray)
				{
					if (refParam.Modifiers.Any(SyntaxKind.RefKeyword) || refParam.Modifiers.Any(SyntaxKind.OutKeyword))
						return null;
					ret.RefParam = refParam;
					return ret;
				}
			}

			return null;
		}
	}

	private class SizeDefInfo(ParameterSyntax ps, ImmutableArray<AttributeData> attrDatas) : ParamInfo(ps)
	{
		const string attr = "Vanara.PInvoke.SizeDefAttribute";
		public string? RefVarName { get; init; } = GetAttr(attr, attrDatas)?.ConstructorArguments.First().Value?.ToString();
		public SizingMethod SizingMethod { get; init; } = GetAttr(attr, attrDatas)?.ConstructorArguments.ElementAtOrDefault(1).Value is int ism ? (SizingMethod)ism : SizingMethod.Count;
		public ArrayPtrInfo? ArrayPtr { get; init; } = GetAttr("Vanara.PInvoke.ArrayPointerAttribute", attrDatas) is null ? null : new ArrayPtrInfo(ps, attrDatas);
		public StructPtrInfo? StructPtr { get; init; } = GetAttr("Vanara.PInvoke.StructPointerAttribute", attrDatas) is null ? null : new StructPtrInfo(ps, attrDatas);
		public string? BufferVarName { get; init; } = GetNamedArg(attr, attrDatas, "BufferVarName") as string;
		public string? OutVarName { get; init; } = GetNamedArg(attr, attrDatas, "OutVarName") as string;
		public int InitSize { get; init; } = GetNamedArg(attr, attrDatas, "InitSize") is int initSize ? initSize : 0;

		public static SizeDefInfo? Validate(SyntaxNode node, ImmutableArray<AttributeData> attrDatas, MethodDeclarationSyntax methodDecl, out (string, string)? err)
		{
			if (node is not ParameterSyntax decl)
			{
				err = ("VANGEN001", "Somehow you didn't get a parameter for this syntax node.");
				return null;
			}

			SizeDefInfo ret = new(decl, attrDatas);

			// TODO: Implement Guess
			err = null;
			if ((ret.SizingMethod & (SizingMethod.Bytes | SizingMethod.InclNullTerm | SizingMethod.QueryResultInReturn | SizingMethod.CheckLastError)) != ret.SizingMethod)
				return null;

			// From 'syntaxNode', get the ParameterSyntax for the parameter referenced by the first string argument in the SizeDef attribute
			ret.SzValueExpr = ret.RefVarName;
			if (ret.RefVarName is not null && ret.RefVarName.Length > 0 && !char.IsDigit(ret.RefVarName[0]))
			{
				if (string.IsNullOrEmpty(ret.RefVarName) || (ret.SzParam = methodDecl.ParameterList.Parameters.FirstOrDefault(p => p.Identifier.Text == ret.RefVarName)) is null)
				{
					err = ("VANGEN023", "SizeDef attribute must have a valid parameter name as its first argument.");
					return null;
				}
				if (ret.OutVarName is string os && !string.IsNullOrEmpty(os))
				{
					if ((ret.OutSzParam = methodDecl.ParameterList.Parameters.FirstOrDefault(p => p.Identifier.Text == os)) is null)
					{
						err = ("VANGEN024", "SizeDef attribute must have a valid parameter name as its OutVarName named argument.");
						return null;
					}
					if (!ret.OutSzParam.Modifiers.Any(SyntaxKind.OutKeyword) && !ret.OutSzParam.Modifiers.Any(SyntaxKind.RefKeyword))
					{
						err = ("VANGEN025", "SizeDef attribute OutVarName parameter must be passed by ref or out.");
						return null;
					}
				}
				if (ret.BufferVarName is string bs && !string.IsNullOrEmpty(bs))
				{
					if ((ret.ByteSzParam = methodDecl.ParameterList.Parameters.FirstOrDefault(p => p.Identifier.Text == bs)) is null)
					{
						err = ("VANGEN030", "SizeDef attribute must have a valid parameter name as its BufferVarName named argument.");
						return null;
					}
					if (!ret.ByteSzParam.Modifiers.Any(SyntaxKind.OutKeyword) && !ret.ByteSzParam.Modifiers.Any(SyntaxKind.RefKeyword))
					{
						err = ("VANGEN031", "SizeDef attribute BufferVarName parameter must be passed by ref or out.");
						return null;
					}
				}

				AttributeSyntax rngAttr = ret.SzParam.AttributeLists.SelectMany(al => al.Attributes).FirstOrDefault(a => a.NameEquals("Range"));
				// If rngAttr is found, get its second constructor argument value as an int and use that as SzValueExpr
				if (rngAttr is not null && rngAttr.ArgumentList is not null && rngAttr.ArgumentList.Arguments.Count > 1)
				{
					ret.SzValueExpr = rngAttr.ArgumentList.Arguments[1].Expression.ToString();
				}
				// If rngAttr is not found, use the max value of the parameter type if it's an integral type
				else
				{
					long? tsz = ret.SzParam.Type?.ToString() switch
					{
						"byte" => byte.MaxValue,
						"sbyte" => sbyte.MaxValue,
						"short" => short.MaxValue,
						_ => ushort.MaxValue - 1,
					};
					if (tsz is null)
					{
						err = ("VANGEN026", "SizeDef attribute must have a Range attribute on its size parameter or the size parameter must be an integral type.");
						return null;
					}
					ret.SzValueExpr = tsz.ToString()!;
				}
			}

			// If a normal query, ensure szParam is by ref
			if (ret.SizingMethod.HasFlag(SizingMethod.Query))
			{
				bool qret = ret.SizingMethod.HasFlag(SizingMethod.QueryResultInReturn), qle = ret.SizingMethod.HasFlag(SizingMethod.CheckLastError);
				if (!qret && !qle && (ret.SzParam is null || !ret.SzParam.Modifiers.Any(SyntaxKind.RefKeyword) && ret.OutSzParam is null && ret.ByteSzParam is null))
				{
					err = ("VANGEN027", "SizeDef attribute with Query sizing method requires the referenced parameter to be passed by ref.");
					return null;
				}
				if (qret && (ret.SzParam is not null && (ret.SzParam.Modifiers.Any(SyntaxKind.RefKeyword) || ret.OutSzParam is not null)))
				{
					err = ("VANGEN028", "SizeDef attribute with QueryResultInReturn sizing method requires any referenced parameter to be passed by value and no OutVarName specified.");
					return null;
				}
			}
			return ret;
		}

		public ParameterSyntax? ByteSzParam { get; private set; }
		public ParameterSyntax? OutSzParam { get; private set; }
		public ParameterSyntax? SzParam { get; private set; }
		public string? SzValueExpr { get; set; }
	}

	private class StructPtrInfo(ParameterSyntax ps, ImmutableArray<AttributeData> attrDatas) : ParamInfo(ps)
	{
		const string attr = "Vanara.PInvoke.StructPointerAttribute";
		public INamedTypeSymbol StructType { get; init; } = GetAttr(attr, attrDatas)?.ConstructorArguments.First().Value as INamedTypeSymbol
			?? throw new ArgumentException("StructPointerAttribute does not have a type as first parameter.");
		public INamedTypeSymbol? Marshaler { get; init; } = GetNamedArg(attr, attrDatas, "Marshaler") as INamedTypeSymbol;
		public bool Marshal { get; init; } = GetAttr(attr, attrDatas)?.ConstructorArguments.Skip(1).FirstOrDefault().Value as bool? ?? true;
		public INamedTypeSymbol? MemMgr { get; init; } = GetNamedArg(attr, attrDatas, "MemoryManager") as INamedTypeSymbol;
		public string? FreeExpr { get; init; } = GetNamedArg(attr, attrDatas, "FreeStatement") as string;
	}
}