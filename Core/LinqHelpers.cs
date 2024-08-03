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

	/// <summary>Compares two sequences by comparing their elements by using a specified <see cref="IComparer{T}"/>.</summary>
	/// <typeparam name="TSource">The type of the elements of the input sequences.</typeparam>
	/// <param name="first">An <see cref="IEnumerable{T}"/> to compare to <paramref name="second"/>.</param>
	/// <param name="second">An <see cref="IEnumerable{T}"/> to compare to <paramref name="first"/>.</param>
	/// <param name="comparer">An <see cref="IComparer{T}"/> to use to compare elements.</param>
	/// <returns>
	/// <para>
	/// A signed integer that indicates the relative values of <paramref name="first"/> and <paramref name="second"/>, as shown in the following table.
	/// </para>
	/// <list type="table">
	/// <item>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </item>
	/// <item>
	/// <description>Less than zero</description>
	/// <description><paramref name="first"/> is less than <paramref name="second"/>.</description>
	/// </item>
	/// <item>
	/// <description>Zero</description>
	/// <description><paramref name="first"/> equals <paramref name="second"/>.</description>
	/// </item>
	/// <item>
	/// <description>Greater than zero</description>
	/// <description><paramref name="first"/> is greater than <paramref name="second"/>.</description>
	/// </item>
	/// </list>
	/// </returns>
	public static int SequenceCompare<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second, IComparer<TSource>? comparer = null)
	{
		if (first is null)
			throw new ArgumentNullException(nameof(first));
		if (second is null)
			throw new ArgumentNullException(nameof(second));

		comparer ??= Comparer<TSource>.Default;

		using IEnumerator<TSource> enumerator = first.GetEnumerator();
		using IEnumerator<TSource> enumerator2 = second.GetEnumerator();
		while (enumerator.MoveNext())
		{
			int cmp = 1;
			if (!enumerator2.MoveNext() || (cmp = comparer.Compare(enumerator.Current, enumerator2.Current)) != 0)
			{
				return cmp;
			}
		}
		return enumerator2.MoveNext() ? -1 : 0;
	}
}