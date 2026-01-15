using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Security;

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

/// <summary>Class that reprents a LPSTR with allocated memory behind it.</summary>
public class SafeLPSTR : SafeMemString<CoTaskMemoryMethods>
{
	const CharSet thisCharSet = CharSet.Ansi;

	/// <summary>Initializes a new instance of the <see cref="SafeLPSTR"/> class.</summary>
	/// <param name="s">The string value.</param>
	public SafeLPSTR(string s) : base(s, thisCharSet) { }

	/// <summary>Initializes a new instance of the <see cref="SafeLPSTR"/> class.</summary>
	/// <param name="s">The string value.</param>
	/// <param name="capacity">The size of the buffer in characters.</param>
	public SafeLPSTR(string s, int capacity) : base(s, capacity, thisCharSet) { }

	/// <summary>Initializes a new instance of the <see cref="SafeLPSTR"/> class.</summary>
	/// <param name="s">The string value.</param>
	public SafeLPSTR(SecureString s) : base(s, thisCharSet) { }

	/// <summary>Initializes a new instance of the <see cref="SafeLPSTR"/> class.</summary>
	/// <param name="capacity">The size of the buffer in characters, including the null character terminator.</param>
	public SafeLPSTR(int capacity) : base(capacity, thisCharSet) { }

	/// <summary>Prevents a default instance of the <see cref="SafeLPSTR"/> class from being created.</summary>
	private SafeLPSTR() : base() { }

	/// <summary>Initializes a new instance of the <see cref="SafeLPSTR"/> class.</summary>
	/// <param name="ptr">The PTR.</param>
	/// <param name="ownsHandle"><c>true</c> to reliably release the handle during finalization; <c>false</c> to prevent it.</param>
	/// <param name="allocatedBytes">The number of bytes allocated to <paramref name="ptr"/>.</param>
	[ExcludeFromCodeCoverage]
	private SafeLPSTR(StrPtrAnsi ptr, bool ownsHandle = true, PInvoke.SizeT allocatedBytes = default) :
		base((IntPtr)ptr, thisCharSet, ownsHandle, allocatedBytes) { }

	/// <summary>Initializes a new instance of the <see cref="SafeLPSTR"/> class.</summary>
	/// <param name="ptr">The PTR.</param>
	/// <param name="ownsHandle"><c>true</c> to reliably release the handle during finalization; <c>false</c> to prevent it.</param>
	/// <param name="allocatedBytes">The number of bytes allocated to <paramref name="ptr"/>.</param>
	[ExcludeFromCodeCoverage]
	private SafeLPSTR(LPSTR ptr, bool ownsHandle = true, PInvoke.SizeT allocatedBytes = default) :
		base((IntPtr)ptr, thisCharSet, ownsHandle, allocatedBytes) { }

	/// <summary>Represents a <c>null</c> value. Used primarily for comparison.</summary>
	/// <value>A null value.</value>
	public static SafeLPSTR Null => new((LPSTR)IntPtr.Zero, false);

	/// <summary>Returns the string value held by a <see cref="SafeLPSTR"/>.</summary>
	/// <param name="s">The <see cref="SafeLPSTR"/> instance.</param>
	/// <returns>A <see cref="string"/> value held by the <see cref="SafeLPSTR"/> or <c>null</c> if the handle or value is invalid.</returns>
	public static implicit operator SafeLPSTR(string s) => s.ToString();

	/// <summary>Returns the LPSTR value held by a <see cref="SafeLPSTR"/>.</summary>
	/// <param name="s">The <see cref="SafeLPSTR"/> instance.</param>
	/// <returns>A <see cref="LPSTR"/> value held by the <see cref="SafeLPSTR"/> or <c>default</c> if the handle or value is invalid.</returns>
	public static implicit operator LPSTR(SafeLPSTR s) => (LPSTR)s.handle;

	/// <summary>Returns the StrPtrAnsi value held by a <see cref="SafeLPSTR"/>.</summary>
	/// <param name="s">The <see cref="SafeLPSTR"/> instance.</param>
	/// <returns>A <see cref="StrPtrAnsi"/> value held by the <see cref="SafeLPSTR"/> or <c>default</c> if the handle or value is invalid.</returns>
	public static implicit operator StrPtrAnsi(SafeLPSTR s) => (StrPtrAnsi)s.handle;

	/// <summary>Appends a copy of the specified string to this instance.</summary>
	/// <param name="value">The string to append.</param>
	/// <returns>A reference to this instance after the append operation has completed.</returns>
	public new SafeLPSTR Append(string? value) { base.Append(value); return this; }

	/// <summary>Appends a copy of the specified value to this instance.</summary>
	/// <param name="value">The value to append.</param>
	/// <returns>A reference to this instance after the append operation has completed.</returns>
	public SafeLPSTR Append(SafeLPSTR value) => Append(value.ToString());

	/// <summary>Inserts a string into this instance at the specified character position.</summary>
	/// <param name="index">The position in this instance where insertion begins.</param>
	/// <param name="value">The string to insert.</param>
	/// <exception cref="System.ArgumentOutOfRangeException">
	/// <paramref name="index"/> is less than zero or greater than the current length of this instance.
	/// </exception>
	public new SafeLPSTR Insert(int index, string? value) { base.Insert(index, value); return this; }

	/// <summary>Removes the specified range of characters from this instance.</summary>
	/// <param name="startIndex">The zero-based position in this instance where removal begins.</param>
	/// <param name="length">The number of characters to remove.</param>
	/// <exception cref="System.ArgumentOutOfRangeException">
	/// If <paramref name="startIndex"/> or <paramref name="length"/> is less than zero, or <paramref name="startIndex"/> + <paramref
	/// name="length"/> is greater than the length of this instance.
	/// </exception>
	public new SafeLPSTR Remove(int startIndex, int length) { base.Remove(startIndex, length); return this; }

	/// <summary>Replaces all occurrences of a specified string in this instance with another specified string.</summary>
	/// <param name="oldValue">The string to replace.</param>
	/// <param name="newValue">The string that replaces <paramref name="oldValue"/>, or <see langword="null"/>.</param>
	public SafeLPSTR Replace(string oldValue, string? newValue) => Replace(oldValue, newValue, 0, Length);

	/// <summary>Replaces the specified old value.</summary>
	/// <param name="oldValue">The string to replace.</param>
	/// <param name="newValue">The string that replaces <paramref name="oldValue"/>, or <see langword="null"/>.</param>
	/// <param name="startIndex">The position in this instance where the substring begins.</param>
	/// <param name="count">The length of the substring.</param>
	public new SafeLPSTR Replace(string oldValue, string? newValue, int startIndex, int count) { base.Replace(oldValue, newValue, startIndex, count); return this; }

	/// <summary>Replaces all occurrences of a specified character in this instance with another specified character.</summary>
	/// <param name="oldChar">The character to replace.</param>
	/// <param name="newChar">The character that replaces <paramref name="oldChar"/>.</param>
	public SafeLPSTR Replace(char oldChar, char newChar) => Replace(oldChar, newChar, 0, Length);

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
	public new SafeLPSTR Replace(char oldChar, char newChar, int startIndex, int count) { base.Replace(oldChar, newChar, startIndex, count); return this; }
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

/// <summary>Class that reprents a LPTSTR with allocated memory behind it.</summary>
public class SafeLPTSTR : SafeMemString<CoTaskMemoryMethods>
{
	const CharSet thisCharSet = CharSet.Auto;

	/// <summary>Initializes a new instance of the <see cref="SafeLPTSTR"/> class.</summary>
	/// <param name="s">The string value.</param>
	public SafeLPTSTR(string s) : base(s, thisCharSet) { }

	/// <summary>Initializes a new instance of the <see cref="SafeLPTSTR"/> class.</summary>
	/// <param name="s">The string value.</param>
	/// <param name="capacity">The size of the buffer in characters.</param>
	public SafeLPTSTR(string s, int capacity) : base(s, capacity, thisCharSet) { }

	/// <summary>Initializes a new instance of the <see cref="SafeLPTSTR"/> class.</summary>
	/// <param name="s">The string value.</param>
	public SafeLPTSTR(SecureString s) : base(s, thisCharSet) { }

	/// <summary>Initializes a new instance of the <see cref="SafeLPTSTR"/> class.</summary>
	/// <param name="capacity">The size of the buffer in characters, including the null character terminator.</param>
	public SafeLPTSTR(int capacity) : base(capacity, thisCharSet) { }

	/// <summary>Prevents a default instance of the <see cref="SafeLPTSTR"/> class from being created.</summary>
	private SafeLPTSTR() : base() { }

	/// <summary>Initializes a new instance of the <see cref="SafeLPTSTR"/> class.</summary>
	/// <param name="ptr">The PTR.</param>
	/// <param name="ownsHandle"><c>true</c> to reliably release the handle during finalization; <c>false</c> to prevent it.</param>
	/// <param name="allocatedBytes">The number of bytes allocated to <paramref name="ptr"/>.</param>
	[ExcludeFromCodeCoverage]
	private SafeLPTSTR(StrPtrAuto ptr, bool ownsHandle = true, PInvoke.SizeT allocatedBytes = default) :
		base((IntPtr)ptr, thisCharSet, ownsHandle, allocatedBytes) { }

	/// <summary>Initializes a new instance of the <see cref="SafeLPTSTR"/> class.</summary>
	/// <param name="ptr">The PTR.</param>
	/// <param name="ownsHandle"><c>true</c> to reliably release the handle during finalization; <c>false</c> to prevent it.</param>
	/// <param name="allocatedBytes">The number of bytes allocated to <paramref name="ptr"/>.</param>
	[ExcludeFromCodeCoverage]
	private SafeLPTSTR(LPTSTR ptr, bool ownsHandle = true, PInvoke.SizeT allocatedBytes = default) :
		base((IntPtr)ptr, thisCharSet, ownsHandle, allocatedBytes) { }

	/// <summary>Represents a <c>null</c> value. Used primarily for comparison.</summary>
	/// <value>A null value.</value>
	public static SafeLPTSTR Null => new((LPTSTR)IntPtr.Zero, false);

	/// <summary>Returns the string value held by a <see cref="SafeLPTSTR"/>.</summary>
	/// <param name="s">The <see cref="SafeLPTSTR"/> instance.</param>
	/// <returns>A <see cref="string"/> value held by the <see cref="SafeLPTSTR"/> or <c>null</c> if the handle or value is invalid.</returns>
	public static implicit operator SafeLPTSTR(string s) => s.ToString();

	/// <summary>Returns the LPTSTR value held by a <see cref="SafeLPTSTR"/>.</summary>
	/// <param name="s">The <see cref="SafeLPTSTR"/> instance.</param>
	/// <returns>A <see cref="LPTSTR"/> value held by the <see cref="SafeLPTSTR"/> or <c>default</c> if the handle or value is invalid.</returns>
	public static implicit operator LPTSTR(SafeLPTSTR s) => (LPTSTR)s.handle;

	/// <summary>Returns the StrPtrAuto value held by a <see cref="SafeLPTSTR"/>.</summary>
	/// <param name="s">The <see cref="SafeLPTSTR"/> instance.</param>
	/// <returns>A <see cref="StrPtrAuto"/> value held by the <see cref="SafeLPTSTR"/> or <c>default</c> if the handle or value is invalid.</returns>
	public static implicit operator StrPtrAuto(SafeLPTSTR s) => (StrPtrAuto)s.handle;

	/// <summary>Appends a copy of the specified string to this instance.</summary>
	/// <param name="value">The string to append.</param>
	/// <returns>A reference to this instance after the append operation has completed.</returns>
	public new SafeLPTSTR Append(string? value) { base.Append(value); return this; }

	/// <summary>Appends a copy of the specified value to this instance.</summary>
	/// <param name="value">The value to append.</param>
	/// <returns>A reference to this instance after the append operation has completed.</returns>
	public SafeLPTSTR Append(SafeLPTSTR value) => Append(value.ToString());

	/// <summary>Inserts a string into this instance at the specified character position.</summary>
	/// <param name="index">The position in this instance where insertion begins.</param>
	/// <param name="value">The string to insert.</param>
	/// <exception cref="System.ArgumentOutOfRangeException">
	/// <paramref name="index"/> is less than zero or greater than the current length of this instance.
	/// </exception>
	public new SafeLPTSTR Insert(int index, string? value) { base.Insert(index, value); return this; }

	/// <summary>Removes the specified range of characters from this instance.</summary>
	/// <param name="startIndex">The zero-based position in this instance where removal begins.</param>
	/// <param name="length">The number of characters to remove.</param>
	/// <exception cref="System.ArgumentOutOfRangeException">
	/// If <paramref name="startIndex"/> or <paramref name="length"/> is less than zero, or <paramref name="startIndex"/> + <paramref
	/// name="length"/> is greater than the length of this instance.
	/// </exception>
	public new SafeLPTSTR Remove(int startIndex, int length) { base.Remove(startIndex, length); return this; }

	/// <summary>Replaces all occurrences of a specified string in this instance with another specified string.</summary>
	/// <param name="oldValue">The string to replace.</param>
	/// <param name="newValue">The string that replaces <paramref name="oldValue"/>, or <see langword="null"/>.</param>
	public SafeLPTSTR Replace(string oldValue, string? newValue) => Replace(oldValue, newValue, 0, Length);

	/// <summary>Replaces the specified old value.</summary>
	/// <param name="oldValue">The string to replace.</param>
	/// <param name="newValue">The string that replaces <paramref name="oldValue"/>, or <see langword="null"/>.</param>
	/// <param name="startIndex">The position in this instance where the substring begins.</param>
	/// <param name="count">The length of the substring.</param>
	public new SafeLPTSTR Replace(string oldValue, string? newValue, int startIndex, int count) { base.Replace(oldValue, newValue, startIndex, count); return this; }

	/// <summary>Replaces all occurrences of a specified character in this instance with another specified character.</summary>
	/// <param name="oldChar">The character to replace.</param>
	/// <param name="newChar">The character that replaces <paramref name="oldChar"/>.</param>
	public SafeLPTSTR Replace(char oldChar, char newChar) => Replace(oldChar, newChar, 0, Length);

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
	public new SafeLPTSTR Replace(char oldChar, char newChar, int startIndex, int count) { base.Replace(oldChar, newChar, startIndex, count); return this; }
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

/// <summary>Class that reprents a LPWSTR with allocated memory behind it.</summary>
public class SafeLPWSTR : SafeMemString<CoTaskMemoryMethods>
{
	const CharSet thisCharSet = CharSet.Unicode;

	/// <summary>Initializes a new instance of the <see cref="SafeLPWSTR"/> class.</summary>
	/// <param name="s">The string value.</param>
	public SafeLPWSTR(string s) : base(s, thisCharSet) { }

	/// <summary>Initializes a new instance of the <see cref="SafeLPWSTR"/> class.</summary>
	/// <param name="s">The string value.</param>
	/// <param name="capacity">The size of the buffer in characters.</param>
	public SafeLPWSTR(string s, int capacity) : base(s, capacity, thisCharSet) { }

	/// <summary>Initializes a new instance of the <see cref="SafeLPWSTR"/> class.</summary>
	/// <param name="s">The string value.</param>
	public SafeLPWSTR(SecureString s) : base(s, thisCharSet) { }

	/// <summary>Initializes a new instance of the <see cref="SafeLPWSTR"/> class.</summary>
	/// <param name="capacity">The size of the buffer in characters, including the null character terminator.</param>
	public SafeLPWSTR(int capacity) : base(capacity, thisCharSet) { }

	/// <summary>Prevents a default instance of the <see cref="SafeLPWSTR"/> class from being created.</summary>
	private SafeLPWSTR() : base() { }

	/// <summary>Initializes a new instance of the <see cref="SafeLPWSTR"/> class.</summary>
	/// <param name="ptr">The PTR.</param>
	/// <param name="ownsHandle"><c>true</c> to reliably release the handle during finalization; <c>false</c> to prevent it.</param>
	/// <param name="allocatedBytes">The number of bytes allocated to <paramref name="ptr"/>.</param>
	[ExcludeFromCodeCoverage]
	private SafeLPWSTR(StrPtrUni ptr, bool ownsHandle = true, PInvoke.SizeT allocatedBytes = default) :
		base((IntPtr)ptr, thisCharSet, ownsHandle, allocatedBytes) { }

	/// <summary>Initializes a new instance of the <see cref="SafeLPWSTR"/> class.</summary>
	/// <param name="ptr">The PTR.</param>
	/// <param name="ownsHandle"><c>true</c> to reliably release the handle during finalization; <c>false</c> to prevent it.</param>
	/// <param name="allocatedBytes">The number of bytes allocated to <paramref name="ptr"/>.</param>
	[ExcludeFromCodeCoverage]
	private SafeLPWSTR(LPWSTR ptr, bool ownsHandle = true, PInvoke.SizeT allocatedBytes = default) :
		base((IntPtr)ptr, thisCharSet, ownsHandle, allocatedBytes) { }

	/// <summary>Represents a <c>null</c> value. Used primarily for comparison.</summary>
	/// <value>A null value.</value>
	public static SafeLPWSTR Null => new((LPWSTR)IntPtr.Zero, false);

	/// <summary>Returns the string value held by a <see cref="SafeLPWSTR"/>.</summary>
	/// <param name="s">The <see cref="SafeLPWSTR"/> instance.</param>
	/// <returns>A <see cref="string"/> value held by the <see cref="SafeLPWSTR"/> or <c>null</c> if the handle or value is invalid.</returns>
	public static implicit operator SafeLPWSTR(string s) => s.ToString();

	/// <summary>Returns the LPWSTR value held by a <see cref="SafeLPWSTR"/>.</summary>
	/// <param name="s">The <see cref="SafeLPWSTR"/> instance.</param>
	/// <returns>A <see cref="LPWSTR"/> value held by the <see cref="SafeLPWSTR"/> or <c>default</c> if the handle or value is invalid.</returns>
	public static implicit operator LPWSTR(SafeLPWSTR s) => (LPWSTR)s.handle;

	/// <summary>Returns the StrPtrUni value held by a <see cref="SafeLPWSTR"/>.</summary>
	/// <param name="s">The <see cref="SafeLPWSTR"/> instance.</param>
	/// <returns>A <see cref="StrPtrUni"/> value held by the <see cref="SafeLPWSTR"/> or <c>default</c> if the handle or value is invalid.</returns>
	public static implicit operator StrPtrUni(SafeLPWSTR s) => (StrPtrUni)s.handle;

	/// <summary>Appends a copy of the specified string to this instance.</summary>
	/// <param name="value">The string to append.</param>
	/// <returns>A reference to this instance after the append operation has completed.</returns>
	public new SafeLPWSTR Append(string? value) { base.Append(value); return this; }

	/// <summary>Appends a copy of the specified value to this instance.</summary>
	/// <param name="value">The value to append.</param>
	/// <returns>A reference to this instance after the append operation has completed.</returns>
	public SafeLPWSTR Append(SafeLPWSTR value) => Append(value.ToString());

	/// <summary>Inserts a string into this instance at the specified character position.</summary>
	/// <param name="index">The position in this instance where insertion begins.</param>
	/// <param name="value">The string to insert.</param>
	/// <exception cref="System.ArgumentOutOfRangeException">
	/// <paramref name="index"/> is less than zero or greater than the current length of this instance.
	/// </exception>
	public new SafeLPWSTR Insert(int index, string? value) { base.Insert(index, value); return this; }

	/// <summary>Removes the specified range of characters from this instance.</summary>
	/// <param name="startIndex">The zero-based position in this instance where removal begins.</param>
	/// <param name="length">The number of characters to remove.</param>
	/// <exception cref="System.ArgumentOutOfRangeException">
	/// If <paramref name="startIndex"/> or <paramref name="length"/> is less than zero, or <paramref name="startIndex"/> + <paramref
	/// name="length"/> is greater than the length of this instance.
	/// </exception>
	public new SafeLPWSTR Remove(int startIndex, int length) { base.Remove(startIndex, length); return this; }

	/// <summary>Replaces all occurrences of a specified string in this instance with another specified string.</summary>
	/// <param name="oldValue">The string to replace.</param>
	/// <param name="newValue">The string that replaces <paramref name="oldValue"/>, or <see langword="null"/>.</param>
	public SafeLPWSTR Replace(string oldValue, string? newValue) => Replace(oldValue, newValue, 0, Length);

	/// <summary>Replaces the specified old value.</summary>
	/// <param name="oldValue">The string to replace.</param>
	/// <param name="newValue">The string that replaces <paramref name="oldValue"/>, or <see langword="null"/>.</param>
	/// <param name="startIndex">The position in this instance where the substring begins.</param>
	/// <param name="count">The length of the substring.</param>
	public new SafeLPWSTR Replace(string oldValue, string? newValue, int startIndex, int count) { base.Replace(oldValue, newValue, startIndex, count); return this; }

	/// <summary>Replaces all occurrences of a specified character in this instance with another specified character.</summary>
	/// <param name="oldChar">The character to replace.</param>
	/// <param name="newChar">The character that replaces <paramref name="oldChar"/>.</param>
	public SafeLPWSTR Replace(char oldChar, char newChar) => Replace(oldChar, newChar, 0, Length);

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
	public new SafeLPWSTR Replace(char oldChar, char newChar, int startIndex, int count) { base.Replace(oldChar, newChar, startIndex, count); return this; }
}

