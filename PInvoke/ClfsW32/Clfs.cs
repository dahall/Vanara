#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

global using System;
global using System.Runtime.InteropServices;
global using System.Threading;
global using Vanara.InteropServices;

global using CLFS_CONTAINER_ID = System.UInt32;
using Vanara.Extensions;

namespace Vanara.PInvoke;

/// <summary>Functions supporting the Windows Common Log File System.</summary>
public static partial class ClfsW32
{
	/// <summary>Base log file name 3-letter extension.</summary>
	public const string CLFS_BASELOG_EXTENSION = ".blf";

	/// <summary>Container name extended attribute entry name.</summary>
	public const string EA_CONTAINER_NAME = "ContainerName";

	/// <summary>Container size extended attribute entry name.</summary>
	public const string EA_CONTAINER_SIZE = "ContainerSize";

	private const string Lib_Clfsw32 = "clfsw32.dll";

	/// <summary>Allocate a blocks for marshaled reads or writes</summary>
	/// <param name="cbBufferLength">Length of the cb buffer.</param>
	/// <param name="pvUserContext">The pv user context.</param>
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	public delegate void CLFS_BLOCK_ALLOCATION(uint cbBufferLength, IntPtr pvUserContext);

	/// <summary>A callback function that frees log blocks.</summary>
	/// <param name="pvBuffer">The pv buffer.</param>
	/// <param name="pvUserContext">The pv user context.</param>
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	public delegate void CLFS_BLOCK_DEALLOCATION(IntPtr pvBuffer, IntPtr pvUserContext);

	/// <summary>The current state of a container.</summary>
	[PInvokeData("clfs.h", MSDNShortId = "NS:clfs._CLS_CONTAINER_INFORMATION")]
	[Flags]
	public enum CLFS_CONTAINER_STATE : uint
	{
		/// <summary>The container is in the process of initializing.</summary>
		ClsContainerInitializing = 0x01,

		/// <summary>The container is allocated, but is not in the active region of the log.</summary>
		ClsContainerInactive = 0x02,

		/// <summary>The container is being used as storage for part of the log.</summary>
		ClsContainerActive = 0x04,

		/// <summary>The container is marked for deletion, but still contains part of the active log.</summary>
		ClsContainerActivePendingDelete = 0x08,

		/// <summary>The container is marked for archive.</summary>
		ClsContainerPendingArchive = 0x10,

		/// <summary>The container is marked for deletion, but still contains log data that is not archived.</summary>
		ClsContainerPendingArchiveAndDelete = 0x20,
	}

	/// <summary>
	/// Specifies a context mode type that indicates the direction and access methods that a client uses to scan a log. The context mode is
	/// set by using ReadLogRecord, and is embedded in the read context that these two functions return.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfs/ne-clfs-clfs_context_mode typedef enum _CLFS_CONTEXT_MODE { ClfsContextNone =
	// 0x00, ClfsContextUndoNext, ClfsContextPrevious, ClfsContextForward } CLFS_CONTEXT_MODE, *PCLFS_CONTEXT_MODE, PPCLFS_CONTEXT_MODE;
	[PInvokeData("clfs.h", MSDNShortId = "NE:clfs._CLFS_CONTEXT_MODE")]
	public enum CLFS_CONTEXT_MODE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0x00</para>
		/// <para>Do not move the cursor.</para>
		/// </summary>
		ClfsContextNone,

		/// <summary>Move the cursor backward to the next undo record.</summary>
		ClfsContextUndoNext,

		/// <summary>Move the cursor to the previous log record from the current read context.</summary>
		ClfsContextPrevious,

		/// <summary>Move the cursor to the next client log record from the current read context.</summary>
		ClfsContextForward,
	}

	/// <summary>Common log file system public flags and constants.</summary>
	[PInvokeData("clfs.h")]
	[Flags]
	public enum CLFS_FLAG : uint
	{
		/// <summary>Assigns no flags.</summary>
		CLFS_FLAG_NO_FLAGS = 0x00000000,

		/// <summary>
		/// Assigns a physical location for all appended records in a log that have not been previously assigned a physical location. All
		/// these records are made available for reading from other marshaling contexts.
		/// </summary>
		CLFS_FLAG_FORCE_APPEND = 0x00000001,

		/// <summary>
		/// Assigns a physical location for all appended records in a log that have not been previously assigned a physical location. All
		/// these records are made available for reading from other marshaling contexts. Then, the records are flushed to disk.
		/// </summary>
		CLFS_FLAG_FORCE_FLUSH = 0x00000002,

		/// <summary>Appends the current record by using the space that is reserved in the marshaling area.</summary>
		CLFS_FLAG_USE_RESERVATION = 0x00000004,

		CLFS_FLAG_REENTRANT_FILE_SYSTEM = 0x00000008,
		CLFS_FLAG_NON_REENTRANT_FILTER = 0x00000010,
		CLFS_FLAG_REENTRANT_FILTER = 0x00000020,
		CLFS_FLAG_IGNORE_SHARE_ACCESS = 0x00000040,
		CLFS_FLAG_READ_IN_PROGRESS = 0x00000080,
		CLFS_FLAG_MINIFILTER_LEVEL = 0x00000100,
		CLFS_FLAG_HIDDEN_SYSTEM_LOG = 0x00000200,
	}

	/// <summary>
	/// Defines types of I/O statistics reported by CLFS and is used when a client calls GetLogIoStatistics. Currently, log flush rates are
	/// the only type of statistic reported, but this enumeration will reflect more types of statistics in the future.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfs/ne-clfs-clfs_iostats_class typedef enum _CLFS_IOSTATS_CLASS {
	// ClfsIoStatsDefault = 0x0000, ClfsIoStatsMax = 0xFFFF } CLFS_IOSTATS_CLASS, *PCLFS_IOSTATS_CLASS, PPCLFS_IOSTATS_CLASS;
	[PInvokeData("clfs.h", MSDNShortId = "NE:clfs._CLFS_IOSTATS_CLASS")]
	public enum CLFS_IOSTATS_CLASS
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0x0000</para>
		/// <para>The default I/O statistics exported.</para>
		/// </summary>
		ClfsIoStatsDefault = 0x0000,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0xFFFF</para>
		/// <para>The log flush rate.</para>
		/// </summary>
		ClfsIoStatsMax = 0xFFFF,
	}

	/// <summary>Specifies whether a log is ephemeral.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfs/ne-clfs-clfs_log_archive_mode typedef enum _CLFS_LOG_ARCHIVE_MODE {
	// ClfsLogArchiveEnabled = 0x01, ClfsLogArchiveDisabled = 0x02 } CLFS_LOG_ARCHIVE_MODE, *PCLFS_LOG_ARCHIVE_MODE;
	[PInvokeData("clfs.h", MSDNShortId = "NE:clfs._CLFS_LOG_ARCHIVE_MODE")]
	public enum CLFS_LOG_ARCHIVE_MODE
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0x01</para>
		/// <para>Enables log archive (ephemeral logs) support.</para>
		/// </summary>
		ClfsLogArchiveEnabled = 1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>0x02</para>
		/// <para>Disables ephemeral logs.</para>
		/// </summary>
		ClfsLogArchiveDisabled,
	}

	/// <summary>Marshalling Context Flag</summary>
	[PInvokeData("clfs.h")]
	[Flags]
	public enum CLFS_MARSHALLING_FLAG : uint
	{
		CLFS_MARSHALLING_FLAG_NONE = 0x00000000,
		CLFS_MARSHALLING_FLAG_DISABLE_BUFF_INIT = 0x00000001,
	}

	/// <summary>Container scan mode flags.</summary>
	[PInvokeData("clfs.h")]
	[Flags]
	public enum CLFS_SCAN_MODE : byte
	{
		/// <summary>
		/// Reinitializes the scan context, but does not allocate associated storage. The initialization is destructive, because all data
		/// that is stored in the current scan context is lost.
		/// </summary>
		CLFS_SCAN_INIT = 0x01,

		/// <summary>
		/// Causes the next call to ScanLogContainers to proceed in a forward direction. Cannot be used if CLFS_SCAN_BACKWARD is specified.
		/// </summary>
		CLFS_SCAN_FORWARD = 0x02,

		/// <summary>
		/// Causes the next call to ScanLogContainers to proceed in a backward direction. Cannot be used if CLFS_SCAN_FORWARD is specified.
		/// </summary>
		CLFS_SCAN_BACKWARD = 0x04,

		/// <summary>Uninitializes the scan context, and deallocates system storage that is associated with a scan context.</summary>
		CLFS_SCAN_CLOSE = 0x08,

		/// <summary>Indicates that the scan context is already initialized.</summary>
		CLFS_SCAN_INITIALIZED = 0x10,

		/// <summary>Indicates that the scanned container descriptors are pre-fetched and buffered.</summary>
		CLFS_SCAN_BUFFERED = 0x20,
	}

	/// <summary>Definition of record types.</summary>
	[PInvokeData("clfs.h")]
	[Flags]
	public enum CLS_RECORD_TYPE : byte
	{
		/// <summary>The default record type of ClfsDataRecord is used.</summary>
		ClfsNullRecord = 0x00,

		/// <summary>User data records are read.</summary>
		ClfsDataRecord = 0x01,

		/// <summary>Restart records are read.</summary>
		ClfsRestartRecord = 0x02,

		/// <summary>Both restart and data records are read.</summary>
		ClfsClientRecord = 0x03
	}

	/// <summary>Determines whether two LSNs from the same stream are equal.</summary>
	/// <param name="plsn1">A pointer to a CLFS_LSN structure to be compared with <c>plsn2</c>.</param>
	/// <param name="plsn2">A pointer to a CLFS_LSN structure to be compared with <c>plsn1</c>.</param>
	/// <returns>Returns <c>TRUE</c> if the two LSNs are equal; otherwise, <c>FALSE</c>.</returns>
	/// <remarks>
	/// <para>CLFS_LSN_NULL (the smallest LSN) and CLFS_LSN_INVALID (larger than any valid LSN) are valid arguments to this function.</para>
	/// <para>LSNs from different streams are not comparable. Do not use this function to compare LSNs from different streams.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfs/nf-clfs-clfslsnequal CLFSUSER_API BOOLEAN LsnEqual( [in] const CLS_LSN *plsn1,
	// [in] const CLS_LSN *plsn2 );
	[DllImport(Lib_Clfsw32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("clfs.h", MSDNShortId = "NF:clfs.ClfsLsnEqual")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern bool LsnEqual(in CLS_LSN plsn1, in CLS_LSN plsn2);

	/// <summary>Determines whether one LSN is greater than another LSN. The two LSNs must be from the same stream.</summary>
	/// <param name="plsn1">A pointer to a CLFS_LSN structure to be compared with <c>plsn2</c>.</param>
	/// <param name="plsn2">A pointer to a CLFS_LSN structure to be compared with <c>plsn1</c>.</param>
	/// <returns><c>TRUE</c> if <c>plsn1</c> is strictly greater than <c>plsn2</c>; otherwise, <c>FALSE</c>.</returns>
	/// <remarks>
	/// <para>CLFS_LSN_NULL (the smallest LSN) and CLFS_LSN_INVALID (larger than any valid LSN) are valid arguments to this function.</para>
	/// <para>LSNs from different streams are not comparable. Do not use this function to compare LSNs from different streams.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfs/nf-clfs-clfslsngreater CLFSUSER_API BOOLEAN LsnGreater( [in] const CLS_LSN
	// *plsn1, [in] const CLS_LSN *plsn2 );
	[DllImport(Lib_Clfsw32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("clfs.h", MSDNShortId = "NF:clfs.ClfsLsnGreater")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern bool LsnGreater(in CLS_LSN plsn1, in CLS_LSN plsn2);

	/// <summary>Determines whether one LSN is less than another LSN. The two LSNs must be from the same stream.</summary>
	/// <param name="plsn1">A pointer to a CLFS_LSN structure to be compared with <c>plsn2</c>.</param>
	/// <param name="plsn2">A pointer to a CLFS_LSN structure to be compared with <c>plsn1</c>.</param>
	/// <returns><c>TRUE</c> if <c>plsn1</c> is strictly less than <c>plsn2</c>; otherwise, <c>FALSE</c>.</returns>
	/// <remarks>
	/// <para>CLFS_LSN_NULL (the smallest LSN) and CLFS_LSN_INVALID (larger than any valid LSN) are valid arguments to this function.</para>
	/// <para>LSNs from different streams are not comparable. Do not use this function to compare LSNs from different streams.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfs/nf-clfs-clfslsnless CLFSUSER_API BOOLEAN LsnLess( [in] const CLS_LSN *plsn1,
	// [in] const CLS_LSN *plsn2 );
	[DllImport(Lib_Clfsw32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("clfs.h", MSDNShortId = "NF:clfs.ClfsLsnLess")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern bool LsnLess(in CLS_LSN plsn1, in CLS_LSN plsn2);

	/// <summary>Determines whether a specified LSN is equal to the smallest possible LSN, which is CLFS_LSN_NULL.</summary>
	/// <param name="plsn">A pointer to the CLFS_LSN structure to be tested.</param>
	/// <returns><c>TRUE</c> if <c>plsn</c> is equal to CLFS_LSN_NULL; otherwise, <c>FALSE</c>.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfs/nf-clfs-clfslsnnull CLFSUSER_API BOOLEAN LsnNull( [in] const CLS_LSN *plsn );
	[DllImport(Lib_Clfsw32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("clfs.h", MSDNShortId = "NF:clfs.ClfsLsnNull")]
	[return: MarshalAs(UnmanagedType.U1)]
	public static extern bool LsnNull(in CLS_LSN plsn);

	/// <summary>Represents a node identifier.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfs/ns-clfs-clfs_node_id typedef struct _CLFS_NODE_ID { ULONG cType; ULONG cbNode;
	// } CLFS_NODE_ID, *PCLFS_NODE_ID;
	[PInvokeData("clfs.h", MSDNShortId = "NS:clfs._CLFS_NODE_ID")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CLFS_NODE_ID
	{
		/// <summary>The CLFS node type.</summary>
		public uint cType;

		/// <summary>The size of the CLFS node, in bytes.</summary>
		public uint cbNode;
	}

	/// <summary>Used by the GetNextLogArchiveExtent function to return information about log archive extents.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfs/ns-clfs-cls_archive_descriptor typedef struct _CLS_ARCHIVE_DESCRIPTOR {
	// ULONGLONG coffLow; ULONGLONG coffHigh; CLS_CONTAINER_INFORMATION infoContainer; } CLS_ARCHIVE_DESCRIPTOR, *PCLS_ARCHIVE_DESCRIPTOR, PPCLS_ARCHIVE_DESCRIPTOR;
	[PInvokeData("clfs.h", MSDNShortId = "NS:clfs._CLS_ARCHIVE_DESCRIPTOR")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct CLS_ARCHIVE_DESCRIPTOR
	{
		/// <summary>The offset in the container to the first byte of the archive extent.</summary>
		public ulong coffLow;

		/// <summary>The offset in the container to the last byte of the archive extent.</summary>
		public ulong coffHigh;

		/// <summary>
		/// The container information structure that describes the container associated with the archive extent. For more information, see CLFS_CONTAINER_INFORMATION.
		/// </summary>
		public CLS_CONTAINER_INFORMATION infoContainer;
	}

	/// <summary>
	/// Describes general information about a container. The CreateLogContainerScanContext and ScanLogContainers functions use container
	/// descriptors to scan and return information about all Common Log File System (CLFS) containers.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfs/ns-clfs-cls_container_information typedef struct _CLS_CONTAINER_INFORMATION {
	// ULONG FileAttributes; ULONGLONG CreationTime; ULONGLONG LastAccessTime; ULONGLONG LastWriteTime; LONGLONG ContainerSize; ULONG
	// FileNameActualLength; ULONG FileNameLength; WCHAR FileName[CLFS_MAX_CONTAINER_INFO]; CLFS_CONTAINER_STATE State; CLFS_CONTAINER_ID
	// PhysicalContainerId; CLFS_CONTAINER_ID LogicalContainerId; } CLS_CONTAINER_INFORMATION, *PCLS_CONTAINER_INFORMATION, PPCLS_CONTAINER_INFORMATION;
	[PInvokeData("clfs.h", MSDNShortId = "NS:clfs._CLS_CONTAINER_INFORMATION")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct CLS_CONTAINER_INFORMATION
	{
		/// <summary>
		/// <para>The file system attributes. CLFS uses the following attributes:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>FILE_ATTRIBUTE_ARCHIVE - The log is not ephemeral.</term>
		/// </item>
		/// <item>
		/// <term>FILE_ATTRIBUTE_DEDICATED - The log is not multiplexed.</term>
		/// </item>
		/// <item>
		/// <term>FILE_ATTRIBUTE_READONLY - The file is read-only. Applications can read the file, but cannot write to it or delete it.</term>
		/// </item>
		/// </list>
		/// <para>CLFS ignores but preserves all other file attribute values. The</para>
		/// <para>SetFileAttributes</para>
		/// <para>topic lists the valid values for attributes.</para>
		/// </summary>
		public FileFlagsAndAttributes FileAttributes;

		/// <summary>The time a file is created.</summary>
		public FILETIME CreationTime;

		/// <summary>The last time a container is read from or written to.</summary>
		public FILETIME LastAccessTime;

		/// <summary>The last time a container is written to.</summary>
		public FILETIME LastWriteTime;

		/// <summary>The size of a container, in bytes.</summary>
		public long ContainerSize;

		/// <summary>
		/// <para>The size of the actual file name, in characters.</para>
		/// <para>This number is different than <c>FileNameLength</c> when the file name of the container is longer than MAX_PATH_LENGTH.</para>
		/// </summary>
		public uint FileNameActualLength;

		/// <summary>The size of the file name in the <c>FileName</c> buffer, in characters.</summary>
		public uint FileNameLength;

		/// <summary>A pointer to a string that contains the file name for a container.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
		public string FileName;

		/// <summary>
		/// <para>The current state of a container.</para>
		/// <para>This member can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>ClfsContainerInitializing</c></term>
		/// <term>The container is in the process of initializing.</term>
		/// </item>
		/// <item>
		/// <term><c>ClfsContainerInactive</c></term>
		/// <term>The container is allocated, but is not in the active region of the log.</term>
		/// </item>
		/// <item>
		/// <term><c>ClfsContainerActive</c></term>
		/// <term>The container is being used as storage for part of the log.</term>
		/// </item>
		/// <item>
		/// <term><c>ClfsContainerActivePendingDelete</c></term>
		/// <term>The container is marked for deletion, but still contains part of the active log.</term>
		/// </item>
		/// <item>
		/// <term><c>ClfsContainerPendingArchive</c></term>
		/// <term>The container is marked for archive.</term>
		/// </item>
		/// <item>
		/// <term><c>ClfsContainerPendingArchiveAndDelete</c></term>
		/// <term>The container is marked for deletion, but still contains log data that is not archived.</term>
		/// </item>
		/// </list>
		/// </summary>
		public CLFS_CONTAINER_STATE State;

		/// <summary>The physical container identifier that cannot be changed.</summary>
		public CLFS_CONTAINER_ID PhysicalContainerId;

		/// <summary>The logical container identifier that changes every time the container is recycled.</summary>
		public CLFS_CONTAINER_ID LogicalContainerId;
	}

	/// <summary>Describes general information about a log. The GetLogFileInformation function returns the <c>CLFS_INFORMATION</c> structure.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfs/ns-clfs-cls_information typedef struct _CLS_INFORMATION { LONGLONG
	// TotalAvailable; LONGLONG CurrentAvailable; LONGLONG TotalReservation; ULONGLONG BaseFileSize; ULONGLONG ContainerSize; ULONG
	// TotalContainers; ULONG FreeContainers; ULONG TotalClients; ULONG Attributes; ULONG FlushThreshold; ULONG SectorSize; CLS_LSN
	// MinArchiveTailLsn; CLS_LSN BaseLsn; CLS_LSN LastFlushedLsn; CLS_LSN LastLsn; CLS_LSN RestartLsn; GUID Identity; } CLS_INFORMATION,
	// *PCLS_INFORMATION, *PPCLS_INFORMATION;
	[PInvokeData("clfs.h", MSDNShortId = "NS:clfs._CLS_INFORMATION")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CLS_INFORMATION
	{
		/// <summary>
		/// <para>The total available space that is allocated to a log, in bytes.</para>
		/// <para>This member is the sum of the sizes of all containers that are allocated to the dedicated log.</para>
		/// </summary>
		public long TotalAvailable;

		/// <summary>The space that is available in a log to append new records and reservation allocations, in bytes.</summary>
		public long CurrentAvailable;

		/// <summary>The total space in a log that is dedicated to reservation allocations.</summary>
		public long TotalReservation;

		/// <summary>The size of the base log, in bytes.</summary>
		public ulong BaseFileSize;

		/// <summary>The size of a container, in bytes.</summary>
		public ulong ContainerSize;

		/// <summary>The number of active containers that are associated with a dedicated log.</summary>
		public uint TotalContainers;

		/// <summary>The number of containers that are not in an active log.</summary>
		public uint FreeContainers;

		/// <summary>The number of log streams that are active in a physical log.</summary>
		public uint TotalClients;

		/// <summary>
		/// The log attributes that are set by using the <c>fFlagsAndAttributes</c> parameter of CreateLogFile when a log is created.
		/// </summary>
		public uint Attributes;

		/// <summary>
		/// The number of bytes of data that can remain pending on the internal flush queue before the Common Log File System (CLFS)
		/// automatically writes the data to disk.
		/// </summary>
		public uint FlushThreshold;

		/// <summary>
		/// <para>The sector size of the underlying disk geometry, in bytes.</para>
		/// <para>The sector size is assumed to be a multiple of 512 and consistent across log containers.</para>
		/// </summary>
		public uint SectorSize;

		/// <summary>The log sequence number (LSN) of the log archive tail.</summary>
		public CLS_LSN MinArchiveTailLsn;

		/// <summary>The LSN that marks the start of the active region of a log.</summary>
		public CLS_LSN BaseLsn;

		/// <summary>
		/// The value of <c>LastFlushedLsn</c> indicates that any LSNs smaller than the one specified are already flushed to disk.
		/// </summary>
		public CLS_LSN LastFlushedLsn;

		/// <summary>The value of <c>LastLsn</c> indicates that any LSNs smaller than the one specified are already appended to the log.</summary>
		public CLS_LSN LastLsn;

		/// <summary>
		/// <para>The LSN of the last written restart record.</para>
		/// <para>If the log does not have a restart area, the LSN has the value of CLFS_LSN_INVALID.</para>
		/// </summary>
		public CLS_LSN RestartLsn;

		/// <summary>The unique identifier for a log.</summary>
		public Guid Identity;
	}

	/// <summary>
	/// Defines the statistics that are reported by GetLogIoStatistics. Initially, statistics packets report only flush statistics, including
	/// the frequency of data and metadata flushes on a physical log and the amount of data and metadata flushed. The flush statistics are
	/// defined by the following I/O statistics packet types.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfs/ns-clfs-cls_io_statistics typedef struct _CLS_IO_STATISTICS {
	// CLS_IO_STATISTICS_HEADER hdrIoStats; ULONGLONG cFlush; ULONGLONG cbFlush; ULONGLONG cMetaFlush; ULONGLONG cbMetaFlush; }
	// CLS_IO_STATISTICS, *PCLS_IO_STATISTICS, PPCLS_IO_STATISTICS;
	[PInvokeData("clfs.h", MSDNShortId = "NS:clfs._CLS_IO_STATISTICS")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CLS_IO_STATISTICS
	{
		/// <summary>The header for the statistics buffer.</summary>
		public CLS_IO_STATISTICS_HEADER hdrIoStats;

		/// <summary>The frequency of data flushes for the logging session.</summary>
		public ulong cFlush;

		/// <summary>The cumulative number of bytes of data flushed in the logging session.</summary>
		public ulong cbFlush;

		/// <summary>The frequency of metadata flushes for the logging session.</summary>
		public ulong cMetaFlush;

		/// <summary>The cumulative number of bytes of metadata flushed in the logging session.</summary>
		public ulong cbMetaFlush;
	}

	/// <summary>
	/// Header for information retrieved by the GetLogIoStatistics function, which defines the I/O performance counters of a log.
	/// </summary>
	/// <remarks>This header is followed by the I/O statistics counters.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfs/ns-clfs-cls_io_statistics_header typedef struct _CLS_IO_STATISTICS_HEADER {
	// UCHAR ubMajorVersion; UCHAR ubMinorVersion; CLFS_IOSTATS_CLASS eStatsClass; USHORT cbLength; ULONG coffData; }
	// CLS_IO_STATISTICS_HEADER, *PCLS_IO_STATISTICS_HEADER, PPCLS_IO_STATISTICS_HEADER;
	[PInvokeData("clfs.h", MSDNShortId = "NS:clfs._CLS_IO_STATISTICS_HEADER")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CLS_IO_STATISTICS_HEADER
	{
		/// <summary>The major version of the statistics buffer.</summary>
		public byte ubMajorVersion;

		/// <summary>The minor version of the statistics buffer.</summary>
		public byte ubMinorVersion;

		/// <summary>
		/// The class of I/O statistics that is exported. Currently, flush statistics are the only statistics information exported. These
		/// statistics include the frequency of data and metadata flushes on a dedicated log and the amount of data and metadata flushed.
		/// Because flush statistics are the sole statistics class, this member is currently unused but will be used in the future.
		/// </summary>
		public CLFS_IOSTATS_CLASS eStatsClass;

		/// <summary>The length of the statistics buffer, including the header.</summary>
		public ushort cbLength;

		/// <summary>
		/// The offset of statistics counters from the beginning of the packet where the statistics data begins. This field allows
		/// transparent modifications to the header and length without affecting how the statistics data is accessed.
		/// </summary>
		public uint coffData;
	}

	/// <summary>Represents a valid log address.</summary>
	/// <remarks>
	/// <para>
	/// The LSN is the valid address that is unique to a client, and returned after the client appends a record to the log. The address
	/// remains valid if the system does not fail, or its marshaled log buffer is flushed successfully to disk.
	/// </para>
	/// <para>In log streams, LSNs increase monotonically. You cannot compare LSNs between log streams.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfs/ns-clfs-cls_lsn typedef struct _CLS_LSN { ULONGLONG Internal; } CLS_LSN,
	// *PCLS_LSN, PPCLS_LSN;
	[PInvokeData("clfs.h", MSDNShortId = "NS:clfs._CLS_LSN")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CLS_LSN : IEquatable<CLS_LSN>, IComparable<CLS_LSN>
	{
		/// <summary>The log sequence number (LSN).</summary>
		public ulong Internal;

		/// <summary>Creates a log sequence number (LSN), given a container ID, a block offset, and a record sequence number.</summary>
		/// <param name="cidContainer">The container ID. This value must be an integer between 0x0 and 0xFFFFFFFF.</param>
		/// <param name="offBlock">The block offset. This value must be a multiple of 512.</param>
		/// <param name="cRecord">The record sequence number. This value must be an integer between 0 - 511.</param>
		public CLS_LSN(CLFS_CONTAINER_ID cidContainer, uint offBlock, uint cRecord) => Internal = LsnCreate(cidContainer, offBlock, cRecord).Internal;

		/// <summary>Retrieves the logical container ID from this LSN.</summary>
		/// <value>
		/// Returns the logical container ID. The logical container ID is not necessarily the same as the ID of the physical container on
		/// stable storage.
		/// </value>
		public CLFS_CONTAINER_ID ContainerId => LsnContainer(this);

		/// <summary>Returns the sector-aligned block offset that is contained in this LSN.</summary>
		/// <value><c>LsnBlockOffset</c> returns the block offset.</value>
		/// <remarks>
		/// <para>
		/// The block offset that is returned is a multiple of the sector size on the stable storage medium. For example, if the sector size
		/// is 1024 bytes, the block offset is a multiple of 1024.
		/// </para>
		/// </remarks>
		public uint BlockOffset => LsnBlockOffset(this);

		/// <summary>Retrieves the record sequence number.</summary>
		/// <value>The record sequence number.</value>
		public uint RecordSequence => LsnRecordSequence(this);

		/// <summary>Determines if this is equal to CLFS_LSN_INVALID.</summary>
		/// <value><see langword="true"/> if <c>plsn</c> is equal to CLFS_LSN_INVALID; otherwise, <see langword="false"/>.</value>
		public bool IsInvalid => LsnInvalid(this);

		/// <summary>Determines if this is equal to the smallest possible LSN, which is CLFS_LSN_NULL.</summary>
		/// <value><see langword="true"/> if <c>plsn</c> is equal to CLFS_LSN_NULL; otherwise, <see langword="false"/>.</value>
		public bool IsNull => LsnNull(this);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="left">The left.</param>
		/// <param name="right">The right.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(CLS_LSN left, CLS_LSN right) => left.Equals(right);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="left">The left.</param>
		/// <param name="right">The right.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(CLS_LSN left, CLS_LSN right) => !(left==right);

		/// <summary>Implements the operator &gt;.</summary>
		/// <param name="left">The left.</param>
		/// <param name="right">The right.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator >(CLS_LSN left, CLS_LSN right) => LsnGreater(left, right);

		/// <summary>Implements the operator &lt;.</summary>
		/// <param name="left">The left.</param>
		/// <param name="right">The right.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator <(CLS_LSN left, CLS_LSN right) => LsnLess(left, right);

		/// <summary>Implements the operator op_Increment.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the operator.</returns>
		public static CLS_LSN operator ++(CLS_LSN value) => LsnIncrement(value);

		/// <summary>Implements the operator op_Decrement.</summary>
		/// <param name="value">The value.</param>
		/// <returns>The result of the operator.</returns>
		public static CLS_LSN operator --(CLS_LSN value) => LsnDecrement(value);

		/// <inheritdoc/>
		public int CompareTo(CLS_LSN other) => LsnLess(this, other) ? -1 : (LsnEqual(this, other) ? 0 : 1);

		/// <inheritdoc/>
		public override bool Equals(object obj) => obj is CLS_LSN lSN && Equals(lSN);

		/// <inheritdoc/>
		public bool Equals(CLS_LSN other) => LsnEqual(this, other);

		/// <inheritdoc/>
		public override int GetHashCode() => 158955808+Internal.GetHashCode();

		/// <inheritdoc/>
		public override string ToString() => $"{{{Internal}}}";

		/// <summary>Represents an invalid LSN.</summary>
		public static readonly CLS_LSN CLFS_LSN_INVALID = new() { Internal = 0xFFFFFFFF00000000UL };

		/// <summary>Represents a NULL LSN.</summary>
		public static readonly CLS_LSN CLFS_LSN_NULL = default;
	}

	/// <summary>
	/// Contains information about the containers that are being scanned by ScanLogContainers, the kind of scan that is being performed, and
	/// a cursor to track which containers have been scanned.
	/// </summary>
	/// <remarks>
	/// This structure is allocated by the client, initialized using CreateLogContainerScanContext, and then passed to ScanLogContainers in
	/// repeated calls.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfs/ns-clfs-cls_scan_context-r1 typedef struct _CLS_SCAN_CONTEXT { CLFS_NODE_ID
	// cidNode; HANDLE hLog; ULONG cIndex; ULONG cContainers; ULONG cContainersReturned; CLFS_SCAN_MODE eScanMode; PCLS_CONTAINER_INFORMATION
	// pinfoContainer; } CLS_SCAN_CONTEXT, *PCLS_SCAN_CONTEXT, PPCLS_SCAN_CONTEXT;
	[PInvokeData("clfs.h", MSDNShortId = "NS:clfs._CLS_SCAN_CONTEXT~r1")]
	[StructLayout(LayoutKind.Explicit, CharSet = CharSet.Unicode)]
	public struct CLS_SCAN_CONTEXT
	{
		/// <summary>The ID of the current node. For more information, see CLFS_NODE_ID.</summary>
		[FieldOffset(0)]
		public CLFS_NODE_ID cidNode;

		/// <summary>A handle to the log being scanned that is obtained from CreateLogFile with permissions to scan the log containers.</summary>
		[FieldOffset(8)]
		public HLOG hLog;

		/// <summary>The index of the current container.</summary>
		[FieldOffset(16)]
		public uint cIndex;

		/// <summary>
		/// <para>The number of system-allocated CLFS_CONTAINER_INFORMATION structures in an array that is pointed to by <c>pinfoContainer</c>.</para>
		/// <para>
		/// That is, this member is the number of containers to scan with each scan call. The caller knows the scan is complete when the
		/// number of containers returned is less than this value.
		/// </para>
		/// </summary>
		[FieldOffset(24)]
		public uint cContainers;

		/// <summary>The number of containers that are returned after a call to ScanLogContainers.</summary>
		[FieldOffset(32)]
		public uint cContainersReturned;

		/// <summary>
		/// <para>The mode in which containers are scanned.</para>
		/// <para>Containers can be scanned in one of the following modes.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term><c>CLFS_SCAN_INIT</c></term>
		/// <term>
		/// Initializes the scan context, but does not allocate associated storage. The initialization is destructive, because all data that
		/// is stored in the current scan context is lost.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>CLFS_SCAN_CLOSE</c></term>
		/// <term>Uninitializes the scan context and deallocates system storage that is associated with a scan context.</term>
		/// </item>
		/// <item>
		/// <term><c>CLFS_SCAN_FORWARD</c></term>
		/// <term>
		/// Causes the next call to ScanLogContainers to proceed in a forward direction. Cannot be used if <c>CLFS_SCAN_BACKWARD</c> is specified.
		/// </term>
		/// </item>
		/// <item>
		/// <term><c>CLFS_SCAN_BACKWARD</c></term>
		/// <term>
		/// Causes the next call to ScanLogContainers to proceed in a backward direction. Cannot be used if <c>CLFS_SCAN_FORWARD</c> is specified.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		[FieldOffset(40)]
		public CLFS_SCAN_MODE eScanMode;

		[FieldOffset(48)]
		private IntPtr _pinfoContainer;

		/// <summary>
		/// A pointer to a client-allocated array of CLFS_CONTAINER_INFORMATION structures to be filled by ScanLogContainers after each
		/// successful call.
		/// </summary>
		public CLS_CONTAINER_INFORMATION[] pinfoContainer => _pinfoContainer.ToArray<CLS_CONTAINER_INFORMATION>((int)cContainersReturned);
	}

	/// <summary>
	/// Contains a user buffer, which is to become part of a log record, and its length. The ReserveAndAppendLog function uses
	/// <c>CLFS_WRITE_ENTRY</c> structures in the routine that appends log records to logs. This routine requires the client to specify a set
	/// of structures. <c>ReserveAndAppendLog</c> gathers these structures and formats them into a log record in a marshaling buffer, which
	/// is eventually flushed to the log.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/clfs/ns-clfs-cls_write_entry typedef struct _CLS_WRITE_ENTRY { PVOID Buffer; ULONG
	// ByteLength; } CLS_WRITE_ENTRY, *PCLS_WRITE_ENTRY, PPCLS_WRITE_ENTRY;
	[PInvokeData("clfs.h", MSDNShortId = "NS:clfs._CLS_WRITE_ENTRY")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CLS_WRITE_ENTRY
	{
		/// <summary>The log record data buffer.</summary>
		public IntPtr Buffer;

		/// <summary>The length of the log record data buffer, in bytes.</summary>
		public uint ByteLength;
	}
}