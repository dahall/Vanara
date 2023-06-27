using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Vanara.Extensions;
using Vanara.InteropServices;
using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.PropSys;
using FILETIME = System.Runtime.InteropServices.ComTypes.FILETIME;

namespace Vanara.PInvoke.Tests;

[TestFixture()]
public class PropSysTests
{
	[Test()]
	public void InitPropVariantFromBooleanVectorTest()
	{
		var pv = new PROPVARIANT();
		InitPropVariantFromBooleanVector(new[] {true,false,true,true}, 4, pv);
		Assert.That(pv.VarType, Is.EqualTo(VarEnum.VT_VECTOR | VarEnum.VT_BOOL));
		Assert.That(pv.Value as IEnumerable<bool>, Is.Not.Null.And.Exactly(4).Items);
		pv.Dispose();
	}

	[Test()]
	public void InitPropVariantFromBufferTest()
	{
		var pv = new PROPVARIANT();
		InitPropVariantFromBuffer(new byte[] {1,2,3,4}, 4, pv);
		Assert.That(pv.VarType, Is.EqualTo(VarEnum.VT_VECTOR | VarEnum.VT_UI1));
		Assert.That(pv.Value as IEnumerable<byte>, Is.Not.Null.And.Exactly(4).Items);
		pv.Dispose();
	}

	[Test()]
	public void InitPropVariantFromCLSIDTest()
	{
		var pv = new PROPVARIANT();
		var g = Guid.NewGuid();
		InitPropVariantFromCLSID(g, pv);
		Assert.That(pv.VarType, Is.EqualTo(VarEnum.VT_CLSID));
		Assert.That(pv.Value, Is.EqualTo(g));
		pv.Dispose();
	}

	[Test()]
	public void InitPropVariantFromDoubleVectorTest()
	{
		var pv = new PROPVARIANT();
		InitPropVariantFromDoubleVector(new[] {1f,2.0,255.3,0.1}, 4, pv);
		Assert.That(pv.VarType, Is.EqualTo(VarEnum.VT_VECTOR | VarEnum.VT_R8));
		Assert.That(pv.Value as IEnumerable<double>, Is.Not.Null.And.Exactly(4).Items.And.Contains(0.1));
		pv.Dispose();
	}

	[Test()]
	public void InitPropVariantFromFileTimeTest()
	{
		var pv = new PROPVARIANT();
		var ft = DateTime.Now.ToFileTimeStruct();
		InitPropVariantFromFileTime(ft, pv);
		Assert.That(pv.VarType, Is.EqualTo(VarEnum.VT_FILETIME));
		Assert.That(pv.Value, Is.EqualTo(ft));
		pv.Dispose();
	}

	[Test()]
	public void InitPropVariantFromFileTimeVectorTest()
	{
		var pv = new PROPVARIANT();
		InitPropVariantFromFileTimeVector(new[] {DateTime.Now.ToFileTimeStruct(), DateTime.Today.ToFileTimeStruct()}, 2, pv);
		Assert.That(pv.VarType, Is.EqualTo(VarEnum.VT_VECTOR | VarEnum.VT_FILETIME));
		Assert.That(pv.Value as IEnumerable<FILETIME>, Is.Not.Null.And.Exactly(2).Items);
		pv.Dispose();
	}

	[Test()]
	public void InitPropVariantFromInt16VectorTest()
	{
		var pv = new PROPVARIANT();
		InitPropVariantFromInt16Vector(new short[] {1,2,3,4}, 4, pv);
		Assert.That(pv.VarType, Is.EqualTo(VarEnum.VT_VECTOR | VarEnum.VT_I2));
		Assert.That(pv.Value as IEnumerable<short>, Is.Not.Null.And.Exactly(4).Items);
		pv.Dispose();
	}

	[Test()]
	public void InitPropVariantFromInt32VectorTest()
	{
		var pv = new PROPVARIANT();
		InitPropVariantFromInt32Vector(new int[] {1,2,3,4}, 4, pv);
		Assert.That(pv.VarType, Is.EqualTo(VarEnum.VT_VECTOR | VarEnum.VT_I4));
		Assert.That(pv.Value as IEnumerable<int>, Is.Not.Null.And.Exactly(4).Items);
		pv.Dispose();
	}

	[Test()]
	public void InitPropVariantFromInt64VectorTest()
	{
		var pv = new PROPVARIANT();
		InitPropVariantFromInt64Vector(new long[] {1,2,3,4}, 4, pv);
		Assert.That(pv.VarType, Is.EqualTo(VarEnum.VT_VECTOR | VarEnum.VT_I8));
		Assert.That(pv.Value as IEnumerable<long>, Is.Not.Null.And.Exactly(4).Items);
		pv.Dispose();
	}

	[Test()]
	public void InitPropVariantFromPropVariantVectorElemTest()
	{
		var pv = new PROPVARIANT(new[] {1,2,3,4});
		var pvc = new PROPVARIANT();
		InitPropVariantFromPropVariantVectorElem(pv, 2, pvc);
		Assert.That(pv.VarType, Is.EqualTo(VarEnum.VT_VECTOR | VarEnum.VT_I4));
		Assert.That(pvc.VarType, Is.EqualTo(VarEnum.VT_I4));
		Assert.That(pvc.Value, Is.TypeOf<int>().And.EqualTo(3));
		pv.Dispose();
		pvc.Dispose();

		pv = new PROPVARIANT(3.14f);
		pvc = new PROPVARIANT();
		InitPropVariantFromPropVariantVectorElem(pv, 0, pvc);
		Assert.That(pv.VarType, Is.EqualTo(VarEnum.VT_R4));
		Assert.That(pvc.VarType, Is.EqualTo(VarEnum.VT_R4));
		Assert.That(pvc.Value, Is.TypeOf<float>().And.EqualTo(3.14f));
		pv.Dispose();
		pvc.Dispose();
	}

	[Test()]
	public void InitPropVariantFromStringVectorTest()
	{
		using var pv = new PROPVARIANT();
		var a = new[] { "1", "2", "3", "4" };
		var c = (uint)a.Length;

		Assert.That(InitPropVariantFromStringVector(a, c, pv), ResultIs.Successful);
		Assert.That(pv.VarType, Is.EqualTo(VarEnum.VT_VECTOR | VarEnum.VT_LPWSTR));
		Assert.That(pv.Value as IEnumerable<string>, Is.EquivalentTo(a));

		Assert.That(PropVariantToStringVector(pv, out var sa), ResultIs.Successful);
		Assert.That(sa, Is.EquivalentTo(a));
	}

	[Test()]
	public void InitPropVariantFromUInt16VectorTest()
	{
		var pv = new PROPVARIANT();
		InitPropVariantFromUInt16Vector(new ushort[] {1,2,3,4}, 4, pv);
		Assert.That(pv.VarType, Is.EqualTo(VarEnum.VT_VECTOR | VarEnum.VT_UI2));
		Assert.That(pv.Value as IEnumerable<ushort>, Is.Not.Null.And.Exactly(4).Items);
		pv.Dispose();
	}

	[Test()]
	public void InitPropVariantFromUInt32VectorTest()
	{
		var pv = new PROPVARIANT();
		InitPropVariantFromUInt32Vector(new uint[] {1,2,3,4}, 4, pv);
		Assert.That(pv.VarType, Is.EqualTo(VarEnum.VT_VECTOR | VarEnum.VT_UI4));
		Assert.That(pv.Value as IEnumerable<uint>, Is.Not.Null.And.Exactly(4).Items);
		pv.Dispose();
	}

	[Test()]
	public void InitPropVariantFromUInt64VectorTest()
	{
		var pv = new PROPVARIANT();
		InitPropVariantFromUInt64Vector(new ulong[] {1,2,3,4}, 4, pv);
		Assert.That(pv.VarType, Is.EqualTo(VarEnum.VT_VECTOR | VarEnum.VT_UI8));
		Assert.That(pv.Value as IEnumerable<ulong>, Is.Not.Null.And.Exactly(4).Items);
		pv.Dispose();
	}

	[Test()]
	public void PSGetNameFromPropertyKeyTest()
	{
		var pkey = new PROPERTYKEY {fmtid = new Guid("{F29F85E0-4FF9-1068-AB91-08002B27B3D9}"), pid = 5};
		var hr = PSGetNameFromPropertyKey(pkey, out var str);
		Assert.That(hr.Succeeded);
		Assert.That(str, Is.Not.Null);
		TestContext.WriteLine(str);
	}

	[Test()]
	public void PropVariantChangeTypeTest()
	{
		var pvd = new PROPVARIANT();
		var pv = new PROPVARIANT(4);
		Assert.That(pv.VarType, Is.EqualTo(VarEnum.VT_I4));
		var hr = PropVariantChangeType(pvd, pv, PROPVAR_CHANGE_FLAGS.PVCHF_DEFAULT, VARTYPE.VT_UI8);
		Assert.That(hr.Succeeded);
		Assert.That(pvd.VarType, Is.EqualTo(VarEnum.VT_UI8));
		Assert.That(pvd.vt, Is.EqualTo(VARTYPE.VT_UI8));
		Assert.That(pvd.Value, Is.EqualTo(4L));
	}

	[Test()]
	public void PropVariantCompareTest()
	{
		var pv1 = new PROPVARIANT();
		InitPropVariantFromUInt32Vector(new uint[] {1,2,3,4}, 4, pv1);
		var pv2 = new PROPVARIANT(new uint[] {1,2,3,4});
		var i = PropVariantCompare(pv1, pv2);
		Assert.That(i, Is.EqualTo(0));
		var pv3 = new PROPVARIANT(1U);
		i = PropVariantCompare(pv1, pv3);
		Assert.That(i, Is.Not.EqualTo(0));
	}

	[Test()]
	public void PropVariantCompareExTest()
	{
		var pv1 = new PROPVARIANT();
		var pv2 = new PROPVARIANT("Test");
		var i = PropVariantCompareEx(pv1, pv2, PROPVAR_COMPARE_UNIT.PVCU_DEFAULT, PROPVAR_COMPARE_FLAGS.PVCF_TREATEMPTYASGREATERTHAN);
		Assert.That(i, Is.GreaterThan(0));
		i = PropVariantCompareEx(pv1, pv2, PROPVAR_COMPARE_UNIT.PVCU_DEFAULT, PROPVAR_COMPARE_FLAGS.PVCF_DEFAULT);
		Assert.That(i, Is.LessThan(0));
		var pv3 = new PROPVARIANT("test");
		i = PropVariantCompareEx(pv2, pv3, PROPVAR_COMPARE_UNIT.PVCU_DEFAULT, PROPVAR_COMPARE_FLAGS.PVCF_USESTRCMPI);
		Assert.That(i, Is.EqualTo(0));
	}

	[Test()]
	public void PropVariantGetElementCountTest()
	{
		var pv1 = new PROPVARIANT(1);
		var i = PropVariantGetElementCount(pv1);
		Assert.That(i, Is.EqualTo(1));
		var pv2 = new PROPVARIANT(new uint[] {1,2,3,4});
		i = PropVariantGetElementCount(pv2);
		Assert.That(i, Is.EqualTo(4));
	}

	[Test()]
	public void PropVariantToBooleanTest()
	{
		var pv1 = new PROPVARIANT(true);
		var hr = PropVariantToBoolean(pv1, out var b);
		Assert.That(hr.Succeeded);
		Assert.That(b, Is.EqualTo(true));
		var pv2 = new PROPVARIANT(1);
		hr = PropVariantToBoolean(pv1, out b);
		Assert.That(hr.Succeeded);
		Assert.That(b, Is.EqualTo(true));
	}

	[Test()]
	public void PropVariantToBooleanVectorAllocTest()
	{
		var pv = new PROPVARIANT(new[] {true, false, true, false});
		var hr = PropVariantToBooleanVectorAlloc(pv, out var h, out var cnt);
		Assert.That(hr.Succeeded);
		bool[] ba = null;
		Assert.That(() => ba = h.ToEnumerable<uint>((int)cnt).Select(i => i != 0).ToArray(), Throws.Nothing);
		Assert.That(ba, Is.Not.Null.And.Exactly(4).Items);
	}

	[Test()]
	public void PropVariantToBSTRTest()
	{
		var pv = new PROPVARIANT("Test");
		var hr = PropVariantToBSTR(pv, out var s);
		Assert.That(hr.Succeeded);
		Assert.That(pv.Value, Is.EqualTo(s));
		pv = new PROPVARIANT(1);
		hr = PropVariantToBSTR(pv, out s);
		Assert.That(hr.Succeeded);
		Assert.That(s, Is.EqualTo("1"));
		pv = new PROPVARIANT();
		hr = PropVariantToBSTR(pv, out s);
		Assert.That(hr.Succeeded);
		Assert.That(s, Is.EqualTo(""));
		pv = new PROPVARIANT(DateTime.Now, VarEnum.VT_FILETIME);
		hr = PropVariantToBSTR(pv, out s);
		Assert.That(hr.Succeeded);
		Assert.That(s, Is.Not.EqualTo(""));
		pv = new PROPVARIANT(new[] {1,2,3,4});
		hr = PropVariantToBSTR(pv, out s);
		Assert.That(hr.Succeeded);
		Assert.That(s, Is.EqualTo("1; 2; 3; 4"));
	}

	[Test()]
	public void PropVariantToBufferTest()
	{
		var pv = new PROPVARIANT(new byte[] {2,2,2,2});
		var oba = new byte[4];
		var hr = PropVariantToBuffer(pv, oba, (uint)oba.Length);
		Assert.That(hr.Succeeded);
		Assert.That(oba, Has.Exactly(4).Items.And.All.EqualTo(2));
	}

	private delegate HRESULT P2V<T>(PROPVARIANT pv, out T val);

	private static void P2VTest<T>(P2V<T> func, T v1, object v2, T o2)
	{
		var pv1 = new PROPVARIANT(v1);
		var hr = func(pv1, out var val);
		Assert.That(hr.Succeeded);
		Assert.That(val, Is.EqualTo(v1));
		var pv2 = new PROPVARIANT(v2);
		hr = func(pv2, out val);
		Assert.That(hr.Succeeded);
		Assert.That(val, Is.EqualTo(o2));
	}

	[Test()]
	public void PropVariantToDoubleTest()
	{
		P2VTest(PropVariantToDouble, 3.14, 1, 1.0);
	}

	[Test()]
	public void PropVariantToDoubleVectorAllocTest()
	{
		P2VATest(PropVariantToDoubleVectorAlloc, new double[] {2, 2, 2, 2});
	}

	[Test()]
	public void PropVariantToFileTimeTest()
	{
		var v1 = DateTime.Now.ToFileTimeStruct();
		var pv1 = new PROPVARIANT(v1);
		var hr = PropVariantToFileTime(pv1, PSTIME_FLAGS.PSTF_UTC, out var val);
		Assert.That(hr.Succeeded);
		Assert.That(val, Is.EqualTo(v1));
		var pv2 = new PROPVARIANT(DateTime.Today, VarEnum.VT_FILETIME);
		hr = PropVariantToFileTime(pv2, PSTIME_FLAGS.PSTF_UTC, out val);
		Assert.That(hr.Succeeded);
		Assert.That(val, Is.EqualTo(DateTime.Today.ToFileTimeStruct()));
	}

	[Test()]
	public void PropVariantToFileTimeVectorAllocTest()
	{
		P2VATest(PropVariantToFileTimeVectorAlloc, new FILETIME[] {DateTime.Today.ToFileTimeStruct(), DateTime.Now.ToFileTimeStruct(), new DateTime(2000, 1, 1).ToFileTimeStruct()});
	}

	[Test()]
	public void PropVariantToGUIDTest()
	{
		var v1 = Guid.NewGuid();
		var pv1 = new PROPVARIANT(v1);
		var hr = PropVariantToGUID(pv1, out var val);
		Assert.That(hr.Succeeded);
		Assert.That(val, Is.EqualTo(v1));
		var pv2 = new PROPVARIANT();
		hr = PropVariantToGUID(pv2, out val);
		Assert.That(hr.Succeeded);
		Assert.That(val, Is.EqualTo(Guid.Empty));
	}

	[Test()]
	public void PropVariantToInt16Test()
	{
		P2VTest<short>(PropVariantToInt16, 3, 1.0, 1);
	}

	[Test()]
	public void PropVariantToInt16VectorAllocTest()
	{
		P2VATest(PropVariantToInt16VectorAlloc, new short[] {2, 2, 2, 2});
	}

	private delegate HRESULT P2VA(PROPVARIANT pv, out SafeCoTaskMemHandle oba, out uint cnt);

	private static void P2VATest<T>(P2VA func, T[] arr) where T : struct
	{
		Assert.That(arr, Is.Not.Null);
		var pv = new PROPVARIANT(arr);
		var hr = func(pv, out var oba, out var cnt);
		Assert.That(hr.Succeeded);
		Assert.That(!oba.IsInvalid);
		Assert.That(arr.Length, Is.EqualTo(cnt));
		var oarr = oba.ToArray<T>((int) cnt);
		Assert.That(oarr, Is.EquivalentTo(arr));
		oba.Dispose();
		Assert.That(oba.IsInvalid && oba.IsClosed);
	}

	[Test()]
	public void PropVariantToInt32Test()
	{
		P2VTest(PropVariantToInt32, 3, 1.0, 1);
	}

	[Test()]
	public void PropVariantToInt32VectorAllocTest()
	{
		P2VATest(PropVariantToInt32VectorAlloc, new int[] {2, 2, 2, 2});
	}

	[Test()]
	public void PropVariantToInt64Test()
	{
		P2VTest<long>(PropVariantToInt64, 3, 1.0, 1);
	}

	[Test()]
	public void PropVariantToInt64VectorAllocTest()
	{
		P2VATest(PropVariantToInt64VectorAlloc, new long[] {2, 2, 2, 2});
	}

	[Test()]
	public void PropVariantToStringAllocTest()
	{
		var pv = new PROPVARIANT("Test");
		var hr = PropVariantToStringAlloc(pv, out var s);
		Assert.That(hr.Succeeded);
		Assert.That(pv.Value, Is.EqualTo((string)s));
		pv = new PROPVARIANT(1);
		hr = PropVariantToStringAlloc(pv, out s);
		Assert.That(hr.Succeeded);
		Assert.That((string)s, Is.EqualTo("1"));
		pv = new PROPVARIANT();
		hr = PropVariantToStringAlloc(pv, out s);
		Assert.That(hr.Succeeded);
		Assert.That((string)s, Is.EqualTo(""));
		pv = new PROPVARIANT(DateTime.Now, VarEnum.VT_FILETIME);
		hr = PropVariantToStringAlloc(pv, out s);
		Assert.That(hr.Succeeded);
		Assert.That((string)s, Is.Not.EqualTo(""));
		pv = new PROPVARIANT(new[] {1,2,3,4});
		hr = PropVariantToStringAlloc(pv, out s);
		Assert.That(hr.Succeeded);
		Assert.That((string)s, Is.EqualTo("1; 2; 3; 4"));
	}

	//[Test()]
	public void PropVariantToStringVectorAllocTest()
	{
		var arr = new[] {"A", "B", "C", "D"};
		Assert.That(arr, Is.Not.Null);
		var pv = new PROPVARIANT(arr);
		var hr = PropVariantToStringVectorAlloc(pv, out var oba, out var cnt);
		Assert.That(hr.Succeeded);
		Assert.That(!oba.IsInvalid);
		Assert.That(arr.Length, Is.EqualTo(cnt));
		var oarr = oba.ToEnumerable<IntPtr>((int) cnt).Select(p => { var s = Marshal.PtrToStringUni(p); Marshal.FreeCoTaskMem(p); return s; }).ToArray();
		Assert.That(oarr, Is.EquivalentTo(arr));
		oba.Dispose();
		Assert.That(oba.IsInvalid && oba.IsClosed);
	}
	
	[Test()]
	public void PropVariantToStringWithDefaultTest()
	{
		var pv = new PROPVARIANT("Test", VarEnum.VT_LPWSTR);
		var s = PropVariantToStringWithDefault(pv, null);
		Assert.That(pv.Value, Is.EqualTo(s));

		pv = new PROPVARIANT();
		s = PropVariantToStringWithDefault(pv, null);
		Assert.That(s, Is.Null);

		pv = new PROPVARIANT(new BLOB());
		s = PropVariantToStringWithDefault(pv, null);
		Assert.That(s, Is.Null);

		pv = new PROPVARIANT(1);
		s = PropVariantToStringWithDefault(pv, null);
		Assert.That(s, Is.Null);

		pv = new PROPVARIANT(new[] {1,2,3,4});
		s = PropVariantToStringWithDefault(pv, null);
		Assert.That(s, Is.Null);
	}

	[Test()]
	public void PropVariantToUInt16Test()
	{
		P2VTest<ushort>(PropVariantToUInt16, 3, 1.0, 1);
	}

	[Test()]
	public void PropVariantToUInt16VectorAllocTest()
	{
		P2VATest(PropVariantToUInt16VectorAlloc, new ushort[] {2, 2, 2, 2});
	}

	[Test()]
	public void PropVariantToUInt32Test()
	{
		P2VTest<uint>(PropVariantToUInt32, 3, 1.0, 1);
	}

	[Test()]
	public void PropVariantToUInt32VectorAllocTest()
	{
		P2VATest(PropVariantToUInt32VectorAlloc, new uint[] {2, 2, 2, 2});
	}

	[Test()]
	public void PropVariantToUInt64Test()
	{
		P2VTest<ulong>(PropVariantToUInt64, 3, 1.0, 1);
	}

	[Test()]
	public void PropVariantToUInt64VectorAllocTest()
	{
		P2VATest(PropVariantToUInt64VectorAlloc, new ulong[] {2, 2, 2, 2});
	}

	[Test()]
	public void PropVariantToVariantTest()
	{
		// TODO
	}

	[Test()]
	public void VariantToPropVariantTest()
	{
		// TODO
	}
}