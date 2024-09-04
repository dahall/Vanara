using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace Vanara.Extensions;

/// <summary>Extensions for types in System.Runtime.InteropServices.ComTypes.</summary>
public static class ComTypeExtensions
{
	/// <summary>Enumerates the strings from an <see cref="IEnumString"/> instance.</summary>
	/// <param name="iEnumString">The <see cref="IEnumString"/> instance.</param>
	/// <returns>A list of strings.</returns>
	public static IEnumerable<string> Enum(this IEnumString iEnumString)
	{
		if (iEnumString is null) yield break;
		using SafeCoTaskMemStruct<uint> ret = new();
		var items = new string[1];
		while (iEnumString.Next(1, items, ret) == 0 && ret.Value == 1)
			yield return items[0];
	}

	/// <summary>Enumerates the objects from an <see cref="IEnumVARIANT"/> instance.</summary>
	/// <param name="iEnumVar">The <see cref="IEnumVARIANT"/> instance.</param>
	/// <returns>A list of objects.</returns>
	public static IEnumerable<object?> Enum(this IEnumVARIANT iEnumVar)
	{
		if (iEnumVar is null) yield break;
		using SafeCoTaskMemStruct<uint> ret = new();
		var items = new object[1];
		while (iEnumVar.Next(1, items, ret) == 0 && ret.Value == 1)
			yield return items[0];
	}
}