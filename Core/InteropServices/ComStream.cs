using System.IO;
using System.Runtime.InteropServices.ComTypes;
using STATSTG = System.Runtime.InteropServices.ComTypes.STATSTG;

namespace Vanara.InteropServices;

/// <summary>Implements a .NET stream derivation and a COM IStream instance.</summary>
/// <seealso cref="Stream"/>
/// <seealso cref="IStream"/>
/// <seealso cref="IDisposable"/>
public class ComStream : Stream, IStream, IDisposable
{
	private readonly IStream? comStream = null;
	private readonly Stream? netStream = null;

	/// <summary>Initializes a new instance of the ComStream class.</summary>
	/// <param name="stream">An IO.Stream</param>
	public ComStream(Stream stream) => netStream = stream;

	/// <summary>Initializes a new instance of the ComStream class.</summary>
	/// <param name="stream">A ComTypes.IStream</param>
	public ComStream(IStream stream) => comStream = stream;

	// Default constructor. Should not be used to create an ComStream object.
	private ComStream()
	{
	}

	/// <summary>Finalizes an instance of the <see cref="ComStream"/> class.</summary>
	~ComStream()
	{
		netStream?.Close();
	}

	/// <summary>Gets a value indicating whether this instance can read.</summary>
	/// <value><see langword="true"/> if this instance can read; otherwise, <see langword="false"/>.</value>
	public override bool CanRead => (GetStats().grfMode & 0x00000003) is 0 or 2;

	/// <summary>Gets a value indicating whether this instance can seek.</summary>
	/// <value><see langword="true"/> if this instance can seek; otherwise, <see langword="false"/>.</value>
	public override bool CanSeek => netStream?.CanSeek ?? true;

	/// <summary>Gets a value indicating whether this instance can timeout.</summary>
	/// <value><see langword="true"/> if this instance can timeout; otherwise, <see langword="false"/>.</value>
	public override bool CanTimeout => netStream?.CanTimeout ?? false;

	/// <summary>Gets a value indicating whether this instance can write.</summary>
	/// <value><see langword="true"/> if this instance can write; otherwise, <see langword="false"/>.</value>
	public override bool CanWrite => (GetStats().grfMode & 0x00000003) is 1 or 2;

	/// <summary>When overridden in a derived class, gets the length in bytes of the stream.</summary>
	public override long Length
	{
		get
		{
			if (comStream is not null)
			{
				// Call IStream.Stat to retrieve info about the stream, which includes the length. STATFLAG_NONAME means that we don't care
				// about the name (STATSTG.pwcsName), so there is no need for the method to allocate memory for the string.
				comStream.Stat(out var statstg, 1);
				return statstg.cbSize;
			}
			else if (netStream is not null)
				return netStream.Length;
			else
				throw new InvalidOperationException();
		}
	}

	/// <summary>Gets or sets the position.</summary>
	/// <value>The position.</value>
	public override long Position
	{
		get => comStream is not null ? Seek(0, SeekOrigin.Current) : netStream?.Position ?? throw new InvalidOperationException();
		set
		{
			if (comStream is not null)
				Seek(value, SeekOrigin.Begin);
			else if (netStream is not null)
				netStream.Position = value;
			else
				throw new InvalidOperationException();
		}
	}

	/// <summary>Gets the <see cref="IStream"/> instance from the <paramref name="stream"/> value, if possible.</summary>
	/// <param name="stream">The stream.</param>
	/// <returns>An <see cref="IStream"/> instance or <see langword="null"/> if not available.</returns>
	public static IStream? ToIStream(object stream) => stream is Stream s ? new ComStream(s) : stream is IStream ist ? ist : null;

	/// <summary>Gets the <see cref="Stream"/> instance from the <paramref name="stream"/> value, if possible.</summary>
	/// <param name="stream">The stream.</param>
	/// <returns>An <see cref="Stream"/> instance or <see langword="null"/> if not available.</returns>
	public static Stream? ToStream(object stream) => stream is Stream s ? s : stream is IStream ist ? new ComStream(ist) : null;

	/// <summary>Closes the current stream and releases any resources (such as the Stream) associated with the current IStream.</summary>
	/// <returns></returns>
	/// <remarks>This method is not a member in IStream.</remarks>
	public override void Close()
	{
		netStream?.Close();
		try { comStream?.Commit(0 /*STGC_DEFAULT*/); } catch { }
		GC.SuppressFinalize(this);
	}

	/// <summary>Clears all buffers for this stream and causes any buffered data to be written to the underlying device.</summary>
	/// <returns></returns>
	public override void Flush() => ((IStream)this).Commit(0 /*STGC_DEFAULT*/);

	/// <summary>
	/// Reads a sequence of bytes from the current stream and advances the position within the stream by the number of bytes read.
	/// </summary>
	/// <param name="buffer">
	/// An array of bytes. When this method returns, the buffer contains the specified byte array with the values between offset and (offset
	/// + count - 1) replaced by the bytes read from the current source.
	/// </param>
	/// <param name="offset">The zero-based byte offset in buffer at which to begin storing the data read from the current stream.</param>
	/// <param name="count">The maximum number of bytes to be read from the current stream.</param>
	/// <returns>
	/// The total number of bytes read into the buffer. This can be less than the number of bytes requested if that many bytes are not
	/// currently available, or zero (0) if the end of the stream has been reached.
	/// </returns>
	/// <exception cref="NotSupportedException">Only a zero offset is supported.</exception>
	public override int Read(byte[] buffer, int offset, int count)
	{
		if (comStream is not null)
		{
			var rdBuf = buffer;
			if (offset != 0)
#if NETCOREAPP3_0_OR_GREATER || NET5_0_OR_GREATER || NETSTANDARD2_1_OR_GREATER
				rdBuf = buffer[offset..];
#else
				throw new InvalidOperationException("Offsets cannot be handled by IStream.");
#endif
			unsafe
			{
				int bytesRead = 0;
				comStream.Read(rdBuf, count, (IntPtr)(void*)&bytesRead);
				return bytesRead;
			}
		}
		else if (netStream is not null)
			return netStream.Read(buffer, offset, count);
		else
			throw new InvalidOperationException();
	}

	/// <summary>Sets the position within the current stream.</summary>
	/// <param name="offset">A byte offset relative to the origin parameter.</param>
	/// <param name="origin">A value of type SeekOrigin indicating the reference point used to obtain the new position.</param>
	/// <returns>The new position within the current stream.</returns>
	public override long Seek(long offset, SeekOrigin origin)
	{
		if (comStream is not null)
		{
			unsafe
			{
				long position = 0;
				// The enum values of SeekOrigin match the enum values of STREAM_SEEK, so we can just cast the origin to an integer.
				comStream.Seek(offset, (int)origin, (IntPtr)(void*)&position);
				return position;
			}
		}
		else if (netStream is not null)
			return netStream.Seek(offset, origin);
		else
			throw new InvalidOperationException();
	}

	/// <summary>Sets the length of the current stream.</summary>
	/// <param name="value">The desired length of the current stream in bytes.</param>
	/// <returns></returns>
	public override void SetLength(long value)
	{
		if (netStream is not null)
			netStream.SetLength(value);
		else if (comStream is not null)
			comStream.SetSize(value);
		else
			throw new InvalidOperationException();
	}

	/// <summary>
	/// Writes a sequence of bytes to the current stream and advances the current position within this stream by the number of bytes written.
	/// </summary>
	/// <param name="buffer">An array of bytes. This method copies count bytes from buffer to the current stream.</param>
	/// <param name="offset">The zero-based byte offset in buffer at which to begin copying bytes to the current stream.</param>
	/// <param name="count">The number of bytes to be written to the current stream.</param>
	/// <returns></returns>
	/// <exception cref="NotSupportedException">Only a zero offset is supported.</exception>
	public override void Write(byte[] buffer, int offset, int count)
	{
		if (buffer.Length < count - offset)
			throw new ArgumentOutOfRangeException(nameof(count));
		if (comStream is not null)
		{
			var wrBuf = buffer;
			if (offset == 0)
			{
				wrBuf = new byte[count];
				Array.Copy(buffer, offset, wrBuf, 0, count);
			}
			comStream.Write(wrBuf, count, IntPtr.Zero);
		}
		else if (netStream is not null)
			netStream.Write(buffer, offset, count);
		else
			throw new InvalidOperationException();
	}

	/// <summary>Creates a new stream object with its own seek pointer that references the same bytes as the original stream.</summary>
	/// <param name="ppstm">When successful, pointer to the location of an IStream pointer to the new stream object.</param>
	/// <returns></returns>
	/// <exception cref="NotSupportedException">The IO.Streamtream cannot be cloned.</exception>
	/// <remarks>This method is not used and always throws the exception.</remarks>
	void IStream.Clone(out IStream ppstm)
	{
		if (netStream is not null)
			throw new NotSupportedException("A System.IO.Stream instance cannot be cloned.");
		else if (comStream is not null)
			comStream.Clone(out ppstm);
		else
			throw new InvalidOperationException();
	}

	/// <summary>Ensures that any changes made to an stream object that is open in transacted mode are reflected in the parent storage.</summary>
	/// <param name="grfCommitFlags">
	/// Controls how the changes for the stream object are committed. See the STGC enumeration for a definition of these values.
	/// </param>
	/// <returns></returns>
	/// <exception cref="IOException">An I/O error occurs.</exception>
	/// <remarks>The <paramref name="grfCommitFlags"/> parameter is not used and this method only does Stream.Flush()</remarks>
	void IStream.Commit(int grfCommitFlags)
	{
		// Clears all buffers for this stream and causes any buffered data to be written to the underlying device.
		if (netStream is not null)
			netStream.Flush();
		else if (comStream is not null)
			comStream.Commit(grfCommitFlags);
		else
			throw new InvalidOperationException();
	}

	/// <summary>
	/// Copies a specified number of bytes from the current seek pointer in the stream to the current seek pointer in another stream.
	/// </summary>
	/// <param name="pstm">The destination stream. The pstm stream can be a new stream or a clone of the source stream.</param>
	/// <param name="cb">The number of bytes to copy from the source stream.</param>
	/// <param name="pcbRead">
	/// The actual number of bytes read from the source. It can be set to IntPtr.Zero. In this case, this method does not provide the actual
	/// number of bytes read.
	/// </param>
	/// <param name="pcbWritten">
	/// The actual number of bytes written to the destination. It can be set this to IntPtr.Zero. In this case, this method does not provide
	/// the actual number of bytes written.
	/// </param>
	/// <returns>The actual number of bytes read ( <paramref name="pcbRead"/>) and written ( <paramref name="pcbWritten"/>) from the source.</returns>
	/// <exception cref="ArgumentException">The sum of offset and count is larger than the buffer length.</exception>
	/// <exception cref="ArgumentNullException">buffer is a null reference.</exception>
	/// <exception cref="ArgumentOutOfRangeException">offset or count is negative.</exception>
	/// <exception cref="IOException">An I/O error occurs.</exception>
	/// <exception cref="NotSupportedException">The stream does not support reading.</exception>
	/// <exception cref="ObjectDisposedException">Methods were called after the stream was closed.</exception>
	void IStream.CopyTo(IStream pstm, long cb, IntPtr pcbRead, IntPtr pcbWritten)
	{
		if (netStream is not null)
		{
			var sourceBytes = new byte[cb];
			long totalBytesRead = 0;
			long totalBytesWritten = 0;

			IntPtr bw = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(int)));
			Marshal.WriteInt32(bw, 0);

			while (totalBytesWritten < cb)
			{
				var currentBytesRead = netStream.Read(sourceBytes, 0, (int)(cb - totalBytesWritten));

				// Has the end of the stream been reached?
				if (currentBytesRead == 0) break;

				totalBytesRead += currentBytesRead;

				pstm.Write(sourceBytes, currentBytesRead, bw);
				var currentBytesWritten = Marshal.ReadInt32(bw);
				if (currentBytesWritten != currentBytesRead)
				{
					System.Diagnostics.Debug.WriteLine("ERROR!: The IStream Write is not writing all the bytes needed!");
				}
				totalBytesWritten += currentBytesWritten;
			}

			Marshal.FreeHGlobal(bw);

			if (pcbRead != IntPtr.Zero) Marshal.WriteInt64(pcbRead, totalBytesRead);
			if (pcbWritten != IntPtr.Zero) Marshal.WriteInt64(pcbWritten, totalBytesWritten);
		}
		else if (comStream is not null)
			comStream.CopyTo(pstm, cb, pcbRead, pcbWritten);
		else
			throw new InvalidOperationException();
	}

	/// <summary>Releases all resources used by the Stream object.</summary>
	void IDisposable.Dispose() => Close();

	/// <summary>Restricts access to a specified range of bytes in the stream.</summary>
	/// <param name="libOffset">Integer that specifies the byte offset for the beginning of the range.</param>
	/// <param name="cb">Integer that specifies the length of the range, in bytes, to be restricted.</param>
	/// <param name="dwLockType">Specifies the restrictions being requested on accessing the range.</param>
	/// <returns></returns>
	/// <exception cref="NotSupportedException">The IO.Stream does not support locking.</exception>
	/// <remarks>This method is not used and always throws the exception.</remarks>
	void IStream.LockRegion(long libOffset, long cb, int dwLockType)
	{
		if (netStream is not null)
			throw new NotSupportedException("Stream does not support locking.");
		else if (comStream is not null)
			comStream.LockRegion(libOffset, cb, dwLockType);
		else
			throw new InvalidOperationException();
	}

	/// <summary>Reads a specified number of bytes from the stream object into memory starting at the current seek pointer.</summary>
	/// <param name="pv">The buffer which the stream data is read into.</param>
	/// <param name="cb">The number of bytes of data to read from the stream object.</param>
	/// <param name="pcbRead">
	/// A pointer to a ULONG variable that receives the actual number of bytes read from the stream object. It can be set to IntPtr.Zero. In
	/// this case, this method does not return the number of bytes read.
	/// </param>
	/// <returns>The actual number of bytes read ( <paramref name="pcbRead"/>) from the source.</returns>
	/// <exception cref="ArgumentException">The sum of offset and count is larger than the buffer length.</exception>
	/// <exception cref="ArgumentNullException">buffer is a null reference.</exception>
	/// <exception cref="ArgumentOutOfRangeException">offset or count is negative.</exception>
	/// <exception cref="IOException">An I/O error occurs.</exception>
	/// <exception cref="NotSupportedException">The stream does not support reading.</exception>
	/// <exception cref="ObjectDisposedException">Methods were called after the stream was closed.</exception>
	void IStream.Read(byte[] pv, int cb, IntPtr pcbRead)
	{
		if (netStream is not null)
		{
			var bytesRead = netStream.Read(pv, 0, cb);
			if (pcbRead != IntPtr.Zero)
				Marshal.WriteInt32(pcbRead, bytesRead);
		}
		else if (comStream is not null)
			comStream.Read(pv, cb, pcbRead);
		else
			throw new InvalidOperationException();
	}

	/// <summary>Discards all changes that have been made to a transacted stream since the last stream.Commit call</summary>
	/// <returns></returns>
	/// <exception cref="NotSupportedException">The IO.Stream does not support reverting.</exception>
	/// <remarks>This method is not used and always throws the exception.</remarks>
	void IStream.Revert()
	{
		if (netStream is not null)
			throw new NotSupportedException("Stream does not support reverting.");
		else if (comStream is not null)
			comStream.Revert();
		else
			throw new InvalidOperationException();
	}

	/// <summary>
	/// Changes the seek pointer to a new location relative to the beginning of the stream, the end of the stream, or the current seek pointer
	/// </summary>
	/// <param name="dlibMove">
	/// The displacement to be added to the location indicated by the dwOrigin parameter. If dwOrigin is STREAM_SEEK_SET, this is interpreted
	/// as an unsigned value rather than a signed value.
	/// </param>
	/// <param name="dwOrigin">
	/// The origin for the displacement specified in dlibMove. The origin can be the beginning of the file (STREAM_SEEK_SET), the current
	/// seek pointer (STREAM_SEEK_CUR), or the end of the file (STREAM_SEEK_END).
	/// </param>
	/// <param name="plibNewPosition">
	/// The location where this method writes the value of the new seek pointer from the beginning of the stream. It can be set to
	/// IntPtr.Zero. In this case, this method does not provide the new seek pointer.
	/// </param>
	/// <returns>
	/// Returns in <paramref name="plibNewPosition"/> the location where this method writes the value of the new seek pointer from the
	/// beginning of the stream.
	/// </returns>
	/// <exception cref="IOException">An I/O error occurs.</exception>
	/// <exception cref="NotSupportedException">The stream does not support reading.</exception>
	/// <exception cref="ObjectDisposedException">Methods were called after the stream was closed.</exception>
	void IStream.Seek(long dlibMove, int dwOrigin, IntPtr plibNewPosition)
	{
		if (netStream is not null)
		{
			// The enum values of SeekOrigin match the enum values of STREAM_SEEK, so we can just cast the dwOrigin to a SeekOrigin
			var origin = Enum.IsDefined(typeof(SeekOrigin), dwOrigin) ? (SeekOrigin)dwOrigin : SeekOrigin.Begin;
			var newPos = netStream.Seek(dlibMove, origin);
			if (plibNewPosition == IntPtr.Zero)
				Marshal.WriteInt64(plibNewPosition, newPos);
		}
		else if (comStream is not null)
			comStream.Seek(dlibMove, dwOrigin, plibNewPosition);
		else
			throw new InvalidOperationException();
	}

	/// <summary>Changes the size of the stream object.</summary>
	/// <param name="libNewSize">Specifies the new size of the stream as a number of bytes.</param>
	/// <returns></returns>
	/// <exception cref="IOException">An I/O error occurs.</exception>
	/// <exception cref="NotSupportedException">The stream does not support reading.</exception>
	/// <exception cref="ObjectDisposedException">Methods were called after the stream was closed.</exception>
	void IStream.SetSize(long libNewSize) => SetLength(libNewSize);

	/// <summary>Retrieves the STATSTG structure for this stream.</summary>
	/// <param name="pstatstg">The STATSTG structure where this method places information about this stream object.</param>
	/// <param name="grfStatFlag">
	/// Specifies that this method does not return some of the members in the STATSTG structure, thus saving a memory allocation operation.
	/// This parameter is not used internally.
	/// </param>
	void IStream.Stat(out STATSTG pstatstg, int grfStatFlag) => pstatstg = GetStats(grfStatFlag);

	/// <summary>Removes the access restriction on a range of bytes previously restricted with the LockRegion method.</summary>
	/// <param name="libOffset">Specifies the byte offset for the beginning of the range.</param>
	/// <param name="cb">Specifies, in bytes, the length of the range to be restricted.</param>
	/// <param name="dwLockType">Specifies the access restrictions previously placed on the range.</param>
	/// <returns></returns>
	/// <exception cref="NotSupportedException">The IO.Stream does not support unlocking.</exception>
	/// <remarks>This method is not used and always throws the exception.</remarks>
	void IStream.UnlockRegion(long libOffset, long cb, int dwLockType)
	{
		if (comStream is not null)
			comStream.UnlockRegion(libOffset, cb, dwLockType);
		else if (netStream is not null)
			throw new NotSupportedException("Stream does not support unlocking.");
		else
			throw new InvalidOperationException();
	}

	/// <summary>Writes a specified number of bytes into the stream object starting at the current seek pointer.</summary>
	/// <param name="pv">
	/// The buffer that contains the data that is to be written to the stream. A valid buffer must be provided for this parameter even when
	/// cb is zero.
	/// </param>
	/// <param name="cb">The number of bytes of data to attempt to write into the stream. This value can be zero.</param>
	/// <param name="pcbWritten">
	/// A variable where this method writes the actual number of bytes written to the stream object. The caller can set this to IntPtr.Zero,
	/// in which case this method does not provide the actual number of bytes written.
	/// </param>
	/// <returns>The actual number of bytes written ( <paramref name="pcbWritten"/>).</returns>
	/// <exception cref="ArgumentException">The sum of offset and count is larger than the buffer length.</exception>
	/// <exception cref="ArgumentNullException">buffer is a null reference.</exception>
	/// <exception cref="ArgumentOutOfRangeException">offset or count is negative.</exception>
	/// <exception cref="IOException">An I/O error occurs.</exception>
	/// <exception cref="NotSupportedException">The IO.Stream does not support reading.</exception>
	/// <exception cref="ObjectDisposedException">Methods were called after the stream was closed.</exception>
	void IStream.Write(byte[] pv, int cb, IntPtr pcbWritten)
	{
		if (netStream is not null)
		{
			var currentPosition = netStream.Position;
			netStream.Write(pv, 0, cb);
			if (pcbWritten != IntPtr.Zero)
				Marshal.WriteInt32(pcbWritten, (int)(netStream.Position - currentPosition));
		}
		else if (comStream is not null)
			comStream.Write(pv, cb, pcbWritten);
		else
			throw new InvalidOperationException();
	}

	private STATSTG GetStats(int grfStatFlag = 1)
	{
		if (netStream is not null)
		{
			return new()
			{
				type = 2, // STGTY_STREAM
				cbSize = netStream.Length, // Gets the length in bytes of the stream.
				grfMode = netStream.CanRead && netStream.CanWrite ? 2 : (netStream.CanRead ? 0 : 1),
				grfLocksSupported = 2 // LOCK_EXCLUSIVE
			};
		}
		else if (comStream is not null)
		{
			comStream.Stat(out var pstatstg, grfStatFlag);
			return pstatstg;
		}
		throw new InvalidOperationException();
	}
}