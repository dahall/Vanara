using Microsoft.Win32.SafeHandles;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Security;
using Vanara.Extensions;

namespace Vanara.InteropServices
{
	/// <summary>Safely handles an unmanaged memory allocated Unicode string.</summary>
	/// <seealso cref="Microsoft.Win32.SafeHandles.SafeHandleZeroOrMinusOneIsInvalid"/>
	public class SafeCoTaskMemString : SafeHandleZeroOrMinusOneIsInvalid
	{
		private readonly CharSet chSet = CharSet.Unicode;

		/// <summary>Initializes a new instance of the <see cref="SafeCoTaskMemString"/> class.</summary>
		/// <param name="s">The string value.</param>
		/// <param name="charSet">The character set.</param>
		/// <param name="ownsHandle"><c>true</c> to reliably release the handle during finalization; <c>false</c> to prevent it.</param>
		public SafeCoTaskMemString(string s, CharSet charSet = CharSet.Unicode, bool ownsHandle = true) : this(StringHelper.AllocString(s, charSet), charSet, ownsHandle)
		{
			Capacity = StringHelper.GetByteCount(s, true, charSet);
		}

		/// <summary>Initializes a new instance of the <see cref="SafeCoTaskMemString"/> class.</summary>
		/// <param name="s">The string value.</param>
		/// <param name="charSet">The character set.</param>
		public SafeCoTaskMemString(SecureString s, CharSet charSet = CharSet.Unicode) : this(StringHelper.AllocSecureString(s, charSet), charSet)
		{
			Capacity = s == null ? 0 : StringHelper.GetCharSize(charSet) * (s.Length + 1);
		}

		/// <summary>Initializes a new instance of the <see cref="SafeCoTaskMemString"/> class.</summary>
		/// <param name="charLen">The size of the buffer in characters, including the null character terminator.</param>
		/// <param name="charSet">The character set.</param>
		public SafeCoTaskMemString(int charLen, CharSet charSet = CharSet.Unicode) : this(StringHelper.AllocChars((uint)charLen, charSet), charSet)
		{
			Capacity = charLen * StringHelper.GetCharSize(charSet);
		}

		/// <summary>Prevents a default instance of the <see cref="SafeCoTaskMemString"/> class from being created.</summary>
		[ExcludeFromCodeCoverage]
		private SafeCoTaskMemString() : base(true) { }

		/// <summary>Initializes a new instance of the <see cref="SafeCoTaskMemString"/> class.</summary>
		/// <param name="ptr">The PTR.</param>
		/// <param name="charSet">The character set.</param>
		/// <param name="ownsHandle"><c>true</c> to reliably release the handle during finalization; <c>false</c> to prevent it.</param>
		[ExcludeFromCodeCoverage]
		private SafeCoTaskMemString(IntPtr ptr, CharSet charSet = CharSet.Unicode, bool ownsHandle = true) : base(ownsHandle)
		{
			chSet = charSet;
			SetHandle(ptr);
		}

		/// <summary>Represents a <c>null</c> value. Used primarily for comparrison.</summary>
		/// <value>A null value.</value>
		public static SafeCoTaskMemString Null => new SafeCoTaskMemString(IntPtr.Zero, CharSet.Unicode, false);

		/// <summary>Gets the number of allocated bytes or -1 if the size is unknown (for example if it is holding a <see cref="SecureString"/>.</summary>
		/// <value>The number of allocated bytes.</value>
		public int Capacity { get; } = -1;

		/// <summary>Gets the number of allocated characters or -1 if the size is unknown (for example if it is holding a <see cref="SecureString"/>.</summary>
		/// <value>The number of characters bytes.</value>
		public int CharCapacity => Capacity == -1 ? -1 : Capacity / StringHelper.GetCharSize(chSet);

		/// <summary>Returns the value of the <see cref="SafeHandle.handle"/> field.</summary>
		/// <param name="s">The <see cref="SafeCoTaskMemString"/> instance.</param>
		/// <returns>
		/// An <see cref="IntPtr"/> representing the value of the handle field. If the handle has been marked invalid with
		/// <see cref="SafeHandle.SetHandleAsInvalid"/>, this method still returns the original handle value, which can be a stale value.
		/// </returns>
		public static explicit operator IntPtr(SafeCoTaskMemString s) => s.DangerousGetHandle();

		/// <summary>Returns the string value held by a <see cref="SafeCoTaskMemString"/>.</summary>
		/// <param name="s">The <see cref="SafeCoTaskMemString"/> instance.</param>
		/// <returns>A <see cref="System.String"/> value held by the <see cref="SafeCoTaskMemString"/> or <c>null</c> if the handle or value is invalid.</returns>
		public static implicit operator string(SafeCoTaskMemString s) => s?.ToString();

		/// <summary>Returns the string value held by this instance.</summary>
		/// <returns>A <see cref="System.String"/> value held by this instance or <c>null</c> if the handle is invalid.</returns>
		public override string ToString() => IsInvalid ? null : StringHelper.GetString(handle, chSet);

		/// <summary>When overridden in a derived class, executes the code required to free the handle.</summary>
		/// <returns>
		/// true if the handle is released successfully; otherwise, in the event of a catastrophic failure, false. In this case, it generates a
		/// releaseHandleFailed MDA Managed Debugging Assistant.
		/// </returns>
		protected override bool ReleaseHandle()
		{
			StringHelper.FreeString(handle, chSet);
			return true;
		}
	}
}