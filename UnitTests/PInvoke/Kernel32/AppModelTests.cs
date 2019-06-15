using NUnit.Framework;
using System;
using System.Runtime.InteropServices;
using System.Text;
using Vanara.InteropServices;
using static Vanara.PInvoke.AdvApi32;
using static Vanara.PInvoke.Kernel32;

namespace Vanara.PInvoke.Tests
{
	[TestFixture]
	public class AppModelTests
	{
		public string pkgFamilyName, pkgFullName;

		//[OneTimeSetUp]
		public void _Setup()
		{
			var sb = new StringBuilder(4096);
			uint sz = (uint)sb.Capacity;
			GetCurrentPackageFamilyName(ref sz, sb).ThrowIfFailed();
			pkgFamilyName = sb.ToString();

			sb.Clear();
			sz = (uint)sb.Capacity;
			GetCurrentPackageFullName(ref sz, sb).ThrowIfFailed();
			pkgFullName = sb.ToString();
		}

		[Test]
		public void AppPolicyGetTest()
		{
			using (var hTok = SafeHTOKEN.FromProcess(GetCurrentProcess(), TokenAccess.TOKEN_ALL_ACCESS))
			{
				Assert.That(AppPolicyGetCreateFileAccess(hTok, out var fileAccess), Is.EqualTo((Win32Error)0));
				Assert.That(AppPolicyGetProcessTerminationMethod(hTok, out var termMeth), Is.EqualTo((Win32Error)0));
				Assert.That(AppPolicyGetShowDeveloperDiagnostic(hTok, out var diag), Is.EqualTo((Win32Error)0));
				Assert.That(AppPolicyGetThreadInitializationType(hTok, out var iType), Is.EqualTo((Win32Error)0));
				TestContext.WriteLine($"File:{fileAccess}; TermMeth:{termMeth}; DevDiag:{diag}; InitType:{iType}");
			}
		}

		//[Test]
		public void AppFromTokenTest()
		{
			using (var hTok = SafeHTOKEN.FromProcess(GetCurrentProcess(), TokenAccess.TOKEN_ALL_ACCESS))
			{
				var sb = new StringBuilder(1024, 1024);
				var sbSz = (uint)sb.Capacity;
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
		}

		//[Test]
		public void FindPackagesByPackageFamilyTest()
		{
			uint cnt = 0, len = 0;
			FindPackagesByPackageFamily(pkgFamilyName, PACKAGE_FLAGS.PACKAGE_INFORMATION_FULL, ref cnt, default, ref len, default, default);
			using (SafeCoTaskMemHandle pn = new SafeCoTaskMemHandle((int)cnt * IntPtr.Size), buf = new SafeCoTaskMemHandle((int)len * 2), prop = new SafeCoTaskMemHandle((int)cnt * sizeof(uint)))
			{
				Assert.That(FindPackagesByPackageFamily(pkgFamilyName, PACKAGE_FLAGS.PACKAGE_INFORMATION_FULL, ref cnt, (IntPtr)pn, ref len, (IntPtr)buf, (IntPtr)prop), Is.EqualTo((Win32Error)0));
			}
		}
	}
}