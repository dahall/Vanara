using System.Threading;

namespace Vanara.PInvoke;

/// <summary>Items from the PeerDist.dll</summary>
public static partial class PeerDist
{
	private const string Lib_PeerDist = "peerdist.dll";

	/// <summary/>
	public const uint PEERDIST_READ_TIMEOUT_DEFAULT = 0xfffffffe;
	/// <summary/>
	public const uint PEERDIST_READ_TIMEOUT_LOCAL_CACHE_ONLY = 0;
	/// <summary/>
	public const uint PEERDIST_RETRIEVAL_OPTIONS_CONTENTINFO_VERSION = 2;
	/// <summary/>
	public const uint PEERDIST_RETRIEVAL_OPTIONS_CONTENTINFO_VERSION_1 = 1;
	/// <summary/>
	public const uint PEERDIST_RETRIEVAL_OPTIONS_CONTENTINFO_VERSION_2 = 2;

	/// <summary>The <c>PEERDIST_CLIENT_INFO_BY_HANDLE_CLASS</c> enumeration defines the possible client information values.</summary>
	/// <remarks>
	/// A value from this enumeration is passed to thePeerDistClientGetInformationByHandle function as the PeerDistClientInfoClass parameter.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/peerdist/ne-peerdist-peerdist_client_info_by_handle_class typedef enum
	// _PEERDIST_CLIENT_INFO_BY_HANDLE_CLASS { PeerDistClientBasicInfo, MaximumPeerDistClientInfoByHandlesClass }
	// PEERDIST_CLIENT_INFO_BY_HANDLE_CLASS, *PPEERDIST_CLIENT_INFO_BY_HANDLE_CLASS;
	[PInvokeData("peerdist.h", MSDNShortId = "NE:peerdist._PEERDIST_CLIENT_INFO_BY_HANDLE_CLASS")]
	public enum PEERDIST_CLIENT_INFO_BY_HANDLE_CLASS
	{
		/// <summary>Indicates the information to retrieve is a PEERDIST_CLIENT_BASIC_INFO structure.</summary>
		PeerDistClientBasicInfo,

		/// <summary>
		/// The maximum value for the enumeration that is used for error checking. This value should not be sent to the
		/// PeerDistClientGetInformationByHandle function.
		/// </summary>
		MaximumPeerDistClientInfoByHandlesClass,
	}

	/// <summary>The <c>PEERDIST_STATUS</c> enumeration defines the possible status values of the Peer Distribution service.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/peerdist/ne-peerdist-peerdist_status typedef enum { PEERDIST_STATUS_DISABLED,
	// PEERDIST_STATUS_UNAVAILABLE, PEERDIST_STATUS_AVAILABLE } PEERDIST_STATUS;
	[PInvokeData("peerdist.h", MSDNShortId = "NE:peerdist.__unnamed_enum_0")]
	public enum PEERDIST_STATUS
	{
		/// <summary>The service is disabled by Group Policy or according to configuration parameters.</summary>
		PEERDIST_STATUS_DISABLED,

		/// <summary>The service is not ready to process the request.</summary>
		PEERDIST_STATUS_UNAVAILABLE,

		/// <summary>The Peer Distribution service is available and ready to process requests.</summary>
		PEERDIST_STATUS_AVAILABLE,
	}

	/// <summary>
	/// The <c>PeerDistClientAddContentInformation</c> function adds the content information associated with a content handle opened by PeerDistClientOpenContent.
	/// </summary>
	/// <param name="hPeerDist">A <c>PEERDIST_INSTANCE_HANDLE</c> returned by PeerDistStartup.</param>
	/// <param name="hContentHandle">A <c>PEERDIST_CONTENT_HANDLE</c> opened by PeerDistClientOpenContent.</param>
	/// <param name="cbNumberOfBytes">Number of bytes in the pBuffer array.</param>
	/// <param name="pBuffer">
	/// Pointer to the buffer that contains the content information. This buffer must remain valid for the duration of the add
	/// operation. The caller must not use this buffer until the add operation is completed.
	/// </param>
	/// <param name="lpOverlapped">
	/// Pointer to an OVERLAPPED structure. The Internal member of OVERLAPPED structure contains the completion status of the
	/// asynchronous operation. The Offset and OffsetHigh are reserved and must be 0.
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is <c>ERROR_IO_PENDING</c>. Otherwise, the function may return one of the following values:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>One or more parameters are invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The hPeerDist handle is invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_ACCESS_DISABLED_BY_POLICY</term>
	/// <term>The feature is disabled by Group Policy.</term>
	/// </item>
	/// <item>
	/// <term>PEERDIST_ERROR_SERVICE_UNAVAILABLE</term>
	/// <term>The service is unavailable.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// In order to retrieve content data from Peer Distribution service the client must add content information that it received from
	/// the content server by calling the <c>PeerDistClientAddContentInformation</c> function. When all content information data has
	/// been added, the PeerDistClientCompleteContentInformation function must be called. Once
	/// <c>PeerDistClientCompleteContentInformation</c> is complete, the client can call PeerDistClientStreamRead or
	/// PeerDistClientBlockRead to retrieve the data from the Peer Distribution system.
	/// </para>
	/// <para>
	/// When calling this function multiple times on a single content handle, the caller must wait for each operation to complete before
	/// the next call is made.
	/// </para>
	/// <para>
	/// An application is not limited to adding content information with a single <c>PeerDistClientAddContentInformation</c> API call,
	/// as it is possible to add portions of that content information as it is made available. When more content information is
	/// available, the application can again call <c>PeerDistClientAddContentInformation</c>. When the application is done adding the
	/// entire content information, it must then call PeerDistClientCompleteContentInformation.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/peerdist/nf-peerdist-peerdistclientaddcontentinformation DWORD
	// PeerDistClientAddContentInformation( PEERDIST_INSTANCE_HANDLE hPeerDist, PEERDIST_CONTENT_HANDLE hContentHandle, DWORD
	// cbNumberOfBytes, PBYTE pBuffer, LPOVERLAPPED lpOverlapped );
	[DllImport(Lib_PeerDist, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("peerdist.h", MSDNShortId = "NF:peerdist.PeerDistClientAddContentInformation")]
	public static unsafe extern Win32Error PeerDistClientAddContentInformation(PEERDIST_INSTANCE_HANDLE hPeerDist, PEERDIST_CONTENT_HANDLE hContentHandle,
		uint cbNumberOfBytes, [In] IntPtr pBuffer, [In] NativeOverlapped* lpOverlapped);

	/// <summary>
	/// The <c>PeerDistClientAddData</c> function is used to supply content to the local cache. Typically this is done when data could
	/// not be found on the local network as indicated when either PeerDistClientBlockRead or PeerDistClientStreamRead complete with
	/// <c>ERROR_TIMEOUT</c> or <c>PEERDIST_ERROR_MISSING_DATA</c>.
	/// </summary>
	/// <param name="hPeerDist">A <c>PEERDIST_INSTANCE_HANDLE</c> returned by PeerDistStartup.</param>
	/// <param name="hContentHandle">A <c>PEERDIST_CONTENT_HANDLE</c> returned by PeerDistClientOpenContent.</param>
	/// <param name="cbNumberOfBytes">The number of bytes to be added to the local cache.</param>
	/// <param name="pBuffer">
	/// Pointer to the buffer that contains the data to be added to the local cache. This buffer must remain valid for the duration of
	/// the add operation. The caller must not use this buffer until the add operation is completed.
	/// </param>
	/// <param name="lpOverlapped">
	/// Pointer to an OVERLAPPED structure. The byte offset from the beginning of content, at which this data is being added, is
	/// specified by setting the <c>Offset</c> and <c>OffsetHigh</c> members of the OVERLAPPED structure. The <c>OffsetHigh</c> member
	/// MUST be set to the higher 32 bits of the byte offset and the <c>Offset</c> member MUST be set to the lower 32 bits of the byte offset.
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is <c>ERROR_IO_PENDING</c>. Otherwise, the function may return one of the following values:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>One or more parameters are invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The hPeerDist or hContent handle is invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_ACCESS_DISABLED_BY_POLICY</term>
	/// <term>The feature is disabled by Group Policy.</term>
	/// </item>
	/// <item>
	/// <term>PEERDIST_ERROR_SERVICE_UNAVAILABLE</term>
	/// <term>The service is unavailable.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The data that has been added with this function and passed verification is available to other peers or hosted cache for
	/// download. The Peer Distribution service stores this data in its local cache.
	/// </para>
	/// <para>
	/// If the API completes with <c>PEERDIST_ERROR_OUT_OF_BOUNDS</c>, this indicates that the offset specified in the overlapped
	/// structure is beyond the end of the content.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/peerdist/nf-peerdist-peerdistclientadddata DWORD PeerDistClientAddData(
	// PEERDIST_INSTANCE_HANDLE hPeerDist, PEERDIST_CONTENT_HANDLE hContentHandle, DWORD cbNumberOfBytes, PBYTE pBuffer, LPOVERLAPPED
	// lpOverlapped );
	[DllImport(Lib_PeerDist, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("peerdist.h", MSDNShortId = "NF:peerdist.PeerDistClientAddData")]
	public static unsafe extern Win32Error PeerDistClientAddData(PEERDIST_INSTANCE_HANDLE hPeerDist, PEERDIST_CONTENT_HANDLE hContentHandle, uint cbNumberOfBytes,
		[In] IntPtr pBuffer, [In] NativeOverlapped* lpOverlapped);

	/// <summary>The <c>PeerDistClientBlockRead</c> function reads content data blocks.</summary>
	/// <param name="hPeerDist">A <c>PEERDIST_INSTANCE_HANDLE</c> returned by PeerDistStartup.</param>
	/// <param name="hContentHandle">A content handle opened by PeerDistClientOpenContent function call.</param>
	/// <param name="cbMaxNumberOfBytes">
	/// The maximum number of bytes to read. If the cbMaxNumberOfBytesToRead is equal to 0, it indicates that the
	/// <c>PeerDistClientBlockRead</c> function is querying the length of available consecutive content byes in the local cache at the
	/// current block read offset. The query will neither download content from the peers, nor return the count of bytes present in the
	/// peer cache.
	/// </param>
	/// <param name="pBuffer">
	/// Pointer to the buffer that receives the data from the local cache. This buffer must remain valid for the duration of the read
	/// operation. The caller must not use this buffer until the read operation is completed. If the cbMaxNumberOfBytesToRead argument
	/// is equal to 0, the pBuffer parameter can be <c>NULL</c>
	/// </param>
	/// <param name="dwTimeoutInMilliseconds">
	/// <para>Timeout value for the read, in milliseconds. There are two special values that may be specified:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>PEERDIST_READ_TIMEOUT_LOCAL_CACHE_ONLY</term>
	/// <term>Specifies that a read should not cause any additional network traffic by contacting peers or a Hosted Cache.</term>
	/// </item>
	/// <item>
	/// <term>PEERDIST_READ_TIMEOUT_DEFAULT</term>
	/// <term>Specifies the default timeout of 5 seconds.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="lpOverlapped">
	/// Pointer to an OVERLAPPED structure. The start offset for read is specified by setting the <c>Offset</c> and <c>OffsetHigh</c>
	/// members of the OVERLAPPED structure. The <c>OffsetHigh</c> member should be set to the higher 32 bits of the start offset and
	/// the <c>Offset</c> member should be set to the lower 32 bits of the start offset.
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is <c>ERROR_IO_PENDING</c>. Otherwise, the function may return one of the following values:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>One or more parameters are invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The hPeerDist or hContent handle is invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_ACCESS_DISABLED_BY_POLICY</term>
	/// <term>The feature is disabled by Group Policy.</term>
	/// </item>
	/// <item>
	/// <term>PEERDIST_ERROR_SERVICE_UNAVAILABLE</term>
	/// <term>The service is unavailable.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>PeerDistClientBlockRead</c> queues the read and immediately returns to the caller. As a result, multiple reads can be issued
	/// simultaneously. <c>PeerDistClientBlockRead</c> will complete a read as soon as any data is available and will not wait for the
	/// buffer to fill completely.
	/// </para>
	/// <para>
	/// If the <c>PeerDistClientBlockRead</c> function operation completes successfully, the <c>Offset</c> and <c>OffsetHigh</c> fields
	/// of the OVERLAPPED structure will be populated with the <c>ULONGLONG</c> offset at which the read started. The OffsetHigh member
	/// will be set to the higher 32 bits of the offset and the Offset member will be set to the lower 32 bits of the offset.
	/// GetOverlappedResult will populate lpNumberOfBytesTransferred with the number of bytes transferred. In the event the caller is
	/// using a completion port to process Peer Distribution API completions then the lpNumberOfBytes argument of
	/// GetQueuedCompletionStatus will be populated with the number of bytes transferred.
	/// </para>
	/// <para>
	/// If the cbMaxNumberOfBytesToRead argument is equal to 0, and the <c>PeerDistClientBlockRead</c> function completes successfully,
	/// the number of bytes transferred (obtained via either GetQueuedCompletionStatus or GetOverlappedResult) will contain the actual
	/// length of content available in the local cache.
	/// </para>
	/// <para>
	/// When this API completes with error values <c>PEERDIST_ERROR_MISSING_DATA</c> or <c>ERROR_TIMEOUT</c>, the <c>Offset</c> and
	/// <c>OffsetHigh</c> fields of the OVERLAPPED structure specify the <c>ULONGLONG</c> offset at which the missing data range begins.
	/// The OffsetHigh member will be set to the higher 32 bits of the offset and the Offset member will be set to the lower 32 bits of
	/// the offset. This missing data range is the start offset (relative to start of the content) and length, in bytes, which needs to
	/// be retrieved from an alternate source, like the original content server. In order to allow the Peer Distribution service to
	/// satisfy the same read in the future, add this data to the local cache by calling PeerDistClientAddData. The length of the
	/// missing data range is specified by the number of bytes transferred (obtained via GetQueuedCompletionStatus or GetOverlappedResult).
	/// </para>
	/// <para>
	/// It is important to note that the missing data range can start at any offset in the content and be any length up to the end of
	/// the content. In the event the content information passed to PeerDistClientAddContentInformation was generated in response to a
	/// range request, then the missing data range will be constrained to the range request bounds. This occurs when the call to
	/// PeerDistServerOpenContentInformation on the content server specified an offset and a length which was a sub-range of the content
	/// as a whole. A completion with <c>ERROR_NO_MORE</c> in this case indicates that the read offset is outside of the sub-range of
	/// the content.
	/// </para>
	/// <para>Range Requests</para>
	/// <para>
	/// If a client is interested in only a portion of the original content, a range request can be used to retrieve that portion. A
	/// range request contains an offset and length of the original content. The size of the content information is directly
	/// proportional to the size of the content requested.
	/// </para>
	/// <para>
	/// PeerDistServerOpenContentInformation supports generating content information for a range request via the ullContentOffset and
	/// cbContentLength parameters. The ullContentOffset parameter represents the offset in the original content where the range begins
	/// and cbContentLength represents the length of the range.
	/// </para>
	/// <para>
	/// Once a client obtains content information representing a particular content range, that content information works seamlessly
	/// with the PeerDistClientOpenContent, PeerDistClientAddContentInformation and PeerDistClientCompleteContentInformation APIs. The
	/// content information can be passed to PeerDistServerOpenContentInformation and will associate the <c>PEERDIST_CONTENT_HANDLE</c>
	/// with the content range. PeerDistClientStreamRead is constrained by the ullContentOffset offset and cbContentLength length
	/// specified in the server side call to PeerDistServerRetrieveContentInformation. <c>PeerDistClientStreamRead</c> will begin at
	/// ullContentOffset and will complete with the error code <c>PEERDIST_ERROR_NO_MORE</c> when the end of the content range is
	/// reached at ullContentOffset + cbContentLength. <c>PeerDistClientBlockRead</c> will complete with the error code
	/// <c>PEERDIST_ERROR_NO_MORE</c> if the offset specified in the OVERLAPPED parameter is less than ullContentOffset or greater than
	/// ullContentOffset + cbContentLength. <c>PeerDistClientStreamRead</c> and <c>PeerDistClientBlockRead</c> both limit the amount of
	/// missing data reported to the content range specified in the content information associated with the
	/// <c>PEERDIST_CONTENT_HANDLE</c>. For example, if the content information represents only the first half of the content, missing
	/// data will be limited to the first half of the content. In all other respects, <c>PeerDistClientBlockRead</c> and
	/// <c>PeerDistClientStreamRead</c> work with content ranges in exactly the same manner in which they work with the content as a whole.
	/// </para>
	/// <para>
	/// A client can use PeerDistClientStreamRead or <c>PeerDistClientBlockRead</c> to retrieve the content from the offset specified by
	/// the ullContentOffset up to the length specified by cbContentLength in the PeerDistServerRetrieveContentInformation call. Both
	/// <c>PeerDistClientStreamRead</c> and <c>PeerDistClientBlockRead</c> will complete with <c>PEERDIST_ERROR_NO_MORE</c> if the
	/// client tries to read beyond the range specified by the ullContentOffset and cbContentLength. Additionally,
	/// <c>PeerDistClientBlockRead</c> will also complete with the error code <c>PEERDIST_ERROR_NO_MORE</c> if the offset specified in
	/// the OVERLAPPED parameter is less than ullContentOffset
	/// </para>
	/// <para>
	/// If the read cannot not be completed from either the local cache or the peer cache, both PeerDistClientStreamRead and
	/// <c>PeerDistClientBlockRead</c> will report <c>PEERDIST_ERROR_MISSING_DATA</c>. When using the ranged content information,
	/// <c>PeerDistClientStreamRead</c> will report a missing data from the start offset of the range up to the end of the range.
	/// <c>PeerDistClientBlockRead</c> will report missing data from start offset of the range up to the end of the range.
	/// </para>
	/// <para>
	/// PeerDistClientAddData allows content data to be added even if it lies outside the content range. This extended data will be
	/// validated after the corresponding content information has been added to the local cache. Once validated, it becomes available to
	/// peers. In other words, if a client adds only content information for the first half of content, <c>PeerDistClientAddData</c>
	/// still allows the client to add data for the entire content. However, the second half of the content will not be validated until
	/// the corresponding content information for the second half has been added. No other Peer Distribution APIs are affected by range requests.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/peerdist/nf-peerdist-peerdistclientblockread DWORD PeerDistClientBlockRead(
	// PEERDIST_INSTANCE_HANDLE hPeerDist, PEERDIST_CONTENT_HANDLE hContentHandle, DWORD cbMaxNumberOfBytes, PBYTE pBuffer, DWORD
	// dwTimeoutInMilliseconds, LPOVERLAPPED lpOverlapped );
	[DllImport(Lib_PeerDist, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("peerdist.h", MSDNShortId = "NF:peerdist.PeerDistClientBlockRead")]
	public static unsafe extern Win32Error PeerDistClientBlockRead(PEERDIST_INSTANCE_HANDLE hPeerDist, PEERDIST_CONTENT_HANDLE hContentHandle, uint cbMaxNumberOfBytes,
		[Out, Optional] IntPtr pBuffer, uint dwTimeoutInMilliseconds, [In] NativeOverlapped* lpOverlapped);

	/// <summary>
	/// The <c>PeerDistClientCancelAsyncOperation</c> function cancels asynchronous operation associated with an OVERLAPPED structure
	/// and the content handle returned by PeerDistClientOpenContent.
	/// </summary>
	/// <param name="hPeerDist">A <c>PEERDIST_INSTANCE_HANDLE</c> returned by PeerDistStartup.</param>
	/// <param name="hContentHandle">A content handle opened by PeerDistClientOpenContent function call.</param>
	/// <param name="pOverlapped">
	/// Pointer to an OVERLAPPED structure that contains the canceling asynchronous operation data. If the pointer is <c>NULL</c> all
	/// asynchronous operations for specified content handle will be canceled.
	/// </param>
	/// <returns>
	/// <para>
	/// The function will return <c>ERROR_SUCCESS</c> value if the operation associated with the specified OVERLAPPED structure is
	/// successfully canceled. Otherwise, the function may return one of the following values:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>One or more parameters are invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The hPeerDist handle is invalid.</term>
	/// </item>
	/// <item>
	/// <term>PEERDIST_ERROR_OPERATION_NOT_FOUND</term>
	/// <term>The operation associated with the specified OVERLAPPED structure cannot be found.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_ACCESS_DISABLED_BY_POLICY</term>
	/// <term>The feature is disabled by Group Policy.</term>
	/// </item>
	/// <item>
	/// <term>PEERDIST_ERROR_SERVICE_UNAVAILABLE</term>
	/// <term>The service is unavailable.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function will synchronously cancel the operation, but will not return until the cancellation result is posted to the
	/// completion port or wait event is set to the signaled state. Any threads in waiting can receive the completion notice for the
	/// operation before or after the <c>PeerDistClientCancelAsyncOperation</c> function returns.
	/// </para>
	/// <para>
	/// This function does not guarantee that the operation will complete as canceled. The cancellation result will be posted only if no
	/// other results have been posted.
	/// </para>
	/// <para>To confirm successfully canceled operations, a call should be made to GetOverlappedResult with an expected return of <c>FALSE</c>.</para>
	/// <para>
	/// Additionally, calling GetLastError immediately after a successful <c>PeerDistClientCancelAsyncOperation</c> will return the
	/// <c>ERROR_OPERATION_ABORTED</c> error code.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/peerdist/nf-peerdist-peerdistclientcancelasyncoperation DWORD
	// PeerDistClientCancelAsyncOperation( PEERDIST_INSTANCE_HANDLE hPeerDist, PEERDIST_CONTENT_HANDLE hContentHandle, LPOVERLAPPED
	// pOverlapped );
	[DllImport(Lib_PeerDist, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("peerdist.h", MSDNShortId = "NF:peerdist.PeerDistClientCancelAsyncOperation")]
	public static unsafe extern Win32Error PeerDistClientCancelAsyncOperation(PEERDIST_INSTANCE_HANDLE hPeerDist, PEERDIST_CONTENT_HANDLE hContentHandle,
		[In] NativeOverlapped* pOverlapped);

	/// <summary>The <c>PeerDistClientCloseContent</c> function closes the content handle opened by PeerDistClientOpenContent.</summary>
	/// <param name="hPeerDist">A <c>PEERDIST_INSTANCE_HANDLE</c> returned by PeerDistStartup.</param>
	/// <param name="hContentHandle">A <c>PEERDIST_CONTENT_HANDLE</c> opened by PeerDistClientOpenContent.</param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is <c>ERROR_SUCCESS</c>. Otherwise, the function may return one of the following values:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>One or more parameters are invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The hPeerDist or hContent handle is invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>This function will cancel all pending asynchronous operations associated with the provided hContentHandle.</para>
	/// <para>All handles opened by the PeerDistClientOpenContent function must be closed by <c>PeerDistClientCloseContent</c>.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/peerdist/nf-peerdist-peerdistclientclosecontent DWORD
	// PeerDistClientCloseContent( PEERDIST_INSTANCE_HANDLE hPeerDist, PEERDIST_CONTENT_HANDLE hContentHandle );
	[DllImport(Lib_PeerDist, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("peerdist.h", MSDNShortId = "NF:peerdist.PeerDistClientCloseContent")]
	public static extern Win32Error PeerDistClientCloseContent(PEERDIST_INSTANCE_HANDLE hPeerDist, PEERDIST_CONTENT_HANDLE hContentHandle);

	/// <summary>The <c>PeerDistClientCompleteContentInformation</c> function completes the process of adding the content information.</summary>
	/// <param name="hPeerDist">A <c>PEERDIST_INSTANCE_HANDLE</c> returned by PeerDistStartup.</param>
	/// <param name="hContentHandle">A <c>PEERDIST_CONTENT_HANDLE</c> returned by PeerDistClientOpenContent.</param>
	/// <param name="lpOverlapped">Pointer to an OVERLAPPED structure.</param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is <c>ERROR_IO_PENDING</c>. Otherwise, the function may return one of the following values:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>One or more parameters are invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The hPeerDist handle is invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_ACCESS_DISABLED_BY_POLICY</term>
	/// <term>The feature is disabled by Group Policy.</term>
	/// </item>
	/// <item>
	/// <term>PEERDIST_ERROR_SERVICE_UNAVAILABLE</term>
	/// <term>The service is unavailable.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// Upon completion of this function, a client can call PeerDistClientStreamRead or PeerDistClientBlockRead to retrieve the data
	/// from the Peer Distribution system.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/peerdist/nf-peerdist-peerdistclientcompletecontentinformation DWORD
	// PeerDistClientCompleteContentInformation( PEERDIST_INSTANCE_HANDLE hPeerDist, PEERDIST_CONTENT_HANDLE hContentHandle,
	// LPOVERLAPPED lpOverlapped );
	[DllImport(Lib_PeerDist, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("peerdist.h", MSDNShortId = "NF:peerdist.PeerDistClientCompleteContentInformation")]
	public static unsafe extern Win32Error PeerDistClientCompleteContentInformation(PEERDIST_INSTANCE_HANDLE hPeerDist, PEERDIST_CONTENT_HANDLE hContentHandle,
		[In] NativeOverlapped* lpOverlapped);

	/// <summary>The PEERDIST_CONTENT_TAG.</summary>
	/// <param name="hPeerDist">A <c>PEERDIST_INSTANCE_HANDLE</c> returned by PeerDistStartup.</param>
	/// <param name="pContentTag">
	/// Pointer to a PEERDIST_CONTENT_TAG structure that contains the tag supplied when PeerDistClientOpenContent is called.
	/// </param>
	/// <param name="hCompletionPort">
	/// A handle to the completion port that can be used for retrieving the completion notification of the asynchronous function. To
	/// create a completion port, use the CreateIoCompletionPort function. This parameter can be <c>NULL</c>.
	/// </param>
	/// <param name="ulCompletionKey">
	/// Value to be returned through the lpCompletionKey parameter of the GetQueuedCompletionStatus function. This parameter is ignored
	/// when hCompletionPort is <c>NULL</c>.
	/// </param>
	/// <param name="lpOverlapped">
	/// Pointer to an OVERLAPPED structure. <c>Offset</c> and <c>OffsetHigh</c> are reserved and must be zero.
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is <c>ERROR_IO_PENDING</c>. Otherwise, the function may return one of the following values:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>One or more parameters are invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The hPeerDist handle is invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_ACCESS_DISABLED_BY_POLICY</term>
	/// <term>The feature is disabled by Group Policy.</term>
	/// </item>
	/// <item>
	/// <term>PEERDIST_ERROR_SERVICE_UNAVAILABLE</term>
	/// <term>The service is unavailable.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// The pContentTag is a client supplied tag passed to PeerDistClientOpenContent, which labels the content added by the client. This
	/// tag is used by the API to selectively flush content from the Peer Distribution cache.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/peerdist/nf-peerdist-peerdistclientflushcontent DWORD
	// PeerDistClientFlushContent( PEERDIST_INSTANCE_HANDLE hPeerDist, PCPEERDIST_CONTENT_TAG pContentTag, HANDLE hCompletionPort,
	// ULONG_PTR ulCompletionKey, LPOVERLAPPED lpOverlapped );
	[DllImport(Lib_PeerDist, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("peerdist.h", MSDNShortId = "NF:peerdist.PeerDistClientFlushContent")]
	public static unsafe extern Win32Error PeerDistClientFlushContent(PEERDIST_INSTANCE_HANDLE hPeerDist, in PEERDIST_CONTENT_TAG pContentTag,
		[In, Optional] HANDLE hCompletionPort, [In, Optional] UIntPtr ulCompletionKey, [In] NativeOverlapped* lpOverlapped);

	/// <summary>
	/// The <c>PeerDistClientGetInformationByHandle</c> function retrieves additional information from the Peer Distribution service for
	/// a specific content handle.
	/// </summary>
	/// <param name="hPeerDist">A <c>PEERDIST_INSTANCE_HANDLE</c> returned by the PeerDistStartup function.</param>
	/// <param name="hContentHandle">A <c>PEERDIST_CONTENT_HANDLE</c> returned by the PeerDistClientOpenContent function.</param>
	/// <param name="PeerDistClientInfoClass">
	/// A value from the PEERDIST_CLIENT_INFO_BY_HANDLE_CLASS enumeration that indicates the information to retrieve.
	/// </param>
	/// <param name="dwBufferSize">The size, in bytes, of the buffer for the lpInformation parameter.</param>
	/// <param name="lpInformation">
	/// A buffer for the returned information. The format of this information depends on the value of the PeerDistClientInfoClass parameter.
	/// </param>
	/// <returns>If the function succeeds, the return value is ERROR_SUCCESS.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/peerdist/nf-peerdist-peerdistclientgetinformationbyhandle DWORD
	// PeerDistClientGetInformationByHandle( PEERDIST_INSTANCE_HANDLE hPeerDist, PEERDIST_CONTENT_HANDLE hContentHandle,
	// PEERDIST_CLIENT_INFO_BY_HANDLE_CLASS PeerDistClientInfoClass, DWORD dwBufferSize, LPVOID lpInformation );
	[DllImport(Lib_PeerDist, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("peerdist.h", MSDNShortId = "NF:peerdist.PeerDistClientGetInformationByHandle")]
	public static extern Win32Error PeerDistClientGetInformationByHandle(PEERDIST_INSTANCE_HANDLE hPeerDist, PEERDIST_CONTENT_HANDLE hContentHandle,
		PEERDIST_CLIENT_INFO_BY_HANDLE_CLASS PeerDistClientInfoClass, uint dwBufferSize, [Out] IntPtr lpInformation);

	/// <summary>
	/// The <c>PeerDistClientOpenContent</c> function opens and returns a PEERDIST_CONTENT_HANDLE. The client uses the content handle to
	/// retrieve data from the Peer Distribution service.
	/// </summary>
	/// <param name="hPeerDist">A <c>PEERDIST_INSTANCE_HANDLE</c> returned by PeerDistStartup.</param>
	/// <param name="pContentTag">
	/// Pointer to a PEERDIST_CONTENT_TAG structure that contains a 16 byte client specified identifier. This parameter is used in
	/// conjunction with the PeerDistClientFlushContent function.
	/// </param>
	/// <param name="hCompletionPort">
	/// A handle to the completion port that can be used for retrieving the completion notification of the asynchronous function. To
	/// create a completion port, use the CreateIoCompletionPort function This parameter can be <c>NULL</c>.
	/// </param>
	/// <param name="ulCompletionKey">
	/// Value to be returned through the lpCompletionKey parameter of the GetQueuedCompletionStatus function. This parameter is ignored
	/// when hCompletionPort is <c>NULL</c>.
	/// </param>
	/// <param name="phContentHandle">
	/// A pointer to a variable that receives the <c>PEERDIST_CONTENT_HANDLE</c> used to retrieve or add data.
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is <c>ERROR_SUCCESS</c>. Otherwise, the function may return one of the following values:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>One or more parameters are invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The hPeerDist handle is invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_ACCESS_DISABLED_BY_POLICY</term>
	/// <term>The feature is disabled by Group Policy.</term>
	/// </item>
	/// <item>
	/// <term>PEERDIST_ERROR_SERVICE_UNAVAILABLE</term>
	/// <term>The service is unavailable.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Client must call the <c>PeerDistClientOpenContent</c> function to obtain a <c>PEERDIST_CONTENT_HANDLE</c> handle that later can
	/// be used in the following functions:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>PeerDistClientAddContentInformation</term>
	/// </item>
	/// <item>
	/// <term>PeerDistClientCompleteContentInformation</term>
	/// </item>
	/// <item>
	/// <term>PeerDistClientBlockRead</term>
	/// </item>
	/// <item>
	/// <term>PeerDistClientStreamRead</term>
	/// </item>
	/// <item>
	/// <term>PeerDistClientAddData</term>
	/// </item>
	/// </list>
	/// <para>
	/// If an optional completion port handle is specified, it is used for posting the completion results of above listed asynchronous functions.
	/// </para>
	/// <para>The handle returned by <c>PeerDistClientOpenContent</c> function call must be closed by PeerDistClientCloseContent function.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/peerdist/nf-peerdist-peerdistclientopencontent DWORD
	// PeerDistClientOpenContent( PEERDIST_INSTANCE_HANDLE hPeerDist, PCPEERDIST_CONTENT_TAG pContentTag, HANDLE hCompletionPort,
	// ULONG_PTR ulCompletionKey, PPEERDIST_CONTENT_HANDLE phContentHandle );
	[DllImport(Lib_PeerDist, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("peerdist.h", MSDNShortId = "NF:peerdist.PeerDistClientOpenContent")]
	public static extern Win32Error PeerDistClientOpenContent(PEERDIST_INSTANCE_HANDLE hPeerDist, in PEERDIST_CONTENT_TAG pContentTag,
		[In, Optional] HANDLE hCompletionPort, [In, Optional] UIntPtr ulCompletionKey, out PEERDIST_CONTENT_HANDLE phContentHandle);

	/// <summary>The <c>PeerDistClientStreamRead</c> reads a sequence of bytes from content stream.</summary>
	/// <param name="hPeerDist">A <c>PEERDIST_INSTANCE_HANDLE</c> returned by PeerDistStartup.</param>
	/// <param name="hContentHandle">A content handle opened by the PeerDistClientOpenContent function call.</param>
	/// <param name="cbMaxNumberOfBytes">
	/// The maximum number of bytes to read. If the cbMaxNumberOfBytesToRead is equal to 0, it indicates that the
	/// <c>PeerDistClientStreamRead</c> function is querying the length of available consecutive content byes in the local cache at the
	/// current stream read offset. The query will neither download content from the peers, nor return the count of bytes present in the
	/// peer cache.
	/// </param>
	/// <param name="pBuffer">
	/// Pointer to the buffer that receives the data from the local cache. This buffer must remain valid for the duration of the read
	/// operation. The caller must not use this buffer until the read operation is completed. If the cbMaxNumberOfBytesToRead argument
	/// is equal to 0, the pBuffer parameter can be <c>NULL</c>.
	/// </param>
	/// <param name="dwTimeoutInMilliseconds">
	/// <para>Timeout value for the read, in milliseconds. There are two special values that may be specified:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>PEERDIST_READ_TIMEOUT_LOCAL_CACHE_ONLY</term>
	/// <term>Specifies that a read should not cause any additional network traffic by contacting peers or a Hosted Cache.</term>
	/// </item>
	/// <item>
	/// <term>PEERDIST_READ_TIMEOUT_DEFAULT</term>
	/// <term>Specifies the default timeout of 5 seconds.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="lpOverlapped">
	/// Pointer to an OVERLAPPED structure. Stream read does not allow the caller to specify the start <c>Offset</c> for the reading.
	/// The next stream read offset is implicitly maintained per hContentHandle.
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is <c>ERROR_IO_PENDING</c>. Otherwise, the function may return one of the following values:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>One or more parameters are invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The hPeerDist or hContent handle is invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_ACCESS_DISABLED_BY_POLICY</term>
	/// <term>The feature is disabled by Group Policy.</term>
	/// </item>
	/// <item>
	/// <term>PEERDIST_ERROR_SERVICE_UNAVAILABLE</term>
	/// <term>The service is unavailable.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>PeerDistClientStreamRead</c> queues the read and immediately returns to the caller. As a result, multiple reads can be issued
	/// simultaneously with the data buffers utilized in a first-in/first-out manner. <c>PeerDistClientStreamRead</c> will complete a
	/// read as soon as any data is available and will not wait for the buffer to fill completely.
	/// </para>
	/// <para>
	/// If the <c>PeerDistClientStreamRead</c> function operation completes successfully, the <c>Offset</c> and <c>OffsetHigh</c> fields
	/// of the OVERLAPPED structure will be populated with the <c>ULONGLONG</c> offset at which the read started. The OffsetHigh member
	/// will be set to the higher 32 bits of the offset and the Offset member will be set to the lower 32 bits of the offset.
	/// GetOverlappedResult populates lpNumberOfBytesTransferred with the number of bytes transferred. In the event the caller is using
	/// a completion port to process Peer Distribution API completions then the lpNumberOfBytes argument of GetQueuedCompletionStatus
	/// will be populated with the number of bytes transferred. The stream offset will be advanced by the number of bytes reported as
	/// read. To query the length of available content for content larger than 4GB, PeerDistClientBlockRead can be used with
	/// cbMaxNumberOfBytesToRead equal to 0 and appropriate offsets.
	/// </para>
	/// <para>
	/// If the API completes with the error value <c>PEERDIST_ERROR_MISSING_DATA</c> or <c>ERROR_TIMEOUT</c>, the <c>Offset</c> and
	/// <c>OffsetHigh</c> fields of the OVERLAPPED structure specify the <c>ULONGLONG</c> offset at which the missing data range begins.
	/// The <c>OffsetHigh</c> member will be set to the higher 32 bits of the offset and the <c>Offset</c> member will be set to the
	/// lower 32 bits of the offset. This missing data range is the start offset (relative to start of the content) and length, in
	/// bytes, which needs to be retrieved from an alternate source, like the original content server., In order to allow the Peer
	/// Distribution service to satisfy the same read in the future, add this data to the local cache by calling PeerDistClientAddData.
	/// The length of the missing data range is specified by the number of bytes transferred (obtained via GetQueuedCompletionStatus or
	/// GetOverlappedResult). The stream offset is advanced by the number of bytes reported as the length of the missing data range.
	/// </para>
	/// <para>
	/// If <c>PeerDistClientStreamRead</c> is called after the stream offset has advanced beyond the end of the content, the API will
	/// complete with <c>ERROR_NO_MORE</c>.
	/// </para>
	/// <para>
	/// It is important to note that the missing data range can start at any offset in the content and be any length up to the end of
	/// the content. In the event the content information passed to PeerDistClientAddContentInformation was generated in response to a
	/// range request, then the missing data range will be constrained to the range request bounds. This will happen when the call to
	/// PeerDistServerOpenContentInformation on the content server specified an offset and a length which was a sub-range of the content
	/// as a whole. A completion with <c>ERROR_NO_MORE</c> in this case indicates that the read offset is outside of the sub-range of
	/// the content.
	/// </para>
	/// <para>Range Requests</para>
	/// <para>
	/// If a client is interested in only a portion of the original content, a range request can be used to retrieve that portion. A
	/// range request contains an offset and length of the original content. The size of the content information is directly
	/// proportional to the size of the content requested.
	/// </para>
	/// <para>
	/// PeerDistServerOpenContentInformation supports generating content information for a range request via the ullContentOffset and
	/// cbContentLength parameters. The ullContentOffset parameter represents the offset in the original content where the range begins
	/// and cbContentLength represents the length of the range.
	/// </para>
	/// <para>
	/// Once a client obtains content information representing a particular content range, that content information works seamlessly
	/// with the PeerDistClientOpenContent, PeerDistClientAddContentInformation and PeerDistClientCompleteContentInformation APIs. The
	/// content information can be passed to PeerDistServerOpenContentInformation and will associate the <c>PEERDIST_CONTENT_HANDLE</c>
	/// with the content range. <c>PeerDistClientStreamRead</c> is constrained by the ullContentOffset offset and cbContentLength length
	/// specified in the server side call to PeerDistServerRetrieveContentInformation. <c>PeerDistClientStreamRead</c> will begin at
	/// ullContentOffset and will complete with the error code <c>PEERDIST_ERROR_NO_MORE</c> when the end of the content range is
	/// reached at ullContentOffset + cbContentLength. PeerDistClientBlockRead will complete with the error code
	/// <c>PEERDIST_ERROR_NO_MORE</c> if the offset specified in the OVERLAPPED parameter is less than ullContentOffset or greater than
	/// ullContentOffset + cbContentLength. <c>PeerDistClientStreamRead</c> and <c>PeerDistClientBlockRead</c> both limit the amount of
	/// missing data reported to the content range specified in the content information associated with the
	/// <c>PEERDIST_CONTENT_HANDLE</c>. For example, if the content information represents only the first half of the content, missing
	/// data will be limited to the first half of the content. In all other respects, <c>PeerDistClientBlockRead</c> and
	/// <c>PeerDistClientStreamRead</c> work with content ranges in exactly the same manner in which they work with the content as a whole.
	/// </para>
	/// <para>
	/// A client can use <c>PeerDistClientStreamRead</c> or PeerDistClientBlockRead to retrieve the content from the offset specified by
	/// the ullContentOffset up to the length specified by cbContentLength in the PeerDistServerRetrieveContentInformation call. Both
	/// <c>PeerDistClientStreamRead</c> and <c>PeerDistClientBlockRead</c> will complete with <c>PEERDIST_ERROR_NO_MORE</c> if the
	/// client tries to read beyond the range specified by the ullContentOffset and cbContentLength. Additionally,
	/// <c>PeerDistClientBlockRead</c> will also complete with the error code <c>PEERDIST_ERROR_NO_MORE</c> if the offset specified in
	/// the OVERLAPPED parameter is less than ullContentOffset
	/// </para>
	/// <para>
	/// If the read cannot not be completed from either the local cache or the peer cache, both <c>PeerDistClientStreamRead</c> and
	/// PeerDistClientBlockRead will report <c>PEERDIST_ERROR_MISSING_DATA</c>. When using the ranged content information,
	/// <c>PeerDistClientStreamRead</c> will report a missing data from the start offset of the range up to the end of the range.
	/// <c>PeerDistClientBlockRead</c> will report missing data from start offset of the range up to the end of the range.
	/// </para>
	/// <para>
	/// PeerDistClientAddData allows content data to be added even if it lies outside the content range. This extended data will be
	/// validated after the corresponding content information has been added to the local cache. Once validated, it becomes available to
	/// peers. In other words, if a client adds only content information for the first half of content, <c>PeerDistClientAddData</c>
	/// still allows the client to add data for the entire content. However, the second half of the content will not be validated until
	/// the corresponding content information for the second half has been added. No other Peer Distribution APIs are affected by range requests.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/peerdist/nf-peerdist-peerdistclientstreamread DWORD PeerDistClientStreamRead(
	// PEERDIST_INSTANCE_HANDLE hPeerDist, PEERDIST_CONTENT_HANDLE hContentHandle, DWORD cbMaxNumberOfBytes, PBYTE pBuffer, DWORD
	// dwTimeoutInMilliseconds, LPOVERLAPPED lpOverlapped );
	[DllImport(Lib_PeerDist, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("peerdist.h", MSDNShortId = "NF:peerdist.PeerDistClientStreamRead")]
	public static unsafe extern Win32Error PeerDistClientStreamRead(PEERDIST_INSTANCE_HANDLE hPeerDist, PEERDIST_CONTENT_HANDLE hContentHandle,
		uint cbMaxNumberOfBytes, [Out, Optional] IntPtr pBuffer, uint dwTimeoutInMilliseconds, [In] NativeOverlapped* lpOverlapped);

	/// <summary>
	/// The <c>PeerDistGetOverlappedResult</c> function retrieves the results of asynchronous operations. This function replaces the
	/// GetOverlappedResult function for Peer Distribution asynchronous operations.
	/// </summary>
	/// <param name="lpOverlapped">A pointer to an OVERLAPPED structure that was specified when the overlapped operation was started.</param>
	/// <param name="lpNumberOfBytesTransferred">
	/// A pointer to a variable that receives the number of bytes that were actually transferred by a read or write operation.
	/// </param>
	/// <param name="bWait">
	/// If this parameter is
	/// <code>true</code>
	/// , the function does not return until the operation has been completed. If this parameter is
	/// <code>false</code>
	/// and the operation is still pending, the function returns
	/// <code>false</code>
	/// .
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para>
	/// <code>true</code>
	/// if the operation has completed.
	/// <code>false</code>
	/// if the bWait argument is
	/// <code>false</code>
	/// and the operation is still pending.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/peerdist/nf-peerdist-peerdistgetoverlappedresult BOOL
	// PeerDistGetOverlappedResult( LPOVERLAPPED lpOverlapped, LPDWORD lpNumberOfBytesTransferred, BOOL bWait );
	[DllImport(Lib_PeerDist, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("peerdist.h", MSDNShortId = "NF:peerdist.PeerDistGetOverlappedResult")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static unsafe extern bool PeerDistGetOverlappedResult([In] NativeOverlapped* lpOverlapped, out uint lpNumberOfBytesTransferred, [MarshalAs(UnmanagedType.Bool)] bool bWait);

	/// <summary>The <c>PeerDistGetStatus</c> function returns the current status of the Peer Distribution service.</summary>
	/// <param name="hPeerDist">A <c>PEERDIST_INSTANCE_HANDLE</c> returned by PeerDistStartup.</param>
	/// <param name="pPeerDistStatus">
	/// A pointer to a PEERDIST_STATUS enumeration which upon operation success receives the current status of the Peer Distribution service.
	/// </param>
	/// <returns>If the function succeeds, the return value is <c>ERROR_SUCCESS</c>.</returns>
	/// <remarks>
	/// A Group Policy change can result in the Peer Distribution service moving to an available, unavailable, or disabled state.
	/// Depending on the resultant state of this transition, the content, content information, or stream handles the caller has access
	/// to may no longer function. If this is the case, the caller must explicitly close the handles by calling the appropriate Peer
	/// Distribution API.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/peerdist/nf-peerdist-peerdistgetstatus DWORD PeerDistGetStatus(
	// PEERDIST_INSTANCE_HANDLE hPeerDist, PEERDIST_STATUS *pPeerDistStatus );
	[DllImport(Lib_PeerDist, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("peerdist.h", MSDNShortId = "NF:peerdist.PeerDistGetStatus")]
	public static extern Win32Error PeerDistGetStatus(PEERDIST_INSTANCE_HANDLE hPeerDist, out PEERDIST_STATUS pPeerDistStatus);

	/// <summary>The <c>PeerDistGetStatusEx</c> function returns the current status and capabilities of the Peer Distribution service.</summary>
	/// <param name="hPeerDist">A <c>PEERDIST_INSTANCE_HANDLE</c> returned by PeerDistStartup.</param>
	/// <param name="pPeerDistStatus">
	/// A pointer to a PEERDIST_STATUS_INFO structure that contains the current status and capabilities of the Peer Distribution service.
	/// </param>
	/// <returns>If the function succeeds, the return value is <c>ERROR_SUCCESS</c>.</returns>
	/// <remarks>
	/// A Group Policy change can result in the Peer Distribution service moving to an available, unavailable, or disabled state.
	/// Depending on the resultant state of this transition, the content, content information, or stream handles the caller has access
	/// to may no longer function. If this is the case, the caller must explicitly close the handles by calling the appropriate Peer
	/// Distribution API.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/peerdist/nf-peerdist-peerdistgetstatusex DWORD PeerDistGetStatusEx(
	// PEERDIST_INSTANCE_HANDLE hPeerDist, PEERDIST_STATUS_INFO *pPeerDistStatus );
	[DllImport(Lib_PeerDist, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("peerdist.h", MSDNShortId = "NF:peerdist.PeerDistGetStatusEx")]
	public static extern Win32Error PeerDistGetStatusEx(PEERDIST_INSTANCE_HANDLE hPeerDist, ref PEERDIST_STATUS_INFO pPeerDistStatus);

	/// <summary>
	/// The <c>PeerDistRegisterForStatusChangeNotification</c> function requests the Peer Distribution service status change notification.
	/// </summary>
	/// <param name="hPeerDist">A <c>PEERDIST_INSTANCE_HANDLE</c> returned by PeerDistStartup.</param>
	/// <param name="hCompletionPort">
	/// A handle to the completion port that can be used for retrieving the completion notification of the asynchronous function. To
	/// create a completion port, use the CreateIoCompletionPort function. This parameter can be <c>NULL</c>.
	/// </param>
	/// <param name="ulCompletionKey">
	/// Value to be returned through the lpCompletionKey parameter of the GetQueuedCompletionStatus function. This parameter is ignored
	/// when hCompletionPort is <c>NULL</c>.
	/// </param>
	/// <param name="lpOverlapped">
	/// Pointer to an OVERLAPPED structure. If the <c>hEvent</c> member of the structure is not <c>NULL</c>, it will be signaled via
	/// SetEvent() used in order to signal the notification. This can occur even if the completion port is specified via the
	/// hCompletionPort argument.
	/// </param>
	/// <param name="pPeerDistStatus">
	/// A pointer to a PEERDIST_STATUS enumeration that indicates the current status of the Peer Distribution service.
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is <c>ERROR_IO_PENDING</c>. Otherwise, the function may return one of the following values:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>One or more parameters are invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The hPeerDist handle is invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function optionally registers a completion port and an OVERLAPPED structure for status change notification. Upon successful
	/// completion, the pPeerDistStatus parameter will contain a valid <c>PEERDIST_STATUS</c> value.
	/// </para>
	/// <para>
	/// Only one active registration for each session is allowed. The caller must register for notification each time after it signals.
	/// The notification will be sent only if the current status is changed from the previous notification. After the first call of the
	/// <c>PeerDistRegisterForStatusChangeNotification</c> function for the Peer Distribution session, the first notification will
	/// trigger only if the status is no longer equal to <c>PEERDIST_STATUS_DISABLED</c>.
	/// </para>
	/// <para>
	/// A Peer Distribution status change can result in the Peer Distribution service moving to an available, unavailable, or disabled
	/// state. If the new status is disabled or unavailable, the content, content information, or stream handles the caller has access
	/// to will no longer function. In this case, any API that uses these handles will fail with error <c>PEERDIST_
	/// ERROR_INVALIDATED</c>. The caller must explicitly close the handles by calling the appropriate Peer Distribution API.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/peerdist/nf-peerdist-peerdistregisterforstatuschangenotification DWORD
	// PeerDistRegisterForStatusChangeNotification( PEERDIST_INSTANCE_HANDLE hPeerDist, HANDLE hCompletionPort, ULONG_PTR
	// ulCompletionKey, LPOVERLAPPED lpOverlapped, PEERDIST_STATUS *pPeerDistStatus );
	[DllImport(Lib_PeerDist, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("peerdist.h", MSDNShortId = "NF:peerdist.PeerDistRegisterForStatusChangeNotification")]
	public static unsafe extern Win32Error PeerDistRegisterForStatusChangeNotification(PEERDIST_INSTANCE_HANDLE hPeerDist, [In, Optional] HANDLE hCompletionPort,
		[In, Optional] UIntPtr ulCompletionKey, [In] NativeOverlapped* lpOverlapped, out PEERDIST_STATUS pPeerDistStatus);

	/// <summary>
	/// The <c>PeerDistRegisterForStatusChangeNotificationEx</c> function requests the Peer Distribution service status change notification.
	/// </summary>
	/// <param name="hPeerDist">A <c>PEERDIST_INSTANCE_HANDLE</c> returned by PeerDistStartup.</param>
	/// <param name="hCompletionPort">
	/// A handle to the completion port that can be used for retrieving the completion notification of the asynchronous function. To
	/// create a completion port, use the CreateIoCompletionPort function. This parameter can be <c>NULL</c>.
	/// </param>
	/// <param name="ulCompletionKey">
	/// Value to be returned through the lpCompletionKey parameter of the GetQueuedCompletionStatus function. This parameter is ignored
	/// when hCompletionPort is <c>NULL</c>.
	/// </param>
	/// <param name="lpOverlapped">
	/// Pointer to an OVERLAPPED structure. If the <c>hEvent</c> member of the structure is not <c>NULL</c>, it will be signaled via
	/// SetEvent() used in order to signal the notification. This can occur even if the completion port is specified via the
	/// hCompletionPort argument.
	/// </param>
	/// <param name="pPeerDistStatus">
	/// A pointer to a PEERDIST_STATUS_INFO structure that contains the current status and capabilities of the Peer Distribution service.
	/// </param>
	/// <returns>If the function succeeds, the return value is ERROR_SUCCESS.</returns>
	/// <remarks>
	/// <para>
	/// This function optionally registers a completion port and an OVERLAPPED structure for status change notification. Upon successful
	/// completion, the pPeerDistStatus parameter will contain a valid <c>PEERDIST_STATUS</c> value.
	/// </para>
	/// <para>
	/// Only one active registration for each session is allowed. The caller must register for notification each time after it signals.
	/// The notification will be sent only if the current status is changed from the previous notification. After the first call of the
	/// PeerDistRegisterForStatusChangeNotification function for the Peer Distribution session, the first notification will trigger only
	/// if the status is no longer equal to <c>PEERDIST_STATUS_DISABLED</c>.
	/// </para>
	/// <para>
	/// A Peer Distribution status change can result in the Peer Distribution service moving to an available, unavailable, or disabled
	/// state. If the new status is disabled or unavailable, the content, content information, or stream handles the caller has access
	/// to will no longer function. In this case, any API that uses these handles will fail with error <c>PEERDIST_
	/// ERROR_INVALIDATED</c>. The caller must explicitly close the handles by calling the appropriate Peer Distribution API.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/peerdist/nf-peerdist-peerdistregisterforstatuschangenotificationex DWORD
	// PeerDistRegisterForStatusChangeNotificationEx( PEERDIST_INSTANCE_HANDLE hPeerDist, HANDLE hCompletionPort, ULONG_PTR
	// ulCompletionKey, LPOVERLAPPED lpOverlapped, PEERDIST_STATUS_INFO *pPeerDistStatus );
	[DllImport(Lib_PeerDist, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("peerdist.h", MSDNShortId = "NF:peerdist.PeerDistRegisterForStatusChangeNotificationEx")]
	public static unsafe extern Win32Error PeerDistRegisterForStatusChangeNotificationEx(PEERDIST_INSTANCE_HANDLE hPeerDist, [In, Optional] HANDLE hCompletionPort,
		[In, Optional] UIntPtr ulCompletionKey, [In] NativeOverlapped* lpOverlapped, ref PEERDIST_STATUS_INFO pPeerDistStatus);

	/// <summary>
	/// The <c>PeerDistServerCancelAsyncOperation</c> function cancels the asynchronous operation associated with the content identifier
	/// and OVERLAPPED structure.
	/// </summary>
	/// <param name="hPeerDist">A <c>PEERDIST_INSTANCE_HANDLE</c> returned by PeerDistStartup.</param>
	/// <param name="cbContentIdentifier">The length, in bytes, of the content identifier.</param>
	/// <param name="pContentIdentifier">Pointer to an array that contains the content identifier.</param>
	/// <param name="pOverlapped">Pointer to an OVERLAPPED structure that contains the canceling asynchronous operation data.</param>
	/// <returns>
	/// <para>
	/// The function will return <c>ERROR_SUCCESS</c> value if the operation associated with OVERLAPPED structure is successfully
	/// canceled. Otherwise, the function may return one of the following values:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>One or more parameters are invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The hPeerDist handle is invalid.</term>
	/// </item>
	/// <item>
	/// <term>PEERDIST_ERROR_OPERATION_NOT_FOUND</term>
	/// <term>The operation for OVERLAPPED structure cannot be found.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_ACCESS_DISABLED_BY_POLICY</term>
	/// <term>The feature is disabled by Group Policy.</term>
	/// </item>
	/// <item>
	/// <term>PEERDIST_ERROR_SERVICE_UNAVAILABLE</term>
	/// <term>The service is unavailable.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function will synchronously cancel the operation, but will not return until the cancelation result is posted to the
	/// completion port or wait event is set to the 'signaled' state. Any threads in waiting can receive the completion notice for the
	/// operation before or after the <c>PeerDistServerCancelAsyncOperation</c> function returns.
	/// </para>
	/// <para>
	/// This function does not guarantee that the operation will complete as canceled. The cancellation result will be posted only if no
	/// other results have been posted.
	/// </para>
	/// <para>To confirm successfully canceled operations, a call should be made to GetOverlappedResult with an expected return of <c>FALSE</c>.</para>
	/// <para>
	/// Additionally, calling GetLastError immediately after a successful <c>PeerDistServerCancelAsyncOperation</c> will return the
	/// <c>ERROR_OPERATION_ABORTED</c> error code.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/peerdist/nf-peerdist-peerdistservercancelasyncoperation DWORD
	// PeerDistServerCancelAsyncOperation( PEERDIST_INSTANCE_HANDLE hPeerDist, DWORD cbContentIdentifier, PBYTE pContentIdentifier,
	// LPOVERLAPPED pOverlapped );
	[DllImport(Lib_PeerDist, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("peerdist.h", MSDNShortId = "NF:peerdist.PeerDistServerCancelAsyncOperation")]
	public static unsafe extern Win32Error PeerDistServerCancelAsyncOperation(PEERDIST_INSTANCE_HANDLE hPeerDist, uint cbContentIdentifier,
		[In] IntPtr pContentIdentifier, [In] NativeOverlapped* pOverlapped);

	/// <summary>The <c>PeerDistServerCloseContentInformation</c> function closes the handle opened by PeerDistServerOpenContentInformation.</summary>
	/// <param name="hPeerDist">The <c>PEERDIST_INSTANCE_HANDLE</c> returned by PeerDistStartup.</param>
	/// <param name="hContentInfo">The handle returned by PeerDistServerOpenContentInformation.</param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is <c>ERROR_SUCCESS</c>. Otherwise, the function may return one of the following values:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The provided hPeerDist or hContentInfo handles are invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_ACCESS_DISABLED_BY_POLICY</term>
	/// <term>The feature is disabled by Group Policy.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// The <c>PeerDistServerCloseContentInformation</c> closes the <c>PEERDIST_CONTENTINFO_HANDLE</c>. Additionally, calling
	/// <c>PeerDistServerCloseContentInformation</c> will cancel any pending operations associated with the <c>PEERDIST_CONTENTINFO_HANDLE</c>.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/peerdist/nf-peerdist-peerdistserverclosecontentinformation DWORD
	// PeerDistServerCloseContentInformation( PEERDIST_INSTANCE_HANDLE hPeerDist, PEERDIST_CONTENTINFO_HANDLE hContentInfo );
	[DllImport(Lib_PeerDist, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("peerdist.h", MSDNShortId = "NF:peerdist.PeerDistServerCloseContentInformation")]
	public static extern Win32Error PeerDistServerCloseContentInformation(PEERDIST_INSTANCE_HANDLE hPeerDist, PEERDIST_CONTENTINFO_HANDLE hContentInfo);

	/// <summary>The <c>PeerDistServerCloseStreamHandle</c> function closes a handle returned by PeerDistServerPublishStream.</summary>
	/// <param name="hPeerDist">A PEERDIST_INSTANCE_HANDLE returned by PeerDistStartup.</param>
	/// <param name="hStream">A PEERDIST_STREAM_HANDLE returned by PeerDistServerPublishStream.</param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is <c>ERROR_SUCCESS</c>. Otherwise, the function may return one of the following values:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>One or more parameters are invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The hPeerDist or hStream handle is invalid</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>PeerDistServerCloseStreamHandle</c> function call cancels all pending operations associated with hStream. To prevent
	/// unintended cancellation of publication and closure of the stream handle, this function should be called after the completion of PeerDistServerPublishCompleteStream.
	/// </para>
	/// <para><c>PeerDistServerCloseStreamHandle</c> does not remove the publication. In order to remove the publication, call PeerDistServerUnpublish.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/peerdist/nf-peerdist-peerdistserverclosestreamhandle DWORD
	// PeerDistServerCloseStreamHandle( PEERDIST_INSTANCE_HANDLE hPeerDist, PEERDIST_STREAM_HANDLE hStream );
	[DllImport(Lib_PeerDist, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("peerdist.h", MSDNShortId = "NF:peerdist.PeerDistServerCloseStreamHandle")]
	public static extern Win32Error PeerDistServerCloseStreamHandle(PEERDIST_INSTANCE_HANDLE hPeerDist, PEERDIST_STREAM_HANDLE hStream);

	/// <summary>
	/// The <c>PeerDistServerOpenContentInformation</c> function opens a <c>PEERDIST_CONTENTINFO_HANDLE</c>. The client uses the handle
	/// to retrieve content information.
	/// </summary>
	/// <param name="hPeerDist">A <c>PEERDIST_INSTANCE_HANDLE</c> returned by PeerDistStartup.</param>
	/// <param name="cbContentIdentifier">The length, in bytes, of the content identifier.</param>
	/// <param name="pContentIdentifier">Pointer to a buffer that contains the content identifier.</param>
	/// <param name="ullContentOffset">
	/// An offset from the beginning of the published content for which the content information handle is requested.
	/// </param>
	/// <param name="cbContentLength">
	/// The length, in bytes, of the content (starting from the ullContentOffset) for which the content information is requested.
	/// </param>
	/// <param name="hCompletionPort">
	/// A handle to the completion port used for retrieving the completion notification of the asynchronous function. To create a
	/// completion port, use the CreateIoCompletionPort function. This parameter can be <c>NULL</c>.
	/// </param>
	/// <param name="ulCompletionKey">
	/// Value to be returned through the lpCompletionKey parameter of the GetQueuedCompletionStatus function. This parameter is ignored
	/// when hCompletionPort is <c>NULL</c>.
	/// </param>
	/// <param name="phContentInfo">A handle used to retrieve the content information.</param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is <c>ERROR_SUCCESS</c>. Otherwise, the function may return one of the following values:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>One or more parameters are invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The hPeerDist handle is invalid.</term>
	/// </item>
	/// <item>
	/// <term>PEERDIST_ERROR_NOT_FOUND</term>
	/// <term>The specified content identifier data is not published.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_ACCESS_DISABLED_BY_POLICY</term>
	/// <term>The feature is disabled by Group Policy.</term>
	/// </item>
	/// <item>
	/// <term>PEERDIST_ERROR_SERVICE_UNAVAILABLE</term>
	/// <term>The service is unavailable.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If function succeeds, the handle received by phContentInfo can be passed to the PeerDistServerRetrieveContentInformation
	/// function to retrieve content information. The handle must be closed via the PeerDistServerCloseContentInformation function.
	/// </para>
	/// <para>If ullContentOffset and cbContentLength are both zero, then the content information for the whole content will be retrieved.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/peerdist/nf-peerdist-peerdistserveropencontentinformation DWORD
	// PeerDistServerOpenContentInformation( PEERDIST_INSTANCE_HANDLE hPeerDist, DWORD cbContentIdentifier, PBYTE pContentIdentifier,
	// ULONGLONG ullContentOffset, ULONGLONG cbContentLength, HANDLE hCompletionPort, ULONG_PTR ulCompletionKey,
	// PPEERDIST_CONTENTINFO_HANDLE phContentInfo );
	[DllImport(Lib_PeerDist, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("peerdist.h", MSDNShortId = "NF:peerdist.PeerDistServerOpenContentInformation")]
	public static extern Win32Error PeerDistServerOpenContentInformation(PEERDIST_INSTANCE_HANDLE hPeerDist, uint cbContentIdentifier,
		[In] IntPtr pContentIdentifier, ulong ullContentOffset, ulong cbContentLength, [In, Optional] HANDLE hCompletionPort,
		[In, Optional] UIntPtr ulCompletionKey, out PEERDIST_CONTENTINFO_HANDLE phContentInfo);

	/// <summary>
	/// The <c>PeerDistServerOpenContentInformationEx</c> function opens a <c>PEERDIST_CONTENTINFO_HANDLE</c>. The client uses the
	/// handle to retrieve content information.
	/// </summary>
	/// <param name="hPeerDist">A <c>PEERDIST_INSTANCE_HANDLE</c> returned by PeerDistStartup.</param>
	/// <param name="cbContentIdentifier">The length, in bytes, of the content identifier.</param>
	/// <param name="pContentIdentifier">Pointer to a buffer that contains the content identifier.</param>
	/// <param name="ullContentOffset">
	/// An offset from the beginning of the published content for which the content information handle is requested.
	/// </param>
	/// <param name="cbContentLength">
	/// The length, in bytes, of the content (starting from the ullContentOffset) for which the content information is requested.
	/// </param>
	/// <param name="pRetrievalOptions">A PEER_RETRIEVAL_OPTIONS structure specifying additional options for retrieving content information.</param>
	/// <param name="hCompletionPort">
	/// A handle to the completion port used for retrieving the completion notification of the asynchronous function. To create a
	/// completion port, use the CreateIoCompletionPort function. This parameter can be <c>NULL</c>.
	/// </param>
	/// <param name="ulCompletionKey">
	/// Value to be returned through the lpCompletionKey parameter of the GetQueuedCompletionStatus function. This parameter is ignored
	/// when hCompletionPort is <c>NULL</c>.
	/// </param>
	/// <param name="phContentInfo">A handle used to retrieve the content information.</param>
	/// <returns>If the function succeeds, the return value is <c>ERROR_SUCCESS</c>.</returns>
	/// <remarks>
	/// <para>
	/// If function succeeds, the handle received by phContentInfo can be passed to the PeerDistServerRetrieveContentInformation
	/// function to retrieve content information. The handle must be closed via the PeerDistServerCloseContentInformation function.
	/// </para>
	/// <para>If ullContentOffset and cbContentLength are both zero, then the content information for the whole content will be retrieved.</para>
	/// <para>
	/// The pRetrievalOptions parameter can be used to specify the range of content information versions that the requesting client is
	/// configured to process. This enables the client to retrieve an applicable version of the content information structure.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/peerdist/nf-peerdist-peerdistserveropencontentinformationex DWORD
	// PeerDistServerOpenContentInformationEx( PEERDIST_INSTANCE_HANDLE hPeerDist, DWORD cbContentIdentifier, PBYTE pContentIdentifier,
	// ULONGLONG ullContentOffset, ULONGLONG cbContentLength, PEERDIST_RETRIEVAL_OPTIONS *pRetrievalOptions, HANDLE hCompletionPort,
	// ULONG_PTR ulCompletionKey, PPEERDIST_CONTENTINFO_HANDLE phContentInfo );
	[DllImport(Lib_PeerDist, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("peerdist.h", MSDNShortId = "NF:peerdist.PeerDistServerOpenContentInformationEx")]
	public static extern Win32Error PeerDistServerOpenContentInformationEx(PEERDIST_INSTANCE_HANDLE hPeerDist, uint cbContentIdentifier,
		[In] IntPtr pContentIdentifier, ulong ullContentOffset, ulong cbContentLength, in PEERDIST_RETRIEVAL_OPTIONS pRetrievalOptions,
		[In, Optional] HANDLE hCompletionPort, [In, Optional] UIntPtr ulCompletionKey, out PEERDIST_CONTENTINFO_HANDLE phContentInfo);

	/// <summary>The <c>PeerDistServerPublishAddToStream</c> function adds data to the publishing stream.</summary>
	/// <param name="hPeerDist">A PEERDIST_INSTANCE_HANDLE returned by PeerDistStartup.</param>
	/// <param name="hStream">A PEERDIST_STREAM_HANDLE created by PeerDistServerPublishStream.</param>
	/// <param name="cbNumberOfBytes">Number of bytes to be published.</param>
	/// <param name="pBuffer">
	/// Pointer to the buffer that contains the data to be published. This buffer must remain valid for the duration of the add
	/// operation. The caller must not use this buffer until the add operation is completed.
	/// </param>
	/// <param name="lpOverlapped">
	/// Pointer to an OVERLAPPED structure. The <c>Offset</c> and <c>OffsetHigh</c> members are reserved and must be zero.
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is <c>ERROR_IO_PENDING</c>. Otherwise, the function may return one of the following values:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>One or more parameters are invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The hPeerDist or hStream handle is invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_OPERATION_ABORTED</term>
	/// <term>The operation was canceled.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_ACCESS_DISABLED_BY_POLICY</term>
	/// <term>The feature is disabled by Group Policy.</term>
	/// </item>
	/// <item>
	/// <term>PEERDIST_ERROR_SERVICE_UNAVAILABLE</term>
	/// <term>The service is unavailable.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// When calling this function multiple times on a single stream handle, the caller must wait for each operation to complete before
	/// the next call is made.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/peerdist/nf-peerdist-peerdistserverpublishaddtostream DWORD
	// PeerDistServerPublishAddToStream( PEERDIST_INSTANCE_HANDLE hPeerDist, PEERDIST_STREAM_HANDLE hStream, DWORD cbNumberOfBytes,
	// PBYTE pBuffer, LPOVERLAPPED lpOverlapped );
	[DllImport(Lib_PeerDist, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("peerdist.h", MSDNShortId = "NF:peerdist.PeerDistServerPublishAddToStream")]
	public static unsafe extern Win32Error PeerDistServerPublishAddToStream(PEERDIST_INSTANCE_HANDLE hPeerDist, PEERDIST_STREAM_HANDLE hStream,
		uint cbNumberOfBytes, [In] IntPtr pBuffer, [In] NativeOverlapped* lpOverlapped);

	/// <summary>The <c>PeerDistServerPublishCompleteStream</c> function completes the process of adding data to the stream.</summary>
	/// <param name="hPeerDist">A PEERDIST_INSTANCE_HANDLE returned by PeerDistStartup.</param>
	/// <param name="hStream">A PEERDIST_STREAM_HANDLE returned by PeerDistServerPublishStream.</param>
	/// <param name="lpOverlapped">
	/// Pointer to an OVERLAPPED structure. The <c>Offset</c> and <c>OffsetHigh</c> are reserved and must be zero.
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is <c>ERROR_IO_PENDING</c>. Otherwise, the function may return one of the following values:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>One or more parameters are invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The hPeerDist or hStream handle is invalid</term>
	/// </item>
	/// <item>
	/// <term>ERROR_OPERATION_ABORTED</term>
	/// <term>The operation was canceled.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_ACCESS_DISABLED_BY_POLICY</term>
	/// <term>The feature is disabled by Group Policy.</term>
	/// </item>
	/// <item>
	/// <term>PEERDIST_ERROR_SERVICE_UNAVAILABLE</term>
	/// <term>The service is unavailable.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Once this API completes successfully, PeerDistServerOpenContentInformation and PeerDistServerRetrieveContentInformation can be
	/// used to retrieve content information.
	/// </para>
	/// <para><c>PeerDistServerPublishCompleteStream</c> does not close hStream. In order to close hStream, call PeerDistServerCloseStreamHandle.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/peerdist/nf-peerdist-peerdistserverpublishcompletestream DWORD
	// PeerDistServerPublishCompleteStream( PEERDIST_INSTANCE_HANDLE hPeerDist, PEERDIST_STREAM_HANDLE hStream, LPOVERLAPPED
	// lpOverlapped );
	[DllImport(Lib_PeerDist, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("peerdist.h", MSDNShortId = "NF:peerdist.PeerDistServerPublishCompleteStream")]
	public static unsafe extern Win32Error PeerDistServerPublishCompleteStream(PEERDIST_INSTANCE_HANDLE hPeerDist, PEERDIST_STREAM_HANDLE hStream,
		[In] NativeOverlapped* lpOverlapped);

	/// <summary>
	/// The <c>PeerDistServerPublishStream</c> function initializes a new stream to be published to the Peer Distribution service.
	/// </summary>
	/// <param name="hPeerDist">A PEERDIST_INSTANCE_HANDLE returned by PeerDistStartup.</param>
	/// <param name="cbContentIdentifier">The length, in bytes, of the buffer that contains content identifier data.</param>
	/// <param name="pContentIdentifier">A pointer to an array that contains a content identifier data.</param>
	/// <param name="cbContentLength">
	/// The length, in bytes, of the content to be published. This value can be 0 if the content length is not yet known. If a non-zero
	/// argument is provided then it must match to the total data length added by PeerDistServerPublishAddToStream function calls.
	/// </param>
	/// <param name="pPublishOptions">Pointer to a PEERDIST_PUBLICATION_OPTIONS structure that specifies content publishing rules.</param>
	/// <param name="hCompletionPort">
	/// A handle to the completion port that can be used for retrieving the completion notification of the asynchronous function. To
	/// create a completion port, use the CreateIoCompletionPort function. This parameter can be <c>NULL</c>.
	/// </param>
	/// <param name="ulCompletionKey">
	/// Value returned through the lpCompletionKey parameter of the GetQueuedCompletionStatus function. This parameter is ignored when
	/// hCompletionPort is <c>NULL</c>.
	/// </param>
	/// <param name="phStream">
	/// A pointer that receives a handle to the stream that is used to publish data into the Peer Distribution service.
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is <c>ERROR_SUCCESS</c>. Otherwise, the function may return one of the following values:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>One or more parameters are invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The specified hPeerDist is invalid.</term>
	/// </item>
	/// <item>
	/// <term>PEERDIST_ERROR_ALREADY_EXISTS</term>
	/// <term>The content identifier used for publication is already published.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_ACCESS_DISABLED_BY_POLICY</term>
	/// <term>The feature is disabled by Group Policy.</term>
	/// </item>
	/// <item>
	/// <term>PEERDIST_ERROR_SERVICE_UNAVAILABLE</term>
	/// <term>The service is unavailable.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// A content identifier is a user defined label for the content being published. This content identifier is used for
	/// PeerDistServerOpenContentInformation, PeerDistServerUnpublish, and PeerDistServerCancelAsyncOperation calls.
	/// </para>
	/// <para>
	/// The handle received by phStream can be used in PeerDistServerPublishAddToStream and PeerDistServerPublishCompleteStream to
	/// publish data into the Peer Distribution service. This handle should be closed by PeerDistServerCloseStreamHandle.
	/// </para>
	/// <para>
	/// A publication is accessible only to the User Account that originally published the content. If a different user calls
	/// <c>PeerDistServerPublishStream</c> with the same content identifier, a separate publication will be created under the context of
	/// that user.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/peerdist/nf-peerdist-peerdistserverpublishstream DWORD
	// PeerDistServerPublishStream( PEERDIST_INSTANCE_HANDLE hPeerDist, DWORD cbContentIdentifier, PBYTE pContentIdentifier, ULONGLONG
	// cbContentLength, PCPEERDIST_PUBLICATION_OPTIONS pPublishOptions, HANDLE hCompletionPort, ULONG_PTR ulCompletionKey,
	// PPEERDIST_STREAM_HANDLE phStream );
	[DllImport(Lib_PeerDist, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("peerdist.h", MSDNShortId = "NF:peerdist.PeerDistServerPublishStream")]
	public static extern Win32Error PeerDistServerPublishStream(PEERDIST_INSTANCE_HANDLE hPeerDist, uint cbContentIdentifier,
		[In] IntPtr pContentIdentifier, ulong cbContentLength, in PEERDIST_PUBLICATION_OPTIONS pPublishOptions, [In, Optional] HANDLE hCompletionPort,
		[In, Optional] UIntPtr ulCompletionKey, out PEERDIST_STREAM_HANDLE phStream);

	/// <summary>
	/// The <c>PeerDistServerPublishStream</c> function initializes a new stream to be published to the Peer Distribution service.
	/// </summary>
	/// <param name="hPeerDist">A PEERDIST_INSTANCE_HANDLE returned by PeerDistStartup.</param>
	/// <param name="cbContentIdentifier">The length, in bytes, of the buffer that contains content identifier data.</param>
	/// <param name="pContentIdentifier">A pointer to an array that contains a content identifier data.</param>
	/// <param name="cbContentLength">
	/// The length, in bytes, of the content to be published. This value can be 0 if the content length is not yet known. If a non-zero
	/// argument is provided then it must match to the total data length added by PeerDistServerPublishAddToStream function calls.
	/// </param>
	/// <param name="pPublishOptions">Pointer to a PEERDIST_PUBLICATION_OPTIONS structure that specifies content publishing rules.</param>
	/// <param name="hCompletionPort">
	/// A handle to the completion port that can be used for retrieving the completion notification of the asynchronous function. To
	/// create a completion port, use the CreateIoCompletionPort function. This parameter can be <c>NULL</c>.
	/// </param>
	/// <param name="ulCompletionKey">
	/// Value returned through the lpCompletionKey parameter of the GetQueuedCompletionStatus function. This parameter is ignored when
	/// hCompletionPort is <c>NULL</c>.
	/// </param>
	/// <param name="phStream">
	/// A pointer that receives a handle to the stream that is used to publish data into the Peer Distribution service.
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is <c>ERROR_SUCCESS</c>. Otherwise, the function may return one of the following values:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>One or more parameters are invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The specified hPeerDist is invalid.</term>
	/// </item>
	/// <item>
	/// <term>PEERDIST_ERROR_ALREADY_EXISTS</term>
	/// <term>The content identifier used for publication is already published.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_ACCESS_DISABLED_BY_POLICY</term>
	/// <term>The feature is disabled by Group Policy.</term>
	/// </item>
	/// <item>
	/// <term>PEERDIST_ERROR_SERVICE_UNAVAILABLE</term>
	/// <term>The service is unavailable.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// A content identifier is a user defined label for the content being published. This content identifier is used for
	/// PeerDistServerOpenContentInformation, PeerDistServerUnpublish, and PeerDistServerCancelAsyncOperation calls.
	/// </para>
	/// <para>
	/// The handle received by phStream can be used in PeerDistServerPublishAddToStream and PeerDistServerPublishCompleteStream to
	/// publish data into the Peer Distribution service. This handle should be closed by PeerDistServerCloseStreamHandle.
	/// </para>
	/// <para>
	/// A publication is accessible only to the User Account that originally published the content. If a different user calls
	/// <c>PeerDistServerPublishStream</c> with the same content identifier, a separate publication will be created under the context of
	/// that user.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/peerdist/nf-peerdist-peerdistserverpublishstream DWORD
	// PeerDistServerPublishStream( PEERDIST_INSTANCE_HANDLE hPeerDist, DWORD cbContentIdentifier, PBYTE pContentIdentifier, ULONGLONG
	// cbContentLength, PCPEERDIST_PUBLICATION_OPTIONS pPublishOptions, HANDLE hCompletionPort, ULONG_PTR ulCompletionKey,
	// PPEERDIST_STREAM_HANDLE phStream );
	[DllImport(Lib_PeerDist, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("peerdist.h", MSDNShortId = "NF:peerdist.PeerDistServerPublishStream")]
	public static extern Win32Error PeerDistServerPublishStream(PEERDIST_INSTANCE_HANDLE hPeerDist, uint cbContentIdentifier,
		[In] IntPtr pContentIdentifier, ulong cbContentLength, [In, Optional] IntPtr pPublishOptions, [In, Optional] HANDLE hCompletionPort,
		[In, Optional] UIntPtr ulCompletionKey, out PEERDIST_STREAM_HANDLE phStream);

	/// <summary>
	/// The <c>PeerDistServerRetrieveContentInformation</c> function retrieves the encoded content information associated with a handle
	/// returned by PeerDistServerOpenContentInformation.
	/// </summary>
	/// <param name="hPeerDist">A PEERDIST_INSTANCE_HANDLE returned by PeerDistStartup.</param>
	/// <param name="hContentInfo">The handle returned by PeerDistServerOpenContentInformation.</param>
	/// <param name="cbMaxNumberOfBytes">The maximum number of bytes to read.</param>
	/// <param name="pBuffer">Pointer to the buffer that receives the content information data.</param>
	/// <param name="lpOverlapped">
	/// Pointer to an OVERLAPPED structure. This function does not allow the caller to specify the start Offset in the content. The
	/// offset is implicitly maintained per hContentInfo. The Offset and OffsetHigh are reserved and must be zero.
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is <c>ERROR_IO_PENDING</c>. Otherwise, the function may return one of the following values:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>One or more parameters are invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The hPeerDist or hContentInfo handle is invalid.</term>
	/// </item>
	/// <item>
	/// <term>PEERDIST_ERROR_NO_MORE</term>
	/// <term>EOF on the content information has been reached.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_ACCESS_DISABLED_BY_POLICY</term>
	/// <term>The feature is disabled by Group Policy.</term>
	/// </item>
	/// <item>
	/// <term>PEERDIST_ERROR_SERVICE_UNAVAILABLE</term>
	/// <term>The service is unavailable.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// On the success of the <c>PeerDistServerRetrieveContentInformation</c> operation, the <c>Offset</c> and <c>OffsetHigh</c> fields
	/// of the OVERLAPPED structure will be populated with the <c>ULONGLONG</c> offset in the content information that was retrieved.
	/// The <c>OffsetHigh</c> member will be set to the higher 32 bits of the offset and the <c>Offset</c> member will be set to the
	/// lower 32 bits of the offset.
	/// </para>
	/// <para>
	/// GetOverlappedResult will populate lpNumberOfBytesTransferred with the number of bytes transferred. In the event the caller is
	/// using a completion port to process Peer Distribution API completions, the lpNumberOfBytes argument of GetQueuedCompletionStatus
	/// will be populated with the number of bytes transferred.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/peerdist/nf-peerdist-peerdistserverretrievecontentinformation DWORD
	// PeerDistServerRetrieveContentInformation( PEERDIST_INSTANCE_HANDLE hPeerDist, PEERDIST_CONTENTINFO_HANDLE hContentInfo, DWORD
	// cbMaxNumberOfBytes, PBYTE pBuffer, LPOVERLAPPED lpOverlapped );
	[DllImport(Lib_PeerDist, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("peerdist.h", MSDNShortId = "NF:peerdist.PeerDistServerRetrieveContentInformation")]
	public static unsafe extern Win32Error PeerDistServerRetrieveContentInformation(PEERDIST_INSTANCE_HANDLE hPeerDist, PEERDIST_CONTENTINFO_HANDLE hContentInfo,
		uint cbMaxNumberOfBytes, [Out] IntPtr pBuffer, [In] NativeOverlapped* lpOverlapped);

	/// <summary>The <c>PeerDistServerUnpublish</c> function removes a publication created via PeerDistServerPublishStream.</summary>
	/// <param name="hPeerDist">A <c>PEERDIST_INSTANCE_HANDLE</c> returned by PeerDistStartup.</param>
	/// <param name="cbContentIdentifier">The length, in bytes, of the content identifier.</param>
	/// <param name="pContentIdentifier">Pointer to a buffer that contains the content identifier.</param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is <c>ERROR_SUCCESS</c>. Otherwise, the function may return one of the following values:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>One or more parameters are invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The hPeerDist handle is invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_ACCESS_DISABLED_BY_POLICY</term>
	/// <term>The feature is disabled by Group Policy.</term>
	/// </item>
	/// <item>
	/// <term>PEERDIST_ERROR_SERVICE_UNAVAILABLE</term>
	/// <term>The service is unavailable.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>PeerDistServerUnpublish</c> function cancels all pending operations on unpublished content within the Peer Distribution
	/// session that is associated with the specified hPeerDist. The client is still required to close previously opened handles on that
	/// content with a call to PeerDistClientCloseContent.
	/// </para>
	/// <para>A publication is accessible only to the User Account that originally published the content.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/peerdist/nf-peerdist-peerdistserverunpublish DWORD PeerDistServerUnpublish(
	// PEERDIST_INSTANCE_HANDLE hPeerDist, DWORD cbContentIdentifier, PBYTE pContentIdentifier );
	[DllImport(Lib_PeerDist, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("peerdist.h", MSDNShortId = "NF:peerdist.PeerDistServerUnpublish")]
	public static extern Win32Error PeerDistServerUnpublish(PEERDIST_INSTANCE_HANDLE hPeerDist, uint cbContentIdentifier, [In] IntPtr pContentIdentifier);

	/// <summary>
	/// The <c>PeerDistShutdown</c> function releases resources allocated by a call to PeerDistStartup. Each handle returned by a
	/// <c>PeerDistStartup</c> call must be closed by a matching call to <c>PeerDistShutdown</c>
	/// </summary>
	/// <param name="hPeerDist">A <c>PEERDIST_INSTANCE_HANDLE</c> returned by PeerDistStartup.</param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is <c>ERROR_SUCCESS</c>. Otherwise, the function may return one of the following values:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The hPeerDist handle is invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// This function will remove all publications that were created with the specified hPeerDist handle. It is recommended that this
	/// function is called after all pending operations have completed, as <c>PeerDistShutdown</c> cancel all pending Peer Distribution
	/// client and server operations associated with the supplied <c>PEERDIST_INSTANCE_HANDLE</c>.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/peerdist/nf-peerdist-peerdistshutdown DWORD PeerDistShutdown(
	// PEERDIST_INSTANCE_HANDLE hPeerDist );
	[DllImport(Lib_PeerDist, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("peerdist.h", MSDNShortId = "NF:peerdist.PeerDistShutdown")]
	public static extern Win32Error PeerDistShutdown(PEERDIST_INSTANCE_HANDLE hPeerDist);

	/// <summary>
	/// The <c>PeerDistStartup</c> function creates a new Peer Distribution instance handle which must be passed to all other Peer
	/// Distribution APIs.
	/// </summary>
	/// <param name="dwVersionRequested">
	/// Contains the minimum version of the Peer Distribution requested by the application. The high order byte specifies the minor
	/// version number; the low order byte specifies the major version number.
	/// </param>
	/// <param name="phPeerDist">
	/// A pointer to a <c>PEERDIST_INSTANCE_HANDLE</c> variable which upon success receives a newly created handle.
	/// </param>
	/// <param name="pdwSupportedVersion">
	/// A pointer to a variable which, if not <c>NULL</c>, contains the maximum version number that is supported by the Peer
	/// Distribution system. The high order byte specifies the minor version number; the low order byte specifies the major version number.
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is <c>ERROR_SUCCESS</c>. Otherwise, the function may return one of the following values:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>One or more parameters are invalid.</term>
	/// </item>
	/// <item>
	/// <term>PEERDIST_ERROR_VERSION_UNSUPPORTED</term>
	/// <term>The requested version is not supported by client side DLL.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <c>PeerDistStartup</c> must be called before any other Peer Distribution functions. When no longer needed, the handle returned
	/// by <c>PeerDistStartup</c> should be closed via a call to PeerDistShutdown.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/peerdist/nf-peerdist-peerdiststartup DWORD PeerDistStartup( DWORD
	// dwVersionRequested, PPEERDIST_INSTANCE_HANDLE phPeerDist, PDWORD pdwSupportedVersion );
	[DllImport(Lib_PeerDist, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("peerdist.h", MSDNShortId = "NF:peerdist.PeerDistStartup")]
	public static extern Win32Error PeerDistStartup(uint dwVersionRequested, out PEERDIST_INSTANCE_HANDLE phPeerDist, out uint pdwSupportedVersion);

	/// <summary>
	/// The <c>PeerDistUnregisterForStatusChangeNotification</c> function unregisters the status change notification for the session
	/// associated with the specified handle.
	/// </summary>
	/// <param name="hPeerDist">A <c>PEERDIST_INSTANCE_HANDLE</c> returned by PeerDistStartup.</param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is <c>ERROR_SUCCESS</c>. Otherwise, the function may return one of the following values:
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>One or more parameters are invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The hPeerDist handle is invalid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function cancels any registered notification previously set by a PeerDistRegisterForStatusChangeNotification function call.
	/// </para>
	/// <para>
	/// To confirm successfully canceled operations, a call should be made to GetOverlappedResult using the <c>OVERLAPPED</c> structure
	/// returned by GetQueuedCompletionStatus with an expected return of <c>FALSE</c>.
	/// </para>
	/// <para>
	/// Additionally, calling GetLastError immediately after a successful PeerDistRegisterForStatusChangeNotification will return the
	/// <c>ERROR_OPERATION_ABORTED</c> error code.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/peerdist/nf-peerdist-peerdistunregisterforstatuschangenotification DWORD
	// PeerDistUnregisterForStatusChangeNotification( PEERDIST_INSTANCE_HANDLE hPeerDist );
	[DllImport(Lib_PeerDist, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("peerdist.h", MSDNShortId = "NF:peerdist.PeerDistUnregisterForStatusChangeNotification")]
	public static extern Win32Error PeerDistUnregisterForStatusChangeNotification(PEERDIST_INSTANCE_HANDLE hPeerDist);

	/// <summary>
	/// The <c>PEERDIST_CLIENT_BASIC_INFO</c> structure indicates whether or not there are many clients simultaneously downloading the
	/// same content.
	/// </summary>
	/// <remarks>
	/// <para>
	/// Thie <c>PEERDIST_CLIENT_BASIC_INFO</c> structure is retrieved from the PeerDistClientGetInformationHandle function with
	/// PeerDistClientBasicInfo value specified for the PeerDistClientInfoClass parameter.
	/// </para>
	/// <para>If true, content that cannot be retrieved from the Peer Distribution APIs may soon be available for retrieval.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/peerdist/ns-peerdist-peerdist_client_basic_info typedef struct
	// _PEERDIST_CLIENT_BASIC_INFO { BOOL fFlashCrowd; } PEERDIST_CLIENT_BASIC_INFO, *PPEERDIST_CLIENT_BASIC_INFO;
	[PInvokeData("peerdist.h", MSDNShortId = "NS:peerdist._PEERDIST_CLIENT_BASIC_INFO")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PEERDIST_CLIENT_BASIC_INFO
	{
		/// <summary>
		/// Indicates that a "flash crowd" situation has been detected, where many clients in the branch office are simultaneously
		/// downloading the same content.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool fFlashCrowd;
	}

	/// <summary>
	/// The <c>PEERDIST_CONTENT_TAG</c> structure contains a client supplied content tag as an input to the PeerDistClientOpenContent API.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/peerdist/ns-peerdist-peerdist_content_tag typedef struct
	// peerdist_content_tag_tag { BYTE Data[16]; } PEERDIST_CONTENT_TAG, *PPEERDIST_CONTENT_TAG;
	[PInvokeData("peerdist.h", MSDNShortId = "NS:peerdist.peerdist_content_tag_tag")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PEERDIST_CONTENT_TAG
	{
		/// <summary>A 16 byte tag associated with the open content.</summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
		public byte[] Data;
	}

	/// <summary>
	/// The <c>PEERDIST_PUBLICATION_OPTIONS</c> structure contains publication options, including the API version information and
	/// possible option flags.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/peerdist/ns-peerdist-peerdist_publication_options typedef struct
	// peerdist_publication_options_tag { DWORD dwVersion; DWORD dwFlags; } PEERDIST_PUBLICATION_OPTIONS, *PPEERDIST_PUBLICATION_OPTIONS;
	[PInvokeData("peerdist.h", MSDNShortId = "NS:peerdist.peerdist_publication_options_tag")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PEERDIST_PUBLICATION_OPTIONS
	{
		/// <summary>
		/// <para>The following possible values reflect the version number of the client:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>1</term>
		/// <term>Version 1.0</term>
		/// </item>
		/// <item>
		/// <term>2</term>
		/// <term>Version 2.0</term>
		/// </item>
		/// </list>
		/// </summary>
		public uint dwVersion;

		/// <summary>Reserved.</summary>
		public uint dwFlags;
	}

	/// <summary>The <c>PEER_RETRIEVAL_OPTIONS</c> structure contains version of the content information to retrieve.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/peerdist/ns-peerdist-peerdist_retrieval_options typedef struct
	// peerdist_retrieval_options_tag { DWORD cbSize; DWORD dwContentInfoMinVersion; DWORD dwContentInfoMaxVersion; DWORD dwReserved; }
	// PEERDIST_RETRIEVAL_OPTIONS, *PPEERDIST_RETRIEVAL_OPTIONS;
	[PInvokeData("peerdist.h", MSDNShortId = "NS:peerdist.peerdist_retrieval_options_tag")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PEERDIST_RETRIEVAL_OPTIONS
	{
		/// <summary>Specifies the size of the input structure.</summary>
		public uint cbSize;

		/// <summary>
		/// <para>Specifies the minimum version of the content information to retrieve. Must be set to one of the following values:</para>
		/// <para>PEERDIST_RETRIEVAL_OPTIONS_CONTENTINFO_VERSION</para>
		/// <para>PEERDIST_RETRIEVAL_OPTIONS_CONTENTINFO_VERSION_1</para>
		/// <para>PEERDIST_RETRIEVAL_OPTIONS_CONTENTINFO_VERSION_2</para>
		/// </summary>
		public uint dwContentInfoMinVersion;

		/// <summary>
		/// <para>Specifies the maximum version of the content information to retrieve. Must be set to one of the following values:</para>
		/// <para>PEERDIST_RETRIEVAL_OPTIONS_CONTENTINFO_VERSION</para>
		/// <para>PEERDIST_RETRIEVAL_OPTIONS_CONTENTINFO_VERSION_1</para>
		/// <para>PEERDIST_RETRIEVAL_OPTIONS_CONTENTINFO_VERSION_2</para>
		/// </summary>
		public uint dwContentInfoMaxVersion;

		/// <summary>Reserved. The <c>dwReserved</c> member should be set to 0.</summary>
		public uint dwReserved;
	}

	/// <summary>
	/// The <c>PEERDIST_STATUS_INFO</c> structure contains information about the current status and capabilities of the BranchCache
	/// service on the local computer.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/peerdist/ns-peerdist-peerdist_status_info typedef struct
	// peerdist_status_info_tag { DWORD cbSize; PEERDIST_STATUS status; DWORD dwMinVer; DWORD dwMaxVer; } PEERDIST_STATUS_INFO, *PPEERDIST_STATUS_INFO;
	[PInvokeData("peerdist.h", MSDNShortId = "NS:peerdist.peerdist_status_info_tag")]
	[StructLayout(LayoutKind.Sequential)]
	public struct PEERDIST_STATUS_INFO
	{
		/// <summary>Size, in bytes, of the <c>PEERDIST_STATUS_INFO</c> structure.</summary>
		public uint cbSize;

		/// <summary>
		/// Specifies the current status of the BranchCache service. This member should be one of following values defined in the
		/// PEERDIST_STATUS enumeration.
		/// </summary>
		public PEERDIST_STATUS status;

		/// <summary>
		/// <para>
		/// Specifies the minimum version of the content information format supported by the BranchCache service on the local machine.
		/// This member must be set to one of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PEERDIST_RETRIEVAL_OPTIONS_CONTENTINFO_VERSION_1 1</term>
		/// <term>Windows 7 compatible content information format.</term>
		/// </item>
		/// <item>
		/// <term>PEERDIST_RETRIEVAL_OPTIONS_CONTENTINFO_VERSION_2 2</term>
		/// <term>Windows 8 content information format.</term>
		/// </item>
		/// </list>
		/// </summary>
		public uint dwMinVer;

		/// <summary>
		/// <para>
		/// Specifies the maximum version of the content information format supported by the BranchCache service on the local machine.
		/// This member must be set to one of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>PEERDIST_RETRIEVAL_OPTIONS_CONTENTINFO_VERSION_1 1</term>
		/// <term>Windows 7 compatible content information format.</term>
		/// </item>
		/// <item>
		/// <term>PEERDIST_RETRIEVAL_OPTIONS_CONTENTINFO_VERSION_2 2</term>
		/// <term>Windows 8 content information format.</term>
		/// </item>
		/// </list>
		/// </summary>
		public uint dwMaxVer;
	}
}