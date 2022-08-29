using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Vanara.Extensions;

namespace Vanara.InteropServices
{
	/// <summary>The GuidPtr structure represents a LPGUID.</summary>
	[StructLayout(LayoutKind.Sequential), DebuggerDisplay("{ptr}, {ToString()}")]
	public struct GuidPtr : IEquatable<GuidPtr>, IEquatable<Guid?>, IEquatable<IntPtr>
	{
		private IntPtr ptr;

		/// <summary>Initializes a new instance of the <see cref="GuidPtr"/> struct by allocating memory with <see cref="Marshal.AllocCoTaskMem(int)"/>.</summary>
		/// <param name="g">The guid value.</param>
		public GuidPtr(Guid g) => ptr = g.MarshalToPtr(Marshal.AllocCoTaskMem, out _);

		/// <summary>Gets a value indicating whether this instance is equivalent to null pointer or void*.</summary>
		/// <value><c>true</c> if this instance is null; otherwise, <c>false</c>.</value>
		public bool IsNull => ptr == IntPtr.Zero;

		/// <summary>Gets the value of the Guid.</summary>
		/// <value>The value pointed to by this pointer.</value>
		public Guid? Value => IsNull ? null : ptr.ToStructure<Guid>();

		/// <summary>Assigns a new Guid value to the pointer.</summary>
		/// <param name="g">The guid value.</param>
		public void Assign(Guid g)
		{
			if (IsNull)
				ptr = g.MarshalToPtr(Marshal.AllocCoTaskMem, out _);
			else
				Marshal.StructureToPtr(g, ptr, true);
		}

		/// <summary>Determines whether the specified <see cref="Nullable{Guid}"/>, is equal to this instance.</summary>
		/// <param name="other">The <see cref="Nullable{Guid}"/> to compare with this instance.</param>
		/// <returns><c>true</c> if the specified <see cref="Nullable{Guid}"/> is equal to this instance; otherwise, <c>false</c>.</returns>
		public bool Equals(Guid? other) => EqualityComparer<Guid?>.Default.Equals(Value, other);

		/// <summary>Determines whether the specified <see cref="GuidPtr"/>, is equal to this instance.</summary>
		/// <param name="other">The <see cref="GuidPtr"/> to compare with this instance.</param>
		/// <returns><c>true</c> if the specified <see cref="GuidPtr"/> is equal to this instance; otherwise, <c>false</c>.</returns>
		public bool Equals(GuidPtr other) => Equals(other.ptr);

		/// <summary>Determines whether the specified <see cref="IntPtr"/>, is equal to this instance.</summary>
		/// <param name="other">The <see cref="IntPtr"/> to compare with this instance.</param>
		/// <returns><c>true</c> if the specified <see cref="IntPtr"/> is equal to this instance; otherwise, <c>false</c>.</returns>
		public bool Equals(IntPtr other) => EqualityComparer<IntPtr>.Default.Equals(ptr, other);

		/// <inheritdoc/>
		public override bool Equals(object obj) => obj switch
		{
			null => IsNull,
			IntPtr p => Equals(p),
			GuidPtr gp => Equals(gp),
			Guid g => Equals(g),
			_ => base.Equals(obj),
		};

		/// <summary>Frees the unmanaged memory.</summary>
		public void Free() { Marshal.FreeCoTaskMem(ptr); ptr = IntPtr.Zero; }

		/// <inheritdoc/>
		public override int GetHashCode() => ptr.GetHashCode();

		/// <inheritdoc/>
		public override string ToString() => Value?.ToString("B") ?? "";

		/// <summary>Performs an implicit conversion from <see cref="GuidPtr"/> to <see cref="System.Nullable{Guid}"/>.</summary>
		/// <param name="g">The pointer to a Guid.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator Guid?(GuidPtr g) => g.Value;

		/// <summary>Performs an explicit conversion from <see cref="GuidPtr"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="g">The pointer to a Guid.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(GuidPtr g) => g.ptr;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="GuidPtr"/>.</summary>
		/// <param name="p">The pointer.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator GuidPtr(IntPtr p) => new() { ptr = p };

		/// <summary>Performs an implicit conversion from <see cref="SafeAllocatedMemoryHandleBase"/> to <see cref="GuidPtr"/>.</summary>
		/// <param name="p">The safe memory handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator GuidPtr(SafeAllocatedMemoryHandleBase p) => new() { ptr = p };

		/// <summary>Determines whether two specified instances of <see cref="GuidPtr"/> are equal.</summary>
		/// <param name="left">The first pointer or handle to compare.</param>
		/// <param name="right">The second pointer or handle to compare.</param>
		/// <returns><see langword="true"/> if <paramref name="left"/> equals <paramref name="right"/>; otherwise, <see langword="false"/>.</returns>
		public static bool operator ==(GuidPtr left, GuidPtr right) => left.Equals(right);

		/// <summary>Determines whether two specified instances of <see cref="GuidPtr"/> are not equal.</summary>
		/// <param name="left">The first pointer or handle to compare.</param>
		/// <param name="right">The second pointer or handle to compare.</param>
		/// <returns><see langword="true"/> if <paramref name="left"/> does not equal <paramref name="right"/>; otherwise, <see langword="false"/>.</returns>
		public static bool operator !=(GuidPtr left, GuidPtr right) => !left.Equals(right);
	}

	/// <summary>The StrPtr structure represents a LPWSTR.</summary>
	[StructLayout(LayoutKind.Sequential), DebuggerDisplay("{ptr}, {ToString()}")]
	public struct StrPtrAnsi : IEquatable<string>, IEquatable<StrPtrAnsi>, IEquatable<IntPtr>
	{
		private IntPtr ptr;

		/// <summary>Initializes a new instance of the <see cref="StrPtrAnsi"/> struct.</summary>
		/// <param name="s">The string value.</param>
		public StrPtrAnsi(string s) => ptr = StringHelper.AllocString(s, CharSet.Ansi);

		/// <summary>Initializes a new instance of the <see cref="StrPtrAnsi"/> struct.</summary>
		/// <param name="charLen">Number of characters to reserve in memory.</param>
		public StrPtrAnsi(uint charLen) => ptr = StringHelper.AllocChars(charLen, CharSet.Ansi);

		/// <summary>Gets a value indicating whether this instance is equivalent to null pointer or void*.</summary>
		/// <value><c>true</c> if this instance is null; otherwise, <c>false</c>.</value>
		public bool IsNull => ptr == IntPtr.Zero;

		/// <summary>Indicates whether the specified string is <see langword="null"/> or an empty string ("").</summary>
		/// <returns>
		/// <see langword="true"/> if the value parameter is <see langword="null"/> or an empty string (""); otherwise, <see langword="false"/>.
		/// </returns>
		public bool IsNullOrEmpty => ptr == IntPtr.Zero || Marshal.ReadByte(ptr) == 0;

		/// <summary>Assigns a new string value to the pointer.</summary>
		/// <param name="s">The string value.</param>
		public void Assign(string s) => StringHelper.RefreshString(ref ptr, out var _, s, CharSet.Ansi);

		/// <summary>Assigns a new string value to the pointer.</summary>
		/// <param name="s">The string value.</param>
		/// <param name="charsAllocated">The character count allocated.</param>
		/// <returns><c>true</c> if new memory was allocated for the string; <c>false</c> if otherwise.</returns>
		public bool Assign(string s, out uint charsAllocated) => StringHelper.RefreshString(ref ptr, out charsAllocated, s, CharSet.Ansi);

		/// <summary>Assigns an integer to the pointer for uses such as LPSTR_TEXTCALLBACK.</summary>
		/// <param name="value">The value to assign.</param>
		public void AssignConstant(int value) { Free(); ptr = (IntPtr)value; }

		/// <summary>Determines whether the specified <see cref="IntPtr"/>, is equal to this instance.</summary>
		/// <param name="other">The <see cref="IntPtr"/> to compare with this instance.</param>
		/// <returns><c>true</c> if the specified <see cref="IntPtr"/> is equal to this instance; otherwise, <c>false</c>.</returns>
		public bool Equals(IntPtr other) => EqualityComparer<IntPtr>.Default.Equals(ptr, other);

		/// <summary>Determines whether the specified <see cref="IntPtr"/>, is equal to this instance.</summary>
		/// <param name="other">The <see cref="IntPtr"/> to compare with this instance.</param>
		/// <returns><c>true</c> if the specified <see cref="IntPtr"/> is equal to this instance; otherwise, <c>false</c>.</returns>
		public bool Equals(string other) => EqualityComparer<string>.Default.Equals(this, other);

		/// <summary>Determines whether the specified <see cref="StrPtrAnsi"/>, is equal to this instance.</summary>
		/// <param name="other">The <see cref="StrPtrAnsi"/> to compare with this instance.</param>
		/// <returns><c>true</c> if the specified <see cref="StrPtrAnsi"/> is equal to this instance; otherwise, <c>false</c>.</returns>
		public bool Equals(StrPtrAnsi other) => Equals(other.ptr);

		/// <summary>Determines whether the specified <see cref="object"/>, is equal to this instance.</summary>
		/// <param name="obj">The <see cref="object"/> to compare with this instance.</param>
		/// <returns><c>true</c> if the specified <see cref="object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
		public override bool Equals(object obj) => obj switch
		{
			null => IsNull,
			string s => Equals(s),
			StrPtrAnsi p => Equals(p),
			IntPtr p => Equals(p),
			_ => base.Equals(obj),
		};

		/// <summary>Frees the unmanaged string memory.</summary>
		public void Free() { StringHelper.FreeString(ptr, CharSet.Ansi); ptr = IntPtr.Zero; }

		/// <summary>Returns a hash code for this instance.</summary>
		/// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
		public override int GetHashCode() => ptr.GetHashCode();

		/// <summary>Returns a <see cref="string"/> that represents this instance.</summary>
		/// <returns>A <see cref="string"/> that represents this instance.</returns>
		public override string ToString() => StringHelper.GetString(ptr, CharSet.Ansi) ?? "null";

		/// <summary>Performs an implicit conversion from <see cref="StrPtrAnsi"/> to <see cref="string"/>.</summary>
		/// <param name="p">The <see cref="StrPtrAnsi"/> instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator string(StrPtrAnsi p) => p.IsNull ? null : p.ToString();

		/// <summary>Performs an explicit conversion from <see cref="StrPtrUni"/> to <see cref="sbyte"/>*.</summary>
		/// <param name="p">The <see cref="sbyte"/>* reference.</param>
		/// <returns>The resulting <see cref="sbyte"/>* from the conversion.</returns>
		public static unsafe explicit operator sbyte*(StrPtrAnsi p) => (sbyte*)p.ptr;

		/// <summary>Performs an explicit conversion from <see cref="StrPtrAnsi"/> to <see cref="System.IntPtr"/>.</summary>
		/// <param name="p">The <see cref="StrPtrAnsi"/> instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(StrPtrAnsi p) => p.ptr;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="StrPtrAnsi"/>.</summary>
		/// <param name="p">The pointer.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator StrPtrAnsi(IntPtr p) => new() { ptr = p };

		/// <summary>Performs an implicit conversion from <see cref="SafeLPSTR"/> to <see cref="StrPtrAnsi"/>.</summary>
		/// <param name="p">The safe memory handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator StrPtrAnsi(SafeLPSTR p) => new() { ptr = p };

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

	/// <summary>The StrPtr structure represents a LPTSTR.</summary>
	[StructLayout(LayoutKind.Sequential), DebuggerDisplay("{ptr}, {ToString()}")]
	public struct StrPtrAuto : IEquatable<string>, IEquatable<StrPtrAuto>, IEquatable<IntPtr>
	{
		private IntPtr ptr;

		/// <summary>Initializes a new instance of the <see cref="StrPtrAuto"/> struct.</summary>
		/// <param name="s">The string value.</param>
		public StrPtrAuto(string s) => ptr = StringHelper.AllocString(s);

		/// <summary>Initializes a new instance of the <see cref="StrPtrAuto"/> struct.</summary>
		/// <param name="charLen">Number of characters to reserve in memory.</param>
		public StrPtrAuto(uint charLen) => ptr = StringHelper.AllocChars(charLen);

		/// <summary>Gets a value indicating whether this instance is equivalent to null pointer or void*.</summary>
		/// <value><c>true</c> if this instance is null; otherwise, <c>false</c>.</value>
		public bool IsNull => ptr == IntPtr.Zero;

		/// <summary>Assigns a string pointer value to the pointer.</summary>
		/// <param name="stringPtr">The string pointer value.</param>
		public void Assign(IntPtr stringPtr) { Free(); ptr = stringPtr; }

		/// <summary>Assigns a new string value to the pointer.</summary>
		/// <param name="s">The string value.</param>
		public void Assign(string s) => StringHelper.RefreshString(ref ptr, out var _, s);

		/// <summary>Assigns a new string value to the pointer.</summary>
		/// <param name="s">The string value.</param>
		/// <param name="charsAllocated">The character count allocated.</param>
		/// <returns><c>true</c> if new memory was allocated for the string; <c>false</c> if otherwise.</returns>
		public bool Assign(string s, out uint charsAllocated) => StringHelper.RefreshString(ref ptr, out charsAllocated, s);

		/// <summary>Assigns an integer to the pointer for uses such as LPSTR_TEXTCALLBACK.</summary>
		/// <param name="value">The value to assign.</param>
		public void AssignConstant(int value) { Free(); ptr = (IntPtr)value; }

		/// <summary>Frees the unmanaged string memory.</summary>
		public void Free() { StringHelper.FreeString(ptr); ptr = IntPtr.Zero; }

		/// <summary>Indicates whether the specified string is <see langword="null"/> or an empty string ("").</summary>
		/// <returns>
		/// <see langword="true"/> if the value parameter is <see langword="null"/> or an empty string (""); otherwise, <see langword="false"/>.
		/// </returns>
		public bool IsNullOrEmpty => ptr == IntPtr.Zero || StringHelper.GetString(ptr, CharSet.Auto, 1) == string.Empty;

		/// <summary>Performs an implicit conversion from <see cref="StrPtrAuto"/> to <see cref="string"/>.</summary>
		/// <param name="p">The <see cref="StrPtrAuto"/> instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator string(StrPtrAuto p) => p.IsNull ? null : p.ToString();

		/// <summary>Performs an explicit conversion from <see cref="StrPtrAuto"/> to <see cref="System.IntPtr"/>.</summary>
		/// <param name="p">The <see cref="StrPtrAuto"/> instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(StrPtrAuto p) => p.ptr;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="StrPtrAuto"/>.</summary>
		/// <param name="p">The pointer.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator StrPtrAuto(IntPtr p) => new() { ptr = p };

		/// <summary>Performs an implicit conversion from <see cref="SafeLPTSTR"/> to <see cref="StrPtrAuto"/>.</summary>
		/// <param name="p">The safe memory handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator StrPtrAuto(SafeLPTSTR p) => new() { ptr = p };

		/// <summary>Determines whether the specified <see cref="IntPtr"/>, is equal to this instance.</summary>
		/// <param name="other">The <see cref="IntPtr"/> to compare with this instance.</param>
		/// <returns><c>true</c> if the specified <see cref="IntPtr"/> is equal to this instance; otherwise, <c>false</c>.</returns>
		public bool Equals(IntPtr other) => EqualityComparer<IntPtr>.Default.Equals(ptr, other);

		/// <summary>Determines whether the specified <see cref="IntPtr"/>, is equal to this instance.</summary>
		/// <param name="other">The <see cref="IntPtr"/> to compare with this instance.</param>
		/// <returns><c>true</c> if the specified <see cref="IntPtr"/> is equal to this instance; otherwise, <c>false</c>.</returns>
		public bool Equals(string other) => EqualityComparer<string>.Default.Equals(this, other);

		/// <summary>Determines whether the specified <see cref="StrPtrAuto"/>, is equal to this instance.</summary>
		/// <param name="other">The <see cref="StrPtrAuto"/> to compare with this instance.</param>
		/// <returns><c>true</c> if the specified <see cref="StrPtrAuto"/> is equal to this instance; otherwise, <c>false</c>.</returns>
		public bool Equals(StrPtrAuto other) => Equals(other.ptr);

		/// <summary>Determines whether the specified <see cref="object"/>, is equal to this instance.</summary>
		/// <param name="obj">The <see cref="object"/> to compare with this instance.</param>
		/// <returns><c>true</c> if the specified <see cref="object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
		public override bool Equals(object obj) => obj switch
		{
			null => IsNull,
			string s => Equals(s),
			StrPtrAuto p => Equals(p),
			IntPtr p => Equals(p),
			_ => base.Equals(obj),
		};

		/// <summary>Returns a hash code for this instance.</summary>
		/// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
		public override int GetHashCode() => ptr.GetHashCode();

		/// <summary>Returns a <see cref="string"/> that represents this instance.</summary>
		/// <returns>A <see cref="string"/> that represents this instance.</returns>
		public override string ToString() => StringHelper.GetString(ptr) ?? "null";

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

	/// <summary>The StrPtr structure represents a LPWSTR.</summary>
	[StructLayout(LayoutKind.Sequential), DebuggerDisplay("{ptr}, {ToString()}")]
	public struct StrPtrUni : IEquatable<string>, IEquatable<StrPtrUni>, IEquatable<IntPtr>
	{
		private IntPtr ptr;

		/// <summary>Initializes a new instance of the <see cref="StrPtrUni"/> struct.</summary>
		/// <param name="s">The string value.</param>
		public StrPtrUni(string s) => ptr = StringHelper.AllocString(s, CharSet.Unicode);

		/// <summary>Initializes a new instance of the <see cref="StrPtrUni"/> struct.</summary>
		/// <param name="charLen">Number of characters to reserve in memory.</param>
		public StrPtrUni(uint charLen) => ptr = StringHelper.AllocChars(charLen, CharSet.Unicode);

		/// <summary>Gets a value indicating whether this instance is equivalent to null pointer or void*.</summary>
		/// <value><c>true</c> if this instance is null; otherwise, <c>false</c>.</value>
		public bool IsNull => ptr == IntPtr.Zero;

		/// <summary>Assigns a new string value to the pointer.</summary>
		/// <param name="s">The string value.</param>
		public void Assign(string s) => StringHelper.RefreshString(ref ptr, out var _, s, CharSet.Unicode);

		/// <summary>Assigns a new string value to the pointer.</summary>
		/// <param name="s">The string value.</param>
		/// <param name="charsAllocated">The character count allocated.</param>
		/// <returns><c>true</c> if new memory was allocated for the string; <c>false</c> if otherwise.</returns>
		public bool Assign(string s, out uint charsAllocated) => StringHelper.RefreshString(ref ptr, out charsAllocated, s, CharSet.Unicode);

		/// <summary>Assigns an integer to the pointer for uses such as LPSTR_TEXTCALLBACK.</summary>
		/// <param name="value">The value to assign.</param>
		public void AssignConstant(int value) { Free(); ptr = (IntPtr)value; }

		/// <summary>Frees the unmanaged string memory.</summary>
		public void Free() { StringHelper.FreeString(ptr, CharSet.Unicode); ptr = IntPtr.Zero; }

		/// <summary>Indicates whether the specified string is <see langword="null"/> or an empty string ("").</summary>
		/// <returns>
		/// <see langword="true"/> if the value parameter is <see langword="null"/> or an empty string (""); otherwise, <see langword="false"/>.
		/// </returns>
		public bool IsNullOrEmpty => ptr == IntPtr.Zero || Marshal.ReadInt16(ptr) == 0;

		/// <summary>Performs an implicit conversion from <see cref="StrPtrUni"/> to <see cref="string"/>.</summary>
		/// <param name="p">The <see cref="StrPtrUni"/> instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator string(StrPtrUni p) => p.IsNull ? null : p.ToString();

		/// <summary>Performs an explicit conversion from <see cref="StrPtrUni"/> to <see cref="char"/>*.</summary>
		/// <param name="p">The <see cref="char"/>* reference.</param>
		/// <returns>The resulting <see cref="char"/>* from the conversion.</returns>
		public static unsafe explicit operator char*(StrPtrUni p) => (char*)p.ptr;

		/// <summary>Performs an explicit conversion from <see cref="StrPtrUni"/> to <see cref="System.IntPtr"/>.</summary>
		/// <param name="p">The <see cref="StrPtrUni"/> instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(StrPtrUni p) => p.ptr;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="StrPtrUni"/>.</summary>
		/// <param name="p">The pointer.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator StrPtrUni(IntPtr p) => new() { ptr = p };

		/// <summary>Performs an implicit conversion from <see cref="SafeLPWSTR"/> to <see cref="StrPtrUni"/>.</summary>
		/// <param name="p">The safe memory handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator StrPtrUni(SafeLPWSTR p) => new() { ptr = p };

		/// <summary>Determines whether the specified <see cref="IntPtr"/>, is equal to this instance.</summary>
		/// <param name="other">The <see cref="IntPtr"/> to compare with this instance.</param>
		/// <returns><c>true</c> if the specified <see cref="IntPtr"/> is equal to this instance; otherwise, <c>false</c>.</returns>
		public bool Equals(IntPtr other) => EqualityComparer<IntPtr>.Default.Equals(ptr, other);

		/// <summary>Determines whether the specified <see cref="IntPtr"/>, is equal to this instance.</summary>
		/// <param name="other">The <see cref="IntPtr"/> to compare with this instance.</param>
		/// <returns><c>true</c> if the specified <see cref="IntPtr"/> is equal to this instance; otherwise, <c>false</c>.</returns>
		public bool Equals(string other) => EqualityComparer<string>.Default.Equals(this, other);

		/// <summary>Determines whether the specified <see cref="StrPtrUni"/>, is equal to this instance.</summary>
		/// <param name="other">The <see cref="StrPtrUni"/> to compare with this instance.</param>
		/// <returns><c>true</c> if the specified <see cref="StrPtrUni"/> is equal to this instance; otherwise, <c>false</c>.</returns>
		public bool Equals(StrPtrUni other) => Equals(other.ptr);

		/// <summary>Determines whether the specified <see cref="object"/>, is equal to this instance.</summary>
		/// <param name="obj">The <see cref="object"/> to compare with this instance.</param>
		/// <returns><c>true</c> if the specified <see cref="object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
		public override bool Equals(object obj) => obj switch
		{
			null => IsNull,
			string s => Equals(s),
			StrPtrUni p => Equals(p),
			IntPtr p => Equals(p),
			_ => base.Equals(obj),
		};

		/// <summary>Returns a hash code for this instance.</summary>
		/// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
		public override int GetHashCode() => ptr.GetHashCode();

		/// <summary>Returns a <see cref="string"/> that represents this instance.</summary>
		/// <returns>A <see cref="string"/> that represents this instance.</returns>
		public override string ToString() => StringHelper.GetString(ptr, CharSet.Unicode) ?? "null";

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

	/// <summary>
	/// <para>Represents a GUID point, or REFGUID, that will automatically dispose the memory to which it points at the end of scope.</para>
	/// <note>You must use the <see cref="Null"/> value, or the parameter-less constructor to pass the equivalent of <see langword="null"/>.</note>
	/// </summary>
	public class SafeGuidPtr : SafeMemStruct<Guid, CoTaskMemoryMethods>
	{
		/// <summary>The equivalent of a <see langword="null"/> pointer to a GUID value.</summary>
		public static readonly SafeGuidPtr Null = new();

		/// <summary>
		/// Initializes a new instance of the <see cref="SafeGuidPtr"/> class. This value is equivalent to a <see langword="null"/> pointer.
		/// </summary>
		public SafeGuidPtr() : base(IntPtr.Zero, true, 0) { }

		/// <summary>Initializes a new instance of the <see cref="SafeGuidPtr"/> class.</summary>
		/// <param name="guid">The unique identifier to assign to the pointer.</param>
		public SafeGuidPtr(in Guid guid) : base(guid) { }

		/// <summary>Performs an implicit conversion from <see cref="System.Nullable{Guid}"/> to <see cref="SafeGuidPtr"/>.</summary>
		/// <param name="guid">The unique identifier.</param>
		/// <returns>The resulting <see cref="SafeGuidPtr"/> instance from the conversion.</returns>
		public static implicit operator SafeGuidPtr(Guid? guid) => guid.HasValue ? new SafeGuidPtr(guid.Value) : Null;
	}
}