using NUnit.Framework;
using System;
using System.Runtime.InteropServices;
using System.Text;
using Vanara.InteropServices;
using static Vanara.PInvoke.AdvApi32;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests
{
	[TestFixture]
	public class NamedPipeApiTests
	{
		[Test]
		public unsafe void ConnectNamedPipeTest()
		{
			using (var hPipe = CreateNamedPipe(PipeClientWriter.pipeName, PIPE_ACCESS.PIPE_ACCESS_DUPLEX, PIPE_TYPE.PIPE_TYPE_BYTE | PIPE_TYPE.PIPE_READMODE_BYTE | PIPE_TYPE.PIPE_WAIT, 10, 1024 * 16, 1024 * 16, 60000))
			{
				Assert.That(hPipe, ResultIs.ValidHandle);

				var p = CSharpRunner.RunProcess(typeof(PipeClientWriter));
				Assert.That(ConnectNamedPipe(hPipe), ResultIs.Successful);

				var buffer = new byte[1024];
				Assert.That(PeekNamedPipe(hPipe, buffer, (uint)buffer.Length - 1, out var peekRead, out var peekAvail, out var peekLeft), ResultIs.Successful);
				//Assert.That(peekRead, Is.EqualTo(PipeClientWriter.bytesToWrite.Length));
				Assert.That(ReadFile(hPipe, buffer, (uint)buffer.Length - 1, out var nRead), ResultIs.Successful);
				Assert.That(nRead, Is.EqualTo(PipeClientWriter.bytesToWrite.Length));

				Assert.That(DisconnectNamedPipe(hPipe), ResultIs.Successful);
			}
		}

		[Test]
		public void CreatePipeTest()
		{
			var saAttr = new SECURITY_ATTRIBUTES { bInheritHandle = true };
			Assert.That(CreatePipe(out var g_hChildStd_OUT_Rd, out var g_hChildStd_OUT_Wr, saAttr, 0), ResultIs.Successful);
			g_hChildStd_OUT_Rd.Dispose();
			g_hChildStd_OUT_Wr.Dispose();
		}

		[Test]
		public void CreateNamedPipeTest()
		{
			using (var hPipe = CreateNamedPipe(@"\\.\pipe\PipeName", PIPE_ACCESS.PIPE_ACCESS_DUPLEX, PIPE_TYPE.PIPE_WAIT, 1, 4096, 4096, 0))
				Assert.That(hPipe, ResultIs.ValidHandle);
		}

		[Test]
		public void GetNamedPipeClientComputerNameTest()
		{
			using (var hPipe = CreateNamedPipe(@"\\.\pipe\PipeName", PIPE_ACCESS.PIPE_ACCESS_DUPLEX, PIPE_TYPE.PIPE_WAIT, 1, 4096, 4096, 0))
			{
				var sb = new StringBuilder(100, 100);
				Assert.That(GetNamedPipeClientComputerName(hPipe, sb, (uint)sb.Capacity), ResultIs.Failure);
			}
		}

		[Test]
		public void GetNamedPipeIdTest()
		{
			var saAttr = new SECURITY_ATTRIBUTES { bInheritHandle = true };
			Assert.That(CreatePipe(out var g_hChildStd_OUT_Rd, out var g_hChildStd_OUT_Wr, saAttr, 0), ResultIs.Successful);
			try
			{
				Assert.That(GetNamedPipeClientProcessId(g_hChildStd_OUT_Rd, out var cpid), ResultIs.Successful);
				Assert.That(cpid, Is.Not.Zero);
				Assert.That(GetNamedPipeClientSessionId(g_hChildStd_OUT_Rd, out var csid), ResultIs.Successful);
				Assert.That(csid, Is.Not.Zero);
				Assert.That(GetNamedPipeServerProcessId(g_hChildStd_OUT_Rd, out var spid), ResultIs.Successful);
				Assert.That(spid, Is.Not.Zero);
				Assert.That(GetNamedPipeServerSessionId(g_hChildStd_OUT_Rd, out var ssid), ResultIs.Successful);
				Assert.That(ssid, Is.Not.Zero);
				Assert.That(GetNamedPipeHandleState(g_hChildStd_OUT_Wr, out var type, out var inst), ResultIs.Successful);
				(cpid, csid, spid, ssid, type, inst).WriteValues();
				Assert.That(SetNamedPipeHandleState(g_hChildStd_OUT_Wr, new PinnedObject(0)), ResultIs.Successful);
			}
			finally
			{
				g_hChildStd_OUT_Rd.Dispose();
				g_hChildStd_OUT_Wr.Dispose();
			}
		}
	}

	public static class PipeClientWriter
	{
		public static readonly byte[] bytesToWrite = new byte[] { 1, 2, 4, 8, 16, 32 };
		public const string pipeName = @"\\.\pipe\PipeName";

		public static int Main()
		{
			Sleep(2000);
			using (var hPipe = CreateFile(pipeName, FileAccess.GENERIC_WRITE, 0, null, System.IO.FileMode.Open, 0))
			{
				if (hPipe.IsInvalid) return (int)(uint)Win32Error.GetLastError();
				if (!WriteFile(hPipe, bytesToWrite, (uint)bytesToWrite.Length, out var written) || written != bytesToWrite.Length)
					return (int)(uint)Win32Error.GetLastError();
			}
			return 0;
		}
	}
}