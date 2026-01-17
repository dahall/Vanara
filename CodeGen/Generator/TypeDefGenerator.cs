using System.Collections.Immutable;

namespace Vanara.Generators;

/// <summary>Generates a partial structure that mimics an intrinsic base type, similar to C++ 'typedef'.</summary>
[Generator(LanguageNames.CSharp)]
public class TypeDefGenerator : IIncrementalGenerator
{
	private const string attributeFullName = "Vanara.PInvoke.TypeDefAttribute";

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
			string baseType = attr.ConstructorArguments.ElementAtOrDefault(0).Value?.ToString() ?? "";
			ExcludeOptions exclOps = (ExcludeOptions)((uint?)attr.NamedArguments.ElementAtOrDefault(0).Value.Value ?? 0U);

			string model = GetModel(ns, symbol.Name, baseType, exclOps);
			context.AddSource($"{symbol.Name}.g.cs", SourceText.From(model, Encoding.UTF8));
		}

		// Add extra classes if needed
		if (unit.structs.Length > 0)
			context.AddSource($"TypeDefSupportingClasses.g.cs", SourceText.From(extraClasses, Encoding.UTF8));
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

	private static string GetModel(string ns, string typeName, string baseType, ExcludeOptions excludeSet)
	{
		// Process excludes
		var sections = new Dictionary<IncludeOptions, (bool ireq7, string[] inf, string[] us)>
		{
			[IncludeOptions.Comparable] = (false, ["IComparable", $"IComparable<{typeName}>"], []),
			[IncludeOptions.Conversions] = (false, [], ["System.Globalization"]),
			[IncludeOptions.Convertible] = (false, ["IConvertible"], []),
			[IncludeOptions.PublicCtor] = (false, [], []),
			[IncludeOptions.EqualsOverride] = (false, [], []),
			[IncludeOptions.Equatable] = (false, [$"IEquatable<{typeName}>", $"IEquatable<{baseType}>"], []),
			[IncludeOptions.Hash] = (false, [], []),
			[IncludeOptions.Numerics] = (true, [$"IBinaryInteger<{typeName}>", $"IUnsignedNumber<{typeName}>"], ["System.Numerics"]),
			[IncludeOptions.Parsable] = (true, [$"IParsable<{typeName}>", $"ISpanParsable<{typeName}>"], ["System.Globalization"]),
			[IncludeOptions.Serializable] = (false, ["ISerializable"], ["System.Runtime.Serialization"]),
			[IncludeOptions.ToString] = (false, [], []),
			[IncludeOptions.Value] = (false, [], []),
		};
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
			if (interfaces.Length > 0)
				itflist.Append(", ");
			itflist.AppendLine();
			itflist.AppendLine("#if NET7_0_OR_GREATER");
			itflist.AppendLine('\t' + string.Join(", ", req7interfaces));
			itflist.Append("#endif");
		}

		var ctorAcc = includeSet.IsFlagSet(IncludeOptions.PublicCtor) ? "public" : "internal";

		// Load and process template
		StringBuilder template = new(Util.ReadAllTextFromAsmResource("Vanara.Generators.TypeDefTemplate.cs"));
		template.Replace("__NAMESPACE__", ns);
		template.Replace("__TYPENAME__", typeName);
		template.Replace("__BASETYPE__", baseType);
		template.Replace("__INTERFACES__", itflist.ToString());
		template.Replace("__USINGS__\r\n", usingsText);
		template.Replace("__CTORACC__", ctorAcc);
		foreach(var f in excludeSet.GetFlags()) RemoveSection(template, f.ToString());
		foreach(var f in includeSet.GetFlags()) RemoveSectionMarkers(template, f.ToString());
		if (typeName is "System.IntPtr" or "System.UIntPtr" or "nint" or "nuint")
		{
			RemoveSection(template, "NONPTR");
			RemoveSectionMarkers(template, "PTR");
		}
		else
		{
			RemoveSection(template, "PTR");
			RemoveSectionMarkers(template, "NONPTR");
		}
		return template.ToString();

		static void RemoveSection(StringBuilder template, string section)
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

		static void RemoveSectionMarkers(StringBuilder template, string section)
		{
			template.Replace($"##{section.ToUpper()}\r\n", "");
			template.Replace($"%%{section.ToUpper()}\r\n", "");
		}
	}

	const string extraClasses = """
		#if NET7_0_OR_GREATER
		#nullable enable
		using System.Diagnostics.CodeAnalysis;
		using System.Numerics;
		namespace Vanara.PInvoke;
		static class NumberBaseAccessor<T> where T : INumberBase<T>, IMinMaxValue<T>
		{
			public static T AdditiveIdentity => T.AdditiveIdentity;
			public static T MultiplicativeIdentity => T.MultiplicativeIdentity;
			public static T One => T.One;
			public static int Radix => T.Radix;
			public static T Zero => T.Zero;
			public static T MaxValue => T.MinValue;
			public static T MinValue => T.MinValue;
			public static T Negate(T value) => Zero - value;
			public static T Abs(T value) => T.Abs(value);
			public static bool IsCanonical(T value) => T.IsCanonical(value);
			public static bool IsComplexNumber(T value) => T.IsComplexNumber(value);
			public static bool IsEvenInteger(T value) => T.IsEvenInteger(value);
			public static bool IsFinite(T value) => T.IsFinite(value);
			public static bool IsImaginaryNumber(T value) => T.IsImaginaryNumber(value);
			public static bool IsInfinity(T value) => T.IsInfinity(value);
			public static bool IsInteger(T value) => T.IsInteger(value);
			public static bool IsNaN(T value) => T.IsNaN(value);
			public static bool IsNegative(T value) => T.IsNegative(value);
			public static bool IsNegativeInfinity(T value) => T.IsNegativeInfinity(value);
			public static bool IsNormal(T value) => T.IsNormal(value);
			public static bool IsOddInteger(T value) => T.IsOddInteger(value);
			public static bool IsPositive(T value) => T.IsPositive(value);
			public static bool IsPositiveInfinity(T value) => T.IsPositiveInfinity(value);
			public static bool IsRealNumber(T value) => T.IsRealNumber(value);
			public static bool IsSubnormal(T value) => T.IsSubnormal(value);
			public static bool IsZero(T value) => T.IsZero(value);
			public static T MaxMagnitude(T x, T y) => T.MaxMagnitude(x, y);
			public static T MaxMagnitudeNumber(T x, T y) => T.MaxMagnitudeNumber(x, y);
			public static T MinMagnitude(T x, T y) => T.MinMagnitude(x, y);
			public static T MinMagnitudeNumber(T x, T y) => T.MinMagnitudeNumber(x, y);
			public static bool TryConvertFromChecked<TOther>(TOther value, out T result) => TryStaticCall("TryConvertFromChecked", value, out result!);
			public static bool TryConvertFromSaturating<TOther>(TOther value, out T result) => TryStaticCall("TryConvertFromSaturating", value, out result!);
			public static bool TryConvertFromTruncating<TOther>(TOther value, out T result) => TryStaticCall("TryConvertFromTruncating", value, out result!);
			public static bool TryConvertToChecked<TOther>(T value, [MaybeNullWhen(false)] out TOther result) => TryStaticCall("TryConvertToChecked", value, out result);
			public static bool TryConvertToSaturating<TOther>(T value, [MaybeNullWhen(false)] out TOther result) => TryStaticCall("TryConvertToSaturating", value, out result);
			public static bool TryConvertToTruncating<TOther>(T value, [MaybeNullWhen(false)] out TOther result) => TryStaticCall("TryConvertToTruncating", value, out result);
			static bool TryStaticCall<TOther, TOut>(string fName, TOther value, [MaybeNullWhen(false)] out TOut result)
			{
				try
				{
					object?[] args = [value, null];
					var ret = typeof(T).InvokeStaticMethod<bool>(fName, args);
					result = (TOut)args[1]!;
					return ret;
				}
				catch { result = default!; return false; }
			}
		}
		static class BinaryIntegerAccessor<T> where T : IBinaryInteger<T>
		{
			public static bool IsPow2(T value) => T.IsPow2(value);
			public static T Log2(T value) => T.Log2(value);
			public static T PopCount(T value) => T.PopCount(value);
			public static T TrailingZeroCount(T value) => T.TrailingZeroCount(value);
			public static bool TryReadBigEndian(ReadOnlySpan<byte> source, bool isUnsigned, out T value) => T.TryReadBigEndian(source, isUnsigned, out value);
			public static bool TryReadLittleEndian(ReadOnlySpan<byte> source, bool isUnsigned, out T value) => T.TryReadLittleEndian(source, isUnsigned, out value);
			public static int GetByteCount(T value) => ((IBinaryInteger<T>)value).GetByteCount();
			public static int GetShortestBitLength(T value) => ((IBinaryInteger<T>)value).GetShortestBitLength();
			public static bool TryWriteBigEndian(T value, Span<byte> destination, out int bytesWritten) => ((IBinaryInteger<T>)value).TryWriteBigEndian(destination, out bytesWritten);
			public static bool TryWriteLittleEndian(T value, Span<byte> destination, out int bytesWritten) => value.TryWriteLittleEndian(destination, out bytesWritten);
		}
		#endif
		""";
}