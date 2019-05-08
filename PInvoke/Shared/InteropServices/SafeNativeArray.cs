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
	/// <typeparam name="TElem">The type of the array elements.</typeparam>
	public class SafeNativeArray<TElem> : SafeNativeArrayBase<TElem, HGlobalMemoryMethods> where TElem : struct
	{
		/// <summary>Initializes a new instance of the <see cref="SafeNativeArray{TElem}"/> class.</summary>
		public SafeNativeArray() : base(0, 0) { }

		/// <summary>Initializes a new instance of the <see cref="SafeNativeArray{TElem}"/> class from a copy of a managed TElem array.</summary>
		/// <param name="array">The array of bytes to copy.</param>
		public SafeNativeArray(TElem[] array) : base(array, 0) { }

		/// <summary>Initializes a new instance of the <see cref="SafeNativeArray{TElem}"/> class.</summary>
		/// <param name="elementCount">The element count. This value can be 0.</param>
		public SafeNativeArray(int elementCount) : base((uint)(ElemSize * elementCount), 0) { }

		/// <summary>Initializes a new instance of the <see cref="SafeNativeArray{TElem}"/> class.</summary>
		/// <param name="ptr">The handle.</param>
		/// <param name="size">The size of memory allocated to the handle, in bytes.</param>
		/// <param name="ownsHandle">if set to <c>true</c> if this class is responsible for freeing the memory on disposal.</param>
		public SafeNativeArray(IntPtr ptr, int size, bool ownsHandle) : base(ptr, (uint)size, ownsHandle) { }

		/// <summary>Creates a new instance of the <see cref="SafeNativeArray{TElem}"/> class using a byte count.</summary>
		/// <param name="byteCount">The number of bytes to allocate for this new array.</param>
		public static SafeNativeArray<TElem> FromByteCount(int byteCount)
		{
			if (byteCount % ElemSize != 0) throw new ArgumentException($"{nameof(byteCount)} parameter must be a multiple of the size of structure {nameof(TElem)}.");
			return new SafeNativeArray<TElem>(byteCount / ElemSize);
		}
	}

	/// <summary>A safe unmanaged array of structures. Array size determined by size of structure.</summary>
	/// <typeparam name="TElem">The type of the array elements.</typeparam>
	/// <typeparam name="TMem">The type of the memory allocation functions to use.</typeparam>
	public class SafeNativeArrayBase<TElem, TMem> : SafeMemoryHandle<TMem>, IList<TElem> where TElem : struct where TMem : IMemoryMethods, new()
	{
		/// <summary>Gets the size of the element.</summary>
		protected static readonly int ElemSize = Marshal.SizeOf(typeof(TElem));

		/// <summary>Initializes a new instance of the <see cref="SafeNativeArray{TElem}"/> class from a copy of a managed TElem array.</summary>
		/// <param name="array">The array of <typeparamref name="TElem"/> with which to initialize the <see cref="SafeNativeArrayBase{TElem, TMem}"/>.</param>
		/// <param name="headerSize">
		/// The number of bytes to allocate in front of the array allocation. This may be used to write the element count or other values
		/// using the <see cref="OnUpdateHeader"/> event.
		/// </param>
		public SafeNativeArrayBase(TElem[] array, uint headerSize = 0) : this((uint)GetRequiredSize(array?.Length ?? 0, headerSize), headerSize) => Elements = array;

		/// <summary>Initializes a new instance of the <see cref="SafeNativeArray{TElem}"/> class.</summary>
		/// <param name="ptr">The handle.</param>
		/// <param name="size">The size of memory allocated to the handle, in bytes.</param>
		/// <param name="ownsHandle">if set to <c>true</c> if this class is responsible for freeing the memory on disposal.</param>
		/// <param name="headerSize">
		/// The number of bytes to allocate in front of the array allocation. This may be used to write the element count or other values
		/// using the <see cref="OnUpdateHeader"/> event.
		/// </param>
		public SafeNativeArrayBase(IntPtr ptr, uint size, bool ownsHandle = true, uint headerSize = 0) : base(ptr, (int)size, ownsHandle) { HeaderSize = headerSize; Count = GetElemCountFromBytes(size, headerSize); OnUpdateHeader(); }

		/// <summary>Initializes a new instance of the <see cref="SafeNativeArray{TElem}"/> class.</summary>
		/// <param name="byteCount">The number of bytes to allocate for this new array.</param>
		/// <param name="headerSize">
		/// The number of bytes to allocate in front of the array allocation. This may be used to write the element count or other values
		/// using the <see cref="OnUpdateHeader"/> event.
		/// </param>
		protected SafeNativeArrayBase(uint byteCount, uint headerSize = 0) : base((int)byteCount) { HeaderSize = headerSize; Count = GetElemCountFromBytes(byteCount, headerSize); OnUpdateHeader(); }

		/// <summary>Gets the number of elements contained in the <see cref="SafeNativeArray{TElem}"/>.</summary>
		public virtual int Count { get; protected set; }

		/// <summary>Gets the size, in bytes, of the header.</summary>
		/// <value>The size of the header.</value>
		public uint HeaderSize { get; }

		/// <summary>Gets a value indicating whether the <see cref="T:System.Collections.Generic.ICollection`1"/> is read-only.</summary>
		public bool IsReadOnly => false;

		/// <summary>Gets or sets the elements.</summary>
		/// <value>The elements of the array.</value>
		protected TElem[] Elements
		{
			get => handle.ToArray<TElem>(Count, (int)HeaderSize);
			set
			{
				Count = value.Length;
				Size = GetRequiredSize(value.Length, HeaderSize);
				value.MarshalToPtr(handle, (int)HeaderSize);
				OnCountChanged();
				OnUpdateHeader();
			}
		}

		/// <summary>Called when the count has changed.</summary>
		protected virtual void OnCountChanged() { }

		/// <summary>Called when the header needs to be refreshed.</summary>
		protected virtual void OnUpdateHeader() { }

		/// <summary>Gets or sets the <typeparamref name="TElem"/> value at the specified index.</summary>
		/// <value>The <typeparamref name="TElem"/> value.</value>
		/// <param name="index">The index.</param>
		/// <returns></returns>
		/// <exception cref="ArgumentOutOfRangeException">index or index</exception>
		public TElem this[int index]
		{
			get => PtrOfElem(index).ToStructure<TElem>();
			set => Marshal.StructureToPtr(value, PtrOfElem(index), false);
		}

		/// <summary>Adds an item to the <see cref="T:System.Collections.Generic.ICollection`1"/>.</summary>
		/// <param name="item">The object to add to the <see cref="T:System.Collections.Generic.ICollection`1"/>.</param>
		public void Add(TElem item) => Insert(Count, item);

		/// <summary>Removes all items from the <see cref="T:System.Collections.Generic.ICollection`1"/>.</summary>
		public virtual void Clear()
		{
			Size = (int)HeaderSize;
			Count = 0;
			OnCountChanged();
		}

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
		public void CopyTo(TElem[] array, int arrayIndex) => Elements.CopyTo(array, arrayIndex);

		/// <summary>Returns an enumerator that iterates through the collection.</summary>
		/// <returns>A <see cref="IEnumerator{TElem}"/> that can be used to iterate through the collection.</returns>
		public IEnumerator<TElem> GetEnumerator() => EnumElements().GetEnumerator();

		/// <summary>Determines the index of a specific item in the <see cref="T:System.Collections.Generic.IList`1"/>.</summary>
		/// <param name="item">The object to locate in the <see cref="T:System.Collections.Generic.IList`1"/>.</param>
		/// <returns>The index of <paramref name="item"/> if found in the list; otherwise, -1.</returns>
		public int IndexOf(TElem item) => Array.IndexOf(Elements, item);

		/// <summary>Inserts an item to the <see cref="T:System.Collections.Generic.IList`1"/> at the specified index.</summary>
		/// <param name="index">The zero-based index at which <paramref name="item"/> should be inserted.</param>
		/// <param name="item">The object to insert into the <see cref="T:System.Collections.Generic.IList`1"/>.</param>
		/// <exception cref="ArgumentOutOfRangeException">index</exception>
		public virtual void Insert(int index, TElem item)
		{
			if (index < 0 || index > Count) throw new ArgumentOutOfRangeException(nameof(index));
			Count++;
			var newSz = GetRequiredSize(Count, HeaderSize);
			var newPtr = mm.AllocMem(newSz);
			var insertPt = ElemOffset(index);
			if (index > 0)
				CopyTo(newPtr, 0, insertPt);
			Marshal.StructureToPtr(item, newPtr.Offset(insertPt), false);
			if (index < Count)
				CopyTo(newPtr, insertPt + ElemSize, newSz - insertPt);
			mm.FreeMem(handle);
			SetHandle(newPtr);
			sz = newSz;
			OnCountChanged();
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
		public virtual void RemoveAt(int index)
		{
			var rmvPt = ElemOffset(index);
			Count--;
			var newSz = GetRequiredSize(Count, HeaderSize);
			CopyTo(handle.Offset(rmvPt), rmvPt + ElemSize, newSz - rmvPt);
			Size -= ElemSize;
			OnCountChanged();
		}

		/// <summary>Returns an enumerator that iterates through a collection.</summary>
		/// <returns>An <see cref="IEnumerator"/> object that can be used to iterate through the collection.</returns>
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		/// <summary>Copies the values of this array to another native memory pointer.</summary>
		/// <param name="ptr">The PTR.</param>
		/// <param name="start">The start.</param>
		/// <param name="length">The length.</param>
		/// <exception cref="ArgumentOutOfRangeException"></exception>
		protected void CopyTo(IntPtr ptr, int start = 0, int length = -1)
		{
			if (start > Size) throw new ArgumentOutOfRangeException();
			if (length == -1) length = Size - start;
			if (length + start > Size || length + start < 0) throw new ArgumentOutOfRangeException();
			handle.CopyTo(start, ptr, length);
		}

		/// <summary>Enumerates the elements.</summary>
		/// <returns>An enumeration of values from the pointer.</returns>
		protected IEnumerable<TElem> EnumElements() => handle.ToIEnum<TElem>(Count, (int)HeaderSize);

		private static int GetElemCountFromBytes(uint byteSize, uint headerSize)
		{
			if (headerSize > byteSize) throw new ArgumentOutOfRangeException(nameof(byteSize));
			if ((byteSize - headerSize) % ElemSize != 0) throw new ArgumentOutOfRangeException(nameof(byteSize));
			return (int)Convert.ChangeType((byteSize - headerSize) / ElemSize, typeof(int));
		}

		private static int GetRequiredSize(int elementCount, uint headerSize) => ElemSize * elementCount + (int)headerSize;

		private int ElemOffset(int index) => index >= 0 && index < Count ? index * ElemSize + (int)HeaderSize : throw new ArgumentOutOfRangeException(nameof(index));

		private IntPtr PtrOfElem(int index) => handle.Offset(ElemOffset(index));
	}
}