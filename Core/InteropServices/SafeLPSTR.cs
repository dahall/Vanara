using System.Diagnostics.CodeAnalysis;
using System.Security;

namespace Vanara.InteropServices;

/// <summary>Class that reprents a PSTR with allocated memory behind it.</summary>
public class SafePSTR : SafeMemString<CoTaskMemoryMethods>
{
	const CharSet thisCharSet = CharSet.Ansi;

	/// <summary>Initializes a new instance of the <see cref="SafePSTR"/> class.</summary>
	/// <param name="s">The string value.</param>
	public SafePSTR(string? s) : base(s, thisCharSet) { }

	/// <summary>Initializes a new instance of the <see cref="SafePSTR"/> class.</summary>
	/// <param name="s">The string value.</param>
	/// <param name="capacity">The size of the buffer in characters.</param>
	public SafePSTR(string? s, int capacity) : base(s, capacity, thisCharSet) { }

	/// <summary>Initializes a new instance of the <see cref="SafePSTR"/> class.</summary>
	/// <param name="s">The string value.</param>
	public SafePSTR(SecureString s) : base(s, thisCharSet) { }

	/// <summary>Initializes a new instance of the <see cref="SafePSTR"/> class.</summary>
	/// <param name="capacity">The size of the buffer in characters, including the null character terminator.</param>
	public SafePSTR(int capacity) : base(capacity, thisCharSet) { }

	/// <summary>Prevents a default instance of the <see cref="SafePSTR"/> class from being created.</summary>
	private SafePSTR() : base() { }

	/// <summary>Initializes a new instance of the <see cref="SafePSTR"/> class.</summary>
	/// <param name="ptr">The PTR.</param>
	/// <param name="ownsHandle"><c>true</c> to reliably release the handle during finalization; <c>false</c> to prevent it.</param>
	/// <param name="allocatedBytes">The number of bytes allocated to <paramref name="ptr"/>.</param>
	[ExcludeFromCodeCoverage]
	private SafePSTR(StrPtrAnsi ptr, bool ownsHandle = true, PInvoke.SizeT allocatedBytes = default) :
		base((IntPtr)ptr, thisCharSet, ownsHandle, allocatedBytes) { }

	/// <summary>Initializes a new instance of the <see cref="SafePSTR"/> class.</summary>
	/// <param name="ptr">The PTR.</param>
	/// <param name="ownsHandle"><c>true</c> to reliably release the handle during finalization; <c>false</c> to prevent it.</param>
	/// <param name="allocatedBytes">The number of bytes allocated to <paramref name="ptr"/>.</param>
	[ExcludeFromCodeCoverage]
	private SafePSTR(PSTR ptr, bool ownsHandle = true, PInvoke.SizeT allocatedBytes = default) :
		base((IntPtr)ptr, thisCharSet, ownsHandle, allocatedBytes) { }

	/// <summary>Represents a <c>null</c> value. Used primarily for comparison.</summary>
	/// <value>A null value.</value>
	public static SafePSTR Null => new((PSTR)IntPtr.Zero, false);

	/// <summary>Returns the string value held by a <see cref="SafePSTR"/>.</summary>
	/// <param name="s">The <see cref="SafePSTR"/> instance.</param>
	/// <returns>A <see cref="string"/> value held by the <see cref="SafePSTR"/> or <c>null</c> if the handle or value is invalid.</returns>
	public static implicit operator SafePSTR(string s) => s.ToString();

	/// <summary>Returns the PSTR value held by a <see cref="SafePSTR"/>.</summary>
	/// <param name="s">The <see cref="SafePSTR"/> instance.</param>
	/// <returns>A <see cref="PSTR"/> value held by the <see cref="SafePSTR"/> or <c>default</c> if the handle or value is invalid.</returns>
	public static implicit operator PSTR(SafePSTR s) => (PSTR)s.handle;

	/// <summary>Returns the StrPtrAnsi value held by a <see cref="SafePSTR"/>.</summary>
	/// <param name="s">The <see cref="SafePSTR"/> instance.</param>
	/// <returns>A <see cref="StrPtrAnsi"/> value held by the <see cref="SafePSTR"/> or <c>default</c> if the handle or value is invalid.</returns>
	public static implicit operator StrPtrAnsi(SafePSTR s) => (StrPtrAnsi)s.handle;

	/// <summary>Appends a copy of the specified string to this instance.</summary>
	/// <param name="value">The string to append.</param>
	/// <returns>A reference to this instance after the append operation has completed.</returns>
	public new SafePSTR Append(string? value) { base.Append(value); return this; }

	/// <summary>Appends a copy of the specified value to this instance.</summary>
	/// <param name="value">The value to append.</param>
	/// <returns>A reference to this instance after the append operation has completed.</returns>
	public SafePSTR Append(SafePSTR value) => Append(value.ToString());

	/// <summary>Inserts a string into this instance at the specified character position.</summary>
	/// <param name="index">The position in this instance where insertion begins.</param>
	/// <param name="value">The string to insert.</param>
	/// <exception cref="System.ArgumentOutOfRangeException">
	/// <paramref name="index"/> is less than zero or greater than the current length of this instance.
	/// </exception>
	public new SafePSTR Insert(int index, string? value) { base.Insert(index, value); return this; }

	/// <summary>Removes the specified range of characters from this instance.</summary>
	/// <param name="startIndex">The zero-based position in this instance where removal begins.</param>
	/// <param name="length">The number of characters to remove.</param>
	/// <exception cref="System.ArgumentOutOfRangeException">
	/// If <paramref name="startIndex"/> or <paramref name="length"/> is less than zero, or <paramref name="startIndex"/> + <paramref
	/// name="length"/> is greater than the length of this instance.
	/// </exception>
	public new SafePSTR Remove(int startIndex, int length) { base.Remove(startIndex, length); return this; }

	/// <summary>Replaces all occurrences of a specified string in this instance with another specified string.</summary>
	/// <param name="oldValue">The string to replace.</param>
	/// <param name="newValue">The string that replaces <paramref name="oldValue"/>, or <see langword="null"/>.</param>
	public SafePSTR Replace(string oldValue, string? newValue) => Replace(oldValue, newValue, 0, Length);

	/// <summary>Replaces the specified old value.</summary>
	/// <param name="oldValue">The string to replace.</param>
	/// <param name="newValue">The string that replaces <paramref name="oldValue"/>, or <see langword="null"/>.</param>
	/// <param name="startIndex">The position in this instance where the substring begins.</param>
	/// <param name="count">The length of the substring.</param>
	public new SafePSTR Replace(string oldValue, string? newValue, int startIndex, int count) { base.Replace(oldValue, newValue, startIndex, count); return this; }

	/// <summary>Replaces all occurrences of a specified character in this instance with another specified character.</summary>
	/// <param name="oldChar">The character to replace.</param>
	/// <param name="newChar">The character that replaces <paramref name="oldChar"/>.</param>
	public SafePSTR Replace(char oldChar, char newChar) => Replace(oldChar, newChar, 0, Length);

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
	public new SafePSTR Replace(char oldChar, char newChar, int startIndex, int count) { base.Replace(oldChar, newChar, startIndex, count); return this; }
}

/// <summary>Class that reprents a PTSTR with allocated memory behind it.</summary>
public class SafePTSTR : SafeMemString<CoTaskMemoryMethods>
{
	const CharSet thisCharSet = CharSet.Auto;

	/// <summary>Initializes a new instance of the <see cref="SafePTSTR"/> class.</summary>
	/// <param name="s">The string value.</param>
	public SafePTSTR(string? s) : base(s, thisCharSet) { }

	/// <summary>Initializes a new instance of the <see cref="SafePTSTR"/> class.</summary>
	/// <param name="s">The string value.</param>
	/// <param name="capacity">The size of the buffer in characters.</param>
	public SafePTSTR(string? s, int capacity) : base(s, capacity, thisCharSet) { }

	/// <summary>Initializes a new instance of the <see cref="SafePTSTR"/> class.</summary>
	/// <param name="s">The string value.</param>
	public SafePTSTR(SecureString s) : base(s, thisCharSet) { }

	/// <summary>Initializes a new instance of the <see cref="SafePTSTR"/> class.</summary>
	/// <param name="capacity">The size of the buffer in characters, including the null character terminator.</param>
	public SafePTSTR(int capacity) : base(capacity, thisCharSet) { }

	/// <summary>Prevents a default instance of the <see cref="SafePTSTR"/> class from being created.</summary>
	private SafePTSTR() : base() { }

	/// <summary>Initializes a new instance of the <see cref="SafePTSTR"/> class.</summary>
	/// <param name="ptr">The PTR.</param>
	/// <param name="ownsHandle"><c>true</c> to reliably release the handle during finalization; <c>false</c> to prevent it.</param>
	/// <param name="allocatedBytes">The number of bytes allocated to <paramref name="ptr"/>.</param>
	[ExcludeFromCodeCoverage]
	private SafePTSTR(StrPtrAuto ptr, bool ownsHandle = true, PInvoke.SizeT allocatedBytes = default) :
		base((IntPtr)ptr, thisCharSet, ownsHandle, allocatedBytes) { }

	/// <summary>Initializes a new instance of the <see cref="SafePTSTR"/> class.</summary>
	/// <param name="ptr">The PTR.</param>
	/// <param name="ownsHandle"><c>true</c> to reliably release the handle during finalization; <c>false</c> to prevent it.</param>
	/// <param name="allocatedBytes">The number of bytes allocated to <paramref name="ptr"/>.</param>
	[ExcludeFromCodeCoverage]
	private SafePTSTR(PTSTR ptr, bool ownsHandle = true, PInvoke.SizeT allocatedBytes = default) :
		base((IntPtr)ptr, thisCharSet, ownsHandle, allocatedBytes) { }

	/// <summary>Represents a <c>null</c> value. Used primarily for comparison.</summary>
	/// <value>A null value.</value>
	public static SafePTSTR Null => new((PTSTR)IntPtr.Zero, false);

	/// <summary>Returns the string value held by a <see cref="SafePTSTR"/>.</summary>
	/// <param name="s">The <see cref="SafePTSTR"/> instance.</param>
	/// <returns>A <see cref="string"/> value held by the <see cref="SafePTSTR"/> or <c>null</c> if the handle or value is invalid.</returns>
	public static implicit operator SafePTSTR(string s) => s.ToString();

	/// <summary>Returns the PTSTR value held by a <see cref="SafePTSTR"/>.</summary>
	/// <param name="s">The <see cref="SafePTSTR"/> instance.</param>
	/// <returns>A <see cref="PTSTR"/> value held by the <see cref="SafePTSTR"/> or <c>default</c> if the handle or value is invalid.</returns>
	public static implicit operator PTSTR(SafePTSTR s) => (PTSTR)s.handle;

	/// <summary>Returns the StrPtrAuto value held by a <see cref="SafePTSTR"/>.</summary>
	/// <param name="s">The <see cref="SafePTSTR"/> instance.</param>
	/// <returns>A <see cref="StrPtrAuto"/> value held by the <see cref="SafePTSTR"/> or <c>default</c> if the handle or value is invalid.</returns>
	public static implicit operator StrPtrAuto(SafePTSTR s) => (StrPtrAuto)s.handle;

	/// <summary>Appends a copy of the specified string to this instance.</summary>
	/// <param name="value">The string to append.</param>
	/// <returns>A reference to this instance after the append operation has completed.</returns>
	public new SafePTSTR Append(string? value) { base.Append(value); return this; }

	/// <summary>Appends a copy of the specified value to this instance.</summary>
	/// <param name="value">The value to append.</param>
	/// <returns>A reference to this instance after the append operation has completed.</returns>
	public SafePTSTR Append(SafePTSTR value) => Append(value.ToString());

	/// <summary>Inserts a string into this instance at the specified character position.</summary>
	/// <param name="index">The position in this instance where insertion begins.</param>
	/// <param name="value">The string to insert.</param>
	/// <exception cref="System.ArgumentOutOfRangeException">
	/// <paramref name="index"/> is less than zero or greater than the current length of this instance.
	/// </exception>
	public new SafePTSTR Insert(int index, string? value) { base.Insert(index, value); return this; }

	/// <summary>Removes the specified range of characters from this instance.</summary>
	/// <param name="startIndex">The zero-based position in this instance where removal begins.</param>
	/// <param name="length">The number of characters to remove.</param>
	/// <exception cref="System.ArgumentOutOfRangeException">
	/// If <paramref name="startIndex"/> or <paramref name="length"/> is less than zero, or <paramref name="startIndex"/> + <paramref
	/// name="length"/> is greater than the length of this instance.
	/// </exception>
	public new SafePTSTR Remove(int startIndex, int length) { base.Remove(startIndex, length); return this; }

	/// <summary>Replaces all occurrences of a specified string in this instance with another specified string.</summary>
	/// <param name="oldValue">The string to replace.</param>
	/// <param name="newValue">The string that replaces <paramref name="oldValue"/>, or <see langword="null"/>.</param>
	public SafePTSTR Replace(string oldValue, string? newValue) => Replace(oldValue, newValue, 0, Length);

	/// <summary>Replaces the specified old value.</summary>
	/// <param name="oldValue">The string to replace.</param>
	/// <param name="newValue">The string that replaces <paramref name="oldValue"/>, or <see langword="null"/>.</param>
	/// <param name="startIndex">The position in this instance where the substring begins.</param>
	/// <param name="count">The length of the substring.</param>
	public new SafePTSTR Replace(string oldValue, string? newValue, int startIndex, int count) { base.Replace(oldValue, newValue, startIndex, count); return this; }

	/// <summary>Replaces all occurrences of a specified character in this instance with another specified character.</summary>
	/// <param name="oldChar">The character to replace.</param>
	/// <param name="newChar">The character that replaces <paramref name="oldChar"/>.</param>
	public SafePTSTR Replace(char oldChar, char newChar) => Replace(oldChar, newChar, 0, Length);

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
	public new SafePTSTR Replace(char oldChar, char newChar, int startIndex, int count) { base.Replace(oldChar, newChar, startIndex, count); return this; }
}

/// <summary>Class that reprents a PWSTR with allocated memory behind it.</summary>
public class SafePWSTR : SafeMemString<CoTaskMemoryMethods>
{
	const CharSet thisCharSet = CharSet.Unicode;

	/// <summary>Initializes a new instance of the <see cref="SafePWSTR"/> class.</summary>
	/// <param name="s">The string value.</param>
	public SafePWSTR(string? s) : base(s, thisCharSet) { }

	/// <summary>Initializes a new instance of the <see cref="SafePWSTR"/> class.</summary>
	/// <param name="s">The string value.</param>
	/// <param name="capacity">The size of the buffer in characters.</param>
	public SafePWSTR(string? s, int capacity) : base(s, capacity, thisCharSet) { }

	/// <summary>Initializes a new instance of the <see cref="SafePWSTR"/> class.</summary>
	/// <param name="s">The string value.</param>
	public SafePWSTR(SecureString s) : base(s, thisCharSet) { }

	/// <summary>Initializes a new instance of the <see cref="SafePWSTR"/> class.</summary>
	/// <param name="capacity">The size of the buffer in characters, including the null character terminator.</param>
	public SafePWSTR(int capacity) : base(capacity, thisCharSet) { }

	/// <summary>Prevents a default instance of the <see cref="SafePWSTR"/> class from being created.</summary>
	private SafePWSTR() : base() { }

	/// <summary>Initializes a new instance of the <see cref="SafePWSTR"/> class.</summary>
	/// <param name="ptr">The PTR.</param>
	/// <param name="ownsHandle"><c>true</c> to reliably release the handle during finalization; <c>false</c> to prevent it.</param>
	/// <param name="allocatedBytes">The number of bytes allocated to <paramref name="ptr"/>.</param>
	[ExcludeFromCodeCoverage]
	private SafePWSTR(StrPtrUni ptr, bool ownsHandle = true, PInvoke.SizeT allocatedBytes = default) :
		base((IntPtr)ptr, thisCharSet, ownsHandle, allocatedBytes) { }

	/// <summary>Initializes a new instance of the <see cref="SafePWSTR"/> class.</summary>
	/// <param name="ptr">The PTR.</param>
	/// <param name="ownsHandle"><c>true</c> to reliably release the handle during finalization; <c>false</c> to prevent it.</param>
	/// <param name="allocatedBytes">The number of bytes allocated to <paramref name="ptr"/>.</param>
	[ExcludeFromCodeCoverage]
	private SafePWSTR(PWSTR ptr, bool ownsHandle = true, PInvoke.SizeT allocatedBytes = default) :
		base((IntPtr)ptr, thisCharSet, ownsHandle, allocatedBytes) { }

	/// <summary>Represents a <c>null</c> value. Used primarily for comparison.</summary>
	/// <value>A null value.</value>
	public static SafePWSTR Null => new((PWSTR)IntPtr.Zero, false);

	/// <summary>Returns the string value held by a <see cref="SafePWSTR"/>.</summary>
	/// <param name="s">The <see cref="SafePWSTR"/> instance.</param>
	/// <returns>A <see cref="string"/> value held by the <see cref="SafePWSTR"/> or <c>null</c> if the handle or value is invalid.</returns>
	public static implicit operator SafePWSTR(string s) => s.ToString();

	/// <summary>Returns the PWSTR value held by a <see cref="SafePWSTR"/>.</summary>
	/// <param name="s">The <see cref="SafePWSTR"/> instance.</param>
	/// <returns>A <see cref="PWSTR"/> value held by the <see cref="SafePWSTR"/> or <c>default</c> if the handle or value is invalid.</returns>
	public static implicit operator PWSTR(SafePWSTR s) => (PWSTR)s.handle;

	/// <summary>Returns the StrPtrUni value held by a <see cref="SafePWSTR"/>.</summary>
	/// <param name="s">The <see cref="SafePWSTR"/> instance.</param>
	/// <returns>A <see cref="StrPtrUni"/> value held by the <see cref="SafePWSTR"/> or <c>default</c> if the handle or value is invalid.</returns>
	public static implicit operator StrPtrUni(SafePWSTR s) => (StrPtrUni)s.handle;

	/// <summary>Appends a copy of the specified string to this instance.</summary>
	/// <param name="value">The string to append.</param>
	/// <returns>A reference to this instance after the append operation has completed.</returns>
	public new SafePWSTR Append(string? value) { base.Append(value); return this; }

	/// <summary>Appends a copy of the specified value to this instance.</summary>
	/// <param name="value">The value to append.</param>
	/// <returns>A reference to this instance after the append operation has completed.</returns>
	public SafePWSTR Append(SafePWSTR value) => Append(value.ToString());

	/// <summary>Inserts a string into this instance at the specified character position.</summary>
	/// <param name="index">The position in this instance where insertion begins.</param>
	/// <param name="value">The string to insert.</param>
	/// <exception cref="System.ArgumentOutOfRangeException">
	/// <paramref name="index"/> is less than zero or greater than the current length of this instance.
	/// </exception>
	public new SafePWSTR Insert(int index, string? value) { base.Insert(index, value); return this; }

	/// <summary>Removes the specified range of characters from this instance.</summary>
	/// <param name="startIndex">The zero-based position in this instance where removal begins.</param>
	/// <param name="length">The number of characters to remove.</param>
	/// <exception cref="System.ArgumentOutOfRangeException">
	/// If <paramref name="startIndex"/> or <paramref name="length"/> is less than zero, or <paramref name="startIndex"/> + <paramref
	/// name="length"/> is greater than the length of this instance.
	/// </exception>
	public new SafePWSTR Remove(int startIndex, int length) { base.Remove(startIndex, length); return this; }

	/// <summary>Replaces all occurrences of a specified string in this instance with another specified string.</summary>
	/// <param name="oldValue">The string to replace.</param>
	/// <param name="newValue">The string that replaces <paramref name="oldValue"/>, or <see langword="null"/>.</param>
	public SafePWSTR Replace(string oldValue, string? newValue) => Replace(oldValue, newValue, 0, Length);

	/// <summary>Replaces the specified old value.</summary>
	/// <param name="oldValue">The string to replace.</param>
	/// <param name="newValue">The string that replaces <paramref name="oldValue"/>, or <see langword="null"/>.</param>
	/// <param name="startIndex">The position in this instance where the substring begins.</param>
	/// <param name="count">The length of the substring.</param>
	public new SafePWSTR Replace(string oldValue, string? newValue, int startIndex, int count) { base.Replace(oldValue, newValue, startIndex, count); return this; }

	/// <summary>Replaces all occurrences of a specified character in this instance with another specified character.</summary>
	/// <param name="oldChar">The character to replace.</param>
	/// <param name="newChar">The character that replaces <paramref name="oldChar"/>.</param>
	public SafePWSTR Replace(char oldChar, char newChar) => Replace(oldChar, newChar, 0, Length);

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
	public new SafePWSTR Replace(char oldChar, char newChar, int startIndex, int count) { base.Replace(oldChar, newChar, startIndex, count); return this; }
}

