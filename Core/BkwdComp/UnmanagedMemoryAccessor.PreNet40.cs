#if NET20 || NET35
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;

namespace System.IO
{
	/// <inheritdoc />
	/// <summary>Provides random access to unmanaged blocks of memory from managed code.</summary>
	/// <seealso cref="T:System.IDisposable" />
	public class UnmanagedMemoryAccessor : IDisposable
	{
		private FileAccess access;
		[SecurityCritical]
		private SafeBuffer buffer;
		private bool canRead;
		private bool canWrite;
		private long offset;

		/// <summary>
		/// Initializes a new instance of the <see cref="UnmanagedMemoryAccessor"/> class with a specified buffer, offset, and capacity.
		/// </summary>
		/// <param name="buffer">The buffer to contain the accessor.</param>
		/// <param name="offset">The byte at which to start the accessor.</param>
		/// <param name="capacity">The size, in bytes, of memory to allocate.</param>
		[SecuritySafeCritical]
		public UnmanagedMemoryAccessor(SafeBuffer buffer, long offset, long capacity) => Initialize(buffer, offset, capacity, FileAccess.Read);

		/// <summary>
		/// Initializes a new instance of the <see cref="UnmanagedMemoryAccessor"/> class with a specified buffer, offset, capacity, and
		/// access right.
		/// </summary>
		/// <param name="buffer">The buffer to contain the accessor.</param>
		/// <param name="offset">The byte at which to start the accessor.</param>
		/// <param name="capacity">The size, in bytes, of memory to allocate.</param>
		/// <param name="access">The type of access allowed to the memory. The default is ReadWrite.</param>
		[SecuritySafeCritical]
		public UnmanagedMemoryAccessor(SafeBuffer buffer, long offset, long capacity, FileAccess access) => Initialize(buffer, offset, capacity, access);

		/// <summary>Initializes a new instance of the <see cref="UnmanagedMemoryAccessor"/> class.</summary>
		protected UnmanagedMemoryAccessor() => IsOpen = false;

		private unsafe delegate T AlignedPtrReadFunc<out T>(byte* ptr) where T : unmanaged;

		private unsafe delegate void AlignedPtrWriteFunc(byte* ptr);

		/// <summary>Determines whether the accessor is readable.</summary>
		/// <value><see langword="true"/> if the accessor is readable; otherwise, <see langword="false"/>.</value>
		public bool CanRead => IsOpen && canRead;

		/// <summary>Determines whether the accessory is writable.</summary>
		/// <value><see langword="true"/> if the accessor is writable; otherwise, <see langword="false"/>.</value>
		public bool CanWrite => IsOpen && canWrite;

		/// <summary>Gets the capacity of the accessor.</summary>
		/// <value>The capacity of the accessor.</value>
		[field: ContractPublicPropertyName("Capacity")]
		public long Capacity { get; private set; }

		/// <summary>Determines whether the accessor is currently open by a process.</summary>
		/// <value><see langword="true"/> if the accessor is open; otherwise, <see langword="false"/>.</value>
		protected bool IsOpen { get; private set; }

		/// <summary>Releases all resources used by the UnmanagedMemoryAccessor.</summary>
		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		/// <summary>Reads a structure of type <typeparamref name="T"/> from the accessor into a provided reference.</summary>
		/// <typeparam name="T">The type of structure.</typeparam>
		/// <param name="position">The position in the accessor at which to begin reading.</param>
		/// <param name="structure">The structure to contain the read data.</param>
		[SecurityCritical]
		public void Read<T>(long position, out T structure) where T : struct
		{
			if (position < 0)
				throw new ArgumentOutOfRangeException(nameof(position), ResourceHelper.GetString("ArgumentOutOfRange_NeedNonNegNum"));
			Contract.EndContractBlock();

			if (!IsOpen)
				throw new ObjectDisposedException("UnmanagedMemoryAccessor", ResourceHelper.GetString("ObjectDisposed_ViewAccessorClosed"));
			if (!CanRead)
				throw new NotSupportedException(ResourceHelper.GetString("NotSupported_Reading"));

			var sizeOfT = (uint)Marshal.SizeOf(typeof(T));
			if (position > Capacity - sizeOfT)
			{
				if (position >= Capacity)
					throw new ArgumentOutOfRangeException(nameof(position), ResourceHelper.GetString("ArgumentOutOfRange_PositionLessThanCapacityRequired"));
				throw new ArgumentException(ResourceHelper.GetString("Argument_NotEnoughBytesToRead", typeof(T).FullName), nameof(position));
			}

			structure = buffer.Read<T>((ulong)(offset + position));
		}

		/// <summary>Reads structures of type <typeparamref name="T"/> from the accessor into an array of type <typeparamref name="T"/>.</summary>
		/// <typeparam name="T">The type of structure.</typeparam>
		/// <param name="position">The number of bytes in the accessor at which to begin reading.</param>
		/// <param name="array">The array to contain the structures read from the accessor.</param>
		/// <param name="offset">The index in <paramref name="array"/> in which to place the first copied structure.</param>
		/// <param name="count">The number of structures of type <typeparamref name="T"/> to read from the accessor.</param>
		/// <returns>
		/// The number of structures read into <paramref name="array"/>. This value can be less than <paramref name="count"/> if there are
		/// fewer structures available, or zero if the end of the accessor is reached.
		/// </returns>
		[SecurityCritical]
		public int ReadArray<T>(long position, T[] array, int offset, int count) where T : struct
		{
			if (array == null)
				throw new ArgumentNullException(nameof(array), ResourceHelper.GetString("ArgumentNull_Buffer"));
			if (offset < 0)
				throw new ArgumentOutOfRangeException(nameof(offset), ResourceHelper.GetString("ArgumentOutOfRange_NeedNonNegNum"));
			if (count < 0)
				throw new ArgumentOutOfRangeException(nameof(count), ResourceHelper.GetString("ArgumentOutOfRange_NeedNonNegNum"));
			if (array.Length - offset < count)
				throw new ArgumentException(ResourceHelper.GetString("Argument_OffsetAndLengthOutOfBounds"));
			Contract.EndContractBlock();

			if (!CanRead)
			{
				if (!IsOpen)
					throw new ObjectDisposedException("UnmanagedMemoryAccessor", ResourceHelper.GetString("ObjectDisposed_ViewAccessorClosed"));
				throw new NotSupportedException(ResourceHelper.GetString("NotSupported_Reading"));
			}
			if (position < 0)
				throw new ArgumentOutOfRangeException(nameof(position), ResourceHelper.GetString("ArgumentOutOfRange_NeedNonNegNum"));

			var sizeOfT = (uint)Marshal.SizeOf(typeof(T));

			// only check position and ask for fewer Ts if count is too big
			if (position >= Capacity)
				throw new ArgumentOutOfRangeException(nameof(position), ResourceHelper.GetString("ArgumentOutOfRange_PositionLessThanCapacityRequired"));

			var n = count;
			var spaceLeft = Capacity - position;
			if (spaceLeft < 0)
			{
				n = 0;
			}
			else
			{
				var spaceNeeded = (ulong)(sizeOfT * count);
				if ((ulong)spaceLeft < spaceNeeded)
				{
					n = (int)(spaceLeft / sizeOfT);
				}
			}

			buffer.ReadArray((ulong)(this.offset + position), array, offset, n);
			return n;
		}

		/// <summary>Reads a Boolean value from the accessor.</summary>
		/// <param name="position">The number of bytes into the accessor at which to begin reading.</param>
		/// <returns><see langword="true"/> or <see langword="false"/>.</returns>
		public bool ReadBoolean(long position) => ReadByte(position) != 0;

		/// <summary>Reads a byte value from the accessor.</summary>
		/// <param name="position">The number of bytes into the accessor at which to begin reading.</param>
		/// <returns>The value that was read.</returns>
		public byte ReadByte(long position)
		{
			const int sizeOfType = sizeof(byte);
			EnsureSafeToRead(position, sizeOfType);

			return InternalReadByte(position);
		}

		/// <summary>Reads a character from the accessor.</summary>
		/// <param name="position">The number of bytes into the accessor at which to begin reading.</param>
		/// <returns>The value that was read.</returns>
		[SecuritySafeCritical]
		public char ReadChar(long position) { unsafe { return InternalRead(position, pointer => (char)(*pointer | *(pointer + 1) << 8)); } }

		/// <summary>Reads a decimal value from the accessor.</summary>
		/// <param name="position">The number of bytes into the accessor at which to begin reading.</param>
		/// <returns>The value that was read.</returns>
		[SecuritySafeCritical]
		public decimal ReadDecimal(long position)
		{
			const int sizeOfType = sizeof(decimal);
			EnsureSafeToRead(position, sizeOfType);

			var decimalArray = new int[4];
			ReadArray(position, decimalArray, 0, decimalArray.Length);
			return new decimal(decimalArray);
		}

		/// <summary>Reads a double-precision floating-point value from the accessor.</summary>
		/// <param name="position">The number of bytes into the accessor at which to begin reading.</param>
		/// <returns>The value that was read.</returns>
		[SecuritySafeCritical]
		public double ReadDouble(long position)
		{
			unsafe
			{
				return InternalRead(position, pointer =>
				{
					var lo = (uint) (*pointer | *(pointer + 1) << 8 | *(pointer + 2) << 16 | *(pointer + 3) << 24);
					var hi = (uint) (*(pointer + 4) | *(pointer + 5) << 8 | *(pointer + 6) << 16 | *(pointer + 7) << 24);
					var tempResult = (ulong)hi << 32 | lo;
					return *(double*) &tempResult;
				});
			}
		}

		/// <summary>Reads a 16-bit integer from the accessor.</summary>
		/// <param name="position">The number of bytes into the accessor at which to begin reading.</param>
		/// <returns>The value that was read.</returns>
		[SecuritySafeCritical]
		public short ReadInt16(long position) { unsafe { return InternalRead(position, pointer => (short)(*pointer | *(pointer + 1) << 8)); } }

		/// <summary>Reads a 32-bit integer from the accessor.</summary>
		/// <param name="position">The number of bytes into the accessor at which to begin reading.</param>
		/// <returns>The value that was read.</returns>
		[SecuritySafeCritical]
		public int ReadInt32(long position) { unsafe { return InternalRead(position, pointer => *pointer | *(pointer + 1) << 8 | *(pointer + 2) << 16 | *(pointer + 3) << 24); } }

		/// <summary>Reads a 64-bit integer from the accessor.</summary>
		/// <param name="position">The number of bytes into the accessor at which to begin reading.</param>
		/// <returns>The value that was read.</returns>
		[SecuritySafeCritical]
		public long ReadInt64(long position)
		{
			unsafe
			{
				return InternalRead(position, pointer =>
				{
					var lo = *pointer | *(pointer + 1) << 8 | *(pointer + 2) << 16 | *(pointer + 3) << 24;
					var hi = *(pointer + 4) | *(pointer + 5) << 8 | *(pointer + 6) << 16 | *(pointer + 7) << 24;
					return ((long)hi << 32) | (uint)lo;
				});
			}
		}

		/// <summary>Reads an 8-bit integer from the accessor.</summary>
		/// <param name="position">The number of bytes into the accessor at which to begin reading.</param>
		/// <returns>The value that was read.</returns>
		[SecuritySafeCritical]
		public sbyte ReadSByte(long position) => unchecked((sbyte)ReadByte(position));

		/// <summary>Reads a single-precision floating-point value from the accessor.</summary>
		/// <param name="position">The number of bytes into the accessor at which to begin reading.</param>
		/// <returns>The value that was read.</returns>
		[SecuritySafeCritical]
		public float ReadSingle(long position)
		{
			unsafe
			{
				return InternalRead(position, pointer =>
				{
					var tempResult = (uint)(*pointer | *(pointer + 1) << 8 | *(pointer + 2) << 16 | *(pointer + 3) << 24);
					return *(float*)&tempResult;
				});
			}
		}

		/// <summary>Reads an unsigned 16-bit integer from the accessor.</summary>
		/// <param name="position">The number of bytes into the accessor at which to begin reading.</param>
		/// <returns>The value that was read.</returns>
		[SecuritySafeCritical]
		public ushort ReadUInt16(long position) { unsafe { return InternalRead(position, pointer => (ushort)(*pointer | *(pointer + 1) << 8)); } }

		/// <summary>Reads an unsigned 32-bit integer from the accessor.</summary>
		/// <param name="position">The number of bytes into the accessor at which to begin reading.</param>
		/// <returns>The value that was read.</returns>
		[SecuritySafeCritical]
		public uint ReadUInt32(long position) { unsafe { return InternalRead(position, pointer => (uint)(*pointer | *(pointer + 1) << 8 | *(pointer + 2) << 16 | *(pointer + 3) << 24)); } }

		/// <summary>Reads an unsigned 64-bit integer from the accessor.</summary>
		/// <param name="position">The number of bytes into the accessor at which to begin reading.</param>
		/// <returns>The value that was read.</returns>
		[SecuritySafeCritical]
		public ulong ReadUInt64(long position)
		{
			unsafe
			{
				return InternalRead(position, pointer =>
				{
					var lo = (uint)(*pointer | *(pointer + 1) << 8 | *(pointer + 2) << 16 | *(pointer + 3) << 24);
					var hi = (uint)(*(pointer + 4) | *(pointer + 5) << 8 | *(pointer + 6) << 16 | *(pointer + 7) << 24);
					return ((ulong)hi << 32) | lo;
				});
			}
		}

		/// <summary>Writes a Boolean value into the accessor.</summary>
		/// <param name="position">The number of bytes into the accessor at which to begin writing.</param>
		/// <param name="value">The value to write.</param>
		public void Write(long position, bool value) => Write(position, (byte)(value ? 1 : 0));

		/// <summary>Writes a byte value into the accessor.</summary>
		/// <param name="position">The number of bytes into the accessor at which to begin writing.</param>
		/// <param name="value">The value to write.</param>
		public void Write(long position, byte value)
		{
			const int sizeOfType = sizeof(byte);
			EnsureSafeToWrite(position, sizeOfType);

			InternalWriteByte(position, value);
		}

		/// <summary>Writes a character into the accessor.</summary>
		/// <param name="position">The number of bytes into the accessor at which to begin writing.</param>
		/// <param name="value">The value to write.</param>
		[SecuritySafeCritical]
		public void Write(long position, char value)
		{
			unsafe
			{
				InternalWrite(position, value, pointer =>
				{
					*pointer = (byte)value;
					*(pointer + 1) = (byte)(value >> 8);
				});
			}
		}

		/// <summary>Writes a 16-bit integer into the accessor.</summary>
		/// <param name="position">The number of bytes into the accessor at which to begin writing.</param>
		/// <param name="value">The value to write.</param>
		[SecuritySafeCritical]
		public void Write(long position, short value)
		{
			unsafe
			{
				InternalWrite(position, value, pointer =>
				{
					*pointer = (byte)value;
					*(pointer + 1) = (byte)(value >> 8);
				});
			}
		}

		/// <summary>Writes a 32-bit integer into the accessor.</summary>
		/// <param name="position">The number of bytes into the accessor at which to begin writing.</param>
		/// <param name="value">The value to write.</param>
		[SecuritySafeCritical]
		public void Write(long position, int value)
		{
			unsafe
			{
				InternalWrite(position, value, pointer =>
				{
					*pointer = (byte)value;
					*(pointer + 1) = (byte)(value >> 8);
					*(pointer + 2) = (byte)(value >> 16);
					*(pointer + 3) = (byte)(value >> 24);
				});
			}
		}

		/// <summary>Writes a 64-bit integer into the accessor.</summary>
		/// <param name="position">The number of bytes into the accessor at which to begin writing.</param>
		/// <param name="value">The value to write.</param>
		[SecuritySafeCritical]
		public void Write(long position, long value)
		{
			unsafe
			{
				InternalWrite(position, value, pointer =>
				{
					*pointer = (byte)value;
					*(pointer + 1) = (byte)(value >> 8);
					*(pointer + 2) = (byte)(value >> 16);
					*(pointer + 3) = (byte)(value >> 24);
					*(pointer + 4) = (byte)(value >> 32);
					*(pointer + 5) = (byte)(value >> 40);
					*(pointer + 6) = (byte)(value >> 48);
					*(pointer + 7) = (byte)(value >> 56);
				});
			}
		}

		/// <summary>Writes a decimal value into the accessor.</summary>
		/// <param name="position">The number of bytes into the accessor at which to begin writing.</param>
		/// <param name="value">The value to write.</param>
		[SecuritySafeCritical]
		public void Write(long position, decimal value)
		{
			const int sizeOfType = sizeof(decimal);
			EnsureSafeToWrite(position, sizeOfType);

			var decimalArray = new byte[16];
			GetDecimalBytes(value, decimalArray);

			var bits = new int[4];
			var flags = decimalArray[12] | (decimalArray[13] << 8) | (decimalArray[14] << 16) | (decimalArray[15] << 24);
			var lo = decimalArray[0] | (decimalArray[1] << 8) | (decimalArray[2] << 16) | (decimalArray[3] << 24);
			var mid = decimalArray[4] | (decimalArray[5] << 8) | (decimalArray[6] << 16) | (decimalArray[7] << 24);
			var hi = decimalArray[8] | (decimalArray[9] << 8) | (decimalArray[10] << 16) | (decimalArray[11] << 24);
			bits[0] = lo;
			bits[1] = mid;
			bits[2] = hi;
			bits[3] = flags;

			WriteArray(position, bits, 0, bits.Length);
		}

		/// <summary>Writes a Single into the accessor.</summary>
		/// <param name="position">The number of bytes into the accessor at which to begin writing.</param>
		/// <param name="value">The value to write.</param>
		[SecuritySafeCritical]
		public void Write(long position, float value)
		{
			unsafe
			{
				InternalWrite(position, value, pointer =>
				{
					var lValue = value;
					var tmpValue = *(uint*)&lValue;
					*pointer = (byte)tmpValue;
					*(pointer + 1) = (byte)(tmpValue >> 8);
					*(pointer + 2) = (byte)(tmpValue >> 16);
					*(pointer + 3) = (byte)(tmpValue >> 24);
				});
			}
		}

		/// <summary>Writes a Double into the accessor.</summary>
		/// <param name="position">The number of bytes into the accessor at which to begin writing.</param>
		/// <param name="value">The value to write.</param>
		[SecuritySafeCritical]
		public void Write(long position, double value)
		{
			unsafe
			{
				InternalWrite(position, value, pointer =>
				{
					var lValue = value;
					var tmpValue = *(ulong*)&lValue;
					*pointer = (byte)tmpValue;
					*(pointer + 1) = (byte)(tmpValue >> 8);
					*(pointer + 2) = (byte)(tmpValue >> 16);
					*(pointer + 3) = (byte)(tmpValue >> 24);
					*(pointer + 4) = (byte)(tmpValue >> 32);
					*(pointer + 5) = (byte)(tmpValue >> 40);
					*(pointer + 6) = (byte)(tmpValue >> 48);
					*(pointer + 7) = (byte)(tmpValue >> 56);
				});
			}
		}

		/// <summary>Writes an unsigned 8-bit integer into the accessor.</summary>
		/// <param name="position">The number of bytes into the accessor at which to begin writing.</param>
		/// <param name="value">The value to write.</param>
		[SecuritySafeCritical]
		public void Write(long position, sbyte value) => Write(position, unchecked((byte)value));

		/// <summary>Writes an unsigned 16-bit integer into the accessor.</summary>
		/// <param name="position">The number of bytes into the accessor at which to begin writing.</param>
		/// <param name="value">The value to write.</param>
		[SecuritySafeCritical]
		public void Write(long position, ushort value)
		{
			unsafe
			{
				InternalWrite(position, value, pointer =>
				{
					*pointer = (byte)value;
					*(pointer + 1) = (byte)(value >> 8);
				});
			}
		}

		/// <summary>Writes an unsigned 32-bit integer into the accessor.</summary>
		/// <param name="position">The number of bytes into the accessor at which to begin writing.</param>
		/// <param name="value">The value to write.</param>
		[SecuritySafeCritical]
		public void Write(long position, uint value)
		{
			unsafe
			{
				InternalWrite(position, value, pointer =>
				{
					*pointer = (byte)value;
					*(pointer + 1) = (byte)(value >> 8);
					*(pointer + 2) = (byte)(value >> 16);
					*(pointer + 3) = (byte)(value >> 24);
				});
			}
		}

		/// <summary>Writes an unsigned 64-bit integer into the accessor.</summary>
		/// <param name="position">The number of bytes into the accessor at which to begin writing.</param>
		/// <param name="value">The value to write.</param>
		[SecuritySafeCritical]
		public void Write(long position, ulong value)
		{
			unsafe
			{
				InternalWrite(position, value, pointer =>
				{
					*pointer = (byte)value;
					*(pointer + 1) = (byte)(value >> 8);
					*(pointer + 2) = (byte)(value >> 16);
					*(pointer + 3) = (byte)(value >> 24);
					*(pointer + 4) = (byte)(value >> 32);
					*(pointer + 5) = (byte)(value >> 40);
					*(pointer + 6) = (byte)(value >> 48);
					*(pointer + 7) = (byte)(value >> 56);
				});
			}
		}

		/// <summary>Writes a structure into the accessor.</summary>
		/// <param name="position">The number of bytes into the accessor at which to begin writing.</param>
		/// <param name="structure">The structure to write.</param>
		[SecurityCritical]
		public void Write<T>(long position, ref T structure) where T : struct
		{
			if (position < 0)
				throw new ArgumentOutOfRangeException(nameof(position), ResourceHelper.GetString("ArgumentOutOfRange_NeedNonNegNum"));
			Contract.EndContractBlock();

			if (!IsOpen)
				throw new ObjectDisposedException("UnmanagedMemoryAccessor", ResourceHelper.GetString("ObjectDisposed_ViewAccessorClosed"));
			if (!CanWrite)
				throw new NotSupportedException(ResourceHelper.GetString("NotSupported_Writing"));

			var sizeOfT = (uint)Marshal.SizeOf(typeof(T));
			if (position > Capacity - sizeOfT)
			{
				if (position >= Capacity)
					throw new ArgumentOutOfRangeException(nameof(position), ResourceHelper.GetString("ArgumentOutOfRange_PositionLessThanCapacityRequired"));
				throw new ArgumentException(ResourceHelper.GetString("Argument_NotEnoughBytesToWrite", typeof(T).FullName), nameof(position));
			}

			buffer.Write((ulong)(offset + position), structure);
		}

		/// <summary>Writes structures from an array of type <typeparamref name="T"/> into the accessor.</summary>
		/// <typeparam name="T">The type of structure.</typeparam>
		/// <param name="position">The number of bytes into the accessor at which to begin writing.</param>
		/// <param name="array">The array to write into the accessor.</param>
		/// <param name="offset">The index in <paramref name="array"/> to start writing from.</param>
		/// <param name="count">The number of structures in <paramref name="array"/> to write.</param>
		[SecurityCritical]
		public void WriteArray<T>(long position, T[] array, int offset, int count) where T : struct
		{
			if (array == null)
				throw new ArgumentNullException(nameof(array), ResourceHelper.GetString("ArgumentNull_Buffer"));
			if (offset < 0)
				throw new ArgumentOutOfRangeException(nameof(offset), ResourceHelper.GetString("ArgumentOutOfRange_NeedNonNegNum"));
			if (count < 0)
				throw new ArgumentOutOfRangeException(nameof(count), ResourceHelper.GetString("ArgumentOutOfRange_NeedNonNegNum"));
			if (array.Length - offset < count)
				throw new ArgumentException(ResourceHelper.GetString("Argument_OffsetAndLengthOutOfBounds"));
			if (position < 0)
				throw new ArgumentOutOfRangeException(nameof(position), ResourceHelper.GetString("ArgumentOutOfRange_NeedNonNegNum"));
			if (position >= Capacity)
				throw new ArgumentOutOfRangeException(nameof(position), ResourceHelper.GetString("ArgumentOutOfRange_PositionLessThanCapacityRequired"));
			Contract.EndContractBlock();

			if (!IsOpen)
				throw new ObjectDisposedException("UnmanagedMemoryAccessor", ResourceHelper.GetString("ObjectDisposed_ViewAccessorClosed"));
			if (!CanWrite)
				throw new NotSupportedException(ResourceHelper.GetString("NotSupported_Writing"));

			buffer.WriteArray((ulong)(this.offset + position), array, offset, count);
		}

		internal static void GetDecimalBytes(decimal d, byte[] buffer)
		{
			Contract.Requires(buffer != null && buffer.Length >= 16, "[GetBytes]buffer != null && buffer.Length >= 16");
			Buffer.BlockCopy(decimal.GetBits(d), 0, buffer, 0, buffer.Length);
		}

		/// <summary>Releases the unmanaged resources used by the UnmanagedMemoryAccessor and optionally releases the managed resources.</summary>
		/// <param name="disposing">
		/// <see langword="true"/> to release both managed and unmanaged resources; <see langword="false"/> to release only unmanaged resources.
		/// </param>
		protected virtual void Dispose(bool disposing) => IsOpen = false;

		/// <summary>Sets the initial values for the accessor.</summary>
		/// <param name="buffer">The buffer to contain the accessor.</param>
		/// <param name="offset">The byte at which to start the accessor.</param>
		/// <param name="capacity">The size, in bytes, of memory to allocate.</param>
		/// <param name="access">The type of access allowed to the memory. The default is ReadWrite.</param>
		[SecuritySafeCritical]
		[SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.UnmanagedCode)]
		protected void Initialize(SafeBuffer buffer, long offset, long capacity, FileAccess access)
		{
			if (buffer == null)
				throw new ArgumentNullException(nameof(buffer));
			if (offset < 0)
				throw new ArgumentOutOfRangeException(nameof(offset), ResourceHelper.GetString("ArgumentOutOfRange_NeedNonNegNum"));
			if (capacity < 0)
				throw new ArgumentOutOfRangeException(nameof(capacity), ResourceHelper.GetString("ArgumentOutOfRange_NeedNonNegNum"));
			if (buffer.ByteLength < (ulong)(offset + capacity))
				throw new ArgumentException(ResourceHelper.GetString("Argument_OffsetAndCapacityOutOfBounds"));
			if (access < FileAccess.Read || access > FileAccess.ReadWrite)
				throw new ArgumentOutOfRangeException(nameof(access));
			Contract.EndContractBlock();

			if (IsOpen)
				throw new InvalidOperationException(ResourceHelper.GetString("InvalidOperation_CalledTwice"));

			unsafe
			{
				byte* pointer = null;
				RuntimeHelpers.PrepareConstrainedRegions();
				try
				{
					buffer.AcquirePointer(ref pointer);
					if ((byte*)((long)pointer + offset + capacity) < pointer)
					{
						throw new ArgumentException(ResourceHelper.GetString("Argument_UnmanagedMemAccessorWrapAround"));
					}
				}
				finally
				{
					if (pointer != null)
					{
						buffer.ReleasePointer();
					}
				}
			}

			this.offset = offset;
			this.buffer = buffer;
			this.Capacity = capacity;
			this.access = access;
			IsOpen = true;
			canRead = (this.access & FileAccess.Read) != 0;
			canWrite = (this.access & FileAccess.Write) != 0;
		}

		private void EnsureSafeToRead(long position, int sizeOfType)
		{
			if (!IsOpen)
				throw new ObjectDisposedException("UnmanagedMemoryAccessor", ResourceHelper.GetString("ObjectDisposed_ViewAccessorClosed"));
			if (!CanRead)
				throw new NotSupportedException(ResourceHelper.GetString("NotSupported_Reading"));
			if (position < 0)
				throw new ArgumentOutOfRangeException(nameof(position), ResourceHelper.GetString("ArgumentOutOfRange_NeedNonNegNum"));
			Contract.EndContractBlock();
			if (position <= Capacity - sizeOfType) return;
			if (position >= Capacity)
				throw new ArgumentOutOfRangeException(nameof(position), ResourceHelper.GetString("ArgumentOutOfRange_PositionLessThanCapacityRequired"));
			throw new ArgumentException(ResourceHelper.GetString("Argument_NotEnoughBytesToRead"), nameof(position));
		}

		private void EnsureSafeToWrite(long position, int sizeOfType)
		{
			if (!IsOpen)
				throw new ObjectDisposedException("UnmanagedMemoryAccessor", ResourceHelper.GetString("ObjectDisposed_ViewAccessorClosed"));
			if (!CanWrite)
				throw new NotSupportedException(ResourceHelper.GetString("NotSupported_Writing"));
			if (position < 0)
				throw new ArgumentOutOfRangeException(nameof(position), ResourceHelper.GetString("ArgumentOutOfRange_NeedNonNegNum"));
			Contract.EndContractBlock();
			if (position > Capacity - sizeOfType)
			{
				if (position >= Capacity)
					throw new ArgumentOutOfRangeException(nameof(position), ResourceHelper.GetString("ArgumentOutOfRange_PositionLessThanCapacityRequired"));
				throw new ArgumentException(ResourceHelper.GetString("Argument_NotEnoughBytesToWrite", "Byte"), nameof(position));
			}
		}

		private unsafe T InternalRead<T>(long position, AlignedPtrReadFunc<T> func) where T : unmanaged, IConvertible
		{
			var sizeOfType = sizeof(T);
			EnsureSafeToRead(position, sizeOfType);

			T result;

			byte* pointer = null;
			RuntimeHelpers.PrepareConstrainedRegions();
			try
			{
				buffer.AcquirePointer(ref pointer);
				pointer += offset + position;

#if ALIGN_ACCESS
				// check if pointer is aligned
				if (((int)pointer & (sizeOfType - 1)) == 0)
				{
#endif
					result = *(T*)pointer;
#if ALIGN_ACCESS
				}
				else
				{
					result = func(pointer);
				}
#endif
			}
			finally
			{
				if (pointer != null)
				{
					buffer.ReleasePointer();
				}
			}

			return result;
		}

		[SecuritySafeCritical]
		private byte InternalReadByte(long position)
		{
			Contract.Assert(CanRead, "UMA not readable");
			Contract.Assert(position >= 0, "position less than 0");
			Contract.Assert(position <= Capacity - sizeof(byte), "position is greater than capacity - sizeof(byte)");

			byte result;
			unsafe
			{
				byte* pointer = null;
				RuntimeHelpers.PrepareConstrainedRegions();
				try
				{
					buffer.AcquirePointer(ref pointer);
					result = *(pointer + offset + position);
				}
				finally
				{
					if (pointer != null)
					{
						buffer.ReleasePointer();
					}
				}
			}
			return result;
		}

		[SecuritySafeCritical]
		private unsafe void InternalWrite<T>(long position, T value, AlignedPtrWriteFunc func) where T : unmanaged, IConvertible
		{
			var sizeOfType = sizeof(T);
			EnsureSafeToWrite(position, sizeOfType);

			byte* pointer = null;
			RuntimeHelpers.PrepareConstrainedRegions();
			try
			{
				buffer.AcquirePointer(ref pointer);
				pointer += offset + position;
#if ALIGN_ACCESS
				// check if pointer is aligned
				if (((int)pointer & (sizeOfType - 1)) == 0)
				{
#endif
					*(T*)pointer = value;
#if ALIGN_ACCESS
				}
				else
				{
					func(pointer);
				}
#endif
			}
			finally
			{
				if (pointer != null)
				{
					buffer.ReleasePointer();
				}
			}
		}

		[SecuritySafeCritical]
		private void InternalWriteByte(long position, byte value)
		{
			Contract.Assert(CanWrite, "UMA not writable");
			Contract.Assert(position >= 0, "position less than 0");
			Contract.Assert(position <= Capacity - sizeof(byte), "position is greater than capacity - sizeof(byte)");

			unsafe
			{
				byte* pointer = null;
				RuntimeHelpers.PrepareConstrainedRegions();
				try
				{
					buffer.AcquirePointer(ref pointer);
					*(pointer + offset + position) = value;
				}
				finally
				{
					if (pointer != null)
					{
						buffer.ReleasePointer();
					}
				}
			}
		}
	}
}
#endif