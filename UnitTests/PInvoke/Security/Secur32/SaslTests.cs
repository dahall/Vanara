using NUnit.Framework;
using static Vanara.PInvoke.Secur32;

namespace Vanara.PInvoke.Tests
{
	[TestFixture()]
	public class SaslTests
	{
		[Test]
		public void SaslEnumerateProfilesTest()
		{
			Assert.That(SaslEnumerateProfiles(out var list, out var cnt), Is.EqualTo((HRESULT)0));
			Assert.That(cnt, Is.LessThan(100));
			TestContext.WriteLine(string.Join("; ", list));
		}

		// [Test] Not on system
		public void SaslGetProfilePackageTest()
		{
			Assert.That(SaslGetProfilePackage("GSSAPI", out var pPkgInfo), Is.Zero);
			var pi = pPkgInfo.ToStructure<SecPkgInfo>();
			Assert.That((uint)pi.fCapabilities, Is.Not.Zero);
		}

		/*
		SaslAcceptSecurityContext	secur32.dll	sspi.h	Vanara.PInvoke.Secur32.SaslAcceptSecurityContext
		SaslGetContextOption	secur32.dll	sspi.h	Vanara.PInvoke.Secur32.SaslGetContextOption
		SaslIdentifyPackage	secur32.dll	sspi.h	Vanara.PInvoke.Secur32.SaslIdentifyPackage
		SaslInitializeSecurityContext	secur32.dll	sspi.h	Vanara.PInvoke.Secur32.SaslInitializeSecurityContext
		SaslSetContextOption	secur32.dll	sspi.h	Vanara.PInvoke.Secur32.SaslSetContextOption
		*/
	}
}