using NUnit.Framework;
using System;
using System.Runtime.InteropServices;
using System.Text;
using Vanara.InteropServices;
using static Vanara.PInvoke.AdvApi32;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests
{
	[TestFixture]
	public class DateTimeApiTests
	{
		private StringBuilder sb = new StringBuilder(4096, 4096);
		private SYSTEMTIME st;

		[OneTimeSetUp]
		public void _Setup()
		{
			GetSystemTime(out st);
		}

		[SetUp]
		public void _TestSetup()
		{
			sb.Clear();
		}

		[Test]
		public void GetDateFormatTest()
		{
			Assert.That(GetDateFormat(LOCALE_USER_DEFAULT, DATE_FORMAT.DATE_LONGDATE, st, null, sb, sb.Capacity), Is.Not.Zero);
			Assert.That(sb.Length, Is.GreaterThan(0));
			TestContext.WriteLine(sb);
		}

		[Test]
		public void GetDateFormatExTest()
		{
			Assert.That(GetDateFormatEx(LOCALE_NAME_USER_DEFAULT, DATE_FORMAT.DATE_LONGDATE, st, null, sb, sb.Capacity), Is.Not.Zero);
			Assert.That(sb.Length, Is.GreaterThan(0));
			TestContext.WriteLine(sb);
		}

		[Test]
		public void GetTimeFormatTest()
		{
			Assert.That(GetTimeFormat(LOCALE_USER_DEFAULT, TIME_FORMAT.LOCALE_NOUSEROVERRIDE, st, null, sb, sb.Capacity), Is.Not.Zero);
			Assert.That(sb.Length, Is.GreaterThan(0));
			TestContext.WriteLine(sb);
		}

		[Test]
		public void GetTimeFormatExTest()
		{
			Assert.That(GetTimeFormatEx(LOCALE_NAME_USER_DEFAULT, TIME_FORMAT.LOCALE_NOUSEROVERRIDE, st, null, sb, sb.Capacity), Is.Not.Zero);
			Assert.That(sb.Length, Is.GreaterThan(0));
			TestContext.WriteLine(sb);
		}
	}
}