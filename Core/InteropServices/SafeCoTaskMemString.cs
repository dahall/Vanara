using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using System.Security;

namespace Vanara.InteropServices;

/// <summary>Safely handles an unmanaged memory allocated Unicode string.</summary>
public class SafeCoTaskMemString : SafeMemString<CoTaskMemoryMethods>
{
	/// <summary>Initializes a new instance of the <see cref="SafeCoTaskMemString"/> class.</summary>
	/// <param name="s">The string value.</param>
	/// <param name="charSet">The character set.</param>
	public SafeCoTaskMemString(string? s, CharSet charSet = CharSet.Unicode) : base(s, charSet) { }

	/// <summary>Initializes a new instance of the <see cref="SafeCoTaskMemString"/> class.</summary>
	/// <param name="s">The string value.</param>
	/// <param name="capacity">The size of the buffer in characters.</param>
	/// <param name="charSet">The character set.</param>
	public SafeCoTaskMemString(string? s, int capacity, CharSet charSet = CharSet.Unicode) : base(s, capacity, charSet) { }

	/// <summary>Initializes a new instance of the <see cref="SafeCoTaskMemString"/> class.</summary>
	/// <param name="s">The string value.</param>
	/// <param name="charSet">The character set.</param>
	public SafeCoTaskMemString(SecureString s, CharSet charSet = CharSet.Unicode) : base(s, charSet) { }

	/// <summary>Initializes a new instance of the <see cref="SafeCoTaskMemString"/> class.</summary>
	/// <param name="capacity">The size of the buffer in characters, including the null character terminator.</param>
	/// <param name="charSet">The character set.</param>
	public SafeCoTaskMemString(int capacity, CharSet charSet = CharSet.Unicode) : base(capacity, charSet) { }

	/// <summary>Prevents a default instance of the <see cref="SafeCoTaskMemString"/> class from being created.</summary>
	private SafeCoTaskMemString() : base() { }

	/// <summary>Initializes a new instance of the <see cref="SafeCoTaskMemString"/> class.</summary>
	/// <param name="ptr">The PTR.</param>
	/// <param name="charSet">The character set.</param>
	/// <param name="ownsHandle"><c>true</c> to reliably release the handle during finalization; <c>false</c> to prevent it.</param>
	/// <param name="allocatedBytes">The number of bytes allocated to <paramref name="ptr"/>.</param>
	[ExcludeFromCodeCoverage]
	private SafeCoTaskMemString(IntPtr ptr, CharSet charSet = CharSet.Unicode, bool ownsHandle = true, PInvoke.SizeT allocatedBytes = default) :
		base(ptr, charSet, ownsHandle, allocatedBytes) { }

	/// <summary>Represents a <c>null</c> value. Used primarily for comparison.</summary>
	/// <value>A null value.</value>
	public static SafeCoTaskMemString Null => new(IntPtr.Zero, CharSet.Unicode, false);
}