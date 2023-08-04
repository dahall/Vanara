using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;

namespace Vanara.PInvoke;

/// <summary>Gets a static field's name from its value and caches the list for faster lookups.</summary>
public class StaticFieldValueHash
{
	private static readonly Dictionary<(Type, Type), IDictionary<int, string>> cache = new();

	/// <summary>Tries to get the name of a static field from it's value.</summary>
	/// <typeparam name="TType">The type of the type.</typeparam>
	/// <typeparam name="TFieldType">The type of the field type.</typeparam>
	/// <param name="value">The value for which to search.</param>
	/// <param name="fieldName">On success, the name of the field.</param>
	/// <returns><see langword="true"/> if the value was found, otherwise <see langword="false"/>.</returns>
	public static bool TryGetFieldName<TType, TFieldType>(TFieldType value, [NotNullWhen(true)] out string? fieldName)
		where TFieldType : struct, IComparable
	{
		var tt = (typeof(TType), typeof(TFieldType));
		if (!cache.TryGetValue(tt, out var hash))
		{
			hash = typeof(TType).GetFields(BindingFlags.Public | BindingFlags.Static).
				Where(fi => fi.FieldType == typeof(TFieldType)).Distinct(FIValueComp<TFieldType>.Default).
				ToDictionary(fi => fi.GetValue(null)!.GetHashCode(), fi => fi.Name);
			cache.Add(tt, hash);
		}
		return hash.TryGetValue(value.GetHashCode(), out fieldName);
	}

	private class FIValueComp<TFieldType> : IEqualityComparer<FieldInfo> where TFieldType : struct, IComparable
	{
		bool IEqualityComparer<FieldInfo>.Equals(FieldInfo? x, FieldInfo? y) =>
			Comparer<TFieldType?>.Default.Compare((TFieldType?)x?.GetValue(null), (TFieldType?)y?.GetValue(null)) == 0;

		int IEqualityComparer<FieldInfo>.GetHashCode(FieldInfo obj) => ((TFieldType?)obj.GetValue(null))?.GetHashCode() ?? 0;

		public static readonly FIValueComp<TFieldType> Default = new();
	}
}