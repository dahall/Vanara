using NUnit.Framework;
using System.Reflection;
using Vanara.Extensions;
using Vanara.PInvoke;

namespace Vanara.InteropServices.Tests;

[TestFixture]
public class StructHelpersTest
{
	static readonly string?[] strings = ["AAA", null, "CCC"];
	static readonly POINT[] pts = [new(1, 1), new(2, 2), new(3, 3)];

	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	struct TEST1
	{
		public int l;
		public LPCWSTRArrayPointer p;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 4)]
	struct TEST2
	{
		public int l;

		[SizeDef("l")]
		public ArrayPointer<POINT> p;
	}

	[Test]
	public void StringArrayTest()
	{
		TEST1 t = new() { l = strings.Length, p = SafeHGlobalHandle.CreateFromStringList(strings, StringListPackMethod.Packed, CharSet.Unicode) };
		Assert.That(t.p, Is.Not.EqualTo(IntPtr.Zero));
		Assert.That(t.p.ToArray(t.l), Is.EquivalentTo(strings));
		Assert.That(t.p[0], Is.EqualTo(strings[0]));
		Assert.That(t.p[1], Is.EqualTo(strings[1]));

		var sz = Marshal.SizeOf(t);
		Assert.That(sz, Is.EqualTo(sizeof(int) + IntPtr.Size));

		var m = Marshal.AllocHGlobal(sz);
		try
		{
			Assert.That(() => Marshal.StructureToPtr(t, m, false), Throws.Nothing);
			TEST1 tr = default;
			Assert.That(() => tr = Marshal.PtrToStructure<TEST1>(m), Throws.Nothing);
			Assert.That(tr.l, Is.EqualTo(t.l));
			Assert.That(tr.p, Is.EqualTo(t.p));
			Assert.That(tr.p.ToArray(tr.l), Is.EquivalentTo(strings));
		}
		finally
		{
			Marshal.FreeHGlobal(m);
		}
	}

	[Test]
	public void StructArrayTest()
	{
		TEST2 t = new() { l = pts.Length };
		using var mem = t.p.DestructiveAssign(pts);
		Assert.That(t.p, Is.Not.EqualTo(IntPtr.Zero));
		Assert.That(t.p.ToArray(t.l), Is.EquivalentTo(pts));
		Assert.That(t.p[0], Is.EqualTo(pts[0]));
		Assert.That(t.p[1], Is.EqualTo(pts[1]));

		var sz = Marshal.SizeOf(t);
		Assert.That(sz, Is.EqualTo(sizeof(int) + IntPtr.Size));

		var m = Marshal.AllocHGlobal(sz);
		try
		{
			Assert.That(() => Marshal.StructureToPtr(t, m, false), Throws.Nothing);
			TEST2 tr = default;
			Assert.That(() => tr = Marshal.PtrToStructure<TEST2>(m), Throws.Nothing);
			Assert.That(tr.l, Is.EqualTo(t.l));
			Assert.That(tr.p, Is.EqualTo(t.p));
			Assert.That(tr.p.ToArray(tr.l), Is.EquivalentTo(pts));
		}
		finally
		{
			Marshal.FreeHGlobal(m);
		}

		unsafe
		{
			POINT* pT = t.p;
			Assert.That(pT[1], Is.EqualTo(pts[1]));
		}

		POINT newpt = new(4, 4);
		t.p[1] = newpt;
		Assert.That(t.p[1], Is.EqualTo(newpt));

		// Get the size from the attribute
		SizeT? val = t.GetFieldSizeViaAttribute("p");
		Assert.That((int)val!.GetValueOrDefault(), Is.EqualTo(t.l));
	}
}