using NUnit.Framework;
using System;
using System.Runtime.InteropServices;
using Vanara.InteropServices;
using static Vanara.PInvoke.AdvApi32;
using static Vanara.PInvoke.VirtDisk;

namespace Vanara.PInvoke.Tests;

//[TestFixture()]
public class VirtDiskTests
{
	private const int vdSize = 0x03010400;
	private static readonly string tmpcfn = TestCaseSources.TempDirWhack + "TestVHD - Diff.vhdx";
	private static readonly string tmpfn = TestCaseSources.TempDirWhack + "TestVHD.vhdx";

	[Test]
	public void _StructTest()
	{
		TestHelper.DumpStructSizeAndOffsets<SET_VIRTUAL_DISK_INFO>();
	}

	[Test()]
	public void AttachVirtualDiskTest()
	{
		throw new NotImplementedException();
	}

	[Test()]
	public void AttachVirtualDiskTest1()
	{
		throw new NotImplementedException();
	}

	[Test()]
	public void CompactVirtualDiskTest()
	{
		throw new NotImplementedException();
	}

	[Test()]
	public void CompactVirtualDiskTest1()
	{
		throw new NotImplementedException();
	}

	[Test()]
	public void CreateVirtualDiskTest()
	{
		var handle = CreateParent();
		Assert.That(() => handle.Dispose(), Throws.Nothing);
		System.IO.File.Delete(tmpfn);
	}

	[Test()]
	public void CreateVirtualDiskTest1()
	{
		var handle = CreateChild();
		Assert.That(() => handle.Dispose(), Throws.Nothing);
		System.IO.File.Delete(tmpcfn);
	}

	[Test()]
	public void DetachVirtualDiskTest()
	{
		throw new NotImplementedException();
	}

	[Test()]
	public void ExpandVirtualDiskTest()
	{
		throw new NotImplementedException();
	}

	[Test()]
	public void GetStorageDependencyInformationTest()
	{
		try
		{
			using var handle = Kernel32.CreateFile(@"\\.\PhysicalDrive2", Kernel32.FileAccess.GENERIC_READ, System.IO.FileShare.ReadWrite, default, System.IO.FileMode.Open, FileFlagsAndAttributes.FILE_ATTRIBUTE_NORMAL | FileFlagsAndAttributes.FILE_FLAG_BACKUP_SEMANTICS);
			Assert.That(handle, ResultIs.ValidHandle);
			using var mem = new SafeCoTaskMemStruct<STORAGE_DEPENDENCY_INFO>(new STORAGE_DEPENDENCY_INFO { Version = STORAGE_DEPENDENCY_INFO_VERSION.STORAGE_DEPENDENCY_INFO_VERSION_2 });
			var flags = GET_STORAGE_DEPENDENCY_FLAG.GET_STORAGE_DEPENDENCY_FLAG_HOST_VOLUMES | GET_STORAGE_DEPENDENCY_FLAG.GET_STORAGE_DEPENDENCY_FLAG_DISK_HANDLE;
			var err = GetStorageDependencyInformation(handle.DangerousGetHandle(), flags, mem.Size, mem, out var sz);
			if (err == Win32Error.ERROR_INSUFFICIENT_BUFFER)
			{
				mem.Size = sz;
				err = GetStorageDependencyInformation(handle.DangerousGetHandle(), flags, mem.Size, mem, out sz);
			}
			err.ThrowIfFailed();
			mem.AsRef().Entries.WriteValues();
		}
		finally
		{
			//System.IO.File.Delete(tmpfn);
		}
	}

	[Test()]
	public void GetVirtualDiskInformationTest()
	{
		throw new NotImplementedException();
	}

	[Test()]
	public void GetVirtualDiskOperationProgressTest()
	{
		throw new NotImplementedException();
	}

	[Test()]
	public void GetVirtualDiskPhysicalPathTest()
	{
		throw new NotImplementedException();
	}

	[Test()]
	public void MergeVirtualDiskTest()
	{
		throw new NotImplementedException();
	}

	[Test()]
	public void OpenVirtualDiskTest()
	{
		throw new NotImplementedException();
	}

	[Test]
	public void ParentChildTest()
	{
		const uint PhysicalSectorSize = 4096;

		try
		{
			CreateParent().Dispose();
			CreateChild().Dispose();

			// Specify UNKNOWN for both device and vendor so the system will use the file extension to determine the correct VHD format.

			VIRTUAL_STORAGE_TYPE storageType = new();
			storageType.DeviceId = VIRTUAL_STORAGE_TYPE_DEVICE_TYPE.VIRTUAL_STORAGE_TYPE_DEVICE_UNKNOWN;
			storageType.VendorId = VIRTUAL_STORAGE_TYPE_VENDOR_UNKNOWN;

			// Open the parent so it's properties can be queried.
			//
			// A "GetInfoOnly" handle is a handle that can only be used to query properties or metadata.

			OPEN_VIRTUAL_DISK_PARAMETERS openParameters = new(false, true);

			// Open the VHD/VHDX.
			//
			// VIRTUAL_DISK_ACCESS_NONE is the only acceptable access mask for V2 handle opens. OPEN_VIRTUAL_DISK_FLAG_NO_PARENTS
			// indicates the parent chain should not be opened.

			OpenVirtualDisk(storageType, tmpfn,
				VIRTUAL_DISK_ACCESS_MASK.VIRTUAL_DISK_ACCESS_NONE,
				OPEN_VIRTUAL_DISK_FLAG.OPEN_VIRTUAL_DISK_FLAG_NO_PARENTS,
				openParameters, out var parentVhdHandle).ThrowIfFailed();

			using (parentVhdHandle)
			{
				// Get the disk ID of the parent.

				GET_VIRTUAL_DISK_INFO parentDiskInfo = new();
				var diskInfoSize = (uint)Marshal.SizeOf(typeof(GET_VIRTUAL_DISK_INFO));
				parentDiskInfo.Version = GET_VIRTUAL_DISK_INFO_VERSION.GET_VIRTUAL_DISK_INFO_IDENTIFIER;

				GetVirtualDiskInformation(parentVhdHandle, ref diskInfoSize, ref parentDiskInfo, out _).ThrowIfFailed();

				// Open the VHD/VHDX so it's properties can be queried.
				//
				// VIRTUAL_DISK_ACCESS_NONE is the only acceptable access mask for V2 handle opens. OPEN_VIRTUAL_DISK_FLAG_NO_PARENTS
				// indicates the parent chain should not be opened.

				OpenVirtualDisk(storageType, tmpcfn,
					VIRTUAL_DISK_ACCESS_MASK.VIRTUAL_DISK_ACCESS_NONE,
					OPEN_VIRTUAL_DISK_FLAG.OPEN_VIRTUAL_DISK_FLAG_NO_PARENTS,
					openParameters, out var childVhdHandle).ThrowIfFailed();

				using (childVhdHandle)
				{
					// Get the disk ID expected for the parent.

					GET_VIRTUAL_DISK_INFO childDiskInfo = new();
					childDiskInfo.Version = GET_VIRTUAL_DISK_INFO_VERSION.GET_VIRTUAL_DISK_INFO_PARENT_IDENTIFIER;
					diskInfoSize = (uint)Marshal.SizeOf(childDiskInfo);

					GetVirtualDiskInformation(childVhdHandle, ref diskInfoSize, ref childDiskInfo, out _).ThrowIfFailed();

					// Verify the disk IDs match.

					if (parentDiskInfo.Identifier != childDiskInfo.ParentIdentifier)
						Assert.Fail("Disk ID mismatch");

					// Reset the parent locators in the child.
				}

				// This cannot be a "GetInfoOnly" handle because the intent is to alter the properties of the VHD/VHDX.
				//
				// VIRTUAL_DISK_ACCESS_NONE is the only acceptable access mask for V2 handle opens. OPEN_VIRTUAL_DISK_FLAG_NO_PARENTS
				// indicates the parent chain should not be opened.

				openParameters.Version2.GetInfoOnly = false;

				OpenVirtualDisk(storageType, tmpcfn,
					VIRTUAL_DISK_ACCESS_MASK.VIRTUAL_DISK_ACCESS_NONE,
					OPEN_VIRTUAL_DISK_FLAG.OPEN_VIRTUAL_DISK_FLAG_NO_PARENTS,
					openParameters, out childVhdHandle).ThrowIfFailed();

				using (childVhdHandle)
				{
					// Update the path to the parent.

					using var pParentPath = new SafeCoTaskMemString(tmpfn);
					SET_VIRTUAL_DISK_INFO setInfo = new();
					setInfo.Version = SET_VIRTUAL_DISK_INFO_VERSION.SET_VIRTUAL_DISK_INFO_PARENT_PATH_WITH_DEPTH;
					setInfo.ParentPathWithDepthInfo = new SET_VIRTUAL_DISK_INFO.SET_VIRTUAL_DISK_INFO_ParentPathWithDepthInfo
					{
						ChildDepth = 1,
						ParentFilePath = (IntPtr)pParentPath
					};

					SetVirtualDiskInformation(childVhdHandle, setInfo).ThrowIfFailed();

					// Set the physical sector size.
					//
					// This operation will only succeed on VHDX.

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

	[Test()]
	public void SetVirtualDiskInformationTest()
	{
		throw new NotImplementedException();
	}

	private SafeVIRTUAL_DISK_HANDLE CreateChild()
	{
		CREATE_VIRTUAL_DISK_PARAMETERS param = new() { Version = CREATE_VIRTUAL_DISK_VERSION.CREATE_VIRTUAL_DISK_VERSION_2 };
		using SafeCoTaskMemString ppp = new(tmpfn);
		param.Version2.ParentPath = (IntPtr)ppp;
		Assert.That(CreateVirtualDisk(new VIRTUAL_STORAGE_TYPE(), tmpcfn, 0, default, 0, 0, param, IntPtr.Zero, out var handle), ResultIs.Successful);
		Assert.That(handle, ResultIs.ValidHandle);
		return handle;
	}

	private SafeVIRTUAL_DISK_HANDLE CreateParent()
	{
		CREATE_VIRTUAL_DISK_PARAMETERS param = new(vdSize, 2);
		Assert.That(CreateVirtualDisk(new VIRTUAL_STORAGE_TYPE(), tmpfn, 0, default, 0, 0, param, IntPtr.Zero, out var handle), ResultIs.Successful);
		Assert.That(handle, ResultIs.ValidHandle);
		return handle;
	}
}