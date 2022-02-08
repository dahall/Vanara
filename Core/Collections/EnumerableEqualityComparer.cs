using System.Collections.Generic;
using System.Linq;

namespace Vanara.Collections
{
	/// <summary>
	/// Checks the linear equality of two enumerated lists. For lists to be equal, they must have the same number of elements and each index
	/// must hold the same value in each list.
	/// </summary>
	/// <typeparam name="T">The element type in the list.</typeparam>
	public sealed class EnumerableEqualityComparer<T> : IEqualityComparer<IEnumerable<T>>
	{
		private static readonly EqualityComparer<T> elementComparer = EqualityComparer<T>.Default;

		/// <summary>Determines whether the specified lists are equal.</summary>
		/// <param name="first">The first list of type T to compare.</param>
		/// <param name="second">The second list of type T to compare.</param>
		/// <returns><see langword="true"/> if the two lists are equal; <see langword="false"/> otherwise.</returns>
		public bool Equals(IEnumerable<T> first, IEnumerable<T> second)
		{
			if (ReferenceEquals(first, second))
				return true;
			if (first is null || second is null)
				return false;
			var e1 = first.GetEnumerator();
			var e2 = second.GetEnumerator();
			bool move1, move2 = false;
			while ((move1 = e1.MoveNext()) && (move2 = e2.MoveNext()))
			{
				if (!elementComparer.Equals(e1.Current, e2.Current))
					return false;
			}
			return move1 == move2;
		}

		/// <summary>Returns a hash code for the specified object.</summary>
		/// <param name="list">The Object for which a hash code is to be returned.</param>
		/// <returns>A hash code for the specified object.</returns>
		public int GetHashCode(IEnumerable<T> list)
		{
			unchecked
			{
				return list is null ? 0 : list.Aggregate(17, (s, e) => s * 31 + elementComparer.GetHashCode(e));
			}
		}
	}
}