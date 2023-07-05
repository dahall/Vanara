using NUnit.Framework;
using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using Vanara.InteropServices;
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
				Assert.That(pv.Value, Is.EquivalentTo(strArr));
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

		[Test]
		public void IPropSetStorageTest()
		{
			var propSetKey = PROPERTYKEY.System.Title.Key;

			// creates a new storage object using NTFS implementation
			StgOpenStorageEx(TestCaseSources.LogFile, STGM.STGM_DIRECT | STGM.STGM_READWRITE | STGM.STGM_SHARE_EXCLUSIVE,
				STGFMT.STGFMT_ANY, default, default, default, typeof(IPropertySetStorage).GUID, out var iptr).ThrowIfFailed();
			using var istg = ComReleaserFactory.Create((IPropertySetStorage)iptr);

			var prcs = new[] { PROPERTYKEY.System.Title.Id, PROPERTYKEY.System.Author.Id, PROPERTYKEY.System.Comment.Id }.Select(propid => new PROPSPEC(propid)).ToArray();
			var vals = prcs.Select((prc, idx) => "VALUE" + idx).ToArray();

			// creates propertystorage
			istg.Item.Create(propSetKey, default, PROPSETFLAG.PROPSETFLAG_DEFAULT, STGM.STGM_CREATE | STGM.STGM_READWRITE | STGM.STGM_SHARE_EXCLUSIVE, out var ipse).ThrowIfFailed();
			using (var pipse = ComReleaserFactory.Create(ipse))
			{
				// write properties
				var prvs = vals.Select(val => new PROPVARIANT(val, VarEnum.VT_LPWSTR)).ToArray();
				try
				{
					ipse.WriteMultiple(prcs, prvs, PID_FIRST_USABLE).ThrowIfFailed();
				}
				finally
				{
					foreach (var prv in prvs)
						prv.Dispose();
				}
			}

			//hr = ipse.Commit((uint)STGC.STGC_DEFAULT);
			// read property
			istg.Item.Open(propSetKey, STGM.STGM_READ | STGM.STGM_SHARE_EXCLUSIVE, out ipse).ThrowIfFailed();
			using (var pipse = ComReleaserFactory.Create(ipse))
			{
				var prvs = new PROPVARIANT[0];
				ipse.ReadMultiple(prcs, out var prvRead).ThrowIfFailed();
			
				CollectionAssert.AreEqual(prvRead.Select(prv => prv.Value), vals);
				
				foreach (var prv in prvs)
					prv.Dispose();
			}
		}

		[Test]
		public void ContextSwitcher()
		{
			Assert.AreEqual(CLSID_ContextSwitcher, typeof(ContextSwitcher).GUID);
			IContextCallback contextCallback = new ContextSwitcher();
		}
	}
}