using NUnit.Framework;
using System.Linq;
using static Vanara.PInvoke.BCrypt;
using static Vanara.PInvoke.NCrypt;

namespace Vanara.PInvoke.Tests;

[TestFixture()]
public class NCryptTests
{
	public static readonly byte[] GenericParameter = [
		0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0a,
		0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09,
	];

	[Test]
	public void NCryptBufferDescTest()
	{
		var bd = new NCryptBufferDesc();
		Assert.That(bd.pBuffers, Is.Empty);
		Assert.That(bd.ulVersion, Is.Zero);

		bd = new NCryptBufferDesc( // 16
			new(KeyDerivationBufferType.KDF_HASH_ALGORITHM, StandardAlgorithmId.BCRYPT_SHA256_ALGORITHM), // 16 + 14
			new(KeyDerivationBufferType.KDF_GENERIC_PARAMETER, GenericParameter)); // 16 + 20
		Assert.That(bd.pBuffers.Length, Is.EqualTo(2));
		Assert.That(bd.ulVersion, Is.Zero);

		using var b = SafeCoTaskMemHandle.CreateFromStructure(bd);
		Assert.That((uint)b.Size, Is.EqualTo(82));

		var bd2 = b.ToStructure<NCryptBufferDesc>()!;
		Assert.That(bd2.pBuffers.Length, Is.EqualTo(2));
		Assert.That(bd2.pBuffers[1].pvBuffer, Is.EquivalentTo(GenericParameter));
	}

	[Test]
	public void NCryptEncapsulateDecapsulateTest()
	{
		using var hProv = SafeNCRYPT_PROV_HANDLE.OpenStorage(KnownStorageProvider.MS_KEY_STORAGE_PROVIDER);
		Assert.That(hProv, ResultIs.ValidHandle);

		Assert.That(hProv.CreatePersistedKey(out var hKey, StandardAlgorithmId.BCRYPT_MLKEM_ALGORITHM), ResultIs.Successful);
		Assert.That(NCryptSetProperty(hKey, BCrypt.PropertyName.BCRYPT_PARAMETER_SET_NAME, ParameterSetName.BCRYPT_MLKEM_PARAMETER_SET_768), ResultIs.Successful);
		Assert.That(NCryptFinalizeKey(hKey), ResultIs.Successful);

		Assert.That(NCryptEncapsulate(hKey, out var pbSecretKey, out var pbCipherText), ResultIs.Successful);
		Assert.That(pbSecretKey, Is.Not.Empty);
		Assert.That(pbSecretKey.Any(b => b != 0), Is.True);
		Assert.That(pbCipherText, Is.Not.Empty);
		Assert.That(pbCipherText.Any(b => b != 0), Is.True);

		Assert.That(NCryptDecapsulate(hKey, pbCipherText, out var pbNewSecretKey), ResultIs.Successful);
		Assert.That(pbNewSecretKey, Is.Not.Empty.And.Length.EqualTo(pbSecretKey.Length));
		Assert.That(pbNewSecretKey, Is.EquivalentTo(pbSecretKey));
	}
}