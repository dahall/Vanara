using NUnit.Framework;
using System.IO;
using static Vanara.PInvoke.AdvApi32;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class AppModelTests
{
	public string? pkgFamilyName = "Microsoft.WindowsTerminal_8wekyb3d8bbwe", pkgFullName = "Microsoft.WindowsTerminal_1.22.12111.0_x64__8wekyb3d8bbwe", pkgAppId = "App", pkgAppExe = "WindowsTerminal.exe";

	//[OneTimeSetUp]
	//public void _Setup()
	//{
	//	FunctionHelper.CallMethodWithStrBuf((StringBuilder? sb, ref uint sz) => GetCurrentPackageFamilyName(ref sz, sb), out pkgFamilyName).ThrowIfFailed();
	//	FunctionHelper.CallMethodWithStrBuf((StringBuilder? sb, ref uint sz) => GetCurrentPackageFullName(ref sz, sb), out pkgFullName).ThrowIfFailed();
	//}

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

	[Test]
	public void AppFromTokenTest()
	{
		Assert.That(FunctionHelper.CallMethodWithStrBuf((StringBuilder? sb, ref uint sz) => GetPackagePathByFullName2(pkgFullName!, PackagePathType.PackagePathType_Effective, ref sz, sb), out var pkgPath), ResultIs.Successful);

		// Luanch the package by its path and get its process handle
		using var hProc = CreateProcess(Path.Combine(pkgPath!, pkgAppExe!));
		Assert.That(hProc, ResultIs.ValidHandle);
		Sleep(500);
		try
		{
			using SafeHTOKEN hTok = SafeHTOKEN.FromProcess(hProc, TokenAccess.TOKEN_QUERY);

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
		finally
		{
			TerminateProcess(hProc, 0);
		}
	}

	[Test]
	public void FindPackagesByPackageFamilyTest()
	{
		Assert.That(FindPackagesByPackageFamily(pkgFamilyName!, PACKAGE_FLAGS.PACKAGE_FILTER_HEAD | PACKAGE_FLAGS.PACKAGE_FILTER_DIRECT, out string?[] fullNames, out uint[] props), ResultIs.Successful);
		for (int i = 0; i < fullNames.Length; i++)
			TestContext.WriteLine($"{pkgFamilyName} = {fullNames[i]} : {props[i]}");
		Assert.That(fullNames, Is.Not.Empty);
	}

	[Test]
	public void GetPackagesByPackageFamilyTest()
	{
		Assert.That(GetPackagesByPackageFamily(pkgFamilyName!, out string?[] pkgNames), ResultIs.Successful);
		pkgNames.WriteValues();
	}

	[Test]
	public void GetPackageApplicationIdsTest()
	{
		Assert.That(OpenPackageInfoByFullName(pkgFullName!, default, out var pir), ResultIs.Successful);
		Assert.That(GetPackageApplicationIds(pir, out var buffer), ResultIs.Successful);
		buffer.WriteValues();
	}

	[Test]
	public void GetPackageInfo2Test()
	{
		Assert.That(OpenPackageInfoByFullName(pkgFullName!, default, out var pir), ResultIs.Successful);
		uint l = 0;
		Assert.That(GetPackageInfo2(pir, PACKAGE_INFORMATION.PACKAGE_INFORMATION_FULL, PackagePathType.PackagePathType_Effective, ref l, default, out var c), ResultIs.Failure);
		using SafeNativeArray<PACKAGE_INFO> vals = new((int)c) { Size = l };
		Assert.That(GetPackageInfo2(pir, PACKAGE_INFORMATION.PACKAGE_INFORMATION_FULL, PackagePathType.PackagePathType_Effective, ref l, vals, out c), ResultIs.Successful);
		foreach (var v in vals)
			v.WriteValues();
	}
}