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
	public abstract class SafeMemString<TMem> : SafeMemoryHandle<TMem> where TMem : IMemoryMethods, new()
	{
		private readonly CharSet chSet = CharSet.Unicode;

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
			chSet = charSet;
		}

		/// <summary>Prevents a default instance of the <see cref="SafeMemString{TMem}"/> class from being created.</summary>
		[ExcludeFromCodeCoverage]
		protected SafeMemString() : base(0) { }

		/// <summary>Initializes a new instance of the <see cref="SafeMemString{TMem}"/> class.</summary>
		/// <param name="ptr">The PTR.</param>
		/// <param name="charSet">The character set.</param>
		/// <param name="ownsHandle"><c>true</c> to reliably release the handle during finalization; <c>false</c> to prevent it.</param>
		[ExcludeFromCodeCoverage]
		protected SafeMemString(IntPtr ptr, CharSet charSet = CharSet.Unicode, bool ownsHandle = true) : base(ptr, 0, ownsHandle)
		{
			chSet = charSet;
		}

		/// <summary>Gets the number of allocated characters or 0 if the size is unknown (for example if it is holding a <see cref="SecureString"/>.</summary>
		/// <value>The number of allocated characters.</value>
		public int Capacity => Size / StringHelper.GetCharSize(chSet);

		/// <summary>Gets the number of characters in the current <see cref="SafeMemString{TMem}"/> object.</summary>
		public int Length => ToString().Length;

		/// <summary>Returns the value of the <see cref="SafeHandle.handle"/> field.</summary>
		/// <param name="s">The <see cref="SafeMemString{TMem}"/> instance.</param>
		/// <returns>
		/// An <see cref="IntPtr"/> representing the value of the handle field. If the handle has been marked invalid with
		/// <see cref="SafeHandle.SetHandleAsInvalid"/>, this method still returns the original handle value, which can be a stale value.
		/// </returns>
		public static explicit operator IntPtr(SafeMemString<TMem> s) => s.DangerousGetHandle();

		/// <summary>Returns the string value held by a <see cref="SafeMemString{TMem}"/>.</summary>
		/// <param name="s">The <see cref="SafeMemString{TMem}"/> instance.</param>
		/// <returns>
		/// A <see cref="System.String"/> value held by the <see cref="SafeMemString{TMem}"/> or <c>null</c> if the handle or value is invalid.
		/// </returns>
		public static implicit operator string(SafeMemString<TMem> s) => s?.ToString();

		/// <summary>Returns the string value held by this instance.</summary>
		/// <returns>A <see cref="System.String"/> value held by this instance or <c>null</c> if the handle is invalid.</returns>
		public override string ToString() => IsInvalid ? null : StringHelper.GetString(handle, chSet, Size);
	}
}