using System;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke
{
	/// <summary>Functions and definitions from Secur32.dll</summary>
	public static partial class Secur32
	{
		/// <summary>
		/// <para>Compares the two specified credentials.</para>
		/// </summary>
		/// <param name="AuthIdentity1">
		/// <para>A pointer to an opaque structure that specifies the first credential to compare.</para>
		/// </param>
		/// <param name="AuthIdentity2">
		/// <para>A pointer to an opaque structure that specifies the second credential to compare.</para>
		/// </param>
		/// <param name="SameSuppliedUser">
		/// <para>
		/// <c>TRUE</c> if the user account specified by the AuthIdentity1 parameter is the same as the user account specified by the
		/// AuthIdentity2 parameter; otherwise, <c>FALSE</c>.
		/// </para>
		/// </param>
		/// <param name="SameSuppliedIdentity">
		/// <para>
		/// <c>TRUE</c> if the identity specified by the AuthIdentity1 parameter is the same as the identity specified by the AuthIdentity2
		/// parameter; otherwise, <c>FALSE</c>.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, it returns <c>SEC_E_OK</c>.</para>
		/// <para>If the function fails, it returns a nonzero error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/nf-sspi-sspicompareauthidentities SECURITY_STATUS SEC_ENTRY
		// SspiCompareAuthIdentities( PSEC_WINNT_AUTH_IDENTITY_OPAQUE AuthIdentity1, PSEC_WINNT_AUTH_IDENTITY_OPAQUE AuthIdentity2, PBOOLEAN
		// SameSuppliedUser, PBOOLEAN SameSuppliedIdentity );
		[DllImport(Lib.Secur32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("sspi.h", MSDNShortId = "d2c4f363-3d86-48f0-bae1-4f9240d68bab")]
		public static extern Win32Error SspiCompareAuthIdentities(PSEC_WINNT_AUTH_IDENTITY_OPAQUE AuthIdentity1, PSEC_WINNT_AUTH_IDENTITY_OPAQUE AuthIdentity2, [MarshalAs(UnmanagedType.U1)] out bool SameSuppliedUser, [MarshalAs(UnmanagedType.U1)] out bool SameSuppliedIdentity);

		/// <summary>
		/// <para>Creates a copy of the specified opaque credential structure.</para>
		/// </summary>
		/// <param name="AuthData">
		/// <para>The credential structure to be copied.</para>
		/// </param>
		/// <param name="AuthDataCopy">
		/// <para>The structure that receives the copy of the structure specified by the AuthData parameter.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, it returns <c>SEC_E_OK</c>.</para>
		/// <para>If the function fails, it returns a nonzero error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/nf-sspi-sspicopyauthidentity SECURITY_STATUS SEC_ENTRY
		// SspiCopyAuthIdentity( PSEC_WINNT_AUTH_IDENTITY_OPAQUE AuthData, PSEC_WINNT_AUTH_IDENTITY_OPAQUE *AuthDataCopy );
		[DllImport(Lib.Secur32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("sspi.h", MSDNShortId = "e53807bf-b5a1-4479-a73b-dd85c5da173e")]
		public static extern Win32Error SspiCopyAuthIdentity(PSEC_WINNT_AUTH_IDENTITY_OPAQUE AuthData, out SafePSEC_WINNT_AUTH_IDENTITY_OPAQUE AuthDataCopy);

		/// <summary>
		/// <para>Decrypts the specified encrypted credential.</para>
		/// </summary>
		/// <param name="EncryptedAuthData">
		/// <para>
		/// On input, a pointer to the encrypted credential structure to be decrypted. On output, a pointer to the decrypted credential structure.
		/// </para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, it returns <c>SEC_E_OK</c>.</para>
		/// <para>If the function fails, it returns a nonzero error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/nf-sspi-sspidecryptauthidentity SECURITY_STATUS SEC_ENTRY
		// SspiDecryptAuthIdentity( PSEC_WINNT_AUTH_IDENTITY_OPAQUE EncryptedAuthData );
		[DllImport(Lib.Secur32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("sspi.h", MSDNShortId = "aef0206c-c376-4877-b1a6-5e86d2e35dea")]
		public static extern Win32Error SspiDecryptAuthIdentity(PSEC_WINNT_AUTH_IDENTITY_OPAQUE EncryptedAuthData);

		/// <summary>
		/// <para>Encodes the specified authentication identity as three strings.</para>
		/// </summary>
		/// <param name="pAuthIdentity">
		/// <para>The credential structure to be encoded.</para>
		/// </param>
		/// <param name="ppszUserName">
		/// <para>The marshaled user name of the identity specified by the pAuthIdentity parameter.</para>
		/// <para>When you have finished using this string, free it by calling the SspiFreeAuthIdentity function.</para>
		/// </param>
		/// <param name="ppszDomainName">
		/// <para>The marshaled domain name of the identity specified by the pAuthIdentity parameter.</para>
		/// <para>When you have finished using this string, free it by calling the SspiFreeAuthIdentity function.</para>
		/// </param>
		/// <param name="ppszPackedCredentialsString">
		/// <para>An encoded string version of a SEC_WINNT_AUTH_IDENTITY_EX2 structure that specifies the users credentials.</para>
		/// <para>When you have finished using this string, free it by calling the SspiFreeAuthIdentity function.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, it returns <c>SEC_E_OK</c>.</para>
		/// <para>
		/// If the function fails, it returns a nonzero error code. Possible values include, but are not limited to, those in the following table.
		/// </para>
		/// <list type="table">
		/// <listheader>
		/// <term>Return code/value</term>
		/// <term>Description</term>
		/// </listheader>
		/// <item>
		/// <term>STATUS_INVALID_PARAMETER 0xC000000D</term>
		/// <term>
		/// The SEC_WINNT_AUTH_IDENTITY_FLAGS_PROCESS_ENCRYPTED flag is set in the identity structure specified by the pAuthIdentity parameter.
		/// </term>
		/// </item>
		/// </list>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/nf-sspi-sspiencodeauthidentityasstrings SECURITY_STATUS SEC_ENTRY
		// SspiEncodeAuthIdentityAsStrings( PSEC_WINNT_AUTH_IDENTITY_OPAQUE pAuthIdentity, PCWSTR *ppszUserName, PCWSTR *ppszDomainName,
		// PCWSTR *ppszPackedCredentialsString );
		[DllImport(Lib.Secur32, SetLastError = false, CharSet = CharSet.Auto)]
		[PInvokeData("sspi.h", MSDNShortId = "0610a7b8-67e9-4c01-893f-da579eeea2f8")]
		public static extern Win32Error SspiEncodeAuthIdentityAsStrings(PSEC_WINNT_AUTH_IDENTITY_OPAQUE pAuthIdentity,
			[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SspiStringMarshaler))] out string ppszUserName,
			[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SspiStringMarshaler))] out string ppszDomainName,
			[MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(SspiStringMarshaler))] out string ppszPackedCredentialsString);

		/// <summary>
		/// <para>Encodes a set of three credential strings as an authentication identity structure.</para>
		/// </summary>
		/// <param name="pszUserName">
		/// <para>The user name associated with the identity to encode.</para>
		/// </param>
		/// <param name="pszDomainName">
		/// <para>The domain name associated with the identity to encode.</para>
		/// </param>
		/// <param name="pszPackedCredentialsString">
		/// <para>An encoded string version of a SEC_WINNT_AUTH_IDENTITY_EX2 structure that specifies the user's credentials.</para>
		/// </param>
		/// <param name="ppAuthIdentity">
		/// <para>A pointer to the encoded identity structure.</para>
		/// <para>When you have finished using this structure, free it by calling the SspiFreeAuthIdentity function.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, it returns <c>SEC_E_OK</c>.</para>
		/// <para>If the function fails, it returns a nonzero error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/nf-sspi-sspiencodestringsasauthidentity SECURITY_STATUS SEC_ENTRY
		// SspiEncodeStringsAsAuthIdentity( PCWSTR pszUserName, PCWSTR pszDomainName, PCWSTR pszPackedCredentialsString,
		// PSEC_WINNT_AUTH_IDENTITY_OPAQUE *ppAuthIdentity );
		[DllImport(Lib.Secur32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("sspi.h", MSDNShortId = "0aea2f00-fcf1-4c4e-a22f-a669dd4fb294")]
		public static extern Win32Error SspiEncodeStringsAsAuthIdentity([MarshalAs(UnmanagedType.LPWStr)] string pszUserName, [MarshalAs(UnmanagedType.LPWStr)] string pszDomainName, [MarshalAs(UnmanagedType.LPWStr)] string pszPackedCredentialsString, out SafePSEC_WINNT_AUTH_IDENTITY_OPAQUE ppAuthIdentity);

		/// <summary>
		/// <para>Encrypts the specified identity structure.</para>
		/// </summary>
		/// <param name="AuthData">
		/// <para>On input, the identity structure to encrypt. On output, the encrypted identity structure.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, it returns <c>SEC_E_OK</c>.</para>
		/// <para>If the function fails, it returns a nonzero error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/nf-sspi-sspiencryptauthidentity SECURITY_STATUS SEC_ENTRY
		// SspiEncryptAuthIdentity( PSEC_WINNT_AUTH_IDENTITY_OPAQUE AuthData );
		[DllImport(Lib.Secur32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("sspi.h", MSDNShortId = "4460f7ec-35fd-4ad1-8c20-dda9f4d3477a")]
		public static extern Win32Error SspiEncryptAuthIdentity(PSEC_WINNT_AUTH_IDENTITY_OPAQUE AuthData);

		/// <summary>
		/// <para>
		/// Creates a new identity structure that is a copy of the specified identity structure modified to exclude the specified security
		/// support provider (SSP).
		/// </para>
		/// </summary>
		/// <param name="AuthIdentity">
		/// <para>The identity structure to modify.</para>
		/// </param>
		/// <param name="pszPackageName">
		/// <para>The SSP to exclude.</para>
		/// </param>
		/// <param name="ppNewAuthIdentity">
		/// <para>The modified identity structure.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, it returns <c>SEC_E_OK</c>.</para>
		/// <para>If the function fails, it returns a nonzero error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/nf-sspi-sspiexcludepackage SECURITY_STATUS SEC_ENTRY SspiExcludePackage(
		// PSEC_WINNT_AUTH_IDENTITY_OPAQUE AuthIdentity, PCWSTR pszPackageName, PSEC_WINNT_AUTH_IDENTITY_OPAQUE *ppNewAuthIdentity );
		[DllImport(Lib.Secur32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("sspi.h", MSDNShortId = "2f85bb13-b72a-4c26-a328-9424a33a63b8")]
		public static extern Win32Error SspiExcludePackage(PSEC_WINNT_AUTH_IDENTITY_OPAQUE AuthIdentity, [MarshalAs(UnmanagedType.LPWStr)] string pszPackageName, out SafePSEC_WINNT_AUTH_IDENTITY_OPAQUE ppNewAuthIdentity);

		/// <summary>
		/// <para>Frees the memory allocated for the specified identity structure.</para>
		/// </summary>
		/// <param name="AuthData">
		/// <para>The identity structure to free.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, it returns <c>SEC_E_OK</c>.</para>
		/// <para>If the function fails, it returns a nonzero error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/nf-sspi-sspifreeauthidentity VOID SEC_ENTRY SspiFreeAuthIdentity(
		// PSEC_WINNT_AUTH_IDENTITY_OPAQUE AuthData );
		[DllImport(Lib.Secur32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("sspi.h", MSDNShortId = "6199f66e-7adb-4bb9-8e77-a735e31dd5f6")]
		public static extern void SspiFreeAuthIdentity(PSEC_WINNT_AUTH_IDENTITY_OPAQUE AuthData);

		/// <summary>
		/// <para>Gets the host name associated with the specified target.</para>
		/// </summary>
		/// <param name="pszTargetName">
		/// <para>The target for which to get the host name.</para>
		/// </param>
		/// <param name="pszHostName">
		/// <para>The name of the host associated with the target specified by the pszTargetName parameter.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, it returns <c>SEC_E_OK</c>.</para>
		/// <para>If the function fails, it returns a nonzero error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/nf-sspi-sspigettargethostname SECURITY_STATUS SEC_ENTRY
		// SspiGetTargetHostName( PCWSTR pszTargetName, PWSTR *pszHostName );
		[DllImport(Lib.Secur32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("sspi.h", MSDNShortId = "84570dfc-1890-4b82-b411-1f9eaa75537b")]
		public static extern Win32Error SspiGetTargetHostName([MarshalAs(UnmanagedType.LPWStr)] string pszTargetName, [MarshalAs(UnmanagedType.LPWStr)] out string pszHostName);

		/// <summary>
		/// <para>Indicates whether the specified identity structure is encrypted.</para>
		/// </summary>
		/// <param name="EncryptedAuthData">
		/// <para>The identity structure to test.</para>
		/// </param>
		/// <returns>
		/// <para><c>TRUE</c> if the identity structure specified by the EncryptedAuthData parameter is encrypted; otherwise, <c>FALSE</c>.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/nf-sspi-sspiisauthidentityencrypted BOOLEAN SEC_ENTRY
		// SspiIsAuthIdentityEncrypted( PSEC_WINNT_AUTH_IDENTITY_OPAQUE EncryptedAuthData );
		[DllImport(Lib.Secur32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("sspi.h", MSDNShortId = "b85095f5-0ca5-4d75-866d-9b756404c1d9")]
		[return: MarshalAs(UnmanagedType.U1)]
		public static extern bool SspiIsAuthIdentityEncrypted(PSEC_WINNT_AUTH_IDENTITY_OPAQUE EncryptedAuthData);

		/// <summary>
		/// <para>Frees the memory associated with the specified buffer.</para>
		/// </summary>
		/// <param name="DataBuffer">
		/// <para>The buffer to free.</para>
		/// </param>
		/// <returns>
		/// <para>This function does not return a value.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/nf-sspi-sspilocalfree VOID SEC_ENTRY SspiLocalFree( PVOID DataBuffer );
		[DllImport(Lib.Secur32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("sspi.h", MSDNShortId = "afb890a8-a2c3-4c35-ba76-758b047ababb")]
		public static extern void SspiLocalFree(IntPtr DataBuffer);

		/// <summary>
		/// <para>Serializes the specified identity structure into a byte array.</para>
		/// </summary>
		/// <param name="AuthIdentity">
		/// <para>The identity structure to serialize.</para>
		/// </param>
		/// <param name="AuthIdentityLength">
		/// <para>The length, in bytes, of the AuthIdentityByteArray array.</para>
		/// </param>
		/// <param name="AuthIdentityByteArray">
		/// <para>A pointer to an array of byte values that represents the identity specified by the AuthIdentity parameter.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, it returns <c>SEC_E_OK</c>.</para>
		/// <para>If the function fails, it returns a nonzero error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/nf-sspi-sspimarshalauthidentity SECURITY_STATUS SEC_ENTRY
		// SspiMarshalAuthIdentity( PSEC_WINNT_AUTH_IDENTITY_OPAQUE AuthIdentity, unsigned long *AuthIdentityLength, char
		// **AuthIdentityByteArray );
		[DllImport(Lib.Secur32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("sspi.h", MSDNShortId = "e43135ad-7fcd-4da6-a4e4-c91c41eeb865")]
		public static extern Win32Error SspiMarshalAuthIdentity(PSEC_WINNT_AUTH_IDENTITY_OPAQUE AuthIdentity, ref uint AuthIdentityLength, [In, Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] byte[] AuthIdentityByteArray);

		/// <summary>
		/// <para>Generates a target name and credential type from the specified identity structure.</para>
		/// <para>
		/// The values that this function generates can be passed as the values of the TargetName and Type parameters in a call to the
		/// CredRead function.
		/// </para>
		/// </summary>
		/// <param name="AuthIdentity">
		/// <para>The identity structure from which to generate the credentials to be passed to the CredRead function.</para>
		/// </param>
		/// <param name="pszTargetName">
		/// <para>A target name that can be modified by this function depending on the value of the AuthIdentity parameter.</para>
		/// </param>
		/// <param name="pCredmanCredentialType">
		/// <para>The credential type to pass to the CredRead function.</para>
		/// </param>
		/// <param name="ppszCredmanTargetName">
		/// <para>The target name to pass to the CredRead function.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, it returns <c>SEC_E_OK</c>.</para>
		/// <para>If the function fails, it returns a nonzero error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/nf-sspi-sspiprepareforcredread SECURITY_STATUS SEC_ENTRY
		// SspiPrepareForCredRead( PSEC_WINNT_AUTH_IDENTITY_OPAQUE AuthIdentity, PCWSTR pszTargetName, PULONG pCredmanCredentialType, PCWSTR
		// *ppszCredmanTargetName );
		[DllImport(Lib.Secur32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("sspi.h", MSDNShortId = "f473fd7a-5c0f-4a77-829b-28a82ad0d28d")]
		public static extern Win32Error SspiPrepareForCredRead(PSEC_WINNT_AUTH_IDENTITY_OPAQUE AuthIdentity, string pszTargetName, out AdvApi32.CRED_TYPE pCredmanCredentialType, out string ppszCredmanTargetName);

		/// <summary>
		/// <para>
		/// Generates values from an identity structure that can be passed as the values of parameters in a call to the CredWrite function.
		/// </para>
		/// </summary>
		/// <param name="AuthIdentity">
		/// <para>The identity structure from which to generate the credentials to be passed to the CredWrite function.</para>
		/// </param>
		/// <param name="pszTargetName">
		/// <para>A target name that can be modified by this function depending on the value of the AuthIdentity parameter.</para>
		/// <para>Set the value of this parameter to <c>NULL</c> to use the user name as the target.</para>
		/// </param>
		/// <param name="pCredmanCredentialType">
		/// <para>The credential type to pass to the CredWrite function.</para>
		/// </param>
		/// <param name="ppszCredmanTargetName">
		/// <para>The target name to pass to the CredWrite function.</para>
		/// </param>
		/// <param name="ppszCredmanUserName">
		/// <para>The user name to pass to the CredWrite function.</para>
		/// </param>
		/// <param name="ppCredentialBlob">
		/// <para>The credential BLOB to send to the CredWrite function.</para>
		/// </param>
		/// <param name="pCredentialBlobSize">
		/// <para>The size, in bytes, of the ppCredentialBlob buffer.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, it returns <c>SEC_E_OK</c>.</para>
		/// <para>If the function fails, it returns a nonzero error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/nf-sspi-sspiprepareforcredwrite SECURITY_STATUS SEC_ENTRY
		// SspiPrepareForCredWrite( PSEC_WINNT_AUTH_IDENTITY_OPAQUE AuthIdentity, PCWSTR pszTargetName, PULONG pCredmanCredentialType, PCWSTR
		// *ppszCredmanTargetName, PCWSTR *ppszCredmanUserName, PUCHAR *ppCredentialBlob, PULONG pCredentialBlobSize );
		[DllImport(Lib.Secur32, SetLastError = false, ExactSpelling = true, CharSet = CharSet.Unicode)]
		[PInvokeData("sspi.h", MSDNShortId = "4db92042-38f2-42c2-9c94-b24e0eaafdf9")]
		public static extern Win32Error SspiPrepareForCredWrite(PSEC_WINNT_AUTH_IDENTITY_OPAQUE AuthIdentity, string pszTargetName, out AdvApi32.CRED_TYPE pCredmanCredentialType, out string ppszCredmanTargetName, out string ppszCredmanUserName, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 6)] out byte[] ppCredentialBlob, out uint pCredentialBlobSize);

		/// <summary>
		/// <para>Deserializes the specified array of byte values into an identity structure.</para>
		/// </summary>
		/// <param name="AuthIdentityLength">
		/// <para>The size, in bytes, of the AuthIdentityByteArray array.</para>
		/// </param>
		/// <param name="AuthIdentityByteArray">
		/// <para>The array of byte values to deserialize.</para>
		/// </param>
		/// <param name="ppAuthIdentity">
		/// <para>The deserialized identity structure.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, it returns <c>SEC_E_OK</c>.</para>
		/// <para>If the function fails, it returns a nonzero error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/nf-sspi-sspiunmarshalauthidentity SECURITY_STATUS SEC_ENTRY
		// SspiUnmarshalAuthIdentity( unsigned long AuthIdentityLength, char *AuthIdentityByteArray, PSEC_WINNT_AUTH_IDENTITY_OPAQUE
		// *ppAuthIdentity );
		[DllImport(Lib.Secur32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("sspi.h", MSDNShortId = "89798b37-808a-4174-8362-a2dc4ee1b460")]
		public static extern Win32Error SspiUnmarshalAuthIdentity(uint AuthIdentityLength, [In, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] byte[] AuthIdentityByteArray, out SafePSEC_WINNT_AUTH_IDENTITY_OPAQUE ppAuthIdentity);

		/// <summary>
		/// <para>Indicates whether the specified identity structure is valid.</para>
		/// </summary>
		/// <param name="AuthData">
		/// <para>The identity structure to test.</para>
		/// </param>
		/// <returns>
		/// <para>
		/// If the function succeeds, it returns <c>SEC_E_OK</c>, which indicates that the identity structure specified by the AuthData
		/// parameter is valid.
		/// </para>
		/// <para>
		/// If the function fails, it returns a nonzero error code that indicates that the identity structure specified by the AuthData
		/// parameter is not valid.
		/// </para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/nf-sspi-sspivalidateauthidentity SECURITY_STATUS SEC_ENTRY
		// SspiValidateAuthIdentity( PSEC_WINNT_AUTH_IDENTITY_OPAQUE AuthData );
		[DllImport(Lib.Secur32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("sspi.h", MSDNShortId = "82733abd-d984-4902-b6e4-c3809171ad51")]
		public static extern Win32Error SspiValidateAuthIdentity(PSEC_WINNT_AUTH_IDENTITY_OPAQUE AuthData);

		/// <summary>
		/// <para>Fills the block of memory associated with the specified identity structure with zeros.</para>
		/// </summary>
		/// <param name="AuthData">
		/// <para>The identity structure to fill with zeros.</para>
		/// </param>
		/// <returns>
		/// <para>If the function succeeds, it returns <c>SEC_E_OK</c>.</para>
		/// <para>If the function fails, it returns a nonzero error code.</para>
		/// </returns>
		// https://docs.microsoft.com/en-us/windows/desktop/api/sspi/nf-sspi-sspizeroauthidentity VOID SEC_ENTRY SspiZeroAuthIdentity(
		// PSEC_WINNT_AUTH_IDENTITY_OPAQUE AuthData );
		[DllImport(Lib.Secur32, SetLastError = false, ExactSpelling = true)]
		[PInvokeData("sspi.h", MSDNShortId = "50b1f24a-c802-4691-a450-316cb31bf44d")]
		public static extern void SspiZeroAuthIdentity(PSEC_WINNT_AUTH_IDENTITY_OPAQUE AuthData);

		[DllImport(Lib.Secur32, SetLastError = false, ExactSpelling = true)]
		private static extern void SspiFreeAuthIdentity(IntPtr AuthData);

		/// <summary>Provides a handle to an authorization identity.</summary>
		public class PSEC_WINNT_AUTH_IDENTITY_OPAQUE : HANDLE
		{
			/// <summary>
			/// Initializes a new instance of the <see cref="PSEC_WINNT_AUTH_IDENTITY_OPAQUE"/> class and assigns an existing handle.
			/// </summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			public PSEC_WINNT_AUTH_IDENTITY_OPAQUE(IntPtr preexistingHandle) : base(preexistingHandle, true) { }

			/// <summary>
			/// Initializes a new instance of the <see cref="PSEC_WINNT_AUTH_IDENTITY_OPAQUE"/> class and assigns an existing handle.
			/// </summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			protected PSEC_WINNT_AUTH_IDENTITY_OPAQUE(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <summary>
			/// Returns an invalid handle by instantiating a <see cref="PSEC_WINNT_AUTH_IDENTITY_OPAQUE"/> object with <see cref="IntPtr.Zero"/>.
			/// </summary>
			public static PSEC_WINNT_AUTH_IDENTITY_OPAQUE NULL => new PSEC_WINNT_AUTH_IDENTITY_OPAQUE(IntPtr.Zero);
		}

		/// <summary>
		/// Provides a <see cref="SafeHandle"/> to a that releases a created PSEC_WINNT_AUTH_IDENTITY_OPAQUE instance at disposal using SspiFreeAuthIdentity.
		/// </summary>
		public class SafePSEC_WINNT_AUTH_IDENTITY_OPAQUE : PSEC_WINNT_AUTH_IDENTITY_OPAQUE
		{
			/// <summary>
			/// Initializes a new instance of the <see cref="PSEC_WINNT_AUTH_IDENTITY_OPAQUE"/> class and assigns an existing handle.
			/// </summary>
			/// <param name="preexistingHandle">An <see cref="IntPtr"/> object that represents the pre-existing handle to use.</param>
			/// <param name="ownsHandle">
			/// <see langword="true"/> to reliably release the handle during the finalization phase; otherwise, <see langword="false"/> (not recommended).
			/// </param>
			public SafePSEC_WINNT_AUTH_IDENTITY_OPAQUE(IntPtr preexistingHandle, bool ownsHandle = true) : base(preexistingHandle, ownsHandle) { }

			/// <inheritdoc/>
			protected override bool InternalReleaseHandle() { SspiFreeAuthIdentity(this); return true; }
		}

		/// <summary>A custom marshaler for functions using SspiFreeAuthIdentity allocated memory.</summary>
		/// <seealso cref="ICustomMarshaler"/>
		internal class SspiStringMarshaler : ICustomMarshaler
		{
			public static ICustomMarshaler GetInstance(string cookie) => new SspiStringMarshaler();

			public void CleanUpManagedData(object ManagedObj)
			{
			}

			public void CleanUpNativeData(IntPtr pNativeData)
			{
				if (pNativeData == IntPtr.Zero) return;
				SspiFreeAuthIdentity(pNativeData);
				pNativeData = IntPtr.Zero;
			}

			public int GetNativeDataSize() => 0;

			public IntPtr MarshalManagedToNative(object ManagedObj) => IntPtr.Zero;

			public object MarshalNativeToManaged(IntPtr pNativeData) => Marshal.PtrToStringAuto(pNativeData);
		}
	}
}