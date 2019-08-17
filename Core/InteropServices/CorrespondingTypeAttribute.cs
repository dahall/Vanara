using System;
using System.Collections.Generic;
using System.Linq;
using Vanara.Extensions;

// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable UnusedMember.Global

namespace Vanara.InteropServices
{
	/// <summary>Actions that can be taken with a corresponding type.</summary>
	[Flags]
	public enum CorrespondingAction
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
	/// Attribute for enum values that provides information about corresponding types and related actions. Useful for Get/Set methods that
	/// use an enumeration value to determine the type to get or set.
	/// </summary>
	/// <seealso cref="System.Attribute"/>
	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Class, AllowMultiple = true)]
	public class CorrespondingTypeAttribute : Attribute
	{
		/// <summary>Initializes a new instance of the <see cref="CorrespondingTypeAttribute"/> class.</summary>
		/// <param name="typeRef">The type that corresponds to this enumeration value.</param>
		/// <param name="action">The actions allowed for the type.</param>
		public CorrespondingTypeAttribute(Type typeRef, CorrespondingAction action = CorrespondingAction.GetSet)
		{
			TypeRef = typeRef;
			Action = action;
		}

		/// <summary>Initializes a new instance of the <see cref="CorrespondingTypeAttribute"/> class.</summary>
		/// <param name="action">The actions allowed for the type.</param>
		public CorrespondingTypeAttribute(CorrespondingAction action) => Action = action;

		/// <summary>Gets the action allowed for the type.</summary>
		/// <value>The action allowed for the type.</value>
		public CorrespondingAction Action { get; }

		/// <summary>Gets the type that corresponds to this enumeration value.</summary>
		/// <value>The type that corresponds to this enumeration value.</value>
		public Type TypeRef { get; }

		/// <summary>Determines whether this instance can get the type for the specified enum value or class.</summary>
		/// <param name="value">The enumeration value or class instance.</param>
		/// <param name="typeRef">The type supplied by the user to validate.</param>
		/// <returns><c>true</c> if this instance can get the specified type; otherwise, <c>false</c>.</returns>
		public static bool CanGet(object value, Type typeRef) => GetAttrForObj(value).Any(a => a.Action.IsFlagSet(CorrespondingAction.Get) && a.TypeRef == typeRef);

		/// <summary>Determines whether this instance can get the type for the specified enum type.</summary>
		/// <param name="value">The enumeration type.</param>
		/// <param name="typeRef">The type supplied by the user to validate.</param>
		/// <returns><c>true</c> if this instance can get the specified type; otherwise, <c>false</c>.</returns>
		public static bool CanGet<TEnum>(TEnum value, Type typeRef) where TEnum : System.Enum => GetAttrForEnum(value, CorrespondingAction.Get).Any(a => a.TypeRef == typeRef);

		/// <summary>Determines whether this type can get the specified reference type.</summary>
		/// <param name="type">The class type.</param>
		/// <param name="typeRef">The type supplied by the user to validate.</param>
		/// <returns><c>true</c> if this type can get the specified reference type; otherwise, <c>false</c>.</returns>
		public static bool CanGet(Type type, Type typeRef) => GetAttrForType(type).Any(a => a.Action.IsFlagSet(CorrespondingAction.Get) && a.TypeRef == typeRef);

		/// <summary>Determines whether an enum value exists that supports a corresponding type of <typeparamref name="T"/>.</summary>
		/// <typeparam name="T">The corresponding type to look for.</typeparam>
		/// <typeparam name="TEnum">The type of the enum.</typeparam>
		/// <param name="value">The value of type <typeparamref name="TEnum"/> that has the corresponding type <typeparamref name="T"/>.</param>
		/// <returns>
		///   <see langword="true" /> if this instance can get the specified value; otherwise, <see langword="false" />.
		/// </returns>
		public static bool CanGet<T, TEnum>(out TEnum value) where TEnum : struct, System.Enum
		{
			foreach (TEnum v in Enum.GetValues(typeof(TEnum)))
			{
				if (CanGet(v, typeof(T)))
				{
					value = v;
					return true;
				}
			}
			value = default;
			return false;
		}

		/// <summary>Determines whether this instance can set the type for the specified enum value or class.</summary>
		/// <param name="value">The enumeration value or class instance.</param>
		/// <param name="typeRef">The type supplied by the user to validate.</param>
		/// <returns><c>true</c> if this instance can set the specified type; otherwise, <c>false</c>.</returns>
		public static bool CanSet(object value, Type typeRef) => GetAttrForObj(value).Any(a => a.Action.IsFlagSet(CorrespondingAction.Set) && a.TypeRef == typeRef);

		/// <summary>Determines whether this instance can set the type for the specified enum value or class.</summary>
		/// <param name="value">The enumeration value or class instance.</param>
		/// <param name="typeRef">The type supplied by the user to validate.</param>
		/// <returns><c>true</c> if this instance can set the specified type; otherwise, <c>false</c>.</returns>
		public static bool CanSet<TEnum>(TEnum value, Type typeRef) where TEnum : System.Enum => GetAttrForEnum(value, CorrespondingAction.Set).Any(a => a.TypeRef == typeRef);

		/// <summary>Determines whether this type can set the specified reference type.</summary>
		/// <param name="type">The class type.</param>
		/// <param name="typeRef">The type supplied by the user to validate.</param>
		/// <returns><c>true</c> if this type can set the specified reference type; otherwise, <c>false</c>.</returns>
		public static bool CanSet(Type type, Type typeRef) => GetAttrForType(type).Any(a => a.Action.IsFlagSet(CorrespondingAction.Set) && a.TypeRef == typeRef);

		/// <summary>Gets the corresponding types for the supplied enumeration value.</summary>
		/// <param name="enumValue">The class or structure instance.</param>
		/// <returns>The types defined by the attribute.</returns>
		public static IEnumerable<Type> GetCorrespondingTypes(object enumValue) => GetAttrForObj(enumValue).Select(a => a.TypeRef);

		/// <summary>Gets the corresponding types for the supplied enumeration value.</summary>
		/// <param name="enumValue">The enumeration value.</param>
		/// <returns>The types defined by the attribute.</returns>
		public static IEnumerable<Type> GetCorrespondingTypes<TEnum>(TEnum enumValue) where TEnum : System.Enum => GetAttrForEnum(enumValue).Select(a => a.TypeRef);

		/// <summary>Gets the corresponding types for the supplied enumeration value.</summary>
		/// <param name="enumValue">The enumeration value.</param>
		/// <param name="action">The action to filter for.</param>
		/// <returns>The types defined by the attribute.</returns>
		public static IEnumerable<Type> GetCorrespondingTypes<TEnum>(TEnum enumValue, CorrespondingAction action) where TEnum : System.Enum => GetAttrForEnum(enumValue, action).Select(a => a.TypeRef);

		/// <summary>Gets the corresponding types for the supplied enumeration value.</summary>
		/// <param name="type">The class type.</param>
		/// <returns>The types defined by the attribute.</returns>
		public static IEnumerable<Type> GetCorrespondingTypes(Type type) => GetAttrForType(type).Select(a => a.TypeRef);

		/// <summary>Gets the CorrespondingTypeAttribute instances associated with an enum value.</summary>
		/// <typeparam name="TEnum">The type of the enum.</typeparam>
		/// <param name="value">The enum value.</param>
		/// <param name="action">The action to filter for.</param>
		/// <returns>An enumeration of all associated CorrespondingTypeAttribute instances.</returns>
		protected static IEnumerable<CorrespondingTypeAttribute> GetAttrForEnum<TEnum>(TEnum value, CorrespondingAction action = (CorrespondingAction)0xf) where TEnum : System.Enum
		{
			var valueType = value.GetType();
			var attr = valueType.GetField(value.ToString()).GetCustomAttributes<CorrespondingTypeAttribute>(false, a => a.Action.HasFlag(action));
			if (attr.Any(a => a.Action == CorrespondingAction.Exception)) throw new Exception();
			//if (!attr.Any()) return new CorrespondingTypeAttribute[0];
			return attr;
		}

		/// <summary>Gets the CorrespondingTypeAttribute instances associated with an enum value or class instance.</summary>
		/// <param name="value">The enum value or class instance.</param>
		/// <returns>An enumeration of all associated CorrespondingTypeAttribute instances.</returns>
		protected static IEnumerable<CorrespondingTypeAttribute> GetAttrForObj(object value)
		{
			if (value is null) throw new ArgumentNullException(nameof(value));
			var valueType = value.GetType();
			if (!valueType.IsEnum && !valueType.IsClass) throw new ArgumentException("Value must be an enumeration or class value.", nameof(value));
			var attr = valueType.IsEnum ? valueType.GetField(value.ToString()).GetCustomAttributes<CorrespondingTypeAttribute>() : valueType.GetCustomAttributes<CorrespondingTypeAttribute>();
			if (!attr.Any()) return new CorrespondingTypeAttribute[0];
			if (attr.Any(a => a.Action == CorrespondingAction.Exception)) throw new Exception();
			return attr;
		}

		/// <summary>Gets the CorrespondingTypeAttribute instances associated with a type.</summary>
		/// <param name="type">The type.</param>
		/// <returns>An enumeration of all associated CorrespondingTypeAttribute instances.</returns>
		protected static IEnumerable<CorrespondingTypeAttribute> GetAttrForType(Type type)
		{
			if (type == null) throw new ArgumentNullException(nameof(type));
			var attr = type.GetCustomAttributes<CorrespondingTypeAttribute>();
			if (!attr.Any()) return new CorrespondingTypeAttribute[0];
			if (attr.Any(a => a.Action == CorrespondingAction.Exception)) throw new Exception();
			return attr;
		}
	}
}