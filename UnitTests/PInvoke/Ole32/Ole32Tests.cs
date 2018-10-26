using NUnit.Framework;
using System;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.PropSys;

namespace Vanara.PInvoke.Tests
{
	[TestFixture()]
	public class Ole32Tests
	{
		[Test()]
		public void CoInitializeExTest()
		{
			var hr = CoInitializeEx(IntPtr.Zero, COINIT.COINIT_APARTMENTTHREADED);
			TestContext.WriteLine(hr.ToString());
			Assert.That((int)hr, Is.EqualTo(0).Or.EqualTo(-2147417850));
			CoUninitialize();
		}

		[Test()]
		public void OleInitializeTest()
		{
			var hr = OleInitialize(IntPtr.Zero);
			TestContext.WriteLine(hr.ToString());
			Assert.That((int)hr, Is.EqualTo(0).Or.EqualTo(-2147417850));
			OleUninitialize();
		}

		[Test()]
		public void PropVariantClearTest()
		{
			var pv = new PROPVARIANT();
			InitPropVariantFromStringVector(new[] {"A", "B", "C", "D"}, 4, pv);
			Assert.That(pv.vt != VARTYPE.VT_EMPTY);
			Assert.That(PropVariantClear(pv).Succeeded);
			Assert.That(pv.vt == VARTYPE.VT_EMPTY && pv.uhVal == 0);
		}

		[Test()]
		public void PropVariantCopyTest()
		{
			using (var pv = new PROPVARIANT())
			{
				var strArr = new[] {"A", "B", "C", "D"};
				InitPropVariantFromStringVector(strArr, 4, pv);
				Assert.That(pv.vt == (VARTYPE.VT_VECTOR | VARTYPE.VT_LPWSTR));
				using (var pvc = new PROPVARIANT())
				{
					Assert.That(PropVariantCopy(pvc, pv).Succeeded);
					Assert.That(pvc.vt == (VARTYPE.VT_VECTOR | VARTYPE.VT_LPWSTR));
					Assert.That(pvc.Value, Is.EquivalentTo(strArr));
				}
			}
		}

		[Test()]
		public void ReleaseStgMediumTest()
		{
			var m = new STGMEDIUM {tymed = TYMED.TYMED_HGLOBAL, unionmember = Marshal.AllocHGlobal(16)};
			Assert.That(() => ReleaseStgMedium(m), Throws.Nothing);
		}
	}
}