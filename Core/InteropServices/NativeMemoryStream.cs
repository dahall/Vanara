using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Vanara.InteropServices;

/// <summary>A <see cref="Stream"/> derivative for working with unmanaged memory.</summary>
/// <seealso cref="Stream"/>
public class NativeMemoryStream : Stream
{
	private const long DefaultCapacity = 256;

	private readonly FileAccess access;
	private readonly long chunkSize = DefaultCapacity;
	private readonly SafeAllocatedMemoryHandle? hmem;
	private readonly List<Reference> references = new();
	private long capacity, length, position, preflushPos;

	/// <summary>Initializes a new instance of the <see cref="NativeMemoryStream"/> class.</summary>
	/// <param name="capacity">The initial capacity.</param>
	/// <param name="addCapacitySize">Size of additional blocks of memory to add when capacity is exceeded.</param>
	/// <param name="maxCapacity">The maximum capacity.</param>
	/// <param name="access">The mode of file access to the native memory stream.</param>
	public NativeMemoryStream(long capacity = DefaultCapacity, long addCapacitySize = DefaultCapacity, long maxCapacity = long.MaxValue, FileAccess access = FileAccess.ReadWrite) :
		this(new SafeCoTaskMemHandle((int)capacity), addCapacitySize, maxCapacity, access)
	{
	}

	/// <summary>Initializes a new instance of the <see cref="NativeMemoryStream"/> class.</summary>
	/// <param name="memoryAllocator">The memory allocator used to create and extend the native memory.</param>
	/// <param name="addCapacitySize">Size of additional blocks of memory to add when capacity is exceeded.</param>
	/// <param name="maxCapacity">The maximum capacity.</param>
	/// <param name="access">The mode of file access to the native memory stream.</param>
	/// <exception cref="ArgumentNullException">memoryAllocator</exception>
	public NativeMemoryStream(SafeAllocatedMemoryHandle memoryAllocator, long addCapacitySize = DefaultCapacity, long maxCapacity = long.MaxValue, FileAccess access = FileAccess.ReadWrite)
	{
		hmem = memoryAllocator ?? throw new ArgumentNullException(nameof(memoryAllocator));
		capacity = memoryAllocator.Size;
		Pointer = hmem.DangerousGetHandle();
		chunkSize = addCapacitySize;
		MaxCapacity = maxCapacity;
		this.access = access;
	}

	/// <summary>Initializes a new instance of the <see cref="NativeMemoryStream"/> class with a pointer and allows for dynamic growth.</summary>
	/// <param name="unmanagedPtr">The pointer to unmanaged, preallocated memory.</param>
	/// <param name="bytesAllocated">The bytes allocated to <paramref name="unmanagedPtr"/>.</param>
	/// <param name="access">The mode of file access to the native memory stream.</param>
	public NativeMemoryStream(IntPtr unmanagedPtr, long bytesAllocated, FileAccess access = FileAccess.Read)
	{
		this.access = access;
		chunkSize = 0;
		Pointer = unmanagedPtr;
		MaxCapacity = capacity = bytesAllocated;
	}

	/// <summary>Gets a value indicating whether the current stream supports reading.</summary>
	public override bool CanRead => !IsDisposed && access != FileAccess.Write;

	/// <summary>Gets a value indicating whether the current stream supports seeking.</summary>
	public override bool CanSeek => !IsDisposed;

	/// <summary>Gets a value indicating whether the current stream supports writing.</summary>
	public override bool CanWrite => !IsDisposed && access != FileAccess.Read;

	/// <summary>Gets or sets the capacity of the underlying buffer.</summary>
	/// <value>The capacity.</value>
	public virtual long Capacity
	{
		get => ThrowIfDisposed(capacity);
		protected set
		{
			ThrowIfDisposed();
			if (hmem is null)
				throw new InvalidOperationException("This constructed instance does not allow changing the capacity.");
			if (value < 0 || value > MaxCapacity || (!IsDisposed && value < Length))
				throw new ArgumentOutOfRangeException(nameof(value));
			if (capacity < value)
			{
				hmem.Size = (int)value;
				Pointer = hmem.DangerousGetHandle();
				capacity = value;
			}
		}
	}

	/// <summary>Gets or sets the character set used when processing strings.</summary>
	/// <value>The character set.</value>
	public CharSet CharSet { get; set; } = CharSet.Auto;

	/// <summary>Gets the length in bytes of the stream.</summary>
	public override long Length => ThrowIfDisposed(length);

	/// <summary>Gets or sets the maximum capacity.</summary>
	/// <value>The maximum capacity.</value>
	public long MaxCapacity { get; protected set; }

	/// <summary>Gets the pointer to the underlying buffer.</summary>
	public IntPtr Pointer { get; private set; }

	/// <summary>Gets or sets the position within the current stream.</summary>
	public override long Position
	{
		get => ThrowIfDisposed(position);
		set => Seek(value, SeekOrigin.Begin);
	}

	/// <summary>Gets the position PTR.</summary>
	/// <value>The position PTR.</value>
	protected IntPtr PositionPtr => Pointer.Offset(Position);

	private bool IsDisposed => Pointer == IntPtr.Zero || (hmem != null && hmem.IsClosed);

	/// <summary>Ensures the allocated buffer is large enough for the supplied capacity.</summary>
	/// <param name="value">The new capacity.</param>
	public virtual void EnsureCapacity(long value)
	{
		if (value < 0) throw new ArgumentOutOfRangeException(nameof(value));
		Debug.WriteLine($"EnsureCap({value}); Capacity={Capacity}; chunk={chunkSize}; max={MaxCapacity}");
		if (value <= Capacity) return;
		Capacity = capacity + Math.Max(value - capacity, chunkSize);
		Debug.WriteLine($">> NewCapacity={Capacity}");
	}

	/// <summary>Clears all buffers for this stream and causes any buffered data to be written to the underlying device.</summary>
	public override void Flush()
	{
		// Write all the reference values and capture offset
		preflushPos = Position;
		foreach (Reference r in references)
		{
			var prelen = length;
			r.WriteOffset = Position;
			WriteObject(r.Value);
			length = prelen;
		}

		// Write all the pointers to the reference values. This has to come later since WriteObject can reallocate memory.
		foreach (Reference r in references)
			Marshal.WriteIntPtr(Pointer.Offset(r.Offset), Pointer.Offset(r.WriteOffset));
	}

	/// <summary>
	/// Reads a sequence of bytes from the current stream and advances the position within the stream by the number of bytes read.
	/// </summary>
	/// <param name="buffer">
	/// An array of bytes. When this method returns, the buffer contains the specified byte array with the values between
	/// <paramref name="offset"/> and ( <paramref name="offset"/> + <paramref name="count"/> - 1) replaced by the bytes read from the
	/// current source.
	/// </param>
	/// <param name="offset">
	/// The zero-based byte offset in <paramref name="buffer"/> at which to begin storing the data read from the current stream.
	/// </param>
	/// <param name="count">The maximum number of bytes to be read from the current stream.</param>
	/// <returns>
	/// The total number of bytes read into the buffer. This can be less than the number of bytes requested if that many bytes are not
	/// currently available, or zero (0) if the end of the stream has been reached.
	/// </returns>
	/// <exception cref="ArgumentNullException">buffer</exception>
	/// <exception cref="ArgumentException"></exception>
	/// <exception cref="ArgumentOutOfRangeException"></exception>
	public override int Read(byte[] buffer, int offset, int count)
	{
		if (buffer == null) throw new ArgumentNullException(nameof(buffer));
		if (offset + count > buffer.Length) throw new ArgumentException("Offset plus count is greater than buffer length.");
		if (count < 0) throw new ArgumentOutOfRangeException(nameof(count));
		if (offset < 0) throw new ArgumentOutOfRangeException(nameof(offset));
		ThrowIfDisposed();
		if (!CanRead) throw new NotSupportedException();
		if (Position + count > Capacity) throw new ArgumentOutOfRangeException(nameof(count));
		if (count > 0)
		{
			Marshal.Copy(PositionPtr, buffer, offset, count);
			Position += count;
		}
		return count;
	}

	/// <summary>
	/// Reads a blittable type from the current stream and advances the position within the stream by the number of bytes read.
	/// </summary>
	/// <typeparam name="T">The type of the object to read.</typeparam>
	/// <param name="charSet">The character set.</param>
	/// <returns>An object of type <typeparamref name="T"/>.</returns>
	/// <exception cref="ArgumentException">Type to be read must be blittable. - T</exception>
	/// <exception cref="ArgumentOutOfRangeException"/>
	public T? Read<T>(CharSet charSet = CharSet.Auto) => (T?)Read(typeof(T), charSet);

	/// <summary>
	/// Reads a blittable type from the current stream and advances the position within the stream by the number of bytes read.
	/// </summary>
	/// <param name="typeToRead">The type of the object to read.</param>
	/// <param name="charSet">The character set.</param>
	/// <returns>An object of type <paramref name="typeToRead"/>.</returns>
	/// <exception cref="ArgumentException">Type to be read must be blittable. - T</exception>
	/// <exception cref="ArgumentOutOfRangeException"></exception>
	public object? Read(Type typeToRead, CharSet charSet = CharSet.Auto)
	{
		if (typeToRead == null) throw new ArgumentNullException(nameof(typeToRead));
		ThrowIfDisposed();
		if (!CanRead) throw new NotSupportedException();
		var ret = PositionPtr.Convert((uint)Capacity - (uint)Position, typeToRead, charSet);
		Position = position + GetSize(ret, charSet);
		return ret;
	}

	/// <summary>Reads the array.</summary>
	/// <typeparam name="T">Type of the array element.</typeparam>
	/// <param name="fsize">The number of elements in the array.</param>
	/// <param name="byRef">if set to <see langword="true"/>, get the values by reference.</param>
	/// <returns>An array of length <paramref name="fsize"/> with values of type <typeparamref name="T"/>.</returns>
	public IEnumerable<T> ReadArray<T>(int fsize, bool byRef) => ReadArray(typeof(T), fsize, byRef)?.Cast<T>() ?? Enumerable.Empty<T>();

	/// <summary>Reads the array.</summary>
	/// <param name="elemType">Type of the array element.</param>
	/// <param name="fsize">The number of elements in the array.</param>
	/// <param name="byRef">if set to <see langword="true"/>, get the values by reference.</param>
	/// <returns>An array of length <paramref name="fsize"/> with values of type <paramref name="elemType"/>.</returns>
	public Array? ReadArray(Type elemType, int fsize, bool byRef = false)
	{
		if (elemType == null) throw new ArgumentNullException(nameof(elemType));
		if (fsize < 0) throw new ArgumentOutOfRangeException(nameof(fsize));
		ThrowIfDisposed();
		if (!CanRead) throw new NotSupportedException();
		if (fsize == 0) return Array.CreateInstance(elemType, 0);
		var elemSize = elemType == typeof(string) || byRef ? IntPtr.Size : (int)InteropExtensions.SizeOf(elemType);
		var blockSize = elemSize * fsize;
		if (Position + blockSize > Capacity) throw new ArgumentOutOfRangeException();
		Array? ret;
		if (elemType == typeof(string))
		{
			if (byRef)
				ret = PositionPtr.ToStringEnum(fsize, CharSet).ToArray();
			else
			{
				ret = PositionPtr.ToStringEnum(CharSet).ToArray();
				if (ret?.GetLength(0) != fsize) throw new ArgumentOutOfRangeException(nameof(fsize));
				blockSize = GetSize(ret, CharSet);
			}
		}
		else
		{
			if (byRef)
			{
				ret = Array.CreateInstance(elemType, fsize);
				IntPtr[] ptrs = PositionPtr.ToArray<IntPtr>(fsize)!;
				for (var index = 0; index < ptrs.Length; index++)
				{
					var ptr = ptrs[index];
					ret.SetValue(ptr.Convert((uint)Capacity - (uint)Position, elemType, CharSet), index);
				}
			}
			else
				ret = PositionPtr.ToArray(elemType, fsize);
		}
		Position = position + blockSize;
		return ret;
	}

	/// <summary>
	/// Reads a type reference from the current stream and advances the position within the stream by the number of bytes read.
	/// </summary>
	/// <typeparam name="T">The type of the object to read.</typeparam>
	/// <param name="charSet">The character set.</param>
	/// <returns>An object of type <typeparamref name="T"/>.</returns>
	public T? ReadReference<T>(CharSet charSet = CharSet.Auto) => Read<IntPtr>().Convert<T>(uint.MaxValue, charSet == CharSet.Auto ? CharSet : charSet);

	/// <summary>
	/// Reads a blittable type from the current stream and advances the position within the stream by the number of bytes read.
	/// </summary>
	/// <typeparam name="T">The type of the object to read.</typeparam>
	/// <returns>An object of type <typeparamref name="T"/>.</returns>
	/// <exception cref="ArgumentException">Type to be read must be blittable. - T</exception>
	/// <exception cref="ArgumentOutOfRangeException"/>
	public T? ReadNullableReference<T>() where T : struct
	{
		var p = Read<IntPtr>();
		return p != IntPtr.Zero ? p.Convert<T>((uint)Capacity - (uint)Position, CharSet.Auto) : (T?)null;
	}

	/// <summary>Copies a specified number of bytes from the stream to a memory location.</summary>
	/// <param name="ptr">
	/// The pointer to the memory location that will recieve the bytes. The caller must ensure that sufficient memory has been allocated
	/// to this pointer.
	/// </param>
	/// <param name="bytesToRead">The number of bytes to read.</param>
	public void ReadToPtr(IntPtr ptr, long bytesToRead)
	{
		if (ptr == IntPtr.Zero) throw new ArgumentNullException(nameof(ptr));
		if (bytesToRead < 0) throw new ArgumentOutOfRangeException(nameof(bytesToRead));
		ThrowIfDisposed();
		if (!CanRead) throw new NotSupportedException();
		if (bytesToRead == 0) return;
		if (Position + bytesToRead > Capacity) throw new ArgumentOutOfRangeException(nameof(bytesToRead));
		PositionPtr.CopyTo(ptr, bytesToRead);
		Position = position + bytesToRead;
	}

	/// <summary>Sets the position within the current stream.</summary>
	/// <param name="offset">A byte offset relative to the <paramref name="origin"/> parameter.</param>
	/// <param name="origin">
	/// A value of type <see cref="T:System.IO.SeekOrigin"/> indicating the reference point used to obtain the new position.
	/// </param>
	/// <returns>The new position within the current stream.</returns>
	/// <exception cref="ArgumentException"></exception>
	public override long Seek(long offset, SeekOrigin origin)
	{
		ThrowIfDisposed();
		var startPos = origin == SeekOrigin.Begin ? 0L : (origin == SeekOrigin.Current ? Position : Capacity);
		var reqPos = startPos + offset;
		if (reqPos < 0 || reqPos > Capacity)
			throw new ArgumentException();
		return position = reqPos;
	}

	/// <summary>Sets the length of the current stream.</summary>
	/// <param name="value">The desired length of the current stream in bytes.</param>
	/// <exception cref="InvalidOperationException"></exception>
	public override void SetLength(long value)
	{
		if (value < 0) throw new ArgumentOutOfRangeException(nameof(value));
		ThrowIfDisposed();
		length = value;
		EnsureCapacity(value);
	}

	/// <summary>
	/// Writes a sequence of bytes to the current stream and advances the current position within this stream by the number of bytes written.
	/// </summary>
	/// <param name="buffer">
	/// An array of bytes. This method copies <paramref name="count"/> bytes from <paramref name="buffer"/> to the current stream.
	/// </param>
	/// <param name="offset">
	/// The zero-based byte offset in <paramref name="buffer"/> at which to begin copying bytes to the current stream.
	/// </param>
	/// <param name="count">The number of bytes to be written to the current stream.</param>
	/// <exception cref="ArgumentNullException">buffer</exception>
	/// <exception cref="ArgumentException"></exception>
	/// <exception cref="ArgumentOutOfRangeException"></exception>
	public override void Write(byte[] buffer, int offset, int count)
	{
		if (buffer == null) throw new ArgumentNullException(nameof(buffer));
		if (offset + count > buffer.Length) throw new ArgumentException();
		if (offset < 0) throw new ArgumentOutOfRangeException(nameof(offset));
		if (count < 0) throw new ArgumentOutOfRangeException(nameof(count));
		ThrowIfDisposed();
		if (access == FileAccess.Read) throw new NotSupportedException();
		EnsureCapacity(Position + count);
		Marshal.Copy(buffer, offset, PositionPtr, count);
		position += count;
		length += count;
	}

	/// <summary>Writes the specified value into the stream.</summary>
	/// <typeparam name="T">The type of the value.</typeparam>
	/// <param name="value">The value.</param>
	public void Write<T>(in T value) where T : struct => WriteObject(value);

	/// <summary>Writes the specified string into the stream.</summary>
	/// <param name="value">The string value.</param>
	/// <param name="charSetOverride">The character set override.</param>
	public void Write(string value, CharSet charSetOverride)
	{
		var bytes = value.GetBytes(true, charSetOverride);
		Write(bytes, 0, bytes.Length);
	}

	/// <summary>Writes the specified string into the stream.</summary>
	/// <param name="value">The string value.</param>
	public void Write(string value) => Write(value, CharSet);

	/// <summary>Writes the specified array into the stream.</summary>
	/// <param name="items">The items.</param>
	/// <param name="byRef">Write values as a referenced array.</param>
	public void Write(IEnumerable? items, bool byRef = false)
	{
		if (access == FileAccess.Read) throw new NotSupportedException();
		if (items == null) return;
		ResetIfFlushed();
		foreach (var i in items)
		{
			if (byRef)
				WriteReferenceObject(i);
			else
				WriteObject(i);
		}
	}

	/// <summary>Writes the specified array into the stream.</summary>
	/// <param name="items">The items.</param>
	/// <param name="method">The packing method for the strings.</param>
	public void Write(IEnumerable<string?> items, StringListPackMethod method = StringListPackMethod.Concatenated)
	{
		if (access == FileAccess.Read) throw new NotSupportedException();
		if (items == null) return;
		if (method == StringListPackMethod.Concatenated)
		{
			if (items.Any(s => s == null)) throw new ArgumentException("Cannot use Concatenated method with null strings.");
			items.MarshalToPtr(method, i => { EnsureCapacity(Position + i); return PositionPtr; }, out var sz, CharSet);
			position += sz;
			length += sz;
		}
		else
		{
			foreach (var s in items)
				WriteReference(s);
		}
	}

	/// <summary>Writes bytes from a memory location into the stream.</summary>
	/// <param name="ptr">
	/// The pointer to the memory location from which to retrieve the bytes to write. The caller must ensure that this memory location
	/// has at least <paramref name="bytesToWrite"/> of allocated memory.
	/// </param>
	/// <param name="bytesToWrite">The number of bytes to write from <paramref name="ptr"/>.</param>
	public void WriteFromPtr(IntPtr ptr, long bytesToWrite)
	{
		if (ptr == IntPtr.Zero) throw new ArgumentNullException(nameof(ptr));
		if (bytesToWrite < 0) throw new ArgumentOutOfRangeException(nameof(bytesToWrite));
		ThrowIfDisposed();
		if (access == FileAccess.Read) throw new NotSupportedException();
		EnsureCapacity(Position + bytesToWrite);
		ptr.CopyTo(PositionPtr, bytesToWrite);
		position += bytesToWrite;
		length += bytesToWrite;
	}

	/// <summary>Writes the specified value into the stream. This function should fail if the object cannot be blitted.</summary>
	/// <param name="value">The value to write.</param>
	public virtual void WriteObject(object? value)
	{
		if (access == FileAccess.Read) throw new NotSupportedException();
		if (value is null) return;
		if (value is string s)
			Write(s);
		else
		{
			ThrowIfDisposed();
			var stSize = GetSize(value, CharSet);
			EnsureCapacity(stSize + Position);
			//ResetIfFlushed();
			if (value is IntPtr p)
				Marshal.WriteIntPtr(PositionPtr, p);
			else
				stSize = InteropExtensions.WriteNoChecks(PositionPtr, value, 0, Capacity - Position);
			position += stSize;
			length += stSize;
		}
	}

	/// <summary>
	/// Writes a reference to the object (memory address as IntPtr) into the stream and then appends the object to the stream when closed
	/// or flushed.
	/// </summary>
	/// <param name="value">The value.</param>
	public void WriteReference<T>(T value) where T : unmanaged => WriteReferenceObject(value);

	/// <summary>
	/// Writes a reference to the object (memory address as IntPtr) into the stream and then appends the object to the stream when closed
	/// or flushed.
	/// </summary>
	/// <param name="value">The value.</param>
	public void WriteReference<T>(T? value) where T : unmanaged => WriteReferenceObject(value.HasValue ? value.Value : null);

	/// <summary>
	/// Writes a reference to the string (memory address as IntPtr) into the stream and then appends the string to the stream when closed
	/// or flushed.
	/// </summary>
	/// <param name="value">The string value.</param>
	public void WriteReference(string? value) => WriteReferenceObject(value);

	/// <summary>Writes the specified value into the stream. This function should fail if the object cannot be blitted.</summary>
	/// <param name="value">The value to write.</param>
	public virtual void WriteReferenceObject(object? value)
	{
		if (access == FileAccess.Read) throw new NotSupportedException();
		var sz = GetSize(value, CharSet);
		if (sz > 0)
		{
			EnsureCapacity(sz + IntPtr.Size + Length);
			length += sz;
			references.Add(new Reference(Position, value));
		}
		WriteObject(IntPtr.Zero);
	}

	/// <summary>
	/// Releases the unmanaged resources used by the <see cref="T:System.IO.Stream"/> and optionally releases the managed resources.
	/// </summary>
	/// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
	protected override void Dispose(bool disposing)
	{
		Pointer = IntPtr.Zero;
		base.Dispose(disposing);
	}

	/// <summary>Gets the size of the object in bytes.</summary>
	/// <param name="obj">The object to check.</param>
	/// <param name="charSet">The character set.</param>
	/// <returns>The size, in bytes, of the object.</returns>
	protected virtual int GetSize(object? obj, CharSet charSet = CharSet.None) =>
		InteropExtensions.SizeOf(obj, charSet);

	private int GetRefSize() => references.Sum(e => GetSize(e.Value, CharSet));

	private void ResetIfFlushed()
	{
		if (preflushPos == 0) return;
		position = preflushPos;
		Pointer.Offset(preflushPos).FillMemory(0, GetRefSize());
		preflushPos = 0;
	}

	private void ThrowIfDisposed()
	{
		if (IsDisposed) throw new ObjectDisposedException(nameof(NativeMemoryStream));
	}

	private T ThrowIfDisposed<T>(T value) => !IsDisposed ? value : throw new ObjectDisposedException(nameof(NativeMemoryStream));

	private class Reference
	{
		public long Offset, WriteOffset;
		public object? Value;

		public Reference(long offset, object? val)
		{
			Offset = offset; Value = val;
		}
	}
}