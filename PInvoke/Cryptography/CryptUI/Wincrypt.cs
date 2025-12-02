using static Vanara.PInvoke.Crypt32;

namespace Vanara.PInvoke;

/// <summary>Methods and data types found in CryptUI.dll.</summary>
public static partial class CryptUI
{
	/// <summary>
	/// The <c>PFNCFILTERPROC</c> function is an application-defined callback function that filters the certificates that appear in the
	/// digital signature wizard that are displayed by the CryptUIWizDigitalSign function.
	/// </summary>
	/// <param name="pCertContext">A pointer to a CERT_CONTEXT structure that contains the certificate to filter.</param>
	/// <param name="pfInitialSelectedCert"/>
	/// <param name="pvCallbackData"/>
	/// <returns>
	/// A Boolean value that specifies whether the certificate contained in the CERT_CONTEXT structure pointed to by the pCertContext
	/// parameter should be displayed in the digital signature wizard.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/cryptuiapi/nc-cryptuiapi-pfncfilterproc PFNCFILTERPROC Pfncfilterproc; BOOL
	// Pfncfilterproc( PCCERT_CONTEXT pCertContext, BOOL *pfInitialSelectedCert, void *pvCallbackData ) {...}
	[PInvokeData("cryptuiapi.h", MSDNShortId = "ced0f35c-7e22-4d19-8352-0bfa37ff1a4b")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public delegate bool PFNCFILTERPROC(PCCERT_CONTEXT pCertContext, [MarshalAs(UnmanagedType.Bool)] ref bool pfInitialSelectedCert, IntPtr pvCallbackData);

	/// <summary>Flags that can be combined to exclude columns of the display.</summary>
	[PInvokeData("cryptuiapi.h", MSDNShortId = "5774af1c-f2d4-4b1e-a20b-dfb57bf9aa37")]
	[Flags]
	public enum CryptUISelect
	{
		/// <summary>Do not display the ISSUEDTO information.</summary>
		CRYPTUI_SELECT_ISSUEDTO_COLUMN = 0x000000001,

		/// <summary>Do not display the ISSUEDBY information.</summary>
		CRYPTUI_SELECT_ISSUEDBY_COLUMN = 0x000000002,

		/// <summary>Do not display IntendedUse information.</summary>
		CRYPTUI_SELECT_INTENDEDUSE_COLUMN = 0x000000004,

		/// <summary>Do not display the display name information.</summary>
		CRYPTUI_SELECT_FRIENDLYNAME_COLUMN = 0x000000008,

		/// <summary>Do not display location information.</summary>
		CRYPTUI_SELECT_LOCATION_COLUMN = 0x000000010,

		/// <summary>Do not display expiration information.</summary>
		CRYPTUI_SELECT_EXPIRATION_COLUMN = 0x000000020,
	}

	/// <summary>Flags for <see cref="CRYPTUI_VIEWCERTIFICATE_STRUCT"/>.</summary>
	[PInvokeData("cryptuiapi.h", MSDNShortId = "7bbd58df-3a1b-4d82-9a90-7c94260a7165")]
	[Flags]
	public enum CryptUIViewCertificateFlags : uint
	{
		/// <summary>The Certification Path page is disabled.</summary>
		CRYPTUI_HIDE_HIERARCHYPAGE = 0x00000001,

		/// <summary>The Details page is disabled.</summary>
		CRYPTUI_HIDE_DETAILPAGE = 0x00000002,

		/// <summary>The user is not allowed to change the properties.</summary>
		CRYPTUI_DISABLE_EDITPROPERTIES = 0x00000004,

		/// <summary>The user is allowed to change the properties.</summary>
		CRYPTUI_ENABLE_EDITPROPERTIES = 0x00000008,

		/// <summary>The Install button is disabled.</summary>
		CRYPTUI_DISABLE_ADDTOSTORE = 0x00000010,

		/// <summary>The Install button is enabled.</summary>
		CRYPTUI_ENABLE_ADDTOSTORE = 0x00000020,

		/// <summary>The pages or buttons that allow the user to accept or decline any decision are disabled.</summary>
		CRYPTUI_ACCEPT_DECLINE_STYLE = 0x00000040,

		/// <summary>An untrusted root error is ignored.</summary>
		CRYPTUI_IGNORE_UNTRUSTED_ROOT = 0x00000080,

		/// <summary>Known trusted stores will not be used to build the chain.</summary>
		CRYPTUI_DONT_OPEN_STORES = 0x00000100,

		/// <summary>A known trusted root store will not be used to build the chain.</summary>
		CRYPTUI_ONLY_OPEN_ROOT_STORE = 0x00000200,

		/// <summary>
		/// Use only when viewing certificates on remote computers. If this flag is used, the first element of rghStores must be the
		/// handle of the root store on the remote computer.
		/// </summary>
		CRYPTUI_WARN_UNTRUSTED_ROOT = 0x00000400,

		/// <summary>
		/// Enable revocation checking with default behavior. The default behavior is to enable revocation checking of the entire
		/// certificate chain except the root certificate. Valid only if neither the pCryptProviderData nor the hWVTStateData union
		/// member is passed in.
		/// </summary>
		CRYPTUI_ENABLE_REVOCATION_CHECKING = 0x00000800,

		/// <summary>
		/// When building a certificate chain for a remote computer, warn that the chain may not be trusted on the remote computer.
		/// </summary>
		CRYPTUI_WARN_REMOTE_TRUST = 0x00001000,

		/// <summary>If this flag is set, the Copy to file button will be disabled on the Detail page.</summary>
		CRYPTUI_DISABLE_EXPORT = 0x00002000,

		/// <summary>
		/// Enable revocation checking only on the leaf certificate in the certificate chain. Valid only if neither the
		/// pCryptProviderData nor the hWVTStateData union member is passed in.
		/// </summary>
		CRYPTUI_ENABLE_REVOCATION_CHECK_END_CERT = 0x00004000,

		/// <summary>
		/// Enable revocation checking on each certificate in the certificate chain. Valid only if neither the pCryptProviderData nor
		/// the hWVTStateData union member is passed in. Note Because root certificates rarely contain information that allows
		/// revocation checking, it is expected that use of this option will usually result in failure of the CryptUIDlgViewCertificate
		/// function. The recommended option is to use CRYPTUI_ENABLE_REVOCATION_CHECK_CHAIN_EXCLUDE_ROOT.
		/// </summary>
		CRYPTUI_ENABLE_REVOCATION_CHECK_CHAIN = 0x00008000,

		/// <summary>
		/// Enable revocation checking on each certificate in the certificate chain except for the root certificate. This is the
		/// recommended option to use for certificate revocation checking. Valid only if neither the pCryptProviderData nor the
		/// hWVTStateData union member is passed in. Note This flag is equivalent to CRYPTUI_ENABLE_REVOCATION_CHECKING.
		/// </summary>
		CRYPTUI_ENABLE_REVOCATION_CHECK_CHAIN_EXCLUDE_ROOT = CRYPTUI_ENABLE_REVOCATION_CHECKING,

		/// <summary>Disable the HTML Help button (?) in the Certificate dialog box.</summary>
		CRYPTUI_DISABLE_HTMLLINK = 0x00010000,

		/// <summary>Disable the Issuer Statement button on the General tab of the Certificate dialog box.</summary>
		CRYPTUI_DISABLE_ISSUERSTATEMENT = 0x00020000,

		/// <summary>
		/// Disable online revocation checking. Set this flag to ensure that the CryptUIDlgViewCertificate function uses the local cache
		/// to retrieve the certificate and does not attempt to retrieve the certificate from the network. Windows Server 2008, Windows
		/// Vista, Windows Server 2003 and Windows XP: This flag is not supported.
		/// </summary>
		CRYPTUI_CACHE_ONLY_URL_RETRIEVAL = 0x00040000,
	}

	/// <summary>A value that indicates whether additional certificates will be included in the signature.</summary>
	[PInvokeData("cryptuiapi.h", MSDNShortId = "22d0bc45-0f66-4f5f-87d3-0849c4327eed")]
	public enum CryptUIWizAddChoice
	{
		/// <summary>No additional certificates will be included in the signature.</summary>
		CRYPTUI_WIZ_DIGITAL_SIGN_ADD_NONE = 0x0,

		/// <summary>The entire certificate chain will be included in the signature.</summary>
		CRYPTUI_WIZ_DIGITAL_SIGN_ADD_CHAIN = 0x00000001,

		/// <summary>All certificates in the certificate chain except the root will be included in the signature.</summary>
		CRYPTUI_WIZ_DIGITAL_SIGN_ADD_CHAIN_NO_ROOT = 0x00000002,
	}

	/// <summary>Indicates the type of the subject to export.</summary>
	[PInvokeData("cryptuiapi.h", MSDNShortId = "3c509bb6-d391-4b59-809c-23466c8196ea")]
	public enum CryptUIWizExportType
	{
		/// <summary>Export the certificate context that is specified in the pCertContext member.</summary>
		CRYPTUI_WIZ_EXPORT_CERT_CONTEXT = 1,

		/// <summary>Export the certificate trust list (CTL) context that is specified in the pCTLContext member.</summary>
		CRYPTUI_WIZ_EXPORT_CTL_CONTEXT = 2,

		/// <summary>Export the certificate revocation list (CRL) context that is specified in the pCRLContext member.</summary>
		CRYPTUI_WIZ_EXPORT_CRL_CONTEXT = 3,

		/// <summary>Export the certificate store that is specified in the hCertStore member.</summary>
		CRYPTUI_WIZ_EXPORT_CERT_STORE = 4,

		/// <summary>Export only the certificates from the certificate store that is specified in the hCertStore member.</summary>
		CRYPTUI_WIZ_EXPORT_CERT_STORE_CERTIFICATES_ONLY = 5,

		/// <summary/>
		CRYPTUI_WIZ_EXPORT_FORMAT_CRL = 6,

		/// <summary/>
		CRYPTUI_WIZ_EXPORT_FORMAT_CTL = 7,
	}

	/// <summary>Contains flags that modify the behavior of <see cref="CryptUIWizDigitalSign"/>.</summary>
	[PInvokeData("cryptuiapi.h", MSDNShortId = "1d01523e-d47b-49be-82c8-5e98f97be800")]
	[Flags]
	public enum CryptUIWizFlags : uint
	{
		/// <summary>
		/// This function will sign the document based on the information in the CRYPTUI_WIZ_DIGITAL_SIGN_INFO structure pointed to by
		/// the pDigitalSignInfo parameter without displaying any user interface. If this flag is not specified, this function will
		/// display a wizard to guide the user through the signing process.
		/// </summary>
		CRYPTUI_WIZ_NO_UI = 0x0001,

		/// <summary>
		/// Suppress all user interfaces generated by cryptographic service providers (CSPs). This option can be overridden by the
		/// CRYPTUI_WIZ_NO_UI_EXCEPT_CSP option.
		/// </summary>
		CRYPTUI_WIZ_IGNORE_NO_UI_FLAG_FOR_CSPS = 0x0002,

		/// <summary>
		/// Suppress all user interfaces except those generated by CSPs. This option overrides the
		/// CRYPTUI_WIZ_IGNORE_NO_UI_FLAG_FOR_CSPS option.
		/// </summary>
		CRYPTUI_WIZ_NO_UI_EXCEPT_CSP = 0x0003,

		/// <summary>Skip the Export Private Key page and assume that the private key is to be exported.</summary>
		CRYPTUI_WIZ_EXPORT_PRIVATE_KEY = 0x0100,

		/// <summary>Disable the Delete the private key check box in the Export File Format page.</summary>
		CRYPTUI_WIZ_EXPORT_NO_DELETE_PRIVATE_KEY = 0x0200,

		/// <summary>Allow certificates to be imported.</summary>
		CRYPTUI_WIZ_IMPORT_ALLOW_CERT = 0x00020000,

		/// <summary>Allow CRLs to be imported.</summary>
		CRYPTUI_WIZ_IMPORT_ALLOW_CRL = 0x00040000,

		/// <summary>Allow CTLs to be imported.</summary>
		CRYPTUI_WIZ_IMPORT_ALLOW_CTL = 0x00080000,

		/// <summary>Do not allow the user to change the destination certificate store represented by the hDestCertStore parameter.</summary>
		CRYPTUI_WIZ_IMPORT_NO_CHANGE_DEST_STORE = 0x00010000,

		/// <summary>
		/// Import the object to the certificate store for the local computer. This applies only to Personal Information Exchange (PFX) imports.
		/// </summary>
		CRYPTUI_WIZ_IMPORT_TO_LOCALMACHINE = 0x00100000,

		/// <summary>Import the object to the certificate store for the current user. This applies only to PFX imports.</summary>
		CRYPTUI_WIZ_IMPORT_TO_CURRENTUSER = 0x00200000,

		/// <summary>
		/// Import the object to a remote certificate store. Set this flag if the hDestCertStore parameter represents a remote
		/// certificate store.
		/// </summary>
		CRYPTUI_WIZ_IMPORT_REMOTE_DEST_STORE = 0x00400000,
	}

	/// <summary>Indicates the type of subject to import.</summary>
	[PInvokeData("cryptuiapi.h", MSDNShortId = "17d932e3-05ea-4ed0-9f88-fbb674b6b070")]
	public enum CryptUIWizImportType
	{
		/// <summary>Import the certificate stored in the file referenced in the pwszFileName member.</summary>
		CRYPTUI_WIZ_IMPORT_SUBJECT_FILE = 1,

		/// <summary>Import the certificate referenced in the pCertContext member.</summary>
		CRYPTUI_WIZ_IMPORT_SUBJECT_CERT_CONTEXT = 2,

		/// <summary>Import the CTL referenced in the pCTLContext member.</summary>
		CRYPTUI_WIZ_IMPORT_SUBJECT_CTL_CONTEXT = 3,

		/// <summary>Import the CRL referenced in the pCRLContext member.</summary>
		CRYPTUI_WIZ_IMPORT_SUBJECT_CRL_CONTEXT = 4,

		/// <summary>Import the certificate store referenced in the hCertStore member.</summary>
		CRYPTUI_WIZ_IMPORT_SUBJECT_CERT_STORE = 5,
	}

	/// <summary>Specifies the type of entity that contains the certificates.</summary>
	[PInvokeData("cryptuiapi.h", MSDNShortId = "0316ed0b-d4e5-4102-9ab0-637e96c7d9f5")]
	[Flags]
	public enum CryptUIWizPVKChoice
	{
		/// <summary>The entity is a PVK file.</summary>
		CRYPTUI_WIZ_DIGITAL_SIGN_PVK_FILE = 0x01,

		/// <summary>The entity is a PVK provider.</summary>
		CRYPTUI_WIZ_DIGITAL_SIGN_PVK_PROV = 0x02,
	}

	/// <summary>A value that specifies the location of the certificate that is used to sign the entity.</summary>
	[PInvokeData("cryptuiapi.h", MSDNShortId = "22d0bc45-0f66-4f5f-87d3-0849c4327eed")]
	public enum CryptUIWizSignLoc
	{
		/// <summary>The certificates in the My store are used.</summary>
		CRYPTUI_WIZ_DIGITAL_SIGN_USE_MY_STORE = 0x0,

		/// <summary>The certificate is contained in the CERT_CONTEXT structure pointed to by the pSigningCertContext member.</summary>
		CRYPTUI_WIZ_DIGITAL_SIGN_CERT = 0x01,

		/// <summary>
		/// The certificate is contained in the certificate store contained in the CRYPTUI_WIZ_DIGITAL_SIGN_STORE_INFO structure pointed
		/// to by the pSigningCertStore member.
		/// </summary>
		CRYPTUI_WIZ_DIGITAL_SIGN_STORE = 0x02,

		/// <summary>
		/// The certificate is contained in the PVK file contained in the CRYPTUI_WIZ_DIGITAL_SIGN_CERT_PVK_INFO structure pointed to by
		/// the pSigningCertPvkInfo member.
		/// </summary>
		CRYPTUI_WIZ_DIGITAL_SIGN_PVK = 0x03,
	}

	/// <summary>A value that indicates the type of the signature.</summary>
	[PInvokeData("cryptuiapi.h", MSDNShortId = "e061aac4-8c9f-4282-a8f8-bc0c5a10e566")]
	[Flags]
	public enum CryptUIWizSigType
	{
		/// <summary>The signature is a commercial signature.</summary>
		CRYPTUI_WIZ_DIGITAL_SIGN_COMMERCIAL = 0x01,

		/// <summary>The signature is a personal signature.</summary>
		CRYPTUI_WIZ_DIGITAL_SIGN_INDIVIDUAL = 0x02,
	}

	/// <summary>A value that indicates the entity that is to be signed.</summary>
	[PInvokeData("cryptuiapi.h", MSDNShortId = "22d0bc45-0f66-4f5f-87d3-0849c4327eed")]
	public enum CryptUIWizToSign
	{
		/// <summary>The user will be prompted for a file to sign.</summary>
		CRYPTUI_WIZ_DIGITAL_SIGN_SUBJECT_PROMPT = 0,

		/// <summary>The memory BLOB specified by the pSignBlobInfo member is to be signed.</summary>
		CRYPTUI_WIZ_DIGITAL_SIGN_SUBJECT_FILE = 0x01,

		/// <summary>The file specified by the pwszFileName member is to be signed.</summary>
		CRYPTUI_WIZ_DIGITAL_SIGN_SUBJECT_BLOB = 0x02,
	}

	/// <summary>
	/// The <c>CertSelectionGetSerializedBlob</c> function is a helper function used to retrieve a serialized certificate BLOB from a
	/// CERT_SELECTUI_INPUT structure.
	/// </summary>
	/// <param name="pcsi">
	/// A pointer to a CERT_SELECTUI_INPUT structure that contains the certificate store and certificate context chain information.
	/// </param>
	/// <param name="ppOutBuffer">The address of a pointer to a buffer that receives the serialized certificates BLOB.</param>
	/// <param name="pulOutBufferSize">
	/// A pointer to a <c>ULONG</c> to receive the size, in bytes, of the BLOB received in the buffer pointed to by the ppOutBuffer parameter.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns <c>S_OK</c>.</para>
	/// <para>
	/// If the function fails, it returns an <c>HRESULT</c> value that indicates the error. If both <c>hStore</c> and <c>prgpChain</c>
	/// parameters are not <c>NULL</c>, return <c>E_INVALIDARG</c>. For a list of common error codes, see Common HRESULT Values.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The returned serialized BLOB is passed to the CredUIPromptForWindowsCredentials function in the pvInAuthBuffer parameter to
	/// allow a user to select a certificate by using the credential selection UI.
	/// </para>
	/// <para>
	/// The certificates that are serialized in the BLOB returned in the buffer pointed to by the ppOutBuffer parameter of this function
	/// are dependent on the values of the <c>hStore</c> and <c>prgpChain</c> members of the CERT_SELECTUI_INPUT structure.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>hStore</term>
	/// <term>prgpChain</term>
	/// <term>Certificates serialized</term>
	/// </listheader>
	/// <item>
	/// <term>NULL</term>
	/// <term>not NULL</term>
	/// <term>The certificates pointed to by the prgpChain member are serialized.</term>
	/// </item>
	/// <item>
	/// <term>not NULL</term>
	/// <term>NULL</term>
	/// <term>The certificates specified by the hStore member are serialized.</term>
	/// </item>
	/// <item>
	/// <term>NULL</term>
	/// <term>NULL</term>
	/// <term>An empty BLOB is returned.</term>
	/// </item>
	/// <item>
	/// <term>not NULL</term>
	/// <term>not NULL</term>
	/// <term>The call fails and the function returns E_INVALIDARG.</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cryptuiapi/nf-cryptuiapi-certselectiongetserializedblob HRESULT
	// CertSelectionGetSerializedBlob( PCERT_SELECTUI_INPUT pcsi, void **ppOutBuffer, ULONG *pulOutBufferSize );
	[DllImport(Lib.CryptUI, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cryptuiapi.h", MSDNShortId = "6c3240f7-5121-401d-a4d4-df3055cb301a")]
	public static extern HRESULT CertSelectionGetSerializedBlob(in CERT_SELECTUI_INPUT pcsi, out IntPtr ppOutBuffer, out uint pulOutBufferSize);

	/// <summary>The <c>CryptUIDlgCertMgr</c> function displays a dialog box that allows the user to manage certificates.</summary>
	/// <param name="pCryptUICertMgr">
	/// A pointer to a CRYPTUI_CERT_MGR_STRUCT structure that contains information about how to create the dialog box.
	/// </param>
	/// <returns>The return value is <c>TRUE</c> if the function succeeds; otherwise, <c>FALSE.</c></returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/cryptuiapi/nf-cryptuiapi-cryptuidlgcertmgr BOOL CryptUIDlgCertMgr(
	// PCCRYPTUI_CERT_MGR_STRUCT pCryptUICertMgr );
	[DllImport(Lib.CryptUI, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cryptuiapi.h", MSDNShortId = "8d94694e-1724-42aa-99bb-6ed2c6d3bc0e")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptUIDlgCertMgr(in CRYPTUI_CERT_MGR_STRUCT pCryptUICertMgr);

	/// <summary>
	/// The <c>CryptUIDlgSelectCertificateFromStore</c> function displays a dialog box that allows the selection of a certificate from a
	/// specified store.
	/// </summary>
	/// <param name="hCertStore">Handle of the certificate store to be searched.</param>
	/// <param name="hwnd">Handle of the window for the display. If <c>NULL</c>, defaults to the desktop window.</param>
	/// <param name="pwszTitle">
	/// String used as the title of the dialog box. If <c>NULL</c>, the default title, "Select Certificate," is used.
	/// </param>
	/// <param name="pwszDisplayString">
	/// Text statement in the selection dialog box. If <c>NULL</c>, the default phrase, "Select a certificate you want to use," is used.
	/// </param>
	/// <param name="dwDontUseColumn">
	/// <para>Flags that can be combined to exclude columns of the display.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPTUI_SELECT_ISSUEDTO_COLUMN</term>
	/// <term>Do not display the ISSUEDTO information.</term>
	/// </item>
	/// <item>
	/// <term>CRYPTUI_SELECT_ISSUEDBY_COLUMN</term>
	/// <term>Do not display the ISSUEDBY information.</term>
	/// </item>
	/// <item>
	/// <term>CRYPTUI_SELECT_INTENDEDUSE_COLUMN</term>
	/// <term>Do not display IntendedUse information.</term>
	/// </item>
	/// <item>
	/// <term>CRYPTUI_SELECT_FRIENDLYNAME_COLUMN</term>
	/// <term>Do not display the display name information.</term>
	/// </item>
	/// <item>
	/// <term>CRYPTUI_SELECT_LOCATION_COLUMN</term>
	/// <term>Do not display location information.</term>
	/// </item>
	/// <item>
	/// <term>CRYPTUI_SELECT_EXPIRATION_COLUMN</term>
	/// <term>Do not display expiration information.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwFlags">Currently not used and should be set to 0.</param>
	/// <param name="pvReserved">Reserved for future use.</param>
	/// <returns>
	/// Returns a pointer to the selected certificate context. If no certificate was selected, <c>NULL</c> is returned. When you have
	/// finished using the certificate, free the certificate context by calling the CertFreeCertificateContext function.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/cryptuiapi/nf-cryptuiapi-cryptuidlgselectcertificatefromstore PCCERT_CONTEXT
	// CryptUIDlgSelectCertificateFromStore( HCERTSTORE hCertStore, HWND hwnd, LPCWSTR pwszTitle, LPCWSTR pwszDisplayString, DWORD
	// dwDontUseColumn, DWORD dwFlags, void *pvReserved );
	[DllImport(Lib.CryptUI, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cryptuiapi.h", MSDNShortId = "5774af1c-f2d4-4b1e-a20b-dfb57bf9aa37")]
	public static extern SafePCCERT_CONTEXT CryptUIDlgSelectCertificateFromStore([In] HCERTSTORE hCertStore, [In, Optional] HWND hwnd, [Optional, MarshalAs(UnmanagedType.LPWStr)] string? pwszTitle,
		[Optional, MarshalAs(UnmanagedType.LPWStr)] string? pwszDisplayString, CryptUISelect dwDontUseColumn, uint dwFlags = 0, IntPtr pvReserved = default);

	/// <summary>The <c>CryptUIDlgViewCertificate</c> function presents a dialog box that displays a specified certificate.</summary>
	/// <param name="pCertViewInfo">
	/// A pointer to a CRYPTUI_VIEWCERTIFICATE_STRUCT structure that contains information about the certificate to view.
	/// </param>
	/// <param name="pfPropertiesChanged">Indicates whether any certificate properties were modified by the caller.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero ( <c>TRUE</c>).</para>
	/// <para>
	/// If the function fails, the return value is zero ( <c>FALSE</c>). For extended error information, call the GetLastError function.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/cryptuiapi/nf-cryptuiapi-cryptuidlgviewcertificatea BOOL
	// CryptUIDlgViewCertificateA( PCCRYPTUI_VIEWCERTIFICATE_STRUCTA pCertViewInfo, BOOL *pfPropertiesChanged );
	[DllImport(Lib.CryptUI, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("cryptuiapi.h", MSDNShortId = "5107ff22-78c4-4005-80af-ff45781da6c7")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptUIDlgViewCertificate(in CRYPTUI_VIEWCERTIFICATE_STRUCT pCertViewInfo, [MarshalAs(UnmanagedType.Bool)] out bool pfPropertiesChanged);

	/// <summary>The <c>CryptUIDlgViewContext</c> function displays a certificate, CTL, or CRL context.</summary>
	/// <param name="dwContextType">
	/// <para>
	/// <c>DWORD</c> indicating whether pvContext is a pointer to a certificate, a CRL, or a CTL context as indicated in the following table.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CERT_STORE_CERTIFICATE_CONTEXT</term>
	/// <term>PCCERT_CONTEXT</term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_CRL_CONTEXT</term>
	/// <term>PCCRL_CONTEXT</term>
	/// </item>
	/// <item>
	/// <term>CERT_STORE_CTL_CONTEXT</term>
	/// <term>PCCTL_CONTEXT</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pvContext">A pointer to a certificate, CRL, or CTL context to be displayed.</param>
	/// <param name="hwnd">Handle of the window for the display. If <c>NULL</c>, the display defaults to the desktop window.</param>
	/// <param name="pwszTitle">Display title string. If <c>NULL</c>, the default context type is used as the title.</param>
	/// <param name="dwFlags">Currently not used and should be set to 0.</param>
	/// <param name="pvReserved">Reserved for future use.</param>
	/// <returns>This function returns <c>TRUE</c> on success and <c>FALSE</c> on failure.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/cryptuiapi/nf-cryptuiapi-cryptuidlgviewcontext BOOL CryptUIDlgViewContext(
	// DWORD dwContextType, const void *pvContext, HWND hwnd, LPCWSTR pwszTitle, DWORD dwFlags, void *pvReserved );
	[DllImport(Lib.CryptUI, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cryptuiapi.h", MSDNShortId = "d4b8f01b-7c3e-4286-bc37-d5ec4a1e1c2f")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptUIDlgViewContext(CertStoreContextType dwContextType, [In] IntPtr pvContext, [In, Optional] HWND hwnd,
		[Optional, MarshalAs(UnmanagedType.LPWStr)] string? pwszTitle, uint dwFlags = 0, IntPtr pvReserved = default);

	/// <summary>
	/// <para>
	/// [The <c>CryptUIWizDigitalSign</c> function is available for use in the operating systems specified in the Requirements section.
	/// It may be altered or unavailable in subsequent versions.]
	/// </para>
	/// <para>
	/// The <c>CryptUIWizDigitalSign</c> function digitally signs a document or BLOB. The document or BLOB can be signed with or without
	/// user interaction.
	/// </para>
	/// </summary>
	/// <param name="dwFlags">
	/// <para>Contains flags that modify the behavior of the function. This can be zero or the following value.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPTUI_WIZ_NO_UI 0x0001</term>
	/// <term>
	/// This function will sign the document based on the information in the CRYPTUI_WIZ_DIGITAL_SIGN_INFO structure pointed to by the
	/// pDigitalSignInfo parameter without displaying any user interface. If this flag is not specified, this function will display a
	/// wizard to guide the user through the signing process.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="hwndParent">
	/// The handle of the window to use as the parent of the dialog box that this function creates. This parameter is ignored if the
	/// <c>CRYPTUI_WIZ_NO_UI</c> flag is set in dwFlags.
	/// </param>
	/// <param name="pwszWizardTitle">
	/// A pointer to a null-terminated Unicode string that contains the title to use in the dialog box that this function creates. This
	/// parameter is ignored if the <c>CRYPT_WIZ_NO_UI</c> flag is set in dwFlags. If this parameter is <c>NULL</c>, a default title is used.
	/// </param>
	/// <param name="pDigitalSignInfo">
	/// A pointer to a CRYPTUI_WIZ_DIGITAL_SIGN_INFO structure that contains information about the signing process.
	/// </param>
	/// <param name="ppSignContext">
	/// A pointer to a CRYPTUI_WIZ_DIGITAL_SIGN_CONTEXT structure pointer that receives the signed BLOB. When you have finished using
	/// this structure, you must free the memory by passing this pointer to the CryptUIWizFreeDigitalSignContext function. This
	/// parameter can be <c>NULL</c> if the signed BLOB is not needed.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns nonzero.</para>
	/// <para>If the function fails, it returns zero.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/cryptuiapi/nf-cryptuiapi-cryptuiwizdigitalsign BOOL CryptUIWizDigitalSign(
	// DWORD dwFlags, HWND hwndParent, LPCWSTR pwszWizardTitle, PCCRYPTUI_WIZ_DIGITAL_SIGN_INFO pDigitalSignInfo,
	// PCCRYPTUI_WIZ_DIGITAL_SIGN_CONTEXT *ppSignContext );
	[DllImport(Lib.CryptUI, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cryptuiapi.h", MSDNShortId = "1d01523e-d47b-49be-82c8-5e98f97be800")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptUIWizDigitalSign(CryptUIWizFlags dwFlags, [In, Optional] HWND hwndParent, [Optional, MarshalAs(UnmanagedType.LPWStr)] string? pwszWizardTitle,
		in CRYPTUI_WIZ_DIGITAL_SIGN_INFO pDigitalSignInfo, out SafePCCRYPTUI_WIZ_DIGITAL_SIGN_CONTEXT ppSignContext);

	/// <summary>
	/// The <c>CryptUIWizExport</c> function exports a certificate, a certificate trust list (CTL), a certificate revocation list (CRL),
	/// or a certificate store to a file. The export can be performed with or without user interaction.
	/// </summary>
	/// <param name="dwFlags">
	/// <para>
	/// Contains flags that modify the behavior of the function. This can be zero or a combination of one or more of the following values.
	/// </para>
	/// <para>
	/// <c>Note</c> Except for <c>CRYPTUI_WIZ_NO_UI</c>, none of the following constants are defined in a published header file. To use
	/// these constants, you must define them by using the specified values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPTUI_WIZ_NO_UI 0x0001</term>
	/// <term>
	/// This function will perform the export based on the information in the CRYPTUI_WIZ_EXPORT_INFO structure pointed to by
	/// pExportInfo without displaying any user interface. If this flag is not specified, this function will display a wizard to guide
	/// the user through the export process.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPTUI_WIZ_IGNORE_NO_UI_FLAG_FOR_CSPS 0x0002</term>
	/// <term>
	/// Suppress all user interfaces generated by cryptographic service providers (CSPs). This option can be overridden by the
	/// CRYPTUI_WIZ_NO_UI_EXCEPT_CSP option.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPTUI_WIZ_NO_UI_EXCEPT_CSP 0x0003</term>
	/// <term>
	/// Suppress all user interfaces except those generated by CSPs. This option overrides the CRYPTUI_WIZ_IGNORE_NO_UI_FLAG_FOR_CSPS option.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPTUI_WIZ_EXPORT_PRIVATE_KEY 0x0100</term>
	/// <term>Skip the Export Private Key page and assume that the private key is to be exported.</term>
	/// </item>
	/// <item>
	/// <term>CRYPTUI_WIZ_EXPORT_NO_DELETE_PRIVATE_KEY 0x0200</term>
	/// <term>Disable the Delete the private key check box in the Export File Format page.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="hwndParent">
	/// The handle of the window to use as the parent of the dialog box that this function creates. This parameter is ignored if the
	/// <c>CRYPT_WIZ_NO_UI</c> flag is set in dwFlags.
	/// </param>
	/// <param name="pwszWizardTitle">
	/// A pointer to a null-terminated Unicode string that contains the title to use in the dialog box that this function creates. This
	/// parameter is ignored if the <c>CRYPT_WIZ_NO_UI</c> flag is set in dwFlags.
	/// </param>
	/// <param name="pExportInfo">
	/// A pointer to a CRYPTUI_WIZ_EXPORT_INFO structure that contains information about producing the export wizard.
	/// </param>
	/// <param name="pvoid">
	/// <para>
	/// If the <c>dwSubjectChoice</c> member of the CRYPTUI_WIZ_EXPORT_INFO structure that pExportInfo references is
	/// <c>CRYPTUI_WIZ_EXPORT_CERT_CONTEXT</c>, and if the <c>CRYPTUI_WIZ_NO_UI</c> flag is set in dwFlags, this parameter is a pointer
	/// to a CRYPTUI_WIZ_EXPORT_CERTCONTEXT_INFO structure.
	/// </para>
	/// <para>
	/// If the <c>CRYPTUI_WIZ_NO_UI</c> flag is not set in dwFlags, this parameter is optional and can be <c>NULL</c>. If this parameter
	/// is not <c>NULL</c>, the CRYPTUI_WIZ_EXPORT_CERTCONTEXT_INFO structure contains the values that are displayed to the user as the
	/// default choices.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns nonzero.</para>
	/// <para>If the function fails, it returns zero. For extended error information, call the GetLastError function.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/cryptuiapi/nf-cryptuiapi-cryptuiwizexport BOOL CryptUIWizExport( DWORD
	// dwFlags, HWND hwndParent, LPCWSTR pwszWizardTitle, PCCRYPTUI_WIZ_EXPORT_INFO pExportInfo, void *pvoid );
	[DllImport(Lib.CryptUI, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("cryptuiapi.h", MSDNShortId = "62537d51-c761-4180-b857-58c819ea66aa")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptUIWizExport(CryptUIWizFlags dwFlags, [In, Optional] HWND hwndParent, [Optional, MarshalAs(UnmanagedType.LPWStr)] string? pwszWizardTitle,
		in CRYPTUI_WIZ_EXPORT_INFO pExportInfo, [In, Optional] IntPtr pvoid);

	/// <summary>
	/// The <c>CryptUIWizFreeDigitalSignContext</c> function frees the CRYPTUI_WIZ_DIGITAL_SIGN_CONTEXT structure allocated by the
	/// CryptUIWizDigitalSign function.
	/// </summary>
	/// <param name="pSignContext">A pointer to the CRYPTUI_WIZ_DIGITAL_SIGN_CONTEXT structure to be freed.</param>
	/// <returns>
	/// <para>If the function succeeds, the function returns nonzero.</para>
	/// <para>If the function fails, it returns zero.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/cryptuiapi/nf-cryptuiapi-cryptuiwizfreedigitalsigncontext BOOL
	// CryptUIWizFreeDigitalSignContext( PCCRYPTUI_WIZ_DIGITAL_SIGN_CONTEXT pSignContext );
	[DllImport(Lib.CryptUI, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cryptuiapi.h", MSDNShortId = "039615ee-0485-4698-944f-23359253767a")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptUIWizFreeDigitalSignContext(PCCRYPTUI_WIZ_DIGITAL_SIGN_CONTEXT pSignContext);

	/// <summary>
	/// The function imports a certificate, a certificate trust list (CTL), a certificate revocation list (CRL), or a certificate store
	/// to a certificate store. The import can be performed with or without user interaction.
	/// </summary>
	/// <param name="dwFlags">
	/// <para>
	/// Contains flags that modify the behavior of the function. This can be zero or a combination of one or more of the following values.
	/// </para>
	/// <para>
	/// <c>Note</c> Except for <c>CRYPTUI_WIZ_NO_UI</c>, none of the following constants are defined in a published header file. To use
	/// these constants, you must define them by using the specified values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPTUI_WIZ_NO_UI 0x0001</term>
	/// <term>
	/// This function will perform the import based on the information in the CRYPTUI_WIZ_IMPORT_SRC_INFO structure pointed to by
	/// pImportSrc into the store specified by hDestCertStore without displaying any user interface. If this flag is not specified, this
	/// function will display a wizard to guide the user through the import process. Beginning with Windows 8 and Windows Server 2012,
	/// if you set this flag and are importing a certificate from a PFX BLOB that was protected to an Active Directory (AD) principal,
	/// and the current user, as part of that principal, has permission to decrypt the password embedded in the PFX packet, the
	/// importation will succeed without requiring that a password be set in the CRYPTUI_WIZ_IMPORT_SRC_INFO structure. For more
	/// information about protecting PFX to an AD principal, see the pvPara parameter and the PKCS12_PROTECT_TO_DOMAIN_SIDS flag of the
	/// PFXExportCertStoreEx function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPTUI_WIZ_IGNORE_NO_UI_FLAG_FOR_CSPS 0x0002</term>
	/// <term>
	/// Suppress all user interfaces generated by cryptographic service providers (CSPs). This option can be overridden by the
	/// CRYPTUI_WIZ_NO_UI_EXCEPT_CSP option.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPTUI_WIZ_NO_UI_EXCEPT_CSP 0x0003</term>
	/// <term>
	/// Suppress all user interfaces except those generated by CSPs. This option overrides the CRYPTUI_WIZ_IGNORE_NO_UI_FLAG_FOR_CSPS option.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPTUI_WIZ_IMPORT_ALLOW_CERT 0x00020000</term>
	/// <term>Allow certificates to be imported.</term>
	/// </item>
	/// <item>
	/// <term>CRYPTUI_WIZ_IMPORT_ALLOW_CRL 0x00040000</term>
	/// <term>Allow CRLs to be imported.</term>
	/// </item>
	/// <item>
	/// <term>CRYPTUI_WIZ_IMPORT_ALLOW_CTL 0x00080000</term>
	/// <term>Allow CTLs to be imported.</term>
	/// </item>
	/// <item>
	/// <term>CRYPTUI_WIZ_IMPORT_NO_CHANGE_DEST_STORE 0x00010000</term>
	/// <term>Do not allow the user to change the destination certificate store represented by the hDestCertStore parameter.</term>
	/// </item>
	/// <item>
	/// <term>CRYPTUI_WIZ_IMPORT_TO_LOCALMACHINE 0x00100000</term>
	/// <term>
	/// Import the object to the certificate store for the local computer. This applies only to Personal Information Exchange (PFX) imports.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPTUI_WIZ_IMPORT_TO_CURRENTUSER 0x00200000</term>
	/// <term>Import the object to the certificate store for the current user. This applies only to PFX imports.</term>
	/// </item>
	/// <item>
	/// <term>CRYPTUI_WIZ_IMPORT_REMOTE_DEST_STORE 0x00400000</term>
	/// <term>
	/// Import the object to a remote certificate store. Set this flag if the hDestCertStore parameter represents a remote certificate store.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="hwndParent">
	/// The handle of the window to use as the parent of the dialog box that this function creates. This parameter is ignored if the
	/// <c>CRYPTUI_WIZ_NO_UI</c> flag is set in dwFlags.
	/// </param>
	/// <param name="pwszWizardTitle">
	/// A pointer to a null-terminated Unicode string that contains the title to use in the dialog box that this function creates. This
	/// parameter is ignored if the <c>CRYPTUI_WIZ_NO_UI</c> flag is set in dwFlags.
	/// </param>
	/// <param name="pImportSrc">
	/// A pointer to a CRYPTUI_WIZ_IMPORT_SRC_INFO structure that contains information about the object to import. This parameter is
	/// required if <c>CRYPTUI_WIZ_NO_UI</c> is set in dwFlags and is optional otherwise.
	/// </param>
	/// <param name="hDestCertStore">
	/// A handle to the certificate store to import to. If this parameter is <c>NULL</c> and the <c>CRYPTUI_WIZ_NO_UI</c> flag is not
	/// set in dwFlags, the wizard will prompt the user to select a certificate store.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns nonzero.</para>
	/// <para>If the function fails, it returns zero. For extended error information, call the GetLastError function.</para>
	/// </returns>
	/// <remarks>
	/// <para>If none of following three flags are set in dwFlags, import of any type of content is allowed:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>CRYPTUI_WIZ_IMPORT_ALLOW_CERT</term>
	/// </item>
	/// <item>
	/// <term>CRYPTUI_WIZ_IMPORT_ALLOW_CRL</term>
	/// </item>
	/// <item>
	/// <term>CRYPTUI_WIZ_IMPORT_ALLOW_CTL</term>
	/// </item>
	/// </list>
	/// <para>
	/// The <c>CRYPTUI_WIZ_IMPORT_TO_LOCALMACHINE</c> and <c>CRYPTUI_WIZ_IMPORT_TO_CURRENTUSER</c> flags are used to force the content
	/// of a PFX BLOB into either the local machine store or the current user store. If neither of these flags are set and
	/// hDestCertStore is <c>NULL</c>:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>The private key in the PFX BLOB will be forced to be imported into the current user store.</term>
	/// </item>
	/// <item>
	/// <term>
	/// And if <c>CRYPTUI_WIZ_NO_UI</c> is not set, the wizard prompts the user to select a certificate store from among the current
	/// user certificate stores.
	/// </term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cryptuiapi/nf-cryptuiapi-cryptuiwizimport BOOL CryptUIWizImport( DWORD
	// dwFlags, HWND hwndParent, LPCWSTR pwszWizardTitle, PCCRYPTUI_WIZ_IMPORT_SRC_INFO pImportSrc, HCERTSTORE hDestCertStore );
	[DllImport(Lib.CryptUI, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("cryptuiapi.h", MSDNShortId = "6b2b9c89-229a-4626-a8b4-fe2b7cc0af86")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptUIWizImport(CryptUIWizFlags dwFlags, [In, Optional] HWND hwndParent, [Optional, MarshalAs(UnmanagedType.LPWStr)] string? pwszWizardTitle,
		in CRYPTUI_WIZ_IMPORT_SRC_INFO pImportSrc, [In, Optional] HCERTSTORE hDestCertStore);

	/// <summary>
	/// The function imports a certificate, a certificate trust list (CTL), a certificate revocation list (CRL), or a certificate store
	/// to a certificate store. The import can be performed with or without user interaction.
	/// </summary>
	/// <param name="dwFlags">
	/// <para>
	/// Contains flags that modify the behavior of the function. This can be zero or a combination of one or more of the following values.
	/// </para>
	/// <para>
	/// <c>Note</c> Except for <c>CRYPTUI_WIZ_NO_UI</c>, none of the following constants are defined in a published header file. To use
	/// these constants, you must define them by using the specified values.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPTUI_WIZ_NO_UI 0x0001</term>
	/// <term>
	/// This function will perform the import based on the information in the CRYPTUI_WIZ_IMPORT_SRC_INFO structure pointed to by
	/// pImportSrc into the store specified by hDestCertStore without displaying any user interface. If this flag is not specified, this
	/// function will display a wizard to guide the user through the import process. Beginning with Windows 8 and Windows Server 2012,
	/// if you set this flag and are importing a certificate from a PFX BLOB that was protected to an Active Directory (AD) principal,
	/// and the current user, as part of that principal, has permission to decrypt the password embedded in the PFX packet, the
	/// importation will succeed without requiring that a password be set in the CRYPTUI_WIZ_IMPORT_SRC_INFO structure. For more
	/// information about protecting PFX to an AD principal, see the pvPara parameter and the PKCS12_PROTECT_TO_DOMAIN_SIDS flag of the
	/// PFXExportCertStoreEx function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPTUI_WIZ_IGNORE_NO_UI_FLAG_FOR_CSPS 0x0002</term>
	/// <term>
	/// Suppress all user interfaces generated by cryptographic service providers (CSPs). This option can be overridden by the
	/// CRYPTUI_WIZ_NO_UI_EXCEPT_CSP option.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPTUI_WIZ_NO_UI_EXCEPT_CSP 0x0003</term>
	/// <term>
	/// Suppress all user interfaces except those generated by CSPs. This option overrides the CRYPTUI_WIZ_IGNORE_NO_UI_FLAG_FOR_CSPS option.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPTUI_WIZ_IMPORT_ALLOW_CERT 0x00020000</term>
	/// <term>Allow certificates to be imported.</term>
	/// </item>
	/// <item>
	/// <term>CRYPTUI_WIZ_IMPORT_ALLOW_CRL 0x00040000</term>
	/// <term>Allow CRLs to be imported.</term>
	/// </item>
	/// <item>
	/// <term>CRYPTUI_WIZ_IMPORT_ALLOW_CTL 0x00080000</term>
	/// <term>Allow CTLs to be imported.</term>
	/// </item>
	/// <item>
	/// <term>CRYPTUI_WIZ_IMPORT_NO_CHANGE_DEST_STORE 0x00010000</term>
	/// <term>Do not allow the user to change the destination certificate store represented by the hDestCertStore parameter.</term>
	/// </item>
	/// <item>
	/// <term>CRYPTUI_WIZ_IMPORT_TO_LOCALMACHINE 0x00100000</term>
	/// <term>
	/// Import the object to the certificate store for the local computer. This applies only to Personal Information Exchange (PFX) imports.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPTUI_WIZ_IMPORT_TO_CURRENTUSER 0x00200000</term>
	/// <term>Import the object to the certificate store for the current user. This applies only to PFX imports.</term>
	/// </item>
	/// <item>
	/// <term>CRYPTUI_WIZ_IMPORT_REMOTE_DEST_STORE 0x00400000</term>
	/// <term>
	/// Import the object to a remote certificate store. Set this flag if the hDestCertStore parameter represents a remote certificate store.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="hwndParent">
	/// The handle of the window to use as the parent of the dialog box that this function creates. This parameter is ignored if the
	/// <c>CRYPTUI_WIZ_NO_UI</c> flag is set in dwFlags.
	/// </param>
	/// <param name="pwszWizardTitle">
	/// A pointer to a null-terminated Unicode string that contains the title to use in the dialog box that this function creates. This
	/// parameter is ignored if the <c>CRYPTUI_WIZ_NO_UI</c> flag is set in dwFlags.
	/// </param>
	/// <param name="pImportSrc">
	/// A pointer to a CRYPTUI_WIZ_IMPORT_SRC_INFO structure that contains information about the object to import. This parameter is
	/// required if <c>CRYPTUI_WIZ_NO_UI</c> is set in dwFlags and is optional otherwise.
	/// </param>
	/// <param name="hDestCertStore">
	/// A handle to the certificate store to import to. If this parameter is <c>NULL</c> and the <c>CRYPTUI_WIZ_NO_UI</c> flag is not
	/// set in dwFlags, the wizard will prompt the user to select a certificate store.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns nonzero.</para>
	/// <para>If the function fails, it returns zero. For extended error information, call the GetLastError function.</para>
	/// </returns>
	/// <remarks>
	/// <para>If none of following three flags are set in dwFlags, import of any type of content is allowed:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>CRYPTUI_WIZ_IMPORT_ALLOW_CERT</term>
	/// </item>
	/// <item>
	/// <term>CRYPTUI_WIZ_IMPORT_ALLOW_CRL</term>
	/// </item>
	/// <item>
	/// <term>CRYPTUI_WIZ_IMPORT_ALLOW_CTL</term>
	/// </item>
	/// </list>
	/// <para>
	/// The <c>CRYPTUI_WIZ_IMPORT_TO_LOCALMACHINE</c> and <c>CRYPTUI_WIZ_IMPORT_TO_CURRENTUSER</c> flags are used to force the content
	/// of a PFX BLOB into either the local machine store or the current user store. If neither of these flags are set and
	/// hDestCertStore is <c>NULL</c>:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>The private key in the PFX BLOB will be forced to be imported into the current user store.</term>
	/// </item>
	/// <item>
	/// <term>
	/// And if <c>CRYPTUI_WIZ_NO_UI</c> is not set, the wizard prompts the user to select a certificate store from among the current
	/// user certificate stores.
	/// </term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cryptuiapi/nf-cryptuiapi-cryptuiwizimport BOOL CryptUIWizImport( DWORD
	// dwFlags, HWND hwndParent, LPCWSTR pwszWizardTitle, PCCRYPTUI_WIZ_IMPORT_SRC_INFO pImportSrc, HCERTSTORE hDestCertStore );
	[DllImport(Lib.CryptUI, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("cryptuiapi.h", MSDNShortId = "6b2b9c89-229a-4626-a8b4-fe2b7cc0af86")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptUIWizImport(CryptUIWizFlags dwFlags, [In, Optional] HWND hwndParent, [Optional, MarshalAs(UnmanagedType.LPWStr)] string? pwszWizardTitle,
		[In, Optional] IntPtr pImportSrc, [In, Optional] HCERTSTORE hDestCertStore);

	/// <summary>
	/// The <c>CERT_SELECTUI_INPUT</c> structure is used by the CertSelectionGetSerializedBlob function to serialize the certificates
	/// contained in a store or an array of certificate chains. The returned serialized BLOB can be passed to the
	/// CredUIPromptForWindowsCredentials function.
	/// </summary>
	/// <remarks>Initializes a new instance of the CERT_SELECTUI_INPUT structure using the specified certificate chain list.</remarks>
	/// <param name="chain">The list of certificate chains to be used for selection. Cannot be null and must contain at least one chain.</param>
	/// <param name="hStore">The optional handle of a certificate store created by the caller.</param>
	// https://docs.microsoft.com/en-us/windows/win32/api/cryptuiapi/ns-cryptuiapi-cert_selectui_input typedef struct { HCERTSTORE
	// hStore; PCCERT_CHAIN_CONTEXT *prgpChain; DWORD cChain; } CERT_SELECTUI_INPUT, *PCERT_SELECTUI_INPUT;
	[PInvokeData("cryptuiapi.h", MSDNShortId = "8953cddd-86b6-4781-8dca-b5fd3d298bc8")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CERT_SELECTUI_INPUT(SafeCertificateChainList chain, HCERTSTORE hStore = default)
	{
		/// <summary>
		/// The handle of a certificate store created by the caller. The store contains the set of application preselected certificates.
		/// </summary>
		public HCERTSTORE hStore = hStore;

		/// <summary>
		/// An array of pointers to CERT_CHAIN_CONTEXT structures. Applications provision this array by preselecting certificate chains
		/// using the CertSelectCertificateChains function.
		/// </summary>
		public IntPtr prgpChain = chain;

		/// <summary>The number of CERT_CHAIN_CONTEXT structures that are in the array pointed to by the <c>prgpChain</c> member.</summary>
		public uint cChain = (uint)chain.Count;

		/// <summary>Gets the array of pointers to CERT_CHAIN_CONTEXT structures.</summary>
		public readonly PCCERT_CHAIN_CONTEXT[]? GetChain() => prgpChain.ToArray<PCCERT_CHAIN_CONTEXT>((int)cChain);
	}

	/// <summary>The <c>CRYPTUI_CERT_MGR_STRUCT</c> structure contains information about a certificate manager dialog box.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/cryptuiapi/ns-cryptuiapi-cryptui_cert_mgr_struct typedef struct
	// _CRYPTUI_CERT_MGR_STRUCT { DWORD dwSize; HWND hwndParent; DWORD dwFlags; LPCWSTR pwszTitle; LPCSTR pszInitUsageOID; }
	// CRYPTUI_CERT_MGR_STRUCT, *PCRYPTUI_CERT_MGR_STRUCT;
	[PInvokeData("cryptuiapi.h", MSDNShortId = "e6c24d16-0ae2-443c-8971-2d7da3aae963")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CRYPTUI_CERT_MGR_STRUCT
	{
		/// <summary>The size, in bytes, of the structure. This value must be set to .</summary>
		public uint dwSize;

		/// <summary>Handle of the parent window of the dialog box.</summary>
		public HWND hwndParent;

		/// <summary>Reserved. This value must be set to zero.</summary>
		public uint dwFlags;

		/// <summary>Title of the dialog box.</summary>
		[MarshalAs(UnmanagedType.LPWStr)] public string pwszTitle;

		/// <summary>
		/// Enhanced key usage object identifier (OID) of the certificates that will initially appear in the dialog box. The default
		/// value is <c>NULL</c>, which displays all certificates.
		/// </summary>
		public StrPtrAnsi pszInitUsageOID;
	}

	/// <summary>
	/// The <c>CRYPTUI_INITDIALOG_STRUCT</c> structure supports the CRYPTUI_VIEWCERTIFICATE_STRUCT structure. It is passed as the lParam
	/// in the WM_INITDIALOG call to each property sheet that is in the <c>rgPropSheetPages</c> array of the
	/// CRYPTUI_VIEWCERTIFICATE_STRUCT structure. The <c>CRYPTUI_VIEWCERTIFICATE_STRUCT</c> structure is used in the
	/// CryptUIDlgViewCertificate function.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/cryptuiapi/ns-cryptuiapi-cryptui_initdialog_struct typedef struct
	// tagCRYPTUI_INITDIALOG_STRUCT { LPARAM lParam; PCCERT_CONTEXT pCertContext; } CRYPTUI_INITDIALOG_STRUCT, *PCRYPTUI_INITDIALOG_STRUCT;
	[PInvokeData("cryptuiapi.h", MSDNShortId = "c6335c02-3b3e-45e2-bb58-b7213aea500b")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CRYPTUI_INITDIALOG_STRUCT
	{
		/// <summary>The <c>lParam</c> in the PROPSHEETPAGE structure.</summary>
		public IntPtr lParam;

		/// <summary>A pointer to the CERT_CONTEXT structure for the certificate that CryptUIDlgViewCertificate is displaying.</summary>
		public PCCERT_CONTEXT pCertContext;
	}

	/// <summary>
	/// The <c>CRYPTUI_VIEWCERTIFICATE_STRUCT</c> structure contains information about a certificate to view. This structure is used in
	/// the CryptUIDlgViewCertificate function.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/cryptuiapi/ns-cryptuiapi-cryptui_viewcertificate_structa typedef struct
	// tagCRYPTUI_VIEWCERTIFICATE_STRUCTA { DWORD dwSize; HWND hwndParent; DWORD dwFlags; LPCSTR szTitle; PCCERT_CONTEXT pCertContext;
	// LPCSTR *rgszPurposes; DWORD cPurposes; union { CRYPT_PROVIDER_DATA const *pCryptProviderData; HANDLE hWVTStateData; }; BOOL
	// fpCryptProviderDataTrustedUsage; DWORD idxSigner; DWORD idxCert; BOOL fCounterSigner; DWORD idxCounterSigner; DWORD cStores;
	// HCERTSTORE *rghStores; DWORD cPropSheetPages; LPCPROPSHEETPAGEA rgPropSheetPages; DWORD nStartPage; }
	// CRYPTUI_VIEWCERTIFICATE_STRUCTA, *PCRYPTUI_VIEWCERTIFICATE_STRUCTA;
	[PInvokeData("cryptuiapi.h", MSDNShortId = "7bbd58df-3a1b-4d82-9a90-7c94260a7165")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct CRYPTUI_VIEWCERTIFICATE_STRUCT
	{
		/// <summary>The size, in bytes, of the <c>CRYPTUI_VIEWCERTIFICATE_STRUCT</c> structure.</summary>
		public uint dwSize;

		/// <summary>A handle to the window that is the parent of the dialog box produced by CryptUIDlgViewCertificate.</summary>
		public HWND hwndParent;

		/// <summary>
		/// <para>This member can be one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CRYPTUI_HIDE_HIERARCHYPAGE</term>
		/// <term>The Certification Path page is disabled.</term>
		/// </item>
		/// <item>
		/// <term>CRYPTUI_HIDE_DETAILPAGE</term>
		/// <term>The Details page is disabled.</term>
		/// </item>
		/// <item>
		/// <term>CRYPTUI_DISABLE_EDITPROPERTIES</term>
		/// <term>The user is not allowed to change the properties.</term>
		/// </item>
		/// <item>
		/// <term>CRYPTUI_ENABLE_EDITPROPERTIES</term>
		/// <term>The user is allowed to change the properties.</term>
		/// </item>
		/// <item>
		/// <term>CRYPTUI_DISABLE_ADDTOSTORE</term>
		/// <term>The Install button is disabled.</term>
		/// </item>
		/// <item>
		/// <term>CRYPTUI_ENABLE_ADDTOSTORE</term>
		/// <term>The Install button is enabled.</term>
		/// </item>
		/// <item>
		/// <term>CRYPTUI_ACCEPT_DECLINE_STYLE</term>
		/// <term>The pages or buttons that allow the user to accept or decline any decision are disabled.</term>
		/// </item>
		/// <item>
		/// <term>CRYPTUI_IGNORE_UNTRUSTED_ROOT</term>
		/// <term>An untrusted root error is ignored.</term>
		/// </item>
		/// <item>
		/// <term>CRYPTUI_DONT_OPEN_STORES</term>
		/// <term>Known trusted stores will not be used to build the chain.</term>
		/// </item>
		/// <item>
		/// <term>CRYPTUI_ONLY_OPEN_ROOT_STORE</term>
		/// <term>A known trusted root store will not be used to build the chain.</term>
		/// </item>
		/// <item>
		/// <term>CRYPTUI_WARN_UNTRUSTED_ROOT</term>
		/// <term>
		/// Use only when viewing certificates on remote computers. If this flag is used, the first element of rghStores must be the
		/// handle of the root store on the remote computer.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CRYPTUI_ENABLE_REVOCATION_CHECKING</term>
		/// <term>
		/// Enable revocation checking with default behavior. The default behavior is to enable revocation checking of the entire
		/// certificate chain except the root certificate. Valid only if neither the pCryptProviderData nor the hWVTStateData union
		/// member is passed in.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CRYPTUI_WARN_REMOTE_TRUST</term>
		/// <term>When building a certificate chain for a remote computer, warn that the chain may not be trusted on the remote computer.</term>
		/// </item>
		/// <item>
		/// <term>CRYPTUI_DISABLE_EXPORT</term>
		/// <term>If this flag is set, the Copy to file button will be disabled on the Detail page.</term>
		/// </item>
		/// <item>
		/// <term>CRYPTUI_ENABLE_REVOCATION_CHECK_END_CERT</term>
		/// <term>
		/// Enable revocation checking only on the leaf certificate in the certificate chain. Valid only if neither the
		/// pCryptProviderData nor the hWVTStateData union member is passed in.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CRYPTUI_ENABLE_REVOCATION_CHECK_CHAIN</term>
		/// <term>
		/// Enable revocation checking on each certificate in the certificate chain. Valid only if neither the pCryptProviderData nor
		/// the hWVTStateData union member is passed in. Note Because root certificates rarely contain information that allows
		/// revocation checking, it is expected that use of this option will usually result in failure of the CryptUIDlgViewCertificate
		/// function. The recommended option is to use CRYPTUI_ENABLE_REVOCATION_CHECK_CHAIN_EXCLUDE_ROOT.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CRYPTUI_ENABLE_REVOCATION_CHECK_CHAIN_EXCLUDE_ROOT</term>
		/// <term>
		/// Enable revocation checking on each certificate in the certificate chain except for the root certificate. This is the
		/// recommended option to use for certificate revocation checking. Valid only if neither the pCryptProviderData nor the
		/// hWVTStateData union member is passed in. Note This flag is equivalent to CRYPTUI_ENABLE_REVOCATION_CHECKING.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CRYPTUI_DISABLE_HTMLLINK</term>
		/// <term>Disable the HTML Help button (?) in the Certificate dialog box.</term>
		/// </item>
		/// <item>
		/// <term>CRYPTUI_DISABLE_ISSUERSTATEMENT</term>
		/// <term>Disable the Issuer Statement button on the General tab of the Certificate dialog box.</term>
		/// </item>
		/// <item>
		/// <term>CRYPTUI_CACHE_ONLY_URL_RETRIEVAL</term>
		/// <term>
		/// Disable online revocation checking. Set this flag to ensure that the CryptUIDlgViewCertificate function uses the local cache
		/// to retrieve the certificate and does not attempt to retrieve the certificate from the network. Windows Server 2008, Windows
		/// Vista, Windows Server 2003 and Windows XP: This flag is not supported.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public CryptUIViewCertificateFlags dwFlags;

		/// <summary>A pointer to a null-terminated string that contains the title for the window.</summary>
		[MarshalAs(UnmanagedType.LPTStr)] public string szTitle;

		/// <summary>A pointer to the CERT_CONTEXT structure that contains the certificate context to display.</summary>
		public PCCERT_CONTEXT pCertContext;

		/// <summary>
		/// An array of pointers to null-terminated strings that contain the purposes for which this certificate will be validated.
		/// </summary>
		public ArrayPointer<StrPtrAuto> rgszPurposes;

		/// <summary>The number of purposes in the <c>rgszPurposes</c> array.</summary>
		public uint cPurposes;

		/// <summary>
		/// If the WinVerifyTrust function has already been called for the certificate and the WTHelperProvDataFromStateData function
		/// was also called, pass in a pointer to the state structure that was acquired from the call to
		/// <c>WTHelperProvDataFromStateData</c>. If <c>pCryptProviderData</c> is set, <c>fpCryptProviderDataTrustedUsage</c>,
		/// <c>idxSigner</c>, <c>idxCert</c>, and <c>fCounterSignature</c> must also be set.
		/// <para>OR</para>
		/// <para>
		/// If WinVerifyTrust has already been called for the certificate and WTHelperProvDataFromStateData was not called, pass in the
		/// <c>hWVTStateData</c> member of the WINTRUST_DATA structure. If <c>hWVTStateData</c> is set,
		/// <c>fpCryptProviderDataTrustedUsage</c>, <c>idxSigner</c>, <c>idxCert</c>, and <c>fCounterSignature</c> must also be set.
		/// </para>
		/// </summary>
		public IntPtr pData;

		/// <summary>If WinVerifyTrust was called, this is the result of whether the certificate was trusted.</summary>
		[MarshalAs(UnmanagedType.Bool)] public bool fpCryptProviderDataTrustedUsage;

		/// <summary>The index of the signer to view.</summary>
		public uint idxSigner;

		/// <summary>
		/// The index of the certificate that is being viewed within the signer chain. The certificate context of this cert must match <c>pCertContext</c>.
		/// </summary>
		public uint idxCert;

		/// <summary><c>TRUE</c> if a countersignature is being viewed. If this is <c>TRUE</c>, <c>idxCounterSigner</c> must be valid.</summary>
		[MarshalAs(UnmanagedType.Bool)] public bool fCounterSigner;

		/// <summary>The index of the countersigner to view.</summary>
		public uint idxCounterSigner;

		/// <summary>
		/// The number of other stores in the <c>rghStores</c> array of certificate stores to search when building and validating the
		/// certificate chain.
		/// </summary>
		public uint cStores;

		/// <summary>
		/// An array of <c>HCERTSTORE</c> handles to other certificate stores to search when building and validating the certificate chain.
		/// </summary>
		public ArrayPointer<HCERTSTORE> rghStores;

		/// <summary>The number of property pages to add to the dialog box.</summary>
		public uint cPropSheetPages;

		/// <summary>
		/// An array of property pages to add to the dialog box. Each page in this array will not receive the <c>lParam</c> in the
		/// PROPSHEETPAGE structure as the <c>lParam</c> in the WM_INITDIALOG message. It will instead receive a pointer to a
		/// CRYPTUI_INITDIALOG_STRUCT structure. It contains the <c>lParam</c> in <c>PROPSHEETPAGE</c> and the pointer to the
		/// CERT_CONTEXT for which the page is being displayed.
		/// </summary>
		public IntPtr rgPropSheetPages;

		/// <summary>
		/// The index of the initial page that will be displayed. If the highest bit (0x8000) is set, the index is assumed to index
		/// <c>rgPropSheetPages</c> (after the highest bit has been stripped off, for example, 0x8000 will indicate the first page in
		/// <c>rgPropSheetPages</c>). If the highest bit is zero, <c>nStartPage</c> will be the starting index of the default
		/// certificate dialog box property pages.
		/// </summary>
		public uint nStartPage;
	}

	/// <summary>
	/// <para>
	/// [The <c>CRYPTUI_WIZ_DIGITAL_SIGN_BLOB_INFO</c> structure is available for use in the operating systems specified in the
	/// Requirements section. It may be altered or unavailable in subsequent versions.]
	/// </para>
	/// <para>
	/// The <c>CRYPTUI_WIZ_DIGITAL_SIGN_BLOB_INFO</c> structure contains information about the public key BLOB used by the
	/// CryptUIWizDigitalSign function.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/cryptuiapi/ns-cryptuiapi-cryptui_wiz_digital_sign_blob_info typedef struct
	// _CRYPTUI_WIZ_DIGITAL_SIGN_BLOB_INFO { DWORD dwSize; GUID *pGuidSubject; DWORD cbBlob; BYTE *pbBlob; LPCWSTR pwszDisplayName; }
	// CRYPTUI_WIZ_DIGITAL_SIGN_BLOB_INFO, *PCRYPTUI_WIZ_DIGITAL_SIGN_BLOB_INFO;
	[PInvokeData("cryptuiapi.h", MSDNShortId = "9750f52a-f605-4f43-98e1-0f0ea947a214")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CRYPTUI_WIZ_DIGITAL_SIGN_BLOB_INFO
	{
		/// <summary>The size, in bytes, of the structure.</summary>
		public uint dwSize;

		/// <summary>
		/// A pointer to a <c>GUID</c> that contains the GUID that identifies the Session Initiation Protocol (SIP) functions to load.
		/// </summary>
		public GuidPtr pGuidSubject;

		/// <summary>The size, in bytes, of the BLOB pointed to by the <c>pbBlob</c> member.</summary>
		public uint cbBlob;

		/// <summary>A pointer to the BLOB to sign.</summary>
		public IntPtr pbBlob;

		/// <summary>A pointer to a null-terminated Unicode string that contains the display name of the BLOB to sign.</summary>
		[MarshalAs(UnmanagedType.LPWStr)] public string pwszDisplayName;
	}

	/// <summary>
	/// <para>
	/// [The <c>CRYPTUI_WIZ_DIGITAL_SIGN_CERT_PVK_INFO</c> structure is available for use in the operating systems specified in the
	/// Requirements section. It may be altered or unavailable in subsequent versions.]
	/// </para>
	/// <para>
	/// The <c>CRYPTUI_WIZ_DIGITAL_SIGN_CERT_PVK_INFO</c> structure contains information about the PVK file that contains the
	/// certificates used by the CryptUIWizDigitalSign function.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/cryptuiapi/ns-cryptuiapi-cryptui_wiz_digital_sign_cert_pvk_info typedef struct
	// _CRYPTUI_WIZ_DIGITAL_SIGN_CERT_PVK_INFO { DWORD dwSize; LPWSTR pwszSigningCertFileName; DWORD dwPvkChoice; union {
	// PCCRYPTUI_WIZ_DIGITAL_SIGN_PVK_FILE_INFO pPvkFileInfo; PCRYPT_KEY_PROV_INFO pPvkProvInfo; }; }
	// CRYPTUI_WIZ_DIGITAL_SIGN_CERT_PVK_INFO, *PCRYPTUI_WIZ_DIGITAL_SIGN_CERT_PVK_INFO;
	[PInvokeData("cryptuiapi.h", MSDNShortId = "0316ed0b-d4e5-4102-9ab0-637e96c7d9f5")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CRYPTUI_WIZ_DIGITAL_SIGN_CERT_PVK_INFO
	{
		/// <summary>The size, in bytes, of the structure.</summary>
		public uint dwSize;

		/// <summary>
		/// A pointer to a null-terminated Unicode string that contains the path and file named of the file that contains the signing certificates.
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)] public string pwszSigningCertFileName;

		/// <summary>
		/// <para>Specifies the type of entity that contains the certificates. This can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CRYPTUI_WIZ_DIGITAL_SIGN_PVK_FILE</term>
		/// <term>The entity is a PVK file.</term>
		/// </item>
		/// <item>
		/// <term>CRYPTUI_WIZ_DIGITAL_SIGN_PVK_PROV</term>
		/// <term>The entity is a PVK provider.</term>
		/// </item>
		/// </list>
		/// </summary>
		public uint dwPvkChoice;

		/// <summary>
		/// A pointer to a CRYPTUI_WIZ_DIGITAL_SIGN_PVK_FILE_INFO structure that contains the PVK file that contains the certificates.
		/// This member is used if <c>CRYPTUI_WIZ_DIGITAL_SIGN_PVK_FILE</c> is specified for the <c>dwPvkChoice</c> member.
		/// <para>OR</para>
		/// <para>
		/// A pointer to a CRYPT_KEY_PROV_INFO structure that contains information about the PVK provider that contains the
		/// certificates. This member is used if <c>CRYPTUI_WIZ_DIGITAL_SIGN_PVK_PROV</c> is specified for the <c>dwPvkChoice</c> member.
		/// </para>
		/// </summary>
		public ManagedStructPointer<CRYPTUI_WIZ_DIGITAL_SIGN_PVK_FILE_INFO> pPvkInfo;
	}

	/// <summary>
	/// <para>
	/// [The <c>CRYPTUI_WIZ_DIGITAL_SIGN_CONTEXT</c> structure is available for use in the operating systems specified in the
	/// Requirements section. It may be altered or unavailable in subsequent versions.]
	/// </para>
	/// <para>
	/// The <c>CRYPTUI_WIZ_DIGITAL_SIGN_CONTEXT</c> structure is used with the CryptUIWizDigitalSign function to contain information
	/// about a BLOB.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/cryptuiapi/ns-cryptuiapi-cryptui_wiz_digital_sign_context typedef struct
	// _CRYPTUI_WIZ_DIGITAL_SIGN_CONTEXT { DWORD dwSize; DWORD cbBlob; BYTE *pbBlob; } CRYPTUI_WIZ_DIGITAL_SIGN_CONTEXT, *PCRYPTUI_WIZ_DIGITAL_SIGN_CONTEXT;
	[PInvokeData("cryptuiapi.h", MSDNShortId = "3e4eb745-0c28-4ce5-870b-d24565ef0cae")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CRYPTUI_WIZ_DIGITAL_SIGN_CONTEXT
	{
		/// <summary>The size, in bytes, of the structure.</summary>
		public uint dwSize;

		/// <summary>The size, in bytes, of the BLOB pointed to by the <c>pbBlob</c> member.</summary>
		public uint cbBlob;

		/// <summary>A pointer to the signed BLOB.</summary>
		public IntPtr pbBlob;
	}

	/// <summary>
	/// <para>
	/// [The <c>CRYPTUI_WIZ_DIGITAL_SIGN_EXTENDED_INFO</c> structure is available for use in the operating systems specified in the
	/// Requirements section. It may be altered or unavailable in subsequent versions.]
	/// </para>
	/// <para>
	/// The <c>CRYPTUI_WIZ_DIGITAL_SIGN_EXTENDED_INFO</c> structure is used with the CRYPTUI_WIZ_DIGITAL_SIGN_INFO structure to contain
	/// extended information about a signature.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/cryptuiapi/ns-cryptuiapi-cryptui_wiz_digital_sign_extended_info typedef struct
	// _CRYPTUI_WIZ_DIGITAL_SIGN_EXTENDED_INFO { DWORD dwSize; DWORD dwAttrFlags; LPCWSTR pwszDescription; LPCWSTR pwszMoreInfoLocation;
	// LPCSTR pszHashAlg; LPCWSTR pwszSigningCertDisplayString; HCERTSTORE hAdditionalCertStore; PCRYPT_ATTRIBUTES psAuthenticated;
	// PCRYPT_ATTRIBUTES psUnauthenticated; } CRYPTUI_WIZ_DIGITAL_SIGN_EXTENDED_INFO, *PCRYPTUI_WIZ_DIGITAL_SIGN_EXTENDED_INFO;
	[PInvokeData("cryptuiapi.h", MSDNShortId = "e061aac4-8c9f-4282-a8f8-bc0c5a10e566")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CRYPTUI_WIZ_DIGITAL_SIGN_EXTENDED_INFO
	{
		/// <summary>The size, in bytes, of the structure.</summary>
		public uint dwSize;

		/// <summary>
		/// <para>A value that indicates the type of the signature. This can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CRYPTUI_WIZ_DIGITAL_SIGN_COMMERCIAL</term>
		/// <term>The signature is a commercial signature.</term>
		/// </item>
		/// <item>
		/// <term>CRYPTUI_WIZ_DIGITAL_SIGN_INDIVIDUAL</term>
		/// <term>The signature is a personal signature.</term>
		/// </item>
		/// </list>
		/// </summary>
		public CryptUIWizSigType dwAttrFlags;

		/// <summary>A pointer to a null-terminated Unicode string that contains the description of the subject of the signature.</summary>
		[MarshalAs(UnmanagedType.LPWStr)] public string pwszDescription;

		/// <summary>
		/// A pointer to a null-terminated Unicode string that contains the location from which to get more information about the file.
		/// This information will be displayed when the file is downloaded.
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)] public string pwszMoreInfoLocation;

		/// <summary>
		/// A pointer to a null-terminated ANSI string that contains the object identifier (OID) of the hash algorithm used for the
		/// signature. The default value is <c>NULL</c>, which indicates that the SHA-1 hash algorithm is used.
		/// </summary>
		public StrPtrAnsi pszHashAlg;

		/// <summary>
		/// A pointer to a null-terminated Unicode string that contains the string displayed on the digital signature wizard page. The
		/// string should prompt the user to select a certificate for a specific purpose.
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)] public string pwszSigningCertDisplayString;

		/// <summary>A handle to an additional certificate store that will be added to the signature.</summary>
		public HCERTSTORE hAdditionalCertStore;

		/// <summary>A pointer to a CRYPT_ATTRIBUTES structure that contains authenticated attributes supplied by the user.</summary>
		public StructPointer<CRYPT_ATTRIBUTES> psAuthenticated;

		/// <summary>A pointer to a CRYPT_ATTRIBUTES structure that contains unauthenticated attributes supplied by the user.</summary>
		public StructPointer<CRYPT_ATTRIBUTES> psUnauthenticated;
	}

	/// <summary>
	/// <para>
	/// [The <c>CRYPTUI_WIZ_DIGITAL_SIGN_INFO</c> structure is available for use in the operating systems specified in the Requirements
	/// section. It may be altered or unavailable in subsequent versions.]
	/// </para>
	/// <para>
	/// The <c>CRYPTUI_WIZ_DIGITAL_SIGN_INFO</c> structure contains information about digital signing. This structure is used by the
	/// CryptUIWizDigitalSign function.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/cryptuiapi/ns-cryptuiapi-cryptui_wiz_digital_sign_info typedef struct
	// _CRYPTUI_WIZ_DIGITAL_SIGN_INFO { DWORD dwSize; DWORD dwSubjectChoice; union { LPCWSTR pwszFileName;
	// PCCRYPTUI_WIZ_DIGITAL_SIGN_BLOB_INFO pSignBlobInfo; }; DWORD dwSigningCertChoice; union { PCCERT_CONTEXT pSigningCertContext;
	// PCCRYPTUI_WIZ_DIGITAL_SIGN_STORE_INFO pSigningCertStore; PCCRYPTUI_WIZ_DIGITAL_SIGN_CERT_PVK_INFO pSigningCertPvkInfo; }; LPCWSTR
	// pwszTimestampURL; DWORD dwAdditionalCertChoice; PCCRYPTUI_WIZ_DIGITAL_SIGN_EXTENDED_INFO pSignExtInfo; }
	// CRYPTUI_WIZ_DIGITAL_SIGN_INFO, *PCRYPTUI_WIZ_DIGITAL_SIGN_INFO;
	[PInvokeData("cryptuiapi.h", MSDNShortId = "22d0bc45-0f66-4f5f-87d3-0849c4327eed")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CRYPTUI_WIZ_DIGITAL_SIGN_INFO
	{
		/// <summary>The size, in bytes, of the structure.</summary>
		public uint dwSize;

		/// <summary>
		/// <para>
		/// A value that indicates the entity that is to be signed. This member is required if <c>CRYPTUI_WIZ_NO_UI</c> is specified in
		/// the dwFlags parameter of the CryptUIWizDigitalSign function. This can be one of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CRYPTUI_WIZ_DIGITAL_SIGN_SUBJECT_BLOB</term>
		/// <term>The memory BLOB specified by the pSignBlobInfo member is to be signed.</term>
		/// </item>
		/// <item>
		/// <term>CRYPTUI_WIZ_DIGITAL_SIGN_SUBJECT_FILE</term>
		/// <term>The file specified by the pwszFileName member is to be signed.</term>
		/// </item>
		/// <item>
		/// <term>0</term>
		/// <term>The user will be prompted for a file to sign.</term>
		/// </item>
		/// </list>
		/// </summary>
		public CryptUIWizToSign dwSubjectChoice;

		/// <summary/>
		public CRYPTUI_WIZ_DIGITAL_SIGN_INFO_UNION ToSign;

		/// <summary/>
		[StructLayout(LayoutKind.Explicit)]
		public struct CRYPTUI_WIZ_DIGITAL_SIGN_INFO_UNION
		{
			/// <summary>
			/// A pointer to a null-terminated Unicode string that contains the path and file name of the file to sign. This member is
			/// used if <c>CRYPTUI_WIZ_DIGITAL_SIGN_SUBJECT_FILE</c> is specified for the <c>dwSubjectChoice</c> member.
			/// </summary>
			[FieldOffset(0)]
			public StrPtrUni pwszFileName;

			/// <summary>
			/// A pointer to a CRYPTUI_WIZ_DIGITAL_SIGN_BLOB_INFO structure that contains the BLOB to sign. This member is used if
			/// <c>CRYPTUI_WIZ_DIGITAL_SIGN_SUBJECT_BLOB</c> is specified for the <c>dwSubjectChoice</c> member.
			/// </summary>
			[FieldOffset(0)]
			public IntPtr pSignBlobInfo;
		}

		/// <summary>
		/// <para>
		/// A value that specifies the location of the certificate that is used to sign the entity. The default value is zero. This can
		/// be one of the following values.
		/// </para>
		/// <para>
		/// <c>Note</c> If <c>CRYPTUI_WIZ_NO_UI</c> is specified in the dwFlags parameter of the CryptUIWizDigitalSign function, this
		/// value must be either <c>CRYPTUI_WIZ_DIGITAL_SIGN_CERT</c> or <c>CRYPTUI_WIZ_DIGITAL_SIGN_PVK</c>.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CRYPTUI_WIZ_DIGITAL_SIGN_CERT</term>
		/// <term>The certificate is contained in the CERT_CONTEXT structure pointed to by the pSigningCertContext member.</term>
		/// </item>
		/// <item>
		/// <term>CRYPTUI_WIZ_DIGITAL_SIGN_STORE</term>
		/// <term>
		/// The certificate is contained in the certificate store contained in the CRYPTUI_WIZ_DIGITAL_SIGN_STORE_INFO structure pointed
		/// to by the pSigningCertStore member.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CRYPTUI_WIZ_DIGITAL_SIGN_PVK</term>
		/// <term>
		/// The certificate is contained in the PVK file contained in the CRYPTUI_WIZ_DIGITAL_SIGN_CERT_PVK_INFO structure pointed to by
		/// the pSigningCertPvkInfo member.
		/// </term>
		/// </item>
		/// <item>
		/// <term>0</term>
		/// <term>The certificates in the My store are used.</term>
		/// </item>
		/// </list>
		/// </summary>
		public CryptUIWizSignLoc dwSigningCertChoice;

		/// <summary>
		/// A pointer to a CERT_CONTEXT structure that contains the certificate to use to sign the entity. This member is used if
		/// <c>CRYPTUI_WIZ_DIGITAL_SIGN_CERT</c> is specified for the <c>dwSigningCertChoice</c> member.
		/// <para>OR</para>
		/// <para>
		/// A pointer to a CRYPTUI_WIZ_DIGITAL_SIGN_STORE_INFO structure that contains the certificate to use to sign the entity. This
		/// member is used if <c>CRYPTUI_WIZ_DIGITAL_SIGN_STORE</c> is specified for the <c>dwSigningCertChoice</c> member.
		/// </para>
		/// <para>OR</para>
		/// <para>
		/// A pointer to a CRYPTUI_WIZ_DIGITAL_SIGN_CERT_PVK_INFO structure that contains the certificate to use to sign the entity.
		/// This member is used if <c>CRYPTUI_WIZ_DIGITAL_SIGN_PVK</c> is specified for the <c>dwSigningCertChoice</c> member.
		/// </para>
		/// </summary>
		public PCCERT_CONTEXT pSigningCertObject;

		/// <summary>A pointer to a null-terminated Unicode string that contains the URL for the time stamp.</summary>
		[MarshalAs(UnmanagedType.LPWStr)] public string pwszTimestampURL;

		/// <summary>
		/// <para>
		/// A value that indicates whether additional certificates will be included in the signature. The default value is zero. This
		/// can be one of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CRYPTUI_WIZ_DIGITAL_SIGN_ADD_CHAIN</term>
		/// <term>The entire certificate chain will be included in the signature.</term>
		/// </item>
		/// <item>
		/// <term>CRYPTUI_WIZ_DIGITAL_SIGN_ADD_CHAIN_NO_ROOT</term>
		/// <term>All certificates in the certificate chain except the root will be included in the signature.</term>
		/// </item>
		/// <item>
		/// <term>0</term>
		/// <term>No additional certificates will be included in the signature.</term>
		/// </item>
		/// </list>
		/// </summary>
		public CryptUIWizAddChoice dwAdditionalCertChoice;

		/// <summary>
		/// A pointer to a CRYPTUI_WIZ_DIGITAL_SIGN_EXTENDED_INFO structure that contains extended information about the signature.
		/// </summary>
		public ManagedStructPointer<CRYPTUI_WIZ_DIGITAL_SIGN_EXTENDED_INFO> pSignExtInfo;
	}

	/// <summary>
	/// <para>
	/// [The <c>CRYPTUI_WIZ_DIGITAL_SIGN_PVK_FILE_INFO</c> structure is available for use in the operating systems specified in the
	/// Requirements section. It may be altered or unavailable in subsequent versions.]
	/// </para>
	/// <para>
	/// The <c>CRYPTUI_WIZ_DIGITAL_SIGN_PVK_FILE_INFO</c> structure is used with the CRYPTUI_WIZ_DIGITAL_SIGN_INFO structure to contain
	/// information about the PVK file used by the digital signature wizard.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/cryptuiapi/ns-cryptuiapi-cryptui_wiz_digital_sign_pvk_file_info typedef struct
	// _CRYPTUI_WIZ_DIGITAL_SIGN_PVK_FILE_INFO { DWORD dwSize; LPWSTR pwszPvkFileName; LPWSTR pwszProvName; DWORD dwProvType; }
	// CRYPTUI_WIZ_DIGITAL_SIGN_PVK_FILE_INFO, *PCRYPTUI_WIZ_DIGITAL_SIGN_PVK_FILE_INFO;
	[PInvokeData("cryptuiapi.h", MSDNShortId = "0e737661-2cc3-47be-ab32-0efbc18fefbd")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CRYPTUI_WIZ_DIGITAL_SIGN_PVK_FILE_INFO
	{
		/// <summary>The size, in bytes, of the structure.</summary>
		public uint dwSize;

		/// <summary>A pointer to a null-terminated Unicode string that contains the path and file name of the PVK file.</summary>
		[MarshalAs(UnmanagedType.LPWStr)] public string pwszPvkFileName;

		/// <summary>A pointer to a null-terminated Unicode string that contains the name of the provider.</summary>
		[MarshalAs(UnmanagedType.LPWStr)] public string pwszProvName;

		/// <summary>
		/// Contains the provider type identifier. For more information about the provider types, see Cryptographic Provider Types.
		/// </summary>
		public uint dwProvType;
	}

	/// <summary>
	/// <para>
	/// [The <c>CRYPTUI_WIZ_DIGITAL_SIGN_STORE_INFO</c> structure is available for use in the operating systems specified in the
	/// Requirements section. It may be altered or unavailable in subsequent versions.]
	/// </para>
	/// <para>
	/// The <c>CRYPTUI_WIZ_DIGITAL_SIGN_STORE_INFO</c> structure contains information about the certificate store used by the digital
	/// signature wizard.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/cryptuiapi/ns-cryptuiapi-cryptui_wiz_digital_sign_store_info typedef struct
	// _CRYPTUI_WIZ_DIGITAL_SIGN_STORE_INFO { DWORD dwSize; DWORD cCertStore; HCERTSTORE *rghCertStore; PFNCFILTERPROC pFilterCallback;
	// void *pvCallbackData; } CRYPTUI_WIZ_DIGITAL_SIGN_STORE_INFO, *PCRYPTUI_WIZ_DIGITAL_SIGN_STORE_INFO;
	[PInvokeData("cryptuiapi.h", MSDNShortId = "d3ffbf1c-e8c2-44ab-84d2-d32350d04407")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CRYPTUI_WIZ_DIGITAL_SIGN_STORE_INFO
	{
		/// <summary>The size, in bytes, of the structure. This value must be set to .</summary>
		public uint dwSize;

		/// <summary>Number of certificates in the <c>rghCertStore</c> member.</summary>
		public uint cCertStore;

		/// <summary>A pointer to a handle to the certificate store that will be used by the digital signature wizard.</summary>
		public StructPointer<HCERTSTORE> rghCertStore;

		/// <summary>Filter callback function used to display the certificate.</summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public PFNCFILTERPROC pFilterCallback;

		/// <summary>A pointer to the callback data.</summary>
		public IntPtr pvCallbackData;
	}

	/// <summary>
	/// <para>
	/// [The <c>CRYPTUI_WIZ_EXPORT_CERTCONTEXT_INFO</c> structure is available for use in the operating systems specified in the
	/// Requirements section. It may be altered or unavailable in subsequent versions.]
	/// </para>
	/// <para>
	/// The <c>CRYPTUI_WIZ_EXPORT_CERTCONTEXT_INFO</c> structure contains information that controls the operation of the
	/// CryptUIWizExport function when a certificate is the object being exported.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/cryptuiapi/ns-cryptuiapi-cryptui_wiz_export_certcontext_info typedef struct
	// _CRYPTUI_WIZ_EXPORT_CERTCONTEXT_INFO { DWORD dwSize; DWORD dwExportFormat; BOOL fExportChain; BOOL fExportPrivateKeys; LPCWSTR
	// pwszPassword; BOOL fStrongEncryption; } CRYPTUI_WIZ_EXPORT_CERTCONTEXT_INFO, *PCRYPTUI_WIZ_EXPORT_CERTCONTEXT_INFO;
	[PInvokeData("cryptuiapi.h", MSDNShortId = "6be86c4f-0ac7-43c2-81fb-9767279ebeaf")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CRYPTUI_WIZ_EXPORT_CERTCONTEXT_INFO
	{
		/// <summary>The size, in bytes, of this structure.</summary>
		public uint dwSize;

		/// <summary>
		/// <para>A value that indicates the export format of the certificate. This member can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CRYPTUI_WIZ_EXPORT_FORMAT_DER</term>
		/// <term>Export in Abstract Syntax Notation One (ASN.1) Distinguished Encoding Rules (DER) format.</term>
		/// </item>
		/// <item>
		/// <term>CRYPTUI_WIZ_EXPORT_FORMAT_PFX</term>
		/// <term>Export in Private Information Exchange (PFX) format.</term>
		/// </item>
		/// <item>
		/// <term>CRYPTUI_WIZ_EXPORT_FORMAT_PKCS7</term>
		/// <term>Export in Public Key Cryptography Standard #7 (PKCS #7) format.</term>
		/// </item>
		/// <item>
		/// <term>CRYPTUI_WIZ_EXPORT_FORMAT_BASE64</term>
		/// <term>Export in base 64 format.</term>
		/// </item>
		/// <item>
		/// <term>CRYPTUI_WIZ_EXPORT_FORMAT_CRL</term>
		/// <term>Export in certificate revocation list (CRL) format.</term>
		/// </item>
		/// <item>
		/// <term>CRYPTUI_WIZ_EXPORT_FORMAT_CTL</term>
		/// <term>Export in certificate trust list (CTL) format.</term>
		/// </item>
		/// </list>
		/// </summary>
		public uint dwExportFormat;

		/// <summary>
		/// Indicates whether the certificate chain should be exported in addition to the certificate. Contains nonzero to export the
		/// chain or zero to not export the chain.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool fExportChain;

		/// <summary>
		/// Indicates whether the private key should be exported in addition to the certificate. Contains nonzero to export the private
		/// key or zero to not export the private key.
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool fExportPrivateKeys;

		/// <summary>
		/// A pointer to a null-terminated Unicode string that contains the password used to access the private key. This is required if
		/// <c>fExportPrivateKeys</c> is nonzero and is otherwise ignored.
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)] public string pwszPassword;

		/// <summary>
		/// <para>
		/// Indicates whether strong encryption should be used in the export process. Contains nonzero to use strong encryption or zero
		/// to use weak encryption. This must be nonzero if <c>dwExportFormat</c> is <c>CRYPTUI_WIZ_EXPORT_FORMAT_PFX</c>. If this is
		/// nonzero, the PFX BLOB produced is not compatible with Internet Explorer 4.0 or earlier versions.
		/// </para>
		/// <para>
		/// <c>Note</c> We recommend that you set this to nonzero; otherwise, a substantially weaker encryption algorithm is used in the
		/// export process.
		/// </para>
		/// </summary>
		[MarshalAs(UnmanagedType.Bool)] public bool fStrongEncryption;
	}

	/// <summary>
	/// <para>
	/// [The <c>CRYPTUI_WIZ_EXPORT_INFO</c> structure is available for use in the operating systems specified in the Requirements
	/// section. It may be altered or unavailable in subsequent versions.]
	/// </para>
	/// <para>
	/// The <c>CRYPTUI_WIZ_EXPORT_INFO</c> structure contains information that controls the operation of the CryptUIWizExport function.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/cryptuiapi/ns-cryptuiapi-cryptui_wiz_export_info typedef struct
	// _CRYPTUI_WIZ_EXPORT_INFO { DWORD dwSize; LPCWSTR pwszExportFileName; DWORD dwSubjectChoice; union { PCCERT_CONTEXT pCertContext;
	// PCCTL_CONTEXT pCTLContext; PCCRL_CONTEXT pCRLContext; HCERTSTORE hCertStore; }; DWORD cStores; HCERTSTORE *rghStores; }
	// CRYPTUI_WIZ_EXPORT_INFO, *PCRYPTUI_WIZ_EXPORT_INFO;
	[PInvokeData("cryptuiapi.h", MSDNShortId = "3c509bb6-d391-4b59-809c-23466c8196ea")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CRYPTUI_WIZ_EXPORT_INFO
	{
		/// <summary>The size, in bytes, of this structure.</summary>
		public uint dwSize;

		/// <summary>
		/// A pointer to a null-terminated Unicode string that contains the fully qualified file name to export to. If this member is
		/// not <c>NULL</c> and the <c>CRYPTUI_WIZ_NO_UI</c> flag in the dwFlags parameter of the CryptUIWizExport function is not set,
		/// this string is displayed to the user as the default file name. This member is required if the <c>CRYPTUI_WIZ_NO_UI</c> flag
		/// is set. This member is otherwise optional.
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)] public string pwszExportFileName;

		/// <summary>
		/// <para>Indicates the type of the subject to export. This member can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CRYPTUI_WIZ_EXPORT_CERT_CONTEXT</term>
		/// <term>Export the certificate context that is specified in the pCertContext member.</term>
		/// </item>
		/// <item>
		/// <term>CRYPTUI_WIZ_EXPORT_CTL_CONTEXT</term>
		/// <term>Export the certificate trust list (CTL) context that is specified in the pCTLContext member.</term>
		/// </item>
		/// <item>
		/// <term>CRYPTUI_WIZ_EXPORT_CRL_CONTEXT</term>
		/// <term>Export the certificate revocation list (CRL) context that is specified in the pCRLContext member.</term>
		/// </item>
		/// <item>
		/// <term>CRYPTUI_WIZ_EXPORT_CERT_STORE</term>
		/// <term>Export the certificate store that is specified in the hCertStore member.</term>
		/// </item>
		/// <item>
		/// <term>CRYPTUI_WIZ_EXPORT_CERT_STORE_CERTIFICATES_ONLY</term>
		/// <term>Export only the certificates from the certificate store that is specified in the hCertStore member.</term>
		/// </item>
		/// </list>
		/// </summary>
		public CryptUIWizExportType dwSubjectChoice;

		/// <summary/>
		public CRYPTUI_WIZ_EXPORT_INFO_UNION Subject;

		/// <summary/>
		[StructLayout(LayoutKind.Explicit)]
		public struct CRYPTUI_WIZ_EXPORT_INFO_UNION
		{
			/// <summary>
			/// A pointer to the CERT_CONTEXT structure that contains the certificate to export. This member is used if the
			/// <c>dwSubjectChoice</c> member contains <c>CRYPTUI_WIZ_EXPORT_CERT_CONTEXT</c>.
			/// </summary>
			[FieldOffset(0)]
			public PCCERT_CONTEXT pCertContext;

			/// <summary>
			/// A pointer to the CTL_CONTEXT structure that contains the CTL to export. This member is used if the
			/// <c>dwSubjectChoice</c> member contains <c>CRYPTUI_WIZ_EXPORT_CTL_CONTEXT</c>.
			/// </summary>
			[FieldOffset(0)]
			public PCCTL_CONTEXT pCTLContext;

			/// <summary>
			/// A pointer to the CRL_CONTEXT structure that contains the CRL to export. This member is used if the
			/// <c>dwSubjectChoice</c> member contains <c>CRYPTUI_WIZ_EXPORT_CRL_CONTEXT</c>.
			/// </summary>
			[FieldOffset(0)]
			public PCCRL_CONTEXT pCRLContext;

			/// <summary>
			/// A handle to the certificate store to export. This member is used if the <c>dwSubjectChoice</c> member contains
			/// <c>CRYPTUI_WIZ_EXPORT_CERT_STORE</c> or <c>CRYPTUI_WIZ_EXPORT_CERT_STORE_CERTIFICATES_ONLY</c>.
			/// </summary>
			[FieldOffset(0)]
			public HCERTSTORE hCertStore;
		}

		/// <summary>The number of elements in the <c>rghStores</c> array.</summary>
		public uint cStores;

		/// <summary>
		/// An array of extra certificate stores to search for certificates in the trust chain if the chain is being exported with a
		/// certificate. This member is ignored if <c>dwSubjectChoice</c> is anything other than the
		/// <c>CRYPTUI_WIZ_EXPORT_CERT_CONTEXT</c> value. The <c>cStores</c> member contains the number of elements in this array.
		/// </summary>
		public ArrayPointer<HCERTSTORE> rghStores;
	}

	/// <summary>
	/// <para>
	/// [The <c>CRYPTUI_WIZ_IMPORT_SRC_INFO</c> structure is available for use in the operating systems specified in the Requirements
	/// section. It may be altered or unavailable in subsequent versions.]
	/// </para>
	/// <para>
	/// The <c>CRYPTUI_WIZ_IMPORT_SRC_INFO</c> structure contains the subject to import into the CryptUIWizImport function. The subject
	/// can be a certificate, a certificate trust list (CTL), or a certificate revocation list (CRL).
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/cryptuiapi/ns-cryptuiapi-cryptui_wiz_import_src_info typedef struct
	// _CRYPTUI_WIZ_IMPORT_SUBJECT_INFO { DWORD dwSize; DWORD dwSubjectChoice; union { LPCWSTR pwszFileName; PCCERT_CONTEXT
	// pCertContext; PCCTL_CONTEXT pCTLContext; PCCRL_CONTEXT pCRLContext; HCERTSTORE hCertStore; }; DWORD dwFlags; LPCWSTR
	// pwszPassword; } CRYPTUI_WIZ_IMPORT_SRC_INFO, *PCRYPTUI_WIZ_IMPORT_SRC_INFO;
	[PInvokeData("cryptuiapi.h", MSDNShortId = "17d932e3-05ea-4ed0-9f88-fbb674b6b070")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CRYPTUI_WIZ_IMPORT_SRC_INFO
	{
		/// <summary>The size, in bytes, of this structure.</summary>
		public uint dwSize;

		/// <summary>
		/// <para>Indicates the type of subject to import. This member can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CRYPTUI_WIZ_IMPORT_SUBJECT_FILE</term>
		/// <term>Import the certificate stored in the file referenced in the pwszFileName member.</term>
		/// </item>
		/// <item>
		/// <term>CRYPTUI_WIZ_IMPORT_SUBJECT_CERT_CONTEXT</term>
		/// <term>Import the certificate referenced in the pCertContext member.</term>
		/// </item>
		/// <item>
		/// <term>CRYPTUI_WIZ_IMPORT_SUBJECT_CTL_CONTEXT</term>
		/// <term>Import the CTL referenced in the pCTLContext member.</term>
		/// </item>
		/// <item>
		/// <term>CRYPTUI_WIZ_IMPORT_SUBJECT_CRL_CONTEXT</term>
		/// <term>Import the CRL referenced in the pCRLContext member.</term>
		/// </item>
		/// <item>
		/// <term>CRYPTUI_WIZ_IMPORT_SUBJECT_CERT_STORE</term>
		/// <term>Import the certificate store referenced in the hCertStore member.</term>
		/// </item>
		/// </list>
		/// </summary>
		public CryptUIWizImportType dwSubjectChoice;

		/// <summary/>
		public CRYPTUI_WIZ_IMPORT_SRC_INFO_UNION Subject;

		/// <summary/>
		[StructLayout(LayoutKind.Explicit)]
		public struct CRYPTUI_WIZ_IMPORT_SRC_INFO_UNION
		{
			/// <summary>
			/// A pointer to a null-terminated Unicode string that contains the path and file name of the file that contains the
			/// certificate to import. This member is used if the <c>dwSubjectChoice</c> member contains <c>CRYPTUI_WIZ_IMPORT_SUBJECT_FILE</c>.
			/// </summary>
			[FieldOffset(0)]
			public StrPtrUni pwszFileName;

			/// <summary>
			/// A pointer to the CERT_CONTEXT structure that contains the certificate to import. This member is used if the
			/// <c>dwSubjectChoice</c> member contains <c>CRYPTUI_WIZ_IMPORT_SUBJECT_CERT_CONTEXT</c>.
			/// </summary>
			[FieldOffset(0)]
			public PCCERT_CONTEXT pCertContext;

			/// <summary>
			/// A pointer to the CTL_CONTEXT structure that contains the CTL to import. This member is used if the
			/// <c>dwSubjectChoice</c> member contains <c>CRYPTUI_WIZ_IMPORT_SUBJECT_CTL_CONTEXT</c>.
			/// </summary>
			[FieldOffset(0)]
			public PCCTL_CONTEXT pCTLContext;

			/// <summary>
			/// A pointer to the CRL_CONTEXT structure that contains the CRL to import. This member is used if the
			/// <c>dwSubjectChoice</c> member contains <c>CRYPTUI_WIZ_IMPORT_SUBJECT_CRL_CONTEXT</c>.
			/// </summary>
			[FieldOffset(0)]
			public PCCRL_CONTEXT pCRLContext;

			/// <summary>
			/// A handle to the certificate store to import. This member is used if the <c>dwSubjectChoice</c> member contains <c>CRYPTUI_WIZ_IMPORT_SUBJECT_CERT_STORE</c>.
			/// </summary>
			[FieldOffset(0)]
			public HCERTSTORE hCertStore;
		}

		/// <summary>
		/// <para>
		/// Contains flags that modify the import operation. This member is required if <c>pwszFileName</c> contains a Personal
		/// Information Exchange (PFX) BLOB. Otherwise, this member is ignored. This member can be zero or a combination of one or more
		/// of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CRYPT_EXPORTABLE</term>
		/// <term>
		/// Imported keys are marked as exportable. If this flag is not used, calls to the CryptExportKey function with the key handle fail.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CRYPT_USER_PROTECTED</term>
		/// <term>
		/// The user is to be notified by means of a dialog box or some other manner when certain actions are attempting to use this
		/// key. The precise behavior is specified by the cryptographic service provider (CSP) that is being used. Prior to Internet
		/// Explorer 4.0, Microsoft CSPs ignored this flag. Starting with Internet Explorer 4.0, Microsoft CSPs support this flag. If
		/// the provider context was opened with the CRYPT_SILENT flag set, using this flag causes a failure, and the last error is set
		/// to NTE_SILENT_CONTEXT.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CRYPT_MACHINE_KEYSET</term>
		/// <term>The private keys are stored under the local computer and not under the current user.</term>
		/// </item>
		/// <item>
		/// <term>CRYPT_USER_KEYSET</term>
		/// <term>
		/// The private keys are stored under the current user and not under the local computer, even if the PFX BLOB specifies that
		/// they should go under the local computer.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public PFXImportFlags dwFlags;

		/// <summary>
		/// Pointer to a null-terminated Unicode string that contains the password used to access the private key. A password is
		/// required if <c>pwszFileName</c> contains a PFX BLOB. If a password is not required, the variable can be an empty string.
		/// This member cannot be <c>NULL</c>.
		/// </summary>
		[MarshalAs(UnmanagedType.LPWStr)] public string pwszPassword;
	}

	public partial struct PCCRYPTUI_WIZ_DIGITAL_SIGN_CONTEXT
	{
		/// <summary>Performs an explicit conversion from <see cref="PCCRYPTUI_WIZ_DIGITAL_SIGN_CONTEXT"/> to <see cref="CRYPTUI_WIZ_DIGITAL_SIGN_CONTEXT"/>.</summary>
		/// <param name="h">The handle.</param>
		/// <returns>The resulting <see cref="CRYPTUI_WIZ_DIGITAL_SIGN_CONTEXT"/> instance from the conversion.</returns>
		public static explicit operator CRYPTUI_WIZ_DIGITAL_SIGN_CONTEXT(PCCRYPTUI_WIZ_DIGITAL_SIGN_CONTEXT h) => h.handle.ToStructure<CRYPTUI_WIZ_DIGITAL_SIGN_CONTEXT>();

		/// <summary>Gets a reference to the <see cref="CRYPTUI_WIZ_DIGITAL_SIGN_CONTEXT"/> structure.</summary>
		public ref CRYPTUI_WIZ_DIGITAL_SIGN_CONTEXT AsRef() => ref handle.AsRef<CRYPTUI_WIZ_DIGITAL_SIGN_CONTEXT>();
	}
}