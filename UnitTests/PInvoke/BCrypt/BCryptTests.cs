using NUnit.Framework;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using Vanara.InteropServices;
using static Vanara.PInvoke.BCrypt;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests
{
	[TestFixture()]
	public class BCryptTests
	{
		[Test]
		public void ContextTest()
		{
			const string ctx = "Private";
			const string func = "SHA256";
			const string propName = "Test";
			object propVal = 255;

			var err = BCryptCreateContext(ContextConfigTable.CRYPT_LOCAL, ctx);
			Assert.That((uint)err, Is.EqualTo(NTStatus.STATUS_SUCCESS));

			try
			{
				err = BCryptQueryContextConfiguration(ContextConfigTable.CRYPT_LOCAL, ctx, out var _, out var buf);
				Assert.That((uint)err, Is.EqualTo(NTStatus.STATUS_SUCCESS));
				var ctxcfg = buf.ToStructure<CRYPT_CONTEXT_CONFIG>();
				Assert.That((int)ctxcfg.dwFlags, Is.Zero);

				err = BCryptConfigureContext(ContextConfigTable.CRYPT_LOCAL, ctx, new CRYPT_CONTEXT_CONFIG { dwFlags = ContextConfigFlags.CRYPT_EXCLUSIVE });
				Assert.That((uint)err, Is.EqualTo(NTStatus.STATUS_SUCCESS));

				err = BCryptQueryContextConfiguration(ContextConfigTable.CRYPT_LOCAL, ctx, out var _, out buf);
				Assert.That((uint)err, Is.EqualTo(NTStatus.STATUS_SUCCESS));
				ctxcfg = buf.ToStructure<CRYPT_CONTEXT_CONFIG>();
				Assert.That(ctxcfg.dwFlags, Is.EqualTo(ContextConfigFlags.CRYPT_EXCLUSIVE));

				err = BCryptAddContextFunction(ContextConfigTable.CRYPT_LOCAL, ctx, InterfaceId.BCRYPT_HASH_INTERFACE, func, CryptPriority.CRYPT_PRIORITY_TOP);
				Assert.That((uint)err, Is.EqualTo(NTStatus.STATUS_SUCCESS));

				string[] funcs = null;
				Assert.That(() => funcs = BCryptEnumContextFunctions(ContextConfigTable.CRYPT_LOCAL, ctx, InterfaceId.BCRYPT_HASH_INTERFACE), Throws.Nothing);
				Assert.That(funcs.Length, Is.EqualTo(1));
				Assert.That(funcs[0], Is.EqualTo(func));

				err = BCryptQueryContextFunctionConfiguration(ContextConfigTable.CRYPT_LOCAL, ctx, InterfaceId.BCRYPT_HASH_INTERFACE, func, out var _, out buf);
				Assert.That((uint)err, Is.EqualTo(NTStatus.STATUS_NOT_FOUND));

				err = BCryptConfigureContextFunction(ContextConfigTable.CRYPT_LOCAL, ctx, InterfaceId.BCRYPT_HASH_INTERFACE, func, new CRYPT_CONTEXT_FUNCTION_CONFIG { dwFlags = ContextConfigFlags.CRYPT_EXCLUSIVE });
				Assert.That((uint)err, Is.EqualTo(NTStatus.STATUS_SUCCESS));

				var propMem = SafeCoTaskMemHandle.CreateFromStructure(propVal);
				err = BCryptSetContextFunctionProperty(ContextConfigTable.CRYPT_LOCAL, ctx, InterfaceId.BCRYPT_HASH_INTERFACE, func, propName, (uint)propMem.Size, propMem);
				Assert.That((uint)err, Is.EqualTo(NTStatus.STATUS_SUCCESS));

				err = BCryptQueryContextFunctionProperty(ContextConfigTable.CRYPT_LOCAL, ctx, InterfaceId.BCRYPT_HASH_INTERFACE, func, propName, out var _, out buf);
				Assert.That((uint)err, Is.EqualTo(NTStatus.STATUS_SUCCESS));
				var propRes = buf.ToStructure<int>();
				Assert.That(propRes, Is.EqualTo(propVal));

				err = BCryptQueryContextFunctionConfiguration(ContextConfigTable.CRYPT_LOCAL, ctx, InterfaceId.BCRYPT_HASH_INTERFACE, func, out var _, out buf);
				Assert.That((uint)err, Is.EqualTo(NTStatus.STATUS_SUCCESS));
				var fcfg = buf.ToStructure<CRYPT_CONTEXT_FUNCTION_CONFIG>();
				Assert.That(fcfg.dwFlags, Is.EqualTo(ContextConfigFlags.CRYPT_EXCLUSIVE));

				err = BCryptRemoveContextFunction(ContextConfigTable.CRYPT_LOCAL, ctx, InterfaceId.BCRYPT_HASH_INTERFACE, func);
				Assert.That((uint)err, Is.EqualTo(NTStatus.STATUS_SUCCESS));
			}
			finally
			{
				err = BCryptDeleteContext(ContextConfigTable.CRYPT_LOCAL, ctx);
				Assert.That((uint)err, Is.EqualTo(NTStatus.STATUS_SUCCESS));
			}
		}

		[Test]
		public void CreateHashTest()
		{
			var err = BCryptOpenAlgorithmProvider(out var hAlg, StandardAlgorithmId.BCRYPT_SHA256_ALGORITHM);
			Assert.That((uint)err, Is.EqualTo(NTStatus.STATUS_SUCCESS));

			var cbHashObject = BCryptGetProperty<uint>(hAlg, PrimitivePropertyId.BCRYPT_OBJECT_LENGTH);
			Assert.That(cbHashObject, Is.GreaterThan(0));

			var cbHash = BCryptGetProperty<uint>(hAlg, PrimitivePropertyId.BCRYPT_HASH_LENGTH);
			Assert.That(cbHash, Is.GreaterThan(0));

			var pbHashObject = new SafeHeapBlock((int)cbHashObject);
			var pbHash = new SafeHeapBlock((int)cbHash);
			err = BCryptCreateHash(hAlg, out var hHash, pbHashObject, cbHashObject, SafeHeapBlock.Null, 0, 0);
			Assert.That((uint)err, Is.EqualTo(NTStatus.STATUS_SUCCESS));

			var pbDupHashObj = new SafeCoTaskMemHandle((int)cbHashObject);
			err = BCryptDuplicateHash(hHash, out var hDupHash, pbDupHashObj, cbHashObject);
			Assert.That((uint)err, Is.EqualTo(NTStatus.STATUS_SUCCESS));

			var rgbMsg = new byte[] { 0x61, 0x62, 0x63 };
			err = BCryptHashData(hHash, rgbMsg, (uint)rgbMsg.Length, 0);
			Assert.That((uint)err, Is.EqualTo(NTStatus.STATUS_SUCCESS));

			err = BCryptFinishHash(hHash, pbHash, cbHash);
			Assert.That((uint)err, Is.EqualTo(NTStatus.STATUS_SUCCESS));
		}

		[Test]
		public void EncryptTest()
		{
			byte[] rgbPlaintext = { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F };
			byte[] rgbIV = { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F };
			byte[] rgbAES128Key = { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F };

			var err = BCryptOpenAlgorithmProvider(out var hAlg, StandardAlgorithmId.BCRYPT_AES_ALGORITHM);
			Assert.That((uint)err, Is.EqualTo(NTStatus.STATUS_SUCCESS));

			var cbKeyObject = BCryptGetProperty<uint>(hAlg, PrimitivePropertyId.BCRYPT_OBJECT_LENGTH);
			Assert.That(cbKeyObject, Is.GreaterThan(0));

			var cbBlockLen = BCryptGetProperty<uint>(hAlg, PrimitivePropertyId.BCRYPT_BLOCK_LENGTH);
			Assert.That(cbBlockLen, Is.GreaterThan(0));
			Assert.That(cbBlockLen, Is.LessThanOrEqualTo(rgbIV.Length));

			var cm = System.Text.Encoding.Unicode.GetBytes(ChainingMode.BCRYPT_CHAIN_MODE_CBC);
			err = BCryptSetProperty(hAlg, PrimitivePropertyId.BCRYPT_CHAINING_MODE, cm, (uint)cm.Length);
			Assert.That((uint)err, Is.EqualTo(NTStatus.STATUS_SUCCESS));

			var pbKeyObject = new SafeCoTaskMemHandle((int)cbKeyObject);
			err = BCryptGenerateSymmetricKey(hAlg, out var hKey, pbKeyObject, cbKeyObject, rgbAES128Key, (uint)rgbAES128Key.Length, 0);
			Assert.That((uint)err, Is.EqualTo(NTStatus.STATUS_SUCCESS));

			err = BCryptExportKey(hKey, default, BlobType.BCRYPT_OPAQUE_KEY_BLOB, IntPtr.Zero, 0, out var cbBlob);
			Assert.That(cbBlob, Is.GreaterThan(0));

			var pbBlob = new SafeCoTaskMemHandle((int)cbBlob);
			err = BCryptExportKey(hKey, default, BlobType.BCRYPT_OPAQUE_KEY_BLOB, pbBlob, (uint)pbBlob.Size, out cbBlob);
			Assert.That((uint)err, Is.EqualTo(NTStatus.STATUS_SUCCESS));

			var pbIV = new SafeCoTaskMemHandle((int)cbBlockLen);
			Marshal.Copy(rgbIV, 0, (IntPtr)pbIV, (int)cbBlockLen);
			err = BCryptEncrypt(hKey, rgbPlaintext, (uint)rgbPlaintext.Length, IntPtr.Zero, pbIV, cbBlockLen, IntPtr.Zero, 0, out var cbCipherText, EncryptFlags.BCRYPT_BLOCK_PADDING);
			Assert.That(cbCipherText, Is.GreaterThan(0));

			var pbCipherText = new SafeCoTaskMemHandle((int)cbCipherText);
			err = BCryptEncrypt(hKey, rgbPlaintext, (uint)rgbPlaintext.Length, IntPtr.Zero, pbIV, cbBlockLen, pbCipherText, cbCipherText, out cbCipherText, EncryptFlags.BCRYPT_BLOCK_PADDING);
			Assert.That((uint)err, Is.EqualTo(NTStatus.STATUS_SUCCESS));

			Marshal.Copy(rgbIV, 0, (IntPtr)pbIV, (int)cbBlockLen);

			err = BCryptImportKey(hAlg, default, BlobType.BCRYPT_OPAQUE_KEY_BLOB, out var hKey2, pbKeyObject, cbKeyObject, pbBlob, cbBlob);
			Assert.That((uint)err, Is.EqualTo(NTStatus.STATUS_SUCCESS));

			err = BCryptDecrypt(hKey2, pbCipherText, cbCipherText, IntPtr.Zero, pbIV, cbBlockLen, IntPtr.Zero, 0, out var cbPlainText, EncryptFlags.BCRYPT_BLOCK_PADDING);
			Assert.That(cbPlainText, Is.GreaterThan(0));

			var pbPlainText = new SafeCoTaskMemHandle((int)cbPlainText);
			err = BCryptDecrypt(hKey2, pbCipherText, cbCipherText, IntPtr.Zero, pbIV, cbBlockLen, pbPlainText, cbPlainText, out cbPlainText, EncryptFlags.BCRYPT_BLOCK_PADDING);
			Assert.That((uint)err, Is.EqualTo(NTStatus.STATUS_SUCCESS));

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
			byte[] SecretPrependArray = { 0x12, 0x34, 0x56 };
			byte[] SecretAppendArray[] = { 0xab, 0xcd, 0xef };

			const DWORD BufferLength = 3;
			var BufferArray = new BCryptBuffer[BufferLength];

			// Get a handle to MS KSP
			var err = NCryptOpenStorageProvider(&ProviderHandleA, MS_KEY_STORAGE_PROVIDER, 0);
			Assert.That((uint)err, Is.EqualTo(NTStatus.STATUS_SUCCESS));

			// Delete existing keys
			err = NCryptOpenKey(ProviderHandleA, &PrivKeyHandleA, L"Sample ECDH Key", 0, 0);
			if (err.S)
			{
				err = NCryptDeleteKey(PrivKeyHandleA, 0);
				if (FAILED(err))
				{
					ReportError(err);
					goto cleanup;
				}
				PrivKeyHandleA = 0;
			}

			// A generates a private key

			err = NCryptCreatePersistedKey(
												ProviderHandleA,            // Provider handle
												&PrivKeyHandleA,            // Key handle - will be created
												NCRYPT_ECDH_P256_ALGORITHM, // Alg name
												L"Sample ECDH Key",         // Key name (null terminated unicode string)
												0,                          // legacy spec
												0);                         // Flags
			if (FAILED(err))
			{
				ReportError(err);
				goto cleanup;
			}

			// Make the key exportable

			KeyPolicy = NCRYPT_ALLOW_EXPORT_FLAG;

			err = NCryptSetProperty(
												PrivKeyHandleA,
												NCRYPT_EXPORT_POLICY_PROPERTY,
												(PBYTE) & KeyPolicy,
												sizeof(KeyPolicy),
												NCRYPT_PERSIST_FLAG);
			if (FAILED(err))
			{
				ReportError(err);
				goto cleanup;
			}

			err = NCryptFinalizeKey(
												PrivKeyHandleA,             // Key handle
												0);                         // Flags
			if (FAILED(err))
			{
				ReportError(err);
				goto cleanup;
			}

			// A exports public key

			err = NCryptExportKey(
												PrivKeyHandleA,             // Handle of the key to export
												NULL,                       // Handle of the key used to wrap the exported key
												BCRYPT_ECCPUBLIC_BLOB,      // Blob type (null terminated unicode string)
												NULL,                       // Parameter list
												NULL,                       // Buffer that recieves the key blob
												0,                          // Buffer length (in bytes)
												&PubBlobLengthA,            // Number of bytes copied to the buffer
												0);                         // Flags
			if (FAILED(err))
			{
				ReportError(err);
				goto cleanup;
			}

			PubBlobA = (PBYTE)HeapAlloc(
												GetProcessHeap(),
												0,
												PubBlobLengthA);
			if (NULL == PubBlobA)
			{
				err = NTE_NO_MEMORY;
				ReportError(err);
				goto cleanup;
			}

			err = NCryptExportKey(
												PrivKeyHandleA,             // Handle of the key to export
												NULL,                       // Handle of the key used to wrap the exported key
												BCRYPT_ECCPUBLIC_BLOB,      // Blob type (null terminated unicode string)
												NULL,                       // Parameter list
												PubBlobA,                   // Buffer that recieves the key blob
												PubBlobLengthA,             // Buffer length (in bytes)
												&PubBlobLengthA,            // Number of bytes copied to the buffer
												0);                         // Flags
			if (FAILED(err))
			{
				ReportError(err);
				goto cleanup;
			}

			// B generates a private key

			Status = BCryptOpenAlgorithmProvider(
												&ExchAlgHandleB,
												BCRYPT_ECDH_P256_ALGORITHM,
												MS_PRIMITIVE_PROVIDER,
												0);
			if (!NT_SUCCESS(Status))
			{
				ReportError(Status);
				err = HRESULT_FROM_NT(Status);
				goto cleanup;
			}

			Status = BCryptGenerateKeyPair(
												ExchAlgHandleB,             // Algorithm handle
												&PrivKeyHandleB,            // Key handle - will be created
												256,                        // Length of the key - in bits
												0);                         // Flags
			if (!NT_SUCCESS(Status))
			{
				ReportError(Status);
				err = HRESULT_FROM_NT(Status);
				goto cleanup;
			}

			Status = BCryptFinalizeKeyPair(
												PrivKeyHandleB,             // Key handle
												0);                         // Flags
			if (!NT_SUCCESS(Status))
			{
				ReportError(Status);
				err = HRESULT_FROM_NT(Status);
				goto cleanup;
			}

			// B exports public key

			Status = BCryptExportKey(
												PrivKeyHandleB,             // Handle of the key to export
												NULL,                       // Handle of the key used to wrap the exported key
												BCRYPT_ECCPUBLIC_BLOB,      // Blob type (null terminated unicode string)
												NULL,                       // Buffer that recieves the key blob
												0,                          // Buffer length (in bytes)
												&PubBlobLengthB,            // Number of bytes copied to the buffer
												0);                         // Flags
			if (!NT_SUCCESS(Status))
			{
				ReportError(Status);
				err = HRESULT_FROM_NT(Status);
				goto cleanup;
			}

			PubBlobB = (PBYTE)HeapAlloc(
												GetProcessHeap(),
												0,
												PubBlobLengthB);
			if (NULL == PubBlobB)
			{
				err = NTE_NO_MEMORY;
				ReportError(err);
				goto cleanup;
			}

			Status = BCryptExportKey(
												PrivKeyHandleB,             // Handle of the key to export
												NULL,                       // Handle of the key used to wrap the exported key
												BCRYPT_ECCPUBLIC_BLOB,      // Blob type (null terminated unicode string)
												PubBlobB,                   // Buffer that recieves the key blob
												PubBlobLengthB,             // Buffer length (in bytes)
												&PubBlobLengthB,            // Number of bytes copied to the buffer
												0);                         // Flags
			if (!NT_SUCCESS(Status))
			{
				ReportError(Status);
				err = HRESULT_FROM_NT(Status);
				goto cleanup;
			}

			// A imports B's public key

			err = NCryptImportKey(
												ProviderHandleA,            // Provider handle
												NULL,                       // Parameter not used
												BCRYPT_ECCPUBLIC_BLOB,      // Blob type (Null terminated unicode string)
												NULL,                       // Parameter list
												&PubKeyHandleA,             // Key handle that will be recieved
												PubBlobB,                   // Buffer than points to the key blob
												PubBlobLengthB,             // Buffer length in bytes
												0);                         // Flags
			if (FAILED(err))
			{
				ReportError(err);
				goto cleanup;
			}

			// A generates the agreed secret

			err = NCryptSecretAgreement(
												PrivKeyHandleA,             // Private key handle
												PubKeyHandleA,              // Public key handle
												&AgreedSecretHandleA,       // Handle that represents the secret agreement value
												0);
			if (FAILED(err))
			{
				ReportError(err);
				goto cleanup;
			}

			// Build KDF parameter list

			//specify hash algorithm
			BufferArray[0].BufferType = KDF_HASH_ALGORITHM;
			BufferArray[0].cbBuffer = (DWORD)((wcslen(BCRYPT_SHA256_ALGORITHM) + 1) * sizeof(WCHAR));
			BufferArray[0].pvBuffer = (PVOID)BCRYPT_SHA256_ALGORITHM;

			//specify secret to append
			BufferArray[1].BufferType = KDF_SECRET_APPEND;
			BufferArray[1].cbBuffer = sizeof(SecretAppendArray);
			BufferArray[1].pvBuffer = (PVOID)SecretAppendArray;

			//specify secret to prepend
			BufferArray[2].BufferType = KDF_SECRET_PREPEND;
			BufferArray[2].cbBuffer = sizeof(SecretPrependArray);
			BufferArray[2].pvBuffer = (PVOID)SecretPrependArray;

			ParameterList.cBuffers = 3;
			ParameterList.pBuffers = BufferArray;
			ParameterList.ulVersion = BCRYPTBUFFER_VERSION;

			err = NCryptDeriveKey(
											   AgreedSecretHandleA,         // Secret agreement handle
											   BCRYPT_KDF_HMAC,             // Key derivation function (null terminated unicode string)
											   &ParameterList,              // KDF parameters
											   NULL,                        // Buffer that recieves the derived key
											   0,                           // Length of the buffer
											   &AgreedSecretLengthA,        // Number of bytes copied to the buffer
											   KDF_USE_SECRET_AS_HMAC_KEY_FLAG);   // Flags
			if (FAILED(err))
			{
				ReportError(err);
				goto cleanup;
			}

			AgreedSecretA = (PBYTE)HeapAlloc(
												GetProcessHeap(),
												0,
												AgreedSecretLengthA);
			if (NULL == AgreedSecretA)
			{
				err = NTE_NO_MEMORY;
				ReportError(err);
				goto cleanup;
			}

			err = NCryptDeriveKey(
											   AgreedSecretHandleA,         // Secret agreement handle
											   BCRYPT_KDF_HMAC,             // Key derivation function (null terminated unicode string)
											   &ParameterList,              // KDF parameters
											   AgreedSecretA,               // Buffer that recieves the derived key
											   AgreedSecretLengthA,         // Length of the buffer
											   &AgreedSecretLengthA,        // Number of bytes copied to the buffer
											   KDF_USE_SECRET_AS_HMAC_KEY_FLAG);   // Flags
			if (FAILED(err))
			{
				ReportError(err);
				goto cleanup;
			}

			// B imports A's public key

			Status = BCryptImportKeyPair(
												ExchAlgHandleB,             // Alg handle
												NULL,                       // Parameter not used
												BCRYPT_ECCPUBLIC_BLOB,      // Blob type (Null terminated unicode string)
												&PubKeyHandleB,             // Key handle that will be recieved
												PubBlobA,                   // Buffer than points to the key blob
												PubBlobLengthA,             // Buffer length in bytes
												0);                         // Flags
			if (!NT_SUCCESS(Status))
			{
				ReportError(Status);
				err = HRESULT_FROM_NT(Status);
				goto cleanup;
			}

			// B generates the agreed secret

			Status = BCryptSecretAgreement(
												PrivKeyHandleB,             // Private key handle
												PubKeyHandleB,              // Public key handle
												&AgreedSecretHandleB,       // Handle that represents the secret agreement value
												0);
			if (!NT_SUCCESS(Status))
			{
				ReportError(Status);
				err = HRESULT_FROM_NT(Status);
				goto cleanup;
			}

			Status = BCryptDeriveKey(
											   AgreedSecretHandleB,         // Secret agreement handle
											   BCRYPT_KDF_HMAC,             // Key derivation function (null terminated unicode string)
											   &ParameterList,              // KDF parameters
											   NULL,                        // Buffer that recieves the derived key
											   0,                           // Length of the buffer
											   &AgreedSecretLengthB,        // Number of bytes copied to the buffer
											   KDF_USE_SECRET_AS_HMAC_KEY_FLAG);    // Flags
			if (!NT_SUCCESS(Status))
			{
				ReportError(Status);
				err = HRESULT_FROM_NT(Status);
				goto cleanup;
			}

			AgreedSecretB = (PBYTE)HeapAlloc(
												GetProcessHeap(),
												0,
												AgreedSecretLengthB);
			if (NULL == AgreedSecretB)
			{
				err = NTE_NO_MEMORY;
				ReportError(err);
				goto cleanup;
			}

			Status = BCryptDeriveKey(
											   AgreedSecretHandleB,         // Secret agreement handle
											   BCRYPT_KDF_HMAC,             // Key derivation function (null terminated unicode string)
											   &ParameterList,              // KDF parameters
											   AgreedSecretB,               // Buffer that recieves the derived key
											   AgreedSecretLengthB,         // Length of the buffer
											   &AgreedSecretLengthB,        // Number of bytes copied to the buffer
											   KDF_USE_SECRET_AS_HMAC_KEY_FLAG);    // Flags
			if (!NT_SUCCESS(Status))
			{
				ReportError(Status);
				err = HRESULT_FROM_NT(Status);
				goto cleanup;
			}

			// At this point the AgreedSecretA should be the same as AgreedSecretB. In a real scenario, the agreed secrets on both sides will
			// probably be input to a BCryptGenerateSymmetricKey function. Optional : Compare them

			if ((AgreedSecretLengthA != AgreedSecretLengthB) ||
				(memcmp(AgreedSecretA, AgreedSecretB, AgreedSecretLengthA))
				)
			{
				err = NTE_FAIL;
				ReportError(err);
				goto cleanup;
			}

			err = S_OK;

			wprintf(L"Success!\n");
		}
	}
}