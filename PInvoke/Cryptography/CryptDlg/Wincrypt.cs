using static Vanara.PInvoke.Crypt32;

namespace Vanara.PInvoke;

/// <summary>Methods and data types found in CryptDlg.dll.</summary>
public static partial class CryptDlg
{
	/// <summary>
	/// The <c>PFNCMFILTERPROC</c> function is a filter procedure that filters each certificate to determine whether it will appear in
	/// the certificate selection dialog box that is displayed by the CertSelectCertificate function. <c>PFNCMFILTERPROC</c> is an
	/// application-defined callback function that is specified in the CERT_SELECT_STRUCT structure. The <c>CERT_SELECT_STRUCT</c>
	/// structure is a parameter in the CertSelectCertificate function. The <c>PFNCMFILTERPROC</c> function must be implemented by the
	/// developer to suit each application.
	/// </summary>
	/// <param name="pCertContext">
	/// A pointer to a CERT_CONTEXT structure that contains a certificate to make a filtering determination on.
	/// </param>
	/// <param name="lCustData">The customer data.</param>
	/// <param name="dwFlags">The flags.</param>
	/// <param name="dwDisplayWell">The display well.</param>
	/// <returns>
	/// Return a nonzero value ( <c>TRUE</c>) to display the certificate. Return zero ( <c>FALSE</c>) to not display the certificate.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/cryptdlg/nc-cryptdlg-pfncmfilterproc PFNCMFILTERPROC Pfncmfilterproc; BOOL
	// Pfncmfilterproc( IN PCCERT_CONTEXT pCertContext, IN LPARAM, IN DWORD, IN DWORD ) {...}
	[PInvokeData("cryptdlg.h", MSDNShortId = "f870a8a7-c504-491a-b9ac-045766e46348")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public delegate bool PFNCMFILTERPROC([In] PCCERT_CONTEXT pCertContext, [In] IntPtr lCustData, [In] uint dwFlags, [In] CertDisplayWell dwDisplayWell);

	/// <summary>
	/// The <c>PFNCMHOOKPROC</c> function is a hook procedure that is called before messages are processed by the certificate selection
	/// dialog box produced by the CertSelectCertificate function. The function allows the caller to customize the dialog box.
	/// <c>PFNCMHOOKPROC</c> is an application-defined callback function specified in the CERT_SELECT_STRUCT structure. The
	/// <c>CERT_SELECT_STRUCT</c> structure is a parameter in the CertSelectCertificate function. The <c>PFNCMHOOKPROC</c> function must
	/// be implemented by the developer to suit each application.
	/// </summary>
	/// <param name="hwndDialog">A handle to a dialog box window.</param>
	/// <param name="message">The message.</param>
	/// <param name="wParam">Additional information about the message sent or posted.</param>
	/// <param name="lParam">Additional information about the message sent or posted.</param>
	/// <returns>
	/// Return a nonzero value ( <c>TRUE</c>) if this function processes the message. Return zero ( <c>FALSE</c>) if this function does
	/// not process the message.
	/// </returns>
	/// <remarks>For information about hooks, see Hooks.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/cryptdlg/nc-cryptdlg-pfncmhookproc PFNCMHOOKPROC Pfncmhookproc; UINT
	// Pfncmhookproc( IN HWND hwndDialog, IN UINT message, IN WPARAM wParam, IN LPARAM lParam ) {...}
	[PInvokeData("cryptdlg.h", MSDNShortId = "7172c995-a46b-437b-beaf-a0649cb8ec3d")]
	public delegate uint PFNCMHOOKPROC([In] HWND hwndDialog, [In] uint message, [In] IntPtr wParam, [In] IntPtr lParam);

	/// <summary/>
	[PInvokeData("cryptdlg.h", MSDNShortId = "f870a8a7-c504-491a-b9ac-045766e46348")]
	public enum CertDisplayWell
	{
		/// <summary/>
		CERT_DISPWELL_SELECT = 1,

		/// <summary/>
		CERT_DISPWELL_TRUST_CA_CERT = 2,

		/// <summary/>
		CERT_DISPWELL_TRUST_LEAF_CERT = 3,

		/// <summary/>
		CERT_DISPWELL_TRUST_ADD_CA_CERT = 4,

		/// <summary/>
		CERT_DISPWELL_TRUST_ADD_LEAF_CERT = 5,

		/// <summary/>
		CERT_DISPWELL_DISTRUST_CA_CERT = 6,

		/// <summary/>
		CERT_DISPWELL_DISTRUST_LEAF_CERT = 7,

		/// <summary/>
		CERT_DISPWELL_DISTRUST_ADD_CA_CERT = 8,

		/// <summary/>
		CERT_DISPWELL_DISTRUST_ADD_LEAF_CERT = 9,
	}

	/// <summary>The operation to be performed.</summary>
	[PInvokeData("cryptdlg.h", MSDNShortId = "b8b5fd3e-a0db-4edd-84c7-48bae9adc3f8")]
	public enum CertModifyCertificatesOp : uint
	{
		/// <summary>Add the certificate to the Untrusted Certificates certificate store. The certificate is explicitly not trusted.</summary>
		CTL_MODIFY_REQUEST_ADD_NOT_TRUSTED = 1,

		/// <summary>
		/// Remove the certificate from the CTL. The certificate is neither explicitly trusted nor untrusted. To be trusted, the
		/// certificate must have a trusted root certificate at the root of its certificate chain.
		/// </summary>
		CTL_MODIFY_REQUEST_REMOVE = 2,

		/// <summary>Add the certificate to the CTL. The certificate is explicitly trusted.</summary>
		CTL_MODIFY_REQUEST_ADD_TRUSTED = 3,
	}

	/// <summary>Flags for CERT_SELECT_STRUCT</summary>
	[PInvokeData("cryptdlg.h", MSDNShortId = "49184872-d636-4e55-8e32-0f38b49b5c21")]
	[Flags]
	public enum CertSelectFlags : uint
	{
		/// <summary/>
		CSS_SELECTCERT_MASK = 0x00ffffff,

		/// <summary>Hide the Properties button.</summary>
		CSS_HIDE_PROPERTIES = 0x00000001,

		/// <summary>Pass a hook procedure in pfnHook.</summary>
		CSS_ENABLEHOOK = 0x00000002,

		/// <summary>Enable multi-selection of certificates. This option is not currently supported and is ignored.</summary>
		CSS_ALLOWMULTISELECT = 0x00000004,

		/// <summary>Show the Help button.</summary>
		CSS_SHOW_HELP = 0x00000010,

		/// <summary>
		/// Cause CertSelectCertificate function to call the DialogBoxIndirectParam function to create a dialog box. For more
		/// information, see pTemplateName.
		/// </summary>
		CSS_ENABLETEMPLATE = 0x00000020,

		/// <summary>
		/// Cause the CertSelectCertificate function to call the DialogBoxParam function to create a dialog box. For more information,
		/// see pTemplateName.
		/// </summary>
		CSS_ENABLETEMPLATEHANDLE = 0x00000040,
	}

	/// <summary/>
	[PInvokeData("cryptdlg.h", MSDNShortId = "3d18526b-1052-4f0c-999b-881a74a94549")]
	[Flags]
	public enum ViewPropertiesFlags : uint
	{
		/// <summary/>
		CM_VIEWFLAGS_MASK = 0x00ffffff,

		/// <summary>Specifies that a hook function is enabled.</summary>
		CM_ENABLEHOOK = 0x00000001,

		/// <summary>Specifies that a help file is used.</summary>
		CM_SHOW_HELP = 0x00000002,

		/// <summary>Specifies that a help icon is used.</summary>
		CM_SHOW_HELPICON = 0x00000004,

		/// <summary>Specifies that a template is enabled.</summary>
		CM_ENABLETEMPLATE = 0x00000008,

		/// <summary>Specifies that the Advance tab is not displayed.</summary>
		CM_HIDE_ADVANCEPAGE = 0x00000010,

		/// <summary>Specifies that the Trust tab is not displayed.</summary>
		CM_HIDE_TRUSTPAGE = 0x00000020,

		/// <summary>Specifies that the name cannot be changed.</summary>
		CM_NO_NAMECHANGE = 0x00000040,

		/// <summary>Specifies that the trust cannot be edited.</summary>
		CM_NO_EDITTRUST = 0x00000080,

		/// <summary>Specifies that the Detail tab is not displayed.</summary>
		CM_HIDE_DETAILPAGE = 0x00000100,

		/// <summary>Specifies that certificate stores are opened.</summary>
		CM_ADD_CERT_STORES = 0x00000200,

		/// <summary/>
		CERTVIEW_CRYPTUI_LPARAM = 0x00800000,
	}

	/// <summary>
	/// <para>
	/// The <c>CertModifyCertificatesToTrust</c> function modifies the set of certificates in a certificate trust list (CTL) for a given purpose.
	/// </para>
	/// <para>
	/// <c>Note</c> This function has no associated import library. You must use the LoadLibrary and GetProcAddress functions to
	/// dynamically link to CryptDlg.dll.
	/// </para>
	/// </summary>
	/// <param name="cCerts">The number of modification requests that are in the rgCerts parameter.</param>
	/// <param name="rgCerts">A pointer to a CTL_MODIFY_REQUEST structure that contains an array of modification requests.</param>
	/// <param name="szPurpose">
	/// A pointer to a null-terminated string that contains the string representation of an object identifier (OID). The OID specifies
	/// the enhanced key usage (EKU) of the CTL to be modified.
	/// </param>
	/// <param name="hwnd">A handle to the parent window of the dialog boxes that this function generates.</param>
	/// <param name="hcertstoreTrust">
	/// A handle to the certificate store in which to modify the list of trusted certificates. If <c>NULL</c>, the Trusted People store
	/// is used with the Current User location.
	/// </param>
	/// <param name="pccertSigner">
	/// A pointer to a CERT_CONTEXT structure that contains a certificate. It is used to sign the trust list. The certificate also
	/// restricts the set of trust lists that may be modified. If <c>NULL</c>, the trust list is not signed.
	/// </param>
	/// <returns>An <c>HRESULT</c>. A value of S_OK indicates success.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/cryptdlg/nf-cryptdlg-certmodifycertificatestotrust CRYPTDLGAPI HRESULT
	// CertModifyCertificatesToTrust( int cCerts, PCTL_MODIFY_REQUEST rgCerts, LPCSTR szPurpose, HWND hwnd, HCERTSTORE hcertstoreTrust,
	// PCCERT_CONTEXT pccertSigner );
	[DllImport(Lib.CryptDlg, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("cryptdlg.h", MSDNShortId = "a23d968e-113f-470e-a629-18c22882c77f")]
	public static extern HRESULT CertModifyCertificatesToTrust(int cCerts, [MarshalAs(UnmanagedType.LPArray)] CTL_MODIFY_REQUEST[] rgCerts, SafeOID szPurpose,
		[Optional] HWND hwnd, HCERTSTORE hcertstoreTrust, PCCERT_CONTEXT pccertSigner);

	/// <summary>
	/// <para>
	/// The <c>CertSelectCertificate</c> function presents a dialog box that allows the user to select certificates from a set of
	/// certificates that match the given criteria.
	/// </para>
	/// <para>
	/// <c>Note</c> This function has no associated import library. You must use the LoadLibrary and GetProcAddress functions to
	/// dynamically link to CryptDlg.dll.
	/// </para>
	/// </summary>
	/// <param name="pCertSelectInfo">
	/// A pointer to a CERT_SELECT_STRUCT structure that contains criteria that control the displayed certificates for selection and
	/// receives the selected certificate.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
	/// <para>If the function fails, the return value is <c>FALSE</c>. For extended error information, call the GetLastError function.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/cryptdlg/nf-cryptdlg-certselectcertificatew CRYPTDLGAPI BOOL
	// CertSelectCertificateW( IN OUT PCERT_SELECT_STRUCT_W pCertSelectInfo );
	[DllImport(Lib.CryptDlg, SetLastError = true, CharSet = CharSet.Auto)]
	[PInvokeData("cryptdlg.h", MSDNShortId = "8160ea08-c7c0-40f5-8771-6603f768744b")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CertSelectCertificate(ref CERT_SELECT_STRUCT pCertSelectInfo);

	/// <summary>
	/// <para>
	/// [The <c>CertViewProperties</c> function is available for use in the operating systems specified in the Requirements section. It
	/// may be altered or unavailable in subsequent versions. Instead, use the CryptUIDlgViewContext function.]
	/// </para>
	/// <para>
	/// The <c>CertViewProperties</c> function displays the properties for a certificate in a user interface (UI) dialog box. This
	/// function has no associated import library. You must use the LoadLibrary and GetProcAddress functions to dynamically link to CryptDlg.dll.
	/// </para>
	/// <para>
	/// <c>Note</c> This function has no associated import library. You must use the LoadLibrary and GetProcAddress functions to
	/// dynamically link to CryptDlg.dll.
	/// </para>
	/// </summary>
	/// <param name="pCertViewInfo">
	/// A pointer to a CERT_VIEWPROPERTIES_STRUCT structure that contains the information about the certificate to view.
	/// </param>
	/// <returns>The return value is <c>TRUE</c> if the function is successful; <c>FALSE</c> if the function fails.</returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/cryptdlg/nf-cryptdlg-certviewpropertiesw CRYPTDLGAPI BOOL CertViewPropertiesW(
	// PCERT_VIEWPROPERTIES_STRUCT_W pCertViewInfo );
	[DllImport(Lib.CryptDlg, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("cryptdlg.h", MSDNShortId = "5df840ab-fff6-4c7e-b799-51e4de4c644a")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CertViewProperties(ref CERT_VIEWPROPERTIES_STRUCT pCertViewInfo);

	/// <summary>
	/// <para>
	/// [The <c>GetFriendlyNameOfCert</c> function is available for use in the operating systems specified in the Requirements section.
	/// It may be altered or unavailable in subsequent versions. Instead, use the CertGetNameString function with the
	/// CERT_NAME_FRIENDLY_DISPLAY_TYPE flag.]
	/// </para>
	/// <para>The <c>GetFriendlyNameOfCert</c> function retrieves the display name for a certificate.</para>
	/// <para>
	/// <c>Note</c> This function has no associated import library. You must use the LoadLibrary and GetProcAddress functions to
	/// dynamically link to CryptDlg.dll.
	/// </para>
	/// </summary>
	/// <param name="pccert">A pointer to the certificate context whose display name is being retrieved.</param>
	/// <param name="pch">A pointer to a character string that receives the display name for the certificate.</param>
	/// <param name="cch">Number of characters allocated for pchBuffer, including the terminating <c>NULL</c> character.</param>
	/// <returns>
	/// The return value is the number of characters, including the terminating <c>NULL</c> character, in the returned display name.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/cryptdlg/nf-cryptdlg-getfriendlynameofcerta CRYPTDLGAPI DWORD
	// GetFriendlyNameOfCertA( PCCERT_CONTEXT pccert, LPSTR pch, DWORD cch );
	[DllImport(Lib.CryptDlg, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("cryptdlg.h", MSDNShortId = "a66a8573-b234-4d5d-bd38-72a3a44a0419")]
	public static extern uint GetFriendlyNameOfCert(PCCERT_CONTEXT pccert, [MarshalAs(UnmanagedType.LPTStr)] StringBuilder pch, uint cch);

	/// <summary>
	/// <para>
	/// [The <c>GetFriendlyNameOfCert</c> function is available for use in the operating systems specified in the Requirements section.
	/// It may be altered or unavailable in subsequent versions. Instead, use the CertGetNameString function with the
	/// CERT_NAME_FRIENDLY_DISPLAY_TYPE flag.]
	/// </para>
	/// <para>The <c>GetFriendlyNameOfCert</c> function retrieves the display name for a certificate.</para>
	/// <para>
	/// <c>Note</c> This function has no associated import library. You must use the LoadLibrary and GetProcAddress functions to
	/// dynamically link to CryptDlg.dll.
	/// </para>
	/// </summary>
	/// <param name="pccert">A pointer to the certificate context whose display name is being retrieved.</param>
	/// <param name="pch">A pointer to a character string that receives the display name for the certificate.</param>
	/// <param name="cch">Number of characters allocated for pchBuffer, including the terminating <c>NULL</c> character.</param>
	/// <returns>
	/// The return value is the number of characters, including the terminating <c>NULL</c> character, in the returned display name.
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/cryptdlg/nf-cryptdlg-getfriendlynameofcerta CRYPTDLGAPI DWORD
	// GetFriendlyNameOfCertA( PCCERT_CONTEXT pccert, LPSTR pch, DWORD cch );
	[DllImport(Lib.CryptDlg, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("cryptdlg.h", MSDNShortId = "a66a8573-b234-4d5d-bd38-72a3a44a0419")]
	public static extern uint GetFriendlyNameOfCert(PCCERT_CONTEXT pccert, IntPtr pch, uint cch);

	/// <summary>
	/// The <c>CERT_SELECT_STRUCT</c> structure contains criteria upon which to select certificates that are presented in a certificate
	/// selection dialog box. This structure is used in the CertSelectCertificate function.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/cryptdlg/ns-cryptdlg-cert_select_struct_w typedef struct tagCSSW { DWORD
	// dwSize; HWND hwndParent; HINSTANCE hInstance; LPCWSTR pTemplateName; DWORD dwFlags; LPCWSTR szTitle; DWORD cCertStore; HCERTSTORE
	// *arrayCertStore; LPCSTR szPurposeOid; DWORD cCertContext; PCCERT_CONTEXT *arrayCertContext; LPARAM lCustData; PFNCMHOOKPROC
	// pfnHook; PFNCMFILTERPROC pfnFilter; LPCWSTR szHelpFileName; DWORD dwHelpId; HCRYPTPROV hprov; } CERT_SELECT_STRUCT_W, *PCERT_SELECT_STRUCT_W;
	[PInvokeData("cryptdlg.h", MSDNShortId = "49184872-d636-4e55-8e32-0f38b49b5c21")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct CERT_SELECT_STRUCT
	{
		/// <summary>The size, in bytes, of this structure.</summary>
		public uint dwSize;

		/// <summary>A handle to the parent window of any dialog boxes that CertSelectCertificate generates.</summary>
		public HWND hwndParent;

		/// <summary>A handle to the module whose executable file contains the dialog box template.</summary>
		public HINSTANCE hInstance;

		/// <summary>
		/// <para>
		/// If the <c>CSS_ENABLETEMPLATE</c> flag is set in the <c>dwFlags</c> member, set <c>pTemplateName</c> to a pointer to a global
		/// memory object that contains the template that DialogBoxIndirectParam uses to create the dialog box. A dialog box template
		/// consists of a header that describes the dialog box. The header is followed by one or more additional blocks of data that
		/// describe each of the controls in the dialog box. The template can use either the standard format or the extended format.
		/// </para>
		/// <para>
		/// If the <c>CSS_ENABLETEMPLATEHANDLE</c> flag is set in <c>dwFlags</c>, <c>pTemplateName</c> specifies the dialog box
		/// template. <c>pTemplateName</c> is either the pointer to a null-terminated character string that specifies the name of the
		/// dialog box template or an integer value that specifies the resource identifier of the dialog box template. If the specifies
		/// a resource identifier, its high-order word must be zero and its low-order word must contain the identifier. One way to
		/// create this integer value is to use the MAKEINTRESOURCE macro.
		/// </para>
		/// </summary>
		public IntPtr pTemplateName;

		/// <summary>
		/// <para>This member can be one or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CSS_HIDE_PROPERTIES</term>
		/// <term>Hide the Properties button.</term>
		/// </item>
		/// <item>
		/// <term>CSS_ENABLEHOOK</term>
		/// <term>Pass a hook procedure in pfnHook.</term>
		/// </item>
		/// <item>
		/// <term>CSS_ALLOWMULTISELECT</term>
		/// <term>Enable multi-selection of certificates. This option is not currently supported and is ignored.</term>
		/// </item>
		/// <item>
		/// <term>CSS_SHOW_HELP</term>
		/// <term>Show the Help button.</term>
		/// </item>
		/// <item>
		/// <term>CSS_ENABLETEMPLATE</term>
		/// <term>
		/// Cause CertSelectCertificate function to call the DialogBoxIndirectParam function to create a dialog box. For more
		/// information, see pTemplateName.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CSS_ENABLETEMPLATEHANDLE</term>
		/// <term>
		/// Cause the CertSelectCertificate function to call the DialogBoxParam function to create a dialog box. For more information,
		/// see pTemplateName.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public CertSelectFlags dwFlags;

		/// <summary>A pointer to a string that contains the text for the title of the dialog box.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string szTitle;

		/// <summary>The number of elements in <c>arrayCertStore</c> array.</summary>
		public uint cCertStore;

		/// <summary>
		/// A pointer to the array of certificate stores that the dialog box enumerates and displays the certificates from. The
		/// <c>cCertStore</c> member contains the number of elements in this array.
		/// </summary>
		public IntPtr arrayCertStore;

		/// <summary>
		/// A pointer to a string representation of an object identifier (OID) for an enhanced key usage (EKU). If an OID is provided,
		/// only certificates that include this EKU will be displayed.
		/// </summary>
		public IntPtr szPurposeOid;

		/// <summary>
		/// The number of elements in the <c>arrayCertContext</c> array. After the CertSelectCertificate function returns, this member
		/// contains the number of certificates that were selected by the user. Currently, only one certificate can be selected by the user.
		/// </summary>
		public uint cCertContext;

		/// <summary>
		/// <para>
		/// A pointer to an array of CERT_CONTEXT structures. The <c>cCertContext</c> member specifies the number of elements in this
		/// array. This array must contain at least one element.
		/// </para>
		/// <para>
		/// The certificates represented by these structures are selected when the dialog box displayed by the CertSelectCertificate
		/// function is initially displayed. Currently, only the first certificate in this array is used. The first certificate in this
		/// array will be released with the CertFreeCertificateContext function if the <c>CertSelectCertificate</c> function is
		/// successful. If the first element in this array is <c>NULL</c>, no certificates are initially selected in the dialog box.
		/// </para>
		/// <para>
		/// After the CertSelectCertificate function returns, this array contains the certificates that were selected by the user.
		/// Currently, only one certificate can be selected by the user.
		/// </para>
		/// </summary>
		public IntPtr arrayCertContext;

		/// <summary>
		/// A pointer to an array of byte values that hold custom data that is passed through to the filter procedure referenced by
		/// <c>pfnFilter</c>. This custom data is not used by the CertSelectCertificate function.
		/// </summary>
		public IntPtr lCustData;

		/// <summary>
		/// A PFNCMHOOKPROC function pointer to the Hook callback function. This function is called before messages are processed by the
		/// dialog box. For more information, see Hooks.
		/// </summary>
		public PFNCMHOOKPROC pfnHook;

		/// <summary>
		/// A PFNCMFILTERPROC function pointer to the filter callback function. This is called to determine which certificates will be
		/// displayed by the dialog box.
		/// </summary>
		public PFNCMFILTERPROC pfnFilter;

		/// <summary>A pointer to a null-terminated string that contains the full path to the Help file.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string szHelpFileName;

		/// <summary>The context identifier for the topic. For more information, see WinHelp.</summary>
		public uint dwHelpId;

		/// <summary>A handle to the Cryptographic Service Provider (CSP) to use for certificate verification.</summary>
		public HCRYPTPROV hprov;
	}

	/// <summary>
	/// <para>
	/// [The <c>CERT_VIEWPROPERTIES_STRUCT</c> structure is available for use in the operating systems specified in the Requirements
	/// section. It may be altered or unavailable in subsequent versions.]
	/// </para>
	/// <para>
	/// The <c>CERT_VIEWPROPERTIES_STRUCT</c> structure defines information used when the CertViewProperties function is called to
	/// display a certificate's properties.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/cryptdlg/ns-cryptdlg-cert_viewproperties_struct_a typedef struct
	// tagCERT_VIEWPROPERTIES_STRUCT_A { DWORD dwSize; HWND hwndParent; HINSTANCE hInstance; DWORD dwFlags; LPCSTR szTitle;
	// PCCERT_CONTEXT pCertContext; LPSTR *arrayPurposes; DWORD cArrayPurposes; DWORD cRootStores; HCERTSTORE *rghstoreRoots; DWORD
	// cStores; HCERTSTORE *rghstoreCAs; DWORD cTrustStores; HCERTSTORE *rghstoreTrust; HCRYPTPROV hprov; LPARAM lCustData; DWORD dwPad;
	// LPCSTR szHelpFileName; DWORD dwHelpId; DWORD nStartPage; DWORD cArrayPropSheetPages; PROPSHEETPAGE *arrayPropSheetPages; }
	// CERT_VIEWPROPERTIES_STRUCT_A, *PCERT_VIEWPROPERTIES_STRUCT_A;
	[PInvokeData("cryptdlg.h", MSDNShortId = "3d18526b-1052-4f0c-999b-881a74a94549")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct CERT_VIEWPROPERTIES_STRUCT
	{
		/// <summary>The size, in bytes, of this structure.</summary>
		public uint dwSize;

		/// <summary>A handle to the parent window.</summary>
		public HWND hwndParent;

		/// <summary>A handle to the module instance.</summary>
		public HINSTANCE hInstance;

		/// <summary>
		/// <para>Bitwise combination of zero or more of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CM_ENABLEHOOK 1 (0x1)</term>
		/// <term>Specifies that a hook function is enabled.</term>
		/// </item>
		/// <item>
		/// <term>CM_SHOW_HELP 2 (0x2)</term>
		/// <term>Specifies that a help file is used.</term>
		/// </item>
		/// <item>
		/// <term>CM_SHOW_HELPICON 4 (0x4)</term>
		/// <term>Specifies that a help icon is used.</term>
		/// </item>
		/// <item>
		/// <term>CM_ENABLETEMPLATE 8 (0x8)</term>
		/// <term>Specifies that a template is enabled.</term>
		/// </item>
		/// <item>
		/// <term>CM_HIDE_ADVANCEPAGE 16 (0x10)</term>
		/// <term>Specifies that the Advance tab is not displayed.</term>
		/// </item>
		/// <item>
		/// <term>CM_HIDE_TRUSTPAGE 32 (0x20)</term>
		/// <term>Specifies that the Trust tab is not displayed.</term>
		/// </item>
		/// <item>
		/// <term>CM_NO_NAMECHANGE 64 (0x40)</term>
		/// <term>Specifies that the name cannot be changed.</term>
		/// </item>
		/// <item>
		/// <term>CM_NO_EDITTRUST 128 (0x80)</term>
		/// <term>Specifies that the trust cannot be edited.</term>
		/// </item>
		/// <item>
		/// <term>CM_HIDE_DETAILPAGE 256 (0x100)</term>
		/// <term>Specifies that the Detail tab is not displayed.</term>
		/// </item>
		/// <item>
		/// <term>CM_ADD_CERT_STORES 512 (0x200)</term>
		/// <term>Specifies that certificate stores are opened.</term>
		/// </item>
		/// </list>
		/// </summary>
		public ViewPropertiesFlags dwFlags;

		/// <summary>A pointer to a null-terminated string for the title of the user interface.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string szTitle;

		/// <summary>Certificate context for the certificate to be shown.</summary>
		public PCCERT_CONTEXT pCertContext;

		/// <summary>A pointer to an array of null-terminated strings that specify the certificate purposes.</summary>
		public IntPtr arrayPurposes;

		/// <summary>Number of elements in the <c>arrayPurposes</c> array. If this value is zero, then no trust status is displayed.</summary>
		public uint cArrayPurposes;

		/// <summary>Number of elements in the <c>rghstoreRoots</c> array.</summary>
		public uint cRootStores;

		/// <summary>Array of Root certificate store handles.</summary>
		public IntPtr rghstoreRoots;

		/// <summary>Number of elements in the <c>rghstoreCAs</c> array.</summary>
		public uint cStores;

		/// <summary>Array of other certificate store handles.</summary>
		public IntPtr rghstoreCAs;

		/// <summary>Number of elements in the <c>rghstoreTrust</c> array.</summary>
		public uint cTrustStores;

		/// <summary>Array of trust certificate store handles.</summary>
		public IntPtr rghstoreTrust;

		/// <summary>A handle to the cryptographic service provider (CSP) to use for verification.</summary>
		public HCRYPTPROV hprov;

		/// <summary>Value used for custom data.</summary>
		public IntPtr lCustData;

		/// <summary>Padding location.</summary>
		public uint dwPad;

		/// <summary>A pointer to a null-terminated string for the Help file name.</summary>
		[MarshalAs(UnmanagedType.LPTStr)]
		public string szHelpFileName;

		/// <summary>ID for the Help file topic.</summary>
		public uint dwHelpId;

		/// <summary>Number of the first property page.</summary>
		public uint nStartPage;

		/// <summary>Number of elements in the <c>arrayPropSheetPages</c> array.</summary>
		public uint cArrayPropSheetPages;

		/// <summary>A pointer to an array of <c>PROPSHEETPAGE</c> structures that specify the property pages.</summary>
		public IntPtr arrayPropSheetPages;
	}

	/// <summary>
	/// The <c>CTL_MODIFY_REQUEST</c> structure contains a request to modify a certificate trust list (CTL). This structure is used in
	/// the CertModifyCertificatesToTrust function.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/cryptdlg/ns-cryptdlg-ctl_modify_request typedef struct _CTL_MODIFY_REQUEST {
	// PCCERT_CONTEXT pccert; DWORD dwOperation; DWORD dwError; } CTL_MODIFY_REQUEST, *PCTL_MODIFY_REQUEST;
	[PInvokeData("cryptdlg.h", MSDNShortId = "b8b5fd3e-a0db-4edd-84c7-48bae9adc3f8")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CTL_MODIFY_REQUEST
	{
		/// <summary>A pointer to a CERT_CONTEXT structure that contains the certificate to change the trust on.</summary>
		public PCCERT_CONTEXT pccert;

		/// <summary>
		/// <para>The operation to be performed. This member can be one of the following values.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CTL_MODIFY_REQUEST_ADD_TRUSTED</term>
		/// <term>Add the certificate to the CTL. The certificate is explicitly trusted.</term>
		/// </item>
		/// <item>
		/// <term>CTL_MODIFY_REQUEST_ADD_NOT_TRUSTED</term>
		/// <term>Add the certificate to the Untrusted Certificates certificate store. The certificate is explicitly not trusted.</term>
		/// </item>
		/// <item>
		/// <term>CTL_MODIFY_REQUEST_REMOVE</term>
		/// <term>
		/// Remove the certificate from the CTL. The certificate is neither explicitly trusted nor untrusted. To be trusted, the
		/// certificate must have a trusted root certificate at the root of its certificate chain.
		/// </term>
		/// </item>
		/// </list>
		/// </summary>
		public CertModifyCertificatesOp dwOperation;

		/// <summary>The error code generated for this operation.</summary>
		public uint dwError;
	}
}