#if NET20 || NET35
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Threading;
using System.Threading.Tasks;
using Vanara.Extensions;

namespace System.IO
{
	/// <summary>Provides access to unmanaged blocks of memory from managed code.</summary>
	/// <seealso cref="System.IO.Stream"/>
	public class UnmanagedMemoryStream : Stream
	{
		internal bool _isOpen;
		private FileAccess _access;

		[SecurityCritical] // auto-generated
		private SafeBuffer _buffer;

		private long _capacity;

		[NonSerialized]
		private Task<int> _lastReadTask;

		private long _length;

		[SecurityCritical]
		private unsafe byte* _mem;

		private long _offset;
		private long _position;

		/// <summary>
		/// Initializes a new instance of the <see cref="UnmanagedMemoryStream"/> class in a safe buffer with a specified offset and length..
		/// </summary>
		/// <param name="buffer">The buffer to contain the unmanaged memory stream.</param>
		/// <param name="offset">The byte position in the buffer at which to start the unmanaged memory stream.</param>
		/// <param name="length">The length of the unmanaged memory stream.</param>
		[SecuritySafeCritical]
		public UnmanagedMemoryStream(SafeBuffer buffer, long offset, long length) => Initialize(buffer, offset, length, FileAccess.Read, false);

		/// <summary>
		/// Initializes a new instance of the <see cref="UnmanagedMemoryStream"/> class in a safe buffer with a specified offset, length, and
		/// file access.
		/// </summary>
		/// <param name="buffer">The buffer to contain the unmanaged memory stream.</param>
		/// <param name="offset">The byte position in the buffer at which to start the unmanaged memory stream.</param>
		/// <param name="length">The length of the unmanaged memory stream.</param>
		/// <param name="access">The mode of file access to the unmanaged memory stream.</param>
		[SecuritySafeCritical]
		public UnmanagedMemoryStream(SafeBuffer buffer, long offset, long length, FileAccess access) => Initialize(buffer, offset, length, access, false);

		/// <summary>
		/// Initializes a new instance of the <see cref="UnmanagedMemoryStream"/> class using the specified location and memory length.
		/// </summary>
		/// <param name="pointer">A pointer to an unmanaged memory location.</param>
		/// <param name="length">The length of the memory to use.</param>
		[SecurityCritical]
		public unsafe UnmanagedMemoryStream(byte* pointer, long length) => Initialize(pointer, length, length, FileAccess.Read, false);

		/// <summary>
		/// Initializes a new instance of the <see cref="UnmanagedMemoryStream"/> class using the specified location, memory length, total
		/// amount of memory, and file access values.
		/// </summary>
		/// <param name="pointer">A pointer to an unmanaged memory location.</param>
		/// <param name="length">The length of the memory to use.</param>
		/// <param name="capacity">The total amount of memory assigned to the stream.</param>
		/// <param name="access">One of the <see cref="FileAccess"/> values.</param>
		[SecurityCritical]
		public unsafe UnmanagedMemoryStream(byte* pointer, long length, long capacity, FileAccess access) => Initialize(pointer, length, capacity, access, false);

		[SecurityCritical]
		internal UnmanagedMemoryStream(SafeBuffer buffer, long offset, long length, FileAccess access, bool skipSecurityCheck) => Initialize(buffer, offset, length, access, skipSecurityCheck);

		[SecurityCritical]
		internal unsafe UnmanagedMemoryStream(byte* pointer, long length, long capacity, FileAccess access, bool skipSecurityCheck) => Initialize(pointer, length, capacity, access, skipSecurityCheck);

		/// <summary>Initializes a new instance of the <see cref="UnmanagedMemoryStream"/> class.</summary>
		[SecuritySafeCritical]
		protected UnmanagedMemoryStream()
		{
			unsafe
			{
				_mem = null;
			}
			_isOpen = false;
		}

		/// <summary>Gets a value indicating whether a stream supports reading.</summary>
		public override bool CanRead
		{
			[Pure]
			get => _isOpen && (_access & FileAccess.Read) != 0;
		}

		/// <summary>Gets a value indicating whether a stream supports seeking.</summary>
		public override bool CanSeek
		{
			[Pure]
			get => _isOpen;
		}

		/// <summary>Gets a value indicating whether a stream supports writing.</summary>
		public override bool CanWrite
		{
			[Pure]
			get => _isOpen && (_access & FileAccess.Write) != 0;
		}

		/// <summary>Gets the stream length (size) or the total amount of memory assigned to a stream (capacity).</summary>
		/// <value>The size or capacity of the stream.</value>
		public long Capacity
		{
			get
			{
				if (!_isOpen) ErrorStreamIsClosed();
				return _capacity;
			}
		}

		/// <summary>Gets the length of the data in a stream.</summary>
		/// <value>The length of the data in the stream.</value>
		public override long Length
		{
			get
			{
				if (!_isOpen) ErrorStreamIsClosed();
				return Interlocked.Read(ref _length);
			}
		}

		/// <summary>Gets or sets the position within the current stream.</summary>
		public override long Position
		{
			get
			{
				if (!CanSeek) ErrorStreamIsClosed();
				Contract.EndContractBlock();
				return Interlocked.Read(ref _position);
			}
			[SecuritySafeCritical]
			set
			{
				if (value < 0)
					throw new ArgumentOutOfRangeException(nameof(value), ResourceHelper.GetString("ArgumentOutOfRange_NeedNonNegNum"));
				Contract.EndContractBlock();
				if (!CanSeek) ErrorStreamIsClosed();

				unsafe
				{
					// On 32 bit machines, ensure we don't wrap around.
					if (value > int.MaxValue || _mem + value < _mem)
						throw new ArgumentOutOfRangeException(nameof(value), ResourceHelper.GetString("ArgumentOutOfRange_StreamLength"));
				}

				Interlocked.Exchange(ref _position, value);
			}
		}

		/// <summary>Gets or sets a byte pointer to a stream based on the current position in the stream.</summary>
		/// <value>A byte pointer.</value>
		public unsafe byte* PositionPointer
		{
			[SecurityCritical]  // auto-generated_required
			get
			{
				if (_buffer != null)
				{
					throw new NotSupportedException(ResourceHelper.GetString("NotSupported_UmsSafeBuffer"));
				}

				// Use a temp to avoid a race
				var pos = Interlocked.Read(ref _position);
				if (pos > _capacity)
					throw new IndexOutOfRangeException(ResourceHelper.GetString("IndexOutOfRange_UMSPosition"));
				var ptr = _mem + pos;
				if (!_isOpen) ErrorStreamIsClosed();
				return ptr;
			}
			[SecurityCritical]  // auto-generated_required
			set
			{
				if (_buffer != null)
					throw new NotSupportedException(ResourceHelper.GetString("NotSupported_UmsSafeBuffer"));
				if (!_isOpen) ErrorStreamIsClosed();

				if (value < _mem)
					throw new IOException(ResourceHelper.GetString("IO.IO_SeekBeforeBegin"));

				Interlocked.Exchange(ref _position, value - _mem);
			}
		}

		internal unsafe byte* Pointer
		{
			[SecurityCritical]
			get
			{
				if (_buffer != null)
					throw new NotSupportedException(ResourceHelper.GetString("NotSupported_UmsSafeBuffer"));

				return _mem;
			}
		}

		/// <summary>Clears all buffers for this stream and causes any buffered data to be written to the underlying device.</summary>
		public override void Flush()
		{
			if (!_isOpen) ErrorStreamIsClosed();
		}

		/// <summary>
		/// Asynchronously clears all buffers for this stream, causes any buffered data to be written to the underlying device, and monitors
		/// cancellation requests.
		/// </summary>
		/// <param name="cancellationToken">The token to monitor for cancellation requests. The default value is None.</param>
		/// <returns>A task that represents the asynchronous flush operation.</returns>
		[HostProtection(ExternalThreading = true)]
		[ComVisible(false)]
		public virtual Task FlushAsync(CancellationToken cancellationToken)
		{
			if (cancellationToken.IsCancellationRequested)
				return Task.FromCanceled(cancellationToken);

			try
			{
				Flush();
				return Task.CompletedTask;
			}
			catch (Exception ex)
			{
				return Task.FromException(ex);
			}
		}

		/// <summary>
		/// When overridden in a derived class, reads a sequence of bytes from the current stream and advances the position within the stream
		/// by the number of bytes read.
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
		[SecuritySafeCritical]
		public override int Read([In, Out] byte[] buffer, int offset, int count)
		{
			if (buffer == null)
				throw new ArgumentNullException(nameof(buffer), ResourceHelper.GetString("ArgumentNull_Buffer"));
			if (offset < 0)
				throw new ArgumentOutOfRangeException(nameof(offset), ResourceHelper.GetString("ArgumentOutOfRange_NeedNonNegNum"));
			if (count < 0)
				throw new ArgumentOutOfRangeException(nameof(count), ResourceHelper.GetString("ArgumentOutOfRange_NeedNonNegNum"));
			if (buffer.Length - offset < count)
				throw new ArgumentException(ResourceHelper.GetString("Argument_InvalidOffLen"));
			Contract.EndContractBlock();  // Keep this in sync with contract validation in ReadAsync

			if (!_isOpen) ErrorStreamIsClosed();
			if (!CanRead) ErrorReadNotSupported();

			// Use a local variable to avoid a race where another thread changes our position after we decide we can read some bytes.
			var pos = Interlocked.Read(ref _position);
			var len = Interlocked.Read(ref _length);
			var n = len - pos;
			if (n > count)
				n = count;
			if (n <= 0)
				return 0;

			var nInt = (int)n; // Safe because n <= count, which is an Int32
			if (nInt < 0)
				nInt = 0;  // _position could be beyond EOF
			Contract.Assert(pos + nInt >= 0, "_position + n >= 0");  // len is less than 2^63 -1.

			if (_buffer != null)
			{
				unsafe
				{
					byte* pointer = null;
					RuntimeHelpers.PrepareConstrainedRegions();
					try
					{
						_buffer.AcquirePointer(ref pointer);
						BufferMemcpy(buffer, offset, pointer + pos + _offset, 0, nInt);
					}
					finally
					{
						if (pointer != null)
						{
							_buffer.ReleasePointer();
						}
					}
				}
			}
			else
			{
				unsafe
				{
					BufferMemcpy(buffer, offset, _mem + pos, 0, nInt);
				}
			}
			Interlocked.Exchange(ref _position, pos + n);
			return nInt;
		}

		/// <summary>
		/// Asynchronously reads a sequence of bytes from the current stream and advances the position within the stream by the number of
		/// bytes read.
		/// </summary>
		/// <param name="buffer">The buffer to write the data into.</param>
		/// <param name="offset">The byte offset in buffer at which to begin writing data from the stream.</param>
		/// <param name="count">The maximum number of bytes to read.</param>
		/// <param name="cancellationToken">The token to monitor for cancellation requests. The default value is None.</param>
		/// <returns>
		/// A task that represents the asynchronous read operation. The value of the TResult parameter contains the total number of bytes
		/// read into the buffer. The result value can be less than the number of bytes requested if the number of bytes currently available
		/// is less than the requested number, or it can be 0 (zero) if the end of the stream has been reached.
		/// </returns>
		[HostProtection(ExternalThreading = true)]
		[ComVisible(false)]
		public virtual Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
		{
			if (buffer == null)
				throw new ArgumentNullException(nameof(buffer), ResourceHelper.GetString("ArgumentNull_Buffer"));
			if (offset < 0)
				throw new ArgumentOutOfRangeException(nameof(offset), ResourceHelper.GetString("ArgumentOutOfRange_NeedNonNegNum"));
			if (count < 0)
				throw new ArgumentOutOfRangeException(nameof(count), ResourceHelper.GetString("ArgumentOutOfRange_NeedNonNegNum"));
			if (buffer.Length - offset < count)
				throw new ArgumentException(ResourceHelper.GetString("Argument_InvalidOffLen"));
			Contract.EndContractBlock();  // contract validation copied from Read(...)

			if (cancellationToken.IsCancellationRequested)
				return Task.FromCanceled<int>(cancellationToken);

			try
			{
				var n = Read(buffer, offset, count);
				var t = _lastReadTask;
				return t != null && t.Result == n ? t : _lastReadTask = Task.FromResult(n);
			}
			catch (Exception ex)
			{
				Contract.Assert(!(ex is OperationCanceledException));
				return Task.FromException<int>(ex);
			}
		}

		/// <summary>
		/// Reads a byte from the stream and advances the position within the stream by one byte, or returns -1 if at the end of the stream.
		/// </summary>
		/// <returns>The unsigned byte cast to an Int32, or -1 if at the end of the stream.</returns>
		[SecuritySafeCritical]
		public override int ReadByte()
		{
			if (!_isOpen) ErrorStreamIsClosed();
			if (!CanRead) ErrorReadNotSupported();

			var pos = Interlocked.Read(ref _position);  // Use a local to avoid a race condition
			var len = Interlocked.Read(ref _length);
			if (pos >= len)
				return -1;
			Interlocked.Exchange(ref _position, pos + 1);
			int result;
			if (_buffer != null)
			{
				unsafe
				{
					byte* pointer = null;
					RuntimeHelpers.PrepareConstrainedRegions();
					try
					{
						_buffer.AcquirePointer(ref pointer);
						result = *(pointer + pos + _offset);
					}
					finally
					{
						if (pointer != null)
						{
							_buffer.ReleasePointer();
						}
					}
				}
			}
			else
			{
				unsafe
				{
					result = _mem[pos];
				}
			}
			return result;
		}

		/// <summary>When overridden in a derived class, sets the position within the current stream.</summary>
		/// <param name="offset">A byte offset relative to the origin parameter.</param>
		/// <param name="loc">A value of type SeekOrigin indicating the reference point used to obtain the new position.</param>
		/// <returns>The new position within the current stream.</returns>
		public override long Seek(long offset, SeekOrigin loc)
		{
			if (!_isOpen) ErrorStreamIsClosed();
			switch (loc)
			{
				case SeekOrigin.Begin:
					if (offset < 0)
						throw new IOException(ResourceHelper.GetString("IO.IO_SeekBeforeBegin"));
					Interlocked.Exchange(ref _position, offset);
					break;

				case SeekOrigin.Current:
					var pos = Interlocked.Read(ref _position);
					if (offset + pos < 0)
						throw new IOException(ResourceHelper.GetString("IO.IO_SeekBeforeBegin"));
					Interlocked.Exchange(ref _position, offset + pos);
					break;

				case SeekOrigin.End:
					var len = Interlocked.Read(ref _length);
					if (len + offset < 0)
						throw new IOException(ResourceHelper.GetString("IO.IO_SeekBeforeBegin"));
					Interlocked.Exchange(ref _position, len + offset);
					break;

				default:
					throw new ArgumentException(ResourceHelper.GetString("Argument_InvalidSeekOrigin"));
			}

			var finalPos = Interlocked.Read(ref _position);
			Contract.Assert(finalPos >= 0, "_position >= 0");
			return finalPos;
		}

		/// <summary>When overridden in a derived class, sets the length of the current stream.</summary>
		/// <param name="value">The desired length of the current stream in bytes.</param>
		[SecuritySafeCritical]
		public override void SetLength(long value)
		{
			if (value < 0)
				throw new ArgumentOutOfRangeException(nameof(value), ResourceHelper.GetString("ArgumentOutOfRange_NeedNonNegNum"));
			Contract.EndContractBlock();
			if (_buffer != null)
				throw new NotSupportedException(ResourceHelper.GetString("NotSupported_UmsSafeBuffer"));
			if (!_isOpen) ErrorStreamIsClosed();
			if (!CanWrite) ErrorWriteNotSupported();

			if (value > _capacity)
				throw new IOException(ResourceHelper.GetString("IO.IO_FixedCapacity"));

			var pos = Interlocked.Read(ref _position);
			var len = Interlocked.Read(ref _length);
			if (value > len)
			{
				unsafe
				{
					BufferZeroMemory(_mem + len, value - len);
				}
			}
			Interlocked.Exchange(ref _length, value);
			if (pos > value)
			{
				Interlocked.Exchange(ref _position, value);
			}
		}

		/// <summary>
		/// When overridden in a derived class, writes a sequence of bytes to the current stream and advances the current position within
		/// this stream by the number of bytes written.
		/// </summary>
		/// <param name="buffer">
		/// An array of bytes. This method copies <paramref name="count"/> bytes from <paramref name="buffer"/> to the current stream.
		/// </param>
		/// <param name="offset">
		/// The zero-based byte offset in <paramref name="buffer"/> at which to begin copying bytes to the current stream.
		/// </param>
		/// <param name="count">The number of bytes to be written to the current stream.</param>
		[SecuritySafeCritical]
		public override void Write(byte[] buffer, int offset, int count)
		{
			if (buffer == null)
				throw new ArgumentNullException(nameof(buffer), ResourceHelper.GetString("ArgumentNull_Buffer"));
			if (offset < 0)
				throw new ArgumentOutOfRangeException(nameof(offset), ResourceHelper.GetString("ArgumentOutOfRange_NeedNonNegNum"));
			if (count < 0)
				throw new ArgumentOutOfRangeException(nameof(count), ResourceHelper.GetString("ArgumentOutOfRange_NeedNonNegNum"));
			if (buffer.Length - offset < count)
				throw new ArgumentException(ResourceHelper.GetString("Argument_InvalidOffLen"));
			Contract.EndContractBlock();  // Keep contract validation in sync with WriteAsync(..)

			if (!_isOpen) ErrorStreamIsClosed();
			if (!CanWrite) ErrorWriteNotSupported();

			var pos = Interlocked.Read(ref _position);  // Use a local to avoid a race condition
			var len = Interlocked.Read(ref _length);
			var n = pos + count;
			// Check for overflow
			if (n < 0)
				throw new IOException(ResourceHelper.GetString("IO.IO_StreamTooLong"));

			if (n > _capacity)
			{
				throw new NotSupportedException(ResourceHelper.GetString("IO.IO_FixedCapacity"));
			}

			if (_buffer == null)
			{
				// Check to see whether we are now expanding the stream and must zero any memory in the middle.
				if (pos > len)
				{
					unsafe
					{
						BufferZeroMemory(_mem + len, pos - len);
					}
				}

				// set length after zeroing memory to avoid race condition of accessing unzeroed memory
				if (n > len)
				{
					Interlocked.Exchange(ref _length, n);
				}
			}

			if (_buffer != null)
			{
				var bytesLeft = _capacity - pos;
				if (bytesLeft < count)
				{
					throw new ArgumentException(ResourceHelper.GetString("Arg_BufferTooSmall"));
				}

				unsafe
				{
					byte* pointer = null;
					RuntimeHelpers.PrepareConstrainedRegions();
					try
					{
						_buffer.AcquirePointer(ref pointer);
						BufferMemcpy(pointer + pos + _offset, 0, buffer, offset, count);
					}
					finally
					{
						if (pointer != null)
						{
							_buffer.ReleasePointer();
						}
					}
				}
			}
			else
			{
				unsafe
				{
					BufferMemcpy(_mem + pos, 0, buffer, offset, count);
				}
			}
			Interlocked.Exchange(ref _position, n);
		}

		/// <summary>
		/// Asynchronously writes a sequence of bytes to the current stream, advances the current position within this stream by the number
		/// of bytes written, and monitors cancellation requests.
		/// </summary>
		/// <param name="buffer">The buffer to write data from.</param>
		/// <param name="offset">The zero-based byte offset in buffer from which to begin copying bytes to the stream.</param>
		/// <param name="count">The maximum number of bytes to write.</param>
		/// <param name="cancellationToken">The token to monitor for cancellation requests. The default value is None.</param>
		/// <returns>A task that represents the asynchronous write operation.</returns>
		[HostProtection(ExternalThreading = true)]
		[ComVisible(false)]
		public virtual Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
		{
			if (buffer == null)
				throw new ArgumentNullException(nameof(buffer), ResourceHelper.GetString("ArgumentNull_Buffer"));
			if (offset < 0)
				throw new ArgumentOutOfRangeException(nameof(offset), ResourceHelper.GetString("ArgumentOutOfRange_NeedNonNegNum"));
			if (count < 0)
				throw new ArgumentOutOfRangeException(nameof(count), ResourceHelper.GetString("ArgumentOutOfRange_NeedNonNegNum"));
			if (buffer.Length - offset < count)
				throw new ArgumentException(ResourceHelper.GetString("Argument_InvalidOffLen"));
			Contract.EndContractBlock();  // contract validation copied from Write(..)

			if (cancellationToken.IsCancellationRequested)
				return Task.FromCanceled(cancellationToken);

			try
			{
				Write(buffer, offset, count);
				return Task.CompletedTask;
			}
			catch (Exception ex)
			{
				Contract.Assert(!(ex is OperationCanceledException));
				return Task.FromException<int>(ex);
			}
		}

		/// <summary>Writes a byte to the current position in the stream and advances the position within the stream by one byte.</summary>
		/// <param name="value">The byte to write to the stream.</param>
		[SecuritySafeCritical]
		public override void WriteByte(byte value)
		{
			if (!_isOpen) ErrorStreamIsClosed();
			if (!CanWrite) ErrorWriteNotSupported();

			var pos = Interlocked.Read(ref _position);  // Use a local to avoid a race condition
			var len = Interlocked.Read(ref _length);
			var n = pos + 1;
			if (pos >= len)
			{
				// Check for overflow
				if (n < 0)
					throw new IOException(ResourceHelper.GetString("IO.IO_StreamTooLong"));

				if (n > _capacity)
					throw new NotSupportedException(ResourceHelper.GetString("IO.IO_FixedCapacity"));

				// Check to see whether we are now expanding the stream and must zero any memory in the middle. don't do if created from SafeBuffer
				if (_buffer == null)
				{
					if (pos > len)
					{
						unsafe
						{
							BufferZeroMemory(_mem + len, pos - len);
						}
					}

					// set length after zeroing memory to avoid race condition of accessing unzeroed memory
					Interlocked.Exchange(ref _length, n);
				}
			}

			if (_buffer != null)
			{
				unsafe
				{
					byte* pointer = null;
					RuntimeHelpers.PrepareConstrainedRegions();
					try
					{
						_buffer.AcquirePointer(ref pointer);
						*(pointer + pos + _offset) = value;
					}
					finally
					{
						if (pointer != null)
						{
							_buffer.ReleasePointer();
						}
					}
				}
			}
			else
			{
				unsafe
				{
					_mem[pos] = value;
				}
			}
			Interlocked.Exchange(ref _position, n);
		}

		[SecurityCritical]
		internal void Initialize(SafeBuffer buffer, long offset, long length, FileAccess access, bool skipSecurityCheck)
		{
			if (buffer == null)
				throw new ArgumentNullException(nameof(buffer));
			if (offset < 0)
				throw new ArgumentOutOfRangeException(nameof(offset), ResourceHelper.GetString("ArgumentOutOfRange_NeedNonNegNum"));
			if (length < 0)
				throw new ArgumentOutOfRangeException(nameof(length), ResourceHelper.GetString("ArgumentOutOfRange_NeedNonNegNum"));
			if (buffer.ByteLength < (ulong)(offset + length))
				throw new ArgumentException(ResourceHelper.GetString("Argument_InvalidSafeBufferOffLen"));
			if (access < FileAccess.Read || access > FileAccess.ReadWrite)
				throw new ArgumentOutOfRangeException(nameof(access));
			Contract.EndContractBlock();

			if (_isOpen)
				throw new InvalidOperationException(ResourceHelper.GetString("InvalidOperation_CalledTwice"));
			if (!skipSecurityCheck)
#pragma warning disable 618
				new SecurityPermission(SecurityPermissionFlag.UnmanagedCode).Demand();
#pragma warning restore 618

			// check for wraparound
			unsafe
			{
				byte* pointer = null;
				RuntimeHelpers.PrepareConstrainedRegions();
				try
				{
					buffer.AcquirePointer(ref pointer);
					if (pointer + offset + length < pointer)
					{
						throw new ArgumentException(ResourceHelper.GetString("ArgumentOutOfRange_UnmanagedMemStreamWrapAround"));
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

			_offset = offset;
			_buffer = buffer;
			_length = length;
			_capacity = length;
			_access = access;
			_isOpen = true;
		}

		[SecurityCritical]
		internal unsafe void Initialize(byte* pointer, long length, long capacity, FileAccess access, bool skipSecurityCheck)
		{
			if (pointer == null)
				throw new ArgumentNullException(nameof(pointer));
			if (length < 0 || capacity < 0)
				throw new ArgumentOutOfRangeException(length < 0 ? "length" : "capacity", ResourceHelper.GetString("ArgumentOutOfRange_NeedNonNegNum"));
			if (length > capacity)
				throw new ArgumentOutOfRangeException(nameof(length), ResourceHelper.GetString("ArgumentOutOfRange_LengthGreaterThanCapacity"));
			Contract.EndContractBlock();
			// Check for wraparound.
			if ((byte*)((long)pointer + capacity) < pointer)
				throw new ArgumentOutOfRangeException(nameof(capacity), ResourceHelper.GetString("ArgumentOutOfRange_UnmanagedMemStreamWrapAround"));
			if (access < FileAccess.Read || access > FileAccess.ReadWrite)
				throw new ArgumentOutOfRangeException(nameof(access), ResourceHelper.GetString("ArgumentOutOfRange_Enum"));
			if (_isOpen)
				throw new InvalidOperationException(ResourceHelper.GetString("InvalidOperation_CalledTwice"));

			if (!skipSecurityCheck)
#pragma warning disable 618
				new SecurityPermission(SecurityPermissionFlag.UnmanagedCode).Demand();
#pragma warning restore 618

			_mem = pointer;
			_offset = 0;
			_length = length;
			_capacity = capacity;
			_access = access;
			_isOpen = true;
		}

		/// <summary>
		/// Releases the unmanaged resources used by the <see cref="T:System.IO.Stream"/> and optionally releases the managed resources.
		/// </summary>
		/// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
		[SecuritySafeCritical]
		protected override void Dispose(bool disposing)
		{
			_isOpen = false;
			unsafe { _mem = null; }

			// Stream allocates WaitHandles for async calls. So for correctness call base.Dispose(disposing) for better perf, avoiding
			// waiting for the finalizers to run on those types.
			base.Dispose(disposing);
		}

		/// <summary>
		/// Initializes a new instance of the UnmanagedMemoryStream class in a safe buffer with a specified offset, length, and file access.
		/// </summary>
		/// <param name="buffer">The buffer to contain the unmanaged memory stream.</param>
		/// <param name="offset">The byte position in the buffer at which to start the unmanaged memory stream.</param>
		/// <param name="length">The length of the unmanaged memory stream.</param>
		/// <param name="access">The mode of file access to the unmanaged memory stream.</param>
		[SecuritySafeCritical]
		protected void Initialize(SafeBuffer buffer, long offset, long length, FileAccess access) => Initialize(buffer, offset, length, access, false);

		/// <summary>Initializes a new instance of the UnmanagedMemoryStream class by using a pointer to an unmanaged memory location.</summary>
		/// <param name="pointer">A pointer to an unmanaged memory location.</param>
		/// <param name="length">The length of the memory to use.</param>
		/// <param name="capacity">The total amount of memory assigned to the stream.</param>
		/// <param name="access">One of the <see cref="FileAccess"/> values.</param>
		[SecurityCritical]
		protected unsafe void Initialize(byte* pointer, long length, long capacity, FileAccess access) => Initialize(pointer, length, capacity, access, false);

		[SecurityCritical]
		private static unsafe void BufferMemcpy(byte[] dest, int destIndex, byte* src, int srcIndex, int len)
		{
			Contract.Assert(srcIndex >= 0 && destIndex >= 0 && len >= 0, "Index and length must be non-negative!");
			Contract.Assert(dest.Length - destIndex >= len, "not enough bytes in dest");
			if (len == 0)
				return;
			Marshal.Copy((IntPtr)src, dest, srcIndex, len);
		}

		[SecurityCritical]
		private static unsafe void BufferMemcpy(byte* dest, int destIndex, byte[] src, int srcIndex, int len)
		{
			Contract.Assert(srcIndex >= 0 && destIndex >= 0 && len >= 0, "Index and length must be non-negative!");
			Contract.Assert(src.Length - srcIndex >= len, "not enough bytes in src");
			if (len == 0)
				return;
			Marshal.Copy(src, srcIndex, (IntPtr)dest, len);
		}

		private static unsafe void BufferZeroMemory(byte* src, long len) => ((IntPtr)src).FillMemory(0, len);

		private static void ErrorReadNotSupported() => throw new NotSupportedException(ResourceHelper.GetString("NotSupported_UnreadableStream"));

		private static void ErrorStreamIsClosed() => throw new ObjectDisposedException(null, ResourceHelper.GetString("ObjectDisposed_StreamClosed"));

		private static void ErrorWriteNotSupported() => throw new NotSupportedException(ResourceHelper.GetString("NotSupported_UnwritableStream"));
	}
}
#endif