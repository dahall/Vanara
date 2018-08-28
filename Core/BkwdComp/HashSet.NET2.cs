#if NET20
using System.Linq;
using System.Runtime.Serialization;

namespace System.Collections.Generic
{
	/// <summary>Provides the base interface for the abstraction of sets.</summary>
	public interface ISet<T> : ICollection<T>
	{
		/// <summary>Adds an element to the current set and returns a value to indicate if the element was successfully added.</summary>
		/// <param name="item">The element to add to the set.</param>
		/// <returns><c>true</c> if the element is added to the set; <c>false</c> if the element is already in the set.</returns>
		new bool Add(T item);

		/// <summary>Removes all elements in the specified collection from the current set.</summary>
		/// <param name="other">The collection of items to remove from the set.</param>
		void ExceptWith(IEnumerable<T> other);

		/// <summary>Modifies the current set so that it contains only elements that are also in a specified collection.</summary>
		/// <param name="other">The collection to compare to the current set.</param>
		void IntersectWith(IEnumerable<T> other);

		/// <summary>Determines whether the current set is a proper (strict) subset of a specified collection.</summary>
		/// <param name="other">The collection to compare to the current set.</param>
		/// <returns><c>true</c> if the current set is a proper subset of <paramref name="other"/>; otherwise, <c>false</c>.</returns>
		bool IsProperSubsetOf(IEnumerable<T> other);

		/// <summary>Determines whether the current set is a proper (strict) superset of a specified collection.</summary>
		/// <param name="other">The collection to compare to the current set.</param>
		/// <returns><c>true</c> if the current set is a proper superset of <paramref name="other"/>; otherwise, <c>false</c>.</returns>
		bool IsProperSupersetOf(IEnumerable<T> other);

		/// <summary>Determines whether a set is a subset of a specified collection.</summary>
		/// <param name="other">The collection to compare to the current set.</param>
		/// <returns><c>true</c> if the current set is a subset of <paramref name="other"/>; otherwise, <c>false</c>.</returns>
		bool IsSubsetOf(IEnumerable<T> other);

		/// <summary>Determines whether the current set is a superset of a specified collection.</summary>
		/// <param name="other">The collection to compare to the current set.</param>
		/// <returns><c>true</c> if the current set is a superset of <paramref name="other"/>; otherwise, <c>false</c>.</returns>
		bool IsSupersetOf(IEnumerable<T> other);

		/// <summary>Determines whether the current set overlaps with the specified collection.</summary>
		/// <param name="other">The collection to compare to the current set.</param>
		/// <returns><c>true</c> if the current set and <paramref name="other"/> share at least one common element; otherwise, <c>false</c>.</returns>
		bool Overlaps(IEnumerable<T> other);

		/// <summary>Determines whether the current set and the specified collection contain the same elements.</summary>
		/// <param name="other">The collection to compare to the current set.</param>
		/// <returns><c>true</c> if the current set is equal to <paramref name="other"/>; otherwise, <c>false</c>.</returns>
		bool SetEquals(IEnumerable<T> other);

		/// <summary>
		/// Modifies the current set so that it contains only elements that are present either in the current set or in the specified
		/// collection, but not both.
		/// </summary>
		/// <param name="other">The collection to compare to the current set.</param>
		void SymmetricExceptWith(IEnumerable<T> other);

		/// <summary>
		/// Modifies the current set so that it contains all elements that are present in the current set, in the specified collection, or in both.
		/// </summary>
		/// <param name="other">The collection to compare to the current set.</param>
		void UnionWith(IEnumerable<T> other);
	}

	/// <summary>
	/// Represents a set of values. This is less efficient than the native implementation in .NET versions after 2.0, but functionally equivalent.
	/// </summary>
	/// <typeparam name="T">The type of elements in the hash set.</typeparam>
	public class HashSet<T> : ISet<T>, IReadOnlyCollection<T>, ISerializable, IDeserializationCallback
	{
		private readonly Dictionary<T, object> dict;

		/// <summary>
		/// Initializes a new instance of the <see cref="HashSet{T}"/> class that is empty and uses the default equality comparer for the set type.
		/// </summary>
		public HashSet() : this((IEqualityComparer<T>)null)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="HashSet{T}"/> class that uses the default equality comparer for the set type,
		/// contains elements copied from the specified collection, and has sufficient capacity to accommodate the number of elements copied..
		/// </summary>
		/// <param name="collection">The collection whose elements are copied to the new set.</param>
		public HashSet(IEnumerable<T> collection) : this(collection, null)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="HashSet{T}"/> class that is empty and uses the specified equality comparer for the
		/// set type..
		/// </summary>
		/// <param name="comparer">
		/// The <see cref="IEqualityComparer{T}"/> implementation to use when comparing values in the set, or <c>null</c> to use the default
		/// <see cref="EqualityComparer{T}"/> implementation for the set type.
		/// </param>
		public HashSet(IEqualityComparer<T> comparer)
		{
			dict = new Dictionary<T, object>(comparer);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="HashSet{T}"/> class that uses the specified equality comparer for the set type,
		/// contains elements copied from the specified collection, and has sufficient capacity to accommodate the number of elements copied..
		/// </summary>
		/// <param name="collection">The collection whose elements are copied to the new set.</param>
		/// <param name="comparer">
		/// The <see cref="IEqualityComparer{T}"/> implementation to use when comparing values in the set, or <c>null</c> to use the default
		/// <see cref="EqualityComparer{T}"/> implementation for the set type.
		/// </param>
		public HashSet(IEnumerable<T> collection, IEqualityComparer<T> comparer)
		{
			dict = new Dictionary<T, object>(comparer);
			foreach (T elem in collection)
			{
				Add(elem);
			}
		}

		/* ***** Unnecessary since implemented in .NET 4.7.2
		/// <summary>
		/// Initializes a new instance of the <see cref="HashSet{T}"/> class that is empty, but has reserved space for capacity items and
		/// uses the default equality comparer for the set type..
		/// </summary>
		/// <param name="capacity">The initial size of the <see cref="HashSet{T}"/></param>
		public HashSet(int capacity) : this(capacity, null)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="HashSet{T}"/> class that uses the specified equality comparer for the set type, and
		/// has sufficient capacity to accommodate capacity elements..
		/// </summary>
		/// <param name="capacity">The initial size of the <see cref="HashSet{T}"/></param>
		/// <param name="comparer">
		/// The <see cref="IEqualityComparer{T}"/> implementation to use when comparing values in the set, or <c>null</c> to use the default
		/// <see cref="EqualityComparer{T}"/> implementation for the set type.
		/// </param>
		public HashSet(int capacity, IEqualityComparer<T> comparer)
		{
			dict = new Dictionary<T, object>(capacity, comparer);
		}
		*/

		/// <summary>Gets the <see cref="IEqualityComparer{T}"/> object that is used to determine equality for the values in the set.</summary>
		public IEqualityComparer<T> Comparer => dict.Comparer;

		/// <inheritdoc cref="ICollection{T}.Count"/>
		public int Count => dict.Count;

		/// <inheritdoc/>
		bool ICollection<T>.IsReadOnly { get; } = false;

		/// <inheritdoc/>
		public bool Add(T item)
		{
			if (null == item)
			{
				throw new ArgumentNullException(nameof(item));
			}

			if (Contains(item))
			{
				return false;
			}

			dict[item] = null;
			return true;
		}

		/// <inheritdoc/>
		public void Clear()
		{
			dict.Clear();
		}

		/// <inheritdoc/>
		public bool Contains(T item)
		{
			return item != null && dict.ContainsKey(item);
		}

		/// <inheritdoc/>
		public void CopyTo(T[] array, int arrayIndex)
		{
			if (array == null)
			{
				throw new ArgumentNullException(nameof(array));
			}

			if (arrayIndex < 0 || arrayIndex >= array.Length || arrayIndex >= Count)
			{
				throw new ArgumentOutOfRangeException(nameof(arrayIndex));
			}

			dict.Keys.CopyTo(array, arrayIndex);
		}

		/// <inheritdoc/>
		public void ExceptWith(IEnumerable<T> other)
		{
			if (other == null)
			{
				throw new ArgumentNullException(nameof(other));
			}

			if (Count == 0)
			{
				return;
			}

			if (other == this)
			{
				Clear();
				return;
			}
			foreach (T elem in other)
			{
				dict.Remove(elem);
			}
		}

		/// <inheritdoc/>
		public IEnumerator<T> GetEnumerator()
		{
			return dict.Keys.GetEnumerator();
		}

		/// <inheritdoc/>
		public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			if (info == null)
			{
				throw new ArgumentNullException(nameof(info));
			}

			dict.GetObjectData(info, context);
		}

		/// <inheritdoc/>
		public void IntersectWith(IEnumerable<T> other)
		{
			if (other == null)
			{
				throw new ArgumentNullException(nameof(other));
			}

			if (other is ICollection<T> c && c.Count == 0)
			{
				Clear();
				return;
			}

			var l = this.ToList();
			foreach (var elem in l)
			{
				if (!other.Contains(elem))
				{
					Remove(elem);
				}
			}
		}

		/// <inheritdoc/>
		public bool IsProperSubsetOf(IEnumerable<T> other)
		{
			if (other == null)
			{
				throw new ArgumentNullException(nameof(other));
			}

			if (Count == 0 && other is ICollection<T> c)
			{
				return c.Count > 0;
			}

			CheckUniqueAndUnfoundElements(other, out int unique, out int unfound, false);
			return unique == Count && unfound > 0;
		}

		/// <inheritdoc/>
		public bool IsProperSupersetOf(IEnumerable<T> other)
		{
			if (other == null)
			{
				throw new ArgumentNullException(nameof(other));
			}

			if (Count == 0)
			{
				return false;
			}

			if (other is ICollection<T> c && c.Count == 0)
			{
				return true;
			}

			CheckUniqueAndUnfoundElements(other, out int unique, out int unfound, true);
			return unique < Count && unfound == 0;
		}

		/// <inheritdoc/>
		public bool IsSubsetOf(IEnumerable<T> other)
		{
			if (other == null)
			{
				throw new ArgumentNullException(nameof(other));
			}

			if (Count == 0)
			{
				return true;
			}

			CheckUniqueAndUnfoundElements(other, out int unique, out int unfound, false);
			return unique == Count && unfound >= 0;
		}

		/// <inheritdoc/>
		public bool IsSupersetOf(IEnumerable<T> other)
		{
			if (other == null)
			{
				throw new ArgumentNullException(nameof(other));
			}

			if (other is ICollection<T> c && c.Count == 0)
			{
				return true;
			}

			foreach (T elem in other)
			{
				if (!Contains(elem))
				{
					return false;
				}
			}

			return true;
		}

		/// <inheritdoc/>
		public virtual void OnDeserialization(object sender)
		{
			dict.OnDeserialization(sender);
		}

		/// <inheritdoc/>
		public bool Overlaps(IEnumerable<T> other)
		{
			if (other == null)
			{
				throw new ArgumentNullException(nameof(other));
			}

			if (Count == 0)
			{
				return false;
			}

			foreach (T elem in other)
			{
				if (Contains(elem))
				{
					return true;
				}
			}

			return false;
		}

		/// <inheritdoc/>
		public bool Remove(T item)
		{
			return item != null && dict.Remove(item);
		}

		/// <inheritdoc/>
		public bool SetEquals(IEnumerable<T> other)
		{
			if (other == null)
			{
				throw new ArgumentNullException(nameof(other));
			}

			if (other is ICollection<T> c && c.Count != Count)
			{
				return false;
			}

			CheckUniqueAndUnfoundElements(other, out int unique, out int unfound, true);
			return unique == Count && unfound == 0;
		}

		/// <inheritdoc/>
		public void SymmetricExceptWith(IEnumerable<T> other)
		{
			if (other == null)
			{
				throw new ArgumentNullException(nameof(other));
			}

			if (Count == 0)
			{
				UnionWith(other);
				return;
			}
			if (other == this)
			{
				Clear();
				return;
			}

			HashSet<T> oh = new HashSet<T>(other, Comparer);
			List<T> dup = this.ToList();
			ExceptWith(oh);
			oh.ExceptWith(dup);
			UnionWith(oh);
		}

		/// <summary>Searches the set for a given value and returns the equal value it finds, if any.</summary>
		/// <param name="equalValue">The value to search for.</param>
		/// <param name="actualValue">
		/// The value from the set that the search found, or the default value of T when the search yielded no match.
		/// </param>
		/// <returns>A value indicating whether the search was successful.</returns>
		/// <remarks>
		/// This can be useful when you want to reuse a previously stored reference instead of a newly constructed one (so that more sharing
		/// of references can occur) or to look up a value that has more complete data than the value you currently have, although their
		/// comparer functions indicate they are equal.
		/// </remarks>
		public bool TryGetValue(T equalValue, out T actualValue)
		{
			foreach (T k in dict.Keys)
			{
				if (!Comparer.Equals(k, equalValue))
				{
					continue;
				}

				actualValue = k;
				return true;
			}
			actualValue = default(T);
			return false;
		}

		/// <inheritdoc/>
		public void UnionWith(IEnumerable<T> other)
		{
			if (other == null)
			{
				throw new ArgumentNullException(nameof(other));
			}

			if (this == other)
			{
				return;
			}

			foreach (T elem in other)
			{
				Add(elem);
			}
		}

		/// <inheritdoc/>
		void ICollection<T>.Add(T item)
		{
			Add(item);
		}

		/// <inheritdoc/>
		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		private void CheckUniqueAndUnfoundElements(IEnumerable<T> other, out int unique, out int unfound, bool returnIfUnfound)
		{
			if (Count == 0)
			{
				unique = 0;
				unfound = other.Any() ? 1 : 0;
				return;
			}

			unfound = 0;
			unique = 0;
			List<T> l = this.ToList();
			BitArray bits = new BitArray(l.Count);
			foreach (T o in other)
			{
				int index = l.IndexOf(o);
				if (index >= 0)
				{
					if (bits[index])
					{
						continue;
					}
					// item hasn't been seen yet
					bits[index] = true;
					unique++;
				}
				else
				{
					unfound++;
					if (returnIfUnfound)
					{
						break;
					}
				}
			}
		}
	}
}
#endif