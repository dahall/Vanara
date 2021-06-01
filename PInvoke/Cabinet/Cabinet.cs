using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	/// <summary>Items from the cabinet.dll</summary>
	public static partial class Cabinet
	{
		/// <summary>A callback that allocates memory.</summary>
		/// <param name="UserContext">The user context.</param>
		/// <param name="Size">The size.</param>
		/// <returns>The allocated memory pointer.</returns>
		public delegate IntPtr PFN_COMPRESS_ALLOCATE([In] IntPtr UserContext, [In] SizeT Size);

		/// <summary>A callback that frees memory.</summary>
		/// <param name="UserContext">The user context.</param>
		/// <param name="Memory">The pointer to the memory to free.</param>
		public delegate void PFN_COMPRESS_FREE([In] IntPtr UserContext, [In] IntPtr Memory);

		/// <summary>The type of compression algorithm and mode to be used by this compressor.</summary>
		[PInvokeData("compressapi.h", MSDNShortId = "782b3c08-158a-4bbd-89a5-c20666cbfb94")]
		[Flags]
		public enum COMPRESS_ALGORITHM
		{
			/// <summary>The compress algorithm invalid</summary>
			COMPRESS_ALGORITHM_INVALID = 0,

			/// <summary>Undocumented</summary>
			COMPRESS_ALGORITHM_NULL = 1,

			/// <summary>MSZIP compression algorithm</summary>
			COMPRESS_ALGORITHM_MSZIP = 2,

			/// <summary>XPRESS compression algorithm</summary>
			COMPRESS_ALGORITHM_XPRESS = 3,

			/// <summary>XPRESS compression algorithm with Huffman encoding</summary>
			COMPRESS_ALGORITHM_XPRESS_HUFF = 4,

			/// <summary>LZMS compression algorithm</summary>
			COMPRESS_ALGORITHM_LZMS = 5,

			/// <summary>Create a block mode compressor</summary>
			COMPRESS_RAW = 1 << 29
		}

		/// <summary>The values of this enumeration identify the type of information class being set or retrieved.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/compressapi/ne-compressapi-compress_information_class typedef enum {
		// COMPRESS_INFORMATION_CLASS_INVALID, COMPRESS_INFORMATION_CLASS_BLOCK_SIZE, COMPRESS_INFORMATION_CLASS_LEVEL } ;
		[PInvokeData("compressapi.h", MSDNShortId = "ebdcbe03-b7fb-4dec-b906-086f8fe9be4c")]
		public enum COMPRESS_INFORMATION_CLASS
		{
			/// <summary>Invalid information class</summary>
			COMPRESS_INFORMATION_CLASS_INVALID,

			/// <summary>
			/// Customized block size. The value specified may be from 65536 to 67108864 bytes. This value can be used only with the LZMS
			/// compression algorithm. A minimum size of 1 MB is suggested to get a better compression ratio. An information class of this
			/// type is sizeof(DWORD).
			/// </summary>
			COMPRESS_INFORMATION_CLASS_BLOCK_SIZE,

			/// <summary>
			/// Desired level of compression. The default value is (DWORD)0. The value (DWORD)1 can improve the compression ratio with a
			/// slightly slower compression speed. This value can be used only with the XPRESS compression algorithm or the XPRESS with
			/// Huffman encoding compression algorithm. An information class of this type is sizeof(DWORD).
			/// </summary>
			COMPRESS_INFORMATION_CLASS_LEVEL,
		}

		/// <summary>Call to close an open <c>COMPRESSOR_HANDLE</c>.</summary>
		/// <param name="CompressorHandle">
		/// Handle to the compressor to be closed. This is the handle to the compressor that was returned by CreateCompressor.
		/// </param>
		/// <returns>
		/// If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error
		/// information, call GetLastError.
		/// </returns>
		/// <remarks>
		/// If the compression algorithm fails for some internal reason, the error from GetLastError can be <c>ERROR_FUNCTION_FAILED</c>. If
		/// the system cannot locate the compression algorithm handle, the error can be <c>ERROR_INVALID_HANDLE</c>.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/compressapi/nf-compressapi-closecompressor BOOL CloseCompressor(
		// COMPRESSOR_HANDLE CompressorHandle );
		[DllImport(Lib.Cabinet, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("compressapi.h", MSDNShortId = "098cf0b9-cd42-4a40-b30f-d7364d067e41")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CloseCompressor(COMPRESSOR_HANDLE CompressorHandle);

		/// <summary>Call to close an open <c>DECOMPRESSOR_HANDLE</c>.</summary>
		/// <param name="DecompressorHandle">
		/// Handle to the decompressor to be closed. This is the handle to the compressor that was returned by CreateDecompressor.
		/// </param>
		/// <returns>
		/// If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error
		/// information, call GetLastError.
		/// </returns>
		/// <remarks>
		/// If the compression algorithm fails for some internal reason, the error from GetLastError can be <c>ERROR_FUNCTION_FAILED</c>. If
		/// the system cannot locate the compression algorithm handle, the error can be <c>ERROR_INVALID_HANDLE</c>.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/compressapi/nf-compressapi-closedecompressor BOOL CloseDecompressor(
		// DECOMPRESSOR_HANDLE DecompressorHandle );
		[DllImport(Lib.Cabinet, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("compressapi.h", MSDNShortId = "bcc4b342-9b84-43c6-aac0-c8f8ea5089c8")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CloseDecompressor(DECOMPRESSOR_HANDLE DecompressorHandle);

		/// <summary>Takes a block of information and compresses it.</summary>
		/// <param name="CompressorHandle">Handle to a compressor returned by CreateCompressor.</param>
		/// <param name="UncompressedData">
		/// Contains the block of information that is to be compressed. The size in bytes of the uncompressed block is given by UncompressedDataSize.
		/// </param>
		/// <param name="UncompressedDataSize">Size in bytes of the uncompressed information.</param>
		/// <param name="CompressedBuffer">
		/// The buffer that receives the compressed information. The maximum size in bytes of the buffer is given by CompressedBufferSize.
		/// </param>
		/// <param name="CompressedBufferSize">Maximum size in bytes of the buffer that receives the compressed information.</param>
		/// <param name="CompressedDataSize">Actual size in bytes of the compressed information received.</param>
		/// <returns>
		/// If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error
		/// information, call GetLastError.
		/// </returns>
		/// <remarks>
		/// <para>
		/// If the compression algorithm fails for some internal reason, the error from GetLastError can be <c>ERROR_FUNCTION_FAILED</c>. If
		/// the system cannot locate the compression algorithm handle, the error can be <c>ERROR_INVALID_HANDLE</c>. If the output buffer is
		/// too small to hold the compressed data, the error can be <c>ERROR_INSUFFICIENT_BUFFER</c>.
		/// </para>
		/// <para>
		/// If CompressedBuffer output buffer is too small to hold the compressed data, the function fails and the error from GetLastError
		/// can be <c>ERROR_INSUFFICIENT_BUFFER</c>. In this case, the CompressedDataSize parameter receives with the size that the
		/// CompressedBuffer needs to be to guarantee success for that input buffer. You can set CompressedBufferSize to zero to determine
		/// the size of the output buffer to allocate.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/compressapi/nf-compressapi-compress BOOL Compress( COMPRESSOR_HANDLE
		// CompressorHandle, LPCVOID UncompressedData, SIZE_T UncompressedDataSize, PVOID CompressedBuffer, SIZE_T CompressedBufferSize,
		// PSIZE_T CompressedDataSize );
		[DllImport(Lib.Cabinet, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("compressapi.h", MSDNShortId = "0e32501c-5213-43e6-88ca-1e424181d7a2")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool Compress(COMPRESSOR_HANDLE CompressorHandle, IntPtr UncompressedData, SizeT UncompressedDataSize, IntPtr CompressedBuffer, SizeT CompressedBufferSize, out SizeT CompressedDataSize);

		/// <summary>Generates a new <c>COMPRESSOR_HANDLE</c>.</summary>
		/// <param name="Algorithm">
		/// <para>The type of compression algorithm and mode to be used by this compressor.</para>
		/// <para>
		/// This parameter can have one of the following values optionally combined with the <c>COMPRESS_RAW</c> flag. Use a "bitwise OR"
		/// operator to include <c>COMPRESS_RAW</c> and to create a block mode compressor. If <c>COMPRESS_RAW</c> is not included, the
		/// Compression API creates a buffer mode compressor. For more information about selecting a compression algorithm and mode, see
		/// Using the Compression API.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>COMPRESS_ALGORITHM_MSZIP 2</term>
		/// <term>MSZIP compression algorithm</term>
		/// </item>
		/// <item>
		/// <term>COMPRESS_ALGORITHM_XPRESS 3</term>
		/// <term>XPRESS compression algorithm</term>
		/// </item>
		/// <item>
		/// <term>COMPRESS_ALGORITHM_XPRESS_HUFF 4</term>
		/// <term>XPRESS compression algorithm with Huffman encoding</term>
		/// </item>
		/// <item>
		/// <term>COMPRESS_ALGORITHM_LZMS 5</term>
		/// <term>LZMS compression algorithm</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="AllocationRoutines">Optional memory allocation and deallocation routines in a COMPRESS_ALLOCATION_ROUTINES structure.</param>
		/// <param name="CompressorHandle">If the function succeeds, the handle to the specified compressor.</param>
		/// <returns>
		/// If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error
		/// information, call GetLastError.
		/// </returns>
		/// <remarks>
		/// If the compression algorithm fails for some internal reason, the error from GetLastError can be <c>ERROR_FUNCTION_FAILED</c>. If
		/// the system can find no compression algorithm matching the specified name and version, the error can be <c>ERROR_NOT_SUPPORTED</c>.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/compressapi/nf-compressapi-createcompressor BOOL CreateCompressor( DWORD
		// Algorithm, PCOMPRESS_ALLOCATION_ROUTINES AllocationRoutines, PCOMPRESSOR_HANDLE CompressorHandle );
		[DllImport(Lib.Cabinet, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("compressapi.h", MSDNShortId = "782b3c08-158a-4bbd-89a5-c20666cbfb94")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CreateCompressor(COMPRESS_ALGORITHM Algorithm, in COMPRESS_ALLOCATION_ROUTINES AllocationRoutines, out SafeCOMPRESSOR_HANDLE CompressorHandle);

		/// <summary>Generates a new <c>COMPRESSOR_HANDLE</c>.</summary>
		/// <param name="Algorithm">
		/// <para>The type of compression algorithm and mode to be used by this compressor.</para>
		/// <para>
		/// This parameter can have one of the following values optionally combined with the <c>COMPRESS_RAW</c> flag. Use a "bitwise OR"
		/// operator to include <c>COMPRESS_RAW</c> and to create a block mode compressor. If <c>COMPRESS_RAW</c> is not included, the
		/// Compression API creates a buffer mode compressor. For more information about selecting a compression algorithm and mode, see
		/// Using the Compression API.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>COMPRESS_ALGORITHM_MSZIP 2</term>
		/// <term>MSZIP compression algorithm</term>
		/// </item>
		/// <item>
		/// <term>COMPRESS_ALGORITHM_XPRESS 3</term>
		/// <term>XPRESS compression algorithm</term>
		/// </item>
		/// <item>
		/// <term>COMPRESS_ALGORITHM_XPRESS_HUFF 4</term>
		/// <term>XPRESS compression algorithm with Huffman encoding</term>
		/// </item>
		/// <item>
		/// <term>COMPRESS_ALGORITHM_LZMS 5</term>
		/// <term>LZMS compression algorithm</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="AllocationRoutines">Optional memory allocation and deallocation routines in a COMPRESS_ALLOCATION_ROUTINES structure.</param>
		/// <param name="CompressorHandle">If the function succeeds, the handle to the specified compressor.</param>
		/// <returns>
		/// If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error
		/// information, call GetLastError.
		/// </returns>
		/// <remarks>
		/// If the compression algorithm fails for some internal reason, the error from GetLastError can be <c>ERROR_FUNCTION_FAILED</c>. If
		/// the system can find no compression algorithm matching the specified name and version, the error can be <c>ERROR_NOT_SUPPORTED</c>.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/compressapi/nf-compressapi-createcompressor BOOL CreateCompressor( DWORD
		// Algorithm, PCOMPRESS_ALLOCATION_ROUTINES AllocationRoutines, PCOMPRESSOR_HANDLE CompressorHandle );
		[DllImport(Lib.Cabinet, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("compressapi.h", MSDNShortId = "782b3c08-158a-4bbd-89a5-c20666cbfb94")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CreateCompressor(COMPRESS_ALGORITHM Algorithm, [Optional] IntPtr AllocationRoutines, out SafeCOMPRESSOR_HANDLE CompressorHandle);

		/// <summary>Generates a new <c>DECOMPRESSOR_HANDLE</c>.</summary>
		/// <param name="Algorithm">
		/// <para>The type of compression algorithm and mode to be used by this decompressor.</para>
		/// <para>
		/// This parameter can have one of the following values optionally combined with the <c>COMPRESS_RAW</c> flag. Use a "bitwise OR"
		/// operator to include <c>COMPRESS_RAW</c> and to create a block mode decompressor. If <c>COMPRESS_RAW</c> is not included, the
		/// Compression API creates a buffer mode decompressor. For more information about selecting a compression algorithm and mode, see
		/// Using the Compression API.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>COMPRESS_ALGORITHM_MSZIP 2</term>
		/// <term>MSZIP compression algorithm</term>
		/// </item>
		/// <item>
		/// <term>COMPRESS_ALGORITHM_XPRESS 3</term>
		/// <term>XPRESS compression algorithm</term>
		/// </item>
		/// <item>
		/// <term>COMPRESS_ALGORITHM_XPRESS_HUFF 4</term>
		/// <term>XPRESS compression algorithm with Huffman encoding</term>
		/// </item>
		/// <item>
		/// <term>COMPRESS_ALGORITHM_LZMS 5</term>
		/// <term>LZMS compression algorithm</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="AllocationRoutines">Optional memory allocation and deallocation routines in a COMPRESS_ALLOCATION_ROUTINES structure.</param>
		/// <param name="DecompressorHandle">If the function succeeds, the handle to the specified decompressor.</param>
		/// <returns>
		/// If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error
		/// information, call GetLastError.
		/// </returns>
		/// <remarks>
		/// If the compression algorithm fails for some internal reason, the error from GetLastError can be <c>ERROR_FUNCTION_FAILED</c>. If
		/// the system can find no compression algorithm matching the specified name and version, the error can be <c>ERROR_NOT_SUPPORTED</c>.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/compressapi/nf-compressapi-createdecompressor BOOL CreateDecompressor( DWORD
		// Algorithm, PCOMPRESS_ALLOCATION_ROUTINES AllocationRoutines, PDECOMPRESSOR_HANDLE DecompressorHandle );
		[DllImport(Lib.Cabinet, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("compressapi.h", MSDNShortId = "a30b3ebe-24ef-4615-a555-a0383b46cd15")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CreateDecompressor(COMPRESS_ALGORITHM Algorithm, in COMPRESS_ALLOCATION_ROUTINES AllocationRoutines, out SafeDECOMPRESSOR_HANDLE DecompressorHandle);

		/// <summary>Generates a new <c>DECOMPRESSOR_HANDLE</c>.</summary>
		/// <param name="Algorithm">
		/// <para>The type of compression algorithm and mode to be used by this decompressor.</para>
		/// <para>
		/// This parameter can have one of the following values optionally combined with the <c>COMPRESS_RAW</c> flag. Use a "bitwise OR"
		/// operator to include <c>COMPRESS_RAW</c> and to create a block mode decompressor. If <c>COMPRESS_RAW</c> is not included, the
		/// Compression API creates a buffer mode decompressor. For more information about selecting a compression algorithm and mode, see
		/// Using the Compression API.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>COMPRESS_ALGORITHM_MSZIP 2</term>
		/// <term>MSZIP compression algorithm</term>
		/// </item>
		/// <item>
		/// <term>COMPRESS_ALGORITHM_XPRESS 3</term>
		/// <term>XPRESS compression algorithm</term>
		/// </item>
		/// <item>
		/// <term>COMPRESS_ALGORITHM_XPRESS_HUFF 4</term>
		/// <term>XPRESS compression algorithm with Huffman encoding</term>
		/// </item>
		/// <item>
		/// <term>COMPRESS_ALGORITHM_LZMS 5</term>
		/// <term>LZMS compression algorithm</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="AllocationRoutines">Optional memory allocation and deallocation routines in a COMPRESS_ALLOCATION_ROUTINES structure.</param>
		/// <param name="DecompressorHandle">If the function succeeds, the handle to the specified decompressor.</param>
		/// <returns>
		/// If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error
		/// information, call GetLastError.
		/// </returns>
		/// <remarks>
		/// If the compression algorithm fails for some internal reason, the error from GetLastError can be <c>ERROR_FUNCTION_FAILED</c>. If
		/// the system can find no compression algorithm matching the specified name and version, the error can be <c>ERROR_NOT_SUPPORTED</c>.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/compressapi/nf-compressapi-createdecompressor BOOL CreateDecompressor( DWORD
		// Algorithm, PCOMPRESS_ALLOCATION_ROUTINES AllocationRoutines, PDECOMPRESSOR_HANDLE DecompressorHandle );
		[DllImport(Lib.Cabinet, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("compressapi.h", MSDNShortId = "a30b3ebe-24ef-4615-a555-a0383b46cd15")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CreateDecompressor(COMPRESS_ALGORITHM Algorithm, [Optional] IntPtr AllocationRoutines, out SafeDECOMPRESSOR_HANDLE DecompressorHandle);

		/// <summary>Takes a block of compressed information and decompresses it.</summary>
		/// <param name="DecompressorHandle">Handle to a decompressor returned by CreateDecompressor.</param>
		/// <param name="CompressedData">
		/// Contains the block of information that is to be decompressed. The size in bytes of the compressed block is given by CompressedDataSize.
		/// </param>
		/// <param name="CompressedDataSize">The size in bytes of the compressed information.</param>
		/// <param name="UncompressedBuffer">
		/// The buffer that receives the uncompressed information. The size in bytes of the buffer is given by UncompressedBufferSize.
		/// </param>
		/// <param name="UncompressedBufferSize">Size in bytes of the buffer that receives the uncompressed information.</param>
		/// <param name="UncompressedDataSize">Actual size in bytes of the uncompressed information received.</param>
		/// <returns>
		/// If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error
		/// information, call GetLastError.
		/// </returns>
		/// <remarks>
		/// <para>
		/// If the block of compressed data pointed to by CompressedData is corrupted, the function can fail and the error from GetLastError
		/// can be <c>ERROR_BAD_COMPRESSION_BUFFER</c>. It is also possible that the function will produce a block of uncompressed data that
		/// does not match the original data.
		/// </para>
		/// <para>
		/// It is recommended that compressors and decompressors not use the <c>COMPRESS_RAW</c> flag. If the compressor is created with the
		/// <c>COMPRESS_RAW</c> flag, the decompressor must also be created with the <c>COMPRESS_RAW</c> flag.
		/// </para>
		/// <para>
		/// If the compressor and decompressor are created using the <c>COMPRESS_RAW</c> flag, the value of UncompressedBufferSize must be
		/// exactly equal to the original size of the uncompressed data and not just the size of the output buffer. This means you should
		/// save the exact original size of the uncompressed data, as well as the compressed data and compressed size, when using the
		/// <c>COMPRESS_RAW</c> flag. If UncompressedBufferSize does not equal the original size of the uncompressed data, the uncompressed
		/// data will not match the original data. In this case, the function can return success or it can return <c>ERROR_BAD_COMPRESSION_BUFFER</c>.
		/// </para>
		/// <para>
		/// If the <c>COMPRESS_RAW</c> flag is not used, UncompressedBufferSize is not required to be exactly equal to the original size of
		/// the uncompressed data. In this case, UncompressedDataSize returns the original size of the uncompressed data. If
		/// UncompressedBufferSize is smaller than the original data size, the function will fail and set UncompressedDataSize to the size of
		/// the original data and the error from GetLastError is <c>ERROR_INSUFFICIENT_BUFFER</c>.
		/// </para>
		/// <para>
		/// To determine how large the UncompressedBuffer needs to be, call the function with UncompressedBufferSize set to zero. In this
		/// case, the function will fail and set UncompressedDataSize to the size of the original data and the error from GetLastError is
		/// <c>ERROR_INSUFFICIENT_BUFFER</c>. Note that the original size returned by the function is extracted from the buffer itself and
		/// should be treated as untrusted and tested against reasonable limits.
		/// </para>
		/// <para>
		/// If the function is called with the CompressedDataSize parameter set to zero, the function fails and the error from GetLastError
		/// is <c>ERROR_INSUFFICIENT_BUFFER</c>. When it fails the function returns with UncompressedDataSize set to a value that you can use
		/// to avoid allocating too large a buffer for the compressed data. You must know the maximum possible size of the original data to
		/// use this method.
		/// </para>
		/// <para>
		/// If you set CompressedDataSize to zero, and set UncompressedBufferSize to the maximum possible size of the original uncompressed
		/// data, the <c>Decompress</c> function will fail as described and the value of UncompressedDataSize will be set to the maximum size
		/// for the compressed data buffer.
		/// </para>
		/// <para>
		/// If the compression algorithm fails for some internal reason, the error from GetLastError can be <c>ERROR_FUNCTION_FAILED</c>. If
		/// the system cannot locate the compression algorithm handle, the error can be <c>ERROR_INVALID_HANDLE</c>. If the output buffer is
		/// too small to hold the uncompressed data, the error can be <c>ERROR_INSUFFICIENT_BUFFER</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/compressapi/nf-compressapi-decompress BOOL Decompress( DECOMPRESSOR_HANDLE
		// DecompressorHandle, LPCVOID CompressedData, SIZE_T CompressedDataSize, PVOID UncompressedBuffer, SIZE_T UncompressedBufferSize,
		// PSIZE_T UncompressedDataSize );
		[DllImport(Lib.Cabinet, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("compressapi.h", MSDNShortId = "654b88c7-14f2-43d4-8850-675ea303b439")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool Decompress(DECOMPRESSOR_HANDLE DecompressorHandle, IntPtr CompressedData, SizeT CompressedDataSize, IntPtr UncompressedBuffer, SizeT UncompressedBufferSize, out SizeT UncompressedDataSize);

		/// <summary>Queries a compressor for information for a particular compression algorithm.</summary>
		/// <param name="CompressorHandle">Handle to the compressor being queried for information.</param>
		/// <param name="CompressInformationClass">A value of the COMPRESS_INFORMATION_CLASS enumeration that identifies the type of information.</param>
		/// <param name="CompressInformation">
		/// Information for the compression algorithm written as bytes. The maximum size in bytes of this information is given by CompressInformationSize.
		/// </param>
		/// <param name="CompressInformationSize">Maximum size in bytes of the information.</param>
		/// <returns>
		/// If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error
		/// information, call GetLastError.
		/// </returns>
		/// <remarks>
		/// If the compression algorithm fails for some internal reason, the error from GetLastError can be <c>ERROR_FUNCTION_FAILED</c>. If
		/// the system cannot locate the compression algorithm handle, the error can be <c>ERROR_INVALID_HANDLE</c>. If the compression
		/// algorithm does not allow the information class, the error can be <c>ERROR_UNSUPPORTED_TYPE</c>. If the buffer is to small to hold
		/// the value, the error can be <c>ERROR_INSUFFICIENT_BUFFER</c>.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/compressapi/nf-compressapi-querycompressorinformation BOOL
		// QueryCompressorInformation( COMPRESSOR_HANDLE CompressorHandle, COMPRESS_INFORMATION_CLASS CompressInformationClass, PVOID
		// CompressInformation, SIZE_T CompressInformationSize );
		[DllImport(Lib.Cabinet, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("compressapi.h", MSDNShortId = "90b2ef29-c488-4d32-a315-312b25a0e585")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool QueryCompressorInformation(COMPRESSOR_HANDLE CompressorHandle, COMPRESS_INFORMATION_CLASS CompressInformationClass, IntPtr CompressInformation, SizeT CompressInformationSize);

		/// <summary>Use this function to query information about a particular compression algorithm.</summary>
		/// <param name="DecompressorHandle">Handle to the decompressor being queried for information.</param>
		/// <param name="CompressInformationClass">A value of the COMPRESS_INFORMATION_CLASS enumeration that identifies the type of information.</param>
		/// <param name="CompressInformation">
		/// Information for the compression algorithm written as bytes. The maximum size in bytes of this information is given by CompressInformationSize.
		/// </param>
		/// <param name="CompressInformationSize">Maximum size in bytes of the information.</param>
		/// <returns>Returns <c>TRUE</c> to indicate success and <c>FALSE</c> otherwise. Call GetLastError to determine cause of failure.</returns>
		/// <remarks>
		/// If the compression algorithm fails for some internal reason, the error from GetLastError can be <c>ERROR_FUNCTION_FAILED</c>. If
		/// the system cannot locate the compression algorithm handle, the error can be <c>ERROR_INVALID_HANDLE</c>. If the compression
		/// algorithm does not allow the information class, the error can be <c>ERROR_UNSUPPORTED_TYPE</c>. If the buffer is to small to hold
		/// the value, the error can be <c>ERROR_INSUFFICIENT_BUFFER</c>.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/compressapi/nf-compressapi-querydecompressorinformation BOOL
		// QueryDecompressorInformation( DECOMPRESSOR_HANDLE DecompressorHandle, COMPRESS_INFORMATION_CLASS CompressInformationClass, PVOID
		// CompressInformation, SIZE_T CompressInformationSize );
		[DllImport(Lib.Cabinet, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("compressapi.h", MSDNShortId = "85b39c04-2145-45d2-be59-24615905353d")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool QueryDecompressorInformation(DECOMPRESSOR_HANDLE DecompressorHandle, COMPRESS_INFORMATION_CLASS CompressInformationClass, IntPtr CompressInformation, SizeT CompressInformationSize);

		/// <summary>
		/// Prepares the compressor for the compression of a new stream. The compressor object retains properties set with
		/// SetCompressorInformation. The sequence of blocks generated is independent of previous blocks.
		/// </summary>
		/// <param name="CompressorHandle">Handle to the compressor returned by CreateCompressor.</param>
		/// <returns>
		/// If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error
		/// information, call GetLastError.
		/// </returns>
		/// <remarks>
		/// If the compression algorithm fails for some internal reason, the error from GetLastError can be <c>ERROR_FUNCTION_FAILED</c>. If
		/// the system cannot locate the compression algorithm handle, the error can be <c>ERROR_INVALID_HANDLE</c>.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/compressapi/nf-compressapi-resetcompressor BOOL ResetCompressor(
		// COMPRESSOR_HANDLE CompressorHandle );
		[DllImport(Lib.Cabinet, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("compressapi.h", MSDNShortId = "1ea542e0-7236-4158-9578-f5d55f8c7f8e")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ResetCompressor(COMPRESSOR_HANDLE CompressorHandle);

		/// <summary>Prepares the decompressor for the decompression of a new stream.</summary>
		/// <param name="DecompressorHandle">Handle to the decompressor returned by CreateDecompressor.</param>
		/// <returns>
		/// If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error
		/// information, call GetLastError.
		/// </returns>
		/// <remarks>
		/// If the compression algorithm fails for some internal reason, the error from GetLastError can be <c>ERROR_FUNCTION_FAILED</c>. If
		/// the system cannot locate the compression algorithm handle, the error can be <c>ERROR_INVALID_HANDLE</c>.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/compressapi/nf-compressapi-resetdecompressor BOOL ResetDecompressor(
		// DECOMPRESSOR_HANDLE DecompressorHandle );
		[DllImport(Lib.Cabinet, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("compressapi.h", MSDNShortId = "45243dac-bf07-4fee-aaf3-1482f4f009d9")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool ResetDecompressor(DECOMPRESSOR_HANDLE DecompressorHandle);

		/// <summary>Sets information in a compressor for a particular compression algorithm.</summary>
		/// <param name="CompressorHandle">Handle to the compressor.</param>
		/// <param name="CompressInformationClass">
		/// A value that identifies the type of information. of the enumeration that identifies the type of information.
		/// </param>
		/// <param name="CompressInformation">The information being set read as bytes. The maximum size in bytes is given by CompressInformationSize.</param>
		/// <param name="CompressInformationSize">Maximum size of the information in bytes.</param>
		/// <returns>
		/// If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error
		/// information, call GetLastError.
		/// </returns>
		/// <remarks>
		/// If the compression algorithm fails for some internal reason, the error from GetLastError can be <c>ERROR_FUNCTION_FAILED</c>. If
		/// the system cannot locate the compression algorithm handle, the error can be <c>ERROR_INVALID_HANDLE</c>. If the compression
		/// algorithm does not allow changing the value of this information class, the error can be <c>ERROR_NOT_SUPPORTED</c>. If the
		/// compression algorithm does not allow the information class, the error can be <c>ERROR_UNSUPPORTED_TYPE</c>.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/compressapi/nf-compressapi-setcompressorinformation BOOL
		// SetCompressorInformation( COMPRESSOR_HANDLE CompressorHandle, COMPRESS_INFORMATION_CLASS CompressInformationClass, LPCVOID
		// CompressInformation, SIZE_T CompressInformationSize );
		[DllImport(Lib.Cabinet, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("compressapi.h", MSDNShortId = "f8c2c425-9b21-4fe3-8b81-d8bf3cd8ec5b")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetCompressorInformation(COMPRESSOR_HANDLE CompressorHandle, COMPRESS_INFORMATION_CLASS CompressInformationClass, IntPtr CompressInformation, SizeT CompressInformationSize);

		/// <summary>Sets information in a decompressor for a particular compression algorithm.</summary>
		/// <param name="DecompressorHandle">Handle to the decompressor.</param>
		/// <param name="CompressInformationClass">
		/// A value that identifies the type of information. of the enumeration that identifies the type of information.
		/// </param>
		/// <param name="CompressInformation">The information being set read as bytes. The maximum size in bytes is given by CompressInformationSize.</param>
		/// <param name="CompressInformationSize">Maximum size of the information in bytes.</param>
		/// <returns>
		/// If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error
		/// information, call GetLastError.
		/// </returns>
		/// <remarks>
		/// If the compression algorithm fails for some internal reason, the error from GetLastError can be <c>ERROR_FUNCTION_FAILED</c>. If
		/// the system cannot locate the compression algorithm handle, the error can be <c>ERROR_INVALID_HANDLE</c>. If the compression
		/// algorithm does not allow changing the value of this information class, the error can be <c>ERROR_NOT_SUPPORTED</c>. If the
		/// compression algorithm does not allow the information class, the error can be <c>ERROR_UNSUPPORTED_TYPE</c>.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/compressapi/nf-compressapi-setdecompressorinformation BOOL
		// SetDecompressorInformation( DECOMPRESSOR_HANDLE DecompressorHandle, COMPRESS_INFORMATION_CLASS CompressInformationClass, LPCVOID
		// CompressInformation, SIZE_T CompressInformationSize );
		[DllImport(Lib.Cabinet, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("compressapi.h", MSDNShortId = "804B73D3-E68E-43A3-8F23-6A46ABDECB23")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SetDecompressorInformation(DECOMPRESSOR_HANDLE DecompressorHandle, COMPRESS_INFORMATION_CLASS CompressInformationClass, IntPtr CompressInformation, SizeT CompressInformationSize);

		/// <summary>A structure containing optional memory allocation and deallocation routines.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/compressapi/ns-compressapi-compress_allocation_routines typedef struct
		// _COMPRESS_ALLOCATION_ROUTINES { PFN_COMPRESS_ALLOCATE Allocate; PFN_COMPRESS_FREE Free; PVOID UserContext; }
		// COMPRESS_ALLOCATION_ROUTINES, *PCOMPRESS_ALLOCATION_ROUTINES;
		[PInvokeData("compressapi.h", MSDNShortId = "91f541c8-36b9-4ec2-ae37-0b41aa6fd623")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct COMPRESS_ALLOCATION_ROUTINES
		{
			/// <summary>Callback that allocates memory.</summary>
			public PFN_COMPRESS_ALLOCATE Allocate;

			/// <summary>Callback that deallocates memory.</summary>
			public PFN_COMPRESS_FREE Free;

			/// <summary>A pointer to context information for the allocation or deallocation routine defined by the user.</summary>
			public IntPtr UserContext;
		}

		/// <summary>Provides a handle to a compressor.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct COMPRESSOR_HANDLE : IHandle
		{
			private IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="COMPRESSOR_HANDLE"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public COMPRESSOR_HANDLE(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="COMPRESSOR_HANDLE"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static COMPRESSOR_HANDLE NULL => new(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="COMPRESSOR_HANDLE"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(COMPRESSOR_HANDLE h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="COMPRESSOR_HANDLE"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator COMPRESSOR_HANDLE(IntPtr h) => new(h);

			/// <summary>Implements the operator !=.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(COMPRESSOR_HANDLE h1, COMPRESSOR_HANDLE h2) => !(h1 == h2);

			/// <summary>Implements the operator ==.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(COMPRESSOR_HANDLE h1, COMPRESSOR_HANDLE h2) => h1.Equals(h2);

			/// <inheritdoc/>
			public override bool Equals(object obj) => obj is COMPRESSOR_HANDLE h ? handle == h.handle : false;

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
		}

		/// <summary>Provides a handle to a decompressor.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct DECOMPRESSOR_HANDLE : IHandle
		{
			private IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="DECOMPRESSOR_HANDLE"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public DECOMPRESSOR_HANDLE(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="DECOMPRESSOR_HANDLE"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static DECOMPRESSOR_HANDLE NULL => new(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="DECOMPRESSOR_HANDLE"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(DECOMPRESSOR_HANDLE h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="DECOMPRESSOR_HANDLE"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator DECOMPRESSOR_HANDLE(IntPtr h) => new(h);

			/// <summary>Implements the operator !=.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(DECOMPRESSOR_HANDLE h1, DECOMPRESSOR_HANDLE h2) => !(h1 == h2);

			/// <summary>Implements the operator ==.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(DECOMPRESSOR_HANDLE h1, DECOMPRESSOR_HANDLE h2) => h1.Equals(h2);

			/// <inheritdoc/>
			public override bool Equals(object obj) => obj is DECOMPRESSOR_HANDLE h ? handle == h.handle : false;

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
		}

		/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="COMPRESSOR_HANDLE"/> that is disposed using <see cref="CloseCompressor"/>.</summary>
		public class SafeCOMPRESSOR_HANDLE : SafeHANDLE
		{
			/// <summary>Initializes a new instance of the <see cref="SafeCOMPRESSOR_HANDLE"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafeCOMPRESSOR_HANDLE(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="SafeCOMPRESSOR_HANDLE"/> class.</summary>
			private SafeCOMPRESSOR_HANDLE() : base() { }

			/// <summary>Performs an implicit conversion from <see cref="SafeCOMPRESSOR_HANDLE"/> to <see cref="COMPRESSOR_HANDLE"/>.</summary>
			/// <param name="h">The safe handle instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator COMPRESSOR_HANDLE(SafeCOMPRESSOR_HANDLE h) => h.handle;

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() => CloseCompressor(this);
		}

		/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="DECOMPRESSOR_HANDLE"/> that is disposed using <see cref="CloseDecompressor"/>.</summary>
		public class SafeDECOMPRESSOR_HANDLE : SafeHANDLE
		{
			/// <summary>Initializes a new instance of the <see cref="SafeDECOMPRESSOR_HANDLE"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafeDECOMPRESSOR_HANDLE(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="SafeDECOMPRESSOR_HANDLE"/> class.</summary>
			private SafeDECOMPRESSOR_HANDLE() : base() { }

			/// <summary>Performs an implicit conversion from <see cref="SafeDECOMPRESSOR_HANDLE"/> to <see cref="DECOMPRESSOR_HANDLE"/>.</summary>
			/// <param name="h">The safe handle instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator DECOMPRESSOR_HANDLE(SafeDECOMPRESSOR_HANDLE h) => h.handle;

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() => CloseDecompressor(this);
		}
	}
}