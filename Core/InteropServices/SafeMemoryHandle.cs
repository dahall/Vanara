using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security;
using Vanara.PInvoke;

namespace Vanara.InteropServices;

/// <summary>Method used to pack a list of strings into memory.</summary>
public enum StringListPackMethod
{
	/// <summary>Each string is separated by a single '\0' character and is terminated by two '\0' characters.</summary>
	Concatenated,

	/// <summary>
	/// A contiguous block of memory containing an array of pointers to strings followed by a NULL pointer and then followed by the
	/// actual strings.
	/// </summary>
	Packed
}

/// <summary>Interface to capture unmanaged memory methods.</summary>
public interface IMemoryMethods : ISimpleMemoryMethods
{
	/// <summary>Gets the Ansi <see cref="SecureString"/> allocation method.</summary>
	/// <param name="secureString">The secure string.</param>
	/// <returns>A memory handle.</returns>
	IntPtr AllocSecureStringAnsi(SecureString? secureString);

	/// <summary>Gets the Unicode <see cref="SecureString"/> allocation method.</summary>
	/// <param name="secureString">The secure string.</param>
	/// <returns>A memory handle.</returns>
	IntPtr AllocSecureStringUni(SecureString? secureString);

	/// <summary>Gets the Ansi string allocation method.</summary>
	/// <param name="value">The value.</param>
	/// <returns>A memory handle.</returns>
	IntPtr AllocStringAnsi(string? value);

	/// <summary>Gets the Unicode string allocation method.</summary>
	/// <param name="value">The value.</param>
	/// <returns>A memory handle.</returns>
	IntPtr AllocStringUni(string? value);

	/// <summary>Gets the Ansi <see cref="SecureString"/> free method.</summary>
	/// <param name="hMem">A memory handle.</param>
	void FreeSecureStringAnsi(IntPtr hMem);

	/// <summary>Gets the Unicode <see cref="SecureString"/> free method.</summary>
	/// <param name="hMem">A memory handle.</param>
	void FreeSecureStringUni(IntPtr hMem);

	/// <summary>Gets the reallocation method.</summary>
	/// <param name="hMem">A memory handle.</param>
	/// <param name="size">The size, in bytes, of memory to allocate.</param>
	/// <returns>A memory handle.</returns>
	IntPtr ReAllocMem(IntPtr hMem, int size);
}

/// <summary>Defines the base functionality for a safe memory handle, providing methods and properties for managing allocated memory.</summary>
/// <remarks>
/// This interface represents a safe memory handle that supports operations such as copying memory, retrieving bytes, locking, and unlocking.
/// It is designed to abstract memory management in scenarios where direct memory manipulation is required. Implementations of this interface
/// may provide additional functionality, such as span-based access or event handling.
/// </remarks>
public interface ISafeMemoryHandleBase : IDisposable, IHandle, IComparable<byte[]>, IComparable<IReadOnlyList<byte>>
{
#if DEBUG
	/// <summary>Dumps memory to byte string.</summary>
	[ExcludeFromCodeCoverage]
	string Dump { get; }
#endif

	/// <summary>Gets a value indicating whether this memory supports locking.</summary>
	/// <value><see langword="true"/> if lockable; otherwise, <see langword="false"/>.</value>
	bool Lockable { get; }

	/// <summary>Gets or sets the size in bytes of the allocated memory block.</summary>
	/// <value>The size in bytes of the allocated memory block.</value>
	SizeT Size { get; set; }

	/// <summary>Occurs when the handle has changed.</summary>
	event EventHandler<IntPtr>? HandleChanged;

#if ALLOWSPAN
	/// <summary>Casts this allocated memory to a <c>Span&lt;Byte&gt;</c>.</summary>
	/// <returns>A span of type <see cref="byte"/>.</returns>
	Span<byte> AsBytes();

	/// <summary>Creates a new span over this allocated memory.</summary>
	/// <returns>The span representation of the structure.</returns>
	ReadOnlySpan<T> AsReadOnlySpan<T>(int length);

	/// <summary>Creates a new span over this allocated memory.</summary>
	/// <returns>The span representation of the structure.</returns>
	Span<T> AsSpan<T>(int length);
#endif

	/// <summary>Copies memory from this allocation to an allocated memory pointer.</summary>
	/// <param name="dest">A pointer to allocated memory that must be at least <paramref name="length"/> bytes.</param>
	/// <param name="length">The number of bytes to copy.</param>
	void CopyTo(IntPtr dest, SizeT length);

	/// <summary>Copies memory from this allocation to an allocated memory pointer.</summary>
	/// <param name="start">The starting offset within this allocation at which to start copying.</param>
	/// <param name="dest">A pointer to allocated memory that must be at least <paramref name="length" /> bytes.</param>
	/// <param name="length">The number of bytes to copy.</param>
	void CopyTo(SizeT start, IntPtr dest, SizeT length);

	/// <summary>Copies memory from this allocation to an allocated memory handle.</summary>
	/// <param name="dest">A safe handle to allocated memory.</param>
	/// <exception cref="System.ArgumentNullException">dest</exception>
	/// <exception cref="System.ArgumentOutOfRangeException">destOffset</exception>
	void CopyTo(ISafeMemoryHandleBase dest);

	/// <summary>Copies memory from this allocation to an allocated memory handle.</summary>
	/// <param name="start">The starting offset within this allocation at which to start copying.</param>
	/// <param name="length">The number of bytes to copy.</param>
	/// <param name="dest">A safe handle to allocated memory.</param>
	/// <param name="destOffset">The offset within <paramref name="dest"/> at which to start copying.</param>
	/// <exception cref="System.ArgumentNullException">dest</exception>
	/// <exception cref="System.ArgumentOutOfRangeException">destOffset - The destination buffer is not large enough.</exception>
	void CopyTo(SizeT start, SizeT length, ISafeMemoryHandleBase dest, SizeT destOffset = default);

	/// <summary>
	/// Overrides the stored size of the allocated memory. This should be used with extreme caution only in cases where the the derived class
	/// is returned from a P/Invoke call and no size has been set in a constructor.
	/// </summary>
	/// <param name="newSize">The size to be set as the new size of the allocated memory.</param>
	void DangerousOverrideSize(SizeT newSize);

	/// <summary>Gets a copy of bytes from the allocated memory block.</summary>
	/// <returns>A byte array with the copied bytes.</returns>
	byte[] GetBytes();

	/// <summary>Gets a copy of bytes from the allocated memory block.</summary>
	/// <param name="startIndex">The start index.</param>
	/// <param name="count">The number of bytes to retrieve.</param>
	/// <returns>A byte array with the copied bytes.</returns>
	byte[] GetBytes(int startIndex, int count);

	/// <summary>Gets a hash code value for all bytes within the allocated memory.</summary>
	/// <returns>A hash code.</returns>
	int GetContentHashCode();

	/// <summary>Locks this instance.</summary>
	void Lock();

	/// <summary>Releases the owned handle without releasing the allocated memory and returns a pointer to the current memory.</summary>
	/// <returns>A pointer to the currently allocated memory. The caller now has the responsibility to free this memory.</returns>
	IntPtr TakeOwnership();

	/// <summary>Decrements the lock count.</summary>
	/// <returns><see langword="true"/> if the memory object is still locked after decrementing the lock count; otherwise <see langword="false"/>.</returns>
	bool Unlock();
}

/// <summary>Interface for classes that support safe memory pointers.</summary>
public partial interface ISafeMemoryHandle : ISafeMemoryHandleBase
{
	/// <summary>
	/// Adds reference to other SafeMemoryHandle objects, the pointer to which are referred to by this object. This is to ensure that
	/// such objects being referred to wouldn't be unreferenced until this object is active. For e.g. when this object is an array of
	/// pointers to other objects
	/// </summary>
	/// <param name="children">Collection of SafeMemoryHandle objects referred to by this object.</param>
	void AddSubReference(params IDisposable[] children);

	/// <summary>Fills the allocated memory with a specific byte value.</summary>
	/// <param name="value">The byte value.</param>
	/// <param name="length">The number of bytes in the block of memory to be filled.</param>
	void Fill(byte value, int length);

	/// <summary>
	/// Extracts an array of structures of <typeparamref name="T"/> containing <paramref name="count"/> items. <note type="note">This
	/// call can cause memory exceptions if the pointer does not have sufficient allocated memory to retrieve all the structures.</note>
	/// </summary>
	/// <typeparam name="T">The type of the structures to retrieve.</typeparam>
	/// <param name="count">The number of structures to retrieve.</param>
	/// <param name="prefixBytes">The number of bytes to skip before reading the structures.</param>
	/// <returns>An array of structures of <typeparamref name="T"/>.</returns>
	T[] ToArray<T>(SizeT count, SizeT prefixBytes = default);

	/// <summary>
	/// Extracts an enumeration of structures of <typeparamref name="T"/> containing <paramref name="count"/> items. <note
	/// type="note">This call can cause memory exceptions if the pointer does not have sufficient allocated memory to retrieve all the structures.</note>
	/// </summary>
	/// <typeparam name="T">The type of the structures to retrieve.</typeparam>
	/// <param name="count">The number of structures to retrieve.</param>
	/// <param name="prefixBytes">The number of bytes to skip before reading the structures.</param>
	/// <returns>An enumeration of structures of <typeparamref name="T"/>.</returns>
	IEnumerable<T> ToEnumerable<T>(SizeT count, SizeT prefixBytes = default);

	/// <summary>Returns a <see cref="System.String"/> that represents this instance.</summary>
	/// <param name="len">The length.</param>
	/// <param name="charSet">The character set of the string.</param>
	/// <returns>A <see cref="System.String"/> that represents this instance.</returns>
	string? ToString(int len, CharSet charSet = CharSet.Unicode);

	/// <summary>Returns a <see cref="System.String"/> that represents this instance.</summary>
	/// <param name="len">The length.</param>
	/// <param name="prefixBytes">Number of bytes preceding the string pointer.</param>
	/// <param name="charSet">The character set of the string.</param>
	/// <returns>A <see cref="System.String"/> that represents this instance.</returns>
	string? ToString(int len, SizeT prefixBytes, CharSet charSet = CharSet.Unicode);

	/// <summary>
	/// Gets an enumerated list of strings from a block of unmanaged memory where each string is separated by a single '\0' character
	/// and is terminated by two '\0' characters.
	/// </summary>
	/// <param name="charSet">The character set of the strings.</param>
	/// <param name="prefixBytes">Number of bytes preceding the array of string pointers.</param>
	/// <returns>Enumeration of strings.</returns>
	IEnumerable<string> ToStringEnum(CharSet charSet = CharSet.Auto, SizeT prefixBytes = default);

	/// <summary>
	/// Returns an enumeration of strings from memory where each string is pointed to by a preceding list of pointers of length
	/// <paramref name="count"/>.
	/// </summary>
	/// <param name="count">The count.</param>
	/// <param name="charSet">The character set of the strings.</param>
	/// <param name="prefixBytes">Number of bytes preceding the array of string pointers.</param>
	/// <returns>An enumerated list of strings.</returns>
	IEnumerable<string?> ToStringEnum(SizeT count, CharSet charSet = CharSet.Auto, SizeT prefixBytes = default);

	/// <summary>
	/// Marshals data from this block of memory to a newly allocated managed object of the type specified by a generic type parameter.
	/// </summary>
	/// <typeparam name="T">The type of the object to which the data is to be copied. This must be a structure.</typeparam>
	/// <param name="prefixBytes">Number of bytes preceding the structure.</param>
	/// <returns>A managed object that contains the data that this <see cref="SafeMemoryHandleExt{T}"/> holds.</returns>
	T? ToStructure<T>(SizeT prefixBytes = default);
}

/// <summary>
/// Extension interface for <see cref="SafeAllocatedMemoryHandleBase"/> that allows the creation of a new instance of the memory handle.
/// </summary>
public partial interface ISafeMemoryHandleFactory : ISafeMemoryHandle
{
#if NET7_0_OR_GREATER
	/// <summary>Creates an instance of the memory handle from an existing handle and size.</summary>
	/// <param name="handle">The handle to memory allocated in the same manner as the implementer.</param>
	/// <param name="size">The size of memory allocated to the handle, in bytes.</param>
	/// <param name="ownsHandle">if set to <c>true</c> if this class is responsible for freeing the memory on disposal.</param>
	/// <returns>A safe handle to the allocated memory.</returns>
	static abstract ISafeMemoryHandle Create(IntPtr handle, SizeT size, bool ownsHandle = true);

	/// <summary>Creates an instance of the memory handle and copies the contents of the specified array to unmanaged memory.</summary>
	/// <param name="bytes">Array of bytes used to initialize allocated memory.</param>
	/// <returns>A safe handle to the allocated memory.</returns>
	static abstract ISafeMemoryHandle Create(byte[] bytes);

	/// <summary>Creates an instance of the memory handle allocating the specified size.</summary>
	/// <param name="size">The number of bytes to allocate.</param>
	/// <returns>A safe handle to the allocated memory.</returns>
	static abstract ISafeMemoryHandle Create(SizeT size);
#endif
}

/// <summary>Interface to capture unmanaged simple (alloc/free) memory methods.</summary>
public interface ISimpleMemoryMethods
{
	/// <summary>Gets a value indicating whether this memory supports locking.</summary>
	/// <value><see langword="true"/> if lockable; otherwise, <see langword="false"/>.</value>
	bool Lockable { get; }

	/// <summary>Gets a handle to a memory allocation of the specified size.</summary>
	/// <param name="size">The size, in bytes, of memory to allocate.</param>
	/// <returns>A memory handle.</returns>
	IntPtr AllocMem(int size);

	/// <summary>Frees the memory associated with a handle.</summary>
	/// <param name="hMem">A memory handle.</param>
	void FreeMem(IntPtr hMem);

	/// <summary>Locks the memory of a specified handle and gets a pointer to it.</summary>
	/// <param name="hMem">A memory handle.</param>
	/// <returns>A pointer to the locked memory.</returns>
	IntPtr LockMem(IntPtr hMem);

	/// <summary>Unlocks the memory of a specified handle.</summary>
	/// <param name="hMem">A memory handle.</param>
	/// <returns><see langword="true"/> if the memory object is still locked after decrementing the lock count; otherwise <see langword="false"/>.</returns>
	bool UnlockMem(IntPtr hMem);

	/// <summary>Gets a value indicating whether <see cref="AllocMem(int)"/> zeroes memory before returning.</summary>
	/// <value><see langword="true"/> if <see cref="AllocMem(int)"/> zeroes memory before returning; otherwise, <see langword="false"/>.</value>
	bool AllocZeroes { get; }
}

/// <summary>Implementation of <see cref="IMemoryMethods"/> using just the methods from <see cref="ISimpleMemoryMethods"/>.</summary>
/// <seealso cref="IMemoryMethods"/>
public abstract class MemoryMethodsBase : IMemoryMethods
{
	/// <summary>Gets a value indicating whether <see cref="AllocMem(int)"/> zeroes memory before returning.</summary>
	/// <value><see langword="true"/> if <see cref="AllocMem(int)"/> zeroes memory before returning; otherwise, <see langword="false"/>.</value>
	public virtual bool AllocZeroes => false;

	/// <summary>Gets a value indicating whether this memory supports locking.</summary>
	/// <value><see langword="true"/> if lockable; otherwise, <see langword="false"/>.</value>
	public virtual bool Lockable => false;

	/// <summary>
	/// Gets a handle to a memory allocation of the specified size.
	/// </summary>
	/// <param name="size">The size, in bytes, of memory to allocate.</param>
	/// <returns>
	/// A memory handle.
	/// </returns>
	/// <exception cref="NotImplementedException"></exception>
	public abstract IntPtr AllocMem(int size);

	/// <summary>Gets the Ansi <see cref="SecureString"/> allocation method.</summary>
	/// <param name="secureString">The secure string.</param>
	/// <returns>A memory handle.</returns>
	public virtual IntPtr AllocSecureStringAnsi(SecureString? secureString) => StringHelper.AllocSecureString(secureString, CharSet.Ansi, AllocMem);

	/// <summary>Gets the Unicode <see cref="SecureString"/> allocation method.</summary>
	/// <param name="secureString">The secure string.</param>
	/// <returns>A memory handle.</returns>
	public virtual IntPtr AllocSecureStringUni(SecureString? secureString) => StringHelper.AllocSecureString(secureString, CharSet.Unicode, AllocMem);

	/// <summary>Gets the Ansi string allocation method.</summary>
	/// <param name="value">The value.</param>
	/// <returns>A memory handle.</returns>
	public virtual IntPtr AllocStringAnsi(string? value) => StringHelper.AllocString(value, CharSet.Ansi, AllocMem);

	/// <summary>Gets the Unicode string allocation method.</summary>
	/// <param name="value">The value.</param>
	/// <returns>A memory handle.</returns>
	public virtual IntPtr AllocStringUni(string? value) => StringHelper.AllocString(value, CharSet.Unicode, AllocMem);

	/// <summary>Frees the memory associated with a handle.</summary>
	/// <param name="hMem">A memory handle.</param>
	public abstract void FreeMem(IntPtr hMem);

	/// <summary>Gets the Ansi <see cref="SecureString"/> free method.</summary>
	/// <param name="hMem">A memory handle.</param>
	public virtual void FreeSecureStringAnsi(IntPtr hMem) => FreeMem(hMem);

	/// <summary>Gets the Unicode <see cref="SecureString"/> free method.</summary>
	/// <param name="hMem">A memory handle.</param>
	public virtual void FreeSecureStringUni(IntPtr hMem) => FreeMem(hMem);

	/// <summary>Locks the memory of a specified handle and gets a pointer to it.</summary>
	/// <param name="hMem">A memory handle.</param>
	/// <returns>A pointer to the locked memory.</returns>
	public virtual IntPtr LockMem(IntPtr hMem) => hMem;

	/// <summary>Gets the reallocation method.</summary>
	/// <param name="hMem">A memory handle.</param>
	/// <param name="size">The size, in bytes, of memory to allocate.</param>
	/// <returns>A memory handle.</returns>
	public virtual IntPtr ReAllocMem(IntPtr hMem, int size)
	{
		var hNew = AllocMem(size);
		hMem.CopyTo(hNew, size);
		FreeMem(hMem);
		return hNew;
	}

	/// <summary>Unlocks the memory of a specified handle.</summary>
	/// <param name="hMem">A memory handle.</param>
	/// <returns><see langword="true"/> if the memory object is still locked after decrementing the lock count; otherwise <see langword="false"/>.</returns>
	public virtual bool UnlockMem(IntPtr hMem) => false;
}

/// <summary>
/// Abstract base class for all SafeHandle derivatives that encapsulate handling unmanaged memory. This class assumes read-only memory.
/// </summary>
/// <seealso cref="System.Runtime.InteropServices.SafeHandle" />
/// <seealso cref="System.IComparable{T}" />
/// <seealso cref="System.IComparable{T}" />
/// <seealso cref="System.IEquatable{T}" />
/// <seealso cref="SafeHandle" />
public abstract class SafeAllocatedMemoryHandleBase : SafeHandle, ISafeMemoryHandleBase, IComparable<SafeAllocatedMemoryHandleBase>,
	IEquatable<SafeAllocatedMemoryHandleBase>
{
	/// <summary>Occurs when the handle has changed.</summary>
	public event EventHandler<IntPtr>? HandleChanged;

	/// <summary>Initializes a new instance of the <see cref="SafeAllocatedMemoryHandleBase"/> class.</summary>
	/// <param name="handle">The handle.</param>
	/// <param name="ownsHandle">if set to <c>true</c> if this class is responsible for freeing the memory on disposal.</param>
	protected SafeAllocatedMemoryHandleBase(IntPtr handle, bool ownsHandle) : base(IntPtr.Zero, ownsHandle) => SetHandle(handle);

#if DEBUG
	/// <summary>Dumps memory to byte string.</summary>
	[ExcludeFromCodeCoverage]
	public string Dump => Size == 0 ? "" : string.Join(" ", GetBytes(0, Size).Select(b => b.ToString("X2")).ToArray());
#endif

	/// <summary>Gets a value indicating whether this memory supports locking.</summary>
	/// <value><see langword="true"/> if lockable; otherwise, <see langword="false"/>.</value>
	public virtual bool Lockable => false;

	/// <summary>Gets or sets the size in bytes of the allocated memory block.</summary>
	/// <value>The size in bytes of the allocated memory block.</value>
	public abstract SizeT Size { get; set; }

	/// <summary>Performs an explicit conversion from <see cref="SafeAllocatedMemoryHandleBase"/> to <see cref="byte"/> pointer.</summary>
	/// <param name="hMem">The <see cref="SafeAllocatedMemoryHandleBase"/> instance.</param>
	/// <returns>The result of the conversion.</returns>
	public static unsafe explicit operator byte*(SafeAllocatedMemoryHandleBase hMem) => (byte*)hMem.handle;

	/// <summary>Performs an explicit conversion from <see cref="SafeAllocatedMemoryHandleBase"/> to <see cref="SafeBuffer"/>.</summary>
	/// <param name="hMem">The <see cref="SafeAllocatedMemoryHandleBase"/> instance.</param>
	/// <returns>The result of the conversion.</returns>
	public static explicit operator SafeBuffer(SafeAllocatedMemoryHandleBase hMem) => new SafeBufferImpl(hMem);

	/// <summary>Performs an implicit conversion from <see cref="SafeAllocatedMemoryHandleBase"/> to <see cref="IntPtr"/>.</summary>
	/// <param name="hMem">The <see cref="SafeAllocatedMemoryHandleBase"/> instance.</param>
	/// <returns>The result of the conversion.</returns>
	public static implicit operator IntPtr(SafeAllocatedMemoryHandleBase hMem) => hMem.handle;

	/// <summary>Implements the operator ! which returns <see langword="true"/> if the handle is invalid.</summary>
	/// <param name="hMem">The <see cref="SafeAllocatedMemoryHandleBase"/> instance.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator !(SafeAllocatedMemoryHandleBase hMem) => hMem.IsInvalid;

#if !NETSTANDARD
	/// <summary>Implements the operator <see langword="true"/>.</summary>
	/// <param name="hMem">The value.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator true(SafeAllocatedMemoryHandleBase hMem) => !hMem.IsInvalid;

	/// <summary>Implements the operator <see langword="false"/>.</summary>
	/// <param name="hMem">The value.</param>
	/// <returns>The result of the operator.</returns>
	public static bool operator false(SafeAllocatedMemoryHandleBase hMem) => hMem.IsInvalid;
#endif

#if ALLOWSPAN
	/// <summary>Creates a new span over this allocated memory.</summary>
	/// <returns>The span representation of the structure.</returns>
	public virtual ReadOnlySpan<T> AsReadOnlySpan<T>(int length) => handle.AsReadOnlySpan<T>(length, 0, Size);

	/// <summary>Creates a new span over this allocated memory.</summary>
	/// <returns>The span representation of the structure.</returns>
	public virtual Span<T> AsSpan<T>(int length) => handle.AsSpan<T>(length, 0, Size);

	/// <summary>Casts this allocated memory to a <c>Span&lt;Byte&gt;</c>.</summary>
	/// <returns>A span of type <see cref="byte"/>.</returns>
	public virtual Span<byte> AsBytes() => AsSpan<byte>(Size);
#endif

	/// <inheritdoc/>
	public virtual int CompareTo(SafeAllocatedMemoryHandleBase? other)
	{
		if (other is null) return 1;
		if (handle.Equals(other.handle)) return 0;
		var ret = Size.CompareTo(other.Size);
		if (ret != 0)
			return ret;

#if ALLOWSPAN
		var a = AsReadOnlySpan<byte>(Size);
		var b = other.AsReadOnlySpan<byte>(Size);
		return a.SequenceCompareTo(b);
#else
		var a = GetBytes();
		var b = other.GetBytes(Size);
		for (int i = 0; i < Size; i++)
		{
			if ((ret = a[i].CompareTo(b[i])) != 0)
				return ret;
		}
		return ret;
#endif
	}

	/// <inheritdoc/>
	public virtual int CompareTo(byte[]? other) => other is null ? 1 : CompareTo(Array.AsReadOnly(other));

	/// <inheritdoc/>
	public virtual int CompareTo(IReadOnlyList<byte>? other)
	{
		if (other is null) return 1;
		int ret = Size.CompareTo(other.Count);
		if (ret != 0)
			return ret;

#if ALLOWSPAN
		var a = AsReadOnlySpan<byte>(Size);
#else
		var a = GetBytes();
#endif
		for (int i = 0; i < Size; i++)
		{
			if ((ret = a[i].CompareTo(other[i])) != 0)
				return ret;
		}
		return ret;
	}

	/// <inheritdoc/>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void CopyTo(IntPtr dest, SizeT length) => CopyTo(0, dest, length);

	/// <inheritdoc/>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void CopyTo(SizeT start, IntPtr dest, SizeT length) => CallLocked(p => p.CopyTo(start, dest, length));

	/// <inheritdoc/>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public void CopyTo(ISafeMemoryHandleBase dest) => CopyTo(0, Size, dest);

	/// <inheritdoc/>
	public void CopyTo(SizeT start, SizeT length, ISafeMemoryHandleBase dest, SizeT destOffset = default)
	{
		if (dest is null) throw new ArgumentNullException(nameof(dest));
		if (start + length > Size) throw new ArgumentOutOfRangeException(nameof(start), "The start offset and length exceed the size of the memory block.");
		if (dest.Size < destOffset + length) throw new ArgumentOutOfRangeException(nameof(destOffset), "The destination buffer is not large enough.");
		CopyTo(start, dest.DangerousGetHandle().Offset(destOffset), length);
	}

	/// <summary>
	/// Overrides the stored size of the allocated memory. This should be used with extreme caution only in cases where the the derived class
	/// is returned from a P/Invoke call and no size has been set in a constructor.
	/// </summary>
	/// <param name="newSize">The size to be set as the new size of the allocated memory.</param>
	public abstract void DangerousOverrideSize(SizeT newSize);

	/// <inheritdoc/>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public bool Equals(SafeAllocatedMemoryHandleBase? other) => CompareTo(other) == 0;

	/// <inheritdoc/>
	public override bool Equals(object? obj) => obj switch
	{
		null => false,
		SafeAllocatedMemoryHandleBase m => Equals(m),
		IntPtr p => handle.Equals(p),
		byte[] b => CompareTo(Array.AsReadOnly(b)) == 0,
		IReadOnlyList<byte> e => CompareTo(e) == 0,
		_ => throw new ArgumentException("Unable to compare type.", nameof(obj)),
	};

	/// <summary>Gets a hash code value for all bytes within the allocated memory.</summary>
	/// <returns>A hash code.</returns>
	public virtual int GetContentHashCode()
	{
		unsafe
		{
			byte* p = (byte*)handle;
			int result = 0;
			for (int i = 0; i < Size; i++)
				result = (result * 31) ^ p[i];
			return result;
		}
	}

	/// <inheritdoc/>
	public override int GetHashCode() => handle.GetHashCode();

	/// <summary>Locks this instance.</summary>
	public virtual void Lock()
	{
	}

	/// <summary>Decrements the lock count.</summary>
	/// <returns><see langword="true"/> if the memory object is still locked after decrementing the lock count; otherwise <see langword="false"/>.</returns>
	public virtual bool Unlock() => false;

	/// <summary>Releases the owned handle without releasing the allocated memory and returns a pointer to the current memory.</summary>
	/// <returns>A pointer to the currently allocated memory. The caller now has the responsibility to free this memory.</returns>
	public virtual IntPtr TakeOwnership()
	{
		while (Unlock()) ;
		var h = handle;
		SetHandleAsInvalid();
		handle = IntPtr.Zero;
		Size = 0;
		return h;
	}

	/// <summary>Gets a copy of bytes from the allocated memory block.</summary>
	/// <returns>A byte array with the copied bytes.</returns>
	public byte[] GetBytes() => GetBytes(0, Size);

	/// <summary>Gets a copy of bytes from the allocated memory block.</summary>
	/// <param name="startIndex">The start index.</param>
	/// <param name="count">The number of bytes to retrieve.</param>
	/// <returns>A byte array with the copied bytes.</returns>
	public byte[] GetBytes(int startIndex, int count)
	{
		if (startIndex < 0 || startIndex + count > Size) throw new ArgumentOutOfRangeException(nameof(startIndex));
		var ret = new byte[count];
		CallLocked(p => Marshal.Copy(p.Offset(startIndex), ret, 0, count));
		return ret;
	}

	/// <summary>Runs a delegate method while locking the memory.</summary>
	/// <param name="action">The action to perform while memory is locked.</param>
	protected void CallLocked(Action<IntPtr> action)
	{
		if (!Lockable)
			action.Invoke(handle);
		else
		{
			try { Lock(); action.Invoke(handle); }
			finally { Unlock(); }
		}
	}

	/// <summary>Runs a delegate method while locking the memory.</summary>
	/// <param name="action">The action to perform while memory is locked.</param>
	protected TOut CallLocked<TOut>(Func<IntPtr, TOut> action)
	{
		if (!Lockable)
			return action.Invoke(handle);

		try { Lock(); return action.Invoke(handle); }
		finally { Unlock(); }
	}

	/// <summary>Sets the handle to the specified pre-existing handle.</summary>
	/// <param name="h">The pre-existing handle to use.</param>
	/// <remarks>
	/// Use the SetHandle method only if you need to support a pre-existing handle (for example, if the handle is returned in a structure)
	/// because the .NET Framework COM interop infrastructure does not support marshaling output handles in a structure.
	/// </remarks>
	new protected void SetHandle(IntPtr h) { base.SetHandle(h); HandleChanged?.Invoke(this, h); }

	private class SafeBufferImpl : SafeBuffer
	{
		public SafeBufferImpl(SafeAllocatedMemoryHandleBase hMem) : base(false) => Initialize((ulong)hMem.Size);

		protected override bool ReleaseHandle() => true;
	}
}

/// <summary>Abstract base class for all SafeHandle derivatives that encapsulate handling unmanaged memory.</summary>
/// <seealso cref="SafeHandle"/>
public abstract class SafeAllocatedMemoryHandle : SafeAllocatedMemoryHandleBase
{
	/// <summary>
	/// Maintains reference to other SafeMemoryHandleExt objects, the pointer to which are referred to by this object. This is to ensure
	/// that such objects being referred to wouldn't be unreferenced until this object is active.
	/// </summary>
	private List<IDisposable>? references;

	/// <summary>Initializes a new instance of the <see cref="SafeAllocatedMemoryHandle"/> class.</summary>
	/// <param name="handle">The handle.</param>
	/// <param name="ownsHandle">if set to <c>true</c> if this class is responsible for freeing the memory on disposal.</param>
	protected SafeAllocatedMemoryHandle(IntPtr handle, bool ownsHandle) : base(handle, ownsHandle) { }

	/// <summary>
	/// Adds reference to other SafeMemoryHandle objects, the pointer to which are referred to by this object. This is to ensure that
	/// such objects being referred to wouldn't be unreferenced until this object is active. For e.g. when this object is an array of
	/// pointers to other objects
	/// </summary>
	/// <param name="children">Collection of SafeMemoryHandle objects referred to by this object.</param>
	public void AddSubReference(IEnumerable<IDisposable> children)
	{
		references ??= [];
		references.AddRange(children);
	}

	/// <summary>
	/// Adds reference to other SafeMemoryHandle objects, the pointer to which are referred to by this object. This is to ensure that
	/// such objects being referred to wouldn't be unreferenced until this object is active. For e.g. when this object is an array of
	/// pointers to other objects
	/// </summary>
	/// <param name="children">Collection of SafeMemoryHandle objects referred to by this object.</param>
	public void AddSubReference(params IDisposable[] children)
	{
		references ??= [];
		references.AddRange(children);
	}

	/// <summary>Fills the allocated memory with a specific byte value.</summary>
	/// <param name="value">The byte value.</param>
	public virtual void Fill(byte value) => Fill(value, Size);

	/// <summary>Fills the allocated memory with a specific byte value.</summary>
	/// <param name="value">The byte value.</param>
	/// <param name="length">The number of bytes in the block of memory to be filled.</param>
	public virtual void Fill(byte value, int length)
	{
		if (length > Size) throw new ArgumentOutOfRangeException(nameof(length));
		CallLocked(p => p.FillMemory(value, length));
	}

	/// <summary>Zero out all allocated memory.</summary>
	public virtual void Zero() => Fill(0, Size);

	/// <inheritdoc/>
	protected override void Dispose(bool disposing)
	{
		if (disposing && references is not null)
		{
			foreach (var d in references) d.Dispose();
			references = null;
		}
		base.Dispose(disposing);
	}
}

/// <summary>Abstract base class for all SafeAllocatedMemoryHandle derivatives that apply a specific memory handling routine set.</summary>
/// <typeparam name="TMem">The <see cref="IMemoryMethods"/> implementation.</typeparam>
public abstract class SafeMemoryHandle<TMem> : SafeAllocatedMemoryHandle where TMem : IMemoryMethods, new()
{
	/// <summary>The <see cref="IMemoryMethods"/> implementation instance.</summary>
	protected static readonly TMem mm = new();

	/// <summary>The number of bytes currently allocated.</summary>
	protected SizeT sz;

	private IntPtr unlockedHandle;

	/// <summary>Initializes a new instance of the <see cref="SafeMemoryHandle{T}"/> class.</summary>
	/// <param name="size">The size of memory to allocate, in bytes.</param>
	/// <exception cref="ArgumentOutOfRangeException">size - The value of this argument must be non-negative</exception>
	protected SafeMemoryHandle(SizeT size = default) : base(IntPtr.Zero, true)
	{
		if (size == 0) return;
		InitFromSize(size);
		if (!mm.AllocZeroes)
			Zero();
	}

	/// <summary>Initializes a new instance of the <see cref="SafeMemoryHandle{T}"/> class.</summary>
	/// <param name="handle">The handle.</param>
	/// <param name="size">The size of memory allocated to the handle, in bytes.</param>
	/// <param name="ownsHandle">if set to <c>true</c> if this class is responsible for freeing the memory on disposal.</param>
	protected SafeMemoryHandle(IntPtr handle, SizeT size, bool ownsHandle) : base(handle, ownsHandle) => sz = size;

	/// <summary>
	/// Allocates from unmanaged memory to represent an array of pointers and marshals the unmanaged pointers (IntPtr) to the native
	/// array equivalent.
	/// </summary>
	/// <param name="bytes">Array of unmanaged pointers</param>
	/// <returns>SafeHGlobalHandle object to an native (unmanaged) array of pointers</returns>
	protected SafeMemoryHandle(byte[] bytes) : base(IntPtr.Zero, true)
	{
		if (bytes is null || bytes.Length == 0) return;
		InitFromSize(bytes.Length);
		CallLocked(p => Marshal.Copy(bytes, 0, p, bytes.Length));
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="SafeMemoryHandle{TMem}"/> class from a <see cref="SafeAllocatedMemoryHandle"/>
	/// instance, copying all the memory.
	/// </summary>
	/// <param name="source">The source memory block.</param>
	protected SafeMemoryHandle(SafeAllocatedMemoryHandle source) : base(IntPtr.Zero, true)
	{
		if (source is null) return;
		InitFromSize(source.Size);
		CallLocked(p => ((IntPtr)source).CopyTo(p, source.Size));
	}

	/// <summary>When overridden in a derived class, gets a value indicating whether the handle value is invalid.</summary>
	public override bool IsInvalid => handle == IntPtr.Zero;

	/// <summary>Gets a value indicating whether this memory supports locking.</summary>
	/// <value><see langword="true"/> if lockable; otherwise, <see langword="false"/>.</value>
	public override bool Lockable => mm.Lockable;

	/// <summary>Gets or sets the size in bytes of the allocated memory block.</summary>
	/// <value>The size in bytes of the allocated memory block.</value>
	public override SizeT Size
	{
		get => sz;
		set
		{
			if (value == 0)
			{
				ReleaseHandle();
			}
			else
			{
				RuntimeHelpers.PrepareConstrainedRegions();
				handle = IsInvalid ? mm.AllocMem(value) : mm.ReAllocMem(handle, value);
				if (!mm.AllocZeroes && value > sz)
					handle.Offset(sz).FillMemory(0, value - sz);
				sz = value;
			}
		}
	}

	/// <summary>
	/// Overrides the stored size of the allocated memory. This should be used with extreme caution only in cases where the the derived class
	/// is returned from a P/Invoke call and no size has been set in a constructor.
	/// </summary>
	/// <param name="newSize">The size to be set as the new size of the allocated memory.</param>
	public override void DangerousOverrideSize(SizeT newSize) => sz = newSize;

	/// <summary>Locks this instance.</summary>
	public override void Lock()
	{
		if (!Lockable) return;
		if (unlockedHandle == default)
		{
			var hlocked = mm.LockMem(handle);
			if (hlocked != handle)
			{
				unlockedHandle = handle;
				SetHandle(hlocked);
			}
		}
		else
			mm.LockMem(unlockedHandle);
	}

	/// <summary>Decrements the lock count.</summary>
	/// <returns><see langword="true"/> if the memory object is still locked after decrementing the lock count; otherwise <see langword="false"/>.</returns>
	public override bool Unlock()
	{
		if (!Lockable || unlockedHandle == default)
			return false;
		var stillLocked = mm.UnlockMem(unlockedHandle);
		if (!stillLocked)
		{
			SetHandle(unlockedHandle);
			unlockedHandle = default;
		}
		return stillLocked;
	}

	/// <summary>
	/// Clones the memory tied to this instance using <see cref="ISimpleMemoryMethods.AllocMem(int)"/> and returns a pointer to the
	/// copied memory.
	/// </summary>
	/// <returns>
	/// A pointer, allocated using <see cref="ISimpleMemoryMethods.AllocMem(int)"/>, to a copy of the memory allocated to this instance.
	/// </returns>
	protected IntPtr CloneMemory()
	{
		var ret = mm.AllocMem(Size);
		Lock();
		handle.CopyTo(ret, Size);
		Unlock();
		return ret;
	}

	/// <summary>When overridden in a derived class, executes the code required to free the handle.</summary>
	/// <returns>
	/// true if the handle is released successfully; otherwise, in the event of a catastrophic failure, false. In this case, it
	/// generates a releaseHandleFailed MDA Managed Debugging Assistant.
	/// </returns>
	protected override bool ReleaseHandle()
	{
		while (Unlock()) ;
		mm.FreeMem(handle);
		sz = 0;
		handle = IntPtr.Zero;
		return true;
	}

	private void InitFromSize(SizeT size)
	{
		RuntimeHelpers.PrepareConstrainedRegions();
		SetHandle(mm.AllocMem(sz = size));
	}
}

/// <summary>A <see cref="SafeHandle"/> for memory allocated via COM.</summary>
/// <seealso cref="SafeHandle"/>
public abstract class SafeMemoryHandleExt<TMem> : SafeMemoryHandle<TMem>, ISafeMemoryHandle where TMem : IMemoryMethods, new()
{
	/// <summary>Initializes a new instance of the <see cref="SafeMemoryHandleExt{T}"/> class.</summary>
	/// <param name="size">The size of memory to allocate, in bytes.</param>
	/// <exception cref="ArgumentOutOfRangeException">size - The value of this argument must be non-negative</exception>
	protected SafeMemoryHandleExt(SizeT size) : base(size) { }

	/// <summary>Initializes a new instance of the <see cref="SafeMemoryHandleExt{T}"/> class.</summary>
	/// <param name="handle">The handle.</param>
	/// <param name="size">The size of memory allocated to the handle, in bytes.</param>
	/// <param name="ownsHandle">if set to <c>true</c> if this class is responsible for freeing the memory on disposal.</param>
	protected SafeMemoryHandleExt(IntPtr handle, SizeT size, bool ownsHandle) : base(handle, size, ownsHandle) { }

	/// <summary>
	/// Allocates from unmanaged memory to represent an array of pointers and marshals the unmanaged pointers (IntPtr) to the native
	/// array equivalent.
	/// </summary>
	/// <param name="bytes">Array of unmanaged pointers</param>
	/// <returns>SafeHGlobalHandle object to an native (unmanaged) array of pointers</returns>
	protected SafeMemoryHandleExt(byte[] bytes) : base(bytes) { }

	/// <summary>
	/// Allocates from unmanaged memory to represent an array of pointers and marshals the unmanaged pointers (IntPtr) to the native
	/// array equivalent.
	/// </summary>
	/// <param name="values">Array of unmanaged pointers</param>
	/// <returns>SafeMemoryHandleExt object to an native (unmanaged) array of pointers</returns>
	protected SafeMemoryHandleExt(IntPtr[] values) : this(IntPtr.Size * values.Length) => CallLocked(p => Marshal.Copy(values, 0, p, values.Length));

	/// <summary>Allocates from unmanaged memory to represent a Unicode string (WSTR) and marshal this to a native PWSTR.</summary>
	/// <param name="s">The string value.</param>
	/// <param name="charSet">The character set of the string.</param>
	/// <returns>SafeMemoryHandleExt object to an native (unmanaged) string</returns>
	protected SafeMemoryHandleExt(string s, CharSet charSet = CharSet.Unicode) : base(IntPtr.Zero, s.GetByteCount(true, charSet), true)
	{
		RuntimeHelpers.PrepareConstrainedRegions();
		SetHandle(StringHelper.GetCharSize(charSet) == 2 ? mm.AllocStringUni(s) : mm.AllocStringAnsi(s));
	}

	/// <summary>
	/// Initializes a new instance of the <see cref="SafeMemoryHandleExt{TMem}"/> class from a <see cref="SafeAllocatedMemoryHandle"/>
	/// instance, copying all the memory.
	/// </summary>
	/// <param name="source">The source memory block.</param>
	protected SafeMemoryHandleExt(SafeAllocatedMemoryHandle source) : base(source) { }

	/// <summary>
	/// Extracts an array of structures of <typeparamref name="T"/> containing <paramref name="count"/> items. <note type="note">This
	/// call can cause memory exceptions if the pointer does not have sufficient allocated memory to retrieve all the structures.</note>
	/// </summary>
	/// <typeparam name="T">The type of the structures to retrieve.</typeparam>
	/// <param name="count">The number of structures to retrieve.</param>
	/// <param name="prefixBytes">The number of bytes to skip before reading the structures.</param>
	/// <returns>An array of structures of <typeparamref name="T"/>.</returns>
	public T[] ToArray<T>(SizeT count, SizeT prefixBytes = default)
	{
		if (IsInvalid) return [];
		//if (Size < Marshal.SizeOf(typeof(T)) * count + prefixBytes)
		//	throw new InsufficientMemoryException("Requested array is larger than the memory allocated.");
		//if (!typeof(T).IsBlittable()) throw new ArgumentException(@"Structure layout is not sequential or explicit.");
		//Debug.Assert(typeof(T).StructLayoutAttribute?.Value == LayoutKind.Sequential);
		return CallLocked(p => p.ToArray<T>(count, prefixBytes, sz)) ?? [];
	}

	/// <summary>
	/// Extracts an enumeration of structures of <typeparamref name="T"/> containing <paramref name="count"/> items. <note
	/// type="note">This call can cause memory exceptions if the pointer does not have sufficient allocated memory to retrieve all the structures.</note>
	/// </summary>
	/// <typeparam name="T">The type of the structures to retrieve.</typeparam>
	/// <param name="count">The number of structures to retrieve.</param>
	/// <param name="prefixBytes">The number of bytes to skip before reading the structures.</param>
	/// <returns>An enumeration of structures of <typeparamref name="T"/>.</returns>
	public IEnumerable<T> ToEnumerable<T>(SizeT count, SizeT prefixBytes = default)
	{
		if (IsInvalid) yield break;
		//if (Size < Marshal.SizeOf(typeof(T)) * count + prefixBytes)
		//	throw new InsufficientMemoryException("Requested array is larger than the memory allocated.");
		//if (!typeof(T).IsBlittable()) throw new ArgumentException(@"Structure layout is not sequential or explicit.");
		//Debug.Assert(typeof(T).StructLayoutAttribute?.Value == LayoutKind.Sequential);
		try
		{
			Lock();
			foreach (T? i in handle.ToIEnum<T>(count, prefixBytes, sz))
				yield return i!;
		}
		finally
		{
			Unlock();
		}
	}

	/// <summary>Returns a <see cref="System.String"/> that represents this instance.</summary>
	/// <param name="len">The length.</param>
	/// <param name="charSet">The character set of the string.</param>
	/// <returns>A <see cref="System.String"/> that represents this instance.</returns>
	public string? ToString(int len, CharSet charSet = CharSet.Unicode) => ToString(len, 0, charSet);

	/// <summary>Returns a <see cref="System.String"/> that represents this instance.</summary>
	/// <param name="len">The length.</param>
	/// <param name="prefixBytes">Number of bytes preceding the string pointer.</param>
	/// <param name="charSet">The character set of the string.</param>
	/// <returns>A <see cref="System.String"/> that represents this instance.</returns>
	public string? ToString(int len, SizeT prefixBytes, CharSet charSet = CharSet.Unicode)
	{
		var str = CallLocked(p => StringHelper.GetString(p.Offset(prefixBytes), charSet, sz == 0 ? long.MaxValue : sz - prefixBytes));
		return len == -1 ? str : str?.Substring(0, Math.Min(len, str.Length));
	}

	/// <summary>
	/// Returns an enumeration of strings from memory where each string is pointed to by a preceding list of pointers of length
	/// <paramref name="count"/>.
	/// </summary>
	/// <param name="count">The count of expected strings.</param>
	/// <param name="charSet">The character set of the strings.</param>
	/// <param name="prefixBytes">Number of bytes preceding the array of string pointers.</param>
	/// <returns>Enumeration of strings.</returns>
	public IEnumerable<string?> ToStringEnum(SizeT count, CharSet charSet = CharSet.Auto, SizeT prefixBytes = default) =>
		IsInvalid ? [] : CallLocked(p => p.ToStringEnum(count, charSet, prefixBytes, sz));

	/// <summary>
	/// Gets an enumerated list of strings from a block of unmanaged memory where each string is separated by a single '\0' character
	/// and is terminated by two '\0' characters.
	/// </summary>
	/// <param name="charSet">The character set of the strings.</param>
	/// <param name="prefixBytes">Number of bytes preceding the array of string pointers.</param>
	/// <returns>An enumerated list of strings.</returns>
	public IEnumerable<string> ToStringEnum(CharSet charSet = CharSet.Auto, SizeT prefixBytes = default) =>
		IsInvalid ? [] : CallLocked(p => p.ToStringEnum(charSet, prefixBytes, sz));

	/// <summary>
	/// Marshals data from this block of memory to a newly allocated managed object of the type specified by a generic type parameter.
	/// </summary>
	/// <typeparam name="T">The type of the object to which the data is to be copied. This must be a structure.</typeparam>
	/// <param name="prefixBytes">Number of bytes preceding the structure.</param>
	/// <returns>A managed object that contains the data that this <see cref="SafeMemoryHandleExt{T}"/> holds.</returns>
	public T? ToStructure<T>(SizeT prefixBytes = default)
	{
		if (IsInvalid) return default;
		return CallLocked(p => p.ToStructure<T>(sz, prefixBytes));
	}

	/// <summary>Marshals data from a managed list of specified type to an offset within this allocated memory.</summary>
	/// <typeparam name="T">
	/// A type of the enumerated managed object that holds the data to be marshaled. The object must be a structure or an instance of a
	/// formatted class.
	/// </typeparam>
	/// <param name="items">The enumerated list of items to marshal.</param>
	/// <param name="autoExtend">
	/// if set to <c>true</c> automatically extend the allocated memory to the size required to hold <paramref name="items"/>.
	/// </param>
	/// <param name="offset">The number of bytes to skip before writing the first element of <paramref name="items"/>.</param>
	public SizeT Write<T>(IEnumerable<T> items, bool autoExtend = true, SizeT offset = default)
	{
		if (IsInvalid) throw new MemberAccessException("Safe memory pointer is not valid.");
		if (autoExtend)
		{
			var count = items.Count();
			if (count == 0) return 0;
			InteropExtensions.TrueType(typeof(T), out var iSz);
			var reqSz = iSz * count + offset;
			if (sz < reqSz)
				Size = reqSz;
		}
		return CallLocked(p => p.Write(items, offset, sz));
	}

	/// <summary>Writes the specified value to an offset within this allocated memory.</summary>
	/// <typeparam name="T">The type of the value to write.</typeparam>
	/// <param name="value">The value to write.</param>
	/// <param name="autoExtend">
	/// if set to <c>true</c> automatically extend the allocated memory to the size required to hold <paramref name="value"/>.
	/// </param>
	/// <param name="offset">The number of bytes to offset from the beginning of this allocated memory before writing.</param>
	public SizeT Write<T>(in T value, bool autoExtend = true, SizeT offset = default) where T : struct
	{
		if (IsInvalid) throw new MemberAccessException("Safe memory pointer is not valid.");
		if (autoExtend)
		{
			InteropExtensions.TrueType(typeof(T), out var iSz);
			var reqSz = iSz + offset;
			if (sz < reqSz)
				Size = reqSz;
		}
		try { Lock(); return handle.Write(value, offset, sz); }
		finally { Unlock(); }
	}

	/// <summary>Writes the specified value to an offset within this allocated memory.</summary>
	/// <param name="value">The value to write.</param>
	/// <param name="autoExtend">
	/// if set to <c>true</c> automatically extend the allocated memory to the size required to hold <paramref name="value"/>.
	/// </param>
	/// <param name="offset">The number of bytes to offset from the beginning of this allocated memory before writing.</param>
	public SizeT Write(object value, bool autoExtend = true, SizeT offset = default)
	{
		if (IsInvalid) throw new MemberAccessException("Safe memory pointer is not valid.");
		if (value is null) return 0;
		if (autoExtend)
		{
			InteropExtensions.TrueType(value.GetType(), out var iSz);
			var reqSz = iSz + offset;
			if (sz < reqSz)
				Size = reqSz;
		}
		return CallLocked(p => p.Write(value, offset, sz));
	}

	/// <summary>When overridden in a derived class, executes the code required to free the handle.</summary>
	/// <returns>
	/// true if the handle is released successfully; otherwise, in the event of a catastrophic failure, false. In this case, it
	/// generates a releaseHandleFailed MDA Managed Debugging Assistant.
	/// </returns>
	protected override bool ReleaseHandle()
	{
		var released = base.ReleaseHandle();
		handle = IntPtr.Zero;
		return released;
	}

#if ALLOWSPAN
	/// <summary>Gets a reference to a structure based on this allocated memory.</summary>
	/// <returns>A referenced structure.</returns>
	public virtual ref T AsRef<T>() => ref MemoryMarshal.GetReference(AsSpan<T>(1));
#endif
}