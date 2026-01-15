using NUnit.Framework;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public partial class WinBaseTests_MemMgmt
{
	[Test]
	public void HGlobalTest()
	{
		HGLOBAL hMem;
		Assert.That(hMem = GlobalAlloc(GMEM.GHND, 256), ResultIs.ValidHandle);
		try
		{
			Assert.That(GlobalFlags(hMem), ResultIs.Value(GMEM.GMEM_FIXED));
			Assert.That(GlobalSize(hMem), ResultIs.Value(new SIZE_T(256)));
			IntPtr ptr;
			Assert.That(ptr = GlobalLock(hMem), ResultIs.ValidHandle);
			Assert.That(GlobalHandle(ptr), ResultIs.Value(hMem));
			Assert.That(GlobalUnlock(hMem), ResultIs.Successful);
			Assert.That(hMem = GlobalReAlloc(hMem, 128, 0), ResultIs.ValidHandle);
		}
		finally
		{
			Assert.That(GlobalFree(hMem), ResultIs.Value(HGLOBAL.NULL));
		}
	}

	[Test]
	public void HLocalTest()
	{
		HLOCAL hMem;
		Assert.That(hMem = LocalAlloc(LMEM.LHND, 256), ResultIs.ValidHandle);
		try
		{
			Assert.That(LocalFlags(hMem), ResultIs.Value(LMEM.LMEM_FIXED));
			Assert.That(LocalSize(hMem), ResultIs.Value(new SIZE_T(256)));
			IntPtr ptr;
			Assert.That(ptr = LocalLock(hMem), ResultIs.ValidHandle);
			Assert.That(LocalHandle(ptr), ResultIs.Value(hMem));
			Assert.That(LocalUnlock(hMem), ResultIs.Successful);
			Assert.That(hMem = LocalReAlloc(hMem, 128, 0), ResultIs.ValidHandle);
		}
		finally
		{
			Assert.That(LocalFree(hMem), ResultIs.Value(HLOCAL.NULL));
		}
	}

	[Test]
	public void IsBadPtrTest()
	{
		using SafeHGlobalHandle mem = new("ABC");
#pragma warning disable CS0618 // Type or member is obsolete
		Assert.That(IsBadCodePtr(mem), ResultIs.Successful);
		Assert.That(IsBadReadPtr(mem, 8), ResultIs.Successful);
		Assert.That(IsBadStringPtr(mem, 4), ResultIs.Successful);
		Assert.That(IsBadWritePtr(mem, 8), ResultIs.Successful);
#pragma warning restore CS0618 // Type or member is obsolete
	}
}