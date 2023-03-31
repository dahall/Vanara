using NUnit.Framework;
using System;

namespace Vanara.PInvoke.Tests;

[TestFixture()]
public class SYSTEMTIMETests
{
	[Test()]
	public void SYSTEMTIMETest()
	{
		var st1 = new SYSTEMTIME();
		Assert.That(st1.wYear, Is.EqualTo(0));
		var st2 = new SYSTEMTIME(DateTime.Today);
		Assert.That(st2.wYear, Is.EqualTo(DateTime.Today.Year));
		var st4 = new SYSTEMTIME(2003, 6, 5, 4, 3, 2, 1);
		Assert.That(st4.wYear == 2003 && st4.wMonth == 6 && st4.wDay == 5 && st4.wHour == 4 && st4.wMinute == 3 && st4.wSecond == 2 && st4.wMilliseconds == 1);
		Assert.That(() => new SYSTEMTIME(1500, 3, 3, 3, 3, 3, 3), Throws.TypeOf<ArgumentOutOfRangeException>());
		Assert.That(() => new SYSTEMTIME(new DateTime(1500, 3, 3, 3, 3, 3, 3)), Throws.TypeOf<ArgumentOutOfRangeException>());
		Assert.That(() => new SYSTEMTIME(2003, 0, 3, 3, 3, 3, 3), Throws.TypeOf<ArgumentOutOfRangeException>());
		Assert.That(() => new SYSTEMTIME(2003, 3, 33, 3, 3, 3, 3), Throws.TypeOf<ArgumentOutOfRangeException>());
		Assert.That(() => new SYSTEMTIME(2003, 3, 3, 33, 3, 3, 3), Throws.TypeOf<ArgumentOutOfRangeException>());
		Assert.That(() => new SYSTEMTIME(2003, 3, 3, 3, 83, 3, 3), Throws.TypeOf<ArgumentOutOfRangeException>());
		Assert.That(() => new SYSTEMTIME(2003, 3, 3, 3, 3, 83, 3), Throws.TypeOf<ArgumentOutOfRangeException>());
		Assert.That(() => new SYSTEMTIME(2003, 3, 3, 3, 3, 3, 1003), Throws.TypeOf<ArgumentOutOfRangeException>());
	}

	[Test()]
	public void CompareTest()
	{
		var st3 = new SYSTEMTIME(DateTime.Today);
		var st4 = new SYSTEMTIME(2003, 6, 5, 4, 3, 2, 1);
		Assert.That(SYSTEMTIME.Compare(st3, st4), Is.GreaterThan(0));
		Assert.That(SYSTEMTIME.Compare(st4, st3), Is.LessThan(0));
		Assert.That(SYSTEMTIME.Compare(st3, st3), Is.EqualTo(0));
	}

	[Test()]
	public void CompareToTest()
	{
		var st3 = new SYSTEMTIME(DateTime.Today);
		var st4 = new SYSTEMTIME(2003, 6, 5, 4, 3, 2, 1);
		Assert.That(st3.CompareTo(st4), Is.GreaterThan(0));
		Assert.That(st4.CompareTo(st3), Is.LessThan(0));
		Assert.That(st3.CompareTo(st3), Is.EqualTo(0));
	}

	[Test()]
	public void OperatorsTest()
	{
		var st1 = new SYSTEMTIME(2003, 6, 5, 4, 3, 2, 1);
		var st2 = SYSTEMTIME.MaxValue;
		var st3 = new SYSTEMTIME(2003, 6, 5, 4, 3, 2, 1);
		Assert.That(st1 == st3);
		Assert.That(st1 == st2, Is.False);
		Assert.That(st1 != st2);
		Assert.That(st1 != st3, Is.False);
		Assert.That(st2 > st1);
		Assert.That(st1 > st2, Is.False);
		Assert.That(st1 < st2);
		Assert.That(st2 < st1, Is.False);
		Assert.That(st1 <= st2);
		Assert.That(st1 <= st3);
		Assert.That(st2 <= st1, Is.False);
		Assert.That(st2 >= st1);
		Assert.That(st1 >= st3);
		Assert.That(st1 >= st2, Is.False);
	}

	[Test()]
	public void EqualsTest()
	{
		var st = new SYSTEMTIME(2007, 6, 5, 4, 3, 2, 1);
		var ste = new SYSTEMTIME(2007, 6, 5, 4, 3, 2, 1);
		var stne = new SYSTEMTIME(2001, 6, 5, 3, 3, 2, 1);

		Assert.That(st.Equals(ste));
		Assert.That(!st.Equals(stne));
		Assert.That(!st.Equals(DateTime.Today));
		Assert.That(!st.Equals("X"));
		Assert.That(!st.Equals(5));
	}

	[Test()]
	public void TicksTest()
	{
		var st = new SYSTEMTIME(2007, 6, 5, 4, 3, 2, 1);
		var dt = new DateTime(2007, 6, 5, 4, 3, 2, 1);
		Assert.That(st.Ticks == dt.Ticks);
	}

	[Test()]
	public void ToDateTimeTest()
	{
		var st3 = SYSTEMTIME.MinValue;
		Assert.That(st3.ToDateTime(DateTimeKind.Local), Is.EqualTo(DateTime.MinValue));
		st3 = SYSTEMTIME.MaxValue;
		Assert.That(st3.ToDateTime(DateTimeKind.Local), Is.EqualTo(DateTime.MaxValue));
	}

	[Test()]
	public void ToStringTest()
	{
		var st3 = new SYSTEMTIME(DateTime.Today);
		Assert.That(st3.ToString(), Is.EqualTo(DateTime.Today.ToString()));
		Assert.That(st3.GetHashCode(), Is.Not.EqualTo(SYSTEMTIME.MinValue.GetHashCode()));
	}
}