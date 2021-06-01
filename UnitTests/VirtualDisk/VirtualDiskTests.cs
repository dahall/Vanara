using NUnit.Framework;
using System;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Threading;
using System.Threading.Tasks;
using Vanara.InteropServices;
using static Vanara.PInvoke.AdvApi32;
using static Vanara.PInvoke.VirtDisk;

namespace Vanara.IO.Tests
{
	[TestFixture()]
	public class VirtualDiskTests
	{
		private static readonly string fn = Vanara.PInvoke.Tests.TestCaseSources.VirtualDisk;
		private static readonly string tmpcfn = Vanara.PInvoke.Tests.TestCaseSources.TempDirWhack + "TestVHD - Diff.vhd";
		private static readonly string tmpfn = Vanara.PInvoke.Tests.TestCaseSources.TempDirWhack + "TestVHD.vhd";

		[Test()]
		public void CompactTest()
		{
			using var vhd = VirtualDisk.Open(fn, false);
			Assert.That(() => vhd.Compact(), Throws.Nothing);
		}

		[Test()]
		public async Task CompactTest1()
		{
			using var vhd = VirtualDisk.Open(fn, false);
			var cts = new CancellationTokenSource();
			var rpt = new Reporter();
			var lastVal = 0;
			rpt.NewVal += (o, e) => TestContext.WriteLine($"{DateTime.Now:o} NewVal={lastVal = e}");
			await vhd.Compact(cts.Token, rpt);
			Assert.That(lastVal, Is.EqualTo(100));
		}

		[Test()]
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
				Assert.That(vhd.ResilientChangeTrackingEnabled, Is.False);
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
			finally
			{
				System.IO.File.Delete(tmpcfn);
				System.IO.File.Delete(tmpfn);
			}
		}

		[Test()]
		public void CreateDynPropTest()
		{
			const int sz = 0x03010200;
			try
			{
				using var vhd = VirtualDisk.Create(tmpfn, sz);
				//vhd.Attach(true);
				Assert.That(System.IO.File.Exists(tmpfn));
				Assert.That(vhd.Attached, Is.False);
				Assert.That(vhd.BlockSize, Is.EqualTo(0x200000));
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
			finally
			{
				System.IO.File.Delete(tmpfn);
			}
		}

		[Test()]
		public void CreateFixedPropTest()
		{
			const int sz = 0x03010400;
			try
			{
				using var vhd = VirtualDisk.Create(tmpfn, sz, false, null);
				Assert.That(System.IO.File.Exists(tmpfn));
				Assert.That(vhd.PhysicalSize, Is.EqualTo(sz + 512));
				Assert.That(vhd.ProviderSubtype, Is.EqualTo(VirtualDisk.Subtype.Fixed));
				Assert.That(vhd.VirtualSize, Is.EqualTo(sz));
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
				using var vhd = VirtualDisk.CreateFromSource(tmpfn, fn);
				Assert.That(System.IO.File.Exists(tmpfn));
				vhd.Close();
			}
			finally
			{
				System.IO.File.Delete(tmpfn);
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

		[Test()]
		public void GetAllAttachedVirtualDiskPathsTest()
		{
			Assert.That(VirtualDisk.GetAllAttachedVirtualDiskPaths(), Is.Empty);
			using (var vhd = VirtualDisk.Open(fn, true))
			{
				vhd.Attach();
				Assert.That(VirtualDisk.GetAllAttachedVirtualDiskPaths(), Has.Some.EqualTo(fn));
			}
			Assert.That(VirtualDisk.GetAllAttachedVirtualDiskPaths(), Is.Empty);
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

		//[Test]
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

		[Test()]
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

		[Test()]
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

		//[Test()]
		//public async Task CreateFromSourceTest1()
		//{
		//	VirtualDisk vd = null;
		//	try
		//	{
		//		var cts = new CancellationTokenSource();
		//		var rpt = new Reporter();
		//		var lastVal = 0;
		//		rpt.NewVal += (o, e) => TestContext.WriteLine($"{DateTime.Now:o} NewVal={lastVal = e}");
		//		vd = await VirtualDisk.CreateFromSource(tmpfn, fn, cts.Token, rpt);
		//		Assert.That(lastVal, Is.EqualTo(100));
		//		Assert.That(System.IO.File.Exists(tmpfn));
		//		TestContext.WriteLine($"New file sz: {new System.IO.FileInfo(tmpfn).Length}");
		//	}
		//	finally
		//	{
		//		vd?.Close();
		//		try { System.IO.File.Delete(tmpfn); } catch { }
		//	}
		//}
		[Test()]
		public void OpenAttachRawTest()
		{
			try
			{
				var param = new OPEN_VIRTUAL_DISK_PARAMETERS(false);
				using var vhd = VirtualDisk.Open(fn, OPEN_VIRTUAL_DISK_FLAG.OPEN_VIRTUAL_DISK_FLAG_NONE, param, VIRTUAL_DISK_ACCESS_MASK.VIRTUAL_DISK_ACCESS_NONE);
				Assert.That(vhd.Attached, Is.False);
				ATTACH_VIRTUAL_DISK_FLAG flags = ATTACH_VIRTUAL_DISK_FLAG.ATTACH_VIRTUAL_DISK_FLAG_READ_ONLY;
				ATTACH_VIRTUAL_DISK_PARAMETERS aparam = ATTACH_VIRTUAL_DISK_PARAMETERS.Default;
				SafePSECURITY_DESCRIPTOR sd = ConvertStringSecurityDescriptorToSecurityDescriptor("O:BAG:BAD:(A;;GA;;;WD)");
				vhd.Attach(flags, ref aparam, sd);
				Assert.That(vhd.Attached, Is.True);
				vhd.Detach();
				Assert.That(vhd.Attached, Is.False);
			}
			finally
			{
			}
		}

		[Test()]
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

		[Test()]
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

		[Test()]
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
		public void ParentChildTest()
		{
			const uint PhysicalSectorSize = 4096;
			const int sz = 0x03010400;

			var tmpfn = VirtualDiskTests.tmpfn + "x";
			var tmpcfn = VirtualDiskTests.tmpcfn + "x";

			try
			{
				VirtualDisk.Create(tmpfn, sz).Dispose();
				VirtualDisk.CreateDifferencing(tmpcfn, tmpfn).Dispose();

				//
				// Specify UNKNOWN for both device and vendor so the system will use the
				// file extension to determine the correct VHD format.
				//

				VIRTUAL_STORAGE_TYPE storageType = new();
				storageType.DeviceId = VIRTUAL_STORAGE_TYPE_DEVICE_TYPE.VIRTUAL_STORAGE_TYPE_DEVICE_UNKNOWN;
				storageType.VendorId = VIRTUAL_STORAGE_TYPE_VENDOR_UNKNOWN;

				//
				// Open the parent so it's properties can be queried.
				//
				// A "GetInfoOnly" handle is a handle that can only be used to query properties or
				// metadata.
				//

				OPEN_VIRTUAL_DISK_PARAMETERS openParameters = new(false, true);

				//
				// Open the VHD/VHDX.
				//
				// VIRTUAL_DISK_ACCESS_NONE is the only acceptable access mask for V2 handle opens.
				// OPEN_VIRTUAL_DISK_FLAG_NO_PARENTS indicates the parent chain should not be opened.
				//

				OpenVirtualDisk(storageType, tmpfn,
					VIRTUAL_DISK_ACCESS_MASK.VIRTUAL_DISK_ACCESS_NONE,
					OPEN_VIRTUAL_DISK_FLAG.OPEN_VIRTUAL_DISK_FLAG_NO_PARENTS,
					openParameters, out var parentVhdHandle).ThrowIfFailed();

				using (parentVhdHandle)
				{
					//
					// Get the disk ID of the parent.
					//

					GET_VIRTUAL_DISK_INFO parentDiskInfo = new();
					var diskInfoSize = (uint)Marshal.SizeOf(typeof(GET_VIRTUAL_DISK_INFO));
					parentDiskInfo.Version = GET_VIRTUAL_DISK_INFO_VERSION.GET_VIRTUAL_DISK_INFO_IDENTIFIER;

					GetVirtualDiskInformation(parentVhdHandle, ref diskInfoSize, ref parentDiskInfo, out _).ThrowIfFailed();

					//
					// Open the VHD/VHDX so it's properties can be queried.
					//
					// VIRTUAL_DISK_ACCESS_NONE is the only acceptable access mask for V2 handle opens.
					// OPEN_VIRTUAL_DISK_FLAG_NO_PARENTS indicates the parent chain should not be opened.
					//

					OpenVirtualDisk(storageType, tmpcfn,
						VIRTUAL_DISK_ACCESS_MASK.VIRTUAL_DISK_ACCESS_NONE,
						OPEN_VIRTUAL_DISK_FLAG.OPEN_VIRTUAL_DISK_FLAG_NO_PARENTS,
						openParameters, out var childVhdHandle).ThrowIfFailed();

					using (childVhdHandle)
					{
						//
						// Get the disk ID expected for the parent.
						//

						GET_VIRTUAL_DISK_INFO childDiskInfo = new();
						childDiskInfo.Version = GET_VIRTUAL_DISK_INFO_VERSION.GET_VIRTUAL_DISK_INFO_PARENT_IDENTIFIER;
						diskInfoSize = (uint)Marshal.SizeOf(childDiskInfo);

						GetVirtualDiskInformation(childVhdHandle, ref diskInfoSize, ref childDiskInfo, out _).ThrowIfFailed();

						//
						// Verify the disk IDs match.
						//

						if (parentDiskInfo.Identifier != childDiskInfo.ParentIdentifier)
							Assert.Fail("Disk ID mismatch");

						//
						// Reset the parent locators in the child.
						//
					}

					//
					// This cannot be a "GetInfoOnly" handle because the intent is to alter the properties of the 
					// VHD/VHDX.
					//
					// VIRTUAL_DISK_ACCESS_NONE is the only acceptable access mask for V2 handle opens.
					// OPEN_VIRTUAL_DISK_FLAG_NO_PARENTS indicates the parent chain should not be opened.
					//

					openParameters.Version2.GetInfoOnly = false;

					OpenVirtualDisk(storageType, tmpcfn,
						VIRTUAL_DISK_ACCESS_MASK.VIRTUAL_DISK_ACCESS_NONE,
						OPEN_VIRTUAL_DISK_FLAG.OPEN_VIRTUAL_DISK_FLAG_NO_PARENTS,
						openParameters, out childVhdHandle).ThrowIfFailed();

					using (childVhdHandle)
					{
						//
						// Update the path to the parent.
						//

						using var pParentPath = new SafeCoTaskMemString(tmpfn);
						SET_VIRTUAL_DISK_INFO setInfo = new();
						setInfo.Version = SET_VIRTUAL_DISK_INFO_VERSION.SET_VIRTUAL_DISK_INFO_PARENT_PATH_WITH_DEPTH;
						setInfo.ParentPathWithDepthInfo = new SET_VIRTUAL_DISK_INFO.SET_VIRTUAL_DISK_INFO_ParentPathWithDepthInfo
						{
							ChildDepth = 1,
							ParentFilePath = (IntPtr)pParentPath
						};

						SetVirtualDiskInformation(childVhdHandle, setInfo).ThrowIfFailed();

						//
						// Set the physical sector size.
						//
						// This operation will only succeed on VHDX.
						//

						setInfo.Version = SET_VIRTUAL_DISK_INFO_VERSION.SET_VIRTUAL_DISK_INFO_PHYSICAL_SECTOR_SIZE;
						setInfo.VhdPhysicalSectorSize = PhysicalSectorSize;

						SetVirtualDiskInformation(childVhdHandle, setInfo).ThrowIfFailed();
					}
				}
			}
			finally
			{
				System.IO.File.Delete(tmpcfn);
				System.IO.File.Delete(tmpfn);
			}
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

			public void Report(int value) => NewVal?.Invoke(this, value);
		}
	}
}