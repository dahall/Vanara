using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Security;

namespace Vanara.PInvoke;

/// <summary>Platform invokable enumerated types, constants and functions from ntdsapi.h</summary>
public static partial class NTDSApi
{
	private const uint NO_ERROR = 0;

	/// <summary>
	/// The <c>SyncUpdateProc</c> function is an application-defined function that handles update messages passed from the
	/// <c>DsReplicaSyncAll</c> function. <c>SyncUpdateProc</c> is a placeholder for the application-defined callback function name.
	/// </summary>
	/// <param name="pData">
	/// Pointer to application-defined data passed in the pCallbackData parameter of the <c>DsReplicaSyncAll</c> function.
	/// </param>
	/// <param name="pUpdate">
	/// Pointer to a <c>DS_REPSYNCALL_UPDATE</c> structure that describes the event in the <c>DsReplicaSyncAll</c> function that caused
	/// the <c>SyncUpdateProc</c> callback function to be called.
	/// </param>
	/// <returns>
	/// Execution of the <c>DsReplicaSyncAll</c> function pauses when it calls the <c>SyncUpdateProc</c> callback function. If
	/// <c>SyncUpdateProc</c> returns <c>TRUE</c>, execution of <c>DsReplicaSyncAll</c> resumes. Otherwise, the <c>DsReplicaSyncAll</c>
	/// function terminates.
	/// </returns>
	// BOOL SyncUpdateProc( LPVOID pData, PDS_REPSYNCALL_UPDATE pUpdate ); https://msdn.microsoft.com/en-us/library/ms677968(v=vs.85).aspx
	[UnmanagedFunctionPointer(CallingConvention.Winapi)]
	[PInvokeData("ntdsapi.h", MSDNShortId = "ms677968")]
	// [return: MarshalAs(UnmanagedType.Bool)] public static extern bool SyncUpdateProc(IntPtr pData, PDS_REPSYNCALL_UPDATE pUpdate);
	[return: MarshalAs(UnmanagedType.Bool)]
	public delegate bool SyncUpdateProc(IntPtr pData, ref DS_REPSYNCALL_UPDATE pUpdate);

	/// <summary>Identifies the task that the KCC should execute.</summary>
	[PInvokeData("ntdsapi.h", MSDNShortId = "2a83ffcb-1ebd-4024-a186-9c079896f4e1")]
	public enum DS_KCC_TASKID
	{
		/// <summary>Update topology.</summary>
		DS_KCC_TASKID_UPDATE_TOPOLOGY = 0
	}

	/// <summary>
	/// Defines the errors returned by the status member of the <see cref="DS_NAME_RESULT_ITEM"/> structure. These are potential errors
	/// that may be encountered while a name is converted by the <see cref="DsCrackNames(SafeDsHandle, string[], DS_NAME_FORMAT,
	/// DS_NAME_FORMAT, DS_NAME_FLAGS)"/> function.
	/// </summary>
	[PInvokeData("NTDSApi.h", MSDNShortId = "ms676061")]
	public enum DS_NAME_ERROR
	{
		/// <summary>The conversion was successful.</summary>
		DS_NAME_NO_ERROR = 0,

		/// <summary>A generic processing error occurred.</summary>
		DS_NAME_ERROR_RESOLVING = 1,

		/// <summary>The name cannot be found or the caller does not have permission to access the name.</summary>
		DS_NAME_ERROR_NOT_FOUND = 2,

		/// <summary>
		/// The input name is mapped to more than one output name or the desired format did not have a single, unique value for the
		/// object found.
		/// </summary>
		DS_NAME_ERROR_NOT_UNIQUE = 3,

		/// <summary>
		/// The input name was found, but the associated output format cannot be found. This can occur if the object does not have all
		/// the required attributes.
		/// </summary>
		DS_NAME_ERROR_NO_MAPPING = 4,

		/// <summary>
		/// Unable to resolve entire name, but was able to determine in which domain object resides. The caller is expected to retry the
		/// call at a domain controller for the specified domain. The entire name cannot be resolved, but the domain that the object
		/// resides in could be determined. The pDomain member of the DS_NAME_RESULT_ITEM contains valid data when this error is specified.
		/// </summary>
		DS_NAME_ERROR_DOMAIN_ONLY = 5,

		/// <summary>A syntactical mapping cannot be performed on the client without transmitting over the network.</summary>
		DS_NAME_ERROR_NO_SYNTACTICAL_MAPPING = 6,

		/// <summary>The name is from an external trusted forest.</summary>
		DS_NAME_ERROR_TRUST_REFERRAL = 7
	}

	/// <summary>
	/// Used to define how the name syntax will be cracked. These flags are used by the <see cref="DsCrackNames(SafeDsHandle, string[],
	/// DS_NAME_FORMAT, DS_NAME_FORMAT, DS_NAME_FLAGS)"/> function.
	/// </summary>
	[Flags]
	[PInvokeData("NTDSApi.h", MSDNShortId = "ms676062")]
	public enum DS_NAME_FLAGS
	{
		/// <summary>Indicates that there are no associated flags.</summary>
		DS_NAME_NO_FLAGS = 0x0,

		/// <summary>
		/// Performs a syntactical mapping at the client without transferring over the network. The only syntactic mapping supported is
		/// from DS_FQDN_1779_NAME to DS_CANONICAL_NAME or DS_CANONICAL_NAME_EX. <see cref="DsCrackNames(SafeDsHandle, string[],
		/// DS_NAME_FORMAT, DS_NAME_FORMAT, DS_NAME_FLAGS)"/> returns the DS_NAME_ERROR_NO_SYNTACTICAL_MAPPING flag if a syntactical
		/// mapping is not possible.
		/// </summary>
		DS_NAME_FLAG_SYNTACTICAL_ONLY = 0x1,

		/// <summary>Forces a trip to the domain controller for evaluation, even if the syntax could be cracked locally.</summary>
		DS_NAME_FLAG_EVAL_AT_DC = 0x2,

		/// <summary>The call fails if the domain controller is not a global catalog server.</summary>
		DS_NAME_FLAG_GCVERIFY = 0x4,

		/// <summary>Enables cross forest trust referral.</summary>
		DS_NAME_FLAG_TRUST_REFERRAL = 0x8
	}

	/// <summary>
	/// Provides formats to use for input and output names for the <see cref="DsCrackNames(SafeDsHandle, string[], DS_NAME_FORMAT,
	/// DS_NAME_FORMAT, DS_NAME_FLAGS)"/> function.
	/// </summary>
	[PInvokeData("NTDSApi.h", MSDNShortId = "ms676245")]
	public enum DS_NAME_FORMAT
	{
		/// <summary>
		/// Indicates the name is using an unknown name type. This format can impact performance because it forces the server to attempt
		/// to match all possible formats. Only use this value if the input format is unknown.
		/// </summary>
		DS_UNKNOWN_NAME = 0,

		/// <summary>
		/// Indicates that the fully qualified distinguished name is used. For example: CN = someone, OU = Users, DC = Engineering, DC =
		/// Fabrikam, DC = Com
		/// </summary>
		DS_FQDN_1779_NAME = 1,

		/// <summary>
		/// Indicates a Windows NT 4.0 account name. For example: Engineering\someone The domain-only version includes two trailing
		/// backslashes (\\).
		/// </summary>
		DS_NT4_ACCOUNT_NAME = 2,

		/// <summary>
		/// Indicates a user-friendly display name, for example, Jeff Smith. The display name is not necessarily the same as relative
		/// distinguished name (RDN).
		/// </summary>
		DS_DISPLAY_NAME = 3,

		/// <summary>Indicates a GUID string that the IIDFromString function returns. For example: {4fa050f0-f561-11cf-bdd9-00aa003a77b6}</summary>
		DS_UNIQUE_ID_NAME = 6,

		/// <summary>
		/// Indicates a complete canonical name. For example: engineering.fabrikam.com/software/someone The domain-only version includes
		/// a trailing forward slash (/).
		/// </summary>
		DS_CANONICAL_NAME = 7,

		/// <summary>Indicates that it is using the user principal name (UPN). For example: someone@engineering.fabrikam.com</summary>
		DS_USER_PRINCIPAL_NAME = 8,

		/// <summary>
		/// This element is the same as DS_CANONICAL_NAME except that the rightmost forward slash (/) is replaced with a newline
		/// character (\n), even in a domain-only case. For example: engineering.fabrikam.com/software\nsomeone
		/// </summary>
		DS_CANONICAL_NAME_EX = 9,

		/// <summary>Indicates it is using a generalized service principal name. For example: www/www.fabrikam.com@fabrikam.com</summary>
		DS_SERVICE_PRINCIPAL_NAME = 10,

		/// <summary>
		/// Indicates a Security Identifier (SID) for the object. This can be either the current SID or a SID from the object SID
		/// history. The SID string can use either the standard string representation of a SID, or one of the string constants defined in
		/// Sddl.h. For more information about converting a binary SID into a SID string, see SID Strings. The following is an example of
		/// a SID string: S-1-5-21-397955417-626881126-188441444-501
		/// </summary>
		DS_SID_OR_SID_HISTORY_NAME = 11,

		/// <summary>Not supported by the Directory Service (DS) APIs.</summary>
		DS_DNS_DOMAIN_NAME = 12,

		/// <summary>
		/// This causes DsCrackNames to return the distinguished names of all naming contexts in the current forest. The formatDesired
		/// parameter is ignored. cNames must be at least one and all strings in rpNames must have a length greater than zero characters.
		/// The contents of the rpNames strings is ignored.
		/// </summary>
		DS_LIST_NCS = unchecked((int)0xfffffff6)
	}

	/// <summary>
	/// <para>
	/// The <c>DS_REPL_INFO_TYPE</c> enumeration is used with the DsReplicaGetInfo and DsReplicaGetInfo2 functions to specify the type of
	/// replication data to retrieve.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/ne-ntdsapi-_ds_repl_info_type typedef enum _DS_REPL_INFO_TYPE {
	// DS_REPL_INFO_NEIGHBORS, DS_REPL_INFO_CURSORS_FOR_NC, DS_REPL_INFO_METADATA_FOR_OBJ, DS_REPL_INFO_KCC_DSA_CONNECT_FAILURES,
	// DS_REPL_INFO_KCC_DSA_LINK_FAILURES, DS_REPL_INFO_PENDING_OPS, DS_REPL_INFO_METADATA_FOR_ATTR_VALUE, DS_REPL_INFO_CURSORS_2_FOR_NC,
	// DS_REPL_INFO_CURSORS_3_FOR_NC, DS_REPL_INFO_METADATA_2_FOR_OBJ, DS_REPL_INFO_METADATA_2_FOR_ATTR_VALUE,
	// DS_REPL_INFO_METADATA_EXT_FOR_ATTR_VALUE, DS_REPL_INFO_TYPE_MAX } DS_REPL_INFO_TYPE;
	[PInvokeData("ntdsapi.h", MSDNShortId = "88d8a164-2192-4e73-a190-aa5b5dbb1101")]
	public enum DS_REPL_INFO_TYPE
	{
		/// <summary>
		/// Requests replication state data for naming context and source server pairs. Returns a pointer to a DS_REPL_NEIGHBORS structure.
		/// </summary>
		[CorrespondingType(typeof(DS_REPL_NEIGHBORS), CorrespondingAction.Get)]
		DS_REPL_INFO_NEIGHBORS,

		/// <summary>
		/// Requests replication state data with respect to all replicas of a given naming context. Returns a pointer to a
		/// DS_REPL_CURSORS structure.
		/// </summary>
		[CorrespondingType(typeof(DS_REPL_CURSORS), CorrespondingAction.Get)]
		DS_REPL_INFO_CURSORS_FOR_NC,

		/// <summary>
		/// Requests replication state data for the attributes for the given object. Returns a pointer to a DS_REPL_OBJ_META_DATA structure.
		/// </summary>
		[CorrespondingType(typeof(DS_REPL_OBJ_META_DATA), CorrespondingAction.Get)]
		DS_REPL_INFO_METADATA_FOR_OBJ,

		/// <summary>
		/// Requests replication state data with respect to connection failures between inbound replication partners. Returns a pointer
		/// to a DS_REPL_KCC_DSA_FAILURES structure.
		/// </summary>
		[CorrespondingType(typeof(DS_REPL_KCC_DSA_FAILURESW), CorrespondingAction.Get)]
		DS_REPL_INFO_KCC_DSA_CONNECT_FAILURES,

		/// <summary>
		/// Requests replication state data with respect to link failures between inbound replication partners. Returns a pointer to a
		/// DS_REPL_KCC_DSA_FAILURES structure.
		/// </summary>
		[CorrespondingType(typeof(DS_REPL_KCC_DSA_FAILURESW), CorrespondingAction.Get)]
		DS_REPL_INFO_KCC_DSA_LINK_FAILURES,

		/// <summary>
		/// Requests the replication tasks currently executing or queued to execute. Returns a pointer to a DS_REPL_PENDING_OPS structure.
		/// </summary>
		[CorrespondingType(typeof(DS_REPL_PENDING_OPSW), CorrespondingAction.Get)]
		DS_REPL_INFO_PENDING_OPS,

		/// <summary>
		/// Requests replication state data for a specific attribute for the given object. Returns a pointer to a
		/// DS_REPL_ATTR_VALUE_META_DATA structure.
		/// </summary>
		[CorrespondingType(typeof(DS_REPL_ATTR_VALUE_META_DATA), CorrespondingAction.Get)]
		DS_REPL_INFO_METADATA_FOR_ATTR_VALUE,

		/// <summary>
		/// Requests replication state data with respect to all replicas of a given naming context. Returns a pointer to a
		/// DS_REPL_CURSORS_2 structure.
		/// </summary>
		[CorrespondingType(typeof(DS_REPL_CURSORS_2), CorrespondingAction.Get)]
		DS_REPL_INFO_CURSORS_2_FOR_NC,

		/// <summary>
		/// Requests replication state data with respect to all replicas of a given naming context. Returns a pointer to a
		/// DS_REPL_CURSORS_3 structure.
		/// </summary>
		[CorrespondingType(typeof(DS_REPL_CURSORS_3W), CorrespondingAction.Get)]
		DS_REPL_INFO_CURSORS_3_FOR_NC,

		/// <summary>
		/// Requests replication state data for the attributes for the given object. Returns a pointer to a DS_REPL_OBJ_META_DATA_2 structure.
		/// </summary>
		[CorrespondingType(typeof(DS_REPL_OBJ_META_DATA_2), CorrespondingAction.Get)]
		DS_REPL_INFO_METADATA_2_FOR_OBJ,

		/// <summary>
		/// Requests replication state data for a specific attribute for the given object. Returns a pointer to a
		/// DS_REPL_ATTR_VALUE_META_DATA_2 structure.
		/// </summary>
		[CorrespondingType(typeof(DS_REPL_ATTR_VALUE_META_DATA_2), CorrespondingAction.Get)]
		DS_REPL_INFO_METADATA_2_FOR_ATTR_VALUE,

		/// <summary>
		/// Requests replication state data for a specific attribute for the given object. Returns a pointer to a
		/// DS_REPL_ATTR_VALUE_META_DATA_EXT structure.
		/// </summary>
		[CorrespondingType(typeof(DS_REPL_ATTR_VALUE_META_DATA_EXT), CorrespondingAction.Get)]
		DS_REPL_INFO_METADATA_EXT_FOR_ATTR_VALUE,
	}

	/// <summary>
	/// <para>
	/// The <c>DS_REPL_OP_TYPE</c> enumeration type is used to indicate the type of replication operation that a given entry in the
	/// replication queue represents.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/ne-ntdsapi-_ds_repl_op_type typedef enum _DS_REPL_OP_TYPE {
	// DS_REPL_OP_TYPE_SYNC, DS_REPL_OP_TYPE_ADD, DS_REPL_OP_TYPE_DELETE, DS_REPL_OP_TYPE_MODIFY, DS_REPL_OP_TYPE_UPDATE_REFS } DS_REPL_OP_TYPE;
	[PInvokeData("ntdsapi.h", MSDNShortId = "81d9f464-90f4-405c-b014-0a61f5a5b816")]
	public enum DS_REPL_OP_TYPE
	{
		/// <summary>Indicates an inbound replication over an existing replication agreement from a direct replication partner.</summary>
		DS_REPL_OP_TYPE_SYNC,

		/// <summary>Indicates the addition of a replication agreement for a new direct replication partner.</summary>
		DS_REPL_OP_TYPE_ADD,

		/// <summary>Indicates the removal of a replication agreement for an existing direct replication partner.</summary>
		DS_REPL_OP_TYPE_DELETE,

		/// <summary>Indicates the modification of a replication agreement for an existing direct replication partner.</summary>
		DS_REPL_OP_TYPE_MODIFY,

		/// <summary>Indicates the addition, deletion, or update of outbound change notification data for a direct replication partner.</summary>
		DS_REPL_OP_TYPE_UPDATE_REFS,
	}

	/// <summary>
	/// <para>
	/// The <c>DS_REPSYNCALL_ERROR</c> enumeration is used with the DS_REPSYNCALL_ERRINFO structure to indicate where in the replication
	/// process an error occurred.
	/// </para>
	/// </summary>
	// https://webcache.googleusercontent.com/search?q=cache:ryUMFaJus6sJ:https://docs.microsoft.com/is-is/windows/desktop/api/Ntdsapi/ne-ntdsapi-ds_repsyncall_error+&cd=1&hl=en&ct=clnk&gl=us
	// typedef enum DS_REPSYNCALL_ERROR { DS_REPSYNCALL_WIN32_ERROR_CONTACTING_SERVER , DS_REPSYNCALL_WIN32_ERROR_REPLICATING ,
	// DS_REPSYNCALL_SERVER_UNREACHABLE } ;
	[PInvokeData("ntdsapi.h", MSDNShortId = "9c020046-ab52-4676-931e-12ce176e93fb")]
	public enum DS_REPSYNCALL_ERROR
	{
		/// <summary>The server referred to by the pszSvrId member of the DS_REPSYNCALL_ERRINFO structure cannot be contacted.</summary>
		DS_REPSYNCALL_WIN32_ERROR_CONTACTING_SERVER,

		/// <summary>
		/// An error occurred during replication of the server identified by the pszSvrId member of the DS_REPSYNCALL_ERRINFO structure.
		/// </summary>
		DS_REPSYNCALL_WIN32_ERROR_REPLICATING,

		/// <summary>The server identified by the pszSvrId member of the DS_REPSYNCALL_ERRINFO structure cannot be contacted.</summary>
		DS_REPSYNCALL_SERVER_UNREACHABLE,
	}

	/// <summary>
	/// <para>
	/// The <c>DS_REPSYNCALL_EVENT</c> enumeration is used with the DS_REPSYNCALL_UPDATE structure to define which event the
	/// <c>DS_REPSYNCALL_UPDATE</c> structure represents.
	/// </para>
	/// </summary>
	// https://webcache.googleusercontent.com/search?q=cache:NyB4AWln394J:https://docs.microsoft.com/en-us/windows/desktop/api/Ntdsapi/ne-ntdsapi-ds_repsyncall_event+&cd=1&hl=en&ct=clnk&gl=us
	// typedef enum DS_REPSYNCALL_EVENT { DS_REPSYNCALL_EVENT_ERROR , DS_REPSYNCALL_EVENT_SYNC_STARTED ,
	// DS_REPSYNCALL_EVENT_SYNC_COMPLETED , DS_REPSYNCALL_EVENT_FINISHED } ;
	[PInvokeData("ntdsapi.h", MSDNShortId = "a732a906-0e26-45f6-b89c-58f2277057ba")]
	public enum DS_REPSYNCALL_EVENT
	{
		/// <summary>An error occurred. Error data is stored in the pErrInfo member of the DS_REPSYNCALL_UPDATE structure.</summary>
		DS_REPSYNCALL_EVENT_ERROR,

		/// <summary>
		/// Synchronization of two servers has started. Both the pErrInfo and pSync members of the DS_REPSYNCALL_UPDATE structure are NULL.
		/// </summary>
		DS_REPSYNCALL_EVENT_SYNC_STARTED,

		/// <summary>
		/// Synchronization of two servers has just finished. The servers involved in the synchronization are identified by the pSync
		/// member of the DS_REPSYNCALL_UPDATE structure. The pErrInfo member of the DS_REPSYNCALL_UPDATE structure is NULL.
		/// </summary>
		DS_REPSYNCALL_EVENT_SYNC_COMPLETED,

		/// <summary>
		/// Execution of DsReplicaSyncAll is complete. Both the pErrInfo and pSync members of the DS_REPSYNCALL_UPDATE structure are
		/// NULL. The return value of the callback function is ignored.
		/// </summary>
		DS_REPSYNCALL_EVENT_FINISHED,
	}

	/// <summary>
	/// <para>The <c>DS_SPN_NAME_TYPE</c> enumeration is used by the DsGetSPN function to identify the format for composing SPNs.</para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/ne-ntdsapi-ds_spn_name_type typedef enum DS_SPN_NAME_TYPE {
	// DS_SPN_DNS_HOST , DS_SPN_DN_HOST , DS_SPN_NB_HOST , DS_SPN_DOMAIN , DS_SPN_NB_DOMAIN , DS_SPN_SERVICE } ;
	[PInvokeData("ntdsapi.h", MSDNShortId = "7aab22a6-1fe1-4127-97d3-54287d770790")]
	public enum DS_SPN_NAME_TYPE
	{
		/// <summary>The SPN format for the distinguished name service of the host-based service, which provides services identified with its host computer. This SPN uses the following format:
		/// <para><code>jeffsmith.fabrikam.com</code></para></summary>
		DS_SPN_DNS_HOST,
		/// <summary>The SPN format for the distinguished name of the host-based service, which provides services identified with its host computer. This SPN uses the following format:
		/// <para><code>cn=jeffsmith,ou=computers,dc=fabrikam,dc=com</code></para></summary>
		DS_SPN_DN_HOST,
		/// <summary>The SPN format for the NetBIOS service of the host-based service, which provides services identified with its host computer. This SPN uses the following format:
		/// <para><code>jeffsmith-nec</code></para></summary>
		DS_SPN_NB_HOST,
		/// <summary>The SPN format for a replicable service that provides services to the specified domain. This SPN uses the following format:
		/// <para><code>fabrikam.com</code></para></summary>
		DS_SPN_DOMAIN,
		/// <summary>The SPN format for a replicable service that provides services to the specified NetBIOS domain. This SPN uses the following format:
		/// <para><code>fabrikam</code></para></summary>
		DS_SPN_NB_DOMAIN,
		/// <summary>The SPN format for a specified service. This SPN uses the following formats, depending on which service is used:
		/// <para><code>cn=anRpcService,cn=RPC Services,cn=system,dc=fabrikam,dc=com</code></para>
		/// <para><code>cn=aWsService,cn=Winsock Services,cn=system,dc=fabrikam,dc=com</code></para></summary>
		DS_SPN_SERVICE
	}

	/// <summary>
	/// <para>
	/// The <c>DS_SPN_WRITE_OP</c> enumeration identifies the type of write operation that should be performed by the DsWriteAccountSpn function.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/ne-ntdsapi-ds_spn_write_op typedef enum DS_SPN_WRITE_OP {
	// DS_SPN_ADD_SPN_OP , DS_SPN_REPLACE_SPN_OP , DS_SPN_DELETE_SPN_OP } ;
	[PInvokeData("ntdsapi.h", MSDNShortId = "8367bdaf-3d8d-46b3-9d03-b9753e8e5a1a")]
	public enum DS_SPN_WRITE_OP
	{
		/// <summary>Adds the specified service principal names (SPNs) to the object identified by the pszAccount parameter in DsWriteAccountSpn.</summary>
		DS_SPN_ADD_SPN_OP,

		/// <summary>
		/// Removes all SPNs currently registered on the account identified by the pszAccount parameter in DsWriteAccountSpn and replaces
		/// them with the SPNs specified by the rpszSpn parameter in DsWriteAccountSpn.
		/// </summary>
		DS_SPN_REPLACE_SPN_OP,

		/// <summary>Deletes the specified SPNs from the object identified by the pszAccount parameter in DsWriteAccountSpn.</summary>
		DS_SPN_DELETE_SPN_OP,
	}

	/// <summary>Flags for DsBindWithSpnEx and DsBindByInstance</summary>
	[PInvokeData("ntdsapi.h", MSDNShortId = "52a5761d-5244-4bc9-8c09-fd08f10a9fff")]
	[Flags]
	public enum DsBindFlags
	{
		/// <summary>
		/// <para>
		/// Causes the bind to use the delegate impersonation level. This enables operations that require delegation, such as
		/// DsAddSidHistory, to succeed. Specifying this flag also causes DsBindWithSpnEx to operate similar to DsBindWithSpn.
		/// </para>
		/// <para>
		/// If this flag is not specified, the bind will use the impersonate impersonation level. For more information about
		/// impersonation levels, see Impersonation Levels.
		/// </para>
		/// <para>
		/// Most operations do not require the delegate impersonation level; this flag should only be specified if it is required.
		/// Binding to a rogue server with the delegate impersonation level enables the rogue server to connect to a non-rogue server
		/// with your credentials and perform unintended operations.
		/// </para>
		/// </summary>
		NTDSAPI_BIND_ALLOW_DELEGATION = 0x00000001,

		/// <summary>
		/// With AD/AM, a single machine, could have multiple "AD's" on a single server. Since DsBindXxxx() will not pick an AD/AM
		/// instance without an instance specifier ( ":389" ), it can be difficult (well impossible) to determine from just a server
		/// name, what the instance annotation or instance guid is. This option will take a server name and find the first available AD
		/// or AD/AM instance. WARNING: The results could be non- deterministic on a server w/ multiple instances.
		/// </summary>
		NTDSAPI_BIND_FIND_BINDING = 0x00000002,

		/// <summary>
		/// Active Directory Lightweight Directory Services: If this flag is specified, DsBindWithSpnEx requires Kerberos authentication
		/// to be used. If Kerberos authentication cannot be established, DsBindWithSpnEx will not attempt to authenticate with any other mechanism.
		/// </summary>
		NTDSAPI_BIND_FORCE_KERBEROS = 0x00000004,
	}

	/// <summary>Contains a set of flags that modify the function behavior.</summary>
	[PInvokeData("ntdsapi.h", MSDNShortId = "2a83ffcb-1ebd-4024-a186-9c079896f4e1")]
	[Flags]
	public enum DsKCCFlags
	{
		/// <summary>The task is queued and then the function returns without waiting for the task to complete.</summary>
		DS_KCC_FLAG_ASYNC_OP = (1 << 0),

		/// <summary>The task will not be added to the queue if another queued task will run soon.</summary>
		DS_KCC_FLAG_DAMPED = (1 << 1),
	}

	/// <summary>Passes additional data to be used to process the request.</summary>
	[PInvokeData("ntdsapi.h", MSDNShortId = "33bd1b61-b9ed-479f-a128-fb7ddbb5e9af")]
	[Flags]
	public enum DsReplicaAddOptions
	{
		/// <summary>Performs this operation asynchronously.</summary>
		DS_REPADD_ASYNCHRONOUS_OPERATION = 0x00000001,

		/// <summary>Creates a writable replica; otherwise, the replica is read-only.</summary>
		DS_REPADD_WRITEABLE = 0x00000002,

		/// <summary>Synchronizes the NC from this source when the DSA is started.</summary>
		DS_REPADD_INITIAL = 0x00000004,

		/// <summary>Synchronizes the NC from this source periodically, as defined in pSchedule.</summary>
		DS_REPADD_PERIODIC = 0x00000008,

		/// <summary>
		/// Synchronizes from the source DSA using the Intersite Messaging Service (IMS) transport, for example, by SMTP, rather than
		/// using the native directory service RPC.
		/// </summary>
		DS_REPADD_INTERSITE_MESSAGING = 0x00000010,

		/// <summary>Does not replicate the NC. Instead, save enough state data such that it may be replicated later.</summary>
		DS_REPADD_ASYNCHRONOUS_REPLICA = 0x00000020,

		/// <summary>
		/// Disables notification-based synchronization for the NC from this source. This is expected to be a temporary state. Use
		/// DS_REPADD_NEVER_NOTIFY to permanently disable synchronization.
		/// </summary>
		DS_REPADD_DISABLE_NOTIFICATION = 0x00000040,

		/// <summary>Disables periodic synchronization for the NC from this source.</summary>
		DS_REPADD_DISABLE_PERIODIC = 0x00000080,

		/// <summary>
		/// Uses compression when replicating. This saves network bandwidth at the expense of CPU overhead at both the source and
		/// destination servers.
		/// </summary>
		DS_REPADD_USE_COMPRESSION = 0x00000100,

		/// <summary>
		/// <para>
		/// Disables change notifications from this source. When this flag is set, the source does not notify the destination when
		/// changes occur. This is recommended for all intersite replication that may occur over WAN links.
		/// </para>
		/// <para>This is expected to be a permanent state; use <c>DS_REPADD_DISABLE_NOTIFICATION</c> to temporarily disable notifications.</para>
		/// </summary>
		DS_REPADD_NEVER_NOTIFY = 0x00000200,

		/// <summary>Undocumented.</summary>
		DS_REPADD_TWO_WAY = 0x00000400,

		/// <summary>Undocumented.</summary>
		DS_REPADD_CRITICAL = 0x00000800,

		/// <summary>Undocumented.</summary>
		DS_REPADD_SELECT_SECRETS = 0x00001000,

		/// <summary>Undocumented.</summary>
		DS_REPADD_NONGC_RO_REPLICA = 0x01000000,
	}

	/// <summary>Passes additional data used to process the request.</summary>
	[PInvokeData("ntdsapi.h", MSDNShortId = "68c767c4-bbb6-477b-8ffb-94f3ae235375")]
	[Flags]
	public enum DsReplicaDelOptions
	{
		/// <summary>Performs this operation asynchronously.</summary>
		DS_REPDEL_ASYNCHRONOUS_OPERATION = 0x00000001,

		/// <summary>Signifies that the replica deleted can be written to.</summary>
		DS_REPDEL_WRITEABLE = 0x00000002,

		/// <summary>Signifies the replica is mail-based rather than synchronized using native directory service RPC.</summary>
		DS_REPDEL_INTERSITE_MESSAGING = 0x00000004,

		/// <summary>
		/// Ignores any error generated from contacting the source to instruct it to remove this NC from its list of servers to which it replicates.
		/// </summary>
		DS_REPDEL_IGNORE_ERRORS = 0x00000008,

		/// <summary>
		/// Does not contact the source to tell it to remove this NC from its list of servers to which it replicates. If this flag is not
		/// set and the link is based in RPC, the source is contacted.
		/// </summary>
		DS_REPDEL_LOCAL_ONLY = 0x00000010,

		/// <summary>Deletes all the objects in the NC. This option is valid only for read-only NCs with no source.</summary>
		DS_REPDEL_NO_SOURCE = 0x00000020,

		/// <summary>Allows deletion of a read-only replica even if it sources other read-only replicas.</summary>
		DS_REPDEL_REF_OK = 0x00000040,
	}

	/// <summary>Contains a set of flags that modify the behavior of the function.</summary>
	[PInvokeData("ntdsapi.h", MSDNShortId = "5735d91d-1b7d-4dc6-b6c6-61ba38ebe50d")]
	[Flags]
	public enum DsReplInfoFlags
	{
		/// <summary>No flags are set.</summary>
		DS_REPL_INFO_FLAG_NONE = 0,

		/// <summary>
		/// Causes the attribute metadata to account for metadata on the attribute's linked values. The resulting vector represents
		/// changes for all attributes. This modified vector is useful for clients that expect all attributes and metadata to be included
		/// in the attribute metadata vector.
		/// </summary>
		DS_REPL_INFO_FLAG_IMPROVE_LINKED_ATTRS = 0x00000001,
	}

	/// <summary>Specifies what fields should be modified. At least one field must be specified in ModifyFields.</summary>
	[PInvokeData("ntdsapi.h", MSDNShortId = "aad20527-1211-41bc-b0e9-02e4ab28ae2e")]
	[Flags]
	public enum DsReplModFieldFlags
	{
		/// <summary>Updates the flags associated with the replica.</summary>
		DS_REPMOD_UPDATE_FLAGS = 0x00000001,

		/// <summary>Updates the address associated with the referenced server.</summary>
		DS_REPMOD_UPDATE_INSTANCE = 0x00000002,

		/// <summary>Updates the address associated with the referenced server.</summary>
		DS_REPMOD_UPDATE_ADDRESS = DS_REPMOD_UPDATE_INSTANCE,

		/// <summary>Updates the periodic replication schedule associated with the replica.</summary>
		DS_REPMOD_UPDATE_SCHEDULE = 0x00000004,

		/// <summary>Not used. Specifying updates of result values is not currently supported. Result values default to 0.</summary>
		DS_REPMOD_UPDATE_RESULT = 0x00000008,

		/// <summary>Updates the transport associated with the replica.</summary>
		DS_REPMOD_UPDATE_TRANSPORT = 0x00000010,
	}

	/// <summary>Passes additional data used to process the request.</summary>
	[PInvokeData("ntdsapi.h", MSDNShortId = "aad20527-1211-41bc-b0e9-02e4ab28ae2e")]
	public enum DsReplModOptions
	{
		/// <summary>Performs this operation asynchronously.</summary>
		DS_REPMOD_ASYNCHRONOUS_OPERATION = 0x00000001,

		/// <summary>Indicates that the replica being modified can be written to.</summary>
		DS_REPMOD_WRITEABLE = 0x00000002
	}

	/// <summary>Contains a set of flags that specify attributes and options for the replication data.</summary>
	[PInvokeData("ntdsapi.h", MSDNShortId = "acab74f4-5739-4310-895b-081062c0360b")]
	[Flags]
	public enum DsReplNeighborFlags
	{
		/// <summary>
		/// <para>The local copy of the naming context is writable.</para>
		/// </summary>
		DS_REPL_NBR_WRITEABLE = 0x10,

		/// <summary>
		/// <para>
		/// Replication of this naming context from this source is attempted when the destination server is booted. This normally only
		/// applies to intra-site neighbors.
		/// </para>
		/// </summary>
		DS_REPL_NBR_SYNC_ON_STARTUP = 0x20,

		/// <summary>
		/// <para>
		/// Perform replication on a schedule. This flag is normally set unless the schedule for this naming context/source is "never",
		/// that is, the empty schedule.
		/// </para>
		/// </summary>
		DS_REPL_NBR_DO_SCHEDULED_SYNCS = 0x40,

		/// <summary>
		/// <para>
		/// Perform replication indirectly through the Inter-Site Messaging Service. This flag is set only when replicating over SMTP.
		/// This flag is not set when replicating over inter-site RPC/IP.
		/// </para>
		/// </summary>
		DS_REPL_NBR_USE_ASYNC_INTERSITE_TRANSPORT = 0x80,

		/// <summary>
		/// <para>
		/// If set, indicates that when inbound replication is complete, the destination server must tell the source server to
		/// synchronize in the reverse direction. This feature is used in dial-up scenarios where only one of the two servers can
		/// initiate a dial-up connection. For example, this option would be used in a corporate headquarters and branch office, where
		/// the branch office connects to the corporate headquarters over the Internet by means of a dial-up ISP connection.
		/// </para>
		/// </summary>
		DS_REPL_NBR_TWO_WAY_SYNC = 0x200,

		/// <summary>
		/// <para>
		/// This neighbor is in a state where it returns parent objects before children objects. It goes into this state after it
		/// receives a child object before its parent.
		/// </para>
		/// </summary>
		DS_REPL_NBR_RETURN_OBJECT_PARENTS = 0x800,

		/// <summary>
		/// <para>
		/// The destination server is performing a full synchronization from the source server. Full synchronizations do not use vectors
		/// that create updates (DS_REPL_CURSORS) for filtering updates. Full synchronizations are not used as a part of the normal
		/// replication protocol.
		/// </para>
		/// </summary>
		DS_REPL_NBR_FULL_SYNC_IN_PROGRESS = 0x10000,

		/// <summary>
		/// <para>
		/// The last packet from the source indicated a modification of an object that the destination server has not yet created. The
		/// next packet to be requested instructs the source server to put all attributes of the modified object into the packet.
		/// </para>
		/// </summary>
		DS_REPL_NBR_FULL_SYNC_NEXT_PACKET = 0x20000,

		/// <summary>
		/// <para>A synchronization has never been successfully completed from this source.</para>
		/// </summary>
		DS_REPL_NBR_NEVER_SYNCED = 0x200000,

		/// <summary>
		/// <para>
		/// The replication engine has temporarily stopped processing this neighbor in order to service another higher-priority neighbor,
		/// either for this partition or for another partition. The replication engine will resume processing this neighbor after the
		/// higher-priority work is completed.
		/// </para>
		/// </summary>
		DS_REPL_NBR_PREEMPTED = 0x1000000,

		/// <summary>
		/// <para>
		/// This neighbor is set to disable notification-based synchronizations. Within a site, domain controllers synchronize with each
		/// other based on notifications when changes occur. This setting prevents this neighbor from performing syncs that are triggered
		/// by notifications. The neighbor will still do synchronizations based on its schedule, or in response to manually requested synchronizations.
		/// </para>
		/// </summary>
		DS_REPL_NBR_IGNORE_CHANGE_NOTIFICATIONS = 0x4000000,

		/// <summary>
		/// <para>
		/// This neighbor is set to not perform synchronizations based on its schedule. The only way this neighbor will perform
		/// synchronizations is in response to change notifications or to manually requested synchronizations.
		/// </para>
		/// </summary>
		DS_REPL_NBR_DISABLE_SCHEDULED_SYNC = 0x8000000,

		/// <summary>
		/// <para>
		/// Changes received from this source are to be compressed. This is normally set if, and only if, the source server is in a
		/// different site.
		/// </para>
		/// </summary>
		DS_REPL_NBR_COMPRESS_CHANGES = 0x10000000,

		/// <summary>
		/// <para>
		/// No change notifications should be received from this source. Normally set if, and only if, the source server is in a
		/// different site.
		/// </para>
		/// </summary>
		DS_REPL_NBR_NO_CHANGE_NOTIFICATIONS = 0x20000000,

		/// <summary>
		/// <para>
		/// This neighbor is in a state where it is rebuilding the contents of this replica because of a change in the partial attribute set.
		/// </para>
		/// </summary>
		DS_REPL_NBR_PARTIAL_ATTRIBUTE_SET = 0x40000000,
	}

	/// <summary>Passes additional data used to process the request.</summary>
	[PInvokeData("ntdsapi.h", MSDNShortId = "2608adde-4f18-4048-a96f-d736ff09cd4b")]
	[Flags]
	public enum DsReplSyncAllFlags
	{
		/// <summary>This option has no effect.</summary>
		DS_REPSYNCALL_NO_OPTIONS = 0x00000000,

		/// <summary>
		/// Generates a fatal error if any server cannot be contacted or if any server is unreachable due to a disconnected or broken topology.
		/// </summary>
		DS_REPSYNCALL_ABORT_IF_SERVER_UNAVAILABLE = 0x00000001,

		/// <summary>Disables transitive replication. Synchronization is performed only with adjacent servers.</summary>
		DS_REPSYNCALL_SYNC_ADJACENT_SERVERS_ONLY = 0x00000002,

		/// <summary>In the event of a non-fatal error, returns server distinguished names (DN) instead of their GUID DNS names.</summary>
		DS_REPSYNCALL_ID_SERVERS_BY_DN = 0x00000004,

		/// <summary>
		/// Disables all synchronization. The topology is still analyzed, and unavailable or unreachable servers are still identified.
		/// </summary>
		DS_REPSYNCALL_DO_NOT_SYNC = 0x00000008,

		/// <summary>
		/// Assumes that all servers are responding. This speeds operation of the DsReplicaSyncAll function, but if some servers are not
		/// responding, some transitive replications may be blocked.
		/// </summary>
		DS_REPSYNCALL_SKIP_INITIAL_CHECK = 0x00000010,

		/// <summary>
		/// Pushes changes from the home server out to all partners using transitive replication. This reverses the direction of
		/// replication, and the order of execution of the replication sets from the usual "pulling" mode of execution.
		/// </summary>
		DS_REPSYNCALL_PUSH_CHANGES_OUTWARD = 0x00000020,

		/// <summary>
		/// Synchronizes across site boundaries. By default, DsReplicaSyncAll attempts to synchronize only with DCs in the same site as
		/// the home system. Set this flag to attempt to synchronize with all DCs in the enterprise forest. However, the DCs can be
		/// synchronized only if connected by a synchronous (RPC) transport.
		/// </summary>
		DS_REPSYNCALL_CROSS_SITE_BOUNDARIES = 0x00000040,
	}

	/// <summary>These flag values are used both as input to DsReplicaSync and as output from DsReplicaGetInfo, PENDING_OPS, DS_REPL_OPW.ulOptions</summary>
	[PInvokeData("ntdsapi.h", MSDNShortId = "20c7f96d-f298-4321-a6f5-910c25e418db")]
	[Flags]
	public enum DsReplSyncOptions
	{
		/// <summary>
		/// Performs this operation asynchronously.
		/// <para>
		/// Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista and Windows Server 2003: Required when using DS_REPSYNC_ALL_SOURCES.
		/// </para>
		/// </summary>
		DS_REPSYNC_ASYNCHRONOUS_OPERATION = 0x00000001,

		/// <summary>Replica is writable. Otherwise, it is read-only.</summary>
		DS_REPSYNC_WRITEABLE = 0x00000002,

		/// <summary>Indicates this operation is a periodic synchronization request as scheduled by the administrator.</summary>
		DS_REPSYNC_PERIODIC = 0x00000004,

		/// <summary>Synchronizes using an ISM.</summary>
		DS_REPSYNC_INTERSITE_MESSAGING = 0x00000008,

		/// <summary>Synchronizes starting from the first Update Sequence Number (USN).</summary>
		DS_REPSYNC_FULL = 0x00000020,

		/// <summary>Indicates this operation is a notification of an update marked urgent.</summary>
		DS_REPSYNC_URGENT = 0x00000040,

		/// <summary>Does not discard this synchronization request, even if a similar synchronization is pending.</summary>
		DS_REPSYNC_NO_DISCARD = 0x00000080,

		/// <summary>Synchronizes even if the link is currently disabled.</summary>
		DS_REPSYNC_FORCE = 0x00000100,

		/// <summary>
		/// Causes the source directory system agent (DSA) to verify that the local DSA is present in the source replicates-to list. If
		/// not, the local DSA is added. This ensures that the source sends change notifications.
		/// </summary>
		DS_REPSYNC_ADD_REFERENCE = 0x00000200,

		/// <summary>A sync from this source has never completed (e.g., a new source).</summary>
		DS_REPSYNC_NEVER_COMPLETED = 0x00000400,

		/// <summary>When this sync is complete, requests a sync in the opposite direction.</summary>
		DS_REPSYNC_TWO_WAY = 0x00000800,

		/// <summary>Do not request change notifications from this source.</summary>
		DS_REPSYNC_NEVER_NOTIFY = 0x00001000,

		/// <summary>Sync the NC from this source when the DSA is started.</summary>
		DS_REPSYNC_INITIAL = 0x00002000,

		/// <summary>
		/// Use compression when replicating. Saves message size (e.g., network bandwidth) at the expense of extra CPU overhead at both
		/// the source and destination servers.
		/// </summary>
		DS_REPSYNC_USE_COMPRESSION = 0x00004000,

		/// <summary>Sync was abandoned for lack of updates (W2K, W2K3)</summary>
		DS_REPSYNC_ABANDONED = 0x00008000,

		/// <summary>Special secret processing</summary>
		DS_REPSYNC_SELECT_SECRETS = 0x00008000,

		/// <summary>Initial sync in progress</summary>
		DS_REPSYNC_INITIAL_IN_PROGRESS = 0x00010000,

		/// <summary>Partial Attribute Set sync in progress</summary>
		DS_REPSYNC_PARTIAL_ATTRIBUTE_SET = 0x00020000,

		/// <summary>Sync is being retried</summary>
		DS_REPSYNC_REQUEUE = 0x00040000,

		/// <summary>Sync is a notification request from a source</summary>
		DS_REPSYNC_NOTIFICATION = 0x00080000,

		/// <summary>Sync is a special form which requests to establish contact now and do the rest of the sync later</summary>
		DS_REPSYNC_ASYNCHRONOUS_REPLICA = 0x00100000,

		/// <summary>Request critical objects only</summary>
		DS_REPSYNC_CRITICAL = 0x00200000,

		/// <summary>A full synchronization is in progress</summary>
		DS_REPSYNC_FULL_IN_PROGRESS = 0x00400000,

		/// <summary>Synchronization request was previously preempted</summary>
		DS_REPSYNC_PREEMPTED = 0x00800000,

		/// <summary>Non GC readonly replica</summary>
		DS_REPSYNC_NONGC_RO_REPLICA = 0x01000000,
	}

	/// <summary>Contains a set of flags that provide additional data used to process the request.</summary>
	[PInvokeData("ntdsapi.h", MSDNShortId = "158c7e73-0e6c-4b71-a87f-2f60f3db91cb")]
	[Flags]
	public enum DsReplUpdateOptions
	{
		/// <summary>The operation is performed asynchronously.</summary>
		DS_REPUPD_ASYNCHRONOUS_OPERATION = 0x00000001,

		/// <summary>The reference to the replica added or removed is writable. Otherwise, it is read-only.</summary>
		DS_REPUPD_WRITEABLE = 0x00000002,

		/// <summary>A reference to the destination is added to the source server.</summary>
		DS_REPUPD_ADD_REFERENCE = 0x00000004,

		/// <summary>A reference to the destination is removed from the source server.</summary>
		DS_REPUPD_DELETE_REFERENCE = 0x00000008,

		/// <summary>Use GCSPN while notifying replica partner</summary>
		DS_REPUPD_REFERENCE_GCSPN = 0x00000010,
	}

	/// <summary>Contains a set of flags that modify the behavior of the function.</summary>
	[PInvokeData("ntdsapi.h", MSDNShortId = "d0e139dc-6aaf-47e1-a76f-4e84f17aa7c6")]
	[Flags]
	public enum DsReplVerifyOptions
	{
		/// <summary>Do not delete objects in response to this function.</summary>
		DS_EXIST_ADVISORY_MODE = 0x1,
	}

	/// <summary>Indicates the type of GUID mapped by DsMapSchemaGuids.</summary>
	[PInvokeData("ntdsapi.h")]
	public enum DsSchemaGuidType
	{
		/// <summary>The GUID cannot be found in the directory service schema.</summary>
		DS_SCHEMA_GUID_NOT_FOUND = 0,

		/// <summary>The GUID identifies a property.</summary>
		DS_SCHEMA_GUID_ATTR = 1,

		/// <summary>The GUID identifies a property set.</summary>
		DS_SCHEMA_GUID_ATTR_SET = 2,

		/// <summary>The GUID identifies a type of object.</summary>
		DS_SCHEMA_GUID_CLASS = 3,

		/// <summary>The GUID identifies an extended access right.</summary>
		DS_SCHEMA_GUID_CONTROL_RIGHT = 4,
	}

	/// <summary>Defines the type of schedule data that is contained in the <see cref="SCHEDULE_HEADER"/> structure.</summary>
	[PInvokeData("schedule.h", MSDNShortId = "5453927e-306e-4442-a855-916005dc8e3b")]
	public enum ScheduleType
	{
		/// <summary>
		/// <para>
		/// The schedule contains a set of intervals. The <c>Offset</c> member contains the offset to an array of bytes with
		/// <c>SCHEDULE_DATA_ENTRIES</c> elements. Each byte in the array represents an hour of the week. The first hour is 00:00 on
		/// Sunday morning GMT.
		/// </para>
		/// <para>
		/// Each bit of the lower four bits of each byte represents a 15 minute block within the hour that the source is available for
		/// replication. The following list lists the binary values and describes each bit of the lower four bits of the hour value.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Binary value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>1000</term>
		/// <term>The source is available for replication from 0 to 14 minutes after the hour.</term>
		/// </item>
		/// <item>
		/// <term>0100</term>
		/// <term>The source is available for replication from 15 to 29 minutes after the hour.</term>
		/// </item>
		/// <item>
		/// <term>0010</term>
		/// <term>The source is available for replication from 30 to 44 minutes after the hour.</term>
		/// </item>
		/// <item>
		/// <term>0001</term>
		/// <term>The source is available for replication from 45 to 59 minutes after the hour.</term>
		/// </item>
		/// </list>
		/// <para>
		/// These bits can be combined to create multiple 15 minute blocks that the source is available. For example, a binary value of
		/// 0111 indicates that the source is available from 0 to 44 minutes after the hour.
		/// </para>
		/// <para>The upper fours bits of each byte are not used.</para>
		/// </summary>
		SCHEDULE_INTERVAL = 0,

		/// <summary>Not supported.</summary>
		SCHEDULE_BANDWIDTH = 1,

		/// <summary>Not supported.</summary>
		SCHEDULE_PRIORITY = 2,
	}

	/// <summary>
	/// <para>
	/// The <c>DsAddSidHistory</c> function retrieves the primary account security identifier (SID) of a security principal from one
	/// domain and adds it to the <c>sIDHistory</c> attribute of a security principal in another domain in a different forest. When the
	/// source domain is in Windows 2000 native mode, this function also retrieves the <c>sIDHistory</c> values of the source principal
	/// and adds them to the destination principal <c>sIDHistory</c>.
	/// </para>
	/// <para>
	/// The <c>DsAddSidHistory</c> function performs a security-sensitive function by adding the primary account SID of an existing
	/// security principal to the <c>sIDHistory</c> of a principal in a domain in a different forest, effectively granting to the latter
	/// access to all resources accessible to the former. For more information about the use and security implications of this function,
	/// see Using DsAddSidHistory.
	/// </para>
	/// </summary>
	/// <param name="hDS">Contains a directory service handle obtained from either the DSBind or DSBindWithCred function.</param>
	/// <param name="Flags">Reserved for future use. Set to <c>NULL</c>.</param>
	/// <param name="SrcDomain"><para>Pointer to a null-terminated string that specifies the name of the domain to query for the SID of SrcPrincipal.</para>
	/// <para>
	/// If the source domain runs on Windows Server operating systems, SrcDomain can be either a domain name system (DNS) name, for
	/// example, fabrikam.com, or a flat NetBIOS, for example, Fabrikam, name. DNS names should be used when possible.
	/// </para></param>
	/// <param name="SrcPrincipal">Pointer to a null-terminated string that specifies the name of a security principal, user or group, in the source domain. This
	/// name is a domain-relative Security Account Manager (SAM) name, for example: evacorets.</param>
	/// <param name="SrcDomainController"><para>
	/// Pointer to a null-terminated string that specifies the name of the primary domain controller (PDC) Emulator in the source domain
	/// to use for secure retrieval of the source principal SID and audit generation.
	/// </para>
	/// <para>If this parameter is <c>NULL</c>, DSBindWithCred will select the primary domain controller.</para>
	/// <para>SrcDomainController can be either a DNS name or a flat NetBIOS name. DNS names should be used when possible.</para></param>
	/// <param name="SrcDomainCreds"><para>
	/// Contains an identity handle that represents the identity and credentials of a user with administrative rights in the source
	/// domain. To obtain this handle, call DsMakePasswordCredentials. This user must be a member of either the Administrators or the
	/// Domain Administrators group. If this call is made from a remote computer to the destination DC, then both the remote computer and
	/// the destination DC must support 128-bit encryption to privacy-protect the credentials. If 128-bit encryption is unavailable and
	/// SrcDomainCreds are provided, then the call must be made on the destination DC.
	/// </para>
	/// <para>If this parameter is <c>NULL</c>, the credentials of the caller are used for access to the source domain.</para></param>
	/// <param name="DstDomain">Pointer to a null-terminated string that specifies the name of the destination domain in which DstPrincipal resides. This name
	/// can either be a DNS name, for example, fabrikam.com, or a NetBIOS name, for example, Fabrikam. The destination domain must run
	/// Windows 2000 native mode.</param>
	/// <param name="DstPrincipal">Pointer to a null-terminated string that specifies the name of a security principal, user or group, in the destination domain.
	/// This domain-relative SAM name identifies the principal whose <c>sIDHistory</c> attribute is updated with the SID of the SrcPrincipal.</param>
	/// <returns>Returns a Win32 error codes including the following.</returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/nf-ntdsapi-dsaddsidhistorya NTDSAPI DWORD DsAddSidHistoryA( HANDLE
	// hDS, DWORD Flags, LPCSTR SrcDomain, LPCSTR SrcPrincipal, LPCSTR SrcDomainController, RPC_AUTH_IDENTITY_HANDLE SrcDomainCreds,
	// LPCSTR DstDomain, LPCSTR DstPrincipal );
	[DllImport(Lib.NTDSApi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("ntdsapi.h", MSDNShortId = "36ef8734-717a-4c3a-a839-6591d85c9734")]
	public static extern Win32Error DsAddSidHistory(SafeDsHandle hDS, uint Flags, string SrcDomain, string SrcPrincipal, string SrcDomainController, SafeAuthIdentityHandle SrcDomainCreds,
		string DstDomain, string DstPrincipal);

	/// <summary>
	/// The <c>DsBind</c> function binds to a domain controller. <c>DsBind</c> uses the default process credentials to bind to the domain
	/// controller. To specify alternate credentials, use the DsBindWithCred function.
	/// </summary>
	/// <param name="DomainControllerName">
	/// <para>
	/// Pointer to a null-terminated string that contains the name of the domain controller to bind to. This name can be the name of the
	/// domain controller or the fully qualified DNS name of the domain controller. Either name type can, optionally, be preceded by two
	/// backslash characters. All of the following examples represent correctly formatted domain controller names:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <description>"FAB-DC-01"</description>
	/// </item>
	/// <item>
	/// <description>"\\FAB-DC-01"</description>
	/// </item>
	/// <item>
	/// <description>"FAB-DC-01.fabrikam.com"</description>
	/// </item>
	/// <item>
	/// <description>"\\FAB-DC-01.fabrikam.com"</description>
	/// </item>
	/// </list>
	/// <para>This parameter can be <c>NULL</c>. For more information, see Remarks.</para>
	/// </param>
	/// <param name="DnsDomainName">
	/// Pointer to a null-terminated string that contains the fully qualified DNS name of the domain to bind to. This parameter can be
	/// <c>NULL</c>. For more information, see Remarks.
	/// </param>
	/// <param name="phDS">
	/// Address of a <c>HANDLE</c> value that receives the binding handle. To close this handle, pass it to the DsUnBind function.
	/// </param>
	/// <returns>
	/// Returns <c>ERROR_SUCCESS</c> if successful or a Windows or RPC error code otherwise. The following are the most common error codes.
	/// </returns>
	/// <remarks>
	/// <para>
	/// The behavior of the <c>DsBind</c> function is determined by the contents of the <c>DomainControllerName</c> and <c>DnsDomainName</c>
	/// parameters. The following list describes the behavior of this function based on the contents of these parameters.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <description><c>DomainControllerName</c></description>
	/// <description><c>DnsDomainName</c></description>
	/// <description>Description</description>
	/// </listheader>
	/// <item>
	/// <description><c>NULL</c></description>
	/// <description><c>NULL</c></description>
	/// <description><c>DsBind</c> will attempt to bind to a global catalog server in the forest of the local computer.</description>
	/// </item>
	/// <item>
	/// <description>(value)</description>
	/// <description><c>NULL</c></description>
	/// <description><c>DsBind</c> will attempt to bind to the domain controller specified by the <c>DomainControllerName</c> parameter.</description>
	/// </item>
	/// <item>
	/// <description><c>NULL</c></description>
	/// <description>(value)</description>
	/// <description><c>DsBind</c> will attempt to bind to any domain controller in the domain specified by <c>DnsDomainName</c> parameter.</description>
	/// </item>
	/// <item>
	/// <description>(value)</description>
	/// <description>(value)</description>
	/// <description>
	/// The <c>DomainControllerName</c> parameter takes precedence. <c>DsBind</c> will attempt to bind to the domain controller specified by
	/// the <c>DomainControllerName</c> parameter.
	/// </description>
	/// </item>
	/// </list>
	/// <note type="note">The ntdsapi.h header defines DsBind as an alias which automatically selects the ANSI or Unicode version of this
	/// function based on the definition of the UNICODE preprocessor constant. Mixing usage of the encoding-neutral alias with code that not
	/// encoding-neutral can lead to mismatches that result in compilation or runtime errors. For more information, see Conventions for
	/// Function Prototypes.</note>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/ntdsapi/nf-ntdsapi-dsbinda
	// NTDSAPI DWORD DsBindA( [in, optional] LPCSTR DomainControllerName, [in, optional] LPCSTR DnsDomainName, [out] HANDLE *phDS );
	[PInvokeData("ntdsapi.h", MSDNShortId = "NF:ntdsapi.DsBindA")]
	[DllImport(Lib.NTDSApi, CharSet = CharSet.Auto, SetLastError = true)]
	public static extern Win32Error DsBind([Optional] string? DomainControllerName, [Optional] string? DnsDomainName, out SafeDsHandle phDS);

	/// <summary>
	/// The <c>DsBindByInstance</c> function explicitly binds to any AD LDS or Active Directory instance.
	/// </summary>
	/// <param name="ServerName">Pointer to a null-terminated string that specifies the name of the instance. This parameter is required to bind to an AD LDS
	/// instance. If this parameter is <c>NULL</c> when binding to an Active Directory instance, then the DnsDomainName parameter must
	/// contain a value. If this parameter and the DnsDomainName parameter are both <c>NULL</c>, the function fails with the return value
	/// <c>ERROR_INVALID_PARAMETER</c> (87).</param>
	/// <param name="Annotation"><para>
	/// Pointer to a null-terminated string that specifies the port number of the AD LDS instance or <c>NULL</c> when binding to an
	/// Active Directory instance. For example, "389".
	/// </para>
	/// <para>
	/// If this parameter is <c>NULL</c> when binding by domain to an Active Directory instance, then the DnsDomainName parameter must be
	/// specified. If this parameter is <c>NULL</c> when binding to an AD LDS instance, then the InstanceGuid parameter must be specified.
	/// </para></param>
	/// <param name="InstanceGuid">Pointer to a <c>GUID</c> value that contains the <c>GUID</c> of the AD LDS instance. The <c>GUID</c> value is the
	/// <c>objectGUID</c> property of the <c>nTDSDSA</c> object of the instance. If this parameter is <c>NULL</c> when binding to an AD
	/// LDS instance, the Annotation parameter must be specified.</param>
	/// <param name="DnsDomainName">Pointer to a null-terminated string that specifies the DNS name of the domain when binding to an Active Directory instance by
	/// domain. Set this parameter to <c>NULL</c> to bind to an Active Directory instance by server or to an AD LDS instance.</param>
	/// <param name="AuthIdentity">Handle to the credentials used to start the RPC session. Use the DsMakePasswordCredentials function to create a structure
	/// suitable for AuthIdentity.</param>
	/// <param name="ServicePrincipalName">Pointer to a null-terminated string that specifies the Service Principal Name to assign to the client. Passing <c>NULL</c> in
	/// ServicePrincipalName is equivalent to a call to the DsBindWithCred function.</param>
	/// <param name="BindFlags"><para>
	/// Contains a set of flags that define the behavior of this function. This parameter can contain zero or a combination of one or
	/// more of the following values.
	/// </para>
	/// <para>NTDSAPI_BIND_ALLOW_DELEGATION (1)</para>
	/// <para>
	/// Causes the bind to use the delegate impersonation level. This enables operations that require delegation, such as
	/// DsAddSidHistory, to succeed. Specifying this flag also causes DsBindWithSpnEx to operate similar to DsBindWithSpn.
	/// </para>
	/// <para>
	/// If this flag is not specified, the bind will use the impersonate impersonation level. For more information about impersonation
	/// levels, see Impersonation Levels.
	/// </para>
	/// <para>
	/// Most operations do not require the delegate impersonation level; this flag should only be specified if it is required. Binding to
	/// a rogue server with the delegate impersonation level enables the rogue server to connect to a non-rogue server with your
	/// credentials and perform unintended operations.
	/// </para>
	/// <para>NTDSAPI_BIND_FORCE_KERBEROS (4)</para>
	/// <para>
	///   <c>Active Directory Lightweight Directory Services:</c> If this flag is specified, DsBindWithSpnEx requires Kerberos
	/// authentication to be used. If Kerberos authentication cannot be established, <c>DsBindWithSpnEx</c> will not attempt to
	/// authenticate with any other mechanism.
	/// </para></param>
	/// <param name="phDS">Address of a <c>HANDLE</c> value that receives the bind handle. To close this handle, call DsUnBind.</param>
	/// <returns>
	/// Returns <c>NO_ERROR</c> if successful or an RPC or Win32 error otherwise. Possible error codes include those listed in the
	/// following list.
	/// </returns>
	/// <remarks>
	/// <para>The following list lists the required parameter values for binding to an instance.</para>
	/// <list type="table">
	///   <listheader>
	///     <term>Instance</term>
	///     <term>ServerName</term>
	///     <term>Annotation</term>
	///     <term>InstanceGuid</term>
	///     <term>DnsDomainName</term>
	///   </listheader>
	///   <item>
	///     <term>Active Directory by server</term>
	///     <term>Server Name</term>
	///     <term>NULL</term>
	///     <term>NULL</term>
	///     <term>NULL</term>
	///   </item>
	///   <item>
	///     <term>Active Directory by domain</term>
	///     <term>NULL</term>
	///     <term>NULL</term>
	///     <term>NULL</term>
	///     <term>DNS domain name</term>
	///   </item>
	///   <item>
	///     <term>AD LDS by port</term>
	///     <term>DNS Name of the computer with the AD LDS installation.</term>
	///     <term>Port Number</term>
	///     <term>NULL</term>
	///     <term>NULL</term>
	///   </item>
	///   <item>
	///     <term>AD LDS by GUID</term>
	///     <term>DNS Name of the computer with the AD LDS installation.</term>
	///     <term>NULL</term>
	///     <term>Instance GUID</term>
	///     <term>NULL</term>
	///   </item>
	/// </list>
	/// <para>
	///   <c>Note</c> For improved performance when binding to an AD LDS instance on a computer with several instances of AD LDS, bind by
	/// the Instance <c>GUID</c> instead of the port number.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/nf-ntdsapi-dsbindbyinstancea NTDSAPI_POSTXP DWORD DsBindByInstanceA(
	// LPCSTR ServerName, LPCSTR Annotation, GUID *InstanceGuid, LPCSTR DnsDomainName, RPC_AUTH_IDENTITY_HANDLE AuthIdentity, LPCSTR
	// ServicePrincipalName, DWORD BindFlags, HANDLE *phDS );
	[PInvokeData("ntdsapi.h", MSDNShortId = "65302ddc-2bc0-4d80-b028-e268859be227")]
	[DllImport(Lib.NTDSApi, CharSet = CharSet.Auto, EntryPoint = "DsBindByInstance", SetLastError = false, ThrowOnUnmappableChar = true), SuppressUnmanagedCodeSecurity]
	public static extern Win32Error DsBindByInstance([Optional] string? ServerName, [Optional] string? Annotation, in Guid InstanceGuid, [Optional] string? DnsDomainName,
		SafeAuthIdentityHandle AuthIdentity, [Optional] string? ServicePrincipalName, [Optional] DsBindFlags BindFlags, out SafeDsHandle phDS);

	/// <summary>
	/// The <c>DsBindByInstance</c> function explicitly binds to any AD LDS or Active Directory instance.
	/// </summary>
	/// <param name="ServerName">Pointer to a null-terminated string that specifies the name of the instance. This parameter is required to bind to an AD LDS
	/// instance. If this parameter is <c>NULL</c> when binding to an Active Directory instance, then the DnsDomainName parameter must
	/// contain a value. If this parameter and the DnsDomainName parameter are both <c>NULL</c>, the function fails with the return value
	/// <c>ERROR_INVALID_PARAMETER</c> (87).</param>
	/// <param name="Annotation"><para>
	/// Pointer to a null-terminated string that specifies the port number of the AD LDS instance or <c>NULL</c> when binding to an
	/// Active Directory instance. For example, "389".
	/// </para>
	/// <para>
	/// If this parameter is <c>NULL</c> when binding by domain to an Active Directory instance, then the DnsDomainName parameter must be
	/// specified. If this parameter is <c>NULL</c> when binding to an AD LDS instance, then the InstanceGuid parameter must be specified.
	/// </para></param>
	/// <param name="InstanceGuid">Pointer to a <c>GUID</c> value that contains the <c>GUID</c> of the AD LDS instance. The <c>GUID</c> value is the
	/// <c>objectGUID</c> property of the <c>nTDSDSA</c> object of the instance. If this parameter is <c>NULL</c> when binding to an AD
	/// LDS instance, the Annotation parameter must be specified.</param>
	/// <param name="DnsDomainName">Pointer to a null-terminated string that specifies the DNS name of the domain when binding to an Active Directory instance by
	/// domain. Set this parameter to <c>NULL</c> to bind to an Active Directory instance by server or to an AD LDS instance.</param>
	/// <param name="AuthIdentity">Handle to the credentials used to start the RPC session. Use the DsMakePasswordCredentials function to create a structure
	/// suitable for AuthIdentity.</param>
	/// <param name="ServicePrincipalName">Pointer to a null-terminated string that specifies the Service Principal Name to assign to the client. Passing <c>NULL</c> in
	/// ServicePrincipalName is equivalent to a call to the DsBindWithCred function.</param>
	/// <param name="BindFlags"><para>
	/// Contains a set of flags that define the behavior of this function. This parameter can contain zero or a combination of one or
	/// more of the following values.
	/// </para>
	/// <para>NTDSAPI_BIND_ALLOW_DELEGATION (1)</para>
	/// <para>
	/// Causes the bind to use the delegate impersonation level. This enables operations that require delegation, such as
	/// DsAddSidHistory, to succeed. Specifying this flag also causes DsBindWithSpnEx to operate similar to DsBindWithSpn.
	/// </para>
	/// <para>
	/// If this flag is not specified, the bind will use the impersonate impersonation level. For more information about impersonation
	/// levels, see Impersonation Levels.
	/// </para>
	/// <para>
	/// Most operations do not require the delegate impersonation level; this flag should only be specified if it is required. Binding to
	/// a rogue server with the delegate impersonation level enables the rogue server to connect to a non-rogue server with your
	/// credentials and perform unintended operations.
	/// </para>
	/// <para>NTDSAPI_BIND_FORCE_KERBEROS (4)</para>
	/// <para>
	///   <c>Active Directory Lightweight Directory Services:</c> If this flag is specified, DsBindWithSpnEx requires Kerberos
	/// authentication to be used. If Kerberos authentication cannot be established, <c>DsBindWithSpnEx</c> will not attempt to
	/// authenticate with any other mechanism.
	/// </para></param>
	/// <param name="phDS">Address of a <c>HANDLE</c> value that receives the bind handle. To close this handle, call DsUnBind.</param>
	/// <returns>
	/// Returns <c>NO_ERROR</c> if successful or an RPC or Win32 error otherwise. Possible error codes include those listed in the
	/// following list.
	/// </returns>
	/// <remarks>
	/// <para>The following list lists the required parameter values for binding to an instance.</para>
	/// <list type="table">
	///   <listheader>
	///     <term>Instance</term>
	///     <term>ServerName</term>
	///     <term>Annotation</term>
	///     <term>InstanceGuid</term>
	///     <term>DnsDomainName</term>
	///   </listheader>
	///   <item>
	///     <term>Active Directory by server</term>
	///     <term>Server Name</term>
	///     <term>NULL</term>
	///     <term>NULL</term>
	///     <term>NULL</term>
	///   </item>
	///   <item>
	///     <term>Active Directory by domain</term>
	///     <term>NULL</term>
	///     <term>NULL</term>
	///     <term>NULL</term>
	///     <term>DNS domain name</term>
	///   </item>
	///   <item>
	///     <term>AD LDS by port</term>
	///     <term>DNS Name of the computer with the AD LDS installation.</term>
	///     <term>Port Number</term>
	///     <term>NULL</term>
	///     <term>NULL</term>
	///   </item>
	///   <item>
	///     <term>AD LDS by GUID</term>
	///     <term>DNS Name of the computer with the AD LDS installation.</term>
	///     <term>NULL</term>
	///     <term>Instance GUID</term>
	///     <term>NULL</term>
	///   </item>
	/// </list>
	/// <para>
	///   <c>Note</c> For improved performance when binding to an AD LDS instance on a computer with several instances of AD LDS, bind by
	/// the Instance <c>GUID</c> instead of the port number.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/nf-ntdsapi-dsbindbyinstancea NTDSAPI_POSTXP DWORD DsBindByInstanceA(
	// LPCSTR ServerName, LPCSTR Annotation, GUID *InstanceGuid, LPCSTR DnsDomainName, RPC_AUTH_IDENTITY_HANDLE AuthIdentity, LPCSTR
	// ServicePrincipalName, DWORD BindFlags, HANDLE *phDS );
	[PInvokeData("ntdsapi.h", MSDNShortId = "65302ddc-2bc0-4d80-b028-e268859be227")]
	[DllImport(Lib.NTDSApi, CharSet = CharSet.Auto, EntryPoint = "DsBindByInstance", SetLastError = false, ThrowOnUnmappableChar = true), SuppressUnmanagedCodeSecurity]
	public static extern Win32Error DsBindByInstance([Optional] string? ServerName, [Optional] string? Annotation, [Optional] IntPtr InstanceGuid, [Optional] string? DnsDomainName,
		SafeAuthIdentityHandle AuthIdentity, [Optional] string? ServicePrincipalName, [Optional] DsBindFlags BindFlags, out SafeDsHandle phDS);

	/// <summary>
	/// The <c>DsBindingSetTimeout</c> function sets the timeout value that is honored by all RPC calls that use the specified binding
	/// handle. RPC calls that required more time than the timeout value are canceled.
	/// </summary>
	/// <param name="hDS">Contains a directory service handle obtained from either the DSBind or DSBindWithCred function.</param>
	/// <param name="cTimeoutSecs">Contains the new timeout value, in seconds.</param>
	/// <returns>
	/// Returns <c>ERROR_SUCCESS</c> if successful or a Win32 or RPC error code otherwise. The following is a possible error code.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/nf-ntdsapi-dsbindingsettimeout NTDSAPI_POSTXP DWORD
	// DsBindingSetTimeout( HANDLE hDS, ULONG cTimeoutSecs );
	[DllImport(Lib.NTDSApi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("ntdsapi.h", MSDNShortId = "abdaae89-fba3-4949-92a9-acd62898ec24")]
	public static extern Win32Error DsBindingSetTimeout(SafeDsHandle hDS, uint cTimeoutSecs);

	/// <summary>
	/// The <c>DsBindToISTG</c> function binds to the computer that holds the Inter-Site Topology Generator (ISTG) role in the domain of
	/// the local computer.
	/// </summary>
	/// <param name="SiteName">Pointer to a null-terminated string that contains the site name used when binding. If this parameter is <c>NULL</c>, the site of
	/// the nearest domain controller is used.</param>
	/// <param name="phDS">Address of a <c>HANDLE</c> value that receives the bind handle. To close this handle, call DsUnBind.</param>
	/// <returns>
	/// Returns <c>ERROR_SUCCESS</c> if successful or a Win32 or RPC error code otherwise. The following are possible error codes.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/nf-ntdsapi-dsbindtoistga NTDSAPI_POSTXP DWORD DsBindToISTGA( LPCSTR
	// SiteName, HANDLE *phDS );
	[DllImport(Lib.NTDSApi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("ntdsapi.h", MSDNShortId = "bd53124c-8578-495d-b540-d4b4c09297c3")]
	public static extern Win32Error DsBindToISTG([Optional] string? SiteName, out SafeDsHandle phDS);

	/// <summary>
	/// The DsBindWithCred function binds to a domain controller using the specified credentials.
	/// </summary>
	/// <param name="DomainControllerName">Pointer to a null-terminated string that contains the name of the domain controller to bind to. This name can be the name of the
	/// domain controller or the fully qualified DNS name of the domain controller. Either name type can, optionally, be preceded by two
	/// backslash characters. All of the following examples represent correctly formatted domain controller names:
	/// <list type="bullet"><item><definition>"FAB-DC-01"</definition></item><item><definition>"\\FAB-DC-01"</definition></item><item><definition>"FAB-DC-01.fabrikam.com"</definition></item><item><definition>"\\FAB-DC-01.fabrikam.com"</definition></item></list><para>This parameter can be NULL. For more information, see Remarks.</para></param>
	/// <param name="DnsDomainName">Pointer to a null-terminated string that contains the fully qualified DNS name of the domain to bind to. This parameter can be
	/// NULL. For more information, see Remarks.</param>
	/// <param name="AuthIdentity">Contains an RPC_AUTH_IDENTITY_HANDLE value that represents the credentials to be used for the bind. The DsMakePasswordCredentials
	/// function is used to obtain this value. If this parameter is NULL, the credentials of the calling thread are used.
	/// <para>DsUnBind must be called before freeing this handle with the DsFreePasswordCredentials function.</para></param>
	/// <param name="phDS">Address of a HANDLE value that receives the binding handle. To close this handle, pass it to the DsUnBind function.</param>
	/// <returns>
	/// Returns ERROR_SUCCESS if successful or a Windows or RPC error code otherwise.
	/// </returns>
	[DllImport(Lib.NTDSApi, CharSet = CharSet.Auto, SetLastError = true)]
	[PInvokeData("NTDSApi.h", MSDNShortId = "ms675961")]
	public static extern Win32Error DsBindWithCred([Optional] string? DomainControllerName, [Optional] string? DnsDomainName, SafeAuthIdentityHandle AuthIdentity, out SafeDsHandle phDS);

	/// <summary>
	/// <para>
	/// The <c>DsBindWithSpn</c> function binds to a domain controller using the specified credentials and a specific service principal
	/// name (SPN) for mutual authentication.
	/// </para>
	/// <para>
	/// This function is provided for where complete control is required for mutual authentication. Do not use this function if you
	/// expect DsBind to find a server for you, because SPNs are computer-specific, and it is unlikely that the SPN you provide will
	/// match the server that <c>DsBind</c> finds for you. Providing a <c>NULL</c> ServicePrincipalName argument results in behavior that
	/// is identical to DsBindWithCred.
	/// </para>
	/// </summary>
	/// <param name="DomainControllerName">Pointer to a null-terminated string that contains the fully qualified DNS name of the domain to bind to. For more information,
	/// see the DomainControllerName description in the DsBind topic.</param>
	/// <param name="DnsDomainName">Pointer to a null-terminated string that contains the fully qualified DNS name of the domain to bind to. For more information,
	/// see the DnsDomainName description in the DsBind topic.</param>
	/// <param name="AuthIdentity"><para>Contains an RPC_AUTH_IDENTITY_HANDLE value that represents the credentials to be used for the bind. The</para>
	/// <para>
	/// DsMakePasswordCredentialsfunction is used to obtain this value. If this parameter is <c>NULL</c>, the credentials of the calling
	/// thread are used.
	/// </para>
	/// <para>DsUnBind must be called before freeing this handle with the DsFreePasswordCredentials function.</para></param>
	/// <param name="ServicePrincipalName">Pointer to a null-terminated string that specifies the Service Principal Name to assign to the client. Passing <c>NULL</c> in
	/// ServicePrincipalName is equivalent to a call to the DsBindWithCred function.</param>
	/// <param name="phDS">Address of a <c>HANDLE</c> value that receives the binding handle. To close this handle, pass it to the DsUnBind function.</param>
	/// <returns>
	/// Returns <c>ERROR_SUCCESS</c> if successful or a Windows or RPC error code otherwise. The following are the most common error codes.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/nf-ntdsapi-dsbindwithspnw NTDSAPI DWORD DsBindWithSpnW( LPCWSTR
	// DomainControllerName, LPCWSTR DnsDomainName, RPC_AUTH_IDENTITY_HANDLE AuthIdentity, LPCWSTR ServicePrincipalName, HANDLE *phDS );
	[DllImport(Lib.NTDSApi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("ntdsapi.h", MSDNShortId = "9a149654-fd94-4b0c-b712-07fb827bef2f")]
	public static extern Win32Error DsBindWithSpn([Optional] string? DomainControllerName, [Optional] string? DnsDomainName, SafeAuthIdentityHandle AuthIdentity, [Optional] string? ServicePrincipalName, out SafeDsHandle phDS);

	/// <summary>
	/// <para>
	/// The <c>DsBindWithSpnEx</c> function binds to a domain controller using the specified credentials and a specific service principal
	/// name (SPN) for mutual authentication. This function is similar to the DsBindWithSpn function except this function allows more
	/// binding options with the BindFlags parameter.
	/// </para>
	/// <para>
	/// This function is provided where complete control is required over mutual authentication. Do not use this function if you expect
	/// DsBind to find a server for you, because SPNs are computer-specific, and it is unlikely that the SPN you provide will match the
	/// server that <c>DsBind</c> finds for you. Providing a <c>NULL</c> ServicePrincipalName argument results in behavior that is
	/// identical to DsBindWithCred.
	/// </para>
	/// </summary>
	/// <param name="DomainControllerName">Pointer to a null-terminated string that contains the fully qualified DNS name of the domain to bind. For more information, see
	/// the DomainControllerName description in the DsBind topic.</param>
	/// <param name="DnsDomainName">Pointer to a null-terminated string that contains the fully qualified DNS name of the domain to bind. For more information, see
	/// the DnsDomainName description in the DsBind topic.</param>
	/// <param name="AuthIdentity"><para>Contains an RPC_AUTH_IDENTITY_HANDLE value that represents the credentials to be used for the bind. The</para>
	/// <para>
	/// DsMakePasswordCredentialsfunction is used to obtain this value. If this parameter is <c>NULL</c>, the credentials of the calling
	/// thread are used.
	/// </para>
	/// <para>DsUnBind must be called before freeing this handle with the DsFreePasswordCredentials function.</para></param>
	/// <param name="ServicePrincipalName">Pointer to a null-terminated string that specifies the Service Principal Name to assign to the client. Passing <c>NULL</c> in
	/// ServicePrincipalName is equivalent to a call to the DsBindWithCred function.</param>
	/// <param name="BindFlags"><para>
	/// Contains a set of flags that define the behavior of this function. This parameter can contain zero or a combination of the values
	/// listed in the following list.
	/// </para>
	/// <para>NTDSAPI_BIND_ALLOW_DELEGATION (1)</para>
	/// <para>
	/// Causes the bind to use the delegate impersonation level. This allows operations that require delegation, such as DsAddSidHistory,
	/// to succeed. Specifying this flag also causes <c>DsBindWithSpnEx</c> to operate like DsBindWithSpn.
	/// </para>
	/// <para>
	/// If this flag is not specified, the bind will use the impersonate impersonation level. For more information, see Impersonation Levels.
	/// </para>
	/// <para>
	/// Most operations do not require the delegate impersonation level, so this flag should only be specified if absolutely required.
	/// Binding to a rogue server with the delegate impersonation level will allow the rogue server to connect to a non-rogue server with
	/// your credentials and perform unintended operations.
	/// </para>
	/// <para>NTDSAPI_BIND_FIND_BINDING (2)</para>
	/// <para>Reserved.</para>
	/// <para>NTDSAPI_BIND_FORCE_KERBEROS (4)</para>
	/// <para>
	///   <c>Active Directory Lightweight Directory Services:</c> If this flag is specified, <c>DsBindWithSpnEx</c> forces Kerberos
	/// authentication to be used. If Kerberos authentication cannot be established, <c>DsBindWithSpnEx</c> will not attempt to
	/// authenticate with any other method.
	/// </para></param>
	/// <param name="phDS">Address of a <c>HANDLE</c> value that receives the binding handle. To close this handle, pass it to the DsUnBind function.</param>
	/// <returns>
	/// Returns <c>ERROR_SUCCESS</c> if successful or a Windows or RPC error code otherwise. The following list lists common error codes.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/nf-ntdsapi-dsbindwithspnexw NTDSAPI_POSTXP DWORD DsBindWithSpnExW(
	// LPCWSTR DomainControllerName, LPCWSTR DnsDomainName, RPC_AUTH_IDENTITY_HANDLE AuthIdentity, LPCWSTR ServicePrincipalName, DWORD
	// BindFlags, HANDLE *phDS );
	[DllImport(Lib.NTDSApi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("ntdsapi.h", MSDNShortId = "52a5761d-5244-4bc9-8c09-fd08f10a9fff")]
	public static extern Win32Error DsBindWithSpnEx([Optional] string? DomainControllerName, [Optional] string? DnsDomainName, SafeAuthIdentityHandle AuthIdentity, [Optional] string? ServicePrincipalName,
		DsBindFlags BindFlags, out SafeDsHandle phDS);

	/// <summary>
	/// The <c>DsClientMakeSpnForTargetServer</c> function constructs a service principal name (SPN) that identifies a specific server to
	/// use for authentication.
	/// </summary>
	/// <param name="ServiceClass">Pointer to a null-terminated string that contains the class of the service as defined by the service. This can be any string
	/// unique to the service.</param>
	/// <param name="ServiceName"><para>
	/// Pointer to a null-terminated string that contains the distinguished name service (DNS) host name. This can either be a fully
	/// qualified name or an IP address in the Internet standard format.
	/// </para>
	/// <para>
	/// Use of an IP address for ServiceName is not recommended because this can create a security issue. Before the SPN is constructed,
	/// the IP address must be translated to a computer name through DNS name resolution. It is possible for the DNS name resolution to
	/// be spoofed, replacing the intended computer name with an unauthorized computer name.
	/// </para></param>
	/// <param name="pcSpnLength">Pointer to a <c>DWORD</c> value that, on entry, contains the size of the pszSpn buffer, in characters. On output, this parameter
	/// receives the number of characters copied to the pszSpn buffer, including the terminating <c>NULL</c>.</param>
	/// <param name="pszSpn">Pointer to a string buffer that receives the SPN.</param>
	/// <returns>This function returns standard Windows error codes.</returns>
	/// <remarks>
	/// <para>When using this function, supply the service class and part of a DNS host name.</para>
	/// <para>
	/// This function is a simplified version of the DsMakeSpn function. The ServiceName is made canonical by resolving through DNS.
	/// </para>
	/// <para>GUID-based DNS names are not supported. When constructed, the simplified SPN is as follows:</para>
	/// <para>The instance name portion (second position) is always set to default. The port and referrer fields are not used.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/nf-ntdsapi-dsclientmakespnfortargetserverw NTDSAPI DWORD
	// DsClientMakeSpnForTargetServerW( LPCWSTR ServiceClass, LPCWSTR ServiceName, DWORD *pcSpnLength, PWSTR pszSpn );
	[DllImport(Lib.NTDSApi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("ntdsapi.h", MSDNShortId = "d205e7cc-4879-41a4-baa7-75e7dd177cd0")]
	public static extern Win32Error DsClientMakeSpnForTargetServer(string ServiceClass, string ServiceName, ref uint pcSpnLength, StringBuilder pszSpn);

	/// <summary>
	/// The DsCrackNames function converts an array of directory service object names from one format to another. Name conversion enables
	/// client applications to map between the multiple names used to identify various directory service objects. For example, user
	/// objects can be identified by SAM account names (Domain\UserName), user principal name (UserName@Domain.com), or distinguished
	/// name. <note type="note">This function uses many handles and memory allocations that can be unwieldy. It is recommended to use the
	/// <see cref="DsCrackNames(SafeDsHandle, string[], DS_NAME_FORMAT, DS_NAME_FORMAT, DS_NAME_FLAGS)" /> method instead.</note>
	/// </summary>
	/// <param name="hSafeDs">Contains a directory service handle obtained from either the DSBind or DSBindWithCred function. If flags contains
	/// DS_NAME_FLAG_SYNTACTICAL_ONLY, hDS can be NULL.</param>
	/// <param name="flags">Contains one or more of the DS_NAME_FLAGS values used to determine how the name syntax will be cracked.</param>
	/// <param name="formatOffered">Contains one of the DS_NAME_FORMAT values that identifies the format of the input names.</param>
	/// <param name="formatDesired">Contains one of the DS_NAME_FORMAT values that identifies the format of the output names. The DS_SID_OR_SID_HISTORY_NAME value is
	/// not supported.</param>
	/// <param name="cNames">Contains the number of elements in the rpNames array.</param>
	/// <param name="rpNames">Pointer to an array of pointers to null-terminated strings that contain names to be converted.</param>
	/// <param name="ppResult">Pointer to a PDS_NAME_RESULT value that receives a DS_NAME_RESULT structure that contains the converted names. The caller must
	/// free this memory, when it is no longer required, by calling DsFreeNameResult.</param>
	/// <returns>
	/// Returns a Win32 error value, an RPC error value, or one of the following.
	/// </returns>
	[DllImport(Lib.NTDSApi, CharSet = CharSet.Auto, SetLastError = true)]
	[PInvokeData("NTDSApi.h", MSDNShortId = "ms675970")]
	public static extern Win32Error DsCrackNames(SafeDsHandle hSafeDs, DS_NAME_FLAGS flags, DS_NAME_FORMAT formatOffered, DS_NAME_FORMAT formatDesired, uint cNames,
		[In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPTStr, SizeParamIndex = 4)] string[] rpNames, out SafeDsNameResult ppResult);

	/// <summary>A wrapper function for the DsCrackNames OS call</summary>
	/// <param name="hSafeDs">Contains a directory service handle obtained from either the DSBind or DSBindWithCred function. If flags contains
	/// DS_NAME_FLAG_SYNTACTICAL_ONLY, hDS can be NULL.</param>
	/// <param name="names">The names to be converted.</param>
	/// <param name="formatDesired">Contains one of the DS_NAME_FORMAT values that identifies the format of the output names. The DS_SID_OR_SID_HISTORY_NAME value is
	/// not supported.</param>
	/// <param name="formatOffered">Contains one of the DS_NAME_FORMAT values that identifies the format of the input names.</param>
	/// <param name="flags">Contains one or m ore of the DS_NAME_FLAGS values used to determine how the name syntax will be cracked.</param>
	/// <returns>The crack results.</returns>
	[PInvokeData("NTDSApi.h", MSDNShortId = "ms675970")]
	public static DS_NAME_RESULT_ITEM[] DsCrackNames(SafeDsHandle hSafeDs, string[] names,
		DS_NAME_FORMAT formatDesired = DS_NAME_FORMAT.DS_USER_PRINCIPAL_NAME,
		DS_NAME_FORMAT formatOffered = DS_NAME_FORMAT.DS_UNKNOWN_NAME,
		DS_NAME_FLAGS flags = DS_NAME_FLAGS.DS_NAME_NO_FLAGS)
	{
		DsCrackNames(hSafeDs, flags, formatOffered, formatDesired, (uint)names.Length, names, out var pResult).ThrowIfFailed();
		return pResult.Items;
	}

	/// <summary>
	/// The <c>DsFreeDomainControllerInfo</c> function frees memory that is allocated by DsGetDomainControllerInfo for data about the
	/// domain controllers in a domain.
	/// </summary>
	/// <param name="InfoLevel"><para>
	/// Indicates what version of the <c>DS_DOMAIN_CONTROLLER_INFO</c> structure should be freed. This parameter can be one of the
	/// following values.
	/// </para>
	/// <para>1</para>
	/// <para>The function frees the structure that contains DS_DOMAIN_CONTROLLER_INFO_1 data.</para>
	/// <para>2</para>
	/// <para>The function frees the structure that contains DS_DOMAIN_CONTROLLER_INFO_2 data.</para></param>
	/// <param name="cInfo">Indicates the number of items in pInfo.</param>
	/// <param name="pInfo">Pointer to an array of DS_DOMAIN_CONTROLLER_INFO structures to be freed.</param>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/nf-ntdsapi-dsfreedomaincontrollerinfoa NTDSAPI VOID
	// DsFreeDomainControllerInfoA( DWORD InfoLevel, DWORD cInfo, VOID *pInfo );
	[DllImport(Lib.NTDSApi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("ntdsapi.h", MSDNShortId = "1b6d3136-91e2-4653-a4b0-ae2f66a6c5a2")]
	public static extern void DsFreeDomainControllerInfo(uint InfoLevel, uint cInfo, DCInfoHandle pInfo);

	/// <summary>
	/// The DsFreeNameResult function frees the memory held by a DS_NAME_RESULT structure. Use this function to free the memory allocated
	/// by the DsCrackNames function.
	/// </summary>
	/// <param name="pResult">Pointer to the DS_NAME_RESULT structure to be freed.</param>
	[DllImport(Lib.NTDSApi, CharSet = CharSet.Auto)]
	[PInvokeData("NTDSApi.h", MSDNShortId = "ms675978")]
	public static extern void DsFreeNameResult(IntPtr pResult);

	/// <summary>
	/// Frees memory allocated for a credentials structure by the DsMakePasswordCredentials function.
	/// </summary>
	/// <param name="AuthIdentity">Handle of the credential structure to be freed.</param>
	[DllImport(Lib.NTDSApi, ExactSpelling = true)]
	[PInvokeData("NTDSApi.h", MSDNShortId = "ms675979")]
	public static extern void DsFreePasswordCredentials(IntPtr AuthIdentity);

	/// <summary>
	/// The <c>DsFreeSchemaGuidMap</c> function frees memory that the DsMapSchemaGuids function has allocated for a DS_SCHEMA_GUID_MAP structure.
	/// </summary>
	/// <param name="pGuidMap">Pointer to a DS_SCHEMA_GUID_MAP structure to deallocate.</param>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/nf-ntdsapi-dsfreeschemaguidmapa NTDSAPI VOID DsFreeSchemaGuidMapA(
	// PDS_SCHEMA_GUID_MAPA pGuidMap );
	[DllImport(Lib.NTDSApi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("ntdsapi.h", MSDNShortId = "54d6acb9-5602-4996-a483-08534143bc0a")]
	public static extern void DsFreeSchemaGuidMap(IntPtr pGuidMap);

	/// <summary>
	/// The <c>DsFreeSpnArray</c> function frees an array returned from the DsGetSpn function.
	/// </summary>
	/// <param name="cSpn">Specifies the number of elements contained in rpszSpn.</param>
	/// <param name="rpszSpn">Pointer to an array returned from DsGetSpn.</param>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/nf-ntdsapi-dsfreespnarraya void DsFreeSpnArrayA( DWORD cSpn, PSTR
	// *rpszSpn );
	[DllImport(Lib.NTDSApi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("ntdsapi.h", MSDNShortId = "1c229933-432d-4ded-be3b-3bd339a0abe4")]
	public static extern void DsFreeSpnArray(uint cSpn, SpnArrayHandle rpszSpn);

	/// <summary>
	/// The <c>DsGetDomainControllerInfo</c> function retrieves data about the domain controllers in a domain.
	/// </summary>
	/// <param name="hDs">Contains a directory service handle obtained from either the DSBind or DSBindWithCred function.</param>
	/// <param name="DomainName">Pointer to a null-terminated string that specifies the domain name.</param>
	/// <param name="InfoLevel"><para>
	/// Contains a value that indicates the version of the <c>DS_DOMAIN_CONTROLLER_INFO</c> structure to return. This can be one of the
	/// following values.
	/// </para>
	/// <para>1</para>
	/// <para>The function provides the domain data in the DS_DOMAIN_CONTROLLER_INFO_1 structure format.</para>
	/// <para>2</para>
	/// <para>The function provides the domain data in the DS_DOMAIN_CONTROLLER_INFO_2 structure format.</para>
	/// <para>3</para>
	/// <para>The function provides the domain data in the DS_DOMAIN_CONTROLLER_INFO_3 structure format.</para></param>
	/// <param name="pcOut">Pointer to a <c>DWORD</c> variable that receives the number of items returned in ppInfo array.</param>
	/// <param name="ppInfo">Pointer to a pointer variable that receives an array of <c>DS_DOMAIN_CONTROLLER_INFO_*</c> structures. The type of structures in
	/// this array is defined by the InfoLevel parameter. The caller must free this array, when it is no longer required, by using the
	/// DsFreeDomainControllerInfo function.</param>
	/// <returns>
	/// <para>
	/// If the function returns domain controller data, the return value is <c>ERROR_SUCCESS</c>. If the caller does not have the
	/// privileges to access the server objects, the return value is <c>ERROR_SUCCESS</c>, but the <c>DS_DOMAIN_CONTROLLER_INFO</c>
	/// structures could be empty.
	/// </para>
	/// <para>If the function fails, the return value can be one of the following error codes.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/nf-ntdsapi-dsgetdomaincontrollerinfoa NTDSAPI DWORD
	// DsGetDomainControllerInfoA( HANDLE hDs, LPCSTR DomainName, DWORD InfoLevel, DWORD *pcOut, VOID **ppInfo );
	[DllImport(Lib.NTDSApi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("ntdsapi.h", MSDNShortId = "52db3b25-e6b0-4a0d-831b-89a203580cf1")]
	public static extern Win32Error DsGetDomainControllerInfo(SafeDsHandle hDs, string DomainName, uint InfoLevel, out uint pcOut, out DCInfoHandle ppInfo);

	/// <summary>
	/// The <c>DsGetDomainControllerInfo</c> function retrieves data about the domain controllers in a domain.
	/// </summary>
	/// <typeparam name="T">The type of the DS_DOMAIN_CONTROLLER_INFO_X structure to return.</typeparam>
	/// <param name="hDs">Contains a directory service handle obtained from either the DSBind or DSBindWithCred function.</param>
	/// <param name="DomainName">Pointer to a null-terminated string that specifies the domain name.</param>
	/// <returns>
	/// An array of <typeparamref name="T" /> returned by a call to the native <c>DsGetDomainControllerInfo</c> function.
	/// </returns>
	/// <exception cref="ArgumentException">Unable to determine level from requested type.</exception>
	public static T[] DsGetDomainControllerInfo<T>(SafeDsHandle hDs, string DomainName) where T : struct, IDsGetDCResult
	{
		uint level = 0, cout = 0;
		DCInfoHandle h = default;
		try
		{
			level = uint.Parse(typeof(T).Name.Substring(typeof(T).Name.LastIndexOf('_') + 1));
		}
		catch
		{
			throw new ArgumentException("Unable to determine level from requested type.");
		}
		try
		{
			DsGetDomainControllerInfo(hDs, DomainName, level, out cout, out h).ThrowIfFailed();
			return h.ToIEnum<T>(cout).ToArray();
		}
		finally
		{
			if (!h.IsNull)
				DsFreeDomainControllerInfo(level, cout, h);
		}
	}

	/// <summary>
	/// The <c>DsGetSpn</c> function constructs an array of one or more service principal names (SPNs). Each name in the array identifies
	/// an instance of a service. These SPNs may be registered with the directory service (DS) using the DsWriteAccountSpn function.
	/// </summary>
	/// <param name="ServiceType"><para>Identifies the format of the SPNs to compose. The ServiceType parameter can have one of the following values.</para>
	/// <para>DS_SPN_DNS_HOST, DS_SPN_DN_HOST, DS_SPN_NB_HOST</para>
	/// <para>The SPNs have the following format.</para>
	/// <para>The</para>
	/// <para>ServiceName</para>
	/// <para>parameter must be</para>
	/// <para>NULL</para>
	/// <para>. This is the SPN format for a host-based service, which provides services identified with its host computer. The</para>
	/// <para>InstancePort</para>
	/// <para>component is optional.</para>
	/// <para>DS_SPN_DOMAIN, DS_SPN_NB_DOMAIN</para>
	/// <para>The SPNs have the following format.</para>
	/// <para>The</para>
	/// <para>ServiceName</para>
	/// <para>
	/// parameter must be the DNS name or DN of a domain. This format is used for a replicable service that provides services to the
	/// specified domain.
	/// </para>
	/// <para>DS_SPN_SERVICE</para>
	/// <para>The SPNs have the following format.</para>
	/// <para>The</para>
	/// <para>ServiceName</para>
	/// <para>
	/// parameter must be a canonical DN or DNS name that identifies an instance of the service. For example, it could be a DNS name of a
	/// SRV record, or the distinguished name of the service connection point for this service instance.
	/// </para></param>
	/// <param name="ServiceClass">Pointer to a constant null-terminated string that specifies the class of the service; for example, http. Generally, this can be
	/// any string that is unique to the service.</param>
	/// <param name="ServiceName">Pointer to a constant null-terminated string that specifies the DNS name or distinguished name (DN) of the service. ServiceName
	/// is not required for a host-based service. For more information, see the description of the ServiceType parameter for the possible
	/// values of ServiceName.</param>
	/// <param name="InstancePort">Specifies the port number of the service instance. If this value is zero, the SPN does not include a port number.</param>
	/// <param name="cInstanceNames">Specifies the number of elements in the pInstanceNames and pInstancePorts arrays. If this value is zero, pInstanceNames must
	/// point to an array of cInstanceNames strings, and pInstancePorts can be either <c>NULL</c> or a pointer to an array of
	/// cInstanceNames port numbers. If this value is zero, <c>DsGetSpn</c> returns only one SPN in the prpszSpn array and pInstanceNames
	/// and pInstancePorts are ignored.</param>
	/// <param name="pInstanceNames">Pointer to an array of null-terminated strings that specify extra instance names (not used for host names). This parameter is
	/// ignored if cInstanceNames is zero. In that case, the InstanceName component of the SPN defaults to the fully qualified DNS name
	/// of the local computer or the NetBIOS name if <c>DS_SPN_NB_HOST</c> or <c>DS_SPN_NB_DOMAIN</c> is specified.</param>
	/// <param name="pInstancePorts">Pointer to an array of extra instance ports. If this value is non- <c>NULL</c>, it must point to an array of cInstanceNames port
	/// numbers. If this value is <c>NULL</c>, the SPNs do not include a port number. This parameter is ignored if cInstanceNames is zero.</param>
	/// <param name="pcSpn">Pointer to a variable that receives the number of SPNs contained in prpszSpn.</param>
	/// <param name="prpszSpn">Pointer to a variable that receives a pointer to an array of SPNs. This array must be freed with DsFreeSpnArray.</param>
	/// <returns>
	/// <para>If the function returns an array of SPNs, the return value is <c>ERROR_SUCCESS</c>.</para>
	/// <para>If the function fails, the return value can be one of the following error codes.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	///   <c>To create SPNs for multiple instances of a replicated service running on multiple host computers</c>
	/// </para>
	/// <list type="number">
	///   <item>
	///     <term>Set cInstanceNames to the number of instances.</term>
	///   </item>
	///   <item>
	///     <term>Specify the names of the host computers in the pInstanceNames array.</term>
	///   </item>
	/// </list>
	/// <para>
	///   <c>To create SPNs for multiple instances of a service running on the same host computer</c>
	/// </para>
	/// <list type="number">
	///   <item>
	///     <term>Set the cInstanceNames to the number of instances.</term>
	///   </item>
	///   <item>
	///     <term>Set each entry in the pInstanceNames array to the DNS name of the host computer.</term>
	///   </item>
	///   <item>
	///     <term>Use the pInstancePorts parameter to specify an array of unique port numbers for each instance to disambiguate the SPNs.</term>
	///   </item>
	/// </list>
	/// <para>String parameters cannot include the forward slash (/), which is used to separate the components of the SPN.</para>
	/// <para>
	/// An application with the appropriate privileges, which are usually those of a domain administrator, can call the DsWriteAccountSpn
	/// function to register one or more SPNs on the user or computer account where the service is running. Clients can then use the SPNs
	/// to authenticate the service.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/nf-ntdsapi-dsgetspna NTDSAPI DWORD DsGetSpnA( DS_SPN_NAME_TYPE
	// ServiceType, LPCSTR ServiceClass, LPCSTR ServiceName, USHORT InstancePort, USHORT cInstanceNames, LPCSTR *pInstanceNames, const
	// USHORT *pInstancePorts, DWORD *pcSpn, PSTR **prpszSpn );
	[DllImport(Lib.NTDSApi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("ntdsapi.h", MSDNShortId = "cbd53850-9b05-4f74-ab07-30dcad583fc5")]
	public static extern Win32Error DsGetSpn(DS_SPN_NAME_TYPE ServiceType, string ServiceClass, [Optional] string? ServiceName, ushort InstancePort, ushort cInstanceNames,
		[Optional] string[]? pInstanceNames, [Optional] ushort[]? pInstancePorts, ref uint pcSpn, out SpnArrayHandle prpszSpn);

	/// <summary>
	/// The <c>DsInheritSecurityIdentity</c> function appends the <c>objectSid</c> and <c>sidHistory</c> attributes of SrcPrincipal to
	/// the <c>sidHistory</c> of DstPrincipal and then deletes SrcPrincipal, all in a single transaction. To ensure that this operation
	/// is atomic, SrcPrincipal and DstPrincipal must be in the same domain and hDS must be bound to a domain controller that the correct
	/// permissions within that domain.
	/// </summary>
	/// <param name="hDS">Contains a directory service handle obtained from either the DSBind or DSBindWithCred function.</param>
	/// <param name="Flags">Reserved for future use. Must be zero.</param>
	/// <param name="SrcPrincipal">Pointer to a null-terminated string that specifies the name of a security principal (user or group) in the source domain. This
	/// name is a domain-relative SAM name.</param>
	/// <param name="DstPrincipal">Pointer to a null-terminated string that specifies the name of a security principal (user or group) in the destination domain.
	/// This domain-relative SAM name identifies the principal whose <c>sidHistory</c> attribute will be updated with the SID of SrcPrincipal.</param>
	/// <returns>Returns a system or RPC error code including the following.</returns>
	/// <remarks>
	/// <para>
	/// With an operating system upgrade domain applications, which span both upgraded and non-upgraded domains, may have security
	/// principals inside and outside the forest for the same logical entity at the same time.
	/// </para>
	/// <para>
	/// When all upgraded domains have joined the same forest, <c>DsInheritSecurityIdentity</c> eliminates the duplicate objects while
	/// ensuring that the remaining objects have all the security rights and privileges belonging to their respective deleted object.
	/// </para>
	/// <para>A <c>DsInheritSecurityIdentity</c> implementation:</para>
	/// <list type="bullet">
	///   <item>
	///     <term>Verifies that SrcPrincipal and DstPrincipal are in the same domain.</term>
	///   </item>
	///   <item>
	///     <term>Verifies that the domain is writable at the bind to the server.</term>
	///   </item>
	///   <item>
	///     <term>Verifies that auditing is enabled for the domain.</term>
	///   </item>
	///   <item>
	///     <term>Verifies that the caller is a member of the domain administrators for the domain.</term>
	///   </item>
	///   <item>
	///     <term>Verifies that the domain is in the native mode.</term>
	///   </item>
	///   <item>
	///     <term>
	/// Verifies that SrcPrincipal exists, that it is a security principal and has read its <c>objectSid</c> and <c>sidHistory</c> properties.
	/// </term>
	///   </item>
	///   <item>
	///     <term>
	/// Verifies that DstPrincipal exists, that it is a security principal, and has read certain properties required for auditing and verification.
	/// </term>
	///   </item>
	///   <item>
	///     <term>
	/// Deletes SrcPrincipal in the database only if the entire operation is committed at completion. This operation fails if the caller
	/// does not have delete rights or if SrcPrincipal has children.
	/// </term>
	///   </item>
	///   <item>
	///     <term>Fails the operation if the <c>objectSid</c> of SrcPrincipal or DstPrincipal is a well-known SID.</term>
	///   </item>
	///   <item>
	///     <term>Adds the <c>objectSid</c> and the <c>sidHistory</c> (if present) of SrcPrincipal to the <c>sidHistory</c> of DstPrincipal.</term>
	///   </item>
	///   <item>
	///     <term>Forces an audit event and fails the operation if the audit fails.</term>
	///   </item>
	///   <item>
	///     <term>Enters events into the Directory Service Log. Do not confuse this with the Security Audit Log.</term>
	///   </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/nf-ntdsapi-dsinheritsecurityidentitya NTDSAPI DWORD
	// DsInheritSecurityIdentityA( HANDLE hDS, DWORD Flags, LPCSTR SrcPrincipal, LPCSTR DstPrincipal );
	[DllImport(Lib.NTDSApi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("ntdsapi.h", MSDNShortId = "ea467069-f886-4e22-896c-16e6e01f3968")]
	public static extern Win32Error DsInheritSecurityIdentity(SafeDsHandle hDS, [Optional] uint Flags, string SrcPrincipal, string DstPrincipal);

	/// <summary>
	/// The <c>DsListDomainsInSite</c> function lists all the domains in a site.
	/// </summary>
	/// <param name="hDs">Contains a directory service handle obtained from either the DSBind or DSBindWithCred function.</param>
	/// <param name="site">Pointer to a null-terminated string that specifies the site name. This string is taken from the list of site names returned by
	/// the DsListSites function.</param>
	/// <param name="ppDomains">Pointer to a pointer to a DS_NAME_RESULT structure that receives the list of domains in the site. To free the returned structure,
	/// call the DsFreeNameResult function.</param>
	/// <returns>
	/// If the function returns a list of domains, the return value is <c>NO_ERROR</c>. If the function fails, the return value can be
	/// one of the following error codes.
	/// </returns>
	/// <remarks>
	/// Individual name conversion errors are reported in the returned DS_NAME_RESULT structure.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/nf-ntdsapi-dslistdomainsinsitea NTDSAPI DWORD DsListDomainsInSiteA(
	// HANDLE hDs, LPCSTR site, PDS_NAME_RESULTA *ppDomains );
	[DllImport(Lib.NTDSApi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("ntdsapi.h", MSDNShortId = "3a039c0c-ac5b-4455-960d-b26a207693ed")]
	public static extern Win32Error DsListDomainsInSite(SafeDsHandle hDs, string site, out SafeDsNameResult ppDomains);

	/// <summary>
	/// The <c>DsListInfoForServer</c> function lists miscellaneous data for a server.
	/// </summary>
	/// <param name="hDs">Contains a directory service handle obtained from either the DSBind or DSBindWithCred function.</param>
	/// <param name="server">Pointer to a null-terminated string that specifies the server name. This name must be the same as one of the strings returned by
	/// the DsListServersForDomainInSite or DsListServersInSite function.</param>
	/// <param name="ppInfo"><para>
	/// Pointer to a variable that receives a pointer to a DS_NAME_RESULT structure that contains the server data. The returned structure
	/// must be deallocated using DsFreeNameResult.
	/// </para>
	/// <para>
	/// The indexes of the array in the DS_NAME_RESULT structure indicate what data are contained by each array element. The following
	/// constants may be used to specify the desired index for a particular piece of data.
	/// </para>
	/// <para>DS_LIST_ACCOUNT_OBJECT_FOR_SERVER</para>
	/// <para>Name of the account object for the domain controller (DC).</para>
	/// <para>DS_LIST_DNS_HOST_NAME_FOR_SERVER</para>
	/// <para>DNS host name of the DC.</para>
	/// <para>DS_LIST_DSA_OBJECT_FOR_SERVER</para>
	/// <para>GUID of the directory service agent (DSA) for the domain controller (DC).</para></param>
	/// <returns>
	/// <para>If the function returns server data, the return value is <c>NO_ERROR</c>.</para>
	/// <para>If the function fails, the return value can be one of the following error codes.</para>
	/// </returns>
	/// <remarks>
	/// Individual name conversion errors are reported in the returned DS_NAME_RESULT structure.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/nf-ntdsapi-dslistinfoforservera NTDSAPI DWORD DsListInfoForServerA(
	// HANDLE hDs, LPCSTR server, PDS_NAME_RESULTA *ppInfo );
	[DllImport(Lib.NTDSApi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("ntdsapi.h", MSDNShortId = "15dcc7ac-4edb-42fa-8466-033794762046")]
	public static extern Win32Error DsListInfoForServer(SafeDsHandle hDs, string server, out SafeDsNameResult ppInfo);

	/// <summary>
	/// The <c>DsListRoles</c> function lists roles recognized by the server.
	/// </summary>
	/// <param name="hDs">Contains a directory service handle obtained from either the DSBind or DSBindWithCred function.</param>
	/// <param name="ppRoles"><para>
	/// Pointer to a variable that receives a pointer to a DS_NAME_RESULT structure containing the roles the server recognizes. The
	/// returned structure must be deallocated using DsFreeNameResult.
	/// </para>
	/// <para>
	/// The indexes of the array in the DS_NAME_RESULT structure indicate what data are contained by each array element. The following
	/// constants may be used to specify the desired index for a particular piece of data.
	/// </para>
	/// <para>DS_ROLE_DOMAIN_OWNER</para>
	/// <para>Server owns the domain.</para>
	/// <para>DS_ROLE_INFRASTRUCTURE_OWNER</para>
	/// <para>Server owns the infrastructure.</para>
	/// <para>DS_ROLE_PDC_OWNER</para>
	/// <para>Server owns the PDC.</para>
	/// <para>DS_ROLE_RID_OWNER</para>
	/// <para>Server owns the RID.</para>
	/// <para>DS_ROLE_SCHEMA_OWNER</para>
	/// <para>Server owns the schema.</para></param>
	/// <returns>
	/// <para>If the function returns a list of roles, the return value is <c>NO_ERROR</c>.</para>
	/// <para>If the function fails, the return value can be one of the following error codes.</para>
	/// <para>Individual name conversion errors are reported in the returned DS_NAME_RESULT structure.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/nf-ntdsapi-dslistrolesa NTDSAPI DWORD DsListRolesA( HANDLE hDs,
	// PDS_NAME_RESULTA *ppRoles );
	[DllImport(Lib.NTDSApi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("ntdsapi.h", MSDNShortId = "679a2dca-019b-4f6e-acd9-efb30e0d4b44")]
	public static extern Win32Error DsListRoles(SafeDsHandle hDs, out SafeDsNameResult ppRoles);

	/// <summary>
	/// The <c>DsListServersForDomainInSite</c> function lists all the servers in a domain in a site.
	/// </summary>
	/// <param name="hDs">Contains a directory service handle obtained from either the DSBind or DSBindWithCred function.</param>
	/// <param name="domain">Pointer to a null-terminated string that specifies the domain name. This string must be the same as one of the strings returned
	/// by DsListDomainsInSite function.</param>
	/// <param name="site">Pointer to a null-terminated string that specifies the site name. This string is taken from the list of site names returned by
	/// the DsListSites function.</param>
	/// <param name="ppServers">Pointer to a pointer to a DS_NAME_RESULT structure that receives the list of servers in the domain. The returned structure must
	/// be freed using the DsFreeNameResult function.</param>
	/// <returns>
	/// If the function returns a list of servers, the return value is <c>NO_ERROR</c>. If the function fails, the return value can be
	/// one of the following error codes.
	/// </returns>
	/// <remarks>
	/// Individual name conversion errors are reported in the returned DS_NAME_RESULT structure.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/nf-ntdsapi-dslistserversfordomaininsitea NTDSAPI DWORD
	// DsListServersForDomainInSiteA( HANDLE hDs, LPCSTR domain, LPCSTR site, PDS_NAME_RESULTA *ppServers );
	[DllImport(Lib.NTDSApi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("ntdsapi.h", MSDNShortId = "1e346532-bbbe-4b3b-a1cb-6a72319cb3e2")]
	public static extern Win32Error DsListServersForDomainInSite(SafeDsHandle hDs, string domain, string site, out SafeDsNameResult ppServers);

	/// <summary>
	/// The <c>DsListServersInSite</c> function lists all the servers in a site.
	/// </summary>
	/// <param name="hDs">Contains a directory service handle obtained from either the DSBind or DSBindWithCred function.</param>
	/// <param name="site">Pointer to a null-terminated string that specifies the site name. The site name uses a distinguished name format. It is taken
	/// from the list of sites returned by the DsListSites function.</param>
	/// <param name="ppServers">Pointer to a pointer to a DS_NAME_RESULT structure that receives the list of servers in the site. The returned structure must be
	/// freed using the DsFreeNameResult function.</param>
	/// <returns>
	/// If the function returns a list of servers, the return value is <c>NO_ERROR</c>. If the function fails, the return value can be
	/// one of the following error codes.
	/// </returns>
	/// <remarks>
	/// Individual name conversion errors are reported in the returned DS_NAME_RESULT structure.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/nf-ntdsapi-dslistserversinsitea NTDSAPI DWORD DsListServersInSiteA(
	// HANDLE hDs, LPCSTR site, PDS_NAME_RESULTA *ppServers );
	[DllImport(Lib.NTDSApi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("ntdsapi.h", MSDNShortId = "46773631-d464-4d9e-83e7-aa502599df71")]
	public static extern Win32Error DsListServersInSite(SafeDsHandle hDs, string site, out SafeDsNameResult ppServers);

	/// <summary>
	/// The <c>DsListSites</c> function lists all the sites in the enterprise forest.
	/// </summary>
	/// <param name="hDs">Contains a directory service handle obtained from either the DSBind or DSBindWithCred function.</param>
	/// <param name="ppSites">Pointer to a pointer to a DS_NAME_RESULT structure that receives the list of sites in the enterprise. The site name is returned
	/// in the distinguished name (DN) format. The returned structure must be freed using the DsFreeNameResult function.</param>
	/// <returns>
	/// If the function returns a list of sites, the return value is <c>NO_ERROR</c>. If the function fails, the return value can be one
	/// of the following error codes.
	/// </returns>
	/// <remarks>
	/// Individual name conversion errors are reported in the returned DS_NAME_RESULT structure.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/nf-ntdsapi-dslistsitesw NTDSAPI DWORD DsListSitesW( HANDLE hDs,
	// PDS_NAME_RESULTW *ppSites );
	[DllImport(Lib.NTDSApi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("ntdsapi.h", MSDNShortId = "d424e750-6700-42b8-9d4f-e430cd0a7e4e")]
	public static extern Win32Error DsListSites(SafeDsHandle hDs, out SafeDsNameResult ppSites);

	/// <summary>
	/// Constructs a credential handle suitable for use with the DsBindWithCred function.
	/// </summary>
	/// <param name="User">A string that contains the user name to use for the credentials.</param>
	/// <param name="Domain">A string that contains the domain that the user is a member of.</param>
	/// <param name="Password">A string that contains the password to use for the credentials.</param>
	/// <param name="pAuthIdentity">An RPC_AUTH_IDENTITY_HANDLE value that receives the credential handle. This handle is used in a subsequent call to
	/// DsBindWithCred. This handle must be freed with the DsFreePasswordCredentials function when it is no longer required.</param>
	/// <returns>Returns a Windows error code.</returns>
	/// <remarks>
	/// A null, default credential handle is created if User, Domain and Password are all NULL. Otherwise, User must be present. The
	/// Domain parameter may be NULL when User is fully qualified, such as a user in UPN format; for example, "someone@fabrikam.com".
	/// <para>
	/// When the handle returned in pAuthIdentity is passed to DsBindWithCred, DsUnBind must be called before freeing the handle with DsFreePasswordCredentials.
	/// </para>
	/// </remarks>
	[DllImport(Lib.NTDSApi, CharSet = CharSet.Auto)]
	[PInvokeData("NTDSApi.h", MSDNShortId = "ms676006")]
	public static extern Win32Error DsMakePasswordCredentials(string User, string Domain, string Password, out SafeAuthIdentityHandle pAuthIdentity);

	/// <summary>
	/// The <c>DsMapSchemaGuids</c> function converts GUIDs of directory service schema objects to their display names.
	/// </summary>
	/// <param name="hDs">Contains a directory service handle obtained from either the DSBind or DSBindWithCred function.</param>
	/// <param name="cGuids">Indicates the number of elements in rGuids.</param>
	/// <param name="rGuids">Pointer to an array of <c>GUID</c> values for the objects to be mapped.</param>
	/// <param name="ppGuidMap">Pointer to a variable that receives a pointer to an array of DS_SCHEMA_GUID_MAP structures that contain the display names of the
	/// objects in rGuids. This array must be deallocated using DsFreeSchemaGuidMap.</param>
	/// <returns>
	/// Returns a standard error code that includes the following values.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/nf-ntdsapi-dsmapschemaguidsa NTDSAPI DWORD DsMapSchemaGuidsA( HANDLE
	// hDs, DWORD cGuids, GUID *rGuids, DS_SCHEMA_GUID_MAPA **ppGuidMap );
	[DllImport(Lib.NTDSApi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("ntdsapi.h", MSDNShortId = "439fff20-51eb-490d-a330-61d07f79c436")]
	public static extern Win32Error DsMapSchemaGuids(SafeDsHandle hDs, uint cGuids, [In] Guid[] rGuids, out SafeDsSchemaGuidMap ppGuidMap);

	/// <summary>
	/// The <c>DsQuerySitesByCost</c> function gets the communication cost between one site and one or more other sites.
	/// </summary>
	/// <param name="hDS">A directory service handle.</param>
	/// <param name="pszFromSite">Pointer to a null-terminated string that contains the relative distinguished name of the site the costs are measured from.</param>
	/// <param name="rgszToSites">Contains an array of null-terminated string pointers that contain the relative distinguished names of the sites the costs are
	/// measured to.</param>
	/// <param name="cToSites">Contains the number of elements in the rgwszToSites array.</param>
	/// <param name="dwFlags">Reserved.</param>
	/// <param name="prgSiteInfo"><para>
	/// Pointer to an array of DS_SITE_COST_INFO structures that receives the cost data. Each element in this array contains the cost
	/// data between the site identified by the pwszFromSite parameter and the site identified by the corresponding rgwszToSites element.
	/// </para>
	/// <para>The caller must free this memory when it is no longer required by calling DsQuerySitesFree.</para></param>
	/// <returns>
	/// Returns <c>ERROR_SUCCESS</c> if successful or a Win32 or RPC error code otherwise. Possible error codes include values listed in
	/// the following list.
	/// </returns>
	/// <remarks>
	/// The cost values obtained by this function are only used to compare and have no meaning by themselves. For example, the cost for
	/// site 1 can be compared to the cost for site 2, but the cost for site 1 cannot be compared to a fixed value.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/nf-ntdsapi-dsquerysitesbycosta NTDSAPI_POSTXP DWORD
	// DsQuerySitesByCostA( HANDLE hDS, PSTR pszFromSite, PSTR *rgszToSites, DWORD cToSites, DWORD dwFlags, PDS_SITE_COST_INFO
	// *prgSiteInfo );
	[DllImport(Lib.NTDSApi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("ntdsapi.h", MSDNShortId = "7a4cbd1c-8445-4882-8559-d44b6e5693e7")]
	public static extern Win32Error DsQuerySitesByCost(SafeDsHandle hDS, string pszFromSite, [In] string[] rgszToSites,
		uint cToSites, [Optional] uint dwFlags, out SafeDsQuerySites prgSiteInfo);

	/// <summary>
	/// The <c>DsQuerySitesFree</c> function frees the memory allocated by the DsQuerySitesByCost function.
	/// </summary>
	/// <param name="rgSiteInfo">Pointer to an array of DS_SITE_COST_INFO structures allocated by a call to DsQuerySitesByCost.</param>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/nf-ntdsapi-dsquerysitesfree void DsQuerySitesFree( PDS_SITE_COST_INFO
	// rgSiteInfo );
	[DllImport(Lib.NTDSApi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("ntdsapi.h", MSDNShortId = "810caa4f-8275-4ad8-ad3e-72061fc073dd")]
	public static extern void DsQuerySitesFree(IntPtr rgSiteInfo);

	/// <summary>
	/// The <c>DsRemoveDsDomain</c> function removes all traces of a domain naming context from the global area of the directory service.
	/// </summary>
	/// <param name="hDs">Contains a directory service handle obtained from either the DSBind or DSBindWithCred function.</param>
	/// <param name="DomainDN">Pointer to a null-terminated string that specifies the distinguished name of the naming context to remove from the directory service.</param>
	/// <returns>
	/// Returns <c>ERROR_SUCCESS</c> if successful or a Win32 or RPC error code if unsuccessful. Possible error codes include the following.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/nf-ntdsapi-dsremovedsdomaina NTDSAPI DWORD DsRemoveDsDomainA( HANDLE
	// hDs, PSTR DomainDN );
	[DllImport(Lib.NTDSApi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("ntdsapi.h", MSDNShortId = "0639cc04-2821-4421-8aa7-363621c1d6b5")]
	public static extern Win32Error DsRemoveDsDomain(SafeDsHandle hDs, string DomainDN);

	/// <summary>
	/// The <c>DsRemoveDsServer</c> function removes all traces of a directory service agent (DSA) from the global area of the directory service.
	/// </summary>
	/// <param name="hDs">Contains a directory service handle obtained from either the DSBind or DSBindWithCred function.</param>
	/// <param name="ServerDN">Pointer to a null-terminated string that specifies the fully qualified distinguished name of the domain controller to remove.</param>
	/// <param name="DomainDN">Pointer to a null-terminated string that specifies a domain hosted by ServerDN. If this parameter is <c>NULL</c>, no verification
	/// is performed to ensure that ServerDN is the last domain controller in DomainDN.</param>
	/// <param name="fLastDcInDomain">Pointer to a Boolean value that receives <c>TRUE</c> if ServerDN is the last DC in DomainDN or <c>FALSE</c> otherwise. This
	/// parameter receives <c>FALSE</c> if DomainDN is <c>NULL</c>.</param>
	/// <param name="fCommit">Contains a Boolean value that specifies if the domain controller should actually be removed. If this parameter is nonzero,
	/// ServerDN is removed. If this parameter is zero, the existence of ServerDN is checked and fLastDcInDomain is written, but the
	/// domain controller is not removed.</param>
	/// <returns>
	/// Returns <c>ERROR_SUCCESS</c> if successful or a Win32 or RPC error code if unsuccessful. Possible error codes include the following.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/nf-ntdsapi-dsremovedsserverw NTDSAPI DWORD DsRemoveDsServerW( HANDLE
	// hDs, PWSTR ServerDN, PWSTR DomainDN, BOOL *fLastDcInDomain, BOOL fCommit );
	[DllImport(Lib.NTDSApi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("ntdsapi.h", MSDNShortId = "a79a2b71-10c7-495b-861f-0c7a4d86f720")]
	public static extern Win32Error DsRemoveDsServer(SafeDsHandle hDs, string ServerDN, [Optional] string? DomainDN, [MarshalAs(UnmanagedType.Bool)] out bool fLastDcInDomain, [MarshalAs(UnmanagedType.Bool)] bool fCommit);

	/// <summary>
	/// The <c>DsReplicaAdd</c> function adds a replication source reference to a destination naming context.
	/// </summary>
	/// <param name="hDS">Contains a directory service handle obtained from either the DSBind or DSBindWithCred function.</param>
	/// <param name="NameContext">The null-terminated string that specifies the distinguished name (DN) of the destination naming context (NC) for which to add the
	/// replica. The destination NC record must exist locally as either an object, instantiated or not, or a reference phantom, for
	/// example, a phantom with a GUID.</param>
	/// <param name="SourceDsaDn">The null-terminated string that specifies the DN of the <c>NTDS-DSA</c> object for the source directory system agent. This
	/// parameter is required if Options includes <c>DS_REPADD_ASYNCHRONOUS_REPLICA</c>; otherwise, it is ignored.</param>
	/// <param name="TransportDn">The null-terminated string that specifies the DN of the <c>interSiteTransport</c> object that represents the transport used for
	/// communication with the source server. This parameter is required if Options includes <c>DS_REPADD_INTERSITE_MESSAGING</c>;
	/// otherwise, it is ignored.</param>
	/// <param name="SourceDsaAddress">The null-terminated string that specifies the transport-specific address of the source DSA. This source server is identified by a
	/// string name, not by its UUID. A string name appropriate for SourceDsaAddress is usually a DNS name based on a GUID, where the
	/// GUID part of the name is the GUID of the <c>NTDS-DSA</c> object for the source server.</param>
	/// <param name="pSchedule">Pointer to a SCHEDULE structure that contains the replication schedule data for the replication source. This parameter is
	/// optional and can be <c>NULL</c> if not used.</param>
	/// <param name="Options"><para>Passes additional data to be used to process the request. This parameter can be a combination of the following values.</para>
	/// <para>DS_REPADD_ASYNCHRONOUS_OPERATION</para>
	/// <para>Performs this operation asynchronously.</para>
	/// <para>DS_REPADD_ASYNCHRONOUS_REPLICA</para>
	/// <para>Does not replicate the NC. Instead, save enough state data such that it may be replicated later.</para>
	/// <para>DS_REPADD_DISABLE_NOTIFICATION</para>
	/// <para>
	/// Disables notification-based synchronization for the NC from this source. This is expected to be a temporary state. Use
	/// <c>DS_REPADD_NEVER_NOTIFY</c> to permanently disable synchronization.
	/// </para>
	/// <para>DS_REPADD_DISABLE_PERIODIC</para>
	/// <para>Disables periodic synchronization for the NC from this source.</para>
	/// <para>DS_REPADD_INITIAL</para>
	/// <para>Synchronizes the NC from this source when the DSA is started.</para>
	/// <para>DS_REPADD_INTERSITE_MESSAGING</para>
	/// <para>
	/// Synchronizes from the source DSA using the Intersite Messaging Service (IMS) transport, for example, by SMTP, rather than using
	/// the native directory service RPC.
	/// </para>
	/// <para>DS_REPADD_NEVER_NOTIFY</para>
	/// <para>
	/// Disables change notifications from this source. When this flag is set, the source does not notify the destination when changes
	/// occur. This is recommended for all intersite replication that may occur over WAN links.
	/// </para>
	/// <para>This is expected to be a permanent state; use <c>DS_REPADD_DISABLE_NOTIFICATION</c> to temporarily disable notifications.</para>
	/// <para>DS_REPADD_PERIODIC</para>
	/// <para>Synchronizes the NC from this source periodically, as defined in pSchedule.</para>
	/// <para>DS_REPADD_USE_COMPRESSION</para>
	/// <para>
	/// Uses compression when replicating. This saves network bandwidth at the expense of CPU overhead at both the source and destination servers.
	/// </para>
	/// <para>DS_REPADD_WRITEABLE</para>
	/// <para>Creates a writable replica; otherwise, the replica is read-only.</para></param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>ERROR_SUCCESS</c>.</para>
	/// <para>If the function fails, the return value can be one of the following.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/nf-ntdsapi-dsreplicaadda NTDSAPI DWORD DsReplicaAddA( HANDLE hDS,
	// LPCSTR NameContext, LPCSTR SourceDsaDn, LPCSTR TransportDn, LPCSTR SourceDsaAddress, const PSCHEDULE pSchedule, DWORD Options );
	[DllImport(Lib.NTDSApi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("ntdsapi.h", MSDNShortId = "33bd1b61-b9ed-479f-a128-fb7ddbb5e9af")]
	public static extern Win32Error DsReplicaAdd(SafeDsHandle hDS, string NameContext, [Optional] string? SourceDsaDn, [Optional] string? TransportDn,
		string SourceDsaAddress, [Optional] SCHEDULE? pSchedule, DsReplicaAddOptions Options);

	/// <summary>
	/// The <c>DsReplicaConsistencyCheck</c> function invokes the Knowledge Consistency Checker (KCC) to verify the replication topology.
	/// The KCC dynamically adjusts the data replication topology of your network when domain controllers are added to or removed from
	/// the network, when a domain controller is unavailable, or when the data replication schedules are changed.
	/// </summary>
	/// <param name="hDS">Contains a directory service handle obtained from either the DSBind, DSBindWithCred, or DsBindWithSpn function.</param>
	/// <param name="TaskID">Identifies the task that the KCC should execute. <c>DS_KCC_TASKID_UPDATE_TOPOLOGY</c> is the only currently supported value.</param>
	/// <param name="dwFlags"><para>
	/// Contains a set of flags that modify the function behavior. This can be zero or a combination of one or more of the following values.
	/// </para>
	/// <para>DS_KCC_FLAG_ASYNC_OP</para>
	/// <para>The task is queued and then the function returns without waiting for the task to complete.</para>
	/// <para>DS_KCC_FLAG_DAMPED</para>
	/// <para>The task will not be added to the queue if another queued task will run soon.</para></param>
	/// <returns>
	/// If the function performs its operation successfully, the return value is <c>ERROR_SUCCESS</c>. If the function fails, the return
	/// value can be one of the following.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/nf-ntdsapi-dsreplicaconsistencycheck NTDSAPI DWORD
	// DsReplicaConsistencyCheck( HANDLE hDS, DS_KCC_TASKID TaskID, DWORD dwFlags );
	[DllImport(Lib.NTDSApi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("ntdsapi.h", MSDNShortId = "2a83ffcb-1ebd-4024-a186-9c079896f4e1")]
	public static extern Win32Error DsReplicaConsistencyCheck(SafeDsHandle hDS, DS_KCC_TASKID TaskID, DsKCCFlags dwFlags);

	/// <summary>
	/// The <c>DsReplicaDel</c> function removes a replication source reference from a destination naming context (NC).
	/// </summary>
	/// <param name="hDS">Contains a directory service handle obtained from either the DSBind or DSBindWithCred function.</param>
	/// <param name="NameContext">Pointer to a constant null-terminated string that specifies the distinguished name (DN) of the destination NC from which to
	/// remove the replica. The destination NC record must exist locally as either an object, instantiated or not, or a reference
	/// phantom, for example, a phantom with a GUID.</param>
	/// <param name="DsaSrc">Pointer to a constant null-terminated Unicode string that specifies the transport-specific address of the source directory system
	/// agent (DSA). This source server is identified by a string name, not by its <c>UUID</c>. A string name appropriate for DsaSrc is
	/// usually a DNS name that is based on a <c>GUID</c>, where the <c>GUID</c> part of the name is the <c>GUID</c> of the nTDSDSA
	/// object for the source server.</param>
	/// <param name="Options"><para>Passes additional data used to process the request. This parameter can be a combination of the following values.</para>
	/// <para>DS_REPDEL_ASYNCHRONOUS_OPERATION</para>
	/// <para>Performs this operation asynchronously.</para>
	/// <para>DS_REPDEL_IGNORE_ERRORS</para>
	/// <para>
	/// Ignores any error generated from contacting the source to instruct it to remove this NC from its list of servers to which it replicates.
	/// </para>
	/// <para>DS_REPDEL_INTERSITE_MESSAGING</para>
	/// <para>Signifies the replica is mail-based rather than synchronized using native directory service RPC.</para>
	/// <para>DS_REPDEL_LOCAL_ONLY</para>
	/// <para>
	/// Does not contact the source to tell it to remove this NC from its list of servers to which it replicates. If this flag is not set
	/// and the link is based in RPC, the source is contacted.
	/// </para>
	/// <para>DS_REPDEL_NO_SOURCE</para>
	/// <para>Deletes all the objects in the NC. This option is valid only for read-only NCs with no source.</para>
	/// <para>DS_REPDEL_REF_OK</para>
	/// <para>Allows deletion of a read-only replica even if it sources other read-only replicas.</para>
	/// <para>DS_REPDEL_WRITEABLE</para>
	/// <para>Signifies that the replica deleted can be written to.</para></param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>ERROR_SUCCESS</c>.</para>
	/// <para>
	/// If the function fails, the return value is a standard Win32 API error or <c>ERROR_INVALID_PARAMETER</c> if a parameter is invalid.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/nf-ntdsapi-dsreplicadela NTDSAPI DWORD DsReplicaDelA( HANDLE hDS,
	// LPCSTR NameContext, LPCSTR DsaSrc, ULONG Options );
	[DllImport(Lib.NTDSApi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("ntdsapi.h", MSDNShortId = "68c767c4-bbb6-477b-8ffb-94f3ae235375")]
	public static extern Win32Error DsReplicaDel(SafeDsHandle hDS, string NameContext, string DsaSrc, DsReplicaDelOptions Options);

	/// <summary>
	/// The <c>DsReplicaFreeInfo</c> function frees the replication state data structure allocated by the DsReplicaGetInfo or
	/// DsReplicaGetInfo2 functions.
	/// </summary>
	/// <param name="InfoType">Contains one of the DS_REPL_INFO_TYPE values that specifies the type of replication data structure contained in pInfo. This must
	/// be the same value passed to the DsReplicaGetInfo or DsReplicaGetInfo2 function when the structure was allocated.</param>
	/// <param name="pInfo">Pointer to the replication data structure allocated by the DsReplicaGetInfo or DsReplicaGetInfo2 functions.</param>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/nf-ntdsapi-dsreplicafreeinfo void DsReplicaFreeInfo(
	// DS_REPL_INFO_TYPE InfoType, VOID *pInfo );
	[DllImport(Lib.NTDSApi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("ntdsapi.h", MSDNShortId = "32ce378e-a178-4970-b3bd-3887866e97af")]
	public static extern void DsReplicaFreeInfo(DS_REPL_INFO_TYPE InfoType, IntPtr pInfo);

	/// <summary>
	/// The <c>DsReplicaGetInfo2</c> function retrieves replication state data from the directory service. This function allows paging of
	/// results in cases where there are more than 1000 entries to retrieve.
	/// </summary>
	/// <param name="hDS">Contains a directory service handle obtained from either the DSBind or DSBindWithCred function.</param>
	/// <param name="InfoType">Contains one of the DS_REPL_INFO_TYPE values that specifies the type of replication data to retrieve. This value also determines
	/// which type of structure is returned in ppInfo.</param>
	/// <param name="pszObject"><para>
	/// Pointer to a constant null-terminated Unicode string that identifies the object to retrieve replication data for. The meaning of
	/// this parameter depends on the value of the InfoType parameter. The following are possible value codes.
	/// </para>
	/// <para>DS_REPL_INFO_NEIGHBORS</para>
	/// <para>pszObject identifies the naming context for which replication neighbors are requested.</para>
	/// <para>DS_REPL_INFO_CURSORS_FOR_NC</para>
	/// <para>pszObject identifies the naming context for which replication cursors are requested.</para>
	/// <para>DS_REPL_INFO_METADATA_FOR_OBJ</para>
	/// <para>pszObject identifies the object for which replication metadata is requested.</para>
	/// <para>DS_REPL_INFO_KCC_DSA_CONNECT_FAILURES</para>
	/// <para>pszObject must be <c>NULL</c>.</para>
	/// <para>DS_REPL_INFO_KCC_DSA_LINK_FAILURES</para>
	/// <para>pszObject must be <c>NULL</c>.</para>
	/// <para>DS_REPL_INFO_PENDING_OPS</para>
	/// <para>pszObject must be <c>NULL</c>.</para>
	/// <para>DS_REPL_INFO_METADATA_FOR_ATTR_VALUE</para>
	/// <para>pszObject identifies the object for which attribute replication metadata is requested.</para>
	/// <para>DS_REPL_INFO_CURSORS_2_FOR_NC</para>
	/// <para>DS_REPL_INFO_CURSORS_3_FOR_NC</para>
	/// <para>DS_REPL_INFO_METADATA_2_FOR_OBJ</para>
	/// <para>pszObject identifies the object for which replication metadata is requested.</para>
	/// <para>DS_REPL_INFO_METADATA_2_FOR_ATTR_VALUE</para>
	/// <para>pszObject identifies the object for which attribute replication metadata is requested.</para></param>
	/// <param name="puuidForSourceDsaObjGuid">Pointer to a <c>GUID</c> value that identifies a specific replication source. If this parameter is not <c>NULL</c> and the
	/// InfoType parameter contains <c>DS_REPL_INFO_NEIGHBORS</c>, only neighbor data for the source corresponding to the nTDSDSA object
	/// with the given <c>objectGuid</c> in the directory is returned. This parameter is ignored if <c>NULL</c> or if the InfoType
	/// parameter is anything other than <c>DS_REPL_INFO_NEIGHBORS</c>.</param>
	/// <param name="pszAttributeName"><para>
	/// Pointer to a null-terminated Unicode string that contains the name of the specific attribute to retrieve replication data for.
	/// </para>
	/// <para>This parameter is only used if the InfoType parameter contains one of the following values.</para>
	/// <para>DS_REPL_INFO_METADATA_FOR_ATTR_VALUE</para>
	/// <para>DS_REPL_INFO_METADATA_2_FOR_ATTR_VALUE</para></param>
	/// <param name="pszValue">Pointer to a null-terminated Unicode string that contains the distinguished name value to match. If the requested attribute is a
	/// distinguished name type value, this function return the attributes that contain the specified value.</param>
	/// <param name="dwFlags"><para>Contains a set of flags that modify the behavior of the function. This parameter can be zero or the following value.</para>
	/// <para>DS_REPL_INFO_FLAG_IMPROVE_LINKED_ATTRS</para>
	/// <para>
	/// Causes the attribute metadata to account for metadata on the attribute's linked values. The resulting vector represents changes
	/// for all attributes. This modified vector is useful for clients that expect all attributes and metadata to be included in the
	/// attribute metadata vector.
	/// </para></param>
	/// <param name="dwEnumerationContext"><para>Contains the index of the next entry to retrieve. This parameter must be set to zero the first time this function is called.</para>
	/// <para>This parameter is only used if the InfoType parameter contains one of the following values.</para>
	/// <para>DS_REPL_INFO_CURSORS_2_FOR_NC</para>
	/// <para>DS_REPL_INFO_CURSORS_3_FOR_NC</para>
	/// <para>DS_REPL_INFO_METADATA_FOR_ATTR_VALUE</para>
	/// <para>DS_REPL_INFO_METADATA_2_FOR_ATTR_VALUE</para>
	/// <para>
	/// This function will retrieve a maximum of 1000 entries on each call. If after calling this function, more entries are available,
	/// the <c>dwEnumerationContext</c> member of the retrieved structure will contain the index of the next entry to retrieve. The
	/// <c>dwEnumerationContext</c> member of the retrieved structure is then used as the dwEnumerationContext parameter in the next call
	/// to this function. When all of the entries have been retrieved, the <c>dwEnumerationContext</c> member of the retrieved structure
	/// will contain -1. If -1 is passed for this parameter, this function will return <c>ERROR_NO_MORE_ITEMS</c>.
	/// </para></param>
	/// <param name="ppInfo"><para>
	/// Address of a structure pointer that receives the requested data. The value of the InfoType parameter determines the format of
	/// this structure. For more information and a list of possible InfoType values and the corresponding structure types, see DS_REPL_INFO_TYPE.
	/// </para>
	/// <para>The caller must free this memory when it is no longer required by calling DsReplicaFreeInfo.</para></param>
	/// <returns>
	/// Returns <c>ERROR_SUCCESS</c> if successful or a Win32 or RPC error otherwise. The following are possible error codes.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/nf-ntdsapi-dsreplicagetinfo2w NTDSAPI DWORD DsReplicaGetInfo2W(
	// HANDLE hDS, DS_REPL_INFO_TYPE InfoType, LPCWSTR pszObject, UUID *puuidForSourceDsaObjGuid, LPCWSTR pszAttributeName, LPCWSTR
	// pszValue, DWORD dwFlags, DWORD dwEnumerationContext, VOID **ppInfo );
	[PInvokeData("ntdsapi.h", MSDNShortId = "5735d91d-1b7d-4dc6-b6c6-61ba38ebe50d")]
	public static Win32Error DsReplicaGetInfo2W(SafeDsHandle hDS, DS_REPL_INFO_TYPE InfoType, [Optional] string? pszObject, [Optional] Guid? puuidForSourceDsaObjGuid, [Optional] string? pszAttributeName,
		[Optional] string? pszValue, DsReplInfoFlags dwFlags, uint dwEnumerationContext, out SafeDsReplicaInfo ppInfo)
	{
		unsafe
		{
			var guid = puuidForSourceDsaObjGuid.GetValueOrDefault();
			var ret = DsReplicaGetInfo2W(hDS, InfoType, pszObject, puuidForSourceDsaObjGuid.HasValue ? &guid : null, pszAttributeName, pszValue, dwFlags, dwEnumerationContext, out ppInfo);
			ppInfo.Type = InfoType;
			return ret;
		}
	}

	/// <summary>
	/// The <c>DsReplicaGetInfo</c> function retrieves replication state data from the directory service.
	/// </summary>
	/// <param name="hDS">Contains a directory service handle obtained from either the DSBind or DSBindWithCred function.</param>
	/// <param name="InfoType"><para>
	/// Contains one of the DS_REPL_INFO_TYPE values that specifies the type of replication data to retrieve. This value also determines
	/// which type of structure is returned in ppInfo.
	/// </para>
	/// <para>
	/// Only the following values are supported for this function. If other data types are required, the DsReplicaGetInfo2 function must
	/// be used.
	/// </para>
	/// <para>DS_REPL_INFO_NEIGHBORS</para>
	/// <para>DS_REPL_INFO_CURSORS_FOR_NC</para>
	/// <para>DS_REPL_INFO_METADATA_FOR_OBJ</para>
	/// <para>DS_REPL_INFO_KCC_DSA_CONNECT_FAILURES</para>
	/// <para>DS_REPL_INFO_KCC_DSA_LINK_FAILURES</para>
	/// <para>DS_REPL_INFO_PENDING_OPS</para></param>
	/// <param name="pszObject"><para>
	/// Pointer to a constant null-terminated Unicode string that identifies the object to retrieve replication data for. The meaning of
	/// this parameter depends on the value of the InfoType parameter. The following are possible value codes.
	/// </para>
	/// <para>DS_REPL_INFO_NEIGHBORS</para>
	/// <para>pszObject identifies the naming context for which replication neighbors are requested.</para>
	/// <para>DS_REPL_INFO_CURSORS_FOR_NC</para>
	/// <para>pszObject identifies the naming context for which replication cursors are requested.</para>
	/// <para>DS_REPL_INFO_METADATA_FOR_OBJ</para>
	/// <para>pszObject identifies the object for which replication metadata is requested.</para>
	/// <para>DS_REPL_INFO_KCC_DSA_CONNECT_FAILURES</para>
	/// <para>pszObject must be <c>NULL</c>.</para>
	/// <para>DS_REPL_INFO_KCC_DSA_LINK_FAILURES</para>
	/// <para>pszObject must be <c>NULL</c>.</para>
	/// <para>DS_REPL_INFO_PENDING_OPS</para>
	/// <para>pszObject must be <c>NULL</c>.</para></param>
	/// <param name="puuidForSourceDsaObjGuid">Pointer to a <c>GUID</c> value that identifies a specific replication source. If this parameter is not <c>NULL</c> and the
	/// InfoType parameter contains <c>DS_REPL_INFO_NEIGHBORS</c>, only neighbor data for the source corresponding to the nTDSDSA object
	/// with the given <c>objectGuid</c> in the directory is returned. This parameter is ignored if <c>NULL</c> or if the InfoType
	/// parameter is anything other than <c>DS_REPL_INFO_NEIGHBORS</c>.</param>
	/// <param name="ppInfo"><para>
	/// Address of a structure pointer that receives the requested data. The value of the InfoType parameter determines the format of
	/// this structure. For more information and list of possible InfoType values and the corresponding structure types, see DS_REPL_INFO_TYPE.
	/// </para>
	/// <para>The caller must free this memory when it is no longer required by calling DsReplicaFreeInfo.</para></param>
	/// <returns>
	/// Returns <c>ERROR_SUCCESS</c> if successful or a Win32 or RPC error otherwise. The following are possible error codes.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/nf-ntdsapi-dsreplicagetinfow NTDSAPI DWORD DsReplicaGetInfoW( HANDLE
	// hDS, DS_REPL_INFO_TYPE InfoType, LPCWSTR pszObject, UUID *puuidForSourceDsaObjGuid, VOID **ppInfo );
	[DllImport(Lib.NTDSApi, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("ntdsapi.h", MSDNShortId = "b7ab22fe-ed92-4213-9b66-2dd5526286fa")]
	public static extern Win32Error DsReplicaGetInfoW(SafeDsHandle hDS, DS_REPL_INFO_TYPE InfoType, [Optional] string? pszObject, in Guid puuidForSourceDsaObjGuid, out SafeDsReplicaInfo ppInfo);

	/// <summary>
	/// The <c>DsReplicaModify</c> function modifies an existing replication source reference for a destination naming context.
	/// </summary>
	/// <param name="hDS">Contains a directory service handle obtained from either the DSBind or DSBindWithCred function.</param>
	/// <param name="NameContext">Pointer to a constant null-terminated string that specifies the distinguished name (DN) of the destination naming context (NC).</param>
	/// <param name="pUuidSourceDsa">Pointer to the UUID of the source directory system agent (DSA). This parameter may be null if ModifyFields does not include
	/// <c>DS_REPMOD_UPDATE_ADDRESS</c> and SourceDsaAddress is not <c>NULL</c>.</param>
	/// <param name="TransportDn">Reserved for future use. Any value other than <c>NULL</c> results in <c>ERROR_NOT_SUPPORTED</c> being returned.</param>
	/// <param name="SourceDsaAddress">Pointer to a constant null-terminated Unicode string that specifies the transport-specific address of the source DSA. This
	/// parameter is ignored if pUuidSourceDsa is not <c>NULL</c> and ModifyFields does not include <c>DS_REPMOD_UPDATE_ADDRESS</c>.</param>
	/// <param name="pSchedule">Pointer to a SCHEDULE structure that contains the replication schedule data for the replication source. This parameter is
	/// optional and can be <c>NULL</c> if not used. This parameter is required if ModifyFields contains the
	/// <c>DS_REPMOD_UPDATE_SCHEDULE</c> flag.</param>
	/// <param name="ReplicaFlags"><para>This parameter is used to control replication behavior and can take the following values.</para>
	/// <para>DS_REPL_NBR_SYNC_ON_STARTUP</para>
	/// <para>
	/// Replication of this naming context from this source is attempted when the destination server is booted. This normally only
	/// applies to intra-site neighbors.
	/// </para>
	/// <para>DS_REPL_NBR_DO_SCHEDULED_SYNCS</para>
	/// <para>
	/// Perform replication on a schedule. This flag is normally set unless the schedule for this naming context and source is "never",
	/// that is, the empty schedule.
	/// </para>
	/// <para>DS_REPL_NBR_TWO_WAY_SYNC</para>
	/// <para>
	/// If set, indicates that when inbound replication is complete, the destination server must tell the source server to synchronize in
	/// the reverse direction. This feature is used in dial-up scenarios where only one of the two servers can initiate a dial-up
	/// connection. For example, this option would be used in a corporate headquarters and branch office, where the branch office
	/// connects to the corporate headquarters over the Internet by means of a dial-up ISP connection.
	/// </para>
	/// <para>DS_REPL_NBR_IGNORE_CHANGE_NOTIFICATIONS</para>
	/// <para>
	/// This neighbor is set to disable notification-based synchronization. Within a site, domain controllers synchronize with each other
	/// based on notifications when changes occur. This setting prevents this neighbor from performing a synchronization triggered by a
	/// notification. The neighbor will still do synchronization based on its schedule or in response to manually requested synchronization.
	/// </para>
	/// <para>DS_REPL_NBR_DISABLE_SCHEDULED_SYNC</para>
	/// <para>
	/// This neighbor is set to not perform synchronization based on its schedule. The only way this neighbor will perform
	/// synchronization is in response to change notifications or to manually requested synchronization.
	/// </para>
	/// <para>DS_REPL_NBR_COMPRESS_CHANGES</para>
	/// <para>
	/// Changes received from this source are to be compressed. This is normally set if, and only if, the source server is in a different site.
	/// </para>
	/// <para>DS_REPL_NBR_NO_CHANGE_NOTIFICATIONS</para>
	/// <para>
	/// No change notifications should be received from this source. This is normally set if, and only if, the source server is in a
	/// different site.
	/// </para></param>
	/// <param name="ModifyFields"><para>
	/// Specifies what fields should be modified. At least one field must be specified in ModifyFields. This parameter can be a
	/// combination of the following values.
	/// </para>
	/// <para>DS_REPMOD_UPDATE_ADDRESS</para>
	/// <para>Updates the address associated with the referenced server.</para>
	/// <para>DS_REPMOD_UPDATE_FLAGS</para>
	/// <para>Updates the flags associated with the replica.</para>
	/// <para>DS_REPMOD_UPDATE_RESULT</para>
	/// <para>Not used. Specifying updates of result values is not currently supported. Result values default to 0.</para>
	/// <para>DS_REPMOD_UPDATE_SCHEDULE</para>
	/// <para>Updates the periodic replication schedule associated with the replica.</para>
	/// <para>DS_REPMOD_UPDATE_TRANSPORT</para>
	/// <para>Updates the transport associated with the replica.</para></param>
	/// <param name="Options"><para>Passes additional data used to process the request. This parameter can be a combination of the following values.</para>
	/// <para>DS_REPMOD_ASYNCHRONOUS_OPERATION</para>
	/// <para>Performs this operation asynchronously.</para>
	/// <para>DS_REPMOD_WRITEABLE</para>
	/// <para>Indicates that the replica being modified can be written to.</para></param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>ERROR_SUCCESS</c>.</para>
	/// <para>If the function fails, the return value can be one of the following.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/nf-ntdsapi-dsreplicamodifya NTDSAPI DWORD DsReplicaModifyA( HANDLE
	// hDS, LPCSTR NameContext, const UUID *pUuidSourceDsa, LPCSTR TransportDn, LPCSTR SourceDsaAddress, const PSCHEDULE pSchedule, DWORD
	// ReplicaFlags, DWORD ModifyFields, DWORD Options );
	[DllImport(Lib.NTDSApi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("ntdsapi.h", MSDNShortId = "aad20527-1211-41bc-b0e9-02e4ab28ae2e")]
	public static extern Win32Error DsReplicaModify(SafeDsHandle hDS, string NameContext, in Guid pUuidSourceDsa, [Optional] string? TransportDn, [Optional] string? SourceDsaAddress,
		[Optional] SCHEDULE? pSchedule, DsReplNeighborFlags ReplicaFlags, DsReplModFieldFlags ModifyFields, DsReplModOptions Options);

	/// <summary>
	/// The <c>DsReplicaModify</c> function modifies an existing replication source reference for a destination naming context.
	/// </summary>
	/// <param name="hDS">Contains a directory service handle obtained from either the DSBind or DSBindWithCred function.</param>
	/// <param name="NameContext">Pointer to a constant null-terminated string that specifies the distinguished name (DN) of the destination naming context (NC).</param>
	/// <param name="pUuidSourceDsa">Pointer to the UUID of the source directory system agent (DSA). This parameter may be null if ModifyFields does not include
	/// <c>DS_REPMOD_UPDATE_ADDRESS</c> and SourceDsaAddress is not <c>NULL</c>.</param>
	/// <param name="TransportDn">Reserved for future use. Any value other than <c>NULL</c> results in <c>ERROR_NOT_SUPPORTED</c> being returned.</param>
	/// <param name="SourceDsaAddress">Pointer to a constant null-terminated Unicode string that specifies the transport-specific address of the source DSA. This
	/// parameter is ignored if pUuidSourceDsa is not <c>NULL</c> and ModifyFields does not include <c>DS_REPMOD_UPDATE_ADDRESS</c>.</param>
	/// <param name="pSchedule">Pointer to a SCHEDULE structure that contains the replication schedule data for the replication source. This parameter is
	/// optional and can be <c>NULL</c> if not used. This parameter is required if ModifyFields contains the
	/// <c>DS_REPMOD_UPDATE_SCHEDULE</c> flag.</param>
	/// <param name="ReplicaFlags"><para>This parameter is used to control replication behavior and can take the following values.</para>
	/// <para>DS_REPL_NBR_SYNC_ON_STARTUP</para>
	/// <para>
	/// Replication of this naming context from this source is attempted when the destination server is booted. This normally only
	/// applies to intra-site neighbors.
	/// </para>
	/// <para>DS_REPL_NBR_DO_SCHEDULED_SYNCS</para>
	/// <para>
	/// Perform replication on a schedule. This flag is normally set unless the schedule for this naming context and source is "never",
	/// that is, the empty schedule.
	/// </para>
	/// <para>DS_REPL_NBR_TWO_WAY_SYNC</para>
	/// <para>
	/// If set, indicates that when inbound replication is complete, the destination server must tell the source server to synchronize in
	/// the reverse direction. This feature is used in dial-up scenarios where only one of the two servers can initiate a dial-up
	/// connection. For example, this option would be used in a corporate headquarters and branch office, where the branch office
	/// connects to the corporate headquarters over the Internet by means of a dial-up ISP connection.
	/// </para>
	/// <para>DS_REPL_NBR_IGNORE_CHANGE_NOTIFICATIONS</para>
	/// <para>
	/// This neighbor is set to disable notification-based synchronization. Within a site, domain controllers synchronize with each other
	/// based on notifications when changes occur. This setting prevents this neighbor from performing a synchronization triggered by a
	/// notification. The neighbor will still do synchronization based on its schedule or in response to manually requested synchronization.
	/// </para>
	/// <para>DS_REPL_NBR_DISABLE_SCHEDULED_SYNC</para>
	/// <para>
	/// This neighbor is set to not perform synchronization based on its schedule. The only way this neighbor will perform
	/// synchronization is in response to change notifications or to manually requested synchronization.
	/// </para>
	/// <para>DS_REPL_NBR_COMPRESS_CHANGES</para>
	/// <para>
	/// Changes received from this source are to be compressed. This is normally set if, and only if, the source server is in a different site.
	/// </para>
	/// <para>DS_REPL_NBR_NO_CHANGE_NOTIFICATIONS</para>
	/// <para>
	/// No change notifications should be received from this source. This is normally set if, and only if, the source server is in a
	/// different site.
	/// </para></param>
	/// <param name="ModifyFields"><para>
	/// Specifies what fields should be modified. At least one field must be specified in ModifyFields. This parameter can be a
	/// combination of the following values.
	/// </para>
	/// <para>DS_REPMOD_UPDATE_ADDRESS</para>
	/// <para>Updates the address associated with the referenced server.</para>
	/// <para>DS_REPMOD_UPDATE_FLAGS</para>
	/// <para>Updates the flags associated with the replica.</para>
	/// <para>DS_REPMOD_UPDATE_RESULT</para>
	/// <para>Not used. Specifying updates of result values is not currently supported. Result values default to 0.</para>
	/// <para>DS_REPMOD_UPDATE_SCHEDULE</para>
	/// <para>Updates the periodic replication schedule associated with the replica.</para>
	/// <para>DS_REPMOD_UPDATE_TRANSPORT</para>
	/// <para>Updates the transport associated with the replica.</para></param>
	/// <param name="Options"><para>Passes additional data used to process the request. This parameter can be a combination of the following values.</para>
	/// <para>DS_REPMOD_ASYNCHRONOUS_OPERATION</para>
	/// <para>Performs this operation asynchronously.</para>
	/// <para>DS_REPMOD_WRITEABLE</para>
	/// <para>Indicates that the replica being modified can be written to.</para></param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>ERROR_SUCCESS</c>.</para>
	/// <para>If the function fails, the return value can be one of the following.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/nf-ntdsapi-dsreplicamodifya NTDSAPI DWORD DsReplicaModifyA( HANDLE
	// hDS, LPCSTR NameContext, const UUID *pUuidSourceDsa, LPCSTR TransportDn, LPCSTR SourceDsaAddress, const PSCHEDULE pSchedule, DWORD
	// ReplicaFlags, DWORD ModifyFields, DWORD Options );
	[DllImport(Lib.NTDSApi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("ntdsapi.h", MSDNShortId = "aad20527-1211-41bc-b0e9-02e4ab28ae2e")]
	public static extern Win32Error DsReplicaModify(SafeDsHandle hDS, string NameContext, [Optional] IntPtr pUuidSourceDsa, [Optional] string? TransportDn, [Optional] string? SourceDsaAddress,
		[Optional] SCHEDULE? pSchedule, DsReplNeighborFlags ReplicaFlags, DsReplModFieldFlags ModifyFields, DsReplModOptions Options);

	/// <summary>
	/// The <c>DsReplicaSync</c> function synchronizes a destination naming context (NC) with one of its sources.
	/// </summary>
	/// <param name="hDS">Contains a directory service handle obtained from either the DSBind or DSBindWithCred function.</param>
	/// <param name="NameContext">Pointer to a constant null-terminated string that specifies the distinguished name of the destination NC.</param>
	/// <param name="pUuidDsaSrc">Pointer to the UUID of a source that replicates to the destination NC.</param>
	/// <param name="Options"><para>Passes additional data used to process the request. This parameter can be a combination of the following values.</para>
	/// <para>DS_REPSYNC_ADD_REFERENCE</para>
	/// <para>
	/// Causes the source directory system agent (DSA) to verify that the local DSA is present in the source replicates-to list. If not,
	/// the local DSA is added. This ensures that the source sends change notifications.
	/// </para>
	/// <para>DS_REPSYNC_ALL_SOURCES</para>
	/// <para>This value is not supported.</para>
	/// <para>
	///   <c>Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista and Windows Server 2003:</c> Synchronizes from all sources.
	/// </para>
	/// <para>DS_REPSYNC_ASYNCHRONOUS_OPERATION</para>
	/// <para>Performs this operation asynchronously.</para>
	/// <para>
	///   <c>Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista and Windows Server 2003:</c> Required when using <c>DS_REPSYNC_ALL_SOURCES</c>.
	/// </para>
	/// <para>DS_REPSYNC_FORCE</para>
	/// <para>Synchronizes even if the link is currently disabled.</para>
	/// <para>DS_REPSYNC_FULL</para>
	/// <para>Synchronizes starting from the first Update Sequence Number (USN).</para>
	/// <para>DS_REPSYNC_INTERSITE_MESSAGING</para>
	/// <para>Synchronizes using an ISM.</para>
	/// <para>DS_REPSYNC_NO_DISCARD</para>
	/// <para>Does not discard this synchronization request, even if a similar synchronization is pending.</para>
	/// <para>DS_REPSYNC_PERIODIC</para>
	/// <para>Indicates this operation is a periodic synchronization request as scheduled by the administrator.</para>
	/// <para>DS_REPSYNC_URGENT</para>
	/// <para>Indicates this operation is a notification of an update marked urgent.</para>
	/// <para>DS_REPSYNC_WRITEABLE</para>
	/// <para>Replica is writable. Otherwise, it is read-only.</para></param>
	/// <returns>
	/// <para>If the function performs its operation successfully, the return value is <c>ERROR_SUCCESS</c>.</para>
	/// <para>If the function fails, the return value is one of the standard Win32 API errors.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The server that <c>DsReplicaSync</c> executes on is called the destination. The destination naming context is brought up-to-date
	/// with respect to a source system, identified by the UUID of the source system NTDS Settings object. The destination system must
	/// already be configured so that the source system is one of the systems from which it receives replication data.
	/// </para>
	/// <para>
	///   <c>Note</c> Forcing manual synchronization can prevent the directory service from properly prioritizing replication operations.
	/// For example, synchronizing a new user may preempt an urgent synchronization performed to provide access to a recently locked out
	/// user or to add a new trust password. If you call this API often, you can flood the network with requests, which can interfere
	/// with other replication operations. For this reason, it is strongly recommended that this function be used only for single-use
	/// scenarios rather than incorporating it into an application that would use it on a regular basis.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/nf-ntdsapi-dsreplicasynca NTDSAPI DWORD DsReplicaSyncA( HANDLE hDS,
	// LPCSTR NameContext, const UUID *pUuidDsaSrc, ULONG Options );
	[DllImport(Lib.NTDSApi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("ntdsapi.h", MSDNShortId = "20c7f96d-f298-4321-a6f5-910c25e418db")]
	public static extern Win32Error DsReplicaSync(SafeDsHandle hDS, string NameContext, in Guid pUuidDsaSrc, DsReplSyncOptions Options);

	/// <summary>
	/// The <c>DsReplicaSyncAll</c> function synchronizes a server with all other servers, using transitive replication, as necessary. By
	/// default, <c>DsReplicaSyncAll</c> synchronizes the server with all other servers in its site; however, you can also use it to
	/// synchronize across site boundaries.
	/// </summary>
	/// <param name="hDS">Contains a directory service handle obtained from either the DSBind or DSBindWithCred function.</param>
	/// <param name="pszNameContext">Pointer to a null-terminated string that specifies the distinguished name of the naming context to synchronize. The
	/// pszNameContext parameter is optional; if its value is <c>NULL</c>, the configuration naming context is replicated.</param>
	/// <param name="ulFlags"><para>Passes additional data used to process the request. This parameter can be a combination of the following values.</para>
	/// <para>DS_REPSYNCALL_ABORT_IF_SERVER_UNAVAILABLE</para>
	/// <para>
	/// Generates a fatal error if any server cannot be contacted or if any server is unreachable due to a disconnected or broken topology.
	/// </para>
	/// <para>DS_REPSYNCALL_CROSS_SITE_BOUNDARIES</para>
	/// <para>
	/// Synchronizes across site boundaries. By default, <c>DsReplicaSyncAll</c> attempts to synchronize only with DCs in the same site
	/// as the home system. Set this flag to attempt to synchronize with all DCs in the enterprise forest. However, the DCs can be
	/// synchronized only if connected by a synchronous (RPC) transport.
	/// </para>
	/// <para>DS_REPSYNCALL_DO_NOT_SYNC</para>
	/// <para>Disables all synchronization. The topology is still analyzed, and unavailable or unreachable servers are still identified.</para>
	/// <para>DS_REPSYNCALL_ID_SERVERS_BY_DN</para>
	/// <para>In the event of a non-fatal error, returns server distinguished names (DN) instead of their GUID DNS names.</para>
	/// <para>DS_REPSYNCALL_NO_OPTIONS</para>
	/// <para>This option has no effect.</para>
	/// <para>DS_REPSYNCALL_PUSH_CHANGES_OUTWARD</para>
	/// <para>
	/// Pushes changes from the home server out to all partners using transitive replication. This reverses the direction of replication,
	/// and the order of execution of the replication sets from the usual "pulling" mode of execution.
	/// </para>
	/// <para>DS_REPSYNCALL_SKIP_INITIAL_CHECK</para>
	/// <para>
	/// Assumes that all servers are responding. This speeds operation of the <c>DsReplicaSyncAll</c> function, but if some servers are
	/// not responding, some transitive replications may be blocked.
	/// </para>
	/// <para>DS_REPSYNCALL_SYNC_ADJACENT_SERVERS_ONLY</para>
	/// <para>Disables transitive replication. Synchronization is performed only with adjacent servers.</para></param>
	/// <param name="pFnCallBack">Pointer to an application-defined SyncUpdateProc function called by the <c>DsReplicaSyncAll</c> function when it encounters an
	/// error, initiates synchronization of two servers, completes synchronization of two servers, or finishes synchronization of all the
	/// servers in the site.</param>
	/// <param name="pCallbackData">Pointer to application-defined data passed as the first argument of the SyncUpdateProc callback function pointed to by the
	/// pFnCallBack parameter.</param>
	/// <param name="pErrors">A NULL-terminated array of pointers to DS_REPSYNCALL_ERRINFO structures that contain errors that occurred during synchronization.
	/// The memory used to hold both the array of pointers and the MsCS\mscs\clusctl_resource_type_get_private_property_fmts.xml data is
	/// allocated as a single block of memory and should be freed when no longer required by a single call to <c>LocalFree</c> with the
	/// pointer value returned in pErrors used as the argument.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>ERROR_SUCCESS</c>.</para>
	/// <para>If the function fails, the return value is as follows.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>DsReplicaSyncAll</c> function attempts to bind to all servers before generating a topology to synchronize from. If a
	/// server cannot be contacted, the function excludes that server from the topology and attempts to work around it. Setting the
	/// <c>DS_REPSYNCALL_SKIP_INITIAL_CHECK</c> flag in ulFlags bypasses the initial binding.
	/// </para>
	/// <para>
	/// If a server cannot be contacted, the <c>DsReplicaSyncAll</c> function attempts to route around it and replicate from as many
	/// servers as possible, unless <c>DS_REPSYNCALL_ABORT_IF_SERVER_UNAVAILABLE</c> is set in ulFlags.
	/// </para>
	/// <para>
	/// The <c>DsReplicaSyncAll</c> function can use the callback function pointed to by pFnCallBack to keep an end user informed about
	/// the current status of the replication. Execution of the <c>DsReplicaSyncAll</c> function pauses when it calls the function
	/// pointed to by pFnCallBack. If the return value from the callback function is <c>TRUE</c>, replication continues; otherwise, the
	/// <c>DsReplicaSyncAll</c> function terminates replication.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/nf-ntdsapi-dsreplicasyncalla NTDSAPI DWORD DsReplicaSyncAllA( HANDLE
	// hDS, LPCSTR pszNameContext, ULONG ulFlags, BOOL(* )(LPVOID,PDS_REPSYNCALL_UPDATEA) pFnCallBack, LPVOID pCallbackData,
	// PDS_REPSYNCALL_ERRINFOA **pErrors );
	[DllImport(Lib.NTDSApi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("ntdsapi.h", MSDNShortId = "2608adde-4f18-4048-a96f-d736ff09cd4b")]
	public static extern Win32Error DsReplicaSyncAll(SafeDsHandle hDS, [Optional] string? pszNameContext, DsReplSyncAllFlags ulFlags, SyncUpdateProc pFnCallBack, IntPtr pCallbackData, out SafeDS_REPSYNCALL_ERRINFOArray pErrors);

	/// <summary>
	/// The <c>DsReplicaUpdateRefs</c> function adds or removes a replication reference for a destination from a source naming context.
	/// </summary>
	/// <param name="hDS">Contains a directory service handle obtained from either the DSBind or DSBindWithCred function.</param>
	/// <param name="NameContext">Pointer to a constant null-terminated string that specifies the distinguished name of the source naming context.</param>
	/// <param name="DsaDest">Pointer to a constant null-terminated string that specifies the transport-specific address of the destination directory system agent.</param>
	/// <param name="pUuidDsaDest">Pointer to a <c>UUID</c> value that contains the destination directory system agent.</param>
	/// <param name="Options"><para>
	/// Contains a set of flags that provide additional data used to process the request. This can be zero or a combination of one or
	/// more of the following values.
	/// </para>
	/// <para>DS_REPUPD_ADD_REFERENCE</para>
	/// <para>A reference to the destination is added to the source server.</para>
	/// <para>DS_REPUPD_ASYNCHRONOUS_OPERATION</para>
	/// <para>The operation is performed asynchronously.</para>
	/// <para>DS_REPUPD_DELETE_REFERENCE</para>
	/// <para>A reference to the destination is removed from the source server.</para>
	/// <para>DS_REPUPD_WRITEABLE</para>
	/// <para>The reference to the replica added or removed is writable. Otherwise, it is read-only.</para></param>
	/// <returns>
	/// <para>If the function succeeds, <c>ERROR_SUCCESS</c> is returned.</para>
	/// <para>If the function fails, the return value can be one of the following.</para>
	/// </returns>
	/// <remarks>
	/// If both <c>DS_REPUPD_ADD_REFERENCE</c> and <c>DS_REPUPD_DELETE_REFERENCE</c> are set in the Options parameter, a reference to the
	/// destination is added if one does not already exist on the server. If a reference to the destination already exists, the reference
	/// is updated.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/nf-ntdsapi-dsreplicaupdaterefsa NTDSAPI DWORD DsReplicaUpdateRefsA(
	// HANDLE hDS, LPCSTR NameContext, LPCSTR DsaDest, const UUID *pUuidDsaDest, ULONG Options );
	[DllImport(Lib.NTDSApi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("ntdsapi.h", MSDNShortId = "158c7e73-0e6c-4b71-a87f-2f60f3db91cb")]
	public static extern Win32Error DsReplicaUpdateRefs(SafeDsHandle hDS, string NameContext, string DsaDest, in Guid pUuidDsaDest, DsReplUpdateOptions Options);

	/// <summary>
	/// The <c>DsReplicaVerifyObjects</c> function verifies all objects for a naming context with a source.
	/// </summary>
	/// <param name="hDS">Contains a directory service handle obtained from either the DSBind, DSBindWithCred, or DsBindWithSpn function.</param>
	/// <param name="NameContext">Pointer to a null-terminated string that contains the distinguished name of the naming context.</param>
	/// <param name="pUuidDsaSrc">Pointer to a <c>UUID</c> value that contains the <c>objectGuid</c> of the directory system agent object.</param>
	/// <param name="ulOptions"><para>Contains a set of flags that modify the behavior of the function. This can be zero or the following value.</para>
	/// <para>DS_EXIST_ADVISORY_MODE</para>
	/// <para>Do not delete objects in response to this function.</para></param>
	/// <returns>
	/// Returns <c>ERROR_SUCCESS</c> if successful or a Win32 error otherwise. Possible error values include the following.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/nf-ntdsapi-dsreplicaverifyobjectsa NTDSAPI DWORD
	// DsReplicaVerifyObjectsA( HANDLE hDS, LPCSTR NameContext, const UUID *pUuidDsaSrc, ULONG ulOptions );
	[DllImport(Lib.NTDSApi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("ntdsapi.h", MSDNShortId = "d0e139dc-6aaf-47e1-a76f-4e84f17aa7c6")]
	public static extern Win32Error DsReplicaVerifyObjects(SafeDsHandle hDS, string NameContext, in Guid pUuidDsaSrc, DsReplVerifyOptions ulOptions);

	/// <summary>
	/// <para>
	/// The <c>DsServerRegisterSpn</c> function composes two SPNs for a host-based service. The names are based on the DNS and NetBIOS
	/// names of the local computer. The function modifies the <c>servicePrincipalName</c> attribute of either a specified account or of
	/// the account associated with the calling thread. The function either registers or unregisters the SPNs.
	/// </para>
	/// <para>
	/// A host-based service is a service instance that provides services identified with its host computer, as distinguished from a
	/// replicable service where clients have no preference which host computer a service instance runs on.
	/// </para>
	/// </summary>
	/// <param name="Operation"><para>Specifies what operation <c>DsServerRegisterSpn</c> should perform. This parameter can have one of the following values.</para>
	/// <para>DS_SPN_ADD_SPN_OP</para>
	/// <para>Adds the SPNs to the user or computer account.</para>
	/// <para>DS_SPN_DELETE_SPN_OP</para>
	/// <para>Deletes the specified SPNs from the account.</para>
	/// <para>DS_SPN_REPLACE_SPN_OP</para>
	/// <para>Removes all SPNs currently registered on the user or computer account and replaces them with the new SPNs.</para></param>
	/// <param name="ServiceClass">Pointer to a constant null-terminated string specifying the class of the service. This parameter may be any string unique to that
	/// service; either the protocol name (for example, ldap) or the string form of a GUID will work.</param>
	/// <param name="UserObjectDN">Pointer to a constant null-terminated string specifying the distinguished name of a user or computer account object to write the
	/// SPNs to. If this parameter is <c>NULL</c>, <c>DsServerRegisterSpn</c> writes to the account object of the primary or impersonated
	/// user associated with the calling thread. If the thread is running in the security context of the LocalSystem account, the
	/// function writes to the account object of the local computer.</param>
	/// <returns>
	/// If the function successfully registers one or more SPNs, it returns <c>ERROR_SUCCESS</c>. Modification is performed permissively,
	/// so that adding a value that already exists does not return an error.
	/// </returns>
	/// <remarks>
	/// <para>The two SPNs composed by the <c>DsServerRegisterSpn</c> function have the following format:</para>
	/// <para>
	/// In one SPN, the host computer is the fully qualified DNS name of the local computer. In the other SPN, the host component is the
	/// NetBIOS name of the local computer.
	/// </para>
	/// <para>
	/// In most cases, the <c>DsServerRegisterSpn</c> caller must have domain administrator privileges to successfully modify the
	/// <c>servicePrincipalName</c> attribute of an account object. The exception to this rule is if the calling thread is running under
	/// the LocalSystem account, <c>DsServerRegisterSpn</c> is allowed if the UserObjectDN parameter is either <c>NULL</c> or specifies
	/// the distinguished name of the local computer account.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/nf-ntdsapi-dsserverregisterspna NTDSAPI DWORD DsServerRegisterSpnA(
	// DS_SPN_WRITE_OP Operation, LPCSTR ServiceClass, LPCSTR UserObjectDN );
	[DllImport(Lib.NTDSApi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("ntdsapi.h", MSDNShortId = "d95dfa55-f978-4d8d-a63d-cd1339769c79")]
	public static extern Win32Error DsServerRegisterSpn(DS_SPN_WRITE_OP Operation, string ServiceClass, [Optional] string? UserObjectDN);

	/// <summary>
	/// The <c>DsUnBind</c> function finds an RPC session with a domain controller and unbinds a handle to the directory service (DS).
	/// </summary>
	/// <param name="phDS">Pointer to a bind handle to the directory service. This handle is provided by a call to DsBind, DsBindWithCred, or DsBindWithSpn.</param>
	/// <returns><c>NO_ERROR</c></returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/nf-ntdsapi-dsunbinda NTDSAPI DWORD DsUnBindA( HANDLE *phDS );
	[DllImport(Lib.NTDSApi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("ntdsapi.h", MSDNShortId = "7106d67f-d421-4a7c-b775-440e5944f25e")]
	public static extern Win32Error DsUnBind(ref IntPtr phDS);

	/// <summary>
	/// The <c>DsWriteAccountSpn</c> function writes an array of service principal names (SPNs) to the <c>servicePrincipalName</c>
	/// attribute of a specified user or computer account object in Active Directory Domain Services. The function can either register or
	/// unregister the SPNs.
	/// </summary>
	/// <param name="hDS">Contains a directory service handle obtained from either the DSBind or DSBindWithCred function.</param>
	/// <param name="Operation">Contains one of the DS_SPN_WRITE_OP values that specifies the operation that <c>DsWriteAccountSpn</c> will perform.</param>
	/// <param name="pszAccount">Pointer to a constant null-terminated string that specifies the distinguished name of a user or computer object in Active
	/// Directory Domain Services. The caller must have write access to the <c>servicePrincipalName</c> property of this object.</param>
	/// <param name="cSpn">Specifies the number of SPNs in rpszSpn. If this value is zero, and Operation contains <c>DS_SPN_REPLACE_SPN_OP</c>, the function
	/// removes all values from the <c>servicePrincipalName</c> attribute of the specified account.</param>
	/// <param name="rpszSpn">Pointer to an array of constant null-terminated strings that specify the SPNs to be added to or removed from the account
	/// identified by the pszAccount parameter. The DsGetSpn function is used to compose SPNs for a service.</param>
	/// <returns>
	/// Returns <c>ERROR_SUCCESS</c> if successful or a Win32, RPC or directory service error if unsuccessful.
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>DsWriteAccountSpn</c> function registers the SPNs for one or more instances of a service. SPNs are used by clients, in
	/// conjunction with a trusted authentication service, to authenticate the service. To protect against security attacks where an
	/// application or service fraudulently registers an SPN that identifies some other service, the default DACL on user and computer
	/// accounts allows only domain administrators to register SPNs in most cases.
	/// </para>
	/// <para>
	/// One exception to this rule is that a service running under the LocalSystem account can call <c>DsWriteAccountSpn</c> to register
	/// a simple SPN of the form "ServiceClass/Host:Port" if the host specified in the SPN is the DNS or NetBIOS name of the computer on
	/// which the service is running.
	/// </para>
	/// <para>
	/// Another exception is that the default DACL on computer accounts allows callers to register SPNs on themselves, subject to certain
	/// constraints. For example, a computer account can have SPNs relative to its computername, of the form "host/&lt;computername&gt;".
	/// Because the computername is contained in the SPN, the SPN is allowable.
	/// </para>
	/// <para>
	/// None of the rules above apply if the DSA is configured to allow any SPN to be written. This reduces security, however, so it is
	/// not recommended.
	/// </para>
	/// <para>
	/// SPNs passed to <c>DsWriteAccountSpn</c> are actually added to the <c>Service-Principal-Name</c> attribute of the computer object
	/// in pszAccount. This call is made using RPC to the domain controller where the account object is stored so it can securely enforce
	/// policy on what SPNs are allowed on the account. Using LDAP to write directly to the SPN property is not allowed; all writes must
	/// come through this RPC call. Reads using LDAP are allowed.
	/// </para>
	/// <para>Permissions required to set SPNs</para>
	/// <para>
	/// To write an arbitrary SPN on an account, the writer requires the "Write ServicePrincipalName" right, which is not granted by
	/// default to the person who created the account. That person has the 'Write validated SPN" right(present only on machine accounts).
	/// </para>
	/// <para>Below is a summary of rights per user on machine accounts:</para>
	/// <list type="table">
	///   <listheader>
	///     <term>User Type</term>
	///     <term>Rights</term>
	///   </listheader>
	///   <item>
	///     <term>Person creating the Account</term>
	///     <term>Write validated SPN</term>
	///   </item>
	///   <item>
	///     <term>Account Operators</term>
	///     <term>Write SPN and Write Validated SPN</term>
	///   </item>
	///   <item>
	///     <term>Authenticated Users</term>
	///     <term>None</term>
	///   </item>
	///   <item>
	///     <term>(self)</term>
	///     <term>Write Validated SPN</term>
	///   </item>
	/// </list>
	/// <para>
	/// On user accounts there is no "Validated SPN" property or "Write SPN" right. Rather, the "Write public information" property set
	/// grants the ability to create arbitrary SPNs.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/nf-ntdsapi-dswriteaccountspna NTDSAPI DWORD DsWriteAccountSpnA(
	// HANDLE hDS, DS_SPN_WRITE_OP Operation, LPCSTR pszAccount, DWORD cSpn, LPCSTR *rpszSpn );
	[DllImport(Lib.NTDSApi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("ntdsapi.h", MSDNShortId = "2b555f6b-643d-4fa0-9aca-701e6b3313fa")]
	public static extern Win32Error DsWriteAccountSpn(SafeDsHandle hDS, DS_SPN_WRITE_OP Operation, string pszAccount, uint cSpn, SpnArrayHandle rpszSpn);

	/// <summary>
	/// The <c>DsReplicaGetInfo2</c> function retrieves replication state data from the directory service. This function allows paging of
	/// results in cases where there are more than 1000 entries to retrieve.
	/// </summary>
	/// <param name="hDS">Contains a directory service handle obtained from either the DSBind or DSBindWithCred function.</param>
	/// <param name="InfoType">Contains one of the DS_REPL_INFO_TYPE values that specifies the type of replication data to retrieve. This value also determines
	/// which type of structure is returned in ppInfo.</param>
	/// <param name="pszObject"><para>
	/// Pointer to a constant null-terminated Unicode string that identifies the object to retrieve replication data for. The meaning of
	/// this parameter depends on the value of the InfoType parameter. The following are possible value codes.
	/// </para>
	/// <para>DS_REPL_INFO_NEIGHBORS</para>
	/// <para>pszObject identifies the naming context for which replication neighbors are requested.</para>
	/// <para>DS_REPL_INFO_CURSORS_FOR_NC</para>
	/// <para>pszObject identifies the naming context for which replication cursors are requested.</para>
	/// <para>DS_REPL_INFO_METADATA_FOR_OBJ</para>
	/// <para>pszObject identifies the object for which replication metadata is requested.</para>
	/// <para>DS_REPL_INFO_KCC_DSA_CONNECT_FAILURES</para>
	/// <para>pszObject must be <c>NULL</c>.</para>
	/// <para>DS_REPL_INFO_KCC_DSA_LINK_FAILURES</para>
	/// <para>pszObject must be <c>NULL</c>.</para>
	/// <para>DS_REPL_INFO_PENDING_OPS</para>
	/// <para>pszObject must be <c>NULL</c>.</para>
	/// <para>DS_REPL_INFO_METADATA_FOR_ATTR_VALUE</para>
	/// <para>pszObject identifies the object for which attribute replication metadata is requested.</para>
	/// <para>DS_REPL_INFO_CURSORS_2_FOR_NC</para>
	/// <para>DS_REPL_INFO_CURSORS_3_FOR_NC</para>
	/// <para>DS_REPL_INFO_METADATA_2_FOR_OBJ</para>
	/// <para>pszObject identifies the object for which replication metadata is requested.</para>
	/// <para>DS_REPL_INFO_METADATA_2_FOR_ATTR_VALUE</para>
	/// <para>pszObject identifies the object for which attribute replication metadata is requested.</para></param>
	/// <param name="puuidForSourceDsaObjGuid">Pointer to a <c>GUID</c> value that identifies a specific replication source. If this parameter is not <c>NULL</c> and the
	/// InfoType parameter contains <c>DS_REPL_INFO_NEIGHBORS</c>, only neighbor data for the source corresponding to the nTDSDSA object
	/// with the given <c>objectGuid</c> in the directory is returned. This parameter is ignored if <c>NULL</c> or if the InfoType
	/// parameter is anything other than <c>DS_REPL_INFO_NEIGHBORS</c>.</param>
	/// <param name="pszAttributeName"><para>
	/// Pointer to a null-terminated Unicode string that contains the name of the specific attribute to retrieve replication data for.
	/// </para>
	/// <para>This parameter is only used if the InfoType parameter contains one of the following values.</para>
	/// <para>DS_REPL_INFO_METADATA_FOR_ATTR_VALUE</para>
	/// <para>DS_REPL_INFO_METADATA_2_FOR_ATTR_VALUE</para></param>
	/// <param name="pszValue">Pointer to a null-terminated Unicode string that contains the distinguished name value to match. If the requested attribute is a
	/// distinguished name type value, this function return the attributes that contain the specified value.</param>
	/// <param name="dwFlags"><para>Contains a set of flags that modify the behavior of the function. This parameter can be zero or the following value.</para>
	/// <para>DS_REPL_INFO_FLAG_IMPROVE_LINKED_ATTRS</para>
	/// <para>
	/// Causes the attribute metadata to account for metadata on the attribute's linked values. The resulting vector represents changes
	/// for all attributes. This modified vector is useful for clients that expect all attributes and metadata to be included in the
	/// attribute metadata vector.
	/// </para></param>
	/// <param name="dwEnumerationContext"><para>Contains the index of the next entry to retrieve. This parameter must be set to zero the first time this function is called.</para>
	/// <para>This parameter is only used if the InfoType parameter contains one of the following values.</para>
	/// <para>DS_REPL_INFO_CURSORS_2_FOR_NC</para>
	/// <para>DS_REPL_INFO_CURSORS_3_FOR_NC</para>
	/// <para>DS_REPL_INFO_METADATA_FOR_ATTR_VALUE</para>
	/// <para>DS_REPL_INFO_METADATA_2_FOR_ATTR_VALUE</para>
	/// <para>
	/// This function will retrieve a maximum of 1000 entries on each call. If after calling this function, more entries are available,
	/// the <c>dwEnumerationContext</c> member of the retrieved structure will contain the index of the next entry to retrieve. The
	/// <c>dwEnumerationContext</c> member of the retrieved structure is then used as the dwEnumerationContext parameter in the next call
	/// to this function. When all of the entries have been retrieved, the <c>dwEnumerationContext</c> member of the retrieved structure
	/// will contain -1. If -1 is passed for this parameter, this function will return <c>ERROR_NO_MORE_ITEMS</c>.
	/// </para></param>
	/// <param name="ppInfo"><para>
	/// Address of a structure pointer that receives the requested data. The value of the InfoType parameter determines the format of
	/// this structure. For more information and a list of possible InfoType values and the corresponding structure types, see DS_REPL_INFO_TYPE.
	/// </para>
	/// <para>The caller must free this memory when it is no longer required by calling DsReplicaFreeInfo.</para></param>
	/// <returns>
	/// Returns <c>ERROR_SUCCESS</c> if successful or a Win32 or RPC error otherwise. The following are possible error codes.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/nf-ntdsapi-dsreplicagetinfo2w NTDSAPI DWORD DsReplicaGetInfo2W(
	// HANDLE hDS, DS_REPL_INFO_TYPE InfoType, LPCWSTR pszObject, UUID *puuidForSourceDsaObjGuid, LPCWSTR pszAttributeName, LPCWSTR
	// pszValue, DWORD dwFlags, DWORD dwEnumerationContext, VOID **ppInfo );
	[DllImport(Lib.NTDSApi, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
	[PInvokeData("ntdsapi.h", MSDNShortId = "5735d91d-1b7d-4dc6-b6c6-61ba38ebe50d")]
	private static unsafe extern Win32Error DsReplicaGetInfo2W(SafeDsHandle hDS, DS_REPL_INFO_TYPE InfoType, [Optional] string? pszObject, [Optional] Guid* puuidForSourceDsaObjGuid, [Optional] string? pszAttributeName,
		[Optional] string? pszValue, DsReplInfoFlags dwFlags, uint dwEnumerationContext, out SafeDsReplicaInfo ppInfo);

	/// <summary>Provides a handle to a domain controller info structure.</summary>
	[AutoHandle]
	public partial struct DCInfoHandle
	{
		/// <summary>Gets a list of stored structures from this handle.</summary>
		/// <typeparam name="T">The type of structure found in the list.</typeparam>
		/// <param name="count">The count.</param>
		/// <returns>The list of structures.</returns>
		public IEnumerable<T> ToIEnum<T>(uint count) where T : struct => handle.ToIEnum<T>((int)count);
	}

	/// <summary>Indicates that the structure can be passed to DsGetDomainControllerInfo.</summary>
	public interface IDsGetDCResult { }

	/// <summary>
	/// The <c>DS_DOMAIN_CONTROLLER_INFO_1</c> structure contains data about a domain controller. This structure is returned by the
	/// DsGetDomainControllerInfo function.
	/// </summary>
	/// <seealso cref="Vanara.PInvoke.NTDSApi.IDsGetDCResult" />
	/// <remarks>
	/// The DsGetDomainControllerInfo function can return different versions of this structure. For more information and a list of the
	/// currently supported versions, see the InfoLevel parameter of <c>DsGetDomainControllerInfo</c>.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/ns-ntdsapi-ds_domain_controller_info_1a typedef struct
	// DS_DOMAIN_CONTROLLER_INFO_1A { #if ... CHAR *NetbiosName; #if ... CHAR *DnsHostName; #if ... CHAR *SiteName; #if ... CHAR
	// *ComputerObjectName; #if ... CHAR *ServerObjectName; #else PSTR NetbiosName; #endif #else PSTR DnsHostName; #endif #else PSTR
	// SiteName; #endif #else PSTR ComputerObjectName; #endif #else PSTR ServerObjectName; #endif BOOL fIsPdc; BOOL fDsEnabled; } *PDS_DOMAIN_CONTROLLER_INFO_1A;
	[PInvokeData("ntdsapi.h", MSDNShortId = "6cc829ac-2aa6-49ef-b1ab-9c249249e0d6")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct DS_DOMAIN_CONTROLLER_INFO_1 : IDsGetDCResult
	{
		/// <summary>
		/// Pointer to a null-terminated string that specifies the NetBIOS name of the domain controller.
		/// </summary>
		public PTSTR NetbiosName;

		/// <summary>
		/// Pointer to a null-terminated string that specifies the DNS host name of the domain controller.
		/// </summary>
		public PTSTR DnsHostName;

		/// <summary>
		/// Pointer to a null-terminated string that specifies the site to which the domain controller belongs.
		/// </summary>
		public PTSTR SiteName;

		/// <summary>
		/// Pointer to a null-terminated string that specifies the name of the computer object on the domain controller.
		/// </summary>
		public PTSTR ComputerObjectName;

		/// <summary>
		/// Pointer to a null-terminated string that specifies the name of the server object on the domain controller.
		/// </summary>
		public PTSTR ServerObjectName;

		/// <summary>
		/// A Boolean value that indicates whether or not this domain controller is the primary domain controller. If this value is TRUE,
		/// the domain controller is the primary domain controller; otherwise, the domain controller is not the primary domain controller.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool fIsPdc;

		/// <summary>
		/// A Boolean value that indicates whether or not the domain controller is enabled. If this value is TRUE, the domain controller
		/// is enabled; otherwise, it is not enabled.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool fDsEnabled;
	}

	/// <summary>
	/// The <c>DS_DOMAIN_CONTROLLER_INFO_2</c> structure contains data about a domain controller. This structure is returned by the
	/// DsGetDomainControllerInfo function.
	/// </summary>
	/// <seealso cref="Vanara.PInvoke.NTDSApi.IDsGetDCResult" />
	/// <remarks>
	/// The DsGetDomainControllerInfo function can return different versions of this structure. For more information and a list of the
	/// currently supported versions, see the InfoLevel parameter of <c>DsGetDomainControllerInfo</c>.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/ns-ntdsapi-ds_domain_controller_info_2a typedef struct
	// DS_DOMAIN_CONTROLLER_INFO_2A { #if ... CHAR *NetbiosName; #if ... CHAR *DnsHostName; #if ... CHAR *SiteName; #if ... CHAR
	// *SiteObjectName; #if ... CHAR *ComputerObjectName; #if ... CHAR *ServerObjectName; #if ... CHAR *NtdsDsaObjectName; #else PSTR
	// NetbiosName; #endif #else PSTR DnsHostName; #endif #else PSTR SiteName; #endif #else PSTR SiteObjectName; #endif #else PSTR
	// ComputerObjectName; #endif #else PSTR ServerObjectName; #endif #else PSTR NtdsDsaObjectName; #endif BOOL fIsPdc; BOOL
	// fDsEnabled; BOOL fIsGc; GUID SiteObjectGuid; GUID ComputerObjectGuid; GUID ServerObjectGuid; GUID NtdsDsaObjectGuid; } *PDS_DOMAIN_CONTROLLER_INFO_2A;
	[PInvokeData("ntdsapi.h", MSDNShortId = "9d45b732-363d-4b20-ae5c-e9e76264bf1f")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct DS_DOMAIN_CONTROLLER_INFO_2 : IDsGetDCResult
	{
		/// <summary>
		/// Pointer to a null-terminated string that specifies the NetBIOS name of the domain controller.
		/// </summary>
		public PTSTR NetbiosName;

		/// <summary>
		/// Pointer to a null-terminated string that specifies the DNS host name of the domain controller.
		/// </summary>
		public PTSTR DnsHostName;

		/// <summary>
		/// Pointer to a null-terminated string that specifies the site to which the domain controller belongs.
		/// </summary>
		public PTSTR SiteName;

		/// <summary>
		/// Pointer to a null-terminated string that specifies the name of the site object on the domain controller.
		/// </summary>
		public PTSTR SiteObjectName;

		/// <summary>
		/// Pointer to a null-terminated string that specifies the name of the computer object on the domain controller.
		/// </summary>
		public PTSTR ComputerObjectName;

		/// <summary>
		/// Pointer to a null-terminated string that specifies the name of the server object on the domain controller.
		/// </summary>
		public PTSTR ServerObjectName;

		/// <summary>
		/// Pointer to a null-terminated string that specifies the name of the NTDS DSA object on the domain controller.
		/// </summary>
		public PTSTR NtdsDsaObjectName;

		/// <summary>
		/// A Boolean value that indicates whether or not this domain controller is the primary domain controller. If this value is TRUE,
		/// the domain controller is the primary domain controller; otherwise, the domain controller is not the primary domain controller.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool fIsPdc;

		/// <summary>
		/// A Boolean value that indicates whether or not the domain controller is enabled. If this value is TRUE, the domain controller
		/// is enabled; otherwise, it is not enabled.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool fDsEnabled;

		/// <summary>
		/// A Boolean value that indicates whether or not the domain controller is global catalog server. If this value is TRUE, the
		/// domain controller is a global catalog server; otherwise, it is not a global catalog server.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool fIsGc;

		/// <summary>
		/// Contains the GUID for the site object on the domain controller.
		/// </summary>
		public Guid SiteObjectGuid;

		/// <summary>
		/// Contains the GUID for the computer object on the domain controller.
		/// </summary>
		public Guid ComputerObjectGuid;

		/// <summary>
		/// Contains the GUID for the server object on the domain controller.
		/// </summary>
		public Guid ServerObjectGuid;

		/// <summary>
		/// Contains the GUID for the NTDS DSA object on the domain controller.
		/// </summary>
		public Guid NtdsDsaObjectGuid;
	}

	/// <summary>
	/// The <c>DS_DOMAIN_CONTROLLER_INFO_3</c> structure contains data about a domain controller. This structure is returned by the
	/// DsGetDomainControllerInfo function.
	/// </summary>
	/// <seealso cref="Vanara.PInvoke.NTDSApi.IDsGetDCResult" />
	/// <remarks>
	/// The DsGetDomainControllerInfo function can return different versions of this structure. For more information and a list of the
	/// currently supported versions, see the InfoLevel parameter of <c>DsGetDomainControllerInfo</c>.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/ns-ntdsapi-ds_domain_controller_info_3a typedef struct
	// DS_DOMAIN_CONTROLLER_INFO_3A { #if ... CHAR *NetbiosName; #if ... CHAR *DnsHostName; #if ... CHAR *SiteName; #if ... CHAR
	// *SiteObjectName; #if ... CHAR *ComputerObjectName; #if ... CHAR *ServerObjectName; #if ... CHAR *NtdsDsaObjectName; #else PSTR
	// NetbiosName; #endif #else PSTR DnsHostName; #endif #else PSTR SiteName; #endif #else PSTR SiteObjectName; #endif #else PSTR
	// ComputerObjectName; #endif #else PSTR ServerObjectName; #endif #else PSTR NtdsDsaObjectName; #endif BOOL fIsPdc; BOOL
	// fDsEnabled; BOOL fIsGc; BOOL fIsRodc; GUID SiteObjectGuid; GUID ComputerObjectGuid; GUID ServerObjectGuid; GUID NtdsDsaObjectGuid;
	// } *PDS_DOMAIN_CONTROLLER_INFO_3A;
	[PInvokeData("ntdsapi.h", MSDNShortId = "510f458e-4c08-41c7-b290-1372ac9c8beb")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct DS_DOMAIN_CONTROLLER_INFO_3 : IDsGetDCResult
	{
		/// <summary>
		/// Pointer to a null-terminated string that specifies the NetBIOS name of the domain controller.
		/// </summary>
		public PTSTR NetbiosName;

		/// <summary>
		/// Pointer to a null-terminated string that specifies the DNS host name of the domain controller.
		/// </summary>
		public PTSTR DnsHostName;

		/// <summary>
		/// Pointer to a null-terminated string that specifies the site to which the domain controller belongs.
		/// </summary>
		public PTSTR SiteName;

		/// <summary>
		/// Pointer to a null-terminated string that specifies the name of the site object on the domain controller.
		/// </summary>
		public PTSTR SiteObjectName;

		/// <summary>
		/// Pointer to a null-terminated string that specifies the name of the computer object on the domain controller.
		/// </summary>
		public PTSTR ComputerObjectName;

		/// <summary>
		/// Pointer to a null-terminated string that specifies the name of the server object on the domain controller.
		/// </summary>
		public PTSTR ServerObjectName;

		/// <summary>
		/// Pointer to a null-terminated string that specifies the name of the NTDS DSA object on the domain controller.
		/// </summary>
		public PTSTR NtdsDsaObjectName;

		/// <summary>
		/// A Boolean value that indicates whether or not this domain controller is the primary domain controller. If this value is TRUE,
		/// the domain controller is the primary domain controller; otherwise, the domain controller is not the primary domain controller.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool fIsPdc;

		/// <summary>
		/// A Boolean value that indicates whether or not the domain controller is enabled. If this value is TRUE, the domain controller
		/// is enabled; otherwise, it is not enabled.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool fDsEnabled;

		/// <summary>
		/// A Boolean value that indicates whether or not the domain controller is global catalog server. If this value is TRUE, the
		/// domain controller is a global catalog server; otherwise, it is not a global catalog server.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool fIsGc;

		/// <summary>
		/// A Boolean value that indicates if the domain controller is a read-only domain controller. If this value is TRUE, the domain
		/// controller is a read-only domain controller; otherwise, it is not a read-only domain controller.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool fIsRodc;

		/// <summary>
		/// Contains the GUID for the site object on the domain controller.
		/// </summary>
		public Guid SiteObjectGuid;

		/// <summary>
		/// Contains the GUID for the computer object on the domain controller.
		/// </summary>
		public Guid ComputerObjectGuid;

		/// <summary>
		/// Contains the GUID for the server object on the domain controller.
		/// </summary>
		public Guid ServerObjectGuid;

		/// <summary>
		/// Contains the GUID for the NTDS DSA object on the domain controller.
		/// </summary>
		public Guid NtdsDsaObjectGuid;
	}

	/// <summary>
	/// Used with the DsCrackNames function to contain the names converted by the function.
	/// </summary>
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	[PInvokeData("NTDSApi.h", MSDNShortId = "ms676246")]
	public struct DS_NAME_RESULT
	{
		/// <summary>Contains the number of elements in the rItems array.</summary>
		public uint cItems;

		/// <summary>
		/// Contains an array of DS_NAME_RESULT_ITEM structure pointers. Each element of this array represents a single converted name.
		/// </summary>
		public IntPtr rItems; // PDS_NAME_RESULT_ITEM

		/// <summary>
		/// Enumeration of DS_NAME_RESULT_ITEM structures. Each element of this array represents a single converted name.
		/// </summary>
		/// <value>The items.</value>
		public DS_NAME_RESULT_ITEM[]? Items => rItems.ToArray<DS_NAME_RESULT_ITEM>((int)cItems);
	}

	/// <summary>
	/// Contains a name converted by the DsCrackNames function, along with associated error and domain data.
	/// </summary>
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	[PInvokeData("NTDSApi.h", MSDNShortId = "ms676246")]
	public struct DS_NAME_RESULT_ITEM
	{
		/// <summary>
		/// Contains one of the DS_NAME_ERROR values that indicates the status of this name conversion.
		/// </summary>
		public DS_NAME_ERROR status;

		/// <summary>
		/// A string that specifies the DNS domain in which the object resides. This member will contain valid data if status contains
		/// DS_NAME_NO_ERROR or DS_NAME_ERROR_DOMAIN_ONLY.
		/// </summary>
		public string pDomain;

		/// <summary>A string that specifies the newly formatted object name.</summary>
		public string pName;

		/// <summary>
		/// Returns a <see cref="string" /> that represents this instance.
		/// </summary>
		/// <returns>A <see cref="string" /> that represents this instance.</returns>
		public override string ToString() => status == DS_NAME_ERROR.DS_NAME_NO_ERROR ? pName : $"{status}";
	}

	/// <summary>
	/// The <c>DS_REPL_ATTR_META_DATA</c> structure is used with the DsReplicaGetInfo and DsReplicaGetInfo2 functions to contain
	/// replication state data for an object attribute.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/ns-ntdsapi-_ds_repl_attr_meta_data typedef struct
	// _DS_REPL_ATTR_META_DATA { PWSTR pszAttributeName; DWORD dwVersion; FILETIME ftimeLastOriginatingChange; UUID
	// uuidLastOriginatingDsaInvocationID; USN usnOriginatingChange; USN usnLocalChange; } DS_REPL_ATTR_META_DATA;
	[PInvokeData("ntdsapi.h", MSDNShortId = "27ccc1c9-03d7-4d13-b9ec-65d6b8bdfd37")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct DS_REPL_ATTR_META_DATA
	{
		/// <summary>
		/// Pointer to a null-terminated Unicode string that contains the LDAP display name of the attribute corresponding to this metadata.
		/// </summary>
		public string pszAttributeName;

		/// <summary>
		/// Contains the version of this attribute. Each originating modification of the attribute increases this value by one.
		/// Replication of a modification does not affect the version.
		/// </summary>
		public uint dwVersion;

		/// <summary>
		/// Contains the time at which the last originating change was made to this attribute. Replication of the change does not affect
		/// this value.
		/// </summary>
		public FILETIME ftimeLastOriginatingChange;

		/// <summary>
		/// Contains the invocation identification of the server on which the last change was made to this attribute. Replication of the
		/// change does not affect this value.
		/// </summary>
		public Guid uuidLastOriginatingDsaInvocationID;

		/// <summary>
		/// Contains the update sequence number (USN) on the originating server at which the last change to this attribute was made.
		/// Replication of the change does not affect this value.
		/// </summary>
		public long usnOriginatingChange;

		/// <summary>
		/// Contains the USN on the destination server (the server from which the DsReplicaGetInfo function retrieved the metadata) at
		/// which the last change to this attribute was applied. This value typically is different on all servers.
		/// </summary>
		public long usnLocalChange;
	}

	/// <summary>
	/// The <c>DS_REPL_ATTR_META_DATA_2</c> structure is used with the DsReplicaGetInfo and DsReplicaGetInfo2 functions to contain
	/// replication state data for an object attribute.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/ns-ntdsapi-_ds_repl_attr_meta_data_2 typedef struct
	// _DS_REPL_ATTR_META_DATA_2 { PWSTR pszAttributeName; DWORD dwVersion; FILETIME ftimeLastOriginatingChange; UUID
	// uuidLastOriginatingDsaInvocationID; USN usnOriginatingChange; USN usnLocalChange; PWSTR pszLastOriginatingDsaDN; } DS_REPL_ATTR_META_DATA_2;
	[PInvokeData("ntdsapi.h", MSDNShortId = "392457b7-df69-44d0-82b2-8381d5877354")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct DS_REPL_ATTR_META_DATA_2
	{
		/// <summary>
		/// Pointer to a null-terminated Unicode string that contains the LDAP display name of the attribute that corresponds to this metadata.
		/// </summary>
		public string pszAttributeName;

		/// <summary>
		/// Contains the version of this attribute. Each originating modification of the attribute increases this value by one.
		/// Replication of a modification does not affect the version.
		/// </summary>
		public uint dwVersion;

		/// <summary>
		/// Contains the time at which the last originating change was made to this attribute. Replication of the change does not affect
		/// this value.
		/// </summary>
		public FILETIME ftimeLastOriginatingChange;

		/// <summary>
		/// Contains the invocation identification of the server on which the last change was made to this attribute. Replication of the
		/// change does not affect this value.
		/// </summary>
		public Guid uuidLastOriginatingDsaInvocationID;

		/// <summary>
		/// Contains the update sequence number (USN) on the originating server at which the last change to this attribute was made.
		/// Replication of the change does not affect this value.
		/// </summary>
		public long usnOriginatingChange;

		/// <summary>
		/// Contains the USN on the destination server (the server from which the DsReplicaGetInfo function retrieved the metadata) at
		/// which the last change to this attribute was applied. This value typically is different on all servers.
		/// </summary>
		public long usnLocalChange;

		/// <summary>
		/// Pointer to a null-terminated Unicode string that contains the distinguished name of the directory system agent server that
		/// originated the last replication.
		/// </summary>
		public string pszLastOriginatingDsaDN;
	}

	/// <summary>
	/// The <c>DS_REPL_ATTR_META_DATA_BLOB</c> structure is used to contain replication state data for an object attribute. This
	/// structure is similar to the DS_REPL_ATTR_META_DATA_2 structure, but is obtained from the Lightweight Directory Access Protocol
	/// API functions when obtaining binary data for the <c>msDS-ReplAttributeMetaData</c> attribute.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/ns-ntdsapi-_ds_repl_attr_meta_data_blob typedef struct
	// _DS_REPL_ATTR_META_DATA_BLOB { DWORD oszAttributeName; DWORD dwVersion; FILETIME ftimeLastOriginatingChange; UUID
	// uuidLastOriginatingDsaInvocationID; USN usnOriginatingChange; USN usnLocalChange; DWORD oszLastOriginatingDsaDN; } DS_REPL_ATTR_META_DATA_BLOB;
	[PInvokeData("ntdsapi.h", MSDNShortId = "eee12de1-287a-4e76-9a9c-37e6b967971f")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct DS_REPL_ATTR_META_DATA_BLOB
	{
		/// <summary>
		/// Contains the offset, in bytes, from the address of this structure to a null-terminated Unicode string that contains the LDAP
		/// display name of the attribute corresponding to this metadata. A value of zero indicates an empty or <c>NULL</c> string.
		/// </summary>
		public uint oszAttributeName;

		/// <summary>
		/// Contains the version of this attribute. Each originating modification of the attribute increases this value by one.
		/// Replication of a modification does not affect the version.
		/// </summary>
		public uint dwVersion;

		/// <summary>
		/// Contains the time at which the last originating change was made to this attribute. Replication of the change does not affect
		/// this value.
		/// </summary>
		public FILETIME ftimeLastOriginatingChange;

		/// <summary>
		/// Contains the invocation identification of the server on which the last change was made to this attribute. Replication of the
		/// change does not affect this value.
		/// </summary>
		public Guid uuidLastOriginatingDsaInvocationID;

		/// <summary>
		/// Contains the update sequence number (USN) on the originating server at which the last change to this attribute was made.
		/// Replication of the change does not affect this value.
		/// </summary>
		public long usnOriginatingChange;

		/// <summary>
		/// Contains the USN on the destination server (the server from which the DsReplicaGetInfo function retrieved the metadata) at
		/// which the last change to this attribute was applied. This value typically is different on all servers.
		/// </summary>
		public long usnLocalChange;

		/// <summary>
		/// Contains the offset, in bytes, from the address of this structure to a null-terminated Unicode string that contains the
		/// distinguished name of the directory system agent server that originated the last replication. A value of zero indicates an
		/// empty or <c>NULL</c> string.
		/// </summary>
		public uint oszLastOriginatingDsaDN;
	}

	/// <summary>
	/// The <c>DS_REPL_ATTR_VALUE_META_DATA</c> structure is used with the DsReplicaGetInfo2 function to provide metadata for a
	/// collection of attribute values.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/ns-ntdsapi-_ds_repl_attr_value_meta_data typedef struct
	// _DS_REPL_ATTR_VALUE_META_DATA { DWORD cNumEntries; DWORD dwEnumerationContext; #if ... DS_REPL_VALUE_META_DATA rgMetaData[]; #else
	// DS_REPL_VALUE_META_DATA rgMetaData[1]; #endif } DS_REPL_ATTR_VALUE_META_DATA;
	[PInvokeData("ntdsapi.h", MSDNShortId = "b13cdd31-d154-4539-81d6-d7a449e2b3d5")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct DS_REPL_ATTR_VALUE_META_DATA
	{
		/// <summary>
		/// Contains the number of elements in the <c>rgMetaData</c> array.
		/// </summary>
		public uint cNumEntries;

		/// <summary>
		/// Contains the zero-based index of the next entry to retrieve if more entries are available. This value is passed for the
		/// dwEnumerationContext parameter in the next call to DsReplicaGetInfo2 to retrieve the next block of entries. If no more
		/// entries are available, this member contains -1.
		/// </summary>
		public uint dwEnumerationContext;

		/// <summary>
		/// Contains an array of DS_REPL_VALUE_META_DATA structures that contain the individual attribute replication values. The
		/// cNumEntries member contains the number of elements in this array.
		/// </summary>
		public IntPtr _rgMetaData;

		/// <summary>
		/// Gets an array of DS_REPL_VALUE_META_DATA structures that contain the individual attribute replication values.
		/// </summary>
		/// <value>The rg meta data.</value>
		public DS_REPL_VALUE_META_DATA[]? rgMetaData => _rgMetaData.ToArray<DS_REPL_VALUE_META_DATA>((int)cNumEntries);
	}

	/// <summary>
	/// The <c>DS_REPL_ATTR_VALUE_META_DATA_2</c> structure is used with the DsReplicaGetInfo2 function to provide metadata for a
	/// collection of attribute values.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/ns-ntdsapi-_ds_repl_attr_value_meta_data_2 typedef struct
	// _DS_REPL_ATTR_VALUE_META_DATA_2 { DWORD cNumEntries; DWORD dwEnumerationContext; #if ... DS_REPL_VALUE_META_DATA_2 rgMetaData[];
	// #else DS_REPL_VALUE_META_DATA_2 rgMetaData[1]; #endif } DS_REPL_ATTR_VALUE_META_DATA_2;
	[PInvokeData("ntdsapi.h", MSDNShortId = "2022362a-e2f7-4cfd-a512-cfe29e5d439d")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct DS_REPL_ATTR_VALUE_META_DATA_2
	{
		/// <summary>
		/// Contains the number of elements in the <c>rgMetaData</c> array.
		/// </summary>
		public uint cNumEntries;

		/// <summary>
		/// Contains the zero-based index of the next entry to retrieve if more entries are available. This value is passed for the
		/// dwEnumerationContext parameter in the next call to DsReplicaGetInfo2 to retrieve the next block of entries. If no more
		/// entries are available, this member contains -1.
		/// </summary>
		public uint dwEnumerationContext;

		/// <summary>
		/// Contains an array of DS_REPL_VALUE_META_DATA_2 structures that contain the individual attribute replication values. The
		/// cNumEntries member contains the number of elements in this array.
		/// </summary>
		public IntPtr _rgMetaData;

		/// <summary>
		/// Gets an array of DS_REPL_VALUE_META_DATA_2 structures that contain the individual attribute replication values.
		/// </summary>
		/// <value>The rg meta data.</value>
		public DS_REPL_VALUE_META_DATA_2[]? rgMetaData => _rgMetaData.ToArray<DS_REPL_VALUE_META_DATA_2>((int)cNumEntries);
	}

	/// <summary>
	/// Provides metadata for a collection of attribute replication values.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/ns-ntdsapi-_ds_repl_attr_value_meta_data_ext typedef struct
	// _DS_REPL_ATTR_VALUE_META_DATA_EXT { DWORD cNumEntries; DWORD dwEnumerationContext; #if ... DS_REPL_VALUE_META_DATA_EXT
	// rgMetaData[]; #else DS_REPL_VALUE_META_DATA_EXT rgMetaData[1]; #endif } DS_REPL_ATTR_VALUE_META_DATA_EXT;
	[PInvokeData("ntdsapi.h", MSDNShortId = "CA41C6BF-A485-4AC7-B761-3A07159C2FF1")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct DS_REPL_ATTR_VALUE_META_DATA_EXT
	{
		/// <summary>The number of elements in the <c>rgMetaData</c> array.</summary>
		public uint cNumEntries;

		/// <summary>
		/// The zero-based index of the next entry to retrieve if more entries are available. This value is passed for the
		/// dwEnumerationContext parameter in the next call to DsReplicaGetInfo2 to retrieve the next block of entries. If no more
		/// entries are available, this member contains -1.
		/// </summary>
		public uint dwEnumerationContext;

		/// <summary>
		/// Contains an array of DS_REPL_VALUE_META_DATA_EXT structures that contain the individual attribute replication values. The
		/// cNumEntries member contains the number of elements in this array.
		/// </summary>
		public IntPtr _rgMetaData;

		/// <summary>
		/// Gets an array of DS_REPL_VALUE_META_DATA_EXT structures that contain the individual attribute replication values.
		/// </summary>
		/// <value>The rg meta data.</value>
		public DS_REPL_VALUE_META_DATA_EXT[]? rgMetaData => _rgMetaData.ToArray<DS_REPL_VALUE_META_DATA_EXT>((int)cNumEntries);
	}

	/// <summary>
	/// The <c>DS_REPL_CURSOR</c> structure contains inbound replication state data with respect to all replicas of a given naming
	/// context, as returned by the DsReplicaGetInfo and DsReplicaGetInfo2 functions.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/ns-ntdsapi-_ds_repl_cursor typedef struct _DS_REPL_CURSOR { UUID
	// uuidSourceDsaInvocationID; USN usnAttributeFilter; } DS_REPL_CURSOR;
	[PInvokeData("ntdsapi.h", MSDNShortId = "ab4ee8d8-5ccd-4f3f-a1c0-de78c65a10d3")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct DS_REPL_CURSOR
	{
		/// <summary>
		/// Contains the invocation identifier of the originating server to which the <c>usnAttributeFilter</c> corresponds.
		/// </summary>
		public Guid uuidSourceDsaInvocationID;

		/// <summary>
		/// Contains the maximum update sequence number to which the destination server can indicate that it has recorded all changes
		/// originated by the given server at update sequence numbers less than, or equal to, this update sequence number. This is used
		/// to filter changes at replication source servers that the destination server has already applied.
		/// </summary>
		public long usnAttributeFilter;
	}

	/// <summary>
	/// The <c>DS_REPL_CURSOR_2</c> structure contains inbound replication state data with respect to all replicas of a given naming
	/// context, as returned by the DsReplicaGetInfo2 function. This structure is an enhanced version of the DS_REPL_CURSOR structure.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/ns-ntdsapi-_ds_repl_cursor_2 typedef struct _DS_REPL_CURSOR_2 { UUID
	// uuidSourceDsaInvocationID; USN usnAttributeFilter; FILETIME ftimeLastSyncSuccess; } DS_REPL_CURSOR_2;
	[PInvokeData("ntdsapi.h", MSDNShortId = "ff839372-41f0-499a-9582-59ace02f1485")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct DS_REPL_CURSOR_2
	{
		/// <summary>
		/// Contains the invocation identifier of the originating server to which the <c>usnAttributeFilter</c> corresponds.
		/// </summary>
		public Guid uuidSourceDsaInvocationID;

		/// <summary>
		/// Contains the maximum update sequence number to which the destination server can indicate that it has recorded all changes
		/// originated by the given server at update sequence numbers less than, or equal to, this update sequence number. This is used
		/// to filter changes at replication source servers that the destination server has already applied.
		/// </summary>
		public long usnAttributeFilter;

		/// <summary>
		/// Contains a FILETIME structure that contains the date and time of the last successful synchronization operation.
		/// </summary>
		public FILETIME ftimeLastSyncSuccess;
	}

	/// <summary>
	/// The <c>DS_REPL_CURSOR_3</c> structure contains inbound replication state data with respect to all replicas of a given naming
	/// context, as returned by the DsReplicaGetInfo2 function. This structure is an enhanced version of the DS_REPL_CURSOR and
	/// DS_REPL_CURSOR_2 structures.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/ns-ntdsapi-_ds_repl_cursor_3w typedef struct _DS_REPL_CURSOR_3W {
	// UUID uuidSourceDsaInvocationID; USN usnAttributeFilter; FILETIME ftimeLastSyncSuccess; PWSTR pszSourceDsaDN; } DS_REPL_CURSOR_3W;
	[PInvokeData("ntdsapi.h", MSDNShortId = "0361a3e1-814c-4ef2-b574-2870a9289e52")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct DS_REPL_CURSOR_3W
	{
		/// <summary>
		/// Contains the invocation identifier of the originating server to which the <c>usnAttributeFilter</c> corresponds.
		/// </summary>
		public Guid uuidSourceDsaInvocationID;

		/// <summary>
		/// Contains the maximum update sequence number to which the destination server can indicate that it has recorded all changes
		/// originated by the given server at update sequence numbers less than, or equal to, this update sequence number. This is used
		/// to filter changes at replication source servers that the destination server has already applied.
		/// </summary>
		public long usnAttributeFilter;

		/// <summary>
		/// Contains a FILETIME structure that contains the date and time of the last successful synchronization operation.
		/// </summary>
		public FILETIME ftimeLastSyncSuccess;

		/// <summary>
		/// Pointer to a null-terminated string that contains the distinguished name of the directory service agent that corresponds to
		/// the source server to which this replication state data applies.
		/// </summary>
		public string pszSourceDsaDN;
	}

	/// <summary>
	/// The <c>DS_REPL_CURSOR_BLOB</c> structure contains inbound replication state data with respect to all replicas of a given naming
	/// context. This structure is similar to the DS_REPL_CURSOR_3 structure, but is obtained from the Lightweight Directory Access
	/// Protocol API functions when obtaining binary data for the <c>msDS-NCReplCursors</c> attribute.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/ns-ntdsapi-_ds_repl_cursor_blob typedef struct _DS_REPL_CURSOR_BLOB {
	// UUID uuidSourceDsaInvocationID; USN usnAttributeFilter; FILETIME ftimeLastSyncSuccess; DWORD oszSourceDsaDN; } DS_REPL_CURSOR_BLOB;
	[PInvokeData("ntdsapi.h", MSDNShortId = "c41e4737-5ef8-40ce-9af1-0afff7e11dc1")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct DS_REPL_CURSOR_BLOB
	{
		/// <summary>
		/// Contains the invocation identifier of the originating server to which the <c>usnAttributeFilter</c> corresponds.
		/// </summary>
		public Guid uuidSourceDsaInvocationID;

		/// <summary>
		/// Contains the maximum update sequence number to which the destination server can indicate that it has recorded all changes
		/// originated by the given server at update sequence numbers less than, or equal to, this update sequence number. This is used
		/// to filter changes at replication source servers that the destination server has already applied.
		/// </summary>
		public long usnAttributeFilter;

		/// <summary>
		/// Contains a FILETIME structure that contains the date and time of the last successful synchronization operation.
		/// </summary>
		public FILETIME ftimeLastSyncSuccess;

		/// <summary>
		/// Contains the offset, in bytes, from the address of this structure to a null-terminated Unicode string that contains the
		/// distinguished name of the directory service agent that corresponds to the source server to which this replication state data applies.
		/// </summary>
		public uint oszSourceDsaDN;
	}

	/// <summary>
	/// The <c>DS_REPL_CURSORS</c> structure is used with the DsReplicaGetInfo and DsReplicaGetInfo2 function to provide replication
	/// state data with respect to all replicas of a given naming context.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/ns-ntdsapi-_ds_repl_cursors typedef struct _DS_REPL_CURSORS { DWORD
	// cNumCursors; DWORD dwReserved; #if ... DS_REPL_CURSOR rgCursor[]; #else DS_REPL_CURSOR rgCursor[1]; #endif } DS_REPL_CURSORS;
	[PInvokeData("ntdsapi.h", MSDNShortId = "0fe5ad72-d3f3-42a8-a36f-ca1fc9c55c50")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct DS_REPL_CURSORS
	{
		/// <summary>Contains the number of elements in the <c>rgCursor</c> array.</summary>
		public uint cNumCursors;

		/// <summary>Reserved for future use.</summary>
		public uint dwReserved;

		/// <summary>
		/// Contains an array of DS_REPL_CURSOR structures that contain the requested replication data. The cNumCursors member contains
		/// the number of elements in this array.
		/// </summary>
		public IntPtr _rgCursor;

		/// <summary>
		/// Contains an array of DS_REPL_CURSOR structures that contain the requested replication data.
		/// </summary>
		/// <value>The rg cursor.</value>
		public DS_REPL_CURSOR[]? rgCursor => _rgCursor.ToArray<DS_REPL_CURSOR>((int)cNumCursors);
	}

	/// <summary>
	/// The <c>DS_REPL_CURSORS_2</c> structure is used with the DsReplicaGetInfo2 function to provide replication state data with respect
	/// to all replicas of a given naming context.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/ns-ntdsapi-_ds_repl_cursors_2 typedef struct _DS_REPL_CURSORS_2 {
	// DWORD cNumCursors; DWORD dwEnumerationContext; #if ... DS_REPL_CURSOR_2 rgCursor[]; #else DS_REPL_CURSOR_2 rgCursor[1]; #endif } DS_REPL_CURSORS_2;
	[PInvokeData("ntdsapi.h", MSDNShortId = "5a1981ac-3b6a-4e48-8430-f8297ddd3283")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct DS_REPL_CURSORS_2
	{
		/// <summary>Contains the number of elements in the <c>rgCursor</c> array.</summary>
		public uint cNumCursors;

		/// <summary>
		/// Contains the zero-based index of the next entry to retrieve if more entries are available. This value is passed for the
		/// dwEnumerationContext parameter in the next call to DsReplicaGetInfo2 to retrieve the next block of entries. If no more
		/// entries are available, this member contains -1.
		/// </summary>
		public uint dwEnumerationContext;

		/// <summary>
		/// Contains an array of DS_REPL_CURSOR_2 structures that contain the requested replication data. The cNumCursors member contains
		/// the number of elements in this array.
		/// </summary>
		public IntPtr _rgCursor;

		/// <summary>
		/// Contains an array of DS_REPL_CURSOR_2 structures that contain the requested replication data.
		/// </summary>
		/// <value>The rg cursor.</value>
		public DS_REPL_CURSOR_2[]? rgCursor => _rgCursor.ToArray<DS_REPL_CURSOR_2>((int)cNumCursors);
	}

	/// <summary>
	/// The <c>DS_REPL_CURSORS_3</c> structure is used with the DsReplicaGetInfo2 function to provide replication state data with respect
	/// to all replicas of a given naming context.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/ns-ntdsapi-_ds_repl_cursors_3w typedef struct _DS_REPL_CURSORS_3W {
	// DWORD cNumCursors; DWORD dwEnumerationContext; #if ... DS_REPL_CURSOR_3W rgCursor[]; #else DS_REPL_CURSOR_3W rgCursor[1]; #endif } DS_REPL_CURSORS_3W;
	[PInvokeData("ntdsapi.h", MSDNShortId = "7b8e0015-dd8f-4cba-8ea2-683cb107f294")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct DS_REPL_CURSORS_3W
	{
		/// <summary>Contains the number of elements in the <c>rgCursor</c> array.</summary>
		public uint cNumCursors;

		/// <summary>
		/// Contains the zero-based index of the next entry to retrieve if more entries are available. This value is passed for the
		/// dwEnumerationContext parameter in the next call to DsReplicaGetInfo2 to retrieve the next block of entries. If no more
		/// entries are available, this member contains -1.
		/// </summary>
		public uint dwEnumerationContext;

		/// <summary>
		/// Contains an array of DS_REPL_CURSOR_3W structures that contain the requested replication data. The cNumCursors member
		/// contains the number of elements in this array.
		/// </summary>
		public IntPtr _rgCursor;

		/// <summary>
		/// Contains an array of DS_REPL_CURSOR_3W structures that contain the requested replication data.
		/// </summary>
		/// <value>The rg cursor.</value>
		public DS_REPL_CURSOR_3W[]? rgCursor => _rgCursor.ToArray<DS_REPL_CURSOR_3W>((int)cNumCursors);
	}

	/// <summary>
	/// The <c>DS_REPL_KCC_DSA_FAILURES</c> structure contains an array of DS_REPL_KCC_DSA_FAILURE structures, which in turn contain
	/// replication state data with respect to inbound replication partners, as returned by the DsReplicaGetInfo and DsReplicaGetInfo2 functions.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/ns-ntdsapi-_ds_repl_kcc_dsa_failuresw typedef struct
	// _DS_REPL_KCC_DSA_FAILURESW { DWORD cNumEntries; DWORD dwReserved; #if ... DS_REPL_KCC_DSA_FAILUREW rgDsaFailure[]; #else
	// DS_REPL_KCC_DSA_FAILUREW rgDsaFailure[1]; #endif } DS_REPL_KCC_DSA_FAILURESW;
	[PInvokeData("ntdsapi.h", MSDNShortId = "bb011502-38ae-43b7-a6ad-de16b499f61b")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct DS_REPL_KCC_DSA_FAILURESW
	{
		/// <summary>
		/// Contains the number of elements in the <c>rgMetaData</c> array.
		/// </summary>
		public uint cNumEntries;

		/// <summary>Reserved for future use.</summary>
		public uint dwReserved;

		/// <summary>
		/// Contains an array of DS_REPL_KCC_DSA_FAILURE structures that contain the requested replication data. The cNumEntries member
		/// contains the number of elements in this array.
		/// </summary>
		public IntPtr _rgDsaFailure;

		/// <summary>
		/// Contains an array of DS_REPL_KCC_DSA_FAILURE structures that contain the requested replication data.
		/// </summary>
		/// <value>The rg DSA failure.</value>
		public DS_REPL_KCC_DSA_FAILUREW[]? rgDsaFailure => _rgDsaFailure.ToArray<DS_REPL_KCC_DSA_FAILUREW>((int)cNumEntries);
	}

	/// <summary>
	/// The <c>DS_REPL_KCC_DSA_FAILURE</c> structure contains replication state data about a specific inbound replication partner, as
	/// returned by the DsReplicaGetInfo and DsReplicaGetInfo2 function. This state data is compiled and used by the Knowledge
	/// Consistency Checker (KCC) to decide when alternate replication routes must be added to account for unreachable servers.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/ns-ntdsapi-_ds_repl_kcc_dsa_failurew typedef struct
	// _DS_REPL_KCC_DSA_FAILUREW { PWSTR pszDsaDN; UUID uuidDsaObjGuid; FILETIME ftimeFirstFailure; DWORD cNumFailures; DWORD
	// dwLastResult; } DS_REPL_KCC_DSA_FAILUREW;
	[PInvokeData("ntdsapi.h", MSDNShortId = "7a7131ce-a647-4b3d-a9f3-091b6dcebff7")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct DS_REPL_KCC_DSA_FAILUREW
	{
		/// <summary>
		/// Pointer to a null-terminated string that contains the distinguished name of the directory system agent object in the
		/// directory that corresponds to the source server.
		/// </summary>
		public string pszDsaDN;

		/// <summary>
		/// Contains the <c>objectGuid</c> of the directory system agent object represented by the <c>pszDsaDN</c> member.
		/// </summary>
		public Guid uuidDsaObjGuid;

		/// <summary>
		/// <para>
		/// Contains a FILETIME structure which the contents of depends on the value passed for the InfoType parameter when
		/// DsReplicaGetInfo or DsReplicaGetInfo2 function was called.
		/// </para>
		/// <para>DS_REPL_INFO_KCC_DSA_CONNECT_FAILURES</para>
		/// <para>Contains the date and time that the first failure occurred when replicating from the source server.</para>
		/// <para>DS_REPL_INFO_KCC_DSA_LINK_FAILURES</para>
		/// <para>Contains the date and time of the last successful replication.</para>
		/// </summary>
		public FILETIME ftimeFirstFailure;

		/// <summary>
		/// Contains the number of consecutive failures since the last successful replication.
		/// </summary>
		public uint cNumFailures;

		/// <summary>
		/// Contains the error code associated with the most recent failure, or <c>ERROR_SUCCESS</c> if the specific error is unavailable.
		/// </summary>
		public Win32Error dwLastResult;
	}

	/// <summary>
	/// The <c>DS_REPL_KCC_DSA_FAILUREW_BLOB</c> structure contains replication state data with respect to a specific inbound replication
	/// partner. This state data is compiled and used by the Knowledge Consistency Checker (KCC) to decide when alternate replication
	/// routes must be added to account for unreachable servers. This structure is similar to the DS_REPL_KCC_DSA_FAILURE structure, but
	/// is obtained from the Lightweight Directory Access Protocol API functions when obtaining binary data for the
	/// <c>msDS-ReplConnectionFailures</c> or <c>msDS-ReplLinkFailures</c> attribute.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/ns-ntdsapi-_ds_repl_kcc_dsa_failurew_blob typedef struct
	// _DS_REPL_KCC_DSA_FAILUREW_BLOB { DWORD oszDsaDN; UUID uuidDsaObjGuid; FILETIME ftimeFirstFailure; DWORD cNumFailures; DWORD
	// dwLastResult; } DS_REPL_KCC_DSA_FAILUREW_BLOB;
	[PInvokeData("ntdsapi.h", MSDNShortId = "b0df588a-2ef1-4870-b304-c6f9e07322b0")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct DS_REPL_KCC_DSA_FAILUREW_BLOB
	{
		/// <summary>
		/// Contains the offset, in bytes, from the address of this structure to a null-terminated string that contains the distinguished
		/// name of the directory system agent object in the directory that corresponds to the source server.
		/// </summary>
		public uint oszDsaDN;

		/// <summary>
		/// Contains the <c>objectGuid</c> of the directory system agent object represented by the <c>oszDsaDN</c> member.
		/// </summary>
		public Guid uuidDsaObjGuid;

		/// <summary>
		/// <para>Contains a FILETIME structure which the contents of depends on the requested binary replication data.</para>
		/// <para>msDS-ReplConnectionFailures</para>
		/// <para>Contains the date and time that the first failure occurred when replicating from the source server.</para>
		/// <para>msDS-ReplLinkFailures</para>
		/// <para>Contains the date and time of the last successful replication.</para>
		/// </summary>
		public FILETIME ftimeFirstFailure;

		/// <summary>
		/// Contains the number of consecutive failures since the last successful replication.
		/// </summary>
		public uint cNumFailures;

		/// <summary>
		/// Contains the error code associated with the most recent failure, or <c>ERROR_SUCCESS</c> if the specific error is unavailable.
		/// </summary>
		public Win32Error dwLastResult;
	}

	/// <summary>
	/// The <c>DS_REPL_NEIGHBOR</c> structure contains inbound replication state data for a particular naming context and source server
	/// pair, as returned by the DsReplicaGetInfo and DsReplicaGetInfo2 functions.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/ns-ntdsapi-_ds_repl_neighborw typedef struct _DS_REPL_NEIGHBORW {
	// PWSTR pszNamingContext; PWSTR pszSourceDsaDN; PWSTR pszSourceDsaAddress; PWSTR pszAsyncIntersiteTransportDN; DWORD
	// dwReplicaFlags; DWORD dwReserved; UUID uuidNamingContextObjGuid; UUID uuidSourceDsaObjGuid; UUID uuidSourceDsaInvocationID; UUID
	// uuidAsyncIntersiteTransportObjGuid; USN usnLastObjChangeSynced; USN usnAttributeFilter; FILETIME ftimeLastSyncSuccess; FILETIME
	// ftimeLastSyncAttempt; DWORD dwLastSyncResult; DWORD cNumConsecutiveSyncFailures; } DS_REPL_NEIGHBORW;
	[PInvokeData("ntdsapi.h", MSDNShortId = "acab74f4-5739-4310-895b-081062c0360b")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct DS_REPL_NEIGHBOR
	{
		/// <summary>
		/// Pointer to a null-terminated string that contains the naming context to which this replication state data pertains. Each
		/// naming context is replicated independently and has different associated neighbor data, even if the naming contexts are
		/// replicated from the same source server.
		/// </summary>
		public string pszNamingContext;

		/// <summary>
		/// Pointer to a null-terminated string that contains the distinguished name of the directory service agent corresponding to the
		/// source server to which this replication state data pertains. Each source server has different associated neighbor data.
		/// </summary>
		public string pszSourceDsaDN;

		/// <summary>
		/// Pointer to a null-terminated string that contains the transport-specific network address of the source server. That is, a
		/// directory name service name for RPC/IP replication, or an SMTP address for an SMTP replication.
		/// </summary>
		public string pszSourceDsaAddress;

		/// <summary>
		/// Pointer to a null-terminated string that contains the distinguished name of the <c>interSiteTransport</c> object that
		/// corresponds to the transport over which replication is performed. This member contains <c>NULL</c> for RPC/IP replication.
		/// </summary>
		public string pszAsyncIntersiteTransportDN;

		/// <summary>
		/// <para>
		/// Contains a set of flags that specify attributes and options for the replication data. This can be zero or a combination of
		/// one or more of the following flags.
		/// </para>
		/// <para>DS_REPL_NBR_WRITEABLE (16 (0x10))</para>
		/// <para>The local copy of the naming context is writable.</para>
		/// <para>DS_REPL_NBR_SYNC_ON_STARTUP (32 (0x20))</para>
		/// <para>
		/// Replication of this naming context from this source is attempted when the destination server is booted. This normally only
		/// applies to intra-site neighbors.
		/// </para>
		/// <para>DS_REPL_NBR_DO_SCHEDULED_SYNCS (64 (0x40))</para>
		/// <para>
		/// Perform replication on a schedule. This flag is normally set unless the schedule for this naming context/source is "never",
		/// that is, the empty schedule.
		/// </para>
		/// <para>DS_REPL_NBR_USE_ASYNC_INTERSITE_TRANSPORT (128 (0x80))</para>
		/// <para>
		/// Perform replication indirectly through the Inter-Site Messaging Service. This flag is set only when replicating over SMTP.
		/// This flag is not set when replicating over inter-site RPC/IP.
		/// </para>
		/// <para>DS_REPL_NBR_TWO_WAY_SYNC (512 (0x200))</para>
		/// <para>
		/// If set, indicates that when inbound replication is complete, the destination server must tell the source server to
		/// synchronize in the reverse direction. This feature is used in dial-up scenarios where only one of the two servers can
		/// initiate a dial-up connection. For example, this option would be used in a corporate headquarters and branch office, where
		/// the branch office connects to the corporate headquarters over the Internet by means of a dial-up ISP connection.
		/// </para>
		/// <para>DS_REPL_NBR_RETURN_OBJECT_PARENTS (2048 (0x800))</para>
		/// <para>
		/// This neighbor is in a state where it returns parent objects before children objects. It goes into this state after it
		/// receives a child object before its parent.
		/// </para>
		/// <para>DS_REPL_NBR_FULL_SYNC_IN_PROGRESS (65536 (0x10000))</para>
		/// <para>
		/// The destination server is performing a full synchronization from the source server. Full synchronizations do not use vectors
		/// that create updates (DS_REPL_CURSORS) for filtering updates. Full synchronizations are not used as a part of the normal
		/// replication protocol.
		/// </para>
		/// <para>DS_REPL_NBR_FULL_SYNC_NEXT_PACKET (131072 (0x20000))</para>
		/// <para>
		/// The last packet from the source indicated a modification of an object that the destination server has not yet created. The
		/// next packet to be requested instructs the source server to put all attributes of the modified object into the packet.
		/// </para>
		/// <para>DS_REPL_NBR_NEVER_SYNCED (2097152 (0x200000))</para>
		/// <para>A synchronization has never been successfully completed from this source.</para>
		/// <para>DS_REPL_NBR_PREEMPTED (16777216 (0x1000000))</para>
		/// <para>
		/// The replication engine has temporarily stopped processing this neighbor in order to service another higher-priority neighbor,
		/// either for this partition or for another partition. The replication engine will resume processing this neighbor after the
		/// higher-priority work is completed.
		/// </para>
		/// <para>DS_REPL_NBR_IGNORE_CHANGE_NOTIFICATIONS (67108864 (0x4000000))</para>
		/// <para>
		/// This neighbor is set to disable notification-based synchronizations. Within a site, domain controllers synchronize with each
		/// other based on notifications when changes occur. This setting prevents this neighbor from performing syncs that are triggered
		/// by notifications. The neighbor will still do synchronizations based on its schedule, or in response to manually requested synchronizations.
		/// </para>
		/// <para>DS_REPL_NBR_DISABLE_SCHEDULED_SYNC (134217728 (0x8000000))</para>
		/// <para>
		/// This neighbor is set to not perform synchronizations based on its schedule. The only way this neighbor will perform
		/// synchronizations is in response to change notifications or to manually requested synchronizations.
		/// </para>
		/// <para>DS_REPL_NBR_COMPRESS_CHANGES (268435456 (0x10000000))</para>
		/// <para>
		/// Changes received from this source are to be compressed. This is normally set if, and only if, the source server is in a
		/// different site.
		/// </para>
		/// <para>DS_REPL_NBR_NO_CHANGE_NOTIFICATIONS (536870912 (0x20000000))</para>
		/// <para>
		/// No change notifications should be received from this source. Normally set if, and only if, the source server is in a
		/// different site.
		/// </para>
		/// <para>DS_REPL_NBR_PARTIAL_ATTRIBUTE_SET (1073741824 (0x40000000))</para>
		/// <para>
		/// This neighbor is in a state where it is rebuilding the contents of this replica because of a change in the partial attribute set.
		/// </para>
		/// </summary>
		public DsReplNeighborFlags dwReplicaFlags;

		/// <summary>Reserved for future use.</summary>
		public uint dwReserved;

		/// <summary>
		/// Contains the <c>objectGuid</c> of the naming context corresponding to <c>pszNamingContext</c>.
		/// </summary>
		public Guid uuidNamingContextObjGuid;

		/// <summary>
		/// Contains the <c>objectGuid</c> of the <c>nTDSDSA</c> object corresponding to <c>pszSourceDsaDN</c>.
		/// </summary>
		public Guid uuidSourceDsaObjGuid;

		/// <summary>
		/// Contains the invocation identifier used by the source server as of the last replication attempt.
		/// </summary>
		public Guid uuidSourceDsaInvocationID;

		/// <summary>
		/// Contains the <c>objectGuid</c> of the inter-site transport object corresponding to <c>pszAsyncIntersiteTransportDN</c>.
		/// </summary>
		public Guid uuidAsyncIntersiteTransportObjGuid;

		/// <summary>
		/// Contains the update sequence number of the last object update received.
		/// </summary>
		public long usnLastObjChangeSynced;

		/// <summary>
		/// Contains the <c>usnLastObjChangeSynced</c> value at the end of the last complete, successful replication cycle, or 0 if none.
		/// Attributes at the source last updated at a update sequence number less than or equal to this value have already been received
		/// and applied by the destination.
		/// </summary>
		public long usnAttributeFilter;

		/// <summary>
		/// Contains a FILETIME structure that contains the date and time the last successful replication cycle was completed from this
		/// source. All members of this structure are zero if the replication cycle has never been completed.
		/// </summary>
		public FILETIME ftimeLastSyncSuccess;

		/// <summary>
		/// Contains a FILETIME structure that contains the date and time of the last replication attempt from this source. All members
		/// of this structure are zero if the replication has never been attempted.
		/// </summary>
		public FILETIME ftimeLastSyncAttempt;

		/// <summary>
		/// Contains an error code associated with the last replication attempt from this source. Contains <c>ERROR_SUCCESS</c> if the
		/// last attempt succeeded.
		/// </summary>
		public Win32Error dwLastSyncResult;

		/// <summary>
		/// Contains the number of failed replication attempts from this source since the last successful replication attempt - or since
		/// the source was added as a neighbor, if no previous attempt was successful.
		/// </summary>
		public uint cNumConsecutiveSyncFailures;
	}

	/// <summary>
	/// The <c>DS_REPL_NEIGHBORS</c> structure is used with the DsReplicaGetInfo and DsReplicaGetInfo2 functions to provide inbound
	/// replication state data for naming context and source server pairs.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/ns-ntdsapi-_ds_repl_neighborsw typedef struct _DS_REPL_NEIGHBORSW {
	// DWORD cNumNeighbors; DWORD dwReserved; #if ... DS_REPL_NEIGHBORW rgNeighbor[]; #else DS_REPL_NEIGHBORW rgNeighbor[1]; #endif } DS_REPL_NEIGHBORSW;
	[PInvokeData("ntdsapi.h", MSDNShortId = "1307399b-de29-43ec-97b4-05cd70c1a92d")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct DS_REPL_NEIGHBORS
	{
		/// <summary>
		/// Contains the number of elements in the <c>rgNeighbor</c> array.
		/// </summary>
		public uint cNumNeighbors;

		/// <summary>Reserved for future use.</summary>
		public uint dwReserved;

		/// <summary>
		/// Contains an array of DS_REPL_NEIGHBOR structures that contain the requested replication data. The cNumNeighbors member
		/// contains the number of elements in this array.
		/// </summary>
		public IntPtr _rgNeighbor;

		/// <summary>
		/// Contains an array of DS_REPL_NEIGHBOR structures that contain the requested replication data.
		/// </summary>
		/// <value>The rg neighbor.</value>
		public DS_REPL_NEIGHBOR[]? rgNeighbor => _rgNeighbor.ToArray<DS_REPL_NEIGHBOR>((int)cNumNeighbors);
	}

	/// <summary>
	/// The <c>DS_REPL_NEIGHBORW_BLOB</c> structure contains inbound replication state data for a particular naming context and source
	/// server pair. This structure is similar to the DS_REPL_NEIGHBOR structure, but is obtained from the Lightweight Directory Access
	/// Protocol API functions when obtaining binary data for the <c>msDS-NCReplInboundNeighbors</c> attribute.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/ns-ntdsapi-_ds_repl_neighborw_blob typedef struct
	// _DS_REPL_NEIGHBORW_BLOB { DWORD oszNamingContext; DWORD oszSourceDsaDN; DWORD oszSourceDsaAddress; DWORD
	// oszAsyncIntersiteTransportDN; DWORD dwReplicaFlags; DWORD dwReserved; UUID uuidNamingContextObjGuid; UUID uuidSourceDsaObjGuid;
	// UUID uuidSourceDsaInvocationID; UUID uuidAsyncIntersiteTransportObjGuid; USN usnLastObjChangeSynced; USN usnAttributeFilter;
	// FILETIME ftimeLastSyncSuccess; FILETIME ftimeLastSyncAttempt; DWORD dwLastSyncResult; DWORD cNumConsecutiveSyncFailures; } DS_REPL_NEIGHBORW_BLOB;
	[PInvokeData("ntdsapi.h", MSDNShortId = "1a56968a-29ed-4c94-80ee-02bdd279f5c2")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct DS_REPL_NEIGHBORW_BLOB
	{
		/// <summary>
		/// Contains the offset, in bytes, from the address of this structure to a null-terminated Unicode string that contains the
		/// naming context to which this replication state data pertains. Each naming context is replicated independently and has
		/// different associated neighbor data, even if the naming contexts are replicated from the same source server.
		/// </summary>
		public uint oszNamingContext;

		/// <summary>
		/// Contains the offset, in bytes, from the address of this structure to a null-terminated Unicode string that contains the
		/// distinguished name of the directory service agent corresponding to the source server to which this replication state data
		/// pertains. Each source server has different associated neighbor data.
		/// </summary>
		public uint oszSourceDsaDN;

		/// <summary>
		/// Contains the offset, in bytes, from the address of this structure to a null-terminated Unicode string that contains the
		/// transport-specific network address of the source server. That is, a directory name service name for RPC/IP replication, or an
		/// SMTP address for an SMTP replication.
		/// </summary>
		public uint oszSourceDsaAddress;

		/// <summary>
		/// Contains the offset, in bytes, from the address of this structure to a null-terminated Unicode string that contains the
		/// distinguished name of the <c>interSiteTransport</c> object that corresponds to the transport over which replication is
		/// performed. This member contains <c>NULL</c> for RPC/IP replication.
		/// </summary>
		public uint oszAsyncIntersiteTransportDN;

		/// <summary>
		/// <para>
		/// Contains a set of flags that specify attributes and options for the replication data. This can be zero or a combination of
		/// one or more of the following flags.
		/// </para>
		/// <para>DS_REPL_NBR_WRITEABLE</para>
		/// <para>The local copy of the naming context is writable.</para>
		/// <para>DS_REPL_NBR_SYNC_ON_STARTUP</para>
		/// <para>
		/// Replication of this naming context from this source is attempted when the destination server is booted. This normally only
		/// applies to intra-site neighbors.
		/// </para>
		/// <para>DS_REPL_NBR_DO_SCHEDULED_SYNCS</para>
		/// <para>
		/// Perform replication on a schedule. This flag is normally set unless the schedule for this naming context/source is "never",
		/// that is, the empty schedule.
		/// </para>
		/// <para>DS_REPL_NBR_USE_ASYNC_INTERSITE_TRANSPORT</para>
		/// <para>
		/// Perform replication indirectly through the Inter-Site Messaging Service. This flag is set only when replicating over SMTP.
		/// This flag is not set when replicating over inter-site RPC/IP.
		/// </para>
		/// <para>DS_REPL_NBR_TWO_WAY_SYNC</para>
		/// <para>
		/// If set, indicates that when inbound replication is complete, the destination server must tell the source server to
		/// synchronize in the reverse direction. This feature is used in dial-up scenarios where only one of the two servers can
		/// initiate a dial-up connection. For example, this option would be used in a corporate headquarters and branch office, where
		/// the branch office connects to the corporate headquarters over the Internet by means of a dial-up ISP connection.
		/// </para>
		/// <para>DS_REPL_NBR_FULL_SYNC_IN_PROGRESS</para>
		/// <para>
		/// The destination server is performing a full synchronization from the source server. Full synchronizations do not use vectors
		/// that create updates (DS_REPL_CURSORS) for filtering updates. Full synchronizations are not used as a part of the normal
		/// replication protocol.
		/// </para>
		/// <para>DS_REPL_NBR_FULL_SYNC_NEXT_PACKET</para>
		/// <para>
		/// The last packet from the source indicated a modification of an object that the destination server has not yet created. The
		/// next packet to be requested instructs the source server to put all attributes of the modified object into the packet.
		/// </para>
		/// <para>DS_REPL_NBR_NEVER_SYNCED</para>
		/// <para>A synchronization has never been successfully completed from this source.</para>
		/// <para>DS_REPL_NBR_COMPRESS_CHANGES</para>
		/// <para>
		/// Changes received from this source are to be compressed. This is normally set if, and only if, the source server is in a
		/// different site.
		/// </para>
		/// <para>DS_REPL_NBR_NO_CHANGE_NOTIFICATIONS</para>
		/// <para>
		/// No change notifications should be received from this source. Normally set if, and only if, the source server is in a
		/// different site.
		/// </para>
		/// </summary>
		public uint dwReplicaFlags;

		/// <summary>Reserved for future use.</summary>
		public uint dwReserved;

		/// <summary>
		/// Contains the <c>objectGuid</c> of the naming context that corresponds to <c>pszNamingContext</c>.
		/// </summary>
		public Guid uuidNamingContextObjGuid;

		/// <summary>
		/// Contains the <c>objectGuid</c> of the <c>nTDSDSA</c> object that corresponds to <c>pszSourceDsaDN</c>.
		/// </summary>
		public Guid uuidSourceDsaObjGuid;

		/// <summary>
		/// Contains the invocation identifier used by the source server as of the last replication attempt.
		/// </summary>
		public Guid uuidSourceDsaInvocationID;

		/// <summary>
		/// Contains the <c>objectGuid</c> of the inter-site transport object that corresponds to <c>pszAsyncIntersiteTransportDN</c>.
		/// </summary>
		public Guid uuidAsyncIntersiteTransportObjGuid;

		/// <summary>
		/// Contains the update sequence number of the last object update received.
		/// </summary>
		public long usnLastObjChangeSynced;

		/// <summary>
		/// Contains the <c>usnLastObjChangeSynced</c> value at the end of the last complete, successful replication cycle, or 0 if none.
		/// Attributes at the source last updated at a update sequence number less than or equal to this value have already been received
		/// and applied by the destination.
		/// </summary>
		public long usnAttributeFilter;

		/// <summary>
		/// Contains a FILETIME structure that contains the date and time the last successful replication cycle was completed from this
		/// source. All members of this structure are zero if the replication cycle has never been completed.
		/// </summary>
		public FILETIME ftimeLastSyncSuccess;

		/// <summary>
		/// Contains a FILETIME structure that contains the date and time of the last replication attempt from this source. All members
		/// of this structure are zero if the replication has never been attempted.
		/// </summary>
		public FILETIME ftimeLastSyncAttempt;

		/// <summary>
		/// Contains a Windows error code associated with the last replication attempt from this source. Contains <c>ERROR_SUCCESS</c> if
		/// the last attempt was successful.
		/// </summary>
		public uint dwLastSyncResult;

		/// <summary>
		/// Contains the number of failed replication attempts that have been made from this source since the last successful replication
		/// attempt or since the source was added as a neighbor, if no previous attempt succeeded.
		/// </summary>
		public uint cNumConsecutiveSyncFailures;
	}

	/// <summary>
	/// The <c>DS_REPL_OBJ_META_DATA</c> structure contains an array of DS_REPL_ATTR_META_DATA structures. These structures contain
	/// replication state data for past and present attributes for a given object. The replication state data is returned from the
	/// DsReplicaGetInfo and DsReplicaGetInfo2 functions. The metadata records data about the last modification of a given object attribute.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/ns-ntdsapi-_ds_repl_obj_meta_data typedef struct
	// _DS_REPL_OBJ_META_DATA { DWORD cNumEntries; DWORD dwReserved; #if ... DS_REPL_ATTR_META_DATA rgMetaData[]; #else
	// DS_REPL_ATTR_META_DATA rgMetaData[1]; #endif } DS_REPL_OBJ_META_DATA;
	[PInvokeData("ntdsapi.h", MSDNShortId = "7851ffbc-5d05-4ea7-b3b4-1b8b77299be5")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct DS_REPL_OBJ_META_DATA
	{
		/// <summary>
		/// Contains the number of elements in the <c>rgMetaData</c> array.
		/// </summary>
		public uint cNumEntries;

		/// <summary>Not used.</summary>
		public uint dwReserved;

		/// <summary>
		/// Contains an array of DS_REPL_ATTR_META_DATA structures. The cNumEntries member contains the number of elements in this array.
		/// </summary>
		public IntPtr _rgMetaData;

		/// <summary>
		/// Contains an array of DS_REPL_ATTR_META_DATA structures that contain the requested replication data.
		/// </summary>
		/// <value>The rg meta data.</value>
		public DS_REPL_ATTR_META_DATA[]? rgMetaData => _rgMetaData.ToArray<DS_REPL_ATTR_META_DATA>((int)cNumEntries);
	}

	/// <summary>
	/// The <c>DS_REPL_OBJ_META_DATA_2</c> structure contains an array of DS_REPL_ATTR_META_DATA_2 structures, which in turn contain
	/// replication state data for the attributes (past and present) for a given object, as returned by the DsReplicaGetInfo2 function.
	/// This structure is an enhanced version of the DS_REPL_OBJ_META_DATA structure.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/ns-ntdsapi-_ds_repl_obj_meta_data_2 typedef struct
	// _DS_REPL_OBJ_META_DATA_2 { DWORD cNumEntries; DWORD dwReserved; #if ... DS_REPL_ATTR_META_DATA_2 rgMetaData[]; #else
	// DS_REPL_ATTR_META_DATA_2 rgMetaData[1]; #endif } DS_REPL_OBJ_META_DATA_2;
	[PInvokeData("ntdsapi.h", MSDNShortId = "2aed753f-432c-4de8-a6be-aa79833f002f")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct DS_REPL_OBJ_META_DATA_2
	{
		/// <summary>
		/// Contains the number of elements in the <c>rgMetaData</c> array.
		/// </summary>
		public uint cNumEntries;

		/// <summary>Not used.</summary>
		public uint dwReserved;

		/// <summary>
		/// Contains an array of DS_REPL_ATTR_META_DATA_2 structures. The cNumEntries member contains the number of elements in this array.
		/// </summary>
		public IntPtr _rgMetaData;

		/// <summary>
		/// Contains an array of DS_REPL_ATTR_META_DATA_2 structures that contain the requested replication data.
		/// </summary>
		/// <value>The rg meta data.</value>
		public DS_REPL_ATTR_META_DATA_2[]? rgMetaData => _rgMetaData.ToArray<DS_REPL_ATTR_META_DATA_2>((int)cNumEntries);
	}

	/// <summary>
	/// The <c>DS_REPL_OP</c> structure describes a replication task currently executing or pending execution, as returned by the
	/// DsReplicaGetInfo or DsReplicaGetInfo2 function.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/ns-ntdsapi-_ds_repl_opw typedef struct _DS_REPL_OPW { FILETIME
	// ftimeEnqueued; ULONG ulSerialNumber; ULONG ulPriority; DS_REPL_OP_TYPE OpType; ULONG ulOptions; PWSTR pszNamingContext; PWSTR
	// pszDsaDN; PWSTR pszDsaAddress; UUID uuidNamingContextObjGuid; UUID uuidDsaObjGuid; } DS_REPL_OPW;
	[PInvokeData("ntdsapi.h", MSDNShortId = "9ea783b3-1529-4424-a582-f46f2a239a60")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct DS_REPL_OPW
	{
		/// <summary>
		/// Contains a FILETIME structure that contains the date and time that this operation was added to the queue.
		/// </summary>
		public FILETIME ftimeEnqueued;

		/// <summary>
		/// Contains the operation identifier. This value is unique in the startup routine of every computer. When the computer is
		/// restarted, the identifiers are no longer unique.
		/// </summary>
		public uint ulSerialNumber;

		/// <summary>
		/// Contains the priority value of this operation. Tasks with a higher priority value are executed first. The priority is
		/// calculated by the server based on the type of operation and its parameters.
		/// </summary>
		public uint ulPriority;

		/// <summary>
		/// Contains one of the DS_REPL_OP_TYPE values that indicate the type of operation that this structure represents.
		/// </summary>
		public DS_REPL_OP_TYPE OpType;

		/// <summary>
		/// <para>
		/// Zero or more bits, the interpretation of which depends on the <c>OpType</c>. For <c>DS_REPL_OP_TYPE_SYNC</c>, the bits should
		/// be interpreted as <c>DS_REPSYNC_</c>. <c>ADD</c>, <c>DELETE</c>, <c>MODIFY</c>, and <c>UPDATE_REFS</c> use <c>DS_REPADD_</c>,
		/// <c>DS_REPDEL_</c>, <c>DS_REPMOD_</c>, and <c>DS_REPUPD_*</c>. For more information and descriptions of these bits, see
		/// DsReplicaSync, DsReplicaAdd, DsReplicaDel, DsReplicaModify, and DsReplicaUpdateRefs.
		/// </para>
		/// <para>
		/// Contains a set of flags that provides additional data about the operation. The contents of this member is determined by the
		/// contents of the <c>OpType</c> member.
		/// </para>
		/// <para>DS_REPL_OP_TYPE_SYNC</para>
		/// <para>
		/// Contains zero or a combination of one or more of the <c>DS_REPSYNC_*</c> values as defined for the Options parameter in DsReplicaSync.
		/// </para>
		/// <para>DS_REPL_OP_TYPE_ADD</para>
		/// <para>
		/// Contains zero or a combination of one or more of the <c>DS_REPADD_*</c> values as defined for the Options parameter in DsReplicaAdd.
		/// </para>
		/// <para>DS_REPL_OP_TYPE_DELETE</para>
		/// <para>
		/// Contains zero or a combination of one or more of the <c>DS_REPDEL_*</c> values as defined for the Options parameter in DsReplicaDel.
		/// </para>
		/// <para>DS_REPL_OP_TYPE_MODIFY</para>
		/// <para>
		/// Contains zero or a combination of one or more of the <c>DS_REPMOD_*</c> values as defined for the Options parameter in DsReplicaModify.
		/// </para>
		/// <para>DS_REPL_OP_TYPE_UPDATE_REFS</para>
		/// <para>
		/// Contains zero or a combination of one or more of the <c>DS_REPSUPD_*</c> values as defined for the Options parameter in DsReplicaUpdateRefs.
		/// </para>
		/// </summary>
		public uint ulOptions;

		/// <summary>
		/// Pointer to a null-terminated string that contains the distinguished name of the naming context associated with this
		/// operation. For example, the naming context to be synchronized for <c>DS_REPL_OP_TYPE_SYNC</c>.
		/// </summary>
		public string pszNamingContext;

		/// <summary>
		/// Pointer to a null-terminated string that contains the distinguished name of the directory system agent object associated with
		/// the remote server corresponding to this operation. For example, the server from which to request changes for
		/// <c>DS_REPL_OP_TYPE_SYNC</c>. This can be <c>NULL</c>.
		/// </summary>
		public string pszDsaDN;

		/// <summary>
		/// Pointer to a null-terminated string that contains the transport-specific network address of the remote server associated with
		/// this operation. For example, the DNS or SMTP address of the server from which to request changes for
		/// <c>DS_REPL_OP_TYPE_SYNC</c>. This can be <c>NULL</c>.
		/// </summary>
		public string pszDsaAddress;

		/// <summary>
		/// Contains the <c>objectGuid</c> of the naming context identified by <c>pszNamingContext</c>.
		/// </summary>
		public Guid uuidNamingContextObjGuid;

		/// <summary>
		/// Contains the <c>objectGuid</c> of the directory system agent object identified by <c>pszDsaDN</c>.
		/// </summary>
		public Guid uuidDsaObjGuid;
	}

	/// <summary>
	/// The <c>DS_REPL_OPW_BLOB</c> structure describes a replication task currently executing or pending execution. This structure is
	/// similar to the DS_REPL_OP structure, but is obtained from the Lightweight Directory Access Protocol API functions when obtaining
	/// binary data for the <c>msDS-ReplPendingOps</c> attribute.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/ns-ntdsapi-_ds_repl_opw_blob typedef struct _DS_REPL_OPW_BLOB {
	// FILETIME ftimeEnqueued; ULONG ulSerialNumber; ULONG ulPriority; DS_REPL_OP_TYPE OpType; ULONG ulOptions; DWORD oszNamingContext;
	// DWORD oszDsaDN; DWORD oszDsaAddress; UUID uuidNamingContextObjGuid; UUID uuidDsaObjGuid; } DS_REPL_OPW_BLOB;
	[PInvokeData("ntdsapi.h", MSDNShortId = "14676159-cc31-4254-b174-dcd84d9ceec1")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct DS_REPL_OPW_BLOB
	{
		/// <summary>
		/// Contains a FILETIME structure that contains the date and time that this operation was added to the queue.
		/// </summary>
		public FILETIME ftimeEnqueued;

		/// <summary>
		/// Contains the identifier of the operation. This value is unique in the startup routine of every computer. When the computer is
		/// restarted, the identifiers are no longer unique.
		/// </summary>
		public uint ulSerialNumber;

		/// <summary>
		/// Contains the priority value of this operation. Tasks with a higher priority value are executed first. The priority is
		/// calculated by the server based on the type of operation and its parameters.
		/// </summary>
		public uint ulPriority;

		/// <summary>
		/// Contains one of the DS_REPL_OP_TYPE values that indicate the type of operation that this structure represents.
		/// </summary>
		public DS_REPL_OP_TYPE OpType;

		/// <summary>
		/// <para>
		/// Zero or more bits, the interpretation of which depends on the <c>OpType</c>. For <c>DS_REPL_OP_TYPE_SYNC</c>, the bits should
		/// be interpreted as <c>DS_REPSYNC_</c>. <c>ADD</c>, <c>DELETE</c>, <c>MODIFY</c>, and <c>UPDATE_REFS</c> use <c>DS_REPADD_</c>,
		/// <c>DS_REPDEL_</c>, <c>DS_REPMOD_</c>, and <c>DS_REPUPD_*</c>. For more information, and descriptions of these bits, see
		/// DsReplicaSync, DsReplicaAdd, DsReplicaDel, DsReplicaModify, and DsReplicaUpdateRefs.
		/// </para>
		/// <para>
		/// Contains a set of flags that provide additional data about the operation. The contents of this member is determined by the
		/// contents of the <c>OpType</c> member.
		/// </para>
		/// <para>This list describes the contents of the ulOptions parameter for each OpType value.</para>
		/// <para>DS_REPL_OP_TYPE_SYNC</para>
		/// <para>
		/// Contains zero or a combination of one or more of the <c>DS_REPSYNC_*</c> values as defined for the Options parameter in DsReplicaSync.
		/// </para>
		/// <para>DS_REPL_OP_TYPE_ADD</para>
		/// <para>
		/// Contains zero or a combination of one or more of the <c>DS_REPADD_*</c> values as defined for the Options parameter in DsReplicaAdd.
		/// </para>
		/// <para>DS_REPL_OP_TYPE_DELETE</para>
		/// <para>
		/// Contains zero or a combination of one or more of the <c>DS_REPDEL_*</c> values as defined for the Options parameter in DsReplicaDel.
		/// </para>
		/// <para>DS_REPL_OP_TYPE_MODIFY</para>
		/// <para>
		/// Contains zero or a combination of one or more of the <c>DS_REPMOD_*</c> values as defined for the Options parameter in DsReplicaModify.
		/// </para>
		/// <para>DS_REPL_OP_TYPE_UPDATE_REFS</para>
		/// <para>
		/// Contains zero or a combination of one or more of the <c>DS_REPSUPD_*</c> values as defined for the Options parameter in DsReplicaUpdateRefs.
		/// </para>
		/// </summary>
		public uint ulOptions;

		/// <summary>
		/// Contains the offset, in bytes, from the address of this structure to a null-terminated string that contains the distinguished
		/// name of the naming context associated with this operation. For example, the naming context to be synchronized for <c>DS_REPL_OP_TYPE_SYNC</c>.
		/// </summary>
		public uint oszNamingContext;

		/// <summary>
		/// Contains the offset, in bytes, from the address of this structure to a null-terminated string that contains the distinguished
		/// name of the directory system agent object associated with the remote server corresponding to this operation. For example, the
		/// server from which to ask for changes for <c>DS_REPL_OP_TYPE_SYNC</c>. This can be <c>NULL</c>.
		/// </summary>
		public uint oszDsaDN;

		/// <summary>
		/// Contains the offset, in bytes, from the address of this structure to a null-terminated string that contains the
		/// transport-specific network address of the remote server associated with this operation. For example, the DNS or SMTP address
		/// of the server from which to ask for changes for <c>DS_REPL_OP_TYPE_SYNC</c>. This can be <c>NULL</c>.
		/// </summary>
		public uint oszDsaAddress;

		/// <summary>
		/// Contains the <c>objectGuid</c> of the naming context identified by <c>pszNamingContext</c>.
		/// </summary>
		public Guid uuidNamingContextObjGuid;

		/// <summary>
		/// Contains the <c>objectGuid</c> of the directory system agent object identified by <c>pszDsaDN</c>.
		/// </summary>
		public Guid uuidDsaObjGuid;
	}

	/// <summary>
	/// The <c>DS_REPL_PENDING_OPS</c> structure contains an array of DS_REPL_OP structures, which in turn describe the replication tasks
	/// currently executing and queued to execute, as returned by the DsReplicaGetInfo and DsReplicaGetInfo2 functions. The entries in
	/// the queue are processed in priority order, and the first entry is the one currently being executed.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/ns-ntdsapi-_ds_repl_pending_opsw typedef struct _DS_REPL_PENDING_OPSW
	// { FILETIME ftimeCurrentOpStarted; DWORD cNumPendingOps; #if ... DS_REPL_OPW rgPendingOp[]; #else DS_REPL_OPW rgPendingOp[1];
	// #endif } DS_REPL_PENDING_OPSW;
	[PInvokeData("ntdsapi.h", MSDNShortId = "2e4b96cb-fbd6-496b-aff3-cb7d82f1fa39")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct DS_REPL_PENDING_OPSW
	{
		/// <summary>
		/// Contains a FILETIME structure that contains the date and time at which the first operation in the queue began executing.
		/// </summary>
		public FILETIME ftimeCurrentOpStarted;

		/// <summary>
		/// Contains the number of elements in the <c>rgPendingOps</c> array.
		/// </summary>
		public uint cNumPendingOps;

		/// <summary>The sequence of replication operations to be performed.</summary>
		public IntPtr _rgPendingOp;

		/// <summary>The sequence of replication operations to be performed.</summary>
		/// <value>The rg pending op.</value>
		public DS_REPL_OPW[]? rgPendingOp => _rgPendingOp.ToArray<DS_REPL_OPW>((int)cNumPendingOps);
	}

	/// <summary>
	/// <para>The <c>DS_REPL_QUEUE_STATISTICSW</c> structure is used to contain replication queue statistics.</para>
	/// <para>
	/// Reserved. Obtain this data using the DS_REPL_QUEUE_STATISTICSW_BLOB structure with the Lightweight Directory Access Protocol API
	/// functions to obtain binary data for the <c>msDS-ReplQueueStatistics</c> attribute.
	/// </para>
	/// </summary>
	/// <remarks>
	/// DS_REPL_QUEUE_STATISTICSW_BLOB is an alias for this structure.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/ns-ntdsapi-_ds_repl_queue_statisticsw typedef struct
	// _DS_REPL_QUEUE_STATISTICSW { FILETIME ftimeCurrentOpStarted; DWORD cNumPendingOps; FILETIME ftimeOldestSync; FILETIME
	// ftimeOldestAdd; FILETIME ftimeOldestMod; FILETIME ftimeOldestDel; FILETIME ftimeOldestUpdRefs; } DS_REPL_QUEUE_STATISTICSW, DS_REPL_QUEUE_STATISTICSW_BLOB;
	[PInvokeData("ntdsapi.h", MSDNShortId = "bfddd7ed-0ff4-46ca-84c2-39020acb37d0")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct DS_REPL_QUEUE_STATISTICSW
	{
		/// <summary>
		/// Contains a FILETIME structure that contains the date and time that the currently running operation started.
		/// </summary>
		public FILETIME ftimeCurrentOpStarted;

		/// <summary>Contains the number of currently pending operations.</summary>
		public uint cNumPendingOps;

		/// <summary>
		/// Contains a FILETIME structure that contains the date and time of the oldest synchronization operation.
		/// </summary>
		public FILETIME ftimeOldestSync;

		/// <summary>
		/// Contains a FILETIME structure that contains the date and time of the oldest add operation.
		/// </summary>
		public FILETIME ftimeOldestAdd;

		/// <summary>
		/// Contains a FILETIME structure that contains the date and time of the oldest modification operation.
		/// </summary>
		public FILETIME ftimeOldestMod;

		/// <summary>
		/// Contains a FILETIME structure that contains the date and time of the oldest delete operation.
		/// </summary>
		public FILETIME ftimeOldestDel;

		/// <summary>
		/// Contains a FILETIME structure that contains the date and time of the oldest reference update operation.
		/// </summary>
		public FILETIME ftimeOldestUpdRefs;
	}

	/// <summary>
	/// The <c>DS_REPL_VALUE_META_DATA</c> structure is used with the DS_REPL_ATTR_VALUE_META_DATA structure to contain attribute value
	/// replication metadata.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/ns-ntdsapi-_ds_repl_value_meta_data typedef struct
	// _DS_REPL_VALUE_META_DATA { PWSTR pszAttributeName; PWSTR pszObjectDn; DWORD cbData; #if ... BYTE *pbData; #else BYTE *pbData;
	// #endif FILETIME ftimeDeleted; FILETIME ftimeCreated; DWORD dwVersion; FILETIME ftimeLastOriginatingChange; UUID
	// uuidLastOriginatingDsaInvocationID; USN usnOriginatingChange; USN usnLocalChange; } DS_REPL_VALUE_META_DATA;
	[PInvokeData("ntdsapi.h", MSDNShortId = "294a466e-8a83-4b33-a8a8-ac7b51d081d4")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct DS_REPL_VALUE_META_DATA
	{
		/// <summary>
		/// Pointer to a null-terminated Unicode string that contains the LDAP display name of the attribute corresponding to this metadata.
		/// </summary>
		public string pszAttributeName;

		/// <summary>
		/// Pointer to a null-terminated Unicode string that contains the distinguished name of the object that this attribute belongs to.
		/// </summary>
		public string pszObjectDn;

		/// <summary>Contains the number of bytes in the <c>pbData</c> array.</summary>
		public uint cbData;

		/// <summary>
		/// The binary_value portion of the attribute value if the attribute is of syntax Object(DN-Binary), or the string_value portion
		/// of the attribute value if the attribute is of syntax Object(DN-String); null otherwise.
		/// </summary>
		public IntPtr pbData;

		/// <summary>
		/// Contains a FILETIME structure that contains the time this attribute was deleted.
		/// </summary>
		public FILETIME ftimeDeleted;

		/// <summary>
		/// Contains a FILETIME structure that contains the time this attribute was created.
		/// </summary>
		public FILETIME ftimeCreated;

		/// <summary>
		/// Contains the version of this attribute. Each originating modification of the attribute increases this value by one.
		/// Replication of a modification does not affect the version.
		/// </summary>
		public uint dwVersion;

		/// <summary>
		/// Contains a FILETIME structure that contains the time at which the last originating change was made to this attribute.
		/// Replication of the change does not affect this value.
		/// </summary>
		public FILETIME ftimeLastOriginatingChange;

		/// <summary>
		/// Contains the invocation identifier of the server on which the last change was made to this attribute. Replication of the
		/// change does not affect this value.
		/// </summary>
		public Guid uuidLastOriginatingDsaInvocationID;

		/// <summary>
		/// Contains the update sequence number (USN) on the originating server at which the last change to this attribute was made.
		/// Replication of the change does not affect this value.
		/// </summary>
		public long usnOriginatingChange;

		/// <summary>
		/// Contains the USN on the destination server, that is the server from which the DsReplicaGetInfo2 function retrieved the
		/// metadata, at which the last change to this attribute was applied. This value is typically different on all servers.
		/// </summary>
		public long usnLocalChange;
	}

	/// <summary>
	/// The <c>DS_REPL_VALUE_META_DATA_2</c> structure is used with the DS_REPL_ATTR_VALUE_META_DATA_2 structure to contain attribute
	/// value replication metadata.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/ns-ntdsapi-_ds_repl_value_meta_data_2 typedef struct
	// _DS_REPL_VALUE_META_DATA_2 { PWSTR pszAttributeName; PWSTR pszObjectDn; DWORD cbData; #if ... BYTE *pbData; #else BYTE *pbData;
	// #endif FILETIME ftimeDeleted; FILETIME ftimeCreated; DWORD dwVersion; FILETIME ftimeLastOriginatingChange; UUID
	// uuidLastOriginatingDsaInvocationID; USN usnOriginatingChange; USN usnLocalChange; PWSTR pszLastOriginatingDsaDN; } DS_REPL_VALUE_META_DATA_2;
	[PInvokeData("ntdsapi.h", MSDNShortId = "747e32b8-2cc0-4fcd-88dc-027188598361")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct DS_REPL_VALUE_META_DATA_2
	{
		/// <summary>
		/// Pointer to a null-terminated Unicode string that contains the LDAP display name of the attribute that corresponds to this metadata.
		/// </summary>
		public string pszAttributeName;

		/// <summary>
		/// Pointer to a null-terminated Unicode string that contains the distinguished name of the object that this attribute belongs to.
		/// </summary>
		public string pszObjectDn;

		/// <summary>Contains the number of bytes in the <c>pbData</c> array.</summary>
		public uint cbData;

		/// <summary>
		/// The binary_value portion of the attribute value if the attribute is of syntax Object(DN-Binary), or the string_value portion
		/// of the attribute value if the attribute is of syntax Object(DN-String); null otherwise.
		/// </summary>
		public IntPtr pbData;

		/// <summary>
		/// Contains a FILETIME structure that contains the time this attribute was deleted.
		/// </summary>
		public FILETIME ftimeDeleted;

		/// <summary>
		/// Contains a FILETIME structure that contains the time this attribute was created.
		/// </summary>
		public FILETIME ftimeCreated;

		/// <summary>
		/// Contains the version of this attribute. Each originating modification of the attribute increases this value by one.
		/// Replication of a modification does not affect the version.
		/// </summary>
		public uint dwVersion;

		/// <summary>
		/// Contains a FILETIME structure that contains the time at which the last originating change was made to this attribute.
		/// Replication of the change does not affect this value.
		/// </summary>
		public FILETIME ftimeLastOriginatingChange;

		/// <summary>
		/// Contains the invocation identifier of the server on which the last change was made to this attribute. Replication of the
		/// change does not affect this value.
		/// </summary>
		public Guid uuidLastOriginatingDsaInvocationID;

		/// <summary>
		/// Contains the update sequence number (USN) on the originating server at which the last change to this attribute was made.
		/// Replication of the change does not affect this value.
		/// </summary>
		public long usnOriginatingChange;

		/// <summary>
		/// Contains the USN on the destination server, that is, the server from which the DsReplicaGetInfo2 function retrieved the
		/// metadata, at which the last change to this attribute was applied. This value is typically different on all servers.
		/// </summary>
		public long usnLocalChange;

		/// <summary>
		/// Pointer to a null-terminated Unicode string that contains the distinguished name of the directory system agent server that
		/// originated the last replication.
		/// </summary>
		public string pszLastOriginatingDsaDN;
	}

	/// <summary>
	/// The <c>DS_REPL_VALUE_META_DATA_BLOB</c> structure is used to contain attribute value replication metadata. This structure is
	/// similar to the DS_REPL_VALUE_META_DATA_2 structure, but is obtained from the Lightweight Directory Access Protocol API functions
	/// when obtaining binary data for the <c>msDS-ReplValueMetaData</c> attribute.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/ns-ntdsapi-_ds_repl_value_meta_data_blob typedef struct
	// _DS_REPL_VALUE_META_DATA_BLOB { DWORD oszAttributeName; DWORD oszObjectDn; DWORD cbData; DWORD obData; FILETIME ftimeDeleted;
	// FILETIME ftimeCreated; DWORD dwVersion; FILETIME ftimeLastOriginatingChange; UUID uuidLastOriginatingDsaInvocationID; USN
	// usnOriginatingChange; USN usnLocalChange; DWORD oszLastOriginatingDsaDN; } DS_REPL_VALUE_META_DATA_BLOB;
	[PInvokeData("ntdsapi.h", MSDNShortId = "7d8bb666-c5d8-43de-ab72-5b02b6e0593d")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct DS_REPL_VALUE_META_DATA_BLOB
	{
		/// <summary>
		/// Contains the offset, in bytes, from the address of this structure to a null-terminated Unicode string that contains the LDAP
		/// display name of the attribute corresponding to this metadata. A value of zero indicates an empty or <c>NULL</c> string.
		/// </summary>
		public uint oszAttributeName;

		/// <summary>
		/// Contains the offset, in bytes, from the address of this structure to a null-terminated Unicode string that contains the
		/// distinguished name of the object that this attribute belongs to. A value of zero indicates an empty or <c>NULL</c> string.
		/// </summary>
		public uint oszObjectDn;

		/// <summary>Contains the number of bytes in the <c>pbData</c> array.</summary>
		public uint cbData;

		/// <summary>
		/// Contains a 32-bit offset, in bytes, from the address of this structure to a buffer that contains the attribute replication
		/// metadata. The cbData member contains the length, in bytes, of this buffer.
		/// </summary>
		public uint obData;

		/// <summary>
		/// Contains a FILETIME structure that contains the time that this attribute was deleted.
		/// </summary>
		public FILETIME ftimeDeleted;

		/// <summary>
		/// Contains a FILETIME structure that contains the time that this attribute was created.
		/// </summary>
		public FILETIME ftimeCreated;

		/// <summary>
		/// Contains the version of this attribute. Each originating modification of the attribute increases this value by one.
		/// Replication of a modification does not affect the version.
		/// </summary>
		public uint dwVersion;

		/// <summary>
		/// Contains a FILETIME structure that contains the time at which the last originating change was made to this attribute.
		/// Replication of the change does not affect this value.
		/// </summary>
		public FILETIME ftimeLastOriginatingChange;

		/// <summary>
		/// Contains the invocation identifier of the server on which the last change was made to this attribute. Replication of the
		/// change does not affect this value.
		/// </summary>
		public Guid uuidLastOriginatingDsaInvocationID;

		/// <summary>
		/// Contains the update sequence number (USN) on the originating server at which the last change to this attribute was made.
		/// Replication of the change does not affect this value.
		/// </summary>
		public long usnOriginatingChange;

		/// <summary>
		/// Contains the USN on the destination server, that is, the server from which the DsReplicaGetInfo2 function retrieved the
		/// metadata, at which the last change to this attribute was applied. This value is typically different on all servers.
		/// </summary>
		public long usnLocalChange;

		/// <summary>
		/// Contains the offset, in bytes, from the address of this structure to a null-terminated Unicode string that contains the
		/// distinguished name of the directory system agent server that originated the last replication. A value of zero indicates an
		/// empty or <c>NULL</c> string.
		/// </summary>
		public uint oszLastOriginatingDsaDN;
	}

	/// <summary>
	/// Contains attribute value replication metadata. This structure is similar to the DS_REPL_VALUE_META_DATA_EXT structure, but is
	/// obtained from the Lightweight Directory Access Protocol API functions when obtaining binary data for the
	/// <c>msDS-ReplValueMetaData</c> attribute.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/ns-ntdsapi-_ds_repl_value_meta_data_blob_ext typedef struct
	// _DS_REPL_VALUE_META_DATA_BLOB_EXT { DWORD oszAttributeName; DWORD oszObjectDn; DWORD cbData; DWORD obData; FILETIME ftimeDeleted;
	// FILETIME ftimeCreated; DWORD dwVersion; FILETIME ftimeLastOriginatingChange; UUID uuidLastOriginatingDsaInvocationID; USN
	// usnOriginatingChange; USN usnLocalChange; DWORD oszLastOriginatingDsaDN; DWORD dwUserIdentifier; DWORD dwPriorLinkState; DWORD
	// dwCurrentLinkState; } DS_REPL_VALUE_META_DATA_BLOB_EXT;
	[PInvokeData("ntdsapi.h", MSDNShortId = "095180F4-9E3F-47EE-B39E-107D7D219DCB")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct DS_REPL_VALUE_META_DATA_BLOB_EXT
	{
		/// <summary>
		/// Contains the offset, in bytes, from the address of this structure to a null-terminated Unicode string that contains the LDAP
		/// display name of the attribute corresponding to this metadata. A value of zero indicates an empty or <c>NULL</c> string.
		/// </summary>
		public uint oszAttributeName;

		/// <summary>
		/// Contains the offset, in bytes, from the address of this structure to a null-terminated Unicode string that contains the
		/// distinguished name of the object that this attribute belongs to. A value of zero indicates an empty or <c>NULL</c> string.
		/// </summary>
		public uint oszObjectDn;

		/// <summary>Contains the number of bytes in the <c>pbData</c> array.</summary>
		public uint cbData;

		/// <summary>
		/// Pointer to a buffer that contains the attribute replication metadata. The <c>cbData</c> member contains the length, in bytes,
		/// of this buffer.
		/// </summary>
		public uint obData;

		/// <summary>
		/// Contains a FILETIME structure that contains the time that this attribute was deleted.
		/// </summary>
		public FILETIME ftimeDeleted;

		/// <summary>
		/// Contains a FILETIME structure that contains the time that this attribute was created.
		/// </summary>
		public FILETIME ftimeCreated;

		/// <summary>
		/// Contains the version of this attribute. Each originating modification of the attribute increases this value by one.
		/// Replication of a modification does not affect the version.
		/// </summary>
		public uint dwVersion;

		/// <summary>
		/// Contains a FILETIME structure that contains the time at which the last originating change was made to this attribute.
		/// Replication of the change does not affect this value.
		/// </summary>
		public FILETIME ftimeLastOriginatingChange;

		/// <summary>
		/// Contains the invocation identifier of the server on which the last change was made to this attribute. Replication of the
		/// change does not affect this value.
		/// </summary>
		public Guid uuidLastOriginatingDsaInvocationID;

		/// <summary>
		/// Contains the update sequence number (USN) on the originating server at which the last change to this attribute was made.
		/// Replication of the change does not affect this value.
		/// </summary>
		public long usnOriginatingChange;

		/// <summary>
		/// Contains the USN on the destination server, that is, the server from which the DsReplicaGetInfo2 function retrieved the
		/// metadata, at which the last change to this attribute was applied. This value is typically different on all servers.
		/// </summary>
		public long usnLocalChange;

		/// <summary>
		/// Contains the offset, in bytes, from the address of this structure to a null-terminated Unicode string that contains the
		/// distinguished name of the directory system agent server that originated the last replication. A value of zero indicates an
		/// empty or <c>NULL</c> string.
		/// </summary>
		public uint oszLastOriginatingDsaDN;

		/// <summary>TBD</summary>
		public uint dwUserIdentifier;

		/// <summary>TBD</summary>
		public uint dwPriorLinkState;

		/// <summary>TBD</summary>
		public uint dwCurrentLinkState;
	}

	/// <summary>
	/// Contains attribute replication meta data for the DS_REPL_ATTR_VALUE_META_DATA_EXT structure.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/ns-ntdsapi-_ds_repl_value_meta_data_ext typedef struct
	// _DS_REPL_VALUE_META_DATA_EXT { PWSTR pszAttributeName; PWSTR pszObjectDn; DWORD cbData; #if ... BYTE *pbData; #else BYTE
	// *pbData; #endif FILETIME ftimeDeleted; FILETIME ftimeCreated; DWORD dwVersion; FILETIME ftimeLastOriginatingChange; UUID
	// uuidLastOriginatingDsaInvocationID; USN usnOriginatingChange; USN usnLocalChange; PWSTR pszLastOriginatingDsaDN; DWORD
	// dwUserIdentifier; DWORD dwPriorLinkState; DWORD dwCurrentLinkState; } DS_REPL_VALUE_META_DATA_EXT;
	[PInvokeData("ntdsapi.h", MSDNShortId = "2BE0F9C4-D688-4DE6-8DB2-15666D8BD070")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	public struct DS_REPL_VALUE_META_DATA_EXT
	{
		/// <summary>
		/// Pointer to a null-terminated Unicode string that contains the LDAP display name of the attribute corresponding to this metadata.
		/// </summary>
		public string pszAttributeName;

		/// <summary>
		/// Pointer to a null-terminated Unicode string that contains the distinguished name of the object that this attribute belongs to.
		/// </summary>
		public string pszObjectDn;

		/// <summary>Contains the number of bytes in the <c>pbData</c> array.</summary>
		public uint cbData;

		/// <summary>
		/// Pointer to a buffer that contains the attribute replication metadata. The <c>cbData</c> member contains the length, in bytes,
		/// of this buffer.
		/// </summary>
		public IntPtr pbData;

		/// <summary>
		/// Contains a FILETIME structure that contains the time this attribute was deleted.
		/// </summary>
		public FILETIME ftimeDeleted;

		/// <summary>
		/// Contains a FILETIME structure that contains the time this attribute was created.
		/// </summary>
		public FILETIME ftimeCreated;

		/// <summary>
		/// Contains the version of this attribute. Each originating modification of the attribute increases this value by one.
		/// Replication of a modification does not affect the version.
		/// </summary>
		public uint dwVersion;

		/// <summary>
		/// Contains a FILETIME structure that contains the time at which the last originating change was made to this attribute.
		/// Replication of the change does not affect this value.
		/// </summary>
		public FILETIME ftimeLastOriginatingChange;

		/// <summary>
		/// Contains the invocation identifier of the server on which the last change was made to this attribute. Replication of the
		/// change does not affect this value.
		/// </summary>
		public Guid uuidLastOriginatingDsaInvocationID;

		/// <summary>
		/// Contains the update sequence number (USN) on the originating server at which the last change to this attribute was made.
		/// Replication of the change does not affect this value.
		/// </summary>
		public long usnOriginatingChange;

		/// <summary>
		/// Contains the USN on the destination server, that is the server from which the DsReplicaGetInfo2 function retrieved the
		/// metadata, at which the last change to this attribute was applied. This value is typically different on all servers.
		/// </summary>
		public long usnLocalChange;

		/// <summary>
		/// Pointer to a null-terminated Unicode string that contains the distinguished name of the directory system agent server that
		/// originated the last replication.
		/// </summary>
		public string pszLastOriginatingDsaDN;

		/// <summary>TBD</summary>
		public uint dwUserIdentifier;

		/// <summary>TBD</summary>
		public uint dwPriorLinkState;

		/// <summary>TBD</summary>
		public uint dwCurrentLinkState;
	}

	/// <summary>
	/// The <c>DS_REPSYNCALL_ERRINFO</c> structure is used with the DS_REPSYNCALL_UPDATE structure to contain errors generated by the
	/// DsReplicaSyncAll function during replication.
	/// </summary>
	// https://webcache.googleusercontent.com/search?q=cache:0plHTsXYeJ0J:https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/ns-ntdsapi-ds_repsyncall_errinfoa+&cd=1&hl=en&ct=clnk&gl=us
	// typedef struct DS_REPSYNCALL_ERRINFOA { PSTR pszSvrId; DS_REPSYNCALL_ERROR error; DWORD dwWin32Err; PSTR pszSrcId; } *PDS_REPSYNCALL_ERRINFOA;
	[PInvokeData("ntdsapi.h", MSDNShortId = "70af4e3e-1f0e-49c5-b8c6-5e89114ed4ea")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct DS_REPSYNCALL_ERRINFO
	{
		/// <summary>
		/// Pointer to a null-terminated string that contains the DNS GUID of the server where the error occurred. Alternatively, this
		/// member can contain the distinguished name of the server if <c>DS_REPSYNCALL_ID_SERVERS_BY_DN</c> is specified in the ulFlags
		/// parameter of the DsReplicaSyncAll function.
		/// </summary>
		public string pszSvrId;

		/// <summary>
		/// Contains one of the DS_REPSYNCALL_ERROR values that indicates where in the replication process the error occurred.
		/// </summary>
		public DS_REPSYNCALL_ERROR error;

		/// <summary>
		/// Indicates the actual Win32 error code generated during replication between the source server referred to by <c>pszSrcId</c>
		/// and the destination server referred to by <c>pszSvrId</c>.
		/// </summary>
		public Win32Error dwWin32Err;

		/// <summary>
		/// Pointer to a null-terminated string that specifies the DNS GUID of the source server. Alternatively, this member can contain
		/// the distinguished name of the source server if <c>DS_REPSYNCALL_ID_SERVERS_BY_DN</c> is specified in the ulFlags parameter of
		/// the DsReplicaSyncAll function.
		/// </summary>
		public string pszSrcId;
	}

	/// <summary>
	/// The <c>DS_REPSYNCALL_UPDATE</c> structure contains status data about the replication performed by the DsReplicaSyncAll function.
	/// The <c>DsReplicaSyncAll</c> function passes this structure to a callback function in its pFnCallBack parameter. For more
	/// information about the callback function, see SyncUpdateProc.
	/// </summary>
	// https://webcache.googleusercontent.com/search?q=cache:-LzmvZ2eMGsJ:https://docs.microsoft.com/en-us/windows/desktop/api/ntdsapi/ns-ntdsapi-ds_repsyncall_updatea+&cd=1&hl=en&ct=clnk&gl=us
	// typedef struct DS_REPSYNCALL_UPDATEA { DS_REPSYNCALL_EVENT event; DS_REPSYNCALL_ERRINFOA *pErrInfo; DS_REPSYNCALL_SYNCA *pSync; } *PDS_REPSYNCALL_UPDATEA;
	[PInvokeData("ntdsapi.h", MSDNShortId = "3b0005cb-0fb6-492c-89e5-8a18a88f881b")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct DS_REPSYNCALL_UPDATE
	{
		/// <summary>
		/// Contains a DS_REPSYNCALL_EVENT value that describes the event which the <c>DS_REPSYNCALL_UPDATE</c> structure represents.
		/// </summary>
		public DS_REPSYNCALL_EVENT cEvent;

		/// <summary>
		/// Pointer to a DS_REPSYNCALL_ERRINFO structure that contains error data about the replication performed by the DsReplicaSyncAll function.
		/// </summary>
		public IntPtr pErrInfo;

		/// <summary>
		/// Pointer to a DS_REPSYNCALL_SYNC structure that identifies the source and destination servers that have either initiated or
		/// finished synchronization.
		/// </summary>
		public IntPtr pSync;
	}

	/// <summary>
	/// The DS_SCHEMA_GUID_MAP structure contains the results of a call to DsMapSchemaGuids. If DsMapSchemaGuids succeeds in mapping a
	/// GUID, DS_SCHEMA_GUID_MAP contains both the GUID and a display name for the object to which the GUID refers.
	/// </summary>
	[PInvokeData("ntdsapi.h")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct DS_SCHEMA_GUID_MAP
	{
		/// <summary>GUID structure that specifies the object GUID.</summary>
		public Guid guid;

		/// <summary>Indicates the type of GUID mapped by DsMapSchemaGuids.</summary>
		public DsSchemaGuidType guidType;

		/// <summary>
		/// Pointer to a null-terminated string value that specifies the display name associated with the GUID. This value may be NULL if
		/// DsMapSchemaGuids was unable to map the GUID to a display name.
		/// </summary>
		public string pName;
	}

	/// <summary>
	/// The <c>DS_SITE_COST_INFO</c> structure is used with the <c>DsQuerySitesByCost</c> function to contain communication cost data.
	/// </summary>
	// https://msdn.microsoft.com/en-us/windows/ms676286(v=vs.80).aspx
	[PInvokeData("ntdsapi.h")]
	[StructLayout(LayoutKind.Sequential)]
	public struct DS_SITE_COST_INFO
	{
		/// <summary>
		/// Contains a success or error code that indicates if the cost data for the site could be obtained. This member can contain one
		/// of the following values.
		/// <list type="bullet">
		/// <item>
		/// <term>ERROR_SUCCESS</term>
		/// <description>The communication cost of the site was obtained and is contained in the cost member of this structure.</description>
		/// </item>
		/// <item>
		/// <term>ERROR_DS_OBJ_NOT_FOUND</term>
		/// <description>The communication cost of the site cannot be obtained. The cost member of this structure should be ignored.</description>
		/// </item>
		/// </list>
		/// </summary>
		public Win32Error errorCode;

		/// <summary>
		/// If the <c>errorCode</c> member contains <c>ERROR_SUCCESS</c>, this member contains the communication cost value of the site.
		/// If the <c>errorCode</c> member contains <c>ERROR_DS_OBJ_NOT_FOUND</c>, this contents of this member is undefined.
		/// </summary>
		public uint cost;
	}

	/// <summary>
	/// The <c>SCHEDULE_HEADER</c> structure is used to contain the replication schedule data for a replication source. The SCHEDULE
	/// structure contains an array of <c>SCHEDULE_HEADER</c> structures.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/schedule/ns-schedule-_schedule_header typedef struct _SCHEDULE_HEADER { ULONG
	// Type; ULONG Offset; } SCHEDULE_HEADER, *PSCHEDULE_HEADER;
	[PInvokeData("schedule.h", MSDNShortId = "5453927e-306e-4442-a855-916005dc8e3b")]
	[StructLayout(LayoutKind.Sequential)]
	public struct SCHEDULE_HEADER
	{
		/// <summary>
		/// <para>Contains one of the following values that defines the type of schedule data that is contained in this structure.</para>
		/// <para>SCHEDULE_INTERVAL</para>
		/// <para>
		/// The schedule contains a set of intervals. The <c>Offset</c> member contains the offset to an array of bytes with
		/// <c>SCHEDULE_DATA_ENTRIES</c> elements. Each byte in the array represents an hour of the week. The first hour is 00:00 on
		/// Sunday morning GMT.
		/// </para>
		/// <para>
		/// Each bit of the lower four bits of each byte represents a 15 minute block within the hour that the source is available for
		/// replication. The following list lists the binary values and describes each bit of the lower four bits of the hour value.
		/// </para>
		/// <list type="table">
		///   <listheader>
		///     <term>Binary value</term>
		///     <term>Description</term>
		///   </listheader>
		///   <item>
		///     <term>1000</term>
		///     <term>The source is available for replication from 0 to 14 minutes after the hour.</term>
		///   </item>
		///   <item>
		///     <term>0100</term>
		///     <term>The source is available for replication from 15 to 29 minutes after the hour.</term>
		///   </item>
		///   <item>
		///     <term>0010</term>
		///     <term>The source is available for replication from 30 to 44 minutes after the hour.</term>
		///   </item>
		///   <item>
		///     <term>0001</term>
		///     <term>The source is available for replication from 45 to 59 minutes after the hour.</term>
		///   </item>
		/// </list>
		/// <para>
		/// These bits can be combined to create multiple 15 minute blocks that the source is available. For example, a binary value of
		/// 0111 indicates that the source is available from 0 to 44 minutes after the hour.
		/// </para>
		/// <para>The upper fours bits of each byte are not used.</para>
		/// <para>SCHEDULE_BANDWIDTH</para>
		/// <para>Not supported.</para>
		/// <para>SCHEDULE_PRIORITY</para>
		/// <para>Not supported.</para>
		/// </summary>
		public ScheduleType Type;

		/// <summary>
		/// Contains the offset, in bytes, from the beginning of the SCHEDULE structure to the data for this schedule. The size and form
		/// of this data depends on the schedule type defined by the <c>Type</c> member.
		/// </summary>
		public uint Offset;
	}

	/// <summary>Provides a handle to an array of one or more service principal names (SPNs).</summary>
	[AutoHandle]
	public partial struct SpnArrayHandle
	{
		/// <summary>Gets the list of service principle names (SPNs) from this handle.</summary>
		/// <param name="count">The count returned in the pcSpn parameter of <see cref="DsGetSpn"/>.</param>
		/// <returns>The list of SPNs.</returns>
		public IEnumerable<string?> GetSPNs(uint count) => handle.ToStringEnum((int)count);
	}

	/// <summary>Provides a <see cref="SafeHandle"/> to an authentication identity that releases its handle at disposal using DsFreePasswordCredentials.</summary>
	[AutoSafeHandle("{ DsFreePasswordCredentials(handle); return true; }")]
	public partial class SafeAuthIdentityHandle
	{
		/// <summary>Gets a value that marshals as NULL so that the local thread's identity is used.</summary>
		public static readonly SafeAuthIdentityHandle LocalThreadIdentity = new();
	}

	/// <summary>Provides a safe handle to an array of DS_REPSYNCALL_ERRINFO structures returned from <see cref="DsReplicaSyncAll"/>.</summary>
	/// <seealso cref="Vanara.InteropServices.GenericSafeHandle"/>
	public class SafeDS_REPSYNCALL_ERRINFOArray : GenericSafeHandle, IReadOnlyCollection<DS_REPSYNCALL_ERRINFO>
	{
		internal SafeDS_REPSYNCALL_ERRINFOArray() : base(IntPtr.Zero, h => LocalFree(h) == IntPtr.Zero)
		{
		}

		/// <inheritdoc/>
		public int Count => IsInvalid ? 0 : handle.GetNulledPtrArrayLength();

		/// <summary>Gets the array of DS_REPSYNCALL_ERRINFO structures.</summary>
		public DS_REPSYNCALL_ERRINFO[] Items => IsInvalid ? new DS_REPSYNCALL_ERRINFO[0] : handle.ToArray<DS_REPSYNCALL_ERRINFO>(Count)!;

		/// <inheritdoc/>
		public IEnumerator<DS_REPSYNCALL_ERRINFO> GetEnumerator() => Array.AsReadOnly(Items).GetEnumerator();

		/// <inheritdoc/>
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		private static extern IntPtr LocalFree(IntPtr hMem);
	}

	/// <summary>A <see cref="SafeHandle"/> for handles bound to directory services.</summary>
	/// <seealso cref="Microsoft.Win32.SafeHandles.SafeHandleZeroOrMinusOneIsInvalid"/>
	[SuppressUnmanagedCodeSecurity, ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
	[PInvokeData("NTDSApi.h")]
	[AutoSafeHandle("DsUnBind(ref handle).Succeeded")]
	public partial class SafeDsHandle { }

	/// <summary>
	/// A <see cref="SafeHandle"/> for the results from <see
	/// cref="DsCrackNames(SafeDsHandle,DS_NAME_FLAGS,DS_NAME_FORMAT,DS_NAME_FORMAT,uint,string[],out SafeDsNameResult)"/>.
	/// </summary>
	/// <seealso cref="GenericSafeHandle"/>
	[PInvokeData("NTDSApi.h")]
	public class SafeDsNameResult : GenericSafeHandle, IEnumerable<DS_NAME_RESULT_ITEM>
	{
		/// <summary>Initializes a new instance of the <see cref="SafeDsNameResult"/> class.</summary>
		public SafeDsNameResult() : base(h => { DsFreeNameResult(h); return true; }) { }

		/// <summary>An array of DS_NAME_RESULT_ITEM structures. Each element of this array represents a single converted name.</summary>
		public DS_NAME_RESULT_ITEM[] Items => IsInvalid ? new DS_NAME_RESULT_ITEM[0] : handle.ToStructure<DS_NAME_RESULT>().Items!;

		/// <inheritdoc/>
		public IEnumerator<DS_NAME_RESULT_ITEM> GetEnumerator() => ((IEnumerable<DS_NAME_RESULT_ITEM>)Items).GetEnumerator();

		/// <inheritdoc/>
		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}

	/// <summary>A <see cref="SafeHandle"/> for the results from <see cref="DsQuerySitesByCost"/>.</summary>
	/// <seealso cref="GenericSafeHandle"/>
	[PInvokeData("NTDSApi.h")]
	public class SafeDsQuerySites : GenericSafeHandle
	{
		/// <summary>Initializes a new instance of the <see cref="SafeDsNameResult"/> class.</summary>
		public SafeDsQuerySites() : base(h => { DsQuerySitesFree(h); return true; }) { }

		/// <summary>Gets an array of DS_SITE_COST_INFO structures.</summary>
		/// <param name="cToSites">
		/// <para>Indicates the number of elements in the array. This value is the same value as that passed into <see cref="DsQuerySitesByCost"/>.</para>
		/// </param>
		public DS_SITE_COST_INFO[] GetItems(int cToSites) => IsInvalid ? new DS_SITE_COST_INFO[0] : handle.ToArray<DS_SITE_COST_INFO>(cToSites)!;
	}

	/// <summary>A <see cref="SafeHandle"/> for the results from <see cref="DsReplicaGetInfo2W(SafeDsHandle, DS_REPL_INFO_TYPE, string, Guid?, string, string, DsReplInfoFlags, uint, out SafeDsReplicaInfo)"/>.</summary>
	[PInvokeData("NTDSApi.h")]
	public class SafeDsReplicaInfo : SafeHANDLE
	{
		internal SafeDsReplicaInfo()
		{
		}

		/// <summary>Gets the value.</summary>
		/// <value>The value.</value>
		public object? Value
		{
			get
			{
				var t = CorrespondingTypeAttribute.GetCorrespondingTypes(Type).FirstOrDefault();
				return t == null || IsInvalid ? null : handle.Convert(uint.MaxValue, t);
			}
		}

		internal DS_REPL_INFO_TYPE Type { get; set; }

		/// <summary>Gets the requested structure.</summary>
		/// <typeparam name="T">Type of the structure</typeparam>
		/// <returns>The structure.</returns>
		public T GetValue<T>() where T : struct
		{
			if (!CorrespondingTypeAttribute.CanGet(Type, typeof(T))) throw new InvalidCastException();
			return handle.ToStructure<T>();
		}

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle()
		{
			DsReplicaFreeInfo(Type, handle);
			return true;
		}
	}

	/// <summary>A <see cref="SafeHandle"/> for the results from <see cref="DsMapSchemaGuids"/>.</summary>
	/// <seealso cref="GenericSafeHandle"/>
	[PInvokeData("NTDSApi.h")]
	public class SafeDsSchemaGuidMap : GenericSafeHandle
	{
		/// <summary>Initializes a new instance of the <see cref="SafeDsNameResult"/> class.</summary>
		public SafeDsSchemaGuidMap() : base(h => { DsFreeSchemaGuidMap(h); return true; }) { }

		/// <summary>Gets an array of DS_SCHEMA_GUID_MAP structures.</summary>
		/// <param name="cGuids">
		/// <para>Indicates the number of elements in the array. This value is the same value as that passed into <see cref="DsMapSchemaGuids"/>.</para>
		/// </param>
		public DS_SCHEMA_GUID_MAP[] GetItems(int cGuids) => IsInvalid ? new DS_SCHEMA_GUID_MAP[0] : handle.ToArray<DS_SCHEMA_GUID_MAP>(cGuids)!;
	}

	/// <summary>
	/// <para>
	/// The <c>SCHEDULE</c> structure is a variable-length structure used with the DsReplicaAdd and DsReplicaModify functions to contain
	/// replication schedule data for a replication source.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/schedule/ns-schedule-_schedule typedef struct _SCHEDULE { ULONG Size; ULONG
	// Bandwidth; ULONG NumberOfSchedules; SCHEDULE_HEADER Schedules[1]; } SCHEDULE, *PSCHEDULE;
	[PInvokeData("schedule.h", MSDNShortId = "d86890db-b34a-415a-820a-6d4790914218")]
	[StructLayout(LayoutKind.Sequential)]
	public class SCHEDULE : IDisposable
	{
		private const int intervalByteCount = 24 * 7;

		/// <summary>Initializes a new instance of the <see cref="SCHEDULE"/> class.</summary>
		/// <param name="scheduleIntervals">The schedule intervals. See <see cref="ScheduleIntervals"/> for detail about this array.</param>
		/// <exception cref="System.ArgumentOutOfRangeException">
		/// scheduleIntervals - Array must have at least 1 schedule and have a second dimension of 24 x 7 bytes.
		/// </exception>
		public SCHEDULE(byte[,] scheduleIntervals)
		{
			if (scheduleIntervals is null || scheduleIntervals.GetLength(0) == 0 || scheduleIntervals.GetLength(1) != intervalByteCount)
				throw new ArgumentOutOfRangeException(nameof(scheduleIntervals), "Array must have at least 1 schedule and have a second dimension of 24 x 7 bytes.");
			NumberOfSchedules = (uint)scheduleIntervals.GetLength(0);
			var hdrSz = NumberOfSchedules * (intervalByteCount + 8);
			_Schedules = Marshal.AllocCoTaskMem((int)hdrSz);
			var scheds = new SCHEDULE_HEADER[NumberOfSchedules];
			Size = (uint)(12 + IntPtr.Size);
			var schMemOffset = Size + NumberOfSchedules * Marshal.SizeOf(typeof(SCHEDULE_HEADER));
			var offset = 0;
			for (var i = 0; i < NumberOfSchedules; i++)
			{
				scheds[i] = new SCHEDULE_HEADER { Type = ScheduleType.SCHEDULE_INTERVAL, Offset = (uint)(offset + schMemOffset) };
				unsafe
				{
					var schOff = (byte*)_Schedules.Offset(offset).ToPointer();
					fixed (byte* retptr = &scheduleIntervals[i, 0])
					{
						for (var x = 0; x < intervalByteCount; x++)
							schOff[x] = retptr[x];
					}
				}
				offset += intervalByteCount;
			}
			Size += hdrSz;
		}

		/// <summary>
		/// <para>
		/// Contains the size, in bytes, of the <c>SCHEDULE</c> structure, including the size of all of the elements and data of the
		/// <c>Schedules</c> array.
		/// </para>
		/// </summary>
		public readonly uint Size;

		/// <summary>
		/// <para>Not used.</para>
		/// </summary>
		public readonly uint Bandwidth;

		/// <summary>
		/// <para>Contains the number of elements in the <c>Schedules</c> array.</para>
		/// </summary>
		public readonly uint NumberOfSchedules;

		/// <summary>
		/// <para>
		/// Contains an array of SCHEDULE_HEADER structures that contain the replication schedule data for the replication source. The
		/// <c>NumberOfSchedules</c> member contains the number of elements in this array. Currently, this array can only contain one element.
		/// </para>
		/// </summary>
		private IntPtr _Schedules;

		/// <summary>
		/// <para>
		/// Contains an array of SCHEDULE_HEADER structures that contain the replication schedule data for the replication source. The
		/// <c>NumberOfSchedules</c> member contains the number of elements in this array. Currently, this array can only contain one element.
		/// </para>
		/// </summary>
		public SCHEDULE_HEADER[] Schedules => _Schedules.ToArray<SCHEDULE_HEADER>((int)NumberOfSchedules) ?? new SCHEDULE_HEADER[0];

		/// <summary>
		/// <para>
		/// Gets a two-dimensional array of bytes for each schedule with 7 x 24 elements. Each byte in the array represents an hour of
		/// the week. The first hour is 00:00 on Sunday morning GMT.
		/// </para>
		/// <para>
		/// Each bit of the lower four bits of each byte represents a 15 minute block within the hour that the source is available for
		/// replication. The following list lists the binary values and describes each bit of the lower four bits of the hour value.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Binary value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>1000</term>
		/// <term>The source is available for replication from 0 to 14 minutes after the hour.</term>
		/// </item>
		/// <item>
		/// <term>0100</term>
		/// <term>The source is available for replication from 15 to 29 minutes after the hour.</term>
		/// </item>
		/// <item>
		/// <term>0010</term>
		/// <term>The source is available for replication from 30 to 44 minutes after the hour.</term>
		/// </item>
		/// <item>
		/// <term>0001</term>
		/// <term>The source is available for replication from 45 to 59 minutes after the hour.</term>
		/// </item>
		/// </list>
		/// <para>
		/// These bits can be combined to create multiple 15 minute blocks that the source is available. For example, a binary value of
		/// 0111 indicates that the source is available from 0 to 44 minutes after the hour.
		/// </para>
		/// <para>The upper fours bits of each byte are not used.</para>
		/// </summary>
		public byte[,] ScheduleIntervals
		{
			get
			{
				var s = Schedules;
				var ret = new byte[s.Length, intervalByteCount];
				for (var i = 0; i < s.Length; i++)
				{
					if (s[i].Type != ScheduleType.SCHEDULE_INTERVAL) continue;
					var offset = (int)s[i].Offset;
					unsafe
					{
						fixed (SCHEDULE_HEADER* sptr = &s[i])
						fixed (byte* retptr = &ret[i, 0])
						{
							var sbptr = (byte*)sptr;
							for (var x = 0; x < intervalByteCount; x++)
								retptr[x] = sbptr[x + offset];
						}
					}
				}
				return ret;
			}
		}

		void IDisposable.Dispose() => Marshal.FreeCoTaskMem(_Schedules);
	}
}