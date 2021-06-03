using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.IO;
using System.Runtime.InteropServices;
using Vanara.RunTimeLib;
using Vanara.Extensions;
using static Vanara.PInvoke.Cabinet;
using System.Collections.Generic;

namespace Vanara.PInvoke.Tests
{
	[TestFixture]
	public class FDITests
	{
		const string cabfn = "test.cab";
		static readonly string cabdir = TestCaseSources.TempDirWhack;
		private ERF erf = new();
		private SafeHFDI handle;

		[OneTimeSetUp]
		public void _Setup()
		{
			handle = FDICreate(AllocCallback, FreeCallback, OpenCallback, ReadCallback, WriteCallback, CloseCallback, SeekCallback, FDICPU.cpuUNKNOWN, ref erf);
		}

		[OneTimeTearDown]
		public void _TearDown()
		{
			handle?.Dispose();
		}

		[Test]
		public void FDICreateTest()
		{
			SafeHFDI h;
			ERF myerf = new();
			Assert.That(h = FDICreate(AllocCallback, FreeCallback, OpenCallback, ReadCallback, WriteCallback, CloseCallback, SeekCallback, FDICPU.cpuUNKNOWN, ref myerf), ResultIs.ValidHandle);
			Assert.That(() => h?.Dispose(), Throws.Nothing);
		}

		[Test, MTAThread]
		public void FDICopyTest()
		{
			List<string> files = new();
			Assert.That(FDICopy(handle, cabfn, cabdir, 0, Notify), Is.True);
			Assert.That(files.Count, Is.GreaterThan(0));
			files.WriteValues();

			IntPtr Notify(FDINOTIFICATIONTYPE fdint, ref FDINOTIFICATION pfdin)
			{
				switch (fdint)
				{
					case FDINOTIFICATIONTYPE.fdintCOPY_FILE:
						files.Add($"{pfdin.psz1} : {pfdin.cb} : {pfdin.DateTime}");
						return IntPtr.Zero;
					case FDINOTIFICATIONTYPE.fdintCLOSE_FILE_INFO:
						return (IntPtr)1;
					default:
						break;
				}
				return IntPtr.Zero;
			}


		}

		private IntPtr AllocCallback(uint cb) => Marshal.AllocHGlobal((int)cb);

		private FileStream StreamFromHandle(IntPtr hf) => GCHandle.FromIntPtr(hf).Target as FileStream;

		private int CloseCallback(IntPtr hf)
		{
			FileStream stream = StreamFromHandle(hf);
			if (stream is null)
				return -1;

			stream.Dispose();
			((GCHandle)hf).Free();
			return 0;
		}

		private void FreeCallback(IntPtr memory) => Marshal.FreeHGlobal(memory);

		private IntPtr OpenCallback(string pszFile, RunTimeLib.FileOpConstant oflag, RunTimeLib.FilePermissionConstant pmode)
		{
			FileMode mode = oflag.ToFileMode();
			FileAccess access = pmode.ToFileAccess();
			FileShare share = pmode.ToFileShare();

			try
			{
				FileStream stream = new FileStream(pszFile, mode, access, share);
				return stream is null ? new IntPtr(-1) : GCHandle.ToIntPtr(GCHandle.Alloc(stream));
			}
			catch (IOException)
			{
				return new IntPtr(-1);
			}
		}

		private uint ReadCallback(IntPtr hf, IntPtr memory, uint cb)
		{
			FileStream stream = StreamFromHandle(hf);

			int numCharactersRead;
			try
			{
				var arr = new byte[(int)cb];
				numCharactersRead = stream.Read(arr, 0, (int)cb);
				Marshal.Copy(arr, 0, memory, numCharactersRead);
			}
			catch (ArgumentNullException) { numCharactersRead = -1; }
			catch (ArgumentOutOfRangeException) { numCharactersRead = -1; }
			catch (NotSupportedException) { numCharactersRead = -1; }
			catch (IOException) { numCharactersRead = -1; }
			catch (ArgumentException) { numCharactersRead = -1; }
			catch (ObjectDisposedException) { numCharactersRead = -1; }

			return unchecked((uint)numCharactersRead);
		}

		private int SeekCallback(IntPtr hf, int dist, SeekOrigin seektype)
		{
			FileStream stream = StreamFromHandle(hf);
			long status;
			try
			{
				status = stream.Seek(dist, seektype);
			}
			catch (NotSupportedException) { status = -1; }
			catch (IOException) { status = -1; }
			catch (ArgumentException) { status = -1; }
			catch (ObjectDisposedException) { status = -1; }

			return (int)status;
		}

		private uint WriteCallback(IntPtr hf, IntPtr memory, uint cb)
		{
			FileStream stream = StreamFromHandle(hf);

			int numCharactersWritten;
			try
			{
				stream.Write(memory.AsReadOnlySpan<byte>((int)cb).ToArray(), 0, (int)cb);
				numCharactersWritten = (int)cb; // Write doesn't return the number of bytes written. Per MSDN, if it succeeds, it will have written count bytes.
			}
			catch (ArgumentNullException) { numCharactersWritten = -1; }
			catch (ArgumentOutOfRangeException) { numCharactersWritten = -1; }
			catch (NotSupportedException) { numCharactersWritten = -1; }
			catch (IOException) { numCharactersWritten = -1; }
			catch (ArgumentException) { numCharactersWritten = -1; }
			catch (ObjectDisposedException) { numCharactersWritten = -1; }

			return unchecked((uint)numCharactersWritten);
		}
	}
}