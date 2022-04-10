﻿using NUnit.Framework;
using System;
using System.Linq;
using System.Security.AccessControl;
using System.Threading;
using System.Threading.Tasks;
using Vanara.InteropServices;
using static Vanara.PInvoke.VirtDisk;

namespace Vanara.IO.Tests
{
	[TestFixture]
	public class VirtualDiskTests
	{
		private static readonly string badfn = Vanara.PInvoke.Tests.TestCaseSources.TempDirWhack + "TestInvalid.vhdx";
		private static readonly string fn = Vanara.PInvoke.Tests.TestCaseSources.VirtualDisk;
		private static readonly string tmpcfn = Vanara.PInvoke.Tests.TestCaseSources.TempDirWhack + "TestVHD - Diff.vhd";
		private static readonly string tmpfn = Vanara.PInvoke.Tests.TestCaseSources.TempDirWhack + "TestVHD.vhd";

		[Test]
		public async Task CompactAsync1Test()
		{
			using var vhd = VirtualDisk.Open(fn, false);
			var rpt = new Reporter();
			rpt.NewVal += (o, e) => TestContext.WriteLine($"{DateTime.Now:o} NewVal={e}");
			var res = await vhd.CompactAsync(default, rpt);
			Assert.That(res);
			Assert.That(rpt.lastVal, Is.EqualTo(100));
		}

		[Test]
		public async Task CompactAsync2Test()
		{
			using var vhd = VirtualDisk.Open(fn, false);
			var rpt = new Reporter();
			rpt.NewVal += (o, e) => TestContext.WriteLine($"{DateTime.Now:o} NewVal={e}");
			await vhd.CompactAsync(VirtualDisk.CompactionMode.Quick, default, rpt);
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
				while (System.IO.File.Exists(fn2))
				{
					try { System.IO.File.Delete(fn2); } catch { Thread.Sleep(500); }
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
				Assert.That(System.IO.File.Exists(tmpcfn));
				Assert.That(System.IO.File.Exists(tmpfn));
				Assert.That(System.IO.File.Exists(tmpfn));
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
				Assert.That(vhd.PhysicalSectorSize, Is.EqualTo(0x200));
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
				System.IO.File.Delete(tmpcfn);
				System.IO.File.Delete(tmpfn);
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
				Assert.That(System.IO.File.Exists(tmpfn));
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
				Assert.That(vhd.PhysicalSectorSize, Is.EqualTo(0x200));
				Assert.That(vhd.ParentIdentifier, Is.Null); // must be differencing
				Assert.That(vhd.ParentPaths, Is.Null); // must be differencing
				Assert.That(vhd.ParentTimeStamp, Is.Null); // must be differencing
				Assert.That(vhd.PhysicalPath, Is.Null); // must be attached
				Assert.That(vhd.PhysicalSectorSize, Is.EqualTo(0x200));
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
				System.IO.File.Delete(tmpfn);
			}
		}

		[Test]
		public void CreateFixedPropTest()
		{
			const int sz = 0x03010400;
			try
			{
				using var vhd = VirtualDisk.Create(tmpfn, sz, false, null);
				Assert.That(System.IO.File.Exists(tmpfn));
				Assert.That(vhd.PhysicalSize, Is.GreaterThanOrEqualTo(sz));
				Assert.That(vhd.ProviderSubtype, Is.EqualTo(VirtualDisk.Subtype.Fixed));
				Assert.That(vhd.VirtualSize, Is.EqualTo(sz));
			}
			finally
			{
				System.IO.File.Delete(tmpfn);
			}
		}

		[Test]
		public void CreateFromSourceTest()
		{
			try
			{
				using var vhd = VirtualDisk.CreateFromSource(tmpfn, fn);
				Assert.That(System.IO.File.Exists(tmpfn));
				vhd.Close();
			}
			finally
			{
				System.IO.File.Delete(tmpfn);
			}
		}

		[Test]
		public async Task CreateFromSourceAsyncTest()
		{
			VirtualDisk vd = null;
			try
			{
				var rpt = new Reporter();
				rpt.NewVal += (o, e) => TestContext.WriteLine($"{DateTime.Now:o} NewVal={e}");
				vd = await VirtualDisk.CreateFromSourceAsync(tmpfn, fn, default, rpt);
				Assert.That(rpt.lastVal, Is.EqualTo(100));
				Assert.That(System.IO.File.Exists(tmpfn));
				TestContext.WriteLine($"New file sz: {new System.IO.FileInfo(tmpfn).Length}");
			}
			finally
			{
				vd?.Close();
				try { System.IO.File.Delete(tmpfn); } catch { }
			}
		}

		[Test]
		public void DetachTest()
		{
			const int sz = 0x03010400;
			try
			{
				using (var vhd = VirtualDisk.Create(tmpfn, sz))
				{
					Assert.That(vhd.Attached, Is.False);
					vhd.Attach(true, false, true, null);
					Assert.That(vhd.Attached, Is.True);
				}
				Assert.That(VirtualDisk.IsAttached(tmpfn), Is.True);
				Assert.That(() => VirtualDisk.Detach(tmpfn), Throws.Nothing);
				Assert.That(VirtualDisk.IsAttached(tmpfn), Is.False);
			}
			finally
			{
				System.IO.File.Delete(tmpfn);
			}
		}

		[Test]
		public void ExpandTest()
		{
			const int sz = 0x810400;
			try
			{
				using var vhd = VirtualDisk.Create(tmpfn, sz, true, null);
				Assert.That(System.IO.File.Exists(tmpfn));
				Assert.That(vhd.VirtualSize, Is.EqualTo(sz));
				vhd.Expand(sz * 2);
				Assert.That(vhd.VirtualSize, Is.EqualTo(sz * 2));
			}
			finally
			{
				System.IO.File.Delete(tmpfn);
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
				System.IO.File.Delete(lfn);
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
				System.IO.File.Delete(lfn);
			}
		}

		[Test]
		public void MergeTest()
		{
			const int sz = 0x03010400;
			try
			{
				using (var vhdp = VirtualDisk.Create(tmpfn, sz))
					Assert.That(System.IO.File.Exists(tmpfn));
				using var vhd = VirtualDisk.CreateDifferencing(tmpcfn, tmpfn);
				Assert.That(System.IO.File.Exists(tmpcfn));
				vhd.Merge(1, 2);
			}
			finally
			{
				System.IO.File.Delete(tmpcfn);
				System.IO.File.Delete(tmpfn);
			}
		}

		[Test]
		public void MergeWithParentTest()
		{
			const int sz = 0x03010400;
			try
			{
				using (var vhdp = VirtualDisk.Create(tmpfn, sz))
					Assert.That(System.IO.File.Exists(tmpfn));
				using var vhd = VirtualDisk.CreateDifferencing(tmpcfn, tmpfn);
				Assert.That(System.IO.File.Exists(tmpcfn));
				vhd.MergeWithParent();
			}
			finally
			{
				System.IO.File.Delete(tmpcfn);
				System.IO.File.Delete(tmpfn);
			}
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
			try
			{
				using var vhd = VirtualDisk.Open(fn, true);
				Assert.That(vhd.Attached, Is.False);
				vhd.Attach(true, true, false, GetWorldFullFileSecurity());
				Assert.That(vhd.Attached, Is.True);
				TestContext.WriteLine(vhd.PhysicalPath);
				Assert.That(vhd.PhysicalPath, Is.Not.Null); // must be attached
				vhd.Detach();
				Assert.That(vhd.Attached, Is.False);
				vhd.Attach();
				Assert.That(vhd.Attached, Is.True);
				vhd.Close();
				Assert.That(vhd.Attached, Is.False);
			}
			finally
			{
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
				Assert.That(System.IO.File.Exists(tmpfn));
				Assert.That(vhd.VirtualSize, Is.EqualTo(sz));
				vhd.Resize(sz * 2);
				Assert.That(vhd.VirtualSize, Is.EqualTo(sz * 2));
			}
			finally
			{
				System.IO.File.Delete(tmpfn);
			}
		}

		[Test]
		public void UnsafeResizeTest()
		{
			const int sz = 0x810400;
			try
			{
				using var vhd = VirtualDisk.Create(tmpfn, sz * 2, true, null);
				Assert.That(System.IO.File.Exists(tmpfn));
				Assert.That(vhd.VirtualSize, Is.EqualTo(sz * 2));
				Assert.That(() => vhd.UnsafeResize(sz), Throws.Exception);
			}
			finally
			{
				System.IO.File.Delete(tmpfn);
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

		private static FileSecurity GetFileSecurity(string sddl)
		{
			var sd = new FileSecurity();
			sd.SetSecurityDescriptorSddlForm(sddl);
			return sd;
		}

		private static FileSecurity GetWorldFullFileSecurity() => GetFileSecurity("O:BAG:BAD:(A;;GA;;;WD)");

		private class Reporter : IProgress<int>
		{
			public event EventHandler<int> NewVal;

			public int lastVal { get; private set; }

			public void Report(int value)
			{
				lastVal = value;
				NewVal?.Invoke(this, value);
			}
		}
	}
}