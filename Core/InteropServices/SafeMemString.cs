using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Security;
using Vanara.Extensions;

namespace Vanara.InteropServices
{
	/// <summary>Base abstract class for a string handler based on <see cref="SafeMemoryHandle{TMem}"/>.</summary>
	/// <typeparam name="TMem">The type of the memory.</typeparam>
	/// <seealso cref="Vanara.InteropServices.SafeMemoryHandle{TMem}"/>
	public abstract class SafeMemString<TMem> : SafeMemoryHandle<TMem>, IEquatable<SafeMemString<TMem>>, IEquatable<string>, IComparable<SafeMemString<TMem>>, IComparable<string> where TMem : IMemoryMethods, new()
	{
		/// <summary>Initializes a new instance of the <see cref="SafeMemString{TMem}"/> class.</summary>
		/// <param name="s">The string value.</param>
		/// <param name="charSet">The character set.</param>
		protected SafeMemString(string s, CharSet charSet = CharSet.Unicode) : this(s, s is null ? 0 : s.Length + 1, charSet)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="SafeMemString{TMem}"/> class.</summary>
		/// <param name="s">The string value.</param>
		/// <param name="capacity">The capacity of the buffer, in characters.</param>
		/// <param name="charSet">The character set.</param>
		protected SafeMemString(string s, int capacity, CharSet charSet = CharSet.Unicode) : this(capacity, charSet)
		{
			StringHelper.Write(s, handle, out _, true, charSet, Size);
		}

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
		protected SafeMemString(int charLen, CharSet charSet = CharSet.Unicode) : base(charLen * StringHelper.GetCharSize(charSet))
		{
			CharSet = charSet;
		}

		/// <summary>Prevents a default instance of the <see cref="SafeMemString{TMem}"/> class from being created.</summary>
		[ExcludeFromCodeCoverage]
		protected SafeMemString() : base(0) { }

		/// <summary>Initializes a new instance of the <see cref="SafeMemString{TMem}"/> class.</summary>
		/// <param name="ptr">The PTR.</param>
		/// <param name="charSet">The character set.</param>
		/// <param name="ownsHandle"><c>true</c> to reliably release the handle during finalization; <c>false</c> to prevent it.</param>
		/// <param name="allocatedBytes">The number of bytes allocated to <paramref name="ptr"/>.</param>
		[ExcludeFromCodeCoverage]
		protected SafeMemString(IntPtr ptr, CharSet charSet = CharSet.Unicode, bool ownsHandle = true, PInvoke.SizeT allocatedBytes = default) : base(ptr, allocatedBytes, ownsHandle)
		{
			CharSet = charSet;
		}

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

		/// <summary>Gets the number of characters in the current <see cref="SafeMemString{TMem}"/> object.</summary>
		public int Length => ToString().Length;

		/// <summary>Performs an explicit conversion from <see cref="SafeMemString{TMem}"/> to <see cref="System.Char"/>.</summary>
		/// <param name="s">The <see cref="SafeMemString{TMem}"/> instance.</param>
		/// <returns>The result of the conversion.</returns>
		/// <exception cref="InvalidCastException">Cannot convert an ANSI string to a Char pointer.</exception>
		public static unsafe explicit operator char*(SafeMemString<TMem> s) => s.CharSet == CharSet.Unicode ? (char*)(void*)s.handle : throw new InvalidCastException("Cannot convert an ANSI string to a Char pointer.");

		/// <summary>Returns the value of the <see cref="SafeHandle.handle"/> field.</summary>
		/// <param name="s">The <see cref="SafeMemString{TMem}"/> instance.</param>
		/// <returns>
		/// An <see cref="IntPtr"/> representing the value of the handle field. If the handle has been marked invalid with
		/// <see cref="SafeHandle.SetHandleAsInvalid"/>, this method still returns the original handle value, which can be a stale value.
		/// </returns>
		public static implicit operator IntPtr(SafeMemString<TMem> s) => s.DangerousGetHandle();

		/// <summary>Returns the string value held by a <see cref="SafeMemString{TMem}"/>.</summary>
		/// <param name="s">The <see cref="SafeMemString{TMem}"/> instance.</param>
		/// <returns>
		/// A <see cref="System.String"/> value held by the <see cref="SafeMemString{TMem}"/> or <c>null</c> if the handle or value is invalid.
		/// </returns>
		public static implicit operator string(SafeMemString<TMem> s) => s?.ToString();

		/// <summary>Implements the operator !=.</summary>
		/// <param name="s1">The left value.</param>
		/// <param name="s2">The right value.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(SafeMemString<TMem> s1, SafeMemString<TMem> s2) => !s1.Equals(s2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="s1">The left value.</param>
		/// <param name="s2">The right value.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(SafeMemString<TMem> s1, SafeMemString<TMem> s2) => s1.Equals(s2);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="s1">The left value.</param>
		/// <param name="s2">The right value.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(SafeMemString<TMem> s1, string s2) => !s1.Equals(s2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="s1">The left value.</param>
		/// <param name="s2">The right value.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(SafeMemString<TMem> s1, string s2) => s1.Equals(s2);

		/// <summary>Compares the current object with another object of the same type.</summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>
		/// A 32-bit signed integer that indicates the relative order of the objects being compared. The return value has the following
		/// meanings: Value Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is equal
		/// to <paramref name="other"/>. Greater than zero This object is greater than <paramref name="other"/>.
		/// </returns>
		public int CompareTo(SafeMemString<TMem> other) => string.Compare(this, other);

		/// <summary>Compares the current object with another object of the same type.</summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>
		/// A 32-bit signed integer that indicates the relative order of the objects being compared. The return value has the following
		/// meanings: Value Meaning Less than zero This object is less than the <paramref name="other"/> parameter.Zero This object is equal
		/// to <paramref name="other"/>. Greater than zero This object is greater than <paramref name="other"/>.
		/// </returns>
		public int CompareTo(string other) => string.Compare(this, other);

		/// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
		public bool Equals(SafeMemString<TMem> other) => string.Equals(this, other);

		/// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
		public bool Equals(string other) => string.Equals(this, other);

		/// <summary>Determines whether the specified <see cref="System.Object"/>, is equal to this instance.</summary>
		/// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
		/// <returns><c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
		public override bool Equals(object obj)
		{
			if (ReferenceEquals(this, obj))
				return true;
			switch (obj)
			{
				case null:
					return false;

				case SafeMemString<TMem> ms:
					return Equals(ms);

				case string s:
					return Equals(s);

				case SafeAllocatedMemoryHandle m:
					return m == handle;

				default:
					return false;
			}
		}

		/// <summary>Returns a hash code for this instance.</summary>
		/// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
		public override int GetHashCode() => ToString()?.GetHashCode() ?? 0;

		/// <summary>Assigns a new string to this memory.</summary>
		/// <param name="value">The string value. This value can be <see langword="null"/>, but its length cannot be greater than the current <see cref="Capacity"/>.</param>
		public virtual void Set(string value)
		{
			StringHelper.Write(value, handle, out _, true, CharSet, Size);
		}

		/// <summary>Returns the string value held by this instance.</summary>
		/// <returns>A <see cref="System.String"/> value held by this instance or <c>null</c> if the handle is invalid.</returns>
		public override string ToString() => IsInvalid ? null : StringHelper.GetString(handle, CharSet, Size == 0 ? long.MaxValue : (long)Size);
	}
}