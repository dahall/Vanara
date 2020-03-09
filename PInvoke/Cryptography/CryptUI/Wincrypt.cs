using System;
using System.Runtime.InteropServices;

using static Vanara.PInvoke.Crypt32;

namespace Vanara.PInvoke
{
	/// <summary>Methods and data types found in CryptUI.dll.</summary>
	public static partial class CryptUI
	{
		/*
		/// <summary>The <c>CertSelectionGetSerializedBlob</c> function is a helper function used to retrieve a serialized certificate BLOB from a CERT_SELECTUI_INPUT structure.</summary>
		/// <param name="pcsi">A pointer to a CERT_SELECTUI_INPUT structure that contains the certificate store and certificate context chain information.</param>
		/// <param name="ppOutBuffer">The address of a pointer to a buffer that receives the serialized certificates BLOB.</param>
		/// <param name="pulOutBufferSize">A pointer to a <c>ULONG</c> to receive the size, in bytes, of the BLOB received in the buffer pointed to by the ppOutBuffer parameter.</param>
		/// <returns>
		/// <para>If the function succeeds, the function returns <c>S_OK</c>.</para>
		/// <para>If the function fails, it returns an <c>HRESULT</c> value that indicates the error. If both <c>hStore</c> and <c>prgpChain</c> parameters are not <c>NULL</c>, return <c>E_INVALIDARG</c>. For a list of common error codes, see Common HRESULT Values.</para>
		/// </returns>
		/// <remarks>
		/// <para>The returned serialized BLOB is passed to the CredUIPromptForWindowsCredentials function in the pvInAuthBuffer parameter to allow a user to select a certificate by using the credential selection UI.</para>
		/// <para>The certificates that are serialized in the BLOB returned in the buffer pointed to by the ppOutBuffer parameter of this function are dependent on the values of the <c>hStore</c> and <c>prgpChain</c> members of the CERT_SELECTUI_INPUT structure.</para>
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
		// https://docs.microsoft.com/en-us/windows/win32/api/cryptuiapi/nf-cryptuiapi-certselectiongetserializedblob
		// HRESULT CertSelectionGetSerializedBlob( PCERT_SELECTUI_INPUT pcsi, void **ppOutBuffer, ULONG *pulOutBufferSize );
		[DllImport(Lib.Cryptui, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("cryptuiapi.h", MSDNShortId = "6c3240f7-5121-401d-a4d4-df3055cb301a")]
		public static extern HRESULT CertSelectionGetSerializedBlob(in CERT_SELECTUI_INPUT pcsi, out IntPtr ppOutBuffer, ref uint pulOutBufferSize);

		ACUIProviderInvokeUI
		AddChainToStore
		CertDllLogMismatchPinRules
		CertDllProtectedRootMessageBox
		CertSelectionGetSerializedBlob
		CommonInit
		CompareCertificate
		CryptDllProtectPrompt
		CryptUIDlgAddPolicyServer
		CryptUIDlgAddPolicyServerWithPriority
		CryptUIDlgCertMgr
		CryptUIDlgFreeCAContext
		CryptUIDlgFreePolicyServerContext
		CryptUIDlgPropertyPolicy
		CryptUIDlgSelectCA
		CryptUIDlgSelectCertificate
		CryptUIDlgSelectCertificateFromStore
		CryptUIDlgSelectPolicyServer
		CryptUIDlgSelectStore
		CryptUIDlgViewCertificate
		CryptUIDlgViewCertificateProperties
		CryptUIDlgViewContext
		CryptUIDlgViewCRL
		CryptUIDlgViewCTL
		CryptUIDlgViewSignerInfo
		CryptUIFreeCertificatePropertiesPages
		CryptUIFreeViewSignaturesPages
		CryptUIGetCertificatePropertiesPages
		CryptUIGetViewSignaturesPages
		CryptUIStartCertMgr
		CryptUIViewExpiringCerts
		CryptUIWizBuildCTL
		CryptUIWizDigitalSign
		CryptUIWizExport
		CryptUIWizFreeDigitalSignContext
		CryptUIWizImport
		CryptUIWizImportInternal
		DisplayHtmlHelp
		FormatDateStringAutoLayout
		GetUnknownErrorString
		InvokeHelpLink
		IsWizardExtensionAvailable
		MyFormatEnhancedKeyUsageString

		*/
	}
}