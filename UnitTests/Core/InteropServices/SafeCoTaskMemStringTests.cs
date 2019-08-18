using NUnit.Framework;
using Vanara.InteropServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Vanara.InteropServices.Tests
{
	[TestFixture()]
	public class SafeCoTaskMemStringTests
	{
		[Test()]
		public void SafeCoTaskMemStringTest()
		{
			const int sz = 100;
			var cs = new string('x', sz);

			var s = new SafeCoTaskMemString(cs);
			Assert.That(s.Capacity, Is.EqualTo(sz + 1));
			Assert.That((string)s, Is.EqualTo(cs));
			Assert.That((IntPtr)s, Is.Not.EqualTo(IntPtr.Zero));

			s = new SafeCoTaskMemString(cs, System.Runtime.InteropServices.CharSet.Ansi);
			Assert.That(s.Capacity, Is.EqualTo(sz + 1));
			Assert.That((string)s, Is.EqualTo(cs));

			s = new SafeCoTaskMemString((string)null);
			Assert.That(s.Capacity, Is.EqualTo(0));
			Assert.That((string)s, Is.Null);
			Assert.That((IntPtr)s, Is.EqualTo(IntPtr.Zero));
		}

		[Test()]
		public void SafeCoTaskMemStringTest1()
		{
			const int sz = 100;
			var s = new SafeCoTaskMemString(sz);
			Assert.That(s.Capacity, Is.EqualTo(sz));
			Assert.That((string)s, Is.EqualTo(string.Empty));

			s = new SafeCoTaskMemString(sz, System.Runtime.InteropServices.CharSet.Ansi);
			Assert.That(s.Capacity, Is.EqualTo(sz));
			Assert.That((string)s, Is.EqualTo(string.Empty));
		}

		[Test()]
		public void SafeCoTaskMemStringTest2()
		{
			const int sz = 100;
			var ss = new SecureString();
			for (var i = 0; i < sz; i++) ss.AppendChar('x');

			var s = new SafeCoTaskMemString(ss);
			Assert.That(s.Capacity, Is.EqualTo(sz));
			Assert.That((string)s, Is.EqualTo(new string('x', sz)));

			ss = null;
			s = new SafeCoTaskMemString(ss, CharSet.Ansi);
			Assert.That((string)s, Is.Null);
			Assert.That(s.Capacity, Is.Zero);
		}

		[Test()]
		public void ToStringTest()
		{
			const int sz = 100;
			var s = new SafeCoTaskMemString(new string('x', sz));
			Assert.That(s.ToString(), Is.EqualTo(new string('x', sz)));
		}
	}
}