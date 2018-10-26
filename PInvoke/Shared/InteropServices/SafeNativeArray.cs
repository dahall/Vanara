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

		/// <summary>Initializes a new instance of the <see cref="SafeNativeArray{TElem, TPrefix, TMem}"/> class.</summary>
		public SafeNativeArray() : base(0) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="SafeNativeArray{TElem, TPrefix, TMem}"/> class from a copy of a managed TElem array.
		/// </summary>
		/// <param name="array">The array of bytes to copy.</param>
		/// <param name="getElemSize">Size of the get elem.</param>
		public SafeNativeArray(TElem[] array) : base(IntPtr.Zero, 0, true) => Elements = array;

		/// <summary>Initializes a new instance of the <see cref="SafeNativeArray{TElem, TPrefix, TMem}"/> class.</summary>
		/// <param name="byteSize">Size of the byte.</param>
		/// <param name="elementCount">The element count. This value can be 0.</param>
		public SafeNativeArray(int elementCount) : base(GetRequiredSize(elementCount)) => Zero();

		/// <summary>
		/// Initializes a new instance of the <see cref="SafeNativeArray{TElem}"/> class.
		/// </summary>
		/// <param name="ptr">The PTR.</param>
		/// <param name="size">The size.</param>
		/// <param name="ownsHandle">if set to <c>true</c> [owns handle].</param>
		public SafeNativeArray(IntPtr ptr, int size, bool ownsHandle) : base(ptr, size, ownsHandle) { }

		/// <summary>Gets the number of elements contained in the <see cref="SafeNativeArray{TElem, TPrefix, TMem}"/>.</summary>
		public int Count => IsInvalid ? 0 : BytesToCount(Size);

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

		public TElem this[int index]
		{
			get => (index >= 0 && index < Count) ? handle.Offset(index * ElemSize).ToStructure<TElem>() : throw new ArgumentOutOfRangeException(nameof(index));
			set { if (index >= 0 && index < Count) Marshal.StructureToPtr(value, handle.Offset(index * ElemSize), false); else throw new ArgumentOutOfRangeException(nameof(index)); }
		}

		public void Add(TElem item) => Insert(Count, item);

		public void Clear() => Size = 0;

		public bool Contains(TElem item) => EnumElements().Contains(item);

		public void CopyTo(TElem[] array, int arrayIndex) => ((IList<TElem>)Elements).CopyTo(array, arrayIndex);

		/// <summary>Returns an enumerator that iterates through the collection.</summary>
		/// <returns>A <see cref="IEnumerator{TElem}"/> that can be used to iterate through the collection.</returns>
		public IEnumerator<TElem> GetEnumerator() => EnumElements().GetEnumerator();

		public int IndexOf(TElem item) => ((IList<TElem>)Elements).IndexOf(item);

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

		public bool Remove(TElem item)
		{
			var idx = IndexOf(item);
			if (idx == -1) return false;
			RemoveAt(idx);
			return true;
		}

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

		protected IEnumerable<TElem> EnumElements() => handle.ToIEnum<TElem>(Count);

		private static int GetRequiredSize(int elementCount) => ElemSize * elementCount;
	}
}