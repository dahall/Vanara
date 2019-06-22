using NUnit.Framework;
using System;
using System.Runtime.InteropServices;
using System.Text;
using Vanara.InteropServices;
using static Vanara.PInvoke.AdvApi32;
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

				if (!AllocateUserPhysicalPages(hProc, ref NumberOfPages, aPFNs))
					FailLastErr("Cannot allocate physical pages ({0})");

				Assert.That(NumberOfPagesInitial, Is.EqualTo(NumberOfPages));

				// Reserve the virtual memory.

				var lpMemReserved = VirtualAlloc(IntPtr.Zero, MEMORY_REQUESTED, MEM_ALLOCATION_TYPE.MEM_RESERVE | MEM_ALLOCATION_TYPE.MEM_PHYSICAL, MEM_PROTECTION.PAGE_READWRITE);
				if (lpMemReserved == IntPtr.Zero)
					FailLastErr("Cannot reserve memory.");

				try
				{
					// Map the physical memory into the window.

					if (!MapUserPhysicalPages(lpMemReserved, NumberOfPages, aPFNs))
						FailLastErr("MapUserPhysicalPages failed ({0})");

					// unmap

					if (!MapUserPhysicalPages(lpMemReserved, NumberOfPages, null))
						FailLastErr("MapUserPhysicalPages failed ({0})");

					// Free the physical pages.

					if (!FreeUserPhysicalPages(hProc, ref NumberOfPages, aPFNs))
						FailLastErr("Cannot free physical pages, error {0}.");
				}
				finally
				{
					// Free virtual memory.

					if (!VirtualFree(lpMemReserved, 0, MEM_ALLOCATION_TYPE.MEM_RELEASE))
						FailLastErr("Call to VirtualFree has failed ({0})");
				}

				void FailLastErr(string fmt)
				{
					Assert.Fail(fmt, Win32Error.GetLastError());
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

	internal class PrivBlock : IDisposable
	{
		SafeCoTaskMemHandle prevState;
		SafeHTOKEN tok;

		public PrivBlock(string priv, HPROCESS hProc = default, TokenAccess access = TokenAccess.TOKEN_ADJUST_PRIVILEGES | TokenAccess.TOKEN_QUERY)
		{
			if (hProc.IsNull) hProc = GetCurrentProcess();
			tok = SafeHTOKEN.FromProcess(hProc, access);
			var newPriv = new PTOKEN_PRIVILEGES(LUID.FromName(priv), PrivilegeAttributes.SE_PRIVILEGE_ENABLED);
			prevState = PTOKEN_PRIVILEGES.GetAllocatedAndEmptyInstance();
			if (!AdjustTokenPrivileges(tok, false, newPriv, (uint)prevState.Size, prevState, out var retLen))
				Win32Error.ThrowLastError();
			prevState.Size = (int)retLen;
		}

		public void Dispose()
		{
			AdjustTokenPrivileges(tok, false, prevState);
			prevState.Dispose();
			tok.Dispose();
		}
	}
}