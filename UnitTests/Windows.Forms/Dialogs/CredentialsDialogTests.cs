namespace Vanara.Windows.Forms.Tests;

[TestFixture()]
public class CredentialsDialogTests
{
	[Test()]
	public void CredentialsDialogTest()
	{
		var cd = new CredentialsDialog("Caption", "Message", Environment.UserDomainName + "\\" + Environment.UserName);
		cd.EncryptPassword = true;
		cd.ForcePreVistaUI = true;
		cd.SaveChecked = true;
		cd.ShowSaveCheckBox = true;
		cd.Target = "TestTarget";
		cd.ValidatePassword += CredDlgOnValidatePassword;
		cd.ShowDialog();
		Assert.That(MessageBox.Show("Confirm UI strings, old dlg and save chkbox", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes);
		cd.ConfirmCredentials(false);

		cd.Reset();
		Assert.That(cd.Caption, Is.Null);
		Assert.That(cd.SaveChecked, Is.False);

		cd.Caption = "Caption";
		cd.UserName = "AMERICAS\\dahall";
		cd.ValidatePassword += CredentialsDialog.StandardPasswordValidator;
		cd.ShowDialog();
		Assert.That(MessageBox.Show("Confirm new dlg and no save chkbox", "Confirm", MessageBoxButtons.YesNo) == DialogResult.Yes);
		cd.ConfirmCredentials(true);

		CredentialsDialog.ParseUserName(cd.UserName, out var user, out var dom);

		void CredDlgOnValidatePassword(object? sender, CredentialsDialog.PasswordValidatorEventArgs e)
		{
			Assert.That(ReferenceEquals(sender, cd));
			if (cd.EncryptPassword)
			{
				Assert.That(e.Password, Is.Null);
				Assert.That(e.SecurePassword, Is.Not.Null);
			}
			else
			{
				Assert.That(e.Password, Is.Not.Null);
				Assert.That(e.SecurePassword, Is.Null);
			}
		}
	}
}