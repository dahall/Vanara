using NUnit.Framework;
using System;
using System.Collections;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.OleAut32;
using static Vanara.PInvoke.PropSys;
using static Vanara.PInvoke.ShlwApi;

namespace Vanara.PInvoke.Tests
{
	[TestFixture]
	public class PROPVARIANTTests
	{
		[Test]
		public void CompareToTest()
		{
			var pv1 = new PROPVARIANT(1);
			var pv2 = new PROPVARIANT(1);
			var pv3 = new PROPVARIANT(5f);
			Assert.That(pv1.CompareTo(pv2), Is.EqualTo(0));
			Assert.That(pv1.CompareTo(pv3), Is.LessThan(0));
			Assert.That(pv3.CompareTo(pv1), Is.GreaterThan(0));
		}

		[Test]
		public void EqualsTest()
		{
			var pv1 = new PROPVARIANT(1);
			var pv2 = new PROPVARIANT(1);
			var pv3 = new PROPVARIANT(5f);
			Assert.That(pv1.Equals(pv2), Is.True);
			Assert.That(pv1.Equals(pv3), Is.False);
			Assert.That(pv3.Equals(pv1), Is.False);
		}

		[Test]
		public void EqualsTest1()
		{
			var pv3 = new PROPVARIANT(5f);
			Assert.That(pv3.Equals(5f), Is.False);
		}

		[Test]
		public void FromNativeVariantTest()
		{
			using (var pVar = new SafeHGlobalHandle(100))
			{
				Marshal.GetNativeVariantForObject(0xFFFFFFFF, (IntPtr)pVar);
				var pv = PROPVARIANT.FromNativeVariant((IntPtr) pVar);
				Assert.That(pv.vt, Is.EqualTo(VARTYPE.VT_UI4));
				VariantClear((IntPtr) pVar);
			}
		}

		//[Test]
		public void PROPVARIANTByRefPropsTest()
		{
			PVRefTest<bool>(true, VARTYPE.VT_BOOL, "pboolVal");
			PVRefTest<byte>(255, VARTYPE.VT_UI1, "pbVal");
			PVRefTest<sbyte>(-126, VARTYPE.VT_I1, "pcVal");
			PVRefTest<double>(345.67d, VARTYPE.VT_R8, "pdblVal");
			PVRefTest<float>(345.67f, VARTYPE.VT_R4, "pfltVal");
			PVRefTest<int>(1024, VARTYPE.VT_I4, "pintVal");
			PVRefTest<short>(1024, VARTYPE.VT_I2, "piVal");
			PVRefTest<int>(1024, VARTYPE.VT_I4, "plVal");
			PVRefTest<uint>(1024U, VARTYPE.VT_UI4, "puintVal");
			PVRefTest<ushort>(1024, VARTYPE.VT_UI2, "puiVal");
			PVRefTest<uint>(1024U, VARTYPE.VT_UI4, "pulVal");
		}

		[TestCase(true, VARTYPE.VT_BOOL, "cabool")]
		[TestCase((byte)255, VARTYPE.VT_UI1, "caub")]
		[TestCase((sbyte)-126, VARTYPE.VT_I1, "cac")]
		[TestCase(345.67d, VARTYPE.VT_R8, "cadbl")]
		[TestCase(345.67f, VARTYPE.VT_R4, "caflt")]
		[TestCase(1024L, VARTYPE.VT_I8, "cah")]
		[TestCase((short)1024, VARTYPE.VT_I2, "cai")]
		[TestCase(1024, VARTYPE.VT_I4, "cal")]
		[TestCase(1024UL, VARTYPE.VT_UI8, "cauh")]
		[TestCase((ushort)1024, VARTYPE.VT_UI2, "caui")]
		[TestCase(1024U, VARTYPE.VT_UI4, "caul")]
		public void PROPVARIANTEnumPropsTest(object value, VARTYPE vt, string prop)
		{
			const int len = 5;
			var arr = Array.CreateInstance(value.GetType(), len);
			for (var i = 0; i < len; i++)
				arr.SetValue(value, i);
			using (var pv = new PROPVARIANT(arr))
			{
				Assert.That(pv.vt, Is.EqualTo(vt | VARTYPE.VT_VECTOR));
				Assert.That(pv.Value, Is.EquivalentTo(arr));
				var pi = pv.GetType().GetProperty(prop);
				Assert.That(pi, Is.Not.Null);
				Assert.That(pi.GetValue(pv), Is.EquivalentTo(arr));
			}
		}

		[TestCase(VARTYPE.VT_CF, "pclipdata")]
		[TestCase(VARTYPE.VT_ARRAY | VARTYPE.VT_VARIANT, "parray")]
		[TestCase(VARTYPE.VT_BLOB, "blob")]
		[TestCase(VARTYPE.VT_BSTR, "bstrVal")]
		[TestCase(VARTYPE.VT_BYREF | VARTYPE.VT_BSTR, "pbstrVal")]
		[TestCase(VARTYPE.VT_BYREF | VARTYPE.VT_CY, "pcyVal")]
		[TestCase(VARTYPE.VT_BYREF | VARTYPE.VT_DATE, "pdate")]
		[TestCase(VARTYPE.VT_BYREF | VARTYPE.VT_DECIMAL, "pdecVal")]
		[TestCase(VARTYPE.VT_BYREF | VARTYPE.VT_DISPATCH, "ppdispVal")]
		[TestCase(VARTYPE.VT_BYREF | VARTYPE.VT_ERROR, "pscode")]
		[TestCase(VARTYPE.VT_BYREF | VARTYPE.VT_UNKNOWN, "ppunkVal")]
		[TestCase(VARTYPE.VT_BYREF | VARTYPE.VT_VARIANT, "pvarVal")]
		[TestCase(VARTYPE.VT_CY, "cyVal")]
		[TestCase(VARTYPE.VT_CLSID, "puuid")]
		[TestCase(VARTYPE.VT_DATE, "date")]
		[TestCase(VARTYPE.VT_DISPATCH, "pdispVal")]
		[TestCase(VARTYPE.VT_ERROR, "scode")]
		[TestCase(VARTYPE.VT_FILETIME, "filetime")]
		[TestCase(VARTYPE.VT_LPSTR, "pszVal")]
		[TestCase(VARTYPE.VT_LPWSTR, "pwszVal")]
		[TestCase(VARTYPE.VT_STORAGE, "pStorage")]
		[TestCase(VARTYPE.VT_STREAM, "pStream")]
		[TestCase(VARTYPE.VT_UNKNOWN, "punkVal")]
		[TestCase(VARTYPE.VT_VECTOR | VARTYPE.VT_CF, "caclipdata")]
		[TestCase(VARTYPE.VT_VECTOR | VARTYPE.VT_CLSID, "cauuid")]
		[TestCase(VARTYPE.VT_VECTOR | VARTYPE.VT_CY, "cacy")]
		[TestCase(VARTYPE.VT_VECTOR | VARTYPE.VT_DATE, "cadate")]
		[TestCase(VARTYPE.VT_VECTOR | VARTYPE.VT_ERROR, "cascode")]
		[TestCase(VARTYPE.VT_VECTOR | VARTYPE.VT_FILETIME, "cafiletime")]
		[TestCase(VARTYPE.VT_VECTOR | VARTYPE.VT_LPWSTR, "calpwstr")]
		[TestCase(VARTYPE.VT_VECTOR | VARTYPE.VT_VARIANT, "capropvar")]
		[TestCase(VARTYPE.VT_VERSIONED_STREAM, "pVersionedStream")]
		[TestCase(VARTYPE.VT_VECTOR | VARTYPE.VT_BSTR, "cabstr")]
		[TestCase(VARTYPE.VT_VECTOR | VARTYPE.VT_LPSTR, "calpstr")]
		public void PROPVARIANTOtherPropsTest(VARTYPE vt, string prop)
		{
			object value;
			Assert.That(() =>
			{
				if ((value = GetSampleData(vt)) == null) return;
				using (var pv = new PROPVARIANT(value, (VarEnum)vt))
				{
					var isa = value.GetType().IsArray;
					Assert.That(pv.vt, Is.EqualTo(vt));
					var pvVal = pv.Value;
					if (isa)
						Assert.That(pvVal, Is.EquivalentTo((IEnumerable)value));
					else
						Assert.That(pvVal, Is.EqualTo(value));
					var pi = pv.GetType().GetProperty(prop);
					Assert.That(pi, Is.Not.Null);
					var	piVal = pi.GetValue(pv);
					if (isa)
						Assert.That(piVal, Is.EquivalentTo((IEnumerable)value));
					else
						Assert.That(piVal, Is.EqualTo(value));
				}
			}, Throws.Nothing);
		}

		[TestCase(true, VARTYPE.VT_BOOL, "boolVal")]
		[TestCase((byte)255, VARTYPE.VT_UI1, "bVal")]
		[TestCase((sbyte)-126, VARTYPE.VT_I1, "cVal")]
		[TestCase(345.67d, VARTYPE.VT_R8, "dblVal")]
		[TestCase(345.67f, VARTYPE.VT_R4, "fltVal")]
		[TestCase(1024L, VARTYPE.VT_I8, "hVal")]
		[TestCase(1024, VARTYPE.VT_I4, "intVal")]
		[TestCase((short)1024, VARTYPE.VT_I2, "iVal")]
		[TestCase(1024, VARTYPE.VT_I4, "lVal")]
		[TestCase(1024UL, VARTYPE.VT_UI8, "uhVal")]
		[TestCase(1024U, VARTYPE.VT_UI4, "uintVal")]
		[TestCase((ushort)1024, VARTYPE.VT_UI2, "uiVal")]
		[TestCase(1024U, VARTYPE.VT_UI4, "ulVal")]
		public void PROPVARIANTPropsTest(object value, VARTYPE vt, string prop)
		{
			using (var pv = new PROPVARIANT(value))
			{
				Assert.That(pv.vt, Is.EqualTo(vt));
				Assert.That(pv.Value, Is.EqualTo(value));
				var pi = pv.GetType().GetProperty(prop);
				Assert.That(pi, Is.Not.Null);
				Assert.That(pi.GetValue(pv), Is.EqualTo(value));
			}
		}

		[Test]
		public void PROPVARIANTTest()
		{
			using (var pv = new PROPVARIANT())
				Assert.That(pv.vt, Is.EqualTo(VARTYPE.VT_EMPTY));
		}

		[Test]
		public void PROPVARIANTTest1()
		{
			var arr = new[] { "A", "B", "C" };
			using (var pv = new PROPVARIANT(arr))
			using (var pv2 = new PROPVARIANT(pv))
				Assert.That(pv2.Value, Is.EquivalentTo(arr).And.EquivalentTo(pv.Value as IEnumerable));
		}

		[Test]
		public void ToStringTest()
		{
			Assert.That(new PROPVARIANT((byte)255).ToString(), Is.EqualTo("VT_UI1=255"));
			Assert.That(new PROPVARIANT().ToString(), Is.EqualTo("VT_EMPTY="));
			Assert.That(new PROPVARIANT("Test").ToString(), Is.EqualTo("VT_LPWSTR=Test"));
			Assert.That(new PROPVARIANT(DBNull.Value).ToString(), Is.EqualTo("VT_NULL="));
			Assert.That(new PROPVARIANT(new byte[] {255,1,15,0}).ToString(), Is.EqualTo("VT_UI1, VT_VECTOR=255,1,15,0"));
		}

		/*public void GetCF()
		{
			foreach (var f in Directory.EnumerateFiles(TestCaseSources.TempDir, "*.*", SearchOption.AllDirectories))
			{
				try
				{
					SHGetPropertyStoreFromParsingName(f, null, GETPROPERTYSTOREFLAGS.GPS_READWRITE,
						Marshal.GenerateGuidForType(typeof(IPropertyStore)), out var ps);
					if (ps == null) continue;
					using (var pv = new PROPVARIANT())
					{
						ps.GetValue(PROPERTYKEY.System.Thumbnail, pv);
						if (pv.IsNullOrEmpty) continue;
						if (pv.vt == VARTYPE.VT_CF)
							TestContext.WriteLine(f);
					}
					ps = null;
				}
				catch
				{
				}
			}
		}*/

		private static object GetSampleData(VARTYPE vt)
		{
			switch (vt)
			{
				case VARTYPE.VT_ARRAY | VARTYPE.VT_VARIANT:
					return new object[] { 100, "100" };
				case VARTYPE.VT_BLOB:
					return new BLOB { cbSize = 200, pBlobData = Marshal.AllocCoTaskMem(200) };
				case VARTYPE.VT_CY:
				case VARTYPE.VT_BYREF | VARTYPE.VT_CY:
				case VARTYPE.VT_BYREF | VARTYPE.VT_DECIMAL:
					return 12345.6789M;
				case VARTYPE.VT_BYREF | VARTYPE.VT_VARIANT:
					return null;
				case VARTYPE.VT_CF:
					return new CLIPDATA("MYCUSTOMFMT");
				case VARTYPE.VT_CLSID:
					return Guid.NewGuid();
				case VARTYPE.VT_DATE:
				case VARTYPE.VT_BYREF | VARTYPE.VT_DATE:
					return new DateTime(1999, 12, 31, 23, 59, 59);
				case VARTYPE.VT_DISPATCH:
					return Activator.CreateInstance(Type.GetTypeFromProgID("Excel.Application"));
				case VARTYPE.VT_ERROR:
				case VARTYPE.VT_BYREF | VARTYPE.VT_ERROR:
					return new Win32Error(5);
				case VARTYPE.VT_FILETIME:
					return new DateTime(1999, 12, 31, 23, 59, 59).ToFileTimeStruct();
				case VARTYPE.VT_BYREF | VARTYPE.VT_BSTR:
					return Marshal.StringToBSTR("string");
				case VARTYPE.VT_BSTR:
				case VARTYPE.VT_LPSTR:
				case VARTYPE.VT_LPWSTR:
					return "string";
				case VARTYPE.VT_STORAGE:
					StgCreateStorageEx(Path.GetTempFileName(), STGM.STGM_DELETEONRELEASE | STGM.STGM_CREATE | STGM.STGM_DIRECT | STGM.STGM_READWRITE | STGM.STGM_SHARE_EXCLUSIVE, STGFMT.STGFMT_DOCFILE, 0, IntPtr.Zero, IntPtr.Zero, typeof(IStorage).GUID, out var iptr);
					return (IStorage)iptr;
				case VARTYPE.VT_STREAM:
					SHCreateStreamOnFileEx(TestCaseSources.SmallFile, STGM.STGM_READ | STGM.STGM_SHARE_EXCLUSIVE, 0, false, null, out var stm);
					return stm;
				case VARTYPE.VT_UNKNOWN:
					return Activator.CreateInstance(Type.GetTypeFromProgID("ADODB.Error"));
				case VARTYPE.VT_VECTOR | VARTYPE.VT_BSTR:
				case VARTYPE.VT_VECTOR | VARTYPE.VT_LPSTR:
				case VARTYPE.VT_VECTOR | VARTYPE.VT_LPWSTR:
					return new[] { "A", "B", "C" };
				case VARTYPE.VT_VECTOR | VARTYPE.VT_CF:
					return new[] { new CLIPDATA(), new CLIPDATA() };
				case VARTYPE.VT_VECTOR | VARTYPE.VT_CLSID:
					return new[] { Guid.NewGuid(), Guid.NewGuid() };
				case VARTYPE.VT_VECTOR | VARTYPE.VT_CY:
					return new[] { 12345.6789M, 98765.4321M };
				case VARTYPE.VT_VECTOR | VARTYPE.VT_DATE:
					return new[] { new DateTime(1999, 12, 31, 23, 59, 59), new DateTime(2000, 1, 1, 0, 0, 1) };
				case VARTYPE.VT_VECTOR | VARTYPE.VT_ERROR:
					return new[] { new Win32Error(1), new Win32Error(5) };
				case VARTYPE.VT_VECTOR | VARTYPE.VT_FILETIME:
					return new[] { new DateTime(1999, 12, 31, 23, 59, 59).ToFileTimeStruct(), new DateTime(2000, 1, 1, 0, 0, 1).ToFileTimeStruct() };
				case VARTYPE.VT_VECTOR | VARTYPE.VT_VARIANT:
					return new[] { new PROPVARIANT(100), new PROPVARIANT(200) };
				case VARTYPE.VT_VERSIONED_STREAM:
					return null;
				default:
					return null;
			}
		}

		private static void PVRefTest<T>(T? nval, VARTYPE vt, string prop) where T : struct
		{
			var pi = typeof(PROPVARIANT).GetProperty(prop);
			Assert.That(pi, Is.Not.Null);
			using (var pv = new PROPVARIANT(null, (VarEnum)(VARTYPE.VT_BYREF | vt)))
			{
				Assert.That(pv.vt, Is.EqualTo(vt | VARTYPE.VT_BYREF));
				Assert.That(pv.Value, Is.Null);
				Assert.That(pi.GetValue(pv), Is.Null);
			}
		}
	}
}