namespace Vanara.PInvoke;

public static partial class D2d1
{
	/// <summary>CLSID_D2D1YCbCr</summary>
	public static readonly Guid CLSID_D2D1YCbCr = new(0x99503cc1, 0x66c7, 0x45c9, 0xa8, 0x75, 0x8a, 0xd8, 0xa7, 0x91, 0x44, 0x01);

	/// <summary>Specifies the chroma subsampling of the input chroma image used by the <c>YCbCr effect</c>.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effects_1/ne-d2d1effects_1-d2d1_ycbcr_chroma_subsampling typedef enum
	// D2D1_YCBCR_CHROMA_SUBSAMPLING { D2D1_YCBCR_CHROMA_SUBSAMPLING_AUTO = 0, D2D1_YCBCR_CHROMA_SUBSAMPLING_420 = 1,
	// D2D1_YCBCR_CHROMA_SUBSAMPLING_422 = 2, D2D1_YCBCR_CHROMA_SUBSAMPLING_444 = 3, D2D1_YCBCR_CHROMA_SUBSAMPLING_440 = 4,
	// D2D1_YCBCR_CHROMA_SUBSAMPLING_FORCE_DWORD = 0xffffffff } ;
	[PInvokeData("d2d1effects_1.h", MSDNShortId = "NE:d2d1effects_1.D2D1_YCBCR_CHROMA_SUBSAMPLING")]
	public enum D2D1_YCBCR_CHROMA_SUBSAMPLING : uint
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>
		/// This mode attempts to infer the chroma subsampling from the bounds of the input images. When this option is selected, the
		/// smaller plane is upsampled to the size of the larger plane and this effect’s output rectangle is the intersection of the two planes.
		/// </para>
		/// <para>
		/// When using this mode, care should be taken when applying effects to the input planes that change the image bounds, such as the
		/// border transform, so that the desired size ratio between the planes is maintained.
		/// </para>
		/// </summary>
		D2D1_YCBCR_CHROMA_SUBSAMPLING_AUTO,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>The chroma plane is horizontally subsampled by 1/2 and vertically subsampled by 1/2.</para>
		/// <para>
		/// When this option is selected, the chroma plane is horizontally and vertically upsampled by 2x and this effect's output rectangle
		/// is the intersection of the two planes.
		/// </para>
		/// </summary>
		D2D1_YCBCR_CHROMA_SUBSAMPLING_420,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>
		/// The chroma plane is horizontally subsampled by 1/2. When this option is selected, the chroma plane is horizontally upsampled by
		/// 2x and this effect's output rectangle is the intersection of the two planes.
		/// </para>
		/// </summary>
		D2D1_YCBCR_CHROMA_SUBSAMPLING_422,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>
		/// The chroma plane is not subsampled. When this option is selected this effect’s output rectangle is the intersection of the two planes.
		/// </para>
		/// </summary>
		D2D1_YCBCR_CHROMA_SUBSAMPLING_444,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>
		/// The chroma plane is vertically subsampled by 1/2. When this option is selected, the chroma plane is vertically upsampled by 2x
		/// and this effect's output rectangle is the intersection of the two planes.</para>
		/// </summary>
		D2D1_YCBCR_CHROMA_SUBSAMPLING_440,
	}

	/// <summary>Specifies the interpolation mode for the <c>YCbCr effect</c>.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effects_1/ne-d2d1effects_1-d2d1_ycbcr_interpolation_mode typedef enum
	// D2D1_YCBCR_INTERPOLATION_MODE { D2D1_YCBCR_INTERPOLATION_MODE_NEAREST_NEIGHBOR = 0, D2D1_YCBCR_INTERPOLATION_MODE_LINEAR = 1,
	// D2D1_YCBCR_INTERPOLATION_MODE_CUBIC = 2, D2D1_YCBCR_INTERPOLATION_MODE_MULTI_SAMPLE_LINEAR = 3,
	// D2D1_YCBCR_INTERPOLATION_MODE_ANISOTROPIC = 4, D2D1_YCBCR_INTERPOLATION_MODE_HIGH_QUALITY_CUBIC = 5,
	// D2D1_YCBCR_INTERPOLATION_MODE_FORCE_DWORD = 0xffffffff } ;
	[PInvokeData("d2d1effects_1.h", MSDNShortId = "NE:d2d1effects_1.D2D1_YCBCR_INTERPOLATION_MODE")]
	public enum D2D1_YCBCR_INTERPOLATION_MODE : uint
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Samples the nearest single point and uses that. This mode uses less processing time, but outputs the lowest quality image.</para>
		/// </summary>
		D2D1_YCBCR_INTERPOLATION_MODE_NEAREST_NEIGHBOR,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>
		/// Uses a four point sample and linear interpolation. This mode uses more processing time than the nearest neighbor mode, but
		/// outputs a higher quality image.
		/// </para>
		/// </summary>
		D2D1_YCBCR_INTERPOLATION_MODE_LINEAR,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>
		/// Uses a 16 sample cubic kernel for interpolation. This mode uses the most processing time, but outputs a higher quality image.
		/// </para>
		/// </summary>
		D2D1_YCBCR_INTERPOLATION_MODE_CUBIC,

		/// <summary>
		/// <para>Value:</para>
		/// <para>3</para>
		/// <para>
		/// Uses 4 linear samples within a single pixel for good edge anti-aliasing. This mode is good for scaling down by small amounts on
		/// images with few pixels.
		/// </para>
		/// </summary>
		D2D1_YCBCR_INTERPOLATION_MODE_MULTI_SAMPLE_LINEAR,

		/// <summary>
		/// <para>Value:</para>
		/// <para>4</para>
		/// <para>Uses anisotropic filtering to sample a pattern according to the transformed shape of the bitmap.</para>
		/// </summary>
		D2D1_YCBCR_INTERPOLATION_MODE_ANISOTROPIC,

		/// <summary>
		/// <para>Value:</para>
		/// <para>5</para>
		/// <para>
		/// Uses a variable size high quality cubic kernel to perform a pre-downscale the image if downscaling is involved in the transform
		/// matrix. Then uses the cubic interpolation mode for the final output.
		/// </para>
		/// </summary>
		D2D1_YCBCR_INTERPOLATION_MODE_HIGH_QUALITY_CUBIC,
	}

	/// <summary>Identifiers for properties of the <c>YCbCr effect</c>.</summary>
	// https://learn.microsoft.com/en-us/windows/win32/api/d2d1effects_1/ne-d2d1effects_1-d2d1_ycbcr_prop typedef enum D2D1_YCBCR_PROP {
	// D2D1_YCBCR_PROP_CHROMA_SUBSAMPLING = 0, D2D1_YCBCR_PROP_TRANSFORM_MATRIX = 1, D2D1_YCBCR_PROP_INTERPOLATION_MODE = 2,
	// D2D1_YCBCR_PROP_FORCE_DWORD = 0xffffffff } ;
	[PInvokeData("d2d1effects_1.h", MSDNShortId = "NE:d2d1effects_1.D2D1_YCBCR_PROP")]
	public enum D2D1_YCBCR_PROP : uint
	{
		/// <summary>
		/// <para>Value:</para>
		/// <para>0</para>
		/// <para>Specifies the chroma subsampling of the input chroma image.</para>
		/// <para>The type is</para>
		/// <para>D2D1_YCBCR_CHROMA_SUBSAMPLING</para>
		/// <para>.</para>
		/// <para>The default value is D2D1_YCBCR_CHROMA_SUBSAMPLING_AUTO.</para>
		/// </summary>
		[CorrespondingType(typeof(D2D1_YCBCR_CHROMA_SUBSAMPLING))]
		D2D1_YCBCR_PROP_CHROMA_SUBSAMPLING,

		/// <summary>
		/// <para>Value:</para>
		/// <para>1</para>
		/// <para>
		/// A 3x2 Matrix specifying the axis-aligned affine transform of the image. Axis aligned transforms include Scale, Flips, and 90
		/// degree rotations.
		/// </para>
		/// <para>The type is</para>
		/// <para>D2D1_MATRIX_3X2_F</para>
		/// <para>.</para>
		/// <para>The default value is Matrix3x2F::Identity().</para>
		/// </summary>
		[CorrespondingType(typeof(D2D1_MATRIX_3X2_F))]
		D2D1_YCBCR_PROP_TRANSFORM_MATRIX,

		/// <summary>
		/// <para>Value:</para>
		/// <para>2</para>
		/// <para>The interpolation mode.</para>
		/// <para>The type is</para>
		/// <para>D2D1_YCBCR_INTERPOLATION_MODE</para>
		/// <para>.</para>
		/// </summary>
		[CorrespondingType(typeof(D2D1_YCBCR_INTERPOLATION_MODE))]
		D2D1_YCBCR_PROP_INTERPOLATION_MODE,
	}
}