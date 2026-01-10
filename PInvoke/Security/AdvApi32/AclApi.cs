using System.Collections.Generic;

namespace Vanara.PInvoke;

public static partial class AdvApi32
{
	/// <summary>A function used to track the progress of the TreeResetNamedSecurityInfo and TreeSetNamedSecurityInfo functions.</summary>
	/// <param name="pObjectName">Name of object just processed.</param>
	/// <param name="Status">Status of operation on object.</param>
	/// <param name="pInvokeSetting">When to set.</param>
	/// <param name="Args">Caller specific data.</param>
	/// <param name="SecuritySet">Whether security was set.</param>
	[PInvokeData("aclapi.h", MSDNShortId = "caa711c3-301b-4ed7-b1f4-dc6a48563905")]
	[UnmanagedFunctionPointer(CallingConvention.Winapi, CharSet = CharSet.Unicode)]
	public delegate void FN_PROGRESS(string pObjectName, uint Status, ref PROG_INVOKE_SETTING pInvokeSetting, IntPtr Args, [MarshalAs(UnmanagedType.Bool)] bool SecuritySet);

	/// <summary>Flags to control the behavior of <see cref="TreeSetNamedSecurityInfo"/>.</summary>
	[PInvokeData("aclapi.h", MSDNShortId = "caa711c3-301b-4ed7-b1f4-dc6a48563905")]
	public enum TREE_SEC_INFO
	{
		/// <summary>
		/// The security information is set on the object specified by the pObjectName parameter and the tree of child objects of that
		/// object. If ACLs are specified in either the pDacl or pSacl parameters, the security descriptors are associated with the
		/// object. The security descriptors are propagated to the tree of child objects based on their inheritance properties.
		/// </summary>
		TREE_SEC_INFO_SET = 0x00000001,

		/// <summary>
		/// The security information is reset on the object specified by the pObjectName parameter and the tree of child objects of that
		/// object. Any existing security information is removed from all objects on the tree.
		/// <para>
		/// If any object in the tree does not grant appropriate permissions to the caller to modify the security descriptor on the
		/// object, then the propagation of security information on that particular node of the tree and its objects is skipped. The
		/// operation continues on the rest of the tree under the object specified by the pObjectName parameter.
		/// </para>
		/// </summary>
		TREE_SEC_INFO_RESET = 0x00000002,

		/// <summary>
		/// The security information is reset on the object specified by the pObjectName parameter and the tree of child objects of that
		/// object. Any existing inherited security information is removed from all objects on the tree. Security information that was
		/// explicitly set on objects in the tree is unchanged.
		/// <para>
		/// If any object in the tree does not grant appropriate permissions to the caller to modify the security descriptor on the
		/// object, then the propagation of security information on that particular node of the tree and its objects is skipped. The
		/// operation continues on the rest of the tree under the object specified by the pObjectName parameter.
		/// </para>
		/// </summary>
		TREE_SEC_INFO_RESET_KEEP_EXPLICIT = 0x00000003,
	}

	/// <summary>
	/// <para>
	/// The <c>BuildExplicitAccessWithName</c> function initializes an EXPLICIT_ACCESS structure with data specified by the caller. The
	/// trustee is identified by a name string.
	/// </para>
	/// </summary>
	/// <param name="pExplicitAccess">
	/// <para>
	/// A pointer to an EXPLICIT_ACCESS structure to initialize. The <c>BuildExplicitAccessWithName</c> function does not allocate any
	/// memory. This parameter cannot be <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="pTrusteeName">
	/// <para>
	/// A pointer to a <c>null</c>-terminated string that contains the name of the trustee for the <c>ptstrName</c> member of the TRUSTEE
	/// structure. The <c>BuildExplicitAccessWithName</c> function sets the other members of the <c>TRUSTEE</c> structure as follows.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>pMultipleTrustee</term>
	/// <term>NULL</term>
	/// </item>
	/// <item>
	/// <term>MultipleTrusteeOperation</term>
	/// <term>NO_MULTIPLE_TRUSTEE</term>
	/// </item>
	/// <item>
	/// <term>TrusteeForm</term>
	/// <term>TRUSTEE_IS_NAME</term>
	/// </item>
	/// <item>
	/// <term>TrusteeType</term>
	/// <term>TRUSTEE_IS_UNKNOWN</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="AccessPermissions">
	/// <para>
	/// Specifies an access mask for the <c>grfAccessPermissions</c> member of the EXPLICIT_ACCESS structure. The mask is a set of bit
	/// flags that use the ACCESS_MASK format to specify the access rights that an ACE allows, denies, or audits for the trustee. The
	/// functions that use the <c>EXPLICIT_ACCESS</c> structure do not convert, interpret, or validate the bits in this mask.
	/// </para>
	/// </param>
	/// <param name="AccessMode">
	/// <para>
	/// Specifies an access mode for the <c>grfAccessMode</c> member of the EXPLICIT_ACCESS structure. The access mode indicates whether
	/// the access control entry (ACE) allows, denies, or audits the specified rights. For a discretionary access control list (DACL),
	/// this parameter can be one of the values from the ACCESS_MODE enumeration. For a system access control list (SACL), this parameter
	/// can be a combination of <c>ACCESS_MODE</c> values.
	/// </para>
	/// </param>
	/// <param name="Inheritance">
	/// <para>
	/// Specifies an inheritance type for the <c>grfInheritance</c> member of the EXPLICIT_ACCESS structure. This value is a set of bit
	/// flags that determine whether other containers or objects can inherit the ACE from the primary object to which the ACL is
	/// attached. The value of this member corresponds to the inheritance portion (low-order byte) of the <c>AceFlags</c> member of the
	/// ACE_HEADER structure. This parameter can be NO_INHERITANCE to indicate that the ACE is not inheritable, or it can be a
	/// combination of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CONTAINER_INHERIT_ACE</term>
	/// <term>Other containers that are contained by the primary object inherit the ACE.</term>
	/// </item>
	/// <item>
	/// <term>INHERIT_ONLY_ACE</term>
	/// <term>
	/// The ACE does not apply to the primary object to which the ACL is attached, but objects contained by the primary object inherit
	/// the ACE.
	/// </term>
	/// </item>
	/// <item>
	/// <term>NO_PROPAGATE_INHERIT_ACE</term>
	/// <term>The OBJECT_INHERIT_ACE and CONTAINER_INHERIT_ACE flags are not propagated to an inherited ACE.</term>
	/// </item>
	/// <item>
	/// <term>OBJECT_INHERIT_ACE</term>
	/// <term>Noncontainer objects contained by the primary object inherit the ACE.</term>
	/// </item>
	/// <item>
	/// <term>SUB_CONTAINERS_AND_OBJECTS_INHERIT</term>
	/// <term>
	/// Both containers and noncontainer objects that are contained by the primary object inherit the ACE. This flag corresponds to the
	/// combination of the CONTAINER_INHERIT_ACE and OBJECT_INHERIT_ACE flags.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SUB_CONTAINERS_ONLY_INHERIT</term>
	/// <term>
	/// Other containers that are contained by the primary object inherit the ACE. This flag corresponds to the combination of the
	/// CONTAINER_INHERIT_ACE and INHERIT_ONLY_ACE flags.
	/// </term>
	/// </item>
	/// <item>
	/// <term>SUB_OBJECTS_ONLY_INHERIT</term>
	/// <term>
	/// Noncontainer objects contained by the primary object inherit the ACE. This flag corresponds to the combination of the
	/// OBJECT_INHERIT_ACE and INHERIT_ONLY_ACE flags.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>This function does not return a value.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/aclapi/nf-aclapi-buildexplicitaccesswithnamea void
	// BuildExplicitAccessWithNameA( PEXPLICIT_ACCESS_A pExplicitAccess, LPSTR pTrusteeName, DWORD AccessPermissions, ACCESS_MODE
	// AccessMode, DWORD Inheritance );
	[DllImport(Lib.AdvApi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("aclapi.h", MSDNShortId = "5f12db19-63cf-4be6-9450-3c36e425967b")]
	public static extern void BuildExplicitAccessWithName(out EXPLICIT_ACCESS pExplicitAccess, string pTrusteeName, ACCESS_MASK AccessPermissions, ACCESS_MODE AccessMode, INHERIT_FLAGS Inheritance);

	/// <summary>
	/// <para>
	/// The <c>BuildSecurityDescriptor</c> function allocates and initializes a new security descriptor. This function can initialize the
	/// new security descriptor by merging specified security information with the information in an existing security descriptor. If you
	/// do not specify an existing security descriptor, the function initializes a new security descriptor based on the specified
	/// security information.
	/// </para>
	/// <para>
	/// The <c>BuildSecurityDescriptor</c> function creates a self-relative security descriptor. The self-relative format makes the
	/// security descriptor suitable for storing in a stream.
	/// </para>
	/// </summary>
	/// <param name="pOwner">
	/// <para>
	/// A pointer to a TRUSTEE structure that identifies the owner for the new security descriptor. If the structure uses the
	/// TRUSTEE_IS_NAME form, <c>BuildSecurityDescriptor</c> looks up the security identifier (SID) associated with the specified trustee name.
	/// </para>
	/// <para>
	/// If this parameter is <c>NULL</c>, the function uses the owner SID from the original security descriptor pointed to by pOldSD. If
	/// pOldSD is <c>NULL</c>, or if the owner SID in pOldSD is <c>NULL</c>, the owner SID is <c>NULL</c> in the new security descriptor.
	/// </para>
	/// </param>
	/// <param name="pGroup">
	/// <para>
	/// A pointer to a TRUSTEE structure that identifies the primary group SID for the new security descriptor. If the structure uses the
	/// TRUSTEE_IS_NAME form, <c>BuildSecurityDescriptor</c> looks up the SID associated with the specified trustee name.
	/// </para>
	/// <para>
	/// If this parameter is <c>NULL</c>, the function uses the group SID from the original security descriptor pointed to by pOldSD. If
	/// pOldSD is <c>NULL</c>, or if the group SID in pOldSD is <c>NULL</c>, the group SID is <c>NULL</c> in the new security descriptor.
	/// </para>
	/// </param>
	/// <param name="cCountOfAccessEntries">
	/// <para>The number of EXPLICIT_ACCESS structures in the pListOfAccessEntries array.</para>
	/// </param>
	/// <param name="pListOfAccessEntries">
	/// <para>
	/// A pointer to an array of EXPLICIT_ACCESS structures that describe access control information for the discretionary access control
	/// list (DACL) of the new security descriptor. The function creates the new DACL by merging the information in the array with the
	/// DACL in pOldSD, if any. If pOldSD is <c>NULL</c>, or if the DACL in pOldSD is <c>NULL</c>, the function creates a new DACL based
	/// solely on the information in the array. For a description of the rules for creating an ACL from an array of
	/// <c>EXPLICIT_ACCESS</c> structures, see the SetEntriesInAcl function.
	/// </para>
	/// <para>
	/// If pListOfAccessEntries is <c>NULL</c>, the new security descriptor gets the DACL from pOldSD. In this case, if pOldSD is
	/// <c>NULL</c>, or if the DACL in pOldSD is <c>NULL</c>, the new DACL is <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="cCountOfAuditEntries">
	/// <para>The number of EXPLICIT_ACCESS structures in the pListOfAuditEntries array.</para>
	/// </param>
	/// <param name="pListOfAuditEntries">
	/// <para>
	/// A pointer to an array of EXPLICIT_ACCESS structures that describe audit control information for the SACL of the new security
	/// descriptor. The function creates the new SACL by merging the information in the array with the SACL in pOldSD, if any. If pOldSD
	/// is <c>NULL</c>, or the SACL in pOldSD is <c>NULL</c>, the function creates a new SACL based solely on the information in the array.
	/// </para>
	/// <para>
	/// If pListOfAuditEntries is <c>NULL</c>, the new security descriptor gets the SACL from pOldSD. In this case, if pOldSD is
	/// <c>NULL</c>, or the SACL in pOldSD is <c>NULL</c>, the new SACL is <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="pOldSD">
	/// <para>
	/// A pointer to an existing self-relative SECURITY_DESCRIPTOR structure and its associated security information. The function builds
	/// the new security descriptor by merging the specified owner, group, access control, and audit-control information with the
	/// information in this security descriptor. This parameter can be <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="pSizeNewSD">
	/// <para>A pointer to a variable that receives the size, in bytes, of the security descriptor.</para>
	/// </param>
	/// <param name="pNewSD">
	/// <para>
	/// A pointer to a variable that receives a pointer to the new security descriptor. The function allocates memory for the new
	/// security descriptor. You must call the LocalFree function to free the returned buffer.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns ERROR_SUCCESS.</para>
	/// <para>If the function fails, it returns a nonzero error code defined in WinError.h.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>BuildSecurityDescriptor</c> function is intended for trusted servers that implement or expose security on their own
	/// objects. The function uses self-relative security descriptors suitable for serializing into a stream and storing to disk, as a
	/// trusted server might require.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/aclapi/nf-aclapi-buildsecuritydescriptora DWORD BuildSecurityDescriptorA(
	// PTRUSTEE_A pOwner, PTRUSTEE_A pGroup, ULONG cCountOfAccessEntries, PEXPLICIT_ACCESS_A pListOfAccessEntries, ULONG
	// cCountOfAuditEntries, PEXPLICIT_ACCESS_A pListOfAuditEntries, PSECURITY_DESCRIPTOR pOldSD, PULONG pSizeNewSD, PSECURITY_DESCRIPTOR
	// *pNewSD );
	[DllImport(Lib.AdvApi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("aclapi.h", MSDNShortId = "becc1218-5bc3-4ab2-86f8-3ebd10e16966")]
	public static extern uint BuildSecurityDescriptor(in TRUSTEE pOwner, in TRUSTEE pGroup, [In, Optional] uint cCountOfAccessEntries,
		[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] EXPLICIT_ACCESS[]? pListOfAccessEntries, [In, Optional] uint cCountOfAuditEntries,
		[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] EXPLICIT_ACCESS[]? pListOfAuditEntries, [In, Optional] PSECURITY_DESCRIPTOR pOldSD,
		out uint pSizeNewSD, out SafePSECURITY_DESCRIPTOR pNewSD);

	/// <summary>
	/// <para>
	/// The <c>BuildSecurityDescriptor</c> function allocates and initializes a new security descriptor. This function can initialize the
	/// new security descriptor by merging specified security information with the information in an existing security descriptor. If you
	/// do not specify an existing security descriptor, the function initializes a new security descriptor based on the specified
	/// security information.
	/// </para>
	/// <para>
	/// The <c>BuildSecurityDescriptor</c> function creates a self-relative security descriptor. The self-relative format makes the
	/// security descriptor suitable for storing in a stream.
	/// </para>
	/// </summary>
	/// <param name="pOwner">
	/// <para>
	/// A pointer to a TRUSTEE structure that identifies the owner for the new security descriptor. If the structure uses the
	/// TRUSTEE_IS_NAME form, <c>BuildSecurityDescriptor</c> looks up the security identifier (SID) associated with the specified trustee name.
	/// </para>
	/// <para>
	/// If this parameter is <c>NULL</c>, the function uses the owner SID from the original security descriptor pointed to by pOldSD. If
	/// pOldSD is <c>NULL</c>, or if the owner SID in pOldSD is <c>NULL</c>, the owner SID is <c>NULL</c> in the new security descriptor.
	/// </para>
	/// </param>
	/// <param name="pGroup">
	/// <para>
	/// A pointer to a TRUSTEE structure that identifies the primary group SID for the new security descriptor. If the structure uses the
	/// TRUSTEE_IS_NAME form, <c>BuildSecurityDescriptor</c> looks up the SID associated with the specified trustee name.
	/// </para>
	/// <para>
	/// If this parameter is <c>NULL</c>, the function uses the group SID from the original security descriptor pointed to by pOldSD. If
	/// pOldSD is <c>NULL</c>, or if the group SID in pOldSD is <c>NULL</c>, the group SID is <c>NULL</c> in the new security descriptor.
	/// </para>
	/// </param>
	/// <param name="cCountOfAccessEntries">
	/// <para>The number of EXPLICIT_ACCESS structures in the pListOfAccessEntries array.</para>
	/// </param>
	/// <param name="pListOfAccessEntries">
	/// <para>
	/// A pointer to an array of EXPLICIT_ACCESS structures that describe access control information for the discretionary access control
	/// list (DACL) of the new security descriptor. The function creates the new DACL by merging the information in the array with the
	/// DACL in pOldSD, if any. If pOldSD is <c>NULL</c>, or if the DACL in pOldSD is <c>NULL</c>, the function creates a new DACL based
	/// solely on the information in the array. For a description of the rules for creating an ACL from an array of
	/// <c>EXPLICIT_ACCESS</c> structures, see the SetEntriesInAcl function.
	/// </para>
	/// <para>
	/// If pListOfAccessEntries is <c>NULL</c>, the new security descriptor gets the DACL from pOldSD. In this case, if pOldSD is
	/// <c>NULL</c>, or if the DACL in pOldSD is <c>NULL</c>, the new DACL is <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="cCountOfAuditEntries">
	/// <para>The number of EXPLICIT_ACCESS structures in the pListOfAuditEntries array.</para>
	/// </param>
	/// <param name="pListOfAuditEntries">
	/// <para>
	/// A pointer to an array of EXPLICIT_ACCESS structures that describe audit control information for the SACL of the new security
	/// descriptor. The function creates the new SACL by merging the information in the array with the SACL in pOldSD, if any. If pOldSD
	/// is <c>NULL</c>, or the SACL in pOldSD is <c>NULL</c>, the function creates a new SACL based solely on the information in the array.
	/// </para>
	/// <para>
	/// If pListOfAuditEntries is <c>NULL</c>, the new security descriptor gets the SACL from pOldSD. In this case, if pOldSD is
	/// <c>NULL</c>, or the SACL in pOldSD is <c>NULL</c>, the new SACL is <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="pOldSD">
	/// <para>
	/// A pointer to an existing self-relative SECURITY_DESCRIPTOR structure and its associated security information. The function builds
	/// the new security descriptor by merging the specified owner, group, access control, and audit-control information with the
	/// information in this security descriptor. This parameter can be <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="pSizeNewSD">
	/// <para>A pointer to a variable that receives the size, in bytes, of the security descriptor.</para>
	/// </param>
	/// <param name="pNewSD">
	/// <para>
	/// A pointer to a variable that receives a pointer to the new security descriptor. The function allocates memory for the new
	/// security descriptor. You must call the LocalFree function to free the returned buffer.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns ERROR_SUCCESS.</para>
	/// <para>If the function fails, it returns a nonzero error code defined in WinError.h.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>BuildSecurityDescriptor</c> function is intended for trusted servers that implement or expose security on their own
	/// objects. The function uses self-relative security descriptors suitable for serializing into a stream and storing to disk, as a
	/// trusted server might require.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/aclapi/nf-aclapi-buildsecuritydescriptora DWORD BuildSecurityDescriptorA(
	// PTRUSTEE_A pOwner, PTRUSTEE_A pGroup, ULONG cCountOfAccessEntries, PEXPLICIT_ACCESS_A pListOfAccessEntries, ULONG
	// cCountOfAuditEntries, PEXPLICIT_ACCESS_A pListOfAuditEntries, PSECURITY_DESCRIPTOR pOldSD, PULONG pSizeNewSD, PSECURITY_DESCRIPTOR
	// *pNewSD );
	[DllImport(Lib.AdvApi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("aclapi.h", MSDNShortId = "becc1218-5bc3-4ab2-86f8-3ebd10e16966")]
	public static extern uint BuildSecurityDescriptor([In, Optional] IntPtr pOwner, [In, Optional] IntPtr pGroup, [In, Optional] uint cCountOfAccessEntries,
		[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] EXPLICIT_ACCESS[]? pListOfAccessEntries, [In, Optional] uint cCountOfAuditEntries,
		[In, Optional, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] EXPLICIT_ACCESS[]? pListOfAuditEntries, [In, Optional] PSECURITY_DESCRIPTOR pOldSD,
		out uint pSizeNewSD, out SafePSECURITY_DESCRIPTOR pNewSD);

	/// <summary>
	/// <para>
	/// The <c>BuildTrusteeWithName</c> function initializes a TRUSTEE structure. The caller specifies the trustee name. The function
	/// sets other members of the structure to default values.
	/// </para>
	/// </summary>
	/// <param name="pTrustee">
	/// <para>
	/// A pointer to a TRUSTEE structure to initialize. The <c>BuildTrusteeWithName</c> function does not allocate any memory. If this
	/// parameter is <c>NULL</c> or a pointer that is not valid, the results are undefined.
	/// </para>
	/// </param>
	/// <param name="pName">
	/// <para>
	/// A pointer to a null-terminated string that contains the name of the trustee for the <c>ptstrName</c> member of the TRUSTEE
	/// structure. The <c>BuildTrusteeWithName</c> function sets the other members of the <c>TRUSTEE</c> structure as follows.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>pMultipleTrustee</term>
	/// <term>NULL</term>
	/// </item>
	/// <item>
	/// <term>MultipleTrusteeOperation</term>
	/// <term>NO_MULTIPLE_TRUSTEE</term>
	/// </item>
	/// <item>
	/// <term>TrusteeForm</term>
	/// <term>TRUSTEE_IS_NAME</term>
	/// </item>
	/// <item>
	/// <term>TrusteeType</term>
	/// <term>TRUSTEE_IS_UNKNOWN</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>This function does not return a value.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/aclapi/nf-aclapi-buildtrusteewithnamea void BuildTrusteeWithNameA( PTRUSTEE_A
	// pTrustee, LPSTR pName );
	[DllImport(Lib.AdvApi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("aclapi.h", MSDNShortId = "a66c23ac-8211-40fd-bfe8-ef9089bf3745")]
	public static extern void BuildTrusteeWithName(out TRUSTEE pTrustee, string pName);

	/// <summary>
	/// <para>
	/// The <c>BuildTrusteeWithObjectsAndName</c> function initializes a TRUSTEE structure with the object-specific access control entry
	/// (ACE) information and initializes the remaining members of the structure to default values. The caller also specifies the name of
	/// the trustee.
	/// </para>
	/// </summary>
	/// <param name="pTrustee">
	/// <para>
	/// A pointer to a TRUSTEE structure that will be initialized by this function. If the value of this parameter is <c>NULL</c> or a
	/// pointer that is not valid, the results are undefined.
	/// </para>
	/// </param>
	/// <param name="pObjName">
	/// <para>A pointer to an OBJECTS_AND_NAME structure that contains information about the trustee and the securable object.</para>
	/// </param>
	/// <param name="ObjectType">
	/// <para>A pointer to an SE_OBJECT_TYPE enumeration that contains information about the type of securable object.</para>
	/// </param>
	/// <param name="ObjectTypeName">
	/// <para>
	/// A pointer to a string that specifies the name that corresponds to the ObjectType GUID to be added to the TRUSTEE structure
	/// returned in the pTrustee parameter. This function determines the ObjectType GUID that corresponds to this name.
	/// </para>
	/// </param>
	/// <param name="InheritedObjectTypeName">
	/// <para>
	/// A pointer to a string that specifies the name that corresponds to the InheritedObjectType GUID to be added to the TRUSTEE
	/// structure returned in the pTrustee parameter. This function determines the InheritedObjectType GUID that corresponds to this name.
	/// </para>
	/// </param>
	/// <param name="Name">
	/// <para>A pointer to a string that specifies the name used to identify the trustee.</para>
	/// </param>
	/// <returns>
	/// <para>This function does not return a value.</para>
	/// </returns>
	/// <remarks>
	/// <para>This function does not allocate memory for the TRUSTEE and OBJECTS_AND_NAME structures.</para>
	/// <para>For more information about object-specific ACEs, see Object-specific ACEs.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/aclapi/nf-aclapi-buildtrusteewithobjectsandnamea void
	// BuildTrusteeWithObjectsAndNameA( PTRUSTEE_A pTrustee, POBJECTS_AND_NAME_A pObjName, SE_OBJECT_TYPE ObjectType, LPSTR
	// ObjectTypeName, LPSTR InheritedObjectTypeName, LPSTR Name );
	[DllImport(Lib.AdvApi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("aclapi.h", MSDNShortId = "62edadfe-0a7b-43ec-bd02-a63f928c7618")]
	public static extern void BuildTrusteeWithObjectsAndName(out TRUSTEE pTrustee, in OBJECTS_AND_NAME pObjName, SE_OBJECT_TYPE ObjectType, string ObjectTypeName, string InheritedObjectTypeName, string Name);

	/// <summary>
	/// <para>
	/// The <c>BuildTrusteeWithObjectsAndSid</c> function initializes a TRUSTEE structure with the object-specific access control entry
	/// (ACE) information and initializes the remaining members of the structure to default values. The caller also specifies the SID
	/// structure that represents the security identifier of the trustee.
	/// </para>
	/// </summary>
	/// <param name="pTrustee">
	/// <para>
	/// A pointer to a TRUSTEE structure to initialize. The <c>BuildTrusteeWithObjectsAndSid</c> function does not allocate any memory.
	/// If this parameter is <c>NULL</c> or a pointer that is not valid, the results are undefined.
	/// </para>
	/// </param>
	/// <param name="pObjSid">
	/// <para>A pointer to an OBJECTS_AND_SID structure that contains information about the trustee and the securable object.</para>
	/// </param>
	/// <param name="pObjectGuid">
	/// <para>A pointer to a GUID structure that describes the ObjectType GUID to be added to the TRUSTEE structure.</para>
	/// </param>
	/// <param name="pInheritedObjectGuid">
	/// <para>A pointer to a GUID structure that describes the InheritedObjectType GUID to be added to the TRUSTEE structure.</para>
	/// </param>
	/// <param name="pSid">
	/// <para>A pointer to a SID structure that identifies the trustee.</para>
	/// </param>
	/// <returns>
	/// <para>This function does not return a value.</para>
	/// </returns>
	/// <remarks>
	/// <para>This function does not allocate memory for the TRUSTEE and OBJECTS_AND_SID structures.</para>
	/// <para>For more information about object-specific ACEs, see Object-specific ACEs.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/aclapi/nf-aclapi-buildtrusteewithobjectsandsidw void
	// BuildTrusteeWithObjectsAndSidW( PTRUSTEE_W pTrustee, POBJECTS_AND_SID pObjSid, GUID *pObjectGuid, GUID *pInheritedObjectGuid, PSID
	// pSid );
	[DllImport(Lib.AdvApi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("aclapi.h", MSDNShortId = "e940a87f-013e-458c-bdc1-9e81c7d905e0")]
	public static extern void BuildTrusteeWithObjectsAndSid(out TRUSTEE pTrustee, in OBJECTS_AND_SID pObjSid, in Guid pObjectGuid, in Guid pInheritedObjectGuid, PSID pSid);

	/// <summary>
	/// <para>
	/// The <c>BuildTrusteeWithSid</c> function initializes a TRUSTEE structure. The caller specifies the security identifier (SID) of
	/// the trustee. The function sets other members of the structure to default values and does not look up the name associated with the SID.
	/// </para>
	/// </summary>
	/// <param name="pTrustee">
	/// <para>
	/// A pointer to a TRUSTEE structure to initialize. The <c>BuildTrusteeWithSid</c> function does not allocate any memory. If this
	/// parameter is <c>NULL</c> or a pointer that is not valid, the results are undefined.
	/// </para>
	/// </param>
	/// <param name="pSid">
	/// <para>
	/// A pointer to a SID structure that identifies the trustee. The <c>BuildTrusteeWithSid</c> function assigns this pointer to the
	/// <c>ptstrName</c> member of the TRUSTEE structure. The function sets the other members of the <c>TRUSTEE</c> structure as follows.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>pMultipleTrustee</term>
	/// <term>NULL</term>
	/// </item>
	/// <item>
	/// <term>MultipleTrusteeOperation</term>
	/// <term>NO_MULTIPLE_TRUSTEE</term>
	/// </item>
	/// <item>
	/// <term>TrusteeForm</term>
	/// <term>TRUSTEE_IS_SID</term>
	/// </item>
	/// <item>
	/// <term>TrusteeType</term>
	/// <term>TRUSTEE_IS_UNKNOWN</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>This function does not return a value.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/aclapi/nf-aclapi-buildtrusteewithsidw void BuildTrusteeWithSidW( PTRUSTEE_W
	// pTrustee, PSID pSid );
	[DllImport(Lib.AdvApi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("aclapi.h", MSDNShortId = "3745fbf2-911a-4cb6-81a8-6256c742c700")]
	public static extern void BuildTrusteeWithSid(out TRUSTEE pTrustee, PSID pSid);

	/// <summary>The FreeInheritedFromArray function frees memory allocated by the GetInheritanceSource function.</summary>
	/// <param name="pInheritArray">A pointer to the array of INHERITED_FROM structures returned by GetInheritanceSource.</param>
	/// <param name="AceCnt">Number of entries in pInheritArray.</param>
	/// <param name="pfnArray">Unused. Set to NULL.</param>
	/// <returns>If the function succeeds, the return value is ERROR_SUCCESS. If the function fails, it returns a nonzero error code.</returns>
	[DllImport(Lib.AdvApi32, ExactSpelling = true)]
	[PInvokeData("Aclapi.h", MSDNShortId = "aa446630")]
	public static extern Win32Error FreeInheritedFromArray(IntPtr pInheritArray, ushort AceCnt, IntPtr pfnArray);

	/// <summary>
	/// <para>
	/// The <c>GetAuditedPermissionsFromAcl</c> function retrieves the audited access rights for a specified trustee. The audited rights
	/// are based on the access control entries (ACEs) of a specified access control list (ACL). The audited access rights indicate the
	/// types of access attempts that cause the system to generate an audit record in the system event log. The audited rights include
	/// those that the ACL specifies for the trustee or for any groups of which the trustee is a member. In determining the audited
	/// rights, the function does not consider the security privileges held by the trustee.
	/// </para>
	/// </summary>
	/// <param name="pacl">
	/// <para>A pointer to an ACL structure from which to get the trustee's audited access rights.</para>
	/// </param>
	/// <param name="pTrustee">
	/// <para>
	/// A pointer to a TRUSTEE structure that identifies the trustee. A trustee can be a user, group, or program (such as a Windows
	/// service). You can use a name or a security identifier (SID) to identify a trustee. For information about SID structures, see SID.
	/// </para>
	/// </param>
	/// <param name="pSuccessfulAuditedRights">
	/// <para>
	/// A pointer to an ACCESS_MASK structure that receives the successful audit mask for rights audited for the trustee specified by the
	/// pTrustee parameter. The system generates an audit record when the trustee successfully uses any of these access rights.
	/// </para>
	/// </param>
	/// <param name="pFailedAuditRights">
	/// <para>
	/// A pointer to an ACCESS_MASK structure that receives the failed audit mask for rights audited for the trustee specified by the
	/// pTrustee parameter. The system generates an audit record when the trustee fails in an attempt to use any of these rights.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns ERROR_SUCCESS.</para>
	/// <para>If the function fails, it returns a nonzero error code defined in WinError.h.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>GetAuditedPermissionsFromAcl</c> function checks all system-audit ACEs in the ACL to determine the audited rights for the
	/// trustee. For all ACEs that specify audited rights for a group, <c>GetAuditedPermissionsFromAcl</c> enumerates the members of the
	/// group to determine whether the trustee is a member. The function returns an error if it cannot enumerate the members of a group.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/aclapi/nf-aclapi-getauditedpermissionsfromacla DWORD
	// GetAuditedPermissionsFromAclA( PACL pacl, PTRUSTEE_A pTrustee, PACCESS_MASK pSuccessfulAuditedRights, PACCESS_MASK
	// pFailedAuditRights );
	[DllImport(Lib.AdvApi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("aclapi.h", MSDNShortId = "4381fe12-5fb3-4f9c-8daa-261cb1a466ec")]
	public static extern Win32Error GetAuditedPermissionsFromAcl(PACL pacl, in TRUSTEE pTrustee, out ACCESS_MASK pSuccessfulAuditedRights, out ACCESS_MASK pFailedAuditRights);

	/// <summary>
	/// The GetEffectiveRightsFromAcl function retrieves the effective access rights that an ACL structure grants to a specified trustee.
	/// The trustee's effective access rights are the access rights that the ACL grants to the trustee or to any groups of which the
	/// trustee is a member.
	/// </summary>
	/// <param name="pacl">A pointer to an ACL structure from which to get the trustee's effective access rights.</param>
	/// <param name="pTrustee">
	/// A pointer to a TRUSTEE structure that identifies the trustee. A trustee can be a user, group, or program (such as a Windows
	/// service). You can use a name or a security identifier (SID) to identify a trustee.
	/// </param>
	/// <param name="pAccessRights">A pointer to an ACCESS_MASK variable that receives the effective access rights of the trustee.</param>
	[DllImport(Lib.AdvApi32, CharSet = CharSet.Auto)]
	[PInvokeData("Aclapi.h", MSDNShortId = "aa446637")]
	public static extern Win32Error GetEffectiveRightsFromAcl(PACL pacl, in TRUSTEE pTrustee, out ACCESS_MASK pAccessRights);

	/// <summary>
	/// <para>
	/// The <c>GetExplicitEntriesFromAcl</c> function retrieves an array of structures that describe the access control entries (ACEs) in
	/// an access control list (ACL).
	/// </para>
	/// </summary>
	/// <param name="pacl">
	/// <para>A pointer to an ACL structure from which to get ACE information.</para>
	/// </param>
	/// <param name="pcCountOfExplicitEntries">
	/// <para>
	/// A pointer to a variable that receives the number of EXPLICIT_ACCESS structures returned in the pListOfExplicitEntries array.
	/// </para>
	/// </param>
	/// <param name="pListOfExplicitEntries">
	/// <para>
	/// A pointer to a variable that receives a pointer to an array of EXPLICIT_ACCESS structures that describe the ACEs in the ACL. If
	/// the function succeeds, you must call the LocalFree function to free the returned buffer.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns ERROR_SUCCESS.</para>
	/// <para>If the function fails, it returns a nonzero error code defined in WinError.h.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Each entry in the array of EXPLICIT_ACCESS structures describes access control information from an ACE for a trustee. A trustee
	/// can be a user, group, or program (such as a Windows service).
	/// </para>
	/// <para>
	/// Each EXPLICIT_ACCESS structure specifies a set of access rights and an access mode flag that indicates whether the ACE allows,
	/// denies, or audits the specified rights.
	/// </para>
	/// <para>
	/// For a discretionary access control list (DACL), the access mode flag can be either GRANT_ACCESS or DENY_ACCESS. For information
	/// about these values, see ACCESS_MODE.
	/// </para>
	/// <para>
	/// For a system access control list (SACL), the access mode flag can be SET_AUDIT_ACCESS, SET_AUDIT_FAILURE, or both. For
	/// information about these values, see ACCESS_MODE.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/aclapi/nf-aclapi-getexplicitentriesfromacla DWORD GetExplicitEntriesFromAclA(
	// PACL pacl, PULONG pcCountOfExplicitEntries, PEXPLICIT_ACCESS_A *pListOfExplicitEntries );
	[DllImport(Lib.AdvApi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("aclapi.h", MSDNShortId = "186aa6aa-efc3-4f8a-acad-e257da3dac0b")]
	public static extern Win32Error GetExplicitEntriesFromAcl(PACL pacl, out uint pcCountOfExplicitEntries, out SafeLocalHandle pListOfExplicitEntries);

	/// <summary>
	/// The <c>GetExplicitEntriesFromAcl</c> function retrieves an array of structures that describe the access control entries (ACEs) in an
	/// access control list (ACL).
	/// </summary>
	/// <param name="pacl">A pointer to an ACL structure from which to get ACE information.</param>
	/// <param name="pListOfExplicitEntries">
	/// A pointer to a variable that receives a pointer to an array of EXPLICIT_ACCESS structures that describe the ACEs in the ACL. If the
	/// function succeeds, you must call the LocalFree function to free the returned buffer.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns ERROR_SUCCESS.</para>
	/// <para>If the function fails, it returns a nonzero error code defined in WinError.h.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Each entry in the array of EXPLICIT_ACCESS structures describes access control information from an ACE for a trustee. A trustee can
	/// be a user, group, or program (such as a Windows service).
	/// </para>
	/// <para>
	/// Each EXPLICIT_ACCESS structure specifies a set of access rights and an access mode flag that indicates whether the ACE allows,
	/// denies, or audits the specified rights.
	/// </para>
	/// <para>
	/// For a discretionary access control list (DACL), the access mode flag can be either GRANT_ACCESS or DENY_ACCESS. For information about
	/// these values, see ACCESS_MODE.
	/// </para>
	/// <para>
	/// For a system access control list (SACL), the access mode flag can be SET_AUDIT_ACCESS, SET_AUDIT_FAILURE, or both. For information
	/// about these values, see ACCESS_MODE.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/aclapi/nf-aclapi-getexplicitentriesfromacla DWORD GetExplicitEntriesFromAclA(
	// PACL pacl, PULONG pcCountOfExplicitEntries, PEXPLICIT_ACCESS_A *pListOfExplicitEntries );
	[PInvokeData("aclapi.h", MSDNShortId = "186aa6aa-efc3-4f8a-acad-e257da3dac0b")]
	public static Win32Error GetExplicitEntriesFromAcl(PACL pacl, out EXPLICIT_ACCESS[]? pListOfExplicitEntries)
	{
		var err = GetExplicitEntriesFromAcl(pacl, out var c, out var m);
		pListOfExplicitEntries = err.Succeeded ? m.ToArray<EXPLICIT_ACCESS>((int)c) : null;
		m.Dispose();
		return err;
	}

	/// <summary>
	/// The GetInheritanceSource function returns information about the source of inherited access control entries (ACEs) in an access
	/// control list (ACL).
	/// </summary>
	/// <param name="pObjectName">A pointer to the name of the object that uses the ACL to be checked.</param>
	/// <param name="ObjectType">
	/// The type of object indicated by pObjectName. The possible values are SE_FILE_OBJECT, SE_REGISTRY_KEY, SE_DS_OBJECT, and SE_DS_OBJECT_ALL.
	/// </param>
	/// <param name="SecurityInfo">The type of ACL used with the object. The possible values are DACL_SECURITY_INFORMATION or SACL_SECURITY_INFORMATION.</param>
	/// <param name="Container">
	/// TRUE if the object is a container object or FALSE if the object is a leaf object. Note that the only leaf object is SE_FILE_OBJECT.
	/// </param>
	/// <param name="pObjectClassGuids">
	/// Optional list of GUIDs that identify the object types or names associated with pObjectName. This may be NULL if the object
	/// manager only supports one object class or has no GUID associated with the object class.
	/// </param>
	/// <param name="GuidCount">Number of GUIDs pointed to by pObjectClassGuids.</param>
	/// <param name="pAcl">The ACL for the object.</param>
	/// <param name="pfnArray">Reserved. Set this parameter to NULL.</param>
	/// <param name="pGenericMapping">The mapping of generic rights to specific rights for the object.</param>
	/// <param name="pInheritArray">
	/// A pointer to an array of INHERITED_FROM structures that the GetInheritanceSource function fills with the inheritance information.
	/// The caller must allocate enough memory for an entry for each ACE in the ACL.
	/// </param>
	/// <returns>
	/// If the function succeeds, the function returns ERROR_SUCCESS. If the function fails, it returns a nonzero error code defined in WinError.h.
	/// </returns>
	[DllImport(Lib.AdvApi32, CharSet = CharSet.Auto)]
	[PInvokeData("Aclapi.h", MSDNShortId = "aa446640")]
	public static extern Win32Error GetInheritanceSource([MarshalAs(UnmanagedType.LPTStr)] string pObjectName, SE_OBJECT_TYPE ObjectType,
		SECURITY_INFORMATION SecurityInfo, [MarshalAs(UnmanagedType.Bool)] bool Container,
		[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5, ArraySubType = UnmanagedType.LPStruct), Optional] Guid[]? pObjectClassGuids,
		uint GuidCount, [In] PACL pAcl, [In, Optional] IntPtr pfnArray, in GENERIC_MAPPING pGenericMapping, SafeInheritedFromArray pInheritArray);

	/// <summary>
	/// The GetInheritanceSource function returns information about the source of inherited access control entries (ACEs) in an access
	/// control list (ACL).
	/// </summary>
	/// <param name="objectName">A pointer to the name of the object that uses the ACL to be checked.</param>
	/// <param name="objectType">
	/// The type of object indicated by pObjectName. The possible values are SE_FILE_OBJECT, SE_REGISTRY_KEY, SE_DS_OBJECT, and SE_DS_OBJECT_ALL.
	/// </param>
	/// <param name="securityInfo">The type of ACL used with the object. The possible values are DACL_SECURITY_INFORMATION or SACL_SECURITY_INFORMATION.</param>
	/// <param name="container">
	/// TRUE if the object is a container object or FALSE if the object is a leaf object. Note that the only leaf object is SE_FILE_OBJECT.
	/// </param>
	/// <param name="pAcl">The ACL for the object.</param>
	/// <param name="pGenericMapping">The mapping of generic rights to specific rights for the object.</param>
	/// <returns>An enumeration of INHERITED_FROM structures with the inheritance information.</returns>
	public static IEnumerable<INHERITED_FROM> GetInheritanceSource(string objectName, System.Security.AccessControl.ResourceType objectType,
		SECURITY_INFORMATION securityInfo, bool container, PACL pAcl, ref GENERIC_MAPPING pGenericMapping)
	{
		using SafeInheritedFromArray pInherit = new((ushort)pAcl.AceCount());
		GetInheritanceSource(objectName, (SE_OBJECT_TYPE)objectType, securityInfo, container, null, 0, pAcl, default, pGenericMapping, pInherit).ThrowIfFailed();
		return pInherit.Results;
	}

	/// <summary>The GetNamedSecurityInfo function retrieves a copy of the security descriptor for an object specified by name.</summary>
	/// <param name="pObjectName">
	/// A pointer to a null-terminated string that specifies the name of the object from which to retrieve security information. For
	/// descriptions of the string formats for the different object types, see SE_OBJECT_TYPE.
	/// </param>
	/// <param name="ObjectType">
	/// Specifies a value from the SE_OBJECT_TYPE enumeration that indicates the type of object named by the pObjectName parameter.
	/// </param>
	/// <param name="SecurityInfo">
	/// A set of bit flags that indicate the type of security information to retrieve. This parameter can be a combination of the
	/// SECURITY_INFORMATION bit flags.
	/// </param>
	/// <param name="ppsidOwner">
	/// A pointer to a variable that receives a pointer to the owner SID in the security descriptor returned in ppSecurityDescriptor or
	/// NULL if the security descriptor has no owner SID. The returned pointer is valid only if you set the OWNER_SECURITY_INFORMATION
	/// flag. Also, this parameter can be NULL if you do not need the owner SID.
	/// </param>
	/// <param name="ppsidGroup">
	/// A pointer to a variable that receives a pointer to the primary group SID in the returned security descriptor or NULL if the
	/// security descriptor has no group SID. The returned pointer is valid only if you set the GROUP_SECURITY_INFORMATION flag. Also,
	/// this parameter can be NULL if you do not need the group SID.
	/// </param>
	/// <param name="ppDacl">
	/// A pointer to a variable that receives a pointer to the DACL in the returned security descriptor or NULL if the security
	/// descriptor has no DACL. The returned pointer is valid only if you set the DACL_SECURITY_INFORMATION flag. Also, this parameter
	/// can be NULL if you do not need the DACL.
	/// </param>
	/// <param name="ppSacl">
	/// A pointer to a variable that receives a pointer to the SACL in the returned security descriptor or NULL if the security
	/// descriptor has no SACL. The returned pointer is valid only if you set the SACL_SECURITY_INFORMATION flag. Also, this parameter
	/// can be NULL if you do not need the SACL.
	/// </param>
	/// <param name="ppSecurityDescriptor">
	/// A pointer to a variable that receives a pointer to the security descriptor of the object. When you have finished using the
	/// pointer, free the returned buffer by calling the LocalFree function.
	/// <para>This parameter is required if any one of the ppsidOwner, ppsidGroup, ppDacl, or ppSacl parameters is not NULL.</para>
	/// </param>
	/// <returns>
	/// If the function succeeds, the return value is ERROR_SUCCESS. If the function fails, the return value is a nonzero error code
	/// defined in WinError.h.
	/// </returns>
	[DllImport(Lib.AdvApi32, CharSet = CharSet.Auto, SetLastError = true)]
	[PInvokeData("Aclapi.h", MSDNShortId = "aa446645")]
	public static extern Win32Error GetNamedSecurityInfo(string pObjectName, SE_OBJECT_TYPE ObjectType, SECURITY_INFORMATION SecurityInfo, out PSID ppsidOwner,
		out PSID ppsidGroup, out PACL ppDacl, out PACL ppSacl, out SafePSECURITY_DESCRIPTOR ppSecurityDescriptor);

	/// <summary>
	/// <para>The <c>GetSecurityInfo</c> function retrieves a copy of the security descriptor for an object specified by a handle.</para>
	/// </summary>
	/// <param name="handle">
	/// <para>A handle to the object from which to retrieve security information.</para>
	/// </param>
	/// <param name="ObjectType">
	/// <para>SE_OBJECT_TYPE enumeration value that indicates the type of object.</para>
	/// </param>
	/// <param name="SecurityInfo">
	/// <para>
	/// A set of bit flags that indicate the type of security information to retrieve. This parameter can be a combination of the
	/// SECURITY_INFORMATION bit flags.
	/// </para>
	/// </param>
	/// <param name="ppsidOwner">
	/// <para>
	/// A pointer to a variable that receives a pointer to the owner SID in the security descriptor returned in ppSecurityDescriptor. The
	/// returned pointer is valid only if you set the OWNER_SECURITY_INFORMATION flag. This parameter can be <c>NULL</c> if you do not
	/// need the owner SID.
	/// </para>
	/// </param>
	/// <param name="ppsidGroup">
	/// <para>
	/// A pointer to a variable that receives a pointer to the primary group SID in the returned security descriptor. The returned
	/// pointer is valid only if you set the GROUP_SECURITY_INFORMATION flag. This parameter can be <c>NULL</c> if you do not need the
	/// group SID.
	/// </para>
	/// </param>
	/// <param name="ppDacl">
	/// <para>
	/// A pointer to a variable that receives a pointer to the DACL in the returned security descriptor. The returned pointer is valid
	/// only if you set the DACL_SECURITY_INFORMATION flag. This parameter can be <c>NULL</c> if you do not need the DACL.
	/// </para>
	/// </param>
	/// <param name="ppSacl">
	/// <para>
	/// A pointer to a variable that receives a pointer to the SACL in the returned security descriptor. The returned pointer is valid
	/// only if you set the SACL_SECURITY_INFORMATION flag. This parameter can be <c>NULL</c> if you do not need the SACL.
	/// </para>
	/// </param>
	/// <param name="ppSecurityDescriptor">
	/// <para>
	/// A pointer to a variable that receives a pointer to the security descriptor of the object. When you have finished using the
	/// pointer, free the returned buffer by calling the LocalFree function.
	/// </para>
	/// <para>This parameter is required if any one of the ppsidOwner, ppsidGroup, ppDacl, or ppSacl parameters is not <c>NULL</c>.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is ERROR_SUCCESS.</para>
	/// <para>If the function fails, the return value is a nonzero error code defined in WinError.h.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If the ppsidOwner, ppsidGroup, ppDacl, and ppSacl parameters are non- <c>NULL</c>, and the SecurityInfo parameter specifies that
	/// they be retrieved from the object, those parameters will point to the corresponding parameters in the security descriptor
	/// returned in ppSecurityDescriptor.
	/// </para>
	/// <para>
	/// To read the owner, group, or DACL from the object's security descriptor, the calling process must have been granted READ_CONTROL
	/// access when the handle was opened. To get READ_CONTROL access, the caller must be the owner of the object or the object's DACL
	/// must grant the access.
	/// </para>
	/// <para>
	/// To read the SACL from the security descriptor, the calling process must have been granted ACCESS_SYSTEM_SECURITY access when the
	/// handle was opened. The proper way to get this access is to enable the SE_SECURITY_NAME privilege in the caller's current token,
	/// open the handle for ACCESS_SYSTEM_SECURITY access, and then disable the privilege. For information about the security
	/// implications of enabling privileges, see Running with Special Privileges.
	/// </para>
	/// <para>You can use the <c>GetSecurityInfo</c> function with the following types of objects:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>Local or remote files or directories on an NTFS file system</term>
	/// </item>
	/// <item>
	/// <term>Named pipes</term>
	/// </item>
	/// <item>
	/// <term>Local or remote printers</term>
	/// </item>
	/// <item>
	/// <term>Local or remote Windows services</term>
	/// </item>
	/// <item>
	/// <term>Network shares</term>
	/// </item>
	/// <item>
	/// <term>Registry keys</term>
	/// </item>
	/// <item>
	/// <term>Semaphores, events, mutexes, and waitable timers</term>
	/// </item>
	/// <item>
	/// <term>Processes, threads, jobs, and file-mapping objects</term>
	/// </item>
	/// <item>
	/// <term>Interactive service window stations and desktops</term>
	/// </item>
	/// <item>
	/// <term>Directory service objects</term>
	/// </item>
	/// </list>
	/// <para>
	/// This function does not handle race conditions. If your thread calls this function at the approximate time that another thread
	/// changes the object's security descriptor, then this function could fail.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example that uses this function, see Finding the Owner of a File Object.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/aclapi/nf-aclapi-getsecurityinfo DWORD GetSecurityInfo( HANDLE handle,
	// SE_OBJECT_TYPE ObjectType, SECURITY_INFORMATION SecurityInfo, PSID *ppsidOwner, PSID *ppsidGroup, PACL *ppDacl, PACL *ppSacl,
	// PSECURITY_DESCRIPTOR *ppSecurityDescriptor );
	[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("aclapi.h", MSDNShortId = "64767a6b-cd79-4e02-881a-706a078ff446")]
	public static extern Win32Error GetSecurityInfo(IntPtr handle, SE_OBJECT_TYPE ObjectType, SECURITY_INFORMATION SecurityInfo, out PSID ppsidOwner, out PSID ppsidGroup,
		out PACL ppDacl, out PACL ppSacl, out SafePSECURITY_DESCRIPTOR ppSecurityDescriptor);

	/// <summary>
	/// <para>
	/// The <c>GetTrusteeForm</c> function retrieves the trustee name from the specified TRUSTEE structure. This value indicates whether
	/// the structure uses a name string or a security identifier (SID) to identify the trustee.
	/// </para>
	/// </summary>
	/// <param name="pTrustee">
	/// <para>A pointer to a TRUSTEE structure.</para>
	/// </param>
	/// <returns>
	/// <para>The return value is one of the constants from the TRUSTEE_FORM enumeration.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/aclapi/nf-aclapi-gettrusteeforma TRUSTEE_FORM GetTrusteeFormA( PTRUSTEE_A
	// pTrustee );
	[DllImport(Lib.AdvApi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("aclapi.h", MSDNShortId = "e5e450b8-0b7b-4324-b453-5c020e74b1ee")]
	public static extern TRUSTEE_FORM GetTrusteeForm(in TRUSTEE pTrustee);

	/// <summary>
	/// <para>The <c>GetTrusteeName</c> function retrieves the trustee name from the specified TRUSTEE structure.</para>
	/// </summary>
	/// <param name="pTrustee">
	/// <para>A pointer to a TRUSTEE structure.</para>
	/// </param>
	/// <returns>
	/// <para>
	/// If the <c>TrusteeForm</c> member of the TRUSTEE structure is TRUSTEE_IS_NAME, the return value is the pointer assigned to the
	/// <c>ptstrName</c> member of the structure.
	/// </para>
	/// <para>
	/// If the <c>TrusteeForm</c> member is TRUSTEE_IS_SID, the return value is <c>NULL</c>. The function does not look up the name
	/// associated with a security identifier (SID).
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>The <c>GetTrusteeName</c> function does not allocate any memory.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/aclapi/nf-aclapi-gettrusteenamea LPSTR GetTrusteeNameA( PTRUSTEE_A pTrustee );
	[DllImport(Lib.AdvApi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("aclapi.h", MSDNShortId = "9d3ce528-fb28-4e2e-bf7f-7d84c697fcb6")]
	public static extern StrPtrAuto GetTrusteeName(in TRUSTEE pTrustee);

	/// <summary>
	/// <para>
	/// The <c>GetTrusteeType</c> function retrieves the trustee type from the specified TRUSTEE structure. This value indicates whether
	/// the trustee is a user, a group, or the trustee type is unknown.
	/// </para>
	/// </summary>
	/// <param name="pTrustee">
	/// <para>A pointer to a TRUSTEE structure.</para>
	/// </param>
	/// <returns>
	/// <para>The return value is one of the constants from the TRUSTEE_TYPE enumeration.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/aclapi/nf-aclapi-gettrusteetypea TRUSTEE_TYPE GetTrusteeTypeA( PTRUSTEE_A
	// pTrustee );
	[DllImport(Lib.AdvApi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("aclapi.h", MSDNShortId = "19777929-43cf-45ea-8283-e42bf9ce8d7a")]
	public static extern TRUSTEE_TYPE GetTrusteeType(in TRUSTEE pTrustee);

	/// <summary>
	/// <para>The <c>LookupSecurityDescriptorParts</c> function retrieves security information from a self-relative security descriptor.</para>
	/// </summary>
	/// <param name="ppOwner">
	/// <para>
	/// A pointer to a variable that receives a pointer to a TRUSTEE structure. The function looks up the name associated with the owner
	/// security identifier (SID) in the pSD security descriptor, and returns a pointer to the name in the <c>ptstrName</c> member of the
	/// <c>TRUSTEE</c> structure. The function sets the <c>TrusteeForm</c> member to TRUSTEE_IS_NAME.
	/// </para>
	/// <para>This parameter can be <c>NULL</c> if you are not interested in the name of the owner.</para>
	/// </param>
	/// <param name="ppGroup">
	/// <para>
	/// A pointer to a variable that receives a pointer to a TRUSTEE structure. The function looks up the name associated with the
	/// primary group SID of the security descriptor, and returns a pointer to the name in the <c>ptstrName</c> member of the
	/// <c>TRUSTEE</c> structure. The function sets the <c>TrusteeForm</c> member to TRUSTEE_IS_NAME.
	/// </para>
	/// <para>This parameter can be <c>NULL</c> if you are not interested in the name of the group.</para>
	/// </param>
	/// <param name="pcCountOfAccessEntries">
	/// <para>
	/// A pointer to a <c>ULONG</c> that receives the number of EXPLICIT_ACCESS structures returned in the pListOfAccessEntries array.
	/// This parameter can be <c>NULL</c> only if the pListOfAccessEntries parameter is also <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="ppListOfAccessEntries">
	/// <para>
	/// A pointer to a variable that receives a pointer to an array of EXPLICIT_ACCESS structures that describe the access control
	/// entries (ACEs) in the discretionary access control list (DACL) of the security descriptor. The TRUSTEE structure in these
	/// <c>EXPLICIT_ACCESS</c> structures use the TRUSTEE_IS_NAME form. For a description of how an array of <c>EXPLICIT_ACCESS</c>
	/// structures describes the ACEs in an access control list (ACL), see the GetExplicitEntriesFromAcl function. If this parameter is
	/// <c>NULL</c>, the cCountOfAccessEntries parameter must also be <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="pcCountOfAuditEntries">
	/// <para>
	/// A pointer to a <c>ULONG</c> that receives the number of EXPLICIT_ACCESS structures returned in the pListOfAuditEntries array.
	/// This parameter can be <c>NULL</c> only if the pListOfAuditEntries parameter is also <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="ppListOfAuditEntries">
	/// <para>
	/// A pointer to a variable that receives a pointer to an array of EXPLICIT_ACCESS structures that describe the ACEs in the system
	/// access control list (SACL) of the security descriptor. The TRUSTEE structure in these <c>EXPLICIT_ACCESS</c> structures uses the
	/// TRUSTEE_IS_NAME form. If this parameter is <c>NULL</c>, the cCountOfAuditEntries parameter must also be <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="pSD">
	/// <para>A pointer to an existing self-relative security descriptor from which the function retrieves security information.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns ERROR_SUCCESS.</para>
	/// <para>If the function fails, it returns a nonzero error code defined in WinError.h.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>LookupSecurityDescriptorParts</c> function retrieves the names of the owner and primary group of the security descriptor.
	/// This function also returns descriptions of the ACEs in the DACL and audit-control entries in the SACL of the security descriptor.
	/// </para>
	/// <para>
	/// The parameters other than pSD can be <c>NULL</c> if you are not interested in the information. If you do not want information
	/// about the DACL, both pListOfAccessEntries and cCountOfAuditEntries must be <c>NULL</c>. If you do not want information about the
	/// SACL, both pListOfAuditEntries and cCountOfAuditEntries must be <c>NULL</c>. Similarly, if you do want DACL or SACL information,
	/// both of the corresponding parameters must not be <c>NULL</c>.
	/// </para>
	/// <para>
	/// When you have finished using any of the buffers returned by the pOwner, pGroup, pListOfAccessEntries, or pListOfAuditEntries
	/// parameters, free them by calling the LocalFree function.
	/// </para>
	/// <para>
	/// The <c>LookupSecurityDescriptorParts</c> function is intended for trusted servers that implement or expose security on their own
	/// objects. The function works with a self-relative security descriptor suitable for serializing into a stream and storing to disk,
	/// as a trusted server might require.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/aclapi/nf-aclapi-lookupsecuritydescriptorpartsa DWORD
	// LookupSecurityDescriptorPartsA( PTRUSTEE_A *ppOwner, PTRUSTEE_A *ppGroup, PULONG pcCountOfAccessEntries, PEXPLICIT_ACCESS_A
	// *ppListOfAccessEntries, PULONG pcCountOfAuditEntries, PEXPLICIT_ACCESS_A *ppListOfAuditEntries, PSECURITY_DESCRIPTOR pSD );
	[DllImport(Lib.AdvApi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("aclapi.h", MSDNShortId = "68c3f56b-6c48-4f4b-bd38-9f4e346c663b")]
	public static extern Win32Error LookupSecurityDescriptorParts(out SafeLocalHandle ppOwner, out SafeLocalHandle ppGroup, out uint pcCountOfAccessEntries, out SafeLocalHandle ppListOfAccessEntries,
		out uint pcCountOfAuditEntries, out SafeLocalHandle ppListOfAuditEntries, PSECURITY_DESCRIPTOR pSD);

	/// <summary>
	/// <para>
	/// The <c>SetEntriesInAcl</c> function creates a new access control list (ACL) by merging new access control or audit control
	/// information into an existing ACL structure.
	/// </para>
	/// </summary>
	/// <param name="cCountOfExplicitEntries">
	/// <para>The number of EXPLICIT_ACCESS structures in the pListOfExplicitEntries array.</para>
	/// </param>
	/// <param name="pListOfExplicitEntries">
	/// <para>
	/// A pointer to an array of EXPLICIT_ACCESS structures that describe the access control information to merge into the existing ACL.
	/// </para>
	/// </param>
	/// <param name="OldAcl">
	/// <para>
	/// A pointer to the existing ACL. This parameter can be <c>NULL</c>, in which case, the function creates a new ACL based on the
	/// EXPLICIT_ACCESS entries.
	/// </para>
	/// </param>
	/// <param name="NewAcl">
	/// <para>
	/// A pointer to a variable that receives a pointer to the new ACL. If the function succeeds, you must call the LocalFree function to
	/// free the returned buffer.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns ERROR_SUCCESS.</para>
	/// <para>If the function fails, it returns a nonzero error code defined in WinError.h.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Each entry in the array of EXPLICIT_ACCESS structures specifies access control or audit control information for a specified
	/// trustee. A trustee can be a user, group, or other security identifier (SID) value, such as a logon identifier or logon type (for
	/// instance, a Windows service or batch job). You can use a name or a SID to identify a trustee.
	/// </para>
	/// <para>
	/// You can use the <c>SetEntriesInAcl</c> function to modify the list of access control entries (ACEs) in a discretionary access
	/// control list (DACL) or a system access control list (SACL). Note that <c>SetEntriesInAcl</c> does not prevent you from mixing
	/// access control and audit control information in the same ACL; however, the resulting ACL will contain meaningless entries.
	/// </para>
	/// <para>
	/// For a DACL, the <c>grfAccessMode</c> member of the EXPLICIT_ACCESS structure specifies whether to allow, deny, or revoke access
	/// rights for the trustee. This member can specify one of the following values:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>GRANT_ACCESS</term>
	/// </item>
	/// <item>
	/// <term>SET_ACCESS</term>
	/// </item>
	/// <item>
	/// <term>DENY_ACCESS</term>
	/// </item>
	/// <item>
	/// <term>REVOKE_ACCESS</term>
	/// </item>
	/// </list>
	/// <para>For information about these values, see ACCESS_MODE.</para>
	/// <para>
	/// The <c>SetEntriesInAcl</c> function places any new access-denied ACEs at the beginning of the list of ACEs for the new ACL. This
	/// function places any new access-allowed ACEs just before any existing access-allowed ACEs.
	/// </para>
	/// <para>For a SACL, the <c>grfAccessMode</c> member of the EXPLICIT_ACCESS structure can specify the following values:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>REVOKE_ACCESS</term>
	/// </item>
	/// <item>
	/// <term>SET_AUDIT_FAILURE</term>
	/// </item>
	/// <item>
	/// <term>SET_AUDIT_SUCCESS</term>
	/// </item>
	/// </list>
	/// <para>SET_AUDIT_FAILURE and SET_AUDIT_SUCCESS can be combined. For information about these values, see ACCESS_MODE.</para>
	/// <para>
	/// The <c>SetEntriesInAcl</c> function places any new system-audit ACEs at the beginning of the list of ACEs for the new ACL.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// For an example that uses this function, see Modifying the ACLs of an Object or Creating a Security Descriptor for a New Object or
	/// Taking Object Ownership.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/aclapi/nf-aclapi-setentriesinacla DWORD SetEntriesInAclA( ULONG
	// cCountOfExplicitEntries, PEXPLICIT_ACCESS_A pListOfExplicitEntries, PACL OldAcl, PACL *NewAcl );
	[DllImport(Lib.AdvApi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("aclapi.h", MSDNShortId = "05960fc1-1ad2-4c19-a65c-62259af5e18c")]
	public static extern Win32Error SetEntriesInAcl(uint cCountOfExplicitEntries, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] EXPLICIT_ACCESS[] pListOfExplicitEntries, PACL OldAcl, out SafePACL NewAcl);

	/// <summary>
	/// The SetNamedSecurityInfo function sets specified security information in the security descriptor of a specified object. The
	/// caller identifies the object by name.
	/// </summary>
	/// <param name="pObjectName">
	/// A pointer to a null-terminated string that specifies the name of the object for which to set security information. This can be
	/// the name of a local or remote file or directory on an NTFS file system, network share, registry key, semaphore, event, mutex,
	/// file mapping, or waitable timer. For descriptions of the string formats for the different object types, see SE_OBJECT_TYPE.
	/// </param>
	/// <param name="ObjectType">
	/// A value of the SE_OBJECT_TYPE enumeration that indicates the type of object named by the pObjectName parameter.
	/// </param>
	/// <param name="SecurityInfo">
	/// A set of bit flags that indicate the type of security information to set. This parameter can be a combination of the
	/// SECURITY_INFORMATION bit flags.
	/// </param>
	/// <param name="ppsidOwner">
	/// A pointer to a SID structure that identifies the owner of the object. If the caller does not have the SeRestorePrivilege constant
	/// (see Privilege Constants), this SID must be contained in the caller's token, and must have the SE_GROUP_OWNER permission enabled.
	/// The SecurityInfo parameter must include the OWNER_SECURITY_INFORMATION flag. To set the owner, the caller must have WRITE_OWNER
	/// access to the object or have the SE_TAKE_OWNERSHIP_NAME privilege enabled. If you are not setting the owner SID, this parameter
	/// can be NULL.
	/// </param>
	/// <param name="ppsidGroup">
	/// A pointer to a SID that identifies the primary group of the object. The SecurityInfo parameter must include the
	/// GROUP_SECURITY_INFORMATION flag. If you are not setting the primary group SID, this parameter can be NULL.
	/// </param>
	/// <param name="ppDacl">
	/// A pointer to the new DACL for the object. The SecurityInfo parameter must include the DACL_SECURITY_INFORMATION flag. The caller
	/// must have WRITE_DAC access to the object or be the owner of the object. If you are not setting the DACL, this parameter can be NULL.
	/// </param>
	/// <param name="ppSacl">
	/// A pointer to the new SACL for the object. The SecurityInfo parameter must include any of the following flags:
	/// SACL_SECURITY_INFORMATION, LABEL_SECURITY_INFORMATION, ATTRIBUTE_SECURITY_INFORMATION, SCOPE_SECURITY_INFORMATION, or BACKUP_SECURITY_INFORMATION.
	/// <para>
	/// If setting SACL_SECURITY_INFORMATION or SCOPE_SECURITY_INFORMATION, the caller must have the SE_SECURITY_NAME privilege enabled.
	/// If you are not setting the SACL, this parameter can be NULL.
	/// </para>
	/// </param>
	/// <returns>
	/// If the function succeeds, the function returns ERROR_SUCCESS. If the function fails, it returns a nonzero error code defined in WinError.h.
	/// </returns>
	[DllImport(Lib.AdvApi32, CharSet = CharSet.Auto)]
	[PInvokeData("Aclapi.h", MSDNShortId = "aa379579")]
	public static extern Win32Error SetNamedSecurityInfo(string pObjectName, SE_OBJECT_TYPE ObjectType, SECURITY_INFORMATION SecurityInfo, [Optional] PSID ppsidOwner,
		[Optional] PSID ppsidGroup, [Optional] PACL ppDacl, [Optional] PACL ppSacl);

	/// <summary>
	/// <para>
	/// The <c>SetSecurityInfo</c> function sets specified security information in the security descriptor of a specified object. The
	/// caller identifies the object by a handle.
	/// </para>
	/// <para>To set the SACL of an object, the caller must have the <c>SE_SECURITY_NAME</c> privilege enabled.</para>
	/// </summary>
	/// <param name="handle">
	/// <para>A handle to the object for which to set security information.</para>
	/// </param>
	/// <param name="ObjectType">
	/// <para>A member of the SE_OBJECT_TYPE enumeration that indicates the type of object identified by the handle parameter.</para>
	/// </param>
	/// <param name="SecurityInfo">
	/// <para>
	/// A set of bit flags that indicate the type of security information to set. This parameter can be a combination of the
	/// SECURITY_INFORMATION bit flags.
	/// </para>
	/// </param>
	/// <param name="psidOwner">
	/// <para>
	/// A pointer to a SID that identifies the owner of the object. The SID must be one that can be assigned as the owner SID of a
	/// security descriptor. The SecurityInfo parameter must include the OWNER_SECURITY_INFORMATION flag. This parameter can be
	/// <c>NULL</c> if you are not setting the owner SID.
	/// </para>
	/// </param>
	/// <param name="psidGroup">
	/// <para>
	/// A pointer to a SID that identifies the primary group of the object. The SecurityInfo parameter must include the
	/// GROUP_SECURITY_INFORMATION flag. This parameter can be <c>NULL</c> if you are not setting the primary group SID.
	/// </para>
	/// </param>
	/// <param name="pDacl">
	/// <para>
	/// A pointer to the new DACL for the object. This parameter is ignored unless the value of the SecurityInfo parameter includes the
	/// <c>DACL_SECURITY_INFORMATION</c> flag. If the value of the SecurityInfo parameter includes the <c>DACL_SECURITY_INFORMATION</c>
	/// flag and the value of this parameter is set to <c>NULL</c>, full access to the object is granted to everyone. For information
	/// about <c>null</c> DACLs, see Creating a DACL.
	/// </para>
	/// </param>
	/// <param name="pSacl">
	/// <para>
	/// A pointer to the new SACL for the object. The SecurityInfo parameter must include any of the following flags:
	/// SACL_SECURITY_INFORMATION, LABEL_SECURITY_INFORMATION, ATTRIBUTE_SECURITY_INFORMATION, SCOPE_SECURITY_INFORMATION, or
	/// BACKUP_SECURITY_INFORMATION. If setting SACL_SECURITY_INFORMATION or SCOPE_SECURITY_INFORMATION, the caller must have the
	/// SE_SECURITY_NAME privilege enabled. This parameter can be <c>NULL</c> if you are not setting the SACL.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns ERROR_SUCCESS.</para>
	/// <para>If the function fails, it returns a nonzero error code defined in WinError.h.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If you are setting the discretionary access control list (DACL) or any elements in the system access control list (SACL) of an
	/// object, the system automatically propagates any inheritable access control entries (ACEs) to existing child objects, according to
	/// the ACE inheritance rules.
	/// </para>
	/// <para>You can use the <c>SetSecurityInfo</c> function with the following types of objects:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>Local or remote files or directories on an NTFS</term>
	/// </item>
	/// <item>
	/// <term>Named pipes</term>
	/// </item>
	/// <item>
	/// <term>Local or remote printers</term>
	/// </item>
	/// <item>
	/// <term>Local or remote Windows services</term>
	/// </item>
	/// <item>
	/// <term>Network shares</term>
	/// </item>
	/// <item>
	/// <term>Registry keys</term>
	/// </item>
	/// <item>
	/// <term>Semaphores, events, mutexes, and waitable timers</term>
	/// </item>
	/// <item>
	/// <term>Processes, threads, jobs, and file-mapping objects</term>
	/// </item>
	/// <item>
	/// <term>Window stations and desktops</term>
	/// </item>
	/// <item>
	/// <term>Directory service objects</term>
	/// </item>
	/// </list>
	/// <para>
	/// The <c>SetSecurityInfo</c> function does not reorder access-allowed or access-denied ACEs based on the preferred order. When
	/// propagating inheritable ACEs to existing child objects, <c>SetSecurityInfo</c> puts inherited ACEs in order after all of the
	/// noninherited ACEs in the DACLs of the child objects.
	/// </para>
	/// <para>
	/// <c>Note</c> If share access to the children of the object is not available, this function will not propagate unprotected ACEs to
	/// the children. For example, if a directory is opened with exclusive access, the operating system will not propagate unprotected
	/// ACEs to the subdirectories or files of that directory when the security on the directory is changed.
	/// </para>
	/// <para>
	/// <c>Warning</c> If the supplied handle was opened with an ACCESS_MASK value of <c>MAXIMUM_ALLOWED</c>, then the
	/// <c>SetSecurityInfo</c> function will not propagate ACEs to children.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/aclapi/nf-aclapi-setsecurityinfo DWORD SetSecurityInfo( HANDLE handle,
	// SE_OBJECT_TYPE ObjectType, SECURITY_INFORMATION SecurityInfo, PSID psidOwner, PSID psidGroup, PACL pDacl, PACL pSacl );
	[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("aclapi.h", MSDNShortId = "f1781ba9-81eb-46f9-b530-c390b67d65de")]
	public static extern Win32Error SetSecurityInfo(IntPtr handle, SE_OBJECT_TYPE ObjectType, SECURITY_INFORMATION SecurityInfo, [Optional] PSID psidOwner, [Optional] PSID psidGroup, [Optional] PACL pDacl, [Optional] PACL pSacl);

	/// <summary>
	/// <para>
	/// The <c>TreeResetNamedSecurityInfo</c> function resets specified security information in the security descriptor of a specified
	/// tree of objects. This function allows a specified discretionary access control list (DACL) or any elements in the system access
	/// control list (SACL) to be propagated throughout an entire tree. This function supports a callback function to track the progress
	/// of the tree operation.
	/// </para>
	/// </summary>
	/// <param name="pObjectName">
	/// <para>
	/// Pointer to a <c>null</c>-terminated string that specifies the name of the root node object for the objects that are to receive
	/// updated security information. Supported objects are registry keys and file objects. For descriptions of the string formats for
	/// the different object types, see SE_OBJECT_TYPE.
	/// </para>
	/// </param>
	/// <param name="ObjectType">
	/// <para>
	/// A value of the SE_OBJECT_TYPE enumeration that indicates the type of object named by the pObjectName parameter. The supported
	/// values are SE_REGISTRY_KEY and SE_FILE_OBJECT, for registry keys and file objects, respectively.
	/// </para>
	/// </param>
	/// <param name="SecurityInfo">
	/// <para>
	/// A set of bit flags that indicate the type of security information to reset. This parameter can be a combination of the
	/// SECURITY_INFORMATION bit flags.
	/// </para>
	/// </param>
	/// <param name="pOwner">
	/// <para>
	/// A pointer to a SID structure that identifies the owner of the object. The SID must be one that can be assigned as the owner SID
	/// of a security descriptor. The SecurityInfo parameter must include the OWNER_SECURITY_INFORMATION flag. To set the owner, the
	/// caller must have WRITE_OWNER access to each object, including the root object. If you are not setting the owner SID, this
	/// parameter can be <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="pGroup">
	/// <para>
	/// A pointer to a SID structure that identifies the primary group of the object. The SecurityInfo parameter must include the
	/// GROUP_SECURITY_INFORMATION flag. To set the group, the caller must have WRITE_OWNER access to each object, including the root
	/// object. If you are not setting the primary group SID, this parameter can be <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="pDacl">
	/// <para>
	/// A pointer to an access control list (ACL) structure that represents the new DACL for the objects being reset. The SecurityInfo
	/// parameter must include the DACL_SECURITY_INFORMATION flag. The caller must have READ_CONTROL and WRITE_DAC access to each object,
	/// including the root object. If you are not setting the DACL, this parameter can be <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="pSacl">
	/// <para>
	/// A pointer to an ACL structure that represents the new SACL for the objects being reset. The SecurityInfo parameter must include
	/// any of the following flags: SACL_SECURITY_INFORMATION, LABEL_SECURITY_INFORMATION, ATTRIBUTE_SECURITY_INFORMATION,
	/// SCOPE_SECURITY_INFORMATION, or BACKUP_SECURITY_INFORMATION. If setting SACL_SECURITY_INFORMATION or SCOPE_SECURITY_INFORMATION,
	/// the caller must have the SE_SECURITY_NAME privilege enabled. If you are not setting the SACL, this parameter can be <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="KeepExplicit">
	/// <para>
	/// Boolean value that defines whether explicitly defined ACEs are kept or deleted for the sub-tree. If KeepExplicit is <c>TRUE</c>,
	/// then explicitly defined ACEs are kept for each subtree DACL and SACL, and inherited ACEs are replaced by the inherited ACEs from
	/// pDacl and pSacl. If KeepExplicit is <c>FALSE</c>, then explicitly defined ACEs for each subtree DACL and SACL are deleted before
	/// the inherited ACEs are replaced by the inherited ACEs from pDacl and pSacl.
	/// </para>
	/// </param>
	/// <param name="fnProgress">
	/// <para>
	/// A pointer to the function used to track the progress of the <c>TreeResetNamedSecurityInfo</c> function. The prototype of the
	/// progress function is:
	/// </para>
	/// <para>
	/// The progress function provides the caller with progress and error information when nodes are processed. The caller specifies the
	/// progress function in fnProgress, and during the tree operation, <c>TreeResetNamedSecurityInfo</c> passes the name of the last
	/// object processed, the error status of that operation, and the current PROG_INVOKE_SETTING value. The caller can change the
	/// PROG_INVOKE_SETTING value by using pInvokeSetting.
	/// </para>
	/// <para>If no progress function is to be used, set this parameter to <c>NULL</c>.</para>
	/// </param>
	/// <param name="ProgressInvokeSetting">
	/// <para>A value of the PROG_INVOKE_SETTING enumeration that specifies the initial setting for the progress function.</para>
	/// </param>
	/// <param name="Args">
	/// <para>A pointer to a <c>VOID</c> for progress function arguments specified by the caller.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns ERROR_SUCCESS.</para>
	/// <para>If the function fails, it returns an error code defined in WinError.h.</para>
	/// </returns>
	/// <remarks>
	/// <para>Setting a <c>NULL</c> owner, group, DACL, or SACL is not supported by this function.</para>
	/// <para>
	/// If the caller does not contain the proper privileges and permissions to support the requested owner, group, DACL, and SACL
	/// updates, then none of the updates are performed.
	/// </para>
	/// <para>This function is similar to the TreeSetNamedSecurityInfo function:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// If the KeepExplicit parameter of <c>TreeResetNamedSecurityInfo</c> is set to <c>TRUE</c>, then the function is equivalent to
	/// TreeSetNamedSecurityInfo with the dwAction parameter set to TREE_SEC_INFO_RESET_KEEP_EXPLICIT.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If the KeepExplicit parameter of <c>TreeResetNamedSecurityInfo</c> is set to <c>FALSE</c>, then the function is equivalent to
	/// TreeSetNamedSecurityInfo with the dwActionparameter set to TREE_SEC_INFO_RESET.
	/// </term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/aclapi/nf-aclapi-treeresetnamedsecurityinfoa DWORD
	// TreeResetNamedSecurityInfoA( LPSTR pObjectName, SE_OBJECT_TYPE ObjectType, SECURITY_INFORMATION SecurityInfo, PSID pOwner, PSID
	// pGroup, PACL pDacl, PACL pSacl, BOOL KeepExplicit, FN_PROGRESS fnProgress, PROG_INVOKE_SETTING ProgressInvokeSetting, PVOID Args );
	[DllImport(Lib.AdvApi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("aclapi.h", MSDNShortId = "adae7d07-a452-409e-b1a1-e9f86f873e39")]
	public static extern Win32Error TreeResetNamedSecurityInfo(string pObjectName, SE_OBJECT_TYPE ObjectType, SECURITY_INFORMATION SecurityInfo, [Optional] PSID pOwner, [Optional] PSID pGroup, [Optional] PACL pDacl, [Optional] PACL pSacl,
		[MarshalAs(UnmanagedType.Bool)] bool KeepExplicit, [Optional] FN_PROGRESS fnProgress, PROG_INVOKE_SETTING ProgressInvokeSetting, [Optional] IntPtr Args);

	/// <summary>
	/// <para>
	/// The <c>TreeSetNamedSecurityInfo</c> function sets specified security information in the security descriptor of a specified tree
	/// of objects. This function allows a specified discretionary access control list (DACL) or any elements in the system access
	/// control list (SACL) to be propagated throughout an entire tree. This function supports a callback function to track the progress
	/// of the tree operation.
	/// </para>
	/// </summary>
	/// <param name="pObjectName">
	/// <para>
	/// Pointer to a <c>null</c>-terminated string that specifies the name of the root node object for the objects that are to receive
	/// updated security information. Supported objects are registry keys and file objects. For descriptions of the string formats for
	/// the different object types, see SE_OBJECT_TYPE.
	/// </para>
	/// </param>
	/// <param name="ObjectType">
	/// <para>
	/// A value of the SE_OBJECT_TYPE enumeration that indicates the type of object named by the pObjectName parameter. The supported
	/// values are SE_REGISTRY_KEY and SE_FILE_OBJECT, for registry keys and file objects, respectively.
	/// </para>
	/// </param>
	/// <param name="SecurityInfo">
	/// <para>
	/// A set of bit flags that indicate the type of security information to set. This parameter can be a combination of the
	/// SECURITY_INFORMATION bit flags.
	/// </para>
	/// </param>
	/// <param name="pOwner">
	/// <para>
	/// A pointer to a SID structure that identifies the owner of the object. The SID must be one that can be assigned as the owner SID
	/// of a security descriptor. The SecurityInfo parameter must include the OWNER_SECURITY_INFORMATION flag. To set the owner, the
	/// caller must have WRITE_OWNER access to each object, including the root object. If you are not setting the owner SID, this
	/// parameter can be <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="pGroup">
	/// <para>
	/// A pointer to a SID structure that identifies the primary group of the object. The SecurityInfo parameter must include the
	/// GROUP_SECURITY_INFORMATION flag. To set the group, the caller must have WRITE_OWNER access to each object, including the root
	/// object. If you are not setting the primary group SID, this parameter can be <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="pDacl">
	/// <para>
	/// A pointer to an access control list (ACL) structure that represents the new DACL for the objects being reset. The SecurityInfo
	/// parameter must include the DACL_SECURITY_INFORMATION flag. The caller must have READ_CONTROL and WRITE_DAC access to each object,
	/// including the root object. If you are not setting the DACL, this parameter can be <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="pSacl">
	/// <para>
	/// A pointer to an ACL structure that represents the new SACL for the objects being reset. The SecurityInfo parameter must include
	/// any of the following flags: SACL_SECURITY_INFORMATION, LABEL_SECURITY_INFORMATION, ATTRIBUTE_SECURITY_INFORMATION,
	/// SCOPE_SECURITY_INFORMATION, or BACKUP_SECURITY_INFORMATION. If setting SACL_SECURITY_INFORMATION or SCOPE_SECURITY_INFORMATION,
	/// the caller must have the SE_SECURITY_NAME privilege enabled. If you are not setting the SACL, this parameter can be <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="dwAction">
	/// <para>Specifies the behavior of this function. This must be set to one of the following values, defined in AccCtrl.h.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>TREE_SEC_INFO_SET 0x00000001</term>
	/// <term>
	/// The security information is set on the object specified by the pObjectName parameter and the tree of child objects of that
	/// object. If ACLs are specified in either the pDacl or pSacl parameters, the security descriptors are associated with the object.
	/// The security descriptors are propagated to the tree of child objects based on their inheritance properties.
	/// </term>
	/// </item>
	/// <item>
	/// <term>TREE_SEC_INFO_RESET 0x00000002</term>
	/// <term>
	/// The security information is reset on the object specified by the pObjectName parameter and the tree of child objects of that
	/// object. Any existing security information is removed from all objects on the tree. If any object in the tree does not grant
	/// appropriate permissions to the caller to modify the security descriptor on the object, then the propagation of security
	/// information on that particular node of the tree and its objects is skipped. The operation continues on the rest of the tree under
	/// the object specified by the pObjectName parameter.
	/// </term>
	/// </item>
	/// <item>
	/// <term>TREE_SEC_INFO_RESET_KEEP_EXPLICIT 0x00000003</term>
	/// <term>
	/// The security information is reset on the object specified by the pObjectName parameter and the tree of child objects of that
	/// object. Any existing inherited security information is removed from all objects on the tree. Security information that was
	/// explicitly set on objects in the tree is unchanged. If any object in the tree does not grant appropriate permissions to the
	/// caller to modify the security descriptor on the object, then the propagation of security information on that particular node of
	/// the tree and its objects is skipped. The operation continues on the rest of the tree under the object specified by the
	/// pObjectName parameter.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="fnProgress">
	/// <para>
	/// A pointer to the function used to track the progress of the <c>TreeSetNamedSecurityInfo</c> function. The prototype of the
	/// progress function is:
	/// </para>
	/// <para>
	/// The progress function provides the caller with progress and error information when nodes are processed. The caller specifies the
	/// progress function in fnProgress, and during the tree operation, <c>TreeSetNamedSecurityInfo</c> passes the name of the last
	/// object processed, the error status of that operation, and the current PROG_INVOKE_SETTING value. The caller can change the
	/// PROG_INVOKE_SETTING value by using pInvokeSetting.
	/// </para>
	/// <para>If no progress function is to be used, set this parameter to <c>NULL</c>.</para>
	/// </param>
	/// <param name="ProgressInvokeSetting">
	/// <para>A value of the PROG_INVOKE_SETTING enumeration that specifies the initial setting for the progress function.</para>
	/// </param>
	/// <param name="Args">
	/// <para>A pointer to a <c>VOID</c> for progress function arguments specified by the caller.</para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns <c>ERROR_SUCCESS</c>.</para>
	/// <para>If the function fails, it returns an error code defined in WinError.h.</para>
	/// </returns>
	/// <remarks>
	/// <para>Setting a <c>NULL</c> owner, group, DACL, or SACL is not supported by this function.</para>
	/// <para>
	/// If the caller does not contain the proper privileges and permissions to support the requested owner, group, DACL, and SACL
	/// updates, then none of the updates is performed.
	/// </para>
	/// <para>
	/// This function provides the same functionality as the SetNamedSecurityInfo function when the value of the dwAction parameter is
	/// set to <c>TREE_SEC_INFO_SET</c>, the value of the ProgressInvokeSetting parameter is set to <c>ProgressInvokePrePostError</c>,
	/// and the function pointed to by the fnProgress parameter sets the value of its pInvokeSetting parameter to <c>ProgressInvokePrePostError</c>.
	/// </para>
	/// <para>This function is similar to the TreeResetNamedSecurityInfo function:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>
	/// If the dwAction parameter of <c>TreeSetNamedSecurityInfo</c> is set to TREE_SEC_INFO_RESET_KEEP_EXPLICIT, then the function is
	/// equivalent to TreeResetNamedSecurityInfo with the KeepExplicit parameter set to <c>TRUE</c>.
	/// </term>
	/// </item>
	/// <item>
	/// <term>
	/// If the dwAction parameter of <c>TreeSetNamedSecurityInfo</c> is set to TREE_SEC_INFO_RESET, then the function is equivalent to
	/// TreeResetNamedSecurityInfo with the KeepExplicit parameter set to <c>FALSE</c>.
	/// </term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/aclapi/nf-aclapi-treesetnamedsecurityinfow DWORD TreeSetNamedSecurityInfoW(
	// LPWSTR pObjectName, SE_OBJECT_TYPE ObjectType, SECURITY_INFORMATION SecurityInfo, PSID pOwner, PSID pGroup, PACL pDacl, PACL
	// pSacl, DWORD dwAction, FN_PROGRESS fnProgress, PROG_INVOKE_SETTING ProgressInvokeSetting, PVOID Args );
	[DllImport(Lib.AdvApi32, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("aclapi.h", MSDNShortId = "caa711c3-301b-4ed7-b1f4-dc6a48563905")]
	public static extern Win32Error TreeSetNamedSecurityInfo(string pObjectName, SE_OBJECT_TYPE ObjectType, SECURITY_INFORMATION SecurityInfo, [Optional] PSID pOwner, [Optional] PSID pGroup,
		[Optional] PACL pDacl, [Optional] PACL pSacl, TREE_SEC_INFO dwAction, [Optional] FN_PROGRESS fnProgress, PROG_INVOKE_SETTING ProgressInvokeSetting, [Optional] IntPtr Args);

	/// <summary>
	/// A <see cref="SafeHandle"/> to hold the array of <see cref="INHERITED_FROM"/> instances returned from <see
	/// cref="GetInheritanceSource(string, SE_OBJECT_TYPE, SECURITY_INFORMATION, bool, Guid[], uint, PACL, IntPtr, in GENERIC_MAPPING, SafeInheritedFromArray)"/>.
	/// </summary>
	public class SafeInheritedFromArray : SafeHGlobalHandle
	{
		/// <summary>Initializes a new instance of the <see cref="SafeInheritedFromArray"/> class.</summary>
		/// <param name="aceCount">The count of ACEs that are contained in the ACL.</param>
		public SafeInheritedFromArray(ushort aceCount) : base(aceCount * Marshal.SizeOf<INHERITED_FROM>()) => AceCount = aceCount;

		/// <summary>Gets the count of ACEs that are contained in the ACL.</summary>
		/// <value>The ACE count.</value>
		public ushort AceCount { get; }

		/// <summary>Gets the array of inheritance objects.</summary>
		/// <value>The array of inheritance objects.</value>
		public INHERITED_FROM[] Results => IsInvalid ? new INHERITED_FROM[0] : handle.ToArray<INHERITED_FROM>(AceCount)!;

		/// <summary>When overridden in a derived class, executes the code required to free the handle.</summary>
		/// <returns>
		/// true if the handle is released successfully; otherwise, in the event of a catastrophic failure, false. In this case, it
		/// generates a releaseHandleFailed MDA Managed Debugging Assistant.
		/// </returns>
		protected override bool ReleaseHandle()
		{
			FreeInheritedFromArray(handle, AceCount, IntPtr.Zero);
			return base.ReleaseHandle();
		}
	}
}