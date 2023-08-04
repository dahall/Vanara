namespace Vanara.PInvoke;

public static partial class AdvApi32
{
	/// <summary>The <c>MSChapSrvChangePassword</c> function changes the password of a user account.</summary>
	/// <param name="ServerName">
	/// A pointer to a null-terminated Unicode string that specifies the Universal Naming Convention (UNC) name of the server on which to
	/// operate. If this parameter is <c>NULL</c>, the function operates on the local computer.
	/// </param>
	/// <param name="UserName">
	/// A pointer to a null-terminated Unicode string that specifies the name of the user whose password is being changed.
	/// </param>
	/// <param name="LmOldPresent">
	/// A <c>BOOLEAN</c> that specifies whether the password designated by LmOldOwfPassword is valid. LmOldPresent is <c>FALSE</c> if the
	/// LmOldOwfPassword password is greater than 128-bits in length, and therefore cannot be represented by a Lan Manager (LM) one-way
	/// function (OWF) password. Otherwise, it is <c>TRUE</c>.
	/// </param>
	/// <param name="LmOldOwfPassword">
	/// A pointer to a LM_OWF_PASSWORD structure that contains the OWF of the user's current LM password. This parameter is ignored if
	/// LmOldPresent is <c>FALSE</c>.
	/// </param>
	/// <param name="LmNewOwfPassword">A pointer to a LM_OWF_PASSWORD structure that contains the OWF of the user's new LM password.</param>
	/// <param name="NtOldOwfPassword">A pointer to a NT_OWF_PASSWORD structure that contains the OWF of the user's current NT password.</param>
	/// <param name="NtNewOwfPassword">A pointer to a NT_OWF_PASSWORD structure that contains the OWF of the user's new NT password.</param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>STATUS_SUCCESS (0x00000000)</c>.</para>
	/// <para>If the function fails, the return value is one of the following error codes from ntstatus.h.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>STATUS_ACCESS_DENIED 0xC0000022</term>
	/// <term>The calling application does not have the appropriate privilege to complete the operation.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_HANDLE 0xC0000008</term>
	/// <term>The specified server or user name was not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_ILL_FORMED_PASSWORD 0xC000006B</term>
	/// <term>New password is poorly formed, for example, it contains characters that cannot be entered from the keyboard.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_PASSWORD_RESTRICTION 0xC000006C</term>
	/// <term>
	/// A restriction prevents the password from being changed. Possible restrictions include time restrictions on how often a password
	/// is allowed to be changed or length restrictions on the provided password. This error is also returned if the new password matched
	/// a password in the recent history log for the account. Security administrators specify how many of the most recently used
	/// passwords are not available for re-use. These are kept in the password recent history log.
	/// </term>
	/// </item>
	/// <item>
	/// <term>STATUS_WRONG_PASSWORD 0xC000006A</term>
	/// <term>The old password parameter does not match the user's current password.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_DOMAIN_STATE 0xC00000DD</term>
	/// <term>The domain controlelr is not in an enabled state. The domain controller must be enabled for this operation.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_DOMAIN_ROLE 0xC00000DE</term>
	/// <term>
	/// The domain controller is serving in the incorrect role to perform the requested operation. The operation can only be performed by
	/// the primary domain controller.
	/// </term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_PARAMETER_MIX 0xC0000030</term>
	/// <term>The value of the LmOldPresent parameter is not correct for the contents of the old and new parameter pairs.</term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>
	/// The value specified by LmNewOwfPassword must always contain a valid OWF. If the new password is greater than 128-bits long, and
	/// therefore cannot be represented by a LAN Manager (LM) password, then LmNewOwfPassword should be the LM OWF of a <c>NULL</c> password.
	/// </para>
	/// <para>This function allows users to change their own passwords only if they have the access: USER_CHANGE_PASSWORD.</para>
	/// <para>
	/// This function fails with <c>STATUS_PASSWORD_RESTRICTION</c> if the attempt to change the password conflicts with an
	/// administrative password restriction.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/mschapp/nf-mschapp-mschapsrvchangepassword DWORD MSChapSrvChangePassword(
	// PWSTR ServerName, PWSTR UserName, BOOLEAN LmOldPresent, PLM_OWF_PASSWORD LmOldOwfPassword, PLM_OWF_PASSWORD LmNewOwfPassword,
	// PNT_OWF_PASSWORD NtOldOwfPassword, PNT_OWF_PASSWORD NtNewOwfPassword );
	[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("mschapp.h", MSDNShortId = "6c154675-4c82-4305-8231-577f990eaeb1")]
	public static extern NTStatus MSChapSrvChangePassword([MarshalAs(UnmanagedType.LPWStr)] string? ServerName, [MarshalAs(UnmanagedType.LPWStr)] string UserName, [MarshalAs(UnmanagedType.U1)] bool LmOldPresent,
		in LM_OWF_PASSWORD LmOldOwfPassword, in LM_OWF_PASSWORD LmNewOwfPassword, in LM_OWF_PASSWORD NtOldOwfPassword, in LM_OWF_PASSWORD NtNewOwfPassword);

	/// <summary>
	/// <para>The <c>MSChapSrvChangePassword2</c> function changes the password of a user account while supporting mutual encryption.</para>
	/// </summary>
	/// <param name="ServerName">
	/// <para>
	/// A pointer to a null-terminated Unicode string that specifies the Universal Naming Convention (UNC) name of the server on which to
	/// operate. If this parameter is <c>NULL</c>, the function operates on the local computer.
	/// </para>
	/// </param>
	/// <param name="UserName">
	/// <para>A pointer to a null-terminated Unicode string that specifies the name of the user whose password is being changed.</para>
	/// </param>
	/// <param name="NewPasswordEncryptedWithOldNt">
	/// <para>
	/// A pointer to a SAMPR_ENCRYPTED_USER_PASSWORD structure that contains the new clear text password encrypted using the current NT
	/// one-way function (OWF) password hash as the encryption key.
	/// </para>
	/// <para>
	/// <c>Note</c> Use the <c>NewPasswordEncryptedWithOldNtPasswordHash()</c> function as defined in RFC 2433, section A.11 to calculate
	/// the cipher for NewPasswordEncryptedWithOldNt.
	/// </para>
	/// </param>
	/// <param name="OldNtOwfPasswordEncryptedWithNewNt">
	/// <para>
	/// A pointer to an ENCRYPTED_NT_OWF_PASSWORD structure that contains the old NT OWF password hash encrypted using the new NT OWF
	/// password hash as the encryption key.
	/// </para>
	/// </param>
	/// <param name="LmPresent">
	/// <para>
	/// A <c>BOOLEAN</c> that specifies if the current Lan Manager (LM) or NT OWF password hashes are used as the encryption keys to
	/// generate the NewPasswordEncryptedWithOldNt and OldNtOwfPasswordEncryptedWithNewNt ciphers. If <c>TRUE</c>, the LM OWF password
	/// hashes are used rather than the NT OWF password hashes.
	/// </para>
	/// </param>
	/// <param name="NewPasswordEncryptedWithOldLm">
	/// <para>
	/// A pointer to a SAMPR_ENCRYPTED_USER_PASSWORD structure that contains the new clear text password encrypted using the current LM
	/// OWF password hash.
	/// </para>
	/// <para>
	/// <c>Note</c> Use the <c>NewPasswordEncryptedWithOldLmPasswordHash()</c> function as defined in RFC 2433, section A.15 to calculate
	/// the cipher for NewPasswordEncryptedWithOldLm.
	/// </para>
	/// </param>
	/// <param name="OldLmOwfPasswordEncryptedWithNewLmOrNt">
	/// <para>
	/// A pointer to a ENCRYPTED_LM_OWF_PASSWORD structure that contains the current LM OWF password hash encrypted using the new LM OWF
	/// password hash.
	/// </para>
	/// </param>
	/// <returns>
	/// <para>If the function succeeds, the return value is <c>STATUS_SUCCESS (0x00000000)</c>.</para>
	/// <para>If the function fails, the return value is one of the following error codes from ntstatus.h.</para>
	/// <list type="table">
	/// <listheader>
	/// <term>Return code/value</term>
	/// <term>Description</term>
	/// </listheader>
	/// <item>
	/// <term>STATUS_ACCESS_DENIED 0xC0000022</term>
	/// <term>The calling application does not have the appropriate privilege to complete the operation.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_HANDLE 0xC0000008</term>
	/// <term>The specified server or user name was not valid.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_ILL_FORMED_PASSWORD 0xC000006B</term>
	/// <term>New password is poorly formed, for example, it contains characters that cannot be entered from the keyboard.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_PASSWORD_RESTRICTION 0xC000006C</term>
	/// <term>
	/// A restriction prevents the password from being changed. Possible restrictions include time restrictions on how often a password
	/// is allowed to be changed or length restrictions on the provided password. This error is also returned if the new password matched
	/// a password in the recent history log for the account. Security administrators specify how many of the most recently used
	/// passwords are not available for re-use. These are kept in the password recent history log.
	/// </term>
	/// </item>
	/// <item>
	/// <term>STATUS_WRONG_PASSWORD 0xC000006A</term>
	/// <term>The old password parameter does not match the user's current password.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_DOMAIN_STATE 0xC00000DD</term>
	/// <term>The domain controller is not in an enabled state. The domain controller must be enabled for this operation.</term>
	/// </item>
	/// <item>
	/// <term>STATUS_INVALID_DOMAIN_ROLE 0xC00000DE</term>
	/// <term>
	/// The domain controller is serving in the incorrect role to perform the requested operation. The operation can only be performed by
	/// the primary domain controller.
	/// </term>
	/// </item>
	/// </list>
	/// </returns>
	/// <remarks>
	/// <para>This function allows users to change their own passwords only if they have the access: USER_CHANGE_PASSWORD.</para>
	/// <para>
	/// This function fails with <c>STATUS_PASSWORD_RESTRICTION</c> if the attempt to change the password conflicts with an
	/// administrative password restriction.
	/// </para>
	/// </remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/mschapp/nf-mschapp-mschapsrvchangepassword2 DWORD MSChapSrvChangePassword2(
	// PWSTR ServerName, PWSTR UserName, PSAMPR_ENCRYPTED_USER_PASSWORD NewPasswordEncryptedWithOldNt, PENCRYPTED_NT_OWF_PASSWORD
	// OldNtOwfPasswordEncryptedWithNewNt, BOOLEAN LmPresent, PSAMPR_ENCRYPTED_USER_PASSWORD NewPasswordEncryptedWithOldLm,
	// PENCRYPTED_LM_OWF_PASSWORD OldLmOwfPasswordEncryptedWithNewLmOrNt );
	[DllImport(Lib.AdvApi32, SetLastError = false, ExactSpelling = true)]
	[PInvokeData("mschapp.h", MSDNShortId = "91ea4b98-79e4-4764-a580-a622d1491943")]
	public static extern NTStatus MSChapSrvChangePassword2([MarshalAs(UnmanagedType.LPWStr)] string? ServerName, [MarshalAs(UnmanagedType.LPWStr)] string UserName, in SAMPR_ENCRYPTED_USER_PASSWORD NewPasswordEncryptedWithOldNt,
		in ENCRYPTED_LM_OWF_PASSWORD OldNtOwfPasswordEncryptedWithNewNt, [MarshalAs(UnmanagedType.U1)] bool LmPresent, in SAMPR_ENCRYPTED_USER_PASSWORD NewPasswordEncryptedWithOldLm, in ENCRYPTED_LM_OWF_PASSWORD OldLmOwfPasswordEncryptedWithNewLmOrNt);

	/// <summary>The <c>CYPHER_BLOCK</c> is the basic unit of storage for the one-way function (OWF) password hashes.</summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/mschapp/ns-mschapp-cypher_block typedef struct _CYPHER_BLOCK { CHAR
	// data[CYPHER_BLOCK_LENGTH]; } CYPHER_BLOCK;
	[PInvokeData("mschapp.h", MSDNShortId = "eb0e38ed-8d12-4df2-be58-7ac18447121f")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct CYPHER_BLOCK
	{
		/// <summary>
		/// An array of CHAR used to store the password hashes and cipher text passed by the MS-CHAP password management API.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
		public byte[] data;
	}

	/// <summary>
	/// The <c>ENCRYPTED_LM_OWF_PASSWORD</c> stores a user's encrypted Lan Manager (LM) one-way function (OWF) password hash.
	/// </summary>
	/// <remarks>ENCRYPTED_NT_OWF_PASSWORD is an alias for this structure.</remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/mschapp/ns-mschapp-_encrypted_lm_owf_password typedef struct
	// _ENCRYPTED_LM_OWF_PASSWORD { CYPHER_BLOCK data[2]; } ENCRYPTED_LM_OWF_PASSWORD, *PENCRYPTED_LM_OWF_PASSWORD;
	[PInvokeData("mschapp.h", MSDNShortId = "83498d3f-0ac5-435c-804e-a4baa1ae855d")]
	public struct ENCRYPTED_LM_OWF_PASSWORD
	{
		/// <summary>
		/// An array of CYPHER_BLOCK structures that contain an encrypted LM OWF password hash. The contents of the array are calculated
		/// using the <c>OldLmPasswordHashEncryptedWithNewNtPasswordHash()</c> function as defined in RFC 2433, section A.16.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
		public CYPHER_BLOCK[] data;
	}

	/// <summary>The <c>LM_OWF_PASSWORD</c> stores the Lan Manage (LM) one-way function (OWF) of a user's password.</summary>
	/// <remarks>NT_OWF_PASSWORD is an alias for this structure.</remarks>
	// https://docs.microsoft.com/en-us/windows/desktop/api/mschapp/ns-mschapp-_lm_owf_password typedef struct _LM_OWF_PASSWORD {
	// CYPHER_BLOCK data[2]; } LM_OWF_PASSWORD;
	[PInvokeData("mschapp.h", MSDNShortId = "db155f34-fa57-4449-9319-d46561fd18c0")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct LM_OWF_PASSWORD
	{
		/// <summary>
		/// An array of CYPHER_BLOCK structures that contain a LM OWF password hash. The contents of the array are calculated using the
		/// <c>LmEncryptedPasswordHash()</c> function as defined in RFC 2433, section A.8.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
		public CYPHER_BLOCK[] data;
	}

	/// <summary>The <c>SAMPR_ENCRYPTED_USER_PASSWORD</c> stores a user's encrypted password.</summary>
	// https://docs.microsoft.com/en-us/windows/desktop/api/mschapp/ns-mschapp-_sampr_encrypted_user_password typedef struct
	// _SAMPR_ENCRYPTED_USER_PASSWORD { UCHAR *Buffer[(256 2)+ 4]; } SAMPR_ENCRYPTED_USER_PASSWORD, *PSAMPR_ENCRYPTED_USER_PASSWORD;
	[PInvokeData("mschapp.h", MSDNShortId = "10137c59-db99-4d70-9716-6f05369084a0")]
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
	public struct SAMPR_ENCRYPTED_USER_PASSWORD
	{
		/// <summary>
		/// An array contains an encrypted password. The contents of the array are calculated using either the
		/// <c>NewPasswordEncryptedWithOldNtPasswordHash</c> or <c>NewPasswordEncryptedWithOldLmPasswordHash</c> functions as defined in
		/// RFC 2433, sections A.11 and A.15 respectively.
		/// </summary>
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = (256 * 2) + 4)]
		public byte[] Buffer;
	}
}