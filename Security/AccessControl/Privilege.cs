using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using Vanara.PInvoke;
using static Vanara.PInvoke.AdvApi32;

namespace Vanara.Security.AccessControl;

/// <summary>Privilege determining the type of system operations that can be performed.</summary>
[TypeConverter(typeof(SystemPrivilegeTypeConverter))]
public enum SystemPrivilege
{
	/// <summary>Required to logon interactively.</summary>
	InteractiveLogon = 0x00000001,

	/// <summary>Required for an account to log on using the network logon type.</summary>
	NetworkLogon = 0x00000002,

	/// <summary>Required for an account to log on using the batch logon type.</summary>
	BatchLogon = 0x00000004,

	/// <summary>Required for an account to log on using the service logon type.</summary>
	ServiceLogon = 0x00000010,

	/// <summary>Explicitly denies an account the right to log on using the interactive logon type.</summary>
	DenyInteractiveLogon = 0x00000040,

	/// <summary>Explicitly denies an account the right to log on using the network logon type.</summary>
	DenyNetworkLogon = 0x00000080,

	/// <summary>Explicitly denies an account the right to log on using the batch logon type.</summary>
	DenyBatchLogon = 0x00000100,

	/// <summary>Explicitly denies an account the right to log on using the service logon type.</summary>
	DenyServiceLogon = 0x00000200,

	/// <summary>Remote interactive logon</summary>
	RemoteInteractiveLogon = 0x00000400,

	/// <summary>Explicitly denies an account the right to log on remotely using the interactive logon type.</summary>
	DenyRemoteInteractiveLogon = 0x00000800,

	/// <summary>Privilege to replace a process-level token.</summary>
	AssignPrimaryToken = 0x00001000,

	/// <summary>Privilege to generate security audits.</summary>
	Audit,

	/// <summary>Privilege to backup files and directories.</summary>
	Backup,

	/// <summary>Privilege to bypass traverse checking.</summary>
	ChangeNotify,

	/// <summary>Privilege to create global objects.</summary>
	CreateGlobal,

	/// <summary>Privilege to create a pagefile.</summary>
	CreatePageFile,

	/// <summary>Privilege to create permanent shared objects.</summary>
	CreatePermanent,

	/// <summary>Privilege to create symbolic links.</summary>
	CreateSymbolicLink,

	/// <summary>Privilege to create a token object.</summary>
	CreateToken,

	/// <summary>Privilege to debug programs.</summary>
	Debug,

	/// <summary>Privilege to delegate session using user impersonation.</summary>
	DelegateSessionUserImpersonate,

	/// <summary>Privilege to enable computer and user accounts to be trusted for delegation.</summary>
	EnableDelegation,

	/// <summary>Privilege to impersonate a client after authentication.</summary>
	Impersonate,

	/// <summary>Privilege to increase scheduling priority.</summary>
	IncreaseBasePriority,

	/// <summary>Privilege to adjust memory quotas for a process.</summary>
	IncreaseQuota,

	/// <summary>Privilege to increase a process working set.</summary>
	IncreaseWorkingSet,

	/// <summary>Privilege to load and unload device drivers.</summary>
	LoadDriver,

	/// <summary>Privilege to lock pages in memory.</summary>
	LockMemory,

	/// <summary>Privilege to add workstations to domain.</summary>
	MachineAccount,

	/// <summary>Privilege to manage the files on a volume.</summary>
	ManageVolume,

	/// <summary>Privilege to profile single process.</summary>
	ProfileSingleProcess,

	/// <summary>Privilege to modify an object label.</summary>
	Relabel,

	/// <summary>Privilege to force shutdown from a remote system.</summary>
	RemoteShutdown,

	/// <summary>Privilege to restore files and directories.</summary>
	Restore,

	/// <summary>Privilege to manage auditing and security log.</summary>
	Security,

	/// <summary>Privilege to shut down the system.</summary>
	Shutdown,

	/// <summary>Privilege to synchronize directory service data.</summary>
	SyncAgent,

	/// <summary>Privilege to modify firmware environment values.</summary>
	SystemEnvironment,

	/// <summary>Privilege to profile system performance.</summary>
	SystemProfile,

	/// <summary>Privilege to change the system time.</summary>
	SystemTime,

	/// <summary>Privilege to take ownership of files or other objects.</summary>
	TakeOwnership,

	/// <summary>Privilege to act as part of the operating system.</summary>
	TrustedComputerBase,

	/// <summary>Privilege to change the time zone.</summary>
	TimeZone,

	/// <summary>Privilege to access Credential Manager as a trusted caller.</summary>
	TrustedCredentialManagerAccess,

	/// <summary>Privilege to remove computer from docking station.</summary>
	Undock,

	/// <summary>Privilege to read unsolicited input from a terminal device.</summary>
	UnsolicitedInput
}

/// <summary>Extension methods for <see cref="SafeHTOKEN"/> for working with privileges.</summary>
public static class PrivilegeExtension
{
	/// <summary>Adjusts a specified privilege on a security token to have the supplied attributes.</summary>
	/// <param name="hObj">The security token object.</param>
	/// <param name="priv">The privilege to adjust.</param>
	/// <param name="attr">The attribute to change.</param>
	/// <returns>The privious privileges.</returns>
	public static TOKEN_PRIVILEGES AdjustPrivilege(this SafeHTOKEN hObj, SystemPrivilege priv, PrivilegeAttributes attr) => AdjustPrivileges(hObj, new TOKEN_PRIVILEGES(priv.GetLUID(), attr));

	/// <summary>Adjusts the specified privileges on a security token to have the supplied attributes.</summary>
	/// <param name="hObj">The security token object.</param>
	/// <param name="privileges">The privileges to change.</param>
	/// <returns>The privious privileges.</returns>
	public static TOKEN_PRIVILEGES AdjustPrivileges(this SafeHTOKEN hObj, params PrivilegeAndAttributes[] privileges)
	{
		if (privileges == null || privileges.Length == 0) throw new ArgumentNullException(nameof(privileges));
		return AdjustPrivileges(hObj, new TOKEN_PRIVILEGES(privileges.Select(pa => new LUID_AND_ATTRIBUTES(pa.Privilege.GetLUID(), pa.Attributes)).ToArray()));
	}

	/// <summary>Adjusts the specified privileges on a security token to have the supplied attributes.</summary>
	/// <param name="hObj">The security token object.</param>
	/// <param name="privileges">The privileges to change.</param>
	/// <returns>The privious privileges.</returns>
	public static TOKEN_PRIVILEGES AdjustPrivileges(this SafeHTOKEN hObj, in TOKEN_PRIVILEGES privileges) { AdjustTokenPrivileges(hObj, false, privileges, out var ret).ThrowIfFailed(); return ret; }

	/// <summary>Gets the <see cref="LUID"/> for this <see cref="SystemPrivilege"/>.</summary>
	/// <param name="systemPrivilege">The system privilege to lookup.</param>
	/// <param name="systemName">
	/// Name of the system on which to check for the LUID value. A <see langword="null"/> will use the local system.
	/// </param>
	/// <returns>The associated LUID.</returns>
	public static LUID GetLUID(this SystemPrivilege systemPrivilege, string? systemName = null) => SystemPrivilegeTypeConverter.GetLUID(systemPrivilege, systemName);

	/// <summary>Gets the <see cref="SystemPrivilege"/> value for this <see cref="LUID"/>.</summary>
	/// <param name="luid">The luid.</param>
	/// <param name="systemName">
	/// Name of the system on which to check for the LUID value. A <see langword="null"/> will use the local system.
	/// </param>
	/// <returns>The associated <see cref="SystemPrivilege"/>.</returns>
	public static SystemPrivilege GetPrivilege(this LUID luid, string? systemName = null) => SystemPrivilegeTypeConverter.GetPrivilege(luid, systemName);

	/// <summary>Enumerates all the privileges held by a security token.</summary>
	/// <param name="hObj">The security token object.</param>
	/// <returns>A sequence of held privileges.</returns>
	public static IEnumerable<LUID_AND_ATTRIBUTES> GetPrivileges(this SafeHTOKEN hObj) =>
		hObj.GetInfo<TOKEN_PRIVILEGES>(TOKEN_INFORMATION_CLASS.TokenPrivileges).Privileges;

	/// <summary>Determines whether the specified security token has a privilege.</summary>
	/// <param name="hObj">The security token object.</param>
	/// <param name="priv">The privilege to assess.</param>
	/// <returns><see langword="true"/> if the specified token has the supplied privilege; otherwise, <see langword="false"/>.</returns>
	public static bool HasPrivilege(this SafeHTOKEN hObj, SystemPrivilege priv) => HasPrivileges(hObj, true, priv);

	/// <summary>Determines whether the specified security token has multiple privileges.</summary>
	/// <param name="hObj">The security token object.</param>
	/// <param name="requireAll">
	/// if set to <see langword="true"/> this method will only return <see langword="true"/> if all supplied privileges all held.
	/// </param>
	/// <param name="privs">The privileges to check.</param>
	/// <returns><see langword="true"/> if the specified token has the supplied privileges; otherwise, <see langword="false"/>.</returns>
	public static bool HasPrivileges(this SafeHTOKEN hObj, bool requireAll, params SystemPrivilege[] privs)
	{
		if (!PrivilegeCheck(hObj, new PRIVILEGE_SET((PrivilegeSetControl)(requireAll ? 1 : 0), privs.Select(p => new LUID_AND_ATTRIBUTES(p.GetLUID(), PrivilegeAttributes.SE_PRIVILEGE_ENABLED)).ToArray()), out var ret))
			Win32Error.ThrowLastError();
		return ret;
	}
}

internal class SystemPrivilegeTypeConverter : TypeConverter
{
	internal static readonly Dictionary<SystemPrivilege, string> PrivLookup =
		new(35)
	{
		{ SystemPrivilege.AssignPrimaryToken, "SeAssignPrimaryTokenPrivilege" },
		{ SystemPrivilege.Audit, "SeAuditPrivilege" },
		{ SystemPrivilege.Backup, "SeBackupPrivilege" },
		{ SystemPrivilege.ChangeNotify, "SeChangeNotifyPrivilege" },
		{ SystemPrivilege.CreateGlobal, "SeCreateGlobalPrivilege" },
		{ SystemPrivilege.CreatePageFile, "SeCreatePagefilePrivilege" },
		{ SystemPrivilege.CreatePermanent, "SeCreatePermanentPrivilege" },
		{ SystemPrivilege.CreateSymbolicLink, "SeCreateSymbolicLinkPrivilege" },
		{ SystemPrivilege.CreateToken, "SeCreateTokenPrivilege" },
		{ SystemPrivilege.Debug, "SeDebugPrivilege" },
		{ SystemPrivilege.DelegateSessionUserImpersonate, "SeDelegateSessionUserImpersonatePrivilege" },
		{ SystemPrivilege.EnableDelegation, "SeEnableDelegationPrivilege" },
		{ SystemPrivilege.Impersonate, "SeImpersonatePrivilege" },
		{ SystemPrivilege.IncreaseBasePriority, "SeIncreaseBasePriorityPrivilege" },
		{ SystemPrivilege.IncreaseQuota, "SeIncreaseQuotaPrivilege" },
		{ SystemPrivilege.IncreaseWorkingSet, "SeIncreaseWorkingSetPrivilege" },
		{ SystemPrivilege.LoadDriver, "SeLoadDriverPrivilege" },
		{ SystemPrivilege.LockMemory, "SeLockMemoryPrivilege" },
		{ SystemPrivilege.MachineAccount, "SeMachineAccountPrivilege" },
		{ SystemPrivilege.ManageVolume, "SeManageVolumePrivilege" },
		{ SystemPrivilege.ProfileSingleProcess, "SeProfileSingleProcessPrivilege" },
		{ SystemPrivilege.Relabel, "SeRelabelPrivilege" },
		{ SystemPrivilege.RemoteShutdown, "SeRemoteShutdownPrivilege" },
		{ SystemPrivilege.Restore, "SeRestorePrivilege" },
		{ SystemPrivilege.Security, "SeSecurityPrivilege" },
		{ SystemPrivilege.Shutdown, "SeShutdownPrivilege" },
		{ SystemPrivilege.SyncAgent, "SeSyncAgentPrivilege" },
		{ SystemPrivilege.SystemEnvironment, "SeSystemEnvironmentPrivilege" },
		{ SystemPrivilege.SystemProfile, "SeSystemProfilePrivilege" },
		{ SystemPrivilege.SystemTime, "SeSystemTimePrivilege" },
		{ SystemPrivilege.TakeOwnership, "SeTakeOwnershipPrivilege" },
		{ SystemPrivilege.TrustedComputerBase, "SeTcbPrivilege" },
		{ SystemPrivilege.TimeZone, "SeTimeZonePrivilege" },
		{ SystemPrivilege.TrustedCredentialManagerAccess, "SeTrustedCredManAccessPrivilege" },
		{ SystemPrivilege.Undock, "SeUndockPrivilege" },
		{ SystemPrivilege.UnsolicitedInput, "SeUnsolicitedInputPrivilege" },
		{ SystemPrivilege.InteractiveLogon, "SeInteractiveLogonRight" },
		{ SystemPrivilege.NetworkLogon, "SeNetworkLogonRight" },
		{ SystemPrivilege.BatchLogon, "SeBatchLogonRight" },
		{ SystemPrivilege.ServiceLogon, "SeServiceLogonRight" },
		{ SystemPrivilege.DenyInteractiveLogon, "SeDenyInteractiveLogonRight" },
		{ SystemPrivilege.DenyNetworkLogon, "SeDenyNetworkLogonRight" },
		{ SystemPrivilege.DenyBatchLogon, "SeDenyBatchLogonRight" },
		{ SystemPrivilege.DenyServiceLogon, "SeDenyServiceLogonRight" },
		{ SystemPrivilege.RemoteInteractiveLogon, "SeRemoteInteractiveLogonRight" },
		{ SystemPrivilege.DenyRemoteInteractiveLogon, "SeDenyRemoteInteractiveLogonRight" },
	};

	private static readonly Dictionary<SystemPrivilege, LUID> luidLookup = new();

	public override bool CanConvertFrom(ITypeDescriptorContext? context, Type sourceType) =>
		sourceType == typeof(string) || sourceType == typeof(LUID) || base.CanConvertFrom(context, sourceType);

	public override bool CanConvertTo(ITypeDescriptorContext? context, Type? destinationType) =>
		destinationType == typeof(string) || destinationType == typeof(LUID) || base.CanConvertTo(context, destinationType);

	public override object? ConvertFrom(ITypeDescriptorContext? context, CultureInfo? culture, object value)
	{
		if (value is string s)
		{
			try { var val = (SystemPrivilege)Enum.Parse(typeof(SystemPrivilege), s, true); return val; } catch { }
			try { return ConvertKnownString(s); } catch { }
		}
		if (value is LUID luid)
			return GetPrivilege(luid);
		return base.ConvertFrom(context, culture, value);
	}

	public override object? ConvertTo(ITypeDescriptorContext? context, CultureInfo? culture, object? value, Type destinationType)
	{
		if (value is not null)
		{
			if (destinationType == typeof(string))
				return PrivLookup[(SystemPrivilege)value];
			if (destinationType == typeof(LUID))
				return GetLUID((SystemPrivilege)value);
		}
		return base.ConvertTo(context, culture, value, destinationType);
	}

	internal static SystemPrivilege ConvertKnownString(string s)
	{
		try { return PrivLookup.First(v => string.Equals(s, v.Value, StringComparison.OrdinalIgnoreCase)).Key; }
		catch { throw new ArgumentOutOfRangeException(nameof(s), "Unrecognized privilege string."); }
	}

	internal static LUID GetLUID(SystemPrivilege systemPrivilege, string? systemName = null)
	{
		LUID val;
		lock (luidLookup)
		{
			if (!luidLookup.TryGetValue(systemPrivilege, out val))
			{
				val = LUID.FromName(PrivLookup[systemPrivilege], systemName);
				luidLookup.Add(systemPrivilege, val);
			}
		}
		return val;
	}

	internal static SystemPrivilege GetPrivilege(LUID luid, string? systemName = null) => ConvertKnownString(luid.GetName(systemName));
}