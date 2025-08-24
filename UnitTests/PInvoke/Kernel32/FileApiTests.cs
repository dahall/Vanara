using NUnit.Framework;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static Vanara.PInvoke.Kernel32;
using static Vanara.PInvoke.Tests.Kernel32Tests;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class FileApiTests
{
	//[Test]
	public void AsyncReadWriteTest()
	{
		string fn = Path.GetTempFileName();
		uint sz = 1024 * 1024 * 128;
		using (SafeHFILE hFile = CreateFile(fn, Kernel32.FileAccess.GENERIC_WRITE, FileShare.Write, null, FileMode.OpenOrCreate,
			FileFlagsAndAttributes.FILE_FLAG_OVERLAPPED, IntPtr.Zero))
		{
			byte[] bytes = GetBigBytes(sz, 1);
			Assert.That(bytes[1024], Is.EqualTo(1));
			new TaskFactory().FromAsync<HFILE, byte[], uint>(BeginWriteFile, EndWriteFile, hFile, bytes, (uint)bytes.Length, 1).Wait();
		}
		FileInfo fi = new(fn);
		Assert.That(fi.Exists);
		Assert.That(fi.Length, Is.EqualTo(sz));

		CREATEFILE2_EXTENDED_PARAMETERS cfp2 = new() { dwFileFlags = FileFlagsAndAttributes.FILE_FLAG_OVERLAPPED, dwSize = (uint)Marshal.SizeOf(typeof(CREATEFILE2_EXTENDED_PARAMETERS)) };
		using (SafeHFILE hFile = CreateFile2(fn, Kernel32.FileAccess.GENERIC_READ, FileShare.Read, FileMode.Open, cfp2))
		{
			byte[] bytes = GetBigBytes(sz);
			Assert.That(bytes[1024], Is.EqualTo(0));
			new TaskFactory().FromAsync<HFILE, byte[], uint>(BeginReadFile, EndReadFile, hFile, bytes, (uint)bytes.Length, 1).Wait();
			Assert.That(bytes[1024], Is.EqualTo(1));
		}

		Assert.That(DeleteFile(fn), Is.True);
	}

	[Test]
	public void CompareFileTimeTest()
	{
		FILETIME now = DateTime.Now.ToFileTimeStruct();
		FILETIME today = DateTime.Today.ToFileTimeStruct();
		Assert.That(CompareFileTime(now, today), Is.GreaterThan(0));
		Assert.That(CompareFileTime(now, now), Is.Zero);
	}

	[Test]
	public void CreateDirectoryTest()
	{
		string dir = TestCaseSources.TempChildDir;
		Assert.That(CreateDirectory(dir), Is.True);
		Assert.That(Directory.Exists(dir), Is.True);
		Assert.That(RemoveDirectory(dir), Is.True);
	}

	[Test]
	public void CreateReadFileTest()
	{
		string rofn = CreateTempFile();
		using SafeHFILE f = CreateFile(rofn, Kernel32.FileAccess.GENERIC_READ, FileShare.Read, null, FileMode.Open, FileFlagsAndAttributes.FILE_ATTRIBUTE_NORMAL, IntPtr.Zero);
		SafeCoTaskMemString sb = new(100, CharSet.Ansi);
		bool b = ReadFile(f, (IntPtr)sb, (uint)sb.Capacity, out uint read, IntPtr.Zero);
		if (!b) TestContext.WriteLine($"ReadFile:{Win32Error.GetLastError()}");
		Assert.That(b);
		if (read < sb.Capacity) Marshal.WriteInt16((IntPtr)sb, (int)read, '\0');
		Assert.That(read, Is.Not.Zero.And.LessThanOrEqualTo(sb.Capacity));
		Assert.That((string?)sb, Is.EqualTo(tmpstr));

		b = SetFilePointerEx(f, 0, out long pos, SeekOrigin.Begin);
		if (!b) TestContext.WriteLine($"SetFilePointerEx:{Win32Error.GetLastError()}");
		Assert.That(b);
		Assert.That(pos, Is.Zero);

		byte[] bytes = new byte[100];
		b = ReadFile(f, bytes, (uint)bytes.Length, out read, IntPtr.Zero);
		if (!b) TestContext.WriteLine($"ReadFile:{Win32Error.GetLastError()}");
		Assert.That(b);
		Assert.That(read, Is.Not.Zero.And.LessThanOrEqualTo(bytes.Length));
		Assert.That(Encoding.ASCII.GetString(bytes, 0, (int)read), Is.EqualTo(tmpstr));
	}

	[Test]
	public void CreateWriteFileTest()
	{
		using SafeHFILE f = CreateFile(Path.GetTempFileName(), Kernel32.FileAccess.GENERIC_WRITE, FileShare.Write, null, FileMode.OpenOrCreate, FileFlagsAndAttributes.FILE_ATTRIBUTE_NORMAL, IntPtr.Zero);
		string txt = "Some text to push.";
		byte[] bytes = txt.GetBytes(false);
		bool b = WriteFile(f, bytes, (uint)bytes.Length, out uint written, IntPtr.Zero);
		if (!b) TestContext.WriteLine($"WriteFile:{Win32Error.GetLastError()}");
		Assert.That(b);
		Assert.That(written, Is.EqualTo(bytes.Length));
		SafeCoTaskMemString ptr = new(" More text to push.");
		b = WriteFile(f, (IntPtr)ptr, (uint)ptr.Capacity, out written, IntPtr.Zero);
		if (!b) TestContext.WriteLine($"WriteFile:{Win32Error.GetLastError()}");
		Assert.That(b);
		Assert.That(written, Is.EqualTo(ptr.Capacity));
	}

	[Test]
	public void DefineDosDeviceTest()
	{
		const string src = "M:";
		string target = TestCaseSources.TempDir;

		int c = QueryDosDevice(src).ToArray().Length;
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
	public void EnumFilesExTest() => Assert.That(EnumFilesEx(@"C:\Temp\*.txt").ToArray(), Is.Not.Empty);

	[Test]
	public void EnumVolumesTest() => Assert.That(EnumVolumes().ToArray(), Is.Not.Empty);

	[Test]
	public void FileTimeToLocalFileTimeTest()
	{
		FILETIME utc = DateTime.UtcNow.ToFileTimeStruct();
		FileTimeToSystemTime(utc, out SYSTEMTIME st);
		Assert.That(FileTimeToLocalFileTime(utc, out FILETIME ftlocal), Is.True);
		FileTimeToSystemTime(ftlocal, out SYSTEMTIME stl);
		Assert.That(stl.wHour, Is.EqualTo(DateTime.Now.Hour));
		Assert.That(LocalFileTimeToFileTime(ftlocal, out FILETIME utc2), Is.True);
		Assert.That(utc.ToUInt64(), Is.EqualTo(utc2.ToUInt64()));
	}

	[Test]
	public void FindFirstChangeNotificationTest()
	{
		bool keepGoing = true;
		Thread thread = new(FileMaker);
		try
		{
			using SafeFindChangeNotificationHandle h = FindFirstChangeNotification(TestCaseSources.TempDir, false, FILE_NOTIFY_CHANGE.FILE_NOTIFY_CHANGE_FILE_NAME);
			Assert.That(h.IsInvalid, Is.False);
			thread.Start();
			Assert.That(WaitForSingleObject(h, 5000), Is.EqualTo(WAIT_STATUS.WAIT_OBJECT_0));
			Assert.That(FindNextChangeNotification(h), Is.True);
			Assert.That(WaitForSingleObject(h, 5000), Is.EqualTo(WAIT_STATUS.WAIT_OBJECT_0));
		}
		finally
		{
			keepGoing = false;
			thread.Join(650);
		}

		void FileMaker()
		{
			string fn = TestCaseSources.TempDir + @"\_tempFile.txt";
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
		bool b = GetDiskFreeSpaceEx(null, out ulong fba, out ulong tb, out ulong tfb);
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
		bool b = GetDiskFreeSpace(null, out uint spc, out uint bps, out uint fc, out uint cc);
		Assert.That(b, Is.True);
		Assert.That(spc, Is.Not.EqualTo(0));
		Assert.That(bps, Is.Not.EqualTo(0));
		Assert.That(fc, Is.Not.EqualTo(0));
		Assert.That(cc, Is.Not.EqualTo(0));
		b = GetDiskFreeSpace("Q", out spc, out bps, out fc, out cc);
		Assert.That(b, Is.False);
	}

	[Test]
	public void GetDriveTypeTest() => Assert.That(GetDriveType(null), Is.EqualTo(DRIVE_TYPE.DRIVE_FIXED));

	[Test]
	public void GetFileInformationByHandleTest()
	{
		using TempFile tmp = new(Kernel32.FileAccess.FILE_GENERIC_READ, FileShare.Read);
		Assert.That(GetFileInformationByHandle(tmp.hFile!, out BY_HANDLE_FILE_INFORMATION fi), Is.True);
		Assert.That(fi.nFileSizeLow, Is.EqualTo(tmpstr.Length));
	}

	[Test]
	public void GetFileSizeTest()
	{
		using TempFile tmp = new(Kernel32.FileAccess.FILE_GENERIC_READ, FileShare.Read);
		Assert.That(GetFileSize(tmp.hFile!, out uint hw), Is.EqualTo(TempFile.tmpstr.Length));
		Assert.That(hw, Is.Zero);
		Assert.That(GetFileSizeEx(tmp.hFile!, out long sz), Is.True);
		Assert.That(sz, Is.EqualTo(TempFile.tmpstr.Length));
	}

	[Test]
	public void GetFileTypeTest()
	{
		using TempFile tmp = new(Kernel32.FileAccess.FILE_GENERIC_READ, FileShare.Read);
		Assert.That(GetFileType(tmp.hFile!), Is.EqualTo(FileType.FILE_TYPE_DISK));
	}

	[Test]
	public void GetFinalPathNameByHandleTest()
	{
		StringBuilder sb = new(MAX_PATH);
		using TempFile tmp = new(Kernel32.FileAccess.FILE_GENERIC_READ, FileShare.Read);
		uint u = GetFinalPathNameByHandle(tmp.hFile!, sb, MAX_PATH, FinalPathNameOptions.FILE_NAME_NORMALIZED);
		Assert.That(u, Is.Not.Zero);
		TestContext.WriteLine(sb);
	}

	[Test]
	public void GetFullPathNameTest()
	{
		var sb = GetFullPathName("notepad.exe", out var idx);
		Assert.That(idx, Is.Not.Zero);
		TestContext.WriteLine(sb);
	}

	[Test]
	public void GetLogicalDrivesTest() => Assert.That(GetLogicalDrives(), Is.Not.Zero);

	[Test]
	public void GetLogicalDriveStringsTest()
	{
		System.Collections.Generic.IEnumerable<string> ie = Enumerable.Empty<string>();
		Assert.That(ie = GetLogicalDriveStrings(), Is.Not.Empty);
		ie.WriteValues();
	}

	[Test]
	public void GetSetFileAttributesTest()
	{
		using TempFile tmp = new();
		FileFlagsAndAttributes attr = FileFlagsAndAttributes.FILE_ATTRIBUTE_ARCHIVE | FileFlagsAndAttributes.FILE_ATTRIBUTE_TEMPORARY;
		Assert.That(SetFileAttributes(tmp.FullName, attr), Is.True);
		Assert.That(GetFileAttributes(tmp.FullName), Is.EqualTo(attr));
		Assert.That(GetFileAttributesEx(tmp.FullName, GET_FILEEX_INFO_LEVELS.GetFileExInfoStandard, out WIN32_FILE_ATTRIBUTE_DATA fi), Is.True);
		Assert.That(fi.dwFileAttributes, Is.EqualTo(attr));
	}

	[Test]
	public void GetSetFileTimeTest()
	{
		using TempFile tmp = new(Kernel32.FileAccess.FILE_ALL_ACCESS, FileShare.Read);
		Assert.That(GetFileTime(tmp.hFile!, out FILETIME ft1, out FILETIME ft2, out FILETIME ft3), Is.True);
		FILETIME nft = DateTime.UtcNow.ToFileTimeStruct();
		bool b = SetFileTime(tmp.hFile!, ft1, ft2, nft);
		if (!b) TestContext.WriteLine($"SetFileTime:{Win32Error.GetLastError()}");
		Assert.That(b, Is.True);
		Assert.That(GetFileTime(tmp.hFile!, out FILETIME nft1, out FILETIME nft2, out FILETIME nft3), Is.True);
		Assert.That(ft1, Is.EqualTo(nft1));
		Assert.That(nft, Is.EqualTo(nft3));
	}

	[Test]
	public void GetShortLongPathNameTest()
	{
		StringBuilder sb = new(1024);
		Assert.That(GetShortPathName(GetType().Assembly.Location, sb, (uint)sb.Capacity), Is.Not.Zero);
		TestContext.WriteLine($"Short: {sb}");
		string shfn = sb.ToString();
		sb.Clear();
		Assert.That(GetLongPathName(shfn, sb, (uint)sb.Capacity), Is.Not.Zero);
		TestContext.WriteLine($"Long: {sb}");
	}

	[Test]
	public void GetTempFileNameTest()
	{
		StringBuilder sb = new(1024);
		Assert.That(GetTempFileName(".", "tmp", 0, sb), Is.Not.Zero);
		TestContext.WriteLine(sb);
	}

	[Test]
	public void GetTempPathTest()
	{
		StringBuilder sb = new(1024);
		Assert.That(GetTempPath((uint)sb.Capacity, sb), Is.Not.Zero);
		TestContext.WriteLine(sb);
	}

	[Test]
	public void GetVolumeInformationByHandleWTest()
	{
		StringBuilder vn = new(1024);
		StringBuilder fsn = new(1024);
		using TempFile tmp = new(Kernel32.FileAccess.FILE_GENERIC_READ, FileShare.Read);
		bool b = GetVolumeInformationByHandleW(tmp.hFile!, vn, (uint)vn.Capacity, out uint vsn, out uint mcl, out FileSystemFlags fsf, fsn, (uint)fsn.Capacity);
		Assert.That(b, Is.True);
		Assert.That(vn.ToString(), Is.Not.Null.And.Not.Empty);
		Assert.That(vsn, Is.Not.EqualTo(0));
		Assert.That(mcl, Is.Not.EqualTo(0));
		Assert.That(fsf, Is.Not.EqualTo(0));
		Assert.That(fsn.ToString(), Is.Not.Null.And.Not.Empty);
		TestContext.WriteLine($"{vn}:{vsn}:{mcl}:{fsf}:{fsn}");
	}

	[Test]
	public void GetVolumeInformationTest()
	{
		bool b = GetVolumeInformation(null, out string vn, out uint vsn, out uint mcl, out FileSystemFlags fsf, out string fsn);
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
		StringBuilder sb = new(1024);
		Assert.That(GetVolumeNameForVolumeMountPoint(@"C:\", sb, (uint)sb.Capacity), Is.True);
		TestContext.WriteLine(sb);
	}

	[Test]
	public void GetVolumePathNamesForVolumeNameTest()
	{
		Assert.That(GetVolumePathNamesForVolumeName(EnumVolumes().First(), out var sb), Is.True);
		TestContext.WriteLine(string.Join("\n", sb));
	}

	[Test]
	public void GetVolumePathNameTest()
	{
		StringBuilder sb = new(1024);
		Assert.That(GetVolumePathName(".", sb, (uint)sb.Capacity), Is.True);
		TestContext.WriteLine(sb);
	}

	[Test]
	public unsafe void LockFileExTest()
	{
		using TempFile tmp = new(Kernel32.FileAccess.FILE_GENERIC_READ, FileShare.Read);
		NativeOverlapped nativeOverlapped = new();
		Assert.That(LockFileEx(tmp.hFile!, LOCKFILE.LOCKFILE_FAIL_IMMEDIATELY, 0, 5, 0, &nativeOverlapped), Is.True);
		SleepEx(0, true);
		Assert.That(UnlockFileEx(tmp.hFile!, 0, 5, 0, &nativeOverlapped), Is.True);
		SleepEx(0, true);
	}

	[Test]
	public void LockFileTest()
	{
		using TempFile tmp = new(Kernel32.FileAccess.FILE_GENERIC_READ, FileShare.Read);
		Assert.That(LockFile(tmp.hFile!, 0, 0, 5, 0), Is.True);
		Assert.That(UnlockFile(tmp.hFile!, 0, 0, 5, 0), Is.True);
	}

	[Test]
	public unsafe void ReadFileExTest()
	{
		using TempFile tmp = new(Kernel32.FileAccess.FILE_GENERIC_READ, FileShare.Read);
		using SafeCoTaskMemString sb = new(100, CharSet.Ansi);
		uint read = 0U;
		NativeOverlapped nativeOverlapped = new();
		bool b = ReadFileEx(tmp.hFile!, (byte*)(IntPtr)sb, (uint)sb.Capacity, &nativeOverlapped, fnComplete);
		if (!b) TestContext.WriteLine($"ReadFileEx:{Win32Error.GetLastError()}");
		Assert.That(b);
		SleepEx(0, true);
		//if (read < sb.Capacity) Marshal.WriteInt16((IntPtr)sb, (int)read, '\0');
		//Assert.That(read, Is.Not.Zero.And.LessThanOrEqualTo(sb.Capacity));
		//Assert.That((string)sb, Is.EqualTo(tmpstr));

		unsafe void fnComplete(uint dwErrorCode, uint dwNumberOfBytesTransfered, NativeOverlapped* lpOverlapped)
		{
			if (dwErrorCode == 0)
				GetOverlappedResult(tmp.hFile!, lpOverlapped, out read, false);
			else
				read = dwNumberOfBytesTransfered;
		}
	}

	[Test]
	public void SetFileInformationByHandleTest()
	{
		using TempFile tmp = new(Kernel32.FileAccess.FILE_ALL_ACCESS, FileShare.Read);
		FILE_ALLOCATION_INFO fai = new() { AllocationSize = 512 };
		bool b = SetFileInformationByHandle(tmp.hFile!, FILE_INFO_BY_HANDLE_CLASS.FileAllocationInfo, fai);
		if (!b) TestContext.WriteLine($"SetFileInformationByHandle:{Win32Error.GetLastError()}");
		Assert.That(b, Is.True);
	}
}