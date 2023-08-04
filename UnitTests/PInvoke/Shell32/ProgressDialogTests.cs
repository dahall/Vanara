using NUnit.Framework;
using System.Threading;
using static Vanara.PInvoke.Shell32;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class ProgressDialogTests
{
	[Test]
	public void InitTest()
	{
		var idlg = new IProgressDialog();
		idlg.SetTitle("Testing progress");
		idlg.SetCancelMsg("Don't like this?");
		idlg.SetLine(1, "Doing something really slow.", false);
		idlg.SetLine(2, @"C:\Users\you\Documents\GitHubRepos\Vanara\UnitTests\PInvoke\Shell32\ProgressDialogTests.cs", true);

		idlg.StartProgressDialog(IntPtr.Zero, null, PROGDLG.PROGDLG_AUTOTIME);
		var rnd = new Random();
		for (uint i = 0; i < 100; i++)
		{
			if (idlg.HasUserCancelled()) break;
			idlg.SetProgress(i, 100);
			Thread.Sleep(rnd.Next(50, 750));
		}
		idlg.StopProgressDialog();
	}

	[Test]
	public void ActionDlgTest()
	{
		var idlg = new IActionProgressDialog();
		idlg.Initialize(SPINITF.SPINITF_NORMAL, "Testing progress", "Don't like this?");
		var ia = (IActionProgress)idlg;
		ia.Begin(SPACTION.SPACTION_APPLYINGATTRIBS, SPBEGINF.SPBEGINF_AUTOTIME);
		ia.UpdateText(SPTEXT.SPTEXT_ACTIONDESCRIPTION, "Description", false);
		ia.UpdateText(SPTEXT.SPTEXT_ACTIONDETAIL, @"C:\Users\you\Documents\GitHubRepos\Vanara\UnitTests\PInvoke\Shell32\ProgressDialogTests.cs", true);
		var rnd = new Random();
		for (uint i = 0; i < 100; i++)
		{
			if (ia.QueryCancel()) break;
			ia.UpdateProgress(i, 100);
			Thread.Sleep(rnd.Next(50, 750));
		}
		ia.End();
		//idlg.Stop();
	}

	[Test]
	public void OpDlgTest()
	{
		var idlg = new IOperationsProgressDialog();
		idlg.StartProgressDialog(IntPtr.Zero, OPPROGDLGF.OPPROGDLG_DEFAULT);
		idlg.SetOperation(SPACTION.SPACTION_FORMATTING);
		idlg.SetMode(PDMODE.PDM_RUN);
		idlg.UpdateProgress(0, 0, 0, 0, 0, 100);
		var srcd = SHGetKnownFolderItem<IShellItem>(KNOWNFOLDERID.FOLDERID_Documents)!;
		var destd = SHGetKnownFolderItem<IShellItem>(KNOWNFOLDERID.FOLDERID_Desktop)!;
		idlg.UpdateLocations(srcd, destd);
		var rnd = new Random();
		for (uint i = 0; i < 100; i++)
		{
			if (idlg.GetOperationStatus() == PDOPSTATUS.PDOPS_CANCELLED) break;
			idlg.UpdateProgress(i * 1024, 102400, i * 1024, 102400, i, 100);
			Thread.Sleep(rnd.Next(50, 250));
		}
		idlg.StopProgressDialog();
		Marshal.FinalReleaseComObject(srcd);
		Marshal.FinalReleaseComObject(destd);
	}
}