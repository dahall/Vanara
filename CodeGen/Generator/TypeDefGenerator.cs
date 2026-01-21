using System.Collections.Immutable;
using System.ComponentModel;
using System.Globalization;

namespace Vanara.Generators;

/// <summary>Generates a partial structure that mimics an intrinsic base type, similar to C++ 'typedef'.</summary>
[Generator(LanguageNames.CSharp)]
public class TypeDefGenerator : IIncrementalGenerator
{
	private const string attributeFullName = "Vanara.PInvoke.TypeDefAttribute";

	private static Type? GetConvForAlias(string typeName) => typeName switch
	{
		"bool" => typeof(BooleanConverter),
		"byte" => typeof(ByteConverter),
		"sbyte" => typeof(SByteConverter),
		"char" => typeof(CharConverter),
		"decimal" => typeof(DecimalConverter),
		"double" => typeof(DoubleConverter),
		"float" => typeof(SingleConverter),
		"int" => typeof(Int32Converter),
		"uint" => typeof(UInt32Converter),
		"long" or "nint" => typeof(Int64Converter),
		"ulong" or "nuint" => typeof(UInt64Converter),
		"short" => typeof(Int16Converter),
		"ushort" => typeof(UInt16Converter),
		"string" => typeof(StringConverter),
		_ => Type.GetType(typeName, false) is Type t ? TypeDescriptor.GetConverter(t).GetType() : null,
	};

	/// <summary>Called to initialize the generator and register generation steps via callbacks on the <paramref name="context"/></summary>
	/// <param name="context">The <see cref="IncrementalGeneratorInitializationContext"/> on which to register callbacks</param>
	public void Initialize(IncrementalGeneratorInitializationContext context)
	{
		var decl = context.SyntaxProvider.ForAttributeWithMetadataName(attributeFullName, IsValidSyntax,
			(ctx, _) =>
				((StructDeclarationSyntax)ctx.TargetNode, ctx.Attributes.FirstOrDefault(a => a.AttributeClass?.ToDisplayString() == attributeFullName) ?? throw new InvalidOperationException("Attribute not found.")));
		var source = context.CompilationProvider.Combine(decl.Collect()).WithTrackingName("Syntax");
		context.RegisterSourceOutput(source, Execute);
	}

	private static bool IsValidSyntax(SyntaxNode syntaxNode, CancellationToken cancellationToken) =>
		syntaxNode is StructDeclarationSyntax ds && ds.IsPartial();

	private static void Execute(SourceProductionContext context, (Compilation compilation, ImmutableArray<(StructDeclarationSyntax, AttributeData)> structs) unit)
	{
		foreach ((StructDeclarationSyntax decl, AttributeData attr) in unit.structs)
		{
			var semanticModel = unit.compilation.GetSemanticModel(decl.SyntaxTree);
			if (semanticModel.GetDeclaredSymbol(decl) is not { } symbol) continue;
			var ns = symbol.ContainingNamespace.ToString();
			INamedTypeSymbol baseType = attr.ConstructorArguments.ElementAtOrDefault(0).Value as INamedTypeSymbol ?? throw new InvalidOperationException("Base type not found.");
			ExcludeOptions exclOps = (ExcludeOptions)((uint?)attr.NamedArguments.FirstOrDefault(na => na.Key == "Excludes").Value.Value ?? 0U);
			INamedTypeSymbol? convType = attr.NamedArguments.FirstOrDefault(na => na.Key == "ConvertTo").Value.Value as INamedTypeSymbol;
			string? getConvValue = attr.NamedArguments.FirstOrDefault(na => na.Key == "GetConvValue").Value.Value as string;
			string? setConvValue = attr.NamedArguments.FirstOrDefault(na => na.Key == "SetConvValue").Value.Value as string;

			string model = GetModel(ns, symbol.Name, baseType, exclOps, convType, getConvValue, setConvValue);
			context.AddSource($"{symbol.Name}.g.cs", SourceText.From(model, Encoding.UTF8));
		}

		// Add extra classes if needed
		if (unit.structs.Length > 0)
			context.AddSource($"TypeDefSupportingClasses.g.cs", SourceText.From(Util.ReadAllTextFromAsmResource("Vanara.Generators.TypeDefSupportingTemplate.cs"), Encoding.UTF8));
	}

	[Flags]
	private enum ExcludeOptions : uint
	{
		PublicCtor = 0x1,
		Value = 0x2,
		Serializable = 0x4,
		Conversions = 0x8,
		Numerics = 0x10,
		EqualsOverride = 0x20,
		Hash = 0x40 | EqualsOverride,
		Equatable = 0x80 | Numerics | EqualsOverride,
		Comparable = 0x100 | Numerics,
		Convertible = 0x200 | Numerics,
		Parsable = 0x400 | Numerics,
		ToString = 0x800,
	}

	[Flags]
	private enum IncludeOptions : uint
	{
		PublicCtor = 0x1,
		Value = 0x2,
		Serializable = 0x4,
		Conversions = 0x8,
		Numerics = 0x10,
		EqualsOverride = 0x20,
		Hash = 0x40,
		Equatable = 0x80,
		Comparable = 0x100,
		Convertible = 0x200,
		Parsable = 0x400,
		ToString = 0x800,
	}

	private static string GetModel(string ns, string typeName, INamedTypeSymbol baseTypeSymbol, ExcludeOptions excludeSet, INamedTypeSymbol? convTypeSymbol, string? getConvValue, string? setConvValue)
	{
		bool noConv = convTypeSymbol is null || convTypeSymbol.Name == "Void";
		if (noConv)
			convTypeSymbol = baseTypeSymbol;
		bool ifmt = convTypeSymbol!.ImplementsInterface("System.IFormattable");
		bool ispanfmt = convTypeSymbol!.ImplementsInterface("System.ISpanFormattable");
		var ptr = baseTypeSymbol.Name is "IntPtr" or "UIntPtr";
		bool num = IsNumber(convTypeSymbol!.Name);
		var baseType = baseTypeSymbol.ToString();
		var convType = convTypeSymbol!.ToString();
		getConvValue ??= $"({convType})Convert.ChangeType(value, typeof({convType}))";
		setConvValue ??= $"({baseType})Convert.ChangeType(value, typeof({baseType}))";

		// Process excludes
		var sections = new Dictionary<IncludeOptions, (bool ireq7, List<string> inf, string[] us)>
		{
			[IncludeOptions.Comparable] = (false, ["IComparable", $"IComparable<{typeName}>"], []),
			[IncludeOptions.Conversions] = (false, [], ["System.Globalization"]),
			[IncludeOptions.Convertible] = (false, ["IConvertible"], []),
			[IncludeOptions.PublicCtor] = (false, [], []),
			[IncludeOptions.EqualsOverride] = (false, [], []),
			[IncludeOptions.Equatable] = (false, [$"IEquatable<{typeName}>", $"IEquatable<{convType}>"], []),
			[IncludeOptions.Hash] = (false, [], []),
			[IncludeOptions.Numerics] = (true, [$"IBinaryInteger<{typeName}>", $"IUnsignedNumber<{typeName}>"], ["System.Numerics"]),
			[IncludeOptions.Parsable] = (true, [$"IParsable<{typeName}>", $"ISpanParsable<{typeName}>"], ["System.Globalization"]),
			[IncludeOptions.Serializable] = (false, ["ISerializable"], ["System.Runtime.Serialization"]),
			[IncludeOptions.ToString] = (false, [], []),
			[IncludeOptions.Value] = (false, [], []),
		};
		if (!noConv) sections[IncludeOptions.Equatable].inf.Add($"IEquatable<{baseType}>");
		// Invert excludes to includes
		IncludeOptions includeSet = (IncludeOptions)~excludeSet;

		// Process using and interfaces
		string[] usings = [.. sections.Where(s => includeSet.IsFlagSet(s.Key)).SelectMany(s => s.Value.us).Distinct()];
		string usingsText = usings.Length > 0 ? "using " + string.Join(";\r\nusing ", usings) + ";\r\n" : "";

		string[] interfaces = [.. sections.Where(s => includeSet.IsFlagSet(s.Key) && !s.Value.ireq7).SelectMany(s => s.Value.inf).Distinct()];
		string[] req7interfaces = [.. sections.Where(s => includeSet.IsFlagSet(s.Key) && s.Value.ireq7).SelectMany(s => s.Value.inf).Distinct()];
		StringBuilder itflist = new();
		if (interfaces.Length > 0 || req7interfaces.Length > 0)
			itflist.Append(" : ");
		itflist.Append(string.Join(", ", interfaces));
		if (req7interfaces.Length > 0)
		{
			itflist.AppendLine();
			itflist.AppendLine("#if NET7_0_OR_GREATER");
			itflist.AppendLine('\t' + (interfaces.Length > 0 ? ", " : "") + string.Join(", ", req7interfaces));
			itflist.Append("#endif");
		}

		var ctorAcc = includeSet.IsFlagSet(IncludeOptions.PublicCtor) ? "public" : "internal";
		var valueAcc = includeSet.IsFlagSet(IncludeOptions.Value) ? "public" : "internal";

		// Load and process template
		StringBuilder template = new(Util.ReadAllTextFromAsmResource("Vanara.Generators.TypeDefTemplate.cs"));
		PickSection("CONVTYPE", !noConv);
		PickSection("PTR", ptr);
		PickSection("IFMT", ifmt);
		PickSection("ISPANFMT", ispanfmt);
		PickSection("ISNUM", ifmt);
		if (ptr)
			template.Replace("((IConvertible)value)", baseType is "nint" ? "((IConvertible)((IntPtr)value).ToInt64())" : "((IConvertible)((UIntPtr)value).ToUInt64())");
		foreach (var f in excludeSet.GetFlags()) RemoveSection(f.ToString());
		foreach(var f in includeSet.GetFlags()) RemoveSectionMarkers(f.ToString());
		template.Replace("__NAMESPACE__", ns);
		template.Replace("__INTERFACES__", itflist.ToString());
		template.Replace("__USINGS__\r\n", usingsText);
		template.Replace("__TYPENAME__", typeName);
		template.Replace("__CONVTYPE__", convType);
		var converterType = GetConvForAlias(convType!) ?? throw new InvalidOperationException($"No TypeConverter found for type '{convType}'.");
		template.Replace("__CONVTYPEFULL__", converterType.FullName);
		template.Replace("__BASETYPE__", baseType);
		template.Replace("__CTORACC__", ctorAcc);
		template.Replace("__VALUEACC__", valueAcc);
		template.Replace("__GETCONVVALUE__", getConvValue);
		template.Replace("__SETCONVVALUE__", setConvValue);
		return template.ToString();

		void RemoveSection(string section)
		{
			var startTag = $"##{section.ToUpper()}";
			var endTag = $"%%{section.ToUpper()}\r\n";

			int startIdx;
			while ((startIdx = template.ToString().IndexOf(startTag)) != -1)
			{
				int endIdx = template.ToString().IndexOf(endTag, startIdx);
				if (endIdx == -1) break;
				template.Remove(startIdx, endIdx + endTag.Length - startIdx);
			}
		}

		void RemoveSectionMarkers(string section) => 
			template.Replace($"##{section.ToUpper()}\r\n", "").Replace($"%%{section.ToUpper()}\r\n", "");

		void PickSection(string section, bool pick)
		{
			RemoveSection((pick ? "!" : "") + section);
			RemoveSectionMarkers((pick ? "" : "!") + section);
		}

		static bool IsNumber(string typeName) =>
			typeName is "Byte" or "SByte" or "Int16" or "UInt16" or "Int32" or "UInt32" or "Int64" or "UInt64" or "Single" or "Double" or "Decimal" or "IntPtr" or "UIntPtr";
	}
}