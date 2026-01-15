using NUnit.Framework;

namespace Vanara.InteropServices.Tests;

[TestFixture()]
public class StrPtrTests
{
	[Test()]
	public void StrPtrTest()
	{
		Assert.That(Marshal.SizeOf<LPTSTR>() == Marshal.SizeOf<IntPtr>());
		var p0 = new LPTSTR();
		Assert.That(p0.IsNull);
		var p1 = new LPTSTR("Test");
		Assert.That(!p1.IsNull);
		Assert.That((string?) p1, Is.EqualTo("Test"));
		p1.Free();
	}

	[Test()]
	public void StrPtrTest1()
	{
		var p1 = new LPTSTR(256);
		Assert.That(!p1.IsNull);
		Assert.That((string?) p1, Is.EqualTo(""));
		var bytes = Marshal.SystemDefaultCharSize == 1 ? Encoding.ASCII.GetBytes("Test\0") : Encoding.Unicode.GetBytes("Test\0");
		Marshal.Copy(bytes, 0, (IntPtr)p1, bytes.Length);
		Assert.That((string?) p1, Is.EqualTo("Test"));
		p1.Free();
	}

	[Test()]
	public void AssignTest()
	{
		var p0 = new LPTSTR();
		Assert.That(p0.IsNull);
		p0.Assign("Test", out var cc);
		Assert.That(!p0.IsNull);
		Assert.That((string?)p0, Is.EqualTo("Test"));
		Assert.That(cc, Is.EqualTo(5));
		p0.Free();
		var p1 = new LPTSTR("Test");
		Assert.That(!p1.IsNull);
		Assert.That((string?) p1, Is.EqualTo("Test"));
		p1.Assign("Test2");
		Assert.That(!p1.IsNull);
		Assert.That((string?) p1, Is.EqualTo("Test2"));
		p1.Free();
	}

	[Test()]
	public void AssignConstantTest()
	{
		var p0 = new LPTSTR();
		Assert.That(p0.IsNull);
		p0.AssignConstant(1);
		Assert.That(!p0.IsNull);
		Assert.That((IntPtr)p0, Is.EqualTo(new IntPtr(1)));
		Assert.That(p0.Free, Throws.Nothing);
	}

	[Test()]
	public void FreeTest()
	{
		var p1 = new LPTSTR(1024);
		var ptr1 = (IntPtr) p1;
		Assert.That(ptr1, Is.Not.EqualTo(IntPtr.Zero));
		p1.Free();
		ptr1 = (IntPtr) p1;
		Assert.That(ptr1, Is.EqualTo(IntPtr.Zero));
	}

	[Test()]
	public void StrPtrUniTest()
	{
		Assert.That(Marshal.SizeOf<LPWSTR>() == Marshal.SizeOf<IntPtr>());
		var p0 = new LPWSTR();
		Assert.That(p0.IsNull);
		var p1 = new LPWSTR("Test");
		Assert.That(!p1.IsNull);
		Assert.That((string?) p1, Is.EqualTo("Test"));
		p1.Free();
	}

	[Test()]
	public void StrPtrUniTest1()
	{
		var p1 = new LPWSTR(256);
		Assert.That(!p1.IsNull);
		Assert.That((string?) p1, Is.EqualTo(""));
		var bytes = Marshal.SystemDefaultCharSize == 1 ? Encoding.ASCII.GetBytes("Test\0") : Encoding.Unicode.GetBytes("Test\0");
		Marshal.Copy(bytes, 0, (IntPtr)p1, bytes.Length);
		Assert.That((string?) p1, Is.EqualTo("Test"));
		p1.Free();
	}

	[Test()]
	public void AssignUniTest()
	{
		var p0 = new LPWSTR();
		Assert.That(p0.IsNull);
		p0.Assign("Test", out var cc);
		Assert.That(!p0.IsNull);
		Assert.That((string?)p0, Is.EqualTo("Test"));
		Assert.That(cc, Is.EqualTo(5));
		p0.Free();
		var p1 = new LPWSTR("Test");
		Assert.That(!p1.IsNull);
		Assert.That((string?) p1, Is.EqualTo("Test"));
		p1.Assign("Test2");
		Assert.That(!p1.IsNull);
		Assert.That((string?) p1, Is.EqualTo("Test2"));
		p1.Free();
	}

	[Test()]
	public void AssignConstantUniTest()
	{
		var p0 = new LPWSTR();
		Assert.That(p0.IsNull);
		p0.AssignConstant(1);
		Assert.That(!p0.IsNull);
		Assert.That((IntPtr)p0, Is.EqualTo(new IntPtr(1)));
		Assert.That(p0.Free, Throws.Nothing);
	}

	[Test()]
	public void FreeUniTest()
	{
		var p1 = new LPWSTR(1024);
		var ptr1 = (IntPtr) p1;
		Assert.That(ptr1, Is.Not.EqualTo(IntPtr.Zero));
		p1.Free();
		ptr1 = (IntPtr) p1;
		Assert.That(ptr1, Is.EqualTo(IntPtr.Zero));
	}
}