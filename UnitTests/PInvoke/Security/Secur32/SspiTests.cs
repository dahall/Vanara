using NUnit.Framework;
using System;
using static Vanara.PInvoke.CredUI;
using static Vanara.PInvoke.Secur32;

namespace Vanara.PInvoke.Tests
{
	[TestFixture()]
	public class SspiTests
	{
		private const string pwd = "Pwd";
		private const string target = "Target";

		[Test]
		public void SspiExcludePackageTest()
		{
			Assert.That(SspiEncodeStringsAsAuthIdentity(Environment.UserName, Environment.UserDomainName, pwd, out var pEncAuthId), Is.EqualTo((HRESULT)0));
			Assert.That(SspiExcludePackage(pEncAuthId, NEGOSSP_NAME, out var pExcAuthId), Is.EqualTo((HRESULT)0));
			Assert.That(pExcAuthId.IsInvalid, Is.False);
		}

		[Test]
		public void SspiGetTargetHostNameTest()
		{
			Assert.That(SspiGetTargetHostName(target, out var host), Is.EqualTo((HRESULT)0));
			TestContext.WriteLine($"{host}");
			Assert.That(host, Is.Not.Null);
		}

		[Test]
		public void SspiPrepareForCredReadTest()
		{
			Assert.That(SspiEncodeStringsAsAuthIdentity(Environment.UserName, Environment.UserDomainName, pwd, out var pEncAuthId), Is.EqualTo((HRESULT)0));
			Assert.That(SspiPrepareForCredRead(pEncAuthId, target, out var cType, out var targName), Is.EqualTo((HRESULT)0));
			TestContext.WriteLine($"{cType}:{targName}");
		}

		[Test]
		public void SspiPrepareForCredWriteTest()
		{
			Assert.That(SspiEncodeStringsAsAuthIdentity(Environment.UserName, Environment.UserDomainName, pwd, out var pEncAuthId), Is.EqualTo((HRESULT)0));
			Assert.That(SspiPrepareForCredWrite(pEncAuthId, target, out var cType, out var targName, out var userName, out var blob, out var blobSize), Is.EqualTo((HRESULT)0));
			TestContext.WriteLine($"{cType}:{targName}:{userName}");
			Assert.That(blob.Length, Is.EqualTo(blobSize));
		}

		[Test, TestCaseSource(typeof(AdvApi32Tests), nameof(AdvApi32Tests.GetAuthCasesFromFile), new object[] { true, true })]
		public void SspiTest(bool validUser, bool validCred, string urn, string dn, string dc, string domain, string username, string password, string notes)
		{
			var save = false;
			Assert.That(SspiPromptForCredentials(target, new CREDUI_INFO(HWND.NULL, "Get", "Credentials"), 0, NEGOSSP_NAME, PSEC_WINNT_AUTH_IDENTITY_OPAQUE.NULL, out var pAuthId, ref save, 0), Is.EqualTo((HRESULT)0));
			Assert.That(SspiValidateAuthIdentity(pAuthId), Is.EqualTo((HRESULT)0));
			Assert.That(SspiCopyAuthIdentity(pAuthId, out var pAuthIdCopy), Is.EqualTo((HRESULT)0));
			Assert.That(SspiCompareAuthIdentities(pAuthId, pAuthIdCopy, out var sameUser, out var sameId), Is.EqualTo((HRESULT)0));
			Assert.That(sameUser && sameId, Is.True);
			pAuthIdCopy.Dispose();
			Assert.That(SspiCompareAuthIdentities(pAuthId, pAuthIdCopy, out sameUser, out sameId), Is.EqualTo((HRESULT)0));
			Assert.That(sameUser || sameId, Is.False);
			if (!SspiIsAuthIdentityEncrypted(pAuthId))
				Assert.That(SspiEncryptAuthIdentity(pAuthId), Is.EqualTo((HRESULT)0));
			Assert.That(SspiDecryptAuthIdentity(pAuthId), Is.EqualTo((HRESULT)0));
			Assert.That(SspiEncryptAuthIdentityEx(SEC_WINNT_AUTH_IDENTITY_ENCRYPT.SEC_WINNT_AUTH_IDENTITY_ENCRYPT_SAME_PROCESS, pAuthId), Is.EqualTo((HRESULT)0));
			Assert.That(SspiDecryptAuthIdentityEx(SEC_WINNT_AUTH_IDENTITY_ENCRYPT.SEC_WINNT_AUTH_IDENTITY_ENCRYPT_SAME_PROCESS, pAuthId), Is.EqualTo((HRESULT)0));
			Assert.That(SspiMarshalAuthIdentity(pAuthId, out var mLen, out var mBytes), Is.EqualTo((HRESULT)0));
			Assert.That(() => mBytes.GetBytes(mLen), Throws.Nothing);
			Assert.That(SspiUnmarshalAuthIdentity(mLen, mBytes.GetBytes(mLen), out var pMrshAuthId), Is.EqualTo((HRESULT)0));
			Assert.That(SspiCompareAuthIdentities(pAuthId, pMrshAuthId, out sameUser, out sameId), Is.EqualTo((HRESULT)0));
			Assert.That(sameUser && sameId, Is.True);
			Assert.That(SspiEncodeAuthIdentityAsStrings(pAuthId, out var retUserName, out var retDomain, out var retCreds), Is.EqualTo((HRESULT)0));
			TestContext.WriteLine($"{retDomain}:{retUserName}:{retCreds}");
		}

		[Test]
		public void SspiValidateAuthIdentityTest()
		{
			Assert.That(SspiEncodeStringsAsAuthIdentity(Environment.UserName, Environment.UserDomainName, pwd, out var pEncAuthId), Is.EqualTo((HRESULT)0));
		}
	}
}