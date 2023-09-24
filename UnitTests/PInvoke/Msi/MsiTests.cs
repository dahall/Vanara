using NUnit.Framework;
using NUnit.Framework.Internal;
using System.Collections.Generic;
using System.Linq;
using static Vanara.PInvoke.Msi;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class MsiTests
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
	public void MsiEnumProductsExTest()
	{
		var prods = MsiEnumProductsEx().ToList();
		Assert.That(prods, Is.Not.Empty);

		var value = new StringBuilder(1024);
		foreach ((string productCode, MSIINSTALLCONTEXT ctx, string sidString) in prods)
		{
			var err = GetProp(productCode, ctx, sidString, INSTALLPROPERTY.INSTALLPROPERTY_PRODUCTNAME);
			var name = err.Succeeded ? value.ToString() : err.ToString();
			err = GetProp(productCode, ctx, sidString, INSTALLPROPERTY.INSTALLPROPERTY_VERSIONSTRING);
			var ver = err.Succeeded ? value.ToString() : err.ToString();
			MsiIsProductElevated(productCode, out var elev);
			TestContext.WriteLine($"{ctx} : {name} : {ver} : Elev={elev}");
		}

		Win32Error GetProp(string productCode, MSIINSTALLCONTEXT ctx, string sidString, string prop)
		{
			value.Length = 0;
			var valueSz = (uint)value.Capacity;
			var err = MsiGetProductInfoEx(productCode, sidString, ctx, prop, value, ref valueSz);
			if (err == Win32Error.ERROR_MORE_DATA)
			{
				value.Capacity = (int)valueSz;
				err = MsiGetProductInfoEx(productCode, sidString, ctx, prop, value, ref valueSz);
			}
			return err;
		}
	}

	[Test]
	public void MsiGetPatchFileListTest()
	{
		var prodCode = MsiEnumProductsEx().First(t => GetPatches(t.productCode).Any()).productCode;
		var patches = string.Join(";", GetPatches(prodCode));
		Assert.That(MsiGetPatchFileList(prodCode, patches, out var cnt, out var recs), ResultIs.Successful);
		for (int r = 0; r < cnt; r++)
			MsiCloseHandle(recs[r]);

		static IEnumerable<string> GetPatches(string pc)
		{
			var patch = new StringBuilder(MAX_GUID_CHARS + 1);
			var txf = new StringBuilder(1024);
			var pkg = new StringBuilder(1024);
			for (uint i = 0; true; i++)
			{
				var txfSz = (uint)txf.Capacity;
				if (MsiEnumPatches(pc, i, patch, txf, ref txfSz) == Win32Error.ERROR_NO_MORE_ITEMS)
					yield break;

				pkg.Length = 0;
				var pkgSz = (uint)pkg.Capacity;
				MsiGetPatchInfo(patch.ToString(), INSTALLPROPERTY.INSTALLPROPERTY_LOCALPACKAGE, pkg, ref pkgSz);
				yield return pkg.ToString();
			}
		}
	}
}