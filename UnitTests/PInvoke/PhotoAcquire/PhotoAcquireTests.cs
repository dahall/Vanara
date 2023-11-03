using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Threading;
using static Vanara.PInvoke.PhotoAcquisition;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class PhotoAcquireTests
{
	private string? devId;
	private static readonly HWND hwndDesktop = User32.GetDesktopWindow();

	[Test]
	public void Test()
	{
		if (devId is null) TestSelDlg();
		Assert.NotNull(devId);

		IPhotoAcquire acquire = new();
		IPhotoAcquireSource? src = acquire.CreatePhotoSource(devId!);
		PhotoAcquireProgress? progress = null; // new();
		acquire.Acquire(src, true, hwndDesktop, "Test", progress);

		TestContext.WriteLine($"Files ===================");
		foreach (var file in acquire.EnumResults()!.Enum())
			TestContext.WriteLine("   " + file);

		TestContext.WriteLine($"Files from Property ===================");
		for (uint i = 0; i < src?.GetItemCount(); i++)
		{
			IPhotoAcquireItem? item = src.GetItemAt(i);
			Assert.NotNull(item);
			var name = item!.GetItemName();
			string? file = item.GetProperty(PKEY_PhotoAcquire_FinalFilename)?.ToString();
			if (file is not null)
			{
				System.IO.File.Delete(file);
				TestContext.WriteLine("   " + file);
			}

			for (uint j = 0; j < item.GetSubItemCount(); j++)
			{
				IPhotoAcquireItem? subItem = item!.GetSubItemAt(i);
				var subName = subItem?.GetItemName();
				string? subfile = subItem?.GetProperty(PKEY_PhotoAcquire_FinalFilename)?.ToString();
				if (subfile is not null)
				{
					System.IO.File.Delete(subfile);
					TestContext.WriteLine("      " + subfile);
				}
			}
		}
	}

	[Test]
	public void TestSrc()
	{
		if (devId is null) TestSelDlg();
		Assert.NotNull(devId);

		IPhotoAcquire acquire = new();
		IPhotoAcquireSource? src = acquire.CreatePhotoSource(devId!);
		Assert.NotNull(src);

		Assert.That(src!.GetFriendlyName(), Is.Not.Null);
		Assert.That(src!.GetDeviceId(), Is.EqualTo(devId));
		IPhotoAcquireSettings? settings = null;
		Assert.That(settings = src!.GetPhotoAcquireSettings(), Is.Not.Null);

		Assert.That(settings!.GetFlags().IsValid(), Is.True);
		Assert.That(settings!.GetOutputFilenameTemplate(), Is.Not.Null);
		Assert.That(settings!.GetSequencePaddingWidth(), Is.GreaterThan(0));
		Assert.That(settings!.GetSequencePaddingWidth(), Is.GreaterThan(0));
		Assert.That(settings!.GetAcquisitionTime().ToDateTime(), Is.GreaterThan(DateTime.MinValue));

		src.GetDeviceIcons(32, out var hIco, out var hSmIco);
		Assert.NotNull(hIco);
		Assert.That(hIco, ResultIs.ValidHandle);
		Assert.That(hSmIco, ResultIs.ValidHandle);

		uint cnt = 0;
		Assert.That(() => src.InitializeItemList(false, null, out cnt), Throws.Nothing);
		Assert.That(cnt, Is.GreaterThan(0));
		Assert.That(cnt, Is.EqualTo(src.GetItemCount()));
	}

	[Test]
	public void TestProgDlg()
	{
		IPhotoProgressDialog dlg = new();
		dlg.Create(hwndDesktop);
		dlg.SetTitle("Progress");
		dlg.ShowCheckbox(PROGRESS_DIALOG_CHECKBOX_ID.PROGRESS_DIALOG_CHECKBOX_ID_DEFAULT, true);
		dlg.SetCheckboxText(PROGRESS_DIALOG_CHECKBOX_ID.PROGRESS_DIALOG_CHECKBOX_ID_DEFAULT, "Do Del");
		dlg.SetCheckboxCheck(PROGRESS_DIALOG_CHECKBOX_ID.PROGRESS_DIALOG_CHECKBOX_ID_DEFAULT, true);
		dlg.SetCheckboxTooltip(PROGRESS_DIALOG_CHECKBOX_ID.PROGRESS_DIALOG_CHECKBOX_ID_DEFAULT, "tooltip");
		dlg.SetCaption("My Caption");
		dlg.SetPercentComplete(25);
		dlg.SetProgressText("25%");
		ProgAction pAction = new();
		dlg.SetActionLinkCallback(pAction);
		dlg.SetActionLinkText("Action!");
		dlg.ShowActionLink(true);
		var input = dlg.GetUserInput(new UserInput());
		Thread.Sleep(10000);
		dlg.Destroy();
	}

	[Test]
	public void TestSelDlg()
	{
		IPhotoAcquireDeviceSelectionDialog seldlg = new();
		seldlg.SetSubmitButtonText("Submit");
		seldlg.SetTitle("Select acquisition device");
		Assert.That(seldlg.DoModal(hwndDesktop, DSF.DSF_ALL_DEVICES, out devId, out var devType), ResultIs.Successful);
		TestContext.WriteLine($"Using device: {devId} ({devType})");
	}

	[Test]
	public void OptsTest()
	{
		IPhotoAcquireOptionsDialog dlg = new();
		dlg.Initialize();
		Assert.That(dlg.DoModal(User32.GetDesktopWindow()).ToInt32(), Is.EqualTo((int)User32.MB_RESULT.IDOK));
	}
}

[ComVisible(true)]
public class UserInput : IUserInputString
{
	HRESULT IUserInputString.GetSubmitButtonText(out string pbstrSubmitButtonText) { pbstrSubmitButtonText = "Submit"; return HRESULT.S_OK; }
	HRESULT IUserInputString.GetPrompt(out string pbstrPromptTitle) { pbstrPromptTitle = "PromptTitle"; return HRESULT.S_OK; }
	HRESULT IUserInputString.GetStringId(out string pbstrStringId) { pbstrStringId = "StringId"; return HRESULT.S_OK; }
	HRESULT IUserInputString.GetStringType(out USER_INPUT_STRING_TYPE pnStringType) { pnStringType = USER_INPUT_STRING_TYPE.USER_INPUT_DEFAULT; return HRESULT.S_OK; }
	HRESULT IUserInputString.GetTooltipText(out string pbstrTooltipText) { pbstrTooltipText = "TooltipText"; return HRESULT.S_OK; }
	HRESULT IUserInputString.GetMaxLength(out uint pcchMaxLength) { pcchMaxLength = 64; return HRESULT.S_OK; }
	HRESULT IUserInputString.GetDefault(out string pbstrDefault) { pbstrDefault = "Default"; return HRESULT.S_OK; }
	HRESULT IUserInputString.GetMruCount(out uint pnMruCount) { pnMruCount = 2; return HRESULT.S_OK; }
	HRESULT IUserInputString.GetMruEntryAt(uint nIndex, out string pbstrMruEntry) { pbstrMruEntry = nIndex.ToString(); return HRESULT.S_OK; }
	HRESULT IUserInputString.GetImage(uint nSize, out Gdi32.SafeHBITMAP phBitmap, out User32.SafeHICON phIcon) { phBitmap = Gdi32.SafeHBITMAP.Null; phIcon = User32.SafeHICON.Null; return HRESULT.S_OK; }
}

[ComVisible(true)]
public class ProgAction : IPhotoProgressActionCB
{
	HRESULT IPhotoProgressActionCB.DoAction(HWND hWndParent)
	{
		User32.MessageBox(hWndParent, "Doing action", "Action", User32.MB_FLAGS.MB_OK);
		return HRESULT.S_OK;
	}
}

[ComVisible(true)]
public class PhotoAcquireProgress : IPhotoAcquireProgressCB
{
	HRESULT IPhotoAcquireProgressCB.Cancelled(out bool pfCancelled) { pfCancelled = true; return HRESULT.S_OK; }
	HRESULT IPhotoAcquireProgressCB.StartEnumeration(IPhotoAcquireSource? pPhotoAcquireSource) => HRESULT.S_OK;
	HRESULT IPhotoAcquireProgressCB.FoundItem(IPhotoAcquireItem pPhotoAcquireItem) => HRESULT.S_OK;
	HRESULT IPhotoAcquireProgressCB.EndEnumeration(HRESULT hr) => HRESULT.S_OK;
	HRESULT IPhotoAcquireProgressCB.StartTransfer(IPhotoAcquireSource? pPhotoAcquireSource) => HRESULT.S_OK;
	HRESULT IPhotoAcquireProgressCB.StartItemTransfer(uint nItemIndex, IPhotoAcquireItem? pPhotoAcquireItem) => HRESULT.S_OK;
	HRESULT IPhotoAcquireProgressCB.DirectoryCreated(string pszDirectory) => HRESULT.S_OK;
	HRESULT IPhotoAcquireProgressCB.UpdateTransferPercent(bool fOverall, uint nPercent) => HRESULT.S_OK;
	HRESULT IPhotoAcquireProgressCB.EndItemTransfer(uint nItemIndex, IPhotoAcquireItem? pPhotoAcquireItem, HRESULT hr) => HRESULT.S_OK;
	HRESULT IPhotoAcquireProgressCB.EndTransfer(HRESULT hr) => HRESULT.S_OK;
	HRESULT IPhotoAcquireProgressCB.StartDelete(IPhotoAcquireSource? pPhotoAcquireSource) => HRESULT.S_OK;
	HRESULT IPhotoAcquireProgressCB.StartItemDelete(uint nItemIndex, IPhotoAcquireItem? pPhotoAcquireItem) => HRESULT.S_OK;
	HRESULT IPhotoAcquireProgressCB.UpdateDeletePercent(uint nPercent) => HRESULT.S_OK;
	HRESULT IPhotoAcquireProgressCB.EndItemDelete(uint nItemIndex, IPhotoAcquireItem? pPhotoAcquireItem, HRESULT hr) => HRESULT.S_OK;
	HRESULT IPhotoAcquireProgressCB.EndDelete(HRESULT hr) => HRESULT.S_OK;
	HRESULT IPhotoAcquireProgressCB.EndSession(HRESULT hr) => HRESULT.S_OK;
	HRESULT IPhotoAcquireProgressCB.GetDeleteAfterAcquire(out bool pfDeleteAfterAcquire) { pfDeleteAfterAcquire = true; return HRESULT.S_OK; }
	HRESULT IPhotoAcquireProgressCB.ErrorAdvise(HRESULT hr, string pszErrorMessage, ERROR_ADVISE_MESSAGE_TYPE nMessageType, out ERROR_ADVISE_RESULT pnErrorAdviseResult) { pnErrorAdviseResult = ERROR_ADVISE_RESULT.PHOTOACQUIRE_RESULT_OK; return HRESULT.S_OK; }
	HRESULT IPhotoAcquireProgressCB.GetUserInput(in Guid riidType, object? pUnknown, Ole32.PROPVARIANT pPropVarResult, Ole32.PROPVARIANT? pPropVarDefault) => HRESULT.S_OK;
}