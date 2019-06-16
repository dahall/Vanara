using NUnit.Framework;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests
{
	[TestFixture]
	public class Kernel32Tests
	{
		internal const string badlibfn = @"C:\Windows\System32\ole3.dll";
		internal const string libfn = @"ole32.dll";
		internal const string tmpstr = @"Temporary";
		internal const string fn = @"C:\Temp\help.ico";

		public static string CreateTempFile(bool markAsTemp = true)
		{
			var fn = Path.GetTempFileName();
			if (markAsTemp)
				new FileInfo(fn).Attributes = FileAttributes.Temporary;
			File.WriteAllText(fn, tmpstr);
			return fn;
		}

		public static byte[] GetBigBytes(uint sz, byte fillVal = 0)
		{
			var ret = new byte[sz];
			for (var i = 0U; i < sz; i++) ret[i] = fillVal;
			return ret;
		}

		[Test]
		public void CreateProcessTest()
		{
			var res = CreateProcess(null, new StringBuilder("notepad.exe"), default, default, false, 0, default, null, STARTUPINFO.Default, out var pi);
			if (!res) TestContext.WriteLine(Win32Error.GetLastError());
			Assert.That(pi.hProcess.IsInvalid, Is.False);
			Assert.That(pi.hThread.IsInvalid, Is.False);
			Assert.That(pi.dwProcessId, Is.GreaterThan(0));
			Assert.That(pi.dwThreadId, Is.GreaterThan(0));
		}

		[Test]
		public void CreateHardLinkTest()
		{
			var link = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
			var fn = CreateTempFile();
			var b = CreateHardLink(link, fn);
			if (!b) TestContext.WriteLine($"CreateHardLink:{Win32Error.GetLastError()}");
			Assert.That(b);
			Assert.That(File.Exists(fn));
			var fnlen = new FileInfo(fn).Length;
			File.AppendAllText(link, "More text");
			Assert.That(fnlen, Is.LessThan(new FileInfo(fn).Length));
			File.Delete(link);
			File.Delete(fn);
		}

		[Test]
		public void CreateSymbolicLinkTest()
		{
			var link = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
			var fn = CreateTempFile(false);
			Assert.That(File.Exists(fn));
			var b = CreateSymbolicLink(link, fn, SymbolicLinkType.SYMBOLIC_LINK_FLAG_FILE);
			if (!b) TestContext.WriteLine($"CreateSymbolicLink:{Win32Error.GetLastError()}");
			Assert.That(b);
			Assert.That(File.Exists(link));
			File.Delete(link);
			File.Delete(fn);
		}

		[Test]
		public void EnumResourceNamesTest()
		{
			using (var hLib = LoadLibraryEx(@"C:\Windows\System32\en-US\aclui.dll.mui", IntPtr.Zero, LoadLibraryExFlags.LOAD_LIBRARY_AS_IMAGE_RESOURCE))
			{
				var l = EnumResourceNamesEx(hLib, ResourceType.RT_STRING);
				Assert.That(l.Count, Is.GreaterThan(0));
				foreach (var resourceName in l)
					Assert.That(resourceName.ToString(), Has.Length.GreaterThan(0));
			}
		}

		[Test]
		public void FileTimeToSystemTimeTest()
		{
			var dt = DateTime.Today;
			var ft = dt.ToFileTimeStruct();
			var b = FileTimeToSystemTime(ft, out var st);
			if (!b) TestContext.WriteLine($"FileTimeToSystemTime:{Win32Error.GetLastError()}");
			Assert.That(b);
			Assert.That(dt.Year, Is.EqualTo(st.wYear));
			Assert.That(dt.Day, Is.EqualTo(st.wDay));
		}

		[Test]
		public void FindResourceTest()
		{
			using (var hLib = LoadLibraryEx(@"comctl32.dll", IntPtr.Zero, LoadLibraryExFlags.LOAD_LIBRARY_AS_IMAGE_RESOURCE))
			{
				var ptr = FindResource(hLib, 65, ResourceType.RT_STRING);
				Assert.That(ptr, Is.Not.EqualTo(IntPtr.Zero));
			}
		}

		[Test]
		public void GetCompressedFileSizeTest()
		{
			var err = GetCompressedFileSize(fn, out ulong sz);
			if (err.Failed)
				TestContext.WriteLine(err);
			Assert.That(sz, Is.GreaterThan(0));

			sz = 0;
			err = GetCompressedFileSize(@"C:\NoFile.txt", out sz);
			Assert.That(err == Win32Error.ERROR_FILE_NOT_FOUND);
		}

		[Test]
		public void GetCurrentProcessTest()
		{
			var h = GetCurrentProcess();
			Assert.That(h, Is.EqualTo((HPROCESS)new IntPtr(-1)));
		}

		[Test]
		public void GetCurrentThreadTest()
		{
			var h = GetCurrentThread();
			Assert.That(h, Is.EqualTo((HTHREAD)new IntPtr(-2)));
		}

		[Test]
		public void GetCurrentThreadIdTest()
		{
			var i = GetCurrentThreadId();
			Assert.That(i, Is.Not.EqualTo(0));
		}

		[Test]
		public void GetModuleFileNameTest()
		{
			const string fn = @"C:\Windows\System32\tzres.dll";
			using (var hLib = LoadLibrary(fn))
			{
				var f = GetModuleFileName(hLib);
				Assert.That(f, Is.SamePath(fn));
			}
		}

		[Test]
		public void GetProcAddressTest()
		{
			const string fn = @"C:\Windows\System32\kernel32.dll";
			using (var hLib = LoadLibrary(fn))
			{
				var a = GetProcAddress(hLib, "GetNativeSystemInfo");
				Assert.That(a, Is.Not.EqualTo(IntPtr.Zero));
			}
		}

		[Test]
		public void GlobalLockTest()
		{
			var bp = GlobalLock(new IntPtr(1));
			Assert.That(bp, Is.EqualTo(IntPtr.Zero));
			Assert.That(Marshal.GetLastWin32Error(), Is.Not.Zero);

			using (var hMem = SafeHGlobalHandle.CreateFromStructure(1L))
			{
				Assert.That(hMem.IsInvalid, Is.False);
				var ptr = GlobalLock(hMem.DangerousGetHandle());
				Assert.That(ptr, Is.EqualTo(hMem.DangerousGetHandle()));
				GlobalUnlock(hMem.DangerousGetHandle());
			}
		}

		[Test]
		public void LoadLibraryTest()
		{
			var hlib = LoadLibrary(badlibfn);
			Assert.That((HINSTANCE)hlib, Is.EqualTo(HINSTANCE.NULL));
			Assert.That(Marshal.GetLastWin32Error(), Is.Not.Zero);

			hlib = LoadLibrary(libfn);
			Assert.That((HINSTANCE)hlib, Is.Not.EqualTo(HINSTANCE.NULL));
		}

		[Test]
		public void LoadLibraryExTest()
		{
			var hlib = LoadLibraryEx(badlibfn, IntPtr.Zero, LoadLibraryExFlags.LOAD_LIBRARY_AS_DATAFILE);
			Assert.That((HINSTANCE)hlib, Is.EqualTo(HINSTANCE.NULL));
			Assert.That(Marshal.GetLastWin32Error(), Is.Not.Zero);

			hlib = LoadLibraryEx(libfn, IntPtr.Zero, LoadLibraryExFlags.LOAD_LIBRARY_AS_DATAFILE);
			Assert.That((HINSTANCE)hlib, Is.Not.EqualTo(HINSTANCE.NULL));
		}

		[Test]
		public void LoadResourceTest()
		{
			using (var hlib = LoadLibraryEx("ole32.dll", IntPtr.Zero, LoadLibraryExFlags.LOAD_LIBRARY_AS_DATAFILE))
			{
				var hres = FindResource(hlib, 4, ResourceType.RT_CURSOR);
				Assert.That(hres, Is.Not.EqualTo(IntPtr.Zero));
				var sz = SizeofResource(hlib, hres);
				Assert.That(sz, Is.GreaterThan(0));
				var pres = LoadResource(hlib, hres);
				Assert.That(pres, Is.Not.EqualTo(IntPtr.Zero));
				var pmem = LockResource(pres);
				Assert.That(pmem, Is.Not.EqualTo(IntPtr.Zero));
			}
		}

		[Test]
		public void QueryDosDeviceTest()
		{
			System.Collections.Generic.IEnumerable<string> ie = null;
			Assert.That(() => ie = QueryDosDevice("C:"), Throws.Nothing);
			Assert.That(ie, Is.Not.Null);
			TestContext.WriteLine(string.Join(",", ie));
			Assert.That(ie, Is.Not.Empty);
		}

		[Test]
		public void QueryDosDeviceTest1()
		{
			var sb = new StringBuilder(4096);
			var cch = QueryDosDevice("C:", sb, sb.Capacity);
			Assert.That(cch, Is.Not.Zero);
			Assert.That(sb.Length, Is.GreaterThan(0));
			TestContext.WriteLine(sb);
		}

		[Test]
		public void HeapTest()
		{
			var ph = new SafeHeapBlock(512);
			var fw = new WIN32_FIND_DATA { ftCreationTime = DateTime.Today.ToFileTimeStruct(), cFileName = "test.txt", dwFileAttributes = FileAttributes.Normal };
			Marshal.StructureToPtr(fw, ph.DangerousGetHandle(), false);
			Assert.That(Marshal.ReadInt32(ph.DangerousGetHandle()), Is.EqualTo((int)FileAttributes.Normal));
			Assert.That(ph.Size, Is.EqualTo(512));

			using (var hh = HeapCreate(0, 0, 0))
			{
				var hb = hh.GetBlock(512);
				Marshal.StructureToPtr(fw, hb.DangerousGetHandle(), false);
				Assert.That(Marshal.ReadInt32(hb.DangerousGetHandle()), Is.EqualTo((int)FileAttributes.Normal));
				Assert.That(hb.Size, Is.EqualTo(512));
			}
		}

		[Test]
		public void PowerRequestTest()
		{
			using (var h = PowerCreateRequest(new REASON_CONTEXT("Just because")))
				Assert.That(h.IsInvalid, Is.False);
			using (var l = LoadLibraryEx("user32.dll", LoadLibraryExFlags.LOAD_LIBRARY_AS_DATAFILE))
			using (var h1 = PowerCreateRequest(new REASON_CONTEXT(l, 800)))
				Assert.That(h1.IsInvalid, Is.False);
		}

		[Test]
		public void SetLastErrorTest()
		{
			SetLastError(0);
			Assert.That((int)Win32Error.GetLastError(), Is.EqualTo(0));
			SetLastError(Win32Error.ERROR_AUDIT_FAILED);
			Assert.That((int)Win32Error.GetLastError(), Is.EqualTo(Win32Error.ERROR_AUDIT_FAILED));
		}

		[Test]
		public void SystemTimeToFileTimeTest()
		{
			var dt = new DateTime(2000, 1, 1, 4, 4, 4, 444, DateTimeKind.Utc);
			var st = new SYSTEMTIME(dt, DateTimeKind.Utc);
			Assert.That(st.ToString(DateTimeKind.Utc, null, null), Is.EqualTo(dt.ToString()));
			var b = SystemTimeToFileTime(st, out var ft);
			Assert.That(b, Is.True);
			Assert.That(FileTimeExtensions.Equals(ft, dt.ToFileTimeStruct()));
		}
	}
}