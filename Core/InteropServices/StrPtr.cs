using System.Collections.Generic;
using System.Diagnostics;

namespace Vanara.InteropServices;

/// <summary>The GuidPtr structure represents a LPGUID.</summary>
/// <remarks>Initializes a new instance of the <see cref="GuidPtr"/> struct by allocating memory with <see cref="Marshal.AllocCoTaskMem(int)"/>.</remarks>
/// <param name="g">The guid value.</param>
[StructLayout(LayoutKind.Sequential), DebuggerDisplay("{ptr}, {ToString()}")]
public struct GuidPtr(Guid g) : IEquatable<GuidPtr>, IEquatable<Guid?>, IEquatable<IntPtr>
{
	private IntPtr ptr = g.MarshalToPtr(Marshal.AllocCoTaskMem, out _);

	/// <summary>Gets a value indicating whether this instance is equivalent to null pointer or void*.</summary>
	/// <value><c>true</c> if this instance is null; otherwise, <c>false</c>.</value>
	public readonly bool IsNull => ptr == IntPtr.Zero;

	/// <summary>Gets the value of the Guid.</summary>
	/// <value>The value pointed to by this pointer.</value>
	public readonly Guid? Value => IsNull ? null : ptr.ToStructure<Guid>();

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
	public readonly bool Equals(Guid? other) => EqualityComparer<Guid?>.Default.Equals(Value, other);

	/// <summary>Determines whether the specified <see cref="GuidPtr"/>, is equal to this instance.</summary>
	/// <param name="other">The <see cref="GuidPtr"/> to compare with this instance.</param>
	/// <returns><c>true</c> if the specified <see cref="GuidPtr"/> is equal to this instance; otherwise, <c>false</c>.</returns>
	public readonly bool Equals(GuidPtr other) => Equals(other.ptr);

	/// <summary>Determines whether the specified <see cref="IntPtr"/>, is equal to this instance.</summary>
	/// <param name="other">The <see cref="IntPtr"/> to compare with this instance.</param>
	/// <returns><c>true</c> if the specified <see cref="IntPtr"/> is equal to this instance; otherwise, <c>false</c>.</returns>
	public readonly bool Equals(IntPtr other) => EqualityComparer<IntPtr>.Default.Equals(ptr, other);

	/// <inheritdoc/>
	public override readonly bool Equals(object? obj) => obj switch
	{
		null => IsNull,
		IntPtr p => Equals(p),
		GuidPtr gp => Equals(gp),
		Guid g => Equals(g),
		_ => base.Equals(obj),
	};

	/// <summary>Frees the unmanaged memory.</summary>
	public void Free()
	{ Marshal.FreeCoTaskMem(ptr); ptr = IntPtr.Zero; }

	/// <inheritdoc/>
	public override readonly int GetHashCode() => ptr.GetHashCode();

	/// <inheritdoc/>
	public override readonly string ToString() => Value?.ToString("B") ?? "";

	/// <summary>Performs an implicit conversion from <see cref="GuidPtr"/> to <see cref="Nullable{Guid}"/>.</summary>
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

	/// <summary>Converts a SafeGuidPtr instance to a pointer to a Guid structure.</summary>
	/// <remarks>
	/// This operator exposes the underlying pointer managed by the SafeGuidPtr. Use with caution, as improper use of the returned pointer
	/// can lead to memory corruption or access violations. The caller is responsible for ensuring that the SafeGuidPtr remains valid for the
	/// lifetime of the pointer.
	/// </remarks>
	/// <param name="sgp">The SafeGuidPtr instance to convert. Must not be null or disposed.</param>
	public static unsafe implicit operator Guid*(SafeGuidPtr sgp) => (Guid*)(void*)sgp.DangerousGetHandle();

	/// <summary>Performs an implicit conversion from <see cref="Nullable{Guid}"/> to <see cref="SafeGuidPtr"/>.</summary>
	/// <param name="guid">The unique identifier.</param>
	/// <returns>The resulting <see cref="SafeGuidPtr"/> instance from the conversion.</returns>
	public static implicit operator SafeGuidPtr(Guid? guid) => guid.HasValue ? new SafeGuidPtr(guid.Value) : Null;
}