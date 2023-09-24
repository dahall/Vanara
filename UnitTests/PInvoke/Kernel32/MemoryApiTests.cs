using NUnit.Framework;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class MemoryApiTests
{
	// From https://docs.microsoft.com/en-us/windows/desktop/Memory/awe-example
	[Test]
	public void AWETest()
	{
		const uint MEMORY_REQUESTED = 1024 * 1024;

		GetSystemInfo(out SYSTEM_INFO sSysInfo);  // fill the system information structure

		TestContext.Write("This computer has page size {0}.\n", sSysInfo.dwPageSize);

		// Calculate the number of pages of memory to request.
		SizeT NumberOfPages = MEMORY_REQUESTED / sSysInfo.dwPageSize;
		TestContext.Write("Requesting {0} pages of memory.\n", NumberOfPages);

		// Enable the privilege.
		using (SafeHPROCESS hProc = SafeHPROCESS.Current)
		using (new ElevPriv("SeLockMemoryPrivilege", hProc))
		{
			// Allocate the physical memory.
			IntPtr[] aPFNs = new IntPtr[NumberOfPages];

			SizeT NumberOfPagesInitial = NumberOfPages;

			Assert.That(AllocateUserPhysicalPages(hProc, ref NumberOfPages, aPFNs), ResultIs.Successful);

			Assert.That(NumberOfPagesInitial, Is.EqualTo(NumberOfPages));

			// Reserve the virtual memory.
			IntPtr lpMemReserved;
			Assert.That(lpMemReserved = VirtualAlloc(IntPtr.Zero, MEMORY_REQUESTED, MEM_ALLOCATION_TYPE.MEM_RESERVE | MEM_ALLOCATION_TYPE.MEM_PHYSICAL, MEM_PROTECTION.PAGE_READWRITE), ResultIs.ValidHandle);

			try
			{
				// Map the physical memory into the window.
				Assert.That(MapUserPhysicalPages(lpMemReserved, NumberOfPages, aPFNs), ResultIs.Successful);

				// unmap
				Assert.That(MapUserPhysicalPages(lpMemReserved, NumberOfPages, null), ResultIs.Successful);

				// Map the physical memory into the window scattered.
				Assert.That(MapUserPhysicalPagesScatter(lpMemReserved, NumberOfPages, aPFNs), ResultIs.Successful);

				// unmap
				Assert.That(MapUserPhysicalPagesScatter(lpMemReserved, NumberOfPages, null), ResultIs.Successful);

				// Free the physical pages.
				Assert.That(FreeUserPhysicalPages(hProc, ref NumberOfPages, aPFNs), ResultIs.Successful);
			}
			finally
			{
				// Free virtual memory.
				Assert.That(VirtualFree(lpMemReserved, 0, MEM_ALLOCATION_TYPE.MEM_RELEASE), ResultIs.Successful);
			}
		}
	}

	[Test]
	public void FillMemoryTest()
	{
		using SafeHGlobalHandle mem = new(128);
		FillMemory((IntPtr)mem, 128, 0xFF);
		Assert.That(mem.ToArray<byte>(128), Has.All.EqualTo(0xFF));
	}

	[Test]
	public void GetLargePageMinimumTest() => Assert.That((uint)GetLargePageMinimum(), Is.GreaterThan(0));

	[Test]
	public void GetMemoryErrorHandlingCapabilitiesTest()
	{
		Assert.That(GetMemoryErrorHandlingCapabilities(out uint cap), Is.True);
		TestContext.WriteLine(cap);
	}

	[Test]
	public void GetProcessWorkingSetSizeExTest()
	{
		Assert.That(GetProcessWorkingSetSizeEx(GetCurrentProcess(), out SizeT min, out SizeT max, out QUOTA_LIMITS_HARDWS flg), Is.True);
		TestContext.WriteLine($"{min} : {max} : {flg}");
	}

	[Test]
	public void GetSystemFileCacheSizeTest()
	{
		Assert.That(GetSystemFileCacheSize(out SizeT min, out SizeT max, out FILE_CACHE_LIMITS flg), Is.True);
		TestContext.WriteLine($"{min} : {max} : {flg}");
	}

	[Test]
	public void SafeMoveableHGlobleFlagsTest()
	{
		using SafeMoveableHGlobalHandle h = new(32);
		Assert.AreEqual(GlobalFlags(h), GMEM.GMEM_SHARE);
	}

	[Test, Repeat(50)]
	public void SafeMoveableHGlobalCreateFromHGLOBALTest()
	{
		RECT val = new(8, 16, 32, 64);
		IntPtr ptr = InteropExtensions.MarshalToPtr(val, i => (IntPtr)GlobalAlloc(GMEM.GHND | GMEM.GMEM_SHARE, i), out _, memLock: p => GlobalLock(p), memUnlock: p => GlobalUnlock(p));
		using SafeMoveableHGlobalHandle h = new(ptr, true);
		Assert.AreEqual(val, h.ToStructure<RECT>());
	}

	[Test]
	public void SafeMoveableHGlobalCreateFromStringListTest()
	{
		string[] strings = new[] { "AAAA", "BBBB", "CCCC" };
		using SafeMoveableHGlobalHandle h = SafeMoveableHGlobalHandle.CreateFromStringList(strings);
		CollectionAssert.AreEqual(strings, h.ToStringEnum());
	}

	[Test]
	public void SafeMoveableHGlobalCreateFromStructTest()
	{
		RECT val = new(8, 16, 32, 64);
		using SafeMoveableHGlobalHandle h = SafeMoveableHGlobalHandle.CreateFromStructure(val);
		Assert.AreEqual(val, h.ToStructure<RECT>());
	}

	[Test]
	public void SafeMoveableHGlobalCreateFromBytesTest()
	{
		const string txt = @"“0’0©0è0”";
		using SafeMoveableHGlobalHandle h = new(Encoding.Unicode.GetBytes(txt + '\0'));
		Assert.AreEqual(txt, h.ToString(-1));
	}

	[Test, Repeat(50)]
	public void SafeMoveableHGlobalTakeOwnershipTest()
	{
		RECT val = new(8, 16, 32, 64);
		using SafeMoveableHGlobalHandle h = SafeMoveableHGlobalHandle.CreateFromStructure(val);
		HGLOBAL myh = h.TakeOwnership();
		try
		{
			IntPtr p = GlobalLock(myh);
			Assert.AreEqual(val, p.ToStructure<RECT>());
			GlobalUnlock(myh);
		}
		finally { Assert.AreEqual(GlobalFree(myh), HGLOBAL.NULL); }
	}

	[Test]
	public void SafeMoveableHGlobalWriteStructTest()
	{
		RECT val = new(8, 16, 32, 64);
		using SafeMoveableHGlobalHandle h = new(32);
		h.Write(val);
		Assert.AreEqual(val, h.ToStructure<RECT>());
	}

	[Test]
	public void SafeMoveableHGlobalWriteStringListTest()
	{
		string[] strings = new[] { "AAAA", "BBBB", "CCCC" };
		using SafeMoveableHGlobalHandle h = new(256);
		h.CallLocked(p => p.Write(strings, StringListPackMethod.Concatenated, offset: 64, allocatedBytes: h.Size));
		CollectionAssert.AreEqual(strings, h.ToStringEnum(prefixBytes: 64));
		Assert.That(() => h.CallLocked(p => p.Write(strings, StringListPackMethod.Concatenated, offset: 250, allocatedBytes: h.Size)), Throws.Exception);
		CollectionAssert.AreEqual(strings, h.ToStringEnum(prefixBytes: 64));
	}
}