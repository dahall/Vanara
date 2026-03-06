using ICSharpCode.Decompiler.Metadata;
using Microsoft.CodeAnalysis;
using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Diagnostics;
using System.IO.Pipelines;
using System.Linq;
using System.Threading.Tasks;
using Vanara.PInvoke.VssApi;
using static Vanara.PInvoke.Kernel32;
using static Vanara.PInvoke.Ole32;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class VssApiTests
{
	static readonly Lazy<Guid> ProviderId = new(() =>
	{
		Assert.That(VssFactory.CreateVssBackupComponents(out IVssBackupComponents backup), ResultIs.Successful);
		backup.InitializeForBackup();
		VSS_OBJECT_PROP prop = backup.Query(default, VSS_OBJECT_TYPE.VSS_OBJECT_NONE, VSS_OBJECT_TYPE.VSS_OBJECT_PROVIDER).Enumerate().FirstOrDefault();
		Assert.That(prop.Obj.Prov.m_ProviderId, Is.Not.EqualTo(Guid.Empty));
		return prop.Obj.Prov.m_ProviderId;
	});

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
	string[] vols;
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

	[OneTimeSetUp]
	public void _Setup() => vols = [.. EnumVolumes()];

	[OneTimeTearDown]
	public void _TearDown()
	{
	}

	[TestWhenElevated]
	public void GetMetadataComponentInfo()
	{
		string metadataFile = TestCaseSources.GetFilePath("vss_metadata.xml");
		Assert.That(VssFactory.CreateVssExamineWriterMetadata(metadataFile, out var ppMetadata), ResultIs.Successful);
		int i = 0;
		foreach (var info in ppMetadata.Components.Select(c => c.GetComponentInfo()))
			TestContext.WriteLine($"{++i}: {info.bstrComponentName}={info.bstrLogicalPath}");
	}

	[TestWhenElevated]
	public async Task OpenStreamOnVSSCopy()
	{
		Assert.That(VssFactory.CreateVssBackupComponents(out IVssBackupComponents backup), ResultIs.Successful);
		backup.InitializeForBackup();
		backup.SetContext(VSS_SNAPSHOT_CONTEXT.VSS_CTX_BACKUP);
		backup.SetBackupState(true, true, VSS_BACKUP_TYPE.VSS_BT_FULL, false);
		Assert.That(backup.IsVolumeSupported(default, "C:\\"), Is.True);
		await backup.GatherWriterMetadata().AsTask();
		foreach (var writer in backup.WriterMetadata)
		{
			writer.GetIdentity(out var pidInstance, out var pidWriter, out var pbstrWriter, out var pInstanceName, out var usage, out var source);
			TestContext.WriteLine($"Writer: {pbstrWriter} ({pInstanceName})");
			int i = 0;
			foreach (var c in writer.Components)
			{
				var info = c.GetComponentInfo();
				TestContext.WriteLine($"  {++i}: {info.bstrCaption}={info.bstrComponentName} ({info.bstrLogicalPath})");
				foreach (var f in c.Files)
					TestContext.WriteLine($"    File: {f.Path} ({f.BackupTypeMask})");
			}
		}
		backup.FreeWriterMetadata();
		Guid snapshotSetId = backup.StartSnapshotSet();
		try
		{
			var snapId = backup.AddToSnapshotSet("C:\\");
			backup.PrepareForBackup();

			await backup.DoSnapshotSet().AsTask();

			var props = backup.GetSnapshotProperties(snapId);
			TestContext.WriteLine(props.m_pwszSnapshotDeviceObject);
			props.Dispose();

			await backup.BackupComplete().AsTask();
		}
		finally
		{
			HRESULT hr = backup.DeleteSnapshots(snapshotSetId, VSS_OBJECT_TYPE.VSS_OBJECT_SNAPSHOT_SET, true, out _, out var badId);
			if (hr.Failed)
				TestContext.WriteLine($"Failed to delete snapshot {badId}");
		}
	}

	[TestWhenElevated]
	public void QueryDiffAreasForVolumeTest()
	{
		Assert.That(vols, Has.Length.GreaterThan(0));

		IVssSnapshotMgmt imgr = new();
		var diffmgr = imgr.GetProviderMgmtInterface<IVssDifferentialSoftwareSnapshotMgmt>(ProviderId.Value);
		foreach (var vol in vols)
		{
			TestContext.WriteLine($"Volume: {vol}");
			try
			{
				var enumMgr = diffmgr.QueryDiffAreasForVolume(vol);
				foreach (var prop in enumMgr.Enumerate())
				{
					switch (prop.Type)
					{
						case VSS_MGMT_OBJECT_TYPE.VSS_MGMT_OBJECT_UNKNOWN:
							TestContext.WriteLine("  Unknown");
							break;
						case VSS_MGMT_OBJECT_TYPE.VSS_MGMT_OBJECT_VOLUME:
							TestContext.WriteLine($"  Volume: {prop.Obj.Vol.m_pwszVolumeDisplayName} ({prop.Obj.Vol.m_pwszVolumeName})");
							break;
						case VSS_MGMT_OBJECT_TYPE.VSS_MGMT_OBJECT_DIFF_VOLUME:
							TestContext.WriteLine($"  DiffVol: {prop.Obj.DiffVol.m_pwszVolumeDisplayName} ({prop.Obj.DiffVol.m_pwszVolumeName}) {prop.Obj.DiffVol.m_llVolumeTotalSpace}:{prop.Obj.DiffVol.m_llVolumeFreeSpace}");
							break;
						case VSS_MGMT_OBJECT_TYPE.VSS_MGMT_OBJECT_DIFF_AREA:
							TestContext.WriteLine($"  DiffAera: {prop.Obj.DiffArea.m_pwszDiffAreaVolumeName} ({prop.Obj.DiffArea.m_pwszVolumeName}) {prop.Obj.DiffArea.m_llMaximumDiffSpace}:{prop.Obj.DiffArea.m_llAllocatedDiffSpace}:{prop.Obj.DiffArea.m_llUsedDiffSpace}");
							break;
						default:
							break;
					}
					prop.Dispose();
				}
			}
			catch { }
		}
	}

	[TestWhenElevated]
	public void TestBackupSnapshots()
	{
		Assert.That(VssFactory.CreateVssBackupComponents(out IVssBackupComponents backup), ResultIs.Successful);
		backup.InitializeForBackup();
		foreach (VSS_OBJECT_PROP prop in backup.Query(default, VSS_OBJECT_TYPE.VSS_OBJECT_NONE, VSS_OBJECT_TYPE.VSS_OBJECT_SNAPSHOT).Enumerate())
		{
			TestContext.WriteLine($"Snapshot: {prop.Obj.Snap.m_pwszOriginalVolumeName} ({prop.Obj.Snap.m_SnapshotId})");
			prop.Obj.Snap.Dispose();
		}
	}

	[TestWhenElevated]
	public async Task TestIssue580()
	{
		// Invoke CoInitializeSecurity to get system writer listed.
		Assert.That(CoInitializeSecurity(null, -1, null, default, Rpc.RPC_C_AUTHN_LEVEL.RPC_C_AUTHN_LEVEL_NONE, Rpc.RPC_C_IMP_LEVEL.RPC_C_IMP_LEVEL_IMPERSONATE, dwCapabilities: 0), ResultIs.Successful);

		TestContext.WriteLine("Initializing VSS Backup Components...");
		Assert.That(VssFactory.CreateVssBackupComponents(out IVssBackupComponents ppBack), ResultIs.Successful);
		TestContext.WriteLine("Successfully created IVssBackupComponents instance.");
		ppBack.InitializeForBackup(null);
		ppBack.SetBackupState(true, true, VSS_BACKUP_TYPE.VSS_BT_FULL, false);
		ppBack.SetContext(VSS_SNAPSHOT_CONTEXT.VSS_CTX_BACKUP);
		await ppBack.GatherWriterMetadata().AsTask();
		foreach (IVssExamineWriterMetadata writeMeta in ppBack.WriterMetadata)
		{
			writeMeta.GetIdentity(out var pidInstance,
					out var pidWriter,
					out var WriteName,
					out var pInstanceName,
					out var usage,
					out var source);
			TestContext.WriteLine("Get compoment for '{0}'", WriteName);

			foreach (IVssWMComponent component in writeMeta.Components)
			{
				//TestContext.WriteLine($"{DateTime.Now} start add expand path for '{WriteName}'");
				Stopwatch stopwatch = new();
				stopwatch.Start();
				for (int k = 0; k < component.Files.Count; k++)
				{
					TestContext.WriteLine($"  {component.Files[k].Path} (recursive:{component.Files[k].Recursive})");
					// DO nothing here;
					// For system writer it took very very long time.
				}
				stopwatch.Stop();
				TestContext.WriteLine($"{DateTime.Now:T} add expand path for '{WriteName}', file count:{component.Files.Count}, took:{stopwatch.Elapsed.TotalMilliseconds}ms");
			}
		}
	}
}