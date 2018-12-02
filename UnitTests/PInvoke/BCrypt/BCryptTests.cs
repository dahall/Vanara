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

			var rgbMsg = new byte[] { 0x61, 0x62, 0x63 };
			err = BCryptHashData(hHash, rgbMsg, (uint)rgbMsg.Length, 0);
			Assert.That((uint)err, Is.EqualTo(NTStatus.STATUS_SUCCESS));

			err = BCryptFinishHash(hHash, pbHash, cbHash);
			Assert.That((uint)err, Is.EqualTo(NTStatus.STATUS_SUCCESS));
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
		public void EncryptTest()
		{
			byte[] rgbPlaintext = { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F };
			byte[] rgbIV =  { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F };
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
			err = BCryptGenerateSymmetricKey(hAlg, out var hKey, (IntPtr)pbKeyObject, cbKeyObject, rgbAES128Key, (uint)rgbAES128Key.Length, 0);
			Assert.That((uint)err, Is.EqualTo(NTStatus.STATUS_SUCCESS));

			err = BCryptExportKey(hKey, default, BlobType.BCRYPT_OPAQUE_KEY_BLOB, null, 0, out var cbBlob);
			Assert.That(cbBlob, Is.GreaterThan(0));

			var pbBlob = new SafeCoTaskMemHandle((int)cbBlob);
			err = BCryptExportKey(hKey, default, BlobType.BCRYPT_OPAQUE_KEY_BLOB, (IntPtr)pbBlob, (uint)pbBlob.Size, out cbBlob);
			Assert.That((uint)err, Is.EqualTo(NTStatus.STATUS_SUCCESS));

			var pbIV = new SafeCoTaskMemHandle((int)cbBlockLen);
			Marshal.Copy(rgbIV, 0, (IntPtr)pbIV, (int)cbBlockLen);
			err = BCryptEncrypt(hKey, rgbPlaintext, (uint)rgbPlaintext.Length, default, (IntPtr)pbIV, cbBlockLen, default, 0, out var cbCipherText, EncryptFlags.BCRYPT_BLOCK_PADDING);
			Assert.That(cbCipherText, Is.GreaterThan(0));

			var pbCipherText = new SafeCoTaskMemHandle((int)cbCipherText);
			err = BCryptEncrypt(hKey, rgbPlaintext, (uint)rgbPlaintext.Length, default, (IntPtr)pbIV, cbBlockLen, (IntPtr)pbCipherText, cbCipherText, out cbCipherText, EncryptFlags.BCRYPT_BLOCK_PADDING);
			Assert.That((uint)err, Is.EqualTo(NTStatus.STATUS_SUCCESS));

			Marshal.Copy(rgbIV, 0, (IntPtr)pbIV, (int)cbBlockLen);

			err = BCryptImportKey(hAlg, default, BlobType.BCRYPT_OPAQUE_KEY_BLOB, out var hKey2, (IntPtr)pbKeyObject, cbKeyObject, (IntPtr)pbBlob, cbBlob);
			Assert.That((uint)err, Is.EqualTo(NTStatus.STATUS_SUCCESS));

			err = BCryptDecrypt(hKey2, (IntPtr)pbCipherText, cbCipherText, default, (IntPtr)pbIV, cbBlockLen, default, 0, out var cbPlainText, EncryptFlags.BCRYPT_BLOCK_PADDING);
			Assert.That(cbPlainText, Is.GreaterThan(0));

			var pbPlainText = new SafeCoTaskMemHandle((int)cbPlainText);
			err = BCryptDecrypt(hKey2, (IntPtr)pbCipherText, cbCipherText, default, (IntPtr)pbIV, cbBlockLen, (IntPtr)pbPlainText, cbPlainText, out cbPlainText, EncryptFlags.BCRYPT_BLOCK_PADDING);
			Assert.That((uint)err, Is.EqualTo(NTStatus.STATUS_SUCCESS));

			Assert.That(pbPlainText.ToArray<byte>(rgbPlaintext.Length), Is.EquivalentTo(rgbPlaintext));
		}
	}
}