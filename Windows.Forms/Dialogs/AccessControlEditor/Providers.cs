﻿using System.Linq;
using System.Security.AccessControl;
using Vanara.PInvoke;
using static Vanara.PInvoke.AclUI;
using static Vanara.PInvoke.AdvApi32;
using ResourceType = System.Security.AccessControl.ResourceType;

namespace Vanara.Security.AccessControl;

/// <summary>
/// An interface for defining an information provider for object types supplied to the <see cref="Windows.Forms.AccessControlEditorDialog"/>.
/// </summary>
public interface IAccessControlEditorDialogProvider
{
	/// <summary>Gets the type of the resource.</summary>
	/// <value>The type of the resource.</value>
	ResourceType ResourceType { get; }

	/// <summary>
	/// Gets an array of <see cref="SI_ACCESS"/> structures which define how to display
	/// different access rights supplied to the editor along with the index of the access right
	/// that should be applied to new ACEs.
	/// </summary>
	/// <param name="flags">
	/// A set of bit flags that indicate the property page being initialized. This value is zero
	/// if the basic security page is being initialized.
	/// </param>
	/// <param name="rights">The access right information for each right.</param>
	/// <param name="defaultIndex">
	/// The default index in the <paramref name="rights"/> array for new ACEs.
	/// </param>
	void GetAccessListInfo(SI_OBJECT_INFO_Flags flags, out SI_ACCESS[] rights, out uint defaultIndex);

	/// <summary>Gets a default Security Descriptor for resetting the security of the object.</summary>
	/// <returns>Pointer to a Security Descriptor.</returns>
	PSECURITY_DESCRIPTOR GetDefaultSecurity();

	/// <summary>
	/// Gets the effective permissions for the provided Sid within the Security Descriptor.
	/// Called only when no object type identifier is specified.
	/// </summary>
	/// <param name="pUserSid">A pointer to the Sid of the identity to check.</param>
	/// <param name="serverName">Name of the server. This can be <c>null</c>.</param>
	/// <param name="pSecurityDescriptor">A pointer to the security descriptor.</param>
	/// <returns>An array of access masks.</returns>
	ACCESS_MASK[] GetEffectivePermission(PSID pUserSid, string? serverName, PSECURITY_DESCRIPTOR pSecurityDescriptor);

	/// <summary>
	/// Gets the effective permissions for the provided Sid within the Security Descriptor.
	/// Called only when an object type identifier is specified.
	/// </summary>
	/// <param name="objTypeId">The object type identifier.</param>
	/// <param name="pUserSid">A pointer to the Sid of the identity to check.</param>
	/// <param name="serverName">Name of the server. This can be <c>null</c>.</param>
	/// <param name="pSecurityDescriptor">A pointer to the security descriptor.</param>
	/// <param name="objectTypeList">The object type list.</param>
	/// <param name="grantedAccessList">An array of access masks.</param>
	/// <returns>An array of access masks.</returns>
	HRESULT GetEffectivePermission(Guid objTypeId, PSID pUserSid, string? serverName, PSECURITY_DESCRIPTOR pSecurityDescriptor, out OBJECT_TYPE_LIST[]? objectTypeList, out ACCESS_MASK[]? grantedAccessList);

	/// <summary>Gets the generic mapping for standard rights.</summary>
	/// <param name="aceFlags">The ace flags.</param>
	/// <returns>A <see cref="GENERIC_MAPPING"/> structure for this object type.</returns>
	GENERIC_MAPPING GetGenericMapping(AceFlags aceFlags);

	/// <summary>
	/// Determines the source of inherited access control entries (ACEs) in discretionary access
	/// control lists (DACLs) and system access control lists (SACLs).
	/// </summary>
	/// <param name="objName">Name of the object.</param>
	/// <param name="serverName">Name of the server.</param>
	/// <param name="isContainer">If set to <c>true</c> object is a container.</param>
	/// <param name="si">
	/// The object-related security information being queried. See SECURITY_INFORMATION type in
	/// Windows documentation.
	/// </param>
	/// <param name="pAcl">A pointer to the ACL.</param>
	/// <returns>
	/// An array of <see cref="INHERITED_FROM"/> structures. The length of this array is the
	/// same as the number of ACEs in the ACL referenced by pACL. Each <see
	/// cref="INHERITED_FROM"/> entry provides inheritance information for the corresponding
	/// ACE entry in pACL.
	/// </returns>
	INHERITED_FROM[] GetInheritSource(string objName, string? serverName, bool isContainer, uint si, PACL pAcl);

	/// <summary>Gets inheritance information for supported object type.</summary>
	/// <returns>
	/// An array of <see cref="SI_INHERIT_TYPE"/> that includes one entry for each combination
	/// of inheritance flags and child object type that you support.
	/// </returns>
	SI_INHERIT_TYPE[] GetInheritTypes();

	/// <summary>Callback method for the property pages.</summary>
	/// <param name="hwnd">The HWND.</param>
	/// <param name="uMsg">The message.</param>
	/// <param name="uPage">The page type.</param>
	HRESULT PropertySheetPageCallback(HWND hwnd, PropertySheetCallbackMessage uMsg, SI_PAGE_TYPE uPage);
}

/// <summary>Base implementation of <see cref="IAccessControlEditorDialogProvider"/>.</summary>
public class GenericProvider : IAccessControlEditorDialogProvider
{
	/// <summary>Gets the type of the resource.</summary>
	/// <value>The type of the resource.</value>
	public virtual ResourceType ResourceType => ResourceType.Unknown;

	/// <summary>
	/// Gets an array of <see cref="SI_ACCESS"/> structures which define how to display
	/// different access rights supplied to the editor along with the index of the access right
	/// that should be applied to new ACEs.
	/// </summary>
	/// <param name="flags">
	/// A set of bit flags that indicate the property page being initialized. This value is zero
	/// if the basic security page is being initialized.
	/// </param>
	/// <param name="rights">The access right information for each right.</param>
	/// <param name="defaultIndex">
	/// The default index in the <paramref name="rights"/> array for new ACEs.
	/// </param>
	public virtual void GetAccessListInfo(SI_OBJECT_INFO_Flags flags, out SI_ACCESS[] rights, out uint defaultIndex)
	{
		rights = [new SI_ACCESS(0, ResStr("Object"), 0)];
		defaultIndex = 0;
	}

	/// <summary>Gets a default Security Descriptor for resetting the security of the object.</summary>
	/// <returns>Pointer to a Security Descriptor.</returns>
	public virtual PSECURITY_DESCRIPTOR GetDefaultSecurity() => IntPtr.Zero;

	/// <summary>
	/// Gets the effective permissions for the provided Sid within the Security Descriptor.
	/// </summary>
	/// <param name="pUserSid">A pointer to the Sid of the identity to check.</param>
	/// <param name="serverName">Name of the server. This can be <c>null</c>.</param>
	/// <param name="pSecurityDescriptor">A pointer to the security descriptor.</param>
	/// <returns>An array of access masks.</returns>
	public virtual ACCESS_MASK[] GetEffectivePermission(PSID pUserSid, string? serverName, PSECURITY_DESCRIPTOR pSecurityDescriptor)
	{
		ACCESS_MASK mask = pSecurityDescriptor.GetEffectiveRights(pUserSid);
		return [mask];
	}

	/// <summary>
	/// Gets the effective permissions for the provided Sid within the Security Descriptor.
	/// Called only when an object type identifier is specified.
	/// </summary>
	/// <param name="objTypeId">The object type identifier.</param>
	/// <param name="pUserSid">A pointer to the Sid of the identity to check.</param>
	/// <param name="serverName">Name of the server. This can be <c>null</c>.</param>
	/// <param name="pSecurityDescriptor">A pointer to the security descriptor.</param>
	/// <param name="objectTypeList">The object type list.</param>
	/// <param name="grantedAccessList">An array of access masks.</param>
	/// <returns></returns>
	/// <exception cref="NotImplementedException"></exception>
	public virtual HRESULT GetEffectivePermission(Guid objTypeId, PSID pUserSid, string? serverName, PSECURITY_DESCRIPTOR pSecurityDescriptor, out OBJECT_TYPE_LIST[]? objectTypeList, out ACCESS_MASK[]? grantedAccessList)
	{
		objectTypeList = null;
		grantedAccessList = null;
		return HRESULT.E_NOTIMPL;
	}

	/// <summary>Gets the generic mapping for standard rights.</summary>
	/// <returns>A <see cref="GENERIC_MAPPING"/> structure for this object type.</returns>
	public virtual GENERIC_MAPPING GetGenericMapping(AceFlags aceFlags) => new(0x80000000, 0x40000000, 0x20000000, 0x10000000);

	/// <summary>
	/// Determines the source of inherited access control entries (ACEs) in discretionary access
	/// control lists (DACLs) and system access control lists (SACLs).
	/// </summary>
	/// <param name="objName">Name of the object.</param>
	/// <param name="serverName">Name of the server.</param>
	/// <param name="isContainer">If set to <c>true</c> object is a container.</param>
	/// <param name="si">
	/// The object-related security information being queried. See SECURITY_INFORMATION type in
	/// Windows documentation.
	/// </param>
	/// <param name="pAcl">A pointer to the ACL.</param>
	/// <returns>
	/// An array of <see cref="INHERITED_FROM"/> structures. The length of this array is the
	/// same as the number of ACEs in the ACL referenced by pACL. Each <see
	/// cref="INHERITED_FROM"/> entry provides inheritance information for the corresponding
	/// ACE entry in pACL.
	/// </returns>
	public virtual INHERITED_FROM[] GetInheritSource(string objName, string? serverName, bool isContainer, uint si, PACL pAcl)
	{
		var gMap = GetGenericMapping(0);
		return GetInheritanceSource(objName, ResourceType, (SECURITY_INFORMATION)si, isContainer, pAcl, ref gMap).ToArray();
	}

	/// <summary>Gets inheritance information for supported object type.</summary>
	/// <returns>
	/// An array of <see cref="SI_INHERIT_TYPE"/> that includes one entry for each combination
	/// of inheritance flags and child object type that you support.
	/// </returns>
	public virtual SI_INHERIT_TYPE[] GetInheritTypes() => [
			new SI_INHERIT_TYPE(0, ResStr("StdInheritance")),
			new SI_INHERIT_TYPE(INHERIT_FLAGS.CONTAINER_INHERIT_ACE | INHERIT_FLAGS.OBJECT_INHERIT_ACE, ResStr("StdInheritanceCIOI")),
			new SI_INHERIT_TYPE(INHERIT_FLAGS.CONTAINER_INHERIT_ACE, ResStr("StdInheritanceCI")),
			new SI_INHERIT_TYPE(INHERIT_FLAGS.OBJECT_INHERIT_ACE, ResStr("StdInheritanceOI")),
			new SI_INHERIT_TYPE(INHERIT_FLAGS.INHERIT_ONLY_ACE | INHERIT_FLAGS.CONTAINER_INHERIT_ACE | INHERIT_FLAGS.OBJECT_INHERIT_ACE, ResStr("StdInheritanceIOCIOI")),
			new SI_INHERIT_TYPE(INHERIT_FLAGS.INHERIT_ONLY_ACE | INHERIT_FLAGS.CONTAINER_INHERIT_ACE, ResStr("StdInheritanceIOCI")),
			new SI_INHERIT_TYPE(INHERIT_FLAGS.INHERIT_ONLY_ACE | INHERIT_FLAGS.OBJECT_INHERIT_ACE, ResStr("StdInheritanceIOOI"))
		];

	/// <summary>Callback method for the property pages.</summary>
	/// <param name="hwnd">The HWND.</param>
	/// <param name="uMsg">The message.</param>
	/// <param name="uPage">The page type.</param>
	public virtual HRESULT PropertySheetPageCallback(HWND hwnd, PropertySheetCallbackMessage uMsg, SI_PAGE_TYPE uPage) => HRESULT.S_OK;

	/// <summary>Gets a resource string.</summary>
	/// <param name="id">The string identifier.</param>
	/// <returns>Localized resource string or identifier string if not found.</returns>
	protected static string ResStr(string id) => Windows.Forms.Properties.Resources.ResourceManager.GetString(id) ?? id;
}

internal class FileProvider : GenericProvider
{
	private const string defaultSecuritySddl = "O:WDG:BAD:AI(A;CIIO;FA;;;WD)(A;;FA;;;BA)S:AI(AU;SAFACIIO;FA;;;WD)";

	public static readonly SafePSECURITY_DESCRIPTOR defaultSd = ConvertStringSecurityDescriptorToSecurityDescriptor(defaultSecuritySddl);

	public override ResourceType ResourceType => ResourceType.FileObject;

	public override void GetAccessListInfo(SI_OBJECT_INFO_Flags flags, out SI_ACCESS[] rights, out uint defaultIndex)
	{
		rights = [
			new((uint)FileSystemRights.FullControl, ResStr("FileRightFullControl"), INHERIT_FLAGS.SI_ACCESS_GENERAL| INHERIT_FLAGS.SI_ACCESS_SPECIFIC | INHERIT_FLAGS.CONTAINER_INHERIT_ACE | INHERIT_FLAGS.OBJECT_INHERIT_ACE),
			new((uint)FileSystemRights.Modify, ResStr("FileRightModify"), INHERIT_FLAGS.SI_ACCESS_GENERAL | INHERIT_FLAGS.CONTAINER_INHERIT_ACE | INHERIT_FLAGS.OBJECT_INHERIT_ACE),
			new((uint)FileSystemRights.ReadAndExecute, ResStr("FileRightReadAndExecute"), INHERIT_FLAGS.SI_ACCESS_GENERAL | INHERIT_FLAGS.CONTAINER_INHERIT_ACE | INHERIT_FLAGS.OBJECT_INHERIT_ACE),
			new((uint)FileSystemRights.ReadAndExecute, ResStr("FileRightListFolderContents"), INHERIT_FLAGS.SI_ACCESS_CONTAINER | INHERIT_FLAGS.CONTAINER_INHERIT_ACE),
			new((uint)FileSystemRights.Read, ResStr("FileRightRead"), INHERIT_FLAGS.SI_ACCESS_GENERAL | INHERIT_FLAGS.CONTAINER_INHERIT_ACE | INHERIT_FLAGS.OBJECT_INHERIT_ACE),
			new((uint)FileSystemRights.Write, ResStr("FileRightWrite"), INHERIT_FLAGS.SI_ACCESS_GENERAL | INHERIT_FLAGS.CONTAINER_INHERIT_ACE | INHERIT_FLAGS.OBJECT_INHERIT_ACE),
			new((uint)FileSystemRights.ExecuteFile, ResStr("FileRightExecuteFile"), INHERIT_FLAGS.SI_ACCESS_SPECIFIC),
			new((uint)FileSystemRights.ReadData, ResStr("FileRightReadData"), INHERIT_FLAGS.SI_ACCESS_SPECIFIC),
			new((uint)FileSystemRights.ReadAttributes, ResStr("FileRightReadAttributes"), INHERIT_FLAGS.SI_ACCESS_SPECIFIC),
			new((uint)FileSystemRights.ReadExtendedAttributes, ResStr("FileRightReadExtendedAttributes"), INHERIT_FLAGS.SI_ACCESS_SPECIFIC),
			new((uint)FileSystemRights.WriteData, ResStr("FileRightWriteData"), INHERIT_FLAGS.SI_ACCESS_SPECIFIC),
			new((uint)FileSystemRights.AppendData, ResStr("FileRightAppendData"), INHERIT_FLAGS.SI_ACCESS_SPECIFIC),
			new((uint)FileSystemRights.WriteAttributes, ResStr("FileRightWriteAttributes"), INHERIT_FLAGS.SI_ACCESS_SPECIFIC),
			new((uint)FileSystemRights.WriteExtendedAttributes, ResStr("FileRightWriteExtendedAttributes"), INHERIT_FLAGS.SI_ACCESS_SPECIFIC),
			new((uint)FileSystemRights.DeleteSubdirectoriesAndFiles, ResStr("FileRightDeleteSubdirectoriesAndFiles"), INHERIT_FLAGS.SI_ACCESS_SPECIFIC),
			new((uint)FileSystemRights.Delete, ResStr("StdRightDelete"), INHERIT_FLAGS.SI_ACCESS_SPECIFIC),
			new((uint)FileSystemRights.ReadPermissions, ResStr("FileRightReadPermissions"), INHERIT_FLAGS.SI_ACCESS_SPECIFIC),
			new((uint)FileSystemRights.ChangePermissions, ResStr("FileRightChangePermissions"), INHERIT_FLAGS.SI_ACCESS_SPECIFIC),
			new((uint)FileSystemRights.TakeOwnership, ResStr("StdRightTakeOwnership"), INHERIT_FLAGS.SI_ACCESS_SPECIFIC),
			new((uint)FileSystemRights.Modify, ResStr("FileRightModify"), 0),
			new((uint)FileSystemRights.ReadAndExecute, ResStr("FileRightReadAndExecute"), 0),
			new((uint)(FileSystemRights.Write | FileSystemRights.ExecuteFile), ResStr("FileRightWriteAndExecute"), 0),
			new((uint)(FileSystemRights.ReadAndExecute | FileSystemRights.Write), ResStr("FileRightReadWriteAndExecute"), 0),
			new(0, ResStr("File"), 0)
		];
		defaultIndex = 3;
	}

	public override PSECURITY_DESCRIPTOR GetDefaultSecurity() => defaultSd;

	public override GENERIC_MAPPING GetGenericMapping(AceFlags aceFlags) =>
		new((uint)(FileSystemRights.Read | FileSystemRights.Synchronize),
			(uint)(FileSystemRights.Write | FileSystemRights.Synchronize), 0x1200A0, (uint)FileSystemRights.FullControl);

	public override SI_INHERIT_TYPE[] GetInheritTypes() => [
			new(0, ResStr("FileInheritance")),
			new(INHERIT_FLAGS.CONTAINER_INHERIT_ACE | INHERIT_FLAGS.OBJECT_INHERIT_ACE, ResStr("FileInheritanceCIOI")),
			new(INHERIT_FLAGS.CONTAINER_INHERIT_ACE, ResStr("FileInheritanceCI")),
			new(INHERIT_FLAGS.OBJECT_INHERIT_ACE, ResStr("FileInheritanceOI")),
			new(INHERIT_FLAGS.INHERIT_ONLY_ACE | INHERIT_FLAGS.CONTAINER_INHERIT_ACE | INHERIT_FLAGS.OBJECT_INHERIT_ACE, ResStr("FileInheritanceIOCIOI")),
			new(INHERIT_FLAGS.INHERIT_ONLY_ACE | INHERIT_FLAGS.CONTAINER_INHERIT_ACE, ResStr("FileInheritanceIOCI")),
			new(INHERIT_FLAGS.INHERIT_ONLY_ACE | INHERIT_FLAGS.OBJECT_INHERIT_ACE, ResStr("FileInheritanceIOOI"))
		];
}

internal class KernelProvider : GenericProvider
{
	public override ResourceType ResourceType => ResourceType.KernelObject;

	//public override IntPtr GetDefaultSecurity() => IntPtr.Zero;
}

internal class RegistryProvider : GenericProvider
{
	public override ResourceType ResourceType => ResourceType.RegistryKey;

	public override void GetAccessListInfo(SI_OBJECT_INFO_Flags flags, out SI_ACCESS[] rights, out uint defaultIndex)
	{
		rights = [
			new SI_ACCESS((uint)RegistryRights.FullControl, ResStr("FileRightFullControl"), INHERIT_FLAGS.SI_ACCESS_GENERAL | INHERIT_FLAGS.SI_ACCESS_SPECIFIC | INHERIT_FLAGS.CONTAINER_INHERIT_ACE | INHERIT_FLAGS.OBJECT_INHERIT_ACE),
			new SI_ACCESS((uint)RegistryRights.ReadKey, ResStr("FileRightRead"), INHERIT_FLAGS.SI_ACCESS_GENERAL | INHERIT_FLAGS.CONTAINER_INHERIT_ACE | INHERIT_FLAGS.OBJECT_INHERIT_ACE),
			new SI_ACCESS((uint)RegistryRights.QueryValues, ResStr("RegistryRightQueryValues"), INHERIT_FLAGS.SI_ACCESS_SPECIFIC),
			new SI_ACCESS((uint)RegistryRights.SetValue, ResStr("RegistryRightSetValue"), INHERIT_FLAGS.SI_ACCESS_SPECIFIC),
			new SI_ACCESS((uint)RegistryRights.CreateSubKey, ResStr("RegistryRightCreateSubKey"), INHERIT_FLAGS.SI_ACCESS_SPECIFIC),
			new SI_ACCESS((uint)RegistryRights.EnumerateSubKeys, ResStr("RegistryRightEnumerateSubKeys"), INHERIT_FLAGS.SI_ACCESS_SPECIFIC),
			new SI_ACCESS((uint)RegistryRights.Notify, ResStr("RegistryRightNotify"), INHERIT_FLAGS.SI_ACCESS_SPECIFIC),
			new SI_ACCESS((uint)RegistryRights.CreateLink, ResStr("RegistryRightCreateLink"), INHERIT_FLAGS.SI_ACCESS_SPECIFIC),
			new SI_ACCESS((uint)RegistryRights.Delete, ResStr("StdRightDelete"), INHERIT_FLAGS.SI_ACCESS_SPECIFIC),
			new SI_ACCESS((uint)RegistryRights.ChangePermissions, ResStr("RegistryRightChangePermissions"), INHERIT_FLAGS.SI_ACCESS_SPECIFIC),
			new SI_ACCESS((uint)RegistryRights.TakeOwnership, ResStr("RegistryRightTakeOwnership"), INHERIT_FLAGS.SI_ACCESS_SPECIFIC),
			new SI_ACCESS((uint)RegistryRights.ReadPermissions, ResStr("RegistryRightReadControl"), INHERIT_FLAGS.SI_ACCESS_SPECIFIC),
			new SI_ACCESS(0, ResStr("File"), 0)
		];
		defaultIndex = 11;
	}

	//public override IntPtr GetDefaultSecurity() => IntPtr.Zero;

	public override GENERIC_MAPPING GetGenericMapping(AceFlags aceFlags) => new((uint)RegistryRights.ReadKey, (uint)RegistryRights.WriteKey, (uint)RegistryRights.ExecuteKey, (uint)RegistryRights.FullControl);

	public override INHERITED_FROM[] GetInheritSource(string objName, string? serverName, bool isContainer, uint si, PACL pAcl)
	{
		var ret = base.GetInheritSource(objName, serverName, isContainer, si, pAcl);
		for (var i = 0; i < ret.Length; i++)
		{
			if (ret[i].GenerationGap == -1)
			{
				var idx = objName.StartsWith(@"\\") ? 1 : 0;
				var parts = objName.TrimStart('\\').Split('\\');
				if (parts.Length > idx)
					ret[i].AncestorName = parts[idx].Replace("HKEY_", "");
			}
		}
		return ret;
	}

	public override SI_INHERIT_TYPE[] GetInheritTypes() => [
			new SI_INHERIT_TYPE(0, ResStr("RegistryInheritance")),
			new SI_INHERIT_TYPE(INHERIT_FLAGS.CONTAINER_INHERIT_ACE | INHERIT_FLAGS.OBJECT_INHERIT_ACE, ResStr("RegistryInheritanceCI")),
			new SI_INHERIT_TYPE(INHERIT_FLAGS.INHERIT_ONLY_ACE | INHERIT_FLAGS.CONTAINER_INHERIT_ACE, ResStr("RegistryInheritanceIOCI")),
		];
}

internal class TaskProvider : GenericProvider
{
	public override ResourceType ResourceType => Windows.Forms.AccessControlEditorDialog.taskResourceType;

	public override void GetAccessListInfo(SI_OBJECT_INFO_Flags flags, out SI_ACCESS[] rights, out uint defaultIndex)
	{
		rights = [
			new SI_ACCESS(0x1F01FF, ResStr("FileRightFullControl"), INHERIT_FLAGS.SI_ACCESS_GENERAL | INHERIT_FLAGS.SI_ACCESS_SPECIFIC | INHERIT_FLAGS.CONTAINER_INHERIT_ACE | INHERIT_FLAGS.OBJECT_INHERIT_ACE),
			new SI_ACCESS(0x1200A9, ResStr("FileRightListFolderContents"), INHERIT_FLAGS.SI_ACCESS_CONTAINER | INHERIT_FLAGS.CONTAINER_INHERIT_ACE),
			new SI_ACCESS(0x120089, ResStr("FileRightRead"), INHERIT_FLAGS.SI_ACCESS_GENERAL | INHERIT_FLAGS.CONTAINER_INHERIT_ACE | INHERIT_FLAGS.OBJECT_INHERIT_ACE),
			new SI_ACCESS(0x120116, ResStr("FileRightWrite"), INHERIT_FLAGS.SI_ACCESS_GENERAL | INHERIT_FLAGS.CONTAINER_INHERIT_ACE | INHERIT_FLAGS.OBJECT_INHERIT_ACE),
			new SI_ACCESS(0x1200A0, ResStr("TaskRightExecute"), INHERIT_FLAGS.SI_ACCESS_GENERAL | INHERIT_FLAGS.CONTAINER_INHERIT_ACE | INHERIT_FLAGS.OBJECT_INHERIT_ACE),

			new SI_ACCESS(0x000001, ResStr("FileRightReadData"), INHERIT_FLAGS.SI_ACCESS_SPECIFIC),
			new SI_ACCESS(0x000002, ResStr("FileRightWriteData"), INHERIT_FLAGS.SI_ACCESS_SPECIFIC),
			new SI_ACCESS(0x000004, ResStr("FileRightAppendData"), INHERIT_FLAGS.SI_ACCESS_SPECIFIC),
			new SI_ACCESS(0x000008, ResStr("FileRightReadExtendedAttributes"), INHERIT_FLAGS.SI_ACCESS_SPECIFIC),
			new SI_ACCESS(0x000010, ResStr("FileRightWriteExtendedAttributes"), INHERIT_FLAGS.SI_ACCESS_SPECIFIC),
			new SI_ACCESS(0x000020, ResStr("FileRightExecuteFile"), INHERIT_FLAGS.SI_ACCESS_SPECIFIC),
			new SI_ACCESS(0x000040, ResStr("FileRightDeleteSubdirectoriesAndFiles"), INHERIT_FLAGS.SI_ACCESS_SPECIFIC),
			new SI_ACCESS(0x000080, ResStr("FileRightReadAttributes"), INHERIT_FLAGS.SI_ACCESS_SPECIFIC),
			new SI_ACCESS(0x000100, ResStr("FileRightWriteAttributes"), INHERIT_FLAGS.SI_ACCESS_SPECIFIC),
			new SI_ACCESS(0x010000, ResStr("StdRightDelete"), INHERIT_FLAGS.SI_ACCESS_SPECIFIC),
			new SI_ACCESS((uint)FileSystemRights.ReadPermissions, ResStr("FileRightReadPermissions"), INHERIT_FLAGS.SI_ACCESS_SPECIFIC),
			new SI_ACCESS((uint)FileSystemRights.ChangePermissions, ResStr("FileRightChangePermissions"), INHERIT_FLAGS.SI_ACCESS_SPECIFIC),
			new SI_ACCESS((uint)FileSystemRights.TakeOwnership, ResStr("StdRightTakeOwnership"), INHERIT_FLAGS.SI_ACCESS_SPECIFIC),
			new SI_ACCESS(0x100000, ResStr("Synchronize"), INHERIT_FLAGS.SI_ACCESS_SPECIFIC),

			new SI_ACCESS(0x1F019F, ResStr("FileRightReadWriteAndExecute"), 0),
			new SI_ACCESS(0, ResStr("File"), 0)
		];
		defaultIndex = 3;
	}

	//public override IntPtr GetDefaultSecurity() => IntPtr.Zero;

	public override GENERIC_MAPPING GetGenericMapping(AceFlags aceFlags) => new(0x120089, 0x120116, 0x1200A0, 0x1F01FF);

	public override INHERITED_FROM[] GetInheritSource(string objName, string? serverName, bool isContainer, uint si, PACL pAcl) =>
		// Get list of all parents
		//var obj = SecuredObject.GetKnownObject(Windows.Forms.AccessControlEditorDialog.TaskResourceType, objName, serverName);
		//var parents = new System.Collections.Generic.List<object>();
		//var folder = obj.GetPropertyValue(isContainer ? "Parent" : "Folder");
		//while (folder != null)
		//{
		//	parents.Add(folder);
		//	folder = folder.GetPropertyValue("Parent");
		//}

		// For each ACE, walk up list of lists of parents to determine if there's a matching one.
		// var acl = RawAclFromPtr(pAcl);
		// for (int i = 0; i < acl.Count; i++) { }

		new INHERITED_FROM[pAcl.AceCount()];
}