using System;
using System.ComponentModel;
using System.Drawing;
using System.Security;
using System.Text;
using System.Windows.Forms;
using Vanara.Extensions;
using Vanara.PInvoke;
using Vanara.Security;
using static Vanara.PInvoke.AdvApi32;
using static Vanara.PInvoke.CredUI;
using static Vanara.PInvoke.Gdi32;

namespace Vanara.Windows.Forms;

/// <summary>Dialog box which prompts for user credentials using the Win32 CREDUI methods.</summary>
[ToolboxItem(true), ToolboxBitmap(typeof(CredentialsDialog), "Dialog"), ToolboxItemFilter("System.Windows.Forms.Control.TopLevel"),
DesignTimeVisible(true), Description("Dialog that prompts the user for credentials."),
Designer("System.ComponentModel.Design.ComponentDesigner, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
public class CredentialsDialog : CommonDialog
{
	private static readonly bool PreVista = Environment.OSVersion.Version.Major <= 5;
	private uint authPackage;
	private bool saveChecked;

	/// <summary>Initializes a new instance of the <see cref="CredentialsDialog"/> class.</summary>
	public CredentialsDialog() => Reset();

	/// <summary>Initializes a new instance of the <see cref="CredentialsDialog"/> class.</summary>
	/// <param name="caption">The caption.</param>
	/// <param name="message">The message.</param>
	/// <param name="userName">Name of the user.</param>
	public CredentialsDialog(string caption, string message = null, string userName = null) : this()
	{
		Caption = caption;
		Message = message;
		UserName = userName;
	}

	/// <summary>Occurs after the OK button has been clicked for validation of the supplied credentials.</summary>
	/// <remarks>
	/// If handled, the <see cref="PasswordValidatorEventArgs.Validated"/> property must be set to <c>true</c> if the password is valid or <c>false</c> if
	/// not. If <c>false</c>, the <see cref="CommonDialog.ShowDialog()"/> method will return <see cref="DialogResult.Cancel"/>.
	/// </remarks>
	[Description("Validates the supplied credentials."), Category("Data")]
	public event EventHandler<PasswordValidatorEventArgs> ValidatePassword;

	/// <summary>Gets or sets the Windows Error Code that caused this credential dialog to appear, if applicable.</summary>
	[DefaultValue(0), Category("Data"), Description("Windows Error Code that caused this credential dialog")]
	public int AuthenticationError { get; set; }

	/// <summary>
	/// <c>Windows Vista and later:</c> On input, the value of this parameter is used to specify the authentication package for which the credentials are serialized.
	/// <para>
	/// To get the appropriate value to use for this parameter on input, call the LsaLookupAuthenticationPackage function and use the value of the
	/// AuthenticationPackage parameter of that function.
	/// </para>
	/// <para>On output, this parameter specifies the authentication package for which the credentials in the ppvOutAuthBuffer buffer are serialized.</para>
	/// </summary>
	/// <value>The authentication package.</value>
	[Browsable(false), DefaultValue(0u)]
	public uint AuthenticationPackage { get => authPackage; set => authPackage = value; }

	/// <summary><c>Windows XP and earlier:</c> Gets or sets the image to display as the banner for the dialog.</summary>
	[DefaultValue(null), Category("Appearance"), Description("Image to display in dialog banner")]
	public Bitmap Banner { get; set; }

	/// <summary>
	/// Gets or sets the caption for the dialog. If this value is <c>null</c> or an empty string, the name of the application will be shown as the caption.
	/// </summary>
	[DefaultValue(null), Category("Appearance"), Description("Caption to display for dialog")]
	public string Caption { get; set; }

	/// <summary>Gets or sets a value indicating whether to encrypt password.</summary>
	/// <value><c>true</c> if password is to be encrypted; otherwise, <c>false</c>.</value>
	[DefaultValue(false), Category("Behavior"), Description("Indicates whether to encrypt password")]
	public bool EncryptPassword { get; set; }

	/// <summary>Gets or sets a value indicating whether to cause the pre-Windows Vista style dialog to be used regardless of the current Windows version.</summary>
	/// <value><c>true</c> if older UI will always be used; <c>false</c> to display the UI commensurate for the current Windows version.</value>
	[DefaultValue(false), Category("Appearance"), Description("Indicates whether to force the older UI.")]
	public bool ForcePreVistaUI { get; set; }

	/// <summary>Gets or sets the message to display on the dialog</summary>
	[DefaultValue(null), Category("Appearance"), Description("Message to display in the dialog")]
	public string Message { get; set; }

	/// <summary>Gets the password entered by the user</summary>
	[DefaultValue(null), Browsable(false)]
	public string Password { get; private set; }

	/// <summary>Gets or sets a boolean indicating if the save check box was checked</summary>
	[DefaultValue(false), Category("Behavior"), Description("Indicates if the save check box is checked.")]
	public bool SaveChecked { get => saveChecked; set => saveChecked = value; }

	/// <summary>Gets the password entered by the user using an encrypted string</summary>
	[DefaultValue(null), Browsable(false)]
	public SecureString SecurePassword { get; private set; }

	/// <summary>Gets or sets a value that determines if the combo box is populated with local administrators only.</summary>
	public bool ShowAdminsOnly { get; set; }

	/// <summary>Gets or sets a boolean indicating if the save check box should be shown.</summary>
	[DefaultValue(false), Category("Behavior"), Description("Indicates if the save check box is shown.")]
	public bool ShowSaveCheckBox { get; set; }

	/// <summary>Gets or sets the name of the target for these credentials</summary>
	/// <remarks>This value is used as a key to store the credentials if persisted</remarks>
	[DefaultValue(null), Category("Data"), Description("Target for the credentials")]
	public string Target { get; set; }

	/// <summary>Gets or sets the username entered</summary>
	/// <remarks>If non-empty before calling <see cref="RunDialog"/>, this value will be displayed in the dialog</remarks>
	[DefaultValue(null), Category("Data"), Description("User name displayed in the dialog")]
	public string UserName { get; set; }

	/// <summary>Gets a default value for the target.</summary>
	/// <value>The default target.</value>
	private static string DefaultTarget => Environment.UserDomainName;

	/// <summary>Validates a password using the LogonUser API function.</summary>
	/// <param name="userName">Name of the user.</param>
	/// <param name="password">The password.</param>
	/// <returns><c>true</c> if the credentials are validated, otherwise <c>false</c>.</returns>
	public static bool IsValidPassword(string userName, string password)
	{
		ParseUserName(userName, out var user, out var domain);
		try
		{
			if (LogonUser(user, domain, password, LogonUserType.LOGON32_LOGON_NETWORK, LogonUserProvider.LOGON32_PROVIDER_DEFAULT, out var obj))
				return true;
		}
		catch { }
		return false;
	}

	/// <summary>Wraps the CredUIParseUserName function which extracts the domain and user account name from a fully qualified user name.</summary>
	/// <param name="userName">Contains the user name to be parsed. The name must be in UPN or down-level format, or a certificate.</param>
	/// <param name="user">Receives the user account name.</param>
	/// <param name="domain">Receives the domain name. If <paramref name="userName"/> specifies a certificate, domain will be NULL.</param>
	public static void ParseUserName(string userName, out string user, out string domain)
	{
		if (userName == null)
			throw new ArgumentNullException(nameof(userName));
		var sbUser = new StringBuilder(CREDUI_MAX_USERNAME_LENGTH);
		var sbDomain = new StringBuilder(CREDUI_MAX_DOMAIN_TARGET_LENGTH);
		var ret = CredUIParseUserName(userName, sbUser, CREDUI_MAX_USERNAME_LENGTH, sbDomain, CREDUI_MAX_DOMAIN_TARGET_LENGTH);
		ret.ThrowIfFailed();
		user = sbUser.ToString();
		domain = sbDomain.Length != 0 ? sbDomain.ToString() : null;
	}

	/// <summary>Implements a standard password validator using the LogonUser API function.</summary>
	/// <param name="sender">The sender.</param>
	/// <param name="args">The <see cref="PasswordValidatorEventArgs"/> instance containing the event data.</param>
	public static void StandardPasswordValidator(object sender, PasswordValidatorEventArgs args)
	{
		if (args.SecurePassword != null) throw new ArgumentException();
		args.Validated = IsValidPassword(args.Username, args.Password);
	}

	/// <summary>Confirms the credentials.</summary>
	/// <param name="updateCredentials">If set to <c>true</c> the credentials are stored in the credential manager.</param>
	/// <returns><c>true</c> if the credentials were confirmed; otherwise <c>false</c>.</returns>
	public bool ConfirmCredentials(bool updateCredentials) => CredUIConfirmCredentials(Target, updateCredentials).Succeeded;

	/// <summary>When overridden in a derived class, resets the properties of a common dialog box to their default values.</summary>
	public override void Reset()
	{
		Target = UserName = Caption = Message = Password = null;
		Banner = null;
		EncryptPassword = ForcePreVistaUI = SaveChecked = ShowSaveCheckBox = false;
	}

	/// <summary>Gets the flags to use in <see cref="CredUIPromptForWindowsCredentials"/>.</summary>
	/// <returns>The flags based on current properties.</returns>
	protected virtual WindowsCredentialsDialogOptions GetDialogFlags()
	{
		return WindowsCredentialsDialogOptions.CREDUIWIN_GENERIC |
			(ShowAdminsOnly ? WindowsCredentialsDialogOptions.CREDUIWIN_ENUMERATE_ADMINS : 0) |
			(ShowSaveCheckBox ? WindowsCredentialsDialogOptions.CREDUIWIN_CHECKBOX : 0);
	}

	/// <summary>Gets the flags to use in <see cref="CredUIPromptForCredentials"/>.</summary>
	/// <returns>The flags based on current properties.</returns>
	protected virtual CredentialsDialogOptions GetPreVistaDialogFlags()
	{
		return CredentialsDialogOptions.CREDUI_FLAGS_DEFAULT |
			(ShowAdminsOnly ? CredentialsDialogOptions.CREDUI_FLAGS_REQUEST_ADMINISTRATOR : 0) |
			(ShowSaveCheckBox ? CredentialsDialogOptions.CREDUI_FLAGS_SHOW_SAVE_CHECK_BOX : 0);
	}

	/// <summary>When overridden in a derived class, specifies a common dialog box.</summary>
	/// <param name="parentWindowHandle">A value that represents the window handle of the owner window for the common dialog box.</param>
	/// <returns>true if the dialog box was successfully run; otherwise, false.</returns>
	protected override bool RunDialog(IntPtr parentWindowHandle)
	{
		var info = new CREDUI_INFO(parentWindowHandle, Caption, Message) { hbmBanner = Banner?.GetHbitmap() ?? IntPtr.Zero };
		try
		{
			if (PreVista || ForcePreVistaUI)
			{
				var userName = new StringBuilder(UserName, CREDUI_MAX_USERNAME_LENGTH);
				var password = new StringBuilder(CREDUI_MAX_PASSWORD_LENGTH);

				if (string.IsNullOrEmpty(Target)) Target = DefaultTarget;
				var ret = CredUIPromptForCredentials(info, Target, IntPtr.Zero, unchecked((uint)AuthenticationError), userName, CREDUI_MAX_USERNAME_LENGTH,
					password, CREDUI_MAX_PASSWORD_LENGTH, ref saveChecked, GetPreVistaDialogFlags());
				if (ret == Win32Error.ERROR_CANCELLED)
					return false;
				if (ret != Win32Error.ERROR_SUCCESS)
					throw new InvalidOperationException($"Unknown error in {nameof(CredentialsDialog)}. Error: 0x{(uint)ret:X}");

				if (EncryptPassword)
				{
					// Convert the password to a SecureString
					var newPassword = StringBuilderToSecureString(password);

					// Clear the old password and set the new one (read-only)
					SecurePassword?.Dispose();
					newPassword.MakeReadOnly();
					SecurePassword = newPassword;
					Password = null;
				}
				else
					Password = password.ToString();

				if (ValidatePassword != null)
				{
					var pve = new PasswordValidatorEventArgs(userName.ToString(), Password, SecurePassword);
					ValidatePassword.Invoke(this, pve);
					if (!pve.Validated)
						return false;
				}
				/*if (save)
				{
					CredUIReturnCodes cret = CredUIConfirmCredentials(this.Target, false);
					if (cret != CredUIReturnCodes.NO_ERROR && cret != CredUIReturnCodes.ERROR_INVALID_PARAMETER)
					{
						this.Options |= CredentialsDialogOptions.IncorrectPassword;
						return false;
					}
				}*/

				// Update other properties
				UserName = userName.ToString();
				return true;
			}
			else
			{
				using (var buf = EncryptPassword && SecurePassword != null ? new AuthenticationBuffer(UserName.ToSecureString(), SecurePassword)
					: new AuthenticationBuffer(UserName, Password))
				{
					var retVal = CredUIPromptForWindowsCredentials(info, 0, ref authPackage, buf, (uint)buf.Size, out var outAuthBuffer, out var outAuthBufferSize, ref saveChecked, GetDialogFlags());
					if (retVal == Win32Error.ERROR_CANCELLED)
						return false;
					retVal.ThrowIfFailed();

					using var outAuth = new AuthenticationBuffer(outAuthBuffer, (int)outAuthBufferSize);
					if (EncryptPassword)
					{
						outAuth.UnPack(true, out SecureString u, out var d, out var p);
						Password = null;
						SecurePassword = p;
						UserName = d?.Length > 0 ? $"{d.ToInsecureString()}\\{u.ToInsecureString()}" : u.ToInsecureString();
					}
					else
					{
						outAuth.UnPack(true, out string u, out var d, out var p);
						Password = p;
						SecurePassword = null;
						UserName = string.IsNullOrEmpty(d) ? u : $"{d}\\{u}";
					}
				}
				if (ValidatePassword != null)
				{
					var pve = new PasswordValidatorEventArgs(UserName, Password, SecurePassword);
					ValidatePassword.Invoke(this, pve);
					if (!pve.Validated)
						return false;
				}

				return true;
			}
		}
		finally
		{
			if (!info.hbmBanner.IsNull)
				DeleteObject(info.hbmBanner);
		}
	}

	private static SecureString StringBuilderToSecureString(StringBuilder password)
	{
		// Copy the password into the secure string, zeroing the original buffer as we go
		var newPassword = new SecureString();
		for (var i = 0; i < password.Length; i++)
		{
			newPassword.AppendChar(password[i]);
			password[i] = '\0';
		}
		return newPassword;
	}

	/// <summary>Used by the <see cref="CredentialsDialog.ValidatePassword"/> event.</summary>
	public class PasswordValidatorEventArgs : EventArgs
	{
		/// <summary>Initializes a new instance of the <see cref="PasswordValidatorEventArgs"/> class.</summary>
		/// <param name="un">The user name.</param>
		/// <param name="pwd">The password.</param>
		/// <param name="sPwd">The secure password.</param>
		internal PasswordValidatorEventArgs(string un, string pwd, SecureString sPwd)
		{
			Username = un;
			Password = pwd;
			SecurePassword = sPwd;
		}

		/// <summary>Gets the password.</summary>
		/// <value>The password.</value>
		public string Password { get; }

		/// <summary>Gets the secure password.</summary>
		/// <value>The secure password.</value>
		public SecureString SecurePassword { get; }

		/// <summary>Gets the username.</summary>
		/// <value>The username.</value>
		public string Username { get; }

		/// <summary>Gets or sets a value indicating whether this <see cref="PasswordValidatorEventArgs"/> is validated.</summary>
		/// <value><c>true</c> if validated; otherwise, <c>false</c>.</value>
		public bool Validated { get; set; } = false;
	}
}