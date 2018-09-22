using NUnit.Framework;
using System;
using System.Runtime.InteropServices;
using Vanara.InteropServices;
using Vanara.PInvoke;

namespace Vanara.Extensions.Tests
{
	[TestFixture()]
	public class InteropExtensionsTests
	{
		private readonly int i = Marshal.SizeOf<int>();

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
			var h = new SafeHGlobalHandle(Marshal.SizeOf<RECT>() * 2 + i);
			var rs = new[] { new RECT(), new RECT(10, 11, 12, 13) };
			rs.MarshalToPtr((IntPtr)h, i);
			Assert.That(Marshal.ReadInt32((IntPtr)h, 4 * i) == 0);
			Assert.That(Marshal.ReadInt32((IntPtr)h, 5 * i) == 10);
			Assert.That(Marshal.ReadInt32((IntPtr)h, 7 * i) == 12);
			var ro = ((IntPtr)h).ToArray<RECT>(2, i);
			Assert.That(ro.Length == 2);
			Assert.That(ro[0].left == 0);
			Assert.That(ro[1].right == 12);
		}

		[Test()]
		public void MarshalToPtrTest1()
		{
			var h = IntPtr.Zero;
			try
			{
				var rs = new[] { new RECT(), new RECT(10, 11, 12, 13) };
				h = rs.MarshalToPtr(Marshal.AllocHGlobal, out var a, i);
				Assert.That(h, Is.Not.EqualTo(IntPtr.Zero));
				Assert.That(a, Is.EqualTo(Marshal.SizeOf(typeof(RECT)) * rs.Length + i));
				Assert.That(Marshal.ReadInt32(h, 4 * i) == 0);
				Assert.That(Marshal.ReadInt32(h, 5 * i) == 10);
				Assert.That(Marshal.ReadInt32(h, 7 * i) == 12);
				var ro = h.ToArray<RECT>(rs.Length, i);
				Assert.That(ro.Length == 2);
				Assert.That(ro[0].left == 0);
				Assert.That(ro[1].right == 12);
				Marshal.FreeHGlobal(h);

				h = new RECT[0].MarshalToPtr(Marshal.AllocHGlobal, out a, i);
				Assert.That(h, Is.Not.EqualTo(IntPtr.Zero));
				Assert.That(a, Is.EqualTo(i));

				Assert.That(() => new DateTime[1].MarshalToPtr(Marshal.AllocHGlobal, out a, i), Throws.Exception);
			}
			finally
			{
				Marshal.FreeHGlobal(h);
			}
		}

		[Test()]
		public void MarshalToPtrTest2()
		{
			var h = IntPtr.Zero;
			try
			{
				var rs = new[] { "str1", "str2", "str3" };
				h = rs.MarshalToPtr(StringListPackMethod.Concatenated, Marshal.AllocHGlobal, out var a, CharSet.Unicode, i);
				Assert.That(h, Is.Not.EqualTo(IntPtr.Zero));
				var chSz = 2;
				Assert.That(a, Is.EqualTo(chSz * (rs[0].Length + 1) * rs.Length + chSz + i));
				var ro = h.ToArray<byte>(a - i, i);
				var chars = System.Text.Encoding.Unicode.GetChars(ro);
				Assert.That(chars.Length, Is.EqualTo((a - i) / chSz));
				Assert.That(chars[0], Is.EqualTo('s'));
				Assert.That(chars[4], Is.EqualTo('\0'));
				Assert.That(chars[chars.Length - 2], Is.EqualTo('\0'));
				Assert.That(chars[chars.Length - 1], Is.EqualTo('\0'));
				Marshal.FreeHGlobal(h);

				h = rs.MarshalToPtr(StringListPackMethod.Concatenated, Marshal.AllocHGlobal, out a, CharSet.Ansi, i);
				Assert.That(h, Is.Not.EqualTo(IntPtr.Zero));
				chSz = 1;
				Assert.That(a, Is.EqualTo(chSz * (rs[0].Length + 1) * rs.Length + chSz + i));
				ro = h.ToArray<byte>(a - i, i);
				chars = System.Text.Encoding.ASCII.GetChars(ro);
				Assert.That(chars.Length, Is.EqualTo((a - i) / chSz));
				Assert.That(chars[0], Is.EqualTo('s'));
				Assert.That(chars[4], Is.EqualTo('\0'));
				Assert.That(chars[chars.Length - 2], Is.EqualTo('\0'));
				Assert.That(chars[chars.Length - 1], Is.EqualTo('\0'));
				Marshal.FreeHGlobal(h);

				h = new string[0].MarshalToPtr(StringListPackMethod.Concatenated, Marshal.AllocHGlobal, out a, CharSet.Unicode, i);
				Assert.That(h, Is.Not.EqualTo(IntPtr.Zero));
				Assert.That(a, Is.EqualTo(i + 2));

				Assert.That(() => new[] { "" }.MarshalToPtr(StringListPackMethod.Concatenated, Marshal.AllocHGlobal, out a, CharSet.Unicode, i), Throws.ArgumentException);
				Assert.That(() => new string[] { null }.MarshalToPtr(StringListPackMethod.Concatenated, Marshal.AllocHGlobal, out a, CharSet.Unicode, i), Throws.ArgumentException);
			}
			finally
			{
				Marshal.FreeHGlobal(h);
			}
		}

		[Test()]
		public void MarshalToPtrTest3()
		{
			var h = IntPtr.Zero;
			try
			{
				var rs = new[] { "str1", "str2", "str3" };
				h = rs.MarshalToPtr(StringListPackMethod.Packed, Marshal.AllocHGlobal, out var a, CharSet.Unicode, i);
				Assert.That(h, Is.Not.EqualTo(IntPtr.Zero));
				var chSz = 2;
				Assert.That(a, Is.EqualTo(chSz * (rs[0].Length + 1) * rs.Length + ((rs.Length + 1) * IntPtr.Size) + i));
				var ro = h.ToArray<IntPtr>(rs.Length, i);
				Assert.That(ro, Has.None.EqualTo(IntPtr.Zero));
				for (var i = 0; i < ro.Length; i++)
					Assert.That(StringHelper.GetString(ro[i], CharSet.Unicode), Is.EqualTo(rs[i]));
				Marshal.FreeHGlobal(h);

				h = rs.MarshalToPtr(StringListPackMethod.Packed, Marshal.AllocHGlobal, out a, CharSet.Ansi, i);
				Assert.That(h, Is.Not.EqualTo(IntPtr.Zero));
				chSz = 1;
				Assert.That(a, Is.EqualTo(chSz * (rs[0].Length + 1) * rs.Length + ((rs.Length + 1) * IntPtr.Size) + i));
				ro = h.ToArray<IntPtr>(rs.Length, i);
				Assert.That(ro, Has.None.EqualTo(IntPtr.Zero));
				for (var i = 0; i < ro.Length; i++)
					Assert.That(StringHelper.GetString(ro[i], CharSet.Ansi), Is.EqualTo(rs[i]));
				Marshal.FreeHGlobal(h);

				h = new string[0].MarshalToPtr(StringListPackMethod.Packed, Marshal.AllocHGlobal, out a, CharSet.Unicode, i);
				Assert.That(h, Is.Not.EqualTo(IntPtr.Zero));
				Assert.That(a, Is.EqualTo(i + IntPtr.Size));
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
			var ptr = rect.StructureToPtr(Marshal.AllocCoTaskMem, out var a);
			Assert.That(ptr != IntPtr.Zero);
			Assert.That(Marshal.ReadInt32(ptr, 1 * i) == 11);
			Marshal.FreeCoTaskMem(ptr);
		}

		[Test()]
		public void ToArrayTest()
		{
			var rs = new[] { 10, 11, 12, 13, 14 };
			var h = SafeHGlobalHandle.CreateFromList(rs, rs.Length, i);
			var ro = ((IntPtr)h).ToArray<int>(4, i);
			Assert.That(ro.Length, Is.EqualTo(4));
			Assert.That(ro[2], Is.EqualTo(rs[2]));

			Assert.That(((IntPtr)h).ToArray<int>(0, i), Is.Empty);
			Assert.That(IntPtr.Zero.ToArray<int>(3, i), Is.Null);
		}

		[Test()]
		public void ToIEnumTest()
		{
			var rs = new[] { 10, 11, 12, 13, 14 };
			var h = SafeHGlobalHandle.CreateFromList(rs, rs.Length, i);
			var ro = ((IntPtr)h).ToIEnum<int>(4, i);
			var v = 10;
			foreach (var rv in ro)
				Assert.That(rv, Is.EqualTo(v++));
			Assert.That(v, Is.EqualTo(14));

			Assert.That(((IntPtr)h).ToIEnum<int>(0, i), Is.Empty);
			Assert.That(IntPtr.Zero.ToIEnum<int>(3, i), Is.Empty);
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
			var h = SafeHGlobalHandle.CreateFromStructure(new PRECT(10, 11, 12, 13));
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
			var ptrs = new[] { (IntPtr)1, (IntPtr)1, (IntPtr)1, (IntPtr)1, (IntPtr)1, IntPtr.Zero };
			var mp = Marshal.AllocCoTaskMem(IntPtr.Size * ptrs.Length);
			ptrs.MarshalToPtr(mp);
			Assert.That(mp.GetNulledPtrArrayLength(), Is.EqualTo(ptrs.Length - 1));
			Marshal.WriteIntPtr(mp, IntPtr.Size, IntPtr.Zero);
			Assert.That(mp.GetNulledPtrArrayLength(), Is.EqualTo(1));
			Marshal.WriteIntPtr(mp, IntPtr.Zero);
			Assert.That(mp.GetNulledPtrArrayLength(), Is.EqualTo(0));
			Assert.That(IntPtr.Zero.GetNulledPtrArrayLength(), Is.EqualTo(0));
			Marshal.FreeCoTaskMem(mp);
		}

		[Test()]
		public void ToStringEnumTest()
		{
			var rs = new[] { "str1", "str2", "str3" };
			using (var sa = SafeHGlobalHandle.CreateFromStringList(rs, StringListPackMethod.Concatenated, CharSet.Ansi, i))
			{
				var ptr = sa.DangerousGetHandle();
				Assert.That(ptr, Is.Not.EqualTo(IntPtr.Zero));
				var se = ptr.ToStringEnum(CharSet.Ansi, i);
				Assert.That(se, Is.EquivalentTo(rs));
			}
			using (var sa = SafeHGlobalHandle.CreateFromStringList(rs, StringListPackMethod.Concatenated, CharSet.Unicode, i))
			{
				var ptr = sa.DangerousGetHandle();
				Assert.That(ptr, Is.Not.EqualTo(IntPtr.Zero));
				var se = ptr.ToStringEnum(CharSet.Unicode, i);
				Assert.That(se, Is.EquivalentTo(rs));
			}
			using (var sa = SafeHGlobalHandle.CreateFromStringList(null, StringListPackMethod.Concatenated, CharSet.Unicode, i))
			{
				var ptr = sa.DangerousGetHandle();
				Assert.That(ptr, Is.Not.EqualTo(IntPtr.Zero));
				var se = ptr.ToStringEnum(CharSet.Unicode, i);
				Assert.That(se, Is.Empty);
			}
			Assert.That(IntPtr.Zero.ToStringEnum(CharSet.Unicode, i), Is.Empty);
		}

		[Test()]
		public void ToStringEnumTest1()
		{
			var rs = new[] { "str1", "str2", null, "", "str3" };
			using (var sa = SafeHGlobalHandle.CreateFromStringList(rs, StringListPackMethod.Packed, CharSet.Ansi, i))
			{
				var ptr = sa.DangerousGetHandle();
				Assert.That(ptr, Is.Not.EqualTo(IntPtr.Zero));
				var se = ptr.ToStringEnum(rs.Length, CharSet.Ansi, i);
				Assert.That(se, Is.EquivalentTo(rs));
			}
			using (var sa = SafeHGlobalHandle.CreateFromStringList(rs, StringListPackMethod.Packed, CharSet.Unicode, i))
			{
				var ptr = sa.DangerousGetHandle();
				Assert.That(ptr, Is.Not.EqualTo(IntPtr.Zero));
				var se = ptr.ToStringEnum(rs.Length, CharSet.Unicode, i);
				Assert.That(se, Is.EquivalentTo(rs));
			}
			using (var sa = SafeHGlobalHandle.CreateFromStringList(null, StringListPackMethod.Packed, CharSet.Unicode, i))
			{
				var ptr = sa.DangerousGetHandle();
				Assert.That(ptr, Is.Not.EqualTo(IntPtr.Zero));
				var se = ptr.ToStringEnum(0, CharSet.Unicode, i);
				Assert.That(se, Is.Empty);
			}
			Assert.That(IntPtr.Zero.ToStringEnum(0, CharSet.Unicode, i), Is.Empty);
		}

		[TestCase("Some string value")]
		[TestCase("")]
		[TestCase((string)null)]
		public void ToInsecureStringTest(string sval)
		{
			var ss = sval.ToSecureString();
			if (sval != null)
			{
				Assert.That(ss, Is.Not.Null);
				Assert.That(ss.Length, Is.EqualTo(sval.Length));
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
			Assert.That(((System.Security.SecureString)null).ToInsecureString(), Is.Null);
		}

		[TestCase("Some string value")]
		[TestCase("")]
		[TestCase((string)null)]
		public void ToSecureStringTest(string sval)
		{
			var ms = new SafeCoTaskMemString(sval);
			var ss = ms.DangerousGetHandle().ToSecureString();
			if (sval != null)
			{
				Assert.That(ss, Is.Not.Null);
				Assert.That(ss.Length, Is.EqualTo(sval.Length));
				var s = ss.ToInsecureString();
				Assert.That(s, Is.EqualTo(sval));

				if (sval.Length > 1)
				{
					ss = ms.DangerousGetHandle().ToSecureString(1);
					Assert.That(ss, Is.Not.Null);
					Assert.That(ss.Length, Is.EqualTo(1));
					s = ss.ToInsecureString();
					Assert.That(s, Is.EqualTo(sval.Substring(0, 1)));
				}
			}
			else
			{
				Assert.That(ss, Is.Null);
			}
		}
	}
}