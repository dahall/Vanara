using NUnit.Framework;
using NUnit.Framework.Internal;
using System.IO;
using System.Threading;
using Vanara.Utilities;
using static Vanara.PInvoke.DOSvc;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class DOSvcTests
{
	[Test]
	public async void Test()
	{
		const string name = "Test download";
		string id = Guid.NewGuid().ToString("N");

		using TemporaryDirectory tempRoot = new();
		string uri = "https://github.com/EWSoftware/SHFB/releases/download/2023.7.8.0/SHFBInstaller_2023.7.8.0.zip";
		string dest = tempRoot.RandomTxtFileFullPath;

		Progress<DO_DOWNLOAD_STATUS> progress = new();
		progress.ProgressChanged += (s, e) => TestContext.WriteLine(e.State);
		CancellationTokenSource cancel = new();
		await Downloader.DownloadAsync(uri, dest, progress, cancel.Token, true, name, id);
		Assert.That(File.Exists(dest), Is.True);

		//IDOManager mgr = new();
		//IDODownload dnld = mgr.CreateDownload();
		//CoSetProxyBlanket(dnld, dwImpLevel: Rpc.RPC_C_IMP_LEVEL.RPC_C_IMP_LEVEL_IMPERSONATE/*, dwCapabilities: EOLE_AUTHENTICATION_CAPABILITIES.EOAC_STATIC_CLOAKING*/).ThrowIfFailed();

		//Assert.That(() => dnld.SetProperty(DODownloadProperty.DODownloadProperty_Uri, uri), Throws.Nothing);
		//Assert.That((string)dnld.GetProperty(DODownloadProperty.DODownloadProperty_Uri), Is.EqualTo(uri));
		//Assert.That(() => dnld.SetProperty(DODownloadProperty.DODownloadProperty_ForegroundPriority, true), Throws.Nothing);
		//Assert.That((bool)dnld.GetProperty(DODownloadProperty.DODownloadProperty_ForegroundPriority), Is.True);
		//Assert.That(() => dnld.SetProperty(DODownloadProperty.DODownloadProperty_LocalPath, dest), Throws.Nothing);
		//Assert.That((string)dnld.GetProperty(DODownloadProperty.DODownloadProperty_LocalPath), Is.EqualTo(dest));
		//Assert.That(() => dnld.SetProperty(DODownloadProperty.DODownloadProperty_DisplayName, name), Throws.Nothing);
		//Assert.That((string)dnld.GetProperty(DODownloadProperty.DODownloadProperty_DisplayName), Is.EqualTo(name));

		//AutoResetEvent done = new(false);
		//Callback callback = new();
		//callback.StatusChange += (s) => { if (s.State == DODownloadState.DODownloadState_Finalized) done.Set(); else if (s.Error.Failed) throw s.Error.GetException()!; };
		//object wrp = new UnknownWrapper(callback);
		//Assert.That(() => dnld.SetProperty(DODownloadProperty.DODownloadProperty_CallbackInterface, wrp), Throws.Nothing);

		//dnld.Start();
		//done.WaitOne();
		//dnld.Finalize();
	}
}