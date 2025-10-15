using System.Threading;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke;

public static partial class ClfsW32
{
	/// <summary>User defined callback deciphering the format of a log record buffer and dumping its content to the log stream.</summary>
	/// <param name="pstrmOut">
	/// <para>A pointer to an open output stream where the log records are placed.</para>
	/// <para>If this parameter is not specified, "stdout" is used as the default.</para>
	/// </param>
	/// <param name="fRecordType">The type of records to be read.</param>
	/// <param name="pvBuffer">The buffer of content to format.</param>
	/// <param name="cbBuffer">The length of pvBuffer.</param>
	/// <returns>Unknown</returns>
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	public delegate uint CLFS_PRINT_RECORD_ROUTINE([In] HFILE pstrmOut, [In] CLS_RECORD_TYPE fRecordType, [In] IntPtr pvBuffer, [In] uint cbBuffer);

	/// <summary/>
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	public delegate void PCLFS_COMPLETION_ROUTINE([In] IntPtr pvOverlapped, [In, Optional] uint ulReserved);

	/// <summary>
	/// <para>
	/// Adds a container to the physical log that is associated with the log handle—if the calling process has write access to the .blf file
	/// and the ability to create files in the target directory of the container.
	/// </para>
	/// <para>
	/// This function is different from AddLogContainerSet, because it adds only one container. To add multiple containers, it is more
	/// efficient to use <c>AddLogContainerSet</c>, which allows you to add more than one container. Adding containers allows a client to
	/// increase the size of a log.
	/// </para>
	/// </summary>
	/// <param name="hLog">
	/// <para>The handle to an open log.</para>
	/// <para>
	/// The handle must be obtained from CreateLogFile with write access to the log. The client application must have write access to the
	/// .blf file, and the ability to create files in the target directory of a container.
	/// </para>
	/// </param>
	/// <param name="pcbContainer">
	/// <para>The optional parameter that specifies the size of the container, in bytes.</para>
	/// <para>The minimum size is 512 KB for normal logs and 1024 KB for multiplexed logs. The maximum size is approximately 4 gigabytes.</para>
	/// <para>
	/// This parameter is required if the containers are being added to a newly created log. If a container is already created, this
	/// parameter can be <c>NULL</c>, or some value that is at least as large as the size of the first container.
	/// </para>
	/// <para>
	/// Log container sizes are multiples of the log region size (512 KB). When you add a container to a new file, the <c>AddLogContainer</c>
	/// function rounds the size of the container up to the next 512 KB boundary, and returns that size in the value pointed to by <c>pcbContainer</c>.
	/// </para>
	/// <para>
	/// Similarly, if the log already has at least one container and the value of <c>*pcbContainer</c> is at least as large as the current
	/// container size, the function creates all containers with the current internal size and returns that size in <c>*pcbContainer</c>.
	/// </para>
	/// </param>
	/// <param name="pwszContainerPath">
	/// A pointer to a null-terminated string that contains a valid path for the new container on a log volume.
	/// </param>
	/// <param name="pReserved">Reserved. Set <c>pReserved</c> to <c>NULL</c>.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// <para>The following list identifies the possible error codes:</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfsw32/nf-clfsw32-addlogcontainer CLFSUSER_API BOOL AddLogContainer( [in] HANDLE
	// hLog, [in, optional] PULONGLONG pcbContainer, [in] LPWSTR pwszContainerPath, [in, out, optional] LPVOID pReserved );
	[DllImport(Lib_Clfsw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("clfsw32.h", MSDNShortId = "NF:clfsw32.AddLogContainer")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AddLogContainer([In] HLOG hLog, in ulong pcbContainer, [MarshalAs(UnmanagedType.LPWStr)] string pwszContainerPath, [In, Out, Optional] IntPtr pReserved);

	/// <summary>
	/// <para>
	/// Adds a container to the physical log that is associated with the log handle—if the calling process has write access to the .blf file
	/// and the ability to create files in the target directory of the container.
	/// </para>
	/// <para>
	/// This function is different from AddLogContainerSet, because it adds only one container. To add multiple containers, it is more
	/// efficient to use <c>AddLogContainerSet</c>, which allows you to add more than one container. Adding containers allows a client to
	/// increase the size of a log.
	/// </para>
	/// </summary>
	/// <param name="hLog">
	/// <para>The handle to an open log.</para>
	/// <para>
	/// The handle must be obtained from CreateLogFile with write access to the log. The client application must have write access to the
	/// .blf file, and the ability to create files in the target directory of a container.
	/// </para>
	/// </param>
	/// <param name="pcbContainer">
	/// <para>The optional parameter that specifies the size of the container, in bytes.</para>
	/// <para>The minimum size is 512 KB for normal logs and 1024 KB for multiplexed logs. The maximum size is approximately 4 gigabytes.</para>
	/// <para>
	/// This parameter is required if the containers are being added to a newly created log. If a container is already created, this
	/// parameter can be <c>NULL</c>, or some value that is at least as large as the size of the first container.
	/// </para>
	/// <para>
	/// Log container sizes are multiples of the log region size (512 KB). When you add a container to a new file, the <c>AddLogContainer</c>
	/// function rounds the size of the container up to the next 512 KB boundary, and returns that size in the value pointed to by <c>pcbContainer</c>.
	/// </para>
	/// <para>
	/// Similarly, if the log already has at least one container and the value of <c>*pcbContainer</c> is at least as large as the current
	/// container size, the function creates all containers with the current internal size and returns that size in <c>*pcbContainer</c>.
	/// </para>
	/// </param>
	/// <param name="pwszContainerPath">
	/// A pointer to a null-terminated string that contains a valid path for the new container on a log volume.
	/// </param>
	/// <param name="pReserved">Reserved. Set <c>pReserved</c> to <c>NULL</c>.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// <para>The following list identifies the possible error codes:</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfsw32/nf-clfsw32-addlogcontainer CLFSUSER_API BOOL AddLogContainer( [in] HANDLE
	// hLog, [in, optional] PULONGLONG pcbContainer, [in] LPWSTR pwszContainerPath, [in, out, optional] LPVOID pReserved );
	[DllImport(Lib_Clfsw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("clfsw32.h", MSDNShortId = "NF:clfsw32.AddLogContainer")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AddLogContainer([In] HLOG hLog, [In, Optional] IntPtr pcbContainer, [MarshalAs(UnmanagedType.LPWStr)] string pwszContainerPath, [In, Out, Optional] IntPtr pReserved);

	/// <summary>
	/// Adds multiple log containers to the physical log that is associated with the log handle—if the calling process has access to the log
	/// handle. Adding containers allows a client to increase the size of a log.
	/// </summary>
	/// <param name="hLog">
	/// <para>The handle to an open log that is obtained from CreateLogFile with permissions to add a log container.</para>
	/// <para>The file can be dedicated or multiplexed.</para>
	/// </param>
	/// <param name="cContainer">
	/// <para>The number of containers in the <c>rgwszContainerPath</c> array.</para>
	/// <para>This value must be nonzero. A log must have at least two containers before any I/O can be performed on it.</para>
	/// </param>
	/// <param name="pcbContainer">
	/// <para>The size of the container, in bytes.</para>
	/// <para>
	/// The minimum size is 512 KB for normal logs and 1024 KB for multiplexed logs. The maximum size is approximately 4 gigabytes (GB).
	/// </para>
	/// <para>
	/// This parameter is required if the containers are being added to a newly created log. If a container is already created, this
	/// parameter can be <c>NULL</c>, or some value that is at least as large as the size of the first container.
	/// </para>
	/// <para>
	/// Log container sizes are multiples of the log region size (512 KB). When you add a container to a new file, the AddLogContainer
	/// function rounds the size of the container up to the next 512 KB boundary, and returns that size in the value pointed to by <c>pcbContainer</c>.
	/// </para>
	/// <para>
	/// Similarly, if the log already has at least one container and the value of <c>*pcbContainer</c> is at least as large as the current
	/// container size, the function creates all containers with the current internal size and returns that size in <c>*pcbContainer</c>.
	/// </para>
	/// </param>
	/// <param name="rgwszContainerPath">
	/// <para>An array of <c>cContainer</c> path names for containers.</para>
	/// <para>Each element in the array is a wide-character string that contains a valid path for the new container in the log volume.</para>
	/// </param>
	/// <param name="pReserved">Reserved. Set <c>Reserved</c> to <c>NULL</c>.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero, which indicates that all containers are added successfully to the log.</para>
	/// <para>
	/// If the function fails, the return value is zero, which indicates that none of the containers are added. To get extended error
	/// information, call GetLastError.
	/// </para>
	/// <para>The following list identifies the possible error codes:</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>AddLogContainerSet</c> function is not atomic. If the operation is interrupted, for example, by an invalid path name, the call
	/// to <c>AddLogContainerSet</c> returns a failure, but some containers may have been created. Your application must recover from this
	/// error, for example, by determining which containers were added.
	/// </para>
	/// <para>
	/// Because <c>AddLogContainerSet</c> adds more than one container, it is more efficient than making repeated calls to AddLogContainer,
	/// which only adds one container.
	/// </para>
	/// <para>Containers are created and opened in a noncompressed mode, and are initialized with 0 (zeros) when they are created.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfsw32/nf-clfsw32-addlogcontainerset CLFSUSER_API BOOL AddLogContainerSet( [in]
	// HANDLE hLog, [in] USHORT cContainer, [in, optional] PULONGLONG pcbContainer, [in] LPWSTR *rgwszContainerPath, [in, out, optional]
	// LPVOID pReserved );
	[DllImport(Lib_Clfsw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("clfsw32.h", MSDNShortId = "NF:clfsw32.AddLogContainerSet")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AddLogContainerSet([In] HLOG hLog, [In] ushort cContainer, [In, Optional] IntPtr pcbContainer,
		[In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr, SizeParamIndex = 1)] string[] rgwszContainerPath, [In, Out, Optional, Ignore] IntPtr pReserved);

	/// <summary>
	/// Adds multiple log containers to the physical log that is associated with the log handle—if the calling process has access to the log
	/// handle. Adding containers allows a client to increase the size of a log.
	/// </summary>
	/// <param name="hLog">
	/// <para>The handle to an open log that is obtained from CreateLogFile with permissions to add a log container.</para>
	/// <para>The file can be dedicated or multiplexed.</para>
	/// </param>
	/// <param name="cContainer">
	/// <para>The number of containers in the <c>rgwszContainerPath</c> array.</para>
	/// <para>This value must be nonzero. A log must have at least two containers before any I/O can be performed on it.</para>
	/// </param>
	/// <param name="pcbContainer">
	/// <para>The size of the container, in bytes.</para>
	/// <para>
	/// The minimum size is 512 KB for normal logs and 1024 KB for multiplexed logs. The maximum size is approximately 4 gigabytes (GB).
	/// </para>
	/// <para>
	/// This parameter is required if the containers are being added to a newly created log. If a container is already created, this
	/// parameter can be <c>NULL</c>, or some value that is at least as large as the size of the first container.
	/// </para>
	/// <para>
	/// Log container sizes are multiples of the log region size (512 KB). When you add a container to a new file, the AddLogContainer
	/// function rounds the size of the container up to the next 512 KB boundary, and returns that size in the value pointed to by <c>pcbContainer</c>.
	/// </para>
	/// <para>
	/// Similarly, if the log already has at least one container and the value of <c>*pcbContainer</c> is at least as large as the current
	/// container size, the function creates all containers with the current internal size and returns that size in <c>*pcbContainer</c>.
	/// </para>
	/// </param>
	/// <param name="rgwszContainerPath">
	/// <para>An array of <c>cContainer</c> path names for containers.</para>
	/// <para>Each element in the array is a wide-character string that contains a valid path for the new container in the log volume.</para>
	/// </param>
	/// <param name="pReserved">Reserved. Set <c>Reserved</c> to <c>NULL</c>.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero, which indicates that all containers are added successfully to the log.</para>
	/// <para>
	/// If the function fails, the return value is zero, which indicates that none of the containers are added. To get extended error
	/// information, call GetLastError.
	/// </para>
	/// <para>The following list identifies the possible error codes:</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>AddLogContainerSet</c> function is not atomic. If the operation is interrupted, for example, by an invalid path name, the call
	/// to <c>AddLogContainerSet</c> returns a failure, but some containers may have been created. Your application must recover from this
	/// error, for example, by determining which containers were added.
	/// </para>
	/// <para>
	/// Because <c>AddLogContainerSet</c> adds more than one container, it is more efficient than making repeated calls to AddLogContainer,
	/// which only adds one container.
	/// </para>
	/// <para>Containers are created and opened in a noncompressed mode, and are initialized with 0 (zeros) when they are created.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfsw32/nf-clfsw32-addlogcontainerset CLFSUSER_API BOOL AddLogContainerSet( [in]
	// HANDLE hLog, [in] USHORT cContainer, [in, optional] PULONGLONG pcbContainer, [in] LPWSTR *rgwszContainerPath, [in, out, optional]
	// LPVOID pReserved );
	[DllImport(Lib_Clfsw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("clfsw32.h", MSDNShortId = "NF:clfsw32.AddLogContainerSet")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AddLogContainerSet([In] HLOG hLog, [In] ushort cContainer, in ulong pcbContainer,
		[In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr, SizeParamIndex = 1)] string[] rgwszContainerPath, [In, Out, Optional, Ignore] IntPtr pReserved);

	/// <summary>Advances the base log sequence number (LSN) of a log stream to the specified LSN.</summary>
	/// <param name="pvMarshal">A pointer to the marshaling context that a successful call to CreateLogMarshallingArea returns.</param>
	/// <param name="plsnBase">
	/// <para>The new base LSN for the log that is specified in <c>pvMarshal</c>.</para>
	/// <para>This LSN must be in the range between the current base LSN and the last LSN of the log, inclusively.</para>
	/// </param>
	/// <param name="fFlags">This parameter is not implemented at this time, and must be zero.</param>
	/// <param name="pOverlapped">
	/// <para>A pointer to an OVERLAPPED structure that is required for asynchronous operation.</para>
	/// <para>If asynchronous operation is not used, this parameter can be <c>NULL</c>.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// <para>The following list identifies the possible error codes:</para>
	/// </returns>
	/// <remarks><c>AdvanceLogBase</c> might flush data and metadata when it is called.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfsw32/nf-clfsw32-advancelogbase CLFSUSER_API BOOL AdvanceLogBase( [in, out] PVOID
	// pvMarshal, [in] PCLFS_LSN plsnBase, [in] ULONG fFlags, [in, out, optional] LPOVERLAPPED pOverlapped );
	[DllImport(Lib_Clfsw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("clfsw32.h", MSDNShortId = "NF:clfsw32.AdvanceLogBase")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AdvanceLogBase([In, Out] IntPtr pvMarshal, in CLS_LSN plsnBase, [In, Optional] uint fFlags,
		ref NativeOverlapped pOverlapped);

	/// <summary>Advances the base log sequence number (LSN) of a log stream to the specified LSN.</summary>
	/// <param name="pvMarshal">A pointer to the marshaling context that a successful call to CreateLogMarshallingArea returns.</param>
	/// <param name="plsnBase">
	/// <para>The new base LSN for the log that is specified in <c>pvMarshal</c>.</para>
	/// <para>This LSN must be in the range between the current base LSN and the last LSN of the log, inclusively.</para>
	/// </param>
	/// <param name="fFlags">This parameter is not implemented at this time, and must be zero.</param>
	/// <param name="pOverlapped">
	/// <para>A pointer to an OVERLAPPED structure that is required for asynchronous operation.</para>
	/// <para>If asynchronous operation is not used, this parameter can be <c>NULL</c>.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// <para>The following list identifies the possible error codes:</para>
	/// </returns>
	/// <remarks><c>AdvanceLogBase</c> might flush data and metadata when it is called.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfsw32/nf-clfsw32-advancelogbase CLFSUSER_API BOOL AdvanceLogBase( [in, out] PVOID
	// pvMarshal, [in] PCLFS_LSN plsnBase, [in] ULONG fFlags, [in, out, optional] LPOVERLAPPED pOverlapped );
	[DllImport(Lib_Clfsw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("clfsw32.h", MSDNShortId = "NF:clfsw32.AdvanceLogBase")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AdvanceLogBase([In, Out] IntPtr pvMarshal, in CLS_LSN plsnBase, [In, Optional] uint fFlags,
		[In, Optional] IntPtr pOverlapped);

	/// <summary>
	/// Calculates the sector-aligned reservation size for a set of reserved records. This value is then passed to AllocReservedLog to
	/// reserve a block of log space for a set of records.
	/// </summary>
	/// <param name="pvMarshal">A pointer to the opaque marshaling context that is allocated by calling the CreateLogMarshallingArea function.</param>
	/// <param name="cReservedRecords">The number of reserved records that are associated with the reservation adjustment.</param>
	/// <param name="rgcbReservation">
	/// <para>An array of space allocations to reserve in the log that is associated with the current marshaling context, in bytes.</para>
	/// <para>
	/// The number of allocations corresponds to the number of records that <c>cReservedRecords</c> specifies. Each allocation must be
	/// greater than zero (0) or the function fails with <c>ERROR_INVALID_PARAMETER</c>.
	/// </para>
	/// </param>
	/// <param name="pcbAlignReservation">
	/// <para>
	/// A pointer to a variable in which the function returns the number of sector-aligned byte space to be reserved in the log—after being
	/// given the number of records that <c>cRecords</c> specifies and the size of reservations specified in the <c>rgcbReservation</c> array.
	/// </para>
	/// <para>
	/// The value returned in <c>*pcbAlignReservation</c> is used as input to AllocReservedLog. If <c>AllocReservedLog</c> succeeds, this
	/// value is always greater than zero (0). If <c>AllocReservedLog</c> fails, the value is zero (0).
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>
	/// If the function fails, the return value is zero (0). To get extended error information, call GetLastError. The following list
	/// identifies the possible error codes:
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfsw32/nf-clfsw32-alignreservedlog CLFSUSER_API BOOL AlignReservedLog( [in, out]
	// PVOID pvMarshal, [in] ULONG cReservedRecords, [in] LONGLONG [] rgcbReservation, [out] PLONGLONG pcbAlignReservation );
	[DllImport(Lib_Clfsw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("clfsw32.h", MSDNShortId = "NF:clfsw32.AlignReservedLog")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AlignReservedLog([In, Out] IntPtr pvMarshal, [In] uint cReservedRecords,
		[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] long[] rgcbReservation, out long pcbAlignReservation);

	/// <summary>
	/// Allocates sector-aligned space for a set of reserved records. The requested allocation must be the same size that AlignReservedLog returns.
	/// </summary>
	/// <param name="pvMarshal">A pointer to the marshaling context that is allocated by calling the CreateLogMarshallingArea function.</param>
	/// <param name="cReservedRecords">
	/// <para>The number of reserved records that are associated with the reservation adjustment.</para>
	/// <para>This value must be greater than zero (0).</para>
	/// </param>
	/// <param name="pcbAdjustment">
	/// <para>
	/// The size of the sector-aligned space reservation that is associated with the number of records specified in <c>cReservedRecords</c>,
	/// in bytes.
	/// </para>
	/// <para>This parameter must be the aligned reservation size that AlignReservedLog returns in <c>*pcbAlignReservation</c>.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>
	/// If the function fails, the return value is zero (0). To get extended error information, call GetLastError. The following list
	/// identifies the possible error codes:
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfsw32/nf-clfsw32-allocreservedlog CLFSUSER_API BOOL AllocReservedLog( [in, out]
	// PVOID pvMarshal, [in] ULONG cReservedRecords, [in, out] PLONGLONG pcbAdjustment );
	[DllImport(Lib_Clfsw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("clfsw32.h", MSDNShortId = "NF:clfsw32.AllocReservedLog")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool AllocReservedLog([In, Out] IntPtr pvMarshal, [In] uint cReservedRecords,
		[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] long[] pcbAdjustment);

	/// <summary>
	/// Resets the log file and then shuts the log. This nullifies any client restart areas and resets the base log sequence number (LSN) for
	/// the log. You do not need to close a log stream handle after calling this function.
	/// </summary>
	/// <param name="hLog">
	/// <para>A handle to a dedicated or multiplexed log.</para>
	/// <para>
	/// This handle is returned by a successful call to CreateLogFile. It is invalidated on successful completion of the call. No other
	/// operations that use this handle, or a derivative of this handle, can be called after this function has returned.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>
	/// If the function fails, the return value is zero (0). To get extended error information, call GetLastError. The following list
	/// identifies the possible error codes:
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfsw32/nf-clfsw32-closeandresetlogfile CLFSUSER_API BOOL CloseAndResetLogFile(
	// [in] HANDLE hLog );
	[DllImport(Lib_Clfsw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("clfsw32.h", MSDNShortId = "NF:clfsw32.CloseAndResetLogFile")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CloseAndResetLogFile([In] HLOG hLog);

	/// <summary>
	/// Creates a scan context to use with ScanLogContainers to enumerate all log containers that are associated with a log, and performs the
	/// first scan.
	/// </summary>
	/// <param name="hLog">
	/// <para>A handle to the log that is obtained from CreateLogFile with permissions to scan the log containers.</para>
	/// <para>The file can be a dedicated or multiplexed log.</para>
	/// </param>
	/// <param name="cFromContainer">
	/// <para>The container where the scan is to be started.</para>
	/// <para>This parameter is an ordinal number relative to the number of containers in the log.</para>
	/// </param>
	/// <param name="cContainers">
	/// <para>The number of CLFS_CONTAINER_INFORMATION structures for <c>CreateLogContainerScanContext</c> to allocate.</para>
	/// <para>
	/// This number is the number of containers scanned with each scan call so the caller knows the scan is complete when the number of
	/// containers returned is less than this value.
	/// </para>
	/// <para>
	/// On exit, a pointer to the system-allocated array of CLFS_CONTAINER_INFORMATION structures is placed in the <c>pinfoContainer</c>
	/// member of the client-allocated CLFS_SCAN_CONTEXT structure. This member is pointed to by the <c>pcxScan</c> parameter (that is,
	/// "pcxScan-&gt;pinfoContainer[]"), and the actual number of structures in the array is placed in "pcxScan-&gt;cContainersReturned".
	/// </para>
	/// <para>
	/// The client must call ScanLogContainers with the <c>eScanMode</c> parameter set to <c>CLFS_SCAN_CLOSE</c> so that it can free this
	/// array; otherwise, memory leaks result.
	/// </para>
	/// </param>
	/// <param name="eScanMode">
	/// <para>The mode to scan containers.</para>
	/// <para>Containers can be scanned in any one of the following modes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>CLFS_SCAN_INIT</c></term>
	/// <term>
	/// Initializes or reinitializes a scan from the first container in the container list. This mode initializes the container context and
	/// returns the first set of container descriptors that <c>cContainers</c> specifies.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>CLFS_SCAN_FORWARD</c></term>
	/// <term>Returns the first set of containers that <c>cContainers</c> specifies.</term>
	/// </item>
	/// <item>
	/// <term><c>CLFS_SCAN_BACKWARD</c></term>
	/// <term>Returns the last set of containers that <c>cContainers</c> specifies.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pcxScan">
	/// A pointer to a client-allocated CLFS_SCAN_CONTEXT structure that receives a scan context that can be passed to the ScanLogContainers
	/// function when a client scans the log containers of a dedicated log.
	/// </param>
	/// <param name="pOverlapped">
	/// <para>A pointer to an OVERLAPPED structure that is required for asynchronous operation.</para>
	/// <para>This parameter can be <c>NULL</c> if an asynchronous operation is not used.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// <para>The following list identifies the possible error codes:</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// After completing a scan, the client must call ScanLogContainers again with the <c>eScanMode</c> parameter set to
	/// <c>CLFS_SCAN_CLOSE</c> so that it can free the system-allocated array of CLFS_CONTAINER_INFORMATION structures; otherwise, memory
	/// leaks result.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example that uses this function, see Enumerating Log Containers.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfsw32/nf-clfsw32-createlogcontainerscancontext CLFSUSER_API BOOL
	// CreateLogContainerScanContext( [in] HANDLE hLog, [in] ULONG cFromContainer, [in] ULONG cContainers, [in] CLFS_SCAN_MODE eScanMode,
	// [in, out] PCLFS_SCAN_CONTEXT pcxScan, [in, out, optional] LPOVERLAPPED pOverlapped );
	[DllImport(Lib_Clfsw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("clfsw32.h", MSDNShortId = "NF:clfsw32.CreateLogContainerScanContext")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CreateLogContainerScanContext([In] HLOG hLog, [In] uint cFromContainer, [In] uint cContainers,
		[In] CLFS_SCAN_MODE eScanMode, ref CLS_SCAN_CONTEXT pcxScan, ref NativeOverlapped pOverlapped);

	/// <summary>
	/// Creates a scan context to use with ScanLogContainers to enumerate all log containers that are associated with a log, and performs the
	/// first scan.
	/// </summary>
	/// <param name="hLog">
	/// <para>A handle to the log that is obtained from CreateLogFile with permissions to scan the log containers.</para>
	/// <para>The file can be a dedicated or multiplexed log.</para>
	/// </param>
	/// <param name="cFromContainer">
	/// <para>The container where the scan is to be started.</para>
	/// <para>This parameter is an ordinal number relative to the number of containers in the log.</para>
	/// </param>
	/// <param name="cContainers">
	/// <para>The number of CLFS_CONTAINER_INFORMATION structures for <c>CreateLogContainerScanContext</c> to allocate.</para>
	/// <para>
	/// This number is the number of containers scanned with each scan call so the caller knows the scan is complete when the number of
	/// containers returned is less than this value.
	/// </para>
	/// <para>
	/// On exit, a pointer to the system-allocated array of CLFS_CONTAINER_INFORMATION structures is placed in the <c>pinfoContainer</c>
	/// member of the client-allocated CLFS_SCAN_CONTEXT structure. This member is pointed to by the <c>pcxScan</c> parameter (that is,
	/// "pcxScan-&gt;pinfoContainer[]"), and the actual number of structures in the array is placed in "pcxScan-&gt;cContainersReturned".
	/// </para>
	/// <para>
	/// The client must call ScanLogContainers with the <c>eScanMode</c> parameter set to <c>CLFS_SCAN_CLOSE</c> so that it can free this
	/// array; otherwise, memory leaks result.
	/// </para>
	/// </param>
	/// <param name="eScanMode">
	/// <para>The mode to scan containers.</para>
	/// <para>Containers can be scanned in any one of the following modes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>CLFS_SCAN_INIT</c></term>
	/// <term>
	/// Initializes or reinitializes a scan from the first container in the container list. This mode initializes the container context and
	/// returns the first set of container descriptors that <c>cContainers</c> specifies.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>CLFS_SCAN_FORWARD</c></term>
	/// <term>Returns the first set of containers that <c>cContainers</c> specifies.</term>
	/// </item>
	/// <item>
	/// <term><c>CLFS_SCAN_BACKWARD</c></term>
	/// <term>Returns the last set of containers that <c>cContainers</c> specifies.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pcxScan">
	/// A pointer to a client-allocated CLFS_SCAN_CONTEXT structure that receives a scan context that can be passed to the ScanLogContainers
	/// function when a client scans the log containers of a dedicated log.
	/// </param>
	/// <param name="pOverlapped">
	/// <para>A pointer to an OVERLAPPED structure that is required for asynchronous operation.</para>
	/// <para>This parameter can be <c>NULL</c> if an asynchronous operation is not used.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// <para>The following list identifies the possible error codes:</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// After completing a scan, the client must call ScanLogContainers again with the <c>eScanMode</c> parameter set to
	/// <c>CLFS_SCAN_CLOSE</c> so that it can free the system-allocated array of CLFS_CONTAINER_INFORMATION structures; otherwise, memory
	/// leaks result.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example that uses this function, see Enumerating Log Containers.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfsw32/nf-clfsw32-createlogcontainerscancontext CLFSUSER_API BOOL
	// CreateLogContainerScanContext( [in] HANDLE hLog, [in] ULONG cFromContainer, [in] ULONG cContainers, [in] CLFS_SCAN_MODE eScanMode,
	// [in, out] PCLFS_SCAN_CONTEXT pcxScan, [in, out, optional] LPOVERLAPPED pOverlapped );
	[DllImport(Lib_Clfsw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("clfsw32.h", MSDNShortId = "NF:clfsw32.CreateLogContainerScanContext")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CreateLogContainerScanContext([In] HLOG hLog, [In] uint cFromContainer, [In] uint cContainers,
		[In] CLFS_SCAN_MODE eScanMode, ref CLS_SCAN_CONTEXT pcxScan, [In, Optional] IntPtr pOverlapped);

	/// <summary>
	/// Creates or opens a log. The log can be dedicated or multiplexed, and that depends on the log name. Use the CloseHandle function to
	/// close the log.
	/// </summary>
	/// <param name="pszLogFileName">
	/// <para>The name of the log.</para>
	/// <para>
	/// This name is specified when creating the log by using <c>CreateLogFile</c>. The following example identifies the format to use.
	/// </para>
	/// <para><c>log :&lt;</c><c>LogName</c><c>&gt;[::&lt;</c><c>LogStreamName</c><c>&gt;]</c></para>
	/// <para>
	/// For example: The path "LOG:c:\MyDirectory\MyLog" creates the file "c:\MyDirectory\MyLog.blf". The path
	/// "??\LOG:\HarddiskVolume1\MyDirectory\MyLog" creates the file "\.\HarddiskVolume1\MyDirectory\MyLog.blf", as does the path "\clfs\Device\HarddiskVolume1\MyDirectory\MyLog".
	/// </para>
	/// <para>
	/// &lt; <c>LogName</c>&gt; corresponds to a valid file path in the file system, and &lt; <c>LogStreamName</c>&gt; is the unique name of
	/// a log stream in the log. For more information, see Log Types.
	/// </para>
	/// </param>
	/// <param name="fDesiredAccess">
	/// <para>The type of access that the returned handle has to the log object.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>GENERIC_READ</c></term>
	/// <term>Specifies read access to the object.</term>
	/// </item>
	/// <item>
	/// <term><c>GENERIC_WRITE</c></term>
	/// <term>Specifies write access to the object.</term>
	/// </item>
	/// <item>
	/// <term><c>DELETE</c></term>
	/// <term>Specify log deletion access</term>
	/// </item>
	/// </list>
	/// <para>A bitwise <c>OR</c> of two or more of these flags allows combinations of read, write, and delete access to the object.</para>
	/// <para>Windows Server 2003 R2:</para>
	/// <para>This parameter must be set to</para>
	/// <para>GENERIC_WRITE</para>
	/// <para>.</para>
	/// </param>
	/// <param name="dwShareMode">
	/// <para>The sharing mode of a file.</para>
	/// <para>
	/// A client cannot request a sharing mode that conflicts with any mode that is specified in any previous open request that has an open handle.
	/// </para>
	/// <para>
	/// If this parameter is zero and the function succeeds, the object cannot be shared and cannot be opened again until the handle is closed.
	/// </para>
	/// <para>This parameter can be one or more of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>FILE_SHARE_DELETE</c></term>
	/// <term>
	/// Enables open operations on the object to request delete access. Without this value, other processes cannot open the object if delete
	/// access is requested.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>FILE_SHARE_READ</c></term>
	/// <term>
	/// Enables open operations on the object to request read access. Without this value, other processes cannot open the object if read
	/// access is requested.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>FILE_SHARE_WRITE</c></term>
	/// <term>
	/// Enables open operations on the object to request write access. Without this value, other processes cannot open the object if write
	/// access is requested.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="psaLogFile">
	/// <para>A pointer to a SECURITY_ATTRIBUTES structure that specifies the security attributes of a log.</para>
	/// <para>
	/// It determines whether the returned handle can be inherited by child processes. If this parameter is <c>NULL</c>, the handle cannot be inherited.
	/// </para>
	/// <para>
	/// The <c>lpSecurityDescriptor</c> member of SECURITY_ATTRIBUTES specifies a security descriptor for the new log handle. If
	/// <c>psaLogFile</c> is <c>NULL</c>, the object gets a default security descriptor. The access control lists (ACL) in the default
	/// security descriptor for a log come from the primary or impersonation token of the creator.
	/// </para>
	/// </param>
	/// <param name="fCreateDisposition">
	/// <para>An action to be taken.</para>
	/// <para>This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>CREATE_NEW</c></term>
	/// <term>Creates a new file and fails if the file already exists.</term>
	/// </item>
	/// <item>
	/// <term><c>OPEN_EXISTING</c></term>
	/// <term>Opens an existing file and fails if the file does not exist.</term>
	/// </item>
	/// <item>
	/// <term><c>OPEN_ALWAYS</c></term>
	/// <term>Opens an existing file or creates the file if it does not exist.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="fFlagsAndAttributes">
	/// <para>The file attributes and flags for the file.</para>
	/// <para>This parameter can take the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>FILE_ATTRIBUTE_ARCHIVE</c></term>
	/// <term>
	/// This non-ephemeral log should be archived. If this flag is not supplied, the log does not need to be archived, and an archival tail
	/// is not maintained for recycling log containers.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>FILE_FLAG_OVERLAPPED</c></term>
	/// <term>
	/// If the <c>FILE_FLAG_OVERLAPPED</c> flag is set, all other flag values are ignored. Specifying <c>FILE_FLAG_OVERLAPPED</c> means that
	/// a file is opened for overlapped I/O, which enables more than one I/O operation to be performed on the log handle. If this flag is set
	/// when creating a log, all asynchronous I/O calls to that log must specify an overlapped structure and synchronize with the deferred
	/// completion of the call.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a handle to the log.</para>
	/// <para>If the function fails, the return value is <c>INVALID_HANDLE_VALUE</c>. To get extended error information, call GetLastError.</para>
	/// <para>The following list identifies the possible error codes:</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfsw32/nf-clfsw32-createlogfile CLFSUSER_API HANDLE CreateLogFile( [in] LPCWSTR
	// pszLogFileName, [in] ACCESS_MASK fDesiredAccess, [in] DWORD dwShareMode, [in, optional] LPSECURITY_ATTRIBUTES psaLogFile, [in] ULONG
	// fCreateDisposition, [in] ULONG fFlagsAndAttributes );
	[DllImport(Lib_Clfsw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("clfsw32.h", MSDNShortId = "NF:clfsw32.CreateLogFile")]
	public static extern SafeHLOG CreateLogFile([MarshalAs(UnmanagedType.LPWStr)] string pszLogFileName, [In] ACCESS_MASK fDesiredAccess,
		[In] System.IO.FileShare dwShareMode, [In, Optional] SECURITY_ATTRIBUTES? psaLogFile, [In] CreationOption fCreateDisposition,
		[In] FileFlagsAndAttributes fFlagsAndAttributes);

	/// <summary>
	/// <para>
	/// Creates a marshaling area for a log, and when successful it returns a marshaling context. Before creating a marshaling area, the log
	/// must have at least one container.
	/// </para>
	/// <para>
	/// The marshaling context is used to append records to or read records from a log. Because records are always stored in log blocks, they
	/// must pass through the marshaling context.
	/// </para>
	/// <para>Log records are written by calling ReserveAndAppendLog.</para>
	/// </summary>
	/// <param name="hLog">
	/// <para>A handle to the log that is obtained from CreateLogFile.</para>
	/// <para>The log handle can refer to a dedicated or multiplexed log.</para>
	/// </param>
	/// <param name="pfnAllocBuffer">
	/// <para>The callback function that allocates memory for log blocks.</para>
	/// <para>
	/// If this parameter is <c>NULL</c>, the Common Log File System (CLFS) provides a default block allocation function. This parameter
	/// cannot be <c>NULL</c> if a block-freeing callback is specified by using the <c>pfnFreeBuffer</c> parameter.
	/// </para>
	/// <para>The following example identifies the syntax of the block allocation callback function:</para>
	/// </param>
	/// <param name="pfnFreeBuffer">
	/// <para>The callback function that frees log blocks allocated by <c>pfnAllocBuffer</c>.</para>
	/// <para>
	/// If this parameter is <c>NULL</c>, CLFS provides a default block deallocation function. This parameter cannot be <c>NULL</c> if a
	/// block allocation callback is specified by using the <c>pfnAllocBuffer</c> parameter.
	/// </para>
	/// <para>The following example identifies the syntax of the block-freeing callback function:</para>
	/// </param>
	/// <param name="pvBlockAllocContext">
	/// <para>
	/// A pointer to a buffer that is passed back as a user context to the block allocation and deallocation routines, if a buffer is specified.
	/// </para>
	/// <para>If <c>pfnAllocBuffer</c> is <c>NULL</c>, this parameter is ignored.</para>
	/// </param>
	/// <param name="cbMarshallingBuffer">
	/// <para>
	/// The size, in bytes, of the individual log I/O blocks that will be used by the new marshaling area. This must be a multiple of the
	/// sector size on the stable storage medium. The sector size is the value returned in the <c>lpBytesPerSector</c> parameter of the
	/// GetDiskFreeSpace function.
	/// </para>
	/// <para>Records cannot be appended or read if they are longer than this value.</para>
	/// </param>
	/// <param name="cMaxWriteBuffers">
	/// <para>The maximum number of blocks that can be allocated at any time for write operations.</para>
	/// <para>
	/// This value can affect the frequency of data flushes. If you do not need to specify a limit to control the frequency of the data flush
	/// cycle, specify INFINITE.
	/// </para>
	/// </param>
	/// <param name="cMaxReadBuffers">
	/// <para>The maximum number of blocks that can be allocated at any time for read operations.</para>
	/// <para>Read contexts use at least one read block.</para>
	/// </param>
	/// <param name="ppvMarshal">
	/// <para>A pointer to the marshaling context that CLFS allocates when <c>CreateLogMarshallingArea</c> completes successfully.</para>
	/// <para>
	/// This context must be used with all read, append, write, and flush operations to log marshaling areas. All operations that access
	/// marshaling areas by using a marshaling context are thread-safe. This parameter is <c>NULL</c> if the operation is not successful.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// <para>The following list identifies the possible error codes:</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfsw32/nf-clfsw32-createlogmarshallingarea CLFSUSER_API BOOL
	// CreateLogMarshallingArea( [in] HANDLE hLog, [in, optional] CLFS_BLOCK_ALLOCATION pfnAllocBuffer, [in, optional]
	// CLFS_BLOCK_DEALLOCATION pfnFreeBuffer, [in, optional] PVOID pvBlockAllocContext, [in] ULONG cbMarshallingBuffer, [in] ULONG
	// cMaxWriteBuffers, [in] ULONG cMaxReadBuffers, [out] PVOID *ppvMarshal );
	[DllImport(Lib_Clfsw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("clfsw32.h", MSDNShortId = "NF:clfsw32.CreateLogMarshallingArea")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CreateLogMarshallingArea([In] HLOG hLog, [In, Optional] CLFS_BLOCK_ALLOCATION? pfnAllocBuffer,
		[In, Optional] CLFS_BLOCK_DEALLOCATION? pfnFreeBuffer, [In, Optional] IntPtr pvBlockAllocContext, [In] uint cbMarshallingBuffer,
		[In] uint cMaxWriteBuffers, [In] uint cMaxReadBuffers, out IntPtr ppvMarshal);

	/// <summary>
	/// <para>
	/// Marks the specified log for deletion. The log is actually deleted when all handles, marshaling areas, and read contexts to the log
	/// are closed. If the log is a physical log, its underlying containers are deleted.
	/// </para>
	/// <para>When a log is marked for deletion, requests to open new client log streams fail.</para>
	/// <para>
	/// <c>Note</c> This function differs from DeleteLogFile, because it takes a valid open handle to the log object instead of the log name.
	/// </para>
	/// </summary>
	/// <param name="hLog">
	/// A handle to an open log that is obtained by a successful call to CreateLogFile. The log must have been created with DELETE access or
	/// you cannot delete the log.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>
	/// If the function fails, the return value is zero (0). To get extended error information, call GetLastError. The following list
	/// identifies the possible error codes:
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfsw32/nf-clfsw32-deletelogbyhandle CLFSUSER_API BOOL DeleteLogByHandle( [in]
	// HANDLE hLog );
	[DllImport(Lib_Clfsw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("clfsw32.h", MSDNShortId = "NF:clfsw32.DeleteLogByHandle")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DeleteLogByHandle([In] HLOG hLog);

	/// <summary>
	/// <para>
	/// Marks a log for deletion. The log is actually deleted when all handles, marshaling areas, and read contexts to the log are closed. If
	/// the log is a physical log, its underlying containers are deleted.
	/// </para>
	/// <para>When a log is marked for deletion, requests to open new client log streams fail.</para>
	/// </summary>
	/// <param name="pszLogFileName">
	/// <para>The name of the log.</para>
	/// <para>This name is specified when creating the log by using CreateLogFile. The following example identifies the format to use:</para>
	/// <para><c>log:&lt;</c><c>log name</c><c>&gt;[::&lt;</c><c>log stream name</c><c>&gt;]</c></para>
	/// <para>&lt; <c>log name</c>&gt; corresponds to a valid file path in the file system.</para>
	/// <para>&lt; <c>log stream name</c>&gt; is the unique name of a log stream in the log.</para>
	/// <para>For more information, see Log Types.</para>
	/// </param>
	/// <param name="pvReserved">This parameter is reserved and should be set to <c>NULL</c>.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>
	/// If the function fails, the return value is zero (0). To get extended error information, call GetLastError. The following list
	/// identifies the possible error codes:
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfsw32/nf-clfsw32-deletelogfile CLFSUSER_API BOOL DeleteLogFile( [in] LPCWSTR
	// pszLogFileName, [in, optional] PVOID pvReserved );
	[DllImport(Lib_Clfsw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("clfsw32.h", MSDNShortId = "NF:clfsw32.DeleteLogFile")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DeleteLogFile([MarshalAs(UnmanagedType.LPWStr)] string pszLogFileName, [In, Optional] IntPtr pvReserved);

	/// <summary>
	/// <para>Deletes a marshaling area that is created by a successful call to CreateLogMarshallingArea.</para>
	/// <para>When you delete a marshaling area it does the following:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>Flushes the log to free pending log I/O blocks</term>
	/// </item>
	/// <item>
	/// <term>Deallocates all log I/O blocks and invalidates all read contexts</term>
	/// </item>
	/// </list>
	/// <para>
	/// The memory allocated by Common Log File System (CLFS) to create the marshaling context is reclaimed when all read contexts are terminated.
	/// </para>
	/// <para><c>Note</c> Clients should not delete a marshaling area if there are pending operations on the marshaling area.</para>
	/// </summary>
	/// <param name="pvMarshal">A pointer to the opaque marshaling context allocated by using the CreateLogMarshallingArea function.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>
	/// If the function fails, the return value is zero (0). To get extended error information, call GetLastError. The following list
	/// identifies the possible error codes:
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfsw32/nf-clfsw32-deletelogmarshallingarea CLFSUSER_API BOOL
	// DeleteLogMarshallingArea( [in] PVOID pvMarshal );
	[DllImport(Lib_Clfsw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("clfsw32.h", MSDNShortId = "NF:clfsw32.DeleteLogMarshallingArea")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DeleteLogMarshallingArea([In] IntPtr pvMarshal);

	/// <summary>
	/// Scans a specified log; filters log records based on record type; and places the records in an output file stream that the caller opens.
	/// </summary>
	/// <param name="pwszLogFileName">
	/// <para>The name of the log stream.</para>
	/// <para>This name is specified when you create the log by using CreateLogFile. The following example identifies the format to use:</para>
	/// <para><c>log:&lt;</c><c>log name</c><c>&gt;[::&lt;</c><c>log stream name</c><c>&gt;]</c></para>
	/// <para>&lt; <c>log name</c>&gt; corresponds to a valid file path in the file system.</para>
	/// <para>&lt; <c>log stream name</c>&gt; is the unique name of a log stream in the log.</para>
	/// <para>For more information, see Log Types.</para>
	/// </param>
	/// <param name="fRecordType">
	/// <para>The type of records to be read.</para>
	/// <para>This parameter can be one or more of the following CLFS_RECORD_TYPE Constants.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>ClfsNullRecord</c></term>
	/// <term>The default record type of <c>ClfsDataRecord</c> is used.</term>
	/// </item>
	/// <item>
	/// <term><c>ClfsDataRecord</c></term>
	/// <term>User data records are read.</term>
	/// </item>
	/// <item>
	/// <term><c>ClfsRestartRecord</c></term>
	/// <term>Restart records are read.</term>
	/// </item>
	/// <item>
	/// <term><c>ClfsClientRecord</c></term>
	/// <term>Both restart and data records are read.</term>
	/// </item>
	/// <item>
	/// <term><c>ClfsClientRecord</c></term>
	/// <term>Specifies a mask for all valid data or restart records.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="plsnStart">
	/// <para>A pointer to a CLFS_LSN that specifies the starting log sequence number (LSN) for the log dump sequence.</para>
	/// <para>
	/// If this parameter is specified, the LSN must be the address of a valid log record in the active part of the log; otherwise, the call
	/// fails with status <c>ERROR_INVALID_PARAMETER</c>.
	/// </para>
	/// <para>If this parameter is not specified, the start of the dump sequence is the beginning of the active log.</para>
	/// </param>
	/// <param name="plsnEnd">
	/// <para>A pointer to a CLFS_LSN that specifies the LSN where the dump sequence should end.</para>
	/// <para>If this LSN is past the end of the LSN range, the function returns <c>ERROR_HANDLE_EOF</c>.</para>
	/// <para>
	/// Unlike <c>plsnStart</c>, this value does not have to be the LSN of a valid record in the active log, but can be any valid LSN. Only
	/// records with an LSN value less than or equal to <c>plsnEnd</c> are placed in the output stream.
	/// </para>
	/// <para>If this parameter is <c>NULL</c>, the dump function uses the last LSN in the active log (at the head of the log).</para>
	/// </param>
	/// <param name="pstrmOut">
	/// <para>A pointer to an open output stream where the log records are placed.</para>
	/// <para>If this parameter is not specified, "stdout" is used as the default.</para>
	/// </param>
	/// <param name="pfnPrintRecord">
	/// <para>A user-defined callback routine that formats user-defined buffers and prints them to the output stream <c>pstrmOut</c>.</para>
	/// <para>
	/// The <c>DumpLogRecords</c> function natively outputs its internal record headers to <c>pstrmOut</c>, but depends on the user-defined
	/// callback to format the user buffers.
	/// </para>
	/// <para>If this parameter is <c>NULL</c>, <c>DumpLogRecords</c> places user record data in the output stream as hexadecimal digits.</para>
	/// </param>
	/// <param name="pfnAllocBlock">
	/// <para>A callback function that allocates memory for log blocks.</para>
	/// <para>
	/// If this parameter is <c>NULL</c>, Common Log File System (CLFS) provides a default block allocation function. This parameter cannot
	/// be <c>NULL</c> if a block-freeing callback is specified by using the <c>pfnFreeBuffer</c> parameter.
	/// </para>
	/// <para>The following example identifies the syntax of the block allocation callback function:</para>
	/// </param>
	/// <param name="pfnFreeBlock">
	/// <para>A callback function that frees log blocks allocated by <c>pfnAllocBuffer</c>.</para>
	/// <para>
	/// If this parameter is <c>NULL</c>, CLFS provides a default block deallocation function. This parameter cannot be <c>NULL</c> if a
	/// block allocation callback is specified by using the <c>pfnAllocBuffer</c> parameter.
	/// </para>
	/// <para>The following example identifies the syntax of the block-freeing callback function:</para>
	/// </param>
	/// <param name="pvBlockAllocContext">
	/// <para>A pointer to a buffer that is passed as a user context to the block allocation and deallocation routines, if a buffer is specified.</para>
	/// <para>If <c>pfnAllocBuffer</c> is <c>NULL</c>, this parameter is ignored.</para>
	/// </param>
	/// <param name="cbBlock">
	/// <para>The size of the buffer that your records are marshaled into, in bytes.</para>
	/// <para>Records cannot be appended or read if they are longer than this value.</para>
	/// </param>
	/// <param name="cMaxBlocks">
	/// <para>The maximum number of blocks that can be allocated at any time for read operations.</para>
	/// <para>Read contexts use at least one read block.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>
	/// If the function fails, the return value is zero (0). To get extended error information, call GetLastError. The following list
	/// identifies the possible error codes:
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfsw32/nf-clfsw32-dumplogrecords CLFSUSER_API BOOL DumpLogRecords( [in] PWSTR
	// pwszLogFileName, [in] CLFS_RECORD_TYPE fRecordType, [in, optional] PCLFS_LSN plsnStart, [in, optional] PCLFS_LSN plsnEnd, [in,
	// optional] PFILE pstrmOut, [in, optional] CLFS_PRINT_RECORD_ROUTINE pfnPrintRecord, [in, optional] CLFS_BLOCK_ALLOCATION pfnAllocBlock,
	// [in, optional] CLFS_BLOCK_DEALLOCATION pfnFreeBlock, [in, optional] PVOID pvBlockAllocContext, [in] ULONG cbBlock, [in] ULONG
	// cMaxBlocks );
	[DllImport(Lib_Clfsw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("clfsw32.h", MSDNShortId = "NF:clfsw32.DumpLogRecords")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DumpLogRecords([MarshalAs(UnmanagedType.LPWStr)] string pwszLogFileName, [In] CLS_RECORD_TYPE fRecordType,
		in CLS_LSN plsnStart, in CLS_LSN plsnEnd, [In, Optional] HFILE pstrmOut, [In, Optional] CLFS_PRINT_RECORD_ROUTINE? pfnPrintRecord,
		[In, Optional] CLFS_BLOCK_ALLOCATION? pfnAllocBlock, [In, Optional] CLFS_BLOCK_DEALLOCATION? pfnFreeBlock,
		[In, Optional] IntPtr pvBlockAllocContext, [In] uint cbBlock, [In] uint cMaxBlocks);

	/// <summary>
	/// Scans a specified log; filters log records based on record type; and places the records in an output file stream that the caller opens.
	/// </summary>
	/// <param name="pwszLogFileName">
	/// <para>The name of the log stream.</para>
	/// <para>This name is specified when you create the log by using CreateLogFile. The following example identifies the format to use:</para>
	/// <para><c>log:&lt;</c><c>log name</c><c>&gt;[::&lt;</c><c>log stream name</c><c>&gt;]</c></para>
	/// <para>&lt; <c>log name</c>&gt; corresponds to a valid file path in the file system.</para>
	/// <para>&lt; <c>log stream name</c>&gt; is the unique name of a log stream in the log.</para>
	/// <para>For more information, see Log Types.</para>
	/// </param>
	/// <param name="fRecordType">
	/// <para>The type of records to be read.</para>
	/// <para>This parameter can be one or more of the following CLFS_RECORD_TYPE Constants.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>ClfsNullRecord</c></term>
	/// <term>The default record type of <c>ClfsDataRecord</c> is used.</term>
	/// </item>
	/// <item>
	/// <term><c>ClfsDataRecord</c></term>
	/// <term>User data records are read.</term>
	/// </item>
	/// <item>
	/// <term><c>ClfsRestartRecord</c></term>
	/// <term>Restart records are read.</term>
	/// </item>
	/// <item>
	/// <term><c>ClfsClientRecord</c></term>
	/// <term>Both restart and data records are read.</term>
	/// </item>
	/// <item>
	/// <term><c>ClfsClientRecord</c></term>
	/// <term>Specifies a mask for all valid data or restart records.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="plsnStart">
	/// <para>A pointer to a CLFS_LSN that specifies the starting log sequence number (LSN) for the log dump sequence.</para>
	/// <para>
	/// If this parameter is specified, the LSN must be the address of a valid log record in the active part of the log; otherwise, the call
	/// fails with status <c>ERROR_INVALID_PARAMETER</c>.
	/// </para>
	/// <para>If this parameter is not specified, the start of the dump sequence is the beginning of the active log.</para>
	/// </param>
	/// <param name="plsnEnd">
	/// <para>A pointer to a CLFS_LSN that specifies the LSN where the dump sequence should end.</para>
	/// <para>If this LSN is past the end of the LSN range, the function returns <c>ERROR_HANDLE_EOF</c>.</para>
	/// <para>
	/// Unlike <c>plsnStart</c>, this value does not have to be the LSN of a valid record in the active log, but can be any valid LSN. Only
	/// records with an LSN value less than or equal to <c>plsnEnd</c> are placed in the output stream.
	/// </para>
	/// <para>If this parameter is <c>NULL</c>, the dump function uses the last LSN in the active log (at the head of the log).</para>
	/// </param>
	/// <param name="pstrmOut">
	/// <para>A pointer to an open output stream where the log records are placed.</para>
	/// <para>If this parameter is not specified, "stdout" is used as the default.</para>
	/// </param>
	/// <param name="pfnPrintRecord">
	/// <para>A user-defined callback routine that formats user-defined buffers and prints them to the output stream <c>pstrmOut</c>.</para>
	/// <para>
	/// The <c>DumpLogRecords</c> function natively outputs its internal record headers to <c>pstrmOut</c>, but depends on the user-defined
	/// callback to format the user buffers.
	/// </para>
	/// <para>If this parameter is <c>NULL</c>, <c>DumpLogRecords</c> places user record data in the output stream as hexadecimal digits.</para>
	/// </param>
	/// <param name="pfnAllocBlock">
	/// <para>A callback function that allocates memory for log blocks.</para>
	/// <para>
	/// If this parameter is <c>NULL</c>, Common Log File System (CLFS) provides a default block allocation function. This parameter cannot
	/// be <c>NULL</c> if a block-freeing callback is specified by using the <c>pfnFreeBuffer</c> parameter.
	/// </para>
	/// <para>The following example identifies the syntax of the block allocation callback function:</para>
	/// </param>
	/// <param name="pfnFreeBlock">
	/// <para>A callback function that frees log blocks allocated by <c>pfnAllocBuffer</c>.</para>
	/// <para>
	/// If this parameter is <c>NULL</c>, CLFS provides a default block deallocation function. This parameter cannot be <c>NULL</c> if a
	/// block allocation callback is specified by using the <c>pfnAllocBuffer</c> parameter.
	/// </para>
	/// <para>The following example identifies the syntax of the block-freeing callback function:</para>
	/// </param>
	/// <param name="pvBlockAllocContext">
	/// <para>A pointer to a buffer that is passed as a user context to the block allocation and deallocation routines, if a buffer is specified.</para>
	/// <para>If <c>pfnAllocBuffer</c> is <c>NULL</c>, this parameter is ignored.</para>
	/// </param>
	/// <param name="cbBlock">
	/// <para>The size of the buffer that your records are marshaled into, in bytes.</para>
	/// <para>Records cannot be appended or read if they are longer than this value.</para>
	/// </param>
	/// <param name="cMaxBlocks">
	/// <para>The maximum number of blocks that can be allocated at any time for read operations.</para>
	/// <para>Read contexts use at least one read block.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>
	/// If the function fails, the return value is zero (0). To get extended error information, call GetLastError. The following list
	/// identifies the possible error codes:
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfsw32/nf-clfsw32-dumplogrecords CLFSUSER_API BOOL DumpLogRecords( [in] PWSTR
	// pwszLogFileName, [in] CLFS_RECORD_TYPE fRecordType, [in, optional] PCLFS_LSN plsnStart, [in, optional] PCLFS_LSN plsnEnd, [in,
	// optional] PFILE pstrmOut, [in, optional] CLFS_PRINT_RECORD_ROUTINE pfnPrintRecord, [in, optional] CLFS_BLOCK_ALLOCATION pfnAllocBlock,
	// [in, optional] CLFS_BLOCK_DEALLOCATION pfnFreeBlock, [in, optional] PVOID pvBlockAllocContext, [in] ULONG cbBlock, [in] ULONG
	// cMaxBlocks );
	[DllImport(Lib_Clfsw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("clfsw32.h", MSDNShortId = "NF:clfsw32.DumpLogRecords")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DumpLogRecords([MarshalAs(UnmanagedType.LPWStr)] string pwszLogFileName, [In] CLS_RECORD_TYPE fRecordType,
		[In, Optional] IntPtr plsnStart, [In, Optional] IntPtr plsnEnd, [In, Optional] HFILE pstrmOut, [In, Optional] CLFS_PRINT_RECORD_ROUTINE? pfnPrintRecord,
		[In, Optional] CLFS_BLOCK_ALLOCATION? pfnAllocBlock, [In, Optional] CLFS_BLOCK_DEALLOCATION? pfnFreeBlock,
		[In, Optional] IntPtr pvBlockAllocContext, [In] uint cbBlock, [In] uint cMaxBlocks);

	/// <summary>
	/// Forces all records appended to this marshaling area to be flushed to disk. This service is a special case of FlushLogToLsn with the
	/// target log sequence number (LSN) set to <c>CLFS_LSN_NULL</c>.
	/// </summary>
	/// <param name="pvMarshal">A pointer to the marshaling context that is allocated by using the CreateLogMarshallingArea function.</param>
	/// <param name="pOverlapped">
	/// <para>A pointer to an OVERLAPPED structure that is required for asynchronous operation.</para>
	/// <para>This parameter can be <c>NULL</c> if asynchronous operation is not used.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>
	/// If the function fails, the return value is zero (0). To get extended error information, call GetLastError. The following list
	/// identifies the possible error codes:
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfsw32/nf-clfsw32-flushlogbuffers CLFSUSER_API BOOL FlushLogBuffers( [in] PVOID
	// pvMarshal, [in, out, optional] LPOVERLAPPED pOverlapped );
	[DllImport(Lib_Clfsw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("clfsw32.h", MSDNShortId = "NF:clfsw32.FlushLogBuffers")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool FlushLogBuffers([In] IntPtr pvMarshal, ref NativeOverlapped pOverlapped);

	/// <summary>
	/// Forces all records appended to this marshaling area to be flushed to disk. This service is a special case of FlushLogToLsn with the
	/// target log sequence number (LSN) set to <c>CLFS_LSN_NULL</c>.
	/// </summary>
	/// <param name="pvMarshal">A pointer to the marshaling context that is allocated by using the CreateLogMarshallingArea function.</param>
	/// <param name="pOverlapped">
	/// <para>A pointer to an OVERLAPPED structure that is required for asynchronous operation.</para>
	/// <para>This parameter can be <c>NULL</c> if asynchronous operation is not used.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>
	/// If the function fails, the return value is zero (0). To get extended error information, call GetLastError. The following list
	/// identifies the possible error codes:
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfsw32/nf-clfsw32-flushlogbuffers CLFSUSER_API BOOL FlushLogBuffers( [in] PVOID
	// pvMarshal, [in, out, optional] LPOVERLAPPED pOverlapped );
	[DllImport(Lib_Clfsw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("clfsw32.h", MSDNShortId = "NF:clfsw32.FlushLogBuffers")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool FlushLogBuffers([In] IntPtr pvMarshal, [In, Optional] IntPtr pOverlapped);

	/// <summary>
	/// Forces all records appended to this marshaling area up to the record with the specified log sequence number (LSN) to be flushed to
	/// the disk. More records than specified may be flushed during this operation.
	/// </summary>
	/// <param name="pvMarshalContext">A pointer to the marshaling context that is allocated by using the CreateLogMarshallingArea function.</param>
	/// <param name="plsnFlush">
	/// <para>A pointer to a CLFS_LSN structure that specifies the LSN that is used to determine which records to flush.</para>
	/// <para>Specify CLFS_LSN_NULL to flush all records in the marshaling area.</para>
	/// </param>
	/// <param name="plsnLastFlushed">
	/// <para>A pointer to a CLFS_LSN structure.</para>
	/// <para>
	/// The LSN returned is greater than the LSN of any record flushed. If the function succeeds, the value of the LSN is never less than
	/// <c>plsnFlush</c>. This value is meaningful only when the function succeeds.
	/// </para>
	/// </param>
	/// <param name="pOverlapped">
	/// <para>A pointer to an OVERLAPPED structure that is required for asynchronous operation.</para>
	/// <para>This parameter can be <c>NULL</c> except for an asynchronous operation.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>
	/// If the function fails, the return value is zero (0). To get extended error information, call GetLastError. The following list
	/// identifies the possible error codes:
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfsw32/nf-clfsw32-flushlogtolsn CLFSUSER_API BOOL FlushLogToLsn( [in] PVOID
	// pvMarshalContext, [in] PCLFS_LSN plsnFlush, [out, optional] PCLFS_LSN plsnLastFlushed, [in, out, optional] LPOVERLAPPED pOverlapped );
	[DllImport(Lib_Clfsw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("clfsw32.h", MSDNShortId = "NF:clfsw32.FlushLogToLsn")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool FlushLogToLsn([In] IntPtr pvMarshalContext, in CLS_LSN plsnFlush, out CLS_LSN plsnLastFlushed,
		ref NativeOverlapped pOverlapped);

	/// <summary>
	/// Forces all records appended to this marshaling area up to the record with the specified log sequence number (LSN) to be flushed to
	/// the disk. More records than specified may be flushed during this operation.
	/// </summary>
	/// <param name="pvMarshalContext">A pointer to the marshaling context that is allocated by using the CreateLogMarshallingArea function.</param>
	/// <param name="plsnFlush">
	/// <para>A pointer to a CLFS_LSN structure that specifies the LSN that is used to determine which records to flush.</para>
	/// <para>Specify CLFS_LSN_NULL to flush all records in the marshaling area.</para>
	/// </param>
	/// <param name="plsnLastFlushed">
	/// <para>A pointer to a CLFS_LSN structure.</para>
	/// <para>
	/// The LSN returned is greater than the LSN of any record flushed. If the function succeeds, the value of the LSN is never less than
	/// <c>plsnFlush</c>. This value is meaningful only when the function succeeds.
	/// </para>
	/// </param>
	/// <param name="pOverlapped">
	/// <para>A pointer to an OVERLAPPED structure that is required for asynchronous operation.</para>
	/// <para>This parameter can be <c>NULL</c> except for an asynchronous operation.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>
	/// If the function fails, the return value is zero (0). To get extended error information, call GetLastError. The following list
	/// identifies the possible error codes:
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfsw32/nf-clfsw32-flushlogtolsn CLFSUSER_API BOOL FlushLogToLsn( [in] PVOID
	// pvMarshalContext, [in] PCLFS_LSN plsnFlush, [out, optional] PCLFS_LSN plsnLastFlushed, [in, out, optional] LPOVERLAPPED pOverlapped );
	[DllImport(Lib_Clfsw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("clfsw32.h", MSDNShortId = "NF:clfsw32.FlushLogToLsn")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool FlushLogToLsn([In] IntPtr pvMarshalContext, in CLS_LSN plsnFlush, out CLS_LSN plsnLastFlushed,
		[In, Optional] IntPtr pOverlapped);

	/// <summary>
	/// Reduces the number of reserved log records in a marshaling area made by calling ReserveAndAppendLog, ReserveAndAppendLogAligned, or
	/// AllocReservedLog. By using this function, clients can free an aggregate set of records and bytes that are reserved in the marshaling area.
	/// </summary>
	/// <param name="pvMarshal">A pointer to the opaque marshaling context that is allocated by using the CreateLogMarshallingArea function.</param>
	/// <param name="cReservedRecords">
	/// <para>The number of reserved records to be freed.</para>
	/// <para>
	/// If the byte count of the adjustment in <c>pcbAdjustment</c> is positive, <c>cReservedRecords</c> is the total number of reserved
	/// records that are remaining after the adjustment. Otherwise, this parameter specifies the number of records to be subtracted from the
	/// current number of reserved records, but can never exceed the reserved count.
	/// </para>
	/// </param>
	/// <param name="pcbAdjustment">
	/// <para>The number of bytes of reservation space affected by the adjustment.</para>
	/// <para>
	/// On input, if this number is positive, it specifies the total remaining size of the reserved space after the adjustment. If this
	/// parameter is negative, its absolute value is the number of bytes to be freed.
	/// </para>
	/// <para>This value is usually an aggregate of the actual reserved space that is returned in a previous call to the following:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>ReserveAndAppendLog</term>
	/// </item>
	/// <item>
	/// <term>ReserveAndAppendLogAligned</term>
	/// </item>
	/// <item>
	/// <term>AllocReservedLog</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>
	/// If the function fails, the return value is zero. To get extended error information, call GetLastError. The following list identifies
	/// the possible error codes:
	/// </para>
	/// </returns>
	/// <remarks>When you reserve records, you reserve a specific size. When you free those records, you must free the same size.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfsw32/nf-clfsw32-freereservedlog CLFSUSER_API BOOL FreeReservedLog( [in, out]
	// PVOID pvMarshal, [in] ULONG cReservedRecords, [in, out] PLONGLONG pcbAdjustment );
	[DllImport(Lib_Clfsw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("clfsw32.h", MSDNShortId = "NF:clfsw32.FreeReservedLog")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool FreeReservedLog([In, Out] IntPtr pvMarshal, [In] uint cReservedRecords, ref long pcbAdjustment);

	/// <summary>
	/// Retrieves the full path name of the specified container. This function is used mainly to obtain the full path name of a container
	/// referenced in the CLFS_CONTAINER_INFORMATION structure that is returned in calls to ScanLogContainers.
	/// </summary>
	/// <param name="hLog">
	/// <para>A handle to the log that is obtained from a successful call to CreateLogFile.</para>
	/// <para>The log handle could refer to a log stream or a physical log.</para>
	/// </param>
	/// <param name="cidLogicalContainer">The unique identifier that is associated with a container.</param>
	/// <param name="pwstrContainerName">
	/// A pointer to a user-allocated buffer to receive the full path and name of the log container, in wide characters.
	/// </param>
	/// <param name="cLenContainerName">The size of the buffer pointed to by <c>pwstrContainerName</c>, in characters.</param>
	/// <param name="pcActualLenContainerName">
	/// <para>A pointer to a variable to receive the actual character count of the full container path name that is retrieved.</para>
	/// <para>
	/// If the function succeeds, the value of this parameter is less than or equal to <c>cLenContainerName</c>. If the buffer is not large
	/// enough to store the whole container path name, the function fails with <c>ERROR_MORE_DATA</c> and sets this parameter to the size
	/// that is required for the full path name. For other failures the value is not defined.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>
	/// If the function fails, the return value is zero (0). To get extended error information, call GetLastError. The following list
	/// identifies the possible error codes:
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfsw32/nf-clfsw32-getlogcontainername CLFSUSER_API BOOL GetLogContainerName( [in]
	// HANDLE hLog, [in] CLFS_CONTAINER_ID cidLogicalContainer, [in, out] LPCWSTR pwstrContainerName, [in] ULONG cLenContainerName, [in, out,
	// optional] PULONG pcActualLenContainerName );
	[DllImport(Lib_Clfsw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("clfsw32.h", MSDNShortId = "NF:clfsw32.GetLogContainerName")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetLogContainerName([In] HLOG hLog, [In] CLFS_CONTAINER_ID cidLogicalContainer,
		[In, Out, MarshalAs(UnmanagedType.LPWStr), SizeDef(nameof(cLenContainerName), SizingMethod.Query, OutVarName = nameof(pcActualLenContainerName))] StringBuilder pwstrContainerName,
		[In] int cLenContainerName, out uint pcActualLenContainerName);

	/// <summary>
	/// <para>
	/// Returns a buffer that contains metadata about a specified log and its current state, which is defined by the CLFS_INFORMATION structure.
	/// </para>
	/// <para>
	/// Data that is obtained reflects the state of the log only at the time when the call is made. Typically, a client can continue to cache
	/// and use fields from this structure until the next time that it appends records or writes its restart area. At that time, some of the
	/// information becomes stale.
	/// </para>
	/// </summary>
	/// <param name="hLog">
	/// <para>A handle to an open log that is obtained from a successful call to CreateLogFile.</para>
	/// <para>The log handle can refer to a dedicated or multiplexed log.</para>
	/// </param>
	/// <param name="pinfoBuffer">A pointer to a user-allocated CLFS_INFORMATION structure that receives the log metadata.</param>
	/// <param name="cbBuffer">
	/// <para>A pointer to a variable that on input specifies the size, in bytes, of the metadata buffer pointed to by <c>pinfoBuffer</c>.</para>
	/// <para>On output, it specifies the number of bytes that are actually copied into <c>pinfoBuffer</c>.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// <para>The following list identifies the possible error codes:</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfsw32/nf-clfsw32-getlogfileinformation CLFSUSER_API BOOL GetLogFileInformation(
	// [in] HANDLE hLog, [in, out] PCLFS_INFORMATION pinfoBuffer, [in, out] PULONG cbBuffer );
	[DllImport(Lib_Clfsw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("clfsw32.h", MSDNShortId = "NF:clfsw32.GetLogFileInformation")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetLogFileInformation([In] HLOG hLog, ref CLS_INFORMATION pinfoBuffer, ref uint cbBuffer);

	/// <summary>
	/// Retrieves log I/O statistics for a dedicated or multiplexed log that is associated with the specified handle. This function queries
	/// Common Log File System (CLFS) for specific types of log I/O statistics. Calling this function on a multiplexed log only associates
	/// the statistics with the underlying log.
	/// </summary>
	/// <param name="hLog">
	/// A handle to an open log file that CreateLogFile gets. The log handle can refer to either a dedicated or multiplexed log file.
	/// </param>
	/// <param name="pvStatsBuffer">
	/// <para>A pointer to a buffer to receive the I/O statistics.</para>
	/// <para>This buffer must be at least as large as an I/O statistics packet header. For more information, see CLFS_IO_STATISTICS_HEADER.</para>
	/// </param>
	/// <param name="cbStatsBuffer">
	/// <para>The size of the I/O statistics buffer <c>pvStatsBuffer</c>, in bytes.</para>
	/// <para>If the buffer is not large enough for the statistics packet, the function fails with <c>ERROR_MORE_DATA</c>.</para>
	/// </param>
	/// <param name="eStatsClass">This parameter is not implemented at this time; it is reserved for future use.</param>
	/// <param name="pcbStatsWritten">
	/// <para>A pointer to a variable to receive the size of the I/O statistics packet that is written to <c>pvStatsBuffer</c>.</para>
	/// <para>This value is less than or equal to <c>cbStatsBuffer</c>.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>
	/// If the function fails, the return value is zero (0). To get extended error information, call GetLastError. The following list
	/// identifies the possible error codes:
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfsw32/nf-clfsw32-getlogiostatistics CLFSUSER_API BOOL GetLogIoStatistics( [in]
	// HANDLE hLog, [in, out] PVOID pvStatsBuffer, [in] ULONG cbStatsBuffer, [in] CLFS_IOSTATS_CLASS eStatsClass, [out, optional] PULONG
	// pcbStatsWritten );
	[DllImport(Lib_Clfsw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("clfsw32.h", MSDNShortId = "NF:clfsw32.GetLogIoStatistics")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetLogIoStatistics([In] HLOG hLog, [In, Out] IntPtr pvStatsBuffer, [In] uint cbStatsBuffer,
		[In] CLFS_IOSTATS_CLASS eStatsClass, out uint pcbStatsWritten);

	/// <summary>Get the reservation information from a marshalling context</summary>
	/// <param name="pvMarshal">A pointer to a marshaling context that is allocated by using the CreateLogMarshallingArea function.</param>
	/// <param name="pcbRecordNumber">The record number.</param>
	/// <param name="pcbUserReservation">The user reservation.</param>
	/// <param name="pcbCommitReservation">The commit reservation.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero (0). To get extended error information, call GetLastError.</para>
	/// </returns>
	[DllImport(Lib_Clfsw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("clfsw32.h")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetLogReservationInfo([In] IntPtr pvMarshal, out uint pcbRecordNumber, out long pcbUserReservation,
		out long pcbCommitReservation);

	/// <summary>
	/// Retrieves the next set of archive extents in a log archive context. The log archive context describes a contiguous set of file
	/// extents that span the snapshot of the active log captured by PrepareLogArchive captures. <c>GetNextLogArchiveExtent</c> maintains a
	/// cursor in the ordered set of log archive descriptors so that subsequent calls allow an application to iterate through the entire set.
	/// </summary>
	/// <param name="pvArchiveContext">
	/// <para>A pointer to an archive context that is obtained by a call to PrepareLogArchive.</para>
	/// <para>
	/// The context maintains the cursor state, which allows iteration through the set of file extents in the archive. The archive client is
	/// responsible for deallocating the context by using the TerminateLogArchive function.
	/// </para>
	/// </param>
	/// <param name="rgadExtent">A client-allocated array of CLFS_ARCHIVE_DESCRIPTOR structures to be filled in by this function.</param>
	/// <param name="cDescriptors">
	/// <para>The number of elements in the <c>rgadExtent</c> array.</para>
	/// <para>This value is the maximum number of archive descriptors that can be retrieved by this function.</para>
	/// </param>
	/// <param name="pcDescriptorsReturned">
	/// <para>The number of descriptors in the <c>rgadExtent</c> array that are filled in by this function.</para>
	/// <para>
	/// If this value is less than <c>cDescriptors</c>, the set of descriptors is exhausted and the archive client can terminate iteration
	/// through the ordered descriptor set. Further calls to this function fail with ERROR_NO_MORE_ENTRIES.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>
	/// If the function fails, the return value is zero (0). To get extended error information, call GetLastError. The following list
	/// identifies the possible error codes:
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfsw32/nf-clfsw32-getnextlogarchiveextent CLFSUSER_API BOOL
	// GetNextLogArchiveExtent( [in] CLFS_LOG_ARCHIVE_CONTEXT pvArchiveContext, [in, out] CLFS_ARCHIVE_DESCRIPTOR [] rgadExtent, [in] ULONG
	// cDescriptors, [out] PULONG pcDescriptorsReturned );
	[DllImport(Lib_Clfsw32, SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("clfsw32.h", MSDNShortId = "NF:clfsw32.GetNextLogArchiveExtent")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetNextLogArchiveExtent([In] SafeArchiveContext pvArchiveContext,
		[In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] CLS_ARCHIVE_DESCRIPTOR[] rgadExtent, [In] int cDescriptors,
		out int pcDescriptorsReturned);

	/// <summary>Returns the sector-aligned block offset that is contained in the specified LSN.</summary>
	/// <param name="plsn">A pointer to a CLFS_LSN structure from which the block offset is to be retrieved.</param>
	/// <returns><c>LsnBlockOffset</c> returns the block offset that is contained in <c>plsn</c>.</returns>
	/// <remarks>
	/// <para>
	/// The block offset that is returned by this function is a multiple of the sector size on the stable storage medium. For example, if the
	/// sector size is 1024 bytes, the block offset is a multiple of 1024.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example that uses this function, see Enumerating Log Containers.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfsw32/nf-clfsw32-lsnblockoffset CLFSUSER_API ULONG LsnBlockOffset( [in] const
	// CLS_LSN *plsn );
	[DllImport(Lib_Clfsw32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("clfsw32.h", MSDNShortId = "NF:clfsw32.LsnBlockOffset")]
	public static extern uint LsnBlockOffset(in CLS_LSN plsn);

	/// <summary>Retrieves the logical container ID that is contained in a specified LSN.</summary>
	/// <param name="plsn">A pointer to a CLFS_LSN structure from which the container ID is to be retrieved.</param>
	/// <returns>
	/// This function returns the logical container ID that is contained in <c>plsn</c>. The logical container ID is not necessarily the same
	/// as the ID of the physical container on stable storage.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfsw32/nf-clfsw32-lsncontainer CLFSUSER_API CLFS_CONTAINER_ID LsnContainer( [in]
	// const CLS_LSN *plsn );
	[DllImport(Lib_Clfsw32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("clfsw32.h", MSDNShortId = "NF:clfsw32.LsnContainer")]
	public static extern CLFS_CONTAINER_ID LsnContainer(in CLS_LSN plsn);

	/// <summary>Creates a log sequence number (LSN), given a container ID, a block offset, and a record sequence number.</summary>
	/// <param name="cidContainer">The container ID. This value must be an integer between 0x0 and 0xFFFFFFFF.</param>
	/// <param name="offBlock">The block offset. This value must be a multiple of 512.</param>
	/// <param name="cRecord">The record sequence number. This value must be an integer between 0 - 511.</param>
	/// <returns>
	/// Returns a CLFS_LSN structure that represents the container ID, block offset, and record sequence number that is supplied by the caller.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfsw32/nf-clfsw32-lsncreate CLFSUSER_API CLS_LSN LsnCreate( [in] CLFS_CONTAINER_ID
	// cidContainer, [in] ULONG offBlock, [in] ULONG cRecord );
	[DllImport(Lib_Clfsw32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("clfsw32.h", MSDNShortId = "NF:clfsw32.LsnCreate")]
	public static extern CLS_LSN LsnCreate([In] CLFS_CONTAINER_ID cidContainer, [In] uint offBlock, [In] uint cRecord);

	/// <summary>Decrement and LSN by 1</summary>
	/// <param name="plsn">LSN to be decremented.</param>
	/// <returns>A valid LSN prior in sequence to the input LSN, if successful. Otherwise, this function returns CLFS_LSN_INVALID.</returns>
	[DllImport(Lib_Clfsw32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("clfsw32.h", MSDNShortId = "NF:clfsw32.LsnDecrement")]
	public static extern CLS_LSN LsnDecrement(in CLS_LSN plsn);

	/// <summary>Increment and LSN by 1</summary>
	/// <param name="plsn">LSN to be incremented.</param>
	/// <returns>A valid LSN next in sequence to the input LSN, if successful. Otherwise, this function returns CLFS_LSN_INVALID.</returns>
	[DllImport(Lib_Clfsw32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("clfsw32.h", MSDNShortId = "NF:clfsw32.LsnIncrement")]
	public static extern CLS_LSN LsnIncrement(in CLS_LSN plsn);

	/// <summary>Check whether or not an LSN is CLFS_LSN_INVALID.</summary>
	/// <param name="plsn">Reference to LSN tested against CLFS_LSN_INVALID.</param>
	/// <returns>
	/// <see langword="true"/> if and only if an LSN is equivalent to CLFS_LSN_INVALID. LSNs with the value CLFS_LSN_NULL will return <see langword="false"/>.
	/// </returns>
	[DllImport(Lib_Clfsw32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("clfsw32.h", MSDNShortId = "NF:clfsw32.LsnInvalid")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern bool LsnInvalid(in CLS_LSN plsn);

	/// <summary>Retrieves the record sequence number that is contained in a specified LSN.</summary>
	/// <param name="plsn">A pointer to a CLFS_LSN structure from which the record sequence number is to be retrieved.</param>
	/// <returns>The record sequence number that is contained in <c>plsn</c>.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfsw32/nf-clfsw32-lsnrecordsequence CLFSUSER_API ULONG LsnRecordSequence( [in]
	// const CLS_LSN *plsn );
	[DllImport(Lib_Clfsw32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("clfsw32.h", MSDNShortId = "NF:clfsw32.LsnRecordSequence")]
	public static extern uint LsnRecordSequence(in CLS_LSN plsn);

	/// <summary>
	/// <para>
	/// Prepares a physical log for archival. The function takes a snapshot of the current active log, builds an ordered set of log archive
	/// descriptors for the active log extents, and returns a log archive context.
	/// </para>
	/// <para>
	/// By passing this log archive context to GetNextLogArchiveExtent, a client can iterate through the set of log archive extents to
	/// archive the log. You can also specify a range of records to archive.
	/// </para>
	/// </summary>
	/// <param name="hLog">
	/// <para>A handle to the log that is obtained by a successful call to CreateLogFile.</para>
	/// <para>This handle can be the handle to a dedicated or multiplexed log.</para>
	/// </param>
	/// <param name="pszBaseLogFileName">
	/// <para>A pointer to a user-allocated buffer to receive the fully qualified path of the base log.</para>
	/// <para>
	/// If the buffer is not large enough, it contains a truncated file path on exit, and the function fails with an
	/// <c>ERROR_BUFFER_OVERFLOW</c> status code.
	/// </para>
	/// <para>
	/// The length of the file path is returned in the variable pointed to by <c>pcActualLength</c>. The client can re-attempt a failed call
	/// with a name buffer that is large enough.
	/// </para>
	/// </param>
	/// <param name="cLen">The size of the <c>pszBaseLogFileName</c> buffer, in wide characters.</param>
	/// <param name="plsnLow">
	/// <para>
	/// A pointer to a CLFS_LSN structure that specifies the log sequence number (LSN) of the low end of the range of the active log where
	/// the log client needs log archival information.
	/// </para>
	/// <para>If this parameter is omitted, the low end of the range defaults to the LSN of the log archive tail.</para>
	/// </param>
	/// <param name="plsnHigh">
	/// <para>
	/// A pointer to a CLFS_LSN structure that specifies the LSN of the high end of the range of the active log where the log client needs
	/// log archival information.
	/// </para>
	/// <para>If this parameter is omitted, the high end of the range defaults to the next LSN to be written to the log.</para>
	/// </param>
	/// <param name="pcActualLength">
	/// <para>A pointer to a variable that receives the actual length of the name of the base log path, in characters.</para>
	/// <para>
	/// If this value is greater than <c>cLen</c>, the function returns an ERROR_BUFFER_OVERFLOW status with a truncated path that is stored
	/// in the <c>pszBaseLogFileName</c> buffer and all other out parameters that are not set to meaningful values.
	/// </para>
	/// </param>
	/// <param name="poffBaseLogFileData">
	/// <para>A pointer to a variable that receives the offset where the metadata begins in the base log.</para>
	/// <para>
	/// The contiguous extent in the base log <c>pszBaseLogFileName</c> represents the full contents of the log metadata—that is, from
	/// <c>poffBaseLogFileData</c> to <c>pcbBaseLogFileLength</c>.
	/// </para>
	/// </param>
	/// <param name="pcbBaseLogFileLength">A pointer to a variable that specifies the exact length of the base log, in bytes.</param>
	/// <param name="plsnBase">A pointer to a CLFS_LSN structure to receive the base log sequence number (LSN) of the active log.</param>
	/// <param name="plsnLast">A pointer to a CLFS_LSN structure to receive the highest valid LSN in the active log.</param>
	/// <param name="plsnCurrentArchiveTail">A pointer to a CLFS_LSN structure to receive the current LSN of the archive tail of the log.</param>
	/// <param name="ppvArchiveContext">
	/// <para>A pointer to the variable that receives a pointer to an archive context that the system allocates.</para>
	/// <para>
	/// The archive context maintains the cursor state of the archival iterator and the log handle context. The archival client is
	/// responsible for releasing the context by calling TerminateLogArchive.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>
	/// If the function fails, the return value is zero. To get extended error information, call GetLastError. The following list identifies
	/// the possible error codes:
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>You must call TerminateLogArchive to free the archive context, or memory leaks can occur.</para>
	/// <para>Until you call TerminateLogArchive, containers that are being archived cannot be recycled.</para>
	/// <para>You can only perform one archive operation at a time per handle that CreateLogFile returns.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfsw32/nf-clfsw32-preparelogarchive CLFSUSER_API BOOL PrepareLogArchive( [in]
	// HANDLE hLog, [in, out] PWSTR pszBaseLogFileName, [in] ULONG cLen, [in, optional] const PCLFS_LSN plsnLow, [in, optional] const
	// PCLFS_LSN plsnHigh, [out, optional] PULONG pcActualLength, [out] PULONGLONG poffBaseLogFileData, [out] PULONGLONG
	// pcbBaseLogFileLength, [out] PCLFS_LSN plsnBase, [out] PCLFS_LSN plsnLast, [out] PCLFS_LSN plsnCurrentArchiveTail, [out]
	// PCLFS_LOG_ARCHIVE_CONTEXT ppvArchiveContext );
	[DllImport(Lib_Clfsw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("clfsw32.h", MSDNShortId = "NF:clfsw32.PrepareLogArchive")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool PrepareLogArchive([In] HLOG hLog,
		[MarshalAs(UnmanagedType.LPWStr), SizeDef(nameof(cLen), SizingMethod.CheckLastError, OutVarName = nameof(pcActualLength))] StringBuilder pszBaseLogFileName,
		[In] int cLen, in CLS_LSN plsnLow, in CLS_LSN plsnHigh, out uint pcActualLength, out ulong poffBaseLogFileData,
		out ulong pcbBaseLogFileLength, out CLS_LSN plsnBase, out CLS_LSN plsnLast, out CLS_LSN plsnCurrentArchiveTail,
		out SafeArchiveContext ppvArchiveContext);

	/// <summary>
	/// <para>
	/// Prepares a physical log for archival. The function takes a snapshot of the current active log, builds an ordered set of log archive
	/// descriptors for the active log extents, and returns a log archive context.
	/// </para>
	/// <para>
	/// By passing this log archive context to GetNextLogArchiveExtent, a client can iterate through the set of log archive extents to
	/// archive the log. You can also specify a range of records to archive.
	/// </para>
	/// </summary>
	/// <param name="hLog">
	/// <para>A handle to the log that is obtained by a successful call to CreateLogFile.</para>
	/// <para>This handle can be the handle to a dedicated or multiplexed log.</para>
	/// </param>
	/// <param name="pszBaseLogFileName">
	/// <para>A pointer to a user-allocated buffer to receive the fully qualified path of the base log.</para>
	/// <para>
	/// If the buffer is not large enough, it contains a truncated file path on exit, and the function fails with an
	/// <c>ERROR_BUFFER_OVERFLOW</c> status code.
	/// </para>
	/// <para>
	/// The length of the file path is returned in the variable pointed to by <c>pcActualLength</c>. The client can re-attempt a failed call
	/// with a name buffer that is large enough.
	/// </para>
	/// </param>
	/// <param name="cLen">The size of the <c>pszBaseLogFileName</c> buffer, in wide characters.</param>
	/// <param name="plsnLow">
	/// <para>
	/// A pointer to a CLFS_LSN structure that specifies the log sequence number (LSN) of the low end of the range of the active log where
	/// the log client needs log archival information.
	/// </para>
	/// <para>If this parameter is omitted, the low end of the range defaults to the LSN of the log archive tail.</para>
	/// </param>
	/// <param name="plsnHigh">
	/// <para>
	/// A pointer to a CLFS_LSN structure that specifies the LSN of the high end of the range of the active log where the log client needs
	/// log archival information.
	/// </para>
	/// <para>If this parameter is omitted, the high end of the range defaults to the next LSN to be written to the log.</para>
	/// </param>
	/// <param name="pcActualLength">
	/// <para>A pointer to a variable that receives the actual length of the name of the base log path, in characters.</para>
	/// <para>
	/// If this value is greater than <c>cLen</c>, the function returns an ERROR_BUFFER_OVERFLOW status with a truncated path that is stored
	/// in the <c>pszBaseLogFileName</c> buffer and all other out parameters that are not set to meaningful values.
	/// </para>
	/// </param>
	/// <param name="poffBaseLogFileData">
	/// <para>A pointer to a variable that receives the offset where the metadata begins in the base log.</para>
	/// <para>
	/// The contiguous extent in the base log <c>pszBaseLogFileName</c> represents the full contents of the log metadata—that is, from
	/// <c>poffBaseLogFileData</c> to <c>pcbBaseLogFileLength</c>.
	/// </para>
	/// </param>
	/// <param name="pcbBaseLogFileLength">A pointer to a variable that specifies the exact length of the base log, in bytes.</param>
	/// <param name="plsnBase">A pointer to a CLFS_LSN structure to receive the base log sequence number (LSN) of the active log.</param>
	/// <param name="plsnLast">A pointer to a CLFS_LSN structure to receive the highest valid LSN in the active log.</param>
	/// <param name="plsnCurrentArchiveTail">A pointer to a CLFS_LSN structure to receive the current LSN of the archive tail of the log.</param>
	/// <param name="ppvArchiveContext">
	/// <para>A pointer to the variable that receives a pointer to an archive context that the system allocates.</para>
	/// <para>
	/// The archive context maintains the cursor state of the archival iterator and the log handle context. The archival client is
	/// responsible for releasing the context by calling TerminateLogArchive.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>
	/// If the function fails, the return value is zero. To get extended error information, call GetLastError. The following list identifies
	/// the possible error codes:
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>You must call TerminateLogArchive to free the archive context, or memory leaks can occur.</para>
	/// <para>Until you call TerminateLogArchive, containers that are being archived cannot be recycled.</para>
	/// <para>You can only perform one archive operation at a time per handle that CreateLogFile returns.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfsw32/nf-clfsw32-preparelogarchive CLFSUSER_API BOOL PrepareLogArchive( [in]
	// HANDLE hLog, [in, out] PWSTR pszBaseLogFileName, [in] ULONG cLen, [in, optional] const PCLFS_LSN plsnLow, [in, optional] const
	// PCLFS_LSN plsnHigh, [out, optional] PULONG pcActualLength, [out] PULONGLONG poffBaseLogFileData, [out] PULONGLONG
	// pcbBaseLogFileLength, [out] PCLFS_LSN plsnBase, [out] PCLFS_LSN plsnLast, [out] PCLFS_LSN plsnCurrentArchiveTail, [out]
	// PCLFS_LOG_ARCHIVE_CONTEXT ppvArchiveContext );
	[DllImport(Lib_Clfsw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("clfsw32.h", MSDNShortId = "NF:clfsw32.PrepareLogArchive")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool PrepareLogArchive([In] HLOG hLog,
		[MarshalAs(UnmanagedType.LPWStr), SizeDef(nameof(cLen), SizingMethod.CheckLastError, OutVarName = nameof(pcActualLength))] StringBuilder pszBaseLogFileName,
		[In] int cLen, [In, Optional] IntPtr plsnLow, [In, Optional] IntPtr plsnHigh, out uint pcActualLength, out ulong poffBaseLogFileData,
		out ulong pcbBaseLogFileLength, out CLS_LSN plsnBase, out CLS_LSN plsnLast, out CLS_LSN plsnCurrentArchiveTail,
		out SafeArchiveContext ppvArchiveContext);

	/// <summary>Copies a range of the archive view of the metadata to the specified buffer.</summary>
	/// <param name="pvArchiveContext">
	/// <para>A pointer to an archive context that is obtained by a call to PrepareLogArchive.</para>
	/// <para>
	/// The context maintains the cursor state, which allows iteration through the set of file extents in the archive. The archive client is
	/// responsible for deallocating the context by using the TerminateLogArchive function.
	/// </para>
	/// </param>
	/// <param name="cbOffset">
	/// <para>The offset in the metadata where data copying starts.</para>
	/// <para>On the first call to this function, specify zero (0). On subsequent calls, specify the value that is returned in <c>pcbBytesRead</c>.</para>
	/// </param>
	/// <param name="cbBytesToRead">
	/// <para>The number of bytes of the metadata snapshot should be copied into <c>pbReadBuffer</c>.</para>
	/// <para>This parameter cannot be zero (0).</para>
	/// </param>
	/// <param name="pbReadBuffer">A pointer to the buffer where the metadata snapshot is copied.</param>
	/// <param name="pcbBytesRead">
	/// <para>A pointer to a variable that receives the number of bytes that are copied to <c>pbReadBuffer</c>.</para>
	/// <para>The number of bytes is always between zero (0) and <c>cbBytesToRead</c>.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>
	/// If the function fails, the return value is zero (0). To get extended error information, call GetLastError. The following list
	/// identifies the possible error codes:
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfsw32/nf-clfsw32-readlogarchivemetadata CLFSUSER_API BOOL ReadLogArchiveMetadata(
	// [in] CLFS_LOG_ARCHIVE_CONTEXT pvArchiveContext, [in] ULONG cbOffset, [in] ULONG cbBytesToRead, [in, out] PBYTE pbReadBuffer, [out]
	// PULONG pcbBytesRead );
	[DllImport(Lib_Clfsw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("clfsw32.h", MSDNShortId = "NF:clfsw32.ReadLogArchiveMetadata")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ReadLogArchiveMetadata([In] SafeArchiveContext pvArchiveContext, [In] uint cbOffset, [In] uint cbBytesToRead,
		[In, Out] IntPtr pbReadBuffer, out uint pcbBytesRead);

	/// <summary>
	/// Initiates a sequence of reads from a specified log sequence number (LSN) in one of three modes, and returns the first of the
	/// specified log records and a read context. A client can read subsequent records in the designated mode by passing the read context to ReadNextLogRecord.
	/// </summary>
	/// <param name="pvMarshal">A pointer to a marshaling context that is allocated by using the CreateLogMarshallingArea function.</param>
	/// <param name="plsnFirst">
	/// <para>
	/// A pointer to a CLFS_LSN structure that specifies the log sequence number (LSN) of the record where the read operation should start.
	/// </para>
	/// <para>This value must be an LSN of a valid record in the active range of the log.</para>
	/// </param>
	/// <param name="eContextMode">
	/// <para>The mode for the read context that is returned in <c>*ppvReadContext</c>.</para>
	/// <para>The following table identifies the three mutually exclusive read modes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>ClfsContextPrevious</c></term>
	/// <term>Reads the record linked to by <c>plsnPrevious</c>.</term>
	/// </item>
	/// <item>
	/// <term><c>ClfsContextUndoNext</c></term>
	/// <term>Reads the record chain linked to by <c>plsnUndoNext</c>.</term>
	/// </item>
	/// <item>
	/// <term><c>ClfsContextForward</c></term>
	/// <term>Reads the record with the LSN that immediately follows the current LSN in the read context.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="ppvReadBuffer">A pointer to a variable that receives a pointer to the target record in the log I/O block.</param>
	/// <param name="pcbReadBuffer">
	/// A pointer to a variable that receives the size of the data that is returned in <c>*ppvReadBuffer</c>, in bytes.
	/// </param>
	/// <param name="peRecordType">
	/// <para>A pointer to a variable that receives the type of record read.</para>
	/// <para>This parameter is one of the CLFS_RECORD_TYPE Constants.</para>
	/// </param>
	/// <param name="plsnUndoNext">A pointer to a CLFS_LSN structure that receives the LSN of the next record in the undo record chain.</param>
	/// <param name="plsnPrevious">A pointer to a CLFS_LSN structure that receives the LSN of the next record in the previous record chain.</param>
	/// <param name="ppvReadContext">
	/// <para>A pointer to a variable that receives a pointer to a system-allocated read context when a read is successful.</para>
	/// <para>
	/// If the function defers completion of an operation, it returns a valid read-context pointer and an error status of
	/// <c>ERROR_IO_PENDING</c>. On all other errors, the read-context pointer is <c>NULL</c>. For more information about handling deferred
	/// completion of the function, see the Remarks section of this topic.
	/// </para>
	/// <para>
	/// After obtaining all requested log records, the client must pass the read context to TerminateReadLog to free the associated memory.
	/// Failure to do so results in memory leakage.
	/// </para>
	/// <para>
	/// <c>Note</c> Common Log File System (CLFS) read contexts are not thread-safe. They should not be used by more than one thread at a
	/// time, or passed into more than one asynchronous read at a time.
	/// </para>
	/// </param>
	/// <param name="pOverlapped">
	/// <para>A pointer to an OVERLAPPED structure, which is required for asynchronous operation.</para>
	/// <para>This parameter can be <c>NULL</c> if asynchronous operation is not used.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// <para>The following list identifies the possible error codes.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The error message ERROR_LOG_BLOCK_INCOMPLETE is returned if the log block size specified by CreateLogMarshallingArea is not large
	/// enough to hold a complete log block.
	/// </para>
	/// <para>
	/// If <c>ReadLogRecord</c> is called with a valid <c>pOverlapped</c> structure and the log handle is created with the overlapped option,
	/// then if a call to this function fails with an error code of <c>ERROR_IO_PENDING</c>, a pointer to a valid read context is placed in
	/// the variable that is pointed to by the <c>ppvReadContext</c> parameter.
	/// </para>
	/// <para>
	/// If you attempt to open more read contexts than the number buffers specified in a previous call to CreateLogMarshallingArea,
	/// ERROR_LOG_BLOCK_EXHAUSTED is returned.
	/// </para>
	/// <para>
	/// To complete a log-record copy, the client should first synchronize its execution with deferred completion of the overlapped I/O
	/// operation by using GetOverlappedResult or one of the synchronization Wait Functions. For more information, see Synchronization and
	/// Overlapped Input and Output.
	/// </para>
	/// <para>
	/// After <c>ReadLogRecord</c> completes asynchronously, the requested record is read from the disk, but is not resolved to a pointer in <c>*ppvReadBuffer</c>.
	/// </para>
	/// <para>
	/// To complete the requested read and obtain a valid pointer to the log record, the client must call ReadNextLogRecord, which passes in
	/// the read-context pointer that <c>ReadLogRecord</c> returns.
	/// </para>
	/// <para>
	/// <c>Note</c> Common Log File System (CLFS) read contexts are not thread-safe. They should not be used by more than one thread at a time.
	/// <para></para>
	/// CLFS read contexts should not be passed into more than one asynchronous read at a time, or the function fails with ERROR_BUSY.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfsw32/nf-clfsw32-readlogrecord CLFSUSER_API BOOL ReadLogRecord( [in] PVOID
	// pvMarshal, [in] PCLFS_LSN plsnFirst, [in] CLFS_CONTEXT_MODE eContextMode, [out] PVOID *ppvReadBuffer, [out] PULONG pcbReadBuffer,
	// [out] PCLFS_RECORD_TYPE peRecordType, [out] PCLFS_LSN plsnUndoNext, [out] PCLFS_LSN plsnPrevious, [out] PVOID *ppvReadContext, [in,
	// out, optional] LPOVERLAPPED pOverlapped );
	[DllImport(Lib_Clfsw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("clfsw32.h", MSDNShortId = "NF:clfsw32.ReadLogRecord")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ReadLogRecord([In] IntPtr pvMarshal, in CLS_LSN plsnFirst, [In] CLFS_CONTEXT_MODE eContextMode,
		out IntPtr ppvReadBuffer, [Out] IntPtr pcbReadBuffer, out CLS_RECORD_TYPE peRecordType, out CLS_LSN plsnUndoNext,
		out CLS_LSN plsnPrevious, out IntPtr ppvReadContext, ref NativeOverlapped pOverlapped);

	/// <summary>
	/// Initiates a sequence of reads from a specified log sequence number (LSN) in one of three modes, and returns the first of the
	/// specified log records and a read context. A client can read subsequent records in the designated mode by passing the read context to ReadNextLogRecord.
	/// </summary>
	/// <param name="pvMarshal">A pointer to a marshaling context that is allocated by using the CreateLogMarshallingArea function.</param>
	/// <param name="plsnFirst">
	/// <para>
	/// A pointer to a CLFS_LSN structure that specifies the log sequence number (LSN) of the record where the read operation should start.
	/// </para>
	/// <para>This value must be an LSN of a valid record in the active range of the log.</para>
	/// </param>
	/// <param name="eContextMode">
	/// <para>The mode for the read context that is returned in <c>*ppvReadContext</c>.</para>
	/// <para>The following table identifies the three mutually exclusive read modes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>ClfsContextPrevious</c></term>
	/// <term>Reads the record linked to by <c>plsnPrevious</c>.</term>
	/// </item>
	/// <item>
	/// <term><c>ClfsContextUndoNext</c></term>
	/// <term>Reads the record chain linked to by <c>plsnUndoNext</c>.</term>
	/// </item>
	/// <item>
	/// <term><c>ClfsContextForward</c></term>
	/// <term>Reads the record with the LSN that immediately follows the current LSN in the read context.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="ppvReadBuffer">A pointer to a variable that receives a pointer to the target record in the log I/O block.</param>
	/// <param name="pcbReadBuffer">
	/// A pointer to a variable that receives the size of the data that is returned in <c>*ppvReadBuffer</c>, in bytes.
	/// </param>
	/// <param name="peRecordType">
	/// <para>A pointer to a variable that receives the type of record read.</para>
	/// <para>This parameter is one of the CLFS_RECORD_TYPE Constants.</para>
	/// </param>
	/// <param name="plsnUndoNext">A pointer to a CLFS_LSN structure that receives the LSN of the next record in the undo record chain.</param>
	/// <param name="plsnPrevious">A pointer to a CLFS_LSN structure that receives the LSN of the next record in the previous record chain.</param>
	/// <param name="ppvReadContext">
	/// <para>A pointer to a variable that receives a pointer to a system-allocated read context when a read is successful.</para>
	/// <para>
	/// If the function defers completion of an operation, it returns a valid read-context pointer and an error status of
	/// <c>ERROR_IO_PENDING</c>. On all other errors, the read-context pointer is <c>NULL</c>. For more information about handling deferred
	/// completion of the function, see the Remarks section of this topic.
	/// </para>
	/// <para>
	/// After obtaining all requested log records, the client must pass the read context to TerminateReadLog to free the associated memory.
	/// Failure to do so results in memory leakage.
	/// </para>
	/// <para>
	/// <c>Note</c> Common Log File System (CLFS) read contexts are not thread-safe. They should not be used by more than one thread at a
	/// time, or passed into more than one asynchronous read at a time.
	/// </para>
	/// </param>
	/// <param name="pOverlapped">
	/// <para>A pointer to an OVERLAPPED structure, which is required for asynchronous operation.</para>
	/// <para>This parameter can be <c>NULL</c> if asynchronous operation is not used.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// <para>The following list identifies the possible error codes.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The error message ERROR_LOG_BLOCK_INCOMPLETE is returned if the log block size specified by CreateLogMarshallingArea is not large
	/// enough to hold a complete log block.
	/// </para>
	/// <para>
	/// If <c>ReadLogRecord</c> is called with a valid <c>pOverlapped</c> structure and the log handle is created with the overlapped option,
	/// then if a call to this function fails with an error code of <c>ERROR_IO_PENDING</c>, a pointer to a valid read context is placed in
	/// the variable that is pointed to by the <c>ppvReadContext</c> parameter.
	/// </para>
	/// <para>
	/// If you attempt to open more read contexts than the number buffers specified in a previous call to CreateLogMarshallingArea,
	/// ERROR_LOG_BLOCK_EXHAUSTED is returned.
	/// </para>
	/// <para>
	/// To complete a log-record copy, the client should first synchronize its execution with deferred completion of the overlapped I/O
	/// operation by using GetOverlappedResult or one of the synchronization Wait Functions. For more information, see Synchronization and
	/// Overlapped Input and Output.
	/// </para>
	/// <para>
	/// After <c>ReadLogRecord</c> completes asynchronously, the requested record is read from the disk, but is not resolved to a pointer in <c>*ppvReadBuffer</c>.
	/// </para>
	/// <para>
	/// To complete the requested read and obtain a valid pointer to the log record, the client must call ReadNextLogRecord, which passes in
	/// the read-context pointer that <c>ReadLogRecord</c> returns.
	/// </para>
	/// <para>
	/// <c>Note</c> Common Log File System (CLFS) read contexts are not thread-safe. They should not be used by more than one thread at a time.
	/// <para></para>
	/// CLFS read contexts should not be passed into more than one asynchronous read at a time, or the function fails with ERROR_BUSY.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfsw32/nf-clfsw32-readlogrecord CLFSUSER_API BOOL ReadLogRecord( [in] PVOID
	// pvMarshal, [in] PCLFS_LSN plsnFirst, [in] CLFS_CONTEXT_MODE eContextMode, [out] PVOID *ppvReadBuffer, [out] PULONG pcbReadBuffer,
	// [out] PCLFS_RECORD_TYPE peRecordType, [out] PCLFS_LSN plsnUndoNext, [out] PCLFS_LSN plsnPrevious, [out] PVOID *ppvReadContext, [in,
	// out, optional] LPOVERLAPPED pOverlapped );
	[DllImport(Lib_Clfsw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("clfsw32.h", MSDNShortId = "NF:clfsw32.ReadLogRecord")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ReadLogRecord([In] IntPtr pvMarshal, in CLS_LSN plsnFirst, [In] CLFS_CONTEXT_MODE eContextMode,
		out IntPtr ppvReadBuffer, [Out] IntPtr pcbReadBuffer, out CLS_RECORD_TYPE peRecordType, out CLS_LSN plsnUndoNext,
		out CLS_LSN plsnPrevious, out IntPtr ppvReadContext, [In, Optional] IntPtr pOverlapped);

	/// <summary>
	/// <para>
	/// Returns the last restart area that is written successfully to the log associated with the marshaling area of WriteLogRestartArea. The
	/// function also returns a read context that allows the caller to cursor backward or forward through a log from the restart record.
	/// </para>
	/// <para>This read context is useful when scanning through previous restart areas prior to the current one by invoking ReadPreviousLogRestartArea.</para>
	/// </summary>
	/// <param name="pvMarshal">A pointer to a marshaling context that is allocated by using the CreateLogMarshallingArea function.</param>
	/// <param name="ppvRestartBuffer">A pointer to a variable that receives a pointer to the restart data in the log I/O block.</param>
	/// <param name="pcbRestartBuffer">A pointer to a variable that receives the amount of restart data.</param>
	/// <param name="plsn">A pointer to a CLFS_LSN structure that receives the log sequence number (LSN) of the restart area.</param>
	/// <param name="ppvContext">
	/// <para>A pointer to a variable that receives a pointer to a system-allocated read context when a read is successful.</para>
	/// <para>
	/// If the function defers completion of an operation, it returns a valid read-context pointer and an error status of
	/// <c>ERROR_IO_PENDING</c>. On all other errors, the read-context pointer is <c>NULL</c>. For more information about handling deferred
	/// completion of the function, see the Remarks section of this topic.
	/// </para>
	/// <para>
	/// After obtaining all requested log records, the client must pass the read context to TerminateReadLog to free the associated memory.
	/// Failure to do so results in memory leakage.
	/// </para>
	/// <para>
	/// <c>Note</c> Common Log File System (CLFS) read contexts are not thread-safe. They should not be used by more than one thread at a
	/// time, or passed into more than one asynchronous read at a time.
	/// </para>
	/// </param>
	/// <param name="pOverlapped">
	/// <para>A pointer to an OVERLAPPED structure that is required for asynchronous operation.</para>
	/// <para>This parameter can be <c>NULL</c> if an asynchronous operation is not used.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// <para>The following list identifies the possible error codes:</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The error message ERROR_LOG_BLOCK_INCOMPLETE is returned if the log block size specified by CreateLogMarshallingArea is not large
	/// enough to hold a complete log block.
	/// </para>
	/// <para>Typically, <c>ReadLogRestartArea</c> is used only during client restart, either after a crash or after a normal shutdown.</para>
	/// <para>If there is no restart area in the log, <c>ReadLogRestartArea</c> fails with the code <c>ERROR_LOG_NO_RESTART</c>.</para>
	/// <para>
	/// If <c>ReadLogRestartArea</c> fails with an error code of <c>ERROR_IO_PENDING</c>, a pointer to a valid read context is placed in the
	/// variable pointed to by the <c>ppvReadContext</c> parameter.
	/// </para>
	/// <para>
	/// To complete the log-record copy, the client should first synchronize its execution with deferred completion of the overlapped I/O
	/// operation by calling GetOverlappedResult, or one of the synchronization Wait Functions. For more information, see Synchronization and
	/// Overlapped Input and Output.
	/// </para>
	/// <para>
	/// After <c>ReadLogRestartArea</c> completes asynchronously, the requested restart area is read from the disk, but a valid pointer to it
	/// is not placed in <c>*ppvRestartBuffer</c>.
	/// </para>
	/// <para>
	/// To obtain a valid pointer, the client must call ReadPreviousLogRestartArea, which passes in the read-context pointer returned by <c>ReadLogRestartArea</c>.
	/// </para>
	/// <para>
	/// <c>Note</c> Common Log File System (CLFS) read contexts are not thread-safe. They should not be used by more than one thread at a time.
	/// <para></para>
	/// CLFS read contexts should not be passed into more than one asynchronous read at a time, or the function fails with ERROR_BUSY.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfsw32/nf-clfsw32-readlogrestartarea CLFSUSER_API BOOL ReadLogRestartArea( [in]
	// PVOID pvMarshal, [out] PVOID *ppvRestartBuffer, [out] PULONG pcbRestartBuffer, [out] PCLFS_LSN plsn, [out] PVOID *ppvContext, [in,
	// out, optional] LPOVERLAPPED pOverlapped );
	[DllImport(Lib_Clfsw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("clfsw32.h", MSDNShortId = "NF:clfsw32.ReadLogRestartArea")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ReadLogRestartArea([In] IntPtr pvMarshal, out IntPtr ppvRestartBuffer, [Out] IntPtr pcbRestartBuffer,
		out CLS_LSN plsn, out IntPtr ppvContext, ref NativeOverlapped pOverlapped);

	/// <summary>
	/// <para>
	/// Returns the last restart area that is written successfully to the log associated with the marshaling area of WriteLogRestartArea. The
	/// function also returns a read context that allows the caller to cursor backward or forward through a log from the restart record.
	/// </para>
	/// <para>This read context is useful when scanning through previous restart areas prior to the current one by invoking ReadPreviousLogRestartArea.</para>
	/// </summary>
	/// <param name="pvMarshal">A pointer to a marshaling context that is allocated by using the CreateLogMarshallingArea function.</param>
	/// <param name="ppvRestartBuffer">A pointer to a variable that receives a pointer to the restart data in the log I/O block.</param>
	/// <param name="pcbRestartBuffer">A pointer to a variable that receives the amount of restart data.</param>
	/// <param name="plsn">A pointer to a CLFS_LSN structure that receives the log sequence number (LSN) of the restart area.</param>
	/// <param name="ppvContext">
	/// <para>A pointer to a variable that receives a pointer to a system-allocated read context when a read is successful.</para>
	/// <para>
	/// If the function defers completion of an operation, it returns a valid read-context pointer and an error status of
	/// <c>ERROR_IO_PENDING</c>. On all other errors, the read-context pointer is <c>NULL</c>. For more information about handling deferred
	/// completion of the function, see the Remarks section of this topic.
	/// </para>
	/// <para>
	/// After obtaining all requested log records, the client must pass the read context to TerminateReadLog to free the associated memory.
	/// Failure to do so results in memory leakage.
	/// </para>
	/// <para>
	/// <c>Note</c> Common Log File System (CLFS) read contexts are not thread-safe. They should not be used by more than one thread at a
	/// time, or passed into more than one asynchronous read at a time.
	/// </para>
	/// </param>
	/// <param name="pOverlapped">
	/// <para>A pointer to an OVERLAPPED structure that is required for asynchronous operation.</para>
	/// <para>This parameter can be <c>NULL</c> if an asynchronous operation is not used.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// <para>The following list identifies the possible error codes:</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The error message ERROR_LOG_BLOCK_INCOMPLETE is returned if the log block size specified by CreateLogMarshallingArea is not large
	/// enough to hold a complete log block.
	/// </para>
	/// <para>Typically, <c>ReadLogRestartArea</c> is used only during client restart, either after a crash or after a normal shutdown.</para>
	/// <para>If there is no restart area in the log, <c>ReadLogRestartArea</c> fails with the code <c>ERROR_LOG_NO_RESTART</c>.</para>
	/// <para>
	/// If <c>ReadLogRestartArea</c> fails with an error code of <c>ERROR_IO_PENDING</c>, a pointer to a valid read context is placed in the
	/// variable pointed to by the <c>ppvReadContext</c> parameter.
	/// </para>
	/// <para>
	/// To complete the log-record copy, the client should first synchronize its execution with deferred completion of the overlapped I/O
	/// operation by calling GetOverlappedResult, or one of the synchronization Wait Functions. For more information, see Synchronization and
	/// Overlapped Input and Output.
	/// </para>
	/// <para>
	/// After <c>ReadLogRestartArea</c> completes asynchronously, the requested restart area is read from the disk, but a valid pointer to it
	/// is not placed in <c>*ppvRestartBuffer</c>.
	/// </para>
	/// <para>
	/// To obtain a valid pointer, the client must call ReadPreviousLogRestartArea, which passes in the read-context pointer returned by <c>ReadLogRestartArea</c>.
	/// </para>
	/// <para>
	/// <c>Note</c> Common Log File System (CLFS) read contexts are not thread-safe. They should not be used by more than one thread at a time.
	/// <para></para>
	/// CLFS read contexts should not be passed into more than one asynchronous read at a time, or the function fails with ERROR_BUSY.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfsw32/nf-clfsw32-readlogrestartarea CLFSUSER_API BOOL ReadLogRestartArea( [in]
	// PVOID pvMarshal, [out] PVOID *ppvRestartBuffer, [out] PULONG pcbRestartBuffer, [out] PCLFS_LSN plsn, [out] PVOID *ppvContext, [in,
	// out, optional] LPOVERLAPPED pOverlapped );
	[DllImport(Lib_Clfsw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("clfsw32.h", MSDNShortId = "NF:clfsw32.ReadLogRestartArea")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ReadLogRestartArea([In] IntPtr pvMarshal, out IntPtr ppvRestartBuffer, [Out] IntPtr pcbRestartBuffer,
		out CLS_LSN plsn, out IntPtr ppvContext, [In, Optional] IntPtr pOverlapped);

	/// <summary>
	/// Reads the next record in a sequence that is initiated by a call to ReadLogRecord or ReadLogRestartArea. By using
	/// <c>ReadNextLogRecord</c> iteratively, a client can read all records of a specified type in a log. The direction of enumeration is
	/// determined by specifying the context mode when beginning the read sequence.
	/// </summary>
	/// <param name="pvReadContext">
	/// <para>A pointer to a read context that the system allocates and creates during a successful call to ReadLogRecord or ReadLogRestartArea.</para>
	/// <para>
	/// If the function defers completion of an operation, it returns a pointer to a valid read context and an error status of
	/// <c>ERROR_IO_PENDING</c>. For information about handling asynchronous completion, see the Remarks section of this topic.
	/// </para>
	/// </param>
	/// <param name="ppvBuffer">A pointer to a variable that receives a pointer to the read data.</param>
	/// <param name="pcbBuffer">
	/// A pointer to a variable that receives the size of the read data that is returned in <c>ppvReadBuffer</c>, in bytes.
	/// </param>
	/// <param name="peRecordType">
	/// <para>
	/// A pointer that, on input, specifies the record type filter of the next record read, and on output specifies the record type that is returned.
	/// </para>
	/// <para>Clients can specify any of the following record types.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>ClfsDataRecord</c></term>
	/// <term>Only user-data records are read.</term>
	/// </item>
	/// <item>
	/// <term><c>ClfsRestartRecord</c></term>
	/// <term>Only restart records are read.</term>
	/// </item>
	/// <item>
	/// <term><c>ClfsClientRecord</c></term>
	/// <term>All restart and data records are read.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="plsnUser">
	/// <para>
	/// A pointer to a CLFS_LSN structure that specifies the log client to read this log sequence number (LSN) as the next LSN instead of
	/// reading forward to the next record, reading the previous LSN, or reading the next undo LSN.
	/// </para>
	/// <para>
	/// This parameter gives log clients the ability to cursor through user-defined LSN chains in client buffers. The relationship of this
	/// parameter to the current LSN held by the read context must be consistent with the context mode, <c>ecxMode</c>, that is specified in
	/// the ReadLogRecord entry points; otherwise, an error code of <c>ERROR_INVALID_PARAMETER</c> is returned.
	/// </para>
	/// </param>
	/// <param name="plsnUndoNext">A pointer to a CLFS_LSN structure that receives the LSN of the next record in an undo record chain.</param>
	/// <param name="plsnPrevious">A pointer to a CLFS_LSN structure that receives the LSN of the next record in the previous record chain.</param>
	/// <param name="plsnRecord">A pointer to a CLFS_LSN structure that receives the LSN of the current record read into the read context.</param>
	/// <param name="pOverlapped">
	/// <para>A pointer to an OVERLAPPED structure that is required for asynchronous operation.</para>
	/// <para>This parameter can be <c>NULL</c> if asynchronous operation is not used.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// <para>The following list identifies the possible error codes:</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If <c>ReadNextLogRecord</c> returns with a status code of <c>ERROR_IO_PENDING</c>, the client should synchronize its execution with
	/// deferred completion of the overlapped I/O operation by using GetOverlappedResult, or one of the synchronization Wait Functions. For
	/// more information, see Synchronization and Overlapped Input and Output.
	/// </para>
	/// <para>
	/// After <c>ReadNextLogRecord</c> completes asynchronously, the requested record is read from the disk, but is not resolved to a pointer
	/// in <c>*ppvReadBuffer</c>. To obtain a valid pointer to the record, the client must call <c>ReadNextLogRecord</c> a second time.
	/// </para>
	/// <para>
	/// <c>Note</c> Common Log File System (CLFS) read contexts are not thread-safe. They should not be used by more than one thread at a time.
	/// <para></para>
	/// CLFS read contexts should not be passed into more than one asynchronous read at a time, or the function fails with ERROR_READ.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfsw32/nf-clfsw32-readnextlogrecord CLFSUSER_API BOOL ReadNextLogRecord( [in, out]
	// PVOID pvReadContext, [out] PVOID *ppvBuffer, [out] PULONG pcbBuffer, [in, out] PCLFS_RECORD_TYPE peRecordType, [in, optional]
	// PCLFS_LSN plsnUser, [out] PCLFS_LSN plsnUndoNext, [out] PCLFS_LSN plsnPrevious, [out] PCLFS_LSN plsnRecord, [in, out, optional]
	// LPOVERLAPPED pOverlapped );
	[DllImport(Lib_Clfsw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("clfsw32.h", MSDNShortId = "NF:clfsw32.ReadNextLogRecord")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ReadNextLogRecord([In, Out] IntPtr pvReadContext, out IntPtr ppvBuffer, [Out] IntPtr pcbBuffer,
		ref CLS_RECORD_TYPE peRecordType, in CLS_LSN plsnUser, out CLS_LSN plsnUndoNext, out CLS_LSN plsnPrevious, out CLS_LSN plsnRecord,
		ref NativeOverlapped pOverlapped);

	/// <summary>
	/// Reads the next record in a sequence that is initiated by a call to ReadLogRecord or ReadLogRestartArea. By using
	/// <c>ReadNextLogRecord</c> iteratively, a client can read all records of a specified type in a log. The direction of enumeration is
	/// determined by specifying the context mode when beginning the read sequence.
	/// </summary>
	/// <param name="pvReadContext">
	/// <para>A pointer to a read context that the system allocates and creates during a successful call to ReadLogRecord or ReadLogRestartArea.</para>
	/// <para>
	/// If the function defers completion of an operation, it returns a pointer to a valid read context and an error status of
	/// <c>ERROR_IO_PENDING</c>. For information about handling asynchronous completion, see the Remarks section of this topic.
	/// </para>
	/// </param>
	/// <param name="ppvBuffer">A pointer to a variable that receives a pointer to the read data.</param>
	/// <param name="pcbBuffer">
	/// A pointer to a variable that receives the size of the read data that is returned in <c>ppvReadBuffer</c>, in bytes.
	/// </param>
	/// <param name="peRecordType">
	/// <para>
	/// A pointer that, on input, specifies the record type filter of the next record read, and on output specifies the record type that is returned.
	/// </para>
	/// <para>Clients can specify any of the following record types.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>ClfsDataRecord</c></term>
	/// <term>Only user-data records are read.</term>
	/// </item>
	/// <item>
	/// <term><c>ClfsRestartRecord</c></term>
	/// <term>Only restart records are read.</term>
	/// </item>
	/// <item>
	/// <term><c>ClfsClientRecord</c></term>
	/// <term>All restart and data records are read.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="plsnUser">
	/// <para>
	/// A pointer to a CLFS_LSN structure that specifies the log client to read this log sequence number (LSN) as the next LSN instead of
	/// reading forward to the next record, reading the previous LSN, or reading the next undo LSN.
	/// </para>
	/// <para>
	/// This parameter gives log clients the ability to cursor through user-defined LSN chains in client buffers. The relationship of this
	/// parameter to the current LSN held by the read context must be consistent with the context mode, <c>ecxMode</c>, that is specified in
	/// the ReadLogRecord entry points; otherwise, an error code of <c>ERROR_INVALID_PARAMETER</c> is returned.
	/// </para>
	/// </param>
	/// <param name="plsnUndoNext">A pointer to a CLFS_LSN structure that receives the LSN of the next record in an undo record chain.</param>
	/// <param name="plsnPrevious">A pointer to a CLFS_LSN structure that receives the LSN of the next record in the previous record chain.</param>
	/// <param name="plsnRecord">A pointer to a CLFS_LSN structure that receives the LSN of the current record read into the read context.</param>
	/// <param name="pOverlapped">
	/// <para>A pointer to an OVERLAPPED structure that is required for asynchronous operation.</para>
	/// <para>This parameter can be <c>NULL</c> if asynchronous operation is not used.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// <para>The following list identifies the possible error codes:</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If <c>ReadNextLogRecord</c> returns with a status code of <c>ERROR_IO_PENDING</c>, the client should synchronize its execution with
	/// deferred completion of the overlapped I/O operation by using GetOverlappedResult, or one of the synchronization Wait Functions. For
	/// more information, see Synchronization and Overlapped Input and Output.
	/// </para>
	/// <para>
	/// After <c>ReadNextLogRecord</c> completes asynchronously, the requested record is read from the disk, but is not resolved to a pointer
	/// in <c>*ppvReadBuffer</c>. To obtain a valid pointer to the record, the client must call <c>ReadNextLogRecord</c> a second time.
	/// </para>
	/// <para>
	/// <c>Note</c> Common Log File System (CLFS) read contexts are not thread-safe. They should not be used by more than one thread at a time.
	/// <para></para>
	/// CLFS read contexts should not be passed into more than one asynchronous read at a time, or the function fails with ERROR_READ.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfsw32/nf-clfsw32-readnextlogrecord CLFSUSER_API BOOL ReadNextLogRecord( [in, out]
	// PVOID pvReadContext, [out] PVOID *ppvBuffer, [out] PULONG pcbBuffer, [in, out] PCLFS_RECORD_TYPE peRecordType, [in, optional]
	// PCLFS_LSN plsnUser, [out] PCLFS_LSN plsnUndoNext, [out] PCLFS_LSN plsnPrevious, [out] PCLFS_LSN plsnRecord, [in, out, optional]
	// LPOVERLAPPED pOverlapped );
	[DllImport(Lib_Clfsw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("clfsw32.h", MSDNShortId = "NF:clfsw32.ReadNextLogRecord")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ReadNextLogRecord([In, Out] IntPtr pvReadContext, out IntPtr ppvBuffer, [Out] IntPtr pcbBuffer,
		ref CLS_RECORD_TYPE peRecordType, [In, Optional] IntPtr plsnUser, out CLS_LSN plsnUndoNext, out CLS_LSN plsnPrevious, out CLS_LSN plsnRecord,
		[In, Optional] IntPtr pOverlapped);

	/// <summary>
	/// Reads the previous log restart area that is relative to the current restart record specified in the read context,
	/// <c>pvReadContext</c>. This read context is the one previously created by a call to ReadLogRestartArea.
	/// </summary>
	/// <param name="pvReadContext">
	/// <para>A pointer to a system-allocated read context that ReadLogRestartArea returns.</para>
	/// <para>
	/// Even when those functions return <c>ERROR_IO_PENDING</c>, they still return a pointer to a valid read context. For information about
	/// asynchronous completion, see the Remarks section of this topic.
	/// </para>
	/// </param>
	/// <param name="ppvRestartBuffer">A pointer to a variable that receives a pointer to the restart data.</param>
	/// <param name="pcbRestartBuffer">
	/// A pointer to a variable that receives the size of the restart data at <c>*ppvRestartBuffer</c>, in bytes.
	/// </param>
	/// <param name="plsnRestart">
	/// A pointer to a CLFS_LSN structure that receives the log sequence number (LSN) of the restart area that this function returns.
	/// </param>
	/// <param name="pOverlapped">
	/// <para>A pointer to an OVERLAPPED structure that is required for asynchronous operation.</para>
	/// <para>This parameter can be <c>NULL</c> if asynchronous operation is not used.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// <para>The following list identifies the possible error codes:</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The error message ERROR_LOG_BLOCK_INCOMPLETE is returned if the log block size specified by CreateLogMarshallingArea is not large
	/// enough to hold a complete log block.
	/// </para>
	/// <para>
	/// If <c>ReadPreviousLogRestartArea</c> fails with an error code of <c>ERROR_IO_PENDING</c>, a pointer to a valid read context is placed
	/// in the variable that is pointed to by the <c>ppvReadContext</c> parameter.
	/// </para>
	/// <para>
	/// To complete the log-record copy, the client should first synchronize its execution with deferred completion of the overlapped I/O
	/// operation by using GetOverlappedResult or one of the synchronization Wait Functions. For more information, see Synchronization and
	/// Overlapped Input and Output.
	/// </para>
	/// <para>
	/// After <c>ReadPreviousLogRestartArea</c> completes asynchronously, the requested restart area is read from the disk, but a valid
	/// pointer to it is not placed in <c>*ppvRestartBuffer</c>.
	/// </para>
	/// <para>To obtain a valid pointer, the client must call <c>ReadPreviousLogRestartArea</c> a second time.</para>
	/// <para>
	/// <c>Note</c> Common Log File System (CLFS) read contexts are not thread-safe. They should not be used by more than one thread at a time.
	/// <para></para>
	/// CLFS read contexts should not be passed into more than one asynchronous read at a time, or the function fails with ERROR_READ.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfsw32/nf-clfsw32-readpreviouslogrestartarea CLFSUSER_API BOOL
	// ReadPreviousLogRestartArea( [in] PVOID pvReadContext, [out] PVOID *ppvRestartBuffer, [out] PULONG pcbRestartBuffer, [out] PCLFS_LSN
	// plsnRestart, [in, out, optional] LPOVERLAPPED pOverlapped );
	[DllImport(Lib_Clfsw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("clfsw32.h", MSDNShortId = "NF:clfsw32.ReadPreviousLogRestartArea")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ReadPreviousLogRestartArea([In] IntPtr pvReadContext, out IntPtr ppvRestartBuffer, [Out] IntPtr pcbRestartBuffer,
		out CLS_LSN plsnRestart, ref NativeOverlapped pOverlapped);

	/// <summary>
	/// Reads the previous log restart area that is relative to the current restart record specified in the read context,
	/// <c>pvReadContext</c>. This read context is the one previously created by a call to ReadLogRestartArea.
	/// </summary>
	/// <param name="pvReadContext">
	/// <para>A pointer to a system-allocated read context that ReadLogRestartArea returns.</para>
	/// <para>
	/// Even when those functions return <c>ERROR_IO_PENDING</c>, they still return a pointer to a valid read context. For information about
	/// asynchronous completion, see the Remarks section of this topic.
	/// </para>
	/// </param>
	/// <param name="ppvRestartBuffer">A pointer to a variable that receives a pointer to the restart data.</param>
	/// <param name="pcbRestartBuffer">
	/// A pointer to a variable that receives the size of the restart data at <c>*ppvRestartBuffer</c>, in bytes.
	/// </param>
	/// <param name="plsnRestart">
	/// A pointer to a CLFS_LSN structure that receives the log sequence number (LSN) of the restart area that this function returns.
	/// </param>
	/// <param name="pOverlapped">
	/// <para>A pointer to an OVERLAPPED structure that is required for asynchronous operation.</para>
	/// <para>This parameter can be <c>NULL</c> if asynchronous operation is not used.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// <para>The following list identifies the possible error codes:</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The error message ERROR_LOG_BLOCK_INCOMPLETE is returned if the log block size specified by CreateLogMarshallingArea is not large
	/// enough to hold a complete log block.
	/// </para>
	/// <para>
	/// If <c>ReadPreviousLogRestartArea</c> fails with an error code of <c>ERROR_IO_PENDING</c>, a pointer to a valid read context is placed
	/// in the variable that is pointed to by the <c>ppvReadContext</c> parameter.
	/// </para>
	/// <para>
	/// To complete the log-record copy, the client should first synchronize its execution with deferred completion of the overlapped I/O
	/// operation by using GetOverlappedResult or one of the synchronization Wait Functions. For more information, see Synchronization and
	/// Overlapped Input and Output.
	/// </para>
	/// <para>
	/// After <c>ReadPreviousLogRestartArea</c> completes asynchronously, the requested restart area is read from the disk, but a valid
	/// pointer to it is not placed in <c>*ppvRestartBuffer</c>.
	/// </para>
	/// <para>To obtain a valid pointer, the client must call <c>ReadPreviousLogRestartArea</c> a second time.</para>
	/// <para>
	/// <c>Note</c> Common Log File System (CLFS) read contexts are not thread-safe. They should not be used by more than one thread at a time.
	/// <para></para>
	/// CLFS read contexts should not be passed into more than one asynchronous read at a time, or the function fails with ERROR_READ.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfsw32/nf-clfsw32-readpreviouslogrestartarea CLFSUSER_API BOOL
	// ReadPreviousLogRestartArea( [in] PVOID pvReadContext, [out] PVOID *ppvRestartBuffer, [out] PULONG pcbRestartBuffer, [out] PCLFS_LSN
	// plsnRestart, [in, out, optional] LPOVERLAPPED pOverlapped );
	[DllImport(Lib_Clfsw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("clfsw32.h", MSDNShortId = "NF:clfsw32.ReadPreviousLogRestartArea")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ReadPreviousLogRestartArea([In] IntPtr pvReadContext, out IntPtr ppvRestartBuffer, [Out] IntPtr pcbRestartBuffer,
		out CLS_LSN plsnRestart, [In, Optional] IntPtr pOverlapped);

	/// <summary>
	/// <para>Removes one container from a log that is associated with a dedicated or multiplexed log handle.</para>
	/// <para>
	/// A client must have administrative privileges on the log handle to remove a container. To remove multiple containers, use the
	/// RemoveLogContainerSet function.
	/// </para>
	/// </summary>
	/// <param name="hLog">A handle to the log that is obtained from CreateLogFile.</param>
	/// <param name="pwszContainerPath">
	/// A pointer to a wide character string that contains a path for a log container that is created by either AddLogContainer or AddLogContainerSet.
	/// </param>
	/// <param name="fForce">
	/// <para>The deletion flag that determines when and how a container is deleted.</para>
	/// <para>
	/// If <c>fForce</c> is <c>TRUE</c>, and the container is part of the active log region, the container is not deleted and an error
	/// <c>ERROR_LOG_CANT_DELETE</c> is returned.
	/// </para>
	/// <para>If <c>FALSE</c>, the container is deleted when the container is no longer a part of the active log region.</para>
	/// </param>
	/// <param name="pReserved">This parameter is reserved and should be set to <c>NULL</c>.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// <para>The following list identifies the possible error codes:</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// By default, container deletion is lazy, which means that a container is deleted only if it is not part of an active log. If the
	/// container is part of the active log, it is marked for deletion. However, deletion does not occur until the end of the log exceeds the
	/// last sector of the container, or the container has a logical identifier that is greater than the logical identifier of the head of
	/// the active log. The log size reflects the container deletion only when the container is deleted physically.
	/// </para>
	/// <para>
	/// A log client can request a forced deletion on a container by setting the deletion flag to <c>TRUE</c>. This has the same effect as
	/// deleting a container that is not part of the active log. However, if the container is part of the active log, the call fails without
	/// marking the container for deletion.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfsw32/nf-clfsw32-removelogcontainer CLFSUSER_API BOOL RemoveLogContainer( [in]
	// HANDLE hLog, [in] LPWSTR pwszContainerPath, [in] BOOL fForce, [in, out, optional] LPVOID pReserved );
	[DllImport(Lib_Clfsw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("clfsw32.h", MSDNShortId = "NF:clfsw32.RemoveLogContainer")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool RemoveLogContainer([In] HLOG hLog, [MarshalAs(UnmanagedType.LPWStr)] string pwszContainerPath,
		[MarshalAs(UnmanagedType.Bool)] bool fForce, [In, Optional] IntPtr pReserved);

	/// <summary>
	/// <para>Removes multiple containers from a log that is associated with a dedicated or multiplexed log handle.</para>
	/// <para>
	/// A client must have administrative privileges on the log handle to remove a container. The RemoveLogContainer function is a special
	/// case of this <c>RemoveLogContainerSet</c> function, because it removes only one container. To remove multiple containers, use the <c>RemoveLogContainerSet</c>.
	/// </para>
	/// </summary>
	/// <param name="hLog">
	/// <para>A handle to the log that is obtained from CreateLogFile.</para>
	/// <para>
	/// The log handle must have administrative permission to add a log container, and can refer to either a dedicated or multiplexed log.
	/// </para>
	/// </param>
	/// <param name="cContainer">
	/// <para>The number of container path names in an array that is pointed to by <c>rgwszContainerPath</c>.</para>
	/// <para>This value must be nonzero.</para>
	/// </param>
	/// <param name="rgwszContainerPath">
	/// <para>An array of pointers to container path names that contain <c>cContainers</c> pointers.</para>
	/// <para>Each path name is a wide character string that identifies a container created by either AddLogContainer or AddLogContainerSet.</para>
	/// </param>
	/// <param name="fForce">
	/// <para>The deletion flag that determines when and how a container is deleted.</para>
	/// <para>
	/// If <c>fForce</c> is <c>TRUE</c>, and the container is part of the active log region, the container is not deleted and an error
	/// <c>ERROR_LOG_CANT_DELETE</c> is returned.
	/// </para>
	/// <para>If <c>FALSE</c>, the container is deleted when the container is no longer a part of the active log region.</para>
	/// </param>
	/// <param name="pReserved">Reserved. Set <c>pReserved</c> to <c>NULL</c>.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// <para>The following list identifies the possible error codes:</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// By default, container deletion is lazy, which means that a container is deleted only if it is not part of the active log. If the
	/// container is part of the active log it is marked for deletion. This deletion is deferred until the tail of the log exceeds the last
	/// sector of the container, or the container has a logical identifier that is greater than the logical identifier of the head of the
	/// active log. The log size reflects the container deletion only when the container is deleted physically.
	/// </para>
	/// <para>
	/// A log client can request a forced deletion on a container by setting the deletion flag to <c>TRUE</c>. This has the same effect as
	/// deleting a container that is not part of the active log. However, if a container is part of the active log, the call fails without
	/// marking the container for deletion.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfsw32/nf-clfsw32-removelogcontainerset CLFSUSER_API BOOL RemoveLogContainerSet(
	// [in] HANDLE hLog, [in] USHORT cContainer, [in] LPWSTR *rgwszContainerPath, [in] BOOL fForce, [in, out, optional] LPVOID pReserved );
	[DllImport(Lib_Clfsw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("clfsw32.h", MSDNShortId = "NF:clfsw32.RemoveLogContainerSet")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool RemoveLogContainerSet([In] HLOG hLog, [In] ushort cContainer,
		[In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPWStr, SizeParamIndex = 1)] string[] rgwszContainerPath,
		[MarshalAs(UnmanagedType.Bool)] bool fForce, [In, Optional] IntPtr pReserved);

	/// <summary>Reserves space for log buffers, or appends a log record to the log, or does both. The function is atomic.</summary>
	/// <param name="pvMarshal">A pointer to a marshaling context that is allocated by using the CreateLogMarshallingArea function.</param>
	/// <param name="rgWriteEntries">
	/// <para>A pointer to an array of CLFS_WRITE_ENTRY buffers to be marshaled into one record.</para>
	/// <para>This parameter is ignored if the <c>cWriteEntries</c> parameter is zero.</para>
	/// </param>
	/// <param name="cWriteEntries">
	/// <para>The number of write entries in the <c>rgWriteEntries</c> array.</para>
	/// <para>If this value is nonzero, you must specify a buffer in the <c>rgWriteEntries</c> parameter.</para>
	/// </param>
	/// <param name="plsnUndoNext">
	/// A pointer to a CLFS_LSN structure that specifies the log sequence number (LSN) of the next record in the undo-chain.
	/// </param>
	/// <param name="plsnPrevious">A pointer to a CLFS_LSN structure that specifies the LSN of the previous record in the previous-chain.</param>
	/// <param name="cReserveRecords">The number of record sizes in the <c>rgcbReservation</c> array.</param>
	/// <param name="rgcbReservation">
	/// <para>A pointer to an array of reservation sizes for each record that the <c>cReserveRecords</c> parameter specifies.</para>
	/// <para>
	/// This parameter is ignored if the <c>cReserveRecords</c> parameter is zero. If a reservation size is negative, a reservation of that
	/// size is released.
	/// </para>
	/// <para>
	/// The actual space that is reserved for each record, including required overhead, is returned in the individual array elements on
	/// successful completion. These values can be passed to the FreeReservedLog function to adjust space that is reserved in the marshaling area.
	/// </para>
	/// </param>
	/// <param name="fFlags">
	/// <para>The flags that specify the behavior of this function.</para>
	/// <para>One or more of the following values can be combined.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>CLFS_FLAG_FORCE_APPEND</c></term>
	/// <term>
	/// Assigns a physical location for all appended records in a log that have not been previously assigned a physical location. All these
	/// records are made available for reading from other marshaling contexts.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>CLFS_FLAG_FORCE_FLUSH</c></term>
	/// <term>
	/// Assigns a physical location for all appended records in a log that have not been previously assigned a physical location. All these
	/// records are made available for reading from other marshaling contexts. Then, the records are flushed to disk.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>CLFS_FLAG_NO_FLAGS</c></term>
	/// <term>Assigns no flags.</term>
	/// </item>
	/// <item>
	/// <term><c>CLFS_FLAG_USE_RESERVATION</c></term>
	/// <term>Appends the current record by using the space that is reserved in the marshaling area.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="plsn">A pointer to a CLFS_LSN structure that receives the LSN of the appended record.</param>
	/// <param name="pOverlapped">
	/// <para>A pointer to an OVERLAPPED structure.</para>
	/// <para>This parameter can be <c>NULL</c> if asynchronous operation is not used.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call the GetLastError function.</para>
	/// <para>The following list identifies the possible error codes:</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The LSN that is returned by the <c>ReserveAndAppendLog</c> function is not necessarily the next LSN that is used. The LSN that is
	/// returned is an estimate of the next LSN, and it varies based on which flags are specified by the <c>fFlags</c> parameter. The LSN
	/// that is returned can be used when moving the base tail. This LSN is invalidated by the next call to this function.
	/// </para>
	/// <para>
	/// If the <c>ReserveAndAppendLog</c> function returns <c>ERROR_LOG_FILE_FULL</c>, there is no more space in the log. This can be
	/// resolved in one of the following ways:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>Free any unneeded reservations.</term>
	/// </item>
	/// <item>
	/// <term>Advance the base LSN or the log archive tail, or both, to recycle containers.</term>
	/// </item>
	/// <item>
	/// <term>Add containers to the log.</term>
	/// </item>
	/// </list>
	/// <para>The CLFS Management API also provides a way to handle scenarios involving full logs.</para>
	/// <para>
	/// If the <c>ReserveAndAppendLog</c> function is called with a valid <c>pOverlapped</c> structure and the log handle is created with the
	/// overlapped option, then if a call to this function fails with an error code of <c>ERROR_IO_PENDING</c>, a pointer to a valid read
	/// context is placed in the variable that is pointed to by the <c>ppvReadContext</c> parameter.
	/// </para>
	/// <para>
	/// To complete the log record copy, the client should first synchronize its execution with deferred completion of the overlapped I/O
	/// operation by using the GetOverlappedResult function, or one of the synchronization Wait Functions. For more information, see
	/// Synchronization and Overlapped Input and Output.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfsw32/nf-clfsw32-reserveandappendlog CLFSUSER_API BOOL ReserveAndAppendLog( [in]
	// PVOID pvMarshal, [in, optional] PCLFS_WRITE_ENTRY rgWriteEntries, [in] ULONG cWriteEntries, [in, optional] PCLFS_LSN plsnUndoNext,
	// [in, optional] PCLFS_LSN plsnPrevious, [in] ULONG cReserveRecords, [in, out, optional] LONGLONG [] rgcbReservation, [in] ULONG fFlags,
	// [out, optional] PCLFS_LSN plsn, [in, out, optional] LPOVERLAPPED pOverlapped );
	[DllImport(Lib_Clfsw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("clfsw32.h", MSDNShortId = "NF:clfsw32.ReserveAndAppendLog")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ReserveAndAppendLog([In] IntPtr pvMarshal,
		[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] CLS_WRITE_ENTRY[]? rgWriteEntries,
		[In] uint cWriteEntries, in CLS_LSN plsnUndoNext, in CLS_LSN plsnPrevious, [In] uint cReserveRecords,
		[In, Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] long[]? rgcbReservation, [In] CLFS_FLAG fFlags,
		out CLS_LSN plsn, ref NativeOverlapped pOverlapped);

	/// <summary>Reserves space for log buffers, or appends a log record to the log, or does both. The function is atomic.</summary>
	/// <param name="pvMarshal">A pointer to a marshaling context that is allocated by using the CreateLogMarshallingArea function.</param>
	/// <param name="rgWriteEntries">
	/// <para>A pointer to an array of CLFS_WRITE_ENTRY buffers to be marshaled into one record.</para>
	/// <para>This parameter is ignored if the <c>cWriteEntries</c> parameter is zero.</para>
	/// </param>
	/// <param name="cWriteEntries">
	/// <para>The number of write entries in the <c>rgWriteEntries</c> array.</para>
	/// <para>If this value is nonzero, you must specify a buffer in the <c>rgWriteEntries</c> parameter.</para>
	/// </param>
	/// <param name="plsnUndoNext">
	/// A pointer to a CLFS_LSN structure that specifies the log sequence number (LSN) of the next record in the undo-chain.
	/// </param>
	/// <param name="plsnPrevious">A pointer to a CLFS_LSN structure that specifies the LSN of the previous record in the previous-chain.</param>
	/// <param name="cReserveRecords">The number of record sizes in the <c>rgcbReservation</c> array.</param>
	/// <param name="rgcbReservation">
	/// <para>A pointer to an array of reservation sizes for each record that the <c>cReserveRecords</c> parameter specifies.</para>
	/// <para>
	/// This parameter is ignored if the <c>cReserveRecords</c> parameter is zero. If a reservation size is negative, a reservation of that
	/// size is released.
	/// </para>
	/// <para>
	/// The actual space that is reserved for each record, including required overhead, is returned in the individual array elements on
	/// successful completion. These values can be passed to the FreeReservedLog function to adjust space that is reserved in the marshaling area.
	/// </para>
	/// </param>
	/// <param name="fFlags">
	/// <para>The flags that specify the behavior of this function.</para>
	/// <para>One or more of the following values can be combined.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>CLFS_FLAG_FORCE_APPEND</c></term>
	/// <term>
	/// Assigns a physical location for all appended records in a log that have not been previously assigned a physical location. All these
	/// records are made available for reading from other marshaling contexts.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>CLFS_FLAG_FORCE_FLUSH</c></term>
	/// <term>
	/// Assigns a physical location for all appended records in a log that have not been previously assigned a physical location. All these
	/// records are made available for reading from other marshaling contexts. Then, the records are flushed to disk.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>CLFS_FLAG_NO_FLAGS</c></term>
	/// <term>Assigns no flags.</term>
	/// </item>
	/// <item>
	/// <term><c>CLFS_FLAG_USE_RESERVATION</c></term>
	/// <term>Appends the current record by using the space that is reserved in the marshaling area.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="plsn">A pointer to a CLFS_LSN structure that receives the LSN of the appended record.</param>
	/// <param name="pOverlapped">
	/// <para>A pointer to an OVERLAPPED structure.</para>
	/// <para>This parameter can be <c>NULL</c> if asynchronous operation is not used.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call the GetLastError function.</para>
	/// <para>The following list identifies the possible error codes:</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The LSN that is returned by the <c>ReserveAndAppendLog</c> function is not necessarily the next LSN that is used. The LSN that is
	/// returned is an estimate of the next LSN, and it varies based on which flags are specified by the <c>fFlags</c> parameter. The LSN
	/// that is returned can be used when moving the base tail. This LSN is invalidated by the next call to this function.
	/// </para>
	/// <para>
	/// If the <c>ReserveAndAppendLog</c> function returns <c>ERROR_LOG_FILE_FULL</c>, there is no more space in the log. This can be
	/// resolved in one of the following ways:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>Free any unneeded reservations.</term>
	/// </item>
	/// <item>
	/// <term>Advance the base LSN or the log archive tail, or both, to recycle containers.</term>
	/// </item>
	/// <item>
	/// <term>Add containers to the log.</term>
	/// </item>
	/// </list>
	/// <para>The CLFS Management API also provides a way to handle scenarios involving full logs.</para>
	/// <para>
	/// If the <c>ReserveAndAppendLog</c> function is called with a valid <c>pOverlapped</c> structure and the log handle is created with the
	/// overlapped option, then if a call to this function fails with an error code of <c>ERROR_IO_PENDING</c>, a pointer to a valid read
	/// context is placed in the variable that is pointed to by the <c>ppvReadContext</c> parameter.
	/// </para>
	/// <para>
	/// To complete the log record copy, the client should first synchronize its execution with deferred completion of the overlapped I/O
	/// operation by using the GetOverlappedResult function, or one of the synchronization Wait Functions. For more information, see
	/// Synchronization and Overlapped Input and Output.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfsw32/nf-clfsw32-reserveandappendlog CLFSUSER_API BOOL ReserveAndAppendLog( [in]
	// PVOID pvMarshal, [in, optional] PCLFS_WRITE_ENTRY rgWriteEntries, [in] ULONG cWriteEntries, [in, optional] PCLFS_LSN plsnUndoNext,
	// [in, optional] PCLFS_LSN plsnPrevious, [in] ULONG cReserveRecords, [in, out, optional] LONGLONG [] rgcbReservation, [in] ULONG fFlags,
	// [out, optional] PCLFS_LSN plsn, [in, out, optional] LPOVERLAPPED pOverlapped );
	[DllImport(Lib_Clfsw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("clfsw32.h", MSDNShortId = "NF:clfsw32.ReserveAndAppendLog")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ReserveAndAppendLog([In] IntPtr pvMarshal,
		[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] CLS_WRITE_ENTRY[]? rgWriteEntries,
		[In] uint cWriteEntries, [In, Optional] IntPtr plsnUndoNext, [In, Optional] IntPtr plsnPrevious, [In] uint cReserveRecords,
		[In, Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] long[]? rgcbReservation, [In] CLFS_FLAG fFlags,
		out CLS_LSN plsn, [In, Optional] IntPtr pOverlapped);

	/// <summary>
	/// Reserves space for log buffers, or appends a log record to the log, or both. This function is like the ReserveAndAppendLog function,
	/// but <c>ReserveAndAppendLogAligned</c> aligns the write entries of the record to the specified byte alignment.
	/// </summary>
	/// <param name="pvMarshal">A pointer to a marshaling context that is allocated by using the CreateLogMarshallingArea function.</param>
	/// <param name="rgWriteEntries">
	/// <para>A pointer to an array of CLFS_WRITE_ENTRY buffers to be marshaled into one record.</para>
	/// <para>This parameter is ignored if the <c>cWriteEntries</c> parameter is zero.</para>
	/// </param>
	/// <param name="cWriteEntries">
	/// <para>The number of write entries in the <c>rgWriteEntries</c> array.</para>
	/// <para>If this value is nonzero, you must specify a buffer in the <c>rgWriteEntries</c> parameter.</para>
	/// </param>
	/// <param name="cbEntryAlignment">
	/// <para>The byte alignment for each write entry in the <c>rgWriteEntries</c> parameter.</para>
	/// <para>Specify 1 (one) for a simple concatenation. The <c>cbWriteEntryAlignment</c> parameter must be nonzero.</para>
	/// </param>
	/// <param name="plsnUndoNext">
	/// A pointer to a CLFS_LSN structure that specifies the log sequence number (LSN) of the next record in the undo-chain.
	/// </param>
	/// <param name="plsnPrevious">A pointer to a CLFS_LSN structure that specifies the LSN of the previous record in the previous-chain.</param>
	/// <param name="cReserveRecords">The number of record sizes in the <c>rgcbReservation</c> array.</param>
	/// <param name="rgcbReservation">
	/// <para>A pointer to an array of reservation sizes for each record that the <c>cReserveRecords</c> parameter specifies.</para>
	/// <para>
	/// This parameter is ignored if the <c>cReserveRecords</c> parameter is zero. If a reservation size is negative, a reservation of that
	/// size is released.
	/// </para>
	/// <para>
	/// The actual space that is reserved for each record, including required overhead, is returned in the individual array elements on
	/// successful completion. These values can be passed to the FreeReservedLog function to adjust space that is reserved in the marshaling area.
	/// </para>
	/// </param>
	/// <param name="fFlags">
	/// <para>The flags that specify the behavior of this function.</para>
	/// <para>One or more of the following values can be combined.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>CLFS_FLAG_FORCE_APPEND</c></term>
	/// <term>
	/// Assigns a physical location for all appended records in the log that are not previously assigned a physical location. All these
	/// records are made available for reading from other marshaling contexts.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>CLFS_FLAG_FORCE_FLUSH</c></term>
	/// <term>
	/// Assigns a physical location for all appended records in the log that are not previously assigned a physical location. All these
	/// records are made available for reading from other marshaling contexts. Then, the records are flushed to disk.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>CLFS_FLAG_NO_FLAGS</c></term>
	/// <term>Assigns no flags.</term>
	/// </item>
	/// <item>
	/// <term><c>CLFS_FLAG_USE_RESERVATION</c></term>
	/// <term>Appends the current record by using the space that is reserved in the marshaling area.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="plsn">A pointer to a CLFS_LSN structure that receives the LSN of the appended record.</param>
	/// <param name="pOverlapped">
	/// <para>A pointer to an OVERLAPPED structure.</para>
	/// <para>This parameter can be <c>NULL</c> if asynchronous operation is not used.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>
	/// If the function fails, the return value is zero. To get extended error information, call the GetLastError function. The following
	/// list identifies the possible error codes:
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The LSN that is returned by the <c>ReserveAndAppendLogAligned</c> function is not necessarily the next LSN that is used. The LSN that
	/// is returned is an estimate of the next LSN, and it varies based on which flags are specified by the <c>fFlags</c> parameter. The LSN
	/// that is returned can be used when moving the base tail. This LSN is invalidated by the next call to this function.
	/// </para>
	/// <para>
	/// If the <c>ReserveAndAppendLogAligned</c> function returns <c>ERROR_LOG_FILE_FULL</c>, there is no more space in the log. This can be
	/// resolved in one of the following ways:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>Free any unneeded reservations.</term>
	/// </item>
	/// <item>
	/// <term>Advance the base LSN or the log archive tail, or both, to recycle containers.</term>
	/// </item>
	/// <item>
	/// <term>Add containers to the log.</term>
	/// </item>
	/// </list>
	/// <para>The CLFS Management API also provides a way to handle scenarios involving full logs.</para>
	/// <para>
	/// If the <c>ReserveAndAppendLogAligned</c> function is called with a valid <c>overlapped</c> structure and the log handle is created
	/// with the overlapped option, then if a call to this function fails with an error code of <c>ERROR_IO_PENDING</c>, a pointer to a valid
	/// read context is placed in the variable that is pointed to by the <c>ppvReadContext</c> parameter.
	/// </para>
	/// <para>
	/// To complete the log-record copy, the client should first synchronize its execution with deferred completion of the overlapped I/O
	/// operation by using the GetOverlappedResult function or one of the synchronization Wait Functions. For more information, see
	/// Synchronization and Overlapped Input and Output.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfsw32/nf-clfsw32-reserveandappendlogaligned CLFSUSER_API BOOL
	// ReserveAndAppendLogAligned( [in] PVOID pvMarshal, [in, optional] PCLFS_WRITE_ENTRY rgWriteEntries, [in] ULONG cWriteEntries, [in]
	// ULONG cbEntryAlignment, [in, optional] PCLFS_LSN plsnUndoNext, [in, optional] PCLFS_LSN plsnPrevious, [in] ULONG cReserveRecords, [in,
	// out, optional] LONGLONG [] rgcbReservation, [in] ULONG fFlags, [out, optional] PCLFS_LSN plsn, [in, out, optional] LPOVERLAPPED
	// pOverlapped );
	[DllImport(Lib_Clfsw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("clfsw32.h", MSDNShortId = "NF:clfsw32.ReserveAndAppendLogAligned")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ReserveAndAppendLogAligned([In] IntPtr pvMarshal,
		[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] CLS_WRITE_ENTRY[]? rgWriteEntries,
		[In] uint cWriteEntries, [In] uint cbEntryAlignment, in CLS_LSN plsnUndoNext, in CLS_LSN plsnPrevious, [In] uint cReserveRecords,
		[In, Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 6)] long[]? rgcbReservation, [In] CLFS_FLAG fFlags,
		out CLS_LSN plsn, ref NativeOverlapped pOverlapped);

	/// <summary>
	/// Reserves space for log buffers, or appends a log record to the log, or both. This function is like the ReserveAndAppendLog function,
	/// but <c>ReserveAndAppendLogAligned</c> aligns the write entries of the record to the specified byte alignment.
	/// </summary>
	/// <param name="pvMarshal">A pointer to a marshaling context that is allocated by using the CreateLogMarshallingArea function.</param>
	/// <param name="rgWriteEntries">
	/// <para>A pointer to an array of CLFS_WRITE_ENTRY buffers to be marshaled into one record.</para>
	/// <para>This parameter is ignored if the <c>cWriteEntries</c> parameter is zero.</para>
	/// </param>
	/// <param name="cWriteEntries">
	/// <para>The number of write entries in the <c>rgWriteEntries</c> array.</para>
	/// <para>If this value is nonzero, you must specify a buffer in the <c>rgWriteEntries</c> parameter.</para>
	/// </param>
	/// <param name="cbEntryAlignment">
	/// <para>The byte alignment for each write entry in the <c>rgWriteEntries</c> parameter.</para>
	/// <para>Specify 1 (one) for a simple concatenation. The <c>cbWriteEntryAlignment</c> parameter must be nonzero.</para>
	/// </param>
	/// <param name="plsnUndoNext">
	/// A pointer to a CLFS_LSN structure that specifies the log sequence number (LSN) of the next record in the undo-chain.
	/// </param>
	/// <param name="plsnPrevious">A pointer to a CLFS_LSN structure that specifies the LSN of the previous record in the previous-chain.</param>
	/// <param name="cReserveRecords">The number of record sizes in the <c>rgcbReservation</c> array.</param>
	/// <param name="rgcbReservation">
	/// <para>A pointer to an array of reservation sizes for each record that the <c>cReserveRecords</c> parameter specifies.</para>
	/// <para>
	/// This parameter is ignored if the <c>cReserveRecords</c> parameter is zero. If a reservation size is negative, a reservation of that
	/// size is released.
	/// </para>
	/// <para>
	/// The actual space that is reserved for each record, including required overhead, is returned in the individual array elements on
	/// successful completion. These values can be passed to the FreeReservedLog function to adjust space that is reserved in the marshaling area.
	/// </para>
	/// </param>
	/// <param name="fFlags">
	/// <para>The flags that specify the behavior of this function.</para>
	/// <para>One or more of the following values can be combined.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>CLFS_FLAG_FORCE_APPEND</c></term>
	/// <term>
	/// Assigns a physical location for all appended records in the log that are not previously assigned a physical location. All these
	/// records are made available for reading from other marshaling contexts.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>CLFS_FLAG_FORCE_FLUSH</c></term>
	/// <term>
	/// Assigns a physical location for all appended records in the log that are not previously assigned a physical location. All these
	/// records are made available for reading from other marshaling contexts. Then, the records are flushed to disk.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>CLFS_FLAG_NO_FLAGS</c></term>
	/// <term>Assigns no flags.</term>
	/// </item>
	/// <item>
	/// <term><c>CLFS_FLAG_USE_RESERVATION</c></term>
	/// <term>Appends the current record by using the space that is reserved in the marshaling area.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="plsn">A pointer to a CLFS_LSN structure that receives the LSN of the appended record.</param>
	/// <param name="pOverlapped">
	/// <para>A pointer to an OVERLAPPED structure.</para>
	/// <para>This parameter can be <c>NULL</c> if asynchronous operation is not used.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>
	/// If the function fails, the return value is zero. To get extended error information, call the GetLastError function. The following
	/// list identifies the possible error codes:
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The LSN that is returned by the <c>ReserveAndAppendLogAligned</c> function is not necessarily the next LSN that is used. The LSN that
	/// is returned is an estimate of the next LSN, and it varies based on which flags are specified by the <c>fFlags</c> parameter. The LSN
	/// that is returned can be used when moving the base tail. This LSN is invalidated by the next call to this function.
	/// </para>
	/// <para>
	/// If the <c>ReserveAndAppendLogAligned</c> function returns <c>ERROR_LOG_FILE_FULL</c>, there is no more space in the log. This can be
	/// resolved in one of the following ways:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>Free any unneeded reservations.</term>
	/// </item>
	/// <item>
	/// <term>Advance the base LSN or the log archive tail, or both, to recycle containers.</term>
	/// </item>
	/// <item>
	/// <term>Add containers to the log.</term>
	/// </item>
	/// </list>
	/// <para>The CLFS Management API also provides a way to handle scenarios involving full logs.</para>
	/// <para>
	/// If the <c>ReserveAndAppendLogAligned</c> function is called with a valid <c>overlapped</c> structure and the log handle is created
	/// with the overlapped option, then if a call to this function fails with an error code of <c>ERROR_IO_PENDING</c>, a pointer to a valid
	/// read context is placed in the variable that is pointed to by the <c>ppvReadContext</c> parameter.
	/// </para>
	/// <para>
	/// To complete the log-record copy, the client should first synchronize its execution with deferred completion of the overlapped I/O
	/// operation by using the GetOverlappedResult function or one of the synchronization Wait Functions. For more information, see
	/// Synchronization and Overlapped Input and Output.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfsw32/nf-clfsw32-reserveandappendlogaligned CLFSUSER_API BOOL
	// ReserveAndAppendLogAligned( [in] PVOID pvMarshal, [in, optional] PCLFS_WRITE_ENTRY rgWriteEntries, [in] ULONG cWriteEntries, [in]
	// ULONG cbEntryAlignment, [in, optional] PCLFS_LSN plsnUndoNext, [in, optional] PCLFS_LSN plsnPrevious, [in] ULONG cReserveRecords, [in,
	// out, optional] LONGLONG [] rgcbReservation, [in] ULONG fFlags, [out, optional] PCLFS_LSN plsn, [in, out, optional] LPOVERLAPPED
	// pOverlapped );
	[DllImport(Lib_Clfsw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("clfsw32.h", MSDNShortId = "NF:clfsw32.ReserveAndAppendLogAligned")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ReserveAndAppendLogAligned([In] IntPtr pvMarshal,
		[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] CLS_WRITE_ENTRY[]? rgWriteEntries,
		[In] uint cWriteEntries, [In] uint cbEntryAlignment, [In, Optional] IntPtr plsnUndoNext, [In, Optional] IntPtr plsnPrevious,
		[In] uint cReserveRecords, [In, Out, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 6)] long[]? rgcbReservation,
		[In] CLFS_FLAG fFlags, out CLS_LSN plsn, [In, Optional] IntPtr pOverlapped);

	/// <summary>Enumerates log containers. Call this function repeatedly to iterate over all log containers.</summary>
	/// <param name="pcxScan">
	/// A pointer to a client-allocated CLFS_SCAN_CONTEXT structure that the CreateLogContainerScanContext function initializes.
	/// </param>
	/// <param name="eScanMode">
	/// <para>The mode for containers to be scanned.</para>
	/// <para>Containers can be scanned in any of the following CLFS_SCAN_MODE modes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>CLFS_SCAN_INIT</c></term>
	/// <term>
	/// Reinitializes the scan context, but does not allocate associated storage. The initialization is destructive, because all data that is
	/// stored in the current scan context is lost.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>CLFS_SCAN_CLOSE</c></term>
	/// <term>Uninitializes the scan context, and deallocates system storage that is associated with a scan context.</term>
	/// </item>
	/// <item>
	/// <term><c>CLFS_SCAN_FORWARD</c></term>
	/// <term>
	/// Causes the next call to <c>ScanLogContainers</c> to proceed in a forward direction. Cannot be used if <c>CLFS_SCAN_BACKWARD</c> is specified.
	/// </term>
	/// </item>
	/// <item>
	/// <term><c>CLFS_SCAN_BACKWARD</c></term>
	/// <term>
	/// Causes the next call to <c>ScanLogContainers</c> to proceed in a backward direction. Cannot be used if <c>CLFS_SCAN_FORWARD</c> is specified.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pReserved">Reserved. Set <c>pReserved</c> to <c>NULL</c>.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// <para>The following list identifies the possible error codes:</para>
	/// </returns>
	/// <remarks>
	/// <para>The ID of a log container is returned in: <c>pcxScan-&gt;pinfoContainer-&gt;LogicalContainerId</c>.</para>
	/// <para>
	/// <c>Note</c> The Common Log File System (CLFS) scan contexts are not thread-safe. They should not be used by more than one thread at a
	/// time, or passed into more than one asynchronous scan at a time.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example that uses this function, see Enumerating Log Containers.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfsw32/nf-clfsw32-scanlogcontainers CLFSUSER_API BOOL ScanLogContainers( [in, out]
	// PCLFS_SCAN_CONTEXT pcxScan, [in] CLFS_SCAN_MODE eScanMode, [in, out, optional] LPVOID pReserved );
	[DllImport(Lib_Clfsw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("clfsw32.h", MSDNShortId = "NF:clfsw32.ScanLogContainers")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ScanLogContainers(ref CLS_SCAN_CONTEXT pcxScan, [In] CLFS_SCAN_MODE eScanMode, [In, Optional] IntPtr pReserved);

	/// <summary>This function has been deprecated. Use TruncateLog instead.</summary>
	/// <param name="hLog">
	/// <para>A handle to the log that is obtained from CreateLogFile.</para>
	/// <para>The log handle must refer to a dedicated log.</para>
	/// </param>
	/// <param name="plsnEnd">
	/// <para>A pointer to a CLFS_LSN structure that specifies the new end of a log.</para>
	/// <para>The LSN must be between the base log sequence number (LSN) of the log and the last LSN of the log.</para>
	/// </param>
	/// <param name="lpOverlapped">Reserved. Set <c>lpOverlapped</c> to <c>NULL</c>.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>
	/// If the function fails, the return value is zero. To get extended error information, call GetLastError. The following list identifies
	/// the possible error codes:
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>SetEndOfLog</c> function truncates the log by setting the end of the log to the specified value. This operation only works on
	/// dedicated logs.
	/// </para>
	/// <para><c>SetEndOfLog</c> can only be used to truncate a log.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfsw32/nf-clfsw32-setendoflog CLFSUSER_API BOOL SetEndOfLog( [in] HANDLE hLog,
	// [in] PCLFS_LSN plsnEnd, [in, out, optional] LPOVERLAPPED lpOverlapped );
	[DllImport(Lib_Clfsw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("clfsw32.h", MSDNShortId = "NF:clfsw32.SetEndOfLog")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetEndOfLog([In] HLOG hLog, in CLS_LSN plsnEnd, [In, Optional] IntPtr lpOverlapped);

	/// <summary>Enables or disables log archive support for a specified log.</summary>
	/// <param name="hLog">A handle to the log that is obtained from CreateLogFile.</param>
	/// <param name="eMode">
	/// <para>Specifies whether to make the log ephemeral. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>ClfsLogArchiveEnabled</c></term>
	/// <term>Enable log archive (ephemeral logs) support.</term>
	/// </item>
	/// <item>
	/// <term><c>ClfsLogArchiveDisabled</c></term>
	/// <term>Disables ephemeral logs.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero (0). To get extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfsw32/nf-clfsw32-setlogarchivemode CLFSUSER_API BOOL SetLogArchiveMode( [in]
	// HANDLE hLog, [in] CLFS_LOG_ARCHIVE_MODE eMode );
	[DllImport(Lib_Clfsw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("clfsw32.h", MSDNShortId = "NF:clfsw32.SetLogArchiveMode")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetLogArchiveMode([In] HLOG hLog, [In] CLFS_LOG_ARCHIVE_MODE eMode);

	/// <summary>Sets the last archived log sequence number (LSN) or <c>archive tail</c> of an archivable log.</summary>
	/// <param name="hLog">
	/// <para>A handle to the log that is obtained from CreateLogFile.</para>
	/// <para>The log handle can refer to a dedicated or multiplexed log.</para>
	/// </param>
	/// <param name="plsnArchiveTail">
	/// <para>A pointer to a CLFS_LSN structure that specifies a valid physical LSN in the log.</para>
	/// <para>
	/// <c>Note</c> For handles to both a physical log or a log stream, <c>plsnArchiveTail</c> is a physical LSN, because it refers to a
	/// record address in the physical log.
	/// </para>
	/// </param>
	/// <param name="pReserved">This parameter is reserved and should be set to <c>NULL</c>.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// <para>The following list identifies the possible error codes:</para>
	/// </returns>
	/// <remarks>
	/// If there are any archive contexts obtained from PrepareLogArchive that are not terminated with TerminateLogArchive, the change does
	/// not take effect until all archives are complete. While there are outstanding archive contexts, only the greatest archive tail is applied.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfsw32/nf-clfsw32-setlogarchivetail CLFSUSER_API BOOL SetLogArchiveTail( [in]
	// HANDLE hLog, [in] PCLFS_LSN plsnArchiveTail, [in, out, optional] LPVOID pReserved );
	[DllImport(Lib_Clfsw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("clfsw32.h", MSDNShortId = "NF:clfsw32.SetLogArchiveTail")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetLogArchiveTail([In] HLOG hLog, in CLS_LSN plsnArchiveTail, [In, Optional] IntPtr pReserved);

	/// <summary>Deallocates system resources that are allocated originally for a log archive context by PrepareLogArchive.</summary>
	/// <param name="pvArchiveContext">The archive context that is obtained from PrepareLogArchive.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>
	/// If the function fails, the return value is zero. To get extended error information, call GetLastError. The following error code is possible:
	/// </para>
	/// </returns>
	/// <remarks>Failure to call this function after archiving completes results in a resource leak.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfsw32/nf-clfsw32-terminatelogarchive CLFSUSER_API BOOL TerminateLogArchive( [in]
	// CLFS_LOG_ARCHIVE_CONTEXT pvArchiveContext );
	[DllImport(Lib_Clfsw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("clfsw32.h", MSDNShortId = "NF:clfsw32.TerminateLogArchive")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool TerminateLogArchive([In] IntPtr pvArchiveContext);

	/// <summary>
	/// Terminates a read context. This function frees system-allocated resources associated with the specified read context. Do not attempt
	/// to read log records after calling this function; you will receive indeterminate results.
	/// </summary>
	/// <param name="pvCursorContext">A pointer to a read context that is returned by ReadLogRecord or ReadLogRestartArea.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>
	/// If the function fails, the return value is zero. To get extended error information, call GetLastError. The following list identifies
	/// the possible error codes:
	/// </para>
	/// </returns>
	/// <remarks>It is important to deallocate unused read contexts. Failure to call this function causes resource leaks.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfsw32/nf-clfsw32-terminatereadlog CLFSUSER_API BOOL TerminateReadLog( [in] PVOID
	// pvCursorContext );
	[DllImport(Lib_Clfsw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("clfsw32.h", MSDNShortId = "NF:clfsw32.TerminateReadLog")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool TerminateReadLog([In] IntPtr pvCursorContext);

	/// <summary>Truncates the log. The function sets the end of the log to the specified value.</summary>
	/// <param name="pvMarshal">A pointer to the opaque marshaling context that is allocated by calling the CreateLogMarshallingArea function.</param>
	/// <param name="plsnEnd">
	/// <para>A pointer to a CLFS_LSN structure that specifies the new end of a log.</para>
	/// <para>The LSN must be between the base log sequence number (LSN) of the log and the last LSN of the log.</para>
	/// </param>
	/// <param name="lpOverlapped">Reserved. Set <c>Reserved</c> to <c>NULL</c>.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>
	/// If the function fails, the return value is zero. To get extended error information, call GetLastError. The following list identifies
	/// the possible error codes:
	/// </para>
	/// </returns>
	/// <remarks>If the volume sector size is greater than 512 bytes, <c>TruncateLog</c> returns ERROR_NOT_SUPPORTED.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfsw32/nf-clfsw32-truncatelog CLFSUSER_API BOOL TruncateLog( [in] PVOID pvMarshal,
	// [in] PCLFS_LSN plsnEnd, [in, out, optional] LPOVERLAPPED lpOverlapped );
	[DllImport(Lib_Clfsw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("clfsw32.h", MSDNShortId = "NF:clfsw32.TruncateLog")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool TruncateLog([In] IntPtr pvMarshal, in CLS_LSN plsnEnd, [In, Optional] IntPtr lpOverlapped);

	/// <summary>Validates the consistency of the log metadata and data before log archive and after log restore.</summary>
	/// <param name="pszLogFileName">
	/// <para>The name of the log.</para>
	/// <para>The name is specified when creating the log by using CreateLogFile. The following example identifies the format to use:</para>
	/// <para><c>Log</c><c>:&lt;</c><c>LogName</c><c>&gt;[::&lt;</c><c>LogStreamName</c><c>&gt;]</c></para>
	/// <para><c>&lt;</c><c>LogName</c><c>&gt;</c> corresponds to a valid file path in the file system.</para>
	/// <para><c>&lt;</c><c>LogStreamName</c><c>&gt;</c> is the unique name of a log stream in the dedicated log.</para>
	/// <para>For more information, see Log Types.</para>
	/// </param>
	/// <param name="psaLogFile">
	/// <para>A pointer to a SECURITY_ATTRIBUTES structure that specifies the security attributes of a log.</para>
	/// <para>This parameter can be <c>NULL</c>.</para>
	/// </param>
	/// <param name="pinfoBuffer">A pointer to a CLFS_INFORMATION structure that receives log metadata.</param>
	/// <param name="pcbBuffer">
	/// <para>A pointer to a variable that, on input, specifies the size of the <c>pinfoBuffer</c> metadata buffer, in bytes.</para>
	/// <para>On output, it receives the amount of information that is copied to the buffer, in bytes.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// <para>The following list identifies the possible error codes:</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfsw32/nf-clfsw32-validatelog CLFSUSER_API BOOL ValidateLog( [in] LPCWSTR
	// pszLogFileName, [in, optional] LPSECURITY_ATTRIBUTES psaLogFile, [out, optional] PCLFS_INFORMATION pinfoBuffer, [in, out] PULONG
	// pcbBuffer );
	[DllImport(Lib_Clfsw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("clfsw32.h", MSDNShortId = "NF:clfsw32.ValidateLog")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ValidateLog([MarshalAs(UnmanagedType.LPWStr)] string pszLogFileName, [In, Optional] SECURITY_ATTRIBUTES? psaLogFile,
		[Out] IntPtr pinfoBuffer, ref uint pcbBuffer);

	/// <summary>
	/// <para>Appends a new client restart area to a log, and optionally advances the base log sequence number (LSN) of the log.</para>
	/// <para>
	/// After it is successfully written to a disk, the last LSN of the log is changed to the LSN of the appended restart record. Typically,
	/// <c>WriteLogRestartArea</c> is used by applications that regularly save a known good state, and the restart area contains the LSNs for
	/// existing log record chains.
	/// </para>
	/// </summary>
	/// <param name="pvMarshal">A pointer to the marshaling context that is allocated by using the CreateLogMarshallingArea function.</param>
	/// <param name="pvRestartBuffer">A pointer to a buffer that contains restart data.</param>
	/// <param name="cbRestartBuffer">The size of <c>pvRestartBuffer</c>, in bytes.</param>
	/// <param name="plsnBase">
	/// <para>A pointer to a CLFS_LSN structure that specifies the new base LSN of the log after successfully writing the restart area.</para>
	/// <para>
	/// This value cannot be outside the range of the active log. It must be at least the value of the current base LSN, and not greater than
	/// the LSN that was returned in the <c>lastLSN</c> parameter from the latest call to ReserveAndAppendLog. If you omit this optional
	/// parameter, the base LSN does not change.
	/// </para>
	/// </param>
	/// <param name="fFlags">
	/// <para>The flags that specify the behavior of this function.</para>
	/// <para>One or more of the following values can be combined.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>CLFS_FLAG_NO_FLAGS</c></term>
	/// <term>Assigns no flags.</term>
	/// </item>
	/// <item>
	/// <term><c>CLFS_FLAG_USE_RESERVATION</c></term>
	/// <term>Appends the current record by using the space that is reserved in the marshaling area.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pcbWritten">A pointer to a variable that receives the number of bytes that are written when an operation completes.</param>
	/// <param name="plsnNext">A pointer to a CLFS_LSN structure that specifies the LSN of the restart area that is written.</param>
	/// <param name="pOverlapped">
	/// <para>A pointer to an OVERLAPPED structure.</para>
	/// <para>This parameter can be <c>NULL</c> if an asynchronous operation is not used.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// <para>The following list identifies the possible error codes:</para>
	/// </returns>
	/// <remarks>
	/// <para>The <c>WriteLogRestartArea</c> causes both a flush of all current buffered log records and a flush of the log metadata.</para>
	/// <para>
	/// If a client calls <c>WriteLogRestartArea</c> on a log that is created to support asynchronous operations (for example, if the
	/// <c>fFlagsAndAttributes</c> parameter of CreateLogFile is set to <c>FILE_FLAG_OVERLAPPED</c> when the log is created), the client must
	/// supply a pointer to a valid OVERLAPPED structure in the <c>pOverlapped</c> parameter of <c>WriteLogRestartArea</c>.
	/// </para>
	/// <para>
	/// Then, if <c>WriteLogRestartArea</c> fails with an error of <c>ERROR_IO_PENDING</c>, a pointer to a valid read context is placed in
	/// the variable that is pointed to by the <c>ppvReadContext</c> parameter.
	/// </para>
	/// <para>
	/// To complete the call, the client should synchronize its execution with deferred completion of the overlapped I/O operation by using
	/// GetOverlappedResult or one of the synchronization Wait Functions. For more information, see Synchronization and Overlapped Input and Output.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfsw32/nf-clfsw32-writelogrestartarea CLFSUSER_API BOOL WriteLogRestartArea( [in,
	// out] PVOID pvMarshal, [in] PVOID pvRestartBuffer, [in] ULONG cbRestartBuffer, [in, optional] PCLFS_LSN plsnBase, [in] ULONG fFlags,
	// [out, optional] PULONG pcbWritten, [out, optional] PCLFS_LSN plsnNext, [in, out, optional] LPOVERLAPPED pOverlapped );
	[DllImport(Lib_Clfsw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("clfsw32.h", MSDNShortId = "NF:clfsw32.WriteLogRestartArea")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool WriteLogRestartArea([In, Out] IntPtr pvMarshal, [In] IntPtr pvRestartBuffer, [In] uint cbRestartBuffer,
		in CLS_LSN plsnBase, [In] CLFS_FLAG fFlags, out uint pcbWritten, out CLS_LSN plsnNext, ref NativeOverlapped pOverlapped);

	/// <summary>
	/// <para>Appends a new client restart area to a log, and optionally advances the base log sequence number (LSN) of the log.</para>
	/// <para>
	/// After it is successfully written to a disk, the last LSN of the log is changed to the LSN of the appended restart record. Typically,
	/// <c>WriteLogRestartArea</c> is used by applications that regularly save a known good state, and the restart area contains the LSNs for
	/// existing log record chains.
	/// </para>
	/// </summary>
	/// <param name="pvMarshal">A pointer to the marshaling context that is allocated by using the CreateLogMarshallingArea function.</param>
	/// <param name="pvRestartBuffer">A pointer to a buffer that contains restart data.</param>
	/// <param name="cbRestartBuffer">The size of <c>pvRestartBuffer</c>, in bytes.</param>
	/// <param name="plsnBase">
	/// <para>A pointer to a CLFS_LSN structure that specifies the new base LSN of the log after successfully writing the restart area.</para>
	/// <para>
	/// This value cannot be outside the range of the active log. It must be at least the value of the current base LSN, and not greater than
	/// the LSN that was returned in the <c>lastLSN</c> parameter from the latest call to ReserveAndAppendLog. If you omit this optional
	/// parameter, the base LSN does not change.
	/// </para>
	/// </param>
	/// <param name="fFlags">
	/// <para>The flags that specify the behavior of this function.</para>
	/// <para>One or more of the following values can be combined.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>CLFS_FLAG_NO_FLAGS</c></term>
	/// <term>Assigns no flags.</term>
	/// </item>
	/// <item>
	/// <term><c>CLFS_FLAG_USE_RESERVATION</c></term>
	/// <term>Appends the current record by using the space that is reserved in the marshaling area.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pcbWritten">A pointer to a variable that receives the number of bytes that are written when an operation completes.</param>
	/// <param name="plsnNext">A pointer to a CLFS_LSN structure that specifies the LSN of the restart area that is written.</param>
	/// <param name="pOverlapped">
	/// <para>A pointer to an OVERLAPPED structure.</para>
	/// <para>This parameter can be <c>NULL</c> if an asynchronous operation is not used.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// <para>The following list identifies the possible error codes:</para>
	/// </returns>
	/// <remarks>
	/// <para>The <c>WriteLogRestartArea</c> causes both a flush of all current buffered log records and a flush of the log metadata.</para>
	/// <para>
	/// If a client calls <c>WriteLogRestartArea</c> on a log that is created to support asynchronous operations (for example, if the
	/// <c>fFlagsAndAttributes</c> parameter of CreateLogFile is set to <c>FILE_FLAG_OVERLAPPED</c> when the log is created), the client must
	/// supply a pointer to a valid OVERLAPPED structure in the <c>pOverlapped</c> parameter of <c>WriteLogRestartArea</c>.
	/// </para>
	/// <para>
	/// Then, if <c>WriteLogRestartArea</c> fails with an error of <c>ERROR_IO_PENDING</c>, a pointer to a valid read context is placed in
	/// the variable that is pointed to by the <c>ppvReadContext</c> parameter.
	/// </para>
	/// <para>
	/// To complete the call, the client should synchronize its execution with deferred completion of the overlapped I/O operation by using
	/// GetOverlappedResult or one of the synchronization Wait Functions. For more information, see Synchronization and Overlapped Input and Output.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfsw32/nf-clfsw32-writelogrestartarea CLFSUSER_API BOOL WriteLogRestartArea( [in,
	// out] PVOID pvMarshal, [in] PVOID pvRestartBuffer, [in] ULONG cbRestartBuffer, [in, optional] PCLFS_LSN plsnBase, [in] ULONG fFlags,
	// [out, optional] PULONG pcbWritten, [out, optional] PCLFS_LSN plsnNext, [in, out, optional] LPOVERLAPPED pOverlapped );
	[DllImport(Lib_Clfsw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("clfsw32.h", MSDNShortId = "NF:clfsw32.WriteLogRestartArea")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool WriteLogRestartArea([In, Out] IntPtr pvMarshal, [In] IntPtr pvRestartBuffer, [In] uint cbRestartBuffer,
		[In, Optional] IntPtr plsnBase, [In] CLFS_FLAG fFlags, out uint pcbWritten, out CLS_LSN plsnNext, [In, Optional] IntPtr pOverlapped);

	/// <summary>Provides a <see cref="SafeHandle"/> for an archive context that is disposed using <see cref="TerminateLogArchive"/>.</summary>
	[AutoSafeHandle("TerminateLogArchive(handle)")]
	public partial class SafeArchiveContext { }
}