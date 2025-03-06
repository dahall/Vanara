using Microsoft.Win32.SafeHandles;
using System.Linq;
using static Vanara.PInvoke.AdvApi32;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke;

/// <summary>Functions and interfaces from UserEnv.dll.</summary>
public static partial class UserEnv
{
	/// <summary>Specifies the link information for the GPO.</summary>
	[PInvokeData("userenv.h", MSDNShortId = "7275a3cd-6b19-4eb9-9481-b73bd5af5753")]
	public enum GPO_LINK
	{
		/// <summary>No link information is available.</summary>
		GPLinkUnknown = 0,

		/// <summary>The GPO is linked to a computer (local or remote).</summary>
		GPLinkMachine,

		/// <summary>The GPO is linked to a site.</summary>
		GPLinkSite,

		/// <summary>The GPO is linked to a domain.</summary>
		GPLinkDomain,

		/// <summary>The GPO is linked to an organizational unit.</summary>
		GPLinkOrganizationalUnit
	}

	/// <summary>Flags used when getting GPO info.</summary>
	[PInvokeData("userenv.h")]
	[Flags]
	public enum GPO_LIST_FLAG
	{
		/// <summary>The gpo list flag machine</summary>
		GPO_LIST_FLAG_MACHINE = 0x00000001,

		/// <summary>The gpo list flag siteonly</summary>
		GPO_LIST_FLAG_SITEONLY = 0x00000002,

		/// <summary>Ignore WMI filters when filtering GPO's</summary>
		GPO_LIST_FLAG_NO_WMIFILTERS = 0x00000004,

		/// <summary>Ignore security filters</summary>
		GPO_LIST_FLAG_NO_SECURITYFILTERS = 0x00000008
	}

	/// <summary>Flags for <see cref="PROFILEINFO"/>.</summary>
	[PInvokeData("profinfo.h", MSDNShortId = "09dae38c-3b2b-4f12-9c1e-90737cf0c7cc")]
	[Flags]
	public enum ProfileInfoFlags : uint
	{
		/// <summary>Prevents the display of profile error messages.</summary>
		PI_NOUI = 0x00000001,

		/// <summary>Not supported.</summary>
		PI_APPLYPOLICY = 0x00000002,
	}

	/// <summary>Profile type flags.</summary>
	[PInvokeData("userenv.h", MSDNShortId = "55ee76c8-1735-43eb-a98e-9e6c87ee1ba7")]
	[Flags]
	public enum ProfileType
	{
		/// <summary>The user has a Temporary User Profiles; it will be deleted at logoff.</summary>
		PT_TEMPORARY = 0x00000001,

		/// <summary>The user has a Roaming User Profiles.</summary>
		PT_ROAMING = 0x00000002,

		/// <summary>The user has a Mandatory User Profiles.</summary>
		PT_MANDATORY = 0x00000004,

		/// <summary>
		/// The user has a Roaming User Profile that was created on another PC and is being downloaded. This profile type implies <c>PT_ROAMING</c>.
		/// </summary>
		PT_ROAMING_PREEXISTING = 0x00000008,
	}

	/// <summary>Options for <see cref="RefreshPolicyEx"/>.</summary>
	[PInvokeData("userenv.h", MSDNShortId = "905ab96b-a7f2-4bb4-a539-385f78284644")]
	[Flags]
	public enum RefreshPolicyOption : uint
	{
		/// <summary>Reapply all policies even if no policy change was detected.</summary>
		RP_FORCE = 1,

		/// <summary>The call does not return till the time policy processing is completed.</summary>
		RP_SYNC = 2
	}

	/// <summary>Creates a per-user, per-app profile for Windows Store apps.</summary>
	/// <param name="pszAppContainerName">
	/// The name of the app container. To ensure uniqueness, it is recommended that this string contains the app name as well as the
	/// publisher. This string can be up to 64 characters in length. Further, it must fit into the pattern described by the regular
	/// expression "[-_. A-Za-z0-9]+".
	/// </param>
	/// <param name="pszDisplayName">The display name. This string can be up to 512 characters in length.</param>
	/// <param name="pszDescription">A description for the app container. This string can be up to 2048 characters in length.</param>
	/// <param name="pCapabilities">The SIDs that define the requested capabilities.</param>
	/// <param name="dwCapabilityCount">The number of SIDs in pCapabilities.</param>
	/// <param name="ppSidAppContainerSid">The SID for the profile.</param>
	/// <returns>
	/// <para>If this function succeeds, it returns a standard HRESULT code, including the following:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>The data store was created successfully.</term>
	/// </item>
	/// <item>
	/// <term>E_ACCESSDENIED</term>
	/// <term>The caller does not have permission to create the profile.</term>
	/// </item>
	/// <item>
	/// <term>HRESULT_FROM_WIN32(ERROR_ALREADY_EXISTS)</term>
	/// <term>The application data store already exists.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>
	/// The container name is NULL, or the container name, the display name, or the description strings exceed their specified
	/// respective limits for length.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// A profile contains folders and registry storage that are per-user and per-app. The folders have ACLs that prevent them from
	/// being accessed by other users and apps. These folders can be accessed by calling SHGetKnownFolderPath.
	/// </para>
	/// <para>
	/// The function creates a profile for the current user. To create a profile on behalf of another user, you must impersonate that
	/// user. To create profiles for multiple users of the same app, you must call <c>CreateAppContainerProfile</c> for each user.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/userenv/nf-userenv-createappcontainerprofile USERENVAPI HRESULT
	// CreateAppContainerProfile( PCWSTR pszAppContainerName, PCWSTR pszDisplayName, PCWSTR pszDescription, PSID_AND_ATTRIBUTES
	// pCapabilities, DWORD dwCapabilityCount, PSID *ppSidAppContainerSid );
	[DllImport(Lib.Userenv, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("userenv.h", MSDNShortId = "73F5F30F-4083-4D33-B181-31B782AD40D6")]
	public static extern HRESULT CreateAppContainerProfile([MarshalAs(UnmanagedType.LPWStr)] string pszAppContainerName, [MarshalAs(UnmanagedType.LPWStr)] string pszDisplayName,
		[MarshalAs(UnmanagedType.LPWStr)] string pszDescription, [In] SID_AND_ATTRIBUTES[]? pCapabilities, uint dwCapabilityCount, out SafeAllocatedSID ppSidAppContainerSid);

	/// <summary>
	/// Retrieves the environment variables for the specified user. This block can then be passed to the CreateProcessAsUser function.
	/// </summary>
	/// <param name="lpEnvironment">
	/// <para>Type: <c>LPVOID*</c></para>
	/// <para>When this function returns, receives an array of strings.</para>
	/// </param>
	/// <param name="hToken">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>
	/// Token for the user, returned from the LogonUser function. If this is a primary token, the token must have <c>TOKEN_QUERY</c> and
	/// <c>TOKEN_DUPLICATE</c> access. If the token is an impersonation token, it must have <c>TOKEN_QUERY</c> access. For more
	/// information, see Access Rights for Access-Token Objects.
	/// </para>
	/// <para>If this parameter is <c>NULL</c>, the returned environment block contains system variables only.</para>
	/// </param>
	/// <param name="bInherit">
	/// <para>Type: <c>BOOL</c></para>
	/// <para>
	/// Specifies whether to inherit from the current process' environment. If this value is <c>TRUE</c>, the process inherits the
	/// current process' environment. If this value is <c>FALSE</c>, the process does not inherit the current process' environment.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para><c>TRUE</c> if successful; otherwise, <c>FALSE</c>. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// If the environment block is passed to CreateProcessAsUser, you must also specify the <c>CREATE_UNICODE_ENVIRONMENT</c> flag.
	/// After <c>CreateProcessAsUser</c> has returned, the new process has a copy of the environment block.
	/// </para>
	/// <para>
	/// User-specific environment variables such as %USERPROFILE% are set only when the user's profile is loaded. To load a user's
	/// profile, call the LoadUserProfile function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/userenv/nf-userenv-createenvironmentblock BOOL CreateEnvironmentBlock( LPVOID
	// *lpEnvironment, HANDLE hToken, BOOL bInherit );
	[DllImport(Lib.Userenv, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("userenv.h", MSDNShortId = "bda8879d-d33a-48f4-8b08-e3a279126a07")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CreateEnvironmentBlock([MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(EnvBlockMarshaler))] out string[] lpEnvironment,
		[Optional] HTOKEN hToken, [MarshalAs(UnmanagedType.Bool)] bool bInherit);

	/// <summary>
	/// Retrieves the environment variables for the specified user. This block can then be passed to the CreateProcessAsUser function.
	/// </summary>
	/// <param name="lpEnvironment">
	/// <para>Type: <c>LPVOID*</c></para>
	/// <para>
	/// When this function returns, receives a pointer to the new environment block. The environment block is an array of
	/// null-terminated Unicode strings. The list ends with two nulls (\0\0).
	/// </para>
	/// </param>
	/// <param name="hToken">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>
	/// Token for the user, returned from the LogonUser function. If this is a primary token, the token must have <c>TOKEN_QUERY</c> and
	/// <c>TOKEN_DUPLICATE</c> access. If the token is an impersonation token, it must have <c>TOKEN_QUERY</c> access. For more
	/// information, see Access Rights for Access-Token Objects.
	/// </para>
	/// <para>If this parameter is <c>NULL</c>, the returned environment block contains system variables only.</para>
	/// </param>
	/// <param name="bInherit">
	/// <para>Type: <c>BOOL</c></para>
	/// <para>
	/// Specifies whether to inherit from the current process' environment. If this value is <c>TRUE</c>, the process inherits the
	/// current process' environment. If this value is <c>FALSE</c>, the process does not inherit the current process' environment.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para><c>TRUE</c> if successful; otherwise, <c>FALSE</c>. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>To free the buffer when you have finished with the environment block, call the DestroyEnvironmentBlock function.</para>
	/// <para>
	/// If the environment block is passed to CreateProcessAsUser, you must also specify the <c>CREATE_UNICODE_ENVIRONMENT</c> flag.
	/// After <c>CreateProcessAsUser</c> has returned, the new process has a copy of the environment block, and DestroyEnvironmentBlock
	/// can be safely called.
	/// </para>
	/// <para>
	/// User-specific environment variables such as %USERPROFILE% are set only when the user's profile is loaded. To load a user's
	/// profile, call the LoadUserProfile function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/userenv/nf-userenv-createenvironmentblock BOOL CreateEnvironmentBlock( LPVOID
	// *lpEnvironment, HANDLE hToken, BOOL bInherit );
	[DllImport(Lib.Userenv, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("userenv.h", MSDNShortId = "bda8879d-d33a-48f4-8b08-e3a279126a07")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CreateEnvironmentBlock(out IntPtr lpEnvironment, [Optional] HTOKEN hToken, [MarshalAs(UnmanagedType.Bool)] bool bInherit);

	/// <summary>Creates a new user profile.</summary>
	/// <param name="pszUserSid">
	/// <para>Type: <c>LPCWSTR</c></para>
	/// <para>Pointer to the SID of the user as a string.</para>
	/// </param>
	/// <param name="pszUserName">
	/// <para>Type: <c>LPCWSTR</c></para>
	/// <para>The user name of the new user. This name is used as the base name for the profile directory.</para>
	/// </param>
	/// <param name="pszProfilePath">
	/// <para>Type: <c>LPWSTR</c></para>
	/// <para>When this function returns, contains a pointer to the full path of the profile.</para>
	/// </param>
	/// <param name="cchProfilePath">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>Size of the buffer pointed to by pszProfilePath, in characters.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>Returns S_OK if successful, or an error value otherwise, including the following:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_ACCESSDENIED</term>
	/// <term>The caller does not have a sufficient permission level to create the profile.</term>
	/// </item>
	/// <item>
	/// <term>HRESULT_FROM_WIN32(ERROR_ALREADY_EXISTS)</term>
	/// <term>A profile already exists for the specified user.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>The caller must have administrator privileges to call this function.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/userenv/nf-userenv-createprofile USERENVAPI HRESULT CreateProfile( LPCWSTR
	// pszUserSid, LPCWSTR pszUserName, LPWSTR pszProfilePath, DWORD cchProfilePath );
	[DllImport(Lib.Userenv, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("userenv.h", MSDNShortId = "cab9e20b-d94c-42e5-ada9-27194f398bb3")]
	public static extern HRESULT CreateProfile([MarshalAs(UnmanagedType.LPWStr)] string pszUserSid, [MarshalAs(UnmanagedType.LPWStr)] string pszUserName,
		[MarshalAs(UnmanagedType.LPWStr)] StringBuilder pszProfilePath, uint cchProfilePath);

	/// <summary>Deletes the specified per-user, per-app profile.</summary>
	/// <param name="pszAppContainerName">
	/// The name given to the profile in the call to the CreateAppContainerProfile function. This string is at most 64 characters in
	/// length, and fits into the pattern described by the regular expression "[-_. A-Za-z0-9]+".
	/// </param>
	/// <returns>
	/// <para>If this function succeeds, it returns a standard HRESULT code, including the following:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>HRESULT_FROM_WIN32(ERROR_NOT_SUPPORTED)</term>
	/// <term>If the method is called from within an app container.</term>
	/// </item>
	/// <item>
	/// <term>S_OK</term>
	/// <term>The profile was deleted successfully.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>If the container name is NULL, or if it exceeds its specified limit for length.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// To ensure the best results, close all file handles in the profile storage locations before calling the
	/// <c>DeleteAppContainerProfile</c> function. Otherwise, this function may not be able to completely remove the storage locations
	/// for the profile.
	/// </para>
	/// <para>
	/// This function deletes the profile for the current user. To delete the profile for another user, you must impersonate that user.
	/// </para>
	/// <para>
	/// If the function fails, the status of the profile is undetermined, and you should call <c>DeleteAppContainerProfile</c> again to
	/// complete the operation.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/userenv/nf-userenv-deleteappcontainerprofile USERENVAPI HRESULT
	// DeleteAppContainerProfile( PCWSTR pszAppContainerName );
	[DllImport(Lib.Userenv, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("userenv.h", MSDNShortId = "ED79D661-D087-4E44-8C32-14705ACA9D40")]
	public static extern HRESULT DeleteAppContainerProfile([MarshalAs(UnmanagedType.LPWStr)] string pszAppContainerName);

	/// <summary>
	/// Deletes the user profile and all user-related settings from the specified computer. The caller must have administrative
	/// privileges to delete a user's profile.
	/// </summary>
	/// <param name="lpSidString">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>Pointer to a string that specifies the user SID.</para>
	/// </param>
	/// <param name="lpProfilePath">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>
	/// Pointer to a string that specifies the profile path. If this parameter is <c>NULL</c>, the function obtains the path from the registry.
	/// </para>
	/// </param>
	/// <param name="lpComputerName">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>
	/// Pointer to a string that specifies the name of the computer from which the profile is to be deleted. If this parameter is
	/// <c>NULL</c>, the local computer name is used.
	/// </para>
	/// <para>
	/// <c>Note</c> As of Windows Vista, this parameter must be <c>NULL</c>. If it is not, this function fails with the error code ERROR_INVALID_PARAMETER.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para><c>TRUE</c> if successful; otherwise, <c>FALSE</c>. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <c>DeleteProfile</c> might fail when passed the security identifier (SID) of the local system account (S-1-5-18). For more
	/// information, see KB890212.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/userenv/nf-userenv-deleteprofilea USERENVAPI BOOL DeleteProfileA( LPCSTR
	// lpSidString, LPCSTR lpProfilePath, LPCSTR lpComputerName );
	[DllImport(Lib.Userenv, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("userenv.h", MSDNShortId = "48a08d9a-4fdc-43ab-8323-c49bc2d0a58d")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DeleteProfile(string lpSidString, [Optional] string? lpProfilePath, [Optional] string? lpComputerName);

	/// <summary>Gets the SID of the specified profile.</summary>
	/// <param name="pszAppContainerName">The name of the profile.</param>
	/// <param name="ppsidAppContainerSid">The SID for the profile.</param>
	/// <returns>
	/// <para>This function can return one of these values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>The operation completed successfully.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>The pszAppContainerName parameter, or the ppsidAppContainerSid parameter is either NULL or not valid.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/userenv/nf-userenv-deriveappcontainersidfromappcontainername USERENVAPI
	// HRESULT DeriveAppContainerSidFromAppContainerName( PCWSTR pszAppContainerName, PSID *ppsidAppContainerSid );
	[DllImport(Lib.Userenv, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("userenv.h", MSDNShortId = "233EFA95-289D-4D55-9D56-0630C015ABC7")]
	public static extern HRESULT DeriveAppContainerSidFromAppContainerName([MarshalAs(UnmanagedType.LPWStr)] string pszAppContainerName, out SafeAllocatedSID ppsidAppContainerSid);

	/// <summary>Frees environment variables created by the CreateEnvironmentBlock function.</summary>
	/// <param name="lpEnvironment">
	/// <para>Type: <c>LPVOID</c></para>
	/// <para>
	/// Pointer to the environment block created by CreateEnvironmentBlock. The environment block is an array of null-terminated Unicode
	/// strings. The list ends with two nulls (\0\0).
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para><c>TRUE</c> if successful; otherwise, <c>FALSE</c>. To get extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/userenv/nf-userenv-destroyenvironmentblock BOOL DestroyEnvironmentBlock(
	// LPVOID lpEnvironment );
	[DllImport(Lib.Userenv, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("userenv.h", MSDNShortId = "8d03e102-3f8a-4aa7-b175-0a6781eedea7")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DestroyEnvironmentBlock(IntPtr lpEnvironment);

	/// <summary>
	/// The <c>EnterCriticalPolicySection</c> function pauses the application of policy to allow applications to safely read policy
	/// settings. Applications call this function if they read multiple policy entries and must ensure that the settings are not changed
	/// while they are being read. This mutex protects Group Policy processing for all client-side extensions stored in a Group Policy
	/// Object (GPO).
	/// </summary>
	/// <param name="bMachine">
	/// A value that specifies whether to stop the application of computer policy or user policy. If this value is <c>TRUE</c>, the
	/// system stops applying computer policy. If this value is <c>FALSE</c>, the system stops applying user policy.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is a handle to a policy section.</para>
	/// <para>If the function fails, the return value is <c>NULL</c>. To get extended error information, call the GetLastError function.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The maximum amount of time an application can hold a critical section is 10 minutes. After 10 minutes, the system releases the
	/// critical section and policy can be applied again.
	/// </para>
	/// <para>
	/// To acquire both the computer and user critical section objects, acquire the user critical section object before acquiring the
	/// computer critical section object. This will help prevent a deadlock situation.
	/// </para>
	/// <para>
	/// To close the handle, call the LeaveCriticalPolicySection function. The policy section handle cannot be used in any other Windows functions.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/userenv/nf-userenv-entercriticalpolicysection USERENVAPI HANDLE
	// EnterCriticalPolicySection( BOOL bMachine );
	[DllImport(Lib.Userenv, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("userenv.h", MSDNShortId = "d17578b3-3a71-456b-97ca-961b81572528")]
	public static extern SafeCriticalPolicySectionHandle EnterCriticalPolicySection([MarshalAs(UnmanagedType.Bool)] bool bMachine);

	/// <summary>Expands the source string by using the environment block established for the specified user.</summary>
	/// <param name="hToken">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>
	/// Token for the user, returned from the LogonUser, CreateRestrictedToken, DuplicateToken, OpenProcessToken, or OpenThreadToken
	/// function. The token must have TOKEN_IMPERSONATE and TOKEN_QUERY access. In addition, as of Windows 7 the token must also have
	/// TOKEN_DUPLICATE access. For more information, see Access Rights for Access-Token Objects.
	/// </para>
	/// <para>If hToken is <c>NULL</c>, the environment block contains system variables only.</para>
	/// </param>
	/// <param name="lpSrc">
	/// <para>Type: <c>LPCTSTR</c></para>
	/// <para>Pointer to the null-terminated source string to be expanded.</para>
	/// </param>
	/// <param name="lpDest">
	/// <para>Type: <c>LPTSTR</c></para>
	/// <para>Pointer to a buffer that receives the expanded strings.</para>
	/// </param>
	/// <param name="dwSize">
	/// <para>Type: <c>DWORD</c></para>
	/// <para>Specifies the size of the lpDest buffer, in <c>TCHARs</c>.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para><c>TRUE</c> if successful; otherwise, <c>FALSE</c>. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>The following is an example source string:</para>
	/// <para>When <c>ExpandEnvironmentStringsForUser</c> returns, the destination string expands as follows:</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/userenv/nf-userenv-expandenvironmentstringsforusera USERENVAPI BOOL
	// ExpandEnvironmentStringsForUserA( HANDLE hToken, LPCSTR lpSrc, LPSTR lpDest, DWORD dwSize );
	[DllImport(Lib.Userenv, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("userenv.h", MSDNShortId = "d32fa6c8-035a-4c84-b210-5366f21b6c17")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool ExpandEnvironmentStringsForUser([Optional] HTOKEN hToken, string lpSrc, StringBuilder lpDest, uint dwSize);

	/// <summary>The <c>FreeGPOList</c> function frees the specified list of GPOs.</summary>
	/// <param name="pGPOList">
	/// A pointer to the list of GPO structures. This list is returned by the GetGPOList or GetAppliedGPOList function. For more
	/// information, see GROUP_POLICY_OBJECT.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/userenv/nf-userenv-freegpolista USERENVAPI BOOL FreeGPOListA(
	// PGROUP_POLICY_OBJECTA pGPOList );
	[DllImport(Lib.Userenv, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("userenv.h", MSDNShortId = "96bd2b5b-c088-4eea-bbc2-31d83c13aa99")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool FreeGPOList(IntPtr pGPOList);

	/// <summary>Retrieves the path to the root of the directory that contains program data shared by all users.</summary>
	/// <param name="lpProfileDir">
	/// <para>Type: <c>LPTSTR</c></para>
	/// <para>
	/// A pointer to a buffer that, when this function returns successfully, receives the path. Set this value to <c>NULL</c> to
	/// determine the required size of the buffer, including the terminating null character.
	/// </para>
	/// </param>
	/// <param name="lpcchSize">
	/// <para>Type: <c>LPDWORD</c></para>
	/// <para>A pointer to the size of the lpProfileDir buffer, in <c>TCHARs</c>.</para>
	/// <para>
	/// If the buffer specified by lpProfileDir is not large enough or lpProfileDir is <c>NULL</c>, the function fails and this
	/// parameter receives the necessary buffer size, including the terminating null character.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para><c>TRUE</c> if successful; otherwise, <c>FALSE</c>. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>The following is an example of the path returned by <c>GetAllUsersProfileDirectory</c> in Windows XP:</para>
	/// <para>The following is an example of the path returned by <c>GetAllUsersProfileDirectory</c> in Windows 7:</para>
	/// <para>
	/// To obtain the paths of subdirectories of this directory, use the SHGetFolderPath (Windows XP and earlier) or
	/// SHGetKnownFolderPath (Windows Vista) function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/userenv/nf-userenv-getallusersprofiledirectorya USERENVAPI BOOL
	// GetAllUsersProfileDirectoryA( LPSTR lpProfileDir, LPDWORD lpcchSize );
	[DllImport(Lib.Userenv, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("userenv.h", MSDNShortId = "bd08947a-df57-4dd9-b9ba-a01b315bfdf1")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetAllUsersProfileDirectory(StringBuilder? lpProfileDir, ref uint lpcchSize);

	/// <summary>Gets the path of the local app data folder for the specified app container.</summary>
	/// <param name="pszAppContainerSid">A pointer to the SID of the app container.</param>
	/// <param name="ppszPath">
	/// The address of a pointer to a string that, when this function returns successfully, receives the path of the local folder.
	/// </param>
	/// <returns>
	/// <para>This function returns an <c>HRESULT</c> code, including but not limited to the following:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>The operation completed successfully.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>The pszAppContainerSid or ppszPath parameter is NULL.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The path retrieved through this function is the same path that you would get by calling the SHGetKnownFolderPath function with <c>FOLDERID_LocalAppData</c>.
	/// </para>
	/// <para>
	/// If a thread token is set, this function uses the app container for the current user. If no thread token is set, this function
	/// uses the app container associated with the process identity.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/userenv/nf-userenv-getappcontainerfolderpath USERENVAPI HRESULT
	// GetAppContainerFolderPath( PCWSTR pszAppContainerSid, PWSTR *ppszPath );
	[DllImport(Lib.Userenv, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("userenv.h", MSDNShortId = "7D3AB78D-C094-4F89-8032-13F3C137E910")]
	public static extern HRESULT GetAppContainerFolderPath([MarshalAs(UnmanagedType.LPWStr)] string pszAppContainerSid, [MarshalAs(UnmanagedType.LPWStr)] out string ppszPath);

	/// <summary>Gets the location of the registry storage associated with an app container.</summary>
	/// <param name="desiredAccess">
	/// <para>Type: <c>REGSAM</c></para>
	/// <para>The desired registry access.</para>
	/// </param>
	/// <param name="phAppContainerKey">
	/// <para>Type: <c>PHKEY</c></para>
	/// <para>
	/// A pointer to an HKEY that, when this function returns successfully, receives the registry storage location for the current profile.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>HRESULT</c></para>
	/// <para>This function returns an <c>HRESULT</c> code, including but not limited to the following:</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>S_OK</term>
	/// <term>The operation completed successfully.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>The caller is not running as or impersonating a user who can access this profile.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// The function gets the registry storage for the current user. To get the registry storage for another user, you must impersonate
	/// that user.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/userenv/nf-userenv-getappcontainerregistrylocation USERENVAPI HRESULT
	// GetAppContainerRegistryLocation( REGSAM desiredAccess, PHKEY phAppContainerKey );
	[DllImport(Lib.Userenv, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("userenv.h", MSDNShortId = "DAD7EC07-D57D-40F5-AA99-AD7579910294")]
	public static extern HRESULT GetAppContainerRegistryLocation(REGSAM desiredAccess, out SafeRegistryHandle phAppContainerKey);

	/// <summary>The <c>GetAppliedGPOList</c> function retrieves the list of GPOs applied for the specified user or computer.</summary>
	/// <param name="dwFlags">
	/// <para>A value that specifies the policy type. This parameter can be the following value.</para>
	/// <para>GPO_LIST_FLAG_MACHINE</para>
	/// <para>Retrieves information about the computer policy.</para>
	/// <para>If this value is not specified, the function retrieves only user policy information.</para>
	/// </param>
	/// <param name="pMachineName">
	/// A pointer to the name of the remote computer. The format of the name is "\computer_name". If this parameter is <c>NULL</c>, the
	/// local computer name is used.
	/// </param>
	/// <param name="pSidUser">
	/// <para>
	/// A value that specifies the SID of the user. If pMachineName is not <c>NULL</c> and dwFlags specifies user policy, then pSidUser
	/// cannot be <c>NULL</c>.
	/// </para>
	/// <para>
	/// If pMachineName is <c>NULL</c> and pSidUser is <c>NULL</c>, the user is the currently logged-on user. If pMachineName is
	/// <c>NULL</c> and pSidUser is not <c>NULL</c>, the user is represented by pSidUser on the local computer. For more information,
	/// see Security Identifiers.
	/// </para>
	/// </param>
	/// <param name="pGuidExtension">A value that specifies the <c>GUID</c> of the extension.</param>
	/// <param name="ppGPOList">A pointer that receives the list of GPO structures. For more information, see GROUP_POLICY_OBJECT.</param>
	/// <returns>
	/// If the function succeeds, the return value is <c>ERROR_SUCCESS</c>. Otherwise, the function returns a system error code. For a
	/// complete list of error codes, see System Error Codes or the header file WinError.h.
	/// </returns>
	/// <remarks>To free the GPO list when you have finished processing it, call the FreeGPOList function.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/userenv/nf-userenv-getappliedgpolista USERENVAPI DWORD GetAppliedGPOListA(
	// DWORD dwFlags, LPCSTR pMachineName, PSID pSidUser, GUID *pGuidExtension, PGROUP_POLICY_OBJECTA *ppGPOList );
	[DllImport(Lib.Userenv, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("userenv.h", MSDNShortId = "11e80a4e-acc4-4229-aa34-8f7d083c1041")]
	public static extern Win32Error GetAppliedGPOList(GPO_LIST_FLAG dwFlags, [Optional] string? pMachineName, [Optional] PSID pSidUser, in Guid pGuidExtension, out IntPtr ppGPOList);

	/// <summary>The <c>GetAppliedGPOList</c> function retrieves the list of GPOs applied for the specified user or computer.</summary>
	/// <param name="dwFlags">
	/// <para>A value that specifies the policy type. This parameter can be the following value.</para>
	/// <para>GPO_LIST_FLAG_MACHINE</para>
	/// <para>Retrieves information about the computer policy.</para>
	/// <para>If this value is not specified, the function retrieves only user policy information.</para>
	/// </param>
	/// <param name="pMachineName">
	/// A pointer to the name of the remote computer. The format of the name is "\computer_name". If this parameter is <c>NULL</c>, the
	/// local computer name is used.
	/// </param>
	/// <param name="pSidUser">
	/// <para>
	/// A value that specifies the SID of the user. If pMachineName is not <c>NULL</c> and dwFlags specifies user policy, then pSidUser
	/// cannot be <c>NULL</c>.
	/// </para>
	/// <para>
	/// If pMachineName is <c>NULL</c> and pSidUser is <c>NULL</c>, the user is the currently logged-on user. If pMachineName is
	/// <c>NULL</c> and pSidUser is not <c>NULL</c>, the user is represented by pSidUser on the local computer. For more information,
	/// see Security Identifiers.
	/// </para>
	/// </param>
	/// <param name="pGuidExtension">A value that specifies the <c>GUID</c> of the extension.</param>
	/// <param name="ppGPOList">A pointer that receives the list of GPO structures. For more information, see GROUP_POLICY_OBJECT.</param>
	/// <returns>
	/// If the function succeeds, the return value is <c>ERROR_SUCCESS</c>. Otherwise, the function returns a system error code. For a
	/// complete list of error codes, see System Error Codes or the header file WinError.h.
	/// </returns>
	/// <remarks>To free the GPO list when you have finished processing it, call the FreeGPOList function.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/userenv/nf-userenv-getappliedgpolista USERENVAPI DWORD GetAppliedGPOListA(
	// DWORD dwFlags, LPCSTR pMachineName, PSID pSidUser, GUID *pGuidExtension, PGROUP_POLICY_OBJECTA *ppGPOList );
	[DllImport(Lib.Userenv, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("userenv.h", MSDNShortId = "11e80a4e-acc4-4229-aa34-8f7d083c1041")]
	public static extern Win32Error GetAppliedGPOList(GPO_LIST_FLAG dwFlags, [Optional] string? pMachineName, [Optional] PSID pSidUser, in Guid pGuidExtension,
		[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(GPOMarshaler))] out GROUP_POLICY_OBJECT[] ppGPOList);

	/// <summary>Retrieves the path to the root of the default user's profile.</summary>
	/// <param name="lpProfileDir">
	/// <para>Type: <c>LPTSTR</c></para>
	/// <para>
	/// A pointer to a buffer that, when this function returns successfully, receives the path to the default user's profile directory.
	/// Set this value to <c>NULL</c> to determine the required size of the buffer.
	/// </para>
	/// </param>
	/// <param name="lpcchSize">
	/// <para>Type: <c>LPDWORD</c></para>
	/// <para>Specifies the size of the lpProfileDir buffer, in <c>TCHARs</c>.</para>
	/// <para>
	/// If the buffer specified by lpProfileDir is not large enough or lpProfileDir is <c>NULL</c>, the function fails and this
	/// parameter receives the necessary buffer size, including the terminating null character.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para><c>TRUE</c> if successful; otherwise, <c>FALSE</c>. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>The following is an example of the path returned by <c>GetDefaultUserProfileDirectory</c> in Windows XP:</para>
	/// <para>The following is an example of the path returned by <c>GetDefaultUserProfileDirectory</c> in Windows 7:</para>
	/// <para>
	/// To obtain the paths of subdirectories of this directory, use the SHGetFolderPath (Windows XP and earlier) or
	/// SHGetKnownFolderPath (Windows Vista) function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/userenv/nf-userenv-getdefaultuserprofiledirectorya USERENVAPI BOOL
	// GetDefaultUserProfileDirectoryA( LPSTR lpProfileDir, LPDWORD lpcchSize );
	[DllImport(Lib.Userenv, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("userenv.h", MSDNShortId = "14ff99cb-838a-442b-9f51-414bd7c0a2ef")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetDefaultUserProfileDirectory(StringBuilder? lpProfileDir, ref uint lpcchSize);

	/// <summary>
	/// The <c>GetGPOList</c> function retrieves the list of GPOs for the specified user or computer. This function can be called in two
	/// ways: first, you can use the token for the user or computer, or, second, you can use the name of the user or computer and the
	/// name of the domain controller.
	/// </summary>
	/// <param name="hToken">
	/// <para>
	/// A token for the user or computer, returned from the LogonUser, CreateRestrictedToken, DuplicateToken, OpenProcessToken, or
	/// OpenThreadToken function. This token must have <c>TOKEN_IMPERSONATE</c> and <c>TOKEN_QUERY</c> access. For more information, see
	/// Access Rights for Access-Token Objects and the following Remarks section.
	/// </para>
	/// <para>If this parameter is <c>NULL</c>, you must supply values for the lpName and lpHostName parameters.</para>
	/// </param>
	/// <param name="lpName">
	/// <para>
	/// A pointer to the user or computer name, in the fully qualified distinguished name format (for example, "CN=user, OU=users,
	/// DC=contoso, DC=com").
	/// </para>
	/// <para>If the hToken parameter is not <c>NULL</c>, this parameter must be <c>NULL</c>.</para>
	/// </param>
	/// <param name="lpHostName">
	/// <para>
	/// A DNS domain name or domain controller name. Domain controller name can be retrieved using the DsGetDcName function, specifying
	/// <c>DS_DIRECTORY_SERVICE_REQUIRED</c> in the flags parameter.
	/// </para>
	/// <para>If the hToken parameter is not <c>NULL</c>, this parameter must be <c>NULL</c>.</para>
	/// </param>
	/// <param name="lpComputerName">
	/// A pointer to the name of the computer used to determine the site location. The format of the name is "\computer_name". If this
	/// parameter is <c>NULL</c>, the local computer name is used.
	/// </param>
	/// <param name="dwFlags">
	/// <para>
	/// A value that specifies additional flags that are used to control information retrieval. If you specify
	/// <c>GPO_LIST_FLAG_MACHINE</c>, the function retrieves policy information for the computer. If you do not specify
	/// <c>GPO_LIST_FLAG_MACHINE</c>, the function retrieves policy information for the user.
	/// </para>
	/// <para>If you specify <c>GPO_LIST_FLAG_SITEONLY</c> the function returns only site information for the computer or user.</para>
	/// </param>
	/// <param name="pGPOList">A pointer that receives the list of GPO structures. For more information, see GROUP_POLICY_OBJECT.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>GetGPOList</c> function is intended for use by services acting on behalf of a user or computer. The service calls this
	/// function to obtain a list of GPOs, then checks each GPO for service-specific policy.
	/// </para>
	/// <para>
	/// Calling this function with a token provides the most accurate list. The system can perform access checking for the user or
	/// computer. Calling this function with the user or computer name and the domain controller name is faster than calling it with a
	/// token. However, if the token is not specified, the system uses the security access of the caller, which means that the list may
	/// not be completely correct for the intended user or computer.
	/// </para>
	/// <para>
	/// To obtain the most accurate list of GPOs for a computer when calling <c>GetGPOList</c>, the caller must have read access to each
	/// OU and site in the computer domain, and also read and apply Group Policy access to all GPOs that are linked to the sites, domain
	/// or OUs of that domain. An example of a caller would be a service running on the computer whose name is specified in the lpName
	/// parameter. An alternate method of obtaining a list of GPOs would be to call the RsopCreateSession method of the
	/// <c>RsopPlanningModeProvider</c> WMI class. The method can generate resultant policy data for a computer or user account in a
	/// hypothetical scenario.
	/// </para>
	/// <para>Call the FreeGPOList function to free the GPO list when you have finished processing it.</para>
	/// <para>
	/// Generally, you should call <c>GetGPOList</c> with a token when retrieving a list of GPOs for a user as shown in the following
	/// code example.
	/// </para>
	/// <para>
	/// Typically, to retrieve a list of GPOs for a computer, you can call <c>GetGPOList</c> with the computer name and domain
	/// controller name as demonstrated in the following code snippet.
	/// </para>
	/// <para>To retrieve the list of GPOs applied for a specific user or computer and extension, call the GetAppliedGPOList function.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/userenv/nf-userenv-getgpolista USERENVAPI BOOL GetGPOListA( HANDLE hToken,
	// LPCSTR lpName, LPCSTR lpHostName, LPCSTR lpComputerName, DWORD dwFlags, PGROUP_POLICY_OBJECTA *pGPOList );
	[DllImport(Lib.Userenv, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("userenv.h", MSDNShortId = "26c54ac5-23d7-40ed-94a9-70d25e14431f")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetGPOList([Optional] HTOKEN hToken, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? lpName, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? lpHostName,
		[Optional, MarshalAs(UnmanagedType.LPTStr)] string? lpComputerName, [Optional] GPO_LIST_FLAG dwFlags, out IntPtr pGPOList);

	/// <summary>
	/// The <c>GetGPOList</c> function retrieves the list of GPOs for the specified user or computer. This function can be called in two
	/// ways: first, you can use the token for the user or computer, or, second, you can use the name of the user or computer and the
	/// name of the domain controller.
	/// </summary>
	/// <param name="hToken">
	/// <para>
	/// A token for the user or computer, returned from the LogonUser, CreateRestrictedToken, DuplicateToken, OpenProcessToken, or
	/// OpenThreadToken function. This token must have <c>TOKEN_IMPERSONATE</c> and <c>TOKEN_QUERY</c> access. For more information, see
	/// Access Rights for Access-Token Objects and the following Remarks section.
	/// </para>
	/// <para>If this parameter is <c>NULL</c>, you must supply values for the lpName and lpHostName parameters.</para>
	/// </param>
	/// <param name="lpName">
	/// <para>
	/// A pointer to the user or computer name, in the fully qualified distinguished name format (for example, "CN=user, OU=users,
	/// DC=contoso, DC=com").
	/// </para>
	/// <para>If the hToken parameter is not <c>NULL</c>, this parameter must be <c>NULL</c>.</para>
	/// </param>
	/// <param name="lpHostName">
	/// <para>
	/// A DNS domain name or domain controller name. Domain controller name can be retrieved using the DsGetDcName function, specifying
	/// <c>DS_DIRECTORY_SERVICE_REQUIRED</c> in the flags parameter.
	/// </para>
	/// <para>If the hToken parameter is not <c>NULL</c>, this parameter must be <c>NULL</c>.</para>
	/// </param>
	/// <param name="lpComputerName">
	/// A pointer to the name of the computer used to determine the site location. The format of the name is "\computer_name". If this
	/// parameter is <c>NULL</c>, the local computer name is used.
	/// </param>
	/// <param name="dwFlags">
	/// <para>
	/// A value that specifies additional flags that are used to control information retrieval. If you specify
	/// <c>GPO_LIST_FLAG_MACHINE</c>, the function retrieves policy information for the computer. If you do not specify
	/// <c>GPO_LIST_FLAG_MACHINE</c>, the function retrieves policy information for the user.
	/// </para>
	/// <para>If you specify <c>GPO_LIST_FLAG_SITEONLY</c> the function returns only site information for the computer or user.</para>
	/// </param>
	/// <param name="pGPOList">A pointer that receives the list of GPO structures. For more information, see GROUP_POLICY_OBJECT.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The <c>GetGPOList</c> function is intended for use by services acting on behalf of a user or computer. The service calls this
	/// function to obtain a list of GPOs, then checks each GPO for service-specific policy.
	/// </para>
	/// <para>
	/// Calling this function with a token provides the most accurate list. The system can perform access checking for the user or
	/// computer. Calling this function with the user or computer name and the domain controller name is faster than calling it with a
	/// token. However, if the token is not specified, the system uses the security access of the caller, which means that the list may
	/// not be completely correct for the intended user or computer.
	/// </para>
	/// <para>
	/// To obtain the most accurate list of GPOs for a computer when calling <c>GetGPOList</c>, the caller must have read access to each
	/// OU and site in the computer domain, and also read and apply Group Policy access to all GPOs that are linked to the sites, domain
	/// or OUs of that domain. An example of a caller would be a service running on the computer whose name is specified in the lpName
	/// parameter. An alternate method of obtaining a list of GPOs would be to call the RsopCreateSession method of the
	/// <c>RsopPlanningModeProvider</c> WMI class. The method can generate resultant policy data for a computer or user account in a
	/// hypothetical scenario.
	/// </para>
	/// <para>
	/// Generally, you should call <c>GetGPOList</c> with a token when retrieving a list of GPOs for a user as shown in the following
	/// code example.
	/// </para>
	/// <para>
	/// Typically, to retrieve a list of GPOs for a computer, you can call <c>GetGPOList</c> with the computer name and domain
	/// controller name as demonstrated in the following code snippet.
	/// </para>
	/// <para>To retrieve the list of GPOs applied for a specific user or computer and extension, call the GetAppliedGPOList function.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/userenv/nf-userenv-getgpolista USERENVAPI BOOL GetGPOListA( HANDLE hToken,
	// LPCSTR lpName, LPCSTR lpHostName, LPCSTR lpComputerName, DWORD dwFlags, PGROUP_POLICY_OBJECTA *pGPOList );
	[DllImport(Lib.Userenv, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("userenv.h", MSDNShortId = "26c54ac5-23d7-40ed-94a9-70d25e14431f")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetGPOList([Optional] HTOKEN hToken, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? lpName, [Optional, MarshalAs(UnmanagedType.LPTStr)] string? lpHostName,
		[Optional, MarshalAs(UnmanagedType.LPTStr)] string? lpComputerName, [Optional] GPO_LIST_FLAG dwFlags, [MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(GPOMarshaler))] out GROUP_POLICY_OBJECT[] pGPOList);

	/// <summary>Retrieves the path to the root directory where user profiles are stored.</summary>
	/// <param name="lpProfileDir">
	/// <para>Type: <c>LPTSTR</c></para>
	/// <para>
	/// A pointer to a buffer that, when this function returns successfully, receives the path to the profiles directory. Set this value
	/// to <c>NULL</c> to determine the required size of the buffer.
	/// </para>
	/// </param>
	/// <param name="lpcchSize">
	/// <para>Type: <c>LPDWORD</c></para>
	/// <para>Specifies the size of the lpProfilesDir buffer, in <c>TCHARs</c>.</para>
	/// <para>
	/// If the buffer specified by lpProfilesDir is not large enough or lpProfilesDir is <c>NULL</c>, the function fails and this
	/// parameter receives the necessary buffer size, including the terminating null character.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para><c>TRUE</c> if successful; otherwise, <c>FALSE</c>. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>The following is an example of the path returned by <c>GetProfilesDirectory</c> in Windows XP:</para>
	/// <para>The following is an example of the path returned by <c>GetProfilesDirectory</c> in Windows 7:</para>
	/// <para>
	/// To obtain the paths of subdirectories of this directory, use the SHGetFolderPath (Windows XP and earlier) or
	/// SHGetKnownFolderPath (Windows Vista) function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/userenv/nf-userenv-getprofilesdirectorya USERENVAPI BOOL
	// GetProfilesDirectoryA( LPSTR lpProfileDir, LPDWORD lpcchSize );
	[DllImport(Lib.Userenv, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("userenv.h", MSDNShortId = "e21411fa-f7e1-4944-93ce-7d9314d79fbf")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetProfilesDirectory(StringBuilder? lpProfileDir, ref uint lpcchSize);

	/// <summary>Retrieves the type of profile loaded for the current user.</summary>
	/// <param name="dwFlags">
	/// <para>Type: <c>DWORD*</c></para>
	/// <para>Pointer to a variable that receives the profile type. If the function succeeds, it sets one or more of the following values:</para>
	/// <para>PT_MANDATORY</para>
	/// <para>The user has a Mandatory User Profiles.</para>
	/// <para>PT_ROAMING</para>
	/// <para>The user has a Roaming User Profiles.</para>
	/// <para>PT_ROAMING_PREEXISTING</para>
	/// <para>
	/// The user has a Roaming User Profile that was created on another PC and is being downloaded. This profile type implies <c>PT_ROAMING</c>.
	/// </para>
	/// <para>PT_TEMPORARY</para>
	/// <para>The user has a Temporary User Profiles; it will be deleted at logoff.</para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para><c>TRUE</c> if successful; otherwise, <c>FALSE</c>. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>If the user profile is not already loaded, the function fails.</para>
	/// <para>
	/// Note that the caller must have <c>KEY_READ</c> access to <c>HKEY_LOCAL_MACHINE</c>. This access right is granted by default. For
	/// more information, see Registry Key Security and Access Rights.
	/// </para>
	/// <para>
	/// If the profile type is <c>PT_ROAMING_PREEXISTING</c>, Explorer will not reinitialize default programs associations when a
	/// profile is loaded on a machine for the first time.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/userenv/nf-userenv-getprofiletype USERENVAPI BOOL GetProfileType( DWORD
	// *dwFlags );
	[DllImport(Lib.Userenv, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("userenv.h", MSDNShortId = "55ee76c8-1735-43eb-a98e-9e6c87ee1ba7")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetProfileType(out ProfileType dwFlags);

	/// <summary>Retrieves the path to the root directory of the specified user's profile.</summary>
	/// <param name="hToken">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>
	/// A token for the user, which is returned by the LogonUser, CreateRestrictedToken, DuplicateToken, OpenProcessToken, or
	/// OpenThreadToken function. The token must have TOKEN_QUERY access. For more information, see Access Rights for Access-Token Objects.
	/// </para>
	/// </param>
	/// <param name="lpProfileDir">
	/// <para>Type: <c>LPTSTR</c></para>
	/// <para>
	/// A pointer to a buffer that, when this function returns successfully, receives the path to the specified user's profile directory.
	/// </para>
	/// </param>
	/// <param name="lpcchSize">
	/// <para>Type: <c>LPDWORD</c></para>
	/// <para>Specifies the size of the lpProfileDir buffer, in <c>TCHARs</c>.</para>
	/// <para>
	/// If the buffer specified by lpProfileDir is not large enough or lpProfileDir is <c>NULL</c>, the function fails and this
	/// parameter receives the necessary buffer size, including the terminating null character.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para><c>TRUE</c> if successful; otherwise, <c>FALSE</c>. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>The following is an example of the path returned by <c>GetUserProfileDirectory</c> in Windows XP:</para>
	/// <para>The following is an example of the path returned by <c>GetUserProfileDirectory</c> in Windows 7:</para>
	/// <para>
	/// To obtain the paths of subdirectories of this directory, use the SHGetFolderPath (Windows XP and earlier) or
	/// SHGetKnownFolderPath (Windows Vista) function.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/userenv/nf-userenv-getuserprofiledirectorya USERENVAPI BOOL
	// GetUserProfileDirectoryA( HANDLE hToken, LPSTR lpProfileDir, LPDWORD lpcchSize );
	[DllImport(Lib.Userenv, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("userenv.h", MSDNShortId = "b5de762d-c9ee-42b0-bce0-e74bcc9c78f0")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool GetUserProfileDirectory(HTOKEN hToken, StringBuilder? lpProfileDir, ref uint lpcchSize);

	/// <summary>
	/// The <c>LeaveCriticalPolicySection</c> function resumes the background application of policy. This function closes the handle to
	/// the policy section.
	/// </summary>
	/// <param name="hSection">Handle to a policy section, which is returned by the EnterCriticalPolicySection function.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/userenv/nf-userenv-leavecriticalpolicysection USERENVAPI BOOL
	// LeaveCriticalPolicySection( HANDLE hSection );
	[DllImport(Lib.Userenv, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("userenv.h", MSDNShortId = "9e6a938f-c9cb-4baf-b7d0-4316e45f874c")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool LeaveCriticalPolicySection(IntPtr hSection);

	/// <summary>Loads the specified user's profile. The profile can be a local user profile or a roaming user profile.</summary>
	/// <param name="hToken">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>
	/// Token for the user, which is returned by the LogonUser, CreateRestrictedToken, DuplicateToken, OpenProcessToken, or
	/// OpenThreadToken function. The token must have <c>TOKEN_QUERY</c>, <c>TOKEN_IMPERSONATE</c>, and <c>TOKEN_DUPLICATE</c> access.
	/// For more information, see Access Rights for Access-Token Objects.
	/// </para>
	/// </param>
	/// <param name="lpProfileInfo">
	/// <para>Type: <c>LPPROFILEINFO</c></para>
	/// <para>
	/// Pointer to a PROFILEINFO structure. <c>LoadUserProfile</c> fails and returns <c>ERROR_INVALID_PARAMETER</c> if the <c>dwSize</c>
	/// member of the structure is not set to or if the <c>lpUserName</c> member is <c>NULL</c>. For more information, see Remarks.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para><c>TRUE</c> if successful; otherwise, <c>FALSE</c>. To get extended error information, call GetLastError.</para>
	/// <para>
	/// The function fails and returns ERROR_INVALID_PARAMETER if the <c>dwSize</c> member of the structure at lpProfileInfo is not set
	/// to or if the <c>lpUserName</c> member is <c>NULL</c>.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// When a user logs on interactively, the system automatically loads the user's profile. If a service or an application
	/// impersonates a user, the system does not load the user's profile. Therefore, the service or application should load the user's
	/// profile with <c>LoadUserProfile</c>.
	/// </para>
	/// <para>
	/// Services and applications that call <c>LoadUserProfile</c> should check to see if the user has a roaming profile. If the user
	/// has a roaming profile, specify its path as the <c>lpProfilePath</c> member of PROFILEINFO. To retrieve the user's roaming
	/// profile path, you can call the NetUserGetInfo function, specifying information level 3 or 4.
	/// </para>
	/// <para>
	/// Upon successful return, the <c>hProfile</c> member of PROFILEINFO is a registry key handle opened to the root of the user's
	/// hive. It has been opened with full access (KEY_ALL_ACCESS). If a service that is impersonating a user needs to read or write to
	/// the user's registry file, use this handle instead of <c>HKEY_CURRENT_USER</c>. Do not close the <c>hProfile</c> handle. Instead,
	/// pass it to the UnloadUserProfile function. This function closes the handle. You should ensure that all handles to keys in the
	/// user's registry hive are closed. If you do not close all open registry handles, the user's profile fails to unload. For more
	/// information, see Registry Key Security and Access Rights and Registry Hives.
	/// </para>
	/// <para>
	/// Note that it is your responsibility to load the user's registry hive into the <c>HKEY_USERS</c> registry key with the
	/// <c>LoadUserProfile</c> function before you call CreateProcessAsUser. This is because <c>CreateProcessAsUser</c> does not load
	/// the specified user's profile into <c>HKEY_USERS</c>. This means that access to information in the <c>HKEY_CURRENT_USER</c>
	/// registry key may not produce results consistent with a normal interactive logon.
	/// </para>
	/// <para>
	/// The calling process must have the <c>SE_RESTORE_NAME</c> and <c>SE_BACKUP_NAME</c> privileges. For more information, see Running
	/// with Special Privileges.
	/// </para>
	/// <para>
	/// Starting with Windows XP Service Pack 2 (SP2) and Windows Server 2003, the caller must be an administrator or the LocalSystem
	/// account. It is not sufficient for the caller to merely impersonate the administrator or LocalSystem account.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/userenv/nf-userenv-loaduserprofilea USERENVAPI BOOL LoadUserProfileA( HANDLE
	// hToken, LPPROFILEINFOA lpProfileInfo );
	[DllImport(Lib.Userenv, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("userenv.h", MSDNShortId = "9ec1f8f2-8f20-4d38-9d41-70315b890336")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool LoadUserProfile(HTOKEN hToken, ref PROFILEINFO lpProfileInfo);

	/* =====================================
	*  Unimplemented at this time due to lack of documentation on ASYNCCOMPLETIONHANDLE
	*
	*
	/// <summary>
	/// The <c>ProcessGroupPolicyCompleted</c> function notifies the system that the specified extension has finished applying policy.
	/// </summary>
	/// <param name="extensionId">Specifies the unique <c>GUID</c> that identifies the extension.</param>
	/// <param name="pAsyncHandle">Asynchronous completion handle. This handle is passed to the ProcessGroupPolicy function.</param>
	/// <param name="dwStatus">Specifies the completion status of asynchronous processing.</param>
	/// <returns>
	/// If the function succeeds, the return value is <c>ERROR_SUCCESS</c>. Otherwise, the function returns one of the system error
	/// codes. For a complete list of error codes, see System Error Codes or the header file WinError.h.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/userenv/nf-userenv-processgrouppolicycompleted USERENVAPI DWORD
	// ProcessGroupPolicyCompleted( REFGPEXTENSIONID extensionId, ASYNCCOMPLETIONHANDLE pAsyncHandle, DWORD dwStatus );
	[DllImport(Lib.Userenv, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("userenv.h", MSDNShortId = "f88c8072-af4c-44e0-a816-ecb841dd1a78")]
	public static extern Win32Error ProcessGroupPolicyCompleted(in Guid extensionId, ASYNCCOMPLETIONHANDLE pAsyncHandle, uint dwStatus);

	/// <summary>
	/// The <c>ProcessGroupPolicyCompletedEx</c> function notifies the system that the specified policy extension has finished applying
	/// policy. The function also reports the status of Resultant Set of Policy (RSoP) logging.
	/// </summary>
	/// <param name="extensionId">Specifies the unique <c>GUID</c> that identifies the policy extension.</param>
	/// <param name="pAsyncHandle">Asynchronous completion handle. This handle is passed to the ProcessGroupPolicyEx callback function.</param>
	/// <param name="dwStatus">Specifies the completion status of asynchronous processing of policy.</param>
	/// <param name="RsopStatus">Specifies an <c>HRESULT</c> return code that indicates the status of RSoP logging.</param>
	/// <returns>
	/// If the function succeeds, the return value is <c>ERROR_SUCCESS</c>. Otherwise, the function returns one of the system error
	/// codes. For a complete list of error codes, see System Error Codes or the header file WinError.h.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/userenv/nf-userenv-processgrouppolicycompletedex USERENVAPI DWORD
	// ProcessGroupPolicyCompletedEx( REFGPEXTENSIONID extensionId, ASYNCCOMPLETIONHANDLE pAsyncHandle, DWORD dwStatus, HRESULT
	// RsopStatus );
	[DllImport(Lib.Userenv, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("userenv.h", MSDNShortId = "0d899190-7345-4762-ab59-b89e2e87d10f")]
	public static extern Win32Error ProcessGroupPolicyCompletedEx(in Guid extensionId, ASYNCCOMPLETIONHANDLE pAsyncHandle, uint dwStatus, HRESULT RsopStatus);
	*
	*
	*/

	/// <summary>
	/// The <c>RefreshPolicy</c> function causes policy to be applied immediately on the client computer. To apply policy and specify
	/// the type of refresh that should occur, you can call the extended function RefreshPolicyEx.
	/// </summary>
	/// <param name="bMachine">
	/// Specifies whether to refresh the computer policy or user policy. If this value is <c>TRUE</c>, the system refreshes the computer
	/// policy. If this value is <c>FALSE</c>, the system refreshes the user policy.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>By default, policy is reapplied every 90 minutes.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/userenv/nf-userenv-refreshpolicy USERENVAPI BOOL RefreshPolicy( BOOL bMachine );
	[DllImport(Lib.Userenv, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("userenv.h", MSDNShortId = "e08cb006-d174-4506-87f0-580660bd4023")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool RefreshPolicy([MarshalAs(UnmanagedType.Bool)] bool bMachine);

	/// <summary>
	/// The <c>RefreshPolicyEx</c> function causes policy to be applied immediately on the computer. The extended function allows you to
	/// specify the type of policy refresh to apply.
	/// </summary>
	/// <param name="bMachine">
	/// Specifies whether to refresh the computer policy or user policy. If this value is <c>TRUE</c>, the system refreshes the computer
	/// policy. If this value is <c>FALSE</c>, the system refreshes the user policy.
	/// </param>
	/// <param name="dwOptions">
	/// <para>Specifies the type of policy refresh to apply. This parameter can be the following value.</para>
	/// <para>RP_FORCE</para>
	/// <para>Reapply all policies even if no policy change was detected.</para>
	/// <para>
	/// Note that if there are any client-side extensions that can be applied at boot or logon time, (for example, an application
	/// installation extension), the extensions are re-applied at the next boot or logon, even if no policy change is detected.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>If you do not need to specify the dwOptions parameter, you can call the RefreshPolicy function instead.</para>
	/// <para>By default, policy is reapplied every 90 minutes.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/userenv/nf-userenv-refreshpolicyex USERENVAPI BOOL RefreshPolicyEx( BOOL
	// bMachine, DWORD dwOptions );
	[DllImport(Lib.Userenv, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("userenv.h", MSDNShortId = "905ab96b-a7f2-4bb4-a539-385f78284644")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool RefreshPolicyEx([MarshalAs(UnmanagedType.Bool)] bool bMachine, RefreshPolicyOption dwOptions = 0);

	/// <summary>
	/// The <c>RegisterGPNotification</c> function enables an application to receive notification when there is a change in policy. When
	/// a policy change occurs, the specified event object is set to the signaled state.
	/// </summary>
	/// <param name="hEvent">Handle to an event object. Use the <see cref="CreateEvent"/> function to create the event object.</param>
	/// <param name="bMachine">
	/// Specifies the policy change type. If <c>TRUE</c>, computer policy changes are reported. If <c>FALSE</c>, user policy changes are reported.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Call the UnregisterGPNotification function to unregister the handle from receiving policy change notifications. Call the
	/// CloseHandle function to close the handle when it is no longer required.
	/// </para>
	/// <para>
	/// An application can also receive notifications about policy changes when a WM_SETTINGCHANGE message is broadcast. In this
	/// instance, the wParam parameter value is 1 if computer policy was applied; it is zero if user policy was applied. The lParam
	/// parameter points to the string "Policy".
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/userenv/nf-userenv-registergpnotification USERENVAPI BOOL
	// RegisterGPNotification( HANDLE hEvent, BOOL bMachine );
	[DllImport(Lib.Userenv, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("userenv.h", MSDNShortId = "0a758da3-73a8-4d9b-8663-e6cab1a1bd3f")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool RegisterGPNotification(SafeEventHandle hEvent, [MarshalAs(UnmanagedType.Bool)] bool bMachine);

	/* =====================================
	*  Unimplemented at this time due to lack of documentation on RSOPTOKEN
	*
	*
	/// <summary>
	/// The <c>RSoPAccessCheckByType</c> function determines whether a security descriptor grants a specified set of access rights to
	/// the client identified by an <c>RSOPTOKEN</c>.
	/// </summary>
	/// <param name="pSecurityDescriptor">Pointer to a SECURITY_DESCRIPTOR against which access on the object is checked.</param>
	/// <param name="pPrincipalSelfSid">
	/// <para>
	/// Pointer to a SID. If the security descriptor is associated with an object that represents a principal (for example, a user
	/// object), this parameter should be the SID of the object. When evaluating access, this SID logically replaces the SID in any ACE
	/// containing the well-known <c>PRINCIPAL_SELF</c> SID ("S-1-5-10"). For more information, see Security Identifiers and Well-Known SIDs.
	/// </para>
	/// <para>This parameter should be <c>NULL</c> if the protected object does not represent a principal.</para>
	/// </param>
	/// <param name="pRsopToken">Pointer to a valid <c>RSOPTOKEN</c> representing the client attempting to gain access to the object.</param>
	/// <param name="dwDesiredAccessMask">
	/// Specifies an access mask that indicates the access rights to check. This mask can contain a combination of generic, standard and
	/// specific access rights. For more information, see Access Rights and Access Masks.
	/// </param>
	/// <param name="pObjectTypeList">
	/// <para>
	/// Pointer to an array of OBJECT_TYPE_LIST structures that identify the hierarchy of object types for which to check access. Each
	/// element in the array specifies a <c>GUID</c> that identifies the object type and a value indicating the level of the object type
	/// in the hierarchy of object types. The array should not have two elements with the same <c>GUID</c>.
	/// </para>
	/// <para>
	/// The array must have at least one element. The first element in the array must be at level zero and identify the object itself.
	/// The array can have only one level zero element. The second element is a subobject, such as a property set, at level 1. Following
	/// each level 1 entry are subordinate entries for the level 2 through 4 subobjects. Thus, the levels for the elements in the array
	/// might be {0, 1, 2, 2, 1, 2, 3}. If the object type list is out of order, <c>RSoPAccessCheckByType</c> fails and GetLastError
	/// returns <c>ERROR_INVALID_PARAMETER</c>.
	/// </para>
	/// </param>
	/// <param name="ObjectTypeListLength">Specifies the number of elements in the pObjectTypeList array.</param>
	/// <param name="pGenericMapping">
	/// Pointer to the GENERIC_MAPPING structure associated with the object for which access is being checked.
	/// </param>
	/// <param name="pPrivilegeSet">This parameter is currently unused.</param>
	/// <param name="pdwPrivilegeSetLength">This parameter is currently unused.</param>
	/// <param name="pdwGrantedAccessMask">
	/// <para>Pointer to an access mask that receives the granted access rights.</para>
	/// <para>
	/// If the function succeeds, the pbAccessStatus parameter is set to <c>TRUE</c>, and the mask is updated to contain the standard
	/// and specific rights granted. If pbAccessStatus is set to <c>FALSE</c>, this parameter is set to zero. If the function fails, the
	/// mask is not modified.
	/// </para>
	/// </param>
	/// <param name="pbAccessStatus">
	/// <para>Pointer to a variable that receives the results of the access check.</para>
	/// <para>
	/// If the function succeeds, and the requested set of access rights are granted, this parameter is set to <c>TRUE</c>. Otherwise,
	/// this parameter is set to <c>FALSE</c>. If the function fails, the status is not modified.
	/// </para>
	/// </param>
	/// <returns>
	/// If the function succeeds, the return value is <c>S_OK</c>. Otherwise, the function returns one of the COM error codes defined in
	/// the Platform SDK header file WinError.h.
	/// </returns>
	/// <remarks>
	/// The <c>RSoPAccessCheckByType</c> function compares the specified security descriptor with the specified <c>RSOPTOKEN</c> and
	/// indicates, in the pbAccessStatus parameter, whether access is granted or denied.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/userenv/nf-userenv-rsopaccesscheckbytype USERENVAPI HRESULT
	// RsopAccessCheckByType( PSECURITY_DESCRIPTOR pSecurityDescriptor, PSID pPrincipalSelfSid, PRSOPTOKEN pRsopToken, DWORD
	// dwDesiredAccessMask, POBJECT_TYPE_LIST pObjectTypeList, DWORD ObjectTypeListLength, PGENERIC_MAPPING pGenericMapping,
	// PPRIVILEGE_SET pPrivilegeSet, LPDWORD pdwPrivilegeSetLength, LPDWORD pdwGrantedAccessMask, LPBOOL pbAccessStatus );
	[DllImport(Lib.Userenv, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("userenv.h", MSDNShortId = "d63734a0-1a88-4669-828e-de467606fc14")]
	public static extern HRESULT RsopAccessCheckByType(PSECURITY_DESCRIPTOR pSecurityDescriptor, PSID pPrincipalSelfSid, PRSOPTOKEN pRsopToken,
		ACCESS_MASK dwDesiredAccessMask, [In] OBJECT_TYPE_LIST[] pObjectTypeList, uint ObjectTypeListLength, in GENERIC_MAPPING pGenericMapping,
		[Optional] IntPtr pPrivilegeSet, [Optional] IntPtr pdwPrivilegeSetLength, out ACCESS_MASK pdwGrantedAccessMask, [MarshalAs(UnmanagedType.Bool)] out bool pbAccessStatus);

	/// <summary>
	/// The <c>RSoPFileAccessCheck</c> function determines whether a file's security descriptor grants a specified set of file access
	/// rights to the client identified by an <c>RSOPTOKEN</c>.
	/// </summary>
	/// <param name="pszFileName">Pointer to the name of the relevant file. The file must already exist.</param>
	/// <param name="pRsopToken">Pointer to a valid <c>RSOPTOKEN</c> representing the client attempting to gain access to the file.</param>
	/// <param name="dwDesiredAccessMask">
	/// Specifies an access mask that indicates the access rights to check. This mask can contain a combination of generic, standard,
	/// and specific access rights. For more information, see Access Rights and Access Masks.
	/// </param>
	/// <param name="pdwGrantedAccessMask">
	/// <para>Pointer to an access mask that receives the granted access rights.</para>
	/// <para>
	/// If the function succeeds, the pbAccessStatus parameter is set to <c>TRUE</c>, and the mask is updated to contain the standard
	/// and specific rights granted. If pbAccessStatus is set to <c>FALSE</c>, this parameter is set to zero. If the function fails, the
	/// mask is not modified.
	/// </para>
	/// </param>
	/// <param name="pbAccessStatus">
	/// <para>Pointer to a variable that receives the results of the access check.</para>
	/// <para>
	/// If the function succeeds, and the requested set of access rights are granted, this parameter is set to <c>TRUE</c>. Otherwise,
	/// this parameter is set to <c>FALSE</c>. If the function fails, the status is not modified.
	/// </para>
	/// </param>
	/// <returns>
	/// If the function succeeds, the return value is <c>S_OK</c>. Otherwise, the function returns one of the COM error codes defined in
	/// the Platform SDK header file WinError.h.
	/// </returns>
	/// <remarks>
	/// The <c>RSoPFileAccessCheck</c> function indicates, in the pbAccessStatus parameter, whether access is granted or denied to the
	/// client identified by the <c>RSOPTOKEN</c>. If access is granted, the requested access mask becomes the object's granted access mask.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/userenv/nf-userenv-rsopfileaccesscheck USERENVAPI HRESULT RsopFileAccessCheck(
	// LPWSTR pszFileName, PRSOPTOKEN pRsopToken, DWORD dwDesiredAccessMask, LPDWORD pdwGrantedAccessMask, LPBOOL pbAccessStatus );
	[DllImport(Lib.Userenv, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("userenv.h", MSDNShortId = "dfdf14ee-fee1-4e96-9955-7f24dfe39487")]
	public static extern HRESULT RsopFileAccessCheck([MarshalAs(UnmanagedType.LPWStr)] string pszFileName, PRSOPTOKEN pRsopToken, ACCESS_MASK dwDesiredAccessMask,
		out ACCESS_MASK pdwGrantedAccessMask, [MarshalAs(UnmanagedType.Bool)] ref bool pbAccessStatus);

	/// <summary>
	/// The <c>RSoPResetPolicySettingStatus</c> function unlinks the RSOP_PolicySettingStatus instance from its RSOP_PolicySetting
	/// instance. The function deletes the instances of <c>RSOP_PolicySettingStatus</c> and RSOP_PolicySettingLink. Optionally, you can
	/// also specify that the function delete the instance of <c>RSOP_PolicySetting</c>.
	/// </summary>
	/// <param name="dwFlags">This parameter is currently unused.</param>
	/// <param name="pServices">
	/// Specifies a WMI services pointer to the RSoP namespace to which the policy data is to be written. This parameter is required.
	/// </param>
	/// <param name="pSettingInstance">
	/// Pointer to an instance of RSOP_PolicySetting containing the policy setting. This parameter is required and can also point to the
	/// instance's children.
	/// </param>
	/// <returns>
	/// If the function succeeds, the return value is <c>S_OK</c>. Otherwise, the function returns one of the COM error codes defined in
	/// the Platform SDK header file WinError.h.
	/// </returns>
	/// <remarks>
	/// To link (associate) the RSOP_PolicySettingStatus instance to its RSOP_PolicySetting instance, you can call the
	/// RSoPSetPolicySettingStatus function.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/userenv/nf-userenv-rsopresetpolicysettingstatus USERENVAPI HRESULT
	// RsopResetPolicySettingStatus( DWORD dwFlags, IWbemServices *pServices, IWbemClassObject *pSettingInstance );
	[DllImport(Lib.Userenv, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("userenv.h", MSDNShortId = "fd849efe-1ee7-4034-aea2-1a2bdb5e46bc")]
	public static extern HRESULT RsopResetPolicySettingStatus([Optional] uint dwFlags, IWbemServices pServices, IWbemClassObject pSettingInstance);

	/// <summary>
	/// The <c>RSoPSetPolicySettingStatus</c> function creates an instance of RSOP_PolicySettingStatus and an instance of
	/// RSOP_PolicySettingLink. The function links (associates) <c>RSOP_PolicySettingStatus</c> to its RSOP_PolicySetting instance.
	/// </summary>
	/// <param name="dwFlags">This parameter is currently unused.</param>
	/// <param name="pServices">
	/// Specifies a WMI services pointer to the RSoP namespace to which the policy data is to be written. This parameter is required.
	/// </param>
	/// <param name="pSettingInstance">
	/// Pointer to an instance of RSOP_PolicySetting containing the policy setting. This parameter is required and can point to the
	/// instance's children.
	/// </param>
	/// <param name="nInfo">Specifies the number of elements in the pStatus array.</param>
	/// <param name="pStatus">Pointer to an array of POLICYSETTINGSTATUSINFO structures.</param>
	/// <returns>
	/// If the function succeeds, the return value is <c>S_OK</c>. Otherwise, the function returns one of the COM error codes defined in
	/// the Platform SDK header file WinError.h.
	/// </returns>
	/// <remarks>
	/// To unlink an RSOP_PolicySettingStatus instance from its RSOP_PolicySetting instance, you can call the
	/// RSoPResetPolicySettingStatus function.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/userenv/nf-userenv-rsopsetpolicysettingstatus USERENVAPI HRESULT
	// RsopSetPolicySettingStatus( DWORD dwFlags, IWbemServices *pServices, IWbemClassObject *pSettingInstance, DWORD nInfo,
	// POLICYSETTINGSTATUSINFO *pStatus );
	[DllImport(Lib.Userenv, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("userenv.h", MSDNShortId = "7ea2f217-4dd2-4c0f-af1b-d4bcb8707519")]
	public static extern HRESULT RsopSetPolicySettingStatus([Optional] uint dwFlags, IWbemServices pServices, IWbemClassObject pSettingInstance,
		uint nInfo, [In, MarshalAs(UnmanagedType.LPArray)] POLICYSETTINGSTATUSINFO[] pStatus);
	*
	*
	*/

	/// <summary>
	/// Unloads a user's profile that was loaded by the LoadUserProfile function. The caller must have administrative privileges on the
	/// computer. For more information, see the Remarks section of the <c>LoadUserProfile</c> function.
	/// </summary>
	/// <param name="hToken">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>
	/// Token for the user, returned from the LogonUser, CreateRestrictedToken, DuplicateToken, OpenProcessToken, or OpenThreadToken
	/// function. The token must have <c>TOKEN_IMPERSONATE</c> and <c>TOKEN_DUPLICATE</c> access. For more information, see Access
	/// Rights for Access-Token Objects.
	/// </para>
	/// </param>
	/// <param name="hProfile">
	/// <para>Type: <c>HANDLE</c></para>
	/// <para>
	/// Handle to the registry key. This value is the <c>hProfile</c> member of the PROFILEINFO structure. For more information see the
	/// Remarks section of LoadUserProfile and Registry Key Security and Access Rights.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>Type: <c>BOOL</c></para>
	/// <para><c>TRUE</c> if successful; otherwise, <c>FALSE</c>. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Before calling <c>UnloadUserProfile</c> you should ensure that all handles to keys that you have opened in the user's registry
	/// hive are closed. If you do not close all open registry handles, the user's profile fails to unload. For more information, see
	/// Registry Key Security and Access Rights and Registry Hives.
	/// </para>
	/// <para>For more information about calling functions that require administrator privileges, see Running with Special Privileges.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/userenv/nf-userenv-unloaduserprofile USERENVAPI BOOL UnloadUserProfile( HANDLE
	// hToken, HANDLE hProfile );
	[DllImport(Lib.Userenv, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("userenv.h", MSDNShortId = "7ecb8a3f-c041-4133-b23a-101de8884882")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool UnloadUserProfile(HTOKEN hToken, HKEY hProfile);

	/// <summary>
	/// The <c>UnregisterGPNotification</c> function unregisters the specified policy-notification handle from receiving policy change notifications.
	/// </summary>
	/// <param name="hEvent">Policy-notification handle passed to the RegisterGPNotification function.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>If the function fails, the return value is zero. To get extended error information, call GetLastError.</para>
	/// </returns>
	/// <remarks>The caller must call the CloseHandle function to close the handle when it is no longer needed.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/userenv/nf-userenv-unregistergpnotification USERENVAPI BOOL
	// UnregisterGPNotification( HANDLE hEvent );
	[DllImport(Lib.Userenv, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("userenv.h", MSDNShortId = "39ac1361-0160-44e3-8b99-ff50978cc425")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool UnregisterGPNotification(SafeEventHandle hEvent);

	/// <summary>The <c>GROUP_POLICY_OBJECT</c> structure provides information about a GPO in a GPO list.</summary>
	/// <remarks>
	/// <para>
	/// Each GPO could contain data that must be processed by multiple snap-in extensions. Therefore, the data in the
	/// <c>lpExtensions</c> member is organized as a series of <c>GUID</c> s that identify the extensions and snap-in extensions. The
	/// data format is as follows:
	/// </para>
	/// <para>
	/// First, there is an opening bracket, "[", followed by the <c>GUID</c> of the extension. Next, you'll find one or more <c>GUID</c>
	/// s identifying the snap-in extensions that have stored data in the GPO. After the last snap-in <c>GUID</c> for an extension,
	/// there is a closing bracket, "]". This pattern is repeated for the next extension.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/userenv/ns-userenv-group_policy_objecta typedef struct _GROUP_POLICY_OBJECTA {
	// DWORD dwOptions; DWORD dwVersion; LPSTR lpDSPath; LPSTR lpFileSysPath; LPSTR lpDisplayName; CHAR szGPOName[50]; GPO_LINK GPOLink;
	// LPARAM lParam; struct _GROUP_POLICY_OBJECTA *pNext; struct _GROUP_POLICY_OBJECTA *pPrev; LPSTR lpExtensions; LPARAM lParam2;
	// LPSTR lpLink; } GROUP_POLICY_OBJECTA, *PGROUP_POLICY_OBJECTA;
	[PInvokeData("userenv.h", MSDNShortId = "7275a3cd-6b19-4eb9-9481-b73bd5af5753")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct GROUP_POLICY_OBJECT
	{
		/// <summary>
		/// <para>Specifies link options. This member can be one of the following values.</para>
		/// <para>GPO_FLAG_DISABLE</para>
		/// <para>This GPO is disabled.</para>
		/// <para>GPO_FLAG_FORCE</para>
		/// <para>Do not override the policy settings in this GPO with policy settings in a subsequent GPO.</para>
		/// </summary>
		public uint dwOptions;

		/// <summary>Specifies the version number of the GPO.</summary>
		public uint dwVersion;

		/// <summary>Pointer to a string that specifies the path to the directory service portion of the GPO.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string lpDSPath;

		/// <summary>Pointer to a string that specifies the path to the file system portion of the GPO.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string lpFileSysPath;

		/// <summary>Pointer to the display name of the GPO.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string lpDisplayName;

		/// <summary>Pointer to a string that specifies a unique name that identifies the GPO.</summary>
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 50)]
		public string szGPOName;

		/// <summary>
		/// <para>Specifies the link information for the GPO. This member may be one of the following values.</para>
		/// <para>GPLinkUnknown</para>
		/// <para>No link information is available.</para>
		/// <para>GPLinkMachine</para>
		/// <para>The GPO is linked to a computer (local or remote).</para>
		/// <para>GPLinkSite</para>
		/// <para>The GPO is linked to a site.</para>
		/// <para>GPLinkDomain</para>
		/// <para>The GPO is linked to a domain.</para>
		/// <para>GPLinkOrganizationalUnit</para>
		/// <para>The GPO is linked to an organizational unit.</para>
		/// </summary>
		public GPO_LINK GPOLink;

		/// <summary>User-supplied data.</summary>
		public IntPtr lParam;

		/// <summary>Pointer to the next GPO in the list.</summary>
		public IntPtr pNext;

		/// <summary>Pointer to the previous GPO in the list.</summary>
		public IntPtr pPrev;

		/// <summary>
		/// Extensions that have stored data in this GPO. The format is a string of <c>GUID</c> s grouped in brackets. For more
		/// information, see the following Remarks section.
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string lpExtensions;

		/// <summary>User-supplied data.</summary>
		public IntPtr lParam2;

		/// <summary>
		/// Path to the Active Directory site, domain, or organization unit to which this GPO is linked. If the GPO is linked to the
		/// local GPO, this member is "Local".
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string lpLink;
	}

	/// <summary>Contains information used when loading or unloading a user profile.</summary>
	/// <remarks>
	/// <para>
	/// Do not use environment variables when specifying a path. The LoadUserProfile function does not expand environment variables,
	/// such as %username%, in a path.
	/// </para>
	/// <para>
	/// When the LoadUserProfile call returns successfully, the <c>hProfile</c> member receives a registry key handle opened to the root
	/// of the user's subtree, opened with full access (KEY_ALL_ACCESS). For more information see the Remarks sections in
	/// <c>LoadUserProfile</c>, Registry Key Security and Access Rights, and Registry Hives.
	/// </para>
	/// <para>
	/// Services and applications that call LoadUserProfile should check to see if the user has a roaming profile. If the user has a
	/// roaming profile, specify its path as the <c>lpProfilePath</c> member of this structure.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/profinfo/ns-profinfo-profileinfoa typedef struct _PROFILEINFOA { DWORD dwSize;
	// DWORD dwFlags; MIDL_STRING LPSTR lpUserName; MIDL_STRING LPSTR lpProfilePath; MIDL_STRING LPSTR lpDefaultPath; MIDL_STRING LPSTR
	// lpServerName; MIDL_STRING LPSTR lpPolicyPath; #if ... ULONG_PTR hProfile; #else HANDLE hProfile; #endif } PROFILEINFOA, *LPPROFILEINFOA;
	[PInvokeData("profinfo.h", MSDNShortId = "09dae38c-3b2b-4f12-9c1e-90737cf0c7cc")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct PROFILEINFO
	{
		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>The size of this structure, in bytes.</para>
		/// </summary>
		public uint dwSize;

		/// <summary>
		/// <para>Type: <c>DWORD</c></para>
		/// <para>This member can be one of the following flags:</para>
		/// <para>PI_NOUI</para>
		/// <para>Prevents the display of profile error messages.</para>
		/// <para>PI_APPLYPOLICY</para>
		/// <para>Not supported.</para>
		/// </summary>
		public ProfileInfoFlags dwFlags;

		/// <summary>
		/// <para>Type: <c>LPTSTR</c></para>
		/// <para>A pointer to the name of the user. This member is used as the base name of the directory in which to store a new profile.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string? lpUserName;

		/// <summary>
		/// <para>Type: <c>LPTSTR</c></para>
		/// <para>
		/// A pointer to the roaming user profile path. If the user does not have a roaming profile, this member can be <c>NULL</c>. To
		/// retrieve the user's roaming profile path, call the NetUserGetInfo function, specifying information level 3 or 4. For more
		/// information, see Remarks.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string? lpProfilePath;

		/// <summary>
		/// <para>Type: <c>LPTSTR</c></para>
		/// <para>A pointer to the default user profile path. This member can be <c>NULL</c>.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string? lpDefaultPath;

		/// <summary>
		/// <para>Type: <c>LPTSTR</c></para>
		/// <para>A pointer to the name of the validating domain controller, in NetBIOS format.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string lpServerName;

		/// <summary>
		/// <para>Type: <c>LPTSTR</c></para>
		/// <para>Not used, set to <c>NULL</c>.</para>
		/// </summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string? lpPolicyPath;

		/// <summary>
		/// <para>Type: <c>HANDLE</c></para>
		/// <para>A handle to the <c>HKEY_CURRENT_USER</c> registry subtree. For more information, see Remarks.</para>
		/// </summary>
		public HKEY hProfile;

		/// <summary>Initializes a new instance of the <see cref="PROFILEINFO"/> struct.</summary>
		/// <param name="userName">Name of the user.</param>
		/// <param name="allowUI">If set to <see langword="false"/>, prevents the display of profile error messages..</param>
		public PROFILEINFO(string? userName, bool allowUI = true)
		{
			dwSize = Default.dwSize;
			dwFlags = allowUI ? 0 : ProfileInfoFlags.PI_NOUI;
			lpUserName = userName;
			lpProfilePath = lpDefaultPath = lpPolicyPath = null;
			lpServerName = "";
			hProfile = HKEY.NULL;
		}

		/// <summary>Gets a default instance of this structure with the size field set appropriately.</summary>
		public static readonly PROFILEINFO Default = new() { dwSize = (uint)Marshal.SizeOf(typeof(PROFILEINFO)) };
	}

	/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="EnterCriticalPolicySection"/> that is disposed using <see cref="LeaveCriticalPolicySection"/>.</summary>
	[AutoSafeHandle("LeaveCriticalPolicySection(handle)")]
	public partial class SafeCriticalPolicySectionHandle { }

	private class EnvBlockMarshaler : ICustomMarshaler
	{
		private EnvBlockMarshaler(string _)
		{
		}

		/// <summary>Gets the instance.</summary>
		/// <param name="cookie">The cookie.</param>
		/// <returns>A new instance of this class.</returns>
		public static ICustomMarshaler GetInstance(string cookie) => new EnvBlockMarshaler(cookie);

		/// <inheritdoc/>
		void ICustomMarshaler.CleanUpManagedData(object ManagedObj) { }

		/// <inheritdoc/>
		void ICustomMarshaler.CleanUpNativeData(IntPtr pNativeData) { }

		/// <inheritdoc/>
		int ICustomMarshaler.GetNativeDataSize() => -1;

		/// <inheritdoc/>
		IntPtr ICustomMarshaler.MarshalManagedToNative(object ManagedObj) => throw new NotImplementedException();

		/// <inheritdoc/>
		object ICustomMarshaler.MarshalNativeToManaged(IntPtr pNativeData)
		{
			try
			{
				return pNativeData.ToStringEnum(CharSet.Unicode).ToArray();
			}
			finally
			{
				DestroyEnvironmentBlock(pNativeData);
			}
		}
	}

	private class GPOMarshaler : ICustomMarshaler
	{
		private GPOMarshaler(string _)
		{
		}

		/// <summary>Gets the instance.</summary>
		/// <param name="cookie">The cookie.</param>
		/// <returns>A new instance of this class.</returns>
		public static ICustomMarshaler GetInstance(string cookie) => new GPOMarshaler(cookie);

		/// <inheritdoc/>
		void ICustomMarshaler.CleanUpManagedData(object ManagedObj) { }

		/// <inheritdoc/>
		void ICustomMarshaler.CleanUpNativeData(IntPtr pNativeData) { }

		/// <inheritdoc/>
		int ICustomMarshaler.GetNativeDataSize() => -1;

		/// <inheritdoc/>
		IntPtr ICustomMarshaler.MarshalManagedToNative(object ManagedObj) => throw new NotImplementedException();

		/// <inheritdoc/>
		object ICustomMarshaler.MarshalNativeToManaged(IntPtr pNativeData)
		{
			try
			{
				var ret = pNativeData.LinkedListToIEnum<GROUP_POLICY_OBJECT>(gpo => gpo.pNext).ToArray();
				for (var i = 0; i < ret.Length; i++)
					ret[i].pNext = ret[i].pPrev = IntPtr.Zero;
				return ret;
			}
			finally
			{
				FreeGPOList(pNativeData);
			}
		}
	}
}
 
 
 