using NUnit.Framework;
using Vanara;
using GMatrix4x4 = Vanara.Matrix<float>;
using GScalar = System.Single;

namespace System.Numerics.Tests;

public class GenericMatrixFloatTests
{
	static System.IO.TextWriter output = TestContext.Out;

	static GMatrix4x4 GenerateIncrementalMatrixNumber(GScalar value = GScalar.NegativeZero)
	{
		return new float[,] {
		   { value + 1, value + 1, value + 1, value - 1  },
		   { value + 1, value + 1, value - 1, value + 1  },
		   { value + 1, value - 1, value + 1, value + 1 },
		   { value - 1, value + 1, value + 1, value + 1 } };
	}

	[Test]
	public void AdditionTest()
	{
		GMatrix4x4 vl = GMatrix4x4.CreateIdentity(4);
		GMatrix4x4 vr = GMatrix4x4.CreateIdentity(4);

		GMatrix4x4 bad = GMatrix4x4.CreateIdentity(3);
		Assert.That(() => vl + bad, Throws.ArgumentException);

		var val = vl + vr;
		Assert.That(val.Columns, Is.EqualTo(vl.Columns));
		Assert.That(val.Rows, Is.EqualTo(vl.Rows));
		for (int i = 0; i < val.Rows; i++)
		{
			for (int j = 0; j < val.Columns; j++)
			{
				if (i == j)
					Assert.That(2f, Is.EqualTo(val[i, j]));
				else
					Assert.That(0f, Is.EqualTo(val[i, j]));
			}
		}
	}

	[Test]
	public void CofactorTest()
	{
		GMatrix4x4 val = new float[,] { { 3, 0, 2 }, { 2, 0, -2 }, { 0, 1, 1 } };
		GMatrix4x4 cof = val.Cofactor();
		GMatrix4x4 exp = new float[,] { { 2, -2, 2 }, { 2, 3, -3 }, { 0, 10, 0 } };
		Assert.That(exp, Is.EqualTo(cof));
	}

	[Test]
	public void DeterminantTest()
	{
		Matrix<GScalar> v1 = new float[,] { { 15 } };
		Assert.That(15f, Is.EqualTo(v1.Determinant));

		Matrix<GScalar> v2 = new float[,] { { 3, 2 }, { -1, 3 } };
		Assert.That(11f, Is.EqualTo(v2.Determinant));

		Matrix<GScalar> v3 = new float[,] { { -1, 2, 0 }, { 2, 1, 5 }, { 0, -2, 3 } };
		Assert.That(-25f, Is.EqualTo(v3.Determinant));

		v3 = new float[,] { { 2, 0, 3 }, { -3, 1, 5 }, { 1, 2, 3 } };
		Assert.That(-35f, Is.EqualTo(v3.Determinant));

		v3 = new float[,] { { 2, 1, 3 }, { -3, 2, 5 }, { 1, 0, 3 } };
		Assert.That(20f, Is.EqualTo(v3.Determinant));

		GMatrix4x4 val = GMatrix4x4.CreateIdentity(4);
		Assert.That(1f, Is.EqualTo(val.Determinant));

		GMatrix4x4 v4 = new float[,] { { 5, -7, 2, 2 }, { 0, 3, 0, -4 }, { -5, -8, 0, 3 }, { 0, 5, 0, -6 } };
		Assert.That(20f, Is.EqualTo(v4.Determinant));

		v4 = new float[,] { { 1, 1, 1, -1 }, { 1, 1, -1, 1 }, { 1, -1, 1, 1 }, { -1, 1, 1, 1 } };
		Assert.That(-16f, Is.EqualTo(v4.Determinant));

		GMatrix4x4 v5 = new float[,] { { 1, 1, 1, 1, -1 }, { 1, 1, 1, -1, 1 }, { 1, 1, -1, 1, 1 }, { 1, -1, 1, 1, 1 }, { -1, 1, 1, 1, 1 } };
		Assert.That(48f, Is.EqualTo(v5.Determinant));
	}

	[Test]
	public void DivisionByScalarTest()
	{
		GMatrix4x4 vl = GenerateIncrementalMatrixNumber();
		GScalar vr = 5f;
		var val = vl / vr;
		Assert.That(val.Columns, Is.EqualTo(vl.Columns));
		Assert.That(val.Rows, Is.EqualTo(vl.Rows));
		for (int i = 0; i < val.Rows; i++)
			for (int j = 0; j < val.Columns; j++)
				Assert.That(vl[i, j] / vr, Is.EqualTo(val[i, j]));
	}

	[Test]
	public void HashCodeTest()
	{
		GMatrix4x4 val = GenerateIncrementalMatrixNumber();
		Assert.That(val.GetHashCode(), Is.EqualTo(val.GetHashCode()));

		GMatrix4x4 val2 = GenerateIncrementalMatrixNumber(4f);
		Assert.That(val.GetHashCode(), Is.Not.EqualTo(val2.GetHashCode()));
	}

	[Test]
	public void IdentityMultTest()
	{
		GMatrix4x4 vl = GenerateIncrementalMatrixNumber();
		GMatrix4x4 vr = GMatrix4x4.CreateIdentity(4);
		var val = vl * vr;
		Assert.That(val.Columns, Is.EqualTo(vl.Columns));
		Assert.That(val, Is.EqualTo(vl));
	}

	[Test]
	public void InvertTest()
	{
		GMatrix4x4 val = new float[,] { { 5, -7, 2, 2 }, { 0, 3, 0, -4 }, { -5, -8, 0, 3 }, { 0, 5, 0, -6 } };
		output.WriteLine(val.ToString());
		GMatrix4x4 inv = val.Invert();
		output.WriteLine(inv.ToString());
		GMatrix4x4 id = val * inv;
		Assert.That(id.IsIdentity);
	}

	[Test]
	public void Matrix4x4IdentityTest()
	{
		GMatrix4x4 val = new float[,] { { 1.0f, 0.0f, 0.0f, 0.0f }, { 0.0f, 1.0f, 0.0f, 0.0f }, { 0.0f, 0.0f, 1.0f, 0.0f }, { 0.0f, 0.0f, 0.0f, 1.0f } };

		Assert.That(val.IsIdentity);
		Assert.That(val.Equals(GMatrix4x4.CreateIdentity(4)), "Matrix4x4.Indentity was not set correctly.");
	}

	[Test]
	public void MultiplicationByScalarTest()
	{
		GMatrix4x4 vl = GenerateIncrementalMatrixNumber();
		GScalar vr = 5f;
		var val = vl * vr;
		Assert.That(val.Columns, Is.EqualTo(vl.Columns));
		Assert.That(val.Rows, Is.EqualTo(vl.Rows));
		for (int i = 0; i < val.Rows; i++)
			for (int j = 0; j < val.Columns; j++)
				Assert.That(vl[i, j] * vr, Is.EqualTo(val[i, j]));

		val = vr * vl;
		Assert.That(val.Columns, Is.EqualTo(vl.Columns));
		Assert.That(val.Rows, Is.EqualTo(vl.Rows));
		for (int i = 0; i < val.Rows; i++)
			for (int j = 0; j < val.Columns; j++)
				Assert.That(vl[i, j] * vr, Is.EqualTo(val[i, j]));
	}

	[Test]
	public void MultiplicationTest()
	{
		GMatrix4x4 vl = new float[,] { { 1, 2, 3 }, { 4, 5, 6 } };
		GMatrix4x4 vr = new float[,] { { 10, 11 }, { 20, 21 }, { 30, 31 } };

		Assert.That(() => vl * GenerateIncrementalMatrixNumber(), Throws.ArgumentException);

		var val = vl * vr;
		Assert.That(val.Columns, Is.EqualTo(vr.Columns));
		Assert.That(val.Rows, Is.EqualTo(vl.Rows));
		Assert.That(val, Is.EqualTo(new GMatrix4x4(new float[,] { { 140, 146 }, { 320, 335 } })));
	}

	[Test]
	public void NegateTest()
	{
		GMatrix4x4 val = GenerateIncrementalMatrixNumber(-5f);
		var nval = -val;
		Assert.That(nval.Columns, Is.EqualTo(val.Columns));
		Assert.That(nval.Rows, Is.EqualTo(val.Rows));
		for (int i = 0; i < val.Rows; i++)
		{
			for (int j = 0; j < val.Columns; j++)
			{
				Assert.That(-val[i, j], Is.EqualTo(nval[i, j]));
			}
		}
	}

	[Test]
	public void PropCheck()
	{
		const int sz = 4;
		GMatrix4x4 val = GMatrix4x4.CreateIdentity(sz);

		Assert.That(val.Rows == sz, "Matrix4x4.Rows was not set correctly.");
		Assert.That(val.Columns == sz, "Matrix4x4.Rows was not set correctly.");

		Assert.That(val[0, 0] == 1f);
		Assert.That(val[0, 1] == 0f);

		Assert.That(() => val[0, 4] == 0f, Throws.TypeOf<ArgumentOutOfRangeException>());
		Assert.That(() => val[4, 0] == 0f, Throws.TypeOf<ArgumentOutOfRangeException>());

		val[0, 0] = 2f;
		Assert.That(val[0, 0] == 2f);

		Assert.That(() => val[0, 4] = 0f, Throws.TypeOf<ArgumentOutOfRangeException>());
		Assert.That(() => val[4, 0] = 0f, Throws.TypeOf<ArgumentOutOfRangeException>());
	}

	[Test]
	public void ReducedRowEchelonFormTest()
	{
		GMatrix4x4 val = new float[,] { { 5, -7, 2, 2, -6 }, { 0, 3, 0, -4, 5 }, { -5, -8, 0, 3, 9 }, { 0, 5, 0, -6, -11 }, { 6, -7, 4, 2, -8 } };
		GMatrix4x4 rref = val.ReducedRowEchelonForm();
		GMatrix4x4 exp = GMatrix4x4.CreateIdentity(5);
		Assert.That(exp, Is.EqualTo(rref));
		Assert.That(5, Is.EqualTo(val.Rank));

		val = new float[,] { { 1, 2, 3 }, { 3, 6, 9 } };
		Assert.That(1, Is.EqualTo(val.Rank)); // Rank calls ReducedRowEchelonForm
	}

	[Test]
	public void SubmatrixTest()
	{
		GMatrix4x4 val = new float[,] { { 5, -7, 2, 2, -6 }, { 0, 3, 0, -4, 5 }, { -5, -8, 0, 3, 9 }, { 0, 5, 0, -6, -11 }, { 6, -7, 4, 2, -8 } };
		GMatrix4x4 sub = val.Submatrix([0..1, 4..4], [1..2]);
		output.WriteLine(sub.ToString());
		GMatrix4x4 exp = new float[,] { { -7, 2 }, { 3, 0 }, { -7, 4 } };
		Assert.That(exp, Is.EqualTo(sub));
	}

	[Test]
	public void SubtractTest()
	{
		GMatrix4x4 vl = GenerateIncrementalMatrixNumber(5f);
		GMatrix4x4 vr = GenerateIncrementalMatrixNumber(-5f);

		GMatrix4x4 bad = GMatrix4x4.CreateIdentity(3);
		Assert.That(() => vl - bad, Throws.ArgumentException);

		Assert.That(vl != vr);
		var val = vl - vr;
		Assert.That(val.Columns, Is.EqualTo(vl.Columns));
		Assert.That(val.Rows, Is.EqualTo(vl.Rows));
		for (int i = 0; i < val.Rows; i++)
		{
			for (int j = 0; j < val.Columns; j++)
			{
				Assert.That(10f, Is.EqualTo(val[i, j]));
			}
		}
	}

	[Test]
	public void ToStringTest()
	{
		GMatrix4x4 val = GenerateIncrementalMatrixNumber();
		output.WriteLine(val.ToString());
	}

	[Test]
	public void TransposeTest()
	{
		GMatrix4x4 val = new float[,] { { 5, -7, 2, 2 }, { 0, 3, 0, -4 }, { -5, -8, 0, 3 }, { 0, 5, 0, -6 } };
		GMatrix4x4 tr = val.Transpose();
		GMatrix4x4 exp = new float[,] { { 5, 0, -5, 0 }, { -7, 3, -8, 5 }, { 2, 0, 0, 0 }, { 2, -4, 3, -6 } };
		Assert.That(exp, Is.EqualTo(tr));

		val = new float[,] { { 6, 4, 24 }, { 1, -9, 8 } };
		tr = val.Transpose();
		exp = new float[,] { { 6, 1 }, { 4, -9 }, { 24, 8 } };
		Assert.That(exp, Is.EqualTo(tr));
	}

	[Test]
	public void VectorTest()
	{
		GMatrix4x4 val = new float[,] { { 5, -7, 2, 2 }, { 0, 3, 0, -4 }, { -5, -8, 0, 3 } };
		GMatrix4x4 rvec2 = new float[,] { { -5, -8, 0, 3 } };
		GMatrix4x4 cvec2 = new float[,] { { 2, 0, 0 } };

		Assert.That(rvec2, Is.EqualTo(val.RowVector(2)));
		Assert.That(cvec2, Is.EqualTo(val.ColumnVector(2)));
	}
}