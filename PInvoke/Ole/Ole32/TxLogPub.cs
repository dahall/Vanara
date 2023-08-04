using LSN = System.Int64;

namespace Vanara.PInvoke;

public static partial class Ole32
{
	/// <summary>Specifies a hint about the order in which records are to be read from a log.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/txlogpub/ne-txlogpub-record_reading_policy typedef enum RECORD_READING_POLICY {
	// RECORD_READING_POLICY_FORWARD = 1, RECORD_READING_POLICY_BACKWARD = 2, RECORD_READING_POLICY_RANDOM = 3 } ;
	[PInvokeData("txlogpub.h", MSDNShortId = "NE:txlogpub.RECORD_READING_POLICY")]
	public enum RECORD_READING_POLICY
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>Indicates that records will be read in order of increasing LSN (from least recent to most recent).</para>
		/// </summary>
		RECORD_READING_POLICY_FORWARD = 1,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>Indicates that records will be read in order of decreasing LSN (from most recent to least recent).</para>
		/// </summary>
		RECORD_READING_POLICY_BACKWARD,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>Indicates that records may be read in any order.</para>
		/// </summary>
		RECORD_READING_POLICY_RANDOM,
	}

	/// <summary>Initializes an instance of a file based implementation of ILog.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/txlogpub/nn-txlogpub-ifilebasedloginit
	[PInvokeData("txlogpub.h", MSDNShortId = "NN:txlogpub.IFileBasedLogInit")]
	[ComImport, Guid("00951E8C-1294-11d1-97E4-00C04FB9618A"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(SimpleFileBasedLog))]
	public interface IFileBasedLogInit
	{
		/// <summary>Create a new log instance on the specified file. If a file with that name already exists, it is overwritten.</summary>
		/// <param name="filename">The absolute path of the file to be created.</param>
		/// <param name="cbCapacityHint">A hint to the implementation about the total capacity that will be needed.</param>
		// https://docs.microsoft.com/en-us/windows/win32/api/txlogpub/nf-txlogpub-ifilebasedloginit-initnew HRESULT InitNew( [in] LPCWSTR
		// filename, [in] ULONG cbCapacityHint );
		void InitNew([MarshalAs(UnmanagedType.LPWStr)] string filename, uint cbCapacityHint);
	}

	/// <summary>
	/// <para>Provides generic low-level logging functionality.</para>
	/// <para>The Common Log File System (CLFS), provides functionality that is a superset of that provided by <c>ILog</c>.</para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// WAL is a technique used by certain applications, such as database management systems, to implement atomic and isolated transactions.
	/// This technique involves writing records of changes to the application's resources to a log before you make these changes. This way
	/// the changes can be reverted if they are required, for example if the transaction fails or is interrupted. In order for applications
	/// to provide transactions that are robust against interruptions such as system crash or power failure, the logging implementation must
	/// provide a method for forcing the log; that is, to make sure that previously written records are on disk before continuing.
	/// </para>
	/// <para>
	/// Writing records that use <c>ILog</c> is a sequential operation; that is, new records are always appended to the end of the log. Each
	/// record appended to the log is assigned a log sequence number (LSN), a numeric identifier which may be used to retrieve the record
	/// later. The data type LSN is a typedef for LARGE_INTEGER, a signed 64-bit value; however, <c>ILog</c> uses only LSNs with nonnegative
	/// values. In addition, LSNs must satisfy the following conditions:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// LSNs are monotonically increasing; if record B is written to the log after record A, the LSN of record B must be larger than the LSN
	/// of record A.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// Values of zero and MAXLSN (0x7FFFFFFFFFFFFFFF) must never be used as the LSN of a record, as they have special meaning to some of the
	/// methods of <c>ILog</c>.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// Other than the conditions here, no assumptions should be made about how LSNs are assigned by an implementation of <c>ILog</c>. In
	/// particular, it is not safe to assume that records will be assigned sequential values for LSNs.
	/// </para>
	/// <para>
	/// After a record is appended to the log, it may not be modified. However, when previously written records are no longer needed, for
	/// example records of changes in a transaction that has already been committed, <c>ILog</c> supports truncating the log. This way, disk
	/// space that was used for nonessential records may be reused. Truncating the log consists of deleting all records with an LSN less than
	/// a specified value.
	/// </para>
	/// <para>
	/// As a performance optimization, some implementations of <c>ILog</c> may buffer records in memory until the log is forced. If this is
	/// the case, special you must consider error control and recovery. Consider the following situation:
	/// </para>
	/// <list type="number">
	/// <item>
	/// <term>
	/// Record A is appended to the log, but the log is not forced. The <c>ILog</c> implementation copies the record to a buffer in memory
	/// and returns a success code.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// Record B is appended to the log, and the <c>ILog</c> implementation decides to force the log to disk. This is either because the
	/// caller asked the log to be forced or because the memory buffer is full. However, the write operation fails, for example because of
	/// low disk space.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// In this situation, it would be inappropriate for the <c>ILog</c> implementation to enable additional records to be appended to the
	/// log, unless it can guarantee that all records for which it returned a success code are first written to disk. One possible method of
	/// error control would be to pin the log in an error state when this situation occurs, permanently disallowing additional writes to the
	/// log instance. Callers that do not force the log to disk for each appended record should realize that this situation may occur and be
	/// able to handle it appropriately.
	/// </para>
	/// <para>ILog File-based Implementation</para>
	/// <para>
	/// The Windows operating system provides a file-based implementation of <c>ILog</c>, which enables you to create a log suited for
	/// write-ahead logging on a file. The log uses a file as a circular buffer, which enables unused space to be reused. This may also
	/// increase the size of the file that may be needed to fit additional records when the log is full. Changes to the log are made
	/// atomically, so that the contents of the log may be recovered after a crash. This implementation uses a buffer in memory for appending
	/// log records. As a result, records are not guaranteed to be written to disk when the ILog::AppendRecord method returns, unless the
	/// caller requests that the log be forced.
	/// </para>
	/// <para>Use the following CLSID to create an instance of a file based log (see CoCreateInstance):</para>
	/// <para>CLSID_SimpleFileBasedLog ({E16C0593-128F-11D1-97E4-00C04FB9618A} ).</para>
	/// <para>
	/// The file based implementation of <c>ILog</c> additionally supports the IFileBasedLogInit and IPersistFile interfaces. Use
	/// IFileBasedLogInit::InitNew to create a new log file. Use IPersistFile::Load to open an existing log file.
	/// </para>
	/// <para>
	/// This implementation uses a simple error control policy. If any one of the methods fails because of an error on the file-system level,
	/// which includes a disk full error, the log is pinned in an error state. This prevents clients from appending additional records to the
	/// file or reading potentially bad records. To continue to use the log file, you must create a new instance of the log.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/txlogpub/nn-txlogpub-ilog
	[PInvokeData("txlogpub.h", MSDNShortId = "NN:txlogpub.ILog")]
	[ComImport, Guid("FF222117-0C6C-11d2-B89A-00C04FB9618A"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ILog
	{
		/// <summary>Forces the contents of the log to disk, at least up through the specified LSN.</summary>
		/// <param name="lsnMinToForce">
		/// At the very least, all records that have not yet been written to disk with an LSN less than or equal to <c>lsnMinToForce</c> must
		/// be written to disk now. An implementation may, however, choose to write more records than what is strictly required. For example,
		/// an implementation is allowed to force all records to disk, regardless of the value of <c>lsnMinToForce</c>. Passing 0 as
		/// <c>lsnMinToForce</c> indicates that the entire log is to be forced to disk.
		/// </param>
		/// <remarks>
		/// <para>The log may also be forced to disk after appending individual records. See ILog::AppendRecord.</para>
		/// <para>Notes to Callers</para>
		/// <para>
		/// A failure return value indicates that any records appended to the log since the last time it was successfully forced are not
		/// guaranteed to be on disk. The ILog interface does not provide a method to determine which records have been successfully written
		/// to disk. If you need to know which records were successfully written to disk, you must force the log for each record. See ILog::AppendRecord.
		/// </para>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// It is recommended that you flush file buffers (for example, using the FlushFileBuffers function) before returning from this method.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/txlogpub/nf-txlogpub-ilog-force HRESULT Force( [in] LSN lsnMinToForce );
		void Force(LSN lsnMinToForce);

		/// <summary>Write a new record to the end of the log.</summary>
		/// <param name="rgBlob">A pointer to an array of BLOBs of data to be written.</param>
		/// <param name="cBlob">The size of the <c>rgBlob</c> array, in elements.</param>
		/// <param name="fForceNow">
		/// Indicates whether to force the data to disk. If <c>TRUE</c>, the contents of the log up to this record must be forced to disk
		/// before the call returns. If <c>FALSE</c>, this record may be buffered in memory to be written after the call returns successfully.
		/// </param>
		/// <param name="plsn">
		/// A pointer to the LSN of the newly appended record. If the LSN of the newly appended record is not needed, this parameter can be <c>NULL</c>.
		/// </param>
		/// <remarks>
		/// <para>
		/// Each log record written or read by ILog is an opaque BLOB of data. As a convenience to callers, <c>AppendRecord</c> allows
		/// multiple BLOBs to be concatenated into a single record; because many implementations of <c>ILog</c> will copy records to a buffer
		/// in memory, it may be inefficient for the caller to allocate memory for concatenating the parts of a record. However, once a
		/// record is appended to the log, <c>ILog</c> provides no method to extract individual BLOBs from the record. It is the
		/// responsibility of the caller to parse the data in records read from the log. See ILog::ReadRecord.
		/// </para>
		/// <para>Notes to Callers</para>
		/// <para>
		/// A failure return value indicates that any records appended to the log since the last time it was successfully forced are not
		/// guaranteed to be on disk. The ILog interface does not provide a method to determine which records have been successfully written
		/// to disk. If you need to know which records were successfully written to disk, you must force the log for each record.
		/// </para>
		/// <para>Notes to Implementers</para>
		/// <para>
		/// If <c>fForceNow</c> is <c>TRUE</c>, it is recommended that you flush file buffers (for example, using the FlushFileBuffers
		/// function) before returning from this method.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/txlogpub/nf-txlogpub-ilog-appendrecord HRESULT AppendRecord( [in] BLOB *rgBlob,
		// [in] ULONG cBlob, [in] BOOL fForceNow, [in, out] LSN *plsn );
		void AppendRecord([In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] BLOB[] rgBlob, uint cBlob, [MarshalAs(UnmanagedType.Bool)] bool fForceNow, out LSN plsn);

		/// <summary>Read a record from the log.</summary>
		/// <param name="lsnToRead">The LSN of the record to be read.</param>
		/// <param name="plsnPrev">
		/// A pointer to the LSN of the previous record (the record immediately preceding the record to be read). This parameter can be
		/// <c>NULL</c> if the LSN of the previous record is not needed. This parameter is 0 if there is no previous record in the log, or if
		/// an error occurs.
		/// </param>
		/// <param name="plsnNext">
		/// A pointer to the LSN of the next record (the record immediately following the record to read). This parameter can be <c>NULL</c>
		/// if the LSN of the next record is not needed. This parameter is MAXLSN (0x7FFFFFFFFFFFFFFF) if there is no next record in the log.
		/// This parameter is 0 if an error occurs.
		/// </param>
		/// <param name="ppbData">
		/// A pointer to a variable that will contain a pointer to the record data on return. The memory for this data is allocated by
		/// <c>ReadRecord</c> and freed by the caller (see CoTaskMemFree). This parameter is <c>NULL</c> if an error occurs.
		/// </param>
		/// <param name="pcbData">A pointer to a variable that receives the size of the record data, in bytes, on return.</param>
		/// <remarks>
		/// <para>
		/// Although records appended to the log using ILog::AppendRecord may be concatenated from multiple BLOBs, <c>ReadRecord</c> returns
		/// the record as a single opaque blob of data. ILog provides no method to extract individual BLOBs from the record. It is the
		/// responsibility of the caller to parse the data in records returned by <c>ReadRecord</c>.
		/// </para>
		/// <para>Notes to Callers</para>
		/// <para>
		/// If the log contains very large records, this method may fail because <c>ReadRecord</c> was unable to allocate sufficient memory
		/// for the record data. If the size of records is bounded or if you only need an initial part of the record, it may be more
		/// efficient to call ILog::ReadRecordPrefix.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/txlogpub/nf-txlogpub-ilog-readrecord HRESULT ReadRecord( [in] LSN lsnToRead,
		// [in, out] LSN *plsnPrev, [in, out] LSN *plsnNext, [out] BYTE **ppbData, [out] ULONG *pcbData );
		unsafe void ReadRecord(LSN lsnToRead, [In, Out, Optional] LSN* plsnPrev, [In, Out, Optional] LSN* plsnNext, out SafeCoTaskMemHandle ppbData, out uint pcbData);

		/// <summary>Reads an initial part of a record from the log.</summary>
		/// <param name="lsnToRead">The LSN of the record to be read.</param>
		/// <param name="plsnPrev">
		/// A pointer to the LSN of the previous record (the record immediately preceding the record to read). You may pass <c>NULL</c> if
		/// the LSN of the previous record is not needed. This parameter is 0 if there is no previous record in the log or if an error occurs.
		/// </param>
		/// <param name="plsnNext">
		/// A pointer to the LSN of the next record (the record immediately following the record to read). You may pass <c>NULL</c> if the
		/// LSN of the next record is not needed. This parameter is MAXLSN (0x7FFFFFFFFFFFFFFF) if there is no next record in the log. This
		/// parameter is 0 if an error occurs.
		/// </param>
		/// <param name="pbData">A pointer to a buffer into which the record data is to be read.</param>
		/// <param name="pcbData">
		/// A pointer to a variable that contains the size in bytes of the buffer on input, and will contain the size in bytes of the record
		/// data read on return.
		/// </param>
		/// <param name="pcbRecord">
		/// A pointer to a variable that will contain the size in bytes of the entire record on return. You may pass <c>NULL</c> if the size
		/// of the entire record is not needed.
		/// </param>
		/// <remarks>
		/// Although records appended to the log using ILog::AppendRecord may be concatenated from multiple BLOBs, <c>ReadRecordPrefix</c>
		/// returns the record as a single opaque blob of data. ILog provides no method to extract individual BLOBs from the record. It is
		/// the responsibility of the caller to parse the data in records returned by <c>ReadRecordPrefix</c>.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/txlogpub/nf-txlogpub-ilog-readrecordprefix HRESULT ReadRecordPrefix( [in] LSN
		// lsnToRead, [in, out] LSN *plsnPrev, [in, out] LSN *plsnNext, [out] BYTE *pbData, [in, out] ULONG *pcbData, [out] ULONG *pcbRecord );
		unsafe void ReadRecordPrefix(LSN lsnToRead, [In, Out, Optional] LSN* plsnPrev, [In, Out, Optional] LSN* plsnNext, [Out] IntPtr pbData, ref uint pcbData, out uint pcbRecord);

		/// <summary>Retrieves information about the current bounds of the log.</summary>
		/// <param name="plsnFirst">
		/// A pointer to the LSN of the first record in the log. This parameter can be <c>NULL</c> if the LSN of the first record is not needed.
		/// </param>
		/// <param name="plsnLast">
		/// A pointer to the LSN of the last record in the log. This parameter can be <c>NULL</c> if the LSN of the last record is not needed.
		/// </param>
		/// <remarks>The limits returned by this method may include records that have not yet been written to disk.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/txlogpub/nf-txlogpub-ilog-getloglimits HRESULT GetLogLimits( [in, out] LSN
		// *plsnFirst, [in, out] LSN *plsnLast );
		unsafe void GetLogLimits([In, Out, Optional] LSN* plsnFirst, [In, Out, Optional] LSN* plsnLast);

		/// <summary>Throws away the specified prefix of the log, making it no longer retrievable.</summary>
		/// <param name="lsnFirstToKeep">The LSN of the first record not to be thrown away. If this parameter is 0, the entire log is emptied.</param>
		/// <remarks>
		/// This request is only a hint to the log implementation. The log is free to ignore the request, or to retain more than was strictly
		/// requested. Many ILog implementations will follow this latter option.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/txlogpub/nf-txlogpub-ilog-truncateprefix HRESULT TruncatePrefix( [in] LSN
		// lsnFirstToKeep );
		void TruncatePrefix(LSN lsnFirstToKeep);

		/// <summary>Provides a hint to the implementation about the pattern in which records will be read.</summary>
		/// <param name="policy">
		/// The pattern in which records will most often be read. For more information, see the RECORD_READING_POLICY enumeration.
		/// </param>
		/// <remarks>
		/// Not all implementations of ILog will be optimized for reading records in a particular pattern. An implementation may choose to
		/// ignore this request and return S_OK.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/txlogpub/nf-txlogpub-ilog-setaccesspolicyhint HRESULT SetAccessPolicyHint( [in]
		// RECORD_READING_POLICY policy );
		void SetAccessPolicyHint(RECORD_READING_POLICY policy);
	}

	/// <summary>CLSID_SimpleFileBasedLog</summary>
	[ComImport, Guid("e16c0593-128f-11d1-97e4-00c04fb9618a"), ClassInterface(ClassInterfaceType.None)]
	public class SimpleFileBasedLog { }
}