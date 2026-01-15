using System.Diagnostics.CodeAnalysis;
using System.Security;

namespace Vanara.InteropServices;

/// <summary>Class that reprents a LPSTR with allocated memory behind it.</summary>
public class SafeLPSTR : SafeMemString<CoTaskMemoryMethods>
{
	const CharSet thisCharSet = CharSet.Ansi;

	/// <summary>Initializes a new instance of the <see cref="SafeLPSTR"/> class.</summary>
	/// <param name="s">The string value.</param>
	public SafeLPSTR(string? s) : base(s, thisCharSet) { }

	/// <summary>Initializes a new instance of the <see cref="SafeLPSTR"/> class.</summary>
	/// <param name="s">The string value.</param>
	/// <param name="capacity">The size of the buffer in characters.</param>
	public SafeLPSTR(string? s, int capacity) : base(s, capacity, thisCharSet) { }

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

/// <summary>Class that reprents a LPTSTR with allocated memory behind it.</summary>
public class SafeLPTSTR : SafeMemString<CoTaskMemoryMethods>
{
	const CharSet thisCharSet = CharSet.Auto;

	/// <summary>Initializes a new instance of the <see cref="SafeLPTSTR"/> class.</summary>
	/// <param name="s">The string value.</param>
	public SafeLPTSTR(string? s) : base(s, thisCharSet) { }

	/// <summary>Initializes a new instance of the <see cref="SafeLPTSTR"/> class.</summary>
	/// <param name="s">The string value.</param>
	/// <param name="capacity">The size of the buffer in characters.</param>
	public SafeLPTSTR(string? s, int capacity) : base(s, capacity, thisCharSet) { }

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

/// <summary>Class that reprents a LPWSTR with allocated memory behind it.</summary>
public class SafeLPWSTR : SafeMemString<CoTaskMemoryMethods>
{
	const CharSet thisCharSet = CharSet.Unicode;

	/// <summary>Initializes a new instance of the <see cref="SafeLPWSTR"/> class.</summary>
	/// <param name="s">The string value.</param>
	public SafeLPWSTR(string? s) : base(s, thisCharSet) { }

	/// <summary>Initializes a new instance of the <see cref="SafeLPWSTR"/> class.</summary>
	/// <param name="s">The string value.</param>
	/// <param name="capacity">The size of the buffer in characters.</param>
	public SafeLPWSTR(string? s, int capacity) : base(s, capacity, thisCharSet) { }

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

