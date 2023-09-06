using NUnit.Framework;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Threading;
using System.Threading.Tasks;
using Vanara.PInvoke.Tests;
using static Vanara.PInvoke.Kernel32;
using static Vanara.PInvoke.VirtDisk;

namespace Vanara.IO.Tests;

[TestFixture]
public class VirtualDiskTests
{
	private static readonly string badfn = TestCaseSources.TempDirWhack + "TestInvalid.vhdx";
	private static readonly string fn = TestCaseSources.VirtualDisk;
	private static readonly string tmpcfn = TestCaseSources.TempDirWhack + "TestVHD - Diff.vhd";
	private static readonly string tmpfn = TestCaseSources.TempDirWhack + "TestVHD.vhd";

	[Test]
	public async Task CompactAsyncTest()
	{
		using var vhd = VirtualDisk.Open(fn, false);
		var rpt = new Reporter();
		rpt.NewVal += (o, e) => TestContext.WriteLine($"{DateTime.Now:o} NewVal={e}");
		var res = await vhd.CompactAsync(default, rpt);
		Assert.That(res);
		Assert.That(rpt.lastVal, Is.EqualTo(100));
	}

	[Test]
	public async Task CompactAsyncMMITest()
	{
		using var vhd = VirtualDisk.Open(fn, false);
		var rpt = new Reporter();
		rpt.NewVal += (o, e) => TestContext.WriteLine($"{DateTime.Now:o} NewVal={e}");
		await vhd.CompactAsync(VirtualDisk.CompactionMode.Full, default, rpt);
		Assert.That(rpt.lastVal, Is.EqualTo(100));
	}

	[Test]
	public void CompactTest()
	{
		using var vhd = VirtualDisk.Open(fn, false);
		Assert.That(() => vhd.Compact(), Throws.Nothing);
	}

	[Test]
	public async Task ConvertTest()
	{
		try
		{
			var rpt = new Reporter();
			rpt.NewVal += (o, e) => TestContext.WriteLine($"{DateTime.Now:o} NewVal={e}");
			await VirtualDisk.ConvertAsync(fn, VirtualDisk.DeviceType.Vhd, default, rpt);
			Assert.That(rpt.lastVal, Is.EqualTo(100));
		}
		finally
		{
			var fn2 = fn.TrimEnd('x');
			while (File.Exists(fn2))
			{
				try { File.Delete(fn2); } catch { Thread.Sleep(500); }
			}
		}
	}

	[Test]
	public void CreateDiffTest()
	{
		const int sz = 0x03010400;
		try
		{
			using var vhdp = VirtualDisk.Create(tmpfn, sz);
			using var vhd = VirtualDisk.CreateDifferencing(tmpcfn, tmpfn);
			Assert.That(File.Exists(tmpcfn));
			Assert.That(File.Exists(tmpfn));
			Assert.That(File.Exists(tmpfn));
			Assert.That(vhd.Attached, Is.False);
			Assert.That(vhd.BlockSize, Is.EqualTo(0x200000));
			Assert.That(vhd.DiskType, Is.EqualTo(VirtualDisk.DeviceType.Vhd));
			Assert.That(vhd.FragmentationPercentage, Is.Null); // must be non-differencing
			Assert.That(vhd.Identifier, Is.Not.EqualTo(Guid.Empty));
			Assert.That(vhd.ImagePath, Is.EqualTo(tmpcfn));
			Assert.That(vhd.Is4kAligned);
			Assert.That(vhd.IsChild, Is.True);
			Assert.That(vhd.IsLoaded, Is.False);
			Assert.That(vhd.IsRemote, Is.False);
			Assert.That(vhd.LogicalSectorSize, Is.EqualTo(0x200));
			Assert.That(vhd.MostRecentId, Is.Null.Or.Empty);
			Assert.That(vhd.NewerChanges, Is.False);
			Assert.That(vhd.ParentBackingStore, Is.EqualTo(tmpfn)); // must be differencing
			Assert.That(vhd.ParentIdentifier, Is.Not.Null); // must be differencing
			Assert.That(vhd.ParentPaths, Is.Not.Null.And.Length.EqualTo(1)); // must be differencing
			Assert.That(vhd.ParentTimeStamp, Is.Not.Null); // must be differencing
			Assert.That(vhd.PhysicalPath, Is.Null); // must be attached
			Assert.That(vhd.PhysicalSectorSize, Is.EqualTo(0x1000));
			Assert.That(vhd.PhysicalSize, Is.LessThan(sz));
			Assert.That(vhd.ProviderSubtype, Is.EqualTo(VirtualDisk.Subtype.Differencing));
			Assert.That(vhd.ResilientChangeTrackingEnabled, Is.False);
			Assert.That(vhd.SectorSize, Is.EqualTo(0x200));
			Assert.That(vhd.SmallestSafeVirtualSize, Is.Null); // must have file system
			Assert.That(vhd.VendorId, Is.Not.EqualTo(Guid.Empty));
			Assert.That(vhd.VhdPhysicalSectorSize, Is.EqualTo(0x200));
			Assert.That(vhd.VirtualDiskId, Is.Not.EqualTo(Guid.Empty));
			Assert.That(vhd.VirtualSize, Is.EqualTo(sz));
		}
		finally
		{
			File.Delete(tmpcfn);
			File.Delete(tmpfn);
		}
	}

	[Test]
	public void CreateDynPropTest()
	{
		const int sz = 0x03010200;
		try
		{
			using var vhd = VirtualDisk.Create(tmpfn, sz);
			//vhd.Attach(true);
			Assert.That(File.Exists(tmpfn));
			Assert.That(vhd.Attached, Is.False);
			Assert.That(vhd.BlockSize, Is.GreaterThan(0));
			Assert.That(vhd.DiskType, Is.EqualTo(VirtualDisk.DeviceType.Vhd));
			Assert.That(vhd.ResilientChangeTrackingEnabled, Is.False);
			Assert.That(vhd.FragmentationPercentage, Is.Zero);
			Assert.That(vhd.Identifier, Is.Not.EqualTo(Guid.Empty));
			Assert.That(vhd.Is4kAligned);
			Assert.That(vhd.IsLoaded, Is.False);
			Assert.That(vhd.IsRemote, Is.False);
			Assert.That(vhd.LogicalSectorSize, Is.EqualTo(0x200));
			Assert.That(vhd.MostRecentId, Is.Null.Or.Empty);
			Assert.That(vhd.NewerChanges, Is.False);
			Assert.That(vhd.ParentBackingStore, Is.Null); // must be attached
			Assert.That(vhd.ParentIdentifier, Is.Null); // must be differencing
			Assert.That(vhd.ParentPaths, Is.Null); // must be differencing
			Assert.That(vhd.ParentTimeStamp, Is.Null); // must be differencing
			Assert.That(vhd.PhysicalPath, Is.Null); // must be attached
			Assert.That(vhd.PhysicalSectorSize, Is.EqualTo(0x1000));
			Assert.That(vhd.PhysicalSize, Is.LessThan(sz));
			Assert.That(vhd.ProviderSubtype, Is.EqualTo(VirtualDisk.Subtype.Dynamic));
			Assert.That(vhd.SectorSize, Is.EqualTo(0x200));
			Assert.That(vhd.SmallestSafeVirtualSize, Is.Null); // must have file system
			Assert.That(vhd.VendorId, Is.Not.EqualTo(Guid.Empty));
			Assert.That(vhd.VhdPhysicalSectorSize, Is.EqualTo(0x200));
			Assert.That(vhd.VirtualDiskId, Is.Not.EqualTo(Guid.Empty));
			Assert.That(vhd.VirtualSize, Is.EqualTo(sz));
		}
		finally
		{
			File.Delete(tmpfn);
		}
	}

	[Test]
	public void CreateFixedPropTest()
	{
		const int sz = 0x03010400;
		try
		{
			using var vhd = VirtualDisk.Create(tmpfn, sz, false, null);
			Assert.That(File.Exists(tmpfn));
			Assert.That(vhd.PhysicalSize, Is.GreaterThanOrEqualTo(sz));
			Assert.That(vhd.ProviderSubtype, Is.EqualTo(VirtualDisk.Subtype.Fixed));
			Assert.That(vhd.VirtualSize, Is.EqualTo(sz));
		}
		finally
		{
			File.Delete(tmpfn);
		}
	}

	[Test]
	public async Task CreateFromSourceAsyncTest()
	{
		VirtualDisk? vd = null;
		try
		{
			var rpt = new Reporter();
			rpt.NewVal += (o, e) => TestContext.WriteLine($"{DateTime.Now:o} NewVal={e}");
			vd = await VirtualDisk.CreateFromSourceAsync(tmpfn, fn, default, rpt);
			Assert.That(rpt.lastVal, Is.EqualTo(100));
			Assert.That(File.Exists(tmpfn));
			TestContext.WriteLine($"New file sz: {new FileInfo(tmpfn).Length}");
		}
		finally
		{
			vd?.Close();
			try { File.Delete(tmpfn); } catch { }
		}
	}

	[Test]
	public void CreateFromSourceTest()
	{
		try
		{
			using var vhd = VirtualDisk.CreateFromSource(tmpfn, fn);
			Assert.That(File.Exists(tmpfn));
			vhd.Close();
		}
		finally
		{
			File.Delete(tmpfn);
		}
	}

	[Test]
	public void ExpandTest()
	{
		const int sz = 0x810400;
		try
		{
			using var vhd = VirtualDisk.Create(tmpfn, sz, true, null);
			Assert.That(File.Exists(tmpfn));
			Assert.That(vhd.VirtualSize, Is.EqualTo(sz));
			vhd.Expand(sz * 2);
			Assert.That(vhd.VirtualSize, Is.EqualTo(sz * 2));
		}
		finally
		{
			File.Delete(tmpfn);
		}
	}

	[Test]
	public void GetAllAttachedVirtualDiskPathsTest()
	{
		Assert.That(() => VirtualDisk.GetAllAttachedVirtualDiskPaths(), Throws.Nothing);
		using var vhd = VirtualDisk.Open(fn, true);
		vhd.Attach();
		Assert.That(VirtualDisk.GetAllAttachedVirtualDiskPaths(), Has.Some.EqualTo(fn));
	}

	[Test]
	public void GetSetMetadataTest()
	{
		const int sz = 0x03010200;
		var lfn = tmpfn + "x";
		try
		{
			using var vhd = VirtualDisk.Create(lfn, sz);
			var count = 0;
			Assert.That(() => count = vhd.Metadata.Count, Throws.Nothing);

			// Try get and set
			var guid = Guid.NewGuid();
			Assert.That(() => vhd.Metadata.Add(guid, new SafeCoTaskMemHandle("Testing")), Throws.Nothing);
			Assert.That(vhd.Metadata.Count, Is.EqualTo(count + 1));
			Assert.That(vhd.Metadata.ContainsKey(Guid.NewGuid()), Is.False);
			Assert.That(vhd.Metadata.TryGetValue(guid, out SafeCoTaskMemHandle mem), Is.True);
			Assert.That(mem.ToString(-1), Is.EqualTo("Testing"));

			// Try enumerate and get
			foreach (System.Collections.Generic.KeyValuePair<Guid, SafeCoTaskMemHandle> mkv in vhd.Metadata)
			{
				Assert.That(mkv.Key, Is.Not.EqualTo(Guid.Empty));
				Assert.That(mkv.Value.Size, Is.Not.Zero);
				TestContext.WriteLine($"{mkv.Key}={mkv.Value.Size}b:{mkv.Value.ToString(-1)}");
			}

			// Try remove
			Assert.That(vhd.Metadata.Remove(guid), Is.True);
			Assert.That(vhd.Metadata.TryGetValue(guid, out mem), Is.False);
			Assert.That(vhd.Metadata.Count, Is.EqualTo(count));
		}
		finally
		{
			File.Delete(lfn);
		}
	}

	[Test]
	public void GetSetPropTest()
	{
		const int sz = 0x03010200;
		var lfn = tmpfn + "x";
		try
		{
			using var vhd = VirtualDisk.Create(lfn, sz);
			var b = vhd.ResilientChangeTrackingEnabled;
			Assert.That(() => vhd.ResilientChangeTrackingEnabled = !b, Throws.Nothing);
			Assert.AreEqual(!b, vhd.ResilientChangeTrackingEnabled);
		}
		finally
		{
			File.Delete(lfn);
		}
	}

	[Test]
	public async Task GetVHDSetInformationTestAsync()
	{
		var newfn = tmpfn + "s";
		try
		{
			using VirtualDisk vhd = await MakeSet();
			VirtualDiskSetInformation? si = default;
			Assert.That(() => si = vhd.GetVHDSetInformation(), Throws.Nothing);
			Assert.That(si?.Path, Is.Not.Null);
			vhd.Close();
			foreach (FileInfo a in si!.AllPaths!.Select(s => new FileInfo(Path.Combine(Path.GetDirectoryName(newfn)!, s))).OrderByDescending(f => f.CreationTime))
				//await VirtualDisk.MergeAsync(a.FullName, newfn);
				File.Delete(a.FullName);
		}
		finally
		{
			File.Delete(newfn);
		}
	}

	private async Task<VirtualDisk> MakeSet()
	{
		var newfn = tmpfn + "x";
		File.Copy(fn, newfn);
		try
		{
			await VirtualDisk.ConvertToVHDSetAsync(newfn);
			Assert.That(File.Exists(tmpfn + "s"));
			return VirtualDisk.Open(tmpfn + "s", false);
		}
		finally
		{
			File.Delete(newfn);
		}
	}

	[Test]
	public void MergeTest()
	{
		const int sz = 0x03010400;
		try
		{
			using (var vhdp = VirtualDisk.Create(tmpfn, sz))
				Assert.That(File.Exists(tmpfn));
			using var vhd = VirtualDisk.CreateDifferencing(tmpcfn, tmpfn);
			Assert.That(File.Exists(tmpcfn));
			vhd.Merge(1, 2);
		}
		finally
		{
			File.Delete(tmpcfn);
			File.Delete(tmpfn);
		}
	}

	[Test]
	public void MergeWithParentTest()
	{
		const int sz = 0x03010400;
		try
		{
			using (var vhdp = VirtualDisk.Create(tmpfn, sz))
				Assert.That(File.Exists(tmpfn));
			using var vhd = VirtualDisk.CreateDifferencing(tmpcfn, tmpfn);
			Assert.That(File.Exists(tmpcfn));
			vhd.MergeWithParent();
		}
		finally
		{
			File.Delete(tmpcfn);
			File.Delete(tmpfn);
		}
	}

	[Test]
	public void MirrorTestAsync()
	{
		var mvhd = TestCaseSources.TempDirWhack + "mirror.vhdx";
		using (var vhd = VirtualDisk.Open(fn, true))
		{
			vhd.MirrorAsync(mvhd).Wait();
			Assert.That(File.Exists(mvhd));
			vhd.BreakMirror();
		}
		Task.Delay(500);
		File.Delete(mvhd);
	}

	[Test]
	public void OpenAttachRawTest()
	{
		try
		{
			var param = new OPEN_VIRTUAL_DISK_PARAMETERS(false);
			using var vhd = VirtualDisk.Open(fn, OPEN_VIRTUAL_DISK_FLAG.OPEN_VIRTUAL_DISK_FLAG_NONE, param, VIRTUAL_DISK_ACCESS_MASK.VIRTUAL_DISK_ACCESS_NONE);
			Assert.That(vhd.Attached, Is.False);
			ATTACH_VIRTUAL_DISK_FLAG flags = ATTACH_VIRTUAL_DISK_FLAG.ATTACH_VIRTUAL_DISK_FLAG_READ_ONLY | ATTACH_VIRTUAL_DISK_FLAG.ATTACH_VIRTUAL_DISK_FLAG_NO_SECURITY_DESCRIPTOR;
			vhd.Attach(flags);
			Assert.That(vhd.Attached, Is.True);
			vhd.Detach();
			Assert.That(vhd.Attached, Is.False);
		}
		finally
		{
		}
	}

	[Test]
	public void OpenAttachTest()
	{
		using var vhd = VirtualDisk.Open(fn, true);
		Assert.That(vhd.Attached, Is.False);
		var beforeDrives = GetLogicalDrives();
		vhd.Attach(new[] { "T:\\" }, true, true, GetWorldFullFileSecurity());
		Assert.That(vhd.Attached, Is.True);
		Assert.That(beforeDrives, Is.Not.EqualTo(GetLogicalDrives()));
		TestContext.WriteLine(vhd.PhysicalPath);
		if (vhd.VolumeGuidPaths is not null) TestContext.WriteLine(string.Join(";", vhd.VolumeGuidPaths));
		if (vhd.VolumeMountPoints is not null) TestContext.WriteLine(string.Join(";", vhd.VolumeMountPoints));
		Assert.That(vhd.PhysicalPath, Is.Not.Null); // must be attached
		vhd.Detach();
		Assert.That(vhd.Attached, Is.False);
		vhd.Attach(true, true, true);
		Assert.That(vhd.Attached, Is.True);
		Assert.That(beforeDrives, Is.EqualTo(GetLogicalDrives()));
		vhd.Close();
		Assert.That(vhd.Attached, Is.False);
	}

	/*[Test]
	public void SetSnapshotInformationAsyncTest()
	{
		var vhd = MakeSet().Result;
		var newfn = vhd.ImagePath;
		vhd.Dispose();
		try
		{
			VirtualDisk.SetSnapshotInformationAsync(new VirtualDiskSnapshotInformation(newfn, Guid.NewGuid())).Wait();
		}
		finally
		{
			File.Delete(newfn);
		}
	}*/

	// [Test] Don't know how to create a file that shows query changes
	public void QueryChangesTest()
	{
		using var vhd = MakeSet().Result;
		var newfn = vhd.ImagePath;
		try
		{
			vhd.ResilientChangeTrackingEnabled = true;
			vhd.TakeSnapshot(Guid.NewGuid(), true);
			QUERY_CHANGES_VIRTUAL_DISK_RANGE[] chgs = vhd.QueryChanges("rctX:e59e6991:208a:44d9:ae6a:2f14351d792f:00000000");
		}
		finally
		{
			vhd.Dispose();
			File.Delete(newfn);
		}
	}

	[Test]
	public async Task ResizeAsync1Test()
	{
		using var vhd = VirtualDisk.Open(fn, false);
		var rpt = new Reporter();
		rpt.NewVal += (o, e) => TestContext.WriteLine($"{DateTime.Now:o} NewVal={e}");
		var res = await vhd.ResizeAsync(vhd.VirtualSize + 1024, default, rpt);
		Assert.That(res);
		Assert.That(rpt.lastVal, Is.EqualTo(100));
	}

	[Test]
	public void ResizeTest()
	{
		const int sz = 0x810400;
		try
		{
			using var vhd = VirtualDisk.Create(tmpfn, sz, true, null);
			Assert.That(File.Exists(tmpfn));
			Assert.That(vhd.VirtualSize, Is.EqualTo(sz));
			vhd.Resize(sz * 2);
			Assert.That(vhd.VirtualSize, Is.EqualTo(sz * 2));
		}
		finally
		{
			File.Delete(tmpfn);
		}
	}

	[Test]
	public async Task SnapshotTest()
	{
		VirtualDisk vhd = await MakeSet();
		var newfn = vhd.ImagePath;
		try
		{
			var id = Guid.NewGuid();
			vhd.TakeSnapshot(id);
			vhd.DeleteSnapshot(id);
		}
		finally
		{
			vhd?.Dispose();
			File.Delete(newfn);
		}
	}

	/*[Test]
	public void GetSnapshotInformationTest()
	{
		var vhd = MakeSet().Result;
		var newfn = vhd.ImagePath;
		try
		{
			var id = Guid.NewGuid();
			vhd.TakeSnapshot(id);
			vhd.Dispose();
			vhd = null;
			var si = VirtualDisk.GetSnapshotInformation(newfn, id);
			Assert.That(si.FilePath, Is.Not.Null);
		}
		finally
		{
			vhd?.Dispose();
			File.Delete(newfn);
		}
	}*/

	[Test]
	public void UnsafeResizeTest()
	{
		const int sz = 0x810400;
		try
		{
			using var vhd = VirtualDisk.Create(tmpfn, sz * 2, true, null);
			Assert.That(File.Exists(tmpfn));
			Assert.That(vhd.VirtualSize, Is.EqualTo(sz * 2));
			Assert.That(() => vhd.UnsafeResize(sz), Throws.Exception);
		}
		finally
		{
			File.Delete(tmpfn);
		}
	}

	[Test]
	public async Task ValidateTest()
	{
		var rpt = new Reporter();
		rpt.NewVal += (o, e) => TestContext.WriteLine($"{DateTime.Now:o} NewVal={e}");
		var res = await VirtualDisk.ValidateAsync(fn, CancellationToken.None, rpt);
		Assert.That(rpt.lastVal, Is.EqualTo(100));
		Assert.That(res);

		res = await VirtualDisk.ValidateAsync(badfn, CancellationToken.None, rpt);
		Assert.That(!res);
	}

	[Test]
	public void ValidatePersistentReservationSupportTest()
	{
		Assert.That(VirtualDisk.ValidatePersistentReservationSupport(fn), Is.False);
	}

	private static FileSecurity GetFileSecurity(string sddl)
	{
		var sd = new FileSecurity();
		sd.SetSecurityDescriptorSddlForm(sddl);
		return sd;
	}

	private static FileSecurity GetWorldFullFileSecurity() => GetFileSecurity("O:BAG:BAD:(A;;GA;;;WD)");

	private class Reporter : IProgress<int>
	{
		public event EventHandler<int>? NewVal;

		public int lastVal { get; private set; }

		public void Report(int value)
		{
			lastVal = value;
			NewVal?.Invoke(this, value);
		}
	}
}