using NUnit.Framework;
using System;
using System.Globalization;

namespace Vanara.Extensions.Tests
{
	[TestFixture()]
	public class FileTimeExtensionsTests
	{
		[Test()]
		public void CompareToTest()
		{
			var ft1 = FileTimeExtensions.MakeFILETIME(10000000UL);
			var ft2 = FileTimeExtensions.MakeFILETIME(864000000000UL);
			Assert.That(ft1.CompareTo(ft2), Is.LessThan(0));
			Assert.That(ft1.CompareTo(ft1), Is.EqualTo(0));
			Assert.That(ft2.CompareTo(ft1), Is.GreaterThan(0));
		}

		[Test()]
		public void EqualsTest()
		{
			var ft1 = FileTimeExtensions.MakeFILETIME(10000000UL);
			var ft2 = FileTimeExtensions.MakeFILETIME(864000000000UL);
			Assert.That(ft1.Equals(ft2), Is.False);
			Assert.That(FileTimeExtensions.Equals(ft1, ft2), Is.False);
			Assert.That(ft1.Equals(ft1), Is.True);
			Assert.That(FileTimeExtensions.Equals(ft1, ft1), Is.True);
		}

		[TestCase("1601-01-01T00:00:00.0000000Z", ExpectedResult = 0UL)]
		[TestCase("1601-01-01T00:00:00.0000001Z", ExpectedResult = 1UL)]
		[TestCase("1601-01-01T00:00:01.0000000Z", ExpectedResult = 10000000UL)]
		[TestCase("1601-01-02T00:00:00.0000000Z", ExpectedResult = 864000000000UL)]
		public ulong ToFileTimeStructTest(string dateString)
		{
			var dt = DateTime.ParseExact(dateString, "o", CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal);
			var ft = dt.ToFileTimeStruct();
			return ft.ToUInt64();
		}

		[TestCase("1601-01-02T00:00:00.0000000Z", ExpectedResult = 864000000000UL)]
		[TestCase("1601-01-02T00:00:00.0000001Z", ExpectedResult = 864000000001UL)]
		[TestCase("1601-01-02T00:00:01.0000000Z", ExpectedResult = 864010000000UL)]
		[TestCase("1601-01-03T00:00:00.0000000Z", ExpectedResult = 1728000000000UL)]
		public ulong ToFileTimeStructTestUtc(string dateString)
		{
			var dt = DateTime.ParseExact(dateString, "o", CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal);
			var ft = dt.ToFileTimeStruct();
			//var off = TimeZone.CurrentTimeZone.GetUtcOffset(dt);
			return ft.ToUInt64();// + (ulong)off.Ticks;
		}

		[TestCase("1600-12-31T00:00:00.0000000Z")]
		[TestCase("0001-01-01T00:00:00.0000000Z")]
		public void ToFileTimeStructThrows(string dateString)
		{
			var dt = DateTime.ParseExact(dateString, "o", CultureInfo.InvariantCulture, DateTimeStyles.None);
			Assert.That(() => dt.ToFileTimeStruct(), Throws.TypeOf<ArgumentOutOfRangeException>());
		}

		[TestCase(0UL, ExpectedResult = "1601-01-01T00:00:00.0000000Z")]
		[TestCase(1UL, ExpectedResult = "1601-01-01T00:00:00.0000001Z")]
		[TestCase(10000000UL, ExpectedResult = "1601-01-01T00:00:01.0000000Z")]
		[TestCase(864000000000UL, ExpectedResult = "1601-01-02T00:00:00.0000000Z")]
		public string ToDateTimeTest(ulong value)
		{
			return FileTimeExtensions.MakeFILETIME(value).ToDateTime(DateTimeKind.Utc).ToString("o");
		}

		[Test()]
		public void MakeFILETIMETest()
		{
			var ft = FileTimeExtensions.MakeFILETIME(1);
			Assert.That(ft.dwLowDateTime, Is.EqualTo(1));
		}

		[Test()]
		public void FILETIMEToUInt64Test()
		{
			Assert.That(FileTimeExtensions.MakeFILETIME(0).ToUInt64(), Is.EqualTo(0));
			Assert.That(FileTimeExtensions.MakeFILETIME(1).ToUInt64(), Is.EqualTo(1));
		}

		[Test()]
		public void FILETIMEToStringTest()
		{
			Assert.That(new DateTime(2000, 1, 1, 0, 0, 0, DateTimeKind.Local).ToFileTimeStruct().ToString("M/d/yyyy"), Is.EqualTo("1/1/2000"));
		}
	}
}