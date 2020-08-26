using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.Kernel32;
using FileAccess = Vanara.PInvoke.Kernel32.FileAccess;

namespace Vanara.PInvoke.Tests
{
	[TestFixture]
	public partial class WinBaseTests_File
	{
		private static readonly string bigfn = TestCaseSources.LargeFile;
		private static readonly string fn = TestCaseSources.SmallFile;
		private const string newfn = @"C:\Temp\help2.ico";

		[Test]
		public void AreSetFileApisTest()
		{
			var ansi = false;
			Assert.That(() => ansi = AreFileApisANSI(), Throws.Nothing);
			if (ansi) SetFileApisToOEM(); else SetFileApisToANSI();
			Assert.That(AreFileApisANSI(), Is.EqualTo(!ansi));
			if (ansi) SetFileApisToANSI(); else SetFileApisToOEM();
		}

		[Test]
		public void CheckNameLegalDOS8Dot3Test()
		{
			Assert.That(CheckNameLegalDOS8Dot3("FRED.DOC", null, 0, out _, out var legal), ResultIs.Successful);
			Assert.That(legal, Is.True);

			var sb = new StringBuilder(50);
			Assert.That(CheckNameLegalDOS8Dot3("FRED IS MY FRIEND.DOC", sb, (uint)sb.Capacity, out var sp, out legal), ResultIs.Successful);
			Assert.That(legal, Is.False);
			TestContext.Write(sb);
		}

		[Test]
		public void CopyFile2Test()
		{
			var par = COPYFILE2_EXTENDED_PARAMETERS.Default;
			par.dwCopyFlags = COPY_FILE.COPY_FILE_RESTARTABLE;
			Assert.That(CopyFile2(fn, newfn, ref par), ResultIs.Successful);
			Assert.That(DeleteFile(newfn), Is.True);
		}

		[Test]
		public void CopyFileExTest()
		{
			Assert.That(CopyFileEx(fn, newfn, null, default, false, COPY_FILE.COPY_FILE_RESTARTABLE), ResultIs.Successful);
			Assert.That(DeleteFile(newfn), Is.True);
		}

		[Test]
		public void CopyFileTest()
		{
			Assert.That(CopyFile(fn, newfn, false), ResultIs.Successful);
			Assert.That(DeleteFile(newfn), Is.True);
		}

		[Test]
		public void CreateDirectoryExTest()
		{
			Assert.That(CreateDirectoryEx(TestCaseSources.TempDir, TestCaseSources.TempChildDir), ResultIs.Successful);
			Assert.That(RemoveDirectory(TestCaseSources.TempChildDir), ResultIs.Successful);
		}

		[Test]
		public void CreateEnumHardLinkTest()
		{
			DeleteFile(newfn);
			Assert.That(CreateHardLink(newfn, fn), ResultIs.Successful);
			Assert.That(EnumHardLinks(fn), Contains.Item(newfn.Substring(2)));
			Assert.That(DeleteFile(newfn), Is.True);
		}

		[Test]
		public void CreateSymbolicLinkTest()
		{
			Assert.That(CreateSymbolicLink(newfn, fn, SymbolicLinkType.SYMBOLIC_LINK_FLAG_FILE), ResultIs.Successful);
			Assert.That(DeleteFile(newfn), Is.True);
		}

		[Test]
		public void EnumFileStreamsTest()
		{
			using (var tmp = new TempFile())
			{
				using (var str = CreateFile(tmp.FullName + ":stream1", FileAccess.GENERIC_WRITE, FileShare.Write, null, FileMode.OpenOrCreate, 0))
					WriteFile(str, Encoding.Unicode.GetBytes("Hello"), 12, out var written);
				using (var str = CreateFile(tmp.FullName + ":stream2", FileAccess.GENERIC_WRITE, FileShare.Write, null, FileMode.OpenOrCreate, 0))
					WriteFile(str, Encoding.Unicode.GetBytes("Bye"), 8, out var written);
				Assert.That(EnumFileStreams(tmp.FullName).ToArray(), Is.Not.Empty);
			}
		}

		[Test]
		public void EnumVolumeMountPointsTest()
		{
			// Setup a new mount on C:
			string mntDir = TestCaseSources.TempDirWhack + @"Mounted\";
			var sb = new StringBuilder(100);
			Assert.That(GetVolumeNameForVolumeMountPoint(@"C:\", sb, (uint)sb.Capacity), ResultIs.Successful);
			var cvol = sb.ToString();
			Assert.That(GetVolumeNameForVolumeMountPoint(@"D:\", sb, (uint)sb.Capacity), ResultIs.Successful);
			var dvol = sb.ToString();
			Assert.That(CreateDirectory(mntDir), ResultIs.Successful);
			Assert.That(SetVolumeMountPoint(mntDir, dvol), ResultIs.Successful);

			try
			{
				Assert.That(EnumVolumeMountPoints(cvol).ToArray(), Contains.Item(mntDir.Substring(3)));
			}
			finally
			{
				// Remove mount
				DeleteVolumeMountPoint(mntDir);
				RemoveDirectory(mntDir);
			}
		}

		[Test]
		public void GetCompressedFileSizeTest()
		{
			Assert.That(GetCompressedFileSize(fn, out ulong sz), ResultIs.Successful);
			Assert.That(sz, Is.GreaterThan(0));

			Assert.That(() => GetCompressedFileSize(fn), Throws.Nothing);
			Assert.That(() => GetCompressedFileSize(@"C:\NoFile.txt"), Throws.Exception);
		}

		[Test]
		public void GetFileInformationByHandleExTest()
		{
			using (var tmp = new TempFile(FileAccess.GENERIC_READ, FileShare.Read))
			using (var hDir = CreateFile(TestCaseSources.TempDirWhack, FileAccess.GENERIC_READ, FileShare.Read, null, FileMode.Open, FileFlagsAndAttributes.FILE_FLAG_BACKUP_SEMANTICS))
			{
				var exes = new List<Exception>();
				TestHelper.RunForEach<FILE_INFO_BY_HANDLE_CLASS>(typeof(Kernel32), "GetFileInformationByHandleEx", e => new object[] { IsDir(e) ? (HFILE)hDir : (HFILE)tmp.hFile, e },
					(e, ex) => { ex.Source = e.ToString(); exes.Add(ex); }, (e, ret, param) => ret.WriteValues(), CorrespondingAction.Get);
				if (exes.Count > 0)
					throw new AggregateException(exes.ToArray());
			}

			bool IsDir(FILE_INFO_BY_HANDLE_CLASS e) => e == FILE_INFO_BY_HANDLE_CLASS.FileFullDirectoryInfo || e == FILE_INFO_BY_HANDLE_CLASS.FileFullDirectoryRestartInfo || e == FILE_INFO_BY_HANDLE_CLASS.FileIdBothDirectoryInfo ||
				e == FILE_INFO_BY_HANDLE_CLASS.FileIdBothDirectoryRestartInfo || e == FILE_INFO_BY_HANDLE_CLASS.FileIdExtdDirectoryInfo || e == FILE_INFO_BY_HANDLE_CLASS.FileIdExtdDirectoryRestartInfo;
		}

		[Test]
		public void GetSetFileBandwidthReservationTest()
		{
			using (var tmp = new TempFile(FileAccess.GENERIC_READ, FileShare.Read))
			{
				// This shouldn't work on NTFS vols.
				Assert.That(GetFileBandwidthReservation(tmp.hFile, out var per, out var bpp, out var disc, out var tsz, out var reqs), ResultIs.FailureCode(Win32Error.ERROR_INVALID_FUNCTION));
				Assert.That(SetFileBandwidthReservation(tmp.hFile, per, bpp, disc, out tsz, out reqs), ResultIs.FailureCode(Win32Error.ERROR_INVALID_FUNCTION));
			}
		}

		[Test]
		public void MoveFileExTest()
		{
			string newFld = TestCaseSources.TempChildDir;
			Assert.That(MoveFileEx(fn, Path.Combine(newFld, Path.GetFileName(fn)), MOVEFILE.MOVEFILE_REPLACE_EXISTING), ResultIs.Successful);
			Assert.That(MoveFileEx(Path.Combine(newFld, Path.GetFileName(fn)), fn, MOVEFILE.MOVEFILE_REPLACE_EXISTING), ResultIs.Successful);
		}

		[Test]
		public void MoveFileTest()
		{
			string newFld = TestCaseSources.TempChildDir;
			Assert.That(MoveFile(fn, Path.Combine(newFld, Path.GetFileName(fn))), ResultIs.Successful);
			Assert.That(MoveFile(Path.Combine(newFld, Path.GetFileName(fn)), fn), ResultIs.Successful);
		}

		[Test]
		public void MoveFileWithProgressTest()
		{
			string newFld = TestCaseSources.TempChildDir;
			var qtr = 0;
			Assert.That(MoveFileWithProgress(bigfn, Path.Combine(newFld, Path.GetFileName(bigfn)), fProgress, default, MOVEFILE.MOVEFILE_REPLACE_EXISTING), ResultIs.Successful);
			Assert.That(MoveFileWithProgress(Path.Combine(newFld, Path.GetFileName(bigfn)), bigfn, fProgress, default, MOVEFILE.MOVEFILE_REPLACE_EXISTING), ResultIs.Successful);

			CopyProgressResult fProgress(long TotalFileSize, long TotalBytesTransferred, long StreamSize, long StreamBytesTransferred, uint dwStreamNumber, COPY_CALLBACK_REASON dwCallbackReason, IntPtr hSourceFile, IntPtr hDestinationFile, IntPtr lpData)
			{
				var prct = TotalBytesTransferred * 100 / TotalFileSize;
				if (prct / 25 + 1 > qtr) { TestContext.WriteLine($"{++qtr}/4 Complete: {StreamSize}, {dwStreamNumber}, {dwCallbackReason}"); }
				return CopyProgressResult.PROGRESS_CONTINUE;
			}
		}

		[Test]
		public void OpenFileTest()
		{
			var buf = OFSTRUCT.Default;
			SafeHFILE hFile;
			Assert.That(hFile = OpenFile(fn, ref buf, OpenFileAction.OF_READ), ResultIs.ValidHandle);
			hFile.Dispose();
		}

		[Test]
		public unsafe void ReadDirectoryChangesExWTest()
		{
			var newFile = Path.Combine(Path.GetDirectoryName(fn), "X.ico");
			using (var hDir = CreateFile(TestCaseSources.TempDirWhack, FileAccess.GENERIC_READ, FileShare.Read, null, FileMode.Open, FileFlagsAndAttributes.FILE_FLAG_BACKUP_SEMANTICS))
			using (var mem = new SafeHGlobalHandle(4096))
			{
				new Thread(() => { Sleep(100); DeleteFile(newFile); CopyFile(fn, newFile, false); DeleteFile(newFile); }).Start();
				Assert.That(ReadDirectoryChangesExW(hDir, (IntPtr)mem, (uint)mem.Size, true, FILE_NOTIFY_CHANGE.FILE_NOTIFY_CHANGE_FILE_NAME, out var ret, null, complete, READ_DIRECTORY_NOTIFY_INFORMATION_CLASS.ReadDirectoryNotifyExtendedInformation), ResultIs.Successful);
				Assert.That(ret, Is.GreaterThan(0));
				var list = new List<FILE_NOTIFY_EXTENDED_INFORMATION>();
				var nxt = 0U;
				do
				{
					var i = mem.DangerousGetHandle().Offset(nxt).ToStructure<FILE_NOTIFY_EXTENDED_INFORMATION>();
					i.FileName = StringHelper.GetString(mem.DangerousGetHandle().Offset(nxt + 76), CharSet.Unicode, i.FileNameLength);
					nxt += i.NextEntryOffset;
					list.Add(i);
				} while (nxt > 0);
				list.WriteValues();
			}

			void complete(uint dwErrorCode, uint dwNumberOfBytesTransfered, NativeOverlapped* lpOverlapped)
			{
				TestContext.WriteLine($"{dwErrorCode}, {dwNumberOfBytesTransfered}");
			}
		}

		[Test]
		public void ReadDirectoryChangesTest()
		{
			var newFile = Path.Combine(Path.GetDirectoryName(fn), "X.ico");
			using (var hDir = CreateFile(TestCaseSources.TempDirWhack, FileAccess.GENERIC_READ, FileShare.Read, null, FileMode.Open, FileFlagsAndAttributes.FILE_FLAG_BACKUP_SEMANTICS))
			using (var mem = new SafeHGlobalHandle(4096))
			{
				new Thread(() => { Sleep(100); DeleteFile(newFile); CopyFile(fn, newFile, false); DeleteFile(newFile); }).Start();
				Assert.That(ReadDirectoryChanges(hDir, (IntPtr)mem, (uint)mem.Size, true, FILE_NOTIFY_CHANGE.FILE_NOTIFY_CHANGE_FILE_NAME, out var ret, IntPtr.Zero, complete), ResultIs.Successful);
				Assert.That(ret, Is.GreaterThan(0));
				var list = new List<FILE_NOTIFY_INFORMATION>();
				var nxt = 0U;
				do
				{
					var i = mem.DangerousGetHandle().Offset(nxt).ToStructure<FILE_NOTIFY_INFORMATION>();
					i.FileName = StringHelper.GetString(mem.DangerousGetHandle().Offset(nxt + 12), CharSet.Unicode, i.FileNameLength);
					nxt += i.NextEntryOffset;
					list.Add(i);
				} while (nxt > 0);
				list.WriteValues();
			}

			void complete(uint dwErrorCode, uint dwNumberOfBytesTransfered, IntPtr lpOverlapped)
			{
				TestContext.WriteLine($"{dwErrorCode}, {dwNumberOfBytesTransfered}");
			}
		}

		[Test]
		public void ReOpenFileTest()
		{
			using (var tmp = new TempFile(FileAccess.GENERIC_WRITE, FileShare.Read))
			{
				Assert.That(tmp, ResultIs.ValidHandle);
				using (var hRe = ReOpenFile(tmp.hFile, FileAccess.GENERIC_READ, FileShare.ReadWrite, 0))
					Assert.That(hRe, ResultIs.ValidHandle);
			}
		}

		[Test]
		public void ReplaceFileTest()
		{
			Assert.That(CopyFile(fn, newfn, false), ResultIs.Successful);
			Assert.That(ReplaceFile(newfn, TestCaseSources.BmpFile), ResultIs.Successful);
			Assert.That(DeleteFile(newfn), ResultIs.Successful);
		}

		[Test]
		public void SetFileCompletionNotificationModesTest()
		{
			using (var tmp = new TempFile(FileAccess.GENERIC_WRITE, FileShare.Read, FileMode.Create, FileFlagsAndAttributes.FILE_FLAG_OVERLAPPED))
				Assert.That(SetFileCompletionNotificationModes(tmp.hFile, FILE_NOTIFICATION_MODE.FILE_SKIP_SET_EVENT_ON_HANDLE), ResultIs.Successful);
		}

		[Test]
		public void SetFileIoOverlappedRangeTest()
		{
			using (var priv = new ElevPriv("SeLockMemoryPrivilege"))
			using (var tmp = new TempFile(FileAccess.FILE_READ_ATTRIBUTES | FileAccess.GENERIC_READ, FileShare.Read, FileMode.Create, FileFlagsAndAttributes.FILE_FLAG_OVERLAPPED | FileFlagsAndAttributes.FILE_FLAG_NO_BUFFERING))
			using (var mem = new AlignedMemory<HGlobalMemoryMethods>(1024, 1024))
				Assert.That(SetFileIoOverlappedRange(tmp.hFile, mem, (uint)mem.Size), ResultIs.Failure); // Not sure why I'm having permissions problems.
		}

		[Test]
		public void SetFileShortNameTest()
		{
			using (new ElevPriv("SeRestorePrivilege"))
			using (var tmp = new TempFile(FileAccess.GENERIC_ALL, FileShare.ReadWrite, dwFlagsAndAttributes: FileFlagsAndAttributes.FILE_FLAG_BACKUP_SEMANTICS))
				Assert.That(SetFileShortName(tmp.hFile, "SN.TXT"), ResultIs.Successful);
		}

		[Test]
		public void SetVolumeLabelTest()
		{
			Assert.That(GetVolumeInformation(null, out var curName, out _, out _, out _, out _), ResultIs.Successful);
			Assert.That(SetVolumeLabel(null, "TempTestVol"), ResultIs.Successful);
			Assert.That(SetVolumeLabel(null, curName), ResultIs.Successful);
		}
	}
}