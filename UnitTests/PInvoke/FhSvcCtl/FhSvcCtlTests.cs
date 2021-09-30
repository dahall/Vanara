using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Runtime.InteropServices;
using static Vanara.PInvoke.FhSvcCtl;

namespace Vanara.PInvoke.Tests
{
	[TestFixture]
	public class FhSvcCtlTests
	{
		[OneTimeSetUp]
		public void _Setup()
		{
		}

		[DllImport(Lib.Kernel32, CharSet = CharSet.Auto, SetLastError = true, BestFitMapping = false, ThrowOnUnmappableChar = true)]
		static extern HINSTANCE LoadLibraryEx(string lpFileName, [Optional] IntPtr hFile, uint dwFlags);

		[DllImport(Lib.Kernel32, SetLastError = true, ExactSpelling = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		static extern bool FreeLibrary(HINSTANCE hModule);

		[OneTimeTearDown]
		public void _TearDown()
		{
		}

		[Test]
		public void TestIntf()
		{
			var mgr = new IFhConfigMgr();
			mgr.LoadConfiguration();
		}

		[Test]
		public void TestFn()
		{
			HINSTANCE hi;
			Assert.That(hi = LoadLibraryEx(@"C:\Windows\System32\fhsvccfg.dll", default, 0x1000), ResultIs.ValidHandle);
			FreeLibrary(hi);

			Assert.That(FhServiceOpenPipe(true, out var hPipe), ResultIs.Successful);
			Assert.That(FhServiceReloadConfiguration(hPipe), ResultIs.Successful);
			Assert.That(FhServiceStartBackup(hPipe, true), ResultIs.Successful);
			Assert.That(FhServiceBlockBackup(hPipe), ResultIs.Successful);
			Assert.That(FhServiceUnblockBackup(hPipe), ResultIs.Successful);
			Assert.That(FhServiceStopBackup(hPipe, false), ResultIs.Successful);
			Assert.That(() => hPipe.Dispose(), Throws.Nothing);
		}
	}
}