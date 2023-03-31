using NUnit.Framework;
using System;
using System.Runtime.InteropServices;
using System.Text;
using Vanara.InteropServices;
using static Vanara.PInvoke.AdvApi32;
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
		StringBuilder sb = new(256);
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
		Assert.That(GetStringTypeA(GetUserDefaultLCID(), CHAR_TYPE_INFO.CT_CTYPE3, input, -1, result), ResultIs.Successful);
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
		const string input = "HÃ´tel";
		const string output = "Hôtel";

		StringBuilder sb = new(256);
		Assert.That(MultiByteToWideChar(CP_UTF8, 0, input, -1, sb, sb.Capacity), Is.GreaterThan(0));
		TestContext.WriteLine(sb);
		Assert.That(sb.ToString(), Is.EqualTo(output));

		sb.Clear();
		Assert.That(WideCharToMultiByte(CP_UTF8, 0, output, -1, sb, sb.Capacity), Is.GreaterThan(0));
		TestContext.WriteLine(sb);
		Assert.That(sb.ToString(), Is.EqualTo(input));
	}
}