using NUnit.Framework;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class RtlSupportApiTests
{
	[Test]
	public void RtlAddDeleteFunctionTableTest()
	{
		using SafeHGlobalHandle mem = new(4096);
		IMAGE_RUNTIME_FUNCTION_ENTRY[] funcs = [new IMAGE_RUNTIME_FUNCTION_ENTRY { BeginAddress = 0, EndAddress = 4096, UnwindInfoAddress = 2048 }];
		ulong baseAddr = (ulong)((IntPtr)mem).ToInt64();
		Assert.That(RtlAddFunctionTable(funcs, 1, baseAddr), ResultIs.Successful);

		try
		{
			IntPtr retAddr = RtlLookupFunctionEntry(baseAddr, out ulong img, out UNWIND_HISTORY_TABLE hist);
			Assert.That(retAddr, Is.EqualTo(IntPtr.Zero));
		}
		finally
		{
			Assert.That(RtlDeleteFunctionTable(funcs), ResultIs.Successful);
		}
	}

	[Test]
	public void RtlCaptureContextTest()
	{
		CONTEXT ctx = RtlCaptureContext();
		Assert.That(ctx.ContextFlags, Is.EqualTo(CONTEXT_FLAG.CONTEXT_ALL));
	}

	[Test]
	public void RtlInstallFunctionTableCallbackTest()
	{
		IntPtr pEntry = default;
		using SafeHGlobalHandle mem = new(4096), entry = SafeHGlobalHandle.CreateFromStructure(new IMAGE_RUNTIME_FUNCTION_ENTRY { BeginAddress = 0, EndAddress = 4096, UnwindInfoAddress = 2048 });
		ulong baseAddr = (ulong)((IntPtr)mem).ToInt64();
		pEntry = (IntPtr)entry;
		ulong id = baseAddr | 0x3;
		Assert.That(RtlInstallFunctionTableCallback(id, baseAddr, 4096, callbk), ResultIs.Successful);
		Assert.That(RtlDeleteFunctionTable(id), ResultIs.Successful);

		IntPtr callbk(IntPtr ControlPc, IntPtr Context) => pEntry;
	}

	[Test]
	public void RtlPcToFileHeaderTest() => Assert.That(() => RtlPcToFileHeader(IntPtr.Zero, out IntPtr p), Throws.Nothing);// TODO - Too undocumented to implement.

	//[Test]
	public void RtlRestoreContextTest()
	{
		CONTEXT ctx = RtlCaptureContext();
		Assert.That(() => RtlRestoreContext(ctx), Throws.Nothing);
		// TODO - Too undocumented to implement.
	}

	[Test]
	public void RtlUnwindTest()
	{
		Assert.Fail("Too undocumented to implement.");
		Assert.That(() => RtlUnwind(default, default, IntPtr.Zero, default), Throws.Nothing);
	}

	[Test]
	public void RtlUnwindExTest()
	{
		Assert.Fail("Too undocumented to implement.");
		Assert.That(() => RtlUnwindEx(default, default, IntPtr.Zero, default, default, default), Throws.Nothing);
	}

	[Test]
	public void RtlMoveMemoryTest()
	{
		using SafeHGlobalHandle src = new(1024), dest = new(1024);
		src.Fill(7, 512);
		Assert.That(() => RtlMoveMemory((IntPtr)dest, (IntPtr)src, 768), Throws.Nothing);
		Assert.That(Marshal.ReadByte(((IntPtr)dest).Offset(256)), Is.EqualTo(7));
		Assert.That(Marshal.ReadByte(((IntPtr)dest).Offset(896)), Is.EqualTo(0));

		Assert.That(() => RtlZeroMemory((IntPtr)dest, 128), Throws.Nothing);
		Assert.That(Marshal.ReadByte(((IntPtr)dest).Offset(64)), Is.EqualTo(0));
		Assert.That(Marshal.ReadByte(((IntPtr)dest).Offset(256)), Is.EqualTo(7));
	}
}