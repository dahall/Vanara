using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Vanara.Extensions;
using Vanara.InteropServices;
using Vanara.PInvoke;
using static Vanara.PInvoke.NetApi32;

namespace Vanara
{
    /// <summary>Represents a user account on a server.</summary>
    [DefaultProperty(nameof(UserName))]
    public sealed class UserAccount : IEquatable<UserAccount>, INamedEntity
    {
        /// <summary>The base date</summary>
        internal static readonly DateTime baseDate = new(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        /// <summary>Initializes a new instance of the <see cref="UserAccount"/> class.</summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="target">The target.</param>
        internal UserAccount(string userName, string target) { UserName = userName; Target = target; }

        /// <summary>
        /// <para>This member can be one or more of the following values.</para>
        /// <para>
        /// Note that setting user account control flags may require certain privileges and control access rights. For more information, see
        /// the Remarks section of the NetUserSetInfo function.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>Value</term>
        /// <term>Meaning</term>
        /// </listheader>
        /// <item>
        /// <term>UF_SCRIPT</term>
        /// <term>The logon script executed. This value must be set.</term>
        /// </item>
        /// <item>
        /// <term>UF_ACCOUNTDISABLE</term>
        /// <term>The user's account is disabled.</term>
        /// </item>
        /// <item>
        /// <term>UF_HOMEDIR_REQUIRED</term>
        /// <term>The home directory is required. This value is ignored.</term>
        /// </item>
        /// <item>
        /// <term>UF_PASSWD_NOTREQD</term>
        /// <term>No password is required.</term>
        /// </item>
        /// <item>
        /// <term>UF_PASSWD_CANT_CHANGE</term>
        /// <term>The user cannot change the password.</term>
        /// </item>
        /// <item>
        /// <term>UF_LOCKOUT</term>
        /// <term>
        /// The account is currently locked out. You can call the NetUserSetInfo function to clear this value and unlock a previously locked
        /// account. You cannot use this value to lock a previously unlocked account.
        /// </term>
        /// </item>
        /// <item>
        /// <term>UF_DONT_EXPIRE_PASSWD</term>
        /// <term>The password should never expire on the account.</term>
        /// </item>
        /// <item>
        /// <term>UF_ENCRYPTED_TEXT_PASSWORD_ALLOWED</term>
        /// <term>The user's password is stored under reversible encryption in the Active Directory.</term>
        /// </item>
        /// <item>
        /// <term>UF_NOT_DELEGATED</term>
        /// <term>Marks the account as "sensitive"; other users cannot act as delegates of this user account.</term>
        /// </item>
        /// <item>
        /// <term>UF_SMARTCARD_REQUIRED</term>
        /// <term>Requires the user to log on to the user account with a smart card.</term>
        /// </item>
        /// <item>
        /// <term>UF_USE_DES_KEY_ONLY</term>
        /// <term>Restrict this principal to use only Data Encryption Standard (DES) encryption types for keys.</term>
        /// </item>
        /// <item>
        /// <term>UF_DONT_REQUIRE_PREAUTH</term>
        /// <term>This account does not require Kerberos preauthentication for logon.</term>
        /// </item>
        /// <item>
        /// <term>UF_TRUSTED_FOR_DELEGATION</term>
        /// <term>
        /// The account is enabled for delegation. This is a security-sensitive setting; accounts with this option enabled should be tightly
        /// controlled. This setting allows a service running under the account to assume a client's identity and authenticate as that user
        /// to other remote servers on the network.
        /// </term>
        /// </item>
        /// <item>
        /// <term>UF_PASSWORD_EXPIRED</term>
        /// <term>The user's password has expired. Windows 2000: This value is ignored.</term>
        /// </item>
        /// <item>
        /// <term>UF_TRUSTED_TO_AUTHENTICATE_FOR_DELEGATION</term>
        /// <term>
        /// The account is trusted to authenticate a user outside of the Kerberos security package and delegate that user through
        /// constrained delegation. This is a security-sensitive setting; accounts with this option enabled should be tightly controlled.
        /// This setting allows a service running under the account to assert a client's identity and authenticate as that user to
        /// specifically configured services on the network. Windows XP/2000: This value is ignored.
        /// </term>
        /// </item>
        /// </list>
        /// <para>
        /// The following values describe the account type. Only one value can be set. You cannot change the account type using the
        /// NetUserSetInfo function.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>Value</term>
        /// <term>Meaning</term>
        /// </listheader>
        /// <item>
        /// <term>UF_NORMAL_ACCOUNT</term>
        /// <term>This is a default account type that represents a typical user.</term>
        /// </item>
        /// <item>
        /// <term>UF_TEMP_DUPLICATE_ACCOUNT</term>
        /// <term>
        /// This is an account for users whose primary account is in another domain. This account provides user access to this domain, but
        /// not to any domain that trusts this domain. The User Manager refers to this account type as a local user account.
        /// </term>
        /// </item>
        /// <item>
        /// <term>UF_WORKSTATION_TRUST_ACCOUNT</term>
        /// <term>This is a computer account for a computer that is a member of this domain.</term>
        /// </item>
        /// <item>
        /// <term>UF_SERVER_TRUST_ACCOUNT</term>
        /// <term>This is a computer account for a backup domain controller that is a member of this domain.</term>
        /// </item>
        /// <item>
        /// <term>UF_INTERDOMAIN_TRUST_ACCOUNT</term>
        /// <term>This is a permit to trust account for a domain that trusts other domains.</term>
        /// </item>
        /// </list>
        /// </summary>
        /// <value>The account control flags.</value>
        public UserAcctCtrlFlags AccountControlFlags
        {
            get => NetUserGetInfo<USER_INFO_1>(Target, UserName).usri1_flags;
            set => NetUserSetInfo(Target, UserName, new USER_INFO_1008 { usri1008_flags = value });
        }

        /// <summary>The date and time when the account expires. A value of <see langword="null"/> indicates that the account never expires.</summary>
        /// <value>The account expiration.</value>
        public DateTime? AccountExpiration
        {
            get => DWORDtoDT(NetUserGetInfo<USER_INFO_2>(Target, UserName).usri2_acct_expires);
            set => NetUserSetInfo(Target, UserName, new USER_INFO_1017 { usri1017_acct_expires = DTtoDWORD(value) });
        }

        /// <summary>
        /// A string that is reserved for use by applications. This string can be a <see langword="null"/> string, or it can have any number
        /// of characters. Microsoft products use this member to store user configuration information. Do not modify this information.
        /// </summary>
        /// <value>The parms.</value>
        public string AppParams
        {
            get => NetUserGetInfo<USER_INFO_11>(Target, UserName).usri11_parms;
            set => NetUserSetInfo(Target, UserName, new USER_INFO_1013 { usri1013_parms = value });
        }

        /// <summary>
        /// <para>
        /// The number of times the user tried to log on to the account using an incorrect password. A value of – 1 indicates that the value
        /// is unknown. Calls to the NetUserAdd and NetUserSetInfo functions ignore this member.
        /// </para>
        /// <para>
        /// This member is replicated from the primary domain controller (PDC); it is also maintained on each backup domain controller (BDC)
        /// in the domain. To obtain an accurate value, you must query each BDC in the domain. The number of times the user tried to log on
        /// using an incorrect password is the largest value retrieved.
        /// </para>
        /// </summary>
        /// <value>The bad password count.</value>
        public uint BadPasswordCount => NetUserGetInfo<USER_INFO_11>(Target, UserName).usri11_bad_pw_count;

        /// <summary>The code page for the user's language of choice.</summary>
        /// <value>The code page.</value>
        public uint CodePage
        {
            get => NetUserGetInfo<USER_INFO_11>(Target, UserName).usri11_code_page;
            set => NetUserSetInfo(Target, UserName, new USER_INFO_1025 { usri1025_code_page = value });
        }

        /// <summary>
        /// A string that contains a comment to associate with the user account. The string can be a <see langword="null"/> string, or it
        /// can have any number of characters.
        /// </summary>
        /// <value>The comment.</value>
        public string Comment
        {
            get => NetUserGetInfo<USER_INFO_10>(Target, UserName).usri10_comment;
            set => NetUserSetInfo(Target, UserName, new USER_INFO_1007 { usri1007_comment = value });
        }

        /// <summary>The country/region code for the user's language of choice.</summary>
        /// <value>The country code.</value>
        public uint CountryCode
        {
            get => NetUserGetInfo<USER_INFO_11>(Target, UserName).usri11_country_code;
            set => NetUserSetInfo(Target, UserName, new USER_INFO_1024 { usri1024_country_code = value });
        }

        /// <summary>
        /// A string that contains the full name of the user. This string can be a <see langword="null"/> string, or it can have any number
        /// of characters.
        /// </summary>
        /// <value>The full name.</value>
        public string FullName
        {
            get => NetUserGetInfo<USER_INFO_10>(Target, UserName).usri10_full_name;
            set => NetUserSetInfo(Target, UserName, new USER_INFO_1011 { usri1011_full_name = value });
        }

        /// <summary>Retrieves a list of global groups to which a specified user belongs.</summary>
        /// <value>A sequence of global groups to which this user belongs.</value>
        /// <remarks>
        /// <para>
        /// If you call this function on a domain controller that is running Active Directory, access is allowed or denied based on the
        /// access control list (ACL) for the securable object. The default ACL permits all authenticated users and members of the
        /// "Pre-Windows 2000 compatible access" group to view the information. If you call this function on a member server or workstation,
        /// all authenticated users can view the information. For information about anonymous access and restricting anonymous access on
        /// these platforms, see Security Requirements for the Network Management Functions. For more information on ACLs, ACEs, and access
        /// tokens, see Access Control Model.
        /// </para>
        /// <para>The security descriptor of the User object is used to perform the access check for this function.</para>
        /// </remarks>
        public IEnumerable<string> GlobalGroups => NetUserGetGroups<GROUP_USERS_INFO_0>(Target, UserName).Select(i => i.grui0_name);

        /// <summary>A string that specifies the drive letter assigned to the user's home directory for logon purposes.</summary>
        /// <value>The home directory drive letter.</value>
        public string HomeDirectoryDriveLetter
        {
            get => NetUserGetInfo<USER_INFO_3>(Target, UserName).usri3_home_dir_drive;
            set => NetUserSetInfo(Target, UserName, new USER_INFO_1053 { usri1053_home_dir_drive = value });
        }

        /// <summary>
        /// A string specifying the path of the home directory of the user specified by the <c>UserName</c> member. The string can be <see langword="null"/>.
        /// </summary>
        /// <value>The home folder.</value>
        public string HomeFolder
        {
            get => NetUserGetInfo<USER_INFO_1>(Target, UserName).usri1_home_dir;
            set => NetUserSetInfo(Target, UserName, new USER_INFO_1006 { usri1006_home_dir = value });
        }

        /// <summary>
        /// <para>This member is currently not used.</para>
        /// <para>The date and time when the last logoff occurred.</para>
        /// <para>
        /// This member is maintained separately on each backup domain controller (BDC) in the domain. To obtain an accurate value, you must
        /// query each BDC in the domain. The last logoff occurred at the time indicated by the largest retrieved value.
        /// </para>
        /// </summary>
        /// <value>The last logoff.</value>
        public DateTime? LastLogoff => DWORDtoDT(NetUserGetInfo<USER_INFO_11>(Target, UserName).usri11_last_logoff);

        /// <summary>
        /// <para>The date and time when the last logon occurred.</para>
        /// <para>
        /// This member is maintained separately on each backup domain controller (BDC) in the domain. To obtain an accurate value, you must
        /// query each BDC in the domain. The last logon occurred at the time indicated by the largest retrieved value.
        /// </para>
        /// </summary>
        /// <value>The last logon.</value>
        public DateTime LastLogon => DWORDtoDT(NetUserGetInfo<USER_INFO_11>(Target, UserName).usri11_last_logon).GetValueOrDefault();

        /// <summary>
        /// Retrieves a list of local groups to which a specified user belongs, including local groups in which the user is indirectly a
        /// member (that is, the user has membership in a global group that is itself a member of one or more local groups).
        /// </summary>
        /// <value>A sequence of local groups to which this user belongs.</value>
        /// <remarks>
        /// <para>
        /// If you call this function on a domain controller that is running Active Directory, access is allowed or denied based on the
        /// access control list (ACL) for the securable object. The default ACL permits all authenticated users and members of the
        /// "Pre-Windows 2000 compatible access" group to view the information. If you call this function on a member server or workstation,
        /// all authenticated users can view the information. For information about anonymous access and restricting anonymous access on
        /// these platforms, see Security Requirements for the Network Management Functions. For more information on ACLs, ACEs, and access
        /// tokens, see Access Control Model.
        /// </para>
        /// <para>
        /// The security descriptor of the Domain object is used to perform the access check for this function. The caller must have Read
        /// Property permission on the Domain object.
        /// </para>
        /// </remarks>
        public IEnumerable<string> LocalGroups => NetUserGetLocalGroups<LOCALGROUP_USERS_INFO_0>(Target, UserName, GetLocalGroupFlags.LG_INCLUDE_INDIRECT).Select(i => i.lgrui0_name);

        /// <summary>
        /// <para>
        /// A pointer to a 168-bit array that specifies the times during which the user can log on. Each bit represents a unique hour in the
        /// week, in Greenwich Mean Time (GMT).
        /// </para>
        /// <para>
        /// The first bit (bit 0, word 0) is Sunday, 0:00 to 0:59; the second bit (bit 1, word 0) is Sunday, 1:00 to 1:59; and so on. Note
        /// that bit 0 in word 0 represents Sunday from 0:00 to 0:59 only if you are in the GMT time zone. In all other cases you must
        /// adjust the bits according to your time zone offset (for example, GMT minus 8 hours for Pacific Standard Time).
        /// </para>
        /// <para>
        /// Specify <see langword="null"/> in this member when calling the NetUserAdd function to indicate no time restriction. Specify a
        /// <see langword="null"/> pointer when calling the NetUserSetInfo function to indicate that no change is to be made to the times
        /// during which the user can log on.
        /// </para>
        /// </summary>
        /// <value>The logon hours.</value>
        /// <exception cref="System.ArgumentOutOfRangeException">LogonHours</exception>
        public BitArray LogonHours
        {
            get
            {
                IntPtr ptr = NetUserGetInfo<USER_INFO_11>(Target, UserName).usri11_logon_hours;
                return new BitArray(ptr.ToByteArray(21));
            }
            set
            {
                if (value is null)
                {
                    NetUserSetInfo(Target, UserName, new USER_INFO_1020 { usri1020_units_per_week = UnitsPerWeek });
                    return;
                }
                if (value.Count != 168)
                {
                    throw new ArgumentOutOfRangeException(nameof(LogonHours));
                }

                byte[] bytes = new byte[21];
                value.CopyTo(bytes, 0);
                using SafeByteArray mem = new(bytes);
                NetUserSetInfo(Target, UserName, new USER_INFO_1020 { usri1020_units_per_week = UnitsPerWeek, usri1020_logon_hours = mem.DangerousGetHandle() });
            }
        }

        /// <summary>
        /// <para>
        /// A string that contains the name of the server to which logon requests are sent. Server names should be preceded by two
        /// backslashes (\). To indicate that the logon request can be handled by any logon server, specify an asterisk (\*) for the server
        /// name. A <see langword="null"/> string indicates that requests should be sent to the domain controller.
        /// </para>
        /// <para>For Windows servers, the NetUserGetInfo function returns \*.</para>
        /// </summary>
        /// <value>The logon server.</value>
        public string LogonServer
        {
            get => NetUserGetInfo<USER_INFO_11>(Target, UserName).usri11_logon_server;
            set => NetUserSetInfo(Target, UserName, new USER_INFO_1023 { usri1023_logon_server = value });
        }

        /// <summary>
        /// The maximum amount of disk space the user can use. Specify <see cref="uint.MaxValue"/> to use all available disk space.
        /// </summary>
        /// <value>The maximum storage.</value>
        public uint MaxStorage
        {
            get => NetUserGetInfo<USER_INFO_11>(Target, UserName).usri11_max_storage;
            set => NetUserSetInfo(Target, UserName, new USER_INFO_1018 { usri1018_max_storage = value });
        }

        /// <summary>
        /// <para>The user's operator privileges.</para>
        /// <para>
        /// For the NetUserGetInfo function, the appropriate value is returned based on the local group membership. If the user is a member
        /// of Print Operators, AF_OP_PRINT is set. If the user is a member of Server Operators, AF_OP_SERVER is set. If the user is a
        /// member of the Account Operators, AF_OP_ACCOUNTS is set. AF_OP_COMM is never set.
        /// </para>
        /// <para>This member can be one or more of the following values.</para>
        /// <list type="table">
        /// <listheader>
        /// <term>Value</term>
        /// <term>Meaning</term>
        /// </listheader>
        /// <item>
        /// <term>AF_OP_PRINT</term>
        /// <term>The print operator privilege is enabled.</term>
        /// </item>
        /// <item>
        /// <term>AF_OP_COMM</term>
        /// <term>The communications operator privilege is enabled.</term>
        /// </item>
        /// <item>
        /// <term>AF_OP_SERVER</term>
        /// <term>The server operator privilege is enabled.</term>
        /// </item>
        /// <item>
        /// <term>AF_OP_ACCOUNTS</term>
        /// <term>The accounts operator privilege is enabled.</term>
        /// </item>
        /// </list>
        /// </summary>
        /// <value>The operator privileges.</value>
        public UserOpPriv OperatorPrivileges
        {
            get => NetUserGetInfo<USER_INFO_11>(Target, UserName).usri11_auth_flags;
            set => NetUserSetInfo(Target, UserName, new USER_INFO_1010 { usri1010_auth_flags = value });
        }

        /// <summary>
        /// A string that specifies the password for the user identified by the <c>UserName</c> member. The length cannot exceed PWLEN bytes.
        /// </summary>
        /// <value>The password.</value>
        public string Password
        {
            set => NetUserSetInfo(Target, UserName, new USER_INFO_1003 { usri1003_password = value });
        }

        /// <summary>The time elapsed since the <c>Password</c> member was last changed.</summary>
        /// <value>The password age.</value>
        public TimeSpan PasswordAge => TimeSpan.FromSeconds(NetUserGetInfo<USER_INFO_1>(Target, UserName).usri1_password_age);

        /// <summary>
        /// <para>The password expiration information.</para>
        /// <para>The NetUserGetInfo function return zero if the password has not expired (and nonzero if it has).</para>
        /// <para>
        /// When you call NetUserAdd or NetUserSetInfo, specify a nonzero value in this member to inform users that they must change their
        /// password at the next logon. To turn off this message, call <c>NetUserSetInfo</c> and specify zero in this member. Note that you
        /// cannot specify zero to negate the expiration of a password that has already expired.
        /// </para>
        /// </summary>
        /// <value><see langword="true"/> if [password expired]; otherwise, <see langword="false"/>.</value>
        public bool PasswordExpired => NetUserGetInfo<USER_INFO_3>(Target, UserName).usri3_password_expired != 0;

        /// <summary>
        /// The relative identifier (RID) of the Primary Global Group for the user. When you call the <c>NetUserAdd</c> function, this
        /// member must be DOMAIN_GROUP_RID_USERS (defined in WinNT.h). When you call <c>NetUserSetInfo</c>, this member must be the RID of
        /// a global group in which the user is enrolled. For more information, see Well-Known SIDs and SID Components.
        /// </summary>
        /// <value>The primary group identifier.</value>
        public uint PrimaryGroupId
        {
            get => NetUserGetInfo<USER_INFO_3>(Target, UserName).usri3_primary_group_id;
            set => NetUserSetInfo(Target, UserName, new USER_INFO_1051 { usri1051_primary_group_id = value });
        }

        /// <summary>
        /// <para>
        /// The level of privilege assigned to the <c>UserName</c> member. For more information about user and group account rights, see Privileges.
        /// </para>
        /// <list type="table">
        /// <listheader>
        /// <term>Value</term>
        /// <term>Meaning</term>
        /// </listheader>
        /// <item>
        /// <term>USER_PRIV_GUEST</term>
        /// <term>Guest</term>
        /// </item>
        /// <item>
        /// <term>USER_PRIV_USER</term>
        /// <term>User</term>
        /// </item>
        /// <item>
        /// <term>USER_PRIV_ADMIN</term>
        /// <term>Administrator</term>
        /// </item>
        /// </list>
        /// </summary>
        /// <value>The privilege.</value>
        public UserPrivilege Privilege => NetUserGetInfo<USER_INFO_1>(Target, UserName).usri1_priv;

        /// <summary>
        /// A string that specifies a path to the user's profile. This value can be a <see langword="null"/> string, a local absolute path,
        /// or a UNC path.
        /// </summary>
        /// <value>The profile path.</value>
        public string ProfilePath
        {
            get => NetUserGetInfo<USER_INFO_3>(Target, UserName).usri3_profile;
            set => NetUserSetInfo(Target, UserName, new USER_INFO_1052 { usri1052_profile = value });
        }

        /// <summary>
        /// A string specifying the path for the user's logon script file. The script file can be a .CMD file, an .EXE file, or a .BAT file.
        /// The string can also be <see langword="null"/>.
        /// </summary>
        /// <value>The script path.</value>
        public string ScriptPath
        {
            get => NetUserGetInfo<USER_INFO_1>(Target, UserName).usri1_script_path;
            set => NetUserSetInfo(Target, UserName, new USER_INFO_1009 { usri1009_script_path = value });
        }

        /// <summary>
        /// <para>The number of times the user logged on successfully to this account. A value of – 1 indicates that the value is unknown.</para>
        /// <para>
        /// This member is maintained separately on each backup domain controller (BDC) in the domain. To obtain an accurate value, you must
        /// query each BDC in the domain. The number of times the user logged on successfully is the sum of the retrieved values.
        /// </para>
        /// </summary>
        /// <value>The successful logons.</value>
        public uint SuccessfulLogons => NetUserGetInfo<USER_INFO_11>(Target, UserName).usri11_num_logons;

        /// <summary>
        /// Gets a string that specifies the DNS or NetBIOS name of the remote server on which the user account resides. If this value is
        /// <see langword="null"/>, the local computer is assumed.
        /// </summary>
        /// <value>The target.</value>
        public string Target { get; }

        /// <summary>
        /// <para>
        /// The number of equal-length time units into which the week is divided. This value is required to compute the length of the bit
        /// string in the <c>logon_hours</c> member.
        /// </para>
        /// <para>This value must be UNITS_PER_WEEK for LAN Manager 2.0. This element is ignored by the NetUserAdd and NetUserSetInfo functions.</para>
        /// <para>For service applications, the units must be one of the following values: SAM_DAYS_PER_WEEK, SAM_HOURS_PER_WEEK, or SAM_MINUTES_PER_WEEK.</para>
        /// </summary>
        /// <value>The units per week.</value>
        public uint UnitsPerWeek
        {
            get => NetUserGetInfo<USER_INFO_11>(Target, UserName).usri11_units_per_week;
            set => NetUserSetInfo(Target, UserName, new USER_INFO_1020 { usri1020_units_per_week = value, usri1020_logon_hours = IntPtr.Zero });
        }

        /// <summary>
        /// A string that contains a user comment. This string can be a <see langword="null"/> string, or it can have any number of characters.
        /// </summary>
        /// <value>The user comment.</value>
        public string UserComment
        {
            get => NetUserGetInfo<USER_INFO_10>(Target, UserName).usri10_usr_comment;
            set => NetUserSetInfo(Target, UserName, new USER_INFO_1012 { usri1012_usr_comment = value });
        }

        /// <summary>A string that specifies the name of the user account.</summary>
        /// <value>The name of the user.</value>
        public string UserName { get; }

        /// <summary>A pointer to a SID structure that contains the security identifier (SID) that uniquely identifies the user.</summary>
        /// <value>The user sid.</value>
        public PSID UserSid => NetUserGetInfo<USER_INFO_23>(Target, UserName).usri23_user_sid;

        /// <summary>
        /// An array of strings that contains the names of workstations from which the user can log on. As many as eight workstations can be
        /// specified. If you do not want to restrict the number of workstations, use a <see langword="null"/> value. To disable logons from
        /// all workstations to this account, set the UF_ACCOUNTDISABLE value in the <c>AccountControlFlags</c> member.
        /// </summary>
        /// <value>The workstations.</value>
        public string[] Workstations
        {
            get => NetUserGetInfo<USER_INFO_11>(Target, UserName).usri11_workstations?.Split(',');
            set => NetUserSetInfo(Target, UserName, new USER_INFO_1014 { usri1014_workstations = value is null || value.Length == 0 ? null : string.Join(",", value) });
        }

        /// <inheritdoc/>
        string INamedEntity.Name => UserName;

        /// <summary>Changes the password for a specified network server or domain.</summary>
        /// <param name="oldPassword">A string that specifies the user's old password.</param>
        /// <param name="newPassword">A string that specifies the user's new password.</param>
        /// <param name="domainName">
        /// A string that specifies the DNS or NetBIOS name of a remote server or domain on which the function is to execute. If this
        /// parameter is <c>NULL</c>, the logon domain of the caller is used.
        /// </param>
        /// <remarks>
        /// <para>
        /// If an application calls the <c>NetUserChangePassword</c> function on a domain controller that is running Active Directory,
        /// access is allowed or denied based on the access control list (ACL) for the securable object. The default ACL permits only Domain
        /// Admins and Account Operators to call this function. On a member server or workstation, only Administrators and Power Users can
        /// call this function. A user can change his or her own password. For more information, see Security Requirements for the Network
        /// Management Functions. For more information on ACLs, ACEs, and access tokens, see Access Control Model.
        /// </para>
        /// <para>
        /// The security descriptor of the User object is used to perform the access check for this function. In addition, the caller must
        /// have the "Change password" control access right on the User object. This right is granted to Anonymous Logon and Everyone by default.
        /// </para>
        /// <para>Note that for the function to succeed, the oldpassword parameter must match the password as it currently exists.</para>
        /// <para>
        /// In some cases, the process that calls the <c>NetUserChangePassword</c> function must also have the SE_CHANGE_NOTIFY_NAME
        /// privilege enabled; otherwise, <c>NetUserChangePassword</c> fails and GetLastError returns ERROR_ACCESS_DENIED. This privilege is
        /// not required for the LocalSystem account or for accounts that are members of the administrators group. By default,
        /// SE_CHANGE_NOTIFY_NAME is enabled for all users, but some administrators may disable the privilege for everyone. For more
        /// information about account privileges, see Privileges and Authorization Constants.
        /// </para>
        /// <para>
        /// See Forcing a User to Change the Logon Password for a code sample that demonstrates how to force a user to change the logon
        /// password on the next logon using the NetUserGetInfo and NetUserSetInfo functions.
        /// </para>
        /// <para>
        /// The <c>NetUserChangePassword</c> function does not control how the oldpassword and newpassword parameters are secured when sent
        /// over the network to a remote server. Any encryption of these parameters is handled by the Remote Procedure Call (RPC) mechanism
        /// supported by the network redirector that provides the network transport. Encryption is also controlled by the security
        /// mechanisms supported by the local computer and the security mechanisms supported by remote network server or domain specified in
        /// the domainname parameter. For more details on security when the Microsoft network redirector is used and the remote network
        /// server is running Microsoft Windows, see the protocol documentation for MS-RPCE, MS-SAMR, MS-SPNG, and MS-NLMP.
        /// </para>
        /// </remarks>
        public void ChangePassword(string oldPassword, string newPassword, string domainName = null) => NetUserChangePassword(domainName, UserName, oldPassword, newPassword).ThrowIfFailed();

        /// <summary>Equalses the specified other.</summary>
        /// <param name="other">The other.</param>
        /// <returns></returns>
        public bool Equals(UserAccount other) => other?.UserName == UserName && other.Target == Target;

        internal static uint DTtoDWORD(DateTime? dt) => dt.HasValue ? (uint)(dt.Value.ToUniversalTime() - baseDate).TotalSeconds : uint.MaxValue;

        internal static DateTime? DWORDtoDT(uint baseSec) => baseSec == 0 || baseSec == uint.MaxValue ? null : (baseDate + TimeSpan.FromSeconds(baseSec)).ToLocalTime();
    }

    /// <summary>Represents the collection of user accounts on a server.</summary>
    public class UserAccounts : ICollection<UserAccount>
    {
        /// <summary>Initializes a new instance of the <see cref="UserAccounts"/> class.</summary>
        /// <param name="target">
        /// The DNS or NetBIOS name of the remote server on which the user account resides. If this value is <see langword="null"/>, the
        /// local computer is assumed.
        /// </param>
        public UserAccounts(string target = null) => Target = target;

        /// <summary>
        /// Gets the DNS or NetBIOS name of the remote server on which the user account resides. If this value is <see langword="null"/>,
        /// the local computer is assumed.
        /// </summary>
        /// <value>The target.</value>
        public string Target { get; }

        /// <summary>Gets the number of elements contained in the collection.</summary>
        /// <value>The number of elements contained in the collection.</value>
        public int Count => Enumerate().Count();

        /// <summary>Gets a value indicating whether the collection is read only.</summary>
        /// <value><see langword="true"/> if the collection is read only; otherwise, <see langword="false"/>.</value>
        bool ICollection<UserAccount>.IsReadOnly => false;

        /// <summary>Adds a user account and assigns a password and other key properties.</summary>
        /// <param name="userName">The name of the user account.</param>
        /// <param name="password">The password of the user. The length cannot exceed PWLEN bytes.</param>
        /// <param name="homeFolder">The optional path of the home directory for the user.</param>
        /// <param name="comment">An optional comment to associate with the user account.</param>
        /// <param name="scriptPath">The script path.</param>
        /// <param name="flags">Flags that describe the account type and options.</param>
        /// <returns>On success, returns an instance of <see cref="UserAccount"/> for the specified user.</returns>
        /// <remarks>
        /// <para>
        /// If you call this function on a domain controller that is running Active Directory, access is allowed or denied based on the
        /// access control list (ACL) for the securable object. The default ACL permits only Domain Admins and Account Operators to call
        /// this function. On a member server or workstation, only Administrators and Power Users can call this function. For more
        /// information, see Security Requirements for the Network Management Functions. For more information on ACLs, ACEs, and access
        /// tokens, see Access Control Model.
        /// </para>
        /// <para>
        /// The security descriptor of the user container is used to perform the access check for this function. The caller must be able to
        /// create child objects of the user class.
        /// </para>
        /// <para>
        /// Server users must use a system in which the server creates a system account for the new user. The creation of this account is
        /// controlled by several parameters in the server's LanMan.ini file.
        /// </para>
        /// <para>If the newly added user already exists as a system user, the <paramref name="homeFolder"/> parameter is ignored.</para>
        /// <para>
        /// When you call the <c>AddNew</c> function, the call initializes the additional members in the <see cref="UserAccount"/> object to
        /// their default values. You can change the default values by setting properties on the object.
        /// </para>
        /// <para>
        /// User account names are limited to 20 characters and group names are limited to 256 characters. In addition, account names cannot
        /// be terminated by a period and they cannot include commas or any of the following printable characters: ", /, , [, ], :, |, &lt;,
        /// &gt;, +, =, ;, ?, *. Names also cannot include characters in the range 1-31, which are non-printable.
        /// </para>
        /// </remarks>
        public UserAccount Add(string userName, string password, string homeFolder = null, string comment = null,
            string scriptPath = null, UserAcctCtrlFlags flags = 0)
        {
            flags |= UserAcctCtrlFlags.UF_SCRIPT;
            NetUserAdd(Target, new USER_INFO_1
            {
                usri1_name = userName,
                usri1_password = password,
                usri1_home_dir = homeFolder,
                usri1_comment = comment,
                usri1_script_path = scriptPath,
                usri1_flags = flags,
                usri1_priv = UserPrivilege.USER_PRIV_USER
            }, 1);
            return new UserAccount(userName, Target);
        }

        /// <summary>Removes all items from the collection.</summary>
        public void Clear()
        {
            foreach (UserAccount a in Enumerate().ToArray())
            {
                Remove(a);
            }
        }

        /// <summary>Determines whether the collection contains the specified user account.</summary>
        /// <param name="item">The user account to find.</param>
        /// <returns><see langword="true"/> if the collection contains the specified user account, otherwise, <see langword="false"/>.</returns>
        public bool Contains(UserAccount item) => Enumerate().Contains(item);

        /// <summary>Copies the elements of the collection to an Array, starting at a particular Array index.</summary>
        /// <param name="array">
        /// The one-dimensional Array that is the destination of the elements copied from the collection. The Array must have zero-based indexing.
        /// </param>
        /// <param name="arrayIndex">The zero-based index in <paramref name="array"/> at which copying begins.</param>
        public void CopyTo(UserAccount[] array, int arrayIndex)
        {
            UserAccount[] a = Enumerate().ToArray();
            Array.Copy(a, 0, array, arrayIndex, a.Length);
        }

        /// <summary>Returns an enumerator that iterates through the collection.</summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        public IEnumerator<UserAccount> GetEnumerator() => Enumerate().GetEnumerator();

        /// <summary>Deletes this account from the server.</summary>
        /// <remarks>
        /// <para>
        /// If you call this function on a domain controller that is running Active Directory, access is allowed or denied based on the
        /// access control list (ACL) for the securable object. The default ACL permits only Domain Admins and Account Operators to call
        /// this function. On a member server or workstation, only Administrators and Power Users can call this function. For more
        /// information, see Security Requirements for the Network Management Functions. For more information on ACLs, ACEs, and access
        /// tokens, see Access Control Model.
        /// </para>
        /// <para>The security descriptor of the User object is used to perform the access check for this function.</para>
        /// <para>
        /// An account cannot be deleted while a user or application is accessing a server resource. If the user was added to the system
        /// with a call to the NetUserAdd function, deleting the user also deletes the user's system account.
        /// </para>
        /// </remarks>
        public bool Remove(UserAccount user) => NetUserDel(user.Target, user.UserName).Succeeded;

        /// <inheritdoc/>
        void ICollection<UserAccount>.Add(UserAccount item) => throw new NotImplementedException();

        /// <summary>Returns an enumerator that iterates through the collection.</summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        private IEnumerable<UserAccount> Enumerate() => NetUserEnum<USER_INFO_0>(Target, 0).Select(u => new UserAccount(u.usri0_name, Target));
    }
}