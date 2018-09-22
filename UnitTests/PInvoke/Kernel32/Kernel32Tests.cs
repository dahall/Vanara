using NUnit.Framework;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.Kernel32;
using static Vanara.PInvoke.Macros;
using static Vanara.PInvoke.User32_Gdi;

namespace Vanara.PInvoke.Tests
{
	[TestFixture]
	public class Kernel32Tests
	{
		internal const string badlibfn = @"C:\Windows\System32\ole3.dll";
		internal const string libfn = @"ole32.dll";
		internal const string tmpstr = @"Temporary";

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
		public void AsyncReadWriteTest()
		{
			var fn = Path.GetTempFileName();
			uint sz = 1024 * 1024 * 128;
			using (var hFile = CreateFile(fn, Kernel32.FileAccess.GENERIC_WRITE, FileShare.Write, null, FileMode.OpenOrCreate,
				FileFlagsAndAttributes.FILE_FLAG_OVERLAPPED, IntPtr.Zero))
			{
				var bytes = GetBigBytes(sz, 1);
				Assert.That(bytes[1024], Is.EqualTo(1));
				new TaskFactory().FromAsync(BeginWriteFile, EndWriteFile, hFile, bytes, (uint) bytes.Length, 1).Wait();
			}
			var fi = new FileInfo(fn);
			Assert.That(fi.Exists);
			Assert.That(fi.Length, Is.EqualTo(sz));
			using (var hFile = CreateFile(fn, Kernel32.FileAccess.GENERIC_READ, FileShare.Read, null, FileMode.Open, 
				FileFlagsAndAttributes.FILE_FLAG_OVERLAPPED | FileFlagsAndAttributes.FILE_FLAG_DELETE_ON_CLOSE, IntPtr.Zero))
			{
				var bytes = GetBigBytes(sz);
				Assert.That(bytes[1024], Is.EqualTo(0));
				new TaskFactory().FromAsync(BeginReadFile, EndReadFile, hFile, bytes, (uint)bytes.Length, 1).Wait();
				Assert.That(bytes[1024], Is.EqualTo(1));
			}
		}

		[Test]
		public void CreateReadFileTest()
		{
			var rofn = CreateTempFile();
			using (var f = CreateFile(rofn, Kernel32.FileAccess.GENERIC_READ, FileShare.Read, null, FileMode.Open, FileFlagsAndAttributes.FILE_ATTRIBUTE_NORMAL, IntPtr.Zero))
			{
				var sb = new SafeCoTaskMemString(100, CharSet.Ansi);
				var b = ReadFile(f, (IntPtr)sb, (uint)sb.Capacity, out var read, IntPtr.Zero);
				if (!b) TestContext.WriteLine($"ReadFile:{Win32Error.GetLastError()}");
				Assert.That(b);
				if (read < sb.Capacity) Marshal.WriteInt16((IntPtr)sb, (int)read, '\0');
				Assert.That(read, Is.Not.Zero.And.LessThanOrEqualTo(sb.Capacity));
				Assert.That((string)sb, Is.EqualTo(tmpstr));

				b = SetFilePointerEx(f, 0, out var pos, SeekOrigin.Begin);
				if (!b) TestContext.WriteLine($"SetFilePointerEx:{Win32Error.GetLastError()}");
				Assert.That(b);
				Assert.That(pos, Is.Zero);

				var bytes = new byte[100];
				b = ReadFile(f, bytes, (uint)bytes.Length, out read, IntPtr.Zero);
				if (!b) TestContext.WriteLine($"ReadFile:{Win32Error.GetLastError()}");
				Assert.That(b);
				Assert.That(read, Is.Not.Zero.And.LessThanOrEqualTo(bytes.Length));
				Assert.That(Encoding.ASCII.GetString(bytes, 0, (int)read), Is.EqualTo(tmpstr));
			}
		}

		[Test]
		public void CreateWriteFileTest()
		{
			using (var f = CreateFile(Path.GetTempFileName(), Kernel32.FileAccess.GENERIC_WRITE, FileShare.Write, null, FileMode.OpenOrCreate, FileFlagsAndAttributes.FILE_ATTRIBUTE_NORMAL, IntPtr.Zero))
			{
				var txt = "Some text to push.";
				var bytes = txt.GetBytes(false);
				var b = WriteFile(f, bytes, (uint)bytes.Length, out var written, IntPtr.Zero);
				if (!b) TestContext.WriteLine($"WriteFile:{Win32Error.GetLastError()}");
				Assert.That(b);
				Assert.That(written, Is.EqualTo(bytes.Length));
				var ptr = new SafeCoTaskMemString(" More text to push.");
				b = WriteFile(f, (IntPtr)ptr, (uint)ptr.Capacity, out written, IntPtr.Zero);
				if (!b) TestContext.WriteLine($"WriteFile:{Win32Error.GetLastError()}");
				Assert.That(b);
				Assert.That(written, Is.EqualTo(ptr.Capacity));
			}
		}

		[Test]
		public void CreateHardLinkTest()
		{
			var link = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
			var fn = CreateTempFile();
			var b = CreateHardLink(link, fn, IntPtr.Zero);
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
				{
					LoadString(hLib, resourceName, out var sptr, 0);
					TestContext.WriteLine($"{resourceName} = {StringHelper.GetString(sptr)}");
				}
			}
		}

		[Test]
		public void FileTimeToSystemTimeTest()
		{
			var dt = DateTime.Today;
			var ft = dt.ToFileTimeStruct();
			var st = new SYSTEMTIME();
			var b = FileTimeToSystemTime(ref ft, ref st);
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
		public void FormatMessageTest()
		{
			var s = FormatMessage(Win32Error.ERROR_INVALID_PARAMETER);
			Assert.That(s, Is.Not.Null);
			TestContext.WriteLine(s);

			using (var hLib = LoadLibraryEx(@"wininet.dll", IntPtr.Zero, LoadLibraryExFlags.LOAD_LIBRARY_AS_DATAFILE))
			{
				s = FormatMessage(12175, new[] {"Fred", "Alice"}, hLib);
				Assert.That(s, Is.Not.Null);
				TestContext.WriteLine(s);
			}
		}

		[Test]
		public void FormatMessageTest1()
		{
			var objs = new string[] {"Alan", "Bob", "Chuck", "Dave", "Ed", "Frank", "Gary", "Harry"}; // new object[] { 4, "Bob", 100UL, long.MaxValue, 'A', true, 5U, byte.MaxValue };
			Assert.That(FormatMessage(null, objs), Is.Null);
			Assert.That(FormatMessage("X", null), Is.EqualTo("X"));
			Assert.That(FormatMessage("X", objs), Is.EqualTo("X"));
			Assert.That(FormatMessage("X %1", new [] {"YZ"}), Is.EqualTo("X YZ"));
			var s = FormatMessage("%1 %2 %3 %4 %5 %6 %7 %8", objs);
			Assert.That(s, Is.EqualTo("Alan Bob Chuck Dave Ed Frank Gary Harry"));
			//s = FormatMessage("%1 %2", new object[] { 4, "Alan" }, FormatMessageFlags.FORMAT_MESSAGE_IGNORE_INSERTS);
			//Assert.That(s, Is.EqualTo("%1 %2"));
			//s = FormatMessage("%1 %2", new object[] { 4, 8 });
			//Assert.That(s, Is.EqualTo("4 8"));
			//s = FormatMessage("%1 %2 %3 %4 %5 %6 %7 %8", objs);
			//Assert.That(s, Is.EqualTo("4 Bob 9223372036854775807 A 1 4294967295 255"));
		}

		[Test]
		public void GetCompressedFileSizeTest()
		{
			var highSz = 0U;
			var lowSz = GetCompressedFileSize(AdvApi32Tests.fn, ref highSz);
			Assert.That(lowSz, Is.Not.EqualTo(INVALID_FILE_SIZE));
			if (lowSz == INVALID_FILE_SIZE)
				TestContext.WriteLine(Win32Error.GetLastError());
			var sz = MAKELONG64(lowSz, highSz);
			Assert.That(sz, Is.GreaterThan(0));

			highSz = 0;
			lowSz = GetCompressedFileSize(@"C:\NoFile.txt", ref highSz);
			Assert.That(lowSz, Is.EqualTo(INVALID_FILE_SIZE));
			Assert.That(Win32Error.GetLastError() == Win32Error.ERROR_FILE_NOT_FOUND);
		}

		[Test]
		public void GetCurrentProcessTest()
		{
			var h = GetCurrentProcess();
			Assert.That(h, Is.EqualTo(new IntPtr(-1)));
		}

		[Test]
		public void GetCurrentThreadTest()
		{
			var h = GetCurrentThread();
			Assert.That(h, Is.EqualTo(new IntPtr(-2)));
		}

		[Test]
		public void GetCurrentThreadIdTest()
		{
			var i = GetCurrentThreadId();
			Assert.That(i, Is.Not.EqualTo(0));
		}

		[Test]
		public void GetDiskFreeSpaceTest()
		{
			var b = GetDiskFreeSpace(null, out var spc, out var bps, out var fc, out var cc);
			Assert.That(b, Is.True);
			Assert.That(spc, Is.Not.EqualTo(0));
			Assert.That(bps, Is.Not.EqualTo(0));
			Assert.That(fc, Is.Not.EqualTo(0));
			Assert.That(cc, Is.Not.EqualTo(0));
			b = GetDiskFreeSpace("Q", out spc, out bps, out fc, out cc);
			Assert.That(b, Is.False);
		}

		[Test]
		public void GetDiskFreeSpaceExTest()
		{
			var b = GetDiskFreeSpaceEx(null, out var fba, out var tb, out var tfb);
			Assert.That(b, Is.True);
			Assert.That(fba, Is.Not.EqualTo(0));
			Assert.That(tb, Is.Not.EqualTo(0));
			Assert.That(tfb, Is.Not.EqualTo(0));
			b = GetDiskFreeSpaceEx("Q", out fba, out tb, out tfb);
			Assert.That(b, Is.False);
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
		public void GetVolumeInformationTest()
		{
			var b = GetVolumeInformation(null, out var vn, out var vsn, out var mcl, out var fsf, out var fsn);
			Assert.That(b, Is.True);
			Assert.That(vn, Is.Not.Null.And.Not.Empty);
			Assert.That(vsn, Is.Not.EqualTo(0));
			Assert.That(mcl, Is.Not.EqualTo(0));
			Assert.That(fsf, Is.Not.EqualTo(0));
			Assert.That(fsn, Is.Not.Null.And.Not.Empty);
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
			Assert.That(hlib, Is.EqualTo(HINSTANCE.NULL));
			Assert.That(Marshal.GetLastWin32Error(), Is.Not.Zero);

			hlib = LoadLibrary(libfn);
			Assert.That(hlib, Is.Not.EqualTo(HINSTANCE.NULL));
		}

		[Test]
		public void LoadLibraryExTest()
		{
			var hlib = LoadLibraryEx(badlibfn, IntPtr.Zero, LoadLibraryExFlags.LOAD_LIBRARY_AS_DATAFILE);
			Assert.That(hlib, Is.EqualTo(HINSTANCE.NULL));
			Assert.That(Marshal.GetLastWin32Error(), Is.Not.Zero);

			hlib = LoadLibraryEx(libfn, IntPtr.Zero, LoadLibraryExFlags.LOAD_LIBRARY_AS_DATAFILE);
			Assert.That(hlib, Is.Not.EqualTo(HINSTANCE.NULL));
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
			var ph = new SafeProcessHeapBlockHandle(512);
			var fw = new WIN32_FIND_DATA {ftCreationTime = DateTime.Today.ToFileTimeStruct(), cFileName = "test.txt", dwFileAttributes = FileAttributes.Normal};
			Marshal.StructureToPtr(fw, ph.DangerousGetHandle(), false);
			Assert.That(Marshal.ReadInt32(ph.DangerousGetHandle()), Is.EqualTo((int)FileAttributes.Normal));
			Assert.That(ph.Size, Is.EqualTo(512));

			using (var hh = HeapCreate(0, IntPtr.Zero, IntPtr.Zero))
			{
				var hb = hh.GetBlock(512);
				Marshal.StructureToPtr(fw, hb.DangerousGetHandle(), false);
				Assert.That(Marshal.ReadInt32(hb.DangerousGetHandle()), Is.EqualTo((int) FileAttributes.Normal));
				Assert.That(hb.Size, Is.EqualTo(512));
			}
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
			var ft = new System.Runtime.InteropServices.ComTypes.FILETIME();
			var b = SystemTimeToFileTime(ref st, ref ft);
			Assert.That(b, Is.True);
			Assert.That(FileTimeExtensions.Equals(ft, dt.ToFileTimeStruct()));
		}
	}
}