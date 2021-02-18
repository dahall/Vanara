using NUnit.Framework;
using Vanara.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using Vanara.PInvoke;
using System.ComponentModel;
using System.Runtime.Serialization;
using static Vanara.PInvoke.FunctionHelper;

namespace Vanara.InteropServices.Tests
{
	[TestFixture()]
	public class AnysizeStructTests
	{
		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
		public struct TestStrStructU
		{
			public int iVal;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1)]
			public string array;
		}

		[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
		public struct TestStrStructA
		{
			public int iVal;
			[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1)]
			public string array;
		}

		[StructLayout(LayoutKind.Sequential)]
		public struct TestStruct
		{
			public int iVal;
			public ushort uVal;
			private ushort hVal;
			[MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
			public long[] array;
		}

		[Test]
		public void StructNamedFieldTest()
		{
			var array = new[] { long.MinValue, 1L, long.MaxValue };
			var ts = new TestStruct { iVal = array.Length, array = array };

			using var mem = new SafeAnysizeStruct<TestStruct>(ts);
			Assert.That((int)mem.Size, Is.EqualTo(32));
			Assert.That(mem.Value.iVal, Is.EqualTo(3));
			Assert.That(mem.Value.array, Is.EquivalentTo(array));

			var tsout = new SafeAnysizeStruct<TestStruct>(mem, mem.Size, nameof(TestStruct.iVal));
			Assert.That(tsout.Value.iVal, Is.EqualTo(3));
			Assert.That(((TestStruct)tsout).array, Is.EquivalentTo(array));
		}

		[Test]
		public void StructAssumedFieldTest()
		{
			var array = new[] { long.MinValue, 1L, long.MaxValue };
			var ts = new TestStruct { iVal = array.Length, array = array };

			using var mem = new SafeAnysizeStruct<TestStruct>(ts);
			Assert.That((int)mem.Size, Is.EqualTo(32));
			Assert.That(mem.Value.iVal, Is.EqualTo(3));
			Assert.That(mem.Value.array, Is.EquivalentTo(array));

			var tsout = new SafeAnysizeStruct<TestStruct>(mem, mem.Size, null);
			Assert.That(tsout.Value.iVal, Is.EqualTo(3));
			Assert.That(((TestStruct)tsout).array, Is.EquivalentTo(array));
		}

		[Test]
		public void StructNoFieldTest()
		{
			var array = new[] { long.MinValue, 1L, long.MaxValue };
			var ts = new TestStruct { iVal = array.Length, array = array };

			using var mem = new SafeAnysizeStruct<TestStruct>(ts);
			Assert.That((int)mem.Size, Is.EqualTo(32));
			Assert.That(mem.Value.iVal, Is.EqualTo(3));
			Assert.That(mem.Value.array, Is.EquivalentTo(array));

			var tsout = new SafeAnysizeStruct<TestStruct>(mem, mem.Size, "*");
			Assert.That(tsout.Value.iVal, Is.EqualTo(3));
			Assert.That(((TestStruct)tsout).array, Is.EquivalentTo(array));
		}

		[Test]
		public void StringNamedFieldTest()
		{
			var ts = new TestStrStructU { iVal = str.Length + 1, array = str };
			var strOffset = Marshal.OffsetOf<TestStrStructU>(nameof(TestStrStructU.array)).ToInt64();

			IVanaraMarshaler m = new AnySizeStringMarshaler<TestStrStructU>(nameof(TestStrStructU.iVal));
			using (var mem = m.MarshalManagedToNative(ts))
			{
				Assert.That((long)mem.Size, Is.GreaterThanOrEqualTo(strOffset + (str.Length + 1) * StringHelper.GetCharSize(CharSet.Unicode)));
				Assert.That(StringHelper.GetString(((IntPtr)mem).Offset(strOffset), CharSet.Unicode), Is.EqualTo(str));

				var tsout = (TestStrStructU)m.MarshalNativeToManaged(mem, mem.Size);
				Assert.That(tsout.iVal, Is.EqualTo(ts.iVal));
				Assert.That(tsout.array, Is.EquivalentTo(str));
			}

			m = new AnySizeStringMarshaler<TestStrStructU>(nameof(TestStrStructU.iVal) + ":br");
			using (var mem = m.MarshalManagedToNative(ts))
			{
				var newStr = str.Substring(0, ts.iVal / StringHelper.GetCharSize(CharSet.Unicode));
				Assert.That((long)mem.Size, Is.GreaterThanOrEqualTo(strOffset + ts.iVal));
				Assert.That(StringHelper.GetString(((IntPtr)mem).Offset(strOffset), CharSet.Unicode), Is.EqualTo(newStr));

				var tsout = (TestStrStructU)m.MarshalNativeToManaged(mem, mem.Size);
				Assert.That(tsout.iVal, Is.EqualTo(ts.iVal));
				Assert.That(tsout.array, Is.EquivalentTo(newStr));
			}
		}

		[Test]
		public void StringNamedFieldATest()
		{
			var ts = new TestStrStructA { iVal = str.Length + 1, array = str };
			var strOffset = Marshal.OffsetOf<TestStrStructA>(nameof(TestStrStructA.array)).ToInt64();

			IVanaraMarshaler m = new AnySizeStringMarshaler<TestStrStructA>(nameof(TestStrStructA.iVal));
			using (var mem = m.MarshalManagedToNative(ts))
			{
				Assert.That((long)mem.Size, Is.GreaterThanOrEqualTo(strOffset + (str.Length + 1)));
				Assert.That(StringHelper.GetString(((IntPtr)mem).Offset(strOffset), CharSet.Ansi), Is.EqualTo(str));

				var tsout = (TestStrStructA)m.MarshalNativeToManaged(mem, mem.Size);
				Assert.That(tsout.iVal, Is.EqualTo(ts.iVal));
				Assert.That(tsout.array, Is.EquivalentTo(str));
			}

			m = new AnySizeStringMarshaler<TestStrStructA>(nameof(TestStrStructA.iVal) + ":br");
			using (var mem = m.MarshalManagedToNative(ts))
			{
				var newStr = str.Substring(0, Math.Min(ts.iVal, str.Length));
				Assert.That((long)mem.Size, Is.GreaterThanOrEqualTo(strOffset + ts.iVal));
				Assert.That(StringHelper.GetString(((IntPtr)mem).Offset(strOffset), CharSet.Ansi), Is.EqualTo(newStr));

				var tsout = (TestStrStructA)m.MarshalNativeToManaged(mem, mem.Size);
				Assert.That(tsout.iVal, Is.EqualTo(ts.iVal));
				Assert.That(tsout.array, Is.EquivalentTo(newStr));
			}
		}

		const string str = "l;kajsdfl;kajsdl;fkj";

		[Test]
		public void StringNoFieldTest()
		{
			var ts = new TestStrStructU { iVal = str.Length + 1, array = str };
			var strOffset = Marshal.OffsetOf<TestStrStructU>(nameof(TestStrStructU.array)).ToInt64();

			IVanaraMarshaler m = new AnySizeStringMarshaler<TestStrStructU>("*");
			using var mem = m.MarshalManagedToNative(ts);

			Assert.That((long)mem.Size, Is.GreaterThanOrEqualTo(strOffset + (str.Length + 1) * StringHelper.GetCharSize(CharSet.Unicode)));
			Assert.That(StringHelper.GetString(((IntPtr)mem).Offset(strOffset), CharSet.Unicode), Is.EqualTo(str));

			var tsout = (TestStrStructU)m.MarshalNativeToManaged(mem, mem.Size);
			Assert.That(tsout.iVal, Is.EqualTo(ts.iVal));
			Assert.That(tsout.array, Is.EquivalentTo(str));
		}
	}
}