using System;

namespace Vanara.PInvoke
{
	/// <summary>
	/// The SECURITY_INFORMATION data type identifies the object-related security information being set or queried. This security information includes:
	/// <list type="bullet">
	/// <item><term>The owner of an object</term></item>
	/// <item><term>The primary group of an object</term></item>
	/// <item><term>The discretionary access control list (DACL) of an object</term></item>
	/// <item><term>The system access control list (SACL) of an object</term></item>
	/// </list>
	/// </summary>
	[Flags]
	public enum SECURITY_INFORMATION : uint
	{
		/// <summary>The owner identifier of the object is being referenced.</summary>
		OWNER_SECURITY_INFORMATION = 0x00000001,
		/// <summary>The primary group identifier of the object is being referenced.</summary>
		GROUP_SECURITY_INFORMATION = 0x00000002,
		/// <summary>The DACL of the object is being referenced.</summary>
		DACL_SECURITY_INFORMATION = 0x00000004,
		/// <summary>The SACL of the object is being referenced.</summary>
		SACL_SECURITY_INFORMATION = 0x00000008,
		/// <summary>The mandatory integrity label is being referenced. The mandatory integrity label is an ACE in the SACL of the object.</summary>
		LABEL_SECURITY_INFORMATION = 0x00000010,
		/// <summary>
		/// The resource properties of the object being referenced. The resource properties are stored in SYSTEM_RESOURCE_ATTRIBUTE_ACE types in the SACL of
		/// the security descriptor.
		/// </summary>
		ATTRIBUTE_SECURITY_INFORMATION = 0x00000020,
		/// <summary>
		/// The Central Access Policy (CAP) identifier applicable on the object that is being referenced. Each CAP identifier is stored in a
		/// SYSTEM_SCOPED_POLICY_ID_ACE type in the SACL of the SD.
		/// </summary>
		SCOPE_SECURITY_INFORMATION = 0x00000040,
		/// <summary>Reserved.</summary>
		PROCESS_TRUST_LABEL_SECURITY_INFORMATION = 0x00000080,
		/// <summary>
		/// All parts of the security descriptor. This is useful for backup and restore software that needs to preserve the entire security descriptor.
		/// </summary>
		BACKUP_SECURITY_INFORMATION = 0x00010000,
		/// <summary>The DACL cannot inherit access control entries (ACEs).</summary>
		PROTECTED_DACL_SECURITY_INFORMATION = 0x80000000,
		/// <summary>The SACL cannot inherit ACEs.</summary>
		PROTECTED_SACL_SECURITY_INFORMATION = 0x40000000,
		/// <summary>The DACL inherits ACEs from the parent object.</summary>
		UNPROTECTED_DACL_SECURITY_INFORMATION = 0x20000000,
		/// <summary>The SACL inherits ACEs from the parent object.</summary>
		UNPROTECTED_SACL_SECURITY_INFORMATION = 0x10000000
	}
}