using System;
using System.Runtime.InteropServices;
using Vanara.InteropServices;
using static Vanara.PInvoke.Crypt32;

namespace Vanara.PInvoke
{
	public static partial class AdvApi32
	{
		/// <summary/>
		public const string SRP_POLICY_APPX = "APPX";
		/// <summary/>
		public const string SRP_POLICY_DLL = "DLL";
		/// <summary/>
		public const string SRP_POLICY_EXE = "EXE";
		/// <summary/>
		public const string SRP_POLICY_MANAGEDINSTALLER = "MANAGEDINSTALLER";
		/// <summary/>
		public const string SRP_POLICY_MSI = "MSI";
		/// <summary/>
		public const string SRP_POLICY_NOV2 = "IGNORESRPV2";
		/// <summary/>
		public const string SRP_POLICY_SCRIPT = "SCRIPT";
		/// <summary/>
		public const string SRP_POLICY_SHELL = "SHELL";
		/// <summary/>
		public const string SRP_POLICY_WLDPCONFIGCI = "WLDPCONFIGCI";
		/// <summary/>
		public const string SRP_POLICY_WLDPMSI = "WLDPMSI";
		/// <summary/>
		public const string SRP_POLICY_WLDPSCRIPT = "WLDPSCRIPT";

		private const int SAFER_MAX_HASH_SIZE = 64;

		/// <summary>The types of criteria considered when evaluating this structure.</summary>
		[PInvokeData("winsafer.h", MSDNShortId = "039a37a9-1744-4cff-919e-e0da50d7b291")]
		[Flags]
		public enum SAFER_CRITERIA
		{
			/// <summary>Check the code image path.</summary>
			SAFER_CRITERIA_IMAGEPATH = 0x00001,

			/// <summary>Check the code hash.</summary>
			SAFER_CRITERIA_IMAGEHASH = 0x00004,

			/// <summary>
			/// Check the Authenticode signature. If this value is used, either the hImageFileHandle member or the ImagePath member must be set.
			/// </summary>
			SAFER_CRITERIA_AUTHENTICODE = 0x00008,

			/// <summary>Check the URL of origin.</summary>
			SAFER_CRITERIA_URLZONE = 0x00010,

			/// <summary>Check the Windows NT image path.</summary>
			SAFER_CRITERIA_IMAGEPATH_NT = 0x01000,

			/// <summary>Check for a Windows Store app package. For use by Windows Store apps.</summary>
			SAFER_CRITERIA_APPX_PACKAGE = 0x00020,
		}

		/// <summary/>
		[PInvokeData("winsafer.h")]
		public enum SAFER_LEVEL_CREATE_FLAGS
		{
			/// <summary/>
			SAFER_LEVEL_OPEN = 1,
		}

		/// <summary/>
		[PInvokeData("winsafer.h")]
		[Flags]
		public enum SAFER_LEVELID
		{
			/// <summary>
			/// Software cannot access certain resources, such as cryptographic keys and credentials, regardless of the user rights of the user.
			/// </summary>
			SAFER_LEVELID_CONSTRAINED = 0x10000,

			/// <summary>Software will not run, regardless of the user rights of the user.</summary>
			SAFER_LEVELID_DISALLOWED = 0x00000,

			/// <summary>Software user rights are determined by the user rights of the user.</summary>
			SAFER_LEVELID_FULLYTRUSTED = 0x40000,

			/// <summary>
			/// Allows programs to execute as a user that does not have Administrator or Power User user rights. Software can access
			/// resources accessible by normal users.
			/// </summary>
			SAFER_LEVELID_NORMALUSER = 0x20000,

			/// <summary>
			/// Allows programs to execute with access only to resources granted to open well-known groups, blocking access to Administrator
			/// and Power User privileges and personally granted rights.
			/// </summary>
			SAFER_LEVELID_UNTRUSTED = 0x01000,
		}

		/// <summary>The <c>SAFER_OBJECT_INFO_CLASS</c> enumeration type defines the type of information requested about a Safer object.</summary>
		/// <remarks>The <c>SAFER_OBJECT_INFO_CLASS</c> enumeration type is used by the SaferGetLevelInformation function.</remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winsafer/ne-winsafer-_safer_object_info_class typedef enum
		// _SAFER_OBJECT_INFO_CLASS { SaferObjectLevelId, SaferObjectScopeId, SaferObjectFriendlyName, SaferObjectDescription,
		// SaferObjectBuiltin, SaferObjectDisallowed, SaferObjectDisableMaxPrivilege, SaferObjectInvertDeletedPrivileges,
		// SaferObjectDeletedPrivileges, SaferObjectDefaultOwner, SaferObjectSidsToDisable, SaferObjectRestrictedSidsInverted,
		// SaferObjectRestrictedSidsAdded, SaferObjectAllIdentificationGuids, SaferObjectSingleIdentification, SaferObjectExtendedError } SAFER_OBJECT_INFO_CLASS;
		[PInvokeData("winsafer.h", MSDNShortId = "31de9e42-6795-433a-937f-c4243e4961df")]
		public enum SAFER_OBJECT_INFO_CLASS
		{
			/// <summary>The LEVELID constant.</summary>
			[CorrespondingType(typeof(SAFER_LEVELID), CorrespondingAction.GetSet)]
			SaferObjectLevelId = 1,

			/// <summary>The user or machine scope.</summary>
			[CorrespondingType(typeof(SAFER_SCOPEID), CorrespondingAction.GetSet)]
			SaferObjectScopeId,

			/// <summary>The display name.</summary>
			[CorrespondingType(typeof(string), CorrespondingAction.GetSet)]
			SaferObjectFriendlyName,

			/// <summary>The description.</summary>
			[CorrespondingType(typeof(string), CorrespondingAction.GetSet)]
			SaferObjectDescription,

			/// <summary/>
			[CorrespondingType(typeof(uint), CorrespondingAction.Get)]
			SaferObjectBuiltin,

			/// <summary/>
			[CorrespondingType(typeof(uint), CorrespondingAction.Get)]
			SaferObjectDisallowed,

			/// <summary/>
			[CorrespondingType(typeof(uint), CorrespondingAction.Get)]
			SaferObjectDisableMaxPrivilege,

			/// <summary/>
			[CorrespondingType(typeof(uint), CorrespondingAction.Get)]
			SaferObjectInvertDeletedPrivileges,

			/// <summary/>
			[CorrespondingType(typeof(TOKEN_PRIVILEGES), CorrespondingAction.Get)]
			SaferObjectDeletedPrivileges,

			/// <summary/>
			[CorrespondingType(typeof(TOKEN_OWNER), CorrespondingAction.Get)]
			SaferObjectDefaultOwner,

			/// <summary/>
			[CorrespondingType(typeof(TOKEN_GROUPS), CorrespondingAction.Get)]
			SaferObjectSidsToDisable,

			/// <summary/>
			[CorrespondingType(typeof(TOKEN_GROUPS), CorrespondingAction.Get)]
			SaferObjectRestrictedSidsInverted,

			/// <summary/>
			[CorrespondingType(typeof(TOKEN_GROUPS), CorrespondingAction.Get)]
			SaferObjectRestrictedSidsAdded,

			/// <summary>Queries for all levels.</summary>
			[CorrespondingType(typeof(IntPtr), CorrespondingAction.Get)]
			SaferObjectAllIdentificationGuids,

			/// <summary>Queries for a single additional rule.</summary>
			[CorrespondingType(typeof(IntPtr), CorrespondingAction.GetSet)]
			SaferObjectSingleIdentification,

			/// <summary>Queries for additional error codes set during rule processing.</summary>
			[CorrespondingType(typeof(Win32Error), CorrespondingAction.Get)]
			SaferObjectExtendedError,
		}

		/// <summary>The <c>SAFER_POLICY_INFO_CLASS</c> enumeration type defines the ways in which a policy may be queried.</summary>
		/// <remarks>The <c>SAFER_POLICY_INFO_CLASS</c> enumeration type is used by the SaferGetPolicyInformation function.</remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winsafer/ne-winsafer-_safer_policy_info_class typedef enum
		// _SAFER_POLICY_INFO_CLASS { SaferPolicyLevelList, SaferPolicyEnableTransparentEnforcement, SaferPolicyDefaultLevel,
		// SaferPolicyEvaluateUserScope, SaferPolicyScopeFlags, SaferPolicyDefaultLevelFlags, SaferPolicyAuthenticodeEnabled } SAFER_POLICY_INFO_CLASS;
		[PInvokeData("winsafer.h", MSDNShortId = "e1438a9f-abca-463d-8a3a-3a820cba16e8")]
		public enum SAFER_POLICY_INFO_CLASS
		{
			/// <summary>The list of all levels defined in a policy.</summary>
			[CorrespondingType(typeof(uint[]), CorrespondingAction.GetSet)]
			SaferPolicyLevelList = 1,

			/// <summary>Determines whether DLL checking is enabled.</summary>
			[CorrespondingType(typeof(uint), CorrespondingAction.GetSet)]
			SaferPolicyEnableTransparentEnforcement,

			/// <summary>The default policy level.</summary>
			[CorrespondingType(typeof(SAFER_LEVELID), CorrespondingAction.GetSet)]
			SaferPolicyDefaultLevel,

			/// <summary>Determines whether user scope rules should be consulted during policy evaluation.</summary>
			[CorrespondingType(typeof(uint), CorrespondingAction.GetSet)]
			SaferPolicyEvaluateUserScope,

			/// <summary>Determines whether the policy is to skip members of the local administrators group.</summary>
			[CorrespondingType(typeof(uint), CorrespondingAction.GetSet)]
			SaferPolicyScopeFlags,

			/// <summary/>
			[CorrespondingType(typeof(uint), CorrespondingAction.Get)]
			SaferPolicyDefaultLevelFlags,

			/// <summary/>
			[CorrespondingType(typeof(uint), CorrespondingAction.Get)]
			SaferPolicyAuthenticodeEnabled,
		}

		/// <summary>The scope of the created level.</summary>
		[PInvokeData("winsafer.h")]
		public enum SAFER_SCOPEID
		{
			/// <summary>The scope of the created level is by computer.</summary>
			SAFER_SCOPEID_MACHINE = 1,

			/// <summary>The scope of the created level is by user.</summary>
			SAFER_SCOPEID_USER = 2,
		}

		/// <summary>Specifies the behavior of <see cref="SaferComputeTokenFromLevel"/>.</summary>
		[PInvokeData("winsafer.h", MSDNShortId = "39406331-3101-48f2-8b92-e049849b2b38")]
		[Flags]
		public enum SAFER_TOKEN_FLAGS
		{
			/// <summary>
			/// If the OutAccessToken parameter is not more restrictive than the InAccessToken parameter, the OutAccessToken parameter
			/// returns NULL.
			/// </summary>
			SAFER_TOKEN_NULL_IF_EQUAL = 1,

			/// <summary>
			/// The token specified by the InAccessToken parameter is compared with the token that would be created if the restrictions
			/// specified by the LevelHandle parameter were applied. The restricted token is not actually created.
			/// <para>On output, the value of the lpReserved parameter specifies the result of the comparison.</para>
			/// </summary>
			SAFER_TOKEN_COMPARE_ONLY = 2,

			/// <summary>
			/// If this flag is set, the system does not check AppLocker rules or apply Software Restriction Policies. For AppLocker, this
			/// flag disables checks for all four rule collections: Executable, Windows Installer, Script, and DLL.
			/// <para>Set this flag when creating a setup program that must run extracted DLLs during installation.</para>
			/// <para>A token can be queried for existence of this flag by using GetTokenInformation.</para>
			/// <para>Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: AppLocker is not supported.</para>
			/// </summary>
			SAFER_TOKEN_MAKE_INERT = 4,

			/// <summary>On output, the value of the lpReserved parameter specifies the set of flags used to create the restricted token.</summary>
			SAFER_TOKEN_WANT_FLAGS = 8,
		}

		/// <summary>
		/// The <c>SaferCloseLevel</c> function closes a SAFER_LEVEL_HANDLE that was opened by using the SaferIdentifyLevel function or the
		/// SaferCreateLevel function.
		/// </summary>
		/// <param name="hLevelHandle">The SAFER_LEVEL_HANDLE to be closed.</param>
		/// <returns><c>TRUE</c> if the function succeeds; otherwise, <c>FALSE</c>. For extended error information, call GetLastError.</returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winsafer/nf-winsafer-safercloselevel BOOL SaferCloseLevel( SAFER_LEVEL_HANDLE
		// hLevelHandle );
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winsafer.h", MSDNShortId = "8daffb35-5bb0-45b3-aff1-a8ea6a142ba5")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SaferCloseLevel(SAFER_LEVEL_HANDLE hLevelHandle);

		/// <summary>The <c>SaferComputeTokenFromLevel</c> function restricts a token using restrictions specified by a SAFER_LEVEL_HANDLE.</summary>
		/// <param name="LevelHandle">
		/// <c>SAFER_LEVEL_HANDLE</c> that contains the restrictions to place on the input token. Do not pass handles with a LevelId of
		/// <c>SAFER_LEVELID_FULLYTRUSTED</c> or <c>SAFER_LEVELID_DISALLOWED</c> to this function. This is because
		/// <c>SAFER_LEVELID_FULLYTRUSTED</c> is unrestricted and <c>SAFER_LEVELID_DISALLOWED</c> does not contain a token.
		/// </param>
		/// <param name="InAccessToken">
		/// Token to be restricted. If this parameter is <c>NULL</c>, the token of the current thread will be used. If the current thread
		/// does not contain a token, the token of the current process is used.
		/// </param>
		/// <param name="OutAccessToken">The resulting restricted token.</param>
		/// <param name="dwFlags">
		/// <para>
		/// Specifies the behavior of the method. The value can be <c>NULL</c> or one or more of the following values combined by using a
		/// bitwise- <c>OR</c> operation.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SAFER_TOKEN_NULL_IF_EQUAL 1 (0x1)</term>
		/// <term>
		/// If the OutAccessToken parameter is not more restrictive than the InAccessToken parameter, the OutAccessToken parameter returns NULL.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SAFER_TOKEN_COMPARE_ONLY 2 (0x2)</term>
		/// <term>
		/// The token specified by the InAccessToken parameter is compared with the token that would be created if the restrictions specified
		/// by the LevelHandle parameter were applied. The restricted token is not actually created. On output, the value of the lpReserved
		/// parameter specifies the result of the comparison.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SAFER_TOKEN_MAKE_INERT 4 (0x4)</term>
		/// <term>
		/// If this flag is set, the system does not check AppLocker rules or apply Software Restriction Policies. For AppLocker, this flag
		/// disables checks for all four rule collections: Executable, Windows Installer, Script, and DLL. Set this flag when creating a
		/// setup program that must run extracted DLLs during installation. A token can be queried for existence of this flag by using
		/// GetTokenInformation. Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP: AppLocker is not supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SAFER_TOKEN_WANT_FLAGS 8 (0x8)</term>
		/// <term>On output, the value of the lpReserved parameter specifies the set of flags used to create the restricted token.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="lpReserved">
		/// <para>
		/// If the <c>SAFER_TOKEN_COMPARE_ONLY</c> flag is set, this parameter, on output, specifies the result of the token comparison. The
		/// output value is an <c>LPDWORD</c>. A value of –1 indicates that the resulting token would be less privileged than the token
		/// specified by the InAccessToken parameter.
		/// </para>
		/// <para>
		/// If the <c>SAFER_TOKEN_WANT_FLAGS</c> flag is set, and the <c>SAFER_TOKEN_COMPARE_ONLY</c> flag is not set, this parameter is an
		/// <c>LPDWORD</c> value that specifies the flags used to create the restricted token.
		/// </para>
		/// </param>
		/// <returns><c>TRUE</c> if the function succeeds; otherwise, <c>FALSE</c>. For extended information, call GetLastError.</returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winsafer/nf-winsafer-safercomputetokenfromlevel BOOL
		// SaferComputeTokenFromLevel( SAFER_LEVEL_HANDLE LevelHandle, HANDLE InAccessToken, PHANDLE OutAccessToken, DWORD dwFlags, LPVOID
		// lpReserved );
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winsafer.h", MSDNShortId = "39406331-3101-48f2-8b92-e049849b2b38")]
		// [return: MarshalAs(UnmanagedType.Bool)] public static extern bool SaferComputeTokenFromLevel(SAFER_LEVEL_HANDLE LevelHandle,
		// HANDLE InAccessToken, ref IntPtr OutAccessToken, uint dwFlags, IntPtr lpReserved);
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SaferComputeTokenFromLevel(SAFER_LEVEL_HANDLE LevelHandle, HTOKEN InAccessToken, out SafeHTOKEN OutAccessToken, SAFER_TOKEN_FLAGS dwFlags, out uint lpReserved);

		/// <summary>The <c>SaferCreateLevel</c> function opens a SAFER_LEVEL_HANDLE.</summary>
		/// <param name="dwScopeId">
		/// <para>The scope of the level to be created. The following table shows the possible values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SAFER_SCOPEID_MACHINE 1</term>
		/// <term>The scope of the created level is by computer.</term>
		/// </item>
		/// <item>
		/// <term>SAFER_SCOPEID_USER 2</term>
		/// <term>The scope of the created level is by user.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="dwLevelId">
		/// <para>The level of the handle to be opened. The following table shows the possible values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SAFER_LEVELID_CONSTRAINED 0x10000</term>
		/// <term>
		/// Software cannot access certain resources, such as cryptographic keys and credentials, regardless of the user rights of the user.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SAFER_LEVELID_DISALLOWED 0x00000</term>
		/// <term>Software will not run, regardless of the user rights of the user.</term>
		/// </item>
		/// <item>
		/// <term>SAFER_LEVELID_FULLYTRUSTED 0x40000</term>
		/// <term>Software user rights are determined by the user rights of the user.</term>
		/// </item>
		/// <item>
		/// <term>SAFER_LEVELID_NORMALUSER 0x20000</term>
		/// <term>
		/// Allows programs to execute as a user that does not have Administrator or Power User user rights. Software can access resources
		/// accessible by normal users.
		/// </term>
		/// </item>
		/// <item>
		/// <term>SAFER_LEVELID_UNTRUSTED 0x01000</term>
		/// <term>
		/// Allows programs to execute with access only to resources granted to open well-known groups, blocking access to Administrator and
		/// Power User privileges and personally granted rights.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="OpenFlags">
		/// <para>This can be the following value.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SAFER_LEVEL_OPEN 1</term>
		/// <term/>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pLevelHandle">
		/// The returned SAFER_LEVEL_HANDLE. When you have finished using the handle, close it by calling the SaferCloseLevel function.
		/// </param>
		/// <param name="lpReserved">This parameter is reserved for future use. Set it to <c>NULL</c>.</param>
		/// <returns>
		/// <para>Returns nonzero if successful or zero otherwise.</para>
		/// <para>For extended error information, call GetLastError.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winsafer/nf-winsafer-safercreatelevel BOOL SaferCreateLevel( DWORD dwScopeId,
		// DWORD dwLevelId, DWORD OpenFlags, SAFER_LEVEL_HANDLE *pLevelHandle, LPVOID lpReserved );
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winsafer.h", MSDNShortId = "7deb1365-5355-4983-900b-8e4fed009403")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SaferCreateLevel(SAFER_SCOPEID dwScopeId, SAFER_LEVELID dwLevelId, SAFER_LEVEL_CREATE_FLAGS OpenFlags, out SafeSAFER_LEVEL_HANDLE pLevelHandle, IntPtr lpReserved = default);

		/// <summary>The <c>SaferGetLevelInformation</c> function retrieves information about a policy level.</summary>
		/// <param name="LevelHandle">The handle of the level to be queried.</param>
		/// <param name="dwInfoType">
		/// <para>
		/// A SAFER_OBJECT_INFO_CLASS enumeration value that specifies the type of object information that should be returned. The specified
		/// value determines the size and type of the lpQueryBuffer parameter. The following table shows the possible values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SaferObjectLevelId 1</term>
		/// <term>Queries for the LEVELID constant. lpQueryBuffer return type: DWORD.</term>
		/// </item>
		/// <item>
		/// <term>SaferObjectScopeId 2</term>
		/// <term>Queries for the user or machine scope. lpQueryBuffer return type: DWORD.</term>
		/// </item>
		/// <item>
		/// <term>SaferObjectFriendlyName 3</term>
		/// <term>Queries for the display name. lpQueryBuffer return type: LPCWSTR.</term>
		/// </item>
		/// <item>
		/// <term>SaferObjectDescription 4</term>
		/// <term>Queries for the description. lpQueryBuffer return type: LPCWSTR.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="lpQueryBuffer">
		/// A buffer to contain the results of the query. For the type of the returned information for each possible value of the dwInfoType
		/// parameter, see the dwInfoType parameter.
		/// </param>
		/// <param name="dwInBufferSize">The size of the lpQueryBuffer parameter in bytes.</param>
		/// <param name="lpdwOutBufferSize">A pointer to return the output size of the lpQueryBuffer parameter.</param>
		/// <returns><c>TRUE</c> if the function succeeds; otherwise, <c>FALSE</c>. For extended error information, call GetLastError.</returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winsafer/nf-winsafer-safergetlevelinformation BOOL SaferGetLevelInformation(
		// SAFER_LEVEL_HANDLE LevelHandle, SAFER_OBJECT_INFO_CLASS dwInfoType, LPVOID lpQueryBuffer, DWORD dwInBufferSize, LPDWORD
		// lpdwOutBufferSize );
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winsafer.h", MSDNShortId = "cbe73ebc-bf2c-4d39-a203-78ff1a407481")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SaferGetLevelInformation(SAFER_LEVEL_HANDLE LevelHandle, SAFER_OBJECT_INFO_CLASS dwInfoType, IntPtr lpQueryBuffer, uint dwInBufferSize, out uint lpdwOutBufferSize);

		/// <summary>
		/// The <c>SaferGetPolicyInformation</c> function gets information about a policy. You can query to find out more information about
		/// the policy.
		/// </summary>
		/// <param name="dwScopeId">
		/// <para>The scope of the query. The following table shows the possible values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SAFER_SCOPEID_MACHINE 1</term>
		/// <term>The scope of the query is by computer.</term>
		/// </item>
		/// <item>
		/// <term>SAFER_SCOPEID_USER 2</term>
		/// <term>The scope of the query is by user.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="SaferPolicyInfoClass">
		/// <para>
		/// A SAFER_POLICY_INFO_CLASS enumeration value that specifies the type of policy information that should be returned. The specified
		/// value determines the size and type of the InfoBuffer parameter. The following table shows the possible values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SaferPolicyLevelList 1</term>
		/// <term>Queries for the list of all levels defined in a policy. InfoBuffer return type: DWORD array of LevelIds.</term>
		/// </item>
		/// <item>
		/// <term>SaferPolicyEnableTransparentEnforcement 2</term>
		/// <term>Queries for the policy value to determine whether DLL checking is enabled. InfoBuffer return type: DWORD Boolean.</term>
		/// </item>
		/// <item>
		/// <term>SaferPolicyDefaultLevel 3</term>
		/// <term>Queries for the default policy level. InfoBuffer return type: DWORD LevelId.</term>
		/// </item>
		/// <item>
		/// <term>SaferPolicyEvaluateUserScope 4</term>
		/// <term>Queries to determine whether user scope rules should be consulted during policy evaluation. InfoBuffer return type: DWORD.</term>
		/// </item>
		/// <item>
		/// <term>SaferPolicyScopeFlags 5</term>
		/// <term>
		/// Queries to determine whether the policy is to skip members of the local administrators group. InfoBuffer return type: DWORD.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="InfoBufferSize">The size, in bytes, of the InfoBuffer parameter.</param>
		/// <param name="InfoBuffer">
		/// A buffer to contain the results of the query. The size and type of the returned information is determined by the
		/// SaferPolicyInfoClass parameter. For the type of the returned information for each possible value of the SaferPolicyInfoClass
		/// parameter, see the SaferPolicyInfoClass parameter.
		/// </param>
		/// <param name="InfoBufferRetSize">The number of bytes in the InfoBuffer parameter that were filled with policy information.</param>
		/// <param name="lpReserved">Reserved for future use. This parameter should be set to <c>NULL</c>.</param>
		/// <returns><c>TRUE</c> if the function succeeds; otherwise, <c>FALSE</c>. For extended error information, call GetLastError.</returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winsafer/nf-winsafer-safergetpolicyinformation BOOL
		// SaferGetPolicyInformation( DWORD dwScopeId, SAFER_POLICY_INFO_CLASS SaferPolicyInfoClass, DWORD InfoBufferSize, PVOID InfoBuffer,
		// PDWORD InfoBufferRetSize, LPVOID lpReserved );
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winsafer.h", MSDNShortId = "1c69d3c1-87e6-42cd-9acb-4c3d06801401")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SaferGetPolicyInformation(SAFER_SCOPEID dwScopeId, SAFER_POLICY_INFO_CLASS SaferPolicyInfoClass, uint InfoBufferSize, IntPtr InfoBuffer, out uint InfoBufferRetSize, IntPtr lpReserved = default);

		/// <summary>The <c>SaferIdentifyLevel</c> function retrieves information about a level.</summary>
		/// <param name="dwNumProperties">Number of SAFER_CODE_PROPERTIES structures in the pCodeproperties parameter.</param>
		/// <param name="pCodeProperties">
		/// Array of SAFER_CODE_PROPERTIES structures. Each structure contains a code file to be checked and the criteria used to check the file.
		/// </param>
		/// <param name="pLevelHandle">
		/// The returned SAFER_LEVEL_HANDLE. When you have finished using the handle, close it by calling the SaferCloseLevel function.
		/// </param>
		/// <param name="lpReserved">
		/// <para>Reserved for future use. Should be set to <c>NULL</c>.</para>
		/// <para>Beginning with Windows 8 and Windows Server 2012 SRP_POLICY_APPX is defined as Windows Store app.</para>
		/// </param>
		/// <returns><c>TRUE</c> if a SAFER_LEVEL_HANDLE was opened; otherwise, <c>FALSE</c>. For extended error information, call GetLastError.</returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winsafer/nf-winsafer-saferidentifylevel BOOL SaferIdentifyLevel( DWORD
		// dwNumProperties, PSAFER_CODE_PROPERTIES pCodeProperties, SAFER_LEVEL_HANDLE *pLevelHandle, LPVOID lpReserved );
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winsafer.h", MSDNShortId = "f82c4f40-5c37-4f97-95a2-4b2cc26bf41e")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SaferIdentifyLevel(uint dwNumProperties, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] SAFER_CODE_PROPERTIES_V1[] pCodeProperties, out SafeSAFER_LEVEL_HANDLE pLevelHandle, [Optional, MarshalAs(UnmanagedType.LPWStr)] string lpReserved);

		/// <summary>The <c>SaferIdentifyLevel</c> function retrieves information about a level.</summary>
		/// <param name="dwNumProperties">Number of SAFER_CODE_PROPERTIES structures in the pCodeproperties parameter.</param>
		/// <param name="pCodeProperties">
		/// Array of SAFER_CODE_PROPERTIES structures. Each structure contains a code file to be checked and the criteria used to check the file.
		/// </param>
		/// <param name="pLevelHandle">
		/// The returned SAFER_LEVEL_HANDLE. When you have finished using the handle, close it by calling the SaferCloseLevel function.
		/// </param>
		/// <param name="lpReserved">
		/// <para>Reserved for future use. Should be set to <c>NULL</c>.</para>
		/// <para>Beginning with Windows 8 and Windows Server 2012 SRP_POLICY_APPX is defined as Windows Store app.</para>
		/// </param>
		/// <returns><c>TRUE</c> if a SAFER_LEVEL_HANDLE was opened; otherwise, <c>FALSE</c>. For extended error information, call GetLastError.</returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winsafer/nf-winsafer-saferidentifylevel BOOL SaferIdentifyLevel( DWORD
		// dwNumProperties, PSAFER_CODE_PROPERTIES pCodeProperties, SAFER_LEVEL_HANDLE *pLevelHandle, LPVOID lpReserved );
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winsafer.h", MSDNShortId = "f82c4f40-5c37-4f97-95a2-4b2cc26bf41e")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SaferIdentifyLevel(uint dwNumProperties, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] SAFER_CODE_PROPERTIES_V2[] pCodeProperties, out SafeSAFER_LEVEL_HANDLE pLevelHandle, [Optional, MarshalAs(UnmanagedType.LPWStr)] string lpReserved);

		/// <summary>
		/// The <c>SaferiIsExecutableFileType</c> function determines whether a specified file is an executable file. Applications use this
		/// function to determine whether a file is an executable file, and if it is, then the application can take security precautions to
		/// prevent invoking untrustworthy code.
		/// </summary>
		/// <param name="szFullPathname">
		/// Pointer to a <c>null</c>-terminated Unicode character string for the name of the file. The path is optional because only the file
		/// name extension is evaluated. The evaluation of the file name extension is not case-sensitive. This parameter cannot be
		/// <c>NULL</c> or an empty string, and the specified file must include a file name extension.
		/// </param>
		/// <param name="bFromShellExecute">
		/// Boolean value that determines whether .exe files are treated as executable files for the file type evaluation. Set this value to
		/// <c>TRUE</c> to omit .exe files from the evaluation or to <c>FALSE</c> to include them.
		/// </param>
		/// <returns>
		/// <para>If the function successfully recognizes the file name's extension as an executable file type, the return value is <c>TRUE</c>.</para>
		/// <para>If the function fails, or if szFullPath identifies a file name with a nonexecutable extension, the function returns <c>FALSE</c>.</para>
		/// </returns>
		/// <remarks>
		/// <para>The following file name extensions are examples of executable file types. This is not a complete list.</para>
		/// <list type="bullet">
		/// <item>
		/// <term>.bat</term>
		/// </item>
		/// <item>
		/// <term>.cmd</term>
		/// </item>
		/// <item>
		/// <term>.com</term>
		/// </item>
		/// <item>
		/// <term>.exe</term>
		/// </item>
		/// <item>
		/// <term>.js</term>
		/// </item>
		/// <item>
		/// <term>.lnk</term>
		/// </item>
		/// <item>
		/// <term>.pif</term>
		/// </item>
		/// <item>
		/// <term>.pl</term>
		/// </item>
		/// <item>
		/// <term>.shs</term>
		/// </item>
		/// <item>
		/// <term>.url</term>
		/// </item>
		/// <item>
		/// <term>.vbs</term>
		/// </item>
		/// </list>
		/// <para>
		/// The security policy Microsoft Management Console (MMC) snap-in (Secpol.msc) controls which extensions are considered executable
		/// file types.
		/// </para>
		/// <para><c>To view or modify the extensions that are considered executable file types</c></para>
		/// <list type="number">
		/// <item>
		/// <term>Run Secpol.msc.</term>
		/// </item>
		/// <item>
		/// <term>Expand <c>Software Restriction Policies</c>, and then double-click <c>Designated File Types</c>.</term>
		/// </item>
		/// </list>
		/// <para>
		/// <c>Note</c> To view the <c>Designated File Types</c> property page, you may need to create the <c>Software Restriction
		/// Policies</c> node. To create the <c>Software Restriction Policies</c> node, follow the instructions that appear when you expand
		/// <c>Software Restriction Policies</c>.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winsafer/nf-winsafer-saferiisexecutablefiletype BOOL
		// SaferiIsExecutableFileType( LPCWSTR szFullPathname, BOOLEAN bFromShellExecute );
		[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("winsafer.h", MSDNShortId = "f122ceaa-65bb-4cfe-a760-adf4f910c487")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SaferiIsExecutableFileType([MarshalAs(UnmanagedType.LPWStr)] string szFullPathname, [MarshalAs(UnmanagedType.U1)] bool bFromShellExecute);

		/// <summary>
		/// <para>Gets the level of a hash identification rule that matches the specified hash.</para>
		/// <para>
		/// This function has no associated import library and is not declared in a public header. You must define a function pointer with
		/// the signature of this function, and you must use the <c>LoadLibrary</c> and <c>GetProcAddress</c> functions to dynamically link
		/// to Advapi32.dll.
		/// </para>
		/// <para>We recommend using the <c>SaferIdentifyLevel</c> function to evaluate software restriction policies.</para>
		/// </summary>
		/// <param name="HashAlgorithm">The identifier of the algorithm used to create the hash.</param>
		/// <param name="pHashBytes">A pointer to an array of bytes that contains the hash.</param>
		/// <param name="dwHashSize">The size, in bytes, of the pHashBytes array.</param>
		/// <param name="dwOriginalImageSize">The size, in bytes, of the original image from which the hash was computed.</param>
		/// <param name="pdwFoundLevel">A pointer to the level identifier for the matching hash identification rule.</param>
		/// <param name="pdwSaferFlags">Reserved. Set this value to zero.</param>
		/// <returns><c>TRUE</c> if the function is successful; otherwise, <c>FALSE</c>.</returns>
		// https://docs.microsoft.com/en-us/windows/desktop/DevNotes/saferisearchmatchinghashrules BOOL WINAPI SaferiSearchMatchingHashRules(
		// _In_opt_ ALG_ID HashAlgorithm, _In_ PBYTE pHashBytes, _In_ DWORD dwHashSize, _In_opt_ DWORD dwOriginalImageSize, _Out_ PDWORD
		// pdwFoundLevel, PDWORD pdwSaferFlags );
		[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("", MSDNShortId = "1592c8da-31c0-45fb-b832-d439dd53c277")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SaferiSearchMatchingHashRules(ALG_ID HashAlgorithm, byte[] pHashBytes, uint dwHashSize, uint dwOriginalImageSize, out SAFER_LEVELID pdwFoundLevel, IntPtr pdwSaferFlags = default);

		/// <summary>The <c>SaferRecordEventLogEntry</c> function saves messages to an event log.</summary>
		/// <param name="hLevel">SAFER_LEVEL_HANDLE that contains the details of the rule to send to the event log.</param>
		/// <param name="szTargetPath">Path of the file that attempted to run.</param>
		/// <param name="lpReserved">Reserved for future use. This parameter should be set to <c>NULL</c>.</param>
		/// <returns><c>TRUE</c> if the function succeeds; otherwise, <c>FALSE</c>. For extended error information, call GetLastError.</returns>
		/// <remarks>
		/// If SaferIdentifyLevel returns a SAFER_LEVEL_HANDLE with a LevelId that is anything other than SAFER_LEVELID_FULLYTRUSTED
		/// (0x40000), <c>SaferRecordEventLogEntry</c> can be called to facilitate troubleshooting. For example, clicking a button in
		/// excel.exe might attempt to launch another process that is not fully trusted. This might display an obscure error message because
		/// the program remapped the error returned from CreateProcess. To ease troubleshooting, some Safer functions call
		/// <c>SaferRecordEventLogEntry</c> to send an event to the event log.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winsafer/nf-winsafer-saferrecordeventlogentry BOOL SaferRecordEventLogEntry(
		// SAFER_LEVEL_HANDLE hLevel, LPCWSTR szTargetPath, LPVOID lpReserved );
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winsafer.h", MSDNShortId = "7eb48f80-3a57-46ec-aca1-6ff8c1c514c6")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SaferRecordEventLogEntry(SAFER_LEVEL_HANDLE hLevel, [MarshalAs(UnmanagedType.LPWStr)] string szTargetPath, IntPtr lpReserved = default);

		/// <summary>The <c>SaferSetLevelInformation</c> function sets the information about a policy level.</summary>
		/// <param name="LevelHandle">The handle of the level to be set.</param>
		/// <param name="dwInfoType">
		/// <para>
		/// A SAFER_OBJECT_INFO_CLASS enumeration value that specifies the type of object information that should be set. The specified value
		/// determines the size and type of the lpQueryBuffer parameter. The following table shows the possible values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SaferObjectLevelId 1</term>
		/// <term>Sets the LEVELID constant. lpQueryBuffer return type: DWORD.</term>
		/// </item>
		/// <item>
		/// <term>SaferObjectScopeId 2</term>
		/// <term>Sets the user or machine scope. lpQueryBuffer return type: DWORD.</term>
		/// </item>
		/// <item>
		/// <term>SaferObjectFriendlyName 3</term>
		/// <term>Sets the display name. lpQueryBuffer return type: LPCWSTR.</term>
		/// </item>
		/// <item>
		/// <term>SaferObjectDescription 4</term>
		/// <term>Sets the description. lpQueryBuffer return type: LPCWSTR.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="lpQueryBuffer">
		/// A buffer to contain the results of the query. For the type of the returned information for each possible value of the dwInfoType
		/// parameter, see the dwInfoType parameter.
		/// </param>
		/// <param name="dwInBufferSize">The size, in bytes, of the lpQueryBuffer parameter.</param>
		/// <returns><c>TRUE</c> if the function succeeds; otherwise, <c>FALSE</c>. For extended error information, call GetLastError.</returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winsafer/nf-winsafer-safersetlevelinformation BOOL SaferSetLevelInformation(
		// SAFER_LEVEL_HANDLE LevelHandle, SAFER_OBJECT_INFO_CLASS dwInfoType, LPVOID lpQueryBuffer, DWORD dwInBufferSize );
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winsafer.h", MSDNShortId = "8DB13F94-1736-4C05-B072-BFBFC076A726")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SaferSetLevelInformation(SAFER_LEVEL_HANDLE LevelHandle, SAFER_OBJECT_INFO_CLASS dwInfoType, IntPtr lpQueryBuffer, uint dwInBufferSize);

		/// <summary>The <c>SaferSetPolicyInformation</c> function sets the global policy controls.</summary>
		/// <param name="dwScopeId">
		/// <para>The scope of the query. The following table shows the possible values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SAFER_SCOPEID_MACHINE 1</term>
		/// <term>The scope of the query is by computer.</term>
		/// </item>
		/// <item>
		/// <term>SAFER_SCOPEID_USER 2</term>
		/// <term>The scope of the query is by user.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="SaferPolicyInfoClass">
		/// <para>
		/// A SAFER_POLICY_INFO_CLASS enumeration value that specifies the type of policy information that should be set. The specified value
		/// determines the size and type of the InfoBuffer parameter. The following table shows the possible values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>SaferPolicyLevelList 1</term>
		/// <term>Sets the list of all levels defined in a policy. InfoBuffer return type: DWORD array of LevelIds.</term>
		/// </item>
		/// <item>
		/// <term>SaferPolicyEnableTransparentEnforcement 2</term>
		/// <term>Sets the policy value to determine whether DLL checking is enabled. InfoBuffer return type: DWORD Boolean.</term>
		/// </item>
		/// <item>
		/// <term>SaferPolicyDefaultLevel 3</term>
		/// <term>Sets the default policy level. InfoBuffer return type: DWORD LevelId.</term>
		/// </item>
		/// <item>
		/// <term>SaferPolicyEvaluateUserScope 4</term>
		/// <term>Sets whether user scope rules should be consulted during policy evaluation. InfoBuffer return type: DWORD.</term>
		/// </item>
		/// <item>
		/// <term>SaferPolicyScopeFlags 5</term>
		/// <term>Sets whether the policy is to skip members of the local administrators group. InfoBuffer return type: DWORD.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="InfoBufferSize">The size, in bytes, of the InfoBuffer parameter.</param>
		/// <param name="InfoBuffer">
		/// A buffer to contain the results of the query. The size and type of the returned information is determined by the
		/// SaferPolicyInfoClass parameter. For the type of the returned information for each possible value of the SaferPolicyInfoClass
		/// parameter, see the SaferPolicyInfoClass parameter.
		/// </param>
		/// <param name="lpReserved">Reserved for future use. This parameter should be set to <c>NULL</c>.</param>
		/// <returns><c>TRUE</c> if the function succeeds; otherwise, <c>FALSE</c>. For extended error information, call GetLastError.</returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winsafer/nf-winsafer-safersetpolicyinformation BOOL
		// SaferSetPolicyInformation( DWORD dwScopeId, SAFER_POLICY_INFO_CLASS SaferPolicyInfoClass, DWORD InfoBufferSize, PVOID InfoBuffer,
		// LPVOID lpReserved );
		[DllImport(Lib.AdvApi32, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("winsafer.h", MSDNShortId = "B8F3AFC4-8CAD-4AD2-AF17-CCE05A315AD8")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool SaferSetPolicyInformation(SAFER_SCOPEID dwScopeId, SAFER_POLICY_INFO_CLASS SaferPolicyInfoClass, uint InfoBufferSize, IntPtr InfoBuffer, IntPtr lpReserved = default);

		/// <summary>
		/// <para>
		/// The <c>SAFER_CODE_PROPERTIES_V1</c> structure contains code image information and criteria to be checked on the code image. An
		/// array of <c>SAFER_CODE_PROPERTIES_V1</c> structures is passed to the SaferIdentifyLevel function.
		/// </para>
		/// <para>
		/// SAFER_CODE_PROPERTIES_V1 does not include the new members for Windows Store app packages. Existing binary callers can distinguish
		/// which version by checking the <c>cbSize</c> member.
		/// </para>
		/// </summary>
		/// <remarks>
		/// SAFER_CODE_PROPERTIES was redefined to include additional members that allow Windows Store app to use the structure. Check the
		/// <c>cbSize</c> member for the appropriate size of the structure and for whether you should use the <c>SAFER_CODE_PROPERTIES</c>
		/// structure or the <c>SAFER_CODE_PROPERTIES_V1</c> structure.
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winsafer/ns-winsafer-safer_code_properties_v1 typedef struct
		// _SAFER_CODE_PROPERTIES_V1 { DWORD cbSize; DWORD dwCheckFlags; LPCWSTR ImagePath; HANDLE hImageFileHandle; DWORD UrlZoneId; BYTE
		// ImageHash[SAFER_MAX_HASH_SIZE]; DWORD dwImageHashSize; LARGE_INTEGER ImageSize; ALG_ID HashAlgorithm; LPBYTE pByteBlock; HWND
		// hWndParent; DWORD dwWVTUIChoice; } SAFER_CODE_PROPERTIES_V1, *PSAFER_CODE_PROPERTIES_V1;
		[PInvokeData("winsafer.h", MSDNShortId = "E09D287B-7223-4CAF-B404-61FB6871B622")]
		[StructLayout(LayoutKind.Sequential)]
		public struct SAFER_CODE_PROPERTIES_V1
		{
			/// <summary>The size, in bytes, of this structure. This is used for future and backward compatibility.</summary>
			public uint cbSize;

			/// <summary>
			/// <para>
			/// The types of criteria considered when evaluating this structure. Some flags might be silently ignored if some or all of their
			/// associated structure elements are not supplied. Specifying zero for this parameter causes the entire structure's contents to
			/// be ignored.
			/// </para>
			/// <para>The following table shows the possible values. These values can be combined by using a bitwise- <c>OR</c> operation.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>SAFER_CRITERIA_IMAGEPATH 0x00001</term>
			/// <term>Check the code image path.</term>
			/// </item>
			/// <item>
			/// <term>SAFER_CRITERIA_IMAGEHASH 0x00004</term>
			/// <term>Check the code hash.</term>
			/// </item>
			/// <item>
			/// <term>SAFER_CRITERIA_AUTHENTICODE 0x00008</term>
			/// <term>
			/// Check the Authenticode signature. If this value is used, either the hImageFileHandle member or the ImagePath member must be set.
			/// </term>
			/// </item>
			/// <item>
			/// <term>SAFER_CRITERIA_URLZONE 0x00010</term>
			/// <term>Check the URL of origin.</term>
			/// </item>
			/// <item>
			/// <term>SAFER_CRITERIA_IMAGEPATH_NT 0x01000</term>
			/// <term>Check the Windows NT image path.</term>
			/// </item>
			/// </list>
			/// </summary>
			public SAFER_CRITERIA dwCheckFlags;

			/// <summary>
			/// A string that specifies the fully qualified path and file name to be used for discrimination checks based on the path. The
			/// image path is also used to open and read the file to identify any other discrimination criteria not supplied in this
			/// structure. This member can be <c>NULL</c>; however, if the <c>dwCheckFlags</c> member includes
			/// <c>SAFER_CRITERIA_AUTHENTICODE</c>, either this member or the <c>hImageFileHandle</c> member must be set.
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string ImagePath;

			/// <summary>
			/// A file handle to a code image with at least GENERIC_READ access. The handle is used instead of explicitly reopening the file
			/// to compute discrimination criteria not supplied in this structure. This member can be <c>NULL</c>; however, if
			/// <c>dwCheckFlags</c> includes <c>SAFER_CRITERIA_AUTHENTICODE</c>, either this member or the <c>ImagePath</c> member must be set.
			/// </summary>
			public HFILE hImageFileHandle;

			/// <summary>
			/// <para>The predetermined Internet Explorer security zones. The following zones are defined:</para>
			/// <list type="bullet">
			/// <item>
			/// <term>URLZONE_LOCAL_MACHINE</term>
			/// </item>
			/// <item>
			/// <term>URLZONE_INTRANET</term>
			/// </item>
			/// <item>
			/// <term>URLZONE_TRUSTED</term>
			/// </item>
			/// <item>
			/// <term>URLZONE_INTERNET</term>
			/// </item>
			/// <item>
			/// <term>URLZONE_UNTRUSTED</term>
			/// </item>
			/// </list>
			/// <para>This member can be set to 0.</para>
			/// </summary>
			public URLZONE UrlZoneId;

			/// <summary>
			/// <para>
			/// The precomputed hash of the image. The supplied hash is interpreted as valid if both the <c>ImageSize</c> member and the
			/// <c>dwImageHashSize</c> member are nonzero and the <c>HashAlgorithm</c> member contains a valid hashing algorithm from Wincrypt.h.
			/// </para>
			/// <para>If the supplied hash fails to meet these conditions, the hash is automatically recomputed by:</para>
			/// <list type="bullet">
			/// <item>
			/// <term>Using the <c>ImageSize</c> member and the <c>pByteBlock</c> member, if both are nonzero.</term>
			/// </item>
			/// <item>
			/// <term>Using the <c>hImageFileHandle</c> member, if it is not <c>NULL</c>.</term>
			/// </item>
			/// <item>
			/// <term>Opening and using the <c>ImagePath</c> member, if it is not <c>NULL</c>.</term>
			/// </item>
			/// </list>
			/// </summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = SAFER_MAX_HASH_SIZE)]
			public byte[] ImageHash;

			/// <summary>The size, in bytes, of the <c>ImageHash</c> member.</summary>
			public uint dwImageHashSize;

			/// <summary>
			/// The size, in bytes, of the <c>pByteBlock</c> member. This member is not used if the <c>pByteBlock</c> member is <c>NULL</c>.
			/// </summary>
			public long ImageSize;

			/// <summary>The hash algorithm used to create the <c>ImageHash</c> member.</summary>
			public ALG_ID HashAlgorithm;

			/// <summary>
			/// The memory block that contains the image of the code being checked. This member is optional. If this member is specified, the
			/// <c>ImageSize</c> member must also be supplied.
			/// </summary>
			public IntPtr pByteBlock;

			/// <summary>
			/// The arguments used for Authenticode signer certificate verification. These arguments are passed to the WinVerifyTrust
			/// function and control the UI that prompts the user to accept or reject entrusted certificates.
			/// </summary>
			public HWND hWndParent;

			/// <summary>
			/// <para>Indicates the type of UI used. The following table shows the possible values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>WTD_UI_ALL</term>
			/// <term>Display all UI.</term>
			/// </item>
			/// <item>
			/// <term>WTD_UI_NONE</term>
			/// <term>Display no UI.</term>
			/// </item>
			/// <item>
			/// <term>WTD_UI_NOBAD</term>
			/// <term>Display UI only if there were no errors.</term>
			/// </item>
			/// <item>
			/// <term>WTD_UI_NOGOOD</term>
			/// <term>Display UI only if an error occurs.</term>
			/// </item>
			/// </list>
			/// </summary>
			// TODO: Replace with WTD_UI once WinTrust.dll is supported
			public uint dwWVTUIChoice;
		}

		/// <summary>
		/// <para>
		/// The <c>SAFER_CODE_PROPERTIES</c> structure contains code image information and criteria to be checked on the code image. An array
		/// of <c>SAFER_CODE_PROPERTIES</c> structures is passed to the SaferIdentifyLevel function.
		/// </para>
		/// <para>
		/// SAFER_CODE_PROPERTIES_V2 is a redefinition of <c>SAFER_CODE_PROPERTIES</c> and is an extended version of SAFER_CODE_PROPERTIES_V1
		/// because it includes new members for Windows Store app packages. Existing binary callers can distinguish which version by checking
		/// the <c>cbSize</c> member.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/winsafer/ns-winsafer-safer_code_properties_v2 typedef struct
		// _SAFER_CODE_PROPERTIES_V2 { DWORD cbSize; DWORD dwCheckFlags; LPCWSTR ImagePath; HANDLE hImageFileHandle; DWORD UrlZoneId; BYTE
		// ImageHash[SAFER_MAX_HASH_SIZE]; DWORD dwImageHashSize; LARGE_INTEGER ImageSize; ALG_ID HashAlgorithm; LPBYTE pByteBlock; HWND
		// hWndParent; DWORD dwWVTUIChoice; LPCWSTR PackageMoniker; LPCWSTR PackagePublisher; LPCWSTR PackageName; ULONG64 PackageVersion;
		// BOOL PackageIsFramework; } SAFER_CODE_PROPERTIES_V2, *PSAFER_CODE_PROPERTIES_V2;
		[PInvokeData("winsafer.h", MSDNShortId = "039a37a9-1744-4cff-919e-e0da50d7b291")]
		[StructLayout(LayoutKind.Sequential)]
		public struct SAFER_CODE_PROPERTIES_V2
		{
			/// <summary>The size of this structure in bytes. This is used for future and backward compatibility.</summary>
			public uint cbSize;

			/// <summary>
			/// <para>
			/// The types of criteria considered when evaluating this structure. Some flags might be silently ignored if some or all of their
			/// associated structure elements are not supplied. Specifying zero for this parameter causes the entire structure's contents to
			/// be ignored.
			/// </para>
			/// <para>The following table shows the possible values. These values may be combined using a bitwise- <c>OR</c> operation.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>SAFER_CRITERIA_IMAGEPATH 0x00001</term>
			/// <term>Check the code image path.</term>
			/// </item>
			/// <item>
			/// <term>SAFER_CRITERIA_IMAGEHASH 0x00004</term>
			/// <term>Check the code hash.</term>
			/// </item>
			/// <item>
			/// <term>SAFER_CRITERIA_AUTHENTICODE 0x00008</term>
			/// <term>
			/// Check the Authenticode signature. If this value is used, either the hImageFileHandle member or the ImagePath member must be set.
			/// </term>
			/// </item>
			/// <item>
			/// <term>SAFER_CRITERIA_URLZONE 0x00010</term>
			/// <term>Check the URL of origin.</term>
			/// </item>
			/// <item>
			/// <term>SAFER_CRITERIA_IMAGEPATH_NT 0x01000</term>
			/// <term>Check the Windows NT image path.</term>
			/// </item>
			/// <item>
			/// <term>SAFER_CRITERIA_APPX_PACKAGE 0x00020</term>
			/// <term>Check for a Windows Store app package. For use by Windows Store apps.</term>
			/// </item>
			/// </list>
			/// </summary>
			public SAFER_CRITERIA dwCheckFlags;

			/// <summary>
			/// A string specifying the fully qualified path and file name to be used for discrimination checks based on the path. The image
			/// path is also used to open and read the file to identify any other discrimination criteria not supplied in this structure.
			/// This member can be <c>NULL</c>; however, if the <c>dwCheckFlags</c> member includes <c>SAFER_CRITERIA_AUTHENTICODE</c>,
			/// either this member or the <c>hImageFileHandle</c> member must be set.
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string ImagePath;

			/// <summary>
			/// A file handle to a code image with at least GENERIC_READ access. The handle is used instead of explicitly reopening the file
			/// to compute discrimination criteria not supplied in this structure. This member can be <c>NULL</c>; however, if
			/// <c>dwCheckFlags</c> includes <c>SAFER_CRITERIA_AUTHENTICODE</c>, either this member or the <c>ImagePath</c> member must be set.
			/// </summary>
			public HFILE hImageFileHandle;

			/// <summary>
			/// <para>The predetermined Internet Explorer security zones. The following zones are defined:</para>
			/// <list type="bullet">
			/// <item>
			/// <term>URLZONE_LOCAL_MACHINE</term>
			/// </item>
			/// <item>
			/// <term>URLZONE_INTRANET</term>
			/// </item>
			/// <item>
			/// <term>URLZONE_TRUSTED</term>
			/// </item>
			/// <item>
			/// <term>URLZONE_INTERNET</term>
			/// </item>
			/// <item>
			/// <term>URLZONE_UNTRUSTED</term>
			/// </item>
			/// </list>
			/// <para>This member can be set to 0.</para>
			/// </summary>
			public URLZONE UrlZoneId;

			/// <summary>
			/// <para>
			/// The pre-computed hash of the image. The supplied hash is interpreted as valid if both the <c>ImageSize</c> member and the
			/// <c>dwImageHashSize</c> member are nonzero and the <c>HashAlgorithm</c> member contains a valid hashing algorithm from Wincrypt.h.
			/// </para>
			/// <para>If the supplied hash fails to meet these conditions, the hash will be automatically recomputed by:</para>
			/// <list type="bullet">
			/// <item>
			/// <term>Using the <c>ImageSize</c> member and the <c>pByteBlock</c> member if both are nonzero.</term>
			/// </item>
			/// <item>
			/// <term>Using the <c>hImageFileHandle</c> member if it is not <c>NULL</c>.</term>
			/// </item>
			/// <item>
			/// <term>Opening and using the <c>ImagePath</c> member if it is not <c>NULL</c>.</term>
			/// </item>
			/// </list>
			/// </summary>
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = SAFER_MAX_HASH_SIZE)]
			public byte[] ImageHash;

			/// <summary>The size in bytes of the <c>ImageHash</c> member.</summary>
			public uint dwImageHashSize;

			/// <summary>
			/// The size in bytes of the <c>pByteBlock</c> member. This member is not used if the <c>pByteBlock</c> member is <c>NULL</c>.
			/// </summary>
			public long ImageSize;

			/// <summary>The hash algorithm used to create the <c>ImageHash</c> member.</summary>
			public ALG_ID HashAlgorithm;

			/// <summary>
			/// The memory block containing the image of the code being checked. This member is optional. If this member is specified, the
			/// <c>ImageSize</c> member must also be supplied.
			/// </summary>
			public IntPtr pByteBlock;

			/// <summary>
			/// The arguments used for Authenticode signer certificate verification. These arguments are passed to the WinVerifyTrust
			/// function and control the user interface (UI) that prompts the user to accept or reject entrusted certificates.
			/// </summary>
			public HWND hWndParent;

			/// <summary>
			/// <para>Indicates the type of UI used. The following table shows the possible values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>WTD_UI_ALL</term>
			/// <term>Display all UI.</term>
			/// </item>
			/// <item>
			/// <term>WTD_UI_NONE</term>
			/// <term>Display no UI.</term>
			/// </item>
			/// <item>
			/// <term>WTD_UI_NOBAD</term>
			/// <term>Display UI only if there were no errors.</term>
			/// </item>
			/// <item>
			/// <term>WTD_UI_NOGOOD</term>
			/// <term>Display UI only if an error occurs.</term>
			/// </item>
			/// </list>
			/// </summary>
			// TODO: Replace with WTD_UI once WinTrust.dll is supported
			public uint dwWVTUIChoice;

			/// <summary>
			/// <para>The package moniker property. For use by Windows Store apps.</para>
			/// <para>
			/// <c>Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:</c> This member
			/// is not available.
			/// </para>
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string PackageMoniker;

			/// <summary>
			/// <para>The package publisher property. For use by Windows Store apps.</para>
			/// <para>
			/// <c>Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:</c> This member
			/// is not available.
			/// </para>
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string PackagePublisher;

			/// <summary>
			/// <para>The package name property. For use by Windows Store apps.</para>
			/// <para>
			/// <c>Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:</c> This member
			/// is not available.
			/// </para>
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string PackageName;

			/// <summary>
			/// <para>The package version property. For use by Windows Store apps.</para>
			/// <para>
			/// <c>Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:</c> This member
			/// is not available.
			/// </para>
			/// </summary>
			public ulong PackageVersion;

			/// <summary>
			/// <para>The package is a framework package. For use by Windows Store apps.</para>
			/// <para>
			/// <c>Windows Server 2008 R2, Windows 7, Windows Server 2008, Windows Vista, Windows Server 2003 and Windows XP:</c> This member
			/// is not available.
			/// </para>
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool PackageIsFramework;
		}

		/// <summary>Provides a handle to a safer level.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct SAFER_LEVEL_HANDLE : IHandle
		{
			private readonly IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="SAFER_LEVEL_HANDLE"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public SAFER_LEVEL_HANDLE(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="SAFER_LEVEL_HANDLE"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static SAFER_LEVEL_HANDLE NULL => new SAFER_LEVEL_HANDLE(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="SAFER_LEVEL_HANDLE"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(SAFER_LEVEL_HANDLE h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="SAFER_LEVEL_HANDLE"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator SAFER_LEVEL_HANDLE(IntPtr h) => new SAFER_LEVEL_HANDLE(h);

			/// <summary>Implements the operator !=.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(SAFER_LEVEL_HANDLE h1, SAFER_LEVEL_HANDLE h2) => !(h1 == h2);

			/// <summary>Implements the operator ==.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(SAFER_LEVEL_HANDLE h1, SAFER_LEVEL_HANDLE h2) => h1.Equals(h2);

			/// <inheritdoc/>
			public override bool Equals(object obj) => obj is SAFER_LEVEL_HANDLE h ? handle == h.handle : false;

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
		}

		/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="SAFER_LEVEL_HANDLE"/> that is disposed using <see cref="SaferCloseLevel"/>.</summary>
		public class SafeSAFER_LEVEL_HANDLE : SafeHANDLE
		{
			/// <summary>Initializes a new instance of the <see cref="SafeSAFER_LEVEL_HANDLE"/> class and assigns an existing handle.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafeSAFER_LEVEL_HANDLE(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>Initializes a new instance of the <see cref="SafeSAFER_LEVEL_HANDLE"/> class.</summary>
			private SafeSAFER_LEVEL_HANDLE() : base() { }

			/// <summary>Performs an implicit conversion from <see cref="SafeSAFER_LEVEL_HANDLE"/> to <see cref="SAFER_LEVEL_HANDLE"/>.</summary>
			/// <param name="h">The safe handle instance.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator SAFER_LEVEL_HANDLE(SafeSAFER_LEVEL_HANDLE h) => h.handle;

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() => SaferCloseLevel(handle);
		}
	}
}