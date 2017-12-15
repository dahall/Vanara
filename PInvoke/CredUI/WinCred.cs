using System;
using System.Runtime.InteropServices;
using System.Text;
using Vanara.InteropServices;

// ReSharper disable InconsistentNaming
// ReSharper disable FieldCanBeMadeReadOnly.Global

namespace Vanara.PInvoke
{
	public static partial class CredUI
	{
		public const int CRED_MAX_DOMAIN_TARGET_NAME_LENGTH = 256 + 1 + 80;
		public const int CRED_MAX_USERNAME_LENGTH = (256 + 1 + 256);
		public const int CREDUI_MAX_CAPTION_LENGTH = 128;
		public const int CREDUI_MAX_DOMAIN_TARGET_LENGTH = CREDUI_MAX_USERNAME_LENGTH;
		public const int CREDUI_MAX_MESSAGE_LENGTH = 32767;
		public const int CREDUI_MAX_PASSWORD_LENGTH = (512 / 2);
		public const int CREDUI_MAX_USERNAME_LENGTH = CRED_MAX_USERNAME_LENGTH;

		/// <summary>Options for the display of the <see cref="CredUIPromptForCredentials"/> and its functionality.</summary>
		[Flags]
		[PInvokeData("wincred.h")]
		public enum CredentialsDialogOptions
		{
			/// <summary>
			/// Default flags settings These are the following values: <see cref="CREDUI_FLAGS_GENERIC_CREDENTIALS"/>, <see cref="CREDUI_FLAGS_ALWAYS_SHOW_UI"/>
			/// and <see cref="CREDUI_FLAGS_EXPECT_CONFIRMATION"/>
			/// </summary>
			CREDUI_FLAGS_DEFAULT = CREDUI_FLAGS_GENERIC_CREDENTIALS | CREDUI_FLAGS_ALWAYS_SHOW_UI | CREDUI_FLAGS_EXPECT_CONFIRMATION,

			/// <summary>No options are set.</summary>
			CREDUI_FLAGS_NONE = 0,

			/// <summary>Notify the user of insufficient credentials by displaying the "Logon unsuccessful" balloon tip.</summary>
			CREDUI_FLAGS_INCORRECT_PASSWORD = 0x00001,

			/// <summary>
			/// Do not store credentials or display check boxes. You can pass ShowSaveCheckBox with this newDS to display the Save check box only, and the result
			/// is returned in the CredentialsDialog.SaveChecked property.
			/// </summary>
			CREDUI_FLAGS_DO_NOT_PERSIST = 0x00002,

			/// <summary>Populate the combo box with local administrators only.</summary>
			CREDUI_FLAGS_REQUEST_ADMINISTRATOR = 0x00004,

			/// <summary>Populate the combo box with user name/password only. Do not display certificates or smart cards in the combo box.</summary>
			CREDUI_FLAGS_EXCLUDE_CERTIFICATES = 0x00008,

			/// <summary>Populate the combo box with certificates and smart cards only. Do not allow a user name to be entered.</summary>
			CREDUI_FLAGS_REQUIRE_CERTIFICATE = 0x00010,

			/// <summary>
			/// If the check box is selected, show the Save check box and return <c>true</c> in the CredentialsDialog.SaveChecked property, otherwise, return
			/// <c>false</c>. Check box uses the value in the CredentialsDialog.SaveChecked property by default.
			/// </summary>
			CREDUI_FLAGS_SHOW_SAVE_CHECK_BOX = 0x00040,

			/// <summary>
			/// Specifies that a user interface will be shown even if the credentials can be returned from an existing credential in credential manager. This
			/// newDS is permitted only if GenericCredentials is also specified.
			/// </summary>
			CREDUI_FLAGS_ALWAYS_SHOW_UI = 0x00080,

			/// <summary>Populate the combo box with certificates or smart cards only. Do not allow a user name to be entered.</summary>
			CREDUI_FLAGS_REQUIRE_SMARTCARD = 0x00100,

			/// <summary></summary>
			CREDUI_FLAGS_PASSWORD_ONLY_OK = 0x00200,

			/// <summary></summary>
			CREDUI_FLAGS_VALIDATE_USERNAME = 0x00400,

			/// <summary></summary>
			CREDUI_FLAGS_COMPLETE_USERNAME = 0x00800,

			/// <summary>Do not show the Save check box, but the credential is saved as though the box were shown and selected.</summary>
			CREDUI_FLAGS_PERSIST = 0x01000,

			/// <summary>
			/// This newDS is meaningful only in locating a matching credential to pre-fill the dialog box, should authentication fail. When this newDS is
			/// specified, wildcard credentials will not be matched. It has no effect when writing a credential. CredUI does not create credentials that contain
			/// wildcard characters. Any found were either created explicitly by the user or created programmatically, as happens when a RAS connection is made.
			/// </summary>
			CREDUI_FLAGS_SERVER_CREDENTIAL = 0x04000,

			/// <summary>
			/// Specifies that the caller will call ConfirmCredentials after checking to determine whether the returned credentials are actually valid. This
			/// mechanism ensures that credentials that are not valid are not saved to the credential manager. Specify this newDS in all cases unless
			/// DoNotPersist is specified.
			/// </summary>
			CREDUI_FLAGS_EXPECT_CONFIRMATION = 0x20000,

			/// <summary>Consider the credentials entered by the user to be generic credentials, rather than windows credentials.</summary>
			CREDUI_FLAGS_GENERIC_CREDENTIALS = 0x40000,

			/// <summary>
			/// The credential is a "RunAs" credential. The TargetName parameter specifies the name of the command or program being run. It is used for prompting
			/// purposes only.
			/// </summary>
			CREDUI_FLAGS_USERNAME_TARGET_CREDENTIALS = 0x80000,

			/// <summary>Do not allow the user to change the supplied user name.</summary>
			CREDUI_FLAGS_KEEP_USERNAME = 0x100000
		}

		/// <summary>Specifies how the credential should be packed.</summary>
		[Flags]
		public enum CredPackFlags
		{
			/// <summary>Encrypts the credential so that it can only be decrypted by processes in the caller's logon session.</summary>
			CRED_PACK_PROTECTED_CREDENTIALS = 0x1,

			/// <summary>Encrypts the credential in a WOW buffer.</summary>
			CRED_PACK_WOW_BUFFER = 0x2,

			/// <summary>Encrypts the credential in a CRED_GENERIC buffer.</summary>
			CRED_PACK_GENERIC_CREDENTIALS = 0x4,

			/// <summary>
			/// Encrypts the credential of an online identity into a SEC_WINNT_AUTH_IDENTITY_EX2 structure.If CRED_PACK_GENERIC_CREDENTIALS and
			/// CRED_PACK_ID_PROVIDER_CREDENTIALS are not set, encrypts the credentials in a KERB_INTERACTIVE_LOGON buffer.
			/// <para><c>Windows 7, Windows Server 2008 R2, Windows Vista, Windows Server 2008:</c> This value is not supported.</para>
			/// </summary>
			CRED_PACK_ID_PROVIDER_CREDENTIALS = 0x8
		}

		/// <summary>Options for the display of the <see cref="CredUIPromptForWindowsCredentials"/> and its functionality.</summary>
		[Flags]
		[PInvokeData("wincred.h")]
		public enum WindowsCredentialsDialogOptions
		{
			/// <summary>No options are set.</summary>
			CREDUIWIN_NONE = 0,

			/// <summary>
			/// The caller is requesting that the credential provider return the user name and password in plain text. This value cannot be combined with SecurePrompt.
			/// </summary>
			CREDUIWIN_GENERIC = 0x00000001,

			/// <summary>The Save check box is displayed in the dialog box.</summary>
			CREDUIWIN_CHECKBOX = 0x00000002,

			/// <summary>
			/// Only credential providers that support the authentication package specified by the authPackage parameter should be enumerated. This value cannot
			/// be combined with InAuthBufferCredentialsOnly.
			/// </summary>
			CREDUIWIN_AUTHPACKAGE_ONLY = 0x00000010,

			/// <summary>
			/// Only the credentials specified by the InAuthBuffer parameter for the authentication package specified by the authPackage parameter should be
			/// enumerated. If this flag is set, and the InAuthBuffer parameter is NULL, the function fails. This value cannot be combined with AuthPackageOnly.
			/// </summary>
			CREDUIWIN_IN_CRED_ONLY = 0x00000020,

			/// <summary>
			/// Credential providers should enumerate only administrators. This value is intended for User Account Control (UAC) purposes only. We recommend that
			/// external callers not set this flag.
			/// </summary>
			CREDUIWIN_ENUMERATE_ADMINS = 0x00000100,

			/// <summary>Only the incoming credentials for the authentication package specified by the authPackage parameter should be enumerated.</summary>
			CREDUIWIN_ENUMERATE_CURRENT_USER = 0x00000200,

			/// <summary>
			/// The credential dialog box should be displayed on the secure desktop. This value cannot be combined with Generic. Windows Vista: This value is not
			/// supported until Windows Vista with SP1.
			/// </summary>
			CREDUIWIN_SECURE_PROMPT = 0x00001000,

			/// <summary>
			/// The credential provider should align the credential BLOB pointed to by the refOutAuthBuffer parameter to a 32-bit boundary, even if the provider
			/// is running on a 64-bit system.
			/// </summary>
			CREDUIWIN_PACK_32_WOW = 0x10000000,

			/// <summary>
			/// The credential dialog box is invoked by the SspiPromptForCredentials function, and the client is prompted before a prior handshake. If
			/// SSPIPFC_NO_CHECKBOX is passed in the pvInAuthBuffer parameter, then the credential provider should not display the check box.
			/// </summary>
			CREDUIWIN_PREPROMPTING = 0X00002000
		}

		/// <summary>
		/// The CredPackAuthenticationBuffer function converts a string user name and password into an authentication buffer.
		/// <para>
		/// Beginning with Windows 8 and Windows Server 2012, the CredPackAuthenticationBuffer function converts an identity credential into an authentication
		/// buffer, which is a SEC_WINNT_AUTH_IDENTITY_EX2 structure. This buffer can be passed to LsaLogonUser, AcquireCredentialsHandle, or other identity
		/// provider interfaces.
		/// </para>
		/// </summary>
		/// <param name="dwFlags">Specifies how the credential should be packed.</param>
		/// <param name="pszUserName">
		/// A pointer to a null-terminated string that specifies the user name to be converted. For domain users, the string must be in the following format:
		/// <para>DomainName\UserName</para>
		/// <para>
		/// For online identities, if the credential is a plaintext password, the user name format is ProviderName\UserName. If the credential is a
		/// SEC_WINNT_AUTH_IDENTITY_EX2 structure, the user name is an encoded string that is the UserName parameter output of a function call to SspiEncodeAuthIdentityAsStrings.
		/// </para>
		/// <para>
		/// For smart card or certificate credentials, the user name is an encoded string that is the output of a function call to CredMarshalCredential with the
		/// CertCredential option.
		/// </para>
		/// <para><c>Windows Server 2008 R2, Windows 7, Windows Server 2008 and Windows Vista:</c> Online identities are not supported.</para>
		/// </param>
		/// <param name="pszPassword">
		/// A pointer to a null-terminated string that specifies the password to be converted.
		/// <para>
		/// For SEC_WINNT_AUTH_IDENTITY_EX2 credentials, the password is an encoded string that is in the ppszPackedCredentialsString output of a function call
		/// to SspiEncodeAuthIdentityAsStrings.
		/// </para>
		/// <para>For smart card credentials, this is the smart card PIN.</para>
		/// <para><c>Windows Server 2008 R2, Windows 7, Windows Server 2008 and Windows Vista:</c> Online identities are not supported.</para>
		/// </param>
		/// <param name="pPackedCredentials">
		/// A pointer to an array of bytes that, on output, receives the packed authentication buffer. This parameter can be NULL to receive the required buffer
		/// size in the pcbPackedCredentials parameter.
		/// </param>
		/// <param name="pcbPackedCredentials">
		/// A pointer to a DWORD value that specifies the size, in bytes, of the pPackedCredentials buffer. On output, if the buffer is not of sufficient size,
		/// specifies the required size, in bytes, of the pPackedCredentials buffer.
		/// </param>
		/// <returns>TRUE if the function succeeds; otherwise, FALSE. For extended error information, call the GetLastError function.</returns>
		[DllImport(Lib.CredUI, CharSet = CharSet.Auto, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("wincred.h", MSDNShortId = "aa374802")]
		public static extern bool CredPackAuthenticationBuffer(CredPackFlags dwFlags, IntPtr pszUserName, IntPtr pszPassword, IntPtr pPackedCredentials, ref int pcbPackedCredentials);

		/// <summary>The CredUICmdLinePromptForCredentials function prompts for and accepts credential information from a user working in a command-line (console) application. The name and password typed by the user are passed back to the calling application for verification.</summary>
		/// <param name="pszTargetName">A pointer to a null-terminated string that contains the name of the target for the credentials, typically a server name. For DFS connections, this string is of the form ServerName\ShareName. The pszTargetName parameter is used to identify the target information and is used to store and retrieve the credential.</param>
		/// <param name="pContext">Currently reserved and must be NULL.</param>
		/// <param name="dwAuthError">Specifies why prompting for credentials is needed. A caller can pass this Windows error parameter, returned by another authentication call, to allow the dialog box to accommodate certain errors. For example, if the password expired status code is passed, the dialog box prompts the user to change the password on the account.</param>
		/// <param name="UserName">A pointer to a null-terminated string that contains the credential user name. If a nonzero-length string is specified for pszUserName, the user will be prompted only for the password. In the case of credentials other than user name/password, a marshaled format of the credential can be passed in. This string is created by calling CredMarshalCredential.
		/// <para>This function writes the user-supplied name to this buffer, copying a maximum of ulUserNameMaxChars characters. The string in this format can be converted to the user name/password format by calling the CredUIParseUsername function. The string in its marshaled format can be passed directly to a security support provider (SSP).</para>
		/// <para>If the CREDUI_FLAGS_DO_NOT_PERSIST flag is not specified, the value returned in this parameter is of a form that should not be inspected, printed, or persisted other than passing it to CredUIParseUsername. The subsequent results of CredUIParseUsername can be passed only to a client-side authentication API such as WNetAddConnection or the SSP API.</para></param>
		/// <param name="ulUserBufferSize">The maximum number of characters that can be copied to pszUserName including the terminating null character. <note>CREDUI_MAX_USERNAME_LENGTH does not include the terminating null character.</note></param>
		/// <param name="pszPassword">A pointer to a null-terminated string that contains the password for the credentials. If a nonzero-length string is specified for pszPassword, the password parameter will be prefilled with the string.
		/// <para>This function writes the user-supplied password to this buffer, copying a maximum of ulPasswordMaxChars characters. If the CREDUI_FLAGS_DO_NOT_PERSIST flag is not specified, the value returned in this parameter is of a form that should not be inspected, printed, or persisted other than passing it to a client-side authentication function such as WNetAddConnection or an SSP function.</para>
		/// <para>When you have finished using the password, clear the password from memory by calling the SecureZeroMemory function. For more information about protecting passwords, see Handling Passwords.</para></param>
		/// <param name="ulPasswordBufferSize">The maximum number of characters that can be copied to pszPassword including the terminating null character. <note>CREDUI_MAX_USERNAME_LENGTH does not include the terminating null character.</note></param>
		/// <param name="pfSave">A pointer to a BOOL that specifies the initial state of the Save message and receives the state of the Save message after the user has responded to the command prompt. If pfSave is not NULL and CredUIPromptForCredentials returns NO_ERROR, pfSave returns the state of the Save message. If the CREDUI_FLAGS_PERSIST flag is specified, the Save message is not displayed but is considered to be "y". If the CREDUI_FLAGS_DO_NOT_PERSIST flag is specified and CREDUI_FLAGS_SHOW_SAVE_CHECK_BOX is not specified, the Save message is not displayed but is considered to be "n".</param>
		/// <param name="dwFlags">A DWORD value that specifies special behavior for this function.</param>
		/// <returns>The result of the operation.</returns>
		[DllImport(Lib.CredUI, CharSet = CharSet.Auto, SetLastError = true)]
		[PInvokeData("wincred.h", MSDNShortId = "aa374802")]
		public static extern Win32Error CredUICmdLinePromptForCredentials([In, Optional] string pszTargetName, IntPtr pContext, Win32Error dwAuthError, StringBuilder UserName, uint ulUserBufferSize, 
			StringBuilder pszPassword, uint ulPasswordBufferSize, [MarshalAs(UnmanagedType.Bool)] ref bool pfSave, CredentialsDialogOptions dwFlags);

		/// <summary>
		/// The CredUIConfirmCredentials function is called after CredUIPromptForCredentials or CredUICmdLinePromptForCredentials, to confirm the validity of the
		/// credential harvested. CredUIConfirmCredentials must be called if the CREDUI_FLAGS_EXPECT_CONFIRMATION flag was passed to the "prompt" function,
		/// either CredUIPromptForCredentials or CredUICmdLinePromptForCredentials, and the "prompt" function returned NO_ERROR.
		/// <para>
		/// After calling the "prompt" function and before calling CredUIConfirmCredentials, the caller must determine whether the credentials are actually valid
		/// by using the credentials to access the resource specified by pszTargetName. The results of that validation test are passed to
		/// CredUIConfirmCredentials in the bConfirm parameter.
		/// </para>
		/// </summary>
		/// <param name="targetName">
		/// Pointer to a null-terminated string that contains the name of the target for the credentials, typically a domain or server application name. This
		/// must be the same value passed as pszTargetName to CredUIPromptForCredentials or CredUICmdLinePromptForCredentials
		/// </param>
		/// <param name="confirm">
		/// Specifies whether the credentials returned from the prompt function are valid. If TRUE, the credentials are stored in the credential manager as
		/// defined by CredUIPromptForCredentials or CredUICmdLinePromptForCredentials. If FALSE, the credentials are not stored and various pieces of memory are
		/// cleaned up.
		/// </param>
		/// <returns>
		/// Status of the operation is returned. The caller can check this status to determine whether the credential confirm operation succeeded. Most
		/// applications ignore this status code because the application's connection to the resource has already been done. The operation can fail because the
		/// credential was not found on the list of credentials awaiting confirmation, or because the attempt to write or delete the credential failed. Failure
		/// to find the credential on the list can occur because the credential was never queued or as a result of too many credentials being queued. Up to five
		/// credentials can be queued before older ones are discarded as newer ones are queued.
		/// </returns>
		[DllImport(Lib.CredUI, CharSet = CharSet.Auto)]
		[PInvokeData("wincred.h", MSDNShortId = "aa375173")]
		public static extern Win32Error CredUIConfirmCredentials(string targetName, [MarshalAs(UnmanagedType.Bool)] bool confirm);

		/// <summary>The CredUIParseUserName function extracts the domain and user account name from a fully qualified user name.</summary>
		/// <param name="pszUserName">
		/// Pointer to a null-terminated string that contains the user name to be parsed. The name must be in UPN or down-level format, or a certificate.
		/// Typically, pszUserName is received from the CredUIPromptForCredentials or CredUICmdLinePromptForCredentials.
		/// </param>
		/// <param name="pszUser">Pointer to a null-terminated string that receives the user account name.</param>
		/// <param name="ulUserMaxChars">
		/// Maximum number of characters to write to the pszUser string including the terminating null character. <note>CREDUI_MAX_USERNAME_LENGTH does NOT
		/// include the terminating null character.</note>
		/// </param>
		/// <param name="pszDomain">
		/// Pointer to a null-terminated string that receives the domain name. If pszUserName specifies a certificate, pszDomain will be NULL.
		/// </param>
		/// <param name="ulDomainMaxChars">
		/// Maximum number of characters to write to the pszDomain string including the terminating null character. <note>CREDUI_MAX_DOMAIN_TARGET_LENGTH does
		/// NOT include the terminating null character.</note>
		/// </param>
		/// <returns>Status of the operation is returned.</returns>
		[DllImport(Lib.CredUI, CharSet = CharSet.Auto)]
		[PInvokeData("wincred.h", MSDNShortId = "aa375175")]
		public static extern Win32Error CredUIParseUserName(string pszUserName, StringBuilder pszUser, int ulUserMaxChars, StringBuilder pszDomain, int ulDomainMaxChars);

		/// <summary>
		/// The CredUIPromptForCredentials function creates and displays a configurable dialog box that accepts credentials information from a user.
		/// <para>
		/// Applications that target Windows Vista or Windows Server 2008 should call CredUIPromptForWindowsCredentials instead of this function, for the
		/// following reasons:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>CredUIPromptForWindowsCredentials is consistent with the current Windows user interface.</term>
		/// </item>
		/// <item>
		/// <term>
		/// CredUIPromptForWindowsCredentials is more extensible, allowing integration of additional authentication mechanisms such as biometrics and smart cards.
		/// </term>
		/// </item>
		/// <item>
		/// <term>CredUIPromptForWindowsCredentials is compliant with the Common Criteria specification.</term>
		/// </item>
		/// </list>
		/// </summary>
		/// <param name="pUiInfo">A pointer to a CREDUI_INFO structure that contains information for customizing the appearance of the dialog box.</param>
		/// <param name="pszTargetName">
		/// A pointer to a null-terminated string that contains the name of the target for the credentials, typically a server name. For Distributed File System
		/// (DFS) connections, this string is of the form ServerName\ShareName. This parameter is used to identify target information when storing and retrieving credentials.
		/// </param>
		/// <param name="Reserved">This parameter is reserved for future use. It must be NULL.</param>
		/// <param name="dwAuthError">
		/// Specifies why the credential dialog box is needed. A caller can pass this Windows error parameter, returned by another authentication call, to allow
		/// the dialog box to accommodate certain errors. For example, if the password expired status code is passed, the dialog box could prompt the user to
		/// change the password on the account.
		/// </param>
		/// <param name="pszUserName">
		/// A pointer to a null-terminated string that contains the user name for the credentials. If a nonzero-length string is passed, the UserName option of
		/// the dialog box is prefilled with the string. In the case of credentials other than UserName/Password, a marshaled format of the credential can be
		/// passed in. This string is created by calling CredMarshalCredential.
		/// <para>
		/// This function copies the user-supplied name to this buffer, copying a maximum of ulUserNameMaxChars characters. This format can be converted to
		/// UserName/Password format by using CredUIParseUsername. A marshaled format can be passed directly to a security support provider (SSP).
		/// </para>
		/// <para>
		/// If the CREDUI_FLAGS_DO_NOT_PERSIST flag is not specified, the value returned in this parameter is of a form that should not be inspected, printed, or
		/// persisted other than passing it to CredUIParseUsername. The subsequent results of CredUIParseUsername can be passed only to a client-side
		/// authentication function such as WNetAddConnection or an SSP function.
		/// </para>
		/// <para>
		/// If no domain or server is specified as part of this parameter, the value of the pszTargetName parameter is used as the domain to form a
		/// DomainName\UserName pair. On output, this parameter receives a string that contains that DomainName\UserName pair.
		/// </para>
		/// </param>
		/// <param name="ulUserNameMaxChars">
		/// The maximum number of characters that can be copied to pszUserName including the terminating null character. <note>CREDUI_MAX_USERNAME_LENGTH does
		/// not include the terminating null character.</note>
		/// </param>
		/// <param name="pszPassword">
		/// A pointer to a null-terminated string that contains the password for the credentials. If a nonzero-length string is specified for pszPassword, the
		/// password option of the dialog box will be prefilled with the string.
		/// <para>
		/// This function copies the user-supplied password to this buffer, copying a maximum of ulPasswordMaxChars characters. If the
		/// CREDUI_FLAGS_DO_NOT_PERSIST flag is not specified, the value returned in this parameter is of a form that should not be inspected, printed, or
		/// persisted other than passing it to a client-side authentication function such as WNetAddConnection or an SSP function.
		/// </para>
		/// <para>
		/// When you have finished using the password, clear the password from memory by calling the SecureZeroMemory function. For more information about
		/// protecting passwords, see Handling Passwords.
		/// </para>
		/// </param>
		/// <param name="ulPasswordMaxChars">
		/// The maximum number of characters that can be copied to pszPassword including the terminating null character. <note>CREDUI_MAX_USERNAME_LENGTH does
		/// not include the terminating null character.</note>
		/// </param>
		/// <param name="pfSave">
		/// A pointer to a BOOL that specifies the initial state of the Save check box and receives the state of the Save check box after the user has responded
		/// to the dialog box. If this value is not NULL and CredUIPromptForCredentials returns NO_ERROR, then pfSave returns the state of the Save check box
		/// when the user chose OK in the dialog box.
		/// <para>If the CREDUI_FLAGS_PERSIST flag is specified, the Save check box is not displayed, but is considered to be selected.</para>
		/// <para>
		/// If the CREDUI_FLAGS_DO_NOT_PERSIST flag is specified and CREDUI_FLAGS_SHOW_SAVE_CHECK_BOX is not specified, the Save check box is not displayed, but
		/// is considered to be cleared.
		/// </para>
		/// <para>
		/// An application that needs to use CredUI to prompt the user for credentials, but does not need the credential management services provided by the
		/// credential manager, can use pfSave to receive the state of the Save check box after the user closes the dialog box. To do this, the caller must
		/// specify CREDUI_FLAGS_DO_NOT_PERSIST and CREDUI_FLAGS_SHOW_SAVE_CHECK_BOX in dwFlags. When CREDUI_FLAGS_DO_NOT_PERSIST and
		/// CREDUI_FLAGS_SHOW_SAVE_CHECK_BOX are set, the application is responsible for examining *pfSave after the function returns, and if *pfSave is TRUE,
		/// then the application must take the appropriate action to save the user credentials within the resources of the application.
		/// </para>
		/// </param>
		/// <param name="dwFlags">
		/// A DWORD value that specifies special behavior for this function. This value can be a bitwise-OR combination of any enumerated value.
		/// </param>
		/// <returns>Status of the operation is returned.</returns>
		[DllImport(Lib.CredUI, CharSet = CharSet.Auto)]
		[PInvokeData("wincred.h", MSDNShortId = "aa375177")]
		public static extern Win32Error CredUIPromptForCredentials(ref CREDUI_INFO pUiInfo, string pszTargetName, IntPtr Reserved, int dwAuthError, StringBuilder pszUserName, int ulUserNameMaxChars, StringBuilder pszPassword, int ulPasswordMaxChars, [MarshalAs(UnmanagedType.Bool)] ref bool pfSave, CredentialsDialogOptions dwFlags);

		/// <summary>
		/// The CredUIPromptForWindowsCredentials function creates and displays a configurable dialog box that allows users to supply credential information by
		/// using any credential provider installed on the local computer.
		/// </summary>
		/// <param name="pUiInfo">
		/// A pointer to a CREDUI_INFO structure that contains information for customizing the appearance of the dialog box that this function displays.
		/// <para>If the hwndParent member of the CREDUI_INFO structure is not NULL, this function displays a modal dialog box centered on the parent window.</para>
		/// <para>If the hwndParent member of the CREDUI_INFO structure is NULL, the function displays a dialog box centered on the screen.</para>
		/// <para>This function ignores the hbmBanner member of the CREDUI_INFO structure.</para>
		/// </param>
		/// <param name="dwAuthError">
		/// A Windows error code, defined in Winerror.h, that is displayed in the dialog box. If credentials previously collected were not valid, the caller uses
		/// this parameter to pass the error message from the API that collected the credentials (for example, Winlogon) to this function. The corresponding
		/// error message is formatted and displayed in the dialog box. Set the value of this parameter to zero to display no error message.
		/// </param>
		/// <param name="pulAuthPackage">
		/// On input, the value of this parameter is used to specify the authentication package for which the credentials in the pvInAuthBuffer buffer are
		/// serialized. If the value of pvInAuthBuffer is NULL and the CREDUIWIN_AUTHPACKAGE_ONLY flag is set in the dwFlags parameter, only credential providers
		/// capable of serializing credentials for the specified authentication package are to be enumerated.
		/// <para>
		/// To get the appropriate value to use for this parameter on input, call the LsaLookupAuthenticationPackage function and use the value of the
		/// AuthenticationPackage parameter of that function.
		/// </para>
		/// <para>On output, this parameter specifies the authentication package for which the credentials in the ppvOutAuthBuffer buffer are serialized.</para>
		/// </param>
		/// <param name="pvInAuthBuffer">
		/// A pointer to a credential BLOB that is used to populate the credential fields in the dialog box. Set the value of this parameter to NULL to leave the
		/// credential fields empty.
		/// </param>
		/// <param name="ulInAuthBufferSize">The size, in bytes, of the pvInAuthBuffer buffer.</param>
		/// <param name="ppvOutAuthBuffer">
		/// The address of a pointer that, on output, specifies the credential BLOB. For Kerberos, NTLM, or Negotiate credentials, call the
		/// CredUnPackAuthenticationBuffer function to convert this BLOB to string representations of the credentials.
		/// <para>
		/// When you have finished using the credential BLOB, clear it from memory by calling the SecureZeroMemory function, and free it by calling the
		/// CoTaskMemFree function.
		/// </para>
		/// </param>
		/// <param name="pulOutAuthBufferSize">The size, in bytes, of the ppvOutAuthBuffer buffer.</param>
		/// <param name="pfSave">
		/// A pointer to a Boolean value that, on input, specifies whether the Save check box is selected in the dialog box that this function displays. On
		/// output, the value of this parameter specifies whether the Save check box was selected when the user clicks the Submit button in the dialog box. Set
		/// this parameter to NULL to ignore the Save check box.
		/// <para>This parameter is ignored if the CREDUIWIN_CHECKBOX flag is not set in the dwFlags parameter.</para>
		/// </param>
		/// <param name="dwFlags">
		/// A DWORD value that specifies special behavior for this function. This value can be a bitwise-OR combination of any enumerated value.
		/// </param>
		/// <returns>Status of the operation is returned.</returns>
		[DllImport(Lib.CredUI, CharSet = CharSet.Auto)]
		[PInvokeData("wincred.h", MSDNShortId = "aa375178")]
		public static extern int CredUIPromptForWindowsCredentials(ref CREDUI_INFO pUiInfo, int dwAuthError, ref uint pulAuthPackage, IntPtr pvInAuthBuffer, uint ulInAuthBufferSize, out IntPtr ppvOutAuthBuffer, out uint pulOutAuthBufferSize, [MarshalAs(UnmanagedType.Bool)] ref bool pfSave, WindowsCredentialsDialogOptions dwFlags);

		/// <summary>The CredUIReadSSOCred function retrieves the user name for a single logon credential.</summary>
		/// <param name="pszRealm">Pointer to a null-terminated string that specifies the realm. If this parameter is NULL, the default realm is used.</param>
		/// <param name="ppszUsername">Pointer to a pointer to a null-terminated string. When you have finished using the string, free ppszUsername by calling the LocalFree function.</param>
		/// <returns>Status of the operation is returned.</returns>
		[DllImport(Lib.CredUI, CharSet = CharSet.Auto)]
		[PInvokeData("wincred.h", MSDNShortId = "aa375177")]
		public static extern Win32Error CredUIReadSSOCred(string pszRealm, [Out, MarshalAs(UnmanagedType.CustomMarshaler, MarshalTypeRef = typeof(LocalStringMarshaler), MarshalCookie = "Auto")] string ppszUsername);

		/// <summary>The CredUIStoreSSOCred function stores a single logon credential.</summary>
		/// <param name="pszRealm">Pointer to a null-terminated string that specifies the realm. If this parameter is NULL, the default realm is used.</param>
		/// <param name="pszUsername">Pointer to a null-terminated string that specifies the user's name.</param>
		/// <param name="pszPassword">Pointer to a null-terminated string that specifies the user's password. When you have finished using the password, clear the password from memory by calling the SecureZeroMemory function. For more information about protecting passwords, see Handling Passwords.</param>
		/// <param name="bPersist">Boolean value that specifies whether the credentials are persisted. If this value is TRUE, the credentials are persisted. If this value is FALSE, the credentials are not persisted.</param>
		/// <returns>Status of the operation is returned.</returns>
		[DllImport(Lib.CredUI, CharSet = CharSet.Auto)]
		[PInvokeData("wincred.h", MSDNShortId = "aa375181")]
		public static extern Win32Error CredUIStoreSSOCred(string pszRealm, string pszUsername, string pszPassword, [MarshalAs(UnmanagedType.Bool)] bool bPersist);

		/// <summary>
		/// The CredUnPackAuthenticationBuffer function converts an authentication buffer returned by a call to the CredUIPromptForWindowsCredentials function
		/// into a string user name and password.
		/// </summary>
		/// <param name="dwFlags">
		/// Setting the value of this parameter to CRED_PACK_PROTECTED_CREDENTIALS specifies that the function attempts to decrypt the credentials in the
		/// authentication buffer. If the credential cannot be decrypted, the function returns FALSE, and a call to the GetLastError function will return the
		/// value ERROR_NOT_CAPABLE.
		/// <para>How the decryption is done depends on the format of the authentication buffer.</para>
		/// <para>
		/// If the authentication buffer is a SEC_WINNT_AUTH_IDENTITY_EX2 structure, the function can decrypt the buffer if it is encrypted by using
		/// SspiEncryptAuthIdentityEx with the SEC_WINNT_AUTH_IDENTITY_ENCRYPT_SAME_LOGON option.
		/// </para>
		/// <para>
		/// If the authentication buffer is one of the marshaled KERB_*_LOGON structures, the function decrypts the password before returning it in the
		/// pszPassword buffer.
		/// </para>
		/// </param>
		/// <param name="pAuthBuffer">
		/// A pointer to the authentication buffer to be converted.
		/// <para>
		/// This buffer is typically the output of the CredUIPromptForWindowsCredentials or CredPackAuthenticationBuffer function. This must be one of the
		/// following types:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>A SEC_WINNT_AUTH_IDENTITY_EX2 structure for identity credentials. The function does not accept other SEC_WINNT_AUTH_IDENTITY structures.</term>
		/// </item>
		/// <item>
		/// <term>A KERB_INTERACTIVE_LOGON or KERB_INTERACTIVE_UNLOCK_LOGON structure for password credentials.</term>
		/// </item>
		/// <item>
		/// <term>A KERB_CERTIFICATE_LOGON or KERB_CERTIFICATE_UNLOCK_LOGON structure for smart card certificate credentials.</term>
		/// </item>
		/// <item>
		/// <term>GENERIC_CRED for generic credentials.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="cbAuthBuffer">The size, in bytes, of the pAuthBuffer buffer.</param>
		/// <param name="pszUserName">
		/// A pointer to a null-terminated string that receives the user name.
		/// <para>This string can be a marshaled credential. See Remarks.</para>
		/// </param>
		/// <param name="pcchMaxUserName">
		/// A pointer to a DWORD value that specifies the size, in characters, of the pszUserName buffer. On output, if the buffer is not of sufficient size,
		/// specifies the required size, in characters, of the pszUserName buffer. The size includes terminating null character.
		/// </param>
		/// <param name="pszDomainName">A pointer to a null-terminated string that receives the name of the user's domain.</param>
		/// <param name="pcchMaxDomainame">
		/// A pointer to a DWORD value that specifies the size, in characters, of the pszDomainName buffer. On output, if the buffer is not of sufficient size,
		/// specifies the required size, in characters, of the pszDomainName buffer. The size includes the terminating null character. The required size can be
		/// zero if there is no domain name.
		/// </param>
		/// <param name="pszPassword">A pointer to a null-terminated string that receives the password.</param>
		/// <param name="pcchMaxPassword">
		/// A pointer to a DWORD value that specifies the size, in characters, of the pszPassword buffer. On output, if the buffer is not of sufficient size,
		/// specifies the required size, in characters, of the pszPassword buffer. The size includes the terminating null character.
		/// <para>This string can be a marshaled credential. See Remarks.</para>
		/// </param>
		/// <returns>
		/// TRUE if the function succeeds; otherwise, FALSE. For extended error information, call the GetLastError function.The following table shows common
		/// values for the GetLastError function.
		/// </returns>
		[DllImport(Lib.CredUI, CharSet = CharSet.Auto, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("wincred.h", MSDNShortId = "aa375185")]
		public static extern bool CredUnPackAuthenticationBuffer(int dwFlags, IntPtr pAuthBuffer, int cbAuthBuffer, StringBuilder pszUserName, ref int pcchMaxUserName, StringBuilder pszDomainName, ref int pcchMaxDomainame, StringBuilder pszPassword, ref int pcchMaxPassword);

		/// <summary>
		/// The CredUnPackAuthenticationBuffer function converts an authentication buffer returned by a call to the CredUIPromptForWindowsCredentials function
		/// into a string user name and password.
		/// </summary>
		/// <param name="dwFlags">
		/// Setting the value of this parameter to CRED_PACK_PROTECTED_CREDENTIALS specifies that the function attempts to decrypt the credentials in the
		/// authentication buffer. If the credential cannot be decrypted, the function returns FALSE, and a call to the GetLastError function will return the
		/// value ERROR_NOT_CAPABLE.
		/// <para>How the decryption is done depends on the format of the authentication buffer.</para>
		/// <para>
		/// If the authentication buffer is a SEC_WINNT_AUTH_IDENTITY_EX2 structure, the function can decrypt the buffer if it is encrypted by using
		/// SspiEncryptAuthIdentityEx with the SEC_WINNT_AUTH_IDENTITY_ENCRYPT_SAME_LOGON option.
		/// </para>
		/// <para>
		/// If the authentication buffer is one of the marshaled KERB_*_LOGON structures, the function decrypts the password before returning it in the
		/// pszPassword buffer.
		/// </para>
		/// </param>
		/// <param name="pAuthBuffer">
		/// A pointer to the authentication buffer to be converted.
		/// <para>
		/// This buffer is typically the output of the CredUIPromptForWindowsCredentials or CredPackAuthenticationBuffer function. This must be one of the
		/// following types:
		/// </para>
		/// <list type="bullet">
		/// <item>
		/// <term>A SEC_WINNT_AUTH_IDENTITY_EX2 structure for identity credentials. The function does not accept other SEC_WINNT_AUTH_IDENTITY structures.</term>
		/// </item>
		/// <item>
		/// <term>A KERB_INTERACTIVE_LOGON or KERB_INTERACTIVE_UNLOCK_LOGON structure for password credentials.</term>
		/// </item>
		/// <item>
		/// <term>A KERB_CERTIFICATE_LOGON or KERB_CERTIFICATE_UNLOCK_LOGON structure for smart card certificate credentials.</term>
		/// </item>
		/// <item>
		/// <term>GENERIC_CRED for generic credentials.</term>
		/// </item>
		/// </list>
		/// </param>
		/// <param name="cbAuthBuffer">The size, in bytes, of the pAuthBuffer buffer.</param>
		/// <param name="pszUserName">
		/// A pointer to a null-terminated string that receives the user name.
		/// <para>This string can be a marshaled credential. See Remarks.</para>
		/// </param>
		/// <param name="pcchMaxUserName">
		/// A pointer to a DWORD value that specifies the size, in characters, of the pszUserName buffer. On output, if the buffer is not of sufficient size,
		/// specifies the required size, in characters, of the pszUserName buffer. The size includes terminating null character.
		/// </param>
		/// <param name="pszDomainName">A pointer to a null-terminated string that receives the name of the user's domain.</param>
		/// <param name="pcchMaxDomainame">
		/// A pointer to a DWORD value that specifies the size, in characters, of the pszDomainName buffer. On output, if the buffer is not of sufficient size,
		/// specifies the required size, in characters, of the pszDomainName buffer. The size includes the terminating null character. The required size can be
		/// zero if there is no domain name.
		/// </param>
		/// <param name="pszPassword">A pointer to a null-terminated string that receives the password.</param>
		/// <param name="pcchMaxPassword">
		/// A pointer to a DWORD value that specifies the size, in characters, of the pszPassword buffer. On output, if the buffer is not of sufficient size,
		/// specifies the required size, in characters, of the pszPassword buffer. The size includes the terminating null character.
		/// <para>This string can be a marshaled credential. See Remarks.</para>
		/// </param>
		/// <returns>
		/// TRUE if the function succeeds; otherwise, FALSE. For extended error information, call the GetLastError function.The following table shows common
		/// values for the GetLastError function.
		/// </returns>
		[DllImport(Lib.CredUI, CharSet = CharSet.Auto, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		[PInvokeData("wincred.h", MSDNShortId = "aa375173")]
		public static extern bool CredUnPackAuthenticationBuffer(int dwFlags, IntPtr pAuthBuffer, int cbAuthBuffer, IntPtr pszUserName, ref int pcchMaxUserName, IntPtr pszDomainName, ref int pcchMaxDomainame, IntPtr pszPassword, ref int pcchMaxPassword);

		[DllImport(Lib.CredUI, CharSet = CharSet.Auto)]
		[PInvokeData("wincred.h", MSDNShortId = "aa375181")]
		public static extern Win32Error XCredUIStoreSSOCred(string pszRealm, string pszUsername, string pszPassword, [MarshalAs(UnmanagedType.Bool)] bool bPersist);

		/// <summary>
		/// The CREDUI_INFO structure is used to pass information to the CredUIPromptForCredentials function that creates a dialog box used to obtain credentials information.
		/// </summary>
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
		[PInvokeData("wincred.h", MSDNShortId = "aa375183")]
		public struct CREDUI_INFO
		{
			/// <summary>Set to the size of the CREDUI_INFO structure.</summary>
			public int cbSize;

			/// <summary>
			/// Specifies the handle to the parent window of the dialog box. The dialog box is modal with respect to the parent window. If this member is NULL,
			/// the desktop is the parent window of the dialog box.
			/// </summary>
			public IntPtr hwndParent;

			/// <summary>Pointer to a string containing a brief message to display in the dialog box. The length of this string should not exceed CREDUI_MAX_MESSAGE_LENGTH.</summary>
			public string pszMessageText;

			/// <summary>Pointer to a string containing the title for the dialog box. The length of this string should not exceed CREDUI_MAX_CAPTION_LENGTH.</summary>
			public string pszCaptionText;

			/// <summary>Bitmap to display in the dialog box. If this member is NULL, a default bitmap is used. The bitmap size is limited to 320x60 pixels.</summary>
			public IntPtr hbmBanner;

			/// <summary>Initializes a new instance of the <see cref="CREDUI_INFO"/> struct.</summary>
			/// <param name="hwndOwner">Specifies the handle to the parent window of the dialog box.</param>
			/// <param name="caption">The string containing the title for the dialog box.</param>
			/// <param name="message">The string containing a brief message to display in the dialog box.</param>
			public CREDUI_INFO(IntPtr hwndOwner, string caption, string message)
			{
				cbSize = Marshal.SizeOf(typeof(CREDUI_INFO));
				hwndParent = hwndOwner;
				if (caption?.Length > CREDUI_MAX_CAPTION_LENGTH)
					throw new ArgumentOutOfRangeException(nameof(caption), $"The caption may not be longer than {CREDUI_MAX_CAPTION_LENGTH}.");
				pszCaptionText = caption ?? string.Empty;
				if (message?.Length > CREDUI_MAX_MESSAGE_LENGTH)
					throw new ArgumentOutOfRangeException(nameof(message), $"The message may not be longer than {CREDUI_MAX_MESSAGE_LENGTH}.");
				pszMessageText = message;
				hbmBanner = IntPtr.Zero;
			}
		}
	}
}