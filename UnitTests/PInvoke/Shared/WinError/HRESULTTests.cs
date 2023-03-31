using NUnit.Framework;
using NUnit.Framework.Constraints;
using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Vanara.PInvoke.Tests;

[TestFixture()]
public class HRESULTTests
{
	[TestCase(HRESULT.E_ACCESSDENIED, 0x80070005, ExpectedResult = 0)]
	[TestCase(HRESULT.E_ACCESSDENIED, 0, ExpectedResult = -1)]
	[TestCase(HRESULT.E_ACCESSDENIED, 5U, ExpectedResult = -1)]
	[TestCase(HRESULT.E_ACCESSDENIED, HRESULT.E_INVALIDARG, ExpectedResult = -1)]
	[TestCase(HRESULT.E_INVALIDARG, HRESULT.E_ACCESSDENIED, ExpectedResult = 1)]
	[TestCase(HRESULT.S_OK, HRESULT.E_ACCESSDENIED, ExpectedResult = 1)]
	public int CompareToTest(int c, object obj) => new HRESULT(c).CompareTo(obj);

	[TestCase(HRESULT.E_ACCESSDENIED, HRESULT.E_INVALIDARG, ExpectedResult = -1)]
	[TestCase(HRESULT.E_INVALIDARG, HRESULT.E_ACCESSDENIED, ExpectedResult = 1)]
	[TestCase(HRESULT.E_INVALIDARG, HRESULT.E_INVALIDARG, ExpectedResult = 0)]
	public int CompareToTest1(int c1, int c2) => new HRESULT(c1).CompareTo(new HRESULT(c2));

	[Test]
	public void ComparisonTest()
	{
		HRESULT hr = HRESULT.E_ACCESSDENIED;
		Assert.That(() => hr.CompareTo(null), Throws.ArgumentException);
		Assert.That(() => hr.CompareTo("A"), Throws.Exception);
		Assert.That(() => hr.CompareTo(DateTime.Today), Throws.Exception);
	}

	[TestCase(HRESULT.E_ACCESSDENIED, 0x80070005, ExpectedResult = true)]
	[TestCase(HRESULT.E_ACCESSDENIED, 0, ExpectedResult = false)]
	[TestCase(HRESULT.E_ACCESSDENIED, 5U, ExpectedResult = false)]
	[TestCase(HRESULT.E_ACCESSDENIED, HRESULT.E_INVALIDARG, ExpectedResult = false)]
	[TestCase(HRESULT.E_INVALIDARG, HRESULT.E_ACCESSDENIED, ExpectedResult = false)]
	[TestCase(HRESULT.E_ACCESSDENIED, "A", ExpectedResult = false)]
	[TestCase(HRESULT.E_ACCESSDENIED, int.MaxValue, ExpectedResult = false)]
	public bool EqualsTest(int c, object obj) => new HRESULT(c).Equals(obj);

	[TestCase(HRESULT.E_ACCESSDENIED, HRESULT.E_INVALIDARG, ExpectedResult = false)]
	[TestCase(HRESULT.E_INVALIDARG, HRESULT.E_ACCESSDENIED, ExpectedResult = false)]
	[TestCase(HRESULT.E_INVALIDARG, HRESULT.E_INVALIDARG, ExpectedResult = true)]
	public bool EqualsTest1(int c1, int c2) => new HRESULT(c1).Equals(new HRESULT(c2));

	[Test]
	public void GetExceptionTest()
	{
		Assert.That(new HRESULT().GetException(), Is.Null);
		Assert.That(new HRESULT(HRESULT.E_ACCESSDENIED).GetException(), Is.TypeOf<UnauthorizedAccessException>());
		Assert.That(new HRESULT(HRESULT.CO_E_ATTEMPT_TO_CREATE_OUTSIDE_CLIENT_CONTEXT).GetException(), Is.TypeOf<COMException>());
		Assert.That(new HRESULT(HRESULT.E_INVALIDARG).GetException(), Is.TypeOf<ArgumentException>());
		Assert.That(new HRESULT(HRESULT.E_INVALIDARG).GetException("Bad"), Has.Message.EqualTo("Bad"));
	}

	[Test()]
	public void HRESULTTest()
	{
		var hr = new HRESULT();
		Assert.That(hr.Succeeded);
		hr = HRESULT.E_ACCESSDENIED;
		Assert.That(hr.Failed);
		Assert.That(hr.Code == 5);
		Assert.That(hr.Facility == HRESULT.FacilityCode.FACILITY_WIN32);
		Assert.That(hr.Severity == HRESULT.SeverityLevel.Fail);
	}

	[Test()]
	public void IConvTest()
	{
		HRESULT hr = HRESULT.E_ACCESSDENIED;
		var c = (IConvertible) hr;
		var cv = (IConvertible)HRESULT.E_ACCESSDENIED;
		var f = System.Globalization.CultureInfo.CurrentCulture.NumberFormat;
		Assert.That(c.GetTypeCode(), Is.EqualTo(cv.GetTypeCode()));
		Assert.That(() => c.ToChar(f), Throws.Exception);
		Assert.That(() => c.ToSByte(f), Throws.Exception);
		Assert.That(() => c.ToByte(f), Throws.Exception);
		Assert.That(() => c.ToInt16(f), Throws.Exception);
		Assert.That(() => c.ToUInt16(f), Throws.Exception);
		Assert.That(c.ToUInt32(f), Is.EqualTo(unchecked((uint)HRESULT.E_ACCESSDENIED)));
		Assert.That(c.ToInt32(f), Is.EqualTo(cv.ToInt32(f)));
		Assert.That(c.ToInt64(f), Is.EqualTo(cv.ToInt64(f)));
		Assert.That(c.ToUInt64(f), Is.EqualTo((ulong)unchecked((uint)HRESULT.E_ACCESSDENIED)));
		Assert.That(c.ToSingle(f), Is.EqualTo(cv.ToSingle(f)));
		Assert.That(c.ToDouble(f), Is.EqualTo(cv.ToDouble(f)));
		Assert.That(c.ToDecimal(f), Is.EqualTo(cv.ToDecimal(f)));
		Assert.That(() => c.ToDateTime(f), Throws.Exception);
		Assert.That(c.ToString(f), Does.StartWith("E_ACCESSDENIED"));
		Assert.That(c.ToType(typeof(int), f), Is.EqualTo(cv.ToType(typeof(int), f)));
	}

	[Test]
	public void MakeTest()
	{
		HRESULT hr = HRESULT.E_ACCESSDENIED;
		Assert.That(HRESULT.Make(true, HRESULT.FacilityCode.FACILITY_WIN32, 5) == hr);
		Assert.That(HRESULT.Make(true, 7, 5) == hr);
	}

	[Test()]
	public void OpTest()
	{
		HRESULT hr = HRESULT.SCHED_S_EVENT_TRIGGER;
		Assert.That((int)hr, Is.EqualTo(0x41308));
		Assert.That((HRESULT)0x41308, Is.EqualTo(hr));
		Assert.That(hr != (HRESULT)0x41307);
		Assert.That(hr != 0x41307);
		Assert.That(hr == 0x41308);
		Assert.That(hr.GetHashCode(), Is.GreaterThan(0));
		Assert.That(new HRESULT(HRESULT.S_OK).GetHashCode(), Is.Zero);
	}

	[Test]
	public void ThrowIfFailedTest()
	{
		HRESULT hr = HRESULT.E_ACCESSDENIED;
		Assert.That(() => hr.ThrowIfFailed(), Throws.Exception);
		Assert.That(() => hr.ThrowIfFailed("Bad"), Throws.TypeOf<UnauthorizedAccessException>().With.Message.EqualTo("Bad"));
		Assert.That(() => HRESULT.ThrowIfFailed(0), Throws.Nothing);
	}

	[TestCase(HRESULT.E_INVALIDARG, "E_INVALIDARG")]
	[TestCase(HRESULT.E_ACCESSDENIED, "E_ACCESSDENIED")]
	public void ToStringTest(int c, string res) => Assert.That(new HRESULT(c).ToString(), Does.StartWith(res));

	[TestCase(0x80070003, "HRESULT_FROM_WIN32(ERROR_PATH_NOT_FOUND)")]
	[TestCase(0x80990003, "0x80990003")]
	[TestCase(0x80079254, "0x80079254")]
	public void ToStringTestU(uint c, string res) => Assert.That(new HRESULT(c).ToString(), Does.StartWith(res));

	[Test]
	public void TypeConverterTest()
	{
		HRESULT hr = HRESULT.E_ACCESSDENIED;
		var conv = TypeDescriptor.GetConverter(typeof(HRESULT));

		Assert.That(conv.CanConvertFrom(null, typeof(Win32Error)), Is.True);
		Assert.That(conv.CanConvertFrom(null, typeof(int)), Is.True);
		Assert.That(conv.CanConvertFrom(null, typeof(char)), Is.False);
		Assert.That(conv.CanConvertFrom(null, typeof(DateTime)), Is.False);

		Assert.That(conv.CanConvertTo(null, typeof(string)), Is.True);
		Assert.That(conv.CanConvertFrom(null, typeof(int)), Is.True);
		Assert.That(conv.CanConvertFrom(null, typeof(char)), Is.False);
		Assert.That(conv.CanConvertTo(null, typeof(DateTime)), Is.False);

		Assert.That(conv.ConvertFrom(new Win32Error(5)), Is.EqualTo(hr));
		Assert.That(conv.ConvertFrom(HRESULT.E_ACCESSDENIED), Is.EqualTo(hr));
		Assert.That(conv.ConvertFrom(0x40000), Is.EqualTo(new HRESULT(HRESULT.OLE_S_USEREG)));
		Assert.That(conv.ConvertFrom(true), Is.EqualTo(new HRESULT()));
		Assert.That(conv.ConvertFrom(false), Is.EqualTo(new HRESULT(HRESULT.S_FALSE)));
		Assert.That(() => conv.ConvertFrom('S'), Throws.TypeOf<NotSupportedException>());
		Assert.That(() => conv.ConvertFrom("S"), Throws.TypeOf<NotSupportedException>());

		Assert.That(conv.ConvertTo(hr, typeof(string)), Is.TypeOf<string>());
		Assert.That(conv.ConvertTo(hr, typeof(bool)), Is.EqualTo(false));
		Assert.That(conv.ConvertTo(hr, typeof(int)), Is.EqualTo(HRESULT.E_ACCESSDENIED));
		Assert.That(() => conv.ConvertTo("s", typeof(int)), Throws.TypeOf<NotSupportedException>());
		Assert.That(() => conv.ConvertTo(hr, typeof(char)), Throws.TypeOf<NotSupportedException>());
		Assert.That(() => conv.ConvertTo(hr, typeof(DateTime)), Throws.TypeOf<NotSupportedException>());
	}
}