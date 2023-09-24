using NUnit.Framework;
using System.Linq;
using static Vanara.PInvoke.AdvApi32;

namespace Vanara.PInvoke.Tests;

[TestFixture()]
public class WinCredTests
{
	public static readonly CREDENTIAL_MGD genCred = CredEnumerate().First(f => f.Type == CRED_TYPE.CRED_TYPE_GENERIC);

	[Test]
	public void CredEnumerateTest()
	{
		var a = CredEnumerate();
		TestContext.WriteLine(string.Join("\r\n", a.Select(c => $"{c.UserName} ({c.Type}) => {c.TargetName}")));
		Assert.That(a, Is.Not.Empty);
	}

	[Test]
	public void CredFindBestCredentialTest()
	{
		Assert.That(CredFindBestCredential(genCred.TargetName, genCred.Type, out var cred), ResultIs.Successful);
		Assert.That(cred.UserName, Is.EqualTo(genCred.UserName));
	}

	[Test]
	public void CredGetSessionTypesTest()
	{
		var cp = new CRED_PERSIST[(int)CRED_TYPE.CRED_TYPE_MAXIMUM];
		Assert.That(CredGetSessionTypes((uint)cp.Length, cp), ResultIs.Successful);
		cp.WriteValues();
	}

	[Test]
	public void CredGetTargetInfoTest()
	{
		// TODO: I have no idea how to get this to not return ERROR_NOT_FOUND
		//Assert.That(CredGetTargetInfo(@"https://github.com/", 0, out var mem), ResultIs.Successful);
	}

	[Test]
	public void CredMarshalCredentialTest()
	{
		const string un = "dahall@github.com";
		var utc = new USERNAME_TARGET_CREDENTIAL_INFO { UserName = un };
		Assert.That(CredMarshalCredential(utc, out var cred), ResultIs.Successful);
		Assert.That(cred, Is.Not.Null);
		TestContext.Write(cred);

		Assert.That(CredIsMarshaledCredential(cred!), Is.True);

		Assert.That(CredUnmarshalCredential(cred!, out var type, out var mem), ResultIs.Successful);
		Assert.That(type, Is.EqualTo(CRED_MARSHAL_TYPE.UsernameTargetCredential));
		Assert.That(mem.DangerousGetHandle().ToStructure<USERNAME_TARGET_CREDENTIAL_INFO>().UserName, Is.EqualTo(un));
		mem.Dispose();
	}

	[Test]
	public void CredReadTest()
	{
		Assert.That(CredRead(genCred.TargetName, genCred.Type, out var cred), ResultIs.Successful);
		Assert.That(cred.UserName, Is.EqualTo(genCred.UserName));
        }

        [Test]
        public void CredReadNegativeTest()
        {
            Assert.That(CredRead(Guid.NewGuid().ToString(), CRED_TYPE.CRED_TYPE_GENERIC, out var cred), ResultIs.Failure);
        }

        [Test]
	public void CredWriteTest()
	{
		const string targetName = "my.urn.pri";
		using var target = new SafeCoTaskMemString(targetName, CharSet.Auto);
		using var user = new SafeCoTaskMemString("dahall@github.com", CharSet.Auto);
		using var pwd = new SafeCoTaskMemString("asldfjua(#)$#$Jdf-0934390".ToSecureString(), CharSet.Auto);
		var cred = new CREDENTIAL
		{
			Type = CRED_TYPE.CRED_TYPE_GENERIC,
			Persist = CRED_PERSIST.CRED_PERSIST_LOCAL_MACHINE,
			TargetName = (IntPtr)target,
			UserName = (IntPtr)user,
			CredentialBlob = (IntPtr)pwd,
			CredentialBlobSize = pwd.Size,
		};
		Assert.That(CredWrite(cred, 0), ResultIs.Successful);

		try
		{
			//Assert.That(CredGetTargetInfo(target, 1, out var mem), ResultIs.Successful);
			const string credToProtect = targetName;
			var sb = new System.Text.StringBuilder(256);
			var sz = (uint)sb.Capacity;
			Assert.That(CredProtect(true, credToProtect, (uint)credToProtect.Length, sb, ref sz, out var type), ResultIs.Successful);
			TestContext.Write(sb);
			Assert.That(CredIsProtected(sb.ToString(), out var type2), Is.True);
			Assert.That(type, Is.EqualTo(type2));
		}
		finally
		{
			Assert.That(CredDelete(targetName, CRED_TYPE.CRED_TYPE_GENERIC), ResultIs.Successful);
		}
	}
}