namespace System.Diagnostics.CodeAnalysis;

#if !NET5_0_OR_GREATER && !NETCOREAPP3_1_OR_GREATER && !NETSTANDARD2_1_OR_GREATER
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

/// <summary>Specifies that an output may be <see langword="null"/> even if the corresponding type disallows it.</summary>
/// <remarks>For more information, see Nullable static analysis in the C# guide.</remarks>
public sealed class MaybeNullAttribute : Attribute
{
	/// <summary>Initializes a new instance of the <see cref="MaybeNullAttribute" /> class.</summary>
	public MaybeNullAttribute() { }
}

/// <summary>Specifies that when a method returns ReturnValue, the parameter may be null even if the corresponding type disallows it.</summary>
/// <remarks>For more information, see Nullable static analysis in the C# guide.</remarks>
/// <seealso cref="Attribute"/>
[AttributeUsage(AttributeTargets.Parameter, Inherited = false)]
public sealed class MaybeNullWhenAttribute : Attribute
{
	/// <summary>Initializes a new instance of the <see cref="MaybeNullWhenAttribute"/> class.</summary>
	/// <param name="returnValue">
	/// The return value condition. If the method returns this value, the associated parameter may be <see langword="null"/>.
	/// </param>
	public MaybeNullWhenAttribute(bool returnValue) => ReturnValue = returnValue;

	/// <summary>Gets the return value condition.</summary>
	/// <value>The return value condition. If the method returns this value, the associated parameter may be <see langword="null"/>.</value>
	public bool ReturnValue { get; }
}

/// <summary>
/// Specifies that an output may be null even if the corresponding type disallows it. Specifies that an input argument was not null when the
/// call returns.
/// </summary>
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.ReturnValue, Inherited = false)]
public sealed class NotNullAttribute : Attribute
{
	/// <summary>Initializes a new instance of the <see cref="NotNullAttribute" /> class.</summary>
	public NotNullAttribute() { }
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

#if !NET5_0_OR_GREATER
/// <summary>
/// Specifies the types of members that are dynamically accessed. This enumeration has a System.FlagsAttribute attribute that allows a
/// bitwise combination of its member values.
/// </summary>
[Flags]
public enum DynamicallyAccessedMemberTypes
{
	/// <summary>Specifies all members.</summary>
	All = -1,

	/// <summary>Specifies no members.</summary>
	None = 0,

	/// <summary>Specifies the default, parameterless public constructor.</summary>
	PublicParameterlessConstructor = 1,

	/// <summary>Specifies all public constructors.</summary>
	PublicConstructors = 3,

	/// <summary>Specifies all non-public constructors.</summary>
	NonPublicConstructors = 4,

	/// <summary>Specifies all public methods.</summary>
	PublicMethods = 8,

	/// <summary>Specifies all non-public methods.</summary>
	NonPublicMethods = 16,

	/// <summary>Specifies all public fields.</summary>
	PublicFields = 32,

	/// <summary>Specifies all non-public fields.</summary>
	NonPublicFields = 64,

	/// <summary>Specifies all public nested types.</summary>
	PublicNestedTypes = 128,

	/// <summary>Specifies all non-public nested types.</summary>
	NonPublicNestedTypes = 256,

	/// <summary>Specifies all public properties.</summary>
	PublicProperties = 512,

	/// <summary>Specifies all non-public properties.</summary>
	NonPublicProperties = 1024,

	/// <summary>Specifies all public events.</summary>
	PublicEvents = 2048,

	/// <summary>Specifies all non-public events.</summary>
	NonPublicEvents = 4096,

	/// <summary>Specifies all interfaces implemented by the type.</summary>
	Interfaces = 8192
}

/// <summary>
/// States a dependency that one member has on another.
/// </summary>
/// <remarks>
/// This can be used to inform tooling of a dependency that is otherwise not evident purely from
/// metadata and IL, for example a member relied on via reflection.
/// </remarks>
[AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Field | AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
public sealed class DynamicDependencyAttribute : Attribute
{
	/// <summary>
	/// Initializes a new instance of the <see cref="DynamicDependencyAttribute"/> class
	/// with the specified signature of a member on the same type as the consumer.
	/// </summary>
	/// <param name="memberSignature">The signature of the member depended on.</param>
	public DynamicDependencyAttribute(string memberSignature) => MemberSignature = memberSignature;

	/// <summary>
	/// Initializes a new instance of the <see cref="DynamicDependencyAttribute"/> class
	/// with the specified signature of a member on a <see cref="System.Type"/>.
	/// </summary>
	/// <param name="memberSignature">The signature of the member depended on.</param>
	/// <param name="type">The <see cref="System.Type"/> containing <paramref name="memberSignature"/>.</param>
	public DynamicDependencyAttribute(string memberSignature, Type type)
	{
		MemberSignature = memberSignature;
		Type = type;
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="DynamicDependencyAttribute"/> class
	/// with the specified signature of a member on a type in an assembly.
	/// </summary>
	/// <param name="memberSignature">The signature of the member depended on.</param>
	/// <param name="typeName">The full name of the type containing the specified member.</param>
	/// <param name="assemblyName">The assembly name of the type containing the specified member.</param>
	public DynamicDependencyAttribute(string memberSignature, string typeName, string assemblyName)
	{
		MemberSignature = memberSignature;
		TypeName = typeName;
		AssemblyName = assemblyName;
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="DynamicDependencyAttribute"/> class
	/// with the specified types of members on a <see cref="System.Type"/>.
	/// </summary>
	/// <param name="memberTypes">The types of members depended on.</param>
	/// <param name="type">The <see cref="System.Type"/> containing the specified members.</param>
	public DynamicDependencyAttribute(DynamicallyAccessedMemberTypes memberTypes, Type type)
	{
		MemberTypes = memberTypes;
		Type = type;
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="DynamicDependencyAttribute"/> class
	/// with the specified types of members on a type in an assembly.
	/// </summary>
	/// <param name="memberTypes">The types of members depended on.</param>
	/// <param name="typeName">The full name of the type containing the specified members.</param>
	/// <param name="assemblyName">The assembly name of the type containing the specified members.</param>
	public DynamicDependencyAttribute(DynamicallyAccessedMemberTypes memberTypes, string typeName, string assemblyName)
	{
		MemberTypes = memberTypes;
		TypeName = typeName;
		AssemblyName = assemblyName;
	}

	/// <summary>
	/// Gets the assembly name of the specified type.
	/// </summary>
	/// <remarks>
	/// <see cref="AssemblyName"/> is only valid when <see cref="TypeName"/> is specified.
	/// </remarks>
	public string? AssemblyName { get; }

	/// <summary>
	/// Gets or sets the condition in which the dependency is applicable, e.g. "DEBUG".
	/// </summary>
	public string? Condition { get; set; }

	/// <summary>
	/// Gets the signature of the member depended on.
	/// </summary>
	/// <remarks>
	/// Either <see cref="MemberSignature"/> must be a valid string or <see cref="MemberTypes"/>
	/// must not equal <see cref="DynamicallyAccessedMemberTypes.None"/>, but not both.
	/// </remarks>
	public string? MemberSignature { get; }

	/// <summary>
	/// Gets the <see cref="DynamicallyAccessedMemberTypes"/> which specifies the type
	/// of members depended on.
	/// </summary>
	/// <remarks>
	/// Either <see cref="MemberSignature"/> must be a valid string or <see cref="MemberTypes"/>
	/// must not equal <see cref="DynamicallyAccessedMemberTypes.None"/>, but not both.
	/// </remarks>
	public DynamicallyAccessedMemberTypes MemberTypes { get; }

	/// <summary>
	/// Gets the <see cref="System.Type"/> containing the specified member.
	/// </summary>
	/// <remarks>
	/// If neither <see cref="Type"/> nor <see cref="TypeName"/> are specified,
	/// the type of the consumer is assumed.
	/// </remarks>
	public Type? Type { get; }

	/// <summary>
	/// Gets the full name of the type containing the specified member.
	/// </summary>
	/// <remarks>
	/// If neither <see cref="Type"/> nor <see cref="TypeName"/> are specified,
	/// the type of the consumer is assumed.
	/// </remarks>
	public string? TypeName { get; }
}

/// <summary>
/// Specifies that the method or property will ensure that the listed field and property members have values that aren't <see langword="null"/>.
/// </summary>
/// <remarks>For more information, see Nullable static analysis in the C# guide.</remarks>
public sealed class MemberNotNullAttribute : Attribute
{
	/// <summary>Initializes the attribute with a field or property member.</summary>
	/// <param name="member">The field or property member that is promised to be not-null.</param>
	public MemberNotNullAttribute(string member) => Members = new[] { member };

	/// <summary>Initializes the attribute with the list of field and property members.</summary>
	/// <param name="members">The list of field and property members that are promised to be not-null.</param>
	public MemberNotNullAttribute(params string[] members) => Members = members;

	/// <summary>Gets field or property member names.</summary>
	public string[] Members { get; }
}
#endif