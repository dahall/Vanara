using System;
using System.Linq;
using System.Reflection;

namespace Vanara.PInvoke
{
	/// <summary>Associates a Guid with an element.</summary>
	/// <seealso cref="Attribute"/>
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Delegate | AttributeTargets.Enum | AttributeTargets.Event |
					AttributeTargets.Field | AttributeTargets.Interface | AttributeTargets.Method |
					AttributeTargets.Property | AttributeTargets.Struct, AllowMultiple = true, Inherited = false)]
	public class AssociateAttribute : Attribute
	{
		/// <summary>Initializes a new instance of the <see cref="PInvokeDataAttribute"/> class.</summary>
		/// <param name="guid">A GUID.</param>
		public AssociateAttribute(string guid)
		{
			Guid = new Guid(guid);
		}

		/// <summary>Gets or sets the GUID associated with this element.</summary>
		/// <value>A GUID value.</value>
		public Guid Guid { get; }

		/// <summary>Retrieves the Guid associated with an enum value.</summary>
		/// <typeparam name="T">An enum type.</typeparam>
		/// <param name="value">The enum value.</param>
		/// <returns>The GUID.</returns>
		public static Guid GetGuidFromEnum<T>(T value)
		{
			var attr = typeof(T).GetField(value.ToString()).GetCustomAttributes(typeof(AssociateAttribute), false);
			return attr.Length > 0 ? ((AssociateAttribute) attr[0]).Guid : Guid.Empty;
		}

		/// <summary>Tries a lookup of the enum value associated with a Guid.</summary>
		/// <param name="guid">The unique identifier.</param>
		/// <param name="value">The found value.</param>
		/// <returns><c>true</c> if found.</returns>
		public static bool TryEnumLookup<T>(Guid guid, out T value)
		{
			foreach (var f in typeof(T).GetFields(BindingFlags.Public | BindingFlags.Static))
			{
				if (f.GetCustomAttributes(typeof(AssociateAttribute), false).Cast<AssociateAttribute>().All(a => a.Guid != guid))
					continue;
				value = (T)f.GetRawConstantValue();
				return true;
			}
			value = default(T);
			return false;
		}
	}
}