using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace Vanara.InteropServices;

/// <summary>An safe unmanaged array of bytes allocated on the global heap.</summary>
/// <seealso cref="byte"/>
/// <seealso cref="System.ICloneable"/>
/// <seealso cref="System.Collections.IList"/>
/// <seealso cref="SafeHGlobalHandle"/>
public class SafeByteArray : SafeMemoryHandle<CoTaskMemoryMethods>, IList<byte>, ICloneable, IList, IStructuralComparable, IStructuralEquatable
{
	/// <summary>Initializes a new instance of the <see cref="SafeByteArray"/> class from a copy of a managed byte array.</summary>
	/// <param name="array">The array of bytes to copy.</param>
	public SafeByteArray(byte[] array) : base(array?.Length ?? 0)
	{
		if (array != null)
			Marshal.Copy(array, 0, handle, array.Length);
	}

	/// <summary>Initializes a new instance of the <see cref="SafeByteArray"/> class and allocates <paramref name="byteCount"/> bytes.</summary>
	/// <param name="byteCount">The byte count to allocate.</param>
	public SafeByteArray(int byteCount) : base(byteCount) => Zero();

	/// <summary>
	/// Initializes a new instance of the <see cref="SafeByteArray"/> class by copying the bytes from another unmanaged array.
	/// </summary>
	/// <param name="src">Another unmanaged array.</param>
	public SafeByteArray(SafeByteArray src) : base(src?.Count ?? 0)
	{
		if (src == null) throw new ArgumentNullException(nameof(src));
		if (src.IsInvalid) throw new ArgumentException(@"Invalid source object.", nameof(src));
		CopyMemory(src.handle, handle, src.Count);
	}

	// Prevents construction of an invalid instance.
	[ExcludeFromCodeCoverage]
	private SafeByteArray() : base(0) { }

	/// <summary>Gets the number of elements contained in the <see cref="T:System.Collections.Generic.ICollection{T}"/>.</summary>
	public int Count => Size;

	/// <summary>Gets a value indicating whether the <see cref="T:System.Collections.Generic.ICollection{T}"/> is read-only.</summary>
	public bool IsReadOnly => false;

	/// <summary>Gets a value indicating whether the <see cref="T:System.Collections.IList"/> has a fixed size.</summary>
	bool IList.IsFixedSize => true;

	/// <summary>
	/// Gets a value indicating whether access to the <see cref="T:System.Collections.ICollection"/> is synchronized (thread safe).
	/// </summary>
	bool ICollection.IsSynchronized => true;

	/// <summary>Gets an object that can be used to synchronize access to the <see cref="T:System.Collections.ICollection"/>.</summary>
	object ICollection.SyncRoot => this;

	[ExcludeFromCodeCoverage]
	private new int Size { get => base.Size; set => base.Size = value; }

	/// <summary>Gets or sets the <see cref="byte"/> at the specified index.</summary>
	/// <value>The <see cref="byte"/>.</value>
	/// <param name="index">The index.</param>
	/// <returns></returns>
	/// <exception cref="System.ArgumentOutOfRangeException">index</exception>
	/// <exception cref="System.InvalidOperationException">Object is not valid.</exception>
	public byte this[int index]
	{
		get
		{
			if (index < 0 || index >= Count) throw new IndexOutOfRangeException();
			return Marshal.ReadByte(handle, index);
		}
		set
		{
			if (index < 0 || index >= Count) throw new IndexOutOfRangeException();
			Marshal.WriteByte(handle, index, value);
		}
	}

	/// <summary>Gets or sets the <see cref="System.Object"/> at the specified index.</summary>
	/// <value>The <see cref="System.Object"/>.</value>
	/// <param name="index">The index.</param>
	/// <returns></returns>
	object? IList.this[int index]
	{
		get => this[index];
		set => this[index] = (byte)(value ?? 0);
	}

	/// <summary>Removes all items from the <see cref="T:System.Collections.Generic.ICollection{T}"/>.</summary>
	/// <exception cref="System.NotSupportedException"></exception>
	public void Clear() => Size = 0;

	/// <summary>Creates a new object that is a copy of the current instance.</summary>
	/// <returns>A new object that is a copy of this instance.</returns>
	public object Clone() => new SafeByteArray(this);

	/// <summary>Determines whether the <see cref="T:System.Collections.Generic.ICollection{T}"/> contains a specific value.</summary>
	/// <param name="item">The object to locate in the <see cref="T:System.Collections.Generic.ICollection{T}"/>.</param>
	/// <returns>
	/// true if <paramref name="item"/> is found in the <see cref="T:System.Collections.Generic.ICollection{T}"/>; otherwise, false.
	/// </returns>
	public bool Contains(byte item) => IndexOf(item) != -1;

	/// <summary>
	/// Copies the elements of the <see cref="T:System.Collections.Generic.ICollection{T}"/> to an <see cref="T:System.Array"/>, starting
	/// at a particular <see cref="T:System.Array"/> index.
	/// </summary>
	/// <param name="array">
	/// The one-dimensional <see cref="T:System.Array"/> that is the destination of the elements copied from <see
	/// cref="T:System.Collections.Generic.ICollection{T}"/> . The <see cref="T:System.Array"/> must have zero-based indexing.
	/// </param>
	/// <param name="arrayIndex">The zero-based index in <paramref name="array"/> at which copying begins.</param>
	/// <exception cref="System.ArgumentNullException">array</exception>
	/// <exception cref="System.ArgumentOutOfRangeException">array</exception>
	public void CopyTo(byte[] array, int arrayIndex)
	{
		if (array == null) throw new ArgumentNullException(nameof(array));
		if (array.Length - arrayIndex < Count) throw new ArgumentOutOfRangeException(nameof(array));
		Marshal.Copy(handle, array, arrayIndex, Count);
	}

	/// <summary>Returns an enumerator that iterates through the collection.</summary>
	/// <returns>A <see cref="T:System.Collections.Generic.IEnumerator{T}"/> that can be used to iterate through the collection.</returns>
	public IEnumerator<byte> GetEnumerator()
	{
		if (IsInvalid) yield break;
		for (var i = 0; i < Count; i++)
			yield return Marshal.ReadByte(handle, i);
	}

	/// <summary>Determines the index of a specific item in the <see cref="T:System.Collections.Generic.IList{T}"/>.</summary>
	/// <param name="item">The object to locate in the <see cref="T:System.Collections.Generic.IList{T}"/>.</param>
	/// <returns>The index of <paramref name="item"/> if found in the list; otherwise, -1.</returns>
	public int IndexOf(byte item)
	{
		var i = 0;
		foreach (var b in this)
		{
			if (b == item) return i;
			i++;
		}
		return -1;
	}

	/// <summary>Copies unmanaged bytes to a managed byte array.</summary>
	/// <returns>Copied byte array.</returns>
	public byte[] ToArray()
	{
		var array = new byte[Count];
		CopyTo(array, 0);
		return array;
	}

	/// <summary>Adds an item to the <see cref="T:System.Collections.IList"/>.</summary>
	/// <param name="value">The object to add to the <see cref="T:System.Collections.IList"/>.</param>
	/// <returns>
	/// The position into which the new element was inserted, or -1 to indicate that the item was not inserted into the collection.
	/// </returns>
	int IList.Add(object? value) => throw new NotSupportedException();

	/// <summary>Adds an item to the <see cref="T:System.Collections.Generic.ICollection{T}"/>.</summary>
	/// <param name="item">The object to add to the <see cref="T:System.Collections.Generic.ICollection{T}"/>.</param>
	/// <exception cref="System.NotSupportedException"></exception>
	[ExcludeFromCodeCoverage]
	void ICollection<byte>.Add(byte item) => ((IList)this).Add(item);

	/// <summary>
	/// Determines whether the current collection object precedes, occurs in the same position as, or follows another object in the sort order.
	/// </summary>
	/// <param name="other">The object to compare with the current instance.</param>
	/// <param name="comparer">
	/// An object that compares members of the current collection object with the corresponding members of <paramref name="other"/>.
	/// </param>
	/// <returns>
	/// An integer that indicates the relationship of the current collection object to <paramref name="other"/>, as shown in the
	/// following table.Return valueDescription-1The current instance precedes <paramref name="other"/>.0The current instance and
	/// <paramref name="other"/> are equal.1The current instance follows <paramref name="other"/>.
	/// </returns>
	int IStructuralComparable.CompareTo(object? other, IComparer comparer)
	{
		if (comparer == null)
			throw new ArgumentNullException(nameof(comparer));
		if (other == null)
			return 1;
		if (other is not IEnumerable<byte> o)
			throw new ArgumentOutOfRangeException(nameof(other), @"Other value is not enumerable.");
		var l = other as ICollection<byte> ?? new List<byte>(o);
		if (Count != l.Count)
			throw new ArgumentOutOfRangeException(nameof(other), @"Other value doesn't have the same number of elements.");

		using (var tenum = GetEnumerator())
		using (var oenum = l.GetEnumerator())
		{
			while (tenum.MoveNext() && oenum.MoveNext())
			{
				var i = comparer.Compare(tenum.Current, oenum.Current);
				if (i != 0) return i;
			}
		}
		return 0;
	}

	/// <summary>Determines whether the <see cref="T:System.Collections.IList"/> contains a specific value.</summary>
	/// <param name="value">The object to locate in the <see cref="T:System.Collections.IList"/>.</param>
	/// <returns>true if the <see cref="T:System.Object"/> is found in the <see cref="T:System.Collections.IList"/>; otherwise, false.</returns>
	bool IList.Contains(object? value) => value != null && Contains((byte)value);

	/// <summary>
	/// Copies the elements of the <see cref="T:System.Collections.ICollection"/> to an <see cref="T:System.Array"/>, starting at a
	/// particular <see cref="T:System.Array"/> index.
	/// </summary>
	/// <param name="array">
	/// The one-dimensional <see cref="T:System.Array"/> that is the destination of the elements copied from <see
	/// cref="T:System.Collections.ICollection"/>. The <see cref="T:System.Array"/> must have zero-based indexing.
	/// </param>
	/// <param name="index">The zero-based index in <paramref name="array"/> at which copying begins.</param>
	/// <exception cref="System.ArgumentNullException">array</exception>
	/// <exception cref="System.ArgumentOutOfRangeException">array</exception>
	void ICollection.CopyTo(Array array, int index)
	{
		if (array == null) throw new ArgumentNullException(nameof(array));
		if (array.Rank != 1 || array.Length - index < Count) throw new ArgumentOutOfRangeException(nameof(array));
		for (var i = 0; i < Count; i++)
			array.SetValue(this[i], i + index);
	}

	/// <summary>Determines whether the specified <see cref="System.Object"/>, is equal to this instance.</summary>
	/// <param name="other">The <see cref="System.Object"/> to compare with this instance.</param>
	/// <param name="comparer">The comparer.</param>
	/// <returns><c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
	bool IStructuralEquatable.Equals(object? other, IEqualityComparer comparer)
	{
		if (comparer == null)
			throw new ArgumentNullException(nameof(comparer));

		if (other == null)
			return false;

		if (ReferenceEquals(this, other))
			return true;

		if (other is not IEnumerable<byte> o)
			throw new ArgumentOutOfRangeException(nameof(other), @"Other value is not enumerable.");
		var l = other as ICollection<byte> ?? new List<byte>(o);
		if (Count != l.Count)
			throw new ArgumentOutOfRangeException(nameof(other), @"Other value doesn't have the same number of elements.");

		using (var tenum = GetEnumerator())
		using (var oenum = l.GetEnumerator())
		{
			while (tenum.MoveNext() && oenum.MoveNext())
			{
				if (!comparer.Equals(tenum.Current, oenum.Current))
					return false;
			}
		}
		return true;
	}

	/// <summary>Returns an enumerator that iterates through a collection.</summary>
	/// <returns>An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.</returns>
	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

	/// <summary>Returns a hash code for this instance.</summary>
	/// <param name="comparer">The comparer.</param>
	/// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
	/// <exception cref="System.ArgumentNullException">comparer</exception>
	int IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
	{
		if (comparer == null)
			throw new ArgumentNullException(nameof(comparer));

		var ret = 0;
		for (var i = Size >= 8 ? Size - 8 : 0; i < Size; i++)
			ret = CombineHashCodes(ret, comparer.GetHashCode(this[i]));
		return ret;
	}

	/// <summary>Determines the index of a specific item in the <see cref="T:System.Collections.IList"/>.</summary>
	/// <param name="value">The object to locate in the <see cref="T:System.Collections.IList"/>.</param>
	/// <returns>The index of <paramref name="value"/> if found in the list; otherwise, -1.</returns>
	int IList.IndexOf(object? value) => IndexOf((byte)(value ?? throw new ArgumentNullException(nameof(value))));

	/// <summary>Inserts an item to the <see cref="T:System.Collections.IList"/> at the specified index.</summary>
	/// <param name="index">The zero-based index at which <paramref name="value"/> should be inserted.</param>
	/// <param name="value">The object to insert into the <see cref="T:System.Collections.IList"/>.</param>
	[ExcludeFromCodeCoverage]
	void IList.Insert(int index, object? value) => ((IList<byte>)this).Insert(index, (byte)(value ?? throw new ArgumentNullException(nameof(value))));

	/// <summary>Inserts an item to the <see cref="T:System.Collections.Generic.IList{T}"/> at the specified index.</summary>
	/// <param name="index">The zero-based index at which <paramref name="item"/> should be inserted.</param>
	/// <param name="item">The object to insert into the <see cref="T:System.Collections.Generic.IList{T}"/>.</param>
	/// <exception cref="System.NotSupportedException"></exception>
	void IList<byte>.Insert(int index, byte item) => throw new NotSupportedException();

	/// <summary>Removes the first occurrence of a specific object from the <see cref="T:System.Collections.IList"/>.</summary>
	/// <param name="value">The object to remove from the <see cref="T:System.Collections.IList"/>.</param>
	[ExcludeFromCodeCoverage]
	void IList.Remove(object? value) => ((ICollection<byte>)this).Remove((byte)(value ?? throw new ArgumentNullException(nameof(value))));

	/// <summary>Removes the first occurrence of a specific object from the <see cref="T:System.Collections.Generic.ICollection{T}"/>.</summary>
	/// <param name="item">The object to remove from the <see cref="T:System.Collections.Generic.ICollection{T}"/>.</param>
	/// <returns>
	/// true if <paramref name="item"/> was successfully removed from the <see cref="T:System.Collections.Generic.ICollection{T}"/>;
	/// otherwise, false. This method also returns false if <paramref name="item"/> is not found in the original <see cref="T:System.Collections.Generic.ICollection{T}"/>.
	/// </returns>
	/// <exception cref="System.NotSupportedException"></exception>
	bool ICollection<byte>.Remove(byte item) => throw new NotSupportedException();

	/// <summary>Removes the <see cref="T:System.Collections.Generic.IList{T}"/> item at the specified index.</summary>
	/// <param name="index">The zero-based index of the item to remove.</param>
	/// <exception cref="System.NotSupportedException"></exception>
	void IList.RemoveAt(int index) => throw new NotSupportedException();

	/// <summary>Removes the <see cref="T:System.Collections.Generic.IList{T}"/> item at the specified index.</summary>
	/// <param name="index">The zero-based index of the item to remove.</param>
	[ExcludeFromCodeCoverage]
	void IList<byte>.RemoveAt(int index) => ((IList)this).RemoveAt(index);

	private static int CombineHashCodes(int h1, int h2) => ((h1 << 5) + h1) ^ h2;

	private static void CopyMemory(IntPtr src, IntPtr dest, int length)
	{
		var size1 = length % 8;
		var size8 = length - size1;
		int ofs;
		// copy multiples of 8 bytes first
		for (ofs = 0; ofs < size8; ofs += 8)
			Marshal.WriteInt64(dest, ofs, Marshal.ReadInt64(src, ofs));
		// copy remaining bytes
		for (var n = 0; n < size1; n++, ofs++)
			Marshal.WriteByte(dest, ofs, Marshal.ReadByte(src, ofs));
	}
}