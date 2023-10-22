using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Linq;
using Vanara.PInvoke.VssApi;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class VssApiTests
{
	static readonly Guid ProviderId = new("{b5946137-7b9f-4925-af80-51abd60b20d5}");
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

	[Test]
	public void QueryDiffAreasForVolumeTest()
	{
		Assert.That(vols, Has.Length.GreaterThan(0));

		IVssSnapshotMgmt imgr = new();
		var diffmgr = imgr.GetProviderMgmtInterface<IVssDifferentialSoftwareSnapshotMgmt>(ProviderId);
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

	[Test]
	public void Test()
	{
		Assert.That(VssFactory.CreateVssBackupComponents(out IVssBackupComponents vss), ResultIs.Successful);
		vss.InitializeForBackup();
	}
}