using System;
using System.Runtime.InteropServices;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.Crypt32;
using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;

namespace Vanara.PInvoke
{
	public static partial class WinTrust
	{
		/// <summary>Action to perform.</summary>
		[PInvokeData("wintrust.h", MSDNShortId = "B2ED5489-792F-4B00-A21E-EE1B1462D1C8")]
		public enum DWACTION
		{
			/// <summary>Allocate memory and fill the CRYPT_PROVIDER_DEFUSAGE structure pointed to by the psUsage parameter.</summary>
			DWACTION_ALLOCANDFILL = 1,

			/// <summary>
			/// Free all memory allocated during a previous call to this function by specifying DWACTION_ALLOCANDFILL for this parameter.
			/// </summary>
			DWACTION_FREE = 2
		}

		/// <summary>Specifies the type of certificate.</summary>
		[PInvokeData("wintrust.h", MSDNShortId = "AC666871-265B-4D09-B7A6-DEC48D4645FD")]
		public enum WIN_CERT_TYPE : ushort
		{
			/// <summary>The bCertificate member contains an X.509 certificate.</summary>
			WIN_CERT_TYPE_X509 = 0x0001,

			/// <summary>The bCertificate member contains a PKCS SignedData structure.</summary>
			WIN_CERT_TYPE_PKCS_SIGNED_DATA = 0x0002,

			/// <summary>Reserved.</summary>
			WIN_CERT_TYPE_RESERVED_1 = 0x0003,

			/// <summary>The bCertificate member contains PKCS1_MODULE_SIGN fields.</summary>
			WIN_CERT_TYPE_TS_STACK_SIGNED = 0x0004,
		}

		/// <summary>A set of flags that modify the behavior of this function.</summary>
		[PInvokeData("wintrust.h", MSDNShortId = "5e4dbccd-4cd0-4525-85dc-3327a5b713a1")]
		[Flags]
		public enum WT_TRUSTDBDIALOG
		{
			WT_TRUSTDBDIALOG_NO_UI_FLAG = 0x00000001,

			/// <summary>
			/// Only display the Trusted Publisher tab. By default, all of the user interface tabs are displayed and the Trusted Publisher
			/// tab is initially selected.
			/// </summary>
			WT_TRUSTDBDIALOG_ONLY_PUB_TAB_FLAG = 0x00000002,

			WT_TRUSTDBDIALOG_WRITE_LEGACY_REG_FLAG = 0x00000100,
			WT_TRUSTDBDIALOG_WRITE_IEAK_STORE_FLAG = 0x00000200,
		}

		/// <summary>Specifies the union member to be used and, thus, the type of object for which trust will be verified.</summary>
		[PInvokeData("wintrust.h", MSDNShortId = "8fb68f44-6f69-4eac-90de-02689e3e86cf")]
		public enum WTD_CHOICE
		{
			/// <summary>Use the file pointed to by pFile.</summary>
			WTD_CHOICE_FILE = 1,

			/// <summary>Use the catalog pointed to by pCatalog.</summary>
			WTD_CHOICE_CATALOG = 2,

			/// <summary>Use the BLOB pointed to by pBlob.</summary>
			WTD_CHOICE_BLOB = 3,

			/// <summary>Use the WINTRUST_SGNR_INFO structure pointed to by pSgnr.</summary>
			WTD_CHOICE_SIGNER = 4,

			/// <summary>Use the certificate pointed to by pCert.</summary>
			WTD_CHOICE_CERT = 5,
		}

		/// <summary>
		/// Certificate revocation check options. This member can be set to add revocation checking to that done by the selected policy provider.
		/// </summary>
		[PInvokeData("wintrust.h", MSDNShortId = "8fb68f44-6f69-4eac-90de-02689e3e86cf")]
		public enum WTD_REVOKE
		{
			/// <summary>
			/// No additional revocation checking will be done when the WTD_REVOKE_NONE flag is used in conjunction with the HTTPSPROV_ACTION
			/// value set in the pgActionID parameter of the WinVerifyTrust function. To ensure the WinVerifyTrust function does not attempt
			/// any network retrieval when verifying code signatures, WTD_CACHE_ONLY_URL_RETRIEVAL must be set in the dwProvFlags parameter.
			/// </summary>
			WTD_REVOKE_NONE = 0x00000000,

			/// <summary>Revocation checking will be done on the whole chain.</summary>
			WTD_REVOKE_WHOLECHAIN = 0x00000001,
		}

		/// <summary>Specifies the action to be taken.</summary>
		[PInvokeData("wintrust.h", MSDNShortId = "8fb68f44-6f69-4eac-90de-02689e3e86cf")]
		public enum WTD_STATEACTION
		{
			/// <summary>Ignore the hWVTStateData member.</summary>
			WTD_STATEACTION_IGNORE = 0x00000000,

			/// <summary>
			/// Verify the trust of the object (typically a file) that is specified by the dwUnionChoice member. The hWVTStateData member
			/// will receive a handle to the state data. This handle must be freed by specifying the WTD_STATEACTION_CLOSE action in a
			/// subsequent call.
			/// </summary>
			WTD_STATEACTION_VERIFY = 0x00000001,

			/// <summary>
			/// Free the hWVTStateData member previously allocated with the WTD_STATEACTION_VERIFY action. This action must be specified for
			/// every use of the WTD_STATEACTION_VERIFY action.
			/// </summary>
			WTD_STATEACTION_CLOSE = 0x00000002,

			/// <summary>
			/// Write the catalog data to a WINTRUST_DATA structure and then cache that structure. This action only applies when the
			/// dwUnionChoice member contains WTD_CHOICE_CATALOG.
			/// </summary>
			WTD_STATEACTION_AUTO_CACHE = 0x00000003,

			/// <summary>Flush any cached catalog data. This action only applies when the dwUnionChoice member contains WTD_CHOICE_CATALOG.</summary>
			WTD_STATEACTION_AUTO_CACHE_FLUSH = 0x00000004,
		}

		/// <summary>DWORD value that specifies trust provider settings.</summary>
		[PInvokeData("wintrust.h", MSDNShortId = "8fb68f44-6f69-4eac-90de-02689e3e86cf")]
		public enum WTD_TRUST
		{
			/// <summary>The trust is verified in the same manner as implemented by Internet Explorer 4.0.</summary>
			WTD_USE_IE4_TRUST_FLAG = 0x00000001,

			/// <summary>The Internet Explorer 4.0 chain functionality is not used.</summary>
			WTD_NO_IE4_CHAIN_FLAG = 0x00000002,

			/// <summary>
			/// The default verification of the policy provider, such as code signing for Authenticode, is not performed, and the certificate
			/// is assumed valid for all usages.
			/// </summary>
			WTD_NO_POLICY_USAGE_FLAG = 0x00000004,

			/// <summary>Revocation checking is not performed.</summary>
			WTD_REVOCATION_CHECK_NONE = 0x00000010,

			/// <summary>Revocation checking is performed on the end certificate only.</summary>
			WTD_REVOCATION_CHECK_END_CERT = 0x00000020,

			/// <summary>Revocation checking is performed on the entire certificate chain.</summary>
			WTD_REVOCATION_CHECK_CHAIN = 0x00000040,

			/// <summary>Revocation checking is performed on the entire certificate chain, excluding the root certificate.</summary>
			WTD_REVOCATION_CHECK_CHAIN_EXCLUDE_ROOT = 0x00000080,

			/// <summary>Not supported.</summary>
			WTD_SAFER_FLAG = 0x00000100,

			/// <summary>Only the hash is verified.</summary>
			WTD_HASH_ONLY_FLAG = 0x00000200,

			/// <summary>
			/// The default operating system version checking is performed. This flag is only used for verifying catalog-signed files.
			/// </summary>
			WTD_USE_DEFAULT_OSVER_CHECK = 0x00000400,

			/// <summary>
			/// If this flag is not set, all time stamped signatures are considered valid forever. Setting this flag limits the valid
			/// lifetime of the signature to the lifetime of the signing certificate. This allows time stamped signatures to expire.
			/// </summary>
			WTD_LIFETIME_SIGNING_FLAG = 0x00000800,

			/// <summary>
			/// Use only the local cache for revocation checks. Prevents revocation checks over the network.
			/// <para>Windows XP: This value is not supported.</para>
			/// </summary>
			WTD_CACHE_ONLY_URL_RETRIEVAL = 0x00001000,

			/// <summary>
			/// Disable the use of MD2 and MD4 hashing algorithms. If a file is signed by using MD2 or MD4 and if this flag is set, an
			/// NTE_BAD_ALGID error is returned. <note>Note This flag is supported on Windows 7 with SP1 and later operating systems.</note>
			/// </summary>
			WTD_DISABLE_MD2_MD4 = 0x00002000,

			/// <summary>
			/// If this flag is specified it is assumed that the file being verified has been downloaded from the web and has the Mark of the
			/// Web attribute. Policies that are meant to apply to Mark of the Web files will be enforced. <note>Note This flag is supported
			/// on Windows 8.1 and later operating systems or on systems that have installed KB2862966.</note>
			/// </summary>
			WTD_MOTW = 0x00004000,

			/// <summary>Undocumented.</summary>
			WTD_CODE_INTEGRITY_DRIVER_MODE = 0x00008000,
		}

		/// <summary>Specifies the kind of user interface (UI) to be used.</summary>
		[PInvokeData("wintrust.h", MSDNShortId = "8fb68f44-6f69-4eac-90de-02689e3e86cf")]
		public enum WTD_UI
		{
			/// <summary>Display all UI.</summary>
			WTD_UI_ALL = 1,

			/// <summary>Display no UI.</summary>
			WTD_UI_NONE = 2,

			/// <summary>Do not display any negative UI.</summary>
			WTD_UI_NOBAD = 3,

			/// <summary>Do not display any positive UI.</summary>
			WTD_UI_NOGOOD = 4,
		}

		/// <summary>
		/// A DWORD value that specifies the user interface context for the WinVerifyTrust function. This causes the text in the Authenticode
		/// dialog box to match the action taken on the file.
		/// </summary>
		[PInvokeData("wintrust.h", MSDNShortId = "8fb68f44-6f69-4eac-90de-02689e3e86cf")]
		public enum WTD_UICONTEXT
		{
			/// <summary>Use when calling WinVerifyTrust for a file that is to be run. This is the default value.</summary>
			WTD_UICONTEXT_EXECUTE = 0,

			/// <summary>Use when calling WinVerifyTrust for a file that is to be installed.</summary>
			WTD_UICONTEXT_INSTALL = 1,
		}

		/// <summary>Flags for <see cref="WintrustGetRegPolicyFlags"/>.</summary>
		[Flags]
		public enum WTPF
		{
			/// <summary>Trust any test certificate.</summary>
			WTPF_TRUSTTEST = 0x00000020,

			/// <summary>Check any test certificate for validity.</summary>
			WTPF_TESTCANBEVALID = 0x00000080,

			/// <summary>Use expiration date.</summary>
			WTPF_IGNOREEXPIRATION = 0x00000100,

			/// <summary>Do revocation check.</summary>
			WTPF_IGNOREREVOKATION = 0x00000200,

			/// <summary>If the source is offline, trust any individual certificates.</summary>
			WTPF_OFFLINEOK_IND = 0x00000400,

			/// <summary>If the source is offline, trust any commercial certificates.</summary>
			WTPF_OFFLINEOK_COM = 0x00000800,

			/// <summary>If the source is offline, trust any individual certificates. Do not use the user interface (UI).</summary>
			WTPF_OFFLINEOKNBU_IND = 0x00001000,

			/// <summary>If the source is offline, trust any commercial certificates. Do not use the checking UI.</summary>
			WTPF_OFFLINEOKNBU_COM = 0x00002000,

			/// <summary>Turn off verification of version 1.0 certificates.</summary>
			WTPF_VERIFY_V1_OFF = 0x00010000,

			/// <summary>Ignore time stamp revocation checks.</summary>
			WTPF_IGNOREREVOCATIONONTS = 0x00020000,

			/// <summary>Allow only items in personal trust database.</summary>
			WTPF_ALLOWONLYPERTRUST = 0x00040000,
		}

		/// <summary>
		/// <para>The <c>OpenPersonalTrustDBDialog</c> function displays the <c>Certificates</c> dialog box.</para>
		/// <para>
		/// <c>Note</c> This function has no associated header file or import library. You must define the function yourself and use the
		/// LoadLibrary and GetProcAddress functions to dynamically link to Wintrust.dll.
		/// </para>
		/// </summary>
		/// <param name="hwndParent">
		/// The handle of the parent window for the dialog box. If this parameter is <c>NULL</c>, the dialog box has no parent.
		/// </param>
		/// <returns>Returns nonzero if the dialog box was opened successfully or zero otherwise.</returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wintrust/nf-wintrust-openpersonaltrustdbdialog BOOL
		// OpenPersonalTrustDBDialog( HWND hwndParent );
		[DllImport(Lib.Wintrust, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wintrust.h", MSDNShortId = "25f1d012-0c82-4992-b924-b539d4c6dc5f")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool OpenPersonalTrustDBDialog(HWND hwndParent);

		/// <summary>
		/// <para>The <c>OpenPersonalTrustDBDialogEx</c> function displays the <c>Certificates</c> dialog box.</para>
		/// <para>
		/// <c>Note</c> This function has no associated header file or import library. You must define the function yourself and use the
		/// LoadLibrary and GetProcAddress functions to dynamically link to Wintrust.dll.
		/// </para>
		/// </summary>
		/// <param name="hwndParent">
		/// The handle of the parent window for the dialog box. If this parameter is <c>NULL</c>, the dialog box has no parent.
		/// </param>
		/// <param name="dwFlags">
		/// <para>A set of flags that modify the behavior of this function. This can be zero or the following value.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WT_TRUSTDBDIALOG_ONLY_PUB_TAB_FLAG 2 (0x2)</term>
		/// <term>
		/// Only display the Trusted Publisher tab. By default, all of the user interface tabs are displayed and the Trusted Publisher tab is
		/// initially selected.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pvReserved">Not used. Must be <c>NULL</c>.</param>
		/// <returns>Returns nonzero if the dialog box was opened successfully or zero otherwise.</returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wintrust/nf-wintrust-openpersonaltrustdbdialogex BOOL
		// OpenPersonalTrustDBDialogEx( HWND hwndParent, DWORD dwFlags, PVOID *pvReserved );
		[DllImport(Lib.Wintrust, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wintrust.h", MSDNShortId = "5e4dbccd-4cd0-4525-85dc-3327a5b713a1")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool OpenPersonalTrustDBDialogEx(HWND hwndParent, WT_TRUSTDBDIALOG dwFlags, IntPtr pvReserved = default);

		/// <summary>
		/// <para>
		/// [The <c>WintrustAddActionID</c> function is available for use in the operating systems specified in the Requirements section. It
		/// may be altered or unavailable in subsequent versions. For certificate verification, use the CertGetCertificateChain and
		/// CertVerifyCertificateChainPolicy functions. For Microsoft Authenticode technology signature verification, use the .NET Framework.]
		/// </para>
		/// <para>
		/// The <c>WintrustAddActionID</c> function adds a trust provider action to the user's system. This method should be called during
		/// the DllRegisterServer implementation of the trust provider. This function has no associated import library. You must use the
		/// LoadLibrary and GetProcAddress functions to dynamically link to Wintrust.dll.
		/// </para>
		/// <para>This method should be called only by a trust provider.</para>
		/// </summary>
		/// <param name="pgActionID">
		/// <para>A pointer to a <c>GUID</c> structure that identifies the action to add and the trust provider that supports that action.</para>
		/// <para>
		/// The WinTrust service is designed to work with trust providers implemented by third parties. Each trust provider provides its own
		/// unique set of action identifiers. For information about the action identifiers supported by a trust provider, see the
		/// documentation for that trust provider.
		/// </para>
		/// <para>
		/// For example, Microsoft provides a Software Publisher Trust Provider that can establish the trustworthiness of software being
		/// downloaded from the Internet or some other public network. The Software Publisher Trust Provider supports the following action
		/// identifiers. These constants are defined in Softpub.h.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WINTRUST_ACTION_GENERIC_VERIFY</term>
		/// <term>Verify a certificate chain only.</term>
		/// </item>
		/// <item>
		/// <term>WINTRUST_ACTION_GENERIC_VERIFY_V2</term>
		/// <term>Verify a file or object using the Authenticode policy provider.</term>
		/// </item>
		/// <item>
		/// <term>HTTPSPROV_ACTION</term>
		/// <term>Verify an SSL/PCT connection through Internet Explorer.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="fdwFlags">
		/// a value that determines whether registry errors are reported by this function. If fdwFlags is zero and this function experiences
		/// a registry error, the registry error will not be propagated to the GetLastError function. If fdwFlags is
		/// WT_ADD_ACTION_ID_RET_RESULT_FLAG (0x1) and this function experiences a registry error, the registry error will be propagated to
		/// the <c>GetLastError</c> function.
		/// </param>
		/// <param name="psProvInfo">A pointer to the CRYPT_REGISTER_ACTIONID structure that defines the information for the trust provider.</param>
		/// <returns>
		/// The return value is <c>TRUE</c> if the function succeeds; <c>FALSE</c> if the function fails. If the function fails, call the
		/// GetLastError function to determine the reason for failure. For information about any registry errors that this function may
		/// encounter, see the description for fdwFlags.
		/// </returns>
		/// <remarks>To remove an action that has been added by this function, call the WintrustRemoveActionID function.</remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wintrust/nf-wintrust-wintrustaddactionid BOOL WintrustAddActionID( GUID
		// *pgActionID, DWORD fdwFlags, CRYPT_REGISTER_ACTIONID *psProvInfo );
		[DllImport(Lib.Wintrust, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("wintrust.h", MSDNShortId = "3b282342-9c86-42fa-b745-e5194d2885dc")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool WintrustAddActionID(in Guid pgActionID, uint fdwFlags, ref CRYPT_REGISTER_ACTIONID psProvInfo);

		/// <summary>
		/// The <c>WintrustAddDefaultForUsage</c> function specifies the default usage identifier and callback information for a provider.
		/// </summary>
		/// <param name="pszUsageOID">Pointer to a string that contains the identifier.</param>
		/// <param name="psDefUsage">Pointer to a CRYPT_PROVIDER_REGDEFUSAGE structure that contains callback information.</param>
		/// <returns>
		/// The return value is <c>TRUE</c> if the function succeeds; <c>FALSE</c> if the function fails. If the function fails, call the
		/// GetLastError function to determine the reason for failure.
		/// </returns>
		/// <remarks>
		/// <para>
		/// If the provider uses this function and requires any of the callback data, the provider must completely fill out the
		/// CRYPT_PROVIDER_REGDEFUSAGE structure.
		/// </para>
		/// <para>The usage and callback information can be retrieved by calling the WintrustGetDefaultForUsage function.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wintrust/nf-wintrust-wintrustadddefaultforusage BOOL
		// WintrustAddDefaultForUsage( const char *pszUsageOID, CRYPT_PROVIDER_REGDEFUSAGE *psDefUsage );
		[DllImport(Lib.Wintrust, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("wintrust.h", MSDNShortId = "511D05BD-0F8C-45B8-A1B0-D3C7AAFECCFC")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool WintrustAddDefaultForUsage([MarshalAs(UnmanagedType.LPStr)] string pszUsageOID, ref CRYPT_PROVIDER_REGDEFUSAGE psDefUsage);

		/// <summary>The <c>WintrustGetDefaultForUsage</c> function retrieves the default usage identifier and callback information.</summary>
		/// <param name="dwAction">
		/// <para>Action to perform. This can be one of the following values. For more information, see Remarks.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>DWACTION_ALLOCANDFILL</term>
		/// <term>Allocate memory and fill the CRYPT_PROVIDER_DEFUSAGE structure pointed to by the psUsage parameter.</term>
		/// </item>
		/// <item>
		/// <term>DWACTION_FREE</term>
		/// <term>Free all memory allocated during a previous call to this function by specifying DWACTION_ALLOCANDFILL for this parameter.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pszUsageOID">Pointer to a string that contains the identifier.</param>
		/// <param name="psUsage">Pointer to a CRYPT_PROVIDER_DEFUSAGE structure that contains callback information to be retrieved.</param>
		/// <returns>
		/// The return value is <c>TRUE</c> if the function succeeds; <c>FALSE</c> if the function fails. If the function fails, call the
		/// GetLastError function to determine the reason for failure.
		/// </returns>
		/// <remarks>
		/// <para>
		/// Call this function once with the dwAction parameter set to <c>DWACTION_ALLOCANDFILL</c> to allocate memory and fill a
		/// CRYPT_PROVIDER_DEFUSAGE structure with information. Call this function again with the dwAction parameter set to
		/// <c>DWACTION_FREE</c> to free the allocated memory.
		/// </para>
		/// <para>The default usage and callback information for a provider is registered by calling the WintrustAddDefaultForUsage function.</para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wintrust/nf-wintrust-wintrustgetdefaultforusage BOOL
		// WintrustGetDefaultForUsage( DWORD dwAction, const char *pszUsageOID, CRYPT_PROVIDER_DEFUSAGE *psUsage );
		[DllImport(Lib.Wintrust, SetLastError = true, ExactSpelling = true)]
		[PInvokeData("wintrust.h", MSDNShortId = "B2ED5489-792F-4B00-A21E-EE1B1462D1C8")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool WintrustGetDefaultForUsage(DWACTION dwAction, [MarshalAs(UnmanagedType.LPStr)] string pszUsageOID, ref CRYPT_PROVIDER_DEFUSAGE psUsage);

		/// <summary>
		/// <para>The <c>WintrustGetRegPolicyFlags</c> function retrieves policy flags for a policy provider.</para>
		/// <para>
		/// <c>Note</c> This function has no associated import library. You must use the LoadLibrary and GetProcAddress functions to
		/// dynamically link to Wintrust.dll.
		/// </para>
		/// </summary>
		/// <param name="pdwPolicyFlags">
		/// <para>This parameter can be a bitwise combination of one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WTPF_TRUSTTEST</term>
		/// <term>Trust any test certificate.</term>
		/// </item>
		/// <item>
		/// <term>WTPF_TESTCANBEVALID</term>
		/// <term>Check any test certificate for validity.</term>
		/// </item>
		/// <item>
		/// <term>WTPF_IGNOREEXPIRATION</term>
		/// <term>Use expiration date.</term>
		/// </item>
		/// <item>
		/// <term>WTPF_IGNOREREVOKATION</term>
		/// <term>Do revocation check.</term>
		/// </item>
		/// <item>
		/// <term>WTPF_OFFLINEOK_IND</term>
		/// <term>If the source is offline, trust any individual certificates.</term>
		/// </item>
		/// <item>
		/// <term>WTPF_OFFLINEOK_COM</term>
		/// <term>If the source is offline, trust any commercial certificates.</term>
		/// </item>
		/// <item>
		/// <term>WTPF_OFFLINEOKNBU_IND</term>
		/// <term>If the source is offline, trust any individual certificates. Do not use the user interface (UI).</term>
		/// </item>
		/// <item>
		/// <term>WTPF_OFFLINEOKNBU_COM</term>
		/// <term>If the source is offline, trust any commercial certificates. Do not use the checking UI.</term>
		/// </item>
		/// <item>
		/// <term>WTPF_VERIFY_V1_OFF</term>
		/// <term>Turn off verification of version 1.0 certificates.</term>
		/// </item>
		/// <item>
		/// <term>WTPF_IGNOREREVOCATIONONTS</term>
		/// <term>Ignore time stamp revocation checks.</term>
		/// </item>
		/// <item>
		/// <term>WTPF_ALLOWONLYPERTRUST</term>
		/// <term>Allow only items in personal trust database.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>This function does not return a value.</returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wintrust/nf-wintrust-wintrustgetregpolicyflags void
		// WintrustGetRegPolicyFlags( DWORD *pdwPolicyFlags );
		[DllImport(Lib.Wintrust, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wintrust.h", MSDNShortId = "f5e79ac8-9a70-4e79-ae4f-e128bd8c84de")]
		public static extern void WintrustGetRegPolicyFlags(out WTPF pdwPolicyFlags);

		/// <summary>
		/// <para>
		/// [The <c>WintrustLoadFunctionPointers</c> function is available for use in the operating systems specified in the Requirements
		/// section. It may be altered or unavailable in subsequent versions. For certificate verification, use the CertGetCertificateChain
		/// and CertVerifyCertificateChainPolicy functions. For Microsoft Authenticode technology signature verification, use the .NET Framework.]
		/// </para>
		/// <para>
		/// The <c>WintrustLoadFunctionPointers</c> function loads function entry points for a specified action GUID. This function has no
		/// associated import library. You must use the LoadLibrary and GetProcAddress functions to dynamically link to Wintrust.dll.
		/// </para>
		/// </summary>
		/// <param name="pgActionID">
		/// <para>
		/// A pointer to a <c>GUID</c> structure that identifies the action whose function pointers are being loaded and the trust provider
		/// that supports that action.
		/// </para>
		/// <para>
		/// The WinTrust service is designed to work with trust providers implemented by third parties. Each trust provider provides its own
		/// unique set of action identifiers. For information about the action identifiers supported by a trust provider, see the
		/// documentation for that trust provider.
		/// </para>
		/// <para>
		/// For example, Microsoft provides a Software Publisher Trust Provider that can establish the trustworthiness of software being
		/// downloaded from the Internet or some other public network. The Software Publisher Trust Provider supports the following action
		/// identifiers. These constants are defined in Softpub.h.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WINTRUST_ACTION_GENERIC_VERIFY</term>
		/// <term>Verify a certificate chain only.</term>
		/// </item>
		/// <item>
		/// <term>WINTRUST_ACTION_GENERIC_VERIFY_V2</term>
		/// <term>Verify a file or object using the Authenticode policy provider.</term>
		/// </item>
		/// <item>
		/// <term>HTTPSPROV_ACTION</term>
		/// <term>Verify an SSL/PCT connection through Internet Explorer.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pPfns">A pointer to the CRYPT_PROVIDER_FUNCTIONS structure that receives the addresses of the function pointers.</param>
		/// <returns>The return value is <c>TRUE</c> if the function succeeds; <c>FALSE</c> if the function fails.</returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wintrust/nf-wintrust-wintrustloadfunctionpointers BOOL
		// WintrustLoadFunctionPointers( GUID *pgActionID, CRYPT_PROVIDER_FUNCTIONS *pPfns );
		[DllImport(Lib.Wintrust, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wintrust.h", MSDNShortId = "c36db226-34b4-4a31-b8c6-b9d124acc669")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool WintrustLoadFunctionPointers(in Guid pgActionID, ref CRYPT_PROVIDER_FUNCTIONS pPfns);

		/// <summary>
		/// <para>
		/// [The <c>WintrustRemoveActionID</c> function is available for use in the operating systems specified in the Requirements section.
		/// It may be altered or unavailable in subsequent versions. For certificate verification, use the CertGetCertificateChain and
		/// CertVerifyCertificateChainPolicy functions. For Authenticode technology signature verification, use the .NET Framework.]
		/// </para>
		/// <para>
		/// The <c>WintrustRemoveActionID</c> function removes an action added by the WintrustAddActionID function. This function has no
		/// associated import library. You must use the LoadLibrary and GetProcAddress functions to dynamically link to Wintrust.dll.
		/// </para>
		/// </summary>
		/// <param name="pgActionID">
		/// <para>A pointer to a <c>GUID</c> structure that identifies the action to remove and the trust provider that supports that action.</para>
		/// <para>
		/// The WinTrust service is designed to work with trust providers implemented by third parties. Each trust provider provides its own
		/// unique set of action identifiers. For information about the action identifiers supported by a trust provider, see the
		/// documentation for that trust provider.
		/// </para>
		/// <para>
		/// For example, Microsoft provides a Software Publisher Trust Provider that can establish the trustworthiness of software being
		/// downloaded from the Internet or some other public network. The Software Publisher Trust Provider supports the following action
		/// identifiers. These constants are defined in Softpub.h.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WINTRUST_ACTION_GENERIC_VERIFY</term>
		/// <term>Verify a certificate chain only.</term>
		/// </item>
		/// <item>
		/// <term>WINTRUST_ACTION_GENERIC_VERIFY_V2</term>
		/// <term>Verify a file or object using the Authenticode policy provider.</term>
		/// </item>
		/// <item>
		/// <term>HTTPSPROV_ACTION</term>
		/// <term>Verify an SSL/PCT connection through Internet Explorer.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>The return value is <c>TRUE</c> if the function succeeds; <c>FALSE</c> if the function fails.</returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wintrust/nf-wintrust-wintrustremoveactionid BOOL WintrustRemoveActionID( GUID
		// *pgActionID );
		[DllImport(Lib.Wintrust, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wintrust.h", MSDNShortId = "d1c84b69-4886-4cb4-99c5-294bd9d8228b")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool WintrustRemoveActionID(in Guid pgActionID);

		/// <summary>
		/// <para>
		/// The <c>WintrustSetDefaultIncludePEPageHashes</c> function sets the default setting that determines whether page hashes are
		/// included when creating subject interface package (SIP) indirect data for PE files.
		/// </para>
		/// <para>
		/// This setting is only used if neither the <c>SPC_EXC_PE_PAGE_HASHES_FLAG</c> or the <c>SPC_INC_PE_PAGE_HASHES_FLAG</c> flag is
		/// specified in the dwFlags parameter of the SignerSignEx function.
		/// </para>
		/// <para>
		/// This function has no associated import library. You must use the LoadLibrary and GetProcAddress functions to dynamically link to Wintrust.dll.
		/// </para>
		/// </summary>
		/// <param name="fIncludePEPageHashes">
		/// Determines whether page hashes are included when creating SIP indirect data for PE files. If this parameter is nonzero, page
		/// hashes are included. If this parameter is zero, page hashes are not included. The value is zero by default.
		/// </param>
		/// <returns>This function does not return a value.</returns>
		/// <remarks>This setting applies to each instance of Wintrust.dll.</remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wintrust/nf-wintrust-wintrustsetdefaultincludepepagehashes void
		// WintrustSetDefaultIncludePEPageHashes( BOOL fIncludePEPageHashes );
		[DllImport(Lib.Wintrust, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wintrust.h", MSDNShortId = "af48e570-e71d-488f-831c-35834242db3c")]
		public static extern void WintrustSetDefaultIncludePEPageHashes([MarshalAs(UnmanagedType.Bool)] bool fIncludePEPageHashes);

		/// <summary>
		/// <para>The <c>WintrustSetRegPolicyFlags</c> function sets policy flags for a policy provider.</para>
		/// <para>
		/// <c>Note</c> This function has no associated import library. You must use the LoadLibrary and GetProcAddress functions to
		/// dynamically link to Wintrust.dll.
		/// </para>
		/// </summary>
		/// <param name="dwPolicyFlags">
		/// <para>This parameter can be a bitwise combination of one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>WTPF_TRUSTTEST</term>
		/// <term>Trust any test certificate.</term>
		/// </item>
		/// <item>
		/// <term>WTPF_TESTCANBEVALID</term>
		/// <term>Check any test certificate for validity.</term>
		/// </item>
		/// <item>
		/// <term>WTPF_IGNOREEXPIRATION</term>
		/// <term>Do not check the expiration date.</term>
		/// </item>
		/// <item>
		/// <term>WTPF_IGNOREREVOKATION</term>
		/// <term>Do not check revocation.</term>
		/// </item>
		/// <item>
		/// <term>WTPF_OFFLINEOK_IND</term>
		/// <term>If the source is offline, trust any individual certificates.</term>
		/// </item>
		/// <item>
		/// <term>WTPF_OFFLINEOK_COM</term>
		/// <term>If the source is offline, trust any commercial certificates.</term>
		/// </item>
		/// <item>
		/// <term>WTPF_OFFLINEOKNBU_IND</term>
		/// <term>If the source is offline, trust any individual certificates. Do not use the user interface (UI).</term>
		/// </item>
		/// <item>
		/// <term>WTPF_OFFLINEOKNBU_COM</term>
		/// <term>If the source is offline, trust any commercial certificates. Do not use the checking UI.</term>
		/// </item>
		/// <item>
		/// <term>WTPF_VERIFY_V1_OFF</term>
		/// <term>Turn off verification of version 1.0 certificates.</term>
		/// </item>
		/// <item>
		/// <term>WTPF_IGNOREREVOCATIONONTS</term>
		/// <term>Ignore time stamp revocation checks.</term>
		/// </item>
		/// <item>
		/// <term>WTPF_ALLOWONLYPERTRUST</term>
		/// <term>Allow only items in personal trust database.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <returns>Returns nonzero if the policy flags were set successfully or zero otherwise.</returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wintrust/nf-wintrust-wintrustsetregpolicyflags BOOL
		// WintrustSetRegPolicyFlags( DWORD dwPolicyFlags );
		[DllImport(Lib.Wintrust, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wintrust.h", MSDNShortId = "8aaeecd0-3814-42a0-9e5b-82b0b220bc9a")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool WintrustSetRegPolicyFlags(WTPF dwPolicyFlags);

		/// <summary>
		/// <para>
		/// The <c>WinVerifyTrust</c> function performs a trust verification action on a specified object. The function passes the inquiry to
		/// a trust provider that supports the action identifier, if one exists.
		/// </para>
		/// <para>For certificate verification, use the CertGetCertificateChain and CertVerifyCertificateChainPolicy functions.</para>
		/// </summary>
		/// <param name="hwnd">
		/// <para>
		/// Optional handle to a caller window. A trust provider can use this value to determine whether it can interact with the user.
		/// However, trust providers typically perform verification actions without input from the user.
		/// </para>
		/// <para>This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>INVALID_HANDLE_VALUE</term>
		/// <term>There is no interactive user. The trust provider performs the verification action without the user's assistance.</term>
		/// </item>
		/// <item>
		/// <term>Zero</term>
		/// <term>The trust provider can use the interactive desktop to display its user interface.</term>
		/// </item>
		/// <item>
		/// <term>A valid window handle</term>
		/// <term>
		/// A trust provider can treat any value other than INVALID_HANDLE_VALUE or zero as a valid window handle that it can use to interact
		/// with the user.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pgActionID">
		/// <para>
		/// A pointer to a <c>GUID</c> structure that identifies an action and the trust provider that supports that action. This value
		/// indicates the type of verification action to be performed on the structure pointed to by pWinTrustData.
		/// </para>
		/// <para>
		/// The WinTrust service is designed to work with trust providers implemented by third parties. Each trust provider provides its own
		/// unique set of action identifiers. For information about the action identifiers supported by a trust provider, see the
		/// documentation for that trust provider.
		/// </para>
		/// <para>
		/// For example, Microsoft provides a Software Publisher Trust Provider that can establish the trustworthiness of software being
		/// downloaded from the Internet or some other public network. The Software Publisher Trust Provider supports the following action
		/// identifiers. These constants are defined in Softpub.h.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>DRIVER_ACTION_VERIFY</term>
		/// <term>
		/// Verify the authenticity of a Windows Hardware Quality Labs (WHQL) signed driver. This is an Authenticode add-on policy provider.
		/// </term>
		/// </item>
		/// <item>
		/// <term>HTTPSPROV_ACTION</term>
		/// <term>Verify an SSL/TLS connection through Internet Explorer.</term>
		/// </item>
		/// <item>
		/// <term>OFFICESIGN_ACTION_VERIFY</term>
		/// <term>
		/// This Action ID is not supported. Verify the authenticity of a structured storage file by using the Microsoft Office Authenticode
		/// add-on policy provider. Windows Server 2003 and Windows XP: This Action ID is supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WINTRUST_ACTION_GENERIC_CHAIN_VERIFY</term>
		/// <term>
		/// Verify certificate chains created from any object type. A callback is provided to implement the final chain policy by using the
		/// chain context for each signer and counter signer.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WINTRUST_ACTION_GENERIC_VERIFY_V2</term>
		/// <term>Verify a file or object using the Authenticode policy provider.</term>
		/// </item>
		/// <item>
		/// <term>WINTRUST_ACTION_TRUSTPROVIDER_TEST</term>
		/// <term>Write the CRYPT_PROVIDER_DATA structure to a file after calling the Authenticode policy provider.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pWVTData">
		/// <para>
		/// A pointer that, when cast as a WINTRUST_DATA structure, contains information that the trust provider needs to process the
		/// specified action identifier. Typically, the structure includes information that identifies the object that the trust provider
		/// must evaluate.
		/// </para>
		/// <para>
		/// The format of the structure depends on the action identifier. For information about the data required for a specific action
		/// identifier, see the documentation for the trust provider that supports that action.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>
		/// If the trust provider verifies that the subject is trusted for the specified action, the return value is zero. No other value
		/// besides zero should be considered a successful return.
		/// </para>
		/// <para>
		/// If the trust provider does not verify that the subject is trusted for the specified action, the function returns a status code
		/// from the trust provider.
		/// </para>
		/// <para>
		/// For example, a trust provider might indicate that the subject is not trusted, or is trusted but with limitations or warnings. The
		/// return value can be a trust-provider-specific value described in the documentation for an individual trust provider, or it can be
		/// one of the following error codes.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
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
		/// </returns>
		/// <remarks>
		/// <para>
		/// The <c>WinVerifyTrust</c> function enables applications to invoke a trust provider to verify that a specified object satisfies
		/// the criteria of a specified verification operation. The pgActionID parameter identifies the verification operation, and the
		/// pWinTrustData parameter identifies the object whose trust is to be verified. A trust provider is a DLL registered with the
		/// operating system. A call to <c>WinVerifyTrust</c> forwards that call to the registered trust provider, if there is one, that
		/// supports that specified action identifier.
		/// </para>
		/// <para>
		/// For example, the Software Publisher Trust Provider can verify that an executable image file comes from a trusted software
		/// publisher and that the file has not been modified since it was published. In this case, the pWinTrustData parameter specifies the
		/// name of the file and the type of file, such as a Microsoft Portable Executable image file.
		/// </para>
		/// <para>
		/// Each trust provider supports a specific set of actions that it can evaluate. Each action has a GUID that identifies it. A trust
		/// provider can support any number of action identifiers, but two trust providers cannot support the same action identifier.
		/// </para>
		/// <para>
		/// For an example that demonstrates how to use this function to verify the signature of a portable executable (PE) file, see Example
		/// C Program: Verifying the Signature of a PE File.
		/// </para>
		/// </remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wintrust/nf-wintrust-winverifytrust LONG WinVerifyTrust( HWND hwnd, GUID
		// *pgActionID, LPVOID pWVTData );
		[DllImport(Lib.Wintrust, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wintrust.h", MSDNShortId = "b7efac6a-ac9f-477a-aada-63fe32208e6f")]
		public static extern Win32Error WinVerifyTrust(HWND hwnd, in Guid pgActionID, IntPtr pWVTData);

		/// <summary>
		/// <para>
		/// The <c>WinVerifyTrustEx</c> function performs a trust verification action on a specified object and takes a pointer to a
		/// WINTRUST_DATA structure. The function passes the inquiry to a trust provider, if one exists, that supports the action identifier.
		/// This function has no associated import library. You must use the LoadLibrary and GetProcAddress functions to dynamically link to Wintrust.dll.
		/// </para>
		/// <para>For certificate verification, use the CertGetCertificateChain and CertVerifyCertificateChainPolicy functions.</para>
		/// </summary>
		/// <param name="hwnd">
		/// <para>
		/// Optional handle to a caller window. A trust provider can use this value to determine whether it can interact with the user.
		/// However, trust providers typically perform verification actions without input from the user.
		/// </para>
		/// <para>This parameter can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>INVALID_HANDLE_VALUE</term>
		/// <term>There is no interactive user. The trust provider performs the verification action without the user's assistance.</term>
		/// </item>
		/// <item>
		/// <term>Zero</term>
		/// <term>The trust provider can use the interactive desktop to display its user interface.</term>
		/// </item>
		/// <item>
		/// <term>A valid window handle</term>
		/// <term>
		/// A trust provider can treat any value other than INVALID_HANDLE_VALUE or zero as a valid window handle that it can use to interact
		/// with the user.
		/// </term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pgActionID">
		/// <para>
		/// A pointer to a <c>GUID</c> structure that identifies an action and the trust provider that supports that action. This value
		/// indicates the type of verification action to be performed on the structure pointed to by pWinTrustData.
		/// </para>
		/// <para>
		/// The WinTrust service is designed to work with trust providers implemented by third parties. Each trust provider provides its own
		/// unique set of action identifiers. For information about the action identifiers supported by a trust provider, see the
		/// documentation for that trust provider.
		/// </para>
		/// <para>
		/// For example, Microsoft provides a Software Publisher Trust Provider that can establish the trustworthiness of software being
		/// downloaded from the Internet or some other public network. The Software Publisher Trust Provider supports the following action
		/// identifiers. These constants are defined in Softpub.h.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>DRIVER_ACTION_VERIFY</term>
		/// <term>
		/// Verify the authenticity of a Windows Hardware Quality Labs (WHQL) signed driver. This is an Authenticode add-on policy provider.
		/// </term>
		/// </item>
		/// <item>
		/// <term>HTTPSPROV_ACTION</term>
		/// <term>Verify an SSL/TLS connection through Internet Explorer.</term>
		/// </item>
		/// <item>
		/// <term>OFFICESIGN_ACTION_VERIFY</term>
		/// <term>
		/// This Action ID is not supported. Verify the authenticity of a structured storage file by using the Microsoft Office Authenticode
		/// add-on policy provider. Windows Server 2003 and Windows XP: This Action ID is supported.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WINTRUST_ACTION_GENERIC_CERT_VERIFY</term>
		/// <term>
		/// Verify a certificate chain only. This is only valid when passing in a certificate context in the WinVerifyTrust input structures.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WINTRUST_ACTION_GENERIC_CHAIN_VERIFY</term>
		/// <term>
		/// Verify certificate chains created from any object type. A callback is provided to implement the final chain policy by using the
		/// chain context for each signer and counter signer.
		/// </term>
		/// </item>
		/// <item>
		/// <term>WINTRUST_ACTION_GENERIC_VERIFY_V2</term>
		/// <term>Verify a file or object using the Authenticode policy provider.</term>
		/// </item>
		/// <item>
		/// <term>WINTRUST_ACTION_TRUSTPROVIDER_TEST</term>
		/// <term>Write the CRYPT_PROVIDER_DATA structure to a file after calling the Authenticode policy provider.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="pWinTrustData">
		/// <para>
		/// A pointer to a WINTRUST_DATA structure that contains information that the trust provider needs to process the specified action
		/// identifier. Typically, the structure includes information that identifies the object that the trust provider must evaluate.
		/// </para>
		/// <para>
		/// The format of the structure depends on the action identifier. For information about the data required for a specific action
		/// identifier, see the documentation for the trust provider that supports that action.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>
		/// If the trust provider verifies that the subject is trusted for the specified action, the return value is ERROR_SUCCESS.
		/// Otherwise, the function returns a status code from the trust provider.
		/// </para>
		/// <para>
		/// For example, a trust provider might indicate that the subject is not trusted, or is trusted but with limitations or warnings. The
		/// return value can be a trust provider–specific value described in the documentation for an individual trust provider, or it can be
		/// one of the following error codes.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code</term>
		/// <term>Description</term>
		/// </listheader>
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
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wintrust/nf-wintrust-winverifytrustex HRESULT WinVerifyTrustEx( HWND hwnd,
		// GUID *pgActionID, WINTRUST_DATA *pWinTrustData );
		[DllImport(Lib.Wintrust, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wintrust.h", MSDNShortId = "209c9953-a4a5-4ff0-961f-92e97ccce23d")]
		public static extern HRESULT WinVerifyTrustEx(HWND hwnd, in Guid pgActionID, [In] WINTRUST_DATA pWinTrustData);

		/// <summary>
		/// <para>
		/// [The <c>WTHelperCertCheckValidSignature</c> function is available for use in the operating systems specified in the Requirements
		/// section. It may be altered or unavailable in subsequent versions. For certificate verification, use the CertGetCertificateChain
		/// and CertVerifyCertificateChainPolicy functions. For Microsoft Authenticode technology signature verification, use the .NET Framework.]
		/// </para>
		/// <para>
		/// The <c>WTHelperCertCheckValidSignature</c> function checks whether a signature is valid. It can be used by trust providers to get
		/// an initial assessment of the validity of a signature before calling the function pointed to by the <c>pfnFinalPolicy</c> member
		/// of a CRYPT_PROVIDER_FUNCTIONS structure.
		/// </para>
		/// </summary>
		/// <param name="pProvData">A pointer to the CRYPT_PROVIDER_DATA structure that contains the signer and countersigner information.</param>
		/// <returns>
		/// <para>If the function succeeds, the function returns S_OK.</para>
		/// <para>
		/// If the function fails, it returns an <c>HRESULT</c> value that indicates the error. For a list of possible error values, see WinVerifyTrust.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wintrust/nf-wintrust-wthelpercertcheckvalidsignature HRESULT
		// WTHelperCertCheckValidSignature( CRYPT_PROVIDER_DATA *pProvData );
		[DllImport(Lib.Wintrust, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wintrust.h", MSDNShortId = "d46eea18-03cb-4199-873e-0e9e13061598")]
		public static extern HRESULT WTHelperCertCheckValidSignature(in CRYPT_PROVIDER_DATA pProvData);

		/// <summary>
		/// <para>
		/// [The <c>WTHelperCertIsSelfSigned</c> function is available for use in the operating systems specified in the Requirements
		/// section. It may be altered or unavailable in subsequent versions. For certificate verification, use the CertGetCertificateChain
		/// and CertVerifyCertificateChainPolicy functions. For Microsoft Authenticode technology signature verification, use the .NET Framework.]
		/// </para>
		/// <para>
		/// The <c>WTHelperCertIsSelfSigned</c> function checks whether a certificate is self-signed. This function has no associated import
		/// library. You must use the LoadLibrary and GetProcAddress functions to dynamically link to Wintrust.dll.
		/// </para>
		/// </summary>
		/// <param name="dwEncoding">
		/// A <c>DWORD</c> value that specifies the encoding types of the certificate to check. For information about possible encoding
		/// types, see Certificate and Message Encoding Types.
		/// </param>
		/// <param name="pCert">A pointer to a CERT_INFO structure that contains information about the certificate to check.</param>
		/// <returns>
		/// <para>If the function succeeds, the function returns <c>TRUE</c>.</para>
		/// <para>If the function fails, it returns <c>FALSE</c>.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wintrust/nf-wintrust-wthelpercertisselfsigned BOOL WTHelperCertIsSelfSigned(
		// DWORD dwEncoding, CERT_INFO *pCert );
		[DllImport(Lib.Wintrust, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wintrust.h", MSDNShortId = "456b8c8c-6ca3-469a-a415-e72109696bf5")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool WTHelperCertIsSelfSigned(uint dwEncoding, in CERT_INFO pCert);

		/// <summary>
		/// <para>
		/// [The <c>WTHelperGetProvCertFromChain</c> function is available for use in the operating systems specified in the Requirements
		/// section. It may be altered or unavailable in subsequent versions. For certificate verification, use the CertGetCertificateChain
		/// and CertVerifyCertificateChainPolicy functions. For Microsoft Authenticode technology signature verification, use the .NET Framework.]
		/// </para>
		/// <para>
		/// The <c>WTHelperGetProvCertFromChain</c> function retrieves a trust provider certificate from the certificate chain. This function
		/// has no associated import library. You must use the LoadLibrary and GetProcAddress functions to dynamically link to Wintrust.dll.
		/// </para>
		/// </summary>
		/// <param name="pSgnr">
		/// A pointer to a CRYPT_PROVIDER_SGNR structure that represents the signers. This pointer is retrieved by the
		/// WTHelperGetProvSignerFromChain function.
		/// </param>
		/// <param name="idxCert">The index of the certificate. The index is zero based.</param>
		/// <returns>
		/// <para>
		/// If the function succeeds, the function returns a pointer to a CRYPT_PROVIDER_CERT structure that represents the trust provider certificate.
		/// </para>
		/// <para>If the function fails, it returns <c>NULL</c>.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wintrust/nf-wintrust-wthelpergetprovcertfromchain CRYPT_PROVIDER_CERT *
		// WTHelperGetProvCertFromChain( CRYPT_PROVIDER_SGNR *pSgnr, DWORD idxCert );
		[DllImport(Lib.Wintrust, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wintrust.h", MSDNShortId = "047278fe-37d5-4fd6-8b36-9e28ead0cc5a")]
		public static extern IntPtr WTHelperGetProvCertFromChain(in CRYPT_PROVIDER_SGNR pSgnr, uint idxCert);

		/// <summary>
		/// <para>
		/// [The <c>WTHelperGetProvPrivateDataFromChain</c> function is available for use in the operating systems specified in the
		/// Requirements section. It may be altered or unavailable in subsequent versions. For certificate verification, use the
		/// CertGetCertificateChain and CertVerifyCertificateChainPolicy functions. For Microsoft Authenticode technology signature
		/// verification, use the .NET Framework.]
		/// </para>
		/// <para>
		/// The <c>WTHelperGetProvPrivateDataFromChain</c> function receives a CRYPT_PROVIDER_PRIVDATA structure from the chain by using the
		/// provider ID. This function has no associated import library. You must use the LoadLibrary and GetProcAddress functions to
		/// dynamically link to Wintrust.dll.
		/// </para>
		/// </summary>
		/// <param name="pProvData">A pointer to a CRYPT_PROVIDER_DATA structure that contains the provider's private information.</param>
		/// <param name="pgProviderID">A pointer to a GUID structure that identifies the provider.</param>
		/// <returns>
		/// <para>
		/// If the function succeeds, the function returns a pointer to a CRYPT_PROVIDER_PRIVDATA structure that represents the trust
		/// provider's private information.
		/// </para>
		/// <para>If the function fails, the return value is <c>NULL</c>.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wintrust/nf-wintrust-wthelpergetprovprivatedatafromchain
		// CRYPT_PROVIDER_PRIVDATA * WTHelperGetProvPrivateDataFromChain( CRYPT_PROVIDER_DATA *pProvData, GUID *pgProviderID );
		[DllImport(Lib.Wintrust, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("wintrust.h", MSDNShortId = "67a718a2-47ca-4c45-a939-99dd8311dc6d")]
		public static extern IntPtr WTHelperGetProvPrivateDataFromChain(in CRYPT_PROVIDER_DATA pProvData, in Guid pgProviderID);

		/// <summary>
		/// <para>
		/// [The <c>CRYPT_PROVIDER_CERT</c> structure is available for use in the operating systems specified in the Requirements section. It
		/// may be altered or unavailable in subsequent versions.]
		/// </para>
		/// <para>The <c>CRYPT_PROVIDER_CERT</c> structure provides information about a provider certificate.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wintrust/ns-wintrust-_crypt_provider_cert typedef struct _CRYPT_PROVIDER_CERT
		// { DWORD cbStruct; PCCERT_CONTEXT pCert; BOOL fCommercial; BOOL fTrustedRoot; BOOL fSelfSigned; BOOL fTestCert; DWORD
		// dwRevokedReason; DWORD dwConfidence; DWORD dwError; CTL_CONTEXT *pTrustListContext; BOOL fTrustListSignerCert; PCCTL_CONTEXT
		// pCtlContext; DWORD dwCtlError; BOOL fIsCyclic; PCERT_CHAIN_ELEMENT pChainElement; } CRYPT_PROVIDER_CERT, *PCRYPT_PROVIDER_CERT;
		[PInvokeData("wintrust.h", MSDNShortId = "622e7a72-445a-4820-b236-1c90dad08351")]
		[StructLayout(LayoutKind.Sequential)]
		public struct CRYPT_PROVIDER_CERT
		{
			/// <summary>The size, in bytes, of this structure.</summary>
			public uint cbStruct;

			/// <summary>A pointer to the certificate context.</summary>
			public IntPtr pCert;

			/// <summary>Boolean value that indicates whether the certificate is a commercial certificate.</summary>
			[MarshalAs(UnmanagedType.Bool)] public bool fCommercial;

			/// <summary>Boolean value that indicates whether the certificate is a trusted root certificate.</summary>
			[MarshalAs(UnmanagedType.Bool)] public bool fTrustedRoot;

			/// <summary>Boolean value that indicates whether the certificate is self-signed.</summary>
			[MarshalAs(UnmanagedType.Bool)] public bool fSelfSigned;

			/// <summary>Boolean value that indicates whether the certificate is a test certificate.</summary>
			[MarshalAs(UnmanagedType.Bool)] public bool fTestCert;

			/// <summary>Value that specifies the revocation reason, if applicable.</summary>
			public uint dwRevokedReason;

			/// <summary>
			/// <para>Bitwise combination of zero or more of the following confidence values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>CERT_CONFIDENCE_SIG 0x10000000</term>
			/// <term>The signature of the certificate is valid.</term>
			/// </item>
			/// <item>
			/// <term>CERT_CONFIDENCE_TIME 0x01000000</term>
			/// <term>The time of the certificate issuer is valid.</term>
			/// </item>
			/// <item>
			/// <term>CERT_CONFIDENCE_TIMENEST 0x00100000</term>
			/// <term>The time of the certificate is valid.</term>
			/// </item>
			/// <item>
			/// <term>CERT_CONFIDENCE_AUTHIDEXT 0x00010000</term>
			/// <term>The authority ID extension is valid.</term>
			/// </item>
			/// <item>
			/// <term>CERT_CONFIDENCE_HYGIENE 0x00001000</term>
			/// <term>At a minimum, the signature of the certificate and authority ID extension are valid.</term>
			/// </item>
			/// <item>
			/// <term>CERT_CONFIDENCE_HIGHEST 0x11111000</term>
			/// <term>Combination of all of the other confidence values.</term>
			/// </item>
			/// </list>
			/// </summary>
			public uint dwConfidence;

			/// <summary>A pointer to a <c>DWORD</c> variable that contains the error value for this certificate, if applicable.</summary>
			public uint dwError;

			/// <summary>A pointer to the CTL_CONTEXT that represents the certificate trust list (CTL).</summary>
			public IntPtr pTrustListContext;

			/// <summary>Boolean value that specifies whether the certificate is a trust list signer certificate.</summary>
			[MarshalAs(UnmanagedType.Bool)] public bool fTrustListSignerCert;

			/// <summary>A pointer to the CTL_CONTEXT that represents a CTL that contains a self-signed certificate, if applicable.</summary>
			public IntPtr pCtlContext;

			/// <summary>
			/// A pointer to a <c>DWORD</c> variable that contains the error value for a CTL that contains a self-signed certificate, if applicable.
			/// </summary>
			public uint dwCtlError;

			/// <summary>Boolean value that indicates whether the certificate trust is cyclical.</summary>
			[MarshalAs(UnmanagedType.Bool)] public bool fIsCyclic;

			/// <summary>A pointer to the CERT_CHAIN_ELEMENT that represents the status of the certificate within a chain.</summary>
			public IntPtr pChainElement;
		}

		/// <summary>
		/// [The CRYPT_PROVUI_DATA structure is available for use in the operating systems specified in the Requirements section. It may be
		/// altered or unavailable in subsequent versions.]
		/// <para>
		/// The CRYPT_PROVUI_DATA structure provides user interface (UI) data for a provider.This structure is used by the CRYPT_PROVUI_FUNCS structure.
		/// </para>
		/// </summary>
		[PInvokeData("wintrust.h", MSDNShortId = "86f819f0-c243-45ba-8b7b-97ed906e6e8a")]
		[StructLayout(LayoutKind.Sequential)]
		public struct CRYPT_PROVIDER_DATA
		{
			/// <summary>The size, in bytes, of this structure.</summary>
			public uint cbStruct;

			/// <summary>Error code, if applicable.</summary>
			public uint dwFinalError;

			/// <summary> A pointer to a null-terminated string for the Yes button text. If this parameter is NULL, then "&Yes" is used. </summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string pYesButtonText;

			/// <summary> A pointer to a null-terminated string for the No button text. If this parameter is NULL, then "&No" is used. </summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string pNoButtonText;

			/// <summary> A pointer to a null-terminated string for the More Info button text. If this parameter is NULL, then "&More Info"
			/// is used. </summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string pMoreInfoButtonText;

			/// <summary>A pointer to a null-terminated string for the Advanced button text.</summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string pAdvancedLinkText;

			/// <summary>
			/// A pointer to a null-terminated string for the text used when the trust is valid and a time stamp is used. If this parameter
			/// is NULL, then "Do you want to install and run ""%1"" signed on %2 and distributed by:" is used.
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string pCopyActionText;

			/// <summary>
			/// A pointer to a null-terminated string for the text used when the trust is valid but a time stamp is not used. If this
			/// parameter is NULL, then "Do you want to install and run ""%1"" signed on an unknown date/time and distributed by:" is used.
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string pCopyActionTextNoTS;

			/// <summary>
			/// A pointer to a null-terminated string for the text used when a signature is not provided. If this parameter is NULL, then "Do
			/// you want to install and run ""%1""?" is used.
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)]
			public string pCopyActionTextNotSigned;
		}

		/// <summary>
		/// The <c>CRYPT_PROVIDER_DEFUSAGE</c> structure is used by the WintrustGetDefaultForUsage function to retrieve callback information
		/// for a provider's default usage.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wintrust/ns-wintrust-_crypt_provider_defusage typedef struct
		// _CRYPT_PROVIDER_DEFUSAGE { DWORD cbStruct; GUID gActionID; LPVOID pDefPolicyCallbackData; LPVOID pDefSIPClientData; }
		// CRYPT_PROVIDER_DEFUSAGE, *PCRYPT_PROVIDER_DEFUSAGE;
		[PInvokeData("wintrust.h", MSDNShortId = "28A93F39-0CBC-432C-841B-83B54A50EA14")]
		[StructLayout(LayoutKind.Sequential)]
		public struct CRYPT_PROVIDER_DEFUSAGE
		{
			/// <summary>Size, in bytes, of the structure.</summary>
			public uint cbStruct;

			/// <summary>GUID that specifies the provider's default action.</summary>
			public Guid gActionID;

			/// <summary>Pointer to a data buffer used to pass policy-specific data to a policy provider.</summary>
			public IntPtr pDefPolicyCallbackData;

			/// <summary>Pointer to a data buffer used to pass subject interface package (SIP) specific data to an SIP provider.</summary>
			public IntPtr pDefSIPClientData;
		}

		/// <summary>
		/// <para>
		/// [The <c>CRYPT_PROVIDER_FUNCTIONS</c> structure is available for use in the operating systems specified in the Requirements
		/// section. It may be altered or unavailable in subsequent versions.]
		/// </para>
		/// <para>
		/// The <c>CRYPT_PROVIDER_FUNCTIONS</c> structure defines the functions used by a cryptographic service provider (CSP) for WinTrust operations.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wintrust/ns-wintrust-_crypt_provider_functions typedef struct
		// _CRYPT_PROVIDER_FUNCTIONS { DWORD cbStruct; PFN_CPD_MEM_ALLOC pfnAlloc; PFN_CPD_MEM_FREE pfnFree; PFN_CPD_ADD_STORE
		// pfnAddStore2Chain; PFN_CPD_ADD_SGNR pfnAddSgnr2Chain; PFN_CPD_ADD_CERT pfnAddCert2Chain; PFN_CPD_ADD_PRIVDATA
		// pfnAddPrivData2Chain; PFN_PROVIDER_INIT_CALL pfnInitialize; PFN_PROVIDER_OBJTRUST_CALL pfnObjectTrust; PFN_PROVIDER_SIGTRUST_CALL
		// pfnSignatureTrust; PFN_PROVIDER_CERTTRUST_CALL pfnCertificateTrust; PFN_PROVIDER_FINALPOLICY_CALL pfnFinalPolicy;
		// PFN_PROVIDER_CERTCHKPOLICY_CALL pfnCertCheckPolicy; PFN_PROVIDER_TESTFINALPOLICY_CALL pfnTestFinalPolicy; struct
		// _CRYPT_PROVUI_FUNCS *psUIpfns; PFN_PROVIDER_CLEANUP_CALL pfnCleanupPolicy; } CRYPT_PROVIDER_FUNCTIONS, *PCRYPT_PROVIDER_FUNCTIONS;
		[PInvokeData("wintrust.h", MSDNShortId = "2c00f8ec-e262-4df8-8984-a2702a4162bf")]
		[StructLayout(LayoutKind.Sequential)]
		public struct CRYPT_PROVIDER_FUNCTIONS
		{
			/// <summary>The size, in bytes, of this structure.</summary>
			public uint cbStruct;

			/// <summary>A pointer to the memory allocation function.</summary>
			public IntPtr pfnAlloc;

			/// <summary>A pointer to the memory deallocation function.</summary>
			public IntPtr pfnFree;

			/// <summary>A pointer to the function that adds a store to the chain.</summary>
			public IntPtr pfnAddStore2Chain;

			/// <summary>A pointer to the function that adds a signer structure to a message structure in a chain.</summary>
			public IntPtr pfnAddSgnr2Chain;

			/// <summary>A pointer to the function that adds a certificate structure to a signer structure in a chain.</summary>
			public IntPtr pfnAddCert2Chain;

			/// <summary>A pointer to the function that adds private data to a structure.</summary>
			public IntPtr pfnAddPrivData2Chain;

			/// <summary>A pointer to the function that initializes policy data.</summary>
			public IntPtr pfnInitialize;

			/// <summary>A pointer to the function that builds information for the signer data.</summary>
			public IntPtr pfnObjectTrust;

			/// <summary>A pointer to the function that builds information for the signing certificate.</summary>
			public IntPtr pfnSignatureTrust;

			/// <summary>A pointer to the function that builds the chain.</summary>
			public IntPtr pfnCertificateTrust;

			/// <summary>A pointer to the function that makes the final call to the policy.</summary>
			public IntPtr pfnFinalPolicy;

			/// <summary>A pointer to the function that checks each certificate while building a chain.</summary>
			public IntPtr pfnCertCheckPolicy;

			/// <summary>A pointer to the function that allows structures to be dumped to a file.</summary>
			public IntPtr pfnTestFinalPolicy;

			/// <summary>A pointer to a CRYPT_PROVUI_FUNCS structure.</summary>
			public IntPtr psUIpfns;

			/// <summary>A pointer to the function that cleans up private data.</summary>
			public IntPtr pfnCleanupPolicy;
		}

		/// <summary>
		/// <para>
		/// [The <c>CRYPT_PROVIDER_PRIVDATA</c> structure is available for use in the operating systems specified in the Requirements
		/// section. It may be altered or unavailable in subsequent versions.]
		/// </para>
		/// <para>
		/// The <c>CRYPT_PROVIDER_PRIVDATA</c> structure contains private data to be used by a provider. The structure is used by the
		/// CRYPT_PROVIDER_DATA structure.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wintrust/ns-wintrust-_crypt_provider_privdata typedef struct
		// _CRYPT_PROVIDER_PRIVDATA { DWORD cbStruct; GUID gProviderID; DWORD cbProvData; void *pvProvData; } CRYPT_PROVIDER_PRIVDATA, *PCRYPT_PROVIDER_PRIVDATA;
		[PInvokeData("wintrust.h", MSDNShortId = "499e4d9b-991a-4317-bc74-a1dfb6609a70")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
		public struct CRYPT_PROVIDER_PRIVDATA
		{
			/// <summary>The size, in bytes, of this structure.</summary>
			public uint cbStruct;

			/// <summary><c>GUID</c> that identifies the provider.</summary>
			public Guid gProviderID;

			/// <summary>Number of bytes referenced by <c>pvProvData</c>.</summary>
			public uint cbProvData;

			/// <summary>A pointer to a <c>void</c> that contains the private data.</summary>
			public IntPtr pvProvData;
		}

		/// <summary>
		/// The <c>CRYPT_PROVIDER_REGDEFUSAGE</c> structure is used by the WintrustAddDefaultForUsage function to register callback
		/// information about a provider's default usage.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wintrust/ns-wintrust-_crypt_provider_regdefusage typedef struct
		// _CRYPT_PROVIDER_REGDEFUSAGE { DWORD cbStruct; GUID *pgActionID; WCHAR *pwszDllName; char *pwszLoadCallbackDataFunctionName; char
		// *pwszFreeCallbackDataFunctionName; } CRYPT_PROVIDER_REGDEFUSAGE, *PCRYPT_PROVIDER_REGDEFUSAGE;
		[PInvokeData("wintrust.h", MSDNShortId = "A6047CBA-E4BA-4A31-B700-C368CFB57895")]
		[StructLayout(LayoutKind.Sequential)]
		public struct CRYPT_PROVIDER_REGDEFUSAGE
		{
			/// <summary>Size, in bytes, of this structure.</summary>
			public uint cbStruct;

			/// <summary>GUID that specifies the provider's default action.</summary>
			public IntPtr pgActionID;

			/// <summary>Pointer to the name of the provider DLL.</summary>
			public StrPtrUni pwszDllName;

			/// <summary>
			/// Pointer to the name of the function that loads the callback data to be returned when the WintrustGetDefaultForUsage function
			/// is called with the dwAction parameter set to <c>DWACTION_ALLOCANDFILL</c>. This information also exists in the WINTRUST_DATA structure.
			/// </summary>
			public StrPtrUni pwszLoadCallbackDataFunctionName;

			/// <summary>
			/// Pointer to the name of the function that frees allocated memory when the WintrustGetDefaultForUsage function is called with
			/// the dwAction parameter set to <c>DWACTION_FREE</c>. This information also exists in the WINTRUST_DATA structure.
			/// </summary>
			public StrPtrUni pwszFreeCallbackDataFunctionName;
		}

		/// <summary>
		/// <para>
		/// [The <c>CRYPT_PROVIDER_SGNR</c> structure is available for use in the operating systems specified in the Requirements section. It
		/// may be altered or unavailable in subsequent versions.]
		/// </para>
		/// <para>The <c>CRYPT_PROVIDER_SGNR</c> structure provides information about a signer or countersigner.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wintrust/ns-wintrust-_crypt_provider_sgnr typedef struct _CRYPT_PROVIDER_SGNR
		// { DWORD cbStruct; FILETIME sftVerifyAsOf; DWORD csCertChain; struct _CRYPT_PROVIDER_CERT *pasCertChain; DWORD dwSignerType;
		// CMSG_SIGNER_INFO *psSigner; DWORD dwError; DWORD csCounterSigners; struct _CRYPT_PROVIDER_SGNR *pasCounterSigners;
		// PCCERT_CHAIN_CONTEXT pChainContext; } CRYPT_PROVIDER_SGNR, *PCRYPT_PROVIDER_SGNR;
		[PInvokeData("wintrust.h", MSDNShortId = "39cf9a03-768d-4ae0-a19d-17652181dbe4")]
		[StructLayout(LayoutKind.Sequential)]
		public struct CRYPT_PROVIDER_SGNR
		{
			/// <summary>The size, in bytes, of this structure.</summary>
			public uint cbStruct;

			/// <summary>The current time, or the time stamp.</summary>
			public FILETIME sftVerifyAsOf;

			/// <summary>Number of elements in the <c>pasCertChain</c> array.</summary>
			public uint csCertChain;

			/// <summary>Array of CRYPT_PROVIDER_CERT structures.</summary>
			public IntPtr pasCertChain;

			/// <summary>
			/// <para>Signer type, if known by the policy. This value is zero, if the signer type is unknown, or the following value.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>SGNR_TYPE_TIMESTAMP 0x00000010</term>
			/// <term>Time stamp signer.</term>
			/// </item>
			/// </list>
			/// </summary>
			public uint dwSignerType;

			/// <summary>A pointer to a CMSG_SIGNER_INFO structure.</summary>
			public IntPtr psSigner;

			/// <summary>Error value, if any, while building or verifying the signer.</summary>
			public uint dwError;

			/// <summary>Number of elements in the <c>pasCounterSigners</c> array.</summary>
			public uint csCounterSigners;

			/// <summary>A pointer to an array of <c>CRYPT_PROVIDER_SGNR</c> structures that represent the countersigners.</summary>
			public IntPtr pasCounterSigners;

			/// <summary>A pointer to a CERT_CHAIN_CONTEXT structure.</summary>
			public IntPtr pChainContext;
		}

		/// <summary>The <c>CRYPT_PROVIDER_SIGSTATE</c> structure is used to communicate between policy providers and Wintrust.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wintrust/ns-wintrust-_crypt_provider_sigstate typedef struct
		// _CRYPT_PROVIDER_SIGSTATE { DWORD cbStruct; HCRYPTMSG *rhSecondarySigs; HCRYPTMSG hPrimarySig; BOOL fFirstAttemptMade; BOOL
		// fNoMoreSigs; DWORD cSecondarySigs; DWORD dwCurrentIndex; BOOL fSupportMultiSig; DWORD dwCryptoPolicySupport; DWORD iAttemptCount;
		// BOOL fCheckedSealing; struct _SEALING_SIGNATURE_ATTRIBUTE *pSealingSignature; } CRYPT_PROVIDER_SIGSTATE, *PCRYPT_PROVIDER_SIGSTATE;
		[PInvokeData("wintrust.h", MSDNShortId = "B362A161-6B92-41B0-AE81-337EB42502D8")]
		[StructLayout(LayoutKind.Sequential)]
		public struct CRYPT_PROVIDER_SIGSTATE
		{
			/// <summary>Size, in bytes, of this structure.</summary>
			public uint cbStruct;

			/// <summary>Pointer to an array of secondary signature handles.</summary>
			public IntPtr rhSecondarySigs;

			/// <summary>Handle of the primary signature.</summary>
			public HCRYPTMSG hPrimarySig;

			/// <summary>Specifies whether the first attempt to verify a signature has been made.</summary>
			[MarshalAs(UnmanagedType.Bool)] public bool fFirstAttemptMade;

			/// <summary>Specifies whether there exist further signatures that await verification.</summary>
			[MarshalAs(UnmanagedType.Bool)] public bool fNoMoreSigs;

			/// <summary>Number of secondary signatures.</summary>
			public uint cSecondarySigs;

			/// <summary>Index of the signature currently being verified.</summary>
			public uint dwCurrentIndex;

			/// <summary>Specifies whether the policy provider supports multiple signatures.</summary>
			[MarshalAs(UnmanagedType.Bool)] public bool fSupportMultiSig;

			/// <summary>
			/// <para>
			/// Identifies the portion of the policy provider that supports cryptographic policy. This can be one of the following values:
			/// </para>
			/// <list type="bullet">
			/// <item>
			/// <term>WSS_OBJTRUST_SUPPORT</term>
			/// </item>
			/// <item>
			/// <term>WSS_SIGTRUST_SUPPORT</term>
			/// </item>
			/// <item>
			/// <term>WSS_CERTTRUST_SUPPORT</term>
			/// </item>
			/// </list>
			/// </summary>
			public uint dwCryptoPolicySupport;

			/// <summary/>
			public uint iAttemptCount;

			/// <summary/>
			[MarshalAs(UnmanagedType.Bool)] public bool fCheckedSealing;

			/// <summary/>
			public IntPtr pSealingSignature;
		}

		/// <summary>
		/// <para>
		/// [The <c>CRYPT_PROVUI_DATA</c> structure is available for use in the operating systems specified in the Requirements section. It
		/// may be altered or unavailable in subsequent versions.]
		/// </para>
		/// <para>
		/// The <c>CRYPT_PROVUI_DATA</c> structure provides user interface (UI) data for a provider. This structure is used by the
		/// CRYPT_PROVUI_FUNCS structure.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wintrust/ns-wintrust-crypt_provui_data typedef struct _CRYPT_PROVUI_DATA {
		// DWORD cbStruct; DWORD dwFinalError; WCHAR *pYesButtonText; WCHAR *pNoButtonText; WCHAR *pMoreInfoButtonText; WCHAR
		// *pAdvancedLinkText; WCHAR *pCopyActionText; WCHAR *pCopyActionTextNoTS; WCHAR *pCopyActionTextNotSigned; } CRYPT_PROVUI_DATA, *PCRYPT_PROVUI_DATA;
		[PInvokeData("wintrust.h", MSDNShortId = "86f819f0-c243-45ba-8b7b-97ed906e6e8a")]
		[StructLayout(LayoutKind.Sequential)]
		public struct CRYPT_PROVUI_DATA
		{
			/// <summary>The size, in bytes, of this structure.</summary>
			public uint cbStruct;

			/// <summary>Error code, if applicable.</summary>
			public Win32Error dwFinalError;

			/// <summary>
			/// A pointer to a <c>null</c>-terminated string for the <c>Yes</c> button text. If this parameter is <c>NULL</c>, then
			/// "&amp;Yes" is used.
			/// </summary>
			public StrPtrUni pYesButtonText;

			/// <summary>
			/// A pointer to a <c>null</c>-terminated string for the <c>No</c> button text. If this parameter is <c>NULL</c>, then "&amp;No"
			/// is used.
			/// </summary>
			public StrPtrUni pNoButtonText;

			/// <summary>
			/// A pointer to a <c>null</c>-terminated string for the <c>More Info</c> button text. If this parameter is <c>NULL</c>, then
			/// "&amp;More Info" is used.
			/// </summary>
			public StrPtrUni pMoreInfoButtonText;

			/// <summary>A pointer to a <c>null</c>-terminated string for the <c>Advanced</c> button text.</summary>
			public StrPtrUni pAdvancedLinkText;

			/// <summary>
			/// A pointer to a <c>null</c>-terminated string for the text used when the trust is valid and a time stamp is used. If this
			/// parameter is <c>NULL</c>, then "Do you want to install and run ""%1"" signed on %2 and distributed by:" is used.
			/// </summary>
			public StrPtrUni pCopyActionText;

			/// <summary>
			/// A pointer to a <c>null</c>-terminated string for the text used when the trust is valid but a time stamp is not used. If this
			/// parameter is <c>NULL</c>, then "Do you want to install and run ""%1"" signed on an unknown date/time and distributed by:" is used.
			/// </summary>
			public StrPtrUni pCopyActionTextNoTS;

			/// <summary>
			/// A pointer to a <c>null</c>-terminated string for the text used when a signature is not provided. If this parameter is
			/// <c>NULL</c>, then "Do you want to install and run ""%1""?" is used.
			/// </summary>
			public StrPtrUni pCopyActionTextNotSigned;
		}

		/// <summary>
		/// <para>
		/// [The <c>CRYPT_PROVUI_FUNCS</c> structure is available for use in the operating systems specified in the Requirements section. It
		/// may be altered or unavailable in subsequent versions.]
		/// </para>
		/// <para>
		/// The <c>CRYPT_PROVUI_FUNCS</c> structure provides information about the user interface (UI) functions of a provider. This
		/// structure is used by the CRYPT_PROVIDER_FUNCTIONS structure.
		/// </para>
		/// </summary>
		/// <remarks>The prototype for PFN_PROVUI_CALL is defined as:</remarks>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wintrust/ns-wintrust-_crypt_provui_funcs typedef struct _CRYPT_PROVUI_FUNCS {
		// DWORD cbStruct; struct _CRYPT_PROVUI_DATA *psUIData; PFN_PROVUI_CALL pfnOnMoreInfoClick; PFN_PROVUI_CALL
		// pfnOnMoreInfoClickDefault; PFN_PROVUI_CALL pfnOnAdvancedClick; PFN_PROVUI_CALL pfnOnAdvancedClickDefault; } CRYPT_PROVUI_FUNCS, *PCRYPT_PROVUI_FUNCS;
		[PInvokeData("wintrust.h", MSDNShortId = "7cdc32ea-b28a-400f-ad8a-984f86bb95fd")]
		[StructLayout(LayoutKind.Sequential)]
		public struct CRYPT_PROVUI_FUNCS
		{
			/// <summary>The size, in bytes, of this structure.</summary>
			public uint cbStruct;

			/// <summary>A pointer to a CRYPT_PROVUI_DATA structure.</summary>
			public IntPtr psUIData;

			/// <summary>A pointer to the function called when the <c>More Info</c> button is clicked.</summary>
			public IntPtr pfnOnMoreInfoClick;

			/// <summary>A pointer to the default function called when the <c>More Info</c> button is clicked.</summary>
			public IntPtr pfnOnMoreInfoClickDefault;

			/// <summary>A pointer to the function called when the <c>Advanced</c> button is clicked.</summary>
			public IntPtr pfnOnAdvancedClick;

			/// <summary>A pointer to the default function called when the <c>Advanced</c> button is clicked.</summary>
			public IntPtr pfnOnAdvancedClickDefault;
		}

		/// <summary>
		/// <para>
		/// [The <c>CRYPT_REGISTER_ACTIONID</c> structure is available for use in the operating systems specified in the Requirements
		/// section. It may be altered or unavailable in subsequent versions.]
		/// </para>
		/// <para>
		/// The <c>CRYPT_REGISTER_ACTIONID</c> structure provides information about the functions of a provider. This structure is used by
		/// the WintrustAddActionID function.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wintrust/ns-wintrust-_crypt_register_actionid typedef struct
		// _CRYPT_REGISTER_ACTIONID { DWORD cbStruct; CRYPT_TRUST_REG_ENTRY sInitProvider; CRYPT_TRUST_REG_ENTRY sObjectProvider;
		// CRYPT_TRUST_REG_ENTRY sSignatureProvider; CRYPT_TRUST_REG_ENTRY sCertificateProvider; CRYPT_TRUST_REG_ENTRY
		// sCertificatePolicyProvider; CRYPT_TRUST_REG_ENTRY sFinalPolicyProvider; CRYPT_TRUST_REG_ENTRY sTestPolicyProvider;
		// CRYPT_TRUST_REG_ENTRY sCleanupProvider; } CRYPT_REGISTER_ACTIONID, *PCRYPT_REGISTER_ACTIONID;
		[PInvokeData("wintrust.h", MSDNShortId = "0b2b482f-f087-4be7-b17f-91c287c3460d")]
		[StructLayout(LayoutKind.Sequential)]
		public struct CRYPT_REGISTER_ACTIONID
		{
			/// <summary>The size, in bytes, of this structure.</summary>
			public uint cbStruct;

			/// <summary>CRYPT_TRUST_REG_ENTRY structure that identifies the function that initializes the provider.</summary>
			public CRYPT_TRUST_REG_ENTRY sInitProvider;

			/// <summary>CRYPT_TRUST_REG_ENTRY structure that identifies the object provider function.</summary>
			public CRYPT_TRUST_REG_ENTRY sObjectProvider;

			/// <summary>CRYPT_TRUST_REG_ENTRY structure that identifies the signature provider function.</summary>
			public CRYPT_TRUST_REG_ENTRY sSignatureProvider;

			/// <summary>CRYPT_TRUST_REG_ENTRY structure that identifies the certificate provider function.</summary>
			public CRYPT_TRUST_REG_ENTRY sCertificateProvider;

			/// <summary>CRYPT_TRUST_REG_ENTRY structure that identifies the certificate policy provider function.</summary>
			public CRYPT_TRUST_REG_ENTRY sCertificatePolicyProvider;

			/// <summary>CRYPT_TRUST_REG_ENTRY structure that identifies the final policy provider function.</summary>
			public CRYPT_TRUST_REG_ENTRY sFinalPolicyProvider;

			/// <summary>CRYPT_TRUST_REG_ENTRY structure that identifies the test policy provider function.</summary>
			public CRYPT_TRUST_REG_ENTRY sTestPolicyProvider;

			/// <summary>CRYPT_TRUST_REG_ENTRY structure that identifies the cleanup provider function.</summary>
			public CRYPT_TRUST_REG_ENTRY sCleanupProvider;
		}

		/// <summary>
		/// <para>
		/// [The <c>CRYPT_TRUST_REG_ENTRY</c> structure is available for use in the operating systems specified in the Requirements section.
		/// It may be altered or unavailable in subsequent versions.]
		/// </para>
		/// <para>
		/// The <c>CRYPT_TRUST_REG_ENTRY</c> structure identifies a provider function by DLL name and function name. This structure is used
		/// by the CRYPT_REGISTER_ACTIONID structure when the WintrustAddActionID function is called.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wintrust/ns-wintrust-_crypt_trust_reg_entry typedef struct
		// _CRYPT_TRUST_REG_ENTRY { DWORD cbStruct; WCHAR *pwszDLLName; WCHAR *pwszFunctionName; } CRYPT_TRUST_REG_ENTRY, *PCRYPT_TRUST_REG_ENTRY;
		[PInvokeData("wintrust.h", MSDNShortId = "1a531219-f254-4057-934b-af95bfe0bb83")]
		[StructLayout(LayoutKind.Sequential)]
		public struct CRYPT_TRUST_REG_ENTRY
		{
			/// <summary>The size, in bytes, of this structure.</summary>
			public uint cbStruct;

			/// <summary>A pointer to a null-terminated string for the DLL name.</summary>
			public StrPtrUni pwszDLLName;

			/// <summary>A pointer to a null-terminated string for the function name.</summary>
			public StrPtrUni pwszFunctionName;
		}

		/// <summary>Provides a handle to a catalog administrator context.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct HCATADMIN : IHandle
		{
			private IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="HCATADMIN"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public HCATADMIN(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="HCATADMIN"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static HCATADMIN NULL => new HCATADMIN(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="HCATADMIN"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(HCATADMIN h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HCATADMIN"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator HCATADMIN(IntPtr h) => new HCATADMIN(h);

			/// <summary>Implements the operator !=.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(HCATADMIN h1, HCATADMIN h2) => !(h1 == h2);

			/// <summary>Implements the operator ==.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(HCATADMIN h1, HCATADMIN h2) => h1.Equals(h2);

			/// <inheritdoc/>
			public override bool Equals(object obj) => obj is HCATADMIN h ? handle == h.handle : false;

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
		}

		/// <summary>Provides a handle to a cryptography message.</summary>
		[StructLayout(LayoutKind.Sequential)]
		public struct HCRYPTMSG : IHandle
		{
			private IntPtr handle;

			/// <summary>Initializes a new instance of the <see cref="HCRYPTMSG"/> struct.</summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public HCRYPTMSG(IntPtr preexistingHandle) => handle = preexistingHandle;

			/// <summary>Returns an invalid handle by instantiating a <see cref="HCRYPTMSG"/> object with <see cref="IntPtr.Zero"/>.</summary>
			public static HCRYPTMSG NULL => new HCRYPTMSG(IntPtr.Zero);

			/// <summary>Gets a value indicating whether this instance is a null handle.</summary>
			public bool IsNull => handle == IntPtr.Zero;

			/// <summary>Performs an explicit conversion from <see cref="HCRYPTMSG"/> to <see cref="IntPtr"/>.</summary>
			/// <param name="h">The handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static explicit operator IntPtr(HCRYPTMSG h) => h.handle;

			/// <summary>Performs an implicit conversion from <see cref="IntPtr"/> to <see cref="HCRYPTMSG"/>.</summary>
			/// <param name="h">The pointer to a handle.</param>
			/// <returns>The result of the conversion.</returns>
			public static implicit operator HCRYPTMSG(IntPtr h) => new HCRYPTMSG(h);

			/// <summary>Implements the operator !=.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator !=(HCRYPTMSG h1, HCRYPTMSG h2) => !(h1 == h2);

			/// <summary>Implements the operator ==.</summary>
			/// <param name="h1">The first handle.</param>
			/// <param name="h2">The second handle.</param>
			/// <returns>The result of the operator.</returns>
			public static bool operator ==(HCRYPTMSG h1, HCRYPTMSG h2) => h1.Equals(h2);

			/// <inheritdoc/>
			public override bool Equals(object obj) => obj is HCRYPTMSG h ? handle == h.handle : false;

			/// <inheritdoc/>
			public override int GetHashCode() => handle.GetHashCode();

			/// <inheritdoc/>
			public IntPtr DangerousGetHandle() => handle;
		}

		/// <summary>
		/// The <c>SPC_INDIRECT_DATA_CONTENT</c> structure is used in Authenticode signatures to store the digest and other attributes of the
		/// signed file.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wintrust/ns-wintrust-_spc_indirect_data_content typedef struct
		// _SPC_INDIRECT_DATA_CONTENT { CRYPT_ATTRIBUTE_TYPE_VALUE Data; CRYPT_ALGORITHM_IDENTIFIER DigestAlgorithm; CRYPT_HASH_BLOB Digest;
		// } SPC_INDIRECT_DATA_CONTENT, *PSPC_INDIRECT_DATA_CONTENT;
		[PInvokeData("wintrust.h", MSDNShortId = "BD790CA5-9C51-4483-93C1-5492154BF913")]
		[StructLayout(LayoutKind.Sequential)]
		public struct SPC_INDIRECT_DATA_CONTENT
		{
			/// <summary>A CRYPT_ATTRIBUTE_TYPE_VALUE that contains attributes of the digested file.</summary>
			public CRYPT_ATTRIBUTE_TYPE_VALUE Data;

			/// <summary>Specifies the digest algorithm used to hash the file.</summary>
			public CRYPT_ALGORITHM_IDENTIFIER DigestAlgorithm;

			/// <summary>The Authenticode digest value of the file using the algorithm specified in the DigestAlgorithm parameter.</summary>
			public CRYPTOAPI_BLOB Digest;
		}

		/// <summary>This structure encapsulates a signature used in verifying executable files.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wintrust/ns-wintrust-_win_certificate typedef struct _WIN_CERTIFICATE { DWORD
		// dwLength; WORD wRevision; WORD wCertificateType; BYTE bCertificate[ANYSIZE_ARRAY]; } WIN_CERTIFICATE, *LPWIN_CERTIFICATE;
		[PInvokeData("wintrust.h", MSDNShortId = "AC666871-265B-4D09-B7A6-DEC48D4645FD")]
		[StructLayout(LayoutKind.Sequential)]
		public struct WIN_CERTIFICATE
		{
			/// <summary>Specifies the length, in bytes, of the signature.</summary>
			public uint dwLength;

			/// <summary>
			/// <para>Specifies the certificate revision.</para>
			/// <para>The only defined certificate revision is <c>WIN_CERT_REVISION_1_0 (0x0100)</c>.</para>
			/// </summary>
			public ushort wRevision;

			/// <summary>
			/// <para>Specifies the type of certificate.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Description</term>
			/// </listheader>
			/// <item>
			/// <term>WIN_CERT_TYPE_X509 (0x0001)</term>
			/// <term>The bCertificate member contains an X.509 certificate.</term>
			/// </item>
			/// <item>
			/// <term>WIN_CERT_TYPE_PKCS_SIGNED_DATA (0x0002)</term>
			/// <term>The bCertificate member contains a PKCS SignedData structure.</term>
			/// </item>
			/// <item>
			/// <term>WIN_CERT_TYPE_RESERVED_1 (0x0003)</term>
			/// <term>Reserved.</term>
			/// </item>
			/// <item>
			/// <term>WIN_CERT_TYPE_PKCS1_SIGN (0x0009)</term>
			/// <term>The bCertificate member contains PKCS1_MODULE_SIGN fields.</term>
			/// </item>
			/// </list>
			/// </summary>
			public WIN_CERT_TYPE wCertificateType;

			/// <summary>
			/// <para>An array of certificates.</para>
			/// <para>The format of this member depends on the value of wCertificateType.</para>
			/// </summary>
			public IntPtr bCertificate;
		}

		/// <summary>
		/// <para>
		/// [The <c>WINTRUST_BLOB_INFO</c> structure is available for use in the operating systems specified in the Requirements section. It
		/// may be altered or unavailable in subsequent versions.]
		/// </para>
		/// <para>The <c>WINTRUST_BLOB_INFO</c> structure is used when calling WinVerifyTrust to verify a memory BLOB.</para>
		/// <para>
		/// <c>Note</c> This structure is not currently supported for the following Inbox file formats. There may be other formats besides
		/// these that are not supported. This structure is only supported by files formats with subject interface package (SIP) providers
		/// that support this structure.
		/// </para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wintrust/ns-wintrust-wintrust_blob_info_ typedef struct WINTRUST_BLOB_INFO_ {
		// DWORD cbStruct; GUID gSubject; LPCWSTR pcwszDisplayName; DWORD cbMemObject; BYTE *pbMemObject; DWORD cbMemSignedMsg; BYTE
		// *pbMemSignedMsg; } WINTRUST_BLOB_INFO, *PWINTRUST_BLOB_INFO;
		[PInvokeData("wintrust.h", MSDNShortId = "8b13d355-4d24-4d8e-aae3-db16467999be")]
		[StructLayout(LayoutKind.Sequential)]
		public struct WINTRUST_BLOB_INFO
		{
			/// <summary>The number of bytes in this structure.</summary>
			public uint cbStruct;

			/// <summary>The <c>GUID</c> of the SIP to load.</summary>
			public Guid gSubject;

			/// <summary>A string that contains the name of the memory object pointed to by <c>pbMem</c>.</summary>
			public StrPtrUni pcwszDisplayName;

			/// <summary>The length, in bytes, of the memory BLOB to be verified.</summary>
			public uint cbMemObject;

			/// <summary>A pointer to a memory BLOB to be verified.</summary>
			public IntPtr pbMemObject;

			/// <summary>This member is reserved. Do not use it.</summary>
			public uint cbMemSignedMsg;

			/// <summary>This member is reserved. Do not use it.</summary>
			public IntPtr pbMemSignedMsg;
		}

		/// <summary>
		/// The <c>WINTRUST_CATALOG_INFO</c> structure is used when calling WinVerifyTrust to verify a member of a Microsoft catalog.
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wintrust/ns-wintrust-wintrust_catalog_info_ typedef struct
		// WINTRUST_CATALOG_INFO_ { DWORD cbStruct; DWORD dwCatalogVersion; LPCWSTR pcwszCatalogFilePath; LPCWSTR pcwszMemberTag; LPCWSTR
		// pcwszMemberFilePath; HANDLE hMemberFile; BYTE *pbCalculatedFileHash; DWORD cbCalculatedFileHash; PCCTL_CONTEXT pcCatalogContext;
		// HCATADMIN hCatAdmin; } WINTRUST_CATALOG_INFO, *PWINTRUST_CATALOG_INFO;
		[PInvokeData("wintrust.h", MSDNShortId = "5d095e0f-c8c9-4717-b23a-985737b78431")]
		[StructLayout(LayoutKind.Sequential)]
		public struct WINTRUST_CATALOG_INFO
		{
			/// <summary>Size, in bytes, of this structure.</summary>
			public uint cbStruct;

			/// <summary>Optional. Catalog version number.</summary>
			public uint dwCatalogVersion;

			/// <summary>The full path and file name of the catalog file that contains the member to be verified.</summary>
			public StrPtrUni pcwszCatalogFilePath;

			/// <summary>Tag of a member file to be verified.</summary>
			public StrPtrUni pcwszMemberTag;

			/// <summary>The full path and file name of the catalog member file to be verified.</summary>
			public StrPtrUni pcwszMemberFilePath;

			/// <summary>
			/// Optional. Handle of the open catalog member file to be verified. The handle must be to a file with at least read permissions.
			/// </summary>
			public HFILE hMemberFile;

			/// <summary>Optional. The calculated hash of the file that contains the file to be verified.</summary>
			public IntPtr pbCalculatedFileHash;

			/// <summary>
			/// The size, in bytes, of the value passed in the <c>pbCalculatedFileHash</c> member. <c>cbCalculatedFileHash</c> is used only
			/// if the calculated hash is being passed.
			/// </summary>
			public uint cbCalculatedFileHash;

			/// <summary>A pointer to a CTL_CONTEXT structure that represents a catalog context to be used instead of a catalog file.</summary>
			public IntPtr pcCatalogContext;

			/// <summary>
			/// Handle to the catalog administrator context that was used when calculating the hash of the file. This value can be zero only
			/// for a SHA1 file hash. <c>Windows 8 and Windows Server 2012:</c> Support for this member begins.
			/// </summary>
			public HCATADMIN hCatAdmin;
		}

		/// <summary>
		/// <para>
		/// [The <c>WINTRUST_CERT_INFO</c> structure is available for use in the operating systems specified in the Requirements section. It
		/// may be altered or unavailable in subsequent versions.]
		/// </para>
		/// <para>The <c>WINTRUST_CERT_INFO</c> structure is used when calling WinVerifyTrust to verify a CERT_CONTEXT.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wintrust/ns-wintrust-wintrust_cert_info_ typedef struct WINTRUST_CERT_INFO_ {
		// DWORD cbStruct; LPCWSTR pcwszDisplayName; CERT_CONTEXT *psCertContext; DWORD chStores; HCERTSTORE *pahStores; DWORD dwFlags;
		// FILETIME *psftVerifyAsOf; } WINTRUST_CERT_INFO, *PWINTRUST_CERT_INFO;
		[PInvokeData("wintrust.h", MSDNShortId = "6522d1f0-3d96-4499-9220-23288122e0e6")]
		[StructLayout(LayoutKind.Sequential)]
		public struct WINTRUST_CERT_INFO
		{
			/// <summary>Count of bytes in this structure.</summary>
			public uint cbStruct;

			/// <summary>String with the name of the memory object pointed to by the <c>pbMem</c> member of the WINTRUST_BLOB_INFO structure.</summary>
			public StrPtrUni pcwszDisplayName;

			/// <summary>A pointer to the CERT_CONTEXT to be verified.</summary>
			public IntPtr psCertContext;

			/// <summary>The number of store handles in <c>pahStores</c>.</summary>
			public uint chStores;

			/// <summary>
			/// An array of open certificate stores to add to the list of stores that the policy provider looks in to find certificates while
			/// building a trust chain.
			/// </summary>
			public IntPtr pahStores;

			/// <summary/>
			public uint dwFlags;

			/// <summary/>
			public IntPtr psftVerifyAsOf;
		}

		/// <summary>The <c>WINTRUST_FILE_INFO</c> structure is used when calling WinVerifyTrust to verify an individual file.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wintrust/ns-wintrust-wintrust_file_info_ typedef struct WINTRUST_FILE_INFO_ {
		// DWORD cbStruct; LPCWSTR pcwszFilePath; HANDLE hFile; GUID *pgKnownSubject; } WINTRUST_FILE_INFO, *PWINTRUST_FILE_INFO;
		[PInvokeData("wintrust.h", MSDNShortId = "3c3bef86-a2ed-47d1-a726-90630433358a")]
		[StructLayout(LayoutKind.Sequential)]
		public struct WINTRUST_FILE_INFO
		{
			/// <summary>Count of bytes in this structure.</summary>
			public uint cbStruct;

			/// <summary>Full path and file name of the file to be verified. This parameter cannot be <c>NULL</c>.</summary>
			public StrPtrUni pcwszFilePath;

			/// <summary>
			/// Optional. File handle to the open file to be verified. This handle must be to a file that has at least read permission. This
			/// member can be set to <c>NULL</c>.
			/// </summary>
			public HFILE hFile;

			/// <summary>Optional. Pointer to a GUID structure that specifies the subject type. This member can be set to <c>NULL</c>.</summary>
			public IntPtr pgKnownSubject;
		}

		/// <summary>
		/// <para>
		/// [The <c>WINTRUST_SGNR_INFO</c> structure is available for use in the operating systems specified in the Requirements section. It
		/// may be altered or unavailable in subsequent versions.]
		/// </para>
		/// <para>The <c>WINTRUST_SGNR_INFO</c> structure is used when calling WinVerifyTrust to verify a CMSG_SIGNER_INFO structure.</para>
		/// </summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wintrust/ns-wintrust-wintrust_sgnr_info typedef struct WINTRUST_SGNR_INFO_ {
		// DWORD cbStruct; LPCWSTR pcwszDisplayName; CMSG_SIGNER_INFO *psSignerInfo; DWORD chStores; HCERTSTORE *pahStores; }
		// WINTRUST_SGNR_INFO, *PWINTRUST_SGNR_INFO;
		[PInvokeData("wintrust.h", MSDNShortId = "04e62bfa-efe4-428a-ae6b-58c2377fd5ba")]
		[StructLayout(LayoutKind.Sequential)]
		public struct WINTRUST_SGNR_INFO
		{
			/// <summary>Count of bytes in this structure.</summary>
			public uint cbStruct;

			/// <summary>String with the name representing the signer to be checked.</summary>
			public StrPtrUni pcwszDisplayName;

			/// <summary>A pointer to a CMSG_SIGNER_INFO structure that includes the signature to be verified.</summary>
			public IntPtr psSignerInfo;

			/// <summary>Number of store handles in <c>pahStores</c>.</summary>
			public uint chStores;

			/// <summary>
			/// An array of open certificate stores to be added to the list of stores that the policy provider uses to find certificates
			/// while building a trust chain.
			/// </summary>
			public IntPtr pahStores;
		}

		/// <summary>The <c>WINTRUST_SIGNATURE_SETTINGS</c> structure can be used to specify the signatures on a file.</summary>
		// https://docs.microsoft.com/en-us/windows/desktop/api/wintrust/ns-wintrust-wintrust_signature_settings_ typedef struct
		// WINTRUST_SIGNATURE_SETTINGS_ { DWORD cbStruct; DWORD dwIndex; DWORD dwFlags; DWORD cSecondarySigs; DWORD dwVerifiedSigIndex;
		// PCERT_STRONG_SIGN_PARA pCryptoPolicy; } WINTRUST_SIGNATURE_SETTINGS, *PWINTRUST_SIGNATURE_SETTINGS;
		[PInvokeData("wintrust.h", MSDNShortId = "E0F526B4-AFDE-4481-B49F-EE7467F97A46")]
		[StructLayout(LayoutKind.Sequential)]
		public struct WINTRUST_SIGNATURE_SETTINGS
		{
			/// <summary>Size, in bytes, of this structure.</summary>
			public uint cbStruct;

			/// <summary>Contains the index of the signature to be validated if the <c>dwFlags</c> member is set to <c>WSS_VERIFY_SPECIFIC</c>.</summary>
			public uint dwIndex;

			/// <summary>
			/// <para>Flags that can be used to refine behavior. This can be one of the following values.</para>
			/// <list type="table">
			/// <listheader>
			/// <term>Value</term>
			/// <term>Meaning</term>
			/// </listheader>
			/// <item>
			/// <term>WSS_VERIFY_SPECIFIC 0x00000001</term>
			/// <term>Set this value if you set the dwIndex parameter.</term>
			/// </item>
			/// <item>
			/// <term>WSS_GET_SECONDARY_SIG_COUNT 0x00000002</term>
			/// <term>Set this value to return the number of secondary signatures found in the cSecondarySigs member.</term>
			/// </item>
			/// </list>
			/// </summary>
			public uint dwFlags;

			/// <summary>Contains the number of secondary signatures found if the <c>dwFlags</c> member is set to <c>WSS_GET_SECONDARY_SIG_COUNT</c>.</summary>
			public uint cSecondarySigs;

			/// <summary>The index used for verification. This member is set on return from Wintrust.</summary>
			public uint dwVerifiedSigIndex;

			/// <summary>
			/// Pointer to a CERT_STRONG_SIGN_PARA structure that contains the policy that a signature must pass to be considered valid.
			/// </summary>
			public IntPtr pCryptoPolicy;
		}

		/// <summary>
		/// [The WINTRUST_DATA structure is available for use in the operating systems specified in the Requirements section. It may be
		/// altered or unavailable in subsequent versions.]
		/// <para>The WINTRUST_DATA structure is used when calling WinVerifyTrust to pass necessary information into the trust providers.</para>
		/// </summary>
		[PInvokeData("wintrust.h", MSDNShortId = "8fb68f44-6f69-4eac-90de-02689e3e86cf")]
		[StructLayout(LayoutKind.Sequential)]
		public class WINTRUST_DATA : IDisposable
		{
			/// <summary>The size, in bytes, of this structure.</summary>
			private int _cbStruct;

			/// <summary>A pointer to a data buffer used to pass policy-specific data to a policy provider. This member can be NULL.</summary>
			public IntPtr pPolicyCallbackData;

			/// <summary>
			/// A pointer to a data buffer used to pass subject interface package (SIP)-specific data to a SIP provider. This member can be NULL.
			/// </summary>
			public IntPtr pSIPCallbackData;

			/// <summary>Specifies the kind of user interface (UI) to be used.</summary>
			public WTD_UI dwUIChoice;

			/// <summary>
			/// Certificate revocation check options. This member can be set to add revocation checking to that done by the selected policy provider.
			/// </summary>
			public WTD_REVOKE fdwRevocationChecks;

			/// <summary>Specifies the union member to be used and, thus, the type of object for which trust will be verified.</summary>
			private WTD_CHOICE _dwUnionChoice;

			/// <summary>Pointer to the structure specified by <see cref="dwUnionChoice"/>.</summary>
			private IntPtr _pInfoStruct;

			/// <summary>Specifies the action to be taken.</summary>
			public WTD_STATEACTION dwStateAction;

			/// <summary>A handle to the state data. The contents of this member depends on the value of the dwStateAction member.</summary>
			public HANDLE hWVTStateData;

			/// <summary>Reserved for future use. Set to NULL.</summary>
			private StrPtrUni pwszURLReference;

			/// <summary>DWORD value that specifies trust provider settings.</summary>
			public WTD_TRUST dwProvFlags;

			/// <summary>
			/// A DWORD value that specifies the user interface context for the WinVerifyTrust function. This causes the text in the
			/// Authenticode dialog box to match the action taken on the file.
			/// </summary>
			public WTD_UICONTEXT dwUIContext;

			/// <summary>
			/// Pointer to a WINTRUST_SIGNATURE_SETTINGS structure.
			/// <para>Windows 8 and Windows Server 2012: Support for this member begins.</para>
			/// </summary>
			private IntPtr _pSignatureSettings;

			/// <summary>Initializes a new instance of the <see cref="WINTRUST_DATA"/> class.</summary>
			public WINTRUST_DATA()
			{
				_cbStruct = Marshal.SizeOf(typeof(WINTRUST_DATA));
				if (Environment.OSVersion.Version < new Version(6, 2))
					_cbStruct -= IntPtr.Size;
			}

			/// <summary>The size, in bytes, of this structure.</summary>
			public int cbStruct => _cbStruct;

			/// <summary>
			/// An optional WINTRUST_SIGNATURE_SETTINGS structure.
			/// <para>Windows 8 and Windows Server 2012: Support for this member begins.</para>
			/// </summary>
			public WINTRUST_SIGNATURE_SETTINGS? pSignatureSettings
			{
				get => _pSignatureSettings.ToNullableStructure<WINTRUST_SIGNATURE_SETTINGS>();
				set
				{
					if (Environment.OSVersion.Version < new Version(6, 2))
						throw new NotSupportedException();
					if (_pSignatureSettings != IntPtr.Zero)
						Marshal.FreeCoTaskMem(_pSignatureSettings);
					_pSignatureSettings = value.HasValue ? value.Value.MarshalToPtr(Marshal.AllocCoTaskMem, out _) : IntPtr.Zero;
				}
			}

			/// <summary>Gets or sets the optional file information.</summary>
			public WINTRUST_FILE_INFO? pFile
			{
				get => _dwUnionChoice == WTD_CHOICE.WTD_CHOICE_FILE ? _pInfoStruct.ToNullableStructure<WINTRUST_FILE_INFO>() : null;
				set
				{
					_dwUnionChoice = WTD_CHOICE.WTD_CHOICE_FILE;
					if (_pInfoStruct != IntPtr.Zero)
						Marshal.FreeCoTaskMem(_pInfoStruct);
					_pInfoStruct = value.HasValue ? value.Value.MarshalToPtr(Marshal.AllocCoTaskMem, out _) : IntPtr.Zero;
				}
			}

			/// <summary>Gets or sets the optional catalog information.</summary>
			public WINTRUST_CATALOG_INFO? pCatalog
			{
				get => _dwUnionChoice == WTD_CHOICE.WTD_CHOICE_CATALOG ? _pInfoStruct.ToNullableStructure<WINTRUST_CATALOG_INFO>() : null;
				set
				{
					_dwUnionChoice = WTD_CHOICE.WTD_CHOICE_CATALOG;
					if (_pInfoStruct != IntPtr.Zero)
						Marshal.FreeCoTaskMem(_pInfoStruct);
					_pInfoStruct = value.HasValue ? value.Value.MarshalToPtr(Marshal.AllocCoTaskMem, out _) : IntPtr.Zero;
				}
			}

			/// <summary>Gets or sets the optional blob information.</summary>
			public WINTRUST_BLOB_INFO? pBlob
			{
				get => _dwUnionChoice == WTD_CHOICE.WTD_CHOICE_BLOB ? _pInfoStruct.ToNullableStructure<WINTRUST_BLOB_INFO>() : null;
				set
				{
					_dwUnionChoice = WTD_CHOICE.WTD_CHOICE_BLOB;
					if (_pInfoStruct != IntPtr.Zero)
						Marshal.FreeCoTaskMem(_pInfoStruct);
					_pInfoStruct = value.HasValue ? value.Value.MarshalToPtr(Marshal.AllocCoTaskMem, out _) : IntPtr.Zero;
				}
			}

			/// <summary>Gets or sets the optional signature information.</summary>
			public WINTRUST_SGNR_INFO? pSgnr
			{
				get => _dwUnionChoice == WTD_CHOICE.WTD_CHOICE_SIGNER ? _pInfoStruct.ToNullableStructure<WINTRUST_SGNR_INFO>() : null;
				set
				{
					_dwUnionChoice = WTD_CHOICE.WTD_CHOICE_SIGNER;
					if (_pInfoStruct != IntPtr.Zero)
						Marshal.FreeCoTaskMem(_pInfoStruct);
					_pInfoStruct = value.HasValue ? value.Value.MarshalToPtr(Marshal.AllocCoTaskMem, out _) : IntPtr.Zero;
				}
			}

			/// <summary>Gets or sets the optional certificate information.</summary>
			public WINTRUST_CERT_INFO? pCert
			{
				get => _dwUnionChoice == WTD_CHOICE.WTD_CHOICE_CERT ? _pInfoStruct.ToNullableStructure<WINTRUST_CERT_INFO>() : null;
				set
				{
					_dwUnionChoice = WTD_CHOICE.WTD_CHOICE_CERT;
					if (_pInfoStruct != IntPtr.Zero)
						Marshal.FreeCoTaskMem(_pInfoStruct);
					_pInfoStruct = value.HasValue ? value.Value.MarshalToPtr(Marshal.AllocCoTaskMem, out _) : IntPtr.Zero;
				}
			}

			/// <summary>Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.</summary>
			void IDisposable.Dispose()
			{
				if (_pInfoStruct != IntPtr.Zero)
					Marshal.FreeCoTaskMem(_pInfoStruct);
			}
		}

		/*
		OpenPersonalTrustDBDialog https://docs.microsoft.com/en-us/windows/desktop/api/wintrust/nf-wintrust-openpersonaltrustdbdialog
		OpenPersonalTrustDBDialogEx https://docs.microsoft.com/en-us/windows/desktop/api/wintrust/nf-wintrust-openpersonaltrustdbdialogex
		WTHelperCertCheckValidSignature https://docs.microsoft.com/en-us/windows/desktop/api/wintrust/nf-wintrust-wthelpercertcheckvalidsignature
		WTHelperCertFindIssuerCertificate https://docs.microsoft.com/en-us/windows/desktop/SecCrypto/wthelpercertfindissuercertificate
		WTHelperCertIsSelfSigned https://docs.microsoft.com/en-us/windows/desktop/api/wintrust/nf-wintrust-wthelpercertisselfsigned
		WTHelperGetFileHash https://docs.microsoft.com/en-us/windows/desktop/SecCrypto/wthelpergetfilehash
		WTHelperGetProvCertFromChain https://docs.microsoft.com/en-us/windows/desktop/api/wintrust/nf-wintrust-wthelpergetprovcertfromchain
		WTHelperGetProvPrivateDataFromChain https://docs.microsoft.com/en-us/windows/desktop/api/wintrust/nf-wintrust-wthelpergetprovprivatedatafromchain
		WTHelperGetProvSignerFromChain https://docs.microsoft.com/en-us/windows/desktop/api/wintrust/nf-wintrust-wthelpergetprovsignerfromchain
		WTHelperProvDataFromStateData https://docs.microsoft.com/en-us/windows/desktop/api/wintrust/nf-wintrust-wthelperprovdatafromstatedata
		WinVerifyTrust https://docs.microsoft.com/en-us/windows/desktop/api/wintrust/nf-wintrust-winverifytrust
		WinVerifyTrustEx https://docs.microsoft.com/en-us/windows/desktop/api/wintrust/nf-wintrust-winverifytrustex
		WintrustAddActionID https://docs.microsoft.com/en-us/windows/desktop/api/wintrust/nf-wintrust-wintrustaddactionid
		WintrustAddDefaultForUsage https://docs.microsoft.com/en-us/windows/desktop/api/wintrust/nf-wintrust-wintrustadddefaultforusage
		WintrustGetDefaultForUsage https://docs.microsoft.com/en-us/windows/desktop/api/wintrust/nf-wintrust-wintrustgetdefaultforusage
		WintrustGetRegPolicyFlags https://docs.microsoft.com/en-us/windows/desktop/api/wintrust/nf-wintrust-wintrustgetregpolicyflags
		WintrustLoadFunctionPointers https://docs.microsoft.com/en-us/windows/desktop/api/wintrust/nf-wintrust-wintrustloadfunctionpointers
		WintrustRemoveActionID https://docs.microsoft.com/en-us/windows/desktop/api/wintrust/nf-wintrust-wintrustremoveactionid
		WintrustSetDefaultIncludePEPageHashes https://docs.microsoft.com/en-us/windows/desktop/api/wintrust/nf-wintrust-wintrustsetdefaultincludepepagehashes
		WintrustSetRegPolicyFlags https://docs.microsoft.com/en-us/windows/desktop/api/wintrust/nf-wintrust-wintrustsetregpolicyflags
		*/
	}
}