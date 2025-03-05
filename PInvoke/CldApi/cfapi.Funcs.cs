using System.Threading;
using static Vanara.PInvoke.Kernel32;
using USN = System.Int64;

namespace Vanara.PInvoke;

/// <summary>Functions, structures and constants from CldApi.dll.</summary>
public static partial class CldApi
{
	/// <summary>Callback function for <see cref="CF_CALLBACK_REGISTRATION"/>.</summary>
	/// <param name="CallbackInfo">The callback information.</param>
	/// <param name="CallbackParameters">The callback parameters.</param>
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	public delegate void CF_CALLBACK(in CF_CALLBACK_INFO CallbackInfo, in CF_CALLBACK_PARAMETERS CallbackParameters);

	private delegate HRESULT GetInfoFunc<TParam, TEnum>(TParam p1, TEnum InfoClass, IntPtr InfoBuffer, uint InfoBufferLength, out uint ReturnedLength) where TEnum : Enum;

	/// <summary>
	/// Closes the file or directory handle returned by CfOpenFileWithOplock. This should not be used with standard Win32 file handles,
	/// only on handles used within CfApi.h.
	/// </summary>
	/// <param name="FileHandle">The file or directory handle to be closed.</param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/nf-cfapi-cfclosehandle void CfCloseHandle( HANDLE FileHandle );
	[DllImport(Lib.CldApi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfapi.h", MSDNShortId = "ECBEF685-0769-4AEA-8A0F-D5FBB70CBB09")]
	public static extern void CfCloseHandle(HCFFILE FileHandle);

	/// <summary>Initiates bi-directional communication between a sync provider and the sync filter API.</summary>
	/// <param name="SyncRootPath">The path to the sync root.</param>
	/// <param name="CallbackTable">The callback table to be registered.</param>
	/// <param name="CallbackContext">A callback context used by the platform anytime a specified callback function is invoked.</param>
	/// <param name="ConnectFlags">Provides additional information when a callback is invoked.</param>
	/// <param name="ConnectionKey">A connection key representing the communication channel with the sync filter.</param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	/// <remarks>
	/// <para>
	/// This initiates a bi-directional communication channel between the sync provider and the sync filter. A sync provider typically
	/// calls this API soon after startup, once it has been initialized and is ready to service requests.
	/// </para>
	/// <para>
	/// The sync root must be registered prior to being connected. For a given SyncRootPath, there can be at most one connection
	/// established at any given time.
	/// </para>
	/// <para>
	/// The sync provider should have WRITE_DATA or WRITE_DAC access to the sync root to be connected or the API will be failed with HRESULT(ERROR_CLOUD_FILE_ACCESS_DENIED).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/nf-cfapi-cfconnectsyncroot HRESULT CfConnectSyncRoot( LPCWSTR
	// SyncRootPath, const CF_CALLBACK_REGISTRATION *CallbackTable, LPCVOID CallbackContext, CF_CONNECT_FLAGS ConnectFlags,
	// CF_CONNECTION_KEY *ConnectionKey );
	[DllImport(Lib.CldApi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfapi.h", MSDNShortId = "287DA978-9797-48DF-9C90-BA53BB82475C")]
	public static extern HRESULT CfConnectSyncRoot([MarshalAs(UnmanagedType.LPWStr)] string SyncRootPath, [In, MarshalAs(UnmanagedType.LPArray)] CF_CALLBACK_REGISTRATION[] CallbackTable,
		[In, Optional] IntPtr CallbackContext, CF_CONNECT_FLAGS ConnectFlags, out CF_CONNECTION_KEY ConnectionKey);

	/// <summary>Converts a normal file/directory to a placeholder file/directory.</summary>
	/// <param name="FileHandle">Handle to the file or directory to be converted.</param>
	/// <param name="FileIdentity">
	/// A user mode buffer that contains the opaque file or directory information supplied by the caller. Optional if the caller is not
	/// dehydrating the file at the same time, or if the caller is converting a directory. Cannot exceed 4KB in size.
	/// </param>
	/// <param name="FileIdentityLength">Length, in bytes, of the FileIdentity.</param>
	/// <param name="ConvertFlags">Placeholder conversion flags.</param>
	/// <param name="ConvertUsn">The final USN value after convert actions are performed.</param>
	/// <param name="Overlapped">
	/// <para>
	/// When specified and combined with an asynchronous FileHandle, Overlapped allows the platform to perform the
	/// <c>CfConvertToPlaceholder</c> call asynchronously. See the Remarks for more details.
	/// </para>
	/// <para>If not specified, the platform will perform the API call synchronously, regardless of how the handle was created.</para>
	/// </param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	/// <remarks>
	/// <para>
	/// In the file case, the caller must acquire an exclusive handle to the file if it also intends to dehydrate the file at the same
	/// time or data corruption can occur. To minimize the impact on user applications it is highly recommended that the caller obtain
	/// the exclusiveness using proper oplocks (via CfOpenFileWithOplock) as opposed to using a share-nothing handle.
	/// </para>
	/// <para>To convert a placeholder:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// The file or directory to be converted must be contained in a registered sync root tree; it can be the sync root directory
	/// itself, or any descendant directory; otherwise, the call with be failed with HRESULT(ERROR_CLOUD_FILE_NOT_UNDER_SYNC_ROOT).
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If dehydration is requested, the sync root must be registered with a valid hydration policy that is not
	/// CF_HYDRATION_POLICY_ALWAYS_FULL; otherwise the call will be failed with HRESULT(ERROR_CLOUD_FILE_NOT_SUPPORTED).
	/// </term>
	/// </item>
	/// <item>
	/// <term>If dehydration is requested, the placeholder must not be pinned locally or the call with be failed with HRESULT(ERROR_CLOUD_FILE_PINNED).</term>
	/// </item>
	/// <item>
	/// <term>If dehydration is requested, the placeholder must be in sync or the call with be failed with HRESULT(ERROR_CLOUD_FILE_NOT_IN_SYNC).</term>
	/// </item>
	/// <item>
	/// <term>
	/// The caller must have WRITE_DATA or WRITE_DAC access to the file or directory to be converted. Otherwise the operation will be
	/// failed with HRESULT(ERROR_CLOUD_FILE_ACCESS_DENIED).
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// If the API returns HRESULT_FROM_WIN32(ERROR_IO_PENDING) when using Overlapped asynchronously, the caller can then wait using GetOverlappedResult.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/nf-cfapi-cfconverttoplaceholder HRESULT CfConvertToPlaceholder( HANDLE
	// FileHandle, LPCVOID FileIdentity, DWORD FileIdentityLength, CF_CONVERT_FLAGS ConvertFlags, USN *ConvertUsn, LPOVERLAPPED
	// Overlapped );
	[DllImport(Lib.CldApi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfapi.h", MSDNShortId = "FDDE9CB0-E1A2-46D6-94E0-228495675271")]
	public static extern HRESULT CfConvertToPlaceholder(HFILE FileHandle, [In, Optional] IntPtr FileIdentity, uint FileIdentityLength, CF_CONVERT_FLAGS ConvertFlags, out USN ConvertUsn, [In, Out, Optional] IntPtr Overlapped);

	/// <summary>Converts a normal file/directory to a placeholder file/directory.</summary>
	/// <param name="FileHandle">Handle to the file or directory to be converted.</param>
	/// <param name="FileIdentity">
	/// A user mode buffer that contains the opaque file or directory information supplied by the caller. Optional if the caller is not
	/// dehydrating the file at the same time, or if the caller is converting a directory. Cannot exceed 4KB in size.
	/// </param>
	/// <param name="FileIdentityLength">Length, in bytes, of the FileIdentity.</param>
	/// <param name="ConvertFlags">Placeholder conversion flags.</param>
	/// <param name="ConvertUsn">The final USN value after convert actions are performed.</param>
	/// <param name="Overlapped">
	/// <para>
	/// When specified and combined with an asynchronous FileHandle, Overlapped allows the platform to perform the
	/// <c>CfConvertToPlaceholder</c> call asynchronously. See the Remarks for more details.
	/// </para>
	/// <para>If not specified, the platform will perform the API call synchronously, regardless of how the handle was created.</para>
	/// </param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	/// <remarks>
	/// <para>
	/// In the file case, the caller must acquire an exclusive handle to the file if it also intends to dehydrate the file at the same
	/// time or data corruption can occur. To minimize the impact on user applications it is highly recommended that the caller obtain
	/// the exclusiveness using proper oplocks (via CfOpenFileWithOplock) as opposed to using a share-nothing handle.
	/// </para>
	/// <para>To convert a placeholder:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// The file or directory to be converted must be contained in a registered sync root tree; it can be the sync root directory
	/// itself, or any descendant directory; otherwise, the call with be failed with HRESULT(ERROR_CLOUD_FILE_NOT_UNDER_SYNC_ROOT).
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If dehydration is requested, the sync root must be registered with a valid hydration policy that is not
	/// CF_HYDRATION_POLICY_ALWAYS_FULL; otherwise the call will be failed with HRESULT(ERROR_CLOUD_FILE_NOT_SUPPORTED).
	/// </term>
	/// </item>
	/// <item>
	/// <term>If dehydration is requested, the placeholder must not be pinned locally or the call with be failed with HRESULT(ERROR_CLOUD_FILE_PINNED).</term>
	/// </item>
	/// <item>
	/// <term>If dehydration is requested, the placeholder must be in sync or the call with be failed with HRESULT(ERROR_CLOUD_FILE_NOT_IN_SYNC).</term>
	/// </item>
	/// <item>
	/// <term>
	/// The caller must have WRITE_DATA or WRITE_DAC access to the file or directory to be converted. Otherwise the operation will be
	/// failed with HRESULT(ERROR_CLOUD_FILE_ACCESS_DENIED).
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// If the API returns HRESULT_FROM_WIN32(ERROR_IO_PENDING) when using Overlapped asynchronously, the caller can then wait using GetOverlappedResult.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/nf-cfapi-cfconverttoplaceholder HRESULT CfConvertToPlaceholder( HANDLE
	// FileHandle, LPCVOID FileIdentity, DWORD FileIdentityLength, CF_CONVERT_FLAGS ConvertFlags, USN *ConvertUsn, LPOVERLAPPED
	// Overlapped );
	[DllImport(Lib.CldApi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfapi.h", MSDNShortId = "FDDE9CB0-E1A2-46D6-94E0-228495675271")]
	public static unsafe extern HRESULT CfConvertToPlaceholder(HFILE FileHandle, [In, Optional] IntPtr FileIdentity, uint FileIdentityLength, CF_CONVERT_FLAGS ConvertFlags,
		[Out, Optional] USN* ConvertUsn, [In, Out, Optional] NativeOverlapped* Overlapped);

	/// <summary>Creates one or more new placeholder files or directories under a sync root tree.</summary>
	/// <param name="BaseDirectoryPath">Local directory path under which placeholders are created.</param>
	/// <param name="PlaceholderArray">
	/// On successful creation, the PlaceholderArray contains the final USN value and a STATUS_OK message. On return, this array
	/// contains an HRESULT value describing whether the placeholder was created or not.
	/// </param>
	/// <param name="PlaceholderCount">The count of placeholders in the PlaceholderArray.</param>
	/// <param name="CreateFlags">Flags for configuring the creation of a placeholder.</param>
	/// <param name="EntriesProcessed">The number of entries processed, including failed entries.</param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	/// <remarks>
	/// <para>
	/// Creating a placeholder with this function is preferred compared to creating a new file with CreateFile and then converting it to
	/// a placeholder with CfConvertToPlaceholder; both for efficiency and because it eliminates the time window where the file is not a
	/// placeholder. The function can also create multiple files or directories in a batch, which can also be more efficient.
	/// </para>
	/// <para>
	/// This function is useful when performing an initial sync of files or directories from the cloud down to the client, or when
	/// syncing down a newly created single file or directory from the cloud.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/nf-cfapi-cfcreateplaceholders HRESULT CfCreatePlaceholders( LPCWSTR
	// BaseDirectoryPath, CF_PLACEHOLDER_CREATE_INFO *PlaceholderArray, DWORD PlaceholderCount, CF_CREATE_FLAGS CreateFlags, PDWORD
	// EntriesProcessed );
	[DllImport(Lib.CldApi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfapi.h", MSDNShortId = "96A6F62E-7F14-40B5-AB57-260DC9B1DF89")]
	public static extern HRESULT CfCreatePlaceholders([MarshalAs(UnmanagedType.LPWStr)] string BaseDirectoryPath, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] CF_PLACEHOLDER_CREATE_INFO[] PlaceholderArray,
		uint PlaceholderCount, CF_CREATE_FLAGS CreateFlags, out uint EntriesProcessed);

	/// <summary>
	/// Dehydrates a placeholder file by ensuring that the specified byte range is not present on-disk in the placeholder. This is valid
	/// for files only.
	/// </summary>
	/// <param name="FileHandle">[in] A handle to the placeholder file.</param>
	/// <param name="StartingOffset">[in] The starting point offset of the placeholder file data.</param>
	/// <param name="Length">
	/// [in] The length, in bytes, of the placeholder file whose data must be invalidated locally on the disk after the API completes
	/// successfully. A length of -1 signifies end of file.
	/// </param>
	/// <param name="DehydrateFlags">[in] Placeholder dehydration flags.</param>
	/// <param name="Overlapped">
	/// <para>
	/// [in, out, optional] When specified and combined with an asynchronous FileHandle, Overlapped allows the platform to perform the
	/// <c>CfDehydratePlaceholder</c> call asynchronously. See the Remarks for more details.
	/// </para>
	/// <para>If not specified, the platform will perform the API call synchronously, regardless of how the handle was created.</para>
	/// </param>
	/// <returns>This function does not return a value.</returns>
	/// <remarks>
	/// <para>
	/// The caller must acquire an exclusive handle to the file or data corruption can occur. To minimize the impact on user
	/// applications it is highly recommended that the caller obtain the exclusiveness using proper oplocks (via
	/// <c>CfOpenFileWithOplock</c>) as opposed to using a share-nothing handle.
	/// </para>
	/// <para>
	/// If the API returns HRESULT_FROM_WIN32(ERROR_IO_PENDING) when using Overlapped asynchronously, the caller can then wait using <c>GetOverlappedResult</c>.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/previous-versions/mt827480(v=vs.85) void STDAPI CfDehydratePlaceholder( _In_ HANDLE FileHandle,
	// _In_ LARGE_INTEGER StartingOffset, _In_ LARGE_INTEGER Length, _In_ CF_HYDRATE_FLAGS DehydrateFlags, _Inout_opt_ LPOVERLAPPED
	// Overlapped );
	[DllImport(Lib.CldApi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("CfApi.h")]
	public static extern HRESULT CfDehydratePlaceholder(HFILE FileHandle, long StartingOffset, long Length, CF_DEHYDRATE_FLAGS DehydrateFlags, [In, Out, Optional] IntPtr Overlapped);

	/// <summary>
	/// Dehydrates a placeholder file by ensuring that the specified byte range is not present on-disk in the placeholder. This is valid
	/// for files only.
	/// </summary>
	/// <param name="FileHandle">[in] A handle to the placeholder file.</param>
	/// <param name="StartingOffset">[in] The starting point offset of the placeholder file data.</param>
	/// <param name="Length">
	/// [in] The length, in bytes, of the placeholder file whose data must be invalidated locally on the disk after the API completes
	/// successfully. A length of -1 signifies end of file.
	/// </param>
	/// <param name="DehydrateFlags">[in] Placeholder dehydration flags.</param>
	/// <param name="Overlapped">
	/// <para>
	/// [in, out, optional] When specified and combined with an asynchronous FileHandle, Overlapped allows the platform to perform the
	/// <c>CfDehydratePlaceholder</c> call asynchronously. See the Remarks for more details.
	/// </para>
	/// <para>If not specified, the platform will perform the API call synchronously, regardless of how the handle was created.</para>
	/// </param>
	/// <returns>This function does not return a value.</returns>
	/// <remarks>
	/// <para>
	/// The caller must acquire an exclusive handle to the file or data corruption can occur. To minimize the impact on user
	/// applications it is highly recommended that the caller obtain the exclusiveness using proper oplocks (via
	/// <c>CfOpenFileWithOplock</c>) as opposed to using a share-nothing handle.
	/// </para>
	/// <para>
	/// If the API returns HRESULT_FROM_WIN32(ERROR_IO_PENDING) when using Overlapped asynchronously, the caller can then wait using <c>GetOverlappedResult</c>.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/previous-versions/mt827480(v=vs.85) void STDAPI CfDehydratePlaceholder( _In_ HANDLE FileHandle,
	// _In_ LARGE_INTEGER StartingOffset, _In_ LARGE_INTEGER Length, _In_ CF_HYDRATE_FLAGS DehydrateFlags, _Inout_opt_ LPOVERLAPPED
	// Overlapped );
	[DllImport(Lib.CldApi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("CfApi.h")]
	public static unsafe extern HRESULT CfDehydratePlaceholder(HFILE FileHandle, long StartingOffset, long Length, CF_DEHYDRATE_FLAGS DehydrateFlags, [In, Out] NativeOverlapped* Overlapped);

	/// <summary>Disconnects a communication channel created by CfConnectSyncRoot.</summary>
	/// <param name="ConnectionKey">The connection key returned from CfConnectSyncRoot that is now used to disconnect the sync root.</param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	/// <remarks>
	/// <para>This removes the communication channel with the platform that was previously established using CfConnectSyncRoot.</para>
	/// <para>
	/// A sync provider can still receive callbacks during the <c>CfDisconnectSyncRoot</c> call, and the provider is free to choose
	/// whether the call needs to fail or be serviced. Either choice will not cause disruptions to the sync provider.
	/// </para>
	/// <para>
	/// After a call to <c>CfDisconnectSyncRoot</c> returns, the sync provider will no longer receive callbacks and the platform will
	/// fail any operation that depends on said callbacks.
	/// </para>
	/// <para>
	/// A sync provider should have WRITE_DATA or WRITE_DAC access to the sync root to be disconnected or a call to
	/// <c>CfDisconnectSyncRoot</c> will be failed with HRESULT(ERROR_CLOUD_FILE_ACCESS_DENIED). Also, if the sync root has not been
	/// previously connected, the call will be failed with invalid parameters.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/nf-cfapi-cfdisconnectsyncroot HRESULT CfDisconnectSyncRoot(
	// CF_CONNECTION_KEY ConnectionKey );
	[DllImport(Lib.CldApi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfapi.h", MSDNShortId = "AB09804A-257B-49A2-861E-B6E102D45182")]
	public static extern HRESULT CfDisconnectSyncRoot(CF_CONNECTION_KEY ConnectionKey);

	/// <summary>
	/// The main entry point for all connection key based placeholder operations. It is intended to be used by a sync provider to
	/// respond to various callbacks from the platform.
	/// </summary>
	/// <param name="OpInfo">Information about an operation on a placeholder.</param>
	/// <param name="OpParams">Parameters of an operation on a placeholder.</param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	/// <remarks>
	/// <para>
	/// A valid call to <c>CfExecute</c> will reset the timers of all pending callback requests that belong to the same sync provider process.
	/// </para>
	/// <para>
	/// <c>CfExecute</c> takes two variable-sized arguments, i.e., CF_OPERATION_INFO and CF_OPERATION_PARAMETERS, with one identifying
	/// the operation type and the other supplying detailed operation parameters. Both arguments start with a <c>StructSize</c> field at
	/// the beginning of the corresponding structures. Callers of <c>CfExecute</c> are responsible for accurate accounting of the
	/// structure size.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/nf-cfapi-cfexecute HRESULT CfExecute( const CF_OPERATION_INFO *OpInfo,
	// CF_OPERATION_PARAMETERS *OpParams );
	[DllImport(Lib.CldApi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfapi.h", MSDNShortId = "6AC8958D-B060-4468-9811-9BAB0E6A06D3")]
	public static extern HRESULT CfExecute(in CF_OPERATION_INFO OpInfo, ref CF_OPERATION_PARAMETERS OpParams);

	/// <summary>Allows the sync provider to query the current correlation vector for a given placeholder file.</summary>
	/// <param name="FileHandle">The handle to the placeholder file.</param>
	/// <param name="CorrelationVector">The correlation vector for the FileHandle.</param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/nf-cfapi-cfgetcorrelationvector HRESULT CfGetCorrelationVector( HANDLE
	// FileHandle, PCORRELATION_VECTOR CorrelationVector );
	[DllImport(Lib.CldApi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfapi.h", MSDNShortId = "3DB0AAFE-82DC-4707-8DB6-C52D4A9B2771")]
	public static extern HRESULT CfGetCorrelationVector(HFILE FileHandle, out CORRELATION_VECTOR CorrelationVector);

	/// <summary>Gets various characteristics of a placeholder file or folder.</summary>
	/// <param name="FileHandle">A handle to the placeholder whose information will be queried.</param>
	/// <param name="InfoClass">Placeholder information. This can be set to either CF_PLACEHOLDER_STANDARD_INFO or CF_PLACEHOLDER_BASIC_INFO.</param>
	/// <param name="InfoBuffer">A pointer to a buffer that will receive information.</param>
	/// <param name="InfoBufferLength">The length of the InfoBuffer, in bytes.</param>
	/// <param name="ReturnedLength">The number of bytes returned in the InfoBuffer.</param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/nf-cfapi-cfgetplaceholderinfo HRESULT CfGetPlaceholderInfo( HANDLE
	// FileHandle, CF_PLACEHOLDER_INFO_CLASS InfoClass, PVOID InfoBuffer, DWORD InfoBufferLength, PDWORD ReturnedLength );
	[DllImport(Lib.CldApi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfapi.h", MSDNShortId = "D82269CF-8056-46CF-9832-AAE8767A854B")]
	public static extern HRESULT CfGetPlaceholderInfo(HFILE FileHandle, CF_PLACEHOLDER_INFO_CLASS InfoClass, [Out] IntPtr InfoBuffer, uint InfoBufferLength, out uint ReturnedLength);

	/// <summary>Gets various characteristics of a placeholder file or folder.</summary>
	/// <typeparam name="T">The type of information to retrieve.</typeparam>
	/// <param name="FileHandle">A handle to the placeholder whose information will be queried.</param>
	/// <returns>The requested information.</returns>
	[PInvokeData("cfapi.h", MSDNShortId = "D82269CF-8056-46CF-9832-AAE8767A854B")]
	public static T CfGetPlaceholderInfo<T>(HFILE FileHandle) where T : struct => GetInfo<T, CF_PLACEHOLDER_INFO_CLASS, HFILE>(CfGetPlaceholderInfo, FileHandle);

	/// <summary>Gets range information about a placeholder file or folder.</summary>
	/// <param name="FileHandle">The handle of the placeholder file to be queried.</param>
	/// <param name="InfoClass">Types of the range of placeholder data.</param>
	/// <param name="StartingOffset">Offset of the starting point of the range of data.</param>
	/// <param name="Length">Length of the range of data.</param>
	/// <param name="InfoBuffer">Pointer to a buffer to receive the data.</param>
	/// <param name="InfoBufferLength">Length, in bytes, of InfoBuffer.</param>
	/// <param name="ReturnedLength">The length of the returned range of placeholder data in the InfoBuffer.</param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	/// <remarks>
	/// Unlike most placeholder APIs that take a file handle, this one does not modify the file in any way, therefore the file handle
	/// only requires READ_ATTRIBUTES access.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/nf-cfapi-cfgetplaceholderrangeinfo HRESULT CfGetPlaceholderRangeInfo(
	// HANDLE FileHandle, CF_PLACEHOLDER_RANGE_INFO_CLASS InfoClass, LARGE_INTEGER StartingOffset, LARGE_INTEGER Length, PVOID
	// InfoBuffer, DWORD InfoBufferLength, PDWORD ReturnedLength );
	[DllImport(Lib.CldApi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfapi.h", MSDNShortId = "B7FE94BC-DC59-407D-85A6-9657E38975AB")]
	public static extern HRESULT CfGetPlaceholderRangeInfo(HFILE FileHandle, CF_PLACEHOLDER_RANGE_INFO_CLASS InfoClass, long StartingOffset, long Length, [Out] IntPtr InfoBuffer, uint InfoBufferLength, out uint ReturnedLength);

	/// <summary>Gets a set of placeholder states based on the FileAttributes and ReparseTag values of the file.</summary>
	/// <param name="FileAttributes">The file attribute information.</param>
	/// <param name="ReparseTag">The reparse tag information from a file.</param>
	/// <returns>Can include CF_PLACEHOLDER_STATE; The placeholder state.</returns>
	/// <remarks>
	/// The FileAttributes and ReparseTag can be obtained by listing the directory containing the file or by directly querying
	/// FileAttributeTagInfo on the file.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/nf-cfapi-cfgetplaceholderstatefromattributetag CF_PLACEHOLDER_STATE
	// CfGetPlaceholderStateFromAttributeTag( DWORD FileAttributes, DWORD ReparseTag );
	[DllImport(Lib.CldApi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfapi.h", MSDNShortId = "D7B4FB60-3388-489F-9F55-153B53BBDA9F")]
	public static extern CF_PLACEHOLDER_STATE CfGetPlaceholderStateFromAttributeTag(FileFlagsAndAttributes FileAttributes, uint ReparseTag);

	/// <summary>Gets a set of placeholder states based on the various information of the file.</summary>
	/// <param name="InfoBuffer">An info buffer about the file.</param>
	/// <param name="InfoClass">An info class so the function knows how to interpret the InfoBuffer.</param>
	/// <returns>Can include CF_PLACEHOLDER_STATE; The placeholder state.</returns>
	/// <remarks>
	/// <para>
	/// The input is a buffer containing information returned by GetFileInformationByHandleEx, and the corresponding InfoClass so the
	/// API knows how to interpret the buffer.
	/// </para>
	/// <para>
	/// Not all information classes supported by GetFileInformationByHandleEx are supported by this API. If the FileAttributes and
	/// ReparseTag can’t be extracted from a given information class, this API will return CF_PLACEHOLDER_STATE_INVALID and set last
	/// error properly.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/nf-cfapi-cfgetplaceholderstatefromfileinfo CF_PLACEHOLDER_STATE
	// CfGetPlaceholderStateFromFileInfo( LPCVOID InfoBuffer, FILE_INFO_BY_HANDLE_CLASS InfoClass );
	[DllImport(Lib.CldApi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfapi.h", MSDNShortId = "33DB8FAC-D2C9-4BBB-8505-1D9A680EA2BF")]
	public static extern CF_PLACEHOLDER_STATE CfGetPlaceholderStateFromFileInfo(IntPtr InfoBuffer, FILE_INFO_BY_HANDLE_CLASS InfoClass);

	/// <summary>Gets a set of placeholder states based on the WIN32_FIND_DATA structure.</summary>
	/// <param name="FindData">The find data information on the file.</param>
	/// <returns>Can include CF_PLACEHOLDER_STATE; The placeholder state.</returns>
	/// <remarks>The WIN32_FIND_DATA structure is obtained from the Win32 FindFirstFile/FindNextFile functions.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/nf-cfapi-cfgetplaceholderstatefromfinddata CF_PLACEHOLDER_STATE
	// CfGetPlaceholderStateFromFindData( const WIN32_FIND_DATA *FindData );
	[DllImport(Lib.CldApi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfapi.h", MSDNShortId = "1A8104BC-E9D1-4846-B91F-4CBEDB1FC542")]
	public static extern CF_PLACEHOLDER_STATE CfGetPlaceholderStateFromFindData(in WIN32_FIND_DATA FindData);

	/// <summary>Gets the platform version information.</summary>
	/// <param name="PlatformVersion">The platform version information. See CF_PLATFORM_INFO for more details.</param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/nf-cfapi-cfgetplatforminfo HRESULT CfGetPlatformInfo( CF_PLATFORM_INFO
	// *PlatformVersion );
	[DllImport(Lib.CldApi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfapi.h", MSDNShortId = "BCF51702-87C1-405B-A3FF-98F5D0DDA8D5")]
	public static extern HRESULT CfGetPlatformInfo(out CF_PLATFORM_INFO PlatformVersion);

	/// <summary>Gets various characteristics of the sync root containing a given file specified by a file handle.</summary>
	/// <param name="FileHandle">Handle of the file under the sync root whose information is to be queried.</param>
	/// <param name="InfoClass">Types of sync root information.</param>
	/// <param name="InfoBuffer">A pointer to a buffer that will receive the sync root information.</param>
	/// <param name="InfoBufferLength">Length, in bytes, of the InfoBuffer.</param>
	/// <param name="ReturnedLength">The number of bytes returned in the InfoBuffer.</param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	/// <remarks>
	/// Unlike most placeholder APIs that take a file handle, this one does not modify the file in any way, therefore the file handle
	/// only requires READ_ATTRIBUTES access.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/nf-cfapi-cfgetsyncrootinfobyhandle HRESULT CfGetSyncRootInfoByHandle(
	// HANDLE FileHandle, CF_SYNC_ROOT_INFO_CLASS InfoClass, PVOID InfoBuffer, DWORD InfoBufferLength, DWORD *ReturnedLength );
	[DllImport(Lib.CldApi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfapi.h", MSDNShortId = "EC96CB4E-6BCE-49D9-9CDA-A24A9303B5CF")]
	public static extern HRESULT CfGetSyncRootInfoByHandle(HFILE FileHandle, CF_SYNC_ROOT_INFO_CLASS InfoClass, [Out] IntPtr InfoBuffer, uint InfoBufferLength, out uint ReturnedLength);

	/// <summary>Gets various characteristics of the sync root containing a given file specified by a file handle.</summary>
	/// <typeparam name="T">The type of information to retrieve.</typeparam>
	/// <param name="FileHandle">Handle of the file under the sync root whose information is to be queried.</param>
	/// <returns>The requested sync root information.</returns>
	[PInvokeData("cfapi.h", MSDNShortId = "EC96CB4E-6BCE-49D9-9CDA-A24A9303B5CF")]
	public static T CfGetSyncRootInfoByHandle<T>(HFILE FileHandle) where T : struct => GetInfo<T, CF_SYNC_ROOT_INFO_CLASS, HFILE>(CfGetSyncRootInfoByHandle, FileHandle);

	/// <summary>Gets various sync root information given a file under the sync root.</summary>
	/// <param name="FilePath">A fully qualified path to a file whose sync root information is to be queried</param>
	/// <param name="InfoClass">Types of sync root information.</param>
	/// <param name="InfoBuffer">A pointer to a buffer that will receive the sync root information.</param>
	/// <param name="InfoBufferLength">Length, in bytes, of the InfoBuffer.</param>
	/// <param name="ReturnedLength">
	/// Length, in bytes, of the returned sync root information. Refer to CfRegisterSyncRoot for details about the sync root information.
	/// </param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/nf-cfapi-cfgetsyncrootinfobypath HRESULT CfGetSyncRootInfoByPath(
	// LPCWSTR FilePath, CF_SYNC_ROOT_INFO_CLASS InfoClass, PVOID InfoBuffer, DWORD InfoBufferLength, DWORD *ReturnedLength );
	[DllImport(Lib.CldApi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfapi.h", MSDNShortId = "0FEEF910-3545-4D94-BFF9-88AEE084F454")]
	public static extern HRESULT CfGetSyncRootInfoByPath([MarshalAs(UnmanagedType.LPWStr)] string FilePath, CF_SYNC_ROOT_INFO_CLASS InfoClass, [Out] IntPtr InfoBuffer, uint InfoBufferLength, out uint ReturnedLength);

	/// <summary>Gets various sync root information given a file under the sync root.</summary>
	/// <typeparam name="T">The type of information to retrieve.</typeparam>
	/// <param name="FilePath">A fully qualified path to a file whose sync root information is to be queried</param>
	/// <returns>The requested sync root information.</returns>
	/// <exception cref="ArgumentException">Supplied type parameter is not supported. - T</exception>
	[PInvokeData("cfapi.h", MSDNShortId = "0FEEF910-3545-4D94-BFF9-88AEE084F454")]
	public static T CfGetSyncRootInfoByPath<T>(string FilePath) where T : struct => GetInfo<T, CF_SYNC_ROOT_INFO_CLASS, string>(CfGetSyncRootInfoByPath, FilePath);

	/// <summary>Initiates a transfer of data into a placeholder file or folder.</summary>
	/// <param name="FileHandle">The file handle of the placeholder.</param>
	/// <param name="TransferKey">An opaque handle to the placeholder to be serviced.</param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	/// <remarks>
	/// <para>
	/// <c>CfGetTransferKey</c> is used as an alternative to CfHydratePlaceholder to proactively initiate data transfer into a placeholder.
	/// </para>
	/// <para>
	/// A sync provider should have READ_DATA or WRITE_DAC access to the file whose transfer key is to be obtained or
	/// <c>CfGetTransferKey</c> will be failed with HRESULT(ERROR_CLOUD_FILE_ACCESS_DENIED).
	/// </para>
	/// <para>
	/// The TransferKey is valid as long as the FileHandle used to obtain it remains open. The sync provider must pass the TransferKey
	/// to CfExecute to perform the desired operation on the placholder file or folder. When a TransferKey is no longer being used, it
	/// must be released using CfReleaseTransferKey.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/nf-cfapi-cfgettransferkey HRESULT CfGetTransferKey( HANDLE FileHandle,
	// CF_TRANSFER_KEY *TransferKey );
	[DllImport(Lib.CldApi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfapi.h", MSDNShortId = "07DDC46A-0C10-4677-A4B0-5A0406BBDAB7")]
	public static extern HRESULT CfGetTransferKey(HFILE FileHandle, out CF_TRANSFER_KEY TransferKey);

	/// <summary>Converts a protected handle to a Win32 handle so that it can be used with all handle-based Win32 APIs.</summary>
	/// <param name="ProtectedHandle">The protected handle to be converted.</param>
	/// <returns>The corresponding Win32 handle.</returns>
	/// <remarks>
	/// <para>
	/// The caller must have referenced the protected handle prior to this call using CfReferenceProtectedHandle to ensure that the use
	/// of the Win32 handle is tracked, and the Win32 API call that consumes the Win32 handle is synchronized with the oplock break
	/// notification acknowledgment.
	/// </para>
	/// <para>The caller must release the reference on the protected handle after being done with the Win32 handle using CfReleaseProtectedHandle.</para>
	/// <para>In no circumstances should the caller close the Win32 handle returned using CfCloseHandle.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/nf-cfapi-cfgetwin32handlefromprotectedhandle HANDLE
	// CfGetWin32HandleFromProtectedHandle( HANDLE ProtectedHandle );
	[DllImport(Lib.CldApi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfapi.h", MSDNShortId = "8C54B6F3-7709-4021-8965-E96B74DD3319")]
	public static extern HFILE CfGetWin32HandleFromProtectedHandle(HCFFILE ProtectedHandle);

	/// <summary>
	/// Hydrates a placeholder file by ensuring that the specified byte range is present on-disk in the placeholder. This is valid for
	/// files only.
	/// </summary>
	/// <param name="FileHandle">Handle of the placeholder file to be hydrated. An attribute or no-access handle is sufficient.</param>
	/// <param name="StartingOffset">The starting point offset of the placeholder file data.</param>
	/// <param name="Length">
	/// The length, in bytes, of the placeholder file whose data must be available locally on the disk after the API completes
	/// successfully. A length of -1 signifies end of file.
	/// </param>
	/// <param name="HydrateFlags">Placeholder hydration flags.</param>
	/// <param name="Overlapped">
	/// <para>
	/// When specified and combined with an asynchronous FileHandle, Overlapped allows the platform to perform the
	/// <c>CfHydratePlaceholder</c> call asynchronously. See the Remarks for more details.
	/// </para>
	/// <para>If not specified, the platform will perform the API call synchronously, regardless of how the handle was created.</para>
	/// </param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	/// <remarks>
	/// <para>The caller must have READ_DATA or WRITE_DAC access to the placeholder to be hydrated.</para>
	/// <para>
	/// If the API returns HRESULT_FROM_WIN32(ERROR_IO_PENDING) when using Overlapped asynchronously, the caller can then wait using GetOverlappedResult.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/nf-cfapi-cfhydrateplaceholder HRESULT CfHydratePlaceholder( HANDLE
	// FileHandle, LARGE_INTEGER StartingOffset, LARGE_INTEGER Length, CF_HYDRATE_FLAGS HydrateFlags, LPOVERLAPPED Overlapped );
	[DllImport(Lib.CldApi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfapi.h", MSDNShortId = "4FFD7580-BF59-48D0-B6D7-516559914096")]
	public static extern HRESULT CfHydratePlaceholder(HFILE FileHandle, long StartingOffset = 0, long Length = -1, CF_HYDRATE_FLAGS HydrateFlags = 0, [In, Out] IntPtr Overlapped = default);

	/// <summary>
	/// Hydrates a placeholder file by ensuring that the specified byte range is present on-disk in the placeholder. This is valid for
	/// files only.
	/// </summary>
	/// <param name="FileHandle">Handle of the placeholder file to be hydrated. An attribute or no-access handle is sufficient.</param>
	/// <param name="StartingOffset">The starting point offset of the placeholder file data.</param>
	/// <param name="Length">
	/// The length, in bytes, of the placeholder file whose data must be available locally on the disk after the API completes
	/// successfully. A length of -1 signifies end of file.
	/// </param>
	/// <param name="HydrateFlags">Placeholder hydration flags.</param>
	/// <param name="Overlapped">
	/// <para>
	/// When specified and combined with an asynchronous FileHandle, Overlapped allows the platform to perform the
	/// <c>CfHydratePlaceholder</c> call asynchronously. See the Remarks for more details.
	/// </para>
	/// <para>If not specified, the platform will perform the API call synchronously, regardless of how the handle was created.</para>
	/// </param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	/// <remarks>
	/// <para>The caller must have READ_DATA or WRITE_DAC access to the placeholder to be hydrated.</para>
	/// <para>
	/// If the API returns HRESULT_FROM_WIN32(ERROR_IO_PENDING) when using Overlapped asynchronously, the caller can then wait using GetOverlappedResult.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/nf-cfapi-cfhydrateplaceholder HRESULT CfHydratePlaceholder( HANDLE
	// FileHandle, LARGE_INTEGER StartingOffset, LARGE_INTEGER Length, CF_HYDRATE_FLAGS HydrateFlags, LPOVERLAPPED Overlapped );
	[DllImport(Lib.CldApi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfapi.h", MSDNShortId = "4FFD7580-BF59-48D0-B6D7-516559914096")]
	public static unsafe extern HRESULT CfHydratePlaceholder(HFILE FileHandle, long StartingOffset, long Length, CF_HYDRATE_FLAGS HydrateFlags, [In, Out] NativeOverlapped* Overlapped);

	/// <summary>
	/// Opens an asynchronous opaque handle to a file or directory (for both normal and placeholder files) and sets up a proper oplock
	/// on it based on the open flags.
	/// </summary>
	/// <param name="FilePath">Fully qualified path to the file or directory to be opened.</param>
	/// <param name="Flags">Flags to specify permissions on opening the file.</param>
	/// <param name="ProtectedHandle">
	/// An opaque handle to the file or directory that is just opened. Note that this is not a normal Win32 handle and hence cannot be
	/// used with non-CfApi Win32 APIs directly.
	/// </param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	/// <remarks>
	/// <para>
	/// When the oplock is broken, the API will handle the break notification automatically on behalf of the caller by draining all
	/// active requests and then closing the underneath Win32 handle.
	/// </para>
	/// <para>
	/// This aims to removing the complexity related to oplock usages. The caller must close the handle returned by
	/// <c>CfOpenFileWithOplock</c> with CfCloseHandle.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/nf-cfapi-cfopenfilewithoplock HRESULT CfOpenFileWithOplock( LPCWSTR
	// FilePath, CF_OPEN_FILE_FLAGS Flags, PHANDLE ProtectedHandle );
	[DllImport(Lib.CldApi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfapi.h", MSDNShortId = "AFC48080-3B4A-4F6B-9122-25C2A025EA95")]
	public static extern HRESULT CfOpenFileWithOplock([MarshalAs(UnmanagedType.LPWStr)] string FilePath, CF_OPEN_FILE_FLAGS Flags, out SafeHCFFILE ProtectedHandle);

	/// <summary>Queries a sync provider to get the status of the provider.</summary>
	/// <param name="ConnectionKey">A connection key representing a communication channel with the sync filter.</param>
	/// <param name="ProviderStatus">The current status of the sync provider.</param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/nf-cfapi-cfquerysyncproviderstatus HRESULT CfQuerySyncProviderStatus(
	// CF_CONNECTION_KEY ConnectionKey, CF_SYNC_PROVIDER_STATUS *ProviderStatus );
	[DllImport(Lib.CldApi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfapi.h", MSDNShortId = "02E6197B-D84A-4E3F-A74C-F5DACAA60AF9")]
	public static extern HRESULT CfQuerySyncProviderStatus(CF_CONNECTION_KEY ConnectionKey, out CF_SYNC_PROVIDER_STATUS ProviderStatus);

	/// <summary>Allows the caller to reference a protected handle to a Win32 handle which can be used with non-CfApi Win32 APIs.</summary>
	/// <param name="ProtectedHandle">The protected handle of a placeholder file.</param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	/// <remarks>
	/// <para>
	/// Every <c>CfReferenceProtectedHandle</c> call must be matched with a CfReleaseProtectedHandle call. It is not recommended to
	/// reference a protected handle for a long period of time, as doing so will prevent the oplock break notification from being acknowledged.
	/// </para>
	/// <para>
	/// The caller should instead break up long running tasks into smaller sub-tasks and reference/release the protected handle for each sub-task.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/nf-cfapi-cfreferenceprotectedhandle BOOLEAN CfReferenceProtectedHandle(
	// HANDLE ProtectedHandle );
	[DllImport(Lib.CldApi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfapi.h", MSDNShortId = "C6281FD6-3A37-4D90-9B19-03DD23949C39")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern bool CfReferenceProtectedHandle(HCFFILE ProtectedHandle);

	/// <summary>Performs a one time sync root registration.</summary>
	/// <param name="SyncRootPath">The path to the sync root to be registered.</param>
	/// <param name="Registration">Contains information about the sync provider and sync root to be registered.</param>
	/// <param name="Policies">The policies of the sync root to be registered.</param>
	/// <param name="RegisterFlags">Flags for registering previous and new sync roots.</param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	/// <remarks>
	/// <para>
	/// This can be used at a sync provider install time, first time set up for an individual user, or when a user configures another
	/// sync root (if this scenario is supported).
	/// </para>
	/// <para>
	/// This performs a one time sync root registration, which allows a sync provider to utilize an entire directory tree structure.
	/// Note that no two sync roots directory trees can overlap with one another.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/nf-cfapi-cfregistersyncroot HRESULT CfRegisterSyncRoot( LPCWSTR
	// SyncRootPath, const CF_SYNC_REGISTRATION *Registration, const CF_SYNC_POLICIES *Policies, CF_REGISTER_FLAGS RegisterFlags );
	[DllImport(Lib.CldApi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfapi.h", MSDNShortId = "FAD56873-8812-42DC-9975-9507F73BD9E3")]
	public static extern HRESULT CfRegisterSyncRoot([MarshalAs(UnmanagedType.LPWStr)] string SyncRootPath, in CF_SYNC_REGISTRATION Registration, in CF_SYNC_POLICIES Policies, CF_REGISTER_FLAGS RegisterFlags);

	/// <summary>Releases a protected handle referenced by CfReferenceProtectedHandle.</summary>
	/// <param name="ProtectedHandle">The protected handle to be released.</param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/nf-cfapi-cfreleaseprotectedhandle void CfReleaseProtectedHandle( HANDLE
	// ProtectedHandle );
	[DllImport(Lib.CldApi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfapi.h", MSDNShortId = "BB63C5EE-92D7-4051-8198-09F50BBC75C5")]
	public static extern void CfReleaseProtectedHandle(HCFFILE ProtectedHandle);

	/// <summary>Releases a transfer key obtained by CfGetTransferKey.</summary>
	/// <param name="FileHandle">The file handle of the placeholder.</param>
	/// <param name="TransferKey">An opaque handle to the placeholder.</param>
	/// <returns>None</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/nf-cfapi-cfreleasetransferkey void CfReleaseTransferKey( HANDLE
	// FileHandle, CF_TRANSFER_KEY *TransferKey );
	[DllImport(Lib.CldApi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfapi.h", MSDNShortId = "53B40C34-EB1F-445B-B1B3-B539C2FADECE")]
	public static extern void CfReleaseTransferKey(HFILE FileHandle, in CF_TRANSFER_KEY TransferKey);

	/// <summary>Allows a sync provider to report progress out-of-band.</summary>
	/// <param name="ConnectionKey">A connection key representing a communication channel with the sync filter.</param>
	/// <param name="TransferKey">An opaque handle to the placeholder.</param>
	/// <param name="ProviderProgressTotal">The total progress of the sync provider in response to a fetch data callback.</param>
	/// <param name="ProviderProgressCompleted">The completed progress of the sync provider in response to a fetch data callback.</param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/nf-cfapi-cfreportproviderprogress HRESULT CfReportProviderProgress(
	// CF_CONNECTION_KEY ConnectionKey, CF_TRANSFER_KEY TransferKey, LARGE_INTEGER ProviderProgressTotal, LARGE_INTEGER
	// ProviderProgressCompleted );
	[DllImport(Lib.CldApi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfapi.h", MSDNShortId = "33AB46FD-200E-40FF-B061-5842C6433069")]
	public static extern HRESULT CfReportProviderProgress(CF_CONNECTION_KEY ConnectionKey, CF_TRANSFER_KEY TransferKey, long ProviderProgressTotal, long ProviderProgressCompleted);

	/// <summary>
	/// Allows a sync provider to notify the platform of its status on a specified sync root without having to connect with a call to
	/// CfConnectSyncRoot first.
	/// </summary>
	/// <param name="SyncRootPath">Path to the sync root.</param>
	/// <param name="SyncStatus">
	/// The sync status to report; if <c>null</c>, clears the previously-saved sync status. For more information, see the Remarks
	/// section, below.
	/// </param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	/// <remarks>
	/// <para>
	/// When a non-null CF_SYNC_STATUS is provided in the SyncStatus parameter, the information will be remembered on the sync root
	/// until it is cleared explicitly by the sync provider or when the machine reboots. The platform will query this information upon
	/// any failed operations on a cloud file placeholder, using the following process:
	/// </para>
	/// <list type="number">
	/// <item>
	/// <term/>
	/// </item>
	/// <item>
	/// <term/>
	/// </item>
	/// <item>
	/// <term/>
	/// </item>
	/// </list>
	/// <para>
	/// <c>CfReportSyncStatus</c> clears the previously-saved sync status when being called with a <c>null</c> sync status. No change
	/// will be made to the existing sync status if the function call fails.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/nf-cfapi-cfreportsyncstatus HRESULT CfReportSyncStatus( LPCWSTR
	// SyncRootPath, CF_SYNC_STATUS *SyncStatus );
	[DllImport(Lib.CldApi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfapi.h", MSDNShortId = "DC77D18A-CBF4-4172-815A-AB49A48D10B3")]
	public static extern HRESULT CfReportSyncStatus([MarshalAs(UnmanagedType.LPWStr)] string SyncRootPath, in CF_SYNC_STATUS SyncStatus);

	/// <summary>
	/// Allows a sync provider to notify the platform of its status on a specified sync root without having to connect with a call to
	/// CfConnectSyncRoot first.
	/// </summary>
	/// <param name="SyncRootPath">Path to the sync root.</param>
	/// <param name="SyncStatus">
	/// The sync status to report; if <c>null</c>, clears the previously-saved sync status. For more information, see the Remarks
	/// section, below.
	/// </param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	/// <remarks>
	/// <para>
	/// When a non-null CF_SYNC_STATUS is provided in the SyncStatus parameter, the information will be remembered on the sync root
	/// until it is cleared explicitly by the sync provider or when the machine reboots. The platform will query this information upon
	/// any failed operations on a cloud file placeholder, using the following process:
	/// </para>
	/// <list type="number">
	/// <item>
	/// <term/>
	/// </item>
	/// <item>
	/// <term/>
	/// </item>
	/// <item>
	/// <term/>
	/// </item>
	/// </list>
	/// <para>
	/// <c>CfReportSyncStatus</c> clears the previously-saved sync status when being called with a <c>null</c> sync status. No change
	/// will be made to the existing sync status if the function call fails.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/nf-cfapi-cfreportsyncstatus HRESULT CfReportSyncStatus( LPCWSTR
	// SyncRootPath, CF_SYNC_STATUS *SyncStatus );
	[DllImport(Lib.CldApi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfapi.h", MSDNShortId = "DC77D18A-CBF4-4172-815A-AB49A48D10B3")]
	public static extern HRESULT CfReportSyncStatus([MarshalAs(UnmanagedType.LPWStr)] string SyncRootPath, [In, Optional] IntPtr SyncStatus);

	/// <summary>
	/// Reverts a placeholder back to a regular file, stripping away all special characteristics such as the reparse tag, the file
	/// identity, etc.
	/// </summary>
	/// <param name="FileHandle">
	/// A handle to the file or directory placeholder that is about to be reverted to normal file or directory. An attribute or
	/// no-access handle is sufficient.
	/// </param>
	/// <param name="RevertFlags">Placeholder revert flags.</param>
	/// <param name="Overlapped">
	/// <para>
	/// When specified and combined with an asynchronous FileHandle, Overlapped allows the platform to perform the
	/// <c>CfRevertPlaceholder</c> call asynchronously. See the Remarks for more details.
	/// </para>
	/// <para>If not specified, the platform will perform the API call synchronously, regardless of how the handle was created.</para>
	/// </param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	/// <remarks>
	/// <para>The caller must have WRITE_DATA or WRITE_DAC access to the placeholder to be reverted.</para>
	/// <para>
	/// If the placeholder is not already fully hydrated at the time of the call, then the filter will send a FETCH_DATA callback to the
	/// sync provider to hydrate the file. If the file can’t be hydrated, the revert will fail.
	/// </para>
	/// <para>
	/// If the API returns HRESULT_FROM_WIN32(ERROR_IO_PENDING) when using Overlapped asynchronously, the caller can then wait using GetOverlappedResult.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/nf-cfapi-cfrevertplaceholder HRESULT CfRevertPlaceholder( HANDLE
	// FileHandle, CF_REVERT_FLAGS RevertFlags, LPOVERLAPPED Overlapped );
	[DllImport(Lib.CldApi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfapi.h", MSDNShortId = "D5404BB6-A066-4B5F-A355-A11A107610CE")]
	public static extern HRESULT CfRevertPlaceholder(HFILE FileHandle, CF_REVERT_FLAGS RevertFlags, [In, Out, Optional] IntPtr Overlapped);

	/// <summary>
	/// Reverts a placeholder back to a regular file, stripping away all special characteristics such as the reparse tag, the file
	/// identity, etc.
	/// </summary>
	/// <param name="FileHandle">
	/// A handle to the file or directory placeholder that is about to be reverted to normal file or directory. An attribute or
	/// no-access handle is sufficient.
	/// </param>
	/// <param name="RevertFlags">Placeholder revert flags.</param>
	/// <param name="Overlapped">
	/// <para>
	/// When specified and combined with an asynchronous FileHandle, Overlapped allows the platform to perform the
	/// <c>CfRevertPlaceholder</c> call asynchronously. See the Remarks for more details.
	/// </para>
	/// <para>If not specified, the platform will perform the API call synchronously, regardless of how the handle was created.</para>
	/// </param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	/// <remarks>
	/// <para>The caller must have WRITE_DATA or WRITE_DAC access to the placeholder to be reverted.</para>
	/// <para>
	/// If the placeholder is not already fully hydrated at the time of the call, then the filter will send a FETCH_DATA callback to the
	/// sync provider to hydrate the file. If the file can’t be hydrated, the revert will fail.
	/// </para>
	/// <para>
	/// If the API returns HRESULT_FROM_WIN32(ERROR_IO_PENDING) when using Overlapped asynchronously, the caller can then wait using GetOverlappedResult.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/nf-cfapi-cfrevertplaceholder HRESULT CfRevertPlaceholder( HANDLE
	// FileHandle, CF_REVERT_FLAGS RevertFlags, LPOVERLAPPED Overlapped );
	[DllImport(Lib.CldApi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfapi.h", MSDNShortId = "D5404BB6-A066-4B5F-A355-A11A107610CE")]
	public static unsafe extern HRESULT CfRevertPlaceholder(HFILE FileHandle, CF_REVERT_FLAGS RevertFlags, [In, Out] NativeOverlapped* Overlapped);

	/// <summary>
	/// Allows a sync provider to instruct the platform to use a specific correlation vector for telemetry purposes on a placeholder
	/// file. This is optional.
	/// </summary>
	/// <param name="FileHandle">The handle to the placeholder file.</param>
	/// <param name="CorrelationVector">A specific correlation vector to be associated with the FileHandle.</param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	/// <remarks>
	/// The platform automatically assigns a correlation vector to each file when it is first opened, and provides this correlation
	/// vector with each callback to the sync provider as part of the common CF_CALLBACK_INFO. It is suggested that the sync engine call
	/// this function to increment the last digit of the correlation vector “clock” as the sync provider progresses through internal
	/// stages (as defined by the sync provider) of satisfying the request.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/nf-cfapi-cfsetcorrelationvector HRESULT CfSetCorrelationVector( HANDLE
	// FileHandle, const PCORRELATION_VECTOR CorrelationVector );
	[DllImport(Lib.CldApi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfapi.h", MSDNShortId = "B9B05D24-BEE5-4BE6-95D5-C28466D69543")]
	public static extern HRESULT CfSetCorrelationVector(HFILE FileHandle, in CORRELATION_VECTOR CorrelationVector);

	/// <summary>Sets the in-sync state for a placeholder file or folder.</summary>
	/// <param name="FileHandle">A handle to the placeholder. The caller must have WRITE_DATA or WRITE_DAC access to the placeholder.</param>
	/// <param name="InSyncState">The in-sync state. See CF_IN_SYNC_STATE for more details.</param>
	/// <param name="InSyncFlags">The in-sync state flags. See CF_SET_IN_SYNC_FLAGS for more details.</param>
	/// <param name="InSyncUsn">
	/// When specified, this instructs the platform to only perform in-sync setting if the file still has the same USN value as the one
	/// passed in. Passing a pointer to a USN value of 0 on input is the same as passing a NULL pointer. On return, this is the final
	/// USN value after setting the in-sync state.
	/// </param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/nf-cfapi-cfsetinsyncstate HRESULT CfSetInSyncState( HANDLE FileHandle,
	// CF_IN_SYNC_STATE InSyncState, CF_SET_IN_SYNC_FLAGS InSyncFlags, USN *InSyncUsn );
	[DllImport(Lib.CldApi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfapi.h", MSDNShortId = "1CB7955D-E530-4F34-8D67-BC608F8B6AF1")]
	public static extern HRESULT CfSetInSyncState(HFILE FileHandle, CF_IN_SYNC_STATE InSyncState, CF_SET_IN_SYNC_FLAGS InSyncFlags, ref USN InSyncUsn);

	/// <summary>Sets the in-sync state for a placeholder file or folder.</summary>
	/// <param name="FileHandle">A handle to the placeholder. The caller must have WRITE_DATA or WRITE_DAC access to the placeholder.</param>
	/// <param name="InSyncState">The in-sync state. See CF_IN_SYNC_STATE for more details.</param>
	/// <param name="InSyncFlags">The in-sync state flags. See CF_SET_IN_SYNC_FLAGS for more details.</param>
	/// <param name="InSyncUsn">
	/// When specified, this instructs the platform to only perform in-sync setting if the file still has the same USN value as the one
	/// passed in. Passing a pointer to a USN value of 0 on input is the same as passing a NULL pointer. On return, this is the final
	/// USN value after setting the in-sync state.
	/// </param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/nf-cfapi-cfsetinsyncstate HRESULT CfSetInSyncState( HANDLE FileHandle,
	// CF_IN_SYNC_STATE InSyncState, CF_SET_IN_SYNC_FLAGS InSyncFlags, USN *InSyncUsn );
	[DllImport(Lib.CldApi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfapi.h", MSDNShortId = "1CB7955D-E530-4F34-8D67-BC608F8B6AF1")]
	public static extern HRESULT CfSetInSyncState(HFILE FileHandle, CF_IN_SYNC_STATE InSyncState, CF_SET_IN_SYNC_FLAGS InSyncFlags, [In, Optional] IntPtr InSyncUsn);

	/// <summary>
	/// This sets the pin state of a placeholder, used to represent a user’s intent. Any application (not just the sync provider) can
	/// call this function.
	/// </summary>
	/// <param name="FileHandle">The handle of the placeholder file. The caller must have READ_DATA or WRITE_DAC access to the placeholder.</param>
	/// <param name="PinState">The pin state of the placeholder file.</param>
	/// <param name="PinFlags">The pin state flags.</param>
	/// <param name="Overlapped">Allows the call to be performed asynchronously. See the Remarks section for more details.</param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	/// <remarks>
	/// <para>When specified and combined with an asynchronous FileHandle, Overlapped allows the platform to perform the call asynchronously.</para>
	/// <para>
	/// The caller must have initialized the overlapped structure with an event to wait on. If this returns
	/// HRESULT_FROM_WIN32(ERROR_IO_PENDING), the caller can then wait using GetOverlappedResult. If not specified, the platform will
	/// perform the API call synchronously, regardless of how the handle was created.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/nf-cfapi-cfsetpinstate HRESULT CfSetPinState( HANDLE FileHandle,
	// CF_PIN_STATE PinState, CF_SET_PIN_FLAGS PinFlags, LPOVERLAPPED Overlapped );
	[DllImport(Lib.CldApi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfapi.h", MSDNShortId = "8B279914-E23A-479B-8621-E83DE1978597")]
	public static extern HRESULT CfSetPinState(HFILE FileHandle, CF_PIN_STATE PinState, CF_SET_PIN_FLAGS PinFlags, [In, Out, Optional] IntPtr Overlapped);

	/// <summary>
	/// This sets the pin state of a placeholder, used to represent a user’s intent. Any application (not just the sync provider) can
	/// call this function.
	/// </summary>
	/// <param name="FileHandle">The handle of the placeholder file. The caller must have READ_DATA or WRITE_DAC access to the placeholder.</param>
	/// <param name="PinState">The pin state of the placeholder file.</param>
	/// <param name="PinFlags">The pin state flags.</param>
	/// <param name="Overlapped">Allows the call to be performed asynchronously. See the Remarks section for more details.</param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	/// <remarks>
	/// <para>When specified and combined with an asynchronous FileHandle, Overlapped allows the platform to perform the call asynchronously.</para>
	/// <para>
	/// The caller must have initialized the overlapped structure with an event to wait on. If this returns
	/// HRESULT_FROM_WIN32(ERROR_IO_PENDING), the caller can then wait using GetOverlappedResult. If not specified, the platform will
	/// perform the API call synchronously, regardless of how the handle was created.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/nf-cfapi-cfsetpinstate HRESULT CfSetPinState( HANDLE FileHandle,
	// CF_PIN_STATE PinState, CF_SET_PIN_FLAGS PinFlags, LPOVERLAPPED Overlapped );
	[DllImport(Lib.CldApi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfapi.h", MSDNShortId = "8B279914-E23A-479B-8621-E83DE1978597")]
	public static unsafe extern HRESULT CfSetPinState(HFILE FileHandle, CF_PIN_STATE PinState, CF_SET_PIN_FLAGS PinFlags, [In, Out] NativeOverlapped* Overlapped);

	/// <summary>Unregisters a previously registered sync root.</summary>
	/// <param name="SyncRootPath">The path to the sync root to be unregistered.</param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	/// <remarks>
	/// <para>
	/// Unregisters a sync root that was registered with CfRegisterSyncRoot. This is typically called at the sync provider uninstall
	/// time, when a user account is deleted, or when a user opts to no longer sync a directory tree (if supported by the sync provider).
	/// </para>
	/// <para>
	/// The sync provider should have WRITE_DATA or WRITE_DAC access to the sync root to be unregistered, or unregistration will fail
	/// with: HRESULT(ERROR_CLOUD_FILE_ACCESS_DENIED).
	/// </para>
	/// <para>Unregisters a sync root by traversing the directory tree of the sync root.</para>
	/// <para>For placeholder files:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>If a placeholder file is fully hydrated, it is reverted back to a "normal" file.</term>
	/// </item>
	/// <item>
	/// <term>If a placeholder file is not hydrated, it is permanently deleted from the local machine.</term>
	/// </item>
	/// </list>
	/// <para>For placeholder directories:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>If a placeholder directory is fully populated, it is reverted back to a "normal" directory.</term>
	/// </item>
	/// <item>
	/// <term>If a placeholder directory is not fully populated, the directory is permanently deleted from the local machine.</term>
	/// </item>
	/// </list>
	/// <para>
	/// <c>Note</c> If the placeholder files or directories cannot be reverted or deleted, it will be skipped, and the unregistering
	/// process will continue until the full sync root tree has been traversed.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/nf-cfapi-cfunregistersyncroot HRESULT CfUnregisterSyncRoot( LPCWSTR
	// SyncRootPath );
	[DllImport(Lib.CldApi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfapi.h", MSDNShortId = "B4DA85DB-A63A-45EB-9F71-9395AC026A0C")]
	public static extern HRESULT CfUnregisterSyncRoot([MarshalAs(UnmanagedType.LPWStr)] string SyncRootPath);

	/// <summary>Updates characteristics of the placeholder file or directory.</summary>
	/// <param name="FileHandle">A handle to the file or directory whose metadata is to be updated.</param>
	/// <param name="FsMetadata">
	/// File system metadata to be updated for the placeholder. Values of 0 for the metadata indicate there are no updates.
	/// </param>
	/// <param name="FileIdentity">
	/// A user mode buffer that contains file or directory information supplied by the caller. Should not exceed 4KB in size.
	/// </param>
	/// <param name="FileIdentityLength">Length, in bytes, of the FileIdentity.</param>
	/// <param name="DehydrateRangeArray">
	/// A range of an existing placeholder that will no longer be considered valid after the call to <c>CfUpdatePlaceholder</c>.
	/// </param>
	/// <param name="DehydrateRangeCount">The count of a series of discrete DehydrateRangeArray partitions of placeholder data.</param>
	/// <param name="UpdateFlags">Update flags for placeholders.</param>
	/// <param name="UpdateUsn">
	/// <para>
	/// On input, UpdateUsn instructs the platform to only perform the update if the file still has the same USN value as the one passed
	/// in. This serves a similar purpose to <c>CF_UPDATE_FLAG_VERIFY_IN_SYNC</c> but also encompasses local metadata changes.
	/// </para>
	/// <para>On return, UpdateUsn receives the final USN value after update actions were performed.</para>
	/// </param>
	/// <param name="Overlapped">
	/// <para>
	/// When specified and combined with an asynchronous FileHandle, Overlapped allows the platform to perform the
	/// <c>CfUpdatePlaceholder</c> call asynchronously. See the Remarks for more details.
	/// </para>
	/// <para>If not specified, the platform will perform the API call synchronously, regardless of how the handle was created.</para>
	/// </param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	/// <remarks>
	/// <para>To update a placeholder:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// The placeholder to be updated must be contained in a registered sync root tree; it can be the sync root directory itself, or any
	/// descendant directory; otherwise, the call with be failed with HRESULT(ERROR_CLOUD_FILE_NOT_UNDER_SYNC_ROOT).
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If dehydration is requested, the sync root must be registered with a valid hydration policy that is not
	/// CF_HYDRATION_POLICY_ALWAYS_FULL; otherwise the call will be failed with HRESULT(ERROR_CLOUD_FILE_NOT_SUPPORTED).
	/// </term>
	/// </item>
	/// <item>
	/// <term>If dehydration is requested, the placeholder must not be pinned locally or the call with be failed with HRESULT(ERROR_CLOUD_FILE_PINNED).</term>
	/// </item>
	/// <item>
	/// <term>If dehydration is requested, the placeholder must be in sync or the call with be failed with HRESULT(ERROR_CLOUD_FILE_NOT_IN_SYNC).</term>
	/// </item>
	/// <item>
	/// <term>
	/// The caller must have WRITE_DATA or WRITE_DAC access to the placeholder to be updated. Otherwise the operation will be failed
	/// with HRESULT(ERROR_CLOUD_FILE_ACCESS_DENIED).
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// If the API returns HRESULT_FROM_WIN32(ERROR_IO_PENDING) when using Overlapped asynchronously, the caller can then wait using GetOverlappedResult.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/nf-cfapi-cfupdateplaceholder HRESULT CfUpdatePlaceholder( HANDLE
	// FileHandle, const CF_FS_METADATA *FsMetadata, LPCVOID FileIdentity, DWORD FileIdentityLength, const CF_FILE_RANGE
	// *DehydrateRangeArray, DWORD DehydrateRangeCount, CF_UPDATE_FLAGS UpdateFlags, USN *UpdateUsn, LPOVERLAPPED Overlapped );
	[DllImport(Lib.CldApi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfapi.h", MSDNShortId = "13F2BF9A-505F-4CFB-B008-7DDE85A3C581")]
	public static extern HRESULT CfUpdatePlaceholder(HFILE FileHandle, in CF_FS_METADATA FsMetadata, [In] IntPtr FileIdentity, uint FileIdentityLength,
		[In, Optional, MarshalAs(UnmanagedType.LPArray)] CF_FILE_RANGE[]? DehydrateRangeArray, uint DehydrateRangeCount, CF_UPDATE_FLAGS UpdateFlags,
		ref USN UpdateUsn, [In, Out, Optional] IntPtr Overlapped);

	/// <summary>Updates characteristics of the placeholder file or directory.</summary>
	/// <param name="FileHandle">A handle to the file or directory whose metadata is to be updated.</param>
	/// <param name="FsMetadata">
	/// File system metadata to be updated for the placeholder. Values of 0 for the metadata indicate there are no updates.
	/// </param>
	/// <param name="FileIdentity">
	/// A user mode buffer that contains file or directory information supplied by the caller. Should not exceed 4KB in size.
	/// </param>
	/// <param name="FileIdentityLength">Length, in bytes, of the FileIdentity.</param>
	/// <param name="DehydrateRangeArray">
	/// A range of an existing placeholder that will no longer be considered valid after the call to <c>CfUpdatePlaceholder</c>.
	/// </param>
	/// <param name="DehydrateRangeCount">The count of a series of discrete DehydrateRangeArray partitions of placeholder data.</param>
	/// <param name="UpdateFlags">Update flags for placeholders.</param>
	/// <param name="UpdateUsn">
	/// <para>
	/// On input, UpdateUsn instructs the platform to only perform the update if the file still has the same USN value as the one passed
	/// in. This serves a similar purpose to <c>CF_UPDATE_FLAG_VERIFY_IN_SYNC</c> but also encompasses local metadata changes.
	/// </para>
	/// <para>On return, UpdateUsn receives the final USN value after update actions were performed.</para>
	/// </param>
	/// <param name="Overlapped">
	/// <para>
	/// When specified and combined with an asynchronous FileHandle, Overlapped allows the platform to perform the
	/// <c>CfUpdatePlaceholder</c> call asynchronously. See the Remarks for more details.
	/// </para>
	/// <para>If not specified, the platform will perform the API call synchronously, regardless of how the handle was created.</para>
	/// </param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	/// <remarks>
	/// <para>To update a placeholder:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// The placeholder to be updated must be contained in a registered sync root tree; it can be the sync root directory itself, or any
	/// descendant directory; otherwise, the call with be failed with HRESULT(ERROR_CLOUD_FILE_NOT_UNDER_SYNC_ROOT).
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If dehydration is requested, the sync root must be registered with a valid hydration policy that is not
	/// CF_HYDRATION_POLICY_ALWAYS_FULL; otherwise the call will be failed with HRESULT(ERROR_CLOUD_FILE_NOT_SUPPORTED).
	/// </term>
	/// </item>
	/// <item>
	/// <term>If dehydration is requested, the placeholder must not be pinned locally or the call with be failed with HRESULT(ERROR_CLOUD_FILE_PINNED).</term>
	/// </item>
	/// <item>
	/// <term>If dehydration is requested, the placeholder must be in sync or the call with be failed with HRESULT(ERROR_CLOUD_FILE_NOT_IN_SYNC).</term>
	/// </item>
	/// <item>
	/// <term>
	/// The caller must have WRITE_DATA or WRITE_DAC access to the placeholder to be updated. Otherwise the operation will be failed
	/// with HRESULT(ERROR_CLOUD_FILE_ACCESS_DENIED).
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// If the API returns HRESULT_FROM_WIN32(ERROR_IO_PENDING) when using Overlapped asynchronously, the caller can then wait using GetOverlappedResult.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/nf-cfapi-cfupdateplaceholder HRESULT CfUpdatePlaceholder( HANDLE
	// FileHandle, const CF_FS_METADATA *FsMetadata, LPCVOID FileIdentity, DWORD FileIdentityLength, const CF_FILE_RANGE
	// *DehydrateRangeArray, DWORD DehydrateRangeCount, CF_UPDATE_FLAGS UpdateFlags, USN *UpdateUsn, LPOVERLAPPED Overlapped );
	[DllImport(Lib.CldApi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfapi.h", MSDNShortId = "13F2BF9A-505F-4CFB-B008-7DDE85A3C581")]
	public static unsafe extern HRESULT CfUpdatePlaceholder(HFILE FileHandle, in CF_FS_METADATA FsMetadata, [In] IntPtr FileIdentity, uint FileIdentityLength,
		[In, Optional, MarshalAs(UnmanagedType.LPArray)] CF_FILE_RANGE[]? DehydrateRangeArray, uint DehydrateRangeCount, CF_UPDATE_FLAGS UpdateFlags,
		ref USN UpdateUsn, [In, Out] NativeOverlapped* Overlapped);

	/// <summary>Updates the current status of the sync provider.</summary>
	/// <param name="ConnectionKey">A connection key representing a communication channel with the sync filter.</param>
	/// <param name="ProviderStatus">The current status of the sync provider.</param>
	/// <returns>If this function succeeds, it returns <c>S_OK</c>. Otherwise, it returns an <c>HRESULT</c> error code.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/cfapi/nf-cfapi-cfupdatesyncproviderstatus HRESULT CfUpdateSyncProviderStatus(
	// CF_CONNECTION_KEY ConnectionKey, CF_SYNC_PROVIDER_STATUS ProviderStatus );
	[DllImport(Lib.CldApi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cfapi.h", MSDNShortId = "E0CB6CA2-439A-4919-95EF-B519ABBBB085")]
	public static extern HRESULT CfUpdateSyncProviderStatus(CF_CONNECTION_KEY ConnectionKey, CF_SYNC_PROVIDER_STATUS ProviderStatus);

	private static T GetInfo<T, TEnum, TParam>(GetInfoFunc<TParam, TEnum> func, TParam firstParam) where TEnum : struct, Enum where T : struct
	{
		if (!CorrespondingTypeAttribute.CanGet<TEnum>(typeof(T), out var infoClass))
			throw new ArgumentException("Supplied type parameter is not supported.", nameof(T));
		using var mem = SafeHGlobalHandle.CreateFromStructure<T>();
		var hr = func(firstParam, infoClass, mem, mem.Size, out var len);
		while (hr == (HRESULT)(Win32Error)Win32Error.ERROR_MORE_DATA && mem.Size < 1024 * 32)
		{
			mem.Size = len * 4;
			hr = func(firstParam, infoClass, mem, mem.Size, out len);
		}
		hr.ThrowIfFailed();
		return mem.ToStructure<T>();
	}
}