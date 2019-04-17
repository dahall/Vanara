using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Vanara.Extensions;

namespace Vanara.InteropServices
{
	/// <summary>
	/// A safe unmanaged array of structures allocated on the global heap. Array size determined by allocated memory size divided by size of structure.
	/// </summary>
	public class SafeNativeArray<TElem> : SafeMemoryHandle<HGlobalMemoryMethods>, IList<TElem> where TElem : unmanaged
	{
		private static readonly int ElemSize = Marshal.SizeOf(typeof(TElem));

		/// <summary>Initializes a new instance of the <see cref="SafeNativeArray{TElem}"/> class.</summary>
		public SafeNativeArray() : base(0) { }

		/// <summary>Initializes a new instance of the <see cref="SafeNativeArray{TElem}"/> class from a copy of a managed TElem array.</summary>
		/// <param name="array">The array of bytes to copy.</param>
		public SafeNativeArray(TElem[] array) : base(IntPtr.Zero, 0, true) => Elements = array;

		/// <summary>Initializes a new instance of the <see cref="SafeNativeArray{TElem}"/> class.</summary>
		/// <param name="elementCount">The element count. This value can be 0.</param>
		public SafeNativeArray(int elementCount) : base(GetRequiredSize(elementCount)) => Zero();

		/// <summary>Initializes a new instance of the <see cref="SafeNativeArray{TElem}"/> class.</summary>
		/// <param name="ptr">The PTR.</param>
		/// <param name="size">The size.</param>
		/// <param name="ownsHandle">if set to <c>true</c> [owns handle].</param>
		public SafeNativeArray(IntPtr ptr, int size, bool ownsHandle) : base(ptr, size, ownsHandle) { }

		/// <summary>Gets the number of elements contained in the <see cref="SafeNativeArray{TElem}"/>.</summary>
		public int Count => IsInvalid ? 0 : BytesToCount(Size);

		/// <summary>Gets a value indicating whether the <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only.</summary>
		public bool IsReadOnly => false;

		/// <summary>Gets or sets the elements.</summary>
		/// <value>The elements of the array.</value>
		protected TElem[] Elements
		{
			get => handle.ToArray<TElem>(Count);
			set
			{
				Size = GetRequiredSize(value.Length);
				value.MarshalToPtr(handle);
			}
		}

		/// <summary>Gets or sets the <typeparamref name="TElem"/> value at the specified index.</summary>
		/// <value>The <typeparamref name="TElem"/> value.</value>
		/// <param name="index">The index.</param>
		/// <returns></returns>
		/// <exception cref="ArgumentOutOfRangeException">index or index</exception>
		public TElem this[int index]
		{
			get => (index >= 0 && index < Count) ? handle.Offset(index * ElemSize).ToStructure<TElem>() : throw new ArgumentOutOfRangeException(nameof(index));
			set { if (index >= 0 && index < Count) Marshal.StructureToPtr(value, handle.Offset(index * ElemSize), false); else throw new ArgumentOutOfRangeException(nameof(index)); }
		}

		/// <summary>Adds an item to the <see cref="T:System.Collections.Generic.ICollection`1"/>.</summary>
		/// <param name="item">The object to add to the <see cref="T:System.Collections.Generic.ICollection`1"/>.</param>
		public void Add(TElem item) => Insert(Count, item);

		/// <summary>Removes all items from the <see cref="T:System.Collections.Generic.ICollection`1"/>.</summary>
		public void Clear() => Size = 0;

		/// <summary>Determines whether this instance contains the object.</summary>
		/// <param name="item">The object to locate in the <see cref="T:System.Collections.Generic.ICollection`1"/>.</param>
		/// <returns>
		/// true if <paramref name="item"/> is found in the <see cref="T:System.Collections.Generic.ICollection`1"/>; otherwise, false.
		/// </returns>
		public bool Contains(TElem item) => EnumElements().Contains(item);

		/// <summary>
		/// Copies the elements of the <see cref="T:System.Collections.Generic.ICollection`1"/> to an <see cref="T:System.Array"/>, starting
		/// at a particular <see cref="T:System.Array"/> index.
		/// </summary>
		/// <param name="array">
		/// The one-dimensional <see cref="T:System.Array"/> that is the destination of the elements copied from
		/// <see cref="T:System.Collections.Generic.ICollection`1"/>. The <see cref="T:System.Array"/> must have zero-based indexing.
		/// </param>
		/// <param name="arrayIndex">The zero-based index in <paramref name="array"/> at which copying begins.</param>
		public void CopyTo(TElem[] array, int arrayIndex) => ((IList<TElem>)Elements).CopyTo(array, arrayIndex);

		/// <summary>Returns an enumerator that iterates through the collection.</summary>
		/// <returns>A <see cref="IEnumerator{TElem}"/> that can be used to iterate through the collection.</returns>
		public IEnumerator<TElem> GetEnumerator() => EnumElements().GetEnumerator();

		/// <summary>Determines the index of a specific item in the <see cref="T:System.Collections.Generic.IList`1"/>.</summary>
		/// <param name="item">The object to locate in the <see cref="T:System.Collections.Generic.IList`1"/>.</param>
		/// <returns>The index of <paramref name="item"/> if found in the list; otherwise, -1.</returns>
		public int IndexOf(TElem item) => ((IList<TElem>)Elements).IndexOf(item);

		/// <summary>Inserts an item to the <see cref="T:System.Collections.Generic.IList`1"/> at the specified index.</summary>
		/// <param name="index">The zero-based index at which <paramref name="item"/> should be inserted.</param>
		/// <param name="item">The object to insert into the <see cref="T:System.Collections.Generic.IList`1"/>.</param>
		/// <exception cref="ArgumentOutOfRangeException">index</exception>
		public void Insert(int index, TElem item)
		{
			if (index < 0 || index > Count) throw new ArgumentOutOfRangeException(nameof(index));
			var newSz = GetRequiredSize(Count + 1);
			var newPtr = mm.AllocMem(newSz);
			var insertPt = GetRequiredSize(index);
			if (index > 0)
				CopyTo(newPtr, 0, insertPt);
			Marshal.StructureToPtr(item, newPtr.Offset(insertPt), false);
			if (index < Count)
				CopyTo(newPtr.Offset(insertPt + ElemSize), insertPt);
			mm.FreeMem(handle);
			SetHandle(newPtr);
			sz = newSz;
		}

		/// <summary>Removes the first occurrence of a specific object from the <see cref="T:System.Collections.Generic.ICollection`1"/>.</summary>
		/// <param name="item">The object to remove from the <see cref="T:System.Collections.Generic.ICollection`1"/>.</param>
		/// <returns>
		/// true if <paramref name="item"/> was successfully removed from the <see cref="T:System.Collections.Generic.ICollection`1"/>;
		/// otherwise, false. This method also returns false if <paramref name="item"/> is not found in the original <see cref="T:System.Collections.Generic.ICollection`1"/>.
		/// </returns>
		public bool Remove(TElem item)
		{
			var idx = IndexOf(item);
			if (idx == -1) return false;
			RemoveAt(idx);
			return true;
		}

		/// <summary>Removes the <see cref="T:System.Collections.Generic.IList`1"/> item at the specified index.</summary>
		/// <param name="index">The zero-based index of the item to remove.</param>
		/// <exception cref="ArgumentOutOfRangeException">index</exception>
		public void RemoveAt(int index)
		{
			if (index < 0 || index >= Count) throw new ArgumentOutOfRangeException(nameof(index));
			var insertPt = GetRequiredSize(index);
			CopyTo(handle.Offset(insertPt), insertPt + ElemSize);
			sz -= ElemSize;
		}

		/// <summary>Returns an enumerator that iterates through a collection.</summary>
		/// <returns>An <see cref="IEnumerator"/> object that can be used to iterate through the collection.</returns>
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		/// <summary>Converts a byte count to a element count.</summary>
		/// <param name="byteSize">The byte count.</param>
		/// <returns>The converted element count.</returns>
		/// <exception cref="ArgumentException">Byte count does not match this structure.</exception>
		protected static int BytesToCount(int byteSize)
		{
			if (byteSize % ElemSize != 0) throw new ArgumentException("Byte count does not match this structure.");
			return byteSize / ElemSize;
		}

		/// <summary>Copies the values of this array to another native memory pointer.</summary>
		/// <param name="ptr">The PTR.</param>
		/// <param name="start">The start.</param>
		/// <param name="length">The length.</param>
		/// <exception cref="ArgumentOutOfRangeException"></exception>
		protected void CopyTo(IntPtr ptr, int start = 0, int length = -1)
		{
			unsafe
			{
				if (start > Size || start < 0) throw new ArgumentOutOfRangeException();
				if (length == -1) length = Size - start;
				if (length + start > Size || length + start < 0) throw new ArgumentOutOfRangeException();
				var old = (byte*)handle;
				var newer = (byte*)ptr;
				for (var i = start; i < start + length; i++)
					newer[i - start] = old[i];
			}
		}

		/// <summary>Enumerates the elements.</summary>
		/// <returns>An enumeration of values from the pointer.</returns>
		protected IEnumerable<TElem> EnumElements() => handle.ToIEnum<TElem>(Count);

		private static int GetRequiredSize(int elementCount) => ElemSize * elementCount;
	}
}