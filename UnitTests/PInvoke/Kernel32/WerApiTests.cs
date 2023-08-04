using NUnit.Framework;
using System;
using System.Runtime.InteropServices;
using Vanara.InteropServices;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class WerApiTests
{
	public static readonly HPROCESS hProc = GetCurrentProcess();

	[Test]
	public void WerGetSetFlagsTest()
	{
		Assert.That(WerGetFlags(hProc, out WER_FAULT_REPORTING flags), ResultIs.Successful);
		Assert.That(flags, Is.Not.Zero);
		Assert.That(WerSetFlags(flags), ResultIs.Successful);
	}

	[Test]
	public void WerRegisterAppLocalDumpTest()
	{
		Assert.That(WerRegisterAppLocalDump("ErrDump.txt"), ResultIs.Successful);
		Assert.That(WerUnregisterAppLocalDump(), ResultIs.Successful);
	}

	[Test]
	public void WerRegisterCustomMetadataTest()
	{
		Assert.That(WerRegisterCustomMetadata("Fred", "Ethel"), ResultIs.Successful);
		Assert.That(WerUnregisterCustomMetadata("Fred"), ResultIs.Successful);
	}

	[Test]
	public void WerRegisterFileTest()
	{
		// Create a log file in the current directory. Make sure we share read access so WER can read the file.
		using TempFile LogFileHandle = new(FileAccess.GENERIC_WRITE, System.IO.FileShare.Read, System.IO.FileMode.Create);
		// Print a few lines into the log file.
		byte[] BytesToPrint = Encoding.Unicode.GetBytes("Line 1\nLine 2\n");

		Assert.That(WriteFile(LogFileHandle.hFile, BytesToPrint, (uint)BytesToPrint.Length, out uint BytesWritten), ResultIs.Successful);

		// Make sure we flush the log file so the bytes actually make it to the file-system.
		Assert.That(FlushFileBuffers(LogFileHandle.hFile), ResultIs.Successful);

		// Get the full path to the log file. We need this because WerRegisterFile requires a full path.
		string LogFullPath = LogFileHandle.FullName;

		// Finally, tell WER to collect the file when we crash. Specify that the file does not contain any personally identifiable
		// information, and the file can be safely sent without the corresponding consent from the user.
		Assert.That(WerRegisterFile(LogFullPath, WER_REGISTER_FILE_TYPE.WerRegFileTypeOther, WER_REGISTER_FILE_FLAGS.WER_FILE_ANONYMOUS_DATA), ResultIs.Successful);

		// Unregister just to check
		Assert.That(WerUnregisterFile(LogFullPath), ResultIs.Successful);
	}

	[Test]
	public void WerRegisterMemoryBlockTest()
	{
		STATE_BLOCK g_StateBlock = default, SecondStateBlock = default;
		SecondStateBlock.Text = "Second state block is in the dump.";
		g_StateBlock.Text = "First state block is in the dump.";
		SafeHGlobalHandle pSecondStateBlock = SafeHGlobalHandle.CreateFromStructure(SecondStateBlock);
		g_StateBlock.SecondStateBlock = (IntPtr)pSecondStateBlock;
		SafeHGlobalHandle pStateBlock = SafeHGlobalHandle.CreateFromStructure(g_StateBlock);

		// Tell WER to collect the memory occupied by g_StateBlock as part of the dump file.
		Assert.That(WerRegisterMemoryBlock((IntPtr)pStateBlock, (uint)Marshal.SizeOf<STATE_BLOCK>()), ResultIs.Successful);

		// Put some strings in the state blocks.
		Assert.That(WerRegisterMemoryBlock((IntPtr)pSecondStateBlock, (uint)Marshal.SizeOf<STATE_BLOCK>()), ResultIs.Successful);

		Assert.That(WerUnregisterMemoryBlock((IntPtr)pSecondStateBlock), ResultIs.Successful);
		Assert.That(WerUnregisterMemoryBlock((IntPtr)pStateBlock), ResultIs.Successful);
	}

	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
	private struct STATE_BLOCK
	{
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
		public string Text;

		public IntPtr SecondStateBlock;
	}
}