using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Vanara.Extensions;

namespace Vanara.InteropServices
{
	/// <summary>The StrPtr structure represents a LPTSTR.</summary>
	[StructLayout(LayoutKind.Sequential), DebuggerDisplay("{ptr}, {ToString()}")]
	public struct StrPtrAuto
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

		/// <summary>Performs an implicit conversion from <see cref="StrPtrAuto"/> to <see cref="System.String"/>.</summary>
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
		public static implicit operator StrPtrAuto(IntPtr p) => new StrPtrAuto { ptr = p };

		/// <summary>Determines whether the specified <see cref="System.Object"/>, is equal to this instance.</summary>
		/// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
		/// <returns><c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
		public override bool Equals(object obj)
		{
			switch (obj)
			{
				case string s:
					return s.Equals(StringHelper.GetString(ptr, CharSet.Auto));
				case IntPtr p:
					return ptr.Equals(p);
				default:
					return base.Equals(obj);
			}
		}

		/// <summary>Returns a hash code for this instance.</summary>
		/// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
		public override int GetHashCode() => ptr.GetHashCode();

		/// <summary>Returns a <see cref="System.String"/> that represents this instance.</summary>
		/// <returns>A <see cref="System.String"/> that represents this instance.</returns>
		public override string ToString() => StringHelper.GetString(ptr) ?? "null";
	}

	/// <summary>The StrPtr structure represents a LPWSTR.</summary>
	[StructLayout(LayoutKind.Sequential), DebuggerDisplay("{ptr}, {ToString()}")]
	public struct StrPtrUni
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

		/// <summary>Performs an implicit conversion from <see cref="StrPtrUni"/> to <see cref="System.String"/>.</summary>
		/// <param name="p">The <see cref="StrPtrUni"/> instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator string(StrPtrUni p) => p.IsNull ? null : p.ToString();

		/// <summary>Performs an explicit conversion from <see cref="StrPtrUni"/> to <see cref="System.IntPtr"/>.</summary>
		/// <param name="p">The <see cref="StrPtrUni"/> instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(StrPtrUni p) => p.ptr;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="StrPtrUni"/>.</summary>
		/// <param name="p">The pointer.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator StrPtrUni(IntPtr p) => new StrPtrUni { ptr = p };

		/// <summary>Determines whether the specified <see cref="System.Object"/>, is equal to this instance.</summary>
		/// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
		/// <returns><c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
		public override bool Equals(object obj)
		{
			switch (obj)
			{
				case string s:
					return s.Equals(StringHelper.GetString(ptr, CharSet.Unicode));
				case IntPtr p:
					return ptr.Equals(p);
				default:
					return base.Equals(obj);
			}
		}

		/// <summary>Returns a hash code for this instance.</summary>
		/// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
		public override int GetHashCode() => ptr.GetHashCode();

		/// <summary>Returns a <see cref="System.String"/> that represents this instance.</summary>
		/// <returns>A <see cref="System.String"/> that represents this instance.</returns>
		public override string ToString() => StringHelper.GetString(ptr, CharSet.Unicode) ?? "null";
	}

	/// <summary>The StrPtr structure represents a LPWSTR.</summary>
	[StructLayout(LayoutKind.Sequential), DebuggerDisplay("{ptr}, {ToString()}")]
	public struct StrPtrAnsi
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

		/// <summary>Frees the unmanaged string memory.</summary>
		public void Free() { StringHelper.FreeString(ptr, CharSet.Ansi); ptr = IntPtr.Zero; }

		/// <summary>Performs an implicit conversion from <see cref="StrPtrAnsi"/> to <see cref="System.String"/>.</summary>
		/// <param name="p">The <see cref="StrPtrAnsi"/> instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator string(StrPtrAnsi p) => p.IsNull ? null : p.ToString();

		/// <summary>Performs an explicit conversion from <see cref="StrPtrAnsi"/> to <see cref="System.IntPtr"/>.</summary>
		/// <param name="p">The <see cref="StrPtrAnsi"/> instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(StrPtrAnsi p) => p.ptr;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="StrPtrAnsi"/>.</summary>
		/// <param name="p">The pointer.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator StrPtrAnsi(IntPtr p) => new StrPtrAnsi { ptr = p };

		/// <summary>Determines whether the specified <see cref="System.Object"/>, is equal to this instance.</summary>
		/// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
		/// <returns><c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
		public override bool Equals(object obj)
		{
			switch (obj)
			{
				case string s:
					return s.Equals(StringHelper.GetString(ptr, CharSet.Ansi));
				case IntPtr p:
					return ptr.Equals(p);
				default:
					return base.Equals(obj);
			}
		}

		/// <summary>Returns a hash code for this instance.</summary>
		/// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
		public override int GetHashCode() => ptr.GetHashCode();

		/// <summary>Returns a <see cref="System.String"/> that represents this instance.</summary>
		/// <returns>A <see cref="System.String"/> that represents this instance.</returns>
		public override string ToString() => StringHelper.GetString(ptr, CharSet.Ansi) ?? "null";
	}

	/// <summary>The GuidPtr structure represents a LPGUID.</summary>
	[StructLayout(LayoutKind.Sequential), DebuggerDisplay("{ptr}, {ToString()}")]
	public struct GuidPtr
	{
		private IntPtr ptr;

		/// <summary>Initializes a new instance of the <see cref="GuidPtr"/> struct by allocating memory with <see cref="Marshal.AllocCoTaskMem(int)"/>.</summary>
		/// <param name="g">The guid value.</param>
		public GuidPtr(Guid g) => ptr = g.StructureToPtr(Marshal.AllocCoTaskMem, out _);

		/// <summary>Gets a value indicating whether this instance is equivalent to null pointer or void*.</summary>
		/// <value><c>true</c> if this instance is null; otherwise, <c>false</c>.</value>
		public bool IsNull => ptr == IntPtr.Zero;

		/// <summary>Gets the value of the Guid.</summary>
		/// <value>The value pointed to by this pointer.</value>
		public Guid? Value => IsNull ? (Guid?)null : ptr.ToStructure<Guid>();

		/// <summary>Assigns a new Guid value to the pointer.</summary>
		/// <param name="g">The guid value.</param>
		public void Assign(Guid g)
		{
			if (IsNull)
				ptr = g.StructureToPtr(Marshal.AllocCoTaskMem, out _);
			else
				Marshal.StructureToPtr(g, ptr, true);
		}

		/// <summary>Frees the unmanaged memory.</summary>
		public void Free() { Marshal.FreeCoTaskMem(ptr); ptr = IntPtr.Zero; }

		/// <summary>
		/// Performs an implicit conversion from <see cref="GuidPtr"/> to <see cref="System.Nullable{Guid}"/>.
		/// </summary>
		/// <param name="g">The pointer to a Guid.</param>
		/// <returns>
		/// The result of the conversion.
		/// </returns>
		public static implicit operator Guid?(GuidPtr g) => g.Value;

		/// <summary>
		/// Performs an explicit conversion from <see cref="GuidPtr"/> to <see cref="IntPtr"/>.
		/// </summary>
		/// <param name="g">The pointer to a Guid.</param>
		/// <returns>
		/// The result of the conversion.
		/// </returns>
		public static explicit operator IntPtr(GuidPtr g) => g.ptr;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="GuidPtr"/>.</summary>
		/// <param name="p">The pointer.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator GuidPtr(IntPtr p) => new GuidPtr { ptr = p };

		/// <summary>Determines whether the specified <see cref="System.Object"/>, is equal to this instance.</summary>
		/// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
		/// <returns><c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
		public override bool Equals(object obj)
		{
			switch (obj)
			{
				case Guid g:
					return IsNull ? false : g.Equals(Value.Value);
				case IntPtr p:
					return ptr.Equals(p);
				default:
					return base.Equals(obj);
			}
		}

		/// <summary>Returns a hash code for this instance.</summary>
		/// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
		public override int GetHashCode() => ptr.GetHashCode();

		/// <inheritdoc/>
		public override string ToString() => Value?.ToString("B") ?? "";
	}
}