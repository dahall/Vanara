//#define WUTYPELIB
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
#if !WUTYPELIB
using Vanara.WindowsUpdate;
using static Vanara.PInvoke.WUApi;
#else
using System.Collections.Generic;
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
	public async Task TestInstaller()
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

#if WUTYPELIB
		List<IUpdate> autoUpd = new UpdateSearcher().Search("IsInstalled=0").Updates.Cast<IUpdate>().Where(u => u.AutoSelectOnWebSites).ToList();
		List<IUpdate> dnld = autoUpd.Where(u => !u.IsDownloaded).ToList();
		if (dnld.Count > 0)
		{
			var dnldColl = new UpdateCollection();
			dnld.ForEach(u => dnldColl.Add(u));
			new UpdateDownloader() { Updates = dnldColl }.DownloadAsync(p => p.WriteValues()).Result.WriteValues();
		}

		var updColl = new UpdateCollection();
		autoUpd.ForEach(u => updColl.Add(u));
		var res = new UpdateInstaller { AllowSourcePrompts = false, ForceQuiet = true, Updates = updColl }.InstallAsync(p => p.WriteValues()).Result;
#else
		var autoUpd = new UpdateSearcher().Search("IsInstalled=0").Updates.Where(u => u.AutoSelectOnWebSites).ToList();
		var dnld = autoUpd.Where(u => !u.IsDownloaded).ToList();
		if (dnld.Count > 0)
		{
			var dres = await new UpdateDownloader(dnld).DownloadAsync(p => p.WriteValues());
			dres.WriteValues();
			Assert.That(dres.HResult, ResultIs.Successful);
		}

		var res = await new UpdateInstaller(autoUpd) { AllowSourcePrompts = false, ForceQuiet = true }.InstallAsync(p => p.WriteValues());
#endif
		res.WriteValues();
		Assert.That(res.HResult, ResultIs.Successful);
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
		foreach (var upd in res.Updates.Cast<Update>())
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
		foreach (var upd in res.Updates.Cast<Update>())
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

	[TestWhenElevated]
	public void TestUpdateServiceManager()
	{
		const string svcid = "7971f918-a847-4430-9279-4a52d1efe18d"; // Guid.NewGuid().ToString("D");

		UpdateServiceManager mgr = new() { ClientApplicationID = "Test" };
#if WUTYPELIB
		foreach (var up in mgr.Services.Cast<IUpdateService>())
			up.WriteValues();
		var us = mgr.AddService2(svcid, (int)(AddServiceFlag.asfAllowOnlineRegistration | AddServiceFlag.asfAllowPendingRegistration), "");
#else
		foreach (var up in mgr)
			up.WriteValues();
		var us = mgr.AddService(svcid, AddServiceFlag.asfAllowOnlineRegistration | AddServiceFlag.asfAllowPendingRegistration);
#endif
		Assert.That(us?.ServiceID, Is.EqualTo(svcid));
		us?.WriteValues();
		mgr.RemoveService(svcid);
	}

#if !WUTYPELIB
	[Test]
	public void UpdateTestRaw()
	{
		// Create searcher
		IUpdateSearcher updateSearcher = new();

		// Create list of updates to install
		IUpdateCollection updatesToInstall = (IUpdateCollection)new UpdateCollectionClass();
		var searchResult = updateSearcher.Search("IsInstalled=1 AND IsHidden=0");
		var updates = searchResult.Updates.Cast<IUpdate>().ToList();

		// Check updates downloaded
		var downloadable = updates.Where(u =>!u.IsDownloaded && (!u.Title.Contains("Internet Explorer 9") || !u.Title.Contains("Internet Explorer 10"))).ToList();

		// Add downloaded to updates to install
		foreach (var x in updates.Where(x => !downloadable.Contains(x)))
			updatesToInstall.Add(x);

		if (downloadable.Count > 0)
		{
			// Create Downloader
			IUpdateDownloader downloader = new();
			downloader.Priority = DownloadPriority.dpNormal;
			downloader.ClientApplicationID = "Test";

			// Create list of updates to download
			IUpdateCollection updatesToDownload = (IUpdateCollection)new UpdateCollectionClass();
			foreach (var update in downloadable)
				updatesToDownload.Add(update);

			// Create awaiter
			var downloadTask = new TaskCompletionSource<IDownloadResult>();

			// Download updates
			downloader.Updates = updatesToDownload; // <------ issue
			Console.WriteLine("Downloading updates ...");
			IUpdate? latest;
			downloader.BeginDownload(new DownloadProgressChangedCallback(progress =>
			{
				// Calculate percent
				Console.WriteLine($"Downloading {progress.PercentComplete}% ...");
				switch (progress.CurrentUpdateDownloadPhase)
				{
					case DownloadPhase.dphDownloading:
						latest = downloader.Updates[progress.CurrentUpdateIndex];
						Console.WriteLine($"Downloading {latest.Title} in {progress.CurrentUpdatePercentComplete}% ...");
						break;
					case DownloadPhase.dphVerifying:
						updatesToInstall.Add(downloader.Updates[progress.CurrentUpdateIndex]);
						break;
				}
			}), new DownloadCompletedCallback((job, _) =>
			{
				try { downloadTask.TrySetResult(downloader.EndDownload(job)); }
				catch (Exception ex) { downloadTask.TrySetException(ex); }
			}), null);

			// Get download result
			try
			{
				var downloadResult = downloadTask.Task.Result;
				if (downloadResult.ResultCode == OperationResultCode.orcFailed)
					Console.WriteLine("Failed to download!");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Failed to download updates: {ex.Message}");
			}
		}

		if (updatesToInstall.Count > 0)
		{
			// Create installer
			// TODO: Solve problem with set updates to downloader and installer instances
			IUpdateInstaller installer = new();
			installer.Updates = updatesToInstall;
			installer.AllowSourcePrompts = false;
			installer.IsForced = true;

			// Create awaiter
			var installTask = new TaskCompletionSource<IInstallationResult>();

			installer.BeginInstall(
				new InstallationProgressChangeCallback(progress =>
					Console.Write($"Installing {progress.PercentComplete}% ...")),
				new InstallationCompletedCallback(job =>
				{
					try { installTask.TrySetResult(installer.EndInstall(job)); }
					catch (Exception e) { installTask.TrySetException(e); }
				}), null);

			// Get installation result
			try
			{
				var installResult = installTask.Task.Result;
				if (installResult.ResultCode == OperationResultCode.orcFailed)
				{
					Console.WriteLine("Failed to install!");
					return;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Failed to install updates: {ex.Message}");
				return;
			}
		}

		Console.WriteLine("Patching complete!");
	}
#endif

	public class DownloadProgressChangedCallback(Action<IDownloadProgress> action) : IDownloadProgressChangedCallback
	{
		public HRESULT Invoke(IDownloadJob job, IDownloadProgressChangedCallbackArgs args)
		{
			try { action.Invoke(args.Progress); }
			catch (Exception ex) { return ex.HResult; }

			return HRESULT.S_OK;
		}

#if WUTYPELIB
		void IDownloadProgressChangedCallback.Invoke(IDownloadJob downloadJob, IDownloadProgressChangedCallbackArgs callbackArgs) => Invoke(downloadJob, callbackArgs).ThrowIfFailed();
#endif
	}

	public class DownloadCompletedCallback(Action<IDownloadJob, IDownloadCompletedCallbackArgs> action) : IDownloadCompletedCallback
	{
		public HRESULT Invoke(IDownloadJob job, IDownloadCompletedCallbackArgs args)
		{
			try { action.Invoke(job, args); }
			catch (Exception ex) { return ex.HResult; }

			return HRESULT.S_OK;
		}

#if WUTYPELIB
		void IDownloadCompletedCallback.Invoke(IDownloadJob downloadJob, IDownloadCompletedCallbackArgs callbackArgs) => Invoke(downloadJob, callbackArgs).ThrowIfFailed();
#endif
	}

	internal class InstallationProgressChangeCallback(Action<IInstallationProgress> action) : IInstallationProgressChangedCallback
	{
		public HRESULT Invoke(IInstallationJob job, IInstallationProgressChangedCallbackArgs args)
		{
			try { action.Invoke(args.Progress); }
			catch (Exception ex) { return ex.HResult; }

			return HRESULT.S_OK;
		}

#if WUTYPELIB
		void IInstallationProgressChangedCallback.Invoke(IInstallationJob downloadJob, IInstallationProgressChangedCallbackArgs callbackArgs) => Invoke(downloadJob, callbackArgs).ThrowIfFailed();
#endif
	}

	internal class InstallationCompletedCallback(Action<IInstallationJob> action) : IInstallationCompletedCallback
	{
		public HRESULT Invoke(IInstallationJob job, IInstallationCompletedCallbackArgs? args)
		{
			try { action.Invoke(job); }
			catch (Exception ex) { return ex.HResult; }

			return HRESULT.S_OK;
		}

#if WUTYPELIB
		void IInstallationCompletedCallback.Invoke(IInstallationJob downloadJob, IInstallationCompletedCallbackArgs callbackArgs) => Invoke(downloadJob, callbackArgs).ThrowIfFailed();
#endif
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