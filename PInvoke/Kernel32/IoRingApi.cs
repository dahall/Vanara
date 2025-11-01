namespace Vanara.PInvoke;

public static partial class Kernel32
{
	/// <summary>Undocumented</summary>
	[PInvokeData("winbase.h", MinClient = PInvokeClient.Windows11)]
	public enum FILE_FLUSH_MODE
	{
		/// <summary>same as WIN32 FlushFileBuffers(); Flushes data, metadata, AND sends a SYNC command to the hardware</summary>
		FILE_FLUSH_DEFAULT = 0,

		/// <summary>Flush data only</summary>
		FILE_FLUSH_DATA,

		/// <summary>Flush data + SYNC (minimal metadata)</summary>
		FILE_FLUSH_MIN_METADATA,

		/// <summary>Flush data + metadata</summary>
		FILE_FLUSH_NO_SYNC,
	}

	/// <summary>Undocumented</summary>
	[PInvokeData("winbase.h", MinClient = PInvokeClient.Windows11)]
	public enum FILE_WRITE_FLAGS
	{
		/// <summary>Undocumented</summary>
		FILE_WRITE_FLAGS_NONE,

		/// <summary>Undocumented</summary>
		FILE_WRITE_FLAGS_WRITE_THROUGH = 0x000000001,
	}

	/// <summary>Specifies advisory flags for creating an I/O ring with a call to CreateIoRing.</summary>
	/// <remarks>
	/// Use the IORING_CREATE_FLAGS structure to pass flags into <c>CreateIoRing</c>. Any unknown or unsupported advisory flags provided to
	/// an API are ignored.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ioringapi/ne-ioringapi-ioring_create_advisory_flags typedef enum
	// IORING_CREATE_ADVISORY_FLAGS { IORING_CREATE_ADVISORY_FLAGS_NONE } ;
	[PInvokeData("ioringapi.h", MSDNShortId = "NE:ioringapi.IORING_CREATE_ADVISORY_FLAGS")]
	[Flags]
	public enum IORING_CREATE_ADVISORY_FLAGS
	{
		/// <summary>None.</summary>
		IORING_CREATE_ADVISORY_FLAGS_NONE,
	}

	/// <summary>Specifies required flags for creating an I/O ring with a call to CreateIoRing.</summary>
	/// <remarks>
	/// Use the IORING_CREATE_FLAGS structure to pass flags into <c>CreateIoRing</c>. If any unknown required flags are provided to an API,
	/// the API will fail the associated call.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ioringapi/ne-ioringapi-ioring_create_required_flags typedef enum
	// IORING_CREATE_REQUIRED_FLAGS { IORING_CREATE_REQUIRED_FLAGS_NONE } ;
	[PInvokeData("ioringapi.h", MSDNShortId = "NE:ioringapi.IORING_CREATE_REQUIRED_FLAGS")]
	[Flags]
	public enum IORING_CREATE_REQUIRED_FLAGS
	{
		/// <summary>None.</summary>
		IORING_CREATE_REQUIRED_FLAGS_NONE,
	}

	/// <summary>Specifies the type of an IORING_HANDLE_REF structure.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ioringapi/ne-ioringapi-ioring_ref_kind typedef enum IORING_REF_KIND {
	// IORING_REF_RAW, IORING_REF_REGISTERED } ;
	[PInvokeData("ioringapi.h", MSDNShortId = "NE:ioringapi.IORING_REF_KIND")]
	public enum IORING_REF_KIND
	{
		/// <summary>The referenced buffer is raw.</summary>
		IORING_REF_RAW,

		/// <summary>
		/// <para>The referenced buffer has been registered with an I/O ring with a call to</para>
		/// <para>BuildIoRingRegisterFileHandles</para>
		/// </summary>
		IORING_REF_REGISTERED,
	}

	/// <summary>Specifies kernel behavior options for I/O ring submission queue entries.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ioringapi/ne-ioringapi-ioring_sqe_flags typedef enum IORING_SQE_FLAGS {
	// IOSQE_FLAGS_NONE } ;
	[PInvokeData("ioringapi.h", MSDNShortId = "NE:ioringapi.IORING_SQE_FLAGS")]
	public enum IORING_SQE_FLAGS
	{
		/// <summary>None.</summary>
		IOSQE_FLAGS_NONE,
	}

	/// <summary>Attempts to cancel a previously submitted I/O ring operation.</summary>
	/// <param name="ioRing">An <c>HIORING</c> representing a handle to the I/O ring for which a cancellation is requested.</param>
	/// <param name="file">An IORING_HANDLE_REF representing the file associated with the operation to cancel.</param>
	/// <param name="opToCancel">
	/// A <c>UINT_PTR</c> specifying the operation to cancel. This value is the same value provided in the userData parameter when the
	/// operation was registered. To support cancellation, the userData value must be unique for each operation.
	/// </param>
	/// <param name="userData">
	/// A UINT_PTR value identifying the cancellation operation. Specify this value when cancelling the operation with a call to
	/// BuildIoRingCancelRequest. If an app implements cancellation behavior for the operation, the userData value must be unique. Otherwise,
	/// the value is treated as opaque by the system and can be anything, including 0.
	/// </param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>Success</term>
	/// </item>
	/// <item>
	/// <term>IORING_E_SUBMISSION_QUEUE_FULL</term>
	/// <term>
	/// The submission queue is full, and no additional entries are available to build. The application must submit the existing entries and
	/// wait for some of them to complete before adding more operations to the queue.
	/// </term>
	/// </item>
	/// <item>
	/// <term>IORING_E_UNKNOWN_REQUIRED_FLAG</term>
	/// <term>
	/// The application provided a required flag that is not known to the implementation. Library code should check the IoRingVersion field
	/// of the IORING_INFO obtained from a call to GetIoRingInfo to determine the API version of an I/O ring which determines the operations
	/// and flags that are supported. Applications should know the version they used to create the I/O ring and therefore should not provide
	/// unsupported flags at runtime.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// Since I/O ring operations are performed asynchronously this function call is only a request for cancellation. The specified operation
	/// may complete before the cancellation is processed. The cancellation operation may complete after the operation it is canceling is
	/// completed. The completion of the cancel operation is not dependent on the actual completion of the I/O operations it cancels. Apps
	/// should look for the completion of the original operation in the completion queue by calling PopIoRingCompletion to observe the final
	/// status of the operation. The operation may have completed successfully or with an error rather than being cancelled by the call to
	/// this function.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ioringapi/nf-ioringapi-buildioringcancelrequest HRESULT BuildIoRingCancelRequest(
	// HIORING ioRing, IORING_HANDLE_REF file, UINT_PTR opToCancel, UINT_PTR userData );
	[DllImport(Lib.KernelBase, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("ioringapi.h", MSDNShortId = "NF:ioringapi.BuildIoRingCancelRequest", MinClient = PInvokeClient.Windows11)]
	public static extern HRESULT BuildIoRingCancelRequest([In, AddAsMember] HIORING ioRing, IORING_HANDLE_REF file, IntPtr opToCancel, [In, Optional] IntPtr userData);

	/// <summary>Undocumented.</summary>
	/// <param name="ioRing">An <c>HIORING</c> representing a handle to the I/O ring for which a cancellation is requested.</param>
	/// <param name="fileRef">An IORING_HANDLE_REF representing the file associated with the operation to flush.</param>
	/// <param name="flushMode">The flush mode.</param>
	/// <param name="userData">
	/// A UINT_PTR value identifying the file write operation. Specify this value when cancelling the operation with a call to
	/// BuildIoRingCancelRequest. If an app implements cancellation behavior for the operation, the userData value must be unique. Otherwise,
	/// the value is treated as opaque by the system and can be anything, including 0.
	/// </param>
	/// <param name="sqeFlags">
	/// A bitwise OR combination of values from the IORING_SQE_FLAGS enumeration specifying kernel behavior options for I/O ring submission
	/// queue entries.
	/// </param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>Success</term>
	/// </item>
	/// <item>
	/// <term>IORING_E_SUBMISSION_QUEUE_FULL</term>
	/// <term>
	/// The submission queue is full, and no additional entries are available to build. The application must submit the existing entries and
	/// wait for some of them to complete before adding more operations to the queue.
	/// </term>
	/// </item>
	/// <item>
	/// <term>IORING_E_UNKNOWN_REQUIRED_FLAG</term>
	/// <term>
	/// The application provided a required flag that is not known to the implementation. Library code should check the IoRingVersion field
	/// of the IORING_INFO obtained from a call to GetIoRingInfo to determine the API version of an I/O ring which determines the operations
	/// and flags that are supported. Applications should know the version they used to create the I/O ring and therefore should not provide
	/// unsupported flags at runtime.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	[DllImport(Lib.KernelBase, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("ioringapi.h", MinClient = PInvokeClient.Windows11)]
	public static extern HRESULT BuildIoRingFlushFile([In, AddAsMember] HIORING ioRing, IORING_HANDLE_REF fileRef, FILE_FLUSH_MODE flushMode,
		IntPtr userData, IORING_SQE_FLAGS sqeFlags);

	/// <summary>Performs an asynchronous read from a file using an I/O ring. This operation is similar to calling ReadFileEx.</summary>
	/// <param name="ioRing">An <c>HIORING</c> representing a handle to the I/O ring which will perform the read operation.</param>
	/// <param name="fileRef">An IORING_HANDLE_REF specifying the file to read.</param>
	/// <param name="dataRef">
	/// An IORING_BUFFER_REF specifying the buffer into which the file is read. The provided buffer must have a size of at least
	/// numberOfBytesToRead bytes.
	/// </param>
	/// <param name="numberOfBytesToRead">The number of bytes to read.</param>
	/// <param name="fileOffset">The offset into the file to begin reading.</param>
	/// <param name="userData">
	/// A UINT_PTR value identifying the file read operation. Specify this value when cancelling the operation with a call to
	/// BuildIoRingCancelRequest. If an app implements cancellation behavior for the operation, the userData value must be unique. Otherwise,
	/// the value is treated as opaque by the system and can be anything, including 0.
	/// </param>
	/// <param name="flags">
	/// A bitwise OR combination of values from the IORING_SQE_FLAGS enumeration specifying kernel behavior options for I/O ring submission
	/// queue entries.
	/// </param>
	/// <returns>
	/// <para>Returns an HRESULT including, but not limited to the following:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>Success</term>
	/// </item>
	/// <item>
	/// <term>IORING_E_SUBMISSION_QUEUE_FULL</term>
	/// <term>
	/// The submission queue is full, and no additional entries are available to build. The application must submit the existing entries and
	/// wait for some of them to complete before adding more operations to the queue.
	/// </term>
	/// </item>
	/// <item>
	/// <term>IORING_E_UNKNOWN_REQUIRED_FLAG</term>
	/// <term>
	/// The application provided a required flag that is not known to the implementation. Library code should check the IoRingVersion field
	/// of the IORING_INFO obtained from a call to GetIoRingInfo to determine the API version of an I/O ring which determines the operations
	/// and flags that are supported. Applications should know the version they used to create the I/O ring and therefore should not provide
	/// unsupported flags at runtime.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// Check I/O ring support for read file operations by calling IsIoRingOpSupported and specifying IORING_OP_READ for the op parameter.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ioringapi/nf-ioringapi-buildioringreadfile HRESULT BuildIoRingReadFile( HIORING
	// ioRing, IORING_HANDLE_REF fileRef, IORING_BUFFER_REF dataRef, UINT32 numberOfBytesToRead, UINT64 fileOffset, UINT_PTR userData,
	// IORING_SQE_FLAGS flags );
	[DllImport(Lib.KernelBase, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("ioringapi.h", MSDNShortId = "NF:ioringapi.BuildIoRingReadFile", MinClient = PInvokeClient.Windows11)]
	public static extern HRESULT BuildIoRingReadFile([In, AddAsMember] HIORING ioRing, IORING_HANDLE_REF fileRef, IORING_BUFFER_REF dataRef,
		uint numberOfBytesToRead, ulong fileOffset, [In, Optional] IntPtr userData, IORING_SQE_FLAGS flags);

	/// <summary>Registers an array of buffers with the system for future I/O ring operations.</summary>
	/// <param name="ioRing">An <c>HIORING</c> representing a handle to the I/O ring for which buffers are registered.</param>
	/// <param name="count">A UINT32 specifying the number of buffers provided in the buffers parameter.</param>
	/// <param name="buffers">An array of IORING_BUFFER_INFO structures representing the buffers to be registered.</param>
	/// <param name="userData">
	/// A UINT_PTR value identifying the registration operation. Specify this value when cancelling the operation with a call to
	/// BuildIoRingCancelRequest. If an app implements cancellation behavior for the operation, the userData value must be unique. Otherwise,
	/// the value is treated as opaque by the system and can be anything, including 0.
	/// </param>
	/// <returns>
	/// <para>Returns an HRESULT including, but not limited to the following:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>Success</term>
	/// </item>
	/// <item>
	/// <term>IORING_E_SUBMISSION_QUEUE_FULL</term>
	/// <term>
	/// The submission queue is full, and no additional entries are available to build. The application must submit the existing entries and
	/// wait for some of them to complete before adding more operations to the queue.
	/// </term>
	/// </item>
	/// <item>
	/// <term>IORING_E_UNKNOWN_REQUIRED_FLAG</term>
	/// <term>
	/// The application provided a required flag that is not known to the implementation. Library code should check the IoRingVersion field
	/// of the IORING_INFO obtained from a call to GetIoRingInfo to determine the API version of an I/O ring which determines the operations
	/// and flags that are supported. Applications should know the version they used to create the I/O ring and therefore should not provide
	/// unsupported flags at runtime.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// This function allows the kernel implementation to perform the validation and internal mapping just once avoiding the overhead on each
	/// I/O operation. Subsequent entries in the submission queue may refer to the buffers registered with this function using an integer
	/// index into the array. If a previous registration exists, this replaces the previous registration completely. Any entries in the array
	/// with an Address of NULL and a Length of 0 are sparse entries, and not used. This allows you to release one or more of the previously
	/// registered buffers.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ioringapi/nf-ioringapi-buildioringregisterbuffers HRESULT
	// BuildIoRingRegisterBuffers( HIORING ioRing, UINT32 count, IORING_BUFFER_INFO const [] buffers, UINT_PTR userData );
	[DllImport(Lib.KernelBase, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("ioringapi.h", MSDNShortId = "NF:ioringapi.BuildIoRingRegisterBuffers", MinClient = PInvokeClient.Windows11)]
	public static extern HRESULT BuildIoRingRegisterBuffers([In, AddAsMember] HIORING ioRing, uint count,
		[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] IORING_BUFFER_INFO[] buffers, [In, Optional] IntPtr userData);

	/// <summary>Registers an array of file handles with the system for future I/O ring operations.</summary>
	/// <param name="ioRing">An <c>HIORING</c> representing a handle to the I/O ring for which file handles are registered.</param>
	/// <param name="count">A UINT32 specifying the number of handles provided in the handles parameter.</param>
	/// <param name="handles">An array of HANDLE values to be registered.</param>
	/// <param name="userData">
	/// A UINT_PTR value identifying the registration operation. Specify this value when cancelling the operation with a call to
	/// BuildIoRingCancelRequest. If an app implements cancellation behavior for the operation, the userData value must be unique. Otherwise,
	/// the value is treated as opaque by the system and can be anything, including 0.
	/// </param>
	/// <returns>
	/// <para>Returns an HRESULT including, but not limited to the following:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>Success</term>
	/// </item>
	/// <item>
	/// <term>IORING_E_SUBMISSION_QUEUE_FULL</term>
	/// <term>
	/// The submission queue is full, and no additional entries are available to build. The application must submit the existing entries and
	/// wait for some of them to complete before adding more operations to the queue.
	/// </term>
	/// </item>
	/// <item>
	/// <term>IORING_E_UNKNOWN_REQUIRED_FLAG</term>
	/// <term>
	/// The application provided a required flag that is not known to the implementation. Library code should check the IoRingVersion field
	/// of the IORING_INFO obtained from a call to GetIoRingInfo to determine the API version of an I/O ring which determines the operations
	/// and flags that are supported. Applications should know the version they used to create the I/O ring and therefore should not provide
	/// unsupported flags at runtime.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// This function allows the kernel implementation to perform the validation and internal mapping just once avoiding the overhead on each
	/// I/O operation. Subsequent entries in the submission queue may refer to the handles registered with this function using an integer
	/// index into the array. If a previous registration exists, this replaces the previous registration completely.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ioringapi/nf-ioringapi-buildioringregisterfilehandles HRESULT
	// BuildIoRingRegisterFileHandles( HIORING ioRing, UINT32 count, HANDLE const [] handles, UINT_PTR userData );
	[DllImport(Lib.KernelBase, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("ioringapi.h", MSDNShortId = "NF:ioringapi.BuildIoRingRegisterFileHandles", MinClient = PInvokeClient.Windows11)]
	public static extern HRESULT BuildIoRingRegisterFileHandles([In, AddAsMember] HIORING ioRing, uint count,
		[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] HANDLE[] handles, [In, Optional] IntPtr userData);

	/// <summary>Undocumented. Performs an asynchronous write to a file using an I/O ring. This operation is similar to calling WriteFileEx.</summary>
	/// <param name="ioRing">An <c>HIORING</c> representing a handle to the I/O ring for which a cancellation is requested.</param>
	/// <param name="fileRef">An IORING_HANDLE_REF specifying the file to write.</param>
	/// <param name="bufferRef">
	/// An IORING_BUFFER_REF specifying the buffer into which the file is write. The provided buffer must have a size of at least
	/// numberOfBytesToRead bytes.
	/// </param>
	/// <param name="numberOfBytesToWrite">The number of bytes to write.</param>
	/// <param name="fileOffset">The offset into the file to begin reading.</param>
	/// <param name="writeFlags">The write flags.</param>
	/// <param name="userData">
	/// A UINT_PTR value identifying the file write operation. Specify this value when cancelling the operation with a call to
	/// BuildIoRingCancelRequest. If an app implements cancellation behavior for the operation, the userData value must be unique. Otherwise,
	/// the value is treated as opaque by the system and can be anything, including 0.
	/// </param>
	/// <param name="sqeFlags">
	/// A bitwise OR combination of values from the IORING_SQE_FLAGS enumeration specifying kernel behavior options for I/O ring submission
	/// queue entries.
	/// </param>
	/// <returns>
	/// <para>Returns an HRESULT including, but not limited to the following:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>Success</term>
	/// </item>
	/// <item>
	/// <term>IORING_E_SUBMISSION_QUEUE_FULL</term>
	/// <term>
	/// The submission queue is full, and no additional entries are available to build. The application must submit the existing entries and
	/// wait for some of them to complete before adding more operations to the queue.
	/// </term>
	/// </item>
	/// <item>
	/// <term>IORING_E_UNKNOWN_REQUIRED_FLAG</term>
	/// <term>
	/// The application provided a required flag that is not known to the implementation. Library code should check the IoRingVersion field
	/// of the IORING_INFO obtained from a call to GetIoRingInfo to determine the API version of an I/O ring which determines the operations
	/// and flags that are supported. Applications should know the version they used to create the I/O ring and therefore should not provide
	/// unsupported flags at runtime.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// Check I/O ring support for read file operations by calling IsIoRingOpSupported and specifying IORING_OP_WRITE for the op parameter.
	/// </remarks>
	[DllImport(Lib.KernelBase, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("ioringapi.h", MinClient = PInvokeClient.Windows11)]
	public static extern HRESULT BuildIoRingWriteFile([In, AddAsMember] HIORING ioRing, IORING_HANDLE_REF fileRef, IORING_BUFFER_REF bufferRef,
		uint numberOfBytesToWrite, ulong fileOffset, FILE_WRITE_FLAGS writeFlags, [In, Optional] IntPtr userData, IORING_SQE_FLAGS sqeFlags);

	/// <summary>Closes an <c>HIORING</c> handle that was previously opened with a call to CreateIoRing.</summary>
	/// <param name="ioRing">The <c>HIORING</c> handle to close.</param>
	/// <returns>Returns S_OK on success.</returns>
	/// <remarks>
	/// <para>
	/// Calling this function ensures that resources allocated for the I/O ring are released. The closed handle is no longer valid after the
	/// function returns. It is important to note that closing the handle tosses the operations that are queued but not submitted. However,
	/// the operations that are in flight are not cancelled.
	/// </para>
	/// <para>
	/// It is possible that reads from or writes to memory buffers may still occur after <c>CloseIoRing</c> returns. If you want to ensure
	/// that no pending reads or writes occur, you must wait for the completions to appear in the completion queue for all the operations
	/// that are submitted. You may choose to cancel the previously submitted operations before waiting on their completions. As an
	/// alternative to submitting multiple cancel requests, you can call CancelIoEx with the file handle and NULL for the overlapped pointer
	/// to effectively cancel all pending operations on the handle.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ioringapi/nf-ioringapi-closeioring HRESULT CloseIoRing( HIORING ioRing );
	[DllImport(Lib.KernelBase, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("ioringapi.h", MSDNShortId = "NF:ioringapi.CloseIoRing", MinClient = PInvokeClient.Windows11)]
	public static extern HRESULT CloseIoRing([In] HIORING ioRing);

	/// <summary>Creates a new instance of an I/O ring submission/completion queue pair and returns a handle for referencing the IORING.</summary>
	/// <param name="ioringVersion">
	/// A UNIT32 representing the version of the I/O ring API the ring is created for. This value must be less than or equal to the value
	/// retrieved from a call to QueryIoRingCapabilities
	/// </param>
	/// <param name="flags">A value from the IORING_CREATE_FLAGS enumeration specifying creation flags.</param>
	/// <param name="submissionQueueSize">
	/// The requested minimum submission queue size. The system may round up the size as needed to ensure the actual size is a power of
	/// 2. You can get the actual allocated queue size by calling GetIoRingInfo. You can get the maximum submission queue size on the current
	/// system by calling QueryIoRingCapabilities.
	/// </param>
	/// <param name="completionQueueSize">
	/// The requested minimum size of the completion queue. The system will round this size up to a power of two that is no less than two
	/// times the actual submission queue size to allow for submissions while some operations are still in progress. You can get the actual
	/// allocated queue size by calling GetIoRingInfo.
	/// </param>
	/// <param name="h">
	/// Receives the resulting <c>HIORING</c> handle, if creation was successful. The returned <c>HIORING</c> ring must be closed by calling
	/// CloseIoRing, not CloseHandle, to release the underlying resources for the IORING.
	/// </param>
	/// <returns>
	/// <para>An HRESULT, including but not limited to the following:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>Success.</term>
	/// </item>
	/// <item>
	/// <term>IORING_E_UNKNOWN_VERSION</term>
	/// <term>The version specified in ioringVersion is unknown.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/ioringapi/nf-ioringapi-createioring HRESULT CreateIoRing( IORING_VERSION
	// ioringVersion, IORING_CREATE_FLAGS flags, UINT32 submissionQueueSize, UINT32 completionQueueSize, HIORING *h );
	[DllImport(Lib.KernelBase, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("ioringapi.h", MSDNShortId = "NF:ioringapi.CreateIoRing", MinClient = PInvokeClient.Windows11)]
	public static extern HRESULT CreateIoRing(IORING_VERSION ioringVersion, IORING_CREATE_FLAGS flags,
		uint submissionQueueSize, uint completionQueueSize, out SafeHIORING h);

	/// <summary>Gets information about the API version and queue sizes of an I/O ring.</summary>
	/// <param name="ioRing">An <c>HIORING</c> representing a handle to the I/O ring for which information is being queried.</param>
	/// <param name="info">Receives a pointer to an IORING_INFO structure specifying API version and queue sizes for the specified I/O ring.</param>
	/// <returns>S_OK on success.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/ioringapi/nf-ioringapi-getioringinfo HRESULT GetIoRingInfo( HIORING ioRing,
	// IORING_INFO *info );
	[DllImport(Lib.KernelBase, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("ioringapi.h", MSDNShortId = "NF:ioringapi.GetIoRingInfo", MinClient = PInvokeClient.Windows11)]
	public static extern HRESULT GetIoRingInfo([In, AddAsMember] HIORING ioRing, out IORING_INFO info);

	/// <summary>Creates an instance of the IORING_BUFFER_REF structure from the provided buffer index and offset.</summary>
	/// <param name="i">The index within the submission queue of the referenced buffer.</param>
	/// <param name="o">The offset within the buffer specified by index.</param>
	/// <returns>IORING_BUFFER_REF</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/ioringapi/nf-ioringapi-ioringbufferreffromindexandoffset void
	// IoRingBufferRefFromIndexAndOffset( i, o );
	[PInvokeData("ioringapi.h", MSDNShortId = "NF:ioringapi.IoRingBufferRefFromIndexAndOffset")]
	public static IORING_BUFFER_REF IoRingBufferRefFromIndexAndOffset(uint i, uint o) => new(i, o);

	/// <summary>Creates an instance of the IORING_BUFFER_REF structure from the provided pointer.</summary>
	/// <param name="p">A void pointer representing the buffer to reference.</param>
	/// <returns>IORING_BUFFER_REF</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/ioringapi/nf-ioringapi-ioringbufferreffrompointer void IoRingBufferRefFromPointer(
	// p );
	[PInvokeData("ioringapi.h", MSDNShortId = "NF:ioringapi.IoRingBufferRefFromPointer")]
	public static IORING_BUFFER_REF IoRingBufferRefFromPointer(IntPtr p) => new(p);

	/// <summary>Creates an instance of the IORING_HANDLE_REF structure from the provided file handle.</summary>
	/// <param name="h">The file handle to be referenced.</param>
	/// <returns>IORING_HANDLE_REF</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/ioringapi/nf-ioringapi-ioringhandlereffromhandle void IoRingHandleRefFromHandle( h );
	[PInvokeData("ioringapi.h", MSDNShortId = "NF:ioringapi.IoRingHandleRefFromHandle")]
	public static IORING_HANDLE_REF IoRingHandleRefFromHandle(IntPtr h) => new(h);

	/// <summary>Creates an instance of the IORING_HANDLE_REF structure from the provided index.</summary>
	/// <param name="i">The index within the submission queue of the file to be referenced.</param>
	/// <returns>IORING_HANDLE_REF</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/ioringapi/nf-ioringapi-ioringhandlereffromindex void IoRingHandleRefFromIndex( i );
	[PInvokeData("ioringapi.h", MSDNShortId = "NF:ioringapi.IoRingHandleRefFromIndex")]
	public static IORING_HANDLE_REF IoRingHandleRefFromIndex(uint i) => new(i);

	/// <summary>Queries the support of the specified operation for the specified I/O ring.</summary>
	/// <param name="ioRing">An <c>HIORING</c> representing a handle to the I/O ring for which operation support is queried.</param>
	/// <param name="op">A value from the IORING_OP_CODE enumeration specifying the operation for which support is queried.</param>
	/// <returns>
	/// <para>Returns an HRESULT including, but not limitted to the following:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>The operation is supported.</term>
	/// </item>
	/// <item>
	/// <term>S_FALSE</term>
	/// <term>The operation is unsupported.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// Unknown operation codes are treated as unsupported. Invalid <c>HIORING</c> handles are treated as not supporting any operations. So,
	/// this method will not throw errors due to these conditions.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ioringapi/nf-ioringapi-isioringopsupported BOOL IsIoRingOpSupported( HIORING
	// ioRing, IORING_OP_CODE op );
	[DllImport(Lib.KernelBase, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("ioringapi.h", MSDNShortId = "NF:ioringapi.IsIoRingOpSupported", MinClient = PInvokeClient.Windows11)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool IsIoRingOpSupported([In, AddAsMember] HIORING ioRing, IORING_OP_CODE op);

	/// <summary>Pops a single entry from the completion queue, if one is available.</summary>
	/// <param name="ioRing">An <c>HIORING</c> representing a handle to the I/O ring from which an entry from the completion queue is popped.</param>
	/// <param name="cqe">Receives a pointer to an IORING_CQE structure representing the completed queue entry.</param>
	/// <returns>
	/// <para>Returns an HRESULT including, but not limitted to the following:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>The entry was popped from the queue and the IORING_CQE pointed to by cqe contains the values from the entry.</term>
	/// </item>
	/// <item>
	/// <term>S_FALSE</term>
	/// <term>The completion queue is empty, and the data pointed to by the cqe parameter is unmodified.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/ioringapi/nf-ioringapi-popioringcompletion HRESULT PopIoRingCompletion( HIORING
	// ioRing, IORING_CQE *cqe );
	[DllImport(Lib.KernelBase, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("ioringapi.h", MSDNShortId = "NF:ioringapi.PopIoRingCompletion", MinClient = PInvokeClient.Windows11)]
	public static extern HRESULT PopIoRingCompletion([In, AddAsMember] HIORING ioRing, out IORING_CQE cqe);

	/// <summary>Queries the OS for the supported capabilities for I/O rings.</summary>
	/// <param name="capabilities">Receives a pointer to an IORING_CAPABILITIES representing the I/O ring API capabilities.</param>
	/// <returns>S_OK on success.</returns>
	/// <remarks>
	/// The results of this call are internally cached per-process, so this is efficient to call multiple times as only the first will
	/// transition to the kernel to retrieve the data.Note that the results are not guaranteed to contain the same values between runs of the
	/// same process or even between processes on the same system. So applications should not store this information beyond the lifetime of
	/// the process and should not assume that other processes have the same support.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ioringapi/nf-ioringapi-queryioringcapabilities HRESULT QueryIoRingCapabilities(
	// IORING_CAPABILITIES *capabilities );
	[DllImport(Lib.KernelBase, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("ioringapi.h", MSDNShortId = "NF:ioringapi.QueryIoRingCapabilities", MinClient = PInvokeClient.Windows11)]
	public static extern HRESULT QueryIoRingCapabilities(out IORING_CAPABILITIES capabilities);

	/// <summary>Registers a completion queue event with an I/O ring.</summary>
	/// <param name="ioRing">An <c>HIORING</c> representing a handle to the I/O ring for which the completion event is registered.</param>
	/// <param name="hEvent">A handle to the event object. The CreateEvent or OpenEvent function returns this handle.</param>
	/// <returns>
	/// <para>Returns an HRESULT including the following values:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>Success</term>
	/// </item>
	/// <item>
	/// <term>E_INVALID_HANDLE</term>
	/// <term>An invalid handle was passed in the <c>ioRing</c> parameter.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>An invalid handle was passed in the <c>hEvent</c> parameter.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The kernel will signal this event when it places the first entry into an empty completion queue, i.e. the kernel only sets the event
	/// to the signaled state when the completion queue transitions from the empty to non-empty state. Applications should call
	/// PopIoRingCompletion until it indicates no more entries and then wait for any additional async completions to complete via the
	/// provided HANDLE. Otherwise, the event won’t enter the signaled state and the wait may block until a timeout occurs, or forever if an
	/// infinite timeout is used.
	/// </para>
	/// <para>
	/// The kernel will internally duplicate the handle, so it is safe for the application to close the handle when waits are no longer
	/// needed. Providing an event handle value of NULL simply clears any existing value. Setting a value of INVALID_HANDLE_VALUE raises an
	/// error, as will any other invalid handle value, to aid in detecting code bugs early.
	/// </para>
	/// <para>
	/// There is, at most, one event handle associated with an HIORING, attempting to set a second one will replace any that already exists.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/ioringapi/nf-ioringapi-setioringcompletionevent HRESULT SetIoRingCompletionEvent(
	// HIORING ioRing, HANDLE hEvent );
	[PInvokeData("ioringapi.h", MSDNShortId = "NF:ioringapi.SetIoRingCompletionEvent")]
	[DllImport(Lib.KernelBase, SetLastError = false, ExactSpelling = true)]
	public static extern HRESULT SetIoRingCompletionEvent([In, AddAsMember] HIORING ioRing, HEVENT hEvent);

	/// <summary>
	/// Submits all constructed but not yet submitted entries to the kernel’s queue and optionally waits for a set of operations to complete.
	/// </summary>
	/// <param name="ioRing">An <c>HIORING</c> representing a handle to the I/O ring for which entries will be submitted.</param>
	/// <param name="waitOperations">
	/// The number of completion queue entries to wait for. Specifying 0 indicates that the call should not wait. This value must be less
	/// than the sum of the number of entries in the submission queue and the number of operations currently in progress.
	/// </param>
	/// <param name="milliseconds">
	/// The number of milliseconds to wait for the operations to complete. Specify <c>INFINITE</c> to wait indefinitely. This value is
	/// ignored if 0 is specified for waitOperations.
	/// </param>
	/// <param name="submittedEntries">
	/// Optional. Receives a pointer to an array of <c>UINT_32</c> values representing the number of entries submitted.
	/// </param>
	/// <returns>
	/// <para>Returns an HRESULT including, but not limited to, one of the following:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>All entries in the queue were submitted without error.</term>
	/// </item>
	/// <item>
	/// <term>IORING_E_WAIT_TIMEOUT</term>
	/// <term>All operations were submitted without error and the subsequent wait timed out.</term>
	/// </item>
	/// <item>
	/// <term>Any other error value</term>
	/// <term>Failure to process the submission queue in its entirety.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// If this function returns an error other than IORING_E_WAIT_TIMEOUT, then all entries remain in the submission queue. Any errors
	/// processing a single submission queue entry results in a synchronous completion of that entry posted to the completion queue with an
	/// error status code for that operation.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ioringapi/nf-ioringapi-submitioring HRESULT SubmitIoRing( HIORING ioRing, UINT32
	// waitOperations, UINT32 milliseconds, UINT32 *submittedEntries );
	[DllImport(Lib.KernelBase, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("ioringapi.h", MSDNShortId = "NF:ioringapi.SubmitIoRing", MinClient = PInvokeClient.Windows11)]
	public static extern HRESULT SubmitIoRing([In, AddAsMember] HIORING ioRing, uint waitOperations, uint milliseconds,
		[Out, Optional, MarshalAs(UnmanagedType.LPArray)] uint[]? submittedEntries);

	/// <summary>Represents a reference to a buffer used in an I/O ring operation.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ioringapi/ns-ioringapi-ioring_buffer_ref typedef struct IORING_BUFFER_REF { void
	// IORING_BUFFER_REF( void *address ); void IORING_BUFFER_REF( IORING_REGISTERED_BUFFER registeredBuffer ); void IORING_BUFFER_REF(
	// UINT32 index, UINT32 offset ); IORING_REF_KIND Kind; union { void *Address; IORING_REGISTERED_BUFFER IndexAndOffset; } BufferUnion;
	// BufferUnion Buffer; } IORING_BUFFER_REF;
	[PInvokeData("ioringapi.h", MSDNShortId = "NS:ioringapi.IORING_BUFFER_REF")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IORING_BUFFER_REF
	{
		/// <summary>Initializes a new instance of the <see cref="IORING_BUFFER_REF"/> struct.</summary>
		/// <param name="address">A pointer specifying the address of a buffer.</param>
		public IORING_BUFFER_REF(IntPtr address)
		{
			Kind = IORING_REF_KIND.IORING_REF_RAW;
			Buffer = new() { Address = address };
		}

		/// <summary>Initializes a new instance of the <see cref="IORING_BUFFER_REF"/> struct.</summary>
		/// <param name="registeredBuffer">The index and offset of the registered buffer.</param>
		public IORING_BUFFER_REF(IORING_REGISTERED_BUFFER registeredBuffer)
		{
			Kind = IORING_REF_KIND.IORING_REF_REGISTERED;
			Buffer = new() { IndexAndOffset = registeredBuffer };
		}

		/// <summary>Initializes a new instance of the <see cref="IORING_BUFFER_REF"/> struct.</summary>
		/// <param name="index">The index of the registered buffer.</param>
		/// <param name="offset">The offset of the registered buffer.</param>
		public IORING_BUFFER_REF(uint index, uint offset) : this(new IORING_REGISTERED_BUFFER { BufferIndex = index, Offset = offset })
		{
		}

		/// <summary>A value from the IORING_REF_KIND enumeration specifying the kind of buffer represented by the structure.</summary>
		public IORING_REF_KIND Kind;

		/// <summary/>
		public BufferUnion Buffer;

		/// <summary/>
		[StructLayout(LayoutKind.Explicit)]
		public struct BufferUnion
		{
			/// <summary>A void pointer specifying the address of a buffer if the Kind value is IORING_REF_RAW.</summary>
			[FieldOffset(0)]
			public IntPtr Address;

			/// <summary>The index and offset of the registered buffer if the Kind value is IORING_REF_REGISTERED.</summary>
			[FieldOffset(0)]
			public IORING_REGISTERED_BUFFER IndexAndOffset;
		}
	}

	/// <summary>Represents the IORING API capabilities.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ioringapi/ns-ioringapi-ioring_capabilities typedef struct IORING_CAPABILITIES {
	// IORING_VERSION MaxVersion; UINT32 MaxSubmissionQueueSize; UINT32 MaxCompletionQueueSize; IORING_FEATURE_FLAGS FeatureFlags; } IORING_CAPABILITIES;
	[PInvokeData("ioringapi.h", MSDNShortId = "NS:ioringapi.IORING_CAPABILITIES")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IORING_CAPABILITIES
	{
		/// <summary>A value from the IORING_VERSION enumeration specifying the maximum supported IORING API version.</summary>
		public IORING_VERSION MaxVersion;

		/// <summary>The maximum submission queue size.</summary>
		public uint MaxSubmissionQueueSize;

		/// <summary>The maximum completion queue size.</summary>
		public uint MaxCompletionQueueSize;

		/// <summary>A value from the IORING_FEATURE_FLAGS enumeration specifying feature flags for the IORING API implementation.</summary>
		public IORING_FEATURE_FLAGS FeatureFlags;
	}

	/// <summary>Represents a completed I/O ring queue entry.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ioringapi/ns-ioringapi-ioring_cqe typedef struct IORING_CQE { UINT_PTR UserData;
	// HRESULT ResultCode; ULONG_PTR Information; } IORING_CQE;
	[PInvokeData("ioringapi.h", MSDNShortId = "NS:ioringapi.IORING_CQE")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IORING_CQE
	{
		/// <summary>
		/// A <c>UINT_PTR</c> representing the user data associated with the entry. This is the same value provided as the UserData parameter
		/// when building the operation's submission queue entry. Applications can use this value to correlate the completion with the
		/// original operation request.
		/// </summary>
		public IntPtr UserData;

		/// <summary>A <c>HRESULT</c> indicating the result code of the associated I/O ring operation.</summary>
		public HRESULT ResultCode;

		/// <summary>A <c>ULONG_PTR</c> representing information about the completed queue operation.</summary>
		public IntPtr Information;
	}

	/// <summary>Specifies flags for creating an I/O ring with a call to CreateIoRing.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ioringapi/ns-ioringapi-ioring_create_flags typedef struct IORING_CREATE_FLAGS {
	// IORING_CREATE_REQUIRED_FLAGS Required; IORING_CREATE_ADVISORY_FLAGS Advisory; } IORING_CREATE_FLAGS;
	[PInvokeData("ioringapi.h", MSDNShortId = "NS:ioringapi.IORING_CREATE_FLAGS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IORING_CREATE_FLAGS
	{
		/// <summary>
		/// A bitwise OR combination of flags from the IORING_CREATE_REQUIRED_FLAGS enumeration. If any unknown required flags are provided
		/// to an API, the API will fail the associated call.
		/// </summary>
		public IORING_CREATE_REQUIRED_FLAGS Required;

		/// <summary>
		/// A bitwise OR combination of flags from the IORING_CREATE_ADVISORY_FLAGS enumeration.Advisory flags. Any unknown or unsupported
		/// advisory flags provided to an API are ignored.
		/// </summary>
		public IORING_CREATE_ADVISORY_FLAGS Advisory;
	}

	/// <summary>Represents a reference to a file handle used in an I/O ring operation.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ioringapi/ns-ioringapi-ioring_handle_ref typedef struct IORING_HANDLE_REF { void
	// IORING_HANDLE_REF( HANDLE h ); void IORING_HANDLE_REF( UINT32 index ); IORING_REF_KIND Kind; union { HANDLE Handle; UINT32 Index; }
	// HandleUnion; HandleUnion Handle; } IORING_HANDLE_REF;
	[PInvokeData("ioringapi.h", MSDNShortId = "NS:ioringapi.IORING_HANDLE_REF")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IORING_HANDLE_REF
	{
		/// <summary>Initializes a new instance of the <see cref="IORING_HANDLE_REF"/> struct.</summary>
		/// <param name="h">The handle to a file.</param>
		public IORING_HANDLE_REF(HANDLE h)
		{
			Kind = IORING_REF_KIND.IORING_REF_RAW;
			Handle = new() { Handle = h };
		}

		/// <summary>Initializes a new instance of the <see cref="IORING_HANDLE_REF"/> struct.</summary>
		/// <param name="index">The index of the registered file handle.</param>
		public IORING_HANDLE_REF(uint index)
		{
			Kind = IORING_REF_KIND.IORING_REF_REGISTERED;
			Handle = new() { Index = index };
		}

		/// <summary>A value from the IORING_REF_KIND enumeration specifying the kind of handle represented by the structure.</summary>
		public IORING_REF_KIND Kind;

		/// <summary/>
		public HandleUnion Handle;

		/// <summary/>
		[StructLayout(LayoutKind.Explicit)]
		public struct HandleUnion
		{
			/// <summary>The handle to a file if the Kind value is IORING_REF_RAW.</summary>
			[FieldOffset(0)]
			public HANDLE Handle;

			/// <summary>The index of the registered file handle if the Kind value is IORING_REF_REGISTERED.</summary>
			[FieldOffset(0)]
			public uint Index;
		}
	}

	/// <summary>Represents the shape and version information for the specified I/O ring.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ioringapi/ns-ioringapi-ioring_info typedef struct IORING_INFO { IORING_VERSION
	// IoRingVersion; IORING_CREATE_FLAGS Flags; UINT32 SubmissionQueueSize; UINT32 CompletionQueueSize; } IORING_INFO;
	[PInvokeData("ioringapi.h", MSDNShortId = "NS:ioringapi.IORING_INFO")]
	[StructLayout(LayoutKind.Sequential)]
	public struct IORING_INFO
	{
		/// <summary>A IORING_VERSION structure representing the API version of the associated I/O ring.</summary>
		public IORING_VERSION IoRingVersion;

		/// <summary>A IORING_CREATE_FLAGS structure containing the creation flags with which the associated I/O ring.</summary>
		public IORING_CREATE_FLAGS Flags;

		/// <summary>
		/// The actual minimum submission queue size. The system may round up the value requested in the call to CreateIoRing as needed to
		/// ensure the actual size is a power of 2.
		/// </summary>
		public uint SubmissionQueueSize;

		/// <summary>
		/// The actual minimum size of the completion queue. The system will round up the value requested in the call to <c>CreateIoRing</c>
		/// to a power of two that is no less than two times the actual submission queue size to allow for submissions while some operations
		/// are still in progress.
		/// </summary>
		public uint CompletionQueueSize;
	}
}