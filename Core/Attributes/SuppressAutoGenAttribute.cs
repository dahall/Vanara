namespace Vanara.PInvoke;

/// <summary>An attribute that can be applied to a code element to suppress the automatic generation of P/Invoke methods for that element.</summary>
/// <seealso cref="System.Attribute"/>
[AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = false)]
public sealed class SuppressAutoGenAttribute : Attribute
{
}
