using NUnit.Framework;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class AutoGenTests
{
	[Test]
	public void ExpandEnvironmentStringsTest()
	{
		var ret = ExpandEnvironmentStrings(@"%SystemRoot%\System32", out string? result);
		Assert.That(result, Is.EqualTo(@"C:\WINDOWS\System32"));
		Assert.That(ret, Is.EqualTo(result!.Length + 1));
	}

	[Test]
	public void GetCalendarInfoTest()
	{
		var ret = GetCalendarInfo(LOCALE_SYSTEM_DEFAULT, CALID.CAL_GREGORIAN, CALTYPE.CAL_SABBREVMONTHNAME1, out string? result);
		Assert.That(result, Is.EqualTo("Jan"));
		Assert.That(ret, Is.EqualTo(result!.Length + 1));
	}

	[Test]
	public void GetLocaleInfoTest()
	{
		Assert.That(GetLocaleInfo(LOCALE_USER_DEFAULT, LCTYPE.LOCALE_RETURN_NUMBER | LCTYPE.LOCALE_ICURRDIGITS, out byte[] pBuffer), ResultIs.Not.Value(0));
		Assert.That(BitConverter.ToUInt16(pBuffer), Is.Not.Zero);
	}

	[Test]
	public void GetNumaNodeProcessorMask2Test()
	{
		Assert.That(GetNumaNodeProcessorMask2(0, out GROUP_AFFINITY[]? procMask), ResultIs.Successful);
		Assert.That(procMask, Is.Not.Null.And.Length.GreaterThan(0));
	}
}