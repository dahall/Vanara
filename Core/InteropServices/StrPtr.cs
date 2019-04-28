using System;
using System.Runtime.InteropServices;
using Vanara.Extensions;

namespace Vanara.InteropServices
{
	/// <summary>The StrPtr structure represents a LPTSTR.</summary>
	[StructLayout(LayoutKind.Sequential)]
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
		public static implicit operator string(StrPtrAuto p) => p.ToString();

		/// <summary>Performs an explicit conversion from <see cref="StrPtrAuto"/> to <see cref="System.IntPtr"/>.</summary>
		/// <param name="p">The <see cref="StrPtrAuto"/> instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(StrPtrAuto p) => p.ptr;

		/// <summary>Returns a <see cref="System.String"/> that represents this instance.</summary>
		/// <returns>A <see cref="System.String"/> that represents this instance.</returns>
		public override string ToString() => StringHelper.GetString(ptr) ?? "null";
	}

	/// <summary>The StrPtr structure represents a LPWSTR.</summary>
	[StructLayout(LayoutKind.Sequential)]
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
		public static implicit operator string(StrPtrUni p) => p.ToString();

		/// <summary>Performs an explicit conversion from <see cref="StrPtrUni"/> to <see cref="System.IntPtr"/>.</summary>
		/// <param name="p">The <see cref="StrPtrUni"/> instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(StrPtrUni p) => p.ptr;

		/// <summary>Returns a <see cref="System.String"/> that represents this instance.</summary>
		/// <returns>A <see cref="System.String"/> that represents this instance.</returns>
		public override string ToString() => StringHelper.GetString(ptr, CharSet.Unicode) ?? "null";
	}

	/// <summary>The StrPtr structure represents a LPWSTR.</summary>
	[StructLayout(LayoutKind.Sequential)]
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
		public static implicit operator string(StrPtrAnsi p) => p.ToString();

		/// <summary>Performs an explicit conversion from <see cref="StrPtrAnsi"/> to <see cref="System.IntPtr"/>.</summary>
		/// <param name="p">The <see cref="StrPtrAnsi"/> instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(StrPtrAnsi p) => p.ptr;

		/// <summary>Returns a <see cref="System.String"/> that represents this instance.</summary>
		/// <returns>A <see cref="System.String"/> that represents this instance.</returns>
		public override string ToString() => StringHelper.GetString(ptr, CharSet.Ansi) ?? "null";
	}
}