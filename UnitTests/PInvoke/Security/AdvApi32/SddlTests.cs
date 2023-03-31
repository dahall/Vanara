using NUnit.Framework;
using static Vanara.PInvoke.AdvApi32;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class SddlTests
{
	[Test]
	public void ConvertSecurityDescriptorToStringSecurityDescriptorTest()
	{
		using (new ElevPriv("SeSecurityPrivilege"))
		{
			var si = SECURITY_INFORMATION.OWNER_SECURITY_INFORMATION | SECURITY_INFORMATION.GROUP_SECURITY_INFORMATION | SECURITY_INFORMATION.DACL_SECURITY_INFORMATION | SECURITY_INFORMATION.SACL_SECURITY_INFORMATION;
			Assert.That(GetNamedSecurityInfo(TestCaseSources.SmallFile, SE_OBJECT_TYPE.SE_FILE_OBJECT, si, out _, out _, out _, out _, out var sd), ResultIs.Successful);
			string sd_sddl;
			using (sd)
			{
				Assert.That(sd_sddl = ConvertSecurityDescriptorToStringSecurityDescriptor(sd, si), Is.Not.Empty);
				TestContext.WriteLine(sd_sddl);
			}
			SafePSECURITY_DESCRIPTOR sd2;
			Assert.That(sd2 = ConvertStringSecurityDescriptorToSecurityDescriptor(sd_sddl), ResultIs.ValidHandle);
			sd2.Dispose();
		}
	}

	[Test]
	public void ConvertSidToStringSidTest()
	{
		using var psid = SafePSID.Everyone;
		string sid_sddl;
		Assert.That(sid_sddl = ConvertSidToStringSid(psid), Is.Not.Empty);
		TestContext.WriteLine(sid_sddl);

		SafePSID psid2;
		Assert.That(psid2 = ConvertStringSidToSid(sid_sddl), ResultIs.ValidHandle);
		using (psid2)
			Assert.That(psid == psid2, Is.True);
	}
}