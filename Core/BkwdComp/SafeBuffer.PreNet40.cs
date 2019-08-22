#if NET20 || NET35

using Microsoft.Win32.SafeHandles;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using Vanara.Extensions;

namespace System.Runtime.InteropServices
{
	/// <summary>
	/// Provides a controlled memory buffer that can be used for reading and writing. Attempts to access memory outside the controlled buffer
	/// (under-runs and overruns) raise exceptions.
	/// </summary>
	/// <seealso cref="Microsoft.Win32.SafeHandles.SafeHandleZeroOrMinusOneIsInvalid"/>
	[Security.SecurityCritical]
	public abstract unsafe class SafeBuffer : SafeHandleZeroOrMinusOneIsInvalid
	{
		private static readonly UIntPtr Uninitialized = UIntPtr.Size == 4 ? (UIntPtr)uint.MaxValue : (UIntPtr)ulong.MaxValue;

		private UIntPtr numBytes;

		/// <inheritdoc/>
		/// <summary>
		/// Creates a new instance of the <see cref="T:System.Runtime.InteropServices.SafeBuffer"/> class, and specifies whether the buffer
		/// handle is to be reliably released.
		/// </summary>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; <see langword="false"/> to prevent reliable
		/// release (not recommended).
		/// </param>
		protected SafeBuffer(bool ownsHandle) : base(ownsHandle) => numBytes = Uninitialized;

		/// <summary>Gets the size of the buffer, in bytes.</summary>
		public ulong ByteLength
		{
			[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
			get => numBytes != Uninitialized ? (ulong)numBytes : throw NotInitialized();
		}

		/// <summary>Obtains a pointer from a <see cref="SafeBuffer"/> object for a block of memory.</summary>
		/// <param name="pointer">
		/// A byte pointer, passed by reference, to receive the pointer from within the <see cref="SafeBuffer"/> object. You must set this
		/// pointer to <see langword="null"/> before you call this method.
		/// </param>
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		public void AcquirePointer(ref byte* pointer)
		{
			if (numBytes == Uninitialized)
				throw NotInitialized();

			pointer = null;

			var junk = false;
			DangerousAddRef(ref junk);
			pointer = (byte*)handle;
		}

		/// <summary>
		/// Defines the allocation size of the memory region in bytes. You must call this method before you use the SafeBuffer instance.
		/// </summary>
		/// <param name="numBytes">The number of bytes in the buffer.</param>
		public void Initialize(ulong numBytes)
		{
			if (IntPtr.Size == 4 && numBytes > uint.MaxValue)
				throw new ArgumentOutOfRangeException(nameof(numBytes), ResourceHelper.GetString("ArgumentOutOfRange_AddressSpace"));

			if (numBytes >= (ulong)Uninitialized)
				throw new ArgumentOutOfRangeException(nameof(numBytes), ResourceHelper.GetString("ArgumentOutOfRange_UIntPtrMax-1"));

			this.numBytes = (UIntPtr)numBytes;
		}

		/// <summary>
		/// Specifies the allocation size of the memory buffer by using the specified number of elements and element size. You must call this
		/// method before you use the SafeBuffer instance.
		/// </summary>
		/// <param name="numElements">The number of elements in the buffer.</param>
		/// <param name="sizeOfEachElement">The size of each element in the buffer.</param>
		public void Initialize(uint numElements, uint sizeOfEachElement) => Initialize((ulong)numElements * sizeOfEachElement);

		/// <summary>
		/// Defines the allocation size of the memory region by specifying the number of value types. You must call this method before you
		/// use the SafeBuffer instance.
		/// </summary>
		/// <typeparam name="T">The value type to allocate memory for.</typeparam>
		/// <param name="numElements">The number of elements of the value type to allocate memory for.</param>
		public void Initialize<T>(uint numElements) where T : struct => Initialize(numElements, AlignedSizeOf<T>());

		/// <summary>Reads a value type from memory at the specified offset.</summary>
		/// <typeparam name="T">The value type to read.</typeparam>
		/// <param name="byteOffset">The location from which to read the value type. You may have to consider alignment issues.</param>
		/// <returns>The value type that was read from memory.</returns>
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		public T Read<T>(ulong byteOffset) where T : struct => handle.ToStructure<T>(numBytes.ToUInt64(), (int)byteOffset);

		/// <summary>
		/// Reads the specified number of value types from memory starting at the offset, and writes them into an array starting at the index.
		/// </summary>
		/// <typeparam name="T">The value type to read.</typeparam>
		/// <param name="byteOffset">The location from which to start reading.</param>
		/// <param name="array">The output array to write to.</param>
		/// <param name="index">The location in the output array to begin writing to.</param>
		/// <param name="count">The number of value types to read from the input array and to write to the output array.</param>
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		public void ReadArray<T>(ulong byteOffset, T[] array, int index, int count) where T : struct
		{
			if (array == null)
				throw new ArgumentNullException(nameof(array), ResourceHelper.GetString("ArgumentNull_Buffer"));
			if (index < 0)
				throw new ArgumentOutOfRangeException(nameof(index), ResourceHelper.GetString("ArgumentOutOfRange_NeedNonNegNum"));
			if (count < 0)
				throw new ArgumentOutOfRangeException(nameof(count), ResourceHelper.GetString("ArgumentOutOfRange_NeedNonNegNum"));
			if (array.Length - index < count)
				throw new ArgumentException(ResourceHelper.GetString("Argument_InvalidOffLen"));

			if (numBytes == Uninitialized)
				throw NotInitialized();

			Array.Copy(handle.ToArray<T>(count, (int)byteOffset, numBytes.ToUInt64()), 0, array, index, count);
		}

		/// <summary>Releases a pointer that was obtained by the <see cref="AcquirePointer(ref byte*)"/> method.</summary>
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		public void ReleasePointer()
		{
			if (numBytes == Uninitialized)
				throw NotInitialized();

			DangerousRelease();
		}

		/// <summary>Writes a value type to memory at the given location.</summary>
		/// <typeparam name="T">The value type to write.</typeparam>
		/// <param name="byteOffset">The location at which to start writing. You may have to consider alignment issues.</param>
		/// <param name="value">The value to write.</param>
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		public void Write<T>(ulong byteOffset, T value) where T : struct
		{
			if (numBytes == Uninitialized)
				throw NotInitialized();

			handle.Write(value, (int)byteOffset, numBytes.ToUInt64());
		}

		/// <summary>
		/// Writes the specified number of value types to a memory location by reading bytes starting from the specified location in the
		/// input array.
		/// </summary>
		/// <typeparam name="T">The value type to write.</typeparam>
		/// <param name="byteOffset">The location in memory to write to.</param>
		/// <param name="array">The input array.</param>
		/// <param name="index">The offset in the array to start reading from.</param>
		/// <param name="count">The number of value types to write.</param>
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		public void WriteArray<T>(ulong byteOffset, T[] array, int index, int count) where T : struct
		{
			if (array == null)
				throw new ArgumentNullException(nameof(array), ResourceHelper.GetString("ArgumentNull_Buffer"));
			if (index < 0)
				throw new ArgumentOutOfRangeException(nameof(index), ResourceHelper.GetString("ArgumentOutOfRange_NeedNonNegNum"));
			if (count < 0)
				throw new ArgumentOutOfRangeException(nameof(count), ResourceHelper.GetString("ArgumentOutOfRange_NeedNonNegNum"));
			if (array.Length - index < count)
				throw new ArgumentException(ResourceHelper.GetString("Argument_InvalidOffLen"));

			if (numBytes == Uninitialized)
				throw NotInitialized();

			handle.Write(array, (int)byteOffset, numBytes.ToUInt64());
		}

		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		private static void NotEnoughRoom() => throw new ArgumentException(ResourceHelper.GetString("Arg_BufferTooSmall"));

		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
		private static InvalidOperationException NotInitialized() => new InvalidOperationException(ResourceHelper.GetString("InvalidOperation_MustCallInitialize"));

		internal static uint AlignedSizeOf<T>()
		{
			var size = SizeOf<T>();
			return (size == 1 || size == 2) ? size : (uint)((size + 3) & (~3));
		}

		internal static uint SizeOf<T>() => (uint)Marshal.SizeOf(typeof(T));
	}

	internal static class ResourceHelper
	{
		public static string GetString(string value, params object[] vars) => string.Format(Vanara.Properties.Resources.ResourceManager.GetString(value) ?? throw new InvalidOperationException(), vars);
	}
}

#endif