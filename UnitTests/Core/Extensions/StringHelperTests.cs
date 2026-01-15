using NUnit.Framework;
using System.Linq;
using System.Security;
using Vanara.PInvoke;

namespace Vanara.Extensions.Tests;

[TestFixture()]
public class StringHelperTests
{
	private static readonly object?[][] testStrings = [
		[null, 0, 0],
		["", 1, 2],
		["Hello, world!", 14, 28],
		["你好，世界！", 19, 14],
		["Surrogate test: \uD83D\uDE00", 21, 38],
	];

	[Test()]
	public void AllocCharsTest()
	{
		var sptr = StringHelper.AllocChars(10, CharSet.Ansi);
		Assert.That(sptr, Is.Not.EqualTo(IntPtr.Zero));
		StringHelper.FreeString(sptr, CharSet.Ansi);
		sptr = StringHelper.AllocChars(10, CharSet.Unicode);
		Assert.That(sptr, Is.Not.EqualTo(IntPtr.Zero));
		StringHelper.FreeString(sptr, CharSet.Unicode);
		Assert.That(StringHelper.AllocChars(0), Is.EqualTo(IntPtr.Zero));
	}

	[Test()]
	public void AllocSecureStringTest()
	{
		var sptr = StringHelper.AllocSecureString(new SecureString(), CharSet.Ansi);
		Assert.That(sptr, Is.Not.EqualTo(IntPtr.Zero));
		StringHelper.FreeString(sptr, CharSet.Ansi);
		sptr = StringHelper.AllocSecureString(new SecureString(), CharSet.Unicode);
		Assert.That(sptr, Is.Not.EqualTo(IntPtr.Zero));
		StringHelper.FreeString(sptr, CharSet.Unicode);
	}

	[TestCaseSource(nameof(testStrings))]
	public void AllocStringTest(string val, int cbAnsi, int cbUni)
	{
		var sptr = StringHelper.AllocString(val, CharSet.Ansi);
		if (val is not null)
			Assert.That(sptr, Is.Not.EqualTo(IntPtr.Zero));
		var astr = StringHelper.GetString(sptr, CharSet.Ansi);
		Assert.That(astr?.Length ?? 0, Is.EqualTo(val?.Length ?? 0));
		if (val is null || !val.Any(c => c > 255))
			Assert.That(astr, Is.EqualTo(val));
		StringHelper.RefreshString(ref sptr, out var l, "ZZZ", CharSet.Ansi);
		Assert.That(l, Is.EqualTo(4));
		Assert.That(StringHelper.GetString(sptr, CharSet.Ansi), Is.EqualTo("ZZZ"));
		StringHelper.FreeString(sptr, CharSet.Ansi);

		sptr = StringHelper.AllocString(val, CharSet.Unicode);
		if (val is not null)
			Assert.That(sptr, Is.Not.EqualTo(IntPtr.Zero));
		Assert.That(StringHelper.GetString(sptr, CharSet.Unicode), Is.EqualTo(val));
		StringHelper.RefreshString(ref sptr, out l, "ZZZZ", CharSet.Unicode);
		Assert.That(l, Is.EqualTo(5));
		Assert.That(StringHelper.GetString(sptr, CharSet.Unicode), Is.EqualTo("ZZZZ"));

		// Check null case
		StringHelper.RefreshString(ref sptr, out l, null, CharSet.Unicode);
		Assert.That(l, Is.EqualTo(0));
		Assert.That(StringHelper.GetString(sptr, CharSet.Unicode), Is.Null);

		StringHelper.FreeString(sptr, CharSet.Unicode);
	}

	[TestCase("BOO", CharSet.Ansi, 4)]
	[TestCase("BOO", CharSet.Unicode, 8)]
	[TestCase("", CharSet.Ansi, 1)]
	[TestCase("", CharSet.Unicode, 2)]
	public void GetBytesNullTermTest(string val, CharSet cs, int len)
	{
		var bytes = val.GetBytes(true, cs);
		Assert.That(bytes.Length, Is.EqualTo(len));
	}

	[TestCase(CharSet.Ansi, 1)]
	[TestCase(CharSet.Unicode, 2)]
	public void GetCharSizeTest(CharSet cs, int len)
	{
		Assert.That(StringHelper.GetCharSize(cs), Is.EqualTo(len));
	}

	[TestCase("hello", true, CharSet.Ansi, 6)]
	[TestCase("hello", false, CharSet.Ansi, 5)]
	[TestCase("hello", true, CharSet.Unicode, 12)]
	[TestCase("hello", false, CharSet.Unicode, 10)]
	[TestCase("", true, CharSet.Ansi, 1)]
	[TestCase("", false, CharSet.Ansi, 0)]
	[TestCase("", true, CharSet.Unicode, 2)]
	[TestCase("", false, CharSet.Unicode, 0)]
	[TestCase(null, true, CharSet.Ansi, 0)]
	[TestCase(null, false, CharSet.Ansi, 0)]
	[TestCase(null, true, CharSet.Unicode, 0)]
	[TestCase(null, false, CharSet.Unicode, 0)]
	public void GetByteCountTest(string value, bool nullTerm, CharSet cs, int ret)
	{
		Assert.That(StringHelper.GetByteCount(value, nullTerm, cs), Is.EqualTo(ret));
	}

	[TestCase(null, 0)]
	[TestCase("", 1)]
	[TestCase("Hello, world!", 14)]
	public void GetAnsiStringTest(string value, int len)
	{
		IntPtr ptr = default;
		CharSet cs = CharSet.Ansi;
		try
		{
			ptr = StringHelper.AllocString(value, cs, Marshal.AllocCoTaskMem, out var count);
			Assert.That(count, Is.EqualTo(len));
			Assert.That(StringHelper.GetString(ptr, cs), Is.EqualTo(value));
			Assert.That(StringHelper.GetString(ptr, cs, count * 2), Is.EqualTo(value));
			if (ptr == IntPtr.Zero)
				Assert.That(value, Is.Null);
			else
			{
				Assert.That(value, Is.Not.Null);
				var readVal = StringHelper.GetString(ptr, cs, count / 2)!;
				if (value.Length > 0)
				{
					Assert.That(value, Is.Not.EqualTo(readVal));
					Assert.That(value.StartsWith(readVal));
				}
				else
					Assert.That(readVal, Is.EqualTo(string.Empty));
			}
		}
		finally
		{
			Marshal.FreeCoTaskMem(ptr);
		}
	}

	[TestCase(null, 0)]
	[TestCase("", 2)]
	[TestCase("Hello, world!", 28)]
	[TestCase("你好，世界！", 14)]
	[TestCase("Surrogate test: \uD83D\uDE00", 38)]
	public void GetUniStringTest(string value, int len)
	{
		IntPtr ptr = default;
		CharSet cs = CharSet.Unicode;
		try
		{
			ptr = StringHelper.AllocString(value, cs, Marshal.AllocCoTaskMem, out var count);
			Assert.That(count, Is.EqualTo(len));
			Assert.That(StringHelper.GetString(ptr, cs), Is.EqualTo(value));
			Assert.That(StringHelper.GetString(ptr, cs, count * 2), Is.EqualTo(value));
			if (ptr == IntPtr.Zero)
				Assert.That(value, Is.Null);
			else
			{
				Assert.That(value, Is.Not.Null);
				var readVal = StringHelper.GetString(ptr, cs, count / 2)!;
				if (value.Length > 0)
				{
					Assert.That(value, Is.Not.EqualTo(readVal));
					Assert.That(value.StartsWith(readVal));
				}
				else
					Assert.That(readVal, Is.EqualTo(string.Empty));
			}
		}
		finally
		{
			Marshal.FreeCoTaskMem(ptr);
		}
	}

	[TestCase(null, 0)]
	[TestCase("", 2)]
	[TestCase("Hello, world!", 28)]
	[TestCase("你好，世界！", 14)]
	[TestCase("Surrogate test: \uD83D\uDE00", 38)]
	public void GetEncUniStringTest(string value, int len)
	{
		IntPtr ptr = default;
		Encoding cs = Encoding.Unicode;
		try
		{
			ptr = StringHelper.AllocString(value, cs, Marshal.AllocCoTaskMem, out var count);
			Assert.That(count, Is.EqualTo(len));
			Assert.That(StringHelper.GetString(ptr, cs, out var read), Is.EqualTo(value));
			Assert.That((int)read, Is.EqualTo(count));
			Assert.That(StringHelper.GetString(ptr, cs, out _, count * 2), Is.EqualTo(value));
			if (ptr == IntPtr.Zero)
				Assert.That(value, Is.Null);
			else
			{
				Assert.That(value, Is.Not.Null);
				var readVal = StringHelper.GetString(ptr, cs, out _, count / 2)!;
				if (value.Length > 0)
				{
					Assert.That(value, Is.Not.EqualTo(readVal));
					Assert.That(value.StartsWith(readVal));
				}
				else
					Assert.That(readVal, Is.EqualTo(string.Empty));
			}
		}
		finally
		{
			Marshal.FreeCoTaskMem(ptr);
		}
	}

	[TestCase("BOO", CharSet.Ansi)]
	[TestCase("BOO", CharSet.Unicode)]
	[TestCase("BOO", CharSet.None)]
	[TestCase("", CharSet.Ansi)]
	[TestCase("", CharSet.Unicode)]
	[TestCase("", CharSet.None)]
	[TestCase(null, CharSet.Ansi)]
	[TestCase(null, CharSet.Unicode)]
	[TestCase(null, CharSet.None)]
	public void GetEncStringTest(string value, CharSet cs)
	{
		IntPtr ptr = default;
		try
		{
			Encoding encoding = cs.ToEncoding();
			ptr = StringHelper.AllocString(value, encoding, Marshal.AllocCoTaskMem, out var count);
			Assert.That(count, Is.EqualTo(StringHelper.GetByteCount(value, encoding, true)));
			Assert.That(StringHelper.GetString(ptr, encoding, out SIZE_T sz), Is.EqualTo(value));
			Assert.That((int)sz, Is.EqualTo(count));
			Assert.That(StringHelper.GetString(ptr, encoding, out sz, count * 2), Is.EqualTo(value));
			Assert.That((int)sz, Is.EqualTo(count));
			Assert.That(StringHelper.GetString(ptr, encoding, out _, count / 2), Is.EqualTo(string.IsNullOrEmpty(value) ? value : value.Substring(0, (value.Length + 1) / 2)));
		}
		finally
		{
			Marshal.FreeCoTaskMem(ptr);
		}
	}
}