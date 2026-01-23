using System.Collections.Generic;
using System.Diagnostics;

namespace Vanara.InteropServices;

/// <summary>The StrPtrAnsi structure represents a pointer to an Ansi string.</summary>
[StructLayout(LayoutKind.Sequential), DebuggerDisplay("{ptr}, {ToString()}")]
public struct StrPtrAnsi : IEquatable<string>, IEquatable<StrPtrAnsi>, IEquatable<IntPtr>
{
	const CharSet thisCharSet = CharSet.Ansi;
	private IntPtr ptr;

	/// <summary>Initializes a new instance of the <see cref="StrPtrAnsi"/> struct.</summary>
	/// <param name="s">The string value.</param>
	public StrPtrAnsi(string s) => ptr = StringHelper.AllocString(s, thisCharSet);

	/// <summary>Initializes a new instance of the <see cref="StrPtrAnsi"/> struct.</summary>
	/// <param name="charLen">Number of characters to reserve in memory.</param>
	public StrPtrAnsi(uint charLen) => ptr = StringHelper.AllocChars(charLen, thisCharSet);

	/// <summary>Gets a value indicating whether this instance is equivalent to null pointer or void*.</summary>
	/// <value><c>true</c> if this instance is null; otherwise, <c>false</c>.</value>
	public readonly bool IsNull => ptr == IntPtr.Zero;

	/// <summary>Indicates whether the specified string is <see langword="null"/> or an empty string ("").</summary>
	/// <returns>
	/// <see langword="true"/> if the value parameter is <see langword="null"/> or an empty string (""); otherwise, <see langword="false"/>.
	/// </returns>
	public readonly bool IsNullOrEmpty => (thisCharSet.ToEncoding().GetChar(ptr) ?? (char)0) == 0;

	/// <summary>Assigns a string pointer value to the pointer.</summary>
	/// <param name="stringPtr">The string pointer value.</param>
	public void Assign(IntPtr stringPtr) { Free(); ptr = stringPtr; }

	/// <summary>Assigns a new string value to the pointer.</summary>
	/// <param name="s">The string value.</param>
	public void Assign(string? s) => StringHelper.RefreshString(ref ptr, out var _, s, thisCharSet);

	/// <summary>Assigns a new string value to the pointer.</summary>
	/// <param name="s">The string value.</param>
	/// <param name="charsAllocated">The character count allocated.</param>
	/// <returns><c>true</c> if new memory was allocated for the string; <c>false</c> if otherwise.</returns>
	public bool Assign(string? s, out uint charsAllocated) => StringHelper.RefreshString(ref ptr, out charsAllocated, s, thisCharSet);

	/// <summary>Assigns an integer to the pointer for uses such as LPSTR_TEXTCALLBACK.</summary>
	/// <param name="value">The value to assign.</param>
	public void AssignConstant(int value) => Assign((IntPtr)value);

	/// <summary>Determines whether the specified <see cref="IntPtr"/>, is equal to this instance.</summary>
	/// <param name="other">The <see cref="IntPtr"/> to compare with this instance.</param>
	/// <returns><c>true</c> if the specified <see cref="IntPtr"/> is equal to this instance; otherwise, <c>false</c>.</returns>
	public readonly bool Equals(IntPtr other) => EqualityComparer<IntPtr>.Default.Equals(ptr, other);

	/// <summary>Determines whether the specified <see cref="IntPtr"/>, is equal to this instance.</summary>
	/// <param name="other">The <see cref="IntPtr"/> to compare with this instance.</param>
	/// <returns><c>true</c> if the specified <see cref="IntPtr"/> is equal to this instance; otherwise, <c>false</c>.</returns>
	public readonly bool Equals(string? other) => EqualityComparer<string?>.Default.Equals(this, other);

	/// <summary>Determines whether the specified <see cref="StrPtrAnsi"/>, is equal to this instance.</summary>
	/// <param name="other">The <see cref="StrPtrAnsi"/> to compare with this instance.</param>
	/// <returns><c>true</c> if the specified <see cref="StrPtrAnsi"/> is equal to this instance; otherwise, <c>false</c>.</returns>
	public readonly bool Equals(StrPtrAnsi other) => Equals(other.ptr);

	/// <summary>Determines whether the specified <see cref="object"/>, is equal to this instance.</summary>
	/// <param name="obj">The <see cref="object"/> to compare with this instance.</param>
	/// <returns><c>true</c> if the specified <see cref="object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
	public override readonly bool Equals(object? obj) => obj switch
	{
		null => IsNull,
		string s => Equals(s),
		StrPtrAnsi p => Equals(p),
		IntPtr p => Equals(p),
		_ => base.Equals(obj),
	};

	/// <summary>Frees the unmanaged string memory.</summary>
	public void Free() { StringHelper.FreeString(ptr, thisCharSet); ptr = IntPtr.Zero; }

	/// <summary>Returns a hash code for this instance.</summary>
	/// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
	public override readonly int GetHashCode() => ptr.GetHashCode();

	/// <summary>Returns a <see cref="string"/> that represents this instance.</summary>
	/// <returns>A <see cref="string"/> that represents this instance.</returns>
	public override readonly string ToString() => StringHelper.GetString(ptr, thisCharSet) ?? "null";

	/// <summary>Performs an implicit conversion from <see cref="StrPtrAnsi"/> to <see cref="string"/>.</summary>
	/// <param name="p">The <see cref="StrPtrAnsi"/> instance.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator string?(StrPtrAnsi p) => p.IsNull ? null : p.ToString();

	/// <summary>Performs an explicit conversion from <see cref="StrPtrAnsi"/> to <see cref="byte"/>*.</summary>
	/// <param name="p">The <see cref="StrPtrAnsi"/> reference.</param>
	/// <returns>The resulting <see cref="byte"/>* from the conversion.</returns>
	public static unsafe explicit operator byte*(StrPtrAnsi p) => (byte*)p.ptr;

	/// <summary>Performs an explicit conversion from <see cref="StrPtrAnsi"/> to <see cref="IntPtr"/>.</summary>
	/// <param name="p">The <see cref="StrPtrAnsi"/> instance.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator IntPtr(StrPtrAnsi p) => p.ptr;

	/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="StrPtrAnsi"/>.</summary>
	/// <param name="p">The pointer.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator StrPtrAnsi(IntPtr p) => new() { ptr = p };

	/// <summary>Determines whether two specified instances of <see cref="StrPtrAnsi"/> are equal.</summary>
	/// <param name="left">The first pointer or handle to compare.</param>
	/// <param name="right">The second pointer or handle to compare.</param>
	/// <returns><see langword="true"/> if <paramref name="left"/> equals <paramref name="right"/>; otherwise, <see langword="false"/>.</returns>
	public static bool operator ==(StrPtrAnsi left, StrPtrAnsi right) => left.Equals(right);

	/// <summary>Determines whether two specified instances of <see cref="StrPtrAnsi"/> are not equal.</summary>
	/// <param name="left">The first pointer or handle to compare.</param>
	/// <param name="right">The second pointer or handle to compare.</param>
	/// <returns><see langword="true"/> if <paramref name="left"/> does not equal <paramref name="right"/>; otherwise, <see langword="false"/>.</returns>
	public static bool operator !=(StrPtrAnsi left, StrPtrAnsi right) => !left.Equals(right);
}

/// <summary>The StrPtrAuto structure represents a pointer to an Auto string.</summary>
[StructLayout(LayoutKind.Sequential), DebuggerDisplay("{ptr}, {ToString()}")]
public struct StrPtrAuto : IEquatable<string>, IEquatable<StrPtrAuto>, IEquatable<IntPtr>
{
	const CharSet thisCharSet = CharSet.Auto;
	private IntPtr ptr;

	/// <summary>Initializes a new instance of the <see cref="StrPtrAuto"/> struct.</summary>
	/// <param name="s">The string value.</param>
	public StrPtrAuto(string s) => ptr = StringHelper.AllocString(s, thisCharSet);

	/// <summary>Initializes a new instance of the <see cref="StrPtrAuto"/> struct.</summary>
	/// <param name="charLen">Number of characters to reserve in memory.</param>
	public StrPtrAuto(uint charLen) => ptr = StringHelper.AllocChars(charLen, thisCharSet);

	/// <summary>Gets a value indicating whether this instance is equivalent to null pointer or void*.</summary>
	/// <value><c>true</c> if this instance is null; otherwise, <c>false</c>.</value>
	public readonly bool IsNull => ptr == IntPtr.Zero;

	/// <summary>Indicates whether the specified string is <see langword="null"/> or an empty string ("").</summary>
	/// <returns>
	/// <see langword="true"/> if the value parameter is <see langword="null"/> or an empty string (""); otherwise, <see langword="false"/>.
	/// </returns>
	public readonly bool IsNullOrEmpty => (thisCharSet.ToEncoding().GetChar(ptr) ?? (char)0) == 0;

	/// <summary>Assigns a string pointer value to the pointer.</summary>
	/// <param name="stringPtr">The string pointer value.</param>
	public void Assign(IntPtr stringPtr) { Free(); ptr = stringPtr; }

	/// <summary>Assigns a new string value to the pointer.</summary>
	/// <param name="s">The string value.</param>
	public void Assign(string? s) => StringHelper.RefreshString(ref ptr, out var _, s, thisCharSet);

	/// <summary>Assigns a new string value to the pointer.</summary>
	/// <param name="s">The string value.</param>
	/// <param name="charsAllocated">The character count allocated.</param>
	/// <returns><c>true</c> if new memory was allocated for the string; <c>false</c> if otherwise.</returns>
	public bool Assign(string? s, out uint charsAllocated) => StringHelper.RefreshString(ref ptr, out charsAllocated, s, thisCharSet);

	/// <summary>Assigns an integer to the pointer for uses such as LPSTR_TEXTCALLBACK.</summary>
	/// <param name="value">The value to assign.</param>
	public void AssignConstant(int value) => Assign((IntPtr)value);

	/// <summary>Determines whether the specified <see cref="IntPtr"/>, is equal to this instance.</summary>
	/// <param name="other">The <see cref="IntPtr"/> to compare with this instance.</param>
	/// <returns><c>true</c> if the specified <see cref="IntPtr"/> is equal to this instance; otherwise, <c>false</c>.</returns>
	public readonly bool Equals(IntPtr other) => EqualityComparer<IntPtr>.Default.Equals(ptr, other);

	/// <summary>Determines whether the specified <see cref="IntPtr"/>, is equal to this instance.</summary>
	/// <param name="other">The <see cref="IntPtr"/> to compare with this instance.</param>
	/// <returns><c>true</c> if the specified <see cref="IntPtr"/> is equal to this instance; otherwise, <c>false</c>.</returns>
	public readonly bool Equals(string? other) => EqualityComparer<string?>.Default.Equals(this, other);

	/// <summary>Determines whether the specified <see cref="StrPtrAuto"/>, is equal to this instance.</summary>
	/// <param name="other">The <see cref="StrPtrAuto"/> to compare with this instance.</param>
	/// <returns><c>true</c> if the specified <see cref="StrPtrAuto"/> is equal to this instance; otherwise, <c>false</c>.</returns>
	public readonly bool Equals(StrPtrAuto other) => Equals(other.ptr);

	/// <summary>Determines whether the specified <see cref="object"/>, is equal to this instance.</summary>
	/// <param name="obj">The <see cref="object"/> to compare with this instance.</param>
	/// <returns><c>true</c> if the specified <see cref="object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
	public override readonly bool Equals(object? obj) => obj switch
	{
		null => IsNull,
		string s => Equals(s),
		StrPtrAuto p => Equals(p),
		IntPtr p => Equals(p),
		_ => base.Equals(obj),
	};

	/// <summary>Frees the unmanaged string memory.</summary>
	public void Free() { StringHelper.FreeString(ptr, thisCharSet); ptr = IntPtr.Zero; }

	/// <summary>Returns a hash code for this instance.</summary>
	/// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
	public override readonly int GetHashCode() => ptr.GetHashCode();

	/// <summary>Returns a <see cref="string"/> that represents this instance.</summary>
	/// <returns>A <see cref="string"/> that represents this instance.</returns>
	public override readonly string ToString() => StringHelper.GetString(ptr, thisCharSet) ?? "null";

	/// <summary>Performs an implicit conversion from <see cref="StrPtrAuto"/> to <see cref="string"/>.</summary>
	/// <param name="p">The <see cref="StrPtrAuto"/> instance.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator string?(StrPtrAuto p) => p.IsNull ? null : p.ToString();

	/// <summary>Performs an explicit conversion from <see cref="StrPtrAuto"/> to <see cref="byte"/>*.</summary>
	/// <param name="p">The <see cref="StrPtrAuto"/> reference.</param>
	/// <returns>The resulting <see cref="byte"/>* from the conversion.</returns>
	public static unsafe explicit operator byte*(StrPtrAuto p) => (byte*)p.ptr;

	/// <summary>Performs an explicit conversion from <see cref="StrPtrAuto"/> to <see cref="IntPtr"/>.</summary>
	/// <param name="p">The <see cref="StrPtrAuto"/> instance.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator IntPtr(StrPtrAuto p) => p.ptr;

	/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="StrPtrAuto"/>.</summary>
	/// <param name="p">The pointer.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator StrPtrAuto(IntPtr p) => new() { ptr = p };

	/// <summary>Determines whether two specified instances of <see cref="StrPtrAuto"/> are equal.</summary>
	/// <param name="left">The first pointer or handle to compare.</param>
	/// <param name="right">The second pointer or handle to compare.</param>
	/// <returns><see langword="true"/> if <paramref name="left"/> equals <paramref name="right"/>; otherwise, <see langword="false"/>.</returns>
	public static bool operator ==(StrPtrAuto left, StrPtrAuto right) => left.Equals(right);

	/// <summary>Determines whether two specified instances of <see cref="StrPtrAuto"/> are not equal.</summary>
	/// <param name="left">The first pointer or handle to compare.</param>
	/// <param name="right">The second pointer or handle to compare.</param>
	/// <returns><see langword="true"/> if <paramref name="left"/> does not equal <paramref name="right"/>; otherwise, <see langword="false"/>.</returns>
	public static bool operator !=(StrPtrAuto left, StrPtrAuto right) => !left.Equals(right);
}

/// <summary>The StrPtrUni structure represents a pointer to an Unicode string.</summary>
[StructLayout(LayoutKind.Sequential), DebuggerDisplay("{ptr}, {ToString()}")]
public struct StrPtrUni : IEquatable<string>, IEquatable<StrPtrUni>, IEquatable<IntPtr>
{
	const CharSet thisCharSet = CharSet.Unicode;
	private IntPtr ptr;

	/// <summary>Initializes a new instance of the <see cref="StrPtrUni"/> struct.</summary>
	/// <param name="s">The string value.</param>
	public StrPtrUni(string s) => ptr = StringHelper.AllocString(s, thisCharSet);

	/// <summary>Initializes a new instance of the <see cref="StrPtrUni"/> struct.</summary>
	/// <param name="charLen">Number of characters to reserve in memory.</param>
	public StrPtrUni(uint charLen) => ptr = StringHelper.AllocChars(charLen, thisCharSet);

	/// <summary>Gets a value indicating whether this instance is equivalent to null pointer or void*.</summary>
	/// <value><c>true</c> if this instance is null; otherwise, <c>false</c>.</value>
	public readonly bool IsNull => ptr == IntPtr.Zero;

	/// <summary>Indicates whether the specified string is <see langword="null"/> or an empty string ("").</summary>
	/// <returns>
	/// <see langword="true"/> if the value parameter is <see langword="null"/> or an empty string (""); otherwise, <see langword="false"/>.
	/// </returns>
	public readonly bool IsNullOrEmpty => (thisCharSet.ToEncoding().GetChar(ptr) ?? (char)0) == 0;

	/// <summary>Assigns a string pointer value to the pointer.</summary>
	/// <param name="stringPtr">The string pointer value.</param>
	public void Assign(IntPtr stringPtr) { Free(); ptr = stringPtr; }

	/// <summary>Assigns a new string value to the pointer.</summary>
	/// <param name="s">The string value.</param>
	public void Assign(string? s) => StringHelper.RefreshString(ref ptr, out var _, s, thisCharSet);

	/// <summary>Assigns a new string value to the pointer.</summary>
	/// <param name="s">The string value.</param>
	/// <param name="charsAllocated">The character count allocated.</param>
	/// <returns><c>true</c> if new memory was allocated for the string; <c>false</c> if otherwise.</returns>
	public bool Assign(string? s, out uint charsAllocated) => StringHelper.RefreshString(ref ptr, out charsAllocated, s, thisCharSet);

	/// <summary>Assigns an integer to the pointer for uses such as LPSTR_TEXTCALLBACK.</summary>
	/// <param name="value">The value to assign.</param>
	public void AssignConstant(int value) => Assign((IntPtr)value);

	/// <summary>Determines whether the specified <see cref="IntPtr"/>, is equal to this instance.</summary>
	/// <param name="other">The <see cref="IntPtr"/> to compare with this instance.</param>
	/// <returns><c>true</c> if the specified <see cref="IntPtr"/> is equal to this instance; otherwise, <c>false</c>.</returns>
	public readonly bool Equals(IntPtr other) => EqualityComparer<IntPtr>.Default.Equals(ptr, other);

	/// <summary>Determines whether the specified <see cref="IntPtr"/>, is equal to this instance.</summary>
	/// <param name="other">The <see cref="IntPtr"/> to compare with this instance.</param>
	/// <returns><c>true</c> if the specified <see cref="IntPtr"/> is equal to this instance; otherwise, <c>false</c>.</returns>
	public readonly bool Equals(string? other) => EqualityComparer<string?>.Default.Equals(this, other);

	/// <summary>Determines whether the specified <see cref="StrPtrUni"/>, is equal to this instance.</summary>
	/// <param name="other">The <see cref="StrPtrUni"/> to compare with this instance.</param>
	/// <returns><c>true</c> if the specified <see cref="StrPtrUni"/> is equal to this instance; otherwise, <c>false</c>.</returns>
	public readonly bool Equals(StrPtrUni other) => Equals(other.ptr);

	/// <summary>Determines whether the specified <see cref="object"/>, is equal to this instance.</summary>
	/// <param name="obj">The <see cref="object"/> to compare with this instance.</param>
	/// <returns><c>true</c> if the specified <see cref="object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
	public override readonly bool Equals(object? obj) => obj switch
	{
		null => IsNull,
		string s => Equals(s),
		StrPtrUni p => Equals(p),
		IntPtr p => Equals(p),
		_ => base.Equals(obj),
	};

	/// <summary>Frees the unmanaged string memory.</summary>
	public void Free() { StringHelper.FreeString(ptr, thisCharSet); ptr = IntPtr.Zero; }

	/// <summary>Returns a hash code for this instance.</summary>
	/// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
	public override readonly int GetHashCode() => ptr.GetHashCode();

	/// <summary>Returns a <see cref="string"/> that represents this instance.</summary>
	/// <returns>A <see cref="string"/> that represents this instance.</returns>
	public override readonly string ToString() => StringHelper.GetString(ptr, thisCharSet) ?? "null";

	/// <summary>Performs an implicit conversion from <see cref="StrPtrUni"/> to <see cref="string"/>.</summary>
	/// <param name="p">The <see cref="StrPtrUni"/> instance.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator string?(StrPtrUni p) => p.IsNull ? null : p.ToString();

	/// <summary>Performs an explicit conversion from <see cref="StrPtrUni"/> to <see cref="byte"/>*.</summary>
	/// <param name="p">The <see cref="StrPtrUni"/> reference.</param>
	/// <returns>The resulting <see cref="byte"/>* from the conversion.</returns>
	public static unsafe explicit operator byte*(StrPtrUni p) => (byte*)p.ptr;

	/// <summary>Performs an explicit conversion from <see cref="StrPtrUni"/> to <see cref="char"/>*.</summary>
	/// <param name="p">The <see cref="char"/>* reference.</param>
	/// <returns>The resulting <see cref="char"/>* from the conversion.</returns>
	public static unsafe explicit operator char*(StrPtrUni p) => (char*)p.ptr;

	/// <summary>Performs an implicit conversion from <see cref="char"/>* to <see cref="StrPtrUni"/>.</summary>
	/// <param name="p">The pointer.</param>
	/// <returns>The result of the conversion.</returns>
	public static unsafe implicit operator StrPtrUni(char* p) => new() { ptr = (IntPtr)p };

	/// <summary>Performs an explicit conversion from <see cref="StrPtrUni"/> to <see cref="IntPtr"/>.</summary>
	/// <param name="p">The <see cref="StrPtrUni"/> instance.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator IntPtr(StrPtrUni p) => p.ptr;

	/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="StrPtrUni"/>.</summary>
	/// <param name="p">The pointer.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator StrPtrUni(IntPtr p) => new() { ptr = p };

	/// <summary>Determines whether two specified instances of <see cref="StrPtrUni"/> are equal.</summary>
	/// <param name="left">The first pointer or handle to compare.</param>
	/// <param name="right">The second pointer or handle to compare.</param>
	/// <returns><see langword="true"/> if <paramref name="left"/> equals <paramref name="right"/>; otherwise, <see langword="false"/>.</returns>
	public static bool operator ==(StrPtrUni left, StrPtrUni right) => left.Equals(right);

	/// <summary>Determines whether two specified instances of <see cref="StrPtrUni"/> are not equal.</summary>
	/// <param name="left">The first pointer or handle to compare.</param>
	/// <param name="right">The second pointer or handle to compare.</param>
	/// <returns><see langword="true"/> if <paramref name="left"/> does not equal <paramref name="right"/>; otherwise, <see langword="false"/>.</returns>
	public static bool operator !=(StrPtrUni left, StrPtrUni right) => !left.Equals(right);
}

