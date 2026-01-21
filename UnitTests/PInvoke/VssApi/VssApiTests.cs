using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Linq;
using System.Threading;
using Vanara.PInvoke.VssApi;
using static Vanara.PInvoke.Kernel32;

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
	public void _Setup()
	{
		vols = EnumVolumes().ToArray();
	}

	[OneTimeTearDown]
	public void _TearDown()
	{
	}

	[TestWhenElevated]
	public void OpenStreamOnVSSCopy()
	{
		Assert.That(VssFactory.CreateVssBackupComponents(out IVssBackupComponents backup), ResultIs.Successful);
		backup.InitializeForBackup();
		backup.GatherWriterMetadata();
		backup.FreeWriterMetadata();
		backup.SetBackupState(false, true, VSS_BACKUP_TYPE.VSS_BT_FULL, false);
		var setId = backup.StartSnapshotSet();
		try
		{
			Assert.That(backup.IsVolumeSupported(default, "C:\\"), Is.True);
			var snapId = backup.AddToSnapshotSet("C:\\");
			var props = backup.GetSnapshotProperties(snapId);
			TestContext.WriteLine(props.m_pwszSnapshotDeviceObject);
			props.Dispose();
		}
		finally
		{
			HRESULT hr = backup.DeleteSnapshots(setId, VSS_OBJECT_TYPE.VSS_OBJECT_SNAPSHOT_SET, true, out _, out var badId);
			if (hr.Failed)
				TestContext.WriteLine($"Failed to delete snapshot {badId}");
		}
		_ = backup.PrepareForBackup();
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
}