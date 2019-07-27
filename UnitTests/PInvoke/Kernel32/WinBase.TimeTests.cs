using NUnit.Framework;
using System;
using Vanara.Extensions;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests
{
	[TestFixture]
	public partial class WinBaseTests_Time
	{
		[Test]
		public void DosDateTimeToFileTimeTest()
		{
			var ft = new DateTime(2019, 10, 29, 13, 51, 24, DateTimeKind.Local).ToFileTimeStruct();
			Assert.That(FileTimeToDosDateTime(ft, out var fatDate, out var fatTime), ResultIs.Successful);
			Assert.That(BitHelper.GetBits(fatDate, 5, 4), Is.EqualTo(10));
			Assert.That(DosDateTimeToFileTime(fatDate, fatTime, out var outFt), ResultIs.Successful);
			Assert.That(outFt.ToUInt64(), Is.EqualTo(ft.ToUInt64()));
		}

		[Test]
		public void GetDynamicTimeZoneInformationEffectiveYearsTest()
		{
			foreach (var tzi in EnumDynamicTimeZoneInformation())
			{
				if (GetDynamicTimeZoneInformationEffectiveYears(tzi, out var year1, out var yearn).Succeeded)
				{
					Assert.That(year1 + yearn, Is.GreaterThan(0));
					tzi.WriteValues();
					(year1, yearn).WriteValues();
					return;
				}
			}
			Assert.Fail();
		}
	}
}