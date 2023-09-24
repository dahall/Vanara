using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class LibLoaderApiTests
{
	internal const string badlibfn = @"C:\Windows\System32\ole3.dll";
	internal const string libfn = @"ole32.dll";
	const string resFile = @"C:\Windows\en-US\regedit.exe.mui";

	[Test]
	public void AddRemoveDllDirectoryTest()
	{
		IntPtr ptr = AddDllDirectory(TestCaseSources.TempDir);
		Assert.That(ptr, Is.Not.EqualTo(IntPtr.Zero));
		Assert.That(RemoveDllDirectory(ptr), Is.True);
	}

	[Test]
	public void EnumResourceLanguagesExTest()
	{
		using SafeHINSTANCE hLib = LoadLibraryEx(resFile, IntPtr.Zero, LoadLibraryExFlags.LOAD_LIBRARY_AS_IMAGE_RESOURCE);
		IReadOnlyList<LANGID>? l = null;
		Assert.That(() => l = EnumResourceLanguagesEx(hLib, ResourceType.RT_STRING, 2), Throws.Nothing);
		Assert.That(l!.Count, Is.GreaterThan(0));
		TestContext.WriteLine(string.Join(" : ", l));
	}

	[Test]
	public void EnumResourceTypesExTest()
	{
		using SafeHINSTANCE hLib = LoadLibraryEx(resFile, IntPtr.Zero, LoadLibraryExFlags.LOAD_LIBRARY_AS_IMAGE_RESOURCE);
		IReadOnlyList<ResourceId>? l = null;
		Assert.That(() => l = EnumResourceTypesEx(hLib), Throws.Nothing);
		Assert.That(l!.Count, Is.GreaterThan(0));
		TestContext.WriteLine(string.Join(" : ", l.Select(i => (ResourceType)i.id)));
	}

	[Test]
	public void EnumResourceNamesTest()
	{
		using SafeHINSTANCE hLib = LoadLibraryEx(resFile, IntPtr.Zero, LoadLibraryExFlags.LOAD_LIBRARY_AS_IMAGE_RESOURCE);
		IReadOnlyList<ResourceId>? l = null;
		Assert.That(() => l = EnumResourceNamesEx(hLib, ResourceType.RT_STRING), Throws.Nothing);
		Assert.That(l!.Count, Is.GreaterThan(0));
		foreach (ResourceId resourceName in l)
			Assert.That(resourceName.ToString(), Has.Length.GreaterThan(0));
		TestContext.WriteLine(string.Join(" : ", l.Select(i => i.id)));
	}

	[Test]
	public void FindResourceTest()
	{
		using SafeHINSTANCE hLib = LoadLibraryEx(@"comctl32.dll", IntPtr.Zero, LoadLibraryExFlags.LOAD_LIBRARY_AS_IMAGE_RESOURCE);
		IntPtr ptr = (IntPtr)FindResource(hLib, 65, ResourceType.RT_STRING);
		Assert.That(ptr, Is.Not.EqualTo(IntPtr.Zero));
	}

	[Test]
	public void FindResourceExTest()
	{
		using SafeHINSTANCE hLib = LoadLibraryEx(@"comctl32.dll", IntPtr.Zero, LoadLibraryExFlags.LOAD_LIBRARY_AS_IMAGE_RESOURCE);
		IntPtr ptr = (IntPtr)FindResourceEx(hLib, 65, ResourceType.RT_STRING, 1033);
		Assert.That(ptr, Is.Not.EqualTo(IntPtr.Zero));
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
		System.Threading.Thread t = new(ThreadFunc);
		t.Start();
		t.Join();

		void ThreadFunc()
		{
			const string fn = @"C:\Windows\System32\kernel32.dll";
			using SafeHINSTANCE hLib = LoadLibrary(fn);
			FreeLibraryAndExitThread(hLib, 20);
			hLib.SetHandleAsInvalid();
		}
	}

	[Test]
	public void GetModuleFileNameHandleTest()
	{
		const string fn = @"C:\Windows\System32\tzres.dll";
		using SafeHINSTANCE hLib = LoadLibrary(fn);
		string f = GetModuleFileName(hLib);
		Assert.That(f, Is.SamePath(fn));
		SafeHINSTANCE hmod = GetModuleHandle(fn);
		Assert.That(hLib.Equals(hmod), Is.True);
		Assert.That(GetModuleHandleEx(GET_MODULE_HANDLE_EX_FLAG.GET_MODULE_HANDLE_EX_FLAG_UNCHANGED_REFCOUNT, fn, out hmod), Is.True);
		Assert.That(hLib.Equals(hmod), Is.True);
	}

	[Test]
	public void GetProcAddressTest()
	{
		const string fn = @"C:\Windows\System32\kernel32.dll";
		using SafeHINSTANCE hLib = LoadLibrary(fn);
		IntPtr a = GetProcAddress(hLib, "GetNativeSystemInfo");
		Assert.That(a, Is.Not.EqualTo(IntPtr.Zero));
	}

	[Test]
	public void LoadLibraryTest()
	{
		using (SafeHINSTANCE hlib = LoadLibrary(badlibfn))
		{
			Assert.That((HINSTANCE)hlib, Is.EqualTo(HINSTANCE.NULL));
			Assert.That(Marshal.GetLastWin32Error(), Is.Not.Zero);
		}

		using (SafeHINSTANCE hlib = LoadLibrary(libfn))
			Assert.That((HINSTANCE)hlib, Is.Not.EqualTo(HINSTANCE.NULL));
	}

	[Test]
	public void LoadLibraryExTest()
	{
		using (SafeHINSTANCE hlib = LoadLibraryEx(badlibfn, IntPtr.Zero, LoadLibraryExFlags.LOAD_LIBRARY_AS_DATAFILE))
		{
			Assert.That((HINSTANCE)hlib, Is.EqualTo(HINSTANCE.NULL));
			Assert.That(Marshal.GetLastWin32Error(), Is.Not.Zero);
		}

		using (SafeHINSTANCE hlib = LoadLibraryEx(libfn, IntPtr.Zero, LoadLibraryExFlags.LOAD_LIBRARY_AS_DATAFILE))
			Assert.That((HINSTANCE)hlib, Is.Not.EqualTo(HINSTANCE.NULL));
	}

	[Test]
	public void FindLoadLockSizeofResourceTest()
	{
		using SafeHINSTANCE hlib = LoadLibraryEx("ole32.dll", IntPtr.Zero, LoadLibraryExFlags.LOAD_LIBRARY_AS_DATAFILE);
		HRSRC hres = FindResource(hlib, 4, ResourceType.RT_CURSOR);
		Assert.That(hres, Is.Not.EqualTo(IntPtr.Zero));
		uint sz = SizeofResource(hlib, hres);
		Assert.That(sz, Is.GreaterThan(0));
		HRSRCDATA pres = LoadResource(hlib, hres);
		Assert.That((IntPtr)pres, Is.Not.EqualTo(IntPtr.Zero));
		IntPtr pmem = LockResource(pres);
		Assert.That(pmem, Is.Not.EqualTo(IntPtr.Zero));
	}

	[Test]
	public void QueryOptionalDelayLoadedAPITest()
	{
		Assert.That(() => QueryOptionalDelayLoadedAPI(GetModuleHandle(), "kernel32.dll", "GetNativeSystemInfo"), Throws.Nothing);
	}
}