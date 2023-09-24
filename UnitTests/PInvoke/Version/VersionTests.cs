using NUnit.Framework;
using NUnit.Framework.Internal;
using static Vanara.PInvoke.VersionDll;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class VersionTests
{
	[OneTimeSetUp]
	public void _Setup()
	{
	}

	[OneTimeTearDown]
	public void _TearDown()
	{
	}

	[Test]
	public void Test()
	{
		const string fn = @"c:\windows\explorer.exe";

		var sz = GetFileVersionInfoSize(fn, out _);
		Assert.NotZero(sz);
		using var mem = new SafeCoTaskMemHandle(sz);
		Assert.That(GetFileVersionInfo(fn, 0, mem.Size, mem), ResultIs.Successful);

		Assert.That(VerQueryValue(mem, "\\", out var ptr, out var ptrLen), ResultIs.Successful);
		var ffi = ptr.ToStructure<VS_FIXEDFILEINFO>(ptrLen);
		ffi.WriteValues();

		Assert.That(VerQueryValue(mem, @"\VarFileInfo\Translation", out ptr, out ptrLen), ResultIs.Successful);
		Assert.That(ptrLen, Is.GreaterThanOrEqualTo(4));
		var langcp = ptr.ToStructure<uint>(ptrLen);

		var fileVerLookup = $"\\StringFileInfo\\{Macros.LOWORD(langcp):X4}{Macros.HIWORD(langcp):X4}\\LegalCopyright";
		Assert.That(VerQueryValue(mem, fileVerLookup, out ptr, out ptrLen), ResultIs.Successful);

		TestContext.WriteLine(StringHelper.GetString(ptr, CharSet.Auto));
	}

	[Test]
	public void TestEx()
	{
		const string fn = @"c:\windows\explorer.exe";

		var sz = GetFileVersionInfoSizeEx(FILE_VER_GET.FILE_VER_GET_LOCALISED, fn, out _);
		Assert.NotZero(sz);
		using var mem = new SafeCoTaskMemHandle(sz);
		Assert.That(GetFileVersionInfoEx(FILE_VER_GET.FILE_VER_GET_LOCALISED, fn, 0, mem.Size, mem), ResultIs.Successful);

		Assert.That(VerQueryValue(mem, "\\", out var ptr, out var ptrLen), ResultIs.Successful);
		var ffi = ptr.ToStructure<VS_FIXEDFILEINFO>(ptrLen);
		ffi.WriteValues();

		Assert.That(VerQueryValue(mem, @"\VarFileInfo\Translation", out ptr, out ptrLen), ResultIs.Successful);
		Assert.That(ptrLen, Is.GreaterThanOrEqualTo(4));
		var langcp = ptr.ToStructure<uint>(ptrLen);

		var lookup = $"\\StringFileInfo\\{Macros.LOWORD(langcp):X4}{Macros.HIWORD(langcp):X4}\\";
		GetStringVal("Comments");
		GetStringVal("CompanyName");
		GetStringVal("FileDescription");
		GetStringVal("FileVersion");
		GetStringVal("InternalName");
		GetStringVal("LegalCopyright");
		GetStringVal("ProductName");
		GetStringVal("ProductVersion");

		void GetStringVal(string val)
		{
			if (VerQueryValue(mem, lookup + val, out ptr, out ptrLen))
				TestContext.WriteLine(StringHelper.GetString(ptr, CharSet.Auto));
		}
	}
}