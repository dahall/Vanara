using System.Collections.Generic;
using System.Linq;

namespace Vanara;

/// <summary>Helper methods for LINQ</summary>
public static class LinqHelpers
{
	/// <summary>Filters <see langword="null"/> values out of a sequence.</summary>
	/// <typeparam name="T">The nullable type.</typeparam>
	/// <param name="o">The sequence.</param>
	/// <returns>The sequence without any <see langword="null"/> values.</returns>
	public static IEnumerable<T> WhereNotNull<T>(this IEnumerable<T?> o) where T : class
		=> o.Where(x => x is not null)!;
}