using NUnit.Framework;
using NUnit.Framework.Internal;
using static Vanara.PInvoke.Kernel32;
using static Vanara.PInvoke.WinTrust;
using static Vanara.PInvoke.AdvApi32;

namespace Vanara.PInvoke.Tests;
[TestFixture]
public class WinTrustTests
{
	const string catfile = @"C:\Windows\System32\CatRoot\{F750E6C3-38EE-11D1-85E5-00C04FC295EE}\ntprint.cat";
	const string cdffile = @"C:\Temp\Good.cdf";
	const uint NTE_BAD_KEYSET = 0x80090016;

	[Test]
	public void CDFTest()
	{
		using SafeCRYPTCATCDF cdf = CryptCATCDFOpen(cdffile, callback);
		Assert.That(cdf, ResultIs.ValidHandle);
		ManagedStructPointer<CRYPTCATMEMBER> pMember = default;
		string? pwszMemberTag = default;
		while ((pwszMemberTag = CryptCATCDFEnumMembersByCDFTagEx(cdf, pwszMemberTag, callback, pMember, true)) != null)
			TestContext.WriteLine(pwszMemberTag);

		void callback(CRYPTCAT_E dwErrorArea, CRYPTCAT_E dwLocalError, string pwszLine) =>
			TestContext.WriteLine($"{dwErrorArea} {dwLocalError} {pwszLine}");
	}

	[Test]
	public void ReadCatalogTest()
	{
		if (!CryptAcquireContext(out var hCryptProv, default, default, PROV_RSA_FULL, 0))
		{
			Assert.That((uint)GetLastError(), Is.EqualTo(NTE_BAD_KEYSET), "CryptAcquireContext failed to get a handle to the default key container.");

			// No default container was found. Attempt to create it.
			Assert.That(CryptAcquireContext(out hCryptProv, default, default, PROV_RSA_FULL, CryptAcquireContextFlags.CRYPT_NEWKEYSET), ResultIs.Successful);
		}

		using var catHandle = CryptCATOpen(catfile, 0, hCryptProv, CRYPTCAT_VERSION.CRYPTCAT_VERSION_1,
			Crypt32.CertEncodingType.CRYPT_ASN_ENCODING);
		Assert.That(catHandle, ResultIs.ValidHandle, "Failed to open catalog file.");

		foreach (var pMember in CryptCATEnumerateMember(catHandle))
			TestContext.WriteLine($"New member: {pMember.pwszReferenceTag}");

		foreach (var attr in CryptCATEnumerateCatAttr(catHandle))
			attr.WriteValues();
	}
}