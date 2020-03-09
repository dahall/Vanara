using System;
using System.Runtime.InteropServices;

using static Vanara.PInvoke.Crypt32;

namespace Vanara.PInvoke
{
	/// <summary>Methods and data types found in CryptDlg.dll.</summary>
	public static partial class CryptDlg
	{
		/*
		/// <summary>
		/// <para>The <c>CertSelectCertificate</c> function presents a dialog box that allows the user to select certificates from a set of certificates that match the given criteria.</para>
		/// <para><c>Note</c> This function has no associated import library. You must use the LoadLibrary and GetProcAddress functions to dynamically link to CryptDlg.dll.</para>
		/// </summary>
		/// <param name="pCertSelectInfo">A pointer to a CERT_SELECT_STRUCT structure that contains criteria that control the displayed certificates for selection and receives the selected certificate.</param>
		/// <returns>
		/// <para>If the function succeeds, the return value is <c>TRUE</c>.</para>
		/// <para>If the function fails, the return value is <c>FALSE</c>. For extended error information, call the GetLastError function.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/win32/api/cryptdlg/nf-cryptdlg-certselectcertificatew
		// CRYPTDLGAPI BOOL CertSelectCertificateW( IN OUT PCERT_SELECT_STRUCT_W pCertSelectInfo );
		[DllImport(Lib.CryptDlg, SetLastError = true, CharSet = CharSet.Auto)]
		[PInvokeData("cryptdlg.h", MSDNShortId = "8160ea08-c7c0-40f5-8771-6603f768744b")]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool CertSelectCertificateW(ref CERT_SELECT_STRUCT_W pCertSelectInfo);

		/// <summary>The <c>CERT_SELECT_STRUCT</c> structure contains criteria upon which to select certificates that are presented in a certificate selection dialog box. This structure is used in the CertSelectCertificate function.</summary>
		// https://docs.microsoft.com/en-us/windows/win32/api/cryptdlg/ns-cryptdlg-cert_select_struct_w typedef struct tagCSSW { DWORD
		// dwSize; HWND hwndParent; HINSTANCE hInstance; LPCWSTR pTemplateName; DWORD dwFlags; LPCWSTR szTitle; DWORD cCertStore; HCERTSTORE
		// *arrayCertStore; LPCSTR szPurposeOid; DWORD cCertContext; PCCERT_CONTEXT *arrayCertContext; LPARAM lCustData; PFNCMHOOKPROC
		// pfnHook; PFNCMFILTERPROC pfnFilter; LPCWSTR szHelpFileName; DWORD dwHelpId; HCRYPTPROV hprov; } CERT_SELECT_STRUCT_W, *PCERT_SELECT_STRUCT_W;
		[PInvokeData("cryptdlg.h", MSDNShortId = "49184872-d636-4e55-8e32-0f38b49b5c21")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct CERT_SELECT_STRUCT_W
		{
			/// <summary>The size, in bytes, of this structure.</summary>
			public uint dwSize;
			/// <summary>A handle to the parent window of any dialog boxes that CertSelectCertificate generates.</summary>
			public HWND hwndParent;
			/// <summary>A handle to the module whose executable file contains the dialog box template.</summary>
			public HINSTANCE hInstance;
			/// <summary>
			///   <para>If the <c>CSS_ENABLETEMPLATE</c> flag is set in the <c>dwFlags</c> member, set <c>pTemplateName</c> to a pointer to a global memory object that contains the template that DialogBoxIndirectParam uses to create the dialog box. A dialog box template consists of a header that describes the dialog box. The header is followed by one or more additional blocks of data that describe each of the controls in the dialog box. The template can use either the standard format or the extended format.</para>
			///   <para>If the <c>CSS_ENABLETEMPLATEHANDLE</c> flag is set in <c>dwFlags</c>, <c>pTemplateName</c> specifies the dialog box template. <c>pTemplateName</c> is either the pointer to a null-terminated character string that specifies the name of the dialog box template or an integer value that specifies the resource identifier of the dialog box template. If the specifies a resource identifier, its high-order word must be zero and its low-order word must contain the identifier. One way to create this integer value is to use the MAKEINTRESOURCE macro.</para>
			/// </summary>
			[MarshalAs(UnmanagedType.LPWStr)] public string pTemplateName;
			/// <summary>
			///   <para>This member can be one or more of the following values.</para>
			///   <list type="table">
			///     <listheader>
			///       <term>Value</term>
			///       <term>Meaning</term>
			///     </listheader>
			///     <item>
			///       <term>CSS_HIDE_PROPERTIES</term>
			///       <term>Hide the Properties button.</term>
			///     </item>
			///     <item>
			///       <term>CSS_ENABLEHOOK</term>
			///       <term>Pass a hook procedure in pfnHook.</term>
			///     </item>
			///     <item>
			///       <term>CSS_ALLOWMULTISELECT</term>
			///       <term>Enable multi-selection of certificates. This option is not currently supported and is ignored.</term>
			///     </item>
			///     <item>
			///       <term>CSS_SHOW_HELP</term>
			///       <term>Show the Help button.</term>
			///     </item>
			///     <item>
			///       <term>CSS_ENABLETEMPLATE</term>
			///       <term>Cause CertSelectCertificate function to call the DialogBoxIndirectParam function to create a dialog box. For more information, see pTemplateName.</term>
			///     </item>
			///     <item>
			///       <term>CSS_ENABLETEMPLATEHANDLE</term>
			///       <term>Cause the CertSelectCertificate function to call the DialogBoxParam function to create a dialog box. For more information, see pTemplateName.</term>
			///     </item>
			///   </list>
			/// </summary>
			public uint dwFlags;
			/// <summary>A pointer to a string that contains the text for the title of the dialog box.</summary>
			[MarshalAs(UnmanagedType.LPWStr)] public string szTitle;
			/// <summary>The number of elements in <c>arrayCertStore</c> array.</summary>
			public uint cCertStore;
			/// <summary>A pointer to the array of certificate stores that the dialog box enumerates and displays the certificates from. The <c>cCertStore</c> member contains the number of elements in this array.</summary>
			public IntPtr arrayCertStore;
			/// <summary>A pointer to a string representation of an object identifier (OID) for an enhanced key usage (EKU). If an OID is provided, only certificates that include this EKU will be displayed.</summary>
			[MarshalAs(UnmanagedType.LPTStr)] public string szPurposeOid;
			/// <summary>The number of elements in the <c>arrayCertContext</c> array. After the CertSelectCertificate function returns, this member contains the number of certificates that were selected by the user. Currently, only one certificate can be selected by the user.</summary>
			public uint cCertContext;
			/// <summary>
			///   <para>A pointer to an array of CERT_CONTEXT structures. The <c>cCertContext</c> member specifies the number of elements in this array. This array must contain at least one element.</para>
			///   <para>The certificates represented by these structures are selected when the dialog box displayed by the CertSelectCertificate function is initially displayed. Currently, only the first certificate in this array is used. The first certificate in this array will be released with the CertFreeCertificateContext function if the <c>CertSelectCertificate</c> function is successful. If the first element in this array is <c>NULL</c>, no certificates are initially selected in the dialog box.</para>
			///   <para>After the CertSelectCertificate function returns, this array contains the certificates that were selected by the user. Currently, only one certificate can be selected by the user.</para>
			/// </summary>
			public IntPtr arrayCertContext;
			/// <summary>A pointer to an array of byte values that hold custom data that is passed through to the filter procedure referenced by <c>pfnFilter</c>. This custom data is not used by the CertSelectCertificate function.</summary>
			public IntPtr lCustData;
			/// <summary>A PFNCMHOOKPROC function pointer to the Hook callback function. This function is called before messages are processed by the dialog box. For more information, see Hooks.</summary>
			public PFNCMHOOKPROC pfnHook;
			/// <summary>A PFNCMFILTERPROC function pointer to the filter callback function. This is called to determine which certificates will be displayed by the dialog box.</summary>
			public PFNCMFILTERPROC pfnFilter;
			/// <summary>A pointer to a null-terminated string that contains the full path to the Help file.</summary>
			[MarshalAs(UnmanagedType.LPTStr)] public string szHelpFileName;
			/// <summary>The context identifier for the topic. For more information, see WinHelp.</summary>
			public uint dwHelpId;
			/// <summary>A handle to the Cryptographic Service Provider (CSP) to use for certificate verification.</summary>
			public HCRYPTPROV hprov;
		}

		CertConfigureTrust
		CertModifyCertificatesToTrust
		CertSelectCertificate
		CertTrustCertPolicy
		CertTrustCleanup
		CertTrustFinalPolicy
		CertTrustInit
		CertViewProperties
		DecodeAttrSequence
		DecodeRecipientID
		EncodeAttrSequence
		EncodeRecipientID
		FormatPKIXEmailProtection
		FormatVerisignExtension
		GetFriendlyNameOfCert

		*/
	}
}