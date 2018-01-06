#if (NET20)
using System.Collections;
using System.Collections.Generic;

namespace System.Linq
{
	/// <summary>Provides a set of static (Shared in Visual Basic) methods for querying objects that implement <see cref="IEnumerable{T}"/>.</summary>
	public static class Enumerable
	{
		/// <summary>Determines whether all elements of a sequence satisfy a condition.</summary>
		/// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
		/// <param name="source">An <see cref="IEnumerable{T}"/> whose elements to apply the predicate to.</param>
		/// <param name="predicate">A function to test each element for a condition.</param>
		/// <returns><c>true</c> if all elements in the source sequence pass the test in the specified predicate; otherwise, <c>false</c>.</returns>
		public static bool All<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (predicate == null) throw new ArgumentNullException(nameof(predicate));
			foreach (TSource element in source)
				if (!predicate(element)) return false;
			return true;
		}

		/// <summary>Determines whether any element of a sequence satisfies a condition.</summary>
		/// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
		/// <param name="source">An <see cref="IEnumerable{T}"/> whose elements to apply the predicate to.</param>
		/// <param name="predicate">A function to test each element for a condition.</param>
		/// <returns><c>true</c> if any elements in the source sequence pass the test in the specified predicate; otherwise, <c>false</c>.</returns>
		public static bool Any<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (predicate == null) throw new ArgumentNullException(nameof(predicate));
			foreach (TSource element in source)
				if (predicate(element)) return true;
			return false;
		}

		/// <summary>Casts the elements of an <see cref="IEnumerable"/> to the specified type.</summary>
		/// <typeparam name="TResult">The type to cast the elements of source to.</typeparam>
		/// <param name="source">The <see cref="IEnumerable{T}"/> that contains the elements to be cast to type <typeparamref name="TResult"/>.</param>
		/// <returns>An <see cref="IEnumerable{T}"/> that contains each element of the source sequence cast to the specified type.</returns>
		public static IEnumerable<TResult> Cast<TResult>(this IEnumerable source)
		{
			foreach (var i in source)
				yield return (TResult)i;
		}

		/// <summary>Determines whether a sequence contains a specified element by using the default equality comparer.</summary>
		/// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
		/// <param name="source">A sequence in which to locate a value.</param>
		/// <param name="value">The value to locate in the sequence.</param>
		/// <returns><c>true</c> if the source sequence contains an element that has the specified value; otherwise, <c>false</c>.</returns>
		public static bool Contains<TSource>(this IEnumerable<TSource> source, TSource value)
		{
			foreach (var i in source)
				if (i.Equals(value)) return true;
			return false;
		}

		/// <summary>Returns the number of elements in a sequence.</summary>
		/// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
		/// <param name="source">A sequence that contains elements to be counted.</param>
		/// <returns>The number of elements in the input sequence.</returns>
		public static int Count<TSource>(this IEnumerable<TSource> source)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (source is ICollection<TSource> c) return c.Count;
			if (source is ICollection ngc) return ngc.Count;
			var i = 0;
			foreach (var e in source) i++;
			return i;
		}

		/// <summary>Returns distinct elements from a sequence by using the default equality comparer to compare values.</summary>
		/// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
		/// <param name="source">The sequence to remove duplicate elements from.</param>
		/// <returns>An <see cref="IEnumerable{T}"/> that contains distinct elements from the source sequence.</returns>
		public static IEnumerable<TSource> Distinct<TSource>(this IEnumerable<TSource> source)
		{
			var set = new Hashtable();
			foreach (var element in source)
				if (!set.ContainsKey(element))
				{
					set.Add(element, null);
					yield return element;
				}
		}

		/// <summary>Returns the first element of a sequence.</summary>
		/// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
		/// <param name="source">The <see cref="IEnumerable{T}"/> to return the first element of.</param>
		/// <returns>The first element in the specified sequence.</returns>
		public static TSource First<TSource>(this IEnumerable<TSource> source)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (source is IList<TSource> list)
			{
				if (list.Count > 0) return list[0];
			}
			else
			{
				using (var e = source.GetEnumerator())
				{
					if (e.MoveNext()) return e.Current;
				}
			}
			throw new InvalidOperationException(@"No elements");
		}

		/// <summary>Returns the first element of a sequence that satisfies a specified condition.</summary>
		/// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
		/// <param name="source">The <see cref="IEnumerable{T}"/> to return the first element of.</param>
		/// <param name="predicate">A function to test each element for a condition.</param>
		/// <returns>The first element in the sequence that passes the test in the specified predicate function.</returns>
		public static TSource First<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (predicate == null) throw new ArgumentNullException(nameof(predicate));
			foreach (var element in source)
				if (predicate(element)) return element;
			throw new InvalidOperationException(@"No match");
		}

		/// <summary>Returns the first element of a sequence, or a default value if the sequence contains no elements.</summary>
		/// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
		/// <param name="source">The <see cref="IEnumerable{T}"/> to return the first element of.</param>
		/// <returns><c>default( <typeparamref name="TSource"/>)</c> if <paramref name="source"/> is empty; otherwise, the first element in <paramref name="source"/>.</returns>
		public static TSource FirstOrDefault<TSource>(this IEnumerable<TSource> source)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (source is IList<TSource> list)
			{
				if (list.Count > 0) return list[0];
			}
			else
			{
				using (var e = source.GetEnumerator())
				{
					if (e.MoveNext()) return e.Current;
				}
			}
			return default(TSource);
		}

		/// <summary>Returns the first element of the sequence that satisfies a condition or a default value if no such element is found.</summary>
		/// <typeparam name="TSource">The type of the elements of source.</typeparam>
		/// <param name="source">An <see cref="IEnumerable{T}"/> to return an element from.</param>
		/// <param name="predicate">A function to test each element for a condition.</param>
		/// <returns><c>default(<typeparamref name="TSource"/>)</c> if <paramref name="source"/> is empty or if no element passes the test specified by <paramref name="predicate"/>; otherwise, the first element in <paramref name="source"/> that passes the test specified by <paramref name="predicate"/>.</returns>
		public static TSource FirstOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (predicate == null) throw new ArgumentNullException(nameof(predicate));
			foreach (var element in source)
				if (predicate(element)) return element;
			return default(TSource);
		}

		/// <summary>Returns the minimum value in a generic sequence.</summary>
		/// <typeparam name="TSource">The type of the elements of source.</typeparam>
		/// <param name="source">A sequence of values to determine the minimum value of.</param>
		/// <returns>The minimum value in the sequence.</returns>
		public static TSource Min<TSource>(this IEnumerable<TSource> source)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			var comparer = Comparer<TSource>.Default;
			var value = default(TSource);
			if (value == null)
			{
				foreach (var x in source)
				{
					if (x != null && (value == null || comparer.Compare(x, value) < 0))
						value = x;
				}
				return value;
			}

			var hasValue = false;
			foreach (var x in source)
			{
				if (hasValue)
				{
					if (comparer.Compare(x, value) < 0)
						value = x;
				}
				else
				{
					value = x;
					hasValue = true;
				}
			}
			if (hasValue) return value;
			throw new InvalidOperationException("No elements");
		}

		/// <summary>Returns the maximum value in a generic sequence.</summary>
		/// <typeparam name="TSource">The type of the elements of source.</typeparam>
		/// <param name="source">A sequence of values to determine the maximum value of.</param>
		/// <returns>The maximum value in the sequence.</returns>
		public static TSource Max<TSource>(this IEnumerable<TSource> source)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			var comparer = Comparer<TSource>.Default;
			var value = default(TSource);
			if (value == null) {
				foreach (var x in source) {
					if (x != null && (value == null || comparer.Compare(x, value) > 0))
						value = x;
				}
				return value;
			}
			var hasValue = false;
			foreach (var x in source) {
				if (hasValue) {
					if (comparer.Compare(x, value) > 0)
						value = x;
				}
				else {
					value = x;
					hasValue = true;
				}
			}
			if (hasValue) return value;
			throw new InvalidOperationException("No elements");
		}

		/// <summary>Sorts the elements of a sequence in ascending order according to a key.</summary>
		/// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
		/// <typeparam name="TKey">The type of the key returned by <paramref name="keySelector"/>.</typeparam>
		/// <param name="source">A sequence of values to order.</param>
		/// <param name="keySelector">A function to extract a key from an element.</param>
		/// <returns>An <see cref="IEnumerable{T}"/> whose elements are sorted according to a key.</returns>
		public static IEnumerable<TSource> OrderBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
		{
			var d = new SortedDictionary<TKey, TSource>();
			foreach (var item in source)
				d.Add(keySelector(item), item);
			return d.Values;
		}

		/// <summary>Projects each element of a sequence into a new form.</summary>
		/// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
		/// <typeparam name="TResult">The type of the value returned by <paramref name="selector"/>.</typeparam>
		/// <param name="source">A sequence of values to invoke a transform function on.</param>
		/// <param name="selector">A transform function to apply to each element.</param>
		/// <returns>An <see cref="IEnumerable{T}"/> whose elements are the result of invoking the transform function on each element of <paramref name="source"/>.</returns>
		public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
		{
			if (selector == null) throw new ArgumentNullException(nameof(selector));
			foreach (var i in source)
				yield return selector(i);
		}

		/// <summary>Returns the only element of a sequence that satisfies a specified condition, and throws an exception if more than one such element exists.</summary>
		/// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
		/// <param name="source">An <see cref="IEnumerable{T}"/> to return a single element from.</param>
		/// <param name="predicate">A function to test an element for a condition.</param>
		/// <returns>The single element of the input sequence that satisfies a condition.</returns>
		public static TSource Single<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (predicate == null) throw new ArgumentNullException(nameof(predicate));
			var result = default(TSource);
			long count = 0;
			foreach (var element in source)
			{
				if (!predicate(element)) continue;
				result = element;
				checked { count++; }
			}
			if (count == 0) throw new InvalidOperationException(@"No matches");
			if (count != 1) throw new InvalidOperationException(@"More than one match.");
			return result;
		}

		/// <summary>Computes the sum of a sequence of nullable <see cref="Int32"/> values.</summary>
		/// <param name="source">A sequence of nullable <see cref="Int32"/> values to calculate the sum of.</param>
		/// <returns>The sum of the values in the sequence.</returns>
		public static int Sum(this IEnumerable<int> source)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			int sum = 0;
			checked
			{
				foreach (int v in source) sum += v;
			}
			return sum;
		}

		/// <summary>
		/// Computes the sum of the sequence of nullable <see cref="Int32"/> values that are obtained by invoking a transform function on each element of the input sequence.
		/// </summary>
		/// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
		/// <param name="source">A sequence of values that are used to calculate a sum.</param>
		/// <param name="selector">A transform function to apply to each element.</param>
		/// <returns>The sum of the projected values.</returns>
		public static int Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, int> selector) => Sum(Select(source, selector));

		/// <summary>Creates an array from a <see cref="IEnumerable"/>.</summary>
		/// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
		/// <param name="source">An <see cref="IEnumerable{T}"/> to create an array from.</param>
		/// <returns>An array that contains the elements from the input sequence.</returns>
		public static TSource[] ToArray<TSource>(this IEnumerable<TSource> source) => ToList(source).ToArray();

		/// <summary>
		/// Creates a <see cref="Dictionary{TKey,TValue}"/> from an <see cref="IEnumerable{T}"/> according to a specified key selector function, a comparer, and
		/// an element selector function.
		/// </summary>
		/// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
		/// <typeparam name="TKey">The type of the key returned by <paramref name="keySelector"/>.</typeparam>
		/// <typeparam name="TElement">The type of the value returned by <paramref name="elementSelector"/>.</typeparam>
		/// <param name="source">An <see cref="IEnumerable{T}"/> to create a <see cref="Dictionary{TKey,TValue}"/> from.</param>
		/// <param name="keySelector">A function to extract a key from each element.</param>
		/// <param name="elementSelector">A transform function to produce a result element value from each element.</param>
		/// <param name="comparer">An <see cref="IEqualityComparer{T}"/> to compare keys.</param>
		/// <returns>A <see cref="Dictionary{TKey,TValue}"/> that contains values of type TElement selected from the input sequence.</returns>
		public static Dictionary<TKey, TElement> ToDictionary<TSource, TKey, TElement>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TElement> elementSelector, IEqualityComparer<TKey> comparer)
		{
			if (source == null) throw new ArgumentNullException(nameof(source));
			if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));
			if (elementSelector == null) throw new ArgumentNullException(nameof(elementSelector));
			var d = new Dictionary<TKey, TElement>(comparer);
			foreach (var element in source) d.Add(keySelector(element), elementSelector(element));
			return d;
		}

		/// <summary>Creates a <see cref="List{T}"/> from an <see cref="IEnumerable{T}"/>.</summary>
		/// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
		/// <param name="source">An <see cref="IEnumerable{T}"/> to create a <see cref="List{T}"/> from.</param>
		/// <returns>A <see cref="List{T}"/> that contains elements from the input sequence.</returns>
		public static List<TSource> ToList<TSource>(this IEnumerable<TSource> source)
		{
			var l = new List<TSource>();
			foreach (var i in source)
				l.Add(i);
			return l;
		}

		/// <summary>Filters a sequence of values based on a predicate.</summary>
		/// <typeparam name="TSource">The type of the elements of <paramref name="source"/>.</typeparam>
		/// <param name="source">An <see cref="IEnumerable{T}"/> to filter.</param>
		/// <param name="predicate">A function to test each element for a condition.</param>
		/// <returns>An <see cref="IEnumerable{T}"/> that contains elements from the input sequence that satisfy the condition.</returns>
		public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
		{
			if (predicate == null) throw new ArgumentNullException(nameof(predicate));
			foreach (var i in source)
				if (predicate(i)) yield return i;
		}
	}
}
#endif