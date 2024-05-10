using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Collections;
using System.Linq;
using Vanara.Extensions.Reflection;
using static Vanara.PInvoke.WUApi;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class WUApiTests
{
	private static readonly string[] UpdProps = [ "AutoSelectOnWebSites", "BundledUpdates", "CanRequireSource", "Categories", "Deadline", "DeltaCompressedContentAvailable",
		"DeltaCompressedContentPreferred", "DeploymentAction", "Description", "DownloadContents", "DownloadPriority", "EulaAccepted", "EulaText", "HandlerID",
		"Identity", "Image", "InstallationBehavior", "IsBeta", "IsDownloaded", "IsHidden", "IsInstalled", "IsMandatory", "IsUninstallable", "KBArticleIDs",
		"Languages", "LastDeploymentChangeTime", "MaxDownloadSize", "MinDownloadSize", "MoreInfoUrls", "MsrcSeverity", "RecommendedCpuSpeed",
		"RecommendedHardDiskSpace", "RecommendedMemory", "ReleaseNotes", "SecurityBulletinIDs", "SupersededUpdateIDs", "SupportUrl", "Title", "Type",
		"UninstallationBehavior", "UninstallationNotes", "UninstallationSteps", "KBArticleIDs", "DeploymentAction", "DownloadPriority", "DownloadContents",
		"RebootRequired", "IsPresent", "CveIDs", "BrowseOnly", "PerUser", "AutoSelection", "AutoDownload" ];

	[Test]
	public void TestUpdateSearch()
	{
		IUpdateSession2 sess = new();
		var searcher = sess.CreateUpdateSearcher();
		searcher.IncludePotentiallySupersededUpdates = true;
		var res = searcher.Search("IsInstalled=0");
		foreach (var upd in res.Updates.Cast<IUpdate5>())
		{
			TestContext.WriteLine(new string('=', 50));
			foreach (var prop in UpdProps)
			{
				try
				{
					var val = upd.GetPropertyValue<object>(prop);
					if (val is null)
						continue;
					if (val is not string and IEnumerable ie)
						try { TestContext.WriteLine($"{prop}: {string.Join(',', ie.Cast<object>().Select(o => o is string s ? s : o.GetPropertyValue<string>("Name")))}"); }
						catch { TestContext.WriteLine($"{prop}: {val.GetPropertyValue<int>("Count")} objects"); }
					else
						TestContext.WriteLine($"{prop}: {val}");
				}
				catch (COMException ce)
				{
					if (ce.ErrorCode == HRESULT.E_NOTIMPL)
						continue;
					throw;
				}
			}
		}
	}

	[Test]
	public void TestUpdateServiceManager()
	{
		IUpdateServiceManager2 mgr = new()
		{
			ClientApplicationID = "Test"
		};
		var svcid = Guid.NewGuid().ToString("D");
		mgr.AddService2(svcid, AddServiceFlag.asfRegisterServiceWithAU | AddServiceFlag.asfAllowPendingRegistration | AddServiceFlag.asfAllowOnlineRegistration, "");
		mgr.RemoveService(svcid);
	}
}