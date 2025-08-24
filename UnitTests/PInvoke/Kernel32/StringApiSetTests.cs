using NUnit.Framework;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class StringApiSetTests
{
	[Test]
	public void CompareStringTest()
	{
		Assert.That(CompareString(GetUserDefaultLCID(), COMPARE_STRING.SORT_DIGITSASNUMBERS, "2", 1, "10", 2), Is.EqualTo(CSTR_LESS_THAN));
		Assert.That(CompareString(GetUserDefaultLCID(), 0, "2", 1, "10", 2), Is.EqualTo(CSTR_GREATER_THAN));
	}

	[Test]
	public void CompareStringExTest()
	{
		Assert.That(CompareStringEx(LOCALE_NAME_INVARIANT, COMPARE_STRING.SORT_DIGITSASNUMBERS, "2", 1, "10", 2), Is.EqualTo(CSTR_LESS_THAN));
		Assert.That(CompareStringEx(LOCALE_NAME_INVARIANT, 0, "2", 1, "10", 2), Is.EqualTo(CSTR_GREATER_THAN));
	}

	[Test]
	public void CompareStringOrdinalTest()
	{
		Assert.That(CompareStringOrdinal("Fred", 4, "Fred", 4, false), Is.EqualTo(CSTR_EQUAL));
		Assert.That(CompareStringOrdinal("Fred", 4, "fred", 4, true), Is.EqualTo(CSTR_EQUAL));
	}

	[Test]
	public void FoldStringTest()
	{
		const string input = "T\u00e8st string \uFF54\uFF4F n\u00f8rm\u00e4lize";
		StringBuilder sb = new(input.Length * 2);
		foreach (STRING_MAPPING e in Enum.GetValues(typeof(STRING_MAPPING)))
		{
			Assert.That(FoldString(e, input, input.Length, sb, sb.Capacity), Is.GreaterThan(0));
			TestContext.WriteLine(sb);
			Assert.That(sb.Length, Is.GreaterThan(0));
			sb.Clear();
		}
	}

	[Test]
	public void GetStringTypeATest()
	{
		const string input = "T\u00e8st string \uFF54\uFF4F n\u00f8rm\u00e4lize";
		ushort[] result = new ushort[input.Length + 1];
#pragma warning disable CS0618 // Type or member is obsolete
		Assert.That(GetStringTypeA(GetUserDefaultLCID(), CHAR_TYPE_INFO.CT_CTYPE3, input, -1, result), ResultIs.Successful);
#pragma warning restore CS0618 // Type or member is obsolete
		result.WriteValues();
	}

	[Test]
	public void GetStringTypeWTest()
	{
		const string input = "T\u00e8st string \uFF54\uFF4F n\u00f8rm\u00e4lize";
		ushort[] result = new ushort[input.Length + 1];
		Assert.That(GetStringTypeW(CHAR_TYPE_INFO.CT_CTYPE3, input, -1, result), ResultIs.Successful);
		result.WriteValues();
	}

	[Test]
	public void GetStringTypeExTest()
	{
		const string input = "T\u00e8st string \uFF54\uFF4F n\u00f8rm\u00e4lize";
		ushort[] result = new ushort[input.Length + 1];
		Assert.That(GetStringTypeEx(LOCALE_USER_DEFAULT, CHAR_TYPE_INFO.CT_CTYPE3, input, -1, result), ResultIs.Successful);
		result.WriteValues();
	}

	[Test]
	public void GetStringTypeExTest2()
	{
		const string input = "T\u00e8st string \uFF54\uFF4F n\u00f8rm\u00e4lize";
		Assert.That(() =>
		{
			Ctype3[] result = GetStringTypeEx<Ctype3>(input, LOCALE_USER_DEFAULT);
			result.WriteValues();
		}, Throws.Nothing);
		Assert.That(() => GetStringTypeEx<CHAR_TYPE_INFO>(input, LOCALE_USER_DEFAULT), Throws.ArgumentException);
		Assert.That(() => GetStringTypeEx<Ctype2>("", LOCALE_USER_DEFAULT), Throws.ArgumentNullException);
	}

	[Test]
	public void MultiByteToWideCharAndBackTest()
	{
		byte[] utf8String = StringHelper.GetBytes("Hôtel", Encoding.UTF8); // "HÃ´tel"
		byte[] uniString = StringHelper.GetBytes("Hôtel", Encoding.Unicode);

		//byte[] buf = new byte[uniString.Length + 4];
		int len;
		Assert.That(len = MultiByteToWideChar(CP_UTF8, 0, utf8String), Is.GreaterThan(0));
		byte[] buf = new byte[len * 2];
		Assert.That(MultiByteToWideChar(CP_UTF8, 0, utf8String, -1, buf, buf.Length / 2), Is.GreaterThan(0));
		TestContext.WriteLine(Encoding.Unicode.GetString(buf));
		Assert.That(buf, Is.EqualTo(uniString));

		Assert.That(len = WideCharToMultiByte(CP_UTF8, 0, uniString), Is.GreaterThan(0));
		buf = new byte[len];
		Assert.That(WideCharToMultiByte(CP_UTF8, 0, uniString, -1, buf, buf.Length), Is.GreaterThan(0));
		TestContext.WriteLine(Encoding.UTF8.GetString(buf));
		Assert.That(buf, Is.EqualTo(utf8String));
	}

	[Test]
	public void MultiByteToWideCharAndBackTest2()
	{
		byte[] utf8String = StringHelper.GetBytes("Hôtel", Encoding.UTF8); // "HÃ´tel"
		byte[] uniString = StringHelper.GetBytes("Hôtel", Encoding.Unicode);

		Assert.That(MultiByteToWideChar(CP_UTF8, utf8String), Is.EqualTo(uniString));

		Assert.That(WideCharToMultiByte(CP_UTF8, uniString, lpUsedDefaultChar: out var uc), Is.EqualTo(utf8String));
		Assert.That(uc, Is.Null, "Used default char should not be set when converting a UTF8 string.");
	}
}