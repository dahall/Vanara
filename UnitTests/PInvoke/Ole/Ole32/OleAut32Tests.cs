using NUnit.Framework;
using static Vanara.PInvoke.Ole32;
using static Vanara.PInvoke.OleAut32;

namespace Vanara.PInvoke.Tests;

[TestFixture]
public class OleAut32Tests
{
	[Test]
	public void SafeArrayAccessDataTest()
	{
		using (var psa = SafeArrayCreateVector(VARTYPE.VT_I8, 0, 5))
		{
			Assert.That(SafeArrayAccessData(psa, out var pData).Succeeded);
			Assert.That(pData, Is.Not.EqualTo(IntPtr.Zero));
			Assert.That(SafeArrayUnaccessData(psa).Succeeded);
			using (var d = new SafeArrayScopedAccessData(psa))
				Assert.That(d.Data, Is.Not.EqualTo(IntPtr.Zero));
		}
	}

	[Test]
	public void SafeArrayCreateTest()
	{
		using (var psa = SafeArrayCreate(VARTYPE.VT_I8, 1, new[] { new SAFEARRAYBOUND(4, 0) }))
			SafeArrayMethodTest<long>(psa, 5);
	}

	private static void SafeArrayMethodTest<T>(SafeSAFEARRAY psa, int count)
	{
		Assert.That(psa, Is.Not.EqualTo(IntPtr.Zero));
		Assert.That(SafeArrayGetDim(psa), Is.EqualTo(1));
		Assert.That(SafeArrayGetElemsize(psa), Is.EqualTo(Marshal.SizeOf(typeof(T))));
		Assert.That(SafeArrayGetLBound(psa, 1, out var b).Succeeded);
		Assert.That(b, Is.EqualTo(0));
		Assert.That(SafeArrayGetUBound(psa, 1, out var u).Succeeded);
		Assert.That(u, Is.EqualTo(count - 1));
	}

	[Test]
	public void SafeArrayCreateExTest()
	{
		using (var psa = SafeArrayCreateEx(VARTYPE.VT_I8, 1, new[] { new SAFEARRAYBOUND(4, 0) }, IntPtr.Zero))
			SafeArrayMethodTest<long>(psa, 5);
	}

	[Test]
	public void SafeArrayCreateVectorTest()
	{
		using (var psa = SafeArrayCreateVector(VARTYPE.VT_I8, 0, 5))
			SafeArrayMethodTest<long>(psa, 5);
	}

	[Test]
	public void SafeArrayGetPutElementTest()
	{
		using (var psa = SafeArrayCreateVector(VARTYPE.VT_I4, 0, 5))
		{
			for (var i = 0; i < 5; i++)
			{
				var p = SafeCoTaskMemHandle.CreateFromStructure(i);
				Assert.That(SafeArrayPutElement(psa, new[] { i }, (IntPtr)p).Succeeded);
			}
			for (var i = 0; i < 5; i++)
			{
				var p = SafeCoTaskMemHandle.CreateFromStructure<int>();
				Assert.That(SafeArrayGetElement(psa, new[] { i }, (IntPtr)p).Succeeded);
				var oi = p.ToStructure<int>();
				Assert.That(oi, Is.EqualTo(i));
			}
		}
	}

	[Test]
	public void SafeArrayScopedAccessTest()
	{
		var psa = SafeArrayCreateVector(VARTYPE.VT_I4, 0, 5);
		{
			/*for (int i = 0; i < 5; i++)
			{
				var p = new SafeCoTaskMemHandle(16);
				Marshal.GetNativeVariantForObject(i, (IntPtr)p);
				Assert.That(SafeArrayPutElement(psa, new[] { i }, (IntPtr)p).Succeeded);
			}*/
			using (var d = new SafeArrayScopedAccessData(psa))
			{
				//var a = d.Data.ToArray<int>(5);
				//Assert.That(a, Is.EquivalentTo(new long[] {0, 1, 2, 3, 4}));
				d.Data.Write(new[] { 0, 1, 2, 3, 4 });
			}
			for (var i = 0; i < 5; i++)
			{
				var p = new SafeCoTaskMemHandle(16);
				Assert.That(SafeArrayGetElement(psa, new[] { i }, (IntPtr)p).Succeeded);
				var oi = p.ToStructure<int>();
				Assert.That(oi, Is.EqualTo(i));
			}
		}
		psa.Dispose();
	}

	[Test]
	public void SafeSAFEARRAYConvert1DimTest()
	{
		// Setup SAFEARRAY
		var array = new int[] { 1, 2, 3, 4 };
		using var sa = SafeSAFEARRAY.CreateFromArray(array, VARTYPE.VT_I4);
		Assert.That(sa.Length, Is.EqualTo(array.Length));
		Assert.That(sa.Rank, Is.EqualTo(array.Rank));

		var toarray = sa.ToArray();
		Assert.That(toarray, Is.EquivalentTo(array));

		var i = sa.GetValue<int>(3);
		Assert.That(i, Is.EqualTo(array[3]));
		sa.SetValue(i + 10, 3);
		Assert.That(sa.GetValue<int>(3), Is.EqualTo(i + 10));
		Assert.That(sa.GetValue(3), Is.EqualTo(i + 10));
	}

	[Test]
	public void SafeSAFEARRAYConvertMultDimTest()
	{
		// Setup SAFEARRAY
		var array = new int[2, 3, 4] { { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 } }, { { 13, 14, 15, 16 }, { 17, 18, 19, 20 }, { 21, 22, 23, 24 } } };
		using var sa = SafeSAFEARRAY.CreateFromArray(array, VARTYPE.VT_I4);
		Assert.That(sa.Length, Is.EqualTo(array.Length));
		Assert.That(sa.Rank, Is.EqualTo(array.Rank));

		var toarray = sa.ToArray();
		Assert.That(toarray.Length, Is.EqualTo(array.Length));
		Assert.That(toarray.Rank, Is.EqualTo(array.Rank));

		var i = sa.GetValue<int>(1, 2, 3);
		Assert.That(i, Is.EqualTo(array[1, 2, 3]));
		sa.SetValue(i + 10, 1, 2, 3);
		Assert.That(sa.GetValue<int>(1, 2, 3), Is.EqualTo(i + 10));
		Assert.That(sa.GetValue(1, 2, 3), Is.EqualTo(i + 10));
	}


	// TODO: [Test]
	public void VariantClearTest()
	{
		throw new NotImplementedException();
	}
}