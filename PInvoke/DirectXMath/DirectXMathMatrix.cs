namespace Vanara.PInvoke;

public static partial class DirectXMath
{
	private const float XM3_DECOMP_EPSILON = 0.0001f;

	/// <summary>Builds an affine transformation matrix.</summary>
	/// <param name="Scaling">Vector of scaling factors for each dimension.</param>
	/// <param name="RotationOrigin">Point identifying the center of rotation.</param>
	/// <param name="RotationQuaternion">Rotation factors.</param>
	/// <param name="Translation">Translation offsets.</param>
	/// <returns>Returns the affine transformation matrix, built from the scaling, rotation, and translation information.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmmatrixaffinetransformation XMMATRIX XM_CALLCONV
	// XMMatrixAffineTransformation( [in] FXMVECTOR Scaling, [in] FXMVECTOR RotationOrigin, [in] FXMVECTOR RotationQuaternion, [in]
	// GXMVECTOR Translation ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMMatrixAffineTransformation")]
	public static XMMATRIX XMMatrixAffineTransformation(in FXMVECTOR Scaling, in FXMVECTOR RotationOrigin, in FXMVECTOR RotationQuaternion, in GXMVECTOR Translation)
	{
		// M = MScaling * Inverse(MRotationOrigin) * MRotation * MRotationOrigin * MTranslation;

		XMMATRIX MScaling = XMMatrixScalingFromVector(Scaling);
		XMVECTOR VRotationOrigin = XMVectorSelect(XMVECTOR.g_XMSelect1110, RotationOrigin, XMVECTOR.g_XMSelect1110);
		XMMATRIX MRotation = XMMatrixRotationQuaternion(RotationQuaternion);
		XMVECTOR VTranslation = XMVectorSelect(XMVECTOR.g_XMSelect1110, Translation, XMVECTOR.g_XMSelect1110);

		XMMATRIX M = MScaling;
		M.r[3] -= VRotationOrigin;
		M *= MRotation;
		M.r[3] += VRotationOrigin;
		M.r[3] += VTranslation;
		return M;
	}

	/// <summary>Builds a 2D affine transformation matrix in the xy plane.</summary>
	/// <param name="Scaling">2D vector of scaling factors for the x-coordinate and y-coordinate.</param>
	/// <param name="RotationOrigin">2D vector describing the center of rotation.</param>
	/// <param name="Rotation">Radian angle of rotation.</param>
	/// <param name="Translation">2D vector translation offsets.</param>
	/// <returns>Returns the 2D affine transformation matrix.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmmatrixaffinetransformation2d XMMATRIX XM_CALLCONV
	// XMMatrixAffineTransformation2D( [in] FXMVECTOR Scaling, [in] FXMVECTOR RotationOrigin, [in] float Rotation, [in] FXMVECTOR
	// Translation ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMMatrixAffineTransformation2D")]
	public static XMMATRIX XMMatrixAffineTransformation2D(this FXMVECTOR Scaling, in FXMVECTOR RotationOrigin, float Rotation, in FXMVECTOR Translation)
	{
		// M = MScaling * Inverse(MRotationOrigin) * MRotation * MRotationOrigin * MTranslation;

		XMVECTOR VScaling = XMVectorSelect(XMVECTOR.g_XMOne, Scaling, XMVECTOR.g_XMSelect1100);
		XMMATRIX MScaling = XMMatrixScalingFromVector(VScaling);
		XMVECTOR VRotationOrigin = XMVectorSelect(XMVECTOR.g_XMSelect1100, RotationOrigin, XMVECTOR.g_XMSelect1100);
		XMMATRIX MRotation = XMMatrixRotationZ(Rotation);
		XMVECTOR VTranslation = XMVectorSelect(XMVECTOR.g_XMSelect1100, Translation, XMVECTOR.g_XMSelect1100);

		XMMATRIX M = MScaling;
		M.r[3] = XMVectorSubtract(M.r[3], VRotationOrigin);
		M = XMMatrixMultiply(M, MRotation);
		M.r[3] = XMVectorAdd(M.r[3], VRotationOrigin);
		M.r[3] = XMVectorAdd(M.r[3], VTranslation);
		return M;
	}

	/// <summary>Breaks down a general 3D transformation matrix into its scalar, rotational, and translational components.</summary>
	/// <param name="outScale">Pointer to the output <c>XMVECTOR</c> that contains scaling factors applied along the x, y, and z-axes.</param>
	/// <param name="outRotQuat">Pointer to the <c>XMVECTOR</c> quaternion that describes the rotation.</param>
	/// <param name="outTrans">Pointer to the <c>XMVECTOR</c> vector that describes a translation along the x, y, and z-axes.</param>
	/// <param name="M">Pointer to an input <c>XMMATRIX</c> matrix to decompose.</param>
	/// <returns>If the function succeeds, the return value is true. If the function fails, the return value is false.</returns>
	/// <remarks>
	/// <para>
	/// <b>XMMatrixDecompose</b> provides the same basic functionality found in both <c>D3DXMatrixDecompose (Direct3D 9)</c> and
	/// <c>D3DXMatrixDecompose (Direct3D 10)</c>.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmmatrixdecompose bool XM_CALLCONV XMMatrixDecompose(
	// [in, out] XMVECTOR *outScale, [in, out] XMVECTOR *outRotQuat, [in, out] XMVECTOR *outTrans, [in] FXMMATRIX M ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMMatrixDecompose")]
	public static bool XMMatrixDecompose(this FXMMATRIX M, out XMVECTOR outScale, out XMVECTOR outRotQuat, out XMVECTOR outTrans)
	{
		XMVECTOR[] pvCanonicalBasis = [XMVECTOR.g_XMIdentityR0, XMVECTOR.g_XMIdentityR1, XMVECTOR.g_XMIdentityR2];

		// Get the translation
		outTrans = M.r[3];

		XMMATRIX matTemp = new(M.r[0], M.r[1], M.r[2], XMVECTOR.g_XMIdentityR3);

		outScale = new(XMVector3Length(M.r[0]).x, XMVector3Length(M.r[1]).x, XMVector3Length(M.r[2]).x, 0f);

		XM3RANKDECOMPOSE(out var a, out var b, out var c, outScale[0], outScale[1], outScale[2]);

		if (outScale[a] < XM3_DECOMP_EPSILON)
		{
			M.r[a] = pvCanonicalBasis[a];
		}
		M.r[a] = XMVector3Normalize(M.r[a]);

		if (outScale[b] < XM3_DECOMP_EPSILON)
		{
			float fAbsX = Math.Abs(XMVectorGetX(M.r[a]));
			float fAbsY = Math.Abs(XMVectorGetY(M.r[a]));
			float fAbsZ = Math.Abs(XMVectorGetZ(M.r[a]));

			XM3RANKDECOMPOSE(out _, out _, out var cc, fAbsX, fAbsY, fAbsZ);

			M.r[b] = XMVector3Cross(M.r[a], pvCanonicalBasis[cc]);
		}

		M.r[b] = XMVector3Normalize(M.r[b]);

		if (outScale[c] < XM3_DECOMP_EPSILON)
		{
			M.r[c] = XMVector3Cross(M.r[a], M.r[b]);
		}

		M.r[c] = XMVector3Normalize(M.r[c]);

		// generate the quaternion from the matrix
		outRotQuat = XMQuaternionRotationMatrix(matTemp);

		float fDet = XMVectorGetX(XMMatrixDeterminant(matTemp));

		// use Kramer's rule to check for handedness of coordinate system
		if (fDet < 0.0f)
		{
			// switch coordinate system by negating the scale and inverting the basis vector on the x-axis
			outScale[a] = -outScale[a];
			M.r[a] = XMVectorNegate(M.r[a]);

			fDet = -fDet;
		}

		fDet -= 1.0f;
		fDet *= fDet;

		if (XM3_DECOMP_EPSILON < fDet)
		{
			// Non-SRT matrix encountered
			return false;
		}
		return true;
	}

	/// <summary>Computes the determinant of a matrix.</summary>
	/// <param name="M">Matrix from which to compute the determinant.</param>
	/// <returns>Returns a vector. The determinant of <i>M</i> is replicated into each component.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmmatrixdeterminant XMVECTOR XMMatrixDeterminant( [in]
	// FXMMATRIX M );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMMatrixDeterminant")]
	public static XMVECTOR XMMatrixDeterminant(this FXMMATRIX M) => new(GetDeterminant(M));

	/// <summary>Builds the identity matrix.</summary>
	/// <returns>Returns the identity matrix.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmmatrixidentity XMMATRIX XM_CALLCONV
	// XMMatrixIdentity() noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMMatrixIdentity")]
	public static XMMATRIX XMMatrixIdentity() => new(XMVECTOR.g_XMIdentityR0, XMVECTOR.g_XMIdentityR1, XMVECTOR.g_XMIdentityR2, XMVECTOR.g_XMIdentityR3);

	/// <summary>Computes the inverse of a matrix.</summary>
	/// <param name="pDeterminant">
	/// Address of a vector, each of whose components receives the determinant of <i>M</i>. This parameter can be nullptr if the determinant
	/// is not desired.
	/// </param>
	/// <param name="M">Matrix to invert.</param>
	/// <returns>
	/// Returns the matrix inverse of <i>M</i>. If there is no inverse (that is, if the determinant is 0), <b>XMMatrixInverse</b> returns an
	/// infinite matrix.
	/// </returns>
	/// <remarks>
	/// <para>
	/// <b>Note</b>  For XNAMATH version 2.04 and earlier, the <i>pDeterminant</i> parameter isn't optional. That is, for XNAMATH version
	/// 2.04 and earlier, you can't set <i>pDeterminant</i> to a nullptr.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmmatrixinverse XMMATRIX XMMatrixInverse( [out,
	// optional] XMVECTOR *pDeterminant, [in] FXMMATRIX M );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMMatrixInverse")]
	public static XMMATRIX XMMatrixInverse(this FXMMATRIX M, out XMVECTOR pDeterminant)
	{
		pDeterminant = M.XMMatrixDeterminant();
		if (pDeterminant.x == 0f)
			return new(XMVECTOR.g_XMInfinity, XMVECTOR.g_XMInfinity, XMVECTOR.g_XMInfinity, XMVECTOR.g_XMInfinity);

		Matrix m = M;
		return m.Invert();

		// TODO: Figure out why none of the below work and remove dependence on Vanara.Matrix
		/*XMMATRIX MT = XMMatrixTranspose(M);
		var MTr = MT.r.ToArray();

		XMVECTOR[] V0 = new XMVECTOR[4], V1 = new XMVECTOR[4];
		V0[0] = XMVectorSwizzle(MTr[2], XM_SWIZZLE_X, XM_SWIZZLE_X, XM_SWIZZLE_Y, XM_SWIZZLE_Y);
		V1[0] = XMVectorSwizzle(MTr[3], XM_SWIZZLE_Z, XM_SWIZZLE_W, XM_SWIZZLE_Z, XM_SWIZZLE_W);
		V0[1] = XMVectorSwizzle(MTr[0], XM_SWIZZLE_X, XM_SWIZZLE_X, XM_SWIZZLE_Y, XM_SWIZZLE_Y);
		V1[1] = XMVectorSwizzle(MTr[1], XM_SWIZZLE_Z, XM_SWIZZLE_W, XM_SWIZZLE_Z, XM_SWIZZLE_W);
		V0[2] = XMVectorPermute(MTr[2], MTr[0], XM_PERMUTE_0X, XM_PERMUTE_0Z, XM_PERMUTE_1X, XM_PERMUTE_1Z);
		V1[2] = XMVectorPermute(MTr[3], MTr[1], XM_PERMUTE_0Y, XM_PERMUTE_0W, XM_PERMUTE_1Y, XM_PERMUTE_1W);

		XMVECTOR D0 = XMVectorMultiply(V0[0], V1[0]);
		XMVECTOR D1 = XMVectorMultiply(V0[1], V1[1]);
		XMVECTOR D2 = XMVectorMultiply(V0[2], V1[2]);

		V0[0] = XMVectorSwizzle(MTr[2], XM_SWIZZLE_Z, XM_SWIZZLE_W, XM_SWIZZLE_Z, XM_SWIZZLE_W);
		V1[0] = XMVectorSwizzle(MTr[3], XM_SWIZZLE_X, XM_SWIZZLE_X, XM_SWIZZLE_Y, XM_SWIZZLE_Y);
		V0[1] = XMVectorSwizzle(MTr[0], XM_SWIZZLE_Z, XM_SWIZZLE_W, XM_SWIZZLE_Z, XM_SWIZZLE_W);
		V1[1] = XMVectorSwizzle(MTr[1], XM_SWIZZLE_X, XM_SWIZZLE_X, XM_SWIZZLE_Y, XM_SWIZZLE_Y);
		V0[2] = XMVectorPermute(MTr[2], MTr[0], XM_PERMUTE_0Y, XM_PERMUTE_0W, XM_PERMUTE_1Y, XM_PERMUTE_1W);
		V1[2] = XMVectorPermute(MTr[3], MTr[1], XM_PERMUTE_0X, XM_PERMUTE_0Z, XM_PERMUTE_1X, XM_PERMUTE_1Z);

		D0 = XMVectorNegativeMultiplySubtract(V0[0], V1[0], D0);
		D1 = XMVectorNegativeMultiplySubtract(V0[1], V1[1], D1);
		D2 = XMVectorNegativeMultiplySubtract(V0[2], V1[2], D2);

		V0[0] = XMVectorSwizzle(MTr[1], XM_SWIZZLE_Y, XM_SWIZZLE_Z, XM_SWIZZLE_X, XM_SWIZZLE_Y);
		V1[0] = XMVectorPermute(D0, D2, XM_PERMUTE_1Y, XM_PERMUTE_0Y, XM_PERMUTE_0W, XM_PERMUTE_0X);
		V0[1] = XMVectorSwizzle(MTr[0], XM_SWIZZLE_Z, XM_SWIZZLE_X, XM_SWIZZLE_Y, XM_SWIZZLE_X);
		V1[1] = XMVectorPermute(D0, D2, XM_PERMUTE_0W, XM_PERMUTE_1Y, XM_PERMUTE_0Y, XM_PERMUTE_0Z);
		V0[2] = XMVectorSwizzle(MTr[3], XM_SWIZZLE_Y, XM_SWIZZLE_Z, XM_SWIZZLE_X, XM_SWIZZLE_Y);
		V1[2] = XMVectorPermute(D1, D2, XM_PERMUTE_1W, XM_PERMUTE_0Y, XM_PERMUTE_0W, XM_PERMUTE_0X);
		V0[3] = XMVectorSwizzle(MTr[2], XM_SWIZZLE_Z, XM_SWIZZLE_X, XM_SWIZZLE_Y, XM_SWIZZLE_X);
		V1[3] = XMVectorPermute(D1, D2, XM_PERMUTE_0W, XM_PERMUTE_1W, XM_PERMUTE_0Y, XM_PERMUTE_0Z);

		XMVECTOR C0 = XMVectorMultiply(V0[0], V1[0]);
		XMVECTOR C2 = XMVectorMultiply(V0[1], V1[1]);
		XMVECTOR C4 = XMVectorMultiply(V0[2], V1[2]);
		XMVECTOR C6 = XMVectorMultiply(V0[3], V1[3]);

		V0[0] = XMVectorSwizzle(MTr[1], XM_SWIZZLE_Z, XM_SWIZZLE_W, XM_SWIZZLE_Y, XM_SWIZZLE_Z);
		V1[0] = XMVectorPermute(D0, D2, XM_PERMUTE_0W, XM_PERMUTE_0X, XM_PERMUTE_0Y, XM_PERMUTE_1X);
		V0[1] = XMVectorSwizzle(MTr[0], XM_SWIZZLE_W, XM_SWIZZLE_Z, XM_SWIZZLE_W, XM_SWIZZLE_Y);
		V1[1] = XMVectorPermute(D0, D2, XM_PERMUTE_0Z, XM_PERMUTE_0Y, XM_PERMUTE_1X, XM_PERMUTE_0X);
		V0[2] = XMVectorSwizzle(MTr[3], XM_SWIZZLE_Z, XM_SWIZZLE_W, XM_SWIZZLE_Y, XM_SWIZZLE_Z);
		V1[2] = XMVectorPermute(D1, D2, XM_PERMUTE_0W, XM_PERMUTE_0X, XM_PERMUTE_0Y, XM_PERMUTE_1Z);
		V0[3] = XMVectorSwizzle(MTr[2], XM_SWIZZLE_W, XM_SWIZZLE_Z, XM_SWIZZLE_W, XM_SWIZZLE_Y);
		V1[3] = XMVectorPermute(D1, D2, XM_PERMUTE_0Z, XM_PERMUTE_0Y, XM_PERMUTE_1Z, XM_PERMUTE_0X);

		C0 = XMVectorNegativeMultiplySubtract(V0[0], V1[0], C0);
		C2 = XMVectorNegativeMultiplySubtract(V0[1], V1[1], C2);
		C4 = XMVectorNegativeMultiplySubtract(V0[2], V1[2], C4);
		C6 = XMVectorNegativeMultiplySubtract(V0[3], V1[3], C6);

		V0[0] = XMVectorSwizzle(MTr[1], XM_SWIZZLE_W, XM_SWIZZLE_X, XM_SWIZZLE_W, XM_SWIZZLE_X);
		V1[0] = XMVectorPermute(D0, D2, XM_PERMUTE_0Z, XM_PERMUTE_1Y, XM_PERMUTE_1X, XM_PERMUTE_0Z);
		V0[1] = XMVectorSwizzle(MTr[0], XM_SWIZZLE_Y, XM_SWIZZLE_W, XM_SWIZZLE_X, XM_SWIZZLE_Z);
		V1[1] = XMVectorPermute(D0, D2, XM_PERMUTE_1Y, XM_PERMUTE_0X, XM_PERMUTE_0W, XM_PERMUTE_1X);
		V0[2] = XMVectorSwizzle(MTr[3], XM_SWIZZLE_W, XM_SWIZZLE_X, XM_SWIZZLE_W, XM_SWIZZLE_X);
		V1[2] = XMVectorPermute(D1, D2, XM_PERMUTE_0Z, XM_PERMUTE_1W, XM_PERMUTE_1Z, XM_PERMUTE_0Z);
		V0[3] = XMVectorSwizzle(MTr[2], XM_SWIZZLE_Y, XM_SWIZZLE_W, XM_SWIZZLE_X, XM_SWIZZLE_Z);
		V1[3] = XMVectorPermute(D1, D2, XM_PERMUTE_1W, XM_PERMUTE_0X, XM_PERMUTE_0W, XM_PERMUTE_1Z);

		XMVECTOR C1 = XMVectorNegativeMultiplySubtract(V0[0], V1[0], C0);
		C0 = XMVectorMultiplyAdd(V0[0], V1[0], C0);
		XMVECTOR C3 = XMVectorMultiplyAdd(V0[1], V1[1], C2);
		C2 = XMVectorNegativeMultiplySubtract(V0[1], V1[1], C2);
		XMVECTOR C5 = XMVectorNegativeMultiplySubtract(V0[2], V1[2], C4);
		C4 = XMVectorMultiplyAdd(V0[2], V1[2], C4);
		XMVECTOR C7 = XMVectorMultiplyAdd(V0[3], V1[3], C6);
		C6 = XMVectorNegativeMultiplySubtract(V0[3], V1[3], C6);

		XMMATRIX R = new(XMVectorSelect(C0, C1, XMVECTOR.g_XMSelect0101), XMVectorSelect(C2, C3, XMVECTOR.g_XMSelect0101),
			XMVectorSelect(C4, C5, XMVECTOR.g_XMSelect0101), XMVectorSelect(C6, C7, XMVECTOR.g_XMSelect0101));
		var Rr = R.r.ToArray();

		XMVECTOR Determinant = XMVector4Dot(Rr[0], MTr[0]);
		Debug.Assert(pDeterminant == Determinant);
		XMVECTOR Reciprocal = XMVectorReciprocal(Determinant);

		return new(XMVectorMultiply(Rr[0], Reciprocal), XMVectorMultiply(Rr[1], Reciprocal),
			XMVectorMultiply(Rr[2], Reciprocal), XMVectorMultiply(Rr[3], Reciprocal));*/

		/*const int n = 4;
		float[,] augmented = new float[n, n * 2];

		// Initialize augmented matrix with the input matrix and the identity matrix
		for (int i = 0; i < n; i++)
		{
			for (int j = 0; j < n; j++)
			{
				augmented[i, j] = M[i, j];
				augmented[i, j + n] = (i == j) ? 1 : 0;
			}
		}

		// Apply Gaussian elimination
		for (int i = 0; i < n; i++)
		{
			int pivotRow = i;
			for (int j = i + 1; j < n; j++)
			{
				if (Math.Abs(augmented[j, i]) > Math.Abs(augmented[pivotRow, i]))
				{
					pivotRow = j;
				}
			}

			if (pivotRow != i)
			{
				for (int k = 0; k < 2 * n; k++)
				{
					float temp = augmented[i, k];
					augmented[i, k] = augmented[pivotRow, k];
					augmented[pivotRow, k] = temp;
				}
			}

			if (Math.Abs(augmented[i, i]) < 1e-10)
			{
				throw new InvalidOperationException();
			}

			float pivot = augmented[i, i];
			for (int j = 0; j < 2 * n; j++)
			{
				augmented[i, j] /= pivot;
			}

			for (int j = 0; j < n; j++)
			{
				if (j != i)
				{
					float factor = augmented[j, i];
					for (int k = 0; k < 2 * n; k++)
					{
						augmented[j, k] -= factor * augmented[i, k];
					}
				}
			}
		}

		float[,] result = new float[n, n];
		for (int i = 0; i < n; i++)
		{
			for (int j = 0; j < n; j++)
			{
				result[i, j] = augmented[i, j + n];
			}
		}

		return new(result);*/
	}

	/// <summary>Tests whether a matrix is the identity matrix.</summary>
	/// <param name="M">Matrix to test.</param>
	/// <returns>Returns true if <i>M</i> is the identity matrix, and false otherwise.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmmatrixisidentity bool XMMatrixIsIdentity( [in]
	// FXMMATRIX M );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMMatrixIsIdentity")]
	public static bool XMMatrixIsIdentity(this FXMMATRIX M)
	{
		// Use the integer pipeline to reduce branching to a minimum
		var pWork = M.GetSpan<uint>(16);
		// Convert 1.0f to zero and or them together
		uint uOne = pWork[0] ^ 0x3F800000U;
		// Or all the 0.0f entries together
		uint uZero = pWork[1];
		uZero |= pWork[2];
		uZero |= pWork[3];
		// 2nd row
		uZero |= pWork[4];
		uOne |= pWork[5] ^ 0x3F800000U;
		uZero |= pWork[6];
		uZero |= pWork[7];
		// 3rd row
		uZero |= pWork[8];
		uZero |= pWork[9];
		uOne |= pWork[10] ^ 0x3F800000U;
		uZero |= pWork[11];
		// 4th row
		uZero |= pWork[12];
		uZero |= pWork[13];
		uZero |= pWork[14];
		uOne |= pWork[15] ^ 0x3F800000U;
		// If all zero entries are zero, the uZero==0
		uZero &= 0x7FFFFFFF;    // Allow -0.0f
								// If all 1.0f entries are 1.0f, then uOne==0
		uOne |= uZero;
		return uOne == 0;
	}

	/// <summary>Tests whether any of the elements of a matrix are positive or negative infinity.</summary>
	/// <param name="M">Matrix to test.</param>
	/// <returns>Returns true if any element of <i>M</i> is either positive or negative infinity, and false otherwise.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmmatrixisinfinite bool XMMatrixIsInfinite( [in]
	// FXMMATRIX M );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMMatrixIsInfinite")]
	public static bool XMMatrixIsInfinite(this XMMATRIX M)
	{
		foreach (var pWork in M.GetSpan<uint>(16))
		{
			uint uTest = pWork & 0x7FFFFFFFU;
			if (uTest == 0x7F800000U)
				return true;
		}
		return false;
	}

	/// <summary>Tests whether any of the elements of a matrix are NaN.</summary>
	/// <param name="M">Matrix to test.</param>
	/// <returns>Returns true if any element of <i>M</i> is NaN, and false otherwise.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmmatrixisnan bool XMMatrixIsNaN( [in] FXMMATRIX M );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMMatrixIsNaN")]
	public static bool XMMatrixIsNaN(this FXMMATRIX M)
	{
		foreach (var pWork in M.GetSpan<uint>(16))
		{
			uint uTest = (pWork & 0x7FFFFFFFU) - 0x7F800001U;
			if (uTest < 0x007FFFFFU)
				return true;
		}
		return false;
	}

	/// <summary>Builds a view matrix for a left-handed coordinate system using a camera position, an up direction, and a focal point.</summary>
	/// <param name="EyePosition">Position of the camera.</param>
	/// <param name="FocusPosition">Position of the focal point.</param>
	/// <param name="UpDirection">Up direction of the camera, typically &lt; 0.0f, 1.0f, 0.0f &gt;.</param>
	/// <returns>Returns a view matrix that transforms a point from world space into view space.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmmatrixlookatlh XMMATRIX XM_CALLCONV
	// XMMatrixLookAtLH( [in] FXMVECTOR EyePosition, [in] FXMVECTOR FocusPosition, [in] FXMVECTOR UpDirection ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMMatrixLookAtLH")]
	public static XMMATRIX XMMatrixLookAtLH(in FXMVECTOR EyePosition, in FXMVECTOR FocusPosition, in FXMVECTOR UpDirection)
	{
		XMVECTOR EyeDirection = XMVectorSubtract(FocusPosition, EyePosition);
		return XMMatrixLookToLH(EyePosition, EyeDirection, UpDirection);
	}

	/// <summary>Builds a view matrix for a right-handed coordinate system using a camera position, an up direction, and a focal point.</summary>
	/// <param name="EyePosition">Position of the camera.</param>
	/// <param name="FocusPosition">Position of the focal point.</param>
	/// <param name="UpDirection">Up direction of the camera, typically &lt; 0.0f, 1.0f, 0.0f &gt;.</param>
	/// <returns>Returns a view matrix that transforms a point from world space into view space.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmmatrixlookatrh XMMATRIX XM_CALLCONV
	// XMMatrixLookAtRH( [in] FXMVECTOR EyePosition, [in] FXMVECTOR FocusPosition, [in] FXMVECTOR UpDirection ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMMatrixLookAtRH")]
	public static XMMATRIX XMMatrixLookAtRH(in FXMVECTOR EyePosition, in FXMVECTOR FocusPosition, in FXMVECTOR UpDirection)
	{
		XMVECTOR NegEyeDirection = XMVectorSubtract(EyePosition, FocusPosition);
		return XMMatrixLookToLH(EyePosition, NegEyeDirection, UpDirection);
	}

	/// <summary>Builds a view matrix for a left-handed coordinate system using a camera position, an up direction, and a camera direction.</summary>
	/// <param name="EyePosition">Position of the camera.</param>
	/// <param name="EyeDirection">Direction of the camera.</param>
	/// <param name="UpDirection">Up direction of the camera, typically &lt; 0.0f, 1.0f, 0.0f &gt;.</param>
	/// <returns>Returns a view matrix that transforms a point from world space into view space.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmmatrixlooktolh XMMATRIX XM_CALLCONV
	// XMMatrixLookToLH( [in] FXMVECTOR EyePosition, [in] FXMVECTOR EyeDirection, [in] FXMVECTOR UpDirection ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMMatrixLookToLH")]
	public static XMMATRIX XMMatrixLookToLH(in FXMVECTOR EyePosition, in FXMVECTOR EyeDirection, in FXMVECTOR UpDirection)
	{
		if (XMVector3Equal(EyeDirection, XMVectorZero())) throw new ArgumentException("EyeDirection cannot be zero.", nameof(EyeDirection));
		if (XMVector3IsInfinite(EyeDirection)) throw new ArgumentException("EyeDirection cannot be infinite.", nameof(EyeDirection));
		if (XMVector3Equal(UpDirection, XMVectorZero())) throw new ArgumentException("UpDirection cannot be zero.", nameof(UpDirection));
		if (XMVector3IsInfinite(UpDirection)) throw new ArgumentException("UpDirection cannot be infinite.", nameof(UpDirection));

		XMVECTOR R2 = XMVector3Normalize(EyeDirection);

		XMVECTOR R0 = XMVector3Cross(UpDirection, R2);
		R0 = XMVector3Normalize(R0);

		XMVECTOR R1 = XMVector3Cross(R2, R0);

		XMVECTOR NegEyePosition = XMVectorNegate(EyePosition);

		XMVECTOR D0 = XMVector3Dot(R0, NegEyePosition);
		XMVECTOR D1 = XMVector3Dot(R1, NegEyePosition);
		XMVECTOR D2 = XMVector3Dot(R2, NegEyePosition);

		return XMMatrixTranspose(new(XMVectorSelect(D0, R0, XMVECTOR.g_XMSelect1110), XMVectorSelect(D1, R1, XMVECTOR.g_XMSelect1110),
			XMVectorSelect(D2, R2, XMVECTOR.g_XMSelect1110), XMVECTOR.g_XMIdentityR3));
	}

	/// <summary>Builds a view matrix for a right-handed coordinate system using a camera position, an up direction, and a camera direction.</summary>
	/// <param name="EyePosition">Position of the camera.</param>
	/// <param name="EyeDirection">Direction of the camera.</param>
	/// <param name="UpDirection">Up direction of the camera, typically &lt; 0.0f, 1.0f, 0.0f &gt;.</param>
	/// <returns>Returns a view matrix that transforms a point from world space into view space.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmmatrixlooktorh XMMATRIX XM_CALLCONV
	// XMMatrixLookToRH( [in] FXMVECTOR EyePosition, [in] FXMVECTOR EyeDirection, [in] FXMVECTOR UpDirection ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMMatrixLookToRH")]
	public static XMMATRIX XMMatrixLookToRH(in FXMVECTOR EyePosition, in FXMVECTOR EyeDirection, in FXMVECTOR UpDirection)
	{
		XMVECTOR NegEyeDirection = XMVectorNegate(EyeDirection);
		return XMMatrixLookToLH(EyePosition, NegEyeDirection, UpDirection);
	}

	/// <summary>Computes the product of two matrices.</summary>
	/// <param name="M1">First matrix to multiply.</param>
	/// <param name="M2">Second matrix to multiply.</param>
	/// <returns>Returns the product of <i>M1</i> and <i>M2</i>.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmmatrixmultiply XMMATRIX XMMatrixMultiply( [in]
	// FXMMATRIX M1, [in] CXMMATRIX M2 );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMMatrixMultiply")]
	public static XMMATRIX XMMatrixMultiply(this FXMMATRIX M1, in CXMMATRIX M2)
	{
		XMMATRIX mResult = default;
		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				float sum = 0f;
				for (int k = 0; k < 4; k++)
					sum += M1[i, k] * M2[k, j];
				mResult[i, j] = sum;
			}
		}
		return mResult;
	}

	/// <summary>Computes the transpose of the product of two matrices.</summary>
	/// <param name="M1">First matrix to multiply.</param>
	/// <param name="M2">Second matrix to multiply.</param>
	/// <returns>Returns the transpose of the product of <i>M1</i> and <i>M2</i>.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmmatrixmultiplytranspose XMMATRIX
	// XMMatrixMultiplyTranspose( [in] FXMMATRIX M1, [in] CXMMATRIX M2 );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMMatrixMultiplyTranspose")]
	public static XMMATRIX XMMatrixMultiplyTranspose(this FXMMATRIX M1, in CXMMATRIX M2)
	{
		XMMATRIX mResult = default;
		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				float sum = 0f;
				for (int k = 0; k < 4; k++)
					sum += M1[i, k] * M2[j, k];
				mResult[i, j] = sum;
			}
		}
		return mResult;
	}

	/// <summary>Builds an orthogonal projection matrix for a left-handed coordinate system.</summary>
	/// <param name="ViewWidth">Width of the frustum at the near clipping plane.</param>
	/// <param name="ViewHeight">Height of the frustum at the near clipping plane.</param>
	/// <param name="NearZ">Distance to the near clipping plane.</param>
	/// <param name="FarZ">Distance to the far clipping plane.</param>
	/// <returns>Returns the orthogonal projection matrix.</returns>
	/// <remarks>
	/// <para>
	/// For typical usage, <i>NearZ</i> is less than <i>FarZ</i>. However, if you flip these values so <i>FarZ</i> is less than
	/// <i>NearZ</i>, the result is an inverted z buffer (also known as a "reverse z buffer") which can provide increased floating-point precision.
	/// </para>
	/// <para><i>NearZ</i> and <i>FarZ</i> cannot be the same value and must be greater than 0.</para>
	/// <para>All the parameters of <b>XMMatrixOrthographicLH</b> are distances in camera space.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmmatrixorthographiclh XMMATRIX XM_CALLCONV
	// XMMatrixOrthographicLH( [in] float ViewWidth, [in] float ViewHeight, [in] float NearZ, [in] float FarZ ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMMatrixOrthographicLH")]
	public static XMMATRIX XMMatrixOrthographicLH(float ViewWidth, float ViewHeight, float NearZ, float FarZ)
	{
		if (XMScalarNearEqual(ViewWidth, 0.0f, 0.00001f)) throw new ArgumentException("Cannot be close to zero.", nameof(ViewWidth));
		if (XMScalarNearEqual(ViewHeight, 0.0f, 0.00001f)) throw new ArgumentException("Cannot be close to zero.", nameof(ViewWidth));
		if (XMScalarNearEqual(FarZ, NearZ, 0.00001f)) throw new ArgumentException("Cannot be close to NearZ.", nameof(FarZ));

		float fRange = 1.0f / (FarZ - NearZ);

		return new(2.0f / ViewWidth, 0.0f, 0.0f, 0.0f,
			0.0f, 2.0f / ViewHeight, 0.0f, 0.0f,
			0.0f, 0.0f, fRange, 0.0f,
			0.0f, 0.0f, -fRange * NearZ, 1.0f);
	}

	/// <summary>Builds a custom orthogonal projection matrix for a left-handed coordinate system.</summary>
	/// <param name="ViewLeft">Minimum x-value of the view volume.</param>
	/// <param name="ViewRight">Maximum x-value of the view volume.</param>
	/// <param name="ViewBottom">Minimum y-value of the view volume.</param>
	/// <param name="ViewTop">Maximum y-value of the view volume.</param>
	/// <param name="NearZ">Distance to the near clipping plane.</param>
	/// <param name="FarZ">Distance to the far clipping plane.</param>
	/// <returns>Returns the custom orthogonal projection matrix.</returns>
	/// <remarks>
	/// <para>
	/// For typical usage, <i>NearZ</i> is less than <i>FarZ</i>. However, if you flip these values so <i>FarZ</i> is less than
	/// <i>NearZ</i>, the result is an inverted z buffer (also known as a "reverse z buffer") which can provide increased floating-point precision.
	/// </para>
	/// <para><i>NearZ</i> and <i>FarZ</i> cannot be the same value and must be greater than 0.</para>
	/// <para>All the parameters of <b>XMMatrixOrthographicOffCenterLH</b> are distances in camera space.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmmatrixorthographicoffcenterlh XMMATRIX XM_CALLCONV
	// XMMatrixOrthographicOffCenterLH( [in] float ViewLeft, [in] float ViewRight, [in] float ViewBottom, [in] float ViewTop, [in] float
	// NearZ, [in] float FarZ ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMMatrixOrthographicOffCenterLH")]
	public static XMMATRIX XMMatrixOrthographicOffCenterLH(float ViewLeft, float ViewRight, float ViewBottom, float ViewTop, float NearZ, float FarZ)
	{
		if (XMScalarNearEqual(ViewRight, ViewLeft, 0.00001f)) throw new ArgumentException("Cannot be close to ViewRight.", nameof(ViewRight));
		if (XMScalarNearEqual(ViewTop, ViewBottom, 0.00001f)) throw new ArgumentException("Cannot be close to ViewTop.", nameof(ViewTop));
		if (XMScalarNearEqual(FarZ, NearZ, 0.00001f)) throw new ArgumentException("Cannot be close to NearZ.", nameof(FarZ));

		float ReciprocalWidth = 1.0f / (ViewRight - ViewLeft);
		float ReciprocalHeight = 1.0f / (ViewTop - ViewBottom);
		float fRange = 1.0f / (FarZ - NearZ);

		return new(ReciprocalWidth + ReciprocalWidth, 0.0f, 0.0f, 0.0f,
			0.0f, ReciprocalHeight + ReciprocalHeight, 0.0f, 0.0f,
			0.0f, 0.0f, fRange, 0.0f,
			-(ViewLeft + ViewRight) * ReciprocalWidth, -(ViewTop + ViewBottom) * ReciprocalHeight, -fRange * NearZ, 1.0f);
	}

	/// <summary>Builds a custom orthogonal projection matrix for a right-handed coordinate system.</summary>
	/// <param name="ViewLeft">Minimum x-value of the view volume.</param>
	/// <param name="ViewRight">Maximum x-value of the view volume.</param>
	/// <param name="ViewBottom">Minimum y-value of the view volume.</param>
	/// <param name="ViewTop">Maximum y-value of the view volume.</param>
	/// <param name="NearZ">Distance to the near clipping plane.</param>
	/// <param name="FarZ">Distance to the far clipping plane.</param>
	/// <returns>Returns the custom orthogonal projection matrix.</returns>
	/// <remarks>
	/// <para>
	/// For typical usage, <i>NearZ</i> is less than <i>FarZ</i>. However, if you flip these values so <i>FarZ</i> is less than
	/// <i>NearZ</i>, the result is an inverted z buffer (also known as a "reverse z buffer") which can provide increased floating-point precision.
	/// </para>
	/// <para><i>NearZ</i> and <i>FarZ</i> cannot be the same value and must be greater than 0.</para>
	/// <para>All the parameters of <b>XMMatrixOrthographicOffCenterRH</b> are distances in camera space.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmmatrixorthographicoffcenterrh XMMATRIX XM_CALLCONV
	// XMMatrixOrthographicOffCenterRH( [in] float ViewLeft, [in] float ViewRight, [in] float ViewBottom, [in] float ViewTop, [in] float
	// NearZ, [in] float FarZ ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMMatrixOrthographicOffCenterRH")]
	public static XMMATRIX XMMatrixOrthographicOffCenterRH(float ViewLeft, float ViewRight, float ViewBottom, float ViewTop, float NearZ, float FarZ)
	{
		if (XMScalarNearEqual(ViewRight, ViewLeft, 0.00001f)) throw new ArgumentException("Cannot be close to ViewRight.", nameof(ViewRight));
		if (XMScalarNearEqual(ViewTop, ViewBottom, 0.00001f)) throw new ArgumentException("Cannot be close to ViewTop.", nameof(ViewTop));
		if (XMScalarNearEqual(FarZ, NearZ, 0.00001f)) throw new ArgumentException("Cannot be close to NearZ.", nameof(FarZ));

		float ReciprocalWidth = 1.0f / (ViewRight - ViewLeft);
		float ReciprocalHeight = 1.0f / (ViewTop - ViewBottom);
		float fRange = 1.0f / (NearZ - FarZ);

		return new(new(ReciprocalWidth + ReciprocalWidth, 0f, 0f, 0f), new(0f, ReciprocalHeight + ReciprocalHeight, 0f, 0f),
			new(0f, 0f, fRange, 0f), new(-(ViewLeft + ViewRight) * ReciprocalWidth, -(ViewTop + ViewBottom) * ReciprocalHeight, fRange * NearZ, 1f));
	}

	/// <summary>Builds an orthogonal projection matrix for a right-handed coordinate system.</summary>
	/// <param name="ViewWidth">Width of the frustum at the near clipping plane.</param>
	/// <param name="ViewHeight">Height of the frustum at the near clipping plane.</param>
	/// <param name="NearZ">Distance to the near clipping plane.</param>
	/// <param name="FarZ">Distance to the far clipping plane.</param>
	/// <returns>Returns the orthogonal projection matrix.</returns>
	/// <remarks>
	/// <para>
	/// For typical usage, <i>NearZ</i> is less than <i>FarZ</i>. However, if you flip these values so <i>FarZ</i> is less than
	/// <i>NearZ</i>, the result is an inverted z buffer (also known as a "reverse z buffer") which can provide increased floating-point precision.
	/// </para>
	/// <para><i>NearZ</i> and <i>FarZ</i> cannot be the same value and must be greater than 0.</para>
	/// <para>All the parameters of <b>XMMatrixOrthographicRH</b> are distances in camera space.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmmatrixorthographicrh XMMATRIX XM_CALLCONV
	// XMMatrixOrthographicRH( [in] float ViewWidth, [in] float ViewHeight, [in] float NearZ, [in] float FarZ ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMMatrixOrthographicRH")]
	public static XMMATRIX XMMatrixOrthographicRH(float ViewWidth, float ViewHeight, float NearZ, float FarZ)
	{
		if (XMScalarNearEqual(ViewWidth, 0.0f, 0.00001f)) throw new ArgumentException("Cannot be close to zero.", nameof(ViewWidth));
		if (XMScalarNearEqual(ViewHeight, 0.0f, 0.00001f)) throw new ArgumentException("Cannot be close to zero.", nameof(ViewWidth));
		if (XMScalarNearEqual(FarZ, NearZ, 0.00001f)) throw new ArgumentException("Cannot be close to NearZ.", nameof(FarZ));

		float fRange = 1.0f / (NearZ - FarZ);

		return new(2.0f / ViewWidth, 0.0f, 0.0f, 0.0f,
			0.0f, 2.0f / ViewHeight, 0.0f, 0.0f,
			0.0f, 0.0f, fRange, 0.0f,
			0.0f, 0.0f, fRange * NearZ, 1.0f);
	}

	/// <summary>Builds a left-handed perspective projection matrix based on a field of view.</summary>
	/// <param name="FovAngleY">Top-down field-of-view angle in radians.</param>
	/// <param name="AspectRatio">Aspect ratio of view-space X:Y.</param>
	/// <param name="NearZ">Distance to the near clipping plane. Must be greater than zero.</param>
	/// <param name="FarZ">Distance to the far clipping plane. Must be greater than zero.</param>
	/// <returns>Returns the perspective projection matrix.</returns>
	/// <remarks>
	/// <para>
	/// For typical usage, <i>NearZ</i> is less than <i>FarZ</i>. However, if you flip these values so <i>FarZ</i> is less than
	/// <i>NearZ</i>, the result is an inverted z buffer (also known as a "reverse z buffer") which can provide increased floating-point precision.
	/// </para>
	/// <para><i>NearZ</i> and <i>FarZ</i> cannot be the same value and must be greater than 0.</para>
	/// <para>
	/// The default <i>AspectRatio</i> axis is horizontal, but recalculating <i>FovAngleY</i> with <i>AspectRatio</i> controls the view
	/// scale direction: 2.0 * atan(tan(FovAngleY * 0.5) / AspectRatio).
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmmatrixperspectivefovlh XMMATRIX XM_CALLCONV
	// XMMatrixPerspectiveFovLH( [in] float FovAngleY, [in] float AspectRatio, [in] float NearZ, [in] float FarZ ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMMatrixPerspectiveFovLH")]
	public static XMMATRIX XMMatrixPerspectiveFovLH(float FovAngleY, float AspectRatio, float NearZ, float FarZ)
	{
		if (NearZ <= 0f || FarZ <= 0f) throw new ArgumentException("NearZ and FarZ must be greater than zero.", nameof(NearZ));
		if (XMScalarNearEqual(FovAngleY, 0.0f, 0.00001f)) throw new ArgumentException("Cannot be close to zero.", nameof(FovAngleY));
		if (XMScalarNearEqual(AspectRatio, 0.0f, 0.00001f)) throw new ArgumentException("Cannot be close to zero.", nameof(AspectRatio));
		if (XMScalarNearEqual(FarZ, NearZ, 0.00001f)) throw new ArgumentException("Cannot be close to NearZ.", nameof(FarZ));

		XMScalarSinCos(out var SinFov, out var CosFov, 0.5f * FovAngleY);

		float Height = CosFov / SinFov;
		float Width = Height / AspectRatio;
		float fRange = FarZ / (FarZ - NearZ);

		return new(Width, 0.0f, 0.0f, 0.0f, 0.0f, Height, 0.0f, 0.0f, 0.0f, 0.0f, fRange, 1.0f, 0.0f, 0.0f, -fRange * NearZ, 0.0f);
	}

	/// <summary>Builds a right-handed perspective projection matrix based on a field of view.</summary>
	/// <param name="FovAngleY">Top-down field-of-view angle in radians.</param>
	/// <param name="AspectRatio">Aspect ratio of view-space X:Y.</param>
	/// <param name="NearZ">Distance to the near clipping plane. Must be greater than zero.</param>
	/// <param name="FarZ">Distance to the far clipping plane. Must be greater than zero.</param>
	/// <returns>Returns the perspective projection matrix.</returns>
	/// <remarks>
	/// <para>
	/// For typical usage, <i>NearZ</i> is less than <i>FarZ</i>. However, if you flip these values so <i>FarZ</i> is less than
	/// <i>NearZ</i>, the result is an inverted z buffer (also known as a "reverse z buffer") which can provide increased floating-point precision.
	/// </para>
	/// <para><i>NearZ</i> and <i>FarZ</i> cannot be the same value and must be greater than 0.</para>
	/// <para>
	/// The default <i>AspectRatio</i> axis is horizontal, but recalculating <i>FovAngleY</i> with <i>AspectRatio</i> controls the view
	/// scale direction: 2.0 * atan(tan(FovAngleY * 0.5) / AspectRatio).
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmmatrixperspectivefovrh XMMATRIX XM_CALLCONV
	// XMMatrixPerspectiveFovRH( [in] float FovAngleY, [in] float AspectRatio, [in] float NearZ, [in] float FarZ ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMMatrixPerspectiveFovRH")]
	public static XMMATRIX XMMatrixPerspectiveFovRH(float FovAngleY, float AspectRatio, float NearZ, float FarZ)
	{
		if (NearZ <= 0f || FarZ <= 0f) throw new ArgumentException("NearZ and FarZ must be greater than zero.", nameof(NearZ));
		if (XMScalarNearEqual(FovAngleY, 0.0f, 0.00001f)) throw new ArgumentException("Cannot be close to zero.", nameof(FovAngleY));
		if (XMScalarNearEqual(AspectRatio, 0.0f, 0.00001f)) throw new ArgumentException("Cannot be close to zero.", nameof(AspectRatio));
		if (XMScalarNearEqual(FarZ, NearZ, 0.00001f)) throw new ArgumentException("Cannot be close to NearZ.", nameof(FarZ));

		XMScalarSinCos(out var SinFov, out var CosFov, 0.5f * FovAngleY);

		float Height = CosFov / SinFov;
		float Width = Height / AspectRatio;
		float fRange = FarZ / (NearZ - FarZ);

		return new(Width, 0.0f, 0.0f, 0.0f, 0.0f, Height, 0.0f, 0.0f, 0.0f, 0.0f, fRange, -1.0f, 0.0f, 0.0f, fRange * NearZ, 0.0f);
	}

	/// <summary>Builds a left-handed perspective projection matrix.</summary>
	/// <param name="ViewWidth">Width of the frustum at the near clipping plane.</param>
	/// <param name="ViewHeight">Height of the frustum at the near clipping plane.</param>
	/// <param name="NearZ">Distance to the near clipping plane. Must be greater than zero.</param>
	/// <param name="FarZ">Distance to the far clipping plane. Must be greater than zero.</param>
	/// <returns>Returns the perspective projection matrix.</returns>
	/// <remarks>
	/// <para>
	/// For typical usage, <i>NearZ</i> is less than <i>FarZ</i>. However, if you flip these values so <i>FarZ</i> is less than
	/// <i>NearZ</i>, the result is an inverted z buffer (also known as a "reverse z buffer") which can provide increased floating-point precision.
	/// </para>
	/// <para><i>NearZ</i> and <i>FarZ</i> cannot be the same value and must be greater than 0.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmmatrixperspectivelh XMMATRIX XM_CALLCONV
	// XMMatrixPerspectiveLH( [in] float ViewWidth, [in] float ViewHeight, [in] float NearZ, [in] float FarZ ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMMatrixPerspectiveLH")]
	public static XMMATRIX XMMatrixPerspectiveLH(float ViewWidth, float ViewHeight, float NearZ, float FarZ)
	{
		if (NearZ <= 0f || FarZ <= 0f) throw new ArgumentException("NearZ and FarZ must be greater than zero.", nameof(NearZ));
		if (XMScalarNearEqual(ViewWidth, 0.0f, 0.00001f)) throw new ArgumentException("Cannot be close to zero.", nameof(ViewWidth));
		if (XMScalarNearEqual(ViewHeight, 0.0f, 0.00001f)) throw new ArgumentException("Cannot be close to zero.", nameof(ViewHeight));
		if (XMScalarNearEqual(FarZ, NearZ, 0.00001f)) throw new ArgumentException("Cannot be close to NearZ.", nameof(FarZ));

		float TwoNearZ = NearZ + NearZ;
		float fRange = FarZ / (FarZ - NearZ);

		return new(TwoNearZ / ViewWidth, 0f, 0f, 0f, 0f, TwoNearZ / ViewHeight, 0f, 0f, 0f, 0f, fRange, 1f, 0f, 0f, -fRange * NearZ, 0f);
	}

	/// <summary>Builds a custom version of a left-handed perspective projection matrix.</summary>
	/// <param name="ViewLeft">The x-coordinate of the left side of the clipping frustum at the near clipping plane.</param>
	/// <param name="ViewRight">The x-coordinate of the right side of the clipping frustum at the near clipping plane.</param>
	/// <param name="ViewBottom">The y-coordinate of the bottom side of the clipping frustum at the near clipping plane.</param>
	/// <param name="ViewTop">The y-coordinate of the top side of the clipping frustum at the near clipping plane.</param>
	/// <param name="NearZ">Distance to the near clipping plane. Must be greater than zero.</param>
	/// <param name="FarZ">Distance to the far clipping plane. Must be greater than zero.</param>
	/// <returns>Returns the custom perspective projection matrix.</returns>
	/// <remarks>
	/// <para>
	/// For typical usage, <i>NearZ</i> is less than <i>FarZ</i>. However, if you flip these values so <i>FarZ</i> is less than
	/// <i>NearZ</i>, the result is an inverted z buffer (also known as a "reverse z buffer") which can provide increased floating-point precision.
	/// </para>
	/// <para><i>NearZ</i> and <i>FarZ</i> cannot be the same value and must be greater than 0.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmmatrixperspectiveoffcenterlh XMMATRIX XM_CALLCONV
	// XMMatrixPerspectiveOffCenterLH( [in] float ViewLeft, [in] float ViewRight, [in] float ViewBottom, [in] float ViewTop, [in] float
	// NearZ, [in] float FarZ ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMMatrixPerspectiveOffCenterLH")]
	public static XMMATRIX XMMatrixPerspectiveOffCenterLH(float ViewLeft, float ViewRight, float ViewBottom, float ViewTop, float NearZ, float FarZ)
	{
		if (NearZ <= 0f || FarZ <= 0f) throw new ArgumentException("NearZ and FarZ must be greater than zero.", nameof(NearZ));
		if (XMScalarNearEqual(ViewRight, 0.0f, 0.00001f)) throw new ArgumentException("Cannot be close to zero.", nameof(ViewRight));
		if (XMScalarNearEqual(ViewTop, 0.0f, 0.00001f)) throw new ArgumentException("Cannot be close to zero.", nameof(ViewTop));
		if (XMScalarNearEqual(FarZ, NearZ, 0.00001f)) throw new ArgumentException("Cannot be close to NearZ.", nameof(FarZ));

		float TwoNearZ = NearZ + NearZ;
		float ReciprocalWidth = 1.0f / (ViewRight - ViewLeft);
		float ReciprocalHeight = 1.0f / (ViewTop - ViewBottom);
		float fRange = FarZ / (FarZ - NearZ);

		return new(TwoNearZ * ReciprocalWidth, 0.0f, 0.0f, 0.0f,
			0.0f, TwoNearZ * ReciprocalHeight, 0.0f, 0.0f,
			-(ViewLeft + ViewRight) * ReciprocalWidth, -(ViewTop + ViewBottom) * ReciprocalHeight, fRange, 1.0f,
			0.0f, 0.0f, -fRange * NearZ, 0.0f);
	}

	/// <summary>Builds a custom version of a right-handed perspective projection matrix.</summary>
	/// <param name="ViewLeft">The x-coordinate of the left side of the clipping frustum at the near clipping plane.</param>
	/// <param name="ViewRight">The x-coordinate of the right side of the clipping frustum at the near clipping plane.</param>
	/// <param name="ViewBottom">The y-coordinate of the bottom side of the clipping frustum at the near clipping plane.</param>
	/// <param name="ViewTop">The y-coordinate of the top side of the clipping frustum at the near clipping plane.</param>
	/// <param name="NearZ">Distance to the near clipping plane. Must be greater than zero.</param>
	/// <param name="FarZ">Distance to the far clipping plane. Must be greater than zero.</param>
	/// <returns>Returns the custom perspective projection matrix.</returns>
	/// <remarks>
	/// <para>
	/// For typical usage, <i>NearZ</i> is less than <i>FarZ</i>. However, if you flip these values so <i>FarZ</i> is less than
	/// <i>NearZ</i>, the result is an inverted z buffer (also known as a "reverse z buffer") which can provide increased floating-point precision.
	/// </para>
	/// <para><i>NearZ</i> and <i>FarZ</i> cannot be the same value and must be greater than 0.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmmatrixperspectiveoffcenterrh XMMATRIX XM_CALLCONV
	// XMMatrixPerspectiveOffCenterRH( [in] float ViewLeft, [in] float ViewRight, [in] float ViewBottom, [in] float ViewTop, [in] float
	// NearZ, [in] float FarZ ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMMatrixPerspectiveOffCenterRH")]
	public static XMMATRIX XMMatrixPerspectiveOffCenterRH(float ViewLeft, float ViewRight, float ViewBottom, float ViewTop, float NearZ, float FarZ)
	{
		if (NearZ <= 0f || FarZ <= 0f) throw new ArgumentException("NearZ and FarZ must be greater than zero.", nameof(NearZ));
		if (XMScalarNearEqual(ViewRight, 0.0f, 0.00001f)) throw new ArgumentException("Cannot be close to zero.", nameof(ViewRight));
		if (XMScalarNearEqual(ViewTop, 0.0f, 0.00001f)) throw new ArgumentException("Cannot be close to zero.", nameof(ViewTop));
		if (XMScalarNearEqual(FarZ, NearZ, 0.00001f)) throw new ArgumentException("Cannot be close to NearZ.", nameof(FarZ));

		float TwoNearZ = NearZ + NearZ;
		float ReciprocalWidth = 1.0f / (ViewRight - ViewLeft);
		float ReciprocalHeight = 1.0f / (ViewTop - ViewBottom);
		float fRange = FarZ / (NearZ - FarZ);

		return new(TwoNearZ * ReciprocalWidth, 0.0f, 0.0f, 0.0f,
			0.0f, TwoNearZ * ReciprocalHeight, 0.0f, 0.0f,
			(ViewLeft + ViewRight) * ReciprocalWidth, (ViewTop + ViewBottom) * ReciprocalHeight, fRange, -1.0f,
			0.0f, 0.0f, fRange * NearZ, 0.0f);
	}

	/// <summary>Builds a right-handed perspective projection matrix.</summary>
	/// <param name="ViewWidth">Width of the frustum at the near clipping plane.</param>
	/// <param name="ViewHeight">Height of the frustum at the near clipping plane.</param>
	/// <param name="NearZ">Distance to the near clipping plane. Must be greater than zero.</param>
	/// <param name="FarZ">Distance to the far clipping plane. Must be greater than zero.</param>
	/// <returns>Returns the perspective projection matrix.</returns>
	/// <remarks>
	/// <para>
	/// For typical usage, <i>NearZ</i> is less than <i>FarZ</i>. However, if you flip these values so <i>FarZ</i> is less than
	/// <i>NearZ</i>, the result is an inverted z buffer (also known as a "reverse z buffer") which can provide increased floating-point precision.
	/// </para>
	/// <para><i>NearZ</i> and <i>FarZ</i> cannot be the same value and must be greater than 0.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmmatrixperspectiverh XMMATRIX XM_CALLCONV
	// XMMatrixPerspectiveRH( [in] float ViewWidth, [in] float ViewHeight, [in] float NearZ, [in] float FarZ ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMMatrixPerspectiveRH")]
	public static XMMATRIX XMMatrixPerspectiveRH(float ViewWidth, float ViewHeight, float NearZ, float FarZ)
	{
		if (NearZ <= 0f || FarZ <= 0f) throw new ArgumentException("NearZ and FarZ must be greater than zero.", nameof(NearZ));
		if (XMScalarNearEqual(ViewWidth, 0.0f, 0.00001f)) throw new ArgumentException("Cannot be close to zero.", nameof(ViewWidth));
		if (XMScalarNearEqual(ViewHeight, 0.0f, 0.00001f)) throw new ArgumentException("Cannot be close to zero.", nameof(ViewHeight));
		if (XMScalarNearEqual(FarZ, NearZ, 0.00001f)) throw new ArgumentException("Cannot be close to NearZ.", nameof(FarZ));

		float TwoNearZ = NearZ + NearZ;
		float fRange = FarZ / (NearZ - FarZ);

		return new(TwoNearZ / ViewWidth, 0f, 0f, 0f, 0f, TwoNearZ / ViewHeight, 0f, 0f, 0f, 0f, fRange, -1f, 0f, 0f, fRange * NearZ, 0f);
	}

	/// <summary>Builds a transformation matrix designed to reflect vectors through a given plane.</summary>
	/// <param name="ReflectionPlane">Plane to reflect through.</param>
	/// <returns>Returns the transformation matrix.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmmatrixreflect XMMATRIX XM_CALLCONV XMMatrixReflect(
	// [in] FXMVECTOR ReflectionPlane ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMMatrixReflect")]
	public static XMMATRIX XMMatrixReflect(in FXMVECTOR ReflectionPlane)
	{
		if (XMVector3Equal(ReflectionPlane, XMVectorZero())) throw new ArgumentException("Plane cannot be zero.", nameof(ReflectionPlane));
		if (XMPlaneIsInfinite(ReflectionPlane)) throw new ArgumentException("Plane cannot be infinite.", nameof(ReflectionPlane));

		XMVECTORF32 NegativeTwo = new(-2.0f, -2.0f, -2.0f, 0.0f);

		XMVECTOR P = XMPlaneNormalize(ReflectionPlane);
		XMVECTOR S = XMVectorMultiply(P, NegativeTwo);

		XMVECTOR A = XMVectorSplatX(P);
		XMVECTOR B = XMVectorSplatY(P);
		XMVECTOR C = XMVectorSplatZ(P);
		XMVECTOR D = XMVectorSplatW(P);

		return new(XMVectorMultiplyAdd(A, S, XMVECTOR.g_XMIdentityR0), XMVectorMultiplyAdd(B, S, XMVECTOR.g_XMIdentityR1),
			XMVectorMultiplyAdd(C, S, XMVECTOR.g_XMIdentityR2), XMVectorMultiplyAdd(D, S, XMVECTOR.g_XMIdentityR3));
	}

	/// <summary>Builds a matrix that rotates around an arbitrary axis.</summary>
	/// <param name="Axis">Vector describing the axis of rotation.</param>
	/// <param name="Angle">
	/// Angle of rotation in radians. Angles are measured clockwise when looking along the rotation axis toward the origin.
	/// </param>
	/// <returns>Returns the rotation matrix.</returns>
	/// <remarks>
	/// <para>
	/// If <i>Axis</i> is a normalized vector, it is faster to use the <c>XMMatrixRotationNormal</c> function to build this type of matrix.
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmmatrixrotationaxis XMMATRIX XM_CALLCONV
	// XMMatrixRotationAxis( [in] FXMVECTOR Axis, [in] float Angle ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMMatrixRotationAxis")]
	public static XMMATRIX XMMatrixRotationAxis(this FXMVECTOR Axis, float Angle)
	{
		if (XMVector3Equal(Axis, XMVectorZero())) throw new ArgumentException("Axis cannot be zero.", nameof(Axis));
		if (XMVector3IsInfinite(Axis)) throw new ArgumentException("Axis cannot be infinite.", nameof(Axis));

		XMVECTOR Normal = XMVector3Normalize(Axis);
		return XMMatrixRotationNormal(Normal, Angle);
	}

	/// <summary>Builds a matrix that rotates around an arbitrary normal vector.</summary>
	/// <param name="NormalAxis">Normal vector describing the axis of rotation.</param>
	/// <param name="Angle">
	/// Angle of rotation in radians. Angles are measured clockwise when looking along the rotation axis toward the origin.
	/// </param>
	/// <returns>Returns the rotation matrix.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmmatrixrotationnormal XMMATRIX XM_CALLCONV
	// XMMatrixRotationNormal( [in] FXMVECTOR NormalAxis, [in] float Angle ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMMatrixRotationNormal")]
	public static XMMATRIX XMMatrixRotationNormal(this FXMVECTOR NormalAxis, float Angle)
	{
		XMScalarSinCos(out var fSinAngle, out var fCosAngle, Angle);

		XMVECTOR A = XMVectorSet(fSinAngle, fCosAngle, 1.0f - fCosAngle, 0.0f);

		XMVECTOR C2 = XMVectorSplatZ(A);
		XMVECTOR C1 = XMVectorSplatY(A);
		XMVECTOR C0 = XMVectorSplatX(A);

		XMVECTOR N0 = XMVectorSwizzle(NormalAxis, XM_SWIZZLE_Y, XM_SWIZZLE_Z, XM_SWIZZLE_X, XM_SWIZZLE_W);
		XMVECTOR N1 = XMVectorSwizzle(NormalAxis, XM_SWIZZLE_Z, XM_SWIZZLE_X, XM_SWIZZLE_Y, XM_SWIZZLE_W);

		XMVECTOR V0 = XMVectorMultiply(C2, N0);
		V0 = XMVectorMultiply(V0, N1);

		XMVECTOR R0 = XMVectorMultiply(C2, NormalAxis);
		R0 = XMVectorMultiplyAdd(R0, NormalAxis, C1);

		XMVECTOR R1 = XMVectorMultiplyAdd(C0, NormalAxis, V0);
		XMVECTOR R2 = XMVectorNegativeMultiplySubtract(C0, NormalAxis, V0);

		V0 = XMVectorSelect(A, R0, XMVECTOR.g_XMSelect1110);
		XMVECTOR V1 = XMVectorPermute(R1, R2, XM_PERMUTE_0Z, XM_PERMUTE_1Y, XM_PERMUTE_1Z, XM_PERMUTE_0X);
		XMVECTOR V2 = XMVectorPermute(R1, R2, XM_PERMUTE_0Y, XM_PERMUTE_1X, XM_PERMUTE_0Y, XM_PERMUTE_1X);

		XMMATRIX M = new();
		M.r[0] = XMVectorPermute(V0, V1, XM_PERMUTE_0X, XM_PERMUTE_1X, XM_PERMUTE_1Y, XM_PERMUTE_0W);
		M.r[1] = XMVectorPermute(V0, V1, XM_PERMUTE_1Z, XM_PERMUTE_0Y, XM_PERMUTE_1W, XM_PERMUTE_0W);
		M.r[2] = XMVectorPermute(V0, V2, XM_PERMUTE_1X, XM_PERMUTE_1Y, XM_PERMUTE_0Z, XM_PERMUTE_0W);
		M.r[3] = XMVECTOR.g_XMIdentityR3;
		return M;
	}

	/// <summary>Builds a rotation matrix from a quaternion.</summary>
	/// <param name="Quaternion">Quaternion defining the rotation.</param>
	/// <returns>Returns the rotation matrix.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmmatrixrotationquaternion XMMATRIX XM_CALLCONV
	// XMMatrixRotationQuaternion( [in] FXMVECTOR Quaternion ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMMatrixRotationQuaternion")]
	public static XMMATRIX XMMatrixRotationQuaternion(this FXMVECTOR Quaternion)
	{
		float qx = Quaternion[0];
		float qxx = qx * qx;

		float qy = Quaternion[1];
		float qyy = qy * qy;

		float qz = Quaternion[2];
		float qzz = qz * qz;

		float qw = Quaternion[3];

		return new(new(1.0f - 2.0f * qyy - 2.0f * qzz, 2.0f * qx * qy + 2.0f * qz * qw, 2.0f * qx * qz - 2.0f * qy * qw, 0.0f),
			new(2.0f * qx * qy - 2.0f * qz * qw, 1.0f - 2.0f * qxx - 2.0f * qzz, 2.0f * qy * qz + 2.0f * qx * qw, 0.0f),
			new(2.0f * qx * qz + 2.0f * qy * qw, 2.0f * qy * qz - 2.0f * qx * qw, 1.0f - 2.0f * qxx - 2.0f * qyy, 0.0f),
			XMVECTOR.g_XMIdentityR3);
	}

	/// <summary>Builds a rotation matrix based on a given pitch, yaw, and roll (Euler angles).</summary>
	/// <param name="Pitch">Angle of rotation around the x-axis, in radians.</param>
	/// <param name="Yaw">Angle of rotation around the y-axis, in radians.</param>
	/// <param name="Roll">Angle of rotation around the z-axis, in radians.</param>
	/// <returns>Returns the rotation matrix.</returns>
	/// <remarks>
	/// <para>
	/// Angles are measured clockwise when looking along the rotation axis toward the origin. This is a left-handed coordinate system. To
	/// use right-handed coordinates, negate all three angles.
	/// </para>
	/// <para>
	/// The order of transformations is roll first, then pitch, and then yaw. The rotations are all applied in the global coordinate frame.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// This function takes x-axis, y-axis, and z-axis angles as input parameters. The assignment of the labels pitch to the x-axis, yaw to
	/// the y-axis, and roll to the z-axis is a common one for computer graphics and games, since it matches typical 'view' coordinate
	/// systems. There are of course other ways to assign those labels when using other coordinate systems (for example, roll could be the
	/// x-axis, pitch the y-axis, and yaw the z-axis).
	/// </para>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmmatrixrotationrollpitchyaw XMMATRIX XM_CALLCONV
	// XMMatrixRotationRollPitchYaw( [in] float Pitch, [in] float Yaw, [in] float Roll ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMMatrixRotationRollPitchYaw")]
	public static XMMATRIX XMMatrixRotationRollPitchYaw(float Pitch, float Yaw, float Roll)
	{
		float cp = (float)Math.Cos(Pitch);
		float sp = (float)Math.Sin(Pitch);

		float cy = (float)Math.Cos(Yaw);
		float sy = (float)Math.Sin(Yaw);

		float cr = (float)Math.Cos(Roll);
		float sr = (float)Math.Sin(Roll);

		return new(new(cr * cy + sr * sp * sy, sr * cp, sr * sp * cy - cr * sy, 0.0f),
			new(cr * sp * sy - sr * cy, cr * cp, sr * sy + cr * sp * cy, 0.0f),
			new(cp * sy, -sp, cp * cy, 0.0f),
			new(0.0f, 0.0f, 0.0f, 1.0f));
	}

	/// <summary>Builds a rotation matrix based on a vector containing the Euler angles (pitch, yaw, and roll).</summary>
	/// <param name="Angles">
	/// 3D vector containing the Euler angles in the order x-axis (pitch), then y-axis (yaw), and then z-axis (roll). The W element is ignored.
	/// </param>
	/// <returns>Returns the rotation matrix.</returns>
	/// <remarks>
	/// <para>
	/// Angles are measured clockwise when looking along the rotation axis toward the origin. This is a left-handed coordinate system. To
	/// use right-handed coordinates, negate all three angles.
	/// </para>
	/// <para>
	/// The order of transformations is roll first, then pitch, and then yaw. The rotations are all applied in the global coordinate frame.
	/// </para>
	/// <para>
	/// <para>Note</para>
	/// <para>
	/// This function takes x-axis, y-axis, and z-axis angles as input parameters. The assignment of the labels pitch to the x-axis, yaw to
	/// the y-axis, and roll to the z-axis is a common one for computer graphics and games, since it matches typical 'view' coordinate
	/// systems. There are of course other ways to assign those labels when using other coordinate systems (for example, roll could be the
	/// x-axis, pitch the y-axis, and yaw the z-axis).
	/// </para>
	/// </para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmmatrixrotationrollpitchyawfromvector XMMATRIX
	// XM_CALLCONV XMMatrixRotationRollPitchYawFromVector( [in] FXMVECTOR Angles ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMMatrixRotationRollPitchYawFromVector")]
	public static XMMATRIX XMMatrixRotationRollPitchYawFromVector(this FXMVECTOR Angles)  // <Pitch, Yaw, Roll, undefined>
	{
		float cp = (float)Math.Cos(Angles[0]);
		float sp = (float)Math.Sin(Angles[0]);

		float cy = (float)Math.Cos(Angles[1]);
		float sy = (float)Math.Sin(Angles[1]);

		float cr = (float)Math.Cos(Angles[2]);
		float sr = (float)Math.Sin(Angles[2]);

		return new(new(cr * cy + sr * sp * sy, sr * cp, sr * sp * cy - cr * sy, 0.0f),
			new(cr * sp * sy - sr * cy, cr * cp, sr * sy + cr * sp * cy, 0.0f),
			new(cp * sy, -sp, cp * cy, 0.0f),
			new(0.0f, 0.0f, 0.0f, 1.0f));
	}

	/// <summary>Builds a matrix that rotates around the x-axis.</summary>
	/// <param name="Angle">
	/// Angle of rotation around the x-axis, in radians. Angles are measured clockwise when looking along the rotation axis toward the origin.
	/// </param>
	/// <returns>Returns the rotation matrix.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmmatrixrotationx XMMATRIX XM_CALLCONV
	// XMMatrixRotationX( [in] float Angle ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMMatrixRotationX")]
	public static XMMATRIX XMMatrixRotationX(float Angle)
	{
		XMScalarSinCos(out var fSinAngle, out var fCosAngle, Angle);

		return new(1.0f, 0.0f, 0.0f, 0.0f, 0.0f, fCosAngle, fSinAngle, 0.0f, 0.0f, -fSinAngle, fCosAngle, 0.0f, 0.0f, 0.0f, 0.0f, 1.0f);
	}

	/// <summary>Builds a matrix that rotates around the y-axis.</summary>
	/// <param name="Angle">
	/// Angle of rotation around the y-axis, in radians. Angles are measured clockwise when looking along the rotation axis toward the origin.
	/// </param>
	/// <returns>Returns the rotation matrix.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmmatrixrotationy XMMATRIX XM_CALLCONV
	// XMMatrixRotationY( [in] float Angle ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMMatrixRotationY")]
	public static XMMATRIX XMMatrixRotationY(float Angle)
	{
		XMScalarSinCos(out var fSinAngle, out var fCosAngle, Angle);

		return new(fCosAngle, 0.0f, -fSinAngle, 0.0f, 0.0f, 1.0f, 0.0f, 0.0f, fSinAngle, 0.0f, fCosAngle, 0.0f, 0.0f, 0.0f, 0.0f, 1.0f);
	}

	/// <summary>Builds a matrix that rotates around the z-axis.</summary>
	/// <param name="Angle">
	/// Angle of rotation around the z-axis, in radians. Angles are measured clockwise when looking along the rotation axis toward the origin.
	/// </param>
	/// <returns>Returns the rotation matrix.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmmatrixrotationz XMMATRIX XM_CALLCONV
	// XMMatrixRotationZ( [in] float Angle ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMMatrixRotationZ")]
	public static XMMATRIX XMMatrixRotationZ(float Angle)
	{
		XMScalarSinCos(out var fSinAngle, out var fCosAngle, Angle);

		return new(fCosAngle, fSinAngle, 0.0f, 0.0f, -fSinAngle, fCosAngle, 0.0f, 0.0f, 0.0f, 0.0f, 1.0f, 0.0f, 0.0f, 0.0f, 0.0f, 1.0f);
	}

	/// <summary>Builds a matrix that scales along the x-axis, y-axis, and z-axis.</summary>
	/// <param name="ScaleX">Scaling factor along the x-axis.</param>
	/// <param name="ScaleY">Scaling factor along the y-axis.</param>
	/// <param name="ScaleZ">Scaling factor along the z-axis.</param>
	/// <returns>Returns the scaling matrix.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmmatrixscaling XMMATRIX XM_CALLCONV XMMatrixScaling(
	// [in] float ScaleX, [in] float ScaleY, [in] float ScaleZ ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMMatrixScaling")]
	public static XMMATRIX XMMatrixScaling(float ScaleX, float ScaleY, float ScaleZ) =>
		new(ScaleX, 0.0f, 0.0f, 0.0f, 0.0f, ScaleY, 0.0f, 0.0f, 0.0f, 0.0f, ScaleZ, 0.0f, 0.0f, 0.0f, 0.0f, 1.0f);

	/// <summary>Builds a scaling matrix from a 3D vector.</summary>
	/// <param name="Scale">3D vector describing the scaling along the x-axis, y-axis, and z-axis.</param>
	/// <returns>Returns the scaling matrix.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmmatrixscalingfromvector XMMATRIX XM_CALLCONV
	// XMMatrixScalingFromVector( [in] FXMVECTOR Scale ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMMatrixScalingFromVector")]
	public static XMMATRIX XMMatrixScalingFromVector(this FXMVECTOR Scale) =>
		new(Scale[0], 0.0f, 0.0f, 0.0f, 0.0f, Scale[1], 0.0f, 0.0f, 0.0f, 0.0f, Scale[2], 0.0f, 0.0f, 0.0f, 0.0f, 1.0f);

	/// <summary>Creates a matrix with <b>float</b> values.</summary>
	/// <param name="m00">Value to assign to the (0,0) element.</param>
	/// <param name="m01">Value to assign to the (0,1) element.</param>
	/// <param name="m02">Value to assign to the (0,2) element.</param>
	/// <param name="m03">Value to assign to the (0,3) element.</param>
	/// <param name="m10">Value to assign to the (1,0) element.</param>
	/// <param name="m11">Value to assign to the (1,1) element.</param>
	/// <param name="m12">Value to assign to the (1,2) element.</param>
	/// <param name="m13">Value to assign to the (1,3) element.</param>
	/// <param name="m20">Value to assign to the (2,0) element.</param>
	/// <param name="m21">Value to assign to the (2,1) element.</param>
	/// <param name="m22">Value to assign to the (2,2) element.</param>
	/// <param name="m23">Value to assign to the (2,3) element.</param>
	/// <param name="m30">Value to assign to the (3,0) element.</param>
	/// <param name="m31">Value to assign to the (3,1) element.</param>
	/// <param name="m32">Value to assign to the (3,2) element.</param>
	/// <param name="m33">Value to assign to the (3,3) element.</param>
	/// <returns>Returns the <c>XMMATRIX</c> with the specified elements.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmmatrixset XMMATRIX XM_CALLCONV XMMatrixSet( [in]
	// float m00, [in] float m01, [in] float m02, [in] float m03, [in] float m10, [in] float m11, [in] float m12, [in] float m13, [in] float
	// m20, [in] float m21, [in] float m22, [in] float m23, [in] float m30, [in] float m31, [in] float m32, [in] float m33 ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMMatrixSet")]
	public static XMMATRIX XMMatrixSet(float m00, float m01, float m02, float m03, float m10, float m11, float m12, float m13,
		float m20, float m21, float m22, float m23, float m30, float m31, float m32, float m33) =>
		new(m00, m01, m02, m03, m10, m11, m12, m13, m20, m21, m22, m23, m30, m31, m32, m33);

	/// <summary>Builds a transformation matrix that flattens geometry into a plane.</summary>
	/// <param name="ShadowPlane">Reference plane.</param>
	/// <param name="LightPosition">
	/// 4D vector describing the light's position. If the light's w-component is 0.0f, the ray from the origin to the light represents a
	/// directional light. If it is 1.0f, the light is a point light.
	/// </param>
	/// <returns>Returns the transformation matrix that flattens the geometry into the plane <i>ShadowPlane</i>.</returns>
	/// <remarks>
	/// <para>This function is useful for forming planar-projected shadows from a light source.</para>
	/// </remarks>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmmatrixshadow XMMATRIX XM_CALLCONV XMMatrixShadow(
	// [in] FXMVECTOR ShadowPlane, [in] FXMVECTOR LightPosition ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMMatrixShadow")]
	public static XMMATRIX XMMatrixShadow(in FXMVECTOR ShadowPlane, in FXMVECTOR LightPosition)
	{
		XMVECTOR Select0001 = new(XM_SELECT_0, XM_SELECT_0, XM_SELECT_0, XM_SELECT_1);

		if (XMVector3Equal(ShadowPlane, XMVectorZero())) throw new ArgumentException("Plane cannot be zero.", nameof(ShadowPlane));
		if (XMPlaneIsInfinite(ShadowPlane)) throw new ArgumentException("Plane cannot be infinite.", nameof(ShadowPlane));

		XMVECTOR P = XMPlaneNormalize(ShadowPlane);
		XMVECTOR Dot = XMPlaneDot(P, LightPosition);
		P = XMVectorNegate(P);
		XMVECTOR D = XMVectorSplatW(P);
		XMVECTOR C = XMVectorSplatZ(P);
		XMVECTOR B = XMVectorSplatY(P);
		XMVECTOR A = XMVectorSplatX(P);
		Dot = XMVectorSelect(Select0001, Dot, Select0001);

		XMMATRIX M = new();
		M.r[3] = XMVectorMultiplyAdd(D, LightPosition, Dot);
		Dot = XMVectorRotateLeft(Dot, 1);
		M.r[2] = XMVectorMultiplyAdd(C, LightPosition, Dot);
		Dot = XMVectorRotateLeft(Dot, 1);
		M.r[1] = XMVectorMultiplyAdd(B, LightPosition, Dot);
		Dot = XMVectorRotateLeft(Dot, 1);
		M.r[0] = XMVectorMultiplyAdd(A, LightPosition, Dot);
		return M;
	}

	/// <summary>Builds a transformation matrix.</summary>
	/// <param name="ScalingOrigin">3D vector describing the center of the scaling.</param>
	/// <param name="ScalingOrientationQuaternion">Quaternion describing the orientation of the scaling.</param>
	/// <param name="Scaling">3D vector containing the scaling factors for the x-axis, y-axis, and z-axis.</param>
	/// <param name="RotationOrigin">3D vector describing the center of the rotation.</param>
	/// <param name="RotationQuaternion">Quaternion describing the rotation around the origin indicated by <i>RotationOrigin</i>.</param>
	/// <param name="Translation">3D vector describing the translations along the x-axis, y-axis, and z-axis.</param>
	/// <returns>Returns the transformation matrix.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmmatrixtransformation XMMATRIX XM_CALLCONV
	// XMMatrixTransformation( [in] FXMVECTOR ScalingOrigin, [in] FXMVECTOR ScalingOrientationQuaternion, [in] FXMVECTOR Scaling, [in]
	// GXMVECTOR RotationOrigin, [in] HXMVECTOR RotationQuaternion, [in] HXMVECTOR Translation ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMMatrixTransformation")]
	public static XMMATRIX XMMatrixTransformation(this FXMVECTOR ScalingOrigin, in FXMVECTOR ScalingOrientationQuaternion, in FXMVECTOR Scaling,
		in GXMVECTOR RotationOrigin, in HXMVECTOR RotationQuaternion, in HXMVECTOR Translation)
	{
		// M = Inverse(MScalingOrigin) * Transpose(MScalingOrientation) * MScaling * MScalingOrientation * MScalingOrigin *
		// Inverse(MRotationOrigin) * MRotation * MRotationOrigin * MTranslation;

		XMVECTOR VScalingOrigin = XMVectorSelect(XMVECTOR.g_XMSelect1110, ScalingOrigin, XMVECTOR.g_XMSelect1110);
		XMVECTOR NegScalingOrigin = XMVectorNegate(ScalingOrigin);

		XMMATRIX MScalingOriginI = XMMatrixTranslationFromVector(NegScalingOrigin);
		XMMATRIX MScalingOrientation = XMMatrixRotationQuaternion(ScalingOrientationQuaternion);
		XMMATRIX MScalingOrientationT = XMMatrixTranspose(MScalingOrientation);
		XMMATRIX MScaling = XMMatrixScalingFromVector(Scaling);
		XMVECTOR VRotationOrigin = XMVectorSelect(XMVECTOR.g_XMSelect1110, RotationOrigin, XMVECTOR.g_XMSelect1110);
		XMMATRIX MRotation = XMMatrixRotationQuaternion(RotationQuaternion);
		XMVECTOR VTranslation = XMVectorSelect(XMVECTOR.g_XMSelect1110, Translation, XMVECTOR.g_XMSelect1110);

		XMMATRIX M = XMMatrixMultiply(MScalingOriginI, MScalingOrientationT);
		M = XMMatrixMultiply(M, MScaling);
		M = XMMatrixMultiply(M, MScalingOrientation);
		M.r[3] = XMVectorAdd(M.r[3], VScalingOrigin);
		M.r[3] = XMVectorSubtract(M.r[3], VRotationOrigin);
		M = XMMatrixMultiply(M, MRotation);
		M.r[3] = XMVectorAdd(M.r[3], VRotationOrigin);
		M.r[3] = XMVectorAdd(M.r[3], VTranslation);
		return M;
	}

	/// <summary>Builds a 2D transformation matrix in the xy plane.</summary>
	/// <param name="ScalingOrigin">2D vector describing the center of the scaling.</param>
	/// <param name="ScalingOrientation">Scaling rotation factor.</param>
	/// <param name="Scaling">2D vector containing the scaling factors for the x-axis and y-axis.</param>
	/// <param name="RotationOrigin">2D vector describing the center of the rotation.</param>
	/// <param name="Rotation">Angle of rotation, in radians.</param>
	/// <param name="Translation">2D vector describing the translation.</param>
	/// <returns>Returns the transformation matrix.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmmatrixtransformation2d XMMATRIX XM_CALLCONV
	// XMMatrixTransformation2D( [in] FXMVECTOR ScalingOrigin, [in] float ScalingOrientation, [in] FXMVECTOR Scaling, [in] FXMVECTOR
	// RotationOrigin, [in] float Rotation, [in] GXMVECTOR Translation ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMMatrixTransformation2D")]
	public static XMMATRIX XMMatrixTransformation2D(in FXMVECTOR ScalingOrigin, float ScalingOrientation, in FXMVECTOR Scaling, in FXMVECTOR RotationOrigin, float Rotation, in GXMVECTOR Translation)
	{
		// M = Inverse(MScalingOrigin) * Transpose(MScalingOrientation) * MScaling * MScalingOrientation * MScalingOrigin *
		// Inverse(MRotationOrigin) * MRotation * MRotationOrigin * MTranslation;

		XMVECTOR VScalingOrigin = XMVectorSelect(XMVECTOR.g_XMSelect1100, ScalingOrigin, XMVECTOR.g_XMSelect1100);
		XMVECTOR NegScalingOrigin = XMVectorNegate(VScalingOrigin);

		XMMATRIX MScalingOriginI = XMMatrixTranslationFromVector(NegScalingOrigin);
		XMMATRIX MScalingOrientation = XMMatrixRotationZ(ScalingOrientation);
		XMMATRIX MScalingOrientationT = XMMatrixTranspose(MScalingOrientation);
		XMVECTOR VScaling = XMVectorSelect(XMVECTOR.g_XMOne, Scaling, XMVECTOR.g_XMSelect1100);
		XMMATRIX MScaling = XMMatrixScalingFromVector(VScaling);
		XMVECTOR VRotationOrigin = XMVectorSelect(XMVECTOR.g_XMSelect1100, RotationOrigin, XMVECTOR.g_XMSelect1100);
		XMMATRIX MRotation = XMMatrixRotationZ(Rotation);
		XMVECTOR VTranslation = XMVectorSelect(XMVECTOR.g_XMSelect1100, Translation, XMVECTOR.g_XMSelect1100);

		XMMATRIX M = XMMatrixMultiply(MScalingOriginI, MScalingOrientationT);
		M = XMMatrixMultiply(M, MScaling);
		M = XMMatrixMultiply(M, MScalingOrientation);
		M.r[3] = XMVectorAdd(M.r[3], VScalingOrigin);
		M.r[3] = XMVectorSubtract(M.r[3], VRotationOrigin);
		M = XMMatrixMultiply(M, MRotation);
		M.r[3] = XMVectorAdd(M.r[3], VRotationOrigin);
		M.r[3] = XMVectorAdd(M.r[3], VTranslation);

		return M;
	}

	/// <summary>Builds a translation matrix from the specified offsets.</summary>
	/// <param name="OffsetX">Translation along the x-axis.</param>
	/// <param name="OffsetY">Translation along the y-axis.</param>
	/// <param name="OffsetZ">Translation along the z-axis.</param>
	/// <returns>Returns the translation matrix.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmmatrixtranslation XMMATRIX XM_CALLCONV
	// XMMatrixTranslation( [in] float OffsetX, [in] float OffsetY, [in] float OffsetZ ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMMatrixTranslation")]
	public static XMMATRIX XMMatrixTranslation(float OffsetX, float OffsetY, float OffsetZ) =>
		new(1.0f, 0.0f, 0.0f, 0.0f, 0.0f, 1.0f, 0.0f, 0.0f, 0.0f, 0.0f, 1.0f, 0.0f, OffsetX, OffsetY, OffsetZ, 1.0f);

	/// <summary>Builds a translation matrix from a vector.</summary>
	/// <param name="Offset">3D vector describing the translations along the x-axis, y-axis, and z-axis.</param>
	/// <returns>Returns the translation matrix.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmmatrixtranslationfromvector XMMATRIX XM_CALLCONV
	// XMMatrixTranslationFromVector( [in] FXMVECTOR Offset ) noexcept;
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMMatrixTranslationFromVector")]
	public static XMMATRIX XMMatrixTranslationFromVector(this FXMVECTOR Offset) =>
		new(1.0f, 0.0f, 0.0f, 0.0f, 0.0f, 1.0f, 0.0f, 0.0f, 0.0f, 0.0f, 1.0f, 0.0f, Offset[0], Offset[1], Offset[2], 1.0f);

	/// <summary>Computes the transpose of a matrix.</summary>
	/// <param name="M">Matrix to transpose.</param>
	/// <returns>Returns the transpose of <i>M</i>.</returns>
	// https://learn.microsoft.com/en-us/windows/win32/api/directxmath/nf-directxmath-xmmatrixtranspose XMMATRIX XMMatrixTranspose( [in]
	// FXMMATRIX M );
	[PInvokeData("directxmath.h", MSDNShortId = "NF:directxmath.XMMatrixTranspose")]
	public static XMMATRIX XMMatrixTranspose(this FXMMATRIX M)
	{
		var r = M.r;
		XMMATRIX P = new(XMVectorMergeXY(r[0], r[2]), XMVectorMergeXY(r[1], r[3]), XMVectorMergeZW(r[0], r[2]),
			XMVectorMergeZW(r[1], r[3]));
		var p = P.r;
		return new(XMVectorMergeXY(p[0], p[1]), XMVectorMergeZW(p[0], p[1]), XMVectorMergeXY(p[2], p[3]),
			XMVectorMergeZW(p[2], p[3]));
	}

	internal static float GetDeterminant(this XMMATRIX M)
	{
		var m = M.GetSpan<float>(16);
		return m[3] * m[6] * m[9] * m[12] - m[2] * m[7] * m[9] * m[12] -
			m[3] * m[5] * m[10] * m[12] + m[1] * m[7] * m[10] * m[12] +
			m[2] * m[5] * m[11] * m[12] - m[1] * m[6] * m[11] * m[12] -
			m[3] * m[6] * m[8] * m[13] + m[2] * m[7] * m[8] * m[13] +
			m[3] * m[4] * m[10] * m[13] - m[0] * m[7] * m[10] * m[13] -
			m[2] * m[4] * m[11] * m[13] + m[0] * m[6] * m[11] * m[13] +
			m[3] * m[5] * m[8] * m[14] - m[1] * m[7] * m[8] * m[14] -
			m[3] * m[4] * m[9] * m[14] + m[0] * m[7] * m[9] * m[14] +
			m[1] * m[4] * m[11] * m[14] - m[0] * m[5] * m[11] * m[14] -
			m[2] * m[5] * m[8] * m[15] + m[1] * m[6] * m[8] * m[15] +
			m[2] * m[4] * m[9] * m[15] - m[0] * m[6] * m[9] * m[15] -
			m[1] * m[4] * m[10] * m[15] + m[0] * m[5] * m[10] * m[15];
	}

	private static void XM3RANKDECOMPOSE(out SizeT a, out SizeT b, out SizeT c, float x, float y, float z)
	{
		if (x < y)
		{
			if (y < z)
			{
				a = 2;
				b = 1;
				c = 0;
			}
			else
			{
				a = 1;

				if (x < z)
				{
					b = 2;
					c = 0;
				}
				else
				{
					b = 0;
					c = 2;
				}
			}
		}
		else
		{
			if (x < z)
			{
				a = 2;
				b = 0;
				c = 1;
			}
			else
			{
				a = 0;

				if (y < z)
				{
					b = 2;
					c = 1;
				}
				else
				{
					b = 1;
					c = 2;
				}
			}
		}
	}
}