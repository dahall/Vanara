#if NET40_OR_GREATER || NETSTANDARD && !NET5_0_OR_GREATER
namespace System.Diagnostics.CodeAnalysis;

/// <summary>Specifies that null is allowed as an input even if the corresponding type disallows it.</summary>
/// <remarks>
/// To override a method that has a parameter annotated with this attribute, use the <c>?</c> operator. For example: <c>override
/// ISet&lt;Enum&gt; ReadJson(JsonReader reader, Type objectType, ISet&lt;Enum&gt;? existingValue, bool hasExistingValue, JsonSerializer
/// serializer)</c>. For more information, see Nullable static analysis in the C# guide.
/// </remarks>
/// <seealso cref="Attribute"/>
[AttributeUsage(AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Property, Inherited = false)]
public sealed class AllowNullAttribute : Attribute
{
	/// <summary>Initializes a new instance of the <see cref="AllowNullAttribute"/> class.</summary>
	public AllowNullAttribute() { }
}

/// <summary>Specifies that null is disallowed as an input even if the corresponding type allows it.</summary>
/// <remarks>For more information, see Nullable static analysis in the C# guide.</remarks>
/// <seealso cref="Attribute"/>
[AttributeUsage(AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.Property, Inherited = false)]
public sealed class DisallowNullAttribute : Attribute
{
	/// <summary>Initializes a new instance of the <see cref="DisallowNullAttribute"/> class.</summary>
	public DisallowNullAttribute() { }
}

/// <summary>Specifies that when a method returns ReturnValue, the parameter will not be null even if the corresponding type allows it.</summary>
/// <remarks>For more information, see Nullable static analysis in the C# guide.</remarks>
/// <seealso cref="Attribute"/>
[AttributeUsage(AttributeTargets.Parameter, Inherited = false)]
public sealed class NotNullWhenAttribute : Attribute
{
	/// <summary>Initializes a new instance of the <see cref="NotNullWhenAttribute"/> class.</summary>
	/// <param name="returnValue">
	/// The return value condition. If the method returns this value, the associated parameter will not be <see langword="null"/>.
	/// </param>
	public NotNullWhenAttribute(bool returnValue) => ReturnValue = returnValue;

	/// <summary>Gets the return value condition.</summary>
	/// <value>The return value condition. If the method returns this value, the associated parameter will not be <see langword="null"/>.</value>
	public bool ReturnValue { get; }
}
#endif