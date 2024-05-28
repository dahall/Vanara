using NUnit.Framework;
using NUnit.Framework.Internal;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Vanara.Utilities;
using static Vanara.PInvoke.DOSvc;
using static Vanara.PInvoke.Ole32;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class DOSvcTests
{
	private const string name = "Test download";
	private readonly string uri = "https://github.com/EWSoftware/SHFB/releases/download/2023.7.8.0/SHFBInstaller_2023.7.8.0.zip";

	[OneTimeSetUp]
	public void _Setup() => CoInitializeSecurity(PSECURITY_DESCRIPTOR.NULL, -1, null, default, Rpc.RPC_C_AUTHN_LEVEL.RPC_C_AUTHN_LEVEL_DEFAULT,
		Rpc.RPC_C_IMP_LEVEL.RPC_C_IMP_LEVEL_IMPERSONATE, dwCapabilities: EOLE_AUTHENTICATION_CAPABILITIES.EOAC_STATIC_CLOAKING).ThrowIfFailed();

	[Test]
	public async Task TestAsync()
	{
		using TemporaryDirectory tempRoot = new();
		string dest = tempRoot.RandomTxtFileFullPath;

		var tw = TestContext.Out;
		Progress<DO_DOWNLOAD_STATUS> progress = new();
		progress.ProgressChanged += (s, e) => tw.WriteLine($"{e.State} - {100*e.BytesTransferred/e.BytesTotal}%");
		CancellationTokenSource cancel = new();
		var ret = await Downloader.DownloadAsync(uri, dest, true, name, true, null, progress, null, cancel.Token);
		Assert.That(File.Exists(dest), Is.True);
		Assert.That(ret, Is.Not.Empty);
	}

	[Test]
	public void TestAsyncCancel()
	{
		using TemporaryDirectory tempRoot = new();
		string dest = tempRoot.RandomTxtFileFullPath;

		var tw = TestContext.Out;
		Progress<DO_DOWNLOAD_STATUS> progress = new();
		progress.ProgressChanged += (s, e) => tw.WriteLine($"{e.State} - {100*e.BytesTransferred/e.BytesTotal}%");
		CancellationTokenSource cancel = new();
		var task = Downloader.DownloadAsync(uri, dest, false, name, true, null, progress, null, cancel.Token);
		cancel.Cancel();
		Assert.That(task.IsCanceled, Is.True);
	}

	[Test]
	public void Test()
	{
		SetupDownload(out var dnld, out var tempRoot, out var dest, out var done);

		dnld.Start();
		Assert.That(done.WaitOne(TimeSpan.FromMinutes(1)), Is.True);
		dnld.Finalize();
		Thread.Sleep(250);
		Assert.That(File.Exists(dest), Is.True);
	}

	[Test]
	public void TestAbort()
	{
		SetupDownload(out var dnld, out var tempRoot, out var dest, out var done);

		dnld.Start();
		dnld.Abort();
		Assert.That(dnld.GetStatus().State, Is.EqualTo(DODownloadState.DODownloadState_Aborted));
		Assert.That(() => dnld.Finalize(), Throws.Exception);
		Assert.That(File.Exists(dest), Is.False);
	}

	private void SetupDownload(out IDODownload dnld, out TemporaryDirectory tempRoot, out string dest, out AutoResetEvent doneEvent)
	{
		IDOManager mgr = new();
		IDODownload download = dnld = mgr.CreateDownload();
		CoSetProxyBlanket(download, dwImpLevel: Rpc.RPC_C_IMP_LEVEL.RPC_C_IMP_LEVEL_IMPERSONATE/*, dwCapabilities: EOLE_AUTHENTICATION_CAPABILITIES.EOAC_STATIC_CLOAKING*/).ThrowIfFailed();

		var done = doneEvent = new(false);
		Callback callback = new();
		var tw = TestContext.Out;
		callback.StatusChange += (s) => { tw.WriteLine("========"); tw.WriteLine(s.GetStringVal()); if (s.State is DODownloadState.DODownloadState_Transferred or DODownloadState.DODownloadState_Finalized) done.Set(); else if (s.Error.Failed) throw s.Error.GetException()!; };
		Assert.That(() => download.SetProperty(DODownloadProperty.DODownloadProperty_CallbackInterface, callback), Throws.Nothing);

		tempRoot = new();
		string destination = dest = tempRoot.RandomTxtFileFullPath;
		Assert.That(() => download.SetProperty(DODownloadProperty.DODownloadProperty_Uri, uri), Throws.Nothing);
		Assert.That((string)download.GetProperty(DODownloadProperty.DODownloadProperty_Uri), Is.EqualTo(uri));
		Assert.That(() => download.SetProperty(DODownloadProperty.DODownloadProperty_LocalPath, destination), Throws.Nothing);
		Assert.That((string)download.GetProperty(DODownloadProperty.DODownloadProperty_LocalPath), Is.EqualTo(dest));
		Assert.That(() => download.SetProperty(DODownloadProperty.DODownloadProperty_DisplayName, name), Throws.Nothing);
		Assert.That((string)download.GetProperty(DODownloadProperty.DODownloadProperty_DisplayName), Is.EqualTo(name));
		Assert.That(() => download.SetProperty(DODownloadProperty.DODownloadProperty_ForegroundPriority, true), Throws.Nothing);
		Assert.That((bool)download.GetProperty(DODownloadProperty.DODownloadProperty_ForegroundPriority), Is.True);
	}

	[ComVisible(true), Guid("90AFD61C-C21C-4627-8A9A-E3268BC89051")]
	public class Callback : IDODownloadStatusCallback
	{
		public event Action<DO_DOWNLOAD_STATUS>? StatusChange;

		HRESULT IDODownloadStatusCallback.OnStatusChange(IDODownload download, in DO_DOWNLOAD_STATUS status)
		{
			StatusChange?.Invoke(status);
			return HRESULT.S_OK;
		}
	}
}