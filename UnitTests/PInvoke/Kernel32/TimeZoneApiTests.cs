using NUnit.Framework;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.AdvApi32;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests
{
	[TestFixture]
	public class TimeZoneApiTests
	{
		[Test]
		public void EnumDynamicTimeZoneInformationTest()
		{
			Assert.That(EnumDynamicTimeZoneInformation(), Is.Not.Empty);
			EnumDynamicTimeZoneInformation().ToArray().WriteValues();
		}

		[Test]
		public void FileTimeToSystemTimeTest()
		{
			var dt = DateTime.Today;
			var ft = dt.ToFileTimeStruct();
			Assert.That(FileTimeToSystemTime(ft, out var st), ResultIs.Successful);
			Assert.That(dt.Year, Is.EqualTo(st.wYear));
			Assert.That(dt.Day, Is.EqualTo(st.wDay));
		}

		[Test]
		public void GetSetDynamicTimeZoneInformationTest()
		{
			// Get a random ref
			var dtz = EnumDynamicTimeZoneInformation().First();

			// Get current
			Assert.That(GetDynamicTimeZoneInformation(out var tz), Is.Not.EqualTo(TZID.TIME_ZONE_ID_INVALID));
			Assert.That(tz.StandardName, Is.Not.Null.Or.Empty);

			using (new ElevPriv("SeTimeZonePrivilege"))
			{
				// Set to random
				Assert.That(SetDynamicTimeZoneInformation(dtz), ResultIs.Successful);

				// Restore to current
				Assert.That(SetDynamicTimeZoneInformation(tz), ResultIs.Successful);
			}
		}

		[Test]
		public void GetSetTimeZoneInformationTest()
		{
			Assert.That(GetTimeZoneInformation(out var tziOld), Is.Not.EqualTo(TZID.TIME_ZONE_ID_INVALID));
			Assert.That(tziOld.StandardName, Is.Not.Null.Or.Empty);

			using (new ElevPriv("SeTimeZonePrivilege"))
			{
				// Build new test tz
				var tziNew = new TIME_ZONE_INFORMATION
				{
					Bias = tziOld.Bias + 60,
					StandardName = "Test Standard Zone",
					StandardDate = new SYSTEMTIME(0, 10, 5, 2),
					DaylightName = "Test Daylight Zone",
					DaylightDate = new SYSTEMTIME(0, 4, 1, 2),
					DaylightBias = -60,
				};

				// Set to new
				Assert.That(SetTimeZoneInformation(tziNew), ResultIs.Successful);

				// Restore to current
				Assert.That(SetTimeZoneInformation(tziOld), ResultIs.Successful);
			}
		}

		[Test]
		public void GetTimeZoneInformationForYearTest()
		{
			Assert.That(GetTimeZoneInformationForYear(2016, IntPtr.Zero, out var tz), ResultIs.Successful);
			Assert.That(tz.StandardName, Is.Not.Null.Or.Empty);
		}

		[Test]
		public void SystemTimeToFileTimeTest()
		{
			var dt = new DateTime(2000, 1, 1, 4, 4, 4, 444, DateTimeKind.Utc);
			var st = new SYSTEMTIME(dt, DateTimeKind.Utc);
			Assert.That(st.ToString(DateTimeKind.Utc, null, null), Is.EqualTo(dt.ToString()));
			Assert.That(SystemTimeToFileTime(st, out var ft), ResultIs.Successful);
			Assert.That(FileTimeExtensions.Equals(ft, dt.ToFileTimeStruct()));
		}

		[Test]
		public void SystemTimeToTzSpecificLocalTimeTest()
		{
			var udt = DateTime.UtcNow.AddHours(100);
			var ut = new SYSTEMTIME(udt, DateTimeKind.Utc);
			Assert.That(SystemTimeToTzSpecificLocalTime(default, ut, out var lt), ResultIs.Successful);
			Assert.That(lt.wHour, Is.EqualTo(udt.ToLocalTime().Hour));

			Assert.That(TzSpecificLocalTimeToSystemTime(default, lt, out var nut), ResultIs.Successful);
			Assert.That(nut, Is.EqualTo(ut));
		}

		[Test]
		public void SystemTimeToTzSpecificLocalTimeExTest()
		{
			// Get a random ref
			var dtz = EnumDynamicTimeZoneInformation().First();

			var udt = DateTime.UtcNow.AddHours(100);
			var ut = new SYSTEMTIME(udt, DateTimeKind.Utc);
			Assert.That(SystemTimeToTzSpecificLocalTimeEx(dtz, ut, out var lt), ResultIs.Successful);
			Assert.That(lt.wYear, Is.EqualTo(udt.ToLocalTime().Year));

			Assert.That(TzSpecificLocalTimeToSystemTimeEx(dtz, lt, out var nut), ResultIs.Successful);
			Assert.That(nut, Is.EqualTo(ut));
		}
	}
}