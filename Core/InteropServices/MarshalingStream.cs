using System;
using System.IO;
using System.Runtime.InteropServices;
using Vanara.Extensions;

namespace Vanara.InteropServices
{
	/// <summary>A <see cref="Stream"/> derivative for working with unmanaged memory.</summary>
	/// <seealso cref="System.IO.Stream"/>
	public class MarshalingStream : Stream
	{
		private readonly IntPtr ptr;

		/// <summary>Initializes a new instance of the <see cref="MarshalingStream"/> class.</summary>
		/// <param name="unmanagedPtr">The unmanaged PTR.</param>
		/// <param name="bytesAllocated">The bytes allocated.</param>
		public MarshalingStream(IntPtr unmanagedPtr, long bytesAllocated)
		{
			ptr = unmanagedPtr;
			Capacity = bytesAllocated;
		}

		/// <summary>Clears all buffers for this stream and causes any buffered data to be written to the underlying device.</summary>
		public override void Flush() { }

		/// <summary>Sets the position within the current stream.</summary>
		/// <param name="offset">A byte offset relative to the <paramref name="origin"/> parameter.</param>
		/// <param name="origin">A value of type <see cref="T:System.IO.SeekOrigin"/> indicating the reference point used to obtain the new position.</param>
		/// <returns>The new position within the current stream.</returns>
		/// <exception cref="System.ArgumentException"></exception>
		public override long Seek(long offset, SeekOrigin origin)
		{
			var startPos = origin == SeekOrigin.Begin ? 0L : (origin == SeekOrigin.Current ? Position : Capacity);
			var reqPos = startPos + offset;
			if (reqPos < 0 || reqPos > Capacity)
				throw new ArgumentException();
			return Position = reqPos;
		}

		/// <summary>Sets the length of the current stream.</summary>
		/// <param name="value">The desired length of the current stream in bytes.</param>
		/// <exception cref="System.InvalidOperationException"></exception>
		public override void SetLength(long value)
		{
			throw new InvalidOperationException();
		}

		/// <summary>Reads a sequence of bytes from the current stream and advances the position within the stream by the number of bytes read.</summary>
		/// <param name="buffer">
		/// An array of bytes. When this method returns, the buffer contains the specified byte array with the values between <paramref name="offset"/> and (
		/// <paramref name="offset"/> + <paramref name="count"/> - 1) replaced by the bytes read from the current source.
		/// </param>
		/// <param name="offset">The zero-based byte offset in <paramref name="buffer"/> at which to begin storing the data read from the current stream.</param>
		/// <param name="count">The maximum number of bytes to be read from the current stream.</param>
		/// <returns>
		/// The total number of bytes read into the buffer. This can be less than the number of bytes requested if that many bytes are not currently available,
		/// or zero (0) if the end of the stream has been reached.
		/// </returns>
		/// <exception cref="System.ArgumentNullException">buffer</exception>
		/// <exception cref="System.ArgumentException"></exception>
		/// <exception cref="System.ArgumentOutOfRangeException"></exception>
		public override int Read(byte[] buffer, int offset, int count)
		{
			if (buffer == null) throw new ArgumentNullException(nameof(buffer));
			if (offset + count > buffer.Length) throw new ArgumentException();
			if (offset < 0 || count < 0) throw new ArgumentOutOfRangeException();
			if (Position + count > Capacity) count = (int)(Capacity - Position);
			if (count > 0)
			{
				Marshal.Copy(PositionPtr, buffer, offset, count);
				Position += count;
			}
			return count;
		}

		/// <summary>Reads a blittable type from the current stream and advances the position within the stream by the number of bytes read.</summary>
		/// <typeparam name="T">The type of the object to read.</typeparam>
		/// <returns>An object of type <typeparamref name="T"/>.</returns>
		/// <exception cref="ArgumentException">Type to be read must be blittable. - T</exception>
		/// <exception cref="ArgumentOutOfRangeException" />
		public T Read<T>()
		{
			//if (!typeof(T).IsBlittable()) throw new ArgumentException(@"Type to be read must be blittable.", nameof(T));
			var sz = Marshal.SizeOf(typeof(T));
			if (Position + sz > Capacity) throw new ArgumentOutOfRangeException();
			var ret = PositionPtr.ToStructure<T>();
			Position += sz;
			return ret;
		}

		/// <summary>Pokes the specified buffer at the offset from the starting pointer without changing the <see cref="Position"/>.</summary>
		/// <param name="buffer">The buffer.</param>
		/// <param name="offsetFromStart">The offset from start.</param>
		/// <exception cref="System.ArgumentNullException">buffer</exception>
		/// <exception cref="System.ArgumentException"></exception>
		/// <exception cref="System.ArgumentOutOfRangeException"></exception>
		public void Poke(byte[] buffer, long offsetFromStart)
		{
			if (buffer == null) throw new ArgumentNullException(nameof(buffer));
			if (offsetFromStart + buffer.Length > Capacity) throw new ArgumentException();
			if (offsetFromStart < 0) throw new ArgumentOutOfRangeException();
			Marshal.Copy(buffer, 0, ptr, buffer.Length);
		}

		/// <summary>Pokes the specified IntPtr value at the offset from the starting pointer without changing the <see cref="Position"/>.</summary>
		/// <param name="value">The value.</param>
		/// <param name="offsetFromStart">The offset from start.</param>
		/// <exception cref="System.ArgumentException"></exception>
		/// <exception cref="System.ArgumentOutOfRangeException"></exception>
		public void Poke(IntPtr value, long offsetFromStart)
		{
			if (offsetFromStart + IntPtr.Size > Capacity) throw new ArgumentException();
			if (offsetFromStart < 0) throw new ArgumentOutOfRangeException();
			Marshal.WriteIntPtr(ptr.Offset(offsetFromStart), value);
		}

		/// <summary>Writes a sequence of bytes to the current stream and advances the current position within this stream by the number of bytes written.</summary>
		/// <param name="buffer">An array of bytes. This method copies <paramref name="count"/> bytes from <paramref name="buffer"/> to the current stream.</param>
		/// <param name="offset">The zero-based byte offset in <paramref name="buffer"/> at which to begin copying bytes to the current stream.</param>
		/// <param name="count">The number of bytes to be written to the current stream.</param>
		/// <exception cref="System.ArgumentNullException">buffer</exception>
		/// <exception cref="System.ArgumentException"></exception>
		/// <exception cref="System.ArgumentOutOfRangeException"></exception>
		public override void Write(byte[] buffer, int offset, int count)
		{
			if (buffer == null) throw new ArgumentNullException(nameof(buffer));
			if (offset + count > buffer.Length) throw new ArgumentException();
			if (offset < 0 || count < 0) throw new ArgumentOutOfRangeException();
			if (Position + count - offset > Capacity) throw new ArgumentException();
			Marshal.Copy(buffer, offset, PositionPtr, count);
			Position += count;
		}

		/// <summary>Writes the specified value into the stream.</summary>
		/// <typeparam name="T">The type of the value.</typeparam>
		/// <param name="value">The value.</param>
		public void Write<T>(T value)
		{
			if (value == null) return;
			if (typeof(T) == typeof(string))
			{
				var bytes = value.ToString().GetBytes(true, CharSet);
				Write(bytes, 0, bytes.Length);
			}
			else
			{
				var stSize = Marshal.SizeOf(value);
				if (stSize + Position > Capacity) throw new ArgumentException();
				Marshal.StructureToPtr(value, PositionPtr, false);
				Position += stSize;
			}
		}

		/// <summary>Writes the specified array into the stream.</summary>
		/// <typeparam name="T">The type of the array item.</typeparam>
		/// <param name="items">The items.</param>
		public void Write<T>(T[] items)
		{
			if (items == null) return;
			if (typeof(T) == typeof(string))
			{
				var hMem = SafeHGlobalHandle.CreateFromStringList(items as string[], StringListPackMethod.Packed, CharSet, 0);
				var bytes = hMem.ToArray<byte>(hMem.Size);
				Write(bytes, 0, bytes.Length);
			}
			else
			{
				var stSize = Marshal.SizeOf(typeof(T));
				if (stSize * items.Length + Position > Capacity) throw new ArgumentException();
				for (var i = 0; i < items.Length; i++)
					Marshal.StructureToPtr(items[i], PositionPtr.Offset(i * stSize), false);
				Position += stSize * items.Length;
			}
		}

		/// <summary>Gets a value indicating whether the current stream supports reading.</summary>
		public override bool CanRead => true;

		/// <summary>Gets a value indicating whether the current stream supports seeking.</summary>
		public override bool CanSeek => true;

		/// <summary>Gets a value indicating whether the current stream supports writing.</summary>
		public override bool CanWrite => true;

		/// <summary>Gets the capacity.</summary>
		/// <value>The capacity.</value>
		public long Capacity { get; }

		/// <summary>Gets or sets the character set.</summary>
		/// <value>The character set.</value>
		public CharSet CharSet { get; set; } = CharSet.Auto;

		/// <summary>When overridden in a derived class, gets the length in bytes of the stream.</summary>
		public override long Length => Capacity;

		/// <summary>Gets the initial pointer supplied to the constructor.</summary>
		public IntPtr Pointer => ptr;

		/// <summary>When overridden in a derived class, gets or sets the position within the current stream.</summary>
		public override long Position { get; set; }

		/// <summary>Gets the position PTR.</summary>
		/// <value>The position PTR.</value>
		public IntPtr PositionPtr => ptr.Offset(Position);
	}
}
