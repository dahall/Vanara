using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Vanara.InteropServices;
using static Vanara.PInvoke.AdvApi32;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests
{
	[TestFixture]
	public class LibLoaderApiTests
	{
		internal const string badlibfn = @"C:\Windows\System32\ole3.dll";
		internal const string libfn = @"ole32.dll";
		const string resFile = @"C:\Windows\en-US\regedit.exe.mui";

		[Test]
		public void AddRemoveDllDirectoryTest()
		{
			var ptr = AddDllDirectory(TestCaseSources.TempDir);
			Assert.That(ptr, Is.Not.EqualTo(IntPtr.Zero));
			Assert.That(RemoveDllDirectory(ptr), Is.True);
		}

		[Test]
		public void EnumResourceLanguagesExTest()
		{
			using (var hLib = LoadLibraryEx(resFile, IntPtr.Zero, LoadLibraryExFlags.LOAD_LIBRARY_AS_IMAGE_RESOURCE))
			{
				IList<ushort> l = null;
				Assert.That(() => l = EnumResourceLanguagesEx(hLib, ResourceType.RT_STRING, 2), Throws.Nothing);
				Assert.That(l.Count, Is.GreaterThan(0));
				TestContext.WriteLine(string.Join(" : ", l));
			}
		}

		[Test]
		public void EnumResourceTypesExTest()
		{
			using (var hLib = LoadLibraryEx(resFile, IntPtr.Zero, LoadLibraryExFlags.LOAD_LIBRARY_AS_IMAGE_RESOURCE))
			{
				IList<ResourceId> l = null;
				Assert.That(() => l = EnumResourceTypesEx(hLib), Throws.Nothing);
				Assert.That(l.Count, Is.GreaterThan(0));
				TestContext.WriteLine(string.Join(" : ", l.Select(i => (ResourceType)i.id)));
			}
		}

		[Test]
		public void EnumResourceNamesTest()
		{
			using (var hLib = LoadLibraryEx(resFile, IntPtr.Zero, LoadLibraryExFlags.LOAD_LIBRARY_AS_IMAGE_RESOURCE))
			{
				IList<ResourceId> l = null;
				Assert.That(() => l = EnumResourceNamesEx(hLib, ResourceType.RT_STRING), Throws.Nothing);
				Assert.That(l.Count, Is.GreaterThan(0));
				foreach (var resourceName in l)
					Assert.That(resourceName.ToString(), Has.Length.GreaterThan(0));
				TestContext.WriteLine(string.Join(" : ", l.Select(i => i.id)));
			}
		}

		[Test]
		public void FindResourceTest()
		{
			using (var hLib = LoadLibraryEx(@"comctl32.dll", IntPtr.Zero, LoadLibraryExFlags.LOAD_LIBRARY_AS_IMAGE_RESOURCE))
			{
				var ptr = (IntPtr)FindResource(hLib, 65, ResourceType.RT_STRING);
				Assert.That(ptr, Is.Not.EqualTo(IntPtr.Zero));
			}
		}

		[Test]
		public void FindResourceExTest()
		{
			using (var hLib = LoadLibraryEx(@"comctl32.dll", IntPtr.Zero, LoadLibraryExFlags.LOAD_LIBRARY_AS_IMAGE_RESOURCE))
			{
				var ptr = (IntPtr)FindResourceEx(hLib, 65, ResourceType.RT_STRING, 1033);
				Assert.That(ptr, Is.Not.EqualTo(IntPtr.Zero));
			}
		}

		[Test]
		public void FindStringOrdinalTest()
		{
			const string src = "How do you do today?";

			Assert.That(FindStringOrdinal(SEARCH_FLAGS.FIND_ENDSWITH, src, src.Length, "DAY?", 4, true), Is.GreaterThan(0));
			Assert.That(FindStringOrdinal(SEARCH_FLAGS.FIND_FROMEND, src, src.Length, "do", 2, false), Is.EqualTo(11));
			Assert.That(FindStringOrdinal(SEARCH_FLAGS.FIND_FROMSTART, src, src.Length, "do", 2, false), Is.EqualTo(4));
			Assert.That(FindStringOrdinal(SEARCH_FLAGS.FIND_STARTSWITH, src, src.Length, "how", 2, false), Is.EqualTo(-1));
			Assert.That(FindStringOrdinal(SEARCH_FLAGS.FIND_STARTSWITH, src, src.Length, "how", 2, true), Is.EqualTo(0));
		}

		[Test]
		public void FreeLibraryAndExitThreadTest()
		{
			var t = new System.Threading.Thread(ThreadFunc);
			t.Start();
			t.Join();

			void ThreadFunc()
			{
				const string fn = @"C:\Windows\System32\kernel32.dll";
				using (var hLib = LoadLibrary(fn))
				{
					FreeLibraryAndExitThread(hLib, 20);
					hLib.SetHandleAsInvalid();
				}
			}
		}

		[Test]
		public void GetModuleFileNameHandleTest()
		{
			const string fn = @"C:\Windows\System32\tzres.dll";
			using (var hLib = LoadLibrary(fn))
			{
				var f = GetModuleFileName(hLib);
				Assert.That(f, Is.SamePath(fn));
				var hmod = GetModuleHandle(fn);
				Assert.That(hLib.Equals(hmod), Is.True);
				Assert.That(GetModuleHandleEx(GET_MODULE_HANDLE_EX_FLAG.GET_MODULE_HANDLE_EX_FLAG_UNCHANGED_REFCOUNT, fn, out hmod), Is.True);
				Assert.That(hLib.Equals(hmod), Is.True);
			}
		}

		[Test]
		public void GetProcAddressTest()
		{
			const string fn = @"C:\Windows\System32\kernel32.dll";
			using (var hLib = LoadLibrary(fn))
			{
				var a = GetProcAddress(hLib, "GetNativeSystemInfo");
				Assert.That(a, Is.Not.EqualTo(IntPtr.Zero));
			}
		}

		[Test]
		public void LoadLibraryTest()
		{
			using (var hlib = LoadLibrary(badlibfn))
			{
				Assert.That((HINSTANCE)hlib, Is.EqualTo(HINSTANCE.NULL));
				Assert.That(Marshal.GetLastWin32Error(), Is.Not.Zero);
			}

			using (var hlib = LoadLibrary(libfn))
				Assert.That((HINSTANCE)hlib, Is.Not.EqualTo(HINSTANCE.NULL));
		}

		[Test]
		public void LoadLibraryExTest()
		{
			using (var hlib = LoadLibraryEx(badlibfn, IntPtr.Zero, LoadLibraryExFlags.LOAD_LIBRARY_AS_DATAFILE))
			{
				Assert.That((HINSTANCE)hlib, Is.EqualTo(HINSTANCE.NULL));
				Assert.That(Marshal.GetLastWin32Error(), Is.Not.Zero);
			}

			using (var hlib = LoadLibraryEx(libfn, IntPtr.Zero, LoadLibraryExFlags.LOAD_LIBRARY_AS_DATAFILE))
				Assert.That((HINSTANCE)hlib, Is.Not.EqualTo(HINSTANCE.NULL));
		}

		[Test]
		public void FindLoadLockSizeofResourceTest()
		{
			using (var hlib = LoadLibraryEx("ole32.dll", IntPtr.Zero, LoadLibraryExFlags.LOAD_LIBRARY_AS_DATAFILE))
			{
				var hres = FindResource(hlib, 4, ResourceType.RT_CURSOR);
				Assert.That(hres, Is.Not.EqualTo(IntPtr.Zero));
				var sz = SizeofResource(hlib, hres);
				Assert.That(sz, Is.GreaterThan(0));
				var pres = LoadResource(hlib, hres);
				Assert.That((IntPtr)pres, Is.Not.EqualTo(IntPtr.Zero));
				var pmem = LockResource(pres);
				Assert.That(pmem, Is.Not.EqualTo(IntPtr.Zero));
			}
		}

		[Test]
		public void QueryOptionalDelayLoadedAPITest()
		{
			Assert.That(() => QueryOptionalDelayLoadedAPI(GetModuleHandle(), "kernel32.dll", "GetNativeSystemInfo"), Throws.Nothing);
		}
	}
}