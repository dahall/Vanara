using System;
using System.Runtime.InteropServices;
using Vanara.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class NetApi32
	{
		/// <summary>Flags that provide additional domain data.</summary>
		[PInvokeData("dsrole.h", MSDNShortId = "8a7b34e8-46d6-46dc-9fef-ec37b0f65eea")]
		[Flags]
		public enum DSROLE_FLAGS : uint
		{
			/// <summary>
			/// <para>The directory service is running on this computer.</para>
			/// </summary>
			DSROLE_PRIMARY_DS_RUNNING = 0x00000001,

			/// <summary>
			/// <para>
			/// The directory service is running in mixed mode. This flag is valid only if the <c>DSROLE_PRIMARY_DS_RUNNING</c> flag is set.
			/// </para>
			/// </summary>
			DSROLE_PRIMARY_DS_MIXED_MODE = 0x00000002,

			/// <summary>
			/// <para>The computer is being upgraded from a previous version of Windows NT/Windows 2000.</para>
			/// </summary>
			DSROLE_UPGRADE_IN_PROGRESS = 0x00000004,

			/// <summary>
			/// <para>The directory service is running as read-only on this computer.</para>
			/// </summary>
			DSROLE_PRIMARY_DS_READONLY = 0x00000008,

			/// <summary>
			/// <para>The <c>DomainGuid</c> member contains a valid domain <c>GUID</c>.</para>
			/// </summary>
			DSROLE_PRIMARY_DOMAIN_GUID_PRESENT = 0x01000000,
		}

		/// <summary>
		/// <para>
		/// The <c>DSROLE_MACHINE_ROLE</c> enumeration is used with the <c>MachineRole</c> member of the DSROLE_PRIMARY_DOMAIN_INFO_BASIC
		/// structure to specify the computer role.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/dsrole/ne-dsrole-_dsrole_machine_role typedef enum _DSROLE_MACHINE_ROLE {
		// DsRole_RoleStandaloneWorkstation , DsRole_RoleMemberWorkstation , DsRole_RoleStandaloneServer , DsRole_RoleMemberServer ,
		// DsRole_RoleBackupDomainController , DsRole_RolePrimaryDomainController } DSROLE_MACHINE_ROLE;
		[PInvokeData("dsrole.h", MSDNShortId = "d5255070-71dd-4510-8bec-a84726a241c6")]
		public enum DSROLE_MACHINE_ROLE
		{
			/// <summary>The computer is a workstation that is not a member of a domain.</summary>
			DsRole_RoleStandaloneWorkstation,

			/// <summary>The computer is a workstation that is a member of a domain.</summary>
			DsRole_RoleMemberWorkstation,

			/// <summary>The computer is a server that is not a member of a domain.</summary>
			DsRole_RoleStandaloneServer,

			/// <summary>The computer is a server that is a member of a domain.</summary>
			DsRole_RoleMemberServer,

			/// <summary>The computer is a backup domain controller.</summary>
			DsRole_RoleBackupDomainController,

			/// <summary>The computer is a primary domain controller.</summary>
			DsRole_RolePrimaryDomainController,
		}

		/// <summary>
		/// <para>
		/// The <c>DSROLE_OPERATION_STATE</c> enumeration is used with the DSROLE_OPERATION_STATE_INFO structure to indicate the operational
		/// state of a computer.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/dsrole/ne-dsrole-_dsrole_operation_state typedef enum _DSROLE_OPERATION_STATE
		// { DsRoleOperationIdle , DsRoleOperationActive , DsRoleOperationNeedReboot } DSROLE_OPERATION_STATE;
		[PInvokeData("dsrole.h", MSDNShortId = "de294893-e78a-4b51-9a48-0c71f91b6fde")]
		public enum DSROLE_OPERATION_STATE
		{
			/// <summary>The computer is idle.</summary>
			DsRoleOperationIdle,

			/// <summary>The computer is active.</summary>
			DsRoleOperationActive,

			/// <summary>The computer requires a restart.</summary>
			DsRoleOperationNeedReboot,
		}

		/// <summary>
		/// <para>
		/// The <c>DSROLE_PRIMARY_DOMAIN_INFO_LEVEL</c> enumeration is used with the DsRoleGetPrimaryDomainInformation function to specify
		/// the type of data to retrieve.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/dsrole/ne-dsrole-_dsrole_primary_domain_info_level typedef enum
		// _DSROLE_PRIMARY_DOMAIN_INFO_LEVEL { DsRolePrimaryDomainInfoBasic , DsRoleUpgradeStatus , DsRoleOperationState } DSROLE_PRIMARY_DOMAIN_INFO_LEVEL;
		[PInvokeData("dsrole.h", MSDNShortId = "c8b141b1-d5fa-4ec9-8899-a1b0f6a4ce1d")]
		public enum DSROLE_PRIMARY_DOMAIN_INFO_LEVEL
		{
			/// <summary>The DsRoleGetPrimaryDomainInformation function retrieves data from a DSROLE_PRIMARY_DOMAIN_INFO_BASIC structure.</summary>
			[CorrespondingType(typeof(DSROLE_PRIMARY_DOMAIN_INFO_BASIC), CorrespondingAction.Get)]
			DsRolePrimaryDomainInfoBasic = 1,

			/// <summary>The DsRoleGetPrimaryDomainInformation function retrieves from a DSROLE_UPGRADE_STATUS_INFO structure.</summary>
			[CorrespondingType(typeof(DSROLE_UPGRADE_STATUS_INFO), CorrespondingAction.Get)]
			DsRoleUpgradeStatus,

			/// <summary>The DsRoleGetPrimaryDomainInformation function retrieves data from a DSROLE_OPERATION_STATE_INFO structure.</summary>
			[CorrespondingType(typeof(DSROLE_OPERATION_STATE_INFO), CorrespondingAction.Get)]
			DsRoleOperationState,
		}

		/// <summary>
		/// <para>
		/// The <c>DSROLE_SERVER_STATE</c> enumeration is used with the DSROLE_UPGRADE_STATUS_INFO structure to indicate the role of a server.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/dsrole/ne-dsrole-_dsrole_server_state typedef enum _DSROLE_SERVER_STATE {
		// DsRoleServerUnknown , DsRoleServerPrimary , DsRoleServerBackup } DSROLE_SERVER_STATE, *PDSROLE_SERVER_STATE;
		[PInvokeData("dsrole.h", MSDNShortId = "cd15aa25-7a73-475f-b163-30e5dc1f52bd")]
		public enum DSROLE_SERVER_STATE
		{
			/// <summary>The server role is unknown.</summary>
			DsRoleServerUnknown,

			/// <summary>The server was, or is, a primary domain controller.</summary>
			DsRoleServerPrimary,

			/// <summary>The server was, or is, a backup domain controller.</summary>
			DsRoleServerBackup,
		}

		/// <summary>
		/// <para>The <c>DsRoleFreeMemory</c> function frees memory allocated by the DsRoleGetPrimaryDomainInformation function.</para>
		/// </summary>
		/// <param name="Buffer">
		/// <para>Pointer to the buffer to be freed.</para>
		/// </param>
		/// <returns>
		/// <para>This function does not return a value.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/dsrole/nf-dsrole-dsrolefreememory void DsRoleFreeMemory( IN PVOID Buffer );
		[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("dsrole.h", MSDNShortId = "5560dfec-2134-4e02-9c87-26d246cd5841")]
		public static extern void DsRoleFreeMemory(IntPtr Buffer);

		/// <summary>
		/// The <c>DsRoleGetPrimaryDomainInformation</c> function retrieves state data for the computer. This data includes the state of the
		/// directory service installation and domain data.
		/// </summary>
		/// <param name="lpServer">
		/// Pointer to null-terminated Unicode string that contains the name of the computer on which to call the function. If this parameter
		/// is <c>NULL</c>, the local computer is used.
		/// </param>
		/// <param name="InfoLevel">
		/// Contains one of the DSROLE_PRIMARY_DOMAIN_INFO_LEVEL values that specify the type of data to retrieve. This parameter also
		/// determines the format of the data supplied in Buffer.
		/// </param>
		/// <param name="Buffer">
		/// <para>
		/// Pointer to the address of a buffer that receives the requested data. The format of this data depends on the value of the
		/// InfoLevel parameter.
		/// </para>
		/// <para>The caller must free this memory when it is no longer required by calling DsRoleFreeMemory.</para>
		/// </param>
		/// <returns>
		/// <para>If the function is successful, the return value is <c>ERROR_SUCCESS</c>.</para>
		/// <para>If the function fails, the return value can be one of the following values.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/dsrole/nf-dsrole-dsrolegetprimarydomaininformation DWORD
		// DsRoleGetPrimaryDomainInformation( IN LPCWSTR lpServer, IN DSROLE_PRIMARY_DOMAIN_INFO_LEVEL InfoLevel, OUT PBYTE *Buffer );
		[DllImport(Lib.NetApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("dsrole.h", MSDNShortId = "d54876e3-a622-4b44-a597-db0f710f7758")]
		public static extern Win32Error DsRoleGetPrimaryDomainInformation([In, MarshalAs(UnmanagedType.LPWStr), Optional] string lpServer, DSROLE_PRIMARY_DOMAIN_INFO_LEVEL InfoLevel, out SafeDcRoleBuffer Buffer);

		/// <summary>
		/// <para>
		/// The <c>DSROLE_OPERATION_STATE_INFO</c> structure is used with the DsRoleGetPrimaryDomainInformation function to contain the
		/// operational state data for a computer.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/dsrole/ns-dsrole-_dsrole_operation_state_info typedef struct
		// _DSROLE_OPERATION_STATE_INFO { DSROLE_OPERATION_STATE OperationState; } DSROLE_OPERATION_STATE_INFO, *PDSROLE_OPERATION_STATE_INFO;
		[PInvokeData("dsrole.h", MSDNShortId = "c6c8e510-190a-47ad-805c-b8d3fbee836d")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct DSROLE_OPERATION_STATE_INFO
		{
			/// <summary>
			/// <para>Contains one of the DSROLE_OPERATION_STATE values that indicates the computer operational state.</para>
			/// </summary>
			public DSROLE_OPERATION_STATE OperationState;
		}

		/// <summary>
		/// <para>
		/// The <c>DSROLE_PRIMARY_DOMAIN_INFO_BASIC</c> structure is used with the DsRoleGetPrimaryDomainInformation function to contain
		/// domain data.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/dsrole/ns-dsrole-_dsrole_primary_domain_info_basic typedef struct
		// _DSROLE_PRIMARY_DOMAIN_INFO_BASIC { DSROLE_MACHINE_ROLE MachineRole; ULONG Flags; LPWSTR DomainNameFlat; LPWSTR DomainNameDns;
		// LPWSTR DomainForestName; GUID DomainGuid; } DSROLE_PRIMARY_DOMAIN_INFO_BASIC, *PDSROLE_PRIMARY_DOMAIN_INFO_BASIC;
		[PInvokeData("dsrole.h", MSDNShortId = "8a7b34e8-46d6-46dc-9fef-ec37b0f65eea")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct DSROLE_PRIMARY_DOMAIN_INFO_BASIC
		{
			/// <summary>
			/// <para>Contains one of the DSROLE_MACHINE_ROLE values that specifies the role of the computer.</para>
			/// </summary>
			public DSROLE_MACHINE_ROLE MachineRole;

			/// <summary>
			/// <para>
			/// Contains a set of flags that provide additional domain data. This can be a combination of one or more of the following values.
			/// </para>
			/// <para>DSROLE_PRIMARY_DOMAIN_GUID_PRESENT</para>
			/// <para>The <c>DomainGuid</c> member contains a valid domain <c>GUID</c>.</para>
			/// <para>DSROLE_PRIMARY_DS_MIXED_MODE</para>
			/// <para>
			/// The directory service is running in mixed mode. This flag is valid only if the <c>DSROLE_PRIMARY_DS_RUNNING</c> flag is set.
			/// </para>
			/// <para>DSROLE_PRIMARY_DS_RUNNING</para>
			/// <para>The directory service is running on this computer.</para>
			/// <para>DSROLE_PRIMARY_DS_READONLY</para>
			/// <para>The directory service is running as read-only on this computer.</para>
			/// <para>DSROLE_UPGRADE_IN_PROGRESS</para>
			/// <para>The computer is being upgraded from a previous version of Windows NT/Windows 2000.</para>
			/// </summary>
			public DSROLE_FLAGS Flags;

			/// <summary>
			/// <para>Pointer to a null-terminated Unicode string that contains the NetBIOS domain name.</para>
			/// </summary>
			public string DomainNameFlat;

			/// <summary>
			/// <para>
			/// Pointer to a null-terminated Unicode string that contains the DNS domain name. This member is optional and may be <c>NULL</c>.
			/// </para>
			/// </summary>
			public string DomainNameDns;

			/// <summary>
			/// <para>Pointer to a null-terminated Unicode string that contains the forest name. This member is optional and may be <c>NULL</c>.</para>
			/// </summary>
			public string DomainForestName;

			/// <summary>
			/// <para>
			/// Contains the domain identifier. This member is valid only if the <c>Flags</c> member contains the
			/// <c>DSROLE_PRIMARY_DOMAIN_GUID_PRESENT</c> flag.
			/// </para>
			/// </summary>
			public Guid DomainGuid;
		}

		/// <summary>
		/// <para>
		/// The <c>DSROLE_UPGRADE_STATUS_INFO</c> structure is used with the DsRoleGetPrimaryDomainInformation function to contain domain
		/// upgrade status data.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/dsrole/ns-dsrole-_dsrole_upgrade_status_info typedef struct
		// _DSROLE_UPGRADE_STATUS_INFO { ULONG OperationState; DSROLE_SERVER_STATE PreviousServerState; } DSROLE_UPGRADE_STATUS_INFO, *PDSROLE_UPGRADE_STATUS_INFO;
		[PInvokeData("dsrole.h", MSDNShortId = "c368d8d9-a91d-4013-880e-36a47d42a697")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		public struct DSROLE_UPGRADE_STATUS_INFO
		{
			/// <summary>
			/// <para>Specifies the current state of the upgrade. This member can be one of the following values.</para>
			/// <para>0</para>
			/// <para>An upgrade is not in progress.</para>
			/// <para>DSROLE_UPGRADE_IN_PROGRESS</para>
			/// <para>An upgrade is in progress.</para>
			/// </summary>
			public DSROLE_FLAGS OperationState;

			/// <summary>
			/// <para>
			/// If an upgrade is in progress, this member contains one of the DSROLE_SERVER_STATE values that indicate the previous role of
			/// the server.
			/// </para>
			/// </summary>
			public DSROLE_SERVER_STATE PreviousServerState;
		}

		/// <summary>Provides a <see cref="SafeHandle"/> to a buffer that releases a created handle at disposal using DsRoleFreeMemory.</summary>
		public class SafeDcRoleBuffer : SafeHANDLE
		{
			/// <summary>Initializes a new instance of the <see cref="SafeDcRoleBuffer"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafeDcRoleBuffer(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="SafeDcRoleBuffer"/> class.</summary>
			private SafeDcRoleBuffer() : base() { }

			/// <summary>Returns an extracted structure from this buffer.</summary>
			/// <typeparam name="T">The structure type to extract.</typeparam>
			/// <returns>Extracted structure or default(T) if the buffer is invalid.</returns>
			public T ToStructure<T>() where T : struct => IsInvalid ? default : (T)Marshal.PtrToStructure(handle, typeof(T));

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() { DsRoleFreeMemory(handle); return true; }
		}
	}
}