using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Vanara.PInvoke;

namespace Vanara.Extensions.Tests;

[TestFixture()]
public class InteropExtensionsTests
{
	private readonly int intSz = Marshal.SizeOf(typeof(int));

	[Test()]
	public void IsBlittableTest()
	{
		Assert.That(typeof(int).IsBlittable(), Is.True);
		Assert.That(typeof(Guid).IsBlittable(), Is.True);
		Assert.That(typeof(RECT).IsBlittable(), Is.True);
		Assert.That(typeof(TypeCode).IsBlittable(), Is.True);
		Assert.That(typeof(PRECT).IsBlittable(), Is.True);
		Assert.That(typeof(int[]).IsBlittable(), Is.True);
		Assert.That(typeof(RECT[]).IsBlittable(), Is.True);
		Assert.That(typeof(decimal).IsBlittable(), Is.True);
		Assert.That(typeof(bool).IsBlittable(), Is.True);
		Assert.That(typeof(DateTime).IsBlittable(), Is.False);
		Assert.That(typeof(string).IsBlittable(), Is.False);
		Assert.That(typeof(string[]).IsBlittable(), Is.False);
		Assert.That(typeof(AbsClass).IsBlittable(), Is.False);
		Assert.That(typeof(IDisposable).IsBlittable(), Is.False);
		//Assert.That(typeof(int[][]).IsBlittable(), Is.False);
		Assert.That(typeof(RECT?).IsBlittable(), Is.False);
	}

	[Test()]
	public void IsNullableTest()
	{
		Assert.That(typeof(int).IsNullable(), Is.False);
		Assert.That(typeof(RECT?).IsNullable(), Is.True);
		Assert.That(typeof(int?).IsNullable(), Is.True);
	}

	[Test()]
	public void MarshalToPtrTest()
	{
		var h = new SafeHGlobalHandle(Marshal.SizeOf(typeof(RECT)) * 2 + intSz);
		var rs = new[] { new RECT(), new RECT(10, 11, 12, 13) };
		((IntPtr)h).Write(rs, intSz, h.Size);
		Assert.AreEqual(Marshal.ReadInt32((IntPtr)h, 4 * intSz), 0);
		Assert.AreEqual(Marshal.ReadInt32((IntPtr)h, 5 * intSz), 10);
		Assert.AreEqual(Marshal.ReadInt32((IntPtr)h, 7 * intSz), 12);
		var ro = ((IntPtr)h).ToArray<RECT>(2, intSz);
		Assert.AreEqual(ro!.Length, 2);
		Assert.AreEqual(ro[0].left, 0);
		Assert.AreEqual(ro[1].right, 12);
	}

	[Test()]
	public void MarshalToPtr_StructArray_Test()
	{
		var h = IntPtr.Zero;
		try
		{
			var rs = new[] { new RECT(), new RECT(10, 11, 12, 13) };
			h = rs.MarshalToPtr(Marshal.AllocHGlobal, out var a, intSz);
			Assert.That(h, Is.Not.EqualTo(IntPtr.Zero));
			Assert.That(a, Is.EqualTo(Marshal.SizeOf(typeof(RECT)) * rs.Length + intSz));
			Assert.AreEqual(Marshal.ReadInt32((IntPtr)h, 4 * intSz), 0);
			Assert.AreEqual(Marshal.ReadInt32((IntPtr)h, 5 * intSz), 10);
			Assert.AreEqual(Marshal.ReadInt32((IntPtr)h, 7 * intSz), 12);
			var ro = h.ToArray<RECT>(rs.Length, intSz)!;
			Assert.AreEqual(ro.Length, 2);
			Assert.AreEqual(ro[0].left, 0);
			Assert.AreEqual(ro[1].right, 12);
			Marshal.FreeHGlobal(h);

			h = new RECT[0].MarshalToPtr(Marshal.AllocHGlobal, out a, intSz);
			Assert.That(h, Is.Not.EqualTo(IntPtr.Zero));
			Assert.That(a, Is.EqualTo(intSz));

			Assert.That(() => new DateTime[1].MarshalToPtr(Marshal.AllocHGlobal, out a, intSz), Throws.Exception);
		}
		finally
		{
			Marshal.FreeHGlobal(h);
		}
	}

	[Test()]
	public void MarshalToPtr_StrListConc_Test()
	{
		var h = IntPtr.Zero;
		try
		{
			var rs = new[] { "str1", "str2", "str3" };
			h = rs.MarshalToPtr(StringListPackMethod.Concatenated, Marshal.AllocHGlobal, out var a, CharSet.Unicode, intSz);
			Assert.That(h, Is.Not.EqualTo(IntPtr.Zero));
			var chSz = 2;
			Assert.That(a, Is.EqualTo(chSz * (rs[0].Length + 1) * rs.Length + chSz + intSz));
			var ro = h.ToByteArray(a - intSz, intSz);
			var chars = Encoding.Unicode.GetChars(ro!);
			Assert.That(chars.Length, Is.EqualTo((a - intSz) / chSz));
			Assert.That(chars[0], Is.EqualTo('s'));
			Assert.That(chars[4], Is.EqualTo('\0'));
			Assert.That(chars[chars.Length - 2], Is.EqualTo('\0'));
			Assert.That(chars[chars.Length - 1], Is.EqualTo('\0'));
			Marshal.FreeHGlobal(h);

			h = rs.MarshalToPtr(StringListPackMethod.Concatenated, Marshal.AllocHGlobal, out a, CharSet.Ansi, intSz);
			Assert.That(h, Is.Not.EqualTo(IntPtr.Zero));
			chSz = 1;
			Assert.That(a, Is.EqualTo(chSz * (rs[0].Length + 1) * rs.Length + chSz + intSz));
			ro = h.ToByteArray(a - intSz, intSz);
			chars = Encoding.ASCII.GetChars(ro!);
			Assert.That(chars.Length, Is.EqualTo((a - intSz) / chSz));
			Assert.That(chars[0], Is.EqualTo('s'));
			Assert.That(chars[4], Is.EqualTo('\0'));
			Assert.That(chars[chars.Length - 2], Is.EqualTo('\0'));
			Assert.That(chars[chars.Length - 1], Is.EqualTo('\0'));
			Marshal.FreeHGlobal(h);

			h = new string[0].MarshalToPtr(StringListPackMethod.Concatenated, Marshal.AllocHGlobal, out a, CharSet.Unicode, intSz);
			Assert.That(h, Is.Not.EqualTo(IntPtr.Zero));
			Assert.That(a, Is.EqualTo(intSz + 2));

			Assert.That(() => new[] { "" }.MarshalToPtr(StringListPackMethod.Concatenated, Marshal.AllocHGlobal, out a, CharSet.Unicode, intSz), Throws.ArgumentException);
			Assert.That(() => new string?[] { null }.MarshalToPtr(StringListPackMethod.Concatenated, Marshal.AllocHGlobal, out a, CharSet.Unicode, intSz), Throws.ArgumentException);
		}
		finally
		{
			Marshal.FreeHGlobal(h);
		}
	}

	[Test()]
	public void MarshalToPtr_StrListPack_Test()
	{
		var h = IntPtr.Zero;
		try
		{
			var rs = new[] { "str1", "str2", "str3" };
			h = rs.MarshalToPtr(StringListPackMethod.Packed, Marshal.AllocHGlobal, out var a, CharSet.Unicode, intSz);
			Assert.That(h, Is.Not.EqualTo(IntPtr.Zero));
			var chSz = 2;
			Assert.That(a, Is.EqualTo(chSz * (rs[0].Length + 1) * rs.Length + ((rs.Length + 1) * IntPtr.Size) + intSz));
			var ro = h.ToIEnum<IntPtr>(rs.Length + 1, intSz).ToArray();
			Assert.That(ro.Take(rs.Length), Has.None.EqualTo(IntPtr.Zero));
			Assert.That(ro[rs.Length], Is.EqualTo(IntPtr.Zero));
			for (var i = 0; i < ro.Length - 1; i++)
				Assert.That(StringHelper.GetString(ro[i], CharSet.Unicode), Is.EqualTo(rs[i]));
			Marshal.FreeHGlobal(h);

			h = rs.MarshalToPtr(StringListPackMethod.Packed, Marshal.AllocHGlobal, out a, CharSet.Ansi, intSz);
			Assert.That(h, Is.Not.EqualTo(IntPtr.Zero));
			chSz = 1;
			Assert.That(a, Is.EqualTo(chSz * (rs[0].Length + 1) * rs.Length + ((rs.Length + 1) * IntPtr.Size) + intSz));
			ro = h.ToIEnum<IntPtr>(rs.Length, intSz).ToArray();
			Assert.That(ro, Has.None.EqualTo(IntPtr.Zero));
			for (var i = 0; i < ro.Length; i++)
				Assert.That(StringHelper.GetString(ro[i], CharSet.Ansi), Is.EqualTo(rs[i]));
			Marshal.FreeHGlobal(h);

			h = new string[0].MarshalToPtr(StringListPackMethod.Packed, Marshal.AllocHGlobal, out a, CharSet.Unicode, intSz);
			Assert.That(h, Is.Not.EqualTo(IntPtr.Zero));
			Assert.That(a, Is.EqualTo(intSz + IntPtr.Size));
		}
		finally
		{
			Marshal.FreeHGlobal(h);
		}
	}

	[Test()]
	public void StructureToPtrTest()
	{
		var rect = new RECT(10, 11, 12, 13);
		var ptr = rect.MarshalToPtr(Marshal.AllocCoTaskMem, out var a);
		Assert.That(ptr != IntPtr.Zero);
		Assert.That(Marshal.ReadInt32(ptr, 1 * intSz) == 11);
		Marshal.FreeCoTaskMem(ptr);
	}

	[Test()]
	public void ToArrayTest()
	{
		var rs = new[] { 10, 11, 12, 13, 14 };
		var h = SafeHGlobalHandle.CreateFromList(rs, rs.Length, intSz);
		var ro = ((IntPtr)h).ToArray<int>(4, intSz);
		Assert.That(ro!.Length, Is.EqualTo(4));
		Assert.That(ro[2], Is.EqualTo(rs[2]));

		Assert.That(((IntPtr)h).ToArray<int>(0, intSz), Is.Empty);
		Assert.That(IntPtr.Zero.ToArray<int>(3, intSz), Is.Null);
	}

	[Test()]
	public void ToIEnumTest()
	{
		var rs = new[] { 10, 11, 12, 13, 14 };
		var h = SafeHGlobalHandle.CreateFromList(rs, rs.Length, intSz);
		var ro = ((IntPtr)h).ToIEnum<int>(4, intSz);
		var v = 10;
		foreach (var rv in ro)
			Assert.That(rv, Is.EqualTo(v++));
		Assert.That(v, Is.EqualTo(14));

		Assert.That(((IntPtr)h).ToIEnum<int>(0, intSz), Is.Empty);
		Assert.That(IntPtr.Zero.ToIEnum<int>(0, intSz), Is.Empty);
	}

	[Test()]
	public void ConvertPtrTest()
	{
		Assert.That(new UIntPtr(0x0E924356).ToIntPtr(), Is.EqualTo(new IntPtr(0x0E924356)));
		Assert.That(new IntPtr(0x0E924356).ToUIntPtr(), Is.EqualTo(new UIntPtr(0x0E924356)));
	}

	[Test()]
	public void ToNullableStructureTest()
	{
		Assert.That(IntPtr.Zero.ToNullableStructure<RECT>(), Is.Null);
		var h = SafeHGlobalHandle.CreateFromStructure(new RECT(10, 11, 12, 13));
		Assert.That(((IntPtr)h).ToNullableStructure<RECT>(), Is.Not.Null);
	}

	[Test()]
	public void ToStructureTest()
	{
		var h = SafeHGlobalHandle.CreateFromStructure(new RECT(10, 11, 12, 13));
		Assert.That(((IntPtr)h).ToStructure<RECT>().left == 10);
		h.Dispose();
		Assert.That(() => ((IntPtr)h).ToStructure<RECT>(), Throws.TypeOf<NullReferenceException>());
	}

	[Test()]
	public void ToStructureTest1()
	{
		using var h = SafeHGlobalHandle.CreateFromStructure(new PRECT(10, 11, 12, 13));
		var r = new PRECT(0, 0, 0, 0);
		Assert.That(() => ((IntPtr)h).ToStructure(r), Throws.Nothing);
		Assert.That(r.left, Is.EqualTo(10));
	}

	private abstract class AbsClass
	{
		public abstract int Value { get; }
	}

	[Test]
	public void GetNulledPtrArrayLengthTest()
	{
		IntPtr[] ptrs = new[] { (IntPtr)1, (IntPtr)1, (IntPtr)1, (IntPtr)1, (IntPtr)1, IntPtr.Zero };
		var mp = ptrs.MarshalToPtr(Marshal.AllocCoTaskMem, out var l);
		try
		{
			Assert.AreEqual(l, ptrs.Length * IntPtr.Size);
			Assert.That(mp.GetNulledPtrArrayLength(), Is.EqualTo(ptrs.Length - 1));
			Marshal.WriteIntPtr(mp, IntPtr.Size, IntPtr.Zero);
			Assert.That(mp.GetNulledPtrArrayLength(), Is.EqualTo(1));
			Marshal.WriteIntPtr(mp, IntPtr.Zero);
			Assert.That(mp.GetNulledPtrArrayLength(), Is.EqualTo(0));
			Assert.That(IntPtr.Zero.GetNulledPtrArrayLength(), Is.EqualTo(0));
		}
		finally
		{
			Marshal.FreeCoTaskMem(mp);
		}
	}

	[Test()]
	public void ToStringEnumConcatTest()
	{
		var rs = new[] { "str1", "str2", "str3" };
		using (var sa = SafeHGlobalHandle.CreateFromStringList(rs, StringListPackMethod.Concatenated, CharSet.Ansi, intSz))
		{
			var ptr = sa.DangerousGetHandle();
			Assert.That(ptr, Is.Not.EqualTo(IntPtr.Zero));
			var se = ptr.ToStringEnum(CharSet.Ansi, intSz, sa.Size);
			Assert.That(se, Is.EquivalentTo(rs));
			Assert.That(() => ptr.ToStringEnum(CharSet.Ansi, intSz, sa.Size - 5).ToArray(), Throws.TypeOf<InsufficientMemoryException>());
			Assert.That(() => ptr.ToStringEnum(CharSet.Ansi, intSz, sa.Size - 1).ToArray(), Throws.TypeOf<InsufficientMemoryException>());
		}
		using (var sa = SafeHGlobalHandle.CreateFromStringList(rs, StringListPackMethod.Concatenated, CharSet.Unicode, intSz))
		{
			var ptr = sa.DangerousGetHandle();
			Assert.That(ptr, Is.Not.EqualTo(IntPtr.Zero));
			var se = ptr.ToStringEnum(CharSet.Unicode, intSz, sa.Size);
			Assert.That(se, Is.EquivalentTo(rs));
			Assert.That(() => ptr.ToStringEnum(CharSet.Unicode, intSz, sa.Size - 5).ToArray(), Throws.TypeOf<InsufficientMemoryException>());
			Assert.That(() => ptr.ToStringEnum(CharSet.Unicode, intSz, sa.Size - 1).ToArray(), Throws.TypeOf<InsufficientMemoryException>());
		}
		using (var sa = SafeHGlobalHandle.CreateFromStringList(Enumerable.Empty<string>(), StringListPackMethod.Concatenated, CharSet.Unicode, intSz))
		{
			var ptr = sa.DangerousGetHandle();
			Assert.That(ptr, Is.Not.EqualTo(IntPtr.Zero));
			var se = ptr.ToStringEnum(CharSet.Unicode, intSz, sa.Size);
			Assert.That(se, Is.Empty);
			Assert.That(() => ptr.ToStringEnum(CharSet.Unicode, intSz, intSz).Count(), Throws.TypeOf<InsufficientMemoryException>());
			Assert.That(() => ptr.ToStringEnum(CharSet.Unicode, intSz, sa.Size - 1).Count(), Throws.TypeOf<InsufficientMemoryException>());
		}
		Assert.That(IntPtr.Zero.ToStringEnum(CharSet.Unicode, intSz), Is.Empty);
	}

	[Test()]
	public void ToStringEnumPackTest()
	{
		var rs = new[] { "str1", "str2", null, "", "str3" };
		using (var sa = SafeHGlobalHandle.CreateFromStringList(rs!, StringListPackMethod.Packed, CharSet.Ansi, intSz))
		{
			var ptr = sa.DangerousGetHandle();
			Assert.That(ptr, Is.Not.EqualTo(IntPtr.Zero));
			var se = ptr.ToStringEnum(rs.Length, CharSet.Ansi, intSz);
			Assert.That(se, Is.EquivalentTo(rs));
		}
		using (var sa = SafeHGlobalHandle.CreateFromStringList(rs!, StringListPackMethod.Packed, CharSet.Unicode, intSz))
		{
			var ptr = sa.DangerousGetHandle();
			Assert.That(ptr, Is.Not.EqualTo(IntPtr.Zero));
			var se = ptr.ToStringEnum(rs.Length, CharSet.Unicode, intSz);
			Assert.That(se, Is.EquivalentTo(rs));
		}
		using (var sa = SafeHGlobalHandle.CreateFromStringList(Enumerable.Empty<string>(), StringListPackMethod.Packed, CharSet.Unicode, intSz))
		{
			var ptr = sa.DangerousGetHandle();
			Assert.That(ptr, Is.Not.EqualTo(IntPtr.Zero));
			var se = ptr.ToStringEnum(0, CharSet.Unicode, intSz);
			Assert.That(se, Is.Empty);
		}
		Assert.That(IntPtr.Zero.ToStringEnum(0, CharSet.Unicode, intSz), Is.Empty);
	}

	[TestCase("Some string value")]
	[TestCase("")]
	[TestCase((string?)null)]
	public void ToInsecureStringTest(string? sval)
	{
		var ss = sval?.ToSecureString();
		if (sval != null)
		{
			Assert.That(ss, Is.Not.Null);
			Assert.That(ss!.Length, Is.EqualTo(sval.Length));
			var s = ss.ToInsecureString();
			Assert.That(s, Is.EqualTo(sval));
		}
		else
		{
			Assert.That(ss, Is.Null);
		}
	}

	[Test]
	public void ToInsecureStringTest()
	{
		Assert.That(IntPtr.Zero.ToSecureString(4), Is.Null);
		Assert.That(((System.Security.SecureString?)null)?.ToInsecureString(), Is.Null);
	}

	[TestCase("Some string value")]
	[TestCase("")]
	[TestCase((string?)null)]
	public void ToSecureStringTest(string? sval)
	{
		var ms = new SafeCoTaskMemString(sval);
		var ss = ms.DangerousGetHandle().ToSecureString();
		if (sval != null)
		{
			Assert.That(ss, Is.Not.Null);
			Assert.That(ss!.Length, Is.EqualTo(sval.Length));
			var s = ss.ToInsecureString();
			Assert.That(s, Is.EqualTo(sval));

			if (sval.Length > 1)
			{
				ss = ms.DangerousGetHandle().ToSecureString(1);
				Assert.That(ss, Is.Not.Null);
				Assert.That(ss!.Length, Is.EqualTo(1));
				s = ss.ToInsecureString();
				Assert.That(s, Is.EqualTo(sval.Substring(0, 1)));
			}
		}
		else
		{
			Assert.That(ss, Is.Null);
		}
	}

	[Test]
	public unsafe void AsUnmanagedArrayPointerTest()
	{
		var h = new SafeHGlobalHandle(Marshal.SizeOf(typeof(RECT)) * 2 + intSz);
		var rs = new[] { new RECT(0, 1, 2, 3), new RECT(10, 11, 12, 13) };
		((IntPtr)h).Write(rs, intSz, h.Size);

		RECT* r = h.DangerousGetHandle().AsUnmanagedArrayPointer<RECT>(rs.Length, intSz, h.Size);
		Assert.That(r[1].left, Is.EqualTo(10));
		Assert.That(r[1].top, Is.EqualTo(11));
		Assert.That(r[1].right, Is.EqualTo(12));
		Assert.That(r[1].bottom, Is.EqualTo(13));
	}

	[Test]
	public void WriteObjectTest()
	{
		using var mem = new SafeHGlobalHandle(4096);
		var h = mem.DangerousGetHandle();

		// null
		Assert.That(h.Write((object?)null), Is.EqualTo(0));

		// bytes
		Assert.That(h.Write((object)new byte[] { 1, 2, 4, 5 }), Is.EqualTo(4));

		// marshaled
		//Assert.That(h.Write(), ResultIs.Successful);

		// string
		Assert.That(h.Write((object)"abcde"), Is.EqualTo(12));

		// blitted
		Assert.That(h.Write((object)1234L), Is.EqualTo(8));
		Assert.That(h.Write((object)Guid.NewGuid()), Is.EqualTo(16));
		Assert.That(h.Write((object)PlatformID.Win32NT), Is.EqualTo(4));

		// string enum
		Assert.That(h.Write((object)new[] { "abcde", "abcde" }), Is.EqualTo(26));

		// array
		Assert.That(h.Write((object)new[] { 1234, 1234 }), Is.EqualTo(8));

		// ienum
		Assert.That(h.Write((object)new List<int>() { 1234, 1234 }), Is.EqualTo(8));

		// iserial
		Assert.That(h.Write((object)DateTime.Now), Is.EqualTo(78));
	}
}