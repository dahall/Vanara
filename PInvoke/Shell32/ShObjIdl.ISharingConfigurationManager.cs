using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke;

public static partial class Shell32
{
	/// <summary>Values that specify the folder being acted on by methods of the ISharingConfigurationManager interface.</summary>
	/// <remarks>
	/// <para>
	/// In Windows Vista, an Server Message Block (SMB) share is created for both the <c>Users</c> and <c>Public</c> folders. As of
	/// Windows 7, the Public share is accessed through the Users share, so only <c>Users</c> is given an SMB share.
	/// </para>
	/// <para>
	/// When methods are called with the <c>DEFSHAREID_PUBLIC</c> value, the restrictions specified by the SHARE_ROLE value in that call
	/// apply to the Everyone access control entry (ACE).
	/// </para>
	/// <para>
	/// When methods are called with the <c>DEFSHAREID_USERS</c> value, the restrictions specified by the SHARE_ROLE value in that call
	/// apply to the Authenticated Users ACE.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/ne-shobjidl_core-def_share_id typedef enum DEF_SHARE_ID {
	// DEFSHAREID_USERS, DEFSHAREID_PUBLIC } ;
	[PInvokeData("shobjidl_core.h", MSDNShortId = "NE:shobjidl_core.DEF_SHARE_ID")]
	public enum DEF_SHARE_ID
	{
		/// <summary>The Users folder (FOLDERID_UserProfiles). This folder is usually found at C:\Users.</summary>
		DEFSHAREID_USERS = 1,

		/// <summary>The Public folder (FOLDERID_Public). This folder is usually found at C:\Users\Public.</summary>
		DEFSHAREID_PUBLIC,
	}

	/// <summary>Specifies the access permissions assigned to the <c>Users</c> or <c>Public</c> folder. Used in CreateShare and GetSharePermissions.</summary>
	/// <remarks>
	/// ISharingConfigurationManager::CreateShare accepts only <c>SHARE_ROLE_READER</c> and <c>SHARE_ROLE_CO_OWNER</c>. All other values
	/// are seen only in the results of ISharingConfigurationManager::GetSharePermissions.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/ne-shobjidl_core-share_role typedef enum SHARE_ROLE {
	// SHARE_ROLE_INVALID, SHARE_ROLE_READER, SHARE_ROLE_CONTRIBUTOR, SHARE_ROLE_CO_OWNER, SHARE_ROLE_OWNER, SHARE_ROLE_CUSTOM,
	// SHARE_ROLE_MIXED } ;
	[PInvokeData("shobjidl_core.h", MSDNShortId = "NE:shobjidl_core.SHARE_ROLE")]
	// public enum SHARE_ROLE{SHARE_ROLE_INVALID, SHARE_ROLE_READER, SHARE_ROLE_CONTRIBUTOR, SHARE_ROLE_CO_OWNER, SHARE_ROLE_OWNER,
	// SHARE_ROLE_CUSTOM, SHARE_ROLE_MIXED, }
	public enum SHARE_ROLE
	{
		/// <summary>The folder is not shared.</summary>
		SHARE_ROLE_INVALID = -1,

		/// <summary>The contents of the folder can be read, but not altered or added to.</summary>
		SHARE_ROLE_READER,

		/// <summary>
		/// The contents of the folder can be read and altered. New items can be added, however items can be deleted only by the user
		/// that contributed them.
		/// </summary>
		SHARE_ROLE_CONTRIBUTOR,

		/// <summary>The contents of the folder can be read, changed, or added to.</summary>
		SHARE_ROLE_CO_OWNER,

		/// <summary>Not normally used in the context of this interface.</summary>
		SHARE_ROLE_OWNER,

		/// <summary>The folder is shared, but the share role is neither SHARE_ROLE_READER, SHARE_ROLE_CONTRIBUTOR, or SHARE_ROLE_CO_OWNER.</summary>
		SHARE_ROLE_CUSTOM,

		/// <summary>Not used in the context of this interface.</summary>
		SHARE_ROLE_MIXED,
	}

	/// <summary>
	/// Exposes methods that set and retrieve information about a computer's default sharing settings for the <c>Users</c> () or
	/// <c>Public</c> () folder. Also exposes a set of methods that allow control of printer sharing.
	/// </summary>
	/// <remarks>
	/// <para>When to Implement</para>
	/// <para>
	/// An implementation of this interface is included in the <c>CSharingConfiguration</c> class. Third parties do not provide their
	/// own implementation.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nn-shobjidl_core-isharingconfigurationmanager
	[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.ISharingConfigurationManager")]
	[ComImport, Guid("B4CD448A-9C86-4466-9201-2E62105B87AE"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), CoClass(typeof(SharingConfigurationManager))]
	public interface ISharingConfigurationManager
	{
		/// <summary>
		/// Shares the <c>Users</c> or <c>Public</c> folder. If the folder is already shared, this method updates its sharing status.
		/// </summary>
		/// <param name="dsid">
		/// <para>Type: <c>DEF_SHARE_ID</c></para>
		/// <para>One of the DEF_SHARE_ID values that indicates the folder to share or update.</para>
		/// </param>
		/// <param name="role">
		/// <para>Type: <c>SHARE_ROLE</c></para>
		/// <para>
		/// One of the following SHARE_ROLE values that sets the access permissions of the share for the Everyone ACE.
		/// <c>CreateShare</c> accepts only these values.
		/// </para>
		/// <para>SHARE_ROLE_READER (0)</para>
		/// <para>Read-only. The contents of the folder can be read, but not altered or added to.</para>
		/// <para>SHARE_ROLE_CO_OWNER (2)</para>
		/// <para>Read/Write. The contents of the folder can be read, changed, or added to.</para>
		/// </param>
		/// <remarks>
		/// <para>Running this method requires an Administrator privilege level.</para>
		/// <para>
		/// If the folder named in dsid is not shared, this method shares the folder using the permission level provided in the role parameter.
		/// </para>
		/// <para>
		/// If the folder named in dsid is already shared, this method updates the permissions on the share with the value provided in
		/// the role parameter.
		/// </para>
		/// <para>
		/// Because as of Windows 7 the <c>Public</c> folder is shared through <c>Users</c> rather than directly, creating a share on
		/// <c>Public</c> causes an Server Message Block (SMB) share to be created on <c>Users</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-isharingconfigurationmanager-createshare
		// HRESULT CreateShare( DEF_SHARE_ID dsid, SHARE_ROLE role );
		void CreateShare(DEF_SHARE_ID dsid, SHARE_ROLE role);

		/// <summary>Removes sharing from either the <c>Users</c> or <c>Public</c> folder.</summary>
		/// <param name="dsid">
		/// <para>Type: <c>DEF_SHARE_ID</c></para>
		/// <para>One of the DEF_SHARE_ID values that specifies the folder to no longer share.</para>
		/// </param>
		/// <remarks>Running this method requires an Administrator privilege level.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-isharingconfigurationmanager-deleteshare
		// HRESULT DeleteShare( DEF_SHARE_ID dsid );
		void DeleteShare(DEF_SHARE_ID dsid);

		/// <summary>Queries whether the <c>Users</c> or <c>Public</c> folder is shared.</summary>
		/// <param name="dsid">
		/// <para>Type: <c>DEF_SHARE_ID</c></para>
		/// <para>One of the DEF_SHARE_ID values that indicates the folder whose sharing state is being checked.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>S_OK if the folder is shared; otherwise, S_FALSE.</para>
		/// </returns>
		/// <remarks>
		/// Because as of Windows 7 <c>Public</c> is shared in-place through <c>Users</c>, callers should always check for the Users
		/// share first. If a share is found to exist on <c>Users</c>, then it follows that a share exists on <c>Public</c> as well.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-isharingconfigurationmanager-shareexists
		// HRESULT ShareExists( DEF_SHARE_ID dsid );
		[PreserveSig]
		HRESULT ShareExists(DEF_SHARE_ID dsid);

		/// <summary>
		/// Gets the access permissions currently associated with the <c>User</c> or <c>Public</c> folder for the Everyone access
		/// control entry (ACE).
		/// </summary>
		/// <param name="dsid">
		/// <para>Type: <c>DEF_SHARE_ID</c></para>
		/// <para>One of the DEF_SHARE_ID values that specifies the folder.</para>
		/// </param>
		/// <returns>
		/// <para>Type: <c>SHARE_ROLE*</c></para>
		/// <para>
		/// A pointer to a value that, when this method returns successfully, receives one of the SHARE_ROLE values that indicate the
		/// sharing permissions set for the folder specified in the dsid parameter.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-isharingconfigurationmanager-getsharepermissions
		// HRESULT GetSharePermissions( DEF_SHARE_ID dsid, SHARE_ROLE *pRole );
		SHARE_ROLE GetSharePermissions(DEF_SHARE_ID dsid);

		/// <summary>
		/// Shares all local printers connected to a computer, enabling them to be discovered by other computers on the network.
		/// </summary>
		/// <remarks>Running this method requires an Administrator privilege level.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-isharingconfigurationmanager-shareprinters
		// HRESULT SharePrinters();
		void SharePrinters();

		/// <summary>Stops sharing all local, shared printers connected to a computer.</summary>
		/// <remarks>Running this method requires an Administrator privilege level.</remarks>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-isharingconfigurationmanager-stopsharingprinters
		// HRESULT StopSharingPrinters();
		void StopSharingPrinters();

		/// <summary>Determines whether any printers connected to this computer are shared.</summary>
		/// <returns>
		/// <para>Type: <c>HRESULT</c></para>
		/// <para>Returns standard HRESULT values, including the following:</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>S_OK</term>
		/// <term>Shared printers were detected.</term>
		/// </item>
		/// <item>
		/// <term>S_FALSE</term>
		/// <term>No shared printers were found.</term>
		/// </item>
		/// <item>
		/// <term>ERROR_FILE_NOT_FOUND</term>
		/// <term>No printers capable of being shared were found.</term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/shobjidl_core/nf-shobjidl_core-isharingconfigurationmanager-areprintersshared
		// HRESULT ArePrintersShared();
		[PreserveSig]
		HRESULT ArePrintersShared();
	}

	/// <summary>CLSID_SharingConfigurationManager</summary>
	[PInvokeData("shobjidl_core.h", MSDNShortId = "NN:shobjidl_core.ISharingConfigurationManager")]
	[ComImport, Guid("49F371E1-8C5C-4d9c-9A3B-54A6827F513C"), ClassInterface(ClassInterfaceType.None)]
	public class SharingConfigurationManager { }
}