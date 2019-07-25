using NUnit.Framework;
using System;
using System.Runtime.InteropServices;
using System.Text;
using Vanara.InteropServices;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests
{
	[TestFixture]
	public class MemoryApiTests
	{
		// From https://docs.microsoft.com/en-us/windows/desktop/Memory/awe-example
		[Test]
		public void AWETest()
		{
			const uint MEMORY_REQUESTED = 1024 * 1024;

			GetSystemInfo(out var sSysInfo);  // fill the system information structure

			TestContext.Write("This computer has page size {0}.\n", sSysInfo.dwPageSize);

			// Calculate the number of pages of memory to request.
			SizeT NumberOfPages = MEMORY_REQUESTED / sSysInfo.dwPageSize;
			TestContext.Write("Requesting {0} pages of memory.\n", NumberOfPages);

			// Enable the privilege.
			using (var hProc = SafeHPROCESS.Current)
			using (new PrivBlock("SeLockMemoryPrivilege", hProc))
			{
				// Allocate the physical memory.
				var aPFNs = new IntPtr[NumberOfPages];

				var NumberOfPagesInitial = NumberOfPages;

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
			using (var mem = new SafeHGlobalHandle(128))
			{
				FillMemory((IntPtr)mem, 128, 0xFF);
				Assert.That(mem.ToArray<byte>(128), Has.All.EqualTo(0xFF));
			}
		}

		[Test]
		public void GetLargePageMinimumTest()
		{
			Assert.That((uint)GetLargePageMinimum(), Is.GreaterThan(0));
		}

		[Test]
		public void GetMemoryErrorHandlingCapabilitiesTest()
		{
			Assert.That(GetMemoryErrorHandlingCapabilities(out var cap), Is.True);
			TestContext.WriteLine(cap);
		}

		[Test]
		public void GetProcessWorkingSetSizeExTest()
		{
			Assert.That(GetProcessWorkingSetSizeEx(GetCurrentProcess(), out var min, out var max, out var flg), Is.True);
			TestContext.WriteLine($"{min} : {max} : {flg}");
		}

		[Test]
		public void GetSystemFileCacheSizeTest()
		{
			Assert.That(GetSystemFileCacheSize(out var min, out var max, out var flg), Is.True);
			TestContext.WriteLine($"{min} : {max} : {flg}");
		}
	}
}