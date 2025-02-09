using Microsoft.VisualStudio.TestPlatform.Utilities;
using NUnit.Framework;
using System.Numerics;
using static Vanara.PInvoke.DirectXMath;

namespace Vanara.PInvoke.Tests;

public class DirectXMathTests
{
	static readonly float[,] m1 = new float[,] { { 5, -7, 2, 2 }, { 0, 3, 0, -4 }, { -5, -8, 0, 3 }, { 0, 5, 0, -6 } };
	static readonly float[,] m1inv = new float[,] { { 0, 3.3f, -0.2f, -2.3f }, { 0, -3, 0, 2 }, { 0.5f, -16.25f, 0.5f, 11.25f }, { 0, -2.5f, 0, 1.5f } };
	static readonly float[,] m1tr = new float[,] { { 5, 0, -5, 0 }, { -7, 3, -8, 5 }, { 2, 0, 0, 0 }, { 2, -4, 3, -6 } };

	[Test]
	public void StructTest()
	{
		foreach (var ss in TestHelper.GetNestedStructSizes(typeof(DirectXMath)))
			TestContext.WriteLine(ss);
	}

	[Test]
	public void SwizzleTest()
	{
		XMVECTOR v = new(1f, 2, 3, 4);
		Assert.That(v.XMVectorGetX(), Is.EqualTo(1f));
		Assert.That(v.XMVectorGetY(), Is.EqualTo(2f));
		Assert.That(v.XMVectorGetZ(), Is.EqualTo(3f));
		Assert.That(v.XMVectorGetW(), Is.EqualTo(4f));
		v = v.XMVectorSwizzle(XM_SWIZZLE_X, XM_SWIZZLE_Y, XM_SWIZZLE_Z, XM_SWIZZLE_W);
		Assert.That(v.XMVectorGetX(), Is.EqualTo(1f));
		Assert.That(v.XMVectorGetY(), Is.EqualTo(2f));
		Assert.That(v.XMVectorGetZ(), Is.EqualTo(3f));
		Assert.That(v.XMVectorGetW(), Is.EqualTo(4f));
		v = v.XMVectorSwizzle(XM_SWIZZLE_W, XM_SWIZZLE_Z, XM_SWIZZLE_Y, XM_SWIZZLE_X);
		Assert.That(v.XMVectorGetX(), Is.EqualTo(4f));
		Assert.That(v.XMVectorGetY(), Is.EqualTo(3f));
		Assert.That(v.XMVectorGetZ(), Is.EqualTo(2f));
		Assert.That(v.XMVectorGetW(), Is.EqualTo(1f));
	}

	[Test]
	public void PermuteTest()
	{
		XMVECTOR v = new(1f, 2, 3, 4);
		XMVECTOR v2 = new(5f, 6, 7, 8);
		XMVECTOR v3 = v.XMVectorPermute(v2, XM_PERMUTE_0X, XM_PERMUTE_0Y, XM_PERMUTE_0Z, XM_PERMUTE_0W);
		Assert.That(v3.XMVectorGetX(), Is.EqualTo(1f));
		Assert.That(v3.XMVectorGetY(), Is.EqualTo(2f));
		Assert.That(v3.XMVectorGetZ(), Is.EqualTo(3f));
		Assert.That(v3.XMVectorGetW(), Is.EqualTo(4f));
		v3 = v.XMVectorPermute(v2, XM_PERMUTE_1X, XM_PERMUTE_1Y, XM_PERMUTE_1Z, XM_PERMUTE_1W);
		Assert.That(v3.XMVectorGetX(), Is.EqualTo(5f));
		Assert.That(v3.XMVectorGetY(), Is.EqualTo(6f));
		Assert.That(v3.XMVectorGetZ(), Is.EqualTo(7f));
		Assert.That(v3.XMVectorGetW(), Is.EqualTo(8f));
	}

	[Test]
	public void MatrixTest()
	{
		XMMATRIX m = m1;
		Assert.That(m[0, 0], Is.EqualTo(5f));
		Assert.That(m[2, 2], Is.EqualTo(0f));
		Assert.That(m[3, 3], Is.EqualTo(-6f));
		Assert.That(() => m[5, 5], Throws.Exception);

		var vrow = new XMVECTOR(0f, 3, 0, -4);
		Assert.That(m.r[1], Is.EqualTo(vrow));

		Assert.That(() => m[1, 0] = m[1, 1] = m[1, 2] = m[1, 3] = 255f, Throws.Nothing);

		Assert.That(m.r[1], Is.EqualTo(new XMVECTOR(255f)));

		Assert.That(() => m.r[1] = vrow, Throws.Nothing);
		Assert.That(m.r[1], Is.EqualTo(vrow));

		m = new(vrow, vrow, vrow, vrow);
		Assert.That(m[0,0] == 0f && m[1,0] == 0f && m[2, 0] == 0f && m[3, 0] == 0f);
	}

	[Test]
	public void InvertTest()
	{
		XMMATRIX val = m1;
		TestContext.WriteLine(val);
		XMMATRIX inv = val.XMMatrixInverse(out var det);
		TestContext.WriteLine(inv);
		Assert.That(det.XMVectorGetX(), Is.EqualTo(20f));
		XMMATRIX invChk = m1inv;
		Assert.That(inv, Is.EqualTo(invChk));
		XMMATRIX id = val * inv;
		TestContext.WriteLine(id);
		Assert.That(id.XMMatrixIsIdentity());
	}

	[Test]
	public void DecomposeTest()
	{
		XMMATRIX val = m1;
		Assert.That(!val.XMMatrixDecompose(out var scale, out var rot, out var trans));
		TestContext.WriteLine($"Scale: {scale}\r\nRotation: {rot}\r\nTranslation: {trans}");
	}

	[Test]
	public void VInvertTest()
	{
		Matrix val = m1;
		TestContext.WriteLine(val);
		Matrix inv = val.Invert();
		TestContext.WriteLine(inv);
		Assert.That(val.Determinant, Is.EqualTo(20f));
		Matrix invChk = m1inv;
		Assert.That(inv, Is.EqualTo(invChk));
		Matrix id = val * inv;
		Assert.That(id.IsIdentity);
	}

	[Test]
	public void DetTest()
	{
		XMMATRIX val = m1;
		Assert.That(val.XMMatrixDeterminant().XMVectorGetX(), Is.EqualTo(20f));
	}

	[Test]
	public void MultiplicationTest()
	{
		XMMATRIX val = m1;
		XMMATRIX inv = m1inv;
		XMMATRIX id = val * inv;
		TestContext.WriteLine(id);
		Assert.That(id.XMMatrixIsIdentity());
	}

	[Test]
	public void TransposeTest()
	{
		XMMATRIX val = m1;
		XMMATRIX tr = val.XMMatrixTranspose();
		XMMATRIX exp = m1tr;
		Assert.That(exp, Is.EqualTo(tr));
	}

}