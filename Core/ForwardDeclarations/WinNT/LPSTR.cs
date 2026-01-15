using System.Collections.Generic;
using System.Diagnostics;

namespace Vanara.InteropServices;

/// <summary>The PSTR structure represents a pointer to an Ansi string.</summary>
[StructLayout(LayoutKind.Sequential), DebuggerDisplay("{ptr}, {ToString()}")]
public struct PSTR : IEquatable<string>, IEquatable<PSTR>, IEquatable<IntPtr>
{
	const CharSet thisCharSet = CharSet.Ansi;
	private IntPtr ptr;

	/// <summary>Initializes a new instance of the <see cref="PSTR"/> struct.</summary>
	/// <param name="s">The string value.</param>
	public PSTR(string s) => ptr = StringHelper.AllocString(s, thisCharSet);

	/// <summary>Initializes a new instance of the <see cref="PSTR"/> struct.</summary>
	/// <param name="charLen">Number of characters to reserve in memory.</param>
	public PSTR(uint charLen) => ptr = StringHelper.AllocChars(charLen, thisCharSet);

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

	/// <summary>Determines whether the specified <see cref="PSTR"/>, is equal to this instance.</summary>
	/// <param name="other">The <see cref="PSTR"/> to compare with this instance.</param>
	/// <returns><c>true</c> if the specified <see cref="PSTR"/> is equal to this instance; otherwise, <c>false</c>.</returns>
	public readonly bool Equals(PSTR other) => Equals(other.ptr);

	/// <summary>Determines whether the specified <see cref="object"/>, is equal to this instance.</summary>
	/// <param name="obj">The <see cref="object"/> to compare with this instance.</param>
	/// <returns><c>true</c> if the specified <see cref="object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
	public override readonly bool Equals(object? obj) => obj switch
	{
		null => IsNull,
		string s => Equals(s),
		PSTR p => Equals(p),
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

	/// <summary>Performs an implicit conversion from <see cref="PSTR"/> to <see cref="string"/>.</summary>
	/// <param name="p">The <see cref="PSTR"/> instance.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator string?(PSTR p) => p.IsNull ? null : p.ToString();

	/// <summary>Performs an explicit conversion from <see cref="PSTR"/> to <see cref="byte"/>*.</summary>
	/// <param name="p">The <see cref="PSTR"/> reference.</param>
	/// <returns>The resulting <see cref="byte"/>* from the conversion.</returns>
	public static unsafe explicit operator byte*(PSTR p) => (byte*)p.ptr;

	/// <summary>Performs an explicit conversion from <see cref="PSTR"/> to <see cref="IntPtr"/>.</summary>
	/// <param name="p">The <see cref="PSTR"/> instance.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator IntPtr(PSTR p) => p.ptr;

	/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="PSTR"/>.</summary>
	/// <param name="p">The pointer.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator PSTR(IntPtr p) => new() { ptr = p };

	/// <summary>Determines whether two specified instances of <see cref="PSTR"/> are equal.</summary>
	/// <param name="left">The first pointer or handle to compare.</param>
	/// <param name="right">The second pointer or handle to compare.</param>
	/// <returns><see langword="true"/> if <paramref name="left"/> equals <paramref name="right"/>; otherwise, <see langword="false"/>.</returns>
	public static bool operator ==(PSTR left, PSTR right) => left.Equals(right);

	/// <summary>Determines whether two specified instances of <see cref="PSTR"/> are not equal.</summary>
	/// <param name="left">The first pointer or handle to compare.</param>
	/// <param name="right">The second pointer or handle to compare.</param>
	/// <returns><see langword="true"/> if <paramref name="left"/> does not equal <paramref name="right"/>; otherwise, <see langword="false"/>.</returns>
	public static bool operator !=(PSTR left, PSTR right) => !left.Equals(right);
}

/// <summary>The PTSTR structure represents a pointer to an Auto string.</summary>
[StructLayout(LayoutKind.Sequential), DebuggerDisplay("{ptr}, {ToString()}")]
public struct PTSTR : IEquatable<string>, IEquatable<PTSTR>, IEquatable<IntPtr>
{
	const CharSet thisCharSet = CharSet.Auto;
	private IntPtr ptr;

	/// <summary>Initializes a new instance of the <see cref="PTSTR"/> struct.</summary>
	/// <param name="s">The string value.</param>
	public PTSTR(string s) => ptr = StringHelper.AllocString(s, thisCharSet);

	/// <summary>Initializes a new instance of the <see cref="PTSTR"/> struct.</summary>
	/// <param name="charLen">Number of characters to reserve in memory.</param>
	public PTSTR(uint charLen) => ptr = StringHelper.AllocChars(charLen, thisCharSet);

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

	/// <summary>Determines whether the specified <see cref="PTSTR"/>, is equal to this instance.</summary>
	/// <param name="other">The <see cref="PTSTR"/> to compare with this instance.</param>
	/// <returns><c>true</c> if the specified <see cref="PTSTR"/> is equal to this instance; otherwise, <c>false</c>.</returns>
	public readonly bool Equals(PTSTR other) => Equals(other.ptr);

	/// <summary>Determines whether the specified <see cref="object"/>, is equal to this instance.</summary>
	/// <param name="obj">The <see cref="object"/> to compare with this instance.</param>
	/// <returns><c>true</c> if the specified <see cref="object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
	public override readonly bool Equals(object? obj) => obj switch
	{
		null => IsNull,
		string s => Equals(s),
		PTSTR p => Equals(p),
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

	/// <summary>Performs an implicit conversion from <see cref="PTSTR"/> to <see cref="string"/>.</summary>
	/// <param name="p">The <see cref="PTSTR"/> instance.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator string?(PTSTR p) => p.IsNull ? null : p.ToString();

	/// <summary>Performs an explicit conversion from <see cref="PTSTR"/> to <see cref="byte"/>*.</summary>
	/// <param name="p">The <see cref="PTSTR"/> reference.</param>
	/// <returns>The resulting <see cref="byte"/>* from the conversion.</returns>
	public static unsafe explicit operator byte*(PTSTR p) => (byte*)p.ptr;

	/// <summary>Performs an explicit conversion from <see cref="PTSTR"/> to <see cref="IntPtr"/>.</summary>
	/// <param name="p">The <see cref="PTSTR"/> instance.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator IntPtr(PTSTR p) => p.ptr;

	/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="PTSTR"/>.</summary>
	/// <param name="p">The pointer.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator PTSTR(IntPtr p) => new() { ptr = p };

	/// <summary>Determines whether two specified instances of <see cref="PTSTR"/> are equal.</summary>
	/// <param name="left">The first pointer or handle to compare.</param>
	/// <param name="right">The second pointer or handle to compare.</param>
	/// <returns><see langword="true"/> if <paramref name="left"/> equals <paramref name="right"/>; otherwise, <see langword="false"/>.</returns>
	public static bool operator ==(PTSTR left, PTSTR right) => left.Equals(right);

	/// <summary>Determines whether two specified instances of <see cref="PTSTR"/> are not equal.</summary>
	/// <param name="left">The first pointer or handle to compare.</param>
	/// <param name="right">The second pointer or handle to compare.</param>
	/// <returns><see langword="true"/> if <paramref name="left"/> does not equal <paramref name="right"/>; otherwise, <see langword="false"/>.</returns>
	public static bool operator !=(PTSTR left, PTSTR right) => !left.Equals(right);
}

/// <summary>The PWSTR structure represents a pointer to an Unicode string.</summary>
[StructLayout(LayoutKind.Sequential), DebuggerDisplay("{ptr}, {ToString()}")]
public struct PWSTR : IEquatable<string>, IEquatable<PWSTR>, IEquatable<IntPtr>
{
	const CharSet thisCharSet = CharSet.Unicode;
	private IntPtr ptr;

	/// <summary>Initializes a new instance of the <see cref="PWSTR"/> struct.</summary>
	/// <param name="s">The string value.</param>
	public PWSTR(string s) => ptr = StringHelper.AllocString(s, thisCharSet);

	/// <summary>Initializes a new instance of the <see cref="PWSTR"/> struct.</summary>
	/// <param name="charLen">Number of characters to reserve in memory.</param>
	public PWSTR(uint charLen) => ptr = StringHelper.AllocChars(charLen, thisCharSet);

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

	/// <summary>Determines whether the specified <see cref="PWSTR"/>, is equal to this instance.</summary>
	/// <param name="other">The <see cref="PWSTR"/> to compare with this instance.</param>
	/// <returns><c>true</c> if the specified <see cref="PWSTR"/> is equal to this instance; otherwise, <c>false</c>.</returns>
	public readonly bool Equals(PWSTR other) => Equals(other.ptr);

	/// <summary>Determines whether the specified <see cref="object"/>, is equal to this instance.</summary>
	/// <param name="obj">The <see cref="object"/> to compare with this instance.</param>
	/// <returns><c>true</c> if the specified <see cref="object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
	public override readonly bool Equals(object? obj) => obj switch
	{
		null => IsNull,
		string s => Equals(s),
		PWSTR p => Equals(p),
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

	/// <summary>Performs an implicit conversion from <see cref="PWSTR"/> to <see cref="string"/>.</summary>
	/// <param name="p">The <see cref="PWSTR"/> instance.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator string?(PWSTR p) => p.IsNull ? null : p.ToString();

	/// <summary>Performs an explicit conversion from <see cref="PWSTR"/> to <see cref="byte"/>*.</summary>
	/// <param name="p">The <see cref="PWSTR"/> reference.</param>
	/// <returns>The resulting <see cref="byte"/>* from the conversion.</returns>
	public static unsafe explicit operator byte*(PWSTR p) => (byte*)p.ptr;

	/// <summary>Performs an explicit conversion from <see cref="PWSTR"/> to <see cref="char"/>*.</summary>
	/// <param name="p">The <see cref="char"/>* reference.</param>
	/// <returns>The resulting <see cref="char"/>* from the conversion.</returns>
	public static unsafe explicit operator char*(PWSTR p) => (char*)p.ptr;

	/// <summary>Performs an implicit conversion from <see cref="char"/>* to <see cref="PWSTR"/>.</summary>
	/// <param name="p">The pointer.</param>
	/// <returns>The result of the conversion.</returns>
	public static unsafe implicit operator PWSTR(char* p) => new() { ptr = (IntPtr)p };

	/// <summary>Performs an explicit conversion from <see cref="PWSTR"/> to <see cref="IntPtr"/>.</summary>
	/// <param name="p">The <see cref="PWSTR"/> instance.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator IntPtr(PWSTR p) => p.ptr;

	/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="PWSTR"/>.</summary>
	/// <param name="p">The pointer.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator PWSTR(IntPtr p) => new() { ptr = p };

	/// <summary>Determines whether two specified instances of <see cref="PWSTR"/> are equal.</summary>
	/// <param name="left">The first pointer or handle to compare.</param>
	/// <param name="right">The second pointer or handle to compare.</param>
	/// <returns><see langword="true"/> if <paramref name="left"/> equals <paramref name="right"/>; otherwise, <see langword="false"/>.</returns>
	public static bool operator ==(PWSTR left, PWSTR right) => left.Equals(right);

	/// <summary>Determines whether two specified instances of <see cref="PWSTR"/> are not equal.</summary>
	/// <param name="left">The first pointer or handle to compare.</param>
	/// <param name="right">The second pointer or handle to compare.</param>
	/// <returns><see langword="true"/> if <paramref name="left"/> does not equal <paramref name="right"/>; otherwise, <see langword="false"/>.</returns>
	public static bool operator !=(PWSTR left, PWSTR right) => !left.Equals(right);
}

