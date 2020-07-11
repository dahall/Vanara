using System;
using System.Collections;
using System.Collections.Generic;
using Vanara.Extensions;
using Vanara.InteropServices;

namespace Vanara.PInvoke.Collections
{
	/// <summary>Provides a generic enumerator over native memory.</summary>
	/// <typeparam name="T">The type of the element to extract from memory.</typeparam>
	/// <seealso cref="System.Collections.Generic.IEnumerator{T}"/>
	/// <seealso cref="System.Collections.Generic.IEnumerable{T}"/>
	public class NativeMemoryEnumerator<T> : UntypedNativeMemoryEnumerator, IEnumerator<T>, IEnumerable<T>
	{
		/// <summary>Initializes a new instance of the <see cref="NativeMemoryEnumerator{T}"/> class.</summary>
		/// <param name="ptr">A pointer to the starting address of a specified number of <typeparamref name="T"/> elements in memory.</param>
		/// <param name="length">The number of <typeparamref name="T"/> elements to be included in the enumeration.</param>
		/// <param name="prefixBytes">Bytes to skip before reading the first element.</param>
		/// <param name="allocatedBytes">If known, the total number of bytes allocated to the native memory in <paramref name="ptr"/>.</param>
		/// <exception cref="System.ArgumentOutOfRangeException">count</exception>
		/// <exception cref="System.InsufficientMemoryException"></exception>
		public NativeMemoryEnumerator(IntPtr ptr, int length, int prefixBytes = 0, SizeT allocatedBytes = default) : base(ptr, typeof(T), length, prefixBytes, allocatedBytes) { }

		/// <summary>Gets the element in the collection at the current position of the enumerator.</summary>
		public new T Current => (T)base.Current;

		/// <summary>Returns an enumerator that iterates through the collection.</summary>
		/// <returns>A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.</returns>
		public new IEnumerator<T> GetEnumerator() => this;
	}

	/// <summary>Provides an enumerator over native memory.</summary>
	/// <seealso cref="System.Collections.IEnumerator"/>
	/// <seealso cref="System.Collections.IEnumerable"/>
	public class UntypedNativeMemoryEnumerator : IEnumerator, IEnumerable
	{
		/// <summary>The number of allocated bytes.</summary>
		protected SizeT allocated;

		/// <summary>The number of elements in the enumeration.</summary>
		protected int count;

		/// <summary>The index of the current item. (-2) signifies an error. (-1) means MoveNext has not been called..</summary>
		protected int index = -1;

		/// <summary>The number of bytes to skip before reading the first element.</summary>
		protected int prefix;

		/// <summary>A pointer to the starting address of a specified number of <see cref="type"/> elements in memory.</summary>
		protected IntPtr ptr;

		/// <summary>The size of <see cref="type"/>.</summary>
		protected SizeT stSize;

		/// <summary>The type of the element to extract from memory.</summary>
		protected Type type;

		/// <summary>Initializes a new instance of the <see cref="NativeMemoryEnumerator{T}"/> class.</summary>
		/// <param name="ptr">A pointer to the starting address of a specified number of <paramref name="type"/> elements in memory.</param>
		/// <param name="type">The type of the element to extract from memory.</param>
		/// <param name="length">The number of <paramref name="type"/> elements to be included in the enumeration.</param>
		/// <param name="prefixBytes">Bytes to skip before reading the first element.</param>
		/// <param name="allocatedBytes">If known, the total number of bytes allocated to the native memory in <paramref name="ptr"/>.</param>
		/// <exception cref="System.ArgumentOutOfRangeException">count</exception>
		/// <exception cref="System.ArgumentNullException">type</exception>
		/// <exception cref="System.InsufficientMemoryException"></exception>
		public UntypedNativeMemoryEnumerator(IntPtr ptr, Type type, int length, int prefixBytes = 0, SizeT allocatedBytes = default)
		{
			if (length < 0 || ptr == IntPtr.Zero && length != 0)
				throw new ArgumentOutOfRangeException(nameof(length));
			if (type is null)
				throw new ArgumentNullException(nameof(type));
			this.type = type;
			this.ptr = ptr;
			count = length;
			prefix = prefixBytes;
			allocated = allocatedBytes == default ? (SizeT)uint.MaxValue : allocatedBytes;
			stSize = InteropExtensions.SizeOf(type);
			if (allocatedBytes > 0 && stSize * length + prefixBytes > allocatedBytes)
				throw new InsufficientMemoryException();
		}

		/// <summary>Gets the element in the collection at the current position of the enumerator.</summary>
		public virtual object Current
		{
			get
			{
				if (index < 0 || index >= count)
					throw new ArgumentOutOfRangeException(nameof(index));
				var offset = prefix + index * stSize;
				return ptr.Offset(offset).Convert(allocated - (uint)offset - (uint)prefix, type);
			}
		}

		/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
		public virtual void Dispose() { }

		/// <summary>Returns an enumerator that iterates through a collection.</summary>
		/// <returns>An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.</returns>
		public IEnumerator GetEnumerator() => this;

		/// <summary>Advances the enumerator to the next element of the collection.</summary>
		/// <returns>
		/// true if the enumerator was successfully advanced to the next element; false if the enumerator has passed the end of the collection.
		/// </returns>
		public bool MoveNext()
		{
			if (++index >= count)
				index = -2;
			return index >= 0;
		}

		/// <summary>Sets the enumerator to its initial position, which is before the first element in the collection.</summary>
		public void Reset() => index = -1;
	}
}