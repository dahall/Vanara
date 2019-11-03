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
		public void ConvertTest()
		{
			var array = new[] { long.MinValue, 0L, long.MaxValue };
			var ts = new TestStruct { iVal = array.Length, array = array };

			using var mem = new SafeAnysizeStruct<TestStruct>(ts);
			Assert.That((int)mem.Size, Is.EqualTo(32));
			Assert.That(mem.Value.iVal, Is.EqualTo(3));
			Assert.That(mem.Value.array, Is.EquivalentTo(array));

			var tsout = new SafeAnysizeStruct<TestStruct>(mem, mem.Size, nameof(TestStruct.iVal));
			Assert.That(tsout.Value.iVal, Is.EqualTo(3));
			Assert.That(((TestStruct)tsout).array, Is.EquivalentTo(array));
		}
	}
}