using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using Vanara.Extensions;
using static Vanara.PInvoke.DbgHelp;
using static Vanara.PInvoke.ImageHlp;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests
{
	[TestFixture]
	public class DbgHelpTests
	{
		const string imgName = "imagehlp.dll";
		const string testAppName = "TestDbgApp";
		static readonly string testAppPath = TestCaseSources.TempDirWhack + testAppName + ".exe";
		private Process testApp;
		private ProcessSymbolHandler hProc;

		[OneTimeSetUp]
		public void _Setup()
		{
			testApp = Process.Start(new ProcessStartInfo(testAppPath) { WindowStyle = ProcessWindowStyle.Minimized });
			hProc = new ProcessSymbolHandler(testApp.Handle);
		}

		[OneTimeTearDown]
		public void _TearDown()
		{
			hProc.Dispose();
			testApp.Kill();
		}

		[Test]
		public void EnumDirTreeTest()
		{
			var output = EnumDirTree(HPROCESS.NULL, Environment.GetFolderPath(Environment.SpecialFolder.Windows), imgName);
			Assert.That(output, Is.Not.Empty);
			TestContext.WriteLine($"Count: {output.Count}");
			output.WriteValues();
		}

		[Test]
		public void EnumerateLoadedModulesTest()
		{
			var output = EnumerateLoadedModules(Process.GetCurrentProcess().Handle);
			Assert.That(output, Is.Not.Empty);
			TestContext.WriteLine($"Count: {output.Count}");
			output.WriteValues();
		}

		[Test]
		public void EnumerateLoadedModulesExTest()
		{
			var output = EnumerateLoadedModulesEx(Process.GetCurrentProcess().Handle);
			Assert.That(output, Is.Not.Empty);
			TestContext.WriteLine($"Count: {output.Count}");
			output.WriteValues();
		}

		[Test]
		public void FindExecutableImageExTest()
		{
			Assert.That(FindExecutableImageEx(imgName, new[] { Environment.GetFolderPath(Environment.SpecialFolder.System), TestCaseSources.TempDir }), ResultIs.Not.Value(null));
		}

		[Test]
		public void ImagehlpApiVersionTest()
		{
			Assert.That(ImagehlpApiVersion().MajorVersion, Is.GreaterThan((ushort)0));
		}

		[Test]
		public void GetImageConfigInformationTest()
		{
			Assert.That(MapAndLoad(imgName, null, out var LoadedImage, true, true), ResultIs.Successful);
			try
			{
				var data = ImageDirectoryEntryToData(LoadedImage.MappedAddress, false, IMAGE_DIRECTORY_ENTRY.IMAGE_DIRECTORY_ENTRY_EXPORT, out var cDirSize); // (_IMAGE_EXPORT_DIRECTORY*)
				Assert.That(data, ResultIs.ValidHandle);
				var ImageExportDirectory = data.ToStructure<IMAGE_EXPORT_DIRECTORY>(cDirSize);
				ImageExportDirectory.WriteValues();
				var addr = ImageRvaToVa(LoadedImage.FileHeader, LoadedImage.MappedAddress, ImageExportDirectory.AddressOfNames, out _); // (uint*)
				Assert.That(addr, ResultIs.ValidHandle);
				foreach (var rva in addr.ToArray<uint>((int)ImageExportDirectory.NumberOfNames))
				{
					var sName = ImageRvaToVa(LoadedImage.FileHeader, LoadedImage.MappedAddress, rva, out _);
					TestContext.WriteLine(Marshal.PtrToStringAnsi(sName) ?? "(null)");
				}
			}
			finally
			{
				UnMapAndLoad(ref LoadedImage);
			}
		}

		[Test]
		public void SymEnumerateModulesTest()
		{
			var output = SymEnumerateModules(hProc, true);
			TestContext.WriteLine($"Count: {output.Count}");
			output.WriteValues();
		}

		[Test]
		public void SymEnumLinesTest()
		{
			var (_, BaseOfDll) = SymEnumerateModules(hProc, true).First();
			var output = SymEnumLines(hProc, unchecked((ulong)BaseOfDll.ToInt64()));
			TestContext.WriteLine($"Count: {output.Count}");
			output.WriteValues();
		}

		[Test]
		public void SymEnumProcessesTest()
		{
			Assert.That(SymEnumProcesses(), Is.Not.Empty);
		}

		[Test]
		public unsafe void SymGetOmapsTest()
		{
			var (_, BaseOfDll) = SymEnumerateModules(hProc, true).First();
			Assert.That(SymGetOmaps(hProc, unchecked((ulong)BaseOfDll.ToInt64()), out var to, out var cto, out var from, out var cfrom), ResultIs.Successful);
		}

		[Test]
		public void SymGetSymFromNameTest()
		{
			using var sym = new SafeIMAGEHLP_SYMBOL();
			Assert.That(SymGetSymFromName(hProc, "strcat", sym), ResultIs.Successful);
			sym.Value.WriteValues();
		}

		[Test]
		public void SymGetSymFromName64Test()
		{
			ulong addr = 0;
			using (var sym = new SafeIMAGEHLP_SYMBOL64())
			{
				Assert.That(SymGetSymFromName64(hProc, "strcat", sym), ResultIs.Successful);
				sym.Value.WriteValues();
				Assert.That(sym.Value.Name, Is.EqualTo("strcat"));
				addr = sym.Value.Address;
			}

			using (var sym = new SafeIMAGEHLP_SYMBOL64())
			{
				Assert.That(SymGetSymFromAddr64(hProc, addr, out var displ, sym), ResultIs.Successful);
				sym.Value.WriteValues();
				Assert.That(sym.Value.Name, Is.EqualTo("strcat"));
			}
		}

		[Test]
		public void MimicDllExp()
		{
			Assert.That(MapAndLoad(imgName, null, out var LoadedImage, true, true), ResultIs.Successful);
			try
			{
				var data = ImageDirectoryEntryToData(LoadedImage.MappedAddress, false, IMAGE_DIRECTORY_ENTRY.IMAGE_DIRECTORY_ENTRY_EXPORT, out var cDirSize); // (_IMAGE_EXPORT_DIRECTORY*)
				Assert.That(data, ResultIs.ValidHandle);
				var ImageExportDirectory = data.ToStructure<IMAGE_EXPORT_DIRECTORY>(cDirSize);
				ImageExportDirectory.WriteValues();

				var addr = ImageRvaToVa(LoadedImage.FileHeader, LoadedImage.MappedAddress, ImageExportDirectory.AddressOfNames, out _); // (uint*)
				Assert.That(addr, ResultIs.ValidHandle);
				var rnameaddrs = addr.ToArray<uint>((int)ImageExportDirectory.NumberOfNames);

				addr = ImageRvaToVa(LoadedImage.FileHeader, LoadedImage.MappedAddress, ImageExportDirectory.AddressOfNameOrdinals, out _); // (uint*)
				Assert.That(addr, ResultIs.ValidHandle);
				var rordaddrs = addr.ToArray<uint>((int)ImageExportDirectory.NumberOfNames);

				for (int i = 0; i < rnameaddrs.Length; i++)
				{
					var sName = Marshal.PtrToStringAnsi(ImageRvaToVa(LoadedImage.FileHeader, LoadedImage.MappedAddress, rnameaddrs[i], out _));
					var ord = ImageRvaToVa(LoadedImage.FileHeader, LoadedImage.MappedAddress, rordaddrs[i], out _).ToNullableStructure<uint>();
					TestContext.WriteLine($"{sName ?? (null)}\t0x{ord ?? 0}");
				}
			}
			finally
			{
				UnMapAndLoad(ref LoadedImage);
			}
		}

		[Test]
		public void MiniDumpCallbackOrderTest()
		{
			var memCallbackCalled = false;
			using var hFile = CreateFile("CallbackOrder.dmp", Kernel32.FileAccess.GENERIC_READ | Kernel32.FileAccess.GENERIC_WRITE, 0, default, FileMode.Create, FileFlagsAndAttributes.FILE_ATTRIBUTE_NORMAL);
			if (!hFile.IsInvalid)
			{
				var mdei = new MINIDUMP_EXCEPTION_INFORMATION
				{
					ThreadId = GetCurrentThreadId(),
					ExceptionPointers = Marshal.GetExceptionPointers()
				};

				var mci = new MINIDUMP_CALLBACK_INFORMATION { CallbackRoutine = MyMiniDumpCallback };

				Assert.That(MiniDumpWriteDump(GetCurrentProcess(), GetCurrentProcessId(), hFile, MINIDUMP_TYPE.MiniDumpNormal, mdei, default, mci), ResultIs.Successful);
			}

			bool MyMiniDumpCallback([In, Out] IntPtr CallbackParam, in MINIDUMP_CALLBACK_INPUT CallbackInput, ref MINIDUMP_CALLBACK_OUTPUT CallbackOutput)
			{
				TestContext.Write($"{CallbackInput.CallbackType} ");
				switch (CallbackInput.CallbackType)
				{
					case MINIDUMP_CALLBACK_TYPE.ModuleCallback:
						TestContext.WriteLine($"(module: {CallbackInput.Module.FullPath})");
						return true;
					case MINIDUMP_CALLBACK_TYPE.ThreadCallback:
						TestContext.WriteLine($"(thread: {CallbackInput.Thread.ThreadId:X})");
						return true;
					case MINIDUMP_CALLBACK_TYPE.ThreadExCallback:
						TestContext.WriteLine($"(thread: {CallbackInput.ThreadEx.ThreadId:X})");
						return true;
					case MINIDUMP_CALLBACK_TYPE.IncludeThreadCallback:
						TestContext.WriteLine($"(thread: {CallbackInput.IncludeThread.ThreadId:X})");
						return true;
					case MINIDUMP_CALLBACK_TYPE.IncludeModuleCallback:
						TestContext.WriteLine($"(module: {CallbackInput.IncludeModule.BaseOfImage:X})");
						return true;
					case MINIDUMP_CALLBACK_TYPE.MemoryCallback:
						memCallbackCalled = true;
						TestContext.WriteLine("");
						return false;
					case MINIDUMP_CALLBACK_TYPE.CancelCallback:
						CallbackOutput.Cancel = false;
						CallbackOutput.CheckCancel = !memCallbackCalled;
						TestContext.WriteLine("");
						return true;
					default:
						TestContext.WriteLine("");
						return false;
				}
			}
		}
	}
}