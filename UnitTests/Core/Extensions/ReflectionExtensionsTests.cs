using Vanara.Extensions;
using NUnit.Framework;
using System;
using System.Drawing;
using static Vanara.Extensions.ReflectionExtensions;
using System.Collections;
using System.Collections.Generic;

namespace Vanara.Extensions.Tests
{
	[TestFixture()]
	public class ReflectionExtensionsTests
	{
		public class X
		{
			public string Str { get; set; }
		}

		[Test()]
		public void GetPropertyValueTest()
		{
			var dt = DateTime.Today;
			Assert.That(dt.GetPropertyValue("Ticks", 0L), Is.EqualTo(dt.Ticks));
			Assert.That(dt.GetPropertyValue("InternalTicks", 0L), Is.EqualTo(dt.Ticks));
			Assert.That(dt.GetPropertyValue<long?>("Tacks"), Is.Null);
			Assert.That(dt.GetPropertyValue<string>("Ticks"), Is.Null);
			Assert.That(dt.GetPropertyValue<ulong>("Ticks", 0), Is.EqualTo((ulong)0));
			Assert.That(dt.GetPropertyValue<byte>("Ticks"), Is.EqualTo((byte)0));
			var x = new X();
			Assert.That(x.GetPropertyValue<string>("Str", ""), Is.EqualTo(""));
		}

		[TestCase(typeof(string), typeof(char))]
		[TestCase(typeof(IEnumerable), typeof(object))]
		[TestCase(typeof(IEnumerable<Guid>), typeof(Guid))]
		[TestCase(typeof(IEnumerable<string>), typeof(string))]
		[TestCase(typeof(List<string>), typeof(string))]
		[TestCase(typeof(IEnum), typeof(object))]
		[TestCase(typeof(IGenEnum), typeof(int))]
		[TestCase(typeof(DerIGenEnum), typeof(int))]
		[TestCase(typeof(int), null)]
		public void FindElementTypeTest(Type t, Type e)
		{
			Assert.That(t.FindElementType(), Is.EqualTo(e));
		}

		[Test]
		public void FindElementTypeTest2()
		{
			Assert.That("Fred".GetType().FindElementType(), Is.EqualTo(typeof(char)));
			Assert.That(new IEnum().GetType().FindElementType(), Is.EqualTo(typeof(object)));
			Assert.That(new IGenEnum().GetType().FindElementType(), Is.EqualTo(typeof(int)));
			Assert.That(new DerIGenEnum().GetType().FindElementType(), Is.EqualTo(typeof(int)));
			Assert.That(new Guid[2].GetType().FindElementType(), Is.EqualTo(typeof(Guid)));
			Assert.That(new string[2].GetType().FindElementType(), Is.EqualTo(typeof(string)));
			Assert.That(new List<string>().GetType().FindElementType(), Is.EqualTo(typeof(string)));

			Assert.That(3.GetType().FindElementType(), Is.Null);

			var ie = GetEnum();
			Assert.That(ie.GetType().FindElementType(), Is.EqualTo(typeof(object)));
			var ige = GetGenEnum();
			Assert.That(ige.GetType().FindElementType(), Is.EqualTo(typeof(int)));

			IEnumerable GetEnum()
			{
				yield return 1;
				yield return 2;
			}

			IEnumerable<int> GetGenEnum()
			{
				yield return 1;
				yield return 2;
			}
		}

		private class IEnum : IEnumerable
		{
			public IEnumerator GetEnumerator() => throw new NotImplementedException();
		}

		private class IGenEnum : IEnumerable<int>
		{
			public IEnumerator<int> GetEnumerator() => throw new NotImplementedException();
			IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
		}

		private class DerIGenEnum : IGenEnum
		{

		}

		[Test()]
		public void InvokeMethodRetTest()
		{
			var dt = DateTime.Today;
			Assert.That(dt.InvokeMethod<long>("ToBinary"), Is.Not.EqualTo(0));
			Assert.That(dt.InvokeMethod<DateTime>("AddHours", (double)1), Is.EqualTo(dt + TimeSpan.FromHours(1)));
			Assert.That(dt.InvokeMethod<long>("ToBinary", Type.EmptyTypes, null), Is.Not.EqualTo(0));
			Assert.That(dt.InvokeMethod<DateTime>("AddHours", new[] { typeof(double) }, new object[] { 1f }), Is.EqualTo(dt + TimeSpan.FromHours(1)));

			Assert.That(() => dt.InvokeMethod<long>("ToBin"), Throws.Exception);
			Assert.That(() => dt.InvokeMethod<long>("ToBinary", 1), Throws.Exception);
			Assert.That(() => dt.InvokeMethod<DateTime>("ToBinary", 1), Throws.Exception);
			Assert.That(() => dt.InvokeMethod<TimeSpan>("Subtract", new[] {typeof(long)}, new object[] {1}), Throws.ArgumentException);
			Assert.That(() => dt.InvokeMethod<TimeSpan>("Subtract", new[] { typeof(DateTime) }, new object[] { 1 }), Throws.ArgumentException);
			Assert.That(() => dt.InvokeMethod<long>("Subtract", new[] { typeof(DateTime) }, new object[] { DateTime.Now }), Throws.ArgumentException);
		}

		[Test()]
		public void InvokeMethodTest()
		{
			var s = new System.Collections.Specialized.StringCollection();
			s.AddRange(new[] { "A", "B", "C" });
			var sa = new string[3];
			Assert.That(() => s.InvokeMethod("CopyTo", new[] { typeof(string[]), typeof(int) }, new object[] { sa, 0 }), Throws.Nothing);
			Assert.That(() => s.InvokeMethod("CopyTo", sa, 0), Throws.Nothing);
			Assert.That(sa[0] == "A");
			Assert.That(() => s.InvokeMethod("Clear"), Throws.Nothing);
			Assert.That(s.Count == 0);
			s.AddRange(sa);
			Assert.That(() => s.InvokeMethod("Clear", Type.EmptyTypes, null), Throws.Nothing);
			Assert.That(s.Count == 0);
			Assert.That(() => s.InvokeMethod("Clr", Type.EmptyTypes, null), Throws.ArgumentException);
			Assert.That(() => s.InvokeMethod<DateTime>("ToBinary", Type.EmptyTypes, null), Throws.ArgumentException);
		}

		[Test()]
		public void InvokeMethodTest1()
		{
			Assert.That(typeof(Rectangle).InvokeMethod<bool>("Contains", 1, 1), Is.False);
		}

		[Test()]
		public void InvokeMethodTypeTest()
		{
			var dt = typeof(DateTime);
			Assert.That(dt.InvokeMethod<long>(new object[] { 2017, 1, 1 }, "ToBinary"), Is.Not.EqualTo(0));
			Assert.That(dt.InvokeMethod<DateTime>(new object[] { 2017, 1, 1 }, "AddHours", (double)1), Is.EqualTo(new DateTime(2017, 1, 1) + TimeSpan.FromHours(1)));
		}
		[Test()]
		public void InvokeNotOverrideTest()
		{
			var t = new TestDerived();
			var mi = typeof(TestBase).GetMethod("GetValue", Type.EmptyTypes);
			Assert.That(mi.InvokeNotOverride(t), Is.EqualTo(0));
			Assert.That(() => mi.InvokeNotOverride(t, 2), Throws.Exception);
			mi = typeof(TestBase).GetMethod("GetValue", new[] { typeof(int), typeof(int) });
			Assert.That(mi.InvokeNotOverride(t, 1, 2), Is.EqualTo(0));
			mi = typeof(TestBase).GetMethod("GetValue", new[] { typeof(int), typeof(int) });
			Assert.That(() => mi.InvokeNotOverride(t, 'c', 2), Throws.Exception);
		}

		[Test()]
		public void LoadTypeTest()
		{
			Assert.That(() => LoadType("X", "Asm"), Is.Null);
			Assert.That(LoadType("System.Uri", @"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.5.2\System.dll"), Is.Not.Null);
			Assert.That(LoadType("Vanara.Extensions.Tests.ReflectionExtensionsTests", null), Is.Not.Null);
		}
		private class TestBase
		{
			public virtual int GetValue() => 0;
			public virtual int GetValue(int a, int b) => 0;
		}

		private class TestDerived : TestBase
		{
			public override int GetValue() => 1;
			public override int GetValue(int a, int b) => 1;
		}
	}
}