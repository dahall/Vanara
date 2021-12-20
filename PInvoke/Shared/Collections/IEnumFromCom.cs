using System;
using System.Collections;
using System.Collections.Generic;
using Vanara.PInvoke;

namespace Vanara.Collections
{
	/// <summary>A generic interface to identify matching COM enumerator interfaces</summary>
	/// <typeparam name="TElem">The type of the elem.</typeparam>
	public interface ICOMEnum<TElem>
	{
		/*
		/// <summary>Retrieves the specified number of items in the enumeration sequence.</summary>
		/// <param name="celt">
		/// The number of items to be retrieved. If there are fewer than the requested number of items left in the sequence, this method
		/// retrieves the remaining elements.
		/// </param>
		/// <param name="rgelt">
		/// <para>An array of enumerated items.</para>
		/// <para>
		/// The enumerator is responsible for calling AddRef, and the caller is responsible for calling Release through each pointer
		/// enumerated. If celt is greater than 1, the caller must also pass a non-NULL pointer passed to pceltFetched to know how many
		/// pointers to release.
		/// </para>
		/// </param>
		/// <param name="pceltFetched">
		/// The number of items that were retrieved. This parameter is always less than or equal to the number of items requested.
		/// </param>
		/// <returns>If the method retrieves the number of items requested, the return value is S_OK. Otherwise, it is S_FALSE.</returns>
		HRESULT Next(uint celt, TElem[] rgelt, out uint pceltFetched);

		/// <summary>Skips over the specified number of items in the enumeration sequence.</summary>
		/// <param name="celt">The number of items to be skipped.</param>
		/// <returns>If the method skips the number of items requested, the return value is S_OK. Otherwise, it is S_FALSE.</returns>
		HRESULT Skip(uint celt);

		/// <summary>Resets the enumeration sequence to the beginning.</summary>
		/// <remarks>
		/// There is no guarantee that the same set of objects will be enumerated after the reset operation has completed. A static
		/// collection is reset to the beginning, but it can be too expensive for some collections, such as files in a directory, to
		/// guarantee this condition.
		/// </remarks>
		void Reset();
		*/
	}

	/// <summary>
	/// Creates an enumerable class from a get next method in the form of HRESULT Next(uint, TItem[], out uint) and a reset method. Useful
	/// if a class doesn't support <see cref="IEnumerable"/> or <see cref="IEnumerable{T}"/> like some COM objects.
	/// </summary>
	/// <typeparam name="TItem">The type of the item.</typeparam>
	public class IEnumFromCom<TItem> : IEnumFromNext<TItem> where TItem : new()
	{
		private readonly ComTryGetNext cnext;

		/// <summary>Initializes a new instance of the <see cref="IEnumFromNext{TItem}"/> class.</summary>
		/// <param name="next">The method used to try to get the next item in the enumeration.</param>
		/// <param name="reset">The method used to reset the enumeration to the first element.</param>
		public IEnumFromCom(ComTryGetNext next, Action reset) : base()
		{
			if (next is null || reset is null)
				throw new ArgumentNullException();
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
		/// <paramref name="celt"/> parameter. S_FALSE = The number of items returned is less than the number specified in the <paramref
		/// name="celt"/> parameter.
		/// </returns>
		public delegate HRESULT ComTryGetNext(uint celt, TItem[] rgelt, out uint celtFetched);

		/// <summary>Initializes a new instance of the <see cref="IEnumFromCom{TItem}"/> class from a COM enumeration interface instance.</summary>
		/// <param name="enumObj">The COM enumeration interface instance.</param>
		public static IEnumFromCom<TItem> Create<TIntf>(TIntf enumObj) where TIntf : class, ICOMEnum<TItem>
		{
			if (enumObj is null)
				throw new ArgumentNullException(nameof(enumObj));
			var cew = new ComEnumWrapper<TIntf>(enumObj);
			return new IEnumFromCom<TItem>(cew.ComObjTryGetNext, cew.ComObjReset);
		}

		private bool TryGet(out TItem item)
		{
			var res = new TItem[] { new TItem() };
			item = default;
			if (cnext(1, res, out var ret) != HRESULT.S_OK)
				return false;
			item = res[0];
			return true;
		}

		private class ComEnumWrapper<T> where T : class, ICOMEnum<TItem>
		{
			private readonly T obj;

			public ComEnumWrapper(T o) => obj = o;

			public void ComObjReset() => ComInvoke("Reset");

			public HRESULT ComObjTryGetNext(uint celt, TItem[] rgelt, out uint celtFetched)
			{
				var para = new object[] { celt, rgelt, 0U };
				var hr = (HRESULT)ComInvoke("Next", para);
				celtFetched = (uint)para[2];
				return hr;
			}

			private object ComInvoke(string meth, object[] p = null) => typeof(T).GetMethod(meth).Invoke(obj, p);
		}
	}
}