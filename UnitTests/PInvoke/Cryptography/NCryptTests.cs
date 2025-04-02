using NUnit.Framework;
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

		bd = new NCryptBufferDesc(new(KeyDerivationBufferType.KDF_HASH_ALGORITHM, StandardAlgorithmId.BCRYPT_SHA256_ALGORITHM),
			new(KeyDerivationBufferType.KDF_GENERIC_PARAMETER, GenericParameter));
		Assert.That(bd.pBuffers.Length, Is.EqualTo(2));
		Assert.That(bd.ulVersion, Is.Zero);

		using var b = SafeCoTaskMemHandle.CreateFromStructure(bd);
		Assert.That((uint)b.Size, Is.EqualTo(80));

		var bd2 = b.ToStructure<NCryptBufferDesc>()!;
		Assert.That(bd2.pBuffers.Length, Is.EqualTo(2));
		Assert.That(bd2.pBuffers[1].pvBuffer, Is.EquivalentTo(GenericParameter));
	}
}