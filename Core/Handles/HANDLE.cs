using System.ComponentModel;
using System.Diagnostics;

namespace Vanara.PInvoke;

/// <summary>Provides a generic Windows handle.</summary>
/// <remarks>Initializes a new instance of the <see cref="HANDLE"/> struct.</remarks>
/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
[StructLayout(LayoutKind.Sequential), DebuggerDisplay("{handle}"), TypeConverter(typeof(HANDLEConverter))]
public readonly partial struct HANDLE(IntPtr preexistingHandle) : IHandle
{
	private readonly IntPtr handle = preexistingHandle;

	/// <summary>Represents an invalid handle.</summary>
	public static readonly IntPtr INVALID_HANDLE_VALUE = new(-1);

	/// <summary>Returns an invalid handle by instantiating a <see cref="HANDLE"/> object with <see cref="IntPtr.Zero"/>.</summary>
	public static readonly HANDLE NULL = new(IntPtr.Zero);

	/// <summary>Gets a value indicating whether the handle is invalid.</summary>
	/// <value><see langword="true"/> if the handle is invalid; otherwise, <see langword="false"/>.</value>
	public readonly bool IsInvalid => handle == IntPtr.Zero || handle == new IntPtr(-1);

	/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
	public readonly bool IsNull => handle == IntPtr.Zero;

	/// <summary>Performs an explicit conversion from <see cref="HANDLE"/> to <see cref="IntPtr"/>.</summary>
	/// <param name="h">The handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator IntPtr(HANDLE h) => h.handle;

	/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HANDLE"/>.</summary>
	/// <param name="h">The pointer to a handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator HANDLE(IntPtr h) => new(h);

	/// <summary>Performs an implicit conversion from <see cref="HANDLE"/> to <see cref="SafeHandle"/>.</summary>
	/// <param name="h">The pointer to a handle.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator HANDLE(SafeHandle h) => new(h.DangerousGetHandle());

	/// <summary>Implements the operator !=.</summary>
	/// <param name="h1">The first handle.</param>
	/// <param name="h2">The second handle.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator !=(HANDLE h1, HANDLE h2) => !(h1 == h2);

	/// <summary>Implements the operator ==.</summary>
	/// <param name="h1">The first handle.</param>
	/// <param name="h2">The second handle.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator ==(HANDLE h1, HANDLE h2) => h1.Equals(h2);

	/// <summary>Implements the operator !.</summary>
	/// <param name="h1">The handle.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator !(HANDLE h1) => h1.IsNull;

#if !NETSTANDARD
	/// <summary>Implements the operator <see langword="true"/>.</summary>
	/// <param name="h">The value.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator true(HANDLE h) => !h.IsInvalid;

	/// <summary>Implements the operator <see langword="false"/>.</summary>
	/// <param name="h">The value.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator false(HANDLE h) => h.IsInvalid;
#endif

	/// <inheritdoc/>
	public readonly IntPtr DangerousGetHandle() => handle;

	/// <inheritdoc/>
	public readonly override bool Equals(object? obj) => obj switch
	{
		IntPtr p => handle == p,
		IHandle i => handle == i.DangerousGetHandle(),
		SafeHandle h => handle == h.DangerousGetHandle(),
		_ => false
	};

	/// <inheritdoc/>
	public readonly override int GetHashCode() => handle.GetHashCode();
}