using NUnit.Framework;
using static Vanara.PInvoke.Secur32;

namespace Vanara.PInvoke.Tests;

[TestFixture()]
public class SaslTests
{
	[Test]
	public void SaslEnumerateProfilesTest()
	{
		Assert.That(SaslEnumerateProfiles(out var list, out var cnt), Is.EqualTo((HRESULT)0));
		Assert.That(cnt, Is.LessThan(100));
		TestContext.WriteLine($"({cnt}): " + string.Join("; ", list));
	}

	// [Test] Not on system
	public void SaslGetProfilePackageTest()
	{
		Assert.That(SaslGetProfilePackage("GSSAPI", out var pPkgInfo), Is.Zero);
		var pi = pPkgInfo.ToStructure<SecPkgInfo>();
		Assert.That((uint)pi.fCapabilities, Is.Not.Zero);
		pi.WriteValues();
	}

	[Test]
	public unsafe void SaslNonFuncTest()
	{
		Assert.That(SaslAcceptSecurityContext(null, null, null, ASC_REQ.ASC_REQ_ALLOCATE_MEMORY, DREP.SECURITY_NATIVE_DREP, out var hCtx, null, out _, out _), ResultIs.Failure);
		Assert.That(SaslGetProfilePackage(string.Empty, out _), ResultIs.Failure);
		var desc = default(SecBufferDesc);
		Assert.That(SaslIdentifyPackage(ref desc, out _), ResultIs.Failure);
		Assert.That(SaslInitializeSecurityContext(null, null, null, ASC_REQ.ASC_REQ_ALLOCATE_MEMORY, 0, DREP.SECURITY_NATIVE_DREP, null, 0, out _, null, out _, out _), ResultIs.Failure);
		Assert.That(SaslGetContextOption(hCtx, SASL_OPTION.SASL_OPTION_AUTHZ_STRING, default, 0, out _), ResultIs.Failure);
		Assert.That(SaslSetContextOption(hCtx, SASL_OPTION.SASL_OPTION_AUTHZ_STRING, "asdfasdf", 18), ResultIs.Failure);
	}

	/************************
	 * These methods cannot be tested functionally as Sasl is not supported on all systems.
	 * **********************
	SaslGetProfilePackage
	SaslAcceptSecurityContext	secur32.dll	sspi.h	Vanara.PInvoke.Secur32.SaslAcceptSecurityContext
	SaslGetContextOption	secur32.dll	sspi.h	Vanara.PInvoke.Secur32.SaslGetContextOption
	SaslIdentifyPackage	secur32.dll	sspi.h	Vanara.PInvoke.Secur32.SaslIdentifyPackage
	SaslInitializeSecurityContext	secur32.dll	sspi.h	Vanara.PInvoke.Secur32.SaslInitializeSecurityContext
	SaslSetContextOption	secur32.dll	sspi.h	Vanara.PInvoke.Secur32.SaslSetContextOption
	*/
}