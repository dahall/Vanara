namespace Vanara.PInvoke;

/// <summary>Options to exclude certain features from generation.</summary>
[Flags]
public enum ExcludeOptions : uint
{
	/// <summary>Exclude public constructor.</summary>
	PublicCtor = 0x1,

	/// <summary>Exclude Value property.</summary>
	Value = 0x2,

	/// <summary>Exclude ISerializable attribute.</summary>
	Serializable = 0x4,

	/// <summary>Exclude conversion operators.</summary>
	Conversions = 0x8,

	/// <summary>Exclude numeric operators and conversions.</summary>
	Numerics = 0x10,

	/// <summary>Exclude Equals override.</summary>
	EqualsOverride = 0x20,

	/// <summary>Exclude GetHashCode implementation.</summary>
	Hash = 0x40 | EqualsOverride,

	/// <summary>Exclude <see cref="IEquatable{T}"/> implementation.</summary>
	Equatable = 0x80 | Numerics | EqualsOverride,

	/// <summary>Exclude <see cref="IComparable"/> implementation.</summary>
	Comparable = 0x100 | Numerics,

	/// <summary>Exclude <see cref="IConvertible"/> implementation.</summary>
	Convertible = 0x200 | Numerics,

	/// <summary>Exclude parsing methods.</summary>
	Parsable = 0x400 | Numerics,

	/// <summary>Exclude ToString overrides.</summary>
	ToString = 0x800,
}

/// <summary>An attribute that can be applied to a partial struct to generate a body that mimics <paramref name="typeRef"/>.</summary>
/// <seealso cref="Attribute"/>
[AttributeUsage(AttributeTargets.Struct, Inherited = false, AllowMultiple = false)]
public sealed class TypeDefAttribute(Type typeRef) : Attribute
{
	/// <summary>Gets the base type reference.</summary>
	/// <value>The base type reference.</value>
	public Type TypeRef { get; } = typeRef;

	/// <summary>Gets or sets a type that is the exposed type.</summary>
	public Type? ConvertTo { get; set; } = null;

	/// <summary>Gets or sets a string containing a set of options to exclude certain features from generation.</summary>
	/// <value>A string containing a set of options to exclude certain features from generation.</value>
	public ExcludeOptions Excludes { get; set; } = 0;

	/// <summary>Gets the code to convert from the base type (TypeRef) to the exposed type (ConverTo) using 'value' to represent the base type variable name.</summary>
	/// <remarks>By default, the base type will use IConverible to change to the exposed type.</remarks>
	public string? GetConvValue { get; set; } = null;

	/// <summary>Gets the code to convert from the exposed type (ConvertTo) to the base type (TypeRef) using 'value' to represent the exposed type variable name.</summary>
	/// <remarks>By default, the exposed type will use IConverible to change to the base type.</remarks>
	public string? SetConvValue { get; set; } = null;
}
