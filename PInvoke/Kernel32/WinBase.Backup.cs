using System.Collections.Generic;

namespace Vanara.PInvoke;

public static partial class Kernel32
{
	/// <summary>Type of data in a <see cref="WIN32_STREAM_ID"/>.</summary>
	[PInvokeData("winbase.h", MSDNShortId = "NS:winbase._WIN32_STREAM_ID")]
	[Flags]
	public enum BACKUP_STREAM_ATTR : uint
	{
		/// <summary>This backup stream has no special attributes.</summary>
		STREAM_NORMAL_ATTRIBUTE = 0x00000000,

		/// <summary>
		/// Attribute set if the stream contains data that is modified when read. Allows the backup application to know that verification of
		/// data will fail.
		/// </summary>
		STREAM_MODIFIED_WHEN_READ = 0x00000001,

		/// <summary>Stream contains security data (general attributes). Allows the stream to be ignored on cross-operations restore.</summary>
		STREAM_CONTAINS_SECURITY = 0x00000002,

		/// <summary>The stream contains properties.</summary>
		STREAM_CONTAINS_PROPERTIES = 0x00000004,

		/// <summary>
		/// The backup stream is part of a sparse file stream. This attribute applies only to backup stream of type DATA, ALTERNATE_DATA, and SPARSE_BLOCK.
		/// </summary>
		STREAM_SPARSE_ATTRIBUTE = 0x00000008,

		/// <summary>The backup stream contains ghosted extents. This attribute applies only to backup stream of type DATA.</summary>
		STREAM_CONTAINS_GHOSTED_FILE_EXTENTS = 0x00000010,
	}

	/// <summary>Type of data in a <see cref="WIN32_STREAM_ID"/>.</summary>
	[PInvokeData("winbase.h", MSDNShortId = "NS:winbase._WIN32_STREAM_ID")]
	public enum BACKUP_STREAM_ID : uint
	{
		/// <summary>The backup type is invalid.</summary>
		BACKUP_INVALID = 0x00000000,

		/// <summary>Standard data. This corresponds to the NTFS $DATA stream type on the default (unnamed) data stream.</summary>
		BACKUP_DATA = 0x00000001,

		/// <summary>Extended attribute data. This corresponds to the NTFS $EA stream type.</summary>
		BACKUP_EA_DATA = 0x00000002,

		/// <summary>Security descriptor data.</summary>
		BACKUP_SECURITY_DATA = 0x00000003,

		/// <summary>Alternative data streams. This corresponds to the NTFS $DATA stream type on a named data stream.</summary>
		BACKUP_ALTERNATE_DATA = 0x00000004,

		/// <summary>Hard link information. This corresponds to the NTFS $FILE_NAME stream type.</summary>
		BACKUP_LINK = 0x00000005,

		/// <summary>Property data.</summary>
		BACKUP_PROPERTY_DATA = 0x00000006,

		/// <summary>Objects identifiers. This corresponds to the NTFS $OBJECT_ID stream type.</summary>
		BACKUP_OBJECT_ID = 0x00000007,

		/// <summary>Reparse points. This corresponds to the NTFS $REPARSE_POINT stream type.</summary>
		BACKUP_REPARSE_DATA = 0x00000008,

		/// <summary>Sparse file. This corresponds to the NTFS $DATA stream type for a sparse file.</summary>
		BACKUP_SPARSE_BLOCK = 0x00000009,

		/// <summary>
		/// Transactional NTFS (TxF) data stream. This corresponds to the NTFS $TXF_DATA stream type. <c>Windows Server 2003 and
		/// Windows XP:  </c> This value is not supported.
		/// </summary>
		BACKUP_TXFS_DATA = 0x0000000a,

		/// <summary>Ghosted extents.</summary>
		BACKUP_GHOSTED_FILE_EXTENTS = 0x0000000b,
	}

	/// <summary>Erasing technique.</summary>
	public enum TAPE_ERASE_TYPE
	{
		/// <summary>Erases the tape from the current position to the end of the current partition.</summary>
		TAPE_ERASE_LONG = 1,

		/// <summary>Writes an erase gap or end-of-data marker at the current position.</summary>
		TAPE_ERASE_SHORT = 0,
	}

	/// <summary>High-order bits of the device features flag.</summary>
	[Flags]
	public enum TAPE_FEATURES_HIGH : uint
	{
		/// <summary>The device moves the tape to a device-specific block address and returns as soon as the move begins.</summary>
		TAPE_DRIVE_ABS_BLK_IMMED = 0x80002000,

		/// <summary>The device moves the tape to a device specific block address.</summary>
		TAPE_DRIVE_ABSOLUTE_BLK = 0x80001000,

		/// <summary>The device moves the tape to the end-of-data marker in a partition.</summary>
		TAPE_DRIVE_END_OF_DATA = 0x80010000,

		/// <summary>The device moves the tape forward (or backward) a specified number of filemarks.</summary>
		TAPE_DRIVE_FILEMARKS = 0x80040000,

		/// <summary>The device enables and disables the device for further operations.</summary>
		TAPE_DRIVE_LOAD_UNLOAD = 0x80000001,

		/// <summary>The device supports immediate load and unload operations.</summary>
		TAPE_DRIVE_LOAD_UNLD_IMMED = 0x80000020,

		/// <summary>The device enables and disables the tape ejection mechanism.</summary>
		TAPE_DRIVE_LOCK_UNLOCK = 0x80000004,

		/// <summary>The device supports immediate lock and unlock operations.</summary>
		TAPE_DRIVE_LOCK_UNLK_IMMED = 0x80000080,

		/// <summary>The device moves the tape to a logical block address in a partition and returns as soon as the move begins.</summary>
		TAPE_DRIVE_LOG_BLK_IMMED = 0x80008000,

		/// <summary>The device moves the tape to a logical block address in a partition.</summary>
		TAPE_DRIVE_LOGICAL_BLK = 0x80004000,

		/// <summary>The device moves the tape forward (or backward) a specified number of blocks.</summary>
		TAPE_DRIVE_RELATIVE_BLKS = 0x80020000,

		/// <summary>The device moves the tape backward over blocks, filemarks, or setmarks.</summary>
		TAPE_DRIVE_REVERSE_POSITION = 0x80400000,

		/// <summary>The device supports immediate rewind operation.</summary>
		TAPE_DRIVE_REWIND_IMMEDIATE = 0x80000008,

		/// <summary>The device moves the tape forward (or backward) to the first occurrence of a specified number of consecutive filemarks.</summary>
		TAPE_DRIVE_SEQUENTIAL_FMKS = 0x80080000,

		/// <summary>The device moves the tape forward (or backward) to the first occurrence of a specified number of consecutive setmarks.</summary>
		TAPE_DRIVE_SEQUENTIAL_SMKS = 0x80200000,

		/// <summary>The device supports setting the size of a fixed-length logical block or setting the variable-length block mode.</summary>
		TAPE_DRIVE_SET_BLOCK_SIZE = 0x80000010,

		/// <summary>The device enables and disables hardware data compression.</summary>
		TAPE_DRIVE_SET_COMPRESSION = 0x80000200,

		/// <summary>The device enables and disables hardware error correction.</summary>
		TAPE_DRIVE_SET_ECC = 0x80000100,

		/// <summary>The device enables and disables data padding.</summary>
		TAPE_DRIVE_SET_PADDING = 0x80000400,

		/// <summary>The device enables and disables the reporting of setmarks.</summary>
		TAPE_DRIVE_SET_REPORT_SMKS = 0x80000800,

		/// <summary>The device moves the tape forward (or reverse) a specified number of setmarks.</summary>
		TAPE_DRIVE_SETMARKS = 0x80100000,

		/// <summary>The device supports immediate spacing.</summary>
		TAPE_DRIVE_SPACE_IMMEDIATE = 0x80800000,

		/// <summary>The device supports tape tensioning.</summary>
		TAPE_DRIVE_TENSION = 0x80000002,

		/// <summary>The device supports immediate tape tensioning.</summary>
		TAPE_DRIVE_TENSION_IMMED = 0x80000040,

		/// <summary>The device writes filemarks.</summary>
		TAPE_DRIVE_WRITE_FILEMARKS = 0x82000000,

		/// <summary>The device writes long filemarks.</summary>
		TAPE_DRIVE_WRITE_LONG_FMKS = 0x88000000,

		/// <summary>The device supports immediate writing of short and long filemarks.</summary>
		TAPE_DRIVE_WRITE_MARK_IMMED = 0x90000000,

		/// <summary>The device writes setmarks.</summary>
		TAPE_DRIVE_WRITE_SETMARKS = 0x81000000,

		/// <summary>The device writes short filemarks.</summary>
		TAPE_DRIVE_WRITE_SHORT_FMKS = 0x84000000,
	}

	/// <summary>Low-order bits of the device features flag.</summary>
	[Flags]
	public enum TAPE_FEATURES_LOW : uint
	{
		/// <summary>The device supports hardware data compression.</summary>
		TAPE_DRIVE_COMPRESSION = 0x00020000,

		/// <summary>The device can report if cleaning is required.</summary>
		TAPE_DRIVE_CLEAN_REQUESTS = 0x02000000,

		/// <summary>The device supports hardware error correction.</summary>
		TAPE_DRIVE_ECC = 0x00010000,

		/// <summary>The device physically ejects the tape on a software eject.</summary>
		TAPE_DRIVE_EJECT_MEDIA = 0x01000000,

		/// <summary>The device performs the erase operation from the beginning-of-partition marker only.</summary>
		TAPE_DRIVE_ERASE_BOP_ONLY = 0x00000040,

		/// <summary>The device performs a long erase operation.</summary>
		TAPE_DRIVE_ERASE_LONG = 0x00000020,

		/// <summary>The device performs an immediate erase operation — that is, it returns when the erase operation begins.</summary>
		TAPE_DRIVE_ERASE_IMMEDIATE = 0x00000080,

		/// <summary>The device performs a short erase operation.</summary>
		TAPE_DRIVE_ERASE_SHORT = 0x00000010,

		/// <summary>The device creates fixed data partitions.</summary>
		TAPE_DRIVE_FIXED = 0x00000001,

		/// <summary>The device supports fixed-length block mode.</summary>
		TAPE_DRIVE_FIXED_BLOCK = 0x00000400,

		/// <summary>The device provides the current device-specific block address.</summary>
		TAPE_DRIVE_GET_ABSOLUTE_BLK = 0x00100000,

		/// <summary>The device provides the current logical block address (and logical tape partition).</summary>
		TAPE_DRIVE_GET_LOGICAL_BLK = 0x00200000,

		/// <summary>The device creates initiator-defined partitions.</summary>
		TAPE_DRIVE_INITIATOR = 0x00000004,

		/// <summary>The device supports data padding.</summary>
		TAPE_DRIVE_PADDING = 0x00040000,

		/// <summary>The device supports setmark reporting.</summary>
		TAPE_DRIVE_REPORT_SMKS = 0x00080000,

		/// <summary>The device creates select data partitions.</summary>
		TAPE_DRIVE_SELECT = 0x00000002,

		/// <summary>The device must be at the beginning of a partition before it can set compression on.</summary>
		TAPE_DRIVE_SET_CMP_BOP_ONLY = 0x04000000,

		/// <summary>The device supports setting the end-of-medium warning size.</summary>
		TAPE_DRIVE_SET_EOT_WZ_SIZE = 0x00400000,

		/// <summary>The device returns the maximum capacity of the tape.</summary>
		TAPE_DRIVE_TAPE_CAPACITY = 0x00000100,

		/// <summary>The device returns the remaining capacity of the tape.</summary>
		TAPE_DRIVE_TAPE_REMAINING = 0x00000200,

		/// <summary>The device supports variable-length block mode.</summary>
		TAPE_DRIVE_VARIABLE_BLOCK = 0x00000800,

		/// <summary>The device returns an error if the tape is write-enabled or write-protected.</summary>
		TAPE_DRIVE_WRITE_PROTECT = 0x00001000,
	}

	/// <summary>Type of information requested.</summary>
	public enum TAPE_PARAM_OP
	{
		/// <summary>Retrieves information about the tape in the tape device.</summary>
		[CorrespondingType(typeof(TAPE_GET_MEDIA_PARAMETERS), CorrespondingAction.Get)]
		GET_TAPE_MEDIA_INFORMATION = 0,

		/// <summary>Retrieves information about the tape device.</summary>
		[CorrespondingType(typeof(TAPE_GET_DRIVE_PARAMETERS), CorrespondingAction.Get)]
		GET_TAPE_DRIVE_INFORMATION = 1,

		/// <summary>Sets the tape-specific information specified by the lpTapeInformation parameter.</summary>
		[CorrespondingType(typeof(TAPE_GET_MEDIA_PARAMETERS), CorrespondingAction.Set)]
		SET_TAPE_MEDIA_INFORMATION = 0,

		/// <summary>Sets the device-specific information specified by lpTapeInformation.</summary>
		[CorrespondingType(typeof(TAPE_GET_DRIVE_PARAMETERS), CorrespondingAction.Set)]
		SET_TAPE_DRIVE_INFORMATION = 1
	}

	/// <summary>Type of partition to create.</summary>
	public enum TAPE_PARTITION_METHOD
	{
		/// <summary>
		/// Partitions the tape based on the device's default definition of partitions. The dwCount and dwSize parameters are ignored.
		/// </summary>
		TAPE_FIXED_PARTITIONS = 0,

		/// <summary>
		/// Partitions the tape into the number and size of partitions specified by dwCount and dwSize, respectively, except for the last
		/// partition. The size of the last partition is the remainder of the tape.
		/// </summary>
		TAPE_INITIATOR_PARTITIONS = 2,

		/// <summary>
		/// Partitions the tape into the number of partitions specified by dwCount. The dwSize parameter is ignored. The size of the
		/// partitions is determined by the device's default partition size. For more specific information, see the documentation for your
		/// tape device.
		/// </summary>
		TAPE_SELECT_PARTITIONS = 1
	}

	/// <summary>Type of positioning to perform.</summary>
	public enum TAPE_POS_METHOD
	{
		/// <summary>
		/// Moves the tape to the device-specific block address specified by the dwOffsetLow and dwOffsetHigh parameters. The dwPartition
		/// parameter is ignored.
		/// </summary>
		TAPE_ABSOLUTE_BLOCK = 1,

		/// <summary>Moves the tape to the block address specified by dwOffsetLow and dwOffsetHigh in the partition specified by dwPartition.</summary>
		TAPE_LOGICAL_BLOCK = 2,

		/// <summary>
		/// Moves the tape to the beginning of the current partition. The dwPartition, dwOffsetLow, and dwOffsetHigh parameters are ignored.
		/// </summary>
		TAPE_REWIND = 0,

		/// <summary>Moves the tape to the end of the data on the partition specified by dwPartition.</summary>
		TAPE_SPACE_END_OF_DATA = 4,

		/// <summary>
		/// Moves the tape forward (or backward) the number of filemarks specified by dwOffsetLow and dwOffsetHigh in the current partition.
		/// The dwPartition parameter is ignored.
		/// </summary>
		TAPE_SPACE_FILEMARKS = 6,

		/// <summary>
		/// Moves the tape forward (or backward) the number of blocks specified by dwOffsetLow and dwOffsetHigh in the current partition. The
		/// dwPartition parameter is ignored.
		/// </summary>
		TAPE_SPACE_RELATIVE_BLOCKS = 5,

		/// <summary>
		/// Moves the tape forward (or backward) to the first occurrence of n filemarks in the current partition, where n is the number
		/// specified by dwOffsetLow and dwOffsetHigh. The dwPartition parameter is ignored.
		/// </summary>
		TAPE_SPACE_SEQUENTIAL_FMKS = 7,

		/// <summary>
		/// Moves the tape forward (or backward) to the first occurrence of n setmarks in the current partition, where n is the number
		/// specified by dwOffsetLow and dwOffsetHigh. The dwPartition parameter is ignored.
		/// </summary>
		TAPE_SPACE_SEQUENTIAL_SMKS = 9,

		/// <summary>
		/// Moves the tape forward (or backward) the number of setmarks specified by dwOffsetLow and dwOffsetHigh in the current partition.
		/// The dwPartition parameter is ignored.
		/// </summary>
		TAPE_SPACE_SETMARKS = 8,
	}

	/// <summary>Type of address to obtain.</summary>
	public enum TAPE_POS_TYPE
	{
		/// <summary>
		/// The lpdwOffsetLow and lpdwOffsetHigh parameters receive the device-specific block address. The dwPartition parameter receives zero.
		/// </summary>
		TAPE_ABSOLUTE_POSITION = 0,

		/// <summary>
		/// The lpdwOffsetLow and lpdwOffsetHigh parameters receive the logical block address. The dwPartition parameter receives the logical
		/// tape partition.
		/// </summary>
		TAPE_LOGICAL_POSITION = 1
	}

	/// <summary>Tape device preparation.</summary>
	public enum TAPE_PREP_OP
	{
		/// <summary>Performs a low-level format of the tape. Currently, only the QIC117 device supports this feature.</summary>
		TAPE_FORMAT = 5,

		/// <summary>Loads the tape and moves the tape to the beginning.</summary>
		TAPE_LOAD = 0,

		/// <summary>Locks the tape ejection mechanism so that the tape is not ejected accidentally.</summary>
		TAPE_LOCK = 3,

		/// <summary>
		/// Adjusts the tension by moving the tape to the end of the tape and back to the beginning. This option is not supported by all
		/// devices. This value is ignored if it is not supported.
		/// </summary>
		TAPE_TENSION = 2,

		/// <summary>
		/// Moves the tape to the beginning for removal from the device. After a successful unload operation, the device returns errors to
		/// applications that attempt to access the tape, until the tape is loaded again.
		/// </summary>
		TAPE_UNLOAD = 1,

		/// <summary>Unlocks the tape ejection mechanism.</summary>
		TAPE_UNLOCK = 4,
	}

	/// <summary>Type of tapemarks to write.</summary>
	public enum TAPEMARK_TYPE
	{
		/// <summary>Writes the number of filemarks specified by the dwTapemarkCount parameter.</summary>
		TAPE_FILEMARKS = 1,

		/// <summary>Writes the number of long filemarks specified by dwTapemarkCount.</summary>
		TAPE_LONG_FILEMARKS = 3,

		/// <summary>Writes the number of setmarks specified by dwTapemarkCount.</summary>
		TAPE_SETMARKS = 0,

		/// <summary>Writes the number of short filemarks specified by dwTapemarkCount.</summary>
		TAPE_SHORT_FILEMARKS = 2,
	}

	/// <summary>
	/// The <c>BackupRead</c> function can be used to back up a file or directory, including the security information. The function reads
	/// data associated with a specified file or directory into a buffer, which can then be written to the backup medium using the
	/// <c>WriteFile</c> function.
	/// </summary>
	/// <param name="hFile">
	/// <para>
	/// Handle to the file or directory to be backed up. To obtain the handle, call the <c>CreateFile</c> function. The SACLs are not read
	/// unless the file handle was created with the <c>ACCESS_SYSTEM_SECURITY</c> access right. For more information, see File Security and
	/// Access Rights.
	/// </para>
	/// <para>
	/// The handle must be synchronous (nonoverlapped). This means that the FILE_FLAG_OVERLAPPED flag must not be set when <c>CreateFile</c>
	/// is called. This function does not validate that the handle it receives is synchronous, so it does not return an error code for a
	/// synchronous handle, but calling it with an asynchronous (overlapped) handle can result in subtle errors that are very difficult to debug.
	/// </para>
	/// <para>
	/// The <c>BackupRead</c> function may fail if <c>CreateFile</c> was called with the flag <c>FILE_FLAG_NO_BUFFERING</c>. In this case,
	/// the <c>GetLastError</c> function returns the value <c>ERROR_INVALID_PARAMETER</c>.
	/// </para>
	/// </param>
	/// <param name="lpBuffer">Pointer to a buffer that receives the data.</param>
	/// <param name="nNumberOfBytesToRead">
	/// Length of the buffer, in bytes. The buffer size must be greater than the size of a <c>WIN32_STREAM_ID</c> structure.
	/// </param>
	/// <param name="lpNumberOfBytesRead">
	/// <para>Pointer to a variable that receives the number of bytes read.</para>
	/// <para>
	/// If the function returns a nonzero value, and the variable pointed to by lpNumberOfBytesRead is zero, then all the data associated
	/// with the file handle has been read.
	/// </para>
	/// </param>
	/// <param name="bAbort">
	/// Indicates whether you have finished using <c>BackupRead</c> on the handle. While you are backing up the file, specify this parameter
	/// as <c>FALSE</c>. Once you are done using <c>BackupRead</c>, you must call <c>BackupRead</c> one more time specifying <c>TRUE</c> for
	/// this parameter and passing the appropriate lpContext. lpContext must be passed when bAbort is <c>TRUE</c>; all other parameters are ignored.
	/// </param>
	/// <param name="bProcessSecurity">
	/// <para>Indicates whether the function will restore the access-control list (ACL) data for the file or directory.</para>
	/// <para>If bProcessSecurity is <c>TRUE</c>, the ACL data will be backed up.</para>
	/// </param>
	/// <param name="lpContext">
	/// <para>
	/// Pointer to a variable that receives a pointer to an internal data structure used by <c>BackupRead</c> to maintain context information
	/// during a backup operation.
	/// </para>
	/// <para>
	/// You must set the variable pointed to by lpContext to <c>NULL</c> before the first call to <c>BackupRead</c> for the specified file or
	/// directory. The function allocates memory for the data structure, and then sets the variable to point to that structure. You must not
	/// change lpContext or the variable that it points to between calls to <c>BackupRead</c>.
	/// </para>
	/// <para>
	/// To release the memory used by the data structure, call <c>BackupRead</c> with the bAbort parameter set to <c>TRUE</c> when the backup
	/// operation is complete.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>
	/// If the function fails, the return value is zero, indicating that an I/O error occurred. To get extended error information, call <c>GetLastError</c>.
	/// </para>
	/// </returns>
	// BOOL BackupRead( _In_ HANDLE hFile, _Out_ LPBYTE lpBuffer, _In_ DWORD nNumberOfBytesToRead, _Out_ LPDWORD lpNumberOfBytesRead, _In_
	// BOOL bAbort, _In_ BOOL bProcessSecurity, _Out_ LPVOID *lpContext); https://msdn.microsoft.com/en-us/library/windows/desktop/aa362509(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("Winbase.h", MSDNShortId = "aa362509")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool BackupRead([In] HFILE hFile, IntPtr lpBuffer, uint nNumberOfBytesToRead, out uint lpNumberOfBytesRead, [MarshalAs(UnmanagedType.Bool)] bool bAbort,
		[MarshalAs(UnmanagedType.Bool)] bool bProcessSecurity, ref IntPtr lpContext);

	/// <summary>
	/// The <c>BackupRead</c> function can be used to back up a file or directory, including the security information. The function reads
	/// data associated with a specified file or directory into a buffer, which can then be written to the backup medium using the
	/// <c>WriteFile</c> function.
	/// <para>This method appropriately closes the read operation after reading all the streams.</para>
	/// </summary>
	/// <param name="hFile">
	/// <para>
	/// Handle to the file or directory to be backed up. To obtain the handle, call the <c>CreateFile</c> function. The SACLs are not read
	/// unless the file handle was created with the <c>ACCESS_SYSTEM_SECURITY</c> access right. For more information, see File Security and
	/// Access Rights.
	/// </para>
	/// <para>
	/// The handle must be synchronous (nonoverlapped). This means that the FILE_FLAG_OVERLAPPED flag must not be set when <c>CreateFile</c>
	/// is called. This function does not validate that the handle it receives is synchronous, so it does not return an error code for a
	/// synchronous handle, but calling it with an asynchronous (overlapped) handle can result in subtle errors that are very difficult to debug.
	/// </para>
	/// <para>
	/// The <c>BackupRead</c> function may fail if <c>CreateFile</c> was called with the flag <c>FILE_FLAG_NO_BUFFERING</c>. In this case,
	/// the <c>GetLastError</c> function returns the value <c>ERROR_INVALID_PARAMETER</c>.
	/// </para>
	/// </param>
	/// <param name="bProcessSecurity">
	/// <para>Indicates whether the function will restore the access-control list (ACL) data for the file or directory.</para>
	/// <para>If bProcessSecurity is <c>TRUE</c>, the ACL data will be backed up.</para>
	/// </param>
	/// <param name="retrieveContents">
	/// If set to <see langword="true"/>, the contents of each stream will be returned in <paramref name="lpBuffers"/>; otherwise <see
	/// langword="false"/> will return a null buffer.
	/// </param>
	/// <param name="lpBuffers">Returns a list of tuples with each stream's information (as a <see cref="WIN32_STREAM_ID"/> value, and optionally the contents.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <see cref="Win32Error.NO_ERROR"/>.</para>
	/// <para>If the function fails, the return value indicates which error occurred.</para>
	/// </returns>
	[PInvokeData("Winbase.h", MSDNShortId = "aa362509")]
	public static Win32Error BackupRead([In] HFILE hFile, [Optional] bool bProcessSecurity, [Optional] bool retrieveContents, out List<(WIN32_STREAM_ID id, SafeAllocatedMemoryHandle? buffer)> lpBuffers)
	{
		lpBuffers = [];
		unsafe
		{
			// Use header to prevent unknown allocation of name value
			WIN32_STREAM_ID_HEADER hdr = new();
			var hdrSize = (uint)sizeof(WIN32_STREAM_ID_HEADER);

			IntPtr lpContext = default;
			try
			{
				while (true)
				{
					// Read the next stream header:
					var ret = BackupRead(hFile, (IntPtr)(void*)&hdr, hdrSize, out var bytesRead, false, bProcessSecurity, ref lpContext);
					if (!ret)
						return GetLastError();
					// Last stream found, so exit loop
					if (bytesRead == 0)
						break;
					// Unexpected error -- this should always be right
					if (bytesRead != hdrSize)
						return Win32Error.ERROR_INVALID_DATA;

					// Get the name if available
					string? name = null;
					if (hdr.dwStreamNameSize > 0)
					{
						using SafeLPWSTR pName = new(((int)hdr.dwStreamNameSize / 2) + 1);
						bool nameRead = BackupRead(hFile, pName, hdr.dwStreamNameSize, out bytesRead, false, bProcessSecurity, ref lpContext);
						if (!nameRead)
							return GetLastError();
						name = pName;
					}

					// Capture the details about the stream and allocated memory with the contents
					(WIN32_STREAM_ID id, SafeAllocatedMemoryHandle? buffer) entry = (hdr, null);
					entry.id.cStreamName = name ?? "";
					if (hdr.dwStreamId != BACKUP_STREAM_ID.BACKUP_INVALID && retrieveContents)
					{
						var buf = new SafeHGlobalHandle(hdr.Size.LowPart());
						if (buf.Size > 0 && !BackupRead(hFile, buf, buf.Size, out bytesRead, false, bProcessSecurity, ref lpContext))
							return GetLastError();
						entry.buffer = buf;
					}
					else
					{
						if (!BackupSeek(hFile, hdr.Size.LowPart(), (uint)hdr.Size.HighPart(), out _, out _, ref lpContext))
							return GetLastError();
					}
					lpBuffers.Add(entry);
				}
			}
			finally
			{
				// Close the backup
				BackupRead(hFile, IntPtr.Zero, 0, out _, true, bProcessSecurity, ref lpContext);
			}
		}
		return 0;
	}

	/// <summary>
	/// The <c>BackupSeek</c> function seeks forward in a data stream initially accessed by using the <c>BackupRead</c> or <c>BackupWrite</c> function.
	/// </summary>
	/// <param name="hFile">
	/// <para>Handle to the file or directory. This handle is created by using the <c>CreateFile</c> function.</para>
	/// <para>
	/// The handle must be synchronous (nonoverlapped). This means that the FILE_FLAG_OVERLAPPED flag must not be set when <c>CreateFile</c>
	/// is called. This function does not validate that the handle it receives is synchronous, so it does not return an error code for a
	/// synchronous handle, but calling it with an asynchronous (overlapped) handle can result in subtle errors that are very difficult to debug.
	/// </para>
	/// </param>
	/// <param name="dwLowBytesToSeek">Low-order part of the number of bytes to seek.</param>
	/// <param name="dwHighBytesToSeek">High-order part of the number of bytes to seek.</param>
	/// <param name="lpdwLowByteSeeked">
	/// Pointer to a variable that receives the low-order bits of the number of bytes the function actually seeks.
	/// </param>
	/// <param name="lpdwHighByteSeeked">
	/// Pointer to a variable that receives the high-order bits of the number of bytes the function actually seeks.
	/// </param>
	/// <param name="lpContext">
	/// Pointer to an internal data structure used by the function. This structure must be the same structure that was initialized by the
	/// <c>BackupRead</c> or <c>BackupWrite</c> function. An application must not touch the contents of this structure.
	/// </param>
	/// <returns>
	/// <para>If the function could seek the requested amount, the function returns a nonzero value.</para>
	/// <para>If the function could not seek the requested amount, the function returns zero. To get extended error information, call <c>GetLastError</c>.</para>
	/// </returns>
	// BOOL BackupSeek( _In_ HANDLE hFile, _In_ DWORD dwLowBytesToSeek, _In_ DWORD dwHighBytesToSeek, _Out_ LPDWORD lpdwLowByteSeeked, _Out_
	// LPDWORD lpdwHighByteSeeked, _In_ LPVOID *lpContext); https://msdn.microsoft.com/en-us/library/windows/desktop/aa362510(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("Winbase.h", MSDNShortId = "aa362510")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool BackupSeek([In] HFILE hFile, uint dwLowBytesToSeek, uint dwHighBytesToSeek, out uint lpdwLowByteSeeked, out uint lpdwHighByteSeeked, ref IntPtr lpContext);

	/// <summary>
	/// The <c>BackupWrite</c> function can be used to restore a file or directory that was backed up using <c>BackupRead</c>. Use the
	/// <c>ReadFile</c> function to get a stream of data from the backup medium, then use <c>BackupWrite</c> to write the data to the
	/// specified file or directory.
	/// </summary>
	/// <param name="hFile">
	/// <para>
	/// Handle to the file or directory to be restored. To obtain the handle, call the <c>CreateFile</c> function. The SACLs are not restored
	/// unless the file handle was created with the <c>ACCESS_SYSTEM_SECURITY</c> access right. To ensure that the integrity ACEs are
	/// restored correctly, the file handle must also have been created with the WRITE_OWNER access right. For more information, see File
	/// Security and Access Rights.
	/// </para>
	/// <para><c>Windows Server 2003 and Windows XP:</c> The WRITE_OWNER access right is not required.</para>
	/// <para>
	/// The handle must be synchronous (nonoverlapped). This means that the FILE_FLAG_OVERLAPPED flag must not be set when <c>CreateFile</c>
	/// is called. This function does not validate that the handle it receives is synchronous, so it does not return an error code for a
	/// synchronous handle, but calling it with an asynchronous (overlapped) handle can result in subtle errors that are very difficult to debug.
	/// </para>
	/// <para>
	/// The <c>BackupWrite</c> function may fail if <c>CreateFile</c> was called with the flag <c>FILE_FLAG_NO_BUFFERING</c>. In this case,
	/// the <c>GetLastError</c> function returns the value <c>ERROR_INVALID_PARAMETER</c>.
	/// </para>
	/// </param>
	/// <param name="lpBuffer">Pointer to a buffer that the function writes data from.</param>
	/// <param name="nNumberOfBytesToWrite">
	/// Size of the buffer, in bytes. The buffer size must be greater than the size of a <c>WIN32_STREAM_ID</c> structure.
	/// </param>
	/// <param name="lpNumberOfBytesWritten">Pointer to a variable that receives the number of bytes written.</param>
	/// <param name="bAbort">
	/// Indicates whether you have finished using <c>BackupWrite</c> on the handle. While you are restoring the file, specify this parameter
	/// as <c>FALSE</c>. After you are done using <c>BackupWrite</c>, you must call <c>BackupWrite</c> one more time specifying <c>TRUE</c>
	/// for this parameter and passing the appropriate lpContext. lpContext must be passed when bAbort is <c>TRUE</c>; all other parameters
	/// are ignored.
	/// </param>
	/// <param name="bProcessSecurity">
	/// <para>Specifies whether the function will restore the access-control list (ACL) data for the file or directory.</para>
	/// <para>
	/// If bProcessSecurity is <c>TRUE</c>, you need to specify <c>WRITE_OWNER</c> and <c>WRITE_DAC</c> access when opening the file or
	/// directory handle. If the handle does not have those access rights, the operating system denies access to the ACL data, and ACL data
	/// restoration will not occur.
	/// </para>
	/// </param>
	/// <param name="lpContext">
	/// <para>
	/// Pointer to a variable that receives a pointer to an internal data structure used by <c>BackupWrite</c> to maintain context
	/// information during a restore operation.
	/// </para>
	/// <para>
	/// You must set the variable pointed to by lpContext to <c>NULL</c> before the first call to <c>BackupWrite</c> for the specified file
	/// or directory. The function allocates memory for the data structure, and then sets the variable to point to that structure. You must
	/// not change lpContext or the variable that it points to between calls to <c>BackupWrite</c>.
	/// </para>
	/// <para>
	/// To release the memory used by the data structure, call <c>BackupWrite</c> with the bAbort parameter set to <c>TRUE</c> when the
	/// restore operation is complete.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>
	/// If the function fails, the return value is zero, indicating that an I/O error occurred. To get extended error information, call <c>GetLastError</c>.
	/// </para>
	/// </returns>
	// BOOL BackupWrite( _In_ HANDLE hFile, _In_ LPBYTE lpBuffer, _In_ DWORD nNumberOfBytesToWrite, _Out_ LPDWORD lpNumberOfBytesWritten,
	// _In_ BOOL bAbort, _In_ BOOL bProcessSecurity, _Out_ LPVOID *lpContext); https://msdn.microsoft.com/en-us/library/windows/desktop/aa362511(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("Winbase.h", MSDNShortId = "aa362511")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool BackupWrite([In] HFILE hFile, [In] IntPtr lpBuffer, uint nNumberOfBytesToWrite, out uint lpNumberOfBytesWritten, [MarshalAs(UnmanagedType.Bool)] bool bAbort,
		[MarshalAs(UnmanagedType.Bool)] bool bProcessSecurity, ref IntPtr lpContext);

	/// <summary>The <c>CreateTapePartition</c> function reformats a tape.</summary>
	/// <param name="hDevice">
	/// Handle to the device where the new partition is to be created. This handle is created by using the <c>CreateFile</c> function.
	/// </param>
	/// <param name="dwPartitionMethod">
	/// <para>
	/// Type of partition to create. To determine what type of partitions your device supports, see the documentation for your hardware. This
	/// parameter can have one of the following values.
	/// </para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>TAPE_FIXED_PARTITIONS0L</term>
	/// <term>Partitions the tape based on the device's default definition of partitions. The dwCount and dwSize parameters are ignored.</term>
	/// </item>
	/// <item>
	/// <term>TAPE_INITIATOR_PARTITIONS2L</term>
	/// <term>
	/// Partitions the tape into the number and size of partitions specified by dwCount and dwSize, respectively, except for the last
	/// partition. The size of the last partition is the remainder of the tape.
	/// </term>
	/// </item>
	/// <item>
	/// <term>TAPE_SELECT_PARTITIONS1L</term>
	/// <term>
	/// Partitions the tape into the number of partitions specified by dwCount. The dwSize parameter is ignored. The size of the partitions
	/// is determined by the device's default partition size. For more specific information, see the documentation for your tape device.
	/// </term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <param name="dwCount">
	/// Number of partitions to create. The <c>GetTapeParameters</c> function provides the maximum number of partitions a tape can support.
	/// </param>
	/// <param name="dwSize">Size of each partition, in megabytes. This value is ignored if the dwPartitionMethod parameter is <c>TAPE_SELECT_PARTITIONS</c>.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is NO_ERROR.</para>
	/// <para>If the function fails, it can return one of the following error codes.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_BEGINNING_OF_MEDIA1102L</term>
	/// <term>An attempt to access data before the beginning-of-medium marker failed.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_BUS_RESET1111L</term>
	/// <term>A reset condition was detected on the bus.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_END_OF_MEDIA1100L</term>
	/// <term>The end-of-tape marker was reached during an operation.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_FILEMARK_DETECTED1101L</term>
	/// <term>A filemark was reached during an operation.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SETMARK_DETECTED1103L</term>
	/// <term>A setmark was reached during an operation.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NO_DATA_DETECTED1104L</term>
	/// <term>The end-of-data marker was reached during an operation.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_PARTITION_FAILURE1105L</term>
	/// <term>The tape could not be partitioned.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_BLOCK_LENGTH1106L</term>
	/// <term>The block size is incorrect on a new tape in a multivolume partition.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_DEVICE_NOT_PARTITIONED1107L</term>
	/// <term>The partition information could not be found when a tape was being loaded.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_MEDIA_CHANGED1110L</term>
	/// <term>The tape that was in the drive has been replaced or removed.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NO_MEDIA_IN_DRIVE1112L</term>
	/// <term>There is no media in the drive.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_SUPPORTED50L</term>
	/// <term>The tape driver does not support a requested function.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNABLE_TO_LOCK_MEDIA1108L</term>
	/// <term>An attempt to lock the ejection mechanism failed.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNABLE_TO_UNLOAD_MEDIA1109L</term>
	/// <term>An attempt to unload the tape failed.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_WRITE_PROTECT19L</term>
	/// <term>The media is write protected.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </returns>
	// DWORD CreateTapePartition( _In_ HANDLE hDevice, _In_ DWORD dwPartitionMethod, _In_ DWORD dwCount, _In_ DWORD dwSize); https://msdn.microsoft.com/en-us/library/windows/desktop/aa362519(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Winbase.h", MSDNShortId = "aa362519")]
	public static extern Win32Error CreateTapePartition([In] HFILE hDevice, TAPE_PARTITION_METHOD dwPartitionMethod, uint dwCount, uint dwSize);

	/// <summary>The <c>EraseTape</c> function erases all or part of a tape.</summary>
	/// <param name="hDevice">Handle to the device where the tape is to be erased. This handle is created by using the CreateFile function.</param>
	/// <param name="dwEraseType">
	/// <para>Erasing technique. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>TAPE_ERASE_LONG 1L</term>
	/// <term>Erases the tape from the current position to the end of the current partition.</term>
	/// </item>
	/// <item>
	/// <term>TAPE_ERASE_SHORT 0L</term>
	/// <term>Writes an erase gap or end-of-data marker at the current position.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="bImmediate">
	/// If this parameter is <c>TRUE</c>, the function returns immediately; if it is <c>FALSE</c>, the function does not return until the
	/// erase operation has been completed.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is NO_ERROR.</para>
	/// <para>If the function fails, it can return one of the following error codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_BEGINNING_OF_MEDIA 1102L</term>
	/// <term>An attempt to access data before the beginning-of-medium marker failed.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_BUS_RESET 1111L</term>
	/// <term>A reset condition was detected on the bus.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_DEVICE_NOT_PARTITIONED 1107L</term>
	/// <term>The partition information could not be found when a tape was being loaded.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_END_OF_MEDIA 1100L</term>
	/// <term>The end-of-tape marker was reached during an operation.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_FILEMARK_DETECTED 1101L</term>
	/// <term>A filemark was reached during an operation.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_BLOCK_LENGTH 1106L</term>
	/// <term>The block size is incorrect on a new tape in a multivolume partition.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_MEDIA_CHANGED 1110L</term>
	/// <term>The tape that was in the drive has been replaced or removed.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NO_DATA_DETECTED 1104L</term>
	/// <term>The end-of-data marker was reached during an operation.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NO_MEDIA_IN_DRIVE 1112L</term>
	/// <term>There is no media in the drive.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_SUPPORTED 50L</term>
	/// <term>The tape driver does not support a requested function.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_PARTITION_FAILURE 1105L</term>
	/// <term>The tape could not be partitioned.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SETMARK_DETECTED 1103L</term>
	/// <term>A setmark was reached during an operation.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNABLE_TO_LOCK_MEDIA 1108L</term>
	/// <term>An attempt to lock the ejection mechanism failed.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNABLE_TO_UNLOAD_MEDIA 1109L</term>
	/// <term>An attempt to unload the tape failed.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_WRITE_PROTECT 19L</term>
	/// <term>The media is write protected.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// Some tape devices do not support certain tape operations. To determine your tape device's capabilities, see your tape device
	/// documentation and use the GetTapeParameters function.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-erasetape DWORD EraseTape( HANDLE hDevice, DWORD dwEraseType,
	// BOOL bImmediate );
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("winbase.h", MSDNShortId = "af262e79-ebdb-4ec5-9b59-ed6725a48bdf")]
	public static extern Win32Error EraseTape([In] HFILE hDevice, TAPE_ERASE_TYPE dwEraseType, [MarshalAs(UnmanagedType.Bool)] bool bImmediate);

	/// <summary>The <c>GetTapeParameters</c> function retrieves information that describes the tape or the tape drive.</summary>
	/// <param name="hDevice">
	/// Handle to the device about which information is sought. This handle is created by using the <c>CreateFile</c> function.
	/// </param>
	/// <param name="dwOperation">
	/// <para>Type of information requested. This parameter must be one of the following values.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>GET_TAPE_DRIVE_INFORMATION1</term>
	/// <term>Retrieves information about the tape device.</term>
	/// </item>
	/// <item>
	/// <term>GET_TAPE_MEDIA_INFORMATION0</term>
	/// <term>Retrieves information about the tape in the tape device.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <param name="lpdwSize">
	/// Pointer to a variable that receives the size, in bytes, of the buffer specified by the lpTapeInformation parameter. If the buffer is
	/// too small, this parameter receives the required size.
	/// </param>
	/// <param name="lpTapeInformation">
	/// <para>
	/// Pointer to a structure that contains the requested information. If the dwOperation parameter is GET_TAPE_MEDIA_INFORMATION,
	/// lpTapeInformation points to a <c>TAPE_GET_MEDIA_PARAMETERS</c> structure.
	/// </para>
	/// <para>If dwOperation is GET_TAPE_DRIVE_INFORMATION, lpTapeInformation points to a <c>TAPE_GET_DRIVE_PARAMETERS</c> structure.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is NO_ERROR.</para>
	/// <para>If the function fails, it can return one of the following error codes.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_BEGINNING_OF_MEDIA1102L</term>
	/// <term>An attempt to access data before the beginning-of-medium marker failed.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_BUS_RESET1111L</term>
	/// <term>A reset condition was detected on the bus.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_DEVICE_NOT_PARTITIONED1107L</term>
	/// <term>The partition information could not be found when a tape was being loaded.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_END_OF_MEDIA1100L</term>
	/// <term>The end-of-tape marker was reached during an operation.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_FILEMARK_DETECTED1101L</term>
	/// <term>A filemark was reached during an operation.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_BLOCK_LENGTH1106L</term>
	/// <term>The block size is incorrect on a new tape in a multivolume partition.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_MEDIA_CHANGED1110L</term>
	/// <term>The tape that was in the drive has been replaced or removed.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NO_DATA_DETECTED1104L</term>
	/// <term>The end-of-data marker was reached during an operation.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NO_MEDIA_IN_DRIVE1112L</term>
	/// <term>There is no media in the drive.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_SUPPORTED50L</term>
	/// <term>The tape driver does not support a requested function.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_PARTITION_FAILURE1105L</term>
	/// <term>The tape could not be partitioned.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SETMARK_DETECTED1103L</term>
	/// <term>A setmark was reached during an operation.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNABLE_TO_LOCK_MEDIA1108L</term>
	/// <term>An attempt to lock the ejection mechanism failed.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNABLE_TO_UNLOAD_MEDIA1109L</term>
	/// <term>An attempt to unload the tape failed.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_WRITE_PROTECT19L</term>
	/// <term>The media is write protected.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </returns>
	// DWORD GetTapeParameters( _In_ HANDLE hDevice, _In_ DWORD dwOperation, _Out_ LPDWORD lpdwSize, _Out_ LPVOID lpTapeInformation); https://msdn.microsoft.com/en-us/library/windows/desktop/aa362526(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Winbase.h", MSDNShortId = "aa362526")]
	public static extern Win32Error GetTapeParameters([In] HFILE hDevice, TAPE_PARAM_OP dwOperation, ref uint lpdwSize, IntPtr lpTapeInformation);

	/// <summary>The <c>GetTapeParameters</c> function retrieves information that describes the tape or the tape drive.</summary>
	/// <typeparam name="T">Either <see cref="TAPE_GET_MEDIA_PARAMETERS"/> or <see cref="TAPE_GET_DRIVE_PARAMETERS"/>.</typeparam>
	/// <param name="hDevice">
	/// Handle to the device about which information is sought. This handle is created by using the <c>CreateFile</c> function.
	/// </param>
	/// <returns>
	/// <para>
	/// Pointer to a structure that contains the requested information. If the dwOperation parameter is GET_TAPE_MEDIA_INFORMATION,
	/// lpTapeInformation points to a <c>TAPE_GET_MEDIA_PARAMETERS</c> structure.
	/// </para>
	/// <para>If dwOperation is GET_TAPE_DRIVE_INFORMATION, lpTapeInformation points to a <c>TAPE_GET_DRIVE_PARAMETERS</c> structure.</para>
	/// </returns>
	/// <exception cref="ArgumentOutOfRangeException">dwOperation - Type parameter does not match valid operation.</exception>
	// DWORD GetTapeParameters( _In_ HANDLE hDevice, _In_ DWORD dwOperation, _Out_ LPDWORD lpdwSize, _Out_ LPVOID lpTapeInformation); https://msdn.microsoft.com/en-us/library/windows/desktop/aa362526(v=vs.85).aspx
	[PInvokeData("Winbase.h", MSDNShortId = "aa362526")]
	public static T GetTapeParameters<T>([In] HFILE hDevice) where T : struct
	{
		if (!CorrespondingTypeAttribute.CanGet<T, TAPE_PARAM_OP>(out var dwOperation))
			throw new ArgumentOutOfRangeException(nameof(dwOperation), "Type parameter does not match valid operation.");
		using SafeCoTaskMemStruct<T> mem = new();
		uint sz = mem.Size;
		GetTapeParameters(hDevice, dwOperation, ref sz, mem).ThrowIfFailed();
		return mem.Value;
	}

	/// <summary>The <c>GetTapePosition</c> function retrieves the current address of the tape, in logical or absolute blocks.</summary>
	/// <param name="hDevice">Handle to the device on which to get the tape position. This handle is created by using <c>CreateFile</c>.</param>
	/// <param name="dwPositionType">
	/// <para>Type of address to obtain. This parameter can be one of the following values.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>TAPE_ABSOLUTE_POSITION0L</term>
	/// <term>
	/// The lpdwOffsetLow and lpdwOffsetHigh parameters receive the device-specific block address. The dwPartition parameter receives zero.
	/// </term>
	/// </item>
	/// <item>
	/// <term>TAPE_LOGICAL_POSITION1L</term>
	/// <term>
	/// The lpdwOffsetLow and lpdwOffsetHigh parameters receive the logical block address. The dwPartition parameter receives the logical
	/// tape partition.
	/// </term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <param name="lpdwPartition">
	/// Pointer to a variable that receives the number of the current tape partition. Partitions are numbered logically from 1 through n,
	/// where 1 is the first partition on the tape and n is the last. When a device-specific block address is retrieved, or if the device
	/// supports only one partition, this parameter receives zero.
	/// </param>
	/// <param name="lpdwOffsetLow">Pointer to a variable that receives the low-order bits of the current tape position.</param>
	/// <param name="lpdwOffsetHigh">
	/// Pointer to a variable that receives the high-order bits of the current tape position. This parameter can be <c>NULL</c> if the
	/// high-order bits are not required.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is NO_ERROR.</para>
	/// <para>If the function fails, it can return one of the following error codes.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_BEGINNING_OF_MEDIA1102L</term>
	/// <term>An attempt to access data before the beginning-of-medium marker failed.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_BUS_RESET1111L</term>
	/// <term>A reset condition was detected on the bus.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_DEVICE_NOT_PARTITIONED1107L</term>
	/// <term>The partition information could not be found when a tape was being loaded.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_END_OF_MEDIA1100L</term>
	/// <term>The end-of-tape marker was reached during an operation.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_FILEMARK_DETECTED1101L</term>
	/// <term>A filemark was reached during an operation.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_BLOCK_LENGTH1106L</term>
	/// <term>The block size is incorrect on a new tape in a multivolume partition.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_MEDIA_CHANGED1110L</term>
	/// <term>The tape that was in the drive has been replaced or removed.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NO_DATA_DETECTED1104L</term>
	/// <term>The end-of-data marker was reached during an operation.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NO_MEDIA_IN_DRIVE1112L</term>
	/// <term>There is no media in the drive.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_SUPPORTED50L</term>
	/// <term>The tape driver does not support a requested function.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_PARTITION_FAILURE1105L</term>
	/// <term>The tape could not be partitioned.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SETMARK_DETECTED1103L</term>
	/// <term>A setmark was reached during an operation.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNABLE_TO_LOCK_MEDIA1108L</term>
	/// <term>An attempt to lock the ejection mechanism failed.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNABLE_TO_UNLOAD_MEDIA1109L</term>
	/// <term>An attempt to unload the tape failed.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_WRITE_PROTECT19L</term>
	/// <term>The media is write protected.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </returns>
	// DWORD GetTapePosition( _In_ HANDLE hDevice, _In_ DWORD dwPositionType, _Out_ LPDWORD lpdwPartition, _Out_ LPDWORD lpdwOffsetLow, _Out_
	// LPDWORD lpdwOffsetHigh); https://msdn.microsoft.com/en-us/library/windows/desktop/aa362528(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Winbase.h", MSDNShortId = "aa362528")]
	public static extern Win32Error GetTapePosition([In] HFILE hDevice, TAPE_POS_TYPE dwPositionType, out uint lpdwPartition, out uint lpdwOffsetLow, out uint lpdwOffsetHigh);

	/// <summary>The <c>GetTapeStatus</c> function determines whether the tape device is ready to process tape commands.</summary>
	/// <param name="hDevice">
	/// Handle to the device for which to get the device status. This handle is created by using the <c>CreateFile</c> function.
	/// </param>
	/// <returns>
	/// <para>If the tape device is ready to accept appropriate tape-access commands without returning errors, the return value is NO_ERROR.</para>
	/// <para>If the function fails, it can return one of the following error codes.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_BEGINNING_OF_MEDIA1102L</term>
	/// <term>An attempt to access data before the beginning-of-medium marker failed.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_BUS_RESET1111L</term>
	/// <term>A reset condition was detected on the bus.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_DEVICE_NOT_PARTITIONED1107L</term>
	/// <term>The partition information could not be found when a tape was being loaded.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_DEVICE_REQUIRES_CLEANING1165L</term>
	/// <term>The tape drive is capable of reporting that it requires cleaning, and reports that it does require cleaning.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_END_OF_MEDIA1100L</term>
	/// <term>The end-of-tape marker was reached during an operation.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_FILEMARK_DETECTED1101L</term>
	/// <term>A filemark was reached during an operation.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_BLOCK_LENGTH1106L</term>
	/// <term>The block size is incorrect on a new tape in a multivolume partition.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_MEDIA_CHANGED1110L</term>
	/// <term>The tape that was in the drive has been replaced or removed.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NO_DATA_DETECTED1104L</term>
	/// <term>The end-of-data marker was reached during an operation.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NO_MEDIA_IN_DRIVE1112L</term>
	/// <term>There is no media in the drive.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_SUPPORTED50L</term>
	/// <term>The tape driver does not support a requested function.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_PARTITION_FAILURE1105L</term>
	/// <term>The tape could not be partitioned.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SETMARK_DETECTED1103L</term>
	/// <term>A setmark was reached during an operation.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNABLE_TO_LOCK_MEDIA1108L</term>
	/// <term>An attempt to lock the ejection mechanism failed.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNABLE_TO_UNLOAD_MEDIA1109L</term>
	/// <term>An attempt to unload the tape failed.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_WRITE_PROTECT19L</term>
	/// <term>The media is write protected.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </returns>
	// DWORD GetTapeStatus( _In_ HANDLE hDevice); https://msdn.microsoft.com/en-us/library/windows/desktop/aa362530(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Winbase.h", MSDNShortId = "aa362530")]
	public static extern Win32Error GetTapeStatus([In] HFILE hDevice);

	/// <summary>The <c>PrepareTape</c> function prepares the tape to be accessed or removed.</summary>
	/// <param name="hDevice">Handle to the device preparing the tape. This handle is created by using the <c>CreateFile</c> function.</param>
	/// <param name="dwOperation">
	/// <para>Tape device preparation. This parameter can be one of the following values.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>TAPE_FORMAT5L</term>
	/// <term>Performs a low-level format of the tape. Currently, only the QIC117 device supports this feature.</term>
	/// </item>
	/// <item>
	/// <term>TAPE_LOAD0L</term>
	/// <term>Loads the tape and moves the tape to the beginning.</term>
	/// </item>
	/// <item>
	/// <term>TAPE_LOCK3L</term>
	/// <term>Locks the tape ejection mechanism so that the tape is not ejected accidentally.</term>
	/// </item>
	/// <item>
	/// <term>TAPE_TENSION2L</term>
	/// <term>
	/// Adjusts the tension by moving the tape to the end of the tape and back to the beginning. This option is not supported by all devices.
	/// This value is ignored if it is not supported.
	/// </term>
	/// </item>
	/// <item>
	/// <term>TAPE_UNLOAD1L</term>
	/// <term>
	/// Moves the tape to the beginning for removal from the device. After a successful unload operation, the device returns errors to
	/// applications that attempt to access the tape, until the tape is loaded again.
	/// </term>
	/// </item>
	/// <item>
	/// <term>TAPE_UNLOCK4L</term>
	/// <term>Unlocks the tape ejection mechanism.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <param name="bImmediate">
	/// If this parameter is <c>TRUE</c>, the function returns immediately. If it is <c>FALSE</c>, the function does not return until the
	/// operation has been completed.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is NO_ERROR.</para>
	/// <para>If the function fails, it can return one of the following error codes.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_BEGINNING_OF_MEDIA1102L</term>
	/// <term>An attempt to access data before the beginning-of-medium marker failed.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_BUS_RESET1111L</term>
	/// <term>A reset condition was detected on the bus.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_DEVICE_NOT_PARTITIONED1107L</term>
	/// <term>The partition information could not be found when a tape was being loaded.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_END_OF_MEDIA1100L</term>
	/// <term>The end-of-tape marker was reached during an operation.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_FILEMARK_DETECTED1101L</term>
	/// <term>A filemark was reached during an operation.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_BLOCK_LENGTH1106L</term>
	/// <term>The block size is incorrect on a new tape in a multivolume partition.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_MEDIA_CHANGED1110L</term>
	/// <term>The tape that was in the drive has been replaced or removed.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NO_DATA_DETECTED1104L</term>
	/// <term>The end-of-data marker was reached during an operation.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NO_MEDIA_IN_DRIVE1112L</term>
	/// <term>There is no media in the drive.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_SUPPORTED50L</term>
	/// <term>The tape driver does not support a requested function.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_PARTITION_FAILURE1105L</term>
	/// <term>The tape could not be partitioned.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SETMARK_DETECTED1103L</term>
	/// <term>A setmark was reached during an operation.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNABLE_TO_LOCK_MEDIA1108L</term>
	/// <term>An attempt to lock the ejection mechanism failed.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNABLE_TO_UNLOAD_MEDIA1109L</term>
	/// <term>An attempt to unload the tape failed.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_WRITE_PROTECT19L</term>
	/// <term>The media is write protected.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </returns>
	// DWORD PrepareTape( _In_ HANDLE hDevice, _In_ DWORD dwOperation, _In_ BOOL bImmediate); https://msdn.microsoft.com/en-us/library/windows/desktop/aa362532(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Winbase.h", MSDNShortId = "aa362532")]
	public static extern Win32Error PrepareTape([In] HFILE hDevice, TAPE_PREP_OP dwOperation, [MarshalAs(UnmanagedType.Bool)] bool bImmediate);

	/// <summary>The <c>SetTapeParameters</c> function either specifies the block size of a tape or configures the tape device.</summary>
	/// <param name="hDevice">
	/// Handle to the device for which to set configuration information. This handle is created by using the CreateFile function.
	/// </param>
	/// <param name="dwOperation">
	/// <para>Type of information to set. This parameter must be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term><c>SET_TAPE_DRIVE_INFORMATION</c> 1L</term>
	/// <term>Sets the device-specific information specified by <c>lpTapeInformation</c>.</term>
	/// </item>
	/// <item>
	/// <term><c>SET_TAPE_MEDIA_INFORMATION</c> 0L</term>
	/// <term>Sets the tape-specific information specified by the <c>lpTapeInformation</c> parameter.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="lpTapeInformation">
	/// <para>
	/// Pointer to a structure that contains the information to set. If the <c>dwOperation</c> parameter is SET_TAPE_MEDIA_INFORMATION,
	/// <c>lpTapeInformation</c> points to a TAPE_SET_MEDIA_PARAMETERS structure.
	/// </para>
	/// <para>If <c>dwOperation</c> is SET_TAPE_DRIVE_INFORMATION, <c>lpTapeInformation</c> points to a TAPE_SET_DRIVE_PARAMETERS structure.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is NO_ERROR.</para>
	/// <para>If the function fails, it can return one of the following error codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_BEGINNING_OF_MEDIA</c> 1102L</term>
	/// <term>An attempt to access data before the beginning-of-medium marker failed.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_BUS_RESET</c> 1111L</term>
	/// <term>A reset condition was detected on the bus.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_DEVICE_NOT_PARTITIONED</c> 1107L</term>
	/// <term>The partition information could not be found when a tape was being loaded.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_END_OF_MEDIA</c> 1100L</term>
	/// <term>The end-of-tape marker was reached during an operation.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_FILEMARK_DETECTED</c> 1101L</term>
	/// <term>A filemark was reached during an operation.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_BLOCK_LENGTH</c> 1106L</term>
	/// <term>The block size is incorrect on a new tape in a multivolume partition.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_MEDIA_CHANGED</c> 1110L</term>
	/// <term>The tape that was in the drive has been replaced or removed.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NO_DATA_DETECTED</c> 1104L</term>
	/// <term>The end-of-data marker was reached during an operation.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NO_MEDIA_IN_DRIVE</c> 1112L</term>
	/// <term>There is no media in the drive.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_SUPPORTED</c> 50L</term>
	/// <term>The tape driver does not support a requested function.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_PARTITION_FAILURE</c> 1105L</term>
	/// <term>The tape could not be partitioned.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_SETMARK_DETECTED</c> 1103L</term>
	/// <term>A setmark was reached during an operation.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_UNABLE_TO_LOCK_MEDIA</c> 1108L</term>
	/// <term>An attempt to lock the ejection mechanism failed.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_UNABLE_TO_UNLOAD_MEDIA</c> 1109L</term>
	/// <term>An attempt to unload the tape failed.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WRITE_PROTECT</c> 19L</term>
	/// <term>The media is write protected.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-settapeparameters DWORD SetTapeParameters( [in] HANDLE hDevice,
	// [in] DWORD dwOperation, [in] LPVOID lpTapeInformation );
	[PInvokeData("winbase.h", MSDNShortId = "NF:winbase.SetTapeParameters")]
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	public static extern Win32Error SetTapeParameters([In] HFILE hDevice, TAPE_PARAM_OP dwOperation, [In] IntPtr lpTapeInformation);

	/// <summary>The <c>SetTapeParameters</c> function either specifies the block size of a tape or configures the tape device.</summary>
	/// <param name="hDevice">
	/// Handle to the device for which to set configuration information. This handle is created by using the CreateFile function.
	/// </param>
	/// <param name="lpTapeInformation">
	/// <para>
	/// Pointer to a structure that contains the information to set. If the <c>dwOperation</c> parameter is SET_TAPE_MEDIA_INFORMATION,
	/// <c>lpTapeInformation</c> points to a TAPE_SET_MEDIA_PARAMETERS structure.
	/// </para>
	/// <para>If <c>dwOperation</c> is SET_TAPE_DRIVE_INFORMATION, <c>lpTapeInformation</c> points to a TAPE_SET_DRIVE_PARAMETERS structure.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is NO_ERROR.</para>
	/// <para>If the function fails, it can return one of the following error codes.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term><c>ERROR_BEGINNING_OF_MEDIA</c> 1102L</term>
	/// <term>An attempt to access data before the beginning-of-medium marker failed.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_BUS_RESET</c> 1111L</term>
	/// <term>A reset condition was detected on the bus.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_DEVICE_NOT_PARTITIONED</c> 1107L</term>
	/// <term>The partition information could not be found when a tape was being loaded.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_END_OF_MEDIA</c> 1100L</term>
	/// <term>The end-of-tape marker was reached during an operation.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_FILEMARK_DETECTED</c> 1101L</term>
	/// <term>A filemark was reached during an operation.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_INVALID_BLOCK_LENGTH</c> 1106L</term>
	/// <term>The block size is incorrect on a new tape in a multivolume partition.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_MEDIA_CHANGED</c> 1110L</term>
	/// <term>The tape that was in the drive has been replaced or removed.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NO_DATA_DETECTED</c> 1104L</term>
	/// <term>The end-of-data marker was reached during an operation.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NO_MEDIA_IN_DRIVE</c> 1112L</term>
	/// <term>There is no media in the drive.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_NOT_SUPPORTED</c> 50L</term>
	/// <term>The tape driver does not support a requested function.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_PARTITION_FAILURE</c> 1105L</term>
	/// <term>The tape could not be partitioned.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_SETMARK_DETECTED</c> 1103L</term>
	/// <term>A setmark was reached during an operation.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_UNABLE_TO_LOCK_MEDIA</c> 1108L</term>
	/// <term>An attempt to lock the ejection mechanism failed.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_UNABLE_TO_UNLOAD_MEDIA</c> 1109L</term>
	/// <term>An attempt to unload the tape failed.</term>
	/// </item>
	/// <item>
	/// <term><c>ERROR_WRITE_PROTECT</c> 19L</term>
	/// <term>The media is write protected.</term>
	/// </item>
	/// </list>
	/// </returns>
	[PInvokeData("winbase.h", MSDNShortId = "NF:winbase.SetTapeParameters")]
	public static void SetTapeParameters<T>([In] HFILE hDevice, in T lpTapeInformation) where T : struct
	{
		if (!CorrespondingTypeAttribute.CanSet<T, TAPE_PARAM_OP>(out var dwOperation))
			throw new ArgumentOutOfRangeException(nameof(dwOperation), "Type parameter does not match valid operation.");
		using SafeCoTaskMemStruct<T> mem = new(lpTapeInformation);
		SetTapeParameters(hDevice, dwOperation, mem).ThrowIfFailed();
	}

	/// <summary>The <c>SetTapePosition</c> function sets the tape position on the specified device.</summary>
	/// <param name="hDevice">
	/// Handle to the device on which to set the tape position. This handle is created by using the <c>CreateFile</c> function.
	/// </param>
	/// <param name="dwPositionMethod">
	/// <para>Type of positioning to perform. This parameter must be one of the following values.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>TAPE_ABSOLUTE_BLOCK1L</term>
	/// <term>
	/// Moves the tape to the device-specific block address specified by the dwOffsetLow and dwOffsetHigh parameters. The dwPartition
	/// parameter is ignored.
	/// </term>
	/// </item>
	/// <item>
	/// <term>TAPE_LOGICAL_BLOCK2L</term>
	/// <term>Moves the tape to the block address specified by dwOffsetLow and dwOffsetHigh in the partition specified by dwPartition.</term>
	/// </item>
	/// <item>
	/// <term>TAPE_REWIND0L</term>
	/// <term>Moves the tape to the beginning of the current partition. The dwPartition, dwOffsetLow, and dwOffsetHigh parameters are ignored.</term>
	/// </item>
	/// <item>
	/// <term>TAPE_SPACE_END_OF_DATA4L</term>
	/// <term>Moves the tape to the end of the data on the partition specified by dwPartition.</term>
	/// </item>
	/// <item>
	/// <term>TAPE_SPACE_FILEMARKS6L</term>
	/// <term>
	/// Moves the tape forward (or backward) the number of filemarks specified by dwOffsetLow and dwOffsetHigh in the current partition. The
	/// dwPartition parameter is ignored.
	/// </term>
	/// </item>
	/// <item>
	/// <term>TAPE_SPACE_RELATIVE_BLOCKS5L</term>
	/// <term>
	/// Moves the tape forward (or backward) the number of blocks specified by dwOffsetLow and dwOffsetHigh in the current partition. The
	/// dwPartition parameter is ignored.
	/// </term>
	/// </item>
	/// <item>
	/// <term>TAPE_SPACE_SEQUENTIAL_FMKS7L</term>
	/// <term>
	/// Moves the tape forward (or backward) to the first occurrence of n filemarks in the current partition, where n is the number specified
	/// by dwOffsetLow and dwOffsetHigh. The dwPartition parameter is ignored.
	/// </term>
	/// </item>
	/// <item>
	/// <term>TAPE_SPACE_SEQUENTIAL_SMKS9L</term>
	/// <term>
	/// Moves the tape forward (or backward) to the first occurrence of n setmarks in the current partition, where n is the number specified
	/// by dwOffsetLow and dwOffsetHigh. The dwPartition parameter is ignored.
	/// </term>
	/// </item>
	/// <item>
	/// <term>TAPE_SPACE_SETMARKS8L</term>
	/// <term>
	/// Moves the tape forward (or backward) the number of setmarks specified by dwOffsetLow and dwOffsetHigh in the current partition. The
	/// dwPartition parameter is ignored.
	/// </term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <param name="dwPartition">
	/// Partition to position within. If dwPartition is zero, the current partition is used. Partitions are numbered logically from 1 through
	/// n, where 1 is the first partition on the tape and n is the last.
	/// </param>
	/// <param name="dwOffsetLow">
	/// Low-order bits of the block address or count for the position operation specified by the dwPositionMethod parameter.
	/// </param>
	/// <param name="dwOffsetHigh">
	/// High-order bits of the block address or count for the position operation specified by the dwPositionMethod parameter. If the
	/// high-order bits are not required, this parameter should be zero.
	/// </param>
	/// <param name="bImmediate">
	/// Indicates whether to return as soon as the move operation begins. If this parameter is <c>TRUE</c>, the function returns immediately;
	/// if <c>FALSE</c>, the function does not return until the move operation has been completed.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is NO_ERROR.</para>
	/// <para>If the function fails, it can return one of the following error codes.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_BEGINNING_OF_MEDIA1102L</term>
	/// <term>An attempt to access data before the beginning-of-medium marker failed.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_BUS_RESET1111L</term>
	/// <term>A reset condition was detected on the bus.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_DEVICE_NOT_PARTITIONED1107L</term>
	/// <term>The partition information could not be found when a tape was being loaded.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_END_OF_MEDIA1100L</term>
	/// <term>The end-of-tape marker was reached during an operation.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_FILEMARK_DETECTED1101L</term>
	/// <term>A filemark was reached during an operation.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_BLOCK_LENGTH1106L</term>
	/// <term>The block size is incorrect on a new tape in a multivolume partition.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_MEDIA_CHANGED1110L</term>
	/// <term>The tape that was in the drive has been replaced or removed.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NO_DATA_DETECTED1104L</term>
	/// <term>The end-of-data marker was reached during an operation.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NO_MEDIA_IN_DRIVE1112L</term>
	/// <term>There is no media in the drive.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_SUPPORTED50L</term>
	/// <term>The tape driver does not support a requested function.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_PARTITION_FAILURE1105L</term>
	/// <term>The tape could not be partitioned.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SETMARK_DETECTED1103L</term>
	/// <term>A setmark was reached during an operation.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNABLE_TO_LOCK_MEDIA1108L</term>
	/// <term>An attempt to lock the ejection mechanism failed.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNABLE_TO_UNLOAD_MEDIA1109L</term>
	/// <term>An attempt to unload the tape failed.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_WRITE_PROTECT19L</term>
	/// <term>The media is write protected.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </returns>
	// DWORD SetTapePosition( _In_ HANDLE hDevice, _In_ DWORD dwPositionMethod, _In_ DWORD dwPartition, _In_ DWORD dwOffsetLow, _In_ DWORD
	// dwOffsetHigh, _In_ BOOL bImmediate); https://msdn.microsoft.com/en-us/library/windows/desktop/aa362536(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Winbase.h", MSDNShortId = "aa362536")]
	public static extern Win32Error SetTapePosition([In] HFILE hDevice, TAPE_POS_METHOD dwPositionMethod, uint dwPartition, uint dwOffsetLow, uint dwOffsetHigh, [MarshalAs(UnmanagedType.Bool)] bool bImmediate);

	/// <summary>
	/// The <c>WriteTapemark</c> function writes a specified number of filemarks, setmarks, short filemarks, or long filemarks to a tape
	/// device. These tapemarks divide a tape partition into smaller areas.
	/// </summary>
	/// <param name="hDevice">Handle to the device on which to write tapemarks. This handle is created by using the <c>CreateFile</c> function.</param>
	/// <param name="dwTapemarkType">
	/// <para>Type of tapemarks to write. This parameter can be one of the following values.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>TAPE_FILEMARKS1L</term>
	/// <term>Writes the number of filemarks specified by the dwTapemarkCount parameter.</term>
	/// </item>
	/// <item>
	/// <term>TAPE_LONG_FILEMARKS3L</term>
	/// <term>Writes the number of long filemarks specified by dwTapemarkCount.</term>
	/// </item>
	/// <item>
	/// <term>TAPE_SETMARKS0L</term>
	/// <term>Writes the number of setmarks specified by dwTapemarkCount.</term>
	/// </item>
	/// <item>
	/// <term>TAPE_SHORT_FILEMARKS2L</term>
	/// <term>Writes the number of short filemarks specified by dwTapemarkCount.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </param>
	/// <param name="dwTapemarkCount">Number of tapemarks to write.</param>
	/// <param name="bImmediate">
	/// If this parameter is <c>TRUE</c>, the function returns immediately; if it is <c>FALSE</c>, the function does not return until the
	/// operation has been completed.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is NO_ERROR.</para>
	/// <para>If the function fails, it can return one of the following error codes.</para>
	/// <para>
	/// <list type="table">
	/// <listheader>
	/// <term>Error</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_BEGINNING_OF_MEDIA1102L</term>
	/// <term>An attempt to access data before the beginning-of-medium marker failed.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_BUS_RESET1111L</term>
	/// <term>A reset condition was detected on the bus.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_DEVICE_NOT_PARTITIONED1107L</term>
	/// <term>The partition information could not be found when a tape was being loaded.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_END_OF_MEDIA1100L</term>
	/// <term>The end-of-tape marker was reached during an operation.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_FILEMARK_DETECTED1101L</term>
	/// <term>A filemark was reached during an operation.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_BLOCK_LENGTH1106L</term>
	/// <term>The block size is incorrect on a new tape in a multivolume partition.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_MEDIA_CHANGED1110L</term>
	/// <term>The tape that was in the drive has been replaced or removed.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NO_DATA_DETECTED1104L</term>
	/// <term>The end-of-data marker was reached during an operation.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NO_MEDIA_IN_DRIVE1112L</term>
	/// <term>There is no media in the drive.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_SUPPORTED50L</term>
	/// <term>The tape driver does not support a requested function.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_PARTITION_FAILURE1105L</term>
	/// <term>The tape could not be partitioned.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SETMARK_DETECTED1103L</term>
	/// <term>A setmark was reached during an operation.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNABLE_TO_LOCK_MEDIA1108L</term>
	/// <term>An attempt to lock the ejection mechanism failed.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNABLE_TO_UNLOAD_MEDIA1109L</term>
	/// <term>An attempt to unload the tape failed.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_WRITE_PROTECT19L</term>
	/// <term>The media is write protected.</term>
	/// </item>
	/// </list>
	/// </para>
	/// </returns>
	// DWORD WriteTapemark( _In_ HANDLE hDevice, _In_ DWORD dwTapemarkType, _In_ DWORD dwTapemarkCount, _In_ BOOL bImmediate); https://msdn.microsoft.com/en-us/library/windows/desktop/aa362668(v=vs.85).aspx
	[DllImport(Lib.Kernel32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Winbase.h", MSDNShortId = "aa362668")]
	public static extern Win32Error WriteTapemark([In] HFILE hDevice, TAPEMARK_TYPE dwTapemarkType, uint dwTapemarkCount, [MarshalAs(UnmanagedType.Bool)] bool bImmediate);

	/// <summary>The TAPE_GET_DRIVE_PARAMETERS structure describes the tape drive. It is used by the GetTapeParameters function.</summary>
	// https://msdn.microsoft.com/en-us/library/windows/desktop/aa362562(v=vs.85).aspx
	[PInvokeData("Winnt.h", MSDNShortId = "aa362562")]
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct TAPE_GET_DRIVE_PARAMETERS
	{
		/// <summary>If this member is TRUE, the device supports hardware error correction. Otherwise, it does not.</summary>
		[MarshalAs(UnmanagedType.U1)] public bool ECC;

		/// <summary>If this member is TRUE, hardware data compression is enabled. Otherwise, it is disabled.</summary>
		[MarshalAs(UnmanagedType.U1)] public bool Compression;

		/// <summary>
		/// If this member is TRUE, data padding is enabled. Otherwise, it is disabled. Data padding keeps the tape streaming at a constant speed.
		/// </summary>
		[MarshalAs(UnmanagedType.U1)] public bool DataPadding;

		/// <summary>If this member is TRUE, setmark reporting is enabled. Otherwise, it is disabled.</summary>
		[MarshalAs(UnmanagedType.U1)] public bool ReportSetmarks;

		/// <summary>Device's default fixed block size, in bytes.</summary>
		public uint DefaultBlockSize;

		/// <summary>Device's maximum block size, in bytes.</summary>
		public uint MaximumBlockSize;

		/// <summary>Device's minimum block size, in bytes.</summary>
		public uint MinimumBlockSize;

		/// <summary>Maximum number of partitions that can be created on the device.</summary>
		public uint MaximumPartitionCount;

		/// <summary>Low-order bits of the device features flag.</summary>
		public TAPE_FEATURES_LOW FeaturesLow;

		/// <summary>High-order bits of the device features flag.</summary>
		public TAPE_FEATURES_HIGH FeaturesHigh;

		/// <summary>Indicates the number of bytes between the end-of-tape warning and the physical end of the tape.</summary>
		public uint EOTWarningZoneSize;
	}

	/// <summary>The TAPE_GET_MEDIA_PARAMETERS structure describes the tape in the tape drive. It is used by the GetTapeParameters function.</summary>
	// https://msdn.microsoft.com/en-us/library/windows/desktop/aa362564(v=vs.85).aspx
	[PInvokeData("Winnt.h", MSDNShortId = "aa362564")]
	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	public struct TAPE_GET_MEDIA_PARAMETERS
	{
		/// <summary>Total number of bytes on the current tape partition.</summary>
		public long Capacity;

		/// <summary>Number of bytes between the current position and the end of the current tape partition.</summary>
		public long Remaining;

		/// <summary>Number of bytes per block.</summary>
		public uint BlockSize;

		/// <summary>Number of partitions on the tape.</summary>
		public uint PartitionCount;

		/// <summary>If this member is TRUE, the tape is write-protected. Otherwise, it is not.</summary>
		[MarshalAs(UnmanagedType.U1)] public bool WriteProtected;
	}

	/// <summary>The <c>WIN32_STREAM_ID</c> structure contains stream data.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/winbase/ns-winbase-win32_stream_id typedef struct _WIN32_STREAM_ID { DWORD
	// dwStreamId; DWORD dwStreamAttributes; LARGE_INTEGER Size; DWORD dwStreamNameSize; WCHAR cStreamName[ANYSIZE_ARRAY]; } WIN32_STREAM_ID, *LPWIN32_STREAM_ID;
	[PInvokeData("winbase.h", MSDNShortId = "NS:winbase._WIN32_STREAM_ID")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	[VanaraMarshaler(typeof(AnySizeStringMarshaler<WIN32_STREAM_ID>), nameof(dwStreamNameSize))]
	public struct WIN32_STREAM_ID
	{
		/// <summary>
		/// <para>Type of data. This member can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>BACKUP_ALTERNATE_DATA</c> 0x00000004</description>
		/// <description>Alternative data streams. This corresponds to the NTFS $DATA stream type on a named data stream.</description>
		/// </item>
		/// <item>
		/// <description><c>BACKUP_DATA</c> 0x00000001</description>
		/// <description>Standard data. This corresponds to the NTFS $DATA stream type on the default (unnamed) data stream.</description>
		/// </item>
		/// <item>
		/// <description><c>BACKUP_EA_DATA</c> 0x00000002</description>
		/// <description>Extended attribute data. This corresponds to the NTFS $EA stream type.</description>
		/// </item>
		/// <item>
		/// <description><c>BACKUP_LINK</c> 0x00000005</description>
		/// <description>Hard link information. This corresponds to the NTFS $FILE_NAME stream type.</description>
		/// </item>
		/// <item>
		/// <description><c>BACKUP_OBJECT_ID</c> 0x00000007</description>
		/// <description>Objects identifiers. This corresponds to the NTFS $OBJECT_ID stream type.</description>
		/// </item>
		/// <item>
		/// <description><c>BACKUP_PROPERTY_DATA</c> 0x00000006</description>
		/// <description>Property data.</description>
		/// </item>
		/// <item>
		/// <description><c>BACKUP_REPARSE_DATA</c> 0x00000008</description>
		/// <description>Reparse points. This corresponds to the NTFS $REPARSE_POINT stream type.</description>
		/// </item>
		/// <item>
		/// <description><c>BACKUP_SECURITY_DATA</c> 0x00000003</description>
		/// <description>Security descriptor data.</description>
		/// </item>
		/// <item>
		/// <description><c>BACKUP_SPARSE_BLOCK</c> 0x00000009</description>
		/// <description>Sparse file. This corresponds to the NTFS $DATA stream type for a sparse file.</description>
		/// </item>
		/// <item>
		/// <description><c>BACKUP_TXFS_DATA</c> 0x0000000A</description>
		/// <description>
		/// Transactional NTFS (TxF) data stream. This corresponds to the NTFS $TXF_DATA stream type. <c>Windows Server 2003 and
		/// Windows XP:  </c> This value is not supported.
		/// </description>
		/// </item>
		/// </list>
		/// </summary>
		public BACKUP_STREAM_ID dwStreamId;

		/// <summary>
		/// <para>Attributes of data to facilitate cross-operating system transfer. This member can be one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>STREAM_MODIFIED_WHEN_READ</c></description>
		/// <description>
		/// Attribute set if the stream contains data that is modified when read. Allows the backup application to know that verification of
		/// data will fail.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>STREAM_CONTAINS_SECURITY</c></description>
		/// <description>Stream contains security data (general attributes). Allows the stream to be ignored on cross-operations restore.</description>
		/// </item>
		/// </list>
		/// </summary>
		public BACKUP_STREAM_ATTR dwStreamAttributes;

		/// <summary>Size of data, in bytes.</summary>
		public long Size;

		/// <summary>Length of the name of the alternative data stream, in bytes.</summary>
		public uint dwStreamNameSize;

		/// <summary>Unicode string that specifies the name of the alternative data stream.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1)]
		public string cStreamName;

		/// <summary>Performs an implicit conversion from <see cref="WIN32_STREAM_ID_HEADER"/> to <see cref="WIN32_STREAM_ID"/>.</summary>
		/// <param name="h">The header.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator WIN32_STREAM_ID(in WIN32_STREAM_ID_HEADER h) =>
			new() { dwStreamId = h.dwStreamId, dwStreamAttributes = h.dwStreamAttributes, Size = h.Size, dwStreamNameSize = h.dwStreamNameSize };
	}

	/// <summary>The <c>WIN32_STREAM_ID</c> structure contains stream data.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/winbase/ns-winbase-win32_stream_id typedef struct _WIN32_STREAM_ID { DWORD
	// dwStreamId; DWORD dwStreamAttributes; LARGE_INTEGER Size; DWORD dwStreamNameSize; WCHAR cStreamName[ANYSIZE_ARRAY]; } WIN32_STREAM_ID, *LPWIN32_STREAM_ID;
	[PInvokeData("winbase.h", MSDNShortId = "NS:winbase._WIN32_STREAM_ID")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode, Size = 20, Pack = 4)]
	public struct WIN32_STREAM_ID_HEADER
	{
		/// <summary>
		/// <para>Type of data. This member can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>BACKUP_ALTERNATE_DATA</c> 0x00000004</description>
		/// <description>Alternative data streams. This corresponds to the NTFS $DATA stream type on a named data stream.</description>
		/// </item>
		/// <item>
		/// <description><c>BACKUP_DATA</c> 0x00000001</description>
		/// <description>Standard data. This corresponds to the NTFS $DATA stream type on the default (unnamed) data stream.</description>
		/// </item>
		/// <item>
		/// <description><c>BACKUP_EA_DATA</c> 0x00000002</description>
		/// <description>Extended attribute data. This corresponds to the NTFS $EA stream type.</description>
		/// </item>
		/// <item>
		/// <description><c>BACKUP_LINK</c> 0x00000005</description>
		/// <description>Hard link information. This corresponds to the NTFS $FILE_NAME stream type.</description>
		/// </item>
		/// <item>
		/// <description><c>BACKUP_OBJECT_ID</c> 0x00000007</description>
		/// <description>Objects identifiers. This corresponds to the NTFS $OBJECT_ID stream type.</description>
		/// </item>
		/// <item>
		/// <description><c>BACKUP_PROPERTY_DATA</c> 0x00000006</description>
		/// <description>Property data.</description>
		/// </item>
		/// <item>
		/// <description><c>BACKUP_REPARSE_DATA</c> 0x00000008</description>
		/// <description>Reparse points. This corresponds to the NTFS $REPARSE_POINT stream type.</description>
		/// </item>
		/// <item>
		/// <description><c>BACKUP_SECURITY_DATA</c> 0x00000003</description>
		/// <description>Security descriptor data.</description>
		/// </item>
		/// <item>
		/// <description><c>BACKUP_SPARSE_BLOCK</c> 0x00000009</description>
		/// <description>Sparse file. This corresponds to the NTFS $DATA stream type for a sparse file.</description>
		/// </item>
		/// <item>
		/// <description><c>BACKUP_TXFS_DATA</c> 0x0000000A</description>
		/// <description>
		/// Transactional NTFS (TxF) data stream. This corresponds to the NTFS $TXF_DATA stream type. <c>Windows Server 2003 and
		/// Windows XP:  </c> This value is not supported.
		/// </description>
		/// </item>
		/// </list>
		/// </summary>
		public BACKUP_STREAM_ID dwStreamId;

		/// <summary>
		/// <para>Attributes of data to facilitate cross-operating system transfer. This member can be one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Value</description>
		/// <description>Meaning</description>
		/// </listheader>
		/// <item>
		/// <description><c>STREAM_MODIFIED_WHEN_READ</c></description>
		/// <description>
		/// Attribute set if the stream contains data that is modified when read. Allows the backup application to know that verification of
		/// data will fail.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>STREAM_CONTAINS_SECURITY</c></description>
		/// <description>Stream contains security data (general attributes). Allows the stream to be ignored on cross-operations restore.</description>
		/// </item>
		/// </list>
		/// </summary>
		public BACKUP_STREAM_ATTR dwStreamAttributes;

		/// <summary>Size of data, in bytes.</summary>
		public long Size;

		/// <summary>Length of the name of the alternative data stream, in bytes.</summary>
		public uint dwStreamNameSize;
	}
}