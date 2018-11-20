using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Vanara.Extensions;

namespace Vanara.InteropServices
{
	/// <summary>
	/// A safe unmanaged array of structures allocated on the global heap with a prefix type (usually a uint or int) that determines the
	/// count of elements.
	/// </summary>
	public class SafeElementArray<TElem, TPrefix, TMem> : SafeMemoryHandle<TMem>, IEnumerable<TElem> where TMem : IMemoryMethods, new() where TElem : struct where TPrefix : IConvertible
	{
		private static readonly int ElemSize = Marshal.SizeOf(typeof(TElem));
		private static readonly int PrefixSize = Marshal.SizeOf(typeof(TPrefix));

		/// <summary>Initializes a new instance of the <see cref="SafeElementArray{TElem, TPrefix, TMem}"/> class.</summary>
		protected SafeElementArray() : this(0) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="SafeElementArray{TElem, TPrefix, TMem}"/> class and allocates <paramref
		/// name="elementCount"/> bytes.
		/// </summary>
		/// <param name="elementCount">The TElem count to allocate.</param>
		protected SafeElementArray(TPrefix elementCount) : this(Convert.ToInt32(elementCount)) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="SafeElementArray{TElem, TPrefix, TMem}"/> class from a copy of a managed TElem array.
		/// </summary>
		/// <param name="array">The array of bytes to copy.</param>
		/// <param name="getElemSize">Size of the get elem.</param>
		protected SafeElementArray(TElem[] array, Func<TElem, int> getElemSize = null) : base(IntPtr.Zero, 0, true) { GetElemSize = getElemSize; Elements = array; }

		/// <summary>Initializes a new instance of the <see cref="SafeElementArray{TElem, TPrefix, TMem}"/> class.</summary>
		/// <param name="byteSize">Size of the byte.</param>
		/// <param name="elementCount">The element count. This value can be 0.</param>
		protected SafeElementArray(int byteSize, int elementCount) : base(byteSize)
		{
			Zero();
			if (elementCount > 0)
				IntCount = elementCount;
		}

		private SafeElementArray(int elementCount) : base(GetRequiredSize(elementCount))
		{
		}

		/// <summary>Gets the number of elements contained in the <see cref="SafeElementArray{TElem, TPrefix, TMem}"/>.</summary>
		protected TPrefix Count
		{
			get => IsInvalid ? default : handle.ToStructure<TPrefix>();
			private set { if (!IsInvalid) Marshal.StructureToPtr(value, handle, false); }
		}

		/// <summary>Gets or sets the elements.</summary>
		/// <value>The elements of the array.</value>
		protected TElem[] Elements
		{
			get => handle.ToArray<TElem>(IntCount, PrefixSize);
			set
			{
				Size = GetElemSize != null ? PrefixSize + value.Sum(GetElemSize) : GetRequiredSize(value.Length);
				InteropExtensions.MarshalToPtr(value, handle, PrefixSize);
				IntCount = value.Length;
			}
		}

		/// <summary>Gets or sets the size of the element.</summary>
		/// <value>The size of the element.</value>
		protected Func<TElem, int> GetElemSize { get; set; }

		private int IntCount
		{
			get => Convert.ToInt32(Count);
			set => Count = (TPrefix)Convert.ChangeType(value, typeof(TPrefix));
		}

		/// <summary>Returns an enumerator that iterates through the collection.</summary>
		/// <returns>A <see cref="IEnumerator{TElem}"/> that can be used to iterate through the collection.</returns>
		public IEnumerator<TElem> GetEnumerator() => ((IEnumerable<TElem>)Elements).GetEnumerator();

		/// <summary>Returns an enumerator that iterates through a collection.</summary>
		/// <returns>An <see cref="IEnumerator"/> object that can be used to iterate through the collection.</returns>
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		/// <summary>Converts a byte count to a element count.</summary>
		/// <param name="byteSize">The byte count.</param>
		/// <returns>The converted element count.</returns>
		/// <exception cref="ArgumentException">Byte count does not match this structure.</exception>
		protected static uint BytesToCount(uint byteSize)
		{
			if ((byteSize - PrefixSize) % ElemSize != 0) throw new ArgumentException("Byte count does not match this structure.");
			return (uint)((byteSize - PrefixSize) / ElemSize);
		}

		private static int GetRequiredSize(int elementCount) => PrefixSize + ElemSize * elementCount;
	}
}