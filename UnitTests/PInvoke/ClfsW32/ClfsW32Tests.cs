using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Runtime.InteropServices;
using System.Threading;
using static Vanara.PInvoke.ClfsW32;

namespace Vanara.PInvoke.Tests;
[TestFixture]
public class ClfsW32Tests
{
	[OneTimeSetUp]
	public void _Setup()
	{
	}

	[OneTimeTearDown]
	public void _TearDown()
	{
	}

	[Test]
	public void Test()
	{
		const string fnbase = @"C:\Temp\testlog";
		const string fn = @"log:" + fnbase;
		System.IO.File.Delete(fnbase + CLFS_BASELOG_EXTENSION);

		using var hLog = CreateLogFile(fn, ACCESS_MASK.GENERIC_WRITE | ACCESS_MASK.GENERIC_READ | ACCESS_MASK.DELETE, System.IO.FileShare.Read, null, Kernel32.CreationOption.OPEN_ALWAYS, FileFlagsAndAttributes.FILE_FLAG_OVERLAPPED);
		Assert.That(hLog, ResultIs.ValidHandle);
		CLS_SCAN_CONTEXT ctx = default;
		string cName = Guid.NewGuid().ToString("N");
		try
		{
			ThreadPool.BindHandle(hLog);

			Assert.That(AddLogContainer(hLog, 512 * 1024, cName), ResultIs.Successful);

			CLS_INFORMATION info = default;
			uint sz = (uint)Marshal.SizeOf(info);
			Assert.That(GetLogFileInformation(hLog, ref info, ref sz), ResultIs.Successful);
			info.WriteValues();
			Assert.That(info.TotalContainers, Is.GreaterThan(0U));

			Assert.That(CreateLogContainerScanContext(hLog, 0, info.TotalContainers, CLFS_SCAN_MODE.CLFS_SCAN_FORWARD, ref ctx), ResultIs.Successful);
			ctx.WriteValues();
		}
		finally
		{
			RemoveLogContainer(hLog, cName, true);
			Assert.That(() => hLog.Dispose(), Throws.Nothing);
			if (ctx.cContainersReturned > 0)
				Assert.That(ScanLogContainers(ref ctx, CLFS_SCAN_MODE.CLFS_SCAN_CLOSE), ResultIs.Successful);
			Win32Error.ThrowLastErrorIfFalse(DeleteLogFile(fn));
		}
	}
}