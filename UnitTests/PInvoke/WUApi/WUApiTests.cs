//#define WUTYPELIB
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
#if !WUTYPELIB
using Vanara.WindowsUpdate;
using static Vanara.PInvoke.WUApi;
#else
using WUApiLib;
#endif

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class WUApiTests
{
	[Test]
	public void TestAgent()
	{
		WindowsUpdateAgentInfo agent = new();
		Version? pv = null, ver = null;
#if !WUTYPELIB
		Assert.That(() => pv = agent.ProductVersion, Throws.Nothing);
		Assert.That(() => ver = agent.ApiVersion, Throws.Nothing);
#endif
		TestContext.WriteLine($"Version: {pv}, Api: {ver}");
	}

	[Test]
	public void TestAuto()
	{
		AutomaticUpdates auto = new();
		auto.WriteValues();
		//auto.EnableService();
		auto.DetectNow();
		auto.Resume();
		//auto.ShowSettingsDialog();

		//var t = auto.Settings.ScheduledInstallationTime;
		//auto.Settings.ScheduledInstallationTime = t + 1;
		//try { auto.Settings.Save(); Assert.That(auto.Settings.ScheduledInstallationTime, Is.EqualTo(t + 1)); }
		//finally { auto.Settings.ScheduledInstallationTime = t; }
	}

	[Test]
	public void TestDownloader()
	{
		UpdateDownloader downloader = new();
		downloader.WriteValues();
	}

	[Test]
	public void TestInstaller()
	{
		AutomaticUpdates auto = new();
		if (!auto.ServiceEnabled)
		{
			for (int i = 0; i <= 5 && !auto.ServiceEnabled; i++)
			{
				auto.EnableService();
				Thread.Sleep(2000);
			}
			Assert.That(auto.ServiceEnabled, Is.True);
		}

		var autoUpd = new UpdateSearcher().Search("IsInstalled=0").Updates.Where(u => u.AutoSelectOnWebSites).ToList();
		var dnld = autoUpd.Where(u => !u.IsDownloaded).ToList();
		if (dnld.Count > 0)
			new UpdateDownloader(dnld).DownloadAsync(p => p.WriteValues()).Result.WriteValues();

		var res = new UpdateInstaller(autoUpd) { AllowSourcePrompts = false, ForceQuiet = true }.InstallAsync(p => p.WriteValues()).Result;
		Assert.That(res.HResult, Is.EqualTo((HRESULT)0));
		res.WriteValues();
	}

	[Test]
	public void TestSysInfo()
	{
		SystemInformation info = new();
		info.WriteValues();
	}

#if !WUTYPELIB
	[Test]
	public void TestUpdateHistory()
	{
		foreach (UpdateHistoryEntry e in new UpdateHistory())
		{
			TestContext.WriteLine(new string('=', 50));
			e.WriteValues(false);
		}
	}
#endif

	[Test]
	public void TestUpdateSearch()
	{
		UpdateSearcher searcher = new();
		var res = searcher.Search("");
		foreach (var upd in res.Updates)
		{
			TestContext.WriteLine(new string('=', 50));
			TestContext.WriteLine(upd.Title);
			//upd.WriteValues(false);
		}
	}

#if !WUTYPELIB
	[Test]
	public void TestFLuentUpdateSearch()
	{
		UpdateSearcher searcher = new();
		var res = searcher.Where.Not.Installed.And.Not.Hidden.Search();
		foreach (var upd in res.Updates)
		{
			TestContext.WriteLine(new string('=', 50));
			upd.WriteValues(false);
		}
	}
#endif

	[Test]
	public async Task TestUpdateSearchAsync()
	{
		UpdateSearcher searcher = new();
		var res = await searcher.SearchAsync("IsInstalled=1");
		foreach (var upd in res.Updates)
		{
			TestContext.WriteLine(new string('=', 50));
			TestContext.WriteLine(upd.Title);
			//upd.WriteValues(false);
		}
	}

	[Test]
	public void TestSession()
	{
#if WUTYPELIB
		UpdateSession UpdateSession = new();
#endif
		TestContext.WriteLine($"ClientID: {UpdateSession.ClientApplicationID}, R/O: {UpdateSession.ReadOnly}, Locale: {UpdateSession.UserLocale}, ");
		UpdateSession.ClientApplicationID = "Test";
		Assert.That(UpdateSession.ClientApplicationID, Is.EqualTo("Test"));
		UpdateSession.UserLocale = (uint)LCID.LOCALE_INVARIANT;
		Assert.That(UpdateSession.UserLocale, Is.EqualTo(LCID.LOCALE_INVARIANT));
		var wp = UpdateSession.WebProxy;
		wp.WriteValues(false);
		wp.UserName = "test";
		wp.BypassList.Add("168.0.0.1");
		UpdateSession.WebProxy = wp;
		wp = UpdateSession.WebProxy;
		Assert.That(wp.UserName, Is.EqualTo("test"));
		Assert.That(wp.BypassList, Contains.Item("168.0.0.1"));
	}

	[Test]
	public void TestUpdateServiceManager()
	{
		UpdateServiceManager mgr = new() { ClientApplicationID = "Test" };
		foreach (var up in mgr)
			up.WriteValues();

		var svcid = "7971f918-a847-4430-9279-4a52d1efe18d"; // Guid.NewGuid().ToString("D");
		var us = mgr.AddService(svcid, AddServiceFlag.asfAllowOnlineRegistration | AddServiceFlag.asfAllowPendingRegistration);
		Assert.That(us?.ServiceID, Is.EqualTo(svcid));
		us?.WriteValues();
		mgr.RemoveService(svcid);
	}
}

#if WUTYPELIB
internal static class Ext
{
	/*public static UpdateCollection ToCollection(this IEnumerable<IUpdate> items)
	{
		if (items is UpdateCollection iuc) return iuc;
		UpdateCollection c = new();
		foreach (var i in items)
			c.Add(i);
		return c;
	}*/

	public static Task<IInstallationResult> InstallAsync(this IUpdateInstaller installer, Action<IInstallationProgress> progress, CancellationToken cancellationToken = default)
	{
		var task = new TaskCompletionSource<IInstallationResult>();
		if (cancellationToken.IsCancellationRequested)
		{
			task.TrySetCanceled(cancellationToken);
			return task.Task;
		}
		IInstallationJob? job = null;
		CancellationTokenRegistration? reg = null;
		job = installer.BeginInstall(new InstallationProgressChangeCallback(progress), new InstallationCompletedCallback(OnComplete), null);
		reg = cancellationToken.Register(() =>
		{
			task.TrySetCanceled(cancellationToken);
			job?.RequestAbort();
		});
		return task.Task;

		void OnComplete(IInstallationJob _job2, IInstallationCompletedCallbackArgs _)
		{
			try
			{
				try { task.TrySetResult(installer.EndInstall(_job2)); }
				catch (Exception e) { task.TrySetException(e);  }
			}
			finally
			{
				job = null;
				reg?.Dispose();
			}
		}
	}

	public static Task<ISearchResult> SearchAsync(this IUpdateSearcher searcher, string criteria, CancellationToken cancellationToken = default)
	{
		var task = new TaskCompletionSource<ISearchResult>();
		if (cancellationToken.IsCancellationRequested)
		{
			task.TrySetCanceled(cancellationToken);
			return task.Task;
		}
		ISearchJob? job = null;
		CancellationTokenRegistration? reg = null;
		job = searcher.BeginSearch(criteria, new SearchCompletedCallback(OnComplete), null);
		reg = cancellationToken.Register(() =>
		{
			task.TrySetCanceled(cancellationToken);
			job?.RequestAbort();
		});
		return task.Task;

		void OnComplete(ISearchJob _job, ISearchCompletedCallbackArgs _)
		{
			try
			{
				try { task.TrySetResult(searcher.EndSearch(_job)); }
				catch (Exception e) { task.TrySetException(e); }
			}
			finally
			{
				job = null;
				reg?.Dispose();
			}
		}
	}

	public static Task<IDownloadResult> DownloadAsync(this IUpdateDownloader downloader, Action<IDownloadProgress> progress, CancellationToken cancellationToken = default(CancellationToken))
	{
		var task = new TaskCompletionSource<IDownloadResult>();
		if (cancellationToken.IsCancellationRequested)
		{
			task.TrySetCanceled(cancellationToken);
			return task.Task;
		}
		IDownloadJob? job = null;
		CancellationTokenRegistration? reg = null;
		job = downloader.BeginDownload(new DownloadProgressChangedCallback(progress), new DownloadCompletedCallback(OnComplete), null);
		reg = cancellationToken.Register(() =>
		{
			task.TrySetCanceled(cancellationToken);
			job?.RequestAbort();
		});
		return task.Task;

		void OnComplete(IDownloadJob _job, IDownloadCompletedCallbackArgs _)
		{
			try
			{
				try { task.TrySetResult(downloader.EndDownload(_job)); }
				catch (Exception e) { task.TrySetException(e); }
			}
			finally
			{
				job = null;
				reg?.Dispose();
			}
		}
	}

	internal class DownloadProgressChangedCallback(Action<WUApiLib.IDownloadProgress> Action) : WUApiLib.IDownloadProgressChangedCallback
	{
		void WUApiLib.IDownloadProgressChangedCallback.Invoke(WUApiLib.IDownloadJob downloadJob, WUApiLib.IDownloadProgressChangedCallbackArgs callbackArgs) => Action?.Invoke(callbackArgs.Progress);
	}
	internal class DownloadCompletedCallback(Action<WUApiLib.IDownloadJob, WUApiLib.IDownloadCompletedCallbackArgs> Action) : WUApiLib.IDownloadCompletedCallback
	{
		void WUApiLib.IDownloadCompletedCallback.Invoke(WUApiLib.IDownloadJob downloadJob, WUApiLib.IDownloadCompletedCallbackArgs callbackArgs) => Action?.Invoke(downloadJob, callbackArgs);
	}
	internal class SearchCompletedCallback(Action<WUApiLib.ISearchJob, WUApiLib.ISearchCompletedCallbackArgs> Action) : WUApiLib.ISearchCompletedCallback
	{
		void WUApiLib.ISearchCompletedCallback.Invoke(WUApiLib.ISearchJob searchJob, WUApiLib.ISearchCompletedCallbackArgs callbackArgs) => Action?.Invoke(searchJob, callbackArgs);
	}
	internal class InstallationProgressChangeCallback(Action<WUApiLib.IInstallationProgress> Action) : WUApiLib.IInstallationProgressChangedCallback
	{
		void WUApiLib.IInstallationProgressChangedCallback.Invoke(WUApiLib.IInstallationJob installationJob, WUApiLib.IInstallationProgressChangedCallbackArgs callbackArgs) => Action?.Invoke(callbackArgs.Progress);
	}
	internal class InstallationCompletedCallback(Action<WUApiLib.IInstallationJob, WUApiLib.IInstallationCompletedCallbackArgs> Action) : WUApiLib.IInstallationCompletedCallback
	{
		void WUApiLib.IInstallationCompletedCallback.Invoke(WUApiLib.IInstallationJob installationJob, WUApiLib.IInstallationCompletedCallbackArgs callbackArgs) => Action?.Invoke(installationJob, callbackArgs);
	}
}
#endif