using NUnit.Framework;
using System;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public partial class WinBaseTests_ProcessThread
{
	public readonly static byte ValidNumaNode = GetNumaHighestNodeNumber(out uint n) ? (byte)n : (byte)0;

	public readonly static byte ValidProcessor = (byte)(Environment.ProcessorCount - 1);

	[Test]
	public void ConvertThreadToFiberExTest()
	{
		Assert.That(ConvertThreadToFiberEx(default, FIBER_FLAG.FIBER_FLAG_FLOAT_SWITCH), ResultIs.ValidHandle);
		Assert.That(ConvertFiberToThread(), ResultIs.Successful);
	}

	[Test]
	public void ConvertThreadToFiberTest()
	{
		Assert.That(ConvertThreadToFiber(), ResultIs.ValidHandle);
		Assert.That(ConvertFiberToThread(), ResultIs.Successful);
	}

	[Test]
	public void CreateFiberExTest()
	{
		IntPtr[] fibers = new IntPtr[2];
		Assert.That(fibers[0] = ConvertThreadToFiber(), ResultIs.ValidHandle);
		Assert.That(fibers[1] = CreateFiberEx(0, 0, FIBER_FLAG.FIBER_FLAG_FLOAT_SWITCH, LocalProc), ResultIs.ValidHandle);
		SwitchToFiber(fibers[1]);
		DeleteFiber(fibers[1]);

		void LocalProc(IntPtr lpParameter) { TestContext.WriteLine("In fiber."); SwitchToFiber(fibers[0]); }
	}

	[Test]
	public void CreateFiberTest()
	{
		IntPtr[] fibers = new IntPtr[2];
		Assert.That(fibers[0] = ConvertThreadToFiber(), ResultIs.ValidHandle);
		Assert.That(fibers[1] = CreateFiber(0, LocalProc), ResultIs.ValidHandle);
		SwitchToFiber(fibers[1]);
		DeleteFiber(fibers[1]);

		void LocalProc(IntPtr lpParameter) { TestContext.WriteLine("In fiber."); SwitchToFiber(fibers[0]); }
	}

	[Test]
	public void GetCurrentProcessTest()
	{
		Assert.That(GetCurrentProcess(), ResultIs.ValidHandle);
	}

	[Test]
	public void GetNumaAvailableMemoryNodeExTest()
	{
		Assert.That(GetNumaAvailableMemoryNodeEx(ValidNumaNode, out ulong bytes), ResultIs.Successful);
		TestContext.Write(bytes);
	}

	[Test]
	public void GetNumaAvailableMemoryNodeTest()
	{
		Assert.That(GetNumaAvailableMemoryNode(ValidNumaNode, out ulong bytes), ResultIs.Successful);
		bytes.WriteValues();
	}

	[Test]
	public void GetNumaNodeNumberFromHandleTest()
	{
		using TempFile tmp = new(FileAccess.GENERIC_READ, System.IO.FileShare.Read);
		Assert.That(GetNumaNodeNumberFromHandle(tmp.hFile, out ushort num), ResultIs.Successful);
		TestContext.Write(num);
	}

	[Test]
	public void GetNumaNodeProcessorMaskTest()
	{
		Assert.That(GetNumaNodeProcessorMask(ValidNumaNode, out ulong mask), ResultIs.Successful);
		TestContext.Write(mask);
	}

	[Test]
	public void GetNumaProcessorNodeExTest()
	{
		PROCESSOR_NUMBER pn = new(0, 0);
		Assert.That(GetNumaProcessorNodeEx(pn, out ushort num), ResultIs.Successful);
		TestContext.Write(num);
	}

	[Test]
	public void GetNumaProcessorNodeTest()
	{
		Assert.That(GetNumaProcessorNode(ValidProcessor, out byte num), ResultIs.Successful);
		TestContext.Write(num);
	}

	[Test]
	public void GetNumaProximityNodeTest()
	{
		Assert.That(GetNumaProximityNode(0, out byte num), ResultIs.Successful);
		TestContext.Write(num);
	}

	[Test]
	public void GetProcessIoCountersTest()
	{
		Assert.That(GetProcessIoCounters(GetCurrentProcess(), out IO_COUNTERS c), ResultIs.Successful);
		TestContext.Write(c);
	}

	[Test]
	public void GetSetProcessAffinityMaskTest()
	{
		Assert.That(GetProcessAffinityMask(GetCurrentProcess(), out UIntPtr pAff, out UIntPtr sAff), ResultIs.Successful);
		TestContext.Write((pAff, sAff));
		Assert.That(SetProcessAffinityMask(GetCurrentProcess(), pAff), ResultIs.Successful);
	}

	[Test]
	public void GetSetProcessWorkingSetSizeTest()
	{
		Assert.That(GetProcessWorkingSetSize(GetCurrentProcess(), out SizeT min, out SizeT max), ResultIs.Successful);
		TestContext.Write((min, max));
		Assert.That(SetProcessWorkingSetSize(GetCurrentProcess(), min, max), ResultIs.Successful);
	}

	[Test]
	public void MapViewOfFileExNumaTest()
	{
		using SafeHSECTION hfile = CreateFileMappingNuma(HFILE.INVALID_HANDLE_VALUE, null, MEM_PROTECTION.PAGE_EXECUTE_READWRITE, 0, 16 * 1024, "Local\\X", 0xffffffff);
		Assert.That(hfile, ResultIs.ValidHandle);
		Assert.That(MapViewOfFileExNuma(hfile, 0, 0, 0, 0, default, 0xffffffff), Is.Not.EqualTo(IntPtr.Zero));
	}

	[Test]
	public void SetThreadAffinityMaskTest()
	{
		Assert.That(SetThreadAffinityMask(GetCurrentThread(), (UIntPtr)1).ToUInt64(), Is.Not.Zero);
		//Assert.That(SetThreadAffinityMask(GetCurrentThread(), (UIntPtr)0).ToUInt64(), Is.Not.Zero);
	}

	[Test]
	public void SetThreadExecutionStateTest()
	{
		Assert.That((int)SetThreadExecutionState(EXECUTION_STATE.ES_SYSTEM_REQUIRED), Is.Not.Zero);
	}

	[Test]
	public void WinExecTest()
	{
		Assert.That(WinExec("notepad.exe", ShowWindowCommand.SW_NORMAL), Is.GreaterThan(31));
	}
}