using System;
using System.Runtime.InteropServices;
using Vanara.Extensions;
using Vanara.InteropServices;

namespace Vanara.PInvoke
{
	public static partial class AdvApi32
	{
		/// <summary>The FreeInheritedFromArray function frees memory allocated by the GetInheritanceSource function.</summary>
		/// <param name="pInheritArray">A pointer to the array of INHERITED_FROM structures returned by GetInheritanceSource.</param>
		/// <param name="AceCnt">Number of entries in pInheritArray.</param>
		/// <param name="pfnArray">Unused. Set to NULL.</param>
		/// <returns>If the function succeeds, the return value is ERROR_SUCCESS. If the function fails, it returns a nonzero error code.</returns>
		[DllImport(Lib.AdvApi32, ExactSpelling = true)]
		[PInvokeData("Aclapi.h", MSDNShortId = "aa446630")]
		public static extern Win32Error FreeInheritedFromArray(IntPtr pInheritArray, ushort AceCnt, IntPtr pfnArray);

		/// <summary>
		/// The GetInheritanceSource function returns information about the source of inherited access control entries (ACEs) in an access control list (ACL).
		/// </summary>
		/// <param name="pObjectName">A pointer to the name of the object that uses the ACL to be checked.</param>
		/// <param name="ObjectType">
		/// The type of object indicated by pObjectName. The possible values are SE_FILE_OBJECT, SE_REGISTRY_KEY, SE_DS_OBJECT, and SE_DS_OBJECT_ALL.
		/// </param>
		/// <param name="SecurityInfo">The type of ACL used with the object. The possible values are DACL_SECURITY_INFORMATION or SACL_SECURITY_INFORMATION.</param>
		/// <param name="Container">TRUE if the object is a container object or FALSE if the object is a leaf object. Note that the only leaf object is SE_FILE_OBJECT.</param>
		/// <param name="pObjectClassGuids">
		/// Optional list of GUIDs that identify the object types or names associated with pObjectName. This may be NULL if the object manager only supports one
		/// object class or has no GUID associated with the object class.
		/// </param>
		/// <param name="GuidCount">Number of GUIDs pointed to by pObjectClassGuids.</param>
		/// <param name="pAcl">The ACL for the object.</param>
		/// <param name="pfnArray">Reserved. Set this parameter to NULL.</param>
		/// <param name="pGenericMapping">The mapping of generic rights to specific rights for the object.</param>
		/// <param name="pInheritArray">
		/// A pointer to an array of INHERITED_FROM structures that the GetInheritanceSource function fills with the inheritance information. The caller must
		/// allocate enough memory for an entry for each ACE in the ACL.
		/// </param>
		/// <returns>If the function succeeds, the function returns ERROR_SUCCESS. If the function fails, it returns a nonzero error code defined in WinError.h.</returns>
		[DllImport(Lib.AdvApi32, CharSet = CharSet.Auto)]
		[PInvokeData("Aclapi.h", MSDNShortId = "aa446640")]
		public static extern Win32Error GetInheritanceSource([MarshalAs(UnmanagedType.LPTStr)] string pObjectName, SE_OBJECT_TYPE ObjectType,
			SECURITY_INFORMATION SecurityInfo, [MarshalAs(UnmanagedType.Bool)] bool Container,
			[In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5, ArraySubType = UnmanagedType.LPStruct), Optional] Guid[] pObjectClassGuids,
			uint GuidCount, [In] IntPtr pAcl, [In] IntPtr pfnArray, in GENERIC_MAPPING pGenericMapping, SafeInheritedFromArray pInheritArray);

		/// <summary>
		/// The GetEffectiveRightsFromAcl function retrieves the effective access rights that an ACL structure grants to a specified trustee. The trustee's
		/// effective access rights are the access rights that the ACL grants to the trustee or to any groups of which the trustee is a member.
		/// </summary>
		/// <param name="pacl">A pointer to an ACL structure from which to get the trustee's effective access rights.</param>
		/// <param name="pTrustee">
		/// A pointer to a TRUSTEE structure that identifies the trustee. A trustee can be a user, group, or program (such as a Windows service). You can use a
		/// name or a security identifier (SID) to identify a trustee.
		/// </param>
		/// <param name="pAccessRights">A pointer to an ACCESS_MASK variable that receives the effective access rights of the trustee.</param>
		[DllImport(Lib.AdvApi32, CharSet = CharSet.Auto)]
		[PInvokeData("Aclapi.h", MSDNShortId = "aa446637")]
		public static extern Win32Error GetEffectiveRightsFromAcl(IntPtr pacl, [In] TRUSTEE pTrustee, ref uint pAccessRights);

		/// <summary>The GetNamedSecurityInfo function retrieves a copy of the security descriptor for an object specified by name.</summary>
		/// <param name="pObjectName">
		/// A pointer to a null-terminated string that specifies the name of the object from which to retrieve security information. For descriptions of the
		/// string formats for the different object types, see SE_OBJECT_TYPE.
		/// </param>
		/// <param name="ObjectType">Specifies a value from the SE_OBJECT_TYPE enumeration that indicates the type of object named by the pObjectName parameter.</param>
		/// <param name="SecurityInfo">
		/// A set of bit flags that indicate the type of security information to retrieve. This parameter can be a combination of the SECURITY_INFORMATION bit flags.
		/// </param>
		/// <param name="ppsidOwner">
		/// A pointer to a variable that receives a pointer to the owner SID in the security descriptor returned in ppSecurityDescriptor or NULL if the security
		/// descriptor has no owner SID. The returned pointer is valid only if you set the OWNER_SECURITY_INFORMATION flag. Also, this parameter can be NULL if
		/// you do not need the owner SID.
		/// </param>
		/// <param name="ppsidGroup">
		/// A pointer to a variable that receives a pointer to the primary group SID in the returned security descriptor or NULL if the security descriptor has
		/// no group SID. The returned pointer is valid only if you set the GROUP_SECURITY_INFORMATION flag. Also, this parameter can be NULL if you do not need
		/// the group SID.
		/// </param>
		/// <param name="ppDacl">
		/// A pointer to a variable that receives a pointer to the DACL in the returned security descriptor or NULL if the security descriptor has no DACL. The
		/// returned pointer is valid only if you set the DACL_SECURITY_INFORMATION flag. Also, this parameter can be NULL if you do not need the DACL.
		/// </param>
		/// <param name="ppSacl">
		/// A pointer to a variable that receives a pointer to the SACL in the returned security descriptor or NULL if the security descriptor has no SACL. The
		/// returned pointer is valid only if you set the SACL_SECURITY_INFORMATION flag. Also, this parameter can be NULL if you do not need the SACL.
		/// </param>
		/// <param name="ppSecurityDescriptor">
		/// A pointer to a variable that receives a pointer to the security descriptor of the object. When you have finished using the pointer, free the returned
		/// buffer by calling the LocalFree function.
		/// <para>This parameter is required if any one of the ppsidOwner, ppsidGroup, ppDacl, or ppSacl parameters is not NULL.</para>
		/// </param>
		/// <returns>
		/// If the function succeeds, the return value is ERROR_SUCCESS. If the function fails, the return value is a nonzero error code defined in WinError.h.
		/// </returns>
		[DllImport(Lib.AdvApi32, CharSet = CharSet.Auto, SetLastError = true)]
		[PInvokeData("Aclapi.h", MSDNShortId = "aa446645")]
		public static extern Win32Error GetNamedSecurityInfo(
			string pObjectName,
			SE_OBJECT_TYPE ObjectType,
			SECURITY_INFORMATION SecurityInfo,
			out IntPtr ppsidOwner,
			out IntPtr ppsidGroup,
			out IntPtr ppDacl,
			out IntPtr ppSacl,
			out SafeSecurityDescriptor ppSecurityDescriptor);

		/// <summary>
		/// The SetNamedSecurityInfo function sets specified security information in the security descriptor of a specified object. The caller identifies the
		/// object by name.
		/// </summary>
		/// <param name="pObjectName">
		/// A pointer to a null-terminated string that specifies the name of the object for which to set security information. This can be the name of a local or
		/// remote file or directory on an NTFS file system, network share, registry key, semaphore, event, mutex, file mapping, or waitable timer. For
		/// descriptions of the string formats for the different object types, see SE_OBJECT_TYPE.
		/// </param>
		/// <param name="ObjectType">A value of the SE_OBJECT_TYPE enumeration that indicates the type of object named by the pObjectName parameter.</param>
		/// <param name="SecurityInfo">
		/// A set of bit flags that indicate the type of security information to set. This parameter can be a combination of the SECURITY_INFORMATION bit flags.
		/// </param>
		/// <param name="ppsidOwner">
		/// A pointer to a SID structure that identifies the owner of the object. If the caller does not have the SeRestorePrivilege constant (see Privilege
		/// Constants), this SID must be contained in the caller's token, and must have the SE_GROUP_OWNER permission enabled. The SecurityInfo parameter must
		/// include the OWNER_SECURITY_INFORMATION flag. To set the owner, the caller must have WRITE_OWNER access to the object or have the
		/// SE_TAKE_OWNERSHIP_NAME privilege enabled. If you are not setting the owner SID, this parameter can be NULL.
		/// </param>
		/// <param name="ppsidGroup">
		/// A pointer to a SID that identifies the primary group of the object. The SecurityInfo parameter must include the GROUP_SECURITY_INFORMATION flag. If
		/// you are not setting the primary group SID, this parameter can be NULL.
		/// </param>
		/// <param name="ppDacl">
		/// A pointer to the new DACL for the object. The SecurityInfo parameter must include the DACL_SECURITY_INFORMATION flag. The caller must have WRITE_DAC
		/// access to the object or be the owner of the object. If you are not setting the DACL, this parameter can be NULL.
		/// </param>
		/// <param name="ppSacl">
		/// A pointer to the new SACL for the object. The SecurityInfo parameter must include any of the following flags: SACL_SECURITY_INFORMATION,
		/// LABEL_SECURITY_INFORMATION, ATTRIBUTE_SECURITY_INFORMATION, SCOPE_SECURITY_INFORMATION, or BACKUP_SECURITY_INFORMATION.
		/// <para>
		/// If setting SACL_SECURITY_INFORMATION or SCOPE_SECURITY_INFORMATION, the caller must have the SE_SECURITY_NAME privilege enabled. If you are not
		/// setting the SACL, this parameter can be NULL.
		/// </para>
		/// </param>
		/// <returns>If the function succeeds, the function returns ERROR_SUCCESS. If the function fails, it returns a nonzero error code defined in WinError.h.</returns>
		[DllImport(Lib.AdvApi32, CharSet = CharSet.Auto)]
		[PInvokeData("Aclapi.h", MSDNShortId = "aa379579")]
		public static extern Win32Error SetNamedSecurityInfo(string pObjectName, SE_OBJECT_TYPE ObjectType, SECURITY_INFORMATION SecurityInfo, PSID ppsidOwner,
			PSID ppsidGroup, IntPtr ppDacl, IntPtr ppSacl);

		/// <summary>A <see cref="SafeHandle"/> to hold the array of <see cref="INHERITED_FROM"/> instances returned from <see cref="GetInheritanceSource"/>.</summary>
		public class SafeInheritedFromArray : SafeHGlobalHandle
		{
			/// <summary>Initializes a new instance of the <see cref="SafeInheritedFromArray"/> class.</summary>
			/// <param name="aceCount">The count of ACEs that are contained in the ACL.</param>
			public SafeInheritedFromArray(ushort aceCount) : base(aceCount * Marshal.SizeOf(typeof(INHERITED_FROM)))
			{
				AceCount = aceCount;
			}

			/// <summary>Gets the count of ACEs that are contained in the ACL.</summary>
			/// <value>The ACE count.</value>
			public ushort AceCount { get; }

			/// <summary>Gets the array of inheritance objects.</summary>
			/// <value>The array of inheritance objects.</value>
			public INHERITED_FROM[] Results => handle.ToArray<INHERITED_FROM>(AceCount);

			/// <summary>When overridden in a derived class, executes the code required to free the handle.</summary>
			/// <returns>
			/// true if the handle is released successfully; otherwise, in the event of a catastrophic failure, false. In this case, it generates a
			/// releaseHandleFailed MDA Managed Debugging Assistant.
			/// </returns>
			protected override bool ReleaseHandle()
			{
				FreeInheritedFromArray(handle, AceCount, IntPtr.Zero);
				return base.ReleaseHandle();
			}
		}
	}
}
