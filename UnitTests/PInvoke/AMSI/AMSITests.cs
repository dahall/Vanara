using NUnit.Framework;
using NUnit.Framework.Internal;
using System.IO;
using static Vanara.PInvoke.AMSI;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class AMSITests
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
	public void AmsiScanStringTest()
	{
		Assert.That(AmsiInitialize(Guid.NewGuid().ToString(), out var hctx), ResultIs.Successful);
		Assert.That(AmsiOpenSession(hctx, out var hsess), ResultIs.Successful);

		var fn = TestCaseSources.LogFile;
		Assert.That(AmsiScanString(hctx, File.ReadAllText(fn), fn, hsess, out var ret), ResultIs.Successful);
		Assert.That(!AmsiResultIsMalware(ret));
	}

	[Test]
	public void AmsiScanStringTest2()
	{
		SafeHAMSISESSION hsess;
		using (hsess = new SafeHAMSISESSION(Guid.NewGuid().ToString()))
		{
			Assert.That(hsess, ResultIs.ValidHandle);

			var fn = TestCaseSources.LogFile;
			Assert.That(AmsiScanString(hsess.Context, File.ReadAllText(fn), fn, hsess, out var ret), ResultIs.Successful);
			Assert.That(!AmsiResultIsMalware(ret));
		}
		Assert.That(hsess, Is.Not.Null);
		Assert.That(hsess.Context, ResultIs.Not.ValidHandle);
		Assert.That(hsess, ResultIs.Not.ValidHandle);
	}

	[Test]
	public void AmsiNotifyOperationTest()
	{
		using var hsess = new SafeHAMSISESSION(Guid.NewGuid().ToString());
		var fn = TestCaseSources.BmpFile;
		using var fs = File.OpenRead(fn);
		using var mem = new NativeMemoryStream();
		fs.CopyTo(mem);
		Assert.That(AmsiNotifyOperation(hsess.Context, mem.Pointer, (uint)mem.Length, fn, out var ret), ResultIs.Successful);
		Assert.That(!AmsiResultIsMalware(ret));
		Assert.That(AmsiScanBuffer(hsess.Context, mem.Pointer, (uint)mem.Length, fn, hsess, out ret), ResultIs.Successful);
		Assert.That(!AmsiResultIsMalware(ret));
	}

	[Test]
	public void AmsiStreamTest()
	{
		var fn = TestCaseSources.BmpFile;
		var app = "MyTestApp";
		AmsiStream? str = null;
		Assert.That(() => str = new(File.ReadAllBytes(fn), false) { AppName = app, ContentName = fn }, Throws.Nothing);
		Assert.That(str!.ContentSize, Is.EqualTo(new FileInfo(fn).Length));

		var istr = (IAmsiStream)str!;
		using var mem = new SafeCoTaskMemHandle(2048);

		Assert.That(istr.GetAttribute(AMSI_ATTRIBUTE.AMSI_ATTRIBUTE_APP_NAME, mem.Size, mem, out var sz), ResultIs.Successful);
		Assert.That(mem.ToString((int)sz * 2), Is.EqualTo(app));

		Assert.That(istr.GetAttribute(AMSI_ATTRIBUTE.AMSI_ATTRIBUTE_CONTENT_NAME, mem.Size, mem, out sz), ResultIs.Successful);
		Assert.That(mem.ToString((int)sz * 2), Is.EqualTo(fn));

		Assert.That(istr.GetAttribute(AMSI_ATTRIBUTE.AMSI_ATTRIBUTE_CONTENT_SIZE, mem.Size, mem, out sz), ResultIs.Successful);
		Assert.That(sz, Is.EqualTo(sizeof(ulong)));
		Assert.That(mem.ToStructure<ulong>(), Is.EqualTo(str!.ContentSize));

		Assert.That(istr.GetAttribute(AMSI_ATTRIBUTE.AMSI_ATTRIBUTE_CONTENT_ADDRESS, mem.Size, mem, out sz), ResultIs.Successful);
		Assert.That(sz, Is.EqualTo(IntPtr.Size));
		Assert.That(mem.ToStructure<IntPtr>(), Is.Not.EqualTo(IntPtr.Zero));

		Assert.That(istr.GetAttribute(AMSI_ATTRIBUTE.AMSI_ATTRIBUTE_SESSION, mem.Size, mem, out sz), ResultIs.Successful);
		Assert.That(sz, Is.EqualTo(IntPtr.Size));
		Assert.That(mem.ToStructure<IntPtr>(), Is.EqualTo(IntPtr.Zero));
	}

	[Test]
	public void InterfaceTest()
	{
		var fn = TestCaseSources.LargeFile;
		var app = "MyTestApp";
		AmsiStream? str = null;
		// This should fail on a large file over 16MB
		Assert.That(() => str = new(new FileInfo(fn), false) { AppName = app }, Throws.Exception);
		// ... but succeed for smaller files
		fn = TestCaseSources.WordDoc;
		Assert.That(() => str = new(new FileInfo(fn), false) { AppName = app }, Throws.Nothing);

		IAntimalware2 iam = new();
		var hr = iam.Scan(str!, out var res, out var prov);
		TestContext.WriteLine(res);
		Assert.That(hr, ResultIs.Successful);
		Assert.That(prov.DisplayName(out var pname), ResultIs.Successful);
		TestContext.WriteLine(pname);

		using var mem = new SafeCoTaskMemHandle(20);
		mem.Fill(78);
		Assert.That(iam.Notify(mem, mem.Size, fn, app, out var res2), ResultIs.Successful);
		TestContext.WriteLine(res2);
	}
}