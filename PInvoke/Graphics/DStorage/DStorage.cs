using static Vanara.PInvoke.Kernel32;
using static Vanara.PInvoke.D3D;

namespace Vanara.PInvoke;

/// <summary>Defines the constants, structures, and interfaces that are used by the DirectStorage API.</summary>
public static partial class DStorage
{
	private const string Lib_DirectStorage = "dstorage.dll";

	static DStorage()
	{
		StaticFieldValueHash.AddFields<HRESULT, int, DSTORAGE_ERROR>(/*Lib_DirectStorage*/);
		//ErrorHelper.AddErrorMessageLookupFunction<DSTORAGE_ERROR>(GetOleDbErrMsg);
	}

	/// <summary>
	/// Disables built-in decompression.
	///
	/// Set NumBuiltInCpuDecompressionThreads in DSTORAGE_CONFIGURATION to this value to disable built-in decompression. No decompression
	/// threads will be created and the title is fully responsible for checking the custom decompression queue and pulling off ALL entries
	/// to decompress.
	/// </summary>
	public const int DSTORAGE_DISABLE_BUILTIN_CPU_DECOMPRESSION = -1;

	/// <summary>The maximum valid queue capacity.</summary>
	public const int DSTORAGE_MAX_QUEUE_CAPACITY = 0x2000;

	/// <summary>The minimum valid queue capacity.</summary>
	public const int DSTORAGE_MIN_QUEUE_CAPACITY = 0x80;

	/// <summary>The maximum number of characters that will be stored for a request's name.</summary>
	public const int DSTORAGE_REQUEST_MAX_NAME = 64;

	/// <summary>The DStorage SDK version</summary>
	public const int DSTORAGE_SDK_VERSION = 203;

	/// <summary>The type of command that failed, as reported by DSTORAGE_ERROR_FIRST_FAILURE.</summary>
	public enum DSTORAGE_COMMAND_TYPE
	{
		/// <summary/>
		DSTORAGE_COMMAND_TYPE_NONE = -1,

		/// <summary/>
		DSTORAGE_COMMAND_TYPE_REQUEST = 0,

		/// <summary/>
		DSTORAGE_COMMAND_TYPE_STATUS = 1,

		/// <summary/>
		DSTORAGE_COMMAND_TYPE_SIGNAL = 2,

		/// <summary/>
		DSTORAGE_COMMAND_TYPE_EVENT = 3,
	}

	/// <summary>Settings controlling DirectStorage compression codec behavior.</summary>
	public enum DSTORAGE_COMPRESSION : int
	{
		/// <summary>Compress data at a fast rate which may not yield the best compression ratio.</summary>
		DSTORAGE_COMPRESSION_FASTEST = -1,

		/// <summary>Compress data at an average rate with a good compression ratio.</summary>
		DSTORAGE_COMPRESSION_DEFAULT = 0,

		/// <summary>Compress data at slow rate with the best compression ratio.</summary>
		DSTORAGE_COMPRESSION_BEST_RATIO = 1
	}

	/// <summary>
	/// The type of compression format used at the decompression stage. Your application can implement custom decompressors, starting from DSTORAGE_CUSTOM_COMPRESSION_0.
	/// </summary>
	public enum DSTORAGE_COMPRESSION_FORMAT : byte
	{
		/// <summary>The data is uncompressed.</summary>
		DSTORAGE_COMPRESSION_FORMAT_NONE = 0,

		/// <summary>The data is compressed using the built-in GDEFLATE format.</summary>
		DSTORAGE_COMPRESSION_FORMAT_GDEFLATE = 1,

		/// <summary>
		/// The data is stored in an application-defined custom format. The application must use IDStorageCustomDecompressionQueue to
		/// implement custom decompression. Additional custom compression formats can be used, for example `(DSTORAGE_CUSTOM_COMPRESSION_0 + 1)`.
		/// </summary>
		DSTORAGE_CUSTOM_COMPRESSION_0 = 0x80,
	}

	/// <summary>Flags returned with GetCompressionSupport that describe the features used by the runtime to decompress content.</summary>
	[Flags]
	public enum DSTORAGE_COMPRESSION_SUPPORT : uint
	{
		/// <summary>None</summary>
		DSTORAGE_COMPRESSION_SUPPORT_NONE = 0x0,

		/// <summary>Optimized driver support for GPU decompression will be used.</summary>
		DSTORAGE_COMPRESSION_SUPPORT_GPU_OPTIMIZED = 0x01,

		/// <summary>
		/// Built-in GPU decompression fallback shader will be used. This can occur if optimized driver support is not available and the
		/// D3D12 device used for this DirectStorage queue supports the required capabilities.
		/// </summary>
		DSTORAGE_COMPRESSION_SUPPORT_GPU_FALLBACK = 0x02,

		/// <summary>
		/// CPU fallback implementation will be used. This can occur if:
		/// * Optimized driver support and built-in GPU decompression is not available.
		/// * GPU decompression support has been explicitly disabled using DSTORAGE_CONFIGURATION.
		/// * DirectStorage runtime encounters a failure during initialization of its GPU decompression system.
		/// </summary>
		DSTORAGE_COMPRESSION_SUPPORT_CPU_FALLBACK = 0x04,

		/// <summary>Executes work on a compute queue.</summary>
		DSTORAGE_COMPRESSION_SUPPORT_USES_COMPUTE_QUEUE = 0x08,

		/// <summary>Executes work on a copy queue.</summary>
		DSTORAGE_COMPRESSION_SUPPORT_USES_COPY_QUEUE = 0x010,
	}

	/// <summary>Specifies information about a custom decompression request.</summary>
	[Flags]
	public enum DSTORAGE_CUSTOM_DECOMPRESSION_FLAGS : uint
	{
		/// <summary>No additional information.</summary>
		DSTORAGE_CUSTOM_DECOMPRESSION_FLAG_NONE = 0x00,

		/// <summary>The uncompressed destination buffer is located in an upload heap, and is marked as WRITE_COMBINED.</summary>
		DSTORAGE_CUSTOM_DECOMPRESSION_FLAG_DEST_IN_UPLOAD_HEAP = 0x01,
	}

	/// <summary>Flags controlling DirectStorage debug layer.</summary>
	[Flags]
	public enum DSTORAGE_DEBUG
	{
		/// <summary>DirectStorage debug layer is disabled.</summary>
		DSTORAGE_DEBUG_NONE = 0x00,

		/// <summary>Print error information to a debugger.</summary>
		DSTORAGE_DEBUG_SHOW_ERRORS = 0x01,

		/// <summary>Trigger a debug break each time an error is detected.</summary>
		DSTORAGE_DEBUG_BREAK_ON_ERROR = 0x02,

		/// <summary>Include object names in ETW events.</summary>
		DSTORAGE_DEBUG_RECORD_OBJECT_NAMES = 0x04
	}

	/// <summary>
	/// Errors defined for DirectStorage. These errors are returned by DirectStorage functions and can be used to determine the cause of a failure.
	/// </summary>
	[PInvokeData("dstorageerr.h")]
	public enum DSTORAGE_ERROR
	{
		/// <summary>DStorage is already running exclusively.</summary>
		E_DSTORAGE_ALREADY_RUNNING = unchecked((int)0x89240001),

		/// <summary>DStorage is not running.</summary>
		E_DSTORAGE_NOT_RUNNING = unchecked((int)0x89240002),

		/// <summary>Invalid queue capacity parameter.</summary>
		E_DSTORAGE_INVALID_QUEUE_CAPACITY = unchecked((int)0x89240003),

		/// <summary>The specified XVD is not on a supported NVMe device. This error only applies to Xbox.</summary>
		E_DSTORAGE_XVD_DEVICE_NOT_SUPPORTED = unchecked((int)0x89240004),

		/// <summary>The specified XVD is not on a supported volume. This error only applies to Xbox.</summary>
		E_DSTORAGE_UNSUPPORTED_VOLUME = unchecked((int)0x89240005),

		/// <summary>The specified offset and length exceeds the size of the file.</summary>
		E_DSTORAGE_END_OF_FILE = unchecked((int)0x89240007),

		/// <summary>The IO request is too large.</summary>
		E_DSTORAGE_REQUEST_TOO_LARGE = unchecked((int)0x89240008),

		/// <summary>The destination buffer for the DStorage request is not accessible.</summary>
		E_DSTORAGE_ACCESS_VIOLATION = unchecked((int)0x89240009),

		/// <summary>The file is not supported by DStorage. Possible reasons include the file is a sparse file, or is compressed in NTFS. This error only applies to Xbox.</summary>
		E_DSTORAGE_UNSUPPORTED_FILE = unchecked((int)0x8924000A),

		/// <summary>The file is not open.</summary>
		E_DSTORAGE_FILE_NOT_OPEN = unchecked((int)0x8924000B),

		/// <summary>A reserved field is not set to 0.</summary>
		E_DSTORAGE_RESERVED_FIELDS = unchecked((int)0x8924000C),

		/// <summary>The request has invalid BCPack decompression mode. This error only applies to Xbox.</summary>
		E_DSTORAGE_INVALID_BCPACK_MODE = unchecked((int)0x8924000D),

		/// <summary>The request has invalid swizzle mode. This error only applies to Xbox.</summary>
		E_DSTORAGE_INVALID_SWIZZLE_MODE = unchecked((int)0x8924000E),

		/// <summary>The request's destination size is invalid. If no decompression is used, it must be equal to the request's length; If decompression is used, it must be larger than the request's length.</summary>
		E_DSTORAGE_INVALID_DESTINATION_SIZE = unchecked((int)0x8924000F),

		/// <summary>The request targets a queue that is closed.</summary>
		E_DSTORAGE_QUEUE_CLOSED = unchecked((int)0x89240010),

		/// <summary>The volume is formatted with an unsupported cluster size. This error only applies to Xbox.</summary>
		E_DSTORAGE_INVALID_CLUSTER_SIZE = unchecked((int)0x89240011),

		/// <summary>The number of queues has reached the maximum limit.</summary>
		E_DSTORAGE_TOO_MANY_QUEUES = unchecked((int)0x89240012),

		/// <summary>Invalid priority is specified for the queue.</summary>
		E_DSTORAGE_INVALID_QUEUE_PRIORITY = unchecked((int)0x89240013),

		/// <summary>The number of files has reached the maximum limit.</summary>
		E_DSTORAGE_TOO_MANY_FILES = unchecked((int)0x89240014),

		/// <summary>The index parameter is out of bound.</summary>
		E_DSTORAGE_INDEX_BOUND = unchecked((int)0x89240015),

		/// <summary>The IO operation has timed out.</summary>
		E_DSTORAGE_IO_TIMEOUT = unchecked((int)0x89240016),

		/// <summary>The specified file has not been opened.</summary>
		E_DSTORAGE_INVALID_FILE_HANDLE = unchecked((int)0x89240017),

		/// <summary>This GDK preview is deprecated. Update to a supported GDK version. This error only applies to Xbox.</summary>
		E_DSTORAGE_DEPRECATED_PREVIEW_GDK = unchecked((int)0x89240018),

		/// <summary>The specified XVD is not registered or unmounted. This error only applies to Xbox.</summary>
		E_DSTORAGE_XVD_NOT_REGISTERED = unchecked((int)0x89240019),

		/// <summary>The request has invalid file offset for the specified decompression mode.</summary>
		E_DSTORAGE_INVALID_FILE_OFFSET = unchecked((int)0x8924001A),

		/// <summary>A memory source request was enqueued into a file source queue, or a file source request was enqueued into a memory source queue.</summary>
		E_DSTORAGE_INVALID_SOURCE_TYPE = unchecked((int)0x8924001B),

		/// <summary>The request has invalid intermediate size for the specified decompression modes. This error only applies to Xbox.</summary>
		E_DSTORAGE_INVALID_INTERMEDIATE_SIZE = unchecked((int)0x8924001C),

		/// <summary>This console generation doesn't support DirectStorage. This error only applies to Xbox.</summary>
		E_DSTORAGE_SYSTEM_NOT_SUPPORTED = unchecked((int)0x8924001D),

		/// <summary>Staging buffer size can only be changed when no queue is created and no file is opened.</summary>
		E_DSTORAGE_STAGING_BUFFER_LOCKED = unchecked((int)0x8924001F),

		/// <summary>The specified staging buffer size is not valid.</summary>
		E_DSTORAGE_INVALID_STAGING_BUFFER_SIZE = unchecked((int)0x89240020),

		/// <summary>The staging buffer isn't large enough to perform this operation.</summary>
		E_DSTORAGE_STAGING_BUFFER_TOO_SMALL = unchecked((int)0x89240021),

		/// <summary>The fence is not valid or has been released.</summary>
		E_DSTORAGE_INVALID_FENCE = unchecked((int)0x89240022),

		/// <summary>The status array is not valid or has been released.</summary>
		E_DSTORAGE_INVALID_STATUS_ARRAY = unchecked((int)0x89240023),

		/// <summary>Invalid priority is specified for the queue. Only DSTORAGE_PRIORITY_REALTIME is a valid priority for a memory queue.</summary>
		E_DSTORAGE_INVALID_MEMORY_QUEUE_PRIORITY = unchecked((int)0x89240024),

		/// <summary>A generic error has happened during decompression.</summary>
		E_DSTORAGE_DECOMPRESSION_ERROR = unchecked((int)0x89240030),

		/// <summary>ZLIB header is corrupted. This error only applies to Xbox.</summary>
		E_DSTORAGE_ZLIB_BAD_HEADER = unchecked((int)0x89240031),

		/// <summary>ZLIB compressed data is corrupted/invalid. This error only applies to Xbox.</summary>
		E_DSTORAGE_ZLIB_BAD_DATA = unchecked((int)0x89240032),

		/// <summary>Block-level ADLER parity check failed during ZLIB decompression. This error only applies to Xbox.</summary>
		E_DSTORAGE_ZLIB_PARITY_FAIL = unchecked((int)0x89240033),

		/// <summary>BCPack header is corrupted. This error only applies to Xbox.</summary>
		E_DSTORAGE_BCPACK_BAD_HEADER = unchecked((int)0x89240034),

		/// <summary>BCPack decoder has generated more data than expected, most likely due to corrupted bitstream. This error only applies to Xbox.</summary>
		E_DSTORAGE_BCPACK_BAD_DATA = unchecked((int)0x89240035),

		/// <summary>A generic error has happened during decryption. This error only applies to Xbox.</summary>
		E_DSTORAGE_DECRYPTION_ERROR = unchecked((int)0x89240036),

		/// <summary>A generic error has happened during copy operation. This error only applies to Xbox.</summary>
		E_DSTORAGE_PASSTHROUGH_ERROR = unchecked((int)0x89240037),

		/// <summary>The file is too fragmented to be accessed by DStorage. This error can only happen with files overly fragmented on a writable volume. This error only applies to Xbox.</summary>
		E_DSTORAGE_FILE_TOO_FRAGMENTED = unchecked((int)0x89240038),

		/// <summary>The size of the resulting compressed data is too large for DirectStorage to decompress successfully on the GPU.</summary>
		E_DSTORAGE_COMPRESSED_DATA_TOO_LARGE = unchecked((int)0x89240039),

		/// <summary>A gpu memory destination request was enqueued into a queue that was created without a D3D device or the destination type is unknown.</summary>
		E_DSTORAGE_INVALID_DESTINATION_TYPE = unchecked((int)0x89240040),

		/// <summary>ForceFileBuffering was enabled without disabling BypassIO.</summary>
		E_DSTORAGE_FILEBUFFERING_REQUIRES_DISABLED_BYPASSIO = unchecked((int)0x89240041),
	}

	/// <summary>Flags used with GetRequests1 when requesting items from the custom decompression queue.</summary>
	[Flags]
	public enum DSTORAGE_GET_REQUEST_FLAGS : uint
	{
		/// <summary>Request entries that use custom decompression formats &gt;= DSTORAGE_CUSTOM_COMPRESSION_0.</summary>
		DSTORAGE_GET_REQUEST_FLAG_SELECT_CUSTOM = 0x01,

		/// <summary>Request entries that use built in compression formats that DirectStorage understands.</summary>
		DSTORAGE_GET_REQUEST_FLAG_SELECT_BUILTIN = 0x02,

		/// <summary>Request all entries. This includes custom decompression and built-in compressed formats.</summary>
		DSTORAGE_GET_REQUEST_FLAG_SELECT_ALL = DSTORAGE_GET_REQUEST_FLAG_SELECT_CUSTOM | DSTORAGE_GET_REQUEST_FLAG_SELECT_BUILTIN
	}

	/// <summary>The priority of a DirectStorage queue.</summary>
	public enum DSTORAGE_PRIORITY : sbyte
	{
		/// <summary/>
		DSTORAGE_PRIORITY_LOW = -1,

		/// <summary/>
		DSTORAGE_PRIORITY_NORMAL = 0,

		/// <summary/>
		DSTORAGE_PRIORITY_HIGH = 1,

		/// <summary/>
		DSTORAGE_PRIORITY_REALTIME = 2,

		/// <summary>The following values can be used for iterating over all priority levels.</summary>
		DSTORAGE_PRIORITY_FIRST = DSTORAGE_PRIORITY_LOW,

		/// <summary/>
		DSTORAGE_PRIORITY_LAST = DSTORAGE_PRIORITY_REALTIME,

		/// <summary/>
		DSTORAGE_PRIORITY_COUNT = 4
	}

	/// <summary>The destination type of a DirectStorage request.</summary>
	public enum DSTORAGE_REQUEST_DESTINATION_TYPE : ulong
	{
		/// <summary>The destination of the DirectStorage request is a block of memory.</summary>
		DSTORAGE_REQUEST_DESTINATION_MEMORY = 0,

		/// <summary>The destination of the DirectStorage request is an ID3D12Resource that is a buffer.</summary>
		DSTORAGE_REQUEST_DESTINATION_BUFFER = 1,

		/// <summary>The destination of the DirectStorage request is an ID3D12Resource that is a texture.</summary>
		DSTORAGE_REQUEST_DESTINATION_TEXTURE_REGION = 2,

		/// <summary>
		/// The destination of the DirectStorage request is an ID3D12Resource that is a texture that will receive all subresources in a
		/// single request.
		/// </summary>
		DSTORAGE_REQUEST_DESTINATION_MULTIPLE_SUBRESOURCES = 3,

		/// <summary>The destination of the DirectStorage request is an ID3D12Resource that is tiled.</summary>
		DSTORAGE_REQUEST_DESTINATION_TILES = 4
	}

	/// <summary>The source type of a DirectStorage request.</summary>
	public enum DSTORAGE_REQUEST_SOURCE_TYPE : ulong
	{
		/// <summary>The source of the DirectStorage request is a file.</summary>
		DSTORAGE_REQUEST_SOURCE_FILE = 0,

		/// <summary>The source of the DirectStorage request is a block of memory.</summary>
		DSTORAGE_REQUEST_SOURCE_MEMORY = 1,
	}

	/// <summary>Defines common staging buffer sizes.</summary>
	public enum DSTORAGE_STAGING_BUFFER_SIZE : uint
	{
		/// <summary>
		/// There is no staging buffer. Use this value to force DirectStorage to deallocate any memory it has allocated for staging buffers.
		/// </summary>
		DSTORAGE_STAGING_BUFFER_SIZE_0 = 0,

		/// <summary>The default staging buffer size of 32MB.</summary>
		DSTORAGE_STAGING_BUFFER_SIZE_32MB = 32 * 1048576,
	}

	/// <summary>
	/// Represents the DirectStorage object for compressing and decompressing the buffers.
	///
	/// Use DStorageCreateCompressionCodec to get an instance of this.
	/// </summary>
	[ComImport, Guid("84ef5121-9b43-4d03-b5c1-cc34606b262d"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDStorageCompressionCodec
	{
		/// <summary>Compresses a buffer of data using a known compression format at the specifed compression level.</summary>
		/// <param name="uncompressedData">Points to a buffer containing uncompressed data.</param>
		/// <param name="uncompressedDataSize">Size, in bytes, of the uncompressed data buffer.</param>
		/// <param name="compressionSetting">Specifies the compression settings to use.</param>
		/// <param name="compressedBuffer">Points to a buffer where compressed data will be written.</param>
		/// <param name="compressedBufferSize">Size, in bytes, of the buffer which will receive the compressed data</param>
		/// <param name="compressedDataSize">Size, in bytes, of the actual size written to compressedBuffer</param>
		void CompressBuffer(IntPtr uncompressedData, SizeT uncompressedDataSize, DSTORAGE_COMPRESSION compressionSetting,
			IntPtr compressedBuffer, SizeT compressedBufferSize, out SizeT compressedDataSize);

		/// <summary>Decompresses data previously compressed using CompressBuffer.</summary>
		/// <param name="compressedData">Points to a buffer containing compressed data.</param>
		/// <param name="compressedDataSize">Size, in bytes, of the compressed data buffer.</param>
		/// <param name="uncompressedBuffer">Points to a buffer where uncompressed data will be written.</param>
		/// <param name="uncompressedBufferSize">Size, in bytes, of the buffer which will receive the uncompressed data</param>
		/// <param name="uncompressedDataSize">Size, in bytes, of the actual size written to uncompressedBuffer</param>
		void DecompressBuffer(IntPtr compressedData, SizeT compressedDataSize, IntPtr uncompressedBuffer, SizeT uncompressedBufferSize,
			out SizeT uncompressedDataSize);

		/// <summary>Returns an upper bound estimated size in bytes required to compress the specified data size.</summary>
		/// <param name="uncompressedDataSize">Size, in bytes, of the data to be compressed</param>
		[PreserveSig]
		SizeT CompressBufferBound(SizeT uncompressedDataSize);
	}

	/// <summary>
	/// A queue of decompression requests. This can be obtained using QueryInterface against the factory. Your application must take
	/// requests from this queue, decompress them, and report that decompression is complete. That allows an application to provide its own
	/// custom decompression.
	/// </summary>
	[ComImport, Guid("97179b2f-2c21-49ca-8291-4e1bf4a160df"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDStorageCustomDecompressionQueue
	{
		/// <summary>Obtains an event to wait on. This event is set when there are pending decompression requests.</summary>
		[PreserveSig]
		HEVENT GetEvent();

		/// <summary>
		/// Populates the given array of request structs with new pending requests. Your application must arrange to fulfill all these
		/// requests, and then call SetRequestResults to indicate completion.
		/// </summary>
		void GetRequests(uint maxRequests,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] DSTORAGE_CUSTOM_DECOMPRESSION_REQUEST[] requests,
			out uint numRequests);

		/// <summary>Your application calls this to indicate that requests have been completed.</summary>
		/// <param name="numResults">The number of results in `results`.</param>
		/// <param name="results">An array of results, the size is specified by `numResults.`</param>
		void SetRequestResults(uint numResults, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] DSTORAGE_CUSTOM_DECOMPRESSION_RESULT[] results);
	}

	/// <summary>
	/// An extension of IDStorageCustomDecompressionQueue that allows an application to retrieve specific types of custom decompression
	/// requests from the decompression queue.
	/// </summary>
	[ComImport, Guid("0D47C6C9-E61A-4706-93B4-68BFE3F4AA4A"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDStorageCustomDecompressionQueue1 : IDStorageCustomDecompressionQueue
	{
		/// <summary>
		/// Populates the given array of request structs with new pending requests based on the specified custom decompression request type.
		/// The application must arrange to fulfill all these requests, and then call SetRequestResults to indicate completion.
		/// </summary>
		[PreserveSig]
		HRESULT GetRequests1([In] DSTORAGE_GET_REQUEST_FLAGS flags, uint maxRequests,
			[Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] DSTORAGE_CUSTOM_DECOMPRESSION_REQUEST[] requests, out uint numRequests);
	}

	/// <summary>
	/// Represents the static DirectStorage object used to create DirectStorage queues, open files for DirectStorage access, and other
	/// global operations.
	/// </summary>
	[ComImport, Guid("6924ea0c-c3cd-4826-b10a-f64f4ed927c1"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDStorageFactory
	{
		/// <summary>Creates a DirectStorage queue object.</summary>
		/// <param name="desc">Descriptor to specify the properties of the queue.</param>
		/// <param name="riid">Specifies the DirectStorage queue interface, such as _uuidof(IDStorageQueue).</param>
		/// <param name="ppv">Receives the new queue created.</param>
		/// <returns>Standard HRESULT error code.</returns>
		[PreserveSig]
		HRESULT CreateQueue(in DSTORAGE_QUEUE_DESC desc, in Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object? ppv);

		/// <summary>Opens a file for DirectStorage access.</summary>
		/// <param name="path">Path of the file to be opened.</param>
		/// <param name="riid">Specifies the DirectStorage file interface, such as _uuidof(IDStorageFile).</param>
		/// <param name="ppv">Receives the new file opened.</param>
		/// <returns>Standard HRESULT error code.</returns>
		[PreserveSig]
		HRESULT OpenFile([In] string path, in Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object? ppv);

		/// <summary>Creates a DirectStorage status array object.</summary>
		/// <param name="capacity">Specifies the number of statuses that the array can hold.</param>
		/// <param name="name">
		/// Specifies object's name that will appear in the ETW events if enabled through the debug layer. This is an optional parameter.
		/// </param>
		/// <param name="riid">Specifies the DirectStorage status interface, such as _uuidof(IDStorageStatusArray).</param>
		/// <param name="ppv">Receives the new status array object created.</param>
		/// <returns>Standard HRESULT error code.</returns>
		[PreserveSig]
		HRESULT CreateStatusArray(uint capacity, [In, Optional] string name, in Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object? ppv);

		/// <summary>Sets flags used to control the debug layer.</summary>
		/// <param name="flags">A set of flags controlling the debug layer.</param>
		[PreserveSig]
		void SetDebugFlags(uint flags);

		/// <summary>
		/// Sets the size of staging buffer(s) used to temporarily store content loaded from the storage device before they are
		/// decompressed. If only uncompressed memory sourced queues writing to cpu memory destinations are used, then the staging buffer
		/// may be 0-sized.
		/// </summary>
		/// <param name="size">Size, in bytes, of each staging buffer used to complete a request.</param>
		/// <remarks>
		/// The default staging buffer is DSTORAGE_STAGING_BUFFER_SIZE_32MB. If multiple staging buffers are necessary to complete a
		/// request, then each separate staging buffer is allocated to this staging buffer size.
		///
		/// If the destination is a GPU resource, then some but not all of the staging buffers will be allocated from VRAM.
		///
		/// Requests that exceed the specified size to SetStagingBufferSize will fail.
		/// </remarks>
		void SetStagingBufferSize(uint size);
	}

	/// <summary>Represents a file to be accessed by DirectStorage.</summary>
	[ComImport, Guid("5de95e7b-955a-4868-a73c-243b29f4b8da"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDStorageFile
	{
		/// <summary>
		/// Closes the file, regardless of the reference count on this object.
		///
		/// After an IDStorageFile object is closed, it can no longer be used in DirectStorage requests. This does not modify the reference
		/// count on this object; Release() must be called as usual.
		/// </summary>
		[PreserveSig]
		void Close();

		/// <summary>Retrieves file information for an opened file.</summary>
		/// <returns>Receives the file information.</returns>
		BY_HANDLE_FILE_INFORMATION GetFileInformation();
	}

	/// <summary>Represents a DirectStorage queue to perform read operations.</summary>
	[ComImport, Guid("cfdbd83f-9e06-4fda-8ea5-69042137f49b"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDStorageQueue
	{
		/// <summary>
		/// Enqueues a read request to the queue. The request remains in the queue until Submit is called, or until the queue is half full.
		/// If there are no free entries in the queue, then the enqueue operation blocks until one becomes available.
		/// </summary>
		/// <param name="request">The read request to be queued.</param>
		[PreserveSig]
		void EnqueueRequest(in DSTORAGE_REQUEST request);

		/// <summary>
		/// Enqueues a status write. The status write happens when all requests before the status write entry complete. If there were
		/// failure(s) since the previous status write entry, then the HResult of the enqueued status entry stores the failure code of the
		/// first failed request in the enqueue order. If there are no free entries in the queue, then the enqueue operation blocks until
		/// one becomes available.
		/// </summary>
		/// <param name="statusArray">IDStorageStatusArray object.</param>
		/// <param name="index">Index of the status entry in the IDStorageStatusArray object to receive the status.</param>
		[PreserveSig]
		void EnqueueStatus([In] IDStorageStatusArray statusArray, uint index);

		/// <summary>
		/// Enqueues fence write. The fence write happens when all requests before the fence entry complete. If there are no free entries in
		/// the queue, then the enqueue operation will block until one becomes available.
		/// </summary>
		/// <param name="fence">An ID3D12Fence to be written.</param>
		/// <param name="value">The value to write to the fence.</param>
		[PreserveSig]
		void EnqueueSignal([In] ID3D12Fence fence, ulong value);

		/// <summary>Submits all requests enqueued so far to DirectStorage to be executed.</summary>
		[PreserveSig]
		void Submit();

		/// <summary>
		/// Attempts to cancel a group of previously enqueued read requests. All previously enqueued requests whose CancellationTag matches
		/// the formula (CancellationTag &amp; mask) == value will be cancelled. A cancelled request might or might not complete its
		/// original read request. A cancelled request is not counted as a failure in either IDStorageStatus or DSTORAGE_ERROR_RECORD.
		/// </summary>
		/// <param name="mask">The mask for the cancellation formula.</param>
		/// <param name="value">The value for the cancellation formula.</param>
		[PreserveSig]
		void CancelRequestsWithTag(ulong mask, ulong value);

		/// <summary>
		/// Closes the DirectStorage queue, regardless of the reference count on this object.
		///
		/// After the Close function returns, the queue will no longer complete any more requests, even if some are submitted. This does not
		/// modify the reference count on this object; Release() must be called as usual.
		/// </summary>
		[PreserveSig]
		void Close();

		/// <summary>
		/// Obtains an event to wait on. When there is any error happening for read requests in this queue, the event will be signaled, and
		/// you may call RetrieveErrorRecord to retrieve diagnostic information.
		/// </summary>
		/// <returns>HANDLE to an event.</returns>
		[PreserveSig]
		HEVENT GetErrorEvent();

		/// <summary>
		/// When the error event is signaled, this function can be called to retrieve a DSTORAGE_ERROR_RECORD. Once the error record is
		/// retrieved, this function should not be called until the next time the error event is signaled.
		/// </summary>
		/// <param name="record">Receives the error record.</param>
		[PreserveSig]
		void RetrieveErrorRecord(out DSTORAGE_ERROR_RECORD record);

		/// <summary>
		/// Obtains information about the queue. It includes the DSTORAGE_QUEUE_DESC structure used for the queue's creation as well as the
		/// number of empty slots and number of entries that need to be enqueued to trigger automatic submission.
		/// </summary>
		/// <param name="info">Receives the queue information.</param>
		[PreserveSig]
		void Query(out DSTORAGE_QUEUE_INFO info);
	}

	/// <summary>Represents a DirectStorage queue to perform read operations.</summary>
	[ComImport, Guid("dd2f482c-5eff-41e8-9c9e-d2374b278128"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDStorageQueue1 : IDStorageQueue
	{
		/// <summary>
		/// Enqueues an operation to set the specified event object to a signaled state. The event object is set when all requests before it
		/// complete. If there are no free entries in the queue the enqueue operation will block until one becomes available.
		/// </summary>
		/// <param name="handle">A handle to an event object.</param>
		[PreserveSig]
		void EnqueueSetEvent(HEVENT handle);
	}

	/// <summary>Represents a DirectStorage queue to perform read operations.</summary>
	[ComImport, Guid("b1c9d643-3a49-44a2-b46f-653649470d18"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDStorageQueue2 : IDStorageQueue1
	{
		/// <summary>
		/// Obtains support information about the queue for a specified compression format. It includes the chosen path that the
		/// DirectStorage runtime will use for decompression.
		/// </summary>
		/// <param name="format">Specifies the compression format to retrieve information about.</param>
		[PreserveSig]
		DSTORAGE_COMPRESSION_SUPPORT GetCompressionSupport(DSTORAGE_COMPRESSION_FORMAT format);
	}

	/// <summary>Represents an array of status entries to receive completion results for the read requests before them.</summary>
	/// <remarks>
	/// A status entry receives completion status for all the requests in the DStorageQueue between where it is enqueued and the previously
	/// enqueued status entry. Only when all requests enqueued before the status entry complete (that is, IsComplete for the entry returns
	/// true), the status entry can be enqueued again.
	/// </remarks>
	[ComImport, Guid("82397587-7cd5-453b-a02e-31379bd64656"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface IDStorageStatusArray
	{
		/// <summary>Returns a Boolean value indicating that all requests enqueued prior to the specified status entry have completed.</summary>
		/// <param name="index">Specifies the index of the status entry to retrieve.</param>
		/// <returns>Boolean value indicating completion.</returns>
		/// <remarks>This is equivalent to `GetHResult(index) != HRESULT.E_PENDING`.</remarks>
		[PreserveSig]
		bool IsComplete(uint index);

		/// <summary>
		/// Returns the HRESULT code of all requests between the specified status entry and the status entry enqueued before it.
		/// </summary>
		/// <param name="index">Specifies the index of the status entry to retrieve.</param>
		/// <returns>HRESULT code of the requests.</returns>
		/// <remarks>
		/// <list type="bullet">
		/// <item>
		/// <description>If any requests have not completed yet, the return value is HRESULT.E_PENDING.</description>
		/// </item>
		/// <item>
		/// <description>
		/// If all requests have completed, and there were failure(s), then the return value stores the failure code of the first failed
		/// request in the enqueue order.
		/// </description>
		/// </item>
		/// <item>
		/// <description>If all requests have completed successfully, then the return value is HRESULT.S_OK.</description>
		/// </item>
		/// </list>
		/// </remarks>
		[PreserveSig]
		HRESULT GetHResult(uint index);
	}

	/// <summary>
	/// Returns an object used to compress/decompress content. Compression codecs are not thread safe so multiple instances are required if
	/// the codecs need to be used by multiple threads.
	/// </summary>
	/// <param name="format">Specifies how the data is compressed.</param>
	/// <param name="numThreads">
	/// Specifies maximum number of threads this codec will use. Specifying 0 means to use the system's best guess at a good value.
	/// </param>
	/// <param name="riid">Specifies the DirectStorage compressor/decompressor interface, such as _uuidof(IDStorageCompressionCodec)</param>
	/// <param name="ppv">Receives the DirectStorage object.</param>
	/// <returns>Standard HRESULT error code.</returns>
	[DllImport(Lib_DirectStorage, ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
	public static extern HRESULT DStorageCreateCompressionCodec(DSTORAGE_COMPRESSION_FORMAT format, uint numThreads, in Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object? ppv);

	/// <summary>
	/// Returns the static DirectStorage factory object used to create DirectStorage queues, open files for DirectStorage access, and other
	/// global operations.
	/// </summary>
	/// <param name="riid">Specifies the DirectStorage factory interface, such as _uuidof(IDStorageFactory)</param>
	/// <param name="ppv">Receives the DirectStorage factory object.</param>
	/// <returns>Standard HRESULT error code.</returns>
	[DllImport(Lib_DirectStorage, ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
	public static extern HRESULT DStorageGetFactory(in Guid riid, [MarshalAs(UnmanagedType.IUnknown)] out object? ppv);

	/// <summary>
	/// Configures DirectStorage. This must be called before the first call to DStorageGetFactory. If this is not called, then default
	/// values are used.
	/// </summary>
	/// <param name="configuration">Specifies the configuration.</param>
	/// <returns>
	/// Standard HRESULT error code. The configuration can only be changed when no queue is created and no files are open,
	/// HRESULT.E_DSTORAGE_STAGING_BUFFER_LOCKED is returned if this is not the case.
	/// </returns>
	[DllImport(Lib_DirectStorage, ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
	public static extern HRESULT DStorageSetConfiguration(in DSTORAGE_CONFIGURATION configuration);

	/// <summary>
	/// Configures DirectStorage. This must be called before the first call to DStorageGetFactory. If this is not called, then default
	/// values are used.
	/// </summary>
	/// <param name="configuration">Specifies the configuration.</param>
	/// <returns>
	/// Standard HRESULT error code. The configuration can only be changed when no queue is created and no files are open,
	/// HRESULT.E_DSTORAGE_STAGING_BUFFER_LOCKED is returned if this is not the case.
	/// </returns>
	[DllImport(Lib_DirectStorage, ExactSpelling = true, CallingConvention = CallingConvention.Cdecl)]
	public static extern HRESULT DStorageSetConfiguration1(in DSTORAGE_CONFIGURATION1 configuration);

	/// <summary>DirectStorage Configuration. Zero initializing this will result in the default values.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct DSTORAGE_CONFIGURATION
	{
		/// <summary>
		/// Sets the number of threads to use for submitting IO operations. Specifying 0 means use the system's best guess at a good value.
		/// Default == 0.
		/// </summary>
		public uint NumSubmitThreads;

		/// <summary>
		/// Sets the number of threads to be used by the DirectStorage runtime to decompress data using the CPU for built-in compressed
		/// formats that cannot be decompressed using the GPU.
		///
		/// Specifying 0 means to use the system's best guess at a good value.
		///
		/// Specifying DSTORAGE_DISABLE_BUILTIN_CPU_DECOMPRESSION means no decompression threads will be created and the title is fully
		/// responsible for checking the custom decompression queue and pulling off ALL entries to decompress.
		///
		/// Default == 0.
		/// </summary>
		public int NumBuiltInCpuDecompressionThreads;

		/// <summary>
		/// Forces the use of the IO mapping layer, even when running on an operation system that doesn't require it. This may be useful
		/// during development, but should be set to the FALSE for release. Default=FALSE.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool ForceMappingLayer;

		/// <summary>
		/// Disables the use of the bypass IO optimization, even if it is available. This might be useful during development, but should be
		/// set to FALSE for release unless ForceFileBuffering is set to TRUE. Default == FALSE.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool DisableBypassIO;

		/// <summary>
		/// Disables the reporting of telemetry data when set to TRUE. Telemetry data is enabled by default in the DirectStorage runtime.
		/// Default == FALSE.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool DisableTelemetry;

		/// <summary>
		/// Disables the use of a decompression metacommand, even if one is available. This will force the runtime to use the built-in GPU
		/// decompression fallback shader. This may be useful during development, but should be set to the FALSE for release. Default == FALSE.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool DisableGpuDecompressionMetacommand;

		/// <summary>
		/// Disables the use of GPU based decompression, even if it is available. This will force the runtime to use the CPU. Default=FALSE.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool DisableGpuDecompression;
	}

	/// <summary>DirectStorage Configuration. Zero initializing this will result in the default values.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct DSTORAGE_CONFIGURATION1
	{
		/// <summary>
		/// Sets the number of threads to use for submitting IO operations. Specifying 0 means use the system's best guess at a good value.
		/// Default == 0.
		/// </summary>
		public uint NumSubmitThreads;

		/// <summary>
		/// Sets the number of threads to be used by the DirectStorage runtime to decompress data using the CPU for built-in compressed
		/// formats that cannot be decompressed using the GPU.
		///
		/// Specifying 0 means to use the system's best guess at a good value.
		///
		/// Specifying DSTORAGE_DISABLE_BUILTIN_CPU_DECOMPRESSION means no decompression threads will be created and the title is fully
		/// responsible for checking the custom decompression queue and pulling off ALL entries to decompress.
		///
		/// Default == 0.
		/// </summary>
		public int NumBuiltInCpuDecompressionThreads;

		/// <summary>
		/// Forces the use of the IO mapping layer, even when running on an operation system that doesn't require it. This may be useful
		/// during development, but should be set to the FALSE for release. Default=FALSE.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool ForceMappingLayer;

		/// <summary>
		/// Disables the use of the bypass IO optimization, even if it is available. This might be useful during development, but should be
		/// set to FALSE for release unless ForceFileBuffering is set to TRUE. Default == FALSE.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool DisableBypassIO;

		/// <summary>
		/// Disables the reporting of telemetry data when set to TRUE. Telemetry data is enabled by default in the DirectStorage runtime.
		/// Default == FALSE.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool DisableTelemetry;

		/// <summary>
		/// Disables the use of a decompression metacommand, even if one is available. This will force the runtime to use the built-in GPU
		/// decompression fallback shader. This may be useful during development, but should be set to the FALSE for release. Default == FALSE.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool DisableGpuDecompressionMetacommand;

		/// <summary>
		/// Disables the use of GPU based decompression, even if it is available. This will force the runtime to use the CPU. Default=FALSE.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool DisableGpuDecompression;

		/// <summary>
		/// Forces the use of the built-in file caching behaviors supported within the Windows operating system by not setting
		/// FILE_FLAG_NO_BUFFERING when opening files.
		///
		/// DisableBypassIO must be set to TRUE when using this option or E_DSTORAGE_FILEBUFFERING_REQUIRES_DISABLED_BYPASSIO will be returned.
		///
		/// It is the title's responsibility to know when to use this setting. This feature should ONLY be enabled for slower HDD drives
		/// that will benefit from the OS file buffering features.
		///
		/// WARNING: Enabling file buffering on high speed drives may reduce overall performance when reading from that drive because
		/// BypassIO is also disabled. Default=FALSE.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool ForceFileBuffering;
	}

	/// <summary>A custom decompression request. Use IDStorageCustomDecompressionQueue to retrieve these requests.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct DSTORAGE_CUSTOM_DECOMPRESSION_REQUEST
	{
		/// <summary>
		/// An identifier provided by DirectStorage. This should be used to identify the request in DSTORAGE_CUSTOM_DECOMPRESSION_RESULT.
		/// This identifier is unique among uncompleted requests, but may be reused after a request has completed.
		/// </summary>
		public ulong Id;

		/// <summary>
		/// The compression format. This will be &gt;= DSTORAGE_CUSTOM_COMPRESSION_0 if DSTORAGE_CUSTOM_DECOMPRESSION_CUSTOMONLY is used to
		/// retrieve requests.
		/// </summary>
		public DSTORAGE_COMPRESSION_FORMAT CompressionFormat;

		/// <summary>Reserved for future use.</summary>
		private unsafe fixed byte Reserved[3];

		/// <summary>Flags containing additional details about the decompression request.</summary>
		public DSTORAGE_CUSTOM_DECOMPRESSION_FLAGS Flags;

		/// <summary>The size of SrcBuffer in bytes.</summary>
		public ulong SrcSize;

		/// <summary>The compressed source buffer.</summary>
		public IntPtr SrcBuffer;

		/// <summary>The size of DstBuffer in bytes.</summary>
		public ulong DstSize;

		/// <summary>The uncompressed destination buffer. SrcBuffer should be decompressed to DstBuffer.</summary>
		public IntPtr DstBuffer;
	}

	/// <summary>
	/// The result of a custom decompression operation. If the request failed, then the Result code is passed back through the standard
	/// DirectStorage status/error reporting mechanism.
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct DSTORAGE_CUSTOM_DECOMPRESSION_RESULT
	{
		/// <summary>The identifier for the request, from DSTORAGE_CUSTOM_DECOMPRESSION_REQUEST.</summary>
		public ulong Id;

		/// <summary>The result of this decompression. S_OK indicates success.</summary>
		public HRESULT Result;
	}

	/// <summary>
	/// Describes the destination for a DirectStorage request. For a request, the value of `request.Options.DestinationType` determines
	/// which of these union fields is active.
	/// </summary>
	[StructLayout(LayoutKind.Explicit)]
	public struct DSTORAGE_DESTINATION
	{
		/// <summary/>
		[FieldOffset(0)]
		public DSTORAGE_DESTINATION_MEMORY Memory;

		/// <summary/>
		[FieldOffset(0)]
		public DSTORAGE_DESTINATION_BUFFER Buffer;

		/// <summary/>
		[FieldOffset(0)]
		public DSTORAGE_DESTINATION_TEXTURE_REGION Texture;

		/// <summary/>
		[FieldOffset(0)]
		public DSTORAGE_DESTINATION_MULTIPLE_SUBRESOURCES MultipleSubresources;

		/// <summary/>
		[FieldOffset(0)]
		public DSTORAGE_DESTINATION_TILES Tiles;
	}

	/// <summary>Describes the destination for a request with DestinationType DSTORAGE_REQUEST_DESTINATION_BUFFER.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct DSTORAGE_DESTINATION_BUFFER
	{
		/// <summary>Address of the resource to receive the final result of this request.</summary>
		public ID3D12Resource Resource;

		/// <summary>The offset, in bytes, in the buffer resource to write into.</summary>
		public ulong Offset;

		/// <summary>Number of bytes to write to the destination buffer.</summary>
		public uint Size;
	}

	/// <summary>Describes the destination for a request with DestinationType DSTORAGE_REQUEST_DESTINATION_MEMORY.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct DSTORAGE_DESTINATION_MEMORY
	{
		/// <summary>Address of the buffer to receive the final result of this request.</summary>
		public IntPtr Buffer;

		/// <summary>Number of bytes to write to the destination buffer.</summary>
		public uint Size;
	}

	/// <summary>Describes the destination for a request with DestinationType DSTORAGE_REQUEST_DESTINATION_MULTIPLE_SUBRESOURCES.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct DSTORAGE_DESTINATION_MULTIPLE_SUBRESOURCES
	{
		/// <summary>
		/// Address of the resource to receive the final result of this request. The source is expected to contain full data for all
		/// subresources, starting from FirstSubresource.
		/// </summary>
		public ID3D12Resource Resource;

		/// <summary>
		/// Describes the first subresource of the destination texture copy location. The subresource referred to must be in the
		/// D3D12_RESOURCE_STATE_COMMON state.
		/// </summary>
		public uint FirstSubresource;
	}

	/// <summary>Describes the destination for a request with DestinationType DSTORAGE_REQUEST_DESTINATION_TEXTURE_REGION.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct DSTORAGE_DESTINATION_TEXTURE_REGION
	{
		/// <summary>Address of the resource to receive the final result of this request.</summary>
		public ID3D12Resource Resource;

		/// <summary>
		/// Describes the destination texture copy location. The subresource referred to must be in the D3D12_RESOURCE_STATE_COMMON state.
		/// </summary>
		public uint SubresourceIndex;

		/// <summary>Coordinates and size of the destination region to copy, in pixels.</summary>
		public D3D12_BOX Region;
	}

	/// <summary>Describes the destination for a request with DestinationType DSTORAGE_REQUEST_DESTINATION_TILES.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct DSTORAGE_DESTINATION_TILES
	{
		/// <summary>
		/// Address of the resource to receive the final result of this request. The source buffer is expected to contain data arranged as
		/// if it were the source to a CopyTiles call with these parameters.
		/// </summary>
		public ID3D12Resource Resource;

		/// <summary>The starting coordinates of the tiled region.</summary>
		public D3D12_TILED_RESOURCE_COORDINATE TiledRegionStartCoordinate;

		/// <summary>The size of the tiled region.</summary>
		public D3D12_TILE_REGION_SIZE TileRegionSize;
	}

	/// <summary>Structure to receive the detailed record of the first failed DirectStorage request.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct DSTORAGE_ERROR_FIRST_FAILURE
	{
		/// <summary>The HRESULT code of the failure.</summary>
		public HRESULT HResult;

		/// <summary>Type of the Enqueue command that caused the failure.</summary>
		public DSTORAGE_COMMAND_TYPE CommandType;

		/// <summary>The parameters passed to the Enqueue call.</summary>
		public UNION union;

		/// <summary>The parameters passed to the Enqueue call.</summary>
		[StructLayout(LayoutKind.Explicit)]
		public struct UNION
		{
			/// <summary/>
			[FieldOffset(0)]
			public DSTORAGE_ERROR_PARAMETERS_REQUEST Request;

			/// <summary/>
			[FieldOffset(0)]
			public DSTORAGE_ERROR_PARAMETERS_STATUS Status;

			/// <summary/>
			[FieldOffset(0)]
			public DSTORAGE_ERROR_PARAMETERS_SIGNAL Signal;

			/// <summary/>
			[FieldOffset(0)]
			public DSTORAGE_ERROR_PARAMETERS_EVENT Event;
		}
	}

	/// <summary>The parameters passed to the EnqueueSetEvent call.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct DSTORAGE_ERROR_PARAMETERS_EVENT
	{
		/// <summary/>
		public HEVENT Handle;
	}

	/// <summary>The parameters passed to the EnqueueRequest call, and optional filename if the request is for a file source.</summary>
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct DSTORAGE_ERROR_PARAMETERS_REQUEST
	{
		/// <summary>For a file source request, the name of the file the request was targeted to.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
		public string Filename;

		private unsafe fixed byte _RequestName[DSTORAGE_REQUEST_MAX_NAME];

		/// <summary>The name of the request if one was specified.</summary>
		public string? RequestName
		{
			get
			{
				unsafe
				{
					fixed (byte* p = _RequestName)
						return Marshal.PtrToStringAnsi((IntPtr)p);
				}
			}
			set
			{
				unsafe
				{
					fixed (byte* p = _RequestName)
					{
						if (value is null)
							*p = 0;
						else
						{
							var bytes = Encoding.ASCII.GetBytes(value);
							if (bytes.Length > DSTORAGE_REQUEST_MAX_NAME)
								throw new ArgumentOutOfRangeException(nameof(value), $"The length of {nameof(value)} must be less than or equal to {DSTORAGE_REQUEST_MAX_NAME}.");
							Marshal.Copy(bytes, 0, (IntPtr)p, bytes.Length);
							*(p + bytes.Length) = 0;
						}
					}
				}
			}
		}

		/// <summary>The parameters passed to the EnqueueRequest call.</summary>
		public DSTORAGE_REQUEST Request;
	}

	/// <summary>The parameters passed to the EnqueueSignal call.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct DSTORAGE_ERROR_PARAMETERS_SIGNAL
	{
		/// <summary/>
		public ID3D12Fence Fence;

		/// <summary/>
		public ulong Value;
	}

	/// <summary>The parameters passed to the EnqueueStatus call.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct DSTORAGE_ERROR_PARAMETERS_STATUS
	{
		/// <summary/>
		public IDStorageStatusArray StatusArray;

		/// <summary/>
		public uint Index;
	}

	/// <summary>Structure to receive the detailed record of a failed DirectStorage request.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct DSTORAGE_ERROR_RECORD
	{
		/// <summary>The number of failed requests in the queue since the last RetrieveErrorRecord call.</summary>
		public uint FailureCount;

		/// <summary>Detailed record about the first failed command in the enqueue order.</summary>
		public DSTORAGE_ERROR_FIRST_FAILURE FirstFailure;
	}

	/// <summary>The DSTORAGE_QUEUE_DESC structure contains the properties of a DirectStorage queue for the queue's creation.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct DSTORAGE_QUEUE_DESC
	{
		/// <summary>The source type of requests that this DirectStorage queue can accept.</summary>
		public DSTORAGE_REQUEST_SOURCE_TYPE SourceType;

		/// <summary>The maximum number of requests that the queue can hold.</summary>
		public ushort Capacity;

		/// <summary>The priority of the requests in this queue.</summary>
		public DSTORAGE_PRIORITY Priority;

		/// <summary>Optional name of the queue. Used for debugging.</summary>
		[MarshalAs(UnmanagedType.LPStr)]
		public string? Name;

		/// <summary>
		/// Optional device to use for writing to destination resources and performing GPU decompression. The destination resource's device
		/// must match this device.
		///
		/// This member may be null. If you specify a null device, then the destination type must be DSTORAGE_REQUEST_DESTINATION_MEMORY.
		/// </summary>
		public ID3D12Device Device;
	}

	/// <summary>The DSTORAGE_QUEUE_INFO structure contains the properties and current state of a DirectStorage queue.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct DSTORAGE_QUEUE_INFO
	{
		/// <summary>The DSTORAGE_QUEUE_DESC structure used for the queue's creation.</summary>
		public DSTORAGE_QUEUE_DESC Desc;

		/// <summary>
		/// The number of available empty slots. If a queue is empty, then the number of empty slots equals capacity - 1. The reserved slot
		/// is used to distinguish between empty and full cases.
		/// </summary>
		public ushort EmptySlotCount;

		/// <summary>The number of entries that would need to be enqueued in order to trigger automatic submission.</summary>
		public ushort RequestCountUntilAutoSubmit;
	}

	/// <summary>Represents a DirectStorage request.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct DSTORAGE_REQUEST
	{
		/// <summary>Combination of decompression and other options for this request.</summary>
		public DSTORAGE_REQUEST_OPTIONS Options;

		/// <summary>The source for this request.</summary>
		public DSTORAGE_SOURCE Source;

		/// <summary>The destination for this request.</summary>
		public DSTORAGE_DESTINATION Destination;

		/// <summary>
		/// The uncompressed size in bytes for the destination for this request. If the request is not compressed, then this can be left as 0.
		///
		/// For compressed data, if the destination is memory, then the uncompressed size must exactly equal the destination size. For other
		/// destination types, the uncompressed size may be greater than the destination size.
		///
		/// If the destination is to memory or buffer, then the destination size should be specified in the corresponding struct (for
		/// example, DSTORAGE_DESTINATION_MEMORY). For textures, it's the value of pTotalBytes returned by GetCopyableFootprints. For tiles,
		/// it's 64k * number of tiles.
		/// </summary>
		public uint UncompressedSize;

		/// <summary>An arbitrary ulong number used for cancellation matching.</summary>
		public ulong CancellationTag;

		/// <summary>
		/// Optional name of the request. Used for debugging. If specified, the string should be accessible until the request completes.
		/// </summary>
		[MarshalAs(UnmanagedType.LPStr)]
		public string? Name;
	}

	/// <summary>Options for a DirectStorage request.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct DSTORAGE_REQUEST_OPTIONS
	{
		/// <summary>DSTORAGE_COMPRESSION_FORMAT indicating how the data is compressed.</summary>
		public DSTORAGE_COMPRESSION_FORMAT CompressionFormat;

		/// <summary>Reserved fields. Must be 0.</summary>
		private unsafe fixed byte Reserved1[7];

		private byte flags;

		/// <summary>DSTORAGE_REQUEST_SOURCE_TYPE enum value indicating whether the source of the request is a file or a block of memory.</summary>
		public DSTORAGE_REQUEST_SOURCE_TYPE SourceType
		{
			get => (DSTORAGE_REQUEST_SOURCE_TYPE)(BitHelper.GetBit(flags, 0) ? 1 : 0);
			set => BitHelper.SetBit(ref flags, 0, (byte)value != 0);
		}

		/// <summary>DSTORAGE_REQUEST_DESTINATION_TYPE enum value indicating the destination of the request. Block of memory, resource.</summary>
		public DSTORAGE_REQUEST_DESTINATION_TYPE DestinationType
		{
			get => (DSTORAGE_REQUEST_DESTINATION_TYPE)BitHelper.GetBits(flags, 1, 7);
			set => BitHelper.SetBits(ref flags, 1, 7, (byte)value);
		}

		/// <summary>Reserved fields. Must be 0.</summary>
		public unsafe fixed ulong Reserved[3];
	}

	/// <summary>
	/// Describes the source specified for a DirectStorage request. For a request, the value of `request.Options.SourceType` determines
	/// which of these union fields is active.
	/// </summary>
	[StructLayout(LayoutKind.Explicit)]
	public struct DSTORAGE_SOURCE
	{
		/// <summary/>
		[FieldOffset(0)]
		public DSTORAGE_SOURCE_MEMORY Memory;

		/// <summary/>
		[FieldOffset(0)]
		public DSTORAGE_SOURCE_FILE File;
	}

	/// <summary>Describes a source for a request with SourceType DSTORAGE_REQUEST_SOURCE_FILE.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct DSTORAGE_SOURCE_FILE
	{
		/// <summary>The file to perform this read request from.</summary>
		public IDStorageFile Source;

		/// <summary>The offset, in bytes, in the file to start the read request at.</summary>
		public ulong Offset;

		/// <summary>Number of bytes to read from the file.</summary>
		public uint Size;
	}

	/// <summary>Describes the source for a request with SourceType DSTORAGE_REQUEST_SOURCE_MEMORY.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct DSTORAGE_SOURCE_MEMORY
	{
		/// <summary>Address of the source buffer to be read from.</summary>
		public IntPtr Source;

		/// <summary>Number of bytes to read from the source buffer.</summary>
		public uint Size;
	}
}