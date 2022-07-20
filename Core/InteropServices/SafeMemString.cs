#nullable enable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Security;
using Vanara.Extensions;

namespace Vanara.InteropServices;

/// <summary>Base abstract class for a string handler based on <see cref="SafeMemoryHandle{TMem}"/>.</summary>
/// <typeparam name="TMem">The type of the memory.</typeparam>
/// <seealso cref="Vanara.InteropServices.SafeMemoryHandle{TMem}"/>
public abstract class SafeMemString<TMem> : SafeMemoryHandle<TMem>, IConvertible, IComparable<SafeMemString<TMem>>, IComparable, IComparable<string>, IEnumerable, IEnumerable<char>, IEquatable<SafeMemString<TMem>>, IEquatable<string> where TMem : IMemoryMethods, new()
{
	/// <summary>The system default character set for evaluating CharSet.Auto.</summary>
	protected static readonly CharSet defaultCharSet = Marshal.SystemDefaultCharSize == 2 ? CharSet.Unicode : CharSet.Ansi;

	/// <summary>Initializes a new instance of the <see cref="SafeMemString{TMem}"/> class.</summary>
	/// <param name="s">The string value.</param>
	/// <param name="charSet">The character set.</param>
	protected SafeMemString(string? s, CharSet charSet = CharSet.Unicode) : this(s, s is null ? 0 : s.Length + 1, charSet)
	{
	}

	/// <summary>Initializes a new instance of the <see cref="SafeMemString{TMem}"/> class.</summary>
	/// <param name="s">The string value.</param>
	/// <param name="capacity">The capacity of the buffer, in characters.</param>
	/// <param name="charSet">The character set.</param>
	protected SafeMemString(string? s, int capacity, CharSet charSet = CharSet.Unicode) : this(capacity, charSet) => StringHelper.Write(s, handle, out _, true, charSet, Size);

	/// <summary>Initializes a new instance of the <see cref="SafeMemString{TMem}"/> class.</summary>
	/// <param name="s">The string value.</param>
	/// <param name="charSet">The character set.</param>
	protected SafeMemString(SecureString s, CharSet charSet = CharSet.Unicode) : this(IntPtr.Zero, charSet)
	{
		SetHandle(StringHelper.AllocSecureString(s, charSet, mm.AllocMem, out var sz));
		base.sz = sz;
	}

	/// <summary>Initializes a new instance of the <see cref="SafeMemString{TMem}"/> class.</summary>
	/// <param name="charLen">The size of the buffer in characters, including the null character terminator.</param>
	/// <param name="charSet">The character set.</param>
	protected SafeMemString(int charLen, CharSet charSet = CharSet.Unicode) : base(charLen * StringHelper.GetCharSize(charSet)) => CharSet = charSet == CharSet.Auto ? charSet : defaultCharSet;

	/// <summary>Prevents a default instance of the <see cref="SafeMemString{TMem}"/> class from being created.</summary>
	[ExcludeFromCodeCoverage]
	protected SafeMemString() : base(0) { }

	/// <summary>Initializes a new instance of the <see cref="SafeMemString{TMem}"/> class.</summary>
	/// <param name="ptr">The PTR.</param>
	/// <param name="charSet">The character set.</param>
	/// <param name="ownsHandle"><c>true</c> to reliably release the handle during finalization; <c>false</c> to prevent it.</param>
	/// <param name="allocatedBytes">The number of bytes allocated to <paramref name="ptr"/>.</param>
	[ExcludeFromCodeCoverage]
	protected SafeMemString(IntPtr ptr, CharSet charSet = CharSet.Unicode, bool ownsHandle = true, PInvoke.SizeT allocatedBytes = default) : base(ptr, allocatedBytes, ownsHandle) => CharSet = charSet == CharSet.Auto ? charSet : defaultCharSet;

	/// <summary>Gets the number of allocated characters or 0 if the size is unknown (for example if it is holding a <see cref="SecureString"/>.</summary>
	/// <value>The number of allocated characters.</value>
	public int Capacity
	{
		get => Size / StringHelper.GetCharSize(CharSet);
		set => Size = value * StringHelper.GetCharSize(CharSet);
	}

	/// <summary>Gets the character set of the assigned string.</summary>
	/// <value>The character set.</value>
	public CharSet CharSet { get; private set; } = CharSet.Unicode;

	/// <summary>Gets a value indicating whether this instance contains a <see langword="null"/> pointer.</summary>
	/// <value><see langword="true"/> if this instance is null; otherwise, <see langword="false"/>.</value>
	public bool IsNull => handle == IntPtr.Zero;

	/// <summary>Gets the number of characters in the current <see cref="SafeMemString{TMem}"/> object.</summary>
	public int Length => ToString()?.Length ?? 0;

	/// <summary>Gets or sets the <see cref="char"/> at the specified index.</summary>
	/// <value>The <see cref="char"/>.</value>
	/// <param name="index">The index of the character in the in-memory string.</param>
	/// <returns>The character.</returns>
	/// <exception cref="System.IndexOutOfRangeException"></exception>
	public char this[int index]
	{
		get
		{
			var cs = StringHelper.GetCharSize(CharSet);
			return index * cs >= Capacity || index < 0
				? throw new IndexOutOfRangeException()
				: CharSet == CharSet.Ansi ? System.Text.Encoding.ASCII.GetChars(GetBytes(index * cs, cs))[0] : System.Text.Encoding.Unicode.GetChars(GetBytes(index * cs, cs))[0];
		}
		set
		{
			var cs = StringHelper.GetCharSize(CharSet);
			if (index * cs >= Capacity || index < 0) throw new IndexOutOfRangeException();
			var bytes = CharSet == CharSet.Ansi ? System.Text.Encoding.ASCII.GetBytes(new[] { value }) : System.Text.Encoding.Unicode.GetBytes(new[] { value });
			handle.Write(bytes, index * cs, Size);
		}
	}

	/// <summary>Performs an explicit conversion from <see cref="SafeMemString{TMem}"/> to <see cref="char"/>.</summary>
	/// <param name="s">The <see cref="SafeMemString{TMem}"/> instance.</param>
	/// <returns>The result of the conversion.</returns>
	/// <exception cref="InvalidCastException">Cannot convert an ANSI string to a Char pointer.</exception>
	public static unsafe explicit operator char*(SafeMemString<TMem> s) => s.CharSet == CharSet.Unicode ? (char*)(void*)s.handle : throw new InvalidCastException("Cannot convert an ANSI string to a Char pointer.");

	/// <summary>Returns the value of the <see cref="SafeHandle.handle"/> field.</summary>
	/// <param name="s">The <see cref="SafeMemString{TMem}"/> instance.</param>
	/// <returns>
	/// An <see cref="IntPtr"/> representing the value of the handle field. If the handle has been marked invalid with <see
	/// cref="SafeHandle.SetHandleAsInvalid"/>, this method still returns the original handle value, which can be a stale value.
	/// </returns>
	public static implicit operator IntPtr(SafeMemString<TMem> s) => s.DangerousGetHandle();

#if ALLOWSPAN
	/// <summary>Performs an implicit conversion from <see cref="SafeMemString{TMem}"/> to <see cref="ReadOnlySpan{T}"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator ReadOnlySpan<char>(SafeMemString<TMem> value) => value.AsReadOnlySpan<char>(value.Length);

	/// <summary>Performs an implicit conversion from <see cref="SafeMemString{TMem}"/> to <see cref="Span{T}"/>.</summary>
	/// <param name="value">The value.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator Span<char>(SafeMemString<TMem> value) => value.AsSpan<char>(value.Length);
#endif

	/// <summary>Returns the string value held by a <see cref="SafeMemString{TMem}"/>.</summary>
	/// <param name="s">The <see cref="SafeMemString{TMem}"/> instance.</param>
	/// <returns>A <see cref="string"/> value held by the <see cref="SafeMemString{TMem}"/> or <c>null</c> if the handle or value is invalid.</returns>
	public static implicit operator string?(SafeMemString<TMem> s) => s.ToString();

	/// <summary>Implements the operator !=.</summary>
	/// <param name="left">The left value.</param>
	/// <param name="right">The right value.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator !=(SafeMemString<TMem>? left, SafeMemString<TMem>? right) => !(left==right);

	/// <summary>Implements the operator !=.</summary>
	/// <param name="left">The left value.</param>
	/// <param name="right">The right value.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator !=(SafeMemString<TMem>? left, string right) => !(left==right);

	/// <summary>Implements the operator &lt;.</summary>
	/// <param name="left">The left.</param>
	/// <param name="right">The right.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator <(SafeMemString<TMem>? left, SafeMemString<TMem>? right) => left is null || left.IsNull ? right is not null && !right.IsNull : left.CompareTo(right)<0;

	/// <summary>Implements the operator &lt;.</summary>
	/// <param name="left">The left.</param>
	/// <param name="right">The right.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator <(SafeMemString<TMem>? left, string right) => left is null || left.IsNull ? right is not null : left.CompareTo(right)<0;

	/// <summary>Implements the operator &lt;=.</summary>
	/// <param name="left">The left.</param>
	/// <param name="right">The right.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator <=(SafeMemString<TMem>? left, SafeMemString<TMem>? right) => left is null || left.IsNull || left.CompareTo(right)<=0;

	/// <summary>Implements the operator &lt;=.</summary>
	/// <param name="left">The left.</param>
	/// <param name="right">The right.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator <=(SafeMemString<TMem>? left, string right) => left is null || left.IsNull || left.CompareTo(right)<=0;

	/// <summary>Implements the operator ==.</summary>
	/// <param name="left">The left value.</param>
	/// <param name="right">The right value.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator ==(SafeMemString<TMem>? left, SafeMemString<TMem>? right) => left is null || left.IsNull ? right is null || right.IsNull : left.Equals(right);

	/// <summary>Implements the operator ==.</summary>
	/// <param name="left">The left value.</param>
	/// <param name="right">The right value.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator ==(SafeMemString<TMem>? left, string right) => left is null || left.IsNull ? right is null : left.Equals(right);

	/// <summary>Implements the operator &gt;.</summary>
	/// <param name="left">The left.</param>
	/// <param name="right">The right.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator >(SafeMemString<TMem>? left, SafeMemString<TMem>? right) => left is not null && !left.IsNull && left.CompareTo(right)>0;

	/// <summary>Implements the operator &gt;.</summary>
	/// <param name="left">The left.</param>
	/// <param name="right">The right.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator >(SafeMemString<TMem>? left, string right) => left is not null && !left.IsNull && left.CompareTo(right)>0;

	/// <summary>Implements the operator &gt;=.</summary>
	/// <param name="left">The left.</param>
	/// <param name="right">The right.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator >=(SafeMemString<TMem>? left, SafeMemString<TMem>? right) => left is null || left.IsNull ? right is null || right.IsNull : left.CompareTo(right)>=0;

	/// <summary>Implements the operator &gt;=.</summary>
	/// <param name="left">The left.</param>
	/// <param name="right">The right.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator >=(SafeMemString<TMem>? left, string right) => left is null || left.IsNull ? right is null : left.CompareTo(right)>=0;

	/// <summary>Removes all characters from the current instance.</summary>
	public void Clear()
	{ Capacity = 1; this[0] = '\0'; }

	/// <summary>Compares the current object with another object of the same type.</summary>
	/// <param name="other">An object to compare with this object.</param>
	/// <returns>
	/// <para>
	/// A 32-bit signed integer that indicates the relative order of the objects being compared. The return value has the following meanings:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <description>Less than zero</description>
	/// <description>This object is less than the <paramref name="other"/> parameter.</description>
	/// </item>
	/// <item>
	/// <description>Zero</description>
	/// <description>This object is equal to <paramref name="other"/>.</description>
	/// </item>
	/// <item>
	/// <description>Greater than zero</description>
	/// <description>This object is greater than <paramref name="other"/>.</description>
	/// </item>
	/// </list>
	/// </returns>
	public int CompareTo(SafeMemString<TMem>? other) => string.Compare(ToString(), other?.ToString());

	/// <summary>Compares the current object with a <see cref="string"/>.</summary>
	/// <param name="other">An object to compare with this object.</param>
	/// <returns>
	/// <para>
	/// A 32-bit signed integer that indicates the relative order of the objects being compared. The return value has the following meanings:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <description>Less than zero</description>
	/// <description>This object is less than the <paramref name="other"/> parameter.</description>
	/// </item>
	/// <item>
	/// <description>Zero</description>
	/// <description>This object is equal to <paramref name="other"/>.</description>
	/// </item>
	/// <item>
	/// <description>Greater than zero</description>
	/// <description>This object is greater than <paramref name="other"/>.</description>
	/// </item>
	/// </list>
	/// </returns>
	public int CompareTo(string? other) => string.Compare(ToString(), other);

	/// <summary>
	/// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance
	/// precedes, follows, or occurs in the same position in the sort order as the other object.
	/// </summary>
	/// <param name="other">An object to compare with this object.</param>
	/// <returns>
	/// <para>
	/// A 32-bit signed integer that indicates the relative order of the objects being compared. The return value has the following meanings:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <description>Less than zero</description>
	/// <description>This object is less than the <paramref name="other"/> parameter.</description>
	/// </item>
	/// <item>
	/// <description>Zero</description>
	/// <description>This object is equal to <paramref name="other"/>.</description>
	/// </item>
	/// <item>
	/// <description>Greater than zero</description>
	/// <description>This object is greater than <paramref name="other"/>.</description>
	/// </item>
	/// </list>
	/// </returns>
	public int CompareTo(object? other) => other switch
	{
		null => IsNull ? 0 : 1,
		string s => CompareTo(s),
		SafeMemString<TMem> v => CompareTo(v),
		_ => throw new ArgumentException($"Argument must be a string or {nameof(SafeMemString<TMem>)}", nameof(other))
	};

	/// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
	/// <param name="other">An object to compare with this object.</param>
	/// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
	public bool Equals(SafeMemString<TMem>? other) => string.Equals(ToString(), other?.ToString());

	/// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
	/// <param name="other">An object to compare with this object.</param>
	/// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
	public bool Equals(string? other) => string.Equals(ToString(), other);

	/// <summary>Determines whether the specified <see cref="object"/>, is equal to this instance.</summary>
	/// <param name="obj">The <see cref="object"/> to compare with this instance.</param>
	/// <returns><c>true</c> if the specified <see cref="object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
	public override bool Equals(object obj) => ReferenceEquals(this, obj) || obj switch
	{
		null => false,
		SafeMemString<TMem> ms => Equals(ms),
		string s => Equals(s),
		SafeAllocatedMemoryHandle m => m == handle,
		_ => false,
	};

	/// <summary>Retrieves an enumerator that can iterate through the individual characters in this string.</summary>
	/// <returns>An <see cref="IEnumerator{T}"/> object that can be used to iterate through individual characters in this string.</returns>
	public IEnumerator<char> GetEnumerator() => ToString()?.GetEnumerator() ?? System.Linq.Enumerable.Empty<char>().GetEnumerator();

	/// <summary>Returns a hash code for this instance.</summary>
	/// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
	public override int GetHashCode() => ToString()?.GetHashCode() ?? 0;

	/// <summary>Assigns a new string to this memory.</summary>
	/// <param name="value">
	/// The string value. This value can be <see langword="null"/>, but its length cannot be greater than the current <see cref="Capacity"/>.
	/// </param>
	public virtual void Set(string? value)
	{
		if (value is null)
			ReleaseHandle();
		else
			StringHelper.Write(value, handle, out _, true, CharSet, Size);
	}

	/// <summary>Returns the string value held by this instance.</summary>
	/// <returns>A <see cref="string"/> value held by this instance or <c>null</c> if the handle is invalid.</returns>
	public override string? ToString() => IsInvalid ? null : StringHelper.GetString(handle, CharSet, Size == 0 ? long.MaxValue : (long)Size);

	/// <summary>
	/// Converts the value of this instance to an equivalent <see cref="string"/> using the specified culture-specific formatting information.
	/// </summary>
	/// <param name="provider">An <see cref="IFormatProvider"/> interface implementation that supplies culture-specific formatting information.</param>
	/// <returns>A <see cref="string"/> instance equivalent to the value of this instance.</returns>
	public virtual string ToString(IFormatProvider? provider) => ToString()?.ToString(provider) ?? string.Empty;

	/// <summary>Returns an enumerator that iterates through a collection.</summary>
	/// <returns>An <see cref="IEnumerator"/> object that can be used to iterate through the collection.</returns>
	IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

	/// <inheritdoc/>
	TypeCode IConvertible.GetTypeCode() => TypeCode.String;

	/// <inheritdoc/>
	bool IConvertible.ToBoolean(IFormatProvider? provider) => Convert.ToBoolean(ToString(), provider);

	/// <inheritdoc/>
	byte IConvertible.ToByte(IFormatProvider? provider) => Convert.ToByte(ToString(), provider);

	/// <inheritdoc/>
	char IConvertible.ToChar(IFormatProvider? provider) => ToString() is not null ? Convert.ToChar(ToString(), provider) : throw new ArgumentNullException();

	/// <inheritdoc/>
	DateTime IConvertible.ToDateTime(IFormatProvider? provider) => Convert.ToDateTime(ToString(), provider);

	/// <inheritdoc/>
	decimal IConvertible.ToDecimal(IFormatProvider? provider) => Convert.ToDecimal(ToString(), provider);

	/// <inheritdoc/>
	double IConvertible.ToDouble(IFormatProvider? provider) => Convert.ToDouble(ToString(), provider);

	/// <inheritdoc/>
	short IConvertible.ToInt16(IFormatProvider? provider) => Convert.ToInt16(ToString(), provider);

	/// <inheritdoc/>
	int IConvertible.ToInt32(IFormatProvider? provider) => Convert.ToInt32(ToString(), provider);

	/// <inheritdoc/>
	long IConvertible.ToInt64(IFormatProvider? provider) => Convert.ToInt64(ToString(), provider);

	/// <inheritdoc/>
	sbyte IConvertible.ToSByte(IFormatProvider? provider) => ToString() is null ? (sbyte)0 : Convert.ToSByte(ToString(), provider);

	/// <inheritdoc/>
	float IConvertible.ToSingle(IFormatProvider? provider) => Convert.ToSingle(ToString(), provider);

	/// <inheritdoc/>
	object IConvertible.ToType(Type conversionType, IFormatProvider? provider)
	{
		var str = ToString();
		return str is not null ? ((IConvertible)str).ToType(conversionType, provider) : throw new ArgumentNullException();
	}

	/// <inheritdoc/>
	ushort IConvertible.ToUInt16(IFormatProvider? provider) => Convert.ToUInt16(ToString(), provider);

	/// <inheritdoc/>
	uint IConvertible.ToUInt32(IFormatProvider? provider) => Convert.ToUInt32(ToString(), provider);

	/// <inheritdoc/>
	ulong IConvertible.ToUInt64(IFormatProvider? provider) => Convert.ToUInt64(ToString(), provider);

	/// <summary>Appends a copy of the specified string to this instance.</summary>
	/// <param name="value">The string to append.</param>
	/// <returns>A reference to this instance after the append operation has completed.</returns>
	protected virtual void Append(string? value)
	{
		if (!string.IsNullOrEmpty(value))
		{
			var curLen = Length;
#pragma warning disable CS8602 // Dereference of a possibly null reference.
			Capacity += value.Length;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
			StringHelper.Write(value, DangerousGetHandle().Offset(curLen * 2), out _, true, CharSet.Unicode, Size);
		}
	}

	/// <summary>Inserts a string into this instance at the specified character position.</summary>
	/// <param name="index">The position in this instance where insertion begins.</param>
	/// <param name="value">The string to insert.</param>
	/// <exception cref="System.ArgumentOutOfRangeException">
	/// <paramref name="index"/> is less than zero or greater than the current length of this instance.
	/// </exception>
	protected virtual void Insert(int index, string? value)
	{
		if (index > Length || index < 0)
			throw new ArgumentOutOfRangeException(nameof(index));
		if (value is not null && value != string.Empty)
		{
			var curLen = Length;
			Capacity += value.Length;
			handle.Offset(index * 2).CopyTo(handle.Offset(curLen * 2), 2 * (curLen - index + 1));
			StringHelper.Write(value, handle.Offset(index * 2), out _, false, CharSet.Unicode, Size);
		}
	}

	/// <summary>Removes the specified range of characters from this instance.</summary>
	/// <param name="startIndex">The zero-based position in this instance where removal begins.</param>
	/// <param name="length">The number of characters to remove.</param>
	/// <exception cref="System.ArgumentOutOfRangeException">
	/// If <paramref name="startIndex"/> or <paramref name="length"/> is less than zero, or <paramref name="startIndex"/> + <paramref
	/// name="length"/> is greater than the length of this instance.
	/// </exception>
	protected virtual void Remove(int startIndex, int length)
	{
		if (startIndex > Length || startIndex < 0 || startIndex + length > Length)
			throw new ArgumentOutOfRangeException(nameof(startIndex));
		handle.Offset((startIndex + length) * 2).CopyTo(handle.Offset(startIndex * 2), 2 * length);
		if (length > 64)
			Capacity = Length + 1;
	}

	/// <summary>Replaces the specified old value.</summary>
	/// <param name="oldValue">The string to replace.</param>
	/// <param name="newValue">The string that replaces <paramref name="oldValue"/>, or <see langword="null"/>.</param>
	/// <param name="startIndex">The position in this instance where the substring begins.</param>
	/// <param name="count">The length of the substring.</param>
	protected virtual void Replace(string oldValue, string? newValue, int startIndex, int count)
	{
		if (IsNull || Length == 0) return;
		var sb = new System.Text.StringBuilder(ToString());
		sb.Replace(oldValue, newValue, startIndex, count);
		Capacity = sb.Length;
		Set(sb.ToString());
	}

	/// <summary>Replaces, within a substring of this instance, all occurrences of a specified character with another specified character.</summary>
	/// <param name="oldChar">The character to replace.</param>
	/// <param name="newChar">The character that replaces <paramref name="oldChar"/>.</param>
	/// <param name="startIndex">The position in this instance where the substring begins.</param>
	/// <param name="count">The length of the substring.</param>
	/// <exception cref="System.ArgumentOutOfRangeException">
	/// <para><paramref name="startIndex"/> + <paramref name="count"/> is greater than the length of the value of this instance.</para>
	/// <para>-or-</para>
	/// <para><paramref name="startIndex"/> or <paramref name="count"/> is less than zero.</para>
	/// </exception>
	protected virtual void Replace(char oldChar, char newChar, int startIndex, int count)
	{
		var currentLength = Length;
		if ((uint)startIndex > (uint)currentLength)
			throw new ArgumentOutOfRangeException(nameof(startIndex));
		if (count < 0 || startIndex > currentLength - count)
			throw new ArgumentOutOfRangeException(nameof(count));

		var endIndex = startIndex + count;
		var chunk = (Span<char>)this;
		for (var i = startIndex; i < endIndex; i++)
		{
			if (chunk[i] == oldChar)
				chunk[i] = newChar;
		}
	}
}