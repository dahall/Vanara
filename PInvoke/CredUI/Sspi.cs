using System;
using System.Runtime.InteropServices;
using Vanara.InteropServices;
using static Vanara.PInvoke.AdvApi32;
using static Vanara.PInvoke.Secur32;

namespace Vanara.PInvoke;

/// <summary>Functions and definitions from CredUI.dll</summary>
public static partial class CredUI
{
	/// <summary>The credential is a certificate.</summary>
	public static readonly Guid SEC_WINNT_AUTH_DATA_TYPE_CERT = new Guid("{0x235f69ad, 0x73fb, 0x4dbc, { 0x82, 0x3, 0x6, 0x29, 0xe7, 0x39, 0x33, 0x9b } }");

	/// <summary>The credential is authentication data from a cryptographic service provider (CSP).</summary>
	public static readonly Guid SEC_WINNT_AUTH_DATA_TYPE_CSP_DATA = new Guid("{0x68fd9879, 0x79c, 0x4dfe, { 0x82, 0x81, 0x57, 0x8a, 0xad, 0xc1, 0xc1, 0x0 } }");

	/// <summary>The credential is a password.</summary>
	public static readonly Guid SEC_WINNT_AUTH_DATA_TYPE_PASSWORD = new Guid("{0x28bfc32f, 0x10f6, 0x4738, { 0x98, 0xd1, 0x1a, 0xc0, 0x61, 0xdf, 0x71, 0x6a } }");

	/// <summary>Flags that determine the behavior of this function.</summary>
	[Flags]
	public enum SSPIPFC
	{
		/// <summary>
		/// The value of the pfSave parameter is ignored, and the credentials collected by this function are not saved.
		/// <para>
		/// Windows 7 and Windows Server 2008 R2: The value of the pfSave parameter is ignored, and the credentials collected by this
		/// function are not saved. Only the name of this possible value was SSPIPFC_SAVE_CRED_BY_CALLER.
		/// </para>
		/// </summary>
		SSPIPFC_CREDPROV_DO_NOT_SAVE = 0x00000001,

		/// <summary>
		/// The value signifies that password and smart card credential providers will not display the "Remember my credentials" checkbox
		/// to the user. The SspiPromptForCredentials function passes this flag value, SSPIPFC_NO_CHECKBOX, in the pvInAuthBuffer
		/// parameter of CredUIPromptForWindowsCredentials function.
		/// </summary>
		SSPIPFC_NO_CHECKBOX = 0x00000002,
	}

	/// <summary>Retrieves context information from a credential provider.</summary>
	/// <param name="ContextHandle">
	/// A pointer to a SEC_WINNT_CREDUI_CONTEXT structure retrieved during a previous call to the SspiUnmarshalCredUIContext function.
	/// </param>
	/// <param name="CredType">The type of credential specified by the ContextHandle parameter.</param>
	/// <param name="LogonId">
	/// The logon ID associated with the credential specified by the ContextHandle parameter. The caller must be running as LocalSystem
	/// to specify a logon ID.
	/// </param>
	/// <param name="CredUIContexts">
	/// A pointer to a SEC_WINNT_CREDUI_CONTEXT_VECTOR structure that specifies the offset and size of the data in the structure
	/// specified by the ContextHandle parameter.
	/// </param>
	/// <param name="TokenHandle">A handle to the specified user's token.</param>
	/// <returns>If the function succeeds, it returns SEC_E_OK. If the function fails, it returns a nonzero error code.</returns>
	[DllImport(Lib.CredUI, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Sspi.h")]
	public static extern Win32Error SspiGetCredUIContext(PSEC_WINNT_CREDUI_CONTEXT ContextHandle, in Guid CredType, LUID LogonId, out PSEC_WINNT_CREDUI_CONTEXT_VECTOR CredUIContexts, out SafeHTOKEN TokenHandle);

	/// <summary>
	/// Indicates whether an error returned after a call to either the InitializeSecurityContext or the AcceptSecurityContext function
	/// requires an additional call to the SspiPromptForCredentials function.
	/// </summary>
	/// <param name="ErrorOrNtStatus">The error to test.</param>
	/// <returns>
	/// TRUE if the error specified by the ErrorOrNtStatus parameter indicates that an additional call to SspiPromptForCredentials is
	/// necessary; otherwise, FALSE.
	/// </returns>
	[DllImport(Lib.CredUI, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Sspi.h")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool SspiIsPromptingNeeded(uint ErrorOrNtStatus);

	/// <summary>Allows a Security Support Provider Interface (SSPI) application to prompt a user to enter credentials.</summary>
	/// <param name="pszTargetName">The name of the target to use.</param>
	/// <param name="pUiInfo">
	/// A pointer to a CREDUI_INFO structure that contains information for customizing the appearance of the dialog box that this
	/// function displays.
	/// <para>
	/// If the hwndParent member of the CREDUI_INFO structure is not NULL, this function displays a modal dialog box centered on the
	/// parent window.
	/// </para>
	/// <para>If the hwndParent member of the CREDUI_INFO structure is NULL, the function displays a dialog box centered on the screen.</para>
	/// <para>This function ignores the hbmBanner member of the CREDUI_INFO structure.</para>
	/// </param>
	/// <param name="dwAuthError">
	/// A Windows error code, defined in Winerror.h, that is displayed in the dialog box. If credentials previously collected were not
	/// valid, the caller uses this parameter to pass the error message from the API that collected the credentials (for example,
	/// Winlogon) to this function. The corresponding error message is formatted and displayed in the dialog box. Set the value of this
	/// parameter to zero to display no error message.
	/// </param>
	/// <param name="pszPackage">The name of the security package to use.</param>
	/// <param name="pInputAuthIdentity">
	/// An identity structure that is used to populate credential fields in the dialog box. To leave the credential fields empty, set the
	/// value of this parameter to NULL.
	/// </param>
	/// <param name="ppAuthIdentity">
	/// An identity structure that represents the credentials this function collects. When you have finished using this structure, free
	/// it by calling the SspiFreeAuthIdentity function.
	/// </param>
	/// <param name="pfSave">
	/// A pointer to a Boolean value that, on input, specifies whether the Save check box is selected in the dialog box that this
	/// function displays. On output, the value of this parameter specifies whether the Save check box was selected when the user clicked
	/// the Submit button in the dialog box. Set this parameter to NULL to ignore the Save check box.
	/// <para>This parameter is ignored if the CREDUIWIN_CHECKBOX flag is not set in the dwFlags parameter.</para>
	/// </param>
	/// <param name="dwFlags">Flags that determine the behavior of this function.</param>
	/// <returns>If the function succeeds, it returns SEC_E_OK. If the function fails, it returns a nonzero error code.</returns>
	[DllImport(Lib.CredUI, SetLastError = false, CharSet = CharSet.Auto)]
	[PInvokeData("Sspi.h")]
	public static extern Win32Error SspiPromptForCredentials(string pszTargetName, in CREDUI_INFO pUiInfo, uint dwAuthError, string pszPackage, PSEC_WINNT_AUTH_IDENTITY_OPAQUE pInputAuthIdentity, out SafePSEC_WINNT_AUTH_IDENTITY_OPAQUE ppAuthIdentity, ref bool pfSave, SSPIPFC dwFlags);

	/// <summary>
	/// Deserializes credential information obtained by a credential provider during a previous call to the
	/// ICredentialProvider::SetSerialization method.
	/// </summary>
	/// <param name="MarshaledCredUIContext">
	/// The serialized credential information obtained as the rgbSerialization member of the CREDENTIAL_PROVIDER_CREDENTIAL_SERIALIZATION
	/// structure retrieved from a call to the ICredentialProvider::SetSerialization method.
	/// </param>
	/// <param name="MarshaledCredUIContextLength">The size, in bytes, of the MarshaledCredUIContext buffer.</param>
	/// <param name="CredUIContext">A pointer to a SEC_WINNT_CREDUI_CONTEXT structure that specifies the deserialized credential information.</param>
	/// <returns></returns>
	[DllImport(Lib.CredUI, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Sspi.h")]
	public static extern Win32Error SspiUnmarshalCredUIContext([MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] byte[] MarshaledCredUIContext, uint MarshaledCredUIContextLength, out PSEC_WINNT_CREDUI_CONTEXT CredUIContext);

	/// <summary>Updates the credentials associated with the specified context.</summary>
	/// <param name="ContextHandle">
	/// A pointer to a SEC_WINNT_CREDUI_CONTEXT structure retrieved during a previous call to the SspiUnmarshalCredUIContext function.
	/// </param>
	/// <param name="CredType">The type of credential specified by the ContextHandle parameter.</param>
	/// <param name="FlatCredUIContextLength">The size, in bytes, of the FlatCredUIContext buffer.</param>
	/// <param name="FlatCredUIContext">The values with which to update the specified credentials.</param>
	/// <returns>If the function succeeds, it returns SEC_E_OK. If the function fails, it returns a nonzero error code.</returns>
	[DllImport(Lib.CredUI, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("Sspi.h")]
	public static extern Win32Error SspiUpdateCredentials(IntPtr ContextHandle, in Guid CredType, uint FlatCredUIContextLength, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] byte[] FlatCredUIContext);

	/// <summary>
	/// Specifies unserialized credential information. The credential information can be serialized by passing it as the rgbSerialization
	/// member of a CREDENTIAL_PROVIDER_CREDENTIAL_SERIALIZATION structure in a call to the ICredentialProvider::SetSerialization method.
	/// <para>The unserialized information can be obtained by calling the SspiUnmarshalCredUIContext function.</para>
	/// </summary>
	[StructLayout(LayoutKind.Sequential)]
	public class PSEC_WINNT_CREDUI_CONTEXT
	{
		/// <summary>The size, in bytes, of the header.</summary>
		public ushort cbHeaderLength;

		/// <summary>A handle to the credential context.</summary>
		public IntPtr CredUIContextHandle;

		/// <summary>
		/// Specifies why prompting for credentials is needed. A caller can pass this Windows error parameter, returned by another
		/// authentication call, to allow the dialog box to accommodate certain errors. For example, if the password expired status code
		/// is passed, the dialog box prompts the user to change the password on the account.
		/// </summary>
		public Win32Error dwAuthError;

		/// <summary>The opaque authentication identity data. SEC_WINNT_AUTH_IDENTITY_OPAQUE.</summary>
		public IntPtr pInputAuthIdentity;

		/// <summary>The name of the target.</summary>
		public StrPtrUni TargetName;

		/// <summary>A pointer to a CREDUI_INFO structure that specifies information for the credential prompt dialog box.</summary>
		public IntPtr UIInfo;
	}

	/// <summary>Specifies the offset and size of the credential context data in a SEC_WINNT_CREDUI_CONTEXT structure.</summary>
	[StructLayout(LayoutKind.Sequential)]
	public class PSEC_WINNT_CREDUI_CONTEXT_VECTOR
	{
		/// <summary>The number of bytes from the beginning of the structure to the context data.</summary>
		public uint CredUIContextArrayOffset;

		/// <summary>The size, in bytes, of the context data.</summary>
		public ushort CredUIContextCount;
	}
}