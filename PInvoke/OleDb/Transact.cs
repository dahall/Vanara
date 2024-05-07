#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member

using System.Runtime.CompilerServices;

namespace Vanara.PInvoke;

public static partial class OleDb
{
	/// <summary>infinite time-out value</summary>
	public const uint XACTCONST_TIMEOUTINFINITE = 0;

	/// <summary>The ISOFLAG enumeration values specify certain flags for a transaction.</summary>
	[PInvokeData("transact.h")]
	[Flags]
	public enum ISOFLAG
	{
		/// <summary>Use just one of ISOFLAG_RETAIN_COMMIT values.</summary>
		ISOFLAG_RETAIN_COMMIT_DC = 1,

		/// <summary></summary>
		ISOFLAG_RETAIN_COMMIT = 2,

		/// <summary></summary>
		ISOFLAG_RETAIN_COMMIT_NO = 3,

		/// <summary>Use just one of ISOFLAG_RETAIN_ABORT values.</summary>
		ISOFLAG_RETAIN_ABORT_DC = 4,

		/// <summary></summary>
		ISOFLAG_RETAIN_ABORT = 8,

		/// <summary></summary>
		ISOFLAG_RETAIN_ABORT_NO = 12,

		/// <summary></summary>
		ISOFLAG_RETAIN_DONTCARE = ISOFLAG_RETAIN_COMMIT_DC | ISOFLAG_RETAIN_ABORT_DC,

		/// <summary></summary>
		ISOFLAG_RETAIN_BOTH = ISOFLAG_RETAIN_COMMIT | ISOFLAG_RETAIN_ABORT,

		/// <summary></summary>
		ISOFLAG_RETAIN_NONE = ISOFLAG_RETAIN_COMMIT_NO | ISOFLAG_RETAIN_ABORT_NO,

		/// <summary></summary>
		ISOFLAG_OPTIMISTIC = 16,

		/// <summary></summary>
		ISOFLAG_READONLY = 32
	}

	/// <summary>The ISOLATIONLEVEL enumeration values specify the isolation levels of a transaction.</summary>
	[PInvokeData("transact.h")]
	public enum ISOLEVEL : uint
	{
		/// <summary>
		/// No isolation level was specified. Any isolation level is supported. A downstream component that has this isolation level always
		/// uses the same isolation level that its immediate upstream component uses. If the root object in a transaction has its isolation
		/// level configured to ISOLATIONLEVEL_UNSPECIFIED, its isolation level becomes ISOLATIONLEVEL_SERIALIZABLE.
		/// </summary>
		ISOLATIONLEVEL_UNSPECIFIED = 0xffffffff,

		/// <summary>No isolation level is used. It is not safe to use this level of isolation.</summary>
		ISOLATIONLEVEL_CHAOS = 0x10,

		/// <summary>
		/// A transaction can read any data, even if it is being modified by another transaction. Any type of new data can be inserted during
		/// a transaction. This is the least safe isolation level but allows the highest concurrency.
		/// </summary>
		ISOLATIONLEVEL_READUNCOMMITTED = 0x100,

		/// <summary>Same as ISOLATIONLEVEL_READUNCOMMITTED.</summary>
		ISOLATIONLEVEL_BROWSE = 0x100,

		/// <summary>Same as ISOLATIONLEVEL_READCOMMITTED.</summary>
		ISOLATIONLEVEL_CURSORSTABILITY = 0x1000,

		/// <summary>
		/// A transaction cannot read data that is being modified by another transaction that has not committed. Any type of new data can be
		/// inserted during a transaction. This is the default isolation level in Microsoft SQL Server.
		/// </summary>
		ISOLATIONLEVEL_READCOMMITTED = 0x1000,

		/// <summary>
		/// Data read by a current transaction cannot be changed by another transaction until the current transaction finishes. Any type of
		/// new data can be inserted during a transaction.
		/// </summary>
		ISOLATIONLEVEL_REPEATABLEREAD = 0x10000,

		/// <summary>
		/// Data read by a current transaction cannot be changed by another transaction until the current transaction finishes. No new data
		/// can be inserted that would affect the current transaction. This is the safest isolation level and is the default, but allows the
		/// lowest level of concurrency.
		/// </summary>
		ISOLATIONLEVEL_SERIALIZABLE = 0x100000,

		/// <summary>Same as ISOLATIONLEVEL_SERIALIZABLE.</summary>
		ISOLATIONLEVEL_ISOLATED = 0x100000
	}

	/// <summary>Specifies any configuration or startup options for the transaction manager object.</summary>
	[PInvokeData("xolehlp.h")]
	[Flags]
	public enum OLE_TM : uint
	{
		/// <summary>
		/// External callers should use this flag if they want the default behavior (which is to demand start DTC). This approach provides
		/// meaningful text and is preferable to directly using the value 0 for i_grfOptions.
		/// </summary>
		OLE_TM_FLAG_NONE = 0x00000000,

		/// <summary>Callers can specify this option if they do not want demand start of DTC.</summary>
		OLE_TM_FLAG_NODEMANDSTART = 0x00000001,

		/// <summary>
		/// If this flag is set, the application specifies that it does not wish to take advantage of any features that need agile recovery
		/// support. As a consequence, the application will be restricted to using the default transaction manager on a cluster. <br/>
		/// </summary>
		OLE_TM_FLAG_NOAGILERECOVERY = 0x00000002,

		/// <summary>
		/// Specifying this flag will cause DTC to query the lock status and fail demand start if someone else is holding SCM lock. This flag
		/// should not be used by external callers.
		/// </summary>
		OLE_TM_FLAG_QUERY_SERVICE_LOCKSTATUS = 0x80000000,

		/// <summary>
		/// Only components internal to the Transaction manager (such as XATM) should use this flag. This flag should not be used by external callers.
		/// </summary>
		OLE_TM_FLAG_INTERNAL_TO_TM = 0x40000000,
	}

	[PInvokeData("transact.h")]
	public enum XACTHEURISTIC
	{
		XACTHEURISTIC_ABORT = 1,
		XACTHEURISTIC_COMMIT = 2,
		XACTHEURISTIC_DAMAGE = 3,
		XACTHEURISTIC_DANGER = 4
	}

	[PInvokeData("transact.h")]
	public enum XACTRM
	{
		XACTRM_OPTIMISTICLASTWINS = 1,
		XACTRM_NOREADONLYPREPARES = 2
	}

	[PInvokeData("transact.h")]
	[Flags]
	public enum XACTSTAT
	{
		XACTSTAT_NONE,
		XACTSTAT_OPENNORMAL = 0x1,
		XACTSTAT_OPENREFUSED = 0x2,
		XACTSTAT_PREPARING = 0x4,
		XACTSTAT_PREPARED = 0x8,
		XACTSTAT_PREPARERETAINING = 0x10,
		XACTSTAT_PREPARERETAINED = 0x20,
		XACTSTAT_COMMITTING = 0x40,
		XACTSTAT_COMMITRETAINING = 0x80,
		XACTSTAT_ABORTING = 0x100,
		XACTSTAT_ABORTED = 0x200,
		XACTSTAT_COMMITTED = 0x400,
		XACTSTAT_HEURISTIC_ABORT = 0x800,
		XACTSTAT_HEURISTIC_COMMIT = 0x1000,
		XACTSTAT_HEURISTIC_DAMAGE = 0x2000,
		XACTSTAT_HEURISTIC_DANGER = 0x4000,
		XACTSTAT_FORCED_ABORT = 0x8000,
		XACTSTAT_FORCED_COMMIT = 0x10000,
		XACTSTAT_INDOUBT = 0x20000,
		XACTSTAT_CLOSED = 0x40000,
		XACTSTAT_OPEN = 0x3,
		XACTSTAT_NOTPREPARED = 0x7ffc3,
		XACTSTAT_ALL = 0x7ffff
	}

	[PInvokeData("transact.h")]
	[Flags]
	public enum XACTTC
	{
		XACTTC_NONE,
		XACTTC_SYNC_PHASEONE = 1,
		XACTTC_SYNC_PHASETWO = 2,
		XACTTC_SYNC = 2,
		XACTTC_ASYNC_PHASEONE = 4,
		XACTTC_ASYNC = 4
	}

	/// <summary>The <c>ITransaction</c> interface is used to commit and abort transactions and to obtain status information about transactions.</summary>
	/// <remarks>
	/// You obtain a pointer to this interface by calling the ITransactionDispenser::BeginTransaction method or the
	/// ITransactionImport::Import method.
	/// </remarks>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms686531(v=vs.85)
	[PInvokeData("transact.h")]
	[ComImport, Guid("0fb15084-af41-11ce-bd2b-204c4f4f5020"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ITransaction
	{
		/// <summary>Commits a transaction.</summary>
		/// <param name="fRetaining">
		/// <para>[in] Whether the commit is retaining or nonretaining.</para>
		/// <para>
		/// <para>Note</para>
		/// <para>
		/// A retaining commit or abort should not change the characteristics (isolation level, isolation flags, transaction options) of the
		/// transaction. The new unit of work retains the same characteristics as the committed work.
		/// </para>
		/// </para>
		/// </param>
		/// <param name="grfTC">
		/// <para>
		/// [in] Values taken from the enumeration XACTTC. Values that may be specified in grfTC are as follows. These values are mutually exclusive.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <description>Flag</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description>XACTTC_ASYNC_PHASEONE</description>
		/// <description>When this flag is specified, an asynchronous commit is performed.</description>
		/// </item>
		/// <item>
		/// <description>XACTTC_SYNC_PHASEONE</description>
		/// <description>
		/// When this flag is specified, the call to <c>ITransaction::Commit</c> returns after phase one of the two-phase commit protocol.
		/// </description>
		/// </item>
		/// <item>
		/// <description>XACTTC_SYNC_PHASETWO</description>
		/// <description>
		/// When this flag is specified, the call to <c>ITransaction::Commit</c> returns after phase two of the two-phase commit protocol.
		/// </description>
		/// </item>
		/// <item>
		/// <description>XACTTC_SYNC</description>
		/// <description>Synonym for XACTTC_SYNC_PHASETWO.</description>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="grfRM">[in] Must be zero.</param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>S_OK The transaction was successfully committed.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// XACT_S_ASYNC An asynchronous commit was specified. The commit operation has begun, but its outcome is not yet known. When the
		/// transaction is complete, notification will be sent by <c>ITransactionOutcomeEvents</c>.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_FAIL A provider-specific error occurred. The transaction was aborted.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_UNEXPECTED An unexpected error occurred. The transaction status is unknown.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>XACT_E_ABORTED The transaction was implicitly aborted before <c>ITransaction::Commit</c> was called.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>XACT_E_ALREADYINPROGRESS A commit or abort operation was already in progress. This call was ignored.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// XACT_E_CANTRETAIN Retaining commit is not supported, or a new unit of work could not be created. The commit succeeded and the
		/// session is in auto-commit mode.
		/// </para>
		/// <para>Commit was called on a distributed transaction with fRetaining set to TRUE.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>XACT_E_COMMITFAILED The transaction failed to commit for an unknown reason. The transaction was aborted.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>XACT_E_CONNECTION_DOWN The connection to the transaction manager failed. The transaction was aborted.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// XACT_E_INDOUBT The transaction status is in doubt. A communication failure occurred, or a transaction manager or resource manager
		/// has failed.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// XACT_E_NOTRANSACTION Unable to commit the transaction because it had already been explicitly committed or aborted. This call was ignored.
		/// </para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// XACT_E_NOTSUPPORTED An invalid combination of commit flags was specified, or grfRM was not equal to zero. This call was ignored.
		/// </para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms713008(v=vs.85) HRESULT Commit( BOOL fRetaining, DWORD
		// grfTC, DWORD grfRM);
		[PreserveSig]
		HRESULT Commit(bool fRetaining, XACTTC grfTC, uint grfRM = 0);

		/// <summary>
		/// <para></para>
		/// <para>
		/// Applies To: Windows 10, Windows 7, Windows 8, Windows 8.1, Windows Server 2008, Windows Server 2008 R2, Windows Server 2012,
		/// Windows Server 2012 R2, Windows Server Technical Preview, Windows Vista
		/// </para>
		/// <para>This method aborts the transaction.</para>
		/// </summary>
		/// <param name="pboidReason">
		/// [in] An optional BOID that indicates why the transaction is being aborted. This argument may be NULL indicating that no abort
		/// reason is provided.
		/// </param>
		/// <param name="fRetaining">[in] Must be FALSE.</param>
		/// <param name="fAsync">
		/// [in] When fAsync is TRUE, an asynchronous abort is performed and the caller must use <c>ITransactionOutcomeEvents</c> to learn
		/// the outcome of the transaction.
		/// </param>
		/// <returns></returns>
		/// <remarks>
		/// <para>The initiator of the transaction may abort the transaction as may any resource manager enlisted on the transaction.</para>
		/// <para>
		/// <c>Abort</c> may be invoked on a transaction repeatedly. XACT_S_ABORTING HRESULT will be returned following the first invocation
		/// of <c>Abort</c>.
		/// </para>
		/// <para>If a communication failure occurs during a call to <c>Commit</c> or <c>Abort</c>, the status of the transaction is unknown.</para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms688267(v=vs.85) HRESULT Abort( BOID * pboidReason, BOOL
		// fRetaining, BOOL fAsync);
		[PreserveSig]
		HRESULT Abort([In, Optional] IntPtr pboidReason, bool fRetaining, bool fAsync);

		/// <summary>Returns information regarding a transaction.</summary>
		/// <param name="pInfo">
		/// <para>
		/// [out] A pointer to the caller-allocated XACTTRANSINFO structure in which the method returns information about the transaction.
		/// pInfo must not be a null pointer.
		/// </para>
		/// <para>The elements of this structure are used as described in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Element</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>uow</c></description>
		/// <description>The unit of work associated with this transaction. Cannot be NULL and must be unique per transaction.</description>
		/// </item>
		/// <item>
		/// <description><c>isoLevel</c></description>
		/// <description>
		/// The isolation level associated with this transaction. ISOLATIONLEVEL_UNSPECIFIED indicates that no isolation level was specified.
		/// For more information, see ITransactionLocal::StartTransaction.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>isoFlags</c></description>
		/// <description>Will be zero.</description>
		/// </item>
		/// <item>
		/// <description><c>grfTCSupported</c></description>
		/// <description>This bitmask indicates the XACTTC flags that this transaction implementation supports.</description>
		/// </item>
		/// <item>
		/// <description><c>grfRMSupported</c></description>
		/// <description>Will be zero.</description>
		/// </item>
		/// <item>
		/// <description><c>grfTCSupportedRetaining</c></description>
		/// <description>Will be zero.</description>
		/// </item>
		/// <item>
		/// <description><c>grfRMSupportedRetaining</c></description>
		/// <description>Will be zero.</description>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>S_OK The method succeeded.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_FAIL A provider-specific error occurred.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_INVALIDARG pInfo was a null pointer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_UNEXPECTED An unknown error occurred. No information is returned.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>
		/// XACT_E_NOTRANSACTION Unable to retrieve information for the transaction because it was already completed. No information is returned.
		/// </para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms714975(v=vs.85) HRESULT GetTransactionInfo( XACTTRANSINFO *pInfo);
		[PreserveSig]
		HRESULT GetTransactionInfo(out XACTTRANSINFO pInfo);
	}

	/// <summary>
	/// This interface contains two methods. The <c>BeginTransaction</c> method creates new transaction objects. The <c>GetOptionsObject</c>
	/// method creates new transaction options objects.
	/// </summary>
	/// <remarks>
	/// Call the DtcGetTransactionManager function with an riid of IID_ITransactionDispenser when initially connecting to DTC. You can also
	/// call <c>QueryInterface</c> on any interface on the DTC proxy core object with an riid of IID_ITransactionDispenser.
	/// </remarks>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms687604(v=vs.85)
	[PInvokeData("transact.h")]
	[ComImport, Guid("3A6AD9E1-23B9-11cf-AD60-00AA00A74CCD"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ITransactionDispenser
	{
		/// <summary>This method creates a transaction options object.</summary>
		/// <param name="ppOptions">
		/// [out] Pointer to the pointer to the <c>ITransactionOptions</c> interface on the transaction options object. Must not be NULL.
		/// </param>
		/// <returns></returns>
		/// <remarks>
		/// <para>
		/// The transaction options object obtained from the <c>GetOptionsObject</c> call can be assigned transaction attributes by calling
		/// the ITransactionOptions::SetOptions method. The transaction options object can then be passed to
		/// ITransactionDispenser::BeginTransaction. The transaction attributes from the transaction options object will be inherited by the
		/// newly created transaction object.
		/// </para>
		/// <para>A process may create as many transaction options objects as it wishes.</para>
		/// <para>
		/// Two or more threads may simultaneously invoke the <c>BeginTransaction</c> method using the same transaction options object.
		/// However, the attributes of the transaction options object must not be changed while the object is in use by the
		/// <c>BeginTransaction</c> method.
		/// </para>
		/// </remarks>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms679525(v=vs.85) HRESULT GetOptionsObject(
		// ITransactionOptions ** ppOptions);
		[PreserveSig]
		HRESULT GetOptionsObject(out ITransactionOptions? ppOptions);

		/// <summary>This method initiates a new transaction and returns a new transaction object which represents the transaction.</summary>
		/// <param name="punkOuter">[in] Must be NULL.</param>
		/// <param name="isoLevel">
		/// [in] The isolation level to be used for this transaction, specified by the ISOLATIONLEVEL enumeration. This value is ignored by
		/// DTC and passed on to the resource managers.
		/// </param>
		/// <param name="isoFlags">[in] Values from ISOFLAG enumeration.</param>
		/// <param name="pOptions">
		/// [in] A pointer to a transaction options object. This value may be NULL. If pOptions is NULL the time-out value for the
		/// transaction is infinite and the transaction will not have a description.
		/// </param>
		/// <param name="ppTransaction">[out] Pointer to the pointer to the <c>ITransaction</c> interface on the new transaction object.</param>
		/// <returns></returns>
		/// <remarks>
		/// A transaction options object which is passed as a parameter to <c>BeginTransaction</c> must not be altered while the
		/// <c>BeginTransaction</c> method invocation is outstanding.
		/// </remarks>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms686676(v=vs.85) HRESULT BeginTransaction( IUnknown *
		// punkOuter, ISOLEVEL isoLevel, ULONG isoFlags, ITransactionOptions * pOptions, ITransaction ** ppTransaction);
		[PreserveSig]
		HRESULT BeginTransaction([In, Optional] object? punkOuter, ISOLEVEL isoLevel, ISOFLAG isoFlags,
			[In, Optional] ITransactionOptions? pOptions, out ITransaction? ppTransaction);
	}

	/// <summary>
	/// <para>This interface contains methods that control the attributes of new transactions such as their time-out periods and descriptions.</para>
	/// <para>
	/// This interface is used to get and set attributes within a transaction options object. The transaction options object can be passed as
	/// a parameter to the ITransactionDispenser::BeginTransaction method. The attributes of the transaction options object are inherited by
	/// the newly initiated transaction. This lets the caller of the <c>BeginTransaction</c> method to control the attributes of a
	/// transaction such as its time-out period and transaction description.
	/// </para>
	/// <para>
	/// This interface is also used to get the transaction option attributes of an existing transaction object. It cannot be used to set the
	/// attributes, because the transaction has already begun.
	/// </para>
	/// </summary>
	/// <remarks>You obtain a pointer to this interface by calling the ITransactionDispenser::GetOptionsObject method.</remarks>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms684388(v=vs.85)
	[PInvokeData("transact.h")]
	[ComImport, Guid("3A6AD9E0-23B9-11cf-AD60-00AA00A74CCD"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ITransactionOptions
	{
		/// <summary>Sets a suite of options associated with a transaction.</summary>
		/// <param name="pOptions">
		/// <para>[in] A pointer to an XACTOPT structure containing the options to be set in this transaction. This cannot be a null pointer.</para>
		/// <para>The elements of this structure are used as described in the following table.</para>
		/// <list type="table">
		/// <listheader>
		/// <description>Element</description>
		/// <description>Description</description>
		/// </listheader>
		/// <item>
		/// <description><c>ulTimeout</c></description>
		/// <description>
		/// The amount of real time in milliseconds before the transaction is to be aborted automatically. Zero indicates an infinite
		/// time-out. If no options have been previously set, <c>ulTimeout</c> is zero.
		/// </description>
		/// </item>
		/// <item>
		/// <description><c>szDescription</c></description>
		/// <description>
		/// A pointer to a textual description associated with this transaction. This string is appropriate for display in various end-user
		/// administration tools that might monitor or log the transaction. If no options have been previously set, <c>szDescription</c> is
		/// an empty string.
		/// </description>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>
		/// <list type="bullet">
		/// <item>
		/// <description>
		/// <para>S_OK The method succeeded.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_FAIL A provider-specific error occurred.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_INVALIDARG pOptions was a null pointer.</para>
		/// </description>
		/// </item>
		/// <item>
		/// <description>
		/// <para>E_UNEXPECTED An unknown error occurred; the method failed.</para>
		/// </description>
		/// </item>
		/// </list>
		/// </returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms714204(v=vs.85) HRESULT SetOptions( XACTOPT *pOptions);
		[PreserveSig]
		HRESULT SetOptions(in XACTOPT pOptions);

		/// <summary>The <c>GetOptions</c> method is used to read transaction attributes from a transaction options object.</summary>
		/// <param name="pOptions">
		/// [in, out] Reference to a XACTOPT structure containing attribute information for a transaction options object. The szDescription
		/// field must be pre-allocated with the correct length.
		/// </param>
		/// <returns></returns>
		/// <remarks>
		/// This method can used to determine the description and the transaction timeout of a transaction that is already in progress, as
		/// shown in the following sample code.
		/// </remarks>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms683541(v=vs.85) HRESULT GetOptions( XACTOPT * pOptions);
		[PreserveSig]
		HRESULT GetOptions(ref XACTOPT pOptions);
	}

	/// <summary>
	/// This interface is used by application programs that require asynchronous notification about transaction outcomes. The application
	/// program implements the methods in this interface and registers the interface with the connection point mechanism. DTC calls the
	/// appropriate method on this interface to inform the application about the outcome of a transaction.
	/// </summary>
	/// <remarks>
	/// <para>
	/// Typically, <c>ITransaction::Commit</c> or <c>Abort</c> calls are performed synchronously. This means that the calling thread is
	/// blocked until DTC makes a commit or abort decision (usually at the end of phase one of the two-phase commit protocol).
	/// </para>
	/// <para>
	/// It is possible to avoid blocking the calling thread by using asynchronous <c>Commit</c> or <c>Abort</c> calls. Asynchronous
	/// <c>Commit</c> or <c>Abort</c> require the following:
	/// </para>
	/// <para>
	/// The <c>ITransactionOutcomeEvents</c> events are raised when the transaction's outcome is known. On the root transaction manager's
	/// system, the transaction outcome event is raised at the end of phase one. On the subordinate transaction managers' systems, the
	/// transaction outcome events are raised at the beginning of phase two.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms686465(v=vs.85)
	[PInvokeData("transact.h")]
	[ComImport, Guid("3A6AD9E2-23B9-11cf-AD60-00AA00A74CCD"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	public interface ITransactionOutcomeEvents
	{
		/// <summary>This event is raised when the transaction committed.</summary>
		/// <param name="fRetaining">[in] Indicates whether retaining <c>Commit</c> was specified. Will be FALSE.</param>
		/// <param name="pNewUOW">[in] Always NULL.</param>
		/// <param name="hr">[in] Always S_OK.</param>
		/// <returns></returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms687677(v=vs.85) HRESULT Committed( BOOL fRetaining, XACTUOW
		// * pNewUOW, HRESULT hr);
		[PreserveSig]
		HRESULT Committed(bool fRetaining, [In, Optional] IntPtr pNewUOW, HRESULT hr);

		/// <summary>
		/// This event is raised when the transaction aborted, either as a result of a call to <c>Abort</c> or an unsuccessful call to <c>Commit</c>*.*
		/// </summary>
		/// <param name="pboidReason">[in] A BOID indicating why the transaction aborted.</param>
		/// <param name="fRetaining">[in] Indicates whether retaining Commit was specified. Will be FALSE.</param>
		/// <param name="pNewUOW">[in] Always NULL.</param>
		/// <param name="hr">[in] Always S_OK.</param>
		/// <returns></returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms688494(v=vs.85) HRESULT Aborted( BOID * pboidReason, BOOL
		// fRetaining, XACTUOW * pNewUOW, HRESULT hr);
		[PreserveSig]
		HRESULT Aborted([In, Optional] IntPtr pboidReason, bool fRetaining, [In, Optional] IntPtr pNewUOW, HRESULT hr);

		/// <summary>
		/// This event is raised when one of the participants in the transaction chooses to heuristically decide the outcome of the transaction.
		/// </summary>
		/// <param name="dwDecision">[in] Values from the enumeration XACTHEURISTIC.</param>
		/// <param name="pboidReason">
		/// [in] A BOID indicating why the transaction was heuristically decided. This value is provided by the party making the heuristic decision.
		/// </param>
		/// <param name="hr">[in] Always S_OK.</param>
		/// <returns></returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms678855(v=vs.85) HRESULT HeuristicDecision( DWORD dwDecision,
		// BOID * pboidReason, HRESULT hr);
		[PreserveSig]
		HRESULT HeuristicDecision(XACTHEURISTIC dwDecision, [In, Optional] IntPtr pboidReason, HRESULT hr);

		/// <summary>
		/// This event is raised when the outcome of the transaction is in-doubt. The outcome of the transaction can be in-doubt if the
		/// connection between the MSDTC proxy and the MSDTC TM was broken after the proxy asked the transaction manager to commit or abort a
		/// transaction but before the transaction manager's response to the commit or abort was received by the proxy. Note: Receiving this
		/// method call is not the same as the state of the transaction being in-doubt.
		/// </summary>
		/// <returns></returns>
		// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms687104(v=vs.85) HRESULT Indoubt(void);
		[PreserveSig]
		HRESULT Indoubt();
	}

	/// <summary>
	/// <para>
	/// The <c>DtcGetTransactionManagerEx</c> function is typically the first DTC call that application programs and resource managers make
	/// when using DTC. This helper function establishes the initial connection to DTC. It returns an interface pointer to one of the
	/// interfaces on the DTC proxy core object. This function helps reduce the boot time and minimize resource consumption and adds the
	/// ability to demand start DTC to compensate for removing boot start.
	/// </para>
	/// </summary>
	/// <param name="pszHost">
	/// <para>[in] Name of the host system which will serve as the transaction commit coordinator.</para>
	/// <para>
	/// <para>Note</para>
	/// <para>If the host system is not found the HRESULT XACT_E_UNABLE_TO_READ_DTC_CONFIG is returned.</para>
	/// </para>
	/// </param>
	/// <param name="pszTmName">
	/// [in] String Name of the transaction manager which will serve as the transaction commit coordinator. Must be NULL.
	/// </param>
	/// <param name="riid">[in] IID of the requested interface.</param>
	/// <param name="grfOptions">
	/// <para>[in] Specifies any configuration or startup options for the transaction manager object. Currently the supported flags are:</para>
	/// <para>OLE_TM_FLAG_NODEMANDSTART (Value = 0x00000001)</para>
	/// <para>Callers can specify this option if they do not want demand start of DTC.</para>
	/// <para>OLE_TM_FLAG_NONE (Value = 0x00000000)</para>
	/// <para>
	/// External callers should use this flag if they want the default behavior (which is to demand start DTC). This approach provides
	/// meaningful text and is preferable to directly using the value 0 for i_grfOptions.
	/// </para>
	/// <para>OLE_TM_FLAG_INTERNAL_TO_TM (Internal only)</para>
	/// <para>
	/// Only components internal to the Transaction manager (such as XATM) should use this flag. This flag should not be used by external callers.
	/// </para>
	/// <para>OLE_TM_FLAG_QUERY_SERVICE_LOCKSTATUS (Internal only)</para>
	/// <para>
	/// Specifying this flag will cause DTC to query the lock status and fail demand start if someone else is holding SCM lock. This flag
	/// should not be used by external callers.
	/// </para>
	/// </param>
	/// <param name="pvConfigParams">
	/// [in] Pointer to a self-describing structure. You can use the structure to pass various configuration parameters into the TM object.
	/// Must be NULL.
	/// </param>
	/// <param name="ppvObject">[out] Pointer to the pointer to the requested interface.</param>
	/// <remarks>
	/// <para>
	/// <para>Note</para>
	/// <para>This API should not be called without the OLE_TM_FLAG_NO_DEMANDSTART during service startup.</para>
	/// </para>
	/// <para>
	/// If the value refers to a remote computer, then you must configure the computers participating in the transaction as follows,
	/// otherwise the call will fail:
	/// </para>
	/// <list type="number">
	/// <item>
	/// <description>
	/// <para>On the computer where the application that makes this call resides, make sure the Remote Registry service is running.</para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>
	/// On the remote computer referred to by the parameter, make sure the MSDTC service is configured to accept Network Transactions and
	/// allows remote clients.
	/// </para>
	/// </description>
	/// </item>
	/// </list>
	/// </remarks>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms678898(v=vs.85) EXTERN_C EXPORTAPI __cdecl
	// DtcGetTransactionManagerEx( tchar * pszHost, tchar * pszTmName, REFIIDriid, DWORDgrfOptions, void * pvConfigParams, void ** ppvObject);
	[PInvokeData("xolehlp.h")]
	[DllImport("xolehlp.dll", SetLastError = false, CharSet = CharSet.Auto)]
	public static extern HRESULT DtcGetTransactionManagerEx(string? pszHost, string? pszTmName, in Guid riid,
		OLE_TM grfOptions, [In, Optional] IntPtr pvConfigParams, [MarshalAs(UnmanagedType.IUnknown, IidParameterIndex = 2)] out object? ppvObject);

	/// <summary>
	/// The <c>DtcGetTransactionManagerEx</c> function is typically the first DTC call that application programs and resource managers make
	/// when using DTC. This helper function establishes the initial connection to DTC. It returns an interface pointer to one of the
	/// interfaces on the DTC proxy core object. This function helps reduce the boot time and minimize resource consumption and adds the
	/// ability to demand start DTC to compensate for removing boot start.
	/// </summary>
	/// <typeparam name="T">The type of the interface to return.</typeparam>
	/// <param name="pszHost">
	/// <para>[in] Name of the host system which will serve as the transaction commit coordinator.</para>
	/// <para>
	/// <para>Note</para>
	/// <para>If the host system is not found the HRESULT XACT_E_UNABLE_TO_READ_DTC_CONFIG is returned.</para>
	/// </para>
	/// </param>
	/// <param name="grfOptions">
	/// <para>[in] Specifies any configuration or startup options for the transaction manager object. Currently the supported flags are:</para>
	/// <para>OLE_TM_FLAG_NODEMANDSTART (Value = 0x00000001)</para>
	/// <para>Callers can specify this option if they do not want demand start of DTC.</para>
	/// <para>OLE_TM_FLAG_NONE (Value = 0x00000000)</para>
	/// <para>
	/// External callers should use this flag if they want the default behavior (which is to demand start DTC). This approach provides
	/// meaningful text and is preferable to directly using the value 0 for i_grfOptions.
	/// </para>
	/// <para>OLE_TM_FLAG_INTERNAL_TO_TM (Internal only)</para>
	/// <para>
	/// Only components internal to the Transaction manager (such as XATM) should use this flag. This flag should not be used by external callers.
	/// </para>
	/// <para>OLE_TM_FLAG_QUERY_SERVICE_LOCKSTATUS (Internal only)</para>
	/// <para>
	/// Specifying this flag will cause DTC to query the lock status and fail demand start if someone else is holding SCM lock. This flag
	/// should not be used by external callers.
	/// </para>
	/// </param>
	/// <returns>[out] Pointer to the pointer to the requested interface.</returns>
	/// <remarks>
	/// <para>
	/// <para>Note</para>
	/// <para>This API should not be called without the OLE_TM_FLAG_NO_DEMANDSTART during service startup.</para>
	/// </para>
	/// <para>
	/// If the value refers to a remote computer, then you must configure the computers participating in the transaction as follows,
	/// otherwise the call will fail:
	/// </para>
	/// <list type="number">
	/// <item>
	/// <description>
	/// <para>On the computer where the application that makes this call resides, make sure the Remote Registry service is running.</para>
	/// </description>
	/// </item>
	/// <item>
	/// <description>
	/// <para>
	/// On the remote computer referred to by the parameter, make sure the MSDTC service is configured to accept Network Transactions and
	/// allows remote clients.
	/// </para>
	/// </description>
	/// </item>
	/// </list>
	/// </remarks>
	// https://learn.microsoft.com/en-us/previous-versions/windows/desktop/ms678898(v=vs.85) EXTERN_C EXPORTAPI __cdecl
	// DtcGetTransactionManagerEx( tchar * pszHost, tchar * pszTmName, REFIIDriid, DWORDgrfOptions, void * pvConfigParams, void ** ppvObject);
	[PInvokeData("xolehlp.h")]
	public static T DtcGetTransactionManagerEx<T>(string? pszHost = null, OLE_TM grfOptions = 0) where T : class
	{
		DtcGetTransactionManagerEx(pszHost, null, typeof(T).GUID, grfOptions, IntPtr.Zero, out var ppvObject).ThrowIfFailed();
		return (T)ppvObject!;
	}

	/// <summary/>
	[StructLayout(LayoutKind.Sequential, Size = 16)]
	[UnsafeValueType]
	[NativeCppClass]
	[PInvokeData("transact.h")]
	public struct BOID
	{
	}

	/// <summary>The XACTOPT structure contains information for a transaction options object.</summary>
	[PInvokeData("transact.h")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct XACTOPT
	{
		/// <summary>
		/// This parameter limits the duration of the transaction and therefore bounds the amount of time that locks are held on database
		/// records and system resources. If the time-out period expires before the transaction commits, the DTC automatically aborts the
		/// transaction. The time-out is specified in milliseconds. A time-out value of zero indicates no time-out.
		/// </summary>
		public uint ulTimeout;

		/// <summary>
		/// A textual description for a transaction. The description is displayed by the DTC administration tool in the DTC Transactions
		/// window. The description is meaningful only to the DTC administrator and is not processed or interpreted by the DTC itself.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
		public string szDescription;
	}

	/// <summary>The XACTTRANSINFO structure stores information about the transaction.</summary>
	[PInvokeData("transact.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct XACTTRANSINFO
	{
		/// <summary>The unit of work associated with this transaction.</summary>
		public BOID uow;

		/// <summary>
		/// The isolation level associated with this transaction object, specified by the ISOLATIONLEVEL enumeration.
		/// ISOLATIONLEVEL_UNSPECIFIED indicates that no isolation level was specified.
		/// </summary>
		public ISOLEVEL isoLevel;

		/// <summary>Values from ISOFLAG enumeration.</summary>
		public ISOFLAG isoFlags;

		/// <summary>This bit mask indicates which grfTC flags that this transaction implementation supports.</summary>
		public uint grfTCSupported;

		/// <summary>Must be zero.</summary>
		public uint grfRMSupported;

		/// <summary>Must be zero.</summary>
		public uint grfTCSupportedRetaining;

		/// <summary>Must be zero.</summary>
		public uint grfRMSupportedRetaining;
	}
}