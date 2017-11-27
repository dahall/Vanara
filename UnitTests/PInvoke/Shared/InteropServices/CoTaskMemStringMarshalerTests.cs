using NUnit.Framework;
using Vanara.InteropServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Vanara.InteropServices.Tests
{
	[TestFixture()]
	public class CoTaskMemStringMarshalerTests
	{
		[Test()]
		public void GetInstanceTest()
		{
			var m1 = CoTaskMemStringMarshaler.GetInstance(null) as CoTaskMemStringMarshaler;
			Assert.That(m1, Is.InstanceOf<CoTaskMemStringMarshaler>());
			//Assert.That(m1.CharSet, Is.EqualTo(CharSet.Unicode));

			m1 = CoTaskMemStringMarshaler.GetInstance("Ansi") as CoTaskMemStringMarshaler;
			Assert.That(m1, Is.InstanceOf<CoTaskMemStringMarshaler>());
			//Assert.That(m1.CharSet, Is.EqualTo(CharSet.Ansi));

			m1 = CoTaskMemStringMarshaler.GetInstance("UnknownValue") as CoTaskMemStringMarshaler;
			Assert.That(m1, Is.InstanceOf<CoTaskMemStringMarshaler>());
			//Assert.That(m1.CharSet, Is.EqualTo(CharSet.Unicode));
		}

		[Test()]
		public void CleanUpManagedDataTest()
		{
			Assert.That(() => CoTaskMemStringMarshaler.GetInstance(null).CleanUpManagedData(4), Throws.Nothing);
		}

		[Test()]
		public void GetNativeDataSizeTest()
		{
			Assert.That(CoTaskMemStringMarshaler.GetInstance(null).GetNativeDataSize(), Is.EqualTo(IntPtr.Size));
		}

		[Test()]
		public void MarshalManagedToNativeTest()
		{
			const string s = "Hello";
			var m1 = CoTaskMemStringMarshaler.GetInstance(null);
			var ptr = m1.MarshalManagedToNative(s);
			Assert.That(ptr, Is.Not.EqualTo(IntPtr.Zero));
			Assert.That(m1.MarshalNativeToManaged(ptr), Is.EqualTo(s));
			Assert.That(() => m1.CleanUpNativeData(ptr), Throws.Nothing);
		}
	}
}