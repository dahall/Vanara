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

/// <summary>Interface for classes that support safe memory pointers.</summary>
public interface ISafeMemoryHandle : IDisposable
{
	/// <summary>Gets a value indicating whether the handle value is invalid.</summary>
	bool IsInvalid { get; }

	/// <summary>Gets the size of the allocated memory block.</summary>
	/// <value>The size of the allocated memory block.</value>
	SizeT Size { get; set; }

	/// <summary>
	/// Adds reference to other SafeMemoryHandle objects, the pointer to which are referred to by this object. This is to ensure that
	/// such objects being referred to wouldn't be unreferenced until this object is active. For e.g. when this object is an array of
	/// pointers to other objects
	/// </summary>
	/// <param name="children">Collection of SafeMemoryHandle objects referred to by this object.</param>
	void AddSubReference(IEnumerable<ISafeMemoryHandle> children);

	/// <summary>Returns the instance as an <see cref="IntPtr"/>. This is a dangerous call as the value is mutable.</summary>
	/// <returns>An <see cref="IntPtr"/> to the internally held memory.</returns>
	IntPtr DangerousGetHandle();

	/// <summary>Gets a copy of bytes from the allocated memory block.</summary>
	/// <param name="startIndex">The start index.</param>
	/// <param name="count">The number of bytes to retrieve.</param>
	/// <returns>A byte array with the copied bytes.</returns>
	public byte[] GetBytes(int startIndex, int count);

	/// <summary>
	/// Extracts an array of structures of <typeparamref name="T"/> containing <paramref name="count"/> items. <note type="note">This
	/// call can cause memory exceptions if the pointer does not have sufficient allocated memory to retrieve all the structures.</note>
	/// </summary>
	/// <typeparam name="T">The type of the structures to retrieve.</typeparam>
	/// <param name="count">The number of structures to retrieve.</param>
	/// <param name="prefixBytes">The number of bytes to skip before reading the structures.</param>
	/// <returns>An array of structures of <typeparamref name="T"/>.</returns>
	T[] ToArray<T>(int count, int prefixBytes = 0);

	/// <summary>
	/// Extracts an enumeration of structures of <typeparamref name="T"/> containing <paramref name="count"/> items. <note
	/// type="note">This call can cause memory exceptions if the pointer does not have sufficient allocated memory to retrieve all the structures.</note>
	/// </summary>
	/// <typeparam name="T">The type of the structures to retrieve.</typeparam>
	/// <param name="count">The number of structures to retrieve.</param>
	/// <param name="prefixBytes">The number of bytes to skip before reading the structures.</param>
	/// <returns>An enumeration of structures of <typeparamref name="T"/>.</returns>
	IEnumerable<T> ToEnumerable<T>(int count, int prefixBytes = 0);

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
	string? ToString(int len, int prefixBytes, CharSet charSet = CharSet.Unicode);

	/// <summary>
	/// Gets an enumerated list of strings from a block of unmanaged memory where each string is separated by a single '\0' character
	/// and is terminated by two '\0' characters.
	/// </summary>
	/// <param name="charSet">The character set of the strings.</param>
	/// <param name="prefixBytes">Number of bytes preceding the array of string pointers.</param>
	/// <returns>Enumeration of strings.</returns>
	IEnumerable<string> ToStringEnum(CharSet charSet = CharSet.Auto, int prefixBytes = 0);

	/// <summary>
	/// Returns an enumeration of strings from memory where each string is pointed to by a preceding list of pointers of length
	/// <paramref name="count"/>.
	/// </summary>
	/// <param name="count">The count.</param>
	/// <param name="charSet">The character set of the strings.</param>
	/// <param name="prefixBytes">Number of bytes preceding the array of string pointers.</param>
	/// <returns>An enumerated list of strings.</returns>
	IEnumerable<string?> ToStringEnum(int count, CharSet charSet = CharSet.Auto, int prefixBytes = 0);

	/// <summary>
	/// Marshals data from this block of memory to a newly allocated managed object of the type specified by a generic type parameter.
	/// </summary>
	/// <typeparam name="T">The type of the object to which the data is to be copied. This must be a structure.</typeparam>
	/// <param name="prefixBytes">Number of bytes preceding the structure.</param>
	/// <returns>A managed object that contains the data that this <see cref="SafeMemoryHandleExt{T}"/> holds.</returns>
	T? ToStructure<T>(int prefixBytes = 0);
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
/// <seealso cref="SafeHandle"/>
public abstract class SafeAllocatedMemoryHandleBase : SafeHandle, IComparable<SafeAllocatedMemoryHandleBase>, IEquatable<SafeAllocatedMemoryHandleBase>
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
		int ret = Size.CompareTo(other.Size);
		if (ret != 0)
			return ret;

#if ALLOWSPAN
		var a = AsReadOnlySpan<byte>(Size);
		var b = other.AsReadOnlySpan<byte>(Size);
#else
		var a = GetBytes();
		var b = other.GetBytes(Size);
#endif
		for (int i = 0; i < Size; i++)
		{
			if ((ret = a[i].CompareTo(b[i])) != 0)
				return ret;
		}
		return ret;
	}

	/// <inheritdoc/>
	public bool Equals(SafeAllocatedMemoryHandleBase? other) => handle.Equals(other?.handle);

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
	/// <summary>Initializes a new instance of the <see cref="SafeAllocatedMemoryHandle"/> class.</summary>
	/// <param name="handle">The handle.</param>
	/// <param name="ownsHandle">if set to <c>true</c> if this class is responsible for freeing the memory on disposal.</param>
	protected SafeAllocatedMemoryHandle(IntPtr handle, bool ownsHandle) : base(handle, ownsHandle) { }

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
				if (value > sz)
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
	public void DangerousOverrideSize(SizeT newSize) => sz = newSize;

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
	/// <summary>
	/// Maintains reference to other SafeMemoryHandleExt objects, the pointer to which are referred to by this object. This is to ensure
	/// that such objects being referred to wouldn't be unreferenced until this object is active.
	/// </summary>
	private List<ISafeMemoryHandle>? references;

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
	/// Adds reference to other SafeMemoryHandle objects, the pointer to which are referred to by this object. This is to ensure that
	/// such objects being referred to wouldn't be unreferenced until this object is active. For e.g. when this object is an array of
	/// pointers to other objects
	/// </summary>
	/// <param name="children">Collection of SafeMemoryHandle objects referred to by this object.</param>
	public void AddSubReference(IEnumerable<ISafeMemoryHandle> children)
	{
		references ??= new List<ISafeMemoryHandle>();
		references.AddRange(children);
	}

	/// <summary>
	/// Adds reference to other SafeMemoryHandle objects, the pointer to which are referred to by this object. This is to ensure that
	/// such objects being referred to wouldn't be unreferenced until this object is active. For e.g. when this object is an array of
	/// pointers to other objects
	/// </summary>
	/// <param name="children">Collection of SafeMemoryHandle objects referred to by this object.</param>
	public void AddSubReference(params ISafeMemoryHandle[] children)
	{
		references ??= new List<ISafeMemoryHandle>();
		references.AddRange(children);
	}

	/// <summary>
	/// Extracts an array of structures of <typeparamref name="T"/> containing <paramref name="count"/> items. <note type="note">This
	/// call can cause memory exceptions if the pointer does not have sufficient allocated memory to retrieve all the structures.</note>
	/// </summary>
	/// <typeparam name="T">The type of the structures to retrieve.</typeparam>
	/// <param name="count">The number of structures to retrieve.</param>
	/// <param name="prefixBytes">The number of bytes to skip before reading the structures.</param>
	/// <returns>An array of structures of <typeparamref name="T"/>.</returns>
	public T[] ToArray<T>(int count, int prefixBytes = 0)
	{
		if (IsInvalid) return new T[0];
		//if (Size < Marshal.SizeOf(typeof(T)) * count + prefixBytes)
		//	throw new InsufficientMemoryException("Requested array is larger than the memory allocated.");
		//if (!typeof(T).IsBlittable()) throw new ArgumentException(@"Structure layout is not sequential or explicit.");
		//Debug.Assert(typeof(T).StructLayoutAttribute?.Value == LayoutKind.Sequential);
		return CallLocked(p => p.ToArray<T>(count, prefixBytes, sz)) ?? new T[0];
	}

	/// <summary>
	/// Extracts an enumeration of structures of <typeparamref name="T"/> containing <paramref name="count"/> items. <note
	/// type="note">This call can cause memory exceptions if the pointer does not have sufficient allocated memory to retrieve all the structures.</note>
	/// </summary>
	/// <typeparam name="T">The type of the structures to retrieve.</typeparam>
	/// <param name="count">The number of structures to retrieve.</param>
	/// <param name="prefixBytes">The number of bytes to skip before reading the structures.</param>
	/// <returns>An enumeration of structures of <typeparamref name="T"/>.</returns>
	public IEnumerable<T> ToEnumerable<T>(int count, int prefixBytes = 0)
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
	public string? ToString(int len, int prefixBytes, CharSet charSet = CharSet.Unicode)
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
	public IEnumerable<string?> ToStringEnum(int count, CharSet charSet = CharSet.Auto, int prefixBytes = 0) =>
		IsInvalid ? Enumerable.Empty<string?>() : CallLocked(p => p.ToStringEnum(count, charSet, prefixBytes, sz));

	/// <summary>
	/// Gets an enumerated list of strings from a block of unmanaged memory where each string is separated by a single '\0' character
	/// and is terminated by two '\0' characters.
	/// </summary>
	/// <param name="charSet">The character set of the strings.</param>
	/// <param name="prefixBytes">Number of bytes preceding the array of string pointers.</param>
	/// <returns>An enumerated list of strings.</returns>
	public IEnumerable<string> ToStringEnum(CharSet charSet = CharSet.Auto, int prefixBytes = 0) =>
		IsInvalid ? Enumerable.Empty<string>() : CallLocked(p => p.ToStringEnum(charSet, prefixBytes, sz));

	/// <summary>
	/// Marshals data from this block of memory to a newly allocated managed object of the type specified by a generic type parameter.
	/// </summary>
	/// <typeparam name="T">The type of the object to which the data is to be copied. This must be a structure.</typeparam>
	/// <param name="prefixBytes">Number of bytes preceding the structure.</param>
	/// <returns>A managed object that contains the data that this <see cref="SafeMemoryHandleExt{T}"/> holds.</returns>
	public T? ToStructure<T>(int prefixBytes = 0)
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
	public int Write<T>(IEnumerable<T> items, bool autoExtend = true, int offset = 0)
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
	public int Write<T>(in T value, bool autoExtend = true, int offset = 0) where T : struct
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
	public int Write(object value, bool autoExtend = true, int offset = 0)
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