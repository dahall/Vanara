using System;
using System.Runtime.InteropServices;
using Vanara.InteropServices;
using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;

namespace Vanara.PInvoke;

/// <summary>Methods and data types found in Crypt32.dll.</summary>
public static partial class Crypt32
{
	/// <summary>A callback function used to read from and write data to a disk when processing large messages.</summary>
	/// <param name="pvArg">The arguments specified by CMSG_STREAM_INFO.</param>
	/// <param name="pbData">A pointer to a block of processed data that is available to the application.</param>
	/// <param name="cbData">The size, in bytes, of the block of processed data at pbData.</param>
	/// <param name="fFinal">
	/// Specifies that the last block of data is being processed and that this is the last time the callback will be executed.
	/// </param>
	/// <returns><see langword="true"/> on success; <see langword="false"/> on failure.</returns>
	[PInvokeData("wincrypt.h", MSDNShortId = "a4e7f6e8-351f-4981-b223-50b65f503394")]
	public delegate bool PFN_CMSG_STREAM_OUTPUT([In] IntPtr pvArg, [In] IntPtr pbData, uint cbData, [MarshalAs(UnmanagedType.Bool)] bool fFinal);

	/// <summary>
	/// The <c>CryptGetSignerCertificateCallback</c> user supplied callback function is used with the CRYPT_VERIFY_MESSAGE_PARA
	/// structure to get and verify a message signer's certificate.
	/// </summary>
	/// <param name="pvGetArg"/>
	/// <param name="dwCertEncodingType">
	/// <para>
	/// Specifies the type of encoding used. It is always acceptable to specify both the certificate and message encoding types by
	/// combining them with a bitwise- <c>OR</c> operation as shown in the following example:
	/// </para>
	/// <para>X509_ASN_ENCODING | PKCS_7_ASN_ENCODING</para>
	/// <para>Currently defined encoding types are:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>X509_ASN_ENCODING</term>
	/// </item>
	/// <item>
	/// <term>PKCS_7_ASN_ENCODING</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pSignerId">
	/// A pointer to a CERT_INFO structure containing the issuer and serial number. Can be <c>NULL</c> if there is no content or signer.
	/// </param>
	/// <param name="hMsgCertStore">A handle to the certificate store containing all the certificates and CRLs in the signed message.</param>
	/// <returns>
	/// If a signer certificate is found, the function returns a pointer to a read-only CERT_CONTEXT. The returned <c>CERT_CONTEXT</c>
	/// was obtained either from a certificate store or was created using CertCreateCertificateContext. In either case, it must be freed
	/// using CertFreeCertificateContext. If this function fails, the return value is <c>NULL</c>.
	/// </returns>
	/// <remarks>If the message does not contain content or signers, the function is called with pSignerId set to <c>NULL</c>.</remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nc-wincrypt-pfn_crypt_get_signer_certificate
	// PFN_CRYPT_GET_SIGNER_CERTIFICATE PfnCryptGetSignerCertificate; PCCERT_CONTEXT PfnCryptGetSignerCertificate( void *pvGetArg, DWORD
	// dwCertEncodingType, PCERT_INFO pSignerId, HCERTSTORE hMsgCertStore ) {...}
	[PInvokeData("wincrypt.h", MSDNShortId = "557ebb26-cce0-4c41-b49c-769b2831cf35")]
	public delegate PCCERT_CONTEXT PFN_CRYPT_GET_SIGNER_CERTIFICATE([In, Out] IntPtr pvGetArg, CertEncodingType dwCertEncodingType, in CERT_INFO pSignerId, HCERTSTORE hMsgCertStore);

	/// <summary>Flags for various structure behaviors.</summary>
	[PInvokeData("wincrypt.h", MSDNShortId = "1601d860-6054-4650-a033-ea088655b7e4")]
	[Flags]
	public enum CryptMsgActionFlags
	{
		/// <summary>
		/// If the encoded output is to be a CMSG_SIGNED inner content of an outer cryptographic message such as a CMSG_ENVELOPED
		/// message, the CRYPT_MESSAGE_BARE_CONTENT_OUT_FLAG must be set.
		/// </summary>
		CRYPT_MESSAGE_BARE_CONTENT_OUT_FLAG = 0x00000001,

		/// <summary>CRYPT_MESSAGE_ENCAPSULATED_CONTENT_OUT_FLAG can be set to encapsulate non-data inner content into an OCTET STRING.</summary>
		CRYPT_MESSAGE_ENCAPSULATED_CONTENT_OUT_FLAG = 0x00000002,

		/// <summary>
		/// CRYPT_MESSAGE_KEYID_SIGNER_FLAG can be set to identify signers by their Key Identifier and not their Issuer and Serial Number.
		/// </summary>
		CRYPT_MESSAGE_KEYID_SIGNER_FLAG = 0x00000004,

		/// <summary>
		/// CRYPT_MESSAGE_SILENT_KEYSET_FLAG can be set to suppress any UI by the CSP. For more information about the CRYPT_SILENT flag,
		/// see CryptAcquireContext.
		/// </summary>
		CRYPT_MESSAGE_SILENT_KEYSET_FLAG = 0x00000040,
	}

	/// <summary>Message control types.</summary>
	[PInvokeData("wincrypt.h", MSDNShortId = "a990d44d-2993-429f-b817-2a834105ecef")]
	public enum CryptMsgControlType
	{
		/// <summary>A BLOB that contains the encoded bytes of attribute certificate.</summary>
		[CorrespondingType(typeof(CRYPTOAPI_BLOB))]
		CMSG_CTRL_ADD_ATTR_CERT = 14,

		/// <summary>A CRYPT_INTEGER_BLOB structure that contains the encoded bytes of the certificate to be added to the message.</summary>
		[CorrespondingType(typeof(CRYPTOAPI_BLOB))]
		CMSG_CTRL_ADD_CERT = 10,

		/// <summary>
		/// A CMSG_CMS_SIGNER_INFO structure that contains signer information. This operation differs from CMSG_CTRL_ADD_SIGNER because
		/// the signer information contains the signature.
		/// </summary>
		[CorrespondingType(typeof(CMSG_CMS_SIGNER_INFO))]
		CMSG_CTRL_ADD_CMS_SIGNER_INFO = 20,

		/// <summary>A BLOB that contains the encoded bytes of the CRL to be added to the message.</summary>
		[CorrespondingType(typeof(CRYPTOAPI_BLOB))]
		CMSG_CTRL_ADD_CRL = 12,

		/// <summary>A CMSG_SIGNER_ENCODE_INFO structure that contains the signer information to be added to the message.</summary>
		[CorrespondingType(typeof(CMSG_SIGNER_ENCODE_INFO))]
		CMSG_CTRL_ADD_SIGNER = 6,

		/// <summary>
		/// A CMSG_CTRL_ADD_SIGNER_UNAUTH_ATTR_PARA structure that contains the index of the signer and a BLOB that contains the
		/// unauthenticated attribute information to be added to the message.
		/// </summary>
		[CorrespondingType(typeof(CMSG_CTRL_ADD_SIGNER_UNAUTH_ATTR_PARA))]
		CMSG_CTRL_ADD_SIGNER_UNAUTH_ATTR = 8,

		/// <summary>
		/// A CMSG_CTRL_DECRYPT_PARA structure used to decrypt the message for the specified key transport recipient. This value is
		/// applicable to RSA recipients. This operation specifies that the CryptMsgControl function search the recipient index to
		/// obtain the key transport recipient information. If the function fails, GetLastError will return CRYPT_E_INVALID_INDEX if no
		/// key transport recipient is found.
		/// </summary>
		[CorrespondingType(typeof(CMSG_CTRL_DECRYPT_PARA))]
		CMSG_CTRL_DECRYPT = 2,

		/// <summary>The index of the attribute certificate to be removed.</summary>
		[CorrespondingType(typeof(uint))]
		CMSG_CTRL_DEL_ATTR_CERT = 15,

		/// <summary>The index of the certificate to be deleted from the message.</summary>
		[CorrespondingType(typeof(uint))]
		CMSG_CTRL_DEL_CERT = 11,

		/// <summary>The index of the CRL to be deleted from the message.</summary>
		[CorrespondingType(typeof(uint))]
		CMSG_CTRL_DEL_CRL = 13,

		/// <summary>The index of the signer to be deleted.</summary>
		[CorrespondingType(typeof(uint))]
		CMSG_CTRL_DEL_SIGNER = 7,

		/// <summary>
		/// A CMSG_CTRL_DEL_SIGNER_UNAUTH_ATTR_PARA structure that contains an index that specifies the signer and the index that
		/// specifies the signer's unauthenticated attribute to be deleted.
		/// </summary>
		[CorrespondingType(typeof(CMSG_CTRL_DEL_SIGNER_UNAUTH_ATTR_PARA))]
		CMSG_CTRL_DEL_SIGNER_UNAUTH_ATTR = 9,

		/// <summary>
		/// A CERT_STRONG_SIGN_PARA structure used to perform strong signature checking.
		/// <para>
		/// To check for a strong signature, specify this control type before calling CryptMsgGetAndVerifySigner or before calling
		/// CryptMsgControl with the following control types set:
		/// </para>
		/// <para>CMSG_CTRL_VERIFY_SIGNATURE</para>
		/// <para>CMSG_CTRL_VERIFY_SIGNATURE_EX</para>
		/// <para>
		/// After the signature is successfully verified, this function checks for a strong signature. If the signature is not strong,
		/// the operation will fail and the GetLastError value will be set to NTE_BAD_ALGID.
		/// </para>
		/// </summary>
		[CorrespondingType(typeof(CERT_STRONG_SIGN_PARA))]
		CMSG_CTRL_ENABLE_STRONG_SIGNATURE = 21,

		/// <summary>
		/// A CMSG_CTRL_KEY_AGREE_DECRYPT_PARA structure used to decrypt the message for the specified key agreement session key. Key
		/// agreement is used with Diffie-Hellman encryption/decryption.
		/// </summary>
		[CorrespondingType(typeof(CMSG_CTRL_KEY_AGREE_DECRYPT_PARA))]
		CMSG_CTRL_KEY_AGREE_DECRYPT = 17,

		/// <summary>
		/// A CMSG_CTRL_KEY_TRANS_DECRYPT_PARA structure used to decrypt the message for the specified key transport recipient. Key
		/// transport is used with RSA encryption/decryption.
		/// </summary>
		[CorrespondingType(typeof(CMSG_CTRL_KEY_TRANS_DECRYPT_PARA))]
		CMSG_CTRL_KEY_TRANS_DECRYPT = 16,

		/// <summary>
		/// A CMSG_CTRL_MAIL_LIST_DECRYPT_PARA structure used to decrypt the message for the specified recipient using a previously
		/// distributed key-encryption key (KEK).
		/// </summary>
		[CorrespondingType(typeof(CMSG_CTRL_MAIL_LIST_DECRYPT_PARA))]
		CMSG_CTRL_MAIL_LIST_DECRYPT = 18,

		/// <summary>This value is not used.</summary>
		CMSG_CTRL_VERIFY_HASH = 5,

		/// <summary>A CERT_INFO structure that identifies the signer of the message whose signature is to be verified.</summary>
		[CorrespondingType(typeof(CERT_INFO))]
		CMSG_CTRL_VERIFY_SIGNATURE = 1,

		/// <summary>
		/// A CMSG_CTRL_VERIFY_SIGNATURE_EX_PARA structure that specifies the signer index and public key to verify the message
		/// signature. The signer public key can be a CERT_PUBLIC_KEY_INFO structure, a certificate context, or a certificate chain context.
		/// </summary>
		[CorrespondingType(typeof(CMSG_CTRL_VERIFY_SIGNATURE_EX_PARA))]
		CMSG_CTRL_VERIFY_SIGNATURE_EX = 19,
	}

	/// <summary>Flags for message functions.</summary>
	[PInvokeData("wincrypt.h", MSDNShortId = "1c12003a-c2f3-4069-8bd6-b8f2875b0c98")]
	[Flags]
	public enum CryptMsgFlags
	{
		/// <summary>
		/// Indicates that streamed output will not have an outer ContentInfo wrapper (as defined by PKCS #7). This makes it suitable to
		/// be streamed into an enclosing message.
		/// </summary>
		CMSG_BARE_CONTENT_FLAG = 0x00000001,

		/// <summary></summary>
		CMSG_LENGTH_ONLY_FLAG = 0x00000002,

		/// <summary>Indicates that there is detached data being supplied for the subsequent calls to CryptMsgUpdate.</summary>
		CMSG_DETACHED_FLAG = 0x00000004,

		/// <summary>
		/// Authenticated attributes are forced to be included in the SignerInfo (as defined by PKCS #7) in cases where they would not
		/// otherwise be required.
		/// </summary>
		CMSG_AUTHENTICATED_ATTRIBUTES_FLAG = 0x00000008,

		/// <summary>
		/// Used to calculate the size of a DER encoding of a message to be nested inside an enveloped message. This is particularly
		/// useful when streaming is being performed.
		/// </summary>
		CMSG_CONTENTS_OCTETS_FLAG = 0x00000010,

		/// <summary></summary>
		CMSG_MAX_LENGTH_FLAG = 0x00000020,

		/// <summary>
		/// Non-Data type inner content is encapsulated within an OCTET STRING. This flag is applicable for both Signed and Enveloped messages.
		/// </summary>
		CMSG_CMS_ENCAPSULATED_CONTENT_FLAG = 0x00000040,

		/// <summary></summary>
		CMSG_SIGNED_DATA_NO_SIGN_FLAG = 0x00000080,

		/// <summary>
		/// If set, the hCryptProv that is passed to this function is released on the final CryptMsgUpdate. The handle is not released
		/// if the function fails.
		/// </summary>
		CMSG_CRYPT_RELEASE_CONTEXT_FLAG = 0x00008000,
	}

	/// <summary>Flags used by CMSG_KEY_AGREE_RECIPIENT_INFO.</summary>
	[PInvokeData("wincrypt.h")]
	public enum CryptMsgKeyOriginator
	{
		/// <summary>OriginatorCertId</summary>
		CMSG_KEY_AGREE_ORIGINATOR_CERT = 1,

		/// <summary>OriginatorPublicKeyInfo</summary>
		CMSG_KEY_AGREE_ORIGINATOR_PUBLIC_KEY = 2,
	}

	/// <summary>
	/// Indicates the parameter types of data to be retrieved.
	/// <para>
	/// For an encoded message, only the CMSG_BARE_CONTENT, CMSG_ENCODE_SIGNER, CMSG_CONTENT_PARAM and CMSG_COMPUTED_HASH_PARAM
	/// dwParamTypes are valid.
	/// </para>
	/// </summary>
	[PInvokeData("wincrypt.h", MSDNShortId = "5a05eb09-208f-4e94-abfa-c2f14c0a3164")]
	public enum CryptMsgParamType
	{
		/// <summary>
		/// Returns the message type of a decoded message of unknown type. The retrieved message type can be compared to supported types
		/// to determine whether processing can continued. For supported message types, see the dwMessageType parameter of CryptMsgOpenToDecode.
		/// </summary>
		[CorrespondingType(typeof(uint))]
		CMSG_TYPE_PARAM = 1,

		/// <summary>
		/// Returns the whole PKCS #7 message from a message opened to encode. Retrieves the inner content of a message opened to
		/// decode. If the message is enveloped, the inner type is data, and CryptMsgControl has been called to decrypt the message, the
		/// decrypted content is returned. If the inner type is not data, the encoded BLOB that requires further decoding is returned.
		/// If the message is not enveloped and the inner content is DATA, the returned data is the octets of the inner content. This
		/// type is applicable to both encode and decode.
		/// <para>For decoding, if the type is CMSG_DATA, the content's octets are returned; else, the encoded inner content is returned.</para>
		/// </summary>
		[CorrespondingType(typeof(byte[]))]
		[CorrespondingType(typeof(CRYPTOAPI_BLOB))]
		CMSG_CONTENT_PARAM = 2,

		/// <summary>
		/// Retrieves the encoded content of an encoded cryptographic message, without the outer layer of the CONTENT_INFO structure.
		/// That is, only the encoding of the PKCS #7 defined ContentInfo.content field is returned.
		/// </summary>
		[CorrespondingType(typeof(byte[]))]
		CMSG_BARE_CONTENT_PARAM = 3,

		/// <summary>Returns the inner content type of a received message. This type is not applicable to messages of type DATA.</summary>
		[CorrespondingType(typeof(byte[]))]
		CMSG_INNER_CONTENT_TYPE_PARAM = 4,

		/// <summary>Returns the number of signers of a received SIGNED message.</summary>
		[CorrespondingType(typeof(uint))]
		CMSG_SIGNER_COUNT_PARAM = 5,

		/// <summary>
		/// Returns information on a message signer. This includes the issuer and serial number of the signer's certificate and
		/// authenticated and unauthenticated attributes of the signer's certificate. To retrieve signer information on all of the
		/// signers of a message, call CryptMsgGetParam varying dwIndex from 0 to the number of signers minus one.
		/// </summary>
		[CorrespondingType(typeof(byte[]))]
		CMSG_SIGNER_INFO_PARAM = 6,

		/// <summary>
		/// Returns information on a message signer needed to identify the signer's certificate. A certificate's Issuer and SerialNumber
		/// can be used to uniquely identify a certificate for retrieval. To retrieve information for all the signers, repetitively call
		/// CryptMsgGetParam varying dwIndex from 0 to the number of signers minus one. Only the Issuer and SerialNumber fields in the
		/// CERT_INFO structure returned contain available, valid data.
		/// </summary>
		[CorrespondingType(typeof(byte[]))]
		CMSG_SIGNER_CERT_INFO_PARAM = 7,

		/// <summary>
		/// Returns the hash algorithm used by a signer of the message. To get the hash algorithm for a specified signer, call
		/// CryptMsgGetParam with dwIndex equal to that signer's index.
		/// </summary>
		[CorrespondingType(typeof(byte[]))]
		CMSG_SIGNER_HASH_ALGORITHM_PARAM = 8,

		/// <summary>
		/// Returns the authenticated attributes of a message signer. To retrieve the authenticated attributes for a specified signer,
		/// call CryptMsgGetParam with dwIndex equal to that signer's index.
		/// </summary>
		[CorrespondingType(typeof(byte[]))]
		CMSG_SIGNER_AUTH_ATTR_PARAM = 9,

		/// <summary>
		/// Returns a message signer's unauthenticated attributes. To retrieve the unauthenticated attributes for a specified signer,
		/// call CryptMsgGetParam with dwIndex equal to that signer's index.
		/// </summary>
		[CorrespondingType(typeof(byte[]))]
		CMSG_SIGNER_UNAUTH_ATTR_PARAM = 10,

		/// <summary>Returns the number of certificates in a received SIGNED or ENVELOPED message.</summary>
		[CorrespondingType(typeof(uint))]
		CMSG_CERT_COUNT_PARAM = 11,

		/// <summary>
		/// Returns a signer's certificate. To get all of the signer's certificates, call CryptMsgGetParam, varying dwIndex from 0 to
		/// the number of available certificates minus one.
		/// </summary>
		[CorrespondingType(typeof(byte[]))]
		CMSG_CERT_PARAM = 12,

		/// <summary>Returns the count of CRLs in a received, SIGNED or ENVELOPED message.</summary>
		[CorrespondingType(typeof(uint))]
		CMSG_CRL_COUNT_PARAM = 13,

		/// <summary>
		/// Returns a CRL. To get all the CRLs, call CryptMsgGetParam, varying dwIndex from 0 to the number of available CRLs minus one.
		/// </summary>
		[CorrespondingType(typeof(byte[]))]
		CMSG_CRL_PARAM = 14,

		/// <summary>Returns the encryption algorithm used to encrypt an ENVELOPED message.</summary>
		[CorrespondingType(typeof(byte[]))]
		CMSG_ENVELOPE_ALGORITHM_PARAM = 15,

		/// <summary>Returns the number of key transport recipients of an ENVELOPED received message.</summary>
		[CorrespondingType(typeof(uint))]
		CMSG_RECIPIENT_COUNT_PARAM = 17,

		/// <summary>
		/// Returns the index of the key transport recipient used to decrypt an ENVELOPED message. This value is available only after a
		/// message has been decrypted.
		/// </summary>
		[CorrespondingType(typeof(uint))]
		CMSG_RECIPIENT_INDEX_PARAM = 18,

		/// <summary>
		/// Returns certificate information about a key transport message's recipient. To get certificate information on all key
		/// transport message's recipients, repetitively call CryptMsgGetParam, varying dwIndex from 0 to the number of recipients minus
		/// one. Only the Issuer, SerialNumber, and PublicKeyAlgorithm members of the CERT_INFO structure returned are available and valid.
		/// </summary>
		[CorrespondingType(typeof(byte[]))]
		CMSG_RECIPIENT_INFO_PARAM = 19,

		/// <summary>Returns the hash algorithm used to hash the message when it was created.</summary>
		[CorrespondingType(typeof(byte[]))]
		CMSG_HASH_ALGORITHM_PARAM = 20,

		/// <summary>Returns the hash value stored in the message when it was created.</summary>
		[CorrespondingType(typeof(byte[]))]
		CMSG_HASH_DATA_PARAM = 21,

		/// <summary>Returns the hash calculated of the data in the message. This type is applicable to both encode and decode.</summary>
		[CorrespondingType(typeof(byte[]))]
		CMSG_COMPUTED_HASH_PARAM = 22,

		/// <summary>Returns the encryption algorithm used to encrypted the message.</summary>
		[CorrespondingType(typeof(byte[]))]
		CMSG_ENCRYPT_PARAM = 26,

		/// <summary>Returns the encrypted hash of a signature. Typically used for performing time-stamping.</summary>
		[CorrespondingType(typeof(byte[]))]
		CMSG_ENCRYPTED_DIGEST = 27,

		/// <summary>Returns the encoded CMSG_SIGNER_INFO signer information for a message signer.</summary>
		[CorrespondingType(typeof(byte[]))]
		CMSG_ENCODED_SIGNER = 28,

		/// <summary>
		/// Changes the contents of an already encoded message. The message must first be decoded with a call to CryptMsgOpenToDecode.
		/// Then the change to the message is made through a call to CryptMsgControl, CryptMsgCountersign, or
		/// CryptMsgCountersignEncoded. The message is then encoded again with a call to CryptMsgGetParam, specifying
		/// CMSG_ENCODED_MESSAGE to get a new encoding that reflects the changes made. This can be used, for instance, to add a
		/// time-stamp attribute to a message.
		/// </summary>
		[CorrespondingType(typeof(byte[]))]
		CMSG_ENCODED_MESSAGE = 29,

		/// <summary>Returns the version of the decoded message. For more information, see the table in the Remarks section.</summary>
		[CorrespondingType(typeof(uint))]
		CMSG_VERSION_PARAM = 30,

		/// <summary>Returns the count of the attribute certificates in a SIGNED or ENVELOPED message.</summary>
		[CorrespondingType(typeof(uint))]
		CMSG_ATTR_CERT_COUNT_PARAM = 31,

		/// <summary>
		/// Retrieves an attribute certificate. To get all the attribute certificates, call CryptMsgGetParam varying dwIndex set to 0
		/// the number of attributes minus one.
		/// </summary>
		[CorrespondingType(typeof(byte[]))]
		CMSG_ATTR_CERT_PARAM = 32,

		/// <summary>Returns the total count of all message recipients including key agreement and mail list recipients.</summary>
		[CorrespondingType(typeof(uint))]
		CMSG_CMS_RECIPIENT_COUNT_PARAM = 33,

		/// <summary>Returns the index of the key transport, key agreement, or mail list recipient used to decrypt an ENVELOPED message.</summary>
		[CorrespondingType(typeof(uint))]
		CMSG_CMS_RECIPIENT_INDEX_PARAM = 34,

		/// <summary>Returns the index of the encrypted key of a key agreement recipient used to decrypt an ENVELOPED message.</summary>
		[CorrespondingType(typeof(uint))]
		CMSG_CMS_RECIPIENT_ENCRYPTED_KEY_INDEX_PARAM = 35,

		/// <summary>
		/// Returns information about a key transport, key agreement, or mail list recipient. It is not limited to key transport message
		/// recipients. To get information on all of a message's recipients, repetitively call CryptMsgGetParam, varying dwIndex from 0
		/// to the number of recipients minus one.
		/// </summary>
		[CorrespondingType(typeof(byte[]))]
		CMSG_CMS_RECIPIENT_INFO_PARAM = 36,

		/// <summary>Returns the unprotected attributes in an enveloped message.</summary>
		[CorrespondingType(typeof(byte[]))]
		CMSG_UNPROTECTED_ATTR_PARAM = 37,

		/// <summary>
		/// Returns information on a message signer needed to identify the signer's public key. This could be a certificate's Issuer and
		/// SerialNumber, a KeyID, or a HashId. To retrieve information for all the signers, call CryptMsgGetParam varying dwIndex from
		/// 0 to the number of signers minus one.
		/// </summary>
		[CorrespondingType(typeof(byte[]))]
		CMSG_SIGNER_CERT_ID_PARAM = 38,

		/// <summary>
		/// Returns information on a message signer. This includes a signerId and authenticated and unauthenticated attributes. To
		/// retrieve signer information on all of the signers of a message, call CryptMsgGetParam varying dwIndex from 0 to the number
		/// of signers minus one.
		/// </summary>
		[CorrespondingType(typeof(byte[]))]
		CMSG_CMS_SIGNER_INFO_PARAM = 39,
	}

	/// <summary>Message signer type.</summary>
	[PInvokeData("wincrypt.h", MSDNShortId = "56b73de8-c170-46f6-b488-096475b59c15")]
	public enum CryptMsgSignerType
	{
		/// <summary>CERT_PUBLIC_KEY_INFO</summary>
		[CorrespondingType(typeof(CERT_PUBLIC_KEY_INFO))]
		CMSG_VERIFY_SIGNER_PUBKEY = 1,

		/// <summary>CERT_CONTEXT</summary>
		[CorrespondingType(typeof(CERT_CONTEXT))]
		CMSG_VERIFY_SIGNER_CERT = 2,

		/// <summary>CERT_CHAIN_CONTEXT</summary>
		[CorrespondingType(typeof(CERT_CHAIN_CONTEXT))]
		CMSG_VERIFY_SIGNER_CHAIN = 3,

		/// <summary>The CMSG verify signer null</summary>
		CMSG_VERIFY_SIGNER_NULL = 4,
	}

	/// <summary>Message types.</summary>
	[PInvokeData("wincrypt.h", MSDNShortId = "1c12003a-c2f3-4069-8bd6-b8f2875b0c98")]
	public enum CryptMsgType
	{
		/// <summary>An octet (BYTE) string.</summary>
		CMSG_DATA = 1,

		/// <summary>CMSG_SIGNED_ENCODE_INFO</summary>
		CMSG_SIGNED = 2,

		/// <summary>CMSG_ENVELOPED_ENCODE_INFO</summary>
		CMSG_ENVELOPED = 3,

		/// <summary>Not implemented.</summary>
		CMSG_SIGNED_AND_ENVELOPED = 4,

		/// <summary>CMSG_HASHED_ENCODE_INFO</summary>
		CMSG_HASHED = 5,

		/// <summary>Not implemented.</summary>
		CMSG_ENCRYPTED = 6,
	}

	/// <summary>Flags that modify the function behavior.</summary>
	[PInvokeData("wincrypt.h", MSDNShortId = "da756cd5-1dec-4d88-9c90-76dd263035eb")]
	public enum CryptMsgVerifyCounterFlags
	{
		/// <summary>
		/// Performs a strong signature check after successful signature verification. Set the pvExtra parameter to point to a
		/// CERT_STRONG_SIGN_PARA structure that contains the parameters needed to check the signature strength.. Windows 8 and Windows
		/// Server 2012: Support for this flag begins.
		/// </summary>
		CMSG_VERIFY_COUNTER_SIGN_ENABLE_STRONG_FLAG = 0x00000001
	}

	/// <summary>
	/// <para>The <c>CryptDecodeMessage</c> function decodes, decrypts, and verifies a cryptographic message.</para>
	/// <para>
	/// This function can be used when the type of cryptographic message is unknown. The dwMsgTypeFlags constants can be combined with a
	/// bitwise- <c>OR</c> operation so that the function will try to find one of the types. When one of the types is found, the
	/// function reports the type found and returns the data appropriate to that type.
	/// </para>
	/// <para>
	/// In each pass, the function cracks only a single level of encryption or encoding. For additional cracking, this function, or one
	/// of the other Simplified Message Functions, must be called again.
	/// </para>
	/// </summary>
	/// <param name="dwMsgTypeFlags">
	/// <para>
	/// Indicates the message type. Message types can be combined with the bitwise- <c>OR</c> operator. This parameter can be one of the
	/// following message types:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>CMSG_DATA_FLAG</term>
	/// </item>
	/// <item>
	/// <term>CMSG_SIGNED_FLAG</term>
	/// </item>
	/// <item>
	/// <term>CMSG_ENVELOPED_FLAG</term>
	/// </item>
	/// <item>
	/// <term>CMSG_SIGNED_AND_ENVELOPED_FLAG</term>
	/// </item>
	/// <item>
	/// <term>CMSG_HASHED_FLAG</term>
	/// </item>
	/// </list>
	/// <para><c>Note</c> After return, the <c>DWORD</c> pointed to by pdwMsgType is set with the type of the message.</para>
	/// </param>
	/// <param name="pDecryptPara">A pointer to a CRYPT_DECRYPT_MESSAGE_PARA structure that contains decryption parameters.</param>
	/// <param name="pVerifyPara">A pointer to a CRYPT_VERIFY_MESSAGE_PARA structure that contains verification parameters.</param>
	/// <param name="dwSignerIndex">
	/// <para>
	/// Indicates which signer, among the possible many signers of a message, is to be verified. This index can be changed in multiple
	/// calls to the function to verify additional signers.
	/// </para>
	/// <para>
	/// dwSignerIndex is set to zero for the first signer. If the function returns <c>FALSE</c>, and GetLastError returns
	/// CRYPT_E_NO_SIGNER, the previous call returned the last signer of the message. This parameter is used only with messages of types
	/// CMSG_SIGNED_AND_ENVELOPED or CMSG_SIGNED. For all other message types, it should be set to zero.
	/// </para>
	/// </param>
	/// <param name="pbEncodedBlob">A pointer to the encoded BLOB that is to be decoded.</param>
	/// <param name="cbEncodedBlob">The size, in bytes, of the encoded BLOB.</param>
	/// <param name="dwPrevInnerContentType">
	/// Only applicable when processing nested cryptographic messages. When processing an outer cryptographic message, it must be set to
	/// zero. When decoding a nested cryptographic message, it is set to the value returned at pdwInnerContentType by a previous calling
	/// of <c>CryptDecodeMessage</c> for the outer message. It can be any of the CMSG types listed in pdwMsgType. For backward
	/// compatibility, set dwPrevInnerContentType to zero.
	/// </param>
	/// <param name="pdwMsgType">
	/// <para>
	/// A pointer to a <c>DWORD</c> that specifies the message type returned. This parameter can be one of the following message types:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>CMSG_DATA</term>
	/// </item>
	/// <item>
	/// <term>CMSG_SIGNED</term>
	/// </item>
	/// <item>
	/// <term>CMSG_ENVELOPED</term>
	/// </item>
	/// <item>
	/// <term>CMSG_SIGNED_AND_ENVELOPED</term>
	/// </item>
	/// <item>
	/// <term>CMSG_HASHED</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pdwInnerContentType">
	/// <para>
	/// A pointer to a <c>DWORD</c> that specifies the type of an inner message. The message type codes used for pdwMsgType are used
	/// here, also.
	/// </para>
	/// <para>If there is no cryptographic nesting, CMSG_DATA is returned.</para>
	/// </param>
	/// <param name="pbDecoded">
	/// <para>A pointer to a buffer to receive the decoded message.</para>
	/// <para>
	/// This parameter can be <c>NULL</c> if the decoded message is not required or to set the size of the decoded message for memory
	/// allocation purposes. A decoded message will not be returned if this parameter is <c>NULL</c>. For more information, see
	/// Retrieving Data of Unknown Length.
	/// </para>
	/// </param>
	/// <param name="pcbDecoded">
	/// <para>
	/// A pointer to a variable that specifies the size, in bytes, of the buffer pointed to by the pbDecoded parameter. When the
	/// function returns, this variable contains the size of the decoded message.
	/// </para>
	/// <para>
	/// <c>Note</c> When processing the data returned in the buffer, applications must use the actual size of the data returned. The
	/// actual size can be slightly smaller than the size of the buffer specified on input. (On input, buffer sizes are usually
	/// specified large enough to ensure that the largest possible output data will fit in the buffer.) On output, the variable pointed
	/// to by this parameter is updated to reflect the actual size of the data copied to the buffer.
	/// </para>
	/// </param>
	/// <param name="ppXchgCert">
	/// A pointer to a pointer to a CERT_CONTEXT structure with a certificate that corresponds to the private exchange key needed to
	/// decode the message. This parameter is only set for message types CMSG_ENVELOPED and CMSG_SIGNED_AND_ENVELOPED.
	/// </param>
	/// <param name="ppSignerCert">
	/// A pointer to a pointer to a CERT_CONTEXT structure of the certificate context of the signer. This parameter is only set for
	/// message types CMSG_SIGNED and CMSG_SIGNED_AND_ENVELOPED.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns nonzero ( <c>TRUE</c>).</para>
	/// <para>If the function fails, it returns zero ( <c>FALSE</c>). For extended error information, call GetLastError.</para>
	/// <para>The CryptDecryptMessage, CryptVerifyMessageSignature, or CryptVerifyMessageHash functions can be propagated to this function.</para>
	/// <para>The following error code is most commonly returned by the GetLastError function.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>
	/// If the buffer specified by the pbDecoded parameter is not large enough to hold the returned data, the function sets the
	/// ERROR_MORE_DATA code and stores the required buffer size, in bytes, in the variable pointed to by pcbDecoded.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The dwMsgTypeFlags parameter specifies the set of allowable messages. For example, to decode either SIGNED or ENVELOPED
	/// messages, set dwMsgTypeFlags to CMSG_SIGNED_FLAG | CMSG_ENVELOPED_FLAG. Either or both of the pDecryptPara or pVerifyPara
	/// parameters must be specified.
	/// </para>
	/// <para>
	/// For a successfully decoded or verified message, the certificate context pointers pointed to by ppXchgCert and ppSignerCert are
	/// updated. They must be freed by calling CertFreeCertificateContext. If the function fails, they are set to <c>NULL</c>.
	/// </para>
	/// <para>
	/// The ppXchgCert or ppSignerCert parameters can be set to <c>NULL</c> before the function is called, which indicates that the
	/// caller is not interested in getting the exchange certificate or the signer certificate context.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptdecodemessage BOOL CryptDecodeMessage( DWORD
	// dwMsgTypeFlags, PCRYPT_DECRYPT_MESSAGE_PARA pDecryptPara, PCRYPT_VERIFY_MESSAGE_PARA pVerifyPara, DWORD dwSignerIndex, const BYTE
	// *pbEncodedBlob, DWORD cbEncodedBlob, DWORD dwPrevInnerContentType, DWORD *pdwMsgType, DWORD *pdwInnerContentType, BYTE
	// *pbDecoded, DWORD *pcbDecoded, PCCERT_CONTEXT *ppXchgCert, PCCERT_CONTEXT *ppSignerCert );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "25ffd058-8f75-4ba5-b075-e3efc09f5d9d")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptDecodeMessage(CryptMsgType dwMsgTypeFlags, in CRYPT_DECRYPT_MESSAGE_PARA pDecryptPara, in CRYPT_VERIFY_MESSAGE_PARA pVerifyPara,
		uint dwSignerIndex, [In] IntPtr pbEncodedBlob, uint cbEncodedBlob, CryptMsgType dwPrevInnerContentType, out CryptMsgType pdwMsgType,
		out CryptMsgType pdwInnerContentType, [Out] IntPtr pbDecoded, ref uint pcbDecoded, out SafePCCERT_CONTEXT ppXchgCert, out SafePCCERT_CONTEXT ppSignerCert);

	/// <summary>The <c>CryptDecryptAndVerifyMessageSignature</c> function decrypts a message and verifies its signature.</summary>
	/// <param name="pDecryptPara">A pointer to a CRYPT_DECRYPT_MESSAGE_PARA structure that contains decryption parameters.</param>
	/// <param name="pVerifyPara">A pointer to a CRYPT_VERIFY_MESSAGE_PARA structure that contains verification parameters.</param>
	/// <param name="dwSignerIndex">
	/// Identifies a particular signer of the message. A message can be signed by more than one signer and this function can be called
	/// multiple times changing this parameter to check for several signers. It is set to zero for the first signer. If the function
	/// returns <c>FALSE</c>, and GetLastError returns CRYPT_E_NO_SIGNER, the previous call received the last signer of the message.
	/// </param>
	/// <param name="pbEncryptedBlob">A pointer to the signed, encoded, and encrypted message to be decrypted and verified.</param>
	/// <param name="cbEncryptedBlob">The size, in bytes, of the encrypted message.</param>
	/// <param name="pbDecrypted">
	/// <para>A pointer to a buffer to receive the decrypted message.</para>
	/// <para>
	/// This parameter can be <c>NULL</c> if the decrypted message is not required or to set the size of the decrypted message for
	/// memory allocation purposes. A decrypted message will not be returned if this parameter is <c>NULL</c>. For more information, see
	/// Retrieving Data of Unknown Length.
	/// </para>
	/// </param>
	/// <param name="pcbDecrypted">
	/// <para>
	/// A pointer to a <c>DWORD</c> that specifies the size, in bytes, of the buffer pointed to by the pbDecrypted parameter. When the
	/// function returns, it contains the size of the decrypted message copied to pbDecrypted.
	/// </para>
	/// <para>
	/// <c>Note</c> When processing the data returned in the pbDecrypted buffer, applications must use the actual size of the data
	/// returned. The actual size can be slightly smaller than the size of the buffer specified in pcbDecrypted on input. On output, the
	/// variable pointed to by this parameter is set to reflect the actual size of the data copied to the buffer.
	/// </para>
	/// </param>
	/// <param name="ppXchgCert">
	/// A pointer to a CERT_CONTEXT structure of the certificate that corresponds to the private exchange key needed to decrypt the message.
	/// </param>
	/// <param name="ppSignerCert">A pointer to a CERT_CONTEXT structure of the certificate of the signer.</param>
	/// <returns>
	/// <para>If the function succeeds, the function returns nonzero ( <c>TRUE</c>).</para>
	/// <para>If the function fails, it returns zero ( <c>FALSE</c>). For extended error information, call GetLastError.</para>
	/// <para>
	/// <c>Note</c> Errors from the called functions CryptDecryptMessage and CryptVerifyMessageSignature might be propagated to this function.
	/// </para>
	/// <para>The GetLastError function returns the following error code most often.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>
	/// If the buffer specified by the pbDecrypted parameter is not large enough to hold the returned data, the function sets the
	/// ERROR_MORE_DATA code, and stores the required buffer size, in bytes, in the variable pointed to by pcbDecrypted.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// For a successfully decrypted and verified message, the certificate context pointers pointed to by ppXchgCert and ppSignerCert
	/// are updated. They must be freed by calling CertFreeCertificateContext. If the function fails, they are set to <c>NULL</c>.
	/// </para>
	/// <para>
	/// To indicate that the caller is not interested in the exchange certificate or the signer certificate context, set the ppXchgCert
	/// and ppSignerCert parameters to <c>NULL</c>.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example that uses this function, see Example C Program: Sending and Receiving a Signed and Encrypted Message.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptdecryptandverifymessagesignature BOOL
	// CryptDecryptAndVerifyMessageSignature( PCRYPT_DECRYPT_MESSAGE_PARA pDecryptPara, PCRYPT_VERIFY_MESSAGE_PARA pVerifyPara, DWORD
	// dwSignerIndex, const BYTE *pbEncryptedBlob, DWORD cbEncryptedBlob, BYTE *pbDecrypted, DWORD *pcbDecrypted, PCCERT_CONTEXT
	// *ppXchgCert, PCCERT_CONTEXT *ppSignerCert );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "0864a187-617f-4a21-9809-d2dbbc54ab9c")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptDecryptAndVerifyMessageSignature(in CRYPT_DECRYPT_MESSAGE_PARA pDecryptPara, in CRYPT_VERIFY_MESSAGE_PARA pVerifyPara, uint dwSignerIndex,
		[In] IntPtr pbEncryptedBlob, uint cbEncryptedBlob, [Out] IntPtr pbDecrypted, ref uint pcbDecrypted, out SafePCCERT_CONTEXT ppXchgCert, out SafePCCERT_CONTEXT ppSignerCert);

	/// <summary>The <c>CryptDecryptMessage</c> function decodes and decrypts a message.</summary>
	/// <param name="pDecryptPara">A pointer to a CRYPT_DECRYPT_MESSAGE_PARA structure that contains decryption parameters.</param>
	/// <param name="pbEncryptedBlob">A pointer to a buffer that contains the encoded and encrypted message to be decrypted.</param>
	/// <param name="cbEncryptedBlob">The size, in bytes, of the encoded and encrypted message.</param>
	/// <param name="pbDecrypted">
	/// <para>A pointer to a buffer that receives the decrypted message.</para>
	/// <para>
	/// To set the size of this information for memory allocation purposes, this parameter can be <c>NULL</c>. A decrypted message will
	/// not be returned if this parameter is <c>NULL</c>. For more information, see Retrieving Data of Unknown Length.
	/// </para>
	/// </param>
	/// <param name="pcbDecrypted">
	/// <para>
	/// A pointer to a <c>DWORD</c> that specifies the size, in bytes, of the buffer pointed to by the pbDecrypted parameter. When the
	/// function returns, this variable contains the size, in bytes, of the decrypted message copied to pbDecrypted.
	/// </para>
	/// <para>
	/// <c>Note</c> When processing the data returned in the pbDecrypted buffer, applications must use the actual size of the data
	/// returned. The actual size can be slightly smaller than the size of the buffer specified in pcbDecrypted on input. On input,
	/// buffer sizes are usually specified large enough to ensure that the largest possible output data will fit in the buffer. On
	/// output, the <c>DWORD</c> is updated to the actual size of the data copied to the buffer.
	/// </para>
	/// </param>
	/// <param name="ppXchgCert">
	/// A pointer to a CERT_CONTEXT structure of a certificate that corresponds to the private exchange key needed to decrypt the
	/// message. To indicate that the function should not return the certificate context used to decrypt, set this parameter to <c>NULL</c>.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns nonzero ( <c>TRUE</c>).</para>
	/// <para>If the function fails, it returns zero ( <c>FALSE</c>). For extended error information, call GetLastError.</para>
	/// <para><c>Note</c> Errors from calls to CryptImportKey and CryptDecrypt might be propagated to this function.</para>
	/// <para>The GetLastError function returns the following error codes most often.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>
	/// If the buffer specified by the pbDecrypted parameter is not large enough to hold the returned data, the function sets the
	/// ERROR_MORE_DATA code, and stores the required buffer size, in bytes, in the variable pointed to by pcbDecrypted.
	/// </term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>
	/// Invalid message and certificate encoding types. Currently only PKCS_7_ASN_ENCODING and X509_ASN_ENCODING_TYPE are supported.
	/// Invalid cbSize in *pDecryptPara.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_E_UNEXPECTED_MSG_TYPE</term>
	/// <term>Not an enveloped cryptographic message.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_ALGID</term>
	/// <term>The message was encrypted by using an unknown or unsupported algorithm.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_E_NO_DECRYPT_CERT</term>
	/// <term>No certificate was found having a private key property to use for decrypting.</term>
	/// </item>
	/// </list>
	/// <para>
	/// If the function fails, GetLastError may return an Abstract Syntax Notation One (ASN.1) encoding/decoding error. For information
	/// about these errors, see ASN.1 Encoding/Decoding Return Values.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// When <c>NULL</c> is passed for pbDecrypted, and pcbDecrypted is not <c>NULL</c>, <c>NULL</c> is returned for the address passed
	/// in ppXchgCert; otherwise, a pointer to a CERT_CONTEXT is returned. For a successfully decrypted message, this pointer to a
	/// <c>CERT_CONTEXT</c> points to the certificate context used to decrypt the message. It must be freed by calling
	/// CertFreeCertificateContext. If the function fails, the value at ppXchgCert is set to <c>NULL</c>.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example that uses this function, see Example C Program: Using CryptEncryptMessage and CryptDecryptMessage.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptdecryptmessage BOOL CryptDecryptMessage(
	// PCRYPT_DECRYPT_MESSAGE_PARA pDecryptPara, const BYTE *pbEncryptedBlob, DWORD cbEncryptedBlob, BYTE *pbDecrypted, DWORD
	// *pcbDecrypted, PCCERT_CONTEXT *ppXchgCert );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "e540b816-64e1-4c78-9020-2b221e813acc")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptDecryptMessage(in CRYPT_DECRYPT_MESSAGE_PARA pDecryptPara, [In] IntPtr pbEncryptedBlob, uint cbEncryptedBlob, [Out] IntPtr pbDecrypted, ref uint pcbDecrypted, out SafePCCERT_CONTEXT ppXchgCert);

	/// <summary>The <c>CryptDecryptMessage</c> function decodes and decrypts a message.</summary>
	/// <param name="pDecryptPara">A pointer to a CRYPT_DECRYPT_MESSAGE_PARA structure that contains decryption parameters.</param>
	/// <param name="pbEncryptedBlob">A pointer to a buffer that contains the encoded and encrypted message to be decrypted.</param>
	/// <param name="cbEncryptedBlob">The size, in bytes, of the encoded and encrypted message.</param>
	/// <param name="pbDecrypted">
	/// <para>A pointer to a buffer that receives the decrypted message.</para>
	/// <para>
	/// To set the size of this information for memory allocation purposes, this parameter can be <c>NULL</c>. A decrypted message will
	/// not be returned if this parameter is <c>NULL</c>. For more information, see Retrieving Data of Unknown Length.
	/// </para>
	/// </param>
	/// <param name="pcbDecrypted">
	/// <para>
	/// A pointer to a <c>DWORD</c> that specifies the size, in bytes, of the buffer pointed to by the pbDecrypted parameter. When the
	/// function returns, this variable contains the size, in bytes, of the decrypted message copied to pbDecrypted.
	/// </para>
	/// <para>
	/// <c>Note</c> When processing the data returned in the pbDecrypted buffer, applications must use the actual size of the data
	/// returned. The actual size can be slightly smaller than the size of the buffer specified in pcbDecrypted on input. On input,
	/// buffer sizes are usually specified large enough to ensure that the largest possible output data will fit in the buffer. On
	/// output, the <c>DWORD</c> is updated to the actual size of the data copied to the buffer.
	/// </para>
	/// </param>
	/// <param name="ppXchgCert">
	/// A pointer to a CERT_CONTEXT structure of a certificate that corresponds to the private exchange key needed to decrypt the
	/// message. To indicate that the function should not return the certificate context used to decrypt, set this parameter to <c>NULL</c>.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns nonzero ( <c>TRUE</c>).</para>
	/// <para>If the function fails, it returns zero ( <c>FALSE</c>). For extended error information, call GetLastError.</para>
	/// <para><c>Note</c> Errors from calls to CryptImportKey and CryptDecrypt might be propagated to this function.</para>
	/// <para>The GetLastError function returns the following error codes most often.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>
	/// If the buffer specified by the pbDecrypted parameter is not large enough to hold the returned data, the function sets the
	/// ERROR_MORE_DATA code, and stores the required buffer size, in bytes, in the variable pointed to by pcbDecrypted.
	/// </term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>
	/// Invalid message and certificate encoding types. Currently only PKCS_7_ASN_ENCODING and X509_ASN_ENCODING_TYPE are supported.
	/// Invalid cbSize in *pDecryptPara.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_E_UNEXPECTED_MSG_TYPE</term>
	/// <term>Not an enveloped cryptographic message.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_ALGID</term>
	/// <term>The message was encrypted by using an unknown or unsupported algorithm.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_E_NO_DECRYPT_CERT</term>
	/// <term>No certificate was found having a private key property to use for decrypting.</term>
	/// </item>
	/// </list>
	/// <para>
	/// If the function fails, GetLastError may return an Abstract Syntax Notation One (ASN.1) encoding/decoding error. For information
	/// about these errors, see ASN.1 Encoding/Decoding Return Values.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// When <c>NULL</c> is passed for pbDecrypted, and pcbDecrypted is not <c>NULL</c>, <c>NULL</c> is returned for the address passed
	/// in ppXchgCert; otherwise, a pointer to a CERT_CONTEXT is returned. For a successfully decrypted message, this pointer to a
	/// <c>CERT_CONTEXT</c> points to the certificate context used to decrypt the message. It must be freed by calling
	/// CertFreeCertificateContext. If the function fails, the value at ppXchgCert is set to <c>NULL</c>.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example that uses this function, see Example C Program: Using CryptEncryptMessage and CryptDecryptMessage.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptdecryptmessage BOOL CryptDecryptMessage(
	// PCRYPT_DECRYPT_MESSAGE_PARA pDecryptPara, const BYTE *pbEncryptedBlob, DWORD cbEncryptedBlob, BYTE *pbDecrypted, DWORD
	// *pcbDecrypted, PCCERT_CONTEXT *ppXchgCert );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "e540b816-64e1-4c78-9020-2b221e813acc")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptDecryptMessage(in CRYPT_DECRYPT_MESSAGE_PARA pDecryptPara, [In] IntPtr pbEncryptedBlob, uint cbEncryptedBlob, [Out] IntPtr pbDecrypted, ref uint pcbDecrypted, IntPtr ppXchgCert = default);

	/// <summary>The <c>CryptEncryptMessage</c> function encrypts and encodes a message.</summary>
	/// <param name="pEncryptPara">
	/// <para>A pointer to a CRYPT_ENCRYPT_MESSAGE_PARA structure that contains the encryption parameters.</para>
	/// <para>
	/// The <c>CryptEncryptMessage</c> function does not support the SHA2 OIDs, <c>szOID_DH_SINGLE_PASS_STDDH_SHA256_KDF</c> and <c>szOID_DH_SINGLE_PASS_STDDH_SHA384_KDF</c>.
	/// </para>
	/// </param>
	/// <param name="cRecipientCert">Number of elements in the rgpRecipientCert array.</param>
	/// <param name="rgpRecipientCert">
	/// Array of pointers to CERT_CONTEXT structures that contain the certificates of intended recipients of the message.
	/// </param>
	/// <param name="pbToBeEncrypted">A pointer to a buffer that contains the message that is to be encrypted.</param>
	/// <param name="cbToBeEncrypted">The size, in bytes, of the message that is to be encrypted.</param>
	/// <param name="pbEncryptedBlob">
	/// <para>A pointer to BLOB that contains a buffer that receives the encrypted and encoded message.</para>
	/// <para>
	/// To set the size of this information for memory allocation purposes, this parameter can be <c>NULL</c>. For more information, see
	/// Retrieving Data of Unknown Length.
	/// </para>
	/// </param>
	/// <param name="pcbEncryptedBlob">
	/// <para>
	/// A pointer to a <c>DWORD</c> that specifies the size, in bytes, of the buffer pointed to by the pbEncryptedBlob parameter. When
	/// the function returns, this variable contains the size, in bytes, of the encrypted and encoded message copied to pbEncryptedBlob.
	/// </para>
	/// <para>
	/// <c>Note</c> When processing the data returned in the buffer of the pbEncryptedBlob, applications need to use the actual size of
	/// the data returned. The actual size can be slightly smaller than the size of the buffer specified on input. (On input, buffer
	/// sizes are usually specified large enough to ensure that the largest possible output data will fit in the buffer.) On output, the
	/// variable pointed to by this parameter is updated to reflect the actual size of the data copied to the buffer.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns nonzero ( <c>TRUE</c>).</para>
	/// <para>If the function fails, it returns zero ( <c>FALSE</c>). For extended error information, call GetLastError.</para>
	/// <para>
	/// <c>Note</c> Errors from calls to CryptGenKey, CryptEncrypt, CryptImportKey, and CryptExportKey can be propagated to this function.
	/// </para>
	/// <para>The GetLastError function returns the following error codes most often.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>
	/// If the buffer specified by the pbEncryptedBlob parameter is not large enough to hold the returned data, the function sets the
	/// ERROR_MORE_DATA code and stores the required buffer size, in bytes, in the variable pointed to by pcbEncryptedBlob.
	/// </term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>
	/// The message encoding type is not valid. Currently only PKCS_7_ASN_ENCODING is supported. The cbSize in *pEncryptPara is not valid.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// If the function fails, GetLastError may return an Abstract Syntax Notation One (ASN.1) encoding/decoding error. For information
	/// about these errors, see ASN.1 Encoding/Decoding Return Values.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptencryptmessage BOOL CryptEncryptMessage(
	// PCRYPT_ENCRYPT_MESSAGE_PARA pEncryptPara, DWORD cRecipientCert, PCCERT_CONTEXT [] rgpRecipientCert, const BYTE *pbToBeEncrypted,
	// DWORD cbToBeEncrypted, BYTE *pbEncryptedBlob, DWORD *pcbEncryptedBlob );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "927f2e9a-96cf-4744-bd57-420b5034d28d")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptEncryptMessage(in CRYPT_ENCRYPT_MESSAGE_PARA pEncryptPara, uint cRecipientCert, [In, MarshalAs(UnmanagedType.LPArray)] PCCERT_CONTEXT[] rgpRecipientCert,
		[In] IntPtr pbToBeEncrypted, uint cbToBeEncrypted, [Out] IntPtr pbEncryptedBlob, ref uint pcbEncryptedBlob);

	/// <summary>
	/// The <c>CryptGetMessageCertificates</c> function returns the handle of an open certificate store containing the message's
	/// certificates and CRLs. This function calls CertOpenStore using provider type CERT_STORE_PROV_PKCS7 as its lpszStoreProvider parameter.
	/// </summary>
	/// <param name="dwMsgAndCertEncodingType">
	/// <para>
	/// Specifies the encoding type used. It is always acceptable to specify both the certificate and message encoding types by
	/// combining them with a bitwise- <c>OR</c> operation as shown in the following example:
	/// </para>
	/// <para>X509_ASN_ENCODING | PKCS_7_ASN_ENCODING</para>
	/// <para>Currently defined encoding types are:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>X509_ASN_ENCODING</term>
	/// </item>
	/// <item>
	/// <term>PKCS_7_ASN_ENCODING</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="hCryptProv">
	/// <para>This parameter is not used and should be set to <c>NULL</c>.</para>
	/// <para>
	/// <c>Windows Server 2003 and Windows XP:</c> Handle of the CSP passed to CertOpenStore. For more information, see
	/// CertOpenStore.Unless there is a strong reason for passing a specific cryptographic provider in hCryptProv, pass zero to cause
	/// the default RSA or DSS provider to be acquired.
	/// </para>
	/// <para>This parameter's data type is <c>HCRYPTPROV</c>.</para>
	/// </param>
	/// <param name="dwFlags">Flags passed to CertOpenStore. For more information, see CertOpenStore.</param>
	/// <param name="pbSignedBlob">A pointer to a buffered CRYPT_INTEGER_BLOB structure that contains the signed message.</param>
	/// <param name="cbSignedBlob">The size, in bytes, of the signed message.</param>
	/// <returns>
	/// <para>Returns the certificate store containing the message's certificates and CRLs. For an error, <c>NULL</c> is returned.</para>
	/// <para>The following lists the error code most commonly returned by the GetLastError function.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>Invalid message and certificate encoding types. Currently only PKCS_7_ASN_ENCODING and X509_ASN_ENCODING are supported.</term>
	/// </item>
	/// </list>
	/// <para>
	/// If the function fails, GetLastError may return an Abstract Syntax Notation One (ASN.1) encoding/decoding error. For information
	/// about these errors, see ASN.1 Encoding/Decoding Return Values.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>Use GetLastError to determine the reason for any errors.</para>
	/// <para>Examples</para>
	/// <para>For an example that uses this function, see Example C Program: Setting and Getting Certificate Store Properties.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptgetmessagecertificates HCERTSTORE
	// CryptGetMessageCertificates( DWORD dwMsgAndCertEncodingType, HCRYPTPROV_LEGACY hCryptProv, DWORD dwFlags, const BYTE
	// *pbSignedBlob, DWORD cbSignedBlob );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "d890f91f-bb45-463b-b7c0-56acc9367571")]
	public static extern SafeHCERTSTORE CryptGetMessageCertificates(CertEncodingType dwMsgAndCertEncodingType, [Optional] HCRYPTPROV hCryptProv, CertStoreFlags dwFlags, [In] IntPtr pbSignedBlob, uint cbSignedBlob);

	/// <summary>The <c>CryptGetMessageSignerCount</c> function returns the number of signers of a signed message.</summary>
	/// <param name="dwMsgEncodingType">
	/// <para>
	/// Specifies the encoding type used. It is always acceptable to specify both the certificate and message encoding types by
	/// combining them with a bitwise- <c>OR</c> operation as shown in the following example:
	/// </para>
	/// <para>X509_ASN_ENCODING | PKCS_7_ASN_ENCODING</para>
	/// <para>Currently defined encoding types are:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>X509_ASN_ENCODING</term>
	/// </item>
	/// <item>
	/// <term>PKCS_7_ASN_ENCODING</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pbSignedBlob">A pointer to a buffer containing the signed message.</param>
	/// <param name="cbSignedBlob">The size, in bytes, of the signed message.</param>
	/// <returns>
	/// <para>Returns the number of signers of a signed message, zero when there are no signers, and minus one (–1) for an error.</para>
	/// <para>For extended error information, call GetLastError. The following error code is most commonly returned.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>Invalid message encoding type. Currently only PKCS_7_ASN_ENCODING is supported.</term>
	/// </item>
	/// </list>
	/// <para>
	/// If the function fails, GetLastError may return an Abstract Syntax Notation One (ASN.1) encoding/decoding error. For information
	/// about these errors, see ASN.1 Encoding/Decoding Return Values.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptgetmessagesignercount LONG
	// CryptGetMessageSignerCount( DWORD dwMsgEncodingType, const BYTE *pbSignedBlob, DWORD cbSignedBlob );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "d18bda8b-b333-4b1e-8ed5-f8eff04b3168")]
	public static extern int CryptGetMessageSignerCount(CertEncodingType dwMsgEncodingType, [In] IntPtr pbSignedBlob, uint cbSignedBlob);

	/// <summary>The <c>CryptHashMessage</c> function creates a hash of the message.</summary>
	/// <param name="pHashPara">A pointer to a CRYPT_HASH_MESSAGE_PARA structure that contains the hash parameters.</param>
	/// <param name="fDetachedHash">
	/// If this parameter is set to <c>TRUE</c>, only pbComputedHash is encoded in pbHashedBlob. Otherwise, both rgpbToBeHashed and
	/// pbComputedHash are encoded.
	/// </param>
	/// <param name="cToBeHashed">
	/// The number of array elements in rgpbToBeHashed and rgcbToBeHashed. This parameter can only be one unless fDetachedHash is set to <c>TRUE</c>.
	/// </param>
	/// <param name="rgpbToBeHashed">An array of pointers to buffers that contain the contents to be hashed.</param>
	/// <param name="rgcbToBeHashed">An array of sizes, in bytes, of the buffers pointed to by rgpbToBeHashed.</param>
	/// <param name="pbHashedBlob">
	/// <para>A pointer to a buffer to receive the hashed message encoded for transmission.</para>
	/// <para>
	/// This parameter can be <c>NULL</c> if the hashed message is not needed for additional processing or to set the size of the hashed
	/// message for memory allocation purposes. A hashed message will not be returned if this parameter is <c>NULL</c>. For more
	/// information, see Retrieving Data of Unknown Length.
	/// </para>
	/// </param>
	/// <param name="pcbHashedBlob">
	/// <para>
	/// A pointer to a <c>DWORD</c> that specifies the size, in bytes, of the buffer pointed to by the pbHashedBlob parameter. When the
	/// function returns, this variable contains the size, in bytes, of the decrypted message copied to pbHashedBlob. This parameter
	/// must be the address of a <c>DWORD</c> and not <c>NULL</c> or the length of the buffer will not be returned.
	/// </para>
	/// <para>
	/// <c>Note</c> When processing the data returned, applications must use the actual size of the data returned. The actual size can
	/// be slightly smaller than the size of the buffer specified on input. On input, buffer sizes are usually specified large enough to
	/// ensure that the largest possible output data will fit in the buffer. On output, the variable pointed to by this parameter is
	/// updated to reflect the actual size of the data copied to the buffer.
	/// </para>
	/// </param>
	/// <param name="pbComputedHash">
	/// A pointer to a buffer to receive the newly created hash value. This parameter can be <c>NULL</c> if the newly created hash is
	/// not needed for additional processing, or to set the size of the hash for memory allocation purposes. For more information, see
	/// Retrieving Data of Unknown Length.
	/// </param>
	/// <param name="pcbComputedHash">
	/// <para>
	/// A pointer to a <c>DWORD</c> that specifies the size, in bytes, of the buffer pointed to by the pbComputedHash parameter. When
	/// the function returns, this <c>DWORD</c> contains the size, in bytes, of the newly created hash that was copied to pbComputedHash.
	/// </para>
	/// <para>
	/// <c>Note</c> When processing the data returned, applications must use the actual size of the data returned. The actual size can
	/// be slightly smaller than the size of the buffer specified on input. On input, buffer sizes are usually specified large enough to
	/// ensure that the largest possible output data will fit in the buffer. On output, the variable pointed to by this parameter is
	/// updated to reflect the actual size of the data copied to the buffer.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns nonzero ( <c>TRUE</c>).</para>
	/// <para>If the function fails, it returns zero ( <c>FALSE</c>). For extended error information, call GetLastError.</para>
	/// <para>
	/// <c>Note</c> Errors from the called functions CryptCreateHash, CryptHashData, and CryptGetHashParam might be propagated to this function.
	/// </para>
	/// <para>The GetLastError function returns the following error codes most often.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>
	/// The message encoding type is not valid. Currently only PKCS_7_ASN_ENCODING is supported. The cbSize in *pHashPara is not valid.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>
	/// If the buffer specified by the pbHashedBlob parameter is not large enough to hold the returned data, the function sets the
	/// ERROR_MORE_DATA code and stores the required buffer size, in bytes, into the variable pointed to by pbHashedBlob.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// If the function fails, GetLastError may return an Abstract Syntax Notation One (ASN.1) encoding/decoding error. For information
	/// about these errors, see ASN.1 Encoding/Decoding Return Values.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-crypthashmessage BOOL CryptHashMessage(
	// PCRYPT_HASH_MESSAGE_PARA pHashPara, BOOL fDetachedHash, DWORD cToBeHashed, const BYTE * [] rgpbToBeHashed, DWORD []
	// rgcbToBeHashed, BYTE *pbHashedBlob, DWORD *pcbHashedBlob, BYTE *pbComputedHash, DWORD *pcbComputedHash );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "85a04c01-fd7c-4d87-b6e1-a0f2aea45d16")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptHashMessage(in CRYPT_HASH_MESSAGE_PARA pHashPara, [MarshalAs(UnmanagedType.Bool)] bool fDetachedHash, uint cToBeHashed,
		[In] IntPtr[] rgpbToBeHashed, [In] uint[] rgcbToBeHashed, [Out] IntPtr pbHashedBlob, ref uint pcbHashedBlob, [Out] IntPtr pbComputedHash, ref uint pcbComputedHash);

	/// <summary>
	/// The <c>CryptMsgCalculateEncodedLength</c> function calculates the maximum number of bytes needed for an encoded cryptographic
	/// message given the message type, encoding parameters, and total length of the data to be encoded. Note that the result will
	/// always be greater than or equal to the actual number of bytes needed.
	/// </summary>
	/// <param name="dwMsgEncodingType">
	/// <para>
	/// Specifies the encoding type used. It is always acceptable to specify both the certificate and message encoding types by
	/// combining them with a bitwise- <c>OR</c> operation as shown in the following example:
	/// </para>
	/// <para>X509_ASN_ENCODING | PKCS_7_ASN_ENCODING</para>
	/// <para>Currently defined encoding types are:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>X509_ASN_ENCODING</term>
	/// </item>
	/// <item>
	/// <term>PKCS_7_ASN_ENCODING</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwFlags">
	/// <para>Currently defined flags are shown in the following table.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CMSG_BARE_CONTENT_FLAG</term>
	/// <term>
	/// Indicates that streamed output will not have an outer ContentInfo wrapper (as defined by PKCS #7). This makes it suitable to be
	/// streamed into an enclosing message.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CMSG_DETACHED_FLAG</term>
	/// <term>Indicates that there is detached data being supplied for the subsequent calls to CryptMsgUpdate.</term>
	/// </item>
	/// <item>
	/// <term>CMSG_CONTENTS_OCTETS_FLAG</term>
	/// <term>
	/// Used to calculate the size of a DER encoding of a message to be nested inside an enveloped message. This is particularly useful
	/// when streaming is being performed.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CMSG_CMS_ENCAPSULATED_CONTENT_FLAG</term>
	/// <term>
	/// Non-Data type inner content is encapsulated within an OCTET STRING. This flag is applicable for both Signed and Enveloped messages.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwMsgType">
	/// <para>Currently defined message types are shown in the following table.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CMSG_DATA</term>
	/// <term>An octet (BYTE) string.</term>
	/// </item>
	/// <item>
	/// <term>CMSG_SIGNED</term>
	/// <term>CMSG_SIGNED_ENCODE_INFO</term>
	/// </item>
	/// <item>
	/// <term>CMSG_ENVELOPED</term>
	/// <term>CMSG_ENVELOPED_ENCODE_INFO</term>
	/// </item>
	/// <item>
	/// <term>CMSG_SIGNED_AND_ENVELOPED</term>
	/// <term>Not implemented.</term>
	/// </item>
	/// <item>
	/// <term>CMSG_HASHED</term>
	/// <term>CMSG_HASHED_ENCODE_INFO</term>
	/// </item>
	/// <item>
	/// <term>CMSG_ENCRYPTED</term>
	/// <term>Not implemented.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pvMsgEncodeInfo">
	/// A pointer to the data to be encoded. The type of data pointed to depends on the value of dwMsgType. For details, see the
	/// dwMsgType table.
	/// </param>
	/// <param name="pszInnerContentObjID">
	/// <para>
	/// When calling <c>CryptMsgCalculateEncodedLength</c> with data provided to CryptMsgUpdate already encoded, the appropriate object
	/// identifier is passed in pszInnerContentObjID. If pszInnerContentObjID is <c>NULL</c>, the inner content type is assumed not to
	/// have been previously encoded, and is encoded as an octet string and given the type CMSG_DATA.
	/// </para>
	/// <para>When streaming is being used, pszInnerContentObjID must be either <c>NULL</c> or szOID_RSA_data.</para>
	/// <para>The following algorithm object identifiers are commonly used:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>szOID_RSA_data</term>
	/// </item>
	/// <item>
	/// <term>szOID_RSA_signedData</term>
	/// </item>
	/// <item>
	/// <term>szOID_RSA_envelopedData</term>
	/// </item>
	/// <item>
	/// <term>szOID_RSA_signEnvData</term>
	/// </item>
	/// <item>
	/// <term>szOID_RSA_digestedData</term>
	/// </item>
	/// <item>
	/// <term>szOID_RSA_encryptedData</term>
	/// </item>
	/// <item>
	/// <term>SPC_INDIRECT_DATA_OBJID</term>
	/// </item>
	/// </list>
	/// <para>
	/// A user can define new inner content usage. The user must ensure that the sender and receiver of the message agree upon the
	/// semantics associated with the object identifier.
	/// </para>
	/// </param>
	/// <param name="cbData">The size, in bytes, of the content.</param>
	/// <returns>
	/// <para>
	/// Returns the required length for an encoded cryptographic message. This length might not be the exact length but it will not be
	/// less than the required length. Zero is returned if the function fails.
	/// </para>
	/// <para>
	/// To retrieve extended error information, use the GetLastError function. The following table lists the error codes most commonly returned.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_E_INVALID_MSG_TYPE</term>
	/// <term>The message type is not valid.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_E_UNKNOWN_ALGO</term>
	/// <term>The cryptographic algorithm is unknown.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One or more arguments are not valid.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptmsgcalculateencodedlength DWORD
	// CryptMsgCalculateEncodedLength( DWORD dwMsgEncodingType, DWORD dwFlags, DWORD dwMsgType, void const *pvMsgEncodeInfo, LPSTR
	// pszInnerContentObjID, DWORD cbData );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "1c12003a-c2f3-4069-8bd6-b8f2875b0c98")]
	public static extern uint CryptMsgCalculateEncodedLength(CertEncodingType dwMsgEncodingType, CryptMsgFlags dwFlags, CryptMsgType dwMsgType, [In] IntPtr pvMsgEncodeInfo,
		[Optional] SafeOID pszInnerContentObjID, uint cbData);

	/// <summary>
	/// The <c>CryptMsgClose</c> function closes a cryptographic message handle. At each call to this function, the reference count on
	/// the message is reduced by one. When the reference count reaches zero, the message is fully released.
	/// </summary>
	/// <param name="hCryptMsg">Handle of the cryptographic message to be closed.</param>
	/// <returns>
	/// <para>If the function succeeds, the function returns nonzero ( <c>TRUE</c>).</para>
	/// <para>If the function fails, it returns zero ( <c>FALSE</c>). For extended error information, call GetLastError.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptmsgclose BOOL CryptMsgClose( HCRYPTMSG hCryptMsg );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "2478dd60-233a-4ef3-86e9-62d2a59ab28a")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptMsgClose(HCRYPTMSG hCryptMsg);

	/// <summary>
	/// <para>
	/// The <c>CryptMsgControl</c> function performs a control operation after a message has been decoded by a final call to the
	/// CryptMsgUpdate function. The control operations provided by this function are used for decryption, signature and hash
	/// verification, and the addition and deletion of certificates, certificate revocation lists (CRLs), signers, and unauthenticated attributes.
	/// </para>
	/// <para>
	/// Important changes that affect the handling of enveloped messages have been made to CryptoAPI to support Secure/Multipurpose
	/// Internet Mail Extensions (S/MIME) email interoperability. For more information, see the Remarks for the CryptMsgOpenToEncode function.
	/// </para>
	/// </summary>
	/// <param name="hCryptMsg">A handle of a cryptographic message for which a control is to be applied.</param>
	/// <param name="dwFlags">
	/// <para>The following value is defined when the dwCtrlType parameter is one of the following:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>CMSG_CTRL_DECRYPT</term>
	/// </item>
	/// <item>
	/// <term>CMSG_CTRL_KEY_TRANS_DECRYPT</term>
	/// </item>
	/// <item>
	/// <term>CMSG_CTRL_KEY_AGREE_DECRYPT</term>
	/// </item>
	/// <item>
	/// <term>CMSG_CTRL_MAIL_LIST_DECRYPT</term>
	/// </item>
	/// </list>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CMSG_CRYPT_RELEASE_CONTEXT_FLAG</term>
	/// <term>
	/// The handle to the cryptographic provider is released on the final call to the CryptMsgClose function. This handle is not
	/// released if the CryptMsgControl function fails.
	/// </term>
	/// </item>
	/// </list>
	/// <para>If the dwCtrlType parameter does not specify a decrypt operation, set this value to zero.</para>
	/// </param>
	/// <param name="dwCtrlType">
	/// <para>
	/// The type of operation to be performed. Currently defined message control types and the type of structure that should be passed
	/// to the pvCtrlPara parameter are shown in the following table.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CMSG_CTRL_ADD_ATTR_CERT 14 (0xE)</term>
	/// <term>A BLOB that contains the encoded bytes of attribute certificate.</term>
	/// </item>
	/// <item>
	/// <term>CMSG_CTRL_ADD_CERT 10 (0xA)</term>
	/// <term>A CRYPT_INTEGER_BLOB structure that contains the encoded bytes of the certificate to be added to the message.</term>
	/// </item>
	/// <item>
	/// <term>CMSG_CTRL_ADD_CMS_SIGNER_INFO 20 (0x14)</term>
	/// <term>
	/// A CMSG_CMS_SIGNER_INFO structure that contains signer information. This operation differs from CMSG_CTRL_ADD_SIGNER because the
	/// signer information contains the signature.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CMSG_CTRL_ADD_CRL 12 (0xC)</term>
	/// <term>A BLOB that contains the encoded bytes of the CRL to be added to the message.</term>
	/// </item>
	/// <item>
	/// <term>CMSG_CTRL_ADD_SIGNER 6 (0x6)</term>
	/// <term>A CMSG_SIGNER_ENCODE_INFO structure that contains the signer information to be added to the message.</term>
	/// </item>
	/// <item>
	/// <term>CMSG_CTRL_ADD_SIGNER_UNAUTH_ATTR 8 (0x8)</term>
	/// <term>
	/// A CMSG_CTRL_ADD_SIGNER_UNAUTH_ATTR_PARA structure that contains the index of the signer and a BLOB that contains the
	/// unauthenticated attribute information to be added to the message.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CMSG_CTRL_DECRYPT 2 (0x2)</term>
	/// <term>
	/// A CMSG_CTRL_DECRYPT_PARA structure used to decrypt the message for the specified key transport recipient. This value is
	/// applicable to RSA recipients. This operation specifies that the CryptMsgControl function search the recipient index to obtain
	/// the key transport recipient information. If the function fails, GetLastError will return CRYPT_E_INVALID_INDEX if no key
	/// transport recipient is found.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CMSG_CTRL_DEL_ATTR_CERT 15 (0xF)</term>
	/// <term>The index of the attribute certificate to be removed.</term>
	/// </item>
	/// <item>
	/// <term>CMSG_CTRL_DEL_CERT 11 (0xB)</term>
	/// <term>The index of the certificate to be deleted from the message.</term>
	/// </item>
	/// <item>
	/// <term>CMSG_CTRL_DEL_CRL 13 (0xD)</term>
	/// <term>The index of the CRL to be deleted from the message.</term>
	/// </item>
	/// <item>
	/// <term>CMSG_CTRL_DEL_SIGNER 7 (0x7)</term>
	/// <term>The index of the signer to be deleted.</term>
	/// </item>
	/// <item>
	/// <term>CMSG_CTRL_DEL_SIGNER_UNAUTH_ATTR 9 (0x9)</term>
	/// <term>
	/// A CMSG_CTRL_DEL_SIGNER_UNAUTH_ATTR_PARA structure that contains an index that specifies the signer and the index that specifies
	/// the signer's unauthenticated attribute to be deleted.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CMSG_CTRL_ENABLE_STRONG_SIGNATURE 21 (0x15)</term>
	/// <term>
	/// A CERT_STRONG_SIGN_PARA structure used to perform strong signature checking. To check for a strong signature, specify this
	/// control type before calling CryptMsgGetAndVerifySigner or before calling CryptMsgControl with the following control types set:
	/// After the signature is successfully verified, this function checks for a strong signature. If the signature is not strong, the
	/// operation will fail and the GetLastError value will be set to NTE_BAD_ALGID.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CMSG_CTRL_KEY_AGREE_DECRYPT 17 (0x11)</term>
	/// <term>
	/// A CMSG_CTRL_KEY_AGREE_DECRYPT_PARA structure used to decrypt the message for the specified key agreement session key. Key
	/// agreement is used with Diffie-Hellman encryption/decryption.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CMSG_CTRL_KEY_TRANS_DECRYPT 16 (0x10)</term>
	/// <term>
	/// A CMSG_CTRL_KEY_TRANS_DECRYPT_PARA structure used to decrypt the message for the specified key transport recipient. Key
	/// transport is used with RSA encryption/decryption.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CMSG_CTRL_MAIL_LIST_DECRYPT 18 (0x12)</term>
	/// <term>
	/// A CMSG_CTRL_MAIL_LIST_DECRYPT_PARA structure used to decrypt the message for the specified recipient using a previously
	/// distributed key-encryption key (KEK).
	/// </term>
	/// </item>
	/// <item>
	/// <term>CMSG_CTRL_VERIFY_HASH 5 (0x5)</term>
	/// <term>This value is not used.</term>
	/// </item>
	/// <item>
	/// <term>CMSG_CTRL_VERIFY_SIGNATURE 1 (0x1)</term>
	/// <term>A CERT_INFO structure that identifies the signer of the message whose signature is to be verified.</term>
	/// </item>
	/// <item>
	/// <term>CMSG_CTRL_VERIFY_SIGNATURE_EX 19 (0x13)</term>
	/// <term>
	/// A CMSG_CTRL_VERIFY_SIGNATURE_EX_PARA structure that specifies the signer index and public key to verify the message signature.
	/// The signer public key can be a CERT_PUBLIC_KEY_INFO structure, a certificate context, or a certificate chain context.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pvCtrlPara">
	/// <para>A pointer to a structure determined by the value of dwCtrlType.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>dwCtrlType value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>
	/// CMSG_CTRL_DECRYPT, CMSG_CTRL_KEY_TRANS_DECRYPT, CMSG_CTRL_KEY_AGREE_DECRYPT, or CMSG_CTRL_MAIL_LIST_DECRYPT, and the streamed
	/// enveloped message is being decoded
	/// </term>
	/// <term>
	/// Decoding will be done as if the streamed content were being decrypted. If any encrypted streamed content has accumulated prior
	/// to this call, some or all of the plaintext that results from the decryption of the cipher text is passed back to the application
	/// through the callback function specified in the call to the CryptMsgOpenToDecode function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CMSG_CTRL_VERIFY_HASH</term>
	/// <term>The hash computed from the content of the message is compared against the hash contained in the message.</term>
	/// </item>
	/// <item>
	/// <term>CMSG_CTRL_ADD_SIGNER</term>
	/// <term>pvCtrlPara points to a CMSG_SIGNER_ENCODE_INFO structure that contains the signer information to be added to the message.</term>
	/// </item>
	/// <item>
	/// <term>CMSG_CTRL_DEL_SIGNER</term>
	/// <term>
	/// After a deletion is made, any other signer indices in use for this message are no longer valid and must be reacquired by calling
	/// the CryptMsgGetParam function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CMSG_CTRL_DEL_SIGNER_UNAUTH_ATTR</term>
	/// <term>
	/// After a deletion is made, any other unauthenticated attribute indices in use for this signer are no longer valid and must be
	/// reacquired by calling the CryptMsgGetParam function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CMSG_CTRL_DEL_CERT</term>
	/// <term>
	/// After a deletion is made, any other certificate indices in use for this message are no longer valid and must be reacquired by
	/// calling the CryptMsgGetParam function.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CMSG_CTRL_DEL_CRL</term>
	/// <term>
	/// After a deletion is made, any other CRL indices in use for this message are no longer valid and will need to be reacquired by
	/// calling the CryptMsgGetParam function.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero.</para>
	/// <para>
	/// If the function fails, the return value is zero and the GetLastError function returns an Abstract Syntax Notation One (ASN.1)
	/// encoding/decoding error. For information about these errors, see ASN.1 Encoding/Decoding Return Values.
	/// </para>
	/// <para>
	/// When a streamed, enveloped message is being decoded, errors encountered in the application-defined callback function specified
	/// by the pStreamInfo parameter of the CryptMsgOpenToDecode function might be propagated to the <c>CryptMsgControl</c> function. If
	/// this happens, the SetLastError function is not called by the <c>CryptMsgControl</c> function after the callback function
	/// returns. This preserves any errors encountered under the control of the application. It is the responsibility of the callback
	/// function (or one of the APIs that it calls) to call the <c>SetLastError</c> function if an error occurs while the application is
	/// processing the streamed data.
	/// </para>
	/// <para>Propagated errors might be encountered from the following functions:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>CryptCreateHash</term>
	/// </item>
	/// <item>
	/// <term>CryptDecrypt</term>
	/// </item>
	/// <item>
	/// <term>CryptGetHashParam</term>
	/// </item>
	/// <item>
	/// <term>CryptGetUserKey</term>
	/// </item>
	/// <item>
	/// <term>CryptHashData</term>
	/// </item>
	/// <item>
	/// <term>CryptImportKey</term>
	/// </item>
	/// <item>
	/// <term>CryptSignHash</term>
	/// </item>
	/// <item>
	/// <term>CryptVerifySignature</term>
	/// </item>
	/// </list>
	/// <para>The following error codes are most commonly returned.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_E_ALREADY_DECRYPTED</term>
	/// <term>The message content has already been decrypted. This error can be returned if the dwCtrlType parameter is set to CMSG_CTRL_DECRYPT.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_E_AUTH_ATTR_MISSING</term>
	/// <term>
	/// The message does not contain an expected authenticated attribute. This error can be returned if the dwCtrlType parameter is set
	/// to CMSG_CTRL_VERIFY_SIGNATURE.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_E_BAD_ENCODE</term>
	/// <term>
	/// An error was encountered while encoding or decoding. This error can be returned if the dwCtrlType parameter is set to CMSG_CTRL_VERIFY_SIGNATURE.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_E_CONTROL_TYPE</term>
	/// <term>The control type is not valid.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_E_HASH_VALUE</term>
	/// <term>The hash value is incorrect.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_E_INVALID_INDEX</term>
	/// <term>The index value is not valid.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_E_INVALID_MSG_TYPE</term>
	/// <term>The message type is not valid.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_E_OID_FORMAT</term>
	/// <term>The object identifier is badly formatted. This error can be returned if the dwCtrlType parameter is set to CMSG_CTRL_ADD_SIGNER.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_E_RECIPIENT_NOT_FOUND</term>
	/// <term>
	/// The enveloped data message does not contain the specified recipient. This error can be returned if the dwCtrlType parameter is
	/// set to CMSG_CTRL_DECRYPT.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_E_SIGNER_NOT_FOUND</term>
	/// <term>The specified signer for the message was not found. This error can be returned if the dwCtrlType parameter is set to CMSG_CTRL_VERIFY_SIGNATURE.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_E_UNKNOWN_ALGO</term>
	/// <term>The cryptographic algorithm is unknown.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_E_UNEXPECTED_ENCODING</term>
	/// <term>The message is not encoded as expected. This error can be returned if the dwCtrlType parameter is set to CMSG_CTRL_VERIFY_SIGNATURE.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One or more arguments are not valid. This error can be returned if the dwCtrlType parameter is set to CMSG_CTRL_DECRYPT.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>Not enough memory was available to complete the operation.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptmsgcontrol BOOL CryptMsgControl( HCRYPTMSG
	// hCryptMsg, DWORD dwFlags, DWORD dwCtrlType, void const *pvCtrlPara );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "a990d44d-2993-429f-b817-2a834105ecef")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptMsgControl(HCRYPTMSG hCryptMsg, CryptMsgFlags dwFlags, CryptMsgControlType dwCtrlType, [In, Optional] IntPtr pvCtrlPara);

	/// <summary>
	/// The <c>CryptMsgCountersign</c> function countersigns an existing signature in a message. Countersignatures are used to sign an
	/// existing signature's encrypted hash of the message. Countersignatures can be used for various purposes including time stamping a message.
	/// </summary>
	/// <param name="hCryptMsg">Cryptographic message handle to be used.</param>
	/// <param name="dwIndex">Zero-based index of the signer in the signed or signed-and-enveloped message to be countersigned.</param>
	/// <param name="cCountersigners">Number of countersigners in the rgCountersigners array.</param>
	/// <param name="rgCountersigners">Array of countersigners' CMSG_SIGNER_ENCODE_INFO structures.</param>
	/// <returns>
	/// <para>If the function succeeds, the function returns nonzero ( <c>TRUE</c>).</para>
	/// <para>If the function fails, it returns zero ( <c>FALSE</c>). For extended error information, call GetLastError.</para>
	/// <para>An error can be propagated from CryptMsgCountersignEncoded.</para>
	/// <para>The following error codes are returned most often.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One or more arguments are not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>Ran out of memory.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>The specified area is not large enough to hold the returned data.</term>
	/// </item>
	/// </list>
	/// <para>
	/// If the function fails, GetLastError may return an Abstract Syntax Notation One (ASN.1) encoding/decoding error. For information
	/// about these errors, see ASN.1 Encoding/Decoding Return Values.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptmsgcountersign BOOL CryptMsgCountersign( HCRYPTMSG
	// hCryptMsg, DWORD dwIndex, DWORD cCountersigners, PCMSG_SIGNER_ENCODE_INFO rgCountersigners );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "ebf76664-bca6-462d-b519-2b60f435d8ef")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptMsgCountersign(HCRYPTMSG hCryptMsg, uint dwIndex, uint cCountersigners, [In, MarshalAs(UnmanagedType.LPArray)] CMSG_SIGNER_ENCODE_INFO[] rgCountersigners);

	/// <summary>
	/// The <c>CryptMsgCountersignEncoded</c> function countersigns an existing PKCS #7 message signature. The pbCountersignature
	/// <c>BYTE</c> buffer it creates is a PKCS #7 encoded SignerInfo that can be used as an unauthenticated Countersignature attribute
	/// of a PKCS #9 signed-data or signed-and-enveloped-data message.
	/// </summary>
	/// <param name="dwEncodingType">
	/// <para>
	/// Specifies the encoding type used. Currently, only X509_ASN_ENCODING and PKCS_7_ASN_ENCODING are being used; however, additional
	/// encoding types may be added in the future. For either current encoding type, use:
	/// </para>
	/// <para>X509_ASN_ENCODING | PKCS_7_ASN_ENCODING.</para>
	/// </param>
	/// <param name="pbSignerInfo">A pointer to the encoded SignerInfo that is to be countersigned.</param>
	/// <param name="cbSignerInfo">Count, in bytes, of the encoded SignerInfo data.</param>
	/// <param name="cCountersigners">Number of countersigners in the rgCountersigners array.</param>
	/// <param name="rgCountersigners">Array of countersigners' CMSG_SIGNER_ENCODE_INFO structures.</param>
	/// <param name="pbCountersignature">
	/// <para>A pointer to a buffer to receive an encoded PKCS #9 countersignature attribute.</para>
	/// <para>
	/// On input, this parameter can be <c>NULL</c> to set the size of this information for memory allocation purposes. For more
	/// information, see Retrieving Data of Unknown Length.
	/// </para>
	/// </param>
	/// <param name="pcbCountersignature">
	/// A pointer to a variable that specifies the size, in bytes, of the buffer pointed to by the pbCountersignature parameter. When
	/// the function returns, the variable pointed to by the pcbCountersignature parameter contains the number of bytes stored in the buffer.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero ( <c>TRUE</c>).</para>
	/// <para>If the function fails, the return value is zero ( <c>FALSE</c>). For extended error information, call GetLastError.</para>
	/// <para>The following table lists the error codes most commonly returned by the GetLastError function.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_E_OID_FORMAT</term>
	/// <term>The object identifier is badly formatted.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One or more arguments are not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>Ran out of memory.</term>
	/// </item>
	/// </list>
	/// <para>Propagated errors might be returned from one of the following functions:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>CryptCreateHash</term>
	/// </item>
	/// <item>
	/// <term>CryptHashData</term>
	/// </item>
	/// <item>
	/// <term>CryptGetHashParam</term>
	/// </item>
	/// <item>
	/// <term>CryptSignHash</term>
	/// </item>
	/// <item>
	/// <term>CryptMsgOpenToEncode</term>
	/// </item>
	/// <item>
	/// <term>CryptMsgUpdate</term>
	/// </item>
	/// <item>
	/// <term>CryptMsgControl</term>
	/// </item>
	/// </list>
	/// <para>
	/// If the function fails, GetLastError may return an Abstract Syntax Notation One (ASN.1) encoding/decoding error. For information
	/// about these errors, see ASN.1 Encoding/Decoding Return Values.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptmsgcountersignencoded BOOL
	// CryptMsgCountersignEncoded( DWORD dwEncodingType, PBYTE pbSignerInfo, DWORD cbSignerInfo, DWORD cCountersigners,
	// PCMSG_SIGNER_ENCODE_INFO rgCountersigners, PBYTE pbCountersignature, PDWORD pcbCountersignature );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "d9fd734b-e14d-4392-ac88-5565aefbedb4")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptMsgCountersignEncoded(CertEncodingType dwEncodingType, [In] IntPtr pbSignerInfo, uint cbSignerInfo, uint cCountersigners,
		[In, MarshalAs(UnmanagedType.LPArray)] CMSG_SIGNER_ENCODE_INFO[] rgCountersigners, [Out] IntPtr pbCountersignature, ref uint pcbCountersignature);

	/// <summary>The <c>CryptMsgDuplicate</c> function duplicates a cryptographic message handle by incrementing its reference count.</summary>
	/// <param name="hCryptMsg">
	/// Handle of the cryptographic message to be duplicated. Duplication is done by incrementing the reference count of the message. A
	/// copy of the message is not made.
	/// </param>
	/// <returns>
	/// The returned handle is the same as the handle input. A copy of the message is not created. When you have finished using the
	/// duplicated message handle, decrease the reference count by calling the CryptMsgClose function.
	/// </returns>
	/// <remarks>
	/// <para>
	/// <c>CryptMsgDuplicate</c> is used to increase the reference count on an <c>HCRYPTMSG</c> handle so that multiple calls to
	/// CryptMsgClose are required to actually release the handle.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example that uses this function, see Example C Program: Encoding and Decoding a Hashed Message.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptmsgduplicate HCRYPTMSG CryptMsgDuplicate( HCRYPTMSG
	// hCryptMsg );
	[DllImport(Lib.Crypt32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "9b1142b9-0caa-4304-bfe6-1c27c6a7b782")]
	public static extern HCRYPTMSG CryptMsgDuplicate(HCRYPTMSG hCryptMsg);

	/// <summary>
	/// The <c>CryptMsgGetParam</c> function acquires a message parameter after a cryptographic message has been encoded or decoded.
	/// This function is called after the final CryptMsgUpdate call.
	/// </summary>
	/// <param name="hCryptMsg">Handle of a cryptographic message.</param>
	/// <param name="dwParamType">
	/// <para>
	/// Indicates the parameter types of data to be retrieved. The type of data to be retrieved determines the type of structure to use
	/// for pvData.
	/// </para>
	/// <para>
	/// For an encoded message, only the CMSG_BARE_CONTENT, CMSG_ENCODE_SIGNER, CMSG_CONTENT_PARAM and CMSG_COMPUTED_HASH_PARAM
	/// dwParamTypes are valid.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CMSG_ATTR_CERT_COUNT_PARAM</term>
	/// <term>pvData data type: pointer to a DWORD Returns the count of the attribute certificates in a SIGNED or ENVELOPED message.</term>
	/// </item>
	/// <item>
	/// <term>CMSG_ATTR_CERT_PARAM</term>
	/// <term>
	/// pvData data type: pointer to a BYTE array Retrieves an attribute certificate. To get all the attribute certificates, call
	/// CryptMsgGetParam varying dwIndex set to 0 the number of attributes minus one.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CMSG_BARE_CONTENT_PARAM</term>
	/// <term>
	/// pvData data type: pointer to a BYTE array Retrieves the encoded content of an encoded cryptographic message, without the outer
	/// layer of the CONTENT_INFO structure. That is, only the encoding of the PKCS #7 defined ContentInfo.content field is returned.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CMSG_CERT_COUNT_PARAM</term>
	/// <term>pvData data type: pointer to DWORD Returns the number of certificates in a received SIGNED or ENVELOPED message.</term>
	/// </item>
	/// <item>
	/// <term>CMSG_CERT_PARAM</term>
	/// <term>
	/// pvData data type: pointer to a BYTE array Returns a signer's certificate. To get all of the signer's certificates, call
	/// CryptMsgGetParam, varying dwIndex from 0 to the number of available certificates minus one.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CMSG_COMPUTED_HASH_PARAM</term>
	/// <term>
	/// pvData data type: pointer to a BYTE array Returns the hash calculated of the data in the message. This type is applicable to
	/// both encode and decode.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CMSG_CONTENT_PARAM</term>
	/// <term>
	/// pvData data type: pointer to a BYTE array Returns the whole PKCS #7 message from a message opened to encode. Retrieves the inner
	/// content of a message opened to decode. If the message is enveloped, the inner type is data, and CryptMsgControl has been called
	/// to decrypt the message, the decrypted content is returned. If the inner type is not data, the encoded BLOB that requires further
	/// decoding is returned. If the message is not enveloped and the inner content is DATA, the returned data is the octets of the
	/// inner content. This type is applicable to both encode and decode. For decoding, if the type is CMSG_DATA, the content's octets
	/// are returned; else, the encoded inner content is returned.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CMSG_CRL_COUNT_PARAM</term>
	/// <term>pvData data type: pointer to DWORD Returns the count of CRLs in a received, SIGNED or ENVELOPED message.</term>
	/// </item>
	/// <item>
	/// <term>CMSG_CRL_PARAM</term>
	/// <term>
	/// pvData data type: pointer to a BYTE array Returns a CRL. To get all the CRLs, call CryptMsgGetParam, varying dwIndex from 0 to
	/// the number of available CRLs minus one.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CMSG_ENCODED_MESSAGE</term>
	/// <term>
	/// pvData data type: pointer to a BYTE array Changes the contents of an already encoded message. The message must first be decoded
	/// with a call to CryptMsgOpenToDecode. Then the change to the message is made through a call to CryptMsgControl,
	/// CryptMsgCountersign, or CryptMsgCountersignEncoded. The message is then encoded again with a call to CryptMsgGetParam,
	/// specifying CMSG_ENCODED_MESSAGE to get a new encoding that reflects the changes made. This can be used, for instance, to add a
	/// time-stamp attribute to a message.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CMSG_ENCODED_SIGNER</term>
	/// <term>pvData data type: pointer to a BYTE array Returns the encoded CMSG_SIGNER_INFO signer information for a message signer.</term>
	/// </item>
	/// <item>
	/// <term>CMSG_ENCRYPTED_DIGEST</term>
	/// <term>pvData data type: pointer to a BYTE array Returns the encrypted hash of a signature. Typically used for performing time-stamping.</term>
	/// </item>
	/// <item>
	/// <term>CMSG_ENCRYPT_PARAM</term>
	/// <term>
	/// pvData data type: pointer to a BYTE array for a CRYPT_ALGORITHM_IDENTIFIER structure. Returns the encryption algorithm used to
	/// encrypted the message.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CMSG_ENVELOPE_ALGORITHM_PARAM</term>
	/// <term>
	/// pvData data type: pointer to a BYTE array for a CRYPT_ALGORITHM_IDENTIFIER structure. Returns the encryption algorithm used to
	/// encrypt an ENVELOPED message.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CMSG_HASH_ALGORITHM_PARAM</term>
	/// <term>
	/// pvData data type: pointer to a BYTE array for a CRYPT_ALGORITHM_IDENTIFIER structure. Returns the hash algorithm used to hash
	/// the message when it was created.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CMSG_HASH_DATA_PARAM</term>
	/// <term>pvData data type: pointer to a BYTE array Returns the hash value stored in the message when it was created.</term>
	/// </item>
	/// <item>
	/// <term>CMSG_INNER_CONTENT_TYPE_PARAM</term>
	/// <term>
	/// pvData data type: pointer to a BYTE array to receive a null-terminated object identifier (OID) string. Returns the inner content
	/// type of a received message. This type is not applicable to messages of type DATA.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CMSG_RECIPIENT_COUNT_PARAM</term>
	/// <term>pvData data type: pointer to a DWORD Returns the number of key transport recipients of an ENVELOPED received message.</term>
	/// </item>
	/// <item>
	/// <term>CMSG_CMS_RECIPIENT_COUNT_PARAM</term>
	/// <term>
	/// pvData data type: pointer to DWORD Returns the total count of all message recipients including key agreement and mail list recipients.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CMSG_RECIPIENT_INDEX_PARAM</term>
	/// <term>
	/// pvData data type: pointer to a DWORD Returns the index of the key transport recipient used to decrypt an ENVELOPED message. This
	/// value is available only after a message has been decrypted.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CMSG_CMS_RECIPIENT_INDEX_PARAM</term>
	/// <term>
	/// pvData data type: pointer to a DWORD Returns the index of the key transport, key agreement, or mail list recipient used to
	/// decrypt an ENVELOPED message.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CMSG_CMS_RECIPIENT_ENCRYPTED_KEY_INDEX_PARAM</term>
	/// <term>
	/// pvData data type: pointer to a DWORD Returns the index of the encrypted key of a key agreement recipient used to decrypt an
	/// ENVELOPED message.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CMSG_RECIPIENT_INFO_PARAM</term>
	/// <term>
	/// pvData data type: pointer to a BYTE array to receive a CERT_INFO structure. Returns certificate information about a key
	/// transport message's recipient. To get certificate information on all key transport message's recipients, repetitively call
	/// CryptMsgGetParam, varying dwIndex from 0 to the number of recipients minus one. Only the Issuer, SerialNumber, and
	/// PublicKeyAlgorithm members of the CERT_INFO structure returned are available and valid.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CMSG_CMS_RECIPIENT_INFO_PARAM</term>
	/// <term>
	/// pvData data type: pointer to a BYTE array to receive a CMSG_CMS_RECIPIENT_INFO structure. Returns information about a key
	/// transport, key agreement, or mail list recipient. It is not limited to key transport message recipients. To get information on
	/// all of a message's recipients, repetitively call CryptMsgGetParam, varying dwIndex from 0 to the number of recipients minus one.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CMSG_SIGNER_AUTH_ATTR_PARAM</term>
	/// <term>
	/// pvData data type: pointer to a BYTE array to receive a CRYPT_ATTRIBUTES structure. Returns the authenticated attributes of a
	/// message signer. To retrieve the authenticated attributes for a specified signer, call CryptMsgGetParam with dwIndex equal to
	/// that signer's index.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CMSG_SIGNER_CERT_INFO_PARAM</term>
	/// <term>
	/// pvData data type: pointer to a BYTE array to receive the CERT_INFO structure. Returns information on a message signer needed to
	/// identify the signer's certificate. A certificate's Issuer and SerialNumber can be used to uniquely identify a certificate for
	/// retrieval. To retrieve information for all the signers, repetitively call CryptMsgGetParam varying dwIndex from 0 to the number
	/// of signers minus one. Only the Issuer and SerialNumber fields in the CERT_INFO structure returned contain available, valid data.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CMSG_SIGNER_CERT_ID_PARAM</term>
	/// <term>
	/// pvData data type: pointer to a BYTE array to receive a CERT_ID structure. Returns information on a message signer needed to
	/// identify the signer's public key. This could be a certificate's Issuer and SerialNumber, a KeyID, or a HashId. To retrieve
	/// information for all the signers, call CryptMsgGetParam varying dwIndex from 0 to the number of signers minus one.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CMSG_SIGNER_COUNT_PARAM</term>
	/// <term>pvData data type: pointer to a DWORD Returns the number of signers of a received SIGNED message.</term>
	/// </item>
	/// <item>
	/// <term>CMSG_SIGNER_HASH_ALGORITHM_PARAM</term>
	/// <term>
	/// pvData data type: pointer to a BYTE array to receive the CRYPT_ALGORITHM_IDENTIFIER structure. Returns the hash algorithm used
	/// by a signer of the message. To get the hash algorithm for a specified signer, call CryptMsgGetParam with dwIndex equal to that
	/// signer's index.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CMSG_SIGNER_INFO_PARAM</term>
	/// <term>
	/// pvData data type: pointer to a BYTE array to receive a CMSG_SIGNER_INFO structure. Returns information on a message signer. This
	/// includes the issuer and serial number of the signer's certificate and authenticated and unauthenticated attributes of the
	/// signer's certificate. To retrieve signer information on all of the signers of a message, call CryptMsgGetParam varying dwIndex
	/// from 0 to the number of signers minus one.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CMSG_CMS_SIGNER_INFO_PARAM</term>
	/// <term>
	/// pvData data type: pointer to a BYTE array to receive a CMSG_CMS_SIGNER_INFO structure. Returns information on a message signer.
	/// This includes a signerId and authenticated and unauthenticated attributes. To retrieve signer information on all of the signers
	/// of a message, call CryptMsgGetParam varying dwIndex from 0 to the number of signers minus one.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CMSG_SIGNER_UNAUTH_ATTR_PARAM</term>
	/// <term>
	/// pvData data type: pointer to a BYTE array to receive a CRYPT_ATTRIBUTES structure. Returns a message signer's unauthenticated
	/// attributes. To retrieve the unauthenticated attributes for a specified signer, call CryptMsgGetParam with dwIndex equal to that
	/// signer's index.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CMSG_TYPE_PARAM</term>
	/// <term>
	/// pvData data type: pointer to a DWORD Returns the message type of a decoded message of unknown type. The retrieved message type
	/// can be compared to supported types to determine whether processing can continued. For supported message types, see the
	/// dwMessageType parameter of CryptMsgOpenToDecode.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CMSG_UNPROTECTED_ATTR_PARAM</term>
	/// <term>
	/// pvData data type: pointer to a BYTE array to receive a CMSG_ATTR structure. Returns the unprotected attributes in an enveloped message.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CMSG_VERSION_PARAM</term>
	/// <term>
	/// pvData data type: pointer to a DWORD Returns the version of the decoded message. For more information, see the table in the
	/// Remarks section.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwIndex">
	/// Index for the parameter being retrieved, where applicable. When a parameter is not being retrieved, this parameter is ignored
	/// and is set to zero.
	/// </param>
	/// <param name="pvData">
	/// <para>
	/// A pointer to a buffer that receives the data retrieved. The form of this data will vary depending on the value of the
	/// dwParamType parameter.
	/// </para>
	/// <para>
	/// This parameter can be <c>NULL</c> to set the size of this information for memory allocation purposes. For more information, see
	/// Retrieving Data of Unknown Length.
	/// </para>
	/// <para>
	/// When processing the data returned in this buffer, applications need to use the actual size of the data returned. The actual size
	/// can be slightly smaller than the size of the buffer specified on input. (On input, buffer sizes are usually specified large
	/// enough to ensure that the largest possible output data will fit in the buffer.) On output, the variable pointed to by this
	/// parameter is updated to reflect the actual size of the data copied to the buffer.
	/// </para>
	/// </param>
	/// <param name="pcbData">
	/// A pointer to a variable that specifies the size, in bytes, of the buffer pointed to by the pvData parameter. When the function
	/// returns, the variable pointed to by the pcbData parameter contains the number of bytes stored in the buffer.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero (TRUE).</para>
	/// <para>If the function fails, the return value is zero (FALSE). For extended error information, call GetLastError.</para>
	/// <para>The following table lists the error codes most commonly returned by the GetLastError function.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_E_ATTRIBUTES_MISSING</term>
	/// <term>The message does not contain the requested attributes.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_E_INVALID_INDEX</term>
	/// <term>The index value is not valid.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_E_INVALID_MSG_TYPE</term>
	/// <term>The message type is not valid.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_E_NOT_DECRYPTED</term>
	/// <term>The message content has not been decrypted yet.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_E_OID_FORMAT</term>
	/// <term>The object identifier is badly formatted.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_E_UNEXPECTED_ENCODING</term>
	/// <term>The message is not encoded as expected.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One or more arguments are not valid.</term>
	/// </item>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>The specified buffer is not large enough to hold the returned data.</term>
	/// </item>
	/// </list>
	/// <para>For dwParamType CMSG_COMPUTED_HASH_PARAM, an error can be propagated from CryptGetHashParam.</para>
	/// <para>
	/// If the function fails, GetLastError may return an Abstract Syntax Notation One (ASN.1) encoding/decoding error. For information
	/// about these errors, see ASN.1 Encoding/Decoding Return Values.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The following version numbers are returned by calls to <c>CryptMsgGetParam</c> with dwParamType set to CMSG_VERSION_PARAM are defined:
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>CMSG_SIGNED_DATA_V1</term>
	/// </item>
	/// <item>
	/// <term>CMSG_SIGNED_DATA_V3</term>
	/// </item>
	/// <item>
	/// <term>CMSG_SIGNED_DATA_PKCS_1_5_VERSION</term>
	/// </item>
	/// <item>
	/// <term>CMSG_SIGNED_DATA_CMS_VERSION</term>
	/// </item>
	/// <item>
	/// <term>CMSG_SIGNER_INFO_V1</term>
	/// </item>
	/// <item>
	/// <term>CMSG_SIGNER_INFO_V3</term>
	/// </item>
	/// <item>
	/// <term>CMSG_SIGNER_INFO_PKCS_1_5_VERSION</term>
	/// </item>
	/// <item>
	/// <term>CMSG_SIGNER_INFO_CMS_VERSION</term>
	/// </item>
	/// <item>
	/// <term>CMSG_HASHED_DATA_V0</term>
	/// </item>
	/// <item>
	/// <term>CMSG_HASHED_DATA_V2</term>
	/// </item>
	/// <item>
	/// <term>CMSG_HASHED_DATA_PKCS_1_5_VERSION</term>
	/// </item>
	/// <item>
	/// <term>CMSG_HASHED_DATA_CMS_VERSION</term>
	/// </item>
	/// <item>
	/// <term>CMSG_ENVELOPED_DATA_V0</term>
	/// </item>
	/// <item>
	/// <term>CMSG_ENVELOPED_DATA_V2</term>
	/// </item>
	/// <item>
	/// <term>CMSG_ENVELOPED_DATA_PKCS_1_5_VERSION</term>
	/// </item>
	/// <item>
	/// <term>CMSG_ENVELOPED_DATA_CMS_VERSION</term>
	/// </item>
	/// </list>
	/// <para>Examples</para>
	/// <para>
	/// For an example that uses this function, see Example C Program: Signing, Encoding, Decoding, and Verifying a Message, Alternate
	/// Code for Encoding an Enveloped Message, Example C Program: Encoding an Enveloped, Signed Message, and Example C Program:
	/// Encoding and Decoding a Hashed Message.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptmsggetparam BOOL CryptMsgGetParam( HCRYPTMSG
	// hCryptMsg, DWORD dwParamType, DWORD dwIndex, void *pvData, DWORD *pcbData );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "5a05eb09-208f-4e94-abfa-c2f14c0a3164")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptMsgGetParam(HCRYPTMSG hCryptMsg, CryptMsgParamType dwParamType, uint dwIndex, [Out] IntPtr pvData, ref uint pcbData);

	/// <summary>
	/// <para>
	/// The <c>CryptMsgOpenToDecode</c> function opens a cryptographic message for decoding and returns a handle of the opened message.
	/// The message remains open until the CryptMsgClose function is called.
	/// </para>
	/// <para>
	/// Important changes that affect the handling of enveloped messages have been made to CryptoAPI to support Secure/Multipurpose
	/// Internet Mail Extensions (S/MIME) email interoperability. For details, see the Remarks section of CryptMsgOpenToEncode.
	/// </para>
	/// </summary>
	/// <param name="dwMsgEncodingType">
	/// <para>
	/// Specifies the encoding type used. It is always acceptable to specify both the certificate and message encoding types by
	/// combining them with a bitwise- <c>OR</c> operation as shown in the following example:
	/// </para>
	/// <para>X509_ASN_ENCODING | PKCS_7_ASN_ENCODING</para>
	/// <para>Currently defined encoding types are:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>X509_ASN_ENCODING</term>
	/// </item>
	/// <item>
	/// <term>PKCS_7_ASN_ENCODING</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwFlags">
	/// <para>This parameter can be one of the following flags.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CMSG_DETACHED_FLAG</term>
	/// <term>Indicates that the message to be decoded is detached. If this flag is not set, the message is not detached.</term>
	/// </item>
	/// <item>
	/// <term>CMSG_CRYPT_RELEASE_CONTEXT_FLAG</term>
	/// <term>
	/// If set, the hCryptProv passed to this function is released on the final CryptMsgUpdate. The handle is not released if the
	/// function fails.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwMsgType">
	/// <para>
	/// Specifies the type of message to decode. In most cases, the message type is determined from the message header and zero is
	/// passed for this parameter. In some cases, notably with Internet Explorer 3.0, messages do not have headers and the type of
	/// message to be decoded must be supplied in this function call. If the header is missing and zero is passed for this parameter,
	/// the function fails.
	/// </para>
	/// <para>This parameter can be one of the following predefined message types.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CMSG_DATA</term>
	/// <term>The message is encoded data.</term>
	/// </item>
	/// <item>
	/// <term>CMSG_ENVELOPED</term>
	/// <term>The message is an enveloped message.</term>
	/// </item>
	/// <item>
	/// <term>CMSG_HASHED</term>
	/// <term>The message is a hashed message.</term>
	/// </item>
	/// <item>
	/// <term>CMSG_SIGNED</term>
	/// <term>The message is a signed message.</term>
	/// </item>
	/// <item>
	/// <term>CMSG_SIGNED_AND_ENVELOPED</term>
	/// <term>The message is a signed and enveloped message.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="hCryptProv">
	/// <para>This parameter is not used and should be set to <c>NULL</c>.</para>
	/// <para>
	/// <c>Windows Server 2003 and Windows XP:</c> Specifies a handle for the cryptographic provider to use for hashing the message. For
	/// signed messages, hCryptProv is used for signature verification.This parameter's data type is <c>HCRYPTPROV</c>.
	/// </para>
	/// <para>
	/// Unless there is a strong reason for passing in a specific cryptographic provider in hCryptProv, set this parameter to
	/// <c>NULL</c>. Passing in <c>NULL</c> causes the default RSA or DSS provider to be acquired before performing hash, signature
	/// verification, or recipient encryption operations.
	/// </para>
	/// </param>
	/// <param name="pRecipientInfo">This parameter is reserved for future use and must be <c>NULL</c>.</param>
	/// <param name="pStreamInfo">
	/// <para>When streaming is not being used, this parameter must be set to <c>NULL</c>.</para>
	/// <para>
	/// <c>Note</c> Streaming is not used with CMSG_HASHED messages. When dealing with hashed data, this parameter must be set to <c>NULL</c>.
	/// </para>
	/// <para>
	/// When streaming is being used, the pStreamInfo parameter is a pointer to a CMSG_STREAM_INFO structure that contains a pointer to
	/// a callback to be called when CryptMsgUpdate is executed or when CryptMsgControl is executed when decoding a streamed enveloped message.
	/// </para>
	/// <para>For a signed message, the callback is passed a block of the decoded bytes from the inner content of the message.</para>
	/// <para>
	/// For an enveloped message, after each call to CryptMsgUpdate, you must check to determine whether the
	/// CMSG_ENVELOPE_ALGORITHM_PARAM property is available by calling the CryptMsgGetParam function. <c>CryptMsgGetParam</c> will fail
	/// and GetLastError will return CRYPT_E_STREAM_MSG_NOT_READY until <c>CryptMsgUpdate</c> has processed enough of the message to
	/// make the CMSG_ENVELOPE_ALGORITHM_PARAM property available. When the CMSG_ENVELOPE_ALGORITHM_PARAM property is available, you can
	/// iterate through the recipients, retrieving a CERT_INFO structure for each recipient by using the <c>CryptMsgGetParam</c>
	/// function to retrieve the CMSG_RECIPIENT_INFO_PARAM property. To prevent a denial of service attack from an enveloped message
	/// that has an artificially large header block, you must keep track of the amount of memory that has been passed to the
	/// <c>CryptMsgUpdate</c> function during this process. If the amount of data exceeds an application defined limit before the
	/// CMSG_ENVELOPE_ALGORITHM_PARAM property is available, you must stop processing the message and call the CryptMsgClose function to
	/// cause the operating system to release any memory that has been allocated for the message. A suggested limit is the maximum
	/// allowable size of a message. For example, if the maximum message size is 10 MB, the limit for this test should be 10 MB.
	/// </para>
	/// <para>
	/// The CERT_INFO structure is used to find a matching certificate in a previously opened certificate store by using the
	/// CertGetSubjectCertificateFromStore function. When the correct certificate is found, the CertGetCertificateContextProperty
	/// function with a CERT_KEY_PROV_INFO_PROP_ID parameter is called to retrieve a CRYPT_KEY_PROV_INFO structure. The structure
	/// contains the information necessary to acquire the recipient's private key by calling CryptAcquireContext, using the
	/// <c>pwszContainerName</c>, <c>pwszProvName</c>, <c>dwProvType</c>, and <c>dwFlags</c> members of the <c>CRYPT_KEY_PROV_INFO</c>
	/// structure. The <c>hCryptProv</c> acquired and the <c>dwKeySpec</c> member of the <c>CRYPT_KEY_PROV_INFO</c> structure are passed
	/// to the CryptMsgControl structure as a member of the CMSG_CTRL_DECRYPT_PARA structure to permit the start of the decryption of
	/// the inner content. The streaming code will then perform the decryption as the data is input. The resulting blocks of plaintext
	/// are passed to the callback function specified by the <c>pfnStreamOutput</c> member of the CMSG_STREAM_INFO structure to handle
	/// the output of the decrypted message.
	/// </para>
	/// <para>
	/// <c>Note</c> Streamed decoding of an enveloped message queues the ciphertext in memory until CryptMsgControl is called to start
	/// the decryption. The application must initiate decrypting in a timely manner so that the data can be saved to disk or routed
	/// elsewhere before the accumulated ciphertext becomes too large and the system runs out of memory.
	/// </para>
	/// <para>
	/// In the case of a signed message enclosed in an enveloped message, the plaintext output from the streaming decode of the
	/// enveloped message can be fed into another streaming decode to process the signed message.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns the handle of the opened message.</para>
	/// <para>If the function fails, it returns <c>NULL</c>. For extended error information, call GetLastError.</para>
	/// <para>The following table lists the error codes most commonly returned by the GetLastError function.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One or more arguments are not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>A memory allocation failure occurred.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptmsgopentodecode HCRYPTMSG CryptMsgOpenToDecode(
	// DWORD dwMsgEncodingType, DWORD dwFlags, DWORD dwMsgType, HCRYPTPROV_LEGACY hCryptProv, PCERT_INFO pRecipientInfo,
	// PCMSG_STREAM_INFO pStreamInfo );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "b3df6312-c866-4faa-8b89-bda67c697631")]
	public static extern SafeHCRYPTMSG CryptMsgOpenToDecode(CertEncodingType dwMsgEncodingType, CryptMsgFlags dwFlags, CryptMsgType dwMsgType,
		[Optional] HCRYPTPROV hCryptProv, [Optional] IntPtr pRecipientInfo, in CMSG_STREAM_INFO pStreamInfo);

	/// <summary>
	/// <para>
	/// The <c>CryptMsgOpenToDecode</c> function opens a cryptographic message for decoding and returns a handle of the opened message.
	/// The message remains open until the CryptMsgClose function is called.
	/// </para>
	/// <para>
	/// Important changes that affect the handling of enveloped messages have been made to CryptoAPI to support Secure/Multipurpose
	/// Internet Mail Extensions (S/MIME) email interoperability. For details, see the Remarks section of CryptMsgOpenToEncode.
	/// </para>
	/// </summary>
	/// <param name="dwMsgEncodingType">
	/// <para>
	/// Specifies the encoding type used. It is always acceptable to specify both the certificate and message encoding types by
	/// combining them with a bitwise- <c>OR</c> operation as shown in the following example:
	/// </para>
	/// <para>X509_ASN_ENCODING | PKCS_7_ASN_ENCODING</para>
	/// <para>Currently defined encoding types are:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>X509_ASN_ENCODING</term>
	/// </item>
	/// <item>
	/// <term>PKCS_7_ASN_ENCODING</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwFlags">
	/// <para>This parameter can be one of the following flags.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CMSG_DETACHED_FLAG</term>
	/// <term>Indicates that the message to be decoded is detached. If this flag is not set, the message is not detached.</term>
	/// </item>
	/// <item>
	/// <term>CMSG_CRYPT_RELEASE_CONTEXT_FLAG</term>
	/// <term>
	/// If set, the hCryptProv passed to this function is released on the final CryptMsgUpdate. The handle is not released if the
	/// function fails.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwMsgType">
	/// <para>
	/// Specifies the type of message to decode. In most cases, the message type is determined from the message header and zero is
	/// passed for this parameter. In some cases, notably with Internet Explorer 3.0, messages do not have headers and the type of
	/// message to be decoded must be supplied in this function call. If the header is missing and zero is passed for this parameter,
	/// the function fails.
	/// </para>
	/// <para>This parameter can be one of the following predefined message types.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CMSG_DATA</term>
	/// <term>The message is encoded data.</term>
	/// </item>
	/// <item>
	/// <term>CMSG_ENVELOPED</term>
	/// <term>The message is an enveloped message.</term>
	/// </item>
	/// <item>
	/// <term>CMSG_HASHED</term>
	/// <term>The message is a hashed message.</term>
	/// </item>
	/// <item>
	/// <term>CMSG_SIGNED</term>
	/// <term>The message is a signed message.</term>
	/// </item>
	/// <item>
	/// <term>CMSG_SIGNED_AND_ENVELOPED</term>
	/// <term>The message is a signed and enveloped message.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="hCryptProv">
	/// <para>This parameter is not used and should be set to <c>NULL</c>.</para>
	/// <para>
	/// <c>Windows Server 2003 and Windows XP:</c> Specifies a handle for the cryptographic provider to use for hashing the message. For
	/// signed messages, hCryptProv is used for signature verification.This parameter's data type is <c>HCRYPTPROV</c>.
	/// </para>
	/// <para>
	/// Unless there is a strong reason for passing in a specific cryptographic provider in hCryptProv, set this parameter to
	/// <c>NULL</c>. Passing in <c>NULL</c> causes the default RSA or DSS provider to be acquired before performing hash, signature
	/// verification, or recipient encryption operations.
	/// </para>
	/// </param>
	/// <param name="pRecipientInfo">This parameter is reserved for future use and must be <c>NULL</c>.</param>
	/// <param name="pStreamInfo">
	/// <para>When streaming is not being used, this parameter must be set to <c>NULL</c>.</para>
	/// <para>
	/// <c>Note</c> Streaming is not used with CMSG_HASHED messages. When dealing with hashed data, this parameter must be set to <c>NULL</c>.
	/// </para>
	/// <para>
	/// When streaming is being used, the pStreamInfo parameter is a pointer to a CMSG_STREAM_INFO structure that contains a pointer to
	/// a callback to be called when CryptMsgUpdate is executed or when CryptMsgControl is executed when decoding a streamed enveloped message.
	/// </para>
	/// <para>For a signed message, the callback is passed a block of the decoded bytes from the inner content of the message.</para>
	/// <para>
	/// For an enveloped message, after each call to CryptMsgUpdate, you must check to determine whether the
	/// CMSG_ENVELOPE_ALGORITHM_PARAM property is available by calling the CryptMsgGetParam function. <c>CryptMsgGetParam</c> will fail
	/// and GetLastError will return CRYPT_E_STREAM_MSG_NOT_READY until <c>CryptMsgUpdate</c> has processed enough of the message to
	/// make the CMSG_ENVELOPE_ALGORITHM_PARAM property available. When the CMSG_ENVELOPE_ALGORITHM_PARAM property is available, you can
	/// iterate through the recipients, retrieving a CERT_INFO structure for each recipient by using the <c>CryptMsgGetParam</c>
	/// function to retrieve the CMSG_RECIPIENT_INFO_PARAM property. To prevent a denial of service attack from an enveloped message
	/// that has an artificially large header block, you must keep track of the amount of memory that has been passed to the
	/// <c>CryptMsgUpdate</c> function during this process. If the amount of data exceeds an application defined limit before the
	/// CMSG_ENVELOPE_ALGORITHM_PARAM property is available, you must stop processing the message and call the CryptMsgClose function to
	/// cause the operating system to release any memory that has been allocated for the message. A suggested limit is the maximum
	/// allowable size of a message. For example, if the maximum message size is 10 MB, the limit for this test should be 10 MB.
	/// </para>
	/// <para>
	/// The CERT_INFO structure is used to find a matching certificate in a previously opened certificate store by using the
	/// CertGetSubjectCertificateFromStore function. When the correct certificate is found, the CertGetCertificateContextProperty
	/// function with a CERT_KEY_PROV_INFO_PROP_ID parameter is called to retrieve a CRYPT_KEY_PROV_INFO structure. The structure
	/// contains the information necessary to acquire the recipient's private key by calling CryptAcquireContext, using the
	/// <c>pwszContainerName</c>, <c>pwszProvName</c>, <c>dwProvType</c>, and <c>dwFlags</c> members of the <c>CRYPT_KEY_PROV_INFO</c>
	/// structure. The <c>hCryptProv</c> acquired and the <c>dwKeySpec</c> member of the <c>CRYPT_KEY_PROV_INFO</c> structure are passed
	/// to the CryptMsgControl structure as a member of the CMSG_CTRL_DECRYPT_PARA structure to permit the start of the decryption of
	/// the inner content. The streaming code will then perform the decryption as the data is input. The resulting blocks of plaintext
	/// are passed to the callback function specified by the <c>pfnStreamOutput</c> member of the CMSG_STREAM_INFO structure to handle
	/// the output of the decrypted message.
	/// </para>
	/// <para>
	/// <c>Note</c> Streamed decoding of an enveloped message queues the ciphertext in memory until CryptMsgControl is called to start
	/// the decryption. The application must initiate decrypting in a timely manner so that the data can be saved to disk or routed
	/// elsewhere before the accumulated ciphertext becomes too large and the system runs out of memory.
	/// </para>
	/// <para>
	/// In the case of a signed message enclosed in an enveloped message, the plaintext output from the streaming decode of the
	/// enveloped message can be fed into another streaming decode to process the signed message.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns the handle of the opened message.</para>
	/// <para>If the function fails, it returns <c>NULL</c>. For extended error information, call GetLastError.</para>
	/// <para>The following table lists the error codes most commonly returned by the GetLastError function.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One or more arguments are not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>A memory allocation failure occurred.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptmsgopentodecode HCRYPTMSG CryptMsgOpenToDecode(
	// DWORD dwMsgEncodingType, DWORD dwFlags, DWORD dwMsgType, HCRYPTPROV_LEGACY hCryptProv, PCERT_INFO pRecipientInfo,
	// PCMSG_STREAM_INFO pStreamInfo );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "b3df6312-c866-4faa-8b89-bda67c697631")]
	public static extern SafeHCRYPTMSG CryptMsgOpenToDecode(CertEncodingType dwMsgEncodingType, CryptMsgFlags dwFlags, CryptMsgType dwMsgType, HCRYPTPROV hCryptProv = default, IntPtr pRecipientInfo = default, IntPtr pStreamInfo = default);

	/// <summary>
	/// The <c>CryptMsgOpenToEncode</c> function opens a cryptographic message for encoding and returns a handle of the opened message.
	/// The message remains open until CryptMsgClose is called.
	/// </summary>
	/// <param name="dwMsgEncodingType">
	/// <para>
	/// Specifies the encoding type used. It is always acceptable to specify both the certificate and message encoding types by
	/// combining them with a bitwise- <c>OR</c> operation as shown in the following example:
	/// </para>
	/// <para>X509_ASN_ENCODING | PKCS_7_ASN_ENCODING</para>
	/// <para>Currently defined encoding types are:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>X509_ASN_ENCODING</term>
	/// </item>
	/// <item>
	/// <term>PKCS_7_ASN_ENCODING</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwFlags">
	/// <para>Currently defined dwFlags are shown in the following table.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CMSG_BARE_CONTENT_FLAG</term>
	/// <term>
	/// The streamed output will not have an outer ContentInfo wrapper (as defined by PKCS #7). This makes it suitable to be streamed
	/// into an enclosing message.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CMSG_DETACHED_FLAG</term>
	/// <term>There is detached data being supplied for the subsequent calls to CryptMsgUpdate.</term>
	/// </item>
	/// <item>
	/// <term>CMSG_AUTHENTICATED_ATTRIBUTES_FLAG</term>
	/// <term>
	/// Authenticated attributes are forced to be included in the SignerInfo (as defined by PKCS #7) in cases where they would not
	/// otherwise be required.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CMSG_CONTENTS_OCTETS_FLAG</term>
	/// <term>
	/// Used when calculating the size of a message that has been encoded by using Distinguished Encoding Rules (DER) and that is nested
	/// inside an enveloped message. This is particularly useful when performing streaming.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CMSG_CMS_ENCAPSULATED_CONTENT_FLAG</term>
	/// <term>
	/// When set, non-data type-inner content is encapsulated within an OCTET STRING. Applicable to both signed and enveloped messages.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CMSG_CRYPT_RELEASE_CONTEXT_FLAG</term>
	/// <term>
	/// If set, the hCryptProv that is passed to this function is released on the final CryptMsgUpdate. The handle is not released if
	/// the function fails.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwMsgType">
	/// <para>Indicates the message type. This must be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CMSG_DATA</term>
	/// <term>This value is not used.</term>
	/// </item>
	/// <item>
	/// <term>CMSG_SIGNED</term>
	/// <term>The pvMsgEncodeInfo parameter is the address of a CMSG_SIGNED_ENCODE_INFO structure that contains the encoding information.</term>
	/// </item>
	/// <item>
	/// <term>CMSG_ENVELOPED</term>
	/// <term>The pvMsgEncodeInfo parameter is the address of a CMSG_ENVELOPED_ENCODE_INFO structure that contains the encoding information.</term>
	/// </item>
	/// <item>
	/// <term>CMSG_SIGNED_AND_ENVELOPED</term>
	/// <term>This value is not currently implemented.</term>
	/// </item>
	/// <item>
	/// <term>CMSG_HASHED</term>
	/// <term>The pvMsgEncodeInfo parameter is the address of a CMSG_HASHED_ENCODE_INFO structure that contains the encoding information.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pvMsgEncodeInfo">
	/// The address of a structure that contains the encoding information. The type of data depends on the value of the dwMsgType
	/// parameter. For details, see dwMsgType.
	/// </param>
	/// <param name="pszInnerContentObjID">
	/// <para>
	/// If CryptMsgCalculateEncodedLength is called and the data for CryptMsgUpdate has already been message encoded, the appropriate
	/// object identifier (OID) is passed in pszInnerContentObjID. If pszInnerContentObjID is <c>NULL</c>, then the inner content type
	/// is assumed not to have been previously encoded and is therefore encoded as an octet string and given the type CMSG_DATA.
	/// </para>
	/// <para><c>Note</c> When streaming is being used, pszInnerContentObjID must be either <c>NULL</c> or szOID_RSA_data.</para>
	/// <para>
	/// The following algorithm OIDs are commonly used. A user can define new inner content usage by ensuring that the sender and
	/// receiver of the message agree upon the semantics associated with the OID.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>szOID_RSA_data</term>
	/// </item>
	/// <item>
	/// <term>szOID_RSA_signedData</term>
	/// </item>
	/// <item>
	/// <term>szOID_RSA_envelopedData</term>
	/// </item>
	/// <item>
	/// <term>szOID_RSA_signEnvData</term>
	/// </item>
	/// <item>
	/// <term>szOID_RSA_digestedData</term>
	/// </item>
	/// <item>
	/// <term>szOID_RSA_encryptedData</term>
	/// </item>
	/// <item>
	/// <term>SPC_INDIRECT_DATA_OBJID</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pStreamInfo">
	/// <para>
	/// When streaming is being used, this parameter is the address of a CMSG_STREAM_INFO structure. The callback function specified by
	/// the <c>pfnStreamOutput</c> member of the <c>CMSG_STREAM_INFO</c> structure is called when CryptMsgUpdate is executed. The
	/// callback is passed the encoded bytes that result from the encoding. For more information about how to use the callback, see <c>CMSG_STREAM_INFO</c>.
	/// </para>
	/// <para>
	/// <c>Note</c> When streaming is being used, the application must not release any data handles that are passed in the
	/// pvMsgEncodeInfo parameter, such as the provider handle in the <c>hCryptProv</c> member of the CMSG_SIGNER_ENCODE_INFO structure,
	/// until after the message handle returned by this function is closed by using the CryptMsgClose function.
	/// </para>
	/// <para>When streaming is not being used, this parameter is set to</para>
	/// <para>NULL</para>
	/// <para>.</para>
	/// <para>
	/// Streaming is not used with the <c>CMSG_HASHED</c> message type. When dealing with hashed data, this parameter must be set to <c>NULL</c>.
	/// </para>
	/// <para>
	/// Consider the case of a signed message being enclosed in an enveloped message. The encoded output from the streamed encoding of
	/// the signed message feeds into another streaming encoding of the enveloped message. The callback for the streaming encoding calls
	/// CryptMsgUpdate to encode the enveloped message. The callback for the enveloped message receives the encoded bytes of the nested
	/// signed message.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, it returns a handle to the opened message. This handle must be closed when it is no longer needed by
	/// passing it to the CryptMsgClose function.
	/// </para>
	/// <para>If this function fails, <c>NULL</c> is returned.</para>
	/// <para>To retrieve extended error information, use the GetLastError function.</para>
	/// <para>The following table lists the error codes most commonly returned by the GetLastError function.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_E_INVALID_MSG_TYPE</term>
	/// <term>The message type is not valid.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_E_OID_FORMAT</term>
	/// <term>The OID is badly formatted.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_E_UNKNOWN_ALGO</term>
	/// <term>The cryptographic algorithm is unknown.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One or more arguments are not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>There is not enough memory.</term>
	/// </item>
	/// </list>
	/// <para>In addition, if dwMsgType is CMSG_SIGNED, errors can be propagated from CryptCreateHash.</para>
	/// <para>If dwMsgType is CMSG_ENVELOPED, errors can be propagated from CryptGenKey, CryptImportKey, and CryptExportKey.</para>
	/// <para>If dwMsgType is CMSG_HASHED, errors can be propagated from CryptCreateHash.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// For functions that perform encryption, the encrypted symmetric keys are reversed from little-endian format to big-endian format
	/// after CryptExportKey is called internally. For functions that perform decryption, the encrypted symmetric keys are reversed from
	/// big-endian format to little-endian format before CryptImportKey is called.
	/// </para>
	/// <para>CRYPT_NO_SALT is specified when symmetric keys are generated and imported with CryptGenKey and CryptImportKey.</para>
	/// <para>
	/// Messages encrypted with the RC2 encryption algorithm use KP_EFFECTIVE_KEYLEN with CryptGetKeyParam to determine the effective
	/// key length of the RC2 key importing or exporting keys.
	/// </para>
	/// <para>
	/// For messages encrypted with the RC2 encryption algorithm, encode and decode operations have been updated to handle ASN RC2
	/// parameters for the <c>ContentEncryptionAlgorithm</c> member of the CMSG_ENVELOPED_ENCODE_INFO structure.
	/// </para>
	/// <para>
	/// For messages encrypted with the RC4, DES, and 3DES encryption algorithms, encode and decode operations now handle the ASN IV
	/// octet string parameter for the <c>ContentEncryptionAlgorithm</c> member of the CMSG_ENVELOPED_ENCODE_INFO structure.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// For examples that use this function, see Example C Program: Signing, Encoding, Decoding, and Verifying a Message, Alternate Code
	/// for Encoding an Enveloped Message, Example C Program: Encoding an Enveloped, Signed Message, and Example C Program: Encoding and
	/// Decoding a Hashed Message.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptmsgopentoencode HCRYPTMSG CryptMsgOpenToEncode(
	// DWORD dwMsgEncodingType, DWORD dwFlags, DWORD dwMsgType, void const *pvMsgEncodeInfo, LPSTR pszInnerContentObjID,
	// PCMSG_STREAM_INFO pStreamInfo );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "b0d2610b-05ba-4fb6-8f38-10f970a52091")]
	public static extern SafeHCRYPTMSG CryptMsgOpenToEncode(CertEncodingType dwMsgEncodingType, CryptMsgFlags dwFlags, CryptMsgType dwMsgType, [In] IntPtr pvMsgEncodeInfo,
		[Optional] SafeOID pszInnerContentObjID, in CMSG_STREAM_INFO pStreamInfo);

	/// <summary>
	/// The <c>CryptMsgOpenToEncode</c> function opens a cryptographic message for encoding and returns a handle of the opened message.
	/// The message remains open until CryptMsgClose is called.
	/// </summary>
	/// <param name="dwMsgEncodingType">
	/// <para>
	/// Specifies the encoding type used. It is always acceptable to specify both the certificate and message encoding types by
	/// combining them with a bitwise- <c>OR</c> operation as shown in the following example:
	/// </para>
	/// <para>X509_ASN_ENCODING | PKCS_7_ASN_ENCODING</para>
	/// <para>Currently defined encoding types are:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>X509_ASN_ENCODING</term>
	/// </item>
	/// <item>
	/// <term>PKCS_7_ASN_ENCODING</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwFlags">
	/// <para>Currently defined dwFlags are shown in the following table.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CMSG_BARE_CONTENT_FLAG</term>
	/// <term>
	/// The streamed output will not have an outer ContentInfo wrapper (as defined by PKCS #7). This makes it suitable to be streamed
	/// into an enclosing message.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CMSG_DETACHED_FLAG</term>
	/// <term>There is detached data being supplied for the subsequent calls to CryptMsgUpdate.</term>
	/// </item>
	/// <item>
	/// <term>CMSG_AUTHENTICATED_ATTRIBUTES_FLAG</term>
	/// <term>
	/// Authenticated attributes are forced to be included in the SignerInfo (as defined by PKCS #7) in cases where they would not
	/// otherwise be required.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CMSG_CONTENTS_OCTETS_FLAG</term>
	/// <term>
	/// Used when calculating the size of a message that has been encoded by using Distinguished Encoding Rules (DER) and that is nested
	/// inside an enveloped message. This is particularly useful when performing streaming.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CMSG_CMS_ENCAPSULATED_CONTENT_FLAG</term>
	/// <term>
	/// When set, non-data type-inner content is encapsulated within an OCTET STRING. Applicable to both signed and enveloped messages.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CMSG_CRYPT_RELEASE_CONTEXT_FLAG</term>
	/// <term>
	/// If set, the hCryptProv that is passed to this function is released on the final CryptMsgUpdate. The handle is not released if
	/// the function fails.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="dwMsgType">
	/// <para>Indicates the message type. This must be one of the following values.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CMSG_DATA</term>
	/// <term>This value is not used.</term>
	/// </item>
	/// <item>
	/// <term>CMSG_SIGNED</term>
	/// <term>The pvMsgEncodeInfo parameter is the address of a CMSG_SIGNED_ENCODE_INFO structure that contains the encoding information.</term>
	/// </item>
	/// <item>
	/// <term>CMSG_ENVELOPED</term>
	/// <term>The pvMsgEncodeInfo parameter is the address of a CMSG_ENVELOPED_ENCODE_INFO structure that contains the encoding information.</term>
	/// </item>
	/// <item>
	/// <term>CMSG_SIGNED_AND_ENVELOPED</term>
	/// <term>This value is not currently implemented.</term>
	/// </item>
	/// <item>
	/// <term>CMSG_HASHED</term>
	/// <term>The pvMsgEncodeInfo parameter is the address of a CMSG_HASHED_ENCODE_INFO structure that contains the encoding information.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pvMsgEncodeInfo">
	/// The address of a structure that contains the encoding information. The type of data depends on the value of the dwMsgType
	/// parameter. For details, see dwMsgType.
	/// </param>
	/// <param name="pszInnerContentObjID">
	/// <para>
	/// If CryptMsgCalculateEncodedLength is called and the data for CryptMsgUpdate has already been message encoded, the appropriate
	/// object identifier (OID) is passed in pszInnerContentObjID. If pszInnerContentObjID is <c>NULL</c>, then the inner content type
	/// is assumed not to have been previously encoded and is therefore encoded as an octet string and given the type CMSG_DATA.
	/// </para>
	/// <para><c>Note</c> When streaming is being used, pszInnerContentObjID must be either <c>NULL</c> or szOID_RSA_data.</para>
	/// <para>
	/// The following algorithm OIDs are commonly used. A user can define new inner content usage by ensuring that the sender and
	/// receiver of the message agree upon the semantics associated with the OID.
	/// </para>
	/// <list type="bullet">
	/// <item>
	/// <term>szOID_RSA_data</term>
	/// </item>
	/// <item>
	/// <term>szOID_RSA_signedData</term>
	/// </item>
	/// <item>
	/// <term>szOID_RSA_envelopedData</term>
	/// </item>
	/// <item>
	/// <term>szOID_RSA_signEnvData</term>
	/// </item>
	/// <item>
	/// <term>szOID_RSA_digestedData</term>
	/// </item>
	/// <item>
	/// <term>szOID_RSA_encryptedData</term>
	/// </item>
	/// <item>
	/// <term>SPC_INDIRECT_DATA_OBJID</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pStreamInfo">
	/// <para>
	/// When streaming is being used, this parameter is the address of a CMSG_STREAM_INFO structure. The callback function specified by
	/// the <c>pfnStreamOutput</c> member of the <c>CMSG_STREAM_INFO</c> structure is called when CryptMsgUpdate is executed. The
	/// callback is passed the encoded bytes that result from the encoding. For more information about how to use the callback, see <c>CMSG_STREAM_INFO</c>.
	/// </para>
	/// <para>
	/// <c>Note</c> When streaming is being used, the application must not release any data handles that are passed in the
	/// pvMsgEncodeInfo parameter, such as the provider handle in the <c>hCryptProv</c> member of the CMSG_SIGNER_ENCODE_INFO structure,
	/// until after the message handle returned by this function is closed by using the CryptMsgClose function.
	/// </para>
	/// <para>When streaming is not being used, this parameter is set to</para>
	/// <para>NULL</para>
	/// <para>.</para>
	/// <para>
	/// Streaming is not used with the <c>CMSG_HASHED</c> message type. When dealing with hashed data, this parameter must be set to <c>NULL</c>.
	/// </para>
	/// <para>
	/// Consider the case of a signed message being enclosed in an enveloped message. The encoded output from the streamed encoding of
	/// the signed message feeds into another streaming encoding of the enveloped message. The callback for the streaming encoding calls
	/// CryptMsgUpdate to encode the enveloped message. The callback for the enveloped message receives the encoded bytes of the nested
	/// signed message.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, it returns a handle to the opened message. This handle must be closed when it is no longer needed by
	/// passing it to the CryptMsgClose function.
	/// </para>
	/// <para>If this function fails, <c>NULL</c> is returned.</para>
	/// <para>To retrieve extended error information, use the GetLastError function.</para>
	/// <para>The following table lists the error codes most commonly returned by the GetLastError function.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_E_INVALID_MSG_TYPE</term>
	/// <term>The message type is not valid.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_E_OID_FORMAT</term>
	/// <term>The OID is badly formatted.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_E_UNKNOWN_ALGO</term>
	/// <term>The cryptographic algorithm is unknown.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One or more arguments are not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>There is not enough memory.</term>
	/// </item>
	/// </list>
	/// <para>In addition, if dwMsgType is CMSG_SIGNED, errors can be propagated from CryptCreateHash.</para>
	/// <para>If dwMsgType is CMSG_ENVELOPED, errors can be propagated from CryptGenKey, CryptImportKey, and CryptExportKey.</para>
	/// <para>If dwMsgType is CMSG_HASHED, errors can be propagated from CryptCreateHash.</para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// For functions that perform encryption, the encrypted symmetric keys are reversed from little-endian format to big-endian format
	/// after CryptExportKey is called internally. For functions that perform decryption, the encrypted symmetric keys are reversed from
	/// big-endian format to little-endian format before CryptImportKey is called.
	/// </para>
	/// <para>CRYPT_NO_SALT is specified when symmetric keys are generated and imported with CryptGenKey and CryptImportKey.</para>
	/// <para>
	/// Messages encrypted with the RC2 encryption algorithm use KP_EFFECTIVE_KEYLEN with CryptGetKeyParam to determine the effective
	/// key length of the RC2 key importing or exporting keys.
	/// </para>
	/// <para>
	/// For messages encrypted with the RC2 encryption algorithm, encode and decode operations have been updated to handle ASN RC2
	/// parameters for the <c>ContentEncryptionAlgorithm</c> member of the CMSG_ENVELOPED_ENCODE_INFO structure.
	/// </para>
	/// <para>
	/// For messages encrypted with the RC4, DES, and 3DES encryption algorithms, encode and decode operations now handle the ASN IV
	/// octet string parameter for the <c>ContentEncryptionAlgorithm</c> member of the CMSG_ENVELOPED_ENCODE_INFO structure.
	/// </para>
	/// <para>Examples</para>
	/// <para>
	/// For examples that use this function, see Example C Program: Signing, Encoding, Decoding, and Verifying a Message, Alternate Code
	/// for Encoding an Enveloped Message, Example C Program: Encoding an Enveloped, Signed Message, and Example C Program: Encoding and
	/// Decoding a Hashed Message.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptmsgopentoencode HCRYPTMSG CryptMsgOpenToEncode(
	// DWORD dwMsgEncodingType, DWORD dwFlags, DWORD dwMsgType, void const *pvMsgEncodeInfo, LPSTR pszInnerContentObjID,
	// PCMSG_STREAM_INFO pStreamInfo );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "b0d2610b-05ba-4fb6-8f38-10f970a52091")]
	public static extern SafeHCRYPTMSG CryptMsgOpenToEncode(CertEncodingType dwMsgEncodingType, CryptMsgFlags dwFlags, CryptMsgType dwMsgType, [In] IntPtr pvMsgEncodeInfo,
		[Optional] SafeOID pszInnerContentObjID, IntPtr pStreamInfo = default);

	/// <summary>
	/// The <c>CryptMsgUpdate</c> function adds contents to a cryptographic message. The use of this function allows messages to be
	/// constructed piece by piece through repetitive calls of <c>CryptMsgUpdate</c>. The added message content is either encoded or
	/// decoded depending on whether the message was opened with CryptMsgOpenToEncode or CryptMsgOpenToDecode.
	/// </summary>
	/// <param name="hCryptMsg">Cryptographic message handle of the message to be updated.</param>
	/// <param name="pbData">A pointer to the buffer holding the data to be encoded or decoded.</param>
	/// <param name="cbData">Number of bytes of data in the pbData buffer.</param>
	/// <param name="fFinal">
	/// <para>
	/// Indicates that the last block of data for encoding or decoding is being processed. Correct usage of this flag is dependent upon
	/// whether the message being processed has detached data. The inclusion of detached data in a message is indicated by setting
	/// dwFlags to CMSG_DETACHED_FLAG in the call to the function that opened the message.
	/// </para>
	/// <para>
	/// If CMSG_DETACHED_FLAG was not set and the message was opened using either CryptMsgOpenToDecode or CryptMsgOpenToEncode, fFinal
	/// is set to <c>TRUE</c>, and <c>CryptMsgUpdate</c> is only called once.
	/// </para>
	/// <para>
	/// If the CMSG_DETACHED_FLAG flag was set and a message is opened using CryptMsgOpenToEncode, fFinal is set to <c>TRUE</c> only on
	/// the last call to <c>CryptMsgUpdate</c>.
	/// </para>
	/// <para>
	/// If the CMSG_DETACHED_FLAG flag was set and a message is opened using CryptMsgOpenToDecode, fFinal is set to <c>TRUE</c> when the
	/// header is processed by a single call to <c>CryptMsgUpdate</c>. It is set to <c>FALSE</c> while processing the detached data in
	/// subsequent calls to <c>CryptMsgUpdate</c> until the last detached data block is to be processed. On the last call to
	/// <c>CryptMsgUpdate</c>, it is set to <c>TRUE</c>.
	/// </para>
	/// <para>
	/// When detached data is decoded, the header and the content of a message are contained in different BLOBs. Each BLOB requires that
	/// fFinal be set to <c>TRUE</c> when the last call to the function is made for that BLOB.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero ( <c>TRUE</c>).</para>
	/// <para>If the function fails, the return value is zero ( <c>FALSE</c>). For extended error information, call GetLastError.</para>
	/// <para>
	/// Errors encountered in the application defined callback function specified by pStreamInfo in CryptMsgOpenToDecode and
	/// CryptMsgOpenToEncode might be propagated to <c>CryptMsgUpdate</c> if streaming is used. If this happens, SetLastError is not
	/// called by <c>CryptMsgUpdate</c> after the callback function returns, which preserves any errors encountered under the control of
	/// the application. It is the responsibility of the callback function (or one of the APIs that it calls) to call
	/// <c>SetLastError</c> if an error occurs while the application is processing the streamed data.
	/// </para>
	/// <para>The following table lists the error codes most commonly returned by the GetLastError function.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_E_INVALID_MSG_TYPE</term>
	/// <term>The message type is not valid.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_E_MSG_ERROR</term>
	/// <term>An error was encountered doing a cryptographic operation.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_E_OID_FORMAT</term>
	/// <term>The object identifier is badly formatted.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_E_UNEXPECTED_ENCODING</term>
	/// <term>The message is not encoded as expected.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_E_UNKNOWN_ALGO</term>
	/// <term>The cryptographic algorithm is unknown.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One or more arguments are not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>Ran out of memory.</term>
	/// </item>
	/// </list>
	/// <para>Propagated errors might be encountered from any of the following functions:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>CryptHashData</term>
	/// </item>
	/// <item>
	/// <term>CryptGetHashParam</term>
	/// </item>
	/// <item>
	/// <term>CryptSignHash</term>
	/// </item>
	/// <item>
	/// <term>CryptGetKeyParam</term>
	/// </item>
	/// <item>
	/// <term>CryptEncrypt</term>
	/// </item>
	/// <item>
	/// <term>CryptCreateHash</term>
	/// </item>
	/// </list>
	/// <para>
	/// If the function fails, GetLastError may return an Abstract Syntax Notation One (ASN.1) encoding/decoding error. For information
	/// about these errors, see ASN.1 Encoding/Decoding Return Values.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptmsgupdate BOOL CryptMsgUpdate( HCRYPTMSG hCryptMsg,
	// const BYTE *pbData, DWORD cbData, BOOL fFinal );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "d27d75f0-1646-4926-b375-59e52b00326c")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptMsgUpdate(HCRYPTMSG hCryptMsg, [In] IntPtr pbData, uint cbData, [MarshalAs(UnmanagedType.Bool)] bool fFinal);

	/// <summary>
	/// The <c>CryptMsgVerifyCountersignatureEncoded</c> function verifies a countersignature in terms of the SignerInfo structure (as
	/// defined by PKCS #7).
	/// </summary>
	/// <param name="hCryptProv">
	/// <para>This parameter is not used and should be set to <c>NULL</c>.</para>
	/// <para>
	/// <c>Windows Server 2003 and Windows XP:</c><c>NULL</c> or the handle of the cryptographic provider to use to hash the
	/// encryptedDigest field of pbSignerInfo.This parameter's data type is <c>HCRYPTPROV</c>.
	/// </para>
	/// <para>
	/// Unless there is a strong reason for passing in a specific cryptographic provider in hCryptProv, pass <c>NULL</c> to cause the
	/// default RSA or DSS provider to be used.
	/// </para>
	/// </param>
	/// <param name="dwEncodingType">
	/// <para>
	/// Specifies the encoding type used. Currently, only X509_ASN_ENCODING and PKCS_7_ASN_ENCODING are being used; however, additional
	/// encoding types may be added in the future. For either current encoding type, use:
	/// </para>
	/// <para>X509_ASN_ENCODING | PKCS_7_ASN_ENCODING.</para>
	/// </param>
	/// <param name="pbSignerInfo">A pointer to the encoded BLOB that contains the signer of the contents of a message to be countersigned.</param>
	/// <param name="cbSignerInfo">Count, in bytes, of the encoded BLOB for the signer of the contents.</param>
	/// <param name="pbSignerInfoCountersignature">A pointer to the encoded BLOB containing the countersigner information.</param>
	/// <param name="cbSignerInfoCountersignature">Count, in bytes, of the encoded BLOB for the countersigner of the message.</param>
	/// <param name="pciCountersigner">
	/// A pointer to a CERT_INFO that includes with the issuer and serial number of the countersigner. For more information, see Remarks.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero ( <c>TRUE</c>).</para>
	/// <para>If the function fails, the return value is zero ( <c>FALSE</c>). For extended error information, call GetLastError.</para>
	/// <para>The following table lists the error codes most commonly returned by the GetLastError function.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_E_AUTH_ATTR_MISSING</term>
	/// <term>The message does not contain an expected authenticated attribute.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_E_HASH_VALUE</term>
	/// <term>The hash value is not correct.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_E_UNEXPECTED_ENCODING</term>
	/// <term>The message is not encoded as expected.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_E_UNKNOWN_ALGO</term>
	/// <term>The cryptographic algorithm is unknown.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One or more arguments are not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>Ran out of memory.</term>
	/// </item>
	/// </list>
	/// <para>Propagated errors from the following functions might be returned.</para>
	/// <list type="bullet">
	/// <item>
	/// <term>CryptHashData</term>
	/// </item>
	/// <item>
	/// <term>CryptGetHashParam</term>
	/// </item>
	/// <item>
	/// <term>CryptImportKey</term>
	/// </item>
	/// <item>
	/// <term>CryptVerifySignature</term>
	/// </item>
	/// <item>
	/// <term>CryptCreateHash</term>
	/// </item>
	/// </list>
	/// <para>
	/// If the function fails, GetLastError may return an Abstract Syntax Notation One (ASN.1) encoding/decoding error. For information
	/// about these errors, see ASN.1 Encoding/Decoding Return Values.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Countersigner verification is done using the PKCS #7 <c>SIGNERINFO</c> structure. The signature must contain the encrypted hash
	/// of the encryptedDigest field of pbSignerInfo.
	/// </para>
	/// <para>
	/// The issuer and serial number of the countersigner must match the countersigner information from pbSignerInfoCountersignature.
	/// The only fields referenced from pciCountersigner are SerialNumber, Issuer, and SubjectPublicKeyInfo. The SubjectPublicKeyInfo is
	/// used to access the public key that is then used to encrypt the hash from the pciCountersigner so compare it with the hash from
	/// the pbSignerInfo.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example that uses this function, see Example C Program: Encoding and Decoding a CounterSigned Message.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptmsgverifycountersignatureencoded BOOL
	// CryptMsgVerifyCountersignatureEncoded( HCRYPTPROV_LEGACY hCryptProv, DWORD dwEncodingType, PBYTE pbSignerInfo, DWORD
	// cbSignerInfo, PBYTE pbSignerInfoCountersignature, DWORD cbSignerInfoCountersignature, PCERT_INFO pciCountersigner );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "b0332360-a737-4b48-b592-0c55d493a02d")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptMsgVerifyCountersignatureEncoded([Optional] HCRYPTPROV hCryptProv, CertEncodingType dwEncodingType, [In] IntPtr pbSignerInfo, uint cbSignerInfo,
		[In] IntPtr pbSignerInfoCountersignature, uint cbSignerInfoCountersignature, in CERT_INFO pciCountersigner);

	/// <summary>
	/// The <c>CryptMsgVerifyCountersignatureEncodedEx</c> function verifies that the pbSignerInfoCounterSignature parameter contains
	/// the encrypted hash of the <c>encryptedDigest</c> field of the pbSignerInfo parameter structure. The signer can be a
	/// CERT_PUBLIC_KEY_INFO structure, a certificate context, or a chain context.
	/// </summary>
	/// <param name="hCryptProv">
	/// <para>This parameter is not used and should be set to <c>NULL</c>.</para>
	/// <para>
	/// <c>Windows Server 2003 and Windows XP:</c><c>NULL</c> or the handle of the cryptographic provider to use to hash the
	/// encryptedDigest field of pbSignerInfo.This parameter's data type is <c>HCRYPTPROV</c>.
	/// </para>
	/// <para>
	/// Unless there is a strong reason for passing in a specific cryptographic provider in hCryptProv, pass <c>NULL</c> to cause the
	/// default RSA or DSS provider to be used.
	/// </para>
	/// </param>
	/// <param name="dwEncodingType">
	/// <para>
	/// The encoding type used. Currently, only X509_ASN_ENCODING and PKCS_7_ASN_ENCODING are being used; however, additional encoding
	/// types may be added in the future. For either current encoding type, use:
	/// </para>
	/// <para>X509_ASN_ENCODING | PKCS_7_ASN_ENCODING.</para>
	/// </param>
	/// <param name="pbSignerInfo">A pointer to the encoded BLOB that contains the signer of the contents of a message to be countersigned.</param>
	/// <param name="cbSignerInfo">The count, in bytes, of the encoded BLOB for the signer of the contents.</param>
	/// <param name="pbSignerInfoCountersignature">A pointer to the encoded BLOB containing the countersigner information.</param>
	/// <param name="cbSignerInfoCountersignature">The count, in bytes, of the encoded BLOB for the countersigner of the message.</param>
	/// <param name="dwSignerType">
	/// <para>
	/// The structure that contains the signer information. The following table shows the predefined values and the structures indicated.
	/// </para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CMSG_VERIFY_SIGNER_PUBKEY</term>
	/// <term>pvSigner is a pointer to a CERT_PUBLIC_KEY_INFO structure.</term>
	/// </item>
	/// <item>
	/// <term>CMSG_VERIFY_SIGNER_CERT</term>
	/// <term>pvSigner is a pointer to a CERT_CONTEXT structure.</term>
	/// </item>
	/// <item>
	/// <term>CMSG_VERIFY_SIGNER_CHAIN</term>
	/// <term>pvSigner is a pointer to a CERT_CHAIN_CONTEXT structure.</term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pvSigner">
	/// A pointer to a CERT_PUBLIC_KEY_INFO structure, a certificate context, or a chain context depending on the value of dwSignerType.
	/// </param>
	/// <param name="dwFlags">
	/// <para>Flags that modify the function behavior. This can be zero or the following value.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Value</term>
	/// <term>Meaning</term>
	/// </listheader>
	/// <item>
	/// <term>CMSG_VERIFY_COUNTER_SIGN_ENABLE_STRONG_FLAG 0x00000001</term>
	/// <term>
	/// Performs a strong signature check after successful signature verification. Set the pvExtra parameter to point to a
	/// CERT_STRONG_SIGN_PARA structure that contains the parameters needed to check the signature strength.. Windows 8 and Windows
	/// Server 2012: Support for this flag begins.
	/// </term>
	/// </item>
	/// </list>
	/// </param>
	/// <param name="pvExtra">
	/// If you set the dwFlags parameter to <c>CMSG_VERIFY_COUNTER_SIGN_ENABLE_STRONG_FLAG</c>, set this parameter (pvExtra) to point to
	/// a CERT_STRONG_SIGN_PARA structure that contains the parameters used to check the signature strength.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero ( <c>TRUE</c>).</para>
	/// <para>If the function fails, the return value is zero ( <c>FALSE</c>). For extended error information, call GetLastError.</para>
	/// <para>The following error codes are most commonly returned by the GetLastError function.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_E_AUTH_ATTR_MISSING</term>
	/// <term>The message does not contain an expected authenticated attribute.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_E_HASH_VALUE</term>
	/// <term>The hash value is not correct.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_E_UNEXPECTED_ENCODING</term>
	/// <term>The message is not encoded as expected.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_E_UNKNOWN_ALGO</term>
	/// <term>The cryptographic algorithm is unknown.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>One or more arguments are not valid.</term>
	/// </item>
	/// <item>
	/// <term>E_OUTOFMEMORY</term>
	/// <term>Ran out of memory.</term>
	/// </item>
	/// </list>
	/// <para>Propagated errors from the following functions might be returned.</para>
	/// <list type="bullet">
	/// <item>
	/// <term>CryptHashData</term>
	/// </item>
	/// <item>
	/// <term>CryptGetHashParam</term>
	/// </item>
	/// <item>
	/// <term>CryptImportKey</term>
	/// </item>
	/// <item>
	/// <term>CryptVerifySignature</term>
	/// </item>
	/// <item>
	/// <term>CryptCreateHash</term>
	/// </item>
	/// </list>
	/// <para>
	/// If the function fails, GetLastError may return an Abstract Syntax Notation One (ASN.1) encoding/decoding error. For information
	/// about these errors, see ASN.1 Encoding/Decoding Return Values.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// Countersigner verification is done using the PKCS #7 <c>SIGNERINFO</c> structure. The signature must contain the encrypted hash
	/// of the encryptedDigest field of pbSignerInfo.
	/// </para>
	/// <para>
	/// The issuer and serial number of the countersigner must match the countersigner information from pbSignerInfoCountersignature.
	/// The only fields referenced from pciCountersigner are SerialNumber, Issuer, and SubjectPublicKeyInfo. The SubjectPublicKeyInfo is
	/// used to access the public key that is then used to encrypt the hash from the pciCountersigner so compare it with the hash from
	/// the pbSignerInfo.
	/// </para>
	/// <para>Examples</para>
	/// <para>For an example that uses this function, see Example C Program: Encoding and Decoding a CounterSigned Message.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptmsgverifycountersignatureencodedex BOOL
	// CryptMsgVerifyCountersignatureEncodedEx( HCRYPTPROV_LEGACY hCryptProv, DWORD dwEncodingType, PBYTE pbSignerInfo, DWORD
	// cbSignerInfo, PBYTE pbSignerInfoCountersignature, DWORD cbSignerInfoCountersignature, DWORD dwSignerType, void *pvSigner, DWORD
	// dwFlags, void *pvExtra );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "da756cd5-1dec-4d88-9c90-76dd263035eb")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptMsgVerifyCountersignatureEncodedEx([Optional] HCRYPTPROV hCryptProv, CertEncodingType dwEncodingType, [In] IntPtr pbSignerInfo, uint cbSignerInfo,
		[In] IntPtr pbSignerInfoCountersignature, uint cbSignerInfoCountersignature, CryptMsgSignerType dwSignerType, IntPtr pvSigner, CryptMsgVerifyCounterFlags dwFlags, [Optional] IntPtr pvExtra);

	/// <summary>
	/// The <c>CryptSignAndEncryptMessage</c> function creates a hash of the specified content, signs the hash, encrypts the content,
	/// hashes the encrypted contents and the signed hash, and then encodes both the encrypted content and the signed hash. The result
	/// is the same as if the hash were first signed and then encrypted.
	/// </summary>
	/// <param name="pSignPara">A pointer to a CRYPT_SIGN_MESSAGE_PARA structure that contains the signature parameters.</param>
	/// <param name="pEncryptPara">A pointer to a CRYPT_ENCRYPT_MESSAGE_PARA structure containing encryption parameters.</param>
	/// <param name="cRecipientCert">Number of array elements in rgpRecipientCert.</param>
	/// <param name="rgpRecipientCert">
	/// Array of pointers to CERT_CONTEXT structures. Each structure is the certificate of an intended recipients of the message.
	/// </param>
	/// <param name="pbToBeSignedAndEncrypted">A pointer to a buffer containing the content to be signed and encrypted.</param>
	/// <param name="cbToBeSignedAndEncrypted">The size, in bytes, of the pbToBeSignedAndEncrypted buffer.</param>
	/// <param name="pbSignedAndEncryptedBlob">
	/// <para>A pointer to a buffer to receive the encrypted and encoded message.</para>
	/// <para>
	/// This parameter can be <c>NULL</c> to set the size of this information for memory allocation purposes. For more information, see
	/// Retrieving Data of Unknown Length.
	/// </para>
	/// </param>
	/// <param name="pcbSignedAndEncryptedBlob">
	/// <para>
	/// A pointer to <c>DWORD</c> specifying the size, in bytes, of the buffer pointed to by pbSignedAndEncryptedBlob. When the function
	/// returns, this variable contains the size, in bytes, of the signed and encrypted message copied to *pbSignedAndEncryptedBlob.
	/// </para>
	/// <para>
	/// <c>Note</c> When processing the data returned, applications must use the actual size of the data returned. The actual size can
	/// be slightly smaller than the size of the buffer specified on input. (On input, buffer sizes are usually specified large enough
	/// to ensure that the largest possible output data will fit in the buffer.) On output, the variable pointed to by this parameter is
	/// updated to reflect the actual size of the data copied to the buffer.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero (TRUE).</para>
	/// <para>If the function fails, the return value is zero (FALSE).</para>
	/// <para>For extended error information, call GetLastError.</para>
	/// <para>The following lists the error code most commonly returned by the GetLastError function.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>
	/// If the buffer specified by the pbSignedAndEncryptedBlob parameter is not large enough to hold the returned data, the function
	/// sets the ERROR_MORE_DATA code, and stores the required buffer size, in bytes, into the variable pointed to by pcbSignedAndEncryptedBlob.
	/// </term>
	/// </item>
	/// </list>
	/// <para><c>Note</c> Errors from the called functions CryptSignMessage and CryptEncryptMessage might be propagated to this function.</para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptsignandencryptmessage BOOL
	// CryptSignAndEncryptMessage( PCRYPT_SIGN_MESSAGE_PARA pSignPara, PCRYPT_ENCRYPT_MESSAGE_PARA pEncryptPara, DWORD cRecipientCert,
	// PCCERT_CONTEXT [] rgpRecipientCert, const BYTE *pbToBeSignedAndEncrypted, DWORD cbToBeSignedAndEncrypted, BYTE
	// *pbSignedAndEncryptedBlob, DWORD *pcbSignedAndEncryptedBlob );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "0ab234f2-a681-463f-8ba8-b23b05cf2626")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptSignAndEncryptMessage(in CRYPT_SIGN_MESSAGE_PARA pSignPara, in CRYPT_ENCRYPT_MESSAGE_PARA pEncryptPara, uint cRecipientCert,
		[In, MarshalAs(UnmanagedType.LPArray)] PCCERT_CONTEXT[] rgpRecipientCert, [In] IntPtr pbToBeSignedAndEncrypted, uint cbToBeSignedAndEncrypted,
		[Out] IntPtr pbSignedAndEncryptedBlob, ref uint pcbSignedAndEncryptedBlob);

	/// <summary>
	/// The <c>CryptSignMessage</c> function creates a hash of the specified content, signs the hash, and then encodes both the original
	/// message content and the signed hash.
	/// </summary>
	/// <param name="pSignPara">A pointer to CRYPT_SIGN_MESSAGE_PARA structure containing the signature parameters.</param>
	/// <param name="fDetachedSignature">
	/// <c>TRUE</c> if this is to be a detached signature. Otherwise, <c>FALSE</c>. If this parameter is set to <c>TRUE</c>, only the
	/// signed hash is encoded in pbSignedBlob. Otherwise, both rgpbToBeSigned and the signed hash are encoded.
	/// </param>
	/// <param name="cToBeSigned">
	/// Count of the number of array elements in rgpbToBeSigned and rgpbToBeSigned. This parameter must be set to one unless
	/// fDetachedSignature is set to <c>TRUE</c>.
	/// </param>
	/// <param name="rgpbToBeSigned">Array of pointers to buffers that contain the contents to be signed.</param>
	/// <param name="rgcbToBeSigned">Array of sizes, in bytes, of the content buffers pointed to in rgpbToBeSigned.</param>
	/// <param name="pbSignedBlob">
	/// <para>
	/// A pointer to a buffer to receive the encoded signed hash, if fDetachedSignature is <c>TRUE</c>, or to both the encoded content
	/// and signed hash if fDetachedSignature is <c>FALSE</c>.
	/// </para>
	/// <para>
	/// This parameter can be <c>NULL</c> to set the size of this information for memory allocation purposes. For more information, see
	/// Retrieving Data of Unknown Length.
	/// </para>
	/// </param>
	/// <param name="pcbSignedBlob">
	/// <para>
	/// A pointer to a <c>DWORD</c> specifying the size, in bytes, of the pbSignedBlob buffer. When the function returns, this variable
	/// contains the size, in bytes, of the signed and encoded message.
	/// </para>
	/// <para>
	/// <c>Note</c> When processing the data returned, applications must use the actual size of the data returned. The actual size can
	/// be slightly smaller than the size of the buffer specified on input. (On input, buffer sizes are usually specified large enough
	/// to ensure that the largest possible output data will fit in the buffer.) On output, the variable pointed to by this parameter is
	/// updated to reflect the actual size of the data copied to the buffer.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero ( <c>TRUE</c>).</para>
	/// <para>If the function fails, the return value is zero ( <c>FALSE</c>).</para>
	/// <para>For extended error information, call GetLastError.</para>
	/// <para>The following lists the error codes most commonly returned by the GetLastError function.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>
	/// If the buffer specified by the pbSignedBlob parameter is not large enough to hold the returned data, the function sets the
	/// ERROR_MORE_DATA code, and stores the required buffer size, in bytes, into the variable pointed to by pcbSignedBlob.
	/// </term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>
	/// The message encoding type is not valid. Currently only PKCS_7_ASN_ENCODING is supported. The cbSize in *pSignPara is not valid.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_E_NO_KEY_PROPERTY</term>
	/// <term>The pSigningCert in *pSignPara does not have a CERT_KEY_PROV_INFO_PROP_ID or CERT_KEY_CONTEXT_PROP_ID property.</term>
	/// </item>
	/// </list>
	/// <para>
	/// <c>Note</c> Errors from the called functions CryptCreateHash, CryptHashData, and CryptSignHash might be propagated to this function.
	/// </para>
	/// <para>
	/// If the function fails, GetLastError may return an Abstract Syntax Notation One (ASN.1) encoding/decoding error. For information
	/// about these errors, see ASN.1 Encoding/Decoding Return Values.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptsignmessage BOOL CryptSignMessage(
	// PCRYPT_SIGN_MESSAGE_PARA pSignPara, BOOL fDetachedSignature, DWORD cToBeSigned, const BYTE * [] rgpbToBeSigned, DWORD []
	// rgcbToBeSigned, BYTE *pbSignedBlob, DWORD *pcbSignedBlob );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "f14f7c7b-14ac-40a7-9a49-d1a899ecc52a")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptSignMessage(in CRYPT_SIGN_MESSAGE_PARA pSignPara, [MarshalAs(UnmanagedType.Bool)] bool fDetachedSignature, uint cToBeSigned,
		[In, MarshalAs(UnmanagedType.LPArray)] IntPtr[] rgpbToBeSigned, [In] uint[] rgcbToBeSigned, [Out] IntPtr pbSignedBlob, ref uint pcbSignedBlob);

	/// <summary>
	/// The <c>CryptSignMessageWithKey</c> function signs a message by using a CSP's private key specified in the parameters. A
	/// placeholder <c>SignerId</c> is created and stored in the message.
	/// </summary>
	/// <param name="pSignPara">A pointer to a CRYPT_KEY_SIGN_MESSAGE_PARA structure that contains the signature parameters.</param>
	/// <param name="pbToBeSigned">A pointer to a buffer array that contains the message to be signed.</param>
	/// <param name="cbToBeSigned">The number of array elements in the pbToBeSigned buffer array.</param>
	/// <param name="pbSignedBlob">
	/// <para>A pointer to a buffer to receive the encoded signed message.</para>
	/// <para>
	/// This parameter can be <c>NULL</c> to set the size of this information for memory allocation purposes. For more information, see
	/// Retrieving Data of Unknown Length.
	/// </para>
	/// </param>
	/// <param name="pcbSignedBlob">
	/// <para>
	/// A pointer to a <c>DWORD</c> value that indicates the size, in bytes, of the pbSignedBlob buffer. When the function returns, this
	/// variable contains the size, in bytes, of the signed and encoded message.
	/// </para>
	/// <para>
	/// <c>Note</c> When processing the data returned, applications must use the actual size of the data returned. The actual size can
	/// be slightly smaller than the size of the buffer specified on input. (On input, buffer sizes are usually specified large enough
	/// to ensure that the largest possible output data will fit in the buffer.) On output, the variable pointed to by this parameter is
	/// updated to reflect the actual size of the data copied to the buffer.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero (TRUE).</para>
	/// <para>If the function fails, the return value is zero (FALSE).</para>
	/// <para>For extended error information, call GetLastError.</para>
	/// <para>The following lists the error codes most commonly returned by the GetLastError function.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>
	/// If the buffer specified by the pbSignedBlob parameter is not large enough to hold the returned data, the function sets the
	/// ERROR_MORE_DATA code and stores the required buffer size, in bytes, into the variable pointed to by pcbSignedBlob.
	/// </term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>
	/// The message encoding type is not valid. Currently only PKCS_7_ASN_ENCODING is supported. The cbSize in *pSignPara is not valid.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_E_NO_KEY_PROPERTY</term>
	/// <term>The pSigningCert in *pSignPara does not have a CERT_KEY_PROV_INFO_PROP_ID or CERT_KEY_CONTEXT_PROP_ID property.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptsignmessagewithkey BOOL CryptSignMessageWithKey(
	// PCRYPT_KEY_SIGN_MESSAGE_PARA pSignPara, const BYTE *pbToBeSigned, DWORD cbToBeSigned, BYTE *pbSignedBlob, DWORD *pcbSignedBlob );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "d31024bf-7022-440b-8134-a02578510357")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptSignMessageWithKey(in CRYPT_KEY_SIGN_MESSAGE_PARA pSignPara, [In] IntPtr pbToBeSigned, uint cbToBeSigned, [Out] IntPtr pbSignedBlob, ref uint pcbSignedBlob);

	/// <summary>The <c>CryptVerifyDetachedMessageHash</c> function verifies a detached hash.</summary>
	/// <param name="pHashPara">A pointer to a CRYPT_HASH_MESSAGE_PARA structure containing the hash parameters.</param>
	/// <param name="pbDetachedHashBlob">A pointer to the encoded, detached hash.</param>
	/// <param name="cbDetachedHashBlob">The size, in bytes, of the detached hash.</param>
	/// <param name="cToBeHashed">Number of elements in the rgpbToBeHashed and rgcbToBeHashed arrays.</param>
	/// <param name="rgpbToBeHashed">Array of pointers to content buffers to be hashed.</param>
	/// <param name="rgcbToBeHashed">
	/// Array of sizes, in bytes, for the content buffers pointed to by the elements of the rgcbToBeHashed array.
	/// </param>
	/// <param name="pbComputedHash">
	/// <para>A pointer to a buffer to receive the computed hash.</para>
	/// <para>
	/// This parameter can be <c>NULL</c> if the newly created hash is not needed for additional processing, or to set the size of the
	/// hash for memory allocation purposes. For more information, see Retrieving Data of Unknown Length.
	/// </para>
	/// </param>
	/// <param name="pcbComputedHash">
	/// <para>
	/// A pointer to a <c>DWORD</c> specifying the size, in bytes, of the pbComputedHash buffer. When the function returns, this
	/// <c>DWORD</c> contains the size, in bytes, of the created hash. The hash will not be returned if this parameter is <c>NULL</c>.
	/// </para>
	/// <para>
	/// <c>Note</c> When processing the data returned , applications must use the actual size of the data returned. The actual size can
	/// be slightly smaller than the size of the buffer specified on input. (On input, buffer sizes are usually specified large enough
	/// to ensure that the largest possible output data will fit in the buffer.) On output, the variable pointed to by this parameter is
	/// updated to reflect the actual size of the data copied to the buffer.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero (TRUE).</para>
	/// <para>If the function fails, the return value is zero (FALSE).</para>
	/// <para>For extended error information, call GetLastError.</para>
	/// <para>The following lists the error codes most commonly returned by the GetLastError function.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_E_UNEXPECTED_MSG_TYPE</term>
	/// <term>Not a hashed cryptographic message.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>
	/// The message encoding type is not valid. Currently only PKCS_7_ASN_ENCODING is supported. The cbSize in *pHashPara is not valid.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>
	/// If the buffer specified by the pbComputedHash parameter is not large enough to hold the returned data, the function sets the
	/// ERROR_MORE_DATA code, and stores the required buffer size, in bytes, into the variable pointed to by pcbComputedHash.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// <c>Note</c> Errors from the called functions CryptCreateHash, CryptHashData, and CryptGetHashParam might be propagated to this
	/// function. If the function fails, GetLastError may return an Abstract Syntax Notation One (ASN.1) encoding/decoding error. For
	/// information about these errors, see ASN.1 Encoding/Decoding Return Values.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptverifydetachedmessagehash BOOL
	// CryptVerifyDetachedMessageHash( PCRYPT_HASH_MESSAGE_PARA pHashPara, BYTE *pbDetachedHashBlob, DWORD cbDetachedHashBlob, DWORD
	// cToBeHashed, const BYTE * [] rgpbToBeHashed, DWORD [] rgcbToBeHashed, BYTE *pbComputedHash, DWORD *pcbComputedHash );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "b529b9e2-9798-4548-a44f-c330524a3e6b")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptVerifyDetachedMessageHash(in CRYPT_HASH_MESSAGE_PARA pHashPara, [In] IntPtr pbDetachedHashBlob, uint cbDetachedHashBlob,
		uint cToBeHashed, [In, MarshalAs(UnmanagedType.LPArray)] IntPtr[] rgpbToBeHashed, [In] uint[] rgcbToBeHashed, [Out] IntPtr pbComputedHash, ref uint pcbComputedHash);

	/// <summary>
	/// The <c>CryptVerifyDetachedMessageSignature</c> function verifies a signed message containing a detached signature or signatures.
	/// </summary>
	/// <param name="pVerifyPara">A pointer to a CRYPT_VERIFY_MESSAGE_PARA structure containing the verification parameters.</param>
	/// <param name="dwSignerIndex">
	/// Index of the signature to be verified. A message might have several signers and this function can be called repeatedly, changing
	/// dwSignerIndex to verify other signatures. If the function returns FALSE, and GetLastError returns CRYPT_E_NO_SIGNER, the
	/// previous call received the last signer of the message.
	/// </param>
	/// <param name="pbDetachedSignBlob">A pointer to a BLOB containing the encoded message signatures.</param>
	/// <param name="cbDetachedSignBlob">The size, in bytes, of the detached signature.</param>
	/// <param name="cToBeSigned">Number of array elements in rgpbToBeSigned and rgcbToBeSigned.</param>
	/// <param name="rgpbToBeSigned">Array of pointers to buffers containing the contents to be hashed.</param>
	/// <param name="rgcbToBeSigned">Array of sizes, in bytes, for the content buffers pointed to in rgpbToBeSigned.</param>
	/// <param name="ppSignerCert">
	/// A pointer to a pointer to a CERT_CONTEXT structure of a signer certificate. When you have finished using the certificate
	/// context, free it by calling the CertFreeCertificateContext function. A pointer to a <c>CERT_CONTEXT</c> structure will not be
	/// returned if this parameter is <c>NULL</c>.
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero (TRUE).</para>
	/// <para>If the function fails, the return value is zero ( <c>FALSE</c>).</para>
	/// <para>For extended error information, call GetLastError.</para>
	/// <para>The following lists the error codes most commonly returned by the GetLastError function.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>
	/// Invalid message and certificate encoding types. Currently only PKCS_7_ASN_ENCODING and X509_ASN_ENCODING_TYPE are supported.
	/// Invalid cbSize in *pVerifyPara.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_E_UNEXPECTED_MSG_TYPE</term>
	/// <term>Not a signed cryptographic message.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_E_NO_SIGNER</term>
	/// <term>The message does not have any signers or a signer for the specified dwSignerIndex.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_ALGID</term>
	/// <term>The message was hashed and signed by using an unknown or unsupported algorithm.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_SIGNATURE</term>
	/// <term>The message's signature was not verified.</term>
	/// </item>
	/// </list>
	/// <para>
	/// <c>Note</c> Errors from the called functions CryptCreateHash, CryptHashData, CryptVerifySignature, and CryptImportKey might be
	/// propagated to this function.If the function fails, GetLastError may return an Abstract Syntax Notation One (ASN.1)
	/// encoding/decoding error. For information about these errors, see ASN.1 Encoding/Decoding Return Values.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptverifydetachedmessagesignature BOOL
	// CryptVerifyDetachedMessageSignature( PCRYPT_VERIFY_MESSAGE_PARA pVerifyPara, DWORD dwSignerIndex, const BYTE *pbDetachedSignBlob,
	// DWORD cbDetachedSignBlob, DWORD cToBeSigned, const BYTE * [] rgpbToBeSigned, DWORD [] rgcbToBeSigned, PCCERT_CONTEXT
	// *ppSignerCert );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "d437f6bf-eb56-4d29-bb91-eb8487e50219")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptVerifyDetachedMessageSignature(in CRYPT_VERIFY_MESSAGE_PARA pVerifyPara, uint dwSignerIndex, [In] IntPtr pbDetachedSignBlob, uint cbDetachedSignBlob,
		uint cToBeSigned, [In, MarshalAs(UnmanagedType.LPArray)] IntPtr[] rgpbToBeSigned, [In] uint[] rgcbToBeSigned, out SafePCCERT_CONTEXT ppSignerCert);

	/// <summary>The <c>CryptVerifyMessageHash</c> function verifies the hash of specified content.</summary>
	/// <param name="pHashPara">A pointer to a CRYPT_HASH_MESSAGE_PARA structure containing hash parameters.</param>
	/// <param name="pbHashedBlob">A pointer to a buffer containing original content and its hash.</param>
	/// <param name="cbHashedBlob">The size, in bytes, of the original hash buffer.</param>
	/// <param name="pbToBeHashed">
	/// <para>A pointer to a buffer to receive the original content that was hashed.</para>
	/// <para>
	/// This parameter can be <c>NULL</c> if the original content is not needed for additional processing, or to set the size of the
	/// original content for memory allocation purposes. For more information, see Retrieving Data of Unknown Length.
	/// </para>
	/// </param>
	/// <param name="pcbToBeHashed">
	/// <para>
	/// A pointer to a <c>DWORD</c> specifying the size, in bytes, of the pbToBeHashed buffer. When the function returns, this variable
	/// contains the size, in bytes, of the original content copied to pbToBeHashed. The original content will not be returned if this
	/// parameter is <c>NULL</c>.
	/// </para>
	/// <para>
	/// <c>Note</c> When processing the data returned, applications must use the actual size of the data returned. The actual size can
	/// be slightly smaller than the size of the buffer specified on input. (On input, buffer sizes are usually specified large enough
	/// to ensure that the largest possible output data will fit in the buffer.) On output, the variable pointed to by this parameter is
	/// updated to reflect the actual size of the data copied to the buffer.
	/// </para>
	/// </param>
	/// <param name="pbComputedHash">
	/// A pointer to a buffer to receive the computed hash. This parameter can be <c>NULL</c> if the created hash is not needed for
	/// additional processing, or to set the size of the original content for memory allocation purposes. For more information, see
	/// Retrieving Data of Unknown Length.
	/// </param>
	/// <param name="pcbComputedHash">
	/// <para>
	/// A pointer to a <c>DWORD</c> specifying the size, in bytes, of the pbComputedHash buffer. When the function returns, this
	/// variable contains the size, in bytes, of the created hash. The hash is not returned if this parameter is <c>NULL</c>.
	/// </para>
	/// <para>
	/// <c>Note</c> When processing the data returned, applications must use the actual size of the data returned. The actual size can
	/// be slightly smaller than the size of the buffer specified on input. (On input, buffer sizes are usually specified large enough
	/// to ensure that the largest possible output data will fit in the buffer.) On output, the variable pointed to by this parameter is
	/// updated to reflect the actual size of the data copied to the buffer.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is nonzero (TRUE).</para>
	/// <para>If the function fails, the return value is zero (FALSE).</para>
	/// <para>For extended error information, call GetLastError.</para>
	/// <para>The following lists the error codes most commonly returned by the GetLastError function.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>CRYPT_E_UNEXPECTED_MSG_TYPE</term>
	/// <term>Not a hashed cryptographic message.</term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>
	/// The message encoding type is not valid. Currently only PKCS_7_ASN_ENCODING is supported. The cbSize in *pHashPara is not valid.
	/// </term>
	/// </item>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>
	/// If the buffer specified by the pbToBeHashed parameter is not large enough to hold the returned data, the function sets the
	/// ERROR_MORE_DATA code, and stores the required buffer size, in bytes, into the variable pointed to by pcbToBeHashed.
	/// </term>
	/// </item>
	/// </list>
	/// <para>
	/// <c>Note</c> Errors from the called functions CryptCreateHash, CryptHashData, and CryptGetHashParam might be propagated to this
	/// function. If the function fails, GetLastError may return an Abstract Syntax Notation One (ASN.1) encoding/decoding error. For
	/// information about these errors, see ASN.1 Encoding/Decoding Return Values.
	/// </para>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptverifymessagehash BOOL CryptVerifyMessageHash(
	// PCRYPT_HASH_MESSAGE_PARA pHashPara, BYTE *pbHashedBlob, DWORD cbHashedBlob, BYTE *pbToBeHashed, DWORD *pcbToBeHashed, BYTE
	// *pbComputedHash, DWORD *pcbComputedHash );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "3b5185b9-e24b-4302-a60c-74ccbd19077c")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptVerifyMessageHash(in CRYPT_HASH_MESSAGE_PARA pHashPara, [In] IntPtr pbHashedBlob, uint cbHashedBlob, [Out] IntPtr pbToBeHashed,
		ref uint pcbToBeHashed, [Out] IntPtr pbComputedHash, ref uint pcbComputedHash);

	/// <summary>
	/// <para>The <c>CryptVerifyMessageSignature</c> function verifies a signed message's signature.</para>
	/// <para>
	/// This function should not be used to verify the signature of a detached message. You should use the
	/// CryptVerifyDetachedMessageSignature function to verify the signature of a detached message.
	/// </para>
	/// </summary>
	/// <param name="pVerifyPara">A pointer to a CRYPT_VERIFY_MESSAGE_PARA structure that contains verification parameters.</param>
	/// <param name="dwSignerIndex">
	/// The index of the desired signature. There can be more than one signature. <c>CryptVerifyMessageSignature</c> can be called
	/// repeatedly, incrementing dwSignerIndex each time. Set this parameter to zero for the first signer, or if there is only one
	/// signer. If the function returns <c>FALSE</c>, and GetLastError returns CRYPT_E_NO_SIGNER, the previous call processed the last
	/// signer of the message.
	/// </param>
	/// <param name="pbSignedBlob">A pointer to a buffer that contains the signed message.</param>
	/// <param name="cbSignedBlob">The size, in bytes, of the signed message buffer.</param>
	/// <param name="pbDecoded">
	/// <para>A pointer to a buffer to receive the decoded message.</para>
	/// <para>
	/// This parameter can be <c>NULL</c> if the decoded message is not needed for additional processing or to set the size of the
	/// message for memory allocation purposes. For more information, see Retrieving Data of Unknown Length.
	/// </para>
	/// </param>
	/// <param name="pcbDecoded">
	/// <para>
	/// A pointer to a <c>DWORD</c> value that specifies the size, in bytes, of the pbDecoded buffer. When the function returns, this
	/// <c>DWORD</c> contains the size, in bytes, of the decoded message. The decoded message will not be returned if this parameter is <c>NULL</c>.
	/// </para>
	/// <para>
	/// <c>Note</c> When processing the data returned, applications must use the actual size of the data returned. The actual size can
	/// be slightly smaller than the size of the buffer specified on input. (On input, buffer sizes are usually specified large enough
	/// to ensure that the largest possible output data will fit in the buffer.) On output, the variable pointed to by this parameter is
	/// updated to reflect the actual size of the data copied to the buffer.
	/// </para>
	/// </param>
	/// <param name="ppSignerCert">
	/// The address of a CERT_CONTEXT structure pointer that receives the certificate of the signer. When you have finished using this
	/// structure, free it by passing this pointer to the CertFreeCertificateContext function. This parameter can be <c>NULL</c> if the
	/// signer's certificate is not needed.
	/// </param>
	/// <returns>
	/// <para>
	/// If the function succeeds, the function returns nonzero. This does not necessarily mean that the signature was verified. In the
	/// case of a detached message, the variable pointed to by pcbDecoded will contain zero. In this case, this function will return
	/// nonzero, but the signature is not verified. To verify the signature of a detached message, use the
	/// CryptVerifyDetachedMessageSignature function.
	/// </para>
	/// <para>If the function fails, it returns zero. For extended error information, call GetLastError.</para>
	/// <para>The following table shows the error codes most commonly returned by the GetLastError function.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>
	/// If the buffer specified by the pbDecoded parameter is not large enough to hold the returned data, the function sets the
	/// ERROR_MORE_DATA code, and stores the required buffer size, in bytes, in the variable pointed to by pcbDecoded.
	/// </term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>
	/// Invalid message and certificate encoding types. Currently only PKCS_7_ASN_ENCODING and X509_ASN_ENCODING_TYPE are supported.
	/// Invalid cbSize in *pVerifyPara.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_E_UNEXPECTED_MSG_TYPE</term>
	/// <term>Not a signed cryptographic message.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_E_NO_SIGNER</term>
	/// <term>The message does not have any signers or a signer for the specified dwSignerIndex.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_ALGID</term>
	/// <term>The message was hashed and signed by using an unknown or unsupported algorithm.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_SIGNATURE</term>
	/// <term>The message's signature was not verified.</term>
	/// </item>
	/// </list>
	/// <para>
	/// <c>Note</c> Errors from the called functions CryptCreateHash, CryptHashData, CryptVerifySignature, and CryptImportKey can be
	/// propagated to this function. If the function fails, GetLastError may return an Abstract Syntax Notation One (ASN.1)
	/// encoding/decoding error. For information about these errors, see ASN.1 Encoding/Decoding Return Values.
	/// </para>
	/// </returns>
	/// <remarks>
	/// <para>
	/// For a verified signer and message, ppSignerCert is updated with the CERT_CONTEXT of the signer. It must be freed by calling
	/// CertFreeCertificateContext. Otherwise, ppSignerCert is set to <c>NULL</c>.
	/// </para>
	/// <para>For a message that contains only certificates and CRLs, pcbDecoded is set to <c>NULL</c>.</para>
	/// <para>Examples</para>
	/// <para>For an example that uses this function, see Example C Program: Signing a Message and Verifying a Message Signature.</para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptverifymessagesignature BOOL
	// CryptVerifyMessageSignature( PCRYPT_VERIFY_MESSAGE_PARA pVerifyPara, DWORD dwSignerIndex, const BYTE *pbSignedBlob, DWORD
	// cbSignedBlob, BYTE *pbDecoded, DWORD *pcbDecoded, PCCERT_CONTEXT *ppSignerCert );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "03411e7a-b097-4059-a198-3d412ae40e38")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptVerifyMessageSignature(in CRYPT_VERIFY_MESSAGE_PARA pVerifyPara, uint dwSignerIndex, [In] IntPtr pbSignedBlob, uint cbSignedBlob,
		[Out] IntPtr pbDecoded, ref uint pcbDecoded, out SafePCCERT_CONTEXT ppSignerCert);

	/// <summary>
	/// The <c>CryptVerifyMessageSignatureWithKey</c> function verifies a signed message's signature by using specified public key information.
	/// </summary>
	/// <param name="pVerifyPara">A pointer to a CRYPT_KEY_VERIFY_MESSAGE_PARA structure that contains verification parameters.</param>
	/// <param name="pPublicKeyInfo">
	/// A pointer to a CERT_PUBLIC_KEY_INFO structure that contains the public key that is used to verify the signed message. If
	/// <c>NULL</c>, the signature is not verified.
	/// </param>
	/// <param name="pbSignedBlob">A pointer to a buffer that contains the signed message.</param>
	/// <param name="cbSignedBlob">The size, in bytes, of the signed message buffer.</param>
	/// <param name="pbDecoded">
	/// <para>A pointer to a buffer to receive the decoded message.</para>
	/// <para>
	/// This parameter can be <c>NULL</c> if the decoded message is not needed for additional processing or to set the size of the
	/// message for memory allocation purposes. For more information, see Retrieving Data of Unknown Length.
	/// </para>
	/// </param>
	/// <param name="pcbDecoded">
	/// <para>
	/// A pointer to a <c>DWORD</c> value that specifies the size, in bytes, of the pbDecoded buffer. When the function returns, this
	/// <c>DWORD</c> contains the size, in bytes, of the decoded message. The decoded message will not be returned if this parameter is <c>NULL</c>.
	/// </para>
	/// <para>
	/// <c>Note</c> When processing the data returned, applications must use the actual size of the data returned. The actual size can
	/// be slightly smaller than the size of the buffer specified on input. (On input, buffer sizes are usually specified large enough
	/// to ensure that the largest possible output data will fit in the buffer.) On output, the variable pointed to by this parameter is
	/// updated to reflect the actual size of the data copied to the buffer.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns nonzero.</para>
	/// <para>If the function fails, it returns zero. For extended error information, call GetLastError.</para>
	/// <para>The following table shows the error codes most commonly returned by the GetLastError function.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>
	/// If the buffer specified by the pbDecoded parameter is not large enough to hold the returned data, the function sets the
	/// ERROR_MORE_DATA code, and stores the required buffer size, in bytes, in the variable pointed to by pcbDecoded.
	/// </term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>
	/// Invalid message and certificate encoding types. Currently only PKCS_7_ASN_ENCODING and X509_ASN_ENCODING_TYPE are supported.
	/// Invalid cbSize in *pVerifyPara.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_E_UNEXPECTED_MSG_TYPE</term>
	/// <term>Not a signed cryptographic message.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_E_NO_SIGNER</term>
	/// <term>The message does not have any signers or a signer for the specified dwSignerIndex.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_ALGID</term>
	/// <term>The message was hashed and signed by using an unknown or unsupported algorithm.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_SIGNATURE</term>
	/// <term>The message's signature was not verified.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptverifymessagesignaturewithkey BOOL
	// CryptVerifyMessageSignatureWithKey( PCRYPT_KEY_VERIFY_MESSAGE_PARA pVerifyPara, PCERT_PUBLIC_KEY_INFO pPublicKeyInfo, const BYTE
	// *pbSignedBlob, DWORD cbSignedBlob, BYTE *pbDecoded, DWORD *pcbDecoded );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "6fe0f9ee-1838-4eb7-8254-05b878eb8f56")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptVerifyMessageSignatureWithKey(in CRYPT_KEY_VERIFY_MESSAGE_PARA pVerifyPara, in CERT_PUBLIC_KEY_INFO pPublicKeyInfo, [In] IntPtr pbSignedBlob,
		uint cbSignedBlob, [Out] IntPtr pbDecoded, ref uint pcbDecoded);

	/// <summary>
	/// The <c>CryptVerifyMessageSignatureWithKey</c> function verifies a signed message's signature by using specified public key information.
	/// </summary>
	/// <param name="pVerifyPara">A pointer to a CRYPT_KEY_VERIFY_MESSAGE_PARA structure that contains verification parameters.</param>
	/// <param name="pPublicKeyInfo">
	/// A pointer to a CERT_PUBLIC_KEY_INFO structure that contains the public key that is used to verify the signed message. If
	/// <c>NULL</c>, the signature is not verified.
	/// </param>
	/// <param name="pbSignedBlob">A pointer to a buffer that contains the signed message.</param>
	/// <param name="cbSignedBlob">The size, in bytes, of the signed message buffer.</param>
	/// <param name="pbDecoded">
	/// <para>A pointer to a buffer to receive the decoded message.</para>
	/// <para>
	/// This parameter can be <c>NULL</c> if the decoded message is not needed for additional processing or to set the size of the
	/// message for memory allocation purposes. For more information, see Retrieving Data of Unknown Length.
	/// </para>
	/// </param>
	/// <param name="pcbDecoded">
	/// <para>
	/// A pointer to a <c>DWORD</c> value that specifies the size, in bytes, of the pbDecoded buffer. When the function returns, this
	/// <c>DWORD</c> contains the size, in bytes, of the decoded message. The decoded message will not be returned if this parameter is <c>NULL</c>.
	/// </para>
	/// <para>
	/// <c>Note</c> When processing the data returned, applications must use the actual size of the data returned. The actual size can
	/// be slightly smaller than the size of the buffer specified on input. (On input, buffer sizes are usually specified large enough
	/// to ensure that the largest possible output data will fit in the buffer.) On output, the variable pointed to by this parameter is
	/// updated to reflect the actual size of the data copied to the buffer.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the function returns nonzero.</para>
	/// <para>If the function fails, it returns zero. For extended error information, call GetLastError.</para>
	/// <para>The following table shows the error codes most commonly returned by the GetLastError function.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>ERROR_MORE_DATA</term>
	/// <term>
	/// If the buffer specified by the pbDecoded parameter is not large enough to hold the returned data, the function sets the
	/// ERROR_MORE_DATA code, and stores the required buffer size, in bytes, in the variable pointed to by pcbDecoded.
	/// </term>
	/// </item>
	/// <item>
	/// <term>E_INVALIDARG</term>
	/// <term>
	/// Invalid message and certificate encoding types. Currently only PKCS_7_ASN_ENCODING and X509_ASN_ENCODING_TYPE are supported.
	/// Invalid cbSize in *pVerifyPara.
	/// </term>
	/// </item>
	/// <item>
	/// <term>CRYPT_E_UNEXPECTED_MSG_TYPE</term>
	/// <term>Not a signed cryptographic message.</term>
	/// </item>
	/// <item>
	/// <term>CRYPT_E_NO_SIGNER</term>
	/// <term>The message does not have any signers or a signer for the specified dwSignerIndex.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_ALGID</term>
	/// <term>The message was hashed and signed by using an unknown or unsupported algorithm.</term>
	/// </item>
	/// <item>
	/// <term>NTE_BAD_SIGNATURE</term>
	/// <term>The message's signature was not verified.</term>
	/// </item>
	/// </list>
	/// </returns>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptverifymessagesignaturewithkey BOOL
	// CryptVerifyMessageSignatureWithKey( PCRYPT_KEY_VERIFY_MESSAGE_PARA pVerifyPara, PCERT_PUBLIC_KEY_INFO pPublicKeyInfo, const BYTE
	// *pbSignedBlob, DWORD cbSignedBlob, BYTE *pbDecoded, DWORD *pcbDecoded );
	[DllImport(Lib.Crypt32, SetLastError = true, ExactSpelling = true)]
	[PInvokeData("wincrypt.h", MSDNShortId = "6fe0f9ee-1838-4eb7-8254-05b878eb8f56")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool CryptVerifyMessageSignatureWithKey(in CRYPT_KEY_VERIFY_MESSAGE_PARA pVerifyPara, [In, Optional] IntPtr pPublicKeyInfo, [In] IntPtr pbSignedBlob,
		uint cbSignedBlob, [Out] IntPtr pbDecoded, ref uint pcbDecoded);

	/// <summary>
	/// The <c>CMSG_CMS_SIGNER_INFO</c> structure contains the content of the defined SignerInfo in signed or signed and enveloped
	/// messages. In decoding a received message, CryptMsgGetParam is called for each signer to get a <c>CMSG_CMS_SIGNER_INFO</c> structure.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-cmsg_cms_signer_info typedef struct _CMSG_CMS_SIGNER_INFO
	// { DWORD dwVersion; CERT_ID SignerId; CRYPT_ALGORITHM_IDENTIFIER HashAlgorithm; CRYPT_ALGORITHM_IDENTIFIER
	// HashEncryptionAlgorithm; CRYPT_DATA_BLOB EncryptedHash; CRYPT_ATTRIBUTES AuthAttrs; CRYPT_ATTRIBUTES UnauthAttrs; }
	// CMSG_CMS_SIGNER_INFO, *PCMSG_CMS_SIGNER_INFO;
	[PInvokeData("wincrypt.h", MSDNShortId = "177323ef-4e26-4681-a474-1a99fb6900af")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CMSG_CMS_SIGNER_INFO
	{
		/// <summary>The version of this structure.</summary>
		public uint dwVersion;

		/// <summary>A CERT_ID structure that identifies the signer's certificate.</summary>
		public CERT_ID SignerId;

		/// <summary>A CRYPT_ALGORITHM_IDENTIFIER structure that specifies the algorithm used in generating the hash of a message.</summary>
		public CRYPT_ALGORITHM_IDENTIFIER HashAlgorithm;

		/// <summary>A CRYPT_ALGORITHM_IDENTIFIER structure that specifies the algorithm used to encrypt the hash.</summary>
		public CRYPT_ALGORITHM_IDENTIFIER HashEncryptionAlgorithm;

		/// <summary>A CRYPT_DATA_BLOB structure that contains the encrypted hash of the message, the signature.</summary>
		public CRYPTOAPI_BLOB EncryptedHash;

		/// <summary>A CRYPT_ATTRIBUTES structure that contains authenticated attributes of the signer.</summary>
		public CRYPT_ATTRIBUTES AuthAttrs;

		/// <summary>A CRYPT_ATTRIBUTES structure that contains unauthenticated attributes of the signer.</summary>
		public CRYPT_ATTRIBUTES UnauthAttrs;
	}

	/// <summary>
	/// The <c>CMSG_CTRL_ADD_SIGNER_UNAUTH_ATTR_PARA</c> structure is used to add an unauthenticated attribute to a signer of a signed
	/// message. This structure is passed to CryptMsgControl if the dwCtrlType parameter is set to <c>CMSG_CTRL_ADD_SIGNER_UNAUTH_ATTR</c>.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-cmsg_ctrl_add_signer_unauth_attr_para typedef struct
	// _CMSG_CTRL_ADD_SIGNER_UNAUTH_ATTR_PARA { DWORD cbSize; DWORD dwSignerIndex; CRYPT_DATA_BLOB blob; }
	// CMSG_CTRL_ADD_SIGNER_UNAUTH_ATTR_PARA, *PCMSG_CTRL_ADD_SIGNER_UNAUTH_ATTR_PARA;
	[PInvokeData("wincrypt.h", MSDNShortId = "5e347a50-942e-4278-a9ae-ad4c30c55c6b")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CMSG_CTRL_ADD_SIGNER_UNAUTH_ATTR_PARA
	{
		/// <summary>Size of this structure in bytes.</summary>
		public uint cbSize;

		/// <summary>
		/// Index of the signer in the <c>rgSigners</c> array of pointers of CMSG_SIGNER_ENCODE_INFO structures in a signed message's
		/// CMSG_SIGNED_ENCODE_INFO structure. The unauthenticated attribute is to be added to this signer's information.
		/// </summary>
		public uint dwSignerIndex;

		/// <summary/>
		public CRYPTOAPI_BLOB blob;
	}

	/// <summary>
	/// <para>
	/// The <c>CMSG_CTRL_DECRYPT_PARA</c> structure contains information used to decrypt an enveloped message for a key transport
	/// recipient. This structure is passed to CryptMsgControl if the dwCtrlType parameter is CMSG_CTRL_DECRYPT.
	/// </para>
	/// <para>
	/// For information about how CryptoAPI supports Secure/Multipurpose Internet Mail Extensions (S/MIME) email interoperability, see
	/// the Remarks section of CryptMsgOpenToEncode.
	/// </para>
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-cmsg_ctrl_decrypt_para typedef struct
	// _CMSG_CTRL_DECRYPT_PARA { DWORD cbSize; union { HCRYPTPROV hCryptProv; NCRYPT_KEY_HANDLE hNCryptKey; } DUMMYUNIONNAME; DWORD
	// dwKeySpec; DWORD dwRecipientIndex; } CMSG_CTRL_DECRYPT_PARA, *PCMSG_CTRL_DECRYPT_PARA;
	[PInvokeData("wincrypt.h", MSDNShortId = "eb9b1daa-b04f-419a-88e3-7c772f9e62eb")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CMSG_CTRL_DECRYPT_PARA
	{
		/// <summary>The size, in bytes, of this structure.</summary>
		public uint cbSize;

		/// <summary/>
		public CMSG_CTRL_DECRYPT_PARA_HANDLES Handle;

		/// <summary/>
		[StructLayout(LayoutKind.Explicit)]
		public struct CMSG_CTRL_DECRYPT_PARA_HANDLES
		{
			/// <summary>
			/// Cryptographic service provider (CSP) handle. The CNG function NCryptIsKeyHandle is called to determine the union choice.
			/// </summary>
			[FieldOffset(0)]
			public HCRYPTPROV hCryptProv;

			/// <summary>
			/// A handle to the CNG Cryptographic service provider (CSP). The CNG function, NCryptIsKeyHandle, is called to determine
			/// the union choice. New encrypt algorithms are only supported in CNG functions. The CNG function, NCryptTranslateHandle,
			/// will be called to convert the CryptoAPI hCryptProv choice where necessary. We recommend that applications pass, to the
			/// hNCryptKey member, the CNG CSP handle that is returned from the NCryptOpenKey function.
			/// </summary>
			[FieldOffset(0)]
			public NCrypt.NCRYPT_KEY_HANDLE hNCryptKey;
		}

		/// <summary>
		/// <para>The private key to be used. This member is not used when the hNCryptKey member is used.</para>
		/// <para>The following <c>dwKeySpec</c> values are defined for the default provider.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>AT_KEYEXCHANGE</term>
		/// <term>Keys used to encrypt and decrypt session keys.</term>
		/// </item>
		/// <item>
		/// <term>AT_SIGNATURE</term>
		/// <term>Keys used to create and verify digital signatures.</term>
		/// </item>
		/// </list>
		/// <para>If <c>dwKeySpec</c> is zero, the default AT_KEYEXCHANGE is used.</para>
		/// </summary>
		public CertKeySpec dwKeySpec;

		/// <summary>Index of the recipient in the message associated with the <c>hCryptProv</c> private key.</summary>
		public uint dwRecipientIndex;
	}

	/// <summary>
	/// The <c>CMSG_CTRL_DEL_SIGNER_UNAUTH_ATTR_PARA</c> structure is used to delete an unauthenticated attribute of a signer of a
	/// signed message. This structure is passed to CryptMsgControl if the dwCrlType parameter is <c>CMSG_CTRL_DEL_SIGNER_UNAUTH_ATTR</c>.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-cmsg_ctrl_del_signer_unauth_attr_para typedef struct
	// _CMSG_CTRL_DEL_SIGNER_UNAUTH_ATTR_PARA { DWORD cbSize; DWORD dwSignerIndex; DWORD dwUnauthAttrIndex; }
	// CMSG_CTRL_DEL_SIGNER_UNAUTH_ATTR_PARA, *PCMSG_CTRL_DEL_SIGNER_UNAUTH_ATTR_PARA;
	[PInvokeData("wincrypt.h", MSDNShortId = "729fbbe0-40c6-41e7-851f-6f93f47e8f4d")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CMSG_CTRL_DEL_SIGNER_UNAUTH_ATTR_PARA
	{
		/// <summary>Size of this structure in bytes.</summary>
		public uint cbSize;

		/// <summary>
		/// Index of the signer in the <c>rgSigners</c> array of pointers to CMSG_SIGNER_ENCODE_INFO structures in a signed message's
		/// CMSG_SIGNED_ENCODE_INFO structure. The unauthenticated attribute for this signer is deleted.
		/// </summary>
		public uint dwSignerIndex;

		/// <summary>
		/// Index of the element in the <c>rgUnauthAttr</c> array of the CMSG_SIGNER_ENCODE_INFO structure holding the unauthenticated
		/// attribute to be removed.
		/// </summary>
		public uint dwUnauthAttrIndex;
	}

	/// <summary>The <c>CMSG_CTRL_KEY_AGREE_DECRYPT_PARA</c> structure contains information about a key agreement recipient.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-cmsg_ctrl_key_agree_decrypt_para typedef struct
	// _CMSG_CTRL_KEY_AGREE_DECRYPT_PARA { DWORD cbSize; union { HCRYPTPROV hCryptProv; NCRYPT_KEY_HANDLE hNCryptKey; } DUMMYUNIONNAME;
	// DWORD dwKeySpec; PCMSG_KEY_AGREE_RECIPIENT_INFO pKeyAgree; DWORD dwRecipientIndex; DWORD dwRecipientEncryptedKeyIndex;
	// CRYPT_BIT_BLOB OriginatorPublicKey; } CMSG_CTRL_KEY_AGREE_DECRYPT_PARA, *PCMSG_CTRL_KEY_AGREE_DECRYPT_PARA;
	[PInvokeData("wincrypt.h", MSDNShortId = "14e58281-4315-4ece-8ea8-92765cffd212")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CMSG_CTRL_KEY_AGREE_DECRYPT_PARA
	{
		/// <summary>The size, in bytes, of this data structure.</summary>
		public uint cbSize;

		/// <summary/>
		public CMSG_CTRL_KEY_AGREE_DECRYPT_PARA_HANDLES Handle;

		/// <summary/>
		[StructLayout(LayoutKind.Explicit)]
		public struct CMSG_CTRL_KEY_AGREE_DECRYPT_PARA_HANDLES
		{
			/// <summary>
			/// A handle to the cryptographic service provider (CSP) used to do the recipient key encryption and export. If <c>NULL</c>,
			/// the provider specified in CMSG_ENVELOPED_ENCODE_INFO is used. The CNG function NCryptIsKeyHandle is called to determine
			/// the union choice.
			/// </summary>
			[FieldOffset(0)]
			public HCRYPTPROV hCryptProv;

			/// <summary>
			/// A handle to the CNG CSP used to do the recipient key encryption and export. The CNG function NCryptIsKeyHandle is called
			/// to determine the union choice. New encrypt algorithms are only supported in CNG functions. The CNG function
			/// NCryptTranslateHandle will be called to convert the CryptoAPI CSP hCryptProv choice where necessary. We recommend that
			/// applications pass, to the hNCryptKey member, the CNG CSP handle that is returned from the NCryptOpenKey function.
			/// </summary>
			[FieldOffset(0)]
			public NCrypt.NCRYPT_KEY_HANDLE hNCryptKey;
		}

		/// <summary>
		/// Specifies the encrypted key. The encrypted key is the result of encrypting the content-encryption key. This member is not
		/// used when the hNCryptKey member is used.
		/// </summary>
		public CertKeySpec dwKeySpec;

		/// <summary>A pointer to a CMSG_KEY_AGREE_RECIPIENT_INFO structure.</summary>
		public IntPtr pKeyAgree;

		/// <summary>Indicates a specific recipient in an array of recipients.</summary>
		public uint dwRecipientIndex;

		/// <summary>Indicates a specific encrypted key in an array of encrypted keys.</summary>
		public uint dwRecipientEncryptedKeyIndex;

		/// <summary>A CRYPT_BIT_BLOB structure that contains the sender's public key information.</summary>
		public CRYPTOAPI_BLOB OriginatorPublicKey;
	}

	/// <summary>The <c>CMSG_CTRL_KEY_TRANS_DECRYPT_PARA</c> structure contains information about a key transport message recipient.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-cmsg_ctrl_key_trans_decrypt_para typedef struct
	// _CMSG_CTRL_KEY_TRANS_DECRYPT_PARA { DWORD cbSize; union { HCRYPTPROV hCryptProv; NCRYPT_KEY_HANDLE hNCryptKey; } DUMMYUNIONNAME;
	// DWORD dwKeySpec; PCMSG_KEY_TRANS_RECIPIENT_INFO pKeyTrans; DWORD dwRecipientIndex; } CMSG_CTRL_KEY_TRANS_DECRYPT_PARA, *PCMSG_CTRL_KEY_TRANS_DECRYPT_PARA;
	[PInvokeData("wincrypt.h", MSDNShortId = "5f3387c9-4ff0-42a0-8fc7-67d3bb8b6bef")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CMSG_CTRL_KEY_TRANS_DECRYPT_PARA
	{
		/// <summary>The size, in bytes, of this data structure.</summary>
		public uint cbSize;

		/// <summary/>
		public CMSG_CTRL_KEY_TRANS_DECRYPT_PARA_HANDLES Handle;

		/// <summary/>
		[StructLayout(LayoutKind.Explicit)]
		public struct CMSG_CTRL_KEY_TRANS_DECRYPT_PARA_HANDLES
		{
			/// <summary>
			/// A handle to the cryptographic service provider (CSP) used to do the recipient key encryption and export. If <c>NULL</c>,
			/// the provider specified in CMSG_ENVELOPED_ENCODE_INFO is used. The CNG function NCryptIsKeyHandle is called to determine
			/// the union choice.
			/// </summary>
			[FieldOffset(0)]
			public HCRYPTPROV hCryptProv;

			/// <summary>
			/// A handle to the CNG CSP used to do the recipient key encryption and export. The CNG function NCryptIsKeyHandle is called
			/// to determine the union choice. New encrypt algorithms are only supported in CNG functions. The CNG function
			/// NCryptTranslateHandle will be called to convert the CryptoAPI CSP hCryptProv choice where necessary. We recommend that
			/// applications pass, to the hNCryptKey member, the CNG CSP handle that is returned from the NCryptOpenKey function.
			/// </summary>
			[FieldOffset(0)]
			public NCrypt.NCRYPT_KEY_HANDLE hNCryptKey;
		}

		/// <summary>
		/// Specifies the encrypted key. The encrypted key is the result of encrypting the content-encryption key for a specific
		/// recipient by using that recipient's public key. This member is not used when the hNCryptKey member is used.
		/// </summary>
		public uint dwKeySpec;

		/// <summary>A pointer to a CMSG_KEY_TRANS_RECIPIENT_INFO structure.</summary>
		public IntPtr pKeyTrans;

		/// <summary>Indicates a specific recipient in any array of recipients.</summary>
		public uint dwRecipientIndex;
	}

	/// <summary>The <c>CMSG_CTRL_MAIL_LIST_DECRYPT_PARA</c> structure contains information on a mail list message recipient.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-cmsg_ctrl_mail_list_decrypt_para typedef struct
	// _CMSG_CTRL_MAIL_LIST_DECRYPT_PARA { DWORD cbSize; HCRYPTPROV hCryptProv; PCMSG_MAIL_LIST_RECIPIENT_INFO pMailList; DWORD
	// dwRecipientIndex; DWORD dwKeyChoice; union { HCRYPTKEY hKeyEncryptionKey; void *pvKeyEncryptionKey; } DUMMYUNIONNAME; }
	// CMSG_CTRL_MAIL_LIST_DECRYPT_PARA, *PCMSG_CTRL_MAIL_LIST_DECRYPT_PARA;
	[PInvokeData("wincrypt.h", MSDNShortId = "30735e01-db6b-40fc-b4c8-cdc24e73defa")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CMSG_CTRL_MAIL_LIST_DECRYPT_PARA
	{
		/// <summary>The size, in bytes, of this data structure.</summary>
		public uint cbSize;

		/// <summary>
		/// The provider used to do the recipient key encryption and export. If <c>hCryptProv</c> is <c>NULL</c>, the provider specified
		/// in CMSG_ENVELOPED_ENCODE_INFO is used.
		/// </summary>
		public HCRYPTPROV hCryptProv;

		/// <summary>A pointer to a CMSG_MAIL_LIST_RECIPIENT_INFO structure.</summary>
		public IntPtr pMailList;

		/// <summary>Indicates a specific recipient in any array of recipients.</summary>
		public uint dwRecipientIndex;

		/// <summary>
		/// Indicates the member of the following union that will be used. Currently only CMSG_MAIL_LIST_HANDLE_KEY_CHOICE is defined.
		/// </summary>
		public uint dwKeyChoice;

		/// <summary>Handle of the key encryption key. Used with <c>dwKeyChoice</c> set to CMSG_MAIL_LIST_HANDLE_KEY_CHOICE.</summary>
		public HCRYPTKEY hKeyEncryptionKey;
	}

	/// <summary>
	/// The <c>CMSG_CTRL_VERIFY_SIGNATURE_EX_PARA</c> structure contains information used to verify a message signature. It contains the
	/// signer index and signer public key. The signer public key can be the signer's CERT_PUBLIC_KEY_INFO structure, certificate
	/// context, or chain context.
	/// </summary>
	/// <remarks>
	/// If <c>dwSignerType</c> is CMSG_VERIFY_SIGNER_NULL, the signature is expected to contain only the unencrypted hash octets.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-cmsg_ctrl_verify_signature_ex_para typedef struct
	// _CMSG_CTRL_VERIFY_SIGNATURE_EX_PARA { DWORD cbSize; HCRYPTPROV_LEGACY hCryptProv; DWORD dwSignerIndex; DWORD dwSignerType; void
	// *pvSigner; } CMSG_CTRL_VERIFY_SIGNATURE_EX_PARA, *PCMSG_CTRL_VERIFY_SIGNATURE_EX_PARA;
	[PInvokeData("wincrypt.h", MSDNShortId = "56b73de8-c170-46f6-b488-096475b59c15")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CMSG_CTRL_VERIFY_SIGNATURE_EX_PARA
	{
		/// <summary>The size, in bytes, of this structure.</summary>
		public uint cbSize;

		/// <summary>
		/// <para>This member is not used and should be set to <c>NULL</c>.</para>
		/// <para>
		/// <c>Windows Server 2003 and Windows XP:</c> A handle to the cryptographic provider used to verify the signature. If
		/// <c>NULL</c>, the cryptographic provider specified in CryptMsgOpenToDecode is used. If the hCryptProv in
		/// <c>CryptMsgOpenToDecode</c> is also <c>NULL</c>, the default provider according to the signer's public key object identifier
		/// (OID) is used.This member's data type is <c>HCRYPTPROV</c>.
		/// </para>
		/// </summary>
		public HCRYPTPROV hCryptProv;

		/// <summary>The index of the signer in the message.</summary>
		public uint dwSignerIndex;

		/// <summary>
		/// <para>
		/// The structure that contains the signer information. The following table shows the predefined values and the structures indicated.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>CMSG_VERIFY_SIGNER_PUBKEY</term>
		/// <term>CERT_PUBLIC_KEY_INFO</term>
		/// </item>
		/// <item>
		/// <term>CMSG_VERIFY_SIGNER_CERT</term>
		/// <term>CERT_CONTEXT</term>
		/// </item>
		/// <item>
		/// <term>CMSG_VERIFY_SIGNER_CHAIN</term>
		/// <term>CERT_CHAIN_CONTEXT</term>
		/// </item>
		/// <item>
		/// <term>CMSG_VERIFY_SIGNER_NULL</term>
		/// <term>NULL</term>
		/// </item>
		/// </list>
		/// </summary>
		public CryptMsgSignerType dwSignerType;

		/// <summary>
		/// A pointer to a CERT_PUBLIC_KEY_INFO structure, a certificate context, a chain context, or <c>NULL</c> depending on the value
		/// of <c>dwSignerType</c>.
		/// </summary>
		public IntPtr pvSigner;
	}

	/// <summary>The <c>CMSG_KEY_AGREE_RECIPIENT_INFO</c> structure contains information used for key agreement algorithms.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-cmsg_key_agree_recipient_info typedef struct
	// _CMSG_KEY_AGREE_RECIPIENT_INFO { DWORD dwVersion; DWORD dwOriginatorChoice; union { CERT_ID OriginatorCertId;
	// CERT_PUBLIC_KEY_INFO OriginatorPublicKeyInfo; } DUMMYUNIONNAME; CRYPT_DATA_BLOB UserKeyingMaterial; CRYPT_ALGORITHM_IDENTIFIER
	// KeyEncryptionAlgorithm; DWORD cRecipientEncryptedKeys; PCMSG_RECIPIENT_ENCRYPTED_KEY_INFO *rgpRecipientEncryptedKeys; }
	// CMSG_KEY_AGREE_RECIPIENT_INFO, *PCMSG_KEY_AGREE_RECIPIENT_INFO;
	[PInvokeData("wincrypt.h", MSDNShortId = "d29d04d6-065e-4bb7-843b-f563643eeb4c")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CMSG_KEY_AGREE_RECIPIENT_INFO
	{
		/// <summary>A <c>DWORD</c> that indicates the version of the structure. Always set to three.</summary>
		public uint dwVersion;

		/// <summary>A <c>DWORD</c> that indicates the key identifier to use.</summary>
		public CryptMsgKeyOriginator dwOriginatorChoice;

		/// <summary/>
		public CMSG_KEY_AGREE_RECIPIENT_INFO_UNION Originator;

		/// <summary/>
		[StructLayout(LayoutKind.Explicit)]
		public struct CMSG_KEY_AGREE_RECIPIENT_INFO_UNION
		{
			/// <summary>A CERT_ID that identifies the public key of the message originator.</summary>
			[FieldOffset(0)]
			public CERT_ID OriginatorCertId;

			/// <summary>A CERT_PUBLIC_KEY_INFO structure that contains the public key of the message originator.</summary>
			[FieldOffset(0)]
			public CERT_PUBLIC_KEY_INFO OriginatorPublicKeyInfo;
		}

		/// <summary>
		/// A CRYPT_DATA_BLOB that indicates that a different key is generated each time the same two parties generate a pair of keys.
		/// The sender provides the bits of this BLOB with some key agreement algorithms. This member can be <c>NULL</c>.
		/// </summary>
		public CRYPTOAPI_BLOB UserKeyingMaterial;

		/// <summary>
		/// A CRYPT_ALGORITHM_IDENTIFIER that identifies the key-encryption algorithm and any associated parameters used to encrypt the
		/// content encryption key.
		/// </summary>
		public CRYPT_ALGORITHM_IDENTIFIER KeyEncryptionAlgorithm;

		/// <summary>The number of elements in the <c>rgpRecipientEncryptedKeys</c> array.</summary>
		public uint cRecipientEncryptedKeys;

		/// <summary>
		/// The address of an array of CMSG_RECIPIENT_ENCRYPTED_KEY_INFO structures that contains information about the key recipients.
		/// The <c>cRecipientEncryptedKeys</c> member contains the number of elements in this array.
		/// </summary>
		public IntPtr rgpRecipientEncryptedKeys;
	}

	/// <summary>The <c>CMSG_KEY_TRANS_RECIPIENT_INFO</c> structure contains information used in key transport algorithms.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-cmsg_key_trans_recipient_info typedef struct
	// _CMSG_KEY_TRANS_RECIPIENT_INFO { DWORD dwVersion; CERT_ID RecipientId; CRYPT_ALGORITHM_IDENTIFIER KeyEncryptionAlgorithm;
	// CRYPT_DATA_BLOB EncryptedKey; } CMSG_KEY_TRANS_RECIPIENT_INFO, *PCMSG_KEY_TRANS_RECIPIENT_INFO;
	[PInvokeData("wincrypt.h", MSDNShortId = "956b0646-50a5-46d1-aa9a-91194c35d2b2")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CMSG_KEY_TRANS_RECIPIENT_INFO
	{
		/// <summary>
		/// Indicates the version of the structure. If <c>RecipientId</c> uses the ISSUER_SERIAL_NUMBER to identify the recipient,
		/// <c>dwVersion</c> is set to zero. If <c>RecipientId</c> uses KEYID, <c>dwVersion</c> is set to two.
		/// </summary>
		public uint dwVersion;

		/// <summary>
		/// A CERT_ID that identifies the recipient. Currently, only ISSUER_SERIAL_NUMBER or KEYID choices in the <c>CERT_ID</c> are valid.
		/// </summary>
		public CERT_ID RecipientId;

		/// <summary>
		/// A CRYPT_ALGORITHM_IDENTIFIER that identifies the key-encryption algorithm and any associated parameters used to encrypt the
		/// content encryption key.
		/// </summary>
		public CRYPT_ALGORITHM_IDENTIFIER KeyEncryptionAlgorithm;

		/// <summary>A CRYPT_DATA_BLOB that contains the bytes of the encrypted session key.</summary>
		public CRYPTOAPI_BLOB EncryptedKey;
	}

	/// <summary>
	/// The <c>CMSG_MAIL_LIST_RECIPIENT_INFO</c> structure contains information used for previously distributed symmetric key-encryption
	/// keys (KEK).
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-cmsg_mail_list_recipient_info typedef struct
	// _CMSG_MAIL_LIST_RECIPIENT_INFO { DWORD dwVersion; CRYPT_DATA_BLOB KeyId; CRYPT_ALGORITHM_IDENTIFIER KeyEncryptionAlgorithm;
	// CRYPT_DATA_BLOB EncryptedKey; FILETIME Date; PCRYPT_ATTRIBUTE_TYPE_VALUE pOtherAttr; } CMSG_MAIL_LIST_RECIPIENT_INFO, *PCMSG_MAIL_LIST_RECIPIENT_INFO;
	[PInvokeData("wincrypt.h", MSDNShortId = "e0946278-75e9-4990-af81-d9e61da9724b")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CMSG_MAIL_LIST_RECIPIENT_INFO
	{
		/// <summary>Indicates the version of the structure. This member is always four.</summary>
		public uint dwVersion;

		/// <summary>
		/// A CRYPT_DATA_BLOB structure that identifies a symmetric key-encryption key previously distributed to the sender and one or
		/// more recipients.
		/// </summary>
		public CRYPTOAPI_BLOB KeyId;

		/// <summary>
		/// CRYPT_ALGORITHM_IDENTIFIER that identifies the key-encryption algorithm and any associated parameters used to encrypt the
		/// content encryption key.
		/// </summary>
		public CRYPT_ALGORITHM_IDENTIFIER KeyEncryptionAlgorithm;

		/// <summary>A CRYPT_DATA_BLOB structure that contains the encrypted content encryption key.</summary>
		public CRYPTOAPI_BLOB EncryptedKey;

		/// <summary>Optional. When present, this member specifies a single key-encryption key from a previously distributed set.</summary>
		public FILETIME Date;

		/// <summary>Optional pointer to a CRYPT_ATTRIBUTE_TYPE_VALUE structure containing additional information.</summary>
		public IntPtr pOtherAttr;
	}

	/// <summary>
	/// The <c>CMSG_RECIPIENT_ENCRYPTED_KEY_INFO</c> structure contains information used for an individual key agreement recipient.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-cmsg_recipient_encrypted_key_info typedef struct
	// _CMSG_RECIPIENT_ENCRYPTED_KEY_INFO { CERT_ID RecipientId; CRYPT_DATA_BLOB EncryptedKey; FILETIME Date;
	// PCRYPT_ATTRIBUTE_TYPE_VALUE pOtherAttr; } CMSG_RECIPIENT_ENCRYPTED_KEY_INFO, *PCMSG_RECIPIENT_ENCRYPTED_KEY_INFO;
	[PInvokeData("wincrypt.h", MSDNShortId = "1921f9b6-86d9-47a0-a36e-e20d481382a3")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CMSG_RECIPIENT_ENCRYPTED_KEY_INFO
	{
		/// <summary>
		/// CERT_ID structure identifying the recipient. Currently, only the ISSUER_SERIAL_NUMBER or KEYID choices in the <c>CERT_ID</c>
		/// structure are valid.
		/// </summary>
		public CERT_ID RecipientId;

		/// <summary>A CRYPT_DATA_BLOB structure that contains the encrypted content encryption key.</summary>
		public CRYPTOAPI_BLOB EncryptedKey;

		/// <summary>
		/// Optional. When present, this member specifies which of the recipient's previously distributed UKMs was used by the sender.
		/// Only applicable to KEYID choice in the <c>RecipientId</c> CERT_ID structure.
		/// </summary>
		public FILETIME Date;

		/// <summary>
		/// Optional pointer to a CRYPT_ATTRIBUTE_TYPE_VALUE structure containing additional information. Only applicable to KEYID
		/// choice in the <c>RecipientId</c> CERT_ID structure.
		/// </summary>
		public IntPtr pOtherAttr;
	}

	/// <summary>
	/// The <c>CMSG_SIGNER_ENCODE_INFO</c> structure contains signer information. It is passed to CryptMsgCountersign,
	/// CryptMsgCountersignEncoded, and optionally to CryptMsgOpenToEncode as a member of the CMSG_SIGNED_ENCODE_INFO structure, if the
	/// dwMsgType parameter is CMSG_SIGNED.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-cmsg_signer_encode_info typedef struct
	// _CMSG_SIGNER_ENCODE_INFO { DWORD cbSize; PCERT_INFO pCertInfo; union { HCRYPTPROV hCryptProv; NCRYPT_KEY_HANDLE hNCryptKey;
	// BCRYPT_KEY_HANDLE hBCryptKey; } DUMMYUNIONNAME; DWORD dwKeySpec; CRYPT_ALGORITHM_IDENTIFIER HashAlgorithm; void *pvHashAuxInfo;
	// DWORD cAuthAttr; PCRYPT_ATTRIBUTE rgAuthAttr; DWORD cUnauthAttr; PCRYPT_ATTRIBUTE rgUnauthAttr; CERT_ID SignerId;
	// CRYPT_ALGORITHM_IDENTIFIER HashEncryptionAlgorithm; void *pvHashEncryptionAuxInfo; } CMSG_SIGNER_ENCODE_INFO, *PCMSG_SIGNER_ENCODE_INFO;
	[PInvokeData("wincrypt.h", MSDNShortId = "f599226d-ddd7-455f-b650-74b91674d8f9")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CMSG_SIGNER_ENCODE_INFO
	{
		/// <summary>The size, in bytes, of this structure.</summary>
		public uint cbSize;

		/// <summary>
		/// <para>A pointer to a CERT_INFO structure that contains the</para>
		/// <para><c>Issuer</c>, <c>SerialNumber</c>, and <c>SubjectPublicKeyInfo</c> members.</para>
		/// <para>
		/// The <c>pbData</c> members of the <c>Issuer</c> and <c>SerialNumber</c> structures combined uniquely identify a certificate.
		/// The <c>Algorithm</c> member of the <c>SubjectPublicKeyInfo</c> structure specifies the hash encryption algorithm used.
		/// </para>
		/// </summary>
		public IntPtr pCertInfo;

		/// <summary/>
		public CMSG_SIGNER_ENCODE_INFO_HANDLES Handle;

		/// <summary/>
		[StructLayout(LayoutKind.Explicit)]
		public struct CMSG_SIGNER_ENCODE_INFO_HANDLES
		{
			/// <summary>
			/// A handle to the cryptographic service provider (CSP). If <c>HashEncryptionAlgorithm</c> is set to
			/// szOID_PKIX_NO_SIGNATURE, this handle can be the handle of a CSP acquired by using the dwFlags parameter set to
			/// <c>CRYPT_VERIFYCONTEXT</c>. The CNG function NCryptIsKeyHandle is called to determine the union choice.
			/// </summary>
			[FieldOffset(0)]
			public HCRYPTPROV hCryptProv;

			/// <summary>
			/// A handle to the CNG CSP. The CNG function NCryptIsKeyHandle is called to determine the union choice. New encrypt
			/// algorithms are only supported in CNG functions. The CNG function NCryptTranslateHandle will be called to convert the
			/// CryptoAPI hCryptProv choice where necessary. We recommend that applications pass, to the hNCryptKey member, the CNG CSP
			/// handle that is returned from the NCryptOpenKey function.
			/// </summary>
			[FieldOffset(0)]
			public NCrypt.NCRYPT_KEY_HANDLE hNCryptKey;

			/// <summary/>
			[FieldOffset(0)]
			public BCrypt.BCRYPT_KEY_HANDLE hBCryptKey;
		}

		/// <summary>
		/// <para>Specifies the private key to be used. This member is not used when the hNCryptKey member is used.</para>
		/// <para>If <c>dwKeySpec</c> is zero, then the default AT_KEYEXCHANGE value is used.</para>
		/// <para>The following <c>dwKeySpec</c> values are defined for the default provider.</para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>AT_KEYEXCHANGE</term>
		/// <term>Keys used to encrypt/decrypt session keys.</term>
		/// </item>
		/// <item>
		/// <term>AT_SIGNATURE</term>
		/// <term>Keys used to create and verify digital signatures.</term>
		/// </item>
		/// </list>
		/// </summary>
		public CertKeySpec dwKeySpec;

		/// <summary>A CRYPT_ALGORITHM_IDENTIFIER structure that specifies the hash algorithm.</summary>
		public CRYPT_ALGORITHM_IDENTIFIER HashAlgorithm;

		/// <summary>Not used. This member must be set to <c>NULL</c>.</summary>
		public IntPtr pvHashAuxInfo;

		/// <summary>
		/// The number of elements in the <c>rgAuthAttr</c> array. If no authenticated attributes are present in <c>rgAuthAttr</c>, then
		/// <c>cAuthAttr</c> is zero.
		/// </summary>
		public uint cAuthAttr;

		/// <summary>
		/// <para>An array of pointers to CRYPT_ATTRIBUTE structures, each of which contains authenticated attribute information.</para>
		/// <para>
		/// The PKCS #9 standard dictates that if there are any attributes, there must be at least two: the content type object
		/// identifier (OID) and the hash of the message. These attributes are automatically added by the system.
		/// </para>
		/// </summary>
		public IntPtr rgAuthAttr;

		/// <summary>
		/// The number of elements in the <c>rgUnauthAttr</c> array. If there are no unauthenticated attributes, <c>cUnauthAttr</c> is zero.
		/// </summary>
		public uint cUnauthAttr;

		/// <summary>
		/// An array of pointers to CRYPT_ATTRIBUTE structures, each of which contains unauthenticated attribute information.
		/// Unauthenticated attributes can contain countersignatures, among other uses.
		/// </summary>
		public IntPtr rgUnauthAttr;

		/// <summary>
		/// A CERT_ID structure that contains a unique identifier of the signer's certificate. This member can optionally be used with
		/// PKCS #7 with Cryptographic Message Syntax (CMS). If this member is not <c>NULL</c> and its <c>dwIdChoice</c> member is not
		/// zero, it is used to identify the certificate instead of the <c>Issuer</c> and <c>SerialNumber</c> members of the CERT_INFO
		/// structure pointed to by <c>pCertInfo</c>. CMS supports the KEY_IDENTIFIER and ISSUER_SERIAL_NUMBER CERT_ID structures. PKCS
		/// version 1.5 supports only the ISSUER_SERIAL_NUMBER CERT_ID choice. This member is used with CMS for PKCS #7 processing and
		/// can be used only if CMSG_SIGNER_ENCODE_INFO_HAS_CMS_FIELDS is defined.
		/// </summary>
		public CERT_ID SignerId;

		/// <summary>
		/// <para>
		/// A CRYPT_ALGORITHM_IDENTIFIER structure optionally used with PKCS #7 with CMS. If this member is not <c>NULL</c>, the
		/// algorithm identified is used instead of the SubjectPublicKeyInfo.Algorithm algorithm. If this member is set to
		/// szOID_PKIX_NO_SIGNATURE, the signature value contains only the hash octets.
		/// </para>
		/// <para>
		/// For RSA, the hash encryption algorithm is normally the same as the public key algorithm. For DSA, the hash encryption
		/// algorithm is normally a DSS signature algorithm.
		/// </para>
		/// <para>
		/// This member is used with CMS for PKCS #7 processing and can be used only if CMSG_SIGNER_ENCODE_INFO_HAS_CMS_FIELDS is defined.
		/// </para>
		/// </summary>
		public CRYPT_ALGORITHM_IDENTIFIER HashEncryptionAlgorithm;

		/// <summary>
		/// This member is not used. This member must be set to <c>NULL</c> if it is present in the data structure. This member is
		/// present only if CMSG_SIGNER_ENCODE_INFO_HAS_CMS_FIELDS is defined.
		/// </summary>
		public IntPtr pvHashEncryptionAuxInfo;
	}

	/// <summary>
	/// The <c>CMSG_SIGNER_INFO</c> structure contains the content of the PKCS #7 defined SignerInfo in signed messages. In decoding a
	/// received message, CryptMsgGetParam is called for each signer to get a <c>CMSG_SIGNER_INFO</c> structure.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-cmsg_signer_info typedef struct _CMSG_SIGNER_INFO { DWORD
	// dwVersion; CERT_NAME_BLOB Issuer; CRYPT_INTEGER_BLOB SerialNumber; CRYPT_ALGORITHM_IDENTIFIER HashAlgorithm;
	// CRYPT_ALGORITHM_IDENTIFIER HashEncryptionAlgorithm; CRYPT_DATA_BLOB EncryptedHash; CRYPT_ATTRIBUTES AuthAttrs; CRYPT_ATTRIBUTES
	// UnauthAttrs; } CMSG_SIGNER_INFO, *PCMSG_SIGNER_INFO;
	[PInvokeData("wincrypt.h", MSDNShortId = "NS:wincrypt._CMSG_SIGNER_INFO")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CMSG_SIGNER_INFO
	{
		/// <summary>The version of this structure.</summary>
		public uint dwVersion;

		/// <summary>A CERT_NAME_BLOB structure that contains the issuer of a certificate with the public key needed to verify a signature.</summary>
		public CRYPTOAPI_BLOB Issuer;

		/// <summary>
		/// A CRYPT_INTEGER_BLOB structure that contains the serial number of the certificate that contains the public key needed to
		/// verify a signature. For more information, see CERT_INFO.
		/// </summary>
		public CRYPTOAPI_BLOB SerialNumber;

		/// <summary>CRYPT_ALGORITHM_IDENTIFIER structure specifying the algorithm used in generating the hash of a message.</summary>
		public CRYPT_ALGORITHM_IDENTIFIER HashAlgorithm;

		/// <summary>CRYPT_ALGORITHM_IDENTIFIER structure specifying the algorithm used to encrypt the hash.</summary>
		public CRYPT_ALGORITHM_IDENTIFIER HashEncryptionAlgorithm;

		/// <summary>A CRYPT_DATA_BLOB that contains the encrypted hash of the message, the signature.</summary>
		public CRYPTOAPI_BLOB EncryptedHash;

		/// <summary>CRYPT_ATTRIBUTES structure containing authenticated attributes of the signer.</summary>
		public CRYPT_ATTRIBUTES AuthAttrs;

		/// <summary>CRYPT_ATTRIBUTES structure containing unauthenticated attributes of the signer.</summary>
		public CRYPT_ATTRIBUTES UnauthAttrs;
	}

	/// <summary>
	/// <para>
	/// The <c>CMSG_STREAM_INFO</c> structure is used to enable stream processing of data rather than single block processing. Stream
	/// processing is most often used when processing large messages. Stream-processed messages can originate from any serialized source
	/// such as a file on a hard disk, a server, or a CD ROM.
	/// </para>
	/// <para>This structure is passed to the CryptMsgOpenToEncode and CryptMsgOpenToDecode functions.</para>
	/// </summary>
	/// <remarks>
	/// <para>
	/// Messages can be so large that processing them all at once by storing the whole message in memory can be difficult, if not
	/// impossible. It is possible to process large messages without encountering memory limitations by streaming the data that is to be
	/// processed into manageable sized blocks. The low-level message functions can be used with streaming to encode or decode a
	/// message. Any level of nesting of messages is supported when streaming to encode and streaming to decode.
	/// </para>
	/// <para>
	/// The input message to be processed as a stream feeds into CryptMsgUpdate one block at a time, with the application determining
	/// the size of the block. As the streamed message is processed for encoding or decoding, the resulting output data is passed back
	/// to the application through an application-specified callback function that is specified by the <c>pfnStreamOutput</c> member.
	/// </para>
	/// <para>
	/// No assumptions can be made about the block size of the output data because the size can vary for several reasons, such as the
	/// jitter in output block size caused by the block size for the encryption algorithm when processing an enveloped message, or when
	/// blocks that contain the message header and the SignerInfo as defined by PKCS # 7 are processed.
	/// </para>
	/// <para>
	/// The size of the output block is passed to the callback function in its cbData parameter. The use of output data is determined in
	/// the calling application. Typically, output from stream processing will not be persisted in memory as a whole due to memory
	/// limitations; rather, it will be serialized to a disk or server file.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-cmsg_stream_info typedef struct _CMSG_STREAM_INFO { DWORD
	// cbContent; PFN_CMSG_STREAM_OUTPUT pfnStreamOutput; void *pvArg; } CMSG_STREAM_INFO, *PCMSG_STREAM_INFO;
	[PInvokeData("wincrypt.h", MSDNShortId = "a4e7f6e8-351f-4981-b223-50b65f503394")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CMSG_STREAM_INFO
	{
		/// <summary>
		/// Specifies the size, in bytes, of the content. Normal Distinguished Encoding Rules (DER) encoding is used unless
		/// <c>CMSG_INDEFINITE_LENGTH</c>(0xFFFFFFFF) is passed, indicating that the application is not specifying the content length.
		/// This forces the use of indefinite-length Basic Encoding Rules (BER) encoding.
		/// </summary>
		public uint cbContent;

		/// <summary>
		/// <para>The address of a callback function used to read from and write data to a disk when processing large messages.</para>
		/// <para>The callback function must have the following signature and parameters:</para>
		/// </summary>
		public PFN_CMSG_STREAM_OUTPUT pfnStreamOutput;

		/// <summary>
		/// A pointer to the argument to pass to the callback function. Typically, this is used for state data that includes the handle
		/// to a more deeply nested message (when decoding) or a less deeply nested message (when encoding).
		/// </summary>
		public IntPtr pvArg;
	}

	/// <summary>The <c>CRYPT_DECRYPT_MESSAGE_PARA</c> structure contains information for decrypting messages.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-crypt_decrypt_message_para typedef struct
	// _CRYPT_DECRYPT_MESSAGE_PARA { DWORD cbSize; DWORD dwMsgAndCertEncodingType; DWORD cCertStore; HCERTSTORE *rghCertStore; DWORD
	// dwFlags; } CRYPT_DECRYPT_MESSAGE_PARA, *PCRYPT_DECRYPT_MESSAGE_PARA;
	[PInvokeData("wincrypt.h", MSDNShortId = "67e136cd-12e3-4a31-9d8b-b53e1129e940")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CRYPT_DECRYPT_MESSAGE_PARA
	{
		/// <summary>Size of this structure in bytes.</summary>
		public uint cbSize;

		/// <summary>
		/// <para>
		/// Type of encoding used. It is always acceptable to specify both the certificate and message encoding types by combining them
		/// with a bitwise- <c>OR</c> operation as shown in the following example:
		/// </para>
		/// <para>X509_ASN_ENCODING | PKCS_7_ASN_ENCODING</para>
		/// <para>Currently defined encoding types are:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>X509_ASN_ENCODING</term>
		/// </item>
		/// <item>
		/// <term>PKCS_7_ASN_ENCODING</term>
		/// </item>
		/// </list>
		/// </summary>
		public CertEncodingType dwMsgAndCertEncodingType;

		/// <summary>Number of elements in the <c>rghCertStore</c> array.</summary>
		public uint cCertStore;

		/// <summary>
		/// <para>Array of certificate store handles.</para>
		/// <para>
		/// These certificate store handles are used to obtain the certificate context to use for decrypting a message. For more
		/// information, see the decryption functions CryptDecryptMessage, and CryptDecryptAndVerifyMessageSignature. An encrypted
		/// message can have one or more recipients. The recipients are identified by a unique certificate identifier, often the hash of
		/// the certificate issuer and serial number. The certificate stores are searched to find a certificate context corresponding to
		/// the unique identifier.
		/// </para>
		/// <para>
		/// Recipients can also be identified by their KeyId. Both Key Agreement (Diffie-Hellman) and Key Transport (RSA) recipients are supported.
		/// </para>
		/// <para>
		/// Only certificate contexts in the store with one of the following properties, CERT_KEY_PROV_INFO_PROP_ID, or
		/// CERT_KEY_CONTEXT_PROP_ID can be used. These properties specify the location of a needed private exchange key.
		/// </para>
		/// </summary>
		public IntPtr rghCertStore;

		/// <summary>
		/// The CRYPT_MESSAGE_SILENT_KEYSET_FLAG can be set to suppress any UI by the CSP. For more information about the CRYPT_SILENT
		/// flag, see CryptAcquireContext.
		/// </summary>
		public CryptMsgActionFlags dwFlags;
	}

	/// <summary>The <c>CRYPT_ENCRYPT_MESSAGE_PARA</c> structure contains information used to encrypt messages.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-crypt_encrypt_message_para typedef struct
	// _CRYPT_ENCRYPT_MESSAGE_PARA { DWORD cbSize; DWORD dwMsgEncodingType; HCRYPTPROV_LEGACY hCryptProv; CRYPT_ALGORITHM_IDENTIFIER
	// ContentEncryptionAlgorithm; void *pvEncryptionAuxInfo; DWORD dwFlags; DWORD dwInnerContentType; } CRYPT_ENCRYPT_MESSAGE_PARA, *PCRYPT_ENCRYPT_MESSAGE_PARA;
	[PInvokeData("wincrypt.h", MSDNShortId = "c683c515-3061-48e3-a64a-2798bd1245b0")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CRYPT_ENCRYPT_MESSAGE_PARA
	{
		/// <summary>The size, in bytes, of this structure.</summary>
		public uint cbSize;

		/// <summary>
		/// <para>
		/// The type of encoding used. It is always acceptable to specify both the certificate and message encoding types by combining
		/// them with a bitwise- <c>OR</c> operation as shown in the following example:
		/// </para>
		/// <para>X509_ASN_ENCODING | PKCS_7_ASN_ENCODING</para>
		/// <para>Currently defined encoding types are:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>X509_ASN_ENCODING</term>
		/// </item>
		/// <item>
		/// <term>PKCS_7_ASN_ENCODING</term>
		/// </item>
		/// </list>
		/// </summary>
		public CertEncodingType dwMsgEncodingType;

		/// <summary>
		/// <para>This member is not used and should be set to <c>NULL</c>.</para>
		/// <para>
		/// <c>Windows Server 2003 and Windows XP:</c> The handle to the cryptographic service provider (CSP) to be used for encryption.
		/// The CSP identified by <c>hCryptProv</c> is used to do content encryption, recipient key encryption, and recipient key
		/// export. Its private key is not used.
		/// </para>
		/// <para>
		/// Unless there is a strong reason for passing in a specific cryptographic provider in <c>hCryptProv</c>, pass zero to use the
		/// default RSA or DSS provider.
		/// </para>
		/// <para>This member's data type is <c>HCRYPTPROV</c>.</para>
		/// </summary>
		public HCRYPTPROV hCryptProv;

		/// <summary>
		/// <para>
		/// A CRYPT_ALGORITHM_IDENTIFIER structure that contains the object identifier (OID) of the encryption algorithm to use. The CSP
		/// specified by the <c>hCryptProv</c> must support this encryption algorithm.
		/// </para>
		/// <para>
		/// The <c>szOID_OIWSEC_desCBC</c> (CALG_DES) and <c>szOID_RSA_DES_EDE3_CBC</c> (CALG_3DES) encryption algorithms require the
		/// <c>Parameters</c> member of this structure to contain an encoded eight-byte initialization vector (IV). If the <c>cbData</c>
		/// member of the <c>Parameters</c> member is zero, an Abstract Syntax Notation One (ASN.1)-encoded OCTET STRING that contains
		/// the IV is generated using CryptGenRandom. For more information about the KP_IV parameter, see CryptSetKeyParam.
		/// </para>
		/// <para>
		/// The <c>szOID_NIST_AES128_CBC</c> (BCRYPT_AES_ALGORITHM, 128 bit), <c>szOID_NIST_AES192_CBC</c> (BCRYPT_AES_ALGORITHM, 192
		/// bit), and <c>szOID_NIST_AES256_CBC</c> (BCRYPT_AES_ALGORITHM, 256 bit) encryption algorithms require the <c>Parameters</c>
		/// member of this structure to contain an encoded sixteen-byte initialization vector (IV). If the <c>cbData</c> member of the
		/// Parameters member is zero, an Abstract Syntax Notation One (ASN.1)-encoded OCTET STRING that contains the IV is generated.
		/// </para>
		/// <para>
		/// The <c>szOID_RSA_RC2CBC</c> (CALG_RC2) algorithm requires the <c>pbData</c> member of the <c>Parameters</c> member of this
		/// structure to be a CRYPT_RC2_CBC_PARAMETERS structure. If the <c>cbData</c> member of the <c>Parameters</c> member is zero,
		/// an ASN.1-encoded <c>CRYPT_RC2_CBC_PARAMETERS</c> structure that contains the IV is generated as the <c>pbData</c> member.
		/// This generated <c>pbData</c> uses the default <c>dwVersion</c> that corresponds to the 40-bit key length. To override the
		/// default 40-bit key length, <c>pvEncryptionAuxInfo</c> can be set to point to a CMSG_RC2_AUX_INFO structure that contains a
		/// key bit length.
		/// </para>
		/// <para>
		/// <c>Note</c> When a message is decrypted, if it has an initialization vector parameter, the cryptographic message functions
		/// call CryptSetKeyParam with the initialization vector before decrypting.
		/// </para>
		/// </summary>
		public CRYPT_ALGORITHM_IDENTIFIER ContentEncryptionAlgorithm;

		/// <summary>
		/// <para>
		/// A pointer to a CMSG_RC2_AUX_INFO structure for RC2 encryption or a CMSG_SP3_COMPATIBLE_AUX_INFO structure for SP3-compatible
		/// encryption. For other than RC2 or SP3-compatible encryption, this member must be set to <c>NULL</c>.
		/// </para>
		/// <para>
		/// If the <c>ContentEncryptionAlgorithm</c> member contains <c>szOID_RSA_RC4</c>, this member points to a CMSG_RC4_AUX_INFO
		/// structure that specifies the number of salt bytes to be included.
		/// </para>
		/// </summary>
		public IntPtr pvEncryptionAuxInfo;

		/// <summary>
		/// <para>
		/// Normally set to zero. However, if the encoded output is to be a CMSG_ENVELOPED inner content of an outer cryptographic
		/// message, such as a CMSG_SIGNED message, the CRYPT_MESSAGE_BARE_CONTENT_OUT_FLAG must be set. If it is not set, content will
		/// be encoded as an inner content type of CMSG_DATA.
		/// </para>
		/// <para>
		/// CRYPT_MESSAGE_ENCAPSULATED_CONTENT_OUT_FLAG can be set to encapsulate non-data inner content within an OCTET STRING before encrypting.
		/// </para>
		/// <para>
		/// CRYPT_MESSAGE_KEYID_RECIPIENT_FLAG can be set to identify recipients by their Key Identifier and not their Issuer and Serial Number.
		/// </para>
		/// </summary>
		public CryptMsgActionFlags dwFlags;

		/// <summary>
		/// Normally set to zero. The <c>dwInnerContentType</c> member must be set to set the cryptographic message types if the input
		/// to be encrypted is the encoded output of another cryptographic message such as CMSG_SIGNED.
		/// </summary>
		public CryptMsgType dwInnerContentType;
	}

	/// <summary>The <c>CRYPT_HASH_MESSAGE_PARA</c> structure contains data for hashing messages.</summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-crypt_hash_message_para typedef struct
	// _CRYPT_HASH_MESSAGE_PARA { DWORD cbSize; DWORD dwMsgEncodingType; HCRYPTPROV_LEGACY hCryptProv; CRYPT_ALGORITHM_IDENTIFIER
	// HashAlgorithm; void *pvHashAuxInfo; } CRYPT_HASH_MESSAGE_PARA, *PCRYPT_HASH_MESSAGE_PARA;
	[PInvokeData("wincrypt.h", MSDNShortId = "60415136-3ac0-4fab-bdbf-faa16e8e43e1")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CRYPT_HASH_MESSAGE_PARA
	{
		/// <summary>Size of this structure in bytes.</summary>
		public uint cbSize;

		/// <summary>
		/// <para>
		/// Type of encoding used. It is always acceptable to specify both the certificate and message encoding types by combining them
		/// with a bitwise- <c>OR</c> operation as shown in the following example:
		/// </para>
		/// <para>X509_ASN_ENCODING | PKCS_7_ASN_ENCODING</para>
		/// <para>Currently defined encoding types are:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>X509_ASN_ENCODING</term>
		/// </item>
		/// <item>
		/// <term>PKCS_7_ASN_ENCODING</term>
		/// </item>
		/// </list>
		/// </summary>
		public CertEncodingType dwMsgEncodingType;

		/// <summary>
		/// <para>This member is not used and should be set to <c>NULL</c>.</para>
		/// <para>
		/// <c>Windows Server 2003 and Windows XP:</c> A handle to the cryptographic service provider (CSP) to be used.Unless there is a
		/// strong reason for passing in a specific cryptographic provider in <c>hCryptProv</c>, pass zero to use the default RSA or DSS provider.
		/// </para>
		/// <para>This member's data type is <c>HCRYPTPROV</c>.</para>
		/// </summary>
		public HCRYPTPROV hCryptProv;

		/// <summary>CRYPT_ALGORITHM_IDENTIFIER containing the algorithm for generating the hash of the message.</summary>
		public CRYPT_ALGORITHM_IDENTIFIER HashAlgorithm;

		/// <summary>Not currently used, and must be set to <c>NULL</c>.</summary>
		public IntPtr pvHashAuxInfo;
	}

	/// <summary>
	/// The <c>CRYPT_KEY_SIGN_MESSAGE_PARA</c> structure contains information about the cryptographic service provider (CSP) and
	/// algorithms used to sign a message.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-crypt_key_sign_message_para typedef struct
	// _CRYPT_KEY_SIGN_MESSAGE_PARA { DWORD cbSize; DWORD dwMsgAndCertEncodingType; union { HCRYPTPROV hCryptProv; NCRYPT_KEY_HANDLE
	// hNCryptKey; } DUMMYUNIONNAME; DWORD dwKeySpec; CRYPT_ALGORITHM_IDENTIFIER HashAlgorithm; void *pvHashAuxInfo;
	// CRYPT_ALGORITHM_IDENTIFIER PubKeyAlgorithm; } CRYPT_KEY_SIGN_MESSAGE_PARA, *PCRYPT_KEY_SIGN_MESSAGE_PARA;
	[PInvokeData("wincrypt.h", MSDNShortId = "d5426ad6-2181-42ce-99f2-cc6cc83e20a8")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CRYPT_KEY_SIGN_MESSAGE_PARA
	{
		/// <summary>The size, in bytes, of this data structure.</summary>
		public uint cbSize;

		/// <summary>
		/// <para>
		/// Specifies the type of message and certificate encoding used. This can be a combination of one or more of the following values.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>X509_ASN_ENCODING</term>
		/// <term>Specifies X.509 certificate encoding.</term>
		/// </item>
		/// <item>
		/// <term>PKCS_7_ASN_ENCODING</term>
		/// <term>Specifies PKCS 7 message encoding.</term>
		/// </item>
		/// </list>
		/// </summary>
		public CertEncodingType dwMsgAndCertEncodingType;

		/// <summary/>
		public CRYPT_KEY_SIGN_MESSAGE_PARA_HANDLE Handle;

		/// <summary/>
		[StructLayout(LayoutKind.Explicit)]
		public struct CRYPT_KEY_SIGN_MESSAGE_PARA_HANDLE
		{
			/// <summary>
			/// The handle of the CSP to use to sign the message. The CryptAcquireContext function is called to obtain this handle.
			/// </summary>
			[FieldOffset(0)]
			public HCRYPTPROV hCryptProv;

			/// <summary>
			/// The handle of the Cryptography API: Next Generation (CNG) CSP to use to sign the message. CNG signature algorithms are
			/// only supported in CNG functions.
			/// </summary>
			[FieldOffset(0)]
			public NCrypt.NCRYPT_KEY_HANDLE hNCryptKey;
		}

		/// <summary>
		/// <para>
		/// Identifies the type of private key to use to sign the message. This must be one of the following values. This member is
		/// ignored if a CNG key is passed in the hNCryptKey member.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Value</term>
		/// <term>Meaning</term>
		/// </listheader>
		/// <item>
		/// <term>AT_KEYEXCHANGE</term>
		/// <term>Use the key exchange key.</term>
		/// </item>
		/// <item>
		/// <term>AT_SIGNATURE</term>
		/// <term>Use the digital signature key.</term>
		/// </item>
		/// </list>
		/// </summary>
		public CertKeySpec dwKeySpec;

		/// <summary>
		/// A CRYPT_ALGORITHM_IDENTIFIER structure that specifies the algorithm to use to generate the hash of the message. This must be
		/// a hash algorithm.
		/// </summary>
		public CRYPT_ALGORITHM_IDENTIFIER HashAlgorithm;

		/// <summary>This member is not used and must be set to <c>NULL</c>.</summary>
		public IntPtr pvHashAuxInfo;

		/// <summary>
		/// A CRYPT_ALGORITHM_IDENTIFIER structure that specifies the algorithm to use to sign the message. This must be either a public
		/// key or a signature algorithm.
		/// </summary>
		public CRYPT_ALGORITHM_IDENTIFIER PubKeyAlgorithm;
	}

	/// <summary>
	/// The <c>CRYPT_KEY_VERIFY_MESSAGE_PARA</c> structure contains information needed to verify signed messages without a certificate
	/// for the signer.
	/// </summary>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-crypt_key_verify_message_para typedef struct
	// _CRYPT_KEY_VERIFY_MESSAGE_PARA { DWORD cbSize; DWORD dwMsgEncodingType; HCRYPTPROV_LEGACY hCryptProv; }
	// CRYPT_KEY_VERIFY_MESSAGE_PARA, *PCRYPT_KEY_VERIFY_MESSAGE_PARA;
	[PInvokeData("wincrypt.h", MSDNShortId = "4e0178fb-1f9f-4ee4-9a83-f37cf71d35ff")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CRYPT_KEY_VERIFY_MESSAGE_PARA
	{
		/// <summary>The size, in bytes, of this structure.</summary>
		public uint cbSize;

		/// <summary>
		/// <para>
		/// Type of encoding used. It is always acceptable to specify both the certificate and message encoding types by combining them
		/// with a bitwise- <c>OR</c> operation as shown in the following example:
		/// </para>
		/// <para>X509_ASN_ENCODING | PKCS_7_ASN_ENCODING</para>
		/// <para>Currently defined encoding types are:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>X509_ASN_ENCODING</term>
		/// </item>
		/// <item>
		/// <term>PKCS_7_ASN_ENCODING</term>
		/// </item>
		/// </list>
		/// </summary>
		public CertEncodingType dwMsgEncodingType;

		/// <summary>
		/// <para>This member is not used and should be set to <c>NULL</c>.</para>
		/// <para>
		/// <c>Windows Server 2003 and Windows XP:</c> A handle to the cryptographic service provider (CSP) to be used to verify a
		/// signed message. The CSP identified by this handle is used for hashing and for signature verification.Unless there is a
		/// strong reason for using a specific cryptographic provider, set this member to zero to use the default RSA or DSS provider.
		/// </para>
		/// <para>This member's data type is <c>HCRYPTPROV</c>.</para>
		/// </summary>
		public HCRYPTPROV hCryptProv;
	}

	/// <summary>
	/// The <c>CRYPT_SIGN_MESSAGE_PARA</c> structure contains information for signing messages using a specified signing certificate context.
	/// </summary>
	/// <remarks>
	/// The <c>HashEncryptionAlgorithm</c> and <c>pvHashEncryptionAuxInfo</c> members can only be used if
	/// CRYPT_SIGN_MESSAGE_PARA_HAS_CMS_FIELDS is defined.
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-crypt_sign_message_para typedef struct
	// _CRYPT_SIGN_MESSAGE_PARA { DWORD cbSize; DWORD dwMsgEncodingType; PCCERT_CONTEXT pSigningCert; CRYPT_ALGORITHM_IDENTIFIER
	// HashAlgorithm; void *pvHashAuxInfo; DWORD cMsgCert; PCCERT_CONTEXT *rgpMsgCert; DWORD cMsgCrl; PCCRL_CONTEXT *rgpMsgCrl; DWORD
	// cAuthAttr; PCRYPT_ATTRIBUTE rgAuthAttr; DWORD cUnauthAttr; PCRYPT_ATTRIBUTE rgUnauthAttr; DWORD dwFlags; DWORD
	// dwInnerContentType; CRYPT_ALGORITHM_IDENTIFIER HashEncryptionAlgorithm; void *pvHashEncryptionAuxInfo; } CRYPT_SIGN_MESSAGE_PARA, *PCRYPT_SIGN_MESSAGE_PARA;
	[PInvokeData("wincrypt.h", MSDNShortId = "1601d860-6054-4650-a033-ea088655b7e4")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CRYPT_SIGN_MESSAGE_PARA
	{
		/// <summary>Size of this structure in bytes.</summary>
		public uint cbSize;

		/// <summary>
		/// <para>
		/// Type of encoding used. It is always acceptable to specify both the certificate and message encoding types by combining them
		/// with a bitwise- <c>OR</c> operation as shown in the following example:
		/// </para>
		/// <para>X509_ASN_ENCODING | PKCS_7_ASN_ENCODING</para>
		/// <para>Currently defined encoding types are:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>X509_ASN_ENCODING</term>
		/// </item>
		/// <item>
		/// <term>PKCS_7_ASN_ENCODING</term>
		/// </item>
		/// </list>
		/// </summary>
		public CertEncodingType dwMsgEncodingType;

		/// <summary>
		/// <para>A pointer to the CERT_CONTEXT to be used in the signing.</para>
		/// <para>
		/// Either the CERT_KEY_PROV_INFO_PROP_ID, or CERT_KEY_CONTEXT_PROP_ID property must be set for the context to provide access to
		/// the private signature key.
		/// </para>
		/// </summary>
		public PCCERT_CONTEXT pSigningCert;

		/// <summary>CRYPT_ALGORITHM_IDENTIFIER containing the hashing algorithm used to hash the data to be signed.</summary>
		public CRYPT_ALGORITHM_IDENTIFIER HashAlgorithm;

		/// <summary>Not currently used, and must be set to <c>NULL</c>.</summary>
		public IntPtr pvHashAuxInfo;

		/// <summary>
		/// Number of elements in the <c>rgpMsgCert</c> array of CERT_CONTEXT structures. If set to zero no certificates are included in
		/// the signed message.
		/// </summary>
		public uint cMsgCert;

		/// <summary>
		/// Array of pointers to CERT_CONTEXT structures to be included in the signed message. If the <c>pSigningCert</c> is to be
		/// included, a pointer to it must be in the <c>rgpMsgCert</c> array.
		/// </summary>
		public IntPtr rgpMsgCert;

		/// <summary>
		/// Number of elements in the <c>rgpMsgCrl</c> array of pointers to CRL_CONTEXT structures. If set to zero, no
		/// <c>CRL_CONTEXT</c> structures are included in the signed message.
		/// </summary>
		public uint cMsgCrl;

		/// <summary>Array of pointers to CRL_CONTEXT structures to be included in the signed message.</summary>
		public IntPtr rgpMsgCrl;

		/// <summary>
		/// Number of elements in the <c>rgAuthAttr</c> array. If no authenticated attributes are present in <c>rgAuthAttr</c>, this
		/// member is set to zero.
		/// </summary>
		public uint cAuthAttr;

		/// <summary>
		/// Array of pointers to CRYPT_ATTRIBUTE structures, each holding authenticated attribute information. If there are
		/// authenticated attributes present, the PKCS #9 standard dictates that there must be at least two attributes present, the
		/// content type object identifier (OID), and the hash of the message itself. These attributes are automatically added by the system.
		/// </summary>
		public IntPtr rgAuthAttr;

		/// <summary>
		/// Number of elements in the <c>rgUnauthAttr</c> array. If no unauthenticated attributes are present in <c>rgUnauthAttr</c>,
		/// this member is zero.
		/// </summary>
		public uint cUnauthAttr;

		/// <summary>
		/// Array of pointers to CRYPT_ATTRIBUTE structures each holding an unauthenticated attribute information. Unauthenticated
		/// attributes can be used to contain countersignatures, among other uses.
		/// </summary>
		public IntPtr rgUnauthAttr;

		/// <summary>
		/// <para>
		/// Normally zero. If the encoded output is to be a CMSG_SIGNED inner content of an outer cryptographic message such as a
		/// CMSG_ENVELOPED message, the CRYPT_MESSAGE_BARE_CONTENT_OUT_FLAG must be set. If it is not set, the message will be encoded
		/// as an inner content type of CMSG_DATA.
		/// </para>
		/// <para>
		/// CRYPT_MESSAGE_ENCAPSULATED_CONTENT_OUT_FLAG can be set to encapsulate non-data inner content into an OCTET STRING.
		/// CRYPT_MESSAGE_KEYID_SIGNER_FLAG can be set to identify signers by their Key Identifier and not their Issuer and Serial Number.
		/// </para>
		/// <para>
		/// CRYPT_MESSAGE_SILENT_KEYSET_FLAG can be set to suppress any UI by the CSP. For more information about the CRYPT_SILENT flag,
		/// see CryptAcquireContext.
		/// </para>
		/// </summary>
		public CryptMsgActionFlags dwFlags;

		/// <summary>
		/// Normally zero. Set to the encoding type of the input message if that input to be signed is the encoded output of another
		/// cryptographic message.
		/// </summary>
		public uint dwInnerContentType;

		/// <summary>
		/// A CRYPT_ALGORITHM_IDENTIFIER. If present and not <c>NULL</c>, it is used instead of the signer's certificate
		/// <c>PublicKeyInfo.Algorithm</c> member. Note that for RSA, the hash encryption algorithm is normally the same as the public
		/// key algorithm. For DSA, the hash encryption algorithm is normally a DSS signature algorithm. This member can only be used if
		/// CRYPT_SIGN_MESSAGE_PARA_HAS_CMS_FIELDS is defined.
		/// </summary>
		[MarshalAs(UnmanagedType.FunctionPtr)]
		public CRYPT_ALGORITHM_IDENTIFIER HashEncryptionAlgorithm;

		/// <summary>
		/// Currently not used and must be set to <c>NULL</c>. This member can only be used if CRYPT_SIGN_MESSAGE_PARA_HAS_CMS_FIELDS is defined.
		/// </summary>
		public IntPtr pvHashEncryptionAuxInfo;
	}

	/// <summary>The <c>CRYPT_VERIFY_MESSAGE_PARA</c> structure contains information needed to verify signed messages.</summary>
	/// <remarks>
	/// <para>This structure is passed to the following functions:</para>
	/// <list type="bullet">
	/// <item>
	/// <term>CryptDecodeMessage</term>
	/// </item>
	/// <item>
	/// <term>CryptDecryptAndVerifyMessageSignature</term>
	/// </item>
	/// <item>
	/// <term>CryptVerifyDetachedMessageSignature</term>
	/// </item>
	/// <item>
	/// <term>CryptVerifyMessageSignature</term>
	/// </item>
	/// </list>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/win32/api/wincrypt/ns-wincrypt-crypt_verify_message_para typedef struct
	// _CRYPT_VERIFY_MESSAGE_PARA { DWORD cbSize; DWORD dwMsgAndCertEncodingType; HCRYPTPROV_LEGACY hCryptProv;
	// PFN_CRYPT_GET_SIGNER_CERTIFICATE pfnGetSignerCertificate; void *pvGetArg; PCCERT_STRONG_SIGN_PARA pStrongSignPara; }
	// CRYPT_VERIFY_MESSAGE_PARA, *PCRYPT_VERIFY_MESSAGE_PARA;
	[PInvokeData("wincrypt.h", MSDNShortId = "bbd56b5e-2bbe-420f-8842-1be50dca779f")]
	[StructLayout(LayoutKind.Sequential)]
	public struct CRYPT_VERIFY_MESSAGE_PARA
	{
		/// <summary>Size of this structure in bytes.</summary>
		public uint cbSize;

		/// <summary>
		/// <para>
		/// Type of encoding used. It is always acceptable to specify both the certificate and message encoding types by combining them
		/// with a bitwise- <c>OR</c> operation as shown in the following example:
		/// </para>
		/// <para>X509_ASN_ENCODING | PKCS_7_ASN_ENCODING</para>
		/// <para>Currently defined encoding types are:</para>
		/// <list type="bullet">
		/// <item>
		/// <term>X509_ASN_ENCODING</term>
		/// </item>
		/// <item>
		/// <term>PKCS_7_ASN_ENCODING</term>
		/// </item>
		/// </list>
		/// </summary>
		public CertEncodingType dwMsgAndCertEncodingType;

		/// <summary>
		/// <para>This member is not used and should be set to <c>NULL</c>.</para>
		/// <para>
		/// <c>Windows Server 2003 and Windows XP:</c> A handle to the cryptographic service provider to be used to verify a signed
		/// message. The CSP identified by this handle is used for hashing and for signature verification.Unless there is a strong
		/// reason for using a specific cryptographic provider, set to zero to use the default RSA or DSS provider.
		/// </para>
		/// <para>This member's data type is <c>HCRYPTPROV</c>.</para>
		/// </summary>
		public HCRYPTPROV hCryptProv;

		/// <summary>
		/// <para>
		/// A pointer to the callback function used to get the signer's certificate context. If <c>NULL</c>, the default callback is
		/// used. The default callback tries to get the signer certificate context from the message's certificate store.
		/// </para>
		/// <para>
		/// An application defined–callback function that gets the signer's certificate can be used in place of the default. It is
		/// passed the certificate identifier of the signer (its issuer and serial number) and a handle to its cryptographic signed
		/// message's certificate store.
		/// </para>
		/// <para>See CryptGetSignerCertificateCallback for the callback functions signature and arguments.</para>
		/// </summary>
		public PFN_CRYPT_GET_SIGNER_CERTIFICATE pfnGetSignerCertificate;

		/// <summary>Argument to pass to the callback function. Typically, this gets and verifies the message signer's certificate.</summary>
		public IntPtr pvGetArg;

		/// <summary>
		/// <para>
		/// Optional pointer to a CERT_STRONG_SIGN_PARA structure that contains parameters used for strong signing. If you set this
		/// member and the function successfully verifies the signature, the function will then check for a strong signature. If the
		/// signature is not strong, the operation will fail and set the GetLastError value to <c>NTE_BAD_ALGID</c>.
		/// </para>
		/// <para>
		/// <c>Note</c> You can use the <c>pStrongSignPara</c> member only if <c>CRYPT_VERIFY_MESSAGE_PARA_HAS_EXTRA_FIELDS</c> is
		/// defined by using the <c>#define</c> directive before including Wincrypt.h. If
		/// <c>CRYPT_VERIFY_MESSAGE_PARA_HAS_EXTRA_FIELDS</c> is defined, you must zero all unused fields.
		/// </para>
		/// <para>Windows 8 and Windows Server 2012:</para>
		/// <para>Support for this member begins.</para>
		/// </summary>
		public IntPtr pStrongSignPara;
	}

	/// <summary>Provides a <see cref="SafeHandle"/> for <see cref="HCRYPTMSG"/> that is disposed using <see cref="CryptMsgClose"/>.</summary>
	public class SafeHCRYPTMSG : SafeHANDLE
	{
		/// <summary>Initializes a new instance of the <see cref="SafeHCRYPTMSG"/> class and assigns an existing handle.</summary>
		/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
		/// <param name="ownsHandle">
		/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
		/// </param>
		public SafeHCRYPTMSG(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

		/// <summary>Initializes a new instance of the <see cref="SafeHCRYPTMSG"/> class.</summary>
		private SafeHCRYPTMSG() : base() { }

		/// <summary>Performs an implicit conversion from <see cref="SafeHCRYPTMSG"/> to <see cref="HCRYPTMSG"/>.</summary>
		/// <param name="h">The safe handle instance.</param>
		/// <returns>The result of the conversion.</returns>
		public static implicit operator HCRYPTMSG(SafeHCRYPTMSG h) => h.handle;

		/// <inheritdoc/>
		protected override bool InternalReleaseHandle() => CryptMsgClose(handle);
	}
}