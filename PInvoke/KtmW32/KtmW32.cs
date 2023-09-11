using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke;

/// <summary>Kernel Transaction Manager (KTM) functions and structures.</summary>
public static partial class KtmW32
{
	/// <summary>An optional enlistment instruction.</summary>
	[PInvokeData("ktmw32.h", MSDNShortId = "7bc06468-947f-48ec-8e58-20df58ed93bd")]
	[Flags]
	public enum CreateEnlistmentOptions
	{
		/// <summary>Enlist as a superior transaction manager.</summary>
		ENLISTMENT_SUPERIOR = 1
	}

	/// <summary>Optional attributes for the new RM.</summary>
	[PInvokeData("ktmw32.h", MSDNShortId = "ad88e478-1dff-4f35-a0e3-6bda8bb45711")]
	[Flags]
	public enum CreateRMOptions
	{
		/// <summary>Indicates that the RM is volatile, and does not perform recovery.</summary>
		RESOURCE_MANAGER_VOLATILE = 1,

		/// <summary/>
		RESOURCE_MANAGER_COMMUNICATION = 2
	}

	/// <summary>Optional attributes for the new TM.</summary>
	[PInvokeData("ktmw32.h", MSDNShortId = "f5b7d0c1-9cd0-48fc-8125-d4da040951c4")]
	[Flags]
	public enum CreateTrxnMgrOptions
	{
		/// <summary/>
		TRANSACTION_MANAGER_COMMIT_DEFAULT = 0x00000000,

		/// <summary>Indicates that the TM is volatile, and does not perform recovery.</summary>
		TRANSACTION_MANAGER_VOLATILE = 0x00000001,

		/// <summary/>
		TRANSACTION_MANAGER_COMMIT_SYSTEM_VOLUME = 0x00000002,

		/// <summary/>
		TRANSACTION_MANAGER_COMMIT_SYSTEM_HIVES = 0x00000004,

		/// <summary/>
		TRANSACTION_MANAGER_COMMIT_LOWEST = 0x00000008,

		/// <summary/>
		TRANSACTION_MANAGER_CORRUPT_FOR_RECOVERY = 0x00000010,

		/// <summary/>
		TRANSACTION_MANAGER_CORRUPT_FOR_PROGRESS = 0x00000020,
	}

	/// <summary>Optional transaction instructions.</summary>
	[PInvokeData("ktmw32.h", MSDNShortId = "578bda35-bd35-4f6d-8366-a4bfb4dbfe42")]
	[Flags]
	public enum CreateTrxnOptions
	{
		/// <summary>The transaction cannot be distributed.</summary>
		TRANSACTION_DO_NOT_PROMOTE = 1
	}

	/// <summary>KTM defines the following enlistment access masks to be used when opening enlistments.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/ktm/enlistment-access-masks
	[PInvokeData("winnt.h", MSDNShortId = "93773eb7-141a-49f3-9306-ffbda2f4ab9f")]
	[Flags]
	public enum EnlistmentAccess : uint
	{
		/// <summary>The caller can query KTM for information about the enlistment.</summary>
		ENLISTMENT_QUERY_INFORMATION = 0x00001,

		/// <summary>The caller can set information about the enlistment.</summary>
		ENLISTMENT_SET_INFORMATION = 0x00002,

		/// <summary>The caller can recover an enlistment.</summary>
		ENLISTMENT_RECOVER = 0x00004,

		/// <summary>
		/// <para>
		/// The caller can complete actions that a resource manager does on behalf of the transaction. The following is a list of actions:
		/// </para>
		/// <list type="bullet">
		/// <item>CommitComplete</item>
		/// <item>PrepareComplete</item>
		/// <item>PrePrepareComplete</item>
		/// <item>RollbackComplete</item>
		/// <item>ReadOnlyEnlistment</item>
		/// <item>RollbackEnlistment</item>
		/// <item>SinglePhaseReject</item>
		/// </list>
		/// </summary>
		ENLISTMENT_SUBORDINATE_RIGHTS = 0x00008,

		/// <summary>The caller can enlist in the transaction as a superior transaction manager.</summary>
		ENLISTMENT_SUPERIOR_RIGHTS = 0x00010,

		/// <summary>The caller has the following privileges: STANDARD_RIGHTS_READ and ENLISTMENT_QUERY_INFORMATION.</summary>
		ENLISTMENT_GENERIC_READ = 0x20001,

		/// <summary>The caller has the following privileges: STANDARD_RIGHTS_WRITE, ENLISTMENT_SET_INFORMATION, and ENLISTMENT_RECOVER.</summary>
		ENLISTMENT_GENERIC_WRITE = 0x2001E,

		/// <summary>The caller has the following privileges: STANDARD_RIGHTS_EXECUTE, ENLISTMENT_RECOVER, and ENLISTMENT_SUBORDINATE_RIGHTS.</summary>
		ENLISTMENT_GENERIC_EXECUTE = 0x2001C,

		/// <summary>This value sets all valid bits for an enlistment access value.</summary>
		ENLISTMENT_ALL_ACCESS = 0xF001F,
	}

	/// <summary>Lists the different types of notifications that can be received by an enlistment.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/ktm/notification-mask
	[PInvokeData("winnt.h", MSDNShortId = "65db8ba5-193c-439b-8e8c-6cb4a9bd4efd")]
	[Flags]
	public enum NOTIFICATION_MASK : uint
	{
		/// <summary>A mask that indicates all valid bits for a transaction notification.</summary>
		TRANSACTION_NOTIFY_MASK = 0x3FFFFFFF,

		/// <summary>
		/// This notification is called after a client calls CommitTransaction and either no resource manager (RM) supports single-phase
		/// commit or a superior transaction manager (TM) calls PrePrepareEnlistment. This notification is received by the RMs indicating
		/// that they should complete any work that could cause other RMs to need to enlist in a transaction, such as flushing its cache.
		/// After completing these operations the RM must call PrePrepareComplete. To receive this notification the RM must also support
		/// TRANSACTION_NOTIFY_PREPARE and TRANSACTION_NOTIFY_COMMIT.
		/// </summary>
		TRANSACTION_NOTIFY_PREPREPARE = 0x00000001,

		/// <summary>
		/// This notification is called after the TRANSACTION_NOTIFY_PREPREPARE processing is complete. It signals the RM to complete all
		/// the work that is associated with this enlistment so that it can guarantee that a commit operation could succeed and an abort
		/// operation could also succeed. Typically, the bulk of the work for a transaction is done during the prepare phase. For durable
		/// RMs, they must log their state prior to calling the PrepareComplete function. This is the last chance for the RM to request
		/// that the transaction be rolled back.
		/// </summary>
		TRANSACTION_NOTIFY_PREPARE = 0x00000002,

		/// <summary>
		/// This notification signals the RM to complete all the work that is associated with this enlistment. Typically, the RM releases
		/// any locks, releases any information necessary to roll back the transaction. The RM must respond by calling the CommitComplete
		/// function when it has finished these operations.
		/// </summary>
		TRANSACTION_NOTIFY_COMMIT = 0x00000004,

		/// <summary>This notification signals the RM to undo all the work it has done that is associated with the transaction.</summary>
		TRANSACTION_NOTIFY_ROLLBACK = 0x00000008,

		/// <summary>This notification signals to the superior TM that a pre-prepare operation was completed successfully.</summary>
		TRANSACTION_NOTIFY_PREPREPARE_COMPLETE = 0x00000010,

		/// <summary>This notification signals to the superior TM that a prepare operation was completed successfully.</summary>
		TRANSACTION_NOTIFY_PREPARE_COMPLETE = 0x00000020,

		/// <summary>This notification signals to the superior TM that a commit operation was completed successfully.</summary>
		TRANSACTION_NOTIFY_COMMIT_COMPLETE = 0x00000040,

		/// <summary>This notification signals to the superior TM that a rollback operation was completed successfully.</summary>
		TRANSACTION_NOTIFY_ROLLBACK_COMPLETE = 0x00000080,

		/// <summary>
		/// This notification signals to RMs that they should recover their state because a transaction outcome must be redelivered. For
		/// example, when an RM is recovered, and when there are transactions left in-doubt. This notification is delivered once the
		/// in-doubt state is resolved.
		/// </summary>
		TRANSACTION_NOTIFY_RECOVER = 0x00000100,

		/// <summary>
		/// This notification signals the RM to complete and commit the transaction without using a two-phase commit protocol. If the RM
		/// wants to use a two-phase operation, it must respond by calling the SinglePhaseReject function.
		/// </summary>
		TRANSACTION_NOTIFY_SINGLE_PHASE_COMMIT = 0x00000200,

		/// <summary>KTM is signaling to the superior TM to perform a commit operation.</summary>
		TRANSACTION_NOTIFY_DELEGATE_COMMIT = 0x00000400,

		/// <summary>KTM is signaling to the superior TM to query the status of an in-doubt transaction.</summary>
		TRANSACTION_NOTIFY_RECOVER_QUERY = 0x00000800,

		/// <summary>
		/// This notification signals to the superior TM that pre-prepare notifications must be delivered on the specified enlistment.
		/// </summary>
		TRANSACTION_NOTIFY_ENLIST_PREPREPARE = 0x00001000,

		/// <summary>This notification indicates that the recovery operation is complete for this RM.</summary>
		TRANSACTION_NOTIFY_LAST_RECOVER = 0x00002000,

		/// <summary>
		/// The specified transaction is in an in-doubt state. The RM receives this notification during recovery operations when a
		/// transaction has been prepared, but there is no superior transaction manager (TM) available. For example, when a transaction
		/// involves a remote TM and that node is unavailable, its node is unavailable, or the local Distributed Transaction Coordinator
		/// service is unavailable, the transaction state is in-doubt.
		/// </summary>
		TRANSACTION_NOTIFY_INDOUBT = 0x00004000,

		/// <summary>The TM is online and accepting requests.</summary>
		TRANSACTION_NOTIFY_TM_ONLINE = 0x02000000,

		/// <summary>
		/// Signals to RMs that there is outcome information available, and that a request for that information should be made.
		/// </summary>
		TRANSACTION_NOTIFY_REQUEST_OUTCOME = 0x20000000,

		/// <summary>Reserved.</summary>
		TRANSACTION_NOTIFY_COMMIT_FINALIZE = 0x40000000,
	}

	/// <summary>KTM defines the following enlistment access masks to be used when opening a resource manager.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/ktm/resource-manager-access-masks
	[PInvokeData("winnt.h", MSDNShortId = "6b901b73-516d-4f27-b258-3b93a8f9675f")]
	[Flags]
	public enum ResourceManagerAccess : uint
	{
		/// <summary>The caller can query for the resource manager (RM) information.</summary>
		RESOURCEMANAGER_QUERY_INFORMATION = 0x0001,

		/// <summary>The caller can set the RM information.</summary>
		RESOURCEMANAGER_SET_INFORMATION = 0x0002,

		/// <summary>The caller can recover the specified RM.</summary>
		RESOURCEMANAGER_RECOVER = 0x0004,

		/// <summary>The caller can enlist an RM in a transaction.</summary>
		RESOURCEMANAGER_ENLIST = 0x0008,

		/// <summary>The caller can receive a notification for an RM.</summary>
		RESOURCEMANAGER_GET_NOTIFICATION = 0x0010,

		/// <summary/>
		RESOURCEMANAGER_REGISTER_PROTOCOL = 0x0020,

		/// <summary/>
		RESOURCEMANAGER_COMPLETE_PROPAGATION = 0x0040,

		/// <summary>The caller has the following privileges: STANDARD_RIGHTS_READ, RESOURCEMANAGER_QUERY_INFORMATION, and RESOURCEMANAGER_RECOVER.</summary>
		RESOURCEMANAGER_GENERIC_READ = ACCESS_MASK.STANDARD_RIGHTS_READ | RESOURCEMANAGER_QUERY_INFORMATION | ACCESS_MASK.SYNCHRONIZE,

		/// <summary>
		/// The caller has the following privileges: STANDARD_RIGHTS_WRITE, RESOURCEMANAGER_SET_INFORMATION, RESOURCEMANAGER_ENLIST, and RESOURCEMANAGER_GET_NOTIFICATION.
		/// </summary>
		RESOURCEMANAGER_GENERIC_WRITE = ACCESS_MASK.STANDARD_RIGHTS_WRITE | RESOURCEMANAGER_SET_INFORMATION | RESOURCEMANAGER_RECOVER | RESOURCEMANAGER_ENLIST | RESOURCEMANAGER_GET_NOTIFICATION | RESOURCEMANAGER_REGISTER_PROTOCOL | RESOURCEMANAGER_COMPLETE_PROPAGATION | ACCESS_MASK.SYNCHRONIZE,

		/// <summary>The caller has the following privileges: STANDARD_RIGHTS_EXECUTE, RESOURCEMANAGER_ENLIST, and RESOURCEMANAGER_GET_NOTIFICATION.</summary>
		RESOURCEMANAGER_GENERIC_EXECUTE = ACCESS_MASK.STANDARD_RIGHTS_EXECUTE | RESOURCEMANAGER_RECOVER | RESOURCEMANAGER_ENLIST | RESOURCEMANAGER_GET_NOTIFICATION | RESOURCEMANAGER_COMPLETE_PROPAGATION | ACCESS_MASK.SYNCHRONIZE,

		/// <summary>The caller has the following privilege: STANDARD_RIGHTS_REQUIRED.</summary>
		RESOURCEMANAGER_ALL_ACCESS = ACCESS_MASK.STANDARD_RIGHTS_REQUIRED | RESOURCEMANAGER_GENERIC_READ | RESOURCEMANAGER_GENERIC_WRITE | RESOURCEMANAGER_GENERIC_EXECUTE,
	}

	/// <summary>Defines the outcomes (results) that KTM can assign to a transaction.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/winnt/ne-winnt-transaction_outcome typedef enum _TRANSACTION_OUTCOME {
	// TransactionOutcomeUndetermined, TransactionOutcomeCommitted, TransactionOutcomeAborted } TRANSACTION_OUTCOME;
	[PInvokeData("winnt.h", MSDNShortId = "d4315a62-b65f-4744-8084-2317ad39c32c")]
	public enum TRANSACTION_OUTCOME
	{
		/// <summary>The transaction has not yet been committed or rolled back.</summary>
		TransactionOutcomeUndetermined = 1,

		/// <summary>The transaction has been committed.</summary>
		TransactionOutcomeCommitted,

		/// <summary>The transaction has been rolled back.</summary>
		TransactionOutcomeAborted,
	}

	/// <summary>KTM defines the following transaction access masks to be used when opening a transaction.</summary>
	/// <remarks>
	/// It is recommended that resource managers, when enlisting in a transaction, specify <c>TRANSACTION_RESOURCE_MANAGER_RIGHTS</c>
	/// when opening a transaction.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/ktm/transaction-access-masks
	[PInvokeData("winnt.h", MSDNShortId = "93ef3098-b3cc-4b24-ae82-1c10d937f14f")]
	[Flags]
	public enum TransactionAccess : uint
	{
		/// <summary>The caller can query transaction information.</summary>
		TRANSACTION_QUERY_INFORMATION = 0x000001,

		/// <summary>The caller can set transaction information.</summary>
		TRANSACTION_SET_INFORMATION = 0x000002,

		/// <summary>The caller can enlist in this transaction.</summary>
		TRANSACTION_ENLIST = 0x000004,

		/// <summary>The caller can commit this transaction.</summary>
		TRANSACTION_COMMIT = 0x000008,

		/// <summary>The caller can roll back this transaction.</summary>
		TRANSACTION_ROLLBACK = 0x000010,

		/// <summary>
		/// The caller can propagate this transaction to a superior resource manager, such as the Distributed Transaction Coordinator (DTC).
		/// </summary>
		TRANSACTION_PROPAGATE = 0x000020,

		/// <summary>The caller has the following privileges: STANDARD_RIGHTS_READ, TRANSACTION_QUERY_INFORMATION, and SYNCHRONIZE.</summary>
		TRANSACTION_GENERIC_READ = 0x120001,

		/// <summary>
		/// The caller has the following privileges: STANDARD_RIGHTS_WRITE, TRANSACTION_SET_INFORMATION, TRANSACTION_COMMIT,
		/// TRANSACTION_ENLIST, TRANSACTION_ROLLBACK, TRANSACTION_PROPAGATE, and SYNCHRONIZE.
		/// </summary>
		TRANSACTION_GENERIC_WRITE = 0x12003E,

		/// <summary>
		/// The caller has the following privileges: STANDARD_RIGHTS_EXECUTE, TRANSACTION_COMMIT, TRANSACTION_ROLLBACK, and SYNCHRONIZE.
		/// </summary>
		TRANSACTION_GENERIC_EXECUTE = 0x120018,

		/// <summary>
		/// The caller has the following privilege: STANDARD_RIGHTS_REQUIRED, TRANSACTION_GENERIC_READ, TRANSACTION_GENERIC_WRITE, and TRANSACTION_GENERIC_EXECUTE.
		/// </summary>
		TRANSACTION_ALL_ACCESS = 0x12003F,

		/// <summary>
		/// The caller has the following privileges: TRANSACTION_GENERIC_READ, STANDARD_RIGHTS_WRITE, TRANSACTION_SET_INFORMATION,
		/// TRANSACTION_ROLLBACK, TRANSACTION_ENLIST, TRANSACTION_PROPAGATE, and SYNCHRONIZE.
		/// </summary>
		TRANSACTION_RESOURCE_MANAGER_RIGHTS = 0x120037,
	}

	/// <summary>KTM defines the following enlistment access masks to be used when opening a transaction manager (TM).</summary>
	// https://docs.microsoft.com/en-us/windows/win32/ktm/transaction-manager-access-masks
	[PInvokeData("winnt.h", MSDNShortId = "8f9b9d3d-e7ea-4df2-82b1-2d4c3e0766c0")]
	[Flags]
	public enum TransactionMgrAccess
	{
		/// <summary>The caller can query information about this TM.</summary>
		TRANSACTIONMANAGER_QUERY_INFORMATION = 0x00001,

		/// <summary>The caller can set information about this TM.</summary>
		TRANSACTIONMANAGER_SET_INFORMATION = 0x00002,

		/// <summary>The caller can recover this TM.</summary>
		TRANSACTIONMANAGER_RECOVER = 0x00004,

		/// <summary>The caller can rename a TM instance.</summary>
		TRANSACTIONMANAGER_RENAME = 0x00008,

		/// <summary>The caller can create a resource manager that is associated with this TM.</summary>
		TRANSACTIONMANAGER_CREATE_RM = 0x00010,

		/// <summary>This value is reserved.</summary>
		TRANSACTIONMANAGER_BIND_TRANSACTION = 0x00020,

		/// <summary>The caller has the following privileges: STANDARD_RIGHTS_READ and TRANSACTIONMANAGER_QUERY_INFORMATION.</summary>
		TRANSACTIONMANAGER_GENERIC_READ = 0x20001,

		/// <summary>
		/// The caller has the following privileges: STANDARD_RIGHTS_WRITE, TRANSACTIONMANAGER_SET_INFORMATION,
		/// TRANSACTIONMANAGER_RECOVER, TRANSACTIONMANAGER_RENAME, and TRANSACTIONMANAGER_CREATE_RM.
		/// </summary>
		TRANSACTIONMANAGER_GENERIC_WRITE = 0x2001E,

		/// <summary>The caller has the following privilege: STANDARD_RIGHTS_EXECUTE.</summary>
		TRANSACTIONMANAGER_GENERIC_EXECUTE = 0x20000,

		/// <summary>This value sets all valid bits for a TM access value.</summary>
		TRANSACTIONMANAGER_ALL_ACCESS = 0xF003F,
	}

	/// <summary>
	/// Indicates that a resource manager (RM) has finished committing a transaction that was requested by the transaction manager (TM).
	/// </summary>
	/// <param name="EnlistmentHandle">A handle to the enlistment for which the commit operation is completed.</param>
	/// <param name="TmVirtualClock">
	/// <para>
	/// The latest virtual clock value received for this transaction. If you specify <c>NULL</c>, the virtual clock value is not changed.
	/// See LARGE_INTEGER.
	/// </para>
	/// <para>To change the virtual clock value, this value must be greater than the current value returned in the COMMIT notification.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero (0). To get extended error information, call the GetLastError function.</para>
	/// <para>The following list identifies the possible error codes:</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/ktmw32/nf-ktmw32-commitcomplete BOOL CommitComplete( IN HANDLE
	// EnlistmentHandle, IN PLARGE_INTEGER TmVirtualClock );
	[DllImport(Lib.Ktmw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("ktmw32.h", MSDNShortId = "de3e3a26-3e56-4732-8e7c-945b45593aed")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CommitComplete([In] HENLISTMENT EnlistmentHandle, in long TmVirtualClock);

	/// <summary>
	/// Indicates that a resource manager (RM) has finished committing a transaction that was requested by the transaction manager (TM).
	/// </summary>
	/// <param name="EnlistmentHandle">A handle to the enlistment for which the commit operation is completed.</param>
	/// <param name="TmVirtualClock">
	/// <para>
	/// The latest virtual clock value received for this transaction. If you specify <c>NULL</c>, the virtual clock value is not changed.
	/// See LARGE_INTEGER.
	/// </para>
	/// <para>To change the virtual clock value, this value must be greater than the current value returned in the COMMIT notification.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero (0). To get extended error information, call the GetLastError function.</para>
	/// <para>The following list identifies the possible error codes:</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/ktmw32/nf-ktmw32-commitcomplete BOOL CommitComplete( IN HANDLE
	// EnlistmentHandle, IN PLARGE_INTEGER TmVirtualClock );
	[DllImport(Lib.Ktmw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("ktmw32.h", MSDNShortId = "de3e3a26-3e56-4732-8e7c-945b45593aed")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CommitComplete([In] HENLISTMENT EnlistmentHandle, [Optional] IntPtr TmVirtualClock);

	/// <summary>
	/// Commits the transaction associated with this enlistment handle. This function is used by communication resource managers
	/// (sometimes called superior transaction managers).
	/// </summary>
	/// <param name="EnlistmentHandle">A handle to the enlistment to commit.</param>
	/// <param name="TmVirtualClock">
	/// <para>
	/// A pointer to the latest virtual clock value received for this enlistment. If you specify <c>NULL</c>, the virtual clock value is
	/// not changed.
	/// </para>
	/// <para>To change the virtual clock value, this value must be greater than the current value returned by a subordinate TM.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is 0 (zero). To get extended error information, call the GetLastError function.</para>
	/// <para>The following list identifies the possible error codes:</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/ktmw32/nf-ktmw32-commitenlistment BOOL CommitEnlistment( IN HANDLE
	// EnlistmentHandle, IN PLARGE_INTEGER TmVirtualClock );
	[DllImport(Lib.Ktmw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("ktmw32.h", MSDNShortId = "d1e1043d-2db3-4f05-affc-2d32744baf10")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CommitEnlistment([In] HENLISTMENT EnlistmentHandle, in long TmVirtualClock);

	/// <summary>
	/// Commits the transaction associated with this enlistment handle. This function is used by communication resource managers
	/// (sometimes called superior transaction managers).
	/// </summary>
	/// <param name="EnlistmentHandle">A handle to the enlistment to commit.</param>
	/// <param name="TmVirtualClock">
	/// <para>
	/// A pointer to the latest virtual clock value received for this enlistment. If you specify <c>NULL</c>, the virtual clock value is
	/// not changed.
	/// </para>
	/// <para>To change the virtual clock value, this value must be greater than the current value returned by a subordinate TM.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is 0 (zero). To get extended error information, call the GetLastError function.</para>
	/// <para>The following list identifies the possible error codes:</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/ktmw32/nf-ktmw32-commitenlistment BOOL CommitEnlistment( IN HANDLE
	// EnlistmentHandle, IN PLARGE_INTEGER TmVirtualClock );
	[DllImport(Lib.Ktmw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("ktmw32.h", MSDNShortId = "d1e1043d-2db3-4f05-affc-2d32744baf10")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CommitEnlistment([In] HENLISTMENT EnlistmentHandle, [Optional] IntPtr TmVirtualClock);

	/// <summary>Requests that the specified transaction be committed.</summary>
	/// <param name="TransactionHandle">
	/// <para>A handle to the transaction to be committed.</para>
	/// <para>
	/// This handle must have been opened with the TRANSACTION_COMMIT access right. For more information, see KTM Security and Access Rights.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is 0 (zero). To get extended error information, call the GetLastError function.</para>
	/// <para>The following list identifies the possible error codes:</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// You can commit any transaction handle that has been opened or created using the TRANSACTION_COMMIT permission; any application
	/// can commit a transaction, not just the creator.
	/// </para>
	/// <para>This function can only be called if the transaction is still active, not prepared, pre-prepared, or rolled back.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ktmw32/nf-ktmw32-committransaction BOOL CommitTransaction( IN HANDLE
	// TransactionHandle );
	[DllImport(Lib.Ktmw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("ktmw32.h", MSDNShortId = "17db5e1f-685b-46f0-bac6-dff4c18bb515")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CommitTransaction([In] HTRXN TransactionHandle);

	/// <summary>Requests that the specified transaction be committed.</summary>
	/// <param name="TransactionHandle">
	/// <para>A handle to the transaction to be committed.</para>
	/// <para>
	/// This handle must have been opened with the TRANSACTION_COMMIT access right. For more information, see KTM Security and Access Rights.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is nonzero. Success means that the function completed synchronously, and the calling
	/// application does not need to wait for pending results.
	/// </para>
	/// <para>If the function fails, the return value is 0 (zero). To get extended error information, call the GetLastError function.</para>
	/// <para>The following list identifies the possible error codes:</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/ktmw32/nf-ktmw32-committransactionasync BOOL CommitTransactionAsync( IN HANDLE
	// TransactionHandle );
	[DllImport(Lib.Ktmw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("ktmw32.h", MSDNShortId = "cc0f4314-e216-490b-a49a-14bb850e0762")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CommitTransactionAsync([In] HTRXN TransactionHandle);

	/// <summary>Creates an enlistment, sets its initial state, and opens a handle to the enlistment with the specified access.</summary>
	/// <param name="lpEnlistmentAttributes">
	/// A pointer to a SECURITY_ATTRIBUTES structure that contains the security attributes for the enlistment manager. Specify
	/// <c>NULL</c> to obtain the default attributes.
	/// </param>
	/// <param name="ResourceManagerHandle">A handle to the resource manager (RM) to enlist.</param>
	/// <param name="TransactionHandle">A handle to the transaction in which the RM is enlisting.</param>
	/// <param name="NotificationMask">
	/// The notifications this RM is requesting for the TransactionHandle parameter. For a list of valid values, see NOTIFICATION_MASK.
	/// </param>
	/// <param name="CreateOptions">
	/// <para>Any optional enlistment instructions.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ENLISTMENT_SUPERIOR 1</term>
	/// <term>Enlist as a superior transaction manager.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="EnlistmentKey">
	/// A pointer to a user-defined structure used by the RM that is returned when a notification is sent in the TRANSACTION_NOTIFICATION
	/// structure. This is typically used to associate a private structure with this specific transaction.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a handle to the enlistment.</para>
	/// <para>
	/// If the function fails, the return value is <c>INVALID_HANDLE_VALUE</c>. To get extended error information, call the GetLastError function.
	/// </para>
	/// <para>The following list identifies the possible error codes:</para>
	/// </returns>
	/// <remarks>
	/// <para><c>Windows Vista:</c> Any attempt to enlist during the pre-prepare phase or later will fail.</para>
	/// <para>
	/// If you do not specify within your notification mask that you accept a single-phase commit request, KTM always performs a
	/// two-phase commit operation.
	/// </para>
	/// <para>Keep the following notification rules in mind when enlisting in transactions:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>The RM must always request rollback notification.</term>
	/// </item>
	/// <item>
	/// <term>If the RM requests prepare notification, it must also request commit notification.</term>
	/// </item>
	/// <item>
	/// <term>If the RM requests a single-phase commit operation, it must also specify prepare and commit notifications.</term>
	/// </item>
	/// <item>
	/// <term>
	/// The only time an RM is not required to request commit notifications is when it is requesting at least a pair of pre-prepare and
	/// rollback notifications.
	/// </term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ktmw32/nf-ktmw32-createenlistment HANDLE CreateEnlistment( IN
	// LPSECURITY_ATTRIBUTES lpEnlistmentAttributes, IN HANDLE ResourceManagerHandle, IN HANDLE TransactionHandle, IN NOTIFICATION_MASK
	// NotificationMask, IN DWORD CreateOptions, IN PVOID EnlistmentKey );
	[DllImport(Lib.Ktmw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("ktmw32.h", MSDNShortId = "7bc06468-947f-48ec-8e58-20df58ed93bd")]
	public static extern SafeHENLISTMENT CreateEnlistment([In, Optional] SECURITY_ATTRIBUTES lpEnlistmentAttributes, [In] HRESMGR ResourceManagerHandle, [In] HTRXN TransactionHandle, [In] NOTIFICATION_MASK NotificationMask, [In, Optional] CreateEnlistmentOptions CreateOptions, [In, Optional] IntPtr EnlistmentKey);

	/// <summary>Creates a new resource manager (RM) object, and associates the RM with a transaction manager (TM).</summary>
	/// <param name="lpResourceManagerAttributes">
	/// A pointer to a SECURITY_ATTRIBUTES structure that contains the security attributes for the resource manager. Specify <c>NULL</c>
	/// to obtain the default attributes.
	/// </param>
	/// <param name="ResourceManagerId">A pointer the resource manager GUID. This parameter is required and must not be <c>NULL</c>.</param>
	/// <param name="CreateOptions">
	/// <para>Any optional attributes for the new RM.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>RESOURCE_MANAGER_VOLATILE</term>
	/// <term>Indicates that the RM is volatile, and does not perform recovery.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="TmHandle">A handle to the TM that will manage the transactions for this RM.</param>
	/// <param name="Description">A description for this RM.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a handle to the RM.</para>
	/// <para>
	/// If the function fails, the return value is INVALID_HANDLE_VALUE. To get extended error information, call the GetLastError function.
	/// </para>
	/// <para>The following list identifies the possible error codes:</para>
	/// </returns>
	/// <remarks>
	/// <para>Immediately after calling this function, you must call RecoverResourceManager.</para>
	/// <para>An RM is an endpoint for TM notifications regarding transactions that the RM has enlisted in.</para>
	/// <para>
	/// RMs are typically persistent, meaning that after a system failure, they must be reopened to perform certain operations. Volatile,
	/// or transient, RMs can be created by calling the <c>CreateResourceManager</c> function and by specifying
	/// RESOURCE_MANAGER_VOLATILE. Volatile RMs do not perform recovery operations, but do require notifications about a transaction.
	/// </para>
	/// <para>You can create a volatile RM on a durable TM, but you cannot create a durable RM on a volatile TM.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ktmw32/nf-ktmw32-createresourcemanager HANDLE CreateResourceManager( IN
	// LPSECURITY_ATTRIBUTES lpResourceManagerAttributes, IN LPGUID ResourceManagerId, IN DWORD CreateOptions, IN HANDLE TmHandle, LPWSTR
	// Description );
	[DllImport(Lib.Ktmw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("ktmw32.h", MSDNShortId = "ad88e478-1dff-4f35-a0e3-6bda8bb45711")]
	public static extern SafeHRESMGR CreateResourceManager([In, Optional] SECURITY_ATTRIBUTES lpResourceManagerAttributes, [In] in Guid ResourceManagerId, [In, Optional] CreateRMOptions CreateOptions, [In] HTRXNMGR TmHandle, [MarshalAs(UnmanagedType.LPWStr), Optional] string? Description);

	/// <summary>Creates a new transaction object.</summary>
	/// <param name="lpTransactionAttributes">
	/// <para>
	/// A pointer to a SECURITY_ATTRIBUTES structure that determines whether the returned handle can be inherited by child processes. If
	/// this parameter is <c>NULL</c>, the handle cannot be inherited.
	/// </para>
	/// <para>
	/// The <c>lpSecurityDescriptor</c> member of the structure specifies a security descriptor for the new event. If
	/// lpTransactionAttributes is <c>NULL</c>, the object gets a default security descriptor. The access control lists (ACL) in the
	/// default security descriptor for a transaction come from the primary or impersonation token of the creator.
	/// </para>
	/// </param>
	/// <param name="UOW">Reserved. Must be zero (0).</param>
	/// <param name="CreateOptions">
	/// <para>Any optional transaction instructions.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>TRANSACTION_DO_NOT_PROMOTE</term>
	/// <term>The transaction cannot be distributed.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="IsolationLevel">Reserved; specify zero (0).</param>
	/// <param name="IsolationFlags">Reserved; specify zero (0).</param>
	/// <param name="Timeout">
	/// <para>
	/// The time-out interval, in milliseconds. If a nonzero value is specified, the transaction will be aborted when the interval
	/// elapses if it has not already reached the prepared state.
	/// </para>
	/// <para>Specify zero (0) or INFINITE to provide an infinite time-out.</para>
	/// </param>
	/// <param name="Description">A user-readable description of the transaction.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a handle to the transaction.</para>
	/// <para>
	/// If the function fails, the return value is <c>INVALID_HANDLE_VALUE</c>. To get extended error information, call the GetLastError function.
	/// </para>
	/// <para>The following list identifies the possible error codes:</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Use the CloseHandle function to close the transaction handle. If the last transaction handle is closed before a client calls the
	/// CommitTransaction function with the transaction handle, then KTM rolls back the transaction.
	/// </para>
	/// <para>
	/// If the transaction might need to be promotable to a distributed transaction, then you must grant the Distributed Transaction
	/// Coordinator (DTC) access rights to enlist in the transaction. To do this, the lpTransactionAttributes parameter needs to contain
	/// an access control entry with the DTC’s SID (S-1-5-80-2818357584-3387065753-4000393942-342927828-138088443) and the
	/// TRANSACTION_ENLIST right. For more information, see Distributed Transaction Coordinator and Access Control Components.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ktmw32/nf-ktmw32-createtransaction HANDLE CreateTransaction( IN
	// LPSECURITY_ATTRIBUTES lpTransactionAttributes, IN LPGUID UOW, IN DWORD CreateOptions, IN DWORD IsolationLevel, IN DWORD
	// IsolationFlags, IN DWORD Timeout, LPWSTR Description );
	[DllImport(Lib.Ktmw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("ktmw32.h", MSDNShortId = "578bda35-bd35-4f6d-8366-a4bfb4dbfe42")]
	public static extern SafeHTRXN CreateTransaction([In, Optional] SECURITY_ATTRIBUTES lpTransactionAttributes, [In, Optional] IntPtr UOW, [In, Optional] CreateTrxnOptions CreateOptions, [In, Optional] uint IsolationLevel, [In, Optional] uint IsolationFlags, [In, Optional] uint Timeout, [MarshalAs(UnmanagedType.LPWStr), Optional] string? Description);

	/// <summary>Creates a new transaction manager (TM) object and returns a handle with the specified access.</summary>
	/// <param name="lpTransactionAttributes">The transaction SECURITY_ATTRIBUTES (ACLs) for the TM object.</param>
	/// <param name="LogFileName">
	/// The log file stream name. If the stream does not exist in the log, it is created. To create a volatile TM, this parameter must be
	/// <c>NULL</c> and CreateOptions must specify TRANSACTION_MANAGER_VOLATILE, this transaction manager is considered volatile.
	/// </param>
	/// <param name="CreateOptions">
	/// <para>Any optional attributes for the new TM.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>TRANSACTION_MANAGER_VOLATILE</term>
	/// <term>Indicates that the TM is volatile, and does not perform recovery.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="CommitStrength">Reserved; specify zero.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a handle to the transaction manager.</para>
	/// <para>
	/// If the function fails, the return value is INVALID_HANDLE_VALUE. To get extended error information, call the GetLastError function.
	/// </para>
	/// <para>The following list identifies the possible error codes:</para>
	/// </returns>
	/// <remarks>
	/// <para>Immediately after calling this function, you must call RecoverTransactionManager.</para>
	/// <para>If your transaction manager is volatile, all your resource managers must also be volatile.</para>
	/// <para>You must call RecoverTransactionManager after creating a TM in order for the TM to function correctly.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ktmw32/nf-ktmw32-createtransactionmanager HANDLE CreateTransactionManager( IN
	// LPSECURITY_ATTRIBUTES lpTransactionAttributes, LPWSTR LogFileName, IN ULONG CreateOptions, IN ULONG CommitStrength );
	[DllImport(Lib.Ktmw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("ktmw32.h", MSDNShortId = "f5b7d0c1-9cd0-48fc-8125-d4da040951c4")]
	public static extern SafeHTRXNMGR CreateTransactionManager([In, Optional] SECURITY_ATTRIBUTES lpTransactionAttributes, [MarshalAs(UnmanagedType.LPWStr), Optional] string? LogFileName, [In, Optional] CreateTrxnMgrOptions CreateOptions, uint CommitStrength = 0);

	/// <summary>Obtains a virtual clock value from a transaction manager.</summary>
	/// <param name="TransactionManagerHandle">A handle to the transaction manager to obtain a virtual clock value for.</param>
	/// <param name="TmVirtualClock">The latest virtual clock value for the transaction manager. See LARGE_INTEGER.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is 0 (zero). To get extended error information, call the GetLastError function.</para>
	/// <para>The following list identifies the possible error codes:</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/ktmw32/nf-ktmw32-getcurrentclocktransactionmanager BOOL
	// GetCurrentClockTransactionManager( IN HANDLE TransactionManagerHandle, OUT PLARGE_INTEGER TmVirtualClock );
	[DllImport(Lib.Ktmw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("ktmw32.h", MSDNShortId = "21d7c0fa-3a49-43b3-9325-d3dfdabbcb98")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetCurrentClockTransactionManager([In] HTRXNMGR TransactionManagerHandle, out long TmVirtualClock);

	/// <summary>Obtains the identifier (ID) for the specified enlistment.</summary>
	/// <param name="EnlistmentHandle">A handle to the enlistment.</param>
	/// <param name="EnlistmentId">A pointer to a variables that receives the ID of the enlistment.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is 0 (zero). To get extended error information, call the GetLastError function.</para>
	/// <para>The following list identifies the possible error codes:</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/ktmw32/nf-ktmw32-getenlistmentid BOOL GetEnlistmentId( IN HANDLE
	// EnlistmentHandle, OUT LPGUID EnlistmentId );
	[DllImport(Lib.Ktmw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("ktmw32.h", MSDNShortId = "ffd37a2e-6bac-4566-bb15-eafce8a11c3b")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetEnlistmentId([In] HENLISTMENT EnlistmentHandle, out Guid EnlistmentId);

	/// <summary>
	/// Retrieves an opaque structure of recovery data from KTM. Recovery information is stored in a log on behalf of a resource manager
	/// (RM) by calling the SetEnlistmentRecoveryInformation function. After a failure, the RM can use the
	/// <c>GetEnlistmentRecoveryInformation</c> function to retrieve the information.
	/// </summary>
	/// <param name="EnlistmentHandle">A handle to the enlistment.</param>
	/// <param name="BufferSize">The size of the Buffer parameter, in bytes.</param>
	/// <param name="Buffer">A pointer to a buffer that receives the enlistment recovery information.</param>
	/// <param name="BufferUsed">A pointer to a variable that receives the actual number of bytes returned in the Buffer parameter.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is 0 (zero). To get extended error information, call the GetLastError function.</para>
	/// <para>The following list identifies the possible error codes:</para>
	/// </returns>
	/// <remarks>This call cannot be used with volatile transaction managers.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ktmw32/nf-ktmw32-getenlistmentrecoveryinformation BOOL
	// GetEnlistmentRecoveryInformation( IN HANDLE EnlistmentHandle, IN ULONG BufferSize, OUT PVOID Buffer, OUT PULONG BufferUsed );
	[DllImport(Lib.Ktmw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("ktmw32.h", MSDNShortId = "05bfbe81-5f3d-4e32-b4fa-4532227f522e")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetEnlistmentRecoveryInformation([In] HENLISTMENT EnlistmentHandle, [In] uint BufferSize, IntPtr Buffer, out uint BufferUsed);

	/// <summary>
	/// Requests and receives a notification for a resource manager (RM). This function is used by the RM register to receive
	/// notifications when a transaction changes state.
	/// </summary>
	/// <param name="ResourceManagerHandle">A handle to the resource manager.</param>
	/// <param name="TransactionNotification">A pointer to a TRANSACTION_NOTIFICATION structure that receives the first available notification.</param>
	/// <param name="NotificationLength">The size of the TransactionNotification buffer, in bytes.</param>
	/// <param name="dwMilliseconds">
	/// The time, in milliseconds, for which the calling application is blocking while waiting for the notification to become available.
	/// If no notifications are available when the timeout expires, <c>ERROR_TIMEOUT</c> is returned.
	/// </param>
	/// <param name="ReturnLength">
	/// A pointer to a variable that receives the actual size of the notification received by the TransactionNotification parameter.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero (0). To get extended error information, call the GetLastError function.</para>
	/// <para>The following list identifies the possible error codes:</para>
	/// </returns>
	/// <remarks>
	/// All resource managers must register to receive <c>TRANSACTION_NOTIFY_PREPREPARE</c>, <c>TRANSACTION_NOTIFY_PREPARE</c>, and
	/// <c>TRANSACTION_NOTIFY_COMMIT</c> notifications, even if they subsequently call ReadOnlyEnlistment to mark an enlistment as
	/// read-only. Resource managers can support <c>TRANSACTION_NOTIFY_SINGLE_PHASE_COMMIT</c>, but they must also support the
	/// multi-phase pre-prepare, prepare, and commit notifications. For the list of all notifications that resource managers can receive,
	/// see TRANSACTION_NOTIFICATION.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ktmw32/nf-ktmw32-getnotificationresourcemanager BOOL
	// GetNotificationResourceManager( IN HANDLE ResourceManagerHandle, OUT PTRANSACTION_NOTIFICATION TransactionNotification, IN ULONG
	// NotificationLength, IN DWORD dwMilliseconds, OUT PULONG ReturnLength );
	[DllImport(Lib.Ktmw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("ktmw32.h", MSDNShortId = "d606f960-e843-4478-8ba7-5201f85c44ce")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetNotificationResourceManager([In] HRESMGR ResourceManagerHandle, IntPtr TransactionNotification, [In] uint NotificationLength, [In, Optional] uint dwMilliseconds, out uint ReturnLength);

	/// <summary>
	/// Requests and receives asynchronous notification for a resource manager (RM). This function is used by the RM register to receive
	/// notifications when a transaction changes state.
	/// </summary>
	/// <param name="ResourceManagerHandle">A handle to the resource manager.</param>
	/// <param name="TransactionNotification">A pointer to a TRANSACTION_NOTIFICATION structure that receives the first available notification.</param>
	/// <param name="TransactionNotificationLength">The size of the TransactionNotification buffer, in bytes.</param>
	/// <param name="ReturnLength">
	/// A pointer to a variable that receives the actual size of the notification received by the TransactionNotification parameter.
	/// </param>
	/// <param name="lpOverlapped">A pointer to an OVERLAPPED structure that is required for asynchronous operation.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero (0). To get extended error information, call the GetLastError function.</para>
	/// <para>The following list identifies the possible error codes:</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// All resource managers must register to receive <c>TRANSACTION_NOTIFY_PREPREPARE</c>, <c>TRANSACTION_NOTIFY_PREPARE</c>, and
	/// <c>TRANSACTION_NOTIFY_COMMIT</c> notifications, even if they subsequently call ReadOnlyEnlistment to mark an enlistment as
	/// read-only. Resource managers can support <c>TRANSACTION_NOTIFY_SINGLE_PHASE_COMMIT</c>, but they must also support the
	/// multi-phase pre-prepare, prepare, and commit notifications. For the list of all notifications that resource managers can receive,
	/// see TRANSACTION_NOTIFICATION.
	/// </para>
	/// <para>
	/// Resource managers (RM) may want to call this function more than once to provide multiple buffers for KTM to use when delivering
	/// notifications. The number of calls to this function depends on how much load your RM is carrying.
	/// </para>
	/// <para>This function must be called after the SetResourceManagerCompletionPort function is called.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ktmw32/nf-ktmw32-getnotificationresourcemanagerasync BOOL
	// GetNotificationResourceManagerAsync( IN HANDLE ResourceManagerHandle, OUT PTRANSACTION_NOTIFICATION TransactionNotification, IN
	// ULONG TransactionNotificationLength, OUT PULONG ReturnLength, IN LPOVERLAPPED lpOverlapped );
	[DllImport(Lib.Ktmw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("ktmw32.h", MSDNShortId = "c83e104b-6cd7-4399-8232-7c2e7b408f1a")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern unsafe bool GetNotificationResourceManagerAsync([In] HRESMGR ResourceManagerHandle, IntPtr TransactionNotification, [In] uint TransactionNotificationLength, out uint ReturnLength, [In] NativeOverlapped* lpOverlapped);

	/// <summary>Obtains the identifier (ID) for the specified transaction.</summary>
	/// <param name="TransactionHandle">A handle to the transaction.</param>
	/// <param name="TransactionId">A pointer to a variable that receives the ID of the transaction.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is 0 (zero). To get extended error information, call the GetLastError function.</para>
	/// <para>The following list identifies the possible error codes:</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/ktmw32/nf-ktmw32-gettransactionid BOOL GetTransactionId( IN HANDLE
	// TransactionHandle, OUT LPGUID TransactionId );
	[DllImport(Lib.Ktmw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("ktmw32.h", MSDNShortId = "10f4729f-3e6e-469a-8f72-48c29735e7b1")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetTransactionId([In] HTRXN TransactionHandle, out Guid TransactionId);

	/// <summary>Returns the requested information about the specified transaction.</summary>
	/// <param name="TransactionHandle">
	/// A handle to the transaction. The handle must have the TRANSACTION_QUERY_INFORMATION permission to retrieve the information.
	/// </param>
	/// <param name="Outcome">
	/// A pointer to a buffer that receives the current outcome of the transaction. If the call to the <c>GetTransactionInformation</c>
	/// function is successful, this value will be one of the TRANSACTION_OUTCOME enumeration values.
	/// </param>
	/// <param name="IsolationLevel">Reserved.</param>
	/// <param name="IsolationFlags">Reserved.</param>
	/// <param name="Timeout">A pointer to a variable that receives the timeout value, in milliseconds, for this transaction.</param>
	/// <param name="BufferLength">
	/// The size of the Description parameter, in bytes. The buffer length value cannot be longer than the value of MAX_TRANSACTION_DESCRIPTION_LENGTH.
	/// </param>
	/// <param name="Description">A pointer to a buffer that receives the user-defined description of the transaction.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call the GetLastError function.</para>
	/// <para>The following list identifies the possible error codes:</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/ktmw32/nf-ktmw32-gettransactioninformation BOOL GetTransactionInformation( IN
	// HANDLE TransactionHandle, OUT PDWORD Outcome, OUT PDWORD IsolationLevel, OUT PDWORD IsolationFlags, OUT PDWORD Timeout, DWORD
	// BufferLength, LPWSTR Description );
	[DllImport(Lib.Ktmw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("ktmw32.h", MSDNShortId = "5ce3c96a-629e-49d0-8ec4-f9bf76af99ac")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetTransactionInformation([In] HTRXN TransactionHandle, out TRANSACTION_OUTCOME Outcome, [Optional] IntPtr IsolationLevel, [Optional] IntPtr IsolationFlags, out uint Timeout, uint BufferLength, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder Description);

	/// <summary>Obtains an identifier for the specified transaction manager.</summary>
	/// <param name="TransactionManagerHandle">A handle to the transaction manager.</param>
	/// <param name="TransactionManagerId">A pointer to a variable that receives the identifier for the transaction manager.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is 0 (zero). To get extended error information, call the GetLastError function.</para>
	/// <para>The following list identifies the possible error codes:</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/ktmw32/nf-ktmw32-gettransactionmanagerid BOOL GetTransactionManagerId( IN
	// HANDLE TransactionManagerHandle, OUT LPGUID TransactionManagerId );
	[DllImport(Lib.Ktmw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("ktmw32.h", MSDNShortId = "e1aa573d-add9-42b7-8b2b-773dc12aa51b")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetTransactionManagerId([In] HTRXNMGR TransactionManagerHandle, out Guid TransactionManagerId);

	/// <summary>Opens an existing enlistment object, and returns a handle to the enlistment.</summary>
	/// <param name="dwDesiredAccess">The access requested for this enlistment. See Enlistment Access Masks for a list of valid values.</param>
	/// <param name="ResourceManagerHandle">A handle to the resource manager.</param>
	/// <param name="EnlistmentId">The enlistment identifier.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a handle to the enlistment.</para>
	/// <para>
	/// If the function fails, the return value is INVALID_HANDLE_VALUE. To get extended error information, call the GetLastError function.
	/// </para>
	/// <para>The following list identifies the possible error codes:</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/ktmw32/nf-ktmw32-openenlistment HANDLE OpenEnlistment( IN DWORD
	// dwDesiredAccess, IN HANDLE ResourceManagerHandle, IN LPGUID EnlistmentId );
	[DllImport(Lib.Ktmw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("ktmw32.h", MSDNShortId = "2c403e22-3feb-415a-b65b-572802764548")]
	public static extern SafeHENLISTMENT OpenEnlistment([In] EnlistmentAccess dwDesiredAccess, [In] HRESMGR ResourceManagerHandle, [In] in Guid EnlistmentId);

	/// <summary>Opens an existing resource manager (RM).</summary>
	/// <param name="dwDesiredAccess">The access requested for the RM. See Resource Manager Access Masks for a list of valid values.</param>
	/// <param name="TmHandle">A handle to the transaction manager.</param>
	/// <param name="ResourceManagerId">The identifier for this resource manager.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a handle to the resource manager.</para>
	/// <para>
	/// If the function fails, the return value is INVALID_HANDLE_VALUE. To get extended error information, call the GetLastError function.
	/// </para>
	/// <para>The following list identifies the possible error codes:</para>
	/// </returns>
	/// <remarks>Immediately after calling this function, you must call RecoverResourceManager.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ktmw32/nf-ktmw32-openresourcemanager HANDLE OpenResourceManager( IN DWORD
	// dwDesiredAccess, IN HANDLE TmHandle, IN LPGUID ResourceManagerId );
	[DllImport(Lib.Ktmw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("ktmw32.h", MSDNShortId = "396b586f-c594-4481-b095-862e9058519c")]
	public static extern SafeHRESMGR OpenResourceManager([In] ResourceManagerAccess dwDesiredAccess, [In] HTRXNMGR TmHandle, [In] in Guid ResourceManagerId);

	/// <summary>Opens an existing transaction.</summary>
	/// <param name="dwDesiredAccess">
	/// The access to the transaction object. You must have read and write access to work with a transaction. See Transaction Access
	/// Masks for a list of valid values.
	/// </param>
	/// <param name="TransactionId">
	/// The GUID that identifies the transaction to be opened. This is commonly referred to as a unit of work for the transaction.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a handle to the transaction.</para>
	/// <para>
	/// If the function fails, the return value is INVALID_HANDLE_VALUE. To get extended error information, call the GetLastError function.
	/// </para>
	/// <para>The following list identifies the possible error codes:</para>
	/// </returns>
	/// <remarks>
	/// Clients close the transaction handle by using the CloseHandle function. If the last transaction handle is closed without anyone
	/// calling the CommitTransaction function on the transaction, then the KTM implicitly rolls back the transaction.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ktmw32/nf-ktmw32-opentransaction HANDLE OpenTransaction( IN DWORD
	// dwDesiredAccess, IN LPGUID TransactionId );
	[DllImport(Lib.Ktmw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("ktmw32.h", MSDNShortId = "d95f15e4-d0fd-4665-849d-eecac8fc542b")]
	public static extern SafeHTRXN OpenTransaction([In] TransactionAccess dwDesiredAccess, [In] in Guid TransactionId);

	/// <summary>Opens an existing transaction manager.</summary>
	/// <param name="LogFileName">The name of the log stream. This stream must exist within a CLFS log file.</param>
	/// <param name="DesiredAccess">The access requested. See Transaction Manager Access Masks for a list of valid values.</param>
	/// <param name="OpenOptions">Reserved; specify zero.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a handle to the transaction manager.</para>
	/// <para>
	/// If the function fails, the return value is INVALID_HANDLE_VALUE. To get extended error information, call the GetLastError function.
	/// </para>
	/// <para>The following list identifies the possible error codes:</para>
	/// </returns>
	/// <remarks>
	/// <para>Immediately after calling this function, you must call RecoverTransactionManager.</para>
	/// <para>
	/// The LogFileName must be specified using the NT file format. For example: &lt;drive&gt;:&lt;path&gt;. Do not use the .BLF extension.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ktmw32/nf-ktmw32-opentransactionmanager HANDLE OpenTransactionManager( LPWSTR
	// LogFileName, IN ACCESS_MASK DesiredAccess, IN ULONG OpenOptions );
	[DllImport(Lib.Ktmw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("ktmw32.h", MSDNShortId = "6b53609a-b956-441c-b5b5-9a8e6aa489c9")]
	public static extern SafeHTRXNMGR OpenTransactionManager([MarshalAs(UnmanagedType.LPWStr)] string LogFileName, [In] TransactionMgrAccess DesiredAccess, uint OpenOptions = 0);

	/// <summary>Opens an existing transaction manager.</summary>
	/// <param name="TransactionManagerId">The identifier of the transaction to open.</param>
	/// <param name="DesiredAccess">The access requested. See Transaction Manager Access Masks for a list of valid values.</param>
	/// <param name="OpenOptions">Reserved; specify zero.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a handle to the transaction manager.</para>
	/// <para>
	/// If the function fails, the return value is INVALID_HANDLE_VALUE. To get extended error information, call the GetLastError function.
	/// </para>
	/// <para>The following list identifies the possible error codes:</para>
	/// </returns>
	/// <remarks>Immediately after calling this function, you must call RecoverTransactionManager.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ktmw32/nf-ktmw32-opentransactionmanagerbyid HANDLE OpenTransactionManagerById(
	// LPGUID TransactionManagerId, IN ACCESS_MASK DesiredAccess, IN ULONG OpenOptions );
	[DllImport(Lib.Ktmw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("ktmw32.h", MSDNShortId = "4724383d-8ecf-40cb-8159-15a6d5ddfd1b")]
	public static extern SafeHTRXNMGR OpenTransactionManagerById(in Guid TransactionManagerId, [In] TransactionMgrAccess DesiredAccess, uint OpenOptions = 0);

	/// <summary>
	/// Indicates that the resource manager (RM) has completed all processing necessary to guarantee that a commit or abort operation
	/// will succeed for the specified transaction.
	/// </summary>
	/// <param name="EnlistmentHandle">A handle to the enlistment.</param>
	/// <param name="TmVirtualClock">
	/// <para>
	/// The latest virtual clock value received for this prepare complete notification. If you specify <c>NULL</c>, the virtual clock
	/// value is not changed. See LARGE_INTEGER.
	/// </para>
	/// <para>To change the virtual clock value, this value must be greater than the current value returned in the COMMIT notification.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero (0). To get extended error information, call the GetLastError function.</para>
	/// <para>The following list identifies the possible error codes:</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/ktmw32/nf-ktmw32-preparecomplete BOOL PrepareComplete( IN HANDLE
	// EnlistmentHandle, IN PLARGE_INTEGER TmVirtualClock );
	[DllImport(Lib.Ktmw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("ktmw32.h", MSDNShortId = "47488c70-3409-4544-bcca-3415f91e7194")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool PrepareComplete([In] HENLISTMENT EnlistmentHandle, in long TmVirtualClock);

	/// <summary>
	/// Indicates that the resource manager (RM) has completed all processing necessary to guarantee that a commit or abort operation
	/// will succeed for the specified transaction.
	/// </summary>
	/// <param name="EnlistmentHandle">A handle to the enlistment.</param>
	/// <param name="TmVirtualClock">
	/// <para>
	/// The latest virtual clock value received for this prepare complete notification. If you specify <c>NULL</c>, the virtual clock
	/// value is not changed. See LARGE_INTEGER.
	/// </para>
	/// <para>To change the virtual clock value, this value must be greater than the current value returned in the COMMIT notification.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero (0). To get extended error information, call the GetLastError function.</para>
	/// <para>The following list identifies the possible error codes:</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/ktmw32/nf-ktmw32-preparecomplete BOOL PrepareComplete( IN HANDLE
	// EnlistmentHandle, IN PLARGE_INTEGER TmVirtualClock );
	[DllImport(Lib.Ktmw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("ktmw32.h", MSDNShortId = "47488c70-3409-4544-bcca-3415f91e7194")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool PrepareComplete([In] HENLISTMENT EnlistmentHandle, [Optional] IntPtr TmVirtualClock);

	/// <summary>
	/// Prepares the transaction associated with this enlistment handle. This function is used by communication resource managers
	/// (sometimes called superior transaction managers).
	/// </summary>
	/// <param name="EnlistmentHandle">A handle to the enlistment for which the prepare operation has completed.</param>
	/// <param name="TmVirtualClock">A pointer to the latest virtual clock value received for this transaction.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero (0). To get extended error information, call the GetLastError function.</para>
	/// <para>The following list identifies the possible error codes:</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/ktmw32/nf-ktmw32-prepareenlistment BOOL PrepareEnlistment( IN HANDLE
	// EnlistmentHandle, IN PLARGE_INTEGER TmVirtualClock );
	[DllImport(Lib.Ktmw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("ktmw32.h", MSDNShortId = "5f1b1eb2-e2f5-4daf-b549-7f0c195414f0")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool PrepareEnlistment([In] HENLISTMENT EnlistmentHandle, in long TmVirtualClock);

	/// <summary>
	/// Signals that this resource manager has completed its pre-prepare work, so that other resource managers can now begin their
	/// prepare operations.
	/// </summary>
	/// <param name="EnlistmentHandle">A handle to the enlistment.</param>
	/// <param name="TmVirtualClock">
	/// <para>
	/// The latest virtual clock value received for this pre-prepare operation. If you specify <c>NULL</c>, the virtual clock value is
	/// not changed. See LARGE_INTEGER.
	/// </para>
	/// <para>To change the virtual clock value, this value must be greater than the current value returned in the COMMIT notification.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero (0). To get extended error information, call the GetLastError function.</para>
	/// <para>The following list identifies the possible error codes:</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/ktmw32/nf-ktmw32-prepreparecomplete BOOL PrePrepareComplete( IN HANDLE
	// EnlistmentHandle, IN PLARGE_INTEGER TmVirtualClock );
	[DllImport(Lib.Ktmw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("ktmw32.h", MSDNShortId = "b4a70a51-2c49-4626-9fca-9ca6e0d21a53")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool PrePrepareComplete([In] HENLISTMENT EnlistmentHandle, in long TmVirtualClock);

	/// <summary>
	/// Signals that this resource manager has completed its pre-prepare work, so that other resource managers can now begin their
	/// prepare operations.
	/// </summary>
	/// <param name="EnlistmentHandle">A handle to the enlistment.</param>
	/// <param name="TmVirtualClock">
	/// <para>
	/// The latest virtual clock value received for this pre-prepare operation. If you specify <c>NULL</c>, the virtual clock value is
	/// not changed. See LARGE_INTEGER.
	/// </para>
	/// <para>To change the virtual clock value, this value must be greater than the current value returned in the COMMIT notification.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero (0). To get extended error information, call the GetLastError function.</para>
	/// <para>The following list identifies the possible error codes:</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/ktmw32/nf-ktmw32-prepreparecomplete BOOL PrePrepareComplete( IN HANDLE
	// EnlistmentHandle, IN PLARGE_INTEGER TmVirtualClock );
	[DllImport(Lib.Ktmw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("ktmw32.h", MSDNShortId = "b4a70a51-2c49-4626-9fca-9ca6e0d21a53")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool PrePrepareComplete([In] HENLISTMENT EnlistmentHandle, [Optional] IntPtr TmVirtualClock);

	/// <summary>
	/// Pre-prepares the transaction associated with this enlistment handle. This function is used by communication resource managers
	/// (sometimes called superior transaction managers).
	/// </summary>
	/// <param name="EnlistmentHandle">A handle to the enlistment for which the prepare operation has completed.</param>
	/// <param name="TmVirtualClock">A pointer to the latest virtual clock value received for this transaction.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero (0). To get extended error information, call the GetLastError function.</para>
	/// <para>The following list identifies the possible error codes:</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/ktmw32/nf-ktmw32-preprepareenlistment BOOL PrePrepareEnlistment( IN HANDLE
	// EnlistmentHandle, IN PLARGE_INTEGER TmVirtualClock );
	[DllImport(Lib.Ktmw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("ktmw32.h", MSDNShortId = "7a336267-4bee-4aac-abff-ec112650789a")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool PrePrepareEnlistment([In] HENLISTMENT EnlistmentHandle, in long TmVirtualClock);

	/// <summary>
	/// Requests that the specified enlistment be converted to a read-only enlistment. A read-only enlistment cannot participate in the
	/// outcome of the transaction and is not durably recorded for recovery.
	/// </summary>
	/// <param name="EnlistmentHandle">A handle to the enlistment.</param>
	/// <param name="TmVirtualClock">
	/// <para>
	/// The latest virtual clock value received for this enlistment. If you specify <c>NULL</c>, the virtual clock value is not changed.
	/// See LARGE_INTEGER.
	/// </para>
	/// <para>To change the virtual clock value, this value must be greater than the current value returned in the COMMIT notification.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero (0). To get extended error information, call the GetLastError function.</para>
	/// <para>The following list identifies the possible error codes:</para>
	/// </returns>
	/// <remarks>
	/// If a resource manager no longer needs to participate in a transaction without rolling back the transaction, it should call
	/// <c>ReadOnlyEnlistment</c> prior to closing the enlistment handle.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ktmw32/nf-ktmw32-readonlyenlistment BOOL ReadOnlyEnlistment( IN HANDLE
	// EnlistmentHandle, IN PLARGE_INTEGER TmVirtualClock );
	[DllImport(Lib.Ktmw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("ktmw32.h", MSDNShortId = "a6411fad-8ad0-4a31-9e09-0c18dd384634")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ReadOnlyEnlistment([In] HENLISTMENT EnlistmentHandle, in long TmVirtualClock);

	/// <summary>
	/// Requests that the specified enlistment be converted to a read-only enlistment. A read-only enlistment cannot participate in the
	/// outcome of the transaction and is not durably recorded for recovery.
	/// </summary>
	/// <param name="EnlistmentHandle">A handle to the enlistment.</param>
	/// <param name="TmVirtualClock">
	/// <para>
	/// The latest virtual clock value received for this enlistment. If you specify <c>NULL</c>, the virtual clock value is not changed.
	/// See LARGE_INTEGER.
	/// </para>
	/// <para>To change the virtual clock value, this value must be greater than the current value returned in the COMMIT notification.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero (0). To get extended error information, call the GetLastError function.</para>
	/// <para>The following list identifies the possible error codes:</para>
	/// </returns>
	/// <remarks>
	/// If a resource manager no longer needs to participate in a transaction without rolling back the transaction, it should call
	/// <c>ReadOnlyEnlistment</c> prior to closing the enlistment handle.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ktmw32/nf-ktmw32-readonlyenlistment BOOL ReadOnlyEnlistment( IN HANDLE
	// EnlistmentHandle, IN PLARGE_INTEGER TmVirtualClock );
	[DllImport(Lib.Ktmw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("ktmw32.h", MSDNShortId = "a6411fad-8ad0-4a31-9e09-0c18dd384634")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ReadOnlyEnlistment([In] HENLISTMENT EnlistmentHandle, [Optional] IntPtr TmVirtualClock);

	/// <summary>Recovers an enlistment's state.</summary>
	/// <param name="EnlistmentHandle">A handle to the enlistment.</param>
	/// <param name="EnlistmentKey">The key to the enlistment to be recovered.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero (0). To get extended error information, call the GetLastError function.</para>
	/// <para>The following list identifies the possible error codes:</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/ktmw32/nf-ktmw32-recoverenlistment BOOL RecoverEnlistment( IN HANDLE
	// EnlistmentHandle, IN PVOID EnlistmentKey );
	[DllImport(Lib.Ktmw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("ktmw32.h", MSDNShortId = "5c36732f-bf4f-4071-959e-3359be0b2363")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool RecoverEnlistment([In] HENLISTMENT EnlistmentHandle, [In, Optional] IntPtr EnlistmentKey);

	/// <summary>Recovers a resource manager's state from its log file.</summary>
	/// <param name="ResourceManagerHandle">A handle to the resource manager.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero (0). To get extended error information, call the GetLastError function.</para>
	/// <para>The following list identifies the possible error codes:</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/ktmw32/nf-ktmw32-recoverresourcemanager BOOL RecoverResourceManager( IN HANDLE
	// ResourceManagerHandle );
	[DllImport(Lib.Ktmw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("ktmw32.h", MSDNShortId = "616ff873-c0d0-464e-9b1b-74a426b99abd")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool RecoverResourceManager([In] HRESMGR ResourceManagerHandle);

	/// <summary>Recovers a transaction manager's state from its log file.</summary>
	/// <param name="TransactionManagerHandle">A handle to the transaction manager.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero (0). To get extended error information, call the GetLastError function.</para>
	/// <para>The following list identifies the possible error codes:</para>
	/// </returns>
	/// <remarks>This function must be called after you call CreateTransactionManager.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ktmw32/nf-ktmw32-recovertransactionmanager BOOL RecoverTransactionManager( IN
	// HANDLE TransactionManagerHandle );
	[DllImport(Lib.Ktmw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("ktmw32.h", MSDNShortId = "6f217ebb-3423-41d3-acff-eb21838c9751")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool RecoverTransactionManager([In] HTRXNMGR TransactionManagerHandle);

	/// <summary>
	/// Renames a transaction manager (TM) object. This function can only be used on named TM handles. A new <c>GUID</c> for the TM is
	/// selected and can be retrieved using the GetTransactionManagerID function.
	/// </summary>
	/// <param name="LogFileName">The name of the log stream. This stream must exist within a CLFS log file.</param>
	/// <param name="ExistingTransactionManagerGuid">A value that specifies the current name of the TM.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero (0). To get extended error information, call the GetLastError function.</para>
	/// <para>The following list identifies the possible error codes:</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/ktmw32/nf-ktmw32-renametransactionmanager BOOL RenameTransactionManager( LPWSTR
	// LogFileName, IN LPGUID ExistingTransactionManagerGuid );
	[DllImport(Lib.Ktmw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("ktmw32.h", MSDNShortId = "2767e689-1342-458f-a215-a29d774c0648")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool RenameTransactionManager([MarshalAs(UnmanagedType.LPWStr)] string LogFileName, in Guid ExistingTransactionManagerGuid);

	/// <summary>Indicates that the resource manager (RM) has successfully completed rolling back a transaction.</summary>
	/// <param name="EnlistmentHandle">A handle the enlistment.</param>
	/// <param name="TmVirtualClock">The latest virtual clock value received for this transaction. See LARGE_INTEGER.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero (0). To get extended error information, call the GetLastError function.</para>
	/// <para>The following list identifies the possible error codes:</para>
	/// </returns>
	/// <remarks>
	/// If the RM was not able to successfully roll back a transaction, the RM should request a full rollback by calling the
	/// RollbackTransaction function.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ktmw32/nf-ktmw32-rollbackcomplete BOOL RollbackComplete( IN HANDLE
	// EnlistmentHandle, IN PLARGE_INTEGER TmVirtualClock );
	[DllImport(Lib.Ktmw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("ktmw32.h", MSDNShortId = "c9d53777-eef9-4c60-921d-50b0fbf8d005")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool RollbackComplete([In] HENLISTMENT EnlistmentHandle, in long TmVirtualClock);

	/// <summary>
	/// Rolls back the specified transaction that is associated with an enlistment. This function cannot be called for read-only enlistments.
	/// </summary>
	/// <param name="EnlistmentHandle">A handle to the enlistment.</param>
	/// <param name="TmVirtualClock">The latest virtual clock value received for this enlistment. See LARGE_INTEGER.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero (0). To get extended error information, call the GetLastError function.</para>
	/// <para>The following list identifies the possible error codes:</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function is used by an RM to roll back a transaction in which it is enlisted. All work associated with the transaction is
	/// rolled back.
	/// </para>
	/// <para>Rollbacks are allowed by enlistments at any time before it issues a prepare complete notification.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ktmw32/nf-ktmw32-rollbackenlistment BOOL RollbackEnlistment( IN HANDLE
	// EnlistmentHandle, IN PLARGE_INTEGER TmVirtualClock );
	[DllImport(Lib.Ktmw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("ktmw32.h", MSDNShortId = "e62c0c81-6802-4a76-94bb-617933490e83")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool RollbackEnlistment([In] HENLISTMENT EnlistmentHandle, in long TmVirtualClock);

	/// <summary>Requests that the specified transaction be rolled back. This function is synchronous.</summary>
	/// <param name="TransactionHandle">A handle to the transaction.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>
	/// If the function fails, the return value is zero. To get extended error information, call the GetLastError function. The following
	/// list identifies the possible error codes:
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/ktmw32/nf-ktmw32-rollbacktransaction BOOL RollbackTransaction( IN HANDLE
	// TransactionHandle );
	[DllImport(Lib.Ktmw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("ktmw32.h", MSDNShortId = "7d3522b8-ddf0-449e-8ab4-09e679ba1f15")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool RollbackTransaction([In] HTRXN TransactionHandle);

	/// <summary>Requests that the specified transaction be rolled back. This function returns asynchronously.</summary>
	/// <param name="TransactionHandle">A handle to the transaction.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero, and GetLastError returns ERROR_IO_PENDING.</para>
	/// <para>
	/// If the function fails, the return value is zero. To get extended error information, call the GetLastError function. The following
	/// list identifies the possible error codes:
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/ktmw32/nf-ktmw32-rollbacktransactionasync BOOL RollbackTransactionAsync( IN
	// HANDLE TransactionHandle );
	[DllImport(Lib.Ktmw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("ktmw32.h", MSDNShortId = "df23e5af-c37e-4e60-b160-6ffa8f6a26e3")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool RollbackTransactionAsync([In] HTRXN TransactionHandle);

	/// <summary>Recovers information only to the specified virtual clock value.</summary>
	/// <param name="TransactionManagerHandle">A handle to the transaction manager.</param>
	/// <param name="TmVirtualClock">A pointer to the latest virtual clock value received for this transaction.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is 0 (zero). To get extended error information, call the GetLastError function.</para>
	/// <para>The following list identifies the possible error codes:</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/ktmw32/nf-ktmw32-rollforwardtransactionmanager BOOL
	// RollforwardTransactionManager( IN HANDLE TransactionManagerHandle, IN PLARGE_INTEGER TmVirtualClock );
	[DllImport(Lib.Ktmw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("ktmw32.h", MSDNShortId = "13492b74-8707-46bb-93f1-59c3c5ceab6d")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool RollforwardTransactionManager([In] HTRXNMGR TransactionManagerHandle, in long TmVirtualClock);

	/// <summary>
	/// Sets an opaque, user-defined structure of recovery data from KTM. Recovery information is stored in a log on behalf of a resource
	/// manager (RM) by calling <c>SetEnlistmentRecoveryInformation</c>. After a failure, the RM can use GetEnlistmentRecoveryInformation
	/// to retrieve the information.
	/// </summary>
	/// <param name="EnlistmentHandle">A handle to the enlistment.</param>
	/// <param name="BufferSize">The size of Buffer, in bytes.</param>
	/// <param name="Buffer">The recovery information.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is 0 (zero). To get extended error information, call the GetLastError function.</para>
	/// <para>The following list identifies the possible error codes:</para>
	/// </returns>
	/// <remarks>
	/// <para>This call cannot be used with volatile transaction managers.</para>
	/// <para>
	/// The information that is provided by the user may not be durably stored in the log at the completion of this operation, but it
	/// will be durably stored by the end of the next commit operation for this enlistment.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ktmw32/nf-ktmw32-setenlistmentrecoveryinformation BOOL
	// SetEnlistmentRecoveryInformation( IN HANDLE EnlistmentHandle, IN ULONG BufferSize, IN PVOID Buffer );
	[DllImport(Lib.Ktmw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("ktmw32.h", MSDNShortId = "54e7526f-57f0-40cd-9624-fce0644a0884")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetEnlistmentRecoveryInformation([In] HENLISTMENT EnlistmentHandle, [In] uint BufferSize, [In] IntPtr Buffer);

	/// <summary>
	/// Associates the specified I/O completion port with the specified resource manager (RM). This port receives all notifications for
	/// the RM.
	/// </summary>
	/// <param name="ResourceManagerHandle">A handle to the resource manager.</param>
	/// <param name="IoCompletionPortHandle">A handle to the I/O completion port.</param>
	/// <param name="CompletionKey">
	/// The user-defined identifier. Typically, it is used to associate the receive notification with a specific resource manager.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is 0 (zero). To get extended error information, call the GetLastError function.</para>
	/// <para>The following list identifies the possible error codes:</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// This function must be used in conjunction with the GetNotificationResourceManagerAsync function, which provides the buffers that
	/// KTM uses to deliver notifications asynchronously. These functions provide a different way to receive notifications from KTM. You
	/// can use these two functions instead of the GetNotificationResourceManager function.
	/// </para>
	/// <para>This function must be called before calling GetNotificationResourceManagerAsync.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/ktmw32/nf-ktmw32-setresourcemanagercompletionport BOOL
	// SetResourceManagerCompletionPort( IN HANDLE ResourceManagerHandle, IN HANDLE IoCompletionPortHandle, IN ULONG_PTR CompletionKey );
	[DllImport(Lib.Ktmw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("ktmw32.h", MSDNShortId = "219fc899-84ee-474f-9f86-6ebf9c721810")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetResourceManagerCompletionPort([In] HRESMGR ResourceManagerHandle, [In] IntPtr IoCompletionPortHandle, [In] IntPtr CompletionKey);

	/// <summary>Sets the transaction information for the specified transaction.</summary>
	/// <param name="TransactionHandle">
	/// A handle to the transaction. The handle must have the TRANSACTION_SET_INFORMATION permission to set the transaction information.
	/// </param>
	/// <param name="IsolationLevel">Reserved; specify zero.</param>
	/// <param name="IsolationFlags">Reserved.</param>
	/// <param name="Timeout">The timeout value, in milliseconds, for this transaction.</param>
	/// <param name="Description">The user-defined description of this transaction.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is 0 (zero). To get extended error information, call the GetLastError function.</para>
	/// <para>The following list identifies the possible error codes:</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/ktmw32/nf-ktmw32-settransactioninformation BOOL SetTransactionInformation( IN
	// HANDLE TransactionHandle, IN DWORD IsolationLevel, IN DWORD IsolationFlags, IN DWORD Timeout, LPWSTR Description );
	[DllImport(Lib.Ktmw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("ktmw32.h", MSDNShortId = "e33d221b-cd06-4f20-a4b5-407a04362ba0")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SetTransactionInformation([In] HTRXN TransactionHandle, [In, Optional] uint IsolationLevel, [In, Optional] uint IsolationFlags, [In, Optional] uint Timeout, [MarshalAs(UnmanagedType.LPWStr), Optional] string? Description);

	/// <summary>
	/// Indicates that the resource manager (RM) is refusing a single-phase request. When a transaction manager (TM) receives this call,
	/// it initiates a two-phase commit and sends a prepare request to all enlisted RMs.
	/// </summary>
	/// <param name="EnlistmentHandle">A handle to the enlistment.</param>
	/// <param name="TmVirtualClock">
	/// <para>
	/// The latest virtual clock value received from the single-phase request notification. If you specify <c>NULL</c>, the virtual clock
	/// value is not changed. See LARGE_INTEGER.
	/// </para>
	/// <para>To change the virtual clock value, this value must be greater than the current value returned in the COMMIT notification.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero (0). To get extended error information, call the GetLastError function.</para>
	/// <para>The following list identifies the possible error codes:</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/ktmw32/nf-ktmw32-singlephasereject BOOL SinglePhaseReject( IN HANDLE
	// EnlistmentHandle, IN PLARGE_INTEGER TmVirtualClock );
	[DllImport(Lib.Ktmw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("ktmw32.h", MSDNShortId = "8cc77686-e130-4b82-b2f5-70121b40e052")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SinglePhaseReject([In] HENLISTMENT EnlistmentHandle, in long TmVirtualClock);

	/// <summary>
	/// Indicates that the resource manager (RM) is refusing a single-phase request. When a transaction manager (TM) receives this call,
	/// it initiates a two-phase commit and sends a prepare request to all enlisted RMs.
	/// </summary>
	/// <param name="EnlistmentHandle">A handle to the enlistment.</param>
	/// <param name="TmVirtualClock">
	/// <para>
	/// The latest virtual clock value received from the single-phase request notification. If you specify <c>NULL</c>, the virtual clock
	/// value is not changed. See LARGE_INTEGER.
	/// </para>
	/// <para>To change the virtual clock value, this value must be greater than the current value returned in the COMMIT notification.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero (0). To get extended error information, call the GetLastError function.</para>
	/// <para>The following list identifies the possible error codes:</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/ktmw32/nf-ktmw32-singlephasereject BOOL SinglePhaseReject( IN HANDLE
	// EnlistmentHandle, IN PLARGE_INTEGER TmVirtualClock );
	[DllImport(Lib.Ktmw32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("ktmw32.h", MSDNShortId = "8cc77686-e130-4b82-b2f5-70121b40e052")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SinglePhaseReject([In] HENLISTMENT EnlistmentHandle, [Optional] IntPtr TmVirtualClock);

	/// <summary>Provides a handle to an enlistment.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct HENLISTMENT : IKernelHandle
	{
		private readonly IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="HENLISTMENT"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HENLISTMENT(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HENLISTMENT"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HENLISTMENT NULL => new HENLISTMENT(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="HENLISTMENT"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(HENLISTMENT h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HENLISTMENT"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HENLISTMENT(IntPtr h) => new HENLISTMENT(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HENLISTMENT h1, HENLISTMENT h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HENLISTMENT h1, HENLISTMENT h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj is HENLISTMENT h ? handle == h.handle : false;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a handle to a resource manager.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct HRESMGR : IKernelHandle
	{
		private readonly IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="HRESMGR"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HRESMGR(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HRESMGR"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HRESMGR NULL => new HRESMGR(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="HRESMGR"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(HRESMGR h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HRESMGR"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HRESMGR(IntPtr h) => new HRESMGR(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HRESMGR h1, HRESMGR h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HRESMGR h1, HRESMGR h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj is HRESMGR h ? handle == h.handle : false;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Provides a handle to a Transaction Manager (TM).</summary>
	[StructLayout(LayoutKind.Sequential)]
	public struct HTRXNMGR : IKernelHandle
	{
		private readonly IntPtr handle;

		/// <summary>Initializes a new instance of the <see cref="HTRXNMGR"/> struct.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		public HTRXNMGR(IntPtr preexistingHandle) => handle = preexistingHandle;

		/// <summary>Returns an invalid handle by instantiating a <see cref="HTRXNMGR"/> object with <see cref="IntPtr.Zero"/>.</summary>
		public static HTRXNMGR NULL => new HTRXNMGR(IntPtr.Zero);

		/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
		public bool IsNull => handle == IntPtr.Zero;

		/// <summary>Performs an explicit conversion from <see cref="HTRXNMGR"/> to <see cref="IntPtr"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static explicit operator IntPtr(HTRXNMGR h) => h.handle;

		/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HTRXNMGR"/>.</summary>
		/// <param name="h">The pointer to a handle.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HTRXNMGR(IntPtr h) => new HTRXNMGR(h);

		/// <summary>Implements the operator !=.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator !=(HTRXNMGR h1, HTRXNMGR h2) => !(h1 == h2);

		/// <summary>Implements the operator ==.</summary>
		/// <param name="h1">The first handle.</param>
		/// <param name="h2">The second handle.</param>
		/// <returns>The result of the operator.</returns>
		public static bool operator ==(HTRXNMGR h1, HTRXNMGR h2) => h1.Equals(h2);

		/// <inheritdoc/>
		public override bool Equals(object? obj) => obj is HTRXNMGR h ? handle == h.handle : false;

		/// <inheritdoc/>
		public override int GetHashCode() => handle.GetHashCode();

		/// <inheritdoc/>
		public IntPtr DangerousGetHandle() => handle;
	}

	/// <summary>Contains the data that is associated with a transaction notification.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ktmtypes/ns-ktmtypes-transaction_notification typedef struct
	// _TRANSACTION_NOTIFICATION { PVOID TransactionKey; ULONG TransactionNotification; LARGE_INTEGER TmVirtualClock; ULONG
	// ArgumentLength; } TRANSACTION_NOTIFICATION, *PTRANSACTION_NOTIFICATION;
	[PInvokeData("ktmtypes.h", MSDNShortId = "4f87de9d-a068-4ab9-8f38-b75f20552b1d")]
	[StructLayout(LayoutKind.Sequential)]
	public struct TRANSACTION_NOTIFICATION
	{
		/// <summary>The user-defined, opaque ID for this transaction.</summary>
		public IntPtr TransactionKey;

		/// <summary>The NOTIFICATION_MASK value for this transaction.</summary>
		public NOTIFICATION_MASK TransactionNotification;

		/// <summary>The latest virtual clock value that is associated with this transaction. See LARGE_INTEGER.</summary>
		public long TmVirtualClock;

		/// <summary>
		/// Indicates the number of bytes for the TRANSACTION_NOTIFICATION_RECOVERY_ARGUMENT structure that follow this
		/// <c>TRANSACTION_NOTIFICATION</c> structure.
		/// </summary>
		public uint ArgumentLength;
	}

	/// <summary>Indicates the transaction to be recovered. This structure is sent with a recovery notification.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/ktmtypes/ns-ktmtypes-transaction_notification_recovery_argument typedef struct
	// _TRANSACTION_NOTIFICATION_RECOVERY_ARGUMENT { GUID EnlistmentId; UOW UOW; } TRANSACTION_NOTIFICATION_RECOVERY_ARGUMENT, *PTRANSACTION_NOTIFICATION_RECOVERY_ARGUMENT;
	[PInvokeData("ktmtypes.h", MSDNShortId = "29a32b89-22d1-4d26-8927-a2051dd5d37a")]
	[StructLayout(LayoutKind.Sequential)]
	public struct TRANSACTION_NOTIFICATION_RECOVERY_ARGUMENT
	{
		/// <summary>The enlistment identifier.</summary>
		public Guid EnlistmentId;

		/// <summary>The transaction identifier, sometimes called the unit of work.</summary>
		public Guid UOW;
	}

	/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="HENLISTMENT"/> that is disposed using <see cref="CloseHandle"/>.</summary>
	public class SafeHENLISTMENT : SafeKernelHandle
	{
		/// <summary>Initializes a new instance of the <see cref="SafeHENLISTMENT"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		public SafeHENLISTMENT(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Initializes a new instance of the <see cref="SafeHENLISTMENT"/> class.</summary>
		private SafeHENLISTMENT() : base() { }

		/// <summary>Performs an implicit conversion from <see cref="SafeHENLISTMENT"/> to <see cref="HENLISTMENT"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HENLISTMENT(SafeHENLISTMENT h) => h.handle;

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() => CloseHandle(handle);
	}

	/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="HRESMGR"/> that is disposed using <see cref="CloseHandle"/>.</summary>
	public class SafeHRESMGR : SafeKernelHandle
	{
		/// <summary>Initializes a new instance of the <see cref="SafeHRESMGR"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		public SafeHRESMGR(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Initializes a new instance of the <see cref="SafeHRESMGR"/> class.</summary>
		private SafeHRESMGR() : base() { }

		/// <summary>Performs an implicit conversion from <see cref="SafeHRESMGR"/> to <see cref="HRESMGR"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HRESMGR(SafeHRESMGR h) => h.handle;

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() => CloseHandle(handle);
	}

	/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="HTRXN"/> that is disposed using <see cref="CloseHandle"/>.</summary>
	public class SafeHTRXN : SafeKernelHandle
	{
		/// <summary>Initializes a new instance of the <see cref="SafeHTRXN"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		public SafeHTRXN(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Initializes a new instance of the <see cref="SafeHTRXN"/> class.</summary>
		private SafeHTRXN() : base() { }

		/// <summary>Performs an implicit conversion from <see cref="SafeHTRXN"/> to <see cref="HTRXN"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HTRXN(SafeHTRXN h) => h.handle;

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() => CloseHandle(handle);
	}

	/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="HTRXNMGR"/> that is disposed using <see cref="CloseHandle"/>.</summary>
	public class SafeHTRXNMGR : SafeKernelHandle
	{
		/// <summary>Initializes a new instance of the <see cref="SafeHTRXNMGR"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		public SafeHTRXNMGR(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Initializes a new instance of the <see cref="SafeHTRXNMGR"/> class.</summary>
		private SafeHTRXNMGR() : base() { }

		/// <summary>Performs an implicit conversion from <see cref="SafeHTRXNMGR"/> to <see cref="HTRXNMGR"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HTRXNMGR(SafeHTRXNMGR h) => h.handle;

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() => CloseHandle(handle);
	}
}