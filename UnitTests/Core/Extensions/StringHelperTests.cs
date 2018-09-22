using NUnit.Framework;
using System;
using System.Runtime.InteropServices;
using System.Security;

namespace Vanara.Extensions.Tests
{
	[TestFixture()]
	public class StringHelperTests
	{
		[Test()]
		public void AllocCharsTest()
		{
			var sptr = StringHelper.AllocChars(10, CharSet.Ansi);
			Assert.That(sptr, Is.Not.EqualTo(IntPtr.Zero));
			StringHelper.FreeString(sptr, CharSet.Ansi);
			sptr = StringHelper.AllocChars(10, CharSet.Unicode);
			Assert.That(sptr, Is.Not.EqualTo(IntPtr.Zero));
			StringHelper.FreeString(sptr, CharSet.Unicode);
			Assert.That(StringHelper.AllocChars(0), Is.EqualTo(IntPtr.Zero));
		}

		[Test()]
		public void AllocSecureStringTest()
		{
			var sptr = StringHelper.AllocSecureString(new SecureString(), CharSet.Ansi);
			Assert.That(sptr, Is.Not.EqualTo(IntPtr.Zero));
			StringHelper.FreeString(sptr, CharSet.Ansi);
			sptr = StringHelper.AllocSecureString(new SecureString(), CharSet.Unicode);
			Assert.That(sptr, Is.Not.EqualTo(IntPtr.Zero));
			StringHelper.FreeString(sptr, CharSet.Unicode);
		}

		[Test()]
		public void AllocStringTest()
		{
			var sptr = StringHelper.AllocString("X", CharSet.Ansi);
			Assert.That(sptr, Is.Not.EqualTo(IntPtr.Zero));
			Assert.That(StringHelper.GetString(sptr, CharSet.Ansi), Is.EqualTo("X"));
			StringHelper.RefreshString(ref sptr, out var l, "ZZZ", CharSet.Ansi);
			Assert.That(l, Is.EqualTo(4));
			Assert.That(StringHelper.GetString(sptr, CharSet.Ansi), Is.EqualTo("ZZZ"));
			StringHelper.FreeString(sptr, CharSet.Ansi);

			sptr = StringHelper.AllocString("Y", CharSet.Unicode);
			Assert.That(sptr, Is.Not.EqualTo(IntPtr.Zero));
			Assert.That(StringHelper.GetString(sptr, CharSet.Unicode), Is.EqualTo("Y"));
			StringHelper.RefreshString(ref sptr, out l, "ZZZZ", CharSet.Unicode);
			Assert.That(l, Is.EqualTo(5));
			Assert.That(StringHelper.GetString(sptr, CharSet.Unicode), Is.EqualTo("ZZZZ"));
			StringHelper.RefreshString(ref sptr, out l, null, CharSet.Unicode);
			Assert.That(l, Is.EqualTo(0));
			Assert.That(StringHelper.GetString(sptr, CharSet.Unicode), Is.Null);
			StringHelper.FreeString(sptr, CharSet.Unicode);
		}

		[TestCase("BOO", CharSet.Ansi, 4)]
		[TestCase("BOO", CharSet.Unicode, 8)]
		[TestCase("", CharSet.Ansi, 1)]
		[TestCase("", CharSet.Unicode, 2)]
		public void GetBytesNullTermTest(string val, CharSet cs, int len)
		{
			var bytes = val.GetBytes(true, cs);
			Assert.That(bytes.Length, Is.EqualTo(len));
		}

		[TestCase(CharSet.Ansi, 1)]
		[TestCase(CharSet.Unicode, 2)]
		public void GetCharSizeTest(CharSet cs, int len)
		{
			Assert.That(StringHelper.GetCharSize(cs), Is.EqualTo(len));
		}

		[TestCase("hello", true, CharSet.Ansi, 6)]
		[TestCase("hello", false, CharSet.Ansi, 5)]
		[TestCase("hello", true, CharSet.Unicode, 12)]
		[TestCase("hello", false, CharSet.Unicode, 10)]
		[TestCase("", true, CharSet.Ansi, 1)]
		[TestCase("", false, CharSet.Ansi, 0)]
		[TestCase("", true, CharSet.Unicode, 2)]
		[TestCase("", false, CharSet.Unicode, 0)]
		[TestCase(null, true, CharSet.Ansi, 0)]
		[TestCase(null, false, CharSet.Ansi, 0)]
		[TestCase(null, true, CharSet.Unicode, 0)]
		[TestCase(null, false, CharSet.Unicode, 0)]
		public void GetByteCountTest(string value, bool nullTerm, CharSet cs, int ret)
		{
			Assert.That(StringHelper.GetByteCount(value, nullTerm, cs), Is.EqualTo(ret));
		}
	}
}