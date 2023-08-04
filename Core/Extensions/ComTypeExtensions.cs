using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;

namespace Vanara.Extensions;

/// <summary>Extensions for types in System.Runtime.InteropServices.ComTypes.</summary>
public static class ComTypeExtensions
{
	/// <summary>Enumerates the strings from an <see cref="IEnumString"/> instance.</summary>
	/// <param name="iEnumString">The <see cref="IEnumString"/> instance.</param>
	/// <returns>A list of strings.</returns>
	/// <exception cref="ArgumentNullException">iEnumString</exception>
	public static IEnumerable<string> Enum(this IEnumString iEnumString)
	{
		if (iEnumString is null) yield break;
		using SafeCoTaskMemStruct<uint> ret = new();
		var items = new string[1];
		while (iEnumString.Next(1, items, ret) == 0 && ret.Value == 1)
			yield return items[0];
	}
}