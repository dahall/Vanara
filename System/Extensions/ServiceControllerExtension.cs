using System.ComponentModel;
using System.Security.AccessControl;
using System.Security.Principal;
using System.ServiceProcess;
using Vanara.PInvoke;
using static Vanara.PInvoke.AdvApi32;

namespace Vanara.Extensions
{
	/// <summary>Extension methods for <see cref="ServiceController"/>.</summary>
	public static partial class ServiceControllerExtension
	{
		/// <summary>
		/// Gets a <see cref="Security.AccessControl.ServiceControllerSecurity"/> object that encapsulates the specified type of access
		/// control list (ACL) entries for the service described by the current <see cref="ServiceController"/> object.
		/// </summary>
		/// <param name="svc">The <see cref="ServiceController"/> object from which to get access control.</param>
		/// <param name="includeSections">
		/// One of the <see cref="AccessControlSections"/> values that specifies which group of access control entries to retrieve.
		/// </param>
		/// <returns>
		/// A <see cref="Security.AccessControl.ServiceControllerSecurity"/> object that encapsulates the access control rules for the
		/// current service.
		/// </returns>
		public static Security.AccessControl.ServiceControllerSecurity GetAccessControl(this ServiceController svc, AccessControlSections includeSections = AccessControlSections.Access | AccessControlSections.Owner | AccessControlSections.Group) => new(svc.ServiceHandle, includeSections);

		/// <summary>
		/// Applies access control list (ACL) entries described by a <see cref="Security.AccessControl.ServiceControllerSecurity"/> object to
		/// the service described by the current <see cref="ServiceController"/> object.
		/// </summary>
		/// <param name="svc">The <see cref="ServiceController"/> object on which to set access control.</param>
		/// <param name="serviceSecurity">
		/// A <see cref="Security.AccessControl.ServiceControllerSecurity"/> object that describes an access control list (ACL) entry to
		/// apply to the current service.
		/// </param>
		public static void SetAccessControl(this ServiceController svc, Security.AccessControl.ServiceControllerSecurity serviceSecurity)
		{
			if (serviceSecurity is null) throw new ArgumentNullException(nameof(serviceSecurity));
			serviceSecurity.Persist(svc.ServiceHandle);
		}

		/// <summary>Changes the start mode of a service.</summary>
		/// <param name="svc">The <see cref="ServiceController"/> instance.</param>
		/// <param name="mode">The new start mode.</param>
		public static void SetStartType(this ServiceController svc, ServiceStartMode mode)
		{
			using var serviceHandle = svc.ServiceHandle;
			if (!ChangeServiceConfig(serviceHandle.DangerousGetHandle(), ServiceTypes.SERVICE_NO_CHANGE, (ServiceStartType)mode, ServiceErrorControlType.SERVICE_NO_CHANGE))
				throw new ExternalException("Could not change service start type.", new Win32Exception());
		}
	}
}

namespace Vanara.Security.AccessControl
{
	/// <summary>Defines the access rights to use when creating access and audit rules.</summary>
	[Flags]
	public enum ServiceControllerAccessRights : uint
	{
		/// <summary>Includes STANDARD_RIGHTS_REQUIRED in addition to all access rights in this table.</summary>
		FullControl = ServiceAccessRights.SERVICE_ALL_ACCESS | AccessSystemSecurity | ACCESS_MASK.STANDARD_RIGHTS_ALL,

		/// <summary>
		/// Required to call the ChangeServiceConfig or ChangeServiceConfig2 function to change the service configuration. Because this
		/// grants the caller the right to change the executable file that the system runs, it should be granted only to administrators.
		/// </summary>
		ChangeConfig = ServiceAccessRights.SERVICE_CHANGE_CONFIG,

		/// <summary>Required to call the EnumDependentServices function to enumerate all the services dependent on the service.</summary>
		EnumerateDependents = ServiceAccessRights.SERVICE_ENUMERATE_DEPENDENTS,

		/// <summary>Required to call the ControlService function to ask the service to report its status immediately.</summary>
		Interrogate = ServiceAccessRights.SERVICE_INTERROGATE,

		/// <summary>Required to call the ControlService function to pause or continue the service.</summary>
		Continue = ServiceAccessRights.SERVICE_PAUSE_CONTINUE,

		/// <summary>Required to call the QueryServiceConfig and QueryServiceConfig2 functions to query the service configuration.</summary>
		QueryConfig = ServiceAccessRights.SERVICE_QUERY_CONFIG,

		/// <summary>
		/// Required to call the QueryServiceStatus or QueryServiceStatusEx function to ask the service control manager about the status of
		/// the service.
		/// <para>Required to call the NotifyServiceStatusChange function to receive notification when a service changes status.</para>
		/// </summary>
		QueryStatus = ServiceAccessRights.SERVICE_QUERY_STATUS,

		/// <summary>Required to call the StartService function to start the service.</summary>
		Start = ServiceAccessRights.SERVICE_START,

		/// <summary>Required to call the ControlService function to stop the service.</summary>
		Stop = ServiceAccessRights.SERVICE_STOP,

		/// <summary>Required to call the ControlService function to specify a user-defined control code.</summary>
		UserDefinedControl = ServiceAccessRights.SERVICE_USER_DEFINED_CONTROL,

		/// <summary>
		/// Required to call the QueryServiceObjectSecurity or SetServiceObjectSecurity function to access the SACL. The proper way to obtain
		/// this access is to enable the SE_SECURITY_NAMEprivilege in the caller's current access token, open the handle for
		/// ACCESS_SYSTEM_SECURITY access, and then disable the privilege.
		/// </summary>
		AccessSystemSecurity = ACCESS_MASK.ACCESS_SYSTEM_SECURITY,

		/// <summary>Required to call the DeleteService function to delete the service.</summary>
		Delete = ACCESS_MASK.DELETE,

		/// <summary>Required to call the QueryServiceObjectSecurity function to query the security descriptor of the service object.</summary>
		ReadPermissions = ACCESS_MASK.READ_CONTROL,

		/// <summary>
		/// Required to call the SetServiceObjectSecurity function to modify the Dacl member of the service object's security descriptor.
		/// </summary>
		ChangePermissions = ACCESS_MASK.WRITE_DAC,

		/// <summary>
		/// Required to call the SetServiceObjectSecurity function to modify the Owner and Group members of the service object's security descriptor.
		/// </summary>
		TakeOwnership = ACCESS_MASK.WRITE_OWNER,

		/// <summary>
		/// Specifies the right to open and copy folders or files as read-only. This right includes the ReadData right,
		/// ReadExtendedAttributes right, ReadAttributes right, and ReadPermissions right.
		/// </summary>
		Read = ACCESS_MASK.STANDARD_RIGHTS_READ | ServiceAccessRights.SERVICE_QUERY_CONFIG | ServiceAccessRights.SERVICE_QUERY_STATUS | ServiceAccessRights.SERVICE_INTERROGATE | ServiceAccessRights.SERVICE_ENUMERATE_DEPENDENTS,

		/// <summary>
		/// Specifies the right to create folders and files, and to add or remove data from files. This right includes the WriteData right,
		/// AppendData right, WriteExtendedAttributes right, and WriteAttributes right.
		/// </summary>
		Write = ACCESS_MASK.STANDARD_RIGHTS_WRITE | ServiceAccessRights.SERVICE_CHANGE_CONFIG,

		/// <summary>Specifies the right to run an application file.</summary>
		Execute = ACCESS_MASK.STANDARD_RIGHTS_EXECUTE | ServiceAccessRights.SERVICE_START | ServiceAccessRights.SERVICE_STOP | ServiceAccessRights.SERVICE_PAUSE_CONTINUE | ServiceAccessRights.SERVICE_USER_DEFINED_CONTROL,
	}

	/// <summary>Represents an abstraction of an access control entry (ACE) that defines an access rule for a service.</summary>
	/// <seealso cref="System.Security.AccessControl.AccessRule"/>
	public sealed class ServiceControllerAccessRule : AccessRule
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ServiceControllerAccessRule"/> class with the specified identity, access rights, and
		/// access control type..
		/// </summary>
		/// <param name="identity">The name of the user account.</param>
		/// <param name="rights">
		/// One of the <see cref="ServiceControllerAccessRights"/> values that specifies the type of operation associated with the access rule.
		/// </param>
		/// <param name="type">One of the <see cref="AccessControlType"/> values that specifies whether to allow or deny the operation.</param>
		public ServiceControllerAccessRule(string identity, ServiceControllerAccessRights rights, AccessControlType type)
					: this(new NTAccount(identity), AccessMaskFromRights(rights), false, type)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ServiceControllerAccessRule"/> class with the specified identity, access rights, and
		/// access control type..
		/// </summary>
		/// <param name="identity">An <see cref="IdentityReference"/> object that encapsulates a reference to a user account.</param>
		/// <param name="rights">
		/// One of the <see cref="ServiceControllerAccessRights"/> values that specifies the type of operation associated with the access rule.
		/// </param>
		/// <param name="type">One of the <see cref="AccessControlType"/> values that specifies whether to allow or deny the operation.</param>
		public ServiceControllerAccessRule(IdentityReference identity, ServiceControllerAccessRights rights, AccessControlType type)
					: this(identity, AccessMaskFromRights(rights), false, type)
		{
		}

		internal ServiceControllerAccessRule(IdentityReference identity, int accessMask, bool isInherited, AccessControlType type)
			: base(identity, accessMask, isInherited, InheritanceFlags.None, PropagationFlags.None, type)
		{
		}

		/// <summary>
		/// Gets the <see cref="ServiceControllerAccessRights"/> flags that are associated with the current
		/// <see cref="ServiceControllerAccessRule"/> object.
		/// </summary>
		/// <value>A bitwise combination of the <see cref="ServiceControllerAccessRights"/> values.</value>
		public ServiceControllerAccessRights AccessRights => (ServiceControllerAccessRights)AccessMask;

		internal static int AccessMaskFromRights(ServiceControllerAccessRights rights) =>
			rights is >= 0 and <= ServiceControllerAccessRights.FullControl ?
			(int)rights : throw new ArgumentOutOfRangeException(nameof(rights));
	}

	/// <summary>Represents an abstraction of an access control entry (ACE) that defines an audit rule for a service.</summary>
	/// <seealso cref="System.Security.AccessControl.AuditRule"/>
	public sealed class ServiceControllerAuditRule : AuditRule
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ServiceControllerAuditRule"/> class for a user account specified in a
		/// <see cref="IdentityReference"/> object.
		/// </summary>
		/// <param name="identity">An <see cref="IdentityReference"/> object that encapsulates a reference to a user account.</param>
		/// <param name="rights">
		/// One of the <see cref="ServiceControllerAccessRights"/> values that specifies the type of operation associated with the access rule.
		/// </param>
		/// <param name="flags">One of the <see cref="AuditFlags"/> values that specifies when to perform auditing.</param>
		public ServiceControllerAuditRule(IdentityReference identity, ServiceControllerAccessRights rights, AuditFlags flags)
					 : this(identity, ServiceControllerAccessRule.AccessMaskFromRights(rights), false, flags)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ServiceControllerAuditRule"/> class for a user account specified in a
		/// <see cref="IdentityReference"/> object.
		/// </summary>
		/// <param name="identity">The name of the user account.</param>
		/// <param name="rights">
		/// One of the <see cref="ServiceControllerAccessRights"/> values that specifies the type of operation associated with the access rule.
		/// </param>
		/// <param name="flags">One of the <see cref="AuditFlags"/> values that specifies when to perform auditing.</param>
		public ServiceControllerAuditRule(string identity, ServiceControllerAccessRights rights, AuditFlags flags)
			: this(new NTAccount(identity), ServiceControllerAccessRule.AccessMaskFromRights(rights), false, flags)
		{
		}

		internal ServiceControllerAuditRule(IdentityReference identity, int accessMask, bool isInherited, AuditFlags flags)
			: base(identity, accessMask, isInherited, InheritanceFlags.None, PropagationFlags.None, flags)
		{
		}
	}

	/// <summary>Represents the access control and audit security for a service.</summary>
	/// <seealso cref="System.Security.AccessControl.NativeObjectSecurity"/>
	public class ServiceControllerSecurity : NativeObjectSecurity
	{
		/// <summary>Initializes a new instance of the <see cref="ServiceControllerSecurity"/> class.</summary>
		public ServiceControllerSecurity() : base(false, System.Security.AccessControl.ResourceType.Service) { }

		internal ServiceControllerSecurity(SafeHandle handle, AccessControlSections includeSections) :
			base(false, System.Security.AccessControl.ResourceType.Service, handle, includeSections)
		{
		}

		/// <summary>
		/// Gets the <see cref="T:System.Type"/> of the securable object associated with this
		/// <see cref="T:System.Security.AccessControl.ObjectSecurity"/> object.
		/// </summary>
		public override Type AccessRightType => typeof(ServiceControllerAccessRights);

		/// <summary>
		/// Gets the <see cref="T:System.Type"/> of the object associated with the access rules of this
		/// <see cref="T:System.Security.AccessControl.ObjectSecurity"/> object. The <see cref="T:System.Type"/> object must be an object
		/// that can be cast as a <see cref="T:System.Security.Principal.SecurityIdentifier"/> object.
		/// </summary>
		public override Type AccessRuleType => typeof(ServiceControllerAccessRule);

		/// <summary>
		/// Gets the <see cref="T:System.Type"/> object associated with the audit rules of this
		/// <see cref="T:System.Security.AccessControl.ObjectSecurity"/> object. The <see cref="T:System.Type"/> object must be an object
		/// that can be cast as a <see cref="T:System.Security.Principal.SecurityIdentifier"/> object.
		/// </summary>
		public override Type AuditRuleType => typeof(ServiceControllerAuditRule);

		/// <summary>
		/// Initializes a new instance of the <see cref="T:System.Security.AccessControl.AccessRule"/> class with the specified values.
		/// </summary>
		/// <param name="identityReference">The identity to which the access rule applies. It must be an object that can be cast as a <see cref="T:System.Security.Principal.SecurityIdentifier"/>.</param>
		/// <param name="accessMask">
		/// The access mask of this rule. The access mask is a 32-bit collection of anonymous bits, the meaning of which is defined by the
		/// individual integrators.
		/// </param>
		/// <param name="isInherited">true if this rule is inherited from a parent container.</param>
		/// <param name="inheritanceFlags">Specifies the inheritance properties of the access rule.</param>
		/// <param name="propagationFlags">
		/// Specifies whether inherited access rules are automatically propagated. The propagation flags are ignored if
		/// <paramref name="inheritanceFlags"/> is set to <see cref="F:System.Security.AccessControl.InheritanceFlags.None"/>.
		/// </param>
		/// <param name="type">Specifies the valid access control type.</param>
		/// <returns>The <see cref="T:System.Security.AccessControl.AccessRule"/> object that this method creates.</returns>
		public override AccessRule AccessRuleFactory(IdentityReference identityReference, int accessMask, bool isInherited, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags, AccessControlType type) => new ServiceControllerAccessRule(identityReference, (ServiceControllerAccessRights)accessMask, type);

		/// <summary>
		/// Initializes a new instance of the <see cref="T:System.Security.AccessControl.AuditRule"/> class with the specified values.
		/// </summary>
		/// <param name="identityReference">The identity to which the audit rule applies. It must be an object that can be cast as a <see cref="T:System.Security.Principal.SecurityIdentifier"/>.</param>
		/// <param name="accessMask">
		/// The access mask of this rule. The access mask is a 32-bit collection of anonymous bits, the meaning of which is defined by the
		/// individual integrators.
		/// </param>
		/// <param name="isInherited">true if this rule is inherited from a parent container.</param>
		/// <param name="inheritanceFlags">Specifies the inheritance properties of the audit rule.</param>
		/// <param name="propagationFlags">
		/// Specifies whether inherited audit rules are automatically propagated. The propagation flags are ignored if
		/// <paramref name="inheritanceFlags"/> is set to <see cref="F:System.Security.AccessControl.InheritanceFlags.None"/>.
		/// </param>
		/// <param name="flags">Specifies the conditions for which the rule is audited.</param>
		/// <returns>The <see cref="T:System.Security.AccessControl.AuditRule"/> object that this method creates.</returns>
		public override AuditRule AuditRuleFactory(IdentityReference identityReference, int accessMask, bool isInherited, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags, AuditFlags flags) => new ServiceControllerAuditRule(identityReference, (ServiceControllerAccessRights)accessMask, flags);

		internal void Persist(SafeHandle handle)
		{
			WriteLock();
			try
			{
				var persistRules = GetAccessControlSectionsFromChanges();
				if (persistRules == AccessControlSections.None)
					return;
				Persist(handle, persistRules);
				OwnerModified = GroupModified = AuditRulesModified = AccessRulesModified = false;
			}
			finally
			{
				WriteUnlock();
			}
		}

		private AccessControlSections GetAccessControlSectionsFromChanges()
		{
			var persistRules = AccessControlSections.None;
			if (AccessRulesModified)
				persistRules = AccessControlSections.Access;
			if (AuditRulesModified)
				persistRules |= AccessControlSections.Audit;
			if (OwnerModified)
				persistRules |= AccessControlSections.Owner;
			if (GroupModified)
				persistRules |= AccessControlSections.Group;
			return persistRules;
		}
	}
}