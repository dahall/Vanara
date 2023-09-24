using NUnit.Framework;
using System.Linq;
using static Vanara.PInvoke.BCrypt;
using static Vanara.PInvoke.Kernel32;
using static Vanara.PInvoke.NCrypt;

namespace Vanara.PInvoke.Tests;

[TestFixture()]
public class BCryptTests
{
	[Test]
	public void ContextTest()
	{
		const string ctx = "Private";
		const string func = StandardAlgorithmId.BCRYPT_SHA256_ALGORITHM;
		const string propName = "Test";
		object propVal = 255;

		var err = BCryptCreateContext(ContextConfigTable.CRYPT_LOCAL, ctx);
		Assert.That((int)err, Is.EqualTo(NTStatus.STATUS_SUCCESS));

		try
		{
			err = BCryptQueryContextConfiguration(ContextConfigTable.CRYPT_LOCAL, ctx, out var _, out var buf);
			Assert.That((int)err, Is.EqualTo(NTStatus.STATUS_SUCCESS));
			var ctxcfg = buf.ToStructure<CRYPT_CONTEXT_CONFIG>();
			Assert.That((int)ctxcfg.dwFlags, Is.Zero);

			err = BCryptConfigureContext(ContextConfigTable.CRYPT_LOCAL, ctx, new CRYPT_CONTEXT_CONFIG { dwFlags = ContextConfigFlags.CRYPT_EXCLUSIVE });
			Assert.That((int)err, Is.EqualTo(NTStatus.STATUS_SUCCESS));

			err = BCryptQueryContextConfiguration(ContextConfigTable.CRYPT_LOCAL, ctx, out var _, out buf);
			Assert.That((int)err, Is.EqualTo(NTStatus.STATUS_SUCCESS));
			ctxcfg = buf.ToStructure<CRYPT_CONTEXT_CONFIG>();
			Assert.That(ctxcfg.dwFlags, Is.EqualTo(ContextConfigFlags.CRYPT_EXCLUSIVE));

			err = BCryptAddContextFunction(ContextConfigTable.CRYPT_LOCAL, ctx, InterfaceId.BCRYPT_HASH_INTERFACE, func, CryptPriority.CRYPT_PRIORITY_TOP);
			Assert.That((int)err, Is.EqualTo(NTStatus.STATUS_SUCCESS));

			string[] funcs = null;
			Assert.That(() => funcs = BCryptEnumContextFunctions(ContextConfigTable.CRYPT_LOCAL, ctx, InterfaceId.BCRYPT_HASH_INTERFACE), Throws.Nothing);
			Assert.That(funcs.Length, Is.EqualTo(1));
			Assert.That(funcs[0], Is.EqualTo(func));

			err = BCryptQueryContextFunctionConfiguration(ContextConfigTable.CRYPT_LOCAL, ctx, InterfaceId.BCRYPT_HASH_INTERFACE, func, out var _, out buf);
			Assert.That((int)err, Is.EqualTo(NTStatus.STATUS_NOT_FOUND));

			err = BCryptConfigureContextFunction(ContextConfigTable.CRYPT_LOCAL, ctx, InterfaceId.BCRYPT_HASH_INTERFACE, func, new CRYPT_CONTEXT_FUNCTION_CONFIG { dwFlags = ContextConfigFlags.CRYPT_EXCLUSIVE });
			Assert.That((int)err, Is.EqualTo(NTStatus.STATUS_SUCCESS));

			var propMem = SafeCoTaskMemHandle.CreateFromStructure(propVal);
			err = BCryptSetContextFunctionProperty(ContextConfigTable.CRYPT_LOCAL, ctx, InterfaceId.BCRYPT_HASH_INTERFACE, func, propName, (uint)propMem.Size, propMem);
			Assert.That((int)err, Is.EqualTo(NTStatus.STATUS_SUCCESS));

			err = BCryptQueryContextFunctionProperty(ContextConfigTable.CRYPT_LOCAL, ctx, InterfaceId.BCRYPT_HASH_INTERFACE, func, propName, out var _, out buf);
			Assert.That((int)err, Is.EqualTo(NTStatus.STATUS_SUCCESS));
			var propRes = buf.ToStructure<int>();
			Assert.That(propRes, Is.EqualTo(propVal));

			err = BCryptQueryContextFunctionConfiguration(ContextConfigTable.CRYPT_LOCAL, ctx, InterfaceId.BCRYPT_HASH_INTERFACE, func, out var _, out buf);
			Assert.That((int)err, Is.EqualTo(NTStatus.STATUS_SUCCESS));
			var fcfg = buf.ToStructure<CRYPT_CONTEXT_FUNCTION_CONFIG>();
			Assert.That(fcfg.dwFlags, Is.EqualTo(ContextConfigFlags.CRYPT_EXCLUSIVE));

			err = BCryptRemoveContextFunction(ContextConfigTable.CRYPT_LOCAL, ctx, InterfaceId.BCRYPT_HASH_INTERFACE, func);
			Assert.That((int)err, Is.EqualTo(NTStatus.STATUS_SUCCESS));
		}
		finally
		{
			err = BCryptDeleteContext(ContextConfigTable.CRYPT_LOCAL, ctx);
			Assert.That((int)err, Is.EqualTo(NTStatus.STATUS_SUCCESS));
		}
	}

	[Test]
	public void CreateHashTest()
	{
		var err = BCryptOpenAlgorithmProvider(out var hAlg, StandardAlgorithmId.BCRYPT_SHA256_ALGORITHM);
		Assert.That((int)err, Is.EqualTo(NTStatus.STATUS_SUCCESS));

		var cbHashObject = BCryptGetProperty<uint>(hAlg, BCrypt.PropertyName.BCRYPT_OBJECT_LENGTH);
		Assert.That(cbHashObject, Is.GreaterThan(0));

		var cbHash = BCryptGetProperty<uint>(hAlg, BCrypt.PropertyName.BCRYPT_HASH_LENGTH);
		Assert.That(cbHash, Is.GreaterThan(0));

		var pbHashObject = new SafeHeapBlock((int)cbHashObject);
		var pbHash = new SafeHeapBlock((int)cbHash);
		err = BCryptCreateHash(hAlg, out var hHash, pbHashObject, cbHashObject);
		Assert.That((int)err, Is.EqualTo(NTStatus.STATUS_SUCCESS));

		var pbDupHashObj = new SafeCoTaskMemHandle((int)cbHashObject);
		err = BCryptDuplicateHash(hHash, out var hDupHash, pbDupHashObj, cbHashObject);
		Assert.That((int)err, Is.EqualTo(NTStatus.STATUS_SUCCESS));

		var rgbMsg = new byte[] { 0x61, 0x62, 0x63 };
		err = BCryptHashData(hHash, rgbMsg, (uint)rgbMsg.Length, 0);
		Assert.That((int)err, Is.EqualTo(NTStatus.STATUS_SUCCESS));

		err = BCryptFinishHash(hHash, pbHash, cbHash);
		Assert.That((int)err, Is.EqualTo(NTStatus.STATUS_SUCCESS));
	}

	[Test]
	public void EncryptTest()
	{
		byte[] rgbPlaintext = { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F };
		byte[] rgbIV = { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F };
		byte[] rgbAES128Key = { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F };

		var err = BCryptOpenAlgorithmProvider(out var hAlg, StandardAlgorithmId.BCRYPT_AES_ALGORITHM);
		Assert.That((int)err, Is.EqualTo(NTStatus.STATUS_SUCCESS));

		var cbKeyObject = BCryptGetProperty<uint>(hAlg, BCrypt.PropertyName.BCRYPT_OBJECT_LENGTH);
		Assert.That(cbKeyObject, Is.GreaterThan(0));

		var cbBlockLen = BCryptGetProperty<uint>(hAlg, BCrypt.PropertyName.BCRYPT_BLOCK_LENGTH);
		Assert.That(cbBlockLen, Is.GreaterThan(0));
		Assert.That(cbBlockLen, Is.LessThanOrEqualTo(rgbIV.Length));

		var cm = Encoding.Unicode.GetBytes(ChainingMode.BCRYPT_CHAIN_MODE_CBC);
		err = BCryptSetProperty(hAlg, BCrypt.PropertyName.BCRYPT_CHAINING_MODE, cm, (uint)cm.Length);
		Assert.That((int)err, Is.EqualTo(NTStatus.STATUS_SUCCESS));

		var pbKeyObject = new SafeCoTaskMemHandle((int)cbKeyObject);
		err = BCryptGenerateSymmetricKey(hAlg, out var hKey, pbKeyObject, cbKeyObject, rgbAES128Key, (uint)rgbAES128Key.Length, 0);
		Assert.That((int)err, Is.EqualTo(NTStatus.STATUS_SUCCESS));

		err = BCryptExportKey(hKey, default, BlobType.BCRYPT_OPAQUE_KEY_BLOB, IntPtr.Zero, 0, out var cbBlob);
		Assert.That(cbBlob, Is.GreaterThan(0));

		var pbBlob = new SafeCoTaskMemHandle((int)cbBlob);
		err = BCryptExportKey(hKey, default, BlobType.BCRYPT_OPAQUE_KEY_BLOB, pbBlob, (uint)pbBlob.Size, out cbBlob);
		Assert.That((int)err, Is.EqualTo(NTStatus.STATUS_SUCCESS));

		var pbIV = new SafeCoTaskMemHandle((int)cbBlockLen);
		Marshal.Copy(rgbIV, 0, (IntPtr)pbIV, (int)cbBlockLen);
		err = BCryptEncrypt(hKey, rgbPlaintext, (uint)rgbPlaintext.Length, IntPtr.Zero, pbIV, cbBlockLen, IntPtr.Zero, 0, out var cbCipherText, EncryptFlags.BCRYPT_BLOCK_PADDING);
		Assert.That(cbCipherText, Is.GreaterThan(0));

		var pbCipherText = new SafeCoTaskMemHandle((int)cbCipherText);
		err = BCryptEncrypt(hKey, rgbPlaintext, (uint)rgbPlaintext.Length, IntPtr.Zero, pbIV, cbBlockLen, pbCipherText, cbCipherText, out cbCipherText, EncryptFlags.BCRYPT_BLOCK_PADDING);
		Assert.That((int)err, Is.EqualTo(NTStatus.STATUS_SUCCESS));

		Marshal.Copy(rgbIV, 0, (IntPtr)pbIV, (int)cbBlockLen);

		err = BCryptImportKey(hAlg, default, BlobType.BCRYPT_OPAQUE_KEY_BLOB, out var hKey2, pbKeyObject, cbKeyObject, pbBlob, cbBlob);
		Assert.That((int)err, Is.EqualTo(NTStatus.STATUS_SUCCESS));

		err = BCryptDecrypt(hKey2, pbCipherText, cbCipherText, IntPtr.Zero, pbIV, cbBlockLen, IntPtr.Zero, 0, out var cbPlainText, EncryptFlags.BCRYPT_BLOCK_PADDING);
		Assert.That(cbPlainText, Is.GreaterThan(0));

		var pbPlainText = new SafeCoTaskMemHandle((int)cbPlainText);
		err = BCryptDecrypt(hKey2, pbCipherText, cbCipherText, IntPtr.Zero, pbIV, cbBlockLen, pbPlainText, cbPlainText, out cbPlainText, EncryptFlags.BCRYPT_BLOCK_PADDING);
		Assert.That((int)err, Is.EqualTo(NTStatus.STATUS_SUCCESS));

		Assert.That(pbPlainText.ToArray<byte>(rgbPlaintext.Length), Is.EquivalentTo(rgbPlaintext));
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

		var f = BCryptEnumContextFunctions(ContextConfigTable.CRYPT_LOCAL, ctx, InterfaceId.BCRYPT_HASH_INTERFACE);
		Assert.That(p.Length, Is.Not.Zero);
		TestContext.WriteLine("Func: " + string.Join(", ", f));
		var func = f[0];

		var fp = BCryptEnumContextFunctionProviders(ContextConfigTable.CRYPT_LOCAL, ctx, InterfaceId.BCRYPT_HASH_INTERFACE, func);
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
		byte[] SecretPrependArray = { 0x12, 0x34, 0x56 };
		byte[] SecretAppendArray = { 0xab, 0xcd, 0xef };

		// Get a handle to MS KSP
		var hr = NCryptOpenStorageProvider(out var ProviderHandleA, KnownStorageProvider.MS_KEY_STORAGE_PROVIDER);
		Assert.That((int)hr, Is.EqualTo(HRESULT.S_OK));

		// Delete existing keys
		hr = NCryptOpenKey(ProviderHandleA, out var PrivKeyHandleA, keyName);
		if (hr.Succeeded)
		{
			hr = NCryptDeleteKey(PrivKeyHandleA, 0);
			Assert.That((int)hr, Is.EqualTo(HRESULT.S_OK));
			PrivKeyHandleA = null;
		}

		// A generates a private key
		hr = NCryptCreatePersistedKey(ProviderHandleA, out PrivKeyHandleA, StandardAlgorithmId.BCRYPT_ECDH_P256_ALGORITHM, keyName);
		Assert.That((int)hr, Is.EqualTo(HRESULT.S_OK));

		// Make the key exportable
		var KeyPolicy = BitConverter.GetBytes((uint)ExportPolicy.NCRYPT_ALLOW_EXPORT_FLAG);
		hr = NCryptSetProperty(PrivKeyHandleA, NCrypt.PropertyName.NCRYPT_EXPORT_POLICY_PROPERTY, KeyPolicy, (uint)KeyPolicy.Length, SetPropFlags.NCRYPT_PERSIST_FLAG);
		Assert.That((int)hr, Is.EqualTo(HRESULT.S_OK));

		hr = NCryptFinalizeKey(PrivKeyHandleA);
		Assert.That((int)hr, Is.EqualTo(HRESULT.S_OK));

		// A exports public key
		hr = NCryptExportKey(PrivKeyHandleA, default, BlobType.BCRYPT_ECCPUBLIC_BLOB, pcbResult: out var PubBlobLengthA);
		Assert.That((int)hr, Is.EqualTo(HRESULT.S_OK));

		var PubBlobA = new SafeCoTaskMemHandle((int)PubBlobLengthA);
		hr = NCryptExportKey(PrivKeyHandleA, default, BlobType.BCRYPT_ECCPUBLIC_BLOB, null, PubBlobA, PubBlobLengthA, out PubBlobLengthA);
		Assert.That((int)hr, Is.EqualTo(HRESULT.S_OK));

		// B generates a private key
		var err = BCryptOpenAlgorithmProvider(out var ExchAlgHandleB, StandardAlgorithmId.BCRYPT_ECDH_P256_ALGORITHM, KnownProvider.MS_PRIMITIVE_PROVIDER);
		Assert.That((int)err, Is.EqualTo(NTStatus.STATUS_SUCCESS));

		err = BCryptGenerateKeyPair(ExchAlgHandleB, out var PrivKeyHandleB, 256);
		Assert.That((int)err, Is.EqualTo(NTStatus.STATUS_SUCCESS));

		err = BCryptFinalizeKeyPair(PrivKeyHandleB);
		Assert.That((int)err, Is.EqualTo(NTStatus.STATUS_SUCCESS));

		// B exports public key
		err = BCryptExportKey(PrivKeyHandleB, default, BlobType.BCRYPT_ECCPUBLIC_BLOB, pcbResult: out var PubBlobLengthB);
		Assert.That((int)err, Is.EqualTo(NTStatus.STATUS_SUCCESS));

		var PubBlobB = new SafeCoTaskMemHandle((int)PubBlobLengthB);
		err = BCryptExportKey(PrivKeyHandleB, default, BlobType.BCRYPT_ECCPUBLIC_BLOB, PubBlobB, PubBlobLengthB, out PubBlobLengthB);
		Assert.That((int)err, Is.EqualTo(NTStatus.STATUS_SUCCESS));

		// A imports B's public key
		hr = NCryptImportKey(ProviderHandleA, default, BlobType.BCRYPT_ECCPUBLIC_BLOB, null, out var PubKeyHandleA, PubBlobB, PubBlobLengthB);
		Assert.That((int)hr, Is.EqualTo(HRESULT.S_OK));

		// A generates the agreed secret
		hr = NCryptSecretAgreement(PrivKeyHandleA, PubKeyHandleA, out var AgreedSecretHandleA);
		Assert.That((int)hr, Is.EqualTo(HRESULT.S_OK));

		// Build KDF parameter list Specify hash algorithm, secret to append and secret to prepend
		var ParameterList = new NCryptBufferDesc
		{
			pBuffers = new[] {
			new NCryptBuffer(KeyDerivationBufferType.KDF_HASH_ALGORITHM, StandardAlgorithmId.BCRYPT_SHA256_ALGORITHM),
			new NCryptBuffer(KeyDerivationBufferType.KDF_SECRET_APPEND, SecretAppendArray),
			new NCryptBuffer(KeyDerivationBufferType.KDF_SECRET_PREPEND, SecretPrependArray) }
		};

		hr = NCryptDeriveKey(AgreedSecretHandleA, KDF.BCRYPT_KDF_HMAC, ParameterList, IntPtr.Zero, 0, out var AgreedSecretLengthA, DeriveKeyFlags.KDF_USE_SECRET_AS_HMAC_KEY_FLAG);
		Assert.That((int)hr, Is.EqualTo(HRESULT.S_OK));

		var AgreedSecretA = new SafeCoTaskMemHandle((int)AgreedSecretLengthA);
		hr = NCryptDeriveKey(AgreedSecretHandleA, KDF.BCRYPT_KDF_HMAC, ParameterList, AgreedSecretA, AgreedSecretLengthA, out AgreedSecretLengthA, DeriveKeyFlags.KDF_USE_SECRET_AS_HMAC_KEY_FLAG);
		Assert.That((int)hr, Is.EqualTo(HRESULT.S_OK));

		// B imports A's public key
		err = BCryptImportKeyPair(ExchAlgHandleB, default, BlobType.BCRYPT_ECCPUBLIC_BLOB, out var PubKeyHandleB, PubBlobA, PubBlobLengthA);
		Assert.That((int)err, Is.EqualTo(NTStatus.STATUS_SUCCESS));

		// B generates the agreed secret
		err = BCryptSecretAgreement(PrivKeyHandleB, PubKeyHandleB, out var AgreedSecretHandleB);
		Assert.That((int)err, Is.EqualTo(NTStatus.STATUS_SUCCESS));

		err = BCryptDeriveKey(AgreedSecretHandleB, KDF.BCRYPT_KDF_HMAC, ParameterList, IntPtr.Zero, 0, out var AgreedSecretLengthB, DeriveKeyFlags.KDF_USE_SECRET_AS_HMAC_KEY_FLAG);
		Assert.That((int)err, Is.EqualTo(NTStatus.STATUS_SUCCESS));

		var AgreedSecretB = new SafeCoTaskMemHandle((int)AgreedSecretLengthB);
		err = BCryptDeriveKey(AgreedSecretHandleB, KDF.BCRYPT_KDF_HMAC, ParameterList, AgreedSecretB, AgreedSecretLengthB, out AgreedSecretLengthB, DeriveKeyFlags.KDF_USE_SECRET_AS_HMAC_KEY_FLAG);
		Assert.That((int)err, Is.EqualTo(NTStatus.STATUS_SUCCESS));

		// At this point the AgreedSecretA should be the same as AgreedSecretB. In a real scenario, the agreed secrets on both sides will
		// probably be input to a BCryptGenerateSymmetricKey function. Optional : Compare them
		Assert.That(AgreedSecretLengthA, Is.EqualTo(AgreedSecretLengthB));
		Assert.That(AgreedSecretA.ToEnumerable<byte>(AgreedSecretA.Size), Is.EquivalentTo(AgreedSecretB.ToEnumerable<byte>(AgreedSecretB.Size)));
	}
}