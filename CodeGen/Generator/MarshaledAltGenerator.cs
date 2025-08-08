//#define TEST
//#define DEBUGGING_SLN
using Microsoft.CodeAnalysis.CSharp;
using System.CodeDom.Compiler;
using System.Collections.Immutable;

namespace Vanara.Generators;

/// <summary>
/// Processes the <c>MarshaledAlternativeAttribute</c> attribute and creates a conversion constructor and operator to handle the alternative type.
/// </summary>
[Generator(LanguageNames.CSharp)]
public class MarshaledAlternativeGenerator : IIncrementalGenerator
{
	private const string attributeFullName = "Vanara.Marshaler.MarshaledAlternativeAttribute";

	/// <summary>Called to initialize the generator and register generation steps via callbacks on the <paramref name="context"/></summary>
	/// <param name="context">The context to register callbacks on</param>
	public void Initialize(IncrementalGeneratorInitializationContext context)
	{
		var decl = context.SyntaxProvider.ForAttributeWithMetadataName(attributeFullName, IsValidSyntax, (ctx, _) =>
			((StructDeclarationSyntax)ctx.TargetNode, ctx.Attributes.FirstOrDefault(a => a.AttributeClass?.ToDisplayString() == attributeFullName) ?? throw new InvalidOperationException("Attribute not found.")));
		var source = context.CompilationProvider.Combine(decl.Collect()).WithTrackingName("Syntax");
		context.RegisterSourceOutput(source, Execute);
	}

	private static bool IsValidSyntax(SyntaxNode syntaxNode, CancellationToken cancellationToken) =>
		syntaxNode is StructDeclarationSyntax ds && ds.IsPartial();

	private static void Execute(SourceProductionContext context, (Compilation compilation, ImmutableArray<(StructDeclarationSyntax, AttributeData)> classes) unit)
	{
		foreach ((StructDeclarationSyntax decl, AttributeData attr) in unit.classes)
		{
			var declModel = unit.compilation?.GetSemanticModel(decl.SyntaxTree);
			if (declModel?.GetDeclaredSymbol(decl) is not { } symbol) continue;

			// Check if the attribute has a single constructor argument of type Type
			if (attr.ConstructorArguments.FirstOrDefault().Value is INamedTypeSymbol altType)
			{
				// Validate that the alternate type is a valid type and has the MarshaledAttribute
				if (altType.GetAttributes().FirstOrDefault(a => a.AttributeClass?.ToDisplayString() == "Vanara.Marshaler.MarshaledAttribute") is not { } altAttr)
				{
					context.ReportError("VANGEN002", $"The alternate type '{altType.Name}' must have the MarshaledAttribute applied.");
					continue;
				}

				// Get the namespace
				string ns = symbol.ContainingNamespace?.ToDisplayString() ?? "BADNS";

				// Get the parent class stack
				Stack<ClassDeclarationSyntax> nestedClasses = new();
				ClassDeclarationSyntax? currentClass = decl.Parent as ClassDeclarationSyntax;
				while (currentClass != null)
				{
					nestedClasses.Push(currentClass);
					currentClass = currentClass.Parent as ClassDeclarationSyntax;
				}

				// Create the output string ==============
				using var outputString = new StringWriter();
				using var output = new IndentedTextWriter(outputString);

				// Output the nullable directive and the warning disable directive
				output.WriteLine("#nullable enable");
				output.WriteLine("#pragma warning disable CS1591");
				//if (methodDecl.GetLeadingTrivia().Where(t => t.IsKind(SyntaxKind.SingleLineDocumentationCommentTrivia)).Count() == 0)
				//	output.WriteLine("#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member");

				// Output the usings statements for the parentClass
				foreach (var u in decl.Ancestors().OfType<CompilationUnitSyntax>().First().Usings.Where(i => i.GlobalKeyword.Value is null))
					output.Write($"{u.ToFullString()}");

				// Output the namespace
				output.WriteLine($"namespace {ns} {{");
				output.Indent++;

				// Output nested classes
				StringBuilder stackName = new();
				var nestedClassCount = nestedClasses.Count;
				while (nestedClasses.Count > 0)
				{
					var nc = nestedClasses.Pop();
					stackName.Append(nc.Identifier.Text).Append('.');
					output.WriteLine($"{nc.Modifiers} class {nc.Identifier} {{");
					output.Indent++;
				}

				// Output the struct declaration
				output.WriteLine($"{decl.Modifiers} struct {decl.Identifier} {{");
				output.Indent++;

				// Output the constructor using the alternate type
				output.WriteLine($"public {decl.Identifier}(in {altType.Name} alt, out Vanara.InteropServices.ISafeMemoryHandle allocatedMem) {{");
				output.Indent++;
				output.WriteLine($"allocatedMem = Vanara.Marshaler.Marshaler.ValueToPtr(alt);");
				output.WriteLine($"this = allocatedMem.ToStructure<{decl.Identifier}>();");
				output.Indent--;
				output.WriteLine("}");

				output.WriteLine();

				// Output the conversion operator to the alternate type
				const string valueName = "value";
				output.WriteLine($"public static implicit operator {altType.Name}({decl.Identifier} {valueName}) {{");
				output.Indent++;
				output.WriteLine("unsafe {");
				output.Indent++;
				output.WriteLine("return new() {");
				output.Indent++;
				// Loop through the fields of the decl struct and output their value assignment from the corresponding field in the alternate type
				var altFields = altType.GetMembers().OfType<IFieldSymbol>().ToList();
				foreach (var field in symbol.GetMembers().OfType<IFieldSymbol>())
				{
					if (altFields?.FirstOrDefault(m => m.Name == field.Name) is not IFieldSymbol altField)
						continue;
					output.WriteLine($"{field.Name} = {GetConvValueStmt(valueName, field.Name, field, altField)},");
				}
				output.Indent--;
				output.WriteLine("};");
				output.Indent--;
				output.WriteLine("}");
				output.Indent--;
				output.WriteLine("}");

				output.Indent--;
				output.WriteLine("}");

				// Close the classes and namespace
				for (int i = 0; i < nestedClassCount; i++)
				{
					output.Indent--;
					output.WriteLine("}");
				}
				output.Indent--;
				output.Write('}');

				// Add the generated source to the context
				context.AddSource($"{stackName}{decl.Identifier.Text}.g.cs", outputString.ToString());
			}
			else
				context.ReportError("VANGEN001", "MarshaledAlternativeAttribute must have a constructor parameter with the alternate type.");
		}


		static string GetConvValueStmt(string valueName, string fieldName, IFieldSymbol fieldType, IFieldSymbol altFieldType)
		{
			// Handle struct pointers
			if (fieldType.Type.IsValueType && (fieldType.Type.Name.Contains("StructPointer")))
				return $"{valueName}.{fieldName}.Value";

			// Handle arrays
			if (altFieldType.GetAttributes().FirstOrDefault(a => a.AttributeClass?.ToDisplayString() == "Vanara.Marshaler.MarshalFieldAs.ArrayAttribute") is { } arrAttr &&
				altFieldType.Type is IArrayTypeSymbol arrType)
			{
				int al = (int?)arrAttr.ConstructorArguments.FirstOrDefault().Value ?? -1;
				if (al == 3 /*LPArray*/ && arrAttr.NamedArguments.FirstOrDefault(a => a.Key == "SizeFieldName").Value.Value is string sizeFieldName)
				{
					if (fieldType.Type.IsValueType && (fieldType.Type.Name.Contains("ArrayPointer")))
						return $"System.Array.ConvertAll({valueName}.{fieldName}.ToArray(System.Convert.ToInt32({valueName}.{sizeFieldName})), i => ({arrType.ElementType.Name})i)";
					if (fieldType.Type.IsValueType && fieldType.Type.Name is "IntPtr" or "nint")
						return $"{valueName}.{fieldName}.ToArray<{arrType.ElementType.Name}>(System.Convert.ToInt32({valueName}.{sizeFieldName}))";
				}
				else if (al == 7 /*LPArrayNullTerm*/)
				{
					return $"{valueName}.{fieldName}.ToArray(Vanara.Extensions.InteropExtensions.GetNulledArrayLength((System.IntPtr){valueName}.{fieldName}, typeof({arrType.ElementType.Name})))";
				}
			}

			// Handle strings
			if (altFieldType.Type is INamedTypeSymbol nType && nType.SpecialType == SpecialType.System_String)
				return $"{valueName}.{fieldName}.ToString()";

			// Handle unsafe pointers
			if (fieldType.Type is IPointerTypeSymbol pType)
			{
				if (altFieldType.Type.Name.Contains("StructPointer"))
					return $"(System.IntPtr){valueName}.{fieldName}";
				else
					return $"*{valueName}.{fieldName}";
			}

			// Handle other types
			return $"{valueName}.{fieldName}";
		}
	}
}