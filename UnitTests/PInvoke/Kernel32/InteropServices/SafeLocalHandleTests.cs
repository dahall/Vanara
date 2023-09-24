using NUnit.Framework;
using Vanara.PInvoke;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.InteropServices.Tests;

[TestFixture()]
public class SafeLocalHandleTests
{
	[Test(Description = "Allocate an enumeration")]
	public void CreateFromListTest()
	{
		int[] r = new[] { 5, 5, 5, 5 };
		SafeLocalHandle h = SafeLocalHandle.CreateFromList(r, r.Length);
		Assert.That(!h.IsClosed && !h.IsInvalid);
		Assert.That((int)h.Size, Is.EqualTo(Marshal.SizeOf(typeof(int)) * r.Length));
		Assert.That(h.ToStructure<int>(), Is.EqualTo(5));
		Assert.That(h.ToEnumerable<int>(4), Has.Exactly(4).EqualTo(5).And.Exactly(4).Items);

		RECT[] d = new[] { new RECT(1, 1, 1, 1), new RECT(2, 2, 2, 2) };
		h = SafeLocalHandle.CreateFromList(d, d.Length);
		Assert.That(!h.IsClosed && !h.IsInvalid);
		Assert.That((int)h.Size, Is.EqualTo(Marshal.SizeOf(typeof(RECT)) * d.Length));
		Assert.That(h.ToStructure<RECT>().X, Is.EqualTo(1));
		Assert.That(h.ToArray<RECT>(4), Has.Exactly(4).Items);

		PRECT[] p = new[] { new PRECT(1, 1, 1, 1), new PRECT(2, 2, 2, 2) };
		h = SafeLocalHandle.CreateFromList(p);
		Assert.That(!h.IsClosed && !h.IsInvalid);
		Assert.That((int)h.Size, Is.EqualTo(Marshal.SizeOf(typeof(PRECT)) * p.Length));
		Assert.That(h.ToArray<RECT>(4), Has.Exactly(4).Items);

		Assert.That(() => SafeLocalHandle.CreateFromList(new[] { "X" }), Throws.ArgumentException);
	}

	[Test(Description = "Allocate an enumeration of strings.")]
	public void CreateFromStringListTest()
	{
		string[] r = new[] { "5", "5", "5", "5" };

		SafeLocalHandle h = SafeLocalHandle.CreateFromStringList(r, StringListPackMethod.Concatenated, CharSet.Ansi, 7);
		Assert.That(!h.IsClosed && !h.IsInvalid);
		Assert.That((int)h.Size, Is.EqualTo(16));
		Assert.That(h.ToStringEnum(CharSet.Ansi, 7), Has.Exactly(4).EqualTo("5").And.Exactly(4).Items);
		h = SafeLocalHandle.CreateFromStringList(r, StringListPackMethod.Concatenated, CharSet.Unicode, 7);
		Assert.That(!h.IsClosed && !h.IsInvalid);
		Assert.That((int)h.Size, Is.EqualTo(25));
		Assert.That(h.ToStringEnum(CharSet.Unicode, 7), Has.Exactly(4).EqualTo("5").And.Exactly(4).Items);
		h = SafeLocalHandle.CreateFromStringList(r);
		Assert.That(!h.IsClosed && !h.IsInvalid);
		Assert.That((int)h.Size, Is.EqualTo(18));
		Assert.That(h.ToString(-1), Is.EqualTo("5"));
		Assert.That(h.ToStringEnum(), Has.Exactly(4).EqualTo("5").And.Exactly(4).Items);

		h = SafeLocalHandle.CreateFromStringList(r, StringListPackMethod.Packed, CharSet.Ansi, 7);
		Assert.That(!h.IsClosed && !h.IsInvalid);
		Assert.That((int)h.Size, Is.EqualTo(7 + IntPtr.Size + r.Length * (2 + IntPtr.Size)));
		Assert.That(h.ToStringEnum(4, CharSet.Ansi, 7), Has.Exactly(4).EqualTo("5").And.Exactly(4).Items);
		h = SafeLocalHandle.CreateFromStringList(r, StringListPackMethod.Packed, CharSet.Unicode, 7);
		Assert.That(!h.IsClosed && !h.IsInvalid);
		Assert.That((int)h.Size, Is.EqualTo(7 + IntPtr.Size + r.Length * (4 + IntPtr.Size)));
		Assert.That(h.ToStringEnum(4, CharSet.Unicode, 7), Has.Exactly(4).EqualTo("5").And.Exactly(4).Items);
		h = SafeLocalHandle.CreateFromStringList(r, StringListPackMethod.Packed);
		Assert.That(!h.IsClosed && !h.IsInvalid);
		Assert.That((int)h.Size, Is.EqualTo(IntPtr.Size + r.Length * (4 + IntPtr.Size)));
		Assert.That(h.ToStringEnum(4, CharSet.Unicode), Has.Exactly(4).EqualTo("5").And.Exactly(4).Items);

		h = SafeLocalHandle.CreateFromStringList(null);
		Assert.That((int)h.Size, Is.EqualTo(StringHelper.GetCharSize()));
	}

	[Test(Description = "Allocate a structure")]
	public void CreateFromStructureTest()
	{
		RECT r = new(5, 5, 5, 5);
		SafeLocalHandle h = SafeLocalHandle.CreateFromStructure(r);
		Assert.That(!h.IsClosed && !h.IsInvalid);
		Assert.That((int)h.Size, Is.EqualTo(Marshal.SizeOf(typeof(RECT))));
		Assert.That(h.ToStructure<RECT>().X, Is.EqualTo(5));
	}

	[Test()]
	public void ResizeTest()
	{
		SafeLocalHandle h = new(5);
		Assert.That(!h.IsClosed && !h.IsInvalid && h.Size == 5);
		IntPtr ptr = (IntPtr)h;
		h.Size = 50;
		Assert.That(!h.IsClosed && !h.IsInvalid && (IntPtr)h != ptr);
		Assert.That((int)h.Size, Is.EqualTo(50));
	}

	[Test()]
	public void SafeLocalHandleTest()
	{
		SafeLocalHandle h = new(5);
		Assert.That(!h.IsClosed && !h.IsInvalid);
		Assert.That((int)h.Size, Is.EqualTo(5));
		h.Dispose();
		Assert.That(h.IsClosed && h.IsInvalid);

		h = new SafeLocalHandle(LocalAlloc(LMEM.LPTR, 5), 5);
		Assert.That(!h.IsClosed && !h.IsInvalid);
		Assert.That(h, Is.Not.EqualTo(SafeHGlobalHandle.Null));
		h.Dispose();
		Assert.That(h.IsClosed && h.IsInvalid);

		Assert.That(() => new SafeLocalHandle(-1), Throws.TypeOf<ArgumentOutOfRangeException>());
	}

	[Test()]
	public void SafeLocalHandleTest1()
	{
		SafeLocalHandle h = new(LocalAlloc(LMEM.LPTR, 5), 5);
		Assert.That(!h.IsClosed && !h.IsInvalid);
		Assert.That((int)h.Size, Is.EqualTo(5));
		h.Dispose();
		Assert.That(h.IsClosed && h.IsInvalid);
	}

	[Test()]
	public void SafeLocalHandleTest2()
	{
		SafeLocalHandle h = new(new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 });
		Assert.That(!h.IsClosed && !h.IsInvalid);
		Assert.That((int)h.Size, Is.EqualTo(10));
		h.Dispose();
		Assert.That(h.IsClosed && h.IsInvalid);
	}

	[Test()]
	public void SafeLocalHandleTest3()
	{
		SafeLocalHandle h = new(new[] { (IntPtr)1, (IntPtr)2, (IntPtr)3, (IntPtr)4, (IntPtr)5 });
		Assert.That(!h.IsClosed && !h.IsInvalid);
		Assert.That((int)h.Size, Is.EqualTo(5 * IntPtr.Size));
		h.Dispose();
		Assert.That(h.IsClosed && h.IsInvalid);
	}

	[Test()]
	public void SafeLocalHandleTest4()
	{
		SafeLocalHandle h = new("0123456789");
		Assert.That(!h.IsClosed && !h.IsInvalid);
		Assert.That((int)h.Size, Is.EqualTo(11 * Marshal.SystemDefaultCharSize));
		h.Dispose();
		Assert.That(h.IsClosed && h.IsInvalid);

		Assert.That(SafeLocalHandle.Null.IsInvalid);
	}

	[Test()]
	public void LocalMemoryMethodsTest()
	{
		LocalMemoryMethods mm = new();
		IntPtr h = mm.AllocStringAnsi("Test");
		Assert.That(h, Is.Not.EqualTo(IntPtr.Zero));
		Assert.That(() => mm.FreeMem(h), Throws.Nothing);
		h = mm.AllocStringAnsi(null);
		Assert.That(h, Is.EqualTo(IntPtr.Zero));
		Assert.That(() => mm.FreeMem(h), Throws.Nothing);
		System.Security.SecureString ss = new();
		h = mm.AllocSecureStringUni(ss);
		Assert.That(h, Is.Not.EqualTo(IntPtr.Zero));
		Assert.That(() => mm.FreeSecureStringUni(h), Throws.Nothing);
		h = mm.AllocSecureStringUni(null);
		Assert.That(h, Is.EqualTo(IntPtr.Zero));
		Assert.That(() => mm.FreeSecureStringUni(h), Throws.Nothing);
		h = mm.AllocSecureStringAnsi(ss);
		Assert.That(h, Is.Not.EqualTo(IntPtr.Zero));
		Assert.That(() => mm.FreeSecureStringAnsi(h), Throws.Nothing);
	}
}