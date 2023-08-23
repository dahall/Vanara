using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Threading;
using static Vanara.PInvoke.DOSvc;
using static Vanara.PInvoke.Ole32;

namespace Vanara.PInvoke.Tests;
[TestFixture]
public class DOSvcTests
{
	[OneTimeSetUp]
	public void _Setup()
	{
	}

	[OneTimeTearDown]
	public void _TearDown()
	{
	}

	[Test]
	public void Test()
	{
		const string name = "Test download";
		string id = Guid.NewGuid().ToString("N");

		using var tempRoot = new TemporaryDirectory();
		var uri = "https://github.com/EWSoftware/SHFB/releases/download/2022.8.14.1/SHFBInstaller_2022.8.14.1.zip";
		var dest = tempRoot.RandomTxtFileFullPath;

		IDOManager mgr = new();
		var dnld = mgr.CreateDownload();
		CoSetProxyBlanket(dnld, dwImpLevel: Rpc.RPC_C_IMP_LEVEL.RPC_C_IMP_LEVEL_IMPERSONATE, dwCapabilities: EOLE_AUTHENTICATION_CAPABILITIES.EOAC_STATIC_CLOAKING).ThrowIfFailed();

		dnld.SetProperty(DODownloadProperty.DODownloadProperty_Uri, uri);
		dnld.SetProperty(DODownloadProperty.DODownloadProperty_ForegroundPriority, true);
		dnld.SetProperty(DODownloadProperty.DODownloadProperty_LocalPath, dest);
		dnld.SetProperty(DODownloadProperty.DODownloadProperty_DisplayName, name);
		dnld.SetProperty(DODownloadProperty.DODownloadProperty_ContentId, id);

		AutoResetEvent done = new(false);
		var callback = new Callback();
		callback.StatusChange += (s) => { if (s.State == DODownloadState.DODownloadState_Finalized) done.Set(); else if (s.Error.Failed) throw s.Error.GetException(); };
		object wrp = new UnknownWrapper(callback);
		dnld.SetProperty(DODownloadProperty.DODownloadProperty_CallbackInterface, wrp);

		dnld.Start();
		done.WaitOne();
		dnld.Finalize();
	}
}

[ComVisible(true), Guid("90AFD61C-C21C-4627-8A9A-E3268BC89051")]
public class Callback : IDODownloadStatusCallback
{
	public event Action<DO_DOWNLOAD_STATUS> StatusChange;

	public Callback() { }

	HRESULT IDODownloadStatusCallback.OnStatusChange(IDODownload download, in DO_DOWNLOAD_STATUS status)
	{
		StatusChange?.Invoke(status);
		return HRESULT.S_OK;
	}
}