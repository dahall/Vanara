namespace Vanara.Windows.Forms.Tests;

[TestFixture()]
public class AccessControlEditorTests
{
	[Test, RequiresThread(System.Threading.ApartmentState.STA)]
	public void AccessControlEditorTest()
	{
		var dlg = new AccessControlEditorDialog() { ElevationRequired = true, OwnerElevationRequired = true, AllowEditOwner = true };
		//dlg.Flags = SI_OBJECT_INFO_Flags.SI_EDIT_OWNER | SI_OBJECT_INFO_Flags.SI_EDIT_AUDITS | SI_OBJECT_INFO_Flags.SI_ADVANCED | SI_OBJECT_INFO_Flags.SI_RESET | SI_OBJECT_INFO_Flags.SI_EDIT_PROPERTIES | SI_OBJECT_INFO_Flags.SI_EDIT_EFFECTIVE | SI_OBJECT_INFO_Flags.SI_RESET_SACL;
		//dlg.ResourceType = AccessControlEditorDialog.TaskResourceType; dlg.ObjectName = @"AUScheduledInstall";
		dlg.Initialize(new System.IO.FileInfo(PInvoke.Tests.TestCaseSources.SmallFile));
		dlg.ShowDialog();

		dlg.Initialize(new System.IO.DirectoryInfo(PInvoke.Tests.TestCaseSources.TempDir));
		dlg.ShowDialog();

		dlg.Initialize(Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Console")!);
		dlg.ShowDialog();
	}
}