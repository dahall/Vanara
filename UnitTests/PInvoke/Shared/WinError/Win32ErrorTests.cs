using NUnit.Framework;
using System;
using System.ComponentModel;
using NUnit.Framework.Constraints;

namespace Vanara.PInvoke.Tests;

[TestFixture()]
public class Win32ErrorTests
{
	[TestCase(Win32Error.ERROR_ACCESS_DENIED, 5, ExpectedResult = 0)]
	[TestCase(Win32Error.ERROR_ACCESS_DENIED, 0, ExpectedResult = 1)]
	[TestCase(Win32Error.ERROR_ACCESS_DENIED, 2U, ExpectedResult = 1)]
	[TestCase(Win32Error.ERROR_ACCESS_DENIED, Win32Error.ERROR_INVALID_PARAMETER, ExpectedResult = -1)]
	[TestCase(Win32Error.ERROR_INVALID_PARAMETER, Win32Error.ERROR_ACCESS_DENIED, ExpectedResult = 1)]
	public int CompareToTest(uint c, object obj) => new Win32Error(c).CompareTo(obj);

	[TestCase(Win32Error.ERROR_ACCESS_DENIED, Win32Error.ERROR_INVALID_PARAMETER, ExpectedResult = -1)]
	[TestCase(Win32Error.ERROR_INVALID_PARAMETER, Win32Error.ERROR_ACCESS_DENIED, ExpectedResult = 1)]
	[TestCase(Win32Error.ERROR_INVALID_PARAMETER, Win32Error.ERROR_INVALID_PARAMETER, ExpectedResult = 0)]
	public int CompareToTest1(uint c1, uint c2) => new Win32Error(c1).CompareTo(new Win32Error(c2));

	[Test]
	public void ComparisonTest()
	{
		Win32Error hr = Win32Error.ERROR_ACCESS_DENIED;
		Assert.That(() => hr.CompareTo(null), Throws.ArgumentException);
		Assert.That(() => hr.CompareTo("A"), Throws.Exception);
		Assert.That(() => hr.CompareTo(DateTime.Today), Throws.Exception);
	}

	[TestCase(Win32Error.ERROR_ACCESS_DENIED, 5, ExpectedResult = true)]
	[TestCase(Win32Error.ERROR_ACCESS_DENIED, 0, ExpectedResult = false)]
	[TestCase(Win32Error.ERROR_ACCESS_DENIED, 2U, ExpectedResult = false)]
	[TestCase(Win32Error.ERROR_ACCESS_DENIED, Win32Error.ERROR_INVALID_PARAMETER, ExpectedResult = false)]
	[TestCase(Win32Error.ERROR_INVALID_PARAMETER, Win32Error.ERROR_ACCESS_DENIED, ExpectedResult = false)]
	[TestCase(Win32Error.ERROR_ACCESS_DENIED, "A", ExpectedResult = false)]
	[TestCase(Win32Error.ERROR_ACCESS_DENIED, uint.MaxValue, ExpectedResult = false)]
	public bool EqualsTest(uint c, object obj) => new Win32Error(c).Equals(obj);

	[TestCase(Win32Error.ERROR_ACCESS_DENIED, Win32Error.ERROR_INVALID_PARAMETER, ExpectedResult = false)]
	[TestCase(Win32Error.ERROR_INVALID_PARAMETER, Win32Error.ERROR_ACCESS_DENIED, ExpectedResult = false)]
	[TestCase(Win32Error.ERROR_INVALID_PARAMETER, Win32Error.ERROR_INVALID_PARAMETER, ExpectedResult = true)]
	public bool EqualsTest1(uint c1, uint c2) => new Win32Error(c1).Equals(new Win32Error(c2));

	[Test]
	public void GetExceptionTest()
	{
		Assert.That(new Win32Error().GetException(), Is.Null);
		Assert.That(new Win32Error(Win32Error.DNS_ERROR_CANNOT_FIND_ROOT_HINTS).GetException(), Is.TypeOf<Win32Exception>());
		Assert.That(new Win32Error(Win32Error.ERROR_ACCESS_DENIED).GetException(), Is.TypeOf<UnauthorizedAccessException>());
		Assert.That(new Win32Error(Win32Error.ERROR_INVALID_PARAMETER).GetException(), Is.TypeOf<ArgumentException>());
		Assert.That(new Win32Error(Win32Error.ERROR_INVALID_PARAMETER).GetException("Bad"), Has.Message.EqualTo("Bad"));
	}

	[Test()]
	public void IConvTest()
	{
		Win32Error err = Win32Error.ERROR_ACCESS_DENIED;
		var c = (IConvertible)err;
		var cv = (IConvertible)Win32Error.ERROR_ACCESS_DENIED;
		var f = System.Globalization.CultureInfo.CurrentCulture.NumberFormat;
		Assert.That(c.GetTypeCode(), Is.EqualTo(cv.GetTypeCode()));
		Assert.That(() => c.ToChar(f), Throws.Exception);
		Assert.That(c.ToSByte(f), Is.EqualTo(cv.ToSByte(f)));
		Assert.That(c.ToByte(f), Is.EqualTo(cv.ToByte(f)));
		Assert.That(c.ToInt16(f), Is.EqualTo(cv.ToInt16(f)));
		Assert.That(c.ToUInt16(f), Is.EqualTo(cv.ToUInt16(f)));
		Assert.That(c.ToInt32(f), Is.EqualTo(cv.ToInt32(f)));
		Assert.That(c.ToUInt32(f), Is.EqualTo(cv.ToUInt32(f)));
		Assert.That(c.ToInt64(f), Is.EqualTo(cv.ToInt64(f)));
		Assert.That(c.ToUInt64(f), Is.EqualTo(cv.ToUInt64(f)));
		Assert.That(c.ToSingle(f), Is.EqualTo(cv.ToSingle(f)));
		Assert.That(c.ToDouble(f), Is.EqualTo(cv.ToDouble(f)));
		Assert.That(c.ToDecimal(f), Is.EqualTo(cv.ToDecimal(f)));
		Assert.That(() => c.ToDateTime(f), Throws.Exception);
		Assert.That(c.ToString(f), Does.StartWith("ERROR_ACCESS_DENIED"));
		Assert.That(c.ToType(typeof(uint), f), Is.EqualTo(cv.ToType(typeof(uint), f)));
	}

	[Test()]
	public void OpTest()
	{
		Win32Error err = Win32Error.ERROR_ACCESS_DENIED;
		Assert.That((uint)err, Is.EqualTo(0x5));
		Assert.That((Win32Error)0x5, Is.EqualTo(err));
		Assert.That(err != (Win32Error)0x41307);
		Assert.That(err != 0x41307);
		Assert.That(err == 5);
		Assert.That(err.Equals(5));
		Assert.That(err == (Win32Error)5);
		Assert.That(err.GetHashCode(), Is.GreaterThan(0));
		Assert.That(new Win32Error(Win32Error.ERROR_SUCCESS).GetHashCode(), Is.Zero);
	}

	[Test()]
	public void Win32ErrorTest()
	{
		var hr = new Win32Error();
		Assert.That(hr.Succeeded);
		hr = Win32Error.ERROR_ACCESS_DENIED;
		Assert.That(hr.Failed);
	}

	[Test]
	public void ThrowIfFailedTest()
	{
		Win32Error hr = Win32Error.ERROR_ACCESS_DENIED;
		Assert.That(() => hr.ThrowIfFailed(), Throws.Exception);
		Assert.That(() => hr.ThrowIfFailed("Bad"), Throws.TypeOf<UnauthorizedAccessException>().With.Message.EqualTo("Bad"));
		Assert.That(() => Win32Error.ThrowIfFailed(0), Throws.Nothing);
		var err = Win32Error.GetLastError();
		Assert.That((uint)err, Is.GreaterThanOrEqualTo(0));
		if (err.Succeeded)
			Assert.That(() => Win32Error.ThrowLastError(), Throws.Nothing);
		else
			Assert.That(() => Win32Error.ThrowLastError(), Throws.Exception);
	}

	[TestCase(Win32Error.ERROR_INVALID_PARAMETER, "ERROR_INVALID_PARAMETER")]
	[TestCase(Win32Error.ERROR_ACCESS_DENIED, "ERROR_ACCESS_DENIED")]
	[TestCase(0x00000003U, "ERROR_PATH_NOT_FOUND")]
	[TestCase(0x00990003U, "0x00990003")]
	public void ToStringTest(uint c, string val) => Assert.That(new Win32Error(c).ToString(), Does.StartWith(val));

	[Test]
	public void TypeConverterTest()
	{
		Win32Error hr = Win32Error.ERROR_ACCESS_DENIED;
		var conv = TypeDescriptor.GetConverter(typeof(Win32Error));

		Assert.That(conv.CanConvertFrom(null, typeof(uint)), Is.True);
		Assert.That(conv.CanConvertFrom(null, typeof(char)), Is.False);
		Assert.That(conv.CanConvertFrom(null, typeof(DateTime)), Is.False);

		Assert.That(conv.CanConvertTo(null, typeof(string)), Is.True);
		Assert.That(conv.CanConvertFrom(null, typeof(uint)), Is.True);
		Assert.That(conv.CanConvertFrom(null, typeof(char)), Is.False);
		Assert.That(conv.CanConvertTo(null, typeof(DateTime)), Is.False);

		Assert.That(conv.ConvertFrom(Win32Error.ERROR_ACCESS_DENIED), Is.EqualTo(hr));
		Assert.That(conv.ConvertFrom(0x00000003), Is.EqualTo(new Win32Error(Win32Error.ERROR_PATH_NOT_FOUND)));
		Assert.That(() => conv.ConvertFrom(true), Throws.TypeOf<NotSupportedException>());
		Assert.That(() => conv.ConvertFrom(false), Throws.TypeOf<NotSupportedException>());
		Assert.That(() => conv.ConvertFrom('S'), Throws.TypeOf<NotSupportedException>());
		Assert.That(() => conv.ConvertFrom("S"), Throws.TypeOf<NotSupportedException>());

		Assert.That(conv.ConvertTo(hr, typeof(string)), Is.TypeOf<string>());
		Assert.That(conv.ConvertTo(hr, typeof(bool)), Is.EqualTo(false));
		Assert.That(conv.ConvertTo(hr, typeof(uint)), Is.EqualTo(Win32Error.ERROR_ACCESS_DENIED));
		Assert.That(() => conv.ConvertTo("s", typeof(uint)), Throws.TypeOf<NotSupportedException>());
		Assert.That(() => conv.ConvertTo(hr, typeof(char)), Throws.TypeOf<NotSupportedException>());
		Assert.That(() => conv.ConvertTo(hr, typeof(DateTime)), Throws.TypeOf<NotSupportedException>());
	}
}