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
	string[] vols;

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
	}
}