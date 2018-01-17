using System.Collections.Generic;

namespace Vanara.Collections
{
	/// <summary>
	/// Checks the linear equality of two enumerated lists. For lists to be equal, they must have the same number of elements and each index must hold the same value in
	/// each list.
	/// </summary>
	/// <typeparam name="T">The element type in the list.</typeparam>
	public sealed class EnumerableEqualityComparer<T> : IEqualityComparer<IEnumerable<T>>
	{
		private static readonly EqualityComparer<T> elementComparer = EqualityComparer<T>.Default;

		/// <summary>Determines whether the specified lists are equal.</summary>
		/// <param name="first">The first list of type T to compare.</param>
		/// <param name="second">The second list of type T to compare.</param>
		/// <returns></returns>
		public bool Equals(IEnumerable<T> first, IEnumerable<T> second)
		{
			if (ReferenceEquals(first, second))
				return true;
			if (first == null || second == null)
				return false;
			var e1 = first.GetEnumerator();
			var e2 = second.GetEnumerator();
			bool move1 = false, move2 = false;
			while ((move1 = e1.MoveNext()) && (move2 = e1.MoveNext()))
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
				if (list == null)
					return 0;
				var hash = 17;
				foreach (T element in list)
					hash = hash * 31 + elementComparer.GetHashCode(element);
				return hash;
			}
		}
	}
}