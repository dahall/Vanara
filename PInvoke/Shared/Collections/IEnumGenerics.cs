using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Vanara.PInvoke;

namespace Vanara.Collections
{
	/// <summary>
	/// Creates an enumerable class from a get next method in the form of HRESULT Next(uint, TItem[], out uint) and a reset method. Useful if
	/// a class doesn't support <see cref="IEnumerable"/> or <see cref="IEnumerable{T}"/> like some COM objects.
	/// </summary>
	/// <typeparam name="TItem">The type of the item.</typeparam>
	public class IEnumFromCom<TItem> : IEnumFromNext<TItem>
	{
		private readonly ComTryGetNext cnext;

		/// <summary>Initializes a new instance of the <see cref="IEnumFromNext{TItem}"/> class.</summary>
		/// <param name="next">The method used to try to get the next item in the enumeration.</param>
		/// <param name="reset">The method used to reset the enumeration to the first element.</param>
		public IEnumFromCom(ComTryGetNext next, Action reset) : base()
		{
			if (next == null || reset == null) throw new ArgumentNullException();
			cnext = next;
			base.next = TryGet;
			base.reset = reset;
		}

		/// <summary>
		/// Delegate that gets the next value in an enumeration and returns true or returns false to indicate there are no more items in the enumeration.
		/// </summary>
		/// <param name="celt">The number of items requested.</param>
		/// <param name="rgelt">An array of items to be returned.</param>
		/// <param name="celtFetched">The number of items retrieved in the <paramref name="celt"/> parameter.</param>
		/// <returns>
		/// This method supports the following return values: S_OK = The number of items returned is equal to the number specified in the
		/// <paramref name="celt"/> parameter. S_FALSE = The number of items returned is less than the number specified in the
		/// <paramref name="celt"/> parameter.
		/// </returns>
		public delegate HRESULT ComTryGetNext(uint celt, TItem[] rgelt, out uint celtFetched);

		private bool TryGet(out TItem item)
		{
			var res = new TItem[1];
			item = default;
			if (cnext(1, res, out var ret).Failed)
				return false;
			item = res[0];
			return true;
		}
	}

	/// <summary>
	/// Creates an enumerable class from a counter and an indexer. Useful if a class doesn't support <see cref="IEnumerable"/> or
	/// <see cref="IEnumerable{T}"/> like some COM objects.
	/// </summary>
	/// <typeparam name="TItem">The type of the item.</typeparam>
	public class IEnumFromIndexer<TItem> : IReadOnlyList<TItem>
	{
		private readonly Func<uint> getCount;
		private readonly Func<uint, TItem> indexer;
		private readonly uint startIndex;

		/// <summary>Initializes a new instance of the <see cref="IEnumFromIndexer{TItem}"/> class.</summary>
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

			public Enumerator(IEnumFromIndexer<TItem> ienum)
			{
				this.ienum = ienum; ((IEnumerator)this).Reset();
			}

			TItem IEnumerator<TItem>.Current => ienum == null ? default : ienum.indexer(i);

			[ExcludeFromCodeCoverage]
			object IEnumerator.Current => ((IEnumerator<TItem>)this).Current;

			void IDisposable.Dispose() => ienum = null;

			bool IEnumerator.MoveNext() => ienum != null && ++i < ienum.getCount() + ienum.startIndex;

			void IEnumerator.Reset()
			{
				if (ienum != null) i = ienum.startIndex - 1;
			}
		}
	}

	/// <summary>
	/// Creates an enumerable class from a get next method and a reset method. Useful if a class doesn't support <see cref="IEnumerable"/> or
	/// <see cref="IEnumerable{T}"/> like some COM objects.
	/// </summary>
	/// <typeparam name="TItem">The type of the item.</typeparam>
	public class IEnumFromNext<TItem> : IEnumerable<TItem>
	{
		/// <summary>The next function delegate.</summary>
		protected TryGetNext next;

		/// <summary>The reset function delegate.</summary>
		protected Action reset;

		/// <summary>Initializes a new instance of the <see cref="IEnumFromNext{TItem}"/> class.</summary>
		/// <param name="next">The method used to try to get the next item in the enumeration.</param>
		/// <param name="reset">The method used to reset the enumeration to the first element.</param>
		public IEnumFromNext(TryGetNext next, Action reset)
		{
			if (next == null || reset == null) throw new ArgumentNullException();
			this.next = next;
			this.reset = reset;
		}

		/// <summary>Initializes a new instance of the <see cref="IEnumFromNext{TItem}"/> class.</summary>
		protected IEnumFromNext() { }

		/// <summary>
		/// Delegate that gets the next value in an enumeration and returns true or returns false to indicate there are no more items in the enumeration.
		/// </summary>
		/// <param name="value">The value, on success, of the next item.</param>
		/// <returns><c>true</c> if an item is returned, otherwise <c>false</c>.</returns>
		public delegate bool TryGetNext(out TItem value);

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

			public Enumerator(IEnumFromNext<TItem> ienum)
			{
				this.ienum = ienum; ((IEnumerator)this).Reset();
			}

			public TItem Current { get; private set; }

			[ExcludeFromCodeCoverage]
			object IEnumerator.Current => Current;

			void IDisposable.Dispose() => ienum = null;

			bool IEnumerator.MoveNext()
			{
				if (ienum == null || !ienum.next(out var p)) return false;
				Current = p;
				return true;
			}

			void IEnumerator.Reset()
			{
				if (ienum == null) return;
				ienum.reset();
				Current = default;
			}
		}
	}
}