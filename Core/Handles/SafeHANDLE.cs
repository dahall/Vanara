using Microsoft.Win32.SafeHandles;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Vanara.PInvoke;

/// <summary>Delegate for a method that closes a handle and reports success. Used by SafeHandleBase.</summary>
/// <param name="handle">The handle.</param>
/// <returns><see langword="true"/> if handle was closed or if handle is already closed; otherwise <see langword="false"/>.</returns>
public delegate bool CloseHandleFunc(IntPtr handle);

/// <summary>Base class for all native handles.</summary>
/// <seealso cref="SafeHandleZeroOrMinusOneIsInvalid"/>
/// <seealso cref="IEquatable{T}"/>
/// <seealso cref="IHandle"/>
[DebuggerDisplay("{handle}")]
public abstract class SafeHANDLE : SafeHandleZeroOrMinusOneIsInvalid, IEquatable<SafeHANDLE>, IHandle
{
	/// <summary>Initializes a new instance of the <see cref="SafeHANDLE"/> class.</summary>
	public SafeHANDLE() : base(true)
	{
	}

	/// <summary>Initializes a new instance of the <see cref="SafeHANDLE"/> class and assigns an existing handle.</summary>
	/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
	/// <param name="ownsHandle">
	/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
	/// </param>
	protected SafeHANDLE(IntPtr preexistingHandle, bool ownsHandle = true) : base(ownsHandle) => SetHandle(preexistingHandle);

	/// <summary>Gets a value indicating whether this instance is null.</summary>
	/// <value><c>true</c> if this instance is null; otherwise, <c>false</c>.</value>
	public bool IsNull => handle == IntPtr.Zero;

	/// <summary>Implements the operator ! which returns <see langword="true"/> if the handle is invalid.</summary>
	/// <param name="hMem">The <see cref="SafeHANDLE"/> instance.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator !(SafeHANDLE hMem) => hMem.IsInvalid;

#if !NETSTANDARD
	/// <summary>Implements the operator <see langword="true"/>.</summary>
	/// <param name="hMem">The value.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator true(SafeHANDLE hMem) => !hMem.IsInvalid;

	/// <summary>Implements the operator <see langword="false"/>.</summary>
	/// <param name="hMem">The value.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator false(SafeHANDLE hMem) => hMem.IsInvalid;
#endif

	/// <summary>Implements the operator !=.</summary>
	/// <param name="h1">The first handle.</param>
	/// <param name="h2">The second handle.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator !=(SafeHANDLE? h1, IHandle? h2) => !(h1 == h2);

	/// <summary>Implements the operator !=.</summary>
	/// <param name="h1">The first handle.</param>
	/// <param name="h2">The second handle.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator !=(SafeHANDLE h1, IntPtr h2) => !(h1 == h2);

	/// <summary>Implements the operator ==.</summary>
	/// <param name="h1">The first handle.</param>
	/// <param name="h2">The second handle.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator ==(SafeHANDLE? h1, IHandle? h2) => h1?.Equals(h2) ?? h2 is null;

	/// <summary>Implements the operator ==.</summary>
	/// <param name="h1">The first handle.</param>
	/// <param name="h2">The second handle.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator ==(SafeHANDLE h1, IntPtr h2) => h1?.Equals(h2) ?? false;

	/// <summary>Determines whether the specified <see cref="SafeHANDLE"/>, is equal to this instance.</summary>
	/// <param name="other">The <see cref="SafeHANDLE"/> to compare with this instance.</param>
	/// <returns><c>true</c> if the specified <see cref="SafeHANDLE"/> is equal to this instance; otherwise, <c>false</c>.</returns>
	public bool Equals(SafeHANDLE? other) => ReferenceEquals(this, other) || other is not null && handle == other.handle && IsClosed == other.IsClosed;

	/// <summary>Determines whether the specified <see cref="object"/>, is equal to this instance.</summary>
	/// <param name="obj">The <see cref="object"/> to compare with this instance.</param>
	/// <returns><c>true</c> if the specified <see cref="object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
	public override bool Equals(object? obj) => obj switch
	{
		IHandle ih => handle.Equals(ih.DangerousGetHandle()),
		SafeHandle sh => handle.Equals(sh.DangerousGetHandle()),
		IntPtr p => handle.Equals(p),
		_ => base.Equals(obj),
	};

	/// <summary>Returns a hash code for this instance.</summary>
	/// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
	public override int GetHashCode() => base.GetHashCode();

	/// <summary>Releases the ownership of the underlying handle and returns the current handle.</summary>
	/// <returns>The value of the current handle.</returns>
	public IntPtr ReleaseOwnership()
	{
		var ret = handle;
		SetHandleAsInvalid();
		return ret;
	}

	/// <summary>
	/// Internal method that actually releases the handle. This is called by <see cref="ReleaseHandle"/> for valid handles and afterwards
	/// zeros the handle.
	/// </summary>
	/// <returns><c>true</c> to indicate successful release of the handle; <c>false</c> otherwise.</returns>
	protected abstract bool InternalReleaseHandle();

	/// <inheritdoc/>
	[MethodImpl(MethodImplOptions.NoOptimization | MethodImplOptions.NoInlining)]
	protected override bool ReleaseHandle()
	{
		if (IsInvalid) return true;
		if (!InternalReleaseHandle()) return false;
		handle = IntPtr.Zero;
		return true;
	}

	/// <summary>Throws an <see cref="ObjectDisposedException"/> if disposed.</summary>
	/// <typeparam name="T">A <see cref="SafeHANDLE"/> instance.</typeparam>
	/// <param name="h">The handle.</param>
	/// <returns>The handle if not disposed.</returns>
	/// <exception cref="ObjectDisposedException">Thrown if handle is disposed.</exception>
	protected static T ThrowIfDisposed<T>(T h) where T : SafeHANDLE => h is null || h.IsInvalid ? throw new ObjectDisposedException(typeof(T).Name) : h;
}