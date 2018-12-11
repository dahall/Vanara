using System;
using System.Runtime.InteropServices;
using Vanara.InteropServices;
using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;

namespace Vanara.PInvoke
{
	/// <summary>Methods and data types found in Crypt32.dll.</summary>
	public static partial class Crypt32
	{
		/// <summary>Private key pair type.</summary>
		[PInvokeData("wincrypt.h")]
		public enum PrivateKeyType
		{
			/// <summary>Key exchange</summary>
			AT_KEYEXCHANGE = 1,
			/// <summary>Digital signature</summary>
			AT_SIGNATURE = 2
		}

		/// <summary>
		/// The CERT_CONTEXT structure contains both the encoded and decoded representations of a certificate. A certificate context returned
		/// by one of the functions defined in Wincrypt.h must be freed by calling the CertFreeCertificateContext function. The
		/// CertDuplicateCertificateContext function can be called to make a duplicate copy (which also must be freed by calling CertFreeCertificateContext).
		/// </summary>
		[PInvokeData("wincrypt.h")]
		[StructLayout(LayoutKind.Sequential)]
		public struct CERT_CONTEXT
		{
			/// <summary>
			/// Type of encoding used. It is always acceptable to specify both the certificate and message encoding types by combining them
			/// with a bitwise-OR operation.
			/// </summary>
			public uint dwCertEncodingType;

			/// <summary>A pointer to a buffer that contains the encoded certificate.</summary>
			public IntPtr pbCertEncoded;

			/// <summary>The size, in bytes, of the encoded certificate.</summary>
			public uint cbCertEncoded;

			/// <summary>The address of a CERT_INFO structure that contains the certificate information.</summary>
			public IntPtr pCertInfo;

			/// <summary>A handle to the certificate store that contains the certificate context.</summary>
			public IntPtr hCertStore;
		}

		/// <summary>
		/// The CERT_EXTENSION structure contains the extension information for a certificate, Certificate Revocation List (CRL) or
		/// Certificate Trust List (CTL).
		/// </summary>
		[PInvokeData("wincrypt.h")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
		public struct CERT_EXTENSION
		{
			/// <summary>
			/// Object identifier (OID) that specifies the structure of the extension data contained in the Value member. For specifics on
			/// extension OIDs and their related structures, see X.509 Certificate Extension Structures.
			/// </summary>
			public StrPtrAnsi pszObjId;

			/// <summary>
			/// If TRUE, any limitations specified by the extension in the Value member of this structure are imperative. If FALSE,
			/// limitations set by this extension can be ignored.
			/// </summary>
			[MarshalAs(UnmanagedType.Bool)]
			public bool fCritical;

			/// <summary>
			/// A CRYPT_OBJID_BLOB structure that contains the encoded extension data. The cbData member of Value indicates the length in
			/// bytes of the pbData member. The pbData member byte string is the encoded extension.e
			/// </summary>
			public CRYPTOAPI_BLOB Value;
		}

		/// <summary>The CERT_INFO structure contains the information of a certificate.</summary>
		[PInvokeData("wincrypt.h")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
		public struct CERT_INFO
		{
			/// <summary>The version number of a certificate.</summary>
			public uint dwVersion;

			/// <summary>
			/// A BLOB that contains the serial number of a certificate. The least significant byte is the zero byte of the pbData member of
			/// SerialNumber. The index for the last byte of pbData, is one less than the value of the cbData member of SerialNumber. The
			/// most significant byte is the last byte of pbData. Leading 0x00 or 0xFF bytes are removed. For more information, see CertCompareIntegerBlob.
			/// </summary>
			public CRYPTOAPI_BLOB SerialNumber;

			/// <summary>
			/// A CRYPT_ALGORITHM_IDENTIFIER structure that contains the signature algorithm type and encoded additional encryption parameters.
			/// </summary>
			public CRYPT_ALGORITHM_IDENTIFIER SignatureAlgorithm;

			/// <summary>The name, in encoded form, of the issuer of the certificate.</summary>
			public CRYPTOAPI_BLOB Issuer;

			/// <summary>
			/// Date and time before which the certificate is not valid. For dates between 1950 and 2049 inclusive, the date and time is
			/// encoded Coordinated Universal Time (Greenwich Mean Time) format in the form YYMMDDHHMMSS. This member uses a two-digit year
			/// and is precise to seconds. For dates before 1950 or after 2049, encoded generalized time is used. Encoded generalized time is
			/// in the form YYYYMMDDHHMMSSMMM, using a four-digit year, and is precise to milliseconds. Even though generalized time supports
			/// millisecond resolution, the NotBefore time is only precise to seconds.
			/// </summary>
			public FILETIME NotBefore;

			/// <summary>
			/// Date and time after which the certificate is not valid. For dates between 1950 and 2049 inclusive, the date and time is
			/// encoded Coordinated Universal Time format in the form YYMMDDHHMMSS. This member uses a two-digit year and is precise to
			/// seconds. For dates before 1950 or after 2049, encoded generalized time is used. Encoded generalized time is in the form
			/// YYYYMMDDHHMMSSMMM, using a four-digit year, and is precise to milliseconds. Even though generalized time supports millisecond
			/// resolution, the NotAfter time is only precise to seconds.
			/// </summary>
			public FILETIME NotAfter;

			/// <summary>The encoded name of the subject of the certificate.</summary>
			public CRYPTOAPI_BLOB Subject;

			/// <summary>
			/// A CERT_PUBLIC_KEY_INFO structure that contains the encoded public key and its algorithm. The PublicKey member of the
			/// CERT_PUBLIC_KEY_INFO structure contains the encoded public key as a CRYPT_BIT_BLOB, and the Algorithm member contains the
			/// encoded algorithm as a CRYPT_ALGORITHM_IDENTIFIER.
			/// </summary>
			public CERT_PUBLIC_KEY_INFO SubjectPublicKeyInfo;

			/// <summary>A BLOB that contains a unique identifier of the issuer.</summary>
			public CRYPTOAPI_BLOB IssuerUniqueId;

			/// <summary>A BLOB that contains a unique identifier of the subject.</summary>
			public CRYPTOAPI_BLOB SubjectUniqueId;

			/// <summary>The number of elements in the rgExtension array.</summary>
			public uint cExtension;

			/// <summary>An array of pointers to CERT_EXTENSION structures, each of which contains extension information about the certificate.</summary>
			public IntPtr rgExtension;
		}

		/// <summary>The CERT_PUBLIC_KEY_INFO structure contains a public key and its algorithm.</summary>
		[PInvokeData("wincrypt.h")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
		public struct CERT_PUBLIC_KEY_INFO
		{
			/// <summary>CRYPT_ALGORITHM_IDENTIFIER structure that contains the public key algorithm type and associated additional parameters.</summary>
			public CRYPT_ALGORITHM_IDENTIFIER Algorithm;

			/// <summary>BLOB containing an encoded public key.</summary>
			public CRYPTOAPI_BLOB PublicKey;
		}

		/// <summary>
		/// The CRYPT_ALGORITHM_IDENTIFIER structure specifies an algorithm used to encrypt a private key. The structure includes the object
		/// identifier (OID) of the algorithm and any needed parameters for that algorithm. The parameters contained in its CRYPT_OBJID_BLOB
		/// are encoded.
		/// </summary>
		[PInvokeData("wincrypt.h")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
		public struct CRYPT_ALGORITHM_IDENTIFIER
		{
			/// <summary>An OID of an algorithm.</summary>
			public StrPtrAnsi pszObjId;

			/// <summary>
			/// A BLOB that provides encoded algorithm-specific parameters. In many cases, there are no parameters. This is indicated by
			/// setting the cbData member of the Parameters BLOB to zero.
			/// </summary>
			public CRYPTOAPI_BLOB Parameters;
		}

		/// <summary>
		/// The BLOB structure contains an arbitrary array of bytes. The structure definition includes aliases appropriate to the various
		/// functions that use it.
		/// </summary>
		[PInvokeData("wincrypt.h")]
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
		public struct CRYPTOAPI_BLOB
		{
			/// <summary>A DWORD variable that contains the count, in bytes, of data.</summary>
			public uint cbData;

			/// <summary>A pointer to the data buffer.</summary>
			public IntPtr pbData;
		}

		/*CertAddCertificateContextToStore
		CertAddCertificateLinkToStore
		CertAddCRLContextToStore
		CertAddCRLLinkToStore
		CertAddCTLContextToStore
		CertAddCTLLinkToStore
		CertAddEncodedCertificateToStore
		CertAddEncodedCertificateToSystemStore
		CertAddEncodedCRLToStore
		CertAddEncodedCTLToStore
		CertAddEnhancedKeyUsageIdentifier
		CertAddRefServerOcspResponse
		CertAddRefServerOcspResponseContext
		CertAddSerializedElementToStore
		CertAddStoreToCollection
		CertAlgIdToOID
		CertCloseServerOcspResponse
		CertCloseStore
		CertCompareCertificate
		CertCompareCertificateName
		CertCompareIntegerBlob
		CertComparePublicKeyInfo
		CertControlStore
		CertCreateCertificateChainEngine
		CertCreateCertificateContext
		CertCreateContext
		CertCreateCRLContext
		CertCreateCTLContext
		CertCreateCTLEntryFromCertificateContextProperties
		CertCreateSelfSignCertificate
		CertDeleteCertificateFromStore
		CertDeleteCRLFromStore
		CertDeleteCTLFromStore
		CertDuplicateCertificateChain
		CertDuplicateCertificateContext
		CertDuplicateCRLContext
		CertDuplicateCTLContext
		CertDuplicateStore
		CertEnumCertificateContextProperties
		CertEnumCertificatesInStore
		CertEnumCRLContextProperties
		CertEnumCRLsInStore
		CertEnumCTLContextProperties
		CertEnumCTLsInStore
		CertEnumPhysicalStore
		CertEnumSubjectInSortedCTL
		CertEnumSystemStore
		CertEnumSystemStoreLocation
		CertFindAttribute
		CertFindCertificateInCRL
		CertFindCertificateInStore
		CertFindChainInStore
		CertFindCRLInStore
		CertFindCTLInStore
		CertFindExtension
		CertFindRDNAttr
		CertFindSubjectInCTL
		CertFindSubjectInSortedCTL
		CertFreeCertificateChain
		CertFreeCertificateChainEngine
		CertFreeCertificateChainList
		CertFreeCertificateContext
		CertFreeCRLContext
		CertFreeCTLContext
		CertFreeServerOcspResponseContext
		CertGetCertificateChain
		CertGetCertificateContextProperty
		CertGetCRLContextProperty
		CertGetCRLFromStore
		CertGetCTLContextProperty
		CertGetEnhancedKeyUsage
		CertGetIntendedKeyUsage
		CertGetIssuerCertificateFromStore
		CertGetNameString
		CertGetPublicKeyLength
		CertGetServerOcspResponseContext
		CertGetStoreProperty
		CertGetSubjectCertificateFromStore
		CertGetValidUsages
		CertIsRDNAttrsInCertificateName
		CertIsStrongHashToSign
		CertIsValidCRLForCertificate
		CertNameToStr
		CertOIDToAlgId
		CertOpenServerOcspResponse
		CertOpenStore
		CertOpenSystemStore
		CertRDNValueToStr
		CertRegisterPhysicalStore
		CertRegisterSystemStore
		CertRemoveEnhancedKeyUsageIdentifier
		CertRemoveStoreFromCollection
		CertResyncCertificateChainEngine
		CertRetrieveLogoOrBiometricInfo
		CertSaveStore
		CertSelectCertificateChains
		CertSerializeCertificateStoreElement
		CertSerializeCRLStoreElement
		CertSerializeCTLStoreElement
		CertSetCertificateContextPropertiesFromCTLEntry
		CertSetCertificateContextProperty
		CertSetCRLContextProperty
		CertSetCTLContextProperty
		CertSetEnhancedKeyUsage
		CertSetStoreProperty
		CertStrToName
		CertUnregisterPhysicalStore
		CertUnregisterSystemStore
		CertVerifyCertificateChainPolicy
		CertVerifyCRLRevocation
		CertVerifyCRLTimeValidity
		CertVerifyCTLUsage
		CertVerifyRevocation
		CertVerifySubjectCertificateContext
		CertVerifyTimeValidity
		CertVerifyValidityNesting
		CryptAcquireCertificatePrivateKey
		CryptBinaryToString
		CryptCreateKeyIdentifierFromCSP
		CryptDecodeMessage
		CryptDecodeObject
		CryptDecodeObjectEx
		CryptDecryptAndVerifyMessageSignature
		CryptDecryptMessage
		CryptEncodeObject
		CryptEncodeObjectEx
		CryptEncryptMessage
		CryptEnumKeyIdentifierProperties
		CryptEnumOIDFunction
		CryptEnumOIDInfo
		CryptExportPublicKeyInfo
		CryptExportPublicKeyInfoEx
		CryptExportPublicKeyInfoFromBCryptKeyHandle
		CryptFindCertificateKeyProvInfo
		CryptFindLocalizedName
		CryptFindOIDInfo
		CryptFormatObject
		CryptFreeOIDFunctionAddress
		CryptGetDefaultOIDDllList
		CryptGetDefaultOIDFunctionAddress
		CryptGetKeyIdentifierProperty
		CryptGetMessageCertificates
		CryptGetMessageSignerCount
		CryptGetOIDFunctionAddress
		CryptGetOIDFunctionValue
		CryptHashCertificate
		CryptHashCertificate2
		CryptHashMessage
		CryptHashPublicKeyInfo
		CryptHashToBeSigned
		CryptImportPublicKeyInfo
		CryptImportPublicKeyInfoEx
		CryptImportPublicKeyInfoEx2
		CryptInitOIDFunctionSet
		CryptInstallDefaultContext
		CryptInstallOIDFunctionAddress
		CryptMemAlloc
		CryptMemFree
		CryptMemRealloc
		CryptMsgCalculateEncodedLength
		CryptMsgClose
		CryptMsgControl
		CryptMsgCountersign
		CryptMsgCountersignEncoded
		CryptMsgDuplicate
		CryptMsgEncodeAndSignCTL
		CryptMsgGetAndVerifySigner
		CryptMsgGetParam
		CryptMsgOpenToDecode
		CryptMsgOpenToEncode
		CryptMsgSignCTL
		CryptMsgUpdate
		CryptMsgVerifyCountersignatureEncoded
		CryptMsgVerifyCountersignatureEncodedEx
		CryptQueryObject
		CryptRegisterDefaultOIDFunction
		CryptRegisterOIDFunction
		CryptRegisterOIDInfo
		CryptRetrieveTimeStamp
		CryptSetKeyIdentifierProperty
		CryptSetOIDFunctionValue
		CryptSignAndEncodeCertificate
		CryptSignAndEncryptMessage
		CryptSignCertificate
		CryptSignMessage
		CryptSignMessageWithKey
		CryptStringToBinary
		CryptUninstallDefaultContext
		CryptUnregisterDefaultOIDFunction
		CryptUnregisterOIDFunction
		CryptUnregisterOIDInfo
		CryptVerifyCertificateSignature
		CryptVerifyCertificateSignatureEx
		CryptVerifyDetachedMessageHash
		CryptVerifyDetachedMessageSignature
		CryptVerifyMessageHash
		CryptVerifyMessageSignature
		CryptVerifyMessageSignatureWithKey
		CryptVerifyTimeStampSignature
		PFXExportCertStore
		PFXExportCertStoreEx
		PFXImportCertStore
		PFXIsPFXBlob
		PFXVerifyPassword*/
	}
}