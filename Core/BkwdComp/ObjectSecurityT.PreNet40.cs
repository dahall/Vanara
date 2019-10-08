#if NET20 || NET35

// Sourced from
// https://github.com/dotnet/corefx/blob/a6f76f4f620cbe74821c6445af3f13e048361658/src/System.Security.AccessControl/src/System/Security/AccessControl/ObjectSecurityT.cs.
// Only additions are preprocessor directives for conditional compilation and XML comments pulled from Microsoft documentation.

// Licensed to the .NET Foundation under one or more agreements. The .NET Foundation licenses this file to you under the MIT license. See the
// LICENSE file in the project root for more information.

/*============================================================
**
** Class:  ObjectSecurity
**
** Purpose: Generic Managed ACL wrapper
**
** Date:  February 7, 2007
**
===========================================================*/

using System.Runtime.InteropServices;
using System.Security.Principal;
using ResourceType = System.Security.AccessControl.ResourceType;

namespace System.Security.AccessControl
{
	/// <summary>
	/// Represents a combination of a user's identity, an access mask, and an access control type (allow or deny). An AccessRule`1 object
	/// also contains information about the how the rule is inherited by child objects and how that inheritance is propagated.
	/// </summary>
	/// <typeparam name="T">The access rights type for the access rule.</typeparam>
	/// <seealso cref="System.Security.AccessControl.AccessRule"/>
	public class AccessRule<T> : AccessRule where T : struct
	{
		// Constructors for creating access rules for file objects

		/// <summary>Initializes a new instance of the <see cref="AccessRule{T}"/> class by using the specified values.</summary>
		/// <param name="identity">The identity to which the access rule applies.</param>
		/// <param name="rights">The rights of the access rule.</param>
		/// <param name="type">The valid access control type.</param>
		public AccessRule(IdentityReference identity, T rights, AccessControlType type) :
			this(identity, (int)(object)rights, false, InheritanceFlags.None, PropagationFlags.None, type)
		{ }

		/// <summary>Initializes a new instance of the <see cref="AccessRule{T}"/> class by using the specified values.</summary>
		/// <param name="identity">The identity to which the access rule applies.</param>
		/// <param name="rights">The rights of the access rule.</param>
		/// <param name="type">The valid access control type.</param>
		public AccessRule(string identity, T rights, AccessControlType type) :
			this(new NTAccount(identity), (int)(object)rights, false, InheritanceFlags.None, PropagationFlags.None, type)
		{ }

		// Constructor for creating access rules for folder objects

		/// <summary>Initializes a new instance of the <see cref="AccessRule{T}"/> class by using the specified values.</summary>
		/// <param name="identity">The identity to which the access rule applies.</param>
		/// <param name="rights">The rights of the access rule.</param>
		/// <param name="inheritanceFlags">The inheritance properties of the access rule.</param>
		/// <param name="propagationFlags">
		/// Whether inherited access rules are automatically propagated. The propagation flags are ignored if inheritanceFlags is set to None.
		/// </param>
		/// <param name="type">The valid access control type.</param>
		public AccessRule(IdentityReference identity, T rights, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags, AccessControlType type) :
			this(identity, (int)(object)rights, false, inheritanceFlags, propagationFlags, type)
		{ }

		/// <summary>Initializes a new instance of the <see cref="AccessRule{T}"/> class by using the specified values.</summary>
		/// <param name="identity">The identity to which the access rule applies.</param>
		/// <param name="rights">The rights of the access rule.</param>
		/// <param name="inheritanceFlags">The inheritance properties of the access rule.</param>
		/// <param name="propagationFlags">
		/// Whether inherited access rules are automatically propagated. The propagation flags are ignored if inheritanceFlags is set to None.
		/// </param>
		/// <param name="type">The valid access control type.</param>
		public AccessRule(string identity, T rights, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags, AccessControlType type) :
			this(new NTAccount(identity), (int)(object)rights, false, inheritanceFlags, propagationFlags, type)
		{ }

		internal AccessRule(IdentityReference identity, int accessMask, bool isInherited, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags, AccessControlType type) :
			base(identity, accessMask, isInherited, inheritanceFlags, propagationFlags, type)
		{ }

		/// <summary>Gets the rights of the current instance.</summary>
		/// <value>The rights, cast as type <typeparamref name="T"/>, of the current instance.</value>
		public T Rights => (T)(object)AccessMask;
	}

	/// <summary>Represents a combination of a user's identity and an access mask.</summary>
	/// <typeparam name="T">The type of the audit rule.</typeparam>
	/// <seealso cref="System.Security.AccessControl.AuditRule"/>
	public class AuditRule<T> : AuditRule where T : struct
	{
		/// <summary>Initializes a new instance of the <see cref="AuditRule{T}"/> class by using the specified values.</summary>
		/// <param name="identity">The identity to which this audit rule applies.</param>
		/// <param name="rights">The rights of the audit rule.</param>
		/// <param name="flags">The conditions for which the rule is audited.</param>
		public AuditRule(IdentityReference identity, T rights, AuditFlags flags) :
			this(identity, rights, InheritanceFlags.None, PropagationFlags.None, flags)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="AuditRule{T}"/> class by using the specified values.</summary>
		/// <param name="identity">The identity to which this audit rule applies.</param>
		/// <param name="rights">The rights of the audit rule.</param>
		/// <param name="inheritanceFlags">The inheritance properties of the audit rule.</param>
		/// <param name="propagationFlags">Whether inherited audit rules are automatically propagated.</param>
		/// <param name="flags">The conditions for which the rule is audited.</param>
		public AuditRule(IdentityReference identity, T rights, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags, AuditFlags flags) :
			this(identity, (int)(object)rights, false, inheritanceFlags, propagationFlags, flags)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="AuditRule{T}"/> class by using the specified values.</summary>
		/// <param name="identity">The identity to which this audit rule applies.</param>
		/// <param name="rights">The rights of the audit rule.</param>
		/// <param name="flags">The conditions for which the rule is audited.</param>
		public AuditRule(string identity, T rights, AuditFlags flags) :
			this(new NTAccount(identity), rights, InheritanceFlags.None, PropagationFlags.None, flags)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="AuditRule{T}"/> class by using the specified values.</summary>
		/// <param name="identity">The identity to which this audit rule applies.</param>
		/// <param name="rights">The rights of the audit rule.</param>
		/// <param name="inheritanceFlags">The inheritance properties of the audit rule.</param>
		/// <param name="propagationFlags">Whether inherited audit rules are automatically propagated.</param>
		/// <param name="flags">The conditions for which the rule is audited.</param>
		public AuditRule(string identity, T rights, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags, AuditFlags flags) :
			this(new NTAccount(identity), (int)(object)rights, false, inheritanceFlags, propagationFlags, flags)
		{
		}

		internal AuditRule(IdentityReference identity, int accessMask, bool isInherited, InheritanceFlags inheritanceFlags, PropagationFlags propagationFlags, AuditFlags flags) :
			base(identity, accessMask, isInherited, inheritanceFlags, propagationFlags, flags)
		{
		}

		/// <summary>Gets the rights of the audit rule.</summary>
		/// <value>The rights, cast as type <typeparamref name="T"/>, of the audit rule.</value>
		public T Rights => (T)(object)AccessMask;
	}

	/// <summary>
	/// Provides the ability to control access to objects without direct manipulation of Access Control Lists (ACLs); also grants the ability
	/// to type-cast access rights.
	/// </summary>
	/// <typeparam name="T">The access rights for the object.</typeparam>
	/// <seealso cref="System.Security.AccessControl.NativeObjectSecurity"/>
	public abstract class ObjectSecurity<T> : NativeObjectSecurity where T : struct
	{
		/// <summary>Initializes a new instance of the <see cref="ObjectSecurity{T}"/> class.</summary>
		/// <param name="isContainer">
		/// <see langword="true"/> if the new <see cref="T:System.Security.AccessControl.NativeObjectSecurity"/> object is a container object.
		/// </param>
		/// <param name="resourceType">
		/// The type of securable object with which the new <see cref="T:System.Security.AccessControl.NativeObjectSecurity"/> object is associated.
		/// </param>
		protected ObjectSecurity(bool isContainer, ResourceType resourceType)
			: base(isContainer, resourceType, null, null)
		{ }

		/// <summary>Initializes a new instance of the <see cref="ObjectSecurity{T}"/> class.</summary>
		/// <param name="isContainer">
		/// <see langword="true"/> if the new <see cref="T:System.Security.AccessControl.NativObjectSecurity"/> object is a container object.
		/// </param>
		/// <param name="resourceType">
		/// The type of securable object with which the new <see cref="T:System.Security.AccessControl.NativeObjectSecurity"/> object is associated.
		/// </param>
		/// <param name="name">
		/// The name of the securable object with which the new <see cref="T:System.Security.AccessControl.NativeObjectSecurity"/> object is associated.
		/// </param>
		/// <param name="includeSections">
		/// One of the <see cref="T:System.Security.AccessControl.AccessControlSections"/> enumeration values that specifies the sections of
		/// the security descriptor (access rules, audit rules, owner, primary group) of the securable object to include in this
		/// <see cref="T:System.Security.AccessControl.NativeObjectSecurity"/> object.
		/// </param>
		protected ObjectSecurity(bool isContainer, ResourceType resourceType, string name, AccessControlSections includeSections)
			: base(isContainer, resourceType, name, includeSections, null, null)
		{ }

		/// <summary>Initializes a new instance of the <see cref="ObjectSecurity{T}"/> class.</summary>
		/// <param name="isContainer">
		/// <see langword="true"/> if the new <see cref="T:System.Security.AccessControl.NativeObjectSecurity"/> object is a container object.
		/// </param>
		/// <param name="resourceType">
		/// The type of securable object with which the new <see cref="T:System.Security.AccessControl.NativeObjectSecurity"/> object is associated.
		/// </param>
		/// <param name="name">
		/// The name of the securable object with which the new <see cref="T:System.Security.AccessControl.NativeObjectSecurity"/> object is associated.
		/// </param>
		/// <param name="includeSections">
		/// One of the <see cref="T:System.Security.AccessControl.AccessControlSections"/> enumeration values that specifies the sections of
		/// the security descriptor (access rules, audit rules, owner, primary group) of the securable object to include in this
		/// <see cref="T:System.Security.AccessControl.NativeObjectSecurity"/> object.
		/// </param>
		/// <param name="exceptionFromErrorCode">A delegate implemented by integrators that provides custom exceptions.</param>
		/// <param name="exceptionContext">An object that contains contextual information about the source or destination of the exception.</param>
		protected ObjectSecurity(bool isContainer, ResourceType resourceType, string name, AccessControlSections includeSections, ExceptionFromErrorCode exceptionFromErrorCode, object exceptionContext)
			: base(isContainer, resourceType, name, includeSections, exceptionFromErrorCode, exceptionContext)
		{ }

		/// <summary>Initializes a new instance of the <see cref="ObjectSecurity{T}"/> class.</summary>
		/// <param name="isContainer">
		/// <see langword="true"/> if the new <see cref="T:System.Security.AccessControl.NativeObjectSecurity"/> object is a container object.
		/// </param>
		/// <param name="resourceType">
		/// The type of securable object with which the new <see cref="T:System.Security.AccessControl.NativeObjectSecurity"/> object is associated.
		/// </param>
		/// <param name="safeHandle">A handle.</param>
		/// <param name="includeSections">
		/// One of the <see cref="T:System.Security.AccessControl.AccessControlSections"/> enumeration values that specifies the sections of
		/// the security descriptor (access rules, audit rules, owner, primary group) of the securable object to include in this
		/// <see cref="T:System.Security.AccessControl.NativeObjectSecurity"/> object.
		/// </param>
		protected ObjectSecurity(bool isContainer, ResourceType resourceType, SafeHandle safeHandle, AccessControlSections includeSections)
			: base(isContainer, resourceType, safeHandle, includeSections, null, null)
		{ }

		/// <summary>Initializes a new instance of the <see cref="ObjectSecurity{T}"/> class.</summary>
		/// <param name="isContainer">
		/// <see langword="true"/> if the new <see cref="T:System.Security.AccessControl.NativeObjectSecurity"/> object is a container object.
		/// </param>
		/// <param name="resourceType">
		/// The type of securable object with which the new <see cref="T:System.Security.AccessControl.NativeObjectSecurity"/> object is associated.
		/// </param>
		/// <param name="safeHandle">A handle.</param>
		/// <param name="includeSections">
		/// One of the <see cref="T:System.Security.AccessControl.AccessControlSections"/> enumeration values that specifies the sections of
		/// the security descriptor (access rules, audit rules, owner, primary group) of the securable object to include in this
		/// <see cref="T:System.Security.AccessControl.NativeObjectSecurity"/> object.
		/// </param>
		/// <param name="exceptionFromErrorCode">A delegate implemented by integrators that provides custom exceptions.</param>
		/// <param name="exceptionContext">An object that contains contextual information about the source or destination of the exception.</param>
		protected ObjectSecurity(bool isContainer, ResourceType resourceType, SafeHandle safeHandle, AccessControlSections includeSections,
			ExceptionFromErrorCode exceptionFromErrorCode, object exceptionContext)
			: base(isContainer, resourceType, safeHandle, includeSections, exceptionFromErrorCode, exceptionContext)
		{ }

		/// <summary>
		/// Gets the <see cref="T:System.Type"/> of the securable object associated with this
		/// <see cref="T:System.Security.AccessControl.ObjectSecurity"/> object.
		/// </summary>
		public override Type AccessRightType => typeof(T);

		/// <summary>
		/// Gets the <see cref="T:System.Type"/> of the object associated with the access rules of this
		/// <see cref="T:System.Security.AccessControl.ObjectSecurity"/> object. The <see cref="T:System.Type"/> object must be an object
		/// that can be cast as a <see cref="T:System.Security.Principal.SecurityIdentifier"/> object.
		/// </summary>
		public override Type AccessRuleType => typeof(AccessRule<T>);

		/// <summary>
		/// Gets the <see cref="T:System.Type"/> object associated with the audit rules of this
		/// <see cref="T:System.Security.AccessControl.ObjectSecurity"/> object. The <see cref="T:System.Type"/> object must be an object
		/// that can be cast as a <see cref="T:System.Security.Principal.SecurityIdentifier"/> object.
		/// </summary>
		public override Type AuditRuleType => typeof(AuditRule<T>);

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
		public override AccessRule AccessRuleFactory(IdentityReference identityReference, int accessMask, bool isInherited, InheritanceFlags inheritanceFlags,
			PropagationFlags propagationFlags, AccessControlType type) =>
				new AccessRule<T>(identityReference, accessMask, isInherited, inheritanceFlags, propagationFlags, type);

		// Override these if you need to do some custom bit remapping to hide any complexity from the user.

		/// <summary>
		/// Adds the specified access rule to the Discretionary Access Control List (DACL) associated with this
		/// <see cref="ObjectSecurity{T}"/> object.
		/// </summary>
		/// <param name="rule">The rule to add.</param>
		public virtual void AddAccessRule(AccessRule<T> rule) => base.AddAccessRule(rule);

		/// <summary>
		/// Adds the specified audit rule to the System Access Control List (SACL) associated with this <see cref="ObjectSecurity{T}"/> object.
		/// </summary>
		/// <param name="rule">The audit rule to add.</param>
		public virtual void AddAuditRule(AuditRule<T> rule) => base.AddAuditRule(rule);

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
		public override AuditRule AuditRuleFactory(IdentityReference identityReference, int accessMask, bool isInherited, InheritanceFlags inheritanceFlags,
			PropagationFlags propagationFlags, AuditFlags flags) =>
			new AuditRule<T>(identityReference, accessMask, isInherited, inheritanceFlags, propagationFlags, flags);

		/// <summary>
		/// Removes access rules that contain the same security identifier and access mask as the specified access rule from the
		/// Discretionary Access Control List (DACL) associated with this <see cref="ObjectSecurity{T}"/> object.
		/// </summary>
		/// <param name="rule">The rule to remove.</param>
		/// <returns><see langword="true"/> if the access rule was successfully removed; otherwise, <see langword="false"/>.</returns>
		public virtual bool RemoveAccessRule(AccessRule<T> rule) => base.RemoveAccessRule(rule);

		/// <summary>
		/// Removes all access rules that have the same security identifier as the specified access rule from the Discretionary Access
		/// Control List (DACL) associated with this <see cref="ObjectSecurity{T}"/> object.
		/// </summary>
		/// <param name="rule">The access rule to remove.</param>
		public virtual void RemoveAccessRuleAll(AccessRule<T> rule) => base.RemoveAccessRuleAll(rule);

		/// <summary>
		/// Removes all access rules that exactly match the specified access rule from the Discretionary Access Control List (DACL)
		/// associated with this <see cref="ObjectSecurity{T}"/> object
		/// </summary>
		/// <param name="rule">The access rule to remove.</param>
		public virtual void RemoveAccessRuleSpecific(AccessRule<T> rule) => base.RemoveAccessRuleSpecific(rule);

		/// <summary>
		/// Removes audit rules that contain the same security identifier and access mask as the specified audit rule from the System Access
		/// Control List (SACL) associated with this <see cref="ObjectSecurity{T}"/> object.
		/// </summary>
		/// <param name="rule">The audit rule to remove.</param>
		/// <returns><see langword="true"/> if the object was removed; otherwise, <see langword="false"/>.</returns>
		public virtual bool RemoveAuditRule(AuditRule<T> rule) => base.RemoveAuditRule(rule);

		/// <summary>
		/// Removes all audit rules that have the same security identifier as the specified audit rule from the System Access Control List
		/// (SACL) associated with this <see cref="ObjectSecurity{T}"/> object.
		/// </summary>
		/// <param name="rule">The audit rule to remove.</param>
		public virtual void RemoveAuditRuleAll(AuditRule<T> rule) => base.RemoveAuditRuleAll(rule);

		/// <summary>
		/// Removes all audit rules that exactly match the specified audit rule from the System Access Control List (SACL) associated with
		/// this <see cref="ObjectSecurity{T}"/> object.
		/// </summary>
		/// <param name="rule">The audit rule to remove.</param>
		public virtual void RemoveAuditRuleSpecific(AuditRule<T> rule) => base.RemoveAuditRuleSpecific(rule);

		/// <summary>
		/// Removes all access rules in the Discretionary Access Control List (DACL) associated with this <see cref="ObjectSecurity{T}"/>
		/// object and then adds the specified access rule.
		/// </summary>
		/// <param name="rule">The access rule to reset.</param>
		public virtual void ResetAccessRule(AccessRule<T> rule) => base.ResetAccessRule(rule);

		/// <summary>
		/// Removes all access rules that contain the same security identifier and qualifier as the specified access rule in the
		/// Discretionary Access Control List (DACL) associated with this <see cref="ObjectSecurity{T}"/> object and then adds the specified
		/// access rule.
		/// </summary>
		/// <param name="rule">The access rule to set.</param>
		public virtual void SetAccessRule(AccessRule<T> rule) => base.SetAccessRule(rule);

		/// <summary>
		/// Removes all audit rules that contain the same security identifier and qualifier as the specified audit rule in the System Access
		/// Control List (SACL) associated with this <see cref="ObjectSecurity{T}"/> object and then adds the specified audit rule.
		/// </summary>
		/// <param name="rule">The audit rule to set.</param>
		public virtual void SetAuditRule(AuditRule<T> rule) => base.SetAuditRule(rule);

		// Use this in your own Persist after you have demanded any appropriate CAS permissions. Note that you will want your version to be
		// internal and use a specialized Safe Handle.
		/// <summary>
		/// Saves the security descriptor associated with this <see cref="ObjectSecurity{T}"/> object to permanent storage, using the
		/// specified handle.
		/// </summary>
		/// <param name="handle">The handle of the securable object with which this <see cref="ObjectSecurity{T}"/> object is associated.</param>
		protected internal void Persist(SafeHandle handle)
		{
			WriteLock();

			try
			{
				var persistRules = GetAccessControlSectionsFromChanges();
				Persist(handle, persistRules);
				OwnerModified = GroupModified = AuditRulesModified = AccessRulesModified = false;
			}
			finally
			{
				WriteUnlock();
			}
		}

		// Use this in your own Persist after you have demanded any appropriate CAS permissions. Note that you will want your version to be internal.
		/// <summary>
		/// Saves the security descriptor associated with this <see cref="ObjectSecurity{T}"/> object to permanent storage, using the
		/// specified name.
		/// </summary>
		/// <param name="name">The name of the securable object with which this <see cref="ObjectSecurity{T}"/> object is associated.</param>
		protected internal void Persist(string name)
		{
			WriteLock();

			try
			{
				var persistRules = GetAccessControlSectionsFromChanges();
				Persist(name, persistRules);
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
			{
				persistRules = AccessControlSections.Access;
			}
			if (AuditRulesModified)
			{
				persistRules |= AccessControlSections.Audit;
			}
			if (OwnerModified)
			{
				persistRules |= AccessControlSections.Owner;
			}
			if (GroupModified)
			{
				persistRules |= AccessControlSections.Group;
			}
			return persistRules;
		}
	}
}

#endif