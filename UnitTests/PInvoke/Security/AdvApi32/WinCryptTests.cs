using NUnit.Framework;
using System.Linq;
using static Vanara.PInvoke.AdvApi32;
using static Vanara.PInvoke.Crypt32;

namespace Vanara.PInvoke.Tests;

[TestFixture()]
public class WinCryptTests
{
	private const string myContName = "MyTestingContainer";

	[Test]
	public void CryptExportKeyTest()
	{
		CryptAcquireContext(out _, myContName, CryptProviderName.MS_ENHANCED_PROV, PROV_RSA_FULL, CryptAcquireContextFlags.CRYPT_DELETEKEYSET);
		Assert.That(CryptAcquireContext(out SafeHCRYPTPROV hProv, myContName, CryptProviderName.MS_ENHANCED_PROV, PROV_RSA_FULL, CryptAcquireContextFlags.CRYPT_NEWKEYSET), ResultIs.Successful);
		using (hProv)
		{
			// get user key from container
			Assert.That(CryptGenKey(hProv, (ALG_ID)CertKeySpec.AT_KEYEXCHANGE, CryptGenKeyFlags.CRYPT_EXPORTABLE, out SafeHCRYPTKEY hKey), ResultIs.Successful);
			using (hKey)
			{
				uint dwBlobLen = 0;
				CryptExportKey(hKey, default, BlobType.PUBLICKEYBLOB, 0, null, ref dwBlobLen);
				Assert.That(dwBlobLen, Is.GreaterThan(0));

				var pbKeyBlobBuffer = new byte[dwBlobLen];
				Assert.That(CryptExportKey(hKey, default, BlobType.PUBLICKEYBLOB, 0, pbKeyBlobBuffer, ref dwBlobLen), ResultIs.Successful);
			}
		}
	}

	[Test]
	public void CryptEnumProviderTypesTest()
	{
		var output = CryptEnumProviderTypes().ToArray();
		Assert.That(output, Is.Not.Empty);
		output.WriteValues();
	}

	[Test]
	public void CryptEnumKeyIdentifierPropertiesTest()
	{
		var output = CryptEnumKeyIdentifierProperties().ToArray();
		Assert.That(output, Is.Not.Empty);
		output.WriteValues();
	}
}