using System.Collections.Generic;
using System.Diagnostics;

namespace Vanara.InteropServices;

/// <summary>The LPSTR structure represents a pointer to an Ansi string.</summary>
[StructLayout(LayoutKind.Sequential), DebuggerDisplay("{ptr}, {ToString()}")]
public struct LPSTR : IEquatable<string>, IEquatable<LPSTR>, IEquatable<IntPtr>
{
	const CharSet thisCharSet = CharSet.Ansi;
	private IntPtr ptr;

	/// <summary>Initializes a new instance of the <see cref="LPSTR"/> struct.</summary>
	/// <param name="s">The string value.</param>
	public LPSTR(string s) => ptr = StringHelper.AllocString(s, thisCharSet);

	/// <summary>Initializes a new instance of the <see cref="LPSTR"/> struct.</summary>
	/// <param name="charLen">Number of characters to reserve in memory.</param>
	public LPSTR(uint charLen) => ptr = StringHelper.AllocChars(charLen, thisCharSet);

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

	/// <summary>Determines whether the specified <see cref="LPSTR"/>, is equal to this instance.</summary>
	/// <param name="other">The <see cref="LPSTR"/> to compare with this instance.</param>
	/// <returns><c>true</c> if the specified <see cref="LPSTR"/> is equal to this instance; otherwise, <c>false</c>.</returns>
	public readonly bool Equals(LPSTR other) => Equals(other.ptr);

	/// <summary>Determines whether the specified <see cref="object"/>, is equal to this instance.</summary>
	/// <param name="obj">The <see cref="object"/> to compare with this instance.</param>
	/// <returns><c>true</c> if the specified <see cref="object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
	public override readonly bool Equals(object? obj) => obj switch
	{
		null => IsNull,
		string s => Equals(s),
		LPSTR p => Equals(p),
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

	/// <summary>Performs an implicit conversion from <see cref="LPSTR"/> to <see cref="string"/>.</summary>
	/// <param name="p">The <see cref="LPSTR"/> instance.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator string?(LPSTR p) => p.IsNull ? null : p.ToString();

	/// <summary>Performs an explicit conversion from <see cref="LPSTR"/> to <see cref="byte"/>*.</summary>
	/// <param name="p">The <see cref="LPSTR"/> reference.</param>
	/// <returns>The resulting <see cref="byte"/>* from the conversion.</returns>
	public static unsafe explicit operator byte*(LPSTR p) => (byte*)p.ptr;

	/// <summary>Performs an explicit conversion from <see cref="LPSTR"/> to <see cref="IntPtr"/>.</summary>
	/// <param name="p">The <see cref="LPSTR"/> instance.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator IntPtr(LPSTR p) => p.ptr;

	/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="LPSTR"/>.</summary>
	/// <param name="p">The pointer.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator LPSTR(IntPtr p) => new() { ptr = p };

	/// <summary>Determines whether two specified instances of <see cref="LPSTR"/> are equal.</summary>
	/// <param name="left">The first pointer or handle to compare.</param>
	/// <param name="right">The second pointer or handle to compare.</param>
	/// <returns><see langword="true"/> if <paramref name="left"/> equals <paramref name="right"/>; otherwise, <see langword="false"/>.</returns>
	public static bool operator ==(LPSTR left, LPSTR right) => left.Equals(right);

	/// <summary>Determines whether two specified instances of <see cref="LPSTR"/> are not equal.</summary>
	/// <param name="left">The first pointer or handle to compare.</param>
	/// <param name="right">The second pointer or handle to compare.</param>
	/// <returns><see langword="true"/> if <paramref name="left"/> does not equal <paramref name="right"/>; otherwise, <see langword="false"/>.</returns>
	public static bool operator !=(LPSTR left, LPSTR right) => !left.Equals(right);
}

/// <summary>The LPTSTR structure represents a pointer to an Auto string.</summary>
[StructLayout(LayoutKind.Sequential), DebuggerDisplay("{ptr}, {ToString()}")]
public struct LPTSTR : IEquatable<string>, IEquatable<LPTSTR>, IEquatable<IntPtr>
{
	const CharSet thisCharSet = CharSet.Auto;
	private IntPtr ptr;

	/// <summary>Initializes a new instance of the <see cref="LPTSTR"/> struct.</summary>
	/// <param name="s">The string value.</param>
	public LPTSTR(string s) => ptr = StringHelper.AllocString(s, thisCharSet);

	/// <summary>Initializes a new instance of the <see cref="LPTSTR"/> struct.</summary>
	/// <param name="charLen">Number of characters to reserve in memory.</param>
	public LPTSTR(uint charLen) => ptr = StringHelper.AllocChars(charLen, thisCharSet);

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

	/// <summary>Determines whether the specified <see cref="LPTSTR"/>, is equal to this instance.</summary>
	/// <param name="other">The <see cref="LPTSTR"/> to compare with this instance.</param>
	/// <returns><c>true</c> if the specified <see cref="LPTSTR"/> is equal to this instance; otherwise, <c>false</c>.</returns>
	public readonly bool Equals(LPTSTR other) => Equals(other.ptr);

	/// <summary>Determines whether the specified <see cref="object"/>, is equal to this instance.</summary>
	/// <param name="obj">The <see cref="object"/> to compare with this instance.</param>
	/// <returns><c>true</c> if the specified <see cref="object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
	public override readonly bool Equals(object? obj) => obj switch
	{
		null => IsNull,
		string s => Equals(s),
		LPTSTR p => Equals(p),
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

	/// <summary>Performs an implicit conversion from <see cref="LPTSTR"/> to <see cref="string"/>.</summary>
	/// <param name="p">The <see cref="LPTSTR"/> instance.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator string?(LPTSTR p) => p.IsNull ? null : p.ToString();

	/// <summary>Performs an explicit conversion from <see cref="LPTSTR"/> to <see cref="byte"/>*.</summary>
	/// <param name="p">The <see cref="LPTSTR"/> reference.</param>
	/// <returns>The resulting <see cref="byte"/>* from the conversion.</returns>
	public static unsafe explicit operator byte*(LPTSTR p) => (byte*)p.ptr;

	/// <summary>Performs an explicit conversion from <see cref="LPTSTR"/> to <see cref="IntPtr"/>.</summary>
	/// <param name="p">The <see cref="LPTSTR"/> instance.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator IntPtr(LPTSTR p) => p.ptr;

	/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="LPTSTR"/>.</summary>
	/// <param name="p">The pointer.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator LPTSTR(IntPtr p) => new() { ptr = p };

	/// <summary>Determines whether two specified instances of <see cref="LPTSTR"/> are equal.</summary>
	/// <param name="left">The first pointer or handle to compare.</param>
	/// <param name="right">The second pointer or handle to compare.</param>
	/// <returns><see langword="true"/> if <paramref name="left"/> equals <paramref name="right"/>; otherwise, <see langword="false"/>.</returns>
	public static bool operator ==(LPTSTR left, LPTSTR right) => left.Equals(right);

	/// <summary>Determines whether two specified instances of <see cref="LPTSTR"/> are not equal.</summary>
	/// <param name="left">The first pointer or handle to compare.</param>
	/// <param name="right">The second pointer or handle to compare.</param>
	/// <returns><see langword="true"/> if <paramref name="left"/> does not equal <paramref name="right"/>; otherwise, <see langword="false"/>.</returns>
	public static bool operator !=(LPTSTR left, LPTSTR right) => !left.Equals(right);
}

/// <summary>The LPWSTR structure represents a pointer to an Unicode string.</summary>
[StructLayout(LayoutKind.Sequential), DebuggerDisplay("{ptr}, {ToString()}")]
public struct LPWSTR : IEquatable<string>, IEquatable<LPWSTR>, IEquatable<IntPtr>
{
	const CharSet thisCharSet = CharSet.Unicode;
	private IntPtr ptr;

	/// <summary>Initializes a new instance of the <see cref="LPWSTR"/> struct.</summary>
	/// <param name="s">The string value.</param>
	public LPWSTR(string s) => ptr = StringHelper.AllocString(s, thisCharSet);

	/// <summary>Initializes a new instance of the <see cref="LPWSTR"/> struct.</summary>
	/// <param name="charLen">Number of characters to reserve in memory.</param>
	public LPWSTR(uint charLen) => ptr = StringHelper.AllocChars(charLen, thisCharSet);

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

	/// <summary>Determines whether the specified <see cref="LPWSTR"/>, is equal to this instance.</summary>
	/// <param name="other">The <see cref="LPWSTR"/> to compare with this instance.</param>
	/// <returns><c>true</c> if the specified <see cref="LPWSTR"/> is equal to this instance; otherwise, <c>false</c>.</returns>
	public readonly bool Equals(LPWSTR other) => Equals(other.ptr);

	/// <summary>Determines whether the specified <see cref="object"/>, is equal to this instance.</summary>
	/// <param name="obj">The <see cref="object"/> to compare with this instance.</param>
	/// <returns><c>true</c> if the specified <see cref="object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
	public override readonly bool Equals(object? obj) => obj switch
	{
		null => IsNull,
		string s => Equals(s),
		LPWSTR p => Equals(p),
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

	/// <summary>Performs an implicit conversion from <see cref="LPWSTR"/> to <see cref="string"/>.</summary>
	/// <param name="p">The <see cref="LPWSTR"/> instance.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator string?(LPWSTR p) => p.IsNull ? null : p.ToString();

	/// <summary>Performs an explicit conversion from <see cref="LPWSTR"/> to <see cref="byte"/>*.</summary>
	/// <param name="p">The <see cref="LPWSTR"/> reference.</param>
	/// <returns>The resulting <see cref="byte"/>* from the conversion.</returns>
	public static unsafe explicit operator byte*(LPWSTR p) => (byte*)p.ptr;

	/// <summary>Performs an explicit conversion from <see cref="LPWSTR"/> to <see cref="char"/>*.</summary>
	/// <param name="p">The <see cref="char"/>* reference.</param>
	/// <returns>The resulting <see cref="char"/>* from the conversion.</returns>
	public static unsafe explicit operator char*(LPWSTR p) => (char*)p.ptr;

	/// <summary>Performs an implicit conversion from <see cref="char"/>* to <see cref="LPWSTR"/>.</summary>
	/// <param name="p">The pointer.</param>
	/// <returns>The result of the conversion.</returns>
	public static unsafe implicit operator LPWSTR(char* p) => new() { ptr = (IntPtr)p };

	/// <summary>Performs an explicit conversion from <see cref="LPWSTR"/> to <see cref="IntPtr"/>.</summary>
	/// <param name="p">The <see cref="LPWSTR"/> instance.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator IntPtr(LPWSTR p) => p.ptr;

	/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="LPWSTR"/>.</summary>
	/// <param name="p">The pointer.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator LPWSTR(IntPtr p) => new() { ptr = p };

	/// <summary>Determines whether two specified instances of <see cref="LPWSTR"/> are equal.</summary>
	/// <param name="left">The first pointer or handle to compare.</param>
	/// <param name="right">The second pointer or handle to compare.</param>
	/// <returns><see langword="true"/> if <paramref name="left"/> equals <paramref name="right"/>; otherwise, <see langword="false"/>.</returns>
	public static bool operator ==(LPWSTR left, LPWSTR right) => left.Equals(right);

	/// <summary>Determines whether two specified instances of <see cref="LPWSTR"/> are not equal.</summary>
	/// <param name="left">The first pointer or handle to compare.</param>
	/// <param name="right">The second pointer or handle to compare.</param>
	/// <returns><see langword="true"/> if <paramref name="left"/> does not equal <paramref name="right"/>; otherwise, <see langword="false"/>.</returns>
	public static bool operator !=(LPWSTR left, LPWSTR right) => !left.Equals(right);
}

