using System;
using System.IO;
using System.Runtime.InteropServices.ComTypes;

namespace Vanara.InteropServices
{
	/// <summary>Implements a .NET stream over a COM IStream instance.</summary>
	/// <seealso cref="System.IO.Stream"/>
	public class ComStream : Stream
	{
		/// <summary>Initializes a new instance of the <see cref="ComStream"/> class.</summary>
		/// <param name="stream">The supporting COM <see cref="IStream"/> instance.</param>
		/// <exception cref="System.ArgumentNullException">stream</exception>
		public ComStream(IStream stream) => IStream = stream ?? throw new ArgumentNullException(nameof(stream));

		/// <summary>Gets a value indicating whether the current stream supports reading.</summary>
		public override bool CanRead => true;

		/// <summary>Gets a value indicating whether the current stream supports seeking.</summary>
		public override bool CanSeek => true;

		/// <summary>Gets a value indicating whether the current stream supports writing.</summary>
		public override bool CanWrite => true;

		/// <summary>Gets the underlying stream.</summary>
		/// <value>The underlying stream.</value>
		public IStream IStream { get; private set; }

		/// <summary>Gets the length in bytes of the stream.</summary>
		/// <exception cref="System.ObjectDisposedException">iComStream</exception>
		public override long Length
		{
			get
			{
				if (IStream is null)
					throw new ObjectDisposedException(nameof(IStream));

				IStream.Stat(out var statstg, 1 /* STATSFLAG_NONAME*/ );
				return statstg.cbSize;
			}
		}

		/// <summary>Gets or sets the position within the current stream.</summary>
		public override long Position
		{
			get => Seek(0, SeekOrigin.Current);
			set => Seek(value, SeekOrigin.Begin);
		}

		/// <summary>
		/// Closes the current stream and releases any resources (such as sockets and file handles) associated with the current stream.
		/// </summary>
		public override void Close()
		{
			if (IStream is null) return;
			IStream.Commit(0);
			IStream = null;
		}

		/// <summary>Clears all buffers for this stream and causes any buffered data to be written to the underlying device.</summary>
		public override void Flush() => IStream?.Commit(0);

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
		/// <exception cref="System.ObjectDisposedException">iComStream</exception>
		/// <exception cref="System.NotSupportedException">Offsets other than zero are not supported.</exception>
		public override int Read(byte[] buffer, int offset, int count)
		{
			if (IStream is null)
				throw new ObjectDisposedException(nameof(IStream));

			if (offset != 0)
				throw new NotSupportedException("Offsets other than zero are not supported.");

			var bytesRead = 0;
			using (var address = new PinnedObject(bytesRead))
				IStream.Read(buffer, count, address);
			return bytesRead;
		}

		/// <summary>Sets the position within the current stream.</summary>
		/// <param name="offset">A byte offset relative to the <paramref name="origin"/> parameter.</param>
		/// <param name="origin">
		/// A value of type <see cref="T:System.IO.SeekOrigin"/> indicating the reference point used to obtain the new position.
		/// </param>
		/// <returns>The new position within the current stream.</returns>
		/// <exception cref="System.ObjectDisposedException">iComStream</exception>
		public override long Seek(long offset, SeekOrigin origin)
		{
			if (IStream is null)
				throw new ObjectDisposedException(nameof(IStream));

			var position = 0L;
			using (var address = new PinnedObject(position))
				IStream.Seek(offset, (int)origin, address);
			return position;
		}

		/// <summary>Sets the length of the current stream.</summary>
		/// <param name="value">The desired length of the current stream in bytes.</param>
		/// <exception cref="System.ObjectDisposedException">iComStream</exception>
		public override void SetLength(long value)
		{
			if (IStream is null)
				throw new ObjectDisposedException(nameof(IStream));

			IStream.SetSize(value);
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
		/// <exception cref="System.ObjectDisposedException">iComStream</exception>
		/// <exception cref="System.NotSupportedException">Offsets other than zero are not supported.</exception>
		public override void Write(byte[] buffer, int offset, int count)
		{
			if (IStream is null)
				throw new ObjectDisposedException(nameof(IStream));

			if (offset != 0)
				throw new NotSupportedException("Offsets other than zero are not supported.");

			IStream.Write(buffer, count, IntPtr.Zero);
		}

		/// <summary>
		/// Releases the unmanaged resources used by the <see cref="T:System.IO.Stream"/> and optionally releases the managed resources.
		/// </summary>
		/// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) Close();
			base.Dispose(disposing);
		}
	}
}