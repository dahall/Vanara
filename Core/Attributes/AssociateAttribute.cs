using System.Linq;
using System.Reflection;

namespace Vanara.PInvoke;

/// <summary>Associates a Guid with an element.</summary>
/// <seealso cref="Attribute"/>
/// <remarks>Initializes a new instance of the <see cref="PInvokeDataAttribute"/> class.</remarks>
/// <param name="guid">A GUID.</param>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Delegate | AttributeTargets.Enum | AttributeTargets.Event |
				AttributeTargets.Field | AttributeTargets.Interface | AttributeTargets.Method |
				AttributeTargets.Property | AttributeTargets.Struct, AllowMultiple = true, Inherited = false)]
public class AssociateAttribute(string guid) : Attribute
{

	/// <summary>Gets or sets the GUID associated with this element.</summary>
	/// <value>A GUID value.</value>
	public Guid Guid { get; } = new Guid(guid);

	/// <summary>Retrieves the Guid associated with an enum value.</summary>
	/// <typeparam name="T">An enum type.</typeparam>
	/// <param name="value">The enum value.</param>
	/// <returns>The GUID associated with the <paramref name="value"/> or <see cref="Guid.Empty"/> if no association exists.</returns>
	public static Guid GetGuidFromEnum<T>(T value) where T : Enum =>
		typeof(T).GetField(value.ToString())?.GetCustomAttributes<AssociateAttribute>().Select(a => a.Guid).FirstOrDefault() ?? Guid.Empty;

	/// <summary>Tries a lookup of the enum value associated with a Guid.</summary>
	/// <param name="guid">The unique identifier.</param>
	/// <param name="value">The found value.</param>
	/// <returns><c>true</c> if found.</returns>
	public static bool TryEnumLookup<T>(Guid guid, out T value) where T : struct, Enum
	{
		foreach (FieldInfo f in typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static))
		{
			if (f.GetCustomAttributes<AssociateAttribute>().All(a => a.Guid != guid))
				continue;
			value = (T)f.GetRawConstantValue()!;
			return true;
		}
		value = default;
		return false;
	}
}