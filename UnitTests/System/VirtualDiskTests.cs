using NUnit.Framework;
using System;
using System.Security.AccessControl;
using System.Threading;
using System.Threading.Tasks;
using Vanara.InteropServices;
using Vanara.IO;
using Vanara.PInvoke;
using static Vanara.PInvoke.AdvApi32;
using static Vanara.PInvoke.VirtDisk;

namespace Vanara.IO.Tests
{
	[TestFixture()]
	public class VirtualDiskTests
	{
		const string tmpfn = @"C:\Temp\TestVHD.vhd";
		const string tmpcfn = @"C:\Temp\TestVHD-Diff.vhd";
		const string fn = @"C:\Users\dahall\VirtualBox VMs\Windows Client\Windows XP Pro\Windows XP Pro.vhd";

		[Test()]
		public void CreateDynPropTest()
		{
			const int sz = 0x03010200;
			try
			{
				using (var vhd = VirtualDisk.Create(tmpfn, sz))
				//using (var pv = new PrivilegedCodeBlock(SystemPrivilege.ManageVolume))
				{
					//vhd.Attach(true);
					Assert.That(System.IO.File.Exists(tmpfn));
					Assert.That(vhd.Attached, Is.False);
					Assert.That(vhd.BlockSize, Is.EqualTo(0x200000));
					Assert.That(vhd.DiskType, Is.EqualTo(VirtualDisk.DeviceType.Vhd));
					Assert.That(vhd.Enabled, Is.False);
					Assert.That(vhd.FragmentationPercentage, Is.Zero);
					Assert.That(vhd.Identifier, Is.Not.EqualTo(Guid.Empty));
					Assert.That(vhd.Is4kAligned);
					Assert.That(vhd.IsLoaded, Is.False);
					Assert.That(vhd.IsRemote, Is.False);
					Assert.That(vhd.LogicalSectorSize, Is.EqualTo(0x200));
					Assert.That(vhd.MostRecentId, Is.Null.Or.Empty);
					Assert.That(vhd.NewerChanges, Is.False);
					//Debug.WriteLine(vhd.ParentBackingStore); // must be differencing
					//Debug.WriteLine(vhd.ParentIdentifier); // must be differencing
					//Debug.WriteLine(vhd.ParentPaths); // must be differencing
					//Debug.WriteLine(vhd.ParentTimeStamp); // must be differencing
					//Debug.WriteLine(vhd.PhysicalPath); // must be attached
					Assert.That(vhd.PhysicalSectorSize, Is.EqualTo(0x200));
					Assert.That(vhd.PhysicalSize, Is.LessThan(sz));
					Assert.That(vhd.ProviderSubtype, Is.EqualTo(VirtualDisk.Subtype.Dynamic));
					Assert.That(vhd.SectorSize, Is.EqualTo(0x200));
					//Debug.WriteLine(vhd.SmallestSafeVirtualSize); // must have file system
					Assert.That(vhd.VendorId, Is.Not.EqualTo(Guid.Empty));
					Assert.That(vhd.VhdPhysicalSectorSize, Is.EqualTo(0x200));
					Assert.That(vhd.VirtualDiskId, Is.Not.EqualTo(Guid.Empty));
					Assert.That(vhd.VirtualSize, Is.EqualTo(sz));
				}
			}
			finally
			{
				System.IO.File.Delete(tmpfn);
			}
		}

		[Test()]
		public void CreateFromSourceTest()
		{
			try
			{
				using (var vhd = VirtualDisk.CreateFromSource(tmpfn, fn))
				{
					Assert.That(System.IO.File.Exists(tmpfn));
				}
			}
			finally
			{
				System.IO.File.Delete(tmpfn);
			}
		}

		[Test()]
		public async Task CreateFromSourceTest1()
		{
			VirtualDisk h = null;
			try
			{
				var cts = new CancellationTokenSource();
				var rpt = new Reporter();
				var lastVal = 0;
				rpt.NewVal += (o, e) => TestContext.WriteLine($"{DateTime.Now:o} NewVal={lastVal = e}");
				h = await VirtualDisk.CreateFromSource(tmpfn, fn, cts.Token, rpt);
				Assert.That(lastVal, Is.EqualTo(100));
				Assert.That(System.IO.File.Exists(tmpfn));
				TestContext.WriteLine($"New file sz: {new System.IO.FileInfo(tmpfn).Length}");
			}
			finally
			{
				h?.Close();
				System.IO.File.Delete(tmpfn);
			}
		}

		[Test()]
		public void CreateFixedPropTest()
		{
			const int sz = 0x03010400;
			try
			{
				using (var vhd = VirtualDisk.Create(tmpfn, sz, false, null))
				{
					Assert.That(System.IO.File.Exists(tmpfn));
					Assert.That(vhd.PhysicalSize, Is.EqualTo(sz + 512));
					Assert.That(vhd.ProviderSubtype, Is.EqualTo(VirtualDisk.Subtype.Fixed));
					Assert.That(vhd.VirtualSize, Is.EqualTo(sz));
				}
			}
			finally
			{
				System.IO.File.Delete(tmpfn);
			}
		}

		[Test()]
		public void CreateDiffTest()
		{
			const int sz = 0x03010400;
			try
			{
				using (var vhdp = VirtualDisk.Create(tmpfn, sz))
				using (var vhd = VirtualDisk.CreateDifferencing(tmpcfn, tmpfn))
				{
					Assert.That(System.IO.File.Exists(tmpcfn));
					Assert.That(System.IO.File.Exists(tmpfn));
					Assert.That(System.IO.File.Exists(tmpfn));
					Assert.That(vhd.Attached, Is.False);
					Assert.That(vhd.BlockSize, Is.EqualTo(0x200000));
					Assert.That(vhd.DiskType, Is.EqualTo(VirtualDisk.DeviceType.Vhd));
					Assert.That(vhd.Enabled, Is.False);
					//Assert.That(vhd.FragmentationPercentage, Is.Zero); // must be non-differencing
					Assert.That(vhd.Identifier, Is.Not.EqualTo(Guid.Empty));
					Assert.That(vhd.Is4kAligned);
					Assert.That(vhd.IsLoaded, Is.False);
					Assert.That(vhd.IsRemote, Is.False);
					Assert.That(vhd.LogicalSectorSize, Is.EqualTo(0x200));
					//Assert.That(vhd.MostRecentId, Is.Null.Or.Empty);
					Assert.That(vhd.NewerChanges, Is.False);
					Assert.That(vhd.ParentBackingStore, Is.EqualTo(tmpfn)); // must be differencing
					Assert.That(vhd.ParentIdentifier, Is.Not.EqualTo(Guid.Empty)); // must be differencing
					Assert.That(vhd.ParentPaths, Is.Null); // must be differencing
					Assert.That(vhd.ParentTimeStamp, Is.Zero); // must be differencing
					//TestContext.WriteLine(vhd.PhysicalPath); // must be attached
					Assert.That(vhd.PhysicalSectorSize, Is.EqualTo(0x200));
					Assert.That(vhd.PhysicalSize, Is.LessThan(sz));
					Assert.That(vhd.ProviderSubtype, Is.EqualTo(VirtualDisk.Subtype.Differencing));
					Assert.That(vhd.SectorSize, Is.EqualTo(0x200));
					//Debug.WriteLine(vhd.SmallestSafeVirtualSize); // must have file system
					Assert.That(vhd.VendorId, Is.Not.EqualTo(Guid.Empty));
					Assert.That(vhd.VhdPhysicalSectorSize, Is.EqualTo(0x200));
					Assert.That(vhd.VirtualDiskId, Is.Not.EqualTo(Guid.Empty));
					Assert.That(vhd.VirtualSize, Is.EqualTo(sz));
				}
			}
			finally
			{
				System.IO.File.Delete(tmpcfn);
				System.IO.File.Delete(tmpfn);
			}
		}

		[Test()]
		public void OpenAttachRawTest()
		{
			try
			{
				var param = new OPEN_VIRTUAL_DISK_PARAMETERS(false);
				using (var vhd = VirtualDisk.Open(fn, OPEN_VIRTUAL_DISK_FLAG.OPEN_VIRTUAL_DISK_FLAG_NONE, param, VIRTUAL_DISK_ACCESS_MASK.VIRTUAL_DISK_ACCESS_NONE))
				{
					Assert.That(vhd.Attached, Is.False);
					var flags = ATTACH_VIRTUAL_DISK_FLAG.ATTACH_VIRTUAL_DISK_FLAG_READ_ONLY;
					var aparam = ATTACH_VIRTUAL_DISK_PARAMETERS.Default;
					if (!ConvertStringSecurityDescriptorToSecurityDescriptor("O:BAG:BAD:(A;;GA;;;WD)", SDDL_REVISION.SDDL_REVISION_1, out SafeHGlobalHandle sd, out uint hLen))
						Win32Error.ThrowLastError();
					vhd.Attach(flags, ref aparam, (IntPtr)sd);
					Assert.That(vhd.Attached, Is.True);
					vhd.Detach();
					Assert.That(vhd.Attached, Is.False);
				}
			}
			finally
			{
			}
		}

		private static FileSecurity GetFileSecurity(string sddl)
		{
			var sd = new FileSecurity();
			sd.SetSecurityDescriptorSddlForm(sddl);
			return sd;
		}

		private static FileSecurity GetWorldFullFileSecurity() => GetFileSecurity("O:BAG:BAD:(A;;GA;;;WD)");

		[Test()]
		public void OpenAttachTest()
		{
			try
			{
				using (var vhd = VirtualDisk.Open(fn))
				{
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
			}
			finally
			{
			}
		}

		[Test]
		public void GetSetMetadataTest()
		{
			const int sz = 0x03010200;
			var lfn = tmpfn + "x";
			try
			{
				using (var vhd = VirtualDisk.Create(lfn, sz))
				{
					vhd.Attach(true, true, false, GetWorldFullFileSecurity());

					// Try enumerate and get
					foreach (var mkv in vhd.Metadata)
					{
						Assert.That(mkv.Key, Is.Not.EqualTo(Guid.Empty));
						Assert.That(mkv.Value.Size, Is.Not.Zero);
						TestContext.WriteLine($"{mkv.Key}={mkv.Value.Size}b:{mkv.Value.ToString(-1)}");
					}

					// Try set and remove
					var guid = Guid.NewGuid();
					Assert.That(() => vhd.Metadata.Add(guid, new SafeCoTaskMemHandle("Testing")), Throws.Nothing);
					Assert.That(vhd.Metadata.TryGetValue(Guid.NewGuid(), out SafeCoTaskMemHandle mem), Is.False);
					Assert.That(vhd.Metadata.TryGetValue(guid, out mem), Is.True);
					Assert.That(mem.ToString(-1), Is.EqualTo("Testing"));
					Assert.That(vhd.Metadata.Remove(guid), Is.True);
					Assert.That(vhd.Metadata.TryGetValue(guid, out mem), Is.False);
				}
			}
			finally
			{
				System.IO.File.Delete(lfn);
			}
		}

		//[Test()]
		public void DetachTest()
		{
			const int sz = 0x03010400;
			try
			{
				using (var vhd = VirtualDisk.Create(tmpfn, sz))
				{
					Assert.That(vhd.Attached, Is.False);
					vhd.Attach(false, false);
					Assert.That(vhd.Attached, Is.False);
				}
				Assert.That(VirtualDisk.GetAllAttachedVirtualDiskPaths(), Has.Some.EqualTo(tmpfn));
				Assert.That(() => VirtualDisk.Detach(tmpfn), Throws.Nothing);
				Assert.That(VirtualDisk.GetAllAttachedVirtualDiskPaths(), Is.Empty);
			}
			finally
			{
				System.IO.File.Delete(tmpfn);
			}
		}

		[Test()]
		public void GetAllAttachedVirtualDiskPathsTest()
		{
			Assert.That(VirtualDisk.GetAllAttachedVirtualDiskPaths(), Is.Empty);
			using (var vhd = VirtualDisk.Open(fn))
			{
				vhd.Attach();
				Assert.That(VirtualDisk.GetAllAttachedVirtualDiskPaths(), Has.Some.EqualTo(fn));
			}
			Assert.That(VirtualDisk.GetAllAttachedVirtualDiskPaths(), Is.Empty);
		}

		[Test()]
		public void CompactTest()
		{
			using (var vhd = VirtualDisk.Open(fn))
			{
				Assert.That(() => vhd.Compact(), Throws.Nothing);
			}
		}

		[Test()]
		public void ExpandTest()
		{
			const int sz = 0x810400;
			try
			{
				using (var vhd = VirtualDisk.Create(tmpfn, sz, true, null))
				{
					Assert.That(System.IO.File.Exists(tmpfn));
					Assert.That(vhd.VirtualSize, Is.EqualTo(sz));
					vhd.Expand(sz * 2);
					Assert.That(vhd.VirtualSize, Is.EqualTo(sz * 2));
				}
			}
			finally
			{
				System.IO.File.Delete(tmpfn);
			}
		}

		[Test()]
		public void MergeWithParentTest()
		{
			const int sz = 0x03010400;
			try
			{
				using (var vhdp = VirtualDisk.Create(tmpfn, sz))
					Assert.That(System.IO.File.Exists(tmpfn));
				using (var vhd = VirtualDisk.CreateDifferencing(tmpcfn, tmpfn))
				{
					Assert.That(System.IO.File.Exists(tmpcfn));
					vhd.MergeWithParent();
				}
			}
			finally
			{
				System.IO.File.Delete(tmpcfn);
				System.IO.File.Delete(tmpfn);
			}
		}

		[Test()]
		public void MergeTest()
		{
			const int sz = 0x03010400;
			try
			{
				using (var vhdp = VirtualDisk.Create(tmpfn, sz))
					Assert.That(System.IO.File.Exists(tmpfn));
				using (var vhd = VirtualDisk.CreateDifferencing(tmpcfn, tmpfn))
				{
					Assert.That(System.IO.File.Exists(tmpcfn));
					vhd.Merge(1, 2);
				}
			}
			finally
			{
				System.IO.File.Delete(tmpcfn);
				System.IO.File.Delete(tmpfn);
			}
		}

		[Test()]
		public void ResizeTest()
		{
			const int sz = 0x810400;
			try
			{
				using (var vhd = VirtualDisk.Create(tmpfn, sz, true, null))
				{
					Assert.That(System.IO.File.Exists(tmpfn));
					Assert.That(vhd.VirtualSize, Is.EqualTo(sz));
					vhd.Resize(sz * 2);
					Assert.That(vhd.VirtualSize, Is.EqualTo(sz * 2));
				}
			}
			finally
			{
				System.IO.File.Delete(tmpfn);
			}
		}

		[Test()]
		public void UnsafeResizeTest()
		{
			const int sz = 0x810400;
			try
			{
				using (var vhd = VirtualDisk.Create(tmpfn, sz * 2, true, null))
				{
					Assert.That(System.IO.File.Exists(tmpfn));
					Assert.That(vhd.VirtualSize, Is.EqualTo(sz * 2));
					Assert.That(() => vhd.UnsafeResize(sz), Throws.Exception);
				}
			}
			finally
			{
				System.IO.File.Delete(tmpfn);
			}
		}

		[Test()]
		public async Task CompactTest1()
		{
			using (var vhd = VirtualDisk.Open(fn))
			{
				var cts = new CancellationTokenSource();
				var rpt = new Reporter();
				var lastVal = 0;
				rpt.NewVal += (o, e) => TestContext.WriteLine($"{DateTime.Now:o} NewVal={lastVal = e}");
				await vhd.Compact(cts.Token, rpt);
				Assert.That(lastVal, Is.EqualTo(100));
			}
		}

		private class Reporter : IProgress<int>
		{
			public event EventHandler<int> NewVal;

			public void Report(int value)
			{
				NewVal?.Invoke(this, value);
			}
		}
	}
}