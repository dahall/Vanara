using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Vanara.Collections
{
	/// <summary>
	/// Creates an enumerable class from a counter and an indexer. Useful if a class doesn't support <see cref="IEnumerable"/> or <see cref="IEnumerable{T}"/>
	/// like some COM objects.
	/// </summary>
	/// <typeparam name="TItem">The type of the item.</typeparam>
	public class IEnumFromIndexer<TItem> : IReadOnlyList<TItem>
	{
		private readonly Func<uint> getCount;
		private readonly Func<uint, TItem> indexer;
		private readonly uint startIndex;

		/// <summary>Initializes a new instance of the <see cref="IEnumFromIndexer{TItem}" /> class.</summary>
		/// <param name="getCount">The method used to get the total count of items.</param>
		/// <param name="indexer">The method used to get a single item.</param>
		/// <param name="startIndex">The index at which the collection begins (usually 1 or 0).</param>
		public IEnumFromIndexer(Func<uint> getCount, Func<uint, TItem> indexer, uint startIndex = 0)
		{
			if (getCount == null || indexer == null) throw new ArgumentNullException();
			this.getCount = getCount;
			this.indexer = indexer;
			this.startIndex = startIndex;
		}

		/// <summary>Gets the number of elements in the collection.</summary>
		/// <value>The number of elements in the collection.</value>
		public int Count => (int)getCount();

		/// <summary>Gets the item at the specified zero-based index.</summary>
		/// <value>The item.</value>
		/// <param name="index">The zero-based index.</param>
		/// <returns>The item at the specified zero-based index.</returns>
		public TItem this[int index] => indexer((uint)index + startIndex);

		/// <summary>Returns an enumerator that iterates through the collection.</summary>
		/// <returns>A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.</returns>
		public IEnumerator<TItem> GetEnumerator() => new Enumerator(this);

		/// <summary>Returns an enumerator that iterates through a collection.</summary>
		/// <returns>An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.</returns>
		[ExcludeFromCodeCoverage]
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		private class Enumerator : IEnumerator<TItem>
		{
			private uint i;
			private IEnumFromIndexer<TItem> ienum;
			public Enumerator(IEnumFromIndexer<TItem> ienum) { this.ienum = ienum; ((IEnumerator)this).Reset(); }
			bool IEnumerator.MoveNext() => ienum != null && ++i < ienum.getCount() + ienum.startIndex;
			void IEnumerator.Reset() { if (ienum != null) i = ienum.startIndex - 1; }
			TItem IEnumerator<TItem>.Current => ienum == null ? default(TItem) : ienum.indexer(i);
			[ExcludeFromCodeCoverage]
			object IEnumerator.Current => ((IEnumerator<TItem>)this).Current;
			void IDisposable.Dispose() { ienum = null; }
		}
	}

	/// <summary>
	/// Creates an enumerable class from a get next method and a reset method. Useful if a class doesn't support <see cref="IEnumerable"/> or <see cref="IEnumerable{T}"/>
	/// like some COM objects.
	/// </summary>
	/// <typeparam name="TItem">The type of the item.</typeparam>
	public class IEnumFromNext<TItem> : IEnumerable<TItem>
	{
		private readonly TryGetNext next;
		private readonly Action reset;

		/// <summary>Delegate that gets the next value in an enumeration and returns true or returns false to indicate there are no more items in the enumeration.</summary>
		/// <param name="value">The value, on success, of the next item.</param>
		/// <returns><c>true</c> if an item is returned, otherwise <c>false</c>.</returns>
		public delegate bool TryGetNext(out TItem value);

		/// <summary>Initializes a new instance of the <see cref="IEnumFromNext{TItem}" /> class.</summary>
		/// <param name="next">The method used to try to get the next item in the enumeration.</param>
		/// <param name="reset">The method used to reset the enumeration to the first element.</param>
		public IEnumFromNext(TryGetNext next, Action reset)
		{
			if (next == null || reset == null) throw new ArgumentNullException();
			this.next = next;
			this.reset = reset;
		}

		/// <summary>Returns an enumerator that iterates through the collection.</summary>
		/// <returns>A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.</returns>
		public IEnumerator<TItem> GetEnumerator() => new Enumerator(this);

		/// <summary>Returns an enumerator that iterates through a collection.</summary>
		/// <returns>An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.</returns>
		[ExcludeFromCodeCoverage]
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		private class Enumerator : IEnumerator<TItem>
		{
			private IEnumFromNext<TItem> ienum;
			public Enumerator(IEnumFromNext<TItem> ienum) { this.ienum = ienum; ((IEnumerator)this).Reset(); }
			bool IEnumerator.MoveNext()
			{
				if (ienum == null || !ienum.next(out TItem p)) return false;
				Current = p;
				return true;
			}
			void IEnumerator.Reset()
			{
				if (ienum == null) return;
				ienum.reset();
				Current = default(TItem);
			}
			public TItem Current { get; private set; }
			[ExcludeFromCodeCoverage]
			object IEnumerator.Current => Current;
			void IDisposable.Dispose() { ienum = null; }
		}
	}
}