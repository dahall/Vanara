using NUnit.Framework;
using static Vanara.PInvoke.AdvApi32;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class AppModelTests
{
	public string pkgFamilyName = "DesktopView_cw5n1h2txyewy", pkgFullName = "DesktopView_10.0.22621.1_neutral_neutral_cw5n1h2txyewy";

	//[OneTimeSetUp]
	public void _Setup()
	{
		FunctionHelper.CallMethodWithStrBuf((StringBuilder sb, ref uint sz) => GetCurrentPackageFamilyName(ref sz, sb), out pkgFamilyName).ThrowIfFailed();
		FunctionHelper.CallMethodWithStrBuf((StringBuilder sb, ref uint sz) => GetCurrentPackageFullName(ref sz, sb), out pkgFullName).ThrowIfFailed();
	}

	[Test]
	public void AppPolicyGetTest()
	{
		using SafeHTOKEN hTok = SafeHTOKEN.FromProcess(GetCurrentProcess(), TokenAccess.TOKEN_ALL_ACCESS);
		Assert.That(AppPolicyGetCreateFileAccess(hTok, out AppPolicyCreateFileAccess fileAccess), Is.EqualTo((Win32Error)0));
		Assert.That(AppPolicyGetProcessTerminationMethod(hTok, out AppPolicyProcessTerminationMethod termMeth), Is.EqualTo((Win32Error)0));
		Assert.That(AppPolicyGetShowDeveloperDiagnostic(hTok, out AppPolicyShowDeveloperDiagnostic diag), Is.EqualTo((Win32Error)0));
		Assert.That(AppPolicyGetThreadInitializationType(hTok, out AppPolicyThreadInitializationType iType), Is.EqualTo((Win32Error)0));
		TestContext.WriteLine($"File:{fileAccess}; TermMeth:{termMeth}; DevDiag:{diag}; InitType:{iType}");
	}

	//[Test]
	public void AppFromTokenTest()
	{
		using SafeHTOKEN hTok = SafeHTOKEN.FromProcess(GetCurrentProcess(), TokenAccess.TOKEN_ALL_ACCESS);
		StringBuilder sb = new(1024, 1024);
		uint sbSz = (uint)sb.Capacity;
		ResetSb();
		Assert.That(GetApplicationUserModelIdFromToken(hTok, ref sbSz, sb), Is.EqualTo((Win32Error)0));
		WriteSb("AppUserModelId");

		ResetSb();
		Assert.That(GetPackageFamilyNameFromToken(hTok, ref sbSz, sb), Is.EqualTo((Win32Error)0));
		WriteSb("PkgFamilyName");

		ResetSb();
		Assert.That(GetPackageFullNameFromToken(hTok, ref sbSz, sb), Is.EqualTo((Win32Error)0));
		WriteSb("PkgFullName");

		void ResetSb() { sb.Clear(); sbSz = (uint)sb.Capacity; }
		void WriteSb(string prefix) => TestContext.WriteLine($"{prefix}:{sb}");
	}

	[Test]
	public void FindPackagesByPackageFamilyTest()
	{
		Assert.That(FindPackagesByPackageFamily(pkgFamilyName, PACKAGE_FLAGS.PACKAGE_FILTER_HEAD | PACKAGE_FLAGS.PACKAGE_INFORMATION_BASIC, out string[] fullNames, out uint[] props), ResultIs.Successful);
		for (int i = 0; i < fullNames.Length; i++)
			TestContext.WriteLine($"{pkgFamilyName} = {fullNames[i]} : {props[i]}");
		Assert.That(fullNames, Is.Not.Empty);
	}

	[Test]
	public void GetPackagesByPackageFamilyTest()
	{
		Assert.That(GetPackagesByPackageFamily(pkgFamilyName, out string[] pkgNames), ResultIs.Successful);
		pkgNames.WriteValues();
	}

	[Test]
	public void GetPackageApplicationIdsTest()
	{
		PACKAGE_INFO_REFERENCE pir = new();
		Assert.That(OpenPackageInfoByFullName(pkgFullName, 0, ref pir), ResultIs.Successful);
		uint sz = 0;
		Assert.That(GetPackageApplicationIds(pir, ref sz, default, out _), ResultIs.FailureCode(Win32Error.ERROR_INSUFFICIENT_BUFFER));
		using SafeCoTaskMemHandle buffer = new(sz);
		Assert.That(GetPackageApplicationIds(pir, ref sz, buffer, out uint c), ResultIs.Successful);
		TestContext.WriteLine($"{pkgFullName} : {c}");
		TestContext.Write(buffer.DangerousGetHandle().ToHexDumpString(buffer.Size, showLocation: false));
	}
}