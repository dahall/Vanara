using NUnit.Framework;
using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.Kernel32;
using static Vanara.PInvoke.Tests.Kernel32Tests;

namespace Vanara.PInvoke.Tests
{
	[TestFixture]
	public class FileApiTests
	{
		//[Test]
		public void AsyncReadWriteTest()
		{
			var fn = Path.GetTempFileName();
			uint sz = 1024 * 1024 * 128;
			using (var hFile = CreateFile(fn, Kernel32.FileAccess.GENERIC_WRITE, FileShare.Write, null, FileMode.OpenOrCreate,
				FileFlagsAndAttributes.FILE_FLAG_OVERLAPPED, IntPtr.Zero))
			{
				var bytes = GetBigBytes(sz, 1);
				Assert.That(bytes[1024], Is.EqualTo(1));
				new TaskFactory().FromAsync<HFILE, byte[], uint>(BeginWriteFile, EndWriteFile, hFile, bytes, (uint)bytes.Length, 1).Wait();
			}
			var fi = new FileInfo(fn);
			Assert.That(fi.Exists);
			Assert.That(fi.Length, Is.EqualTo(sz));

			var cfp2 = new CREATEFILE2_EXTENDED_PARAMETERS { dwFileFlags = FileFlagsAndAttributes.FILE_FLAG_OVERLAPPED, dwSize = (uint)Marshal.SizeOf(typeof(CREATEFILE2_EXTENDED_PARAMETERS)) };
			using (var hFile = CreateFile2(fn, Kernel32.FileAccess.GENERIC_READ, FileShare.Read, FileMode.Open, cfp2))
			{
				var bytes = GetBigBytes(sz);
				Assert.That(bytes[1024], Is.EqualTo(0));
				new TaskFactory().FromAsync<HFILE, byte[], uint>(BeginReadFile, EndReadFile, hFile, bytes, (uint)bytes.Length, 1).Wait();
				Assert.That(bytes[1024], Is.EqualTo(1));
			}

			Assert.That(DeleteFile(fn), Is.True);
		}

		[Test]
		public void CompareFileTimeTest()
		{
			var now = DateTime.Now.ToFileTimeStruct();
			var today = DateTime.Today.ToFileTimeStruct();
			Assert.That(CompareFileTime(now, today), Is.GreaterThan(0));
			Assert.That(CompareFileTime(now, now), Is.Zero);
		}

		[Test]
		public void CreateDirectoryTest()
		{
			const string dir = @"C:\Temp\Temp";
			Assert.That(CreateDirectory(dir), Is.True);
			Assert.That(System.IO.Directory.Exists(dir), Is.True);
			Assert.That(RemoveDirectory(dir), Is.True);
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
		public void DefineDosDeviceTest()
		{
			const string src = "M:";
			const string target = @"C:\Temp";

			var c = QueryDosDevice(src).ToArray().Length;
			Assert.That(DefineDosDevice(DDD.DDD_NO_BROADCAST_SYSTEM, src, target), Is.True);
			Assert.That(QueryDosDevice(src).ToArray(), Has.Member(@"\??\" + target).And.Length.EqualTo(c + 1));
			Assert.That(DefineDosDevice(DDD.DDD_NO_BROADCAST_SYSTEM | DDD.DDD_REMOVE_DEFINITION, src, target), Is.True);
			Assert.That(QueryDosDevice(src).ToArray(), Has.Length.EqualTo(c));
		}

		[Test]
		public void DeleteSetVolumeMountPointTest()
		{
			// TODO: SetVolumeMountPoint();
		}

		[Test]
		public void EnumFilesExTest()
		{
			Assert.That(EnumFilesEx(@"C:\Temp\*.txt").ToArray(), Is.Not.Empty);
		}

		[Test]
		public void EnumVolumesTest()
		{
			Assert.That(EnumVolumes().ToArray(), Is.Not.Empty);
		}

		[Test]
		public void FileTimeToLocalFileTimeTest()
		{
			var utc = DateTime.UtcNow.ToFileTimeStruct();
			FileTimeToSystemTime(utc, out var st);
			Assert.That(FileTimeToLocalFileTime(utc, out var ftlocal), Is.True);
			FileTimeToSystemTime(ftlocal, out var stl);
			Assert.That(stl.wHour, Is.EqualTo(DateTime.Now.Hour));
			Assert.That(LocalFileTimeToFileTime(ftlocal, out var utc2), Is.True);
			Assert.That(utc.ToUInt64(), Is.EqualTo(utc2.ToUInt64()));
		}

		[Test]
		public void FindFirstChangeNotificationTest()
		{
			var keepGoing = true;
			var thread = new Thread(FileMaker);
			try
			{
				using (var h = FindFirstChangeNotification(@"C:\Temp", false, FILE_NOTIFY_CHANGE.FILE_NOTIFY_CHANGE_FILE_NAME))
				{
					Assert.That(h.IsInvalid, Is.False);
					thread.Start();
					Assert.That(WaitForSingleObject(h, 5000), Is.EqualTo(WAIT_STATUS.WAIT_OBJECT_0));
					Assert.That(FindNextChangeNotification(h), Is.True);
					Assert.That(WaitForSingleObject(h, 5000), Is.EqualTo(WAIT_STATUS.WAIT_OBJECT_0));
				}
			}
			finally
			{
				keepGoing = false;
				thread.Join(650);
			}

			void FileMaker()
			{
				const string fn = @"C:\Temp\_tempFile.txt";
				while (keepGoing)
				{
					Thread.Sleep(200);
					File.WriteAllText(fn, "a;sldkfjal;skdjfl;akjsdfl;kj");
					Thread.Sleep(100);
					File.Delete(fn);
				}
			}
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
		public void GetDriveTypeTest()
		{
			Assert.That(GetDriveType(null), Is.EqualTo(DRIVE_TYPE.DRIVE_FIXED));
		}

		[Test]
		public void GetFileInformationByHandleTest()
		{
			using (var tmp = new TempFile(Kernel32.FileAccess.FILE_GENERIC_READ, FileShare.Read))
			{
				Assert.That(GetFileInformationByHandle(tmp.hFile, out var fi), Is.True);
				Assert.That(fi.nFileSizeLow, Is.EqualTo(tmpstr.Length));
			}
		}

		[Test]
		public void GetFileSizeTest()
		{
			using (var tmp = new TempFile(Kernel32.FileAccess.FILE_GENERIC_READ, FileShare.Read))
			{
				Assert.That(GetFileSize(tmp.hFile, out var hw), Is.EqualTo(TempFile.tmpstr.Length));
				Assert.That(hw, Is.Zero);
				Assert.That(GetFileSizeEx(tmp.hFile, out var sz), Is.True);
				Assert.That(sz, Is.EqualTo(TempFile.tmpstr.Length));
			}
		}

		[Test]
		public void GetFileTypeTest()
		{
			using (var tmp = new TempFile(Kernel32.FileAccess.FILE_GENERIC_READ, FileShare.Read))
				Assert.That(GetFileType(tmp.hFile), Is.EqualTo(FileType.FILE_TYPE_DISK));
		}

		[Test]
		public void GetFinalPathNameByHandleTest()
		{
			var sb = new StringBuilder(MAX_PATH);
			using (var tmp = new TempFile(Kernel32.FileAccess.FILE_GENERIC_READ, FileShare.Read))
			{
				var u = GetFinalPathNameByHandle(tmp.hFile, sb, MAX_PATH, FinalPathNameOptions.FILE_NAME_NORMALIZED);
				Assert.That(u, Is.Not.Zero);
				TestContext.WriteLine(sb);
			}
		}

		[Test]
		public void GetFullPathNameTest()
		{
			var sb = new StringBuilder(1024);
			var u = GetFullPathName("notepad.exe", (uint)sb.Capacity, sb, out _);
			Assert.That(u, Is.Not.Zero);
			TestContext.WriteLine(sb);
		}

		[Test]
		public void GetLogicalDrivesTest()
		{
			Assert.That(GetLogicalDrives(), Is.Not.Zero);
		}

		[Test]
		public void GetLogicalDriveStringsTest()
		{
			var sb = new StringBuilder(1024);
			Assert.That(GetLogicalDriveStrings((uint)sb.Capacity, sb), Is.Not.Zero);
			TestContext.WriteLine(sb);
		}

		[Test]
		public void GetSetFileAttributesTest()
		{
			using (var tmp = new TempFile())
			{
				var attr = FileFlagsAndAttributes.FILE_ATTRIBUTE_ARCHIVE | FileFlagsAndAttributes.FILE_ATTRIBUTE_TEMPORARY;
				Assert.That(SetFileAttributes(tmp.FullName, attr), Is.True);
				Assert.That(GetFileAttributes(tmp.FullName), Is.EqualTo(attr));
				Assert.That(GetFileAttributesEx(tmp.FullName, GET_FILEEX_INFO_LEVELS.GetFileExInfoStandard, out var fi), Is.True);
				Assert.That(fi.dwFileAttributes, Is.EqualTo(attr));
			}
		}

		[Test]
		public void GetSetFileTimeTest()
		{
			using (var tmp = new TempFile(Kernel32.FileAccess.FILE_ALL_ACCESS, FileShare.Read))
			{
				Assert.That(GetFileTime(tmp.hFile, out var ft1, out var ft2, out var ft3), Is.True);
				var nft = DateTime.UtcNow.ToFileTimeStruct();
				var b = SetFileTime(tmp.hFile, ft1, ft2, nft);
				if (!b) TestContext.WriteLine($"SetFileTime:{Win32Error.GetLastError()}");
				Assert.That(b, Is.True);
				Assert.That(GetFileTime(tmp.hFile, out var nft1, out var nft2, out var nft3), Is.True);
				Assert.That(ft1, Is.EqualTo(nft1));
				Assert.That(nft, Is.EqualTo(nft3));
			}
		}

		[Test]
		public void GetShortLongPathNameTest()
		{
			var sb = new StringBuilder(1024);
			Assert.That(GetShortPathName(GetType().Assembly.Location, sb, (uint)sb.Capacity), Is.Not.Zero);
			TestContext.WriteLine($"Short: {sb}");
			var shfn = sb.ToString();
			sb.Clear();
			Assert.That(GetLongPathName(shfn, sb, (uint)sb.Capacity), Is.Not.Zero);
			TestContext.WriteLine($"Long: {sb}");
		}

		[Test]
		public void GetTempFileNameTest()
		{
			var sb = new StringBuilder(1024);
			Assert.That(GetTempFileName(".", "tmp", 0, sb), Is.Not.Zero);
			TestContext.WriteLine(sb);
		}

		[Test]
		public void GetTempPathTest()
		{
			var sb = new StringBuilder(1024);
			Assert.That(GetTempPath((uint)sb.Capacity, sb), Is.Not.Zero);
			TestContext.WriteLine(sb);
		}

		[Test]
		public void GetVolumeInformationByHandleWTest()
		{
			var vn = new StringBuilder(1024);
			var fsn = new StringBuilder(1024);
			using (var tmp = new TempFile(Kernel32.FileAccess.FILE_GENERIC_READ, FileShare.Read))
			{
				var b = GetVolumeInformationByHandleW(tmp.hFile, vn, (uint)vn.Capacity, out var vsn, out var mcl, out var fsf, fsn, (uint)fsn.Capacity);
				Assert.That(b, Is.True);
				Assert.That(vn.ToString(), Is.Not.Null.And.Not.Empty);
				Assert.That(vsn, Is.Not.EqualTo(0));
				Assert.That(mcl, Is.Not.EqualTo(0));
				Assert.That(fsf, Is.Not.EqualTo(0));
				Assert.That(fsn.ToString(), Is.Not.Null.And.Not.Empty);
				TestContext.WriteLine($"{vn}:{vsn}:{mcl}:{fsf}:{fsn}");
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
		public void GetVolumeNameForVolumeMountPointTest()
		{
			var sb = new StringBuilder(1024);
			Assert.That(GetVolumeNameForVolumeMountPoint(@"C:\", sb, (uint)sb.Capacity), Is.True);
			TestContext.WriteLine(sb);
		}

		[Test]
		public void GetVolumePathNamesForVolumeNameTest()
		{
			var sb = new StringBuilder(1024);
			Assert.That(GetVolumePathNamesForVolumeName(EnumVolumes().First(), sb, (uint)sb.Capacity, out var l), Is.True);
			TestContext.WriteLine(sb);
		}

		[Test]
		public void GetVolumePathNameTest()
		{
			var sb = new StringBuilder(1024);
			Assert.That(GetVolumePathName(".", sb, (uint)sb.Capacity), Is.True);
			TestContext.WriteLine(sb);
		}

		[Test]
		public unsafe void LockFileExTest()
		{
			using (var tmp = new TempFile(Kernel32.FileAccess.FILE_GENERIC_READ, FileShare.Read))
			{
				var nativeOverlapped = new NativeOverlapped();
				Assert.That(LockFileEx(tmp.hFile, LOCKFILE.LOCKFILE_FAIL_IMMEDIATELY, 0, 5, 0, &nativeOverlapped), Is.True);
				SleepEx(0, true);
				Assert.That(UnlockFileEx(tmp.hFile, 0, 5, 0, &nativeOverlapped), Is.True);
				SleepEx(0, true);
			}
		}

		[Test]
		public void LockFileTest()
		{
			using (var tmp = new TempFile(Kernel32.FileAccess.FILE_GENERIC_READ, FileShare.Read))
			{
				Assert.That(LockFile(tmp.hFile, 0, 0, 5, 0), Is.True);
				Assert.That(UnlockFile(tmp.hFile, 0, 0, 5, 0), Is.True);
			}
		}

		[Test]
		public unsafe void ReadFileExTest()
		{
			using (var tmp = new TempFile(Kernel32.FileAccess.FILE_GENERIC_READ, FileShare.Read))
			using (var sb = new SafeCoTaskMemString(100, CharSet.Ansi))
			{
				var read = 0U;
				var nativeOverlapped = new NativeOverlapped();
				var b = ReadFileEx(tmp.hFile, (byte*)(IntPtr)sb, (uint)sb.Capacity, &nativeOverlapped, fnComplete);
				if (!b) TestContext.WriteLine($"ReadFileEx:{Win32Error.GetLastError()}");
				Assert.That(b);
				SleepEx(0, true);
				//if (read < sb.Capacity) Marshal.WriteInt16((IntPtr)sb, (int)read, '\0');
				//Assert.That(read, Is.Not.Zero.And.LessThanOrEqualTo(sb.Capacity));
				//Assert.That((string)sb, Is.EqualTo(tmpstr));

				unsafe void fnComplete(uint dwErrorCode, uint dwNumberOfBytesTransfered, NativeOverlapped* lpOverlapped)
				{
					if (dwErrorCode == 0)
						GetOverlappedResult(tmp.hFile, lpOverlapped, out read, false);
					else
						read = dwNumberOfBytesTransfered;
				}
			}
		}

		[Test]
		public void SetFileInformationByHandleTest()
		{
			using (var tmp = new TempFile(Kernel32.FileAccess.FILE_ALL_ACCESS, FileShare.Read))
			{
				var fai = new FILE_ALLOCATION_INFO { AllocationSize = 512 };
				var b = SetFileInformationByHandle(tmp.hFile, FILE_INFO_BY_HANDLE_CLASS.FileAllocationInfo, fai);
				if (!b) TestContext.WriteLine($"SetFileInformationByHandle:{Win32Error.GetLastError()}");
				Assert.That(b, Is.True);
			}
		}
	}

	internal class TempFile : IDisposable
	{
		public const string tmpstr = @"Temporary";

		public TempFile(Kernel32.FileAccess dwDesiredAccess, FileShare dwShareMode, FileMode dwCreationDisposition = FileMode.OpenOrCreate, FileFlagsAndAttributes dwFlagsAndAttributes = FileFlagsAndAttributes.FILE_ATTRIBUTE_NORMAL) : this()
		{
			hFile = CreateFile(FullName, dwDesiredAccess, dwShareMode, null, dwCreationDisposition, dwFlagsAndAttributes, IntPtr.Zero);
		}

		public TempFile(string contents = tmpstr)
		{
			FullName = Path.GetTempFileName(); File.WriteAllText(FullName, contents);
		}

		public string FullName { get; }
		public SafeHFILE hFile { get; }

		void IDisposable.Dispose()
		{
			hFile?.Dispose(); File.Delete(FullName);
		}
	}
}