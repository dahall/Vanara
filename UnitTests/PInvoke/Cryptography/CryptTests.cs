using NUnit.Framework;
using static Vanara.PInvoke.Crypt32;

namespace Vanara.PInvoke.Tests;

[TestFixture()]
public class CryptTests
{
	[Test]
	public void CryptEnumOIDFunctionTest()
	{
		var ret = CryptEnumOIDFunction();
		Assert.That(ret, Is.Not.Empty);
		foreach (var oid in ret)
		{
			TestContext.WriteLine($"{oid.encType} {oid.funcName} {oid.oid}");
			foreach (var (valueName, value) in oid.values)
				TestContext.WriteLine($"  {valueName} = {(value is string[] a ? string.Join(",", a) : value?.ToString())}");
		}
	}

	[Test]
	public void CryptEnumOIDInfoTest()
	{
		var ret = CryptEnumOIDInfo();
		Assert.That(ret, Is.Not.Empty);
		foreach (var oid in ret)
		{
			TestContext.WriteLine(((SafeOID)(IntPtr)oid.pszOID).ToString());
			oid.WriteValues();
		}
	}
}