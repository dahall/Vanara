namespace Vanara.PInvoke;

/// <summary>
/// <note type="implement">This attribute does not yet have an implemented generator.</note>
/// An attribute to indicate that the method of the attributed parameter should be added as a constructor of the class or structure of the type
/// being annotated. The type must be <c>partial</c> and either a structure or class.
/// </summary>
[AttributeUsage(AttributeTargets.Parameter | AttributeTargets.ReturnValue, Inherited = false, AllowMultiple = false)]
public sealed class AddAsCtorAttribute : Attribute
{
}

/// <summary>
/// <note type="implement">This attribute does not yet have an implemented generator.</note>
/// An attribute to indicate that the method of the attributed parameter should be added as a member of the class or structure of the type
/// being annotated. The type must be <c>partial</c> and either a structure or class.
/// </summary>
/// <remarks>
/// <para>
/// This attribute indicates that the enclosing method can be added to the type of the attributed parameter. This is helpful when exposing
/// member methods of handles and safe handles. For example, <c>HEVENT</c> has a number of supporting functions like <c>bool SetEvent([In]
/// HEVENT hEvent)</c>. Placing this attribute on the <c>bool SetEvent([In, AddAsMember] HEVENT hEvent)</c> parameter will then add <c>bool
/// SetEvent()</c> to the HEVENT structure.
/// </para>
/// <para>
/// If there are supporting classes, like SafeEventHandle for HEVENT, then you can use the alternate parameter of the attribute to indicate
/// that class name that should also receive the method (e.g., <c>bool SetEvent([In, AddAsMember(typeof(SafeEventHandle))] HEVENT hEvent)</c>).
/// </para>
/// </remarks>
[AttributeUsage(AttributeTargets.Parameter, Inherited = false, AllowMultiple = false)]
public sealed class AddAsMemberAttribute : Attribute
{
}

/// <summary>
/// <note type="implement">This attribute does not yet have an implemented generator.</note>
/// <para>
/// Applying this attribute to a class or structure will used the supplied regex pattern to replace portions of the auto-generated method names.
/// </para>
/// </summary>
/// <param name="regexMatchPatterns">A sequence of tuples containing the regex pattern to match and the replacement string to use for auto-generated method names.</param>
[AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
public sealed class AdjustAutoMethodNamePatternAttribute(params (string pattern, string replacement)[] regexMatchPatterns) : Attribute
{
	/// <summary>
	/// Initializes a new instance of the <see cref="AdjustAutoMethodNamePatternAttribute"/> class with a regex pattern that will remove all
	/// matches from auto methods.
	/// </summary>
	/// <param name="removePattern">The pattern that removes matching values.</param>
	public AdjustAutoMethodNamePatternAttribute(string removePattern) : this((removePattern, string.Empty))
	{
	}

	/// <summary>
	/// A sequence of tuples containing the regex pattern to match and the replacement string to use for auto-generated method names.
	/// </summary>
	public (string pattern, string replacement)[] RegexMatchPatterns { get; } = regexMatchPatterns;
}

/// <summary>
/// <note type="implement">This attribute does not yet have an implemented generator.</note>
/// <para>Applying this attribute to a class or structure will defer the auto-generated methods to the specified type.</para>
/// </summary>
/// <param name="deferredType">
/// The type of the partial class or structure that will host the auto methods. This type must provide an implicit conversion operator to the
/// type associated with this attribute.
/// </param>
[AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public sealed class DeferAutoMethodToAttribute(Type deferredType) : Attribute
{
	/// <summary>The type of the partial class or structure that will host the auto methods.</summary>
	public Type DeferredType { get; } = deferredType ?? throw new ArgumentNullException(nameof(deferredType), "Deferred type cannot be null.");
}