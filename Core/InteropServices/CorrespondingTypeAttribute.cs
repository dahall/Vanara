using System;
using System.Linq;
using Vanara.Extensions;
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global

namespace Vanara.InteropServices
{
	/// <summary>Actions that can be taken with a corresponding type.</summary>
	[Flags]
	public enum CorrepsondingAction
	{
		/// <summary>No actions may be taken.</summary>
		None = 0,
		/// <summary>The type can be retrieved.</summary>
		Get = 1,
		/// <summary>The type can be set.</summary>
		Set = 2,
		/// <summary>The type can be retrieved and set.</summary>
		GetSet = 3,
		/// <summary>Throw a <see cref="Exception"/> if this enumeration value is used.</summary>
		Exception = 4
	}

	/// <summary>
	/// Attribute for enum values that provides information about corresponding types and related actions. Useful for Get/Set methods that use an enumeration
	/// value to determine the type to get or set.
	/// </summary>
	/// <seealso cref="System.Attribute"/>
	[AttributeUsage(AttributeTargets.Field)]
	public class CorrespondingTypeAttribute : Attribute
	{
		/// <summary>Initializes a new instance of the <see cref="CorrespondingTypeAttribute"/> class.</summary>
		/// <param name="typeRef">The type that corresponds to this enumeration value.</param>
		/// <param name="action">The actions allowed for the type.</param>
		public CorrespondingTypeAttribute(Type typeRef, CorrepsondingAction action = CorrepsondingAction.Get | CorrepsondingAction.Set)
		{
			TypeRef = typeRef;
			Action = action;
		}

		/// <summary>Initializes a new instance of the <see cref="CorrespondingTypeAttribute"/> class.</summary>
		/// <param name="action">The actions allowed for the type.</param>
		public CorrespondingTypeAttribute(CorrepsondingAction action)
		{
			Action = action;
		}

		/// <summary>Gets the action allowed for the type.</summary>
		/// <value>The action allowed for the type.</value>
		public CorrepsondingAction Action { get; }

		/// <summary>Gets the type that corresponds to this enumeration value.</summary>
		/// <value>The type that corresponds to this enumeration value.</value>
		public Type TypeRef { get; }

		/// <summary>Determines whether this instance can get the type for the specified enum value.</summary>
		/// <param name="value">The enumeration value.</param>
		/// <param name="typeRef">The type supplied by the user to validate.</param>
		/// <returns><c>true</c> if this instance can get the specified type; otherwise, <c>false</c>.</returns>
		public static bool CanGet(object value, Type typeRef)
		{
			var attr = GetAttrForEnum(value);
			return attr.Action.IsFlagSet(CorrepsondingAction.Get) && attr.TypeRef == typeRef;
		}

		/// <summary>Determines whether this instance can set the type for the specified enum value.</summary>
		/// <param name="value">The enumeration value.</param>
		/// <param name="typeRef">The type supplied by the user to validate.</param>
		/// <returns><c>true</c> if this instance can set the specified type; otherwise, <c>false</c>.</returns>
		public static bool CanSet(object value, Type typeRef)
		{
			var attr = GetAttrForEnum(value);
			return attr.Action.IsFlagSet(CorrepsondingAction.Set) && attr.TypeRef == typeRef;
		}

		/// <summary>Gets the corresponding type for the supplied enumeration value.</summary>
		/// <param name="enumValue">The enumeration value.</param>
		/// <returns>The type defined by the attribute.</returns>
		public static Type GetCorrespondingType(object enumValue) => GetAttrForEnum(enumValue).TypeRef;

		private static CorrespondingTypeAttribute GetAttrForEnum(object value)
		{
			if (value == null) throw new ArgumentNullException(nameof(value));
			var valueType = value.GetType();
			if (!valueType.IsEnum) throw new ArgumentException("Value must be an enumeration value.", nameof(value));
			var attr = valueType.GetField(value.ToString()).GetCustomAttributes(typeof(CorrespondingTypeAttribute), false).Cast<CorrespondingTypeAttribute>().FirstOrDefault();
			if (attr == null) throw new InvalidOperationException("Value must have the CorrespondingTypeAttribute defined.");
			if (attr.Action == CorrepsondingAction.Exception) throw new Exception();
			return attr;
		}
	}
}