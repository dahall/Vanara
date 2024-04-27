using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;

namespace Vanara.PInvoke;

/// <summary>Gets a static field's name from its value and caches the list for faster lookups.</summary>
public static class StaticFieldValueHash
{
	private static readonly Dictionary<(Type, Type), IDictionary<int, (string, string?)>> cache = [];

	/// <summary>Adds the seqence of field values to the associated cache.</summary>
	/// <typeparam name="TType">The type of the type.</typeparam>
	/// <typeparam name="TFieldType">The type of the field type.</typeparam>
	/// <param name="fields">The list of field values and names to add.</param>
	/// <param name="lib">The optional library name.</param>
	public static void AddFields<TType, TFieldType>(IEnumerable<(TFieldType value, string name)> fields, string? lib = null)
		where TFieldType : struct, IComparable, IConvertible
	{
		TryGetFieldName<TType, TFieldType>(default, out _); // Load default values
		var tt = (typeof(TType), typeof(TFieldType));
		if (cache.TryGetValue(tt, out var hash))
		{
			foreach (var (value, name) in fields)
				if (!hash.ContainsKey(value.GetHashCode()))
					hash.Add(value.GetHashCode(), (name, lib));
		}
	}

	/// <summary>Adds the seqence of field values to the associated cache.</summary>
	/// <typeparam name="TType">The type of the type.</typeparam>
	/// <typeparam name="TFieldType">The type of the field type.</typeparam>
	/// <typeparam name="TEnum">The type of the enum to added.</typeparam>
	/// <param name="lib">The optional library name.</param>
	public static void AddFields<TType, TFieldType, TEnum>(string? lib = null) where TFieldType : struct, IComparable, IConvertible =>
		AddFields<TType, TFieldType>(Enum.GetValues(typeof(TEnum)).Cast<TFieldType>().Select(v => (v, Enum.GetName(typeof(TEnum), v)!)), lib);

	/// <summary>Tries to get the name of a value's library.</summary>
	/// <typeparam name="TType">The type of the type.</typeparam>
	/// <typeparam name="TFieldType">The type of the field type.</typeparam>
	/// <param name="value">The value for which to search.</param>
	/// <returns>The name of the library or <see langword="null"/>.</returns>
	public static string? GetFieldLib<TType, TFieldType>(TFieldType value)
		where TFieldType : struct, IComparable, IConvertible
	{
		var tt = (typeof(TType), typeof(TFieldType));
		return cache.TryGetValue(tt, out var hash) && hash.TryGetValue(value.GetHashCode(), out var t) ? t.Item2 : null;
	}

	/// <summary>Tries to get the name of a static field from it's value.</summary>
	/// <typeparam name="TType">The type of the type.</typeparam>
	/// <typeparam name="TFieldType">The type of the field type.</typeparam>
	/// <param name="value">The value for which to search.</param>
	/// <param name="fieldName">On success, the name of the field.</param>
	/// <returns><see langword="true"/> if the value was found, otherwise <see langword="false"/>.</returns>
	public static bool TryGetFieldName<TType, TFieldType>(TFieldType value, [NotNullWhen(true)] out string? fieldName)
		where TFieldType : struct, IComparable, IConvertible
	{
		var tt = (typeof(TType), typeof(TFieldType));
		if (!cache.TryGetValue(tt, out var hash))
		{
			hash = typeof(TType).GetFields(BindingFlags.Public | BindingFlags.Static).
				Where(fi => fi.FieldType == typeof(TFieldType)).Distinct(FIValueComp<TFieldType>.Default).
				ToDictionary<FieldInfo, int, (string, string?)>(fi => fi.GetValue(null)!.GetHashCode(), fi => (fi.Name, null));
			cache.Add(tt, hash);
		}
		var ret = hash.TryGetValue(value.GetHashCode(), out var t);
		fieldName = t.Item1;
		return ret;
	}

	private class FIValueComp<TFieldType> : IEqualityComparer<FieldInfo> where TFieldType : struct, IComparable, IConvertible
	{
		bool IEqualityComparer<FieldInfo>.Equals(FieldInfo? x, FieldInfo? y) =>
			Comparer<TFieldType?>.Default.Compare((TFieldType?)x?.GetValue(null), (TFieldType?)y?.GetValue(null)) == 0;

		int IEqualityComparer<FieldInfo>.GetHashCode(FieldInfo obj) => ((TFieldType?)obj.GetValue(null))?.GetHashCode() ?? 0;

		public static readonly FIValueComp<TFieldType> Default = new();
	}
}