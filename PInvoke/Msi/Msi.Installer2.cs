using static Vanara.PInvoke.Crypt32;

namespace Vanara.PInvoke;

/// <summary>Items from the Msi.dll</summary>
public static partial class Msi
{
	/// <summary>
	/// The <c>MsiExtractPatchXMLData</c> function extracts information from a patch that can be used to determine if the patch applies
	/// to a target system. The function returns an XML string that can be provided to MsiDeterminePatchSequence and
	/// MsiDetermineApplicablePatches instead of the full patch file. The returned information can be used to determine whether the
	/// patch is applicable.
	/// </summary>
	/// <param name="szPatchPath">
	/// The full path to the patch that is being queried. Pass in as a null-terminated string. This parameter cannot be <c>NULL</c>.
	/// </param>
	/// <param name="dwReserved">A reserved argument that must be 0 (zero).</param>
	/// <param name="szXMLData">
	/// <para>
	/// A pointer to a buffer to hold the XML string that contains the extracted patch information. This buffer should be large enough
	/// to contain the received information. If the buffer is too small, the function returns ERROR_MORE_DATA and sets *pcchXMLData to
	/// the number of <c>TCHAR</c> in the value, not including the terminating NULL character.
	/// </para>
	/// <para>
	/// If szXMLData is set to <c>NULL</c> and pcchXMLData is set to a valid pointer, the function returns ERROR_SUCCESS and sets
	/// *pcchXMLData to the number of <c>TCHAR</c> in the value, not including the terminating NULL character. The function can then be
	/// called again to retrieve the value, with szXMLData buffer large enough to contain *pcchXMLData + 1 characters.
	/// </para>
	/// </param>
	/// <param name="pcchXMLData">
	/// <para>
	/// A pointer to a variable that specifies the number of <c>TCHAR</c> in the szXMLData buffer. When the function returns, this
	/// parameter is set to the size of the requested value whether or not the function copies the value into the specified buffer. The
	/// size is returned as the number of <c>TCHAR</c> in the requested value, not including the terminating null character.
	/// </para>
	/// <para>If this parameter is set to <c>NULL</c>, the function returns ERROR_INVALID_PARAMETER.</para>
	/// </param>
	/// <returns>
	/// <para>The <c>MsiExtractPatchXMLData</c> function can return the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_FUNCTION_FAILED</term>
	/// <term>The function failed in a way that is not identified by any of the return values in this table.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>An invalid parameter was passed to the function.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>The value does not fit in the provided buffer.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_PATCH_OPEN_FAILED</term>
	/// <term>The patch file could not be opened.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SUCCESS</term>
	/// <term>The function was successful.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_PATCH_PACKAGE_INVALID</term>
	/// <term>The patch file could not be opened.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_CALL_NOT_IMPLEMENTED</term>
	/// <term>This error can be returned if MSXML 3.0 is not installed.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>The ExtractPatchXMLData method of the Installer object uses the <c>MsiExtractPatchXMLData</c> function.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msiextractpatchxmldataa UINT MsiExtractPatchXMLDataA( LPCSTR
	// szPatchPath, DWORD dwReserved, LPSTR szXMLData, LPDWORD pcchXMLData );
	[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiExtractPatchXMLDataA")]
	public static extern Win32Error MsiExtractPatchXMLData([MarshalAs(UnmanagedType.LPTStr)] string szPatchPath, [Optional] uint dwReserved,
		[Out, Optional, MarshalAs(UnmanagedType.LPTStr)] StringBuilder szXMLData, ref uint pcchXMLData);

	/// <summary>
	/// The <c>MsiGetComponentPath</c> function returns the full path to an installed component. If the key path for the component is a
	/// registry key then the registry key is returned.
	/// </summary>
	/// <param name="szProduct">Specifies the product code for the client product.</param>
	/// <param name="szComponent">Specifies the component ID of the component to be located.</param>
	/// <param name="lpPathBuf">
	/// <para>
	/// Pointer to a variable that receives the path to the component. This parameter can be null. If the component is a registry key,
	/// the registry roots are represented numerically. If this is a registry subkey path, there is a backslash at the end of the Key
	/// Path. If this is a registry value key path, there is no backslash at the end. For example, a registry path on a 32-bit operating
	/// system of <c>HKEY_CURRENT_USER</c>\ <c>SOFTWARE</c>\ <c>Microsoft</c> is returned as "01:\SOFTWARE\Microsoft". The registry
	/// roots returned on 32-bit operating systems are defined as shown in the following table.
	/// </para>
	/// <para>
	/// <c>Note</c> On 64-bit operating systems, a value of 20 is added to the numerical registry roots in this table to distinguish
	/// them from registry key paths on 32-bit operating systems. For example, a registry key path of <c>HKEY_CURRENT_USER</c>\
	/// <c>SOFTWARE</c>\ <c>Microsoft</c> is returned as "21:\SOFTWARE\Microsoft\", if the component path is a registry key on a 64-bit
	/// operating system.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Root</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>HKEY_CLASSES_ROOT</term>
	/// <term>00</term>
	/// </item>
	/// <item>
	/// <term>HKEY_CURRENT_USER</term>
	/// <term>01</term>
	/// </item>
	/// <item>
	/// <term>HKEY_LOCAL_MACHINE</term>
	/// <term>02</term>
	/// </item>
	/// <item>
	/// <term>HKEY_USERS</term>
	/// <term>03</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pcchBuf">
	/// <para>
	/// Pointer to a variable that specifies the size, in characters, of the buffer pointed to by the lpPathBuf parameter. On input,
	/// this is the full size of the buffer, including a space for a terminating null character. If the buffer passed in is too small,
	/// the count returned does not include the terminating null character.
	/// </para>
	/// <para>If lpPathBuf is null, pcchBuf can be null.</para>
	/// </param>
	/// <returns>
	/// <para>The <c>MsiGetComponentPath</c> function returns the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>INSTALLSTATE_NOTUSED</term>
	/// <term>The component being requested is disabled on the computer.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLSTATE_ABSENT</term>
	/// <term>The component is not installed.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLSTATE_INVALIDARG</term>
	/// <term>One of the function parameters is invalid.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLSTATE_LOCAL</term>
	/// <term>The component is installed locally.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLSTATE_SOURCE</term>
	/// <term>The component is installed to run from source.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLSTATE_SOURCEABSENT</term>
	/// <term>The component source is inaccessible.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLSTATE_UNKNOWN</term>
	/// <term>The product code or component ID is unknown.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>Upon success of the <c>MsiGetComponentPath</c> function, the pcchBuf parameter contains the length of the string in lpPathBuf.</para>
	/// <para>The <c>MsiGetComponentPath</c> function might return INSTALLSTATE_ABSENT or INSTALL_STATE_UNKNOWN, for the following reasons:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>INSTALLSTATE_ABSENT</term>
	/// <description>
	/// The application did not properly ensure that the feature was installed by calling MsiUseFeature and, if necessary, MsiConfigureFeature.
	/// </description>
	/// </item>
	/// <item>
	/// <term>INSTALLSTATE_UNKNOWN</term>
	/// <description>
	/// The feature is not published. The application should have determined this earlier by calling MsiQueryFeatureState or
	/// MsiEnumFeatures. The application makes these calls while it initializes. An application should only use features that are known
	/// to be published. Since INSTALLSTATE_UNKNOWN should have been returned by MsiUseFeature as well, either MsiUseFeature was not
	/// called, or its return value was not properly checked.
	/// </description>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msigetcomponentpatha INSTALLSTATE MsiGetComponentPathA( LPCSTR
	// szProduct, LPCSTR szComponent, LPSTR lpPathBuf, LPDWORD pcchBuf );
	[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiGetComponentPathA")]
	public static extern INSTALLSTATE MsiGetComponentPath([MarshalAs(UnmanagedType.LPTStr)] string szProduct,
		[MarshalAs(UnmanagedType.LPTStr)] string szComponent, [Out, Optional, MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpPathBuf,
		ref uint pcchBuf);

	/// <summary>
	/// <para>
	/// The <c>MsiGetComponentPathEx</c> function returns the full path to an installed component. If the key path for the component is
	/// a registry key then the function returns the registry key.
	/// </para>
	/// <para>
	/// This function extends the existing MsiGetComponentPath function to enable searches for components across user accounts and
	/// installation contexts.
	/// </para>
	/// </summary>
	/// <param name="szProductCode">
	/// A null-terminated string value that specifies an application's product code GUID. The function gets the path of installed
	/// components used by this application.
	/// </param>
	/// <param name="szComponentCode">
	/// A null-terminated string value that specifies a component code GUID. The function gets the path of an installed component having
	/// this component code.
	/// </param>
	/// <param name="szUserSid">
	/// <para>
	/// A null-terminated string value that specifies the security identifier (SID) for a user in the system. The function gets the
	/// paths of installed components of applications installed under the user accounts identified by this SID. The special SID string
	/// s-1-1-0 (Everyone) specifies all users in the system. If this parameter is <c>NULL</c>, the function gets the path of an
	/// installed component for the currently logged-on user only.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>SID type</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>NULL</term>
	/// <term>Specifies the currently logged-on user.</term>
	/// </item>
	/// <item>
	/// <term>User SID</term>
	/// <term>Specifies a particular user in the system. An example of an user SID is "S-1-3-64-2415071341-1358098788-3127455600-2561".</term>
	/// </item>
	/// <item>
	/// <term>s-1-1-0</term>
	/// <term>Specifies all users in the system.</term>
	/// </item>
	/// </list>
	/// <para>
	/// <c>Note</c> The special SID string s-1-5-18 (System) cannot be used to search applications installed in the per-machine
	/// installation context. Setting the SID value to s-1-5-18 returns <c>ERROR_INVALID_PARAMETER</c>. When dwContext is set to
	/// MSIINSTALLCONTEXT_MACHINE only, szUserSid must be <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="dwContext">
	/// <para>
	/// A flag that specifies the installation context. The function gets the paths of installed components of applications installed in
	/// the specified installation context. This parameter can be a combination of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Context</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MSIINSTALLCONTEXT_USERMANAGED 1</term>
	/// <term>Include applications installed in the per–user–managed installation context.</term>
	/// </item>
	/// <item>
	/// <term>MSIINSTALLCONTEXT_USERUNMANAGED 2</term>
	/// <term>Include applications installed in the per–user–unmanaged installation context.</term>
	/// </item>
	/// <item>
	/// <term>MSIINSTALLCONTEXT_MACHINE 4</term>
	/// <term>
	/// Include applications installed in the per-machine installation context. When dwInstallContext is set to
	/// MSIINSTALLCONTEXT_MACHINE only, the szUserSID parameter must be NULL.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="lpOutPathBuffer">
	/// <para>
	/// A string value that receives the path to the component. This parameter can be <c>NULL</c>. If the component is a registry key,
	/// the registry roots are represented numerically. If this is a registry subkey path, there is a backslash at the end of the Key
	/// Path. If this is a registry value key path, there is no backslash at the end. For example, a registry path on a 32-bit operating
	/// system of <c>HKEY_CURRENT_USER</c>\ <c>SOFTWARE</c>\ <c>Microsoft</c> is returned as "01:\SOFTWARE\Microsoft". The registry
	/// roots returned on 32-bit operating systems are defined as shown in the following table.
	/// </para>
	/// <para>
	/// <c>Note</c> On 64-bit operating systems, a value of 20 is added to the numerical registry roots in this table to distinguish
	/// them from registry key paths on 32-bit operating systems. For example, a registry key path of <c>HKEY_CURRENT_USER</c>\
	/// <c>SOFTWARE</c>\ <c>Microsoft</c> is returned as "21:\SOFTWARE\Microsoft\", if the component path is a registry key on a 64-bit
	/// operating system.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Root</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>HKEY_CLASSES_ROOT</term>
	/// <term>00</term>
	/// </item>
	/// <item>
	/// <term>HKEY_CURRENT_USER</term>
	/// <term>01</term>
	/// </item>
	/// <item>
	/// <term>HKEY_LOCAL_MACHINE</term>
	/// <term>02</term>
	/// </item>
	/// <item>
	/// <term>HKEY_USERS</term>
	/// <term>03</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pcchOutPathBuffer">
	/// Pointer to a location that receives the size of the buffer, in <c>TCHAR</c>, pointed to by the szPathBuf parameter. The value in
	/// this location should be set to the count of <c>TCHAR</c> in the string including the terminating null character. If the size of
	/// the buffer is too small, this parameter receives the length of the string value without including the terminating null character
	/// in the count.
	/// </param>
	/// <returns>
	/// <para>The <c>MsiGetComponentPathEx</c> function returns the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>INSTALLSTATE_NOTUSED</term>
	/// <term>The component being requested is disabled on the computer.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLSTATE_BADCONFIG</term>
	/// <term>Configuration data is corrupt.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLSTATE_ABSENT</term>
	/// <term>The component is not installed.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLSTATE_INVALIDARG</term>
	/// <term>One of the function parameters is invalid.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLSTATE_LOCAL</term>
	/// <term>The component is installed locally.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLSTATE_SOURCE</term>
	/// <term>The component is installed to run from source.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLSTATE_SOURCEABSENT</term>
	/// <term>The component source is inaccessible.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLSTATE_UNKNOWN</term>
	/// <term>The product code or component ID is unknown.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLSTATE_BROKEN</term>
	/// <term>The component is corrupt or partially missing in some way and requires repair.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>MsiGetComponentPathEx</c> function might return <c>INSTALLSTATE_ABSENT</c> or <c>INSTALL_STATE_UNKNOWN</c>, for the
	/// following reasons:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>INSTALLSTATE_ABSENT</term>
	/// </item>
	/// <item>
	/// <term>INSTALLSTATE_UNKNOWN</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msigetcomponentpathexa INSTALLSTATE MsiGetComponentPathExA( LPCSTR
	// szProductCode, LPCSTR szComponentCode, LPCSTR szUserSid, MSIINSTALLCONTEXT dwContext, LPSTR lpOutPathBuffer, LPDWORD
	// pcchOutPathBuffer );
	[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiGetComponentPathExA")]
	public static extern INSTALLSTATE MsiGetComponentPathEx([MarshalAs(UnmanagedType.LPTStr)] string szProductCode,
		[MarshalAs(UnmanagedType.LPTStr)] string szComponentCode, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? szUserSid,
		[Optional] MSIINSTALLCONTEXT dwContext, [Out, Optional, MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpOutPathBuffer,
		ref uint pcchOutPathBuffer);

	/// <summary>The <c>MsiGetFeatureInfo</c> function returns descriptive information for a feature.</summary>
	/// <param name="hProduct">Handle to the product that owns the feature. This handle is obtained from MsiOpenProduct.</param>
	/// <param name="szFeature">Feature code for the feature about which information should be returned.</param>
	/// <param name="lpAttributes">
	/// <para>Pointer to a location containing one or more of the following Attribute flags.</para>
	/// <para>INSTALLFEATUREATTRIBUTE_FAVORLOCAL (1)</para>
	/// <para>INSTALLFEATUREATTRIBUTE_FAVORSOURCE (2)</para>
	/// <para>INSTALLFEATUREATTRIBUTE_FOLLOWPARENT (4)</para>
	/// <para>INSTALLFEATUREATTRIBUTE_FAVORADVERTISE (8)</para>
	/// <para>INSTALLFEATUREATTRIBUTE_DISALLOWADVERTISE (16)</para>
	/// <para>INSTALLFEATUREATTRIBUTE_NOUNSUPPORTEDADVERTISE (32)</para>
	/// <para>
	/// For more information, see Feature Table. The values that <c>MsiGetFeatureInfo</c> returns are double the values in the
	/// Attributes column of the Feature Table.
	/// </para>
	/// </param>
	/// <param name="lpTitleBuf">
	/// <para>
	/// Pointer to a buffer to receive the localized name of the feature, which corresponds to the Title field in the Feature Table.
	/// </para>
	/// <para>This parameter is optional and can be null.</para>
	/// </param>
	/// <param name="pcchTitleBuf">
	/// As input, the size of lpTitleBuf. As output, the number of characters returned in lpTitleBuf. On input, this is the full size of
	/// the buffer, and includes a space for a terminating null character. If the buffer that is passed in is too small, the count
	/// returned does not include the terminating null character.
	/// </param>
	/// <param name="lpHelpBuf">
	/// Pointer to a buffer to receive the localized description of the feature, which corresponds to the Description field for the
	/// feature in the Feature table. This parameter is optional and can be null.
	/// </param>
	/// <param name="pcchHelpBuf">
	/// As input, the size of lpHelpBuf. As output, the number of characters returned in lpHelpBuf. On input, this is the full size of
	/// the buffer, and includes a space for a terminating null character. If the buffer passed in is too small, the count returned does
	/// not include the terminating null character.
	/// </param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>The product handle is invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>One of the parameters is invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>A buffer is too small to hold the requested data.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SUCCESS</term>
	/// <term>The function returns successfully.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNKNOWN_FEATURE</term>
	/// <term>The feature is not known.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// The buffer sizes for the <c>MsiGetFeatureInfo</c> function should include an extra character for the terminating null character.
	/// If a buffer is too small, the returned string is truncated with null, and the buffer size contains the number of characters in
	/// the whole string, not including the terminating null character. For more information, see Calling Database Functions From Programs.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msigetfeatureinfow UINT MsiGetFeatureInfoW( MSIHANDLE hProduct,
	// LPCWSTR szFeature, LPDWORD lpAttributes, LPWSTR lpTitleBuf, LPDWORD pcchTitleBuf, LPWSTR lpHelpBuf, LPDWORD pcchHelpBuf );
	[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiGetFeatureInfoW")]
	public static extern Win32Error MsiGetFeatureInfo(MSIHANDLE hProduct, [MarshalAs(UnmanagedType.LPTStr)] string szFeature,
		out INSTALLFEATUREATTRIBUTE lpAttributes, [Out, Optional, MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpTitleBuf,
		ref uint pcchTitleBuf, [Out, Optional, MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpHelpBuf, ref uint pcchHelpBuf);

	/// <summary>The <c>MsiGetFeatureUsage</c> function returns the usage metrics for a product feature.</summary>
	/// <param name="szProduct">Specifies the product code for the product that contains the feature.</param>
	/// <param name="szFeature">Specifies the feature code for the feature for which metrics are to be returned.</param>
	/// <param name="pdwUseCount">Indicates the number of times the feature has been used.</param>
	/// <param name="pwDateUsed">
	/// <para>Specifies the date that the feature was last used. The date is in the MS-DOS date format, as shown in the following table.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Bits</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>0 – 4</term>
	/// <term>Day of the month (1-31)</term>
	/// </item>
	/// <item>
	/// <term>5 – 8</term>
	/// <term>Month (1 = January, 2 = February, and so on)</term>
	/// </item>
	/// <item>
	/// <term>9 – 15</term>
	/// <term>Year offset from 1980 (add 1980 to get actual year)</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>The <c>MsiGetFeatureUsage</c> function returns the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_BAD_CONFIGURATION</term>
	/// <term>The configuration data is corrupt.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSTALL_FAILURE</term>
	/// <term>No usage information is available or the product or feature is invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SUCCESS</term>
	/// <term>The function completed successfully.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks/>
	// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msigetfeatureusagew UINT MsiGetFeatureUsageW( LPCWSTR szProduct,
	// LPCWSTR szFeature, LPDWORD pdwUseCount, LPWORD pwDateUsed );
	[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiGetFeatureUsageW")]
	public static extern Win32Error MsiGetFeatureUsage([MarshalAs(UnmanagedType.LPTStr)] string szProduct,
		[MarshalAs(UnmanagedType.LPTStr)] string szFeature, out uint pdwUseCount, out ushort pwDateUsed);

	/// <summary>
	/// <para>
	/// The <c>MsiGetFileHash</c> function takes the path to a file and returns a 128-bit hash of that file. Authoring tools may use
	/// <c>MsiGetFileHash</c> to obtain the file hash needed to populate the MsiFileHash table.
	/// </para>
	/// <para>
	/// Windows Installer uses file hashing as a means to detect and eliminate unnecessary file copying. A file hash stored in the
	/// MsiFileHash table may be compared to a hash of an existing file on the user's computer.
	/// </para>
	/// </summary>
	/// <param name="szFilePath">Path to file that is to be hashed.</param>
	/// <param name="dwOptions">The value in this column must be 0. This parameter is reserved for future use.</param>
	/// <param name="pHash">Pointer to the returned file hash information.</param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_SUCCESS</term>
	/// <term>The function completed successfully.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_FILE_NOT_FOUND</term>
	/// <term>The file does not exist.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>The file could not be opened to get version information.</term>
	/// </item>
	/// <item>
	/// <term>E_FAIL</term>
	/// <term>Unexpected error has occurred.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The entire 128-bit file hash is returned as four 32-bit fields. The numbering of the four fields is zero-based. The values
	/// returned by <c>MsiGetFileHash</c> correspond to the four fields of the MSIFILEHASHINFO structure. The first field corresponds to
	/// the HashPart1 column of the MsiFileHash table, the second field corresponds to the HashPart2 column, the third field corresponds
	/// to the HashPart3 column, and the fourth field corresponds to the HashPart4 column.
	/// </para>
	/// <para>
	/// The hash information entered into the MsiFileHash table must be obtained by calling <c>MsiGetFileHash</c> or the FileHash
	/// method. Do not attempt to use other methods to generate the file hash.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msigetfilehasha UINT MsiGetFileHashA( LPCSTR szFilePath, DWORD
	// dwOptions, PMSIFILEHASHINFO pHash );
	[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiGetFileHashA")]
	public static extern Win32Error MsiGetFileHash([MarshalAs(UnmanagedType.LPTStr)] string szFilePath, [Optional] uint dwOptions, ref MSIFILEHASHINFO pHash);

	/// <summary>
	/// <para>
	/// The <c>MsiGetFileSignatureInformation</c> function takes the path to a file that has been digitally signed and returns the
	/// file's signer certificate and hash. <c>MsiGetFileSignatureInformation</c> may be called to obtain the signer certificate and
	/// hash needed to populate the MsiDigitalCertificate, MsiPatchCertificate, and MsiDigitalSignature tables.
	/// </para>
	/// <para>
	/// <c>Windows Installer 3.0 and later:</c> Beginning with Windows Installer 3.0, the Windows Installer can verify the digital
	/// signatures of patches (.msp files) by using the MsiPatchCertificate and MsiDigitalCertificate tables. For more information see
	/// Guidelines for Authoring Secure Installations and User Account Control (UAC) Patching.
	/// </para>
	/// <para>
	/// <c>Windows Installer 2.0:</c> Digital signatures of patches is not supported. Windows Installer 2.0 uses digital signatures as a
	/// means to detect corrupted resources, and can only verify the digital signatures of external cabinets, and only by the use of the
	/// MsiDigitalSignature and MsiDigitalCertificate tables.
	/// </para>
	/// </summary>
	/// <param name="szSignedObjectPath">
	/// Pointer to a null-terminated string specifying the full path to the file that contains the digital signature.
	/// </param>
	/// <param name="dwFlags">
	/// <para>Special error case flags.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Flag</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MSI_INVALID_HASH_IS_FATAL 0x1</term>
	/// <term>
	/// Without this flag set, and when requesting only the certificate context, an invalid hash in the digital signature does not cause
	/// MsiGetFileSignatureInformation to return a fatal error. To return a fatal error for an invalid hash, set the
	/// MSI_INVALID_HASH_IS_FATAL flag.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="ppcCertContext">Returned signer certificate context</param>
	/// <param name="pbHashData">Returned hash buffer. This parameter can be <c>NULL</c> if the hash data is not being requested.</param>
	/// <param name="pcbHashData">
	/// Pointer to a variable that specifies the size, in bytes, of the buffer pointed to by the pbHashData parameter. This parameter
	/// cannot be <c>NULL</c> if pbHashData is non- <c>NULL</c>. If ERROR_MORE_DATA is returned, pbHashData gives the size of the buffer
	/// required to hold the hash data. If ERROR_SUCCESS is returned, it gives the number of bytes written to the hash buffer. The
	/// pcbHashData parameter is ignored if pbHashData is <c>NULL</c>.
	/// </param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_SUCCESS/S_OK</term>
	/// <term>Successful completion.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>Invalid parameter was specified.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_FUNCTION_FAILED</term>
	/// <term>
	/// WinVerifyTrust is not available on the system. MsiGetFileSignatureInformation requires the presence of the Wintrust.dll file on
	/// the system.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>
	/// A buffer is too small to hold the requested data. If ERROR_MORE_DATA is returned, pcbHashData gives the size of the buffer
	/// required to hold the hash data.
	/// </term>
	/// </item>
	/// <item>
	/// <term>TRUST_E_NOSIGNATURE</term>
	/// <term>File is not signed</term>
	/// </item>
	/// <item>
	/// <term>TRUST_E_BAD_DIGEST</term>
	/// <term>The file's current hash is invalid according to the hash stored in the file's digital signature.</term>
	/// </item>
	/// <item>
	/// <term>CERT_E_REVOKED</term>
	/// <term>The file's signer certificate has been revoked. The file's digital signature is compromised.</term>
	/// </item>
	/// <item>
	/// <term>TRUST_E_SUBJECT_NOT_TRUSTED</term>
	/// <term>
	/// The subject failed the specified verification action. Most trust providers return a more detailed error code that describes the
	/// reason for the failure.
	/// </term>
	/// </item>
	/// <item>
	/// <term>TRUST_E_PROVIDER_UNKNOWN</term>
	/// <term>The trust provider is not recognized on this system.</term>
	/// </item>
	/// <item>
	/// <term>TRUST_E_ACTION_UNKNOWN</term>
	/// <term>The trust provider does not support the specified action.</term>
	/// </item>
	/// <item>
	/// <term>TRUST_E_SUBJECT_FORM_UNKNOWN</term>
	/// <term>The trust provider does not support the form specified for the subject.</term>
	/// </item>
	/// </list>
	/// <para>
	/// <c>MsiGetFileSignatureInformation</c> also returns all the Win32 error values mapped to their equivalent <c>HRESULT</c> data
	/// type by <c>HRESULT_FROM_WIN32</c>.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// When requesting only the certificate context, an invalid hash in the digital signature does not cause
	/// <c>MsiGetFileSignatureInformation</c> to return a fatal error. To return a fatal error for an invalid hash, set the
	/// MSI_INVALID_HASH_IS_FATAL flag in the dwFlags parameter.
	/// </para>
	/// <para>
	/// The certificate context and hash information is extracted from the file by a call to WinVerifyTrust. The ppcCertContext
	/// parameter is a duplicate of the signer certificate context from the signature. It is the responsibility of the caller to call
	/// CertFreeCertificateContext to free the certificate context when finished.
	/// </para>
	/// <para>Note that <c>MsiGetFileSignatureInformation</c> requires the presence of the Wintrust.dll file on the system.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msigetfilesignatureinformationw HRESULT
	// MsiGetFileSignatureInformationW( LPCWSTR szSignedObjectPath, DWORD dwFlags, PCCERT_CONTEXT *ppcCertContext, LPBYTE pbHashData,
	// LPDWORD pcbHashData );
	[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiGetFileSignatureInformationW")]
	public static extern HRESULT MsiGetFileSignatureInformation([MarshalAs(UnmanagedType.LPTStr)] string szSignedObjectPath,
		MSISIGINFO dwFlags, out SafePCCERT_CONTEXT ppcCertContext, [Out, Optional] IntPtr pbHashData, ref uint pcbHashData);

	/// <summary>
	/// The <c>MsiGetFileVersion</c> returns the version string and language string in the format that the installer expects to find
	/// them in the database. If you want only version information, set lpLangBuf and pcchLangBuf to 0 (zero). If you just want language
	/// information, set lpVersionBuf and pcchVersionBuf to 0 (zero).
	/// </summary>
	/// <param name="szFilePath">Specifies the path to the file.</param>
	/// <param name="lpVersionBuf">
	/// <para>Returns the file version.</para>
	/// <para>Set to 0 for language information only.</para>
	/// </param>
	/// <param name="pcchVersionBuf">
	/// <para>In and out buffer count as the number of <c>TCHAR</c>.</para>
	/// <para>
	/// Set to 0 (zero) for language information only. On input, this is the full size of the buffer, including a space for a
	/// terminating null character. If the buffer passed in is too small, the count returned does not include the terminating null character.
	/// </para>
	/// </param>
	/// <param name="lpLangBuf">
	/// <para>Returns the file language.</para>
	/// <para>Set to 0 (zero) for version information only.</para>
	/// </param>
	/// <param name="pcchLangBuf">
	/// <para>In and out buffer count as the number of <c>TCHAR</c>.</para>
	/// <para>
	/// Set to 0 (zero) for version information only. On input, this is the full size of the buffer, including a space for a terminating
	/// null character. If the buffer passed in is too small, the count returned does not include the terminating null character.
	/// </para>
	/// </param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_SUCCESS</term>
	/// <term>Successful completion.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_FILE_NOT_FOUND</term>
	/// <term>File does not exist.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>File cannot be opened to get version information.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_FILE_INVALID</term>
	/// <term>File does not contain version information.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_DATA</term>
	/// <term>The version information is invalid.</term>
	/// </item>
	/// <item>
	/// <term>E_FAIL</term>
	/// <term>Unexpected error.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks/>
	// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msigetfileversiona UINT MsiGetFileVersionA( LPCSTR szFilePath,
	// LPSTR lpVersionBuf, LPDWORD pcchVersionBuf, LPSTR lpLangBuf, LPDWORD pcchLangBuf );
	[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiGetFileVersionA")]
	public static extern Win32Error MsiGetFileVersion([MarshalAs(UnmanagedType.LPTStr)] string szFilePath,
		[Out, Optional, MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpVersionBuf, ref uint pcchVersionBuf,
		[Out, Optional, MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpLangBuf, ref uint pcchLangBuf);

	/// <summary>
	/// The <c>MsiGetFileVersion</c> returns the version string and language string in the format that the installer expects to find
	/// them in the database. If you want only version information, set lpLangBuf and pcchLangBuf to 0 (zero). If you just want language
	/// information, set lpVersionBuf and pcchVersionBuf to 0 (zero).
	/// </summary>
	/// <param name="szFilePath">Specifies the path to the file.</param>
	/// <param name="lpVersionBuf">
	/// <para>Returns the file version.</para>
	/// <para>Set to 0 for language information only.</para>
	/// </param>
	/// <param name="pcchVersionBuf">
	/// <para>In and out buffer count as the number of <c>TCHAR</c>.</para>
	/// <para>
	/// Set to 0 (zero) for language information only. On input, this is the full size of the buffer, including a space for a
	/// terminating null character. If the buffer passed in is too small, the count returned does not include the terminating null character.
	/// </para>
	/// </param>
	/// <param name="lpLangBuf">
	/// <para>Returns the file language.</para>
	/// <para>Set to 0 (zero) for version information only.</para>
	/// </param>
	/// <param name="pcchLangBuf">
	/// <para>In and out buffer count as the number of <c>TCHAR</c>.</para>
	/// <para>
	/// Set to 0 (zero) for version information only. On input, this is the full size of the buffer, including a space for a terminating
	/// null character. If the buffer passed in is too small, the count returned does not include the terminating null character.
	/// </para>
	/// </param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_SUCCESS</term>
	/// <term>Successful completion.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_FILE_NOT_FOUND</term>
	/// <term>File does not exist.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>File cannot be opened to get version information.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_FILE_INVALID</term>
	/// <term>File does not contain version information.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_DATA</term>
	/// <term>The version information is invalid.</term>
	/// </item>
	/// <item>
	/// <term>E_FAIL</term>
	/// <term>Unexpected error.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks/>
	// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msigetfileversiona UINT MsiGetFileVersionA( LPCSTR szFilePath,
	// LPSTR lpVersionBuf, LPDWORD pcchVersionBuf, LPSTR lpLangBuf, LPDWORD pcchLangBuf );
	[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiGetFileVersionA")]
	public static extern Win32Error MsiGetFileVersion([MarshalAs(UnmanagedType.LPTStr)] string szFilePath,
		[Out, Optional, MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpVersionBuf, [In, Optional] IntPtr pcchVersionBuf,
		[Out, Optional, MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpLangBuf, [In, Optional] IntPtr pcchLangBuf);

	/// <summary>
	/// The <c>MsiGetPatchFileList</c> function is provided a list of .msp files, delimited by semicolons, and retrieves the list of
	/// files that can be updated by the patches.
	/// </summary>
	/// <param name="szProductCode">
	/// A null-terminated string value containing the ProductCode (GUID) of the product which is the target of the patches. This
	/// parameter cannot be <c>NULL</c>.
	/// </param>
	/// <param name="szPatchPackages">
	/// A null-terminated string value that contains the list of Windows Installer patches (.msp files). Each patch can be specified by
	/// the full path to the patch package. The patches in the list are delimited by semicolons. At least one patch must be specified.
	/// </param>
	/// <param name="pcFiles">
	/// A pointer to a location that receives the number of files that will be updated on this system by this list of patches specified
	/// by szPatchList. This parameter is required.
	/// </param>
	/// <param name="pphFileRecords">
	/// A pointer to a location that receives a pointer to an array of records. The first field (0-index) of each record contains the
	/// full file path of a file that can be updated when the list of patches in szPatchList are applied on this computer. This
	/// parameter is required.
	/// </param>
	/// <returns>
	/// <para>The <c>MsiGetPatchFileList</c> function returns the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_SUCCESS</term>
	/// <term>The function completed successfully.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>An invalid parameter was passed to the function.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_FUNCTION_FAILED</term>
	/// <term>The function failed.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// For example, szPatchList could have the value: "c:\sus\download\cache\Office\sp1.msp; c:\sus\download\cache\Office\QFE1.msp; c:\sus\download\cache\Office\QFEn.msp".
	/// </para>
	/// <para>
	/// This function runs in the context of the caller. The product code is searched in the order of user-unmanaged context,
	/// user-managed context, and machine context.
	/// </para>
	/// <para>You must close all MSIHANDLE objects that are returned by this function by calling the MsiCloseHandle function.</para>
	/// <para>If the function fails, you can obtain extended error information by using the MsiGetLastErrorRecord function.</para>
	/// <para>For more information about using the <c>MsiGetPatchFileList</c> function see Listing the Files that can be Updated.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msigetpatchfilelista UINT MsiGetPatchFileListA( LPCSTR
	// szProductCode, LPCSTR szPatchPackages, LPDWORD pcFiles, MSIHANDLE **pphFileRecords );
	[DllImport(Lib_Msi, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiGetPatchFileListA")]
	public static extern Win32Error MsiGetPatchFileList([MarshalAs(UnmanagedType.LPTStr)] string szProductCode,
		[MarshalAs(UnmanagedType.LPTStr)] string szPatchPackages, out uint pcFiles,
		[MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] out MSIHANDLE[] pphFileRecords);

	/// <summary>The <c>MsiGetPatchInfo</c> function returns information about a patch.</summary>
	/// <param name="szPatch">Specifies the patch code for the patch package.</param>
	/// <param name="szAttribute">
	/// <para>Specifies the attribute to be retrieved.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Attribute</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>INSTALLPROPERTY_LOCALPACKAGE</term>
	/// <term>Local cached package.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="lpValueBuf">Pointer to a buffer that receives the property value. This parameter can be null.</param>
	/// <param name="pcchValueBuf">
	/// <para>
	/// Pointer to a variable that specifies the size, in characters, of the buffer pointed to by the lpValueBuf parameter. On input,
	/// this is the full size of the buffer, including a space for a terminating null character. If the buffer passed in is too small,
	/// the count returned does not include the terminating null character.
	/// </para>
	/// <para>If lpValueBuf is null, pcchValueBuf can be null.</para>
	/// </param>
	/// <returns>
	/// <para>The <c>MsiGetPatchInfo</c> function returns the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_BAD_CONFIGURATION</term>
	/// <term>The configuration data is corrupt.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>An invalid parameter was passed to the function.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>A buffer is too small to hold the requested data.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SUCCESS</term>
	/// <term>The function completed successfully.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNKNOWN_PRODUCT</term>
	/// <term>The patch package is not installed.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNKNOWN_PROPERTY</term>
	/// <term>The property is unrecognized.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// When the <c>MsiGetPatchInfo</c> function returns, the pcchValueBuf parameter contains the length of the class string stored in
	/// the buffer. The count returned does not include the terminating null character.
	/// </para>
	/// <para>
	/// If the buffer is too small to hold the requested data, <c>MsiGetPatchInfo</c> returns ERROR_MORE_DATA, and pcchValueBuf contains
	/// the number of characters copied to lpValueBuf, without counting the null character.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msigetpatchinfoa UINT MsiGetPatchInfoA( LPCSTR szPatch, LPCSTR
	// szAttribute, LPSTR lpValueBuf, LPDWORD pcchValueBuf );
	[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiGetPatchInfoA")]
	public static extern Win32Error MsiGetPatchInfo([MarshalAs(UnmanagedType.LPTStr)] string szPatch,
		[MarshalAs(UnmanagedType.LPTStr)] string szAttribute, [Out, Optional, MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpValueBuf,
		ref uint pcchValueBuf);

	/// <summary>
	/// The <c>MsiGetPatchInfoEx</c> function queries for information about the application of a patch to a specified instance of a product.
	/// </summary>
	/// <param name="szPatchCode">A null-terminated string that contains the GUID of the patch. This parameter cannot be <c>NULL</c>.</param>
	/// <param name="szProductCode">
	/// A null-terminated string that contains the ProductCode GUID of the product instance. This parameter cannot be <c>NULL</c>.
	/// </param>
	/// <param name="szUserSid">
	/// <para>
	/// A null-terminated string that specifies the security identifier (SID) under which the instance of the patch being queried
	/// exists. Using a <c>NULL</c> value specifies the current user.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>SID</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>NULL</term>
	/// <term>Specifies the user that is logged on.</term>
	/// </item>
	/// <item>
	/// <term>User SID</term>
	/// <term>
	/// Specifies the enumeration for a specific user ID in the system. The following example identifies a possible user SID: "S-1-3-64-2415071341-1358098788-3127455600-2561".
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// <c>Note</c> The special SID string "S-1-5-18" (system) cannot be used to enumerate products installed as per-machine. If
	/// dwContext is <c>MSIINSTALLCONTEXT_MACHINE</c>, szUserSid must be <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="dwContext">
	/// <para>
	/// Restricts the enumeration to a per-user-unmanaged, per-user-managed, or per-machine context. This parameter can be any one of
	/// the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Context</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MSIINSTALLCONTEXT_USERMANAGED 1</term>
	/// <term>Query that is extended to all per–user-managed installations for the users that szUserSid specifies.</term>
	/// </item>
	/// <item>
	/// <term>MSIINSTALLCONTEXT_USERUNMANAGED 2</term>
	/// <term>Query that is extended to all per–user-unmanaged installations for the users that szUserSid specifies.</term>
	/// </item>
	/// <item>
	/// <term>MSIINSTALLCONTEXT_MACHINE 4</term>
	/// <term>Query that is extended to all per-machine installations.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="szProperty">
	/// <para>A null-terminated string that specifies the property value to retrieve. The szProperty parameter can be one of the following:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Name</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>INSTALLPROPERTY_LOCALPACKAGE "LocalPackage"</term>
	/// <term>Gets the cached patch file that the product uses.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLPROPERTY_TRANSFORMS "Transforms"</term>
	/// <term>
	/// Gets the set of patch transforms that the last patch installation applied to the product. This value may not be available for
	/// per-user, non-managed applications if the user is not logged on.
	/// </term>
	/// </item>
	/// <item>
	/// <term>INSTALLPROPERTY_INSTALLDATE "InstallDate"</term>
	/// <term>
	/// Gets the last time this product received service. The value of this property is replaced each time a patch is applied or removed
	/// from the product or the /v Command-Line Option is used to repair the product. If the product has received no repairs or patches
	/// this property contains the time this product was installed on this computer.
	/// </term>
	/// </item>
	/// <item>
	/// <term>INSTALLPROPERTY_UNINSTALLABLE "Uninstallable"</term>
	/// <term>
	/// Returns "1" if the patch is marked as possible to uninstall from the product. In this case, the installer can still block the
	/// uninstallation if this patch is required by another patch that cannot be uninstalled.
	/// </term>
	/// </item>
	/// <item>
	/// <term>INSTALLPROPERTY_PATCHSTATE "State"</term>
	/// <term>
	/// Returns "1" if this patch is currently applied to the product. Returns "2" if this patch is superseded by another patch. Returns
	/// "4" if this patch is obsolete. These values correspond to the constants the dwFilter parameter of MsiEnumPatchesEx uses.
	/// </term>
	/// </item>
	/// <item>
	/// <term>INSTALLPROPERTY_DISPLAYNAME "DisplayName"</term>
	/// <term>
	/// Get the registered display name for the patch. For patches that do not include the DisplayName property in the MsiPatchMetadata
	/// table, the returned display name is an empty string ("").
	/// </term>
	/// </item>
	/// <item>
	/// <term>INSTALLPROPERTY_MOREINFOURL "MoreInfoURL"</term>
	/// <term>
	/// Get the registered support information URL for the patch. For patches that do not include the MoreInfoURL property in the
	/// MsiPatchMetadata table, the returned support information URL is an empty string ("").
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="lpValue">
	/// <para>
	/// This parameter is a pointer to a buffer that receives the property value. This buffer should be large enough to contain the
	/// information. If the buffer is too small, the function returns <c>ERROR_MORE_DATA</c> and sets *pcchValue to the number of
	/// <c>TCHAR</c> in the property value, not including the terminating <c>NULL</c> character.
	/// </para>
	/// <para>
	/// If lpValue is set to <c>NULL</c> and pcchValue is set to a valid pointer, the function returns <c>ERROR_SUCCESS</c> and sets
	/// *pcchValue to the number of <c>TCHAR</c> in the value, not including the terminating <c>NULL</c> character. The function can
	/// then be called again to retrieve the value, with lpValue buffer large enough to contain *pcchValue + 1 characters.
	/// </para>
	/// <para>
	/// If lpValue and pcchValue are both set to <c>NULL</c>, the function returns <c>ERROR_SUCCESS</c> if the value exists, without
	/// retrieving the value.
	/// </para>
	/// </param>
	/// <param name="pcchValue">
	/// <para>
	/// When calling the function, this parameter should be a pointer to a variable that specifies the number of <c>TCHAR</c> in the
	/// lpValue buffer. When the function returns, this parameter is set to the size of the requested value whether or not the function
	/// copies the value into the specified buffer. The size is returned as the number of <c>TCHAR</c> in the requested value, not
	/// including the terminating null character.
	/// </para>
	/// <para>This parameter can be set to <c>NULL</c> only if lpValue is also <c>NULL</c>. Otherwise, the function returns <c>ERROR_INVALID_PARAMETER</c>.</para>
	/// </param>
	/// <returns>
	/// <para>The <c>MsiGetPatchInfoEx</c> function returns the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>The function fails trying to access a resource with insufficient privileges.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_BAD_CONFIGURATION</term>
	/// <term>The configuration data is corrupt.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_FUNCTION_FAILED</term>
	/// <term>The function fails and the error is not identified in other error codes.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>An invalid parameter is passed to the function.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>The value does not fit in the provided buffer.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SUCCESS</term>
	/// <term>The patch is enumerated successfully.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNKNOWN_PRODUCT</term>
	/// <term>The product that szProduct specifies is not installed on the computer.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNKNOWN_PROPERTY</term>
	/// <term>The property is unrecognized.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNKNOWN_PATCH</term>
	/// <term>The patch is unrecognized.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para><c>Windows Installer 2.0:</c> Not supported. This function is available beginning with Windows Installer version 3.0.</para>
	/// <para>
	/// A user may query patch data for any product instance that is visible. The administrator group can query patch data for any
	/// product instance and any user on the computer. Not all values are guaranteed to be available for per-user, non-managed
	/// applications if the user is not logged on.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msigetpatchinfoexa UINT MsiGetPatchInfoExA( LPCSTR szPatchCode,
	// LPCSTR szProductCode, LPCSTR szUserSid, MSIINSTALLCONTEXT dwContext, LPCSTR szProperty, LPSTR lpValue, LPDWORD pcchValue );
	[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiGetPatchInfoExA")]
	public static extern Win32Error MsiGetPatchInfoEx([MarshalAs(UnmanagedType.LPTStr)] string szPatchCode,
		[MarshalAs(UnmanagedType.LPTStr)] string szProductCode, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? szUserSid,
		MSIINSTALLCONTEXT dwContext, [MarshalAs(UnmanagedType.LPTStr)] string szProperty,
		[Out, Optional, MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpValue, ref uint pcchValue);

	/// <summary>
	/// The <c>MsiGetProductCode</c> function returns the product code of an application by using the component code of an installed or
	/// advertised component of the application. During initialization, an application must determine under which product code it has
	/// been installed or advertised.
	/// </summary>
	/// <param name="szComponent">
	/// This parameter specifies the component code of a component that has been installed by the application. This will be typically
	/// the component code of the component containing the executable file of the application.
	/// </param>
	/// <param name="lpBuf39">
	/// Pointer to a buffer that receives the product code. This buffer must be 39 characters long. The first 38 characters are for the
	/// GUID, and the last character is for the terminating null character.
	/// </param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_BAD_CONFIGURATION</term>
	/// <term>The configuration data is corrupt.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSTALL_FAILURE</term>
	/// <term>The product code could not be determined.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>An invalid parameter was passed to the function.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SUCCESS</term>
	/// <term>The function completed successfully.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNKNOWN_COMPONENT</term>
	/// <term>The specified component is unknown.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// During initialization, an application must determine the product code under which it was installed. An application can be part
	/// of different products in different installations. For example, an application can be part of a suite of applications, or it can
	/// be installed by itself.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msigetproductcodea UINT MsiGetProductCodeA( LPCSTR szComponent,
	// LPSTR lpBuf39 );
	[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiGetProductCodeA")]
	public static extern Win32Error MsiGetProductCode([MarshalAs(UnmanagedType.LPTStr)] string szComponent,
[Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpBuf39);

	/// <summary>The <c>MsiGetProductInfo</c> function returns product information for published and installed products.</summary>
	/// <param name="szProduct">Specifies the product code for the product.</param>
	/// <param name="szAttribute">
	/// <para>Specifies the property to be retrieved.</para>
	/// <para>
	/// The Required Properties are guaranteed to be available, but other properties are available only if that property is set. For
	/// more information, see Properties. The properties in the following list can be retrieved only from applications that are installed.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Property</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>INSTALLPROPERTY_HELPLINK</term>
	/// <term>Support link. For more information, see the ARPHELPLINK property.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLPROPERTY_HELPTELEPHONE</term>
	/// <term>Support telephone. For more information, see the ARPHELPTELEPHONE property.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLPROPERTY_INSTALLDATE</term>
	/// <term>
	/// The last time this product received service. The value of this property is replaced each time a patch is applied or removed from
	/// the product or the /v Command-Line Option is used to repair the product. If the product has received no repairs or patches this
	/// property contains the time this product was installed on this computer.
	/// </term>
	/// </item>
	/// <item>
	/// <term>INSTALLPROPERTY_INSTALLEDLANGUAGE</term>
	/// <term>Installed language. Windows Installer 4.5 and earlier: Not supported.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLPROPERTY_INSTALLEDPRODUCTNAME</term>
	/// <term>Installed product name. For more information, see the ProductName property.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLPROPERTY_INSTALLLOCATION</term>
	/// <term>Installation location. For more information, see the ARPINSTALLLOCATION property.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLPROPERTY_INSTALLSOURCE</term>
	/// <term>Installation source. For more information, see the SourceDir property.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLPROPERTY_LOCALPACKAGE</term>
	/// <term>Local cached package.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLPROPERTY_PUBLISHER</term>
	/// <term>Publisher. For more information, see the Manufacturer property.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLPROPERTY_URLINFOABOUT</term>
	/// <term>URL information. For more information, see the ARPURLINFOABOUT property.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLPROPERTY_URLUPDATEINFO</term>
	/// <term>URL update information. For more information, see the ARPURLUPDATEINFO property.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLPROPERTY_VERSIONMINOR</term>
	/// <term>Minor product version derived from the ProductVersion property.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLPROPERTY_VERSIONMAJOR</term>
	/// <term>Major product version derived from the ProductVersion property.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLPROPERTY_VERSIONSTRING</term>
	/// <term>Product version. For more information, see the ProductVersion property.</term>
	/// </item>
	/// </list>
	/// <para>
	/// To retrieve the product ID, registered owner, or registered company from applications that are installed, set szProperty to one
	/// of the following text string values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ProductID</term>
	/// <term>The product identifier for the product. For more information, see the ProductID property.</term>
	/// </item>
	/// <item>
	/// <term>RegCompany</term>
	/// <term>The company registered to use this product.</term>
	/// </item>
	/// <item>
	/// <term>RegOwner</term>
	/// <term>The owner registered to use this product.</term>
	/// </item>
	/// </list>
	/// <para>
	/// To retrieve the instance type of the product, set szProperty to the following value. This property is available for advertised
	/// or installed products.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>InstanceType</term>
	/// <term>
	/// A missing value or a value of 0 (zero) indicates a normal product installation. A value of 1 (one) indicates a product installed
	/// using a multiple instance transform and the MSINEWINSTANCE property. Available with the installer running Windows Server 2003 or
	/// Windows XP with SP1. For more information see, Installing Multiple Instances of Products and Patches.
	/// </term>
	/// </item>
	/// </list>
	/// <para>The advertised properties in the following list can be retrieved from applications that are advertised or installed.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Property</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>INSTALLPROPERTY_TRANSFORMS</term>
	/// <term>Transforms.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLPROPERTY_LANGUAGE</term>
	/// <term>Product language.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLPROPERTY_PRODUCTNAME</term>
	/// <term>Human readable product name. For more information, see the ProductName property.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLPROPERTY_ASSIGNMENTTYPE</term>
	/// <term>
	/// Equals 0 (zero) if the product is advertised or installed per-user. Equals 1 (one) if the product is advertised or installed
	/// per-machine for all users.
	/// </term>
	/// </item>
	/// <item>
	/// <term>INSTALLPROPERTY_PACKAGECODE</term>
	/// <term>Identifier of the package this product was installed from. For more information, see Package Codes.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLPROPERTY_VERSION</term>
	/// <term>Product version derived from the ProductVersion property.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLPROPERTY_PRODUCTICON</term>
	/// <term>Primary icon for the package. For more information, see the ARPPRODUCTICON property.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLPROPERTY_PACKAGENAME</term>
	/// <term>Name of the original installation package.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLPROPERTY_AUTHORIZED_LUA_APP</term>
	/// <term>
	/// A value of one (1) indicates a product that can be serviced by non-administrators using User Account Control (UAC) Patching. A
	/// missing value or a value of 0 (zero) indicates that least-privilege patching is not enabled. Available in Windows Installer 3.0
	/// or later.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="lpValueBuf">Pointer to a buffer that receives the property value. This parameter can be null.</param>
	/// <param name="pcchValueBuf">
	/// <para>
	/// Pointer to a variable that specifies the size, in characters, of the buffer pointed to by the lpValueBuf parameter. On input,
	/// this is the full size of the buffer, including a space for a terminating null character. If the buffer passed in is too small,
	/// the count returned does not include the terminating null character.
	/// </para>
	/// <para>
	/// If lpValueBuf is null, pcchValueBuf can be null. In this case, the function checks that the property is registered correctly
	/// with the product.
	/// </para>
	/// </param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_BAD_CONFIGURATION</term>
	/// <term>The configuration data is corrupt.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>An invalid parameter was passed to the function.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>A buffer is too small to hold the requested data.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SUCCESS</term>
	/// <term>The function completed successfully.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNKNOWN_PRODUCT</term>
	/// <term>The product is unadvertised or uninstalled.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNKNOWN_PROPERTY</term>
	/// <term>The property is unrecognized.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// When the <c>MsiGetProductInfo</c> function returns, the pcchValueBuf parameter contains the length of the string stored in the
	/// buffer. The count returned does not include the terminating null character. If the buffer is not large enough,
	/// <c>MsiGetProductInfo</c> returns ERROR_MORE_DATA and pcchValueBuf contains the size of the string, in characters, without
	/// counting the null character.
	/// </para>
	/// <para>
	/// <c>MsiGetProductInfo</c>(INSTALLPROPERTY_LOCALPACKAGE) does not necessarily return a path to the cached package. The cached
	/// package is for internal use only. Maintenance mode installations should be invoked through the MsiConfigureFeature,
	/// MsiConfigureProduct, or MsiConfigureProductEx functions.
	/// </para>
	/// <para>
	/// If you attempt to use <c>MsiGetProductInfo</c> to query an advertised product for a property that is only available to installed
	/// products, the function returns ERROR_UNKNOWN_PROPERTY. For example, if the application is advertised and not installed, a query
	/// for the INSTALLPROPERTY_INSTALLLOCATION property returns an error of ERROR_UNKNOWN_PROPERTY.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msigetproductinfoa UINT MsiGetProductInfoA( LPCSTR szProduct,
	// LPCSTR szAttribute, LPSTR lpValueBuf, LPDWORD pcchValueBuf );
	[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiGetProductInfoA")]
	public static extern Win32Error MsiGetProductInfo([MarshalAs(UnmanagedType.LPTStr)] string szProduct, [MarshalAs(UnmanagedType.LPTStr)] string szAttribute,
		[Out, Optional, MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpValueBuf, ref uint pcchValueBuf);

	/// <summary>
	/// <para>
	/// The <c>MsiGetProductInfoEx</c> function returns product information for advertised and installed products. This function can
	/// retrieve information
	/// </para>
	/// <para>about an instance of a product that is installed under a user account other than the current user.</para>
	/// <para>
	/// The calling process must have administrative privileges for a user who is different from the current user. The
	/// <c>MsiGetProductInfoEx</c> function cannot query an instance of a product that is advertised under a per-user-unmanaged context
	/// for a user account other than the current user.
	/// </para>
	/// <para>This function is an extension of the MsiGetProductInfo function.</para>
	/// </summary>
	/// <param name="szProductCode">The ProductCode GUID of the product instance that is being queried.</param>
	/// <param name="szUserSid">
	/// <para>
	/// The security identifier (SID) of the account under which the instance of the product that is being queried exists. A <c>NULL</c>
	/// specifies the current user SID.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>SID</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>NULL</term>
	/// <term>The currently logged-on user.</term>
	/// </item>
	/// <item>
	/// <term>User SID</term>
	/// <term>The enumeration for a specific user in the system. An example of user SID is "S-1-3-64-2415071341-1358098788-3127455600-2561".</term>
	/// </item>
	/// </list>
	/// <para>
	/// <c>Note</c> The special SID string "S-1-5-18" (system) cannot be used to enumerate products installed as per-machine. If
	/// dwContext is "MSIINSTALLCONTEXT_MACHINE", szUserSid must be <c>NULL</c>.
	/// </para>
	/// </param>
	/// <param name="dwContext">
	/// <para>The installation context of the product instance that is being queried.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Name</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MSIINSTALLCONTEXT_USERMANAGED</term>
	/// <term>Retrieves the product property for the per–user–managed instance of the product.</term>
	/// </item>
	/// <item>
	/// <term>MSIINSTALLCONTEXT_USERUNMANAGED</term>
	/// <term>Retrieves the product property for the per–user–unmanaged instance of the product.</term>
	/// </item>
	/// <item>
	/// <term>MSIINSTALLCONTEXT_MACHINE</term>
	/// <term>Retrieves the product property for the per-machine instance of the product.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="szProperty">
	/// <para>Property being queried.</para>
	/// <para>
	/// The property to be retrieved. The properties in the following table can only be retrieved from applications that are already
	/// installed. All required properties are guaranteed to be available, but other properties are available only if the property is
	/// set. For more information, see Required Properties and Properties.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Property</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>INSTALLPROPERTY_PRODUCTSTATE</term>
	/// <term>The state of the product returned in string form as "1" for advertised and "5" for installed.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLPROPERTY_HELPLINK</term>
	/// <term>The support link. For more information, see the ARPHELPLINK property.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLPROPERTY_HELPTELEPHONE</term>
	/// <term>The support telephone. For more information, see the ARPHELPTELEPHONE property.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLPROPERTY_INSTALLDATE</term>
	/// <term>
	/// The last time this product received service. The value of this property is replaced each time a patch is applied or removed from
	/// the product or the /v Command-Line Option is used to repair the product. If the product has received no repairs or patches this
	/// property contains the time this product was installed on this computer.
	/// </term>
	/// </item>
	/// <item>
	/// <term>INSTALLPROPERTY_INSTALLEDLANGUAGE</term>
	/// <term>Installed language. Windows Installer 4.5 and earlier: Not supported.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLPROPERTY_INSTALLEDPRODUCTNAME</term>
	/// <term>The installed product name. For more information, see the ProductName property.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLPROPERTY_INSTALLLOCATION</term>
	/// <term>The installation location. For more information, see the ARPINSTALLLOCATION property.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLPROPERTY_INSTALLSOURCE</term>
	/// <term>The installation source. For more information, see the SourceDir property.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLPROPERTY_LOCALPACKAGE</term>
	/// <term>The local cached package.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLPROPERTY_PUBLISHER</term>
	/// <term>The publisher. For more information, see the Manufacturer property.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLPROPERTY_URLINFOABOUT</term>
	/// <term>URL information. For more information, see the ARPURLINFOABOUT property.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLPROPERTY_URLUPDATEINFO</term>
	/// <term>The URL update information. For more information, see the ARPURLUPDATEINFO property.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLPROPERTY_VERSIONMINOR</term>
	/// <term>The minor product version that is derived from the ProductVersion property.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLPROPERTY_VERSIONMAJOR</term>
	/// <term>The major product version that is derived from the ProductVersion property.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLPROPERTY_VERSIONSTRING</term>
	/// <term>The product version. For more information, see the ProductVersion property.</term>
	/// </item>
	/// </list>
	/// <para>
	/// To retrieve the product ID, registered owner, or registered company from applications that are installed, set szProperty to one
	/// of the following text string values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ProductID</term>
	/// <term>The product identifier. For more information, see the ProductID property.</term>
	/// </item>
	/// <item>
	/// <term>RegCompany</term>
	/// <term>The company that is registered to use the product.</term>
	/// </item>
	/// <item>
	/// <term>RegOwner</term>
	/// <term>The owner who is registered to use the product.</term>
	/// </item>
	/// </list>
	/// <para>
	/// To retrieve the instance type of the product, set szProperty to the following value. This property is available for advertised
	/// or installed products.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>InstanceType</term>
	/// <term>
	/// A missing value or a value of 0 (zero) indicates a normal product installation. A value of one (1) indicates a product installed
	/// using a multiple instance transform and the MSINEWINSTANCE property. For more information, see Installing Multiple Instances of
	/// Products and Patches.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// The properties in the following table can be retrieved from applications that are advertised or installed. These properties
	/// cannot be retrieved for product instances that are installed under a per-user-unmanaged context for user accounts other than
	/// current user account.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Property</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>INSTALLPROPERTY_TRANSFORMS</term>
	/// <term>Transforms.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLPROPERTY_LANGUAGE</term>
	/// <term>Product language.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLPROPERTY_PRODUCTNAME</term>
	/// <term>Human readable product name. For more information, see the ProductName property.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLPROPERTY_ASSIGNMENTTYPE</term>
	/// <term>
	/// Equals 0 (zero) if the product is advertised or installed per-user. Equals one (1) if the product is advertised or installed
	/// per-computer for all users.
	/// </term>
	/// </item>
	/// <item>
	/// <term>INSTALLPROPERTY_PACKAGECODE</term>
	/// <term>Identifier of the package that a product is installed from. For more information, see the Package Codes property.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLPROPERTY_VERSION</term>
	/// <term>Product version derived from the ProductVersion property.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLPROPERTY_PRODUCTICON</term>
	/// <term>Primary icon for the package. For more information, see the ARPPRODUCTICON property.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLPROPERTY_PACKAGENAME</term>
	/// <term>Name of the original installation package.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLPROPERTY_AUTHORIZED_LUA_APP</term>
	/// <term>
	/// A value of one (1) indicates a product that can be serviced by non-administrators using User Account Control (UAC) Patching. A
	/// missing value or a value of 0 (zero) indicates that least-privilege patching is not enabled. Available in Windows Installer 3.0
	/// or later.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="szValue">
	/// <para>
	/// A pointer to a buffer that receives the property value. This buffer should be large enough to contain the information. If the
	/// buffer is too small, the function returns <c>ERROR_MORE_DATA</c> and sets *pcchValue to the number of <c>TCHAR</c> in the value,
	/// not including the terminating NULL character.
	/// </para>
	/// <para>
	/// If lpValue is set to <c>NULL</c> and pcchValue is set to a valid pointer, the function returns <c>ERROR_SUCCESS</c> and sets
	/// *pcchValue to the number of <c>TCHAR</c> in the value, not including the terminating NULL character. The function can then be
	/// called again to retrieve the value, with lpValue buffer large enough to contain *pcchValue + 1 characters.
	/// </para>
	/// <para>
	/// If lpValue and pcchValue are both set to <c>NULL</c>, the function returns <c>ERROR_SUCCESS</c> if the value exists, without
	/// retrieving the value.
	/// </para>
	/// </param>
	/// <param name="pcchValue">
	/// <para>
	/// A pointer to a variable that specifies the number of <c>TCHAR</c> in the lpValue buffer. When the function returns, this
	/// parameter is set to the size of the requested value whether or not the function copies the value into the specified buffer. The
	/// size is returned as the number of <c>TCHAR</c> in the requested value, not including the terminating null character.
	/// </para>
	/// <para>This parameter can be set to <c>NULL</c> only if lpValue is also <c>NULL</c>. Otherwise, the function returns <c>ERROR_INVALID_PARAMETER</c>.</para>
	/// </param>
	/// <returns>
	/// <para>The <c>MsiGetProductInfoEx</c> function returns the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>
	/// The calling process must have administrative privileges to get information for a product installed for a user other than the
	/// current user.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_BAD_CONFIGURATION</term>
	/// <term>The configuration data is corrupt.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>An invalid parameter is passed to the function.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>A buffer is too small to hold the requested data.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SUCCESS</term>
	/// <term>The function completed successfully.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNKNOWN_PRODUCT</term>
	/// <term>The product is unadvertised or uninstalled.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNKNOWN_PROPERTY</term>
	/// <term>The property is unrecognized.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_FUNCTION_FAILED</term>
	/// <term>An unexpected internal failure.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// When the <c>MsiGetProductInfoEx</c> function returns, the pcchValue parameter contains the length of the string that is stored
	/// in the buffer. The count returned does not include the terminating null character. If the buffer is not big enough,
	/// <c>MsiGetProductInfoEx</c> returns <c>ERROR_MORE_DATA</c>, and the pcchValue parameter contains the size of the string, in
	/// <c>TCHAR</c>, without counting the null character.
	/// </para>
	/// <para>
	/// The <c>MsiGetProductInfoEx</c> function ( <c>INSTALLPROPERTY_LOCALPACKAGE</c>) returns a path to the cached package. The cached
	/// package is for internal use only. Maintenance mode installations must be invoked through the MsiConfigureFeature,
	/// MsiConfigureProduct, or MsiConfigureProductEx functions.
	/// </para>
	/// <para>
	/// The MsiGetProductInfo function returns <c>ERROR_UNKNOWN_PROPERTY</c> if the application being queried is advertised and not
	/// installed. For example, if the application is advertised and not installed, a query for <c>INSTALLPROPERTY_INSTALLLOCATION</c>
	/// returns an error of <c>ERROR_UNKNOWN_PROPERTY</c>.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msigetproductinfoexa UINT MsiGetProductInfoExA( LPCSTR
	// szProductCode, LPCSTR szUserSid, MSIINSTALLCONTEXT dwContext, LPCSTR szProperty, LPSTR szValue, LPDWORD pcchValue );
	[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiGetProductInfoExA")]
	public static extern Win32Error MsiGetProductInfoEx([MarshalAs(UnmanagedType.LPTStr)] string szProductCode,
		[Optional, MarshalAs(UnmanagedType.LPTStr)] string? szUserSid, MSIINSTALLCONTEXT dwContext, [MarshalAs(UnmanagedType.LPTStr)] string szProperty,
		[Out, MarshalAs(UnmanagedType.LPTStr)] StringBuilder szValue, ref uint pcchValue);

	/// <summary>The <c>MsiGetProductInfoFromScript</c> function returns product information for a Windows Installer script file.</summary>
	/// <param name="szScriptFile">
	/// A null-terminated string specifying the full path to the script file. The script file is the advertise script that was created
	/// by calling MsiAdvertiseProduct or MsiAdvertiseProductEx.
	/// </param>
	/// <param name="lpProductBuf39">
	/// Points to a buffer that receives the product code. The buffer must be 39 characters long. The first 38 characters are for the
	/// product code GUID, and the last character is for the terminating null character.
	/// </param>
	/// <param name="plgidLanguage">Points to a variable that receives the product language.</param>
	/// <param name="pdwVersion">Points to a buffer that receives the product version.</param>
	/// <param name="lpNameBuf">Points to a buffer that receives the product name. The buffer includes a terminating null character.</param>
	/// <param name="pcchNameBuf">
	/// Points to a variable that specifies the size, in characters, of the buffer pointed to by the lpNameBuf parameter. This size
	/// should include the terminating null character. When the function returns, this variable contains the length of the string stored
	/// in the buffer. The count returned does not include the terminating null character. If the buffer is not large enough, the
	/// function returns ERROR_MORE_DATA, and the variable contains the size of the string in characters, without counting the null character.
	/// </param>
	/// <param name="lpPackageBuf">Points to a buffer that receives the package name. The buffer includes the terminating null character.</param>
	/// <param name="pcchPackageBuf">
	/// Points to a variable that specifies the size, in characters, of the buffer pointed to by the lpPackageNameBuf parameter. This
	/// size should include the terminating null character. When the function returns, this variable contains the length of the string
	/// stored in the buffer. The count returned does not include the terminating null character. If the buffer is not large enough, the
	/// function returns ERROR_MORE_DATA, and the variable contains the size of the string in characters, without counting the null character.
	/// </param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_SUCCESS</term>
	/// <term>The function completed successfully.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>An invalid argument was passed to the function.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>A buffer was too small to hold the entire value.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSTALL_FAILURE</term>
	/// <term>Could not get script information.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_CALL_NOT_IMPLEMENTED</term>
	/// <term>This function is only available on Windows 2000 and Windows XP.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks/>
	// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msigetproductinfofromscripta UINT MsiGetProductInfoFromScriptA(
	// LPCSTR szScriptFile, LPSTR lpProductBuf39, LANGID *plgidLanguage, LPDWORD pdwVersion, LPSTR lpNameBuf, LPDWORD pcchNameBuf, LPSTR
	// lpPackageBuf, LPDWORD pcchPackageBuf );
	[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiGetProductInfoFromScriptA")]
	public static extern Win32Error MsiGetProductInfoFromScript([MarshalAs(UnmanagedType.LPTStr)] string szScriptFile,
		[Out, Optional, MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpProductBuf39, out ushort plgidLanguage, out uint pdwVersion,
		[Out, Optional, MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpNameBuf, ref uint pcchNameBuf,
		[Out, Optional, MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpPackageBuf, ref uint pcchPackageBuf);

	/// <summary>The <c>MsiGetProductProperty</c> function retrieves product properties. These properties are in the product database.</summary>
	/// <param name="hProduct">Handle to the product obtained from MsiOpenProduct.</param>
	/// <param name="szProperty">Specifies the property to retrieve. This is case-sensitive.</param>
	/// <param name="lpValueBuf">
	/// Pointer to a buffer that receives the property value. The value is truncated and null-terminated if lpValueBuf is too small.
	/// This parameter can be null.
	/// </param>
	/// <param name="pcchValueBuf">
	/// <para>
	/// Pointer to a variable that specifies the size, in characters, of the buffer pointed to by the lpValueBuf parameter. On input,
	/// this is the full size of the buffer, including a space for a terminating null character. If the buffer passed in is too small,
	/// the count returned does not include the terminating null character.
	/// </para>
	/// <para>If lpValueBuf is null, pcchValueBuf can be null.</para>
	/// </param>
	/// <returns>
	/// <para>The <c>MsiGetProductProperty</c> function return the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>An invalid parameter was passed to the function.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE</term>
	/// <term>An invalid handle was passed to the function.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>A buffer is too small to hold the entire property value.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SUCCESS</term>
	/// <term>The function completed successfully.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// When the <c>MsiGetProductProperty</c> function returns, the pcchValueBuf parameter contains the length of the string stored in
	/// the buffer. The count returned does not include the terminating null character. If the buffer is not big enough,
	/// <c>MsiGetProductProperty</c> returns ERROR_MORE_DATA, and <c>MsiGetProductProperty</c> contains the size of the string, in
	/// characters, without counting the null character.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msigetproductpropertya UINT MsiGetProductPropertyA( MSIHANDLE
	// hProduct, LPCSTR szProperty, LPSTR lpValueBuf, LPDWORD pcchValueBuf );
	[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiGetProductPropertyA")]
	public static extern Win32Error MsiGetProductProperty(MSIHANDLE hProduct, [MarshalAs(UnmanagedType.LPTStr)] string szProperty,
		[Out, Optional, MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpValueBuf, ref uint pcchValueBuf);

	/// <summary>
	/// The <c>MsiGetShortcutTarget</c> function examines a shortcut and returns its product, feature name, and component if available.
	/// </summary>
	/// <param name="szShortcutPath">A null-terminated string specifying the full path to a shortcut.</param>
	/// <param name="szProductCode">
	/// A GUID for the product code of the shortcut. This string buffer must be 39 characters long. The first 38 characters are for the
	/// GUID, and the last character is for the terminating null character. This parameter can be null.
	/// </param>
	/// <param name="szFeatureId">
	/// The feature name of the shortcut. The string buffer must be MAX_FEATURE_CHARS+1 characters long. This parameter can be null.
	/// </param>
	/// <param name="szComponentCode">
	/// A GUID of the component code. This string buffer must be 39 characters long. The first 38 characters are for the GUID, and the
	/// last character is for the terminating null character. This parameter can be null.
	/// </param>
	/// <returns>This function returns UINT.</returns>
	/// <remarks>
	/// <para>
	/// If the function fails, and the shortcut exists, the regular contents of the shortcut may be accessed through the IShellLink interface.
	/// </para>
	/// <para>Otherwise, the state of the target may be determined by using the Installer Selection Functions.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msigetshortcuttargeta UINT MsiGetShortcutTargetA( LPCSTR
	// szShortcutPath, LPSTR szProductCode, LPSTR szFeatureId, LPSTR szComponentCode );
	[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiGetShortcutTargetA")]
	public static extern Win32Error MsiGetShortcutTarget([MarshalAs(UnmanagedType.LPTStr)] string szShortcutPath,
		[Out, Optional, MarshalAs(UnmanagedType.LPTStr)] StringBuilder szProductCode,
		[Out, Optional, MarshalAs(UnmanagedType.LPTStr)] StringBuilder szFeatureId,
		[Out, Optional, MarshalAs(UnmanagedType.LPTStr)] StringBuilder szComponentCode);

	/// <summary>The <c>MsiGetUserInfo</c> function returns the registered user information for an installed product.</summary>
	/// <param name="szProduct">Specifies the product code for the product to be queried.</param>
	/// <param name="lpUserNameBuf">Pointer to a variable that receives the name of the user.</param>
	/// <param name="pcchUserNameBuf">
	/// Pointer to a variable that specifies the size, in characters, of the buffer pointed to by the lpUserNameBuf parameter. This size
	/// should include the terminating null character.
	/// </param>
	/// <param name="lpOrgNameBuf">Pointer to a buffer that receives the organization name.</param>
	/// <param name="pcchOrgNameBuf">
	/// Pointer to a variable that specifies the size, in characters, of the buffer pointed to by the lpOrgNameBuf parameter. On input,
	/// this is the full size of the buffer, including a space for a terminating null character. If the buffer passed in is too small,
	/// the count returned does not include the terminating null character.
	/// </param>
	/// <param name="lpSerialBuf">Pointer to a buffer that receives the product ID.</param>
	/// <param name="pcchSerialBuf">
	/// Pointer to a variable that specifies the size, in characters, of the buffer pointed to by the lpSerialBuf parameter. On input,
	/// this is the full size of the buffer, including a space for a terminating null character. If the buffer passed in is too small,
	/// the count returned does not include the terminating null character.
	/// </param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>USERINFOSTATE_ABSENT</term>
	/// <term>Some or all of the user information is absent.</term>
	/// </item>
	/// <item>
	/// <term>USERINFOSTATE_INVALIDARG</term>
	/// <term>One of the function parameters was invalid.</term>
	/// </item>
	/// <item>
	/// <term>USERINFOSTATE_MOREDATA</term>
	/// <term>A buffer is too small to hold the requested data.</term>
	/// </item>
	/// <item>
	/// <term>USERINFOSTATE_PRESENT</term>
	/// <term>The function completed successfully.</term>
	/// </item>
	/// <item>
	/// <term>USERINFOSTATE_UNKNOWN</term>
	/// <term>The product code does not identify a known product.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// When the <c>MsiGetUserInfo</c> function returns, the pcchNameBuf parameter contains the length of the class string stored in the
	/// buffer. The count returned does not include the terminating null character. If the buffer is not big enough, the
	/// <c>MsiGetUserInfo</c> function returns USERINFOSTATE_MOREDATA, and <c>MsiGetUserInfo</c> contains the size of the string, in
	/// characters, without counting the null character.
	/// </para>
	/// <para>The user information is considered to be present even in the absence of a company name.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msigetuserinfoa USERINFOSTATE MsiGetUserInfoA( LPCSTR szProduct,
	// LPSTR lpUserNameBuf, LPDWORD pcchUserNameBuf, LPSTR lpOrgNameBuf, LPDWORD pcchOrgNameBuf, LPSTR lpSerialBuf, LPDWORD
	// pcchSerialBuf );
	[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiGetUserInfoA")]
	public static extern USERINFOSTATE MsiGetUserInfo([MarshalAs(UnmanagedType.LPTStr)] string szProduct,
		[Out, Optional, MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpUserNameBuf, ref uint pcchUserNameBuf,
		[Out, Optional, MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpOrgNameBuf, ref uint pcchOrgNameBuf,
		[Out, Optional, MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpSerialBuf, ref uint pcchSerialBuf);

	/// <summary>The <c>MsiInstallMissingComponent</c> function installs files that are unexpectedly missing.</summary>
	/// <param name="szProduct">Specifies the product code for the product that owns the component to be installed.</param>
	/// <param name="szComponent">Identifies the component to be installed.</param>
	/// <param name="eInstallState">
	/// <para>Specifies the way the component should be installed. This parameter must be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>INSTALLSTATE_LOCAL</term>
	/// <term>The component should be locally installed.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLSTATE_SOURCE</term>
	/// <term>The component should be installed to run from the source.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLSTATE_DEFAULT</term>
	/// <term>The component should be installed according to the installer defaults.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_BAD_CONFIGURATION</term>
	/// <term>The configuration information is corrupt.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSTALL_FAILURE</term>
	/// <term>The installation failed.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSTALL_SOURCE_ABSENT</term>
	/// <term>The source was unavailable.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSTALL_SUSPEND</term>
	/// <term>The installation was suspended.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSTALL_USEREXIT</term>
	/// <term>The user exited the installation.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>One of the parameters is invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SUCCESS</term>
	/// <term>The function completed successfully.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNKNOWN_PRODUCT</term>
	/// <term>The product code is unrecognized.</term>
	/// </item>
	/// </list>
	/// <para>For more information about error messages, see Displayed Error Messages</para>
	/// </returns>
	/// <remarks>
	/// The <c>MsiInstallMissingComponent</c> function resolves the feature(s) that the component belongs to. Then, the product feature
	/// that requires the least additional disk space is installed.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msiinstallmissingcomponenta UINT MsiInstallMissingComponentA(
	// LPCSTR szProduct, LPCSTR szComponent, INSTALLSTATE eInstallState );
	[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiInstallMissingComponentA")]
	public static extern Win32Error MsiInstallMissingComponent([MarshalAs(UnmanagedType.LPTStr)] string szProduct,
		[MarshalAs(UnmanagedType.LPTStr)] string szComponent, INSTALLSTATE eInstallState);

	/// <summary>The <c>MsiInstallMissingFile</c> function installs files that are unexpectedly missing.</summary>
	/// <param name="szProduct">Specifies the product code for the product that owns the file to be installed.</param>
	/// <param name="szFile">Specifies the file to be installed.</param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_BAD_CONFIGURATION</term>
	/// <term>The configuration information is corrupt.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSTALL_FAILURE</term>
	/// <term>The installation failed.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSTALL_SOURCE_ABSENT</term>
	/// <term>The source was unavailable.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSTALL_SUSPEND</term>
	/// <term>The installation was suspended.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSTALL_USEREXIT</term>
	/// <term>The user exited the installation.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>A parameter was invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SUCCESS</term>
	/// <term>The function completed successfully.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNKNOWN_PRODUCT</term>
	/// <term>The product code is unrecognized.</term>
	/// </item>
	/// </list>
	/// <para>For more information about error messages, see Displayed Error Messages.</para>
	/// </returns>
	/// <remarks>
	/// The <c>MsiInstallMissingFile</c> function obtains the component that the file belongs to from the file table. Then, the product
	/// feature that requires the least additional disk space is installed.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msiinstallmissingfilea UINT MsiInstallMissingFileA( LPCSTR
	// szProduct, LPCSTR szFile );
	[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiInstallMissingFileA")]
	public static extern Win32Error MsiInstallMissingFile([MarshalAs(UnmanagedType.LPTStr)] string szProduct,
		[MarshalAs(UnmanagedType.LPTStr)] string szFile);

	/// <summary>The <c>MsiInstallProduct</c> function installs or uninstalls a product.</summary>
	/// <param name="szPackagePath">
	/// A null-terminated string that specifies the path to the location of the Windows Installer package. The string value can contain
	/// a URL (e.g. <c>http://packageLocation/package/package.msi</c>), a network path (e.g. \packageLocation\package.msi), a file path
	/// (e.g. file://packageLocation/package.msi), or a local path (e.g. D:\packageLocation\package.msi).
	/// </param>
	/// <param name="szCommandLine">
	/// <para>
	/// A null-terminated string that specifies the command line property settings. This should be a list of the format Property=Setting
	/// Property=Setting. For more information, see About Properties.
	/// </para>
	/// <para>
	/// To perform an administrative installation, include ACTION=ADMIN in szCommandLine. For more information, see the ACTION property.
	/// </para>
	/// </param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_SUCCESS</term>
	/// <term>The function completes successfully.</term>
	/// </item>
	/// <item>
	/// <term>An error relating to an action</term>
	/// <term>For more information, see Error Codes.</term>
	/// </item>
	/// <item>
	/// <term>Initialization Error</term>
	/// <term>An error that relates to initialization occurred.</term>
	/// </item>
	/// </list>
	/// <para>For more information, see Displayed Error Messages.</para>
	/// </returns>
	/// <remarks>
	/// <para>The <c>MsiInstallProduct</c> function displays the user interface with the current settings and log mode.</para>
	/// <list type="bullet">
	/// <item>
	/// <term>You can change user interface settings by using the MsiSetInternalUI, MsiSetExternalUI, or MsiSetExternalUIRecord functions.</term>
	/// </item>
	/// <item>
	/// <term>You can set the log mode by using the MsiEnableLog function.</term>
	/// </item>
	/// <item>
	/// <term>You can completely remove a product by setting REMOVE=ALL in szCommandLine.</term>
	/// </item>
	/// </list>
	/// <para>For more information, see REMOVE Property.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msiinstallproducta UINT MsiInstallProductA( LPCSTR szPackagePath,
	// LPCSTR szCommandLine );
	[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiInstallProductA")]
	public static extern Win32Error MsiInstallProduct([MarshalAs(UnmanagedType.LPTStr)] string szPackagePath, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? szCommandLine);

	/// <summary>
	/// <para>
	/// The <c>MsiIsProductElevated</c> function returns whether or not the product is managed. Only applications that require elevated
	/// privileges for installation and being installed through advertisement are considered managed, which means that an application
	/// installed per-machine is always considered managed.
	/// </para>
	/// <para>
	/// An application that is installed per-user is only considered managed if it is advertised by a local system process that is
	/// impersonating the user. For more information, see Advertising a Per-User Application to be Installed with Elevated Privileges.
	/// </para>
	/// <para>
	/// <c>MsiIsProductElevated</c> verifies that the local system owns the product registry data. The function does not refer to
	/// account policies such as AlwaysInstallElevated.
	/// </para>
	/// </summary>
	/// <param name="szProduct">
	/// <para>The full product code GUID of the product.</para>
	/// <para>This parameter is required and cannot be <c>NULL</c> or empty.</para>
	/// </param>
	/// <param name="pfElevated">
	/// <para>A pointer to a BOOL for the result.</para>
	/// <para>This parameter cannot be <c>NULL</c>.</para>
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the return value is ERROR_SUCCESS, and pfElevated is set to <c>TRUE</c> if the product is a managed application.
	/// </para>
	/// <para>If the function fails, the return value is one of the error codes identified in the following table.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_UNKNOWN_PRODUCT</term>
	/// <term>The product is not currently known.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>An invalid argument is passed to the function.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_BAD_CONFIGURATION</term>
	/// <term>The configuration information for the product is invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_FUNCTION_FAILED</term>
	/// <term>The function failed.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_CALL_NOT_IMPLEMENTED</term>
	/// <term>The function is not available for a specific platform.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks/>
	// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msiisproductelevatedw UINT MsiIsProductElevatedW( LPCWSTR
	// szProduct, BOOL *pfElevated );
	[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiIsProductElevatedW")]
	public static extern Win32Error MsiIsProductElevated([MarshalAs(UnmanagedType.LPTStr)] string szProduct, [MarshalAs(UnmanagedType.Bool)] out bool pfElevated);

	/// <summary>
	/// <para>
	/// The <c>MsiJoinTransaction</c> function requests that the Windows Installer make the current process the owner of the transaction
	/// installing the multiple-package installation.
	/// </para>
	/// <para><c>Windows Installer 4.0 and earlier:</c> Not supported. This function is available beginning with Windows Installer 4.5.</para>
	/// </summary>
	/// <param name="hTransactionHandle">
	/// The transaction ID, which identifies the transaction and is the identifier returned by the MsiBeginTransaction function.
	/// </param>
	/// <param name="dwTransactionAttributes">
	/// <para>Attributes of the multiple-package installation.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>0</term>
	/// <term>When 0 or no value is set, Windows Installer closes the UI from the previous installation.</term>
	/// </item>
	/// <item>
	/// <term>MSITRANSACTION_CHAIN_EMBEDDEDUI</term>
	/// <term>Set this attribute to request that the Windows Installer not shutdown the embedded UI until the transaction is complete.</term>
	/// </item>
	/// <item>
	/// <term>MSITRANSACTION_JOIN_EXISTING_EMBEDDEDUI</term>
	/// <term>
	/// Set this attribute to request that the Windows Installer transfer the embedded UI from the original installation. If the
	/// original installation has no embedded UI, setting this attribute does nothing.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="phChangeOfOwnerEvent">
	/// This parameter returns a handle to an event that is set when the <c>MsiJoinTransaction</c> function changes the owner of the
	/// transaction to a new owner. The current owner can use this to determine when ownership of the transaction has changed. Leaving a
	/// transaction without an owner will roll back the transaction.
	/// </param>
	/// <returns>
	/// <para>The <c>MsiJoinTransaction</c> function can return the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>The user that owns the transaction and the user that joins the transaction are not the same.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>A parameter that is not valid is passed to the function.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSTALL_ALREADY_RUNNING</term>
	/// <term>The owner cannot be changed while an active installation is in progress.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_HANDLE_STATE</term>
	/// <term>The transaction ID provided is not valid.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Because a transaction can be owned by no more than one process at a time, the functions authored into the MsiEmbeddedChainer
	/// table can use <c>MsiJoinTransaction</c> to request ownership of the transaction before using the Windows Installer API to
	/// configure or install an application. The installer verifies that there is no installation in progress. The installer verifies
	/// that the process requesting ownership and the process that currently owns the transaction share a parent process in the same
	/// process tree. If the function succeeds, the process that calls <c>MsiJoinTransaction</c> becomes the current owner of the transaction.
	/// </para>
	/// <para>
	/// <c>MsiJoinTransaction</c> sets the internal UI of the new installation to the UI level of thew original installation. After the
	/// new installation owns the transaction, it can call MsiSetInternalUI to change the UI level. This enables the new installation to
	/// run at a higher UI level than the original installation.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msijointransaction UINT MsiJoinTransaction( MSIHANDLE
	// hTransactionHandle, DWORD dwTransactionAttributes, HANDLE *phChangeOfOwnerEvent );
	[DllImport(Lib_Msi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiJoinTransaction")]
	public static extern Win32Error MsiJoinTransaction(MSIHANDLE hTransactionHandle, MSITRANSACTION dwTransactionAttributes,
		out System.Threading.EventWaitHandle phChangeOfOwnerEvent);

	/// <summary>
	/// The <c>MsiLocateComponent</c> function returns the full path to an installed component without a product code. This function
	/// attempts to determine the product using MsiGetProductCode, but is not guaranteed to find the correct product for the caller.
	/// MsiGetComponentPath should always be called when possible.
	/// </summary>
	/// <param name="szComponent">Specifies the component ID of the component to be located.</param>
	/// <param name="lpPathBuf">
	/// Pointer to a variable that receives the path to the component. The variable includes the terminating null character.
	/// </param>
	/// <param name="pcchBuf">
	/// <para>
	/// Pointer to a variable that specifies the size, in characters, of the buffer pointed to by the lpPathBuf parameter. On input,
	/// this is the full size of the buffer, including a space for a terminating null character. Upon success of the
	/// <c>MsiLocateComponent</c> function, the variable pointed to by pcchBuf contains the count of characters not including the
	/// terminating null character. If the size of the buffer passed in is too small, the function returns INSTALLSTATE_MOREDATA.
	/// </para>
	/// <para>If lpPathBuf is null, pcchBuf can be null.</para>
	/// </param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>INSTALLSTATE_NOTUSED</term>
	/// <term>The component being requested is disabled on the computer.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLSTATE_ABSENT</term>
	/// <term>The component is not installed. See Remarks.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLSTATE_INVALIDARG</term>
	/// <term>One of the function parameters is invalid.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLSTATE_LOCAL</term>
	/// <term>The component is installed locally.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLSTATE_MOREDATA</term>
	/// <term>The buffer provided was too small.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLSTATE_SOURCE</term>
	/// <term>The component is installed to run from source.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLSTATE_SOURCEABSENT</term>
	/// <term>The component source is inaccessible.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLSTATE_UNKNOWN</term>
	/// <term>The product code or component ID is unknown. See Remarks.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>The <c>MsiLocateComponent</c> function might return INSTALLSTATE_ABSENT or INSTALL_STATE_UNKNOWN, for the following reasons:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>INSTALLSTATE_ABSENT</term>
	/// <description>
	/// The application did not properly ensure that the feature was installed by calling MsiUseFeature and, if necessary, MsiConfigureFeature.
	/// </description>
	/// </item>
	/// <item>
	/// <term>INSTALLSTATE_UNKNOWN</term>
	/// <description>
	/// The feature is not published. The application should have determined this earlier by calling MsiQueryFeatureState or
	/// MsiEnumFeatures. The application makes these calls while it initializes. An application should only use features that are known
	/// to be published. Since INSTALLSTATE_UNKNOWN should have been returned by MsiUseFeature as well, either MsiUseFeature was not
	/// called, or its return value was not properly checked.
	/// </description>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msilocatecomponenta INSTALLSTATE MsiLocateComponentA( LPCSTR
	// szComponent, LPSTR lpPathBuf, LPDWORD pcchBuf );
	[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiLocateComponentA")]
	public static extern INSTALLSTATE MsiLocateComponent([MarshalAs(UnmanagedType.LPTStr)] string szComponent,
		[Out, Optional, MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpPathBuf, ref uint pcchBuf);

	/// <summary>
	/// The <c>MsiNotifySidChange</c> function notifies and updates the Windows Installer internal information with changes to user SIDs.
	/// </summary>
	/// <param name="pOldSid">Null-terminated string that specifies the string value of the previous security identifier(SID).</param>
	/// <param name="pNewSid">Null-terminated string that specifies the string value of the new security identifier(SID).</param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>An invalid parameter is passed to the function. This error returned if any of the parameters is NULL.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SUCCESS</term>
	/// <term>The function succeeded.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_OUTOFMEMORY</term>
	/// <term>Insufficient memory was available.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_FUNCTION_FAILED</term>
	/// <term>Internal failure during execution.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <c>Windows Installer 2.0 and Windows Installer 3.0:</c> Not supported. This function is available beginning with Windows
	/// Installer 3.1.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msinotifysidchangea UINT MsiNotifySidChangeA( LPCSTR pOldSid,
	// LPCSTR pNewSid );
	[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiNotifySidChangeA")]
	public static extern Win32Error MsiNotifySidChange([MarshalAs(UnmanagedType.LPTStr)] string pOldSid,
		[MarshalAs(UnmanagedType.LPTStr)] string pNewSid);

	/// <summary>
	/// The <c>MsiOpenPackage</c> function opens a package to use with the functions that access the product database. The
	/// MsiCloseHandle function must be called with the handle when the handle is not needed.
	/// </summary>
	/// <param name="szPackagePath">The path to the package.</param>
	/// <param name="hProduct">A pointer to a variable that receives the product handle.</param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_BAD_CONFIGURATION</term>
	/// <term>The configuration information is corrupt.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSTALL_FAILURE</term>
	/// <term>The product could not be opened.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSTALL_REMOTE_PROHIBITED</term>
	/// <term>Windows Installer does not permit installation from a remote desktop connection.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>An invalid parameter is passed to the function.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SUCCESS</term>
	/// <term>The function completes successfully.</term>
	/// </item>
	/// </list>
	/// <para>If this function fails, it may return a system error code. For more information, see System Error Codes.</para>
	/// </returns>
	/// <remarks>
	/// MsiOpenPackage can accept an opened database handle in the form "#nnnn", where nnnn is the database handle in string form, i.e.
	/// #123, instead of a path to the package. This is intended for development tasks such as running validation actions, or for use
	/// with database management tools.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msiopenpackagea UINT MsiOpenPackageA( LPCSTR szPackagePath,
	// MSIHANDLE *hProduct );
	[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiOpenPackageA")]
	public static extern Win32Error MsiOpenPackage([MarshalAs(UnmanagedType.LPTStr)] string szPackagePath, out PMSIHANDLE hProduct);

	/// <summary>
	/// The <c>MsiOpenPackageEx</c> function opens a package to use with functions that access the product database. The MsiCloseHandle
	/// function must be called with the handle when the handle is no longer needed.
	/// </summary>
	/// <param name="szPackagePath">The path to the package.</param>
	/// <param name="dwOptions">
	/// <para>The bit flags to indicate whether or not to ignore the computer state. Pass in 0 (zero) to use MsiOpenPackage behavior.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Constant</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MSIOPENPACKAGEFLAGS_IGNOREMACHINESTATE 1</term>
	/// <term>Ignore the computer state when creating the product handle.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="hProduct">A pointer to a variable that receives the product handle.</param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_BAD_CONFIGURATION</term>
	/// <term>The configuration information is corrupt.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSTALL_FAILURE</term>
	/// <term>The product could not be opened.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSTALL_REMOTE_PROHIBITED</term>
	/// <term>Windows Installer does not permit installation from a remote desktop connection.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>An invalid parameter is passed to the function.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SUCCESS</term>
	/// <term>The function completes successfully.</term>
	/// </item>
	/// </list>
	/// <para>If this function fails, it may return a system error code. For more information, see System Error Codes.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// To create a restricted product handle that is independent of the current machine state and incapable of changing the current
	/// machine state, use <c>MsiOpenPackageEx</c> with MSIOPENPACKAGEFLAGS_IGNOREMACHINESTATE set in dwOptions.
	/// </para>
	/// <para>
	/// Note that if dwOptions is MSIOPENPACKAGEFLAGS_IGNOREMACHINESTATE or 1, <c>MsiOpenPackageEx</c> ignores the current machine state
	/// when creating the product handle. If the value of dwOptions is 0, <c>MsiOpenPackageEx</c> is the same as MsiOpenPackage and
	/// creates a product handle that is dependent upon whether the package specified by szPackagePath is already installed on the computer.
	/// </para>
	/// <para>
	/// The restricted handle created by using <c>MsiOpenPackageEx</c> with MSIOPENPACKAGEFLAGS_IGNOREMACHINESTATE only permits
	/// execution of dialogs, a subset of the standard actions, and custom actions that set properties ( Custom Action Type 35, Custom
	/// Action Type 51, and Custom Action Type 19). The restricted handle prevents the use of custom actions that run Dynamic-Link
	/// Libraries, Executable Files or Scripts.
	/// </para>
	/// <para>
	/// You can call MsiDoAction on the following standard actions using the restricted handle. All other actions return
	/// ERROR_FUNCTION_NOT_CALLED if called with the restricted handle.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>ADMIN</term>
	/// </item>
	/// <item>
	/// <term>ADVERTISE</term>
	/// </item>
	/// <item>
	/// <term>INSTALL</term>
	/// </item>
	/// <item>
	/// <term>SEQUENCE</term>
	/// </item>
	/// <item>
	/// <term>AppSearch action</term>
	/// </item>
	/// <item>
	/// <term>CCPSearch</term>
	/// </item>
	/// <item>
	/// <term>CostFinalize</term>
	/// </item>
	/// <item>
	/// <term>CostInitialize</term>
	/// </item>
	/// <item>
	/// <term>FileCost</term>
	/// </item>
	/// <item>
	/// <term>FindRelatedProducts</term>
	/// </item>
	/// <item>
	/// <term>IsolateComponents action</term>
	/// </item>
	/// <item>
	/// <term>LaunchConditions</term>
	/// </item>
	/// <item>
	/// <term>MigrateFeatureStates</term>
	/// </item>
	/// <item>
	/// <term>ResolveSource</term>
	/// </item>
	/// <item>
	/// <term>RMCCPSearch</term>
	/// </item>
	/// <item>
	/// <term>ValidateProductID</term>
	/// </item>
	/// </list>
	/// <para>The MsiCloseHandle function must be called when the handle is not needed.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msiopenpackageexa UINT MsiOpenPackageExA( LPCSTR szPackagePath,
	// DWORD dwOptions, MSIHANDLE *hProduct );
	[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiOpenPackageExA")]
	public static extern Win32Error MsiOpenPackageEx([MarshalAs(UnmanagedType.LPTStr)] string szPackagePath, MSIOPENPACKAGEFLAGS dwOptions,
		out PMSIHANDLE hProduct);

	/// <summary>
	/// <para>
	/// The <c>MsiOpenProduct</c> function opens a product for use with the functions that access the product database. The
	/// MsiCloseHandle function must be called with the handle when the handle is no longer needed.
	/// </para>
	/// <para>
	/// <c>Note</c> Initialize COM on the same thread before calling the MsiOpenPackage, MsiOpenPackageEx, or <c>MsiOpenProduct</c> function.
	/// </para>
	/// </summary>
	/// <param name="szProduct">Specifies the product code of the product to be opened.</param>
	/// <param name="hProduct">Pointer to a variable that receives the product handle.</param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_BAD_CONFIGURATION</term>
	/// <term>The configuration information is corrupt.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSTALL_FAILURE</term>
	/// <term>The product could not be opened.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSTALL_SOURCE_ABSENT</term>
	/// <term>The source was unavailable.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>An invalid parameter was passed to the function.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SUCCESS</term>
	/// <term>The function completed successfully.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNKNOWN_PRODUCT</term>
	/// <term>The product code was unrecognized.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks/>
	// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msiopenproducta UINT MsiOpenProductA( LPCSTR szProduct, MSIHANDLE
	// *hProduct );
	[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiOpenProductA")]
	public static extern Win32Error MsiOpenProduct([MarshalAs(UnmanagedType.LPTStr)] string szProduct, out PMSIHANDLE hProduct);

	/// <summary>The <c>MsiProcessAdvertiseScript</c> function processes an advertise script file into the specified locations.</summary>
	/// <param name="szScriptFile">The full path to a script file generated by MsiAdvertiseProduct or MsiAdvertiseProductEx.</param>
	/// <param name="szIconFolder">
	/// An optional path to a folder in which advertised icon files and transform files are located. If this parameter is <c>NULL</c>,
	/// no icon or transform files are written.
	/// </param>
	/// <param name="hRegData">
	/// A registry key under which registry data is to be written. If this parameter is <c>NULL</c>, the installer writes the registry
	/// data under the appropriate key, based on whether the advertisement is per-user or per-machine. If this parameter is non-
	/// <c>NULL</c>, the script will write the registry data under the specified registry key rather than the normal location. In this
	/// case, the application will not get advertised to the user.
	/// </param>
	/// <param name="fShortcuts">
	/// <c>TRUE</c> if shortcuts should be created. If a special folder is returned by SHGetSpecialFolderLocation it will hold the shortcuts.
	/// </param>
	/// <param name="fRemoveItems"><c>TRUE</c> if specified items are to be removed instead of created.</param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_SUCCESS</term>
	/// <term>The function completed successfully.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>The calling process was not running under the LocalSystem account.</term>
	/// </item>
	/// <item>
	/// <term>An error relating to an action</term>
	/// <term>See Error Codes.</term>
	/// </item>
	/// <item>
	/// <term>Initialization Error</term>
	/// <term>An error relating to initialization occurred.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_CALL_NOT_IMPLEMENTED</term>
	/// <term>This function is not available for this platform.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// The process calling this function must be running under the LocalSystem account. To advertise an application for per-user
	/// installation to a targeted user, the thread that calls this function must impersonate the targeted user. If the thread calling
	/// this function is not impersonating a targeted user, the application is advertised to all users for installation with elevated privileges.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msiprocessadvertisescripta UINT MsiProcessAdvertiseScriptA( LPCSTR
	// szScriptFile, LPCSTR szIconFolder, HKEY hRegData, BOOL fShortcuts, BOOL fRemoveItems );
	[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiProcessAdvertiseScriptA")]
	public static extern Win32Error MsiProcessAdvertiseScript([MarshalAs(UnmanagedType.LPTStr)] string szScriptFile,
		[Optional, MarshalAs(UnmanagedType.LPTStr)] string? szIconFolder, HKEY hRegData, [MarshalAs(UnmanagedType.Bool)] bool fShortcuts,
		[MarshalAs(UnmanagedType.Bool)] bool fRemoveItems);

	/// <summary>
	/// The <c>MsiProvideAssembly</c> function returns the full path to a Windows Installer component that contains an assembly. The
	/// function prompts for a source and performs any necessary installation. <c>MsiProvideAssembly</c> increments the usage count for
	/// the feature.
	/// </summary>
	/// <param name="szAssemblyName">The assembly name as a string.</param>
	/// <param name="szAppContext">
	/// Set to null for global assemblies. For private assemblies, set szAppContext to the full path of the application configuration
	/// file or to the full path of the executable file of the application to which the assembly has been made private.
	/// </param>
	/// <param name="dwInstallMode">
	/// <para>Defines the installation mode. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>INSTALLMODE_DEFAULT</term>
	/// <term>
	/// Provide the component and perform any installation necessary to provide the component. If the key file of a component in the
	/// requested feature, or a feature parent, is missing, reinstall the feature using MsiReinstallFeature with the following flag bits
	/// set: REINSTALLMODE_FILEMISSING, REINSTALLMODE_FILEOLDERVERSION, REINSTALLMODE_FILEVERIFY, REINSTALLMODE_MACHINEDATA,
	/// REINSTALLMODE_USERDATA and REINSTALLMODE_SHORTCUT.
	/// </term>
	/// </item>
	/// <item>
	/// <term>INSTALLMODE_EXISTING</term>
	/// <term>
	/// Provide the component only if the feature exists. Otherwise return ERROR_FILE_NOT_FOUND. This mode verifies that the key file of
	/// the component exists.
	/// </term>
	/// </item>
	/// <item>
	/// <term>INSTALLMODE_NODETECTION</term>
	/// <term>
	/// Provide the component only if the feature exists. Otherwise return ERROR_FILE_NOT_FOUND. This mode only checks that the
	/// component is registered and does not verify that the key file of the component exists.
	/// </term>
	/// </item>
	/// <item>
	/// <term>INSTALLMODE_NOSOURCERESOLUTION</term>
	/// <term>
	/// Provide the component only if the feature's installation state is INSTALLSTATE_LOCAL. If the feature installation state is
	/// INSTALLSTATE_SOURCE, return ERROR_INSTALL_SOURCE_ABSENT. Otherwise return ERROR_FILE_NOT_FOUND. This mode only checks that the
	/// component is registered and does not verify that the key file exists.
	/// </term>
	/// </item>
	/// <item>
	/// <term>INSTALLMODE_NODETECTION_ANY</term>
	/// <term>
	/// Provide the component if a feature exists from any installed product. Otherwise return ERROR_FILE_NOT_FOUND. This mode only
	/// checks that the component is registered and does not verify that the key file of the component exists. This flag is similar to
	/// the INSTALLMODE_NODETECTION flag except that with this flag we check for any product that has installed the assembly as opposed
	/// to the last product as is the case with the INSTALLMODE_NODETECTION flag. This flag can only be used with MsiProvideAssembly.
	/// </term>
	/// </item>
	/// <item>
	/// <term>combination of the REINSTALLMODE flags</term>
	/// <term>
	/// Call MsiReinstallFeature to reinstall feature using this parameter for the dwReinstallMode parameter, and then provide the component.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwAssemblyInfo">
	/// <para>Assembly information and assembly type. Set to one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MSIASSEMBLYINFO_NETASSEMBLY 0</term>
	/// <term>.NET Assembly</term>
	/// </item>
	/// <item>
	/// <term>MSIASSEMBLYINFO_WIN32ASSEMBLY 1</term>
	/// <term>Win32 Assembly</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="lpPathBuf">Pointer to a variable that receives the path to the component. This parameter can be null.</param>
	/// <param name="pcchPathBuf">
	/// <para>
	/// Pointer to a variable that specifies the size, in characters, of the buffer pointed to by the lpPathBuf parameter. On input,
	/// this is the full size of the buffer, including a space for a terminating null character. If the buffer passed in is too small,
	/// the count returned does not include the terminating null character.
	/// </para>
	/// <para>If lpPathBuf is null, pcchPathBuf can be null.</para>
	/// </param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_BAD_CONFIGURATION</term>
	/// <term>The configuration data is corrupt.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_FILE_NOT_FOUND</term>
	/// <term>The feature is absent or broken. This error is returned for dwInstallMode = INSTALLMODE_EXISTING.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSTALL_FAILURE</term>
	/// <term>The installation failed.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSTALL_NOTUSED</term>
	/// <term>The component being requested is disabled on the computer.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>An invalid parameter was passed to the function.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SUCCESS</term>
	/// <term>The function completed successfully.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNKNOWN_FEATURE</term>
	/// <term>The feature ID does not identify a known feature.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNKNOWN_COMPONENT</term>
	/// <term>The component ID does not specify a known component.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNKNOWN_PRODUCT</term>
	/// <term>The product code does not identify a known product.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLSTATE_UNKNOWN</term>
	/// <term>An unrecognized product or a feature name was passed to the function.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>The buffer overflow is returned.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
	/// <term>The system does not have enough memory to complete the operation. Available with Windows Server 2003.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSTALL_SOURCE_ABSENT</term>
	/// <term>Unable to detect a source.</term>
	/// </item>
	/// </list>
	/// <para>For more information, see Displayed Error Messages.</para>
	/// </returns>
	/// <remarks>
	/// <para>When the <c>MsiProvideAssembly</c> function succeeds, the pcchPathBuf parameter contains the length of the string in lpPathBuf.</para>
	/// <para>The INSTALLMODE_EXISTING option cannot be used in combination with the REINSTALLMODE flag.</para>
	/// <para>
	/// Features with components that contain a corrupted file or the wrong version of a file must be explicitly reinstalled by the
	/// user, or by having the application call MsiReinstallFeature.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msiprovideassemblya UINT MsiProvideAssemblyA( LPCSTR
	// szAssemblyName, LPCSTR szAppContext, DWORD dwInstallMode, DWORD dwAssemblyInfo, LPSTR lpPathBuf, LPDWORD pcchPathBuf );
	[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiProvideAssemblyA")]
	public static extern Win32Error MsiProvideAssembly([MarshalAs(UnmanagedType.LPTStr)] string szAssemblyName,
		[Optional, MarshalAs(UnmanagedType.LPTStr)] string? szAppContext, INSTALLMODE dwInstallMode, MSIASSEMBLYINFO dwAssemblyInfo,
		[Out, Optional, MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpPathBuf, ref uint pcchPathBuf);

	/// <summary>
	/// The <c>MsiProvideAssembly</c> function returns the full path to a Windows Installer component that contains an assembly. The
	/// function prompts for a source and performs any necessary installation. <c>MsiProvideAssembly</c> increments the usage count for
	/// the feature.
	/// </summary>
	/// <param name="szAssemblyName">The assembly name as a string.</param>
	/// <param name="szAppContext">
	/// Set to null for global assemblies. For private assemblies, set szAppContext to the full path of the application configuration
	/// file or to the full path of the executable file of the application to which the assembly has been made private.
	/// </param>
	/// <param name="dwInstallMode">
	/// <para>Defines the installation mode. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>INSTALLMODE_DEFAULT</term>
	/// <term>
	/// Provide the component and perform any installation necessary to provide the component. If the key file of a component in the
	/// requested feature, or a feature parent, is missing, reinstall the feature using MsiReinstallFeature with the following flag bits
	/// set: REINSTALLMODE_FILEMISSING, REINSTALLMODE_FILEOLDERVERSION, REINSTALLMODE_FILEVERIFY, REINSTALLMODE_MACHINEDATA,
	/// REINSTALLMODE_USERDATA and REINSTALLMODE_SHORTCUT.
	/// </term>
	/// </item>
	/// <item>
	/// <term>INSTALLMODE_EXISTING</term>
	/// <term>
	/// Provide the component only if the feature exists. Otherwise return ERROR_FILE_NOT_FOUND. This mode verifies that the key file of
	/// the component exists.
	/// </term>
	/// </item>
	/// <item>
	/// <term>INSTALLMODE_NODETECTION</term>
	/// <term>
	/// Provide the component only if the feature exists. Otherwise return ERROR_FILE_NOT_FOUND. This mode only checks that the
	/// component is registered and does not verify that the key file of the component exists.
	/// </term>
	/// </item>
	/// <item>
	/// <term>INSTALLMODE_NOSOURCERESOLUTION</term>
	/// <term>
	/// Provide the component only if the feature's installation state is INSTALLSTATE_LOCAL. If the feature installation state is
	/// INSTALLSTATE_SOURCE, return ERROR_INSTALL_SOURCE_ABSENT. Otherwise return ERROR_FILE_NOT_FOUND. This mode only checks that the
	/// component is registered and does not verify that the key file exists.
	/// </term>
	/// </item>
	/// <item>
	/// <term>INSTALLMODE_NODETECTION_ANY</term>
	/// <term>
	/// Provide the component if a feature exists from any installed product. Otherwise return ERROR_FILE_NOT_FOUND. This mode only
	/// checks that the component is registered and does not verify that the key file of the component exists. This flag is similar to
	/// the INSTALLMODE_NODETECTION flag except that with this flag we check for any product that has installed the assembly as opposed
	/// to the last product as is the case with the INSTALLMODE_NODETECTION flag. This flag can only be used with MsiProvideAssembly.
	/// </term>
	/// </item>
	/// <item>
	/// <term>combination of the REINSTALLMODE flags</term>
	/// <term>
	/// Call MsiReinstallFeature to reinstall feature using this parameter for the dwReinstallMode parameter, and then provide the component.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwAssemblyInfo">
	/// <para>Assembly information and assembly type. Set to one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MSIASSEMBLYINFO_NETASSEMBLY 0</term>
	/// <term>.NET Assembly</term>
	/// </item>
	/// <item>
	/// <term>MSIASSEMBLYINFO_WIN32ASSEMBLY 1</term>
	/// <term>Win32 Assembly</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="lpPathBuf">Pointer to a variable that receives the path to the component. This parameter can be null.</param>
	/// <param name="pcchPathBuf">
	/// <para>
	/// Pointer to a variable that specifies the size, in characters, of the buffer pointed to by the lpPathBuf parameter. On input,
	/// this is the full size of the buffer, including a space for a terminating null character. If the buffer passed in is too small,
	/// the count returned does not include the terminating null character.
	/// </para>
	/// <para>If lpPathBuf is null, pcchPathBuf can be null.</para>
	/// </param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_BAD_CONFIGURATION</term>
	/// <term>The configuration data is corrupt.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_FILE_NOT_FOUND</term>
	/// <term>The feature is absent or broken. This error is returned for dwInstallMode = INSTALLMODE_EXISTING.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSTALL_FAILURE</term>
	/// <term>The installation failed.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSTALL_NOTUSED</term>
	/// <term>The component being requested is disabled on the computer.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>An invalid parameter was passed to the function.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SUCCESS</term>
	/// <term>The function completed successfully.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNKNOWN_FEATURE</term>
	/// <term>The feature ID does not identify a known feature.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNKNOWN_COMPONENT</term>
	/// <term>The component ID does not specify a known component.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNKNOWN_PRODUCT</term>
	/// <term>The product code does not identify a known product.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLSTATE_UNKNOWN</term>
	/// <term>An unrecognized product or a feature name was passed to the function.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>The buffer overflow is returned.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NOT_ENOUGH_MEMORY</term>
	/// <term>The system does not have enough memory to complete the operation. Available with Windows Server 2003.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSTALL_SOURCE_ABSENT</term>
	/// <term>Unable to detect a source.</term>
	/// </item>
	/// </list>
	/// <para>For more information, see Displayed Error Messages.</para>
	/// </returns>
	/// <remarks>
	/// <para>When the <c>MsiProvideAssembly</c> function succeeds, the pcchPathBuf parameter contains the length of the string in lpPathBuf.</para>
	/// <para>The INSTALLMODE_EXISTING option cannot be used in combination with the REINSTALLMODE flag.</para>
	/// <para>
	/// Features with components that contain a corrupted file or the wrong version of a file must be explicitly reinstalled by the
	/// user, or by having the application call MsiReinstallFeature.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msiprovideassemblya UINT MsiProvideAssemblyA( LPCSTR
	// szAssemblyName, LPCSTR szAppContext, DWORD dwInstallMode, DWORD dwAssemblyInfo, LPSTR lpPathBuf, LPDWORD pcchPathBuf );
	[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiProvideAssemblyA")]
	public static extern Win32Error MsiProvideAssembly([MarshalAs(UnmanagedType.LPTStr)] string szAssemblyName,
		[Optional, MarshalAs(UnmanagedType.LPTStr)] string? szAppContext, INSTALLMODE dwInstallMode, MSIASSEMBLYINFO dwAssemblyInfo,
		[Out, Optional, MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpPathBuf, [In, Optional] IntPtr pcchPathBuf);

	/// <summary>
	/// The <c>MsiProvideComponent</c> function returns the full component path, performing any necessary installation. This function
	/// prompts for source if necessary and increments the usage count for the feature.
	/// </summary>
	/// <param name="szProduct">Specifies the product code for the product that contains the feature with the necessary component.</param>
	/// <param name="szFeature">Specifies the feature ID of the feature with the necessary component.</param>
	/// <param name="szComponent">Specifies the component code of the necessary component.</param>
	/// <param name="dwInstallMode">
	/// <para>Defines the installation mode. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>INSTALLMODE_DEFAULT</term>
	/// <term>
	/// Provide the component and perform any installation necessary to provide the component. If the key file of a component in the
	/// requested feature, or a feature parent, is missing, reinstall the feature using MsiReinstallFeature with the following flag bits
	/// set: REINSTALLMODE_FILEMISSING, REINSTALLMODE_FILEOLDERVERSION, REINSTALLMODE_FILEVERIFY, REINSTALLMODE_MACHINEDATA,
	/// REINSTALLMODE_USERDATA and REINSTALLMODE_SHORTCUT.
	/// </term>
	/// </item>
	/// <item>
	/// <term>INSTALLMODE_EXISTING</term>
	/// <term>
	/// Provide the component only if the feature exists. Otherwise return ERROR_FILE_NOT_FOUND. This mode verifies that the key file of
	/// the component exists.
	/// </term>
	/// </item>
	/// <item>
	/// <term>INSTALLMODE_NODETECTION</term>
	/// <term>
	/// Provide the component only if the feature exists. Otherwise return ERROR_FILE_NOT_FOUND. This mode only checks that the
	/// component is registered and does not verify that the key file of the component exists.
	/// </term>
	/// </item>
	/// <item>
	/// <term>combination of the REINSTALLMODE flags</term>
	/// <term>
	/// Call MsiReinstallFeature to reinstall feature using this parameter for the dwReinstallMode parameter, and then provide the component.
	/// </term>
	/// </item>
	/// <item>
	/// <term>INSTALLMODE_NOSOURCERESOLUTION</term>
	/// <term>
	/// Provide the component only if the feature's installation state is INSTALLSTATE_LOCAL. If the feature's installation state is
	/// INSTALLSTATE_SOURCE, return ERROR_INSTALL_SOURCE_ABSENT. Otherwise return ERROR_FILE_NOT_FOUND. This mode only checks that the
	/// component is registered and does not verify that the key file exists.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="lpPathBuf">Pointer to a variable that receives the path to the component. This parameter can be null.</param>
	/// <param name="pcchPathBuf">
	/// <para>
	/// Pointer to a variable that specifies the size, in characters, of the buffer pointed to by the lpPathBuf parameter. On input,
	/// this is the full size of the buffer, including a space for a terminating null character. If the buffer passed in is too small,
	/// the count returned does not include the terminating null character.
	/// </para>
	/// <para>If lpPathBuf is null, pcchBuf can be null.</para>
	/// </param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_BAD_CONFIGURATION</term>
	/// <term>The configuration data is corrupt.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_FILE_NOT_FOUND</term>
	/// <term>The feature is absent or broken. this error is returned for dwInstallMode = INSTALLMODE_EXISTING.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSTALL_FAILURE</term>
	/// <term>The installation failed.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSTALL_NOTUSED</term>
	/// <term>The component being requested is disabled on the computer.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>An invalid parameter was passed to the function.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SUCCESS</term>
	/// <term>The function completed successfully.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNKNOWN_FEATURE</term>
	/// <term>The feature ID does not identify a known feature.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNKNOWN_PRODUCT</term>
	/// <term>The product code does not identify a known product.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLSTATE_UNKNOWN</term>
	/// <term>An unrecognized product or a feature name was passed to the function.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>The buffer overflow is returned.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSTALL_SOURCE_ABSENT</term>
	/// <term>Unable to detect a source.</term>
	/// </item>
	/// </list>
	/// <para>For more information, see Displayed Error Messages.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Upon success of the <c>MsiProvideComponent</c> function, the pcchPathBuf parameter contains the length of the string in lpPathBuf.
	/// </para>
	/// <para>
	/// The <c>MsiProvideComponent</c> function combines the functionality of MsiUseFeature, MsiConfigureFeature, and
	/// MsiGetComponentPath. You can use the <c>MsiProvideComponent</c> function to simplify the calling sequence. However, because this
	/// function increments the usage count, use it with caution to prevent inaccurate usage counts. The <c>MsiProvideComponent</c>
	/// function also provides less flexibility than the series of individual calls.
	/// </para>
	/// <para>
	/// If the application is recovering from an unexpected situation, the application has probably already called MsiUseFeature and
	/// incremented the usage count. In this case, the application should call MsiConfigureFeature instead of <c>MsiProvideComponent</c>
	/// to avoid incrementing the count again.
	/// </para>
	/// <para>The INSTALLMODE_EXISTING option cannot be used in combination with the REINSTALLMODE flag.</para>
	/// <para>
	/// Features with components containing a corrupted file or the wrong version of a file must be explicitly reinstalled by the user
	/// or by having the application call MsiReinstallFeature.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msiprovidecomponenta UINT MsiProvideComponentA( LPCSTR szProduct,
	// LPCSTR szFeature, LPCSTR szComponent, DWORD dwInstallMode, LPSTR lpPathBuf, LPDWORD pcchPathBuf );
	[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiProvideComponentA")]
	public static extern Win32Error MsiProvideComponent([MarshalAs(UnmanagedType.LPTStr)] string szProduct,
		[MarshalAs(UnmanagedType.LPTStr)] string szFeature, [MarshalAs(UnmanagedType.LPTStr)] string szComponent,
		INSTALLMODE dwInstallMode, [Out, Optional, MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpPathBuf, ref uint pcchPathBuf);

	/// <summary>
	/// The <c>MsiProvideComponent</c> function returns the full component path, performing any necessary installation. This function
	/// prompts for source if necessary and increments the usage count for the feature.
	/// </summary>
	/// <param name="szProduct">Specifies the product code for the product that contains the feature with the necessary component.</param>
	/// <param name="szFeature">Specifies the feature ID of the feature with the necessary component.</param>
	/// <param name="szComponent">Specifies the component code of the necessary component.</param>
	/// <param name="dwInstallMode">
	/// <para>Defines the installation mode. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>INSTALLMODE_DEFAULT</term>
	/// <term>
	/// Provide the component and perform any installation necessary to provide the component. If the key file of a component in the
	/// requested feature, or a feature parent, is missing, reinstall the feature using MsiReinstallFeature with the following flag bits
	/// set: REINSTALLMODE_FILEMISSING, REINSTALLMODE_FILEOLDERVERSION, REINSTALLMODE_FILEVERIFY, REINSTALLMODE_MACHINEDATA,
	/// REINSTALLMODE_USERDATA and REINSTALLMODE_SHORTCUT.
	/// </term>
	/// </item>
	/// <item>
	/// <term>INSTALLMODE_EXISTING</term>
	/// <term>
	/// Provide the component only if the feature exists. Otherwise return ERROR_FILE_NOT_FOUND. This mode verifies that the key file of
	/// the component exists.
	/// </term>
	/// </item>
	/// <item>
	/// <term>INSTALLMODE_NODETECTION</term>
	/// <term>
	/// Provide the component only if the feature exists. Otherwise return ERROR_FILE_NOT_FOUND. This mode only checks that the
	/// component is registered and does not verify that the key file of the component exists.
	/// </term>
	/// </item>
	/// <item>
	/// <term>combination of the REINSTALLMODE flags</term>
	/// <term>
	/// Call MsiReinstallFeature to reinstall feature using this parameter for the dwReinstallMode parameter, and then provide the component.
	/// </term>
	/// </item>
	/// <item>
	/// <term>INSTALLMODE_NOSOURCERESOLUTION</term>
	/// <term>
	/// Provide the component only if the feature's installation state is INSTALLSTATE_LOCAL. If the feature's installation state is
	/// INSTALLSTATE_SOURCE, return ERROR_INSTALL_SOURCE_ABSENT. Otherwise return ERROR_FILE_NOT_FOUND. This mode only checks that the
	/// component is registered and does not verify that the key file exists.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="lpPathBuf">Pointer to a variable that receives the path to the component. This parameter can be null.</param>
	/// <param name="pcchPathBuf">
	/// <para>
	/// Pointer to a variable that specifies the size, in characters, of the buffer pointed to by the lpPathBuf parameter. On input,
	/// this is the full size of the buffer, including a space for a terminating null character. If the buffer passed in is too small,
	/// the count returned does not include the terminating null character.
	/// </para>
	/// <para>If lpPathBuf is null, pcchBuf can be null.</para>
	/// </param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_BAD_CONFIGURATION</term>
	/// <term>The configuration data is corrupt.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_FILE_NOT_FOUND</term>
	/// <term>The feature is absent or broken. this error is returned for dwInstallMode = INSTALLMODE_EXISTING.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSTALL_FAILURE</term>
	/// <term>The installation failed.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSTALL_NOTUSED</term>
	/// <term>The component being requested is disabled on the computer.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>An invalid parameter was passed to the function.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SUCCESS</term>
	/// <term>The function completed successfully.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNKNOWN_FEATURE</term>
	/// <term>The feature ID does not identify a known feature.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNKNOWN_PRODUCT</term>
	/// <term>The product code does not identify a known product.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLSTATE_UNKNOWN</term>
	/// <term>An unrecognized product or a feature name was passed to the function.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>The buffer overflow is returned.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSTALL_SOURCE_ABSENT</term>
	/// <term>Unable to detect a source.</term>
	/// </item>
	/// </list>
	/// <para>For more information, see Displayed Error Messages.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Upon success of the <c>MsiProvideComponent</c> function, the pcchPathBuf parameter contains the length of the string in lpPathBuf.
	/// </para>
	/// <para>
	/// The <c>MsiProvideComponent</c> function combines the functionality of MsiUseFeature, MsiConfigureFeature, and
	/// MsiGetComponentPath. You can use the <c>MsiProvideComponent</c> function to simplify the calling sequence. However, because this
	/// function increments the usage count, use it with caution to prevent inaccurate usage counts. The <c>MsiProvideComponent</c>
	/// function also provides less flexibility than the series of individual calls.
	/// </para>
	/// <para>
	/// If the application is recovering from an unexpected situation, the application has probably already called MsiUseFeature and
	/// incremented the usage count. In this case, the application should call MsiConfigureFeature instead of <c>MsiProvideComponent</c>
	/// to avoid incrementing the count again.
	/// </para>
	/// <para>The INSTALLMODE_EXISTING option cannot be used in combination with the REINSTALLMODE flag.</para>
	/// <para>
	/// Features with components containing a corrupted file or the wrong version of a file must be explicitly reinstalled by the user
	/// or by having the application call MsiReinstallFeature.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msiprovidecomponenta UINT MsiProvideComponentA( LPCSTR szProduct,
	// LPCSTR szFeature, LPCSTR szComponent, DWORD dwInstallMode, LPSTR lpPathBuf, LPDWORD pcchPathBuf );
	[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiProvideComponentA")]
	public static extern Win32Error MsiProvideComponent([MarshalAs(UnmanagedType.LPTStr)] string szProduct,
		[MarshalAs(UnmanagedType.LPTStr)] string szFeature, [MarshalAs(UnmanagedType.LPTStr)] string szComponent,
		INSTALLMODE dwInstallMode, [Out, Optional, MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpPathBuf, [In, Optional] IntPtr pcchPathBuf);

	/// <summary>
	/// The <c>MsiProvideQualifiedComponent</c> function returns the full component path for a qualified component and performs any
	/// necessary installation. This function prompts for source if necessary, and increments the usage count for the feature.
	/// </summary>
	/// <param name="szCategory">
	/// Specifies the component ID for the requested component. This may not be the GUID for the component itself, but rather a server
	/// that provides the correct functionality, as in the ComponentId column of the PublishComponent table.
	/// </param>
	/// <param name="szQualifier">Specifies a qualifier into a list of advertising components (from PublishComponent Table).</param>
	/// <param name="dwInstallMode">
	/// <para>Defines the installation mode. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>INSTALLMODE_DEFAULT</term>
	/// <term>
	/// Provide the component and perform any installation necessary to provide the component. If the key file of a component in the
	/// requested feature, or a feature parent, is missing, reinstall the feature using MsiReinstallFeature with the following flag bits
	/// set: REINSTALLMODE_FILEMISSING, REINSTALLMODE_FILEOLDERVERSION, REINSTALLMODE_FILEVERIFY, REINSTALLMODE_MACHINEDATA,
	/// REINSTALLMODE_USERDATA, and REINSTALLMODE_SHORTCUT.
	/// </term>
	/// </item>
	/// <item>
	/// <term>INSTALLMODE_EXISTING</term>
	/// <term>
	/// Provide the component only if the feature exists. Otherwise return ERROR_FILE_NOT_FOUND. This mode verifies that the key file of
	/// the component exists.
	/// </term>
	/// </item>
	/// <item>
	/// <term>INSTALLMODE_NODETECTION</term>
	/// <term>
	/// Provide the component only if the feature exists. Otherwise return ERROR_FILE_NOT_FOUND. This mode only checks that the
	/// component is registered and does not verify that the key file of the component exists.
	/// </term>
	/// </item>
	/// <item>
	/// <term>combination of the REINSTALLMODE flags</term>
	/// <term>
	/// Call MsiReinstallFeature to reinstall the feature using this parameter for the dwReinstallMode parameter, and then provide the component.
	/// </term>
	/// </item>
	/// <item>
	/// <term>INSTALLMODE_NOSOURCERESOLUTION</term>
	/// <term>
	/// Provide the component only if the feature's installation state is INSTALLSTATE_LOCAL. If the feature's installation state is
	/// INSTALLSTATE_SOURCE, return ERROR_INSTALL_SOURCE_ABSENT. Otherwise, it returns ERROR_FILE_NOT_FOUND. This mode only checks that
	/// the component is registered and does not verify that the key file exists.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="lpPathBuf">Pointer to a variable that receives the path to the component. This parameter can be null.</param>
	/// <param name="pcchPathBuf">
	/// <para>
	/// Pointer to a variable that specifies the size, in characters, of the buffer pointed to by the lpPathBuf parameter. On input,
	/// this is the full size of the buffer, including a space for a terminating null character. If the buffer passed in is too small,
	/// the count returned does not include the terminating null character.
	/// </para>
	/// <para>If lpPathBuf is null, pcchBuf can be null.</para>
	/// </param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INDEX_ABSENT</term>
	/// <term>The component qualifier is invalid or absent.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SUCCESS</term>
	/// <term>The function completed successfully.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_FILE_NOT_FOUND</term>
	/// <term>The feature is absent or broken. This error is returned for dwInstallMode = INSTALLMODE_EXISTING.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNKNOWN_COMPONENT</term>
	/// <term>The specified component is unknown.</term>
	/// </item>
	/// <item>
	/// <term>An error relating to an action</term>
	/// <term>See Error Codes.</term>
	/// </item>
	/// <item>
	/// <term>Initialization Error</term>
	/// <term>An error relating to initialization occurred.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Upon success of the <c>MsiProvideQualifiedComponent</c> function, the pcchPathBuf parameter contains the length of the string in lpPathBuf.
	/// </para>
	/// <para>
	/// Features with components containing a corrupted file or the wrong version of a file must be explicitly reinstalled by the user
	/// or by having the application call MsiReinstallFeature.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msiprovidequalifiedcomponenta UINT MsiProvideQualifiedComponentA(
	// LPCSTR szCategory, LPCSTR szQualifier, DWORD dwInstallMode, LPSTR lpPathBuf, LPDWORD pcchPathBuf );
	[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiProvideQualifiedComponentA")]
	public static extern Win32Error MsiProvideQualifiedComponent([MarshalAs(UnmanagedType.LPTStr)] string szCategory,
		[MarshalAs(UnmanagedType.LPTStr)] string szQualifier, INSTALLMODE dwInstallMode,
		[Out, Optional, MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpPathBuf, ref uint pcchPathBuf);

	/// <summary>
	/// The <c>MsiProvideQualifiedComponent</c> function returns the full component path for a qualified component and performs any
	/// necessary installation. This function prompts for source if necessary, and increments the usage count for the feature.
	/// </summary>
	/// <param name="szCategory">
	/// Specifies the component ID for the requested component. This may not be the GUID for the component itself, but rather a server
	/// that provides the correct functionality, as in the ComponentId column of the PublishComponent table.
	/// </param>
	/// <param name="szQualifier">Specifies a qualifier into a list of advertising components (from PublishComponent Table).</param>
	/// <param name="dwInstallMode">
	/// <para>Defines the installation mode. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>INSTALLMODE_DEFAULT</term>
	/// <term>
	/// Provide the component and perform any installation necessary to provide the component. If the key file of a component in the
	/// requested feature, or a feature parent, is missing, reinstall the feature using MsiReinstallFeature with the following flag bits
	/// set: REINSTALLMODE_FILEMISSING, REINSTALLMODE_FILEOLDERVERSION, REINSTALLMODE_FILEVERIFY, REINSTALLMODE_MACHINEDATA,
	/// REINSTALLMODE_USERDATA, and REINSTALLMODE_SHORTCUT.
	/// </term>
	/// </item>
	/// <item>
	/// <term>INSTALLMODE_EXISTING</term>
	/// <term>
	/// Provide the component only if the feature exists. Otherwise return ERROR_FILE_NOT_FOUND. This mode verifies that the key file of
	/// the component exists.
	/// </term>
	/// </item>
	/// <item>
	/// <term>INSTALLMODE_NODETECTION</term>
	/// <term>
	/// Provide the component only if the feature exists. Otherwise return ERROR_FILE_NOT_FOUND. This mode only checks that the
	/// component is registered and does not verify that the key file of the component exists.
	/// </term>
	/// </item>
	/// <item>
	/// <term>combination of the REINSTALLMODE flags</term>
	/// <term>
	/// Call MsiReinstallFeature to reinstall the feature using this parameter for the dwReinstallMode parameter, and then provide the component.
	/// </term>
	/// </item>
	/// <item>
	/// <term>INSTALLMODE_NOSOURCERESOLUTION</term>
	/// <term>
	/// Provide the component only if the feature's installation state is INSTALLSTATE_LOCAL. If the feature's installation state is
	/// INSTALLSTATE_SOURCE, return ERROR_INSTALL_SOURCE_ABSENT. Otherwise, it returns ERROR_FILE_NOT_FOUND. This mode only checks that
	/// the component is registered and does not verify that the key file exists.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="lpPathBuf">Pointer to a variable that receives the path to the component. This parameter can be null.</param>
	/// <param name="pcchPathBuf">
	/// <para>
	/// Pointer to a variable that specifies the size, in characters, of the buffer pointed to by the lpPathBuf parameter. On input,
	/// this is the full size of the buffer, including a space for a terminating null character. If the buffer passed in is too small,
	/// the count returned does not include the terminating null character.
	/// </para>
	/// <para>If lpPathBuf is null, pcchBuf can be null.</para>
	/// </param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INDEX_ABSENT</term>
	/// <term>The component qualifier is invalid or absent.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SUCCESS</term>
	/// <term>The function completed successfully.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_FILE_NOT_FOUND</term>
	/// <term>The feature is absent or broken. This error is returned for dwInstallMode = INSTALLMODE_EXISTING.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNKNOWN_COMPONENT</term>
	/// <term>The specified component is unknown.</term>
	/// </item>
	/// <item>
	/// <term>An error relating to an action</term>
	/// <term>See Error Codes.</term>
	/// </item>
	/// <item>
	/// <term>Initialization Error</term>
	/// <term>An error relating to initialization occurred.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Upon success of the <c>MsiProvideQualifiedComponent</c> function, the pcchPathBuf parameter contains the length of the string in lpPathBuf.
	/// </para>
	/// <para>
	/// Features with components containing a corrupted file or the wrong version of a file must be explicitly reinstalled by the user
	/// or by having the application call MsiReinstallFeature.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msiprovidequalifiedcomponenta UINT MsiProvideQualifiedComponentA(
	// LPCSTR szCategory, LPCSTR szQualifier, DWORD dwInstallMode, LPSTR lpPathBuf, LPDWORD pcchPathBuf );
	[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiProvideQualifiedComponentA")]
	public static extern Win32Error MsiProvideQualifiedComponent([MarshalAs(UnmanagedType.LPTStr)] string szCategory,
		[MarshalAs(UnmanagedType.LPTStr)] string szQualifier, INSTALLMODE dwInstallMode,
		[Out, Optional, MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpPathBuf, [In, Optional] IntPtr pcchPathBuf);

	/// <summary>
	/// The <c>MsiProvideQualifiedComponentEx</c> function returns the full component path for a qualified component that is published
	/// by a product and performs any necessary installation. This function prompts for source if necessary and increments the usage
	/// count for the feature.
	/// </summary>
	/// <param name="szCategory">
	/// Specifies the component ID that for the requested component. This may not be the GUID for the component itself but rather a
	/// server that provides the correct functionality, as in the ComponentId column of the PublishComponent table.
	/// </param>
	/// <param name="szQualifier">Specifies a qualifier into a list of advertising components (from PublishComponent Table).</param>
	/// <param name="dwInstallMode">
	/// <para>Defines the installation mode. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>INSTALLMODE_DEFAULT</term>
	/// <term>
	/// Provide the component and perform any installation necessary to provide the component. If the key file of a component in the
	/// requested feature, or a feature parent, is missing, reinstall the feature using MsiReinstallFeature with the following flag bits
	/// set: REINSTALLMODE_FILEMISSING, REINSTALLMODE_FILEOLDERVERSION, REINSTALLMODE_FILEVERIFY, REINSTALLMODE_MACHINEDATA,
	/// REINSTALLMODE_USERDATA and REINSTALLMODE_SHORTCUT.
	/// </term>
	/// </item>
	/// <item>
	/// <term>INSTALLMODE_EXISTING</term>
	/// <term>
	/// Provide the component only if the feature exists. Otherwise return ERROR_FILE_NOT_FOUND. This mode verifies that the key file of
	/// the component exists.
	/// </term>
	/// </item>
	/// <item>
	/// <term>INSTALLMODE_NODETECTION</term>
	/// <term>
	/// Provide the component only if the feature exists. Otherwise return ERROR_FILE_NOT_FOUND. This mode only checks that the
	/// component is registered and does not verify that the key file of the component exists.
	/// </term>
	/// </item>
	/// <item>
	/// <term>INSTALLMODE_EXISTING</term>
	/// <term>Provide the component only if the feature exists, else return ERROR_FILE_NOT_FOUND.</term>
	/// </item>
	/// <item>
	/// <term>combination of the REINSTALLMODE flags</term>
	/// <term>
	/// Call MsiReinstallFeature to reinstall feature using this parameter for the dwReinstallMode parameter, and then provide the component.
	/// </term>
	/// </item>
	/// <item>
	/// <term>INSTALLMODE_NOSOURCERESOLUTION</term>
	/// <term>
	/// Provide the component only if the feature's installation state is INSTALLSTATE_LOCAL. If the feature's installation state is
	/// INSTALLSTATE_SOURCE, return ERROR_INSTALL_SOURCE_ABSENT. Otherwise return ERROR_FILE_NOT_FOUND. This mode only checks that the
	/// component is registered and does not verify that the key file exists.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="szProduct">
	/// Specifies the product to match that has published the qualified component. If this is null, then this API works the same as MsiProvideQualifiedComponent.
	/// </param>
	/// <param name="dwUnused1">Reserved. Must be zero.</param>
	/// <param name="dwUnused2">Reserved. Must be zero.</param>
	/// <param name="lpPathBuf">Pointer to a variable that receives the path to the component. This parameter can be null.</param>
	/// <param name="pcchPathBuf">
	/// <para>
	/// Pointer to a variable that specifies the size, in characters, of the buffer pointed to by the lpPathBuf parameter. On input,
	/// this is the full size of the buffer, including a space for a terminating null character. If the buffer passed in is too small,
	/// the count returned does not include the terminating null character.
	/// </para>
	/// <para>If lpPathBuf is null, pcchBuf can be null.</para>
	/// </param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INDEX_ABSENT</term>
	/// <term>Component qualifier invalid or not present.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SUCCESS</term>
	/// <term>The function completed successfully.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_FILE_NOT_FOUND</term>
	/// <term>The feature is absent or broken. this error is returned for dwInstallMode = INSTALLMODE_EXISTING.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNKNOWN_COMPONENT</term>
	/// <term>The specified component is unknown.</term>
	/// </item>
	/// <item>
	/// <term>An error relating to an action</term>
	/// <term>See Error Codes.</term>
	/// </item>
	/// <item>
	/// <term>Initialization Error</term>
	/// <term>An error relating to initialization occurred.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Upon success of the <c>MsiProvideQualifiedComponentEx</c> function, the pcchPathBuf parameter contains the length of the string
	/// in lpPathBuf.
	/// </para>
	/// <para>
	/// Features with components containing a corrupted file or the wrong version of a file must be explicitly reinstalled by the user
	/// or by having the application call MsiReinstallFeature.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msiprovidequalifiedcomponentexa UINT
	// MsiProvideQualifiedComponentExA( LPCSTR szCategory, LPCSTR szQualifier, DWORD dwInstallMode, LPCSTR szProduct, DWORD dwUnused1,
	// DWORD dwUnused2, LPSTR lpPathBuf, LPDWORD pcchPathBuf );
	[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiProvideQualifiedComponentExA")]
	public static extern Win32Error MsiProvideQualifiedComponentEx([MarshalAs(UnmanagedType.LPTStr)] string szCategory,
		[MarshalAs(UnmanagedType.LPTStr)] string szQualifier, INSTALLMODE dwInstallMode,
		[Optional, MarshalAs(UnmanagedType.LPTStr)] string? szProduct, [Optional] uint dwUnused1, [Optional] uint dwUnused2,
		[Out, Optional, MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpPathBuf, ref uint pcchPathBuf);

	/// <summary>
	/// The <c>MsiProvideQualifiedComponentEx</c> function returns the full component path for a qualified component that is published
	/// by a product and performs any necessary installation. This function prompts for source if necessary and increments the usage
	/// count for the feature.
	/// </summary>
	/// <param name="szCategory">
	/// Specifies the component ID that for the requested component. This may not be the GUID for the component itself but rather a
	/// server that provides the correct functionality, as in the ComponentId column of the PublishComponent table.
	/// </param>
	/// <param name="szQualifier">Specifies a qualifier into a list of advertising components (from PublishComponent Table).</param>
	/// <param name="dwInstallMode">
	/// <para>Defines the installation mode. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>INSTALLMODE_DEFAULT</term>
	/// <term>
	/// Provide the component and perform any installation necessary to provide the component. If the key file of a component in the
	/// requested feature, or a feature parent, is missing, reinstall the feature using MsiReinstallFeature with the following flag bits
	/// set: REINSTALLMODE_FILEMISSING, REINSTALLMODE_FILEOLDERVERSION, REINSTALLMODE_FILEVERIFY, REINSTALLMODE_MACHINEDATA,
	/// REINSTALLMODE_USERDATA and REINSTALLMODE_SHORTCUT.
	/// </term>
	/// </item>
	/// <item>
	/// <term>INSTALLMODE_EXISTING</term>
	/// <term>
	/// Provide the component only if the feature exists. Otherwise return ERROR_FILE_NOT_FOUND. This mode verifies that the key file of
	/// the component exists.
	/// </term>
	/// </item>
	/// <item>
	/// <term>INSTALLMODE_NODETECTION</term>
	/// <term>
	/// Provide the component only if the feature exists. Otherwise return ERROR_FILE_NOT_FOUND. This mode only checks that the
	/// component is registered and does not verify that the key file of the component exists.
	/// </term>
	/// </item>
	/// <item>
	/// <term>INSTALLMODE_EXISTING</term>
	/// <term>Provide the component only if the feature exists, else return ERROR_FILE_NOT_FOUND.</term>
	/// </item>
	/// <item>
	/// <term>combination of the REINSTALLMODE flags</term>
	/// <term>
	/// Call MsiReinstallFeature to reinstall feature using this parameter for the dwReinstallMode parameter, and then provide the component.
	/// </term>
	/// </item>
	/// <item>
	/// <term>INSTALLMODE_NOSOURCERESOLUTION</term>
	/// <term>
	/// Provide the component only if the feature's installation state is INSTALLSTATE_LOCAL. If the feature's installation state is
	/// INSTALLSTATE_SOURCE, return ERROR_INSTALL_SOURCE_ABSENT. Otherwise return ERROR_FILE_NOT_FOUND. This mode only checks that the
	/// component is registered and does not verify that the key file exists.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="szProduct">
	/// Specifies the product to match that has published the qualified component. If this is null, then this API works the same as MsiProvideQualifiedComponent.
	/// </param>
	/// <param name="dwUnused1">Reserved. Must be zero.</param>
	/// <param name="dwUnused2">Reserved. Must be zero.</param>
	/// <param name="lpPathBuf">Pointer to a variable that receives the path to the component. This parameter can be null.</param>
	/// <param name="pcchPathBuf">
	/// <para>
	/// Pointer to a variable that specifies the size, in characters, of the buffer pointed to by the lpPathBuf parameter. On input,
	/// this is the full size of the buffer, including a space for a terminating null character. If the buffer passed in is too small,
	/// the count returned does not include the terminating null character.
	/// </para>
	/// <para>If lpPathBuf is null, pcchBuf can be null.</para>
	/// </param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INDEX_ABSENT</term>
	/// <term>Component qualifier invalid or not present.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SUCCESS</term>
	/// <term>The function completed successfully.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_FILE_NOT_FOUND</term>
	/// <term>The feature is absent or broken. this error is returned for dwInstallMode = INSTALLMODE_EXISTING.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNKNOWN_COMPONENT</term>
	/// <term>The specified component is unknown.</term>
	/// </item>
	/// <item>
	/// <term>An error relating to an action</term>
	/// <term>See Error Codes.</term>
	/// </item>
	/// <item>
	/// <term>Initialization Error</term>
	/// <term>An error relating to initialization occurred.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Upon success of the <c>MsiProvideQualifiedComponentEx</c> function, the pcchPathBuf parameter contains the length of the string
	/// in lpPathBuf.
	/// </para>
	/// <para>
	/// Features with components containing a corrupted file or the wrong version of a file must be explicitly reinstalled by the user
	/// or by having the application call MsiReinstallFeature.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msiprovidequalifiedcomponentexa UINT
	// MsiProvideQualifiedComponentExA( LPCSTR szCategory, LPCSTR szQualifier, DWORD dwInstallMode, LPCSTR szProduct, DWORD dwUnused1,
	// DWORD dwUnused2, LPSTR lpPathBuf, LPDWORD pcchPathBuf );
	[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiProvideQualifiedComponentExA")]
	public static extern Win32Error MsiProvideQualifiedComponentEx([MarshalAs(UnmanagedType.LPTStr)] string szCategory,
		[MarshalAs(UnmanagedType.LPTStr)] string szQualifier, INSTALLMODE dwInstallMode,
		[Optional, MarshalAs(UnmanagedType.LPTStr)] string? szProduct, [Optional] uint dwUnused1, [Optional] uint dwUnused2,
		[Out, Optional, MarshalAs(UnmanagedType.LPTStr)] StringBuilder lpPathBuf, [In, Optional] IntPtr pcchPathBuf);

	/// <summary>
	/// The <c>MsiQueryComponentState</c> function returns the installed state for a component. This function can query for a component
	/// of an instance of a product that is installed under user accounts other than the current user provided the product is not
	/// advertised under the per-user-unmanaged context for a user account other than the current user. The calling process must have
	/// administrative privileges to get information for a product installed for a user other than the current user.
	/// </summary>
	/// <param name="szProductCode">Specifies the ProductCode GUID for the product that contains the component.</param>
	/// <param name="szUserSid">
	/// <para>
	/// Specifies the security identifier (SID) of the account under which the instance of the product being queried exists. If
	/// dwContext is not MSIINSTALLCONTEXT_MACHINE, null specifies the current user.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Type of SID</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>NULL</term>
	/// <term>NULL denotes the currently logged on user.</term>
	/// </item>
	/// <item>
	/// <term>User SID</term>
	/// <term>Specifies enumeration for a particular user in the system. An example of user SID is "S-1-3-64-2415071341-1358098788-3127455600-2561".</term>
	/// </item>
	/// </list>
	/// <para>
	/// <c>Note</c> The special SID string "S-1-5-18" (system) cannot be used to enumerate products installed as per-machine. If
	/// dwContext is <c>MSIINSTALLCONTEXT_MACHINE</c>, szUserSid must be null.
	/// </para>
	/// </param>
	/// <param name="dwContext">
	/// <para>The installation context of the product instance being queried.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Name</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MSIINSTALLCONTEXT_USERMANAGED</term>
	/// <term>Retrieves the component's state for the per–user–managed instance of the product.</term>
	/// </item>
	/// <item>
	/// <term>MSIINSTALLCONTEXT_USERUNMANAGED</term>
	/// <term>Retrieves the component's state for the per–user–non-managed instance of the product.</term>
	/// </item>
	/// <item>
	/// <term>MSIINSTALLCONTEXT_MACHINE</term>
	/// <term>Retrieves the component's state for the per-machine instance of the product.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="szComponentCode">
	/// Specifies the component being queried. Component code GUID of the component as found in the ComponentID column of the Component table.
	/// </param>
	/// <param name="pdwState">
	/// <para>
	/// Installation state of the component for the specified product instance. This parameter can return one of the following or null values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>INSTALLSTATE_LOCAL</term>
	/// <term>The component is installed locally.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLSTATE_SOURCE</term>
	/// <term>The component is installed to run from the source.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>The <c>MsiQueryComponentState</c> function returns the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>
	/// The calling process must have administrative privileges to get information for a product installed for a user other than the
	/// current user.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_BAD_CONFIGURATION</term>
	/// <term>The configuration data is corrupt.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>An invalid parameter was passed to the function.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SUCCESS</term>
	/// <term>The function completed successfully.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNKNOWN_COMPONENT</term>
	/// <term>The component ID does not identify a known component.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNKNOWN_PRODUCT</term>
	/// <term>The product code does not identify a known product.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_FUNCTION_FAILED</term>
	/// <term>Failures that cannot be ascribed to any Windows error code.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>Buffer too small to get the user SID.</term>
	/// </item>
	/// </list>
	/// <para>For more information, see Displayed Error Messages.</para>
	/// </returns>
	/// <remarks/>
	// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msiquerycomponentstatea UINT MsiQueryComponentStateA( LPCSTR
	// szProductCode, LPCSTR szUserSid, MSIINSTALLCONTEXT dwContext, LPCSTR szComponentCode, INSTALLSTATE *pdwState );
	[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiQueryComponentStateA")]
	public static extern Win32Error MsiQueryComponentState([MarshalAs(UnmanagedType.LPTStr)] string szProductCode,
		[Optional, MarshalAs(UnmanagedType.LPTStr)] string? szUserSid, MSIINSTALLCONTEXT dwContext,
		[MarshalAs(UnmanagedType.LPTStr)] string szComponentCode, out INSTALLSTATE pdwState);

	/// <summary>The <c>MsiQueryFeatureState</c> function returns the installed state for a product feature.</summary>
	/// <param name="szProduct">Specifies the product code for the product that contains the feature of interest.</param>
	/// <param name="szFeature">Identifies the feature of interest.</param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>INSTALLSTATE_ABSENT</term>
	/// <term>The feature is not installed.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLSTATE_ADVERTISED</term>
	/// <term>The feature is advertised</term>
	/// </item>
	/// <item>
	/// <term>INSTALLSTATE_LOCAL</term>
	/// <term>The feature is installed locally.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLSTATE_SOURCE</term>
	/// <term>The feature is installed to run from source.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLSTATE_INVALIDARG</term>
	/// <term>An invalid parameter was passed to the function.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLSTATE_UNKNOWN</term>
	/// <term>The product code or feature ID is unknown.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>The <c>MsiQueryFeatureState</c> function does not validate that the feature is actually accessible.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msiqueryfeaturestatea INSTALLSTATE MsiQueryFeatureStateA( LPCSTR
	// szProduct, LPCSTR szFeature );
	[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiQueryFeatureStateA")]
	public static extern INSTALLSTATE MsiQueryFeatureState([MarshalAs(UnmanagedType.LPTStr)] string szProduct,
		[MarshalAs(UnmanagedType.LPTStr)] string szFeature);

	/// <summary>
	/// The <c>MsiQueryFeatureStateEx</c> function returns the installed state for a product feature. This function can be used to query
	/// any feature of an instance of a product installed under the machine account or any context under the current user account or the
	/// per-user-managed context under any user account other than the current user. A user must have administrative privileges to get
	/// information for a product installed for a user other than the current user.
	/// </summary>
	/// <param name="szProductCode">ProductCode GUID of the product that contains the feature of interest.</param>
	/// <param name="szUserSid">
	/// <para>
	/// Specifies the security identifier (SID) of the account, under which, the instance of the product being queried exists. If
	/// dwContext is not <c>MSIINSTALLCONTEXT_MACHINE</c>, a null value specifies the current user.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Type of SID</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>NULL</term>
	/// <term>NULL denotes the currently logged on user.</term>
	/// </item>
	/// <item>
	/// <term>User SID</term>
	/// <term>Specifies enumeration for a particular user in the system. An example of user SID is "S-1-3-64-2415071341-1358098788-3127455600-2561".</term>
	/// </item>
	/// </list>
	/// <para>
	/// <c>Note</c> The special SID string s-1-5-18 (system) cannot be used to enumerate features of products installed as per-machine.
	/// If dwContext is <c>MSIINSTALLCONTEXT_MACHINE</c>, szUserSid must be null.
	/// </para>
	/// </param>
	/// <param name="dwContext">
	/// <para>The installation context of the product instance being queried.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Name</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MSIINSTALLCONTEXT_USERMANAGED</term>
	/// <term>Retrieves the feature state for the per-user-managed instance of the product.</term>
	/// </item>
	/// <item>
	/// <term>MSIINSTALLCONTEXT_USERUNMANAGED</term>
	/// <term>Retrieves the feature state for the per-user-unmanaged instance of the product.</term>
	/// </item>
	/// <item>
	/// <term>MSIINSTALLCONTEXT_MACHINE</term>
	/// <term>Retrieves the feature state for the per-machine instance of the product.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="szFeature">
	/// Specifies the feature being queried. Identifier of the feature as found in the <c>Feature</c> column of the Feature table.
	/// </param>
	/// <param name="pdwState">
	/// <para>
	/// Installation state of the feature for the specified product instance. This parameter can return one of the following or null.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>INSTALLSTATE_ADVERTISED</term>
	/// <term>This feature is advertised.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLSTATE_LOCAL</term>
	/// <term>The feature is installed locally.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLSTATE_SOURCE</term>
	/// <term>The feature is installed to run from source.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>The <c>MsiQueryFeatureStateEx</c> function returns the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>
	/// A user must have administrative privileges to get information for a product installed for a user other than the current user.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_BAD_CONFIGURATION</term>
	/// <term>The configuration data is corrupt.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>An invalid parameter was passed to the function.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SUCCESS</term>
	/// <term>The function completed successfully.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNKNOWN_FEATURE</term>
	/// <term>The feature ID does not identify a known feature.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNKNOWN_PRODUCT</term>
	/// <term>The product code does not identify a known product.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_FUNCTION_FAILED</term>
	/// <term>An unexpected internal failure.</term>
	/// </item>
	/// </list>
	/// <para>For more information, see Displayed Error Messages.</para>
	/// </returns>
	/// <remarks>
	/// The <c>MsiQueryFeatureStateEx</c> function does not validate that the feature is actually accessible. The
	/// <c>MsiQueryFeatureStateEx</c> function does not validate the feature ID. <c>ERROR_UNKNOWN_FEATURE</c> is returned for any
	/// unknown feature ID. When the query is made on a product installed under the per-user-unmanaged context for a user account other
	/// than the current user, the function fails. In this case the function returns <c>ERROR_UNKNOWN_FEATURE</c>, or if the product is
	/// advertised only (not installed), <c>ERROR_UNKNOWN_PRODUCT</c> is returned.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msiqueryfeaturestateexa UINT MsiQueryFeatureStateExA( LPCSTR
	// szProductCode, LPCSTR szUserSid, MSIINSTALLCONTEXT dwContext, LPCSTR szFeature, INSTALLSTATE *pdwState );
	[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiQueryFeatureStateExA")]
	public static extern Win32Error MsiQueryFeatureStateEx([MarshalAs(UnmanagedType.LPTStr)] string szProductCode,
		[Optional, MarshalAs(UnmanagedType.LPTStr)] string? szUserSid, MSIINSTALLCONTEXT dwContext,
		[MarshalAs(UnmanagedType.LPTStr)] string szFeature, out INSTALLSTATE pdwState);

	/// <summary>The <c>MsiQueryProductState</c> function returns the installed state for a product.</summary>
	/// <param name="szProduct">Specifies the product code that identifies the product to be queried.</param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>INSTALLSTATE_ABSENT</term>
	/// <term>The product is installed for a different user.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLSTATE_ADVERTISED</term>
	/// <term>The product is advertised but not installed.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLSTATE_DEFAULT</term>
	/// <term>The product is installed for the current user.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLSTATE_INVALIDARG</term>
	/// <term>An invalid parameter was passed to the function.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLSTATE_UNKNOWN</term>
	/// <term>The product is neither advertised or installed.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks/>
	// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msiqueryproductstatea INSTALLSTATE MsiQueryProductStateA( LPCSTR
	// szProduct );
	[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiQueryProductStateA")]
	public static extern INSTALLSTATE MsiQueryProductState([MarshalAs(UnmanagedType.LPTStr)] string szProduct);

	/// <summary>The <c>MsiReinstallFeature</c> function reinstalls features.</summary>
	/// <param name="szProduct">Specifies the product code for the product that contains the feature to be reinstalled.</param>
	/// <param name="szFeature">
	/// Specifies the feature to be reinstalled. The parent feature or child feature of the specified feature is not reinstalled. To
	/// reinstall the parent or child feature, you must call the <c>MsiReinstallFeature</c> function for each separately or use the
	/// MsiReinstallProduct function.
	/// </param>
	/// <param name="dwReinstallMode">
	/// <para>Specifies what to install. This parameter can be one or more of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>REINSTALLMODE_FILEMISSING</term>
	/// <term>Reinstall only if the file is missing.</term>
	/// </item>
	/// <item>
	/// <term>REINSTALLMODE_FILEOLDERVERSION</term>
	/// <term>Reinstall if the file is missing or is an older version.</term>
	/// </item>
	/// <item>
	/// <term>REINSTALLMODE_FILEEQUALVERSION</term>
	/// <term>Reinstall if the file is missing, or is an equal or older version.</term>
	/// </item>
	/// <item>
	/// <term>REINSTALLMODE_FILEEXACT</term>
	/// <term>Reinstall if the file is missing or is a different version.</term>
	/// </item>
	/// <item>
	/// <term>REINSTALLMODE_FILEVERIFY</term>
	/// <term>
	/// Verify the checksum values, and reinstall the file if they are missing or corrupt. This flag only repairs files that have
	/// msidbFileAttributesChecksum in the Attributes column of the File table.
	/// </term>
	/// </item>
	/// <item>
	/// <term>REINSTALLMODE_FILEREPLACE</term>
	/// <term>Force all files to be reinstalled, regardless of checksum or version.</term>
	/// </item>
	/// <item>
	/// <term>REINSTALLMODE_USERDATA</term>
	/// <term>Rewrite all required registry entries from the Registry Table that go to theHKEY_CURRENT_USER or HKEY_USERS registry hive.</term>
	/// </item>
	/// <item>
	/// <term>REINSTALLMODE_MACHINEDATA</term>
	/// <term>
	/// Rewrite all required registry entries from the Registry Table that go to the HKEY_LOCAL_MACHINEor HKEY_CLASSES_ROOT registry
	/// hive. Rewrite all information from the Class Table, Verb Table, PublishComponent Table, ProgID Table, MIME Table, Icon Table,
	/// Extension Table, and AppID Table regardless of machine or user assignment. Reinstall all qualified components. When reinstalling
	/// an application, this option runs the RegisterTypeLibraries and InstallODBC actions.
	/// </term>
	/// </item>
	/// <item>
	/// <term>REINSTALLMODE_SHORTCUT</term>
	/// <term>Reinstall all shortcuts and re-cache all icons overwriting any existing shortcuts and icons.</term>
	/// </item>
	/// <item>
	/// <term>REINSTALLMODE_PACKAGE</term>
	/// <term>
	/// Use to run from the source package and re-cache the local package. Do not use for the first installation of an application or feature.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INSTALL_FAILURE</term>
	/// <term>The installation failed.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>An invalid parameter was passed to the function.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSTALL_SERVICE_FAILURE</term>
	/// <term>The installation service could not be accessed.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSTALL_SUSPEND</term>
	/// <term>The installation was suspended and is incomplete.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSTALL_USEREXIT</term>
	/// <term>The user canceled the installation.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SUCCESS</term>
	/// <term>The function completed successfully.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNKNOWN_FEATURE</term>
	/// <term>The feature ID does not identify a known feature.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNKNOWN_PRODUCT</term>
	/// <term>The product code does not identify a known product.</term>
	/// </item>
	/// </list>
	/// <para>For more information, see Displayed Error Messages.</para>
	/// </returns>
	/// <remarks/>
	// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msireinstallfeaturea UINT MsiReinstallFeatureA( LPCSTR szProduct,
	// LPCSTR szFeature, DWORD dwReinstallMode );
	[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiReinstallFeatureA")]
	public static extern Win32Error MsiReinstallFeature([MarshalAs(UnmanagedType.LPTStr)] string szProduct,
		[MarshalAs(UnmanagedType.LPTStr)] string szFeature, REINSTALLMODE dwReinstallMode);

	/// <summary>The <c>MsiReinstallProduct</c> function reinstalls products.</summary>
	/// <param name="szProduct">Specifies the product code for the product to be reinstalled.</param>
	/// <param name="szReinstallMode">
	/// <para>Specifies the reinstall mode. This parameter can be one or more of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>REINSTALLMODE_FILEMISSING</term>
	/// <term>Reinstall only if the file is missing.</term>
	/// </item>
	/// <item>
	/// <term>REINSTALLMODE_FILEOLDERVERSION</term>
	/// <term>Reinstall if the file is missing or is an older version.</term>
	/// </item>
	/// <item>
	/// <term>REINSTALLMODE_FILEEQUALVERSION</term>
	/// <term>Reinstall if the file is missing, or is an equal or older version.</term>
	/// </item>
	/// <item>
	/// <term>REINSTALLMODE_FILEEXACT</term>
	/// <term>Reinstall if the file is missing or is a different version.</term>
	/// </item>
	/// <item>
	/// <term>REINSTALLMODE_FILEVERIFY</term>
	/// <term>
	/// Verify the checksum values and reinstall the file if they are missing or corrupt. This flag only repairs files that have
	/// msidbFileAttributesChecksum in the Attributes column of the File table.
	/// </term>
	/// </item>
	/// <item>
	/// <term>REINSTALLMODE_FILEREPLACE</term>
	/// <term>Force all files to be reinstalled, regardless of checksum or version.</term>
	/// </item>
	/// <item>
	/// <term>REINSTALLMODE_USERDATA</term>
	/// <term>Rewrite all required registry entries from the Registry Table that go to theHKEY_CURRENT_USER or HKEY_USERS registry hive.</term>
	/// </item>
	/// <item>
	/// <term>REINSTALLMODE_MACHINEDATA</term>
	/// <term>
	/// Rewrite all required registry entries from the Registry Table that go to the HKEY_LOCAL_MACHINEor HKEY_CLASSES_ROOT registry
	/// hive. Rewrite all information from the Class Table, Verb Table, PublishComponent Table, ProgID Table, MIMET Table, Icon Table,
	/// Extension Table, and AppID Table regardless of machine or user assignment. Reinstall all qualified components. When reinstalling
	/// an application, this option runs the RegisterTypeLibraries and InstallODBC actions.
	/// </term>
	/// </item>
	/// <item>
	/// <term>REINSTALLMODE_SHORTCUT</term>
	/// <term>Reinstall all shortcuts and re-cache all icons overwriting any existing shortcuts and icons.</term>
	/// </item>
	/// <item>
	/// <term>REINSTALLMODE_PACKAGE</term>
	/// <term>
	/// Use to run from the source package and re-cache the local package. Do not use for the first installation of an application or feature.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INSTALL_FAILURE</term>
	/// <term>The installation failed.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>An invalid parameter was passed to the function.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSTALL_SERVICE_FAILURE</term>
	/// <term>The installation service could not be accessed.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSTALL_SUSPEND</term>
	/// <term>The installation was suspended and is incomplete.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSTALL_USEREXIT</term>
	/// <term>The user canceled the installation.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SUCCESS</term>
	/// <term>The function completed successfully.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNKNOWN_PRODUCT</term>
	/// <term>The product code does not identify a known product.</term>
	/// </item>
	/// </list>
	/// <para>For more information, see Displayed Error Messages.</para>
	/// </returns>
	/// <remarks/>
	// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msireinstallproducta UINT MsiReinstallProductA( LPCSTR szProduct,
	// DWORD szReinstallMode );
	[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiReinstallProductA")]
	public static extern Win32Error MsiReinstallProduct([MarshalAs(UnmanagedType.LPTStr)] string szProduct, REINSTALLMODE szReinstallMode);

	/// <summary>
	/// The <c>MsiRemovePatches</c> function removes one or more patches from a single product. To remove a patch from multiple
	/// products, <c>MsiRemovePatches</c> must be called for each product.
	/// </summary>
	/// <param name="szPatchList">
	/// A null-terminated string that represents the list of patches to remove. Each patch can be specified by the GUID of the patch or
	/// the full path to the patch package. The patches in the list are delimited by semicolons.
	/// </param>
	/// <param name="szProductCode">
	/// A null-terminated string that is the ProductCode (GUID) of the product from which the patches are removed. This parameter cannot
	/// be <c>NULL</c>.
	/// </param>
	/// <param name="eUninstallType">
	/// <para>Value that indicates the type of patch removal to perform. This parameter must be <c>INSTALLTYPE_SINGLE_INSTANCE</c>.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>INSTALLTYPE_SINGLE_INSTANCE</term>
	/// <term>The patch is uninstalled for only the product specified by szProduct.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="szPropertyList">
	/// A null-terminated string that specifies command-line property settings. For more information see About Properties and Setting
	/// Public Property Values on the Command Line. This parameter can be <c>NULL</c>.
	/// </param>
	/// <returns>
	/// <para>The <c>MsiRemovePatches</c> function returns the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>An invalid parameter was included.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_PATCH_PACKAGE_OPEN_FAILED</term>
	/// <term>The patch package could not be opened.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SUCCESS</term>
	/// <term>The patch was successfully removed.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNKNOWN_PRODUCT</term>
	/// <term>The product specified by szProductList is not installed either per-machine or per-user for the caller of MsiRemovePatches.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_PATCH_PACKAGE_OPEN_FAILED</term>
	/// <term>The patch package could not be opened.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_PATCH_PACKAGE_INVALID</term>
	/// <term>The patch package is invalid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_PATCH_PACKAGE_UNSUPPORTED</term>
	/// <term>The patch package cannot be processed by this version of the Windows Installer service.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_PATCH_REMOVAL_UNSUPPORTED</term>
	/// <term>The patch package is not removable.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNKNOWN_PATCH</term>
	/// <term>The patch has not been applied to this product.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_PATCH_REMOVAL_DISALLOWED</term>
	/// <term>Patch removal was disallowed by policy.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// See Uninstalling Patches for an example that demonstrates how an application can remove a patch from all products that are
	/// available to the user.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msiremovepatchesa UINT MsiRemovePatchesA( LPCSTR szPatchList,
	// LPCSTR szProductCode, INSTALLTYPE eUninstallType, LPCSTR szPropertyList );
	[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiRemovePatchesA")]
	public static extern Win32Error MsiRemovePatches([MarshalAs(UnmanagedType.LPTStr)] string szPatchList,
		[MarshalAs(UnmanagedType.LPTStr)] string szProductCode, INSTALLTYPE eUninstallType,
		[Optional, MarshalAs(UnmanagedType.LPTStr)] string? szPropertyList);

	/// <summary>
	/// The <c>MsiSetExternalUI</c> function enables an external user-interface handler. This external UI handler is called before the
	/// normal internal user-interface handler. The external UI handler has the option to suppress the internal UI by returning a
	/// non-zero value to indicate that it has handled the messages. For more information, see About the User Interface.
	/// </summary>
	/// <param name="puiHandler">Specifies a callback function that conforms to the INSTALLUI_HANDLER specification.</param>
	/// <param name="dwMessageFilter">
	/// <para>
	/// Specifies which messages to handle using the external message handler. If the external handler returns a non-zero result, then
	/// that message will not be sent to the UI, instead the message will be logged if logging has been enabled. For more information,
	/// see the MsiEnableLog function.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>INSTALLLOGMODE_FILESINUSE</term>
	/// <term>Files in use information. When this message is received, a FilesInUse Dialog should be displayed.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLLOGMODE_FATALEXIT</term>
	/// <term>Premature termination of installation.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLLOGMODE_ERROR</term>
	/// <term>The error messages are logged.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLLOGMODE_WARNING</term>
	/// <term>The warning messages are logged.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLLOGMODE_USER</term>
	/// <term>The user requests are logged.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLLOGMODE_INFO</term>
	/// <term>The status messages that are not displayed are logged.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLLOGMODE_RESOLVESOURCE</term>
	/// <term>Request to determine a valid source location.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLLOGMODE_RMFILESINUSE</term>
	/// <term>Files in use information. When this message is received, a MsiRMFilesInUse Dialog should be displayed.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLLOGMODE_OUTOFDISKSPACE</term>
	/// <term>There was insufficient disk space.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLLOGMODE_ACTIONSTART</term>
	/// <term>The start of new installation actions are logged.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLLOGMODE_ACTIONDATA</term>
	/// <term>The data record with the installation action is logged.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLLOGMODE_COMMONDATA</term>
	/// <term>The parameters for user-interface initialization are logged.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLLOGMODE_PROGRESS</term>
	/// <term>
	/// Progress bar information. This message includes information on units so far and total number of units. For an explanation of the
	/// message format, see the MsiProcessMessage function. This message is only sent to an external user interface and is not logged.
	/// </term>
	/// </item>
	/// <item>
	/// <term>INSTALLLOGMODE_INITIALIZE</term>
	/// <term>
	/// If this is not a quiet installation, then the basic UI has been initialized. If this is a full UI installation, the full UI is
	/// not yet initialized. This message is only sent to an external user interface and is not logged.
	/// </term>
	/// </item>
	/// <item>
	/// <term>INSTALLLOGMODE_TERMINATE</term>
	/// <term>
	/// If a full UI is being used, the full UI has ended. If this is not a quiet installation, the basic UI has not yet ended. This
	/// message is only sent to an external user interface and is not logged.
	/// </term>
	/// </item>
	/// <item>
	/// <term>INSTALLLOGMODE_SHOWDIALOG</term>
	/// <term>Sent prior to display of the full UI dialog. This message is only sent to an external user interface and is not logged.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLLOGMODE_INSTALLSTART</term>
	/// <term>Installation of product begins. The message contains the product's ProductName and ProductCode.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLLOGMODE_INSTALLEND</term>
	/// <term>Installation of product ends. The message contains the product's ProductName, ProductCode, and return value.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pvContext">
	/// Pointer to an application context that is passed to the callback function. This parameter can be used for error checking.
	/// </param>
	/// <returns>The return value is the previously set external handler, or zero (0) if there was no previously set handler.</returns>
	/// <remarks>
	/// <para>
	/// To restore the previous UI handler, second call is made to <c>MsiSetExternalUI</c> using the INSTALLUI_HANDLER returned by the
	/// first call to <c>MsiSetExternalUI</c> and specifying zero (0) for dwMessageFilter.
	/// </para>
	/// <para>
	/// The external user interface handler pointed to by the puiHandler parameter does not have full control over the external user
	/// interface unless MsiSetInternalUI is called with the dwUILevel parameter set to INSTALLUILEVEL_NONE. If <c>MsiSetInternalUI</c>
	/// is not called, the internal user interface level defaults to INSTALLUILEVEL_BASIC. As a result, any message not handled by the
	/// external user interface handler is handled by Windows Installer. The initial "Preparing to install. . ." dialog always appears
	/// even if the external user interface handler handles all messages.
	/// </para>
	/// <para>
	/// <c>MsiSetExternalUI</c> should only be called from a Bootstrapping application. You cannot call <c>MsiSetExternalUI</c> from a
	/// custom action.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msisetexternaluia INSTALLUI_HANDLERA MsiSetExternalUIA(
	// INSTALLUI_HANDLERA puiHandler, DWORD dwMessageFilter, LPVOID pvContext );
	[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiSetExternalUIA")]
	public static extern INSTALLUI_HANDLER MsiSetExternalUI([Optional] INSTALLUI_HANDLER puiHandler, INSTALLLOGMODE dwMessageFilter,
		[In, Optional] IntPtr pvContext);

	/// <summary>The <c>MsiSetExternalUIRecord</c> function enables an external user-interface (UI) handler.</summary>
	/// <param name="puiHandler">
	/// <para>Specifies a callback function that conforms to the INSTALLUI_HANDLER_RECORD specification.</para>
	/// <para>To disable the current external UI handler, call the function with this parameter set to a <c>NULL</c> value.</para>
	/// </param>
	/// <param name="dwMessageFilter">
	/// <para>
	/// Specifies which messages to handle using the external message handler. If the external handler returns a non-zero result, then
	/// that message is not sent to the UI, instead the message is logged if logging is enabled. For more information, see MsiEnableLog.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>INSTALLLOGMODE_FILESINUSE</term>
	/// <term>Files in use information. When this message is received, a FilesInUse Dialog should be displayed.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLLOGMODE_FATALEXIT</term>
	/// <term>Premature termination of installation.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLLOGMODE_ERROR</term>
	/// <term>The error messages are logged.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLLOGMODE_WARNING</term>
	/// <term>The warning messages are logged.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLLOGMODE_USER</term>
	/// <term>The user requests are logged.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLLOGMODE_INFO</term>
	/// <term>The status messages that are not displayed are logged.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLLOGMODE_RESOLVESOURCE</term>
	/// <term>Request to determine a valid source location.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLLOGMODE_RMFILESINUSE</term>
	/// <term>Files in use information. When this message is received, a MsiRMFilesInUse Dialog should be displayed.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLLOGMODE_OUTOFDISKSPACE</term>
	/// <term>The is insufficient disk space.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLLOGMODE_ACTIONSTART</term>
	/// <term>The start of new installation actions are logged.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLLOGMODE_ACTIONDATA</term>
	/// <term>The data record with the installation action is logged.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLLOGMODE_COMMONDATA</term>
	/// <term>The parameters for user-interface initialization are logged.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLLOGMODE_PROGRESS</term>
	/// <term>
	/// The Progress bar information. This message includes information about units so far and total number of units. This message is
	/// only sent to an external user interface and is not logged. For more information, see MsiProcessMessage.
	/// </term>
	/// </item>
	/// <item>
	/// <term>INSTALLLOGMODE_INITIALIZE</term>
	/// <term>
	/// If this is not a quiet installation, then the basic UI is initialized. If this is a full UI installation, the Full UI is not yet
	/// initialized. This message is only sent to an external user interface and is not logged.
	/// </term>
	/// </item>
	/// <item>
	/// <term>INSTALLLOGMODE_TERMINATE</term>
	/// <term>
	/// If a full UI is being used, the full UI has ended. If this is not a quiet installation, the basic UI has not ended. This message
	/// is only sent to an external user interface and is not logged.
	/// </term>
	/// </item>
	/// <item>
	/// <term>INSTALLLOGMODE_SHOWDIALOG</term>
	/// <term>Sent prior to display of the Full UI dialog. This message is only sent to an external user interface and is not logged.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLLOGMODE_INSTALLSTART</term>
	/// <term>Installation of product begins. The message contains the product's ProductName and ProductCode.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLLOGMODE_INSTALLEND</term>
	/// <term>Installation of product ends. The message contains the product's ProductName, ProductCode, and return value.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pvContext">
	/// <para>A pointer to an application context that is passed to the callback function.</para>
	/// <para>This parameter can be used for error checking.</para>
	/// </param>
	/// <param name="ppuiPrevHandler">
	/// Returns the pointer to the previously set callback function that conforms to the INSTALLUI_HANDLER_RECORD specification, or
	/// <c>NULL</c> if no callback is previously set.
	/// </param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_SUCCESS</term>
	/// <term>The function completes successfully.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_CALL_NOT_IMPLEMENTED</term>
	/// <term>
	/// This value indicates that an attempt is made to call this function from a custom action. This function cannot be called from a
	/// custom action.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>This function cannot be called from Custom Actions.</para>
	/// <para>
	/// The external UI handler enabled by calling <c>MsiSetExternalUIRecord</c> receives messages in the format of a Record Object. The
	/// external UI handler enabled by calling MsiSetExternalUI receives messages in the format of a string. An external UI is always
	/// called before the Windows Installer internal UI. An enabled record-based external UI is called before any string-based external
	/// UI. If the record-based external UI handler returns 0 (zero), the message is sent to any enabled string-based external UI
	/// handler. If the external UI handler returns a non-zero value, the internal Windows Installer UI handler is suppressed and the
	/// messages are considered handled.
	/// </para>
	/// <para>
	/// This function stores the external user interfaces it has set. To replace the current external UI handler with a previous
	/// handler, call the function and specify the INSTALLUI_HANDLER_RECORD as the puiHandler parameter and 0 (zero) as the
	/// dwMessageFilter parameter.
	/// </para>
	/// <para>
	/// The external user interface handler pointed to by the puiHandler parameter does not have full control over the external user
	/// interface unless MsiSetInternalUI is called with the dwUILevel parameter set to INSTALLUILEVEL_NONE. If <c>MsiSetInternalUI</c>
	/// is not called, the internal user interface level defaults to INSTALLUILEVEL_BASIC. As a result, any message not handled by the
	/// external user interface handler is handled by Windows Installer. The initial "Preparing to install. . ." dialog always appears
	/// even if the external user interface handler handles all messages. MsiSetExternalUI should only be called from an Bootstrapping
	/// application. You cannot call <c>MsiSetExternalUI</c> from a custom action.
	/// </para>
	/// <para>To disable this external UI handler, call <c>MsiSetExternalUIRecord</c> with a <c>NULL</c> value for the puiHandler parameter.</para>
	/// <para>
	/// <c>Windows Installer 2.0 and Windows Installer 3.0:</c> Not supported. The <c>MsiSetExternalUIRecord</c> function is available
	/// beginning with Windows Installer 3.1.
	/// </para>
	/// <para>For more information about using a record-based external handler, see Monitoring an Installation Using MsiSetExternalUIRecord.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msisetexternaluirecord UINT MsiSetExternalUIRecord(
	// INSTALLUI_HANDLER_RECORD puiHandler, DWORD dwMessageFilter, LPVOID pvContext, PINSTALLUI_HANDLER_RECORD ppuiPrevHandler );
	[DllImport(Lib_Msi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiSetExternalUIRecord")]
	public static extern Win32Error MsiSetExternalUIRecord([Optional] INSTALLUI_HANDLER_RECORD puiHandler, INSTALLLOGMODE dwMessageFilter,
		[In, Optional] IntPtr pvContext, out INSTALLUI_HANDLER_RECORD ppuiPrevHandler);

	/// <summary>
	/// The <c>MsiSetInternalUI</c> function enables the installer's internal user interface. Then this user interface is used for all
	/// subsequent calls to user-interface-generating installer functions in this process. For more information, see User Interface Levels.
	/// </summary>
	/// <param name="dwUILevel">
	/// <para>Specifies the level of complexity of the user interface. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>INSTALLUILEVEL_FULL</term>
	/// <term>Authored user interface with wizards, progress, and errors.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLUILEVEL_REDUCED</term>
	/// <term>Authored user interface with wizard dialog boxes suppressed.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLUILEVEL_BASIC</term>
	/// <term>Simple progress and error handling.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLUILEVEL_DEFAULT</term>
	/// <term>The installer chooses an appropriate user interface level.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLUILEVEL_NONE</term>
	/// <term>Completely silent installation.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLUILEVEL_ENDDIALOG</term>
	/// <term>
	/// If combined with any above value, the installer displays a modal dialog box at the end of a successful installation or if there
	/// has been an error. No dialog box is displayed if the user cancels.
	/// </term>
	/// </item>
	/// <item>
	/// <term>INSTALLUILEVEL_PROGRESSONLY</term>
	/// <term>
	/// If combined with the INSTALLUILEVEL_BASIC value, the installer shows simple progress dialog boxes but does not display any modal
	/// dialog boxes or error dialog boxes.
	/// </term>
	/// </item>
	/// <item>
	/// <term>INSTALLUILEVEL_NOCHANGE</term>
	/// <term>No change in the UI level. However, if phWnd is not Null, the parent window can change.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLUILEVEL_HIDECANCEL</term>
	/// <term>
	/// If combined with the INSTALLUILEVEL_BASIC value, the installer shows simple progress dialog boxes but does not display a Cancel
	/// button on the dialog. This prevents users from canceling the install.
	/// </term>
	/// </item>
	/// <item>
	/// <term>INSTALLUILEVEL_SOURCERESONLY</term>
	/// <term>
	/// If this value is combined with the INSTALLUILEVEL_NONE value, the installer displays only the dialog boxes used for source
	/// resolution. No other dialog boxes are shown. This value has no effect if the UI level is not INSTALLUILEVEL_NONE. It is used
	/// with an external user interface designed to handle all of the UI except for source resolution. In this case, the installer
	/// handles source resolution.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="phWnd">
	/// Pointer to a window. This window becomes the owner of any user interface created. A pointer to the previous owner of the user
	/// interface is returned. If this parameter is null, the owner of the user interface does not change.
	/// </param>
	/// <returns>
	/// The previous user interface level is returned. If an invalid dwUILevel is passed, then <c>INSTALLUILEVEL_NOCHANGE</c> is returned.
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>MsiSetInternalUI</c> function is useful when the installer must display a user interface. For example, if a feature is
	/// installed, but the source is a compact disc that must be inserted, the installer prompts the user for the compact disc.
	/// Depending on the nature of the installation, the application might also display progress indicators or query the user for information.
	/// </para>
	/// <para>
	/// When Msi.dll is loaded, the user interface level is set to DEFAULT and the user interface owner is set to 0 (that is, the
	/// initial user interface owner is the desktop).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msisetinternalui INSTALLUILEVEL MsiSetInternalUI( INSTALLUILEVEL
	// dwUILevel, HWND *phWnd );
	[DllImport(Lib_Msi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiSetInternalUI")]
	public static extern INSTALLUILEVEL MsiSetInternalUI(INSTALLUILEVEL dwUILevel, ref HWND phWnd);

	/// <summary>
	/// The <c>MsiSetInternalUI</c> function enables the installer's internal user interface. Then this user interface is used for all
	/// subsequent calls to user-interface-generating installer functions in this process. For more information, see User Interface Levels.
	/// </summary>
	/// <param name="dwUILevel">
	/// <para>Specifies the level of complexity of the user interface. This parameter can be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>INSTALLUILEVEL_FULL</term>
	/// <term>Authored user interface with wizards, progress, and errors.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLUILEVEL_REDUCED</term>
	/// <term>Authored user interface with wizard dialog boxes suppressed.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLUILEVEL_BASIC</term>
	/// <term>Simple progress and error handling.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLUILEVEL_DEFAULT</term>
	/// <term>The installer chooses an appropriate user interface level.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLUILEVEL_NONE</term>
	/// <term>Completely silent installation.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLUILEVEL_ENDDIALOG</term>
	/// <term>
	/// If combined with any above value, the installer displays a modal dialog box at the end of a successful installation or if there
	/// has been an error. No dialog box is displayed if the user cancels.
	/// </term>
	/// </item>
	/// <item>
	/// <term>INSTALLUILEVEL_PROGRESSONLY</term>
	/// <term>
	/// If combined with the INSTALLUILEVEL_BASIC value, the installer shows simple progress dialog boxes but does not display any modal
	/// dialog boxes or error dialog boxes.
	/// </term>
	/// </item>
	/// <item>
	/// <term>INSTALLUILEVEL_NOCHANGE</term>
	/// <term>No change in the UI level. However, if phWnd is not Null, the parent window can change.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLUILEVEL_HIDECANCEL</term>
	/// <term>
	/// If combined with the INSTALLUILEVEL_BASIC value, the installer shows simple progress dialog boxes but does not display a Cancel
	/// button on the dialog. This prevents users from canceling the install.
	/// </term>
	/// </item>
	/// <item>
	/// <term>INSTALLUILEVEL_SOURCERESONLY</term>
	/// <term>
	/// If this value is combined with the INSTALLUILEVEL_NONE value, the installer displays only the dialog boxes used for source
	/// resolution. No other dialog boxes are shown. This value has no effect if the UI level is not INSTALLUILEVEL_NONE. It is used
	/// with an external user interface designed to handle all of the UI except for source resolution. In this case, the installer
	/// handles source resolution.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="phWnd">
	/// Pointer to a window. This window becomes the owner of any user interface created. A pointer to the previous owner of the user
	/// interface is returned. If this parameter is null, the owner of the user interface does not change.
	/// </param>
	/// <returns>
	/// The previous user interface level is returned. If an invalid dwUILevel is passed, then <c>INSTALLUILEVEL_NOCHANGE</c> is returned.
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>MsiSetInternalUI</c> function is useful when the installer must display a user interface. For example, if a feature is
	/// installed, but the source is a compact disc that must be inserted, the installer prompts the user for the compact disc.
	/// Depending on the nature of the installation, the application might also display progress indicators or query the user for information.
	/// </para>
	/// <para>
	/// When Msi.dll is loaded, the user interface level is set to DEFAULT and the user interface owner is set to 0 (that is, the
	/// initial user interface owner is the desktop).
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msisetinternalui INSTALLUILEVEL MsiSetInternalUI( INSTALLUILEVEL
	// dwUILevel, HWND *phWnd );
	[DllImport(Lib_Msi, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiSetInternalUI")]
	public static extern INSTALLUILEVEL MsiSetInternalUI(INSTALLUILEVEL dwUILevel, [In, Optional] IntPtr phWnd);

	/// <summary>
	/// The <c>MsiSourceListAddMediaDisk</c> function adds or updates a disk of the media source of a registered product or patch. If
	/// the disk specified already exists, it is updated with the new values. If the disk specified does not exist, a new disk entry is
	/// created with the new values.
	/// </summary>
	/// <param name="szProductCodeOrPatchCode">
	/// The ProductCode or patch GUID of the product or patch. Use a null-terminated string. If the string is longer than 39 characters,
	/// the function fails and returns ERROR_INVALID_PARAMETER. This parameter cannot be <c>NULL</c>.
	/// </param>
	/// <param name="szUserSid">
	/// <para>
	/// This parameter can be a string SID that specifies the user account that contains the product or patch. The SID is not validated
	/// or resolved. An incorrect SID can return ERROR_UNKNOWN_PRODUCT or ERROR_UNKNOWN_PATCH.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Type of SID</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>NULL</term>
	/// <term>
	/// NULL denotes the currently logged on user. When referencing the current user account, szUserSID can be NULL and dwContext can be
	/// MSIINSTALLCONTEXT_USERMANAGED or MSIINSTALLCONTEXT_USERUNMANAGED.
	/// </term>
	/// </item>
	/// <item>
	/// <term>User SID</term>
	/// <term>Specifies enumeration for a particular user in the system. An example of user SID is "S-1-3-64-2415071341-1358098788-3127455600-2561".</term>
	/// </item>
	/// </list>
	/// <para>
	/// <c>Note</c> The special SID string s-1-5-18 (system) cannot be used to enumerate products or patches installed as per-machine.
	/// Setting the SID value to s-1-5-18 returns ERROR_INVALID_PARAMETER. When dwContext is set to MSIINSTALLCONTEXT_MACHINE only,
	/// szUserSid must be <c>NULL</c>.
	/// </para>
	/// <para>
	/// <c>Note</c> The special SID string s-1-1-0 (everyone) should not be used. Setting the SID value to s-1-1-0 fails and returns
	/// ERROR_INVALID_PARAM .
	/// </para>
	/// </param>
	/// <param name="dwContext">
	/// <para>
	/// This parameter specifies the context of the product or patch instance. This parameter can contain one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Type of context</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MSIINSTALLCONTEXT_USERMANAGED</term>
	/// <term>The product or patch instance exists in the per-user-managed context.</term>
	/// </item>
	/// <item>
	/// <term>MSIINSTALLCONTEXT_USERUNMANAGED</term>
	/// <term>The product or patch instance exists in the per-user-unmanaged context.</term>
	/// </item>
	/// <item>
	/// <term>MSIINSTALLCONTEXT_MACHINE</term>
	/// <term>The product or patch instance exists in the per-machine context.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwOptions">
	/// <para>The dwOptions value specifies the meaning of szProductCodeOrPatchCode.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Flag</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MSICODE_PRODUCT</term>
	/// <term>szProductCodeOrPatchCode is a product code GUID.</term>
	/// </item>
	/// <item>
	/// <term>MSICODE_PATCH</term>
	/// <term>szProductCodeOrPatchCode is a patch code GUID.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwDiskId">This parameter provides the ID of the disk being added or updated.</param>
	/// <param name="szVolumeLabel">
	/// The szVolumeLabel provides the label of the disk being added or updated. An update overwrites the existing volume label in the
	/// registry. To change the disk prompt only, get the existing volume label from the registry and provide it in this call along with
	/// the new disk prompt. Passing a <c>NULL</c> or empty string for szVolumeLabel registers an empty string (0 bytes in length) as
	/// the volume label.
	/// </param>
	/// <param name="szDiskPrompt">
	/// On entry to <c>MsiSourceListAddMediaDisk</c>, szDiskPrompt provides the disk prompt of the disk being added or updated. An
	/// update overwrites the registered disk prompt. To change the volume label only, get the existing disk prompt that is registered
	/// and provide it when calling <c>MsiSourceListAddMediaDisk</c> along with the new volume label. Passing <c>NULL</c> or an empty
	/// string registers an empty string (0 bytes in length) as the disk prompt.
	/// </param>
	/// <returns>
	/// <para>The <c>MsiSourceListAddMediaDisk</c> function returns the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>
	/// The user does not have the ability to read the specified media source or the specified product or patch. This does not indicate
	/// whether a media source, product or patch was found.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_BAD_CONFIGURATION</term>
	/// <term>The configuration data is corrupt.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSTALL_SERVICE_FAILURE</term>
	/// <term>The Windows Installer service could not be accessed.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>An invalid parameter was passed to the function.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SUCCESS</term>
	/// <term>The value was successfully reordered.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNKNOWN_PATCH</term>
	/// <term>The patch was not found.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNKNOWN_PRODUCT</term>
	/// <term>The product was not found.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_FUNCTION_FAILED</term>
	/// <term>Unexpected internal failure.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Administrators can modify the installation of a product or patch instance that exists under the machine context or under their
	/// own per-user context (managed or unmanaged.) They can modify the installation of a product or patch instance that exists under
	/// any user's per-user-managed context. Administrators cannot modify another user's installation of a product or patch instance
	/// that exists under that other user's per-user-unmanaged context.
	/// </para>
	/// <para>
	/// Non-administrators cannot modify the installation of a product or patch instance that exists under another user's per-user
	/// context (managed or unmanaged.) They can modify the installation of a product or patch instance that exists under their own
	/// per-user-unmanaged context. They can modify the installation of a product or patch instance under the machine context or their
	/// own per-user-managed context only if they are enabled to browse for a product or patch source. Users can be enabled to browse
	/// for sources by setting policy. For more information, see DisableBrowse, AllowLockdownBrowse, AllowLockDownMedia and
	/// AlwaysInstallElevated policies.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msisourcelistaddmediadiska UINT MsiSourceListAddMediaDiskA( LPCSTR
	// szProductCodeOrPatchCode, LPCSTR szUserSid, MSIINSTALLCONTEXT dwContext, DWORD dwOptions, DWORD dwDiskId, LPCSTR szVolumeLabel,
	// LPCSTR szDiskPrompt );
	[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiSourceListAddMediaDiskA")]
	public static extern Win32Error MsiSourceListAddMediaDisk([MarshalAs(UnmanagedType.LPTStr)] string szProductCodeOrPatchCode,
		[Optional, MarshalAs(UnmanagedType.LPTStr)] string? szUserSid, MSIINSTALLCONTEXT dwContext, MSICODE dwOptions, uint dwDiskId,
		[Optional, MarshalAs(UnmanagedType.LPTStr)] string? szVolumeLabel, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? szDiskPrompt);

	/// <summary>
	/// <para>
	/// The <c>MsiSourceListAddSource</c> function adds to the list of valid network sources that contain the specified type of sources
	/// for a product or patch in a specified user context.
	/// </para>
	/// <para>The number of sources in the SOURCELIST property is unlimited.</para>
	/// </summary>
	/// <param name="szProduct">The ProductCode of the product to modify.</param>
	/// <param name="szUserName">
	/// <para>
	/// The user name for a per-user installation. On Windows 2000 or Windows XP, the user name should always be in the format of
	/// DOMAIN\USERNAME (or MACHINENAME\USERNAME for a local user).
	/// </para>
	/// <para>An empty string or <c>NULL</c> for a per-machine installation.</para>
	/// </param>
	/// <param name="dwReserved">Reserved for future use. This value must be set to 0.</param>
	/// <param name="szSource">Pointer to the string specifying the source.</param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>The user does not have the ability to add a source.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_BAD_CONFIGURATION</term>
	/// <term>The configuration data is corrupt.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_BAD_USERNAME</term>
	/// <term>Could not resolve the user name.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_FUNCTION_FAILED</term>
	/// <term>The function did not succeed.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSTALL_SERVICE_FAILURE</term>
	/// <term>Could not access installer service.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>An invalid parameter was passed to the function.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SUCCESS</term>
	/// <term>The source was added.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNKNOWN_PRODUCT</term>
	/// <term>The specified product is unknown.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// An administrator can modify per-machine installations, their own per-user non-managed installations, and the per-user managed
	/// installations for any user. A non-administrator can only modify per-machine installations and their own (managed or
	/// non-managed)per-user installations. Users can be enabled to browse for sources by setting policy. For more information, see the
	/// DisableBrowse, AllowLockdownBrowse, and AlwaysInstallElevated policies.
	/// </para>
	/// <para>
	/// Note that this function merely adds the new source to the list of valid sources. If another source was used to install the
	/// product, the new source is not used until the current source is unavailable.
	/// </para>
	/// <para>It is the responsibility of the caller to ensure that the provided source is a valid source image for the product.</para>
	/// <para>
	/// If the user name is an empty string or <c>NULL</c>, the function operates on the per-machine installation of the product. In
	/// this case, if the product is installed only in the per-user state, the function returns ERROR_UNKNOWN_PRODUCT.
	/// </para>
	/// <para>
	/// If the user name is not an empty string or <c>NULL</c>, it specifies the name of the user whose product installation is
	/// modified. If the user name is the current user name, the function first attempts to modify a non-managed installation of the
	/// product. If no non-managed installation of the product can be found, the function then tries to modify a managed per-user
	/// installation of the product. If no managed or unmanaged per-user installations of the product can be found, the function returns
	/// ERROR_UNKNOWN_PRODUCT, even if the product is installed per-machine.
	/// </para>
	/// <para>
	/// This function can not modify a non-managed installation for any user besides the current user. If the user name is not an empty
	/// string or <c>NULL</c>, but is not the current user, the function only checks for a managed per-user installation of the product
	/// for the specified user. If the product is not installed as managed per-user for the specified user, the function returns
	/// ERROR_UNKNOWN_PRODUCT, even if the product is installed per-machine.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msisourcelistaddsourcea UINT MsiSourceListAddSourceA( LPCSTR
	// szProduct, LPCSTR szUserName, DWORD dwReserved, LPCSTR szSource );
	[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiSourceListAddSourceA")]
	public static extern Win32Error MsiSourceListAddSource([MarshalAs(UnmanagedType.LPTStr)] string szProduct,
		[Optional, MarshalAs(UnmanagedType.LPTStr)] string? szUserName, [Optional] uint dwReserved, [MarshalAs(UnmanagedType.LPTStr)] string szSource);

	/// <summary>
	/// The <c>MsiSourceListAddSourceEx</c> function adds or reorders the set of sources of a patch or product in a specified context.
	/// It can also create a source list for a patch that does not exist in the specified context.
	/// </summary>
	/// <param name="szProductCodeOrPatchCode">
	/// The ProductCode or patch GUID of the product or patch. Use a null-terminated string. If the string is longer than 39 characters,
	/// the function fails and returns <c>ERROR_INVALID_PARAMETER</c>. This parameter cannot be <c>NULL</c>.
	/// </param>
	/// <param name="szUserSid">
	/// <para>
	/// This parameter can be a string SID that specifies the user account that contains the product or patch. The SID is not validated
	/// or resolved. An incorrect SID can return <c>ERROR_UNKNOWN_PRODUCT</c> or <c>ERROR_UNKNOWN_PATCH</c>. When referencing a machine
	/// context, szUserSID must be <c>NULL</c> and dwContext must be <c>MSIINSTALLCONTEXT_MACHINE</c>.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Type of SID</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>NULL</term>
	/// <term>
	/// NULL denotes the currently logged on user. When referencing the current user account, szUserSID can be NULL and dwContext can be
	/// MSIINSTALLCONTEXT_USERMANAGED or MSIINSTALLCONTEXT_USERUNMANAGED.
	/// </term>
	/// </item>
	/// <item>
	/// <term>User SID</term>
	/// <term>Specifies enumeration for a particular user in the system. An example of a user SID is "S-1-3-64-2415071341-1358098788-3127455600-2561".</term>
	/// </item>
	/// </list>
	/// <para>
	/// <c>Note</c> The special SID string s-1-5-18 (system) cannot be used to enumerate products or patches installed as per-machine.
	/// Setting the SID value to "S-1-5-18" returns <c>ERROR_INVALID_PARAMETER</c>.
	/// </para>
	/// <para>
	/// <c>Note</c> The special SID string s-1-1-0 (everyone) should not be used. Setting the SID value to "S-1-1-0" fails and returns <c>ERROR_INVALID_PARAM</c>.
	/// </para>
	/// </param>
	/// <param name="dwContext">
	/// <para>
	/// This parameter specifies the context of the product or patch instance. This parameter can contain one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Type of context</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MSIINSTALLCONTEXT_USERMANAGED</term>
	/// <term>The product or patch instance exists in the per-user-managed context.</term>
	/// </item>
	/// <item>
	/// <term>MSIINSTALLCONTEXT_USERUNMANAGED</term>
	/// <term>The product or patch instance exists in the per-user-unmanaged context.</term>
	/// </item>
	/// <item>
	/// <term>MSIINSTALLCONTEXT_MACHINE</term>
	/// <term>The product or patch instance exists in the per-machine context.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwOptions">
	/// <para>
	/// The dwOptions value determines the interpretation of the szProductCodeOrPatchCode value and the type of sources to clear. This
	/// parameter must be a combination of one of the following <c>MSISOURCETYPE_</c> constants and one of the following <c>MSICODE_</c> constants.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Flag</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MSISOURCETYPE_NETWORK</term>
	/// <term>The source is a network type.</term>
	/// </item>
	/// <item>
	/// <term>MSISOURCETYPE_URL</term>
	/// <term>The source is a URL type.</term>
	/// </item>
	/// <item>
	/// <term>MSICODE_PRODUCT</term>
	/// <term>szProductCodeOrPatchCode is a product code.</term>
	/// </item>
	/// <item>
	/// <term>MSICODE_PATCH</term>
	/// <term>szProductCodeOrPatchCode is a patch code.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="szSource">
	/// Source to add or move. This parameter is expected to contain only the path without the filename. The filename is already
	/// registered as "PackageName" and can be manipulated through MsiSourceListSetInfo. This argument is required.
	/// </param>
	/// <param name="dwIndex">
	/// <para>
	/// This parameter provides the new index for the source. All sources are indexed in the source list from 1 to N, where N is the
	/// count of sources in the list. Every source in the list has a unique index.
	/// </para>
	/// <para>
	/// If <c>MsiSourceListAddSourceEx</c> is called with a new source and dwIndex set to 0 (zero), the new source is appended to the
	/// existing list. If dwIndex is set to 0 and the source already exists in the list, no update is done on the list.
	/// </para>
	/// <para>
	/// If <c>MsiSourceListAddSourceEx</c> is called with a new source and dwIndex set to a non-zero value less than count (N), the new
	/// source is placed at the specified index and the other sources are re-indexed. If the source already exists, it is moved to the
	/// specified index and the other sources are re-indexed.
	/// </para>
	/// <para>
	/// If <c>MsiSourceListAddSourceEx</c> is called with a new source and dwIndex set to a non-zero value greater than the count of
	/// sources (N), the new source is appended to the existing list. If the source already exists, it is moved to the end of the list
	/// and the other sources are re-indexed.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>The <c>MsiSourceListAddSourceEx</c> function returns the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>The user does not have the ability to add or move a source. Does not indicate whether the product or patch was found.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_BAD_CONFIGURATION</term>
	/// <term>The configuration data is corrupt.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSTALL_SERVICE_FAILURE</term>
	/// <term>Could not access the Windows Installer service.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SUCCESS</term>
	/// <term>The source was inserted or updated.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNKNOWN_PRODUCT</term>
	/// <term>The specified product is unknown.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNKNOWN_PATCH</term>
	/// <term>The specified patch is unknown.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_FUNCTION_FAILED</term>
	/// <term>Unexpected internal failure.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Administrators can modify the installation of a product or patch instance that exists under the machine context or under their
	/// own per-user context (managed or unmanaged.) They can modify the installation of a product or patch instance that exists under
	/// any user's per-user-managed context. Administrators cannot modify another user's installation of a product or patch instance
	/// that exists under that other user's per-user-unmanaged context.
	/// </para>
	/// <para>
	/// Non-administrators cannot modify the installation of a product or patch instance that exists under another user's per-user
	/// context (managed or unmanaged.) They can modify the installation of a product or patch instance that exists under their own
	/// per-user-unmanaged context. They can modify the installation of a product or patch instance under the machine context or their
	/// own per-user-managed context only if they are enabled to browse for a product or patch source. Users can be enabled to browse
	/// for sources by setting policy. For more information, see the DisableBrowse, AllowLockdownBrowse, and AlwaysInstallElevated policies.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msisourcelistaddsourceexa UINT MsiSourceListAddSourceExA( LPCSTR
	// szProductCodeOrPatchCode, LPCSTR szUserSid, MSIINSTALLCONTEXT dwContext, DWORD dwOptions, LPCSTR szSource, DWORD dwIndex );
	[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiSourceListAddSourceExA")]
	public static extern Win32Error MsiSourceListAddSourceEx([MarshalAs(UnmanagedType.LPTStr)] string szProductCodeOrPatchCode,
		[Optional, MarshalAs(UnmanagedType.LPTStr)] string? szUserSid, MSIINSTALLCONTEXT dwContext, uint dwOptions,
		[MarshalAs(UnmanagedType.LPTStr)] string szSource, uint dwIndex);

	/// <summary>
	/// The <c>MsiSourceListClearAll</c> function removes all network sources from the source list of a patch or product in a specified
	/// context. For more information, see Source Resiliency.
	/// </summary>
	/// <param name="szProduct">The ProductCode of the product to modify.</param>
	/// <param name="szUserName">
	/// <para>
	/// The user name for a per-user installation. The user name should always be in the format of DOMAIN\USERNAME (or
	/// MACHINENAME\USERNAME for a local user).
	/// </para>
	/// <para>An empty string or <c>NULL</c> for a per-machine installation.</para>
	/// </param>
	/// <param name="dwReserved">Reserved for future use. This value must be set to 0.</param>
	/// <returns>
	/// <para>The <c>MsiSourceListClearAll</c> function returns the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>The user does not have the ability to clear the source list for this product.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_BAD_CONFIGURATION</term>
	/// <term>The configuration data is corrupt.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_BAD_USERNAME</term>
	/// <term>Could not resolve the user name.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_FUNCTION_FAILED</term>
	/// <term>The function did not succeed.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSTALL_SERVICE_FAILURE</term>
	/// <term>Could not access installer service.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>An invalid parameter was passed to the function.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SUCCESS</term>
	/// <term>The function succeeded.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNKNOWN_PRODUCT</term>
	/// <term>The specified product is unknown.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// An administrator can modify per-machine installations, their own per-user non-managed installations, and the per-user managed
	/// installations for any user. A non-administrator can only modify per-machine installations and their own (managed or
	/// non-managed)per-user installations. Users can be enabled to browse for sources by setting policy. For more information, see the
	/// DisableBrowse, AllowLockdownBrowse, and AlwaysInstallElevated policies.
	/// </para>
	/// <para>
	/// If a network source is the current source for the product, this function forces the installer to search the source list for a
	/// valid source the next time a source is needed. If the current source is media or a URL source, it is still valid after this call
	/// and the source list is not searched unless MsiSourceListForceResolution is also called.
	/// </para>
	/// <para>
	/// If the user name is an empty string or <c>NULL</c>, the function operates on the per-machine installation of the product. In
	/// this case, if the product is installed as per-user only, the function returns ERROR_UNKNOWN_PRODUCT.
	/// </para>
	/// <para>
	/// If the user name is not an empty string or <c>NULL</c>, it specifies the name of the user whose product installation is
	/// modified. If the user name is the current user name, the function first attempts to modify a non-managed installation of the
	/// product. If no non-managed installation of the product can be found, the function then tries to modify a managed per-user
	/// installation of the product. If no managed or unmanaged per-user installations of the product can be found, the function returns
	/// ERROR_UNKNOWN_PRODUCT, even if the product is installed per-machine.
	/// </para>
	/// <para>
	/// This function cannot modify a non-managed installation for any user besides the current user. If the user name is not an empty
	/// string or <c>NULL</c>, but is not the current user, the function only checks for a managed per-user installation of the product
	/// for the specified user. If the product is not installed as managed per-user for the specified user, the function returns
	/// ERROR_UNKNOWN_PRODUCT, even if the product is installed per-machine.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msisourcelistclearalla UINT MsiSourceListClearAllA( LPCSTR
	// szProduct, LPCSTR szUserName, DWORD dwReserved );
	[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiSourceListClearAllA")]
	public static extern Win32Error MsiSourceListClearAll([MarshalAs(UnmanagedType.LPTStr)] string szProduct,
		[Optional, MarshalAs(UnmanagedType.LPTStr)] string? szUserName, uint dwReserved = 0);

	/// <summary>
	/// The <c>MsiSourceListClearAllEx</c> function removes all the existing sources of a given source type for the specified product or
	/// patch instance. The patch registration is also removed if the sole source of the patch gets removed and if the patch is not
	/// installed as a new patch by any client in the same context. Specifying that <c>MsiSourceListClearAllEx</c> remove the current
	/// source for this product or patch forces the installer to search the source list for a source the next time a source is required.
	/// </summary>
	/// <param name="szProductCodeOrPatchCode">
	/// The ProductCode or patch GUID of the product or patch. Use a null-terminated string. If the string is longer than 39 characters,
	/// the function fails and returns ERROR_INVALID_PARAMETER. This parameter cannot be <c>NULL</c>.
	/// </param>
	/// <param name="szUserSid">
	/// This parameter can be a string SID that specifies the user account that contains the product or patch. The SID is not validated
	/// or resolved. An incorrect SID can return ERROR_UNKNOWN_PRODUCT or ERROR_UNKNOWN_PATCH. When referencing a machine context,
	/// szUserSID must be <c>NULL</c> and dwContext must be MSIINSTALLCONTEXT_MACHINE. Using the machine SID ("S-1-5-18") returns
	/// ERROR_INVALID PARAMETER. When referencing the current user account, szUserSID can be <c>NULL</c> and dwContext can be
	/// MSIINSTALLCONTEXT_USERMANAGED or MSIINSTALLCONTEXT_USERUNMANAGED.
	/// </param>
	/// <param name="dwContext">
	/// <para>
	/// This parameter specifies the context of the product or patch instance. This parameter can contain one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Type of context</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MSIINSTALLCONTEXT_USERMANAGED</term>
	/// <term>The product or patch instance exists in the per-user-managed context.</term>
	/// </item>
	/// <item>
	/// <term>MSIINSTALLCONTEXT_USERUNMANAGED</term>
	/// <term>The product or patch instance exists in the per-user-unmanaged context.</term>
	/// </item>
	/// <item>
	/// <term>MSIINSTALLCONTEXT_MACHINE</term>
	/// <term>The product or patch instance exists in the per-machine context.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwOptions">
	/// <para>
	/// The dwOptions value determines the interpretation of the szProductCodeOrPatchCode value and the type of sources to clear. This
	/// parameter must be a combination of one of the following MSISOURCETYPE_* constants and one of the following MSICODE_* constants.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Flag</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MSISOURCETYPE_MEDIA</term>
	/// <term>The source is media.</term>
	/// </item>
	/// <item>
	/// <term>MSISOURCETYPE_NETWORK</term>
	/// <term>The source is a network type.</term>
	/// </item>
	/// <item>
	/// <term>MSISOURCETYPE_URL</term>
	/// <term>The source is a URL type.</term>
	/// </item>
	/// <item>
	/// <term>MSICODE_PATCH</term>
	/// <term>szProductCodeOrPatchCode is a patch code.</term>
	/// </item>
	/// <item>
	/// <term>MSICODE_PRODUCT</term>
	/// <term>szProductCodeOrPatchCode is a product code.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>The user does not have the ability to add or move a source. Does not indicate whether the product or patch was found.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_BAD_CONFIGURATION</term>
	/// <term>The configuration data is corrupt.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSTALL_SERVICE_FAILURE</term>
	/// <term>Cannot access the Windows Installer service.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>An invalid parameter was passed to the function.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SUCCESS</term>
	/// <term>All sources of the specified type were removed.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNKNOWN_PRODUCT</term>
	/// <term>The specified product is unknown.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNKNOWN_PATCH</term>
	/// <term>The specified patch is unknown.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_FUNCTION_FAILED</term>
	/// <term>Unexpected internal failure.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Administrators can modify the installation of a product or patch instance that exists under the machine context or under their
	/// own per-user context (managed or unmanaged.) They can modify the installation of a product or patch instance that exists under
	/// any user's per-user-managed context. Administrators cannot modify another user's installation of a product or patch instance
	/// that exists under that other user's per-user-unmanaged context.
	/// </para>
	/// <para>
	/// Non-administrators cannot modify the installation of a product or patch instance that exists under another user's per-user
	/// context (managed or unmanaged.) They can modify the installation of a product or patch instance that exists under their own
	/// per-user-unmanaged context. They can modify the installation of a product or patch instance under the machine context or their
	/// own per-user-managed context only if they are enabled to browse for a product or patch source. Users can be enabled to browse
	/// for sources by setting policy, for more information, see DisableBrowse, AllowLockdownBrowse, and AlwaysInstallElevated policies.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msisourcelistclearallexa UINT MsiSourceListClearAllExA( LPCSTR
	// szProductCodeOrPatchCode, LPCSTR szUserSid, MSIINSTALLCONTEXT dwContext, DWORD dwOptions );
	[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiSourceListClearAllExA")]
	public static extern Win32Error MsiSourceListClearAllEx([MarshalAs(UnmanagedType.LPTStr)] string szProductCodeOrPatchCode,
		[Optional, MarshalAs(UnmanagedType.LPTStr)] string? szUserSid, MSIINSTALLCONTEXT dwContext, uint dwOptions);

	/// <summary>
	/// The <c>MsiSourceListClearMediaDisk</c> function provides the ability to remove an existing registered disk under the media
	/// source for a product or patch in a specific context.
	/// </summary>
	/// <param name="szProductCodeOrPatchCode">
	/// The ProductCode or patch GUID of the product or patch. Use a null-terminated string. If the string is longer than 39 characters,
	/// the function fails and returns ERROR_INVALID_PARAMETER. This parameter cannot be <c>NULL</c>.
	/// </param>
	/// <param name="szUserSid">
	/// <para>
	/// This parameter can be a string SID that specifies the user account that contains the product or patch. The SID is not validated
	/// or resolved. An incorrect SID can return ERROR_UNKNOWN_PRODUCT or ERROR_UNKNOWN_PATCH.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Type of SID</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>NULL</term>
	/// <term>
	/// NULL denotes the currently logged on user. When referencing the current user account, szUserSID can be NULL and dwContext can be
	/// MSIINSTALLCONTEXT_USERMANAGED or MSIINSTALLCONTEXT_USERUNMANAGED.
	/// </term>
	/// </item>
	/// <item>
	/// <term>User SID</term>
	/// <term>Specifies enumeration for a particular user in the system. An example of user SID is "S-1-3-64-2415071341-1358098788-3127455600-2561".</term>
	/// </item>
	/// </list>
	/// <para>
	/// <c>Note</c> The special SID string s-1-5-18 (system) cannot be used to enumerate products or patches installed as per-machine.
	/// Setting the SID value to s-1-5-18 returns ERROR_INVALID_PARAMETER. When dwContext is set to MSIINSTALLCONTEXT_MACHINE only,
	/// szUserSid must be <c>NULL</c>.
	/// </para>
	/// <para>
	/// <c>Note</c> The special SID string s-1-1-0 (everyone) should not be used. Setting the SID value to s-1-1-0 fails and returns ERROR_INVALID_PARAM.
	/// </para>
	/// </param>
	/// <param name="dwContext">
	/// <para>
	/// This parameter specifies the context of the product or patch instance. This parameter can contain one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Type of context</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MSIINSTALLCONTEXT_USERMANAGED</term>
	/// <term>The product or patch instance exists in the per-user-managed context.</term>
	/// </item>
	/// <item>
	/// <term>MSIINSTALLCONTEXT_USERUNMANAGED</term>
	/// <term>The product or patch instance exists in the per-user-unmanaged context.</term>
	/// </item>
	/// <item>
	/// <term>MSIINSTALLCONTEXT_MACHINE</term>
	/// <term>The product or patch instance exists in the per-machine context.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwOptions">
	/// <para>The dwOptions value specifies the meaning of szProductCodeOrPatchCode.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Flag</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MSICODE_PRODUCT</term>
	/// <term>szProductCodeOrPatchCode is a product code GUID.</term>
	/// </item>
	/// <item>
	/// <term>MSICODE_PATCH</term>
	/// <term>szProductCodeOrPatchCode is a patch code GUID.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwDiskId">This parameter provides the ID of the disk being removed.</param>
	/// <returns>
	/// <para>The <c>MsiSourceListClearMediaDisk</c> function returns the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>
	/// The user does not have the ability to read the specified media source or the specified product or patch. This does not indicate
	/// whether a media source, product or patch was found.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_BAD_CONFIGURATION</term>
	/// <term>The configuration data is corrupt.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSTALL_SERVICE_FAILURE</term>
	/// <term>The Windows Installer service could not be accessed.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>An invalid parameter was passed to the function.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SUCCESS</term>
	/// <term>The value was successfully removed or not found.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNKNOWN_PATCH</term>
	/// <term>The patch was not found.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNKNOWN_PRODUCT</term>
	/// <term>The product was not found.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_FUNCTION_FAILED</term>
	/// <term>Unexpected internal failure.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Administrators can modify the installation of a product or patch instance that exists under the machine context or under their
	/// own per-user context (managed or unmanaged.) They can modify the installation of a product or patch instance that exists under
	/// any user's per-user-managed context. Administrators cannot modify another user's installation of a product or patch instance
	/// that exists under that other user's per-user-unmanaged context.
	/// </para>
	/// <para>
	/// Non-administrators cannot modify the installation of a product or patch instance that exists under another user's per-user
	/// context (managed or unmanaged.) They can modify the installation of a product or patch instance that exists under their own
	/// per-user-unmanaged context. They can modify the installation of a product or patch instance under the machine context or their
	/// own per-user-managed context only if they are enabled to browse for a product or patch source. Users can be enabled to browse
	/// for sources by setting policy. For more information, see the DisableBrowse, AllowLockdownBrowse, and AlwaysInstallElevated policies.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msisourcelistclearmediadiska UINT MsiSourceListClearMediaDiskA(
	// LPCSTR szProductCodeOrPatchCode, LPCSTR szUserSid, MSIINSTALLCONTEXT dwContext, DWORD dwOptions, DWORD dwDiskId );
	[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiSourceListClearMediaDiskA")]
	public static extern Win32Error MsiSourceListClearMediaDisk([MarshalAs(UnmanagedType.LPTStr)] string szProductCodeOrPatchCode,
		[Optional, MarshalAs(UnmanagedType.LPTStr)] string? szUserSid, MSIINSTALLCONTEXT dwContext, MSICODE dwOptions, uint dwDiskId);

	/// <summary>
	/// The <c>MsiSourceListClearSource</c> function removes an existing source for a product or patch in a specified context. The patch
	/// registration is also removed if the sole source of the patch gets removed and if the patch is not installed by any client in the
	/// same context. Specifying that <c>MsiSourceListClearSource</c> remove the current source for this product or patch forces the
	/// installer to search the source list for a source the next time a source is required.
	/// </summary>
	/// <param name="szProductCodeOrPatchCode">
	/// The ProductCode or patch GUID of the product or patch. Use a null-terminated string. If the string is longer than 39 characters,
	/// the function fails and returns <c>ERROR_INVALID_PARAMETER</c>. This parameter cannot be <c>NULL</c>.
	/// </param>
	/// <param name="szUserSid">
	/// <para>
	/// This parameter can be a string SID that specifies the user account that contains the product or patch. The SID is not validated
	/// or resolved. An incorrect SID can return <c>ERROR_UNKNOWN_PRODUCT</c> or <c>ERROR_UNKNOWN_PATCH</c>. When referencing a machine
	/// context, szUserSID must be <c>NULL</c> and dwContext must be <c>MSIINSTALLCONTEXT_MACHINE</c>.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Type of SID</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>NULL</term>
	/// <term>
	/// NULL denotes the currently logged on user. When referencing the current user account, szUserSID can be NULL and dwContext can be
	/// MSIINSTALLCONTEXT_USERMANAGED or MSIINSTALLCONTEXT_USERUNMANAGED.
	/// </term>
	/// </item>
	/// <item>
	/// <term>User SID</term>
	/// <term>Specifies enumeration for a particular user in the system. An example of a user SID is "S-1-3-64-2415071341-1358098788-3127455600-2561".</term>
	/// </item>
	/// </list>
	/// <para>
	/// <c>Note</c> The special SID string "S-1-5-18" (system) cannot be used to enumerate products or patches installed as per-machine.
	/// Setting the SID value to "S-1-5-18" returns <c>ERROR_INVALID_PARAMETER</c>.
	/// </para>
	/// <para>
	/// <c>Note</c> The special SID string "S-1-1-0" (everyone) should not be used. Setting the SID value to "S-1-1-0" fails and returns <c>ERROR_INVALID_PARAM</c>.
	/// </para>
	/// </param>
	/// <param name="dwContext">
	/// <para>
	/// This parameter specifies the context of the product or patch instance. This parameter can contain one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Type of context</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MSIINSTALLCONTEXT_USERMANAGED</term>
	/// <term>The product or patch instance exists in the per-user-managed context.</term>
	/// </item>
	/// <item>
	/// <term>MSIINSTALLCONTEXT_USERUNMANAGED</term>
	/// <term>The product or patch instance exists in the per-user-unmanaged context.</term>
	/// </item>
	/// <item>
	/// <term>MSIINSTALLCONTEXT_MACHINE</term>
	/// <term>The product or patch instance exists in the per-machine context.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwOptions">
	/// <para>
	/// The dwOptions value determines the interpretation of the szProductCodeOrPatchCode value and the type of sources to clear. This
	/// parameter must be a combination of one of the following <c>MSISOURCETYPE_</c> constants and one of the following <c>MSICODE_</c> constants.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Flag</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MSISOURCETYPE_NETWORK</term>
	/// <term>The source is a network type.</term>
	/// </item>
	/// <item>
	/// <term>MSISOURCETYPE_URL</term>
	/// <term>The source is a URL type.</term>
	/// </item>
	/// <item>
	/// <term>MSICODE_PRODUCT</term>
	/// <term>szProductCodeOrPatchCode is a product code.</term>
	/// </item>
	/// <item>
	/// <term>MSICODE_PATCH</term>
	/// <term>szProductCodeOrPatchCode is a patch code.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="szSource">
	/// Source to remove. This parameter is expected to contain only the path without the filename. The filename is already registered
	/// as "PackageName" and can be manipulated through MsiSourceListSetInfo. This argument is required.
	/// </param>
	/// <returns>
	/// <para>The <c>MsiSourceListClearSource</c> function returns the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>The user does not have the ability to remove a source. Does not indicate whether the product or patch was found.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_BAD_CONFIGURATION</term>
	/// <term>The configuration data is corrupt.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSTALL_SERVICE_FAILURE</term>
	/// <term>Could not access the Windows Installer service</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>An invalid parameter was passed to the function.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SUCCESS</term>
	/// <term>The source was removed or not found.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNKNOWN_PATCH</term>
	/// <term>The specified patch is unknown.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNKNOWN_PRODUCT</term>
	/// <term>The specified product is unknown.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_FUNCTION_FAILED</term>
	/// <term>Unexpected internal failure.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Administrators can modify the installation of a product or patch instance that exists under the machine context or under their
	/// own per-user context (managed or unmanaged.) They can modify the installation of a product or patch instance that exists under
	/// any user's per-user-managed context. Administrators cannot modify another user's installation of a product or patch instance
	/// that exists under that other user's per-user-unmanaged context.
	/// </para>
	/// <para>
	/// Non-administrators cannot modify the installation of a product or patch instance that exists under another user's per-user
	/// context (managed or unmanaged.) They can modify the installation of a product or patch instance that exists under their own
	/// per-user-unmanaged context. They can modify the installation of a product or patch instance under the machine context or their
	/// own per-user-managed context only if they are enabled to browse for a product or patch source. Users can be enabled to browse
	/// for sources by setting policy. For more information, see the DisableBrowse, AllowLockdownBrowse, and AlwaysInstallElevated policies.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msisourcelistclearsourcea UINT MsiSourceListClearSourceA( LPCSTR
	// szProductCodeOrPatchCode, LPCSTR szUserSid, MSIINSTALLCONTEXT dwContext, DWORD dwOptions, LPCSTR szSource );
	[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiSourceListClearSourceA")]
	public static extern Win32Error MsiSourceListClearSource([MarshalAs(UnmanagedType.LPTStr)] string szProductCodeOrPatchCode,
		[Optional, MarshalAs(UnmanagedType.LPTStr)] string? szUserSid, MSIINSTALLCONTEXT dwContext, uint dwOptions,
		[MarshalAs(UnmanagedType.LPTStr)] string szSource);

	/// <summary>
	/// The <c>MsiSourceListEnumMediaDisks</c> function enumerates the list of disks registered for the media source for a patch or product.
	/// </summary>
	/// <param name="szProductCodeOrPatchCode">
	/// The ProductCode or patch GUID of the product or patch. Use a null-terminated string. If the string is longer than 39 characters,
	/// the function fails and returns ERROR_INVALID_PARAMETER. This parameter cannot be <c>NULL</c>.
	/// </param>
	/// <param name="szUserSid">
	/// <para>
	/// A string SID that specifies the user account that contains the product or patch. The SID is not validated or resolved. An
	/// incorrect SID can return ERROR_UNKNOWN_PRODUCT or ERROR_UNKNOWN_PATCH. When referencing a machine context, szUserSID must be
	/// <c>NULL</c> and dwContext must be MSIINSTALLCONTEXT_MACHINE.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Type of SID</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>NULL</term>
	/// <term>
	/// A NULL denotes the currently logged on user. When referencing the current user account, szUserSID can be NULL and dwContext can
	/// be MSIINSTALLCONTEXT_USERMANAGED or MSIINSTALLCONTEXT_USERUNMANAGED.
	/// </term>
	/// </item>
	/// <item>
	/// <term>User SID</term>
	/// <term>An enumeration for a specific user in the system. An example of a user SID is "S-1-3-64-2415071341-1358098788-3127455600-2561".</term>
	/// </item>
	/// <item>
	/// <term>s-1-1-0</term>
	/// <term>The special SID string s-1-1-0 (everyone) specifies enumeration across all users in the system.</term>
	/// </item>
	/// </list>
	/// <para>
	/// <c>Note</c> The special SID string s-1-5-18 (system) cannot be used to enumerate products or patches installed as per-machine.
	/// Setting the SID value to s-1-5-18 returns ERROR_INVALID_PARAMETER.
	/// </para>
	/// </param>
	/// <param name="dwContext">
	/// <para>
	/// This parameter specifies the context of the product or patch instance. This parameter can contain one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Type of context</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MSIINSTALLCONTEXT_USERMANAGED</term>
	/// <term>The product or patch instance exists in the per-user-managed context.</term>
	/// </item>
	/// <item>
	/// <term>MSIINSTALLCONTEXT_USERUNMANAGED</term>
	/// <term>The product or patch instance exists in the per-user-unmanaged context.</term>
	/// </item>
	/// <item>
	/// <term>MSIINSTALLCONTEXT_MACHINE</term>
	/// <term>The product or patch instance exists in the per-machine context.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwOptions">
	/// <para>The dwOptions value that specifies the meaning of szProductCodeOrPatchCode.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Flag</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MSICODE_PRODUCT</term>
	/// <term>szProductCodeOrPatchCode is a product code GUID.</term>
	/// </item>
	/// <item>
	/// <term>MSICODE_PATCH</term>
	/// <term>szProductCodeOrPatchCode is a patch code GUID.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwIndex">
	/// The index of the source to retrieve. This parameter must be 0 (zero) for the first call to the
	/// <c>MsiSourceListEnumMediaDisks</c> function, and then incremented for subsequent calls until the function returns ERROR_NO_MORE_ITEMS.
	/// </param>
	/// <param name="pdwDiskId">
	/// On entry to <c>MsiSourceListEnumMediaDisks</c> this parameter provides a pointer to a <c>DWORD</c> to receive the ID of the disk
	/// that is being enumerated. This parameter is optional.
	/// </param>
	/// <param name="szVolumeLabel">
	/// <para>
	/// An output buffer that receives the volume label of the disk that is being enumerated. This buffer should be large enough to
	/// contain the information. If the buffer is too small, the function returns ERROR_MORE_DATA and sets *pcchVolumeLabel to the
	/// number of <c>TCHAR</c> in the value, not including the terminating NULL character.
	/// </para>
	/// <para>
	/// If szVolumeLabel and pcchVolumeLabel are both set to <c>NULL</c>, the function returns ERROR_SUCCESS if the value exists,
	/// without retrieving the value.
	/// </para>
	/// </param>
	/// <param name="pcchVolumeLabel">
	/// <para>
	/// A pointer to a variable that specifies the number of <c>TCHAR</c> in the szVolumeLabel buffer. When the function returns, this
	/// parameter is the number of <c>TCHAR</c> in the received value, not including the terminating null character.
	/// </para>
	/// <para>This parameter can be set to <c>NULL</c> only if szVolumeLabel is also <c>NULL</c>, otherwise the function returns ERROR_INVALID_PARAMETER.</para>
	/// </param>
	/// <param name="szDiskPrompt">
	/// <para>
	/// An output buffer that receives the disk prompt of the disk that is being enumerated. This buffer should be large enough to
	/// contain the information. If the buffer is too small, the function returns ERROR_MORE_DATA and sets *pcchDiskPrompt to the number
	/// of <c>TCHAR</c> in the value, not including the terminating NULL character.
	/// </para>
	/// <para>
	/// If the szDiskPrompt is set to <c>NULL</c> and pcchDiskPrompt is set to a valid pointer, the function returns ERROR_SUCCESS and
	/// sets *pcchDiskPrompt to the number of <c>TCHAR</c> in the value, not including the terminating NULL character. The function can
	/// then be called again to retrieve the value, with szDiskPrompt buffer large enough to contain *pcchDiskPrompt + 1 characters.
	/// </para>
	/// <para>
	/// If szDiskPrompt and pcchDiskPrompt are both set to <c>NULL</c>, the function returns ERROR_SUCCESS if the value exists, without
	/// retrieving the value.
	/// </para>
	/// </param>
	/// <param name="pcchDiskPrompt">
	/// <para>
	/// A pointer to a variable that specifies the number of <c>TCHAR</c> in the szDiskPrompt buffer. When the function returns, this
	/// parameter is set to the size of the requested value whether or not the function copies the value into the specified buffer. The
	/// size is returned as the number of <c>TCHAR</c> in the requested value, not including the terminating null character.
	/// </para>
	/// <para>This parameter can be set to <c>NULL</c> only if szDiskPrompt is also <c>NULL</c>, otherwise the function returns ERROR_INVALID_PARAMETER.</para>
	/// </param>
	/// <returns>
	/// <para>The <c>MsiSourceListEnumMediaDisks</c> function returns the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>
	/// The user does not have the ability to read the specified media source or the specified product or patch. This does not indicate
	/// whether a media source, product, or patch is found.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_BAD_CONFIGURATION</term>
	/// <term>The configuration data is corrupt.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>An invalid parameter is passed to the function.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NO_MORE_ITEMS</term>
	/// <term>There are no more disks registered for this product or patch.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SUCCESS</term>
	/// <term>The value is enumerated successfully.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNKNOWN_PATCH</term>
	/// <term>The patch is not found.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNKNOWN_PRODUCT</term>
	/// <term>The product is not found.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>The buffer that is provided is too small to contain the requested information.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_FUNCTION_FAILED</term>
	/// <term>Unexpected internal failure.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// When making multiple calls to <c>MsiSourceListEnumMediaDisks</c> to enumerate all the sources for a single product instance,
	/// each call must be made from the same thread.
	/// </para>
	/// <para>
	/// An administrator can enumerate per-user unmanaged and managed installations for themselves, per-machine installations, and
	/// per-user managed installations for any user. An administrator cannot enumerate per-user unmanaged installations for other users.
	/// Non-administrators can only enumerate their own per-user unmanaged and managed installations and per-machine installations.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msisourcelistenummediadisksa UINT MsiSourceListEnumMediaDisksA(
	// LPCSTR szProductCodeOrPatchCode, LPCSTR szUserSid, MSIINSTALLCONTEXT dwContext, DWORD dwOptions, DWORD dwIndex, LPDWORD
	// pdwDiskId, LPSTR szVolumeLabel, LPDWORD pcchVolumeLabel, LPSTR szDiskPrompt, LPDWORD pcchDiskPrompt );
	[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiSourceListEnumMediaDisksA")]
	public static extern Win32Error MsiSourceListEnumMediaDisks([MarshalAs(UnmanagedType.LPTStr)] string szProductCodeOrPatchCode,
		[MarshalAs(UnmanagedType.LPTStr)] string szUserSid, MSIINSTALLCONTEXT dwContext, MSICODE dwOptions, uint dwIndex,
		out uint pdwDiskId, [Out, Optional, MarshalAs(UnmanagedType.LPTStr)] StringBuilder szVolumeLabel, ref uint pcchVolumeLabel,
		[Out, Optional, MarshalAs(UnmanagedType.LPTStr)] StringBuilder szDiskPrompt, ref uint pcchDiskPrompt);

	/// <summary>
	/// The <c>MsiSourceListEnumMediaDisks</c> function enumerates the list of disks registered for the media source for a patch or product.
	/// </summary>
	/// <param name="szProductCodeOrPatchCode">
	/// The ProductCode or patch GUID of the product or patch. Use a null-terminated string. If the string is longer than 39 characters,
	/// the function fails and returns ERROR_INVALID_PARAMETER. This parameter cannot be <c>NULL</c>.
	/// </param>
	/// <param name="szUserSid">
	/// <para>
	/// A string SID that specifies the user account that contains the product or patch. The SID is not validated or resolved. An
	/// incorrect SID can return ERROR_UNKNOWN_PRODUCT or ERROR_UNKNOWN_PATCH. When referencing a machine context, szUserSID must be
	/// <c>NULL</c> and dwContext must be MSIINSTALLCONTEXT_MACHINE.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Type of SID</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>NULL</term>
	/// <term>
	/// A NULL denotes the currently logged on user. When referencing the current user account, szUserSID can be NULL and dwContext can
	/// be MSIINSTALLCONTEXT_USERMANAGED or MSIINSTALLCONTEXT_USERUNMANAGED.
	/// </term>
	/// </item>
	/// <item>
	/// <term>User SID</term>
	/// <term>An enumeration for a specific user in the system. An example of a user SID is "S-1-3-64-2415071341-1358098788-3127455600-2561".</term>
	/// </item>
	/// <item>
	/// <term>s-1-1-0</term>
	/// <term>The special SID string s-1-1-0 (everyone) specifies enumeration across all users in the system.</term>
	/// </item>
	/// </list>
	/// <para>
	/// <c>Note</c> The special SID string s-1-5-18 (system) cannot be used to enumerate products or patches installed as per-machine.
	/// Setting the SID value to s-1-5-18 returns ERROR_INVALID_PARAMETER.
	/// </para>
	/// </param>
	/// <param name="dwContext">
	/// <para>
	/// This parameter specifies the context of the product or patch instance. This parameter can contain one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Type of context</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MSIINSTALLCONTEXT_USERMANAGED</term>
	/// <term>The product or patch instance exists in the per-user-managed context.</term>
	/// </item>
	/// <item>
	/// <term>MSIINSTALLCONTEXT_USERUNMANAGED</term>
	/// <term>The product or patch instance exists in the per-user-unmanaged context.</term>
	/// </item>
	/// <item>
	/// <term>MSIINSTALLCONTEXT_MACHINE</term>
	/// <term>The product or patch instance exists in the per-machine context.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwOptions">
	/// <para>The dwOptions value that specifies the meaning of szProductCodeOrPatchCode.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Flag</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MSICODE_PRODUCT</term>
	/// <term>szProductCodeOrPatchCode is a product code GUID.</term>
	/// </item>
	/// <item>
	/// <term>MSICODE_PATCH</term>
	/// <term>szProductCodeOrPatchCode is a patch code GUID.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwIndex">
	/// The index of the source to retrieve. This parameter must be 0 (zero) for the first call to the
	/// <c>MsiSourceListEnumMediaDisks</c> function, and then incremented for subsequent calls until the function returns ERROR_NO_MORE_ITEMS.
	/// </param>
	/// <param name="pdwDiskId">
	/// On entry to <c>MsiSourceListEnumMediaDisks</c> this parameter provides a pointer to a <c>DWORD</c> to receive the ID of the disk
	/// that is being enumerated. This parameter is optional.
	/// </param>
	/// <param name="szVolumeLabel">
	/// <para>
	/// An output buffer that receives the volume label of the disk that is being enumerated. This buffer should be large enough to
	/// contain the information. If the buffer is too small, the function returns ERROR_MORE_DATA and sets *pcchVolumeLabel to the
	/// number of <c>TCHAR</c> in the value, not including the terminating NULL character.
	/// </para>
	/// <para>
	/// If szVolumeLabel and pcchVolumeLabel are both set to <c>NULL</c>, the function returns ERROR_SUCCESS if the value exists,
	/// without retrieving the value.
	/// </para>
	/// </param>
	/// <param name="pcchVolumeLabel">
	/// <para>
	/// A pointer to a variable that specifies the number of <c>TCHAR</c> in the szVolumeLabel buffer. When the function returns, this
	/// parameter is the number of <c>TCHAR</c> in the received value, not including the terminating null character.
	/// </para>
	/// <para>This parameter can be set to <c>NULL</c> only if szVolumeLabel is also <c>NULL</c>, otherwise the function returns ERROR_INVALID_PARAMETER.</para>
	/// </param>
	/// <param name="szDiskPrompt">
	/// <para>
	/// An output buffer that receives the disk prompt of the disk that is being enumerated. This buffer should be large enough to
	/// contain the information. If the buffer is too small, the function returns ERROR_MORE_DATA and sets *pcchDiskPrompt to the number
	/// of <c>TCHAR</c> in the value, not including the terminating NULL character.
	/// </para>
	/// <para>
	/// If the szDiskPrompt is set to <c>NULL</c> and pcchDiskPrompt is set to a valid pointer, the function returns ERROR_SUCCESS and
	/// sets *pcchDiskPrompt to the number of <c>TCHAR</c> in the value, not including the terminating NULL character. The function can
	/// then be called again to retrieve the value, with szDiskPrompt buffer large enough to contain *pcchDiskPrompt + 1 characters.
	/// </para>
	/// <para>
	/// If szDiskPrompt and pcchDiskPrompt are both set to <c>NULL</c>, the function returns ERROR_SUCCESS if the value exists, without
	/// retrieving the value.
	/// </para>
	/// </param>
	/// <param name="pcchDiskPrompt">
	/// <para>
	/// A pointer to a variable that specifies the number of <c>TCHAR</c> in the szDiskPrompt buffer. When the function returns, this
	/// parameter is set to the size of the requested value whether or not the function copies the value into the specified buffer. The
	/// size is returned as the number of <c>TCHAR</c> in the requested value, not including the terminating null character.
	/// </para>
	/// <para>This parameter can be set to <c>NULL</c> only if szDiskPrompt is also <c>NULL</c>, otherwise the function returns ERROR_INVALID_PARAMETER.</para>
	/// </param>
	/// <returns>
	/// <para>The <c>MsiSourceListEnumMediaDisks</c> function returns the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>
	/// The user does not have the ability to read the specified media source or the specified product or patch. This does not indicate
	/// whether a media source, product, or patch is found.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_BAD_CONFIGURATION</term>
	/// <term>The configuration data is corrupt.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>An invalid parameter is passed to the function.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NO_MORE_ITEMS</term>
	/// <term>There are no more disks registered for this product or patch.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SUCCESS</term>
	/// <term>The value is enumerated successfully.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNKNOWN_PATCH</term>
	/// <term>The patch is not found.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNKNOWN_PRODUCT</term>
	/// <term>The product is not found.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>The buffer that is provided is too small to contain the requested information.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_FUNCTION_FAILED</term>
	/// <term>Unexpected internal failure.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// When making multiple calls to <c>MsiSourceListEnumMediaDisks</c> to enumerate all the sources for a single product instance,
	/// each call must be made from the same thread.
	/// </para>
	/// <para>
	/// An administrator can enumerate per-user unmanaged and managed installations for themselves, per-machine installations, and
	/// per-user managed installations for any user. An administrator cannot enumerate per-user unmanaged installations for other users.
	/// Non-administrators can only enumerate their own per-user unmanaged and managed installations and per-machine installations.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msisourcelistenummediadisksa UINT MsiSourceListEnumMediaDisksA(
	// LPCSTR szProductCodeOrPatchCode, LPCSTR szUserSid, MSIINSTALLCONTEXT dwContext, DWORD dwOptions, DWORD dwIndex, LPDWORD
	// pdwDiskId, LPSTR szVolumeLabel, LPDWORD pcchVolumeLabel, LPSTR szDiskPrompt, LPDWORD pcchDiskPrompt );
	[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiSourceListEnumMediaDisksA")]
	public static extern Win32Error MsiSourceListEnumMediaDisks([MarshalAs(UnmanagedType.LPTStr)] string szProductCodeOrPatchCode,
		[MarshalAs(UnmanagedType.LPTStr)] string szUserSid, MSIINSTALLCONTEXT dwContext, MSICODE dwOptions, uint dwIndex,
		out uint pdwDiskId, [Out, Optional, MarshalAs(UnmanagedType.LPTStr)] StringBuilder szVolumeLabel, [In, Optional] IntPtr pcchVolumeLabel,
		[Out, Optional, MarshalAs(UnmanagedType.LPTStr)] StringBuilder szDiskPrompt, [In, Optional] IntPtr pcchDiskPrompt);

	/// <summary>The <c>MsiSourceListEnumSources</c> function enumerates the sources in the source list of a specified patch or product.</summary>
	/// <param name="szProductCodeOrPatchCode">
	/// The ProductCode or patch GUID of the product or patch. Use a null-terminated string. If the string is longer than 39 characters,
	/// the function fails and returns ERROR_INVALID_PARAMETER. This parameter cannot be <c>NULL</c>.
	/// </param>
	/// <param name="szUserSid">
	/// <para>
	/// A string SID that specifies the user account that contains the product or patch. The SID is not validated or resolved. An
	/// incorrect SID can return ERROR_UNKNOWN_PRODUCT or ERROR_UNKNOWN_PATCH. When referencing a machine context, szUserSID must be
	/// <c>NULL</c> and dwContext must be MSIINSTALLCONTEXT_MACHINE.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Type of SID</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>NULL</term>
	/// <term>
	/// A NULL indicates the current user who is logged on. When referencing the current user account, szUserSID can be NULL and
	/// dwContext can be MSIINSTALLCONTEXT_USERMANAGED or MSIINSTALLCONTEXT_USERUNMANAGED.
	/// </term>
	/// </item>
	/// <item>
	/// <term>User SID</term>
	/// <term>An enumeration for a specific user in the system. An example of a user SID is "S-1-3-64-2415071341-1358098788-3127455600-2561".</term>
	/// </item>
	/// <item>
	/// <term>s-1-1-0</term>
	/// <term>The special SID string s-1-1-0 (everyone) specifies enumeration across all users in the system.</term>
	/// </item>
	/// </list>
	/// <para>
	/// <c>Note</c> The special SID string s-1-5-18 (system) cannot be used to enumerate products or patches installed as per-machine.
	/// Setting the SID value to s-1-5-18 returns ERROR_INVALID_PARAMETER.
	/// </para>
	/// </param>
	/// <param name="dwContext">
	/// <para>The context of the product or patch instance. This parameter can contain one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Type of context</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MSIINSTALLCONTEXT_USERMANAGED</term>
	/// <term>The product or patch instance exists in the per-user-managed context.</term>
	/// </item>
	/// <item>
	/// <term>MSIINSTALLCONTEXT_USERUNMANAGED</term>
	/// <term>The product or patch instance exists in the per-user-unmanaged context.</term>
	/// </item>
	/// <item>
	/// <term>MSIINSTALLCONTEXT_MACHINE</term>
	/// <term>The product or patch instance exists in the per-machine context.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwOptions">
	/// <para>
	/// The dwOptions value determines the interpretation of the szProductCodeOrPatchCode value and the type of sources to clear. This
	/// parameter must be a combination of one of the following MSISOURCETYPE_* constants and one of the following MSICODE_* constants.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Flag</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MSISOURCETYPE_NETWORK</term>
	/// <term>The source is a network type.</term>
	/// </item>
	/// <item>
	/// <term>MSISOURCETYPE_URL</term>
	/// <term>The source is a URL type.</term>
	/// </item>
	/// <item>
	/// <term>MSICODE_PRODUCT</term>
	/// <term>szProductCodeOrPatchCode is a product code.</term>
	/// </item>
	/// <item>
	/// <term>MSICODE_PATCH</term>
	/// <term>szProductCodeOrPatchCode is a patch code.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwIndex">
	/// The index of the source to retrieve. This parameter must be 0 (zero) for the first call to the <c>MsiSourceListEnumSources</c>
	/// function, and then incremented for subsequent calls until the function returns ERROR_NO_MORE_ITEMS. The index should be
	/// incremented only if the previous call returned ERROR_SUCCESS.
	/// </param>
	/// <param name="szSource">
	/// <para>
	/// A pointer to a buffer that receives the path to the source that is being enumerated. This buffer should be large enough to
	/// contain the received value. If the buffer is too small, the function returns ERROR_MORE_DATA and sets *pcchSource to the number
	/// of <c>TCHAR</c> in the value, not including the terminating NULL character.
	/// </para>
	/// <para>
	/// If szSource is set to <c>NULL</c> and pcchSource is set to a valid pointer, the function returns ERROR_SUCCESS and sets
	/// *pcchSource to the number of <c>TCHAR</c> in the value, not including the terminating NULL character. The function can then be
	/// called again to retrieve the value, with szSource buffer large enough to contain *pcchSource + 1 characters.
	/// </para>
	/// <para>
	/// If szSource and pcchSource are both set to <c>NULL</c>, the function returns ERROR_SUCCESS if the value exists, without
	/// retrieving the value.
	/// </para>
	/// </param>
	/// <param name="pcchSource">
	/// <para>
	/// A pointer to a variable that specifies the number of <c>TCHAR</c> in the szSource buffer. When the function returns, this
	/// parameter is set to the size of the requested value whether or not the function copies the value into the specified buffer. The
	/// size is returned as the number of <c>TCHAR</c> in the requested value, not including the terminating null character.
	/// </para>
	/// <para>This parameter can be set to <c>NULL</c> only if szSource is also <c>NULL</c>, otherwise the function returns ERROR_INVALID_PARAMETER.</para>
	/// </param>
	/// <returns>
	/// <para>The <c>MsiSourceListEnumSources</c> function returns the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>
	/// The user does not have the ability to read the specified source list. This does not indicate whether a product or patch is found.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_BAD_CONFIGURATION</term>
	/// <term>The configuration data is corrupt.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>An invalid parameter is passed to the function.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>The provided buffer is not sufficient to contain the requested data.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_NO_MORE_ITEMS</term>
	/// <term>There are no more sources in the specified list to enumerate.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SUCCESS</term>
	/// <term>A source is enumerated successfully.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNKNOWN_PATCH</term>
	/// <term>The patch specified is not installed on the computer in the specified contexts.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNKNOWN_PRODUCT</term>
	/// <term>The product specified is not installed on the computer in the specified contexts.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_FUNCTION_FAILED</term>
	/// <term>Unexpected internal failure.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// When making multiple calls to <c>MsiSourceListEnumSources</c> to enumerate all sources for a single product instance, each call
	/// must be made from the same thread.
	/// </para>
	/// <para>
	/// An administrator can enumerate per-user unmanaged and managed installations for themselves, per-machine installations, and
	/// per-user managed installations for any user. An administrator cannot enumerate per-user unmanaged installations for other users.
	/// Non-administrators can only enumerate their own per-user unmanaged and managed installations and per-machine installations.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msisourcelistenumsourcesa UINT MsiSourceListEnumSourcesA( LPCSTR
	// szProductCodeOrPatchCode, LPCSTR szUserSid, MSIINSTALLCONTEXT dwContext, DWORD dwOptions, DWORD dwIndex, LPSTR szSource, LPDWORD
	// pcchSource );
	[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiSourceListEnumSourcesA")]
	public static extern Win32Error MsiSourceListEnumSources([MarshalAs(UnmanagedType.LPTStr)] string szProductCodeOrPatchCode,
		[Optional, MarshalAs(UnmanagedType.LPTStr)] string? szUserSid, MSIINSTALLCONTEXT dwContext, uint dwOptions, uint dwIndex,
		[Out, Optional, MarshalAs(UnmanagedType.LPTStr)] StringBuilder szSource, ref uint pcchSource);

	/// <summary>
	/// The <c>MsiSourceListForceResolution</c> function forces the installer to search the source list for a valid product source the
	/// next time a source is required. For example, when the installer performs an installation or reinstallation, or when it requires
	/// the path for a component that is set to run from source.
	/// </summary>
	/// <param name="szProduct">The ProductCode of the product to modify.</param>
	/// <param name="szUserName">
	/// <para>
	/// The user name for a per-user installation. The user name should always be in the format of DOMAIN\USERNAME (or
	/// MACHINENAME\USERNAME for a local user).
	/// </para>
	/// <para>An empty string or <c>NULL</c> for a per-machine installation.</para>
	/// </param>
	/// <param name="dwReserved">Reserved for future use. This value must be set to 0.</param>
	/// <returns>
	/// <para>The <c>MsiSourceListForceResolution</c> function returns the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>The caller does not have sufficient access to force resolution for the product.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_BAD_CONFIGURATION</term>
	/// <term>The configuration data is corrupt.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_BAD_USER_NAME</term>
	/// <term>The specified user is not a valid user.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_FUNCTION_FAILED</term>
	/// <term>The function could not complete.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSTALL_SERVICE_FAILURE</term>
	/// <term>The installation service could not be accessed.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>An invalid parameter was passed to the function.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SUCCESS</term>
	/// <term>The function succeeded.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNKNOWN_PRODUCT</term>
	/// <term>The specified product is unknown.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// An administrator can modify per-machine installations, their own per-user non-managed installations, and the per-user managed
	/// installations for any user. A non-administrator can only modify per-machine installations and their own (managed or non-managed)
	/// per-user installations.
	/// </para>
	/// <para>
	/// If the user name is an empty string or <c>NULL</c>, the function operates on the per-machine installation of the product. In
	/// this case, if the product is installed as per-user only, the function returns ERROR_UNKNOWN_PRODUCT.
	/// </para>
	/// <para>
	/// If the user name is not an empty string or <c>NULL</c>, it specifies the name of the user whose product installation is
	/// modified. If the user name is the current user name, the function first attempts to modify a non-managed installation of the
	/// product. If no non-managed installation of the product can be found, the function then tries to modify a managed per-user
	/// installation of the product. If no managed or unmanaged per-user installations of the product can be found, the function returns
	/// ERROR_UNKNOWN_PRODUCT, even if the product is installed per-machine.
	/// </para>
	/// <para>
	/// This function can not modify a non-managed installation for any user besides the current user. If the user name is not an empty
	/// string or <c>NULL</c>, but is not the current user, the function only checks for a managed per-user installation of the product
	/// for the specified user. If the product is not installed as managed per-user for the specified user, the function returns
	/// ERROR_UNKNOWN_PRODUCT, even if the product is installed per-machine.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msisourcelistforceresolutiona UINT MsiSourceListForceResolutionA(
	// LPCSTR szProduct, LPCSTR szUserName, DWORD dwReserved );
	[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiSourceListForceResolutionA")]
	public static extern Win32Error MsiSourceListForceResolution([MarshalAs(UnmanagedType.LPTStr)] string szProduct,
		[Optional, MarshalAs(UnmanagedType.LPTStr)] string? szUserName, uint dwReserved = 0);

	/// <summary>
	/// The <c>MsiSourceListForceResolutionEx</c> function removes the registration of the property called "LastUsedSource". This
	/// function does not affect the registered source list. Whenever the installer requires the source to reinstall a product or patch,
	/// it first tries the source registered as "LastUsedSource". If that fails, or if that registration is missing, the installer
	/// searches the other registered sources until it finds a valid source or until the list of sources is exhausted. Clearing the
	/// "LastUsedSource" registration forces the installer to do a source resolution against the registered sources the next time it
	/// requires the source.
	/// </summary>
	/// <param name="szProductCodeOrPatchCode">
	/// The ProductCode or patch GUID of the product or patch. Use a null-terminated string. If the string is longer than 39 characters,
	/// the function fails and returns ERROR_INVALID_PARAMETER. This parameter cannot be <c>NULL</c>.
	/// </param>
	/// <param name="szUserSid">
	/// This parameter can be a string SID that specifies the user account that contains the product or patch. The SID is not validated
	/// or resolved. An incorrect SID can return ERROR_UNKNOWN_PRODUCT or ERROR_UNKNOWN_PATCH. When referencing a machine context,
	/// szUserSID must be <c>NULL</c> and dwContext must be MSIINSTALLCONTEXT_MACHINE. Using the machine SID ("S-1-5-18") returns
	/// ERROR_INVALID PARAMETER. When referencing the current user account, szUserSID can be <c>NULL</c> and dwContext can be
	/// MSIINSTALLCONTEXT_USERMANAGED or MSIINSTALLCONTEXT_USERUNMANAGED.
	/// </param>
	/// <param name="dwContext">
	/// <para>
	/// This parameter specifies the context of the product or patch instance. This parameter can contain one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Type of context</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MSIINSTALLCONTEXT_USERMANAGED</term>
	/// <term>The product or patch instance exists in the per-user-managed context.</term>
	/// </item>
	/// <item>
	/// <term>MSIINSTALLCONTEXT_USERUNMANAGED</term>
	/// <term>The product or patch instance exists in the per-user-unmanaged context.</term>
	/// </item>
	/// <item>
	/// <term>MSIINSTALLCONTEXT_MACHINE</term>
	/// <term>The product or patch instance exists in the per-machine context.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwOptions">
	/// <para>The dwOptions value determines the interpretation of the szProductCodeOrPatchCode value .</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Flag</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MSICODE_PRODUCT</term>
	/// <term>szProductCodeOrPatchCode is a product code.</term>
	/// </item>
	/// <item>
	/// <term>MSICODE_PATCH</term>
	/// <term>szProductCodeOrPatchCode is a patch code.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>The <c>MsiSourceListForceResolutionEx</c> function returns the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>
	/// The user does not have the ability to modify the specified source list. Does not indicate whether the product or patch was found.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_BAD_CONFIGURATION</term>
	/// <term>The configuration data is corrupt.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSTALL_SERVICE_FAILURE</term>
	/// <term>Could not access the Windows Installer service</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>An invalid parameter was passed to the function.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SUCCESS</term>
	/// <term>The "LastUsedSource" registration was cleared.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNKNOWN_PATCH</term>
	/// <term>The patch was not found.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNKNOWN_PRODUCT</term>
	/// <term>The specified product or patch was not found.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_FUNCTION_FAILED</term>
	/// <term>Unexpected internal failure.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Administrators can modify the installation of a product or patch instance that exists under the machine context or under their
	/// own per-user context (managed or unmanaged.) They can modify the installation of a product or patch instance that exists under
	/// any user's per-user-managed context. Administrators cannot modify another user's installation of a product or patch instance
	/// that exists under that other user's per-user-unmanaged context.
	/// </para>
	/// <para>
	/// Non-administrators cannot modify the installation of a product or patch instance that exists under another user's per-user
	/// context (managed or unmanaged.) They can modify the installation of a product or patch instance that exists under their own
	/// per-user-unmanaged context. They can modify the installation of a product or patch instance under the machine context or their
	/// own per-user-managed context only if they are enabled to browse for a product or patch source. Users can be enabled to browse
	/// for sources by setting policy, for more information, see DisableBrowse, AllowLockdownBrowse, and AlwaysInstallElevated policies.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msisourcelistforceresolutionexa UINT
	// MsiSourceListForceResolutionExA( LPCSTR szProductCodeOrPatchCode, LPCSTR szUserSid, MSIINSTALLCONTEXT dwContext, DWORD dwOptions );
	[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiSourceListForceResolutionExA")]
	public static extern Win32Error MsiSourceListForceResolutionEx([MarshalAs(UnmanagedType.LPTStr)] string szProductCodeOrPatchCode,
		[Optional, MarshalAs(UnmanagedType.LPTStr)] string? szUserSid, MSIINSTALLCONTEXT dwContext, MSICODE dwOptions);

	/// <summary>
	/// The <c>MsiSourceListGetInfo</c> function retrieves information about the source list for a product or patch in a specific context.
	/// </summary>
	/// <param name="szProductCodeOrPatchCode">
	/// The ProductCode or patch GUID of the product or patch. Use a null-terminated string. If the string is longer than 39 characters,
	/// the function fails and returns ERROR_INVALID_PARAMETER. This parameter cannot be <c>NULL</c>.
	/// </param>
	/// <param name="szUserSid">
	/// <para>
	/// This parameter can be a string security identifier (SID) that specifies the user account that contains the product or patch. The
	/// SID is not validated or resolved. An incorrect SID can return ERROR_UNKNOWN_PRODUCT or ERROR_UNKNOWN_PATCH. When referencing a
	/// machine context, szUserSID must be <c>NULL</c> and dwContext must be MSIINSTALLCONTEXT_MACHINE.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Type of SID</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>NULL</term>
	/// <term>
	/// NULL denotes the currently logged on user. When referencing the current user account, szUserSID can be NULL and dwContext can be
	/// MSIINSTALLCONTEXT_USERMANAGED or MSIINSTALLCONTEXT_USERUNMANAGED.
	/// </term>
	/// </item>
	/// <item>
	/// <term>User SID</term>
	/// <term>Specifies enumeration for a specific user in the system. An example of a user SID is "S-1-3-64-2415071341-1358098788-3127455600-2561".</term>
	/// </item>
	/// </list>
	/// <para>
	/// <c>Note</c> The special SID string s-1-5-18 (system) cannot be used to enumerate products or patches installed as per-machine.
	/// Setting the SID value to s-1-5-18 returns ERROR_INVALID_PARAMETER.
	/// </para>
	/// <para>
	/// <c>Note</c> The special SID string s-1-1-0 (everyone) should not be used. Setting the SID value to s-1-1-0 fails and returns ERROR_INVALID_PARAM.
	/// </para>
	/// </param>
	/// <param name="dwContext">
	/// <para>
	/// This parameter specifies the context of the product or patch instance. This parameter can contain one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Type of context</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MSIINSTALLCONTEXT_USERMANAGED</term>
	/// <term>The product or patch instance exists in the per-user-managed context.</term>
	/// </item>
	/// <item>
	/// <term>MSIINSTALLCONTEXT_USERUNMANAGED</term>
	/// <term>The product or patch instance exists in the per-user-unmanaged context.</term>
	/// </item>
	/// <item>
	/// <term>MSIINSTALLCONTEXT_MACHINE</term>
	/// <term>The product or patch instance exists in the per-machine context.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwOptions">
	/// <para>The dwOptions value specifies the meaning of szProductCodeOrPatchCode.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Flag</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MSICODE_PRODUCT</term>
	/// <term>szProductCodeOrPatchCode is a product code GUID.</term>
	/// </item>
	/// <item>
	/// <term>MSICODE_PATCH</term>
	/// <term>szProductCodeOrPatchCode is a patch code GUID.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="szProperty">
	/// <para>
	/// A null-terminated string that specifies the property value to retrieve. The szProperty parameter can be one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Name</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>INSTALLPROPERTY_MEDIAPACKAGEPATH "MediaPackagePath"</term>
	/// <term>The path relative to the root of the installation media.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLPROPERTY_DISKPROMPT "DiskPrompt"</term>
	/// <term>The prompt template that is used when prompting the user for installation media.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLPROPERTY_LASTUSEDSOURCE "LastUsedSource"</term>
	/// <term>The most recently used source location for the product.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLPROPERTY_LASTUSEDTYPE "LastUsedType"</term>
	/// <term>
	/// An "n" if the last-used source is a network location. A "u" if the last used source is a URL location. An "m" if the last used
	/// source is media. An empty string ("") if there is no last used source.
	/// </term>
	/// </item>
	/// <item>
	/// <term>INSTALLPROPERTY_PACKAGENAME "PackageName"</term>
	/// <term>The name of the Windows Installer package or patch package on the source.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="szValue">
	/// <para>
	/// An output buffer that receives the information. This buffer should be large enough to contain the information. If the buffer is
	/// too small, the function returns ERROR_MORE_DATA and sets *pcchValue to the number of <c>TCHAR</c> in the value, not including
	/// the terminating NULL character.
	/// </para>
	/// <para>
	/// If the szValue is set to <c>NULL</c> and pcchValue is set to a valid pointer, the function returns ERROR_SUCCESS and sets
	/// *pcchValue to the number of <c>TCHAR</c> in the value, not including the terminating NULL character. The function can then be
	/// called again to retrieve the value, with szValue buffer large enough to contain *pcchValue + 1 characters.
	/// </para>
	/// <para>
	/// If szValue and pcchValue are both set to <c>NULL</c>, the function returns ERROR_SUCCESS if the value exists, without retrieving
	/// the value.
	/// </para>
	/// </param>
	/// <param name="pcchValue">
	/// <para>
	/// A pointer to a variable that specifies the number of <c>TCHAR</c> in the szValue buffer. When the function returns, this
	/// parameter is set to the size of the requested value whether or not the function copies the value into the specified buffer. The
	/// size is returned as the number of <c>TCHAR</c> in the requested value, not including the terminating null character.
	/// </para>
	/// <para>This parameter can be set to <c>NULL</c> only if szValue is also <c>NULL</c>, otherwise the function returns ERROR_INVALID_PARAMETER.</para>
	/// </param>
	/// <returns>
	/// <para>The <c>MsiSourceListGetInfo</c> function returns the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>
	/// The user does not have the ability to read the specified source list. This does not indicate whether a product or patch is found.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_BAD_CONFIGURATION</term>
	/// <term>The configuration data is corrupt.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>An invalid parameter is passed to the function.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>The provided buffer is not sufficient to contain the requested data.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SUCCESS</term>
	/// <term>The property is retrieved successfully.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNKNOWN_PATCH</term>
	/// <term>The patch is not found.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNKNOWN_PRODUCT</term>
	/// <term>The product is not found.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNKNOWN_PROPERTY</term>
	/// <term>The source property is not found.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_FUNCTION_FAILED</term>
	/// <term>An unexpected internal failure.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Administrators can modify the installation of a product or patch instance that exists under the machine context or under their
	/// own per-user context (managed or unmanaged.) They can modify the installation of a product or patch instance that exists under
	/// any user's per-user-managed context. Administrators cannot modify another user's installation of a product or patch instance
	/// that exists under that other user's per-user-unmanaged context.
	/// </para>
	/// <para>
	/// Non-administrators cannot modify the installation of a product or patch instance that exists under another user's per-user
	/// context (managed or unmanaged.) They can modify the installation of a product or patch instance that exists under their own
	/// per-user-unmanaged context. They can modify the installation of a product or patch instance under the machine context or their
	/// own per-user-managed context only if they are enabled to browse for a product or patch source. Users can be enabled to browse
	/// for sources by setting policy. For more information, see DisableBrowse, AllowLockdownBrowse, and AlwaysInstallElevated policies.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msisourcelistgetinfoa UINT MsiSourceListGetInfoA( LPCSTR
	// szProductCodeOrPatchCode, LPCSTR szUserSid, MSIINSTALLCONTEXT dwContext, DWORD dwOptions, LPCSTR szProperty, LPSTR szValue,
	// LPDWORD pcchValue );
	[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiSourceListGetInfoA")]
	public static extern Win32Error MsiSourceListGetInfo([MarshalAs(UnmanagedType.LPTStr)] string szProductCodeOrPatchCode,
		[Optional, MarshalAs(UnmanagedType.LPTStr)] string? szUserSid, MSIINSTALLCONTEXT dwContext, MSICODE dwOptions,
		[MarshalAs(UnmanagedType.LPTStr)] string szProperty, [Out, Optional, MarshalAs(UnmanagedType.LPTStr)] StringBuilder szValue, ref uint pcchValue);

	/// <summary>
	/// The <c>MsiSourceListSetInfo</c> function sets information about the source list for a product or patch in a specific context.
	/// </summary>
	/// <param name="szProductCodeOrPatchCode">
	/// The ProductCode or patch GUID of the product or patch. Use a null-terminated string. If the string is longer than 39 characters,
	/// the function fails and returns <c>ERROR_INVALID_PARAMETER</c>. This parameter cannot be <c>NULL</c>.
	/// </param>
	/// <param name="szUserSid">
	/// <para>
	/// This parameter can be a string SID that specifies the user account that contains the product or patch. The SID is not validated
	/// or resolved. An incorrect SID can return <c>ERROR_UNKNOWN_PRODUCT</c> or <c>ERROR_UNKNOWN_PATCH</c>. When referencing a machine
	/// context, szUserSID must be <c>NULL</c> and dwContext must be <c>MSIINSTALLCONTEXT_MACHINE</c>.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Type of SID</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>NULL</term>
	/// <term>
	/// NULL denotes the currently logged on user. When referencing the current user account, szUserSID can be NULL and dwContext can be
	/// MSIINSTALLCONTEXT_USERMANAGED or MSIINSTALLCONTEXT_USERUNMANAGED.
	/// </term>
	/// </item>
	/// <item>
	/// <term>User SID</term>
	/// <term>Specifies enumeration for a particular user in the system. An example of a user SID is "S-1-3-64-2415071341-1358098788-3127455600-2561".</term>
	/// </item>
	/// </list>
	/// <para>
	/// <c>Note</c> The special SID string "S-1-5-18" (system) cannot be used to enumerate products or patches installed as per-machine.
	/// Setting the SID value to "S-1-5-18" returns "ERROR_INVALID_PARAMETER".
	/// </para>
	/// <para>
	/// <c>Note</c> The special SID string "S-1-1-0" (everyone) should not be used. Setting the SID value to "S-1-1-0" fails and returns <c>ERROR_INVALID_PARAM</c>.
	/// </para>
	/// </param>
	/// <param name="dwContext">
	/// <para>
	/// This parameter specifies the context of the product or patch instance. This parameter can contain one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Type of context</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MSIINSTALLCONTEXT_USERMANAGED</term>
	/// <term>The product or patch instance exists in the per-user-managed context.</term>
	/// </item>
	/// <item>
	/// <term>MSIINSTALLCONTEXT_USERUNMANAGED</term>
	/// <term>The product or patch instance exists in the per-user-unmanaged context.</term>
	/// </item>
	/// <item>
	/// <term>MSIINSTALLCONTEXT_MACHINE</term>
	/// <term>The product or patch instance exists in the per-machine context.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwOptions">
	/// <para>The dwOptions value specifies the meaning of szProductCodeOrPatchCode.</para>
	/// <para>
	/// If the property being set is "LastUsedSource", this parameter also specifies the type of source as network or URL. In this case,
	/// the dwOptions parameter must be a combination of one of the following <c>MSISOURCETYPE_</c> constants and one of the following
	/// <c>MSICODE_</c> constants.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Flag</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>MSISOURCETYPE_NETWORK</term>
	/// <term>The source is a network type.</term>
	/// </item>
	/// <item>
	/// <term>MSISOURCETYPE_URL</term>
	/// <term>The source is a URL type.</term>
	/// </item>
	/// <item>
	/// <term>MSICODE_PRODUCT</term>
	/// <term>szProductCodeOrPatchCode is a product code GUID.</term>
	/// </item>
	/// <item>
	/// <term>MSICODE_PATCH</term>
	/// <term>szProductCodeOrPatchCode is a patch code GUID.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="szProperty">
	/// <para>
	/// The parameter szProperty indicates the property value to set. Not all properties that can be retrieved through
	/// MsiSourceListGetInfo can be set via a call to <c>MsiSourceListSetInfo</c>. The szProperty value can be one of the following values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Name</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>INSTALLPROPERTY_MEDIAPACKAGEPATH "MediaPackagePath"</term>
	/// <term>The path relative to the root of the installation media.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLPROPERTY_DISKPROMPT "DiskPrompt"</term>
	/// <term>The prompt template used when prompting the user for installation media.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLPROPERTY_LASTUSEDSOURCE "LastUsedSource"</term>
	/// <term>
	/// The most recently used source location for the product. If the source is not registered, the function calls
	/// MsiSourceListAddSourceEx to register it. On successful registration, the function sets the source as the LastUsedSource.
	/// </term>
	/// </item>
	/// <item>
	/// <term>INSTALLPROPERTY_PACKAGENAME "PackageName"</term>
	/// <term>The name of the Windows Installer package or patch package on the source.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="szValue">
	/// The new value of the property. No validation of the new value is performed. This value cannot be <c>NULL</c>. It can be an empty string.
	/// </param>
	/// <returns>
	/// <para>The <c>MsiSourceListSetInfo</c> function returns the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_ACCESS_DENIED</term>
	/// <term>The user does not have the ability to set the source list for the specified product.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_BAD_CONFIGURATION</term>
	/// <term>The configuration data is corrupt.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSTALL_SERVICE_FAILURE</term>
	/// <term>The Windows Installer service could not be accessed.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>An invalid parameter was passed to the function.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SUCCESS</term>
	/// <term>The property was set.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNKNOWN_PATCH</term>
	/// <term>The patch was not found.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNKNOWN_PRODUCT</term>
	/// <term>The product was not found.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_UNKNOWN_PROPERTY</term>
	/// <term>The source property was not found.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_FUNCTION_FAILED</term>
	/// <term>Unexpected internal failure.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Administrators can modify the installation of a product or patch instance that exists under the machine context or under their
	/// own per-user context (managed or unmanaged.) They can modify the installation of a product or patch instance that exists under
	/// any user's per-user-managed context. Administrators cannot modify another user's installation of a product or patch instance
	/// that exists under that other user's per-user-unmanaged context.
	/// </para>
	/// <para>
	/// Non-administrators cannot modify the installation of a product or patch instance that exists under another user's per-user
	/// context (managed or unmanaged.) They can modify the installation of a product or patch instance that exists under their own
	/// per-user-unmanaged context. They can modify the installation of a product or patch instance under the machine context or their
	/// own per-user-managed context only if they are enabled to browse for a product or patch source. Users can be enabled to browse
	/// for sources by setting policy. For more information, see the DisableBrowse, AllowLockdownBrowse, and AlwaysInstallElevated policies.
	/// </para>
	/// <para>
	/// An exception to the above rule is setting "LastUsedSource" to one of the registered sources. If the source is already
	/// registered, a non-administrator can set "LastUsedSource" to their own installations (managed or non-managed) and per-machine
	/// installations, irrespective of policies.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msisourcelistsetinfoa UINT MsiSourceListSetInfoA( LPCSTR
	// szProductCodeOrPatchCode, LPCSTR szUserSid, MSIINSTALLCONTEXT dwContext, DWORD dwOptions, LPCSTR szProperty, LPCSTR szValue );
	[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiSourceListSetInfoA")]
	public static extern Win32Error MsiSourceListSetInfo([MarshalAs(UnmanagedType.LPTStr)] string szProductCodeOrPatchCode,
		[Optional, MarshalAs(UnmanagedType.LPTStr)] string? szUserSid, MSIINSTALLCONTEXT dwContext, uint dwOptions,
		[MarshalAs(UnmanagedType.LPTStr)] string szProperty, [MarshalAs(UnmanagedType.LPTStr)] string szValue);

	/// <summary>
	/// The <c>MsiUseFeature</c> function increments the usage count for a particular feature and indicates the installation state for
	/// that feature. This function should be used to indicate an application's intent to use a feature.
	/// </summary>
	/// <param name="szProduct">Specifies the product code for the product that owns the feature to be used.</param>
	/// <param name="szFeature">Identifies the feature to be used.</param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>INSTALLSTATE_ABSENT</term>
	/// <term>The feature is not installed.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLSTATE_ADVERTISED</term>
	/// <term>The feature is advertised</term>
	/// </item>
	/// <item>
	/// <term>INSTALLSTATE_BADCONFIG</term>
	/// <term>The configuration data is corrupt.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLSTATE_INVALIDARG</term>
	/// <term>Invalid function argument.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLSTATE_LOCAL</term>
	/// <term>The feature is locally installed and available for use.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLSTATE_SOURCE</term>
	/// <term>The feature is installed from the source and available for use.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLSTATE_UNKNOWN</term>
	/// <term>The feature is not published.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// The <c>MsiUseFeature</c> function should only be used on features known to be published. INSTALLSTATE_UNKNOWN indicates that the
	/// program is trying to use a feature that is not published. The application should determine whether the feature is published
	/// before calling <c>MsiUseFeature</c> by calling MsiQueryFeatureState or MsiEnumFeatures. The application should make these calls
	/// while it initializes. An application should only use features that are known to be published.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msiusefeaturea INSTALLSTATE MsiUseFeatureA( LPCSTR szProduct,
	// LPCSTR szFeature );
	[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiUseFeatureA")]
	public static extern INSTALLSTATE MsiUseFeature([MarshalAs(UnmanagedType.LPTStr)] string szProduct,
		[MarshalAs(UnmanagedType.LPTStr)] string szFeature);

	/// <summary>
	/// The <c>MsiUseFeatureEx</c> function increments the usage count for a particular feature and indicates the installation state for
	/// that feature. This function should be used to indicate an application's intent to use a feature.
	/// </summary>
	/// <param name="szProduct">Specifies the product code for the product that owns the feature to be used.</param>
	/// <param name="szFeature">Identifies the feature to be used.</param>
	/// <param name="dwInstallMode">
	/// <para>This parameter can have the following value.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>INSTALLMODE_NODETECTION</term>
	/// <term>Return value indicates the installation state.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwReserved">Reserved for future use. This value must be set to 0.</param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>INSTALLSTATE_ABSENT</term>
	/// <term>The feature is not installed.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLSTATE_ADVERTISED</term>
	/// <term>The feature is advertised</term>
	/// </item>
	/// <item>
	/// <term>INSTALLSTATE_LOCAL</term>
	/// <term>The feature is locally installed and available for use.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLSTATE_SOURCE</term>
	/// <term>The feature is installed from the source and available for use.</term>
	/// </item>
	/// <item>
	/// <term>INSTALLSTATE_UNKNOWN</term>
	/// <term>The feature is not published.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// The <c>MsiUseFeatureEx</c> function should only be used on features known to be published. INSTALLSTATE_UNKNOWN indicates that
	/// the program is trying to use a feature that is not published. The application should determine whether the feature is published
	/// before calling MsiUseFeature by calling MsiQueryFeatureState or MsiEnumFeatures. The application should make these calls while
	/// it initializes. An application should only use features that are known to be published.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msiusefeatureexa INSTALLSTATE MsiUseFeatureExA( LPCSTR szProduct,
	// LPCSTR szFeature, DWORD dwInstallMode, DWORD dwReserved );
	[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiUseFeatureExA")]
	public static extern INSTALLSTATE MsiUseFeatureEx([MarshalAs(UnmanagedType.LPTStr)] string szProduct,
		[MarshalAs(UnmanagedType.LPTStr)] string szFeature, INSTALLMODE dwInstallMode, uint dwReserved = 0);

	/// <summary>The <c>MsiVerifyPackage</c> function verifies that the given file is an installation package.</summary>
	/// <param name="szPackagePath">Specifies the path and file name of the package.</param>
	/// <returns>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_INSTALL_PACKAGE_INVALID</term>
	/// <term>The file is not a valid package.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INSTALL_PACKAGE_OPEN_FAILED</term>
	/// <term>The file could not be opened.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_INVALID_PARAMETER</term>
	/// <term>The parameter is not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_SUCCESS</term>
	/// <term>The file is a package.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks/>
	// https://docs.microsoft.com/en-us/windows/win32/api/msi/nf-msi-msiverifypackagew UINT MsiVerifyPackageW( LPCWSTR szPackagePath );
	[DllImport(Lib_Msi, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("msi.h", MSDNShortId = "NF:msi.MsiVerifyPackageW")]
	public static extern Win32Error MsiVerifyPackage([MarshalAs(UnmanagedType.LPTStr)] string szPackagePath);
}