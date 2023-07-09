using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;
using Vanara.Extensions;

namespace Vanara.PInvoke;

public static partial class NetApi32
{
	/// <summary>
	/// The <c>NetApiBufferAllocate</c> function allocates memory from the heap. Use this function only when compatibility with the
	/// NetApiBufferFree function is required. Otherwise, use the memory management functions.
	/// </summary>
	/// <param name="ByteCount">Number of bytes to be allocated.</param>
	/// <param name="Buffer">Receives a pointer to the allocated buffer.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is NERR_Success.</para>
	/// <para>If the function fails, the return value is a system error code. For a list of error codes, see System Error Codes.</para>
	/// </returns>
	/// <remarks>
	/// <para>No special group membership is required to successfully execute the ApiBuffer functions.</para>
	/// <para>For more information, see Network Management Function Buffers and Network Management Function Buffer Lengths.</para>
	/// <para>Examples</para>
	/// <para>The following code sample demonstrates how to use the network management ApiBuffer functions.</para>
	/// <para>
	/// The sample first calls the <c>NetApiBufferAllocate</c> function to allocate memory and then the NetApiBufferSize function to
	/// retrieve the size of the allocated memory. Following this, the sample calls NetApiBufferReallocate to change the size of the
	/// memory allocation. Finally, the sample calls NetApiBufferFree to free the memory. In each case, the sample prints a message
	/// indicating success or failure.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmapibuf/nf-lmapibuf-netapibufferallocate NET_API_STATUS NET_API_FUNCTION
	// NetApiBufferAllocate( DWORD ByteCount, LPVOID *Buffer );
	[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("lmapibuf.h", MSDNShortId = "9ff1e3eb-9417-469f-a8c0-cdcda3cd9583")]
	public static extern Win32Error NetApiBufferAllocate(uint ByteCount, out SafeNetApiBuffer Buffer);

	/// <summary>
	/// The NetApiBufferFree function frees the memory that the NetApiBufferAllocate function allocates. Applications should also call
	/// NetApiBufferFree to free the memory that other network management functions use internally to return information.
	/// </summary>
	/// <param name="pBuf">
	/// A pointer to a buffer returned previously by another network management function or memory allocated by calling the
	/// NetApiBufferAllocate function.
	/// </param>
	/// <returns>
	/// If the function succeeds, the return value is NERR_Success. If the function fails, the return value is a system error code.
	/// </returns>
	[DllImport(Lib.NetApi32, ExactSpelling = true), SuppressUnmanagedCodeSecurity]
	[PInvokeData("lm.h", MSDNShortId = "aa370304")]
	public static extern Win32Error NetApiBufferFree(IntPtr pBuf);

	/// <summary>
	/// The <c>NetApiBufferReallocate</c> function changes the size of a buffer allocated by a previous call to the NetApiBufferAllocate function.
	/// </summary>
	/// <param name="OldBuffer">Pointer to the buffer returned by a call to the NetApiBufferAllocate function.</param>
	/// <param name="NewByteCount">Specifies the new size of the buffer, in bytes.</param>
	/// <param name="NewBuffer">Receives the pointer to the reallocated buffer.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is NERR_Success.</para>
	/// <para>If the function fails, the return value is a system error code. For a list of error codes, see System Error Codes.</para>
	/// </returns>
	/// <remarks>
	/// <para>No special group membership is required to successfully execute the ApiBuffer functions.</para>
	/// <para>For a code sample that demonstrates how to use the network management ApiBuffer functions, see NetApiBufferAllocate.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmapibuf/nf-lmapibuf-netapibufferreallocate NET_API_STATUS NET_API_FUNCTION
	// NetApiBufferReallocate( _Frees_ptr_opt_ LPVOID OldBuffer, DWORD NewByteCount, LPVOID *NewBuffer );
	[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("lmapibuf.h", MSDNShortId = "61153de0-33d3-4c83-a8aa-a7179252328c")]
	public static extern Win32Error NetApiBufferReallocate(IntPtr OldBuffer, uint NewByteCount, out IntPtr NewBuffer);

	/// <summary>
	/// The <c>NetApiBufferSize</c> function returns the size, in bytes, of a buffer allocated by a call to the NetApiBufferAllocate function.
	/// </summary>
	/// <param name="Buffer">Pointer to a buffer returned by the NetApiBufferAllocate function.</param>
	/// <param name="ByteCount">Receives the size of the buffer, in bytes.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is NERR_Success.</para>
	/// <para>If the function fails, the return value is a system error code. For a list of error codes, see System Error Codes.</para>
	/// </returns>
	/// <remarks>
	/// <para>No special group membership is required to successfully execute the ApiBuffer functions.</para>
	/// <para>For a code sample that demonstrates how to use the network management ApiBuffer functions, see NetApiBufferAllocate.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/lmapibuf/nf-lmapibuf-netapibuffersize NET_API_STATUS NET_API_FUNCTION
	// NetApiBufferSize( LPVOID Buffer, LPDWORD ByteCount );
	[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("lmapibuf.h", MSDNShortId = "0c28feeb-00a3-4ad5-b85f-96326515fae2")]
	public static extern Win32Error NetApiBufferSize(IntPtr Buffer, out uint ByteCount);

	/// <summary>Provides a <see cref="SafeHandle"/> to a buffer that releases a created handle at disposal using NetApiBufferFree.</summary>
	public class SafeNetApiBuffer : SafeHANDLE
	{
		/// <summary>Initializes a new instance of the <see cref="SafeNetApiBuffer"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		public SafeNetApiBuffer(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Initializes a new instance of the <see cref="SafeNetApiBuffer"/> class.</summary>
		private SafeNetApiBuffer() : base() { }

		/// <summary>
		/// Gets or sets the size of the buffer in bytes. When setting, this reallocates the existing buffer and does not guarantee that
		/// the currently allocated memory will be untouched or destroyed.
		/// </summary>
		/// <value>The size of the allocated memory in bytes.</value>
		public uint Size
		{
			get { var err = NetApiBufferSize(handle, out var sz); return err.Succeeded ? sz : throw err.GetException()!; }
			set { NetApiBufferReallocate(handle, value, out var h).ThrowIfFailed(); SetHandle(h); }
		}

		/// <summary>Allocates memory for a new <see cref="SafeNetApiBuffer"/>.</summary>
		/// <param name="size">The size of the buffer in bytes.</param>
		/// <returns>A new instance of <see cref="SafeNetApiBuffer"/> with the requested number of bytes allocated.</returns>
		public static SafeNetApiBuffer Allocate(uint size)
		{
			NetApiBufferAllocate(size, out var b).ThrowIfFailed();
			return b;
		}

		/// <summary>Extracts a list of structures.</summary>
		/// <typeparam name="T">The type of the structure.</typeparam>
		/// <param name="count">The count of structures in the list.</param>
		/// <returns>The list of structures.</returns>
		public IEnumerable<T?> ToIEnum<T>(int count) => handle.ToIEnum<T>(count);

		/// <inheritdoc/>
		public override string? ToString() => StringHelper.GetString(handle);

		/// <summary>Extracts a list of strings. Used by <see cref="DsAddressToSiteNames"/>.</summary>
		/// <param name="count">The number of elements in the list.</param>
		/// <returns>The list of strings.</returns>
		public IEnumerable<string?> ToStringEnum(int count) => handle.ToStringEnum(count);

		/// <summary>Returns an extracted structure from this buffer.</summary>
		/// <typeparam name="T">The structure type to extract.</typeparam>
		/// <returns>Extracted structure or default(T) if the buffer is invalid.</returns>
		public T ToStructure<T>() where T : struct => IsInvalid ? default : handle.ToStructure<T>();

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() => NetApiBufferFree(handle) == 0;
	}

	/// <summary>A custom marshaler for functions using NetApiBuffer so that managed strings can be used.</summary>
	/// <seealso cref="ICustomMarshaler"/>
	internal class NetApiBufferUnicodeStringMarshaler : ICustomMarshaler
	{
		public static ICustomMarshaler GetInstance(string cookie) => new NetApiBufferUnicodeStringMarshaler();

		public void CleanUpManagedData(object ManagedObj) { }

		public void CleanUpNativeData(IntPtr pNativeData) { }

		public int GetNativeDataSize() => 0;

		public IntPtr MarshalManagedToNative(object ManagedObj) => throw new NotImplementedException();

		public object MarshalNativeToManaged(IntPtr pNativeData)
		{
			if (pNativeData == IntPtr.Zero) return string.Empty;
			try { return StringHelper.GetString(pNativeData, CharSet.Unicode) ?? string.Empty; }
			finally { NetApiBufferFree(pNativeData); }
		}
	}
}