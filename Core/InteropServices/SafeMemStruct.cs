using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Vanara.PInvoke;

#if ALLOWSPAN
using System.Buffers;
#endif

namespace Vanara.InteropServices;

/// <summary>Base abstract class for a structure handler based on <see cref="SafeMemoryHandle{TMem}"/>.</summary>
/// <typeparam name="TStruct">The type of the structure.</typeparam>
/// <typeparam name="TMem">The type of the memory.</typeparam>
/// <seealso cref="SafeMemoryHandle{TMem}"/>
public abstract class SafeMemStruct<TStruct, TMem> : SafeMemoryHandle<TMem>, IEquatable<TStruct> where TMem : IMemoryMethods, new() where TStruct : struct
{
	/// <summary>The structure size, in bytes, of TStruct.</summary>
	protected static readonly SizeT BaseStructSize = InteropExtensions.SizeOf<TStruct>();

	/// <summary>Initializes a new instance of the <see cref="SafeMemStruct{TStruct, TMem}"/> class.</summary>
	/// <param name="s">The TStruct value.</param>
	/// <param name="capacity">The capacity of the buffer, in bytes.</param>
	protected SafeMemStruct(in TStruct s, SizeT capacity = default) : base(Math.Max(BaseStructSize, (ulong)capacity)) => handle.Write(s);

	/// <summary>Initializes a new instance of the <see cref="SafeMemStruct{TStruct, TMem}"/> class.</summary>
	/// <param name="capacity">The capacity of the buffer, in bytes.</param>
	protected SafeMemStruct(SizeT capacity = default) : base(Math.Max(BaseStructSize, (ulong)capacity)) { }

	/// <summary>Initializes a new instance of the <see cref="SafeMemStruct{TStruct, TMem}"/> class.</summary>
	/// <param name="ptr">The PTR.</param>
	/// <param name="ownsHandle"><c>true</c> to reliably release the handle during finalization; <c>false</c> to prevent it.</param>
	/// <param name="allocatedBytes">The number of bytes allocated to <paramref name="ptr"/>.</param>
	[ExcludeFromCodeCoverage]
	protected SafeMemStruct(IntPtr ptr, bool ownsHandle = true, SizeT allocatedBytes = default) : base(ptr, allocatedBytes, ownsHandle) { }

	/// <summary>Gets a value indicating whether the current memory has a valid value of its underlying type.</summary>
	/// <value><see langword="true"/> if this instance has a value; otherwise, <see langword="false"/>.</value>
	public bool HasValue => !IsClosed && !IsInvalid;

	/// <summary>
	/// Gets or sets the value of the current <see cref="SafeMemStruct{TStruct, TMem}"/> object if it has been assigned a valid
	/// underlying value.
	/// </summary>
	/// <value>
	/// The value of the current <see cref="SafeMemStruct{TStruct, TMem}"/> object if the HasValue property is true. An exception is
	/// thrown if the HasValue property is false.
	/// </value>
	/// <exception cref="InvalidOperationException">The HasValue property is false.</exception>
	public TStruct Value
	{
		get => HasValue ? handle.ToStructure<TStruct>(Size) : throw new InvalidOperationException("The HasValue property is false.");
		set => _ = HasValue ? handle.Write(value, 0, Size) : throw new InvalidOperationException("The HasValue property is false.");
	}

	/// <summary>Returns the TStruct value held by a <see cref="SafeMemStruct{TStruct, TMem}"/>.</summary>
	/// <param name="s">The <see cref="SafeMemStruct{TStruct, TMem}"/> instance.</param>
	/// <returns>
	/// A nullable value held by the <see cref="SafeMemStruct{TStruct, TMem}"/> or <c>null</c> if the handle or value is invalid.
	/// </returns>
	public static explicit operator TStruct?(SafeMemStruct<TStruct, TMem> s) => s is null || !s.HasValue ? (TStruct?)null : s.Value;

	/// <summary>Performs an explicit conversion from <see cref="SafeMemStruct{TStruct, TMem}"/> to <see cref="char"/>.</summary>
	/// <param name="s">The <see cref="SafeMemStruct{TStruct, TMem}"/> instance.</param>
	/// <returns>The result of the conversion.</returns>
	/// <exception cref="InvalidCastException">Cannot convert an ANSI string to a Char pointer.</exception>
	public static unsafe explicit operator void*(SafeMemStruct<TStruct, TMem> s) => (void*)s.handle;

	/// <summary>Returns the value of the <see cref="SafeHandle.handle"/> field.</summary>
	/// <param name="s">The <see cref="SafeMemStruct{TStruct, TMem}"/> instance.</param>
	/// <returns>
	/// An <see cref="IntPtr"/> representing the value of the handle field. If the handle has been marked invalid with <see
	/// cref="SafeHandle.SetHandleAsInvalid"/>, this method still returns the original handle value, which can be a stale value.
	/// </returns>
	public static implicit operator IntPtr(SafeMemStruct<TStruct, TMem> s) => s.DangerousGetHandle();

	/// <summary>Returns the TStruct value held by a <see cref="SafeMemStruct{TStruct, TMem}"/>.</summary>
	/// <param name="s">The <see cref="SafeMemStruct{TStruct, TMem}"/> instance.</param>
	/// <returns>
	/// The structure value held by the <see cref="SafeMemStruct{TStruct, TMem}"/> or an <see cref="InvalidOperationException"/>
	/// exception if the handle or value is invalid.
	/// </returns>
	public static implicit operator TStruct(SafeMemStruct<TStruct, TMem> s) => s is not null ? s.Value : throw new ArgumentNullException(nameof(s));

	/// <summary>Appends the specified bytes to the end of the allocated memory for this structure, expanding the allocation to fit the byte array.</summary>
	/// <param name="bytes">The bytes.</param>
	/// <returns>A pointer to the copied bytes in memory.</returns>
	public virtual IntPtr Append(byte[] bytes)
	{
		var sz = Size;
		Size += bytes.Length;
		Marshal.Copy(bytes, 0, handle.Offset(sz), bytes.Length);
		return handle.Offset(sz);
	}

	/// <summary>Appends the specified memory to the end of the allocated memory for this structure, expanding the allocation to fit the added memory.</summary>
	/// <param name="mem">The memory to append.</param>
	/// <returns>A pointer to the copied memory.</returns>
	public virtual IntPtr Append(SafeAllocatedMemoryHandleBase mem)
	{
		var sz = Size;
		Size += mem.Size;
		((IntPtr)mem).CopyTo(handle.Offset(sz), mem.Size);
		return handle.Offset(sz);
	}

	/// <summary>Appends the specified object to the end of the allocated memory for this structure, expanding the allocation to fit the added object.</summary>
	/// <param name="value">The value to append.</param>
	/// <returns>A pointer to the copied memory.</returns>
	public virtual IntPtr Append(object value)
	{
		var sz = Size;
		var vSz = InteropExtensions.SizeOf(value);
		Size += vSz;
		handle.Write(value, sz, Size);
		return handle.Offset(sz);
	}

	/// <summary>Determines whether the specified <see cref="object"/>, is equal to this instance.</summary>
	/// <param name="obj">The <see cref="object"/> to compare with this instance.</param>
	/// <returns><c>true</c> if the specified <see cref="object"/> is equal to this instance; otherwise, <c>false</c>.</returns>
	public override bool Equals(object? obj) => ReferenceEquals(this, obj) ||
		obj switch
		{
			null => false,
			SafeMemStruct<TStruct, TMem> ms => Equals((TStruct?)this, (TStruct?)ms),
			TStruct s => Equals(s),
			SafeAllocatedMemoryHandle m => m.DangerousGetHandle() == handle,
			_ => false,
		};

	/// <summary>Indicates whether the current object is equal to another object of the same type.</summary>
	/// <param name="other">An object to compare with this object.</param>
	/// <returns>true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.</returns>
	public bool Equals(TStruct other) => HasValue && EqualityComparer<TStruct>.Default.Equals(handle.ToStructure<TStruct>(Size), other);

	/// <summary>Gets the memory address of a field within <typeparamref name="TStruct"/>.</summary>
	/// <param name="fieldName">Name of the field.</param>
	/// <returns>The pointer to the field in memory.</returns>
	public virtual IntPtr GetFieldAddress(string fieldName) => handle.Offset(FieldOffset(fieldName));

	/// <summary>Returns a hash code for this instance.</summary>
	/// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
	public override int GetHashCode() => handle.ToInt32();

	/// <summary>Retrieves a string from the current memory block at the specified offset, using the given character encoding.</summary>
	/// <param name="offsetFromStart">
	/// The offset, in bytes, from the start of the memory block at which to begin reading the string. Must not exceed the size of the memory block.
	/// </param>
	/// <param name="charSet">The character encoding to use when interpreting the string. The default is CharSet.Auto.</param>
	/// <returns>A string read from the specified offset, or null if the memory block has no value.</returns>
	/// <exception cref="ArgumentOutOfRangeException">Thrown if offsetFromStart is greater than the size of the memory block.</exception>
	public virtual string? GetStringAtOffset(long offsetFromStart, CharSet charSet = CharSet.Auto)
	{
		if (!HasValue)
			return null;
		if (offsetFromStart > Size)
			throw new ArgumentOutOfRangeException(nameof(offsetFromStart));
		return StringHelper.GetString(handle.Offset(offsetFromStart), charSet, Size - offsetFromStart);
	}

	/// <summary>Retrieves the value of the current <see cref="SafeMemStruct{TStruct, TMem}"/> object, or the specified default value.</summary>
	/// <param name="defaultValue">A value to return if the <see cref="HasValue"/> property is <see langword="false"/>.</param>
	/// <returns>
	/// The value of the <see cref="Value"/> property if the <see cref="HasValue"/> property is <see langword="true"/>; otherwise, the
	/// <paramref name="defaultValue"/> parameter.
	/// </returns>
	public virtual TStruct GetValueOrDefault(in TStruct defaultValue = default) => HasValue ? Value : defaultValue;

	/// <summary>Initializes the size field by the specified name or the first four bytes of the structure's memory.</summary>
	/// <param name="fieldName">Name of the field.</param>
	public virtual void InitializeSizeField(string? fieldName = null) => (fieldName is null ? handle : GetFieldAddress(fieldName)).Write((uint)BaseStructSize);

	/// <summary>Returns the string value held by this instance.</summary>
	/// <returns>A <see cref="string"/> value held by this instance or <c>null</c> if the handle is invalid.</returns>
	public override string ToString() => ((TStruct?)this)?.ToString() ?? "";

	/// <summary>Returns the addresss of the named field.</summary>
	/// <param name="name">The field address.</param>
	/// <returns>The address of the field within the structure.</returns>
	protected static IntPtr FieldAddress(string name) => Marshal.OffsetOf(typeof(TStruct), name);

	/// <summary>Returns the field offset of the named field.</summary>
	/// <param name="name">The field name.</param>
	/// <returns>The offset, in bytes, of the field within the structure.</returns>
	protected static long FieldOffset(string name) => FieldAddress(name).ToInt64();

#if ALLOWSPAN
	/// <summary>Gets a reference to a structure based on this allocated memory.</summary>
	/// <returns>A referenced structure.</returns>
	public ref TStruct AsRef() => ref MemoryMarshal.GetReference(AsSpan());

	/// <summary>Creates a new span over this allocated memory.</summary>
	/// <returns>The span representation of the structure.</returns>
	public Span<TStruct> AsSpan() => base.AsSpan<TStruct>(1);
#endif
}

/// <summary>A structure handler based on unmanaged memory allocated by AllocCoTaskMem.</summary>
/// <typeparam name="TStruct">The type of the structure.</typeparam>
/// <seealso cref="SafeMemStruct{TStruct, TMem}"/>
public class SafeCoTaskMemStruct<TStruct> : SafeMemStruct<TStruct, CoTaskMemoryMethods> where TStruct : struct
{
	/// <summary>Initializes a new instance of the <see cref="SafeCoTaskMemStruct{TStruct}"/> class.</summary>
	/// <param name="s">The TStruct value.</param>
	/// <param name="capacity">The capacity of the buffer, in bytes.</param>
	public SafeCoTaskMemStruct(in TStruct s, SizeT capacity = default) : base(s, capacity) { }

	/// <summary>Initializes a new instance of the <see cref="SafeCoTaskMemStruct{TStruct}"/> class.</summary>
	/// <param name="capacity">The capacity of the buffer, in bytes.</param>
	public SafeCoTaskMemStruct(SizeT capacity = default) : base(capacity) { }

	/// <summary>Initializes a new instance of the <see cref="SafeCoTaskMemStruct{TStruct}"/> class.</summary>
	/// <param name="ptr">The PTR.</param>
	/// <param name="ownsHandle"><c>true</c> to reliably release the handle during finalization; <c>false</c> to prevent it.</param>
	/// <param name="allocatedBytes">The number of bytes allocated to <paramref name="ptr"/>.</param>
	[ExcludeFromCodeCoverage]
	public SafeCoTaskMemStruct(IntPtr ptr, bool ownsHandle = true, SizeT allocatedBytes = default) : base(ptr, ownsHandle, allocatedBytes) { }

	/// <summary>Represents the <see langword="null"/> equivalent of this class instances.</summary>
	public static readonly SafeCoTaskMemStruct<TStruct> Null = new(IntPtr.Zero, false);

	/// <summary>Performs an implicit conversion from <see cref="Nullable{TStruct}"/> to <see cref="SafeCoTaskMemStruct{TStruct}"/>.</summary>
	/// <param name="s">The value of the <typeparamref name="TStruct"/> instance or <see langword="null"/>.</param>
	/// <returns>The resulting <see cref="SafeCoTaskMemStruct{TStruct}"/> instance from the conversion.</returns>
	public static implicit operator SafeCoTaskMemStruct<TStruct>(TStruct? s) => s.HasValue ? new SafeCoTaskMemStruct<TStruct>(s.Value) : new SafeCoTaskMemStruct<TStruct>(IntPtr.Zero);
}

/// <summary>A structure handler based on unmanaged memory allocated by AllocHGlobal.</summary>
/// <typeparam name="TStruct">The type of the structure.</typeparam>
/// <seealso cref="SafeMemStruct{TStruct, TMem}"/>
public class SafeHGlobalStruct<TStruct> : SafeMemStruct<TStruct, HGlobalMemoryMethods> where TStruct : struct
{
	/// <summary>Initializes a new instance of the <see cref="SafeHGlobalStruct{TStruct}"/> class.</summary>
	/// <param name="s">The TStruct value.</param>
	/// <param name="capacity">The capacity of the buffer, in bytes.</param>
	public SafeHGlobalStruct(in TStruct s, SizeT capacity = default) : base(s, capacity) { }

	/// <summary>Initializes a new instance of the <see cref="SafeHGlobalStruct{TStruct}"/> class.</summary>
	/// <param name="capacity">The capacity of the buffer, in bytes.</param>
	public SafeHGlobalStruct(SizeT capacity = default) : base(capacity) { }

	/// <summary>Initializes a new instance of the <see cref="SafeHGlobalStruct{TStruct}"/> class.</summary>
	/// <param name="ptr">The PTR.</param>
	/// <param name="ownsHandle"><c>true</c> to reliably release the handle during finalization; <c>false</c> to prevent it.</param>
	/// <param name="allocatedBytes">The number of bytes allocated to <paramref name="ptr"/>.</param>
	[ExcludeFromCodeCoverage]
	public SafeHGlobalStruct(IntPtr ptr, bool ownsHandle = true, SizeT allocatedBytes = default) : base(ptr, ownsHandle, allocatedBytes) { }

	/// <summary>Represents the <see langword="null"/> equivalent of this class instances.</summary>
	public static readonly SafeHGlobalStruct<TStruct> Null = new(IntPtr.Zero, false);

	/// <summary>Performs an implicit conversion from <see cref="Nullable{TStruct}"/> to <see cref="SafeHGlobalStruct{TStruct}"/>.</summary>
	/// <param name="s">The value of the <typeparamref name="TStruct"/> instance or <see langword="null"/>.</param>
	/// <returns>The resulting <see cref="SafeHGlobalStruct{TStruct}"/> instance from the conversion.</returns>
	public static implicit operator SafeHGlobalStruct<TStruct>(TStruct? s) => s.HasValue ? new SafeHGlobalStruct<TStruct>(s.Value) : new SafeHGlobalStruct<TStruct>(IntPtr.Zero);
}