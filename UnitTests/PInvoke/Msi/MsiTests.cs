using NUnit.Framework;
using NUnit.Framework.Internal;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using static Vanara.PInvoke.Msi;

namespace Vanara.PInvoke.Tests
{
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
	}
}