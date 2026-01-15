using System.Collections.Generic;

namespace Vanara.PInvoke;

public static partial class AdvApi32
{
	/// <summary/>
	public const uint MANAGED_APPS_INFOLEVEL_DEFAULT = 0x10000;

	/// <summary>
	/// The <c>INSTALLSPECTYPE</c> enumeration values define the ways a group policy application can be specified to the
	/// InstallApplication function. The values are used in the <c>Type</c> member of INSTALLDATA.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/appmgmt/ne-appmgmt-installspectype typedef enum _INSTALLSPECTYPE { APPNAME,
	// FILEEXT, PROGID, COMCLASS } INSTALLSPECTYPE;
	[PInvokeData("appmgmt.h", MSDNShortId = "9e62a22d-cae7-4b3e-9000-71eddb1f3cad")]
	public enum INSTALLSPECTYPE
	{
		/// <summary>This constant equals 1. The application is specified by its display name and group policy GUID.</summary>
		APPNAME = 1,

		/// <summary>The application is specified by its file name extension, for example, .jpg.</summary>
		FILEEXT,

		/// <summary/>
		PROGID,

		/// <summary/>
		COMCLASS,
	}

	/// <summary>Query type for <c>GetManagedApplications</c>.</summary>
	[PInvokeData("appmgmt.h", MSDNShortId = "62e32f36-cbb2-4557-9773-8bd454870d55")]
	public enum MANAGED_APPQUERY
	{
		/// <summary>Lists all applications that apply to the user. The parameter pCategory must be null.</summary>
		MANAGED_APPS_USERAPPLICATIONS = 0x1,

		/// <summary>Lists only applications in the category specified by pCategory. The pCategory parameter cannot be null.</summary>
		MANAGED_APPS_FROMCATEGORY = 0x2,
	}

	/// <summary>Type param for <c>MANAGEDAPPLICATION</c>.</summary>
	[PInvokeData("appmgmt.h", MSDNShortId = "8ac78f92-e665-4dd0-b226-6bf41dcd050a")]
	public enum MANAGED_APPTYPE
	{
		/// <summary>The application is installed using the Windows Installer.</summary>
		MANAGED_APPTYPE_WINDOWSINSTALLER = 0x1,

		/// <summary>The application is installed using a legacy setup application.</summary>
		MANAGED_APPTYPE_SETUPEXE = 0x2,

		/// <summary>The application is installed by an unsupported setup application.</summary>
		MANAGED_APPTYPE_UNSUPPORTED = 0x3,
	}

	/// <summary>
	/// The <c>GetLocalManagedApplications</c> function can be run on the target computer to get a list of managed applications on that
	/// computer. The function can also be called in the context of a user to get a list of managed applications for that user. This
	/// function only returns applications that can be installed by the Windows Installer.
	/// </summary>
	/// <param name="bUserApps">
	/// A value that, if <c>TRUE</c>, the prgLocalApps parameter contains a list of managed applications that applies to the user. If the
	/// value of this parameter is <c>FALSE</c>, the prgLocalApps parameter contains a list of managed applications that applies to the
	/// local computer.
	/// </param>
	/// <param name="pdwApps">The address of a <c>DWORD</c> that specifies the number of applications in the list returned by prgLocalApps.</param>
	/// <param name="prgLocalApps">
	/// The address of an array that contains the list of managed applications. You must call <c>LocalFree</c> to free this array when
	/// its contents are no longer required. This parameter cannot be null. The list is returned as a LOCALMANAGEDAPPLICATION structure.
	/// </param>
	/// <returns>
	/// If the function succeeds, the return value is <c>ERROR_SUCCESS</c>. Otherwise, the function returns one of the system error
	/// codes. For a complete list of error codes, see System Error Codes or the header file WinError.h.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/appmgmt/nf-appmgmt-getlocalmanagedapplications DWORD
	// GetLocalManagedApplications( BOOL bUserApps, LPDWORD pdwApps, PLOCALMANAGEDAPPLICATION *prgLocalApps );
	[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("appmgmt.h", MSDNShortId = "4606ff09-7e23-4953-aeef-cac822995d35")]
	public static extern Win32Error GetLocalManagedApplications([MarshalAs(UnmanagedType.Bool)] bool bUserApps, out uint pdwApps, out SafeLocalHandle prgLocalApps);

	/// <summary>
	/// The <c>GetLocalManagedApplications</c> function can be run on the target computer to get a list of managed applications on that
	/// computer. The function can also be called in the context of a user to get a list of managed applications for that user. This
	/// function only returns applications that can be installed by the Windows Installer.
	/// </summary>
	/// <param name="bUserApps">
	/// A value that, if <c>TRUE</c>, the prgLocalApps parameter contains a list of managed applications that applies to the user. If the
	/// value of this parameter is <c>FALSE</c>, the prgLocalApps parameter contains a list of managed applications that applies to the
	/// local computer.
	/// </param>
	/// <returns>The list of managed applications.</returns>
	[PInvokeData("appmgmt.h", MSDNShortId = "4606ff09-7e23-4953-aeef-cac822995d35")]
	public static IEnumerable<LOCALMANAGEDAPPLICATION> GetLocalManagedApplications(bool bUserApps)
	{
		GetLocalManagedApplications(bUserApps, out var c, out var p).ThrowIfFailed();
		return p.ToArray<LOCALMANAGEDAPPLICATION>((int)c);
	}

	/// <summary>
	/// The <c>GetManagedApplicationCategories</c> function gets a list of application categories for a domain. The list is the same for
	/// all users in the domain.
	/// </summary>
	/// <param name="dwReserved">This parameter is reserved. Its value must be 0.</param>
	/// <param name="pAppCategory">
	/// A APPCATEGORYINFOLIST structure that contains a list of application categories. This structure must be freed by calling LocalFree
	/// when the list is no longer required.
	/// </param>
	/// <returns>
	/// If the function succeeds, the return value is <c>ERROR_SUCCESS</c>. Otherwise, the function returns one of the system error
	/// codes. For a complete list of error codes, see System Error Codes or the header file WinError.h.
	/// </returns>
	/// <remarks>
	/// The structure returned by <c>GetManagedApplicationCategories</c> must be freed by calling LocalFree when the list is no longer required.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/appmgmt/nf-appmgmt-getmanagedapplicationcategories DWORD
	// GetManagedApplicationCategories( DWORD dwReserved, APPCATEGORYINFOLIST *pAppCategory );
	[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("appmgmt.h", MSDNShortId = "10824852-7810-483a-91b3-2d9cc3d21934")]
	public static extern Win32Error GetManagedApplicationCategories([Optional] uint dwReserved, IntPtr pAppCategory);

	/// <summary>
	/// The <c>GetManagedApplicationCategories</c> function gets a list of application categories for a domain. The list is the same for
	/// all users in the domain.
	/// </summary>
	/// <returns>A list of application categories.</returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/appmgmt/nf-appmgmt-getmanagedapplicationcategories DWORD
	// GetManagedApplicationCategories( DWORD dwReserved, APPCATEGORYINFOLIST *pAppCategory );
	[PInvokeData("appmgmt.h", MSDNShortId = "10824852-7810-483a-91b3-2d9cc3d21934")]
	public static IEnumerable<APPCATEGORYINFO> GetManagedApplicationCategories()
	{
		var h = IntPtr.Zero;
		try
		{
			GetManagedApplicationCategories(0, h).ThrowIfFailed();
			var l = h.ToStructure<APPCATEGORYINFOLIST>();
			return l.pCategoryInfo.ToArray<APPCATEGORYINFO>((int)l.cCategory) ?? new APPCATEGORYINFO[0];
		}
		finally
		{
			Kernel32.LocalFree(h);
		}
	}

	/// <summary>
	/// The <c>GetManagedApplications</c> function gets a list of applications that are displayed in the <c>Add</c> pane of <c>Add/Remove
	/// Programs</c> (ARP) for a specified user context.
	/// </summary>
	/// <param name="pCategory">
	/// <para>A pointer to a GUID that specifies the category</para>
	/// <para>
	/// of applications to be listed. If pCategory is not null, dwQueryFlags must contain <c>MANAGED_APPS_FROMCATEGORY</c>. If pCategory
	/// is null, dwQueryFlags cannot contain <c>MANAGED_APPS_FROMCATEGORY</c>.
	/// </para>
	/// </param>
	/// <param name="dwQueryFlags">
	/// <para>This parameter can contain one or more of the following values.</para>
	/// <para>MANAGED_APPS_USERAPPLICATIONS</para>
	/// <para>Lists all applications that apply to the user. The parameter pCategory must be null.</para>
	/// <para>MANAGED_APPS_FROMCATEGORY</para>
	/// <para>Lists only applications in the category specified by pCategory. The pCategory parameter cannot be null.</para>
	/// </param>
	/// <param name="dwInfoLevel">This parameter must be <c>MANAGED_APPS_INFOLEVEL_DEFAULT</c>.</param>
	/// <param name="pdwApps">The count of applications in the list returned by this function.</param>
	/// <param name="prgManagedApps">
	/// This parameter is a pointer to an array of MANAGEDAPPLICATION structures. This array contains the list of applications listed in
	/// the <c>Add</c> pane of <c>Add/Remove Programs</c> (ARP). You must call <c>LocalFree</c> to free the array when they array is no
	/// longer required.
	/// </param>
	/// <returns>
	/// If the function succeeds, the return value is <c>ERROR_SUCCESS</c>. Otherwise, the function returns one of the system error
	/// codes. For a complete list of error codes, see System Error Codes or the header file WinError.h.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/appmgmt/nf-appmgmt-getmanagedapplications DWORD GetManagedApplications( GUID
	// *pCategory, DWORD dwQueryFlags, DWORD dwInfoLevel, LPDWORD pdwApps, PMANAGEDAPPLICATION *prgManagedApps );
	[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("appmgmt.h", MSDNShortId = "62e32f36-cbb2-4557-9773-8bd454870d55")]
	public static extern Win32Error GetManagedApplications(IntPtr pCategory, MANAGED_APPQUERY dwQueryFlags, uint dwInfoLevel, out uint pdwApps, out SafeLocalHandle prgManagedApps);

	/// <summary>
	/// The <c>GetManagedApplications</c> function gets a list of applications that are displayed in the <c>Add</c> pane of
	/// <c>Add/Remove Programs</c> (ARP) for a specified user context.
	/// </summary>
	/// <param name="pCategory">
	/// <para>A pointer to a GUID that specifies the category</para>
	/// <para>
	/// of applications to be listed. If pCategory is not null, dwQueryFlags must contain <c>MANAGED_APPS_FROMCATEGORY</c>. If pCategory
	/// is null, dwQueryFlags cannot contain <c>MANAGED_APPS_FROMCATEGORY</c>.
	/// </para>
	/// </param>
	/// <returns>
	/// A sequence of MANAGEDAPPLICATION structures. This array contains the list of applications listed in the <c>Add</c> pane of
	/// <c>Add/Remove Programs</c> (ARP).
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/desktop/api/appmgmt/nf-appmgmt-getmanagedapplications DWORD GetManagedApplications( GUID
	// *pCategory, DWORD dwQueryFlags, DWORD dwInfoLevel, LPDWORD pdwApps, PMANAGEDAPPLICATION *prgManagedApps );
	[PInvokeData("appmgmt.h", MSDNShortId = "62e32f36-cbb2-4557-9773-8bd454870d55")]
	public static IEnumerable<MANAGEDAPPLICATION> GetManagedApplications(Guid? pCategory)
	{
		using SafeCoTaskMemStruct<Guid> pGuid = pCategory;
		GetManagedApplications(pGuid, pCategory.HasValue ? MANAGED_APPQUERY.MANAGED_APPS_FROMCATEGORY : MANAGED_APPQUERY.MANAGED_APPS_USERAPPLICATIONS, MANAGED_APPS_INFOLEVEL_DEFAULT, out var c, out var h).ThrowIfFailed();
		return h.ToArray<MANAGEDAPPLICATION>((int)c);
	}

	/// <summary>
	/// The <c>InstallApplication</c> function can install applications that have been deployed to target users that belong to a domain.
	/// The security context of the user that is calling <c>InstallApplication</c> must be that of a domain user logged onto a computer
	/// in a domain that trusts the target user's domain. Group Policy must be successfully applied when the target user logs on.
	/// </summary>
	/// <param name="pInstallInfo">A pointer to a INSTALLDATA structure that specifies the application to install.</param>
	/// <returns>
	/// If the function succeeds, the return value is <c>ERROR_SUCCESS</c>. Otherwise, the function returns one of the system error
	/// codes. For a complete list of error codes, see System Error Codes or the header file WinError.h.
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>InstallApplication</c> function can only install applications that have been deployed by using Group Policy. A domain
	/// administrator can deploy applications to target users by using the user configuration section of Group Policy Objects (GPO). The
	/// target user must belong to the target domain and the GPO must apply to this user in the target domain. The
	/// <c>InstallApplication</c> function installs applications according to standard Group Policy inheritance rules. If the same
	/// application is deployed in multiple GPOs, the function installs the version of the application deployed in the highest precedence
	/// GPO. After an application has been installed for a user, it is not visible to other users on the computer. This is standard for
	/// applications that are deployed through user group policy.
	/// </para>
	/// <para>
	/// The <c>InstallApplication</c> function can install deployed applications that use Windows Installer (.msi files) or software
	/// installation settings (.zap files) to handle setup and installation.
	/// </para>
	/// <para>
	/// The <c>InstallApplication</c> function can install applications that use a Windows Installer package for their installation. In
	/// this case, the user calling <c>InstallApplication</c> is not required to have administrator privileges. The system can install
	/// the application because the Windows Installer is a trusted application deployed by a domain administrator. The user that receives
	/// the application must have access to the location of the .msi files.
	/// </para>
	/// <para>
	/// Remove applications installed using .msi files by calling the Windows Installer function MsiConfigureProduct to uninstall the
	/// application. Then call UninstallApplication to inform the system that the application is no longer managed on the client by Group
	/// Policy. <c>UninstallApplication</c> should be called even if the uninstall fails because this enables the system to keep the
	/// Resultant Set of Policy (RSoP) accurate.
	/// </para>
	/// <para>
	/// The <c>InstallApplication</c> function can also install applications that use setup applications based on software installation
	/// settings (.zap files). The user that receives the application must have access to the location of the .zap files. A .zap file is
	/// a text file similar to an .ini file, which enables Windows to publish an application (for example, Setup.exe) for installation
	/// with <c>Add or Remove Programs</c>. To publish applications that do not use the Windows Installer, you must create a .zap file,
	/// copy the .zap file to the software distribution point servers, and then use Group Policy–based software deployment to publish the
	/// application for users. If the application is deployed using .zap files, the user installing the application must have privileges
	/// on the machine to install the software. You cannot use .zap files for assigned applications.
	/// </para>
	/// <para>
	/// Remove applications using software installation settings (.zap files) by calling the uninstall function or a command specific for
	/// the installation application.
	/// </para>
	/// <para>
	/// For information about using installation applications other than the Windows Installer see article 231747, "How to Publish
	/// non-MSI Programs with .zap Files," in the Microsoft Knowledge Base.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/appmgmt/nf-appmgmt-installapplication DWORD InstallApplication( PINSTALLDATA
	// pInstallInfo );
	[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("appmgmt.h", MSDNShortId = "5b2e1d82-a421-42af-9e1b-391ae9d4813e")]
	public static extern Win32Error InstallApplication(in INSTALLDATA pInstallInfo);

	/// <summary>
	/// <para>
	/// The <c>UninstallApplication</c> function uninstalls a group policy application that handles setup and installation using Windows
	/// Installer .msi files. The <c>UninstallApplication</c> function should only be called in the context of the user for whom the user
	/// group policy application has previously attempted an uninstall by calling the MsiConfigureProduct function. The
	/// InstallApplication function can install group policy applications.
	/// </para>
	/// <para>
	/// <c>Note</c> Failure to call <c>UninstallApplication</c> as part of the protocol for uninstalling a group policy-based application
	/// can cause the Resultant Set of Policy (RSoP) to indicate inaccurate information.
	/// </para>
	/// </summary>
	/// <param name="ProductCode">
	/// The Windows Installer product code of the product being uninstalled. The product code of the application should be provided in
	/// the form of a Windows Installer GUID as a string with braces.
	/// </param>
	/// <param name="dwStatus">
	/// The status of the uninstall attempt. The dwStatus parameter is the Windows success code of the uninstall attempt returned by
	/// MsiConfigureProduct. The system can use this to ensure that the Resultant Set of Policy (RSoP) indicates whether the uninstall
	/// failed or succeeded.
	/// </param>
	/// <returns>
	/// If the function succeeds, the return value is <c>ERROR_SUCCESS</c>. Otherwise, the function returns one of the system error
	/// codes. For a complete list of error codes, see System Error Codes or the header file WinError.h.
	/// </returns>
	/// <remarks>
	/// <para>
	/// Remove a group policy application that uses .msi files by calling the Windows Installer function MsiConfigureProduct to uninstall
	/// the application. Then call <c>UninstallApplication</c> to inform the system that the application is no longer managed on the
	/// client by Group Policy. <c>UninstallApplication</c> should be called even if the uninstall fails because this enables the system
	/// to keep the Resultant Set of Policy (RSoP) accurate.
	/// </para>
	/// <para>
	/// Remove applications installed using software installation settings (.zap files) by calling the uninstall function or command
	/// specific for the installation application. For information about using installation applications other than the Windows Installer
	/// see article 231747, "How to Publish non-MSI Programs with .zap Files," in the Microsoft Knowledge Base.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/appmgmt/nf-appmgmt-uninstallapplication DWORD UninstallApplication( PWSTR
	// ProductCode, DWORD dwStatus );
	[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("appmgmt.h", MSDNShortId = "d45494e2-d86e-4d94-a158-4024eacf46a2")]
	public static extern Win32Error UninstallApplication([MarshalAs(UnmanagedType.LPWStr)] string ProductCode, Win32Error dwStatus);

	/// <summary>
	/// Provides application category information to Add/Remove Programs in Control Panel. The APPCATEGORYINFOLIST structure is used
	/// create a complete list of categories for an application publisher.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/appmgmt/ns-appmgmt-appcategoryinfo typedef struct _APPCATEGORYINFO { LCID
	// Locale; PWSTR pszDescription; GUID AppCategoryId; } APPCATEGORYINFO;
	[PInvokeData("appmgmt.h", MSDNShortId = "7a0e61cb-97f8-4ca2-a85a-889e671099d0")]
	[StructLayout(LayoutKind.Sequential)]
	public struct APPCATEGORYINFO
	{
		/// <summary>
		/// <para>Type: <c>LCID</c></para>
		/// <para>Unused.</para>
		/// </summary>
		public LCID Locale;

		/// <summary>
		/// <para>Type: <c>PWSTR</c></para>
		/// <para>
		/// A pointer to a string containing the display name of the category. This string displays in the <c>Category</c> list in
		/// Add/Remove Programs. This string buffer must be allocated using CoTaskMemAlloc and freed using CoTaskMemFree.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pszDescription;

		/// <summary>
		/// <para>Type: <c>GUID</c></para>
		/// <para>A GUID identifying the application category.</para>
		/// </summary>
		public Guid AppCategoryId;
	}

	/// <summary>
	/// Provides a list of supported application categories from an application publisher to Add/Remove Programs in Control Panel.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/appmgmt/ns-appmgmt-appcategoryinfolist typedef struct _APPCATEGORYINFOLIST {
	// DWORD cCategory; APPCATEGORYINFO *pCategoryInfo; } APPCATEGORYINFOLIST;
	[PInvokeData("appmgmt.h", MSDNShortId = "c590d9ab-ab41-4192-a6c2-c6c2c931e873")]
	[StructLayout(LayoutKind.Sequential)]
	public struct APPCATEGORYINFOLIST
	{
		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>A value of type <c>DWORD</c> that specifies the count of APPCATEGORYINFO elements in the array pointed to by <c>pCategoryInfo</c>.</para>
		/// </summary>
		public uint cCategory;

		/// <summary>
		/// <para>Type: <c>APPCATEGORYINFO*</c></para>
		/// <para>
		/// A pointer to an array of APPCATEGORYINFO structures. This array contains all the categories an application publisher supports
		/// and must be allocated using CoTaskMemAlloc and freed using CoTaskMemFree.
		/// </para>
		/// </summary>
		public IntPtr pCategoryInfo;
	}

	/// <summary>The <c>INSTALLDATA</c> structure specifies a group-policy application to be installed by InstallApplication.</summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/appmgmt/ns-appmgmt-_installdata typedef struct _INSTALLDATA { INSTALLSPECTYPE
	// Type; INSTALLSPEC Spec; } INSTALLDATA, *PINSTALLDATA;
	[PInvokeData("appmgmt.h", MSDNShortId = "0c0570c6-f8f5-41e1-a1d2-d4e8c450f73c")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
	public struct INSTALLDATA
	{
		/// <summary>
		/// Defines how <c>Spec</c> specifies the application to InstallApplication. <c>Type</c> can be one of the INSTALLSPECTYPE
		/// enumeration values. Set <c>Type</c> to APPNAME to install an application specified by its user-friendly name and GPO GUID.
		/// Set <c>Type</c> to FILEEXT to install an application specified by its file name extension.
		/// </summary>
		public INSTALLSPECTYPE Type;

		/// <summary>An INSTALLSPEC structure that specifies the application.</summary>
		public INSTALLSPEC Spec;
	}

	/// <summary>
	/// The <c>INSTALLSPEC</c> structure specifies a group policy application by its user-friendly name and group policy GUID or by its
	/// file name extension. The <c>Spec</c> member of the INSTALLDATA structure provides this information to the InstallApplication function.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/appmgmt/ns-appmgmt-_installspec typedef union _INSTALLSPEC { struct { WCHAR
	// *Name; GUID GPOId; } AppName; WCHAR *FileExt; WCHAR *ProgId; struct { GUID Clsid; DWORD ClsCtx; } COMClass; } INSTALLSPEC;
	[PInvokeData("appmgmt.h", MSDNShortId = "e9c1b943-9cb0-480f-8ab7-0f439087216a")]
	[StructLayout(LayoutKind.Explicit)]
	public struct INSTALLSPEC
	{
		/// <summary>Structure that contains the following members.</summary>
		[FieldOffset(0)]
		public APPNAME AppName;

		/// <summary>
		/// <para>The file name extension, such as .jpg, of the application to be installed.</para>
		/// <para>
		/// <c>Note</c> InstallApplication fails if the <c>Type</c> member of INSTALLDATA equals <c>FILEEXT</c> and there is no
		/// application deployed to the user with this file name extension.
		/// </para>
		/// </summary>
		[FieldOffset(0)]
		public PWSTR FileExt;

		/// <summary/>
		[FieldOffset(0)]
		public PWSTR ProgId;

		/// <summary/>
		[FieldOffset(0)]
		public COMCLASS COMClass;

		/// <summary>Structure that contains the following members.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct APPNAME
		{
			/// <summary>
			/// The user-friendly name of the application as it appears in <c>Add or Remove Programs</c> and the Group Policy Object
			/// Editor. You can obtain the name by calling GetManagedApplications.
			/// </summary>
			public PWSTR Name;

			/// <summary>
			/// The <c>GUID</c> for the group policy object in which the application exists. You can obtain the group policy object
			/// <c>GUID</c> by calling GetManagedApplications.
			/// </summary>
			public Guid GPOId;
		}

		/// <summary>Structure that contains the following members.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct COMCLASS
		{
			/// <summary/>
			public Guid Clsid;

			/// <summary/>
			public uint ClsCtx;
		}
	}

	/// <summary>
	/// The <c>LOCALMANAGEDAPPLICATION</c> structure describes a managed application installed for a user or a computer. Returned by the
	/// GetLocalManagedApplications function.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/appmgmt/ns-appmgmt-_localmanagedapplication typedef struct
	// _LOCALMANAGEDAPPLICATION { PWSTR pszDeploymentName; PWSTR pszPolicyName; PWSTR pszProductId; DWORD dwState; }
	// LOCALMANAGEDAPPLICATION, *PLOCALMANAGEDAPPLICATION;
	[PInvokeData("appmgmt.h", MSDNShortId = "b2b7d209-76ee-4ba4-ac61-034d2c8e0689")]
	[StructLayout(LayoutKind.Sequential)]
	public struct LOCALMANAGEDAPPLICATION
	{
		/// <summary>
		/// This is a Unicode string that gives the user friendly name of the application as it appears in the Application Deployment
		/// Editor (ADE).
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pszDeploymentName;

		/// <summary>This is the user-friendly name of the group policy object (GPO) from which the application originates.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pszPolicyName;

		/// <summary>This is a Unicode string that gives the Windows Installer product code GUID for the application.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pszProductId;

		/// <summary>
		/// <para>Indicates the state of the installed application. This parameter can contain one or more of the following values.</para>
		/// <para>LOCAL_STATE_ASSIGNED</para>
		/// <para>The application is installed in the assigned state.</para>
		/// <para>LOCAL_STATE_PUBLISHED</para>
		/// <para>The application is installed in the published state.</para>
		/// <para>LOCAL_STATE_UNINSTALL_UNMANAGED</para>
		/// <para>The installation of this application uninstalled an unmanaged application with a conflicting transform.</para>
		/// <para>LOCAL_STATE_POLICYREMOVE_ORPHAN</para>
		/// <para>If the policy from which this application originates is removed, the application is left on the computer.</para>
		/// <para>LOCAL_STATE_POLICYREMOVE_UNINSTALL</para>
		/// <para>If the policy from which this application originates is removed, the application is uninstalled from the computer.</para>
		/// </summary>
		public uint dwState;
	}

	/// <summary>
	/// The <c>MANAGEDAPPLICATION</c> structure contains information about an application. The function GetManagedApplications returns an
	/// array of <c>MANAGEDAPPLICATION</c> structures.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/appmgmt/ns-appmgmt-managedapplication typedef struct _MANAGEDAPPLICATION {
	// PWSTR pszPackageName; PWSTR pszPublisher; DWORD dwVersionHi; DWORD dwVersionLo; DWORD dwRevision; GUID GpoId; PWSTR
	// pszPolicyName; GUID ProductId; LANGID Language; PWSTR pszOwner; PWSTR pszCompany; PWSTR pszComments; PWSTR pszContact; PWSTR
	// pszSupportUrl; DWORD dwPathType; BOOL bInstalled; } MANAGEDAPPLICATION, *PMANAGEDAPPLICATION;
	[PInvokeData("appmgmt.h", MSDNShortId = "8ac78f92-e665-4dd0-b226-6bf41dcd050a")]
	[StructLayout(LayoutKind.Sequential)]
	public struct MANAGEDAPPLICATION
	{
		/// <summary>The user-friendly name of the application.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pszPackageName;

		/// <summary>The name of the application's publisher.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pszPublisher;

		/// <summary>The major version number of the application.</summary>
		public uint dwVersionHi;

		/// <summary>The minor version number of the application.</summary>
		public uint dwVersionLo;

		/// <summary>The version number of the deployment. The version changes each time an application gets patched.</summary>
		public uint dwRevision;

		/// <summary>The GUID of the GPO from which this application is deployed.</summary>
		public Guid GpoId;

		/// <summary>The user-friendly name for the GPO from which this application is deployed.</summary>
		[MarshalAs(UnmanagedType.LPWStr)]
		public string pszPolicyName;

		/// <summary>If this application is installed by Windows Installer, this member is the ProductId GUID.</summary>
		public Guid ProductId;

		/// <summary>
		/// The numeric language identifier that indicates the language version of the application. For a list of language numeric
		/// identifiers, see the Language Identifier Constants and Strings topic.
		/// </summary>
		public ushort Language;

		/// <summary>This member is unused.</summary>
		public PWSTR pszOwner;

		/// <summary>This member is unused.</summary>
		public PWSTR pszCompany;

		/// <summary>This member is unused.</summary>
		public PWSTR pszComments;

		/// <summary>This member is unused.</summary>
		public PWSTR pszContact;

		/// <summary>This member is unused.</summary>
		public PWSTR pszSupportUrl;

		/// <summary>
		/// <para>Indicates the type of package used to install the application. This member can have one of the following values.</para>
		/// <para>MANAGED_APPTYPE_WINDOWSINSTALLER</para>
		/// <para>The application is installed using the Windows Installer.</para>
		/// <para>MANAGED_APPTYPE_SETUPEXE</para>
		/// <para>The application is installed using a legacy setup application.</para>
		/// <para>MANAGED_APPTYPE_UNSUPPORTED</para>
		/// <para>The application is installed by an unsupported setup application.</para>
		/// </summary>
		public MANAGED_APPTYPE dwPathType;

		/// <summary>This parameter is <c>TRUE</c> if the application is currently installed and is <c>FALSE</c> otherwise.</summary>
		[MarshalAs(UnmanagedType.Bool)]
		public bool bInstalled;
	}
}