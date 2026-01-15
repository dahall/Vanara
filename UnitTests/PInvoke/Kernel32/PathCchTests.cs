using NUnit.Framework;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class PathCchTests
{
	[Test]
	public void PathAllocCanonicalizeTest()
	{
		Assert.That(PathAllocCanonicalize(@"C:\name_1\.\name_2\..\name_3", PATHCCH_OPTIONS.PATHCCH_NONE, out string ret), Is.EqualTo((HRESULT)0));
		Assert.That(ret, Is.EqualTo(@"C:\name_1\name_3"));
	}

	[Test]
	public void LocalStringMarshalerTest()
	{
		long originalByteCount = GC.GetTotalMemory(true);
		for (int i = 0; i < 5000; i++)
		{
			PathAllocCanonicalize(@"C:\name_1\.\name_2\..\name_3", PATHCCH_OPTIONS.PATHCCH_NONE, out string ret);
			Assert.That(ret, Is.EqualTo(@"C:\name_1\name_3"));
		}
		GC.Collect();
		GC.WaitForPendingFinalizers();
		GC.Collect();
		long finalByteCount = GC.GetTotalMemory(true);
		Assert.That(Math.Abs(finalByteCount - originalByteCount), Is.LessThan(2000));
	}

	[Test]
	public void PathAllocCombineTest()
	{
		Assert.That(PathAllocCombine(@"C:\name_1\.\name_2\..", @"name_3", PATHCCH_OPTIONS.PATHCCH_NONE, out string ret), Is.EqualTo((HRESULT)0));
		Assert.That(ret, Is.EqualTo(@"C:\name_1\name_3"));
	}

	[Test]
	public void PathCchAddBackslashTest()
	{
		StringBuilder sb = new(TestCaseSources.TempDirWhack, 100);
		Assert.That(PathCchAddBackslash(sb, sb.Capacity), Is.EqualTo((HRESULT)HRESULT.S_FALSE));
		Assert.That(sb.ToString(), Is.EqualTo(TestCaseSources.TempDirWhack));

		sb = new StringBuilder(TestCaseSources.TempDir, 100);
		Assert.That(PathCchAddBackslash(sb, sb.Capacity), Is.EqualTo((HRESULT)0));
		Assert.That(sb.ToString(), Is.EqualTo(TestCaseSources.TempDirWhack));
	}

	[Test]
	public void PathCchAddBackslashExTest()
	{
		StringBuilder sb = new(TestCaseSources.TempDirWhack, 64);
		Assert.That(PathCchAddBackslashEx(sb, sb.Capacity, out var end, out SIZE_T rem), Is.EqualTo((HRESULT)HRESULT.S_FALSE));
		Assert.That(sb.ToString(), Is.EqualTo(TestCaseSources.TempDirWhack));
		Assert.That(end, Is.Not.EqualTo(IntPtr.Zero));
		Assert.That(rem, Is.LessThan(60));

		sb = new StringBuilder(TestCaseSources.TempDir, 64);
		Assert.That(PathCchAddBackslashEx(sb, sb.Capacity, out end, out rem), Is.EqualTo((HRESULT)0));
		Assert.That(sb.ToString(), Is.EqualTo(TestCaseSources.TempDirWhack));
		Assert.That(rem, Is.LessThan(60));
	}

	[Test]
	public void PathCchAddBackslashExTest2()
	{
		SafePWSTR sb = new(TestCaseSources.TempDirWhack, 64);
		Assert.That(PathCchAddBackslashEx(sb, sb.Capacity, out PWSTR end, out _), Is.EqualTo((HRESULT)HRESULT.S_FALSE));
		Assert.That(sb.ToString(), Is.EqualTo(TestCaseSources.TempDirWhack));
		Assert.That(end, Is.EqualTo(sb.DangerousGetHandle().Offset(sb.Length * 2)));

		sb = new SafePWSTR(TestCaseSources.TempDir, 64);
		Assert.That(PathCchAddBackslashEx(sb, sb.Size, out end, out _), Is.EqualTo((HRESULT)0));
		Assert.That(sb.ToString(), Is.EqualTo(TestCaseSources.TempDirWhack));
		Assert.That(end, Is.EqualTo(sb.DangerousGetHandle().Offset(sb.Length * 2)));
	}

	[Test]
	public void PathCchAddExtensionTest()
	{
		StringBuilder sb = new(@"C:\Temp\Dog", 64);
		Assert.That(PathCchAddExtension(sb, sb.Capacity, "txt"), Is.EqualTo((HRESULT)0));
		Assert.That(sb.ToString(), Is.EqualTo(@"C:\Temp\Dog.txt"));
	}

	[Test]
	public void PathCchAppendTest()
	{
		StringBuilder sb = new(@"C:\Temp\Dog", 64);
		Assert.That(PathCchAppend(sb, sb.Capacity, "txt"), Is.EqualTo((HRESULT)0));
		Assert.That(sb.ToString(), Is.EqualTo(@"C:\Temp\Dog\txt"));
	}

	[Test]
	public void PathCchAppendExTest()
	{
		StringBuilder sb = new(@"C:\Temp\Dog", 64);
		Assert.That(PathCchAppendEx(sb, sb.Capacity, "txt", PATHCCH_OPTIONS.PATHCCH_ENSURE_TRAILING_SLASH), Is.EqualTo((HRESULT)0));
		Assert.That(sb.ToString(), Is.EqualTo(@"C:\Temp\Dog\txt\"));
	}

	[Test]
	public void PathCchCanonicalizeTest()
	{
		StringBuilder sb = new(64);
		Assert.That(PathCchCanonicalize(sb, sb.Capacity, @"C:\name_1\.\name_2\..\name_3"), Is.EqualTo((HRESULT)0));
		Assert.That(sb.ToString(), Is.EqualTo(@"C:\name_1\name_3"));
	}

	[Test]
	public void PathCchCanonicalizeExTest()
	{
		StringBuilder sb = new(64);
		Assert.That(PathCchCanonicalizeEx(sb, sb.Capacity, @"C:\name_1\.\name_2\..\name_3", PATHCCH_OPTIONS.PATHCCH_ENSURE_TRAILING_SLASH), Is.EqualTo((HRESULT)0));
		Assert.That(sb.ToString(), Is.EqualTo(@"C:\name_1\name_3\"));
	}

	[Test]
	public void PathCchCombineTest()
	{
		StringBuilder sb = new(64);
		Assert.That(PathCchCombine(sb, sb.Capacity, @"C:\name_1\.\name_2\..", @"name_3"), Is.EqualTo((HRESULT)0));
		Assert.That(sb.ToString(), Is.EqualTo(@"C:\name_1\name_3"));
	}

	[Test]
	public void PathCchCombineExTest()
	{
		StringBuilder sb = new(64);
		Assert.That(PathCchCombineEx(sb, sb.Capacity, @"C:\name_1\.\name_2\..", @"name_3", PATHCCH_OPTIONS.PATHCCH_ENSURE_TRAILING_SLASH), Is.EqualTo((HRESULT)0));
		Assert.That(sb.ToString(), Is.EqualTo(@"C:\name_1\name_3\"));
	}

	[Test]
	public void PathCchFindExtensionTest()
	{
		SafeCoTaskMemString sb = new(@"C:\Temp\dog.txt", 64);
		Assert.That(PathCchFindExtension((IntPtr)sb, sb.Capacity, out PWSTR ptr), Is.EqualTo((HRESULT)0));
		Assert.That(ptr, Is.EqualTo(sb.DangerousGetHandle().Offset(22)));
	}

	[Test]
	public void PathCchIsRootTest() => Assert.That(PathCchIsRoot(@"C:\"), Is.True);

	[Test]
	public void PathCchRemoveBackslashTest()
	{
		StringBuilder sb = new(TestCaseSources.TempDirWhack, 64);
		Assert.That(PathCchRemoveBackslash(sb, sb.Capacity), Is.EqualTo((HRESULT)0));
		Assert.That(sb.ToString(), Is.EqualTo(TestCaseSources.TempDir));

		sb = new StringBuilder(TestCaseSources.TempDir, 64);
		Assert.That(PathCchRemoveBackslash(sb, sb.Capacity), Is.EqualTo((HRESULT)HRESULT.S_FALSE));
		Assert.That(sb.ToString(), Is.EqualTo(TestCaseSources.TempDir));
	}

	[Test]
	public void PathCchRemoveBackslashExTest()
	{
		SafeCoTaskMemString sb = new(TestCaseSources.TempDirWhack, 64);
		Assert.That(PathCchRemoveBackslashEx((IntPtr)sb, sb.Capacity, out PWSTR end, out SIZE_T rem), Is.EqualTo((HRESULT)0));
		Assert.That(sb.ToString(), Is.EqualTo(TestCaseSources.TempDir));
		Assert.That(end, Is.EqualTo(sb.DangerousGetHandle().Offset(14)));

		sb = new SafeCoTaskMemString(TestCaseSources.TempDir, 64);
		Assert.That(PathCchRemoveBackslashEx((IntPtr)sb, sb.Capacity, out end, out rem), Is.EqualTo((HRESULT)HRESULT.S_FALSE));
		Assert.That(sb.ToString(), Is.EqualTo(TestCaseSources.TempDir));
		Assert.That(end, Is.EqualTo(sb.DangerousGetHandle().Offset(14)));
	}

	[Test]
	public void PathCchRemoveExtensionTest()
	{
		StringBuilder sb = new(@"C:\Temp\dog.txt", 64);
		Assert.That(PathCchRemoveExtension(sb, sb.Capacity), Is.EqualTo((HRESULT)0));
		Assert.That(sb.ToString(), Is.EqualTo(@"C:\Temp\dog"));

		sb = new StringBuilder(@"C:\Temp\dog", 64);
		Assert.That(PathCchRemoveExtension(sb, sb.Capacity), Is.EqualTo((HRESULT)HRESULT.S_FALSE));
		Assert.That(sb.ToString(), Is.EqualTo(@"C:\Temp\dog"));
	}

	[Test]
	public void PathCchRemoveFileSpecTest()
	{
		StringBuilder sb = new(@"C:\foo\bar.txt", 64);
		Assert.That(PathCchRemoveFileSpec(sb, sb.Capacity), Is.EqualTo((HRESULT)0));
		Assert.That(sb.ToString(), Is.EqualTo(@"C:\foo"));
	}

	[Test]
	public void PathCchRenameExtensionTest()
	{
		StringBuilder sb = new(@"C:\Temp\dog.txt", 64);
		Assert.That(PathCchRenameExtension(sb, sb.Capacity, "doc"), Is.EqualTo((HRESULT)0));
		Assert.That(sb.ToString(), Is.EqualTo(@"C:\Temp\dog.doc"));

		sb = new StringBuilder(@"C:\Temp\dog", 64);
		Assert.That(PathCchRenameExtension(sb, sb.Capacity, "txt"), Is.EqualTo((HRESULT)0));
		Assert.That(sb.ToString(), Is.EqualTo(@"C:\Temp\dog.txt"));
	}

	[Test]
	public void PathCchSkipRootTest()
	{
		SafeCoTaskMemString sb = new(TestCaseSources.TempDirWhack, 64);
		Assert.That(PathCchSkipRoot((IntPtr)sb, out PWSTR end), Is.EqualTo((HRESULT)0));
		Assert.That(end, Is.EqualTo(sb.DangerousGetHandle().Offset(6)));
	}

	[Test]
	public void PathCchStripPrefixTest()
	{
		StringBuilder sb = new(@"\\?\C:\foo\bar.txt", 64);
		Assert.That(PathCchStripPrefix(sb, sb.Capacity), Is.EqualTo((HRESULT)0));
		Assert.That(sb.ToString(), Is.EqualTo(@"C:\foo\bar.txt"));

		sb = new StringBuilder(@"C:\foo\bar.txt", 64);
		Assert.That(PathCchStripPrefix(sb, sb.Capacity), Is.EqualTo((HRESULT)HRESULT.S_FALSE));
		Assert.That(sb.ToString(), Is.EqualTo(@"C:\foo\bar.txt"));
	}

	[Test]
	public void PathCchStripToRootTest()
	{
		StringBuilder sb = new(@"C:\foo\bar.txt", 64);
		Assert.That(PathCchStripToRoot(sb, sb.Capacity), Is.EqualTo((HRESULT)0));
		Assert.That(sb.ToString(), Is.EqualTo(@"C:\"));

		sb = new StringBuilder(@"\\path1\path2", 64);
		Assert.That(PathCchStripToRoot(sb, sb.Capacity), Is.EqualTo((HRESULT)HRESULT.S_FALSE));
		Assert.That(sb.ToString(), Is.EqualTo(@"\\path1\path2"));
	}

	[Test]
	public void PathIsUNCExTest()
	{
		Assert.That(PathIsUNCEx(@"\\path1\path2\path3", out PWSTR svr), Is.True);
		Assert.That(svr.ToString(), Is.EqualTo(@"path1\path2\path3"));
	}
}