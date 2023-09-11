using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Collections.Generic;
using System.IO;
using Vanara.RunTimeLib;
using static Vanara.PInvoke.Cabinet;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class FDITests
{
	private const string cabfn = "test.cab";
	private static readonly string cabdir = TestCaseSources.TempDirWhack;
	private ERF fderf = new();
	private SafeHFDI? hfdi;

	[OneTimeSetUp]
	public void _Setup()
	{
		hfdi = FDICreate(AllocCallback, FreeCallback, OpenCallback, ReadCallback, WriteCallback, CloseCallback, SeekCallback, FDICPU.cpuUNKNOWN, ref fderf);
	}

	[OneTimeTearDown]
	public void _TearDown()
	{
		hfdi?.Dispose();
	}

	[Test]
	public void FCICreateTest()
	{
		SafeHFCI h;
		ERF myerf = new();
		using var tmp = new TempFile(null);
		CCAB ccab = new(tmp.FullName);
		Assert.That(h = FCICreate(ref myerf, FilePlacedCallback, AllocCallback, FreeCallback, FcOpenCallback, FcReadCallback, FcWriteCallback, FcCloseCallback, FcSeekCallback, DeleteCallback, GetTemplateCallback, ccab), ResultIs.ValidHandle);

		Assert.That(FCIAddFile(h, TestCaseSources.SmallFile, Path.GetFileName(TestCaseSources.SmallFile), false, FcGetNextCab, FcStatus, FcGetOpenInfo, TCOMP.tcompTYPE_MSZIP), ResultIs.Successful);
		Assert.That(FCIAddFile(h, TestCaseSources.ImageFile, Path.GetFileName(TestCaseSources.ImageFile), false, FcGetNextCab, FcStatus, FcGetOpenInfo, TCOMP.tcompTYPE_MSZIP), ResultIs.Successful);
		Assert.That(FCIAddFile(h, TestCaseSources.WordDoc, Path.GetFileName(TestCaseSources.WordDoc), false, FcGetNextCab, FcStatus, FcGetOpenInfo, TCOMP.tcompTYPE_MSZIP), ResultIs.Successful);

		Assert.That(FCIFlushFolder(h, FcGetNextCab, FcStatus), ResultIs.Successful);

		Assert.That(FCIFlushCabinet(h, false, FcGetNextCab, FcStatus), ResultIs.Successful);

		Assert.That(() => h?.Dispose(), Throws.Nothing);

		Assert.That(File.Exists(tmp.FullName), Is.True);
	}

	[Test, MTAThread]
	public void FDICopyTest()
	{
		List<string> files = new();
		Assert.That(FDICopy(hfdi!, cabfn, cabdir, 0, Notify), Is.True);
		Assert.That(files.Count, Is.GreaterThan(0));
		files.WriteValues();

		IntPtr Notify(FDINOTIFICATIONTYPE fdint, ref FDINOTIFICATION pfdin)
		{
			switch (fdint)
			{
				case FDINOTIFICATIONTYPE.fdintCOPY_FILE:
					files.Add($"{pfdin.psz1} : {pfdin.cb} : {pfdin.DateTime}");
					break;

				default:
					break;
			}
			return IntPtr.Zero;
		}
	}

	[Test]
	public void FDICreateTest()
	{
		SafeHFDI h;
		ERF myerf = new();
		Assert.That(h = FDICreate(AllocCallback, FreeCallback, OpenCallback, ReadCallback, WriteCallback, CloseCallback, SeekCallback, FDICPU.cpuUNKNOWN, ref myerf), ResultIs.ValidHandle);
		Assert.That(() => h?.Dispose(), Throws.Nothing);
	}

	private IntPtr AllocCallback(uint cb) => Marshal.AllocHGlobal((int)cb);

	private int CloseCallback(IntPtr hf) => FcCloseCallback(hf, out _, default);

	private int DeleteCallback(string pszFile, out int err, IntPtr pv)
	{
		if (DeleteFile(pszFile))
		{
			err = 0;
			return 0;
		}
		else
		{
			err = (int)(uint)GetLastError();
			return -1;
		}
	}

	private int FcCloseCallback(IntPtr hf, out int err, IntPtr pv)
	{
		err = 0;
		if (CloseHandle(hf))
			return 0;
		err = (int)(uint)GetLastError();
		return -1;
	}

	private bool FcGetNextCab(ref CCAB pccab, uint cbPrevCab, IntPtr pv) => true;

	private IntPtr FcGetOpenInfo(string pszName, ref ushort pdate, ref ushort ptime, ref ushort pattribs, out int err, IntPtr pv)
	{
		err = 0;
		var handle = CreateFile(pszName, Kernel32.FileAccess.GENERIC_READ, FileShare.ReadWrite, default, FileMode.Open, 0, default);
		if (handle.IsInvalid)
		{
			err = (int)(uint)GetLastError();
			return new IntPtr(-1);
		}
		if (!GetFileInformationByHandle(handle, out var info))
		{
			err = (int)(uint)GetLastError();
			handle.Dispose();
			return new IntPtr(-1);
		}
		FileTimeToDosDateTime(info.ftLastWriteTime, out pdate, out ptime);
		pattribs = (ushort)(info.dwFileAttributes & (FileFlagsAndAttributes.FILE_ATTRIBUTE_READONLY | FileFlagsAndAttributes.FILE_ATTRIBUTE_HIDDEN | FileFlagsAndAttributes.FILE_ATTRIBUTE_SYSTEM | FileFlagsAndAttributes.FILE_ATTRIBUTE_ARCHIVE));
		return handle.ReleaseOwnership();
	}

	private IntPtr FcOpenCallback(string pszFile, FileOpConstant oflag, FilePermissionConstant pmode, out int err, IntPtr pv)
	{
		FileMode creation;
		FileShare sharing = pmode.ToFileShare();
		Kernel32.FileAccess ioflag = 0;

		switch (oflag & (FileOpConstant)0x03)
		{
			case FileOpConstant._O_RDONLY: ioflag |= Kernel32.FileAccess.GENERIC_READ; break;
			case FileOpConstant._O_WRONLY: ioflag |= Kernel32.FileAccess.GENERIC_WRITE; break;
			case FileOpConstant._O_RDWR: ioflag |= Kernel32.FileAccess.GENERIC_READ | Kernel32.FileAccess.GENERIC_WRITE; break;
		}

		if (oflag.IsFlagSet(FileOpConstant._O_CREAT))
		{
			if (oflag.IsFlagSet(FileOpConstant._O_EXCL)) creation = FileMode.CreateNew;
			else if (oflag.IsFlagSet(FileOpConstant._O_TRUNC)) creation = FileMode.Create;
			else creation = FileMode.OpenOrCreate;
		}
		else
		{
			if (oflag.IsFlagSet(FileOpConstant._O_TRUNC)) creation = FileMode.Create;
			else creation = FileMode.Open;
		}

		var hfile = CreateFile(pszFile, ioflag, sharing, default, creation, FileFlagsAndAttributes.FILE_ATTRIBUTE_NORMAL, default).ReleaseOwnership();
		err = hfile == HFILE.INVALID_HANDLE_VALUE ? (int)(uint)GetLastError() : 0;
		return hfile == HFILE.INVALID_HANDLE_VALUE ? IntPtr.Zero : hfile;
	}

	private uint FcReadCallback(IntPtr hf, IntPtr memory, uint cb, out int err, IntPtr pv)
	{
		err = 0;
		if (ReadFile(hf, memory, cb, out var read))
			return read;
		err = (int)(uint)GetLastError();
		return unchecked((uint)-1);
	}

	private int FcSeekCallback(IntPtr hf, int dist, SeekOrigin seektype, out int err, IntPtr pv)
	{
		var ret = SetFilePointer(hf, dist, default, seektype);
		if (ret == INVALID_SET_FILE_POINTER)
		{
			err = (int)(uint)GetLastError();
			return -1;
		}
		err = 0;
		return unchecked((int)ret);
	}

	private int FcStatus(CabinetFileStatus typeStatus, uint cb1, uint cb2, IntPtr pv) => 0;

	private uint FcWriteCallback(IntPtr hf, IntPtr memory, uint cb, out int err, IntPtr pv)
	{
		err = 0;
		if (WriteFile(hf, memory, cb, out var written))
			return written;
		err = (int)(uint)GetLastError();
		return unchecked((uint)-1);
	}

	private int FilePlacedCallback(ref CCAB pccab, string pszFile, int cbFile, bool fContinuation, IntPtr pv)
	{
		if (!fContinuation)
			TestContext.WriteLine($"Adding {pszFile}...");
		return 0;
	}

	private void FreeCallback(IntPtr memory) => Marshal.FreeHGlobal(memory);

	private bool GetTemplateCallback(IntPtr pszTempName, int cbTempName, IntPtr pv)
	{
		var sb = new StringBuilder(1024);
		GetTempFileName(Path.GetTempPath(), "cab", 0, sb);
		if (sb.Length >= cbTempName)
			return false;
		Marshal.Copy(StringHelper.GetBytes(sb.ToString(), true, CharSet.Ansi), 0, pszTempName, sb.Length + 1);
		return DeleteFile(sb.ToString());
	}

	private IntPtr OpenCallback(string pszFile, FileOpConstant oflag, FilePermissionConstant pmode) => FcOpenCallback(pszFile, oflag, pmode, out _, default);

	private uint ReadCallback(IntPtr hf, IntPtr memory, uint cb) => FcReadCallback(hf, memory, cb, out _, default);

	private int SeekCallback(IntPtr hf, int dist, SeekOrigin seektype) => FcSeekCallback(hf, dist, seektype, out _, default);

	private uint WriteCallback(IntPtr hf, IntPtr memory, uint cb) => FcWriteCallback(hf, memory, cb, out _, default);
}