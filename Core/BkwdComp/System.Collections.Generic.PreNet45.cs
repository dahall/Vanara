#if (NET20 || NET35 || NET40)
namespace System.Collections.Generic
{
	/// <summary>Represents a strongly-typed, read-only collection of elements.</summary>
	/// <typeparam name="T">The type of the elements.</typeparam>
	/// <seealso cref="System.Collections.Generic.IEnumerable{T}"/>
	public interface IReadOnlyCollection<T> : IEnumerable<T>
	{
		/// <summary>Gets the number of elements in the collection.</summary>
		/// <value>The number of elements in the collection.</value>
		int Count { get; }
	}

	/// <summary>Represents a read-only collection of elements that can be accessed by index.</summary>
	/// <typeparam name="T">The type of elements in the read-only list.</typeparam>
	/// <seealso cref="System.Collections.Generic.IReadOnlyCollection{T}"/>
	public interface IReadOnlyList<T> : IReadOnlyCollection<T>
	{
		/// <summary>Gets the element at the specified index in the read-only list.</summary>
		/// <value>The element at the specified index in the read-only list.</value>
		/// <param name="index">The zero-based index of the element to get.</param>
		T this[int index] { get; }
	}
}
#endif