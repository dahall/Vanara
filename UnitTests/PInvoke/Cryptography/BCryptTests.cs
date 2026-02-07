using NUnit.Framework;
using System.Linq;
using static Vanara.PInvoke.BCrypt;
using static Vanara.PInvoke.Kernel32;
using static Vanara.PInvoke.NCrypt;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class BCryptTests
{
	[Test]
	public void ContextTest()
	{
		const string ctx = "RSA";
		const string func = StandardAlgorithmId.BCRYPT_SHA256_ALGORITHM;
		const string propName = "Test";
		const uint propVal = 255;

		Assert.That(BCryptCreateContext(ContextConfigTable.CRYPT_LOCAL, ctx), ResultIs.Successful);

		try
		{
			Assert.That(BCryptQueryContextConfiguration(ContextConfigTable.CRYPT_LOCAL, ctx, out var ctxcfg), ResultIs.Successful);
			Assert.That((int)ctxcfg.GetValueOrDefault().dwFlags, Is.Zero);

			Assert.That(BCryptConfigureContext(ContextConfigTable.CRYPT_LOCAL, ctx, new(ContextConfigFlags.CRYPT_EXCLUSIVE)), ResultIs.Successful);

			Assert.That(BCryptQueryContextConfiguration(ContextConfigTable.CRYPT_LOCAL, ctx, out ctxcfg), ResultIs.Successful);
			Assert.That(ctxcfg.GetValueOrDefault().dwFlags, Is.EqualTo(ContextConfigFlags.CRYPT_EXCLUSIVE));

			Assert.That(BCryptAddContextFunction(ContextConfigTable.CRYPT_LOCAL, ctx, InterfaceId.BCRYPT_HASH_INTERFACE, func, CryptPriority.CRYPT_PRIORITY_TOP), ResultIs.Successful);

			string?[]? funcs = null;
			Assert.That(() => funcs = BCryptEnumContextFunctions(ContextConfigTable.CRYPT_LOCAL, ctx, InterfaceId.BCRYPT_HASH_INTERFACE), Throws.Nothing);
			Assert.That(funcs?.Length, Is.EqualTo(1));
			Assert.That(funcs![0], Is.EqualTo(func));

			Assert.That(BCryptQueryContextFunctionConfiguration(ContextConfigTable.CRYPT_LOCAL, ctx, InterfaceId.BCRYPT_HASH_INTERFACE, func, out var ctxfcfg), ResultIs.Failure);

			Assert.That(BCryptConfigureContextFunction(ContextConfigTable.CRYPT_LOCAL, ctx, InterfaceId.BCRYPT_HASH_INTERFACE, func, new CRYPT_CONTEXT_FUNCTION_CONFIG { dwFlags = ContextConfigFlags.CRYPT_EXCLUSIVE }), ResultIs.Successful);

			Assert.That(BCryptSetContextFunctionProperty(ContextConfigTable.CRYPT_LOCAL, ctx, InterfaceId.BCRYPT_HASH_INTERFACE, func, propName, sizeof(uint), BitConverter.GetBytes(propVal)), ResultIs.Successful);

			Assert.That(BCryptQueryContextFunctionProperty(ContextConfigTable.CRYPT_LOCAL, ctx, InterfaceId.BCRYPT_HASH_INTERFACE, func, propName, out var ctxfpropbuf), ResultIs.Successful);
			var propRes = ctxfpropbuf.ToStructure<uint>();
			Assert.That(propRes, Is.EqualTo(propVal));

			Assert.That(BCryptQueryContextFunctionConfiguration(ContextConfigTable.CRYPT_LOCAL, ctx, InterfaceId.BCRYPT_HASH_INTERFACE, func, out ctxfcfg), ResultIs.Successful);
			Assert.That(ctxfcfg.GetValueOrDefault().dwFlags, Is.EqualTo(ContextConfigFlags.CRYPT_EXCLUSIVE));

			Assert.That(BCryptRemoveContextFunction(ContextConfigTable.CRYPT_LOCAL, ctx, InterfaceId.BCRYPT_HASH_INTERFACE, func), ResultIs.Successful);
		}
		finally
		{
			Assert.That(BCryptDeleteContext(ContextConfigTable.CRYPT_LOCAL, ctx), ResultIs.Successful);
		}
	}

	[Test]
	public void CreateHashTest()
	{
		Assert.That(BCryptOpenAlgorithmProvider(out var hAlg, StandardAlgorithmId.BCRYPT_SHA256_ALGORITHM), ResultIs.Successful);

		var cbHashObject = hAlg.ObjectLength;
		Assert.That(cbHashObject, Is.GreaterThan(0));

		var cbHash = hAlg.HashLength;
		Assert.That(cbHash, Is.GreaterThan(0));

		var pbHashObject = new SafeHeapBlock((int)cbHashObject);
		var pbHash = new SafeHeapBlock((int)cbHash);
		Assert.That(BCryptCreateHash(hAlg, out var hHash, pbHashObject, cbHashObject), ResultIs.Successful);

		var pbDupHashObj = new SafeCoTaskMemHandle((int)cbHashObject);
		Assert.That(BCryptDuplicateHash(hHash, out var hDupHash, pbDupHashObj, cbHashObject), ResultIs.Successful);

		var rgbMsg = new byte[] { 0x61, 0x62, 0x63 };
		Assert.That(BCryptHashData(hHash, rgbMsg, (uint)rgbMsg.Length, 0), ResultIs.Successful);

		Assert.That(BCryptFinishHash(hHash, pbHash, cbHash), ResultIs.Successful);
	}

	[Test]
	public void CreateHashTest2()
	{
		Assert.That(BCryptOpenAlgorithmProvider(out SafeBCRYPT_ALG_HANDLE? hAlg, StandardAlgorithmId.BCRYPT_SHA256_ALGORITHM), ResultIs.Successful);

		var rgbMsg = new byte[] { 0x61, 0x62, 0x63 };
		Assert.That(BCryptHash(hAlg, rgbMsg, out var pbHash), ResultIs.Successful);
	}

	[Test]
	public void EncryptTest()
	{
		byte[] rgbPlaintext = "A random string to test."u8.ToArray();
		byte[] pbKey = GetRandomBytes(32);

		// Open an AES algorithm handle and set it to CBC mode
		using var hAES = SafeBCRYPT_ALG_HANDLE.OpenProvider(StandardAlgorithmId.BCRYPT_AES_ALGORITHM);
		Assert.That(hAES, ResultIs.ValidHandle);

		hAES.GenerateSymmetricKey(out var hKey, pbKey!).ThrowIfFailed();
		hAES.SetProperty(BCrypt.PropertyName.BCRYPT_CHAINING_MODE, ChainingMode.BCRYPT_CHAIN_MODE_CBC);
		hKey.Export(default, BlobType.BCRYPT_OPAQUE_KEY_BLOB, out var pbBlob).ThrowIfFailed();

		// Make an IV
		byte[] rgbIV = GetRandomBytes(hAES.GetProperty<int>(BCrypt.PropertyName.BCRYPT_BLOCK_LENGTH));

		// Encrypt the plaintext with the derived key and a cloned IV
		hKey.Encrypt(rgbPlaintext, default, (byte[])rgbIV.Clone(), out var pbCipherText, EncryptFlags.BCRYPT_BLOCK_PADDING).ThrowIfFailed();

		hAES.ImportKey(default, BlobType.BCRYPT_OPAQUE_KEY_BLOB, out var hKey2, out var pbKeyObject, pbBlob!).ThrowIfFailed();
		hKey2.Decrypt(pbCipherText!, default, rgbIV, out var pbPlainText, EncryptFlags.BCRYPT_BLOCK_PADDING).ThrowIfFailed();

		Assert.That(pbPlainText, Is.EquivalentTo(rgbPlaintext));
	}

	[Test]
	public void GenRandomTest() => Assert.That(GetRandomBytes(16).Length, Is.EqualTo(16));

	public static byte[] GetRandomBytes(int count)
	{
		using var hAlg = SafeBCRYPT_ALG_HANDLE.OpenProvider(StandardAlgorithmId.BCRYPT_RNG_ALGORITHM);
		var ret = new byte[count];
		hAlg.GenRandom(ret).ThrowIfFailed();
		return ret;
	}

	[Test]
	public void EnumTests()
	{
		var a = BCryptEnumAlgorithms((AlgOperations)0x3F);
		Assert.That(a.Length, Is.Not.Zero);
		TestContext.WriteLine("Alg: " + string.Join(", ", a.Select(s => $"{s.pszName} ({s.dwClass})")));

		var c = BCryptEnumContexts(ContextConfigTable.CRYPT_LOCAL);
		Assert.That(c.Length, Is.Not.Zero);
		TestContext.WriteLine("Ctx: " + string.Join(", ", c));
		var ctx = c[0];

		var p = BCryptEnumProviders(StandardAlgorithmId.BCRYPT_SHA256_ALGORITHM);
		Assert.That(p.Length, Is.Not.Zero);
		TestContext.WriteLine("Prov: " + string.Join(", ", p));

		var f = BCryptEnumContextFunctions(ContextConfigTable.CRYPT_LOCAL, ctx!, InterfaceId.BCRYPT_HASH_INTERFACE);
		Assert.That(p.Length, Is.Not.Zero);
		TestContext.WriteLine("Func: " + string.Join(", ", f));
		var func = f[0];

		var fp = BCryptEnumContextFunctionProviders(ContextConfigTable.CRYPT_LOCAL, ctx!, InterfaceId.BCRYPT_HASH_INTERFACE, func!);
		Assert.That(fp.Length, Is.Not.Zero);
		TestContext.WriteLine("FuncProv: " + string.Join(", ", fp));

		var r = BCryptEnumRegisteredProviders();
		Assert.That(r.Length, Is.Not.Zero);
		TestContext.WriteLine("RegProv: " + string.Join(", ", r));
	}

	[Test]
	public void SecretAgreementWithPersistedKeysTest()
	{
		const string keyName = "Sample ECDH Key";
		byte[] SecretPrependArray = [0x12, 0x34, 0x56];
		byte[] SecretAppendArray = [0xab, 0xcd, 0xef];

		// Get a handle to MS KSP
		Assert.That(NCryptOpenStorageProvider(out var ProviderHandleA, KnownStorageProvider.MS_KEY_STORAGE_PROVIDER), ResultIs.Successful);

		// Delete existing keys
		var hr = NCryptOpenKey(ProviderHandleA, out var PrivKeyHandleA, keyName);
		if (hr.Succeeded)
		{
			Assert.That(NCryptDeleteKey(PrivKeyHandleA, 0), ResultIs.Successful);
			PrivKeyHandleA.ReleaseOwnership();
		}

		// A generates a private key
		Assert.That(NCryptCreatePersistedKey(ProviderHandleA, out PrivKeyHandleA, StandardAlgorithmId.BCRYPT_ECDH_P256_ALGORITHM, keyName), ResultIs.Successful);

		// Make the key exportable
		Assert.That(NCryptSetProperty(PrivKeyHandleA, NCrypt.PropertyName.NCRYPT_EXPORT_POLICY_PROPERTY, ExportPolicy.NCRYPT_ALLOW_EXPORT_FLAG, SetPropFlags.NCRYPT_PERSIST_FLAG), ResultIs.Successful);
		Assert.That(NCryptFinalizeKey(PrivKeyHandleA), ResultIs.Successful);

		// A exports public key
		Assert.That(NCryptExportKey(PrivKeyHandleA, default, BlobType.BCRYPT_ECCPUBLIC_BLOB, out var PubBlobA), ResultIs.Successful);

		// B generates a private key
		Assert.That(BCryptOpenAlgorithmProvider(out var ExchAlgHandleB, StandardAlgorithmId.BCRYPT_ECDH_P256_ALGORITHM, KnownProvider.MS_PRIMITIVE_PROVIDER), ResultIs.Successful);

		Assert.That(BCryptGenerateKeyPair(ExchAlgHandleB, out var PrivKeyHandleB, 256), ResultIs.Successful);

		Assert.That(BCryptFinalizeKeyPair(PrivKeyHandleB), ResultIs.Successful);

		// B exports public key
		Assert.That(BCryptExportKey(PrivKeyHandleB, default, BlobType.BCRYPT_ECCPUBLIC_BLOB, pcbResult: out var PubBlobLengthB), ResultIs.Successful);

		var PubBlobB = new SafeCoTaskMemHandle((int)PubBlobLengthB);
		Assert.That(BCryptExportKey(PrivKeyHandleB, default, BlobType.BCRYPT_ECCPUBLIC_BLOB, PubBlobB, PubBlobLengthB, out PubBlobLengthB), ResultIs.Successful);

		// A imports B's public key
		Assert.That(NCryptImportKey(ProviderHandleA, default, BlobType.BCRYPT_ECCPUBLIC_BLOB, null, out var PubKeyHandleA, PubBlobB, PubBlobLengthB), ResultIs.Successful);

		// A generates the agreed secret
		Assert.That(NCryptSecretAgreement(PrivKeyHandleA, PubKeyHandleA, out var AgreedSecretHandleA), ResultIs.Successful);

		// Build KDF parameter list Specify hash algorithm, secret to append and secret to prepend
		NCryptBufferDesc ParameterList = new(
			new(KeyDerivationBufferType.KDF_HASH_ALGORITHM, StandardAlgorithmId.BCRYPT_SHA256_ALGORITHM),
			new(KeyDerivationBufferType.KDF_SECRET_PREPEND, SecretPrependArray),
			new(KeyDerivationBufferType.KDF_SECRET_APPEND, SecretAppendArray)
		);

		Assert.That(NCryptDeriveKey(AgreedSecretHandleA, KDF.BCRYPT_KDF_HMAC, ParameterList, out var AgreedSecretA, DeriveKeyFlags.KDF_USE_SECRET_AS_HMAC_KEY_FLAG), ResultIs.Successful);

		// B imports A's public key
		Assert.That(BCryptImportKeyPair(ExchAlgHandleB, default, BlobType.BCRYPT_ECCPUBLIC_BLOB, out var PubKeyHandleB, PubBlobA, PubBlobA.Size), ResultIs.Successful);

		// B generates the agreed secret
		Assert.That(BCryptSecretAgreement(PrivKeyHandleB, PubKeyHandleB, out var AgreedSecretHandleB), ResultIs.Successful);

		Assert.That(BCryptDeriveKey(AgreedSecretHandleB, KDF.BCRYPT_KDF_HMAC, ParameterList, IntPtr.Zero, 0, out var AgreedSecretLengthB, DeriveKeyFlags.KDF_USE_SECRET_AS_HMAC_KEY_FLAG), ResultIs.Successful);

		var AgreedSecretB = new SafeCoTaskMemHandle((int)AgreedSecretLengthB);
		Assert.That(BCryptDeriveKey(AgreedSecretHandleB, KDF.BCRYPT_KDF_HMAC, ParameterList, AgreedSecretB, AgreedSecretLengthB, out AgreedSecretLengthB, DeriveKeyFlags.KDF_USE_SECRET_AS_HMAC_KEY_FLAG), ResultIs.Successful);

		// At this point the AgreedSecretA should be the same as AgreedSecretB. In a real scenario, the agreed secrets on both sides will
		// probably be input to a BCryptGenerateSymmetricKey function. Optional : Compare them
		Assert.That(AgreedSecretA!.Length, Is.EqualTo(AgreedSecretLengthB));
		Assert.That(AgreedSecretA, Is.EquivalentTo(AgreedSecretB.ToEnumerable<byte>(AgreedSecretB.Size)));
	}
}